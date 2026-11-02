namespace MovilidadUrbana.PruebaDeArquitectura.Application.Mutantes.R4;

// Mutación R4, parte 2: el núcleo guarda mensajes del modelo. Una propiedad con el nombre corto
// (gracias al global using) y otra con el nombre calificado, sin ningún using en el archivo.
public sealed class PropuestaConMensaje
{
    public ChatMessage? UltimoMensaje { get; set; }

    public Microsoft.Extensions.AI.ChatMessage? MensajeOriginal { get; set; }
}
