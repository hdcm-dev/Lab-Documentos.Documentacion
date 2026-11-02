namespace MovilidadUrbana.Ejemplos.Orquestacion.Application.Altas;

/// <summary>
/// Lo que el paso con modelo extrae del texto de la persona. Tiene la forma de <c>LocalidadModel</c>.
/// Es una propuesta: no se guarda; se revisa y la persona la confirma. Los campos son anulables
/// porque el texto puede no traer el dato, y «no lo dijo» no es «cero».
/// </summary>
public sealed record PropuestaDeAlta(string? Nombre, string? Provincia, string? CodigoPostal, int? Habitantes);

/// <summary>Salida del paso de extracción. <see cref="Propuesta"/> es null si el modelo no devolvió la forma pedida.</summary>
public sealed record PropuestaExtraida(string Texto, PropuestaDeAlta? Propuesta);

/// <summary>La propuesta después de la revisión en código. Sin errores, pasa a la persona.</summary>
public sealed record RevisionDeAlta(PropuestaDeAlta? Propuesta, IReadOnlyDictionary<string, string> Errores)
{
    public bool Aceptada => Propuesta is not null && Errores.Count == 0;
}

/// <summary>La respuesta de la persona al pedido de confirmación.</summary>
public sealed record ConfirmacionDeAlta(bool Confirmada);

public enum EstadoDelAlta
{
    /// <summary>La revisión en código o el caso de uso la rechazó: no se escribió nada.</summary>
    Rechazada,

    /// <summary>La persona no la confirmó: no se escribió nada.</summary>
    Descartada,

    /// <summary>La persona la confirmó y el caso de uso la guardó.</summary>
    Registrada,
}

public sealed record ResultadoDelAlta(EstadoDelAlta Estado, string Mensaje, IReadOnlyDictionary<string, string> Errores)
{
    public override string ToString() =>
        Errores.Count == 0 ? $"{Estado}: {Mensaje}" : $"{Estado}: {Mensaje} [{string.Join("; ", Errores.Select(e => $"{e.Key}: {e.Value}"))}]";
}
