// Sonda EVAL (PC-08, consulta dirigida C1 ronda 2, 2026-10-28). Costo en tiempo del juez y de los evaluadores de
// Microsoft.Extensions.AI.Evaluation.Quality 10.11.0 con qwen3.5:4b como modelo juez, por OllamaSharp 5.5.0.
// Mide cada llamada al juez (pared, tokens de entrada y salida, contadores de Ollama) con un DelegatingChatClient.
// El endpoint sale sólo de OLLAMA_ENDPOINT y nunca se imprime (R-PRIV).
// Corpus: requisitos de EncuestaPolicy / LocalidadPolicy del caso base (Lab-E2E.WebBlazor 59399ba, ApiWeb), con los
// valores de EncuestaRules / LocalidadRules ya resueltos. Las respuestas a juzgar están escritas a mano (no las genera
// el modelo): el objeto de la sonda es el COSTO del juez, no la calidad de un asistente.
using System.Diagnostics;
using System.Text.Json;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.AI.Evaluation;
using Microsoft.Extensions.AI.Evaluation.Quality;
using OllamaSharp;

var endpoint = Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT") ?? "http://localhost:11434";
var model = Environment.GetEnvironmentVariable("OLLAMA_MODEL") ?? "qwen3.5:4b";
bool razonar = Environment.GetEnvironmentVariable("RAZONAR") == "1";
int reps = int.Parse(Environment.GetEnvironmentVariable("REPS") ?? "1");
var soloCasos = (Environment.GetEnvironmentVariable("CASOS") ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries);
var soloEval = (Environment.GetEnvironmentVariable("EVALUADORES") ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries);
void Log(object o) => Console.WriteLine(JsonSerializer.Serialize(o).Replace(endpoint.TrimEnd('/'), "<OLLAMA_ENDPOINT>"));

var http = new HttpClient { BaseAddress = new Uri(endpoint), Timeout = TimeSpan.FromMinutes(20) };
Log(new { paso = "inicio", fecha = DateTimeOffset.Now.ToString("o"), model, razonar, reps,
    meai = typeof(IChatClient).Assembly.GetName().Version?.ToString(),
    evaluation = typeof(IEvaluator).Assembly.GetName().Version?.ToString(),
    quality = typeof(RelevanceEvaluator).Assembly.GetName().Version?.ToString(),
    ollamasharp = typeof(OllamaApiClient).Assembly.GetName().Version?.ToString() });
try { var tags = JsonDocument.Parse(await http.GetStringAsync("/api/tags")); foreach (var m in tags.RootElement.GetProperty("models").EnumerateArray()) if (m.GetProperty("name").GetString() == model) Log(new { paso = "modelo", nombre = model, digest = m.GetProperty("digest").GetString()![..12] }); } catch (Exception e) { Log(new { paso = "tags-error", e.Message }); }

var medidor = new Medidor(new OllamaApiClient(http, model), razonar, Log);
var config = new ChatConfiguration(medidor);

string[] politica = [
    "Encuesta, nombre: Al menos 3 caracteres.",
    "Encuesta, edad: Entre 16 y 110 años.",
    "Encuesta, localidad: Una de las localidades cargadas en el ABM.",
    "Encuesta, medios: Al menos uno.",
    "Encuesta, distancia: Entre 0 y 500 km por día.",
    "Encuesta, minutos: Entre 1 y 600 minutos.",
    "Localidad, nombre: Entre 3 y 60 caracteres, único por provincia.",
    "Localidad, código postal: 4 dígitos.",
    "Localidad, habitantes: Un número entero de 1 en adelante.",
];
string Ctx(params int[] idx) => string.Join("\n", idx.Select(i => politica[i]));
var casos = new[] {
    new Caso("C1-edad", "¿Qué edad tiene que tener una persona para responder la encuesta de Movilidad Urbana?",
        "Tiene que tener entre 16 y 110 años.", "Entre 16 y 110 años.", [1, 0, 3]),
    new Caso("C2-cp", "¿Cuántos dígitos lleva el código postal de una localidad?",
        "El código postal lleva 4 dígitos.", "4 dígitos.", [7, 6, 8]),
    new Caso("C3-distancia-mal", "¿Cuántos kilómetros por día se pueden declarar en la encuesta?",
        "Se pueden declarar hasta 1000 km por día.", "Entre 0 y 500 km por día.", [4, 5, 3]),
    new Caso("C4-no-respondible", "Si elimino una localidad, ¿se pierden las encuestas que la usan?",
        "Las reglas cargadas no dicen qué pasa con las encuestas al eliminar una localidad; no lo puedo afirmar.",
        "No está en los requisitos cargados.", [2, 6, 3]),
};
var evaluadores = new (string nombre, IEvaluator ev, Func<Caso, EvaluationContext[]> ctx)[] {
    ("Relevance", new RelevanceEvaluator(), _ => []),
    ("Coherence", new CoherenceEvaluator(), _ => []),
    ("Fluency", new FluencyEvaluator(), _ => []),
    ("Groundedness", new GroundednessEvaluator(), c => [new GroundednessEvaluatorContext(Ctx(c.Fragmentos))]),
    ("Retrieval", new RetrievalEvaluator(), c => [new RetrievalEvaluatorContext(c.Fragmentos.Select(i => politica[i]).ToArray())]),
    ("Completeness", new CompletenessEvaluator(), c => [new CompletenessEvaluatorContext(c.Verdad)]),
    ("Equivalence", new EquivalenceEvaluator(), c => [new EquivalenceEvaluatorContext(c.Verdad)]),
};

