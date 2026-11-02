using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Domain.Entities;

namespace MovilidadUrbana.Asistente.Tests.Comun;

/// <summary>Cuenta las llamadas a los repositorios copiados. Lo comparten todos los ámbitos de una prueba.</summary>
public sealed class ContadorDeLlamadas
{
    private int _altas, _modificaciones, _bajas, _encuestas, _lecturas;
    public int Altas => _altas;
    public int Modificaciones => _modificaciones;
    public int Bajas => _bajas;
    public int EncuestasRegistradas => _encuestas;
    public int Lecturas => _lecturas;
    public int Escrituras => _altas + _modificaciones + _bajas + _encuestas;

    internal void Alta() => Interlocked.Increment(ref _altas);
    internal void Modificacion() => Interlocked.Increment(ref _modificaciones);
    internal void Baja() => Interlocked.Increment(ref _bajas);
    internal void Encuesta() => Interlocked.Increment(ref _encuestas);
    internal void Lectura() => Interlocked.Increment(ref _lecturas);
}

public sealed class LocalidadRepositoryEspia(ILocalidadRepository real, ContadorDeLlamadas contador) : ILocalidadRepository
{
    public Task<IReadOnlyList<Localidad>> GetAllAsync(CancellationToken cancellationToken = default) { contador.Lectura(); return real.GetAllAsync(cancellationToken); }
    public Task<Localidad?> GetByIdAsync(int id, CancellationToken cancellationToken = default) { contador.Lectura(); return real.GetByIdAsync(id, cancellationToken); }
    public Task<int> AddAsync(Localidad localidad, CancellationToken cancellationToken = default) { contador.Alta(); return real.AddAsync(localidad, cancellationToken); }
    public Task UpdateAsync(Localidad localidad, CancellationToken cancellationToken = default) { contador.Modificacion(); return real.UpdateAsync(localidad, cancellationToken); }
    public Task DeleteAsync(int id, CancellationToken cancellationToken = default) { contador.Baja(); return real.DeleteAsync(id, cancellationToken); }
}

public sealed class EncuestaRepositoryEspia(IEncuestaRepository real, ContadorDeLlamadas contador) : IEncuestaRepository
{
    public Task<int> AddAsync(RespuestaDeEncuesta respuesta, CancellationToken cancellationToken = default) { contador.Encuesta(); return real.AddAsync(respuesta, cancellationToken); }
    public Task<int> CountAsync(CancellationToken cancellationToken = default) { contador.Lectura(); return real.CountAsync(cancellationToken); }
}
