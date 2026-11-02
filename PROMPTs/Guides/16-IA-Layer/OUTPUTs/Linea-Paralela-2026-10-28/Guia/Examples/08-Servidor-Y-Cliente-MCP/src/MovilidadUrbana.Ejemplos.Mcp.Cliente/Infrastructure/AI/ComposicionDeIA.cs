using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OllamaSharp;

namespace MovilidadUrbana.Ejemplos.Mcp.Cliente.Infrastructure.AI;

/// <summary>Composición del cliente: el único lugar que conoce al proveedor y arma el bucle de herramientas.</summary>
public static class ComposicionDeIA
{
    public const string NombreDelHttpClient = "servidor-de-modelos";

    /// <param name="leerVariable">Lector de variables de entorno; las pruebas pasan uno propio.</param>
    /// <param name="clienteInterno">Reemplaza al cliente del proveedor (modo sin modelo y pruebas).</param>
    public static IHostApplicationBuilder AgregarCapaDeIA(
        this IHostApplicationBuilder builder, Func<string, string?>? leerVariable = null,
        Func<IServiceProvider, IChatClient>? clienteInterno = null)
    {
        leerVariable ??= Environment.GetEnvironmentVariable;

        // Las variables externas pisan la configuración, sólo si están definidas.
        var mapa = new Dictionary<string, string?>();
        if (leerVariable("OLLAMA_ENDPOINT") is { Length: > 0 } endpoint) mapa["AI:Endpoint"] = endpoint;
        if (leerVariable("OLLAMA_MODEL") is { Length: > 0 } modelo) mapa["AI:Modelo"] = modelo;
        builder.Configuration.AddInMemoryCollection(mapa);

        builder.Services.AddOptions<OpcionesDeIA>()
            .Bind(builder.Configuration.GetSection(OpcionesDeIA.Seccion))
            .ValidateDataAnnotations()
            .ValidateOnStart();
        builder.Services.AddOptions<OpcionesDelClienteMcp>()
            .Bind(builder.Configuration.GetSection(OpcionesDelClienteMcp.Seccion))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        builder.Services.AddHttpClient(NombreDelHttpClient, (sp, http) =>
        {
            var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
            http.BaseAddress = new Uri(ia.Endpoint);
            http.Timeout = TimeSpan.FromSeconds(ia.TimeoutSegundos);
        });

        // Un IChatClient con el bucle de herramientas acotado (CTRL-05); el agente lo usa tal cual.
        builder.Services.AddChatClient(clienteInterno ?? CrearClienteDelProveedor)
            .Use((interno, sp) =>
            {
                var limites = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value.Herramientas;
                return new FunctionInvokingChatClient(interno, sp.GetService<ILoggerFactory>(), sp)
                {
                    MaximumIterationsPerRequest = limites.MaximoDeIteraciones,
                    MaximumConsecutiveErrorsPerRequest = limites.MaximoDeErroresConsecutivos,
                };
            });
        return builder;
    }

    /// <summary>Vía nativa: OllamaSharp → <c>/api/chat</c>, con <c>num_ctx</c> por pedido.</summary>
    public static IChatClient CrearClienteDelProveedor(IServiceProvider sp)
    {
        var ia = sp.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
        var http = sp.GetRequiredService<IHttpClientFactory>().CreateClient(NombreDelHttpClient);
        return new OllamaApiClient(http, ia.Modelo);
    }
}
