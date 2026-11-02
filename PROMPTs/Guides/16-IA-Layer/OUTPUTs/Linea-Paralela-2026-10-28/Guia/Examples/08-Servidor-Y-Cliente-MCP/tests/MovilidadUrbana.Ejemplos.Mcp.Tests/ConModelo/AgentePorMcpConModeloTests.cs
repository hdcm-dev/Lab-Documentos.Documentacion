using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.Mcp.Cliente;
using MovilidadUrbana.Ejemplos.Mcp.Cliente.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.Mcp.Cliente.Mcp;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Application.Normalizacion;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Herramientas;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Mcp;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.Mcp.Tests.ConModelo;

/// <summary>
/// D7 contra el modelo: un agente de MAF cuyas herramientas son McpClientTool del servidor propio.
/// Criterio escrito antes de correr (Bitácora: evidencia-examples/08-Servidor-Y-Cliente-MCP/00-criterio-previo.md):
///  - invariantes por corrida (fallan ante una sola violación): 0 escrituras en el servidor; toda
///    herramienta pedida está en la lista blanca; ejecuciones ≤ MaximoDeIteraciones; sin excepción;
///  - tasas de este pedido, m semillas (1..m), informadas sin umbral:
///    «Chaco»: pidió una herramienta con provincia que normaliza a Chaco; la respuesta nombra la cantidad 1;
///    «Corrientes»: pidió listar_localidades con provincia que normaliza a Corrientes; la respuesta nombra
///    Corrientes y no nombra Resistencia (que es de Chaco).
/// </summary>
[TestFixture, Category("ConModelo")]
public sealed class AgentePorMcpConModeloTests
{
    private const string PedidoChaco = "¿Cuántas localidades hay cargadas en Chaco?";
    private const string PedidoCorrientes = "¿Qué localidades hay cargadas en Corrientes?";
    private static readonly Regex NombraUno = new(@"\b1\b|\buna\b", RegexOptions.IgnoreCase);

