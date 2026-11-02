using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Application.Consultas;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Herramientas;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Infrastructure.Persistence;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.Mcp.Tests.Cableado;

/// <summary>
/// CTRL-06 (herramientas por sesión), en forma concurrente: el catálogo crea las herramientas con los
/// servicios de <see cref="AIFunctionArguments.Services"/>. Con el ámbito de cada sesión, B no ve ni borra lo de A,
/// con <c>ValidateScopes</c> en true y en false. Caso rojo: si se pasan los servicios raíz, con
/// <c>ValidateScopes = false</c> las dos sesiones comparten un único <see cref="SessionContext"/> y B ve y borra
/// lo que escribió A, sin error; con <c>true</c>, cada llamada a la herramienta falla.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class ConcurrenciaTests
{
    private static ServiceProvider Proveedor(bool validarAmbitos)
    {
        var s = new ServiceCollection();
        s.AddSingleton<AlmacenEnMemoria>();
        s.AddScoped<SessionContext>();
        s.AddScoped<ISessionContext>(sp => sp.GetRequiredService<SessionContext>());
        s.AddScoped<ILocalidadRepository, LocalidadRepositoryEnMemoria>();
        s.AddScoped<LocalidadService>();
        s.AddScoped<ConsultaDeLocalidades>();
        return s.BuildServiceProvider(new ServiceProviderOptions { ValidateScopes = validarAmbitos });
    }

    private static AIFunction Herramienta(string nombre) => CatalogoDeHerramientas.Crear().Single(f => f.Name == nombre);

    /// <summary>A da de alta Goya y B, en paralelo, lista Corrientes y pide borrar Goya.</summary>
    private static async Task<(string ListadoDeB, string BorradoDeB, int GoyaQuedaEnA)> DosSesiones(ServiceProvider raiz, bool usarAmbito)
    {
        using var ambitoA = raiz.CreateScope();
        using var ambitoB = raiz.CreateScope();
        var spA = usarAmbito ? ambitoA.ServiceProvider : raiz;
        var spB = usarAmbito ? ambitoB.ServiceProvider : raiz;
        using var barrera = new Barrier(2);

        var a = Task.Run(async () =>
        {
            spA.GetRequiredService<SessionContext>().Set("sesion-A");
            barrera.SignalAndWait();   // las dos sesiones quedan fijadas
            barrera.SignalAndWait();   // B ya fijó la suya
            await spA.GetRequiredService<LocalidadService>().SaveAsync(new LocalidadModel { Nombre = "Goya", Provincia = "Corrientes", CodigoPostal = "3450", Habitantes = 89959 });
            barrera.SignalAndWait();   // A escribió
        });
        var b = Task.Run(async () =>
        {
            barrera.SignalAndWait();
            spB.GetRequiredService<SessionContext>().Set("sesion-B");
            barrera.SignalAndWait();
            barrera.SignalAndWait();
            var listado = await Herramienta(HerramientasDeLocalidades.Listar).InvokeAsync(new AIFunctionArguments { ["provincia"] = "Corrientes", Services = spB });
            var borrado = await Herramienta(HerramientasDeLocalidades.Borrar).InvokeAsync(new AIFunctionArguments { ["nombre"] = "Goya", Services = spB });
            return (Texto(listado), Texto(borrado));
        });
        await Task.WhenAll(a, b);
        var (listadoB, borradoB) = await b;
        var quedan = raiz.GetRequiredService<AlmacenEnMemoria>().Leer("sesion-A", l => l.Nombre == "Goya").Count;
        return (listadoB, borradoB, quedan);
    }

    private static string Texto(object? r) => r is System.Text.Json.JsonElement e ? e.GetRawText() : r?.ToString() ?? "null";

    [TestCase(true)]
    [TestCase(false)]
    public async Task ConElAmbitoDeCadaSesion_BNoVeNiBorraLoDeA(bool validarAmbitos)
    {
        await using var raiz = Proveedor(validarAmbitos);
        var (listado, borrado, quedan) = await DosSesiones(raiz, usarAmbito: true);
        TestContext.Out.WriteLine($"ValidateScopes={validarAmbitos}\n  B lista: {listado}\n  B borra: {borrado}\n  Goya en A: {quedan}");
        Assert.That(listado, Does.Not.Contain("Goya"));
        Assert.That(Comun.Ok(borrado), Is.False);
        Assert.That(quedan, Is.EqualTo(1), "borradas 0");
    }

    [Test]
    public async Task CasoRojo_ServiciosRaizSinValidarAmbitos_BVeYBorraLoDeA()
    {
        await using var raiz = Proveedor(validarAmbitos: false);
        var (listado, borrado, quedan) = await DosSesiones(raiz, usarAmbito: false);
        TestContext.Out.WriteLine($"ValidateScopes=false, servicios raíz\n  B lista: {listado}\n  B borra: {borrado}\n  Goya en A: {quedan}");
        // El cruce se ve: la prueba de arriba lo detectaría.
        Assert.That(listado, Does.Contain("Goya"));
        Assert.That(Comun.Ok(borrado), Is.True);
    }

    [Test]
    public async Task CasoRojo_ServiciosRaizValidandoAmbitos_FallaEnCadaLlamada()
    {
        using var raiz = Proveedor(validarAmbitos: true);
        var ex = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await Herramienta(HerramientasDeLocalidades.Listar).InvokeAsync(new AIFunctionArguments { Services = raiz }));
        TestContext.Out.WriteLine(ex!.Message);
    }
}
