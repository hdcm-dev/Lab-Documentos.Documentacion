using System.Globalization;
using System.Text;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.ApiWeb.Domain;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Consultas;

/// <summary>Resultado de una consulta: el valor o los errores por campo, con los nombres del ABM.</summary>
public sealed record ResultadoDeConsulta<T>(T? Valor, IReadOnlyDictionary<string, string> Errores)
{
    public bool EsValido => Errores.Count == 0;
}

/// <summary>
/// Caso de uso de LECTURA del núcleo: cuenta las localidades de la sesión en una provincia del catálogo.
/// La provincia que propone el modelo se normaliza contra <see cref="Catalogos.Provincias"/> («corrientes»
/// → «Corrientes»); fuera del catálogo es un error de campo, nunca un cero.
/// </summary>
public sealed class ConsultaDeLocalidades(LocalidadService localidades)
{
    public async Task<ResultadoDeConsulta<int?>> ContarPorProvinciaAsync(string? provincia, CancellationToken ct = default)
    {
        var normalizada = NormalizarProvincia(provincia);
        if (normalizada is null)
        {
            return new(null, new Dictionary<string, string>
            {
                ["provincia"] = $"«{provincia}» no está en el catálogo: {string.Join(", ", Catalogos.Provincias)}.",
            });
        }

        var todas = await localidades.GetAllAsync(ct);
        return new(todas.Count(l => l.Provincia == normalizada), new Dictionary<string, string>());
    }

    public static string? NormalizarProvincia(string? provincia) =>
        Catalogos.Provincias.FirstOrDefault(p => Plano(p) == Plano(provincia));

    private static string Plano(string? texto)
    {
        var descompuesto = (texto ?? string.Empty).Trim().Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();
        foreach (var c in descompuesto)
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark) sb.Append(char.ToLowerInvariant(c));
        return sb.ToString();
    }
}
