using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.AI;

namespace MovilidadUrbana.RagEnMemoria.SinModelo;

/// <summary>
/// Modo sin modelo (<c>--sin-modelo</c>): un generador de embeddings por bolsa de palabras, determinista y
/// sin red. No busca por significado (sólo por palabras compartidas); sirve para ver qué fragmentos
/// llegarían al prompt y cómo se arma el pedido, no para medir la recuperación.
/// </summary>
public sealed class GeneradorPorPalabras(int dimension) : IEmbeddingGenerator<string, Embedding<float>>
{
    public Task<GeneratedEmbeddings<Embedding<float>>> GenerateAsync(
        IEnumerable<string> values, EmbeddingGenerationOptions? options = null, CancellationToken cancellationToken = default)
    {
        var lista = values.Select(v => new Embedding<float>(Vectorizar(v))).ToList();
        return Task.FromResult(new GeneratedEmbeddings<Embedding<float>>(lista));
    }

    private float[] Vectorizar(string texto)
    {
        var v = new float[dimension];
        var sinInstruccion = texto.Contains("\nQuery:", StringComparison.Ordinal) ? texto[(texto.IndexOf("\nQuery:", StringComparison.Ordinal) + 7)..] : texto;
        foreach (var palabra in Palabras(sinInstruccion))
            v[BitConverter.ToUInt32(SHA256.HashData(Encoding.UTF8.GetBytes(palabra)), 0) % (uint)dimension] += 1;
        var norma = MathF.Sqrt(v.Sum(x => x * x));
        if (norma > 0) for (var i = 0; i < v.Length; i++) v[i] /= norma;
        else v[0] = 1;
        return v;
    }

    private static IEnumerable<string> Palabras(string texto) =>
        new string(texto.ToLowerInvariant().Normalize(NormalizationForm.FormD)
                .Where(c => System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)
                .Select(c => char.IsLetterOrDigit(c) ? c : ' ').ToArray())
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Where(p => p.Length > 3);   // descarta artículos y preposiciones cortas

    public object? GetService(Type serviceType, object? serviceKey = null) => null;

    public void Dispose() { }
}

/// <summary>Cliente de chat sin modelo: devuelve el pedido que habría recibido el modelo.</summary>
public sealed class ClienteQueMuestraElPedido : IChatClient
{
    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
    {
        var texto = string.Join("\n", messages.Select(m => $"--- {m.Role} ---\n{m.Text}"));
        return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, "(sin modelo) El pedido habría sido:\n" + texto)));
    }

    public IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default) =>
        throw new NotSupportedException();

    public object? GetService(Type serviceType, object? serviceKey = null) => null;

    public void Dispose() { }
}
