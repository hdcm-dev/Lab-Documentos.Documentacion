using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Asistente.Infrastructure.AI;

namespace MovilidadUrbana.Asistente.Presentation;

/// <summary>
/// Un solo límite de concurrencia para el modelo, compartido por las dos entradas: los endpoints HTTP del
/// asistente (política <see cref="Politica"/>, 503 con Retry-After al saturarse) y la página de chat, que
/// llama al puerto en el mismo proceso. No está dentro de la cadena del IChatClient.
/// </summary>
public sealed class LimitadorDelModelo : IDisposable
{
    public const string Politica = "modelo";

    public LimitadorDelModelo(IOptions<OpcionesDeIA> opciones)
    {
        var c = opciones.Value.Concurrencia;
        Limitador = new ConcurrencyLimiter(new ConcurrencyLimiterOptions
        {
            PermitLimit = c.Permisos,
            QueueLimit = c.Cola,
            QueueProcessingOrder = QueueProcessingOrder.OldestFirst
        });
    }

    public ConcurrencyLimiter Limitador { get; }

    public void Dispose() => Limitador.Dispose();
}

public static class LimitadorDelModeloExtensions
{
    public static IServiceCollection AddLimitadorDelModelo(this IServiceCollection services)
    {
        services.AddSingleton<LimitadorDelModelo>();
        services.AddRateLimiter(o =>
        {
            o.RejectionStatusCode = StatusCodes.Status503ServiceUnavailable;
            o.OnRejected = (contexto, _) =>
            {
                var segundos = contexto.HttpContext.RequestServices.GetRequiredService<IOptions<OpcionesDeIA>>().Value.Concurrencia.ReintentarEnSegundos;
                contexto.HttpContext.Response.Headers.RetryAfter = segundos.ToString(System.Globalization.CultureInfo.InvariantCulture);
                return ValueTask.CompletedTask;
            };
            // La partición devuelve siempre el mismo limitador: el que usa también la página.
            o.AddPolicy(LimitadorDelModelo.Politica, contexto =>
                RateLimitPartition.Get(LimitadorDelModelo.Politica,
                    _ => contexto.RequestServices.GetRequiredService<LimitadorDelModelo>().Limitador));
        });
        return services;
    }
}
