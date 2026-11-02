using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.VectorData.InMemory;
using CommunityToolkit.VectorData.SqliteVec;
await Extra.Go();
var gen = new HashGen(1024);
var sc = new ServiceCollection(); sc.AddSqliteVectorStore(_ => "Data Source=/tmp/di.db"); Console.WriteLine("DI AddSqliteVectorStore(_ => cs) ok: " + (sc.BuildServiceProvider().GetService<VectorStore>()?.GetType().Name));
foreach (var (name, store) in new (string, VectorStore)[]{ ("InMemory", new InMemoryVectorStore(new() { EmbeddingGenerator = gen })), ("SqliteVec", new SqliteVectorStore("Data Source=/tmp/a.db;Pooling=false", new() { EmbeddingGenerator = gen })) })
{
  var col = store.GetCollection<string, FragmentoDeAyuda>("ayuda");
  await col.EnsureCollectionDeletedAsync(); await col.EnsureCollectionExistsAsync();
  await col.UpsertAsync([
    new FragmentoDeAyuda { Id = "loc-cp", Fuente = "LocalidadPolicy.RequisitoDelCodigoPostal", Texto = "El código postal tiene 4 dígitos.", Embedding = "Código postal: 4 dígitos." },
    new FragmentoDeAyuda { Id = "enc-edad", Fuente = "EncuestaPolicy.RequisitoDeLaEdad", Texto = "Entre 16 y 110 años.", Embedding = "Edad de quien responde: entre 16 y 110 años." },
    new FragmentoDeAyuda { Id = "int", Fuente = "interno", Texto = "código postal interno", Embedding = "código postal interno" }]);
  foreach (var (lbl, filt) in new (string, System.Linq.Expressions.Expression<Func<FragmentoDeAyuda,bool>>)[]{ ("!=", f => f.Fuente != "interno"), ("==", f => f.Fuente == "LocalidadPolicy.RequisitoDelCodigoPostal") })
  try {
    var ids = new List<string>();
    await foreach (var r in col.SearchAsync("¿Cuántos números lleva el CP? código postal", top: 3, new() { Filter = filt })) ids.Add($"{r.Record.Id}:{r.Score:F3}");
    Console.WriteLine($"[{name}] filtro {lbl}: {string.Join(",", ids)}");
  } catch (Exception e) { Console.WriteLine($"[{name}] filtro {lbl}: {e.GetType().Name}: {e.Message.Split('\n')[0]}"); }
  var got = await col.GetAsync("loc-cp", new() { IncludeVectors = false });
  Console.WriteLine($"[{name}] GetAsync Texto='{got?.Texto}' Embedding='{got?.Embedding}'");
  Console.WriteLine($"[{name}] hybrid: {col is IKeywordHybridSearchable<FragmentoDeAyuda>}");
}
public sealed class FragmentoDeAyuda {
    [VectorStoreKey] public required string Id { get; set; }
    [VectorStoreData(IsIndexed = true)] public required string Fuente { get; set; }
    [VectorStoreData] public required string Texto { get; set; }
    [VectorStoreVector(1024, DistanceFunction = DistanceFunction.CosineDistance)] public required string Embedding { get; set; }
}
sealed class HashGen(int dims) : IEmbeddingGenerator<string, Embedding<float>> {
  public Task<GeneratedEmbeddings<Embedding<float>>> GenerateAsync(IEnumerable<string> values, EmbeddingGenerationOptions? options = null, CancellationToken ct = default) =>
    Task.FromResult(new GeneratedEmbeddings<Embedding<float>>(values.Select(v => { var vec = new float[dims];
      foreach (var w in v.ToLowerInvariant().Split(' ', StringSplitOptions.RemoveEmptyEntries)) vec[(uint)w.GetHashCode() % dims] += 1;
      var n = MathF.Sqrt(vec.Sum(x => x*x)); for (int i=0;i<dims;i++) vec[i]/=n; return new Embedding<float>(vec); }).ToList()));
  public object? GetService(Type t, object? k = null) => null; public void Dispose() {}
}
public static class Extra {
  public static async Task Go() {
    var gen = new HashGen(1024);
    // CosineSimilarity en SqliteVec
    try { var c = new SqliteVectorStore("Data Source=/tmp/b.db;Pooling=false", new() { EmbeddingGenerator = gen }).GetCollection<string, FSim>("s"); await c.EnsureCollectionExistsAsync(); Console.WriteLine("Sqlite CosineSimilarity: no lanza"); }
    catch (Exception e) { Console.WriteLine("Sqlite CosineSimilarity: " + e.GetType().Name + ": " + e.Message.Split('\n')[0]); }
    var m = new InMemoryVectorStore(new() { EmbeddingGenerator = gen }).GetCollection<string, FSim>("s"); await m.EnsureCollectionExistsAsync();
    await m.UpsertAsync([ new FSim{Id="a",E="código postal"}, new FSim{Id="b",E="edad años"} ]);
    await foreach (var r in m.SearchAsync("código postal", top: 2)) Console.WriteLine($"InMemory CosineSimilarity {r.Record.Id} {r.Score:F3}");
    foreach (var t in new[]{ typeof(Microsoft.Extensions.DataIngestion.HeaderChunker) }.Concat(typeof(Microsoft.Extensions.DataIngestion.HeaderChunker).Assembly.GetExportedTypes().Where(x=>x.Name.Contains("Chunker")||x.Name.Contains("Enricher")||x.Name.Contains("Writer")||x.Name.Contains("Reader"))).Distinct())
      Console.WriteLine($"{t.FullName} : {t.BaseType?.Name}");
    var mdA = typeof(Microsoft.Extensions.DataIngestion.MarkdownReader).FullName; Console.WriteLine("Markdig reader: " + mdA);
    var oc = new OllamaSharp.OllamaApiClient(new Uri("http://localhost:11434"), "x");
    var f = typeof(OllamaSharp.OllamaApiClient).GetFields(System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Instance).FirstOrDefault(x=>x.FieldType==typeof(HttpClient));
    Console.WriteLine("Ollama HttpClient timeout: " + ((HttpClient?)f?.GetValue(oc))?.Timeout);
    Console.WriteLine("VectorStoreWriter ctor: " + string.Join(" | ", typeof(Microsoft.Extensions.DataIngestion.VectorStoreWriter<string>).GetConstructors().Select(c=>string.Join(",", c.GetParameters().Select(p=>p.ParameterType.Name+" "+p.Name)))));
    Console.WriteLine("IngestionPipeline ctor: " + string.Join(" | ", typeof(Microsoft.Extensions.DataIngestion.IngestionPipeline<string>).GetConstructors().Select(c=>string.Join(",", c.GetParameters().Select(p=>p.ParameterType.Name+" "+p.Name)))));
    Console.WriteLine("ProcessAsync: " + string.Join(" | ", typeof(Microsoft.Extensions.DataIngestion.IngestionPipeline<string>).GetMethods().Where(x=>x.Name=="ProcessAsync").Select(c=>c.ReturnType.Name+"("+string.Join(",", c.GetParameters().Select(p=>p.ParameterType.Name+" "+p.Name))+")")));
  }
}
public sealed class FSim { [VectorStoreKey] public required string Id { get; set; } [VectorStoreVector(1024, DistanceFunction = DistanceFunction.CosineSimilarity)] public required string E { get; set; } }
