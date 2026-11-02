using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Application.Asistente;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI.Aprobaciones;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.Persistence;
using OllamaSharp;

namespace MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI;

/// <summary>Composición: el único lugar que conoce al proveedor y arma el bucle de herramientas.</summary>
public static class ComposicionDeIA
{
    public const string NombreDelHttpClient = "servidor-de-modelos";

    /// <summary>Casos de uso del caso base y persistencia en memoria, por ámbito (una sesión por ámbito).</summary>
    public static IServiceCollection AgregarAplicacion(this IServiceCollection services)
    {
        services.AddSingleton<AlmacenEnMemoria>();
        services.AddScoped<SessionContext>();
        services.AddScoped<ISessionContext>(sp => sp.GetRequiredService<SessionContext>());
        services.AddScoped<ILocalidadRepository, LocalidadRepositoryEnMemoria>();
        services.AddScoped<LocalidadService>();
        return services;
    }

    /// <param name="leerVariable">Lector de variables de entorno; las pruebas pasan uno propio.</param>
    /// <param name="clienteInterno">Reemplaza al cliente del proveedor (modo sin modelo y pruebas).</param>
    public static IHostApplicationBuilder AgregarCapaDeIA(
        this IHostApplicationBuilder builder, Func<string, string?>? leerVariable = null,
        Func<IServiceProvider, IChatClient>? clienteInterno = null)
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
        builder.Services.AddSingleton(TimeProvider.System);

        builder.Services.AddHttpClient(NombreDelHttpClient, (sp, http) =>
        {
            var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            http.BaseAddress = new Uri(ia.Endpoint);
            http.Timeout = TimeSpan.FromSeconds(ia.TimeoutSegundos);
        });

        // Un solo IChatClient para la llamada única y para el agente, con el bucle acotado (CTRL-05).
        builder.Services.AddChatClient(clienteInterno ?? CrearClienteDelProveedor)
            .Use((interno, sp) =>
            {
                var limites = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value.Herramientas;
                return new FunctionInvokingChatClient(interno, sp.GetService<ILoggerFactory>(), sp)
                {
                    MaximumIterationsPerRequest = limites.MaximoDeIteraciones,
                    MaximumConsecutiveErrorsPerRequest = limites.MaximoDeErroresConsecutivos,
                };
            });

        // Almacenes del servidor (A1): nunca salen ni entran por la API.
        builder.Services.AddSingleton<AlmacenDeAprobaciones>();
        builder.Services.AddSingleton<AlmacenDeConversaciones>();

        // Herramientas por petición (T1): se arman con los servicios de ESTA sesión.
        builder.Services.AddScoped<AutorizacionDeEscritura>();
        builder.Services.AddScoped<HerramientasDeLocalidades>();
        builder.Services.AddScoped<IAsistenteConAprobacion, AsistenteConAprobacion>();
        return builder;
    }

    public static IChatClient CrearClienteDelProveedor(IServiceProvider sp)
    {
        var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
        var http = sp.GetRequiredService<IHttpClientFactory>().CreateClient(NombreDelHttpClient);
        return new OllamaApiClient(http, ia.Modelo);
    }
}
