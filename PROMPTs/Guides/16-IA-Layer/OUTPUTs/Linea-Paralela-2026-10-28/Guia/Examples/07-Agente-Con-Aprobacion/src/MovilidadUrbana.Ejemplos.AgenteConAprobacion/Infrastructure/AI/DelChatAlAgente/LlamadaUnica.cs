using Microsoft.Extensions.AI;

namespace MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI.DelChatAlAgente;

/// <summary>Paso 4.1: una pregunta, el bucle de UseFunctionInvocation y una respuesta. Sin agente.</summary>
public static class LlamadaUnica
{
    public static async Task<string> PreguntarAsync(
        IChatClient chat, HerramientasDeLocalidades herramientas, ChatOptions opciones, string pregunta,
        CancellationToken ct = default)
    {
        opciones.Tools = [herramientas.ContarLocalidades()];
        ChatResponse respuesta = await chat.GetResponseAsync(
            [new(ChatRole.System, Instrucciones.DelAsistente), new(ChatRole.User, pregunta)], opciones, ct);
        return respuesta.Text;
    }
}
