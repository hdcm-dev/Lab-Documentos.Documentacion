using MovilidadUrbana.Asistente.Application.Asistente;
using MovilidadUrbana.Asistente.Application.Encuestas;

namespace MovilidadUrbana.Asistente.Presentation.Contracts;

/// <summary>Pedido al asistente. Sin <see cref="ConversacionId"/>, el servidor abre una conversación nueva.</summary>
public sealed record PedidoAlAsistente(string? Texto, string? ConversacionId);

/// <summary>Pedido «desde texto»: sólo propone, nunca guarda.</summary>
public sealed record PedidoDesdeTexto(string? Texto);

/// <summary>Un evento del asistente tal como lo emite la API (una entrada del arreglo JSON que va llegando).</summary>
public sealed record EventoDto(string Tipo, string? Etapa, string? Texto, AccionDto? Accion, IReadOnlyList<string>? Fuentes)
{
    public static EventoDto De(EventoDelAsistente evento) => evento switch
    {
        EtapaIniciada e => new("etapa", e.Nombre, null, null, null),
        TextoParcial t => new("texto", null, t.Texto, null, null),
        AccionPropuesta a => new("accion", null, null, AccionDto.De(a), null),
        Final f => new("final", null, null, null, f.Fuentes),
        _ => throw new InvalidOperationException($"Evento sin contrato: {evento.GetType().Name}")
    };
}

/// <summary>Una acción propuesta y validada. Se confirma con POST o DELETE en /api/v1/localidades.</summary>
public sealed record AccionDto(string Tipo, int? LocalidadId, string Nombre, string Provincia, string CodigoPostal,
    int? Habitantes, IReadOnlyDictionary<string, string> Errores)
{
    public static AccionDto De(AccionPropuesta a) =>
        new(a.Tipo.ToString().ToLowerInvariant(), a.Datos.LocalidadId, a.Datos.Nombre, a.Datos.Provincia,
            a.Datos.CodigoPostal, a.Datos.Habitantes, a.Datos.Errores);
}

/// <summary>Propuesta de alta desde texto: los datos para precargar el formulario y sus errores.</summary>
public sealed record PropuestaDeAltaDto(bool Interpretada, AccionDto? Propuesta, string? Motivo);

/// <summary>Paso 2 de la encuesta desde texto, normalizado.</summary>
public sealed record PropuestaDePaso2Dto(bool Interpretada, IReadOnlyList<string> Medios, string Frecuencia, IReadOnlyDictionary<string, string> Errores)
{
    public static PropuestaDePaso2Dto De(PropuestaDePaso2? p) =>
        p is null ? new(false, [], string.Empty, new Dictionary<string, string>()) : new(true, p.Medios, p.Frecuencia, p.Errores);
}
