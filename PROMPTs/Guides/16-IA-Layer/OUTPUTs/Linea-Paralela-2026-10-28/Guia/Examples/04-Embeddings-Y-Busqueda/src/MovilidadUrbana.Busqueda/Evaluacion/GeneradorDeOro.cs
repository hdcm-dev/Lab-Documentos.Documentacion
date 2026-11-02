using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using MovilidadUrbana.ApiWeb.Application.Encuestas;
using MovilidadUrbana.ApiWeb.Application.Localidades;

namespace MovilidadUrbana.Busqueda.Evaluacion;

public sealed record ConsultaDeOro(string Id, string Conjunto, string Consulta, bool Respondible, IReadOnlyList<string> Relevantes);

public sealed record Oro(string Version, string CasoBase, string Generador, IReadOnlyList<ConsultaDeOro> Consultas)
{
    public IEnumerable<ConsultaDeOro> De(string conjunto) => Consultas.Where(c => c.Conjunto == conjunto);
}

/// <summary>
/// Genera el oro de la búsqueda de requisitos. Las consultas se redactaron antes de correr el modelo;
/// los relevantes se nombran con <c>nameof</c>, así que si una propiedad de <c>*Policy</c> cambia de nombre,
/// esto no compila. El archivo versionado <c>oro/oro-requisitos.json</c> es la salida de <see cref="Serializar"/>,
/// y una prueba de <c>Cableado/</c> verifica que coinciden.
/// </summary>
public static class GeneradorDeOro
{
    public const string Calibracion = "calibracion";
    public const string Evaluacion = "evaluacion";

    private static string L(string propiedad) => $"{nameof(LocalidadPolicy)}.{propiedad}";
    private static string E(string propiedad) => $"{nameof(EncuestaPolicy)}.{propiedad}";

    public static Oro Generar() => new(
        Version: "1",
        CasoBase: "MovilidadUrbana.ApiWeb @ 59399ba (LocalidadPolicy, EncuestaPolicy)",
        Generador: "src/MovilidadUrbana.Busqueda/Evaluacion/GeneradorDeOro.cs",
        Consultas:
        [
            // Evaluación: 12 respondibles (K ≥ 10). La 12 tiene dos relevantes: separa recall@3 de hit@3.
            R("e01", "¿Cuántos números lleva el CP?", L(nameof(LocalidadPolicy.RequisitoDelCodigoPostal))),
            R("e02", "¿Puedo dar de alta una ciudad con cero habitantes?", L(nameof(LocalidadPolicy.RequisitoDeLosHabitantes))),
            R("e03", "¿En qué provincias puedo cargar una ciudad nueva?", L(nameof(LocalidadPolicy.RequisitoDeLaProvincia))),
            R("e04", "¿Puede haber dos ciudades que se llamen igual en la misma provincia?", L(nameof(LocalidadPolicy.RequisitoDelNombre))),
            R("e05", "¿Desde qué edad se puede contestar la encuesta?", E(nameof(EncuestaPolicy.RequisitoDeLaEdad))),
            R("e06", "¿Cuántos kilómetros por día puedo declarar como máximo?", E(nameof(EncuestaPolicy.RequisitoDeLaDistancia))),
            R("e07", "¿Cuánto tiempo puede durar el viaje que informo?", E(nameof(EncuestaPolicy.RequisitoDeLosMinutos))),
            R("e08", "¿Tengo que marcar por lo menos un medio de transporte?", E(nameof(EncuestaPolicy.RequisitoDeLosMedios))),
            R("e09", "¿Qué pongo como razón por la que viajo?", E(nameof(EncuestaPolicy.RequisitoDelMotivo))),
            R("e10", "¿Me preguntan cada cuánto viajo en colectivo?", E(nameof(EncuestaPolicy.RequisitoDeLaFrecuencia))),
            R("e11", "¿Puedo elegir una ciudad que todavía no está dada de alta?", E(nameof(EncuestaPolicy.RequisitoDeLaLocalidad))),
            R("e12", "¿Cuántas letras como mínimo tiene que tener un nombre?",
                L(nameof(LocalidadPolicy.RequisitoDelNombre)), E(nameof(EncuestaPolicy.RequisitoDelNombre))),

            // Evaluación: 10 no respondibles (K ≥ 10). Ningún enunciado las contesta.
            N("e13", "¿Si elimino una ciudad se pierden las encuestas?"),
            N("e14", "¿Quién puede ver las respuestas que cargué?"),
            N("e15", "¿Puedo responder la encuesta sin conexión a internet?"),
            N("e16", "¿Cómo exporto los resultados a una planilla?"),
            N("e17", "¿Cuánto tarda en aparecer una localidad nueva en el listado?"),
            N("e18", "¿Puedo cambiar una respuesta después de enviarla?"),
            N("e19", "¿La encuesta pide el DNI?"),
            N("e20", "¿En qué idiomas está disponible la encuesta?"),
            N("e21", "¿Quién administra el padrón de localidades?"),
            N("e22", "¿Cuántas encuestas se respondieron hasta hoy?"),

            // Calibración del umbral de abstención: consultas distintas de las de evaluación.
            RC("c01", "¿El código postal lleva letras o sólo cifras?", L(nameof(LocalidadPolicy.RequisitoDelCodigoPostal))),
            RC("c02", "¿Hasta qué edad me dejan responder?", E(nameof(EncuestaPolicy.RequisitoDeLaEdad))),
            RC("c03", "¿Cuántos minutos de viaje como mínimo?", E(nameof(EncuestaPolicy.RequisitoDeLosMinutos))),
            RC("c04", "¿La población de la ciudad puede ser negativa?", L(nameof(LocalidadPolicy.RequisitoDeLosHabitantes))),
            RC("c05", "¿Qué distancia diaria acepta el formulario?", E(nameof(EncuestaPolicy.RequisitoDeLaDistancia))),
            NC("c06", "¿Dónde se guardan los datos de la encuesta?"),
            NC("c07", "¿Hay una aplicación para el teléfono?"),
            NC("c08", "¿Quién hizo este sistema?"),
            NC("c09", "¿Se puede borrar una encuesta respondida?"),
            NC("c10", "¿Qué pasa si cierro el navegador a mitad de la encuesta?"),
        ]);

    private static ConsultaDeOro R(string id, string consulta, params string[] relevantes) =>
        new(id, Evaluacion, consulta, true, relevantes);

    private static ConsultaDeOro N(string id, string consulta) => new(id, Evaluacion, consulta, false, []);

    private static ConsultaDeOro RC(string id, string consulta, string relevante) => new(id, Calibracion, consulta, true, [relevante]);

    private static ConsultaDeOro NC(string id, string consulta) => new(id, Calibracion, consulta, false, []);

    public static readonly JsonSerializerOptions Json = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
    };

    public static string Serializar() => JsonSerializer.Serialize(Generar(), Json) + "\n";

    public static Oro Leer(string ruta) =>
        JsonSerializer.Deserialize<Oro>(File.ReadAllText(ruta), Json) ?? throw new InvalidDataException(ruta);
}
