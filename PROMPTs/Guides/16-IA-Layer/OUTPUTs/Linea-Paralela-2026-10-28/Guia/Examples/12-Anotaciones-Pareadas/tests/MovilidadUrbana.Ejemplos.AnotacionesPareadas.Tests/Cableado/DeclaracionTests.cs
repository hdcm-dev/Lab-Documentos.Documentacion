using System.Text.Json.Nodes;
using Microsoft.Extensions.AI;
using Microsoft.SemanticKernel;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.AnotacionesPareadas.Tests.Cableado;

/// <summary>
/// Lo que ve el modelo: nombre, descripción y esquema de parámetros de cada variante. Las dos se escribieron
/// con el mismo nombre y los mismos textos; las pruebas fijan en qué coinciden y en qué no, con SK 1.81.0
/// y MEAI 10.11.0.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class DeclaracionTests
{
    [Test]
    public void LasDosSonAIFunction_ConLaMismaDescripcion()
    {
        var a = new Armado();
        KernelFunction kf = a.FuncionSk;
        AIFunction sk = kf;            // KernelFunction deriva de AIFunction
        AIFunction maf = a.FuncionMaf;

        TestContext.Out.WriteLine($"SK : {sk.GetType().Name} | KernelFunction.Name «{kf.Name}» | AIFunction.Name «{sk.Name}» | PluginName «{kf.PluginName}»");
        TestContext.Out.WriteLine($"MAF: {maf.GetType().Name} | AIFunction.Name «{maf.Name}»");

        Assert.That(sk.Description, Is.EqualTo(maf.Description));
        Assert.That(maf.Name, Is.EqualTo("resultados_por_medio"));
    }

    [Test]
    public void ElNombreQueVeElModelo_LlevaElPrefijoDelPluginEnSemanticKernel()
    {
        var a = new Armado();
        AIFunction sk = a.FuncionSk;
        Assert.That(a.FuncionSk.Name, Is.EqualTo("resultados_por_medio"), "nombre de la función dentro del plugin");
        Assert.That(sk.Name, Is.EqualTo("Encuesta_resultados_por_medio"), "nombre como AIFunction: plugin_función");
        Assert.That(a.FuncionMaf.Name, Is.EqualTo("resultados_por_medio"));
    }

    [Test]
    public void ElEsquemaDeParametros_CoincideEnNombresYDescripciones_NoEnTipos()
    {
        var a = new Armado();
        var sk = JsonNode.Parse(a.FuncionSk.JsonSchema.GetRawText())!.AsObject();
        var maf = JsonNode.Parse(a.FuncionMaf.JsonSchema.GetRawText())!.AsObject();
        TestContext.Out.WriteLine($"SK : {sk.ToJsonString()}");
        TestContext.Out.WriteLine($"MAF: {maf.ToJsonString()}");

        var propsSk = sk["properties"]!.AsObject();
        var propsMaf = maf["properties"]!.AsObject();
        Assert.That(propsSk.Select(p => p.Key), Is.EqualTo(propsMaf.Select(p => p.Key)));
        Assert.That(propsSk["localidad"]!["description"]!.GetValue<string>(), Is.EqualTo(propsMaf["localidad"]!["description"]!.GetValue<string>()));
        Assert.That(sk.ContainsKey("required") || maf.ContainsKey("required"), Is.False, "ninguna marca a localidad como obligatoria");

        // Lo que difiere, medido:
        Assert.That(propsSk["localidad"]!["type"]!.ToJsonString(), Is.EqualTo("\"string\""));
        Assert.That(propsMaf["localidad"]!["type"]!.ToJsonString(), Is.EqualTo("[\"string\",\"null\"]"));
        Assert.That(propsMaf["localidad"]!.AsObject().ContainsKey("default"), Is.True);
        Assert.That(propsSk["localidad"]!.AsObject().ContainsKey("default"), Is.False);
        Assert.That(sk.ContainsKey("condition"), Is.True, "SK suma «condition» con la descripción de la función");
        Assert.That(maf.ContainsKey("condition"), Is.False);
        Assert.That(JsonNode.DeepEquals(sk, maf), Is.False);
    }
}
