using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI.DelChatAlAgente;

/// <summary>Paso 4.2: el MISMO IChatClient, ahora como agente de MAF con sesión de varios turnos.</summary>
public static class AgenteDeMaf
{
    public static AIAgent Crear(IChatClient chat, HerramientasDeLocalidades herramientas) =>
        chat.AsAIAgent(
            instructions: Instrucciones.DelAsistente,
            name: "AsistenteDeLocalidades",
            tools: [herramientas.ContarLocalidades()]);

    public static async Task<IReadOnlyList<string>> ConversarAsync(
        AIAgent agente, ChatOptions opciones, IEnumerable<string> preguntas, CancellationToken ct = default)
    {
        AgentSession sesion = await agente.CreateSessionAsync(ct);   // el historial vive en la sesión
        var respuestas = new List<string>();
        foreach (var pregunta in preguntas)
            respuestas.Add((await agente.RunAsync(pregunta, sesion, new ChatClientAgentRunOptions(opciones), ct)).Text);
        return respuestas;
    }
}
