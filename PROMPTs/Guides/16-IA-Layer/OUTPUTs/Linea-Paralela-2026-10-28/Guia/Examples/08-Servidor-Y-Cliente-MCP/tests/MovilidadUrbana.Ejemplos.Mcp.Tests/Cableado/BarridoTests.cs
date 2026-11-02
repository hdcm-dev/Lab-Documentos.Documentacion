using System.Text.RegularExpressions;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.Mcp.Tests.Cableado;

/// <summary>Barridos sobre el código del ejemplo (src/): lo que la guía promete que no aparece.</summary>
[TestFixture, Category("Cableado")]
public sealed class BarridoTests
{
    private static IEnumerable<FileInfo> Fuentes(string patron = "*.cs") =>
        new DirectoryInfo(Path.Combine(Comun.RaizDelEjemplo().FullName, "src"))
            .EnumerateFiles(patron, SearchOption.AllDirectories)
            .Where(f => !f.FullName.Contains($"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}")
                     && !f.FullName.Contains($"{Path.DirectorySeparatorChar}obj{Path.DirectorySeparatorChar}"));

    [Test]
    public void McpServerTool_ConAtributo_SoloEnElBloqueAlternativo()
    {
        var con = Fuentes().Where(f => Regex.IsMatch(File.ReadAllText(f.FullName), @"\[McpServerTool(Type)?\b")).Select(f => f.Name).ToList();
        Assert.That(con, Is.EqualTo(new[] { "HerramientasConAtributos.cs" }));
    }

    [Test]
    public void SinLiteralesDeModeloNiEndpointFueraDeLasOpciones()
    {
        var literal = new Regex(@"localhost:11434|qwen3\.5|num_ctx""\s*\]\s*=\s*\d|TimeoutSegundos\s*=\s*\d");
        var con = Fuentes().Where(f => f.Name != "OpcionesDeIA.cs" && literal.IsMatch(File.ReadAllText(f.FullName))).Select(f => f.Name).ToList();
        Assert.That(con, Is.Empty);
    }

    // Los términos se arman por partes para que este archivo no aparezca en los mismos barridos sobre el repositorio.
    [TestCase("np", "x")]
    [TestCase("Custom", "Headers")]
    [TestCase("WithToolsFrom", "Assembly")]
    [TestCase("Echo", "Tool")]
    public void NoAparece(string parte1, string parte2)
    {
        var termino = parte1 + parte2;
        var con = Fuentes().Concat(Fuentes("*.json")).Where(f => File.ReadAllText(f.FullName).Contains(termino)).Select(f => f.Name).ToList();
        Assert.That(con, Is.Empty);
    }
}
