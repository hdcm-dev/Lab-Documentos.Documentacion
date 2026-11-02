using System.Reflection;
foreach (var asm in new[]{typeof(Microsoft.Extensions.AI.AIContent).Assembly, typeof(Microsoft.Extensions.AI.FunctionInvokingChatClient).Assembly, typeof(Microsoft.Agents.AI.AIAgent).Assembly})
foreach (var t in asm.GetExportedTypes().Where(t=>t.Name.Contains("Approval")))
{
  Console.WriteLine($"== {t.FullName} : {t.BaseType?.Name}");
  foreach (var c in t.GetConstructors()) Console.WriteLine("  ctor(" + string.Join(", ", c.GetParameters().Select(p=>p.ParameterType.Name+" "+p.Name))+")");
  foreach (var p in t.GetProperties(BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly)) Console.WriteLine($"  prop {p.PropertyType.Name} {p.Name} {(p.CanWrite?"set":"")}");
  foreach (var m in t.GetMethods(BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly).Where(m=>!m.IsSpecialName)) Console.WriteLine($"  m {m.ReturnType.Name} {m.Name}(" + string.Join(", ", m.GetParameters().Select(p=>p.ParameterType.Name+" "+p.Name))+")");
}
