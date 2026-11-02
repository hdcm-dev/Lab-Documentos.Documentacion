using System.Runtime.CompilerServices;
using Microsoft.Extensions.AI;

namespace MovilidadUrbana.Ejemplos.Orquestacion.SinModelo;

/// <summary>Un pedido que recibió el cliente guionado: con qué instrucciones, cuántos mensajes, qué devolvió.</summary>
public sealed record LlamadaRegistrada(string? Instrucciones, int Mensajes, bool OfrecioHerramientas, string Respuesta);

/// <summary>
/// Hace de modelo en el modo sin modelo y en las pruebas de cableado: responde con un guion y registra
/// cada pedido. Muestra el cableado (orden de los pasos, puerto, escrituras), no el comportamiento de un modelo.
/// </summary>
public sealed class ClienteGuionado(Func<IReadOnlyList<ChatMessage>, ChatOptions?, string> guion) : IChatClient
{
    private readonly List<LlamadaRegistrada> _llamadas = [];

    public IReadOnlyList<LlamadaRegistrada> Llamadas { get { lock (_llamadas) return _llamadas.ToList(); } }

    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var lista = messages.ToList();
        var texto = guion(lista, options);
        lock (_llamadas) _llamadas.Add(new(options?.Instructions, lista.Count, options?.Tools is { Count: > 0 }, texto));
        return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, texto)));
    }

    public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var r = await GetResponseAsync(messages, options, cancellationToken);
        foreach (var u in r.ToChatResponseUpdates()) yield return u;
    }

    public object? GetService(Type serviceType, object? serviceKey = null) => serviceType.IsInstanceOfType(this) ? this : null;

    public void Dispose() { }
}
