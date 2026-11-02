using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.RagEnMemoria.Application.Ayuda;
using MovilidadUrbana.RagEnMemoria.Infrastructure.Persistence;
using MovilidadUrbana.RagEnMemoria.Tests.Dobles;
using NUnit.Framework;

namespace MovilidadUrbana.RagEnMemoria.Tests.Cableado;

/// <summary>El almacén real (MEVD InMemory) con un generador falso y fijo.</summary>
public class AlmacenTests
{
    [Test]
    public async Task GeneradorDe512_ConDimensionDeclarada1024_NoArranca()
    {
        using var host = AnfitrionDePrueba.Crear(new ClienteFalso(ClienteFalso.Texto("ok")), new GeneradorFalso(512),
            new() { ["AI:DimensionDeEmbeddings"] = "1024" });
        var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => host.StartAsync());
        Assert.That(ex!.Message, Does.Contain("512").And.Contain("1024").And.Contain("embeddings-falso"));
    }

    [Test]
    public async Task GeneradorDe1024_ConDimensionDeclarada1024_Arranca_YCargaLos12()
    {
        var generador = new GeneradorFalso(1024);
        using var host = AnfitrionDePrueba.Crear(new ClienteFalso(ClienteFalso.Texto("ok")), generador,
            new() { ["AI:DimensionDeEmbeddings"] = "1024" });
        await host.StartAsync();
        var almacen = host.Services.GetRequiredService<AlmacenDeRequisitos>();
        Assert.That(almacen.Dimension, Is.EqualTo(1024));
        var todos = await almacen.BuscarAsync("cualquiera", 12, default);
        Assert.That(todos, Has.Count.EqualTo(12));
        await host.StopAsync();
    }

    [Test]
    public async Task SinDimensionDeclarada_SeTomaLaMedida()
    {
        using var host = AnfitrionDePrueba.Crear(new ClienteFalso(ClienteFalso.Texto("ok")), new GeneradorFalso(64),
            new() { ["AI:DimensionDeEmbeddings"] = null });
        await host.StartAsync();
        Assert.That(host.Services.GetRequiredService<AlmacenDeRequisitos>().Dimension, Is.EqualTo(64));
        await host.StopAsync();
    }

    [Test]
    public async Task LaInstruccionVaSoloEnLaConsulta_NuncaEnElDocumento()
    {
        var generador = new GeneradorFalso(32);
        using var host = AnfitrionDePrueba.Crear(new ClienteFalso(ClienteFalso.Texto("ok")), generador);
        await host.StartAsync();
        await host.Services.GetRequiredService<IBuscadorDeRequisitos>().BuscarAsync("¿CP?", 3, default);

        var documentos = RequisitosDelDominio.Todos.Select(AlmacenDeRequisitos.TextoDelDocumento).ToHashSet();
        Assert.Multiple(() =>
        {
            Assert.That(generador.Recibidos.Where(documentos.Contains).Count(), Is.EqualTo(12));
            Assert.That(generador.Recibidos.Where(documentos.Contains), Has.None.Contain("Instruct:"));
            Assert.That(generador.Recibidos[^1], Is.EqualTo("Instruct: Retrieve the requirement\nQuery:¿CP?"));
        });
        await host.StopAsync();
    }

    [Test]
    public async Task ConVectoresFijos_ElAlmacenDevuelveElOrdenEsperado_YElPuntajeEsSimilitud()
    {
        // Cada requisito i es el eje i; la consulta pesa 3 en el CP, 2 en la edad y 1 en el nombre.
        const int d = 32;
        var corpus = RequisitosDelDominio.Todos;
        var mapa = corpus.Select((r, i) => (Texto: AlmacenDeRequisitos.TextoDelDocumento(r), V: GeneradorFalso.Vector(d, (i, 1f))))
            .ToDictionary(x => x.Texto, x => x.V);
        int Pos(string f) => corpus.ToList().FindIndex(r => r.Fuente == f);
        var consulta = AlmacenDeRequisitos.TextoDeLaConsulta("q", "Retrieve the requirement");
        mapa[consulta] = GeneradorFalso.Vector(d,
            (Pos("LocalidadPolicy.RequisitoDelCodigoPostal"), 3f), (Pos("EncuestaPolicy.RequisitoDeLaEdad"), 2f), (Pos("LocalidadPolicy.RequisitoDelNombre"), 1f));

        using var host = AnfitrionDePrueba.Crear(new ClienteFalso(ClienteFalso.Texto("ok")), new GeneradorFalso(d, mapa));
        await host.StartAsync();
        var r = await host.Services.GetRequiredService<IBuscadorDeRequisitos>().BuscarAsync("q", 3, default);

        Assert.That(r.Select(x => x.Fuente), Is.EqualTo(new[]
            { "LocalidadPolicy.RequisitoDelCodigoPostal", "EncuestaPolicy.RequisitoDeLaEdad", "LocalidadPolicy.RequisitoDelNombre" }));
        Assert.That(r[0].Puntaje, Is.EqualTo(3 / Math.Sqrt(14)).Within(1e-5), "coseno: mayor es mejor");
        Assert.That(r[0].Puntaje, Is.GreaterThan(r[1].Puntaje));
        await host.StopAsync();
    }

    [Test]
    public async Task SinTimeout_LasOpcionesNoValidan_YNoArranca()
    {
        using var host = AnfitrionDePrueba.Crear(new ClienteFalso(ClienteFalso.Texto("ok")), new GeneradorFalso(32),
            new() { ["AI:TimeoutSegundos"] = null });
        await Assert.ThrowsAsync<OptionsValidationException>(() => host.StartAsync());
    }
}
