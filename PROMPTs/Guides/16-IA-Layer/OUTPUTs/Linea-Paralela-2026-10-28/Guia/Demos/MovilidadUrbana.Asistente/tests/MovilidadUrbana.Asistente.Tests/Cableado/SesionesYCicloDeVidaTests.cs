using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.Asistente.Infrastructure.AI;
using MovilidadUrbana.Asistente.Tests.Comun;

namespace MovilidadUrbana.Asistente.Tests.Cableado;

/// <summary>
/// CTRL-06, forma (a)–(c): (a) con la clase real SessionContext copiada; (b) dos sesiones concurrentes con
/// barrera, ValidateScopes en true y en false, cadena Singleton y Scoped; (c) sin cruce con Scoped, y con
/// Singleton la prueba detecta el defecto (caso rojo esperado).
/// </summary>
[TestFixture]
public sealed class SesionesYCicloDeVidaTests
{
    private sealed record Vista(string Sesion, string Texto, Exception? Error);

    private static async Task<(Vista A, Vista B)> CorrerDosSesiones(ServiceLifetime cicloDeVida, bool validarScopes)
    {
        // El «modelo» pide listar y después repite lo que recibió. Reactivo: sirve con concurrencia.
        var falso = ClienteFalso.Reactivo(v => v.UltimoResultado is null ? Responde.Llamar("listar_localidades") : Responde.EcoDelResultado(v));
        using var comp = new Composicion(falso, validarScopes, cicloDeVida);

        // La sesión A da de alta Goya por la operación normal (caso de uso copiado), en su propio ámbito.
        await using (var a = comp.Ambito("sesion-A"))
        {
            var r = await a.ServiceProvider.GetRequiredService<LocalidadService>()
                .SaveAsync(new LocalidadModel { Nombre = "Goya", Provincia = "Corrientes", CodigoPostal = "3450", Habitantes = 89959 });
            Assert.That(r.IsSuccess, Is.True);
        }

        using var barrera = new Barrier(2);
        async Task<Vista> Sesion(string id)
        {
            await Task.Yield();
            await using var ambito = comp.Ambito(id);
            var chat = ambito.ServiceProvider.GetRequiredService<IChatClient>();
            barrera.SignalAndWait(TimeSpan.FromSeconds(10));
            var r = await chat.GetResponseAsync("¿Qué localidades tengo?", new ChatOptions { Tools = [.. CatalogoDeHerramientas.Todas] });
            var error = r.Messages.SelectMany(m => m.Contents).OfType<FunctionResultContent>().Select(f => f.Exception).FirstOrDefault(e => e is not null);
            return new Vista(id, r.Text, error);
        }

        var resultados = await Task.WhenAll(Task.Run(() => Sesion("sesion-A")), Task.Run(() => Sesion("sesion-B")));
        return (resultados[0], resultados[1]);
    }

    private static bool Aislado(Vista a, Vista b) => a.Texto.Contains("Goya") && !b.Texto.Contains("Goya");

    [TestCase(true)]
    [TestCase(false)]
    public async Task CTRL06_con_la_cadena_Scoped_cada_sesion_ve_solo_lo_suyo(bool validarScopes)
    {
        var (a, b) = await CorrerDosSesiones(ServiceLifetime.Scoped, validarScopes);
        TestContext.Out.WriteLine($"A: {a.Texto}\nB: {b.Texto}");
        Assert.Multiple(() =>
        {
            Assert.That(Aislado(a, b), Is.True, "A ve su Goya y B no lo ve");
            Assert.That(a.Error, Is.Null);
            Assert.That(b.Error, Is.Null);
        });
    }

    [Test]
    public async Task CTRL06_caso_rojo_Singleton_con_ValidateScopes_false_comparte_un_unico_espacio_sin_error()
    {
        var (a, b) = await CorrerDosSesiones(ServiceLifetime.Singleton, validarScopes: false);
        TestContext.Out.WriteLine($"A: {a.Texto}\nB: {b.Texto}");
        Assert.Multiple(() =>
        {
            Assert.That(Aislado(a, b), Is.False, "la prueba de aislamiento detecta el defecto");
            Assert.That(a.Texto, Is.EqualTo(b.Texto), "las dos conversaciones leen el mismo espacio: el de la raíz");
            Assert.That(a.Error, Is.Null, "y no hay ningún error que lo avise");
        });
    }

    [Test]
    public async Task CTRL06_Singleton_con_ValidateScopes_true_falla_en_cada_llamada_a_la_herramienta()
    {
        var (a, b) = await CorrerDosSesiones(ServiceLifetime.Singleton, validarScopes: true);
        TestContext.Out.WriteLine($"A: {a.Error?.GetType().Name}: {a.Error?.Message}");
        Assert.Multiple(() =>
        {
            Assert.That(a.Error, Is.TypeOf<InvalidOperationException>());
            Assert.That(b.Error, Is.TypeOf<InvalidOperationException>());
            Assert.That(Aislado(a, b), Is.False);
        });
    }
}
