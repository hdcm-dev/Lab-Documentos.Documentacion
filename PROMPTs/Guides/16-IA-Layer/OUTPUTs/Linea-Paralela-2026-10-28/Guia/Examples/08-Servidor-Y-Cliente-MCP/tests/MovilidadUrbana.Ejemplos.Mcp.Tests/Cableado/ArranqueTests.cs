using System.Net;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Mcp;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.Mcp.Tests.Cableado;

/// <summary>CTRL-13 al arrancar: loopback por defecto, AllowedHosts cerrado y token obligatorio.</summary>
[TestFixture, Category("Cableado")]
public sealed class ArranqueTests
{
    [Test]
    public async Task PorDefecto_EscuchaSoloEnLoopback()
    {
        await using var servidor = await Comun.ServidorAsync();
        var direcciones = servidor.App.Services.GetRequiredService<IServer>().Features.Get<IServerAddressesFeature>()!.Addresses;
        TestContext.Out.WriteLine(string.Join(", ", direcciones));
        Assert.That(direcciones.Select(d => IPAddress.IsLoopback(IPAddress.Parse(new Uri(d).Host.Trim('[', ']')))), Is.All.True);
    }

    [Test]
    public void ElJsonDelEjemplo_DeclaraLoopbackYAllowedHostsCerrado()
    {
        var builder = ServidorMcp.CrearBuilder([], "Production");
        Assert.That(builder.Configuration["AllowedHosts"], Is.EqualTo("localhost;127.0.0.1"));
        Assert.That(builder.Configuration["Mcp:Urls:0"], Does.StartWith("http://127.0.0.1:"));
        Assert.That(ReglasDelPerimetro.Revisar(builder.Configuration), Is.Empty);
    }

    [TestCase("http://0.0.0.0:0")]
    [TestCase("http://192.0.2.10:8080")]  // dirección de documentación (RFC 5737)
    [TestCase("http://+:8080")]
    public void UnaDireccionFueraDeLoopback_NoArranca(string url)
    {
        var builder = ServidorMcp.CrearBuilder([], "Development", new Dictionary<string, string?> { ["Mcp:Urls:0"] = url });
        var ex = Assert.Throws<InvalidOperationException>(() => builder.AgregarServidorMcp());
        TestContext.Out.WriteLine(ex!.Message);
        Assert.That(ex.Message, Does.Contain("no es loopback"));
    }

    [TestCase("*")]
    [TestCase("localhost;*")]
    public void AllowedHostsAbierto_NoArranca(string hosts)
    {
        var builder = ServidorMcp.CrearBuilder([], "Development", new Dictionary<string, string?> { ["AllowedHosts"] = hosts });
        var ex = Assert.Throws<InvalidOperationException>(() => builder.AgregarServidorMcp());
        Assert.That(ex!.Message, Does.Contain("AllowedHosts"));
    }

    [Test]
    public async Task FueraDeDevelopment_SinToken_NoArranca()
    {
        var ex = await Assert.ThrowsAsync<OptionsValidationException>(async () =>
        {
            await using var _ = await ServidorMcp.IniciarEnLoopbackAsync("Production");
        });
        TestContext.Out.WriteLine(string.Join(" | ", ex!.Failures));
        Assert.That(ex.Failures, Has.Some.Contain("Token"));
    }
}
