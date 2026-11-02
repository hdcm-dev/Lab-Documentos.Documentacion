using Microsoft.Extensions.AI;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Abstractions;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Asistente;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Consultas;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Localidades;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.Persistence;
using OllamaSharp;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;

/// <summary>Composición de la capa de IA. Es el único lugar que conoce al proveedor.</summary>
public static class ComposicionDeIA
{
    public const string NombreDelHttpClient = "servidor-de-modelos";

    /// <summary>Clave del cliente del proveedor (Singleton). Las pruebas registran su cliente falso con esta clave.</summary>
    public const string ClaveDelProveedor = "proveedor";

    /// <summary>Casos de uso del núcleo y persistencia en memoria, por ámbito (una sesión por ámbito).</summary>
    public static IServiceCollection AgregarAplicacion(this IServiceCollection services)
    {
        services.AddSingleton<AlmacenEnMemoria>();
        services.AddSingleton<IVersionesDeDatos, VersionesDeDatosEnMemoria>();
        services.AddScoped<SessionContext>();
        services.AddScoped<ISessionContext>(sp => sp.GetRequiredService<SessionContext>());
        services.AddScoped<ILocalidadRepository, LocalidadRepositoryEnMemoria>();
        services.AddScoped<LocalidadService>();
        services.AddScoped<ConsultaDeLocalidades>();
        services.AddScoped<AltaDeLocalidad>();
        return services;
    }

    /// <param name="vidaDelPipeline">Scoped en la aplicación. Las pruebas del ciclo de vida pasan Singleton.</param>
    /// <param name="leerVariable">Lector de variables de entorno; las pruebas pasan uno propio.</param>
    public static IHostApplicationBuilder AgregarCapaDeIA(
        this IHostApplicationBuilder builder,
        ServiceLifetime vidaDelPipeline = ServiceLifetime.Scoped,
        Func<string, string?>? leerVariable = null)
    {
        leerVariable ??= Environment.GetEnvironmentVariable;

        // Las variables externas pisan la sección AI, sólo si están definidas.
        var mapa = new Dictionary<string, string?>();
        if (leerVariable("OLLAMA_ENDPOINT") is { Length: > 0 } endpoint) mapa["AI:Endpoint"] = endpoint;
        if (leerVariable("OLLAMA_MODEL") is { Length: > 0 } modelo) mapa["AI:Modelo"] = modelo;
        builder.Configuration.AddInMemoryCollection(mapa);

        builder.Services.AddOptions<OpcionesDeIA>()
            .Bind(builder.Configuration.GetSection(OpcionesDeIA.Seccion))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        builder.Services.AgregarAplicacion();
        builder.Services.AddDistributedMemoryCache();   // en producción, un IDistributedCache compartido

        // El cliente del proveedor es Singleton y usa el HttpClient de IHttpClientFactory, con el timeout de las opciones
        // y el handler que lee prompt_eval_cached_count. El detector de contexto truncado lo envuelve.
        builder.Services.AddTransient<LectorDePrefijoCacheado>();
        builder.Services.AddHttpClient(NombreDelHttpClient, (sp, http) =>
            {
                var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
                http.BaseAddress = new Uri(ia.Endpoint);
                http.Timeout = TimeSpan.FromSeconds(ia.TimeoutSegundos);
            })
            .AddHttpMessageHandler<LectorDePrefijoCacheado>();
        builder.Services.AddKeyedSingleton<IChatClient>(ClaveDelProveedor, (sp, _) =>
        {
            var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            var http = sp.GetRequiredService<IHttpClientFactory>().CreateClient(NombreDelHttpClient);
            return new DetectorDeContextoTruncado(new OllamaApiClient(http, ia.Modelo));
        });

        // El pipeline: caché → UseFunctionInvocation → UseOpenTelemetry → cliente. Scoped: cada pedido HTTP
        // tiene el suyo, con el SessionContext de su ámbito.
        bool esDesarrollo = builder.Environment.IsDevelopment();
        builder.Services.AddChatClient(sp => sp.GetRequiredKeyedService<IChatClient>(ClaveDelProveedor), vidaDelPipeline)
            .Use((interno, sp) => sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value.CacheDeRespuestas
                ? new CacheConContador(interno, sp.GetRequiredService<IDistributedCache>(), ValoresDeLaClave(sp))
                : interno)
            .Use((interno, sp) =>
            {
                var limites = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value.Herramientas;
                return new FunctionInvokingChatClient(interno, sp.GetService<ILoggerFactory>(), sp)
                {
                    MaximumIterationsPerRequest = limites.MaximoDeIteraciones,
                    MaximumConsecutiveErrorsPerRequest = limites.MaximoDeErroresConsecutivos,
                };
            })
            .UseOpenTelemetry(sourceName: TelemetriaDeIA.Fuente,
                configure: c => c.EnableSensitiveData = esDesarrollo);   // contenido sólo en Development

        builder.Services.AddScoped<IAsistente, Asistente>();
        return builder;
    }

    /// <summary>[SessionId, VersionDeDatos], leídos EN CADA PEDIDO (no al crear la caché).</summary>
    private static Func<object?[]> ValoresDeLaClave(IServiceProvider sp) => () =>
    {
        var sesion = sp.GetRequiredService<ISessionContext>().Id;
        return [sesion, sp.GetRequiredService<IVersionesDeDatos>().Leer(sesion)];
    };
}
