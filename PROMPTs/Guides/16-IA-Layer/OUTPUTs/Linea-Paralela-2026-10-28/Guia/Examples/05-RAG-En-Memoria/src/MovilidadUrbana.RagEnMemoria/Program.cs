using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.RagEnMemoria;
using MovilidadUrbana.RagEnMemoria.Application.Ayuda;
using MovilidadUrbana.RagEnMemoria.Infrastructure.AI;
using MovilidadUrbana.RagEnMemoria.SinModelo;

// Uso: dotnet run -- [--estrategia contexto-fijo|rag|rag-herramienta|rag-agente] [--sin-modelo] "pregunta"
var sinModelo = args.Contains("--sin-modelo");
var estrategia = ValorDe("--estrategia") ?? ComposicionDeIA.Estrategias.Rag;
var pregunta = args.Where((a, i) => !a.StartsWith("--", StringComparison.Ordinal) && (i == 0 || args[i - 1] != "--estrategia")).LastOrDefault()
               ?? "¿Cuántos dígitos lleva el código postal?";
if (!ComposicionDeIA.Estrategias.Todas.Contains(estrategia))
{
    Console.Error.WriteLine($"Estrategia desconocida: {estrategia}. Opciones: {string.Join(", ", ComposicionDeIA.Estrategias.Todas)}");
    return 2;
}

var builder = Host.CreateApplicationBuilder(args);
if (sinModelo)
{
    // Sin red: el generador por palabras y un cliente que devuelve el pedido armado.
    builder.Services.AddOptions<OpcionesDeIA>().Bind(builder.Configuration.GetSection(OpcionesDeIA.Seccion)).ValidateDataAnnotations().ValidateOnStart();
    builder.Services.AddSingleton<IEmbeddingGenerator<string, Embedding<float>>>(sp =>
        new GeneradorPorPalabras(sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value.DimensionDeEmbeddings ?? 1024));
    builder.Services.AddSingleton<IChatClient, ClienteQueMuestraElPedido>();
    builder.AgregarAyuda();
}
else
{
    builder.AgregarCapaDeIA();
}

using var host = builder.Build();
await host.StartAsync();   // valida opciones y la dimensión de los embeddings, y carga el corpus

var ayuda = host.Services.GetRequiredKeyedService<IAyuda>(estrategia);
var respuesta = await ayuda.ResponderAsync(pregunta, semilla: null, CancellationToken.None);

Console.WriteLine($"Estrategia: {estrategia}{(sinModelo ? " (sin modelo)" : "")}");
Console.WriteLine($"Pregunta: {pregunta}");
Console.WriteLine("Fragmentos en el pedido:");
foreach (var f in respuesta.FragmentosEnElPrompt)
    Console.WriteLine($"  {f.Puntaje,6:0.000}  [{f.Fuente}] {f.Texto}");
Console.WriteLine($"Respuesta: {respuesta.Texto}");
if (!sinModelo)
    Console.WriteLine($"Citas válidas: {(respuesta.FuentesCitadas.Count == 0 ? "(ninguna)" : string.Join(", ", respuesta.FuentesCitadas))}");
Console.WriteLine($"Tokens de entrada: {respuesta.TokensDeEntrada?.ToString() ?? "(no informado)"}; de salida: {respuesta.TokensDeSalida?.ToString() ?? "(no informado)"}");
await host.StopAsync();
return 0;

string? ValorDe(string opcion)
{
    var i = Array.IndexOf(args, opcion);
    return i >= 0 && i + 1 < args.Length ? args[i + 1] : null;
}
