namespace MovilidadUrbana.SalidaEstructurada.Application.Propuestas;

/// <summary>Qué propone el texto: dar de alta una localidad nueva o corregir una que ya existe.</summary>
public enum TipoDePropuesta
{
    Alta,
    Modificacion
}

/// <summary>
/// Lo que el modelo devuelve con <c>GetResponseAsync&lt;LocalidadPropuesta&gt;</c>. Tiene la forma de
/// <c>LocalidadModel</c> más el tipo. Es una propuesta: no se guarda, se revisa y la persona la confirma.
/// Los campos son anulables porque el texto puede no traer el dato, y «no lo dijo» no es «cero».
/// </summary>
public sealed record LocalidadPropuesta(
    TipoDePropuesta Tipo,
    int? Id,
    string? Nombre,
    string? Provincia,
    string? CodigoPostal,
    int? Habitantes);
