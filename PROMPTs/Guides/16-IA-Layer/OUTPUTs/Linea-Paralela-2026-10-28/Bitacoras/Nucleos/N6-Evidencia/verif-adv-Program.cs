using System.ComponentModel;
using System.Reflection;
using CommunityToolkit.VectorData.InMemory;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using ModelContextProtocol.Server;
using MovilidadUrbana.ApiWeb.Application;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Application.Encuestas;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.ApiWeb.Domain;
using MovilidadUrbana.ApiWeb.Domain.Entities;

var repo = new RepoMem();
var localidadService = new LocalidadService(repo);
var encuestaService = new EncuestaService(new EncRepoMem());
var herramientas = new HerramientasDeLocalidad(localidadService);

// ---- 4.1 + 4.6 ----
var fake = new GuionChatClient(new FunctionCallContent("c1", "agregar_localidad",
    new Dictionary<string, object?> { ["nombre"] = "Goya", ["provincia"] = "Corrientes", ["codigoPostal"] = "34", ["habitantes"] = 89959 }));
IChatClient chat = fake.AsBuilder().UseFunctionInvocation().Build();
var options = new ChatOptions { Tools = herramientas.Crear() };
ChatResponse resp = await chat.GetResponseAsync("Agregá Goya", options);
Console.WriteLine($"[4.1] visto: {fake.ResultadosVistos.Single()}");
Console.WriteLine($"[4.6] localidades: {(await localidadService.GetAllAsync()).Count}");

// ---- 4.2 ----
var chat2 = new GuionChatClient(textoFinal: "{\"medios\":[\"colectivo\",\"avion\"],\"frecuencia\":\"diaria\"}");
string textoDelUsuario = "bondi y avión";
ChatResponse<EncuestaPaso2Propuesta> r = await chat2.GetResponseAsync<EncuestaPaso2Propuesta>(
    $"Extraé los medios de transporte y la frecuencia. Medios válidos: " +
    $"{string.Join(", ", Catalogos.Medios.Select(m => m.Clave))}. Frecuencias válidas: " +
    $"{string.Join(", ", Catalogos.Frecuencias.Select(f => f.Clave))}.\nTexto: {textoDelUsuario}");
var desconocidos = r.Result.Medios.Where(m => !Catalogos.Medios.Any(c => c.Clave == m)).ToList();
var model = new EncuestaModel { Frecuencia = r.Result.Frecuencia };
foreach (var m in r.Result.Medios.Except(desconocidos)) model.AlternarMedio(m, elegido: true);
var errores = new Dictionary<string, string>(encuestaService.ValidarPaso(2, model));
if (desconocidos.Count > 0) errores["medios"] = $"Medios fuera del catálogo: {string.Join(", ", desconocidos)}";
Console.WriteLine($"[4.2] errores: {string.Join("; ", errores.Select(e => e.Key + "=" + e.Value))}");

// ---- 4.3 ----
IEmbeddingGenerator<string, Embedding<float>> embeddings = new HashEmb(384);
var contexto = new System.Text.StringBuilder(); string pregunta = "dígitos del código postal";
var store = new InMemoryVectorStore(new() { EmbeddingGenerator = embeddings });
var col = store.GetCollection<string, Fragmento>("ayuda");
await col.EnsureCollectionExistsAsync();
await col.UpsertAsync([
    new() { Id = "loc-cp",   Fuente = "LocalidadPolicy.RequisitoDelCodigoPostal", Texto = LocalidadPolicy.RequisitoDelCodigoPostal, Embedding = "Código postal: " + LocalidadPolicy.RequisitoDelCodigoPostal },
    new() { Id = "enc-edad", Fuente = "EncuestaPolicy.RequisitoDeLaEdad",        Texto = EncuestaPolicy.RequisitoDeLaEdad,        Embedding = "Edad: " + EncuestaPolicy.RequisitoDeLaEdad },
]);
await foreach (var hit in col.SearchAsync(pregunta, top: 3))
    contexto.AppendLine($"[{hit.Record.Fuente}] {hit.Record.Texto}");
