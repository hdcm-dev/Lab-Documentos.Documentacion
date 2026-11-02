using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using CommunityToolkit.VectorData.InMemory;
using CommunityToolkit.VectorData.SqliteVec;
using Microsoft.Agents.AI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using ModelContextProtocol.Client;
using ModelContextProtocol.Server;

// ---------- 1. EF Core SQLite 10 + SqliteVec en el mismo proceso ----------
File.Delete("/work/datos.db"); File.Delete("/work/vectores.db");
var services = new ServiceCollection();
services.AddDbContextFactory<AppDb>(o => o.UseSqlite("Data Source=/work/datos.db"));
services.AddScoped<LocalidadService>();
var sp = services.BuildServiceProvider();
using (var db = sp.GetRequiredService<IDbContextFactory<AppDb>>().CreateDbContext())
{
    db.Database.EnsureCreated();
    db.Localidades.AddRange(new Localidad { Nombre = "Corrientes", Provincia = "Corrientes", CodigoPostal = "3400", Habitantes = 346334 },
                            new Localidad { Nombre = "Resistencia", Provincia = "Chaco", CodigoPostal = "3500", Habitantes = 291720 });
    db.SaveChanges();
    Console.WriteLine($"[1] EF Core SQLite: {db.Localidades.Count()} localidades");
}
foreach (var a in AppDomain.CurrentDomain.GetAssemblies().Where(a => a.GetName().Name!.StartsWith("SQLitePCLRaw")).OrderBy(a => a.GetName().Name))
    Console.WriteLine($"[1] {a.GetName().Name} {a.GetName().Version}");
var gen = new HashEmbeddingGenerator(64);
var vstore = new SqliteVectorStore("Data Source=/work/vectores.db;Pooling=false", new() { EmbeddingGenerator = gen });
var col = vstore.GetCollection<string, Fragmento>("ayuda");
await col.EnsureCollectionExistsAsync();
await col.UpsertAsync([
  new Fragmento { Id = "pol-cp", Fuente = "LocalidadPolicy.RequisitoDelCodigoPostal", Texto = "El código postal tiene 4 dígitos.", Embedding = "código postal tiene 4 dígitos" },
  new Fragmento { Id = "pol-edad", Fuente = "EncuestaPolicy.RequisitoDeLaEdad", Texto = "La edad va entre 16 y 110 años.", Embedding = "edad entre 16 y 110 años" }]);
await foreach (var r in col.SearchAsync("cuántos dígitos lleva el código postal", top: 1))
    Console.WriteLine($"[1] SqliteVec top1 = {r.Record.Id} ({r.Record.Fuente})");
using (var db = sp.GetRequiredService<IDbContextFactory<AppDb>>().CreateDbContext())
    Console.WriteLine($"[1] EF Core sigue operativo tras sqlite-vec: {db.Localidades.Count()} localidades");

// ---------- 2. Tool calling sobre un caso de uso: el modelo propone, el dominio decide ----------
using (var scope = sp.CreateScope())
{
    var svc = scope.ServiceProvider.GetRequiredService<LocalidadService>();
    var tools = new List<AITool> {
        AIFunctionFactory.Create(svc.ListarAsync, "listar_localidades", "Lista las localidades cargadas"),
        AIFunctionFactory.Create(svc.AgregarAsync, "agregar_localidad", "Da de alta una localidad; valida las reglas del dominio") };
    var fake = new GuionChatClient(
        new FunctionCallContent("c1", "agregar_localidad", new Dictionary<string, object?> { ["nombre"] = "Goya", ["provincia"] = "Corrientes", ["codigoPostal"] = "34", ["habitantes"] = 89959 }),
        new FunctionCallContent("c2", "agregar_localidad", new Dictionary<string, object?> { ["nombre"] = "Goya", ["provincia"] = "Corrientes", ["codigoPostal"] = "3450", ["habitantes"] = 89959 }));
    IChatClient chat = fake.AsBuilder().UseFunctionInvocation().Build();
    var resp = await chat.GetResponseAsync("Agregá Goya, Corrientes, CP 34, 89959 habitantes", new ChatOptions { Tools = tools });
    foreach (var fr in fake.ResultadosVistos) Console.WriteLine($"[2] resultado de herramienta visto por el modelo: {fr}");
    Console.WriteLine($"[2] respuesta final: {resp.Text}");
    Console.WriteLine($"[2] localidades en base: {(await svc.ListarAsync()).Count}");
    Console.WriteLine($"[2] ApprovalRequiredAIFunction existe: {typeof(AIFunction).Assembly.GetType("Microsoft.Extensions.AI.ApprovalRequiredAIFunction") is not null}");
}

