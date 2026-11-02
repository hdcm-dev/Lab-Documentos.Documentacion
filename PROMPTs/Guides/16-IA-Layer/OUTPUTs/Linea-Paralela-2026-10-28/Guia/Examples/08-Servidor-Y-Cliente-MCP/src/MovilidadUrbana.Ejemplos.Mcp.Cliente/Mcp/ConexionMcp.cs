using System.Net.Http.Headers;
using Microsoft.Extensions.AI;
using ModelContextProtocol.Client;

namespace MovilidadUrbana.Ejemplos.Mcp.Cliente.Mcp;

/// <summary>Pone el token del servidor MCP como encabezado HTTP, en el <c>HttpClient</c>; nunca en el cuerpo.</summary>
public sealed class ManejadorDeTokenMcp(string token) : DelegatingHandler(new HttpClientHandler())
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage pedido, CancellationToken ct)
    {
        pedido.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return base.SendAsync(pedido, ct);
    }
}

/// <summary>Conexión del cliente MCP al servidor propio, por Streamable HTTP.</summary>
public static class ConexionMcp
{
    public static async Task<McpClient> ConectarAsync(Uri endpoint, string token, CancellationToken ct = default)
    {
        var http = new HttpClient(new ManejadorDeTokenMcp(token));
        var transporte = new HttpClientTransport(
            new HttpClientTransportOptions
            {
                Endpoint = endpoint,
                TransportMode = HttpTransportMode.StreamableHttp,
                Name = "movilidad-urbana",
            },
            http, ownsHttpClient: true);
        return await McpClient.CreateAsync(transporte, cancellationToken: ct);
    }
}

/// <summary>Lo que dejó pasar la lista blanca y lo que descartó.</summary>
public sealed record HerramientasFiltradas(
    IReadOnlyList<McpClientTool> Aceptadas, IReadOnlyList<string> Descartadas, IReadOnlyList<string> Faltantes);

/// <summary>
/// Lista blanca por nombre: el agente recibe sólo las herramientas permitidas, no todas las que el
/// servidor publique (<c>tools: [.. tools]</c>). Las anotaciones del servidor (<c>readOnlyHint</c>) no deciden
/// nada acá: para un cliente son datos no confiables.
/// </summary>
public static class ListaBlanca
{
    public static HerramientasFiltradas Filtrar(IEnumerable<McpClientTool> ofrecidas, IReadOnlyCollection<string> permitidas)
    {
        var lista = ofrecidas.ToList();
        var aceptadas = lista.Where(t => permitidas.Contains(t.Name, StringComparer.Ordinal)).ToList();
        var descartadas = lista.Where(t => !permitidas.Contains(t.Name, StringComparer.Ordinal)).Select(t => t.Name).ToList();
        var faltantes = permitidas.Where(p => aceptadas.All(t => t.Name != p)).ToList();
        return new(aceptadas, descartadas, faltantes);
    }

    /// <summary>Un <see cref="McpClientTool"/> es un <see cref="AIFunction"/>: va tal cual a un agente o a un <c>IChatClient</c>.</summary>
    public static IList<AITool> ComoHerramientas(this HerramientasFiltradas filtradas) => [.. filtradas.Aceptadas];
}
