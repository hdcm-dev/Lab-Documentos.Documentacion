using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Asistente;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.Persistence;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests.Cableado;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests.ConModelo;

/// <summary>
/// El pipeline completo contra el modelo: «¿Cuántas localidades hay cargadas en Corrientes?» (la sesión siembra 1).
/// Criterio escrito antes de correr:
///  - invariantes por semilla: sin excepción; 0 escrituras; el segundo pedido igual es un acierto
///    (0 spans, contador +1, mismo texto); toda herramienta pedida está en la lista cerrada;
///  - tasas de este pedido, m semillas (1..m), sin umbral: pidió la herramienta (span execute_tool);
///    la respuesta nombra 1 (regex \b1\b|\buna\b); el servidor informó tokens cacheados &gt; 0 en el último pedido.
/// </summary>
[TestFixture, Category("ConModelo")]
public sealed class PipelineConModeloTests
{
    private const string Pregunta = "¿Cuántas localidades hay cargadas en Corrientes?";
    private static readonly Regex NombraUno = new(@"\b1\b|\buna\b", RegexOptions.IgnoreCase);

    [Test]
    public async Task CacheFriaYCaliente_ConElModelo()
    {
        int m = ServidorDePrueba.Semillas;
        var registro = new RegistroRllm("pipeline-con-modelo");
        var violaciones = new List<string>();
        int pidioHerramienta = 0, nombraUno = 0, conCacheados = 0;

        for (int s = 1; s <= m; s++)
        {
            using var host = ServidorDePrueba.Anfitrion(new() { ["AI:Muestreo:Semilla"] = s.ToString() });
            var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            if (s == 1)
            {
                var (version, digest) = await ServidorDePrueba.Identificar(host);
                var mu = ia.Muestreo;
                registro.Linea($"# R-LLM — estimando: este pedido, 1 pedido × {m} semillas (s = 1..{m}), {ia.Modelo}@{digest}, " +
                    $"T {mu.Temperatura}, top_p {mu.TopP}, top_k {mu.TopK}, presence {mu.PenalizacionPorPresencia}, think false, num_ctx {ia.NumCtx}, " +
                    $"ruta API /api/chat (OllamaSharp 5.5.0), bucle {ia.Herramientas.MaximoDeIteraciones} iteraciones, Ollama {version}, " +
                    $"criterio previo: comentario de esta clase, fecha {DateTimeOffset.Now:O}");
                registro.Linea($"# rótulo: {ServidorDePrueba.Estacion}");
            }

            using var escucha = new Escucha();
            using var ambito = host.Sesion($"sesion-s{s}");
            var asistente = ambito.ServiceProvider.GetRequiredService<IAsistente>();
            var lectura = LectorDePrefijoCacheado.Abrir();
            string fria;
            var reloj = Stopwatch.StartNew();
            try { fria = await asistente.PreguntarAsync(Pregunta); }
            catch (Exception ex) { violaciones.Add($"s={s}: {ex.GetType().Name}: {ex.Message}"); continue; }
            var pared = reloj.Elapsed.TotalSeconds;
            var spans = escucha.Spans();
            bool herramienta = spans.Any(x => x.StartsWith("execute_tool", StringComparison.Ordinal));
            foreach (var x in spans.Where(x => x.StartsWith("execute_tool ", StringComparison.Ordinal)))
                if (!HerramientasDeLocalidades.NombresDeLectura.Contains(x["execute_tool ".Length..])) violaciones.Add($"s={s}: herramienta fuera de la lista: {x}");
            if (herramienta) pidioHerramienta++;
            if (NombraUno.IsMatch(fria)) nombraUno++;
            if (lectura.TokensCacheados > 0) conCacheados++;

            escucha.LimpiarSpans();
            long aciertos = escucha.Aciertos;
            var caliente = await asistente.PreguntarAsync(Pregunta);
            if (escucha.Spans().Count != 0) violaciones.Add($"s={s}: el acierto dejó {escucha.Spans().Count} spans");
            if (escucha.Aciertos - aciertos != 1) violaciones.Add($"s={s}: contador +{escucha.Aciertos - aciertos}");
            if (caliente != fria) violaciones.Add($"s={s}: el acierto cambió el texto");
            var escrituras = host.Services.GetRequiredService<AlmacenEnMemoria>().Escrituras;
            if (escrituras != 0) violaciones.Add($"s={s}: {escrituras} escrituras");

            registro.Linea($"s={s}: spans [{string.Join(", ", spans)}]; prompt_eval_count {lectura.TokensDeEntrada}, cacheados {lectura.TokensCacheados?.ToString() ?? "ausente"}; " +
                $"pared {pared:0.0} s; respuesta «{fria.Replace('\n', ' ')}»");
        }

        registro.Linea($"invariantes: {(violaciones.Count == 0 ? $"0 violaciones en {m} semillas" : string.Join("; ", violaciones))}");
        registro.Linea($"pidió la herramienta: {RegistroRllm.Fraccion(pidioHerramienta, m)}");
        registro.Linea($"la respuesta nombra 1: {RegistroRllm.Fraccion(nombraUno, m)}");
        registro.Linea($"el servidor informó tokens cacheados > 0 en el último pedido: {RegistroRllm.Fraccion(conCacheados, m)}");
        registro.Guardar();
        Assert.That(violaciones, Is.Empty);
    }
}
