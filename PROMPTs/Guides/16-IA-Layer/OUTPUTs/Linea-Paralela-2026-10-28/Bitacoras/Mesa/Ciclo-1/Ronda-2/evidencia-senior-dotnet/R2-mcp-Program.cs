// PC-01: AllowedHosts y RequireAuthorization() sobre MapMcp (ModelContextProtocol.AspNetCore 2.3.0).
// PC-09: una única definición de herramienta servida al bucle IChatClient / Agent Framework y al servidor MCP.
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Agents.AI;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Options;
using ModelContextProtocol.Client;
using ModelContextProtocol.Server;

Console.WriteLine($"# MCP.AspNetCore {typeof(Microsoft.AspNetCore.Builder.McpEndpointRouteBuilderExtensions).Assembly.GetName().Version}; MCP {typeof(McpServerTool).Assembly.GetName().Version}; MEAI {typeof(IChatClient).Assembly.GetName().Version}; MAF {typeof(AIAgent).Assembly.GetName().Version}; runtime {Environment.Version}\n");

// ---------- La definición única ----------
// Fuente de verdad: un AIFunction por herramienta, creado por reflexión sobre un método de una clase con dependencias Scoped.
// El bucle la usa tal cual; el servidor MCP la envuelve con McpServerTool.Create(AIFunction).
static IReadOnlyList<AIFunction> CatalogoDeHerramientas() =>
[
    AIFunctionFactory.Create(
        typeof(HerramientasDeLectura).GetMethod(nameof(HerramientasDeLectura.ContarPorMedio))!,
        args => ActivatorUtilities.CreateInstance<HerramientasDeLectura>(args.Services!),
        new AIFunctionFactoryOptions { Name = "contar_por_medio" }),
];

async Task<(WebApplication app, string url)> Levantar(string allowedHosts, bool exigirAuth, bool validarOrigin = false)
{
    var b = WebApplication.CreateBuilder();
    b.Logging.ClearProviders();
    b.WebHost.UseUrls("http://127.0.0.1:0");                       // loopback por defecto (M13)
    b.Configuration["AllowedHosts"] = allowedHosts;                 // lo lee el HostFiltering que CreateBuilder ya registra
    b.Configuration["Mcp:Token"] = "token-de-prueba";
    b.Configuration["Mcp:OrigenesPermitidos"] = "http://localhost:5000";
    b.Services.AddScoped<SessionContext>();
    b.Services.AddSingleton<IEncuestaLectura, EncuestaFalsa>();
    b.Services.AddAuthentication("TokenDemo").AddScheme<AuthenticationSchemeOptions, TokenDemoHandler>("TokenDemo", null);
    b.Services.AddAuthorization();
    b.Services.AddMcpServer()
        .WithHttpTransport(o => o.Stateless = true)
        .WithTools(CatalogoDeHerramientas().Select(f => McpServerTool.Create(f, new McpServerToolCreateOptions { ReadOnly = true })));
    var app = b.Build();
    app.Use(async (ctx, next) => { ctx.RequestServices.GetRequiredService<SessionContext>().SessionId = ctx.Request.Headers["X-Sesion-Id"].FirstOrDefault() ?? "(sin sesión)"; await next(); });
    if (validarOrigin)   // MCP 2025-06-18 «Servers MUST validate the Origin header»: el SDK 2.3.0 no lo hace (caso [C])
        app.UseWhen(c => c.Request.Path.StartsWithSegments("/mcp"), rama => rama.Use(async (c, next) =>
        {
            var origin = c.Request.Headers.Origin.ToString();
            var permitidos = (c.RequestServices.GetRequiredService<IConfiguration>()["Mcp:OrigenesPermitidos"] ?? "").Split(';', StringSplitOptions.RemoveEmptyEntries);
            if (origin.Length > 0 && !permitidos.Contains(origin, StringComparer.OrdinalIgnoreCase)) { c.Response.StatusCode = 403; return; }
            await next();
        }));
    app.UseAuthentication(); app.UseAuthorization();
    var ep = app.MapMcp("/mcp");
    if (exigirAuth) ep.RequireAuthorization();
    await app.StartAsync();
    var url = app.Services.GetRequiredService<IServer>().Features.Get<IServerAddressesFeature>()!.Addresses.First();
    return (app, url);
}

const string Init = "{\"jsonrpc\":\"2.0\",\"id\":1,\"method\":\"initialize\",\"params\":{\"protocolVersion\":\"2025-06-18\",\"capabilities\":{},\"clientInfo\":{\"name\":\"sonda\",\"version\":\"1\"}}}";
async Task<string> Post(string url, string? host = null, string? token = null, string? origin = null, string body = Init)
{
    using var hc = new HttpClient();
    var req = new HttpRequestMessage(HttpMethod.Post, url.TrimEnd('/') + "/mcp") { Content = new StringContent(body, Encoding.UTF8, "application/json") };
    req.Headers.Accept.ParseAdd("application/json"); req.Headers.Accept.ParseAdd("text/event-stream");
    if (host != null) req.Headers.Host = host;
    if (token != null) req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
    if (origin != null) req.Headers.Add("Origin", origin);
    var r = await hc.SendAsync(req);
    var txt = await r.Content.ReadAsStringAsync();
    var www = r.Headers.WwwAuthenticate.Count > 0 ? $" WWW-Authenticate: {r.Headers.WwwAuthenticate}" : "";
    return $"{(int)r.StatusCode}{www} «{(txt.Length > 90 ? txt[..90] + "…" : txt)}»";
}

