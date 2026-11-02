using System.Runtime.CompilerServices;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Application.Asistente;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI.Aprobaciones;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.Persistence;

namespace MovilidadUrbana.Ejemplos.AgenteConAprobacion.Tests.Cableado;

/// <summary>Reloj que avanza sólo cuando la prueba lo pide.</summary>
public sealed class RelojManual : TimeProvider
{
    private DateTimeOffset _ahora = new(2026, 10, 28, 12, 0, 0, TimeSpan.Zero);
    public override DateTimeOffset GetUtcNow() => _ahora;
    public void Avanzar(TimeSpan t) => _ahora += t;
}

/// <summary>Cliente falso por pasos: cada llamada consume el siguiente paso; sin pasos, responde «fin».</summary>
public sealed class ClientePorPasos(params Func<IList<ChatMessage>, ChatResponse>[] pasos) : IChatClient
{
    private int _i;
    public int Llamadas { get; private set; }
    public List<List<ChatMessage>> MensajesRecibidos { get; } = [];

    public static ChatResponse Pedir(string herramienta, Dictionary<string, object?> argumentos) =>
        new(new ChatMessage(ChatRole.Assistant, [new FunctionCallContent("call-" + Guid.NewGuid().ToString("n")[..6], herramienta, argumentos)]));

    public static ChatResponse Decir(string texto) => new(new ChatMessage(ChatRole.Assistant, texto));

    /// <summary>Un cliente que pide la misma herramienta en cada llamada, para medir el corte del bucle.</summary>
    public static ClientePorPasos SiemprePide(string herramienta, Dictionary<string, object?> argumentos) =>
        new(Enumerable.Repeat<Func<IList<ChatMessage>, ChatResponse>>(_ => Pedir(herramienta, argumentos), 100).ToArray());

    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
    {
        Llamadas++;
        var lista = messages.ToList();
        MensajesRecibidos.Add(lista);
        return Task.FromResult(_i < pasos.Length ? pasos[_i++](lista) : Decir("fin"));
    }

    public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        foreach (var u in (await GetResponseAsync(messages, options, cancellationToken)).ToChatResponseUpdates()) yield return u;
    }

    public object? GetService(Type serviceType, object? serviceKey = null) => serviceType.IsInstanceOfType(this) ? this : null;
    public void Dispose() { }
}

/// <summary>Un aprobador que devuelve null: la persona no contestó.</summary>
public sealed class AprobadorQueDevuelveNull : IAprobador
{
    public int Preguntas { get; private set; }
    public Task<bool?> PreguntarAsync(AprobacionPendiente pendiente, CancellationToken ct) { Preguntas++; return Task.FromResult<bool?>(null); }
}

/// <summary>Un aprobador que nunca contesta: sólo lo corta el plazo.</summary>
public sealed class AprobadorQueNoResponde : IAprobador
{
    public async Task<bool?> PreguntarAsync(AprobacionPendiente pendiente, CancellationToken ct)
    {
        await Task.Delay(Timeout.Infinite, ct);
        return true; // nunca llega
    }
}

public sealed class AprobadorFijo(bool respuesta) : IAprobador
{
    public Task<bool?> PreguntarAsync(AprobacionPendiente pendiente, CancellationToken ct) => Task.FromResult<bool?>(respuesta);
}

/// <summary>Anfitrión con la composición real, el cliente falso y el reloj manual.</summary>
public sealed class Entorno : IDisposable
{
    public IHost Host { get; }
    public RelojManual Reloj { get; } = new();
    public AlmacenEnMemoria Almacen => Host.Services.GetRequiredService<AlmacenEnMemoria>();
    public AlmacenDeAprobaciones Aprobaciones => Host.Services.GetRequiredService<AlmacenDeAprobaciones>();
    public AlmacenDeConversaciones Conversaciones => Host.Services.GetRequiredService<AlmacenDeConversaciones>();

    public Entorno(IChatClient interno, Dictionary<string, string?>? cambios = null)
    {
        var builder = Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
        {
            DisableDefaults = true,
            ContentRootPath = AppContext.BaseDirectory,
        });
        builder.Configuration
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json")
            .AddInMemoryCollection(cambios ?? []);
        builder.AgregarCapaDeIA(_ => null, _ => interno);
        builder.Services.AddSingleton<TimeProvider>(Reloj);
        Host = builder.Build();
    }

    public Sesion Abrir(string sessionId) => new(Host.Services.CreateScope(), sessionId);

    public void Dispose() => Host.Dispose();
}

/// <summary>Un ámbito con su sesión fijada, como lo deja el middleware de sesión en una petición.</summary>
public sealed class Sesion : IDisposable
{
    private readonly IServiceScope _scope;
    public string Id { get; }
    public IServiceProvider Servicios => _scope.ServiceProvider;
    public IAsistenteConAprobacion Asistente => Servicios.GetRequiredService<IAsistenteConAprobacion>();
    public LocalidadService Localidades => Servicios.GetRequiredService<LocalidadService>();
    public HerramientasDeLocalidades Herramientas => Servicios.GetRequiredService<HerramientasDeLocalidades>();
    public AutorizacionDeEscritura Autorizacion => Servicios.GetRequiredService<AutorizacionDeEscritura>();

    public Sesion(IServiceScope scope, string id)
    {
        _scope = scope;
        Id = id;
        Servicios.GetRequiredService<SessionContext>().Set(id);
    }

    public async Task<int> IdDeAsync(string nombre) => (await Localidades.GetAllAsync()).Single(l => l.Nombre == nombre).Id;

    public async Task<string[]> NombresAsync() => (await Localidades.GetAllAsync()).Select(l => l.Nombre).ToArray();

    public void Dispose() => _scope.Dispose();
}
