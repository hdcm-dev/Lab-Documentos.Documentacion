using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Options;

namespace MovilidadUrbana.Streaming;

/// <summary>Resultado de una respuesta en streaming, completa o cortada por cancelación.</summary>
public sealed record ResultadoDelStreaming(
    string Texto,
    bool Cancelada,
    int Fragmentos,
    TimeSpan? PrimerFragmento,
    TimeSpan Total,
    ChatResponse? Respuesta);

/// <summary>Contesta preguntas sobre la encuesta de movilidad, fragmento a fragmento.</summary>
public sealed class AsistenteDeLaEncuesta(IChatClient cliente, IOptions<OpcionesDeIA> opciones)
{
    private readonly OpcionesDeIA _ia = opciones.Value;

    public List<ChatMessage> NuevaConversacion() => [new(ChatRole.System, ContextoDeLaEncuesta.Instrucciones)];

    public ChatOptions CrearOpcionesDeChat(int? semilla = null, int? maximoDeTokensDeSalida = null) => new()
    {
        Temperature = _ia.Muestreo.Temperatura,
        TopP = _ia.Muestreo.TopP,
        TopK = _ia.Muestreo.TopK,
        PresencePenalty = _ia.Muestreo.PresencePenalty,
        Seed = semilla,
        MaxOutputTokens = maximoDeTokensDeSalida,
        Reasoning = new ReasoningOptions { Effort = ReasoningEffort.None },      // think: false
        AdditionalProperties = new() { ["num_ctx"] = _ia.NumCtx },               // por pedido
    };

    public async Task<ResultadoDelStreaming> ResponderAsync(
        List<ChatMessage> historial,
        string pregunta,
        Action<string> alRecibirTexto,
        ChatOptions? opcionesDeChat = null,
        CancellationToken ct = default)
    {
        if (pregunta.Length > _ia.LargoMaximoDeEntrada)
            throw new ArgumentException($"La pregunta supera {_ia.LargoMaximoDeEntrada} caracteres.", nameof(pregunta));

        List<ChatMessage> pedido = [.. historial, new(ChatRole.User, pregunta)];
        List<ChatResponseUpdate> fragmentos = [];
        var texto = new StringBuilder();
        var reloj = Stopwatch.StartNew();
        TimeSpan? primero = null;

        try
        {
            await foreach (ChatResponseUpdate fragmento in
                cliente.GetStreamingResponseAsync(pedido, opcionesDeChat ?? CrearOpcionesDeChat(), ct))
            {
                fragmentos.Add(fragmento);
                if (string.IsNullOrEmpty(fragmento.Text)) continue;   // p. ej. el último, que trae el uso
                primero ??= reloj.Elapsed;
                texto.Append(fragmento.Text);
                alRecibirTexto(fragmento.Text);
            }
        }
        catch (OperationCanceledException) when (ct.IsCancellationRequested)
        {
            // Un proveedor corta lanzando la excepción…
        }

        // …y otro (OllamaSharp 5.5.0) termina la enumeración sin lanzar: se mira el token en los dos casos.
        if (ct.IsCancellationRequested)
        {
            // Respuesta cortada: el texto parcial se devuelve, pero no entra al historial.
            return new(texto.ToString(), true, fragmentos.Count, primero, reloj.Elapsed, null);
        }

        ChatResponse respuesta = fragmentos.ToChatResponse();
        historial.Add(new(ChatRole.User, pregunta));
        historial.AddMessages(fragmentos);
        return new(texto.ToString(), false, fragmentos.Count, primero, reloj.Elapsed, respuesta);
    }
}
