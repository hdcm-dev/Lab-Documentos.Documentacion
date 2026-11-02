using System.Runtime.CompilerServices;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

Console.WriteLine($"# runtime {Environment.Version}; MEAI {typeof(CachingChatClient).Assembly.GetName().Version}");
IDistributedCache Nueva() => new MemoryDistributedCache(Options.Create(new MemoryDistributedCacheOptions()));
var msgs = new[] { new ChatMessage(ChatRole.User, "¿Cuántas localidades cargué en Corrientes?") };

async Task Stream(IChatClient c) { await foreach (var _ in c.GetStreamingResponseAsync(msgs)) { } }

// [1] Streaming, CoalesceStreamingUpdates por defecto, las dos sobrescrituras.
foreach (bool? coalesce in new bool?[] { null, true, false })
{
  var g = new Falso(); var c = new Contadora(g, Nueva());
  if (coalesce is bool b) c.CoalesceStreamingUpdates = b;
  await Stream(c); await Stream(c);
  Console.WriteLine($"[1] streaming x2, Coalesce={(coalesce?.ToString() ?? "por defecto")} (valor efectivo {c.CoalesceStreamingUpdates}): llamadas al cliente={g.Llamadas}; ReadCacheAsync llamadas={c.LeeR} aciertos={c.AcR}; ReadCacheStreamingAsync llamadas={c.LeeS} aciertos={c.AcS}; WriteCacheAsync={c.EsR}; WriteCacheStreamingAsync={c.EsS}");
}
// [2] No streaming.
{ var g = new Falso(); var c = new Contadora(g, Nueva()); await c.GetResponseAsync(msgs); await c.GetResponseAsync(msgs);
  Console.WriteLine($"[2] GetResponseAsync x2: llamadas al cliente={g.Llamadas}; ReadCacheAsync aciertos={c.AcR}; ReadCacheStreamingAsync llamadas={c.LeeS}"); }
// [3] Caso rojo de (2b): sólo ReadCacheAsync sobrescrito, streaming por defecto.
{ var g = new Falso(); var c = new SoloR(g, Nueva()); await Stream(c); await Stream(c);
  Console.WriteLine($"[3] sólo ReadCacheAsync, streaming x2, Coalesce por defecto: llamadas al cliente={g.Llamadas}; contador={c.Ac}"); }
{ var g = new Falso(); var c = new SoloR(g, Nueva()) { CoalesceStreamingUpdates = false }; await Stream(c); await Stream(c);
  Console.WriteLine($"[3'] sólo ReadCacheAsync, streaming x2, Coalesce=false: llamadas al cliente={g.Llamadas}; contador={c.Ac}"); }
// [4] Regla (a): almacén compartido, instancia por scope que lee la versión al crearse.
{ var almacen = Nueva(); var g = new Falso(); int version = 0;
  IChatClient Scope(bool conVersion) => new Contadora(g, almacen) { CacheKeyAdditionalValues = conVersion ? ["sesion-A", version.ToString()] : ["sesion-A"] };
  foreach (var conV in new[] { true, false })
  { version = 0; var g0 = g.Llamadas;
    await Scope(conV).GetResponseAsync(msgs); var a = g.Llamadas - g0;
    version = 1; // escritura confirmada en otro pedido
    var g1 = g.Llamadas; await Scope(conV).GetResponseAsync(msgs); var b = g.Llamadas - g1;
    Console.WriteLine($"[4] {(conV ? "[SessionId, VersionDeDatos]" : "caso rojo [SessionId]")}: 1.er pedido llamadas={a}; tras escritura (v 0→1) llamadas={b} → {(b == 0 ? "ACIERTO (respuesta vieja)" : "fallo de caché")}");
    almacen = Nueva(); }
}
// [5] EnableCaching por defecto con ConversationId.
{ var g = new Falso(); var c = new Contadora(g, Nueva()); var o = new ChatOptions { ConversationId = "x" };
  await c.GetResponseAsync(msgs, o); await c.GetResponseAsync(msgs, o);
  Console.WriteLine($"[5] ConversationId con valor, x2: llamadas al cliente={g.Llamadas} (2 = no cachea)"); }
{ var g = new Falso(); var c = new SinCache(g, Nueva()); await c.GetResponseAsync(msgs); await c.GetResponseAsync(msgs); await Stream(c); await Stream(c);
  Console.WriteLine($"[5'] EnableCaching sobrescrito a false, 2 normales + 2 streaming: llamadas al cliente={g.Llamadas}"); }

class Contadora(IChatClient i, IDistributedCache d) : DistributedCachingChatClient(i, d)
{
  public int LeeR, AcR, LeeS, AcS, EsR, EsS;
  protected override async Task<ChatResponse?> ReadCacheAsync(string key, CancellationToken ct) { LeeR++; var r = await base.ReadCacheAsync(key, ct); if (r is not null) AcR++; return r; }
  protected override async Task<IReadOnlyList<ChatResponseUpdate>?> ReadCacheStreamingAsync(string key, CancellationToken ct) { LeeS++; var r = await base.ReadCacheStreamingAsync(key, ct); if (r is not null) AcS++; return r; }
  protected override Task WriteCacheAsync(string key, ChatResponse v, CancellationToken ct) { EsR++; return base.WriteCacheAsync(key, v, ct); }
  protected override Task WriteCacheStreamingAsync(string key, IReadOnlyList<ChatResponseUpdate> v, CancellationToken ct) { EsS++; return base.WriteCacheStreamingAsync(key, v, ct); }
}
class SoloR(IChatClient i, IDistributedCache d) : DistributedCachingChatClient(i, d)
{
  public int Ac;
  protected override async Task<ChatResponse?> ReadCacheAsync(string key, CancellationToken ct) { var r = await base.ReadCacheAsync(key, ct); if (r is not null) Ac++; return r; }
}
class SinCache(IChatClient i, IDistributedCache d) : DistributedCachingChatClient(i, d)
{
  protected override bool EnableCaching(IEnumerable<ChatMessage> messages, ChatOptions? options) => false;
}
class Falso : IChatClient
{
  public int Llamadas;
  public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> m, ChatOptions? o = null, CancellationToken ct = default)
  { Llamadas++; return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, "Cargaste 2."))); }
  public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> m, ChatOptions? o = null, [EnumeratorCancellation] CancellationToken ct = default)
  { Llamadas++; foreach (var t in new[] { "Carg", "aste ", "2." }) { await Task.Yield(); yield return new ChatResponseUpdate(ChatRole.Assistant, t) { MessageId = "m1" }; } }
  public object? GetService(Type t, object? k = null) => null;
  public void Dispose() { }
}
