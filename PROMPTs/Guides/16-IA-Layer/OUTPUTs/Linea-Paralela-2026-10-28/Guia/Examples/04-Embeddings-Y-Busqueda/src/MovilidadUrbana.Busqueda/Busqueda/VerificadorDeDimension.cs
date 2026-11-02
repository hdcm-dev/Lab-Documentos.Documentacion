using Microsoft.Extensions.AI;

namespace MovilidadUrbana.Busqueda.Busqueda;

/// <summary>
/// Vectores de dimensiones distintas no son comparables y nada lo avisa: la similitud da un número igual.
/// Este decorador hace cumplir el invariante «largo de cada vector devuelto = dimensión declarada».
/// Si no hay dimensión declarada, adopta la del primer vector que ve.
/// </summary>
public sealed class VerificadorDeDimension(
    IEmbeddingGenerator<string, Embedding<float>> interno, string modelo, int? dimensionDeclarada)
    : DelegatingEmbeddingGenerator<string, Embedding<float>>(interno)
{
    private int? _dimension = dimensionDeclarada;

    public int? Dimension => _dimension;

    public override async Task<GeneratedEmbeddings<Embedding<float>>> GenerateAsync(
        IEnumerable<string> values, EmbeddingGenerationOptions? options = null, CancellationToken cancellationToken = default)
    {
        var generados = await base.GenerateAsync(values, options, cancellationToken);
        foreach (var e in generados)
        {
            _dimension ??= e.Vector.Length;
            if (e.Vector.Length != _dimension)
                throw new DimensionDeEmbeddingsException(modelo, _dimension.Value, e.Vector.Length);
        }
        return generados;
    }
}

public sealed class DimensionDeEmbeddingsException(string modelo, int declarada, int medida)
    : InvalidOperationException(
        $"El modelo de embeddings «{modelo}» devolvió vectores de {medida} dimensiones y el almacén declara {declarada}. " +
        "Vectores de dimensiones distintas no se pueden comparar: corregí AI:DimensionDeEmbeddings o el modelo.")
{
    public string Modelo { get; } = modelo;
    public int Declarada { get; } = declarada;
    public int Medida { get; } = medida;
}
