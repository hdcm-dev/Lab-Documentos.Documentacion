// ¿Cómo fija un lector num_ctx desde .NET y cómo lee prompt_eval_count? (M10, MI-18, R-C08)
// HTTP falso: responde como /api/chat de Ollama con prompt_eval_count = 2050 y captura el cuerpo enviado.
using System.Net;
using System.Text;
using Microsoft.Extensions.AI;
using OllamaSharp;
using OllamaSharp.Models;
using OllamaSharp.Models.Chat;

var falso = new Falso();
IChatClient chat = new OllamaApiClient(new HttpClient(falso) { BaseAddress = new Uri("http://localhost:11434") }, "modelo-x");

async Task Probar(string rotulo, ChatOptions o)
{
    var r = await chat.GetResponseAsync("hola", o);
    Console.WriteLine($"[{rotulo}] cuerpo enviado: {falso.Ultimo}");
    Console.WriteLine($"[{rotulo}] Usage.InputTokenCount={r.Usage?.InputTokenCount} OutputTokenCount={r.Usage?.OutputTokenCount}; RawRepresentation={r.RawRepresentation?.GetType().Name}");
}

await Probar("A sin nada", new ChatOptions());
var b = new ChatOptions { AdditionalProperties = new() { ["num_ctx"] = 8192 } };
await Probar("B AdditionalProperties[num_ctx]", b);
await Probar("C RawRepresentationFactory→ChatRequest.Options.NumCtx",
    new ChatOptions { RawRepresentationFactory = _ => new ChatRequest { Options = new RequestOptions { NumCtx = 8192 } } });
await Probar("D Reasoning=None", new ChatOptions { Reasoning = new() { Effort = ReasoningEffort.None } });

sealed class Falso : HttpMessageHandler
{
    public string Ultimo = "";
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage req, CancellationToken ct)
    {
        Ultimo = req.Content is null ? "" : await req.Content.ReadAsStringAsync(ct);
        var json = "{\"model\":\"modelo-x\",\"created_at\":\"2026-10-28T00:00:00Z\",\"message\":{\"role\":\"assistant\",\"content\":\"ok\"},\"done\":true,\"done_reason\":\"stop\",\"prompt_eval_count\":2050,\"eval_count\":3}\n";
        return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(json, Encoding.UTF8, "application/x-ndjson") };
    }
}
