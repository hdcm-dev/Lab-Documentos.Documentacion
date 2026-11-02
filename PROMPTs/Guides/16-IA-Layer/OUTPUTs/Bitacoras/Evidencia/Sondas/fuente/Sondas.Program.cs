// Sondas DEP-03 y DEP-13 del plan de la guía 16 (§G.3, §E.5). Fuera del repo: miden, no enseñan.
//   dotnet run -- --dep03   Ollama propio: prompt de ~4.700 tokens con num_ctx (capa única) y sin él.
//   dotnet run -- --dep13   servidor compartido: dos llamadas de clase K para calibrar t.
// Estímulo: padrón «escrito para el ejemplo» (Localidad 001…NNN, provincias de Catalogos).
using System.Globalization;
using System.Text;
using Microsoft.Extensions.AI;
using MovilidadUrbana.Asistente.Comun.AI;
using MovilidadUrbana.Asistente.Comun.Registro;
using MovilidadUrbana.Asistente.Domain;
using OllamaSharp;

var modo = args.FirstOrDefault() ?? "";
ConfiguracionDelModelo cfg;
try { cfg = ConfiguracionDelModelo.DesdeEntorno().Validar(); }
catch (ConfiguracionInvalidaException e) { Console.Error.WriteLine($"Configuración rechazada: {e.Message}"); return 1; }

return modo switch
{
    "--dep03" => await Sondas.Dep03Async(cfg),
    "--dep13" => await Sondas.Dep13Async(cfg),
    _ => 2
};

public static class Sondas
{
    private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

    public static string Fila(int i) =>
        $"Localidad {i:000} | provincia {Catalogos.Provincias[i % Catalogos.Provincias.Count]} | CP {1000 + (i * 37) % 9000:0000} | {1000 + (i * 7919) % 200000} habitantes";

    public static string Padron(int filas) =>
        string.Join("\n", Enumerable.Range(1, filas).Select(Fila));

    private static string Instrucciones(string padron, string? nonce = null) =>
        (nonce is null ? "" : $"Sesión {nonce}.\n") + $"""
        Sos el asistente del ABM de localidades de Movilidad Urbana. Respondé en castellano y sólo con lo
        que dice el padrón de abajo. Si el dato no está en el padrón, decí «No sé».

        Padrón de localidades (escrito para el ejemplo):
        {padron}
        """;

