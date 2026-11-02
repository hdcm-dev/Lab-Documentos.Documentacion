using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.Extensions.AI;

namespace MovilidadUrbana.Asistente.Tests.Comun;

/// <summary>Lo que el cliente falso vio en una llamada.</summary>
public sealed record LlamadaVista(IReadOnlyList<ChatMessage> Mensajes, ChatOptions? Opciones)
{
    public string Sistema => Mensajes.FirstOrDefault(m => m.Role == ChatRole.System)?.Text ?? string.Empty;

    public IReadOnlyList<string> Herramientas => Opciones?.Tools?.Select(t => t.Name).ToList() ?? [];

    public FunctionResultContent? UltimoResultado =>
        Mensajes.SelectMany(m => m.Contents).OfType<FunctionResultContent>().LastOrDefault();
}

/// <summary>
/// IChatClient guionado y determinista: cada llamada consume el siguiente paso del guion, o, si el guion
/// es reactivo, decide por lo que recibe. No hay modelo: lo que «dice el modelo» lo escribe la prueba.
/// </summary>
public sealed class ClienteFalso : IChatClient
{
    private readonly ConcurrentQueue<Func<LlamadaVista, ChatResponse>> _pasos = new();
    private readonly Func<LlamadaVista, ChatResponse>? _reactivo;
    private readonly ConcurrentQueue<LlamadaVista> _llamadas = new();

    public ClienteFalso(params Func<LlamadaVista, ChatResponse>[] pasos)
    {
        foreach (var p in pasos) _pasos.Enqueue(p);
    }

    private ClienteFalso(Func<LlamadaVista, ChatResponse> reactivo) => _reactivo = reactivo;

    /// <summary>Un cliente que decide cada respuesta por lo que recibe (sin orden fijo; sirve con concurrencia).</summary>
    public static ClienteFalso Reactivo(Func<LlamadaVista, ChatResponse> decidir) => new(decidir);

    /// <summary>Demora antes de responder, respetando la cancelación.</summary>
    public TimeSpan Demora { get; init; }

    public IReadOnlyList<LlamadaVista> Llamadas => _llamadas.ToList();

    public int CantidadDeLlamadas => _llamadas.Count;

    public async Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
    {
        var vista = new LlamadaVista(messages.ToList(), options);
        _llamadas.Enqueue(vista);
        if (Demora > TimeSpan.Zero) await Task.Delay(Demora, cancellationToken);
        cancellationToken.ThrowIfCancellationRequested();
        if (_reactivo is not null) return _reactivo(vista);
        if (!_pasos.TryDequeue(out var paso))
            throw new InvalidOperationException($"El guion no prevé la llamada {_llamadas.Count}.");
        return paso(vista);
    }

    public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var respuesta = await GetResponseAsync(messages, options, cancellationToken);
        foreach (var u in Trozar(respuesta)) { cancellationToken.ThrowIfCancellationRequested(); yield return u; }
    }

    // El texto llega en varios trozos, como por streaming.
    private static IEnumerable<ChatResponseUpdate> Trozar(ChatResponse r)
    {
        var mensaje = r.Messages.Last();
        if (mensaje.Contents.All(c => c is TextContent) && mensaje.Text.Length > 0)
        {
            var texto = mensaje.Text;
            for (var i = 0; i < texto.Length; i += 12)
                yield return new ChatResponseUpdate(ChatRole.Assistant, texto.Substring(i, Math.Min(12, texto.Length - i))) { ModelId = r.ModelId };
            yield break;
        }
        foreach (var u in r.ToChatResponseUpdates()) yield return u;
    }

    public object? GetService(Type serviceType, object? serviceKey = null) => serviceType.IsInstanceOfType(this) ? this : null;

    public void Dispose() { }
}

/// <summary>Respuestas que se usan en los guiones.</summary>
public static class Responde
{
    public static ChatResponse Texto(string texto) =>
        new(new ChatMessage(ChatRole.Assistant, texto)) { ModelId = "falso", Usage = new UsageDetails { InputTokenCount = 10, OutputTokenCount = 3 } };

    public static ChatResponse Json(object valor) => Texto(JsonSerializer.Serialize(valor, AIJsonUtilities.DefaultOptions));

    public static ChatResponse Llamar(string herramienta, Dictionary<string, object?>? argumentos = null) =>
        new(new ChatMessage(ChatRole.Assistant, [new FunctionCallContent("c-" + Guid.NewGuid().ToString("n")[..6], herramienta, argumentos ?? [])])) { ModelId = "falso" };

    public static Func<LlamadaVista, ChatResponse> Intencion(string intencion) => _ => Json(new { intencion });

    /// <summary>Devuelve como texto el último resultado de herramienta que recibió.</summary>
    public static ChatResponse EcoDelResultado(LlamadaVista v) => Texto(v.UltimoResultado?.Result?.ToString() ?? "(sin resultado)");
}
