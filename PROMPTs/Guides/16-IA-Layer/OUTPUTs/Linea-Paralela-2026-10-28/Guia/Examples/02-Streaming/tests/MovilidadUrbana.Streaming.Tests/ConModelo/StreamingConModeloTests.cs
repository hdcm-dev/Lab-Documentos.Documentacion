using System.Diagnostics;
using System.Text.Json;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using OllamaSharp;

namespace MovilidadUrbana.Streaming.Tests.ConModelo;

/// <summary>
/// Contra el servidor Ollama de prueba, por OLLAMA_ENDPOINT. Sin la variable: Inconclusive.
///
/// Criterio escrito antes de correr (2026-10-28):
/// (1) Respuesta completa, «este pedido», semillas 1..10, salida máxima 256 tokens.
///     Invariantes (fallan ante una sola violación): no cancelada; al menos 2 fragmentos con texto;
///     el texto concatenado es igual a ToChatResponse().Text. Se informan, sin umbral: motivo de fin,
///     presencia de Usage, tiempo al primer texto y total.
/// (2) Cancelación, «este pedido», semillas 1..10, salida máxima 400 tokens, cancelando al primer texto.
///     Invariantes: Cancelada; ningún texto después de Cancel(); ResponderAsync vuelve en menos de 2 s
///     desde Cancel(). Se registran, sin umbral, los tiempos de una pregunta siguiente corta.
///     (Una primera versión usaba «primer texto de la siguiente en menos de 15 s» como señal de que el
///     servidor dejó de generar: quedó descartada porque ese tiempo depende sobre todo de cuánto
///     prefijo del prompt reusa el servidor, no del corte. Si el servidor libera o no la generación
///     cortada no se mide acá.)
/// </summary>
[TestFixture, Category("ConModelo"), NonParallelizable]
public sealed class StreamingConModeloTests
{
    private const int Semillas = 10;
    private IHost? _host;
    private AsistenteDeLaEncuesta _asistente = null!;
    private string _cabecera = "";
    private string _salida = "";

    [OneTimeSetUp]
    public async Task Arrancar()
    {
        if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT")))
            Assert.Inconclusive("Sin OLLAMA_ENDPOINT: no medido.");

        var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
        {
            EnvironmentName = "Development",
            ContentRootPath = AppContext.BaseDirectory,
        });
        builder.AgregarIA();
        _host = builder.Build();
        await _host.StartAsync();
        _asistente = _host.Services.GetRequiredService<AsistenteDeLaEncuesta>();

