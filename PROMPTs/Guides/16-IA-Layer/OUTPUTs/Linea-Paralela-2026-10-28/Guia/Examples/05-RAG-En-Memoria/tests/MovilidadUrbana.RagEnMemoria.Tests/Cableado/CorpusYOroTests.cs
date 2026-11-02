using System.Text.RegularExpressions;
using MovilidadUrbana.ApiWeb.Application.Encuestas;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.RagEnMemoria.Application.Ayuda;
using MovilidadUrbana.RagEnMemoria.Tests.Evaluacion;
using NUnit.Framework;

namespace MovilidadUrbana.RagEnMemoria.Tests.Cableado;

public class CorpusYOroTests
{
    [Test]
    public void ElCorpus_SonLos12RequisitosDeLasPoliticas_LeidosDelCodigo()
    {
        var todos = RequisitosDelDominio.Todos;
        Assert.That(todos, Has.Count.EqualTo(12));
        Assert.That(todos.Select(r => r.Fuente), Is.Unique);
        Assert.That(todos.Single(r => r.Fuente == "LocalidadPolicy.RequisitoDelCodigoPostal").Texto,
            Is.EqualTo(LocalidadPolicy.RequisitoDelCodigoPostal));
        Assert.That(todos.Single(r => r.Fuente == "EncuestaPolicy.RequisitoDeLaEdad").Texto,
            Is.EqualTo(EncuestaPolicy.RequisitoDeLaEdad));
    }

    [Test]
    public void ElOro_EstaVersionado_YCadaClaveSaleDelTextoDeUnRelevante()
    {
        var oro = ConjuntoDeOro.Cargar();
        var corpus = RequisitosDelDominio.Todos.ToDictionary(r => r.Fuente);
        Assert.Multiple(() =>
        {
            Assert.That(oro.VersionDelCasoBase, Is.EqualTo("59399ba"));
            Assert.That(oro.Respondibles.Count(), Is.GreaterThanOrEqualTo(10), "tasa de la tarea: K ≥ 10");
            Assert.That(oro.NoRespondibles.Count(), Is.GreaterThanOrEqualTo(3));
            Assert.That(oro.Consultas.Select(c => c.Id), Is.Unique);
            foreach (var c in oro.Respondibles)
            {
                Assert.That(c.Relevantes, Is.Not.Empty, c.Id);
                Assert.That(c.Relevantes.All(corpus.ContainsKey), c.Id + ": relevante fuera del corpus");
                Assert.That(c.Relevantes.Any(f => Regex.IsMatch(CriterioDeRespuesta.Normalizar(corpus[f].Texto), c.Clave!)),
                    c.Id + ": la clave no está en el texto de ningún relevante");
            }
            foreach (var c in oro.NoRespondibles) Assert.That(c.Relevantes, Is.Empty, c.Id);
        });
    }
}

public class MetricasTests
{
    // Tres consultas calculadas a mano (k = 3):
    //   q1 rel {A}    ranking A B C → hit@1 1, hit@3 1, recall@3 1,   RR 1
    //   q2 rel {A}    ranking B C A → hit@1 0, hit@3 1, recall@3 1,   RR 1/3
    //   q3 rel {A, D} ranking B D C → hit@1 0, hit@3 1, recall@3 1/2, RR 1/2
    private static readonly (IReadOnlyList<string>, IReadOnlyList<string>)[] Casos =
    [
        (["A"], ["A", "B", "C"]),
        (["A"], ["B", "C", "A"]),
        (["A", "D"], ["B", "D", "C"]),
    ];

    [Test]
    public void LasMetricas_ReproducenElCalculoAMano()
    {
        Assert.Multiple(() =>
        {
            Assert.That(MetricasDeRecuperacion.HitAt(1, Casos), Is.EqualTo(1.0 / 3).Within(1e-9));
            Assert.That(MetricasDeRecuperacion.HitAt(3, Casos), Is.EqualTo(1.0).Within(1e-9));
            Assert.That(MetricasDeRecuperacion.RecallAt(3, Casos), Is.EqualTo(2.5 / 3).Within(1e-9));
            Assert.That(MetricasDeRecuperacion.MrrAt(3, Casos), Is.EqualTo((1 + 1.0 / 3 + 0.5) / 3).Within(1e-9));
            // MRR con corte: si el relevante está después de k, cuenta 0.
            Assert.That(MetricasDeRecuperacion.RangoReciproco(2, ["A"], ["B", "C", "A"]), Is.EqualTo(0));
        });
    }

    [Test]
    public void ElCriterio_EscritoAntes_SeAplicaIgualALasDosEstrategias()
    {
        var cp = ConjuntoDeOro.Cargar().Consultas.Single(c => c.Id == "R01");
        var nr = ConjuntoDeOro.Cargar().Consultas.Single(c => c.Id == "N01");
        var fuente = "LocalidadPolicy.RequisitoDelCodigoPostal";
        Assert.Multiple(() =>
        {
            Assert.That(CriterioDeRespuesta.Cumple(cp, $"Lleva 4 dígitos [{fuente}].", [fuente]), Is.True);
            Assert.That(CriterioDeRespuesta.Cumple(cp, "Lleva 4 dígitos.", []), Is.False, "sin cita");
            Assert.That(CriterioDeRespuesta.Cumple(cp, $"Lleva 5 dígitos [{fuente}].", [fuente]), Is.False, "sin la clave");
            Assert.That(CriterioDeRespuesta.Cumple(nr, "No lo sé con los requisitos disponibles.", []), Is.True);
            Assert.That(CriterioDeRespuesta.Cumple(nr, "Sí, se pierden.", []), Is.False);
        });
    }

    [Test]
    public void LaComparacionPareada_SoloDiceDifiereConSeisDiscordantesEnUnSentido()
    {
        var cinco = Enumerable.Repeat((1.0, 0.0), 5).Concat(Enumerable.Repeat((1.0, 1.0), 7)).ToList();
        var seis = Enumerable.Repeat((1.0, 0.0), 6).Concat(Enumerable.Repeat((1.0, 1.0), 6)).ToList();
        var mezclados = Enumerable.Repeat((1.0, 0.0), 6).Append((0.0, 1.0)).ToList();
        Assert.Multiple(() =>
        {
            Assert.That(Estadistica.Pareada("A", "B", cinco), Does.EndWith("no separado con este N"));
            Assert.That(Estadistica.Pareada("A", "B", seis), Does.Contain("difiere"));
            Assert.That(Estadistica.Pareada("A", "B", mezclados), Does.EndWith("no separado con este N"));
        });
    }
}
