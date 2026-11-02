using Microsoft.Agents.AI.Workflows;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.Ejemplos.Orquestacion.Application.Altas;

namespace MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.Workflows;

/// <summary>Paso 1, con modelo: el texto de la persona → una propuesta tipada (o null). No elige el paso siguiente.</summary>
internal sealed partial class ExtraerPropuestaExecutor(IExtractorDeAlta extractor) : Executor(WorkflowDeAlta.Extraer)
{
    [MessageHandler]
    private async ValueTask<PropuestaExtraida> HandleAsync(string texto, IWorkflowContext context, CancellationToken cancellationToken) =>
        new(texto, await extractor.ExtraerAsync(texto, cancellationToken));
}

/// <summary>Lo que pasó en una corrida del workflow de alta.</summary>
/// <param name="Executors">Cada <c>ExecutorInvokedEvent</c>, en orden (el puerto aparece al pedir y al recibir la respuesta).</param>
public sealed record TrazaDelAlta(
    ResultadoDelAlta? Resultado,
    IReadOnlyList<string> Executors,
    int PedidosDeConfirmacion,
    RunStatus Estado,
    CheckpointInfo? UltimoCheckpoint)
{
    /// <summary>Los pasos por los que pasó la corrida, sin repetir invocaciones seguidas del mismo executor.</summary>
    public IReadOnlyList<string> Pasos => Executors.Where((e, i) => i == 0 || Executors[i - 1] != e).ToList();
}

/// <summary>
/// WORKFLOW, en el sentido de la guía: hay un paso con modelo y el código fija el orden de todos los pasos.
/// extraer (modelo) → revisar (código, RevisorDeAlta) → confirmar-alta (la persona, por RequestPort) → registrar
/// (caso de uso copiado). Si la revisión falla, la salida es «rechazada» y la persona ni siquiera ve la propuesta.
/// Ninguna escritura sin la confirmación: el único executor que escribe está detrás del puerto.
/// </summary>
public static class WorkflowDeAlta
{
    public const string Extraer = "extraer";
    public const string Revisar = "revisar";
    public const string Rechazo = "rechazo";
    public const string ConfirmarAlta = "confirmar-alta";
    public const string Registrar = "registrar";

    // Estado compartido del workflow: lo escribe «revisar», lo lee «registrar», y queda en el checkpoint.
    private const string Alcance = "alta";
    private const string ClaveDeLaRevision = "revision";

    public static Workflow Construir(IExtractorDeAlta extractor, LocalidadService localidades)
    {
        var extraer = new ExtraerPropuestaExecutor(extractor);

        Func<PropuestaExtraida, IWorkflowContext, CancellationToken, ValueTask<RevisionDeAlta>> revisar = async (p, contexto, ct) =>
        {
            var revision = RevisorDeAlta.Revisar(p.Propuesta);
            if (revision.Aceptada) await contexto.QueueStateUpdateAsync(ClaveDeLaRevision, revision, Alcance, ct);
            return revision;
        };
        ExecutorBinding revision = revisar.BindAsExecutor(Revisar);

        Func<RevisionDeAlta, ResultadoDelAlta> rechazar = r =>
            new(EstadoDelAlta.Rechazada, "La propuesta no pasó la revisión; no se guardó nada.", r.Errores);
        ExecutorBinding rechazo = rechazar.BindAsExecutor(Rechazo);

        // Persona en el bucle: el workflow emite RequestInfoEvent y espera la respuesta tipada.
        RequestPort<RevisionDeAlta, ConfirmacionDeAlta> confirmar = RequestPort.Create<RevisionDeAlta, ConfirmacionDeAlta>(ConfirmarAlta);

        Func<ConfirmacionDeAlta, IWorkflowContext, CancellationToken, ValueTask<ResultadoDelAlta>> registrar = async (c, contexto, ct) =>
        {
            if (!c.Confirmada)
                return new(EstadoDelAlta.Descartada, "La persona no confirmó; no se guardó nada.", Sin);

            var r = await contexto.ReadStateAsync<RevisionDeAlta>(ClaveDeLaRevision, Alcance, ct)
                ?? throw new InvalidOperationException("No hay una revisión aceptada en el estado del workflow.");
            var p = r.Propuesta!;
            var resultado = await localidades.SaveAsync(new LocalidadModel
            {
                Nombre = p.Nombre!, Provincia = p.Provincia!, CodigoPostal = p.CodigoPostal!, Habitantes = p.Habitantes,
            }, ct);   // el caso de uso copiado vuelve a validar y decide (por ejemplo, duplicadas)

            return resultado.IsSuccess
                ? new(EstadoDelAlta.Registrada, resultado.Message, Sin)
                : new(EstadoDelAlta.Rechazada, resultado.Message, resultado.Errors);
        };
        ExecutorBinding registro = registrar.BindAsExecutor(Registrar);

        return new WorkflowBuilder(extraer)
            .AddEdge(extraer, revision)
            .AddEdge<RevisionDeAlta>(revision, rechazo, r => r is { Aceptada: false })
            .AddEdge<RevisionDeAlta>(revision, confirmar, r => r is { Aceptada: true })
            .AddEdge(confirmar, registro)
            .WithOutputFrom(rechazo, registro)
            .Build();
    }

