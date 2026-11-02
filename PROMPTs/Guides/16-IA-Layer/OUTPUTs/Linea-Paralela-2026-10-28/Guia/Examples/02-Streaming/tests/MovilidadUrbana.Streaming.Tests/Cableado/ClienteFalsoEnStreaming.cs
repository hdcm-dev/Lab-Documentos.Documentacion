using System.Runtime.CompilerServices;
using Microsoft.Extensions.AI;

namespace MovilidadUrbana.Streaming.Tests.Cableado;

/// <summary>
/// IChatClient con guion: emite los fragmentos dados, con una espera entre uno y el siguiente, y al final el uso.
/// Ante la cancelación lanza <see cref="OperationCanceledException"/> o, con <paramref name="cortaEnSilencio"/>,
/// termina la enumeración sin lanzar (lo que se observó con OllamaSharp 5.5.0).
/// </summary>
public sealed class ClienteFalsoEnStreaming(IReadOnlyList<string> guion, TimeSpan espera, bool cortaEnSilencio = false) : IChatClient
{
    public int Llamadas { get; private set; }
    public int FragmentosEmitidos { get; private set; }
    public bool VioLaCancelacion { get; private set; }
    public ChatOptions? UltimasOpciones { get; private set; }
    public IReadOnlyList<ChatMessage> UltimosMensajes { get; private set; } = [];

    public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(
        IEnumerable<ChatMessage> messages, ChatOptions? options = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        Llamadas++;
        UltimasOpciones = options;
        UltimosMensajes = [.. messages];
        foreach (var texto in guion)
        {
            bool cortado = false;
            try { if (FragmentosEmitidos > 0) await Task.Delay(espera, cancellationToken); }   // el primero sale enseguida
            catch (OperationCanceledException) { VioLaCancelacion = true; if (!cortaEnSilencio) throw; cortado = true; }
            if (cortado) yield break;
            FragmentosEmitidos++;
            yield return new ChatResponseUpdate(ChatRole.Assistant, texto) { MessageId = "m1" };
        }
        yield return new ChatResponseUpdate
        {
            Role = ChatRole.Assistant,
            MessageId = "m1",
            FinishReason = ChatFinishReason.Stop,
            Contents = [new UsageContent(new UsageDetails { InputTokenCount = 120, OutputTokenCount = guion.Count })],
        };
    }

    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null,
        CancellationToken cancellationToken = default) => throw new NotSupportedException("Este ejemplo sólo usa streaming.");

    public object? GetService(Type serviceType, object? serviceKey = null) => null;
    public void Dispose() { }
}
