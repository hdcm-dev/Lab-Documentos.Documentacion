using System.Text.Json;
using Microsoft.Extensions.AI;

namespace MovilidadUrbana.Ejemplos.AnotacionesPareadas.SinModelo;

/// <summary>
/// Hace de «modelo» con un guion fijo: en el primer turno pide la herramienta del guion con sus argumentos;
/// cuando recibe el resultado, lo repite como texto. Sirve para ver el cableado de los dos marcos sin un
/// servidor; no dice nada del comportamiento de un modelo.
/// Con <paramref name="usarNombreOfrecido"/> en <c>true</c> pide el nombre tal como se lo ofrecieron
/// (con el prefijo del plugin si lo hay), como haría un modelo que copia la declaración; en <c>false</c>,
/// el nombre corto del guion.
/// </summary>
public sealed class ClienteGuionado(string herramienta, IDictionary<string, object?> argumentos, bool usarNombreOfrecido = true) : IChatClient
{
    public int Llamadas { get; private set; }

    /// <summary>Herramientas que cada llamada ofreció al «modelo»: nombre y esquema de parámetros.</summary>
    public List<IReadOnlyList<(string Nombre, string Esquema)>> HerramientasOfrecidas { get; } = [];

    /// <summary>Nombre que pidió el «modelo» en su llamada a la herramienta.</summary>
    public string? NombrePedido { get; private set; }

    /// <summary>Tipo de <c>FunctionResultContent.Result</c> que le devolvió el bucle del marco.</summary>
    public Type? TipoDelResultado { get; private set; }

    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
    {
        Llamadas++;
        var ofrecidas = (options?.Tools ?? []).OfType<AIFunctionDeclaration>()
            .Select(t => (t.Name, t.JsonSchema.GetRawText())).ToList();
        HerramientasOfrecidas.Add(ofrecidas);

        var resultado = messages.SelectMany(m => m.Contents).OfType<FunctionResultContent>().LastOrDefault();
        AIContent contenido;
        if (resultado is null)
        {
            NombrePedido = usarNombreOfrecido
                ? ofrecidas.Select(o => o.Item1).FirstOrDefault(n => n == herramienta || n.EndsWith("_" + herramienta, StringComparison.Ordinal)) ?? herramienta
                : herramienta;
            contenido = new FunctionCallContent($"guion-{Llamadas}", NombrePedido, new Dictionary<string, object?>(argumentos));
        }
        else
        {
            TipoDelResultado = resultado.Result?.GetType();
            contenido = new TextContent($"(sin modelo) {Texto(resultado.Result)}");
        }
        return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, [contenido])));
    }

    private static string Texto(object? valor) => valor switch
    {
        JsonElement e => e.GetRawText(),
        string s => s,
        _ => JsonSerializer.Serialize(valor)
    };

    public IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
        => throw new NotSupportedException("El ejemplo no usa streaming.");

    public object? GetService(Type serviceType, object? serviceKey = null) => serviceType.IsInstanceOfType(this) ? this : null;

    public void Dispose() { }
}
