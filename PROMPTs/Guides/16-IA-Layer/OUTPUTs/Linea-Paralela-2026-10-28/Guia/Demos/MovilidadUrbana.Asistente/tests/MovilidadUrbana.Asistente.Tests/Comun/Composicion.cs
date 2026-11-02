using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using MovilidadUrbana.ApiWeb.Application;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Infrastructure;
using MovilidadUrbana.ApiWeb.Infrastructure.Persistence;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Asistente.Application;
using MovilidadUrbana.Asistente.Infrastructure.AI;

namespace MovilidadUrbana.Asistente.Tests.Comun;

/// <summary>Una base SQLite en un archivo temporal, que se borra al terminar.</summary>
public sealed class BaseTemporal : IDisposable
{
    public string Archivo { get; } = Path.Combine(Path.GetTempPath(), $"asistente-{Guid.NewGuid():n}.db");
    public string Cadena => $"Data Source={Archivo};Default Timeout=30;Pooling=False";

    public void Dispose()
    {
        foreach (var f in new[] { Archivo, Archivo + "-wal", Archivo + "-shm" })
            try { File.Delete(f); } catch (IOException) { }
    }
}

/// <summary>
/// La composición real de la app (capas copiadas + agregado + capa de IA), sin host web, con un cliente falso
/// en lugar del cliente del servidor de modelo y espías sobre los repositorios. Para las pruebas que necesitan elegir el ciclo de
/// vida o el ValidateScopes, o mirar la cadena del IChatClient.
/// </summary>
public sealed class Composicion : IDisposable
{
    private readonly BaseTemporal _base = new();

    public ServiceProvider Raiz { get; }
    public ContadorDeLlamadas Contador { get; } = new();

    public Composicion(IChatClient falso, bool validarScopes = true, ServiceLifetime cicloDeVida = ServiceLifetime.Scoped,
        string entorno = "Development", IDictionary<string, string?>? configuracionExtra = null)
    {
        var valores = new Dictionary<string, string?>
        {
            ["AI:TimeoutSegundos"] = "300",
            ["AI:Endpoint"] = "http://localhost:11434"
        };
        foreach (var (k, v) in configuracionExtra ?? new Dictionary<string, string?>()) valores[k] = v;
        var configuracion = new ConfigurationBuilder().AddInMemoryCollection(valores).Build();

        var sc = new ServiceCollection();
        sc.AddLogging();
        sc.AddSingleton<IConfiguration>(configuracion);
        sc.AddInfrastructure(_base.Cadena);
        sc.AddApplication();
        sc.AddApplicationAgregada();
        sc.AddCapaDeIA(configuracion, new HostingEnvironment { EnvironmentName = entorno, ApplicationName = "pruebas" });

        // Espías sobre los repositorios copiados.
        Reemplazar<ILocalidadRepository>(sc, sp => new LocalidadRepositoryEspia(ActivatorUtilities.CreateInstance<LocalidadRepository>(sp), Contador));
        Reemplazar<IEncuestaRepository>(sc, sp => new EncuestaRepositoryEspia(ActivatorUtilities.CreateInstance<EncuestaRepository>(sp), Contador));

        // El cliente real del servidor se reemplaza por el cliente falso.
        sc.AddKeyedSingleton<IChatClient>(ComposicionDeIA.ClaveDelClienteDelServidor, falso);

        if (cicloDeVida != ServiceLifetime.Scoped)
        {
            foreach (var d in sc.Where(d => d.ServiceType == typeof(IChatClient) && !d.IsKeyedService).ToList()) sc.Remove(d);
            sc.AgregarCadenaDeChat(cicloDeVida, habilitarDatosSensibles: entorno == "Development");
        }

        Raiz = sc.BuildServiceProvider(new ServiceProviderOptions { ValidateScopes = validarScopes });
        DatabaseInitializer.Initialize(Raiz);
    }

    private static void Reemplazar<T>(IServiceCollection sc, Func<IServiceProvider, T> fabrica) where T : class
    {
        foreach (var d in sc.Where(d => d.ServiceType == typeof(T)).ToList()) sc.Remove(d);
        sc.AddScoped(fabrica);
    }

    /// <summary>Un ámbito con la sesión fijada, como lo dejarían el middleware o el componente Routes.</summary>
    public AsyncServiceScope Ambito(string sesion)
    {
        var ambito = Raiz.CreateAsyncScope();
        ambito.ServiceProvider.GetRequiredService<SessionContext>().Set(sesion);
        return ambito;
    }

    public void Dispose()
    {
        Raiz.Dispose();
        Microsoft.Data.Sqlite.SqliteConnection.ClearAllPools();
        _base.Dispose();
    }
}
