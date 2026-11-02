using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Domain.Entities;

namespace MovilidadUrbana.SalidaEstructurada.Infrastructure.Persistence;

/// <summary>
/// Repositorio en memoria de UNA sesión, sembrado como el caso base (Corrientes y Resistencia).
/// Reemplaza a EF Core para que el ejemplo no necesite base; cuenta las escrituras para mostrarlas.
/// </summary>
public sealed class LocalidadRepositoryEnMemoria : ILocalidadRepository
{
    private readonly List<Localidad> _localidades =
    [
        new() { Id = 1, SessionId = "ejemplo", Nombre = "Corrientes", Provincia = "Corrientes", CodigoPostal = "3400", Habitantes = 346334 },
        new() { Id = 2, SessionId = "ejemplo", Nombre = "Resistencia", Provincia = "Chaco", CodigoPostal = "3500", Habitantes = 291720 }
    ];

    public int Escrituras { get; private set; }

    public Task<IReadOnlyList<Localidad>> GetAllAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult<IReadOnlyList<Localidad>>(_localidades.ToList());

    public Task<Localidad?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        Task.FromResult(_localidades.FirstOrDefault(l => l.Id == id));

    public Task<int> AddAsync(Localidad localidad, CancellationToken cancellationToken = default)
    {
        Escrituras++;
        localidad.Id = _localidades.Max(l => l.Id) + 1;
        _localidades.Add(localidad);
        return Task.FromResult(localidad.Id);
    }

    public Task UpdateAsync(Localidad localidad, CancellationToken cancellationToken = default)
    {
        Escrituras++;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        Escrituras++;
        _localidades.RemoveAll(l => l.Id == id);
        return Task.CompletedTask;
    }
}
