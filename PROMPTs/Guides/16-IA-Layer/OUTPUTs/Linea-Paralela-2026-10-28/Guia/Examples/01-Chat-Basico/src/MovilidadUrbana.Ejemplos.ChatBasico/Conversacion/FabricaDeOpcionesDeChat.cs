using Microsoft.Extensions.AI;
using MovilidadUrbana.Ejemplos.ChatBasico.Configuracion;

namespace MovilidadUrbana.Ejemplos.ChatBasico.Conversacion;

/// <summary>Arma las <see cref="ChatOptions"/> de cada pedido a partir de <see cref="OpcionesDeIA"/>.</summary>
public static class FabricaDeOpcionesDeChat
{
    public static ChatOptions Crear(OpcionesDeIA ia)
    {
        var m = ia.Muestreo;
        var opciones = new ChatOptions
        {
            Temperature = m.Temperatura,
            TopP = m.TopP,
            TopK = m.TopK,                      // por /v1 se descarta en silencio
            PresencePenalty = m.PenalizacionPorPresencia,
            Seed = m.Semilla,
            Reasoning = m.ApagarRazonamiento ? new ReasoningOptions { Effort = ReasoningEffort.None } : null,
        };

        if (ia.Proveedor == Proveedores.Ollama)
        {
            // Sólo la vía nativa los lleva al servidor, dentro de "options".
            opciones.AdditionalProperties = new() { ["num_ctx"] = ia.NumCtx };
            if (m.MinP is { } minP) opciones.AdditionalProperties["min_p"] = minP;
            if (m.PenalizacionPorRepeticion is { } rep) opciones.AdditionalProperties["repeat_penalty"] = rep;
        }

        return opciones;
    }
}
