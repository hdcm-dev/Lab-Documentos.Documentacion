using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.SalidaEstructurada;
using MovilidadUrbana.SalidaEstructurada.Application.Propuestas;
using MovilidadUrbana.SalidaEstructurada.Infrastructure.AI;
using MovilidadUrbana.SalidaEstructurada.Infrastructure.Persistence;
using OllamaSharp;

// appsettings.json se lee de la carpeta de salida, también con «dotnet run --project» desde otra carpeta.
var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
{
    Args = args,
    ContentRootPath = AppContext.BaseDirectory
});

// Las variables externas pisan la sección AI sólo si están definidas.
var mapa = new Dictionary<string, string?>();
void Mapear(string variable, string clave)
{
    var valor = Environment.GetEnvironmentVariable(variable);
    if (!string.IsNullOrWhiteSpace(valor)) mapa[clave] = valor;
}
Mapear("OLLAMA_ENDPOINT", "AI:Endpoint");
Mapear("OLLAMA_MODEL", "AI:Modelo");
builder.Configuration.AddInMemoryCollection(mapa);

builder.Services.AddOptions<OpcionesDeIA>()
    .Bind(builder.Configuration.GetSection(OpcionesDeIA.Seccion))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddHttpClient("ollama", (sp, http) =>
{
    var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
    http.BaseAddress = new Uri(ia.Endpoint);
    http.Timeout = TimeSpan.FromSeconds(ia.TimeoutSegundos);
});
builder.Services.AddChatClient(sp =>
{
    var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
    var http = sp.GetRequiredService<IHttpClientFactory>().CreateClient("ollama");
    return new OllamaApiClient(http, ia.Modelo);
});

builder.Services.AddSingleton<LocalidadRepositoryEnMemoria>();
builder.Services.AddSingleton<ILocalidadRepository>(sp => sp.GetRequiredService<LocalidadRepositoryEnMemoria>());
builder.Services.AddSingleton<IExtractorDeLocalidad, ExtractorDeLocalidadLlm>();
builder.Services.AddSingleton<RevisorDePropuesta>();

using var host = builder.Build();
await host.StartAsync();   // ValidateOnStart: sin TimeoutSegundos no arranca

var texto = args.Length > 0 ? string.Join(' ', args) : "Agregá Goya, Corrientes, CP 34, 89959 habitantes";
var repositorio = host.Services.GetRequiredService<LocalidadRepositoryEnMemoria>();
var extractor = host.Services.GetRequiredService<IExtractorDeLocalidad>();
var revisor = host.Services.GetRequiredService<RevisorDePropuesta>();

LocalidadPropuesta? propuesta = await extractor.ExtraerAsync(texto, await repositorio.GetAllAsync());
Revision revision = await revisor.RevisarAsync(propuesta);

var json = new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() } };
Console.WriteLine($"Texto: {texto}");
Console.WriteLine($"Propuesta del modelo (forma): {JsonSerializer.Serialize(propuesta, json)}");
Console.WriteLine($"Revisión (validez): {revision.GetType().Name}");
Console.WriteLine(JsonSerializer.Serialize<object>(revision, json));
Console.WriteLine($"Escrituras en el repositorio: {repositorio.Escrituras}");   // siempre 0: guardar lo confirma la persona

await host.StopAsync();
