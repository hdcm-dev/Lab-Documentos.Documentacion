using Microsoft.Extensions.AI;
using Microsoft.Extensions.AI.Evaluation;
using Microsoft.Extensions.AI.Evaluation.Quality;
using Microsoft.Extensions.AI.Evaluation.Reporting;
using Microsoft.Extensions.AI.Evaluation.Reporting.Storage;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Encuestas;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests.Evaluacion;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests.Cableado;

/// <summary>Contrato de la salida estructurada del paso 2 y evaluadores, con un cliente falso (sin modelo).</summary>
[TestFixture, Category("Cableado")]
public sealed class SalidaEstructuradaYEvaluacionTests
{
    public const string TextoDeLaPersona = "Voy en bondi y a veces en bici, casi todos los días";

    [Test]
    public async Task ContratoDeSalidaEstructurada_CasoFeliz_Malformado_YEsquema()
    {
        // Caso feliz
        var ok = new ClienteGuionado { Responder = _ => """{"medios":["colectivo","bicicleta"],"frecuencia":"diaria"}""" };
        var r1 = await ok.GetResponseAsync<EncuestaPaso2Propuesta>(TextoDeLaPersona);
        Assert.That(r1.TryGetResult(out var p) && p.Medios.SequenceEqual(["colectivo", "bicicleta"]) && p.Frecuencia == "diaria", Is.True);

        // El modelo no respeta el formato: el código no se rompe
        var mal = new ClienteGuionado { Responder = _ => "no es JSON" };
        var r2 = await mal.GetResponseAsync<EncuestaPaso2Propuesta>(TextoDeLaPersona);
        Assert.That(r2.TryGetResult(out _), Is.False);

        // El esquema que se envía es parte del contrato
        var esquema = (mal.UltimasOpciones?.ResponseFormat as ChatResponseFormatJson)?.Schema?.ToString();
        Assert.That(esquema, Does.Contain("\"required\""));
    }

    [TestCase("""{"medios":["piedra"],"frecuencia":"diaria"}""", false, "piedra")]
    [TestCase("""{"medios":["bondi","bici"],"frecuencia":"diaria"}""", false, "bondi")]
    [TestCase("""{"medios":["colectivo","bicicleta"],"frecuencia":"diaria"}""", true, "catálogo")]
    [TestCase("no es JSON", false, "no es JSON")]
    public async Task MedioEnCatalogoEvaluator_DaLaMetricaConSuMotivo(string respuesta, bool esperado, string motivo)
    {
        var resultado = await new MedioEnCatalogoEvaluator().EvaluateAsync(
            [new ChatMessage(ChatRole.User, TextoDeLaPersona)], new ChatResponse(new ChatMessage(ChatRole.Assistant, respuesta)));
        var metrica = resultado.Get<BooleanMetric>(MedioEnCatalogoEvaluator.Nombre);

        Assert.Multiple(() =>
        {
            Assert.That(metrica.Value, Is.EqualTo(esperado));
            Assert.That(metrica.Interpretation!.Failed, Is.EqualTo(!esperado));
            Assert.That(metrica.Reason, Does.Contain(motivo));
        });
    }

    /// <summary>
    /// El método de evaluación con juez, cableado con un juez FALSO: las cuatro métricas aparecen y el almacén
    /// queda escrito para <c>aieval report</c>. No mide calidad: el juez no es un modelo.
    /// </summary>
    [Test]
    public async Task EvaluacionConJuezFalso_LasMetricasAparecen_YQuedaElAlmacen()
    {
        var almacen = Environment.GetEnvironmentVariable("EVAL_ALMACEN") is { Length: > 0 } a
            ? a : Path.Combine(AppContext.BaseDirectory, "almacen-evaluacion");
        var juez = new ClienteGuionado { Responder = _ => "<S0>sin razonamiento</S0><S1>el juez es falso</S1><S2>3</S2>" };
        var config = DiskBasedReportingConfiguration.Create(
            storageRootPath: almacen,
            evaluators: [new RelevanceEvaluator(), new CoherenceEvaluator(), new GroundednessEvaluator(), new MedioEnCatalogoEvaluator()],
            chatConfiguration: new ChatConfiguration(juez),
            enableResponseCaching: false,
            executionName: "cableado-juez-falso");

        EvaluationResult resultado;
        await using (var corrida = await config.CreateScenarioRunAsync("MovilidadUrbana.Encuesta.Paso2"))
        {
            var mensajes = new List<ChatMessage> { new(ChatRole.User, TextoDeLaPersona) };
            var respuesta = new ChatResponse(new ChatMessage(ChatRole.Assistant, """{"medios":["colectivo","bicicleta"],"frecuencia":"diaria"}"""));
            resultado = await corrida.EvaluateAsync(mensajes, respuesta,
                additionalContext: [new GroundednessEvaluatorContext("Medios válidos: colectivo, auto, bicicleta, moto, caminata, tren.")]);
        }

        foreach (var m in resultado.Metrics.Values)
            TestContext.Out.WriteLine($"{m.Name}: {m.GetType().Name} interpretación={m.Interpretation?.Rating} diagnósticos={m.Diagnostics?.Count ?? 0}");
        Assert.That(resultado.Metrics.Keys, Is.SupersetOf(new[] { "Relevance", "Coherence", "Groundedness", MedioEnCatalogoEvaluator.Nombre }));
        Assert.That(Directory.EnumerateFiles(almacen, "*", SearchOption.AllDirectories), Is.Not.Empty);
    }
}
