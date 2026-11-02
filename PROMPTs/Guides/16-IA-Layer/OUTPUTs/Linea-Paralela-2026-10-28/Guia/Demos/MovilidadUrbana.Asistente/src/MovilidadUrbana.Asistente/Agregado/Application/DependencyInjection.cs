using Microsoft.Extensions.DependencyInjection;
using MovilidadUrbana.Asistente.Application.Abstractions;
using MovilidadUrbana.Asistente.Application.Asistente;
using MovilidadUrbana.Asistente.Application.Encuestas;
using MovilidadUrbana.Asistente.Application.Localidades;

namespace MovilidadUrbana.Asistente.Application;

/// <summary>Registra los casos de uso agregados. Los copiados los registra AddApplication() de la copia.</summary>
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationAgregada(this IServiceCollection services)
    {
        services.AddScoped<ProponerLocalidadDesdeTexto>();
        services.AddScoped<ProponerBajaDesdeTexto>();
        services.AddScoped<ProponerPaso2DesdeTexto>();
        services.AddScoped<ResultadosDeEncuestaService>();
        services.AddScoped<IAsistenteDeMovilidad, AsistenteDeMovilidad>();
        return services;
    }
}
