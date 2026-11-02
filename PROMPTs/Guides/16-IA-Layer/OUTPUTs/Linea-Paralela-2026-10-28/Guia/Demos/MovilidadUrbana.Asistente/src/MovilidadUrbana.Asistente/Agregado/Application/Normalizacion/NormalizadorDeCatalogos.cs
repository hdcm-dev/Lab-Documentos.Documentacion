using System.Globalization;
using MovilidadUrbana.ApiWeb.Domain;
using MovilidadUrbana.ApiWeb.Domain.Rules;

namespace MovilidadUrbana.Asistente.Application.Normalizacion;

/// <summary>
/// Normaliza contra los catálogos del dominio lo que llega por el camino de IA, antes de que lo vea un
/// caso de uso. Es núcleo: no conoce Microsoft.Extensions.AI ni Infrastructure. El adaptador lo invoca
/// primero y después al caso de uso: el catálogo normaliza y las reglas deciden.
///
/// No traduce sinónimos («bondi» no es «colectivo»): acepta la clave o la etiqueta del catálogo, sin
/// distinguir mayúsculas ni tildes, y todo lo demás lo devuelve como desconocido. Traducir sería decidir
/// por la persona. Por la misma razón el código postal con dígitos que no son ASCII se rechaza y no se
/// convierte.
///
/// Además cubre dos huecos de la copia, sólo en el camino de IA y sin tocar lo copiado: un valor de enum
/// que el tipo no define (GetResponseAsync&lt;T&gt; lo acepta) y un nombre de localidad más largo que
/// <see cref="LocalidadRules.LargoMaximoDelNombre"/>, que la API copiada declara y no hace cumplir.
/// </summary>
public static class NormalizadorDeCatalogos
{
    private static readonly CompareInfo Comparador = CultureInfo.InvariantCulture.CompareInfo;
    private const CompareOptions SinMayusculasNiTildes = CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace;

    private static bool Igual(string a, string b) => Comparador.Compare(a.Trim(), b.Trim(), SinMayusculasNiTildes) == 0;

    /// <summary>La provincia tal como figura en <see cref="Catalogos.Provincias"/>, o null si no está.</summary>
    public static string? Provincia(string? valor) =>
        string.IsNullOrWhiteSpace(valor) ? null : Catalogos.Provincias.FirstOrDefault(p => Igual(p, valor));

    /// <summary>Claves de <see cref="Catalogos.Medios"/> reconocidas y valores que no están en el catálogo.</summary>
    public static (IReadOnlyList<string> Claves, IReadOnlyList<string> Desconocidos) Medios(IEnumerable<string?>? valores)
    {
        var claves = new List<string>();
        var desconocidos = new List<string>();
        foreach (var valor in valores ?? [])
        {
            if (string.IsNullOrWhiteSpace(valor)) continue;
            var medio = Catalogos.Medios.FirstOrDefault(m => Igual(m.Clave, valor) || Igual(m.Etiqueta, valor));
            if (medio.Clave is null) desconocidos.Add(valor.Trim());
            else if (!claves.Contains(medio.Clave)) claves.Add(medio.Clave);
        }
        return (claves, desconocidos);
    }

    /// <summary>La clave de <see cref="Catalogos.Frecuencias"/>, o null si el valor no está en el catálogo.</summary>
    public static string? Frecuencia(string? valor) =>
        string.IsNullOrWhiteSpace(valor)
            ? null
            : Catalogos.Frecuencias.FirstOrDefault(f => Igual(f.Clave, valor) || Igual(f.Etiqueta, valor)).Clave;

    /// <summary>
    /// Falso si el código postal tiene algún dígito que no es ASCII. <c>\d</c> de .NET acepta cualquier
    /// dígito Unicode, así que <c>"٣٤٥٠"</c> pasa <see cref="LocalidadRules.CodigoPostalValido"/>.
    /// </summary>
    public static bool CodigoPostalSoloAscii(string? codigoPostal) =>
        (codigoPostal ?? string.Empty).Trim().All(c => !char.IsDigit(c) || char.IsAsciiDigit(c));

    /// <summary>Falso si el nombre supera <see cref="LocalidadRules.LargoMaximoDelNombre"/> (60).</summary>
    public static bool NombreDentroDelLargo(string? nombre) =>
        (nombre ?? string.Empty).Trim().Length <= LocalidadRules.LargoMaximoDelNombre;

    /// <summary>Falso si el valor no es uno de los que declara el enum (por ejemplo, 5 en un enum de dos).</summary>
    public static bool TipoDefinido<TEnum>(TEnum valor) where TEnum : struct, Enum => Enum.IsDefined(valor);
}
