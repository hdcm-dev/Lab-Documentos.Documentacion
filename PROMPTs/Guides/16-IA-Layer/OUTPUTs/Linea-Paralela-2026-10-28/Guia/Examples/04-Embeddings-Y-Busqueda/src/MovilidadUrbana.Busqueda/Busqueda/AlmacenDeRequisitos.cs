using CommunityToolkit.VectorData.InMemory;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.VectorData;
using MovilidadUrbana.Busqueda.Configuracion;
using MovilidadUrbana.Busqueda.Requisitos;

namespace MovilidadUrbana.Busqueda.Busqueda;

/// <summary>Registro del almacén. La dimensión no va en un atributo: la define la colección en tiempo de ejecución.</summary>
public sealed class FragmentoDeRequisito
{
    public required string Id { get; set; }
    public required string Entidad { get; set; }
    public required string Texto { get; set; }      // el enunciado original: del vector no se recupera
    public required string Embedding { get; set; }  // con generador en el store, MEVD lo vectoriza al guardar y al buscar
}

public sealed record ResultadoDeBusqueda(string Fuente, string Enunciado, double Similitud);

/// <summary>Almacén vectorial en memoria con los doce requisitos. Persistence, detrás de una interfaz si crece.</summary>
public sealed class AlmacenDeRequisitos(
    IEmbeddingGenerator<string, Embedding<float>> generador,
    IOptions<OpcionesDeIA> opciones,
    CatalogoDeRequisitos catalogo)
{
    public const string NombreDeLaColeccion = "requisitos";
    public const string TextoDePrueba = "Prueba de dimensión al arrancar.";

    private VectorStoreCollection<string, FragmentoDeRequisito>? _coleccion;

    public int Dimension { get; private set; }

    /// <summary>
    /// Mide un embedding de prueba y valida la dimensión ANTES de crear la colección: si no coincide con la
    /// declarada, <see cref="DimensionDeEmbeddingsException"/> y la aplicación no arranca.
    /// </summary>
    public async Task InicializarAsync(CancellationToken ct = default)
    {
        var ia = opciones.Value;
        var prueba = await generador.GenerateVectorAsync(TextoDePrueba, cancellationToken: ct);
        var declarada = ia.DimensionDeEmbeddings ?? prueba.Length;
        if (prueba.Length != declarada)
            throw new DimensionDeEmbeddingsException(ia.ModeloDeEmbeddings, declarada, prueba.Length);
        Dimension = declarada;

        var definicion = new VectorStoreCollectionDefinition
        {
            Properties =
            [
                new VectorStoreKeyProperty(nameof(FragmentoDeRequisito.Id), typeof(string)),
                new VectorStoreDataProperty(nameof(FragmentoDeRequisito.Entidad), typeof(string)) { IsIndexed = true },
                new VectorStoreDataProperty(nameof(FragmentoDeRequisito.Texto), typeof(string)),
                new VectorStoreVectorProperty(nameof(FragmentoDeRequisito.Embedding), typeof(string), Dimension)
                {
                    DistanceFunction = DistanceFunction.CosineSimilarity, // mayor = más parecido
                },
            ],
        };

        var store = new InMemoryVectorStore(new() { EmbeddingGenerator = generador });
        _coleccion = store.GetCollection<string, FragmentoDeRequisito>(NombreDeLaColeccion, definicion);
        await _coleccion.EnsureCollectionExistsAsync(ct);
        await _coleccion.UpsertAsync(catalogo.Requisitos.Select(r => new FragmentoDeRequisito
        {
            Id = r.Fuente,
            Entidad = r.Entidad,
            Texto = r.Enunciado,
            Embedding = r.TextoAIndexar,
        }), ct);
    }

    /// <summary>Los <paramref name="top"/> enunciados más parecidos a la consulta, ya formateada.</summary>
    public async Task<IReadOnlyList<ResultadoDeBusqueda>> BuscarAsync(string consulta, int top, CancellationToken ct = default)
    {
        var coleccion = _coleccion ?? throw new InvalidOperationException("El almacén no se inicializó.");
        var resultados = new List<ResultadoDeBusqueda>();
        await foreach (var r in coleccion.SearchAsync(consulta, top, cancellationToken: ct))
            resultados.Add(new ResultadoDeBusqueda(r.Record.Id, r.Record.Texto, r.Score ?? double.NaN));
        return resultados;
    }
}

/// <summary>Instrucción sólo en la consulta, con el formato que publica la model card del modelo de embeddings por defecto.</summary>
public static class FormatoDeConsulta
{
    public static string Aplicar(string? instruccion, string consulta) =>
        string.IsNullOrWhiteSpace(instruccion) ? consulta : $"Instruct: {instruccion}\nQuery:{consulta}";
}

/// <summary>Valida la dimensión e ingiere al arrancar: si falla, <c>StartAsync</c> lanza y no hay primer pedido.</summary>
public sealed class ArranqueDelAlmacen(AlmacenDeRequisitos almacen) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken) => almacen.InicializarAsync(cancellationToken);
    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
