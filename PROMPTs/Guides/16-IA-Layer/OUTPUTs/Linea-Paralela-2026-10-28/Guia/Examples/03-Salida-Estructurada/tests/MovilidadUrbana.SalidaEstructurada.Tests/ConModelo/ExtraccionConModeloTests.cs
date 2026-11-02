using System.Diagnostics;
using System.Text.Json;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Options;
using MovilidadUrbana.SalidaEstructurada.Application.Propuestas;
using MovilidadUrbana.SalidaEstructurada.Infrastructure.AI;
using MovilidadUrbana.SalidaEstructurada.Tests.Dobles;
using OllamaSharp;

namespace MovilidadUrbana.SalidaEstructurada.Tests.ConModelo;

/// <summary>
/// Contra el servidor Ollama de prueba, por turno. Sin OLLAMA_ENDPOINT, Inconclusive (no se saltea en silencio).
/// Afirma invariantes (fallan ante una sola violación) e informa tasas k/m con Wilson 95 %, sin umbral.
/// El criterio de cada tasa está escrito en <see cref="Pedidos" /> antes de correr.
/// </summary>
[TestFixture, Category("ConModelo"), NonParallelizable]
public sealed class ExtraccionConModeloTests
{
    private sealed record Pedido(string Id, string Texto, (string Nombre, Func<LocalidadPropuesta?, Revision, bool> Cumple)[] Tasas);

    private static readonly Pedido[] Pedidos =
    [
        new("D1-cp-invalido", "Agregá Goya, Corrientes, CP 34, 89959 habitantes",
        [
            ("forma válida (TryGetResult)", (p, _) => p is not null),
            ("CP distinto de «34» (inventado)", (p, _) => p is not null && p.CodigoPostal?.Trim() != "34"),
            ("llega a la pantalla sin errores", (_, r) => r is Revision.ParaConfirmar { Errores.Count: 0 })
        ]),
        new("alta-completa", "Agregá Goya, Corrientes, CP 3450, unos 90 mil habitantes",
        [
            ("forma válida (TryGetResult)", (p, _) => p is not null),
            ("igual a lo esperado (Alta, sin id, Goya, Corrientes, 3450, 90000)",
                (p, _) => p == new LocalidadPropuesta(TipoDePropuesta.Alta, null, "Goya", "Corrientes", "3450", 90000)),
            ("llega a la pantalla sin errores", (_, r) => r is Revision.ParaConfirmar { Errores.Count: 0 })
        ]),
        new("D2-sin-habitantes", "En Bella Vista, Corrientes, CP 3432, no sé cuántos viven",
        [
            ("forma válida (TryGetResult)", (p, _) => p is not null),
            ("habitantes en null (no inventa)", (p, _) => p is not null && p.Habitantes is null),
            ("la pantalla pide los habitantes", (_, r) => r is Revision.ParaConfirmar pc && pc.Errores.ContainsKey("habitantes"))
        ]),
        new("modificacion", "Corregí Resistencia: tiene 300000 habitantes",
        [
            ("forma válida (TryGetResult)", (p, _) => p is not null),
            ("Modificacion con el id 2 de la sesión", (p, _) => p is { Tipo: TipoDePropuesta.Modificacion, Id: 2 }),
            ("no se descarta", (_, r) => r is not Revision.Descartada)
        ])
    ];