    private static readonly IReadOnlyDictionary<string, string> Sin = new Dictionary<string, string>();

    /// <param name="persona">Responde al pedido de confirmación; null = no responde (la corrida queda pendiente).</param>
    public static async Task<TrazaDelAlta> EjecutarAsync(
        Workflow workflow, string texto, Func<RevisionDeAlta, ConfirmacionDeAlta?> persona,
        CheckpointManager? checkpoints = null, CancellationToken cancellationToken = default)
    {
        await using StreamingRun run = checkpoints is null
            ? await InProcessExecution.RunStreamingAsync(workflow, texto, cancellationToken: cancellationToken)
            : await InProcessExecution.RunStreamingAsync(workflow, texto, checkpoints, cancellationToken: cancellationToken);
        return await ObservarAsync(run, persona, cancellationToken);
    }

    /// <summary>Retoma una corrida desde un checkpoint, en otra instancia del run.</summary>
    public static async Task<TrazaDelAlta> ReanudarAsync(
        Workflow workflow, CheckpointInfo checkpoint, CheckpointManager checkpoints,
        Func<RevisionDeAlta, ConfirmacionDeAlta?> persona, CancellationToken cancellationToken = default)
    {
        await using StreamingRun run = await InProcessExecution.ResumeStreamingAsync(workflow, checkpoint, checkpoints, cancellationToken);
        return await ObservarAsync(run, persona, cancellationToken);
    }

    private static async Task<TrazaDelAlta> ObservarAsync(
        StreamingRun run, Func<RevisionDeAlta, ConfirmacionDeAlta?> persona, CancellationToken cancellationToken)
    {
        var executors = new List<string>();
        int pedidos = 0;
        ResultadoDelAlta? resultado = null;
        CheckpointInfo? ultimo = null;

        // blockOnPendingRequest: false → con un pedido sin responder, el stream termina al cerrar el superstep
        // (con su checkpoint) y la corrida queda en PendingRequests, en vez de esperar para siempre. Ojo: también
        // puede terminar antes de procesar una respuesta recién enviada; por eso, si se respondió, se vuelve a observar.
        bool respondida;
        do
        {
            respondida = false;
            await foreach (WorkflowEvent evento in run.WatchStreamAsync(blockOnPendingRequest: false, cancellationToken))
            {
                switch (evento)
                {
                    case ExecutorInvokedEvent invocado:
                        executors.Add(invocado.ExecutorId);
                        break;
                    case SuperStepCompletedEvent paso when paso.CompletionInfo?.Checkpoint is { } cp:
                        ultimo = cp;
                        break;
                    case RequestInfoEvent pedido when pedido.Request.TryGetDataAs(out RevisionDeAlta? revision):
                        pedidos++;
                        // Sin respuesta no se escribe nada: el único executor que escribe está detrás del puerto.
                        if (persona(revision!) is { } respuesta)
                        {
                            await run.SendResponseAsync(pedido.Request.CreateResponse(respuesta));
                            respondida = true;
                        }
                        break;
                    case WorkflowOutputEvent salida when salida.Is(out ResultadoDelAlta? r):
                        resultado = r;
                        break;
                    case WorkflowErrorEvent error:
                        throw new InvalidOperationException("El workflow falló.", error.Exception);
                    case ExecutorFailedEvent fallo:
                        throw new InvalidOperationException($"Falló el executor {fallo.ExecutorId}.", fallo.Data);
                }
            }
        } while (respondida && resultado is null);

        return new(resultado, executors, pedidos, await run.GetStatusAsync(cancellationToken), ultimo);
    }
}
