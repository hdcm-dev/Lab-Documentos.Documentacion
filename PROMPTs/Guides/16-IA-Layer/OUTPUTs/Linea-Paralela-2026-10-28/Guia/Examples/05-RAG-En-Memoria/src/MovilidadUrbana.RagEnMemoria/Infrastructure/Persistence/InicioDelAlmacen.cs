using Microsoft.Extensions.Hosting;

namespace MovilidadUrbana.RagEnMemoria.Infrastructure.Persistence;

/// <summary>Valida la dimensión y carga el corpus al arrancar: si falla, el anfitrión no arranca.</summary>
public sealed class InicioDelAlmacen(AlmacenDeRequisitos almacen) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken) => almacen.IniciarAsync(cancellationToken);

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
