using Microsoft.Agents.AI.Workflows;
using MovilidadUrbana.ApiWeb.Application.Encuestas;
using MovilidadUrbana.Ejemplos.Orquestacion.Application.Encuesta;

namespace MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.Workflows;

/// <summary>El mensaje que viaja entre los pasos del grafo.</summary>
public sealed record EstadoDeLaEncuesta(EncuestaModel Encuesta, int Paso, IReadOnlyDictionary<string, string> Errores);

/// <summary>
/// Un paso de la encuesta como executor de MAF. La forma recomendada en C# es una clase <c>partial</c>
/// con métodos <c>[MessageHandler]</c>: el generador del paquete <c>Microsoft.Agents.AI.Workflows.Generators</c>
/// escribe <c>ConfigureProtocol</c>. Sin ese paquete, la clase no compila (CS0534).
/// </summary>
internal sealed partial class ValidarPasoExecutor(int paso, EncuestaService servicio) : Executor($"paso-{paso}")
{
    [MessageHandler]
    private ValueTask<EstadoDeLaEncuesta> HandleAsync(EstadoDeLaEncuesta estado, IWorkflowContext context) =>
        ValueTask.FromResult(estado with { Paso = paso, Errores = servicio.ValidarPaso(paso, estado.Encuesta) });
}

/// <summary>
/// CONTRAEJEMPLO. La misma encuesta de <see cref="EncuestaComoProceso"/>, escrita como workflow de MAF:
/// tres executors, aristas condicionales, una salida de rechazo y una de registro. Da el mismo resultado
/// que la función, con más piezas. Ningún paso usa un modelo: según la definición de la guía, esto no es un
/// workflow, es código. «If you can write a function to handle the task, do that instead».
/// </summary>
public static class EncuestaComoWorkflowDeMaf
{
    public static Workflow Construir(EncuestaService servicio)
    {
        var paso1 = new ValidarPasoExecutor(1, servicio);
        var paso2 = new ValidarPasoExecutor(2, servicio);
        var paso3 = new ValidarPasoExecutor(3, servicio);

        // Executors desde funciones: el método es BindAsExecutor. La página de executors muestra
        // BindExecutor, que en 1.26.0 no compila con una función (CS0411).
        Func<EstadoDeLaEncuesta, ResultadoDeLaEncuesta> rechazar = e => new(false, e.Paso, e.Errores);
        ExecutorBinding rechazo = rechazar.BindAsExecutor("rechazo");

        Func<EstadoDeLaEncuesta, CancellationToken, ValueTask<ResultadoDeLaEncuesta>> registrar = async (e, ct) =>
        {
            await servicio.RegistrarAsync(e.Encuesta, ct);
            return new(true, null, ResultadoDeLaEncuesta.SinErrores);
        };
        ExecutorBinding registro = registrar.BindAsExecutor("registro");

        static bool SinErrores(EstadoDeLaEncuesta? e) => e is { Errores.Count: 0 };
        static bool ConErrores(EstadoDeLaEncuesta? e) => e is { Errores.Count: > 0 };

        return new WorkflowBuilder(paso1)
            .AddEdge<EstadoDeLaEncuesta>(paso1, paso2, SinErrores)
            .AddEdge<EstadoDeLaEncuesta>(paso1, rechazo, ConErrores)
            .AddEdge<EstadoDeLaEncuesta>(paso2, paso3, SinErrores)
            .AddEdge<EstadoDeLaEncuesta>(paso2, rechazo, ConErrores)
            .AddEdge<EstadoDeLaEncuesta>(paso3, registro, SinErrores)
            .AddEdge<EstadoDeLaEncuesta>(paso3, rechazo, ConErrores)
            .WithOutputFrom(rechazo, registro)
            .Build();
    }

    /// <summary>Corre el grafo y devuelve el resultado, los executors invocados en orden y los supersteps.</summary>
    public static async Task<(ResultadoDeLaEncuesta Resultado, IReadOnlyList<string> Executors, int Supersteps)> CompletarAsync(
        EncuestaService servicio, EncuestaModel encuesta, CancellationToken cancellationToken = default)
    {
        Workflow workflow = Construir(servicio);
        var executors = new List<string>();
        int supersteps = 0;
        ResultadoDeLaEncuesta? resultado = null;

        await using StreamingRun run = await InProcessExecution.RunStreamingAsync(
            workflow, new EstadoDeLaEncuesta(encuesta, 0, ResultadoDeLaEncuesta.SinErrores), cancellationToken: cancellationToken);
        await foreach (WorkflowEvent evento in run.WatchStreamAsync(cancellationToken))
        {
            switch (evento)
            {
                case ExecutorInvokedEvent invocado: executors.Add(invocado.ExecutorId); break;
                case SuperStepCompletedEvent: supersteps++; break;
                case WorkflowOutputEvent salida when salida.Is(out ResultadoDeLaEncuesta? r): resultado = r; break;
                case WorkflowErrorEvent error: throw new InvalidOperationException("El workflow falló.", error.Exception);
            }
        }

        return (resultado ?? throw new InvalidOperationException("El workflow terminó sin salida."), executors, supersteps);
    }
}
