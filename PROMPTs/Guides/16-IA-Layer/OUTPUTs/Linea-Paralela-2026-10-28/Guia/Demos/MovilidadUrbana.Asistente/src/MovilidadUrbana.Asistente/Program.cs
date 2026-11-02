using System.Globalization;
using MovilidadUrbana.ApiWeb.Application;
using MovilidadUrbana.ApiWeb.Infrastructure;
using MovilidadUrbana.ApiWeb.Infrastructure.Persistence;
using MovilidadUrbana.ApiWeb.Sessions;
using MovilidadUrbana.Asistente.Application;
using MovilidadUrbana.Asistente.Infrastructure.AI;
using MovilidadUrbana.Asistente.Presentation;
using MovilidadUrbana.Asistente.Presentation.Componentes;
using MovilidadUrbana.Asistente.Presentation.Operaciones;
using MovilidadUrbana.Asistente.Presentation.Sesion;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// Como en el caso base: textos y formatos en es-AR.
var cultura = new CultureInfo("es-AR");
CultureInfo.DefaultThreadCurrentCulture = cultura;
CultureInfo.DefaultThreadCurrentUICulture = cultura;

// OLLAMA_ENDPOINT y OLLAMA_MODEL pisan AI:Endpoint y AI:Modelo, sólo si están definidas.
ComposicionDeIA.MapearVariablesDeEntorno(builder.Configuration);

// --- Capas copiadas de MovilidadUrbana.ApiWeb ------------------------------------------------------
var connectionString = builder.Configuration.GetConnectionString("BaseDeDatos")
    ?? MovilidadUrbana.ApiWeb.Infrastructure.DependencyInjection.DefaultConnectionString;
builder.Services.AddInfrastructure(connectionString);
builder.Services.AddApplication();

// --- Lo agregado: núcleo, capa de IA y entradas ----------------------------------------------------
builder.Services.AddApplicationAgregada();
builder.Services.AddCapaDeIA(builder.Configuration, builder.Environment);
builder.Services.AddLimitadorDelModelo();
builder.Services.AddOperacionesDeLocalidad();

builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// Telemetría: sólo si se indica a dónde exportarla (por ejemplo, un Aspire Dashboard local).
if (!string.IsNullOrWhiteSpace(builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]))
{
    builder.Services.AddOpenTelemetry()
        .WithTracing(t => t.AddSource(TelemetriaDeIA.Fuente).AddOtlpExporter())
        .WithMetrics(m => m.AddMeter(TelemetriaDeIA.Fuente).AddOtlpExporter());
}

var app = builder.Build();

DatabaseInitializer.Initialize(app.Services);

app.UseExceptionHandler();
app.UseStatusCodePages();

// La API copiada identifica la sesión por X-Sesion-Id; la página, por una cookie que asigna el servidor.
app.UseWhen(c => c.Request.Path.StartsWithSegments("/api"), a => a.UseMiddleware<SessionHeaderMiddleware>());
app.UseWhen(c => !c.Request.Path.StartsWithSegments("/api"), a => a.UseMiddleware<CookieDeSesionMiddleware>());

app.UseRateLimiter();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapControllers();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();

/// <summary>Punto de entrada visible para las pruebas con <c>WebApplicationFactory</c>.</summary>
public partial class Program;
