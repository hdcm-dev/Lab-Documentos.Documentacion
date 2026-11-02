using Microsoft.Extensions.AI;
using MovilidadUrbana.Asistente.Application.Abstractions;
using MovilidadUrbana.Asistente.Tests.Comun;

namespace MovilidadUrbana.Asistente.Tests.Cableado;

/// <summary>
/// La regla de dependencias: el núcleo (Domain y Application copiados, y Agregado/Application) no conoce la
/// IA, la persistencia, HTTP ni Infrastructure. Con dos casos rojos que demuestran que la prueba detecta.
/// </summary>
[TestFixture]
public sealed class ArquitecturaTests
{
    private static readonly string[] Nucleo = ["MovilidadUrbana.ApiWeb.Domain", "MovilidadUrbana.ApiWeb.Application", "MovilidadUrbana.Asistente.Application"];

    internal static bool Prohibido(string ns) =>
        ns.StartsWith("Microsoft.Extensions.AI") || ns.StartsWith("OllamaSharp") || ns.StartsWith("OpenTelemetry") ||
        ns.StartsWith("Microsoft.EntityFrameworkCore") || ns.StartsWith("Microsoft.AspNetCore") ||
        ns.StartsWith("MovilidadUrbana.ApiWeb.Infrastructure") || ns.StartsWith("MovilidadUrbana.Asistente.Infrastructure") ||
        ns.StartsWith("MovilidadUrbana.Asistente.Presentation") || ns.StartsWith("MovilidadUrbana.ApiWeb.Controllers") ||
        ns.StartsWith("MovilidadUrbana.ApiWeb.Sessions");

    [Test]
    public void El_nucleo_no_depende_de_IA_ni_de_Infrastructure()
    {
        var tipos = typeof(IAsistenteDeMovilidad).Assembly.GetTypes()
            .Where(t => t.Namespace is { } ns && Nucleo.Any(n => ns == n || ns.StartsWith(n + ".")))
            .ToList();
        Assert.That(tipos.Select(t => t.Namespace), Does.Contain("MovilidadUrbana.Asistente.Application.Normalizacion"));
        Assert.That(ReglaDeCapas.Violaciones(tipos, Prohibido), Is.Empty);
    }

    [Test]
    public void Caso_rojo_una_propiedad_de_tipo_ChatMessage_en_el_nucleo_se_detecta() =>
        Assert.That(ReglaDeCapas.Violaciones([typeof(Rojo.Application.ConPropiedad)], Prohibido), Is.Not.Empty);

    [Test]
    public void Caso_rojo_un_uso_solo_dentro_del_cuerpo_de_un_metodo_se_detecta()
    {
        var tipos = typeof(Rojo.Application.SoloEnElCuerpo).Assembly.GetTypes()
            .Where(t => t.FullName!.StartsWith(typeof(Rojo.Application.SoloEnElCuerpo).FullName!));
        var v = ReglaDeCapas.Violaciones(tipos, Prohibido);
        TestContext.Out.WriteLine(string.Join("\n", v));
        Assert.That(v, Is.Not.Empty);
    }
}
