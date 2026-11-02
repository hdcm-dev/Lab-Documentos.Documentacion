using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.ToolCalling.Application.Asistente;
using MovilidadUrbana.Ejemplos.ToolCalling.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.ToolCalling.SinModelo;

// Las preguntas de la corrida: una que la herramienta responde y otra con una provincia fuera del catálogo.
string[] preguntas =
[
    "¿Cuántas localidades hay cargadas en Chaco?",
    "¿Y cuántas hay en Misiones?",
];

bool sinModelo = args.Contains("--sin-modelo");

// Los appsettings*.json se copian a la salida: la raíz de contenido es la carpeta del ejecutable.
var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
{
    Args = args.Where(a => a != "--sin-modelo").ToArray(),
    ContentRootPath = AppContext.BaseDirectory,
});
builder.AgregarCapaDeIA(clienteInterno: sinModelo
    ? _ => new ClienteGuionado(new Dictionary<string, FunctionCallContent>
    {
        [preguntas[0]] = new("-", HerramientasDeLocalidades.ContarPorProvincia, new Dictionary<string, object?> { ["provincia"] = "Chaco" }),
        [preguntas[1]] = new("-", HerramientasDeLocalidades.ContarPorProvincia, new Dictionary<string, object?> { ["provincia"] = "Misiones" }),
    })
    : null);

using var host = builder.Build();
try
{
    await host.StartAsync(); // ValidateOnStart: una opción inválida corta acá, antes del primer pedido
}
catch (OptionsValidationException ex)
{
    Console.Error.WriteLine($"Configuración inválida: {string.Join(" | ", ex.Failures)}");
    return 3;
}

var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
Console.WriteLine(sinModelo
    ? "Modo sin modelo: un cliente guionado pide las herramientas."
    : $"Proveedor: {ia.Proveedor}; modelo: {ia.Modelo}; num_ctx: {(ia.Proveedor == Proveedores.Ollama ? ia.NumCtx : "no se fija por /v1")}");
Console.WriteLine($"Bucle: hasta {ia.Herramientas.MaximoDeIteraciones} iteraciones, {ia.Herramientas.MaximoDeErroresConsecutivos} errores consecutivos.");

// Un ámbito = una sesión. La consola usa una sola, sembrada como el caso base (Corrientes y Resistencia).
using var ambito = host.Services.CreateScope();
ambito.ServiceProvider.GetRequiredService<SessionContext>().Set("sesion-de-la-consola");
var asistente = ambito.ServiceProvider.GetRequiredService<IAsistenteDeLocalidades>();

try
{
    foreach (var pregunta in preguntas)
    {
        RespuestaDelAsistente r = await asistente.PreguntarAsync(pregunta);
        Console.WriteLine($"> {pregunta}");
        foreach (var h in r.Herramientas)
            Console.WriteLine($"  [herramienta] {h.Nombre}({h.Argumentos}) → {h.Resultado}");
        Console.WriteLine(r.Texto);
    }
}
catch (EntradaDemasiadoLargaException ex)
{
    Console.Error.WriteLine(ex.Message);
    return 2;
}

await host.StopAsync();
return 0;