    // ---------------------------------------------------------------- DEP-03
    public static async Task<int> Dep03Async(ConfiguracionDelModelo cfg)
    {
        var c = cfg with { Endpoint = cfg.PropioEndpoint, Modelo = cfg.PropioModelo, Servidor = TipoDeServidor.Propio };
        var p = await PredicadoDeSalto.EvaluarAsync(c.Endpoint, c.Modelo, ["completion"]);
        if (p.Saltar) { Console.Error.WriteLine($"no se corre: {p.Motivo}"); return 1; }

        const string ejemplo = "DEP-03-Sonda-NumCtx";
        var instrucciones = Instrucciones(Padron(200));
        var pregunta = "¿Qué código postal tiene la Localidad 001 y en qué provincia está? Respondé en una oración.";
        var esperado = Fila(1);
        using var reg = new EscritorDeRegistro(new ContextoDeCorrida
        {
            Ejemplo = ejemplo, Configuracion = c, Adaptador = Adaptador.OllamaSharp, Modelo = c.Modelo,
            Digest = p.Digest, OllamaVersion = p.VersionDeOllama, EntradasVersion = "dep03-v1",
            EntradasHash = Hashes.Sha256(instrucciones + "\n" + pregunta),
            PaquetesHash = Hashes.DePaquetes(AppContext.BaseDirectory) ?? Hashes.DePaquetes()
        });

        // Con la capa única: AddOllamaOption(OllamaOption.NumCtx, 8192) por ConfigureOptions.
        var conCapa = FabricaDeClientes.CrearChatOllama(c.Endpoint, c.Modelo, c);
        // Sin la opción: el mismo cliente base, con razonamiento, temperatura y semilla, pero SIN num_ctx.
        var sinNumCtx = new ChatClientBuilder(new OllamaApiClient(FabricaDeClientes.CrearHttp(c.Endpoint), c.Modelo))
            .ConfigureOptions(o =>
            {
                o.Reasoning ??= new ReasoningOptions { Effort = ReasoningEffort.None };
                o.Temperature ??= c.Temperatura;
                o.Seed ??= c.Semilla;
            }).Build();

        var lineas = new List<RegistroDeLlamada>();
        async Task<RegistroDeLlamada> Llamar(int n, string paso, IChatClient cliente, bool conOpcion)
        {
            List<ChatMessage> m = [new(ChatRole.User, pregunta)];
            var o = new ChatOptions { Instructions = instrucciones, MaxOutputTokens = 60 };
            var reloj = EscritorDeRegistro.Cronometro();
            var r = await cliente.GetResponseAsync(m, o);
            var efectivas = o.Clone();
            if (conOpcion) OpcionesDelProveedor.Aplicar(efectivas, c, Adaptador.OllamaSharp);
            else { efectivas.Reasoning ??= new ReasoningOptions { Effort = ReasoningEffort.None }; efectivas.Temperature ??= c.Temperatura; efectivas.Seed ??= c.Semilla; }
            var l = reg.Llamada("n01", n, m, efectivas, r, reloj.Elapsed, paso: paso);
            reg.Escribir(l);
            lineas.Add(l);
            Console.WriteLine($"[{paso}] prompt_eval_count={l.PromptEvalCount} prompt_eval_ms={l.PromptEvalDurationMs} eval_count={l.EvalCount} " +
                $"load_ms={l.LoadDurationMs} total_ms={l.TotalDurationMs} reloj_ms={l.DuracionRelojMs} num_ctx={l.NumCtx?.ToString(Inv) ?? "null"} truncado_posible={l.TruncadoPosible?.ToString() ?? "null"}");
            Console.WriteLine($"  salida: {r.Text}");
            return l;
        }

        var con1 = await Llamar(1, "con-opcion", conCapa, true);
        var con2 = await Llamar(2, "con-opcion-repetida", conCapa, true);
        var sin = await Llamar(3, "sin-opcion", sinNumCtx, false);

        var caracteres = instrucciones.Length + pregunta.Length;
        var estimacion = GuardaDeTruncado.Estimar([new ChatMessage(ChatRole.User, pregunta)], new ChatOptions { Instructions = instrucciones });
        var pasa = con1.NumCtx == 8192 && con1.TruncadoPosible == false && sin.PromptEvalCount < con1.PromptEvalCount;
        reg.Escribir(new RegistroDeEntrada
        {
            Ejemplo = ejemplo, EntradaId = "n01", Oraculo = "dep03-num-ctx",
            Resultado = pasa ? ResultadoDeEntrada.Pasa : ResultadoDeEntrada.Falla,
            Motivo = $"con={con1.PromptEvalCount};sin={sin.PromptEvalCount};estimacion={estimacion}"
        });

        double? MsPorToken(RegistroDeLlamada l) => l.PromptEvalCount is > 0 && l.PromptEvalDurationMs is { } d ? d / l.PromptEvalCount : null;
        var frio = MsPorToken(con1); var cache = MsPorToken(con2);
        Console.WriteLine($"caracteres del prompt (instrucciones + pregunta): {caracteres}; estimación de la guarda (4,0 c/t): {estimacion}");
        Console.WriteLine($"caracteres por token medidos: {(con1.PromptEvalCount is > 0 ? (caracteres / (double)con1.PromptEvalCount).ToString("0.000", Inv) : "n/d")}");
        Console.WriteLine($"ms por token de prompt: frío {frio?.ToString("0.000", Inv)}; repetido {cache?.ToString("0.000", Inv)}; " +
            $"umbral (media geométrica) {(frio is > 0 && cache is > 0 ? Math.Sqrt(frio.Value * cache.Value).ToString("0.000", Inv) : "n/d")}");
        Console.WriteLine($"prompt_eval_count con la opción {con1.PromptEvalCount} · sin la opción {sin.PromptEvalCount}");
        Console.WriteLine($"oráculo dep03-num-ctx: {(pasa ? "pasa" : "falla")}");
        Console.WriteLine($"esperado (fila 1 del padrón): {esperado}");
        return 0;
    }

