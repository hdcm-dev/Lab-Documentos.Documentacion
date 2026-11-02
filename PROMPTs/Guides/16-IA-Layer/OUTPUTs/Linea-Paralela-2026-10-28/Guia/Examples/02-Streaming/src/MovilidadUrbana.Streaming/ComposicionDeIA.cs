using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using OllamaSharp;

namespace MovilidadUrbana.Streaming;

public static class ComposicionDeIA
{
    public const string NombreDelHttpClient = "ollama";

    /// <summary>Opciones validadas al arrancar, HttpClient de la fábrica e IChatClient Singleton por OllamaSharp.</summary>
    public static IHostApplicationBuilder AgregarIA(this IHostApplicationBuilder builder)
    {
        // Las tres variables externas pisan la sección AI sólo si están definidas.
        var mapa = new Dictionary<string, string?>();
        void Mapear(string variable, string clave)
        {
            var valor = Environment.GetEnvironmentVariable(variable);
            if (!string.IsNullOrWhiteSpace(valor)) mapa[clave] = valor;
        }
        Mapear("OLLAMA_ENDPOINT", "AI:Endpoint");
        Mapear("OLLAMA_MODEL", "AI:Modelo");
        Mapear("OLLAMA_EMBEDDING_MODEL", "AI:ModeloDeEmbeddings");
        builder.Configuration.AddInMemoryCollection(mapa);

        builder.Services.AddOptions<OpcionesDeIA>()
            .Bind(builder.Configuration.GetSection(OpcionesDeIA.Seccion))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        builder.Services.AddHttpClient(NombreDelHttpClient, (sp, http) =>
        {
            var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            http.BaseAddress = new Uri(ia.Endpoint);
            http.Timeout = TimeSpan.FromSeconds(ia.TimeoutSegundos);
        });

        builder.Services.AddChatClient(sp =>
        {
            var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            var http = sp.GetRequiredService<IHttpClientFactory>().CreateClient(NombreDelHttpClient);
            return new OllamaApiClient(http, ia.Modelo);
        });

        builder.Services.AddSingleton<AsistenteDeLaEncuesta>();
        return builder;
    }
}
