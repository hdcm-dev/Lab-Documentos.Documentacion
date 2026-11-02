using Microsoft.Extensions.AI;
using Microsoft.Extensions.AI.Evaluation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Domain;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Encuestas;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests.Cableado;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests.Evaluacion;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests.ConModelo;

/// <summary>
/// El contrato del paso 2 contra el modelo, con el texto «Voy en bondi y a veces en bici, casi todos los días».
/// Criterio escrito antes de correr:
///  - invariantes: sin excepción (el código usa TryGetResult); el veredicto de MedioEnCatalogoEvaluator
///    coincide con la verificación directa contra Catalogos.Medios;
///  - tasas de este pedido, m semillas (1..m), sin umbral: deserializó; todos los medios en el catálogo;
///    exactamente {colectivo, bicicleta} y «diaria».
/// </summary>
[TestFixture, Category("ConModelo")]
public sealed class SalidaEstructuradaConModeloTests
{
    public const string Pedido =
        "Extraé los medios de transporte y la frecuencia. Medios válidos: colectivo, auto, bicicleta, moto, caminata, tren. " +
        "Frecuencias válidas: diaria, semanal, ocasional.\nTexto: " + SalidaEstructuradaYEvaluacionTests.TextoDeLaPersona;

    [Test]
    public async Task Paso2_ContraElModelo()
    {
        int m = ServidorDePrueba.Semillas;
        var registro = new RegistroRllm("salida-estructurada-con-modelo");
        var violaciones = new List<string>();
        int deserializo = 0, enCatalogo = 0, exacto = 0;

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
                    $"ruta API /api/chat (OllamaSharp 5.5.0, format = esquema JSON de EncuestaPaso2Propuesta), Ollama {version}, " +
                    $"criterio previo: comentario de esta clase, fecha {DateTimeOffset.Now:O}");
                registro.Linea($"# rótulo: {ServidorDePrueba.Estacion}");
                registro.Linea($"# pedido: «{Pedido.Replace('\n', ' ')}»");
            }

            using var ambito = host.Sesion($"sesion-s{s}");
            var chat = ambito.ServiceProvider.GetRequiredService<IChatClient>();
            try
            {
                var r = await chat.GetResponseAsync<EncuestaPaso2Propuesta>(Pedido, Asistente.CrearOpciones(ia));
                bool ok = r.TryGetResult(out var p);
                var medios = p?.Medios ?? [];
                bool catalogo = ok && medios.Length > 0 && medios.All(x => Catalogos.Medios.Any(c => c.Clave == x));
                bool esExacto = ok && medios.Order().SequenceEqual(["bicicleta", "colectivo"]) && p!.Frecuencia == "diaria";
                var veredicto = (await new MedioEnCatalogoEvaluator().EvaluateAsync([], r)).Get<BooleanMetric>(MedioEnCatalogoEvaluator.Nombre).Value;
                if (veredicto != catalogo) violaciones.Add($"s={s}: evaluador {veredicto} ≠ verificación {catalogo}");
                if (ok) deserializo++;
                if (catalogo) enCatalogo++;
                if (esExacto) exacto++;
                registro.Linea($"s={s}: crudo «{r.Text.Replace('\n', ' ')}» deserializó {ok} en catálogo {catalogo} exacto {esExacto}");
            }
            catch (Exception ex) { violaciones.Add($"s={s}: {ex.GetType().Name}: {ex.Message}"); }
        }

        registro.Linea($"invariantes: {(violaciones.Count == 0 ? $"0 violaciones en {m} semillas" : string.Join("; ", violaciones))}");
        registro.Linea($"deserializó: {RegistroRllm.Fraccion(deserializo, m)}");
        registro.Linea($"todos los medios en el catálogo: {RegistroRllm.Fraccion(enCatalogo, m)}");
        registro.Linea($"exactamente {{colectivo, bicicleta}} y «diaria»: {RegistroRllm.Fraccion(exacto, m)}");
        registro.Guardar();
        Assert.That(violaciones, Is.Empty);
    }
}
