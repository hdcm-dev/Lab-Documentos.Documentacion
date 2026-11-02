using Microsoft.Extensions.AI;
using Microsoft.Extensions.Options;

namespace MovilidadUrbana.RagEnMemoria.Infrastructure.AI;

/// <summary>Arma las <see cref="ChatOptions"/> de cada pedido a partir de <see cref="OpcionesDeIA"/>.</summary>
public sealed class FabricaDeOpcionesDeChat(IOptions<OpcionesDeIA> opciones)
{
    /// <param name="semilla">Pisa la semilla de configuración (las pruebas con modelo declaran una por corrida).</param>
    public ChatOptions Crear(long? semilla = null, IList<AITool>? herramientas = null)
    {
        var ia = opciones.Value;
        var m = ia.Muestreo;
        var chat = new ChatOptions
        {
            Temperature = m.Temperatura,
            TopP = m.TopP,
            TopK = m.TopK,
            PresencePenalty = m.PenalizacionPorPresencia,
            Seed = semilla ?? m.Semilla,
            MaxOutputTokens = ia.MaxTokensDeSalida,
            Reasoning = m.ApagarRazonamiento ? new ReasoningOptions { Effort = ReasoningEffort.None } : null,
            Tools = herramientas,
            // num_ctx, min_p y repeat_penalty sólo llegan por la vía nativa, dentro de "options".
            AdditionalProperties = new() { ["num_ctx"] = ia.NumCtx },
        };
        if (m.MinP is { } minP) chat.AdditionalProperties["min_p"] = minP;
        if (m.PenalizacionPorRepeticion is { } rep) chat.AdditionalProperties["repeat_penalty"] = rep;
        return chat;
    }
}
