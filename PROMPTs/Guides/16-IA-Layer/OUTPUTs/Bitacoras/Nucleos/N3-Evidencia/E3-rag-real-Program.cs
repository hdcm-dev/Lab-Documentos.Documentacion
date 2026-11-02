using System.Diagnostics;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using CommunityToolkit.VectorData.InMemory;
using OllamaSharp;

var embedEndpoint = new Uri(Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT") ?? "http://localhost:11434");
var chatEndpoint  = new Uri(Environment.GetEnvironmentVariable("OLLAMA_CHAT_ENDPOINT") ?? embedEndpoint.ToString());

(string Id, string Fuente, string Texto)[] corpus = [
 ("loc-nombre","reglas/localidad#nombre","El nombre de una localidad debe tener entre 3 y 60 caracteres y no puede repetirse dentro de la misma provincia."),
 ("loc-cp","reglas/localidad#codigo-postal","El código postal de una localidad se compone de exactamente 4 dígitos numéricos."),
 ("loc-hab","reglas/localidad#habitantes","La cantidad de habitantes es un número entero de 1 en adelante, sin máximo."),
 ("loc-baja","reglas/localidad#baja","Borrar una localidad no afecta las respuestas de encuesta ya registradas, porque guardan el nombre y no la clave."),
 ("enc-edad","reglas/encuesta#edad","Quien responde la encuesta debe tener entre 16 y 110 años, ambos bordes incluidos."),
 ("enc-dist","reglas/encuesta#distancia","La distancia recorrida por día va de 0 a 500 km; cero es válido porque se puede no viajar."),
 ("enc-min","reglas/encuesta#minutos","El tiempo de viaje diario va de 1 a 600 minutos; cero minutos no es válido."),
 ("enc-medios","catalogo#medios","Los medios de transporte posibles son colectivo, auto particular, bicicleta, moto, a pie y tren; hay que elegir al menos uno."),
 ("enc-frec","catalogo#frecuencias","La frecuencia de uso puede ser todos los días, algunos días por semana u ocasionalmente."),
 ("enc-motivo","catalogo#motivos","El motivo principal del viaje es trabajo, estudio, salud u otros."),
 ("enc-pasos","reglas/encuesta#pasos","La encuesta es un asistente de tres pasos: datos personales, hábitos de viaje y motivo con confirmación."),
 ("sesion","persistencia#sesion","Cada visitante tiene su propia sesión y sus datos quedan aislados del resto en la misma base SQLite."),
];
(string Q, string Gold)[] preguntas = [
 ("¿Cuántos números lleva el CP?","loc-cp"),
 ("¿Puedo cargar dos pueblos con el mismo nombre en una provincia?","loc-nombre"),
 ("¿Un chico de 15 años puede contestar?","enc-edad"),
 ("Si no viajo, ¿qué pongo en kilómetros?","enc-dist"),
 ("¿Se puede ir caminando como medio?","enc-medios"),
 ("Si elimino una ciudad, ¿se pierden las encuestas?","loc-baja"),
 ("¿Qué opciones hay para la razón del viaje?","enc-motivo"),
 ("¿Los datos de otro usuario se mezclan con los míos?","sesion"),
];

var ollama = new OllamaApiClient(embedEndpoint);
foreach (var (model, docPrefix, qPrefix) in new[]{ ("nomic-embed-text","",""), ("nomic-embed-text","search_document: ","search_query: "), ("qwen3-embedding:0.6b","","") })
{
  ollama.SelectedModel = model;
  IEmbeddingGenerator<string, Embedding<float>> gen = ollama;
  var sw = Stopwatch.StartNew();
  var docVecs = await gen.GenerateAsync(corpus.Select(c => docPrefix + c.Texto));
  var dims = docVecs[0].Vector.Length;
  var def = new VectorStoreCollectionDefinition { Properties = [
    new VectorStoreKeyProperty("Id", typeof(string)), new VectorStoreDataProperty("Fuente", typeof(string)), new VectorStoreDataProperty("Texto", typeof(string)),
    new VectorStoreVectorProperty("Vector", typeof(ReadOnlyMemory<float>), dimensions: dims){ DistanceFunction = DistanceFunction.CosineSimilarity } ]};
  var store = new InMemoryVectorStore();
  var col = store.GetCollection<string, Frag>("frag", def);
  await col.EnsureCollectionExistsAsync();
  await col.UpsertAsync(corpus.Select((c,i) => new Frag{ Id=c.Id, Fuente=c.Fuente, Texto=c.Texto, Vector=docVecs[i].Vector }));
  int hit1=0, hit3=0; double mrr=0;
  foreach (var (q,gold) in preguntas) {
    var qv = await gen.GenerateVectorAsync(qPrefix + q);
    var ids = new List<string>(); await foreach (var r in col.SearchAsync(qv, top: 5)) ids.Add(r.Record.Id);
    var rank = ids.IndexOf(gold) + 1;
    if (rank==1) hit1++; if (rank is >=1 and <=3) hit3++; if (rank>0) mrr += 1.0/rank;
    if (rank!=1) Console.WriteLine($"   miss [{model}{(docPrefix!=""?"+prefijos":"")}] '{q}' -> {string.Join(",",ids.Take(3))} (gold rank {rank})");
  }
  Console.WriteLine($"{model}{(docPrefix!=""?" +prefijos":"")}: dims={dims} recall@1={hit1}/{preguntas.Length} recall@3={hit3}/{preguntas.Length} MRR@5={mrr/preguntas.Length:F3} t={sw.ElapsedMilliseconds}ms");
}

// Generación con citas (consulta → top-3 → prompt con fuentes)
if (Environment.GetEnvironmentVariable("OLLAMA_CHAT_MODEL") is { } chatModel) {
  ollama.SelectedModel = "qwen3-embedding:0.6b"; IEmbeddingGenerator<string, Embedding<float>> gen = ollama;
  var store = new InMemoryVectorStore(new() { EmbeddingGenerator = gen });
  var col = store.GetCollection<string, FragAuto>("auto");
  await col.EnsureCollectionExistsAsync();
  await col.UpsertAsync(corpus.Select(c => new FragAuto{ Id=c.Id, Fuente=c.Fuente, Texto=c.Texto, Vector=c.Texto }));
  var pregunta = "Si no viajo, ¿qué pongo en kilómetros y en minutos?";
  var ctx = new List<string>(); await foreach (var r in col.SearchAsync(pregunta, top: 3)) ctx.Add($"[{r.Record.Fuente}] {r.Record.Texto}");
  IChatClient chat = new OllamaApiClient(new HttpClient { BaseAddress = chatEndpoint, Timeout = TimeSpan.FromMinutes(10) }, chatModel); var swc = Stopwatch.StartNew();
  var resp = await chat.GetResponseAsync([
    new(ChatRole.System, "Respondé sólo con la información de las FUENTES. Citá cada afirmación con su [fuente]. Si las fuentes no alcanzan, decí que no sabés."),
    new(ChatRole.User, "FUENTES:\n" + string.Join("\n", ctx) + "\n\nPREGUNTA: " + pregunta)], new ChatOptions{ Temperature = 0 });
  Console.WriteLine("CONTEXTO:\n" + string.Join("\n", ctx));
  Console.WriteLine($"RESPUESTA ({chatModel}, {swc.ElapsedMilliseconds} ms):\n" + resp.Text);
}

public class Frag { public string Id {get;set;} public string Fuente {get;set;} public string Texto {get;set;} public ReadOnlyMemory<float> Vector {get;set;} }
public class FragAuto {
  [VectorStoreKey] public string Id {get;set;}
  [VectorStoreData] public string Fuente {get;set;}
  [VectorStoreData] public string Texto {get;set;}
  [VectorStoreVector(1024, DistanceFunction = DistanceFunction.CosineSimilarity)] public string Vector {get;set;}
}
