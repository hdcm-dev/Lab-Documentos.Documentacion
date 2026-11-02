// Juez de evidencia, aprobación ronda 2 vuelta 2 (P2-06), 2026-10-28. Sin modelo: cliente guionado.
// Pregunta: en MEAI 10.11.0, un acierto por GetStreamingResponseAsync ¿pasa por ReadCacheAsync o por ReadCacheStreamingAsync?
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
Console.WriteLine($"# runtime {Environment.Version}; MEAI {typeof(IChatClient).Assembly.GetName().Version}");
IDistributedCache NuevaCache() => new MemoryDistributedCache(Options.Create(new MemoryDistributedCacheOptions()));
var herramienta = AIFunctionFactory.Create((string provincia) => provincia == "Corrientes" ? 2 : 0, "contar_localidades_por_provincia");
List<ChatMessage> Msgs() => [new ChatMessage(ChatRole.User, "¿Cuántas localidades hay en Corrientes?")];
ChatOptions Opc() => new() { Tools = [herramienta] };

// [1] Streaming con CoalesceStreamingUpdates en true (por defecto) y en false.
foreach (bool coalesce in new[] { true, false })
{
  var g = new Guion(); var c = new Espia(new FunctionInvokingChatClient(g), NuevaCache());
  Console.WriteLine($"\n[1] CoalesceStreamingUpdates={c.CoalesceStreamingUpdates} (por defecto) → se fija en {coalesce}");
  c.CoalesceStreamingUpdates = coalesce;
  foreach (var estado in new[] { "fría", "caliente" })
  {
    var antes = g.Llamadas; c.Reset(); int n = 0; var txt = "";
    await foreach (var u in c.GetStreamingResponseAsync(Msgs(), Opc())) { n++; txt += u.Text; }
    Console.WriteLine($"  streaming {estado}: llamadas={g.Llamadas - antes}; fragmentos={n}; texto=«{txt}»; ReadCacheAsync={c.R}/{c.RHit} acierto; ReadCacheStreamingAsync={c.RS}/{c.RSHit} acierto; WriteCacheAsync={c.W}; WriteCacheStreamingAsync={c.WS}");
  }
}

// [2] Subclase que sólo sobrescribe ReadCacheAsync (el caso «rojo» de (2b)), por streaming con valores por defecto.
{
  var g = new Guion(); var c = new SoloRead(new FunctionInvokingChatClient(g), NuevaCache());
  for (int i = 0; i < 2; i++) { await foreach (var _ in c.GetStreamingResponseAsync(Msgs(), Opc())) { } }
  Console.WriteLine($"\n[2] Sólo ReadCacheAsync sobrescrito, 2 pedidos por streaming (por defecto): llamadas={g.Llamadas}; aciertos contados={c.Aciertos}");
}

// [2c] Caso rojo con CoalesceStreamingUpdates = false.
{
  var g = new Guion(); var c = new SoloRead(new FunctionInvokingChatClient(g), NuevaCache()) { CoalesceStreamingUpdates = false };
  for (int i = 0; i < 2; i++) { await foreach (var _ in c.GetStreamingResponseAsync(Msgs(), Opc())) { } }
  Console.WriteLine($"\n[2c] Sólo ReadCacheAsync sobrescrito, CoalesceStreamingUpdates=false, 2 pedidos por streaming: llamadas={g.Llamadas}; aciertos contados={c.Aciertos}");
}

// [3] EnableCaching sobrescrito: no cachea pedidos con herramientas.
{
  var g = new Guion(); var c = new SinHerramientas(new FunctionInvokingChatClient(g), NuevaCache());
  for (int i = 0; i < 2; i++) await c.GetResponseAsync(Msgs(), Opc());
  var a = g.Llamadas;
  for (int i = 0; i < 2; i++) await c.GetResponseAsync(Msgs(), new ChatOptions());
  Console.WriteLine($"\n[3] EnableCaching sobrescrito (false si hay Tools): 2 pedidos con herramientas → llamadas={a}; 2 pedidos sin herramientas → llamadas={g.Llamadas - a}");
}

