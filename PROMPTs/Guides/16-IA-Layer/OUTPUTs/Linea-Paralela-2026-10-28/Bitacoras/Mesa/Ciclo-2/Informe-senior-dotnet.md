---
doc_id: BIT-16-C2-INF-senior-dotnet
doc_type: informe-de-mesa
title: Relectura integral (ciclo 2), rol Senior .NET
status: emitido
origin: ai-assisted
last_review: 2026-10-28
traces: [REED-16 §10, 06-Plan-De-Redaccion §10, 07-Dictamen-Presidencia]
---

# Informe del Senior .NET: relectura integral (ciclo 2)

**Mandato.** Que la guía, `Examples/` y la demo usen .NET 10 de forma idiomática: DI, opciones, streaming, EF Core,
Blazor Interactive Server y ASP.NET Core. También, que las versiones de los paquetes coincidan en NuGet de hoy,
el Anexo D y los `.csproj`. Leí la guía completa (l. 1–4116) y revisé el código de `Examples/` y de la demo que la
guía cita en lo que toca a mi mandato. Lo hice a ciegas: no leí otros informes del ciclo 2.

**Evidencia** en `evidencia-senior-dotnet/`:

- `01`: últimas versiones en nuget.org, consultadas el 2026-10-28.
- `02`: los paquetes de cada `.csproj`.
- `03`: la reflexión sobre NUnit 5.0.0 y el marco compartido.
- `04`: los clientes Singleton que retienen un `HttpClient`.
- `05`: las citas de Microsoft Learn, con su fecha.

No compilé nada ni corrí nada contra el modelo. Lo que propongo para producción va rotulado «no ejecutado».

## Hallazgos

### SENIOR-01 · S2 · técnico. En Blazor Interactive Server, «Scoped» quiere decir el circuito, no el pedido

- **Ubicación:** guía §8.7 (l. 2974: «Si el pipeline es Scoped, cada pedido tiene el suyo»), §8.7 «Criterio» (l. 3011), §9.4 (l. 3312) y Anexo F D-06.
- **Evidencia:** la página `ChatDelAsistente.razor` inyecta `IAsistenteDeMovilidad` e `ISessionContext` una sola vez por circuito (l. 5–6). Sus turnos comparten entonces el mismo ámbito y la misma cadena del `IChatClient`. El comentario de `Agregado/Infrastructure/AI/ComposicionDeIA.cs` (l. 18) sí lo dice: «(o cada circuito de la página)». También lo dice `Infrastructure/DependencyInjection.cs` (l. 19): «Factory y no contexto de ámbito: un circuito de Blazor vive más que una petición». La guía nunca lo explica. Microsoft Learn [B] lo confirma: «service instances that are scoped to the circuit» y «scoped service registrations can be problematic… DbContext isn't thread safe».
- **Riesgo para el lector:** quien copie el patrón en Blazor Server inyecta un `DbContext` Scoped en las herramientas. Ese contexto vive horas y queda expuesto a operaciones concurrentes.
- **Propuesta:** agregar al final del párrafo de l. 2974 el texto siguiente.

  > «En Blazor Interactive Server el ámbito no es el pedido sino el **circuito**: la página de la demo resuelve el asistente y la sesión una vez y todos sus turnos comparten la cadena. Eso alcanza para aislar sesiones, porque el circuito es de una sola persona, pero no sirve para la persistencia: un `DbContext` con ámbito viviría lo que dura el circuito y no admite operaciones concurrentes. Por eso la copia del caso base registra `AddDbContextFactory<AppDbContext>` y cada repositorio abre un contexto por operación (`LocalidadRepository`, `LecturaDeResultadosEf`), como recomienda la documentación de Blazor con EF Core [REF-138].»

  Sumar al Anexo D: `REF-138 | Microsoft Learn, «ASP.NET Core Blazor with Entity Framework Core (EF Core)» | https://learn.microsoft.com/en-us/aspnet/core/blazor/blazor-ef-core | ms.date 2025-11-11, updated_at 2026-10-13 | consultada 2026-10-28`.

  En §4.9.4, después de «atada al circuito», agregar: «(sus servicios Scoped viven lo que el circuito, §8.7)».

