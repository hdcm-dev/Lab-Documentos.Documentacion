namespace MovilidadUrbana.Ejemplos.Orquestacion.Application.Altas;

/// <summary>Puerto del paso con modelo. Application no ve tipos de Microsoft.Extensions.AI.</summary>
public interface IExtractorDeAlta
{
    /// <returns>La propuesta, o null si el modelo no devolvió la forma pedida.</returns>
    Task<PropuestaDeAlta?> ExtraerAsync(string texto, CancellationToken cancellationToken = default);
}

public sealed class EntradaDemasiadoLargaException(int largo, int maximo)
    : Exception($"El texto tiene {largo} caracteres y el máximo es {maximo}.");
