using System.Text.Json;
using Microsoft.Extensions.Options;
using MovilidadUrbana.SalidaEstructurada.Application.Propuestas;
using MovilidadUrbana.SalidaEstructurada.Infrastructure.AI;
using MovilidadUrbana.SalidaEstructurada.Tests.Dobles;
using OllamaSharp;

namespace MovilidadUrbana.SalidaEstructurada.Tests.Cableado;

/// <summary>
/// Sin modelo, pero con el cliente real de OllamaSharp: un servidor falso en el HttpClient guarda lo que
/// sale por la vía nativa (/api/chat) y contesta lo que la prueba necesita.
/// </summary>
[TestFixture]
public sealed class CuerpoDelPedidoTests
{
    private static (ExtractorDeLocalidadLlm Extractor, ServidorOllamaFalso Servidor) Armar(string contenido)
    {
        var ia = Opciones.DelAppsettings();
        var servidor = new ServidorOllamaFalso(contenido);
        var http = new HttpClient(servidor) { BaseAddress = new Uri(ia.Endpoint) };
        return (new ExtractorDeLocalidadLlm(new OllamaApiClient(http, ia.Modelo), Options.Create(ia)), servidor);
    }

    [Test]
    public async Task ElPedidoLlevaElEsquemaEnFormat_YLasOpcionesPorPedido()
    {
        var (extractor, servidor) = Armar(
            """{"tipo":"Alta","id":null,"nombre":"Goya","provincia":"Corrientes","codigoPostal":"3450","habitantes":90000}""");

        var propuesta = await extractor.ExtraerAsync("Agregá Goya, Corrientes, CP 3450, unos 90 mil habitantes", []);

        Assert.That(propuesta, Is.EqualTo(new LocalidadPropuesta(TipoDePropuesta.Alta, null, "Goya", "Corrientes", "3450", 90000)));
        using var cuerpo = JsonDocument.Parse(servidor.Cuerpos.Single());
        var raiz = cuerpo.RootElement;
        var ia = Opciones.DelAppsettings();
        // Se muestran sólo los campos que enseña el ejemplo (no el cuerpo entero ni sus cabeceras).
        TestContext.Out.WriteLine($"format: {raiz.GetProperty("format")}");
        TestContext.Out.WriteLine($"options: {raiz.GetProperty("options")}; think: {raiz.GetProperty("think")}");

        // La forma viaja como JSON Schema en «format»: el servidor restringe la salida a ese esquema.
        var format = raiz.GetProperty("format");
        Assert.That(format.ValueKind, Is.EqualTo(JsonValueKind.Object));
        var propiedades = format.GetProperty("properties").EnumerateObject().Select(p => p.Name).ToList();
        Assert.That(propiedades, Is.EquivalentTo(new[] { "tipo", "id", "nombre", "provincia", "codigoPostal", "habitantes" }));

        // Razonamiento apagado, num_ctx y el muestreo del fabricante, todos desde OpcionesDeIA.
        Assert.That(raiz.GetProperty("think").GetBoolean(), Is.False);
        var opciones = raiz.GetProperty("options");
        Assert.That(opciones.GetProperty("num_ctx").GetInt32(), Is.EqualTo(ia.NumCtx));
        Assert.That(opciones.GetProperty("temperature").GetSingle(), Is.EqualTo(ia.Muestreo.Temperatura));
        Assert.That(opciones.GetProperty("top_p").GetSingle(), Is.EqualTo(ia.Muestreo.TopP));
        Assert.That(opciones.GetProperty("top_k").GetInt32(), Is.EqualTo(ia.Muestreo.TopK));
        Assert.That(opciones.GetProperty("presence_penalty").GetSingle(), Is.EqualTo(ia.Muestreo.PresencePenalty));
    }

    [Test]
    public async Task ContenidoQueNoEsJson_PorElClienteReal_DaNull()
    {
        var (extractor, _) = Armar("No entendí el pedido.");

        var propuesta = await extractor.ExtraerAsync("Agregá Goya", []);

        Assert.That(propuesta, Is.Null);
    }
}
