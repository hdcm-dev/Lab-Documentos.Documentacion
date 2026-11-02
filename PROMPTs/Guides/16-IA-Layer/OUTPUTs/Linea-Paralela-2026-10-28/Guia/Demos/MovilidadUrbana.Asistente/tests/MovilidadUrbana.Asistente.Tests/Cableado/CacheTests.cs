using System.Diagnostics.Metrics;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Asistente.Infrastructure.AI;
using MovilidadUrbana.Asistente.Tests.Comun;

namespace MovilidadUrbana.Asistente.Tests.Cableado;

/// <summary>
/// La caché de la demo está apagada por defecto. Si se prende (AI:Cache:Habilitada), rige la regla (b):
/// sólo pedidos sin herramientas, clave con la sesión y aciertos contados por nombre en los dos caminos.
/// </summary>
[TestFixture]
public sealed class CacheTests
{
    private static readonly Dictionary<string, string?> ConCache = new() { ["AI:Cache:Habilitada"] = "true" };

    /// <summary>Escucha el contador por su nombre. Si el instrumento no existe o se llama distinto, queda en 0.</summary>
    private sealed class Aciertos : IDisposable
    {
        private readonly MeterListener _oyente = new();
        private long _valor;
        public long Valor => Interlocked.Read(ref _valor);

        public Aciertos()
        {
            _oyente.InstrumentPublished = (i, l) =>
            {
                if (i.Meter.Name == TelemetriaDeIA.Fuente && i.Name == "movilidadurbana.ai.cache.aciertos") l.EnableMeasurementEvents(i);
            };
            _oyente.SetMeasurementEventCallback<long>((_, v, _, _) => Interlocked.Add(ref _valor, v));
            _oyente.Start();
        }

        public void Dispose() => _oyente.Dispose();
    }

    private static async Task<string> Streaming(IChatClient chat, string texto)
    {
        var partes = new List<string>();
        await foreach (var u in chat.GetStreamingResponseAsync(texto)) partes.Add(u.Text);
        return string.Concat(partes);
    }

    [Test]
    public async Task Cache_por_GetResponseAsync_un_acierto_no_llama_al_cliente_y_cuenta_1()
    {
        using var aciertos = new Aciertos();
        var falso = ClienteFalso.Reactivo(_ => Responde.Texto("Lleva 4 dígitos."));
        using var comp = new Composicion(falso, configuracionExtra: ConCache);
        await using var ambito = comp.Ambito("cache-1");
        var chat = ambito.ServiceProvider.GetRequiredService<IChatClient>();

        await chat.GetResponseAsync("¿Cuántos dígitos?");
        await chat.GetResponseAsync("¿Cuántos dígitos?");

        Assert.Multiple(() =>
        {
            Assert.That(falso.CantidadDeLlamadas, Is.EqualTo(1));
            Assert.That(aciertos.Valor, Is.EqualTo(1));
        });
    }

    [TestCase(true, TestName = "Cache_2b_streaming_con_CoalesceStreamingUpdates_por_defecto_cuenta_1")]
    [TestCase(false, TestName = "Cache_2b_streaming_con_CoalesceStreamingUpdates_false_cuenta_1")]
    public async Task Cache_por_streaming(bool coalescer)
    {
        using var aciertos = new Aciertos();
        var falso = ClienteFalso.Reactivo(_ => Responde.Texto("Lleva 4 dígitos, según el requisito del código postal."));
        using var comp = new Composicion(falso, configuracionExtra: ConCache);
        await using var ambito = comp.Ambito("cache-2b");
        var chat = ambito.ServiceProvider.GetRequiredService<IChatClient>();
        chat.GetService<CacheConContador>()!.CoalesceStreamingUpdates = coalescer;

        var primera = await Streaming(chat, "¿Cuántos dígitos?");
        var segunda = await Streaming(chat, "¿Cuántos dígitos?");

        Assert.Multiple(() =>
        {
            Assert.That(segunda, Is.EqualTo(primera));
            Assert.That(falso.CantidadDeLlamadas, Is.EqualTo(1));
            Assert.That(aciertos.Valor, Is.EqualTo(1), "1 por acierto, no por fragmento");
        });
    }

