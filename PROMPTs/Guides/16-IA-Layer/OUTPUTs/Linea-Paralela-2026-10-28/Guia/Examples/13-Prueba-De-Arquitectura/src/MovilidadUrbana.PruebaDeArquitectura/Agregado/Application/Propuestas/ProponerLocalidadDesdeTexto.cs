using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.ApiWeb.Domain.Rules;

namespace MovilidadUrbana.PruebaDeArquitectura.Application.Propuestas;

/// <summary>
/// Caso de uso agregado: convierte un texto libre en un formulario precargado. No persiste: quien guarda
/// es la operación normal del ABM (<see cref="LocalidadService.SaveAsync" />), después de que la persona
/// confirma. Depende del puerto, nunca del adaptador ni del cliente del modelo.
/// </summary>
public sealed class ProponerLocalidadDesdeTexto(IExtractorDeLocalidad extractor)
{
    public async Task<LocalidadModel?> EjecutarAsync(string texto, CancellationToken cancellationToken = default)
    {
        var propuesta = await extractor.ExtraerAsync(texto, cancellationToken);
        if (propuesta is null) return null;   // camino sin IA: el formulario vacío

        return new LocalidadModel
        {
            Nombre = (propuesta.Nombre ?? string.Empty).Trim(),
            Provincia = propuesta.Provincia ?? string.Empty,
            CodigoPostal = propuesta.CodigoPostal ?? string.Empty,
            Habitantes = LocalidadRules.HabitantesValidos(propuesta.Habitantes) ? propuesta.Habitantes : null
        };
    }
}