### SENIOR-02 · S3 · técnico. Un Singleton que retiene un `HttpClient` de `IHttpClientFactory` se enseña como criterio

- **Ubicación:** guía §8.7 «Criterio» (l. 3011): «El cliente del proveedor (`OllamaApiClient`) es Singleton, con clave, y usa el `HttpClient` de `IHttpClientFactory`». También D-06 (consecuencias) y §5.7 (l. 1178). En el código: `Demos/…/Agregado/Infrastructure/AI/ComposicionDeIA.cs` l. 59–64, `Examples/09…/ComposicionDeIA.cs` l. 71–75 y, en consolas, 01, 02, 05, 06, 07, 08 y 10 (`evidencia-senior-dotnet/04`).
- **Evidencia:** Microsoft Learn [A] dice que «HttpClient instances created by IHttpClientFactory are intended to be short-lived». Agrega que un cliente retenido en un singleton «may prevent it from reacting to DNS changes, defeating one of the purposes of IHttpClientFactory». La alternativa documentada para un cliente de larga vida es `SocketsHttpHandler` con `PooledConnectionLifetime`. En las consolas, que viven segundos, no importa. En la demo y en la API de `Examples/09`, que son procesos de larga vida, sí: el servidor de modelos se alcanza por un nombre (`ollama` en la red de Docker) que puede cambiar de dirección cuando se recrea el contenedor.
- **Propuesta:**
  - En el registro del `HttpClient` de la demo y de `Examples/09`, encadenar `.UseSocketsHttpHandler((h, _) => h.PooledConnectionLifetime = TimeSpan.FromMinutes(2)).SetHandlerLifetime(Timeout.InfiniteTimeSpan)`. Es la receta literal de [A]. Después se recompila y corre `Cableado/`.
  - Reemplazar el «Criterio» de l. 3011 por este texto:

    > «El cliente del proveedor (`OllamaApiClient`) es Singleton, con clave, y retiene **un** `HttpClient` durante toda la vida del proceso; por eso su manejador es `SocketsHttpHandler` con `PooledConnectionLifetime`, la forma que la documentación de .NET da para un cliente de larga vida, en lugar de confiar en la rotación de `IHttpClientFactory`, que no alcanza a un `HttpClient` retenido [REF-139].»

  Sumar `REF-139 | Microsoft Learn, «Use the IHttpClientFactory - .NET» | https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory | ms.date 2026-08-06, updated_at 2026-08-13 | consultada 2026-10-28`.

  Si no se cambia el código, la guía debe nombrar el límite: «el Singleton retiene el `HttpClient`; si la dirección del servidor cambia, hace falta reiniciar el proceso».

### SENIOR-03 · S3 · técnico. «Despliegue · La aplicación» sólo muestra `dotnet run` en la imagen del SDK

- **Ubicación:** guía §8.12.2 (l. 3110–3128), con remisión desde §8.1.8 y desde la ruta de ACT-OPS (§0.4).
- **Evidencia:** el único comando corre `dotnet run --project …` dentro de `mcr.microsoft.com/dotnet/sdk:10.0`, con `ASPNETCORE_ENVIRONMENT=Development`. La propia guía dice que sin Development la demo no arranca, porque sólo `appsettings.Development.json` declara `TimeoutSegundos` (l. 3124 y §9.8). Es una forma de correr el laboratorio, no de desplegar: no hay `dotnet publish`, ni imagen de ejecución, ni `appsettings.Production.json`. La guía no dice que eso falta.
- **Propuesta:** agregar al final de §8.12.2 este texto.

  > «**Lo que este comando no es.** Es la forma de correr el laboratorio, no un despliegue. Para un entorno que no es Development faltan tres piezas, ninguna construida en esta guía (**no ejecutado**): publicar (`dotnet publish -c Release`) y correr la salida en la imagen de ejecución `mcr.microsoft.com/dotnet/aspnet:10.0`, no en la del SDK; un `appsettings.Production.json` (o la variable `AI__TimeoutSegundos`) que declare el timeout medido en ese entorno, porque sin él la aplicación no arranca, a propósito (CTRL-10); y `AllowedHosts` restringido al nombre real en lugar del `"*"` del `appsettings.json` de la demo.»

  Sumar a la tabla de §8.3.2 la fila «Publicación para un entorno no Development | la demo sólo corre con `dotnet run` en Development; ver §8.12.2».

