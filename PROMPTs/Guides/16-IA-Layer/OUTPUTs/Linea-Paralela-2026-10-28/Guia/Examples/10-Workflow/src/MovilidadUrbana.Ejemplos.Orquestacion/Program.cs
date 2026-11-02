using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Application.Encuestas;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.Orquestacion.Application.Altas;
using MovilidadUrbana.Ejemplos.Orquestacion.Application.Encuesta;
using MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.Workflows;
using MovilidadUrbana.Ejemplos.Orquestacion.SinModelo;

// Uso: dotnet run -- <encuesta | alta | secuencial> [--sin-modelo] [--confirmar si|no|nadie] [--texto "..."]
string comando = args.FirstOrDefault(a => !a.StartsWith("--")) ?? "encuesta";
bool sinModelo = args.Contains("--sin-modelo");
string confirmar = Valor("--confirmar") ?? "si";
string[] textos = Valor("--texto") is { } t
    ? [t]
    : ["Agregá Goya, Corrientes, CP 34, 89959 habitantes", "Agregá Goya, Corrientes, CP 3450, 89959 habitantes"];

var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
{
    Args = args.Where(a => a.StartsWith("--AI:")).ToArray(),
    ContentRootPath = AppContext.BaseDirectory,
});
builder.AgregarCapaDeIA(clienteInterno: sinModelo || comando == "encuesta" ? _ => GuionSinModelo() : null);

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

using var ambito = host.Services.CreateScope();
ambito.ServiceProvider.GetRequiredService<SessionContext>().Set("sesion-de-la-consola");
var sp = ambito.ServiceProvider;

switch (comando)
{
    case "encuesta":
        // CASO-8: la misma encuesta como función y como workflow de MAF. Ningún paso usa modelo.
        Console.WriteLine("Encuesta de tres pasos: función frente a workflow de MAF (sin modelo).");
        foreach (var (nombre, crear) in EncuestasDeEjemplo.Todas)
        {
            var comoFuncion = await sp.GetRequiredService<EncuestaComoProceso>().CompletarAsync(crear());
            var (comoGrafo, executors, supersteps) =
                await EncuestaComoWorkflowDeMaf.CompletarAsync(sp.GetRequiredService<EncuestaService>(), crear());
            Console.WriteLine($"- {nombre}: función → {comoFuncion}; workflow de MAF → {comoGrafo} " +
                              $"({supersteps} supersteps: {string.Join(" > ", executors)})");
        }
        break;

    case "alta":
        var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
        Console.WriteLine(sinModelo ? "Modo sin modelo: un cliente guionado hace de extractor." : $"Modelo: {ia.Modelo}; num_ctx: {ia.NumCtx}");
        foreach (var texto in textos)
        {
            var workflow = WorkflowDeAlta.Construir(sp.GetRequiredService<IExtractorDeAlta>(), sp.GetRequiredService<LocalidadService>());
            var traza = await WorkflowDeAlta.EjecutarAsync(workflow, texto, revision =>
            {
                Console.WriteLine($"  [confirmar-alta] ¿Agregar {revision.Propuesta}? → {confirmar}");
                return confirmar switch { "si" => new ConfirmacionDeAlta(true), "no" => new ConfirmacionDeAlta(false), _ => null };
            });
            Console.WriteLine($"> {texto}");
            Console.WriteLine($"  pasos: {string.Join(" > ", traza.Pasos)}");
            Console.WriteLine($"  resultado: {traza.Resultado?.ToString() ?? "(sin salida)"}; estado de la corrida: {traza.Estado}");
        }
        break;

    case "secuencial":
        // BuildSequential + AsAIAgent: para quien lo llama es un agente; el orden está en el grafo.
        var opciones = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
        var agente = AltaAsistidaSecuencial.ComoAgente(sp.GetRequiredService<IChatClient>(), opciones);
        Console.WriteLine($"Tipo expuesto: {agente.GetType().Name} (es AIAgent)");
        foreach (var texto in textos)
        {
            var sesion = await agente.CreateSessionAsync();
            var respuesta = await agente.RunAsync(texto, sesion);
            Console.WriteLine($"> {texto}");
            foreach (var m in respuesta.Messages)
                Console.WriteLine($"  [{m.AuthorName ?? m.Role.Value}] {m.Text}");
        }
        break;

    default:
        Console.Error.WriteLine($"Comando desconocido: {comando}. Usá encuesta, alta o secuencial.");
        return 2;
}

Console.WriteLine($"Escrituras en el almacén: {host.Services.GetRequiredService<MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.Persistence.AlmacenEnMemoria>().Escrituras}");
await host.StopAsync();
return 0;

string? Valor(string nombre)
{
    int i = Array.IndexOf(args, nombre);
    return i >= 0 && i + 1 < args.Length ? args[i + 1] : null;
}

// Guion del modo sin modelo: el extractor estructurado devuelve el JSON que el texto dice; el de la
// secuencia, una línea; el redactor, una oración. No muestra el comportamiento de un modelo.
static ClienteGuionado GuionSinModelo() => new((mensajes, opciones) =>
{
    var texto = mensajes.LastOrDefault(m => m.Role == ChatRole.User)?.Text ?? string.Empty;
    var cp = texto.Contains("3450") ? "3450" : "34";
    if (opciones?.Instructions == AltaAsistidaSecuencial.InstruccionesDelRedactor)
        return "Se va a agregar Goya (Corrientes). ¿Confirmás?";
    if (opciones?.Instructions == AltaAsistidaSecuencial.InstruccionesDelExtractor)
        return $"Goya; Corrientes; {cp}; 89959";
    return $$"""{"nombre":"Goya","provincia":"Corrientes","codigoPostal":"{{cp}}","habitantes":89959}""";
});
