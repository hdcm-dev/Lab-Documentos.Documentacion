using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.ToolCalling.Application.Asistente;
using MovilidadUrbana.Ejemplos.ToolCalling.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.ToolCalling.Infrastructure.Persistence;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.ToolCalling.Tests.ConModelo;

/// <summary>
/// El primer ejercicio contra el modelo, por las dos vías (OllamaSharp → /api/chat y MEAI.OpenAI → /v1).
/// Criterio escrito antes de correr (Bitácora: evidencia-examples/06-Tool-Calling/00-criterio-previo.md):
///  - invariantes por corrida (fallan ante una sola violación): 0 escrituras en el almacén; toda
///    herramienta pedida está en la lista cerrada; ejecuciones ≤ MaximoDeIteraciones; sin excepción;
///  - tasas de este pedido, m semillas (1..m), se informan sin umbral:
///    «Chaco»: pidió contar_localidades_por_provincia (o listar_localidades) con provincia que normaliza a Chaco;
///             la respuesta nombra la cantidad correcta (1: regex \b1\b|\buna\b);
///    «Misiones»: pidió alguna herramienta; la respuesta dice que no está en el catálogo
///             (regex cat[aá]logo|no (es|est[aá]|figura|forma parte|se encuentra)); la respuesta afirma un conteo
///             (regex \b\d+\s+localidad), que sería inventado.
/// </summary>
[TestFixture, Category("ConModelo")]
public sealed class HerramientasConModeloTests
{
    private const string PedidoChaco = "¿Cuántas localidades hay cargadas en Chaco?";
    private const string PedidoMisiones = "¿Cuántas localidades hay cargadas en Misiones?";
    private static readonly Regex NombraUno = new(@"\b1\b|\buna\b", RegexOptions.IgnoreCase);
    private static readonly Regex FueraDelCatalogo = new(@"cat[aá]logo|no (es|est[aá]|figura|forma parte|se encuentra)", RegexOptions.IgnoreCase);
    private static readonly Regex AfirmaUnConteo = new(@"\b\d+\s+localidad", RegexOptions.IgnoreCase);

