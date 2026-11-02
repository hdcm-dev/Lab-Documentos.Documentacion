using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.ToolCalling.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.ToolCalling.Infrastructure.Persistence;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.ToolCalling.Tests.Cableado;

/// <summary>Lo registrado es exactamente la lista cerrada de herramientas de lectura, y ninguna escribe.</summary>
[TestFixture, Category("Cableado")]
public sealed class CatalogoDeHerramientasTests
{
    [Test]
    public async Task LasHerramientasRegistradas_SonLaListaCerrada_YNingunaEscribe()
    {
        using var host = Configuraciones.Anfitrion(Configuraciones.Valida(), _ => new ClienteGuionado("x", []));
        using var ambito = host.Services.CreateScope();
        ambito.ServiceProvider.GetRequiredService<SessionContext>().Set("sesion-a");
        var funciones = ambito.ServiceProvider.GetRequiredService<HerramientasDeLocalidades>().Crear().Cast<AIFunction>().ToList();

        foreach (var f in funciones) TestContext.Out.WriteLine($"{f.Name}: {f.Description} — esquema {f.JsonSchema}");
        Assert.That(funciones.Select(f => f.Name), Is.EquivalentTo(new[] { "contar_localidades_por_provincia", "listar_localidades" }));
        Assert.That(funciones.Select(f => f.Name), Is.EquivalentTo(HerramientasDeLocalidades.NombresDeLectura));

        var almacen = host.Services.GetRequiredService<AlmacenEnMemoria>();
        await funciones.Single(f => f.Name == "contar_localidades_por_provincia").InvokeAsync(new() { ["provincia"] = "Corrientes" });
        await funciones.Single(f => f.Name == "listar_localidades").InvokeAsync(new() { ["provincia"] = "Chaco", ["codigoPostal"] = "3500" });
        await funciones.Single(f => f.Name == "listar_localidades").InvokeAsync(new());
        TestContext.Out.WriteLine($"lecturas={almacen.Lecturas}; escrituras={almacen.Escrituras}");
        Assert.That(almacen.Lecturas, Is.EqualTo(3));
        Assert.That(almacen.Escrituras, Is.Zero);
    }

    [Test]
    public async Task EntradaMasLargaQueElMaximo_NoLlamaAlModelo()
    {
        var modelo = new ClienteGuionado(HerramientasDeLocalidades.Listar, []);
        using var host = Configuraciones.Anfitrion(Configuraciones.Valida(), _ => modelo);
        var (ambito, asistente) = Configuraciones.Sesion(host, "sesion-a");
        using (ambito)
        {
            await Assert.ThrowsAsync<EntradaDemasiadoLargaException>(() => asistente.PreguntarAsync(new string('a', 2001)));
            Assert.That(modelo.Llamadas, Is.Zero);
        }
    }
}
