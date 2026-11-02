using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MovilidadUrbana.Busqueda.Configuracion;

namespace MovilidadUrbana.Busqueda.Tests.Cableado;

/// <summary>Generador falso fijo: cada texto conocido tiene su vector; el resto, un vector de relleno. Cuenta llamadas.</summary>
public sealed class GeneradorFijo(int dimension, Func<string, float[]?>? vectores = null) : IEmbeddingGenerator<string, Embedding<float>>
{
    public int Llamadas { get; private set; }
    public List<string> TextosPedidos { get; } = [];

    /// <summary>Vector unitario en el eje <paramref name="i"/>.</summary>
    public static float[] Eje(int dimension, int i) { var v = new float[dimension]; v[i] = 1f; return v; }

    /// <summary>Combinación de ejes, normalizada L2.</summary>
    public static float[] Mezcla(int dimension, params (int Eje, float Peso)[] partes)
    {
        var v = new float[dimension];
        foreach (var (eje, peso) in partes) v[eje] += peso;
        var n = MathF.Sqrt(v.Sum(x => x * x));
        return v.Select(x => x / n).ToArray();
    }

    public Task<GeneratedEmbeddings<Embedding<float>>> GenerateAsync(
        IEnumerable<string> values, EmbeddingGenerationOptions? options = null, CancellationToken cancellationToken = default)
    {
        var lista = values.ToList();
        Llamadas++;
        TextosPedidos.AddRange(lista);
        return Task.FromResult(new GeneratedEmbeddings<Embedding<float>>(
            lista.Select(t => new Embedding<float>(vectores?.Invoke(t) ?? Eje(dimension, dimension - 1)))));
    }

    public object? GetService(Type serviceType, object? serviceKey = null) => null;
    public void Dispose() { }
}

public static class AnfitrionDePrueba
{
    /// <summary>Anfitrión con la composición real, configuración en memoria y el generador doble.</summary>
    public static IHost Crear(IEmbeddingGenerator<string, Embedding<float>> generador, Dictionary<string, string?>? cambios = null)
    {
        var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings { DisableDefaults = true });
        var config = new Dictionary<string, string?>
        {
            ["AI:Modo"] = Modos.Ollama,
            ["AI:TimeoutSegundos"] = "5",
            ["AI:DimensionDeEmbeddings"] = "1024",
        };
        foreach (var (k, v) in cambios ?? []) config[k] = v;
        builder.Configuration.AddInMemoryCollection(config);
        builder.AgregarBusquedaDeRequisitos(_ => null, _ => generador);
        return builder.Build();
    }
}
