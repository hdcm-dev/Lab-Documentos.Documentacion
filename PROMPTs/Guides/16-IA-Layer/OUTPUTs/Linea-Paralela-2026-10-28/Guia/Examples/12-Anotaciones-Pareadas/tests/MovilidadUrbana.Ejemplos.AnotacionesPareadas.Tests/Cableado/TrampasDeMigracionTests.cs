using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.AnotacionesPareadas.Tests.Cableado;

/// <summary>Lo que cambia sin aviso al migrar si se deja la anotación vieja o no se fija el nombre.</summary>
[TestFixture, Category("Cableado")]
public sealed class TrampasDeMigracionTests
{
    [Test]
    public void AIFunctionFactory_NoLeeElNombreDeKernelFunction()
    {
        var a = new Armado();
        // El método todavía tiene [KernelFunction("resultados_por_medio")], pero AIFunctionFactory no lo mira.
        AIFunction f = AIFunctionFactory.Create(a.Plugin.ResultadosPorMedioAsync);

        TestContext.Out.WriteLine($"Name sin name: «{f.Name}»; Description «{f.Description}»");
        Assert.That(f.Name, Is.EqualTo("ResultadosPorMedio"), "el nombre sale del método, sin el sufijo Async");
        Assert.That(f.Description, Is.EqualTo(a.FuncionMaf.Description), "[Description] sí se lee");
    }

    /// <summary>
    /// Atajo que no sirve con estas versiones: la KernelFunction del plugin viejo, entregada tal cual a un agente
    /// de MAF. Compila y se ofrece al modelo (con el prefijo del plugin), pero al ejecutarla falla: 0 lecturas, y
    /// el modelo recibe «Error: Function failed.» sin que la aplicación vea una excepción.
    /// </summary>
    [Test]
    public async Task LaKernelFunction_EntregadaTalCualAUnAgenteDeMaf_FallaAlEjecutar()
    {
        var a = new Armado();
        AIAgent agente = a.Chat.AsAIAgent(instructions: "x", tools: [a.FuncionSk]);
        AgentResponse r = await agente.RunAsync("¿Qué medios usa la gente de Corrientes?", await agente.CreateSessionAsync());

        TestContext.Out.WriteLine($"ofrecida «{a.Chat.HerramientasOfrecidas[0].Single().Nombre}»; lecturas {a.Almacen.Lecturas}; texto «{r.Text}»");
        Assert.That(a.Chat.HerramientasOfrecidas[0].Select(h => h.Nombre), Is.EqualTo(new[] { "Encuesta_resultados_por_medio" }));
        Assert.That(a.Almacen.Lecturas, Is.EqualTo(0));
        Assert.That(r.Text, Does.Contain("Error: Function failed."));
    }

    /// <summary>El mismo caso con <c>IncludeDetailedErrors</c>, para ver el motivo que el modo por defecto oculta.</summary>
    [Test]
    public async Task LaKernelFunction_EnMaf_ConErroresDetallados_MuestraElMotivo()
    {
        var a = new Armado();
        AIAgent agente = a.Chat.AsBuilder()
            .UseFunctionInvocation(configure: f => f.IncludeDetailedErrors = true)
            .Build()
            .AsAIAgent(instructions: "x", tools: [a.FuncionSk]);
        AgentResponse r = await agente.RunAsync("¿Qué medios usa la gente de Corrientes?", await agente.CreateSessionAsync());

        TestContext.Out.WriteLine($"lecturas {a.Almacen.Lecturas}; texto «{r.Text}»");
        Assert.That(a.Almacen.Lecturas, Is.EqualTo(0));
        Assert.That(r.Text, Does.Contain("KernelPlugin"));
    }
}
