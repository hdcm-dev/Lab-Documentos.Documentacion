using System.Reflection;
using MovilidadUrbana.PruebaDeArquitectura.Application.Propuestas;

namespace MovilidadUrbana.PruebaDeArquitectura.Tests.Cableado;

/// <summary>
/// Qué es cada capa en este proyecto. El caso base es un solo ensamblado: las capas son espacios de nombres.
/// La copia conserva los suyos (<c>MovilidadUrbana.ApiWeb.*</c>); lo agregado vive en
/// <c>MovilidadUrbana.PruebaDeArquitectura.*</c>.
/// </summary>
public static class Capas
{
    public static readonly Assembly Aplicacion = typeof(IExtractorDeLocalidad).Assembly;

    public static readonly string[] Dominio = ["MovilidadUrbana.ApiWeb.Domain"];

    /// <summary>Núcleo: Domain y Application copiados, y Application agregado.</summary>
    public static readonly string[] Nucleo =
        ["MovilidadUrbana.ApiWeb.Domain", "MovilidadUrbana.ApiWeb.Application", "MovilidadUrbana.PruebaDeArquitectura.Application"];

    public static readonly string[] Infraestructura =
        ["MovilidadUrbana.ApiWeb.Infrastructure", "MovilidadUrbana.PruebaDeArquitectura.Infrastructure"];

    public static readonly string[] Persistencia = ["MovilidadUrbana.ApiWeb.Infrastructure"];

    public static readonly string[] AdaptadorDeIA = ["MovilidadUrbana.PruebaDeArquitectura.Infrastructure.AI"];

    /// <summary>Presentación: controladores y middleware del caso base, y las herramientas (adaptadores de entrada).</summary>
    public static readonly string[] Presentacion =
        ["MovilidadUrbana.ApiWeb.Controllers", "MovilidadUrbana.ApiWeb.Sessions", "MovilidadUrbana.ApiWeb.Contracts",
         "MovilidadUrbana.PruebaDeArquitectura.Presentation"];

    // Lo que viene de afuera, por familia.
    public static readonly string[] IA = ["Microsoft.Extensions.AI", "Microsoft.Agents.AI", "ModelContextProtocol", "OllamaSharp"];
    public static readonly string[] ProveedorDeIA = ["OllamaSharp"];
    public static readonly string[] AccesoADatos = ["Microsoft.EntityFrameworkCore", "Microsoft.Data.Sqlite"];
    public static readonly string[] Http = ["Microsoft.AspNetCore"];

    public static bool En(string? espacio, IEnumerable<string> raices) =>
        espacio is not null && raices.Any(r => espacio == r || espacio.StartsWith(r + ".", StringComparison.Ordinal));

    public static bool En(Type t, IEnumerable<string> raices) => En(t.Namespace, raices);

    public static IReadOnlyList<Type> TiposDe(Assembly ensamblado, IEnumerable<string> raices) =>
        ensamblado.GetTypes().Where(t => En(t, raices)).ToList();

    /// <summary>Los casos de uso: las clases <c>*Service</c> de Application y los casos de uso agregados.</summary>
    public static bool EsCasoDeUso(Type t) =>
        (En(t, ["MovilidadUrbana.ApiWeb.Application"]) && t.Name.EndsWith("Service", StringComparison.Ordinal))
        || t == typeof(ProponerLocalidadDesdeTexto);
}
