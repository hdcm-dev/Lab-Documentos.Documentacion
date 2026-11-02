using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;

namespace MovilidadUrbana.Busqueda.Tests.Cableado;

[TestFixture, Category("Cableado")]
public sealed class CacheTests
{
    [Test]
    public async Task LaSegundaGeneracionDelMismoTexto_NoLlamaAlGenerador()
    {
        var generador = new GeneradorFijo(1024);
        using var host = AnfitrionDePrueba.Crear(generador);
        var compuesto = host.Services.GetRequiredService<IEmbeddingGenerator<string, Embedding<float>>>();

        await compuesto.GenerateVectorAsync("¿Cuántos números lleva el CP?");
        var despuesDeLaPrimera = generador.Llamadas;
        await compuesto.GenerateVectorAsync("¿Cuántos números lleva el CP?");
        await compuesto.GenerateVectorAsync("¿Desde qué edad se puede contestar la encuesta?");

        Assert.Multiple(() =>
        {
            Assert.That(despuesDeLaPrimera, Is.EqualTo(1));
            Assert.That(generador.Llamadas, Is.EqualTo(2), "la repetida sale de la caché; la nueva llama");
        });
    }
}
