using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Application.Asistente;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI.DelChatAlAgente;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.SinModelo;

// Uso: dotnet run [-- --sin-modelo] [--aprobar s|n]
bool sinModelo = args.Contains("--sin-modelo");
int iAprobar = Array.IndexOf(args, "--aprobar");
bool? aprobarFijo = iAprobar >= 0 && iAprobar + 1 < args.Length ? args[iAprobar + 1] == "s" : null;

var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
{
    Args = args.Where(a => a != "--sin-modelo").ToArray(),
    ContentRootPath = AppContext.BaseDirectory, // appsettings*.json junto al ejecutable
});
builder.AgregarCapaDeIA(clienteInterno: sinModelo ? _ => new ClienteGuionado() : null);

IHost host;
OpcionesDeIA ia;
try
{
    host = builder.Build();
    ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value; // ValidateOnStart valida acá
}
catch (OptionsValidationException e)
{
    Console.Error.WriteLine($"Configuración inválida: {e.Message}");
    return 3;
}

Console.WriteLine(sinModelo ? "Modo sin modelo (cliente guionado)" : $"Modelo: {ia.Modelo}; num_ctx: {ia.NumCtx}");
using var scope = host.Services.CreateScope();
var sp = scope.ServiceProvider;
const string Sesion = "sesion-de-la-consola";
sp.GetRequiredService<SessionContext>().Set(Sesion);   // en la web lo pone el middleware de sesión
var chat = sp.GetRequiredService<IChatClient>();
var herramientas = sp.GetRequiredService<HerramientasDeLocalidades>();

Console.WriteLine("\n== 4.1 Llamada única con una herramienta");
Console.WriteLine("> ¿Cuántas localidades hay en Chaco?");
Console.WriteLine(await LlamadaUnica.PreguntarAsync(chat, herramientas, FabricaDeOpcionesDeChat.Crear(ia), "¿Cuántas localidades hay en Chaco?"));

Console.WriteLine("\n== 4.2 El mismo IChatClient como agente de MAF, con sesión");
var agente = AgenteDeMaf.Crear(chat, herramientas);
string[] preguntas = ["¿Cuántas localidades hay en Chaco?", "¿Y en Corrientes?"];
var respuestas = await AgenteDeMaf.ConversarAsync(agente, FabricaDeOpcionesDeChat.Crear(ia), preguntas);
for (int i = 0; i < preguntas.Length; i++) Console.WriteLine($"> {preguntas[i]}\n{respuestas[i]}");

Console.WriteLine("\n== Escritura con aprobación");
var asistente = sp.GetRequiredService<IAsistenteConAprobacion>();
const string Conversacion = "conversacion-1";
Console.WriteLine("> Borrá Resistencia");
var r = await asistente.ConversarAsync(Sesion, Conversacion, "Borrá Resistencia");
if (r.Texto.Length > 0) Console.WriteLine(r.Texto);
if (r.Pendiente is { } pendiente)
{
    bool aprobado = await Aprobacion.PedirAprobacionAsync(
        pendiente, new AprobadorDeConsola(aprobarFijo), TimeSpan.FromSeconds(ia.Aprobaciones.PlazoDeRespuestaSegundos));
    r = await asistente.ResolverAsync(Sesion, Conversacion, pendiente.Id, aprobado);
    Console.WriteLine(r.Texto);
}
var quedan = await sp.GetRequiredService<LocalidadService>().GetAllAsync();
Console.WriteLine($"Localidades de la sesión: {string.Join(", ", quedan.Select(l => l.Nombre))}");
return 0;
