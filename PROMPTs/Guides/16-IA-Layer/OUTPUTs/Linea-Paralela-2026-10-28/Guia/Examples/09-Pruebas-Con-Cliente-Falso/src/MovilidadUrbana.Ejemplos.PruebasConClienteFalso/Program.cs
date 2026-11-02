using MovilidadUrbana.ApiWeb.Sessions;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.Http;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

builder.AgregarCapaDeIA();
builder.Services.AgregarLimitadorDeIA(builder.Configuration);

// La misma constante en UseOpenTelemetry (ComposicionDeIA), AddSource y AddMeter.
var otel = builder.Services.AddOpenTelemetry()
    .WithTracing(t => t.AddSource(TelemetriaDeIA.Fuente))
    .WithMetrics(m => m.AddMeter(TelemetriaDeIA.Fuente));
if (!string.IsNullOrWhiteSpace(builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]))
    otel.UseOtlpExporter();   // sólo si hay un colector configurado

var app = builder.Build();

app.UseMiddleware<SessionHeaderMiddleware>();   // copiado del caso base: X-Sesion-Id → SessionContext
app.UseRateLimiter();
app.MapearAsistente();

app.Run();

/// <summary>Visible para <c>WebApplicationFactory</c> en las pruebas.</summary>
public partial class Program;
