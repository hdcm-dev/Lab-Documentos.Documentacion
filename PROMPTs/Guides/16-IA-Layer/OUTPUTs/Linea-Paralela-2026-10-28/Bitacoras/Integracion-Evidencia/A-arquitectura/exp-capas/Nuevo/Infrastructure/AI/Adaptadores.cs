using System.ComponentModel;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.Asistente.Application.Abstractions;

namespace MovilidadUrbana.Asistente.Infrastructure.AI;

/// <summary>Vía A — RAG como paso fijo de un workflow: siempre recupera, una sola llamada al modelo, sin agente.</summary>
public sealed class AyudaRag(BuscadorDeRequisitos buscador, IChatClient chat, ChatOptions opciones) : IAyuda
{
    public async Task<RespuestaConFuentes> ResponderAsync(string pregunta, CancellationToken ct = default)
    {
        var fuentes = await buscador.BuscarAsync(pregunta, 3, ct);
        var r = await chat.GetResponseAsync([
            new(ChatRole.System, "Respondé en una oración, sólo con las FUENTES, citando [id]. Si no alcanzan, decí que no sabés."),
            new(ChatRole.User, "FUENTES:\n" + string.Join("\n", fuentes.Select(f => $"[{f.Id}] {f.Texto}")) + "\n\nPREGUNTA: " + pregunta)],
            opciones.Clone(), ct);
        return new(r.Text, fuentes.Select(f => f.Id).ToList());
    }
}

/// <summary>Vía B — recuperación como herramienta: el modelo decide si busca requisitos o consulta un caso de uso.</summary>
public sealed class AsistenteDeMovilidadLlm(IChatClient chatConHerramientas, ChatOptions opciones, BuscadorDeRequisitos buscador, LocalidadService localidades) : IAsistenteDeMovilidad
{
    public IList<AITool> Herramientas() => [
        AIFunctionFactory.Create(
            [Description("Busca los requisitos de carga de localidades y de la encuesta.")]
            async ([Description("La pregunta sobre un requisito")] string pregunta, CancellationToken ct) =>
                string.Join("\n", (await buscador.BuscarAsync(pregunta, 3, ct)).Select(f => $"[{f.Id}] {f.Texto}")),
            "buscar_requisitos"),
        AIFunctionFactory.Create(
            [Description("Cuenta cuántas localidades cargadas hay en una provincia.")]
            async ([Description("Nombre de la provincia")] string provincia, CancellationToken ct) =>
                (await localidades.GetAllAsync(ct)).Count(l => string.Equals(l.Provincia, provincia, StringComparison.OrdinalIgnoreCase)),
            "contar_localidades_por_provincia")];

    public async Task<string> ResponderAsync(string pedido, CancellationToken ct = default)
    {
        var o = opciones.Clone(); o.Tools = Herramientas();
        var r = await chatConHerramientas.GetResponseAsync([
            new(ChatRole.System, "Sos el asistente de Movilidad Urbana. Usá las herramientas; no inventes datos."),
            new(ChatRole.User, pedido)], o, ct);
        return r.Text;
    }
}

/// <summary>Vía C — recuperación como proveedor de contexto de un agente de Agent Framework (antes de cada corrida).</summary>
public sealed class ProveedorDeRequisitos(BuscadorDeRequisitos buscador) : AIContextProvider(null, null, null)
{
    protected override async ValueTask<AIContext> ProvideAIContextAsync(InvokingContext context, CancellationToken cancellationToken = default)
    {
        var ultima = context.AIContext.Messages?.LastOrDefault(m => m.Role == ChatRole.User)?.Text ?? "";
        var fuentes = await buscador.BuscarAsync(ultima, 2, cancellationToken);
        return new AIContext { Instructions = "Requisitos relevantes:\n" + string.Join("\n", fuentes.Select(f => $"[{f.Id}] {f.Texto}")) };
    }
}
