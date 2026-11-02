using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Domain.Entities;

namespace MovilidadUrbana.Ejemplos.Orquestacion.Infrastructure.Persistence;

/// <summary>
/// Almacén del ejemplo, en memoria y compartido por los ámbitos. Cuenta las escrituras para que las
/// pruebas puedan afirmar «0 escrituras» sin mirar adentro de los repositorios.
/// </summary>
public sealed class AlmacenEnMemoria
{
    private int _siguienteId = 2;
    private readonly object _candado = new();

    public List<Localidad> Localidades { get; } =
    [
        // Las dos localidades que siembra SessionSeeder en el caso base.
        new() { Id = 1, SessionId = "*", Nombre = "Corrientes", Provincia = "Corrientes", CodigoPostal = "3400", Habitantes = 352646 },
        new() { Id = 2, SessionId = "*", Nombre = "Resistencia", Provincia = "Chaco", CodigoPostal = "3500", Habitantes = 291720 },
    ];

    public List<RespuestaDeEncuesta> Encuestas { get; } = [];

    public int Escrituras { get; private set; }

    internal int NuevoId() { lock (_candado) return ++_siguienteId; }

    internal void ContarEscritura() { lock (_candado) Escrituras++; }
}

/// <summary>Filtra por sesión como el repositorio del caso base; las sembradas («*») las ve cualquier sesión.</summary>
public sealed class LocalidadRepositoryEnMemoria(AlmacenEnMemoria almacen, ISessionContext sesion) : ILocalidadRepository
{
    private IEnumerable<Localidad> DeLaSesion => almacen.Localidades.Where(l => l.SessionId == sesion.Id || l.SessionId == "*");

    public Task<IReadOnlyList<Localidad>> GetAllAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult<IReadOnlyList<Localidad>>(DeLaSesion.OrderBy(l => l.Nombre).ToList());

    public Task<Localidad?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        Task.FromResult(DeLaSesion.FirstOrDefault(l => l.Id == id));

    public Task<int> AddAsync(Localidad localidad, CancellationToken cancellationToken = default)
    {
        localidad.Id = almacen.NuevoId();
        localidad.SessionId = sesion.Id;
        almacen.Localidades.Add(localidad);
        almacen.ContarEscritura();
        return Task.FromResult(localidad.Id);
    }

    public Task UpdateAsync(Localidad localidad, CancellationToken cancellationToken = default)
    {
        almacen.ContarEscritura();
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        almacen.Localidades.RemoveAll(l => l.Id == id && l.SessionId == sesion.Id);
        almacen.ContarEscritura();
        return Task.CompletedTask;
    }
}

public sealed class EncuestaRepositoryEnMemoria(AlmacenEnMemoria almacen, ISessionContext sesion) : IEncuestaRepository
{
    public Task<int> AddAsync(RespuestaDeEncuesta respuesta, CancellationToken cancellationToken = default)
    {
        respuesta.Id = almacen.NuevoId();
        respuesta.SessionId = sesion.Id;
        almacen.Encuestas.Add(respuesta);
        almacen.ContarEscritura();
        return Task.FromResult(respuesta.Id);
    }

    public Task<int> CountAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult(almacen.Encuestas.Count(e => e.SessionId == sesion.Id));
}
