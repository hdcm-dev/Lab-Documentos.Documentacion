using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Extensions.AI;

namespace MovilidadUrbana.Ejemplos.AgenteConAprobacion.SinModelo;

/// <summary>
/// Modo sin modelo: un <see cref="IChatClient"/> determinista que hace lo que haría un modelo obediente.
///  - «¿Cuántas localidades hay en X?» o «¿Y en X?» → pide contar_localidades(X) y responde con la cantidad.
///  - «Borrá X» → pide listar_localidades, busca el id de X y pide eliminar_localidad(id).
///  - «Agregá N, P, CP C, H habitantes» → pide agregar_localidad.
/// No decide nada que la aplicación no controle: las escrituras igual esperan la aprobación.
/// </summary>
public sealed partial class ClienteGuionado : IChatClient
{
    public int Llamadas { get; private set; }
    public List<ChatOptions?> OpcionesRecibidas { get; } = [];
    public List<List<ChatMessage>> MensajesRecibidos { get; } = [];

    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default) =>
        Task.FromResult(Responder(messages, options));

    private ChatResponse Responder(IEnumerable<ChatMessage> messages, ChatOptions? options)
    {
        Llamadas++;
        var lista = messages.ToList();
        OpcionesRecibidas.Add(options);
        MensajesRecibidos.Add(lista);

        int iTexto = lista.FindLastIndex(m => m.Role == ChatRole.User && !string.IsNullOrWhiteSpace(m.Text));
        string texto = iTexto >= 0 ? lista[iTexto].Text : "";
        var resultados = lista.Skip(iTexto + 1).SelectMany(m => m.Contents).OfType<FunctionResultContent>().ToList();
        var llamadas = lista.Skip(iTexto + 1).SelectMany(m => m.Contents).OfType<FunctionCallContent>().ToList();
        string? ultimo = resultados.Count > 0 ? Texto(resultados[^1].Result) : null;
        string? herramientaDelUltimo = resultados.Count > 0 ? llamadas.FirstOrDefault(c => c.CallId == resultados[^1].CallId)?.Name : null;

        if (Contar().Match(texto) is { Success: true } mc)
        {
            if (ultimo is null) return Pedir("contar_localidades", new() { ["provincia"] = mc.Groups["p"].Value.Trim() });
            using var d = JsonDocument.Parse(ultimo);
            return Decir(d.RootElement.TryGetProperty("cantidad", out var n)
                ? $"En {mc.Groups["p"].Value.Trim()} hay {n.GetInt32()} localidad(es) cargada(s)."
                : $"No pude contar: {ultimo}");
        }

        if (Borrar().Match(texto) is { Success: true } mb)
        {
            var nombre = mb.Groups["n"].Value.Trim();
            if (ultimo is null) return Pedir("listar_localidades", new());
            if (herramientaDelUltimo == "listar_localidades")
            {
                using var d = JsonDocument.Parse(ultimo);
                foreach (var l in d.RootElement.GetProperty("localidades").EnumerateArray())
                    if (string.Equals(l.GetProperty("nombre").GetString(), nombre, StringComparison.OrdinalIgnoreCase))
                        return Pedir("eliminar_localidad", new() { ["id"] = l.GetProperty("id").GetInt32() });
                return Decir($"No encontré «{nombre}» entre tus localidades.");
            }
            return Decir($"Resultado: {ultimo}");
        }

        if (AgregarRx().Match(texto) is { Success: true } ma)
        {
            if (ultimo is null)
                return Pedir("agregar_localidad", new()
                {
                    ["nombre"] = ma.Groups["n"].Value.Trim(), ["provincia"] = ma.Groups["p"].Value.Trim(),
                    ["codigoPostal"] = ma.Groups["c"].Value.Trim(), ["habitantes"] = int.Parse(ma.Groups["h"].Value),
                });
            return Decir($"Resultado: {ultimo}");
        }

        return Decir(ultimo is null ? "(modo sin modelo: no entiendo ese pedido)" : $"Resultado: {ultimo}");
    }

    public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        foreach (var u in (await GetResponseAsync(messages, options, cancellationToken)).ToChatResponseUpdates()) yield return u;
    }

    public object? GetService(Type serviceType, object? serviceKey = null) => serviceType.IsInstanceOfType(this) ? this : null;
    public void Dispose() { }

    private static ChatResponse Pedir(string herramienta, Dictionary<string, object?> argumentos) =>
        new(new ChatMessage(ChatRole.Assistant, [new FunctionCallContent("call-" + Guid.NewGuid().ToString("n")[..6], herramienta, argumentos)]))
            { FinishReason = ChatFinishReason.ToolCalls };

    private static ChatResponse Decir(string texto) => new(new ChatMessage(ChatRole.Assistant, texto)) { FinishReason = ChatFinishReason.Stop };

    private static string Texto(object? resultado) => resultado switch
    {
        null => "null",
        string s => s,
        JsonElement e => e.ValueKind == JsonValueKind.String ? e.GetString()! : e.GetRawText(),
        _ => JsonSerializer.Serialize(resultado),
    };

    [GeneratedRegex(@"cu[aá]ntas localidades hay en (?<p>[^?¿]+)|^¿?\s*[Yy] en (?<p>[^?¿]+)", RegexOptions.IgnoreCase)]
    private static partial Regex Contar();

    [GeneratedRegex(@"borr[aá]\s+(?:la localidad\s+)?(?<n>[^.,!?]+)", RegexOptions.IgnoreCase)]
    private static partial Regex Borrar();

    [GeneratedRegex(@"agreg[aá]\s+(?<n>[^,]+),\s*(?<p>[^,]+),\s*CP\s*(?<c>\S+),\s*(?<h>\d+)\s*habitantes", RegexOptions.IgnoreCase)]
    private static partial Regex AgregarRx();
}
