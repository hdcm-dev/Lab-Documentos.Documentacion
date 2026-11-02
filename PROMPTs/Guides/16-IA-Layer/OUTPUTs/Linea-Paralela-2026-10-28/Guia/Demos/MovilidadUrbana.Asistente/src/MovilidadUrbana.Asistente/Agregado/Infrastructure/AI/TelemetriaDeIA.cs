using System.Diagnostics.Metrics;

namespace MovilidadUrbana.Asistente.Infrastructure.AI;

/// <summary>
/// Nombres de telemetría de la capa de IA. La misma constante va a <c>UseOpenTelemetry(sourceName:)</c>,
/// a <c>AddSource</c> y a <c>AddMeter</c>: con nombres distintos no se ve ningún span.
/// </summary>
public static class TelemetriaDeIA
{
    public const string Fuente = "MovilidadUrbana.AI";

    public const string AciertosDeCache = "movilidadurbana.ai.cache.aciertos";

    public static readonly Meter Medidor = new(Fuente);

    /// <summary>Un acierto de caché no deja spans: se lee en esta métrica.</summary>
    public static readonly Counter<long> Aciertos =
        Medidor.CreateCounter<long>(AciertosDeCache, unit: "{acierto}", description: "Respuestas servidas desde la caché.");
}
