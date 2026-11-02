// PC-02 (mesa ciclo 1, ronda 2, guía 16, 2026-10-28). Sin modelo: IChatClient guionado + exportador en memoria de OpenTelemetry.
// Pregunta: con UseOpenTelemetry dos veces y el mismo sourceName, ¿se ven a la vez los spans de herramientas y los aciertos de caché?
// Se comparan: Rama A (caché → FI → OTel), R-C07 (OTel → caché → FI) y doble capa (OTel → caché → FI → OTel), cada una con caché fría y caliente.
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

const string Fuente = "MovilidadUrbana.AI"; // TelemetriaDeIA.Fuente (MI-15, P-42)
Console.WriteLine($"# runtime {Environment.Version}; MEAI {typeof(IChatClient).Assembly.GetName().Version}; OpenTelemetry {typeof(Sdk).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion}");

var trazas = new List<Activity>();
var metricas = new List<Metric>();
using var tp = Sdk.CreateTracerProviderBuilder().AddSource(Fuente).AddInMemoryExporter(trazas).Build()!;
using var mp = Sdk.CreateMeterProviderBuilder().AddMeter(Fuente).AddInMemoryExporter(metricas, lector => lector.TemporalityPreference = MetricReaderTemporalityPreference.Delta).Build()!;
var medidor = new Meter(Fuente);
var aciertos = medidor.CreateCounter<long>("movilidadurbana.ai.cache.aciertos");

var herramienta = AIFunctionFactory.Create((string provincia) => provincia == "Corrientes" ? 2 : 0, "contar_localidades_por_provincia");
IDistributedCache NuevaCache() => new MemoryDistributedCache(Options.Create(new MemoryDistributedCacheOptions()));

var variantes = new (string clave, string rotulo, Func<IChatClient, IChatClient> armar)[] {
  ("A", "Rama A: caché → UseFunctionInvocation → UseOpenTelemetry → cliente",
     c => c.AsBuilder().Use(i => new CacheConContador(i, NuevaCache(), aciertos)).UseFunctionInvocation().UseOpenTelemetry(sourceName: Fuente).Build()),
  ("B", "R-C07: UseOpenTelemetry → caché → UseFunctionInvocation → cliente",
     c => c.AsBuilder().UseOpenTelemetry(sourceName: Fuente).Use(i => new CacheConContador(i, NuevaCache(), aciertos)).UseFunctionInvocation().Build()),
  ("D", "Doble capa: UseOpenTelemetry (externa) → caché → UseFunctionInvocation → UseOpenTelemetry (interna) → cliente, mismo sourceName",
     c => c.AsBuilder().UseOpenTelemetry(sourceName: Fuente).Use(i => new CacheConContador(i, NuevaCache(), aciertos)).UseFunctionInvocation().UseOpenTelemetry(sourceName: Fuente).Build()),
  ("D2", "Doble capa con distributed cache de MEAI sin contador (UseDistributedCache), mismo orden que D",
     c => c.AsBuilder().UseOpenTelemetry(sourceName: Fuente).UseDistributedCache(NuevaCache()).UseFunctionInvocation().UseOpenTelemetry(sourceName: Fuente).Build()),
};

