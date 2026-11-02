using System.Diagnostics;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace MovilidadUrbana.Streaming.Tests.Cableado;

/// <summary>Sin modelo y deterministas: corren siempre.</summary>
[TestFixture, Category("Cableado")]
public sealed class StreamingCableadoTests
{
    private static readonly string[] Guion = ["La encuesta ", "pide nombre, ", "edad, localidad ", "y medios de transporte."];

    private static AsistenteDeLaEncuesta Asistente(IChatClient cliente) => new(cliente, Options.Create(new OpcionesDeIA
    {
        TimeoutSegundos = 300,
        NumCtx = 8192,
        LargoMaximoDeEntrada = 2000,
        Muestreo = new() { Temperatura = 0.7f, TopP = 0.8f, TopK = 20, PresencePenalty = 1.5f },
    }));

    [Test]
    public async Task Los_fragmentos_llegan_en_orden_y_recomponen_la_respuesta()
    {
        var cliente = new ClienteFalsoEnStreaming(Guion, TimeSpan.FromMilliseconds(10));
        var asistente = Asistente(cliente);
        var historial = asistente.NuevaConversacion();
        var recibidos = new List<string>();

        var r = await asistente.ResponderAsync(historial, ContextoDeLaEncuesta.PreguntaDeEjemplo, recibidos.Add);

        Assert.That(recibidos, Is.EqualTo(Guion));                          // uno por fragmento, en orden
        Assert.That(r.Texto, Is.EqualTo(string.Concat(Guion)));
        Assert.That(r.Respuesta!.Text, Is.EqualTo(r.Texto));                 // ToChatResponse recompone lo mismo
        Assert.That(r.Respuesta.FinishReason, Is.EqualTo(ChatFinishReason.Stop));
        Assert.That(r.Respuesta.Usage!.InputTokenCount, Is.EqualTo(120));    // el uso llega en el último fragmento
        Assert.That(r.Fragmentos, Is.EqualTo(Guion.Length + 1));
        Assert.That(historial.Select(m => m.Role), Is.EqualTo(new[] { ChatRole.System, ChatRole.User, ChatRole.Assistant }));
        Assert.That(historial[^1].Text, Is.EqualTo(string.Concat(Guion)));  // un solo mensaje, no uno por fragmento
    }

    [TestCase(false, TestName = "Cancelar a mitad (el proveedor lanza OperationCanceledException)")]
    [TestCase(true, TestName = "Cancelar a mitad (el proveedor termina la enumeración sin lanzar)")]
    public async Task Cancelar_a_mitad_corta_en_menos_de_un_segundo_y_no_toca_el_historial(bool cortaEnSilencio)
    {
        // Entre fragmentos hay 5 s: si el token no llegara al cliente, la prueba tardaría 15 s más.
        var cliente = new ClienteFalsoEnStreaming(Guion, TimeSpan.FromSeconds(5), cortaEnSilencio);
        var asistente = Asistente(cliente);
        var historial = asistente.NuevaConversacion();
        using var cts = new CancellationTokenSource();
        var reloj = new Stopwatch();

        var r = await asistente.ResponderAsync(historial, ContextoDeLaEncuesta.PreguntaDeEjemplo,
            _ => { cts.Cancel(); reloj.Start(); },                           // cancela al primer texto
            ct: cts.Token);

        Assert.That(r.Cancelada, Is.True);
        Assert.That(r.Texto, Is.EqualTo(Guion[0]));
        Assert.That(cliente.FragmentosEmitidos, Is.EqualTo(1));
        Assert.That(cliente.VioLaCancelacion, Is.True);
        Assert.That(reloj.Elapsed, Is.LessThan(TimeSpan.FromSeconds(1)));
        Assert.That(historial, Has.Count.EqualTo(1));                        // sólo el mensaje de sistema
        Assert.That(r.Respuesta, Is.Null);
    }

    [Test]
    public async Task Las_opciones_del_pedido_salen_de_OpcionesDeIA()
    {
        var cliente = new ClienteFalsoEnStreaming(Guion, TimeSpan.Zero);
        var asistente = Asistente(cliente);

        await asistente.ResponderAsync(asistente.NuevaConversacion(), "¿Qué medios de transporte acepta?", _ => { },
            asistente.CrearOpcionesDeChat(semilla: 7));

        var o = cliente.UltimasOpciones!;
        Assert.That(o.AdditionalProperties!["num_ctx"], Is.EqualTo(8192));
        Assert.That(o.Reasoning!.Effort, Is.EqualTo(ReasoningEffort.None));
        Assert.That((o.Temperature, o.TopP, o.TopK, o.PresencePenalty, o.Seed), Is.EqualTo((0.7f, 0.8f, 20, 1.5f, 7L)));
        Assert.That(cliente.UltimosMensajes[^1].Text, Is.EqualTo("¿Qué medios de transporte acepta?"));
    }

    [Test]
    public async Task Una_pregunta_mas_larga_que_el_maximo_no_llama_al_modelo()
    {
        var cliente = new ClienteFalsoEnStreaming(Guion, TimeSpan.Zero);
        var asistente = Asistente(cliente);

        await Assert.ThrowsAsync<ArgumentException>(() =>
            asistente.ResponderAsync(asistente.NuevaConversacion(), new string('a', 2001), _ => { }));
        Assert.That(cliente.Llamadas, Is.Zero);
    }

    [Test]
    public async Task Sin_TimeoutSegundos_el_host_no_arranca()
    {
        var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
        {
            EnvironmentName = "Production",
            ContentRootPath = Path.GetTempPath(),
            Configuration = new ConfigurationManager(),
        });
        builder.AgregarIA();
        using var host = builder.Build();

        var error = await Assert.ThrowsAsync<OptionsValidationException>(() => host.StartAsync());
        Assert.That(error!.Message, Does.Contain(nameof(OpcionesDeIA.TimeoutSegundos)));
    }

    [TestCase(0, 10, "[0.00; 0.28]")]
    [TestCase(12, 16, "[0.51; 0.90]")]
    [TestCase(10, 10, "[0.72; 1.00]")]
    public void El_intervalo_de_Wilson_del_informe_reproduce_los_valores_publicados(int k, int n, string esperado) =>
        Assert.That(ConModelo.StreamingConModeloTests.Wilson(k, n), Is.EqualTo(esperado));
}
