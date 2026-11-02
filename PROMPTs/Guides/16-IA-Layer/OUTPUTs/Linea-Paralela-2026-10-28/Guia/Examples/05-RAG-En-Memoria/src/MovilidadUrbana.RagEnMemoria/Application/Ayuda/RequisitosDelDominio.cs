using System.Reflection;
using MovilidadUrbana.ApiWeb.Application.Encuestas;
using MovilidadUrbana.ApiWeb.Application.Localidades;

namespace MovilidadUrbana.RagEnMemoria.Application.Ayuda;

/// <summary>Un requisito enunciado para la persona, con la fuente que lo produce en el código.</summary>
public sealed record Requisito(string Fuente, string Tema, string Texto);

/// <summary>
/// El corpus: los requisitos que el caso base enuncia en <see cref="LocalidadPolicy"/> y
/// <see cref="EncuestaPolicy"/>, leídos por reflexión en cada arranque. Si cambia una regla, cambia el
/// texto; si se agrega un requisito, entra solo. Ojo: es la política tal como se enuncia, no lo que la
/// API hace cumplir (por ejemplo, el nombre de la localidad declara un máximo de 60 que ninguna regla verifica).
/// </summary>
public static class RequisitosDelDominio
{
    private static readonly (Type Politica, string Entidad)[] Politicas =
    [
        (typeof(LocalidadPolicy), "Localidad"),
        (typeof(EncuestaPolicy), "Encuesta"),
    ];

    public static IReadOnlyList<Requisito> Todos { get; } = Leer();

    private static List<Requisito> Leer() =>
    [
        .. from p in Politicas
           from prop in p.Politica.GetProperties(BindingFlags.Public | BindingFlags.Static)
           where prop.PropertyType == typeof(string) && prop.Name.StartsWith("Requisito", StringComparison.Ordinal)
           orderby prop.MetadataToken   // orden de declaración
           select new Requisito(
               $"{p.Politica.Name}.{prop.Name}",
               $"{p.Entidad}: {Tema(prop.Name)}",
               (string)prop.GetValue(null)!),
    ];

    /// <summary>«RequisitoDelCodigoPostal» → «codigo postal».</summary>
    private static string Tema(string propiedad)
    {
        var resto = propiedad["Requisito".Length..];
        foreach (var prefijo in new[] { "DeLos", "DeLas", "DeLa", "Del" })
            if (resto.StartsWith(prefijo, StringComparison.Ordinal)) { resto = resto[prefijo.Length..]; break; }
        return string.Concat(resto.Select((c, i) => i > 0 && char.IsUpper(c) ? " " + char.ToLowerInvariant(c) : char.ToLowerInvariant(c).ToString()));
    }
}
