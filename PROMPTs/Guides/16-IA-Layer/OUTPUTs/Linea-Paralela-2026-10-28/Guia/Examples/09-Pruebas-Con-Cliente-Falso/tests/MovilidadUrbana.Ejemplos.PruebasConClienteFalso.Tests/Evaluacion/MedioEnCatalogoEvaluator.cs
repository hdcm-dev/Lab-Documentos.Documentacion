using System.Text.Json;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.AI.Evaluation;
using MovilidadUrbana.ApiWeb.Domain;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Encuestas;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests.Evaluacion;

/// <summary>
/// Evaluador propio y determinista: cada medio que propone el modelo para el paso 2 tiene que ser una clave de
/// <see cref="Catalogos.Medios"/>. «piedra» (o «bondi» sin normalizar) es una métrica fallida, con el motivo.
/// </summary>
public sealed class MedioEnCatalogoEvaluator : IEvaluator
{
    public const string Nombre = "Medio en catálogo";

    public IReadOnlyCollection<string> EvaluationMetricNames => [Nombre];

    public ValueTask<EvaluationResult> EvaluateAsync(IEnumerable<ChatMessage> messages, ChatResponse modelResponse,
        ChatConfiguration? chatConfiguration = null, IEnumerable<EvaluationContext>? additionalContext = null,
        CancellationToken cancellationToken = default)
    {
        bool ok = false;
        string motivo;
        try
        {
            var propuesta = JsonSerializer.Deserialize<EncuestaPaso2Propuesta>(modelResponse.Text, new JsonSerializerOptions(JsonSerializerDefaults.Web));
            var fuera = (propuesta?.Medios ?? []).Where(m => !Catalogos.Medios.Any(c => c.Clave == m)).ToList();
            ok = propuesta is { Medios.Length: > 0 } && fuera.Count == 0;
            motivo = ok ? "todos los medios son claves del catálogo"
                : fuera.Count > 0 ? $"medios fuera del catálogo: {string.Join(", ", fuera)}" : "sin medios";
        }
        catch (JsonException) { motivo = "la respuesta no es JSON"; }

        var metrica = new BooleanMetric(Nombre, ok, motivo)
        {
            Interpretation = new EvaluationMetricInterpretation(
                ok ? EvaluationRating.Good : EvaluationRating.Unacceptable, failed: !ok, reason: motivo),
        };
        return new(new EvaluationResult(metrica));
    }
}
