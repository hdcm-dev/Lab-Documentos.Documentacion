using CommunityToolkit.VectorData.InMemory;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.VectorData;
using MovilidadUrbana.RagEnMemoria.Application.Ayuda;
using MovilidadUrbana.RagEnMemoria.Infrastructure.AI;

namespace MovilidadUrbana.RagEnMemoria.Infrastructure.Persistence;

/// <summary>Registro del almacén: un requisito por fragmento (ya son atómicos), con su texto aparte del vector.</summary>
public sealed class FragmentoDeRequisito
{
    public string Id { get; set; } = "";
    public string Fuente { get; set; } = "";
    public string Tema { get; set; } = "";
    public string Texto { get; set; } = "";
    public ReadOnlyMemory<float> Vector { get; set; }
}

/// <summary>
/// Almacén vectorial en memoria (MEVD + InMemory, GA). Los embeddings los genera este adaptador, no el
/// almacén, para poder aplicar la asimetría de Qwen3-Embedding: instrucción en la consulta, nunca en el
/// documento. La colección se define en tiempo de ejecución porque la dimensión sale de la configuración.
/// </summary>
public sealed class AlmacenDeRequisitos(
    IEmbeddingGenerator<string, Embedding<float>> generador, IOptions<OpcionesDeIA> opciones) : IBuscadorDeRequisitos
{
    public const string Coleccion = "requisitos";

    private VectorStoreCollection<string, FragmentoDeRequisito>? _coleccion;

    /// <summary>Dimensión con la que quedó declarado el almacén (después de <see cref="IniciarAsync"/>).</summary>
    public int Dimension { get; private set; }

    public static VectorStoreCollectionDefinition Definicion(int dimension) => new()
    {
        Properties =
        [
            new VectorStoreKeyProperty(nameof(FragmentoDeRequisito.Id), typeof(string)),
            new VectorStoreDataProperty(nameof(FragmentoDeRequisito.Fuente), typeof(string)) { IsIndexed = true },
            new VectorStoreDataProperty(nameof(FragmentoDeRequisito.Tema), typeof(string)),
            new VectorStoreDataProperty(nameof(FragmentoDeRequisito.Texto), typeof(string)),
            new VectorStoreVectorProperty(nameof(FragmentoDeRequisito.Vector), typeof(ReadOnlyMemory<float>), dimension)
            {
                DistanceFunction = DistanceFunction.CosineSimilarity,   // mayor es mejor
            },
        ],
    };

    /// <summary>
    /// Valida la dimensión con un embedding de prueba y carga el corpus. Si el largo medido no coincide con
    /// el declarado, lanza: vectores de dimensiones distintas no son comparables y nada más lo avisa.
    /// </summary>
    public async Task IniciarAsync(CancellationToken cancellationToken = default)
    {
        var ia = opciones.Value;
        var prueba = await generador.GenerateVectorAsync("prueba de dimensión", cancellationToken: cancellationToken);
        if (ia.DimensionDeEmbeddings is { } declarada && declarada != prueba.Length)
            throw new InvalidOperationException(
                $"El modelo de embeddings '{ia.ModeloDeEmbeddings}' devuelve vectores de {prueba.Length} " +
                $"y el almacén declara {declarada} (AI:DimensionDeEmbeddings). No se arranca.");
        Dimension = prueba.Length;

        var store = new InMemoryVectorStore();
        _coleccion = store.GetCollection<string, FragmentoDeRequisito>(Coleccion, Definicion(Dimension));
        await _coleccion.EnsureCollectionExistsAsync(cancellationToken);

        var corpus = RequisitosDelDominio.Todos;
        var vectores = await generador.GenerateAsync(corpus.Select(TextoDelDocumento), cancellationToken: cancellationToken);
        await _coleccion.UpsertAsync(
            corpus.Select((r, i) => new FragmentoDeRequisito
            {
                Id = r.Fuente, Fuente = r.Fuente, Tema = r.Tema, Texto = r.Texto, Vector = vectores[i].Vector,
            }),
            cancellationToken);
    }

    /// <summary>El documento va sin instrucción: tema y texto del requisito.</summary>
    public static string TextoDelDocumento(Requisito r) => $"{r.Tema}: {r.Texto}";

    /// <summary>La consulta lleva la instrucción de tarea si está configurada (formato de la ficha del modelo).</summary>
    public static string TextoDeLaConsulta(string consulta, string? instruccion) =>
        string.IsNullOrWhiteSpace(instruccion) ? consulta : $"Instruct: {instruccion}\nQuery:{consulta}";

    public async Task<IReadOnlyList<FragmentoRecuperado>> BuscarAsync(string consulta, int k, CancellationToken cancellationToken)
    {
        var coleccion = _coleccion ?? throw new InvalidOperationException("El almacén no se inició (IniciarAsync).");
        var vector = await generador.GenerateVectorAsync(
            TextoDeLaConsulta(consulta, opciones.Value.Rag.InstruccionDeConsulta), cancellationToken: cancellationToken);
        if (vector.Length != Dimension)
            throw new InvalidOperationException($"La consulta dio un vector de {vector.Length}; el almacén es de {Dimension}.");

        var resultado = new List<FragmentoRecuperado>();
        await foreach (var r in coleccion.SearchAsync(vector, k, cancellationToken: cancellationToken))
            resultado.Add(new(r.Record.Fuente, r.Record.Tema, r.Record.Texto, r.Score ?? double.NaN));
        return resultado;
    }
}
