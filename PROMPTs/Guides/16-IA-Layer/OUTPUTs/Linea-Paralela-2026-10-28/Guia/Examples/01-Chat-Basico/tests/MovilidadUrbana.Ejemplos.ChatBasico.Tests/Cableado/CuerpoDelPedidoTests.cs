using System.Text.Json.Nodes;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.ChatBasico.Configuracion;
using MovilidadUrbana.Ejemplos.ChatBasico.Conversacion;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.ChatBasico.Tests.Cableado;

/// <summary>
/// Qué llega al servidor por cada vía con las mismas opciones: se captura el cuerpo del pedido
/// con un servidor falso. Reproduce las filas TopK, MaxOutputTokens y num_ctx de la tabla de vías.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class CuerpoDelPedidoTests
{
    private static async Task<ServidorFalso.Pedido> Enviar(string proveedor, string? credencial = null)
    {
        var servidor = new ServidorFalso();
        var config = Configuraciones.Valida(proveedor);
        if (credencial is not null) config["AI:Credencial"] = credencial;
        using var host = Configuraciones.Anfitrion(config, servidor);

        var chat = host.Services.GetRequiredService<IChatClient>();
        var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
        var opciones = FabricaDeOpcionesDeChat.Crear(ia);
        opciones.MaxOutputTokens = 3;

        await chat.GetResponseAsync("¿Cuántos dígitos lleva el código postal?", opciones);
        return servidor.Pedidos.Single();
    }

    [Test]
    public async Task ViaNativa_LlevaNumCtxTopKYNumPredict()
    {
        var pedido = await Enviar(Proveedores.Ollama);
        var cuerpo = pedido.Json;
        var options = cuerpo["options"]!.AsObject();
        TestContext.Out.WriteLine($"POST {pedido.Ruta}  options={options.ToJsonString()}  think={cuerpo["think"]?.ToJsonString() ?? "(ausente)"}");

        Assert.That(pedido.Ruta, Is.EqualTo("/api/chat"));
        Assert.That((int)options["num_ctx"]!, Is.EqualTo(8192));
        Assert.That((int)options["top_k"]!, Is.EqualTo(20));
        Assert.That((int)options["num_predict"]!, Is.EqualTo(3));
        Assert.That((bool)cuerpo["think"]!, Is.False);
    }

    [Test]
    public async Task ViaV1_DescartaTopKYNumCtx_YTraduceMaxOutputTokens()
    {
        var pedido = await Enviar(Proveedores.OpenAICompatible);
        var sinMensajes = pedido.Json;
        sinMensajes.Remove("messages");
        TestContext.Out.WriteLine($"POST {pedido.Ruta}  cuerpo sin mensajes={sinMensajes.ToJsonString()}");

        Assert.That(pedido.Ruta, Is.EqualTo("/v1/chat/completions"));
        Assert.That(pedido.Cuerpo, Does.Not.Contain("top_k"), "TopK se descarta en silencio por /v1");
        Assert.That(pedido.Cuerpo, Does.Not.Contain("num_ctx"), "num_ctx no se puede fijar por pedido por /v1");
        Assert.That((int)sinMensajes["max_completion_tokens"]!, Is.EqualTo(3), "MaxOutputTokens sale como max_completion_tokens");
        Assert.That(sinMensajes.ContainsKey("max_tokens"), Is.False);
        Assert.That((string?)sinMensajes["reasoning_effort"], Is.EqualTo("none"));
        Assert.That((double)sinMensajes["top_p"]!, Is.EqualTo(0.8).Within(1e-6));
    }

    [TestCase(Proveedores.Ollama)]
    [TestCase(Proveedores.OpenAICompatible)]
    public async Task Credencial_ViajaComoEncabezado_YNoEnElCuerpo(string proveedor)
    {
        const string credencial = "CREDENCIAL-DE-PRUEBA";
        var pedido = await Enviar(proveedor, credencial);
        TestContext.Out.WriteLine($"{proveedor}: Authorization={(pedido.Autorizacion is null ? "(ausente)" : "Bearer <credencial>")}; credencial en el cuerpo: {pedido.Cuerpo.Contains(credencial)}");

        Assert.That(pedido.Autorizacion, Is.EqualTo($"Bearer {credencial}"));
        Assert.That(pedido.Cuerpo, Does.Not.Contain(credencial));
    }
}
