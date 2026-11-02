using System.Reflection;
using MovilidadUrbana.ApiWeb.Application.Encuestas;
using MovilidadUrbana.ApiWeb.Application.Localidades;

namespace MovilidadUrbana.Busqueda.Requisitos;

/// <summary>Un enunciado de <c>*Policy</c>: lo que se le muestra a la persona antes de cargar un campo.</summary>
/// <param name="Fuente">Clase y propiedad de origen, p. ej. <c>LocalidadPolicy.RequisitoDelCodigoPostal</c>.</param>
/// <param name="Enunciado">El texto tal como lo devuelve la política (p. ej. «4 dígitos.»).</param>
/// <param name="TextoAIndexar">Entidad y campo + enunciado: lo que se convierte en vector.</param>
public sealed record Requisito(string Fuente, string Entidad, string Campo, string Enunciado, string TextoAIndexar);

/// <summary>
/// Corpus del ejemplo: los doce enunciados de <see cref="LocalidadPolicy"/> y <see cref="EncuestaPolicy"/>,
/// leídos por reflexión. Si una regla cambia, el texto indexado cambia con ella.
/// </summary>
public sealed class CatalogoDeRequisitos
{
    // «Código postal: 4 dígitos.» se busca mejor que «4 dígitos.» solo: el fragmento lleva su campo.
    private static readonly Dictionary<string, (string Entidad, string Campo)> Etiquetas = new()
    {
        [$"{nameof(LocalidadPolicy)}.{nameof(LocalidadPolicy.RequisitoDelNombre)}"] = ("Localidad", "nombre de la localidad"),
        [$"{nameof(LocalidadPolicy)}.{nameof(LocalidadPolicy.RequisitoDeLaProvincia)}"] = ("Localidad", "provincia"),
        [$"{nameof(LocalidadPolicy)}.{nameof(LocalidadPolicy.RequisitoDelCodigoPostal)}"] = ("Localidad", "código postal"),
        [$"{nameof(LocalidadPolicy)}.{nameof(LocalidadPolicy.RequisitoDeLosHabitantes)}"] = ("Localidad", "habitantes"),
        [$"{nameof(EncuestaPolicy)}.{nameof(EncuestaPolicy.RequisitoDelNombre)}"] = ("Encuesta", "nombre de quien responde"),
        [$"{nameof(EncuestaPolicy)}.{nameof(EncuestaPolicy.RequisitoDeLaEdad)}"] = ("Encuesta", "edad de quien responde"),
        [$"{nameof(EncuestaPolicy)}.{nameof(EncuestaPolicy.RequisitoDeLaLocalidad)}"] = ("Encuesta", "localidad donde vive"),
        [$"{nameof(EncuestaPolicy)}.{nameof(EncuestaPolicy.RequisitoDeLosMedios)}"] = ("Encuesta", "medios de transporte que usa"),
        [$"{nameof(EncuestaPolicy)}.{nameof(EncuestaPolicy.RequisitoDeLaFrecuencia)}"] = ("Encuesta", "frecuencia de uso"),
        [$"{nameof(EncuestaPolicy)}.{nameof(EncuestaPolicy.RequisitoDeLaDistancia)}"] = ("Encuesta", "distancia recorrida"),
        [$"{nameof(EncuestaPolicy)}.{nameof(EncuestaPolicy.RequisitoDeLosMinutos)}"] = ("Encuesta", "duración del viaje"),
        [$"{nameof(EncuestaPolicy)}.{nameof(EncuestaPolicy.RequisitoDelMotivo)}"] = ("Encuesta", "motivo del viaje"),
    };

    public IReadOnlyList<Requisito> Requisitos { get; } = Leer(typeof(LocalidadPolicy), typeof(EncuestaPolicy));

    public static IReadOnlyList<string> PropiedadesSinEtiqueta(params Type[] politicas) =>
        politicas.SelectMany(PropiedadesDeRequisito)
            .Select(p => $"{p.DeclaringType!.Name}.{p.Name}")
            .Where(f => !Etiquetas.ContainsKey(f))
            .ToList();

    private static IReadOnlyList<Requisito> Leer(params Type[] politicas)
    {
        var faltan = PropiedadesSinEtiqueta(politicas);
        if (faltan.Count > 0)
            throw new InvalidOperationException($"Requisitos sin entidad ni campo declarados: {string.Join(", ", faltan)}");

        return politicas.SelectMany(PropiedadesDeRequisito)
            .Select(p =>
            {
                var fuente = $"{p.DeclaringType!.Name}.{p.Name}";
                var enunciado = (string)p.GetValue(null)!;
                var (entidad, campo) = Etiquetas[fuente];
                return new Requisito(fuente, entidad, campo, enunciado, $"{entidad} — {campo}: {enunciado}");
            })
            .ToList();
    }

    private static IEnumerable<PropertyInfo> PropiedadesDeRequisito(Type politica) =>
        politica.GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Where(p => p.PropertyType == typeof(string) && p.Name.StartsWith("Requisito", StringComparison.Ordinal))
            .OrderBy(p => p.MetadataToken);
}
