using System.Diagnostics;
using System.Globalization;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.RagEnMemoria.Application.Ayuda;
using MovilidadUrbana.RagEnMemoria.Infrastructure.AI;
using MovilidadUrbana.RagEnMemoria.Tests.Evaluacion;
using NUnit.Framework;

namespace MovilidadUrbana.RagEnMemoria.Tests.ConModelo;

/// <summary>
/// Comparación pareada de las dos estrategias de IAyuda con el mismo oro, el mismo modelo, las mismas
/// semillas y el mismo criterio (escrito antes): contexto fijo (los 12) frente a RAG por la vía A (los k
/// recuperados). La recuperación se calcula primero para todas las consultas, así el servidor no alterna
/// entre el modelo de embeddings y el de chat; después corre una estrategia entera y luego la otra.
/// </summary>
public class ContextoFijoFrenteARagConModeloTests
{
    private sealed class BuscadorPrecalculado(IReadOnlyDictionary<string, IReadOnlyList<FragmentoRecuperado>> resultados) : IBuscadorDeRequisitos
    {
        public Task<IReadOnlyList<FragmentoRecuperado>> BuscarAsync(string consulta, int k, CancellationToken cancellationToken) =>
            Task.FromResult<IReadOnlyList<FragmentoRecuperado>>(resultados[consulta].Take(k).ToList());
    }

