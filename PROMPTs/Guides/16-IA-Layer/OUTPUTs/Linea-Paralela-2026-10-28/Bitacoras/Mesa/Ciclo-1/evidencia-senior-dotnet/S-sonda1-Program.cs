// Sonda Senior .NET (mesa ciclo 1, guía 16, 2026-10-28). Sin modelo: IChatClient guionado.
// [S1] Orden del pipeline: ¿qué spans se ven con UseOpenTelemetry por fuera vs. por dentro de UseFunctionInvocation?
// [S2] AddChatClient Scoped con fábrica que crea OllamaApiClient: ¿un HttpClient nuevo por scope? Alternativa: interno Singleton por clave.
// [S3] Reflexión: TypedResults.ServerSentEvents (ASP.NET Core 10), AIAgent.SerializeSessionAsync/DeserializeSessionAsync (MAF 1.26.0),
//      VectorStoreVectorAttribute (constructor: ¿dimensión sólo como constante?).
using System.Diagnostics;
using System.Reflection;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using OllamaSharp;

const string S = "MovilidadUrbana.AI";
Console.WriteLine($"# SDK runtime {Environment.Version}; MEAI {typeof(IChatClient).Assembly.GetName().Version}; OllamaSharp {typeof(OllamaApiClient).Assembly.GetName().Version}; MAF {typeof(AIAgent).Assembly.GetName().Version}");

// ---------- [S1] ----------
var spans = new List<string>();
using var al = new ActivityListener { ShouldListenTo = s => s.Name == S, Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
    ActivityStopped = a => spans.Add($"{a.OperationName}|{a.DisplayName}|parent={(a.Parent?.OperationName ?? "-")}") };
ActivitySource.AddActivityListener(al);
var herramienta = AIFunctionFactory.Create((string provincia) => provincia == "Corrientes" ? 2 : 0, "contar_localidades_por_provincia");
foreach (var (rotulo, armar) in new (string, Func<IChatClient, IChatClient>)[] {
    ("OTel afuera (orden de BIT-16-04 §6.2): UseOpenTelemetry → UseFunctionInvocation → cliente", c => c.AsBuilder().UseOpenTelemetry(sourceName: S).UseFunctionInvocation().Build()),
    ("OTel adentro: UseFunctionInvocation → UseOpenTelemetry → cliente", c => c.AsBuilder().UseFunctionInvocation().UseOpenTelemetry(sourceName: S).Build()) })
{
    spans.Clear();
    var cliente = armar(new Guion());
    var r = await cliente.GetResponseAsync("¿Cuántas localidades hay en Corrientes?", new ChatOptions { Tools = [herramienta] });
    Console.WriteLine($"[S1] {rotulo}\n      respuesta=«{r.Text}»; spans de «{S}» = {spans.Count}");
    foreach (var s in spans) Console.WriteLine($"        {s}");
}

