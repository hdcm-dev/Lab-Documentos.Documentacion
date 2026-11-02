using System.Collections.Concurrent;
using System.Text.Json;

namespace MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI.Aprobaciones;

/// <summary>
/// Estado de cada conversación (la sesión serializada del agente), con clave <c>SessionId + ConversacionId</c>
/// y vencimiento. Guarda el historial con el texto de la persona y los argumentos pendientes: es dato de la
/// persona y es frontera de confianza (MAF ejecuta lo que diga la sesión deserializada). Por eso vive sólo
/// en el servidor, vence y no se escribe en registros. En memoria acá; en producción, un almacén del servidor.
/// </summary>
public sealed class AlmacenDeConversaciones(TimeProvider reloj)
{
    private readonly ConcurrentDictionary<(string, string), (string Json, DateTimeOffset Vence)> _estados = new();

    public void Guardar(string sessionId, string conversacionId, JsonElement estado, TimeSpan vigencia) =>
        _estados[(sessionId, conversacionId)] = (estado.GetRawText(), reloj.GetUtcNow() + vigencia);

    public JsonElement? Leer(string sessionId, string conversacionId)
    {
        if (!_estados.TryGetValue((sessionId, conversacionId), out var e)) return null;
        if (e.Vence <= reloj.GetUtcNow())
        {
            _estados.TryRemove((sessionId, conversacionId), out _);
            return null;
        }
        return JsonDocument.Parse(e.Json).RootElement.Clone();
    }

    /// <summary>Sólo para las pruebas: simula que alguien alteró el almacén.</summary>
    internal int AlterarParaPruebas(string sessionId, string conversacionId, string buscar, string reemplazo)
    {
        var e = _estados[(sessionId, conversacionId)];
        int veces = e.Json.Split(buscar).Length - 1;
        _estados[(sessionId, conversacionId)] = (e.Json.Replace(buscar, reemplazo), e.Vence);
        return veces;
    }
}