        var ia = _host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
        using var meta = new OllamaApiClient(new Uri(ia.Endpoint));
        var modelo = (await meta.ListLocalModelsAsync()).Single(m => m.Name == ia.Modelo);
        var version = await meta.GetVersionAsync();
        _cabecera = $"{ia.Modelo}@{modelo.Digest[..12]}, T {ia.Muestreo.Temperatura}, think false, ruta /api/chat (OllamaSharp), " +
                    $"num_ctx {ia.NumCtx}, Ollama {version}, fecha {DateTimeOffset.Now:yyyy-MM-dd}";
        _salida = Environment.GetEnvironmentVariable("R_LLM_SALIDA") ?? Path.Combine(TestContext.CurrentContext.WorkDirectory, "salida-r-llm");
        Directory.CreateDirectory(_salida);
    }

    [OneTimeTearDown]
    public async Task Parar() { if (_host is not null) { await _host.StopAsync(); _host.Dispose(); } }

    [Test]
    public async Task Respuesta_completa_en_streaming()
    {
        var violaciones = new List<string>();
        var filas = new List<object>();
        for (int s = 1; s <= Semillas; s++)
        {
            var historial = _asistente.NuevaConversacion();
            int conTexto = 0;
            var r = await _asistente.ResponderAsync(historial, ContextoDeLaEncuesta.PreguntaDeEjemplo, _ => conTexto++,
                _asistente.CrearOpcionesDeChat(semilla: s, maximoDeTokensDeSalida: 256));

            if (r.Cancelada) violaciones.Add($"s{s}: cancelada");
            if (conTexto < 2) violaciones.Add($"s{s}: {conTexto} fragmentos con texto");
            if (r.Respuesta?.Text != r.Texto) violaciones.Add($"s{s}: ToChatResponse distinto de la concatenación");
            filas.Add(new
            {
                semilla = s, fragmentosConTexto = conTexto, fragmentos = r.Fragmentos,
                primerTextoS = r.PrimerFragmento?.TotalSeconds, totalS = r.Total.TotalSeconds,
                fin = r.Respuesta?.FinishReason?.Value, tokensEntrada = r.Respuesta?.Usage?.InputTokenCount,
                tokensSalida = r.Respuesta?.Usage?.OutputTokenCount, texto = r.Texto,
            });
        }
        int ok = Semillas - violaciones.Select(v => v.Split(':')[0]).Distinct().Count();
        Escribir("1-completa", filas, $"{ok}/{Semillas} sin violar los invariantes — estimando: este pedido, 1 pedido × {Semillas} semillas (s = 1..{Semillas}), {_cabecera}; criterio previo: invariantes (1) del encabezado; Wilson 95 % {Wilson(ok, Semillas)}");
        Assert.That(violaciones, Is.Empty);
    }

    [Test]
    public async Task Cancelar_al_primer_texto_corta_la_respuesta()
    {
        const string larga = "Explicá con detalle, campo por campo, todo lo que pide la encuesta y para qué sirve cada dato.";
        const string corta = "¿Cuál es la edad mínima para responder la encuesta? Contestá sólo con el número.";
        var violaciones = new List<string>();
        var filas = new List<object>();
        for (int s = 1; s <= Semillas; s++)
        {
            var historial = _asistente.NuevaConversacion();
            using var cts = new CancellationTokenSource();
            var desdeCancel = new Stopwatch();
            int textosDespues = 0;
            var r = await _asistente.ResponderAsync(historial, larga, _ =>
                {
                    if (cts.IsCancellationRequested) { textosDespues++; return; }
                    cts.Cancel(); desdeCancel.Start();
                },
                _asistente.CrearOpcionesDeChat(semilla: s, maximoDeTokensDeSalida: 400), cts.Token);
            desdeCancel.Stop();

            if (!r.Cancelada) violaciones.Add($"s{s}: no cancelada");
            if (textosDespues > 0) violaciones.Add($"s{s}: {textosDespues} textos después de Cancel()");
            if (desdeCancel.Elapsed >= TimeSpan.FromSeconds(2)) violaciones.Add($"s{s}: volvió a los {desdeCancel.Elapsed.TotalSeconds:F2} s");

            var siguiente = await _asistente.ResponderAsync(historial, corta, _ => { },
                _asistente.CrearOpcionesDeChat(semilla: s, maximoDeTokensDeSalida: 16));
            filas.Add(new
            {
                semilla = s, cancelada = r.Cancelada, primerTextoS = r.PrimerFragmento?.TotalSeconds,
                corteS = desdeCancel.Elapsed.TotalSeconds, textosDespues, parcial = r.Texto,
                siguientePrimerTextoS = siguiente.PrimerFragmento?.TotalSeconds, siguienteTotalS = siguiente.Total.TotalSeconds,
                siguienteTexto = siguiente.Texto,
            });
        }
        int ok = Semillas - violaciones.Select(v => v.Split(':')[0]).Distinct().Count();
        Escribir("2-cancelacion", filas,
            $"{ok}/{Semillas} sin violar los invariantes — estimando: este pedido, 1 pedido × {Semillas} semillas (s = 1..{Semillas}), {_cabecera}; criterio previo: (2) del encabezado; Wilson 95 % {Wilson(ok, Semillas)}");
        Assert.That(violaciones, Is.Empty);
    }

    private void Escribir(string nombre, List<object> filas, string resumen)
    {
        var lineas = new List<string> { $"# R-LLM: {resumen}" };
        lineas.AddRange(filas.Select(f => JsonSerializer.Serialize(f)));
        File.WriteAllLines(Path.Combine(_salida, $"{nombre}.jsonl"), lineas);
        TestContext.Out.WriteLine(resumen);
    }

    /// <summary>Intervalo de Wilson al 95 % (z = 1,96).</summary>
    public static string Wilson(int k, int n)
    {
        const double z = 1.96;
        double p = (double)k / n, d = 1 + z * z / n, c = p + z * z / (2 * n);
        double m = z * Math.Sqrt(p * (1 - p) / n + z * z / (4.0 * n * n));
        return string.Create(System.Globalization.CultureInfo.InvariantCulture, $"[{Math.Max(0, (c - m) / d):F2}; {Math.Min(1, (c + m) / d):F2}]");
    }
}
