using Microsoft.Extensions.AI;

// Tipos de prueba, a propósito en contra de la regla de capas: sirven de casos rojos.
namespace MovilidadUrbana.Asistente.Tests.Cableado.Rojo.Application;

public sealed class ConPropiedad
{
    public ChatMessage? Mensaje { get; set; }
}

public sealed class SoloEnElCuerpo
{
    public string Texto() => new ChatMessage(ChatRole.User, "hola").Text;
}
