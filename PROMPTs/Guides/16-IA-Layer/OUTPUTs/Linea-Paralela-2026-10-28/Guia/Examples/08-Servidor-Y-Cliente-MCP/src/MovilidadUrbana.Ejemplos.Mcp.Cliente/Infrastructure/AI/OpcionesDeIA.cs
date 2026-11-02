using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace MovilidadUrbana.Ejemplos.Mcp.Cliente.Infrastructure.AI;

/// <summary>
/// Única clase de opciones de la capa de IA, ligada a la sección <c>AI</c> y validada al arrancar.
/// Es el único lugar del código (junto con los <c>appsettings*.json</c>) donde aparecen el endpoint,
/// el modelo, <c>num_ctx</c>, el timeout y los límites del bucle de herramientas.
/// </summary>
public sealed class OpcionesDeIA
{
    public const string Seccion = "AI";

    [Required, Url] public string Endpoint { get; set; } = "http://localhost:11434";

    [Required] public string Modelo { get; set; } = "qwen3.5:4b";

    /// <summary>Se manda en cada pedido por la vía nativa (OllamaSharp → <c>/api/chat</c>).</summary>
    [Range(512, 262_144)] public int NumCtx { get; set; } = 8192;

    /// <summary>Sin valor por defecto: 0 no valida. Cada <c>appsettings.&lt;entorno&gt;.json</c> lo declara.</summary>
    [Range(1, 3_600)] public int TimeoutSegundos { get; set; }

    /// <summary>Caracteres. Se valida antes de llamar al modelo.</summary>
    [Range(1, 100_000)] public int LargoMaximoDeEntrada { get; set; } = 2_000;

    [ValidateObjectMembers] public OpcionesDeHerramientas Herramientas { get; set; } = new();

    [ValidateObjectMembers] public OpcionesDeMuestreo Muestreo { get; set; } = new();
}

/// <summary>
/// Límites del bucle de <c>FunctionInvokingChatClient</c>. Regla de la guía: iteraciones = herramientas
/// encadenables del escenario + 1 (acá, 2 + 1 = 3); errores consecutivos, 2. Valores elegidos, no medidos.
/// </summary>
public sealed class OpcionesDeHerramientas
{
    [Range(1, 10)] public int MaximoDeIteraciones { get; set; } = 3;
    [Range(0, 10)] public int MaximoDeErroresConsecutivos { get; set; } = 2;
}

/// <summary>
/// Muestreo. null = no se manda y rige el Modelfile del servidor. Los valores se fijan en
/// <c>appsettings.json</c> con el preajuste del fabricante para el modo sin razonamiento.
/// </summary>
public sealed class OpcionesDeMuestreo
{
    [Range(0.0, 2.0)] public float? Temperatura { get; set; }
    [Range(0.0, 1.0)] public float? TopP { get; set; }
    [Range(1, 1_000)] public int? TopK { get; set; }
    [Range(0.0, 1.0)] public float? MinP { get; set; }
    [Range(-2.0, 2.0)] public float? PenalizacionPorPresencia { get; set; }
    [Range(0.0, 2.0)] public float? PenalizacionPorRepeticion { get; set; }
    public long? Semilla { get; set; }
    public bool ApagarRazonamiento { get; set; } = true;
}

/// <summary>Opciones del cliente MCP, sección <c>McpCliente</c>, validadas al arrancar.</summary>
public sealed class OpcionesDelClienteMcp
{
    public const string Seccion = "McpCliente";

    /// <summary>
    /// Lista blanca por nombre: las únicas herramientas del servidor que el agente recibe. Una herramienta que el
    /// servidor publique y no esté acá no llega al modelo.
    /// </summary>
    [Required, MinLength(1)] public string[] HerramientasPermitidas { get; set; } = [];

    /// <summary>Token del servidor MCP. Viaja como encabezado, puesto por <c>ManejadorDeTokenMcp</c>.</summary>
    [Required, MinLength(16)] public string? Token { get; set; }
}
