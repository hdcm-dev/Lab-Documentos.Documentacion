namespace MovilidadUrbana.Asistente.Application.Asistente;

/// <summary>Lo que el asistente emite mientras trabaja. Son tipos del núcleo, no de Microsoft.Extensions.AI.</summary>
public abstract record EventoDelAsistente;

/// <summary>Empieza una etapa (interpretar, consultar, proponer…). La UI la muestra como progreso.</summary>
public sealed record EtapaIniciada(string Nombre) : EventoDelAsistente;

/// <summary>Un trozo de texto de la respuesta. La UI lo muestra como texto, nunca como HTML.</summary>
public sealed record TextoParcial(string Texto) : EventoDelAsistente;

/// <summary>
/// Una escritura que la persona tiene que confirmar con la operación normal de la API. Ya está validada:
/// el tipo es uno de los del enum, la localidad de una baja existe en la sesión y los datos de un alta
/// pasaron por el normalizador y las reglas. Si una validación falla, la propuesta se descarta y no llega
/// a la UI; los errores de un alta viajan en <see cref="DatosDeAccion.Errores"/> para que la persona corrija.
/// </summary>
public sealed record AccionPropuesta(TipoDeAccion Tipo, DatosDeAccion Datos) : EventoDelAsistente;

/// <summary>Fin de la respuesta, con las fuentes que citó la ayuda (vacío si no corresponde).</summary>
public sealed record Final(IReadOnlyList<string> Fuentes) : EventoDelAsistente;

public enum TipoDeAccion
{
    Alta,
    Baja
}

/// <summary>
/// Datos de una <see cref="AccionPropuesta"/>. En una baja salen del repositorio (la entidad que resuelve
/// el servidor), no del texto del modelo. En un alta son la propuesta ya normalizada, para precargar el
/// formulario.
/// </summary>
public sealed record DatosDeAccion(
    int? LocalidadId,
    string Nombre,
    string Provincia,
    string CodigoPostal,
    int? Habitantes,
    IReadOnlyDictionary<string, string> Errores);

public enum RolDelTurno
{
    Persona,
    Asistente
}

/// <summary>Un turno del historial, en tipos del núcleo.</summary>
public sealed record TurnoDeConversacion(RolDelTurno Rol, string Texto);

/// <summary>Lo que la persona quiere hacer, según el modelo.</summary>
public enum IntencionDelPedido
{
    /// <summary>Pregunta sobre los datos de la sesión (localidades, resultados de la encuesta).</summary>
    Consulta,

    /// <summary>Pregunta sobre los requisitos o reglas de los formularios.</summary>
    Ayuda,

    /// <summary>Quiere dar de alta una localidad.</summary>
    Alta,

    /// <summary>Quiere dar de baja una localidad.</summary>
    Baja,

    /// <summary>Describe cómo viaja (paso 2 de la encuesta).</summary>
    Encuesta,

    /// <summary>Nada de lo anterior, o el modelo no devolvió una intención válida.</summary>
    FueraDeAlcance
}

/// <summary>Textos fijos que el asistente muestra; no los decide el modelo.</summary>
public static class AvisosDelAsistente
{
    public const string QueHace =
        "Este asistente usa un modelo de lenguaje. Responde preguntas sobre tus datos y sobre los requisitos, " +
        "y prepara altas y bajas de localidades, pero no guarda ni borra nada: cada alta o baja la confirmás vos " +
        "con el formulario normal. Puede equivocarse: revisá lo que propone.";

    public const string FueraDeAlcance =
        "No entendí el pedido. Puedo consultar tus localidades y los resultados de la encuesta, explicar los " +
        "requisitos de los formularios, preparar el alta o la baja de una localidad y ordenar cómo viajás " +
        "(medios y frecuencia).";

    public const string SinInterpretacion =
        "No pude interpretar el pedido con el modelo. Podés cargar el dato con el formulario normal.";
}
