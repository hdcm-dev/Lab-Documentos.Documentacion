using System.Globalization;
using System.Numerics.Tensors;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Busqueda.Busqueda;
using MovilidadUrbana.Busqueda.Configuracion;
using MovilidadUrbana.Busqueda.Evaluacion;
using OllamaSharp;

namespace MovilidadUrbana.Busqueda.Tests.ConModelo;

/// <summary>
/// Contra el servidor Ollama de prueba. Tres tipos de aserción: invariante (falla ante una violación),
/// tasa informada (k/n con su estimando, sin umbral de aprobación) y «no medido» (Inconclusive).
/// Criterio escrito antes de correr: evidencia-examples/04-Embeddings-Y-Busqueda/00-criterio-previo.md.
/// </summary>
[TestFixture, Category("ConModelo"), NonParallelizable]
public sealed class BusquedaConModeloTests
{
    private const int Repeticiones = 3; // m por consulta: los embeddings no muestrean, así que se mide si repiten
    private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;
    private const string Rotulo = "medido en la estación de laboratorio";

    [Test]
    public async Task Invariante_DimensionDelModelo_1024Arranca_512NoArranca()
    {
        var r = new RegistroRllm("01-dimension");
        using (var host = ServidorDePrueba.Anfitrion())
        {
            await host.StartAsync(); // el verificador revisa los 13 vectores (prueba + 12 requisitos)
            var almacen = host.Services.GetRequiredService<AlmacenDeRequisitos>();
            r.Linea($"declarada 1024 → arranca; dimensión medida = {almacen.Dimension}");
            Assert.That(almacen.Dimension, Is.EqualTo(1024));
        }

        using (var host = ServidorDePrueba.Anfitrion(new() { ["AI:DimensionDeEmbeddings"] = "512" }))
        {
            var ex = await Assert.ThrowsAsync<DimensionDeEmbeddingsException>(() => host.StartAsync());
            r.Linea($"declarada 512 → no arranca: {ex!.Message}");
            Assert.That((ex.Declarada, ex.Medida), Is.EqualTo((512, 1024)));
        }
        r.Guardar();
    }

