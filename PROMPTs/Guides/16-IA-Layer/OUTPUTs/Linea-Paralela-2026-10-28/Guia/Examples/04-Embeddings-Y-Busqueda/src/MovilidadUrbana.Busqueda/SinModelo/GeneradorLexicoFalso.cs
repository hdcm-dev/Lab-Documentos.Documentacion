using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.AI;

namespace MovilidadUrbana.Busqueda.SinModelo;

/// <summary>
/// Modo sin modelo: un «embedding» léxico y determinista (bolsa de palabras con hash, normalizada L2).
/// Sirve para correr el circuito completo sin servidor. No entiende significado: sólo cuenta palabras
/// compartidas, y por eso es la línea de base contra la que se lee lo que aporta un modelo.
/// </summary>
public sealed class GeneradorLexicoFalso(int dimension) : IEmbeddingGenerator<string, Embedding<float>>
{
    public const string Nombre = "generador-lexico-falso";

    public Task<GeneratedEmbeddings<Embedding<float>>> GenerateAsync(
        IEnumerable<string> values, EmbeddingGenerationOptions? options = null, CancellationToken cancellationToken = default) =>
        Task.FromResult(new GeneratedEmbeddings<Embedding<float>>(values.Select(v => new Embedding<float>(Vectorizar(v)))));

    private float[] Vectorizar(string texto)
    {
        var v = new float[dimension];
        foreach (var palabra in Palabras(texto))
            v[(int)(Fnv1a(palabra) % (uint)dimension)] += 1f;
        var norma = MathF.Sqrt(v.Sum(x => x * x));
        if (norma > 0) for (var i = 0; i < v.Length; i++) v[i] /= norma;
        return v;
    }

    private static IEnumerable<string> Palabras(string texto)
    {
        var sinTildes = new StringBuilder();
        foreach (var c in texto.ToLowerInvariant().Normalize(NormalizationForm.FormD))
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark) sinTildes.Append(c);
        return Regex.Split(sinTildes.ToString(), @"[^\p{L}\p{Nd}]+")
            .Where(p => p.Length > 2); // descarta «de», «la», «el»…
    }

    private static uint Fnv1a(string s)
    {
        var h = 2166136261u;
        foreach (var b in Encoding.UTF8.GetBytes(s)) { h ^= b; h *= 16777619u; }
        return h;
    }

    public object? GetService(Type serviceType, object? serviceKey = null) =>
        serviceType == typeof(EmbeddingGeneratorMetadata) ? new EmbeddingGeneratorMetadata(Nombre, null, Nombre, dimension) : null;

    public void Dispose() { }
}
