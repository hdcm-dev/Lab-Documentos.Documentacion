using MovilidadUrbana.ApiWeb.Application;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Abstractions;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Localidades;

/// <summary>
/// Escritura confirmada por la persona, por la operación normal (no por una herramienta: en este ejemplo
/// ninguna herramienta escribe). Delega en el caso de uso copiado y, DESPUÉS de que se confirmó, incrementa la
/// versión de los datos de la sesión para que la caché de respuestas no sirva una respuesta vieja.
/// </summary>
public sealed class AltaDeLocalidad(LocalidadService localidades, ISessionContext sesion, IVersionesDeDatos versiones)
{
    public async Task<Result> RegistrarAsync(LocalidadModel model, CancellationToken ct = default)
    {
        var resultado = await localidades.SaveAsync(model, ct);
        if (resultado.IsSuccess) versiones.Incrementar(sesion.Id);
        return resultado;
    }
}
