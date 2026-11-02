using System.Reflection;
var t = typeof(ModelContextProtocol.AspNetCore.HttpServerTransportOptions);
foreach (var p in t.GetProperties()) Console.WriteLine($"{p.Name}: {p.PropertyType.Name} {string.Join(",", p.GetCustomAttributesData().Select(a => a.AttributeType.Name + "(" + string.Join(",", a.ConstructorArguments.Select(c => c.Value)) + ")"))}");
var o = new ModelContextProtocol.AspNetCore.HttpServerTransportOptions();
foreach (var p in t.GetProperties().Where(p => p.Name is "Stateless" or "SessionMode")) Console.WriteLine($"default {p.Name} = {p.GetValue(o)}");
var asm = typeof(Microsoft.Agents.AI.ChatClientAgent).Assembly;
foreach (var m in asm.GetExportedTypes().SelectMany(x => x.GetMethods(BindingFlags.Public | BindingFlags.Static)).Where(m => m.Name == "AsAIAgent"))
  Console.WriteLine($"{m.DeclaringType!.Name}.AsAIAgent({string.Join(", ", m.GetParameters().Select(p => p.ParameterType.Name + " " + p.Name))})");
