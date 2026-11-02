using MovilidadUrbana.ApiWeb.Domain.Entities;

namespace MovilidadUrbana.Ejemplos.AnotacionesPareadas.Application.Resultados;

/// <summary>Puerto de lectura: las respuestas de la sesión actual. No hay operación de escritura.</summary>
public interface ILecturaDeRespuestas
{
    Task<IReadOnlyList<RespuestaDeEncuesta>> ListarAsync(CancellationToken cancellationToken = default);
}
