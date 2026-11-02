using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.ChatBasico.Configuracion;
using MovilidadUrbana.Ejemplos.ChatBasico.Conversacion;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.ChatBasico.Tests.ConModelo;

/// <summary>
/// Chat básico por la vía nativa, con el modelo y el muestreo de appsettings.json.
/// Criterio escrito antes de correr:
///  - invariantes por corrida (fallan ante una sola violación): texto no vacío, FinishReason = stop,
///    InputTokenCount &gt; 0;
///  - tasa de este pedido, m semillas (1..m): la respuesta nombra 4 dígitos («4» o «cuatro»);
///    la prueba falla si k &lt; m − 2 (umbral elegido, no medido).
/// </summary>
[TestFixture, Category("ConModelo")]
public sealed class ChatConModeloTests
{
    private const string Pedido = "¿Cuántos dígitos lleva el código postal de una localidad?";
    private static readonly Regex NombraCuatro = new(@"\b4\b|cuatro", RegexOptions.IgnoreCase);

    [Test]
    public async Task RespondeLosDigitosDelCodigoPostal()
    {
        int m = int.Parse(ServidorDePrueba.Pruebas["Semillas"]!);
        var registro = new RegistroRllm("chat-basico-4b");
        int k = 0;
        var violaciones = new List<string>();

        for (int s = 1; s <= m; s++)
        {
            using var host = ServidorDePrueba.Anfitrion(new() { ["AI:Muestreo:Semilla"] = s.ToString() });
            var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            if (s == 1)
            {
                var (version, digest) = await ServidorDePrueba.Identificar(host, ia.Modelo);
                var mu = ia.Muestreo;
                registro.Linea($"# R-LLM — estimando: este pedido, 1 pedido × {m} semillas (s = 1..{m}), {ia.Modelo}@{digest}, " +
                    $"T {mu.Temperatura}, top_p {mu.TopP}, top_k {mu.TopK}, presence {mu.PenalizacionPorPresencia}, think {(mu.ApagarRazonamiento ? "false" : "default")}, " +
                    $"num_ctx {ia.NumCtx}, ruta API /api/chat (OllamaSharp), Ollama {version}, fecha {DateTimeOffset.Now:O}");
                registro.Linea("# criterio previo: invariantes (texto no vacío, FinishReason stop, InputTokenCount > 0) en m/m; tasa «nombra 4 dígitos» con k ≥ m − 2");
                registro.Linea($"# sistema: «{AsistenteDeMovilidad.InstruccionesDelSistema}»");
                registro.Linea($"# pedido: «{Pedido}»");
            }

            var asistente = host.Services.GetRequiredService<AsistenteDeMovilidad>();
            var reloj = Stopwatch.StartNew();
            ChatResponse r = await asistente.PreguntarAsync(Pedido);
            reloj.Stop();

            var texto = r.Text.Trim();
            bool pasa = NombraCuatro.IsMatch(texto);
            if (pasa) k++;
            if (texto.Length == 0) violaciones.Add($"s={s}: texto vacío");
            if (r.FinishReason != ChatFinishReason.Stop) violaciones.Add($"s={s}: FinishReason {r.FinishReason}");
            if (!(r.Usage?.InputTokenCount > 0)) violaciones.Add($"s={s}: InputTokenCount {r.Usage?.InputTokenCount}");
            registro.Linea($"s={s} pasa={pasa} pared={reloj.Elapsed.TotalSeconds:F1}s entrada={r.Usage?.InputTokenCount} salida={r.Usage?.OutputTokenCount} fin={r.FinishReason} «{texto.Replace("\n", " ⏎ ")}»");
        }

        registro.Linea($"# resultado: nombra 4 dígitos {RegistroRllm.Fraccion(k, m)} — estimando: este pedido; invariantes violadas: {violaciones.Count}");
        registro.Guardar();

        Assert.That(violaciones, Is.Empty);
        Assert.That(k, Is.GreaterThanOrEqualTo(m - 2));
    }
}
