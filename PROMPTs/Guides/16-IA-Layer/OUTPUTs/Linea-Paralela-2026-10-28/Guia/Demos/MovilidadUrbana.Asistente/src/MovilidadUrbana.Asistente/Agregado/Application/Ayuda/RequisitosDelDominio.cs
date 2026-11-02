using MovilidadUrbana.ApiWeb.Application.Encuestas;
using MovilidadUrbana.ApiWeb.Application.Localidades;

namespace MovilidadUrbana.Asistente.Application.Ayuda;

/// <summary>Un requisito enunciado para la persona, con la fuente que lo produce en el código.</summary>
public sealed record Requisito(string Fuente, string Tema, string Texto);

/// <summary>
/// Los 12 requisitos que el caso base enuncia en <see cref="LocalidadPolicy"/> y <see cref="EncuestaPolicy"/>,
/// leídos del código en cada arranque: si cambia una regla, cambia el texto que ve el modelo. Es el
/// corpus del contexto fijo (escalón 0). Ojo: son la política tal como se enuncia, no lo que la API hace
/// cumplir (por ejemplo, la API copiada no limita el nombre a 60 caracteres).
/// </summary>
public static class RequisitosDelDominio
{
    public static IReadOnlyList<Requisito> Todos { get; } =
    [
        new($"{nameof(LocalidadPolicy)}.{nameof(LocalidadPolicy.RequisitoDelNombre)}", "Localidad: nombre", LocalidadPolicy.RequisitoDelNombre),
        new($"{nameof(LocalidadPolicy)}.{nameof(LocalidadPolicy.RequisitoDeLaProvincia)}", "Localidad: provincia", LocalidadPolicy.RequisitoDeLaProvincia),
        new($"{nameof(LocalidadPolicy)}.{nameof(LocalidadPolicy.RequisitoDelCodigoPostal)}", "Localidad: código postal", LocalidadPolicy.RequisitoDelCodigoPostal),
        new($"{nameof(LocalidadPolicy)}.{nameof(LocalidadPolicy.RequisitoDeLosHabitantes)}", "Localidad: habitantes", LocalidadPolicy.RequisitoDeLosHabitantes),
        new($"{nameof(EncuestaPolicy)}.{nameof(EncuestaPolicy.RequisitoDelNombre)}", "Encuesta: nombre de la persona", EncuestaPolicy.RequisitoDelNombre),
        new($"{nameof(EncuestaPolicy)}.{nameof(EncuestaPolicy.RequisitoDeLaEdad)}", "Encuesta: edad", EncuestaPolicy.RequisitoDeLaEdad),
        new($"{nameof(EncuestaPolicy)}.{nameof(EncuestaPolicy.RequisitoDeLaLocalidad)}", "Encuesta: localidad", EncuestaPolicy.RequisitoDeLaLocalidad),
        new($"{nameof(EncuestaPolicy)}.{nameof(EncuestaPolicy.RequisitoDeLosMedios)}", "Encuesta: medios de transporte", EncuestaPolicy.RequisitoDeLosMedios),
        new($"{nameof(EncuestaPolicy)}.{nameof(EncuestaPolicy.RequisitoDeLaFrecuencia)}", "Encuesta: frecuencia", EncuestaPolicy.RequisitoDeLaFrecuencia),
        new($"{nameof(EncuestaPolicy)}.{nameof(EncuestaPolicy.RequisitoDeLaDistancia)}", "Encuesta: distancia diaria", EncuestaPolicy.RequisitoDeLaDistancia),
        new($"{nameof(EncuestaPolicy)}.{nameof(EncuestaPolicy.RequisitoDeLosMinutos)}", "Encuesta: tiempo de viaje", EncuestaPolicy.RequisitoDeLosMinutos),
        new($"{nameof(EncuestaPolicy)}.{nameof(EncuestaPolicy.RequisitoDelMotivo)}", "Encuesta: motivo", EncuestaPolicy.RequisitoDelMotivo)
    ];

    /// <summary>Las fuentes del catálogo que aparecen citadas entre corchetes en el texto, en orden de aparición.</summary>
    public static IReadOnlyList<string> FuentesCitadas(string texto) =>
        Todos.Select(r => (r.Fuente, Posicion: texto.IndexOf($"[{r.Fuente}]", StringComparison.Ordinal)))
            .Where(x => x.Posicion >= 0)
            .OrderBy(x => x.Posicion)
            .Select(x => x.Fuente)
            .ToList();
}
