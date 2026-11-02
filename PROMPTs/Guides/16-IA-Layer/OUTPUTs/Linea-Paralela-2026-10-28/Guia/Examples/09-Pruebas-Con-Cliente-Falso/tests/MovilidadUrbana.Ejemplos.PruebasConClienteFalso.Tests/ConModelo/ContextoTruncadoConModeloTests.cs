using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests.ConModelo;

/// <summary>
/// num_ctx llega al servidor y el detector ve el truncado, contra el modelo de chat.
/// Prompt: 185 líneas «Localidad i: código postal 3000+i, …» y la pregunta por la Localidad 1, que queda en la
/// zona que se descarta si se trunca. Cada semilla lleva su encabezado («Planilla s»), así el prefijo no se reusa.
/// Criterio escrito antes de correr (invariantes; fallan ante una sola violación):
///  (1) con NumCtx de las opciones (8192), InputTokenCount = L supera el num_ctx corto (4096): la prueba discrimina;
///  (2) con num_ctx corto y largo esperado L, el detector lanza ContextoTruncadoException en cada semilla;
///  (3) Usage.CachedInputTokenCount llega null por OllamaSharp 5.5.0 y el handler lee prompt_eval_count = L.
/// Se informa sin umbral (existencia): la respuesta con 8192 es «3001».
/// </summary>
[TestFixture, Category("ConModelo")]
public sealed class ContextoTruncadoConModeloTests
{
    [Test]
    public async Task NumCtxLlega_YElDetectorVeElTruncado()
    {
        int n = int.Parse(ServidorDePrueba.Pruebas["SemillasDelTruncado"]!);
        int lineas = int.Parse(ServidorDePrueba.Pruebas["LineasDelPromptLargo"]!);
        int corto = int.Parse(ServidorDePrueba.Pruebas["NumCtxCorto"]!);
        using var host = ServidorDePrueba.Anfitrion(new());
        var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
        var (version, digest) = await ServidorDePrueba.Identificar(host);
        var chat = host.Services.GetRequiredKeyedService<IChatClient>(ComposicionDeIA.ClaveDelProveedor);
        var registro = new RegistroRllm("contexto-truncado");
        var m = ia.Muestreo;
        registro.Linea($"# R-LLM — invariantes n/n — estimando: este pedido, 1 pedido × {n} semillas (s = 1..{n}) por num_ctx, " +
            $"{ia.Modelo}@{digest}, T {m.Temperatura}, top_p {m.TopP}, top_k {m.TopK}, think false, MaxOutputTokens 8, ruta API /api/chat (OllamaSharp 5.5.0), " +
            $"num_ctx {ia.NumCtx} y {corto}, prompt de {lineas} líneas, Ollama {version}, criterio previo: comentario de esta clase, fecha {DateTimeOffset.Now:O}");
        registro.Linea($"# rótulo: {ServidorDePrueba.Estacion}");

        var violaciones = new List<string>();
        int respondio3001 = 0;
        for (int s = 1; s <= n; s++)
        {
            var mensaje = new ChatMessage(ChatRole.User, Prompt(s, lineas));
            var largo = Opciones(ia, s, ia.NumCtx);
            var lectura = LectorDePrefijoCacheado.Abrir();
            var reloj = Stopwatch.StartNew();
            var r = await chat.GetResponseAsync([mensaje], largo);
            var pared8 = reloj.Elapsed.TotalSeconds;
            long l = r.Usage?.InputTokenCount ?? 0;
            if (l <= corto) violaciones.Add($"s={s}: con {ia.NumCtx} llegaron {l} tokens, no supera {corto}");
            if (r.Usage?.CachedInputTokenCount is not null) violaciones.Add($"s={s}: CachedInputTokenCount = {r.Usage.CachedInputTokenCount}");
            var (handler8, cacheados8) = (lectura.TokensDeEntrada, lectura.TokensCacheados);
            if (handler8 != l) violaciones.Add($"s={s}: handler {handler8} ≠ Usage {l}");
            if (r.Text.Trim() == "3001") respondio3001++;

            var truncado = DetectorDeContextoTruncado.FijarLargoEsperado(Opciones(ia, s, corto), l);
            lectura = LectorDePrefijoCacheado.Abrir();
            reloj.Restart();
            string resultadoCorto;
            try
            {
                var rc = await chat.GetResponseAsync([mensaje], truncado);
                resultadoCorto = $"SIN ERROR, InputTokenCount {rc.Usage?.InputTokenCount}, respuesta «{rc.Text.Trim()}»";
                violaciones.Add($"s={s}: con {corto} no se detectó truncado ({resultadoCorto})");
            }
            catch (ContextoTruncadoException ex)
            {
                resultadoCorto = $"ContextoTruncadoException esperado {ex.Esperado} recibido {ex.Recibido} (handler prompt_eval_count {lectura.TokensDeEntrada})";
            }
            registro.Linea($"s={s}: num_ctx {ia.NumCtx} → InputTokenCount {l}, handler prompt_eval_count {handler8} cached {cacheados8?.ToString() ?? "ausente"}, " +
                $"CachedInputTokenCount {r.Usage?.CachedInputTokenCount?.ToString() ?? "null"}, respuesta «{r.Text.Trim()}», pared {pared8:0.0} s | " +
                $"num_ctx {corto} → {resultadoCorto}, pared {reloj.Elapsed.TotalSeconds:0.0} s");
        }

        registro.Linea($"invariantes: {(violaciones.Count == 0 ? "0 violaciones" : string.Join("; ", violaciones))}");
        registro.Linea($"existencia: con {ia.NumCtx} respondió «3001» en {respondio3001} de {n}");
        registro.Guardar();
        Assert.That(violaciones, Is.Empty);
    }

    private static ChatOptions Opciones(OpcionesDeIA ia, int semilla, int numCtx)
    {
        var o = Asistente.CrearOpciones(ia);
        o.Seed = semilla;
        o.MaxOutputTokens = 8;
        o.AdditionalProperties!["num_ctx"] = numCtx;
        return o;
    }

    public static string Prompt(int serie, int lineas)
    {
        var sb = new StringBuilder($"Planilla {serie} de Movilidad Urbana.\n");
        for (int i = 1; i <= lineas; i++)
            sb.Append($"Localidad {i}: código postal {3000 + i}, provincia Corrientes, habitantes {1000 + i * 7}.\n");
        sb.Append("¿Cuál es el código postal de la Localidad 1? Respondé sólo el número.");
        return sb.ToString();
    }
}
