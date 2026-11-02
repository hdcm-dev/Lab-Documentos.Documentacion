using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Asistente;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests.Cableado;

[TestFixture, Category("Cableado")]
public sealed class OpcionesYTelemetriaTests
{
    [Test]
    public void SinTimeoutSegundos_NoArranca()
    {
        var ex = Assert.Throws<OptionsValidationException>(() =>
            Anfitrion.Crear(new ClienteGuionado(), entorno: "Production", configuracion: new()));
        Assert.That(ex!.Message, Does.Contain(nameof(OpcionesDeIA.TimeoutSegundos)));
    }

    /// <summary>La misma constante en UseOpenTelemetry y en el oyente: al menos un span. Con otro nombre: 0.</summary>
    [TestCase(TelemetriaDeIA.Fuente, true)]
    [TestCase("MovilidadUrbana.OtraFuente", false)]
    public async Task ActivityListener_ConLaFuenteCorrectaVeSpans_ConOtraNinguno(string fuente, bool esperaSpans)
    {
        using var host = Anfitrion.Crear(new ClienteGuionado());
        using var escucha = new Escucha(fuente);
        using var a = host.Sesion("sesion-A");

        await a.ServiceProvider.GetRequiredService<IAsistente>().PreguntarAsync("¿Cuántas localidades hay cargadas en Chaco?");

        if (esperaSpans) Assert.That(escucha.Spans(), Has.Count.GreaterThanOrEqualTo(1));
        else Assert.That(escucha.Spans(), Is.Empty);
    }

    /// <summary>El contenido de los mensajes va a la telemetría sólo en Development.</summary>
    [TestCase("Development", true)]
    [TestCase("Production", false)]
    public void EnableSensitiveData_SoloEnDevelopment(string entorno, bool esperado)
    {
        using var host = Anfitrion.Crear(new ClienteGuionado(), entorno: entorno);
        using var a = host.Sesion("sesion-A");
        var otel = a.ServiceProvider.GetRequiredService<IChatClient>().GetService<OpenTelemetryChatClient>();

        Assert.That(otel, Is.Not.Null);
        Assert.That(otel!.EnableSensitiveData, Is.EqualTo(esperado));
    }

    /// <summary>El orden del pipeline, de afuera hacia adentro, leído de la instancia resuelta.</summary>
    [Test]
    public void ElPipelineQuedaEnElOrden_Cache_Funciones_Telemetria_Cliente()
    {
        using var host = Anfitrion.Crear(new ClienteGuionado());
        using var a = host.Sesion("sesion-A");
        var orden = new List<string>();
        IChatClient? c = a.ServiceProvider.GetRequiredService<IChatClient>();
        while (c is not null)
        {
            orden.Add(c.GetType().Name);
            c = c is DelegatingChatClient d ? Interno(d) : null;
        }

        Assert.That(orden, Is.EqualTo(new[]
            { nameof(CacheConContador), nameof(FunctionInvokingChatClient), nameof(OpenTelemetryChatClient), nameof(ClienteGuionado) }));
    }

    /// <summary>Ningún endpoint, modelo, num_ctx ni timeout literal en src/ fuera de OpcionesDeIA y los appsettings.</summary>
    [Test]
    public void NingunLiteralFueraDeLasOpciones()
    {
        var raiz = new DirectoryInfo(AppContext.BaseDirectory);
        while (raiz is not null && !Directory.Exists(Path.Combine(raiz.FullName, "src"))) raiz = raiz.Parent;
        Assert.That(raiz, Is.Not.Null);
        string[] prohibidos = ["localhost:11434", "qwen3.5", "8192", "num_ctx\"] = 4096", "TimeSpan.FromSeconds(300)"];
        var hallazgos = Directory.EnumerateFiles(Path.Combine(raiz!.FullName, "src"), "*.cs", SearchOption.AllDirectories)
            .Where(f => !f.Contains($"{Path.DirectorySeparatorChar}obj{Path.DirectorySeparatorChar}") && Path.GetFileName(f) != "OpcionesDeIA.cs")
            .SelectMany(f => File.ReadLines(f).Select((l, i) => (f, i, l)))
            .Where(x => prohibidos.Any(p => x.l.Contains(p, StringComparison.Ordinal)))
            .Select(x => $"{Path.GetFileName(x.f)}:{x.i + 1}: {x.l.Trim()}")
            .ToList();

        Assert.That(hallazgos, Is.Empty);
    }

    private static IChatClient? Interno(DelegatingChatClient d) =>
        typeof(DelegatingChatClient).GetProperty("InnerClient", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)!
            .GetValue(d) as IChatClient;
}
