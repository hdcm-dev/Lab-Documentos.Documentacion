using System.Collections.Concurrent;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Asistente.Application.Abstractions;
using MovilidadUrbana.Asistente.Application.Asistente;

namespace MovilidadUrbana.Asistente.Infrastructure.AI;

/// <summary>
/// Historial de conversaciones en memoria del servidor (D-11): clave SessionId + ConversacionId, vencimiento
/// por inactividad (30 min por defecto) y sólo los últimos turnos. Es dato de la persona: no se registra en
/// logs ni en telemetría. El estado no viaja al cliente, así que el cliente no lo puede alterar.
/// </summary>
public sealed class HistorialEnMemoria(IOptions<OpcionesDeIA> opciones, TimeProvider reloj) : IHistorialDeConversacion
{
    private sealed record Entrada(List<TurnoDeConversacion> Turnos, DateTimeOffset UltimoUso);

    private readonly ConcurrentDictionary<(string Sesion, string Conversacion), Entrada> _entradas = new();

    private TimeSpan Vencimiento => TimeSpan.FromMinutes(opciones.Value.Conversacion.VencimientoMinutos);

    public IReadOnlyList<TurnoDeConversacion> Leer(string sessionId, string conversacionId)
    {
        Purgar();
        if (!_entradas.TryGetValue((sessionId, conversacionId), out var e)) return [];
        lock (e.Turnos) return e.Turnos.ToList();
    }

    public void Agregar(string sessionId, string conversacionId, params TurnoDeConversacion[] turnos)
    {
        Purgar();
        var maximo = opciones.Value.Conversacion.TurnosDeHistorial;
        var ahora = reloj.GetUtcNow();
        var e = _entradas.AddOrUpdate((sessionId, conversacionId),
            _ => new Entrada([], ahora),
            (_, previa) => previa with { UltimoUso = ahora });
        lock (e.Turnos)
        {
            e.Turnos.AddRange(turnos);
            if (e.Turnos.Count > maximo) e.Turnos.RemoveRange(0, e.Turnos.Count - maximo);
        }
    }

    private void Purgar()
    {
        var limite = reloj.GetUtcNow() - Vencimiento;
        foreach (var (clave, e) in _entradas)
            if (e.UltimoUso < limite) _entradas.TryRemove(clave, out _);
    }
}
