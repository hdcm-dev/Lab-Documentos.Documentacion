using MovilidadUrbana.ApiWeb.Domain.Entities;

namespace MovilidadUrbana.SalidaEstructurada.Application.Propuestas;

/// <summary>
/// Puerto de Application: no expone tipos de Microsoft.Extensions.AI. Devuelve <c>null</c> cuando la
/// respuesta no tiene la forma pedida; la aplicación sigue entonces por el camino sin IA.
/// </summary>
public interface IExtractorDeLocalidad
{
    Task<LocalidadPropuesta?> ExtraerAsync(
        string texto,
        IReadOnlyList<Localidad> localidadesDeLaSesion,
        CancellationToken cancellationToken = default);
}