// ---------- 3. Extracción estructurada + validación por reglas ----------
var extractor = new GuionChatClient(textoFinal: "{\"nombre\":\"Bella Vista\",\"provincia\":\"Corrientes\",\"codigoPostal\":\"3432\",\"habitantes\":0}");
var prop = await extractor.GetResponseAsync<LocalidadPropuesta>("En Bella Vista (Corrientes, CP 3432) no sé cuántos viven");
Console.WriteLine($"[3] propuesta tipada: {prop.Result}");
Console.WriteLine($"[3] errores de dominio: {string.Join("; ", LocalidadRules.Validar(prop.Result))}");

// ---------- 4. Agente MAF sobre el mismo IChatClient ----------
AIAgent agente = new GuionChatClient(textoFinal: "Hay 3 localidades.").AsAIAgent(instructions: "Respondé sobre localidades.", name: "AsistenteMovilidad");
Console.WriteLine($"[4] agente {agente.Name}: {await agente.RunAsync("¿Cuántas localidades hay?")}");

// ---------- 5. Servidor MCP HTTP con herramientas que reciben servicios por DI ----------
var wb = WebApplication.CreateBuilder();
wb.Logging.ClearProviders();
wb.Services.AddDbContextFactory<AppDb>(o => o.UseSqlite("Data Source=/work/datos.db"));
wb.Services.AddScoped<LocalidadService>();
wb.Services.AddMcpServer().WithHttpTransport(o => o.Stateless = true).WithTools<LocalidadMcpTools>();
wb.WebHost.UseUrls("http://127.0.0.1:5077");
var app = wb.Build();
app.MapMcp("/mcp");
await app.StartAsync();
var url = app.Urls.First();
await using (var mcp = await McpClient.CreateAsync(new HttpClientTransport(new HttpClientTransportOptions { Endpoint = new Uri(url + "/mcp") })))
{
    var mtools = await mcp.ListToolsAsync();
    Console.WriteLine($"[5] herramientas MCP: {string.Join(", ", mtools.Select(t => t.Name))}");
    var res = await mcp.CallToolAsync("listar_localidades", new Dictionary<string, object?>());
    Console.WriteLine($"[5] listar_localidades → {JsonSerializer.Serialize(res.Content.Select(c => (c as ModelContextProtocol.Protocol.TextContentBlock)?.Text))}");
    Console.WriteLine($"[5] McpClientTool es AIFunction: {mtools[0] is AIFunction}");
}
await app.StopAsync();

