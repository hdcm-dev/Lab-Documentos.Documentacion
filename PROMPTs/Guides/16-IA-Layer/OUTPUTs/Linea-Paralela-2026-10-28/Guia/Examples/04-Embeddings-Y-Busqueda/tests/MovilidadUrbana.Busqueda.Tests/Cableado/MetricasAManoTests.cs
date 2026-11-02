using Microsoft.Extensions.DependencyInjection;
using MovilidadUrbana.Busqueda.Busqueda;
using MovilidadUrbana.Busqueda.Evaluacion;
using MovilidadUrbana.Busqueda.Requisitos;

namespace MovilidadUrbana.Busqueda.Tests.Cableado;

/// <summary>
/// Con un generador falso fijo, la búsqueda real (MEVD InMemory, coseno) y el evaluador reproducen métricas
/// calculadas a mano para tres consultas respondibles y una no respondible.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class MetricasAManoTests
{
    private const int D = 1024;

    [Test]
    public async Task TresConsultas_ReproducenLasCuentasAMano()
    {
        var catalogo = new CatalogoDeRequisitos();
        int Eje(string fuente) => catalogo.Requisitos.ToList().FindIndex(r => r.Fuente == fuente);
        int cp = Eje("LocalidadPolicy.RequisitoDelCodigoPostal"), hab = Eje("LocalidadPolicy.RequisitoDeLosHabitantes"),
            locNombre = Eje("LocalidadPolicy.RequisitoDelNombre"), edad = Eje("EncuestaPolicy.RequisitoDeLaEdad"),
            dist = Eje("EncuestaPolicy.RequisitoDeLaDistancia"), min = Eje("EncuestaPolicy.RequisitoDeLosMinutos"),
            motivo = Eje("EncuestaPolicy.RequisitoDelMotivo"), medios = Eje("EncuestaPolicy.RequisitoDeLosMedios");

        // Cada requisito, un eje propio; cada consulta, una mezcla elegida para que el ranking se pueda contar a mano.
        var vectores = catalogo.Requisitos.Select((r, i) => (r.TextoAIndexar, GeneradorFijo.Eje(D, i))).ToDictionary();
        vectores["q1"] = GeneradorFijo.Eje(D, cp);                                                  // CP primero
        vectores["q2"] = GeneradorFijo.Mezcla(D, (hab, 3), (locNombre, 2), (edad, 1));              // relevante en el puesto 2
        vectores["q3"] = GeneradorFijo.Mezcla(D, (edad, 3), (dist, 2), (min, 1));                   // relevante fuera del top-3
        vectores["q4"] = GeneradorFijo.Mezcla(D, (cp, 1), (edad, 1), (motivo, 1), (medios, 1));     // no respondible: mejor 0,5
        var generador = new GeneradorFijo(D, t => vectores.TryGetValue(t, out var v) ? v : GeneradorFijo.Eje(D, 0));

        using var host = AnfitrionDePrueba.Crear(generador);
        await host.StartAsync();
        var almacen = host.Services.GetRequiredService<AlmacenDeRequisitos>();

        ConsultaDeOro[] consultas =
        [
            new("q1", "prueba", "q1", true, ["LocalidadPolicy.RequisitoDelCodigoPostal"]),
            new("q2", "prueba", "q2", true, ["LocalidadPolicy.RequisitoDelNombre", "EncuestaPolicy.RequisitoDelNombre"]),
            new("q3", "prueba", "q3", true, ["EncuestaPolicy.RequisitoDelMotivo"]),
            new("q4", "prueba", "q4", false, []),
        ];
        var informe = await EvaluacionDeRecuperacion.InformeAsync(almacen, consultas, instruccion: null, k: 3, umbral: 0.6, tamanoDelCorpus: 12);

        // A mano:
        //   q1: rango 1 → hit@1 = 1, hit@3 = 1, recall@3 = 1/1, RR = 1.
        //   q2: top-3 = Habitantes (3/√14 ≈ 0,80), Nombre de Localidad (2/√14 ≈ 0,53), Edad (1/√14 ≈ 0,27);
        //       relevantes {Nombre de Localidad, Nombre de quien responde} → rango 2, hit@1 = 0, hit@3 = 1, recall@3 = 1/2, RR = 1/2.
        //   q3: top-3 = Edad, Distancia, Minutos; relevante Motivo → hit = 0, recall = 0, RR = 0.
        //   hit@1 = 1/3; hit@3 = 2/3; recall@3 = (1 + 1/2 + 0)/3 = 0,5; MRR@3 = (1 + 1/2 + 0)/3 = 0,5.
        //   q4 (no respondible): mejor similitud 1/2 = 0,5 < 0,6 → abstención correcta 1/1; q1..q3 superan 0,6 → 0 indebidas.
        var q2 = informe.Filas.Single(f => f.Consulta.Id == "q2");
        Assert.Multiple(() =>
        {
            Assert.That(q2.Resultados.Select(r => r.Similitud), Is.EqualTo(new[] { 3 / Math.Sqrt(14), 2 / Math.Sqrt(14), 1 / Math.Sqrt(14) }).Within(1e-5));
            Assert.That(q2.RangoDelPrimerRelevante, Is.EqualTo(2));
            Assert.That(informe.HitEn(1), Is.EqualTo(1.0 / 3).Within(1e-9));
            Assert.That(informe.HitEn(3), Is.EqualTo(2.0 / 3).Within(1e-9));
            Assert.That(informe.RecallEnK, Is.EqualTo(0.5).Within(1e-9));
            Assert.That(informe.Mrr, Is.EqualTo(0.5).Within(1e-9));
            Assert.That(informe.Filas.Single(f => f.Consulta.Id == "q4").MejorSimilitud, Is.EqualTo(0.5).Within(1e-5));
            Assert.That(informe.Abstencion, Is.EqualTo(1.0));
            Assert.That(informe.AbstencionesIndebidas, Is.Zero);
            Assert.That(informe.AzarHitEn(3), Is.EqualTo(0.25));
        });
    }

    [Test]
    public void LineaDeAzar_YWilson()
    {
        // Con 12 enunciados y un relevante, hit@k al azar = k/12. Wilson 95 % de 0/10 = [0; 0,28] (el de la guía).
        var (a, b) = Wilson.Intervalo(0, 10);
        Assert.Multiple(() =>
        {
            Assert.That(new InformeDeRecuperacion([], 3, 12).AzarHitEn(1), Is.EqualTo(1.0 / 12));
            Assert.That(a, Is.EqualTo(0).Within(1e-9));
            Assert.That(b, Is.EqualTo(0.28).Within(0.005));
        });
    }
}
