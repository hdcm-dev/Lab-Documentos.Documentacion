using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MovilidadUrbana.Busqueda.Configuracion;
using OllamaSharp;

namespace MovilidadUrbana.Busqueda.Tests.ConModelo;

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
        builder.AgregarBusquedaDeRequisitos(v => v == "OLLAMA_ENDPOINT" ? endpoint : Environment.GetEnvironmentVariable(v));
        return builder.Build();
    }

    /// <summary>Versión del servidor y digest del modelo, para la cabecera R-LLM.</summary>
    public static async Task<(string Version, string Digest)> Identificar(string modelo)
    {
        using var http = new HttpClient { BaseAddress = new Uri(Endpoint), Timeout = TimeSpan.FromMinutes(2) };
        var cliente = new OllamaApiClient(http);
        var version = await cliente.GetVersionAsync();
        var digest = (await cliente.ListLocalModelsAsync()).FirstOrDefault(m => m.Name == modelo)?.Digest ?? "(no está en el servidor)";
        return (version, digest.Length > 12 ? digest[..12] : digest);
    }
}

/// <summary>Registro R-LLM de una prueba contra el modelo (cabecera R-LLM + filas crudas).</summary>
public sealed class RegistroRllm(string nombre)
{
    private readonly StringBuilder _texto = new();

    public void Linea(string linea = "")
    {
        _texto.AppendLine(linea);
        TestContext.Out.WriteLine(linea);
    }

    public void Guardar()
    {
        var carpeta = Environment.GetEnvironmentVariable("RLLM_SALIDA") is { Length: > 0 } c
            ? c
            : Path.Combine(AppContext.BaseDirectory, "salidas-con-modelo");
        Directory.CreateDirectory(carpeta);
        File.WriteAllText(Path.Combine(carpeta, nombre + ".txt"), _texto.ToString());
    }
}
