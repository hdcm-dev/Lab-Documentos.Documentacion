// Sonda B-abstracciones-agentes (integración de la guía 16, 2026-10-28).
// Dominio: Movilidad Urbana (catálogo Medios y Provincias copiados de MovilidadUrbana.ApiWeb/Domain/Catalogos.cs).
// Los conteos y las localidades de E-B4 son DATOS SINTÉTICOS de la sonda, no del caso base.
// El endpoint sale sólo de OLLAMA_ENDPOINT y nunca se imprime (R-PRIV).
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics.Tensors;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OllamaSharp;
using OpenAI;

var endpoint = Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT") ?? "http://localhost:11434";
var model = Environment.GetEnvironmentVariable("OLLAMA_MODEL") ?? "qwen3.5:4b";
var embedModel = Environment.GetEnvironmentVariable("OLLAMA_EMBED_MODEL") ?? "qwen3-embedding:0.6b";
int n = int.TryParse(Environment.GetEnvironmentVariable("N"), out var nn) ? nn : 5;
var pasos = (args.Length > 0 ? args[0] : "b1,b2,b3,b4").Split(',');

string Limpio(string s) => s.Replace(endpoint.TrimEnd('/'), "<OLLAMA_ENDPOINT>");
void Log(object o) => Console.WriteLine(Limpio(JsonSerializer.Serialize(o)));

var captura = new Captura();
HttpClient NuevoHttp() => new(new CapturaHandler(captura) { InnerHandler = new HttpClientHandler() })
{ BaseAddress = new Uri(endpoint), Timeout = TimeSpan.FromMinutes(10) };

IChatClient Base(string via, string m) => via switch
{
    "ollama" => new OllamaApiClient(NuevoHttp(), m),
    "openai" => new OpenAIClient(new ApiKeyCredential("ollama"), new OpenAIClientOptions
    {
        Endpoint = new Uri(endpoint.TrimEnd('/') + "/v1"),
        Transport = new HttpClientPipelineTransport(NuevoHttp()),
        NetworkTimeout = TimeSpan.FromMinutes(10)
    }).GetChatClient(m).AsIChatClient(),
    _ => throw new ArgumentException(via)
};

ChatOptions SinRazonamiento(ChatOptions? o = null)
{
    o ??= new ChatOptions();
    if (model.StartsWith("qwen3")) o.Reasoning = new ReasoningOptions { Effort = ReasoningEffort.None };
    o.Temperature = 0.7f;
    return o;
}

Log(new { paso = "inicio", fecha = DateTimeOffset.Now.ToString("o"), model, embedModel, n, meai = typeof(IChatClient).Assembly.GetName().Version?.ToString(), ollamasharp = typeof(OllamaApiClient).Assembly.GetName().Version?.ToString(), maf = typeof(AIAgent).Assembly.GetName().Version?.ToString() });

// ---------- E-B1: tool calling por las dos vías, con validación del argumento en la aplicación ----------
if (pasos.Contains("b1"))
{
    foreach (var (via, m) in new[] { ("ollama", model), ("openai", model), ("ollama", "qwen2.5:0.5b") })
    {
        for (int i = 1; i <= n; i++)
        {
            Herramientas.Reiniciar();
            captura.Etiqueta = $"b1-{via}-{m}";
            IChatClient chat = Base(via, m).AsBuilder()
                .UseFunctionInvocation(configure: f => { f.MaximumIterationsPerRequest = 4; f.MaximumConsecutiveErrorsPerRequest = 2; })
                .Build();
            var opts = new ChatOptions { Tools = [AIFunctionFactory.Create(Herramientas.ContarRespuestasPorMedio, "contar_respuestas_por_medio")], Seed = i };
            if (m == model) SinRazonamiento(opts); else opts.Temperature = 0.7f;
            var sw = Stopwatch.StartNew();
            string texto, error = "";
            try
            {
                var r = await chat.GetResponseAsync(
                    [new(ChatRole.System, "Respondé usando las herramientas disponibles cuando hagan falta."),
                     new(ChatRole.User, "¿Cuánta gente contestó en la encuesta de Movilidad Urbana que va a pie?")], opts);
                texto = r.Text;
            }
            catch (Exception ex) { texto = ""; error = ex.GetType().Name + ": " + ex.Message; }
            sw.Stop();
            bool exito = Herramientas.Llamadas.Contains("caminata") && texto.Contains("18");
            Log(new { paso = "b1", via, modelo = m, corrida = i, seed = i, pared_s = Math.Round(sw.Elapsed.TotalSeconds, 2), argumentos = Herramientas.Llamadas, rechazados_por_la_app = Herramientas.Rechazos, exito, texto = Recortar(texto), error });
        }
    }
}

