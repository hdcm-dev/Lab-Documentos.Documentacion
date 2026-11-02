using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.Ejemplos.Orquestacion.Application.Altas;
using MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.Persistence;
using MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.Workflows;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.Orquestacion.Tests.ConModelo;

/// <summary>
/// Contra el servidor de prueba. Criterio escrito antes de correr:
///  - workflow de alta, P1 «CP 34» y P2 «CP 3450», m semillas: invariantes (camino fijado por código, 1 llamada sin
///    herramientas, escrituras sólo con «Registrada», sin excepción); tasas de este pedido sin umbral;
///  - secuencial extractor → redactor con P2: invariantes (2 llamadas en ese orden, sin herramientas); tasas de este pedido.
/// </summary>
[TestFixture, Category("ConModelo")]
public sealed class WorkflowConModeloTests
{
    private const string P1 = "Agregá Goya, Corrientes, CP 34, 89959 habitantes";
    private const string P2 = "Agregá Goya, Corrientes, CP 3450, 89959 habitantes";
    private static readonly PropuestaDeAlta Exacta = new("Goya", "Corrientes", "3450", 89959);
    private static readonly string[] Rechazado = [WorkflowDeAlta.Extraer, WorkflowDeAlta.Revisar, WorkflowDeAlta.Rechazo];
    private static readonly string[] Confirmado = [WorkflowDeAlta.Extraer, WorkflowDeAlta.Revisar, WorkflowDeAlta.ConfirmarAlta, WorkflowDeAlta.Registrar];

    /// <summary>Envuelve el puerto para ver qué propuso el modelo, sin tocar el workflow.</summary>
    private sealed class ExtractorQueRegistra(IExtractorDeAlta interno) : IExtractorDeAlta
    {
        public PropuestaDeAlta? Ultima { get; private set; }
        public async Task<PropuestaDeAlta?> ExtraerAsync(string texto, CancellationToken cancellationToken = default) =>
            Ultima = await interno.ExtraerAsync(texto, cancellationToken);
    }

    [Test]
    public async Task WorkflowDeAlta_ConElModelo()
    {
        int m = ServidorDePrueba.Semillas;
        var registro = new RegistroRllm("workflow-de-alta");
        var violaciones = new List<string>();
        var paredes = new List<double>();
        int p1Cp34 = 0, p1Rechazada = 0, p1Inventado = 0, p2Exacta = 0, p2Registrada = 0;

        for (int s = 1; s <= m; s++)
        {
            var (host, ambito, contador) = ServidorDePrueba.Anfitrion(s);
            using var _h = host; using var _a = ambito;
            var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            if (s == 1)
            {
                var (version, digest) = await ServidorDePrueba.Identificar(ia);
                registro.Linea(ServidorDePrueba.Cabecera(ia, version, digest, $"este pedido, 2 pedidos × {m} semillas"));
                registro.Linea($"# rótulo: {ServidorDePrueba.Estacion}");
                registro.Linea("# persona simulada: confirma sólo si la propuesta es exactamente Goya / Corrientes / 3450 / 89959");
            }

            foreach (var pedido in new[] { P1, P2 })
            {
                var almacen = host.Services.GetRequiredService<AlmacenEnMemoria>();
                int escriturasAntes = almacen.Escrituras, llamadasAntes = contador.Llamadas.Count;
                var extractor = new ExtractorQueRegistra(ambito.ServiceProvider.GetRequiredService<IExtractorDeAlta>());
                var workflow = WorkflowDeAlta.Construir(extractor, ambito.ServiceProvider.GetRequiredService<LocalidadService>());
                bool? respondio = null;
                TrazaDelAlta? traza = null;
                var reloj = Stopwatch.StartNew();
                try
                {
                    traza = await WorkflowDeAlta.EjecutarAsync(workflow, pedido, r => new ConfirmacionDeAlta((respondio = r.Propuesta == Exacta).Value));
                }
                catch (Exception ex) { violaciones.Add($"s={s} «{pedido}»: {ex.GetType().Name}: {ex.InnerException?.Message ?? ex.Message}"); }
                reloj.Stop();
                paredes.Add(reloj.Elapsed.TotalSeconds);

                var llamadas = contador.Llamadas.Skip(llamadasAntes).ToList();
                int escrituras = almacen.Escrituras - escriturasAntes;
                if (llamadas.Count != 1 || llamadas.Any(l => l.Herramientas)) violaciones.Add($"s={s}: {llamadas.Count} llamadas (herramientas: {llamadas.Any(l => l.Herramientas)})");
                if (traza is null) continue;
                bool camino = traza.Pasos.SequenceEqual(Rechazado) || traza.Pasos.SequenceEqual(Confirmado);
                if (!camino) violaciones.Add($"s={s}: camino {string.Join(" > ", traza.Pasos)}");
                bool registrada = traza.Resultado?.Estado == EstadoDelAlta.Registrada;
                if (escrituras != (registrada ? 1 : 0) || (registrada && respondio != true)) violaciones.Add($"s={s}: {escrituras} escrituras con resultado {traza.Resultado?.Estado} y respuesta {respondio}");

                var p = extractor.Ultima;
                bool rechazada = traza.Pasos.SequenceEqual(Rechazado);
                if (pedido == P1)
                {
                    bool cp34 = p?.CodigoPostal?.Trim() == "34";
                    bool inventado = !rechazada && p?.CodigoPostal is { Length: 4 } cp && cp != "34";
                    p1Cp34 += cp34 ? 1 : 0; p1Rechazada += rechazada ? 1 : 0; p1Inventado += inventado ? 1 : 0;
                }
                else
                {
                    p2Exacta += p == Exacta ? 1 : 0; p2Registrada += registrada ? 1 : 0;
                }
                registro.Linea($"s={s} pedido=«{pedido}» propuesta={p?.ToString() ?? "null"} pasos={string.Join(">", traza.Pasos)} " +
                               $"persona={respondio?.ToString() ?? "-"} resultado={traza.Resultado} escrituras={escrituras} pared={reloj.Elapsed.TotalSeconds:F1}s");
            }
        }

        var orden = paredes.Order().ToList();
        registro.Linea("# resultado (estimando: este pedido; cada fila por separado, no se comparan):");
        registro.Linea($"#  P1 «CP 34» — propuesta con CP 34: {RegistroRllm.Fraccion(p1Cp34, m)}; rechazada por la revisión: {RegistroRllm.Fraccion(p1Rechazada, m)}; llegó a la persona con un CP de 4 dígitos inventado: {RegistroRllm.Fraccion(p1Inventado, m)}");
        registro.Linea($"#  P2 «CP 3450» — propuesta exacta: {RegistroRllm.Fraccion(p2Exacta, m)}; registrada: {RegistroRllm.Fraccion(p2Registrada, m)}");
        registro.Linea($"#  invariantes violadas: {violaciones.Count}; pared por corrida del workflow: mediana {orden[orden.Count / 2]:F1} s (mín {orden[0]:F1}, máx {orden[^1]:F1}, N = {orden.Count})");
        foreach (var v in violaciones) registro.Linea($"#  violación: {v}");
        registro.Guardar();
        Assert.That(violaciones, Is.Empty);
    }

