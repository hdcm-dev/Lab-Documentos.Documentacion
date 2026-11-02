using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using MovilidadUrbana.Ejemplos.Mcp.Cliente.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.Mcp.Cliente.Mcp;

namespace MovilidadUrbana.Ejemplos.Mcp.Cliente;

/// <summary>Una llamada a herramienta tal como quedó en la respuesta del agente.</summary>
public sealed record LlamadaObservada(string Nombre, string Argumentos, string Resultado);

/// <summary>Lo que devuelve una pregunta: el texto y las herramientas que se ejecutaron por MCP.</summary>
public sealed record RespuestaDelAgente(string Texto, IReadOnlyList<LlamadaObservada> Herramientas);

/// <summary>
/// Agente de MAF cuyas herramientas son <see cref="ModelContextProtocol.Client.McpClientTool"/>: cada llamada
/// del modelo viaja por MCP al servidor propio, que la ejecuta sobre sus casos de uso de lectura.
/// </summary>
public sealed class AgenteDeLocalidadesPorMcp(IChatClient chat, HerramientasFiltradas herramientas, OpcionesDeIA ia)
{
    public const string Instrucciones =
        "Sos el asistente de la encuesta de movilidad urbana. Para cualquier dato de localidades usá las " +
        "herramientas; no inventes cantidades ni nombres. Si una herramienta devuelve errores, explicáselos a la persona. " +
        "Respondé en español, en una o dos oraciones.";

    private readonly AIAgent _agente = chat.AsAIAgent(
        instructions: Instrucciones,
        name: "AsistenteDeLocalidadesPorMcp",
        tools: herramientas.ComoHerramientas());

    public async Task<RespuestaDelAgente> PreguntarAsync(string pregunta, CancellationToken ct = default)
    {
        if (pregunta.Length > ia.LargoMaximoDeEntrada)
            throw new ArgumentException($"La pregunta supera {ia.LargoMaximoDeEntrada} caracteres.", nameof(pregunta));

        var opciones = new ChatClientAgentRunOptions(FabricaDeOpcionesDeChat.Crear(ia));
        var respuesta = await _agente.RunAsync(pregunta, session: null, options: opciones, cancellationToken: ct);

        var contenidos = respuesta.Messages.SelectMany(m => m.Contents).ToList();
        var resultados = contenidos.OfType<FunctionResultContent>().ToDictionary(r => r.CallId);
        var llamadas = contenidos.OfType<FunctionCallContent>()
            .Select(c => new LlamadaObservada(
                c.Name,
                System.Text.Json.JsonSerializer.Serialize(c.Arguments),
                resultados.TryGetValue(c.CallId, out var r) ? Texto(r.Result) : "(sin resultado)"))
            .ToList();
        return new(respuesta.Text, llamadas);
    }

    private static string Texto(object? resultado) => resultado switch
    {
        null => "null",
        string s => s,
        TextContent t => t.Text,                                            // lo que devuelve una McpClientTool
        IEnumerable<AIContent> partes => string.Join(" ", partes.Select(Texto)),
        System.Text.Json.JsonElement e => e.GetRawText(),
        _ => System.Text.Json.JsonSerializer.Serialize(resultado),
    };
}
