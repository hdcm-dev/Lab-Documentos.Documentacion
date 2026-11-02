using Microsoft.Extensions.AI;

namespace MovilidadUrbana.Ejemplos.Mcp.Cliente.Infrastructure.AI;

/// <summary>
/// Arma las <see cref="ChatOptions"/> de cada pedido a partir de <see cref="OpcionesDeIA"/>.
/// Las herramientas no van acá: las pone quien llama (la llamada única) o el agente.
/// </summary>
public static class FabricaDeOpcionesDeChat
{
    public static ChatOptions Crear(OpcionesDeIA ia)
    {
        var m = ia.Muestreo;
        var opciones = new ChatOptions
        {
            Temperature = m.Temperatura,
            TopP = m.TopP,
            TopK = m.TopK,
            PresencePenalty = m.PenalizacionPorPresencia,
            Seed = m.Semilla,
            Reasoning = m.ApagarRazonamiento ? new ReasoningOptions { Effort = ReasoningEffort.None } : null,
            ToolMode = ChatToolMode.Auto,
            // Vía nativa: viajan dentro de "options" del pedido a /api/chat.
            AdditionalProperties = new() { ["num_ctx"] = ia.NumCtx },
        };
        if (m.MinP is { } minP) opciones.AdditionalProperties["min_p"] = minP;
        if (m.PenalizacionPorRepeticion is { } rep) opciones.AdditionalProperties["repeat_penalty"] = rep;
        return opciones;
    }
}