### SENIOR-04 · S4 · técnico. `Meter` estático en una aplicación con DI

- **Ubicación:** guía §8.5.2 (l. 2872–2887). En el código: `Examples/09…/Infrastructure/AI/TelemetriaDeIA.cs` l. 15 y `Demos/…/Agregado/Infrastructure/AI/TelemetriaDeIA.cs` l. 15.
- **Evidencia:** Microsoft Learn [C] dice «For usage in DI-aware libraries static variables are considered an anti-pattern» y, para ASP.NET Core y Generic Host, «create the Meter object using IMeterFactory». La guía enseña el `static readonly Meter` sin nombrar la alternativa. Las pruebas que buscan el contador por su nombre (`PipelineTests` (2), `CacheTests`) dependen de un estado global. [C] advierte que, en ese caso, las pruebas en paralelo observan las mediciones de otras pruebas.
- **Propuesta:** agregar después de l. 2887 este texto.

  > «Un `Meter` estático es la forma para código sin DI; en una aplicación con anfitrión, la documentación de .NET recomienda crearlo con `IMeterFactory`, que lo aísla por contenedor y evita que pruebas en paralelo vean las mediciones de otras [REF-140]. Los ejemplos usan el estático para compartir la constante con `UseOpenTelemetry`; la variante con `IMeterFactory` no se construyó. Con el estático, las pruebas que leen el contador no corren en paralelo.»

  Sumar `REF-140 | Microsoft Learn, «Creating Metrics - .NET» | https://learn.microsoft.com/en-us/dotnet/core/diagnostics/metrics-instrumentation | ms.date 2024-11-19, updated_at 2026-06-26 | consultada 2026-10-28`.

  Además, verificar si las pruebas de 09 y de la demo corren en paralelo y anotarlo.

### SENIOR-05 · S4 · coherencia. `Examples/13` arma el cliente sin `IHttpClientFactory` ni timeout

- **Ubicación:** guía §4.4 (l. 700: «El proveedor concreto aparece sólo en el registro (`…/Agregado/Infrastructure/AI/DependencyInjection.cs`, l. 24-29)»). En el código: `Examples/13-Prueba-De-Arquitectura/src/MovilidadUrbana.PruebaDeArquitectura/Agregado/Infrastructure/AI/DependencyInjection.cs` l. 24–28.
- **Evidencia:** ese registro hace `new OllamaApiClient(new Uri(ia.Endpoint), ia.Modelo)`, que crea su propio `HttpClient` con el timeout por defecto. El resto de los ejemplos y el criterio de §5.3, §5.10 y A.1 piden que el timeout salga de `OpcionesDeIA` y que la credencial viaje en un `DelegatingHandler` del `HttpClient` de la fábrica. Es el ejemplo que §1.4 da como plantilla del puerto y su adaptador.
- **Propuesta:** alinear el registro con el de los otros ejemplos: `AddHttpClient` nombrado, con `BaseAddress` y `Timeout` desde `OpcionesDeIA`, más `new OllamaApiClient(factory.CreateClient(...), ia.Modelo)`. Después recompilar y correr las 13 pruebas y las mutaciones. Si no se toca, agregar en §4.4, después de l. 700: «(el registro de este ejemplo es mínimo: sin `IHttpClientFactory` ni timeout configurado; la forma completa es la de §5.3 y §5.7)».

### SENIOR-06 · S4 · técnico. El limitador de `Examples/09` lee la configuración por fuera de `IOptions`

