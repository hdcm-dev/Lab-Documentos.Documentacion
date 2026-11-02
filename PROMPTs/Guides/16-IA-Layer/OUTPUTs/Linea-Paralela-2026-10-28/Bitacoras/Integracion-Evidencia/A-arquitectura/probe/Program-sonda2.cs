using System.Reflection;
foreach (var t in typeof(Microsoft.Agents.AI.AIContextProvider).GetNestedTypes()) { Console.WriteLine("== "+t.FullName);
 foreach (var c in t.GetConstructors()) Console.WriteLine("   ctor("+string.Join(", ", c.GetParameters().Select(p=>p.ParameterType.Name+" "+p.Name))+")");
 foreach (var p in t.GetProperties()) Console.WriteLine($"   prop {p.PropertyType.Name} {p.Name}"); }
var e = Nullable.GetUnderlyingType(typeof(Microsoft.Extensions.AI.ReasoningOptions).GetProperty("Effort")!.PropertyType)!;
Console.WriteLine("Effort: " + e.FullName + " " + (e.IsEnum? string.Join(",",Enum.GetNames(e)) : string.Join(",", e.GetProperties(BindingFlags.Public|BindingFlags.Static).Select(p=>p.Name))));
var tv = typeof(OllamaSharp.Models.Chat.ThinkValue);
Console.WriteLine("ThinkValue ops: " + string.Join(",", tv.GetMethods(BindingFlags.Public|BindingFlags.Static).Select(m=>m.Name+"("+string.Join(",",m.GetParameters().Select(p=>p.ParameterType.Name))+")")));
