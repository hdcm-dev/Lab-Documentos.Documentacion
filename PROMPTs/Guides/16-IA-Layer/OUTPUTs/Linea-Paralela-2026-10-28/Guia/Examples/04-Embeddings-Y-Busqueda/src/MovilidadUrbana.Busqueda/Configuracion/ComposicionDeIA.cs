using Microsoft.Extensions.AI;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Busqueda.Busqueda;
using MovilidadUrbana.Busqueda.Requisitos;
using MovilidadUrbana.Busqueda.SinModelo;
using OllamaSharp;

namespace MovilidadUrbana.Busqueda.Configuracion;

/// <summary>Composición de la capa de IA: el único lugar que conoce al proveedor de embeddings.</summary>
public static class ComposicionDeIA
{
    public const string NombreDelHttpClient = "servidor-de-modelos";
    public const string FuenteDeTelemetria = "MovilidadUrbana.AI";

    /// <param name="leerVariable">Lector de variables de entorno; las pruebas pasan uno propio.</param>
    /// <param name="generadorBase">Generador que reemplaza al del servidor (las pruebas pasan un doble).</param>
    public static IHostApplicationBuilder AgregarBusquedaDeRequisitos(
        this IHostApplicationBuilder builder,
        Func<string, string?>? leerVariable = null,
        Func<IServiceProvider, IEmbeddingGenerator<string, Embedding<float>>>? generadorBase = null)
    {
        leerVariable ??= Environment.GetEnvironmentVariable;

        // Las variables externas pisan la sección AI, sólo si están definidas.
        var mapa = new Dictionary<string, string?>();
        void Mapear(string variable, string clave)
        {
            var valor = leerVariable(variable);
            if (!string.IsNullOrWhiteSpace(valor)) mapa[clave] = valor;
        }
        Mapear("OLLAMA_ENDPOINT", "AI:Endpoint");
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

        generadorBase ??= sp =>
        {
            var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            return ia.Modo == Modos.SinModelo
                ? new GeneradorLexicoFalso(ia.DimensionDeEmbeddings ?? 1024)
                : new OllamaApiClient(sp.GetRequiredService<IHttpClientFactory>().CreateClient(NombreDelHttpClient), ia.ModeloDeEmbeddings);
        };

        builder.Services.AddSingleton<IDistributedCache>(_ =>
            new MemoryDistributedCache(Options.Create(new MemoryDistributedCacheOptions())));

        // El primero que se agrega es el más externo: telemetría → caché → verificador de dimensión → proveedor.
        builder.Services.AddSingleton(sp =>
        {
            var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            var modelo = ia.Modo == Modos.SinModelo ? GeneradorLexicoFalso.Nombre : ia.ModeloDeEmbeddings;
            return new EmbeddingGeneratorBuilder<string, Embedding<float>>(generadorBase(sp))
                .UseOpenTelemetry(sourceName: FuenteDeTelemetria)
                .UseDistributedCache(sp.GetRequiredService<IDistributedCache>())
                .Use(interno => new VerificadorDeDimension(interno, modelo, ia.DimensionDeEmbeddings))
                .Build(sp);
        });

        builder.Services.AddSingleton<CatalogoDeRequisitos>();
        builder.Services.AddSingleton<AlmacenDeRequisitos>();
        builder.Services.AddHostedService<ArranqueDelAlmacen>();
        return builder;
    }
}
