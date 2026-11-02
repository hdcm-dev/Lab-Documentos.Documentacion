using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Asistente.Application.Abstractions;
using MovilidadUrbana.Asistente.Application.Asistente;
using MovilidadUrbana.Asistente.Infrastructure.AI;
using MovilidadUrbana.Asistente.Presentation.Sesion;
using MovilidadUrbana.Asistente.Tests.Comun;

namespace MovilidadUrbana.Asistente.Tests.Cableado;

/// <summary>Página de chat (sesión por cookie, eventos de etapa, cancelación) y estado de la conversación (D-11).</summary>
[TestFixture]
public sealed class PaginaYConversacionTests
{
    private static async Task<(string? Cookie, string Sesion)> Pedir(string ruta, string? cookie = null)
    {
        var contexto = new DefaultHttpContext();
        contexto.Request.Method = "GET";
        contexto.Request.Path = ruta;
        if (cookie is not null) contexto.Request.Headers.Cookie = $"{CookieDeSesionMiddleware.NombreDeLaCookie}={cookie}";
        var sesion = new SessionContext();
        await new CookieDeSesionMiddleware(_ => Task.CompletedTask).InvokeAsync(contexto, sesion);
        var setCookie = contexto.Response.Headers.SetCookie.ToString();
        var valor = setCookie.Length == 0 ? null : setCookie.Split(';')[0].Split('=')[1];
        return (valor, sesion.Id);
    }

    [Test]
    public async Task Dos_pestanas_sin_cookie_reciben_sesiones_distintas_que_asigna_el_servidor()
    {
        var (cookie1, sesion1) = await Pedir("/");
        var (cookie2, sesion2) = await Pedir("/");
        Assert.Multiple(() =>
        {
            Assert.That(cookie1, Is.Not.Null.And.EqualTo(sesion1));
            Assert.That(cookie2, Is.Not.Null.And.EqualTo(sesion2));
            Assert.That(sesion1, Is.Not.EqualTo(sesion2));
        });
    }

    [Test]
    public async Task Con_cookie_se_conserva_la_sesion_y_un_recurso_estatico_no_emite_cookie()
    {
        var (cookie, sesion) = await Pedir("/", "sesion-existente");
        var (cookieCss, _) = await Pedir("/app.css");
        Assert.Multiple(() =>
        {
            Assert.That(cookie, Is.Null);
            Assert.That(sesion, Is.EqualTo("sesion-existente"));
            Assert.That(cookieCss, Is.Null);
        });
    }

    [Test]
    public async Task EtapaIniciada_llega_antes_que_cualquier_TextoParcial_y_Final_cierra()
    {
        var falso = new ClienteFalso(Responde.Intencion("Ayuda"), _ => Responde.Texto("Lleva 4 dígitos [LocalidadPolicy.RequisitoDelCodigoPostal]."));
        using var comp = new Composicion(falso);
        await using var ambito = comp.Ambito("p40");
        var eventos = new List<EventoDelAsistente>();
        await foreach (var e in ambito.ServiceProvider.GetRequiredService<IAsistenteDeMovilidad>().ConversarAsync("p40", "c1", "¿Cuántos dígitos?", CancellationToken.None))
            eventos.Add(e);

        var primeraEtapa = eventos.FindIndex(e => e is EtapaIniciada);
        var primerTexto = eventos.FindIndex(e => e is TextoParcial);
        Assert.Multiple(() =>
        {
            Assert.That(primeraEtapa, Is.EqualTo(0));
            Assert.That(primerTexto, Is.GreaterThan(primeraEtapa));
            Assert.That(eventos.OfType<EtapaIniciada>().Select(e => e.Nombre), Is.EqualTo(new[] { "interpretar", "leer-requisitos" }));
            Assert.That(eventos[^1], Is.TypeOf<Final>());
        });
    }

    [Test]
    public async Task Cancelar_corta_el_pedido_en_menos_de_un_segundo()
    {
        var falso = new ClienteFalsoLento(ClienteFalso.Reactivo(_ => Responde.Json(new { intencion = "Ayuda" })), TimeSpan.FromSeconds(30));
        using var comp = new Composicion(falso);
        await using var ambito = comp.Ambito("p14");
        using var cancelacion = new CancellationTokenSource(TimeSpan.FromMilliseconds(200));
        var reloj = Stopwatch.StartNew();

        await Assert.CatchAsync<OperationCanceledException>(async () =>
        {
            await foreach (var _ in ambito.ServiceProvider.GetRequiredService<IAsistenteDeMovilidad>().ConversarAsync("p14", "c1", "hola", cancelacion.Token)) { }
        });
        Assert.That(reloj.Elapsed, Is.LessThan(TimeSpan.FromSeconds(1)));
    }

