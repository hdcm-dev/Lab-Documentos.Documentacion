using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.ChatBasico.Tests.Cableado;

/// <summary>OpcionesDeIA se valida al arrancar (ValidateOnStart), no en el primer pedido.</summary>
[TestFixture, Category("Cableado")]
public sealed class ArranqueTests
{
    [Test]
    public async Task ConConfiguracionCompleta_Arranca()
    {
        using var host = Configuraciones.Anfitrion(Configuraciones.Valida());
        await host.StartAsync();
        await host.StopAsync();
    }

    [Test]
    public async Task SinTimeoutSegundos_NoArranca()
    {
        var config = Configuraciones.Valida();
        config.Remove("AI:TimeoutSegundos");
        using var host = Configuraciones.Anfitrion(config);

        var ex = await Assert.ThrowsAsync<OptionsValidationException>(() => host.StartAsync());
        TestContext.Out.WriteLine($"sin TimeoutSegundos → {ex!.GetType().Name}: {string.Join(" | ", ex.Failures)}");
        Assert.That(ex.Failures, Has.Some.Contains("TimeoutSegundos"));
    }

    [Test]
    public async Task ConPermisosCero_NoArranca()
    {
        var config = Configuraciones.Valida();
        config["AI:Concurrencia:Permisos"] = "0";
        using var host = Configuraciones.Anfitrion(config);

        var ex = await Assert.ThrowsAsync<OptionsValidationException>(() => host.StartAsync());
        TestContext.Out.WriteLine($"Concurrencia:Permisos = 0 → {ex!.GetType().Name}: {string.Join(" | ", ex.Failures)}");
        Assert.That(ex.Failures, Has.Some.Contains("Permisos"));
    }

    [Test]
    public async Task ConProveedorDesconocido_NoArranca()
    {
        var config = Configuraciones.Valida();
        config["AI:Proveedor"] = "otro";
        using var host = Configuraciones.Anfitrion(config);

        var ex = await Assert.ThrowsAsync<OptionsValidationException>(() => host.StartAsync());
        Assert.That(ex!.Failures, Has.Some.Contains("Proveedor"));
    }
}

/// <summary>Caso rojo de [ValidateObjectMembers]: sin el atributo, la clase anidada no se valida.</summary>
[TestFixture, Category("Cableado")]
public sealed class ValidateObjectMembersTests
{
    public sealed class OpcionesSinAtributo { public MovilidadUrbana.Ejemplos.ChatBasico.Configuracion.OpcionesDeConcurrencia Concurrencia { get; set; } = new(); }

    [Test]
    public async Task SinElAtributo_PermisosCeroArranca()
    {
        var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings { DisableDefaults = true });
        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?> { ["X:Concurrencia:Permisos"] = "0" });
        builder.Services.AddOptions<OpcionesSinAtributo>().Bind(builder.Configuration.GetSection("X"))
            .ValidateDataAnnotations().ValidateOnStart();
        using var host = builder.Build();

        await host.StartAsync(); // no lanza: Permisos = 0 pasa
        var valor = host.Services.GetRequiredService<IOptions<OpcionesSinAtributo>>().Value.Concurrencia.Permisos;
        TestContext.Out.WriteLine($"sin [ValidateObjectMembers], Permisos = {valor} y el anfitrión arrancó");
        Assert.That(valor, Is.EqualTo(0));
        await host.StopAsync();
    }
}
