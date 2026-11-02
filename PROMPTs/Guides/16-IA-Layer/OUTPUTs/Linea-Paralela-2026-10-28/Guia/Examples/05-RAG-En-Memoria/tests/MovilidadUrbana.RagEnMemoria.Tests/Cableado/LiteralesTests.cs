using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace MovilidadUrbana.RagEnMemoria.Tests.Cableado;

/// <summary>Ningún endpoint, modelo, num_ctx ni timeout literal fuera de OpcionesDeIA y los appsettings.</summary>
public class LiteralesTests
{
    private static string Fuentes([CallerFilePath] string aca = "") =>
        Path.GetFullPath(Path.Combine(Path.GetDirectoryName(aca)!, "..", "..", "..", "src", "MovilidadUrbana.RagEnMemoria"));

    [TestCase("localhost:11434")]
    [TestCase("qwen3.5:4b")]
    [TestCase("qwen3-embedding")]
    [TestCase("8192")]
    public void ElLiteral_SoloApareceEnOpcionesYAppsettings(string literal)
    {
        var raiz = Fuentes();
        if (!Directory.Exists(raiz)) Assert.Inconclusive($"Sin las fuentes junto a la prueba: {raiz}");
        var donde = Directory.EnumerateFiles(raiz, "*.cs", SearchOption.AllDirectories)
            .Where(f => !f.Contains($"{Path.DirectorySeparatorChar}obj{Path.DirectorySeparatorChar}"))
            .Where(f => Path.GetFileName(f) != "OpcionesDeIA.cs")
            .Where(f => File.ReadAllText(f).Contains(literal, StringComparison.Ordinal))
            .Select(Path.GetFileName);
        Assert.That(donde, Is.Empty);
    }
}
