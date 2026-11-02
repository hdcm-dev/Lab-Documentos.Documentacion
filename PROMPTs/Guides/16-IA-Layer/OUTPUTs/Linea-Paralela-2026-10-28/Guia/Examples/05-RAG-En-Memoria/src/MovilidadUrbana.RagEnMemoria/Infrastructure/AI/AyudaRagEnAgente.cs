using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Options;
using MovilidadUrbana.RagEnMemoria.Application.Ayuda;

namespace MovilidadUrbana.RagEnMemoria.Infrastructure.AI;

/// <summary>
/// Vía C: la misma recuperación dentro de un agente de MAF (<see cref="AIAgent"/>), con la búsqueda como
/// herramienta. Es la vía B con otro anfitrión del bucle; se enseña en la sección de agentes.
/// </summary>
public sealed class AyudaRagEnAgente(IChatClient chat, IBuscadorDeRequisitos buscador, FabricaDeOpcionesDeChat fabrica, IOptions<OpcionesDeIA> opciones) : IAyuda
{
    public async Task<RespuestaDeAyuda> ResponderAsync(string pregunta, long? semilla, CancellationToken cancellationToken)
    {
        var ia = opciones.Value;
        ValidarEntrada.Pregunta(pregunta, ia);
        var herramienta = new HerramientaDeBusqueda(buscador, ia);

        AIAgent agente = chat.AsAIAgent(new ChatClientAgentOptions
        {
            Name = "ayuda-de-requisitos",
            ChatOptions = Con(fabrica.Crear(semilla, [herramienta.Funcion]), TextosDeInstruccion.AyudaConHerramienta),
        });
        AgentResponse r = await agente.RunAsync(TextosDeInstruccion.Pregunta(pregunta), cancellationToken: cancellationToken);
        return new(r.Text, Citas.Leer(r.Text), herramienta.Recuperados, r.Usage?.InputTokenCount, r.Usage?.OutputTokenCount);
    }

    private static ChatOptions Con(ChatOptions o, string instrucciones)
    {
        o.Instructions = instrucciones;
        return o;
    }
}
