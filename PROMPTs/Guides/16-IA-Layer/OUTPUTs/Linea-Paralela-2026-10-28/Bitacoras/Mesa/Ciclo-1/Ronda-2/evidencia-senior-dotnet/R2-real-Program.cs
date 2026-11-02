// PC-04 y PC-05 contra el servidor Ollama de la LAN del laboratorio (R-LLM). El endpoint sale de OLLAMA_ENDPOINT y no se imprime.
using System.ClientModel;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Nodes;
using Microsoft.Extensions.AI;
using OllamaSharp;

var ep = Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT") ?? "http://localhost:11434";
const string modelo = "qwen3.5:4b";
var nonce = Guid.NewGuid().ToString("N")[..8];
var sb = new StringBuilder($"[corrida {nonce}] Sos el asistente de la encuesta de Movilidad Urbana. Respondé sólo con un número.\nTabla de respuestas por localidad (localidad: cantidad):\n");
for (int i = 1; i <= 60; i++) sb.Append($"Localidad {i:00}: {(i * 7) % 23 + 1} respuestas\n");
var sistema = sb.ToString();

var cap = new Captura(new HttpClientHandler());
var oc = new OllamaApiClient(new HttpClient(cap) { BaseAddress = new Uri(ep), Timeout = TimeSpan.FromMinutes(5) }, modelo);
var lista = await oc.ListLocalModelsAsync();
var m = lista.First(x => x.Name == modelo);
Console.WriteLine($"# {DateTimeOffset.Now:O} modelo={modelo} digest={m.Digest} Ollama={await oc.GetVersionAsync()} MEAI {typeof(IChatClient).Assembly.GetName().Version} OllamaSharp {typeof(OllamaApiClient).Assembly.GetName().Version} OpenAI {typeof(OpenAI.OpenAIClient).Assembly.GetName().Version}");
Console.WriteLine($"# parámetros: Temperature 0, Seed 1, MaxOutputTokens 16, Reasoning.Effort None (think:false), num_ctx sin fijar (el del modelo cargado); nonce de prefijo {nonce}");
Console.WriteLine($"# mensaje de sistema ({sistema.Length} caracteres): primera línea «{sistema.Split('\n')[0]}», 60 líneas «Localidad NN: k respuestas» con k=(NN*7)%23+1\n");
ChatOptions Op(int max = 16) => new() { Temperature = 0, Seed = 1, MaxOutputTokens = max, Reasoning = new() { Effort = ReasoningEffort.None } };
IChatClient chat = oc;

async Task Caso(string rot, string pregunta)
{
    var caja = new Caja(); Captura.Actual.Value = caja;
    var sw = Stopwatch.StartNew();
    var r = await chat.GetResponseAsync([new(ChatRole.System, sistema), new(ChatRole.User, pregunta)], Op());
    Console.WriteLine($"[{rot}] pregunta «{pregunta}» → «{r.Text.Trim()}» pared={sw.Elapsed.TotalSeconds:F1}s");
    Console.WriteLine($"      IChatClient: Usage.InputTokenCount={r.Usage?.InputTokenCount} CachedInputTokenCount={r.Usage?.CachedInputTokenCount?.ToString() ?? "null"} AdditionalCounts={(r.Usage?.AdditionalCounts is null ? "null" : string.Join(",", r.Usage.AdditionalCounts))}");
    Console.WriteLine($"      DelegatingHandler (última línea de /api/chat): prompt_eval_count={caja.Total} prompt_eval_cached_count={caja.Cached?.ToString() ?? "ausente"}");
    Console.WriteLine($"      cuerpo enviado (sin mensajes): {caja.CuerpoSinMensajes}");
}
await Caso("A frío (prefijo nuevo)", "¿Cuántas respuestas tiene la Localidad 17?");
await Caso("B mismo pedido", "¿Cuántas respuestas tiene la Localidad 17?");
await Caso("C misma tabla, otra pregunta", "¿Cuántas respuestas tiene la Localidad 42?");

// /v1 por MEAI.OpenAI: ¿llega cached_tokens? ¿se respeta max_completion_tokens?
IChatClient v1 = new OpenAI.OpenAIClient(new ApiKeyCredential("ollama"), new OpenAI.OpenAIClientOptions { Endpoint = new Uri(ep.TrimEnd('/') + "/v1"), Transport = new System.ClientModel.Primitives.HttpClientPipelineTransport(new HttpClient(cap) { Timeout = TimeSpan.FromMinutes(5) }) }).GetChatClient(modelo).AsIChatClient();
foreach (var (rot, max) in new[] { ("D /v1 MaxOutputTokens 3", 3), ("E /v1 MaxOutputTokens 3, repetido", 3) })
{
    var caja = new Caja(); Captura.Actual.Value = caja;
    var sw = Stopwatch.StartNew();
    var r = await v1.GetResponseAsync([new(ChatRole.System, sistema), new(ChatRole.User, "Enumerá las localidades 1 a 10 con su cantidad.")], Op(max));
    Console.WriteLine($"[{rot}] → «{r.Text.Trim().Replace("\n", " ⏎ ")}» pared={sw.Elapsed.TotalSeconds:F1}s FinishReason={r.FinishReason}");
    Console.WriteLine($"      Usage: Input={r.Usage?.InputTokenCount} Output={r.Usage?.OutputTokenCount} CachedInput={r.Usage?.CachedInputTokenCount?.ToString() ?? "null"}");
    Console.WriteLine($"      cuerpo enviado (sin mensajes): {caja.CuerpoSinMensajes}");
    Console.WriteLine($"      usage crudo devuelto: {caja.UsageCrudo}");
}

sealed class Caja { public int? Total; public int? Cached; public string CuerpoSinMensajes = ""; public string UsageCrudo = ""; }
sealed class Captura(HttpMessageHandler interno) : DelegatingHandler(interno)
{
    public static readonly AsyncLocal<Caja?> Actual = new();
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage req, CancellationToken ct)
    {
        var caja = Actual.Value;
        if (caja != null && req.Content != null)
        {
            var n = JsonNode.Parse(await req.Content.ReadAsStringAsync(ct))!.AsObject();
            n.Remove("messages"); caja.CuerpoSinMensajes = n.ToJsonString();
        }
        var resp = await base.SendAsync(req, ct);
        var p = req.RequestUri!.AbsolutePath;
        if (caja != null && (p.EndsWith("/api/chat") || p.EndsWith("/chat/completions")) && resp.IsSuccessStatusCode)
        {
            var texto = await resp.Content.ReadAsStringAsync(ct);
            var ultima = JsonNode.Parse(texto.Split('\n', StringSplitOptions.RemoveEmptyEntries).Last())!;
            if (p.EndsWith("/api/chat")) { caja.Total = (int?)ultima["prompt_eval_count"]; caja.Cached = (int?)ultima["prompt_eval_cached_count"]; }
            else caja.UsageCrudo = ultima["usage"]?.ToJsonString() ?? "(sin usage)";
            var nuevo = new StringContent(texto, Encoding.UTF8, resp.Content.Headers.ContentType?.MediaType ?? "application/json");
            resp.Content = nuevo;
        }
        return resp;
    }
}
