using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ModelContextProtocol.Client;
using MovilidadUrbana.Ejemplos.Mcp.Cliente;
using MovilidadUrbana.Ejemplos.Mcp.Cliente.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.Mcp.Cliente.Mcp;
using MovilidadUrbana.Ejemplos.Mcp.Cliente.SinModelo;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Herramientas;
using ModelContextProtocol.Server;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.Mcp.Tests.Cableado;

/// <summary>El cliente MCP: lista blanca por nombre y un agente de MAF con McpClientTool, sin modelo.</summary>
[TestFixture, Category("Cableado")]
public sealed class ClienteYAgenteTests
{
    private static IHost Anfitrion(ClienteGuionado guion)
    {
        var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
        {
            DisableDefaults = true,
            EnvironmentName = "Development",
            ContentRootPath = AppContext.BaseDirectory,
        });
        builder.Configuration.AddJsonFile("appsettings.json").AddJsonFile("appsettings.Development.json");
        builder.AgregarCapaDeIA(_ => null, _ => guion);
        var host = builder.Build();
        host.Start();
        return host;
    }

    [Test]
    public void LaListaBlancaDeLaConfiguracion_EsLaDeLasHerramientasDeLectura()
    {
        using var host = Anfitrion(new ClienteGuionado(new Dictionary<string, FunctionCallContent>()));
        var permitidas = host.Services.GetRequiredService<IOptions<OpcionesDelClienteMcp>>().Value.HerramientasPermitidas;
        Assert.That(permitidas, Is.EquivalentTo(CatalogoDeHerramientas.DeLectura().Select(f => f.Name)));
    }

    [Test]
    public async Task LaListaBlanca_DescartaLoQueElServidorPubliqueDeMas()
    {
        // Un servidor que, además del catálogo, publica una herramienta que el cliente no conoce.
        var extra = McpServerTool.Create(AIFunctionFactory.Create(() => "todo borrado", "borrar_todo"), new McpServerToolCreateOptions { ReadOnly = true });
        await using var servidor = await Servidor.Mcp.ServidorMcp.IniciarEnLoopbackAsync("Development", herramientas: b => b
            .WithTools(CatalogoDeHerramientas.DeLectura().Select(f => McpServerTool.Create(f)))
            .WithTools([extra]));
        await using var mcp = await ConexionMcp.ConectarAsync(servidor.Endpoint, Comun.TokenDeDemostracion);

        var ofrecidas = await mcp.ListToolsAsync();
        var filtradas = ListaBlanca.Filtrar(ofrecidas, ["contar_localidades_por_provincia", "listar_localidades", "no_existe"]);
        TestContext.Out.WriteLine($"ofrecidas: {string.Join(", ", ofrecidas.Select(t => t.Name))}; descartadas: {string.Join(", ", filtradas.Descartadas)}; faltantes: {string.Join(", ", filtradas.Faltantes)}");

        Assert.That(ofrecidas.Select(t => t.Name), Has.Member("borrar_todo"));      // el servidor la ofrece, y dice readOnly
        Assert.That(filtradas.Aceptadas.Select(t => t.Name), Is.EquivalentTo(new[] { "contar_localidades_por_provincia", "listar_localidades" }));
        Assert.That(filtradas.Descartadas, Is.EqualTo(new[] { "borrar_todo" }));
        Assert.That(filtradas.Faltantes, Is.EqualTo(new[] { "no_existe" }));
        Assert.That(filtradas.ComoHerramientas(), Is.All.InstanceOf<AIFunction>());  // McpClientTool : AIFunction
    }

    [Test]
    public async Task ElAgenteConMcpClientTool_LlamaAlServidorPorMcp_SinModelo()
    {
        const string pregunta = "¿Cuántas localidades hay cargadas en Chaco?";
        var guion = new ClienteGuionado(new Dictionary<string, FunctionCallContent>
        {
            [pregunta] = new("g1", HerramientasDeLocalidades.ContarPorProvincia, new Dictionary<string, object?> { ["provincia"] = "chaco" }),
        });
        using var host = Anfitrion(guion);
        await using var servidor = await Comun.ServidorAsync();
        await using var mcp = await ConexionMcp.ConectarAsync(servidor.Endpoint, Comun.TokenDeDemostracion);
        var opcionesMcp = host.Services.GetRequiredService<IOptions<OpcionesDelClienteMcp>>().Value;
        var filtradas = ListaBlanca.Filtrar(await mcp.ListToolsAsync(), opcionesMcp.HerramientasPermitidas);
        Assert.That(filtradas.Aceptadas, Is.All.InstanceOf<McpClientTool>());

        var agente = new AgenteDeLocalidadesPorMcp(host.Services.GetRequiredService<IChatClient>(), filtradas,
            host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value);
        var lecturasAntes = servidor.Almacen.Lecturas;
        var r = await agente.PreguntarAsync(pregunta);

        TestContext.Out.WriteLine($"{string.Join(" ; ", r.Herramientas.Select(h => $"{h.Nombre}({h.Argumentos}) → {h.Resultado}"))}\n«{r.Texto}»");
        Assert.That(r.Herramientas.Select(h => h.Nombre), Is.EqualTo(new[] { HerramientasDeLocalidades.ContarPorProvincia }));
        Assert.That(r.Herramientas[0].Resultado, Does.Match("\"cantidad\\\\?\"\\s*:\\s*1\\b"));
        Assert.That(servidor.Almacen.Lecturas, Is.EqualTo(lecturasAntes + 1), "la herramienta se ejecutó en el servidor, una vez");
        Assert.That(servidor.Almacen.Escrituras, Is.Zero);
        Assert.That(guion.Llamadas, Is.EqualTo(2), "pide la herramienta y después redacta");
    }

    [Test]
    public async Task ElAgente_RechazaUnaEntradaDemasiadoLarga_SinLlamarAlModelo()
    {
        var guion = new ClienteGuionado(new Dictionary<string, FunctionCallContent>());
        using var host = Anfitrion(guion);
        var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
        var agente = new AgenteDeLocalidadesPorMcp(host.Services.GetRequiredService<IChatClient>(), new HerramientasFiltradas([], [], []), ia);
        await Assert.ThrowsAsync<ArgumentException>(() => agente.PreguntarAsync(new string('a', ia.LargoMaximoDeEntrada + 1)));
        Assert.That(guion.Llamadas, Is.Zero);
    }
}
