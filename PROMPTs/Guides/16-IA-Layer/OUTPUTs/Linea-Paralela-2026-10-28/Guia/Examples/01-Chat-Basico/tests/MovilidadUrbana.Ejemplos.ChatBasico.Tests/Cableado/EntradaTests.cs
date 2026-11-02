using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using MovilidadUrbana.Ejemplos.ChatBasico.Conversacion;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.ChatBasico.Tests.Cableado;

[TestFixture, Category("Cableado")]
public sealed class EntradaTests
{
    private static (AsistenteDeMovilidad, ClienteDeChatFalso, IDisposable) Armar()
    {
        var falso = new ClienteDeChatFalso();
        var host = Configuraciones.Anfitrion(Configuraciones.Valida(),
            reemplazos: s => s.AddSingleton<IChatClient>(falso));
        return (host.Services.GetRequiredService<AsistenteDeMovilidad>(), falso, host);
    }

    [Test]
    public async Task EntradaDe2001Caracteres_SeRechazaSinLlamarAlModelo()
    {
        var (asistente, falso, host) = Armar();
        using var _ = host;

        var ex = await Assert.ThrowsAsync<EntradaDemasiadoLargaException>(() => asistente.PreguntarAsync(new string('a', 2001)));
        TestContext.Out.WriteLine($"2001 caracteres → {ex!.Message}; llamadas al modelo: {falso.Llamadas}");
        Assert.That(falso.Llamadas, Is.EqualTo(0));
        Assert.That(asistente.Historial, Has.Count.EqualTo(1), "el texto rechazado no entra al historial");
    }

    [Test]
    public async Task EntradaDe2000Caracteres_LlamaUnaVez()
    {
        var (asistente, falso, host) = Armar();
        using var _ = host;

        await asistente.PreguntarAsync(new string('a', 2000));
        Assert.That(falso.Llamadas, Is.EqualTo(1));
    }

    [Test]
    public async Task SegundaPregunta_ViajaConElHistorial()
    {
        var (asistente, falso, host) = Armar();
        using var _ = host;

        await asistente.PreguntarAsync("¿Cuántos dígitos lleva el código postal?");
        await asistente.PreguntarAsync("¿Y la provincia puede ser cualquiera?");

        var roles = falso.MensajesRecibidos[1].Select(m => m.Role).ToArray();
        TestContext.Out.WriteLine($"roles del segundo pedido: {string.Join(", ", roles)}");
        Assert.That(roles, Is.EqualTo(new[] { ChatRole.System, ChatRole.User, ChatRole.Assistant, ChatRole.User }));
    }
}
