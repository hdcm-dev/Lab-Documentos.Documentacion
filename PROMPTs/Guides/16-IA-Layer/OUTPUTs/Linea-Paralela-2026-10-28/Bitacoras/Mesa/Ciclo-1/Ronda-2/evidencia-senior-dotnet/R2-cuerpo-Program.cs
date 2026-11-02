// PC-03 (<clave-de-cabeceras> en el cuerpo), PC-04 (prompt_eval_cached_count desde IChatClient), PC-05 (TopP/TopK/PresencePenalty por OllamaSharp y por /v1).
// Servidor HTTP falso (Kestrel en loopback, puerto efímero) que registra método, ruta, encabezados y cuerpo tal como llegan por el socket.
using System.ClientModel;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.AI;
using OllamaSharp;
using OllamaSharp.Models.Chat;

var capturas = new List<string>();
var b = WebApplication.CreateSlimBuilder();
b.Logging.ClearProviders();
b.WebHost.UseUrls("http://127.0.0.1:0");
var app = b.Build();
app.Run(async ctx =>
{
    using var sr = new StreamReader(ctx.Request.Body);
    var cuerpo = await sr.ReadToEndAsync();
    var enc = string.Join(" | ", ctx.Request.Headers.Where(h => h.Key is not ("Content-Length" or "Host" or "traceparent")).Select(h => $"{h.Key}: {h.Value}"));
    capturas.Add($"{ctx.Request.Method} {ctx.Request.Path}\n      encabezados HTTP: {enc}\n      cuerpo: {cuerpo}");
    var path = ctx.Request.Path.Value ?? "";
    if (path == "/api/chat")
    {
        ctx.Response.ContentType = "application/x-ndjson";
        await ctx.Response.WriteAsync("{\"model\":\"modelo-x\",\"created_at\":\"2026-10-28T00:00:00Z\",\"message\":{\"role\":\"assistant\",\"content\":\"ok\"},\"done\":true,\"done_reason\":\"stop\",\"total_duration\":1000,\"prompt_eval_count\":1467,\"prompt_eval_cached_count\":954,\"prompt_eval_duration\":500,\"eval_count\":3,\"eval_duration\":100}\n");
    }
    else if (path == "/api/embed")
    {
        ctx.Response.ContentType = "application/json";
        await ctx.Response.WriteAsync("{\"model\":\"emb-x\",\"embeddings\":[[0.1,0.2,0.3]],\"prompt_eval_count\":2}");
    }
    else if (path == "/v1/chat/completions")
    {
        ctx.Response.ContentType = "application/json";
        await ctx.Response.WriteAsync("{\"id\":\"c1\",\"object\":\"chat.completion\",\"created\":1,\"model\":\"modelo-x\",\"choices\":[{\"index\":0,\"message\":{\"role\":\"assistant\",\"content\":\"ok\"},\"finish_reason\":\"stop\"}],\"usage\":{\"prompt_tokens\":1467,\"completion_tokens\":3,\"total_tokens\":1470,\"prompt_tokens_details\":{\"cached_tokens\":954}}}");
    }
    else ctx.Response.StatusCode = 404;
});
await app.StartAsync();
var baseUrl = app.Services.GetRequiredService<IServer>().Features.Get<IServerAddressesFeature>()!.Addresses.First();
string Ultima() { var c = capturas[^1]; return c; }

Console.WriteLine($"# MEAI {typeof(IChatClient).Assembly.GetName().Version}; MEAI.OpenAI {typeof(OpenAIClientExtensions).Assembly.GetName().Version}; OpenAI {typeof(OpenAI.OpenAIClient).Assembly.GetName().Version}; OllamaSharp {typeof(OllamaApiClient).Assembly.GetName().Version}; runtime {Environment.Version}");
Console.WriteLine("# servidor falso: Kestrel en loopback, puerto efímero (no se registra)\n");

// ---------------- PC-03 ----------------
Console.WriteLine("## PC-03 <clave-de-cabeceras>");
var oc = new OllamaApiClient(new HttpClient { BaseAddress = new Uri(baseUrl) }, "modelo-x");
IChatClient chat = oc;
await chat.GetResponseAsync("hola");
Console.WriteLine("[A] cliente sin encabezados → " + Ultima());

oc.DefaultRequestHeaders["X-Prueba-Clave"] = "VALOR-SENSIBLE-DE-PRUEBA";
await chat.GetResponseAsync("hola");
Console.WriteLine("[B] OllamaApiClient.DefaultRequestHeaders[\"X-Prueba-Clave\"] → " + Ultima());

await chat.GetResponseAsync("hola", new ChatOptions { RawRepresentationFactory = _ => new ChatRequest { <clave-de-cabeceras> = { ["X-Por-Pedido"] = "VALOR-POR-PEDIDO" } } });
Console.WriteLine("[C] ChatRequest.<clave-de-cabeceras> por RawRepresentationFactory → " + Ultima());

