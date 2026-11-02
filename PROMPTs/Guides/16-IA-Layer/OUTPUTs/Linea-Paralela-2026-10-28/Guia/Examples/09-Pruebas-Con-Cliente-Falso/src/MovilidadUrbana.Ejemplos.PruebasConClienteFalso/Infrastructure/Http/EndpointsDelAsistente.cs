using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Asistente;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Localidades;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.Http;

public sealed record PedidoAlAsistente(string? Texto);
public sealed record RespuestaDelAsistente(string Texto);

public static class EndpointsDelAsistente
{
    public const string PoliticaDeIA = "ia";

    /// <summary>
    /// Límite de concurrencia en la ENTRADA HTTP, no dentro del pipeline de IChatClient: al saturarse,
    /// el pedido recibe 503 con Retry-After (y no un 500 por una excepción del cliente de chat).
    /// </summary>
    public static IServiceCollection AgregarLimitadorDeIA(this IServiceCollection services, IConfiguration configuracion)
    {
        var concurrencia = configuracion.GetSection($"{OpcionesDeIA.Seccion}:Concurrencia").Get<OpcionesDeConcurrencia>() ?? new();
        services.AddRateLimiter(o =>
        {
            o.RejectionStatusCode = StatusCodes.Status503ServiceUnavailable;
            o.OnRejected = (ctx, ct) =>
            {
                ctx.HttpContext.Response.Headers.RetryAfter = concurrencia.ReintentarEnSegundos.ToString();
                return ValueTask.CompletedTask;
            };
            o.AddConcurrencyLimiter(PoliticaDeIA, l =>
            {
                l.PermitLimit = concurrencia.Permisos;   // 1
                l.QueueLimit = concurrencia.Cola;        // 2
                l.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
            });
        });
        return services;
    }

    public static IEndpointRouteBuilder MapearAsistente(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/v1/asistente", async (PedidoAlAsistente pedido, IAsistente asistente,
                IOptions<OpcionesDeIA> opciones, CancellationToken ct) =>
            {
                var maximo = opciones.Value.LargoMaximoDeEntrada;
                if (string.IsNullOrWhiteSpace(pedido.Texto) || pedido.Texto.Length > maximo)
                    return Results.ValidationProblem(new Dictionary<string, string[]>
                        { ["texto"] = [$"El texto es obligatorio y tiene como máximo {maximo} caracteres."] });

                // La cancelación del pedido HTTP llega al cliente de chat por el token.
                return Results.Ok(new RespuestaDelAsistente(await asistente.PreguntarAsync(pedido.Texto, ct)));
            })
            .RequireRateLimiting(PoliticaDeIA);

        // La operación normal de alta: la persona confirma en la pantalla; después se incrementa VersionDeDatos.
        app.MapPost("/api/v1/localidades", async (LocalidadModel model, AltaDeLocalidad alta, CancellationToken ct) =>
        {
            var r = await alta.RegistrarAsync(model, ct);
            return r.IsSuccess ? Results.Ok(r.Message) : Results.ValidationProblem(r.Errors.ToDictionary(e => e.Key, e => new[] { e.Value }));
        });

        return app;
    }
}