// ---------- [S2] ----------
static HttpClient? HttpDe(OllamaApiClient c)
{
    foreach (var f in typeof(OllamaApiClient).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
        if (typeof(HttpClient).IsAssignableFrom(f.FieldType)) return (HttpClient?)f.GetValue(c);
    return null;
}
{
    var sc = new ServiceCollection();
    sc.AddChatClient(_ => new OllamaApiClient(new Uri("http://localhost:11434"), "modelo"), ServiceLifetime.Scoped).UseFunctionInvocation();
    using var root = sc.BuildServiceProvider(new ServiceProviderOptions { ValidateScopes = true });
    var vistos = new List<(OllamaApiClient o, HttpClient? h)>();
    for (int i = 0; i < 3; i++) { using var scope = root.CreateScope(); var o = scope.ServiceProvider.GetRequiredService<IChatClient>().GetService<OllamaApiClient>()!; vistos.Add((o, HttpDe(o))); }
    Console.WriteLine($"[S2] AddChatClient(fábrica con new OllamaApiClient(Uri), Scoped), 3 scopes → OllamaApiClient distintos = {vistos.Select(v => v.o).Distinct().Count()}; HttpClient distintos = {vistos.Select(v => v.h).Where(h => h is not null).Distinct().Count()}; timeout del HttpClient = {vistos[0].h?.Timeout}");
}
{
    var sc = new ServiceCollection();
    sc.AddScoped<SesionDePrueba>();
    sc.AddHttpClient("ollama", h => { h.BaseAddress = new Uri("http://localhost:11434"); h.Timeout = TimeSpan.FromMinutes(3); });
    sc.AddKeyedSingleton<IChatClient>("ollama-interno", (sp, _) => new OllamaApiClient(sp.GetRequiredService<IHttpClientFactory>().CreateClient("ollama"), "modelo"));
    sc.AddChatClient(sp => sp.GetRequiredKeyedService<IChatClient>("ollama-interno"), ServiceLifetime.Scoped).UseFunctionInvocation();
    using var root = sc.BuildServiceProvider(new ServiceProviderOptions { ValidateScopes = true });
    var quienSoy = AIFunctionFactory.Create((AIFunctionArguments a) => a.Services!.GetRequiredService<SesionDePrueba>().Id, "quien_soy");
    var internos = new List<OllamaApiClient>();
    foreach (var sesion in new[] { "sesion-A", "sesion-B" })
    {
        using var scope = root.CreateScope();
        scope.ServiceProvider.GetRequiredService<SesionDePrueba>().Id = sesion;
        var chat = scope.ServiceProvider.GetRequiredService<IChatClient>();
        internos.Add(chat.GetService<OllamaApiClient>()!);
        // Sustituyo el interno por el guion sólo para ejecutar la herramienta: se arma igual que arriba, con la clave apuntando al guion.
    }
    Console.WriteLine($"[S2] Interno Singleton por clave + IHttpClientFactory, externo Scoped → OllamaApiClient distintos en 2 scopes = {internos.Distinct().Count()}; timeout = {HttpDe(internos[0])?.Timeout}");
    var sc2 = new ServiceCollection();
    sc2.AddScoped<SesionDePrueba>();
    sc2.AddKeyedSingleton<IChatClient>("interno", (_, _) => new Guion());
    sc2.AddChatClient(sp => sp.GetRequiredKeyedService<IChatClient>("interno"), ServiceLifetime.Scoped).UseFunctionInvocation();
    using var root2 = sc2.BuildServiceProvider(new ServiceProviderOptions { ValidateScopes = true });
    foreach (var sesion in new[] { "sesion-A", "sesion-B" })
    {
        using var scope = root2.CreateScope();
        scope.ServiceProvider.GetRequiredService<SesionDePrueba>().Id = sesion;
        var r = await scope.ServiceProvider.GetRequiredService<IChatClient>().GetResponseAsync("¿quién soy?", new ChatOptions { Tools = [quienSoy] });
        Console.WriteLine($"[S2] Mismo patrón con el guion como interno Singleton, scope {sesion} → la herramienta vio: {r.Text}");
    }
}

// ---------- [S3] ----------
var tr = Type.GetType("Microsoft.AspNetCore.Http.TypedResults, Microsoft.AspNetCore.Http.Results");
var sse = tr?.GetMethods().Where(m => m.Name == "ServerSentEvents").Select(m => $"{m.Name}<{string.Join(",", m.GetGenericArguments().Select(g => g.Name))}>({string.Join(", ", m.GetParameters().Select(p => p.ParameterType.Name + " " + p.Name))})").ToList();
Console.WriteLine($"[S3] TypedResults.ServerSentEvents en {tr?.Assembly.GetName().Version}: {(sse is { Count: > 0 } ? string.Join(" | ", sse) : "NO EXISTE")}");
foreach (var n in new[] { "SerializeSessionAsync", "DeserializeSessionAsync" })
    foreach (var m in typeof(AIAgent).GetMethods().Where(m => m.Name == n))
        Console.WriteLine($"[S3] AIAgent.{n}({string.Join(", ", m.GetParameters().Select(p => p.ParameterType.Name + " " + p.Name))}) → {m.ReturnType.Name}{(m.ReturnType.IsGenericType ? "<" + string.Join(",", m.ReturnType.GetGenericArguments().Select(g => g.Name)) + ">" : "")}");
foreach (var c in typeof(VectorStoreVectorAttribute).GetConstructors())
    Console.WriteLine($"[S3] VectorStoreVectorAttribute({string.Join(", ", c.GetParameters().Select(p => p.ParameterType.Name + " " + p.Name))})");
foreach (var c in typeof(VectorStoreVectorProperty).GetConstructors())
    Console.WriteLine($"[S3] VectorStoreVectorProperty({string.Join(", ", c.GetParameters().Select(p => p.ParameterType.Name + " " + p.Name))})");

sealed class SesionDePrueba { public string Id { get; set; } = "(vacía)"; }

// Guion: sin resultado de herramienta y con herramientas → pide la primera; con resultado → lo devuelve como texto.
sealed class Guion : IChatClient
{
    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken ct = default)
    {
        var res = messages.SelectMany(m => m.Contents).OfType<FunctionResultContent>().LastOrDefault();
        if (res is null && options?.Tools is { Count: > 0 } t)
        {
            var args = t[0].Name == "contar_localidades_por_provincia" ? new Dictionary<string, object?> { ["provincia"] = "Corrientes" } : null;
            return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, [new FunctionCallContent("c1", t[0].Name, args)])));
        }
        return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, res?.Result?.ToString() ?? "sin herramienta")) { ModelId = "guion" });
    }
    public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
    { foreach (var u in (await GetResponseAsync(messages, options, ct)).ToChatResponseUpdates()) yield return u; }
    public object? GetService(Type t, object? k = null) => t.IsInstanceOfType(this) ? this : null;
    public void Dispose() { }
}