Console.WriteLine($"[4.3] {contexto.ToString().Replace("\n", " | ")}");

// ---- 4.4 ----
bool aprobado = false;
IChatClient chatClient = new GuionChatClient(new FunctionCallContent("d1", "eliminar_localidad", new Dictionary<string, object?> { ["id"] = 2 }));
AIFunction baja = new ApprovalRequiredAIFunction(
    AIFunctionFactory.Create((int id) => localidadService.DeleteAsync(id), "eliminar_localidad",
        "Elimina una localidad por Id. Requiere aprobación de la persona."));
AIAgent agente = chatClient.AsAIAgent(instructions: "Asistente del ABM de localidades.", tools: [baja]);
AgentSession session = await agente.CreateSessionAsync();
AgentResponse aresp = await agente.RunAsync("Borrá Resistencia", session);
var pedido = aresp.Messages.SelectMany(m => m.Contents).OfType<ToolApprovalRequestContent>().FirstOrDefault();
Console.WriteLine($"[4.4] pedido de aprobación: {pedido is not null}; localidades: {(await localidadService.GetAllAsync()).Count}");
if (pedido is not null)
    aresp = await agente.RunAsync(new ChatMessage(ChatRole.User, [pedido.CreateResponse(aprobado)]), session);
Console.WriteLine($"[4.4] tras rechazo: localidades: {(await localidadService.GetAllAsync()).Count}");

// ---- 4.5 (sólo compilación del registro) ----
var wb = WebApplication.CreateBuilder();
wb.Services.AddMcpServer().WithHttpTransport(o => o.SessionMode = ModelContextProtocol.AspNetCore.HttpServerSessionMode.Stateless).WithTools<LocalidadMcpTools>();
var app = wb.Build();
app.MapMcp("/mcp");
Console.WriteLine("[4.5] compila");

// ---- reflexión ----
foreach (var t in new[] { typeof(ApprovalRequiredAIFunction), typeof(ToolApprovalRequestContent), typeof(ToolApprovalResponseContent), typeof(InMemoryVectorStore) })
    Console.WriteLine($"[R] {t.FullName} attrs: {string.Join(",", t.GetCustomAttributesData().Select(a => a.AttributeType.Name + "(" + string.Join(",", a.ConstructorArguments.Select(c => c.Value)) + ")"))}");
foreach (var m in typeof(AIAgent).Assembly.GetExportedTypes().SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.Static)).Where(m => m.Name == "AsAIAgent"))
    Console.WriteLine($"[R] {m.DeclaringType!.Name}.AsAIAgent({string.Join(", ", m.GetParameters().Select(p => p.ParameterType.Name + " " + p.Name))})");

