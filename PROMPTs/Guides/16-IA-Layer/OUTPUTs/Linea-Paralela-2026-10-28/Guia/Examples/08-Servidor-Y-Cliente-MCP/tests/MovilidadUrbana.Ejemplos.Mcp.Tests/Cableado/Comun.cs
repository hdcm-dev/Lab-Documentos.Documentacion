using System.Net.Http.Headers;
using System.Text;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Mcp;

namespace MovilidadUrbana.Ejemplos.Mcp.Tests.Cableado;

/// <summary>Piezas comunes: el servidor en proceso (Development) y un pedido MCP «initialize» crudo.</summary>
public static class Comun
{
    /// <summary>El token de demostración de <c>servidor-mcp.Development.json</c>.</summary>
    public const string TokenDeDemostracion = "token-de-demostracion-solo-development";
    public const string OrigenPermitido = "http://localhost:3000";

    public static Task<ServidorEnProceso> ServidorAsync(Dictionary<string, string?>? cambios = null) =>
        ServidorMcp.IniciarEnLoopbackAsync("Development", new Dictionary<string, string?>(cambios ?? [])
        {
            ["Mcp:OrigenesPermitidos:0"] = OrigenPermitido,
        });

    private const string Initialize =
        "{\"jsonrpc\":\"2.0\",\"id\":1,\"method\":\"initialize\",\"params\":{\"protocolVersion\":\"2025-06-18\"," +
        "\"capabilities\":{},\"clientInfo\":{\"name\":\"prueba\",\"version\":\"1\"}}}";

    /// <summary>POST de «initialize» con el Host, el token y el Origin que se pidan; devuelve el código HTTP.</summary>
    public static async Task<int> InitializeAsync(Uri endpoint, string? host = null, string? token = null, string? origen = null)
    {
        using var http = new HttpClient();
        using var pedido = new HttpRequestMessage(HttpMethod.Post, endpoint)
        {
            Content = new StringContent(Initialize, Encoding.UTF8, "application/json"),
        };
        pedido.Headers.Accept.ParseAdd("application/json");
        pedido.Headers.Accept.ParseAdd("text/event-stream");
        if (host is not null) pedido.Headers.Host = host;
        if (token is not null) pedido.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        if (origen is not null) pedido.Headers.Add("Origin", origen);
        using var respuesta = await http.SendAsync(pedido);
        return (int)respuesta.StatusCode;
    }

    /// <summary>El campo «ok» de una <c>Respuesta</c> serializada (el SDK la manda con sangría).</summary>
    public static bool Ok(string json) => System.Text.Json.JsonDocument.Parse(json).RootElement.GetProperty("ok").GetBoolean();

    /// <summary>Un campo de «datos» de una <c>Respuesta</c> serializada.</summary>
    public static System.Text.Json.JsonElement Dato(string json, string campo) =>
        System.Text.Json.JsonDocument.Parse(json).RootElement.GetProperty("datos").GetProperty(campo).Clone();

    /// <summary>Carpeta raíz del ejemplo (la que tiene el .slnx), para los barridos sobre el código.</summary>
    public static DirectoryInfo RaizDelEjemplo()
    {
        var d = new DirectoryInfo(AppContext.BaseDirectory);
        while (d is not null && !d.EnumerateFiles("*.slnx").Any()) d = d.Parent;
        return d ?? throw new DirectoryNotFoundException("No encontré el .slnx del ejemplo.");
    }
}
