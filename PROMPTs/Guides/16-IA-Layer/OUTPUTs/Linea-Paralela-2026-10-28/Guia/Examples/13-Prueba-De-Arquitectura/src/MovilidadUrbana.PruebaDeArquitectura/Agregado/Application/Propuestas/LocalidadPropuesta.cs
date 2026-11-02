namespace MovilidadUrbana.PruebaDeArquitectura.Application.Propuestas;

/// <summary>
/// Lo que el adaptador de IA propone a partir de un texto libre. Es un tipo de Application: no sabe
/// que lo llenó un modelo. Los campos son anulables porque el texto puede no traer el dato.
/// </summary>
public sealed record LocalidadPropuesta(string? Nombre, string? Provincia, string? CodigoPostal, int? Habitantes);
