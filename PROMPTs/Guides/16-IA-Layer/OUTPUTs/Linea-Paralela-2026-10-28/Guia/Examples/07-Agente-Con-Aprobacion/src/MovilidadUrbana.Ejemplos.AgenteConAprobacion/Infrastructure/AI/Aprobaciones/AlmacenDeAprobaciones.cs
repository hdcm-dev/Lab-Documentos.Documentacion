using System.Collections.Concurrent;
using System.Security.Cryptography;
using Microsoft.Extensions.AI;

namespace MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI.Aprobaciones;

/// <summary>Lo que el servidor guarda de una aprobación pendiente. Nunca viaja al cliente (A1).</summary>
public sealed record AprobacionGuardada(
    string SessionId, string ConversacionId, string RequestId, FunctionCallContent Llamada,
    string ClaveDeArgumentos, DateTimeOffset Vence);

/// <summary>
/// Aprobaciones pendientes, sólo en el servidor (A1). El id que ve el cliente es un aleatorio de 128 bits,
/// no el <c>RequestId</c> de MAF (que es «ficc_» + el CallId del proveedor y no es secreto) (A2). Cada id
/// está atado a <c>SessionId + ConversacionId</c>, se usa una sola vez y vence (A3).
/// </summary>
public sealed class AlmacenDeAprobaciones(TimeProvider reloj)
{
    private readonly ConcurrentDictionary<string, AprobacionGuardada> _pendientes = new();

    public string Registrar(string sessionId, string conversacionId, string requestId, FunctionCallContent llamada, TimeSpan vigencia)
    {
        var argumentos = new Dictionary<string, object?>(llamada.Arguments ?? new Dictionary<string, object?>());
        var copia = new FunctionCallContent(llamada.CallId, llamada.Name, argumentos);
        var id = Convert.ToBase64String(RandomNumberGenerator.GetBytes(16)).TrimEnd('=').Replace('+', '-').Replace('/', '_');
        _pendientes[id] = new AprobacionGuardada(sessionId, conversacionId, requestId, copia,
            AutorizacionDeEscritura.Clave(argumentos), reloj.GetUtcNow() + vigencia);
        return id;
    }

    /// <summary>
    /// Devuelve la aprobación y la consume, sólo si el id existe, es de esta sesión y conversación y no venció.
    /// Un intento desde otra conversación no la consume: sigue siendo de su dueña.
    /// </summary>
    public AprobacionGuardada? Tomar(string id, string sessionId, string conversacionId)
    {
        if (!_pendientes.TryGetValue(id, out var a)) return null;
        if (a.SessionId != sessionId || a.ConversacionId != conversacionId) return null;
        if (!_pendientes.TryRemove(new KeyValuePair<string, AprobacionGuardada>(id, a))) return null; // ya la usó otro pedido
        return a.Vence > reloj.GetUtcNow() ? a : null;
    }

    public bool HayPendiente(string sessionId, string conversacionId) =>
        _pendientes.Values.Any(a => a.SessionId == sessionId && a.ConversacionId == conversacionId && a.Vence > reloj.GetUtcNow());

    /// <summary>Sólo para las pruebas: lo que una persona de afuera NO ve.</summary>
    internal IReadOnlyCollection<AprobacionGuardada> ParaPruebas => _pendientes.Values.ToList();
}
