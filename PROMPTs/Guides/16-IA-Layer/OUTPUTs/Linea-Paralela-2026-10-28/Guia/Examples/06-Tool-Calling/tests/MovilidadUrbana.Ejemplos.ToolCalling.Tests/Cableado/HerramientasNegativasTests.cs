using System.Text.Json.Nodes;
using Microsoft.Extensions.DependencyInjection;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.Ejemplos.ToolCalling.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.ToolCalling.Infrastructure.Persistence;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.ToolCalling.Tests.Cableado;

/// <summary>
/// Las cuatro pruebas negativas del primer ejercicio, por el camino completo: un «modelo» guionado pide la
/// herramienta, el bucle real de FunctionInvokingChatClient la ejecuta, el caso de uso decide y el resultado
/// vuelve al modelo. Ninguna escribe; las que rechazan el argumento ni siquiera leen.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class HerramientasNegativasTests
{
    private const string Pregunta = "pregunta de la prueba";

    private static async Task<(JsonObject Resultado, AlmacenEnMemoria Almacen, ClienteGuionado Modelo)> Pedir(
        string herramienta, Dictionary<string, object?> argumentos, string sesion = "sesion-a",
        Func<IServiceProvider, Task>? antes = null)
    {
        var modelo = new ClienteGuionado(herramienta, argumentos);
        using var host = Configuraciones.Anfitrion(Configuraciones.Valida(), _ => modelo);
        var almacen = host.Services.GetRequiredService<AlmacenEnMemoria>();
        if (antes is not null) await antes(host.Services);
        int lecturasAntes = almacen.Lecturas;

        var (ambito, asistente) = Configuraciones.Sesion(host, sesion);
        using (ambito)
        {
            var r = await asistente.PreguntarAsync(Pregunta);
            var llamada = r.Herramientas.Single();
            TestContext.Out.WriteLine($"{llamada.Nombre}({llamada.Argumentos}) → {llamada.Resultado}; lecturas en esta pregunta: {almacen.Lecturas - lecturasAntes}; escrituras: {almacen.Escrituras}");
            Assert.That(modelo.ResultadosVistos, Has.Count.EqualTo(1), "el resultado volvió al modelo");
            return (JsonNode.Parse(llamada.Resultado)!.AsObject(), almacen, modelo);
        }
    }

    private static JsonNode? Campo(JsonObject o, string nombre) =>
        o.FirstOrDefault(p => string.Equals(p.Key, nombre, StringComparison.OrdinalIgnoreCase)).Value;

    [Test]
    public async Task ControlPositivo_ProvinciaEnMinusculas_SeNormalizaYCuenta()
    {
        var (r, almacen, _) = await Pedir(HerramientasDeLocalidades.ContarPorProvincia, new() { ["provincia"] = "chaco" });
        Assert.That((bool)Campo(r, "ok")!, Is.True);
        Assert.That((string?)Campo(Campo(r, "datos")!.AsObject(), "provincia"), Is.EqualTo("Chaco"));
        Assert.That((int)Campo(Campo(r, "datos")!.AsObject(), "cantidad")!, Is.EqualTo(1)); // Resistencia
        Assert.That(almacen.Escrituras, Is.Zero);
    }

    [Test]
    public async Task Negativa1_ProvinciaFueraDelCatalogo_ErrorPorCampo_SinLeerNiEscribir()
    {
        var (r, almacen, _) = await Pedir(HerramientasDeLocalidades.ContarPorProvincia, new() { ["provincia"] = "Misiones" });
        Assert.That((bool)Campo(r, "ok")!, Is.False);
        Assert.That((string?)Campo(Campo(r, "errores")!.AsObject(), "provincia"), Does.Contain("no es una provincia del catálogo"));
        Assert.That(almacen.Lecturas, Is.Zero, "el normalizador rechaza antes del caso de uso");
        Assert.That(almacen.Escrituras, Is.Zero);
    }

    [TestCase("34")]
    [TestCase("٣٤٠٠")] // dígitos arábigo-índicos: ^\d{4}$ de las reglas copiadas los acepta; la entrada de IA no
    [TestCase("34OO")]
    public async Task Negativa2_CodigoPostalInvalido_ErrorPorCampo_SinLeerNiEscribir(string cp)
    {
        var (r, almacen, _) = await Pedir(HerramientasDeLocalidades.Listar, new() { ["codigoPostal"] = cp });
        Assert.That((bool)Campo(r, "ok")!, Is.False);
        Assert.That((string?)Campo(Campo(r, "errores")!.AsObject(), "codigoPostal"), Does.Contain("4 dígitos (0-9)"));
        Assert.That(almacen.Lecturas, Is.Zero);
        Assert.That(almacen.Escrituras, Is.Zero);
    }

    [Test]
    public async Task Negativa3_LocalidadInexistente_ErrorPorCampo_SinEscrituras()
    {
        var (r, almacen, _) = await Pedir(HerramientasDeLocalidades.Listar, new() { ["nombre"] = "Bella Vista" });
        Assert.That((bool)Campo(r, "ok")!, Is.False);
        Assert.That((string?)Campo(Campo(r, "errores")!.AsObject(), "nombre"), Is.EqualTo("No hay ninguna localidad «Bella Vista» cargada."));
        Assert.That(almacen.Escrituras, Is.Zero);
    }

    [Test]
    public async Task Negativa4_LocalidadDeOtraSesion_NoSeVe_YLaRespuestaEsLaDeUnaInexistente()
    {
        // La sesión B da de alta Goya por el caso de uso normal (lo que haría su pantalla).
        async Task AltaEnB(IServiceProvider raiz)
        {
            using var b = raiz.CreateScope();
            b.ServiceProvider.GetRequiredService<MovilidadUrbana.ApiWeb.Infrastructure.Sessions.SessionContext>().Set("sesion-b");
            var alta = await b.ServiceProvider.GetRequiredService<LocalidadService>().SaveAsync(
                new LocalidadModel { Nombre = "Goya", Provincia = "Corrientes", CodigoPostal = "3450", Habitantes = 89959 });
            Assert.That(alta.IsSuccess, Is.True);
        }

        var buscarGoya = new Dictionary<string, object?> { ["nombre"] = "Goya" };
        var (enA, almacenA, _) = await Pedir(HerramientasDeLocalidades.Listar, buscarGoya, "sesion-a", AltaEnB);
        var (sinGoya, _, _) = await Pedir(HerramientasDeLocalidades.Listar, buscarGoya, "sesion-a");
        var (enB, _, _) = await Pedir(HerramientasDeLocalidades.Listar, buscarGoya, "sesion-b", AltaEnB);

        Assert.That((bool)Campo(enA, "ok")!, Is.False, "A no ve lo que cargó B");
        Assert.That(enA.ToJsonString(), Is.EqualTo(sinGoya.ToJsonString()), "indistinguible de una localidad que no existe");
        Assert.That((bool)Campo(enB, "ok")!, Is.True, "B sí la ve");
        Assert.That(enB.ToJsonString(), Does.Contain("3450"));
        Assert.That(almacenA.Escrituras, Is.EqualTo(1), "la única escritura es el alta de B por el caso de uso, no la herramienta");
    }

    [Test]
    public async Task Negativa4b_ContarEnOtraSesion_NoSumaLoDeLaOtra()
    {
        async Task AltaEnB(IServiceProvider raiz)
        {
            using var b = raiz.CreateScope();
            b.ServiceProvider.GetRequiredService<MovilidadUrbana.ApiWeb.Infrastructure.Sessions.SessionContext>().Set("sesion-b");
            await b.ServiceProvider.GetRequiredService<LocalidadService>().SaveAsync(
                new LocalidadModel { Nombre = "Goya", Provincia = "Corrientes", CodigoPostal = "3450", Habitantes = 89959 });
        }
        var contar = new Dictionary<string, object?> { ["provincia"] = "Corrientes" };
        var (enA, _, _) = await Pedir(HerramientasDeLocalidades.ContarPorProvincia, contar, "sesion-a", AltaEnB);
        var (enB, _, _) = await Pedir(HerramientasDeLocalidades.ContarPorProvincia, contar, "sesion-b", AltaEnB);
        Assert.That((int)Campo(Campo(enA, "datos")!.AsObject(), "cantidad")!, Is.EqualTo(1));
        Assert.That((int)Campo(Campo(enB, "datos")!.AsObject(), "cantidad")!, Is.EqualTo(2));
    }
}
