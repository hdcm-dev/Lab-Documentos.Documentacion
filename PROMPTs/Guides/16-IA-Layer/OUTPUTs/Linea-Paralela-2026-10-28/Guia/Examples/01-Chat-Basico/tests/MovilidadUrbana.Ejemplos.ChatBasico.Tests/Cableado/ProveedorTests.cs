using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using MovilidadUrbana.Ejemplos.ChatBasico.Configuracion;
using NUnit.Framework;
using OllamaSharp;

namespace MovilidadUrbana.Ejemplos.ChatBasico.Tests.Cableado;

/// <summary>El selector AI:Proveedor cambia el adaptador; el resto del código sigue viendo IChatClient.</summary>
[TestFixture, Category("Cableado")]
public sealed class ProveedorTests
{
    [Test]
    public void Ollama_DaElClienteNativo()
    {
        using var host = Configuraciones.Anfitrion(Configuraciones.Valida(Proveedores.Ollama));
        var chat = host.Services.GetRequiredService<IChatClient>();
        TestContext.Out.WriteLine($"ollama → {chat.GetType().FullName}; proveedor según metadatos: {chat.GetService<ChatClientMetadata>()?.ProviderName}");
        Assert.That(chat, Is.InstanceOf<OllamaApiClient>());
    }

    [Test]
    public void OpenAICompatible_DaElAdaptadorDeOpenAI()
    {
        using var host = Configuraciones.Anfitrion(Configuraciones.Valida(Proveedores.OpenAICompatible));
        var chat = host.Services.GetRequiredService<IChatClient>();
        TestContext.Out.WriteLine($"openai-compatible → {chat.GetType().FullName}; proveedor según metadatos: {chat.GetService<ChatClientMetadata>()?.ProviderName}");
        Assert.That(chat.GetService<OpenAI.Chat.ChatClient>(), Is.Not.Null);
    }
}
