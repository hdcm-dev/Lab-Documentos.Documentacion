using Microsoft.Agents.AI.Workflows;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.Orquestacion.Tests.Cableado;

/// <summary>
/// Trampa de los executors con [MessageHandler]: lo que un handler manda o produce por el contexto
/// (SendMessageAsync, YieldOutputAsync) se declara en el atributo. Si no, compila y falla al ejecutar.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class TrampasDeExecutorsTests
{
    private static async Task<(string? Salida, Exception? Error)> Correr(ExecutorBinding executor)
    {
        var workflow = new WorkflowBuilder(executor).WithOutputFrom(executor).Build();
        string? salida = null;
        Exception? error = null;
        await using var run = await InProcessExecution.RunStreamingAsync(workflow, "Goya");
        await foreach (var evento in run.WatchStreamAsync())
        {
            if (evento is WorkflowOutputEvent o && o.Is(out string? s)) salida = s;
            if (evento is ExecutorFailedEvent f) error = f.Data;
            if (evento is WorkflowErrorEvent w) error ??= w.Exception;
        }
        return (salida, error);
    }

    [Test]
    public async Task SinDeclararYield_CompilaYFallaAlEjecutar()
    {
        var (salida, error) = await Correr(new SinDeclarar());
        TestContext.Out.WriteLine($"sin declarar: salida={salida ?? "(ninguna)"}; error={error?.GetType().Name}: {error?.Message}");
        Assert.That(salida, Is.Null);
        Assert.That(error, Is.InstanceOf<InvalidOperationException>());
    }

    [Test]
    public async Task ConYieldDeclarado_Funciona()
    {
        var (salida, error) = await Correr(new Declarado());
        TestContext.Out.WriteLine($"declarado: salida={salida}; error={error?.Message ?? "(ninguno)"}");
        Assert.That(error, Is.Null);
        Assert.That(salida, Is.EqualTo("localidad: Goya"));
    }
}

internal sealed partial class SinDeclarar() : Executor("sin-declarar")
{
    [MessageHandler]
    private async ValueTask HandleAsync(string nombre, IWorkflowContext contexto) =>
        await contexto.YieldOutputAsync($"localidad: {nombre}");
}

internal sealed partial class Declarado() : Executor("declarado")
{
    [MessageHandler(Yield = [typeof(string)])]
    private async ValueTask HandleAsync(string nombre, IWorkflowContext contexto) =>
        await contexto.YieldOutputAsync($"localidad: {nombre}");
}
