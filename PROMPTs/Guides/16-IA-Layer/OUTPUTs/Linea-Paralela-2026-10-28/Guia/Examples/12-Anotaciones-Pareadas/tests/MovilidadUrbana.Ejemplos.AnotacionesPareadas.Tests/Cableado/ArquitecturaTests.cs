using System.Reflection;
using MovilidadUrbana.Ejemplos.AnotacionesPareadas.Application.Resultados;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.AnotacionesPareadas.Tests.Cableado;

/// <summary>Application no nombra tipos de ningún marco de IA: migrar de SK a MAF no la toca.</summary>
[TestFixture, Category("Cableado")]
public sealed class ArquitecturaTests
{
    private static readonly string[] Prohibidos = ["Microsoft.SemanticKernel", "Microsoft.Extensions.AI", "Microsoft.Agents.AI"];

    [Test]
    public void ApplicationSinTiposDeMarcosDeIA()
    {
        var tipos = typeof(ConsultaDeResultadosPorMedio).Assembly.GetTypes()
            .Where(t => t.Namespace?.StartsWith("MovilidadUrbana.Ejemplos.AnotacionesPareadas.Application") == true)
            .ToList();
        var hallados = tipos.SelectMany(t => Usados(t).Select(u => $"{t.Name} → {u.FullName}"))
            .Where(s => Prohibidos.Any(p => s.Contains("→ " + p)))
            .ToList();

        TestContext.Out.WriteLine($"tipos de Application revisados: {tipos.Count}; con tipos de marcos de IA: {hallados.Count}");
        Assert.That(tipos, Is.Not.Empty);
        Assert.That(hallados, Is.Empty);
    }

    [Test]
    public void CasoRojo_ElAdaptadorSiNombraElMarco()
    {
        var adaptador = typeof(Infrastructure.AI.AgentFramework.HerramientasDeResultados);
        Assert.That(Usados(adaptador).Any(u => u.FullName?.StartsWith("Microsoft.Extensions.AI") == true), Is.True);
    }

    private static IEnumerable<Type> Usados(Type t)
    {
        const BindingFlags todo = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
        foreach (var f in t.GetFields(todo)) yield return f.FieldType;
        foreach (var p in t.GetProperties(todo)) yield return p.PropertyType;
        foreach (var m in t.GetMethods(todo))
        {
            yield return m.ReturnType;
            foreach (var p in m.GetParameters()) yield return p.ParameterType;
            foreach (var a in m.GetCustomAttributesData()) yield return a.AttributeType;
        }
        foreach (var c in t.GetConstructors(todo))
            foreach (var p in c.GetParameters()) yield return p.ParameterType;
        if (t.BaseType is not null) yield return t.BaseType;
        foreach (var i in t.GetInterfaces()) yield return i;
    }
}