    [Test]
    public async Task La_sesion_del_pedido_tiene_que_ser_la_del_ambito()
    {
        using var comp = new Composicion(new ClienteFalso());
        await using var ambito = comp.Ambito("sesion-A");
        await Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
            await foreach (var _ in ambito.ServiceProvider.GetRequiredService<IAsistenteDeMovilidad>().ConversarAsync("sesion-B", "c1", "hola", CancellationToken.None)) { }
        });
    }

    private sealed class RelojManual : TimeProvider
    {
        public DateTimeOffset Ahora { get; set; } = new(2026, 10, 28, 12, 0, 0, TimeSpan.Zero);
        public override DateTimeOffset GetUtcNow() => Ahora;
    }

    [Test]
    public void D11_el_historial_se_separa_por_sesion_y_conversacion_y_vence_a_los_30_minutos()
    {
        var reloj = new RelojManual();
        var historial = new HistorialEnMemoria(Options.Create(new OpcionesDeIA()), reloj);
        historial.Agregar("A", "c1", new TurnoDeConversacion(RolDelTurno.Persona, "hola de A"));
        historial.Agregar("B", "c1", new TurnoDeConversacion(RolDelTurno.Persona, "hola de B"));

        Assert.Multiple(() =>
        {
            Assert.That(historial.Leer("A", "c1").Single().Texto, Is.EqualTo("hola de A"));
            Assert.That(historial.Leer("B", "c1").Single().Texto, Is.EqualTo("hola de B"), "mismo ConversacionId, otra sesión: otro historial");
            Assert.That(historial.Leer("A", "c2"), Is.Empty);
        });

        reloj.Ahora += TimeSpan.FromMinutes(29);
        Assert.That(historial.Leer("A", "c1"), Has.Count.EqualTo(1));
        reloj.Ahora += TimeSpan.FromMinutes(31);
        Assert.That(historial.Leer("A", "c1"), Is.Empty, "vencido por inactividad");
    }

    [Test]
    public void D11_el_historial_conserva_solo_los_ultimos_turnos()
    {
        var historial = new HistorialEnMemoria(Options.Create(new OpcionesDeIA()), TimeProvider.System);
        for (var i = 0; i < 10; i++) historial.Agregar("A", "c1", new TurnoDeConversacion(RolDelTurno.Persona, $"t{i}"));
        Assert.That(historial.Leer("A", "c1").Select(t => t.Texto), Is.EqualTo(new[] { "t4", "t5", "t6", "t7", "t8", "t9" }));
    }

    [Test]
    public void D11_el_puerto_y_sus_eventos_no_exponen_tipos_de_MEAI()
    {
        var tipos = new[] { typeof(IAsistenteDeMovilidad), typeof(EventoDelAsistente), typeof(EtapaIniciada), typeof(TextoParcial), typeof(AccionPropuesta), typeof(Final), typeof(DatosDeAccion) };
        Assert.That(ReglaDeCapas.Violaciones(tipos, ns => ns.StartsWith("Microsoft.Extensions.AI")), Is.Empty);
    }

    [Test]
    public void D5_el_corpus_de_la_ayuda_son_los_12_requisitos_que_enuncia_el_codigo()
    {
        var delCodigo = new[] { typeof(ApiWeb.Application.Localidades.LocalidadPolicy), typeof(ApiWeb.Application.Encuestas.EncuestaPolicy) }
            .SelectMany(t => t.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
                .Where(p => p.PropertyType == typeof(string))
                .Select(p => (Fuente: $"{t.Name}.{p.Name}", Texto: (string)p.GetValue(null)!)))
            .ToList();
        var corpus = Application.Ayuda.RequisitosDelDominio.Todos.Select(r => (r.Fuente, r.Texto)).ToList();
        Assert.Multiple(() =>
        {
            Assert.That(corpus, Has.Count.EqualTo(12));
            Assert.That(corpus, Is.EquivalentTo(delCodigo));
        });
    }
}
