using System.ComponentModel;
using ModelContextProtocol.Server;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Application.Consultas;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Herramientas;

namespace MovilidadUrbana.Ejemplos.Mcp.Servidor.Alternativa;

// ─────────────────────────────────────────────────────────────────────────────────────────────────────
// ALTERNATIVA CON DOS DEFINICIONES. No se registra en el servidor del ejemplo.
// Así se publica con los atributos del SDK de MCP. El bucle de la app necesitaría además su propio
// AIFunctionFactory.Create: nombre, descripción y esquema quedan escritos dos veces, y hay que fijar
// Name en los dos lados para que coincidan. Una prueba de Cableado compara lo que publica esta clase con
// lo que publica el catálogo único.
// ─────────────────────────────────────────────────────────────────────────────────────────────────────
[McpServerToolType]
public sealed class HerramientasConAtributos
{
    [McpServerTool(Name = HerramientasDeLocalidades.ContarPorProvincia, ReadOnly = true, Destructive = false, Idempotent = true, OpenWorld = false)]
    [Description("Cuenta las localidades cargadas en una provincia del catálogo.")]
    public static async Task<Respuesta<ConteoPorProvincia>> ContarPorProvinciaAsync(
        ConsultaDeLocalidades consultas,   // los servicios llegan por DI como parámetros del método
        [Description("Una de: Buenos Aires, Chaco, Córdoba, Corrientes, Entre Ríos, Mendoza, Santa Fe")] string provincia,
        CancellationToken ct = default)
    {
        var r = await consultas.ContarPorProvinciaAsync(provincia, ct);
        return new(r.EsValido, r.Valor, r.Errores);
    }

    [McpServerTool(Name = HerramientasDeLocalidades.Listar, ReadOnly = true, Destructive = false, Idempotent = true, OpenWorld = false)]
    [Description("Lista las localidades cargadas. Todos los filtros son opcionales.")]
    public static async Task<Respuesta<IReadOnlyList<LocalidadResumida>>> ListarAsync(
        ConsultaDeLocalidades consultas,
        [Description("Provincia del catálogo, para filtrar")] string? provincia = null,
        [Description("Código postal de 4 dígitos, para filtrar")] string? codigoPostal = null,
        [Description("Nombre exacto de la localidad, para buscarla")] string? nombre = null,
        CancellationToken ct = default)
    {
        var r = await consultas.ListarAsync(provincia, codigoPostal, nombre, ct);
        return new(r.EsValido, r.Valor, r.Errores);
    }
}
