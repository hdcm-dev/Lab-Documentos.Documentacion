using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Extensions.AI;
using MovilidadUrbana.Asistente.Infrastructure.AI;
using OllamaSharp;

namespace MovilidadUrbana.Asistente.Tests.ConModelo;

/// <summary>Lo que el modelo devolvió en cada llamada: funciones pedidas y texto. Lo usa la clasificación de corridas.</summary>
public sealed class Registrador(IChatClient interno) : DelegatingChatClient(interno)
{
    private readonly List<string> _funcionesPedidas = [];
    public IReadOnlyList<string> FuncionesPedidas { get { lock (_funcionesPedidas) return _funcionesPedidas.ToList(); } }

    public override async Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
    {
        var r = await base.GetResponseAsync(messages, options, cancellationToken);
        Anotar(r.Messages.SelectMany(m => m.Contents));
        return r;
    }

    public override async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await foreach (var u in base.GetStreamingResponseAsync(messages, options, cancellationToken))
        {
            Anotar(u.Contents);
            yield return u;
        }
    }

    private void Anotar(IEnumerable<AIContent> contenidos)
    {
        lock (_funcionesPedidas) _funcionesPedidas.AddRange(contenidos.OfType<FunctionCallContent>().Select(f => f.Name));
    }
}

/// <summary>
/// Servidor de prueba, cabecera R-LLM y salida cruda en JSONL. Sin <c>OLLAMA_ENDPOINT</c>, «no medido».
/// </summary>
public static class RegistroRllm
{
    public static string Endpoint => Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT") ?? string.Empty;

    public static string Modelo =>
        Environment.GetEnvironmentVariable("OLLAMA_MODEL") is { Length: > 0 } m ? m : new OpcionesDeIA().Modelo;

    public static void ExigirServidor()
    {
        if (string.IsNullOrWhiteSpace(Endpoint)) Assert.Inconclusive("ConModelo: no medido (falta OLLAMA_ENDPOINT).");
    }

    public static Registrador NuevoClienteDelServidor()
    {
        var http = new HttpClient { BaseAddress = new Uri(Endpoint), Timeout = TimeSpan.FromSeconds(600) };
        return new Registrador(new OllamaApiClient(http, Modelo));
    }

    public static Dictionary<string, string?> Configuracion(int semilla) => new()
    {
        ["AI:Modelo"] = Modelo,
        ["AI:Muestreo:Semilla"] = semilla.ToString(System.Globalization.CultureInfo.InvariantCulture)
    };

    private static string Sha256(string archivo) =>
        File.Exists(archivo) ? Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(archivo))) : "(falta)";

    /// <summary>Abre la salida de una prueba y escribe la cabecera R-LLM.</summary>
    public static async Task<Salida> AbrirAsync(string prueba, string estimando, int pedidos, int semillas, string entrada)
    {
        var carpeta = Environment.GetEnvironmentVariable("CONMODELO_SALIDA") is { Length: > 0 } c
            ? c : Path.Combine(TestContext.CurrentContext.WorkDirectory, "resultados-conmodelo");
        Directory.CreateDirectory(carpeta);
        using var http = new HttpClient { BaseAddress = new Uri(Endpoint), Timeout = TimeSpan.FromSeconds(30) };
        var version = await http.GetFromJsonAsync<JsonObject>("api/version");
        var tags = await http.GetFromJsonAsync<JsonObject>("api/tags");
        var digest = tags?["models"]?.AsArray().FirstOrDefault(m => (string?)m?["name"] == Modelo)?["digest"]?.ToString() ?? "(no listado)";
        var o = new OpcionesDeIA();
        var directorio = TestContext.CurrentContext.TestDirectory;
        var cabecera = new
        {
            tipo = "cabecera-r-llm",
            fecha = DateTimeOffset.Now.ToString("o"),
            prueba,
            estimando,
            pedidos,
            semillas = $"s = 1..{semillas}",
            modelo = $"{Modelo}@{digest}",
            servidor = $"Ollama {version?["version"]}",
            estacion = Environment.GetEnvironmentVariable("ESTACION_ROTULO") ?? "(sin rótulo)",
            ruta = "OllamaSharp 5.5.0 → /api/chat",
            parametros = new { temperatura = o.Muestreo.Temperatura, top_p = o.Muestreo.TopP, top_k = o.Muestreo.TopK, presence_penalty = o.Muestreo.PresencePenalty, num_ctx = o.NumCtx, num_predict = o.MaximoDeTokensDeSalida, think = false },
            entrada,
            criterio_previo = $"ConModelo/CRITERIO.md sha256 {Sha256(Path.Combine(directorio, "ConModelo", "CRITERIO.md"))}",
            oro = $"ConModelo/oro-ayuda.json sha256 {Sha256(Path.Combine(directorio, "ConModelo", "oro-ayuda.json"))}"
        };
        var salida = new Salida(Path.Combine(carpeta, $"{prueba}-{DateTime.Now:yyyyMMdd-HHmmss}.jsonl"));
        salida.Escribir(cabecera);
        return salida;
    }

    public sealed class Salida(string archivo)
    {
        public string Archivo { get; } = archivo;

        public void Escribir(object linea)
        {
            var json = JsonSerializer.Serialize(linea, new JsonSerializerOptions { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
            File.AppendAllText(Archivo, json + Environment.NewLine);
            TestContext.Out.WriteLine(json);
        }
    }

    /// <summary>Intervalo de Wilson al 95 % (nunca el normal).</summary>
    public static (double Inferior, double Superior) Wilson(int k, int n)
    {
        if (n == 0) return (0, 1);
        const double z = 1.959963984540054;
        double p = (double)k / n, z2 = z * z, d = 1 + z2 / n;
        double centro = (p + z2 / (2 * n)) / d;
        double margen = z * Math.Sqrt(p * (1 - p) / n + z2 / (4.0 * n * n)) / d;
        return (Math.Max(0, centro - margen), Math.Min(1, centro + margen));
    }

    public static string Tasa(int k, int n, string estimando)
    {
        var (a, b) = Wilson(k, n);
        return string.Create(System.Globalization.CultureInfo.GetCultureInfo("es-AR"), $"{k}/{n} — estimando: {estimando}; Wilson 95 % [{a:0.00}; {b:0.00}]");
    }
}
