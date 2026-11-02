using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;

/// <summary>
/// Única clase de opciones de la capa de IA, ligada a la sección <c>AI</c> y validada al arrancar.
/// Es el único lugar del código (junto con los <c>appsettings*.json</c>) donde aparecen el endpoint,
/// el modelo, <c>num_ctx</c>, el timeout, la concurrencia y el largo de entrada.
/// </summary>
public sealed class OpcionesDeIA
{
    public const string Seccion = "AI";

    [Required, Url] public string Endpoint { get; set; } = "http://localhost:11434";

    [Required] public string Modelo { get; set; } = "qwen3.5:4b";

    /// <summary>Se manda en cada pedido. Todos los clientes del mismo modelo usan el mismo valor.</summary>
    [Range(512, 262_144)] public int NumCtx { get; set; } = 8192;

    /// <summary>Sin valor por defecto: 0 no valida. Cada <c>appsettings.&lt;entorno&gt;.json</c> lo declara.</summary>
    [Range(1, 3_600)] public int TimeoutSegundos { get; set; }

    /// <summary>Caracteres. Se valida antes de llamar al modelo; la API responde 400.</summary>
    [Range(1, 100_000)] public int LargoMaximoDeEntrada { get; set; } = 2_000;

    [ValidateObjectMembers] public OpcionesDeConcurrencia Concurrencia { get; set; } = new();

    [ValidateObjectMembers] public OpcionesDeHerramientas Herramientas { get; set; } = new();

    [ValidateObjectMembers] public OpcionesDeMuestreo Muestreo { get; set; } = new();

    /// <summary>
    /// Caché de respuestas por fuera del bucle de herramientas. En este ejemplo se enseña con la clave
    /// [SessionId, VersionDeDatos]; se puede apagar para aislar otra prueba.
    /// </summary>
    public bool CacheDeRespuestas { get; set; } = true;
}

/// <summary>Límite de concurrencia en la entrada HTTP: lo que no entra en permisos + cola recibe 503.</summary>
public sealed class OpcionesDeConcurrencia
{
    [Range(1, 64)] public int Permisos { get; set; } = 1;
    [Range(0, 64)] public int Cola { get; set; } = 2;
    /// <summary>Valor de <c>Retry-After</c> en el 503. Elegido, no medido.</summary>
    [Range(1, 3_600)] public int ReintentarEnSegundos { get; set; } = 30;
}

/// <summary>Límites del bucle de <c>FunctionInvokingChatClient</c>: una herramienta encadenable + 1, y 2 errores.</summary>
public sealed class OpcionesDeHerramientas
{
    [Range(1, 10)] public int MaximoDeIteraciones { get; set; } = 2;
    [Range(0, 10)] public int MaximoDeErroresConsecutivos { get; set; } = 2;
}

/// <summary>Muestreo. null = no se manda y rige el Modelfile del servidor.</summary>
public sealed class OpcionesDeMuestreo
{
    [Range(0.0, 2.0)] public float? Temperatura { get; set; }
    [Range(0.0, 1.0)] public float? TopP { get; set; }
    [Range(1, 1_000)] public int? TopK { get; set; }
    [Range(-2.0, 2.0)] public float? PenalizacionPorPresencia { get; set; }
    public long? Semilla { get; set; }
    public bool ApagarRazonamiento { get; set; } = true;
}
