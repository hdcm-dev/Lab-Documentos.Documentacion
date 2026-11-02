using System.Text;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.AI;
using NUnit.Framework;
using OllamaSharp;

namespace MovilidadUrbana.Ejemplos.Orquestacion.Tests.ConModelo;

/// <summary>
/// Acceso al servidor Ollama de prueba, sólo por OLLAMA_ENDPOINT. Sin la variable, la prueba queda
/// Inconclusive («ConModelo: no medido»): nunca se saltea en verde.
/// </summary>
public static class ServidorDePrueba
{
    public static string Endpoint =>
        Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT") is { Length: > 0 } e
            ? e
            : throw new InconclusiveException("ConModelo: no medido (falta OLLAMA_ENDPOINT).");

    /// <summary>Rótulo de la estación que va en la cabecera R-LLM (lo pasa quien corre la prueba).</summary>
    public static string Estacion =>
        Environment.GetEnvironmentVariable("ESTACION") is { Length: > 0 } e ? e : "estación sin rotular";

    public static int Semillas =>
        int.TryParse(Environment.GetEnvironmentVariable("CONMODELO_M"), out var m)
            ? m
            : int.Parse(new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.ConModelo.json").Build()["PruebasConModelo:Semillas"]!);

    /// <summary>Anfitrión con la composición real y los appsettings del ejemplo; el cliente del servidor envuelto en un contador.</summary>
    public static (IHost Host, IServiceScope Ambito, ContadorDeLlamadas Contador) Anfitrion(int semilla)
    {
        var endpoint = Endpoint;
        var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings { DisableDefaults = true, ContentRootPath = AppContext.BaseDirectory });
        builder.Configuration
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json")
            .AddInMemoryCollection(new Dictionary<string, string?> { ["AI:Muestreo:Semilla"] = semilla.ToString() });
        ContadorDeLlamadas? contador = null;
        builder.AgregarCapaDeIA(v => v == "OLLAMA_ENDPOINT" ? endpoint : null, sp =>
        {
            var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            var http = sp.GetRequiredService<IHttpClientFactory>().CreateClient(ComposicionDeIA.NombreDelHttpClient);
            return contador = new ContadorDeLlamadas(new OllamaApiClient(http, ia.Modelo));
        });
        var host = builder.Build();
        host.Start();
        _ = host.Services.GetRequiredService<IChatClient>();   // fuerza la creación del contador
        var ambito = host.Services.CreateScope();
        ambito.ServiceProvider.GetRequiredService<SessionContext>().Set($"sesion-s{semilla}");
        return (host, ambito, contador!);
    }

    /// <summary>Versión del servidor y digest del modelo, para la cabecera R-LLM.</summary>
    public static async Task<(string Version, string Digest)> Identificar(OpcionesDeIA ia)
    {
        using var http = new HttpClient { BaseAddress = new Uri(Endpoint), Timeout = TimeSpan.FromSeconds(ia.TimeoutSegundos) };
        var cliente = new OllamaApiClient(http);
        var version = await cliente.GetVersionAsync();
        var digest = (await cliente.ListLocalModelsAsync()).FirstOrDefault(m => m.Name == ia.Modelo)?.Digest ?? "(no está en el servidor)";
        return (version, digest.Length > 12 ? digest[..12] : digest);
    }

    public static string Cabecera(OpcionesDeIA ia, string version, string digest, string estimando) =>
        $"# R-LLM — estimando: {estimando}, semillas s = 1..{Semillas}, {ia.Modelo}@{digest}, T {ia.Muestreo.Temperatura}, top_p {ia.Muestreo.TopP}, " +
        $"top_k {ia.Muestreo.TopK}, presence {ia.Muestreo.PenalizacionPorPresencia}, think {(ia.Muestreo.ApagarRazonamiento ? "false" : "default")}, " +
        $"num_ctx {ia.NumCtx}, ruta API /api/chat (OllamaSharp 5.5.0), Ollama {version}, criterio previo: el comentario de ConModelo/WorkflowConModeloTests.cs, fecha {DateTimeOffset.Now:O}";
}

/// <summary>Cuenta las llamadas al modelo, con qué instrucciones y si se ofrecieron herramientas.</summary>
public sealed class ContadorDeLlamadas(IChatClient interno) : DelegatingChatClient(interno)
{
    private readonly List<(string? Instrucciones, bool Herramientas)> _llamadas = [];
    public IReadOnlyList<(string? Instrucciones, bool Herramientas)> Llamadas { get { lock (_llamadas) return _llamadas.ToList(); } }

    public override Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
    {
        lock (_llamadas) _llamadas.Add((options?.Instructions, options?.Tools is { Count: > 0 }));
        return base.GetResponseAsync(messages, options, cancellationToken);
    }

    public override IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
    {
        lock (_llamadas) _llamadas.Add((options?.Instructions, options?.Tools is { Count: > 0 }));
        return base.GetStreamingResponseAsync(messages, options, cancellationToken);
    }
}

/// <summary>Registro R-LLM de una prueba contra el modelo (cabecera R-LLM + filas crudas).</summary>
public sealed class RegistroRllm(string nombre)
{
    private readonly StringBuilder _texto = new();

    public void Linea(string linea)
    {
        _texto.AppendLine(linea);
        TestContext.Out.WriteLine(linea);
    }

    public void Guardar()
    {
        var carpeta = Environment.GetEnvironmentVariable("RLLM_SALIDA") is { Length: > 0 } c ? c : Path.Combine(AppContext.BaseDirectory, "salidas-con-modelo");
        Directory.CreateDirectory(carpeta);
        File.WriteAllText(Path.Combine(carpeta, nombre + ".txt"), _texto.ToString());
    }

    /// <summary>Intervalo de Wilson al 95 %.</summary>
    public static string Fraccion(int k, int n)
    {
        const double z = 1.959964;
        double p = (double)k / n, d = 1 + z * z / n;
        double centro = (p + z * z / (2 * n)) / d;
        double margen = z * Math.Sqrt(p * (1 - p) / n + z * z / (4.0 * n * n)) / d;
        return $"{k}/{n}; Wilson 95 % [{Math.Max(0, centro - margen):0.00}; {Math.Min(1, centro + margen):0.00}]";
    }
}
