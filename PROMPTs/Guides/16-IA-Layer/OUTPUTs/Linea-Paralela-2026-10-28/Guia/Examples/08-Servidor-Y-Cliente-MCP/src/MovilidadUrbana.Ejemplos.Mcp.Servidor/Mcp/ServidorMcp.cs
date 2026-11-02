using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using ModelContextProtocol.Server;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Application.Consultas;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Herramientas;
using MovilidadUrbana.Ejemplos.Mcp.Servidor.Infrastructure.Persistence;

namespace MovilidadUrbana.Ejemplos.Mcp.Servidor.Mcp;

/// <summary>
/// Composición del servidor MCP: un adaptador de entrada más, al lado de la API. Usa
/// <c>WebApplication.CreateBuilder</c> (no el builder <i>slim</i>), que es el que registra el HostFiltering
/// que lee <c>AllowedHosts</c>. Principio: el modelo propone; la aplicación ejecuta, autoriza y valida.
/// </summary>
public static class ServidorMcp
{
    /// <summary>Crea el builder con la configuración del servidor (<c>servidor-mcp*.json</c>, variables, argumentos).</summary>
    public static WebApplicationBuilder CrearBuilder(string[] args, string? entorno = null, IDictionary<string, string?>? cambios = null)
    {
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions
        {
            Args = args,
            EnvironmentName = entorno,
            ContentRootPath = AppContext.BaseDirectory,
        });
        builder.Configuration
            .AddJsonFile("servidor-mcp.json", optional: false)
            .AddJsonFile($"servidor-mcp.{builder.Environment.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables()            // otra vez, para que pisen a los .json de arriba
            .AddCommandLine(args)
            .AddInMemoryCollection(cambios ?? new Dictionary<string, string?>());
        return builder;
    }

    /// <param name="herramientas">
    /// Qué publica el servidor. Por defecto, el catálogo único filtrado a lectura. Las pruebas pasan la
    /// alternativa con atributos para compararla.
    /// </param>
    public static WebApplicationBuilder AgregarServidorMcp(this WebApplicationBuilder builder, Action<IMcpServerBuilder>? herramientas = null)
    {
        var errores = ReglasDelPerimetro.Revisar(builder.Configuration);
        if (errores.Count > 0) throw new InvalidOperationException(string.Join(Environment.NewLine, errores));

        builder.WebHost.UseUrls(builder.Configuration.GetSection($"{OpcionesDelServidorMcp.Seccion}:Urls").Get<string[]>()!);

        builder.Services.AddOptions<OpcionesDelServidorMcp>()
            .Bind(builder.Configuration.GetSection(OpcionesDelServidorMcp.Seccion))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        // Núcleo y persistencia, por ámbito: una petición HTTP es un ámbito.
        builder.Services.AddSingleton<AlmacenEnMemoria>();
        builder.Services.AddScoped<SessionContext>();
        builder.Services.AddScoped<ISessionContext>(sp => sp.GetRequiredService<SessionContext>());
        builder.Services.AddScoped<ILocalidadRepository, LocalidadRepositoryEnMemoria>();
        builder.Services.AddScoped<LocalidadService>();
        builder.Services.AddScoped<ConsultaDeLocalidades>();

        builder.Services.AddAuthentication(AutenticacionPorToken.Esquema)
            .AddScheme<AuthenticationSchemeOptions, AutenticacionPorToken>(AutenticacionPorToken.Esquema, null);
        builder.Services.AddAuthorization();

        var mcp = builder.Services.AddMcpServer(o => o.ServerInfo = new() { Name = "movilidad-urbana", Version = "1.0.0" })
            .WithHttpTransport(o => o.Stateless = true);   // sin estado: cada pedido es independiente
        if (herramientas is not null) herramientas(mcp);
        else mcp.WithTools(CatalogoDeHerramientas.DeLectura().Select(f => McpServerTool.Create(f, new McpServerToolCreateOptions
        {
            ReadOnly = true,
            Destructive = false,
            Idempotent = true,
            OpenWorld = false,
        })));
        return builder;
    }

    public static WebApplication UsarServidorMcp(this WebApplication app)
    {
        var ruta = app.Services.GetRequiredService<Microsoft.Extensions.Options.IOptions<OpcionesDelServidorMcp>>().Value.Ruta;
        app.UseWhen(c => c.Request.Path.StartsWithSegments(ruta), rama => rama
            .UseMiddleware<ValidacionDeOrigen>()          // 403 con un Origin ajeno
            .UseMiddleware<SesionFijaDeDemostracion>());  // la sesión fija, declarada
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapMcp(ruta).RequireAuthorization();          // 401 sin token o con token incorrecto
        return app;
    }

    /// <summary>
    /// Levanta el servidor en un puerto libre de 127.0.0.1, en el mismo proceso (lo usan la consola cliente y
    /// las pruebas). El cliente igual se conecta por HTTP: pasa por el perímetro y la autenticación.
    /// </summary>
    public static async Task<ServidorEnProceso> IniciarEnLoopbackAsync(
        string entorno, IDictionary<string, string?>? cambios = null, Action<IMcpServerBuilder>? herramientas = null,
        CancellationToken ct = default)
    {
        var todos = new Dictionary<string, string?>(cambios ?? new Dictionary<string, string?>())
        {
            [$"{OpcionesDelServidorMcp.Seccion}:Urls:0"] = "http://127.0.0.1:0",
        };
        var builder = CrearBuilder([], entorno, todos);
        builder.Logging.ClearProviders();
        builder.AgregarServidorMcp(herramientas);
        var app = builder.Build();
        app.UsarServidorMcp();
        await app.StartAsync(ct);
        var direccion = app.Services.GetRequiredService<IServer>().Features.Get<IServerAddressesFeature>()!.Addresses.Single();
        var ruta = app.Services.GetRequiredService<Microsoft.Extensions.Options.IOptions<OpcionesDelServidorMcp>>().Value.Ruta;
        return new ServidorEnProceso(app, new Uri(direccion.TrimEnd('/') + ruta));
    }
}

/// <summary>El servidor levantado en proceso y su punto de conexión.</summary>
public sealed class ServidorEnProceso(WebApplication app, Uri endpoint) : IAsyncDisposable
{
    public WebApplication App { get; } = app;
    public Uri Endpoint { get; } = endpoint;
    public AlmacenEnMemoria Almacen => App.Services.GetRequiredService<AlmacenEnMemoria>();

    public async ValueTask DisposeAsync()
    {
        await App.StopAsync();
        await App.DisposeAsync();
    }
}
