using MovilidadUrbana.ApiWeb.Domain;
using MovilidadUrbana.ApiWeb.Domain.Rules;

namespace MovilidadUrbana.Ejemplos.Mcp.Servidor.Application.Normalizacion;

/// <summary>Valor normalizado o el error por campo, con el nombre de campo que usa el ABM.</summary>
public readonly record struct Normalizado(string? Valor, string? Campo, string? Error)
{
    public bool EsValido => Error is null;
    public static Normalizado Ok(string valor) => new(valor, null, null);
    public static Normalizado Falla(string campo, string error) => new(null, campo, error);
}

/// <summary>
/// Núcleo del camino de IA: valida y normaliza los argumentos que propone el modelo contra
/// <see cref="Catalogos"/> y los límites de <see cref="LocalidadRules"/>, ANTES de llamar al caso de uso.
/// Es más estricto que las reglas copiadas a propósito: ellas no se endurecen.
/// No referencia Microsoft.Extensions.AI.
/// </summary>
public static class NormalizadorDeCatalogos
{
    public static Normalizado Provincia(string? provincia)
    {
        var texto = provincia?.Trim();
        if (string.IsNullOrEmpty(texto))
            return Normalizado.Falla("provincia", $"Indicá una provincia del catálogo: {string.Join(", ", Catalogos.Provincias)}.");

        // «chaco» se normaliza a «Chaco»; «Misiones» no está en el catálogo y se rechaza.
        var delCatalogo = Catalogos.Provincias.FirstOrDefault(p => string.Equals(p, texto, StringComparison.OrdinalIgnoreCase));
        return delCatalogo is null
            ? Normalizado.Falla("provincia", $"«{texto}» no es una provincia del catálogo ({string.Join(", ", Catalogos.Provincias)}).")
            : Normalizado.Ok(delCatalogo);
    }

    public static Normalizado CodigoPostal(string? codigoPostal)
    {
        var texto = (codigoPostal ?? string.Empty).Trim();
        // Sólo dígitos 0-9: el patrón ^\d{4}$ de las reglas copiadas también acepta «٣٤٠٠».
        return texto.Length == LocalidadRules.DigitosDelCodigoPostal && texto.All(char.IsAsciiDigit)
            ? Normalizado.Ok(texto)
            : Normalizado.Falla("codigoPostal", $"El código postal debe tener {LocalidadRules.DigitosDelCodigoPostal} dígitos (0-9).");
    }

    public static Normalizado Nombre(string? nombre)
    {
        var texto = (nombre ?? string.Empty).Trim();
        if (texto.Length == 0)
            return Normalizado.Falla("nombre", "Indicá el nombre de la localidad.");
        return texto.Length > LocalidadRules.LargoMaximoDelNombre
            ? Normalizado.Falla("nombre", $"El nombre supera {LocalidadRules.LargoMaximoDelNombre} caracteres.")
            : Normalizado.Ok(texto);
    }
}
