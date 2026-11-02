using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using MovilidadUrbana.Ejemplos.Mcp.Cliente.Mcp;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Herramientas;
using NUnit.Framework;
using OllamaSharp;

namespace MovilidadUrbana.Ejemplos.Mcp.Tests.Cableado;

/// <summary>
/// Qué le llega al modelo cuando la herramienta es una McpClientTool: se captura el cuerpo del segundo pedido a
/// /api/chat (el que lleva el mensaje «tool») con un servidor Ollama falso y el OllamaApiClient real.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class LoQueLeeElModeloTests
{
    private sealed class OllamaFalso : HttpMessageHandler
    {
        public List<string> Cuerpos { get; } = [];

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage pedido, CancellationToken ct)
        {
            Cuerpos.Add(pedido.Content is null ? "" : await pedido.Content.ReadAsStringAsync(ct));
            var mensaje = Cuerpos.Count == 1
                ? "{\"role\":\"assistant\",\"content\":\"\",\"tool_calls\":[{\"function\":{\"name\":\"contar_localidades_por_provincia\",\"arguments\":{\"provincia\":\"Chaco\"}}}]}"
                : """{"role":"assistant","content":"Hay 1 localidad cargada en Chaco."}""";
            var json = "{\"model\":\"modelo-de-prueba\",\"created_at\":\"2026-10-28T00:00:00Z\",\"message\":" + mensaje +
                       ",\"done\":true,\"done_reason\":\"stop\",\"prompt_eval_count\":200,\"eval_count\":10}\n";
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(json, Encoding.UTF8, "application/x-ndjson") };
        }
    }

    [Test]
    public async Task ElMensajeToolLlevaElResultadoDeMcp()
    {
        await using var servidor = await Comun.ServidorAsync();
        await using var mcp = await ConexionMcp.ConectarAsync(servidor.Endpoint, Comun.TokenDeDemostracion);
        var filtradas = ListaBlanca.Filtrar(await mcp.ListToolsAsync(), [HerramientasDeLocalidades.ContarPorProvincia]);

        var falso = new OllamaFalso();
        IChatClient chat = new ChatClientBuilder(new OllamaApiClient(new HttpClient(falso) { BaseAddress = new Uri("http://ollama-falso") }, "modelo-de-prueba"))
            .UseFunctionInvocation().Build();
        AIAgent agente = chat.AsAIAgent(instructions: "Respondé con datos.", tools: filtradas.ComoHerramientas());
        var r = await agente.RunAsync("¿Cuántas localidades hay cargadas en Chaco?");

        Assert.That(falso.Cuerpos, Has.Count.EqualTo(2));
        var mensajes = JsonNode.Parse(falso.Cuerpos[1])!["messages"]!.AsArray();
        var tool = mensajes.Single(m => (string?)m!["role"] == "tool")!;
        var contenido = (string)tool["content"]!;
        TestContext.Out.WriteLine($"herramientas declaradas: {JsonNode.Parse(falso.Cuerpos[0])!["tools"]!.ToJsonString().Length} caracteres");
        TestContext.Out.WriteLine($"mensaje tool: {contenido}");
        TestContext.Out.WriteLine($"respuesta: {r.Text}");
        // Medido con OllamaSharp 5.5.0 y ModelContextProtocol 2.3.0: el modelo lee el FunctionResultContent
        // entero, y adentro el TextContent de MCP, con la Respuesta como texto JSON dentro de un string.
        var leido = JsonNode.Parse(contenido)!;
        Assert.That((string?)leido["Result"]!["$type"], Is.EqualTo("text"));
        var interno = JsonNode.Parse((string)leido["Result"]!["Text"]!)!;
        Assert.That((int)interno["datos"]!["cantidad"]!, Is.EqualTo(1));
        Assert.That(servidor.Almacen.Escrituras, Is.Zero);
    }
}
