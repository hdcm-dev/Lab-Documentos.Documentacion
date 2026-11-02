using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace MovilidadUrbana.Ejemplos.AnotacionesPareadas.Infrastructure.AI.AgentFramework;

/// <summary>Después: <c>AsAIAgent</c> con la herramienta de <c>AIFunctionFactory</c>, sobre el mismo <c>IChatClient</c>.</summary>
public static class AgenteDeAgentFramework
{
    public static async Task<string> PreguntarAsync(IChatClient chat, HerramientasDeResultados herramientas, string pregunta, CancellationToken ct = default)
    {
        AIAgent agente = chat.AsAIAgent(
            instructions: Instrucciones.DelAsistente,
            name: "AsistenteDeResultados",
            tools: [herramientas.ComoAIFunction()]);
        AgentSession sesion = await agente.CreateSessionAsync(ct);

        AgentResponse respuesta = await agente.RunAsync(pregunta, sesion, cancellationToken: ct);
        return respuesta.Text;
    }
}
