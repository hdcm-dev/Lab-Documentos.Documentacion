using System.ComponentModel;
using System.Reflection;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.Asistente.Application.Encuestas;
using MovilidadUrbana.Asistente.Application.Normalizacion;

namespace MovilidadUrbana.Asistente.Infrastructure.AI;

/// <summary>
/// Herramientas que ve el modelo: adaptadores de entrada finos sobre casos de uso, todas de sólo lectura.
/// Se crean por invocación con los servicios del ámbito del pedido (<c>AIFunctionArguments.Services</c>),
/// así que leen la sesión de ese pedido. No tienen parámetro de sesión: la sesión no la elige el modelo.
/// </summary>
public sealed class HerramientasDeLectura(
    LocalidadService localidades,
    ResultadosDeEncuestaService resultados,
    IOptions<OpcionesDeIA> opciones)
{
    private int Largo => opciones.Value.LargoMaximoDeEntrada;

    [Description("Lista las localidades cargadas por la persona: id, nombre, provincia, código postal y habitantes.")]
    public async Task<string> ListarLocalidadesAsync(CancellationToken cancellationToken)
    {
        var lista = await localidades.GetAllAsync(cancellationToken);
        return ContenidoExterno.Envolver(
            lista.Select(l => new { l.Id, l.Nombre, l.Provincia, l.CodigoPostal, l.Habitantes }), Largo);
    }

    [Description("Cuenta las localidades cargadas por la persona. Si se indica una provincia del catálogo, cuenta sólo las de esa provincia.")]
    public async Task<string> ContarLocalidadesAsync(
        [Description("Provincia del catálogo. Opcional.")] string? provincia,
        CancellationToken cancellationToken)
    {
        var lista = await localidades.GetAllAsync(cancellationToken);
        if (string.IsNullOrWhiteSpace(provincia))
            return ContenidoExterno.Envolver(new { cantidad = lista.Count }, Largo);

        var normalizada = NormalizadorDeCatalogos.Provincia(provincia);
        return normalizada is null
            ? ContenidoExterno.Envolver(new { error = $"La provincia «{provincia}» no está en el catálogo." }, Largo)
            : ContenidoExterno.Envolver(new { provincia = normalizada, cantidad = lista.Count(l => l.Provincia == normalizada) }, Largo);
    }

    [Description("Resultados agregados de la encuesta de transporte de la persona: total y conteos por medio, por motivo y por localidad. No incluye datos de quienes respondieron.")]
    public async Task<string> ResultadosDeEncuestaAsync(CancellationToken cancellationToken) =>
        ContenidoExterno.Envolver(await resultados.ResumirAsync(cancellationToken), Largo);
}

/// <summary>
/// Catálogo único y cerrado de herramientas. No hay herramientas de escritura: un alta o una baja la
/// propone el modelo como <c>AccionPropuesta</c> y la ejecuta la persona con la operación normal.
/// </summary>
public static class CatalogoDeHerramientas
{
    public const string ListarLocalidades = "listar_localidades";
    public const string ContarLocalidades = "contar_localidades";
    public const string ResultadosDeEncuesta = "resultados_de_encuesta";

    public static IReadOnlyList<AIFunction> Todas { get; } =
    [
        Crear(nameof(HerramientasDeLectura.ListarLocalidadesAsync), ListarLocalidades),
        Crear(nameof(HerramientasDeLectura.ContarLocalidadesAsync), ContarLocalidades),
        Crear(nameof(HerramientasDeLectura.ResultadosDeEncuestaAsync), ResultadosDeEncuesta)
    ];

    private static AIFunction Crear(string metodo, string nombre) =>
        AIFunctionFactory.Create(
            typeof(HerramientasDeLectura).GetMethod(metodo, BindingFlags.Public | BindingFlags.Instance)!,
            args => ActivatorUtilities.CreateInstance<HerramientasDeLectura>(
                args.Services ?? throw new InvalidOperationException("La herramienta necesita los servicios del ámbito.")),
            new AIFunctionFactoryOptions { Name = nombre });
}
