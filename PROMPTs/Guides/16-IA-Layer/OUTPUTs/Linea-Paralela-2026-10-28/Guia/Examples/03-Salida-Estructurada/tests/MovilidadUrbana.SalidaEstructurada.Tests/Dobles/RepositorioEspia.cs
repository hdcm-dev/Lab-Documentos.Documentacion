using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Domain.Entities;

namespace MovilidadUrbana.SalidaEstructurada.Tests.Dobles;

/// <summary>
/// Repositorio espía con datos de dos sesiones. Filtra por sesión como el del caso base
/// (<c>l.Id == id &amp;&amp; l.SessionId == session.Id</c>) y cuenta lecturas y escrituras.
/// </summary>
public sealed class RepositorioEspia(string sesion) : ILocalidadRepository
{
    private readonly List<Localidad> _todas =
    [
        new() { Id = 1, SessionId = "sesion-a", Nombre = "Corrientes", Provincia = "Corrientes", CodigoPostal = "3400", Habitantes = 346334 },
        new() { Id = 2, SessionId = "sesion-a", Nombre = "Resistencia", Provincia = "Chaco", CodigoPostal = "3500", Habitantes = 291720 },
        new() { Id = 7, SessionId = "sesion-b", Nombre = "Goya", Provincia = "Corrientes", CodigoPostal = "3450", Habitantes = 89959 }
    ];

    public int Lecturas { get; private set; }
    public int Escrituras => Altas + Modificaciones + Bajas;
    public int Altas { get; private set; }
    public int Modificaciones { get; private set; }
    public int Bajas { get; private set; }
    public int Llamadas => Lecturas + Escrituras;

    public Task<IReadOnlyList<Localidad>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        Lecturas++;
        return Task.FromResult<IReadOnlyList<Localidad>>(_todas.Where(l => l.SessionId == sesion).ToList());
    }

    public Task<Localidad?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        Lecturas++;
        return Task.FromResult(_todas.FirstOrDefault(l => l.Id == id && l.SessionId == sesion));
    }

    public Task<int> AddAsync(Localidad localidad, CancellationToken cancellationToken = default)
    {
        Altas++;
        localidad.Id = _todas.Max(l => l.Id) + 1;
        localidad.SessionId = sesion;
        _todas.Add(localidad);
        return Task.FromResult(localidad.Id);
    }

    public Task UpdateAsync(Localidad localidad, CancellationToken cancellationToken = default)
    {
        Modificaciones++;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        Bajas++;
        return Task.CompletedTask;
    }
}
