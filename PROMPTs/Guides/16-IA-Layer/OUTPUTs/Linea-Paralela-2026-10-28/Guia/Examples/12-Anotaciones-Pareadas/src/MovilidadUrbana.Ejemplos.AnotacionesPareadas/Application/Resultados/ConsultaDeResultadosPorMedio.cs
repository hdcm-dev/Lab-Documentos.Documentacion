using MovilidadUrbana.ApiWeb.Domain;

namespace MovilidadUrbana.Ejemplos.AnotacionesPareadas.Application.Resultados;

/// <summary>
/// Caso de uso de lectura: cuenta las respuestas de la encuesta por medio, en el orden del catálogo,
/// opcionalmente para una localidad. Es el mismo para las dos anotaciones: lo que cambia entre
/// Semantic Kernel y Agent Framework es el adaptador, no esta clase.
/// </summary>
public sealed class ConsultaDeResultadosPorMedio(ILecturaDeRespuestas lectura)
{
    public const int LargoMaximoDeLocalidad = 60;

    public async Task<ResultadosPorMedio> ContarAsync(string? localidad, CancellationToken cancellationToken = default)
    {
        var filtro = string.IsNullOrWhiteSpace(localidad) ? null : localidad.Trim();
        if (filtro is { Length: > LargoMaximoDeLocalidad })
            return new ResultadosPorMedio(null, 0, [], $"La localidad no puede superar {LargoMaximoDeLocalidad} caracteres.");

        var respuestas = await lectura.ListarAsync(cancellationToken);
        var elegidas = filtro is null
            ? respuestas
            : [.. respuestas.Where(r => string.Equals(r.Localidad, filtro, StringComparison.OrdinalIgnoreCase))];

        if (filtro is not null && elegidas.Count == 0)
            return new ResultadosPorMedio(filtro, 0, [], $"No hay respuestas registradas para «{filtro}».");

        var porMedio = Catalogos.Medios
            .Select(m => new ConteoPorMedio(m.Clave, m.Etiqueta, elegidas.Count(r => r.Medios.Contains(m.Clave))))
            .ToList();
        return new ResultadosPorMedio(filtro, elegidas.Count, porMedio, null);
    }
}