IEmbeddingGenerator<string, Embedding<float>> emb = new OllamaApiClient(new HttpClient { BaseAddress = new Uri(baseUrl) }, "emb-x") { DefaultRequestHeaders = { ["X-Prueba-Clave"] = "VALOR-SENSIBLE-DE-PRUEBA" } };
await emb.GenerateAsync(["texto"]);
Console.WriteLine("[D] embeddings con DefaultRequestHeaders → " + Ultima());

var hc = new HttpClient { BaseAddress = new Uri(baseUrl) };
hc.DefaultRequestHeaders.Add("X-Prueba-Clave", "VALOR-EN-HTTPCLIENT");
IChatClient chatHc = new OllamaApiClient(hc, "modelo-x");
await chatHc.GetResponseAsync("hola");
Console.WriteLine("[E] encabezado puesto en HttpClient.DefaultRequestHeaders → " + Ultima());

var ser = JsonSerializer.Serialize(new ChatRequest { Model = "m", <clave-de-cabeceras> = { ["X-K"] = "v" } });
Console.WriteLine("[F] JsonSerializer.Serialize(ChatRequest) con opciones por defecto → " + ser);
var ser2 = JsonSerializer.Serialize(new ChatRequest { Model = "m", <clave-de-cabeceras> = { ["X-K"] = "v" } }, oc.OutgoingJsonSerializerOptions);
Console.WriteLine("[G] con oc.OutgoingJsonSerializerOptions → " + ser2);
var pch = typeof(OllamaSharp.Models.OllamaRequest).GetProperty("<clave-de-cabeceras>")!;
Console.WriteLine($"[H] OllamaRequest.<clave-de-cabeceras> atributos: [{string.Join(",", pch.GetCustomAttributes(true).Select(a => a.GetType().Name))}]");

