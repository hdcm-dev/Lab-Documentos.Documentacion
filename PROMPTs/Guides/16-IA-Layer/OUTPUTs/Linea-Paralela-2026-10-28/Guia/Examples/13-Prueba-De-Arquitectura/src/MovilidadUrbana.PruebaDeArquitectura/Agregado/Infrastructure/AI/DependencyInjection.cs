using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.PruebaDeArquitectura.Application.Propuestas;
using OllamaSharp;

namespace MovilidadUrbana.PruebaDeArquitectura.Infrastructure.AI;

/// <summary>
/// Registra el adaptador de IA. El proveedor (OllamaSharp) aparece sólo acá: cambiarlo no toca Application.
/// <c>OLLAMA_ENDPOINT</c>, si está, reemplaza a <c>AI:Endpoint</c>.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddAdaptadorDeIA(this IServiceCollection services, IConfiguration configuracion)
    {
        services.AddOptions<OpcionesDeIA>()
            .Bind(configuracion.GetSection(OpcionesDeIA.Seccion))
            .PostConfigure(o => o.Endpoint = Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT") is { Length: > 0 } e ? e : o.Endpoint)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddSingleton<IChatClient>(sp =>
        {
            var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            return new OllamaApiClient(new Uri(ia.Endpoint), ia.Modelo);
        });
        services.AddScoped<IExtractorDeLocalidad, ExtractorDeLocalidadLlm>();
        return services;
    }
}
