using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Application.Asistente;

namespace MovilidadUrbana.Ejemplos.AgenteConAprobacion;

/// <summary>Le pregunta a la persona por consola. Con <c>--aprobar s|n</c> la respuesta viene fija.</summary>
public sealed class AprobadorDeConsola(bool? respuestaFija) : IAprobador
{
    public async Task<bool?> PreguntarAsync(AprobacionPendiente pendiente, CancellationToken ct)
    {
        Console.WriteLine($"  [aprobación] {pendiente.Descripcion} (herramienta {pendiente.Herramienta}; vence {pendiente.Vence:HH:mm:ss} UTC)");
        Console.Write("  ¿Aprobás? (s/n): ");
        if (respuestaFija is { } fija)
        {
            Console.WriteLine(fija ? "s (fija por --aprobar)" : "n (fija por --aprobar)");
            return fija;
        }
        var linea = await Console.In.ReadLineAsync(ct);
        return linea?.Trim().ToLowerInvariant() switch { "s" => true, "n" => false, _ => null }; // otra cosa = sin respuesta
    }
}