    [Test]
    public async Task Secuencial_ConElModelo()
    {
        int m = ServidorDePrueba.Semillas;
        var registro = new RegistroRllm("secuencial");
        var violaciones = new List<string>();
        var paredes = new List<double>();
        int extractor3450 = 0, nombra = 0, redactor3450 = 0;
        var goyaYCorrientes = new Regex("Goya.*Corrientes|Corrientes.*Goya", RegexOptions.Singleline);

        for (int s = 1; s <= m; s++)
        {
            var (host, ambito, contador) = ServidorDePrueba.Anfitrion(s);
            using var _h = host; using var _a = ambito;
            var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            if (s == 1)
            {
                var (version, digest) = await ServidorDePrueba.Identificar(ia);
                registro.Linea(ServidorDePrueba.Cabecera(ia, version, digest, $"este pedido, 1 pedido × {m} semillas"));
                registro.Linea($"# rótulo: {ServidorDePrueba.Estacion}");
            }

            var agente = AltaAsistidaSecuencial.ComoAgente(contador, ia);
            var reloj = Stopwatch.StartNew();
            Microsoft.Agents.AI.AgentResponse? respuesta = null;
            try { respuesta = await agente.RunAsync(P2, await agente.CreateSessionAsync()); }
            catch (Exception ex) { violaciones.Add($"s={s}: {ex.GetType().Name}: {ex.Message}"); }
            reloj.Stop();
            paredes.Add(reloj.Elapsed.TotalSeconds);

            var quien = contador.Llamadas.Select(l => l.Instrucciones == AltaAsistidaSecuencial.InstruccionesDelRedactor ? "redactor"
                : l.Instrucciones == AltaAsistidaSecuencial.InstruccionesDelExtractor ? "extractor" : "?").ToList();
            if (!quien.SequenceEqual(["extractor", "redactor"]) || contador.Llamadas.Any(l => l.Herramientas))
                violaciones.Add($"s={s}: llamadas {string.Join(">", quien)}");
            if (respuesta is null) continue;

            string deExtractor = string.Join(" ", respuesta.Messages.Where(x => x.AuthorName == AltaAsistidaSecuencial.NombreDelExtractor).Select(x => x.Text));
            string deRedactor = string.Join(" ", respuesta.Messages.Where(x => x.AuthorName == AltaAsistidaSecuencial.NombreDelRedactor).Select(x => x.Text));
            extractor3450 += deExtractor.Contains("3450") ? 1 : 0;
            nombra += goyaYCorrientes.IsMatch(deRedactor) ? 1 : 0;
            redactor3450 += deRedactor.Contains("3450") ? 1 : 0;
            registro.Linea($"s={s} llamadas={string.Join(">", quien)} pared={reloj.Elapsed.TotalSeconds:F1}s extractor=«{deExtractor.Replace("\n", " ⏎ ")}» redactor=«{deRedactor.Replace("\n", " ⏎ ")}»");
        }

        var orden = paredes.Order().ToList();
        registro.Linea("# resultado (estimando: este pedido):");
        registro.Linea($"#  la línea del extractor contiene 3450: {RegistroRllm.Fraccion(extractor3450, m)}; el redactor nombra Goya y Corrientes: {RegistroRllm.Fraccion(nombra, m)}; el redactor contiene 3450: {RegistroRllm.Fraccion(redactor3450, m)}");
        registro.Linea($"#  invariantes violadas: {violaciones.Count}; pared por corrida (2 llamadas): mediana {orden[orden.Count / 2]:F1} s (mín {orden[0]:F1}, máx {orden[^1]:F1}, N = {orden.Count})");
        foreach (var v in violaciones) registro.Linea($"#  violación: {v}");
        registro.Guardar();
        Assert.That(violaciones, Is.Empty);
    }
}
