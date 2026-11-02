using System.Diagnostics.Metrics;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Caching.Distributed;

namespace MovilidadUrbana.Asistente.Infrastructure.AI;

/// <summary>
/// Caché de respuestas que cuenta sus aciertos en <see cref="TelemetriaDeIA.AciertosDeCache"/>, por los dos
/// caminos de lectura: <c>ReadCacheAsync</c> y <c>ReadCacheStreamingAsync</c> (con
/// <c>CoalesceStreamingUpdates = false</c> el streaming lee por el segundo). Cuenta 1 por acierto.
///
/// Regla de la demo: no cachea pedidos que llevan herramientas. Un acierto no vuelve a ejecutarlas, así que
/// devolvería lo que leyeron entonces, aunque la persona haya dado de alta o de baja algo después.
/// Se crea por ámbito y la clave lleva la sesión (<c>CacheKeyAdditionalValues = [SessionId]</c>).
/// </summary>
public class CacheConContador(IChatClient interno, IDistributedCache almacen, Counter<long>? aciertos = null)
    : DistributedCachingChatClient(interno, almacen)
{
    private readonly Counter<long> _aciertos = aciertos ?? TelemetriaDeIA.Aciertos;

    protected override bool EnableCaching(IEnumerable<ChatMessage> messages, ChatOptions? options) =>
        options?.Tools is not { Count: > 0 } && base.EnableCaching(messages, options);

    protected override async Task<ChatResponse?> ReadCacheAsync(string key, CancellationToken cancellationToken)
    {
        var respuesta = await base.ReadCacheAsync(key, cancellationToken);
        if (respuesta is not null) _aciertos.Add(1);
        return respuesta;
    }

    protected override async Task<IReadOnlyList<ChatResponseUpdate>?> ReadCacheStreamingAsync(string key, CancellationToken cancellationToken)
    {
        var respuesta = await base.ReadCacheStreamingAsync(key, cancellationToken);
        if (respuesta is not null) _aciertos.Add(1);
        return respuesta;
    }
}