    // ---------------------------------------------------------------- DEP-13
    public static async Task<int> Dep13Async(ConfiguracionDelModelo cfg)
    {
        var p = await PredicadoDeSalto.EvaluarAsync(cfg.Endpoint, cfg.Modelo, ["completion"]);
        if (p.Saltar) { Console.Error.WriteLine($"no se corre: {p.Motivo}"); return 1; }
        const string ejemplo = "DEP-13-Sonda-Clase-K";
        var pregunta = "Describí el padrón en un párrafo de unas 70 palabras: cuántas localidades hay y de qué provincias son.";
        var padron = Padron(20);
        using var reg = new EscritorDeRegistro(new ContextoDeCorrida
        {
            Ejemplo = ejemplo, Configuracion = cfg, Adaptador = Adaptador.OllamaSharp, Modelo = cfg.Modelo,
            Digest = p.Digest, OllamaVersion = p.VersionDeOllama, EntradasVersion = "dep13-v1",
            EntradasHash = Hashes.Sha256(Instrucciones(padron) + "\n" + pregunta),
            PaquetesHash = Hashes.DePaquetes(AppContext.BaseDirectory) ?? Hashes.DePaquetes()
        });
        var cliente = FabricaDeClientes.CrearChatOllama(cfg.Endpoint, cfg.Modelo, cfg);
        var rc = 0;
        foreach (var (id, nonce) in new[] { ("k01", "K01-7f3a"), ("k02", "K02-c91e") })
        {
            var cargado = await PredicadoDeSalto.ModeloCargadoAsync(cfg.Endpoint, cfg.Modelo);
            List<ChatMessage> m = [new(ChatRole.User, pregunta)];
            // El nonce al principio de las instrucciones: ninguna de las dos reutiliza el prefijo de la otra.
            var o = new ChatOptions { Instructions = Instrucciones(padron, nonce), MaxOutputTokens = 120 };
            var reloj = EscritorDeRegistro.Cronometro();
            var r = await cliente.GetResponseAsync(m, o);
            var efectivas = o.Clone();
            OpcionesDelProveedor.Aplicar(efectivas, cfg, Adaptador.OllamaSharp);
            var l = reg.Llamada(id, 1, m, efectivas, r, reloj.Elapsed, paso: "clase-k", estadoCacheForzado: cargado == false ? "frio" : null);
            reg.Escribir(l);
            var dentro = l.DuracionRelojMs <= 80_000;
            var resultado = l.TruncadoPosible == true ? ResultadoDeEntrada.Excluida : dentro && l.PromptEvalCount <= 500 ? ResultadoDeEntrada.Pasa : ResultadoDeEntrada.Falla;
            reg.Escribir(new RegistroDeEntrada
            {
                Ejemplo = ejemplo, EntradaId = id, Oraculo = "dep13-clase-k", Resultado = resultado,
                Motivo = l.TruncadoPosible == true ? "truncado_posible" : $"pesimista_ms=80000"
            });
            double? Tps(long? n, double? ms) => n is > 0 && ms is > 0 ? n / (ms / 1000.0) : null;
            Console.WriteLine($"[{id}] p={l.PromptEvalCount} s={l.EvalCount} prompt_eval_ms={l.PromptEvalDurationMs} eval_ms={l.EvalDurationMs} load_ms={l.LoadDurationMs} " +
                $"total_ms={l.TotalDurationMs} reloj_ms={l.DuracionRelojMs} num_ctx={l.NumCtx} truncado_posible={l.TruncadoPosible} modelo_cargado_antes={cargado}");
            Console.WriteLine($"  prompt {Tps(l.PromptEvalCount, l.PromptEvalDurationMs)?.ToString("0.00", Inv)} tok/s · salida {Tps(l.EvalCount, l.EvalDurationMs)?.ToString("0.00", Inv)} tok/s · " +
                $"fórmula AJ-02 p/9,4 + s/4 = {((l.PromptEvalCount ?? 0) / 9.4 + (l.EvalCount ?? 0) / 4.0).ToString("0.0", Inv)} s · oráculo dep13-clase-k: {resultado}");
            Console.WriteLine($"  salida: {r.Text}");
            if (resultado == ResultadoDeEntrada.Excluida) rc = 1;
        }
        return rc;
    }
}
