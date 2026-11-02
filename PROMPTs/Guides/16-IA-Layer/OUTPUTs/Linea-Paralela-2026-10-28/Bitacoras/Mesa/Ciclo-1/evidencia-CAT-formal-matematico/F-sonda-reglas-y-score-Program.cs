using MovilidadUrbana.ApiWeb.Domain.Rules;
using Microsoft.Extensions.VectorData;
using CommunityToolkit.VectorData.InMemory;

Console.WriteLine("# Sonda CAT-formal — " + DateTimeOffset.Now.ToString("u") + " — .NET " + Environment.Version);
Console.WriteLine("[F1] LocalidadRules.CodigoPostalValido (copia literal de ApiWeb @59399ba)");
var casos = new (string etiqueta, string? cp)[] {
  ("ASCII 3400", "3400"), ("ASCII 34", "34"), ("ASCII 34000", "34000"),
  ("árabe-índico ٣٤٠٠ (U+0663..)", "٣٤٠٠"),
  ("ancho completo ３４００ (U+FF13..)", "３４００"),
  ("devanagari ३४०० (U+0969..)", "३४००"),
  ("con espacios ' 3400 '", " 3400 "), ("con salto final '3400\\n'", "3400\n"),
  ("0000", "0000"), ("null", null) };
foreach (var (e, cp) in casos) Console.WriteLine($"    {e,-36} → {LocalidadRules.CodigoPostalValido(cp)}");
Console.WriteLine("[F2] LocalidadRules.HabitantesValidos");
foreach (int? h in new int?[] { 0, 1, int.MaxValue, null, -5 }) Console.WriteLine($"    {h?.ToString() ?? "null",-12} → {LocalidadRules.HabitantesValidos(h)}");
Console.WriteLine("[F3] NombreValido con 61 y 200 caracteres (LargoMaximoDelNombre = 60)");
Console.WriteLine($"    61 → {LocalidadRules.NombreValido(new string('a', 61))}; 200 → {LocalidadRules.NombreValido(new string('a', 200))}");

Console.WriteLine("[F4] Score de InMemory 1.0.1: CosineSimilarity frente a CosineDistance con vectores fijos");
float[][] docs = { new float[] {1,0,0}, new float[] {0.8f,0.6f,0}, new float[] {0,1,0}, new float[] {-1,0,0} };
var q = new ReadOnlyMemory<float>(new float[] {1,0,0});
foreach (var fn in new[] { DistanceFunction.CosineSimilarity, DistanceFunction.CosineDistance })
{
  var def = new VectorStoreCollectionDefinition { Properties = new List<VectorStoreProperty> {
    new VectorStoreKeyProperty("Id", typeof(string)),
    new VectorStoreVectorProperty("V", typeof(ReadOnlyMemory<float>), 3) { DistanceFunction = fn } } };
  var col = new InMemoryVectorStore().GetDynamicCollection("c" + fn, def);
  await col.EnsureCollectionExistsAsync();
  for (int i = 0; i < docs.Length; i++) await col.UpsertAsync(new Dictionary<string, object?> { ["Id"] = "d" + i, ["V"] = new ReadOnlyMemory<float>(docs[i]) });
  var ids = new List<string>();
  await foreach (var r in col.SearchAsync(q, top: 4)) ids.Add($"{r.Record["Id"]}:{r.Score:F3}");
  Console.WriteLine($"    {fn,-16} orden devuelto: {string.Join(", ", ids)}");
}
Console.WriteLine("    (d0 idéntico, d1 cos=0.8, d2 ortogonal, d3 opuesto)");
