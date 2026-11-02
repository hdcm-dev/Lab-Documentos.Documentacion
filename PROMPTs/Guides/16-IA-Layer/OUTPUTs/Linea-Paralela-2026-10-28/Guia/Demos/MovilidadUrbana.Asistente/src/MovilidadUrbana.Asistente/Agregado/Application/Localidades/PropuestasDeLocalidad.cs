using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.ApiWeb.Domain.Rules;
using MovilidadUrbana.Asistente.Application.Abstractions;
using MovilidadUrbana.Asistente.Application.Asistente;
using MovilidadUrbana.Asistente.Application.Normalizacion;

namespace MovilidadUrbana.Asistente.Application.Localidades;

/// <summary>Lo que el modelo extrae del texto para un alta. Cualquier campo puede faltar.</summary>
public sealed record LocalidadPropuesta(string? Nombre, string? Provincia, string? CodigoPostal, int? Habitantes);

/// <summary>Lo que el modelo sugiere para una baja: el tipo y el id de una de las localidades que se le mostraron.</summary>
public sealed record AccionSugerida(TipoDeAccion Tipo, int? LocalidadId);

/// <summary>Una localidad de la sesión tal como se le muestra al modelo para elegir.</summary>
public sealed record LocalidadDeReferencia(int Id, string Nombre, string Provincia);

/// <summary>Resultado de proponer: la acción validada, o el motivo por el que se descartó.</summary>
public sealed record ResultadoDePropuesta(AccionPropuesta? Accion, string? MotivoDeDescarte)
{
    public static ResultadoDePropuesta Valida(AccionPropuesta accion) => new(accion, null);

    public static ResultadoDePropuesta Descartada(string motivo) => new(null, motivo);
}

/// <summary>
/// ESC-03 «desde texto»: arma la propuesta de alta y la valida con el normalizador y las reglas del
/// dominio, <b>sin persistir</b>. El alta la hace la persona con POST /api/v1/localidades.
/// </summary>
public sealed class ProponerLocalidadDesdeTexto(IExtractorDeLocalidad extractor, ILocalidadRepository repository)
{
    public async Task<ResultadoDePropuesta> ProponerAsync(string texto, CancellationToken cancellationToken)
    {
        var propuesta = await extractor.ExtraerAsync(texto, cancellationToken);
        if (propuesta is null) return ResultadoDePropuesta.Descartada(AvisosDelAsistente.SinInterpretacion);
        return ResultadoDePropuesta.Valida(await ValidarAsync(propuesta, cancellationToken));
    }

    /// <summary>Normaliza y valida. Lee las localidades de la sesión para avisar un duplicado; no escribe.</summary>
    public async Task<AccionPropuesta> ValidarAsync(LocalidadPropuesta propuesta, CancellationToken cancellationToken)
    {
        var errores = new Dictionary<string, string>();
        var nombre = (propuesta.Nombre ?? string.Empty).Trim();
        var provinciaCruda = (propuesta.Provincia ?? string.Empty).Trim();
        var codigoPostal = (propuesta.CodigoPostal ?? string.Empty).Trim();

        if (!LocalidadRules.NombreValido(nombre) || !NormalizadorDeCatalogos.NombreDentroDelLargo(nombre))
            errores["nombre"] = $"El nombre no cumple el requisito: {LocalidadPolicy.RequisitoDelNombre}";

        var provincia = NormalizadorDeCatalogos.Provincia(provinciaCruda);
        if (provincia is null)
            errores["provincia"] = $"«{provinciaCruda}» no está en el catálogo. {LocalidadPolicy.RequisitoDeLaProvincia}";

        if (!NormalizadorDeCatalogos.CodigoPostalSoloAscii(codigoPostal) || !LocalidadRules.CodigoPostalValido(codigoPostal))
            errores["codigoPostal"] = $"«{codigoPostal}» no cumple el requisito: {LocalidadPolicy.RequisitoDelCodigoPostal}";

        if (!LocalidadRules.HabitantesValidos(propuesta.Habitantes))
            errores["habitantes"] = $"Falta o no es válido. {LocalidadPolicy.RequisitoDeLosHabitantes}";

        if (!errores.ContainsKey("nombre") && provincia is not null)
        {
            var existentes = await repository.GetAllAsync(cancellationToken);
            if (existentes.Any(l => LocalidadRules.MismaLocalidad(l.Nombre, l.Provincia, nombre, provincia)))
                errores["nombre"] = "Ya existe una localidad con ese nombre en la provincia.";
        }

        return new AccionPropuesta(
            TipoDeAccion.Alta,
            new DatosDeAccion(null, nombre, provincia ?? provinciaCruda, codigoPostal, propuesta.Habitantes, errores));
    }
}

/// <summary>
/// ESC-04: arma la propuesta de baja. El modelo elige entre las localidades de la sesión; la propuesta
/// se valida antes de llegar a la UI (tipo definido, id positivo, id existente en la sesión) y lleva la
/// entidad que resuelve el servidor. La baja la hace la persona con DELETE /api/v1/localidades/{id}.
/// </summary>
public sealed class ProponerBajaDesdeTexto(IExtractorDeBaja extractor, ILocalidadRepository repository)
{
    public async Task<ResultadoDePropuesta> ProponerAsync(string texto, CancellationToken cancellationToken)
    {
        var disponibles = (await repository.GetAllAsync(cancellationToken))
            .Select(l => new LocalidadDeReferencia(l.Id, l.Nombre, l.Provincia))
            .ToList();
        var sugerida = await extractor.ExtraerAsync(texto, disponibles, cancellationToken);
        return await ValidarAsync(sugerida, cancellationToken);
    }

    /// <summary>
    /// Descarta antes de tocar el repositorio un tipo que el enum no define, un tipo que no es baja o un id
    /// no positivo. Sólo si pasa eso lee la localidad, siempre filtrada por la sesión.
    /// </summary>
    public async Task<ResultadoDePropuesta> ValidarAsync(AccionSugerida? sugerida, CancellationToken cancellationToken)
    {
        if (sugerida is null) return ResultadoDePropuesta.Descartada(AvisosDelAsistente.SinInterpretacion);
        if (!NormalizadorDeCatalogos.TipoDefinido(sugerida.Tipo))
            return ResultadoDePropuesta.Descartada($"El tipo de acción {(int)sugerida.Tipo} no existe.");
        if (sugerida.Tipo != TipoDeAccion.Baja)
            return ResultadoDePropuesta.Descartada("El pedido no es una baja.");
        if (sugerida.LocalidadId is not int id || id <= 0)
            return ResultadoDePropuesta.Descartada("No encontré esa localidad entre las tuyas.");

        var localidad = await repository.GetByIdAsync(id, cancellationToken);
        if (localidad is null) return ResultadoDePropuesta.Descartada("No encontré esa localidad entre las tuyas.");

        return ResultadoDePropuesta.Valida(new AccionPropuesta(
            TipoDeAccion.Baja,
            new DatosDeAccion(localidad.Id, localidad.Nombre, localidad.Provincia, localidad.CodigoPostal,
                localidad.Habitantes, new Dictionary<string, string>())));
    }
}