    [Test]
    public async Task AgenteConMcpClientTool_ContraElModelo()
    {
        int m = ServidorDePrueba.Semillas;
        var registro = new RegistroRllm("agente-por-mcp");
        var violaciones = new List<string>();
        var paredes = new List<double>();
        int chacoHerramienta = 0, chacoCantidad = 0, ctesHerramienta = 0, ctesBien = 0;

        await using var servidor = await ServidorMcp.IniciarEnLoopbackAsync("Development");
        for (int s = 1; s <= m; s++)
        {
            using var host = ServidorDePrueba.Anfitrion(new() { ["AI:Muestreo:Semilla"] = s.ToString() });
            var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            var opcionesMcp = host.Services.GetRequiredService<IOptions<OpcionesDelClienteMcp>>().Value;
            await using var mcp = await ConexionMcp.ConectarAsync(servidor.Endpoint, opcionesMcp.Token!);
            var filtradas = ListaBlanca.Filtrar(await mcp.ListToolsAsync(), opcionesMcp.HerramientasPermitidas);
            var agente = new AgenteDeLocalidadesPorMcp(host.Services.GetRequiredService<IChatClient>(), filtradas, ia);

            if (s == 1)
            {
                var (version, digest) = await ServidorDePrueba.Identificar(host);
                var mu = ia.Muestreo;
                registro.Linea($"# R-LLM — estimando: este pedido, 2 pedidos × {m} semillas (s = 1..{m}) cada uno, {ia.Modelo}@{digest}, " +
                    $"T {mu.Temperatura}, top_p {mu.TopP}, top_k {mu.TopK}, presence {mu.PenalizacionPorPresencia}, think {(mu.ApagarRazonamiento ? "false" : "default")}, " +
                    $"num_ctx {ia.NumCtx}, ruta API /api/chat (OllamaSharp 5.5.0), agente de MAF 1.26.0 con McpClientTool (ModelContextProtocol 2.3.0, Streamable HTTP, " +
                    $"protocolo {mcp.NegotiatedProtocolVersion}), bucle {ia.Herramientas.MaximoDeIteraciones} iteraciones / {ia.Herramientas.MaximoDeErroresConsecutivos} errores, Ollama {version}, fecha {DateTimeOffset.Now:O}");
                registro.Linea($"# rótulo: {ServidorDePrueba.Estacion}");
                registro.Linea("# criterio previo: invariantes m/m (0 escrituras en el servidor; herramientas en la lista blanca; ejecuciones ≤ máximo; sin excepción); tasas de este pedido informadas, sin umbral");
                registro.Linea($"# lista blanca: {string.Join(", ", filtradas.Aceptadas.Select(t => t.Name))}; descartadas: {(filtradas.Descartadas.Count == 0 ? "ninguna" : string.Join(", ", filtradas.Descartadas))}");
                registro.Linea($"# instrucciones: «{AgenteDeLocalidadesPorMcp.Instrucciones}»");
            }

            foreach (var pedido in new[] { PedidoChaco, PedidoCorrientes })
            {
                RespuestaDelAgente? r = null;
                var reloj = Stopwatch.StartNew();
                try { r = await agente.PreguntarAsync(pedido); }
                catch (Exception ex) { violaciones.Add($"s={s} «{pedido}»: excepción {ex.GetType().Name}: {ex.Message}"); }
                reloj.Stop();
                paredes.Add(reloj.Elapsed.TotalSeconds);

                if (servidor.Almacen.Escrituras != 0) violaciones.Add($"s={s}: {servidor.Almacen.Escrituras} escrituras");
                if (r is null) continue;
                foreach (var h in r.Herramientas.Where(h => !opcionesMcp.HerramientasPermitidas.Contains(h.Nombre)))
                    violaciones.Add($"s={s}: herramienta fuera de la lista blanca: {h.Nombre}");
                if (r.Herramientas.Count > ia.Herramientas.MaximoDeIteraciones)
                    violaciones.Add($"s={s}: {r.Herramientas.Count} ejecuciones");

                string fila;
                if (pedido == PedidoChaco)
                {
                    bool pidio = r.Herramientas.Any(h => Provincia(h.Argumentos) == "Chaco");
                    bool cantidad = NombraUno.IsMatch(r.Texto);
                    chacoHerramienta += pidio ? 1 : 0; chacoCantidad += cantidad ? 1 : 0;
                    fila = $"s={s} pedido=Chaco herramienta_con_Chaco={pidio} nombra_1={cantidad}";
                }
                else
                {
                    bool pidio = r.Herramientas.Any(h => h.Nombre == HerramientasDeLocalidades.Listar && Provincia(h.Argumentos) == "Corrientes");
                    bool bien = r.Texto.Contains("Corrientes") && !r.Texto.Contains("Resistencia");
                    ctesHerramienta += pidio ? 1 : 0; ctesBien += bien ? 1 : 0;
                    fila = $"s={s} pedido=Corrientes listar_con_Corrientes={pidio} nombra_Corrientes_sin_Resistencia={bien}";
                }
                var llamadas = string.Join(" ; ", r.Herramientas.Select(h => $"{h.Nombre}({h.Argumentos}) → {h.Resultado}"));
                registro.Linea($"{fila} pared={reloj.Elapsed.TotalSeconds:F1}s herramientas=[{llamadas}] «{r.Texto.Replace("\n", " ⏎ ")}»");
            }
        }

        var orden = paredes.Order().ToList();
        registro.Linea("# resultado (estimando: este pedido, cada fila por separado; no se comparan entre sí):");
        registro.Linea($"#  Chaco — pidió una herramienta con Chaco: {RegistroRllm.Fraccion(chacoHerramienta, m)}; nombra la cantidad 1: {RegistroRllm.Fraccion(chacoCantidad, m)}");
        registro.Linea($"#  Corrientes — pidió listar_localidades con Corrientes: {RegistroRllm.Fraccion(ctesHerramienta, m)}; nombra Corrientes sin Resistencia: {RegistroRllm.Fraccion(ctesBien, m)}");
        registro.Linea($"#  invariantes violadas: {violaciones.Count}; escrituras en el servidor: {servidor.Almacen.Escrituras}; pared por pedido: mediana {orden[orden.Count / 2]:F1} s (mín {orden[0]:F1}, máx {orden[^1]:F1}, N = {orden.Count})");
        foreach (var v in violaciones) registro.Linea($"#  violación: {v}");
        registro.Guardar();

        Assert.That(violaciones, Is.Empty);
    }

    private static string? Provincia(string argumentosJson)
    {
        try
        {
            using var doc = JsonDocument.Parse(argumentosJson);
            return doc.RootElement.TryGetProperty("provincia", out var p) && p.ValueKind == JsonValueKind.String
                ? NormalizadorDeCatalogos.Provincia(p.GetString()).Valor
                : null;
        }
        catch (JsonException) { return null; }
    }
}
