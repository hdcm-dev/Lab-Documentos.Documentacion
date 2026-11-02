namespace MovilidadUrbana.PruebaDeArquitectura.Application.Mutantes.Nameof;

// Agujero declarado 2: nameof se resuelve al compilar y queda como una cadena.
public static class NombreDelTipo
{
    public const string Mensaje = nameof(Microsoft.Extensions.AI.ChatMessage);
}
