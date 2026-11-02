using System.Text.Json;
using Microsoft.Extensions.AI;

namespace MovilidadUrbana.Ejemplos.Mcp.Cliente.SinModelo;

/// <summary>
/// Modo sin modelo: hace de «modelo» con un guion fijo. Para cada pregunta conocida pide una herramienta;
/// cuando recibe el resultado, lo repite como texto. Lo que se ve es el cableado (bucle, herramientas,
/// casos de uso y sesión), no el comportamiento de ningún modelo.
/// </summary>
public sealed class ClienteGuionado(IReadOnlyDictionary<string, FunctionCallContent> guion) : IChatClient
{
    public int Llamadas { get; private set; }

    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
    {
        Llamadas++;
        var lista = messages.ToList();
        var resultado = lista[^1].Contents.OfType<FunctionResultContent>().LastOrDefault();
        if (resultado is not null)
            return Responder(new TextContent($"(sin modelo) La herramienta devolvió: {(resultado.Result is JsonElement e ? e.GetRawText() : JsonSerializer.Serialize(resultado.Result))}"));

        var pregunta = lista.Last(m => m.Role == ChatRole.User).Text;
        return guion.TryGetValue(pregunta, out var pedido)
            ? Responder(new FunctionCallContent($"guion-{Llamadas}", pedido.Name, pedido.Arguments))
            : Responder(new TextContent("(sin modelo) No tengo guion para esa pregunta."));
    }

    private static Task<ChatResponse> Responder(AIContent contenido) =>
        Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, [contenido])));

    public IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
        => throw new NotSupportedException("El ejemplo no usa streaming.");

    public object? GetService(Type serviceType, object? serviceKey = null) => serviceType.IsInstanceOfType(this) ? this : null;
    public void Dispose() { }
}
