using Microsoft.Extensions.AI;
using Microsoft.Extensions.Options;
using MovilidadUrbana.RagEnMemoria.Application.Ayuda;

namespace MovilidadUrbana.RagEnMemoria.Infrastructure.AI;

/// <summary>
/// Escalón 0, contexto fijo: los 12 requisitos van enteros, siempre, en el mensaje del sistema. El
/// prefijo es idéntico en cada pedido (instrucción + fragmentos) y la pregunta va al final, así el
/// servidor puede reusar el prefijo ya leído.
/// </summary>
public sealed class AyudaContextoFijo(IChatClient chat, FabricaDeOpcionesDeChat fabrica, IOptions<OpcionesDeIA> opciones) : IAyuda
{
    public async Task<RespuestaDeAyuda> ResponderAsync(string pregunta, long? semilla, CancellationToken cancellationToken)
    {
        ValidarEntrada.Pregunta(pregunta, opciones.Value);
        var todos = RequisitosDelDominio.Todos.Select(r => new FragmentoRecuperado(r.Fuente, r.Tema, r.Texto, 1)).ToList();
        var sistema = TextosDeInstruccion.Ayuda + "\n" + ContenidoExterno.Envolver(todos, opciones.Value.LargoMaximoDeFragmentos);
        var r = await chat.GetResponseAsync(
            [new(ChatRole.System, sistema), new(ChatRole.User, TextosDeInstruccion.Pregunta(pregunta))],
            fabrica.Crear(semilla), cancellationToken);
        return new(r.Text, Citas.Leer(r.Text), todos, r.Usage?.InputTokenCount, r.Usage?.OutputTokenCount);
    }
}

/// <summary>
/// Vía A, paso fijo: la aplicación busca SIEMPRE antes de llamar al modelo y pone los k fragmentos
/// recuperados en el pedido. Determinista hasta el modelo: se prueba entera con un buscador falso.
/// </summary>
public sealed class AyudaRag(IChatClient chat, IBuscadorDeRequisitos buscador, FabricaDeOpcionesDeChat fabrica, IOptions<OpcionesDeIA> opciones) : IAyuda
{
    public async Task<RespuestaDeAyuda> ResponderAsync(string pregunta, long? semilla, CancellationToken cancellationToken)
    {
        var ia = opciones.Value;
        ValidarEntrada.Pregunta(pregunta, ia);
        var fragmentos = await buscador.BuscarAsync(pregunta, ia.Rag.K, cancellationToken);

        // Instrucción fija primero (prefijo estable); fragmentos variables y pregunta al final.
        var usuario = ContenidoExterno.Envolver(fragmentos, ia.LargoMaximoDeFragmentos) + "\n\n" + TextosDeInstruccion.Pregunta(pregunta);
        var r = await chat.GetResponseAsync(
            [new(ChatRole.System, TextosDeInstruccion.Ayuda), new(ChatRole.User, usuario)],
            fabrica.Crear(semilla), cancellationToken);
        return new(r.Text, Citas.Leer(r.Text), fragmentos, r.Usage?.InputTokenCount, r.Usage?.OutputTokenCount);
    }
}

/// <summary>
/// Vía B, herramienta: el modelo decide si busca. Sirve cuando conviven preguntas de requisitos con
/// otras que no los necesitan; el costo es que el modelo puede contestar sin buscar.
/// </summary>
public sealed class AyudaRagConHerramienta(IChatClient chat, IBuscadorDeRequisitos buscador, FabricaDeOpcionesDeChat fabrica, IOptions<OpcionesDeIA> opciones) : IAyuda
{
    public async Task<RespuestaDeAyuda> ResponderAsync(string pregunta, long? semilla, CancellationToken cancellationToken)
    {
        var ia = opciones.Value;
        ValidarEntrada.Pregunta(pregunta, ia);
        var herramienta = new HerramientaDeBusqueda(buscador, ia);

        using var conHerramientas = new ChatClientBuilder(chat)
            .UseFunctionInvocation(configure: f => f.MaximumIterationsPerRequest = ia.Rag.MaximoDeIteraciones)
            .Build();
        var r = await conHerramientas.GetResponseAsync(
            [new(ChatRole.System, TextosDeInstruccion.AyudaConHerramienta), new(ChatRole.User, TextosDeInstruccion.Pregunta(pregunta))],
            fabrica.Crear(semilla, [herramienta.Funcion]), cancellationToken);
        return new(r.Text, Citas.Leer(r.Text), herramienta.Recuperados, r.Usage?.InputTokenCount, r.Usage?.OutputTokenCount);
    }
}

/// <summary>La búsqueda publicada como <see cref="AIFunction"/>, con registro de lo que devolvió.</summary>
public sealed class HerramientaDeBusqueda
{
    private readonly List<FragmentoRecuperado> _recuperados = [];

    public HerramientaDeBusqueda(IBuscadorDeRequisitos buscador, OpcionesDeIA ia)
    {
        Funcion = AIFunctionFactory.Create(
            async (string consulta, CancellationToken ct) =>
            {
                var fragmentos = await buscador.BuscarAsync(consulta, ia.Rag.K, ct);
                _recuperados.AddRange(fragmentos);
                return ContenidoExterno.Envolver(fragmentos, ia.LargoMaximoDeFragmentos);
            },
            TextosDeInstruccion.NombreDeLaHerramienta,
            TextosDeInstruccion.DescripcionDeLaHerramienta);
    }

    public AIFunction Funcion { get; }

    /// <summary>Lo que la herramienta devolvió en este pedido (vacío si el modelo no buscó).</summary>
    public IReadOnlyList<FragmentoRecuperado> Recuperados => _recuperados;
}

internal static class ValidarEntrada
{
    public static void Pregunta(string pregunta, OpcionesDeIA ia)
    {
        if (string.IsNullOrWhiteSpace(pregunta))
            throw new ArgumentException("La pregunta está vacía.", nameof(pregunta));
        if (pregunta.Length > ia.LargoMaximoDeEntrada)
            throw new ArgumentException($"La pregunta supera {ia.LargoMaximoDeEntrada} caracteres.", nameof(pregunta));
    }
}
