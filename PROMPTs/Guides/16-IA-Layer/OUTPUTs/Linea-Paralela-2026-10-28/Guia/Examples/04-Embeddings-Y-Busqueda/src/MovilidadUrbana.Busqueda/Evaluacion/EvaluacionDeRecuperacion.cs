using System.Globalization;
using System.Text;
using MovilidadUrbana.Busqueda.Busqueda;

namespace MovilidadUrbana.Busqueda.Evaluacion;

/// <summary>Resultado de correr el oro con un formato de consulta: umbral calibrado y métricas de evaluación.</summary>
public sealed record CorridaDelOro(string Formato, double Umbral, bool CalibracionSeparable, InformeDeRecuperacion Calibracion, InformeDeRecuperacion Evaluacion);

/// <summary>Corre la recuperación sola, sin generar: si el enunciado correcto no está en el top-k, ningún prompt lo arregla.</summary>
public static class EvaluacionDeRecuperacion
{
    public static async Task<CorridaDelOro> CorrerAsync(
        AlmacenDeRequisitos almacen, Oro oro, string? instruccion, int k, int tamanoDelCorpus, CancellationToken ct = default)
    {
        var formato = string.IsNullOrWhiteSpace(instruccion) ? "sin instrucción" : "con instrucción";

        // 1) Calibración: el umbral es el punto medio entre la peor respondible y la mejor no respondible.
        var calibracion = await InformeAsync(almacen, oro.De(GeneradorDeOro.Calibracion), instruccion, k, null, tamanoDelCorpus, ct);
        var peorRespondible = calibracion.Respondibles.Min(f => f.MejorSimilitud);
        var mejorNoRespondible = calibracion.NoRespondibles.Max(f => f.MejorSimilitud);
        var umbral = Math.Round((peorRespondible + mejorNoRespondible) / 2, 4);

        // 2) Evaluación con ese umbral, sobre consultas que no se usaron para calibrar.
        var evaluacion = await InformeAsync(almacen, oro.De(GeneradorDeOro.Evaluacion), instruccion, k, umbral, tamanoDelCorpus, ct);
        return new CorridaDelOro(formato, umbral, peorRespondible > mejorNoRespondible, calibracion, evaluacion);
    }

    public static async Task<InformeDeRecuperacion> InformeAsync(
        AlmacenDeRequisitos almacen, IEnumerable<ConsultaDeOro> consultas, string? instruccion, int k, double? umbral,
        int tamanoDelCorpus, CancellationToken ct = default)
    {
        var filas = new List<FilaDeConsulta>();
        foreach (var c in consultas)
        {
            var resultados = await almacen.BuscarAsync(FormatoDeConsulta.Aplicar(instruccion, c.Consulta), k, ct);
            filas.Add(new FilaDeConsulta(c, resultados, k, umbral));
        }
        return new InformeDeRecuperacion(filas, k, tamanoDelCorpus);
    }

    /// <summary>Tabla por consulta y totales, en texto plano (lo que se guarda como salida cruda).</summary>
    public static string Tabla(CorridaDelOro corrida)
    {
        var inv = CultureInfo.InvariantCulture;
        var e = corrida.Evaluacion;
        var sb = new StringBuilder();
        sb.AppendLine($"## Formato: {corrida.Formato}; k = {e.K}; umbral calibrado = {corrida.Umbral.ToString("0.0000", inv)} " +
                      $"(calibración {(corrida.CalibracionSeparable ? "separable" : "NO separable")})");
        sb.AppendLine("id\tresp\trango\thit@1\thit@3\trecall@3\tRR@3\tmejor\tabst\ttop-3");
        foreach (var f in e.Filas)
            sb.AppendLine(string.Join('\t',
                f.Consulta.Id, f.Consulta.Respondible ? "sí" : "no", f.RangoDelPrimerRelevante?.ToString(inv) ?? "-",
                f.Consulta.Respondible ? (f.HitEn(1) ? 1 : 0).ToString(inv) : "-",
                f.Consulta.Respondible ? (f.HitEn(3) ? 1 : 0).ToString(inv) : "-",
                f.Consulta.Respondible ? f.RecallEnK.ToString("0.00", inv) : "-",
                f.Consulta.Respondible ? f.RangoReciproco.ToString("0.00", inv) : "-",
                f.MejorSimilitud.ToString("0.0000", inv), f.SeAbstiene ? "sí" : "no",
                string.Join(" | ", f.Resultados.Select(r => $"{r.Fuente} {r.Similitud.ToString("0.0000", inv)}"))));
        int kr = e.Respondibles.Count, kn = e.NoRespondibles.Count;
        sb.AppendLine($"hit@1 = {Wilson.Fraccion(e.AciertosEn(1), kr)} (azar {e.AzarHitEn(1).ToString("0.00", inv)})");
        sb.AppendLine($"hit@3 = {Wilson.Fraccion(e.AciertosEn(3), kr)} (azar {e.AzarHitEn(3).ToString("0.00", inv)})");
        sb.AppendLine($"recall@3 = {e.RecallEnK.ToString("0.000", inv)} (promedio sobre {kr} respondibles)");
        sb.AppendLine($"MRR@3 = {e.Mrr.ToString("0.000", inv)} (promedio sobre {kr} respondibles)");
        sb.AppendLine($"abstención correcta = {Wilson.Fraccion(e.AbstencionesCorrectas, kn)}; abstenciones indebidas en respondibles = {e.AbstencionesIndebidas}/{kr}");
        return sb.ToString();
    }
}
