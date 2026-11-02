using MovilidadUrbana.ApiWeb.Application;
using MovilidadUrbana.PruebaDeArquitectura.Application;
using MovilidadUrbana.PruebaDeArquitectura.Infrastructure.AI;
using MovilidadUrbana.PruebaDeArquitectura.Presentation.Herramientas;

namespace MovilidadUrbana.PruebaDeArquitectura;

/// <summary>
/// Raíz de composición: el único lugar que conoce todas las capas a la vez. La regla de dependencias no
/// la inspecciona, y por eso no tiene lógica: sólo registra. Lo propio del anfitrión web (controladores,
/// middleware) se suma en <c>Program.cs</c>.
/// </summary>
public static class Composicion
{
    public static IServiceCollection AgregarServicios(this IServiceCollection services, IConfiguration configuracion)
    {
        var conexion = configuracion.GetConnectionString("BaseDeDatos")
            ?? MovilidadUrbana.ApiWeb.Infrastructure.DependencyInjection.DefaultConnectionString;
        MovilidadUrbana.ApiWeb.Infrastructure.DependencyInjection.AddInfrastructure(services, conexion);
        services.AddApplication();
        services.AddPropuestas();
        services.AddAdaptadorDeIA(configuracion);
        services.AddScoped<HerramientasDeLectura>();
        return services;
    }
}
