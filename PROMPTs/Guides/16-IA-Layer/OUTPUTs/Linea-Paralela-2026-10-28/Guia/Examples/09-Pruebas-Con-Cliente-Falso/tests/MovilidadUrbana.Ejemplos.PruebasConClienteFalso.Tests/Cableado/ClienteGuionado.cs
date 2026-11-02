using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Extensions.AI;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests.Cableado;

/// <summary>
/// <c>IChatClient</c> falso para pruebas deterministas: cuenta llamadas, guarda las opciones recibidas y
/// completa <c>Usage</c>, para poder afirmar sobre caché, esquema y telemetría. No es un modelo: es un guion.
/// <list type="bullet">
/// <item>Con <see cref="Responder"/>: devuelve ese texto (salida estructurada, demoras).</item>
/// <item>Si el último texto de la persona empieza con <c>LLAMAR:herramienta:{json}</c>, pide esa herramienta.</item>
/// <item>Si no, con herramientas en las opciones y sin resultado todavía, pide
/// <c>contar_localidades_por_provincia({"provincia":"Corrientes"})</c>; con el resultado, lo redacta.</item>
/// </list>
/// </summary>
public sealed class ClienteGuionado : IChatClient
{
    private int _llamadas;

    public int Llamadas => _llamadas;
    public ChatOptions? UltimasOpciones { get; private set; }
    public Func<IEnumerable<ChatMessage>, string>? Responder { get; init; }
    public TimeSpan Demora { get; init; }
    public long TokensDeEntrada { get; init; } = 12;

    /// <summary>Resultados de herramienta que vio el «modelo», en orden (texto o «EXC Tipo»).</summary>
    public List<string> ResultadosVistos { get; } = [];

    public async Task<ChatResponse> GetResponseAsync(
        IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
    {
        Interlocked.Increment(ref _llamadas);
        UltimasOpciones = options;
        if (Demora > TimeSpan.Zero) await Task.Delay(Demora, cancellationToken);
        var uso = new UsageDetails { InputTokenCount = TokensDeEntrada, OutputTokenCount = 3 };

        if (Responder is not null)
            return new ChatResponse(new ChatMessage(ChatRole.Assistant, Responder(messages))) { Usage = uso };

        var lista = messages.ToList();
        int iUsuario = lista.FindLastIndex(m => m.Role == ChatRole.User);
        int iResultado = lista.FindLastIndex(m => m.Contents.OfType<FunctionResultContent>().Any());
        var resultado = iResultado > iUsuario ? lista[iResultado].Contents.OfType<FunctionResultContent>().Last() : null;

        if (resultado is null && options?.Tools is { Count: > 0 })
        {
            var texto = iUsuario >= 0 ? lista[iUsuario].Text : string.Empty;
            var (nombre, argumentos) = texto.StartsWith("LLAMAR:", StringComparison.Ordinal)
                ? Pedido(texto)
                : (HerramientasDeLocalidades.ContarPorProvincia, new Dictionary<string, object?> { ["provincia"] = "Corrientes" });
            return new ChatResponse(new ChatMessage(ChatRole.Assistant,
                [new FunctionCallContent($"llamada-{_llamadas}", nombre, argumentos)])) { Usage = uso };
        }

        string visto = resultado is null ? "(sin herramienta)"
            : resultado.Exception is { } ex ? $"EXC {ex.GetType().Name}"
            : JsonSerializer.Serialize(resultado.Result);
        lock (ResultadosVistos) ResultadosVistos.Add(visto);
        var cantidad = Regex.Match(visto, "\"cantidad\"\\s*:\\s*(\\d+)", RegexOptions.IgnoreCase);
        var respuesta = cantidad.Success ? $"Hay {cantidad.Groups[1].Value} localidades cargadas en Corrientes." : visto;
        return new ChatResponse(new ChatMessage(ChatRole.Assistant, respuesta)) { Usage = uso };
    }

    public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(
        IEnumerable<ChatMessage> messages, ChatOptions? options = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var r = await GetResponseAsync(messages, options, cancellationToken);
        foreach (var u in r.ToChatResponseUpdates()) yield return u;
    }

    public object? GetService(Type serviceType, object? serviceKey = null) => serviceType.IsInstanceOfType(this) ? this : null;

    public void Dispose() { }

    private static (string, Dictionary<string, object?>) Pedido(string texto)
    {
        var partes = texto.Split(':', 3);
        return (partes[1], JsonSerializer.Deserialize<Dictionary<string, object?>>(partes[2]) ?? []);
    }
}
