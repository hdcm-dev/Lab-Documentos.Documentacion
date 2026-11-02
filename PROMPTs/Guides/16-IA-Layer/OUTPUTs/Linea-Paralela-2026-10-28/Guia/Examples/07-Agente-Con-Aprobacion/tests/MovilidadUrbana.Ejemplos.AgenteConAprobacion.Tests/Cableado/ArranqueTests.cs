using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.SinModelo;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.AgenteConAprobacion.Tests.Cableado;

[TestFixture, Category("Cableado")]
public sealed class ArranqueTests
{
    [TestCase("AI:TimeoutSegundos", "0")]
    [TestCase("AI:Aprobaciones:VencimientoDeAprobacionMinutos", "0")]
    [TestCase("AI:Herramientas:MaximoDeIteraciones", "0")]
    public void ConfiguracionInvalida_NoArranca(string clave, string valor)
    {
        Assert.Throws<OptionsValidationException>(() =>
        {
            using var e = new Entorno(new ClienteGuionado(), new() { [clave] = valor });
            _ = e.Host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
        });
    }
}
