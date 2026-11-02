using System.Net;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using MovilidadUrbana.ApiWeb.Contracts;
using MovilidadUrbana.Asistente.Application.Asistente;
using MovilidadUrbana.Asistente.Application.Encuestas;
using MovilidadUrbana.Asistente.Application.Localidades;
using MovilidadUrbana.Asistente.Presentation.Contracts;
using MovilidadUrbana.Asistente.Tests.Comun;

namespace MovilidadUrbana.Asistente.Tests.Cableado;

/// <summary>
/// El recorrido D1–D6 de la demo con un cliente falso que hace de modelo: lo que el modelo «propone» lo
/// escribe la prueba; lo que se verifica es lo que la aplicación hace con eso. Sin modelo y determinista.
/// </summary>
[TestFixture]
public sealed class RecorridoD1aD6Tests
{
    private static async Task<List<LocalidadDto>> LocalidadesAsync(HttpClient c) =>
        await c.GetFromJsonAsync<List<LocalidadDto>>("api/v1/localidades", Fabrica.Json) ?? [];

    // ---------------- D1 ----------------

    [Test]
    public async Task D1_el_CP_que_el_modelo_copia_mal_lo_rechaza_el_dominio_y_no_se_guarda_nada()
    {
        var falso = new ClienteFalso(
            Responde.Intencion("Alta"),
            _ => Responde.Json(new { nombre = "Goya", provincia = "Corrientes", codigoPostal = "34", habitantes = 89959 }));
        using var app = new Fabrica(falso);

        var (r, eventos) = await app.ConversarAsync("d1", "Agregá Goya, Corrientes, CP 34, 89959 habitantes");

        Assert.That(r.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var accion = eventos.Single(e => e.Tipo == "accion").Accion!;
        Assert.Multiple(() =>
        {
            Assert.That(accion.Tipo, Is.EqualTo("alta"));
            Assert.That(accion.Errores.Keys, Is.EquivalentTo(new[] { "codigoPostal" }));
            Assert.That(app.Contador.Escrituras, Is.Zero, "la propuesta no persiste");
        });
        Assert.That((await LocalidadesAsync(app.Cliente("d1"))).Select(l => l.Nombre), Has.No.Member("Goya"));
    }

    [Test]
    public async Task D1_un_CP_inventado_que_pasa_las_reglas_queda_a_la_vista_para_que_la_persona_lo_confirme()
    {
        // El modelo puede «corregir» el 34 inventando un CP plausible; 3400 pasa ^\d{4}$.
        var falso = new ClienteFalso(
            Responde.Intencion("Alta"),
            _ => Responde.Json(new { nombre = "Goya", provincia = "Corrientes", codigoPostal = "3400", habitantes = 89959 }));
        using var app = new Fabrica(falso);

        var (_, eventos) = await app.ConversarAsync("d1b", "Agregá Goya, Corrientes, CP 34, 89959 habitantes");

        var accion = eventos.Single(e => e.Tipo == "accion").Accion!;
        Assert.Multiple(() =>
        {
            Assert.That(accion.Errores, Is.Empty, "las reglas no ven la diferencia entre el dato y el inventado");
            Assert.That(accion.CodigoPostal, Is.EqualTo("3400"), "el formulario precargado muestra lo que propuso el modelo");
            Assert.That(app.Contador.Escrituras, Is.Zero);
        });
    }

    [Test]
    public async Task D1_el_alta_confirmada_es_la_operacion_normal_de_la_API_copiada()
    {
        var falso = new ClienteFalso(
            Responde.Intencion("Alta"),
            _ => Responde.Json(new { nombre = "Goya", provincia = "Corrientes", codigoPostal = "34", habitantes = 89959 }));
        using var app = new Fabrica(falso);
        var (_, eventos) = await app.ConversarAsync("d1c", "Agregá Goya, Corrientes, CP 34, 89959 habitantes");
        var propuesta = eventos.Single(e => e.Tipo == "accion").Accion!;
        Assert.That(app.Contador.Altas, Is.Zero);

        // La persona corrige el CP en el formulario y guarda: POST /api/v1/localidades, con su sesión.
        var r = await app.Cliente("d1c").PostAsJsonAsync("api/v1/localidades",
            new LocalidadRequest(propuesta.Nombre, propuesta.Provincia, "3450", propuesta.Habitantes));

        await Assert.MultipleAsync(async () =>
        {
            Assert.That(r.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(app.Contador.Altas, Is.EqualTo(1));
            Assert.That((await LocalidadesAsync(app.Cliente("d1c"))).Select(l => l.Nombre), Has.Member("Goya"));
        });
    }

    [TestCase("٣٤٥٠", "Corrientes", "Goya", "codigoPostal", TestName = "D1_regla_heredada_CP_con_digitos_no_ASCII")]
    [TestCase("3450", "Tucumán", "Goya", "provincia", TestName = "D1_regla_heredada_provincia_fuera_de_catalogo")]
    [TestCase("3450", "Corrientes", "NOMBRE61", "nombre", TestName = "D1_regla_heredada_nombre_de_61_caracteres")]
    public async Task Regla_heredada_el_camino_de_IA_rechaza_lo_que_la_API_copiada_acepta(string cp, string provincia, string nombre, string campo)
    {
        if (nombre == "NOMBRE61") nombre = new string('a', 61);
        using var app = new Fabrica(new ClienteFalso());

        // Por la API copiada, sin IA: lo que diga el código copiado (la copia no se endurece).
        var porApi = await app.Cliente("h").PostAsJsonAsync("api/v1/localidades", new LocalidadRequest(nombre, provincia, cp, 1000));
        TestContext.Out.WriteLine($"API copiada: {campo} → {(int)porApi.StatusCode}");

        // Por el camino de IA: el normalizador del núcleo lo rechaza antes del caso de uso.
        using var ambito = app.Services.CreateScope();
        ambito.ServiceProvider.GetRequiredService<MovilidadUrbana.ApiWeb.Infrastructure.Sessions.SessionContext>().Set("h-ia");
        var proponer = ambito.ServiceProvider.GetRequiredService<ProponerLocalidadDesdeTexto>();
        var accion = await proponer.ValidarAsync(new LocalidadPropuesta(nombre, provincia, cp, 1000), CancellationToken.None);

        Assert.Multiple(() =>
        {
            Assert.That(porApi.StatusCode, Is.EqualTo(HttpStatusCode.Created), "la API copiada lo acepta (deuda heredada declarada)");
            Assert.That(accion.Datos.Errores.Keys, Does.Contain(campo), "el camino de IA lo rechaza");
        });
    }

    // ---------------- D2 ----------------

    [Test]
    public async Task D2_sin_habitantes_la_propuesta_no_pasa_las_reglas_y_pide_el_dato()
    {
        var falso = new ClienteFalso(
            Responde.Intencion("Alta"),
            _ => Responde.Json(new { nombre = "Bella Vista", provincia = "Corrientes", codigoPostal = (string?)null, habitantes = (int?)null }));
        using var app = new Fabrica(falso);

        var (_, eventos) = await app.ConversarAsync("d2", "En Bella Vista no sé cuántos viven");

        var accion = eventos.Single(e => e.Tipo == "accion").Accion!;
        Assert.Multiple(() =>
        {
            Assert.That(accion.Errores.Keys, Does.Contain("habitantes"));
            Assert.That(accion.Habitantes, Is.Null, "no se inventa un valor por defecto");
            Assert.That(app.Contador.Escrituras, Is.Zero);
        });
    }

    // ---------------- D3 ----------------

    [Test]
    public async Task D3_medios_y_frecuencia_del_catalogo_pasan_la_validacion_del_paso_2()
    {
        var falso = new ClienteFalso(
            Responde.Intencion("Encuesta"),
            _ => Responde.Json(new { medios = new[] { "colectivo", "bicicleta" }, frecuencia = "diaria" }));
        using var app = new Fabrica(falso);

        var (_, eventos) = await app.ConversarAsync("d3", "Voy en bondi y a veces en bici, casi todos los días");

        var texto = string.Concat(eventos.Where(e => e.Tipo == "texto").Select(e => e.Texto));
        Assert.That(texto, Does.Contain("Colectivo, Bicicleta").And.Contain("Todos los días").And.Contain("Pasa la validación"));
        Assert.That(app.Contador.Escrituras, Is.Zero);
    }

    [Test]
    public async Task D3_un_medio_que_el_modelo_copia_literal_se_rechaza_no_se_descarta()
    {
        // «bondi» copiado literal es un caso que se observó con el modelo provisional.
        var falso = new ClienteFalso(
            Responde.Intencion("Encuesta"),
            _ => Responde.Json(new { medios = new[] { "bondi", "bicicleta" }, frecuencia = "diaria" }));
        using var app = new Fabrica(falso);

        using var ambito = app.Services.CreateScope();
        var p = ambito.ServiceProvider.GetRequiredService<ProponerPaso2DesdeTexto>()
            .Validar(new EncuestaPaso2Propuesta(["bondi", "bicicleta"], "diaria"));

        Assert.Multiple(() =>
        {
            Assert.That(p.Medios, Is.EqualTo(new[] { "bicicleta" }));
            Assert.That(p.Errores["medios"], Does.Contain("bondi"));
        });
    }

    [Test]
    public async Task D3_piedra_por_el_camino_de_IA_da_el_error_del_normalizador_y_cero_escrituras()
    {
        // POST .../desde-texto va directo al extractor: una sola llamada al modelo.
        var falso = new ClienteFalso(_ => Responde.Json(new { medios = new[] { "piedra" }, frecuencia = "diaria" }));
        using var app = new Fabrica(falso);

        var r = await app.Cliente("piedra").PostAsJsonAsync("api/v1/encuestas/pasos/2/desde-texto", new PedidoDesdeTexto("Voy en piedra todos los días"));
        var falsoDos = await r.Content.ReadFromJsonAsync<PropuestaDePaso2Dto>(Fabrica.Json);

        Assert.Multiple(() =>
        {
            Assert.That(falsoDos!.Errores["medios"], Does.StartWith("Medios fuera del catálogo: piedra"));
            Assert.That(app.Contador.Escrituras, Is.Zero);
        });
        TestContext.Out.WriteLine($"camino de IA: medios → «{falsoDos!.Errores["medios"]}»");
    }

    [Test]
    public async Task D3_piedra_por_el_endpoint_copiado_da_lo_que_diga_el_codigo_copiado()
    {
        using var app = new Fabrica(new ClienteFalso());
        var c = app.Cliente("piedra-api");

        var validacion = await c.PostAsJsonAsync("api/v1/encuestas/pasos/2/validacion",
            new EncuestaRequest(null, null, null, ["piedra"], "diaria", null, null, null));
        var paso = await validacion.Content.ReadFromJsonAsync<ValidacionDePasoDto>(Fabrica.Json);

        var registro = await c.PostAsJsonAsync("api/v1/encuestas",
            new EncuestaRequest("Ana Pérez", 30, "Corrientes", ["piedra"], "diaria", 5, 20, "trabajo"));
        var registrada = await registro.Content.ReadFromJsonAsync<EncuestaRegistradaDto>(Fabrica.Json);
        var medios = registrada!.Resumen.Single(f => f.Clave == "medios").Valor;

        TestContext.Out.WriteLine($"endpoint copiado: validación del paso 2 → valido={paso!.Valido}; registro → {(int)registro.StatusCode}, medios guardados «{medios}»");
        // Lo que hace hoy el código copiado: el paso 2 valida (sólo cuenta medios) y el registro guarda la
        // encuesta sin el medio desconocido, en silencio. No coincide con el camino de IA, y no se endurece.
        Assert.Multiple(() =>
        {
            Assert.That(paso.Valido, Is.True);
            Assert.That(registro.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(medios, Is.Empty);
        });
    }

    // ---------------- D4 ----------------

    [Test]
    public async Task D4_el_dato_exacto_lo_calcula_el_caso_de_uso_y_la_herramienta_devuelve_agregados_de_la_sesion()
    {
        var falso = new ClienteFalso(
            Responde.Intencion("Consulta"),
            _ => Responde.Llamar("resultados_de_encuesta"),
            Responde.EcoDelResultado);
        using var app = new Fabrica(falso);
        async Task Registrar(string sesion, string nombre, string[] medios, string motivo) =>
            Assert.That((await app.Cliente(sesion).PostAsJsonAsync("api/v1/encuestas",
                new EncuestaRequest(nombre, 30, "Corrientes", medios, "diaria", 5, 20, motivo))).StatusCode, Is.EqualTo(HttpStatusCode.Created));
        await Registrar("d4-a", "Ana Pérez", ["colectivo"], "trabajo");
        await Registrar("d4-a", "Beto Gómez", ["colectivo", "bicicleta"], "estudio");
        await Registrar("d4-b", "Carla Ruiz", ["auto"], "trabajo");
        await Registrar("d4-c", "Dora Paz", ["auto"], "salud");

        var (_, eventos) = await app.ConversarAsync("d4-a", "¿Qué medio usa más la gente?");

        var resultado = falso.Llamadas[2].UltimoResultado!.Result!.ToString()!;
        Assert.Multiple(() =>
        {
            Assert.That(resultado, Does.Contain("\"total\":2"), "sólo las dos respuestas de la sesión");
            Assert.That(resultado, Does.Contain("\"clave\":\"colectivo\",\"etiqueta\":\"Colectivo\",\"cantidad\":2"));
            Assert.That(resultado, Does.Not.Contain("auto"), "nada de otras sesiones");
            Assert.That(resultado, Does.Not.Contain("Ana").And.Not.Contain("Beto"), "sin nombres");
            Assert.That(eventos.Last().Tipo, Is.EqualTo("final"));
        });
    }

    // ---------------- D5 ----------------

    [Test]
    public async Task D5_la_ayuda_con_contexto_fijo_lleva_los_12_requisitos_y_muestra_la_fuente_citada()
    {
        var falso = new ClienteFalso(
            Responde.Intencion("Ayuda"),
            _ => Responde.Texto("Lleva 4 dígitos [LocalidadPolicy.RequisitoDelCodigoPostal]. Ver también [Inventada.Fuente]."));
        using var app = new Fabrica(falso);

        var (_, eventos) = await app.ConversarAsync("d5", "¿Cuántos dígitos lleva el código postal?");

        var sistema = falso.Llamadas[1].Sistema;
        Assert.Multiple(() =>
        {
            foreach (var r in Application.Ayuda.RequisitosDelDominio.Todos)
                Assert.That(sistema, Does.Contain($"[{r.Fuente}] {r.Tema}: {r.Texto}"));
            Assert.That(falso.Llamadas[1].Herramientas, Is.Empty, "la ayuda no usa herramientas");
            Assert.That(eventos.Last().Fuentes, Is.EqualTo(new[] { "LocalidadPolicy.RequisitoDelCodigoPostal" }), "una fuente inventada no se muestra");
            Assert.That(eventos.Count(e => e.Tipo == "texto"), Is.GreaterThan(1), "llega por trozos");
        });
    }

    // ---------------- D6 ----------------

    [Test]
    public async Task D6_una_baja_propuesta_no_borra_nada_hasta_el_clic_y_el_clic_es_la_operacion_normal()
    {
        var falso = new ClienteFalso(
            Responde.Intencion("Baja"),
            v => Responde.Json(new { tipo = "Baja", localidadId = IdDe(v.Sistema, "Resistencia") }));
        using var app = new Fabrica(falso);
        var c = app.Cliente("d6");

        var (_, eventos) = await app.ConversarAsync("d6", "Borrá Resistencia");
        var accion = eventos.Single(e => e.Tipo == "accion").Accion!;

        await Assert.MultipleAsync(async () =>
        {
            Assert.That(accion.Tipo, Is.EqualTo("baja"));
            Assert.That(accion.Nombre, Is.EqualTo("Resistencia"), "la entidad la resuelve el servidor");
            Assert.That(accion.Provincia, Is.EqualTo("Chaco"));
            Assert.That(app.Contador.Bajas, Is.Zero, "0 bajas sin el clic");
            Assert.That((await LocalidadesAsync(c)).Select(l => l.Nombre), Has.Member("Resistencia"));
        });

        var borrado = await c.DeleteAsync($"api/v1/localidades/{accion.LocalidadId}");

        await Assert.MultipleAsync(async () =>
        {
            Assert.That(borrado.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            Assert.That(app.Contador.Bajas, Is.EqualTo(1), "1 baja después del clic, por el caso de uso");
            Assert.That((await LocalidadesAsync(c)).Select(l => l.Nombre), Has.No.Member("Resistencia"));
        });
    }

    internal static int? IdDe(string sistema, string nombre)
    {
        var m = Regex.Match(sistema, $@"- id (\d+): {Regex.Escape(nombre)} \(");
        return m.Success ? int.Parse(m.Groups[1].Value) : null;
    }
}
