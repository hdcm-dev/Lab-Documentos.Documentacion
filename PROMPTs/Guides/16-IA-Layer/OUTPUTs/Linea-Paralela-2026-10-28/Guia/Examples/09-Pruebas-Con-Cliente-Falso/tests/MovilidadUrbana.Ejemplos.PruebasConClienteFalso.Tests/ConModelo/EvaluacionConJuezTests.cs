using Microsoft.Extensions.AI;
using Microsoft.Extensions.AI.Evaluation;
using Microsoft.Extensions.AI.Evaluation.Quality;
using Microsoft.Extensions.AI.Evaluation.Reporting;
using Microsoft.Extensions.AI.Evaluation.Reporting.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests.Cableado;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests.Evaluacion;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests.ConModelo;

/// <summary>
/// El método de evaluación con un modelo como juez. Los evaluadores de calidad se ajustaron para modelos grandes
/// y, con modelos chicos o locales, el desempeño puede ser especialmente pobre: el resultado se informa como k/n
/// con su intervalo y NUNCA como compuerta. Corre sólo bajo demanda (CONMODELO_JUEZ=1): por defecto queda
/// Inconclusive («no medido»).
/// </summary>
[TestFixture, Category("ConModelo")]
public sealed class EvaluacionConJuezTests
{
    [Test]
    public async Task Paso2_EvaluadoPorUnJuez()
    {
        if (Environment.GetEnvironmentVariable("CONMODELO_JUEZ") != "1")
            Assert.Inconclusive("Juez: no medido (corre sólo bajo demanda, con CONMODELO_JUEZ=1).");

        using var host = ServidorDePrueba.Anfitrion(new());
        var juez = host.Services.GetRequiredKeyedService<IChatClient>(ComposicionDeIA.ClaveDelProveedor);
        var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
        var almacen = Environment.GetEnvironmentVariable("EVAL_ALMACEN") is { Length: > 0 } a
            ? a : Path.Combine(AppContext.BaseDirectory, "almacen-evaluacion");

        ReportingConfiguration config = DiskBasedReportingConfiguration.Create(
            storageRootPath: almacen,
            evaluators: [new RelevanceEvaluator(), new CoherenceEvaluator(), new GroundednessEvaluator(), new MedioEnCatalogoEvaluator()],
            chatConfiguration: new ChatConfiguration(juez),
            enableResponseCaching: true,
            executionName: Environment.GetEnvironmentVariable("BUILD_NUMBER") ?? $"{DateTime.Now:yyyyMMddTHHmmss}");

        await using ScenarioRun corrida = await config.CreateScenarioRunAsync("MovilidadUrbana.Encuesta.Paso2");
        var mensajes = new List<ChatMessage> { new(ChatRole.User, SalidaEstructuradaConModeloTests.Pedido) };
        ChatResponse respuesta = await corrida.ChatConfiguration!.ChatClient.GetResponseAsync(mensajes, Asistente.CrearOpciones(ia));
        EvaluationResult resultado = await corrida.EvaluateAsync(mensajes, respuesta,
            additionalContext: [new GroundednessEvaluatorContext("Medios válidos: colectivo, auto, bicicleta, moto, caminata, tren.")]);

        foreach (var m in resultado.Metrics.Values) TestContext.Out.WriteLine($"{m.Name}: {m.Interpretation?.Rating} {m.Reason}");
        Assert.That(resultado.Metrics, Has.Count.EqualTo(4));
    }
}
