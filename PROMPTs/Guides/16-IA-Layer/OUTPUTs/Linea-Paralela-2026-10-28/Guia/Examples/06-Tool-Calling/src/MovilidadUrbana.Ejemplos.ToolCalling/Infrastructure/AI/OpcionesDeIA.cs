using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace MovilidadUrbana.Ejemplos.ToolCalling.Infrastructure.AI;

/// <summary>
/// Única clase de opciones de la capa de IA, ligada a la sección <c>AI</c> y validada al arrancar.
/// Es el único lugar del código (junto con los <c>appsettings*.json</c>) donde aparecen el endpoint,
/// el modelo, <c>num_ctx</c>, el timeout y los límites del bucle de herramientas.
/// </summary>
public sealed class OpcionesDeIA
{
    public const string Seccion = "AI";

    /// <summary><c>ollama</c> (vía nativa, OllamaSharp → <c>/api/chat</c>) u <c>openai-compatible</c> (MEAI.OpenAI → <c>/v1</c>).</summary>
    [Required, RegularExpression($"^({Proveedores.Ollama}|{Proveedores.OpenAICompatible})$")]
    public string Proveedor { get; set; } = Proveedores.Ollama;

    [Required, Url] public string Endpoint { get; set; } = "http://localhost:11434";

    [Required] public string Modelo { get; set; } = "qwen3.5:4b";

    /// <summary>Se manda en cada pedido por la vía nativa. Por <c>/v1</c> no se puede fijar por pedido.</summary>
    [Range(512, 262_144)] public int NumCtx { get; set; } = 8192;

    /// <summary>Sin valor por defecto: 0 no valida. Cada <c>appsettings.&lt;entorno&gt;.json</c> lo declara.</summary>
    [Range(1, 3_600)] public int TimeoutSegundos { get; set; }

    /// <summary>Caracteres. Se valida antes de llamar al modelo.</summary>
    [Range(1, 100_000)] public int LargoMaximoDeEntrada { get; set; } = 2_000;

    [ValidateObjectMembers] public OpcionesDeHerramientas Herramientas { get; set; } = new();

    [ValidateObjectMembers] public OpcionesDeMuestreo Muestreo { get; set; } = new();

    /// <summary>
    /// Credencial del servidor, si la pide. Viaja sólo como encabezado, puesta por
    /// <see cref="ManejadorDeCredenciales"/>; nunca en un campo del cuerpo del pedido.
    /// </summary>
    public string? Credencial { get; set; }
}

public static class Proveedores
{
    public const string Ollama = "ollama";
    public const string OpenAICompatible = "openai-compatible";
}

/// <summary>
/// Límites del bucle de <c>FunctionInvokingChatClient</c>. Regla de la guía: iteraciones = herramientas
/// encadenables del escenario + 1 (acá, 2 + 1 = 3); errores consecutivos, 2. Son valores elegidos con esa
/// regla, no medidos. Sin configurarlos rigen los del paquete (40 y 3).
/// </summary>
public sealed class OpcionesDeHerramientas
{
    [Range(1, 10)] public int MaximoDeIteraciones { get; set; } = 3;
    [Range(0, 10)] public int MaximoDeErroresConsecutivos { get; set; } = 2;
}

/// <summary>
/// Muestreo. null = no se manda y rige el Modelfile del servidor. Los valores se fijan en
/// <c>appsettings.json</c> con el preajuste del fabricante para el modo sin razonamiento.
/// <see cref="TopK"/>, <see cref="MinP"/> y <see cref="PenalizacionPorRepeticion"/> llegan sólo por la vía nativa.
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
