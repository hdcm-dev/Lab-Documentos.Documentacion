using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.Orquestacion.Application.Altas;
using MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.Persistence;
using MovilidadUrbana.Ejemplos.Orquestacion.SinModelo;

namespace MovilidadUrbana.Ejemplos.Orquestacion.Tests.Cableado;

/// <summary>La composición real del ejemplo con el cliente guionado en lugar del servidor. Un ámbito = una sesión.</summary>
public sealed class Anfitrion : IDisposable
{
    private readonly IHost _host;
    private readonly IServiceScope _ambito;

    public Anfitrion(ClienteGuionado cliente, string sesion = "sesion-a")
    {
        var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
        {
            DisableDefaults = true,
            ContentRootPath = AppContext.BaseDirectory,
        });
        builder.Configuration.AddJsonFile("appsettings.json").AddJsonFile("appsettings.Development.json");
        builder.AgregarCapaDeIA(_ => null, _ => cliente);
        _host = builder.Build();
        _host.Start();
        _ambito = _host.Services.CreateScope();
        _ambito.ServiceProvider.GetRequiredService<SessionContext>().Set(sesion);
        Cliente = cliente;
    }

    public ClienteGuionado Cliente { get; }
    public IServiceProvider Servicios => _ambito.ServiceProvider;
    public AlmacenEnMemoria Almacen => _host.Services.GetRequiredService<AlmacenEnMemoria>();
    public IExtractorDeAlta Extractor => Servicios.GetRequiredService<IExtractorDeAlta>();
    public LocalidadService Localidades => Servicios.GetRequiredService<LocalidadService>();

    /// <summary>Un «modelo» que siempre devuelve el mismo texto.</summary>
    public static ClienteGuionado Devuelve(string respuesta) => new((_, _) => respuesta);

    public static string Json(string? nombre, string? provincia, string? cp, int? habitantes) =>
        System.Text.Json.JsonSerializer.Serialize(new { nombre, provincia, codigoPostal = cp, habitantes });

    public void Dispose()
    {
        _ambito.Dispose();
        _host.Dispose();
    }
}
