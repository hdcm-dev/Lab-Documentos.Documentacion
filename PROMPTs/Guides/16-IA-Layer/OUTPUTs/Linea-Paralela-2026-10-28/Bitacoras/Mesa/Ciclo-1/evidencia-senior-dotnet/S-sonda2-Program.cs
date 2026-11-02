// Sonda 2 Senior .NET (2026-10-28): ¿qué piezas que la guía enseña por defecto llevan [Experimental]?
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
static string Exp(MemberInfo? m) => m is null ? "NO ENCONTRADO" : (m.GetCustomAttributesData().FirstOrDefault(a => a.AttributeType.Name == "ExperimentalAttribute") is { } a ? $"[Experimental(\"{a.ConstructorArguments[0].Value}\")]" : "sin [Experimental]");
var asmMeai = typeof(IChatClient).Assembly; var asmMeaiImpl = typeof(FunctionInvokingChatClient).Assembly; var asmMaf = typeof(AIAgent).Assembly; var asmMafCore = typeof(ChatClientAgent).Assembly;
Type? T(string n) => new[] { asmMeai, asmMeaiImpl, asmMaf, asmMafCore }.Select(a => a.GetType(n)).FirstOrDefault(t => t is not null);
foreach (var n in new[] { "Microsoft.Extensions.AI.ReasoningOptions", "Microsoft.Extensions.AI.ReasoningEffort", "Microsoft.Extensions.AI.ApprovalRequiredAIFunction", "Microsoft.Extensions.AI.ToolApprovalRequestContent", "Microsoft.Extensions.AI.ToolApprovalResponseContent", "Microsoft.Agents.AI.AIContextProvider", "Microsoft.Extensions.AI.ChatResponseFormat", "Microsoft.Extensions.AI.MessageCountingChatReducer", "Microsoft.Extensions.AI.ReducingChatClient", "Microsoft.Extensions.AI.IImageGenerator" })
    Console.WriteLine($"{n}: {Exp(T(n))}");
Console.WriteLine($"ChatOptions.Reasoning: {Exp(typeof(ChatOptions).GetProperty("Reasoning"))}");
Console.WriteLine($"ChatOptions.AllowBackgroundResponses: {Exp(typeof(ChatOptions).GetProperty("AllowBackgroundResponses"))}");
Console.WriteLine($"ChatClientAgentOptions.AIContextProviders: {Exp(typeof(ChatClientAgentOptions).GetProperty("AIContextProviders"))}");
Console.WriteLine($"FunctionInvokingChatClient.MaximumIterationsPerRequest por defecto: {new FunctionInvokingChatClient(new NullClient()).MaximumIterationsPerRequest}; MaximumConsecutiveErrorsPerRequest: {new FunctionInvokingChatClient(new NullClient()).MaximumConsecutiveErrorsPerRequest}");
sealed class NullClient : IChatClient { public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> m, ChatOptions? o = null, CancellationToken c = default) => throw new NotImplementedException(); public IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> m, ChatOptions? o = null, CancellationToken c = default) => throw new NotImplementedException(); public object? GetService(Type t, object? k = null) => null; public void Dispose() { } }
