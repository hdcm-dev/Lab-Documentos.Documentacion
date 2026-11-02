using Microsoft.Agents.AI;
using Microsoft.Agents.AI.Workflows;
using Microsoft.Extensions.AI;
using MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.AI;

namespace MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.Workflows;

/// <summary>
/// Orquestación prearmada: dos agentes de MAF en secuencia (extractor → redactor), armados con
/// <c>AgentWorkflowBuilder.BuildSequential</c> y expuestos con la interfaz <c>AIAgent</c> mediante
/// <c>AsAIAgent()</c>. Quien lo llama no ve la diferencia con un agente, pero el orden sigue en el grafo.
/// </summary>
public static class AltaAsistidaSecuencial
{
    public const string NombreDelExtractor = "extractor";
    public const string NombreDelRedactor = "redactor";

    public static readonly string InstruccionesDelExtractor =
        ExtractorDeAltaLlm.Instrucciones +
        "Respondé sólo con una línea: nombre; provincia; código postal; habitantes (null en lo que falte).";

    public const string InstruccionesDelRedactor =
        "Con los datos que extrajo el paso anterior, escribí una sola oración para la persona que diga qué " +
        "localidad se va a agregar y le pida que confirme. No agregues datos que no estén en la conversación.";

    public static Workflow Construir(IChatClient chat, OpcionesDeIA ia)
    {
        AIAgent extractor = chat.AsAIAgent(new ChatClientAgentOptions
        {
            Name = NombreDelExtractor,
            ChatOptions = FabricaDeOpcionesDeChat.Crear(ia, InstruccionesDelExtractor),
        });
        AIAgent redactor = chat.AsAIAgent(new ChatClientAgentOptions
        {
            Name = NombreDelRedactor,
            ChatOptions = FabricaDeOpcionesDeChat.Crear(ia, InstruccionesDelRedactor),
        });

        return AgentWorkflowBuilder.BuildSequential(extractor, redactor);
    }

    /// <summary>El mismo workflow, con la interfaz de un agente.</summary>
    public static AIAgent ComoAgente(IChatClient chat, OpcionesDeIA ia) =>
        Construir(chat, ia).AsAIAgent(name: "alta-asistida");
}
