using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;

namespace MovilidadUrbana.Ejemplos.Mcp.Servidor.Mcp;

/// <summary>
/// Validación de <c>Origin</c> sobre la ruta MCP. La especificación del transporte Streamable HTTP pide
/// validar <c>Origin</c> en toda conexión y responder 403 si viene y no es válido; el SDK
/// ModelContextProtocol.AspNetCore 2.3.0 no lo hace, así que lo hace la app.
/// </summary>
public sealed class ValidacionDeOrigen(RequestDelegate siguiente, IOptions<OpcionesDelServidorMcp> opciones)
{
    public Task InvokeAsync(HttpContext contexto)
    {
        var origen = contexto.Request.Headers.Origin.ToString();
        if (origen.Length > 0 && !opciones.Value.OrigenesPermitidos.Contains(origen, StringComparer.OrdinalIgnoreCase))
        {
            contexto.Response.StatusCode = StatusCodes.Status403Forbidden;
            return Task.CompletedTask;
        }
        return siguiente(contexto);
    }
}

/// <summary>
/// Sesión fija de demostración, DECLARADA: todo pedido MCP trabaja sobre el espacio de datos
/// <see cref="Id"/>, diga lo que diga el cliente. El servidor no lee <c>X-Sesion-Id</c> (en el caso base lo
/// elige el cliente, y eso es débil) ni lo confunde con el <c>Mcp-Session-Id</c> del protocolo.
/// En CTX-PROD el espacio de datos sale de la identidad autenticada, no de una constante.
/// </summary>
public sealed class SesionFijaDeDemostracion(RequestDelegate siguiente)
{
    public const string Id = "demostracion-mcp";

    public Task InvokeAsync(HttpContext contexto, SessionContext sesion)
    {
        sesion.Set(Id);
        return siguiente(contexto);
    }
}

/// <summary>Autenticación por token fijo (<c>Authorization: Bearer</c>), comparado en tiempo constante.</summary>
public sealed class AutenticacionPorToken(
    IOptionsMonitor<AuthenticationSchemeOptions> esquema, ILoggerFactory registro, UrlEncoder codificador,
    IOptions<OpcionesDelServidorMcp> opciones)
    : AuthenticationHandler<AuthenticationSchemeOptions>(esquema, registro, codificador)
{
    public const string Esquema = "TokenMcp";

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var encabezado = Request.Headers.Authorization.ToString();
        if (!encabezado.StartsWith("Bearer ", StringComparison.Ordinal))
            return Task.FromResult(AuthenticateResult.NoResult());

        var recibido = Encoding.UTF8.GetBytes(encabezado["Bearer ".Length..]);
        var esperado = Encoding.UTF8.GetBytes(opciones.Value.Token!);
        if (!CryptographicOperations.FixedTimeEquals(recibido, esperado))
            return Task.FromResult(AuthenticateResult.Fail("token inválido"));

        var identidad = new ClaimsIdentity([new Claim(ClaimTypes.Name, "cliente-mcp")], Esquema);
        return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(new ClaimsPrincipal(identidad), Esquema)));
    }
}

/// <summary>Reglas del perímetro que se revisan antes de construir el servidor.</summary>
public static class ReglasDelPerimetro
{
    /// <summary>Errores de configuración: direcciones fuera de loopback y <c>AllowedHosts</c> abierto.</summary>
    public static IReadOnlyList<string> Revisar(IConfiguration configuracion)
    {
        var errores = new List<string>();
        var urls = configuracion.GetSection($"{OpcionesDelServidorMcp.Seccion}:Urls").Get<string[]>() ?? [];
        foreach (var url in urls)
            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) || !EsLoopback(uri.Host))
                errores.Add($"Mcp:Urls «{url}» no es loopback: el servidor MCP escucha sólo en 127.0.0.1, [::1] o localhost.");

        var hosts = configuracion["AllowedHosts"];
        if (string.IsNullOrWhiteSpace(hosts) || hosts.Split(';').Any(h => h.Trim() == "*"))
            errores.Add("AllowedHosts tiene que ser una lista cerrada (por ejemplo «localhost;127.0.0.1»), nunca «*».");
        return errores;
    }

    private static bool EsLoopback(string host) =>
        host == "localhost" || (IPAddress.TryParse(host.Trim('[', ']'), out var ip) && IPAddress.IsLoopback(ip));
}
