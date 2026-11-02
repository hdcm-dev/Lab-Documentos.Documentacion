// Puertos de aplicación: hablan el idioma del caso de uso. Ningún tipo de Microsoft.Extensions.AI acá.
namespace MovilidadUrbana.Asistente.Application.Abstractions;

public sealed record RespuestaConFuentes(string Texto, IReadOnlyList<string> Fuentes);

/// <summary>Ayuda sobre los requisitos de carga (vía A: RAG como paso fijo, sin agente).</summary>
public interface IAyuda
{
    Task<RespuestaConFuentes> ResponderAsync(string pregunta, CancellationToken ct = default);
}

/// <summary>Asistente que decide qué consultar (vía B: recuperación como herramienta).</summary>
public interface IAsistenteDeMovilidad
{
    Task<string> ResponderAsync(string pedido, CancellationToken ct = default);
}
