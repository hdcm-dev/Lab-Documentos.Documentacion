using System.ComponentModel;
using Microsoft.Extensions.AI;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.ApiWeb.Domain;

namespace MovilidadUrbana.PruebaDeArquitectura.Presentation.Herramientas;

/// <summary>
/// Adaptador de entrada: expone un caso de uso como herramienta del modelo, como un controlador lo expone
/// por HTTP. Conoce <see cref="AIFunction" /> (es su protocolo) pero no el proveedor ni la persistencia.
/// </summary>
public sealed class HerramientasDeLectura(LocalidadService localidades)
{
    public IReadOnlyList<AIFunction> Catalogo() =>
        [AIFunctionFactory.Create(ContarLocalidadesAsync, "contar_localidades")];

    [Description("Cuenta las localidades de la sesión; si se indica una provincia del catálogo, sólo las de esa provincia.")]
    private async Task<int> ContarLocalidadesAsync(
        [Description("Provincia del catálogo, o vacío para todas.")] string? provincia,
        CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(provincia) && !Catalogos.Provincias.Contains(provincia))
            throw new ArgumentException($"«{provincia}» no es una provincia del catálogo.", nameof(provincia));

        var todas = await localidades.GetAllAsync(cancellationToken);
        return string.IsNullOrWhiteSpace(provincia) ? todas.Count : todas.Count(l => l.Provincia == provincia);
    }
}
