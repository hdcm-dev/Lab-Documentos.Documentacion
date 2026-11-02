using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace MovilidadUrbana.Asistente.Infrastructure.AI;

/// <summary>
/// Única clase de opciones de la capa de IA, ligada a la sección <c>AI</c> y validada al arrancar
/// (<c>ValidateDataAnnotations().ValidateOnStart()</c>). Endpoint, modelo, <c>num_ctx</c>, timeout y
/// límites salen de acá y de los appsettings: ningún literal de esos en el resto del código.
/// Las variables de entorno <c>OLLAMA_ENDPOINT</c> y <c>OLLAMA_MODEL</c> pisan <c>AI:Endpoint</c> y
/// <c>AI:Modelo</c> sólo si están definidas.
/// </summary>
public sealed class OpcionesDeIA
{
    public const string Seccion = "AI";

    /// <summary>El servidor Ollama de prueba. Por defecto, el local.</summary>
    [Required, Url]
    public string Endpoint { get; set; } = "http://localhost:11434";

    /// <summary>Modelo de chat. Provisional: ver README.</summary>
    [Required]
    public string Modelo { get; set; } = "qwen3.5:4b";

    /// <summary>Ventana de contexto por pedido (<c>num_ctx</c>). Mismo valor para todos los pedidos al mismo modelo.</summary>
    [Range(512, 262_144)]
    public int NumCtx { get; set; } = 8192;

    /// <summary>Tope de tokens de salida por pedido (<c>num_predict</c> por la vía nativa).</summary>
    [Range(16, 32_768)]
    public int MaximoDeTokensDeSalida { get; set; } = 512;

    /// <summary>Timeout del HttpClient hacia el servidor. Sin valor por defecto: 0 no valida y la app no arranca.</summary>
    [Range(1, 3_600)]
    public int TimeoutSegundos { get; set; }

    /// <summary>Largo máximo, en caracteres, del texto de la persona y de cada salida de herramienta que vuelve al modelo.</summary>
    [Range(1, 100_000)]
    public int LargoMaximoDeEntrada { get; set; } = 2_000;

    [ValidateObjectMembers]
    public OpcionesDeConcurrencia Concurrencia { get; set; } = new();

    [ValidateObjectMembers]
    public OpcionesDeHerramientas Herramientas { get; set; } = new();

    [ValidateObjectMembers]
    public OpcionesDeMuestreo Muestreo { get; set; } = new();

    [ValidateObjectMembers]
    public OpcionesDeConversacion Conversacion { get; set; } = new();

    [ValidateObjectMembers]
    public OpcionesDeCache Cache { get; set; } = new();
}

/// <summary>Límite de pedidos simultáneos al modelo, en la entrada (HTTP y página). Valores elegidos, no medidos.</summary>
public sealed class OpcionesDeConcurrencia
{
    [Range(1, 64)] public int Permisos { get; set; } = 1;
    [Range(0, 64)] public int Cola { get; set; } = 2;
    [Range(1, 3_600)] public int ReintentarEnSegundos { get; set; } = 30;
}

/// <summary>Límites del bucle de herramientas: iteraciones = herramientas encadenables + 1; errores consecutivos.</summary>
public sealed class OpcionesDeHerramientas
{
    [Range(1, 40)] public int MaximoDeIteraciones { get; set; } = 3;
    [Range(0, 40)] public int MaximoDeErroresConsecutivos { get; set; } = 2;
}

/// <summary>
/// Muestreo. Por defecto, el preajuste que la model card de Qwen3.5-4B da para el modo sin razonamiento y
/// tareas generales. <see cref="TopK"/> sólo llega por la vía nativa (OllamaSharp), que es la de la demo.
/// </summary>
public sealed class OpcionesDeMuestreo
{
    [Range(0.0, 2.0)] public float Temperatura { get; set; } = 0.7f;
    [Range(0.0, 1.0)] public float TopP { get; set; } = 0.8f;
    [Range(1, 1_000)] public int TopK { get; set; } = 20;
    [Range(-2.0, 2.0)] public float PresencePenalty { get; set; } = 1.5f;

    /// <summary>Semilla fija para reproducir una corrida; null = la que elija el servidor.</summary>
    public long? Semilla { get; set; }
}

/// <summary>Estado de la conversación (D-11).</summary>
public sealed class OpcionesDeConversacion
{
    [Range(1, 1_440)] public int VencimientoMinutos { get; set; } = 30;
    [Range(0, 50)] public int TurnosDeHistorial { get; set; } = 6;
}

/// <summary>
/// Caché de respuestas. Apagada por defecto. Si se prende, sólo cachea pedidos sin herramientas (por
/// ejemplo, la ayuda con contexto fijo): un acierto no vuelve a ejecutar las herramientas de lectura.
/// </summary>
public sealed class OpcionesDeCache
{
    public bool Habilitada { get; set; }
}
