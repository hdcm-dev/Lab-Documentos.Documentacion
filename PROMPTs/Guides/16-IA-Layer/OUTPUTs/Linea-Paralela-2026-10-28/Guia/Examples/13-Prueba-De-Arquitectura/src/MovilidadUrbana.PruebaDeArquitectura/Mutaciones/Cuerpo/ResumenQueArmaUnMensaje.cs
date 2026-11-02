namespace MovilidadUrbana.PruebaDeArquitectura.Application.Mutantes.Cuerpo;

// Segundo caso rojo: el tipo prohibido aparece sólo dentro del cuerpo de un método. La firma
// (base, interfaces, campos, propiedades, parámetros, retornos) queda limpia.
public sealed class ResumenQueArmaUnMensaje
{
    public int LargoDelSaludo(string nombre) =>
        new Microsoft.Extensions.AI.ChatMessage(Microsoft.Extensions.AI.ChatRole.User, $"Hola, {nombre}").Text.Length;
}
