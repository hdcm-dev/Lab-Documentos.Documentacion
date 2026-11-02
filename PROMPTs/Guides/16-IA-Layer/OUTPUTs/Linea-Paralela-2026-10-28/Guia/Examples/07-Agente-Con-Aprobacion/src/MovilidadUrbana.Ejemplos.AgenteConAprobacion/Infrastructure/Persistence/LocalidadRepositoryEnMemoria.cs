using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Domain.Entities;

namespace MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.Persistence;

/// <summary>
/// Repositorio acotado a la sesión actual, como el del caso base: ninguna consulta sale del espacio de
/// datos del visitante. Scoped: una sesión por ámbito.
/// </summary>
public sealed class LocalidadRepositoryEnMemoria(AlmacenEnMemoria almacen, ISessionContext session) : ILocalidadRepository
{
    public Task<IReadOnlyList<Localidad>> GetAllAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult(almacen.Leer(session.Id));

    public Task<Localidad?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        Task.FromResult(almacen.Leer(session.Id, l => l.Id == id).FirstOrDefault());

    public Task<int> AddAsync(Localidad localidad, CancellationToken cancellationToken = default) =>
        Task.FromResult(almacen.Agregar(session.Id, localidad));

    public Task UpdateAsync(Localidad localidad, CancellationToken cancellationToken = default)
    {
        if (localidad.SessionId == session.Id) almacen.Reemplazar(session.Id, localidad);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        almacen.Borrar(session.Id, id);
        return Task.CompletedTask;
    }
}