// ---------- E-B2: salida estructurada GetResponseAsync<T> por las dos vías ----------
if (pasos.Contains("b2"))
{
    var prompt = "Extraé los datos de la localidad del texto. Provincias válidas: " + string.Join(", ", Catalogos.Provincias) +
                 ". El código postal es de 4 dígitos y los habitantes son un entero.\nTexto: «Agregá Goya, Corrientes, CP 3450, unos 90 mil habitantes»";
    foreach (var (via, esquema, veces) in new[] { ("ollama", true, n), ("openai", true, n), ("ollama", false, 3) })
    {
        for (int i = 1; i <= veces; i++)
        {
            captura.Etiqueta = $"b2-{via}-schema{esquema}";
            IChatClient chat = Base(via, model);
            var opts = SinRazonamiento(new ChatOptions { Seed = i });
            var sw = Stopwatch.StartNew();
            bool forma = false; LocalidadPropuesta? p = null; string error = "", crudo = "";
            try
            {
                var r = await chat.GetResponseAsync<LocalidadPropuesta>(prompt, opts, useJsonSchemaResponseFormat: esquema);
                crudo = r.Text;
                forma = r.TryGetResult(out p);
            }
            catch (Exception ex) { error = ex.GetType().Name + ": " + ex.Message; }
            sw.Stop();
            var errores = p is null ? ["sin resultado"] : Reglas.Validar(p);
            bool exacto = p is { Nombre: "Goya", Provincia: "Corrientes", CodigoPostal: "3450", Habitantes: 90000 };
            Log(new { paso = "b2", via, useJsonSchemaResponseFormat = esquema, corrida = i, seed = i, pared_s = Math.Round(sw.Elapsed.TotalSeconds, 2), forma_valida = forma, propuesta = p, errores_de_dominio = errores, igual_a_lo_esperado = exacto, crudo = Recortar(crudo), error });
        }
    }
}

// ---------- E-B3: agente de Agent Framework sobre el MISMO IChatClient (sesión + aprobación) ----------
if (pasos.Contains("b3"))
{
    int veces = Math.Min(n, 3);
    for (int i = 1; i <= veces; i++)
    {
        Herramientas.Reiniciar();
        captura.Etiqueta = "b3-agente";
        IChatClient baseClient = Base("ollama", model).AsBuilder()
            .ConfigureOptions(o => { o.Reasoning = new ReasoningOptions { Effort = ReasoningEffort.None }; o.Temperature = 0.7f; })
            .Build();
        AIAgent agente = baseClient.AsAIAgent(
            instructions: "Sos el asistente de Movilidad Urbana. Respondé usando las herramientas disponibles cuando hagan falta.",
            name: "AsistenteMovilidad",
            tools: [AIFunctionFactory.Create(Herramientas.ContarRespuestasPorMedio, "contar_respuestas_por_medio"),
                    new ApprovalRequiredAIFunction(AIFunctionFactory.Create(Herramientas.EliminarLocalidad, "eliminar_localidad"))]);
        var sw = Stopwatch.StartNew();
        string t1 = "", t2 = "", error = "";
        try
        {
            AgentSession s = await agente.CreateSessionAsync();
            t1 = (await agente.RunAsync("¿Cuánta gente contestó en la encuesta que va a pie?", s)).Text;
            t2 = (await agente.RunAsync("¿Y en bicicleta?", s)).Text;
        }
        catch (Exception ex) { error = ex.GetType().Name + ": " + ex.Message; }
        var sesionPared = Math.Round(sw.Elapsed.TotalSeconds, 2);
        bool exitoSesion = Herramientas.Llamadas.Contains("caminata") && Herramientas.Llamadas.Contains("bicicleta") && t1.Contains("18") && t2.Contains("12");
        Log(new { paso = "b3-sesion", corrida = i, pared_s = sesionPared, argumentos = Herramientas.Llamadas.ToArray(), exito = exitoSesion, turno1 = Recortar(t1), turno2 = Recortar(t2), error });

        // Aprobación: la baja pide aprobación; se rechaza y se comprueba que no se ejecutó.
        sw.Restart(); error = "";
        int pedidos = 0; string? nombreLlamada = null, argsLlamada = null; string tRechazo = "";
        try
        {
            AgentSession s2 = await agente.CreateSessionAsync();
            var r = await agente.RunAsync("Borrá la localidad Resistencia.", s2);
            var reqs = r.Messages.SelectMany(mm => mm.Contents).OfType<ToolApprovalRequestContent>().ToList();
            pedidos = reqs.Count;
            if (reqs.Count > 0)
            {
                var llamada = (FunctionCallContent)reqs[0].ToolCall;
                nombreLlamada = llamada.Name; argsLlamada = JsonSerializer.Serialize(llamada.Arguments);
                var resp = await agente.RunAsync(new ChatMessage(ChatRole.User, [reqs[0].CreateResponse(false)]), s2);
                tRechazo = resp.Text;
            }
            else tRechazo = r.Text;
        }
        catch (Exception ex) { error = ex.GetType().Name + ": " + ex.Message; }
        Log(new { paso = "b3-aprobacion", corrida = i, pared_s = Math.Round(sw.Elapsed.TotalSeconds, 2), pedidos_de_aprobacion = pedidos, herramienta = nombreLlamada, argumentos = argsLlamada, eliminaciones_ejecutadas = Herramientas.Eliminaciones, texto_tras_rechazo = Recortar(tRechazo), error });
    }
}