// ---------- PC-01 ----------
Console.WriteLine("## PC-01");
var (a1, u1) = await Levantar("localhost;127.0.0.1", exigirAuth: true);
Console.WriteLine("[A] AllowedHosts=\"localhost;127.0.0.1\" + MapMcp(\"/mcp\").RequireAuthorization()");
Console.WriteLine("    Host 127.0.0.1, sin token          → " + await Post(u1));
Console.WriteLine("    Host 127.0.0.1, token incorrecto   → " + await Post(u1, token: "otro"));
Console.WriteLine("    Host 127.0.0.1, token correcto     → " + await Post(u1, token: "token-de-prueba"));
Console.WriteLine("    Host «atacante.example», token ok  → " + await Post(u1, host: "atacante.example", token: "token-de-prueba"));
Console.WriteLine("    Host localhost, token ok           → " + await Post(u1, host: "localhost", token: "token-de-prueba"));
var fuentes = a1.Services.GetRequiredService<EndpointDataSource>().Endpoints.OfType<RouteEndpoint>().Where(e => e.RoutePattern.RawText!.StartsWith("/mcp"));
foreach (var e in fuentes) Console.WriteLine($"    endpoint {e.RoutePattern.RawText} [{e.DisplayName}] IAuthorizeData={e.Metadata.GetOrderedMetadata<Microsoft.AspNetCore.Authorization.IAuthorizeData>().Count}");
await a1.StopAsync();

var (a2, u2) = await Levantar("*", exigirAuth: false);
Console.WriteLine("[B] Control: AllowedHosts=\"*\" y sin RequireAuthorization (lo que hace N6 §4.5 hoy)");
Console.WriteLine("    Host «atacante.example», sin token → " + await Post(u2, host: "atacante.example"));
Console.WriteLine("    + Origin «http://atacante.example» → " + await Post(u2, host: "atacante.example", origin: "http://atacante.example"));
await a2.StopAsync();

var (a3, u3) = await Levantar("localhost;127.0.0.1", exigirAuth: false);
Console.WriteLine("[C] AllowedHosts restringido, sin auth: Origin ajeno con Host válido");
Console.WriteLine("    Host 127.0.0.1 + Origin «http://atacante.example» → " + await Post(u3, origin: "http://atacante.example"));
await a3.StopAsync();

var (a5, u5) = await Levantar("localhost;127.0.0.1", exigirAuth: true, validarOrigin: true);
Console.WriteLine("[G] AllowedHosts restringido + middleware de Origin + RequireAuthorization");
Console.WriteLine("    Host 127.0.0.1 + Origin ajeno + token ok        → " + await Post(u5, origin: "http://atacante.example", token: "token-de-prueba"));
Console.WriteLine("    Host 127.0.0.1 + Origin permitido + token ok    → " + await Post(u5, origin: "http://localhost:5000", token: "token-de-prueba"));
Console.WriteLine("    Host 127.0.0.1 sin Origin (cliente no navegador) + token ok → " + await Post(u5, token: "token-de-prueba"));
await a5.StopAsync();

var ext = typeof(Microsoft.Extensions.DependencyInjection.HttpMcpServerBuilderExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static).Select(m => m.Name).Distinct();
Console.WriteLine($"[D] HttpMcpServerBuilderExtensions: {string.Join(", ", ext)}");
var ext2 = typeof(Microsoft.Extensions.DependencyInjection.McpAuthenticationExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static).Select(m => m.Name + "(" + string.Join(",", m.GetParameters().Select(p => p.ParameterType.Name)) + ")").Distinct();
Console.WriteLine($"[E] McpAuthenticationExtensions: {string.Join(", ", ext2)}");
var ext3 = typeof(McpServerTool).Assembly.GetTypes().Concat(typeof(Microsoft.Extensions.DependencyInjection.HttpMcpServerBuilderExtensions).Assembly.GetTypes()).Concat(AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().Name == "ModelContextProtocol").SelectMany(x => x.GetTypes()))
    .Where(t => t.IsPublic).SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.Static)).Where(m => m.Name.Contains("Authoriz")).Select(m => m.DeclaringType!.Name + "." + m.Name).Distinct();
Console.WriteLine($"[F] métodos públicos con «Authoriz» en los ensamblados MCP: {string.Join(", ", ext3)}");