- **Ubicación:** guía §8.6, snippet de l. 2943–2964 (`Examples/09…/Infrastructure/Http/EndpointsDelAsistente.cs` l. 22–41).
- **Evidencia:** `configuracion.GetSection($"{OpcionesDeIA.Seccion}:Concurrencia").Get<OpcionesDeConcurrencia>() ?? new()` liga una segunda copia, sin `ValidateDataAnnotations` y leída una sola vez al registrar. Además, si falta la sección, toma los valores por defecto en silencio. La demo resuelve lo mismo de forma idiomática: `LimitadorDelModelo` recibe `IOptions<OpcionesDeIA>` y `OnRejected` lee `ReintentarEnSegundos` por `RequestServices` con `CultureInfo.InvariantCulture` (`Agregado/Presentation/LimitadorDelModelo.cs` l. 17–50). La regla de §5.10 («ningún literal fuera de `OpcionesDeIA`») se cumple, pero la validación al arrancar de §5.3 no cubre esa copia.
- **Propuesta:** en el ejemplo, tomar los valores de `IOptions<OpcionesDeIA>`, con el patrón de la demo (`AddPolicy` + `RateLimitPartition.Get` sobre un `ConcurrencyLimiter` Singleton construido desde `IOptions`), y actualizar el snippet. Si no se toca el código, agregar después del snippet: «El ejemplo liga la sección aparte para mostrar el limitador solo; la demo lo construye desde `IOptions<OpcionesDeIA>`, así la misma validación al arrancar cubre los permisos (`LimitadorDelModelo.cs`).»

## Revisado y bien

1. **Las versiones coinciden en NuGet de hoy, el Anexo D y los `.csproj`.** Comparé los 30 paquetes en la API flatcontainer el 2026-10-28 (`evidencia/01`). Todos los paquetes usados son la última estable. Las tres filas del origen (`EF Core Sqlite` y `AspNetCore.OpenApi` 10.0.11, `Scalar.AspNetCore` 2.17.3) están desactualizadas a propósito y bien rotuladas, con la última estable correcta (10.0.14 y 2.18.5). La columna «Dónde» de D.2 coincide proyecto por proyecto con `evidencia/02`. También coinciden §2.5, §7 y §9: MEAI 10.11.0, MAF 1.26.0, MCP 2.3.0, OllamaSharp 5.5.0 y SK 1.81.0. Todo apunta a `net10.0`.
2. **EF Core en Blazor Server, en la demo.** `AddDbContextFactory<AppDbContext>` está en `Infrastructure/DependencyInjection.cs` l. 20. Cada repositorio y `LecturaDeResultadosEf` abren un contexto por operación, con `await using` y `AsNoTracking`, que es la recomendación vigente de Microsoft Learn [B]. La página cancela su `CancellationTokenSource` en `Dispose`, no usa `MarkupString` y repinta con `InvokeAsync(StateHasChanged)`. Las confirmaciones pasan por la API HTTP propia, así que no comparten contexto con el turno.
3. **Las afirmaciones de NUnit 5 y del marco compartido están verificadas.** Reflexión sobre `nunit.framework.dll` 5.0.0 (`evidencia/03`): todas las sobrecargas de `Assert.ThrowsAsync` devuelven `Task<T>`, existe `Assert.MultipleAsync` y `[Order]` está marcado `[Obsolete]`. Eso confirma §8.4.2 y la fila de §8.14. Además, el marco compartido `Microsoft.AspNetCore.App` 10.0.14 trae `Microsoft.Extensions.Options.DataAnnotations.dll`, como dice §5.3. El resto de los usos idiomáticos que revisé también se sostiene:
   - opciones con `ValidateDataAnnotations` + `ValidateOnStart` + `[ValidateObjectMembers]`;
   - `ContentRootPath = AppContext.BaseDirectory` en consola;
   - `AddChatClient(...).Use(...)` con `FunctionInvokingChatClient(interno, loggerFactory, sp)`;
   - cliente Keyed y cadena Scoped;
   - en streaming, mirar el token después del bucle;
   - `ValidateScopes` en Development según [REF-123].
