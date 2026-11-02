namespace MovilidadUrbana.Ejemplos.AgenteConAprobacion.Application.Asistente;

/// <summary>
/// Puerto del asistente. Habla el idioma del caso de uso: no expone tipos de MEAI ni de MAF, y ninguna
/// operación recibe estado de la conversación desde afuera (la sesión del agente vive sólo en el servidor).
/// </summary>
public interface IAsistenteConAprobacion
{
    Task<RespuestaDelAsistente> ConversarAsync(string sessionId, string conversacionId, string texto, CancellationToken ct = default);

    /// <param name="idDeAprobacion">El id que devolvió <see cref="AprobacionPendiente.Id"/>; no el de la llamada del modelo.</param>
    Task<RespuestaDelAsistente> ResolverAsync(string sessionId, string conversacionId, string idDeAprobacion, bool aprobado, CancellationToken ct = default);
}

/// <param name="Pendiente">Si no es null, hay una escritura esperando la decisión de la persona.</param>
public sealed record RespuestaDelAsistente(string Texto, AprobacionPendiente? Pendiente);

/// <summary>Lo que la persona ve para decidir.</summary>
/// <param name="Id">Aleatorio del servidor, atado a sesión y conversación, de un solo uso.</param>
/// <param name="Descripcion">La entidad que resolvió el servidor, no el texto del modelo.</param>
public sealed record AprobacionPendiente(string Id, string Herramienta, string Descripcion, DateTimeOffset Vence);