var total = Stopwatch.StartNew();
for (int r = 1; r <= reps; r++)
foreach (var c in casos.Where(c => soloCasos.Length == 0 || soloCasos.Contains(c.Id)))
foreach (var (nombre, ev, ctx) in evaluadores.Where(e => soloEval.Length == 0 || soloEval.Contains(e.nombre)))
{
    var mensajes = new List<ChatMessage> { new(ChatRole.System, "Sos el asistente de ayuda de Movilidad Urbana. Respondé sólo con los requisitos cargados."), new(ChatRole.User, c.Pregunta) };
    var respuesta = new ChatResponse(new ChatMessage(ChatRole.Assistant, c.Respuesta));
    medidor.Etiqueta = $"{c.Id}/{nombre}/r{r}"; medidor.Llamadas = 0;
    var sw = Stopwatch.StartNew(); string error = ""; EvaluationResult? res = null;
    try { res = await ev.EvaluateAsync(mensajes, respuesta, config, ctx(c)); } catch (Exception e) { error = e.GetType().Name + ": " + e.Message.Split('\n')[0]; }
    var metricas = res?.Metrics.Values.Select(m => new {
        m.Name, valor = m is NumericMetric n ? n.Value : (object?)null, rating = m.Interpretation?.Rating.ToString(), falla = m.Interpretation?.Failed,
        razon = m.Reason is { Length: > 200 } s ? s[..200] : m.Reason,
        diagnosticos = m.Diagnostics?.Select(d => $"{d.Severity}: {(d.Message.Length > 160 ? d.Message[..160] : d.Message)}").ToArray(),
        metadata = m.Metadata }).ToArray();
    Log(new { paso = "evaluacion", caso = c.Id, evaluador = nombre, rep = r, pared_s = Math.Round(sw.Elapsed.TotalSeconds, 2), llamadas_al_juez = medidor.Llamadas, metricas, error });
}
Log(new { paso = "fin", fecha = DateTimeOffset.Now.ToString("o"), total_s = Math.Round(total.Elapsed.TotalSeconds, 1), llamadas = medidor.Total });

record Caso(string Id, string Pregunta, string Respuesta, string Verdad, int[] Fragmentos);

sealed class Medidor(IChatClient inner, bool razonar, Action<object> log) : DelegatingChatClient(inner)
{
    public string Etiqueta = ""; public int Llamadas; public int Total;
    public override async Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken ct = default)
    {
        var o = options?.Clone() ?? new ChatOptions();
        if (!razonar) o.Reasoning = new ReasoningOptions { Effort = ReasoningEffort.None };
        var lista = messages.ToList();
        var sw = Stopwatch.StartNew(); ChatResponse r;
        try { r = await base.GetResponseAsync(lista, o, ct); }
        catch (Exception e) { log(new { paso = "juez-error", etiqueta = Etiqueta, pared_s = Math.Round(sw.Elapsed.TotalSeconds, 2), error = e.GetType().Name + ": " + e.Message.Split('\n')[0] }); throw; }
        Llamadas++; Total++;
        var u = r.Usage;
        log(new { paso = "juez", etiqueta = Etiqueta, pared_s = Math.Round(sw.Elapsed.TotalSeconds, 2),
            chars_prompt = lista.Sum(m => m.Text?.Length ?? 0), temperatura = o.Temperature, max_salida = o.MaxOutputTokens,
            formato = o.ResponseFormat?.GetType().Name, razonamiento = !razonar ? "none" : "por defecto",
            tokens_entrada = u?.InputTokenCount, tokens_salida = u?.OutputTokenCount, cuentas = u?.AdditionalCounts,
            fin = r.FinishReason?.Value, texto = r.Text is { Length: > 240 } t ? t[..240] : r.Text });
        return r;
    }
}
