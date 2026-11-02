using Microsoft.EntityFrameworkCore;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Domain.Entities;
using MovilidadUrbana.ApiWeb.Infrastructure.Persistence;
using MovilidadUrbana.Asistente.Application.Abstractions;
using MovilidadUrbana.Asistente.Application.Encuestas;

namespace MovilidadUrbana.Asistente.Infrastructure.Persistence;

/// <summary>
/// Conteos de la encuesta de la sesión, con EF Core sobre el AppDbContext copiado. Motivo y localidad se
/// agrupan en la base (GROUP BY). Los medios se proyectan solos y se cuentan en memoria, porque el
/// ValueConverter de la lista no se traduce a SQL. Nunca lee Nombre ni Edad.
/// </summary>
public sealed class LecturaDeResultadosEf(IDbContextFactory<AppDbContext> factory, ISessionContext session) : ILecturaDeResultados
{
    public sealed record Conteo(string Clave, int Cantidad);

    public static IQueryable<Conteo> ConsultaPorMotivo(IQueryable<RespuestaDeEncuesta> respuestas) =>
        respuestas.GroupBy(e => e.Motivo).Select(g => new Conteo(g.Key, g.Count()));

    public static IQueryable<Conteo> ConsultaPorLocalidad(IQueryable<RespuestaDeEncuesta> respuestas) =>
        respuestas.GroupBy(e => e.Localidad).Select(g => new Conteo(g.Key, g.Count()));

    public IQueryable<RespuestaDeEncuesta> DeLaSesion(AppDbContext context) =>
        context.Encuestas.AsNoTracking().Where(e => e.SessionId == session.Id);

    public async Task<ConteosDeEncuesta> LeerAsync(CancellationToken cancellationToken)
    {
        await using var context = await factory.CreateDbContextAsync(cancellationToken);
        var respuestas = DeLaSesion(context);

        var total = await respuestas.CountAsync(cancellationToken);
        var porMotivo = await ConsultaPorMotivo(respuestas).ToDictionaryAsync(c => c.Clave, c => c.Cantidad, cancellationToken);
        var porLocalidad = await ConsultaPorLocalidad(respuestas).ToDictionaryAsync(c => c.Clave, c => c.Cantidad, cancellationToken);
        var medios = await respuestas.Select(e => e.Medios).ToListAsync(cancellationToken);
        var porMedio = medios.SelectMany(m => m).GroupBy(m => m).ToDictionary(g => g.Key, g => g.Count());

        return new ConteosDeEncuesta(total, porMedio, porMotivo, porLocalidad);
    }
}
