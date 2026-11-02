using System.Net.Http.Headers;
using Microsoft.Extensions.Options;

namespace MovilidadUrbana.Ejemplos.ChatBasico.Configuracion;

/// <summary>
/// Pone la credencial como encabezado HTTP. Es el lugar correcto: un encabezado puesto acá
/// no se copia al cuerpo del pedido, cosa que sí pasa con los encabezados por pedido del
/// cliente de OllamaSharp (se serializan dentro del JSON).
/// </summary>
public sealed class ManejadorDeCredenciales(IOptions<OpcionesDeIA> opciones) : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage pedido, CancellationToken ct)
    {
        if (opciones.Value.Credencial is { Length: > 0 } credencial)
            pedido.Headers.Authorization = new AuthenticationHeaderValue("Bearer", credencial);
        return base.SendAsync(pedido, ct);
    }
}