// ---------- PC-09 ----------
Console.WriteLine("\n## PC-09");
var (a4, u4) = await Levantar("localhost;127.0.0.1", exigirAuth: false);
// (1) Lado MCP: un cliente MCP real por HTTP
await using (var mcp = await McpClient.CreateAsync(new HttpClientTransport(new HttpClientTransportOptions
{ Endpoint = new Uri(u4.TrimEnd('/') + "/mcp"), TransportMode = HttpTransportMode.StreamableHttp, AdditionalHeaders = new Dictionary<string, string> { ["X-Sesion-Id"] = "sesion-MCP" } })))
{
    var tools = await mcp.ListToolsAsync();
    foreach (var t in tools) Console.WriteLine($"[A] MCP tools/list: name={t.Name} description=«{t.Description}» readOnlyHint={t.ProtocolTool.Annotations?.ReadOnlyHint}\n      inputSchema={JsonSerializer.Serialize(t.ProtocolTool.InputSchema)}");
    var res = await mcp.CallToolAsync("contar_por_medio", new Dictionary<string, object?> { ["medio"] = "caminata" });
    Console.WriteLine($"[B] MCP tools/call contar_por_medio(caminata) → {string.Join(" ", res.Content.OfType<ModelContextProtocol.Protocol.TextContentBlock>().Select(c => c.Text))}");
}
// (2) Lado bucle: la misma definición, en un scope de la app
var f = CatalogoDeHerramientas()[0];
Console.WriteLine($"[C] AIFunction: name={f.Name} description=«{f.Description}»\n      JsonSchema={f.JsonSchema.GetRawText()}");
using (var scope = a4.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<SessionContext>().SessionId = "sesion-BUCLE";
    IChatClient bucle = new ChatClientBuilder(new GuionFalso()).UseFunctionInvocation().Build(scope.ServiceProvider);
    var r = await bucle.GetResponseAsync("¿cuántos van a pie?", new ChatOptions { Tools = [.. CatalogoDeHerramientas()] });
    Console.WriteLine($"[D] IChatClient + UseFunctionInvocation → «{r.Text}»");
    AIAgent agente = new ChatClientAgent(new GuionFalso(), instructions: "Respondé con datos.", tools: [.. CatalogoDeHerramientas()], services: scope.ServiceProvider);
    var ra = await agente.RunAsync("¿cuántos van a pie?");
    Console.WriteLine($"[E] ChatClientAgent (MAF) con la misma lista → «{ra.Text}»");
}
await a4.StopAsync();

// ---------- tipos ----------
public sealed class SessionContext { public string SessionId { get; set; } = "(sin sesión)"; }
public interface IEncuestaLectura { int Contar(string sesion, string medio); }
public sealed class EncuestaFalsa : IEncuestaLectura { public int Contar(string sesion, string medio) => medio == "caminata" ? 18 : 0; }
public sealed class HerramientasDeLectura(SessionContext ctx, IEncuestaLectura lectura)
{
    [Description("Cuenta cuántas respuestas de la encuesta de la sesión declaran un medio de transporte.")]
    public string ContarPorMedio([Description("Medio de transporte, por ejemplo «caminata» o «colectivo».")] string medio)
        => $"{lectura.Contar(ctx.SessionId, medio)} respuestas con «{medio}» (vista desde la sesión {ctx.SessionId})";
}
public sealed class TokenDemoHandler(IOptionsMonitor<AuthenticationSchemeOptions> o, ILoggerFactory l, UrlEncoder e, IConfiguration cfg)
    : AuthenticationHandler<AuthenticationSchemeOptions>(o, l, e)
{
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var h = Request.Headers.Authorization.ToString();
        if (!h.StartsWith("Bearer ")) return Task.FromResult(AuthenticateResult.NoResult());
        return Task.FromResult(h["Bearer ".Length..] == cfg["Mcp:Token"]
            ? AuthenticateResult.Success(new AuthenticationTicket(new ClaimsPrincipal(new ClaimsIdentity([new Claim(ClaimTypes.Name, "cliente-mcp")], "TokenDemo")), "TokenDemo"))
            : AuthenticateResult.Fail("token inválido"));
    }
}
// Cliente falso: primero pide la herramienta, después responde con lo que devolvió.
public sealed class GuionFalso : IChatClient
{
    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> m, ChatOptions? o = null, CancellationToken ct = default)
    {
        var res = m.SelectMany(x => x.Contents).OfType<FunctionResultContent>().LastOrDefault();
        return Task.FromResult(res is null
            ? new ChatResponse(new ChatMessage(ChatRole.Assistant, [new FunctionCallContent("c1", "contar_por_medio", new Dictionary<string, object?> { ["medio"] = "caminata" })]))
            : new ChatResponse(new ChatMessage(ChatRole.Assistant, $"Herramienta: {res.Result}")));
    }
    public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> m, ChatOptions? o = null, [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
    { foreach (var u in (await GetResponseAsync(m, o, ct)).ToChatResponseUpdates()) yield return u; }
    public object? GetService(Type t, object? k = null) => null;
    public void Dispose() { }
}
