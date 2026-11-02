using System.Net.Http.Headers;
using Microsoft.Extensions.Options;

namespace MovilidadUrbana.Ejemplos.ToolCalling.Infrastructure.AI;

/// <summary>Pone la credencial como encabezado HTTP, en el <c>HttpClient</c> de <c>IHttpClientFactory</c>; nunca en el cuerpo.</summary>
public sealed class ManejadorDeCredenciales(IOptions<OpcionesDeIA> opciones) : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage pedido, CancellationToken ct)
    {
        if (opciones.Value.Credencial is { Length: > 0 } credencial)
            pedido.Headers.Authorization = new AuthenticationHeaderValue("Bearer", credencial);
        return base.SendAsync(pedido, ct);
    }
}
