// Sonda P-03 (ciclo 1, aplicación): limitador de concurrencia en la entrada HTTP, 503 con Retry-After.
// El «cliente del modelo» es falso: tarda 2 s. Permisos = 1, Cola = 2: el cuarto pedido simultáneo recibe 503.
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://127.0.0.1:5099");
builder.Logging.ClearProviders();
var opciones = new { Concurrencia = new { Permisos = 1, Cola = 2 } };
builder.Services.AddRateLimiter(o =>
{
    o.RejectionStatusCode = StatusCodes.Status503ServiceUnavailable;
    o.OnRejected = (ctx, ct) =>
    {
        ctx.HttpContext.Response.Headers.RetryAfter = "30";
        return ValueTask.CompletedTask;
    };
    o.AddConcurrencyLimiter("ia", l =>
    {
        l.PermitLimit = opciones.Concurrencia.Permisos;   // 1
        l.QueueLimit  = opciones.Concurrencia.Cola;       // 2
        l.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
});
var app = builder.Build();
app.UseRateLimiter();
app.MapPost("/api/v1/asistente", async (CancellationToken ct) => { await Task.Delay(2000, ct); return Results.Ok("ok"); }).RequireRateLimiting("ia");
await app.StartAsync();

using var http = new HttpClient { BaseAddress = new Uri("http://127.0.0.1:5099") };
var pedidos = Enumerable.Range(1, 4).Select(async i => { await Task.Delay(i * 50); var r = await http.PostAsync("/api/v1/asistente", null); return (i, (int)r.StatusCode, r.Headers.RetryAfter?.ToString() ?? "-"); }).ToArray();
foreach (var (i, codigo, retry) in await Task.WhenAll(pedidos)) Console.WriteLine($"pedido {i}: {codigo} Retry-After={retry}");
await app.StopAsync();
