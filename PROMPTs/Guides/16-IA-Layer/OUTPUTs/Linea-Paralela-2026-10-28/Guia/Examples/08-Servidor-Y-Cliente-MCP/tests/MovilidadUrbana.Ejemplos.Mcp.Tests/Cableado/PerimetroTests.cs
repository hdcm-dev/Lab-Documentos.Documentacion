using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.Mcp.Tests.Cableado;

/// <summary>
/// CTRL-13, la tabla del perímetro, sobre el servidor real (Kestrel en 127.0.0.1, puerto libre):
/// AllowedHosts (HostFiltering de WebApplication.CreateBuilder) → 400; RequireAuthorization → 401;
/// middleware de Origin → 403; pedido válido → 200.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class PerimetroTests
{
    private const string Token = Comun.TokenDeDemostracion;

    public static IEnumerable<TestCaseData> Tabla()
    {
        yield return new TestCaseData("atacante.example", Token, null, 400).SetName("Host ajeno, con token → 400");
        yield return new TestCaseData(null, null, null, 401).SetName("Sin token → 401");
        yield return new TestCaseData(null, "token-incorrecto-de-prueba", null, 401).SetName("Token incorrecto → 401");
        yield return new TestCaseData(null, Token, "http://atacante.example", 403).SetName("Origin ajeno, con token → 403");
        yield return new TestCaseData(null, null, "http://atacante.example", 403).SetName("Origin ajeno, sin token → 403 (Origin se revisa antes)");
        yield return new TestCaseData(null, Token, Comun.OrigenPermitido, 200).SetName("Origin permitido, con token → 200");
        yield return new TestCaseData(null, Token, null, 200).SetName("Sin Origin (cliente que no es navegador), con token → 200");
        yield return new TestCaseData("localhost", Token, null, 200).SetName("Host localhost, con token → 200");
    }

    [TestCaseSource(nameof(Tabla))]
    public async Task ElPerimetroResponde(string? host, string? token, string? origen, int esperado)
    {
        await using var servidor = await Comun.ServidorAsync();
        var codigo = await Comun.InitializeAsync(servidor.Endpoint, host, token, origen);
        TestContext.Out.WriteLine($"Host={host ?? "(127.0.0.1)"} token={(token is null ? "no" : token == Token ? "ok" : "malo")} Origin={origen ?? "(no)"} → {codigo}");
        Assert.That(codigo, Is.EqualTo(esperado));
    }
}