// ---------- E-B4: ESC-01 por similitud (RAG) frente a herramienta exacta ----------
if (pasos.Contains("b4"))
{
    captura.Etiqueta = "b4-embed";
    IEmbeddingGenerator<string, Embedding<float>> gen = new OllamaApiClient(NuevoHttp(), embedModel);
    var filas = Localidades.Sinteticas;
    var textos = filas.Select(f => $"Localidad {f.Nombre}, provincia de {f.Provincia}, código postal {f.CodigoPostal}, {f.Habitantes} habitantes.").ToList();
    var vecs = await gen.GenerateAsync(textos);
    foreach (var pregunta in new[] { "¿Cuántas localidades hay en la provincia de Corrientes?", "¿Cuántas localidades de Chaco están registradas?" })
    {
        var q = (await gen.GenerateAsync([pregunta]))[0].Vector;
        var orden = filas.Select((f, k) => (f, score: TensorPrimitives.CosineSimilarity(q.Span, vecs[k].Vector.Span)))
                         .OrderByDescending(x => x.score).ToList();
        string prov = pregunta.Contains("Corrientes") ? "Corrientes" : "Chaco";
        foreach (int k in new[] { 3, 5 })
        {
            var top = orden.Take(k).ToList();
            Log(new { paso = "b4", pregunta, k, dimension = vecs[0].Vector.Length, top = top.Select(x => $"{x.f.Nombre} ({x.f.Provincia}) {x.score:0.000}"), de_la_provincia_en_topk = top.Count(x => x.f.Provincia == prov), ajenas_en_topk = top.Count(x => x.f.Provincia != prov), conteo_exacto_por_herramienta = filas.Count(f => f.Provincia == prov) });
        }
    }
}

foreach (var (etq, resumen) in captura.Resumenes) Log(new { paso = "captura-http", etiqueta = etq, resumen });
Log(new { paso = "fin", fecha = DateTimeOffset.Now.ToString("o") });

static string Recortar(string s) => s.Length > 300 ? s[..300] + "…" : s;

static class Catalogos
{
    public static readonly string[] Provincias = ["Buenos Aires", "Chaco", "Córdoba", "Corrientes", "Entre Ríos", "Mendoza", "Santa Fe"];
    public static readonly (string Clave, string Etiqueta)[] Medios =
        [("colectivo", "Colectivo"), ("auto", "Auto particular"), ("bicicleta", "Bicicleta"), ("moto", "Moto"), ("caminata", "A pie"), ("tren", "Tren")];
}

public sealed record LocalidadPropuesta(string Nombre, string Provincia, string CodigoPostal, int Habitantes);

