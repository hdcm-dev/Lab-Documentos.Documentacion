using System.Reflection;
using Microsoft.Extensions.AI;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Application.Asistente;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI.Aprobaciones;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.SinModelo;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.AgenteConAprobacion.Tests.Cableado;

[TestFixture, Category("Cableado")]
public sealed class CatalogoYPuertoTests
{
    /// <summary>Lista cerrada: toda escritura va con aprobación y con la guarda; ninguna lectura la necesita.</summary>
    [Test]
    public void EscriturasConAprobacionYGuarda_LecturasSin()
    {
        using var e = new Entorno(new ClienteGuionado());
        using var s = e.Abrir("sesion-A");
        var catalogo = s.Herramientas.Catalogo().Cast<AIFunction>().ToList();

        var escrituras = catalogo.Where(f => f is ApprovalRequiredAIFunction).ToList();
        Assert.Multiple(() =>
        {
            Assert.That(catalogo.Select(f => f.Name), Is.EquivalentTo(new[] { "contar_localidades", "listar_localidades", "eliminar_localidad", "agregar_localidad" }));
            Assert.That(escrituras.Select(f => f.Name), Is.EquivalentTo(HerramientasDeLocalidades.DeEscritura));
            Assert.That(catalogo.Where(f => f is not ApprovalRequiredAIFunction).Select(f => f.Name), Is.EquivalentTo(HerramientasDeLocalidades.DeLectura));
            foreach (var f in escrituras)
                Assert.That(f.GetService(typeof(FuncionConAutorizacion)), Is.Not.Null, $"{f.Name} sin la guarda");
        });
    }

    /// <summary>
    /// El puerto no expone tipos de MEAI ni de MAF, y ninguna operación recibe estado de la conversación:
    /// una sesión serializada alterada no tiene por dónde entrar.
    /// </summary>
    [Test]
    public void ElPuertoSoloRecibeTextoIdsYDecision()
    {
        var permitidos = new[] { typeof(string), typeof(bool), typeof(CancellationToken) };
        var tipos = new[] { typeof(IAsistenteConAprobacion), typeof(RespuestaDelAsistente), typeof(AprobacionPendiente), typeof(IAprobador) };
        var ajenos = new[] { typeof(IChatClient).Assembly, typeof(Microsoft.Agents.AI.AIAgent).Assembly, typeof(AIContent).Assembly };

        var parametros = typeof(IAsistenteConAprobacion).GetMethods().SelectMany(m => m.GetParameters()).Select(p => p.ParameterType).Distinct().ToList();
        var expuestos = tipos.SelectMany(t => t.GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(p => p.PropertyType)
                .Concat(t.GetMethods().SelectMany(m => m.GetParameters().Select(p => p.ParameterType).Append(m.ReturnType))))
            .Distinct().ToList();

        Assert.Multiple(() =>
        {
            Assert.That(parametros, Is.SubsetOf(permitidos));
            Assert.That(expuestos.Where(t => ajenos.Contains(t.Assembly) || t.GenericTypeArguments.Any(g => ajenos.Contains(g.Assembly))), Is.Empty);
        });
    }
}
