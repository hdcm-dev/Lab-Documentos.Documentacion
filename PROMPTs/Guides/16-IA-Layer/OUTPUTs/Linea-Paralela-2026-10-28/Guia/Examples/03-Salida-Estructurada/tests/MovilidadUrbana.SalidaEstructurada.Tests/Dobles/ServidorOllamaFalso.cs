using System.Net;
using System.Text;
using System.Text.Json;

namespace MovilidadUrbana.SalidaEstructurada.Tests.Dobles;

/// <summary>
/// Servidor Ollama falso en el <see cref="HttpClient" />: guarda el cuerpo de cada pedido a /api/chat
/// y contesta con el contenido que se le indique, en el formato de la API nativa.
/// </summary>
public sealed class ServidorOllamaFalso(string contenido) : HttpMessageHandler
{
    public List<string> Cuerpos { get; } = [];

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Cuerpos.Add(request.Content is null ? "" : await request.Content.ReadAsStringAsync(cancellationToken));
        var linea = JsonSerializer.Serialize(new
        {
            model = "modelo-falso",
            created_at = "2026-10-28T00:00:00Z",
            message = new { role = "assistant", content = contenido },
            done = true,
            done_reason = "stop"
        });
        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(linea + "\n", Encoding.UTF8, "application/x-ndjson")
        };
    }
}
