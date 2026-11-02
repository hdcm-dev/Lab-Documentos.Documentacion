using System.Text.Json;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.ApiWeb.Domain.Rules;
using MovilidadUrbana.SalidaEstructurada.Application.Propuestas;
using MovilidadUrbana.SalidaEstructurada.Infrastructure.AI;
using MovilidadUrbana.SalidaEstructurada.Tests.Dobles;

namespace MovilidadUrbana.SalidaEstructurada.Tests.Cableado;

/// <summary>Sin modelo: un cliente falso hace de modelo y devuelve la respuesta que cada prueba necesita.</summary>
[TestFixture]
public sealed class FormaNoEsValidezTests
{
    private static async Task<(Revision Revision, RepositorioEspia Repositorio, ClienteFalso Cliente)> CorrerAsync(string respuestaDelModelo)
    {
        var cliente = new ClienteFalso(respuestaDelModelo);
        var extractor = new ExtractorDeLocalidadLlm(cliente, Options.Create(Opciones.DelAppsettings()));
        var repositorio = new RepositorioEspia("sesion-a");
        var propuesta = await extractor.ExtraerAsync("texto de prueba", []);
        var revision = await new RevisorDePropuesta(repositorio).RevisarAsync(propuesta);
        return (revision, repositorio, cliente);
    }

    [Test]
    public async Task JsonMalformado_TryGetResultDaFalso_YLaAplicacionSigueSinIA()
    {
        var cliente = new ClienteFalso("Goya, Corrientes, 3450");   // texto, no JSON

        ChatResponse<LocalidadPropuesta> r = await cliente.GetResponseAsync<LocalidadPropuesta>("Agregá Goya");
        Assert.That(r.TryGetResult(out _), Is.False);
        Assert.Throws<JsonException>(() => _ = r.Result);           // .Result a ciegas tira la petición abajo

        var (revision, repositorio, _) = await CorrerAsync("Goya, Corrientes, 3450");
        Assert.That(revision, Is.TypeOf<Revision.SinPropuesta>());
        Assert.That(repositorio.Llamadas, Is.Zero);
    }

    [Test]
    public async Task TipoFueraDelEnum_TieneFormaPeroSeDescartaAntesDeLaPantalla()
    {
        var (revision, repositorio, _) = await CorrerAsync(
            """{"tipo":5,"id":null,"nombre":"Goya","provincia":"Corrientes","codigoPostal":"3450","habitantes":89959}""");

        Assert.That(revision, Is.TypeOf<Revision.Descartada>());
        Assert.That(((Revision.Descartada)revision).Motivo, Does.Contain("tipo fuera del contrato: 5"));
        Assert.That(repositorio.Llamadas, Is.Zero);
    }

    [Test]
    public async Task IdNegativo_SeDescartaSinTocarElRepositorio()
    {
        var (revision, repositorio, _) = await CorrerAsync(
            """{"tipo":"Modificacion","id":-1,"nombre":"Resistencia","provincia":"Chaco","codigoPostal":"3500","habitantes":300000}""");

        Assert.That(revision, Is.TypeOf<Revision.Descartada>());
        Assert.That(repositorio.Llamadas, Is.Zero);
    }

    [Test]
    public async Task IdDeOtraSesion_SeDescartaComoInexistente_SinEscrituras()
    {
        // El id 7 existe, pero es de la sesión B; el repositorio de la sesión A no lo devuelve.
        var (revision, repositorio, _) = await CorrerAsync(
            """{"tipo":"Modificacion","id":7,"nombre":"Goya","provincia":"Corrientes","codigoPostal":"3450","habitantes":90000}""");

        Assert.That(revision, Is.TypeOf<Revision.Descartada>());
        Assert.That(((Revision.Descartada)revision).Motivo, Does.Contain("id inexistente en la sesión: 7"));
        Assert.That(repositorio.Escrituras, Is.Zero);
    }

    [Test]
    public async Task Modificacion_LoQueElTextoNoCambiaSaleDeLaEntidadDeLaSesion()
    {
        // «Corregí Resistencia: tiene 300000 habitantes»: el modelo trae el id y sólo el dato que cambia.
        var (revision, repositorio, _) = await CorrerAsync(
            """{"tipo":"Modificacion","id":2,"nombre":null,"provincia":null,"codigoPostal":null,"habitantes":300000}""");

        var paraConfirmar = (Revision.ParaConfirmar)revision;
        Assert.That(paraConfirmar.Errores, Is.Empty);
        Assert.That(paraConfirmar.Formulario.Id, Is.EqualTo(2));
        Assert.That(paraConfirmar.Formulario.Nombre, Is.EqualTo("Resistencia"));
        Assert.That(paraConfirmar.Formulario.CodigoPostal, Is.EqualTo("3500"));
        Assert.That(paraConfirmar.Formulario.Habitantes, Is.EqualTo(300000));
        Assert.That(repositorio.Escrituras, Is.Zero);
    }

