using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovilidadUrbana.Streaming;

// Uso: dotnet run -- [--pregunta "<texto>"] [--cortar-a-los <segundos>]
// Ctrl+C también cancela la respuesta en curso.
string pregunta = ContextoDeLaEncuesta.PreguntaDeEjemplo;
int? cortarALos = null;
for (int i = 0; i < args.Length - 1; i++)
{
    if (args[i] == "--pregunta") pregunta = args[i + 1];
    if (args[i] == "--cortar-a-los") cortarALos = int.Parse(args[i + 1]);
}

// La raíz de contenido es la carpeta del ejecutable: así los appsettings se encuentran
// también con «dotnet run --project», que corre desde otra carpeta.
var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
{
    Args = args,
    ContentRootPath = AppContext.BaseDirectory,
});
builder.AgregarIA();
using var host = builder.Build();
await host.StartAsync();   // ValidateOnStart: una opción inválida corta acá

var asistente = host.Services.GetRequiredService<AsistenteDeLaEncuesta>();
var historial = asistente.NuevaConversacion();

using var cts = new CancellationTokenSource();
Console.CancelKeyPress += (_, e) => { e.Cancel = true; cts.Cancel(); };
if (cortarALos is int segundos) cts.CancelAfter(TimeSpan.FromSeconds(segundos));

Console.WriteLine($"> {pregunta}");
var resultado = await asistente.ResponderAsync(historial, pregunta, Console.Write, ct: cts.Token);
Console.WriteLine();

Console.WriteLine(resultado.Cancelada
    ? $"[cancelada: {resultado.Texto.Length} caracteres parciales; el historial no la guarda]"
    : $"[completa: motivo de fin {resultado.Respuesta?.FinishReason}; " +
      $"tokens de entrada {resultado.Respuesta?.Usage?.InputTokenCount}, de salida {resultado.Respuesta?.Usage?.OutputTokenCount}]");
Console.WriteLine($"[fragmentos {resultado.Fragmentos}; primer texto a los {resultado.PrimerFragmento?.TotalSeconds:F1} s; " +
                  $"total {resultado.Total.TotalSeconds:F1} s; mensajes en el historial {historial.Count}]");

await host.StopAsync();
