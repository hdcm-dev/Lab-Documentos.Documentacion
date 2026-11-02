using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using MovilidadUrbana.RagEnMemoria.Application.Ayuda;
using MovilidadUrbana.RagEnMemoria.Infrastructure.AI;
using MovilidadUrbana.RagEnMemoria.Tests.Dobles;
using NUnit.Framework;
using E = MovilidadUrbana.RagEnMemoria.ComposicionDeIA.Estrategias;

namespace MovilidadUrbana.RagEnMemoria.Tests.Cableado;

/// <summary>Vía B (herramienta en el bucle de MEAI) y vía C (la misma herramienta en un agente de MAF), con dobles.</summary>
public class ViasByCTests
{
    private const string Cp = "LocalidadPolicy.RequisitoDelCodigoPostal";

    private static BuscadorFalso Buscador() =>
        new(BuscadorFalso.De(Cp), BuscadorFalso.De("EncuestaPolicy.RequisitoDeLaEdad", 0.4), BuscadorFalso.De("LocalidadPolicy.RequisitoDelNombre", 0.3));

    [TestCase(E.RagConHerramienta)]
    [TestCase(E.RagEnAgente)]
    public async Task CuandoElModeloPideBuscar_LaAplicacionBusca_YDevuelveLosFragmentosMarcados(string estrategia)
    {
        var buscador = Buscador();
        var chat = new ClienteFalso(ClienteFalso.PideBuscar("código postal"), ClienteFalso.Texto($"Lleva 4 dígitos [{Cp}]."));
        using var host = AnfitrionDePrueba.Crear(chat, new GeneradorFalso(32), buscador: buscador);

        var r = await host.Services.GetRequiredKeyedService<IAyuda>(estrategia).ResponderAsync("¿Cuántos dígitos lleva el CP?", null, default);

        Assert.That(buscador.Llamadas, Is.EqualTo(new[] { ("código postal", 3) }), "busca con la consulta que eligió el modelo");
        Assert.That(chat.Pedidos, Has.Count.EqualTo(2));
        var primero = chat.Pedidos[0].Opciones!;
        var resultado = chat.Pedidos[1].Mensajes.SelectMany(m => m.Contents).OfType<FunctionResultContent>().Single();
        Assert.Multiple(() =>
        {
            Assert.That(primero.Tools!.Select(t => t.Name), Is.EqualTo(new[] { TextosDeInstruccion.NombreDeLaHerramienta }));
            Assert.That(resultado.Result?.ToString(), Does.Contain(ContenidoExterno.Aviso));
            Assert.That(r.FragmentosEnElPrompt, Has.Count.EqualTo(3));
            Assert.That(r.FuentesCitadas, Is.EqualTo(new[] { Cp }));
        });
    }

    [TestCase(E.RagConHerramienta)]
    [TestCase(E.RagEnAgente)]
    public async Task SiElModeloNoPideBuscar_NoHayBusqueda_YLaRespuestaSaleSinFragmentos(string estrategia)
    {
        // El riesgo propio de B y C: el modelo decide. Con la vía A esto no puede pasar.
        var buscador = Buscador();
        var chat = new ClienteFalso(ClienteFalso.Texto("Lleva 5 dígitos."));
        using var host = AnfitrionDePrueba.Crear(chat, new GeneradorFalso(32), buscador: buscador);

        var r = await host.Services.GetRequiredKeyedService<IAyuda>(estrategia).ResponderAsync("¿Cuántos dígitos lleva el CP?", null, default);

        Assert.That(buscador.Llamadas, Is.Empty);
        Assert.That(r.FragmentosEnElPrompt, Is.Empty);
        Assert.That(r.FuentesCitadas, Is.Empty);
    }

    [Test]
    public async Task ViaB_ElBucleSeCortaEnElMaximoDeIteraciones()
    {
        var buscador = Buscador();
        var chat = new ClienteFalso(ClienteFalso.PideBuscar("cp"));   // pide buscar siempre
        using var host = AnfitrionDePrueba.Crear(chat, new GeneradorFalso(32), new() { ["AI:Rag:MaximoDeIteraciones"] = "2" }, buscador);

        await host.Services.GetRequiredKeyedService<IAyuda>(E.RagConHerramienta).ResponderAsync("¿CP?", null, default);

        Assert.That(buscador.Llamadas, Has.Count.LessThanOrEqualTo(2));
    }
}
