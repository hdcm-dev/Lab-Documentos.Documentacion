using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using MovilidadUrbana.Ejemplos.Mcp.Cliente.Mcp;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Alternativa;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Herramientas;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Mcp;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.Mcp.Tests.Cableado;

/// <summary>
/// La alternativa con dos definiciones ([McpServerToolType]) compila y publica lo mismo que el catálogo único:
/// mismos nombres (fijados a mano en los dos lados), misma descripción y mismo esquema. Los parámetros que
/// llegan por DI (ConsultaDeLocalidades) y el CancellationToken no aparecen en el esquema.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class AlternativaTests
{
    [Test]
    public async Task LaAlternativaConAtributos_PublicaLoMismoQueElCatalogo()
    {
        await using var servidor = await ServidorMcp.IniciarEnLoopbackAsync("Development", herramientas: b => b.WithTools<HerramientasConAtributos>());
        await using var mcp = await ConexionMcp.ConectarAsync(servidor.Endpoint, Comun.TokenDeDemostracion);
        var publicadas = await mcp.ListToolsAsync();
        var catalogo = CatalogoDeHerramientas.DeLectura().ToDictionary(f => f.Name);

        Assert.That(publicadas.Select(t => t.Name), Is.EquivalentTo(catalogo.Keys));
        foreach (var t in publicadas)
        {
            var alternativa = JsonSerializer.Serialize(t.ProtocolTool.InputSchema);
            var unico = JsonSerializer.Serialize(catalogo[t.Name].JsonSchema);
            TestContext.Out.WriteLine($"{t.Name}: esquema igual al del catálogo = {alternativa == unico}\n  alternativa {alternativa}\n  catálogo    {unico}");
            Assert.That(t.Description, Is.EqualTo(catalogo[t.Name].Description));
            Assert.That(alternativa, Is.EqualTo(unico));
        }
    }
}
