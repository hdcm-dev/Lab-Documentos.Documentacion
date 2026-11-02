using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovilidadUrbana.RagEnMemoria.Application.Ayuda;

namespace MovilidadUrbana.RagEnMemoria.Tests.Dobles;

/// <summary>Cliente de chat con guion: devuelve las respuestas en orden y guarda cada pedido.</summary>
public sealed class ClienteFalso(params Func<IReadOnlyList<ChatMessage>, ChatResponse>[] guion) : IChatClient
{
    public List<(List<ChatMessage> Mensajes, ChatOptions? Opciones)> Pedidos { get; } = [];

    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
    {
        var lista = messages.ToList();
        Pedidos.Add((lista, options?.Clone()));
        var paso = guion[Math.Min(Pedidos.Count - 1, guion.Length - 1)];
        return Task.FromResult(paso(lista));
    }

    public IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default) =>
        GetResponseAsync(messages, options, cancellationToken).ToStreaming(cancellationToken);

    public object? GetService(Type serviceType, object? serviceKey = null) => null;

    public void Dispose() { }

    public static Func<IReadOnlyList<ChatMessage>, ChatResponse> Texto(string texto) =>
        _ => new ChatResponse(new ChatMessage(ChatRole.Assistant, texto));

    public static Func<IReadOnlyList<ChatMessage>, ChatResponse> PideBuscar(string consulta, string idDeLlamada = "llamada-1") =>
        _ => new ChatResponse(new ChatMessage(ChatRole.Assistant,
            [new FunctionCallContent(idDeLlamada, "buscar_requisitos", new Dictionary<string, object?> { ["consulta"] = consulta })]));
}

internal static class ExtensionesDeStreaming
{
    public static async IAsyncEnumerable<ChatResponseUpdate> ToStreaming(this Task<ChatResponse> respuesta,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
    {
        foreach (var u in (await respuesta).ToChatResponseUpdates()) yield return u;
    }
}

/// <summary>Buscador falso: devuelve siempre los mismos fragmentos y cuenta las llamadas.</summary>
public sealed class BuscadorFalso(params FragmentoRecuperado[] fragmentos) : IBuscadorDeRequisitos
{
    public List<(string Consulta, int K)> Llamadas { get; } = [];

    public Task<IReadOnlyList<FragmentoRecuperado>> BuscarAsync(string consulta, int k, CancellationToken cancellationToken)
    {
        Llamadas.Add((consulta, k));
        return Task.FromResult<IReadOnlyList<FragmentoRecuperado>>(fragmentos.Take(k).ToList());
    }

    public static FragmentoRecuperado De(string fuente, double puntaje = 0.9)
    {
        var r = RequisitosDelDominio.Todos.Single(x => x.Fuente == fuente);
        return new(r.Fuente, r.Tema, r.Texto, puntaje);
    }
}

/// <summary>
/// Generador de embeddings falso y fijo: a cada texto conocido le asigna el vector que diga el mapa; a los
/// demás, el vector cero con un 1 en la última posición. Guarda lo que recibió.
/// </summary>
public sealed class GeneradorFalso(int dimension, IReadOnlyDictionary<string, float[]>? mapa = null) : IEmbeddingGenerator<string, Embedding<float>>
{
    public List<string> Recibidos { get; } = [];

    public Task<GeneratedEmbeddings<Embedding<float>>> GenerateAsync(IEnumerable<string> values, EmbeddingGenerationOptions? options = null, CancellationToken cancellationToken = default)
    {
        var lista = new List<Embedding<float>>();
        foreach (var v in values)
        {
            Recibidos.Add(v);
            if (mapa is not null && mapa.TryGetValue(v, out var fijo)) { lista.Add(new(fijo)); continue; }
            var x = new float[dimension];
            x[^1] = 1;
            lista.Add(new(x));
        }
        return Task.FromResult(new GeneratedEmbeddings<Embedding<float>>(lista));
    }

    public object? GetService(Type serviceType, object? serviceKey = null) => null;

    public void Dispose() { }

    /// <summary>Vector con pesos en las posiciones dadas (sin normalizar: coseno no lo necesita).</summary>
    public static float[] Vector(int dimension, params (int Posicion, float Peso)[] pesos)
    {
        var x = new float[dimension];
        foreach (var (i, p) in pesos) x[i] = p;
        return x;
    }
}

/// <summary>Anfitrión de prueba con la composición real de la ayuda y los dobles que se pasen.</summary>
public static class AnfitrionDePrueba
{
    public static IHost Crear(IChatClient chat, IEmbeddingGenerator<string, Embedding<float>> generador,
        Dictionary<string, string?>? cambios = null, IBuscadorDeRequisitos? buscador = null)
    {
        var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings { DisableDefaults = true });
        var config = new Dictionary<string, string?>
        {
            ["AI:Endpoint"] = "http://servidor-falso.invalid",
            ["AI:Modelo"] = "modelo-falso",
            ["AI:ModeloDeEmbeddings"] = "embeddings-falso",
            ["AI:DimensionDeEmbeddings"] = "32",
            ["AI:TimeoutSegundos"] = "5",
            ["AI:Rag:K"] = "3",
            ["AI:Rag:InstruccionDeConsulta"] = "Retrieve the requirement",
        };
        foreach (var (k, v) in cambios ?? []) config[k] = v;
        builder.Configuration.AddInMemoryCollection(config);
        builder.Services.AddOptions<Infrastructure.AI.OpcionesDeIA>()
            .Bind(builder.Configuration.GetSection(Infrastructure.AI.OpcionesDeIA.Seccion))
            .ValidateDataAnnotations().ValidateOnStart();
        builder.Services.AddSingleton(chat);
        builder.Services.AddSingleton(generador);
        builder.AgregarAyuda();
        if (buscador is not null) builder.Services.AddSingleton(buscador);   // pisa al almacén
        return builder.Build();
    }
}
