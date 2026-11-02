using System.ClientModel;
using System.ClientModel.Primitives;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.ToolCalling.Application.Asistente;
using MovilidadUrbana.Ejemplos.ToolCalling.Application.Consultas;
using MovilidadUrbana.Ejemplos.ToolCalling.Infrastructure.Persistence;
using OllamaSharp;
using OpenAI;

namespace MovilidadUrbana.Ejemplos.ToolCalling.Infrastructure.AI;

/// <summary>Composición: el único lugar que conoce al proveedor. Application no cambia al cambiarlo.</summary>
public static class ComposicionDeIA
{
    public const string NombreDelHttpClient = "servidor-de-modelos";

    /// <summary>Casos de uso del núcleo y persistencia en memoria, por ámbito (una sesión por ámbito).</summary>
    public static IServiceCollection AgregarAplicacion(this IServiceCollection services)
    {
        services.AddSingleton<AlmacenEnMemoria>();
        services.AddScoped<SessionContext>();
        services.AddScoped<ISessionContext>(sp => sp.GetRequiredService<SessionContext>());
        services.AddScoped<ILocalidadRepository, LocalidadRepositoryEnMemoria>();
        services.AddScoped<LocalidadService>();
        services.AddScoped<ConsultaDeLocalidades>();
        return services;
    }

    /// <param name="leerVariable">Lector de variables de entorno; las pruebas pasan uno propio.</param>
    /// <param name="clienteInterno">
    /// Reemplaza al cliente del proveedor (modo sin modelo y pruebas). El bucle de herramientas y sus
    /// límites se componen igual encima.
    /// </param>
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

        builder.Services.AddTransient<ManejadorDeCredenciales>();
        builder.Services.AddHttpClient(NombreDelHttpClient, (sp, http) =>
            {
                var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
                http.BaseAddress = new Uri(ia.Endpoint);
                http.Timeout = TimeSpan.FromSeconds(ia.TimeoutSegundos);
            })
            .AddHttpMessageHandler<ManejadorDeCredenciales>();

        // Cliente de chat con el bucle de herramientas acotado por configuración (CTRL-05).
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

        builder.Services.AddScoped<HerramientasDeLocalidades>();
        builder.Services.AddScoped<IAsistenteDeLocalidades, AsistenteDeLocalidades>();
        return builder;
    }

    /// <summary>El selector <c>AI:Proveedor</c>: lo único que cambia entre las dos vías.</summary>
    public static IChatClient CrearClienteDelProveedor(IServiceProvider sp)
    {
        var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
        var http = sp.GetRequiredService<IHttpClientFactory>().CreateClient(NombreDelHttpClient);
        return ia.Proveedor switch
        {
            // Vía nativa: num_ctx por pedido, TopK, think.
            Proveedores.Ollama => new OllamaApiClient(http, ia.Modelo),

            // Vía /v1: num_ctx NO se puede fijar por pedido; TopK se descarta.
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
    }
}
