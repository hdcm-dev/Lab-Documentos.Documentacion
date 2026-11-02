using Microsoft.Extensions.AI;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Abstractions;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Asistente;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Localidades;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests.Cableado;

/// <summary>
/// Las cinco pruebas del pipeline caché → UseFunctionInvocation → UseOpenTelemetry → cliente, con la
/// composición real y un cliente falso con guion. La pregunta es siempre la misma; la sesión siembra
/// Corrientes y Resistencia, así que en Corrientes hay 1 localidad hasta que se da de alta otra.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class PipelineTests
{
    private const string Pregunta = "¿Cuántas localidades hay cargadas en Corrientes?";

    private static bool EsChat(string span) => span == "chat" || span.StartsWith("chat ", StringComparison.Ordinal);

    [Test]
    public async Task P1_CacheFria_ConUnaHerramienta_DejaOrchestrateTools_Chat_ExecuteTool_Chat()
    {
        var falso = new ClienteGuionado();
        using var host = Anfitrion.Crear(falso);
        using var escucha = new Escucha();
        using var a = host.Sesion("sesion-A");

        var texto = await a.ServiceProvider.GetRequiredService<IAsistente>().PreguntarAsync(Pregunta);

        var spans = escucha.Spans();
        TestContext.Out.WriteLine($"spans: {string.Join(" | ", spans)}");
        Assert.Multiple(() =>
        {
            Assert.That(texto, Is.EqualTo("Hay 1 localidades cargadas en Corrientes."));
            Assert.That(falso.Llamadas, Is.EqualTo(2));
            Assert.That(spans, Has.Count.EqualTo(4));
            Assert.That(spans[0], Is.EqualTo("orchestrate_tools"));
            Assert.That(EsChat(spans[1]), Is.True, spans[1]);
            Assert.That(spans[2], Is.EqualTo($"execute_tool {HerramientasDeLocalidades.ContarPorProvincia}"));
            Assert.That(EsChat(spans[3]), Is.True, spans[3]);
        });
    }

    [Test]
    public async Task P2_CacheCaliente_PorGetResponseAsync_CeroSpans_CeroLlamadas_ContadorEnUno()
    {
        var falso = new ClienteGuionado();
        using var host = Anfitrion.Crear(falso);
        using var escucha = new Escucha();
        using var a = host.Sesion("sesion-A");
        var asistente = a.ServiceProvider.GetRequiredService<IAsistente>();
        await asistente.PreguntarAsync(Pregunta);
        escucha.LimpiarSpans();
        long llamadas = falso.Llamadas, aciertos = escucha.Aciertos, tokens = escucha.RegistrosDeTokens;

        var texto = await asistente.PreguntarAsync(Pregunta);

        // El contador se busca por su NOMBRE en el Meter de la fuente: si falta o se llama distinto, falla.
        Assert.That(escucha.InstrumentoDeAciertosPublicado, Is.True,
            "no hay un instrumento «movilidadurbana.ai.cache.aciertos» en el Meter de la fuente");
        Assert.Multiple(() =>
        {
            Assert.That(texto, Is.EqualTo("Hay 1 localidades cargadas en Corrientes."));
            Assert.That(escucha.Spans(), Is.Empty, "un acierto no aparece en la traza");
            Assert.That(falso.Llamadas - llamadas, Is.Zero, "un acierto no llama al modelo ni vuelve a ejecutar la herramienta");
            Assert.That(escucha.Aciertos - aciertos, Is.EqualTo(1));
            Assert.That(escucha.RegistrosDeTokens - tokens, Is.Zero, "el histograma de tokens no registra nada nuevo");
        });
    }

    [TestCase(null, TestName = "P2b_Streaming_CoalesceStreamingUpdatesPorDefecto_CeroLlamadas_ContadorEnUno")]
    [TestCase(false, TestName = "P2b_Streaming_CoalesceStreamingUpdatesFalse_CeroLlamadas_ContadorEnUno")]
    public async Task P2b_Streaming(bool? coalesce)
    {
        var falso = new ClienteGuionado();
        using var host = Anfitrion.Crear(falso);
        using var escucha = new Escucha();
        using var a = host.Sesion("sesion-A");
        var chat = a.ServiceProvider.GetRequiredService<IChatClient>();
        var cache = chat.GetService<CacheConContador>()!;
        Assert.That(cache.CoalesceStreamingUpdates, Is.True, "el valor por defecto de MEAI 10.11.0");
        if (coalesce is bool c) cache.CoalesceStreamingUpdates = c;
        var opciones = Asistente.CrearOpciones(host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value, HerramientasDeLocalidades.Catalogo);

        var fria = await Unir(chat, opciones);
        long llamadas = falso.Llamadas, aciertos = escucha.Aciertos;
        var caliente = await Unir(chat, opciones);

        Assert.Multiple(() =>
        {
            Assert.That(caliente, Is.EqualTo(fria));
            Assert.That(falso.Llamadas - llamadas, Is.Zero);
            Assert.That(escucha.Aciertos - aciertos, Is.EqualTo(1));
        });
    }

    /// <summary>
    /// Caso rojo de (2b): una caché que sólo sobrescribe ReadCacheAsync. Con CoalesceStreamingUpdates = false
    /// el acierto por streaming pasa por ReadCacheStreamingAsync y el contador queda en 0; con el valor por
    /// defecto (true) pasa por ReadCacheAsync y da 1. La prueba afirma las dos cosas.
    /// </summary>
    [TestCase(true, 1)]
    [TestCase(false, 0)]
    public async Task P2b_CasoRojo_SoloReadCacheAsync(bool coalesce, int aciertosEsperados)
    {
        var falso = new ClienteGuionado();
        using var host = Anfitrion.Crear(falso);
        using var escucha = new Escucha();
        using var a = host.Sesion("sesion-A");
        var cache = new SoloReadCacheAsync(new FunctionInvokingChatClient(falso, null, a.ServiceProvider), NuevoAlmacen())
            { CoalesceStreamingUpdates = coalesce };
        var opciones = Asistente.CrearOpciones(host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value, HerramientasDeLocalidades.Catalogo);

        await Unir(cache, opciones);
        long llamadas = falso.Llamadas, aciertos = escucha.Aciertos;
        await Unir(cache, opciones);

        Assert.Multiple(() =>
        {
            Assert.That(falso.Llamadas - llamadas, Is.Zero, "la caché acertó");
            Assert.That(escucha.Aciertos - aciertos, Is.EqualTo(aciertosEsperados));
        });
    }

    [Test]
    public async Task P3_DosSesiones_MismoTexto_DosFallos_LlamadasEnLasDos()
    {
        var falso = new ClienteGuionado();
        using var host = Anfitrion.Crear(falso);
        using var escucha = new Escucha();

        foreach (var sesion in new[] { "sesion-A", "sesion-B" })
        {
            using var ambito = host.Sesion(sesion);
            long antes = falso.Llamadas;
            await ambito.ServiceProvider.GetRequiredService<IAsistente>().PreguntarAsync(Pregunta);
            Assert.That(falso.Llamadas - antes, Is.EqualTo(2), $"{sesion}: fallo de caché, con la herramienta");
        }
        Assert.That(escucha.Aciertos, Is.Zero);
    }

    [Test]
    public async Task P4_EscrituraConfirmada_InvalidaLaRespuestaCacheada_MismaSesionYMismaInstancia()
    {
        var falso = new ClienteGuionado();
        using var host = Anfitrion.Crear(falso);
        using var escucha = new Escucha();
        using var a = host.Sesion("sesion-A");
        var asistente = a.ServiceProvider.GetRequiredService<IAsistente>();   // misma instancia en los tres pedidos
        var versiones = host.Services.GetRequiredService<IVersionesDeDatos>();

        Assert.That(await asistente.PreguntarAsync(Pregunta), Is.EqualTo("Hay 1 localidades cargadas en Corrientes."));
        Assert.That(await asistente.PreguntarAsync(Pregunta), Is.EqualTo("Hay 1 localidades cargadas en Corrientes."));
        long aciertos = escucha.Aciertos, llamadas = falso.Llamadas;
        Assert.That(aciertos, Is.EqualTo(1), "la lectura quedó cacheada");

        await DarDeAltaGoya(host, "sesion-A");
        Assert.That(versiones.Leer("sesion-A"), Is.EqualTo(1), "VersionDeDatos de 0 a 1");

        escucha.LimpiarSpans();
        var texto = await asistente.PreguntarAsync(Pregunta);

        Assert.Multiple(() =>
        {
            Assert.That(texto, Is.EqualTo("Hay 2 localidades cargadas en Corrientes."));
            Assert.That(falso.Llamadas - llamadas, Is.EqualTo(2), "fallo de caché");
            Assert.That(escucha.Spans(), Does.Contain($"execute_tool {HerramientasDeLocalidades.ContarPorProvincia}"));
            Assert.That(escucha.Aciertos, Is.EqualTo(aciertos), "el contador no cambia");
        });
    }

    /// <summary>Casos rojos de (4): la misma secuencia con una clave mal armada sirve la respuesta vieja.</summary>
    [TestCase("sin VersionDeDatos en la clave")]
    [TestCase("versión leída al crear la instancia")]
    public async Task P4_CasoRojo_ClaveMalArmada_SirveLaRespuestaVieja(string caso)
    {
        var falso = new ClienteGuionado();
        using var host = Anfitrion.Crear(falso);
        using var a = host.Sesion("sesion-A");
        var sesion = a.ServiceProvider.GetRequiredService<ISessionContext>().Id;
        var versiones = host.Services.GetRequiredService<IVersionesDeDatos>();
        var fijos = new object?[] { sesion, versiones.Leer(sesion) };
        Func<object?[]> valores = caso == "sin VersionDeDatos en la clave" ? () => [sesion] : () => fijos;
        var chat = new CacheConContador(new FunctionInvokingChatClient(falso, null, a.ServiceProvider), NuevoAlmacen(), valores);
        var opciones = Asistente.CrearOpciones(host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value, HerramientasDeLocalidades.Catalogo);

        var antes = (await chat.GetResponseAsync(Pregunta, opciones)).Text;
        await DarDeAltaGoya(host, "sesion-A");
        long llamadas = falso.Llamadas;
        var despues = (await chat.GetResponseAsync(Pregunta, opciones)).Text;

        Assert.Multiple(() =>
        {
            Assert.That(falso.Llamadas - llamadas, Is.Zero, $"{caso}: ACIERTO después de la escritura");
            Assert.That(despues, Is.EqualTo(antes).And.EqualTo("Hay 1 localidades cargadas en Corrientes."), "respuesta vieja");
        });
    }

    /// <summary>La escritura confirmada llega por la operación normal, en otro ámbito (otro pedido HTTP).</summary>
    private static async Task DarDeAltaGoya(IHost host, string sesion)
    {
        using var otro = host.Sesion(sesion);
        var r = await otro.ServiceProvider.GetRequiredService<AltaDeLocalidad>().RegistrarAsync(
            new LocalidadModel { Nombre = "Goya", Provincia = "Corrientes", CodigoPostal = "3450", Habitantes = 89959 });
        Assert.That(r.IsSuccess, Is.True, r.Message);
    }

    private static async Task<string> Unir(IChatClient chat, ChatOptions opciones)
    {
        var texto = "";
        await foreach (var u in chat.GetStreamingResponseAsync(Pregunta, opciones)) texto += u.Text;
        return texto;
    }

    private static IDistributedCache NuevoAlmacen() => new MemoryDistributedCache(Options.Create(new MemoryDistributedCacheOptions()));

    private sealed class SoloReadCacheAsync(IChatClient interno, IDistributedCache cache) : DistributedCachingChatClient(interno, cache)
    {
        protected override async Task<ChatResponse?> ReadCacheAsync(string key, CancellationToken cancellationToken)
        {
            var r = await base.ReadCacheAsync(key, cancellationToken);
            if (r is not null) TelemetriaDeIA.Aciertos.Add(1);
            return r;
        }
    }
}
