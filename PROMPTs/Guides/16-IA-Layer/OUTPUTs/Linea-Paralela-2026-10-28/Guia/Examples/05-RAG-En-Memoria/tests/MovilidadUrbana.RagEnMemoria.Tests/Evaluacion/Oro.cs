using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MovilidadUrbana.RagEnMemoria.Tests.Evaluacion;

public sealed record ConsultaDeOro(string Id, string Consulta, IReadOnlyList<string> Relevantes, bool Respondible, string? Clave);

public sealed record ConjuntoDeOro(string Descripcion, string VersionDelCasoBase, IReadOnlyList<ConsultaDeOro> Consultas)
{
    public static ConjuntoDeOro Cargar() =>
        JsonSerializer.Deserialize<ConjuntoDeOro>(
            File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Oro", "oro-requisitos.json")),
            new JsonSerializerOptions(JsonSerializerDefaults.Web))!;

    public IEnumerable<ConsultaDeOro> Respondibles => Consultas.Where(c => c.Respondible);
    public IEnumerable<ConsultaDeOro> NoRespondibles => Consultas.Where(c => !c.Respondible);
}

/// <summary>
/// Criterio de la respuesta, escrito antes de correr contra el modelo.
/// Respondible: no se abstiene, cita al menos un relevante y contiene la clave.
/// No respondible: se abstiene con la frase fija.
/// </summary>
public static class CriterioDeRespuesta
{
    public static string Normalizar(string texto) =>
        new string(texto.ToLowerInvariant().Normalize(NormalizationForm.FormD)
            .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray());

    public static bool SeAbstiene(string texto) =>
        Normalizar(texto).Contains("no lo se con los requisitos disponibles", StringComparison.Ordinal);

    public static bool Cumple(ConsultaDeOro c, string texto, IReadOnlyList<string> citas) =>
        c.Respondible
            ? !SeAbstiene(texto) && citas.Intersect(c.Relevantes).Any() && Regex.IsMatch(Normalizar(texto), c.Clave!)
            : SeAbstiene(texto);
}

/// <summary>Métricas de recuperación sobre las respondibles (las no respondibles quedan fuera del promedio).</summary>
public static class MetricasDeRecuperacion
{
    public static double HitAt(int k, IEnumerable<(IReadOnlyList<string> Relevantes, IReadOnlyList<string> Ranking)> casos) =>
        casos.Average(c => c.Ranking.Take(k).Intersect(c.Relevantes).Any() ? 1.0 : 0.0);

    public static double RecallAt(int k, IEnumerable<(IReadOnlyList<string> Relevantes, IReadOnlyList<string> Ranking)> casos) =>
        casos.Average(c => (double)c.Ranking.Take(k).Intersect(c.Relevantes).Count() / c.Relevantes.Count);

    public static double MrrAt(int k, IEnumerable<(IReadOnlyList<string> Relevantes, IReadOnlyList<string> Ranking)> casos) =>
        casos.Average(c => RangoReciproco(k, c.Relevantes, c.Ranking));

    public static double RangoReciproco(int k, IReadOnlyList<string> relevantes, IReadOnlyList<string> ranking)
    {
        var i = ranking.Take(k).ToList().FindIndex(relevantes.Contains);
        return i < 0 ? 0 : 1.0 / (i + 1);
    }
}

public static class Estadistica
{
    /// <summary>Intervalo de Wilson al 95 %.</summary>
    public static (double A, double B) Wilson(int k, int n)
    {
        const double z = 1.959964;
        double p = (double)k / n, d = 1 + z * z / n;
        double centro = (p + z * z / (2 * n)) / d;
        double margen = z * Math.Sqrt(p * (1 - p) / n + z * z / (4.0 * n * n)) / d;
        return (Math.Max(0, centro - margen), Math.Min(1, centro + margen));
    }

    public static string Fraccion(int k, int n)
    {
        var (a, b) = Wilson(k, n);
        return string.Create(CultureInfo.InvariantCulture, $"{k}/{n}; Wilson 95 % [{a:0.00}; {b:0.00}]");
    }

    /// <summary>
    /// Comparación pareada por pedido: «difiere» sólo con 6 o más pares discordantes, todos en el
    /// mismo sentido (prueba del signo bilateral, p = 2·0,5^n &lt; 0,05). Si no, «no separado con este N».
    /// </summary>
    public static string Pareada(string a, string b, IReadOnlyList<(double TasaA, double TasaB)> pares)
    {
        int aMejor = pares.Count(p => p.TasaA > p.TasaB), bMejor = pares.Count(p => p.TasaB > p.TasaA);
        int discordantes = aMejor + bMejor;
        var veredicto = discordantes >= 6 && (aMejor == 0 || bMejor == 0)
            ? $"difiere (p = {2 * Math.Pow(0.5, discordantes):0.000})"
            : "no separado con este N";
        return $"pares {pares.Count}; discordantes {discordantes} ({a} mejor en {aMejor}, {b} mejor en {bMejor}); {veredicto}";
    }
}
