using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.AI;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Domain.Entities;

namespace Experimento;

/// <summary>Repositorio en memoria (en la demo lo reemplaza la copia de Infrastructure/Persistence con EF Core SQLite).</summary>
public sealed class RepositorioEnMemoria : ILocalidadRepository
{
    readonly List<Localidad> datos = [
        new() { Id = 1, Nombre = "Corrientes", Provincia = "Corrientes", CodigoPostal = "3400", Habitantes = 400000 },
        new() { Id = 2, Nombre = "Goya", Provincia = "Corrientes", CodigoPostal = "3450", Habitantes = 90000 },
        new() { Id = 3, Nombre = "Resistencia", Provincia = "Chaco", CodigoPostal = "3500", Habitantes = 390000 }];
    public Task<IReadOnlyList<Localidad>> GetAllAsync(CancellationToken c = default) => Task.FromResult<IReadOnlyList<Localidad>>(datos.ToList());
    public Task<Localidad?> GetByIdAsync(int id, CancellationToken c = default) => Task.FromResult(datos.FirstOrDefault(l => l.Id == id));
    public Task<int> AddAsync(Localidad l, CancellationToken c = default) { l.Id = datos.Max(x => x.Id) + 1; datos.Add(l); return Task.FromResult(l.Id); }
    public Task UpdateAsync(Localidad l, CancellationToken c = default) => Task.CompletedTask;
    public Task DeleteAsync(int id, CancellationToken c = default) { datos.RemoveAll(l => l.Id == id); return Task.CompletedTask; }
}

/// <summary>Embeddings falsos y estables: bolsa de palabras con hash FNV-1a en 256 dimensiones.</summary>
public sealed class EmbeddingsFnv : IEmbeddingGenerator<string, Embedding<float>>
{
    public Task<GeneratedEmbeddings<Embedding<float>>> GenerateAsync(IEnumerable<string> values, EmbeddingGenerationOptions? o = null, CancellationToken c = default) =>
        Task.FromResult(new GeneratedEmbeddings<Embedding<float>>(values.Select(v => new Embedding<float>(Vector(v)))));
    static float[] Vector(string s)
    {
        var v = new float[256];
        foreach (var w in s.ToLowerInvariant().Normalize(NormalizationForm.FormD).Where(ch => char.IsLetterOrDigit(ch) || ch == ' ').Aggregate(new StringBuilder(), (b, ch) => b.Append(ch)).ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries))
        { uint h = 2166136261; foreach (var ch in w.Length > 5 ? w[..5] : w) { h ^= ch; h *= 16777619; } v[h % 256] += 1; }
        return v;
    }
    public object? GetService(Type t, object? k = null) => null;
    public void Dispose() { }
}

/// <summary>Cliente de chat guionado: pide una herramienta según el pedido y registra lo que recibe.</summary>
public sealed class ChatGuionado : IChatClient
{
    public List<string> Registro { get; } = [];
    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken c = default)
    {
        var lista = messages.ToList();
        Registro.Add($"recibe {lista.Count} mensajes; instrucciones={(options?.Instructions is null ? "no" : "sí: " + options.Instructions.Replace("\n", " | "))}; tools=[{string.Join(",", options?.Tools?.Select(t => t.Name) ?? [])}]");
        var resultado = lista.SelectMany(m => m.Contents).OfType<FunctionResultContent>().LastOrDefault();
        if (resultado is not null)
            return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, $"(guion) con el resultado de la herramienta: {resultado.Result}")));
        var pedido = lista.Last(m => m.Role == ChatRole.User).Text;
        if (options?.Tools is { Count: > 0 })
        {
            var (nombre, args) = pedido.Contains("cuántas localidades", StringComparison.OrdinalIgnoreCase)
                ? ("contar_localidades_por_provincia", new Dictionary<string, object?> { ["provincia"] = "Corrientes" })
                : ("buscar_requisitos", new Dictionary<string, object?> { ["pregunta"] = pedido });
            Registro.Add($"pide herramienta {nombre}");
            return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, [new FunctionCallContent("c1", nombre, args)])));
        }
        return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, "(guion) respuesta sin herramientas")));
    }
    public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> m, ChatOptions? o = null, [EnumeratorCancellation] CancellationToken c = default)
    { foreach (var u in (await GetResponseAsync(m, o, c)).ToChatResponseUpdates()) yield return u; }
    public object? GetService(Type t, object? k = null) => null;
    public void Dispose() { }
}
