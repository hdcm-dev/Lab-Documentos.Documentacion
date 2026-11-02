// 4.1
using Microsoft.Extensions.VectorData;
using Microsoft.Extensions.AI;
using CommunityToolkit.VectorData.InMemory;
using CommunityToolkit.VectorData.SqliteVec;
using OllamaSharp;
using Microsoft.Extensions.DataIngestion;
using Microsoft.ML.Tokenizers;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlTypes;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Logging;

public sealed class FragmentoDeAyuda
{
    [VectorStoreKey]
    public required string Id { get; set; }
    [VectorStoreData(IsIndexed = true)]
    public required string Fuente { get; set; }
    [VectorStoreData]
    public required string Texto { get; set; }
    [VectorStoreVector(1024, DistanceFunction = DistanceFunction.CosineSimilarity)]
    public required string Embedding { get; set; }
}
public static class S42 {
  public static async Task Run() {
    var endpoint = new Uri(Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT") ?? "http://localhost:11434");
    var modeloEmbeddings = Environment.GetEnvironmentVariable("OLLAMA_EMBEDDING_MODEL") ?? "qwen3-embedding:0.6b";
    IEmbeddingGenerator<string, Embedding<float>> embeddings = new OllamaApiClient(endpoint, modeloEmbeddings);
    VectorStore store = new InMemoryVectorStore(new() { EmbeddingGenerator = embeddings });
    VectorStoreCollection<string, FragmentoDeAyuda> fragmentos = store.GetCollection<string, FragmentoDeAyuda>("ayuda");
    await fragmentos.EnsureCollectionExistsAsync();
    VectorStore store2 = new SqliteVectorStore("Data Source=ayuda.db;Pooling=false", new() { EmbeddingGenerator = embeddings });
    // 4.3
    await fragmentos.UpsertAsync(
    [
        new FragmentoDeAyuda { Id = "loc-cp", Fuente = "LocalidadPolicy.RequisitoDelCodigoPostal",
            Texto = "El código postal tiene 4 dígitos.", Embedding = "Código postal: 4 dígitos." },
    ]);
    // 4.4
    var pregunta = "¿Cuántos números lleva el CP?";
    var contexto = new List<string>();
    await foreach (VectorSearchResult<FragmentoDeAyuda> r in fragmentos.SearchAsync(pregunta, top: 3,
                       new() { Filter = f => f.Fuente != "interno" }))
        contexto.Add($"[{r.Record.Fuente}] {r.Record.Texto}");
    IChatClient chat = new OllamaApiClient(endpoint, "x");
    ChatResponse respuesta = await chat.GetResponseAsync(
    [
        new(ChatRole.System, "a"),
        new(ChatRole.User, "FUENTES:\n" + string.Join("\n", contexto)),
    ], new ChatOptions { Temperature = 0 });
    // 4.5
    if (fragmentos is IKeywordHybridSearchable<FragmentoDeAyuda> hibrida)
    {
        await foreach (var r in hibrida.HybridSearchAsync(pregunta, ["código", "postal"], top: 3))
            Console.WriteLine($"{r.Record.Id} {r.Score}");
    }
    // 4.8
    IEmbeddingGenerator<string, Embedding<float>> generator =
        new EmbeddingGeneratorBuilder<string, Embedding<float>>(new OllamaApiClient(endpoint, modeloEmbeddings))
            .UseDistributedCache(new MemoryDistributedCache(Options.Create(new MemoryDistributedCacheOptions())))
            .Build();
  }
  // 4.6
  public static async Task Ingesta(IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator, IngestionDocumentReader reader, ILoggerFactory loggerFactory) {
    Tokenizer tokenizer = TiktokenTokenizer.CreateForModel("gpt-5");
    IngestionChunkerOptions options = new(tokenizer) { MaxTokensPerChunk = 2000, OverlapTokens = 0 };
    IngestionChunker<string> chunker = new HeaderChunker(options);
    using SqliteVectorStore vectorStore = new("Data Source=vectors.db;Pooling=false",
        new() { EmbeddingGenerator = embeddingGenerator });
    using VectorStoreWriter<string> writer = new(vectorStore, dimensionCount: 1024);
    using IngestionPipeline<string> pipeline = new(reader, chunker, writer, loggerFactory: loggerFactory);
    await foreach (var result in pipeline.ProcessAsync(new DirectoryInfo("."), searchPattern: "*.md"))
        Console.WriteLine($"'{result.DocumentId}' ok={result.Succeeded}");
  }
}
// 4.7
public class Articulo { public int Id { get; set; }
    [Column(TypeName = "vector(1024)")] public SqlVector<float> Embedding { get; set; } }
public class Ctx : DbContext { public DbSet<Articulo> Articulos => Set<Articulo>(); }
public static class S47 {
  public static async Task Run(Ctx context, IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator) {
    var q = new SqlVector<float>(await embeddingGenerator.GenerateVectorAsync("consulta"));
    var top = await context.Articulos
        .OrderBy(a => EF.Functions.VectorDistance("cosine", a.Embedding, q))
        .Take(3).ToListAsync();
  }
}
