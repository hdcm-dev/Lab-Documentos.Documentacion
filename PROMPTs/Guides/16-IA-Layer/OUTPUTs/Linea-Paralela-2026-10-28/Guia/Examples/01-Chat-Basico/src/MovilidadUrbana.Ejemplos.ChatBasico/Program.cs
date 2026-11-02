using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.ChatBasico.Configuracion;
using MovilidadUrbana.Ejemplos.ChatBasico.Conversacion;

// Los appsettings*.json se copian a la salida: la raíz de contenido es la carpeta del ejecutable.
var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
{
    Args = args,
    ContentRootPath = AppContext.BaseDirectory,
});
builder.AgregarCapaDeIA();

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
Console.WriteLine($"Proveedor: {ia.Proveedor}; modelo: {ia.Modelo}; num_ctx: {(ia.Proveedor == Proveedores.Ollama ? ia.NumCtx : "no se fija por /v1")}");

var asistente = host.Services.GetRequiredService<AsistenteDeMovilidad>();
string[] preguntas =
[
    builder.Configuration["pregunta"] ?? "¿Cuántos dígitos lleva el código postal de una localidad?",
    "¿Y la provincia puede ser cualquiera?", // segunda vuelta: viaja con el historial
];

try
{
    foreach (var pregunta in preguntas)
    {
        ChatResponse respuesta = await asistente.PreguntarAsync(pregunta);
        Console.WriteLine($"> {pregunta}");
        Console.WriteLine(respuesta.Text.Trim());
        Console.WriteLine($"  [uso] entrada={respuesta.Usage?.InputTokenCount} salida={respuesta.Usage?.OutputTokenCount} fin={respuesta.FinishReason}");
    }
}
catch (EntradaDemasiadoLargaException ex)
{
    Console.Error.WriteLine(ex.Message);
    return 2;
}

await host.StopAsync();
return 0;
