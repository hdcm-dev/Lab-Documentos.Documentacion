// Sonda P-11 (ciclo 1, aplicación): ¿ValidateDataAnnotations() recorre el objeto anidado con [ValidateObjectMembers]?
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

foreach (var (caso, permisos, timeout, conAtributo) in new[] { ("Permisos=0, con atributo", "0", "300", true), ("Permisos=0, sin atributo", "0", "300", false), ("sin TimeoutSegundos", "1", null, true), ("válido", "1", "300", true) })
{
    var b = Host.CreateEmptyApplicationBuilder(new());
    var mapa = new Dictionary<string, string?> { ["AI:Concurrencia:Permisos"] = permisos };
    if (timeout is not null) mapa["AI:TimeoutSegundos"] = timeout;
    b.Configuration.AddInMemoryCollection(mapa);
    if (conAtributo) b.Services.AddOptions<OpcionesDeIA>().Bind(b.Configuration.GetSection(OpcionesDeIA.Seccion)).ValidateDataAnnotations().ValidateOnStart();
    else b.Services.AddOptions<OpcionesDeIASinAtributo>().Bind(b.Configuration.GetSection(OpcionesDeIA.Seccion)).ValidateDataAnnotations().ValidateOnStart();
    try { using var h = b.Build(); await h.StartAsync(); await h.StopAsync(); Console.WriteLine($"{caso}: arrancó"); }
    catch (OptionsValidationException e) { Console.WriteLine($"{caso}: OptionsValidationException -> {string.Join(" | ", e.Failures)}"); }
}

public sealed class OpcionesDeIA
{
    public const string Seccion = "AI";
    [Required, Url] public string Endpoint { get; set; } = "http://localhost:11434";
    [Range(32, 4_096)] public int? DimensionDeEmbeddings { get; set; }
    [Range(512, 262_144)] public int NumCtx { get; set; } = 8192;
    [Range(1, 3_600)] public int TimeoutSegundos { get; set; }
    [Range(1, 100_000)] public int LargoMaximoDeEntrada { get; set; } = 2_000;
    [ValidateObjectMembers] public OpcionesDeConcurrencia Concurrencia { get; set; } = new();
}
public sealed class OpcionesDeIASinAtributo
{
    [Range(1, 3_600)] public int TimeoutSegundos { get; set; }
    public OpcionesDeConcurrencia Concurrencia { get; set; } = new();
}
public sealed class OpcionesDeConcurrencia { [Range(1, 64)] public int Permisos { get; set; } = 1; [Range(0, 64)] public int Cola { get; set; } = 2; }