    [Test]
    public async Task TasaDeLaTarea_OroConYSinInstruccion()
    {
        using var host = ServidorDePrueba.Anfitrion();
        await host.StartAsync();
        var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
        var almacen = host.Services.GetRequiredService<AlmacenDeRequisitos>();
        var oro = GeneradorDeOro.Leer(Path.Combine(AppContext.BaseDirectory, "oro", "oro-requisitos.json"));
        var (version, digest) = await ServidorDePrueba.Identificar(ia.ModeloDeEmbeddings);
        var fecha = DateTime.Now.ToString("yyyy-MM-dd", Inv);

        var conInstruccion = await EvaluacionDeRecuperacion.CorrerAsync(almacen, oro, ia.Busqueda.InstruccionDeConsulta, ia.Busqueda.Top, 12);
        var sinInstruccion = await EvaluacionDeRecuperacion.CorrerAsync(almacen, oro, null, ia.Busqueda.Top, 12);

        // m = 3 repeticiones por consulta y formato, por el generador SIN caché: ¿el vector se repite?
        using var http = new HttpClient { BaseAddress = new Uri(ia.Endpoint), Timeout = TimeSpan.FromSeconds(ia.TimeoutSegundos) };
        IEmbeddingGenerator<string, Embedding<float>> crudo = new OllamaApiClient(http, ia.ModeloDeEmbeddings);
        int identicas = 0, pares = 0;
        double maxDif = 0;
        foreach (var c in oro.Consultas)
            foreach (var instr in new[] { ia.Busqueda.InstruccionDeConsulta, null })
            {
                var texto = FormatoDeConsulta.Aplicar(instr, c.Consulta);
                var v = new List<float[]>();
                for (var s = 0; s < Repeticiones; s++) v.Add((await crudo.GenerateVectorAsync(texto)).ToArray());
                for (var s = 1; s < Repeticiones; s++)
                {
                    pares++;
                    var dif = v[0].Zip(v[s], (a, b) => Math.Abs(a - b)).Max();
                    maxDif = Math.Max(maxDif, dif);
                    if (dif == 0) identicas++;
                }
            }

        var e1 = conInstruccion.Evaluacion; var e0 = sinInstruccion.Evaluacion;
        int kr = e1.Respondibles.Count, kn = e1.NoRespondibles.Count;
        var r = new RegistroRllm("02-oro-con-y-sin-instruccion");
        r.Linea($"# R-LLM — estimando: tarea, K = {kr} respondibles + {kn} no respondibles × m = {Repeticiones} repeticiones " +
                $"(los embeddings no muestrean: sin semilla ni temperatura), {ia.ModeloDeEmbeddings}@{digest}, T n/a, think n/a, " +
                $"ruta /api/embed (OllamaSharp 5.5.0), criterio previo: 00-criterio-previo.md, {fecha}; Wilson 95 % sobre las consultas; " +
                $"crudo: este archivo. Ollama {version}; {Rotulo}.");
        r.Linea($"repeticiones: {identicas}/{pares} pares de vectores idénticos (diferencia máxima {maxDif.ToString("G3", Inv)})");
        r.Linea();
        r.Linea(EvaluacionDeRecuperacion.Tabla(conInstruccion));
        r.Linea(EvaluacionDeRecuperacion.Tabla(sinInstruccion));

        // Comparación pareada (mismas consultas, mismo digest): pares discordantes por métrica binaria.
        void Pareada(string metrica, Func<FilaDeConsulta, bool> exito, IEnumerable<FilaDeConsulta> f1, IEnumerable<FilaDeConsulta> f0)
        {
            var pares1 = f1.Zip(f0).ToList();
            int soloCon = pares1.Count(p => exito(p.First) && !exito(p.Second));
            int soloSin = pares1.Count(p => !exito(p.First) && exito(p.Second));
            var veredicto = (soloCon + soloSin >= 6 && (soloCon == 0 || soloSin == 0)) ? "difiere (≥ 6 discordantes en un solo sentido)" : "no separado con este N";
            r.Linea($"pareada {metrica}: sólo con instrucción {soloCon}, sólo sin instrucción {soloSin} → {veredicto}");
        }
        Pareada("hit@1", f => f.HitEn(1), e1.Respondibles, e0.Respondibles);
        Pareada("hit@3", f => f.HitEn(3), e1.Respondibles, e0.Respondibles);
        Pareada("abstención", f => f.SeAbstiene, e1.NoRespondibles, e0.NoRespondibles);
        r.Guardar();

        // Sólo invariantes de estructura: las tasas se informan, no se aprueban.
        Assert.Multiple(() =>
        {
            Assert.That(kr, Is.GreaterThanOrEqualTo(10));
            Assert.That(kn, Is.GreaterThanOrEqualTo(10));
            Assert.That(e1.Filas.All(f => f.Resultados.Count == ia.Busqueda.Top), Is.True);
        });
    }

    [Test]
    public async Task Existencia_SimilitudEntreMedios()
    {
        using var host = ServidorDePrueba.Anfitrion();
        await host.StartAsync();
        var generador = host.Services.GetRequiredService<IEmbeddingGenerator<string, Embedding<float>>>();
        var r = new RegistroRllm("03-similitud-entre-medios");
        r.Linea($"# existencia, n = 1 por par (los embeddings no muestrean); {Rotulo}");
        foreach (var (a, b) in new[] { ("colectivo", "ómnibus"), ("colectivo", "bicicleta"), ("en avión", "Moto"), ("en avión", "Tren") })
        {
            var va = await generador.GenerateVectorAsync(a);
            var vb = await generador.GenerateVectorAsync(b);
            r.Linea($"coseno(«{a}», «{b}») = {TensorPrimitives.CosineSimilarity(va.Span, vb.Span).ToString("0.0000", Inv)}");
        }
        r.Guardar();
    }
}
