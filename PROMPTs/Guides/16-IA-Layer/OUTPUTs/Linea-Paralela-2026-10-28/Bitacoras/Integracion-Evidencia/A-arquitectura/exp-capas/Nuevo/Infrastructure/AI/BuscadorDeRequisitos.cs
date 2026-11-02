using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using CommunityToolkit.VectorData.InMemory;

namespace MovilidadUrbana.Asistente.Infrastructure.AI;

/// <summary>Recuperación (Retrieval · Embeddings · Vector DB de la imagen). Vive en Infrastructure/AI.</summary>
public sealed class BuscadorDeRequisitos(IEmbeddingGenerator<string, Embedding<float>> embeddings)
{
    VectorStoreCollection<string, Fragmento>? coleccion;

    public async Task IndexarAsync(IEnumerable<Requisito> corpus, CancellationToken ct = default)
    {
        var lista = corpus.ToList();
        var vectores = await embeddings.GenerateAsync(lista.Select(r => r.Texto), cancellationToken: ct);
        Dimension = vectores[0].Vector.Length;
        var def = new VectorStoreCollectionDefinition { Properties = [
            new VectorStoreKeyProperty("Id", typeof(string)),
            new VectorStoreDataProperty("Texto", typeof(string)),
            new VectorStoreVectorProperty("Vector", typeof(ReadOnlyMemory<float>), dimensions: Dimension) { DistanceFunction = DistanceFunction.CosineSimilarity } ] };
        coleccion = new InMemoryVectorStore().GetCollection<string, Fragmento>("requisitos", def);
        await coleccion.EnsureCollectionExistsAsync(ct);
        await coleccion.UpsertAsync(lista.Select((r, i) => new Fragmento { Id = r.Id, Texto = r.Texto, Vector = vectores[i].Vector }), ct);
    }

    public int Dimension { get; private set; }

    public async Task<IReadOnlyList<Requisito>> BuscarAsync(string pregunta, int top = 3, CancellationToken ct = default)
    {
        var qv = await embeddings.GenerateVectorAsync(pregunta, cancellationToken: ct);
        var res = new List<Requisito>();
        await foreach (var r in coleccion!.SearchAsync(qv, top, cancellationToken: ct)) res.Add(new(r.Record.Id, r.Record.Texto));
        return res;
    }

    public sealed class Fragmento { public string Id { get; set; } = ""; public string Texto { get; set; } = ""; public ReadOnlyMemory<float> Vector { get; set; } }
}
