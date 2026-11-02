using System.Reflection;
using System.Text.RegularExpressions;
using MovilidadUrbana.ApiWeb.Application.Encuestas;
using MovilidadUrbana.ApiWeb.Application.Localidades;

namespace MovilidadUrbana.Asistente.Infrastructure.AI;

public sealed record Requisito(string Id, string Texto);

/// <summary>Corpus = los enunciados de *Policy leídos del código (no transcriptos).</summary>
public static class CorpusDeRequisitos
{
    public static IReadOnlyList<Requisito> Leer() =>
        new[] { (typeof(LocalidadPolicy), "Localidad"), (typeof(EncuestaPolicy), "Encuesta") }
            .SelectMany(t => t.Item1.GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.PropertyType == typeof(string))
                .Select(p => new Requisito($"{t.Item1.Name}.{p.Name}",
                    $"{t.Item2}, {Campo(p.Name)}: {(string)p.GetValue(null)!}")))
            .ToList();

    static string Campo(string prop) =>
        Regex.Replace(Regex.Replace(prop, "^Requisito(DeLos|DeLas|DeLa|Del|De)", ""), "(?<=[a-z])(?=[A-Z])", " ").ToLowerInvariant();
}
