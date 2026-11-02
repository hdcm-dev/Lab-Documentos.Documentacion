using System.Reflection;
using System.Text.Json;
using Microsoft.Extensions.AI;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Herramientas;
using NUnit.Framework;

namespace MovilidadUrbana.Ejemplos.Mcp.Tests.Cableado;

/// <summary>
/// El catálogo único y su filtro, por reflexión y por nombre: lo que MCP publica es de lectura, no recibe la
/// sesión como parámetro y no devuelve campos de la persona ni el identificador de sesión.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class CatalogoTests
{
    /// <summary>Lista cerrada declarada EN LA PRUEBA: agregar una herramienta publicada sin tocarla hace fallar.</summary>
    private static readonly string[] PublicadasEsperadas = ["contar_localidades_por_provincia", "listar_localidades"];

    [Test]
    public void LoPublicado_PorNombre_EsLaListaCerrada()
    {
        var nombres = CatalogoDeHerramientas.DeLectura().Select(f => f.Name);
        Assert.That(nombres, Is.EquivalentTo(PublicadasEsperadas));
    }

    [Test]
    public void ElCatalogoTieneUnaEscritura_YElFiltroLaDeja()
    {
        var catalogo = CatalogoDeHerramientas.Crear();
        var borrar = catalogo.Single(f => f.Name == HerramientasDeLocalidades.Borrar);
        Assert.That(borrar, Is.InstanceOf<ApprovalRequiredAIFunction>());
        Assert.That(CatalogoDeHerramientas.EsDeLectura(borrar), Is.False);
        Assert.That(CatalogoDeHerramientas.DeLectura().Select(f => f.Name), Does.Not.Contain(HerramientasDeLocalidades.Borrar));
    }

    [Test]
    public void LoPublicado_PorReflexion_EsDeLectura_YNingunoPideAprobacion()
    {
        foreach (var f in CatalogoDeHerramientas.DeLectura())
        {
            Assert.That(f.GetService<ApprovalRequiredAIFunction>(), Is.Null, f.Name);
            Assert.That(f.UnderlyingMethod!.GetCustomAttribute<HerramientaDeLecturaAttribute>(), Is.Not.Null, f.Name);
            Assert.That(f.UnderlyingMethod!.GetCustomAttribute<HerramientaDeEscrituraAttribute>(), Is.Null, f.Name);
        }
    }

    [Test]
    public void CadaMetodoDelAdaptador_EstaMarcadoComoLecturaOEscritura()
    {
        var metodos = typeof(HerramientasDeLocalidades).GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        foreach (var m in metodos)
            Assert.That(m.IsDefined(typeof(HerramientaDeLecturaAttribute)) ^ m.IsDefined(typeof(HerramientaDeEscrituraAttribute)), Is.True, m.Name);
    }

    [Test]
    public void NingunaHerramientaDelCatalogo_RecibeLaSesionComoParametro()
    {
        foreach (var f in CatalogoDeHerramientas.Crear())
        {
            foreach (var p in f.UnderlyingMethod!.GetParameters())
            {
                Assert.That(p.Name, Does.Not.Match("(?i)sesi[oó]n|session"), $"{f.Name}.{p.Name}");
                Assert.That(p.ParameterType, Is.Not.AssignableTo<ISessionContext>(), $"{f.Name}.{p.Name}");
            }
            using var esquema = JsonDocument.Parse(f.JsonSchema.GetRawText());
            var propiedades = esquema.RootElement.TryGetProperty("properties", out var ps)
                ? ps.EnumerateObject().Select(x => x.Name).ToList() : [];
            Assert.That(propiedades, Has.None.Match("(?i)sesi[oó]n|session"), f.Name);
        }
    }

    /// <summary>Campos que no pueden salir por MCP: los de la persona de la encuesta y el id de sesión.</summary>
    private static readonly string[] CamposProhibidos = ["SessionId", "Edad", "Id"];

    [Test]
    public void LoPublicado_NoDevuelveCamposDeLaPersonaNiLaSesion()
    {
        foreach (var f in CatalogoDeHerramientas.DeLectura())
        {
            var tipos = TiposAlcanzables(f.UnderlyingMethod!.ReturnType).ToList();
            TestContext.Out.WriteLine($"{f.Name}: {string.Join(", ", tipos.Select(t => t.Name))}");
            Assert.That(tipos.Where(t => t.Namespace?.EndsWith("Domain.Entities") == true), Is.Empty, f.Name);
            var propiedades = tipos.SelectMany(t => t.GetProperties()).Select(p => p.Name);
            Assert.That(propiedades.Intersect(CamposProhibidos), Is.Empty, f.Name);
            Assert.That(f.ReturnJsonSchema?.GetRawText() ?? "", Does.Not.Match("(?i)\"(sessionId|edad)\""), f.Name);
        }
    }

    [Test]
    public void LaPruebaDeCamposProhibidos_DetectaAlgo_CasoRojo()
    {
        // Si una herramienta devolviera la entidad Localidad, saldría el SessionId: la prueba lo tiene que ver.
        var tipos = TiposAlcanzables(typeof(Task<IReadOnlyList<MovilidadUrbana.ApiWeb.Domain.Entities.Localidad>>)).ToList();
        Assert.That(tipos.SelectMany(t => t.GetProperties()).Select(p => p.Name), Has.Member("SessionId"));
    }

    private static IEnumerable<Type> TiposAlcanzables(Type raiz)
    {
        var vistos = new HashSet<Type>();
        var pendientes = new Stack<Type>([raiz]);
        while (pendientes.Count > 0)
        {
            var t = pendientes.Pop();
            if (!vistos.Add(t)) continue;
            foreach (var g in t.IsGenericType ? t.GetGenericArguments() : []) pendientes.Push(g);
            if (t.IsArray) pendientes.Push(t.GetElementType()!);
            if (t.Namespace?.StartsWith("MovilidadUrbana") == true)
                foreach (var p in t.GetProperties()) pendientes.Push(p.PropertyType);
        }
        return vistos.Where(t => t.Namespace?.StartsWith("MovilidadUrbana") == true);
    }

    [Test]
    public void SessionContextDelCasoBase_EsElQueUsaElServidor()
    {
        // La sesión del servidor es la clase real copiada del caso base, no un doble.
        Assert.That(typeof(SessionContext).Assembly, Is.EqualTo(typeof(CatalogoDeHerramientas).Assembly));
        Assert.That(typeof(SessionContext).Namespace, Is.EqualTo("MovilidadUrbana.ApiWeb.Infrastructure.Sessions"));
    }
}