    [Test]
    public async Task Oro_ContextoFijoFrenteARag_Pareado()
    {
        var oro = ConjuntoDeOro.Cargar();
        int m = ServidorDePrueba.Pruebas.GetValue("Semillas", 3);
        using var host = ServidorDePrueba.Anfitrion();
        await host.StartAsync();
        var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>();
        var (version, digest) = await ServidorDePrueba.Identificar(host);
        var buscador = host.Services.GetRequiredService<IBuscadorDeRequisitos>();
        var log = new RegistroRllm("05-contexto-fijo-frente-a-rag");

        var recuperado = new Dictionary<string, IReadOnlyList<FragmentoRecuperado>>();
        foreach (var c in oro.Consultas) recuperado[c.Consulta] = await buscador.BuscarAsync(c.Consulta, ia.Value.Rag.K, default);

        var chat = host.Services.GetRequiredService<IChatClient>();
        var fabrica = host.Services.GetRequiredService<FabricaDeOpcionesDeChat>();
        var estrategias = new (string Nombre, IAyuda Ayuda)[]
        {
            ("contexto-fijo", new AyudaContextoFijo(chat, fabrica, ia)),
            ("rag", new AyudaRag(chat, new BuscadorPrecalculado(recuperado), fabrica, ia)),
        };

        var mu = ia.Value.Muestreo;
        log.Linea($"# Examples/05 — contexto fijo frente a RAG (vía A), pareado por consulta; caso base {oro.VersionDelCasoBase}");
        log.Linea($"# {ServidorDePrueba.Estacion}; Ollama {version}; {DateTime.Now:yyyy-MM-dd HH:mm zzz}");
        log.Linea($"# chat {ia.Value.Modelo}@{digest(ia.Value.Modelo)}; embeddings {ia.Value.ModeloDeEmbeddings}@{digest(ia.Value.ModeloDeEmbeddings)} (con instrucción); /api/chat por OllamaSharp");
        log.Linea(string.Create(CultureInfo.InvariantCulture,
            $"# T {mu.Temperatura}, top_p {mu.TopP}, top_k {mu.TopK}, presence {mu.PenalizacionPorPresencia}, think off, num_ctx {ia.Value.NumCtx}, num_predict {ia.Value.MaxTokensDeSalida}, k = {ia.Value.Rag.K}"));
        log.Linea($"# K = {oro.Consultas.Count} consultas ({oro.Respondibles.Count()} respondibles + {oro.NoRespondibles.Count()} no respondibles) × m = {m} semillas (s = 1..{m}); estimando: la tarea; criterio escrito antes: 00-criterio-previo.md");
        log.Linea("estrategia\tid\tsemilla\tok\tcitas\ttokens_entrada\ttokens_salida\tpared_s\ttexto");

        var tasas = new Dictionary<string, Dictionary<string, int>>();   // estrategia → consulta → aciertos
        var paredes = new Dictionary<string, List<double>>();
        var entradas = new Dictionary<string, List<long>>();
        var citasFueraDelPrompt = new Dictionary<string, int>();
        foreach (var (nombre, ayuda) in estrategias)
        {
            tasas[nombre] = []; paredes[nombre] = []; entradas[nombre] = []; citasFueraDelPrompt[nombre] = 0;
            foreach (var c in oro.Consultas)
            {
                tasas[nombre][c.Id] = 0;
                for (var s = 1; s <= m; s++)
                {
                    var reloj = Stopwatch.StartNew();
                    var r = await ayuda.ResponderAsync(c.Consulta, s, default);
                    reloj.Stop();
                    Assert.That(r.Texto, Is.Not.Empty, "invariante: respuesta no vacía");
                    var ok = CriterioDeRespuesta.Cumple(c, r.Texto, r.FuentesCitadas);
                    if (ok) tasas[nombre][c.Id]++;
                    if (r.FuentesCitadas.Except(r.FragmentosEnElPrompt.Select(f => f.Fuente)).Any()) citasFueraDelPrompt[nombre]++;
                    paredes[nombre].Add(reloj.Elapsed.TotalSeconds);
                    if (r.TokensDeEntrada is { } te) entradas[nombre].Add(te);
                    log.Linea(string.Create(CultureInfo.InvariantCulture,
                        $"{nombre}\t{c.Id}\t{s}\t{(ok ? 1 : 0)}\t{string.Join(",", r.FuentesCitadas)}\t{r.TokensDeEntrada}\t{r.TokensDeSalida}\t{reloj.Elapsed.TotalSeconds:0.0}\t{r.Texto.Replace('\n', ' ')}"));
                }
            }
        }

        log.Linea("## Tabla por consulta (aciertos/m)");
        foreach (var c in oro.Consultas)
            log.Linea($"{c.Id}\t{(c.Respondible ? "resp" : "no-resp")}\tcontexto-fijo {tasas["contexto-fijo"][c.Id]}/{m}\trag {tasas["rag"][c.Id]}/{m}\trecuperados: {string.Join(", ", recuperado[c.Consulta].Select(f => f.Fuente))}");

        foreach (var (grupo, consultas) in new[] { ("todas", oro.Consultas.ToList()), ("respondibles", oro.Respondibles.ToList()), ("no respondibles", oro.NoRespondibles.ToList()) })
        {
            foreach (var (nombre, _) in estrategias)
            {
                var j = consultas.Count(c => tasas[nombre][c.Id] == m);
                var media = consultas.Average(c => (double)tasas[nombre][c.Id] / m);
                log.Linea(string.Create(CultureInfo.InvariantCulture,
                    $"RESUMEN {grupo} {nombre}: consultas que pasan en {m}/{m}: {Estadistica.Fraccion(j, consultas.Count)}; media de las tasas por consulta {media:0.000} (la tarea, K = {consultas.Count} × m = {m}; sin Wilson sobre K·m)"));
            }
            var pares = consultas.Select(c => ((double)tasas["contexto-fijo"][c.Id], (double)tasas["rag"][c.Id])).ToList();
            log.Linea($"PAREADA {grupo}: " + Estadistica.Pareada("contexto-fijo", "rag", pares));
        }
        foreach (var (nombre, _) in estrategias)
            log.Linea(string.Create(CultureInfo.InvariantCulture,
                $"COSTO {nombre}: tokens de entrada mediana {Mediana(entradas[nombre].Select(x => (double)x).ToList()):0} (rango {entradas[nombre].DefaultIfEmpty().Min()}–{entradas[nombre].DefaultIfEmpty().Max()}); pared mediana {Mediana(paredes[nombre]):0.0} s (rango {paredes[nombre].Min():0.0}–{paredes[nombre].Max():0.0}); corridas con una cita que no estaba en el prompt: {citasFueraDelPrompt[nombre]}/{paredes[nombre].Count}"));
        await host.StopAsync();
    }

    private static double Mediana(List<double> x)
    {
        if (x.Count == 0) return double.NaN;
        var o = x.Order().ToList();
        return o.Count % 2 == 1 ? o[o.Count / 2] : (o[o.Count / 2 - 1] + o[o.Count / 2]) / 2;
    }
}
