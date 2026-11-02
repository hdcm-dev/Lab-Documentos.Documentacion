using System.ComponentModel;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Consultas;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;

/// <summary>
/// Catálogo de herramientas, todas de LECTURA. Las funciones son únicas para toda la aplicación y resuelven
/// el caso de uso desde <see cref="AIFunctionArguments.Services"/>: los servicios del pipeline que las invoca.
/// Por eso la vida del pipeline importa: Scoped ve la sesión del pedido; un Singleton ve la raíz (D-06).
/// </summary>
public static class HerramientasDeLocalidades
{
    public const string ContarPorProvincia = "contar_localidades_por_provincia";

    /// <summary>Lista cerrada: las únicas herramientas que registra el ejemplo. Ninguna escribe.</summary>
    public static readonly IReadOnlyList<string> NombresDeLectura = [ContarPorProvincia];

    public static IList<AITool> Catalogo { get; } =
    [
        AIFunctionFactory.Create(ContarAsync, ContarPorProvincia, "Cuenta las localidades cargadas en una provincia del catálogo."),
    ];

    /// <summary>Lo que vuelve al modelo. Los errores usan los nombres de campo del ABM.</summary>
    public sealed record Respuesta(bool Ok, int? Cantidad, IReadOnlyDictionary<string, string> Errores);

    private static async Task<Respuesta> ContarAsync(
        [Description("Una de: Buenos Aires, Chaco, Córdoba, Corrientes, Entre Ríos, Mendoza, Santa Fe")] string provincia,
        AIFunctionArguments argumentos,
        CancellationToken ct)
    {
        var consultas = argumentos.Services!.GetRequiredService<ConsultaDeLocalidades>();
        var r = await consultas.ContarPorProvinciaAsync(provincia, ct);
        return new Respuesta(r.EsValido, r.Valor, r.Errores);
    }
}
