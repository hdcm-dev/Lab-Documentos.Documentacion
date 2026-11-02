using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Application.Normalizacion;

namespace MovilidadUrbana.Ejemplos.Mcp.Servidor.Application.Consultas;

/// <summary>Lo que una consulta devuelve de una localidad: sin <c>SessionId</c> ni <c>Id</c>.</summary>
public sealed record LocalidadResumida(string Nombre, string Provincia, string CodigoPostal, int Habitantes);

/// <summary>Conteo con la provincia ya normalizada al catálogo.</summary>
public sealed record ConteoPorProvincia(string Provincia, int Cantidad);

/// <summary>Resultado de una consulta: el valor, o los errores por campo (con los nombres del ABM).</summary>
public sealed record ResultadoDeConsulta<T>(T? Valor, IReadOnlyDictionary<string, string> Errores)
{
    public bool EsValido => Errores.Count == 0;
    public static ResultadoDeConsulta<T> Ok(T valor) => new(valor, new Dictionary<string, string>());
    public static ResultadoDeConsulta<T> Invalido(IReadOnlyDictionary<string, string> errores) => new(default, errores);
}

/// <summary>
/// Casos de uso de lectura sobre localidades, en el núcleo. Delegan en <see cref="LocalidadService"/>
/// (copiado del caso base), que lee sólo la sesión actual. Ninguno escribe. No conocen al modelo ni al
/// proveedor: cambiar de proveedor no cambia esta clase.
/// </summary>
public sealed class ConsultaDeLocalidades(LocalidadService localidades)
{
    public async Task<ResultadoDeConsulta<ConteoPorProvincia>> ContarPorProvinciaAsync(string? provincia, CancellationToken ct = default)
    {
        var p = NormalizadorDeCatalogos.Provincia(provincia);
        if (!p.EsValido) return ResultadoDeConsulta<ConteoPorProvincia>.Invalido(Errores(p)); // no llega al caso de uso

        var todas = await localidades.GetAllAsync(ct);
        return ResultadoDeConsulta<ConteoPorProvincia>.Ok(new(p.Valor!, todas.Count(l => l.Provincia == p.Valor)));
    }

    /// <summary>Lista las localidades de la sesión; cada filtro es opcional y se valida antes de leer.</summary>
    public async Task<ResultadoDeConsulta<IReadOnlyList<LocalidadResumida>>> ListarAsync(
        string? provincia = null, string? codigoPostal = null, string? nombre = null, CancellationToken ct = default)
    {
        var errores = new Dictionary<string, string>();
        Normalizado? p = provincia is null ? null : NormalizadorDeCatalogos.Provincia(provincia);
        Normalizado? cp = codigoPostal is null ? null : NormalizadorDeCatalogos.CodigoPostal(codigoPostal);
        Normalizado? n = nombre is null ? null : NormalizadorDeCatalogos.Nombre(nombre);
        foreach (var f in new[] { p, cp, n })
            if (f is { EsValido: false } falla) errores[falla.Campo!] = falla.Error!;
        if (errores.Count > 0) return ResultadoDeConsulta<IReadOnlyList<LocalidadResumida>>.Invalido(errores);

        var todas = await localidades.GetAllAsync(ct);
        var filtradas = todas
            .Where(l => p is null || l.Provincia == p.Value.Valor)
            .Where(l => cp is null || l.CodigoPostal == cp.Value.Valor)
            .Where(l => n is null || string.Equals(l.Nombre, n.Value.Valor, StringComparison.OrdinalIgnoreCase))
            .Select(l => new LocalidadResumida(l.Nombre, l.Provincia, l.CodigoPostal, l.Habitantes))
            .ToList();

        // Una localidad de otra sesión no se ve: la respuesta es la misma que para una inexistente.
        if (n is not null && filtradas.Count == 0)
            return ResultadoDeConsulta<IReadOnlyList<LocalidadResumida>>.Invalido(
                new Dictionary<string, string> { ["nombre"] = $"No hay ninguna localidad «{n.Value.Valor}» cargada." });

        return ResultadoDeConsulta<IReadOnlyList<LocalidadResumida>>.Ok(filtradas);
    }

    private static Dictionary<string, string> Errores(Normalizado falla) => new() { [falla.Campo!] = falla.Error! };
}
