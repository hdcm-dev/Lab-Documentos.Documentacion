namespace MovilidadUrbana.RagEnMemoria.Infrastructure.AI;

/// <summary>
/// Instrucciones del sistema. Las dos estrategias usan la misma instrucción y el mismo formato de
/// fragmentos: lo único que cambia es cuántos requisitos llegan (los 12 o los k recuperados).
/// La cita no lleva un ejemplo de formato: con un marcador como «[Politica.Requisito]», el 4b lo copió
/// literal en la mayoría de las respuestas RAG («[Politica.RequisitoDeLaEdad]»), y esas citas no valen.
/// </summary>
public static class TextosDeInstruccion
{
    /// <summary>Frase exacta de abstención; la comparación con el oro la busca tal cual.</summary>
    public const string Abstencion = "No lo sé con los requisitos disponibles.";

    public static string Ayuda { get; } =
        "Sos el asistente de Movilidad Urbana. Respondé en español, en una a tres oraciones, usando SÓLO los " +
        "fragmentos que te pasa la aplicación. Al final de cada oración copiá entre corchetes el valor exacto " +
        "del campo «fuente» del fragmento que la respalda, sin cambiarlo. " +
        $"Si los fragmentos no alcanzan para responder, respondé exactamente: {Abstencion}";

    /// <summary>Vías B y C: la búsqueda es una herramienta que el modelo pide.</summary>
    public static string AyudaConHerramienta { get; } =
        "Sos el asistente de Movilidad Urbana. Respondé en español, en una a tres oraciones. Para cualquier " +
        $"pregunta sobre requisitos o reglas de los formularios usá la herramienta {NombreDeLaHerramienta} y " +
        "respondé SÓLO con lo que devuelva. Al final de cada oración copiá entre corchetes el valor exacto " +
        "del campo «fuente» del fragmento que la respalda, sin cambiarlo. " +
        $"Si lo que devuelve no alcanza, respondé exactamente: {Abstencion}";

    public const string NombreDeLaHerramienta = "buscar_requisitos";

    public const string DescripcionDeLaHerramienta =
        "Busca por significado los requisitos de los formularios de localidades y de la encuesta de transporte. " +
        "Devuelve los fragmentos más parecidos a la consulta, con su fuente.";

    public static string Pregunta(string pregunta) => $"Pregunta: {pregunta}";
}
