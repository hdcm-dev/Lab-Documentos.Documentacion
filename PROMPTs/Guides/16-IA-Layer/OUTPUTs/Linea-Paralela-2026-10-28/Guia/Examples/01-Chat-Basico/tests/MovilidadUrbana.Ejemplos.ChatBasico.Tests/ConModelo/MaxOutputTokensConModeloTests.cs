using System.Diagnostics;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.ChatBasico.Configuracion;
using MovilidadUrbana.Ejemplos.ChatBasico.Conversacion;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.ChatBasico.Tests.ConModelo;

/// <summary>
/// MaxOutputTokens por las dos vías, con el mismo pedido y el mismo modelo.
/// Criterio escrito antes de correr:
///  - vía nativa (invariante): OutputTokenCount ≤ MaxOutputTokens en m/m;
///  - vía /v1 (existencia): se observa OutputTokenCount &gt; MaxOutputTokens en al menos 1 de m.
/// </summary>
[TestFixture, Category("ConModelo")]
public sealed class MaxOutputTokensConModeloTests
{
    private const string Pedido = "Enumerá las provincias del catálogo, una por línea.";

    [Test]
    public async Task MaxOutputTokensAcotaPorLaViaNativaYNoPorV1()
    {
        var p = ServidorDePrueba.Pruebas;
        int m = int.Parse(p["SemillasPorTamano"]!), max = int.Parse(p["MaxOutputTokensChico"]!);
        var registro = new RegistroRllm("max-output-tokens-4b");
        var salida = new Dictionary<(string, int), long?>();

        foreach (var proveedor in new[] { Proveedores.Ollama, Proveedores.OpenAICompatible })
        for (int s = 1; s <= m; s++)
        {
            using var host = ServidorDePrueba.Anfitrion(new()
            {
                ["AI:Proveedor"] = proveedor,
                ["AI:Muestreo:Semilla"] = s.ToString(),
            });
            var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            if (salida.Count == 0)
            {
                var (version, digest) = await ServidorDePrueba.Identificar(host, ia.Modelo);
                var mu = ia.Muestreo;
                registro.Linea($"# R-LLM — estimando: este pedido, 1 pedido × {m} semillas por vía (s = 1..{m}), {ia.Modelo}@{digest}, " +
                    $"T {mu.Temperatura}, top_p {mu.TopP}, think false (nativa) / reasoning_effort none (/v1), MaxOutputTokens {max}, " +
                    $"num_ctx {ia.NumCtx} sólo por la nativa, rutas API /api/chat (OllamaSharp) y /v1/chat/completions (MEAI.OpenAI), Ollama {version}, fecha {DateTimeOffset.Now:O}");
                registro.Linea($"# criterio previo: nativa, salida ≤ {max} en {m}/{m} (invariante); /v1, salida > {max} en al menos 1 de {m} (existencia)");
                registro.Linea($"# sistema: el de AsistenteDeMovilidad; pedido: «{Pedido}»");
            }

            var chat = host.Services.GetRequiredService<IChatClient>();
            var opciones = FabricaDeOpcionesDeChat.Crear(ia);
            opciones.MaxOutputTokens = max;
            var reloj = Stopwatch.StartNew();
            var r = await chat.GetResponseAsync(
                [new(ChatRole.System, AsistenteDeMovilidad.InstruccionesDelSistema), new(ChatRole.User, Pedido)], opciones);
            reloj.Stop();
            salida[(proveedor, s)] = r.Usage?.OutputTokenCount;
            registro.Linea($"{proveedor} s={s} entrada={r.Usage?.InputTokenCount} salida={r.Usage?.OutputTokenCount} fin={r.FinishReason} pared={reloj.Elapsed.TotalSeconds:F1}s «{r.Text.Trim().Replace("\n", " ⏎ ")}»");
        }

        int nativaAcotada = Enumerable.Range(1, m).Count(s => salida[(Proveedores.Ollama, s)] <= max);
        int v1Excedida = Enumerable.Range(1, m).Count(s => salida[(Proveedores.OpenAICompatible, s)] > max);
        registro.Linea($"# resultado — estimando: este pedido; nativa acotada {nativaAcotada}/{m}; /v1 por encima de {max}: se observó en {v1Excedida} de {m}");
        registro.Guardar();

        Assert.Multiple(() =>
        {
            Assert.That(nativaAcotada, Is.EqualTo(m), "la vía nativa no respetó MaxOutputTokens");
            Assert.That(v1Excedida, Is.GreaterThanOrEqualTo(1), "por /v1 no se observó salida por encima de MaxOutputTokens");
        });
    }
}
