using System.ComponentModel;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Application.Consultas;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Application.Normalizacion;

namespace MovilidadUrbana.Ejemplos.Mcp.Servidor.Herramientas;

/// <summary>Marca un método del catálogo que sólo lee. MCP publica únicamente los que la llevan.</summary>
[AttributeUsage(AttributeTargets.Method)]
public sealed class HerramientaDeLecturaAttribute : Attribute;

/// <summary>Marca un método del catálogo que escribe. Nunca se publica por MCP.</summary>
[AttributeUsage(AttributeTargets.Method)]
public sealed class HerramientaDeEscrituraAttribute : Attribute;

/// <summary>Lo que vuelve al modelo: el valor o los errores por campo, con los nombres del ABM.</summary>
public sealed record Respuesta<T>(bool Ok, T? Datos, IReadOnlyDictionary<string, string> Errores);

/// <summary>
/// Adaptador de entrada: expone casos de uso como herramientas. Es fino: no valida ni filtra por su
/// cuenta, llama al caso de uso. Ningún método recibe la sesión como parámetro: la sesión sale del
/// ámbito (los servicios con los que se crea esta clase), nunca de lo que mande el modelo o el cliente.
/// </summary>
public sealed class HerramientasDeLocalidades(ConsultaDeLocalidades consultas, LocalidadService localidades)
{
    public const string ContarPorProvincia = "contar_localidades_por_provincia";
    public const string Listar = "listar_localidades";
    public const string Borrar = "borrar_localidad";

    [HerramientaDeLectura]
    [Description("Cuenta las localidades cargadas en una provincia del catálogo.")]
    public async Task<Respuesta<ConteoPorProvincia>> ContarPorProvinciaAsync(
        [Description("Una de: Buenos Aires, Chaco, Córdoba, Corrientes, Entre Ríos, Mendoza, Santa Fe")] string provincia,
        CancellationToken ct = default)
    {
        var r = await consultas.ContarPorProvinciaAsync(provincia, ct);
        return new(r.EsValido, r.Valor, r.Errores);
    }

    [HerramientaDeLectura]
    [Description("Lista las localidades cargadas. Todos los filtros son opcionales.")]
    public async Task<Respuesta<IReadOnlyList<LocalidadResumida>>> ListarAsync(
        [Description("Provincia del catálogo, para filtrar")] string? provincia = null,
        [Description("Código postal de 4 dígitos, para filtrar")] string? codigoPostal = null,
        [Description("Nombre exacto de la localidad, para buscarla")] string? nombre = null,
        CancellationToken ct = default)
    {
        var r = await consultas.ListarAsync(provincia, codigoPostal, nombre, ct);
        return new(r.EsValido, r.Valor, r.Errores);
    }

    /// <summary>
    /// La única escritura del catálogo. Está para que el filtro se vea: el bucle de la app la puede usar
    /// envuelta en <c>ApprovalRequiredAIFunction</c> (como en el ejemplo 07); MCP no la publica, porque
    /// por MCP la aprobación no viaja y el servidor la ejecutaría sin preguntar.
    /// </summary>
    [HerramientaDeEscritura]
    [Description("Da de baja una localidad de la sesión, por su nombre exacto.")]
    public async Task<Respuesta<string>> BorrarAsync(
        [Description("Nombre exacto de la localidad")] string nombre,
        CancellationToken ct = default)
    {
        var n = NormalizadorDeCatalogos.Nombre(nombre);
        if (!n.EsValido) return new(false, null, new Dictionary<string, string> { [n.Campo!] = n.Error! });

        var todas = await localidades.GetAllAsync(ct);
        var localidad = todas.FirstOrDefault(l => string.Equals(l.Nombre, n.Valor, StringComparison.OrdinalIgnoreCase));
        if (localidad is null)
            return new(false, null, new Dictionary<string, string> { ["nombre"] = $"No hay ninguna localidad «{n.Valor}» cargada." });

        var r = await localidades.DeleteAsync(localidad.Id, ct);   // el caso de uso del ABM, con sus reglas
        return new(r.IsSuccess, r.Message, r.Errors);
    }
}
