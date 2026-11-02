using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Extensions.AI;
using Microsoft.SemanticKernel;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.AnotacionesPareadas.Application.Resultados;
using MovilidadUrbana.Ejemplos.AnotacionesPareadas.Infrastructure.AI.AgentFramework;
using MovilidadUrbana.Ejemplos.AnotacionesPareadas.Infrastructure.AI.SemanticKernel;
using MovilidadUrbana.Ejemplos.AnotacionesPareadas.Infrastructure.Persistence;
using MovilidadUrbana.Ejemplos.AnotacionesPareadas.SinModelo;

// Ejemplo 12: la misma herramienta con [KernelFunction] (Semantic Kernel) y con [Description] + AIFunctionFactory
// (Agent Framework), sobre el mismo caso de uso. Corre sin modelo: el «modelo» es un cliente guionado.
var sesion = new SessionContext();
sesion.Set("sesion-de-ejemplo");
var consulta = new ConsultaDeResultadosPorMedio(new RespuestasEnMemoria(sesion));

var plugin = new ResultadosDeEncuestaPlugin(consulta);
var herramientas = new HerramientasDeResultados(consulta);
var guion = new Dictionary<string, object?> { ["localidad"] = "Corrientes" };

var chatSk = new ClienteGuionado(HerramientasDeResultados.ResultadosPorMedio, guion);
Kernel kernel = AgenteDeSemanticKernel.CrearKernel(chatSk, plugin);
AIFunction funcionSk = kernel.Plugins[AgenteDeSemanticKernel.NombreDelPlugin]["resultados_por_medio"];
AIFunction funcionMaf = herramientas.ComoAIFunction();

Console.WriteLine("== Declaración que ve el modelo");
Mostrar("Semantic Kernel", funcionSk);
Mostrar("Agent Framework", funcionMaf);

Console.WriteLine("== Invocación directa con {\"localidad\":\"Corrientes\"}");
var argumentos = new AIFunctionArguments(guion);
Console.WriteLine($"Semantic Kernel: {Compacto(await funcionSk.InvokeAsync(argumentos))}");
Console.WriteLine($"Agent Framework: {Compacto(await funcionMaf.InvokeAsync(argumentos))}");

const string pregunta = "¿Qué medios usa la gente de Corrientes?";
Console.WriteLine($"== Agente con cliente guionado: «{pregunta}»");
var textoSk = await AgenteDeSemanticKernel.PreguntarAsync(kernel, pregunta);
Console.WriteLine($"ChatCompletionAgent: pidió «{chatSk.NombrePedido}»; llamadas al cliente {chatSk.Llamadas}; resultado recibido como {chatSk.TipoDelResultado?.Name}");
Console.WriteLine($"  {textoSk}");
var chatMaf = new ClienteGuionado(HerramientasDeResultados.ResultadosPorMedio, guion);
var textoMaf = await AgenteDeAgentFramework.PreguntarAsync(chatMaf, herramientas, pregunta);
Console.WriteLine($"AsAIAgent: pidió «{chatMaf.NombrePedido}»; llamadas al cliente {chatMaf.Llamadas}; resultado recibido como {chatMaf.TipoDelResultado?.Name}");
Console.WriteLine($"  {textoMaf.ReplaceLineEndings("").Replace("  ", "")}");

static void Mostrar(string marco, AIFunction f) =>
    Console.WriteLine($"{marco}: {f.GetType().Name}; Name «{f.Name}»; JsonSchema {Compacto(f.JsonSchema)}");

static string Compacto(object? valor) => valor is JsonElement e
    ? JsonNode.Parse(e.GetRawText())?.ToJsonString() ?? "null"
    : JsonSerializer.Serialize(valor);
