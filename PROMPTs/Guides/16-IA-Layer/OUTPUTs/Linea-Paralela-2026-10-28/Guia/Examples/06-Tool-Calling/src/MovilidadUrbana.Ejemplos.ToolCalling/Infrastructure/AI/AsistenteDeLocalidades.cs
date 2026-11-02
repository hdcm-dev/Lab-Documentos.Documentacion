using System.Text.Json;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.ToolCalling.Application.Asistente;

namespace MovilidadUrbana.Ejemplos.ToolCalling.Infrastructure.AI;

/// <summary>
/// Adaptador del puerto <see cref="IAsistenteDeLocalidades"/>: el único que ve <see cref="IChatClient"/>.
/// Es un agente mínimo: el modelo decide, en un bucle acotado, qué herramienta pedir y cuándo terminar;
/// la aplicación ejecuta cada pedido (lo hace <c>FunctionInvokingChatClient</c>, dentro del cliente).
/// </summary>
public sealed class AsistenteDeLocalidades(
    IChatClient chat, HerramientasDeLocalidades herramientas, IOptions<OpcionesDeIA> opciones) : IAsistenteDeLocalidades
{
    public const string InstruccionesDelSistema =
        "Sos el asistente de la encuesta de Movilidad Urbana. Respondé en español, en una o dos oraciones. " +
        "Para cualquier dato sobre las localidades cargadas usá las herramientas; no inventes cantidades. " +
        "Si una herramienta devuelve errores, explicáselos a la persona con tus palabras.";

    public async Task<RespuestaDelAsistente> PreguntarAsync(string texto, CancellationToken ct = default)
    {
        var ia = opciones.Value;
        if (texto.Length > ia.LargoMaximoDeEntrada)
            throw new EntradaDemasiadoLargaException(texto.Length, ia.LargoMaximoDeEntrada); // antes de llamar al modelo

        List<ChatMessage> mensajes = [new(ChatRole.System, InstruccionesDelSistema), new(ChatRole.User, texto)];
        ChatResponse r = await chat.GetResponseAsync(mensajes, FabricaDeOpcionesDeChat.Crear(ia, herramientas.Crear()), ct);
        return new RespuestaDelAsistente(r.Text.Trim(), Llamadas(r));
    }

    /// <summary>Empareja cada pedido de herramienta con su resultado, tal como quedaron en la respuesta.</summary>
    public static IReadOnlyList<LlamadaAHerramienta> Llamadas(ChatResponse r)
    {
        var contenidos = r.Messages.SelectMany(m => m.Contents).ToList();
        var resultados = contenidos.OfType<FunctionResultContent>().ToDictionary(x => x.CallId);
        return contenidos.OfType<FunctionCallContent>()
            .Select(c => new LlamadaAHerramienta(
                c.Name,
                JsonSerializer.Serialize(c.Arguments),
                resultados.TryGetValue(c.CallId, out var res) ? Texto(res.Result) : "(sin resultado)"))
            .ToList();
    }

    private static string Texto(object? resultado) => resultado switch
    {
        null => "null",
        string s => s,
        JsonElement e => e.GetRawText(),
        _ => JsonSerializer.Serialize(resultado),
    };
}

public sealed class EntradaDemasiadoLargaException(int largo, int maximo)
    : Exception($"La entrada tiene {largo} caracteres; el máximo es {maximo}.")
{
    public int Largo { get; } = largo;
    public int Maximo { get; } = maximo;
}