    [TestCase(Proveedores.Ollama)]
    [TestCase(Proveedores.OpenAICompatible)]
    public async Task PrimerEjercicio_PorLaVia(string proveedor)
    {
        int m = ServidorDePrueba.Semillas;
        var registro = new RegistroRllm($"tool-calling-{proveedor}");
        var violaciones = new List<string>();
        var paredes = new List<double>();
        var crudo = new List<string>();
        int chacoHerramienta = 0, chacoCantidad = 0, misionesHerramienta = 0, misionesCatalogo = 0, misionesConteo = 0;

        for (int s = 1; s <= m; s++)
        {
            using var host = ServidorDePrueba.Anfitrion(new() { ["AI:Proveedor"] = proveedor, ["AI:Muestreo:Semilla"] = s.ToString() });
            var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            if (s == 1)
            {
                var (version, digest) = await ServidorDePrueba.Identificar(host);
                var mu = ia.Muestreo;
                var ruta = proveedor == Proveedores.Ollama ? "/api/chat (OllamaSharp 5.5.0)" : "/v1/chat/completions (MEAI.OpenAI 10.11.0)";
                registro.Linea($"# R-LLM — estimando: este pedido, 2 pedidos × {m} semillas (s = 1..{m}) cada uno, {ia.Modelo}@{digest}, " +
                    $"T {mu.Temperatura}, top_p {mu.TopP}, top_k {mu.TopK}{(proveedor == Proveedores.Ollama ? "" : " (no viaja por /v1)")}, presence {mu.PenalizacionPorPresencia}, " +
                    $"think {(mu.ApagarRazonamiento ? "false" : "default")}, num_ctx {(proveedor == Proveedores.Ollama ? ia.NumCtx.ToString() : "no se fija por /v1")}, " +
                    $"ruta API {ruta}, bucle {ia.Herramientas.MaximoDeIteraciones} iteraciones / {ia.Herramientas.MaximoDeErroresConsecutivos} errores, Ollama {version}, fecha {DateTimeOffset.Now:O}");
                registro.Linea($"# rótulo: {ServidorDePrueba.Estacion}");
                registro.Linea("# criterio previo: invariantes m/m (0 escrituras; herramientas en la lista cerrada; ejecuciones ≤ máximo; sin excepción); tasas de este pedido informadas, sin umbral");
                registro.Linea($"# sistema: «{AsistenteDeLocalidades.InstruccionesDelSistema}»");
            }

            foreach (var pedido in new[] { PedidoChaco, PedidoMisiones })
            {
                var almacen = host.Services.GetRequiredService<AlmacenEnMemoria>();
                using var ambito = host.Services.CreateScope();
                ambito.ServiceProvider.GetRequiredService<SessionContext>().Set($"sesion-s{s}");
                var asistente = ambito.ServiceProvider.GetRequiredService<IAsistenteDeLocalidades>();

                RespuestaDelAsistente? r = null;
                var reloj = Stopwatch.StartNew();
                try { r = await asistente.PreguntarAsync(pedido); }
                catch (Exception ex) { violaciones.Add($"s={s} «{pedido}»: excepción {ex.GetType().Name}: {ex.Message}"); }
                reloj.Stop();
                paredes.Add(reloj.Elapsed.TotalSeconds);

                if (almacen.Escrituras != 0) violaciones.Add($"s={s}: {almacen.Escrituras} escrituras");
                if (r is null) continue;
                foreach (var h in r.Herramientas.Where(h => !HerramientasDeLocalidades.NombresDeLectura.Contains(h.Nombre)))
                    violaciones.Add($"s={s}: herramienta fuera de la lista: {h.Nombre}");
                if (r.Herramientas.Count > ia.Herramientas.MaximoDeIteraciones)
                    violaciones.Add($"s={s}: {r.Herramientas.Count} ejecuciones");

                string fila;
                if (pedido == PedidoChaco)
                {
                    bool pidio = r.Herramientas.Any(h => ProvinciaNormalizada(h.Argumentos) == "Chaco");
                    bool cantidad = NombraUno.IsMatch(r.Texto);
                    chacoHerramienta += pidio ? 1 : 0; chacoCantidad += cantidad ? 1 : 0;
                    fila = $"s={s} pedido=Chaco herramienta_con_Chaco={pidio} nombra_1={cantidad}";
                }
                else
                {
                    bool pidio = r.Herramientas.Count > 0, catalogo = FueraDelCatalogo.IsMatch(r.Texto), conteo = AfirmaUnConteo.IsMatch(r.Texto);
                    misionesHerramienta += pidio ? 1 : 0; misionesCatalogo += catalogo ? 1 : 0; misionesConteo += conteo ? 1 : 0;
                    fila = $"s={s} pedido=Misiones pidio_herramienta={pidio} dice_fuera_de_catalogo={catalogo} afirma_conteo={conteo}";
                }
                var llamadas = string.Join(" ; ", r.Herramientas.Select(h => $"{h.Nombre}({h.Argumentos}) → {h.Resultado}"));
                registro.Linea($"{fila} pared={reloj.Elapsed.TotalSeconds:F1}s herramientas=[{llamadas}] «{r.Texto.Replace("\n", " ⏎ ")}»");
            }
        }

        var orden = paredes.Order().ToList();
        registro.Linea($"# resultado (estimando: este pedido, cada fila por separado; no se comparan entre sí):");
        registro.Linea($"#  Chaco — pidió la herramienta con Chaco: {RegistroRllm.Fraccion(chacoHerramienta, m)}; nombra la cantidad 1: {RegistroRllm.Fraccion(chacoCantidad, m)}");
        registro.Linea($"#  Misiones — pidió alguna herramienta: {RegistroRllm.Fraccion(misionesHerramienta, m)}; dice que no está en el catálogo: {RegistroRllm.Fraccion(misionesCatalogo, m)}; afirma un conteo: {RegistroRllm.Fraccion(misionesConteo, m)}");
        registro.Linea($"#  invariantes violadas: {violaciones.Count}; pared por pedido: mediana {orden[orden.Count / 2]:F1} s (mín {orden[0]:F1}, máx {orden[^1]:F1}, N = {orden.Count})");
        foreach (var v in violaciones) registro.Linea($"#  violación: {v}");
        registro.Guardar();

        Assert.That(violaciones, Is.Empty);
    }

    private static string? ProvinciaNormalizada(string argumentosJson)
    {
        try
        {
            using var doc = JsonDocument.Parse(argumentosJson);
            return doc.RootElement.TryGetProperty("provincia", out var p) && p.ValueKind == JsonValueKind.String
                ? MovilidadUrbana.Ejemplos.ToolCalling.Application.Normalizacion.NormalizadorDeCatalogos.Provincia(p.GetString()).Valor
                : null;
        }
        catch (JsonException) { return null; }
    }
}
