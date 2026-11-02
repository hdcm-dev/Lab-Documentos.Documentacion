using System.ComponentModel;
using Microsoft.Extensions.AI;
using MovilidadUrbana.Ejemplos.ToolCalling.Application.Consultas;

namespace MovilidadUrbana.Ejemplos.ToolCalling.Infrastructure.AI;

/// <summary>
/// Adaptador de entrada: expone dos casos de uso de LECTURA como herramientas. Es fino: no valida ni
/// filtra por su cuenta; llama al caso de uso y le devuelve al modelo el valor o los errores por campo.
/// Scoped: se crea por ámbito con los servicios de ESA sesión, así que una herramienta nunca ve otra sesión. Principio: el modelo propone; la aplicación ejecuta, autoriza y valida.
/// </summary>
public sealed class HerramientasDeLocalidades(ConsultaDeLocalidades consultas)
{
    public const string ContarPorProvincia = "contar_localidades_por_provincia";
    public const string Listar = "listar_localidades";

    /// <summary>Lista cerrada: las únicas herramientas que este ejemplo registra. Todas leen; ninguna escribe.</summary>
    public static readonly IReadOnlyList<string> NombresDeLectura = [ContarPorProvincia, Listar];

    /// <summary>Lo que vuelve al modelo. Los errores usan los nombres de campo del ABM.</summary>
    public sealed record Respuesta(bool Ok, object? Datos, IReadOnlyDictionary<string, string> Errores);

    [Description("Cuenta las localidades cargadas en una provincia del catálogo.")]
    public async Task<Respuesta> ContarPorProvinciaAsync(
        [Description("Una de: Buenos Aires, Chaco, Córdoba, Corrientes, Entre Ríos, Mendoza, Santa Fe")] string provincia,
        CancellationToken ct = default)
    {
        var r = await consultas.ContarPorProvinciaAsync(provincia, ct);
        return new Respuesta(r.EsValido, r.Valor, r.Errores);
    }

    [Description("Lista las localidades cargadas. Todos los filtros son opcionales.")]
    public async Task<Respuesta> ListarAsync(
        [Description("Provincia del catálogo, para filtrar")] string? provincia = null,
        [Description("Código postal de 4 dígitos, para filtrar")] string? codigoPostal = null,
        [Description("Nombre exacto de la localidad, para buscarla")] string? nombre = null,
        CancellationToken ct = default)
    {
        var r = await consultas.ListarAsync(provincia, codigoPostal, nombre, ct);
        return new Respuesta(r.EsValido, r.Valor, r.Errores);
    }

    public IList<AITool> Crear() =>
    [
        AIFunctionFactory.Create(ContarPorProvinciaAsync, ContarPorProvincia),
        AIFunctionFactory.Create(ListarAsync, Listar),
    ];
}
