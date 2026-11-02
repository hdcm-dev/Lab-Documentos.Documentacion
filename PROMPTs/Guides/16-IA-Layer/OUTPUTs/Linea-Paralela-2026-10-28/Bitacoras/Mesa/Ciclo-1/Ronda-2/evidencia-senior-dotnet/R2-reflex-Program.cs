using System.Reflection;
void Dump(Type t, string filtro = "")
{
    Console.WriteLine($"== {t.FullName} : {t.BaseType?.Name} [{string.Join(",", t.GetCustomAttributes(false).Select(a => a.GetType().Name))}]");
    foreach (var m in t.GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
    {
        if (m is MethodInfo mi && mi.IsSpecialName) continue;
        var s = m switch {
            PropertyInfo p => $"P {p.PropertyType.Name} {p.Name} [{string.Join(",", p.GetCustomAttributes(true).Select(a => a.GetType().Name))}]",
            MethodInfo mi2 => $"M {mi2.ReturnType.Name} {mi2.Name}({string.Join(", ", mi2.GetParameters().Select(x => x.ParameterType.Name + " " + x.Name))})",
            ConstructorInfo c => $"C ({string.Join(", ", c.GetParameters().Select(x => x.ParameterType.Name + " " + x.Name))})",
            _ => null };
        if (s != null && s.Contains(filtro)) Console.WriteLine("   " + s);
    }
}
var osh = typeof(OllamaSharp.OllamaApiClient).Assembly;
Console.WriteLine($"# OllamaSharp {osh.GetName().Version}; MCP {typeof(ModelContextProtocol.Server.McpServerTool).Assembly.GetName().Version}; MCP.AspNetCore {typeof(Microsoft.AspNetCore.Builder.McpEndpointRouteBuilderExtensions).Assembly.GetName().Version}");
foreach (var n in new[]{"OllamaSharp.Models.OllamaRequest","OllamaSharp.Models.Chat.ChatRequest","OllamaSharp.Models.Chat.ChatDoneResponseStream","OllamaSharp.Models.RequestOptions","OllamaSharp.OllamaApiClient","OllamaSharp.Models.EmbedRequest"})
{ var t = osh.GetType(n); if (t is null) Console.WriteLine("NO " + n); else Dump(t); }
foreach (var t in osh.GetTypes().Where(t => t.IsPublic && t.Name.Contains("Done"))) Console.WriteLine("tipo Done: " + t.FullName);
Dump(typeof(ModelContextProtocol.Server.McpServerTool));
Dump(typeof(Microsoft.AspNetCore.Builder.McpEndpointRouteBuilderExtensions));
var mcp = typeof(ModelContextProtocol.Server.McpServerTool).Assembly;
foreach (var t in mcp.GetTypes().Where(t => t.IsPublic && t.Name.EndsWith("Extensions"))) Dump(t);
foreach (var t in typeof(Microsoft.AspNetCore.Builder.McpEndpointRouteBuilderExtensions).Assembly.GetTypes().Where(t => t.IsPublic)) Console.WriteLine("aspnet tipo: " + t.FullName);
var hto = typeof(Microsoft.AspNetCore.Builder.McpEndpointRouteBuilderExtensions).Assembly.GetTypes().FirstOrDefault(t => t.Name == "HttpServerTransportOptions"); if (hto != null) Dump(hto);
Dump(typeof(Microsoft.Extensions.AI.AIFunctionFactory));
Dump(typeof(Microsoft.Extensions.AI.AIFunctionFactoryOptions));
