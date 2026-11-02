using Microsoft.Extensions.AI;

namespace MovilidadUrbana.SalidaEstructurada.Tests.Dobles;

/// <summary>Cliente de chat guionado: devuelve siempre el mismo texto y cuenta las llamadas.</summary>
public sealed class ClienteFalso(string respuesta) : IChatClient
{
    public int Llamadas { get; private set; }

    public Task<ChatResponse> GetResponseAsync(
        IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
    {
        Llamadas++;
        return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, respuesta)));
    }

    public IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(
        IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default) =>
        throw new NotSupportedException();

    public object? GetService(Type serviceType, object? serviceKey = null) => null;

    public void Dispose() { }
}
