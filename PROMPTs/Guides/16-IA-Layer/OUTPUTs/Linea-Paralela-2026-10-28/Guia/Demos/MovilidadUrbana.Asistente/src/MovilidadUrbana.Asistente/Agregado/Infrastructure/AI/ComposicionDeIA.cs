using Microsoft.Extensions.AI;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.Asistente.Application.Abstractions;
using MovilidadUrbana.Asistente.Infrastructure.Persistence;
using OllamaSharp;

namespace MovilidadUrbana.Asistente.Infrastructure.AI;

/// <summary>
/// Compone la capa de IA. El cliente del servidor de modelo (OllamaSharp) es Singleton y usa un HttpClient de
/// IHttpClientFactory con el timeout de <see cref="OpcionesDeIA"/>. La cadena que ven los adaptadores es
/// Scoped, así cada pedido (o cada circuito de la página) resuelve las herramientas con su propia sesión:
///
///   [caché, sólo si AI:Cache:Habilitada] → UseFunctionInvocation → UseOpenTelemetry → cliente
///
/// El límite de concurrencia no está en esta cadena: va en la entrada (ver LimitadorDelModelo).
/// </summary>
public static class ComposicionDeIA
{
    /// <summary>Clave del cliente del servidor de modelo; las pruebas la reemplazan por un cliente falso.</summary>
    public const string ClaveDelClienteDelServidor = "cliente-del-servidor-de-modelo";

    public const string ClienteHttpDelModelo = "servidor-ollama";

    /// <summary>Mapea las variables de entorno externas a la sección AI, sólo si están definidas.</summary>
    public static void MapearVariablesDeEntorno(IConfigurationManager configuracion)
    {
        var mapa = new Dictionary<string, string?>();
        void Mapear(string variable, string clave)
        {
            var valor = Environment.GetEnvironmentVariable(variable);
            if (!string.IsNullOrWhiteSpace(valor)) mapa[clave] = valor;
        }
        Mapear("OLLAMA_ENDPOINT", $"{OpcionesDeIA.Seccion}:{nameof(OpcionesDeIA.Endpoint)}");
        Mapear("OLLAMA_MODEL", $"{OpcionesDeIA.Seccion}:{nameof(OpcionesDeIA.Modelo)}");
        configuracion.AddInMemoryCollection(mapa);
    }

    public static IServiceCollection AddCapaDeIA(this IServiceCollection services, IConfiguration configuracion, IHostEnvironment entorno)
    {
        services.AddOptions<OpcionesDeIA>()
            .Bind(configuracion.GetSection(OpcionesDeIA.Seccion))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddHttpClient(ClienteHttpDelModelo, (sp, http) =>
        {
            var o = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            http.BaseAddress = new Uri(o.Endpoint);
            http.Timeout = TimeSpan.FromSeconds(o.TimeoutSegundos);
        });

        services.AddKeyedSingleton<IChatClient>(ClaveDelClienteDelServidor, (sp, _) =>
        {
            var o = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            var http = sp.GetRequiredService<IHttpClientFactory>().CreateClient(ClienteHttpDelModelo);
            return new OllamaApiClient(http, o.Modelo);
        });

        services.AgregarCadenaDeChat(ServiceLifetime.Scoped, habilitarDatosSensibles: entorno.IsDevelopment());

        services.AddDistributedMemoryCache();
        services.AddSingleton(TimeProvider.System);
        services.AddSingleton<IHistorialDeConversacion, HistorialEnMemoria>();
        services.AddSingleton<FabricaDeOpcionesDeChat>();
        services.AddScoped<IClasificadorDePedido, ClasificadorDePedidoLlm>();
        services.AddScoped<ExtractoresLlm>();
        services.AddScoped<IExtractorDeLocalidad>(sp => sp.GetRequiredService<ExtractoresLlm>());
        services.AddScoped<IExtractorDeEncuesta>(sp => sp.GetRequiredService<ExtractoresLlm>());
        services.AddScoped<IExtractorDeBaja>(sp => sp.GetRequiredService<ExtractoresLlm>());
        services.AddScoped<IAyuda, AyudaContextoFijo>();
        services.AddScoped<IConsultaConHerramientas, ConsultaConHerramientasLlm>();
        services.AddScoped<ILecturaDeResultados, LecturaDeResultadosEf>();
        return services;
    }

    /// <summary>
    /// La cadena del IChatClient. El ciclo de vida es parámetro sólo para que las pruebas muestren qué pasa
    /// con Singleton; la aplicación usa Scoped.
    /// </summary>
    public static ChatClientBuilder AgregarCadenaDeChat(this IServiceCollection services, ServiceLifetime cicloDeVida, bool habilitarDatosSensibles) =>
        services.AddChatClient(sp => sp.GetRequiredKeyedService<IChatClient>(ClaveDelClienteDelServidor), cicloDeVida)
            .Use((interno, sp) =>
            {
                var o = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
                if (!o.Cache.Habilitada) return interno;
                return new CacheConContador(interno, sp.GetRequiredService<IDistributedCache>())
                {
                    CacheKeyAdditionalValues = [sp.GetRequiredService<ISessionContext>().Id]
                };
            })
            .Use((interno, sp) =>
            {
                var o = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
                return new FunctionInvokingChatClient(interno, sp.GetService<ILoggerFactory>(), sp)
                {
                    MaximumIterationsPerRequest = o.Herramientas.MaximoDeIteraciones,
                    MaximumConsecutiveErrorsPerRequest = o.Herramientas.MaximoDeErroresConsecutivos,
                    IncludeDetailedErrors = false
                };
            })
            .UseOpenTelemetry(sourceName: TelemetriaDeIA.Fuente, configure: c => c.EnableSensitiveData = habilitarDatosSensibles);
}
