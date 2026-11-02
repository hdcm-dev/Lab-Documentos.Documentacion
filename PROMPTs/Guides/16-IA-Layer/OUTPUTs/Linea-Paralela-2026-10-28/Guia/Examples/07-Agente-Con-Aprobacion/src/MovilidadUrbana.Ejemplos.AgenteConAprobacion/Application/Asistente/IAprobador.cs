namespace MovilidadUrbana.Ejemplos.AgenteConAprobacion.Application.Asistente;

/// <summary>Quien le pregunta a la persona (consola, pantalla). <c>null</c> = no contestó.</summary>
public interface IAprobador
{
    Task<bool?> PreguntarAsync(AprobacionPendiente pendiente, CancellationToken ct);
}

public static class Aprobacion
{
    /// <summary>
    /// La decisión es explícita: sin respuesta, o si vence el plazo, es «no». Nunca hay un
    /// <c>aprobado = true</c> cableado.
    /// </summary>
    public static async Task<bool> PedirAprobacionAsync(
        AprobacionPendiente pendiente, IAprobador aprobador, TimeSpan plazo, CancellationToken ct = default)
    {
        using var limite = CancellationTokenSource.CreateLinkedTokenSource(ct);
        limite.CancelAfter(plazo);
        try
        {
            return await aprobador.PreguntarAsync(pendiente, limite.Token) ?? false; // sin respuesta = no
        }
        catch (OperationCanceledException) when (!ct.IsCancellationRequested)
        {
            return false; // venció el plazo = no
        }
    }
}
