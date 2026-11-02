using System.Text.Json;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol;
using MovilidadUrbana.ApiWeb.Domain.Entities;
using MovilidadUrbana.Ejemplos.Mcp.Cliente.Mcp;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Herramientas;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Mcp;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.Mcp.Tests.Cableado;

/// <summary>
/// Lo que ve un cliente MCP real, por HTTP: tools/list igual al catálogo filtrado (nombre, descripción y
/// esquema), cada herramienta invocada con argumentos válidos da 0 escrituras, y la sesión es la fija.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class ToolsListTests
{
    [Test]
    public async Task ToolsList_EsIgualAlJsonSchemaDelCatalogo()
    {
        await using var servidor = await Comun.ServidorAsync();
        await using var mcp = await ConexionMcp.ConectarAsync(servidor.Endpoint, Comun.TokenDeDemostracion);
        var publicadas = await mcp.ListToolsAsync();
        var catalogo = CatalogoDeHerramientas.DeLectura().ToDictionary(f => f.Name);

        Assert.That(publicadas.Select(t => t.Name), Is.EquivalentTo(catalogo.Keys));
        foreach (var t in publicadas)
        {
            var f = catalogo[t.Name];
            var esquemaMcp = JsonSerializer.Serialize(t.ProtocolTool.InputSchema);
            var esquemaCatalogo = JsonSerializer.Serialize(f.JsonSchema);
            TestContext.Out.WriteLine($"{t.Name} readOnlyHint={t.ProtocolTool.Annotations?.ReadOnlyHint}\n  mcp      {esquemaMcp}\n  catálogo {esquemaCatalogo}");
            Assert.That(t.Description, Is.EqualTo(f.Description));
            Assert.That(esquemaMcp, Is.EqualTo(esquemaCatalogo));
            Assert.That(t.ProtocolTool.Annotations?.ReadOnlyHint, Is.True);
            Assert.That(t.ProtocolTool.Annotations?.DestructiveHint, Is.False);
        }
    }

    [Test]
    public async Task CadaHerramientaPublicada_ConArgumentosValidos_NoEscribe()
    {
        await using var servidor = await Comun.ServidorAsync();
        await using var mcp = await ConexionMcp.ConectarAsync(servidor.Endpoint, Comun.TokenDeDemostracion);
        var argumentosValidos = new Dictionary<string, Dictionary<string, object?>>
        {
            [HerramientasDeLocalidades.ContarPorProvincia] = new() { ["provincia"] = "Chaco" },
            [HerramientasDeLocalidades.Listar] = new() { ["provincia"] = "Corrientes" },
        };
        var publicadas = await mcp.ListToolsAsync();
        Assert.That(publicadas.Select(t => t.Name), Is.EquivalentTo(argumentosValidos.Keys), "cada publicada necesita sus argumentos acá");

        var lecturasAntes = servidor.Almacen.Lecturas;
        foreach (var t in publicadas)
        {
            var r = await mcp.CallToolAsync(t.Name, argumentosValidos[t.Name]);
            var texto = string.Join(" ", r.Content.OfType<TextContentBlock>().Select(c => c.Text));
            TestContext.Out.WriteLine($"{t.Name} → {texto}");
            Assert.That(r.IsError, Is.Not.True, t.Name);
            Assert.That(Comun.Ok(texto), Is.True, t.Name);
        }
        Assert.That(servidor.Almacen.Escrituras, Is.Zero);
        Assert.That(servidor.Almacen.Lecturas, Is.GreaterThan(lecturasAntes));
    }

    [Test]
    public async Task LaEscrituraNoSePuedeLlamarPorMcp()
    {
        await using var servidor = await Comun.ServidorAsync();
        await using var mcp = await ConexionMcp.ConectarAsync(servidor.Endpoint, Comun.TokenDeDemostracion);
        var lanzo = false; CallToolResult? r = null;
        try { r = await mcp.CallToolAsync(HerramientasDeLocalidades.Borrar, new Dictionary<string, object?> { ["nombre"] = "Resistencia" }); }
        catch (Exception ex) { lanzo = true; TestContext.Out.WriteLine($"{ex.GetType().Name}: {ex.Message}"); }
        if (r is not null) TestContext.Out.WriteLine($"IsError={r.IsError} {string.Join(" ", r.Content.OfType<TextContentBlock>().Select(c => c.Text))}");
        Assert.That(lanzo || r?.IsError == true, Is.True);
        Assert.That(servidor.Almacen.Escrituras, Is.Zero);
    }

    [Test]
    public async Task LaSesionEsLaFijaDeDemostracion_YElEncabezadoDelClienteNoLaCambia()
    {
        await using var servidor = await Comun.ServidorAsync();
        // Una localidad cargada en la sesión fija y otra en una sesión cualquiera, directo en el almacén.
        servidor.Almacen.Agregar(SesionFijaDeDemostracion.Id, new Localidad { Nombre = "Goya", Provincia = "Corrientes", CodigoPostal = "3450", Habitantes = 89959 });
        servidor.Almacen.Agregar("otra-sesion", new Localidad { Nombre = "Bella Vista", Provincia = "Corrientes", CodigoPostal = "3432", Habitantes = 37181 });

        await using var mcp = await McpClient.CreateAsync(new HttpClientTransport(
            new HttpClientTransportOptions
            {
                Endpoint = servidor.Endpoint,
                TransportMode = HttpTransportMode.StreamableHttp,
                AdditionalHeaders = new Dictionary<string, string> { ["X-Sesion-Id"] = "otra-sesion" },  // se ignora
            },
            new HttpClient(new ManejadorDeTokenMcp(Comun.TokenDeDemostracion)), ownsHttpClient: true));

        var r = await mcp.CallToolAsync(HerramientasDeLocalidades.Listar, new Dictionary<string, object?> { ["provincia"] = "Corrientes" });
        var texto = string.Join(" ", r.Content.OfType<TextContentBlock>().Select(c => c.Text));
        TestContext.Out.WriteLine(texto);
        Assert.That(texto, Does.Contain("Goya"));
        Assert.That(texto, Does.Not.Contain("Bella Vista"));
    }
}
