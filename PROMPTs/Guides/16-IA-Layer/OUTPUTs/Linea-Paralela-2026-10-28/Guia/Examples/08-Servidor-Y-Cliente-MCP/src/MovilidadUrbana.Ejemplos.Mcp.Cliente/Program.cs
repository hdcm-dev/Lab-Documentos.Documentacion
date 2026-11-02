using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.Mcp.Cliente;
using MovilidadUrbana.Ejemplos.Mcp.Cliente.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.Mcp.Cliente.Mcp;
using MovilidadUrbana.Ejemplos.Mcp.Cliente.SinModelo;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Mcp;

// D7: un cliente MCP lista localidades. La consola levanta el servidor MCP del ejemplo en 127.0.0.1 (mismo
// proceso), se conecta por HTTP con su token, filtra las herramientas por lista blanca y se las da a un agente.
// --sin-modelo: el «modelo» es un cliente guionado; se ve el cableado, no el comportamiento de un modelo.
var sinModelo = args.Contains("--sin-modelo");
string[] preguntas = ["¿Cuántas localidades hay cargadas en Chaco?", "¿Qué localidades hay cargadas en Corrientes?"];

var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
{
    Args = args.Where(a => a != "--sin-modelo").ToArray(),
    ContentRootPath = AppContext.BaseDirectory,   // los appsettings*.json están junto al ejecutable
});
builder.AgregarCapaDeIA(clienteInterno: sinModelo
    ? _ => new ClienteGuionado(new Dictionary<string, FunctionCallContent>
    {
        [preguntas[0]] = new("g1", "contar_localidades_por_provincia", new Dictionary<string, object?> { ["provincia"] = "Chaco" }),
        [preguntas[1]] = new("g2", "listar_localidades", new Dictionary<string, object?> { ["provincia"] = "Corrientes" }),
    })
    : null);

IHost host;
try { host = builder.Build(); await host.StartAsync(); }
catch (Exception ex) when (ex is OptionsValidationException || ex.InnerException is OptionsValidationException)
{
    var fallas = (ex as AggregateException)?.InnerExceptions.OfType<OptionsValidationException>() ?? [(OptionsValidationException)(ex.InnerException ?? ex)];
    Console.Error.WriteLine($"Configuración inválida: {string.Join(" | ", fallas.SelectMany(f => f.Failures))}");
    return 3;
}

var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
var clienteMcp = host.Services.GetRequiredService<IOptions<OpcionesDelClienteMcp>>().Value;

await using var servidor = await ServidorMcp.IniciarEnLoopbackAsync(builder.Environment.EnvironmentName);
await using var mcp = await ConexionMcp.ConectarAsync(servidor.Endpoint, clienteMcp.Token!);

var filtradas = ListaBlanca.Filtrar(await mcp.ListToolsAsync(), clienteMcp.HerramientasPermitidas);
Console.WriteLine($"Servidor MCP: {mcp.ServerInfo?.Name} {mcp.ServerInfo?.Version}, protocolo {mcp.NegotiatedProtocolVersion}");
Console.WriteLine($"Herramientas aceptadas: {string.Join(", ", filtradas.Aceptadas.Select(t => t.Name))}");
Console.WriteLine($"Descartadas por la lista blanca: {(filtradas.Descartadas.Count == 0 ? "ninguna" : string.Join(", ", filtradas.Descartadas))}");
Console.WriteLine($"Modelo: {(sinModelo ? "ninguno (cliente guionado)" : ia.Modelo)}\n");

var agente = new AgenteDeLocalidadesPorMcp(host.Services.GetRequiredService<IChatClient>(), filtradas, ia);
foreach (var pregunta in preguntas)
{
    var r = await agente.PreguntarAsync(pregunta);
    Console.WriteLine($"> {pregunta}");
    foreach (var h in r.Herramientas) Console.WriteLine($"  [mcp] {h.Nombre}({h.Argumentos}) → {h.Resultado}");
    Console.WriteLine($"  {r.Texto}\n");
}
Console.WriteLine($"Escrituras en el servidor: {servidor.Almacen.Escrituras}");

await host.StopAsync();
return 0;
