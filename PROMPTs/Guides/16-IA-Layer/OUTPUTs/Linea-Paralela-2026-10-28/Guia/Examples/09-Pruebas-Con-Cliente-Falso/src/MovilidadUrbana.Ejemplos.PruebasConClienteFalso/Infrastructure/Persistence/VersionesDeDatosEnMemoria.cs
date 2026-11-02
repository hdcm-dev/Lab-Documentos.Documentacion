using System.Collections.Concurrent;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Abstractions;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.Persistence;

/// <summary>Almacén por sesión de la versión de los datos. Singleton: sobrevive entre pedidos HTTP (entre ámbitos).</summary>
public sealed class VersionesDeDatosEnMemoria : IVersionesDeDatos
{
    private readonly ConcurrentDictionary<string, long> _versiones = new();

    public long Leer(string sesion) => _versiones.GetValueOrDefault(sesion);

    public void Incrementar(string sesion) => _versiones.AddOrUpdate(sesion, 1, (_, v) => v + 1);
}