// ================= tipos =================
public class Localidad { public int Id { get; set; } public string Nombre { get; set; } = ""; public string Provincia { get; set; } = ""; public string CodigoPostal { get; set; } = ""; public int Habitantes { get; set; } }
public class AppDb(DbContextOptions<AppDb> o) : DbContext(o) { public DbSet<Localidad> Localidades => Set<Localidad>(); }
public record LocalidadPropuesta(string Nombre, string Provincia, string CodigoPostal, int Habitantes);
public static class LocalidadRules
{
    public static IEnumerable<string> Validar(LocalidadPropuesta p)
    {
        if ((p.Nombre ?? "").Trim().Length < 3) yield return "nombre: El nombre debe tener al menos 3 caracteres.";
        if (string.IsNullOrWhiteSpace(p.Provincia)) yield return "provincia: Seleccione una provincia.";
        if (!Regex.IsMatch((p.CodigoPostal ?? "").Trim(), @"^\d{4}$")) yield return "codigoPostal: El código postal debe tener 4 dígitos.";
        if (p.Habitantes < 1) yield return "habitantes: Ingrese una cantidad de habitantes mayor a cero.";
    }
}
public sealed class LocalidadService(IDbContextFactory<AppDb> f)
{
    public async Task<IReadOnlyList<string>> ListarAsync()
    { await using var db = await f.CreateDbContextAsync(); return await db.Localidades.Select(l => l.Nombre + " (" + l.Provincia + ")").ToListAsync(); }
    public async Task<string> AgregarAsync(string nombre, string provincia, string codigoPostal, int habitantes)
    {
        var errores = LocalidadRules.Validar(new(nombre, provincia, codigoPostal, habitantes)).ToList();
        if (errores.Count > 0) return "INVALIDO: " + string.Join("; ", errores);
        await using var db = await f.CreateDbContextAsync();
        db.Localidades.Add(new Localidad { Nombre = nombre.Trim(), Provincia = provincia, CodigoPostal = codigoPostal.Trim(), Habitantes = habitantes });
        await db.SaveChangesAsync(); return $"Se agregó la localidad {nombre.Trim()}.";
    }
}
[McpServerToolType]
public sealed class LocalidadMcpTools
{
    [McpServerTool(Name = "listar_localidades"), Description("Lista las localidades cargadas")]
    public static Task<IReadOnlyList<string>> Listar(LocalidadService service) => service.ListarAsync();
}
public class Fragmento
{
    [VectorStoreKey] public string Id { get; set; }
    [VectorStoreData] public string Fuente { get; set; }
    [VectorStoreData] public string Texto { get; set; }
    [VectorStoreVector(64)] public string Embedding { get; set; }
}
/// Cliente falso: emite las llamadas a herramienta del guion, una por turno, y después texto.
public sealed class GuionChatClient(params FunctionCallContent[] llamadas) : IChatClient
{
    private readonly Queue<FunctionCallContent> _q = new(llamadas);
    private readonly string? _final;
    public List<string> ResultadosVistos { get; } = [];
    public GuionChatClient(string textoFinal) : this() => _final = textoFinal;
    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken ct = default)
    {
        var last = messages.Last();
        foreach (var fr in last.Contents.OfType<FunctionResultContent>()) ResultadosVistos.Add($"{fr.CallId}={fr.Result}");
        if (_q.Count > 0) return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, [_q.Dequeue()])));
        return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, _final ?? "Listo.")));
    }
    public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
    { foreach (var u in (await GetResponseAsync(messages, options, ct)).ToChatResponseUpdates()) yield return u; }
    public object? GetService(Type serviceType, object? serviceKey = null) => serviceType.IsInstanceOfType(this) ? this : null;
    public void Dispose() { }
}
public sealed class HashEmbeddingGenerator(int dims) : IEmbeddingGenerator<string, Embedding<float>>
{
    public Task<GeneratedEmbeddings<Embedding<float>>> GenerateAsync(IEnumerable<string> values, EmbeddingGenerationOptions? o = null, CancellationToken ct = default)
        => Task.FromResult(new GeneratedEmbeddings<Embedding<float>>(values.Select(v => {
            var vec = new float[dims];
            foreach (var w in Regex.Split(v.ToLowerInvariant(), @"\W+").Where(w => w.Length > 2)) vec[(int)((uint)w.GetHashCode() % dims)] += 1;
            var n = MathF.Sqrt(vec.Sum(x => x * x)); if (n > 0) for (int i = 0; i < dims; i++) vec[i] /= n;
            return new Embedding<float>(vec); })));
    public object? GetService(Type t, object? k = null) => null;
    public void Dispose() { }
}
