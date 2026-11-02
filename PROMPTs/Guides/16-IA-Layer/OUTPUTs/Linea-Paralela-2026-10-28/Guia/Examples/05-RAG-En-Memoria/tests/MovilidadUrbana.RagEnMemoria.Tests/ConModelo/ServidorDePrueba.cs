using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.RagEnMemoria.Infrastructure.AI;
using NUnit.Framework;
using OllamaSharp;

namespace MovilidadUrbana.RagEnMemoria.Tests.ConModelo;

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

    public static IConfiguration Pruebas { get; } = new ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory)
        .AddJsonFile("appsettings.ConModelo.json")
        .Build()
        .GetSection("PruebasConModelo");

    /// <summary>Anfitrión con la composición real y los appsettings del ejemplo, más los cambios de la prueba.</summary>
    public static IHost Anfitrion(Dictionary<string, string?>? cambios = null)
    {
        var endpoint = Endpoint;
        var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
        {
            DisableDefaults = true,
            ContentRootPath = AppContext.BaseDirectory,
        });
        builder.Configuration
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json")
            .AddInMemoryCollection(cambios ?? []);
        builder.AgregarCapaDeIA(v => v == "OLLAMA_ENDPOINT" ? endpoint : null);
        return builder.Build();
    }

    /// <summary>Versión del servidor y digest (12) de cada modelo, para la cabecera R-LLM.</summary>
    public static async Task<(string Version, Func<string, string> Digest)> Identificar(IHost host)
    {
        var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
        using var http = new HttpClient { BaseAddress = new Uri(Endpoint), Timeout = TimeSpan.FromSeconds(ia.TimeoutSegundos) };
        var cliente = new OllamaApiClient(http);
        var version = await cliente.GetVersionAsync();
        var modelos = (await cliente.ListLocalModelsAsync()).ToList();
        return (version, nombre =>
        {
            var d = modelos.FirstOrDefault(m => m.Name == nombre)?.Digest ?? "(no está en el servidor)";
            return d.Length > 12 ? d[..12] : d;
        });
    }

    /// <summary>Rótulo de la estación. Lo pone quien corre la prueba; si falta, se dice.</summary>
    public static string Estacion =>
        Environment.GetEnvironmentVariable("RLLM_ESTACION") is { Length: > 0 } e ? e : "(estación sin rotular)";
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
        Archivo = Path.GetFileName(_archivo);
    }

    public string Archivo { get; }

    public void Linea(string linea)
    {
        _texto.AppendLine(linea);
        TestContext.Out.WriteLine(linea);
        File.WriteAllText(_archivo, _texto.ToString());   // se guarda a cada línea: un corte deja lo medido
    }
}
