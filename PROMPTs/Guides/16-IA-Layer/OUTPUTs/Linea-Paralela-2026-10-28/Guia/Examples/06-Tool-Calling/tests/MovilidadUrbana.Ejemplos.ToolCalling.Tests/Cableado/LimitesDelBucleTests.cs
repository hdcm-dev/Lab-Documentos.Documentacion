using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Domain.Entities;
using MovilidadUrbana.Ejemplos.ToolCalling.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.ToolCalling.Infrastructure.Persistence;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.ToolCalling.Tests.Cableado;

/// <summary>
/// Límites del bucle (CTRL-05), por configuración: iteraciones = herramientas encadenables + 1 (3) y
/// errores consecutivos 2. Lo que hace FunctionInvokingChatClient 10.11.0 al llegar a cada límite se mide acá.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class LimitesDelBucleTests
{
    [Test]
    public void LosLimitesSalenDeLaConfiguracion()
    {
        var config = Configuraciones.Valida();
        config["AI:Herramientas:MaximoDeIteraciones"] = "5";
        config["AI:Herramientas:MaximoDeErroresConsecutivos"] = "1";
        using var host = Configuraciones.Anfitrion(config, _ => new ClienteGuionado("x", []));
        var bucle = host.Services.GetRequiredService<IChatClient>().GetService<FunctionInvokingChatClient>();
        TestContext.Out.WriteLine($"MaximumIterationsPerRequest={bucle?.MaximumIterationsPerRequest}; MaximumConsecutiveErrorsPerRequest={bucle?.MaximumConsecutiveErrorsPerRequest}");
        Assert.That(bucle, Is.Not.Null);
        Assert.That(bucle!.MaximumIterationsPerRequest, Is.EqualTo(5));
        Assert.That(bucle.MaximumConsecutiveErrorsPerRequest, Is.EqualTo(1));
    }

    [TestCase("0", "2")]
    [TestCase("3", "-1")]
    public void LimiteFueraDeRango_NoArranca(string iteraciones, string errores)
    {
        var config = Configuraciones.Valida();
        config["AI:Herramientas:MaximoDeIteraciones"] = iteraciones;
        config["AI:Herramientas:MaximoDeErroresConsecutivos"] = errores;
        Assert.Throws<OptionsValidationException>(() => Configuraciones.Anfitrion(config, _ => new ClienteGuionado("x", [])));
    }

    [Test]
    public async Task UnModeloQueNoTermina_SeCortaEnElMaximoDeIteraciones()
    {
        var modelo = new ClienteQueNoTermina(HerramientasDeLocalidades.ContarPorProvincia, new() { ["provincia"] = "Chaco" });
        using var host = Configuraciones.Anfitrion(Configuraciones.Valida(), _ => modelo);
        var almacen = host.Services.GetRequiredService<AlmacenEnMemoria>();
        var (ambito, asistente) = Configuraciones.Sesion(host, "sesion-a");
        using (ambito)
        {
            var r = await asistente.PreguntarAsync("pregunta de la prueba");
            var ultima = modelo.OpcionesRecibidas[^1];
            TestContext.Out.WriteLine($"llamadas al modelo={modelo.Llamadas}; herramientas ejecutadas={r.Herramientas.Count}; lecturas={almacen.Lecturas}; " +
                $"última llamada: herramientas={ultima?.Tools?.Count ?? 0}, ToolMode={ultima?.ToolMode?.GetType().Name ?? "null"}; texto final=«{r.Texto}»");

            Assert.That(r.Herramientas, Has.Count.EqualTo(3), "3 ejecuciones: una por iteración");
            Assert.That(almacen.Lecturas, Is.EqualTo(3));
            Assert.That(modelo.Llamadas, Is.EqualTo(4), "3 iteraciones con herramientas + 1 vuelta final");
            Assert.That(ultima?.Tools is not { Count: > 0 } || ultima.ToolMode is NoneChatToolMode, Is.True,
                "en la vuelta final el bucle ya no ofrece herramientas");
            Assert.That(almacen.Escrituras, Is.Zero);
        }
    }

    /// <summary>Repositorio que falla siempre: cada ejecución de la herramienta termina en excepción.</summary>
    private sealed class RepositorioQueFalla : ILocalidadRepository
    {
        public int Lecturas;
        public Task<IReadOnlyList<Localidad>> GetAllAsync(CancellationToken c = default) { Lecturas++; throw new InvalidOperationException("base caída"); }
        public Task<Localidad?> GetByIdAsync(int id, CancellationToken c = default) => throw new InvalidOperationException("base caída");
        public Task<int> AddAsync(Localidad l, CancellationToken c = default) => throw new NotSupportedException();
        public Task UpdateAsync(Localidad l, CancellationToken c = default) => throw new NotSupportedException();
        public Task DeleteAsync(int id, CancellationToken c = default) => throw new NotSupportedException();
    }

    [Test]
    public async Task ErroresConsecutivos_PasadoElMaximo_LaExcepcionSale()
    {
        var modelo = new ClienteQueNoTermina(HerramientasDeLocalidades.ContarPorProvincia, new() { ["provincia"] = "Chaco" });
        var repositorio = new RepositorioQueFalla();
        var config = Configuraciones.Valida();
        config["AI:Herramientas:MaximoDeIteraciones"] = "10"; // que corte por errores, no por iteraciones
        using var host = Configuraciones.Anfitrion(config, _ => modelo,
            reemplazos: s => s.AddScoped<ILocalidadRepository>(_ => repositorio));
        var (ambito, asistente) = Configuraciones.Sesion(host, "sesion-a");
        using (ambito)
        {
            var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => asistente.PreguntarAsync("pregunta de la prueba"));
            TestContext.Out.WriteLine($"excepción: «{ex!.Message}»; ejecuciones de la herramienta={repositorio.Lecturas}; llamadas al modelo={modelo.Llamadas}");
            Assert.That(repositorio.Lecturas, Is.EqualTo(3), "2 errores tolerados + el que supera el máximo");
            Assert.That(modelo.Llamadas, Is.EqualTo(3));
        }
    }
}