// ================= tipos =================
public sealed record EncuestaPaso2Propuesta(string[] Medios, string Frecuencia);
public sealed class HerramientasDeLocalidad(LocalidadService service)
{
    [Description("Da de alta una localidad. Devuelve el resultado de la validación del dominio.")]
    public async Task<object> AgregarAsync(
        [Description("Nombre de la localidad")] string nombre,
        [Description("Una de: Buenos Aires, Chaco, Córdoba, Corrientes, Entre Ríos, Mendoza, Santa Fe")] string provincia,
        [Description("Código postal de 4 dígitos")] string codigoPostal,
        [Description("Cantidad de habitantes, entero ≥ 1")] int habitantes)
    {
        Result r = await service.SaveAsync(new LocalidadModel
            { Nombre = nombre, Provincia = provincia, CodigoPostal = codigoPostal, Habitantes = habitantes });
        return new { r.IsSuccess, r.Message, r.Errors };
    }
    public IList<AITool> Crear() => [AIFunctionFactory.Create(AgregarAsync, "agregar_localidad")];
}
[McpServerToolType]
public sealed class LocalidadMcpTools
{
    [McpServerTool(Name = "listar_localidades"), Description("Lista las localidades cargadas")]
    public static Task<IReadOnlyList<Localidad>> Listar(LocalidadService service, CancellationToken ct)
        => service.GetAllAsync(ct);
}
public sealed class Fragmento
{
    [VectorStoreKey] public string Id { get; set; } = "";
    [VectorStoreData] public string Fuente { get; set; } = "";
    [VectorStoreData] public string Texto { get; set; } = "";
    [VectorStoreVector(384)] public string Embedding { get; set; } = "";
}
public sealed class RepoMem : ILocalidadRepository
{
    private readonly List<Localidad> _l = [new() { Id = 1, Nombre = "Corrientes", Provincia = "Corrientes", CodigoPostal = "3400", Habitantes = 346334 }, new() { Id = 2, Nombre = "Resistencia", Provincia = "Chaco", CodigoPostal = "3500", Habitantes = 291720 }];
    public Task<IReadOnlyList<Localidad>> GetAllAsync(CancellationToken c = default) => Task.FromResult<IReadOnlyList<Localidad>>(_l.ToList());
    public Task<Localidad?> GetByIdAsync(int id, CancellationToken c = default) => Task.FromResult(_l.FirstOrDefault(x => x.Id == id));
    public Task<int> AddAsync(Localidad l, CancellationToken c = default) { l.Id = _l.Max(x => x.Id) + 1; _l.Add(l); return Task.FromResult(l.Id); }
    public Task UpdateAsync(Localidad l, CancellationToken c = default) => Task.CompletedTask;
    public Task DeleteAsync(int id, CancellationToken c = default) { _l.RemoveAll(x => x.Id == id); return Task.CompletedTask; }
}
public sealed class EncRepoMem : IEncuestaRepository
{
    public Task<int> AddAsync(RespuestaDeEncuesta r, CancellationToken c = default) => Task.FromResult(1);
    public Task<int> CountAsync(CancellationToken c = default) => Task.FromResult(0);
}
public sealed class GuionChatClient(params FunctionCallContent[] llamadas) : IChatClient
{
    private readonly Queue<FunctionCallContent> _q = new(llamadas);
    private readonly string? _final;
    public List<string> ResultadosVistos { get; } = [];
    public GuionChatClient(string textoFinal) : this() => _final = textoFinal;
    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken ct = default)
    {
        var last = messages.Last();
        foreach (var fr in last.Contents.OfType<FunctionResultContent>()) ResultadosVistos.Add($"{fr.CallId}={System.Text.Json.JsonSerializer.Serialize(fr.Result)}");
        if (_q.Count > 0) return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, [_q.Dequeue()])));
        return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, _final ?? "Listo.")));
    }
    public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
    { foreach (var u in (await GetResponseAsync(messages, options, ct)).ToChatResponseUpdates()) yield return u; }
    public object? GetService(Type serviceType, object? serviceKey = null) => serviceType.IsInstanceOfType(this) ? this : null;
    public void Dispose() { }
}
public sealed class HashEmb(int dims) : IEmbeddingGenerator<string, Embedding<float>>
{
    public Task<GeneratedEmbeddings<Embedding<float>>> GenerateAsync(IEnumerable<string> values, EmbeddingGenerationOptions? o = null, CancellationToken ct = default)
        => Task.FromResult(new GeneratedEmbeddings<Embedding<float>>(values.Select(v => {
            var vec = new float[dims];
            foreach (var w in System.Text.RegularExpressions.Regex.Split(v.ToLowerInvariant(), @"\W+").Where(w => w.Length > 2)) vec[(int)((uint)w.GetHashCode() % dims)] += 1;
            var n = MathF.Sqrt(vec.Sum(x => x * x)); if (n > 0) for (int i = 0; i < dims; i++) vec[i] /= n;
            return new Embedding<float>(vec); })));
    public object? GetService(Type t, object? k = null) => null;
    public void Dispose() { }
}
