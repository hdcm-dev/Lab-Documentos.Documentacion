using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests.Cableado;

/// <summary>
/// La API entera (Program.cs) en memoria, con el cliente del proveedor reemplazado por uno falso: el
/// limitador de concurrencia en la entrada HTTP y el largo máximo de entrada.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class EntradaHttpTests
{
    private static WebApplicationFactory<Program> Api(IChatClient falso) =>
        new WebApplicationFactory<Program>().WithWebHostBuilder(b => b.ConfigureTestServices(s =>
            s.AddKeyedSingleton(ComposicionDeIA.ClaveDelProveedor, falso)));

    /// <summary>Cliente falso de 2 s, Permisos = 1 y Cola = 2: los pedidos 1–3 en 200 y el 4.º en 503 con Retry-After.</summary>
    [Test]
    public async Task CuartoPedidoSimultaneo_Recibe503ConRetryAfter()
    {
        var falso = new ClienteGuionado { Responder = _ => "Listo.", Demora = TimeSpan.FromSeconds(2) };
        await using var api = Api(falso);
        var concurrencia = api.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value.Concurrencia;
        Assert.That((concurrencia.Permisos, concurrencia.Cola), Is.EqualTo((1, 2)), "valores de appsettings.json");
        using var http = api.CreateClient();
        // Calentamiento: un pedido inválido (400, sin llamar al modelo) para que el primer pedido medido no
        // llegue tarde por la compilación JIT y cambie el orden de llegada.
        await http.PostAsJsonAsync("/api/v1/asistente", new { texto = "" });

        var pedidos = Enumerable.Range(1, 4).Select(async i =>
        {
            await Task.Delay(i * 250);
            var r = await http.PostAsJsonAsync("/api/v1/asistente", new { texto = $"Pregunta {i} sobre las localidades de Chaco" });
            return (Pedido: i, Codigo: r.StatusCode, Reintentar: r.Headers.RetryAfter?.ToString());
        }).ToArray();
        var resultados = await Task.WhenAll(pedidos);
        foreach (var r in resultados) TestContext.Out.WriteLine($"pedido {r.Pedido}: {(int)r.Codigo} Retry-After={r.Reintentar ?? "-"}");

        Assert.Multiple(() =>
        {
            Assert.That(resultados.Take(3).Select(r => r.Codigo), Has.All.EqualTo(HttpStatusCode.OK));
            Assert.That(resultados[3].Codigo, Is.EqualTo(HttpStatusCode.ServiceUnavailable));
            Assert.That(resultados[3].Reintentar, Is.EqualTo(concurrencia.ReintentarEnSegundos.ToString()));
            Assert.That(falso.Llamadas, Is.EqualTo(3));
        });
    }

    [Test]
    public async Task EntradaDe2001Caracteres_Responde400_SinLlamarAlModelo()
    {
        var falso = new ClienteGuionado { Responder = _ => "no debería llamarse" };
        await using var api = Api(falso);
        using var http = api.CreateClient();

        var r = await http.PostAsJsonAsync("/api/v1/asistente", new { texto = new string('a', 2001) });

        Assert.Multiple(() =>
        {
            Assert.That(r.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(falso.Llamadas, Is.Zero);
        });
    }

    [Test]
    public async Task UnaSesionPorEncabezado_LaRespuestaDevuelveElMismoId()
    {
        var falso = new ClienteGuionado { Responder = _ => "Listo." };
        await using var api = Api(falso);
        using var http = api.CreateClient();
        using var pedido = new HttpRequestMessage(HttpMethod.Post, "/api/v1/asistente") { Content = JsonContent.Create(new { texto = "Hola" }) };
        pedido.Headers.Add("X-Sesion-Id", "sesion-de-prueba");

        var r = await http.SendAsync(pedido);

        Assert.That(r.Headers.GetValues("X-Sesion-Id").Single(), Is.EqualTo("sesion-de-prueba"));
    }
}
