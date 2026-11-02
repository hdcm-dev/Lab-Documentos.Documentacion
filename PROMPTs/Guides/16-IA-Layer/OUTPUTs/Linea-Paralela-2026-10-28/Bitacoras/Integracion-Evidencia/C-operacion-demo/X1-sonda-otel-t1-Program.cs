// Sonda C-operacion-demo (2026-10-28). Sin modelo: IChatClient guionado.
// [A] ¿Qué nombre de ActivitySource/Meter usa UseOpenTelemetry(sourceName: ...)? ¿Lo exporta el SDK si AddSource usa el nombre por defecto?
// [B] T1 (N6 §8.3): ¿qué IServiceProvider llega a AIFunctionArguments.Services con AddChatClient singleton vs scoped?
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry;
using OpenTelemetry.Trace;

// ---------- [A] nombres de fuente y medidor ----------
foreach (var nombre in new string?[] { null, "MovilidadUrbana.AI" })
{
    var fuentes = new HashSet<string>(); var medidores = new HashSet<string>();
    using var al = new ActivityListener { ShouldListenTo = s => true, Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
        ActivityStarted = a => { if (a.OperationName.StartsWith("chat")) fuentes.Add(a.Source.Name); } };
    ActivitySource.AddActivityListener(al);
    using var ml = new MeterListener { InstrumentPublished = (i, l) => { if (i.Name.StartsWith("gen_ai")) medidores.Add(i.Meter.Name); } };
    ml.Start();
    IChatClient c = new Guion().AsBuilder().UseOpenTelemetry(sourceName: nombre).Build();
    await c.GetResponseAsync("¿Cuántas localidades hay en Corrientes?");
    Console.WriteLine($"[A] sourceName={nombre ?? "(por defecto)"} -> ActivitySource={string.Join(",", fuentes)} Meter={string.Join(",", medidores)}");
}
// Con el SDK: AddSource con el nombre por defecto frente a un cliente con sourceName propio
foreach (var (registrada, delCliente) in new[] { ("Experimental.Microsoft.Extensions.AI", "MovilidadUrbana.AI"), ("MovilidadUrbana.AI", "MovilidadUrbana.AI") })
{
    var exportadas = new List<Activity>();
    using (var tp = Sdk.CreateTracerProviderBuilder().AddSource(registrada).AddInMemoryExporter(exportadas).Build())
    {
        IChatClient c = new Guion().AsBuilder().UseOpenTelemetry(sourceName: delCliente).Build();
        await c.GetResponseAsync("¿Cuántas localidades hay en Corrientes?");
    }
    Console.WriteLine($"[A] SDK AddSource(\"{registrada}\") + cliente sourceName=\"{delCliente}\" -> spans exportados: {exportadas.Count}");
}

// ---------- [B] T1: servicios que ve la herramienta ----------
foreach (var vida in new[] { ServiceLifetime.Singleton, ServiceLifetime.Scoped })
{
    var sc = new ServiceCollection();
    sc.AddScoped<SessionContext>();
    sc.AddChatClient(_ => new Guion(), vida).UseFunctionInvocation();
    using var root = sc.BuildServiceProvider(new ServiceProviderOptions { ValidateScopes = true });
    var quienSoy = AIFunctionFactory.Create((AIFunctionArguments args) =>
    {
        var sp = args.Services;
        if (sp is null) return "Services=null";
        try { return $"SessionId={sp.GetRequiredService<SessionContext>().SessionId ?? "(vacío)"}"; }
        catch (Exception e) { return $"{e.GetType().Name}: {e.Message.Split('.')[0]}"; }
    }, "quien_soy");
    foreach (var sesion in new[] { "sesion-A", "sesion-B" })
    {
        using var scope = root.CreateScope();
        scope.ServiceProvider.GetRequiredService<SessionContext>().SessionId = sesion;
        var chat = scope.ServiceProvider.GetRequiredService<IChatClient>();
        var r = await chat.GetResponseAsync("¿quién soy?", new ChatOptions { Tools = [quienSoy] });
        Console.WriteLine($"[B] AddChatClient {vida}, scope {sesion} -> herramienta vio: {r.Text}");
    }
}

sealed class SessionContext { public string? SessionId { get; set; } }

// Cliente guionado: si no hay resultado de herramienta, pide «quien_soy»; si lo hay, lo devuelve como texto.
sealed class Guion : IChatClient
{
    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken ct = default)
    {
        var res = messages.SelectMany(m => m.Contents).OfType<FunctionResultContent>().LastOrDefault();
        if (res is null && options?.Tools is { Count: > 0 })
            return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, [new FunctionCallContent("c1", "quien_soy")])));
        return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, res?.Result?.ToString() ?? "Hay 1 localidad."))
            { ModelId = "guion", Usage = new UsageDetails { InputTokenCount = 12, OutputTokenCount = 8 } });
    }
    public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
    { foreach (var u in (await GetResponseAsync(messages, options, ct)).ToChatResponseUpdates()) yield return u; }
    public object? GetService(Type t, object? k = null) => t.IsInstanceOfType(this) ? this : null;
    public void Dispose() { }
}
