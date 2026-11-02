using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.RagEnMemoria.Application.Ayuda;
using MovilidadUrbana.RagEnMemoria.Infrastructure.AI;
using MovilidadUrbana.RagEnMemoria.Infrastructure.Persistence;
using OllamaSharp;

namespace MovilidadUrbana.RagEnMemoria;

/// <summary>Composición de la capa de IA: el único lugar que conoce al proveedor y al almacén.</summary>
public static class ComposicionDeIA
{
    public const string NombreDelHttpClient = "servidor-de-modelos";

    /// <summary>Estrategias de <see cref="IAyuda"/>, registradas como servicios con clave.</summary>
    public static class Estrategias
    {
        public const string ContextoFijo = "contexto-fijo";
        public const string Rag = "rag";                         // vía A
        public const string RagConHerramienta = "rag-herramienta"; // vía B
        public const string RagEnAgente = "rag-agente";          // vía C
        public static readonly string[] Todas = [ContextoFijo, Rag, RagConHerramienta, RagEnAgente];
    }

    /// <param name="leerVariable">Lector de variables de entorno; las pruebas pasan uno propio.</param>
    public static IHostApplicationBuilder AgregarCapaDeIA(
        this IHostApplicationBuilder builder, Func<string, string?>? leerVariable = null)
    {
        leerVariable ??= Environment.GetEnvironmentVariable;
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

        builder.Services.AddHttpClient(NombreDelHttpClient, (sp, http) =>
        {
            var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            http.BaseAddress = new Uri(ia.Endpoint);
            http.Timeout = TimeSpan.FromSeconds(ia.TimeoutSegundos);
        });

        builder.Services.AddSingleton<IChatClient>(sp =>
        {
            var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            return new OllamaApiClient(sp.GetRequiredService<IHttpClientFactory>().CreateClient(NombreDelHttpClient), ia.Modelo);
        });
        builder.Services.AddSingleton<IEmbeddingGenerator<string, Embedding<float>>>(sp =>
        {
            var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            return new OllamaApiClient(sp.GetRequiredService<IHttpClientFactory>().CreateClient(NombreDelHttpClient), ia.ModeloDeEmbeddings);
        });

        return builder.AgregarAyuda();
    }

    /// <summary>Lo que no depende del proveedor: almacén, buscador y las cuatro estrategias.</summary>
    public static IHostApplicationBuilder AgregarAyuda(this IHostApplicationBuilder builder)
    {
        builder.Services.AddSingleton<FabricaDeOpcionesDeChat>();
        builder.Services.AddSingleton<AlmacenDeRequisitos>();
        builder.Services.AddSingleton<IBuscadorDeRequisitos>(sp => sp.GetRequiredService<AlmacenDeRequisitos>());
        builder.Services.AddHostedService<InicioDelAlmacen>();
        builder.Services.AddKeyedTransient<IAyuda, AyudaContextoFijo>(Estrategias.ContextoFijo);
        builder.Services.AddKeyedTransient<IAyuda, AyudaRag>(Estrategias.Rag);
        builder.Services.AddKeyedTransient<IAyuda, AyudaRagConHerramienta>(Estrategias.RagConHerramienta);
        builder.Services.AddKeyedTransient<IAyuda, AyudaRagEnAgente>(Estrategias.RagEnAgente);
        return builder;
    }
}
