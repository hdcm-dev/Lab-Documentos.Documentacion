using Microsoft.Extensions.AI;

namespace MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.AI;

/// <summary>Arma las <see cref="ChatOptions"/> de cada pedido a partir de <see cref="OpcionesDeIA"/>. Ningún paso ofrece herramientas.</summary>
public static class FabricaDeOpcionesDeChat
{
    public static ChatOptions Crear(OpcionesDeIA ia, string? instrucciones = null)
    {
        var m = ia.Muestreo;
        return new ChatOptions
        {
            Instructions = instrucciones,
            Temperature = m.Temperatura,
            TopP = m.TopP,
            TopK = m.TopK,
            PresencePenalty = m.PenalizacionPorPresencia,
            Seed = m.Semilla,
            Reasoning = m.ApagarRazonamiento ? new ReasoningOptions { Effort = ReasoningEffort.None } : null,
            // Vía nativa: num_ctx viaja por pedido, dentro de "options".
            AdditionalProperties = new() { ["num_ctx"] = ia.NumCtx },
        };
    }
}
