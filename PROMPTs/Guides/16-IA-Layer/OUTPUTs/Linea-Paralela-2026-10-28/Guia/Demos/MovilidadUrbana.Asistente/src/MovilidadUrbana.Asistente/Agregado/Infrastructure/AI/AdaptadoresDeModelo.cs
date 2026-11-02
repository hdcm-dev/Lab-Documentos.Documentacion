using System.Runtime.CompilerServices;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Asistente.Application.Abstractions;
using MovilidadUrbana.Asistente.Application.Asistente;
using MovilidadUrbana.Asistente.Application.Encuestas;
using MovilidadUrbana.Asistente.Application.Localidades;

namespace MovilidadUrbana.Asistente.Infrastructure.AI;

/// <summary>Arma las <see cref="ChatOptions"/> de cada pedido desde <see cref="OpcionesDeIA"/>.</summary>
public sealed class FabricaDeOpcionesDeChat(IOptions<OpcionesDeIA> opciones)
{
    public ChatOptions Crear(IList<AITool>? herramientas = null)
    {
        var o = opciones.Value;
        return new ChatOptions
        {
            ModelId = o.Modelo,
            Temperature = o.Muestreo.Temperatura,
            TopP = o.Muestreo.TopP,
            TopK = o.Muestreo.TopK,
            PresencePenalty = o.Muestreo.PresencePenalty,
            Seed = o.Muestreo.Semilla,
            MaxOutputTokens = o.MaximoDeTokensDeSalida,
            Reasoning = new ReasoningOptions { Effort = ReasoningEffort.None },
            AdditionalProperties = new AdditionalPropertiesDictionary { ["num_ctx"] = o.NumCtx },
            Tools = herramientas
        };
    }

    public static IEnumerable<ChatMessage> Historial(IReadOnlyList<TurnoDeConversacion> previos) =>
        previos.Select(t => new ChatMessage(t.Rol == RolDelTurno.Persona ? ChatRole.User : ChatRole.Assistant, t.Texto));
}

/// <summary>Clasifica el pedido con salida estructurada. Si no se puede leer o el valor no existe en el enum, FueraDeAlcance.</summary>
public sealed class ClasificadorDePedidoLlm(IChatClient chat, FabricaDeOpcionesDeChat fabrica) : IClasificadorDePedido
{
    public sealed record Clasificacion(IntencionDelPedido Intencion);

    public async Task<IntencionDelPedido> ClasificarAsync(string texto, CancellationToken cancellationToken)
    {
        var r = await chat.GetResponseAsync<Clasificacion>(
            [new(ChatRole.System, TextosDeInstruccion.Clasificar), new(ChatRole.User, texto)],
            fabrica.Crear(), cancellationToken: cancellationToken);
        return r.TryGetResult(out var c) && c is not null && Enum.IsDefined(c.Intencion)
            ? c.Intencion
            : IntencionDelPedido.FueraDeAlcance;
    }
}

/// <summary>Extracciones con salida estructurada. La forma no es validez: valida el núcleo después.</summary>
public sealed class ExtractoresLlm(IChatClient chat, FabricaDeOpcionesDeChat fabrica)
    : IExtractorDeLocalidad, IExtractorDeEncuesta, IExtractorDeBaja
{
    public Task<LocalidadPropuesta?> ExtraerAsync(string texto, CancellationToken cancellationToken) =>
        Extraer<LocalidadPropuesta>(TextosDeInstruccion.ExtraerLocalidad, texto, cancellationToken);

    public Task<EncuestaPaso2Propuesta?> ExtraerPaso2Async(string texto, CancellationToken cancellationToken) =>
        Extraer<EncuestaPaso2Propuesta>(TextosDeInstruccion.ExtraerPaso2, texto, cancellationToken);

    public Task<AccionSugerida?> ExtraerAsync(string texto, IReadOnlyList<LocalidadDeReferencia> disponibles, CancellationToken cancellationToken) =>
        Extraer<AccionSugerida>(TextosDeInstruccion.ExtraerBaja(disponibles), texto, cancellationToken);

    private async Task<T?> Extraer<T>(string sistema, string texto, CancellationToken cancellationToken) where T : class
    {
        var r = await chat.GetResponseAsync<T>(
            [new(ChatRole.System, sistema), new(ChatRole.User, $"Texto: {texto}")],
            fabrica.Crear(), cancellationToken: cancellationToken);
        return r.TryGetResult(out var valor) ? valor : null;   // sin resultado legible: camino sin IA
    }
}

/// <summary>Escalón 0: los 12 requisitos van enteros en el prompt, con su fuente para citarla.</summary>
public sealed class AyudaContextoFijo(IChatClient chat, FabricaDeOpcionesDeChat fabrica) : IAyuda
{
    public async IAsyncEnumerable<string> ResponderAsync(
        IReadOnlyList<TurnoDeConversacion> previos, string pregunta,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        List<ChatMessage> mensajes = [new(ChatRole.System, TextosDeInstruccion.Ayuda), .. FabricaDeOpcionesDeChat.Historial(previos), new(ChatRole.User, pregunta)];
        await foreach (var u in chat.GetStreamingResponseAsync(mensajes, fabrica.Crear(), cancellationToken))
            if (!string.IsNullOrEmpty(u.Text)) yield return u.Text;
    }
}

/// <summary>Consulta sobre los datos de la sesión con las herramientas de lectura del catálogo.</summary>
public sealed class ConsultaConHerramientasLlm(IChatClient chat, FabricaDeOpcionesDeChat fabrica) : IConsultaConHerramientas
{
    public async IAsyncEnumerable<string> ResponderAsync(
        IReadOnlyList<TurnoDeConversacion> previos, string texto,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        List<ChatMessage> mensajes = [new(ChatRole.System, TextosDeInstruccion.Consulta), .. FabricaDeOpcionesDeChat.Historial(previos), new(ChatRole.User, texto)];
        var opciones = fabrica.Crear([.. CatalogoDeHerramientas.Todas]);
        await foreach (var u in chat.GetStreamingResponseAsync(mensajes, opciones, cancellationToken))
            if (!string.IsNullOrEmpty(u.Text)) yield return u.Text;
    }
}
