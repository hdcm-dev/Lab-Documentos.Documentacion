using System.Net.Http.Json;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using MovilidadUrbana.ApiWeb.Contracts;
using MovilidadUrbana.ApiWeb.Sessions;

namespace MovilidadUrbana.Asistente.Presentation.Operaciones;

/// <summary>Resultado de la operación normal: si salió bien, el mensaje, y los errores por campo de la API.</summary>
public sealed record ResultadoDeOperacion(bool Ok, int Estado, IReadOnlyDictionary<string, string[]> Errores);

/// <summary>
/// La confirmación de la persona ejecuta la operación normal de la API copiada (mismo controller, mismo
/// middleware de sesión, mismas reglas que el ABM sin IA), por HTTP al propio servidor y con la sesión de
/// la página en <c>X-Sesion-Id</c>.
/// </summary>
public sealed class OperacionesDeLocalidad(HttpClient http)
{
    public const string NombreDelCliente = "api-propia";

    public Task<ResultadoDeOperacion> AgregarAsync(string sessionId, LocalidadRequest datos, CancellationToken cancellationToken) =>
        Enviar(new HttpRequestMessage(HttpMethod.Post, "api/v1/localidades") { Content = JsonContent.Create(datos) }, sessionId, cancellationToken);

    public Task<ResultadoDeOperacion> EliminarAsync(string sessionId, int id, CancellationToken cancellationToken) =>
        Enviar(new HttpRequestMessage(HttpMethod.Delete, $"api/v1/localidades/{id}"), sessionId, cancellationToken);

    private async Task<ResultadoDeOperacion> Enviar(HttpRequestMessage pedido, string sessionId, CancellationToken cancellationToken)
    {
        pedido.Headers.Add(SessionHeaderMiddleware.HeaderName, sessionId);
        using var respuesta = await http.SendAsync(pedido, cancellationToken);
        if (respuesta.IsSuccessStatusCode) return new(true, (int)respuesta.StatusCode, new Dictionary<string, string[]>());

        IReadOnlyDictionary<string, string[]> errores = new Dictionary<string, string[]>();
        if (respuesta.Content.Headers.ContentType?.MediaType?.Contains("json") == true)
        {
            var problema = await respuesta.Content.ReadFromJsonAsync<ValidationProblemDetails>(cancellationToken);
            if (problema is not null) errores = problema.Errors.ToDictionary(e => e.Key, e => e.Value);
        }
        return new(false, (int)respuesta.StatusCode, errores);
    }
}

public static class OperacionesDeLocalidadExtensions
{
    /// <summary>
    /// El cliente apunta a la dirección en la que escucha este mismo servidor (o a <c>Asistente:UrlDeLaApi</c>
    /// si se configura). No usa la URL del navegador: dentro de un contenedor el puerto publicado es otro.
    /// </summary>
    public static IServiceCollection AddOperacionesDeLocalidad(this IServiceCollection services)
    {
        services.AddHttpClient<OperacionesDeLocalidad>(OperacionesDeLocalidad.NombreDelCliente, (sp, http) =>
        {
            var configurada = sp.GetRequiredService<IConfiguration>()["Asistente:UrlDeLaApi"];
            http.BaseAddress = new Uri(string.IsNullOrWhiteSpace(configurada) ? DireccionPropia(sp) : configurada);
        });
        return services;
    }

    private static string DireccionPropia(IServiceProvider sp)
    {
        var direccion = sp.GetRequiredService<IServer>().Features.Get<IServerAddressesFeature>()?.Addresses.FirstOrDefault()
            ?? "http://localhost";
        var uri = new UriBuilder(direccion.Replace("://+", "://localhost").Replace("://*", "://localhost")
            .Replace("://[::]", "://localhost").Replace("://0.0.0.0", "://localhost"));
        return uri.Uri.GetLeftPart(UriPartial.Authority) + "/";
    }
}