// [4] Regla (a): CacheKeyAdditionalValues = [SessionId, VersionDeDatos], una instancia por «scope».
foreach (bool conVersion in new[] { true, false })
{
  var g = new Guion(); var cache = NuevaCache(); int version = 0; var res = new List<string>();
  foreach (var paso in new[] { "lectura", "lectura tras escritura" })
  {
    if (paso != "lectura") version++; // escritura confirmada en otro pedido HTTP
    var c = new DistributedCachingChatClient(new FunctionInvokingChatClient(g), cache)
      { CacheKeyAdditionalValues = conVersion ? ["sesion-A", version] : ["sesion-A"] };
    var antes = g.Llamadas; await c.GetResponseAsync(Msgs(), Opc());
    res.Add($"{paso} (v{version}): llamadas={g.Llamadas - antes} → {(g.Llamadas - antes == 0 ? "ACIERTO" : "fallo")}");
  }
  Console.WriteLine($"\n[4] clave {(conVersion ? "[SessionId, VersionDeDatos]" : "[SessionId] (caso rojo)")}: {string.Join("; ", res)}");
}

class Espia(IChatClient i, IDistributedCache d) : DistributedCachingChatClient(i, d)
{
  public int R, RHit, RS, RSHit, W, WS; public void Reset() => R = RHit = RS = RSHit = W = WS = 0;
  protected override async Task<ChatResponse?> ReadCacheAsync(string key, CancellationToken ct) { R++; var r = await base.ReadCacheAsync(key, ct); if (r is not null) RHit++; return r; }
  protected override async Task<IReadOnlyList<ChatResponseUpdate>?> ReadCacheStreamingAsync(string key, CancellationToken ct) { RS++; var r = await base.ReadCacheStreamingAsync(key, ct); if (r is not null) RSHit++; return r; }
  protected override Task WriteCacheAsync(string key, ChatResponse v, CancellationToken ct) { W++; return base.WriteCacheAsync(key, v, ct); }
  protected override Task WriteCacheStreamingAsync(string key, IReadOnlyList<ChatResponseUpdate> v, CancellationToken ct) { WS++; return base.WriteCacheStreamingAsync(key, v, ct); }
}
sealed class SoloRead(IChatClient i, IDistributedCache d) : DistributedCachingChatClient(i, d)
{
  public int Aciertos;
  protected override async Task<ChatResponse?> ReadCacheAsync(string key, CancellationToken ct) { var r = await base.ReadCacheAsync(key, ct); if (r is not null) Aciertos++; return r; }
}
sealed class SinHerramientas(IChatClient i, IDistributedCache d) : DistributedCachingChatClient(i, d)
{
  protected override bool EnableCaching(IEnumerable<ChatMessage> messages, ChatOptions? options) => options?.Tools is not { Count: > 0 } && base.EnableCaching(messages, options);
}
sealed class Guion : IChatClient
{
  public int Llamadas;
  public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken ct = default)
  {
    Llamadas++;
    var res = messages.SelectMany(m => m.Contents).OfType<FunctionResultContent>().LastOrDefault();
    if (res is null && options?.Tools is { Count: > 0 } t)
      return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, [new FunctionCallContent($"c{Llamadas}", t[0].Name, new Dictionary<string, object?> { ["provincia"] = "Corrientes" })])));
    return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, res?.Result?.ToString() ?? "sin herramienta")));
  }
  public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null,
      [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
  { var r = await GetResponseAsync(messages, options, ct); foreach (var ch in (r.Text.Length > 0 ? r.Text.Select(x => x.ToString()) : [""])) { if (r.Text.Length == 0) { foreach (var u in r.ToChatResponseUpdates()) yield return u; } else yield return new ChatResponseUpdate(ChatRole.Assistant, ch) { MessageId = "m" }; } }
  public object? GetService(Type t, object? k = null) => t.IsInstanceOfType(this) ? this : null;
  public void Dispose() { }
}