    [Test]
    public async Task AltaConId_SeDescarta()
    {
        var (revision, repositorio, _) = await CorrerAsync(
            """{"tipo":"Alta","id":1,"nombre":"Goya","provincia":"Corrientes","codigoPostal":"3450","habitantes":89959}""");

        Assert.That(revision, Is.TypeOf<Revision.Descartada>());
        Assert.That(repositorio.Llamadas, Is.Zero);
    }

    [Test]
    public async Task FormaValidaPeroInvalidaParaElDominio_LaPantallaPideLosDatos()
    {
        // «En Bella Vista no sé cuántos viven», y un CP de 2 dígitos: JSON válido, propuesta inválida.
        var (revision, repositorio, _) = await CorrerAsync(
            """{"tipo":"Alta","id":null,"nombre":"Bella Vista","provincia":"Corrientes","codigoPostal":"34","habitantes":null}""");

        var paraConfirmar = (Revision.ParaConfirmar)revision;
        Assert.That(paraConfirmar.Errores.Keys, Is.EquivalentTo(new[] { "codigoPostal", "habitantes" }));
        Assert.That(paraConfirmar.Errores["habitantes"], Is.EqualTo("Ingrese una cantidad de habitantes mayor a cero."));
        Assert.That(repositorio.Escrituras, Is.Zero);
    }

    // Lo que las reglas copiadas aceptan y la entrada de IA no: el catálogo normaliza; las reglas deciden.
    [TestCase("provincia", """{"tipo":"Alta","id":null,"nombre":"Posadas","provincia":"Misiones","codigoPostal":"3300","habitantes":1}""")]
    [TestCase("codigoPostal", """{"tipo":"Alta","id":null,"nombre":"Goya","provincia":"Corrientes","codigoPostal":"٣٤٥٠","habitantes":1}""")]
    [TestCase("nombre", """{"tipo":"Alta","id":null,"nombre":"NOMBRE_DE_61","provincia":"Corrientes","codigoPostal":"3450","habitantes":1}""")]
    public async Task LoQueLasReglasCopiadasDejanPasar_LaEntradaDeIALoRechaza(string campo, string respuesta)
    {
        Assert.That(LocalidadRules.ProvinciaValida("Misiones"), Is.True);          // sólo exige «no vacío»
        Assert.That(LocalidadRules.CodigoPostalValido("٣٤٥٠"), Is.True);          // \d acepta dígitos no ASCII
        Assert.That(LocalidadRules.NombreValido(new string('a', 61)), Is.True);   // el máximo 60 no se aplica

        var (revision, repositorio, _) = await CorrerAsync(respuesta.Replace("NOMBRE_DE_61", new string('a', 61)));

        var paraConfirmar = (Revision.ParaConfirmar)revision;
        Assert.That(paraConfirmar.Errores.Keys, Is.EquivalentTo(new[] { campo }));
        Assert.That(repositorio.Escrituras, Is.Zero);
    }

    [Test]
    public async Task ProvinciaEnMinusculas_SeNormalizaAlCatalogo()
    {
        var (revision, _, _) = await CorrerAsync(
            """{"tipo":"Alta","id":null,"nombre":"Goya","provincia":"corrientes","codigoPostal":"3450","habitantes":89959}""");

        var paraConfirmar = (Revision.ParaConfirmar)revision;
        Assert.That(paraConfirmar.Errores, Is.Empty);
        Assert.That(paraConfirmar.Formulario.Provincia, Is.EqualTo("Corrientes"));
    }

    [Test]
    public async Task CpInventadoQuePasaLasReglas_LlegaSinErrores_YSoloGuardaElClicDeLaPersona()
    {
        // El texto decía «CP 34»; el modelo «corrigió» a 3400, que cumple ^\d{4}$. Las reglas no lo ven.
        var (revision, repositorio, _) = await CorrerAsync(
            """{"tipo":"Alta","id":null,"nombre":"Goya","provincia":"Corrientes","codigoPostal":"3400","habitantes":89959}""");

        var paraConfirmar = (Revision.ParaConfirmar)revision;
        Assert.That(paraConfirmar.Errores, Is.Empty);
        Assert.That(repositorio.Escrituras, Is.Zero);                    // nada se guardó todavía

        // La persona ve el 3400 en el formulario precargado y confirma: la operación normal del ABM.
        var resultado = await new LocalidadService(repositorio).SaveAsync(paraConfirmar.Formulario);
        Assert.That(resultado.IsSuccess, Is.True);
        Assert.That(repositorio.Altas, Is.EqualTo(1));
    }

    [Test]
    public async Task EntradaMasLargaQueElMaximo_NoLlamaAlModelo()
    {
        var ia = Opciones.DelAppsettings();
        var cliente = new ClienteFalso("{}");
        var extractor = new ExtractorDeLocalidadLlm(cliente, Options.Create(ia));

        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
            extractor.ExtraerAsync(new string('x', ia.LargoMaximoDeEntrada + 1), []));
        Assert.That(cliente.Llamadas, Is.Zero);
    }
}
