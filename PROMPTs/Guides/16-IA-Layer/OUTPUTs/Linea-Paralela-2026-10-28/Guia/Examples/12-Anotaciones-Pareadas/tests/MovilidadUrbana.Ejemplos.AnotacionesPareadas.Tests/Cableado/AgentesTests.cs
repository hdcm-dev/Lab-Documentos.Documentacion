using MovilidadUrbana.Ejemplos.AnotacionesPareadas.Infrastructure.AI.AgentFramework;
using MovilidadUrbana.Ejemplos.AnotacionesPareadas.Infrastructure.AI.SemanticKernel;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.AnotacionesPareadas.Tests.Cableado;

/// <summary>
/// El bucle de cada marco con el mismo «modelo» guionado: pide resultados_por_medio una vez, recibe el
/// resultado y lo repite. Se cuentan ejecuciones de la herramienta (lecturas del almacén) y llamadas al cliente.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class AgentesTests
{
    private const string Pregunta = "¿Qué medios usa la gente de Corrientes?";
    private const string TotalDos = "(?i)\"totalDeRespuestas\":\\s*2";

    [Test]
    public async Task ChatCompletionAgent_EjecutaLaHerramientaUnaVez()
    {
        var a = new Armado();
        var texto = await AgenteDeSemanticKernel.PreguntarAsync(a.Kernel, Pregunta);

        Informar("SK", a, texto);
        Assert.That(a.Chat.HerramientasOfrecidas[0].Select(h => h.Nombre), Is.EqualTo(new[] { "Encuesta_resultados_por_medio" }));
        Assert.That(a.Almacen.Lecturas, Is.EqualTo(1));
        Assert.That(a.Chat.Llamadas, Is.EqualTo(2));
        Assert.That(texto, Does.Match(TotalDos));
    }

    [Test]
    public async Task AsAIAgent_EjecutaLaHerramientaUnaVez()
    {
        var a = new Armado();
        var texto = await AgenteDeAgentFramework.PreguntarAsync(a.Chat, a.Herramientas, Pregunta);

        Informar("MAF", a, texto);
        Assert.That(a.Chat.HerramientasOfrecidas[0].Select(h => h.Nombre), Is.EqualTo(new[] { "resultados_por_medio" }));
        Assert.That(a.Almacen.Lecturas, Is.EqualTo(1));
        Assert.That(a.Chat.Llamadas, Is.EqualTo(2));
        Assert.That(texto, Does.Match(TotalDos));
    }

    /// <summary>
    /// El resultado llega al cliente con otra forma: SK entrega el objeto del caso de uso; MAF, el JSON que
    /// serializó AIFunctionFactory (camelCase). Cómo viaja después al servidor lo decide el adaptador del
    /// proveedor; eso no se mide acá.
    /// </summary>
    [Test]
    public async Task ElResultadoLlegaAlCliente_ComoObjetoEnSk_YComoJsonEnMaf()
    {
        var sk = new Armado();
        var maf = new Armado();
        await AgenteDeSemanticKernel.PreguntarAsync(sk.Kernel, Pregunta);
        await AgenteDeAgentFramework.PreguntarAsync(maf.Chat, maf.Herramientas, Pregunta);

        TestContext.Out.WriteLine($"SK : FunctionResultContent.Result es {sk.Chat.TipoDelResultado?.FullName}");
        TestContext.Out.WriteLine($"MAF: FunctionResultContent.Result es {maf.Chat.TipoDelResultado?.FullName}");
        Assert.That(sk.Chat.TipoDelResultado, Is.EqualTo(typeof(Application.Resultados.ResultadosPorMedio)));
        Assert.That(maf.Chat.TipoDelResultado, Is.EqualTo(typeof(System.Text.Json.JsonElement)));
    }

    /// <summary>
    /// Caso rojo: el mismo IChatClient sin <c>UseKernelFunctionInvocation</c>. El agente devuelve la llamada a la
    /// herramienta como respuesta, sin ejecutarla y sin error: 0 lecturas, 1 llamada, texto vacío.
    /// </summary>
    [Test]
    public async Task ChatCompletionAgent_SinUseKernelFunctionInvocation_NoEjecutaNiFalla()
    {
        var a = new Armado(conInvocacionDeFunciones: false);
        var texto = await AgenteDeSemanticKernel.PreguntarAsync(a.Kernel, Pregunta);

        Informar("SK sin invocación", a, texto);
        Assert.That(a.Chat.NombrePedido, Is.EqualTo("Encuesta_resultados_por_medio"));
        Assert.That(a.Almacen.Lecturas, Is.EqualTo(0));
        Assert.That(a.Chat.Llamadas, Is.EqualTo(1));
        Assert.That(texto, Is.Empty);
    }

    /// <summary>
    /// Si el modelo pide el nombre corto (el de [KernelFunction]) en lugar del que le ofrecieron con el prefijo
    /// del plugin, Semantic Kernel no ejecuta nada y le devuelve al modelo un error de función no encontrada.
    /// </summary>
    [Test]
    public async Task ChatCompletionAgent_ConElNombreSinPrefijo_NoEjecuta()
    {
        var a = new Armado(usarNombreOfrecido: false);
        var texto = await AgenteDeSemanticKernel.PreguntarAsync(a.Kernel, Pregunta);

        Informar("SK sin prefijo", a, texto);
        Assert.That(a.Chat.NombrePedido, Is.EqualTo("resultados_por_medio"));
        Assert.That(a.Almacen.Lecturas, Is.EqualTo(0));
        Assert.That(a.Chat.Llamadas, Is.EqualTo(2));
        Assert.That(texto, Does.Contain("Requested function \"resultados_por_medio\" not found"));
    }

    private static void Informar(string marco, Armado a, string texto)
    {
        TestContext.Out.WriteLine($"{marco}: llamadas al cliente {a.Chat.Llamadas}; lecturas {a.Almacen.Lecturas}; nombre pedido «{a.Chat.NombrePedido}»");
        for (var i = 0; i < a.Chat.HerramientasOfrecidas.Count; i++)
            foreach (var (nombre, esquema) in a.Chat.HerramientasOfrecidas[i])
                TestContext.Out.WriteLine($"{marco}: llamada {i + 1} ofreció «{nombre}» con esquema {esquema}");
        TestContext.Out.WriteLine($"{marco}: texto final «{texto.ReplaceLineEndings(" ")}»");
    }
}
