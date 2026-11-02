using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Application.Encuestas;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.Orquestacion.Application.Altas;
using MovilidadUrbana.Ejemplos.Orquestacion.Application.Encuesta;
using MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.Persistence;
using OllamaSharp;

namespace MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.AI;

/// <summary>Composición: el único lugar que arma el cliente del servidor de modelos.</summary>
public static class ComposicionDeIA
{
    public const string NombreDelHttpClient = "servidor-de-modelos";

    /// <param name="leerVariable">Lector de variables de entorno; las pruebas pasan uno propio.</param>
    /// <param name="clienteInterno">Reemplaza al cliente del servidor (modo sin modelo y pruebas).</param>
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

        // Núcleo y persistencia en memoria, por ámbito (una sesión por ámbito).
        builder.Services.AddSingleton<AlmacenEnMemoria>();
        builder.Services.AddScoped<SessionContext>();
        builder.Services.AddScoped<ISessionContext>(sp => sp.GetRequiredService<SessionContext>());
        builder.Services.AddScoped<ILocalidadRepository, LocalidadRepositoryEnMemoria>();
        builder.Services.AddScoped<IEncuestaRepository, EncuestaRepositoryEnMemoria>();
        builder.Services.AddScoped<LocalidadService>();
        builder.Services.AddScoped<EncuestaService>();
        builder.Services.AddScoped<EncuestaComoProceso>();

        builder.Services.AddHttpClient(NombreDelHttpClient, (sp, http) =>
        {
            var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            http.BaseAddress = new Uri(ia.Endpoint);
            http.Timeout = TimeSpan.FromSeconds(ia.TimeoutSegundos);
        });

        // Sin UseFunctionInvocation: ningún paso de este ejemplo ofrece herramientas al modelo.
        builder.Services.AddChatClient(clienteInterno ?? (sp =>
        {
            var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            var http = sp.GetRequiredService<IHttpClientFactory>().CreateClient(NombreDelHttpClient);
            return new OllamaApiClient(http, ia.Modelo);
        }));

        builder.Services.AddScoped<IExtractorDeAlta, ExtractorDeAltaLlm>();
        return builder;
    }
}
