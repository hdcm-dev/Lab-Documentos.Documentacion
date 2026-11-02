using MovilidadUrbana.ApiWeb.Domain;
using MovilidadUrbana.ApiWeb.Domain.Rules;

namespace MovilidadUrbana.Ejemplos.Orquestacion.Application.Altas;

/// <summary>
/// Paso en código del workflow de alta (núcleo, sin tipos de IA). Usa las reglas copiadas del caso
/// base y cierra, sólo para lo que propone el modelo, las tres puertas que la copia deja abiertas:
/// provincia fuera del catálogo, código postal con dígitos no ASCII y nombre de más de 60 caracteres.
/// La forma la garantiza el pedido estructurado; la validez la decide esta clase, y al final el caso de uso.
/// </summary>
public static class RevisorDeAlta
{
    public static RevisionDeAlta Revisar(PropuestaDeAlta? propuesta)
    {
        var errores = new Dictionary<string, string>();
        if (propuesta is null)
        {
            errores["propuesta"] = "El modelo no devolvió una propuesta con la forma pedida.";
            return new(null, errores);
        }

        var nombre = propuesta.Nombre?.Trim() ?? string.Empty;
        if (!LocalidadRules.NombreValido(nombre) || nombre.Length > LocalidadRules.LargoMaximoDelNombre)
            errores["nombre"] = $"Entre {LocalidadRules.LargoMinimoDelNombre} y {LocalidadRules.LargoMaximoDelNombre} caracteres.";

        // Normaliza mayúsculas contra el catálogo; lo que no está en el catálogo se rechaza.
        var provincia = Catalogos.Provincias.FirstOrDefault(p =>
            string.Equals(p, propuesta.Provincia?.Trim(), StringComparison.OrdinalIgnoreCase));
        if (provincia is null)
            errores["provincia"] = "No es una provincia del catálogo.";

        var cp = propuesta.CodigoPostal?.Trim() ?? string.Empty;
        if (!LocalidadRules.CodigoPostalValido(cp) || !cp.All(char.IsAsciiDigit))
            errores["codigoPostal"] = $"El código postal debe tener {LocalidadRules.DigitosDelCodigoPostal} dígitos (0-9).";

        if (!LocalidadRules.HabitantesValidos(propuesta.Habitantes))
            errores["habitantes"] = "Falta la cantidad de habitantes o no es mayor a cero.";

        return new(errores.Count == 0 ? propuesta with { Nombre = nombre, Provincia = provincia, CodigoPostal = cp } : propuesta, errores);
    }
}
