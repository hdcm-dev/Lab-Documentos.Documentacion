using System.Diagnostics;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.Asistente.Infrastructure.AI;
using Experimento;
using OllamaSharp;

var modo = args.FirstOrDefault() ?? "fake";
Console.WriteLine($"# Experimento A-arquitectura — modo {modo} — {DateTimeOffset.Now:yyyy-MM-dd HH:mm:ss zzz}");
Console.WriteLine($"MEAI {typeof(IChatClient).Assembly.GetName().Version} · MAF {typeof(AIAgent).Assembly.GetName().Version} · OllamaSharp {typeof(OllamaApiClient).Assembly.GetName().Version}");

var corpus = CorpusDeRequisitos.Leer();
Console.WriteLine($"[1] Corpus leído de LocalidadPolicy y EncuestaPolicy por reflexión: {corpus.Count} enunciados");
foreach (var r in corpus) Console.WriteLine($"    {r.Id} → «{r.Texto}»");

var localidades = new LocalidadService(new RepositorioEnMemoria());   // caso de uso COPIADO, sin cambios
string pCp = "¿Cuántos dígitos lleva el código postal de una localidad?";
string pCuenta = "¿Cuántas localidades hay cargadas en la provincia de Corrientes?";

if (modo == "fake")
{
    var buscador = new BuscadorDeRequisitos(new EmbeddingsFnv());
    await buscador.IndexarAsync(corpus);
    var opciones = new ChatOptions();

    var chatA = new ChatGuionado();
    var a = await new AyudaRag(buscador, chatA, opciones).ResponderAsync(pCp);
    Console.WriteLine($"[2] Vía A (RAG fijo, sin agente): fuentes={string.Join(",", a.Fuentes)}; llamadas al modelo={chatA.Registro.Count}; {string.Join(" / ", chatA.Registro)}");

    var chatB = new ChatGuionado();
    var conHerr = chatB.AsBuilder().UseFunctionInvocation().Build();
    var asis = new AsistenteDeMovilidadLlm(conHerr, opciones, buscador, localidades);
    foreach (var p in new[] { pCp, pCuenta })
    {
        chatB.Registro.Clear();
        var t = await asis.ResponderAsync(p);
        Console.WriteLine($"[3] Vía B (recuperación como herramienta) «{p}» → {t}");
        foreach (var l in chatB.Registro) Console.WriteLine($"      {l}");
    }

    var chatC = new ChatGuionado();
    AIAgent agente = new ChatClientAgent(chatC, new ChatClientAgentOptions { AIContextProviders = [new ProveedorDeRequisitos(buscador)] });
    var rc = await agente.RunAsync(pCp);
    Console.WriteLine($"[4] Vía C (AIContextProvider de MAF) → {rc.Text}");
    foreach (var l in chatC.Registro) Console.WriteLine($"      {l}");
    return;
}

// --- modo real: Ollama propio por variables (R-PRIV: el endpoint no se imprime) ---
var endpoint = new Uri(Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT") ?? "http://localhost:11434");
var modelo = Environment.GetEnvironmentVariable("OLLAMA_MODEL") ?? "qwen3.5:4b";
var modeloEmb = Environment.GetEnvironmentVariable("OLLAMA_EMBEDDING_MODEL") ?? "qwen3-embedding:0.6b";
int n = int.Parse(Environment.GetEnvironmentVariable("N") ?? "5");
var http = new HttpClient { BaseAddress = endpoint, Timeout = TimeSpan.FromMinutes(5) };
var buscadorR = new BuscadorDeRequisitos(new OllamaApiClient(http, modeloEmb));
var sw = Stopwatch.StartNew(); await buscadorR.IndexarAsync(corpus);
Console.WriteLine($"[R1] Embeddings {modeloEmb} vía IEmbeddingGenerator (OllamaSharp): dimensión {buscadorR.Dimension}; indexar 12 enunciados {sw.ElapsedMilliseconds} ms");
foreach (var p in new[] { pCp, "¿Qué edad tiene que tener quien responde la encuesta?", "¿Cuántos medios de transporte hay que elegir?" })
    Console.WriteLine($"      top-3 «{p}» → {string.Join(", ", (await buscadorR.BuscarAsync(p)).Select(f => f.Id))}");

IChatClient chat = new OllamaApiClient(http, modelo);
ChatOptions Opciones(int seed) => new() { Temperature = 0.7f, Seed = seed, MaxOutputTokens = 300,
    RawRepresentationFactory = _ => new OllamaSharp.Models.Chat.ChatRequest { Think = false } };
Console.WriteLine($"[R2] Chat {modelo}; Temperature 0.7, Seed=i, MaxOutputTokens 300, think=false (RawRepresentationFactory)");

sw.Restart(); var ra = await new AyudaRag(buscadorR, chat, Opciones(1)).ResponderAsync(pCp);
Console.WriteLine($"[R3] Vía A (RAG fijo) {sw.ElapsedMilliseconds} ms; fuentes={string.Join(",", ra.Fuentes)}\n      respuesta: {ra.Texto.Replace("\n", " ")}");

var asisR = new AsistenteDeMovilidadLlm(chat, Opciones(1), buscadorR, localidades);
foreach (var (p, esperada) in new[] { (pCp, "buscar_requisitos"), (pCuenta, "contar_localidades_por_provincia") })
{
    int ok = 0;
    for (int i = 1; i <= n; i++)
    {
        var o = Opciones(i); o.Tools = asisR.Herramientas();
        sw.Restart();
        var r = await chat.GetResponseAsync([
            new(ChatRole.System, "Sos el asistente de Movilidad Urbana. Usá las herramientas; no inventes datos."), new(ChatRole.User, p)], o);
        var llamadas = r.Messages.SelectMany(m => m.Contents).OfType<FunctionCallContent>().ToList();
        bool exito = llamadas.Count == 1 && llamadas[0].Name == esperada;
        if (exito) ok++;
        Console.WriteLine($"      [R4] corrida {i} «{p[..30]}…» → [{string.Join(";", llamadas.Select(c => c.Name + System.Text.Json.JsonSerializer.Serialize(c.Arguments)))}] finish={r.FinishReason} {sw.ElapsedMilliseconds} ms {(exito ? "OK" : "FALLA")}");
    }
    Console.WriteLine($"[R4] Vía B, elección de herramienta para «{p}»: {ok}/{n} piden sólo {esperada}");
}
var conHerrR = chat.AsBuilder().UseFunctionInvocation().Build();
foreach (var p in new[] { pCp, pCuenta })
{
    sw.Restart(); var t = await new AsistenteDeMovilidadLlm(conHerrR, Opciones(1), buscadorR, localidades).ResponderAsync(p);
    Console.WriteLine($"[R5] Vía B completa (UseFunctionInvocation) «{p}» {sw.ElapsedMilliseconds} ms → {t.Replace("\n", " ")}");
}
