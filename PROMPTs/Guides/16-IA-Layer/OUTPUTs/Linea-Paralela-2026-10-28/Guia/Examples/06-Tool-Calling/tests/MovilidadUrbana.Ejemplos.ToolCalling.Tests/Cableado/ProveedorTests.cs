using System.Reflection;
using System.Text.Json.Nodes;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using MovilidadUrbana.Ejemplos.ToolCalling.Application.Consultas;
using MovilidadUrbana.Ejemplos.ToolCalling.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.ToolCalling.Infrastructure.Persistence;
using NUnit.Framework;
using OllamaSharp;

namespace MovilidadUrbana.Ejemplos.ToolCalling.Tests.Cableado;

/// <summary>
/// Cambiar de proveedor no cambia Application. Dos proveedores falsos (un servidor HTTP falso que habla
/// /api/chat y /v1/chat/completions) piden la misma herramienta, cada uno en su formato; la composición real
/// elige el adaptador por AI:Proveedor. Se comprueba que el caso de uso recibe lo mismo y devuelve lo mismo,
/// y que ningún tipo de Application nombra un tipo del proveedor ni de Microsoft.Extensions.AI.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class ProveedorTests
{
    private const string Pregunta = "¿Cuántas localidades hay cargadas en Chaco?";

    private static async Task<(Application.Asistente.RespuestaDelAsistente R, ServidorFalsoConHerramientas Servidor, int Lecturas, Type Cliente)> Corrida(string proveedor)
    {
        var servidor = new ServidorFalsoConHerramientas(HerramientasDeLocalidades.ContarPorProvincia, """{"provincia":"Chaco"}""");
        using var host = Configuraciones.Anfitrion(Configuraciones.Valida(proveedor), servidor: servidor);
        var cliente = host.Services.GetRequiredService<IChatClient>();
        var tipo = (cliente.GetService<OllamaApiClient>() as object ?? cliente.GetService<OpenAI.Chat.ChatClient>())!.GetType();
        var (ambito, asistente) = Configuraciones.Sesion(host, "sesion-a");
        using (ambito)
        {
            var r = await asistente.PreguntarAsync(Pregunta);
            return (r, servidor, host.Services.GetRequiredService<AlmacenEnMemoria>().Lecturas, tipo);
        }
    }

    [Test]
    public async Task DosProveedores_MismaHerramienta_MismoResultadoDelCasoDeUso()
    {
        var nativa = await Corrida(Proveedores.Ollama);
        var v1 = await Corrida(Proveedores.OpenAICompatible);

        foreach (var (nombre, c) in new[] { ("ollama", nativa), ("openai-compatible", v1) })
        {
            TestContext.Out.WriteLine($"{nombre}: cliente {c.Cliente.FullName}; rutas {string.Join(", ", c.Servidor.Pedidos.Select(p => p.Ruta))}; " +
                $"herramienta {c.R.Herramientas.Single().Nombre}({c.R.Herramientas.Single().Argumentos}) → {c.R.Herramientas.Single().Resultado}; texto «{c.R.Texto}»");
            Assert.That(c.Servidor.Pedidos, Has.Count.EqualTo(2), "pedido de herramienta + vuelta con el resultado");
            Assert.That(c.Lecturas, Is.EqualTo(1), "el caso de uso leyó una vez");
        }

        Assert.That(nativa.Servidor.Pedidos.All(p => p.Ruta == "/api/chat"));
        Assert.That(v1.Servidor.Pedidos.All(p => p.Ruta == "/v1/chat/completions"));
        Assert.That(v1.R.Herramientas.Single().Nombre, Is.EqualTo(nativa.R.Herramientas.Single().Nombre));
        Assert.That(v1.R.Herramientas.Single().Resultado, Is.EqualTo(nativa.R.Herramientas.Single().Resultado),
            "el caso de uso devolvió lo mismo por las dos vías");
        Assert.That(v1.R.Texto, Is.EqualTo(nativa.R.Texto));
    }

    [Test]
    public async Task ElResultadoDeLaHerramientaViajaAlModelo_EnElFormatoDeCadaVia()
    {
        var nativa = await Corrida(Proveedores.Ollama);
        var v1 = await Corrida(Proveedores.OpenAICompatible);
        var resultado = nativa.R.Herramientas.Single().Resultado;

        JsonObject PrimerPedido(ServidorFalsoConHerramientas s) => s.Pedidos[0].Json;
        JsonObject MensajeTool(ServidorFalsoConHerramientas s) =>
            s.Pedidos[1].Json["messages"]!.AsArray().Select(m => m!.AsObject()).Single(m => (string?)m["role"] == "tool");

        var herramientasNativa = PrimerPedido(nativa.Servidor)["tools"]!.AsArray();
        var herramientasV1 = PrimerPedido(v1.Servidor)["tools"]!.AsArray();
        var sinMensajes = PrimerPedido(v1.Servidor).DeepClone().AsObject();
        sinMensajes.Remove("messages"); sinMensajes.Remove("tools");
        TestContext.Out.WriteLine($"/api/chat: tools={herramientasNativa.Count}, options={PrimerPedido(nativa.Servidor)["options"]?.ToJsonString()}, tool={MensajeTool(nativa.Servidor).ToJsonString()}");
        TestContext.Out.WriteLine($"/v1: tools={herramientasV1.Count}, resto del cuerpo={sinMensajes.ToJsonString()}, tool={MensajeTool(v1.Servidor).ToJsonString()}");

        Assert.That(herramientasNativa.Count, Is.EqualTo(2));
        Assert.That(herramientasV1.Count, Is.EqualTo(2));
        Assert.That((int)PrimerPedido(nativa.Servidor)["options"]!["num_ctx"]!, Is.EqualTo(8192));
        Assert.That(v1.Servidor.Pedidos[0].Cuerpo, Does.Not.Contain("num_ctx"), "por /v1 no se fija num_ctx por pedido");
        // Lo que el caso de uso devolvió es lo mismo; lo que LEE el modelo, no: OllamaSharp 5.5.0 manda el
        // FunctionResultContent entero ({"CallId":…,"Result":…}) como contenido del mensaje «tool»;
        // MEAI.OpenAI manda sólo el resultado y el id va aparte, en tool_call_id.
        var contenidoNativa = JsonNode.Parse((string)MensajeTool(nativa.Servidor)["content"]!)!.AsObject();
        Assert.That(contenidoNativa.Select(p => p.Key), Is.EqualTo(new[] { "CallId", "Result" }));
        Assert.That(contenidoNativa["Result"]!.ToJsonString(), Is.EqualTo(JsonNode.Parse(resultado)!.ToJsonString()));
        Assert.That(MensajeTool(nativa.Servidor).ContainsKey("tool_call_id"), Is.False);

        Assert.That(JsonNode.Parse((string)MensajeTool(v1.Servidor)["content"]!)!.ToJsonString(), Is.EqualTo(JsonNode.Parse(resultado)!.ToJsonString()));
        Assert.That((string?)MensajeTool(v1.Servidor)["tool_call_id"], Is.EqualTo("call_1"));
        Assert.That((string?)PrimerPedido(v1.Servidor)["tool_choice"], Is.EqualTo("auto"), "ChatToolMode.Auto viaja como tool_choice por /v1");
    }

    private static readonly string[] EnsambladosDelProveedor = ["Microsoft.Extensions.AI", "OllamaSharp", "OpenAI"];

    [Test]
    public void Application_NoNombraTiposDelProveedorNiDeMEAI()
    {
        var ensamblado = typeof(ConsultaDeLocalidades).Assembly;
        var deApplication = ensamblado.GetTypes().Where(t =>
            t.Namespace is { } ns &&
            (ns.StartsWith("MovilidadUrbana.Ejemplos.ToolCalling.Application") || ns.StartsWith("MovilidadUrbana.ApiWeb.Application") || ns.StartsWith("MovilidadUrbana.ApiWeb.Domain")))
            .ToList();

        static IEnumerable<Type> Firmas(Type t)
        {
            const BindingFlags todo = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            if (t.BaseType is { } b) yield return b;
            foreach (var i in t.GetInterfaces()) yield return i;
            foreach (var f in t.GetFields(todo)) yield return f.FieldType;
            foreach (var p in t.GetProperties(todo)) yield return p.PropertyType;
            foreach (var m in t.GetMethods(todo))
            {
                yield return m.ReturnType;
                foreach (var p in m.GetParameters()) yield return p.ParameterType;
            }
            foreach (var c in t.GetConstructors(todo))
                foreach (var p in c.GetParameters()) yield return p.ParameterType;
        }

        static IEnumerable<Type> Desplegar(Type t) =>
            t.IsGenericType ? t.GetGenericArguments().SelectMany(Desplegar).Prepend(t) : t.HasElementType ? Desplegar(t.GetElementType()!) : [t];

        var violaciones = deApplication
            .SelectMany(t => Firmas(t).SelectMany(Desplegar).Select(u => (t, u)))
            .Where(x => x.u.Assembly.GetName().Name is { } a && EnsambladosDelProveedor.Any(p => a == p || a.StartsWith(p + ".")))
            .Select(x => $"{x.t.FullName} → {x.u.FullName}")
            .Distinct().ToList();

        TestContext.Out.WriteLine($"tipos de Application/Domain revisados: {deApplication.Count}; referencias a MEAI u proveedores: {violaciones.Count}");
        foreach (var v in violaciones) TestContext.Out.WriteLine(v);
        Assert.That(deApplication, Has.Count.GreaterThan(5));
        Assert.That(violaciones, Is.Empty);
    }

    // Caso rojo: el mismo recorrido detecta un tipo de MEAI en una firma.
    private sealed class PuertoMalHecho { public ChatResponse? Respuesta { get; set; } }

    [Test]
    public void CasoRojo_UnaPropiedadChatResponse_SeDetecta()
    {
        var tipo = typeof(PuertoMalHecho).GetProperty(nameof(PuertoMalHecho.Respuesta))!.PropertyType;
        var subyacente = Nullable.GetUnderlyingType(tipo) ?? tipo;
        Assert.That(EnsambladosDelProveedor.Any(p => subyacente.Assembly.GetName().Name!.StartsWith(p)), Is.True);
    }
}
