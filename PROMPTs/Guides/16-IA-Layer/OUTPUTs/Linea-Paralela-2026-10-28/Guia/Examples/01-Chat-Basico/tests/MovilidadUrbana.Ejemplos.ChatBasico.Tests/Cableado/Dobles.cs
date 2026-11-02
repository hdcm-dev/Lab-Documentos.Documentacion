using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovilidadUrbana.Ejemplos.ChatBasico.Configuracion;

namespace MovilidadUrbana.Ejemplos.ChatBasico.Tests.Cableado;

/// <summary>Configuración mínima válida, sin archivos ni variables de entorno.</summary>
public static class Configuraciones
{
    public static Dictionary<string, string?> Valida(string proveedor = Proveedores.Ollama) => new()
    {
        ["AI:Proveedor"] = proveedor,
        ["AI:Endpoint"] = "http://servidor-falso.invalid",
        ["AI:Modelo"] = "modelo-de-prueba",
        ["AI:ModeloDeEmbeddings"] = "embeddings-de-prueba",
        ["AI:NumCtx"] = "8192",
        ["AI:TimeoutSegundos"] = "30",
        ["AI:LargoMaximoDeEntrada"] = "2000",
        ["AI:Muestreo:Temperatura"] = "0.7",
        ["AI:Muestreo:TopP"] = "0.8",
        ["AI:Muestreo:TopK"] = "20",
        ["AI:Muestreo:PenalizacionPorPresencia"] = "1.5",
    };

    /// <summary>Anfitrión con la composición real; sin appsettings ni variables (DisableDefaults).</summary>
    public static IHost Anfitrion(Dictionary<string, string?> config, HttpMessageHandler? servidor = null,
        Action<IServiceCollection>? reemplazos = null)
    {
        var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings { DisableDefaults = true });
        builder.Configuration.AddInMemoryCollection(config);
        builder.AgregarCapaDeIA(leerVariable: _ => null);
        if (servidor is not null)
            builder.Services.AddHttpClient(ComposicionDeIA.NombreDelHttpClient)
                .ConfigurePrimaryHttpMessageHandler(() => servidor); // el último manejador primario gana
        reemplazos?.Invoke(builder.Services);
        return builder.Build();
    }
}

/// <summary>Servidor HTTP falso: registra el pedido tal como sale del cliente y responde lo mínimo.</summary>
public sealed class ServidorFalso : HttpMessageHandler
{
    public sealed record Pedido(string Ruta, string? Autorizacion, string Cuerpo)
    {
        public JsonObject Json => JsonNode.Parse(Cuerpo)!.AsObject();
    }

    public List<Pedido> Pedidos { get; } = [];

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage pedido, CancellationToken ct)
    {
        var cuerpo = pedido.Content is null ? "" : await pedido.Content.ReadAsStringAsync(ct);
        var ruta = pedido.RequestUri!.AbsolutePath;
        Pedidos.Add(new(ruta, pedido.Headers.Authorization?.ToString(), cuerpo));

        string json, tipo;
        if (ruta.EndsWith("/api/chat"))
        {
            tipo = "application/x-ndjson";
            json = """{"model":"modelo-de-prueba","created_at":"2026-10-28T00:00:00Z","message":{"role":"assistant","content":"Cuatro dígitos."},"done":true,"done_reason":"stop","total_duration":1000,"prompt_eval_count":120,"eval_count":4,"eval_duration":100}""" + "\n";
        }
        else if (ruta.EndsWith("/v1/chat/completions"))
        {
            tipo = "application/json";
            json = """{"id":"c1","object":"chat.completion","created":1,"model":"modelo-de-prueba","choices":[{"index":0,"message":{"role":"assistant","content":"Cuatro dígitos."},"finish_reason":"stop"}],"usage":{"prompt_tokens":120,"completion_tokens":4,"total_tokens":124}}""";
        }
        else return new HttpResponseMessage(HttpStatusCode.NotFound);

        return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(json, Encoding.UTF8, tipo) };
    }
}

/// <summary>Cliente de chat falso: cuenta las llamadas y guarda los mensajes que recibió.</summary>
public sealed class ClienteDeChatFalso : IChatClient
{
    public int Llamadas { get; private set; }
    public List<List<ChatMessage>> MensajesRecibidos { get; } = [];

    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
    {
        Llamadas++;
        MensajesRecibidos.Add(messages.ToList());
        return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, $"respuesta {Llamadas}")));
    }

    public IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
        => throw new NotSupportedException();

    public object? GetService(Type serviceType, object? serviceKey = null) => null;
    public void Dispose() { }
}
