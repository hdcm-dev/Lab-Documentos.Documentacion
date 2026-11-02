using Microsoft.Extensions.DependencyInjection;
using MovilidadUrbana.PruebaDeArquitectura.Application.Propuestas;

namespace MovilidadUrbana.PruebaDeArquitectura.Application;

/// <summary>Registra el caso de uso agregado, igual que <c>AddApplication</c> del caso base.</summary>
public static class DependencyInjection
{
    public static IServiceCollection AddPropuestas(this IServiceCollection services) =>
        services.AddScoped<ProponerLocalidadDesdeTexto>();
}
