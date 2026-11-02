using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Localidades;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests.Cableado;

/// <summary>
/// Ciclo de vida del pipeline (D-06), con la clase REAL <c>SessionContext</c> copiada del caso base: dos
/// sesiones concurrentes, sincronizadas con una barrera, con el pipeline Scoped o Singleton y
/// <c>ValidateScopes</c> en <c>true</c> o en <c>false</c>.
/// <para>Para medir el cruce, la prueba suma DOS herramientas de escritura que el ejemplo no registra
/// (<c>agregar_localidad_de_prueba</c> y <c>eliminar_localidad_de_prueba</c>): resuelven los servicios desde
/// el pipeline que las invoca, igual que la herramienta de lectura del catálogo.</para>
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class CicloDeVidaDelClienteTests
{
    // Cuatro fases separadas por la barrera; null = esa sesión espera la fase sin pedir nada. B lee recién
    // después de que A escribió, así el resultado no depende de cómo se intercalen los hilos.
    private const string Contar = "LLAMAR:contar_localidades_por_provincia:{\"provincia\":\"Corrientes\"}";

    private static readonly string?[] PedidosDeA =
        ["LLAMAR:agregar_localidad_de_prueba:{\"nombre\":\"Goya\"}", Contar, null, Contar];

    private static readonly string?[] PedidosDeB =
        [null, Contar, "LLAMAR:eliminar_localidad_de_prueba:{\"nombre\":\"Goya\"}", Contar];

    [TestCase(ServiceLifetime.Scoped, false)]
    [TestCase(ServiceLifetime.Scoped, true)]
    public async Task Scoped_SinCruce_BNoVeNiBorraLoDeA(ServiceLifetime vida, bool validarScopes)
    {
        var (a, b) = await Correr(vida, validarScopes);

        Assert.Multiple(() =>
        {
            Assert.That(Cruces(a, b), Is.Empty);
            Assert.That(a, Is.EqualTo(new[] { "agregada Goya", "cantidad 2", "-", "cantidad 2" }));
            Assert.That(b, Is.EqualTo(new[] { "-", "cantidad 1", "borradas 0", "cantidad 1" }));
        });
    }

    /// <summary>
    /// Caso rojo: con un Singleton y ValidateScopes = false, las herramientas resuelven el SessionContext de la
    /// raíz, con su Guid provisorio: las dos conversaciones comparten un único espacio. B ve la localidad que
    /// creó A y la borra, sin error. La prueba de arriba detecta ese cruce.
    /// </summary>
    [Test]
    public async Task Singleton_ValidateScopesFalse_CasoRojo_BVeYBorraLoDeA_SinError()
    {
        var (a, b) = await Correr(ServiceLifetime.Singleton, validarScopes: false);

        Assert.Multiple(() =>
        {
            Assert.That(Cruces(a, b), Is.Not.Empty, "la verificación de cruce detecta el defecto");
            Assert.That(b[1], Is.EqualTo("cantidad 2"), "B vio la localidad de A");
            Assert.That(b[2], Is.EqualTo("borradas 1"), "B borró la localidad de A");
            Assert.That(a[3], Is.EqualTo("cantidad 1"), "A perdió lo suyo");
            Assert.That(a.Concat(b), Has.None.StartsWith("EXC"), "sin error");
        });
    }

    /// <summary>Con un Singleton y ValidateScopes = true no falla al construir el contenedor: falla en CADA llamada a la herramienta.</summary>
    [Test]
    public async Task Singleton_ValidateScopesTrue_FallaEnCadaLlamadaALaHerramienta()
    {
        var (a, b) = await Correr(ServiceLifetime.Singleton, validarScopes: true);

        var llamadas = a.Concat(b).Where(x => x != "-").ToList();
        Assert.That(llamadas, Has.Count.EqualTo(6));
        Assert.That(llamadas, Has.All.EqualTo("EXC InvalidOperationException"));
    }

    private static List<string> Cruces(IReadOnlyList<string> a, IReadOnlyList<string> b)
    {
        var cruces = new List<string>();
        if (b[1] != "cantidad 1") cruces.Add($"B vio «{b[1]}» (lo suyo es 1)");
        if (b[2] != "borradas 0") cruces.Add($"B borró algo de A: «{b[2]}»");
        if (a[3] != "cantidad 2") cruces.Add($"A perdió lo suyo: «{a[3]}»");
        return cruces;
    }

    private static async Task<(List<string> A, List<string> B)> Correr(ServiceLifetime vida, bool validarScopes)
    {
        var falso = new ClienteGuionado();
        using var host = Anfitrion.Crear(falso, vida, validarScopes, configuracion: new()
        {
            ["AI:TimeoutSegundos"] = "300",
            ["AI:CacheDeRespuestas"] = "false",   // se aísla el efecto sobre las herramientas
        });
        var herramientas = HerramientasDeLocalidades.Catalogo.Concat(HerramientasDePrueba()).ToList();
        using var barrera = new Barrier(2);

        async Task<List<string>> Sesion(string id, string?[] pedidos)
        {
            await Task.Yield();
            using var ambito = host.Sesion(id);
            var chat = ambito.ServiceProvider.GetRequiredService<IChatClient>();
            var vistos = new List<string>();
            foreach (var pedido in pedidos)
            {
                barrera.SignalAndWait(TimeSpan.FromSeconds(10));
                if (pedido is null) { vistos.Add("-"); continue; }
                var r = await chat.GetResponseAsync(pedido, new ChatOptions { Tools = herramientas });
                vistos.Add(Resumir(r.Text));
            }
            barrera.SignalAndWait(TimeSpan.FromSeconds(10));
            return vistos;
        }

        var a = Task.Run(() => Sesion("sesion-A", PedidosDeA));
        var b = Task.Run(() => Sesion("sesion-B", PedidosDeB));
        var res = await Task.WhenAll(a, b);
        return (res[0], res[1]);
    }

    private static string Resumir(string texto) =>
        texto.StartsWith("Hay ", StringComparison.Ordinal) ? $"cantidad {texto.Split(' ')[1]}" : texto.Trim('"');

    private static IEnumerable<AITool> HerramientasDePrueba() =>
    [
        AIFunctionFactory.Create(async (string nombre, AIFunctionArguments argumentos, CancellationToken ct) =>
        {
            var r = await argumentos.Services!.GetRequiredService<AltaDeLocalidad>().RegistrarAsync(
                new LocalidadModel { Nombre = nombre, Provincia = "Corrientes", CodigoPostal = "3450", Habitantes = 89959 }, ct);
            return r.IsSuccess ? $"agregada {nombre}" : $"rechazada {nombre}";
        }, "agregar_localidad_de_prueba"),
        AIFunctionFactory.Create(async (string nombre, AIFunctionArguments argumentos, CancellationToken ct) =>
        {
            var servicio = argumentos.Services!.GetRequiredService<LocalidadService>();
            var objetivo = (await servicio.GetAllAsync(ct)).Where(l => l.Nombre == nombre).ToList();
            foreach (var l in objetivo) await servicio.DeleteAsync(l.Id, ct);
            return $"borradas {objetivo.Count}";
        }, "eliminar_localidad_de_prueba"),
    ];
}