    /// <summary>Caso rojo: una caché que sólo sobrescribe ReadCacheAsync.</summary>
    private sealed class SoloReadCacheAsync(IChatClient interno, IDistributedCache almacen) : DistributedCachingChatClient(interno, almacen)
    {
        protected override async Task<ChatResponse?> ReadCacheAsync(string key, CancellationToken cancellationToken)
        {
            var r = await base.ReadCacheAsync(key, cancellationToken);
            if (r is not null) TelemetriaDeIA.Aciertos.Add(1);
            return r;
        }
    }

    [TestCase(false, 0, TestName = "Cache_2b_caso_rojo_sin_ReadCacheStreamingAsync_y_sin_coalescer_cuenta_0")]
    [TestCase(true, 1, TestName = "Cache_2b_caso_rojo_sin_ReadCacheStreamingAsync_coalesciendo_cuenta_1")]
    public async Task Cache_caso_rojo(bool coalescer, long esperado)
    {
        using var aciertos = new Aciertos();
        var falso = ClienteFalso.Reactivo(_ => Responde.Texto("Lleva 4 dígitos, según el requisito del código postal."));
        using var cache = new SoloReadCacheAsync(falso, new MemoryDistributedCache(Options.Create(new MemoryDistributedCacheOptions())))
        { CoalesceStreamingUpdates = coalescer };

        await Streaming(cache, "¿Cuántos dígitos?");
        await Streaming(cache, "¿Cuántos dígitos?");

        Assert.Multiple(() =>
        {
            Assert.That(falso.CantidadDeLlamadas, Is.EqualTo(1), "hubo acierto");
            Assert.That(aciertos.Valor, Is.EqualTo(esperado));
        });
    }

    [Test]
    public async Task Cache_regla_b_un_pedido_con_herramientas_no_se_cachea()
    {
        using var aciertos = new Aciertos();
        var falso = ClienteFalso.Reactivo(v => v.UltimoResultado is null ? Responde.Llamar("contar_localidades") : Responde.EcoDelResultado(v));
        using var comp = new Composicion(falso, configuracionExtra: ConCache);
        await using var ambito = comp.Ambito("cache-b");
        var chat = ambito.ServiceProvider.GetRequiredService<IChatClient>();
        var opciones = new ChatOptions { Tools = [.. CatalogoDeHerramientas.Todas] };

        await chat.GetResponseAsync("¿Cuántas localidades tengo?", opciones);
        await chat.GetResponseAsync("¿Cuántas localidades tengo?", opciones);

        Assert.Multiple(() =>
        {
            Assert.That(falso.CantidadDeLlamadas, Is.EqualTo(4), "las dos vueltas llegan al cliente y ejecutan la herramienta");
            Assert.That(aciertos.Valor, Is.Zero);
        });
    }

    [Test]
    public async Task Cache_dos_sesiones_con_el_mismo_texto_dan_dos_fallos()
    {
        using var aciertos = new Aciertos();
        var falso = ClienteFalso.Reactivo(_ => Responde.Texto("Lleva 4 dígitos."));
        using var comp = new Composicion(falso, configuracionExtra: ConCache);
        foreach (var sesion in new[] { "sesion-A", "sesion-B" })
        {
            await using var ambito = comp.Ambito(sesion);
            await ambito.ServiceProvider.GetRequiredService<IChatClient>().GetResponseAsync("¿Cuántos dígitos?");
        }
        Assert.Multiple(() =>
        {
            Assert.That(falso.CantidadDeLlamadas, Is.EqualTo(2));
            Assert.That(aciertos.Valor, Is.Zero);
        });
    }
}
