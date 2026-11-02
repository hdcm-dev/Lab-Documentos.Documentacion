using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovilidadUrbana.Busqueda.Busqueda;
using MovilidadUrbana.Busqueda.Configuracion;
using MovilidadUrbana.Busqueda.Evaluacion;

namespace MovilidadUrbana.Busqueda.Tests.Cableado;

/// <summary>
/// Modo sin modelo: el circuito completo (opciones, dimensión, ingesta, búsqueda, calibración y métricas) con el
/// generador léxico. Es determinista: la tabla sale igual en cada corrida y sirve de línea de base léxica.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class SinModeloTests
{
    private static IHost Anfitrion()
    {
        var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
        {
            DisableDefaults = true,
            ContentRootPath = AppContext.BaseDirectory,
        });
        builder.Configuration
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json")
            .AddInMemoryCollection(new Dictionary<string, string?> { ["AI:Modo"] = Modos.SinModelo });
        builder.AgregarBusquedaDeRequisitos(_ => null);
        return builder.Build();
    }

    [Test]
    public async Task ElOroCorreSinServidor_YDaLoMismoDosVeces()
    {
        var oro = GeneradorDeOro.Leer(Path.Combine(AppContext.BaseDirectory, "oro", "oro-requisitos.json"));
        var tablas = new List<string>();
        for (var vuelta = 0; vuelta < 2; vuelta++)
        {
            using var host = Anfitrion();
            await host.StartAsync();
            var almacen = host.Services.GetRequiredService<AlmacenDeRequisitos>();
            var corrida = await EvaluacionDeRecuperacion.CorrerAsync(almacen, oro, instruccion: null, k: 3, tamanoDelCorpus: 12);
            tablas.Add(EvaluacionDeRecuperacion.Tabla(corrida));
        }
        TestContext.Out.WriteLine("Generador léxico falso (no es un modelo), sin instrucción:");
        TestContext.Out.WriteLine(tablas[0]);
        Assert.That(tablas[1], Is.EqualTo(tablas[0]));
    }
}
