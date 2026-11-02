using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.ChatBasico.Tests.Cableado;

/// <summary>En el código de la app (src/), ningún endpoint, modelo, num_ctx ni timeout literal fuera de OpcionesDeIA y los appsettings.</summary>
[TestFixture, Category("Cableado")]
public sealed class LiteralesTests
{
    private static readonly Regex Prohibidos = new(
        @"localhost:\d+|:11434|qwen|\b(4096|8192|16384)\b|From(Seconds|Minutes)\(\s*\d|""num_ctx""\]\s*=\s*\d",
        RegexOptions.IgnoreCase);

    private static string CarpetaDeLaApp([CallerFilePath] string archivo = "") =>
        Path.GetFullPath(Path.Combine(Path.GetDirectoryName(archivo)!, "..", "..", "..", "src"));

    [Test]
    public void NingunLiteralDeConfiguracionFueraDeOpciones()
    {
        var raiz = CarpetaDeLaApp();
        var archivos = Directory.EnumerateFiles(raiz, "*.cs", SearchOption.AllDirectories)
            .Where(a => !a.Contains($"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}")
                     && !a.Contains($"{Path.DirectorySeparatorChar}obj{Path.DirectorySeparatorChar}")
                     && Path.GetFileName(a) != "OpcionesDeIA.cs")
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

    // Caso rojo: el patrón detecta lo que tiene que detectar.
    [TestCase("IChatClient c = new OllamaApiClient(new Uri(\"http://localhost:11434\"), \"qwen3.5:4b\");")]
    [TestCase("opciones.AdditionalProperties[\"num_ctx\"] = 8192;")]
    [TestCase("http.Timeout = TimeSpan.FromSeconds(300);")]
    public void ElPatronDetectaUnLiteral(string linea) => Assert.That(Prohibidos.IsMatch(linea), Is.True);
}
