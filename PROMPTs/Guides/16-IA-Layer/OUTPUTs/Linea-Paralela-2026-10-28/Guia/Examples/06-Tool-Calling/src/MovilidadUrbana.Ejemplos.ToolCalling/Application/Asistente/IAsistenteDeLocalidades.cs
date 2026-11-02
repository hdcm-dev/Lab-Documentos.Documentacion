namespace MovilidadUrbana.Ejemplos.ToolCalling.Application.Asistente;

/// <summary>Una herramienta que el modelo pidió y la aplicación ejecutó, con su resultado tal como volvió al modelo.</summary>
public sealed record LlamadaAHerramienta(string Nombre, string Argumentos, string Resultado);

/// <summary>Respuesta del asistente, sin tipos del proveedor ni de Microsoft.Extensions.AI.</summary>
public sealed record RespuestaDelAsistente(string Texto, IReadOnlyList<LlamadaAHerramienta> Herramientas);

/// <summary>
/// Puerto del asistente. Lo implementa un adaptador de Infrastructure/AI; quien lo usa no sabe qué
/// proveedor hay detrás.
/// </summary>
public interface IAsistenteDeLocalidades
{
    Task<RespuestaDelAsistente> PreguntarAsync(string texto, CancellationToken ct = default);
}
