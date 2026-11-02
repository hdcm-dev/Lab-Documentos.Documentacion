using MovilidadUrbana.Busqueda.Busqueda;

namespace MovilidadUrbana.Busqueda.Evaluacion;

/// <summary>Una consulta del oro con lo que devolvió la búsqueda (ordenado de mayor a menor similitud).</summary>
public sealed record FilaDeConsulta(ConsultaDeOro Consulta, IReadOnlyList<ResultadoDeBusqueda> Resultados, int K, double? Umbral)
{
    /// <summary>Rango (1..K) del primer relevante entre los K primeros, o null si no está.</summary>
    public int? RangoDelPrimerRelevante =>
        Resultados.Take(K).Select((r, i) => (r, i)).Where(t => Consulta.Relevantes.Contains(t.r.Fuente))
            .Select(t => (int?)(t.i + 1)).FirstOrDefault();

    public bool HitEn(int k) => RangoDelPrimerRelevante is { } r && r <= k;

    public double RecallEnK =>
        (double)Resultados.Take(K).Count(r => Consulta.Relevantes.Contains(r.Fuente)) / Consulta.Relevantes.Count;

    public double RangoReciproco => RangoDelPrimerRelevante is { } r ? 1.0 / r : 0.0;

    public double MejorSimilitud => Resultados.Count > 0 ? Resultados[0].Similitud : double.NegativeInfinity;

    /// <summary>Se abstiene si la mejor similitud queda bajo el umbral. Sin umbral, nunca se abstiene.</summary>
    public bool SeAbstiene => Umbral is { } u && MejorSimilitud < u;
}

/// <summary>
/// Métricas sobre las consultas respondibles Q, con R(q) relevantes y la lista recuperada de largo k:
/// hit@k = proporción de consultas con al menos un relevante entre los k primeros;
/// recall@k = promedio de |relevantes entre los k| / |R(q)|;
/// MRR@k = promedio de 1/rango del primer relevante si está entre los k primeros, y 0 si no.
/// Las no respondibles quedan fuera de esos promedios: con ellas se mide la abstención correcta.
/// </summary>
public sealed record InformeDeRecuperacion(IReadOnlyList<FilaDeConsulta> Filas, int K, int TamanoDelCorpus)
{
    public IReadOnlyList<FilaDeConsulta> Respondibles => Filas.Where(f => f.Consulta.Respondible).ToList();
    public IReadOnlyList<FilaDeConsulta> NoRespondibles => Filas.Where(f => !f.Consulta.Respondible).ToList();

    public int AciertosEn(int k) => Respondibles.Count(f => f.HitEn(k));
    public double HitEn(int k) => (double)AciertosEn(k) / Respondibles.Count;
    public double RecallEnK => Respondibles.Average(f => f.RecallEnK);
    public double Mrr => Respondibles.Average(f => f.RangoReciproco);

    public int AbstencionesCorrectas => NoRespondibles.Count(f => f.SeAbstiene);
    public double Abstencion => NoRespondibles.Count == 0 ? double.NaN : (double)AbstencionesCorrectas / NoRespondibles.Count;

    /// <summary>Respondibles en las que se abstuvo: el costo del umbral.</summary>
    public int AbstencionesIndebidas => Respondibles.Count(f => f.SeAbstiene);

    /// <summary>Línea de azar con un relevante: hit@k = k / tamaño del corpus.</summary>
    public double AzarHitEn(int k) => (double)k / TamanoDelCorpus;
}

public static class Wilson
{
    /// <summary>Intervalo de Wilson al 95 % para k éxitos en n.</summary>
    public static (double A, double B) Intervalo(int k, int n)
    {
        const double z = 1.959964;
        double p = (double)k / n, d = 1 + z * z / n;
        double centro = (p + z * z / (2 * n)) / d;
        double margen = z * Math.Sqrt(p * (1 - p) / n + z * z / (4.0 * n * n)) / d;
        return (Math.Max(0, centro - margen), Math.Min(1, centro + margen));
    }

    public static string Fraccion(int k, int n)
    {
        var (a, b) = Intervalo(k, n);
        return $"{k}/{n}; Wilson 95 % [{a:0.00}; {b:0.00}]";
    }
}
