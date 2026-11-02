using System.Reflection;
using Microsoft.Extensions.AI;
foreach (var m in typeof(ChatClientBuilderServiceCollectionExtensions).GetMethods(BindingFlags.Public|BindingFlags.Static).Where(m=>m.Name.StartsWith("Add")))
  Console.WriteLine("AddChatClient: " + string.Join(", ", m.GetParameters().Select(p=>$"{p.ParameterType.Name} {p.Name}{(p.HasDefaultValue? "="+p.DefaultValue:"")}")));
Console.WriteLine("AIFunctionArguments props: " + string.Join(", ", typeof(AIFunctionArguments).GetProperties().Select(p=>p.Name)));
Console.WriteLine("FunctionInvokingChatClient props: " + string.Join(", ", typeof(FunctionInvokingChatClient).GetProperties().Select(p=>p.Name)));
Console.WriteLine("AIFunctionFactoryOptions props: " + string.Join(", ", typeof(AIFunctionFactoryOptions).GetProperties().Select(p=>p.Name)));
var ap = typeof(AIFunction).Assembly.GetType("Microsoft.Extensions.AI.ApprovalRequiredAIFunction");
Console.WriteLine("ApprovalRequiredAIFunction experimental: " + string.Join(",", ap!.GetCustomAttributesData().Select(a=>a.AttributeType.Name+"("+string.Join(",",a.ConstructorArguments.Select(c=>c.Value))+")")));
Console.WriteLine("Approval types: " + string.Join(", ", typeof(AIFunction).Assembly.GetExportedTypes().Where(t=>t.Name.Contains("Approval")).Select(t=>t.Name)));