static class Reglas
{
    public static List<string> Validar(LocalidadPropuesta p)
    {
        var e = new List<string>();
        if (string.IsNullOrWhiteSpace(p.Nombre)) e.Add("nombre vacío");
        if (!Catalogos.Provincias.Contains(p.Provincia)) e.Add($"provincia fuera de catálogo: {p.Provincia}");
        if (!Regex.IsMatch(p.CodigoPostal ?? "", "^[0-9]{4}$")) e.Add($"código postal inválido: {p.CodigoPostal}");
        if (p.Habitantes < 1) e.Add($"habitantes < 1: {p.Habitantes}");
        return e;
    }
}

static class Herramientas
{
    // Conteos SINTÉTICOS de la sonda (no salen del caso base, que no tiene consulta de resultados).
    static readonly Dictionary<string, int> Conteos = new() { ["colectivo"] = 41, ["auto"] = 23, ["bicicleta"] = 12, ["moto"] = 7, ["caminata"] = 18, ["tren"] = 4 };
    public static List<string> Llamadas { get; } = [];
    public static int Rechazos { get; private set; }
    public static int Eliminaciones { get; private set; }
    public static void Reiniciar() { Llamadas.Clear(); Rechazos = 0; Eliminaciones = 0; }

    [Description("Devuelve cuántas respuestas de la encuesta de Movilidad Urbana declararon un medio de transporte.")]
    public static string ContarRespuestasPorMedio(
        [Description("Clave del medio de transporte de la encuesta: colectivo, auto, bicicleta, moto, caminata o tren.")] string medio)
    {
        Llamadas.Add(medio);
        if (!Catalogos.Medios.Any(m => m.Clave == medio))
        {
            Rechazos++;
            return $"ERROR: '{medio}' no es una clave del catálogo de medios. Claves válidas: {string.Join(", ", Catalogos.Medios.Select(m => $"{m.Clave} ({m.Etiqueta})"))}.";
        }
        return $"{Conteos[medio]} respuestas declararon el medio '{medio}'.";
    }

    [Description("Da de baja una localidad por nombre. Acción destructiva.")]
    public static string EliminarLocalidad([Description("Nombre de la localidad")] string nombre)
    {
        Eliminaciones++;
        return $"Se eliminó la localidad {nombre}.";
    }
}

static class Localidades
{
    // DATOS SINTÉTICOS de la sonda (el caso base siembra sólo Corrientes y Resistencia).
    public static readonly LocalidadPropuesta[] Sinteticas =
    [
        new("Corrientes", "Corrientes", "3400", 400000), new("Resistencia", "Chaco", "3500", 300000),
        new("Goya", "Corrientes", "3450", 90000), new("Bella Vista", "Corrientes", "3432", 35000),
        new("Paso de los Libres", "Corrientes", "3230", 45000), new("Barranqueras", "Chaco", "3503", 55000),
        new("Rosario", "Santa Fe", "2000", 950000), new("Paraná", "Entre Ríos", "3100", 250000)
    ];
}

sealed class Captura
{
    public string Etiqueta { get; set; } = "";
    public Dictionary<string, string> Resumenes { get; } = [];
}

// Registra, una vez por etiqueta, la ruta relativa y las claves relevantes del cuerpo (sin host).
sealed class CapturaHandler(Captura c) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage req, CancellationToken ct)
    {
        if (!c.Resumenes.ContainsKey(c.Etiqueta) && req.Content is not null)
        {
            var body = await req.Content.ReadAsStringAsync(ct);
            try
            {
                using var d = JsonDocument.Parse(body);
                var r = d.RootElement;
                string Val(string k) => r.TryGetProperty(k, out var v) ? (v.ValueKind == JsonValueKind.Object ? "objeto{" + string.Join(",", v.EnumerateObject().Select(p => p.Name)) + "}" : v.ToString()) : "-";
                c.Resumenes[c.Etiqueta] = $"{req.Method} {req.RequestUri?.AbsolutePath} claves=[{string.Join(",", r.EnumerateObject().Select(p => p.Name))}] format={Val("format")} response_format={Val("response_format")} think={Val("think")} reasoning_effort={Val("reasoning_effort")} options={Val("options")}";
            }
            catch { c.Resumenes[c.Etiqueta] = $"{req.Method} {req.RequestUri?.AbsolutePath} (cuerpo no JSON)"; }
        }
        return await base.SendAsync(req, ct);
    }
}
