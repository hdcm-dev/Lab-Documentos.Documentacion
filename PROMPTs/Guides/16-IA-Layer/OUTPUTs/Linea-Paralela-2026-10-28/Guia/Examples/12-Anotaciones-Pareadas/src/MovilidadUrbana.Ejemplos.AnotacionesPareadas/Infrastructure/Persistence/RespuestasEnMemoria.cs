using System.Collections.Concurrent;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Domain.Entities;
using MovilidadUrbana.Ejemplos.AnotacionesPareadas.Application.Resultados;

namespace MovilidadUrbana.Ejemplos.AnotacionesPareadas.Infrastructure.Persistence;

/// <summary>
/// Respuestas en memoria, separadas por sesión como en el repositorio del caso base. Cada sesión nueva
/// arranca con cuatro respuestas ficticias. <see cref="Lecturas"/> cuenta las lecturas para las pruebas.
/// </summary>
public sealed class RespuestasEnMemoria(ISessionContext sesion) : ILecturaDeRespuestas
{
    private readonly ConcurrentDictionary<string, List<RespuestaDeEncuesta>> _porSesion = new();

    public int Lecturas { get; private set; }

    public Task<IReadOnlyList<RespuestaDeEncuesta>> ListarAsync(CancellationToken cancellationToken = default)
    {
        Lecturas++;
        var lista = _porSesion.GetOrAdd(sesion.Id, Sembrar);
        return Task.FromResult<IReadOnlyList<RespuestaDeEncuesta>>([.. lista]);
    }

    private static List<RespuestaDeEncuesta> Sembrar(string sessionId) =>
    [
        Respuesta(sessionId, 1, "Corrientes", ["colectivo", "caminata"], "trabajo"),
        Respuesta(sessionId, 2, "Corrientes", ["colectivo"], "estudio"),
        Respuesta(sessionId, 3, "Resistencia", ["colectivo", "bicicleta"], "trabajo"),
        Respuesta(sessionId, 4, "Resistencia", ["auto"], "salud")
    ];

    private static RespuestaDeEncuesta Respuesta(string sessionId, int id, string localidad, IReadOnlyList<string> medios, string motivo) => new()
    {
        Id = id,
        SessionId = sessionId,
        Nombre = $"Persona de ejemplo {id}",
        Edad = 30 + id,
        Localidad = localidad,
        Medios = medios,
        Frecuencia = "diaria",
        Distancia = 5,
        Minutos = 20,
        Motivo = motivo,
        RegistradaEn = DateTimeOffset.UnixEpoch
    };
}
