using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.Mcp.Cliente.Infrastructure.AI;
using NUnit.Framework;
using OllamaSharp;

namespace MovilidadUrbana.Ejemplos.Mcp.Tests.ConModelo;

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

    public static IConfiguration Pruebas { get; } = new ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory)
        .AddJsonFile("appsettings.ConModelo.json")
        .Build()
        .GetSection("PruebasConModelo");

    public static int Semillas =>
        int.TryParse(Environment.GetEnvironmentVariable("CONMODELO_M"), out var m) ? m : int.Parse(Pruebas["Semillas"]!);

    /// <summary>Anfitrión con la composición real y los appsettings del ejemplo, más los cambios de la prueba.</summary>
    public static IHost Anfitrion(Dictionary<string, string?> cambios)
    {
        var endpoint = Endpoint;
        var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
        {
            DisableDefaults = true,
            EnvironmentName = "Development",
            ContentRootPath = AppContext.BaseDirectory,
        });
        builder.Configuration
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json")
            .AddInMemoryCollection(cambios);
        builder.AgregarCapaDeIA(v => v == "OLLAMA_ENDPOINT" ? endpoint : null);
        var host = builder.Build();
        host.Start();
        return host;
    }

    /// <summary>Versión del servidor y digest del modelo, para la cabecera R-LLM.</summary>
    public static async Task<(string Version, string Digest)> Identificar(IHost host)
    {
        var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
        using var http = new HttpClient { BaseAddress = new Uri(Endpoint), Timeout = TimeSpan.FromSeconds(ia.TimeoutSegundos) };
        var cliente = new OllamaApiClient(http);
        var version = await cliente.GetVersionAsync();
        var digest = (await cliente.ListLocalModelsAsync()).FirstOrDefault(m => m.Name == ia.Modelo)?.Digest ?? "(no está en el servidor)";
        return (version, digest.Length > 12 ? digest[..12] : digest);
    }
}

/// <summary>Registro R-LLM de una prueba contra el modelo (cabecera R-LLM + filas crudas).</summary>
public sealed class RegistroRllm
{
    private readonly StringBuilder _texto = new();
    private readonly string _archivo;

    public RegistroRllm(string nombre)
    {
        var carpeta = Environment.GetEnvironmentVariable("RLLM_SALIDA") is { Length: > 0 } c
            ? c
            : Path.Combine(AppContext.BaseDirectory, "salidas-con-modelo");
        Directory.CreateDirectory(carpeta);
        _archivo = Path.Combine(carpeta, nombre + ".txt");
    }

    public void Linea(string linea)
    {
        _texto.AppendLine(linea);
        TestContext.Out.WriteLine(linea);
    }

    public void Guardar() => File.WriteAllText(_archivo, _texto.ToString());

    /// <summary>Intervalo de Wilson al 95 %.</summary>
    public static (double A, double B) Wilson(int k, int n)
    {
        const double z = 1.959964;
        double p = (double)k / n, d = 1 + z * z / n;
        double centro = (p + z * z / (2 * n)) / d;
        double margen = z * Math.Sqrt(p * (1 - p) / n + z * z / (4.0 * n * n)) / d;
        return (Math.Max(0, centro - margen), Math.Min(1, centro + margen));
    }

    public static string Fraccion(int k, int n)
    {
        var (a, b) = Wilson(k, n);
        return $"{k}/{n}; Wilson 95 % [{a:0.00}; {b:0.00}]";
    }
}
