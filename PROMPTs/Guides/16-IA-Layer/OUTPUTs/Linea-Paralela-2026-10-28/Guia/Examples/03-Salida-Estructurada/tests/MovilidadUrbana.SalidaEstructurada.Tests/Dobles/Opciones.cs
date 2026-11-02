using Microsoft.Extensions.Configuration;

namespace MovilidadUrbana.SalidaEstructurada.Tests.Dobles;

/// <summary>Opciones de prueba: las lee del mismo appsettings.json del ejemplo, sin literales.</summary>
public static class Opciones
{
    public static OpcionesDeIA DelAppsettings()
    {
        var configuracion = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"))
            .Build();
        var ia = new OpcionesDeIA();
        configuracion.GetSection(OpcionesDeIA.Seccion).Bind(ia);
        return ia;
    }
}
