using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.ToolCalling.Application.Asistente;
using MovilidadUrbana.Ejemplos.ToolCalling.Infrastructure.AI;

namespace MovilidadUrbana.Ejemplos.ToolCalling.Tests.Cableado;

/// <summary>Configuración mínima válida y anfitrión con la composición real, sin archivos ni variables.</summary>
public static class Configuraciones
{
    public static Dictionary<string, string?> Valida(string proveedor = Proveedores.Ollama) => new()
    {
        ["AI:Proveedor"] = proveedor,
        ["AI:Endpoint"] = "http://servidor-falso.invalid",
        ["AI:Modelo"] = "modelo-de-prueba",
        ["AI:NumCtx"] = "8192",
        ["AI:TimeoutSegundos"] = "30",
        ["AI:LargoMaximoDeEntrada"] = "2000",
        ["AI:Herramientas:MaximoDeIteraciones"] = "3",
        ["AI:Herramientas:MaximoDeErroresConsecutivos"] = "2",
    };

    public static IHost Anfitrion(Dictionary<string, string?> config,
        Func<IServiceProvider, IChatClient>? clienteInterno = null, HttpMessageHandler? servidor = null,
        Action<IServiceCollection>? reemplazos = null)
    {
        var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings { DisableDefaults = true });
        builder.Configuration.AddInMemoryCollection(config);
        builder.AgregarCapaDeIA(leerVariable: _ => null, clienteInterno: clienteInterno);
        if (servidor is not null)
            builder.Services.AddHttpClient(ComposicionDeIA.NombreDelHttpClient)
                .ConfigurePrimaryHttpMessageHandler(() => servidor); // el último manejador primario gana
        reemplazos?.Invoke(builder.Services);
        var host = builder.Build();
        host.Start(); // ValidateOnStart
        return host;
    }

    /// <summary>Un ámbito con su sesión fijada: lo que hace el middleware de sesión en el caso base.</summary>
    public static (IServiceScope Ambito, IAsistenteDeLocalidades Asistente) Sesion(IHost host, string sesion)
    {
        var ambito = host.Services.CreateScope();
        ambito.ServiceProvider.GetRequiredService<SessionContext>().Set(sesion);
        return (ambito, ambito.ServiceProvider.GetRequiredService<IAsistenteDeLocalidades>());
    }
}

/// <summary>
/// «Modelo» guionado: en la primera vuelta pide la herramienta del guion; cuando le vuelve el resultado,
/// contesta texto. Guarda los resultados que vio, tal como le llegaron.
/// </summary>
public sealed class ClienteGuionado(string herramienta, Dictionary<string, object?> argumentos) : IChatClient
{
    public int Llamadas { get; private set; }
    public List<string> ResultadosVistos { get; } = [];
    public List<ChatOptions?> OpcionesRecibidas { get; } = [];

    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
    {
        Llamadas++;
        OpcionesRecibidas.Add(options);
        var ultimo = messages.Last();
        var resultado = ultimo.Contents.OfType<FunctionResultContent>().LastOrDefault();
        if (resultado is not null)
        {
            ResultadosVistos.Add(System.Text.Json.JsonSerializer.Serialize(resultado.Result));
            return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, "listo")));
        }
        return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant,
            [new FunctionCallContent($"c{Llamadas}", herramienta, argumentos)])));
    }

    public IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
        => throw new NotSupportedException();
    public object? GetService(Type serviceType, object? serviceKey = null) => null;
    public void Dispose() { }
}

/// <summary>«Modelo» que nunca termina: en cada vuelta vuelve a pedir la herramienta. Sirve para ver el corte del bucle.</summary>
public sealed class ClienteQueNoTermina(string herramienta, Dictionary<string, object?> argumentos) : IChatClient
{
    public int Llamadas { get; private set; }
    public List<ChatOptions?> OpcionesRecibidas { get; } = [];

    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
    {
        Llamadas++;
        OpcionesRecibidas.Add(options?.Clone());
        // Si el bucle le saca las herramientas, contesta texto (lo haría cualquier modelo sin herramientas).
        if (options?.Tools is not { Count: > 0 } || options.ToolMode is NoneChatToolMode)
            return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, "respuesta sin herramientas")));
        return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant,
            [new FunctionCallContent($"c{Llamadas}", herramienta, argumentos)])));
    }

    public IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
        => throw new NotSupportedException();
    public object? GetService(Type serviceType, object? serviceKey = null) => null;
    public void Dispose() { }
}

/// <summary>
/// Servidor HTTP falso que habla los dos protocolos: en el primer pedido devuelve un pedido de herramienta
/// (en el formato de cada vía) y en el segundo, texto. Registra cada cuerpo tal como sale del cliente.
/// </summary>
public sealed class ServidorFalsoConHerramientas(string herramienta, string argumentosJson) : HttpMessageHandler
{
    public sealed record Pedido(string Ruta, string Cuerpo)
    {
        public JsonObject Json => JsonNode.Parse(Cuerpo)!.AsObject();
    }

    public List<Pedido> Pedidos { get; } = [];

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage pedido, CancellationToken ct)
    {
        var cuerpo = pedido.Content is null ? "" : await pedido.Content.ReadAsStringAsync(ct);
        var ruta = pedido.RequestUri!.AbsolutePath;
        Pedidos.Add(new(ruta, cuerpo));
        bool primera = Pedidos.Count(p => p.Ruta == ruta) == 1;

        string json, tipo;
        if (ruta.EndsWith("/api/chat"))
        {
            tipo = "application/x-ndjson";
            var mensaje = primera
                ? "{\"role\":\"assistant\",\"content\":\"\",\"tool_calls\":[{\"function\":{\"name\":\"" + herramienta + "\",\"arguments\":" + argumentosJson + "}}]}"
                : """{"role":"assistant","content":"Hay 1 localidad cargada en Chaco."}""";
            json = "{\"model\":\"modelo-de-prueba\",\"created_at\":\"2026-10-28T00:00:00Z\",\"message\":" + mensaje +
                   ",\"done\":true,\"done_reason\":\"stop\",\"prompt_eval_count\":200,\"eval_count\":10}\n";
        }
        else if (ruta.EndsWith("/v1/chat/completions"))
        {
            tipo = "application/json";
            var argumentosComoTexto = System.Text.Json.JsonSerializer.Serialize(argumentosJson); // por /v1 los argumentos viajan como texto
            var eleccion = primera
                ? "{\"index\":0,\"message\":{\"role\":\"assistant\",\"content\":null,\"tool_calls\":[{\"id\":\"call_1\",\"type\":\"function\",\"function\":{\"name\":\"" + herramienta + "\",\"arguments\":" + argumentosComoTexto + "}}]},\"finish_reason\":\"tool_calls\"}"
                : """{"index":0,"message":{"role":"assistant","content":"Hay 1 localidad cargada en Chaco."},"finish_reason":"stop"}""";
            json = "{\"id\":\"c1\",\"object\":\"chat.completion\",\"created\":1,\"model\":\"modelo-de-prueba\",\"choices\":[" + eleccion +
                   "],\"usage\":{\"prompt_tokens\":200,\"completion_tokens\":10,\"total_tokens\":210}}";
        }
        else return new HttpResponseMessage(HttpStatusCode.NotFound);

        return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(json, Encoding.UTF8, tipo) };
    }
}
