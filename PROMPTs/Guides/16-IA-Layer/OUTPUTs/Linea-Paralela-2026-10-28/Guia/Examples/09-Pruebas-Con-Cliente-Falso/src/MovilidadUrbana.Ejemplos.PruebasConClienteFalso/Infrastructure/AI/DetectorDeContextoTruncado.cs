using System.Runtime.CompilerServices;
using Microsoft.Extensions.AI;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;

/// <summary>
/// Decorador del cliente del proveedor. Si el prompt supera <c>num_ctx</c>, Ollama lo recorta sin dar error
/// y la respuesta parece válida. Este decorador compara <c>Usage.InputTokenCount</c> con el largo esperado
/// (medido antes con el MISMO modelo: el token es una unidad de cada modelo) y, si llegó menos, lo trata
/// como error («contexto truncado»), no como respuesta.
/// <para>El largo esperado lo fija quien lo conoce (el adaptador o la prueba) con
/// <see cref="FijarLargoEsperado"/>. Viaja en <see cref="ChatOptions.AdditionalProperties"/> y el decorador
/// lo saca antes de pasar el pedido al proveedor, para que no llegue al cuerpo del pedido HTTP.</para>
/// </summary>
public sealed class DetectorDeContextoTruncado(IChatClient interno) : DelegatingChatClient(interno)
{
    public const string ClaveDelLargoEsperado = "movilidadurbana.largo_esperado";

    public static ChatOptions FijarLargoEsperado(ChatOptions opciones, long tokens)
    {
        (opciones.AdditionalProperties ??= [])[ClaveDelLargoEsperado] = tokens;
        return opciones;
    }

    public override async Task<ChatResponse> GetResponseAsync(
        IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
    {
        var (esperado, limpias) = Separar(options);
        var respuesta = await base.GetResponseAsync(messages, limpias, cancellationToken);
        Verificar(esperado, respuesta.Usage?.InputTokenCount);
        return respuesta;
    }

    public override async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(
        IEnumerable<ChatMessage> messages, ChatOptions? options = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var (esperado, limpias) = Separar(options);
        long? recibido = null;
        await foreach (var fragmento in base.GetStreamingResponseAsync(messages, limpias, cancellationToken))
        {
            foreach (var uso in fragmento.Contents.OfType<UsageContent>())
                recibido = uso.Details.InputTokenCount ?? recibido;
            yield return fragmento;
        }
        Verificar(esperado, recibido);
    }

    private static (long? Esperado, ChatOptions? Limpias) Separar(ChatOptions? options)
    {
        if (options?.AdditionalProperties is not { } extra || !extra.TryGetValue(ClaveDelLargoEsperado, out var valor))
            return (null, options);

        var limpias = options.Clone();
        limpias.AdditionalProperties = new(extra);
        limpias.AdditionalProperties.Remove(ClaveDelLargoEsperado);
        return (Convert.ToInt64(valor), limpias);
    }

    private static void Verificar(long? esperado, long? recibido)
    {
        if (esperado is { } e && recibido is { } r && r < e)
            throw new ContextoTruncadoException(e, r);
    }
}

/// <summary>El servidor procesó menos tokens de los que se mandaron: la respuesta no se usa.</summary>
public sealed class ContextoTruncadoException(long esperado, long recibido)
    : Exception($"contexto truncado: se esperaban {esperado} tokens de entrada y el servidor procesó {recibido}.")
{
    public long Esperado { get; } = esperado;
    public long Recibido { get; } = recibido;
}