    [Test]
    public async Task Extraccion_ConElServidorDePrueba()
    {
        var endpoint = Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT");
        if (string.IsNullOrWhiteSpace(endpoint))
            Assert.Inconclusive("Sin OLLAMA_ENDPOINT: no medido.");

        var ia = Opciones.DelAppsettings();
        ia.Endpoint = endpoint;
        var modelo = Environment.GetEnvironmentVariable("OLLAMA_MODEL");
        if (!string.IsNullOrWhiteSpace(modelo)) ia.Modelo = modelo;
        int m = int.TryParse(Environment.GetEnvironmentVariable("CONMODELO_M"), out var mm) ? mm : 10;
        var estacion = Environment.GetEnvironmentVariable("ESTACION") ?? "sin rótulo de estación";
        var salidaDir = Environment.GetEnvironmentVariable("SALIDA_DIR") ?? TestContext.CurrentContext.WorkDirectory;
        Directory.CreateDirectory(salidaDir);

        using var http = new HttpClient { BaseAddress = new Uri(ia.Endpoint), Timeout = TimeSpan.FromSeconds(ia.TimeoutSegundos) };
        var ollama = new OllamaApiClient(http, ia.Modelo);
        var digest = (await ollama.ListLocalModelsAsync()).FirstOrDefault(x => x.Name == ia.Modelo)?.Digest?[..12] ?? "digest-desconocido";

        var crudo = Path.Combine(salidaDir, "conmodelo-salidas.jsonl");
        await using var escritor = new StreamWriter(crudo, append: false);
        var conteos = Pedidos.ToDictionary(p => p.Id, p => new int[p.Tasas.Length]);
        var violaciones = new List<string>();
        int escriturasTotales = 0;

        foreach (var pedido in Pedidos)
        for (int semilla = 1; semilla <= m; semilla++)
        {
            var guarda = new GuardaRespuesta(ollama);
            IChatClient chat = guarda.AsBuilder().ConfigureOptions(o => o.Seed = semilla).Build();
            var extractor = new ExtractorDeLocalidadLlm(chat, Options.Create(ia));
            var repositorio = new RepositorioEspia("sesion-a");
            var reloj = Stopwatch.StartNew();
            LocalidadPropuesta? propuesta = await extractor.ExtraerAsync(pedido.Texto, await repositorio.GetAllAsync());
            var revision = await new RevisorDePropuesta(repositorio).RevisarAsync(propuesta);
            reloj.Stop();

            // Invariantes: ninguna escritura; nada con tipo fuera del enum llega a la pantalla.
            escriturasTotales += repositorio.Escrituras;
            if (repositorio.Escrituras != 0) violaciones.Add($"{pedido.Id} s{semilla}: {repositorio.Escrituras} escrituras");
            if (revision is Revision.ParaConfirmar && propuesta is not null && !Enum.IsDefined(propuesta.Tipo))
                violaciones.Add($"{pedido.Id} s{semilla}: tipo fuera del enum en pantalla");

            var cumple = pedido.Tasas.Select(t => t.Cumple(propuesta, revision)).ToArray();
            for (int i = 0; i < cumple.Length; i++) if (cumple[i]) conteos[pedido.Id][i]++;

            await escritor.WriteLineAsync(JsonSerializer.Serialize(new
            {
                pedido = pedido.Id, semilla, pared_s = Math.Round(reloj.Elapsed.TotalSeconds, 2),
                crudo = guarda.UltimoTexto, propuesta, revision = revision.GetType().Name,
                errores = (revision as Revision.ParaConfirmar)?.Errores, motivo = (revision as Revision.Descartada)?.Motivo,
                cumple, tokens_entrada = guarda.TokensDeEntrada, tokens_salida = guarda.TokensDeSalida
            }));
        }

        var resumen = new List<string>
        {
            $"# R-LLM — ejemplo 03-Salida-Estructurada — {DateTimeOffset.Now:yyyy-MM-dd HH:mm zzz}",
            $"# modelo@digest: {ia.Modelo}@{digest}; T {ia.Muestreo.Temperatura}, top_p {ia.Muestreo.TopP}, top_k {ia.Muestreo.TopK}, presence_penalty {ia.Muestreo.PresencePenalty}; think false; num_ctx {ia.NumCtx}; ruta /api/chat (OllamaSharp); semillas 1..{m}",
            $"# {estacion}",
            "# criterio previo: el de cada tasa, escrito en ConModelo/ExtraccionConModeloTests.cs (Pedidos) antes de correr",
            $"# crudo: {Path.GetFileName(crudo)}",
            $"invariante: escrituras en el repositorio = {escriturasTotales} (de {Pedidos.Length * m} corridas); violaciones = {violaciones.Count}"
        };
        foreach (var pedido in Pedidos)
            for (int i = 0; i < pedido.Tasas.Length; i++)
            {
                int k = conteos[pedido.Id][i];
                var (a, b) = Wilson(k, m);
                resumen.Add($"{k}/{m} — estimando: este pedido, 1 pedido × {m} semillas (s = 1..{m}) — {pedido.Id} «{pedido.Texto}»: {pedido.Tasas[i].Nombre}; Wilson 95 % [{a:0.00}; {b:0.00}]");
            }
        await File.WriteAllLinesAsync(Path.Combine(salidaDir, "conmodelo-resumen.txt"), resumen);
        foreach (var linea in resumen) TestContext.Out.WriteLine(linea);

        Assert.That(violaciones, Is.Empty, string.Join("; ", violaciones));
    }

    private static (double, double) Wilson(int k, int n)
    {
        const double z = 1.959964;
        double p = (double)k / n, d = 1 + z * z / n;
        double c = p + z * z / (2 * n), r = z * Math.Sqrt(p * (1 - p) / n + z * z / (4.0 * n * n));
        return (Math.Max(0, (c - r) / d), Math.Min(1, (c + r) / d));
    }

    /// <summary>Guarda el texto crudo y el uso de la última respuesta, para la evidencia.</summary>
    private sealed class GuardaRespuesta(IChatClient inner) : DelegatingChatClient(inner)
    {
        public string? UltimoTexto { get; private set; }
        public long? TokensDeEntrada { get; private set; }
        public long? TokensDeSalida { get; private set; }

        public override async Task<ChatResponse> GetResponseAsync(
            IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
        {
            var r = await base.GetResponseAsync(messages, options, cancellationToken);
            UltimoTexto = r.Text;
            TokensDeEntrada = r.Usage?.InputTokenCount;
            TokensDeSalida = r.Usage?.OutputTokenCount;
            return r;
        }
    }
}
