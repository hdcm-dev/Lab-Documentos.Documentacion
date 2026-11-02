using System.Reflection;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using CommunityToolkit.VectorData.InMemory;
using CommunityToolkit.VectorData.SqliteVec;
using OllamaSharp;

// 1) Reflexión: qué colecciones implementan IKeywordHybridSearchable<T>
var asmNames = new[]{"CommunityToolkit.VectorData.InMemory","CommunityToolkit.VectorData.SqliteVec","CommunityToolkit.VectorData.Qdrant","CommunityToolkit.VectorData.PgVector","CommunityToolkit.VectorData.Redis","CommunityToolkit.VectorData.SqlServer","CommunityToolkit.VectorData.AzureAISearch"};
foreach (var n in asmNames) {
  var a = Assembly.Load(n);
  foreach (var t in a.GetExportedTypes().Where(t => t.IsClass && t.GetInterfaces().Any(i=>i.IsGenericType && i.GetGenericTypeDefinition()==typeof(VectorStoreCollection<,>)) || (t.BaseType?.IsGenericType==true && t.BaseType.GetGenericTypeDefinition()==typeof(VectorStoreCollection<,>))))
    Console.WriteLine($"{n}: {t.Name} hybrid={t.GetInterfaces().Any(i=>i.IsGenericType && i.GetGenericTypeDefinition()==typeof(IKeywordHybridSearchable<>))}");
}
// 2) OllamaApiClient implementa IEmbeddingGenerator
Console.WriteLine("OllamaApiClient is IEmbeddingGenerator<string,Embedding<float>>: " + typeof(IEmbeddingGenerator<string,Embedding<float>>).IsAssignableFrom(typeof(OllamaApiClient)));
Console.WriteLine("OllamaApiClient is IChatClient: " + typeof(IChatClient).IsAssignableFrom(typeof(OllamaApiClient)));
// 3) DataIngestion tipos
var di = Assembly.Load("Microsoft.Extensions.DataIngestion");
Console.WriteLine("DataIngestion types: " + string.Join(", ", di.GetExportedTypes().Select(t=>t.Name).OrderBy(x=>x)));
var dia = Assembly.Load("Microsoft.Extensions.DataIngestion.Abstractions");
Console.WriteLine("DataIngestion.Abstractions types: " + string.Join(", ", dia.GetExportedTypes().Select(t=>t.Name).OrderBy(x=>x)));

// 4) Búsqueda real con un generador determinista (bolsa de palabras con hash) — sin servicio externo
var gen = new HashEmbeddingGenerator(64);
foreach (var (name, store) in new (string, VectorStore)[]{ ("InMemory", new InMemoryVectorStore(new() { EmbeddingGenerator = gen })), ("SqliteVec", new SqliteVectorStore("Data Source=/work/probe.db;Pooling=false", new() { EmbeddingGenerator = gen })) })
{
  var col = store.GetCollection<string, Fragmento>("fragmentos");
  await col.EnsureCollectionDeletedAsync();
  await col.EnsureCollectionExistsAsync();
  await col.UpsertAsync([
    new Fragmento{ Id="loc-1", Fuente="localidades.md#alta", Texto="Para dar de alta una localidad se carga nombre y provincia", Embedding="Para dar de alta una localidad se carga nombre y provincia"},
    new Fragmento{ Id="enc-1", Fuente="encuesta.md#paso2", Texto="El paso dos de la encuesta pide el medio de transporte habitual", Embedding="El paso dos de la encuesta pide el medio de transporte habitual"},
    new Fragmento{ Id="enc-2", Fuente="encuesta.md#paso3", Texto="El paso tres confirma la encuesta y muestra el resumen", Embedding="El paso tres confirma la encuesta y muestra el resumen"}]);
  await foreach (var r in col.SearchAsync("medio de transporte en la encuesta", top: 2))
    Console.WriteLine($"[{name}] {r.Record.Id} ({r.Record.Fuente}) score={r.Score:F4}");
}

public class Fragmento {
  [VectorStoreKey] public string Id { get; set; }
  [VectorStoreData] public string Fuente { get; set; }
  [VectorStoreData] public string Texto { get; set; }
  [VectorStoreVector(64, DistanceFunction = DistanceFunction.CosineDistance)] public string Embedding { get; set; }
}

sealed class HashEmbeddingGenerator(int dims) : IEmbeddingGenerator<string, Embedding<float>> {
  public Task<GeneratedEmbeddings<Embedding<float>>> GenerateAsync(IEnumerable<string> values, EmbeddingGenerationOptions? options = null, CancellationToken ct = default) {
    var list = values.Select(v => {
      var vec = new float[dims];
      foreach (var w in v.ToLowerInvariant().Split(' ', StringSplitOptions.RemoveEmptyEntries)) vec[(uint)w.GetHashCode() % dims] += 1; // GetHashCode es por proceso: sólo para la sonda
      var norm = MathF.Sqrt(vec.Sum(x => x*x)); for (int i=0;i<dims;i++) vec[i]/=norm;
      return new Embedding<float>(vec);
    }).ToList();
    return Task.FromResult(new GeneratedEmbeddings<Embedding<float>>(list));
  }
  public object? GetService(Type t, object? k = null) => null;
  public void Dispose() {}
}
