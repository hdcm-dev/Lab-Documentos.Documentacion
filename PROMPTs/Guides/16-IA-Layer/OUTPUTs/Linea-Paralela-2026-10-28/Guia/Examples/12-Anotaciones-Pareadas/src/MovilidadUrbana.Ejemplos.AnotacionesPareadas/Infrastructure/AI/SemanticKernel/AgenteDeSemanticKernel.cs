using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents;

namespace MovilidadUrbana.Ejemplos.AnotacionesPareadas.Infrastructure.AI.SemanticKernel;

/// <summary>Antes: Kernel + plugin + <c>ChatCompletionAgent</c>, sobre el mismo <c>IChatClient</c>.</summary>
public static class AgenteDeSemanticKernel
{
    public const string NombreDelPlugin = "Encuesta";

    /// <param name="conInvocacionDeFunciones">
    /// <c>false</c> sólo para la prueba roja: sin <c>UseKernelFunctionInvocation</c> el agente devuelve la llamada
    /// a la herramienta sin ejecutarla.
    /// </param>
    public static Kernel CrearKernel(IChatClient chat, ResultadosDeEncuestaPlugin herramientas, bool conInvocacionDeFunciones = true)
    {
        IChatClient cliente = conInvocacionDeFunciones
            ? chat.AsBuilder().UseKernelFunctionInvocation().Build()   // SK ejecuta las KernelFunction que pide el modelo
            : chat;

        IKernelBuilder builder = Kernel.CreateBuilder();
        builder.Services.AddSingleton(cliente);
        Kernel kernel = builder.Build();

        KernelPlugin plugin = KernelPluginFactory.CreateFromObject(herramientas, NombreDelPlugin);
        kernel.Plugins.Add(plugin);
        return kernel;
    }

    public static async Task<string> PreguntarAsync(Kernel kernel, string pregunta, CancellationToken ct = default)
    {
        ChatCompletionAgent agente = new()
        {
            Name = "AsistenteDeResultados",
            Instructions = Instrucciones.DelAsistente,
            Kernel = kernel,
            Arguments = new KernelArguments(new PromptExecutionSettings { FunctionChoiceBehavior = FunctionChoiceBehavior.Auto() })
        };
        ChatHistoryAgentThread hilo = new();

        string texto = "";
        await foreach (AgentResponseItem<ChatMessageContent> item in agente.InvokeAsync(pregunta, hilo, cancellationToken: ct))
            texto = item.Message.Content ?? "";
        return texto;
    }
}
