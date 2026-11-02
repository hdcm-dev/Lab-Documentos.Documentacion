using System.ComponentModel;
using Microsoft.Extensions.AI;
using MovilidadUrbana.Ejemplos.AnotacionesPareadas.Application.Resultados;

namespace MovilidadUrbana.Ejemplos.AnotacionesPareadas.Infrastructure.AI.AgentFramework;

/// <summary>Después: la misma herramienta como método con <c>[Description]</c>, para <c>AIFunctionFactory</c>.</summary>
public sealed class HerramientasDeResultados(ConsultaDeResultadosPorMedio consulta)
{
    public const string ResultadosPorMedio = "resultados_por_medio";

    [Description("Cuenta las respuestas de la encuesta de transporte por medio. No devuelve datos de quienes respondieron.")]
    public Task<ResultadosPorMedio> ResultadosPorMedioAsync(
        [Description("Localidad de la encuesta. Opcional: sin localidad, cuenta todas las respuestas.")] string? localidad = null,
        CancellationToken cancellationToken = default)
        => consulta.ContarAsync(localidad, cancellationToken);

    /// <summary>El nombre se pasa explícito: sin él, la función se llamaría como el método.</summary>
    public AIFunction ComoAIFunction() =>
        AIFunctionFactory.Create(ResultadosPorMedioAsync, name: ResultadosPorMedio);
}