// ---------------- PC-04 ----------------
Console.WriteLine("\n## PC-04 prompt_eval_cached_count (el falso devuelve prompt_eval_count 1467 y prompt_eval_cached_count 954)");
IChatClient c4 = new OllamaApiClient(new HttpClient { BaseAddress = new Uri(baseUrl) }, "modelo-x");
var r4 = await c4.GetResponseAsync("hola");
var u = r4.Usage!;
Console.WriteLine($"[A] Usage: Input={u.InputTokenCount} Output={u.OutputTokenCount} Total={u.TotalTokenCount} CachedInput={u.CachedInputTokenCount?.ToString() ?? "null"} Reasoning={u.ReasoningTokenCount?.ToString() ?? "null"} AdditionalCounts={(u.AdditionalCounts is null ? "null" : string.Join(",", u.AdditionalCounts.Select(kv => kv.Key + "=" + kv.Value)))}");
Console.WriteLine($"[B] ChatResponse.AdditionalProperties={(r4.AdditionalProperties is null ? "null" : string.Join(",", r4.AdditionalProperties.Select(kv => kv.Key + "=" + kv.Value)))}");
var raw = r4.RawRepresentation;
Console.WriteLine($"[C] RawRepresentation={raw?.GetType().FullName}");
for (var t = raw?.GetType(); t != null && t != typeof(object); t = t.BaseType)
    foreach (var p in t.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        Console.WriteLine($"      {t.Name}.{p.Name} ({p.PropertyType.Name}) [{string.Join(",", p.GetCustomAttributes(true).Select(a => a.GetType().Name))}] = {Fmt(p.GetValue(raw))}");
var msgRaw = r4.Messages.LastOrDefault()?.RawRepresentation;
Console.WriteLine($"[D] Messages[^1].RawRepresentation={msgRaw?.GetType().FullName ?? "null"}");
var cacheStr = typeof(OllamaApiClient).Assembly.GetTypes().SelectMany(t => t.GetProperties()).Where(p => p.Name.Contains("Cache", StringComparison.OrdinalIgnoreCase)).Select(p => p.DeclaringType!.Name + "." + p.Name);
Console.WriteLine($"[E] propiedades con «Cache» en todo OllamaSharp: [{string.Join(", ", cacheStr)}]");
var ext = typeof(OllamaApiClient).Assembly.GetTypes().SelectMany(t => t.GetProperties()).Where(p => p.GetCustomAttributes(typeof(System.Text.Json.Serialization.JsonExtensionDataAttribute), true).Any()).Select(p => p.DeclaringType!.Name + "." + p.Name);
Console.WriteLine($"[F] propiedades [JsonExtensionData] en OllamaSharp: [{string.Join(", ", ext)}]");
// Streaming
UsageDetails? us = null; await foreach (var up in c4.GetStreamingResponseAsync("hola")) foreach (var uc in up.Contents.OfType<UsageContent>()) us = uc.Details;
Console.WriteLine($"[G] streaming UsageContent: Input={us?.InputTokenCount} CachedInput={us?.CachedInputTokenCount?.ToString() ?? "null"} AdditionalCounts={(us?.AdditionalCounts is null ? "null" : string.Join(",", us.AdditionalCounts.Select(kv => kv.Key + "=" + kv.Value)))}");
// Remedio: DelegatingHandler que lee la última línea de /api/chat y la deja en un acumulador por pedido
var lector = new LectorDeCache(new HttpClientHandler());
IChatClient c4b = new OllamaApiClient(new HttpClient(lector) { BaseAddress = new Uri(baseUrl) }, "modelo-x");
LectorDeCache.Actual.Value = new CajaDeUso();
var r4b = await c4b.GetResponseAsync("hola");
Console.WriteLine($"[H] remedio DelegatingHandler: prompt_eval_count={LectorDeCache.Actual.Value.Total} prompt_eval_cached_count={LectorDeCache.Actual.Value.Cached}; respuesta del IChatClient intacta: «{r4b.Text}»");
// /v1 por MEAI.OpenAI
IChatClient c4v = new OpenAI.OpenAIClient(new ApiKeyCredential("no-se-usa"), new OpenAI.OpenAIClientOptions { Endpoint = new Uri(baseUrl.TrimEnd('/') + "/v1") }).GetChatClient("modelo-x").AsIChatClient();
var r4v = await c4v.GetResponseAsync("hola");
Console.WriteLine($"[I] vía /v1 (MEAI.OpenAI) con usage.prompt_tokens_details.cached_tokens=954 en la respuesta: Input={r4v.Usage?.InputTokenCount} CachedInput={r4v.Usage?.CachedInputTokenCount?.ToString() ?? "null"} AdditionalCounts={(r4v.Usage?.AdditionalCounts is null ? "null" : string.Join(",", r4v.Usage.AdditionalCounts.Select(kv => kv.Key + "=" + kv.Value)))}");

// ---------------- PC-05 ----------------
Console.WriteLine("\n## PC-05 muestreo");
ChatOptions Opc() => new() { Temperature = 0.7f, TopP = 0.8f, TopK = 20, PresencePenalty = 1.5f, FrequencyPenalty = 0.1f, Seed = 7, MaxOutputTokens = 64 };
await chat.GetResponseAsync("hola", Opc());
Console.WriteLine("[A] OllamaSharp /api/chat con Temperature 0.7, TopP 0.8, TopK 20, PresencePenalty 1.5, FrequencyPenalty 0.1, Seed 7, MaxOutputTokens 64 → " + Ultima());
await c4v.GetResponseAsync("hola", Opc());
Console.WriteLine("[B] MEAI.OpenAI /v1/chat/completions con las mismas ChatOptions → " + Ultima());
var o3 = Opc(); o3.AdditionalProperties = new() { ["top_k"] = 20 };
await c4v.GetResponseAsync("hola", o3);
Console.WriteLine("[C] /v1 con AdditionalProperties[\"top_k\"]=20 → " + Ultima());
var o4 = Opc(); o4.RawRepresentationFactory = _ => { var x = new OpenAI.Chat.ChatCompletionOptions(); x.Patch.Set("$.top_k"u8, 20); return x; };
await c4v.GetResponseAsync("hola", o4);
Console.WriteLine("[D] /v1 con RawRepresentationFactory → ChatCompletionOptions.Patch.Set(\"$.top_k\", 20) → " + Ultima());
var o5 = new ChatOptions { AdditionalProperties = new() { ["top_k"] = 20, ["min_p"] = 0.0f, ["repeat_penalty"] = 1.0f } };
await chat.GetResponseAsync("hola", o5);
Console.WriteLine("[E] OllamaSharp con AdditionalProperties top_k/min_p/repeat_penalty → " + Ultima());

await app.StopAsync();

static string Fmt(object? v) => v switch { null => "null", string s => $"\"{s}\"", System.Collections.IEnumerable e and not string => "[" + string.Join(",", e.Cast<object>().Select(x => x?.ToString())) + "]", _ => v.ToString() ?? "" };

sealed class LectorDeCache(HttpMessageHandler interno) : DelegatingHandler(interno)
{
    public static readonly AsyncLocal<CajaDeUso?> Actual = new();   // la fija quien llama; el handler la llena
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage req, CancellationToken ct)
    {
        var resp = await base.SendAsync(req, ct);
        if (req.RequestUri!.AbsolutePath.EndsWith("/api/chat") && resp.IsSuccessStatusCode)
        {
            var texto = await resp.Content.ReadAsStringAsync(ct);   // sólo vale con stream:false o leyendo todo; ver nota
            var ultima = texto.Split('\n', StringSplitOptions.RemoveEmptyEntries).Last();
            var n = JsonNode.Parse(ultima)!;
            if (Actual.Value is { } caja) { caja.Total = (int?)n["prompt_eval_count"]; caja.Cached = (int?)n["prompt_eval_cached_count"]; }
            var nuevo = new StringContent(texto, Encoding.UTF8, resp.Content.Headers.ContentType?.MediaType ?? "application/x-ndjson");
            resp.Content = nuevo;
        }
        return resp;
    }
}

sealed class CajaDeUso { public int? Total; public int? Cached; }
