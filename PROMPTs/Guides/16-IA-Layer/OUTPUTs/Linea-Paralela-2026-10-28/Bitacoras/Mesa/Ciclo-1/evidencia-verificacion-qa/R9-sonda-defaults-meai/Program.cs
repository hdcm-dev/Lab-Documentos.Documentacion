using Microsoft.Extensions.AI;
var f = new FunctionInvokingChatClient(new Nulo());
Console.WriteLine($"MEAI {typeof(FunctionInvokingChatClient).Assembly.GetName().Version}");
Console.WriteLine($"MaximumIterationsPerRequest={f.MaximumIterationsPerRequest}");
Console.WriteLine($"MaximumConsecutiveErrorsPerRequest={f.MaximumConsecutiveErrorsPerRequest}");
Console.WriteLine($"TerminateOnUnknownCalls={f.TerminateOnUnknownCalls}");
Console.WriteLine($"ChatOptions.Reasoning existe={typeof(ChatOptions).GetProperty("Reasoning") is not null}");
Console.WriteLine($"ReasoningEffort.None existe={Enum.GetNames(typeof(ReasoningEffort)).Contains("None")} valores={string.Join(",",Enum.GetNames(typeof(ReasoningEffort)))}");
sealed class Nulo : IChatClient {
  public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> m, ChatOptions? o = null, CancellationToken c = default) => Task.FromResult(new ChatResponse());
  public IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> m, ChatOptions? o = null, CancellationToken c = default) => throw new NotImplementedException();
  public object? GetService(Type t, object? k = null) => null; public void Dispose() {}
}
