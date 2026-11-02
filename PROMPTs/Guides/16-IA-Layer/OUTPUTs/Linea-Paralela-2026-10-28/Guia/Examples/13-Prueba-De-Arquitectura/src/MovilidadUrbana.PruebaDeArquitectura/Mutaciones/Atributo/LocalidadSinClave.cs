namespace MovilidadUrbana.PruebaDeArquitectura.Application.Mutantes.Atributo;

// Caso rojo por atributo: un atributo de EF Core en un tipo del núcleo.
[Microsoft.EntityFrameworkCore.Keyless]
public sealed class LocalidadSinClave
{
    public string Nombre { get; set; } = string.Empty;
}
