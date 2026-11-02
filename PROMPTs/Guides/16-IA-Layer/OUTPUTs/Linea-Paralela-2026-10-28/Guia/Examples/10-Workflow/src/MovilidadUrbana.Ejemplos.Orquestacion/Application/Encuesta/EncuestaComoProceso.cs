using MovilidadUrbana.ApiWeb.Application.Encuestas;
using MovilidadUrbana.ApiWeb.Domain.Rules;

namespace MovilidadUrbana.Ejemplos.Orquestacion.Application.Encuesta;

/// <summary>Cómo terminó una encuesta: registrada, o detenida en el primer paso con errores.</summary>
public sealed record ResultadoDeLaEncuesta(bool Registrada, int? PasoConErrores, IReadOnlyDictionary<string, string> Errores)
{
    public static readonly IReadOnlyDictionary<string, string> SinErrores = new Dictionary<string, string>();

    public override string ToString() => Registrada
        ? "registrada"
        : $"detenida en el paso {PasoConErrores}: {string.Join(", ", Errores.Keys.Order())}";
}

/// <summary>
/// La encuesta de tres pasos como lo que es: un proceso de pasos fijos, sin ningún paso con modelo.
/// Es una función: valida cada paso con el caso de uso copiado y registra al final. No hace falta
/// ningún marco para escribirla.
/// </summary>
public sealed class EncuestaComoProceso(EncuestaService servicio)
{
    public async Task<ResultadoDeLaEncuesta> CompletarAsync(EncuestaModel encuesta, CancellationToken cancellationToken = default)
    {
        for (int paso = 1; paso <= EncuestaRules.TotalDePasos; paso++)
        {
            var errores = servicio.ValidarPaso(paso, encuesta);
            if (errores.Count > 0) return new(false, paso, errores);
        }

        await servicio.RegistrarAsync(encuesta, cancellationToken);
        return new(true, null, ResultadoDeLaEncuesta.SinErrores);
    }
}
