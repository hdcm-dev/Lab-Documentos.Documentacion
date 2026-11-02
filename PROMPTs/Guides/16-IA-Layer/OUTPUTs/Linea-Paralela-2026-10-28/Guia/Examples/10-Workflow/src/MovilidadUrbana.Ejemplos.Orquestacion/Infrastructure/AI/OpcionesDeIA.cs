using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.AI;

/// <summary>
/// Única clase de opciones de la capa de IA, ligada a la sección <c>AI</c> y validada al arrancar.
/// Es el único lugar del código (junto con los <c>appsettings*.json</c>) donde aparecen el endpoint,
/// el modelo, <c>num_ctx</c> y el timeout. Este ejemplo usa sólo la vía nativa (OllamaSharp → <c>/api/chat</c>).
/// </summary>
public sealed class OpcionesDeIA
{
    public const string Seccion = "AI";

    [Required, Url] public string Endpoint { get; set; } = "http://localhost:11434";

    [Required] public string Modelo { get; set; } = "qwen3.5:4b";

    /// <summary>Se manda en cada pedido, dentro de <c>options</c>.</summary>
    [Range(512, 262_144)] public int NumCtx { get; set; } = 8192;

    /// <summary>Sin valor por defecto: 0 no valida. Cada <c>appsettings.&lt;entorno&gt;.json</c> lo declara.</summary>
    [Range(1, 3_600)] public int TimeoutSegundos { get; set; }

    /// <summary>Caracteres. Se valida antes de llamar al modelo.</summary>
    [Range(1, 100_000)] public int LargoMaximoDeEntrada { get; set; } = 2_000;

    [ValidateObjectMembers] public OpcionesDeMuestreo Muestreo { get; set; } = new();
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
    [Range(-2.0, 2.0)] public float? PenalizacionPorPresencia { get; set; }
    public long? Semilla { get; set; }
    public bool ApagarRazonamiento { get; set; } = true;
}
