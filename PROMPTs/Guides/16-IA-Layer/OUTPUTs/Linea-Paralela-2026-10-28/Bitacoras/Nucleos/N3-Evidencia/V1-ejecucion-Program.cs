using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.VectorData.InMemory;
using CommunityToolkit.VectorData.SqliteVec;
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
