// Lo que haría un lector ingenuo con la reparación de N6 §4.3 («dimensión tomada de configuración»):
// pasar la dimensión leída de configuración al atributo.
using Microsoft.Extensions.VectorData;
var dim = int.Parse(Environment.GetEnvironmentVariable("AI__DimensionDeEmbeddings") ?? "1024");
Console.WriteLine(dim);
public static class Config { public static readonly int Dimension = int.Parse(Environment.GetEnvironmentVariable("AI__DimensionDeEmbeddings") ?? "1024"); }
public sealed class Fragmento
{
    [VectorStoreKey] public string Id { get; set; } = "";
    [VectorStoreVector(Config.Dimension)] public string Embedding { get; set; } = "";
}
