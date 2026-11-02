using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace MovilidadUrbana.RagEnMemoria.Infrastructure.AI;

/// <summary>
/// Única clase de opciones de la capa de IA, ligada a la sección <c>AI</c> y validada al arrancar.
/// Junto con los <c>appsettings*.json</c>, es el único lugar donde aparecen el endpoint, los modelos,
/// <c>num_ctx</c>, el timeout y los parámetros de la recuperación.
/// </summary>
public sealed class OpcionesDeIA
{
    public const string Seccion = "AI";

    [Required, Url] public string Endpoint { get; set; } = "http://localhost:11434";

    [Required] public string Modelo { get; set; } = "qwen3.5:4b";

    [Required] public string ModeloDeEmbeddings { get; set; } = "qwen3-embedding:0.6b";

    /// <summary>
    /// Dimensión que se declara en el almacén. Al arrancar se genera un embedding de prueba y, si el largo
    /// no coincide, la aplicación no arranca. null = se toma el largo medido.
    /// </summary>
    [Range(32, 4_096)] public int? DimensionDeEmbeddings { get; set; }

    /// <summary>Se manda en cada pedido por la vía nativa (OllamaSharp → <c>/api/chat</c>).</summary>
    [Range(512, 262_144)] public int NumCtx { get; set; } = 8192;

    /// <summary>Por la vía nativa llega como <c>num_predict</c> y acota la salida.</summary>
    [Range(1, 8_192)] public int MaxTokensDeSalida { get; set; } = 200;

    /// <summary>Sin valor por defecto: 0 no valida. Cada <c>appsettings.&lt;entorno&gt;.json</c> lo declara.</summary>
    [Range(1, 3_600)] public int TimeoutSegundos { get; set; }

    /// <summary>Caracteres de la pregunta. Se valida antes de llamar al modelo.</summary>
    [Range(1, 100_000)] public int LargoMaximoDeEntrada { get; set; } = 2_000;

    /// <summary>Caracteres del bloque de fragmentos recuperados que entra al prompt (se recorta con marca).</summary>
    [Range(100, 200_000)] public int LargoMaximoDeFragmentos { get; set; } = 4_000;

    [ValidateObjectMembers] public OpcionesDeMuestreo Muestreo { get; set; } = new();

    [ValidateObjectMembers] public OpcionesDeRecuperacion Rag { get; set; } = new();
}

/// <summary>Muestreo. null = no se manda y rige el Modelfile del servidor.</summary>
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

public sealed class OpcionesDeRecuperacion
{
    /// <summary>Fragmentos que entran al prompt. Cada fragmento es un requisito entero (ya son atómicos).</summary>
    [Range(1, 12)] public int K { get; set; } = 3;

    /// <summary>
    /// Instrucción de tarea que se antepone sólo a la consulta (no a los documentos), con el formato
    /// <c>Instruct: …\nQuery:…</c> de la ficha de Qwen3-Embedding. Vacía = consulta sin instrucción.
    /// </summary>
    public string? InstruccionDeConsulta { get; set; }

    /// <summary>Corte del bucle de la vía B y de la vía C.</summary>
    [Range(1, 10)] public int MaximoDeIteraciones { get; set; } = 3;
}
