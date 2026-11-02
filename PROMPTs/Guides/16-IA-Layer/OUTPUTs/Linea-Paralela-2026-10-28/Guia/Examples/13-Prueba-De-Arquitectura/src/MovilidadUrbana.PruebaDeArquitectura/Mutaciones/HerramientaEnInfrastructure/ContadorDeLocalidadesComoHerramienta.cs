using MovilidadUrbana.ApiWeb.Application.Localidades;

namespace MovilidadUrbana.PruebaDeArquitectura.Infrastructure.AI.Mutantes.HerramientaEnInfrastructure;

// Caso rojo de capa: un tipo de Infrastructure/AI que toma un caso de uso para exponerlo como
// herramienta. Ese trabajo es de un adaptador de entrada (Presentation/Herramientas).
public sealed class ContadorDeLocalidadesComoHerramienta(LocalidadService localidades)
{
    public Microsoft.Extensions.AI.AIFunction Herramienta() =>
        Microsoft.Extensions.AI.AIFunctionFactory.Create(
            async (CancellationToken ct) => (await localidades.GetAllAsync(ct)).Count, "contar_localidades");
}
