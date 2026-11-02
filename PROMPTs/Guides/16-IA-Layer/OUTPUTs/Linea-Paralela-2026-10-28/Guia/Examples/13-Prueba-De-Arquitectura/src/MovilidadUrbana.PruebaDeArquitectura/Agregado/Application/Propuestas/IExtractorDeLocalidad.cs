namespace MovilidadUrbana.PruebaDeArquitectura.Application.Propuestas;

/// <summary>
/// Puerto de Application: habla el idioma del caso de uso. Ni en la firma ni en el cuerpo de quien lo
/// usa aparece un tipo de Microsoft.Extensions.AI. Devuelve <c>null</c> cuando no hay propuesta.
/// </summary>
public interface IExtractorDeLocalidad
{
    Task<LocalidadPropuesta?> ExtraerAsync(string texto, CancellationToken cancellationToken = default);
}
