using System.Runtime.CompilerServices;
using MovilidadUrbana.ApiWeb.Application.Encuestas;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.Busqueda.Evaluacion;
using MovilidadUrbana.Busqueda.Requisitos;

namespace MovilidadUrbana.Busqueda.Tests.Cableado;

[TestFixture, Category("Cableado")]
public sealed class OroYCatalogoTests
{
    private static string RaizDelEjemplo([CallerFilePath] string archivo = "") =>
        Path.GetFullPath(Path.Combine(Path.GetDirectoryName(archivo)!, "..", "..", ".."));

    [Test]
    public void ElCorpusSonLosDoceEnunciadosDeLasPoliticas()
    {
        var requisitos = new CatalogoDeRequisitos().Requisitos;
        Assert.Multiple(() =>
        {
            Assert.That(requisitos, Has.Count.EqualTo(12));
            Assert.That(CatalogoDeRequisitos.PropiedadesSinEtiqueta(typeof(LocalidadPolicy), typeof(EncuestaPolicy)), Is.Empty);
            Assert.That(requisitos.Single(r => r.Fuente == "LocalidadPolicy.RequisitoDelCodigoPostal").Enunciado,
                Is.EqualTo(LocalidadPolicy.RequisitoDelCodigoPostal).And.EqualTo("4 dígitos."));
            Assert.That(requisitos.Single(r => r.Fuente == "LocalidadPolicy.RequisitoDelCodigoPostal").TextoAIndexar,
                Is.EqualTo("Localidad — código postal: 4 dígitos."));
        });
        foreach (var r in requisitos) TestContext.Out.WriteLine($"{r.Fuente}\t{r.TextoAIndexar}");
    }

    [Test]
    public void ElOroVersionadoEsLaSalidaDeSuGenerador()
    {
        var versionado = File.ReadAllText(Path.Combine(RaizDelEjemplo(), "oro", "oro-requisitos.json"));
        Assert.That(versionado, Is.EqualTo(GeneradorDeOro.Serializar()),
            "regenerá con: dotnet run --project src/MovilidadUrbana.Busqueda -- oro > oro/oro-requisitos.json");
    }

    [Test]
    public void ElOroTieneLosTamanosDeUnaTasaDeLaTarea_YRelevantesQueExisten()
    {
        var oro = GeneradorDeOro.Generar();
        var fuentes = new CatalogoDeRequisitos().Requisitos.Select(r => r.Fuente).ToHashSet();
        var evaluacion = oro.De(GeneradorDeOro.Evaluacion).ToList();
        var consultasDeCalibracion = oro.De(GeneradorDeOro.Calibracion).Select(c => c.Consulta).ToHashSet();
        Assert.Multiple(() =>
        {
            Assert.That(evaluacion.Count(c => c.Respondible), Is.GreaterThanOrEqualTo(10), "K ≥ 10 respondibles");
            Assert.That(evaluacion.Count(c => !c.Respondible), Is.GreaterThanOrEqualTo(10), "K ≥ 10 no respondibles");
            Assert.That(oro.Consultas.SelectMany(c => c.Relevantes).Distinct(), Is.SubsetOf(fuentes));
            Assert.That(oro.Consultas.Where(c => c.Respondible).All(c => c.Relevantes.Count > 0), Is.True);
            Assert.That(oro.Consultas.Where(c => !c.Respondible).All(c => c.Relevantes.Count == 0), Is.True);
            Assert.That(evaluacion.Any(c => consultasDeCalibracion.Contains(c.Consulta)), Is.False, "calibración y evaluación no comparten consultas");
            Assert.That(oro.Consultas.Select(c => c.Id), Is.Unique);
        });
    }
}
