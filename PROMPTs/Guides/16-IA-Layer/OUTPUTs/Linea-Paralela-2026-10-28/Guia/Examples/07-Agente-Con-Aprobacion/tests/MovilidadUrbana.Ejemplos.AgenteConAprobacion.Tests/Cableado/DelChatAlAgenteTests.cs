using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI.DelChatAlAgente;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.SinModelo;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.AgenteConAprobacion.Tests.Cableado;

/// <summary>El paso 4.1 → 4.2 sobre el mismo IChatClient, sin modelo.</summary>
[TestFixture, Category("Cableado")]
public sealed class DelChatAlAgenteTests
{
    private static (IChatClient Chat, OpcionesDeIA Ia) Piezas(Sesion s) =>
        (s.Servicios.GetRequiredService<IChatClient>(), s.Servicios.GetRequiredService<IOptions<OpcionesDeIA>>().Value);

    [Test]
    public async Task LlamadaUnica_PideLaHerramientaYRespondeConElCasoDeUso()
    {
        var guion = new ClienteGuionado();
        using var e = new Entorno(guion);
        using var s = e.Abrir("sesion-A");
        var (chat, ia) = Piezas(s);

        var texto = await LlamadaUnica.PreguntarAsync(chat, s.Herramientas, FabricaDeOpcionesDeChat.Crear(ia), "¿Cuántas localidades hay en Chaco?");

        Assert.Multiple(() =>
        {
            Assert.That(texto, Does.Contain("1 localidad"));
            Assert.That(guion.Llamadas, Is.EqualTo(2), "pedido de herramienta + respuesta final");
            Assert.That(guion.OpcionesRecibidas[0]!.Tools!.Select(t => t.Name), Is.EqualTo(new[] { "contar_localidades" }));
            Assert.That(guion.OpcionesRecibidas[0]!.AdditionalProperties!["num_ctx"], Is.EqualTo(8192));
        });
    }

    [Test]
    public async Task AgenteDeMaf_MismoClienteConSesionDeDosTurnos()
    {
        var guion = new ClienteGuionado();
        using var e = new Entorno(guion);
        using var s = e.Abrir("sesion-A");
        var (chat, ia) = Piezas(s);

        var agente = AgenteDeMaf.Crear(chat, s.Herramientas);
        var respuestas = await AgenteDeMaf.ConversarAsync(agente, FabricaDeOpcionesDeChat.Crear(ia), ["¿Cuántas localidades hay en Chaco?", "¿Y en Corrientes?"]);

        // El primer pedido del segundo turno trae el historial del primero: la sesión lo guardó.
        var segundoTurno = guion.MensajesRecibidos[2];
        Assert.Multiple(() =>
        {
            Assert.That(respuestas, Is.EqualTo(new[] { "En Chaco hay 1 localidad(es) cargada(s).", "En Corrientes hay 1 localidad(es) cargada(s)." }));
            Assert.That(guion.Llamadas, Is.EqualTo(4));
            Assert.That(segundoTurno.Any(m => m.Role == ChatRole.User && m.Text.Contains("Chaco")), Is.True, "falta el turno 1 en el historial");
            Assert.That(guion.OpcionesRecibidas[0]!.Tools!.Select(t => t.Name), Is.EqualTo(new[] { "contar_localidades" }));
            Assert.That(guion.OpcionesRecibidas[0]!.AdditionalProperties!["num_ctx"], Is.EqualTo(8192), "las opciones de ejecución no llegaron");
            Assert.That(guion.OpcionesRecibidas[0]!.Instructions ?? string.Join(" ", guion.MensajesRecibidos[0].Where(m => m.Role == ChatRole.System).Select(m => m.Text)),
                Does.Contain("ABM de localidades"));
        });
    }

    /// <summary>
    /// El agente usa el mismo bucle (y el mismo corte) que la llamada única: MAF no le agrega otro
    /// FunctionInvokingChatClient con sus valores por defecto.
    /// </summary>
    [Test]
    public async Task ElCorteDelBucleEsElMismoEnLosDosPasos()
    {
        var args = new Dictionary<string, object?> { ["provincia"] = "Chaco" };
        var guionA = ClientePorPasos.SiemprePide("contar_localidades", args);
        var guionB = ClientePorPasos.SiemprePide("contar_localidades", args);
        int llamadasA, llamadasB, maximo;

        using (var e = new Entorno(guionA))
        using (var s = e.Abrir("sesion-A"))
        {
            var (chat, ia) = Piezas(s);
            maximo = ia.Herramientas.MaximoDeIteraciones;
            await LlamadaUnica.PreguntarAsync(chat, s.Herramientas, FabricaDeOpcionesDeChat.Crear(ia), "¿Cuántas localidades hay en Chaco?");
            llamadasA = guionA.Llamadas;
        }
        using (var e = new Entorno(guionB))
        using (var s = e.Abrir("sesion-A"))
        {
            var (chat, ia) = Piezas(s);
            await AgenteDeMaf.ConversarAsync(AgenteDeMaf.Crear(chat, s.Herramientas), FabricaDeOpcionesDeChat.Crear(ia), ["¿Cuántas localidades hay en Chaco?"]);
            llamadasB = guionB.Llamadas;
        }

        TestContext.Out.WriteLine($"MaximoDeIteraciones={maximo}; llamadas al cliente: llamada única {llamadasA}, agente de MAF {llamadasB}");
        Assert.Multiple(() =>
        {
            Assert.That(llamadasB, Is.EqualTo(llamadasA));
            Assert.That(llamadasA, Is.LessThanOrEqualTo(maximo + 1));
        });
    }
}
