using MovilidadUrbana.ApiWeb.Application.Encuestas;
using MovilidadUrbana.ApiWeb.Domain;
using MovilidadUrbana.Asistente.Application.Abstractions;
using MovilidadUrbana.Asistente.Application.Normalizacion;

namespace MovilidadUrbana.Asistente.Application.Encuestas;

/// <summary>Lo que el modelo extrae del texto para el paso 2: medios y frecuencia, tal como los escribió.</summary>
public sealed record EncuestaPaso2Propuesta(string[]? Medios, string? Frecuencia);

/// <summary>El paso 2 ya normalizado a claves del catálogo, con los errores por campo.</summary>
public sealed record PropuestaDePaso2(
    IReadOnlyList<string> Medios,
    string Frecuencia,
    IReadOnlyDictionary<string, string> Errores);

/// <summary>
/// ESC-03 «desde texto» para el paso 2 de la encuesta: el modelo propone, el catálogo normaliza y la regla
/// copiada (<see cref="EncuestaService.ValidarPaso"/>) decide. Un medio fuera del catálogo se rechaza: no
/// se descarta en silencio. No registra la encuesta.
/// </summary>
public sealed class ProponerPaso2DesdeTexto(IExtractorDeEncuesta extractor, EncuestaService encuestas)
{
    public async Task<PropuestaDePaso2?> ProponerAsync(string texto, CancellationToken cancellationToken)
    {
        var propuesta = await extractor.ExtraerPaso2Async(texto, cancellationToken);
        return propuesta is null ? null : Validar(propuesta);
    }

    public PropuestaDePaso2 Validar(EncuestaPaso2Propuesta propuesta)
    {
        var (claves, desconocidos) = NormalizadorDeCatalogos.Medios(propuesta.Medios);
        var frecuencia = NormalizadorDeCatalogos.Frecuencia(propuesta.Frecuencia);

        var model = new EncuestaModel { Frecuencia = frecuencia ?? string.Empty };
        foreach (var clave in claves) model.AlternarMedio(clave, elegido: true);

        var errores = new Dictionary<string, string>(encuestas.ValidarPaso(2, model));
        if (desconocidos.Count > 0)
        {
            errores["medios"] =
                $"Medios fuera del catálogo: {string.Join(", ", desconocidos)}. " +
                $"Los del catálogo son: {string.Join(", ", Catalogos.Medios.Select(m => m.Etiqueta))}.";
        }
        if (frecuencia is null && !string.IsNullOrWhiteSpace(propuesta.Frecuencia))
        {
            errores["frecuencia"] =
                $"«{propuesta.Frecuencia!.Trim()}» no está en el catálogo. " +
                $"Las del catálogo son: {string.Join(", ", Catalogos.Frecuencias.Select(f => f.Etiqueta))}.";
        }

        return new PropuestaDePaso2(claves, frecuencia ?? string.Empty, errores);
    }
}

/// <summary>Conteos crudos por clave, tal como los devuelve la lectura.</summary>
public sealed record ConteosDeEncuesta(
    int Total,
    IReadOnlyDictionary<string, int> PorMedio,
    IReadOnlyDictionary<string, int> PorMotivo,
    IReadOnlyDictionary<string, int> PorLocalidad);

/// <summary>Una celda de un agregado: la clave, su etiqueta y cuántas respuestas la tienen.</summary>
public sealed record ConteoPorCategoria(string Clave, string Etiqueta, int Cantidad);

/// <summary>Resultados agregados de la encuesta de la sesión. No lleva nombre, edad ni ningún campo de la persona.</summary>
public sealed record ResumenDeResultados(
    int Total,
    IReadOnlyList<ConteoPorCategoria> PorMedio,
    IReadOnlyList<ConteoPorCategoria> PorMotivo,
    IReadOnlyList<ConteoPorCategoria> PorLocalidad);

/// <summary>
/// D4: el dato exacto («¿qué medio usa más la gente?») lo calcula este caso de uso, no el modelo. Sólo
/// agrega conteos de la sesión. En CTX-PROD haría falta un tamaño mínimo de celda con supresión
/// complementaria; en la demo cada sesión agrega sólo lo que ella cargó.
/// </summary>
public sealed class ResultadosDeEncuestaService(ILecturaDeResultados lectura)
{
    public async Task<ResumenDeResultados> ResumirAsync(CancellationToken cancellationToken)
    {
        var c = await lectura.LeerAsync(cancellationToken);
        return new ResumenDeResultados(
            c.Total,
            Ordenar(c.PorMedio, Catalogos.EtiquetaDeMedio),
            Ordenar(c.PorMotivo, Catalogos.EtiquetaDeMotivo),
            Ordenar(c.PorLocalidad, clave => clave));
    }

    private static IReadOnlyList<ConteoPorCategoria> Ordenar(IReadOnlyDictionary<string, int> conteos, Func<string, string> etiqueta) =>
        conteos.OrderByDescending(c => c.Value).ThenBy(c => c.Key, StringComparer.Ordinal)
            .Select(c => new ConteoPorCategoria(c.Key, etiqueta(c.Key), c.Value))
            .ToList();
}
