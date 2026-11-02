using System.Text.Json;
using Microsoft.Extensions.AI;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.AnotacionesPareadas.Tests.Cableado;

/// <summary>Con los mismos argumentos, las dos variantes llaman al mismo caso de uso y devuelven lo mismo.</summary>
[TestFixture, Category("Cableado")]
public sealed class InvocacionTests
{
    [TestCase("Corrientes")]
    [TestCase("resistencia")]
    [TestCase(null)]
    [TestCase("Goya")]
    public async Task MismosArgumentos_MismoResultado(string? localidad)
    {
        var a = new Armado();
        var argumentos = new AIFunctionArguments(new Dictionary<string, object?> { ["localidad"] = localidad });

        var sk = Json(await a.FuncionSk.InvokeAsync(argumentos));
        var lecturasSk = a.Almacen.Lecturas;
        var maf = Json(await a.FuncionMaf.InvokeAsync(argumentos));

        TestContext.Out.WriteLine($"SK : {sk}");
        TestContext.Out.WriteLine($"MAF: {maf}");
        Assert.That(sk, Is.EqualTo(maf));
        Assert.That(lecturasSk, Is.EqualTo(1));
        Assert.That(a.Almacen.Lecturas, Is.EqualTo(2));
    }

    [Test]
    public async Task ElResultadoNoTraeDatosDeLaPersona()
    {
        var a = new Armado();
        var json = Json(await a.FuncionMaf.InvokeAsync(new AIFunctionArguments()));
        Assert.That(json, Does.Not.Contain("Persona de ejemplo"));
        Assert.That(json, Does.Not.Contain("Nombre").And.Not.Contain("Edad"));
    }

    private static string Json(object? valor) => valor is JsonElement e ? e.GetRawText() : JsonSerializer.Serialize(valor);
}
