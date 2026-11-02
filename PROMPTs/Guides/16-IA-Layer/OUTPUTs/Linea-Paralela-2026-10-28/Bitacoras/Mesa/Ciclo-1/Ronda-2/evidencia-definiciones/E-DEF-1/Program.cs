using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Agents.AI;
using Microsoft.Agents.AI.Workflows;
using Microsoft.Extensions.AI;

// E-DEF-1 (consulta P-31 / D-7): quién decide el próximo paso.
// Determinista, sin modelo: un IChatClient "guionado" hace de modelo.
// Parte 1: el mismo código de agente, dos guiones -> dos órdenes de herramientas.
// Parte 2: un workflow de MAF expuesto con AsAIAgent(): el orden sólo cambia si cambia el código del grafo.

var bitacora = new List<string>();

AIFunction contar = AIFunctionFactory.Create(
    [Description("Cuenta las encuestas registradas")] () => { bitacora.Add("herramienta:contar_encuestas"); return 42; },
    "contar_encuestas");
AIFunction listar = AIFunctionFactory.Create(
    [Description("Lista las localidades del catálogo")] () => { bitacora.Add("herramienta:listar_localidades"); return "Rosario, <otra-localidad>"; },
    "listar_localidades");

async Task<string> CorrerAgente(string[] guion)
{
    bitacora.Clear();
    AIAgent agente = new GuionChatClient("modelo", guion, bitacora)
        .AsAIAgent(instructions: "Respondé sobre movilidad urbana.", name: "Asistente", tools: [contar, listar]);
    AgentSession s = await agente.CreateSessionAsync();
    var r = await agente.RunAsync("Dame el resumen", s);
    return string.Join(" > ", bitacora.Where(b => b.StartsWith("herramienta:"))) + $"  | respuesta: {r.Text}";
}

Console.WriteLine("PARTE 1 - agente (AsAIAgent sobre IChatClient), mismo código:");
Console.WriteLine("  guion A: " + await CorrerAgente(["contar_encuestas", "listar_localidades"]));
Console.WriteLine("  guion B: " + await CorrerAgente(["listar_localidades", "contar_encuestas"]));
Console.WriteLine("  guion C: " + await CorrerAgente([]));

async Task<string> CorrerWorkflow(bool invertirCodigo)
{
    bitacora.Clear();
    // Cada paso es un agente sin herramientas; el "modelo" de cada uno sólo deja rastro.
    AIAgent paso1 = new GuionChatClient("paso-1", [], bitacora)
        .AsAIAgent(instructions: "Paso 1", name: "Paso1");
    AIAgent paso2 = new GuionChatClient("paso-2", [], bitacora)
        .AsAIAgent(instructions: "Paso 2", name: "Paso2");
    Workflow wf = invertirCodigo ? AgentWorkflowBuilder.BuildSequential(paso2, paso1) : AgentWorkflowBuilder.BuildSequential(paso1, paso2);
    AIAgent comoAgente = wf.AsAIAgent();
    Console.WriteLine($"  tipo expuesto: {comoAgente.GetType().Name} es AIAgent = {comoAgente is AIAgent}");
    AgentSession s = await comoAgente.CreateSessionAsync();
    await comoAgente.RunAsync("Dame el resumen", s);
    return string.Join(" > ", bitacora.Where(b => b.StartsWith("modelo-llamado:")));
}

Console.WriteLine("PARTE 2 - workflow de MAF (BuildSequential) expuesto con AsAIAgent():");
Console.WriteLine("  codigo (paso1, paso2), corrida 1: " + await CorrerWorkflow(false));
Console.WriteLine("  codigo (paso1, paso2), corrida 2: " + await CorrerWorkflow(false));
Console.WriteLine("  codigo (paso2, paso1):            " + await CorrerWorkflow(true));

sealed class GuionChatClient(string nombre, string[] guion, List<string> bitacora) : IChatClient
{
    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
    {
        bitacora.Add($"modelo-llamado:{nombre}");
        int resultados = messages.SelectMany(m => m.Contents).OfType<FunctionResultContent>().Count();
        if (resultados < guion.Length)
        {
            var call = new FunctionCallContent($"c{resultados}", guion[resultados]);
            return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, [call])));
        }
        return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, $"listo ({nombre})")));
    }

    public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var r = await GetResponseAsync(messages, options, cancellationToken);
        foreach (var u in r.ToChatResponseUpdates()) yield return u;
    }

    public object? GetService(Type serviceType, object? serviceKey = null) => serviceType.IsInstanceOfType(this) ? this : null;
    public void Dispose() { }
}
