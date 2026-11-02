using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI.DelChatAlAgente;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.Persistence;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.AgenteConAprobacion.Tests.ConModelo;

/// <summary>
/// 4.1 → 4.2 contra el modelo. Por semilla s = 1..m: la llamada única con «¿Cuántas localidades hay en Chaco?»
/// y el agente de MAF con dos turnos («¿Cuántas localidades hay en Chaco?», «¿Y en Corrientes?»).
/// Criterio escrito antes de correr:
///  - invariantes (fallan ante una sola violación): sin excepción y texto no vacío en cada respuesta;
///  - tasas de este pedido, sin umbral (se informan con Wilson): pidió la herramienta (la base se leyó en ese
///    turno) y la respuesta nombra la cantidad correcta (1, «una» o «un»);
///  - existencia: la herramienta se pidió al menos una vez en la llamada única y al menos una vez en el turno 1 del agente.
/// </summary>
[TestFixture, Category("ConModelo")]
public sealed class DelChatAlAgenteConModeloTests
{
    private static readonly Regex NombraUna = new(@"\b(1|una|un)\b", RegexOptions.IgnoreCase);

    [Test]
    public async Task LlamadaUnicaYAgenteDeMaf()
    {
        int m = int.Parse(ServidorDePrueba.Pruebas["SemillasDelAgente"]!);
        var registro = new RegistroRllm("del-chat-al-agente-4b");
        var violaciones = new List<string>();
        int herr41 = 0, ok41 = 0, herrT1 = 0, okT1 = 0, herrT2 = 0, okT2 = 0;

        for (int s = 1; s <= m; s++)
        {
            using var host = ServidorDePrueba.Anfitrion(new() { ["AI:Muestreo:Semilla"] = s.ToString() });
            var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            if (s == 1)
            {
                var (version, digest) = await ServidorDePrueba.Identificar(host, ia.Modelo);
                registro.Linea($"# R-LLM — estimando: este pedido, 3 pedidos × {m} semillas (s = 1..{m}), {ia.Modelo}@{digest}, {ServidorDePrueba.Parametros(ia)}, " +
                    $"Ollama {version}, estación: {ServidorDePrueba.Estacion}, fecha {DateTimeOffset.Now:O}");
                registro.Linea("# criterio previo: invariantes (sin excepción, texto no vacío) en todas; tasas «pidió la herramienta» y «nombra 1» sin umbral, con Wilson; existencia: herramienta ≥ 1 en 4.1 y en el turno 1 de 4.2");
                registro.Linea($"# sistema: «{Instrucciones.DelAsistente}»");
            }

            using var scope = host.Services.CreateScope();
            var sp = scope.ServiceProvider;
            sp.GetRequiredService<SessionContext>().Set($"sesion-{s}");
            var almacen = sp.GetRequiredService<AlmacenEnMemoria>();
            var chat = sp.GetRequiredService<IChatClient>();
            var herramientas = sp.GetRequiredService<HerramientasDeLocalidades>();

            async Task<(string Texto, bool Herramienta, double Pared)> Medir(Func<Task<string>> f)
            {
                int antes = almacen.Lecturas;
                var reloj = Stopwatch.StartNew();
                try
                {
                    var t = (await f()).Trim();
                    return (t, almacen.Lecturas > antes, reloj.Elapsed.TotalSeconds);
                }
                catch (Exception ex)
                {
                    violaciones.Add($"s={s}: {ex.GetType().Name}: {ex.Message.Split('\n')[0]}");
                    return ("", almacen.Lecturas > antes, reloj.Elapsed.TotalSeconds);
                }
            }

            var a = await Medir(() => LlamadaUnica.PreguntarAsync(chat, herramientas, FabricaDeOpcionesDeChat.Crear(ia), "¿Cuántas localidades hay en Chaco?"));
            var agente = AgenteDeMaf.Crear(chat, herramientas);
            var sesion = await agente.CreateSessionAsync();
            var opciones = new Microsoft.Agents.AI.ChatClientAgentRunOptions(FabricaDeOpcionesDeChat.Crear(ia));
            var t1 = await Medir(async () => (await agente.RunAsync("¿Cuántas localidades hay en Chaco?", sesion, opciones)).Text);
            var t2 = await Medir(async () => (await agente.RunAsync("¿Y en Corrientes?", sesion, opciones)).Text);

            foreach (var (nombre, r) in new[] { ("4.1", a), ("4.2-t1", t1), ("4.2-t2", t2) })
            {
                if (r.Texto.Length == 0) violaciones.Add($"s={s} {nombre}: texto vacío");
                registro.Linea($"s={s} {nombre} herramienta={r.Herramienta} nombra1={NombraUna.IsMatch(r.Texto)} pared={r.Pared:F1}s «{r.Texto.Replace("\n", " ⏎ ")}»");
            }
            if (a.Herramienta) herr41++; if (NombraUna.IsMatch(a.Texto)) ok41++;
            if (t1.Herramienta) herrT1++; if (NombraUna.IsMatch(t1.Texto)) okT1++;
            if (t2.Herramienta) herrT2++; if (NombraUna.IsMatch(t2.Texto)) okT2++;
        }

        registro.Linea($"# resultado — estimando: este pedido (cada fila, 1 pedido × {m} semillas)");
        registro.Linea($"#  4.1 llamada única: pidió la herramienta {RegistroRllm.Fraccion(herr41, m)}; nombra 1 {RegistroRllm.Fraccion(ok41, m)}");
        registro.Linea($"#  4.2 turno 1:       pidió la herramienta {RegistroRllm.Fraccion(herrT1, m)}; nombra 1 {RegistroRllm.Fraccion(okT1, m)}");
        registro.Linea($"#  4.2 turno 2:       pidió la herramienta {RegistroRllm.Fraccion(herrT2, m)}; nombra 1 {RegistroRllm.Fraccion(okT2, m)}");
        registro.Linea($"#  invariantes violadas: {violaciones.Count} {string.Join(" | ", violaciones)}");
        registro.Guardar();

        Assert.Multiple(() =>
        {
            Assert.That(violaciones, Is.Empty);
            Assert.That(herr41, Is.GreaterThanOrEqualTo(1), "la llamada única nunca pidió la herramienta");
            Assert.That(herrT1, Is.GreaterThanOrEqualTo(1), "el agente nunca pidió la herramienta");
        });
    }
}
