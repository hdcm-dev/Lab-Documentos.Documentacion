using MovilidadUrbana.Asistente.Application.Asistente;
using MovilidadUrbana.Asistente.Application.Encuestas;
using MovilidadUrbana.Asistente.Application.Localidades;

namespace MovilidadUrbana.Asistente.Application.Abstractions;

// Puertos de la capa de IA. Viven en el núcleo y no exponen tipos de Microsoft.Extensions.AI: los
// adaptadores de Infrastructure/AI los implementan con IChatClient, prompts y opciones del modelo.

/// <summary>El asistente de la página de chat y de POST /api/v1/asistente.</summary>
public interface IAsistenteDeMovilidad
{
    IAsyncEnumerable<EventoDelAsistente> ConversarAsync(
        string sessionId, string conversacionId, string texto, CancellationToken cancellationToken);
}

/// <summary>Decide qué quiere la persona. Si el modelo no devuelve algo válido, <see cref="IntencionDelPedido.FueraDeAlcance"/>.</summary>
public interface IClasificadorDePedido
{
    Task<IntencionDelPedido> ClasificarAsync(string texto, CancellationToken cancellationToken);
}

/// <summary>ESC-03: datos de una localidad desde texto libre. Null si la salida estructurada no se pudo leer.</summary>
public interface IExtractorDeLocalidad
{
    Task<LocalidadPropuesta?> ExtraerAsync(string texto, CancellationToken cancellationToken);
}

/// <summary>ESC-03: medios y frecuencia (paso 2 de la encuesta) desde texto libre.</summary>
public interface IExtractorDeEncuesta
{
    Task<EncuestaPaso2Propuesta?> ExtraerPaso2Async(string texto, CancellationToken cancellationToken);
}

/// <summary>ESC-04: qué localidad de la sesión quiere dar de baja la persona.</summary>
public interface IExtractorDeBaja
{
    Task<AccionSugerida?> ExtraerAsync(
        string texto, IReadOnlyList<LocalidadDeReferencia> disponibles, CancellationToken cancellationToken);
}

/// <summary>ESC-01: preguntas sobre los requisitos del dominio. En la demo, sólo contexto fijo.</summary>
public interface IAyuda
{
    IAsyncEnumerable<string> ResponderAsync(
        IReadOnlyList<TurnoDeConversacion> previos, string pregunta, CancellationToken cancellationToken);
}

/// <summary>ESC-01: preguntas sobre los datos de la sesión, con herramientas de sólo lectura.</summary>
public interface IConsultaConHerramientas
{
    IAsyncEnumerable<string> ResponderAsync(
        IReadOnlyList<TurnoDeConversacion> previos, string texto, CancellationToken cancellationToken);
}

/// <summary>
/// Estado de la conversación (D-11): clave SessionId + ConversacionId y vencimiento. Guarda texto de la
/// persona, así que no va a registros ni a telemetría.
/// </summary>
public interface IHistorialDeConversacion
{
    IReadOnlyList<TurnoDeConversacion> Leer(string sessionId, string conversacionId);

    void Agregar(string sessionId, string conversacionId, params TurnoDeConversacion[] turnos);
}

/// <summary>Lectura de conteos de la encuesta de la sesión, sin campos de la persona.</summary>
public interface ILecturaDeResultados
{
    Task<ConteosDeEncuesta> LeerAsync(CancellationToken cancellationToken);
}
