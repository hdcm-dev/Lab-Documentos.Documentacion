using MovilidadUrbana.ApiWeb.Domain.Rules;
using MovilidadUrbana.PruebaDeArquitectura.Application.Propuestas;
using MovilidadUrbana.PruebaDeArquitectura.Infrastructure.AI;
using MovilidadUrbana.PruebaDeArquitectura.Presentation.Herramientas;
using static MovilidadUrbana.PruebaDeArquitectura.Tests.Cableado.Capas;

namespace MovilidadUrbana.PruebaDeArquitectura.Tests.Cableado;

/// <summary>
/// La regla de dependencias sobre la aplicación compilada (la copia del caso base más la capa de IA).
/// Cada regla primero comprueba que inspeccionó algo: una regla sobre cero tipos da verde y no prueba nada.
/// </summary>
[TestFixture, Category("Regla")]
public sealed class ReglaDeDependenciasTests
{
    /// <summary>
    /// Excepciones declaradas: dependencias que la regla tolera a sabiendas, con su motivo. Fuera de esta
    /// lista, ninguna.
    /// </summary>
    private static readonly (string Origen, string Destino, string Motivo)[] Excepciones =
    [
        ("MovilidadUrbana.ApiWeb.Sessions.SessionHeaderMiddleware", "MovilidadUrbana.ApiWeb.Infrastructure.Sessions.SessionContext",
         "heredada del caso base: el middleware fija la sesión en la clase concreta, que es la que tiene Set"),
    ];

    private static IReadOnlyList<string> SinExcepciones(IEnumerable<ReglaDeCapas.Violacion> violaciones) =>
        violaciones
            .Where(v => !Excepciones.Any(e => e.Origen == (v.Origen.DeclaringType ?? v.Origen).FullName && e.Destino == v.Destino.FullName))
            .Select(v => v.ToString())
            .ToList();

    private static IReadOnlyList<Type> Inspeccionar(string[] capa, params Type[] debeIncluir)
    {
        var tipos = TiposDe(Aplicacion, capa);
        Assert.That(tipos, Is.SupersetOf(debeIncluir), "la capa no tiene los tipos que se esperaba inspeccionar");
        return tipos;
    }

    [Test]
    public void El_nucleo_no_conoce_IA_ni_acceso_a_datos_ni_HTTP_ni_las_capas_de_afuera()
    {
        var tipos = Inspeccionar(Nucleo, typeof(LocalidadRules), typeof(ApiWeb.Application.Localidades.LocalidadService),
            typeof(IExtractorDeLocalidad), typeof(ProponerLocalidadDesdeTexto));

        var violaciones = ReglaDeCapas.Violaciones(tipos, t =>
            En(t, IA) || En(t, AccesoADatos) || En(t, Http) || En(t, Infraestructura) || En(t, Presentacion));

        TestContext.Out.WriteLine($"Núcleo: {tipos.Count} tipos inspeccionados.");
        Assert.That(SinExcepciones(violaciones), Is.Empty);
    }

    [Test]
    public void El_dominio_no_conoce_Application()
    {
        var tipos = Inspeccionar(Dominio, typeof(LocalidadRules));
        var violaciones = ReglaDeCapas.Violaciones(tipos, t => En(t, Nucleo) && !En(t, Dominio));
        Assert.That(SinExcepciones(violaciones), Is.Empty);
    }

    [Test]
    public void Infrastructure_no_usa_casos_de_uso_ni_Presentacion()
    {
        var tipos = Inspeccionar(Infraestructura, typeof(ExtractorDeLocalidadLlm));
        var violaciones = ReglaDeCapas.Violaciones(tipos, t => EsCasoDeUso(t) || En(t, Presentacion));
        Assert.That(SinExcepciones(violaciones), Is.Empty);
    }

    [Test]
    public void La_persistencia_no_conoce_IA()
    {
        var tipos = Inspeccionar(Persistencia, typeof(ApiWeb.Infrastructure.Persistence.LocalidadRepository));
        Assert.That(SinExcepciones(ReglaDeCapas.Violaciones(tipos, t => En(t, IA))), Is.Empty);
    }

    [Test]
    public void El_adaptador_de_IA_no_conoce_el_acceso_a_datos()
    {
        var tipos = Inspeccionar(AdaptadorDeIA, typeof(ExtractorDeLocalidadLlm));
        var violaciones = ReglaDeCapas.Violaciones(tipos, t => En(t, AccesoADatos) || En(t, Persistencia));
        Assert.That(SinExcepciones(violaciones), Is.Empty);
    }

    [Test]
    public void Presentacion_no_conoce_acceso_a_datos_ni_proveedor_de_IA_ni_Infrastructure()
    {
        var tipos = Inspeccionar(Presentacion, typeof(HerramientasDeLectura), typeof(ApiWeb.Controllers.LocalidadesController));
        var violaciones = ReglaDeCapas.Violaciones(tipos, t => En(t, AccesoADatos) || En(t, ProveedorDeIA) || En(t, Infraestructura));

        foreach (var v in violaciones) TestContext.Out.WriteLine($"encontrada: {v}");
        Assert.That(SinExcepciones(violaciones), Is.Empty);
    }

    [Test]
    public void Cada_excepcion_declarada_sigue_existiendo()
    {
        // Si el código deja de necesitar una excepción, la lista tiene que achicarse: una excepción que no
        // excusa nada es un agujero esperando.
        var todas = ReglaDeCapas.Violaciones(TiposDe(Aplicacion, Presentacion), t => En(t, Infraestructura));
        foreach (var e in Excepciones)
            Assert.That(todas.Any(v => (v.Origen.DeclaringType ?? v.Origen).FullName == e.Origen && v.Destino.FullName == e.Destino),
                $"la excepción {e.Origen} → {e.Destino} ya no hace falta");
    }
}
