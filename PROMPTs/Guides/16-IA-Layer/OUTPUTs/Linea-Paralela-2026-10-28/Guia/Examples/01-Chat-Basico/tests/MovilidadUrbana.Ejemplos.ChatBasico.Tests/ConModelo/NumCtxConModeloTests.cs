using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.ChatBasico.Configuracion;
using MovilidadUrbana.Ejemplos.ChatBasico.Conversacion;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.ChatBasico.Tests.ConModelo;

/// <summary>
/// ¿Llega num_ctx al servidor? Un prompt de unos 6000 tokens con el modelo de humo, con tres
/// valores de AI:NumCtx. Criterio escrito antes de correr (invariantes; fallan ante una violación):
///  (a) con el grande, InputTokenCount &gt; el chico en cada semilla;
///  (b) con el chico, InputTokenCount ≤ el chico en cada semilla (truncado en silencio);
///  (c) con el grande, InputTokenCount = el de referencia (sin truncar).
/// Si num_ctx no viajara, (a) fallaría: el servidor usaría su valor por defecto en los dos casos.
/// </summary>
[TestFixture, Category("ConModelo")]
public sealed class NumCtxConModeloTests
{
    private static readonly string[] Localidades = ["Corrientes", "Resistencia", "Goya", "Bella Vista", "Paraná", "Rosario", "Córdoba", "Mendoza"];
    private static readonly string[] Medios = ["colectivo", "auto", "bicicleta", "moto", "caminata", "tren"];
    private static readonly string[] Motivos = ["trabajo", "estudio", "salud", "otros"];

    /// <summary>Respuestas sintéticas de la encuesta, deterministas.</summary>
    public static string PromptLargo(int lineas)
    {
        var sb = new StringBuilder("Respuestas de la encuesta de Movilidad Urbana, una por línea:\n");
        for (int i = 1; i <= lineas; i++)
            sb.Append($"Respuesta {i:0000}: localidad {Localidades[i % Localidades.Length]}, medio {Medios[i * 7 % Medios.Length]}, " +
                      $"motivo {Motivos[i * 3 % Motivos.Length]}, viaja {i % 5 + 1} veces por semana.\n");
        sb.Append("¿Cuántas respuestas hay en total? Respondé sólo con un número.");
        return sb.ToString();
    }

    [Test]
    public async Task NumCtxLlegaAlServidor()
    {
        var p = ServidorDePrueba.Pruebas;
        string modelo = p["ModeloDeHumo"]!;
        int chico = int.Parse(p["NumCtxChico"]!), grande = int.Parse(p["NumCtxGrande"]!), referencia = int.Parse(p["NumCtxDeReferencia"]!);
        int m = int.Parse(p["SemillasPorTamano"]!), maxSalida = int.Parse(p["MaxOutputTokensChico"]!);
        string prompt = PromptLargo(int.Parse(p["LineasDelPromptLargo"]!));
        var registro = new RegistroRllm("num-ctx-humo");
        var entrada = new Dictionary<(int, int), int?>();

        // Agrupado por tamaño: alternar num_ctx recarga el modelo en cada cambio.
        var corridas = new List<(int NumCtx, int Semilla)> { (referencia, 1) };
        corridas.AddRange(Enumerable.Range(1, m).Select(s => (grande, s)));
        corridas.AddRange(Enumerable.Range(1, m).Select(s => (chico, s)));

        foreach (var (numCtx, s) in corridas)
        {
            using var host = ServidorDePrueba.Anfitrion(new()
            {
                ["AI:Modelo"] = modelo,
                ["AI:NumCtx"] = numCtx.ToString(),
                ["AI:Muestreo:Semilla"] = s.ToString(),
                ["AI:Muestreo:ApagarRazonamiento"] = "false", // el modelo de humo no tiene modo de razonamiento
            });
            var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            if (entrada.Count == 0)
            {
                var (version, digest) = await ServidorDePrueba.Identificar(host, modelo);
                registro.Linea($"# R-LLM — estimando: este pedido (invariantes), 1 pedido × {m} semillas por tamaño (s = 1..{m}) + 1 de referencia, {modelo}@{digest}, " +
                    $"T {ia.Muestreo.Temperatura}, think sin enviar, num_ctx {referencia}/{grande}/{chico}, MaxOutputTokens {maxSalida}, ruta API /api/chat (OllamaSharp), Ollama {version}, fecha {DateTimeOffset.Now:O}");
                registro.Linea($"# criterio previo: (a) entrada({grande}) > {chico} en {m}/{m}; (b) entrada({chico}) ≤ {chico} en {m}/{m}; (c) entrada({grande}) = entrada({referencia})");
                registro.Linea($"# pedido: {prompt.Length} caracteres, {prompt.Split('\n').Length} líneas, generado por PromptLargo (determinista)");
            }

            var chat = host.Services.GetRequiredService<IChatClient>();
            var opciones = FabricaDeOpcionesDeChat.Crear(ia);
            opciones.MaxOutputTokens = maxSalida;
            var reloj = Stopwatch.StartNew();
            var r = await chat.GetResponseAsync(prompt, opciones);
            reloj.Stop();
            entrada[(numCtx, s)] = r.Usage?.InputTokenCount is long n ? (int)n : null;
            registro.Linea($"num_ctx={numCtx} s={s} entrada={r.Usage?.InputTokenCount} salida={r.Usage?.OutputTokenCount} fin={r.FinishReason} pared={reloj.Elapsed.TotalSeconds:F1}s «{r.Text.Trim()}»");
        }

        var g = Enumerable.Range(1, m).Select(s => entrada[(grande, s)]).ToList();
        var c = Enumerable.Range(1, m).Select(s => entrada[(chico, s)]).ToList();
        int okA = g.Count(x => x > chico), okB = c.Count(x => x <= chico), okC = g.Count(x => x == entrada[(referencia, 1)]);
        registro.Linea($"# resultado — estimando: este pedido; (a) {okA}/{m}; (b) {okB}/{m}; (c) {okC}/{m}; referencia={entrada[(referencia, 1)]}");
        registro.Guardar();

        Assert.Multiple(() =>
        {
            Assert.That(okA, Is.EqualTo(m), "(a) con el grande no se superó el chico: num_ctx no llegó");
            Assert.That(okB, Is.EqualTo(m), "(b) con el chico no se truncó");
            Assert.That(okC, Is.EqualTo(m), "(c) con el grande se truncó");
        });
    }
}
