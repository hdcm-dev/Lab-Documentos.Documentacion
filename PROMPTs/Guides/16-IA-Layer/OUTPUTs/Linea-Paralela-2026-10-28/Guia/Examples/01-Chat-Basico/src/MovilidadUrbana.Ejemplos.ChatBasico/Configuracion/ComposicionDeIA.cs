using System.ClientModel;
using System.ClientModel.Primitives;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.ChatBasico.Conversacion;
using OllamaSharp;
using OpenAI;

namespace MovilidadUrbana.Ejemplos.ChatBasico.Configuracion;

/// <summary>Composición de la capa de IA: el único lugar que conoce al proveedor.</summary>
public static class ComposicionDeIA
{
    public const string NombreDelHttpClient = "servidor-de-modelos";

    /// <param name="leerVariable">Lector de variables de entorno; las pruebas pasan uno propio.</param>
    public static IHostApplicationBuilder AgregarCapaDeIA(
        this IHostApplicationBuilder builder, Func<string, string?>? leerVariable = null)
    {
        leerVariable ??= Environment.GetEnvironmentVariable;

        // Las tres variables externas pisan la sección AI, sólo si están definidas.
        var mapa = new Dictionary<string, string?>();
        void Mapear(string variable, string clave)
        {
            var valor = leerVariable(variable);
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

        // Credenciales y encabezados: en el HttpClient de IHttpClientFactory, por un DelegatingHandler.
        builder.Services.AddTransient<ManejadorDeCredenciales>();
        builder.Services.AddHttpClient(NombreDelHttpClient, (sp, http) =>
            {
                var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
                http.BaseAddress = new Uri(ia.Endpoint);
                http.Timeout = TimeSpan.FromSeconds(ia.TimeoutSegundos);
            })
            .AddHttpMessageHandler<ManejadorDeCredenciales>();

        builder.Services.AddSingleton<IChatClient>(sp =>
        {
            var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            var http = sp.GetRequiredService<IHttpClientFactory>().CreateClient(NombreDelHttpClient);
            return ia.Proveedor switch
            {
                // Vía nativa: num_ctx por pedido, TopK, think.
                Proveedores.Ollama => new OllamaApiClient(http, ia.Modelo),

                // Vía /v1: num_ctx NO se puede fijar por pedido; TopK se descarta; MaxOutputTokens no acota.
                Proveedores.OpenAICompatible => new OpenAIClient(
                        new ApiKeyCredential(ia.Credencial ?? "sin-credencial"), // el SDK exige una; Ollama local la ignora
                        new OpenAIClientOptions
                        {
                            Endpoint = new Uri($"{ia.Endpoint.TrimEnd('/')}/v1"),
                            Transport = new HttpClientPipelineTransport(http),
                            NetworkTimeout = TimeSpan.FromSeconds(ia.TimeoutSegundos),
                        })
                    .GetChatClient(ia.Modelo)
                    .AsIChatClient(),

                _ => throw new InvalidOperationException($"AI:Proveedor desconocido: {ia.Proveedor}"),
            };
        });

        builder.Services.AddTransient<AsistenteDeMovilidad>();
        return builder;
    }
}
