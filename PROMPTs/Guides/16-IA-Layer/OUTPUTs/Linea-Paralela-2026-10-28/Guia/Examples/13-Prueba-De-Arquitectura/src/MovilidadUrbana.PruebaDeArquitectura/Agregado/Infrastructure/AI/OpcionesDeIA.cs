using System.ComponentModel.DataAnnotations;

namespace MovilidadUrbana.PruebaDeArquitectura.Infrastructure.AI;

/// <summary>Sección <c>AI</c> de la configuración. Endpoint y modelo no se escriben en el código.</summary>
public sealed class OpcionesDeIA
{
    public const string Seccion = "AI";

    [Required, Url] public string Endpoint { get; set; } = string.Empty;
    [Required] public string Modelo { get; set; } = string.Empty;
    [Range(512, 262144)] public int NumCtx { get; set; }
}
