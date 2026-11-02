using System.Reflection;
using static MovilidadUrbana.PruebaDeArquitectura.Tests.Cableado.Capas;

namespace MovilidadUrbana.PruebaDeArquitectura.Tests.Cableado;

/// <summary>
/// La regla detecta lo que dice detectar. Las mutaciones de <c>src/.../Mutaciones/</c> se compilan dentro de
/// este ensamblado y se inspeccionan con el mismo predicado de las reglas. Dos de ellas son agujeros
/// declarados: la prueba afirma que <b>no</b> se ven, para que nadie crea que se ven.
/// </summary>
[TestFixture, Category("CasosRojos")]
public sealed class CasosRojosTests
{
    private static readonly Assembly Pruebas = typeof(CasosRojosTests).Assembly;

    private static IReadOnlyList<Type> Mutante(string nombre) =>
        Pruebas.GetTypes().Where(t => t.Namespace?.EndsWith(".Mutantes." + nombre, StringComparison.Ordinal) == true).ToList();

    private static bool ProhibidoEnElNucleo(Type t) =>
        En(t, IA) || En(t, AccesoADatos) || En(t, Http) || En(t, Infraestructura) || En(t, Presentacion);

    private static IReadOnlyList<ReglaDeCapas.Violacion> Inspeccionar(string nombre, bool leerCuerpo = true)
    {
        var tipos = Mutante(nombre);
        Assert.That(tipos, Is.Not.Empty, $"no se compiló la mutación {nombre}");
        var v = ReglaDeCapas.Violaciones(tipos, ProhibidoEnElNucleo, leerCuerpo);
        foreach (var x in v) TestContext.Out.WriteLine(x);
        return v;
    }

    [Test]
    public void R4_global_using_y_propiedad_ChatMessage_se_detecta()
    {
        var v = Inspeccionar("R4");
        Assert.That(v.Select(x => x.Donde), Does.Contain("propiedad UltimoMensaje").And.Contain("propiedad MensajeOriginal"));
        Assert.That(v.Select(x => x.Destino.FullName), Has.All.EqualTo("Microsoft.Extensions.AI.ChatMessage"));
    }

    [Test]
    public void Uso_solo_dentro_de_un_cuerpo_de_metodo_la_firma_no_lo_ve_y_el_IL_si()
    {
        Assert.That(Inspeccionar("Cuerpo", leerCuerpo: false), Is.Empty, "sólo con la firma, el uso en el cuerpo no se ve");

        var conIL = Inspeccionar("Cuerpo", leerCuerpo: true);
        Assert.That(conIL.Select(x => x.Destino.FullName), Does.Contain("Microsoft.Extensions.AI.ChatMessage"));
        Assert.That(conIL.Select(x => x.Donde), Has.All.StartWith("cuerpo de "));
    }

    [Test]
    public void Atributo_de_EF_Core_en_el_nucleo_se_detecta()
    {
        var v = Inspeccionar("Atributo");
        Assert.That(v.Select(x => x.ToString()), Has.Some.Contains("Microsoft.EntityFrameworkCore.KeylessAttribute (atributo de tipo)"));
    }

    [Test]
    public void Caso_de_uso_expuesto_como_herramienta_desde_Infrastructure_se_detecta()
    {
        var tipos = Mutante("HerramientaEnInfrastructure");
        Assert.That(tipos, Is.Not.Empty);
        Assert.That(tipos.All(t => En(t, AdaptadorDeIA)), "la mutación tiene que caer en Infrastructure/AI");

        var v = ReglaDeCapas.Violaciones(tipos, t => EsCasoDeUso(t) || En(t, Presentacion));
        foreach (var x in v) TestContext.Out.WriteLine(x);
        Assert.That(v.Select(x => x.Destino.Name), Has.All.EqualTo("LocalidadService"));
        Assert.That(v, Is.Not.Empty);
    }

    [Test]
    public void Agujero_declarado_nameof_no_deja_rastro()
    {
        Assert.That(Inspeccionar("Nameof"), Is.Empty,
            "nameof se compila a una cadena: no hay tipo que inspeccionar, ni dependencia en tiempo de ejecución");
    }
}
