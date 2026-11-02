using System.Globalization;
using System.Numerics.Tensors;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Busqueda.Busqueda;
using MovilidadUrbana.Busqueda.Configuracion;
using MovilidadUrbana.Busqueda.Evaluacion;
using MovilidadUrbana.Busqueda.Requisitos;
using MovilidadUrbana.Busqueda.SinModelo;

// Uso: buscar "<consulta>" | evaluar | similitud "<texto a>" "<texto b>" | oro
var comando = args.FirstOrDefault() ?? "buscar";
if (comando == "oro")
{
    Console.Write(GeneradorDeOro.Serializar()); // redirigir a oro/oro-requisitos.json para regenerarlo
    return 0;
}
var textos = args.Skip(1).TakeWhile(a => !a.StartsWith("--", StringComparison.Ordinal)).ToArray();
var opcionesDeLinea = args.Skip(1 + textos.Length).ToArray();

var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
{
    Args = opcionesDeLinea,
    ContentRootPath = AppContext.BaseDirectory,
});
builder.AgregarBusquedaDeRequisitos();

using var host = builder.Build();
try
{
    await host.StartAsync(); // valida opciones y dimensión, e ingiere los doce requisitos
}
catch (OptionsValidationException ex)
{
    Console.Error.WriteLine($"Configuración inválida: {string.Join(" | ", ex.Failures)}");
    return 3;
}
catch (DimensionDeEmbeddingsException ex)
{
    Console.Error.WriteLine(ex.Message);
    return 4;
}

var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
var almacen = host.Services.GetRequiredService<AlmacenDeRequisitos>();
var inv = CultureInfo.InvariantCulture;
var modelo = ia.Modo == Modos.SinModelo ? GeneradorLexicoFalso.Nombre : ia.ModeloDeEmbeddings;
Console.WriteLine($"Modo: {ia.Modo}; modelo: {modelo}; dimensión: {almacen.Dimension}");

switch (comando)
{
    case "buscar":
    {
        var consulta = textos.FirstOrDefault() ?? "¿Cuántos números lleva el CP?";
        var instruccion = ia.Busqueda.InstruccionDeConsulta;
        var umbral = string.IsNullOrWhiteSpace(instruccion) ? ia.Busqueda.UmbralSinInstruccion : ia.Busqueda.UmbralConInstruccion;
        var resultados = await almacen.BuscarAsync(FormatoDeConsulta.Aplicar(instruccion, consulta), ia.Busqueda.Top);
        Console.WriteLine($"> {consulta}");
        foreach (var r in resultados)
            Console.WriteLine($"  {r.Similitud.ToString("0.0000", inv)}  [{r.Fuente}] {r.Enunciado}");
        if (umbral is null)
            Console.WriteLine("  (sin umbral de abstención configurado: la similitud siempre devuelve algo)");
        else if (resultados[0].Similitud < umbral)
            Console.WriteLine($"  Ningún requisito alcanza el umbral {umbral.Value.ToString("0.0000", inv)}: no lo sé con los requisitos cargados.");
        break;
    }
    case "evaluar":
    {
        var oro = GeneradorDeOro.Leer(Path.Combine(AppContext.BaseDirectory, "oro", "oro-requisitos.json"));
        var corpus = host.Services.GetRequiredService<CatalogoDeRequisitos>().Requisitos.Count;
        foreach (var instruccion in new[] { ia.Busqueda.InstruccionDeConsulta, null })
        {
            var corrida = await EvaluacionDeRecuperacion.CorrerAsync(almacen, oro, instruccion, ia.Busqueda.Top, corpus);
            Console.WriteLine(EvaluacionDeRecuperacion.Tabla(corrida));
        }
        break;
    }
    case "similitud":
    {
        var generador = host.Services.GetRequiredService<IEmbeddingGenerator<string, Embedding<float>>>();
        var a = await generador.GenerateVectorAsync(textos.ElementAtOrDefault(0) ?? "colectivo");
        var b = await generador.GenerateVectorAsync(textos.ElementAtOrDefault(1) ?? "ómnibus");
        Console.WriteLine(TensorPrimitives.CosineSimilarity(a.Span, b.Span).ToString("0.0000", inv));
        break;
    }
    default:
        Console.Error.WriteLine($"Comando desconocido: {comando}. Usá buscar, evaluar, similitud u oro.");
        return 2;
}

await host.StopAsync();
return 0;
