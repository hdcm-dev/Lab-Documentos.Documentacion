namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Encuestas;

/// <summary>
/// Lo que el modelo extrae del texto para el paso 2 de la encuesta: medios y frecuencia, tal como los escribió.
/// Es una PROPUESTA: el catálogo normaliza y las reglas deciden. La forma (que el JSON deserialice) no es validez.
/// </summary>
public sealed record EncuestaPaso2Propuesta(string[] Medios, string Frecuencia);
