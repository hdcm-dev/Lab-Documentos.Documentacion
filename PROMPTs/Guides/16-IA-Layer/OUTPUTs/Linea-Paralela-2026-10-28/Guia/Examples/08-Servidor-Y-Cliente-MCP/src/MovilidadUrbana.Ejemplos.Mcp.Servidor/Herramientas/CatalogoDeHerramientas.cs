using System.Reflection;
using Microsoft.Extensions.AI;

namespace MovilidadUrbana.Ejemplos.Mcp.Servidor.Herramientas;

/// <summary>
/// Catálogo único: una sola definición de cada herramienta (nombre, descripción y esquema), como
/// <see cref="AIFunction"/>. La misma lista sirve al bucle de la app (<c>IChatClient</c> o un agente de MAF)
/// y, filtrada a lectura, al servidor MCP. Cada invocación crea las herramientas con los servicios del
/// ámbito que llega en <see cref="AIFunctionArguments.Services"/>: en MCP, los de la petición HTTP.
/// </summary>
public static class CatalogoDeHerramientas
{
    public static IReadOnlyList<AIFunction> Crear() =>
    [
        Desde(nameof(HerramientasDeLocalidades.ContarPorProvinciaAsync), HerramientasDeLocalidades.ContarPorProvincia),
        Desde(nameof(HerramientasDeLocalidades.ListarAsync), HerramientasDeLocalidades.Listar),
        // La escritura entra al catálogo envuelta: el bucle la ejecuta sólo con la aprobación de la persona.
        new ApprovalRequiredAIFunction(Desde(nameof(HerramientasDeLocalidades.BorrarAsync), HerramientasDeLocalidades.Borrar)),
    ];

    /// <summary>Lo que se publica por MCP: sólo las de lectura.</summary>
    public static IReadOnlyList<AIFunction> DeLectura() => [.. Crear().Where(EsDeLectura)];

    /// <summary>
    /// De lectura = el método lleva <see cref="HerramientaDeLecturaAttribute"/>, no lleva
    /// <see cref="HerramientaDeEscrituraAttribute"/> y la función no pide aprobación.
    /// </summary>
    public static bool EsDeLectura(AIFunction funcion) =>
        funcion.GetService<ApprovalRequiredAIFunction>() is null
        && funcion.UnderlyingMethod is { } metodo
        && metodo.GetCustomAttribute<HerramientaDeLecturaAttribute>() is not null
        && metodo.GetCustomAttribute<HerramientaDeEscrituraAttribute>() is null;

    private static AIFunction Desde(string metodo, string nombre) =>
        AIFunctionFactory.Create(
            typeof(HerramientasDeLocalidades).GetMethod(metodo)!,
            args => ActivatorUtilities.CreateInstance<HerramientasDeLocalidades>(
                args.Services ?? throw new InvalidOperationException("La herramienta necesita los servicios del ámbito.")),
            new AIFunctionFactoryOptions { Name = nombre });
}
