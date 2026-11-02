using Microsoft.Agents.AI;
using Microsoft.Agents.AI.Workflows;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.Workflows;
using MovilidadUrbana.Ejemplos.Orquestacion.SinModelo;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.Orquestacion.Tests.Cableado;

/// <summary>
/// BuildSequential + AsAIAgent: el workflow se presenta con la interfaz de un agente, pero el orden de los
/// pasos sigue escrito en el grafo. Cambia sólo si cambia el código.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class SecuencialTests
{
    private static ClienteGuionado Guion() => new((_, o) =>
        o?.Instructions == AltaAsistidaSecuencial.InstruccionesDelRedactor ? "Se va a agregar Goya (Corrientes). ¿Confirmás?" : "Goya; Corrientes; 3450; 89959");

    private static string Quien(LlamadaRegistrada l) =>
        l.Instrucciones == AltaAsistidaSecuencial.InstruccionesDelRedactor ? "redactor"
        : l.Instrucciones == AltaAsistidaSecuencial.InstruccionesDelExtractor ? "extractor" : "?";

    [Test]
    public async Task ComoAgente_EsUnAIAgent_YElOrdenEsElDelGrafo()
    {
        using var a = new Anfitrion(Guion());
        var ia = a.Servicios.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
        AIAgent agente = AltaAsistidaSecuencial.ComoAgente(a.Cliente, ia);

        for (int corrida = 1; corrida <= 2; corrida++)
        {
            var respuesta = await agente.RunAsync("Agregá Goya, Corrientes, CP 3450, 89959 habitantes", await agente.CreateSessionAsync());
            TestContext.Out.WriteLine($"corrida {corrida}: {string.Join(" | ", respuesta.Messages.Select(m => $"[{m.AuthorName}] {m.Text}"))}");
        }

        var orden = a.Cliente.Llamadas.Select(Quien).ToList();
        TestContext.Out.WriteLine($"tipo: {agente.GetType().Name}; llamadas: {string.Join(" > ", orden)}; " +
                                  $"mensajes que recibió cada una: {string.Join(", ", a.Cliente.Llamadas.Select(l => l.Mensajes))}");
        Assert.Multiple(() =>
        {
            Assert.That(agente.GetType().Name, Is.EqualTo("WorkflowHostAgent"));
            Assert.That(orden, Is.EqualTo(new[] { "extractor", "redactor", "extractor", "redactor" }));
            Assert.That(a.Cliente.Llamadas.All(l => !l.OfrecioHerramientas), Is.True);
            // El redactor recibe la conversación con lo que dijo el extractor.
            Assert.That(a.Cliente.Llamadas[1].Mensajes, Is.GreaterThan(a.Cliente.Llamadas[0].Mensajes));
        });
    }

    [Test]
    public async Task InvertirElCodigo_InvierteElOrden()
    {
        using var a = new Anfitrion(Guion());
        var ia = a.Servicios.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
        AIAgent extractor = a.Cliente.AsAIAgent(new ChatClientAgentOptions { Name = "extractor", ChatOptions = FabricaDeOpcionesDeChat.Crear(ia, AltaAsistidaSecuencial.InstruccionesDelExtractor) });
        AIAgent redactor = a.Cliente.AsAIAgent(new ChatClientAgentOptions { Name = "redactor", ChatOptions = FabricaDeOpcionesDeChat.Crear(ia, AltaAsistidaSecuencial.InstruccionesDelRedactor) });

        AIAgent invertido = AgentWorkflowBuilder.BuildSequential(redactor, extractor).AsAIAgent();
        await invertido.RunAsync("Agregá Goya, Corrientes, CP 3450, 89959 habitantes", await invertido.CreateSessionAsync());

        Assert.That(a.Cliente.Llamadas.Select(Quien), Is.EqualTo(new[] { "redactor", "extractor" }));
    }
}
