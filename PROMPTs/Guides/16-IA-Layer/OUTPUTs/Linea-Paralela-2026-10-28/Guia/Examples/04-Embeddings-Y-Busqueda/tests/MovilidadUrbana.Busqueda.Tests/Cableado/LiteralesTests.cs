using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace MovilidadUrbana.Busqueda.Tests.Cableado;

/// <summary>En src/, ningún endpoint, modelo ni timeout literal fuera de OpcionesDeIA y los appsettings.</summary>
[TestFixture, Category("Cableado")]
public sealed class LiteralesTests
{
    private static readonly Regex Prohibidos = new(
        @"localhost:\d+|:11434|qwen|embed-text|minilm|From(Seconds|Minutes)\(\s*\d", RegexOptions.IgnoreCase);

    private static string CarpetaDeLaApp([CallerFilePath] string archivo = "") =>
        Path.GetFullPath(Path.Combine(Path.GetDirectoryName(archivo)!, "..", "..", "..", "src"));

    [Test]
    public void NingunLiteralDeConfiguracionFueraDeOpciones()
    {
        var sep = Path.DirectorySeparatorChar;
        var archivos = Directory.EnumerateFiles(CarpetaDeLaApp(), "*.cs", SearchOption.AllDirectories)
            .Where(a => !a.Contains($"{sep}bin{sep}") && !a.Contains($"{sep}obj{sep}") && Path.GetFileName(a) != "OpcionesDeIA.cs")
            .ToList();
        var hallados = archivos
            .SelectMany(a => File.ReadLines(a).Select((linea, i) => $"{Path.GetFileName(a)}:{i + 1}: {linea.Trim()}"))
            .Where(l => Prohibidos.IsMatch(l))
            .ToList();
        foreach (var h in hallados) TestContext.Out.WriteLine(h);
        Assert.That(archivos, Is.Not.Empty);
        Assert.That(hallados, Is.Empty);
    }

    [Test]
    public void ElPatronDetectaLoQueTieneQueDetectar() =>
        Assert.That(Prohibidos.IsMatch("new OllamaApiClient(endpoint, \"qwen3-embedding:0.6b\")"), Is.True);
}
