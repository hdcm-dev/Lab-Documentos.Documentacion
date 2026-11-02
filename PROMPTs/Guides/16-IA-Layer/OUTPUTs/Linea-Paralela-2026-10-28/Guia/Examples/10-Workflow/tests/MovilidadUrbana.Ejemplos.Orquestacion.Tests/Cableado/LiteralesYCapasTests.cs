using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using MovilidadUrbana.Ejemplos.Orquestacion.Application.Altas;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.Orquestacion.Tests.Cableado;

[TestFixture, Category("Cableado")]
public sealed class LiteralesYCapasTests
{
    private static readonly Regex Prohibidos = new(
        @"localhost:\d+|:11434|qwen|\b(4096|8192|16384)\b|From(Seconds|Minutes)\(\s*\d|""num_ctx""\]\s*=\s*\d",
        RegexOptions.IgnoreCase);

    private static string CarpetaDeLaApp([CallerFilePath] string archivo = "") =>
        Path.GetFullPath(Path.Combine(Path.GetDirectoryName(archivo)!, "..", "..", "..", "src"));

    /// <summary>En src/, ningún endpoint, modelo, num_ctx ni timeout literal fuera de OpcionesDeIA y los appsettings.</summary>
    [Test]
    public void NingunLiteralDeConfiguracionFueraDeOpciones()
    {
        var raiz = CarpetaDeLaApp();
        var sep = Path.DirectorySeparatorChar;
        var archivos = Directory.EnumerateFiles(raiz, "*.cs", SearchOption.AllDirectories)
            .Where(a => !a.Contains($"{sep}bin{sep}") && !a.Contains($"{sep}obj{sep}") && Path.GetFileName(a) != "OpcionesDeIA.cs")
            .ToList();
        var hallados = archivos
            .SelectMany(a => File.ReadLines(a).Select((linea, i) => (a, i + 1, linea)))
            .Where(t => Prohibidos.IsMatch(t.linea))
            .Select(t => $"{Path.GetRelativePath(raiz, t.a)}:{t.Item2}: {t.linea.Trim()}")
            .ToList();
        TestContext.Out.WriteLine($"archivos .cs revisados: {archivos.Count}; literales fuera de opciones: {hallados.Count}");
        foreach (var h in hallados) TestContext.Out.WriteLine(h);
        Assert.That(archivos, Is.Not.Empty);
        Assert.That(hallados, Is.Empty);
    }

    [TestCase("IChatClient c = new OllamaApiClient(new Uri(\"http://localhost:11434\"), \"qwen3.5:4b\");")]
    [TestCase("http.Timeout = TimeSpan.FromSeconds(300);")]
    public void ElPatronDetectaUnLiteral(string linea) => Assert.That(Prohibidos.IsMatch(linea), Is.True);

    /// <summary>Application (núcleo) no nombra tipos de Microsoft.Extensions.AI, OllamaSharp ni Agent Framework.</summary>
    [Test]
    public void ApplicationNoConoceLaCapaDeIA()
    {
        var prohibidos = new[] { "Microsoft.Extensions.AI", "OllamaSharp", "Microsoft.Agents" };
        var tipos = typeof(RevisorDeAlta).Assembly.GetTypes()
            .Where(t => t.Namespace?.StartsWith("MovilidadUrbana.Ejemplos.Orquestacion.Application") == true)
            .ToList();
        const BindingFlags todo = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
        var usados = tipos.SelectMany(t =>
                t.GetFields(todo).Select(f => f.FieldType)
                .Concat(t.GetProperties(todo).Select(p => p.PropertyType))
                .Concat(t.GetMethods(todo).SelectMany(m => m.GetParameters().Select(p => p.ParameterType).Append(m.ReturnType)))
                .Concat(t.GetConstructors(todo).SelectMany(c => c.GetParameters().Select(p => p.ParameterType)))
                .Select(u => (t, u)))
            .Where(x => prohibidos.Any(p => x.u.FullName?.Contains(p) == true || x.u.GenericTypeArguments.Any(g => g.FullName?.Contains(p) == true)))
            .Select(x => $"{x.t.Name} → {x.u.FullName}")
            .ToList();
        TestContext.Out.WriteLine($"tipos de Application revisados: {tipos.Count}; referencias a la capa de IA: {usados.Count}");
        Assert.That(tipos, Is.Not.Empty);
        Assert.That(usados, Is.Empty);
    }
}
