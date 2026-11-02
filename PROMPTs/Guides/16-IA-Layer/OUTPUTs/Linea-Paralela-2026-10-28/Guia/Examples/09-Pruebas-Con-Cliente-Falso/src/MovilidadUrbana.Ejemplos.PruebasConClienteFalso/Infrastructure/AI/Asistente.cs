using Microsoft.Extensions.AI;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Asistente;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;

/// <summary>Adaptador del puerto <see cref="IAsistente"/>: el único que ve <see cref="IChatClient"/>.</summary>
public sealed class Asistente(IChatClient chat, IOptions<OpcionesDeIA> opciones) : IAsistente
{
    public const string InstruccionesDelSistema =
        "Sos el asistente de la encuesta de Movilidad Urbana. Para saber cuántas localidades hay cargadas en una " +
        "provincia, usá la herramienta; no inventes cantidades. Respondé en una sola oración.";

    public async Task<string> PreguntarAsync(string texto, CancellationToken cancellationToken = default)
    {
        var ia = opciones.Value;
        if (texto.Length > ia.LargoMaximoDeEntrada)
            throw new EntradaDemasiadoLargaException(texto.Length, ia.LargoMaximoDeEntrada);

        var respuesta = await chat.GetResponseAsync(
            [new ChatMessage(ChatRole.System, InstruccionesDelSistema), new ChatMessage(ChatRole.User, texto)],
            CrearOpciones(ia, HerramientasDeLocalidades.Catalogo),
            cancellationToken);
        return respuesta.Text;
    }

    /// <summary>Opciones de cada pedido, todas desde <see cref="OpcionesDeIA"/>. <c>num_ctx</c> viaja en cada pedido.</summary>
    public static ChatOptions CrearOpciones(OpcionesDeIA ia, IList<AITool>? herramientas = null)
    {
        var m = ia.Muestreo;
        return new ChatOptions
        {
            Temperature = m.Temperatura,
            TopP = m.TopP,
            TopK = m.TopK,
            PresencePenalty = m.PenalizacionPorPresencia,
            Seed = m.Semilla,
            Reasoning = m.ApagarRazonamiento ? new ReasoningOptions { Effort = ReasoningEffort.None } : null,
            Tools = herramientas,
            AdditionalProperties = new() { ["num_ctx"] = ia.NumCtx },
        };
    }
}
