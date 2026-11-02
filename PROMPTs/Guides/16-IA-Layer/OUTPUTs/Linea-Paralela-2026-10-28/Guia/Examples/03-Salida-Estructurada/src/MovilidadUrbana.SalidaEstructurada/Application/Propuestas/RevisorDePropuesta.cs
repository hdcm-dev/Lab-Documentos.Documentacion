using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.ApiWeb.Domain;
using MovilidadUrbana.ApiWeb.Domain.Rules;

namespace MovilidadUrbana.SalidaEstructurada.Application.Propuestas;

/// <summary>Resultado de revisar una propuesta. Ninguno escribe: guardar es un paso aparte de la persona.</summary>
public abstract record Revision
{
    /// <summary>La respuesta no tuvo la forma pedida: la pantalla abre el formulario vacío (camino sin IA).</summary>
    public sealed record SinPropuesta(string Aviso) : Revision;

    /// <summary>La propuesta no llega a la pantalla: su tipo o su id no valen en esta sesión.</summary>
    public sealed record Descartada(string Motivo) : Revision;

    /// <summary>
    /// Formulario precargado para que la persona lo vea y confirme. Los errores son por campo, con los
    /// nombres que la pantalla del ABM ya conoce; sin errores no quiere decir que el dato sea cierto.
    /// </summary>
    public sealed record ParaConfirmar(LocalidadModel Formulario, IReadOnlyDictionary<string, string> Errores) : Revision;
}

/// <summary>
/// Núcleo del camino de IA: el modelo propone, el catálogo normaliza y las reglas deciden. No referencia
/// Microsoft.Extensions.AI y no llama a ningún método de escritura del repositorio.
/// </summary>
public sealed class RevisorDePropuesta(ILocalidadRepository repository)
{
    public async Task<Revision> RevisarAsync(LocalidadPropuesta? propuesta, CancellationToken cancellationToken = default)
    {
        if (propuesta is null)
            return new Revision.SinPropuesta("No pude leer una localidad en el texto. Completá el formulario.");

        // 1. Contrato: la deserialización acepta un número que el enum no define (por ejemplo, 5).
        if (!Enum.IsDefined(propuesta.Tipo))
            return new Revision.Descartada($"tipo fuera del contrato: {(int)propuesta.Tipo}");

        // 2. El id: un alta no trae id; una modificación trae uno que existe en ESTA sesión.
        if (propuesta.Tipo == TipoDePropuesta.Alta && propuesta.Id is not null)
            return new Revision.Descartada("un alta no lleva id");
        if (propuesta.Tipo == TipoDePropuesta.Modificacion)
        {
            if (propuesta.Id is not > 0)
                return new Revision.Descartada($"id inválido: {propuesta.Id?.ToString() ?? "sin id"}");
            // El repositorio filtra por sesión: el id de otra sesión da null, igual que uno inexistente.
            var existente = await repository.GetByIdAsync(propuesta.Id.Value, cancellationToken);
            if (existente is null)
                return new Revision.Descartada($"id inexistente en la sesión: {propuesta.Id}");

            // Lo que el texto no cambia se toma de la entidad que resuelve el servidor, no del modelo.
            propuesta = propuesta with
            {
                Nombre = propuesta.Nombre ?? existente.Nombre,
                Provincia = propuesta.Provincia ?? existente.Provincia,
                CodigoPostal = propuesta.CodigoPostal ?? existente.CodigoPostal,
                Habitantes = propuesta.Habitantes ?? existente.Habitantes
            };
        }

        // 3. Normalización contra el catálogo y la entrada de IA (no toca las reglas copiadas).
        var errores = new Dictionary<string, string>();
        var nombre = (propuesta.Nombre ?? string.Empty).Trim();
        if (nombre.Length > LocalidadRules.LargoMaximoDelNombre)
            errores["nombre"] = $"El nombre propuesto supera {LocalidadRules.LargoMaximoDelNombre} caracteres.";

        var provincia = Catalogos.Provincias.FirstOrDefault(p =>
            string.Equals(p, propuesta.Provincia?.Trim(), StringComparison.OrdinalIgnoreCase));
        if (provincia is null && !string.IsNullOrWhiteSpace(propuesta.Provincia))
            errores["provincia"] = $"«{propuesta.Provincia}» no es una provincia del catálogo.";

        var codigoPostal = (propuesta.CodigoPostal ?? string.Empty).Trim();
        if (codigoPostal.Any(c => !char.IsAsciiDigit(c)) && codigoPostal.Length > 0)
            errores["codigoPostal"] = "El código postal propuesto tiene caracteres que no son dígitos 0-9.";

        var formulario = new LocalidadModel
        {
            Id = propuesta.Id,
            Nombre = nombre,
            Provincia = provincia ?? string.Empty,
            CodigoPostal = codigoPostal,
            Habitantes = propuesta.Habitantes
        };

        // 4. Las reglas del dominio deciden, con los mensajes del ABM. TryAdd: el error de normalización manda.
        if (!LocalidadRules.NombreValido(formulario.Nombre))
            errores.TryAdd("nombre", $"El nombre debe tener al menos {LocalidadRules.LargoMinimoDelNombre} caracteres.");
        if (!LocalidadRules.ProvinciaValida(formulario.Provincia))
            errores.TryAdd("provincia", "Seleccione una provincia.");
        if (!LocalidadRules.CodigoPostalValido(formulario.CodigoPostal))
            errores.TryAdd("codigoPostal", $"El código postal debe tener {LocalidadRules.DigitosDelCodigoPostal} dígitos.");
        if (!LocalidadRules.HabitantesValidos(formulario.Habitantes))
            errores.TryAdd("habitantes", "Ingrese una cantidad de habitantes mayor a cero.");

        return new Revision.ParaConfirmar(formulario, errores);
    }
}
