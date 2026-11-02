using Microsoft.Extensions.DependencyInjection;
using MovilidadUrbana.ApiWeb.Application.Encuestas;
using MovilidadUrbana.Ejemplos.Orquestacion.Application.Encuesta;
using MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.Workflows;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.Orquestacion.Tests.Cableado;

/// <summary>
/// CASO-8, el contraejemplo: la encuesta de tres pasos como función y como workflow de MAF dan lo mismo.
/// El grafo suma piezas (executors, aristas, supersteps) y ningún paso usa un modelo.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class EncuestaContraejemploTests
{
    private static IEnumerable<TestCaseData> Encuestas() =>
        EncuestasDeEjemplo.Todas.Select(e => new TestCaseData(e.Nombre).SetName($"FuncionYWorkflowDeMafDanLoMismo({e.Nombre})"));

    [TestCaseSource(nameof(Encuestas))]
    public async Task FuncionYWorkflowDeMafDanLoMismo(string nombre)
    {
        var crear = EncuestasDeEjemplo.Todas.Single(e => e.Nombre == nombre).Crear;

        using var conFuncion = new Anfitrion(Anfitrion.Devuelve("-"));
        var porFuncion = await conFuncion.Servicios.GetRequiredService<EncuestaComoProceso>().CompletarAsync(crear());

        using var conGrafo = new Anfitrion(Anfitrion.Devuelve("-"));
        var (porGrafo, executors, supersteps) =
            await EncuestaComoWorkflowDeMaf.CompletarAsync(conGrafo.Servicios.GetRequiredService<EncuestaService>(), crear());

        TestContext.Out.WriteLine($"{nombre}: función → {porFuncion}; grafo → {porGrafo}; {supersteps} supersteps: {string.Join(" > ", executors)}");
        Assert.Multiple(() =>
        {
            Assert.That(porGrafo.Registrada, Is.EqualTo(porFuncion.Registrada));
            Assert.That(porGrafo.PasoConErrores, Is.EqualTo(porFuncion.PasoConErrores));
            Assert.That(porGrafo.Errores.Keys, Is.EquivalentTo(porFuncion.Errores.Keys));
            Assert.That(conGrafo.Almacen.Escrituras, Is.EqualTo(conFuncion.Almacen.Escrituras));
            Assert.That(conGrafo.Almacen.Escrituras, Is.EqualTo(porFuncion.Registrada ? 1 : 0));
            Assert.That(conGrafo.Cliente.Llamadas, Is.Empty, "ningún paso llama al modelo");
            Assert.That(conFuncion.Cliente.Llamadas, Is.Empty);
        });
    }

    [Test]
    public void ElGrafoSumaPiezasYNingunaEsUnAgente()
    {
        using var anfitrion = new Anfitrion(Anfitrion.Devuelve("-"));
        var workflow = EncuestaComoWorkflowDeMaf.Construir(anfitrion.Servicios.GetRequiredService<EncuestaService>());

        var executors = workflow.ReflectExecutors();
        var aristas = workflow.ReflectEdges().Sum(e => e.Value.Count);
        TestContext.Out.WriteLine($"executors: {string.Join(", ", executors.Keys.Order())}; aristas: {aristas}; " +
                                  $"tipos: {string.Join(", ", executors.Values.Select(b => b.ExecutorType.Name).Distinct())}");

        Assert.That(executors.Keys, Is.EquivalentTo(new[] { "paso-1", "paso-2", "paso-3", "rechazo", "registro" }));
        Assert.That(aristas, Is.EqualTo(6));
        Assert.That(executors.Values.Select(b => b.ExecutorType.Name), Has.None.Contains("Agent"));
    }
}
