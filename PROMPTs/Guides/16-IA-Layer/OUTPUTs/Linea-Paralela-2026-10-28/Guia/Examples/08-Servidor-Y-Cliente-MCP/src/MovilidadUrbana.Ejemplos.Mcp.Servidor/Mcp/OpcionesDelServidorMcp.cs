using System.ComponentModel.DataAnnotations;

namespace MovilidadUrbana.Ejemplos.Mcp.Servidor.Mcp;

/// <summary>
/// Opciones del servidor MCP, sección <c>Mcp</c> de <c>servidor-mcp*.json</c>, validadas al arrancar.
/// <c>AllowedHosts</c> no está acá: es una clave de la raíz que lee el HostFiltering de ASP.NET Core.
/// </summary>
public sealed class OpcionesDelServidorMcp
{
    public const string Seccion = "Mcp";

    /// <summary>Ruta del punto de conexión MCP (Streamable HTTP).</summary>
    [Required] public string Ruta { get; set; } = "/mcp";

    /// <summary>Direcciones donde escucha. Por defecto sólo loopback; otra dirección no arranca.</summary>
    [Required, MinLength(1)] public string[] Urls { get; set; } = [];

    /// <summary>
    /// Orígenes de navegador aceptados. Un pedido con <c>Origin</c> fuera de esta lista recibe 403; uno sin
    /// <c>Origin</c> (un cliente que no es navegador) pasa.
    /// </summary>
    public string[] OrigenesPermitidos { get; set; } = [];

    /// <summary>
    /// Token que el cliente manda como <c>Authorization: Bearer</c>. Sin valor por defecto: fuera de
    /// Development se pasa por variable de entorno (<c>Mcp__Token</c>) y el servidor no arranca sin él.
    /// </summary>
    [Required, MinLength(16)] public string? Token { get; set; }
}
