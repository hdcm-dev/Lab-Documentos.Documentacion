// R-LLM. Criterio de éxito escrito antes: con un prompt de ~3000 tokens, sin num_ctx Usage.InputTokenCount < 2100
// (truncado silencioso, X3) y con AdditionalProperties["num_ctx"]=8192 Usage.InputTokenCount > 2900 (sin truncar).
// El endpoint sale sólo de OLLAMA_ENDPOINT y no se imprime (R-PRIV).
using Microsoft.Extensions.AI;
using OllamaSharp;
var ep = Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT") ?? "http://localhost:11434";
var modelo = Environment.GetEnvironmentVariable("OLLAMA_MODEL") ?? "qwen2.5:0.5b";
IChatClient chat = new OllamaApiClient(new HttpClient { BaseAddress = new Uri(ep), Timeout = TimeSpan.FromMinutes(5) }, modelo);
var lineas = Enumerable.Range(1, int.Parse(Environment.GetEnvironmentVariable("LINEAS") ?? "300")).Select(i => $"Localidad {i}: código postal {3000 + i}, provincia Corrientes, habitantes {1000 + i * 7}.");
var prompt = string.Join("\n", lineas) + "\n¿Cuál es el código postal de la Localidad 1? Respondé sólo el número.";
Console.WriteLine($"# {DateTimeOffset.Now:O} modelo={modelo} caracteres_prompt={prompt.Length}");
foreach (var (rot, o) in new (string, ChatOptions)[] {
    ("sin num_ctx", new ChatOptions { Temperature = 0, Seed = 1, MaxOutputTokens = 16 }),
    ("num_ctx=8192 por AdditionalProperties", new ChatOptions { Temperature = 0, Seed = 1, MaxOutputTokens = 16, AdditionalProperties = new() { ["num_ctx"] = 8192 } }) })
{
    var sw = System.Diagnostics.Stopwatch.StartNew();
    var r = await chat.GetResponseAsync(prompt, o);
    Console.WriteLine($"[{rot}] InputTokenCount={r.Usage?.InputTokenCount} respuesta=«{r.Text.Trim()}» FinishReason={r.FinishReason} ms={sw.ElapsedMilliseconds}");
}
