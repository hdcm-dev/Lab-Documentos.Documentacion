using System.Text.Json;
using Microsoft.Extensions.AI;

namespace MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI.Aprobaciones;

/// <summary>
/// Guarda de la herramienta de escritura, por ámbito. Sólo deja pasar UNA ejecución, y sólo de la
/// llamada exacta (herramienta y argumentos) que la persona aprobó. Defensa en profundidad: aunque la
/// sesión del agente se altere (MAF ejecuta lo que diga la sesión deserializada), la guarda compara con
/// la copia que guardó el servidor al registrar la aprobación.
/// </summary>
public sealed class AutorizacionDeEscritura
{
    private (string Herramienta, string Clave)? _habilitada;

    public int Rechazadas { get; private set; }

    public void Habilitar(string herramienta, string claveDeArgumentos) => _habilitada = (herramienta, claveDeArgumentos);

    public void Revocar() => _habilitada = null;

    /// <summary>true una sola vez, si coincide con lo aprobado.</summary>
    public bool Consumir(string herramienta, IEnumerable<KeyValuePair<string, object?>> argumentos)
    {
        var pedida = (herramienta, Clave(argumentos));
        if (_habilitada is { } h && h == pedida)
        {
            _habilitada = null;
            return true;
        }
        Rechazadas++;
        return false;
    }

    /// <summary>Forma canónica de los argumentos: JSON con las claves ordenadas.</summary>
    public static string Clave(IEnumerable<KeyValuePair<string, object?>> argumentos) =>
        JsonSerializer.Serialize(argumentos.OrderBy(a => a.Key, StringComparer.Ordinal)
            .ToDictionary(a => a.Key, a => a.Value));
}

/// <summary>Envuelve una función de escritura con la guarda. Va DENTRO de <see cref="ApprovalRequiredAIFunction"/>.</summary>
public sealed class FuncionConAutorizacion(AIFunction interna, AutorizacionDeEscritura autorizacion) : DelegatingAIFunction(interna)
{
    public const string Rechazo = "Rechazado: esta llamada no coincide con la que aprobó la persona.";

    protected override ValueTask<object?> InvokeCoreAsync(AIFunctionArguments arguments, CancellationToken cancellationToken) =>
        autorizacion.Consumir(Name, arguments)
            ? base.InvokeCoreAsync(arguments, cancellationToken)
            : ValueTask.FromResult<object?>(Rechazo);
}
