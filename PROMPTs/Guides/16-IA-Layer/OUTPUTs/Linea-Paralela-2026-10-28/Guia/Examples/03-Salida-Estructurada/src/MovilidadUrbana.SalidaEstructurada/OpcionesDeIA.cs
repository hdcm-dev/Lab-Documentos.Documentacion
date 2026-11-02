using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace MovilidadUrbana.SalidaEstructurada;

/// <summary>
/// Única clase de opciones de IA, ligada a la sección <c>AI</c> y validada al arrancar.
/// Ningún endpoint, modelo, <c>num_ctx</c> ni timeout se escribe fuera de esta clase y de los appsettings.
/// </summary>
public sealed class OpcionesDeIA
{
    public const string Seccion = "AI";

    [Required, Url] public string Endpoint { get; set; } = "http://localhost:11434";
    [Required] public string Modelo { get; set; } = "qwen3.5:4b";
    [Range(512, 262_144)] public int NumCtx { get; set; } = 8192;
    [Range(1, 3_600)] public int TimeoutSegundos { get; set; }          // sin valor por defecto: 0 no valida
    [Range(1, 100_000)] public int LargoMaximoDeEntrada { get; set; } = 2_000;

    /// <summary>Preajuste del fabricante para el modo sin razonamiento; viaja tipado por la vía nativa.</summary>
    [ValidateObjectMembers] public OpcionesDeMuestreo Muestreo { get; set; } = new();
}

/// <summary>Sin valores en código: los declara el appsettings con su fuente.</summary>
public sealed class OpcionesDeMuestreo
{
    [Range(0.0, 2.0)] public float? Temperatura { get; set; }
    [Range(0.0, 1.0)] public float? TopP { get; set; }
    [Range(1, 1_000)] public int? TopK { get; set; }
    [Range(-2.0, 2.0)] public float? PresencePenalty { get; set; }
}
