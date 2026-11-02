// Rótulo R-06 (dominio ilustrativo del dossier; la guía usa Movilidad Urbana): evidencia compilada, no se reescribe.
using System.ComponentModel;
using Microsoft.Agents.AI;
using Microsoft.Agents.AI.Workflows;
using Microsoft.Extensions.AI;
using ModelContextProtocol.Client;
using OllamaSharp;

// Compile-check only (N4 dossier). Endpoint overridable by env var; default localhost.
var endpoint = Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT") ?? "http://localhost:11434";
var model = Environment.GetEnvironmentVariable("OLLAMA_MODEL") ?? "qwen3:4b";

// 1) MEAI: function calling with FunctionInvokingChatClient
IChatClient baseClient = new OllamaApiClient(new Uri(endpoint), model);
IChatClient client = new ChatClientBuilder(baseClient)
    .UseFunctionInvocation(configure: f => { f.MaximumIterationsPerRequest = 5; })
    .Build();
var options = new ChatOptions { Tools = [AIFunctionFactory.Create(Tools.GetEstadoLinea)] };

// 2) Agent Framework: ChatClientAgent + session + approval
AIFunction approval = new ApprovalRequiredAIFunction(AIFunctionFactory.Create(Tools.ReportarIncidente));
AIAgent agent = baseClient.AsAIAgent(
    instructions: "Respondé sobre movilidad urbana.",
    name: "Movilidad",
    tools: [AIFunctionFactory.Create(Tools.GetEstadoLinea), approval]);

if (args.Length > 0 && args[0] == "run")
{
    AgentSession session = await agent.CreateSessionAsync();
    AgentResponse response = await agent.RunAsync("¿Cómo está la línea 1?", session);
    var reqs = response.Messages.SelectMany(m => m.Contents).OfType<ToolApprovalRequestContent>().ToList();
    if (reqs.Count > 0)
    {
        var msg = new ChatMessage(ChatRole.User, [reqs[0].CreateResponse(true)]);
        Console.WriteLine(await agent.RunAsync(msg, session));
    }
    Console.WriteLine(response.Text);
    var r2 = await client.GetResponseAsync("¿Cómo está la línea 1?", options);
    Console.WriteLine(r2.Text);
}

// 3) Workflows: executors + edges + checkpoint + HITL port
var upper = new UppercaseExecutor();
Func<string, string> rev = s => new string(s.Reverse().ToArray());
var reverse = rev.BindAsExecutor("Reverse");
Workflow wf = new WorkflowBuilder(upper).AddEdge(upper, reverse).WithOutputFrom(reverse).Build();
CheckpointManager cm = CheckpointManager.CreateInMemory();
await using (StreamingRun run = await InProcessExecution.RunStreamingAsync(wf, "hola", cm))
{
    await foreach (WorkflowEvent evt in run.WatchStreamAsync())
    {
        if (evt is SuperStepCompletedEvent ss) Console.WriteLine($"checkpoint: {ss.CompletionInfo?.Checkpoint is not null}");
        if (evt is WorkflowOutputEvent o) Console.WriteLine($"output: {o.Data}");
    }
}
var port = RequestPort.Create<string, bool>("Aprobacion");
var sequential = AgentWorkflowBuilder.BuildSequential(agent, agent);
AIAgent wfAgent = sequential.AsAIAgent();

// 4) MCP client (types only; not executed)
if (args.Length > 0 && args[0] == "mcp")
{
    var transport = new StdioClientTransport(new StdioClientTransportOptions { Name = "x", Command = "echo" });
    McpClient mcp = await McpClient.CreateAsync(transport);
    IList<McpClientTool> tools = await mcp.ListToolsAsync();
    AIAgent withMcp = baseClient.AsAIAgent(instructions: "x", tools: [.. tools]);
}

static class Tools
{
    [Description("Devuelve el estado operativo de una línea.")]
    public static string GetEstadoLinea([Description("Código de línea")] string linea) => $"Línea {linea}: normal";
    [Description("Registra un incidente (requiere aprobación).")]
    public static string ReportarIncidente(string descripcion) => "registrado";
}

internal sealed partial class UppercaseExecutor() : Executor("UppercaseExecutor")
{
    [MessageHandler]
    private ValueTask<string> HandleAsync(string message, IWorkflowContext context)
        => ValueTask.FromResult(message.ToUpperInvariant());
}