foreach (var (clave, rotulo, armar) in variantes)
{
  var guion = new Guion();
  var cliente = armar(guion);
  Console.WriteLine($"\n[{clave}] {rotulo}");
  foreach (var estado in new[] { "fría", "caliente" })
  {
    trazas.Clear(); metricas.Clear(); var llamadasAntes = guion.Llamadas; var herrAntes = guion.HerramientaVista;
    var r = await cliente.GetResponseAsync([new ChatMessage(ChatRole.User, "¿Cuántas localidades hay en Corrientes?")], new ChatOptions { Tools = [herramienta], Temperature = 0 });
    tp.ForceFlush(); mp.ForceFlush();
    var porId = trazas.ToDictionary(a => a.SpanId);
    string Prof(Activity a) { int d = 0; var p = a.ParentSpanId; while (porId.TryGetValue(p, out var x)) { d++; p = x.ParentSpanId; } return new string(' ', 2 * d); }
    Console.WriteLine($"  caché {estado}: respuesta=«{r.Text}»; llamadas al cliente guionado={guion.Llamadas - llamadasAntes}; spans de «{Fuente}»={trazas.Count}; resultados de herramienta vistos por el cliente={guion.HerramientaVista - herrAntes}");
    foreach (var a in trazas.OrderBy(a => a.StartTimeUtc))
      Console.WriteLine($"    {Prof(a)}{a.DisplayName} [in={a.GetTagItem("gen_ai.usage.input_tokens") ?? "-"}, out={a.GetTagItem("gen_ai.usage.output_tokens") ?? "-"}, dur={a.Duration.TotalMilliseconds:F1} ms]");
    foreach (var m in metricas)
    {
      long n = 0; double suma = 0; var desglose = new List<string>();
      foreach (ref readonly var pt in m.GetMetricPoints())
      {
        long c; double s;
        if (m.MetricType == MetricType.Histogram) { c = pt.GetHistogramCount(); s = pt.GetHistogramSum(); }
        else { c = 1; s = pt.GetSumLong(); }
        n += c; suma += s;
        var tags = new List<string>(); foreach (var t in pt.Tags) if (t.Key is "gen_ai.token.type") tags.Add($"{t.Value}");
        desglose.Add($"{string.Join(",", tags)}:n={c},suma={s}");
      }
      Console.WriteLine($"    métrica {m.Name} ({m.MetricType}): {string.Join(" | ", desglose)}");
    }
  }
}

// [Clave con sesión] Dos sesiones, mismo texto, caché por fuera de UseFunctionInvocation.
Console.WriteLine("\n[S] Clave de caché y sesión (caché por fuera de UseFunctionInvocation)");
var miembros = typeof(DistributedCachingChatClient).GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
   .Where(m => m.Name.Contains("Key")).Select(m => $"{m.MemberType}:{m.Name}").Distinct();
Console.WriteLine($"  miembros con «Key» en DistributedCachingChatClient: {string.Join(", ", miembros)}");
foreach (var conSesion in new[] { false, true })
{
  var guion = new Guion(); var cache = NuevaCache();
  foreach (var sesion in new[] { "sesion-A", "sesion-B" })
  {
    var dcc = new DistributedCachingChatClient(new FunctionInvokingChatClient(guion), cache);
    if (conSesion) dcc.CacheKeyAdditionalValues = [sesion];
    var antes = guion.Llamadas;
    var r = await dcc.GetResponseAsync([new ChatMessage(ChatRole.User, "¿Cuántas localidades hay en Corrientes?")], new ChatOptions { Tools = [herramienta] });
    Console.WriteLine($"  CacheKeyAdditionalValues={(conSesion ? "[SessionId]" : "(sin)")} {sesion}: llamadas al cliente={guion.Llamadas - antes} → {(guion.Llamadas - antes == 0 ? "ACIERTO (respuesta de otra sesión)" : "fallo de caché")}");
  }
}

// Caché que cuenta sus aciertos en el Meter de la fuente (rama A de P-03).
sealed class CacheConContador(IChatClient interno, IDistributedCache cache, Counter<long> aciertos) : DistributedCachingChatClient(interno, cache)
{
  protected override async Task<ChatResponse?> ReadCacheAsync(string key, CancellationToken ct)
  {
    var r = await base.ReadCacheAsync(key, ct);
    if (r is not null) aciertos.Add(1);
    return r;
  }
}

sealed class Guion : IChatClient
{
  public int Llamadas; public int HerramientaVista;
  public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken ct = default)
  {
    Llamadas++;
    var res = messages.SelectMany(m => m.Contents).OfType<FunctionResultContent>().LastOrDefault();
    var uso = new UsageDetails { InputTokenCount = 12, OutputTokenCount = 3 };
    if (res is null && options?.Tools is { Count: > 0 } t)
      return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, [new FunctionCallContent($"c{Llamadas}", t[0].Name, new Dictionary<string, object?> { ["provincia"] = "Corrientes" })])) { ModelId = "guion", Usage = uso });
    if (res is not null) HerramientaVista++;
    return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, res?.Result?.ToString() ?? "sin herramienta")) { ModelId = "guion", Usage = uso });
  }
  public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null,
      [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
  { foreach (var u in (await GetResponseAsync(messages, options, ct)).ToChatResponseUpdates()) yield return u; }
  public object? GetService(Type t, object? k = null) => t.IsInstanceOfType(this) ? this : null;
  public void Dispose() { }
}
