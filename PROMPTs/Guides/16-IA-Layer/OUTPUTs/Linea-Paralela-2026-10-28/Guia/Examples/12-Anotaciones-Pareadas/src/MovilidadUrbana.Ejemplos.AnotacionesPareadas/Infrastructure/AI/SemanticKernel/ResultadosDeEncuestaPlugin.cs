using System.ComponentModel;
using Microsoft.SemanticKernel;
using MovilidadUrbana.Ejemplos.AnotacionesPareadas.Application.Resultados;

namespace MovilidadUrbana.Ejemplos.AnotacionesPareadas.Infrastructure.AI.SemanticKernel;

/// <summary>Antes: la herramienta como función de un plugin de Semantic Kernel.</summary>
public sealed class ResultadosDeEncuestaPlugin(ConsultaDeResultadosPorMedio consulta)
{
    [KernelFunction("resultados_por_medio")]
    [Description("Cuenta las respuestas de la encuesta de transporte por medio. No devuelve datos de quienes respondieron.")]
    public Task<ResultadosPorMedio> ResultadosPorMedioAsync(
        [Description("Localidad de la encuesta. Opcional: sin localidad, cuenta todas las respuestas.")] string? localidad = null,
        CancellationToken cancellationToken = default)
        => consulta.ContarAsync(localidad, cancellationToken);
}
