using Microsoft.Agents.AI.Workflows;
using MovilidadUrbana.Ejemplos.Orquestacion.Application.Altas;
using MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.Workflows;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.Orquestacion.Tests.Cableado;

/// <summary>
/// El workflow de alta: un paso con modelo, el orden fijado por el código y ninguna escritura sin la
/// confirmación de la persona. Un cliente guionado hace de modelo.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class WorkflowDeAltaTests
{
    private static readonly string Valida = Anfitrion.Json("Goya", "Corrientes", "3450", 89959);
    private static readonly string[] CaminoConfirmado = [WorkflowDeAlta.Extraer, WorkflowDeAlta.Revisar, WorkflowDeAlta.ConfirmarAlta, WorkflowDeAlta.Registrar];
    private static readonly string[] CaminoRechazado = [WorkflowDeAlta.Extraer, WorkflowDeAlta.Revisar, WorkflowDeAlta.Rechazo];

    private static Func<RevisionDeAlta, ConfirmacionDeAlta?> Persona(bool? responde) =>
        _ => responde is null ? null : new ConfirmacionDeAlta(responde.Value);

    private static async Task<TrazaDelAlta> Correr(Anfitrion a, bool? persona, string texto = "Agregá Goya, Corrientes, CP 3450, 89959 habitantes")
    {
        var workflow = WorkflowDeAlta.Construir(a.Extractor, a.Localidades);
        var traza = await WorkflowDeAlta.EjecutarAsync(workflow, texto, Persona(persona));
        TestContext.Out.WriteLine($"pasos: {string.Join(" > ", traza.Pasos)}; resultado: {traza.Resultado}; estado: {traza.Estado}; escrituras: {a.Almacen.Escrituras}");
        return traza;
    }

    [Test]
    public async Task ElOrdenLoFijaElCodigo_ElModeloNoRecibeHerramientas()
    {
        // Dos «modelos» distintos, el mismo camino: el contenido cambia; el paso siguiente, no.
        foreach (var respuesta in new[] { Valida, Anfitrion.Json("Bella Vista", "corrientes", "3432", 1000) })
        {
            using var a = new Anfitrion(Anfitrion.Devuelve(respuesta));
            var traza = await Correr(a, persona: true);
            Assert.Multiple(() =>
            {
                Assert.That(traza.Pasos, Is.EqualTo(CaminoConfirmado));
                Assert.That(a.Cliente.Llamadas, Has.Count.EqualTo(1));
                Assert.That(a.Cliente.Llamadas[0].OfrecioHerramientas, Is.False);
                Assert.That(traza.Resultado!.Estado, Is.EqualTo(EstadoDelAlta.Registrada));
            });
        }
    }

    [TestCase("Goya", "Corrientes", "34", 89959, "codigoPostal")]
    [TestCase("Goya", "Corrientes", "٣٤٥٠", 89959, "codigoPostal")]      // dígitos no ASCII: la regla copiada los acepta
    [TestCase("Goya", "Misiones", "3450", 89959, "provincia")]            // fuera del catálogo: la regla copiada la acepta
    [TestCase("Goya", "Corrientes", "3450", null, "habitantes")]          // «no lo dijo» no es cero
    [TestCase("G", "Corrientes", "3450", 89959, "nombre")]
    public async Task PropuestaInvalida_SeRechazaAntesDeLaPersona_0Escrituras(string? nombre, string? provincia, string? cp, int? habitantes, string campo)
    {
        using var a = new Anfitrion(Anfitrion.Devuelve(Anfitrion.Json(nombre, provincia, cp, habitantes)));
        var traza = await Correr(a, persona: true);
        Assert.Multiple(() =>
        {
            Assert.That(traza.Pasos, Is.EqualTo(CaminoRechazado));
            Assert.That(traza.PedidosDeConfirmacion, Is.Zero);
            Assert.That(traza.Resultado!.Estado, Is.EqualTo(EstadoDelAlta.Rechazada));
            Assert.That(traza.Resultado.Errores.Keys, Does.Contain(campo));
            Assert.That(a.Almacen.Escrituras, Is.Zero);
        });
    }

    [Test]
    public async Task NombreDe61Caracteres_SeRechaza_AunqueLaReglaCopiadaLoAcepta()
    {
        using var a = new Anfitrion(Anfitrion.Devuelve(Anfitrion.Json(new string('a', 61), "Corrientes", "3450", 10)));
        var traza = await Correr(a, persona: true);
        Assert.That(traza.Resultado!.Errores.Keys, Does.Contain("nombre"));
        Assert.That(a.Almacen.Escrituras, Is.Zero);
    }

    [Test]
    public async Task JsonMalformado_SeRechazaSinEscribir()
    {
        using var a = new Anfitrion(Anfitrion.Devuelve("{ esto no es JSON"));
        var traza = await Correr(a, persona: true);
        Assert.Multiple(() =>
        {
            Assert.That(traza.Pasos, Is.EqualTo(CaminoRechazado));
            Assert.That(traza.Resultado!.Errores.Keys, Is.EquivalentTo(new[] { "propuesta" }));
            Assert.That(a.Almacen.Escrituras, Is.Zero);
        });
    }

    [TestCase(true, EstadoDelAlta.Registrada, 1)]
    [TestCase(false, EstadoDelAlta.Descartada, 0)]
    public async Task LaPersonaDecide(bool confirma, EstadoDelAlta estado, int escrituras)
    {
        using var a = new Anfitrion(Anfitrion.Devuelve(Valida));
        var traza = await Correr(a, confirma);
        Assert.Multiple(() =>
        {
            Assert.That(traza.PedidosDeConfirmacion, Is.EqualTo(1));
            Assert.That(traza.Resultado!.Estado, Is.EqualTo(estado));
            Assert.That(a.Almacen.Escrituras, Is.EqualTo(escrituras));
            Assert.That(traza.Estado, Is.EqualTo(RunStatus.Idle));
        });
    }

    [Test]
    public async Task SinRespuestaDeLaPersona_LaCorridaQuedaPendiente_0Escrituras()
    {
        using var a = new Anfitrion(Anfitrion.Devuelve(Valida));
        var traza = await Correr(a, persona: null);
        Assert.Multiple(() =>
        {
            Assert.That(traza.Estado, Is.EqualTo(RunStatus.PendingRequests));
            Assert.That(traza.Resultado, Is.Null);
            Assert.That(a.Almacen.Escrituras, Is.Zero);
        });
    }

    [Test]
    public async Task ElCasoDeUsoTieneLaUltimaPalabra_DuplicadaConfirmadaNoSeGuarda()
    {
        // «Corrientes, Corrientes» ya está sembrada: pasa la revisión, la persona confirma y el caso de uso la rechaza.
        using var a = new Anfitrion(Anfitrion.Devuelve(Anfitrion.Json("Corrientes", "Corrientes", "3400", 352646)));
        var traza = await Correr(a, persona: true);
        Assert.Multiple(() =>
        {
            Assert.That(traza.Pasos, Is.EqualTo(CaminoConfirmado));
            Assert.That(traza.Resultado!.Estado, Is.EqualTo(EstadoDelAlta.Rechazada));
            Assert.That(traza.Resultado.Errores.Keys, Does.Contain("nombre"));
            Assert.That(a.Almacen.Escrituras, Is.Zero);
        });
    }

    [Test]
    public async Task CheckpointConPedidoPendiente_SeReanudaEnOtraCorrida_SinVolverALlamarAlModelo()
    {
        using var a = new Anfitrion(Anfitrion.Devuelve(Valida));
        var checkpoints = CheckpointManager.CreateInMemory();
        var workflow = WorkflowDeAlta.Construir(a.Extractor, a.Localidades);

        var primera = await WorkflowDeAlta.EjecutarAsync(workflow, "Agregá Goya, Corrientes, CP 3450, 89959 habitantes", Persona(null), checkpoints);
        TestContext.Out.WriteLine($"primera: pasos {string.Join(" > ", primera.Pasos)}; estado {primera.Estado}; checkpoint {primera.UltimoCheckpoint?.CheckpointId}");
        Assert.That(primera.Estado, Is.EqualTo(RunStatus.PendingRequests));
        Assert.That(primera.UltimoCheckpoint, Is.Not.Null);
        Assert.That(a.Almacen.Escrituras, Is.Zero);

        // Otra instancia del workflow (como tras un reinicio) y otra corrida, desde el checkpoint.
        var otroWorkflow = WorkflowDeAlta.Construir(a.Extractor, a.Localidades);
        var segunda = await WorkflowDeAlta.ReanudarAsync(otroWorkflow, primera.UltimoCheckpoint!, checkpoints, Persona(true));
        TestContext.Out.WriteLine($"segunda: pasos {string.Join(" > ", segunda.Pasos)}; pedidos {segunda.PedidosDeConfirmacion}; resultado {segunda.Resultado}; estado {segunda.Estado}");
        Assert.Multiple(() =>
        {
            Assert.That(segunda.PedidosDeConfirmacion, Is.EqualTo(1), "el pedido pendiente se vuelve a emitir al reanudar");
            Assert.That(segunda.Resultado!.Estado, Is.EqualTo(EstadoDelAlta.Registrada));
            Assert.That(a.Almacen.Escrituras, Is.EqualTo(1));
            Assert.That(a.Cliente.Llamadas, Has.Count.EqualTo(1), "el paso con modelo no se repite");
        });
    }

    [Test]
    public async Task EntradaDemasiadoLarga_0LlamadasAlModelo_0Escrituras()
    {
        using var a = new Anfitrion(Anfitrion.Devuelve(Valida));
        var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => Correr(a, true, new string('x', 2001)));
        TestContext.Out.WriteLine($"{ex!.Message} ← {ex.InnerException?.GetType().Name}: {ex.InnerException?.Message}");
        Assert.Multiple(() =>
        {
            Assert.That(ex.InnerException, Is.TypeOf<EntradaDemasiadoLargaException>());
            Assert.That(a.Cliente.Llamadas, Is.Empty);
            Assert.That(a.Almacen.Escrituras, Is.Zero);
        });
    }
}
