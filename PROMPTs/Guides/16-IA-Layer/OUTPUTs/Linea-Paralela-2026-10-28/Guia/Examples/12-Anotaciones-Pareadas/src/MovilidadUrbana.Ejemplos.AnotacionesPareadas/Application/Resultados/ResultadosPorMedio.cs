namespace MovilidadUrbana.Ejemplos.AnotacionesPareadas.Application.Resultados;

/// <summary>Cuántas respuestas eligieron un medio. Una respuesta puede elegir varios medios.</summary>
public sealed record ConteoPorMedio(string Medio, string Etiqueta, int Respuestas);

/// <summary>
/// Agregado de la encuesta por medio de transporte, sin datos de quienes respondieron
/// (ni nombre ni edad). <see cref="Error"/> trae el motivo cuando el pedido no se pudo responder.
/// </summary>
public sealed record ResultadosPorMedio(
    string? Localidad,
    int TotalDeRespuestas,
    IReadOnlyList<ConteoPorMedio> PorMedio,
    string? Error);
