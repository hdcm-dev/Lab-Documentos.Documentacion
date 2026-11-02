using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovilidadUrbana.PruebaDeArquitectura.Application.Propuestas;
using MovilidadUrbana.PruebaDeArquitectura.Infrastructure.AI;
using MovilidadUrbana.PruebaDeArquitectura.Presentation.Herramientas;

namespace MovilidadUrbana.PruebaDeArquitectura.Tests.Cableado;

/// <summary>
/// La regla mira tipos; esta prueba mira que la raíz de composición los une: el puerto se resuelve con el
/// adaptador y la herramienta llega al caso de uso. Sin modelo: crear el cliente no abre ninguna conexión.
/// </summary>
[TestFixture]
public sealed class ComposicionTests
{
    [Test]
    public void El_puerto_se_resuelve_con_el_adaptador_y_la_herramienta_con_el_caso_de_uso()
    {
        var configuracion = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["AI:Endpoint"] = "http://ollama.invalid",   // nombre reservado: nunca resuelve
            ["AI:Modelo"] = "modelo-de-prueba",
            ["AI:NumCtx"] = "8192",
            ["ConnectionStrings:BaseDeDatos"] = "Data Source=:memory:"
        }).Build();

        var services = new ServiceCollection().AddLogging();
        services.AgregarServicios(configuracion);
        using var proveedor = services.BuildServiceProvider(new ServiceProviderOptions { ValidateScopes = true, ValidateOnBuild = true });
        using var ambito = proveedor.CreateScope();

        Assert.That(ambito.ServiceProvider.GetRequiredService<IExtractorDeLocalidad>(), Is.TypeOf<ExtractorDeLocalidadLlm>());
        Assert.That(ambito.ServiceProvider.GetRequiredService<ProponerLocalidadDesdeTexto>(), Is.Not.Null);
        Assert.That(ambito.ServiceProvider.GetRequiredService<IChatClient>(), Is.Not.Null);

        var catalogo = ambito.ServiceProvider.GetRequiredService<HerramientasDeLectura>().Catalogo();
        Assert.That(catalogo.Select(f => f.Name), Is.EqualTo(new[] { "contar_localidades" }));
    }
}
