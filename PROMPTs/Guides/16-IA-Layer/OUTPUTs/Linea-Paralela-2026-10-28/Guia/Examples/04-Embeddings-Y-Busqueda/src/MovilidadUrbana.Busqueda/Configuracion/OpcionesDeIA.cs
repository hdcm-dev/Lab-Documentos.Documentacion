using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace MovilidadUrbana.Busqueda.Configuracion;

/// <summary>
/// Única clase de opciones de IA, ligada a la sección <c>AI</c> y validada al arrancar.
/// Ningún endpoint, modelo ni timeout se escribe fuera de esta clase y de los appsettings.
/// </summary>
public sealed class OpcionesDeIA
{
    public const string Seccion = "AI";

    /// <summary><c>Ollama</c> (servidor de prueba) o <c>SinModelo</c> (generador léxico falso, determinista).</summary>
    [Required, AllowedValues(Modos.Ollama, Modos.SinModelo)] public string Modo { get; set; } = Modos.Ollama;

    [Required, Url] public string Endpoint { get; set; } = "http://localhost:11434";
    [Required] public string ModeloDeEmbeddings { get; set; } = "qwen3-embedding:0.6b";

    /// <summary>Dimensión declarada del almacén. <c>null</c> = se toma el largo del primer embedding medido al arrancar.</summary>
    [Range(32, 4_096)] public int? DimensionDeEmbeddings { get; set; }

    [Range(1, 3_600)] public int TimeoutSegundos { get; set; }          // sin valor por defecto: 0 no valida

    [ValidateObjectMembers] public OpcionesDeBusqueda Busqueda { get; set; } = new();
}

public static class Modos
{
    public const string Ollama = "Ollama";
    public const string SinModelo = "SinModelo";
}

public sealed class OpcionesDeBusqueda
{
    /// <summary>Cuántos enunciados devuelve la búsqueda (el k de hit@k, recall@k y MRR@k).</summary>
    [Range(1, 12)] public int Top { get; set; } = 3;

    /// <summary>Instrucción que se antepone a la consulta (nunca al documento). Vacía = sin instrucción.</summary>
    public string? InstruccionDeConsulta { get; set; }

    /// <summary>Umbrales de abstención: dependen del modelo y del formato de consulta; los fija la calibración.</summary>
    [Range(-1.0, 1.0)] public double? UmbralConInstruccion { get; set; }
    [Range(-1.0, 1.0)] public double? UmbralSinInstruccion { get; set; }
}
