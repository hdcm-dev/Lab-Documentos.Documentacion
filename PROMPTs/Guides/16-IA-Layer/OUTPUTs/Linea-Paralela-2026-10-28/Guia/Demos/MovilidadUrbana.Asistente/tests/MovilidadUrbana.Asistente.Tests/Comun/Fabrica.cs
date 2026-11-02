using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Infrastructure.Persistence;
using MovilidadUrbana.ApiWeb.Sessions;
using MovilidadUrbana.Asistente.Infrastructure.AI;
using MovilidadUrbana.Asistente.Presentation.Contracts;
using MovilidadUrbana.Asistente.Presentation.Operaciones;

namespace MovilidadUrbana.Asistente.Tests.Comun;

/// <summary>
/// La app entera en proceso (WebApplicationFactory), con el cliente falso en lugar del cliente del servidor de modelo, una base
/// SQLite temporal y espías sobre los repositorios. Sin Kestrel ni modelo.
/// </summary>
public sealed class Fabrica(IChatClient falso, IDictionary<string, string?>? configuracion = null) : WebApplicationFactory<Program>
{
    private readonly BaseTemporal _base = new();

    public ContadorDeLlamadas Contador { get; } = new();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Development");
        builder.UseSetting("ConnectionStrings:BaseDeDatos", _base.Cadena);
        foreach (var (k, v) in configuracion ?? new Dictionary<string, string?>()) builder.UseSetting(k, v);

        builder.ConfigureTestServices(sc =>
        {
            foreach (var d in sc.Where(d => d.ServiceType == typeof(ILocalidadRepository) || d.ServiceType == typeof(IEncuestaRepository)).ToList()) sc.Remove(d);
            sc.AddScoped<ILocalidadRepository>(sp => new LocalidadRepositoryEspia(ActivatorUtilities.CreateInstance<LocalidadRepository>(sp), Contador));
            sc.AddScoped<IEncuestaRepository>(sp => new EncuestaRepositoryEspia(ActivatorUtilities.CreateInstance<EncuestaRepository>(sp), Contador));
            sc.AddKeyedSingleton<IChatClient>(ComposicionDeIA.ClaveDelClienteDelServidor, falso);
            // La confirmación de la página llama a la API por HTTP: en proceso, al TestServer.
            sc.AddHttpClient(OperacionesDeLocalidad.NombreDelCliente).ConfigurePrimaryHttpMessageHandler(() => Server.CreateHandler());
        });
    }

    public HttpClient Cliente(string sesion)
    {
        var c = CreateClient();
        c.DefaultRequestHeaders.Add(SessionHeaderMiddleware.HeaderName, sesion);
        return c;
    }

    public static readonly JsonSerializerOptions Json = new(JsonSerializerDefaults.Web);

    /// <summary>POST /api/v1/asistente y lee el arreglo de eventos completo.</summary>
    public async Task<(HttpResponseMessage Respuesta, List<EventoDto> Eventos)> ConversarAsync(string sesion, string texto)
    {
        var r = await Cliente(sesion).PostAsJsonAsync("api/v1/asistente", new PedidoAlAsistente(texto, null));
        var eventos = r.IsSuccessStatusCode ? await r.Content.ReadFromJsonAsync<List<EventoDto>>(Json) ?? [] : [];
        return (r, eventos);
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        Microsoft.Data.Sqlite.SqliteConnection.ClearAllPools();
        _base.Dispose();
    }
}
