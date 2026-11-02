using System.Diagnostics;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.RagEnMemoria.Application.Ayuda;
using MovilidadUrbana.RagEnMemoria.Infrastructure.AI;
using MovilidadUrbana.RagEnMemoria.Infrastructure.Persistence;
using MovilidadUrbana.RagEnMemoria.Tests.Evaluacion;
using NUnit.Framework;

namespace MovilidadUrbana.RagEnMemoria.Tests.ConModelo;

/// <summary>
/// La mitad de recuperación de la RAG contra qwen3-embedding, con el oro: hit@1, hit@3, recall@3 y MRR@3
/// sobre las respondibles, puntaje máximo de las no respondibles, con y sin instrucción en la consulta.
/// Los embeddings no muestrean: una corrida por consulta; repetirla es reproducción (se comprueba).
/// </summary>
public class RecuperacionConModeloTests
{
    [Test]
    public async Task Oro_ConYSinInstruccion()
    {
        var oro = ConjuntoDeOro.Cargar();
        var k = ServidorDePrueba.Pruebas.GetValue("K", 3);
        var log = new RegistroRllm("05-recuperacion");
        var rangos = new Dictionary<string, Dictionary<string, double>>();   // formato → consulta → RR@3

        foreach (var conInstruccion in new[] { true, false })
        {
            var formato = conInstruccion ? "con instrucción" : "sin instrucción";
            using var host = ServidorDePrueba.Anfitrion(conInstruccion ? null : new() { ["AI:Rag:InstruccionDeConsulta"] = "" });
            var reloj = Stopwatch.StartNew();
            await host.StartAsync();
            var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            var (version, digest) = await ServidorDePrueba.Identificar(host);
            var almacen = host.Services.GetRequiredService<AlmacenDeRequisitos>();
            if (conInstruccion)
            {
                log.Linea($"# Examples/05 — recuperación con el oro ({oro.Consultas.Count} consultas: {oro.Respondibles.Count()} respondibles, {oro.NoRespondibles.Count()} no respondibles; caso base {oro.VersionDelCasoBase})");
                log.Linea($"# {ServidorDePrueba.Estacion}; Ollama {version}; {DateTime.Now:yyyy-MM-dd HH:mm zzz}");
                log.Linea($"# modelo@digest: {ia.ModeloDeEmbeddings}@{digest(ia.ModeloDeEmbeddings)}; /api/embed por OllamaSharp; dimensión medida {almacen.Dimension}; k = {k}");
                log.Linea("# estimando: la tarea (unidad = consulta); embeddings sin muestreo: m = 1 y la repetición es reproducción; criterio escrito antes: 00-criterio-previo.md");
            }
            log.Linea($"## {formato}: «{ia.Rag.InstruccionDeConsulta}»; arranque e ingesta {reloj.Elapsed.TotalSeconds:0.0} s");

            var casos = new List<(IReadOnlyList<string>, IReadOnlyList<string>)>();
            var maximosNoResp = new List<double>();
            var maximosResp = new List<double>();
            rangos[formato] = [];
            foreach (var c in oro.Consultas)
            {
                var r = await almacen.BuscarAsync(c.Consulta, k, default);
                Assert.That(r, Has.Count.EqualTo(k), "invariante: k resultados");
                var ranking = r.Select(x => x.Fuente).ToList();
                var rr = c.Respondible ? MetricasDeRecuperacion.RangoReciproco(k, c.Relevantes, ranking) : double.NaN;
                if (c.Respondible) { casos.Add((c.Relevantes, (IReadOnlyList<string>)ranking)); maximosResp.Add(r[0].Puntaje); rangos[formato][c.Id] = rr; }
                else maximosNoResp.Add(r[0].Puntaje);
                log.Linea(string.Create(CultureInfo.InvariantCulture,
                    $"{c.Id}\t{(c.Respondible ? $"RR@{k}={rr:0.000}" : "no-resp")}\t{string.Join(" | ", r.Select(x => $"{x.Fuente} {x.Puntaje:0.000}"))}"));
            }

            // Reproducción: la misma consulta da los mismos puntajes.
            var a = await almacen.BuscarAsync(oro.Consultas[0].Consulta, k, default);
            var b = await almacen.BuscarAsync(oro.Consultas[0].Consulta, k, default);
            Assert.That(b.Select(x => x.Puntaje), Is.EqualTo(a.Select(x => x.Puntaje)), "invariante: reproducción idéntica");

            int K = casos.Count;
            int hits1 = casos.Count(cc => cc.Item2.Take(1).Intersect(cc.Item1).Any());
            int hits3 = casos.Count(cc => cc.Item2.Take(3).Intersect(cc.Item1).Any());
            log.Linea(string.Create(CultureInfo.InvariantCulture,
                $"RESUMEN {formato}: hit@1 {Estadistica.Fraccion(hits1, K)}; hit@3 {Estadistica.Fraccion(hits3, K)}; recall@3 {MetricasDeRecuperacion.RecallAt(3, casos):0.000}; MRR@3 {MetricasDeRecuperacion.MrrAt(3, casos):0.000} — la tarea, K = {K} consultas × m = 1"));
            log.Linea(string.Create(CultureInfo.InvariantCulture,
                $"PUNTAJE MÁXIMO {formato}: respondibles mín {maximosResp.Min():0.000} / mediana {Mediana(maximosResp):0.000}; no respondibles {string.Join(", ", maximosNoResp.Select(x => x.ToString("0.000", CultureInfo.InvariantCulture)))} (umbral de abstención: no calibrado en este ejemplo)"));
            log.Linea($"LÍNEA DE AZAR con 12 enunciados y un relevante: hit@1 = {1.0 / 12:0.000}, hit@3 = {3.0 / 12:0.000}");
            await host.StopAsync();
        }

        var pares = rangos["con instrucción"].Keys.Select(id => (rangos["con instrucción"][id], rangos["sin instrucción"][id])).ToList();
        log.Linea("PAREADA por consulta (RR@3, con frente a sin instrucción): " + Estadistica.Pareada("con", "sin", pares));
    }

    private static double Mediana(List<double> x)
    {
        var o = x.Order().ToList();
        return o.Count % 2 == 1 ? o[o.Count / 2] : (o[o.Count / 2 - 1] + o[o.Count / 2]) / 2;
    }
}
