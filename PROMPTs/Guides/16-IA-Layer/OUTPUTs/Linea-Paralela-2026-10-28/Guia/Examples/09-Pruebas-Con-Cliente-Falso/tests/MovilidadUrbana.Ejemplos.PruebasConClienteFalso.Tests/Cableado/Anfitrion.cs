using System.Diagnostics;
using System.Diagnostics.Metrics;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests.Cableado;

/// <summary>
/// Anfitrión con la composición REAL de la capa de IA (<see cref="ComposicionDeIA.AgregarCapaDeIA"/>) y el
/// cliente del proveedor reemplazado por uno falso. Lo único que cambia es la clave <c>proveedor</c>.
/// </summary>
public static class Anfitrion
{
    public static IHost Crear(
        IChatClient falso,
        ServiceLifetime vidaDelPipeline = ServiceLifetime.Scoped,
        bool validarScopes = true,
        string entorno = "Development",
        Dictionary<string, string?>? configuracion = null)
    {
        var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
        {
            DisableDefaults = true,
            EnvironmentName = entorno,
        });
        builder.Configuration.AddInMemoryCollection(configuracion ?? new() { ["AI:TimeoutSegundos"] = "300" });
        builder.ConfigureContainer(new DefaultServiceProviderFactory(new ServiceProviderOptions { ValidateScopes = validarScopes }));
        builder.AgregarCapaDeIA(vidaDelPipeline, leerVariable: _ => null);
        builder.Services.AddKeyedSingleton(ComposicionDeIA.ClaveDelProveedor, falso);
        var host = builder.Build();
        host.Start();
        return host;
    }

    /// <summary>Un ámbito con la sesión fijada, como lo hace el middleware de sesión en cada pedido HTTP.</summary>
    public static IServiceScope Sesion(this IHost host, string id)
    {
        var ambito = host.Services.CreateScope();
        ambito.ServiceProvider.GetRequiredService<SessionContext>().Set(id);
        return ambito;
    }
}

/// <summary>Escucha la fuente de telemetría: spans, el contador de aciertos (por su NOMBRE) y el histograma de tokens.</summary>
public sealed class Escucha : IDisposable
{
    private readonly ActivityListener _trazas;
    private readonly MeterListener _metricas = new();
    private readonly List<Activity> _spans = [];
    private long _aciertos, _registrosDeTokens;

    public bool InstrumentoDeAciertosPublicado { get; private set; }

    public Escucha(string fuente = TelemetriaDeIA.Fuente)
    {
        _trazas = new ActivityListener
        {
            ShouldListenTo = s => s.Name == fuente,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
            ActivityStopped = a => { lock (_spans) _spans.Add(a); },
        };
        ActivitySource.AddActivityListener(_trazas);

        _metricas.InstrumentPublished = (instrumento, l) =>
        {
            if (instrumento.Meter.Name != fuente) return;
            if (instrumento.Name == "movilidadurbana.ai.cache.aciertos") { InstrumentoDeAciertosPublicado = true; l.EnableMeasurementEvents(instrumento); }
            if (instrumento.Name == "gen_ai.client.token.usage") l.EnableMeasurementEvents(instrumento);
        };
        _metricas.SetMeasurementEventCallback<long>((i, v, _, _) =>
        {
            if (i.Name == "movilidadurbana.ai.cache.aciertos") Interlocked.Add(ref _aciertos, v);
            else Interlocked.Increment(ref _registrosDeTokens);
        });
        _metricas.SetMeasurementEventCallback<int>((i, _, _, _) => Interlocked.Increment(ref _registrosDeTokens));
        _metricas.Start();
    }

    public long Aciertos => Interlocked.Read(ref _aciertos);
    public long RegistrosDeTokens => Interlocked.Read(ref _registrosDeTokens);

    /// <summary>Nombres de los spans terminados, en orden de inicio.</summary>
    public IReadOnlyList<string> Spans()
    {
        lock (_spans) return _spans.OrderBy(a => a.StartTimeUtc).Select(a => a.DisplayName).ToList();
    }

    public void LimpiarSpans() { lock (_spans) _spans.Clear(); }

    public void Dispose()
    {
        _trazas.Dispose();
        _metricas.Dispose();
    }
}
