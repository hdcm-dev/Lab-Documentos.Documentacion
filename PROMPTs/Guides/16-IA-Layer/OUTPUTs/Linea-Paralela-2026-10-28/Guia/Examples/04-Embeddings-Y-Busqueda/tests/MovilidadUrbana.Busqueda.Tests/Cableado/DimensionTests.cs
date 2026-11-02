using Microsoft.Extensions.DependencyInjection;
using MovilidadUrbana.Busqueda.Busqueda;
using MovilidadUrbana.Busqueda.Requisitos;

namespace MovilidadUrbana.Busqueda.Tests.Cableado;

/// <summary>Invariante: largo de cada vector devuelto = dimensión declarada en el almacén. Si no, no arranca.</summary>
[TestFixture, Category("Cableado")]
public sealed class DimensionTests
{
    [Test]
    public async Task Generador512_ConDimensionDeclarada1024_NoArranca()
    {
        var generador = new GeneradorFijo(512);
        using var host = AnfitrionDePrueba.Crear(generador, new() { ["AI:ModeloDeEmbeddings"] = "modelo-de-prueba" });

        var ex = await Assert.ThrowsAsync<DimensionDeEmbeddingsException>(() => host.StartAsync());
        TestContext.Out.WriteLine(ex!.Message);
        Assert.Multiple(() =>
        {
            Assert.That(ex.Declarada, Is.EqualTo(1024));
            Assert.That(ex.Medida, Is.EqualTo(512));
            Assert.That(ex.Message, Does.Contain("modelo-de-prueba").And.Contain("512").And.Contain("1024"));
            Assert.That(generador.TextosPedidos, Is.EqualTo(new[] { AlmacenDeRequisitos.TextoDePrueba }), "corta antes de ingerir");
        });
    }

    [Test]
    public async Task Generador1024_ConDimensionDeclarada1024_Arranca()
    {
        var generador = new GeneradorFijo(1024);
        using var host = AnfitrionDePrueba.Crear(generador);

        await host.StartAsync();
        var almacen = host.Services.GetRequiredService<AlmacenDeRequisitos>();
        var resultados = await almacen.BuscarAsync("cualquier consulta", 12);
        Assert.Multiple(() =>
        {
            Assert.That(almacen.Dimension, Is.EqualTo(1024));
            Assert.That(resultados, Has.Count.EqualTo(12), "los doce requisitos se ingirieron");
        });
    }

    [Test]
    public async Task SinDimensionDeclarada_AdoptaLaDelPrimerEmbedding()
    {
        using var host = AnfitrionDePrueba.Crear(new GeneradorFijo(768), new() { ["AI:DimensionDeEmbeddings"] = null });
        await host.StartAsync();
        Assert.That(host.Services.GetRequiredService<AlmacenDeRequisitos>().Dimension, Is.EqualTo(768));
    }

    [Test]
    public async Task UnVectorDeOtroLargoALaMitadDeLaIngesta_NoArranca()
    {
        // La prueba de arranque pasa con 1024, pero un requisito vuelve con 512: el verificador lo corta igual.
        var habitantes = new CatalogoDeRequisitos().Requisitos.Single(r => r.Fuente == "LocalidadPolicy.RequisitoDeLosHabitantes");
        var generador = new GeneradorFijo(1024, t => t == habitantes.TextoAIndexar ? new float[512] : null);
        using var host = AnfitrionDePrueba.Crear(generador, new() { ["AI:DimensionDeEmbeddings"] = null });

        var ex = await Assert.ThrowsAsync<DimensionDeEmbeddingsException>(() => host.StartAsync());
        Assert.That((ex!.Declarada, ex.Medida), Is.EqualTo((1024, 512)));
    }
}
