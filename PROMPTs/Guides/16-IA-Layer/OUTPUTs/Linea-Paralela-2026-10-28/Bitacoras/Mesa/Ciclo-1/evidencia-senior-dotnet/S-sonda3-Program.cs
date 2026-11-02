// Sonda 3 Senior .NET (2026-10-28): ¿por dónde se fija num_ctx desde .NET con OllamaSharp 5.5.0? (reflexión, sin modelo)
using System.Reflection;
var asm = typeof(OllamaSharp.OllamaApiClient).Assembly;
var req = asm.GetType("OllamaSharp.Models.Chat.ChatRequest")!;
Console.WriteLine($"ChatRequest.Options : {req.GetProperty("Options")?.PropertyType.FullName}");
var opt = req.GetProperty("Options")!.PropertyType;
Console.WriteLine($"{opt.Name}.NumCtx : {opt.GetProperty("NumCtx")?.PropertyType}");
foreach (var t in asm.GetTypes().Where(t => t.Name.Contains("AbstractionMapper")))
    Console.WriteLine($"mapper: {t.FullName}; métodos: {string.Join(", ", t.GetMethods(BindingFlags.Static|BindingFlags.Public|BindingFlags.NonPublic).Select(m => m.Name).Distinct().Where(n => n.Contains("Option") || n.Contains("Chat")).Take(12))}");
var oo = asm.GetType("OllamaSharp.Models.OllamaOption");
Console.WriteLine($"OllamaOption.NumCtx: {oo?.GetProperty("NumCtx", BindingFlags.Static|BindingFlags.Public)?.GetValue(null)}");
