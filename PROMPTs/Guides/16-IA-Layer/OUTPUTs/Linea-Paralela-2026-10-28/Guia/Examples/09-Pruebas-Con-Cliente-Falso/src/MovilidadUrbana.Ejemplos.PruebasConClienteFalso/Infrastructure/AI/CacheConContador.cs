using Microsoft.Extensions.AI;
using Microsoft.Extensions.Caching.Distributed;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;

/// <summary>
/// Caché de respuestas que va por fuera de <c>UseFunctionInvocation</c> y cuenta sus aciertos en
/// <see cref="TelemetriaDeIA.AciertosDeCache"/>.
/// <list type="bullet">
/// <item>Se sobrescriben los DOS métodos de lectura: con <c>CoalesceStreamingUpdates</c> en <c>true</c> (el valor
/// por defecto) el streaming lee por <c>ReadCacheAsync</c>; con <c>false</c>, por <c>ReadCacheStreamingAsync</c>.
/// En cada acierto se llama uno solo de los dos: no hay doble conteo.</item>
/// <item>La clave suma los valores que devuelve <paramref name="valoresDeLaClave"/> EN CADA PEDIDO
/// (en la composición: <c>[SessionId, VersionDeDatos]</c>). Leerlos al crear la instancia deja la versión vieja.</item>
/// <item>Un acierto no vuelve a ejecutar las herramientas: devuelve la respuesta tal como se armó.</item>
/// </list>
/// </summary>
public class CacheConContador(IChatClient interno, IDistributedCache cache, Func<object?[]> valoresDeLaClave)
    : DistributedCachingChatClient(interno, cache)
{
    protected override string GetCacheKey(IEnumerable<ChatMessage> messages, ChatOptions? options, params ReadOnlySpan<object?> additionalValues)
        => base.GetCacheKey(messages, options, [.. additionalValues, .. valoresDeLaClave()]);

    protected override async Task<ChatResponse?> ReadCacheAsync(string key, CancellationToken cancellationToken)
    {
        var respuesta = await base.ReadCacheAsync(key, cancellationToken);
        if (respuesta is not null) TelemetriaDeIA.Aciertos.Add(1);
        return respuesta;
    }

    protected override async Task<IReadOnlyList<ChatResponseUpdate>?> ReadCacheStreamingAsync(string key, CancellationToken cancellationToken)
    {
        var fragmentos = await base.ReadCacheStreamingAsync(key, cancellationToken);
        if (fragmentos is not null) TelemetriaDeIA.Aciertos.Add(1);
        return fragmentos;
    }
}
