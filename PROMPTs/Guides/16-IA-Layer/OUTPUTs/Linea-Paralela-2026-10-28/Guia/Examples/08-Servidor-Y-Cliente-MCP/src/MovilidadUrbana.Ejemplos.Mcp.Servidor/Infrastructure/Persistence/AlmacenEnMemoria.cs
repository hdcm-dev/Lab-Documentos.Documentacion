using MovilidadUrbana.ApiWeb.Domain.Entities;

namespace MovilidadUrbana.Ejemplos.Mcp.Servidor.Infrastructure.Persistence;

/// <summary>
/// Reemplaza a la base SQLite del caso base para que el ejemplo no necesite base. Guarda las localidades
/// de TODAS las sesiones, como la tabla real; el repositorio filtra por sesión. Cada sesión nueva se siembra
/// con las mismas dos localidades que siembra el caso base (Corrientes y Resistencia).
/// Cuenta lecturas y escrituras para que las pruebas las muestren.
/// </summary>
public sealed class AlmacenEnMemoria
{
    private readonly Lock _candado = new();
    private readonly List<Localidad> _filas = [];
    private readonly HashSet<string> _sembradas = [];
    private int _ultimoId;

    public int Lecturas { get; private set; }
    public int Escrituras { get; private set; }

    public IReadOnlyList<Localidad> Leer(string sesion, Func<Localidad, bool>? filtro = null)
    {
        lock (_candado)
        {
            Sembrar(sesion);
            Lecturas++;
            return _filas.Where(l => l.SessionId == sesion && (filtro?.Invoke(l) ?? true)).Select(Copia).ToList();
        }
    }

    public int Agregar(string sesion, Localidad localidad)
    {
        lock (_candado)
        {
            Sembrar(sesion);
            Escrituras++;
            var fila = Copia(localidad);
            fila.Id = ++_ultimoId;
            fila.SessionId = sesion;
            _filas.Add(fila);
            return fila.Id;
        }
    }

    public void Reemplazar(string sesion, Localidad localidad)
    {
        lock (_candado)
        {
            Escrituras++;
            var i = _filas.FindIndex(l => l.Id == localidad.Id && l.SessionId == sesion);
            if (i >= 0) _filas[i] = Copia(localidad);
        }
    }

    public void Borrar(string sesion, int id)
    {
        lock (_candado)
        {
            Escrituras++;
            _filas.RemoveAll(l => l.Id == id && l.SessionId == sesion);
        }
    }

    private void Sembrar(string sesion)
    {
        if (!_sembradas.Add(sesion)) return;
        foreach (var (nombre, provincia, cp, habitantes) in new[]
                 { ("Corrientes", "Corrientes", "3400", 346334), ("Resistencia", "Chaco", "3500", 291720) })
            _filas.Add(new Localidad { Id = ++_ultimoId, SessionId = sesion, Nombre = nombre, Provincia = provincia, CodigoPostal = cp, Habitantes = habitantes });
    }

    private static Localidad Copia(Localidad l) => new()
        { Id = l.Id, SessionId = l.SessionId, Nombre = l.Nombre, Provincia = l.Provincia, CodigoPostal = l.CodigoPostal, Habitantes = l.Habitantes };
}
