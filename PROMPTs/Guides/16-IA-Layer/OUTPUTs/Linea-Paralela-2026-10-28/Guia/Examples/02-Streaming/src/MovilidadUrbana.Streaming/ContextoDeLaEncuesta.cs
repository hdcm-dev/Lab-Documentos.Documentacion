namespace MovilidadUrbana.Streaming;

/// <summary>
/// Contexto fijo del asistente. Los campos, rangos y catálogos son los de
/// <c>RespuestaDeEncuesta</c>, <c>EncuestaRules</c> y <c>Catalogos</c> de MovilidadUrbana.ApiWeb.
/// </summary>
public static class ContextoDeLaEncuesta
{
    public const string PreguntaDeEjemplo = "¿Qué datos pide la encuesta de movilidad?";

    public const string Instrucciones = """
        Sos el asistente de la encuesta de movilidad urbana. Respondé en español, en un máximo de
        cinco oraciones y sólo con estos datos. Si te preguntan algo que no está acá, decí que no lo sabés.

        La encuesta pide:
        - Nombre (al menos 3 caracteres) y edad (de 16 a 110 años).
        - Localidad donde vive la persona.
        - Medios de transporte que usa, uno o varios: colectivo, auto particular, bicicleta, moto, a pie, tren.
        - Frecuencia del viaje: todos los días, algunos días por semana u ocasionalmente.
        - Distancia del viaje en kilómetros (de 0 a 500) y duración en minutos (de 1 a 600).
        - Motivo del viaje: trabajo, estudio, salud u otros.
        """;
}
