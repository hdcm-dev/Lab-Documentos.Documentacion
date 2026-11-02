---
doc_id: BIT-16-C1-INF-senior-dotnet
doc_type: informe-de-especialista
title: Informe del especialista Senior .NET — mesa ciclo 1
status: hecho
origin: agent
owner: especialista Senior .NET (panel del ciclo 1)
last_review: 2026-10-28
audience: [relator, jurado, presidencia]
traces: [REED-16 §8, §9.2 paso 3, M§3, M§8, BIT-16-00, BIT-16-04 §2–§7, Nucleos/N1, N2, N3, N4, N5, N6, Lab-E2E.WebBlazor@59399ba]
---

# Informe del especialista Senior .NET — mesa ciclo 1

**Mandato.** Uso idiomático de .NET 10 en los borradores y en el plan de la demo: DI, `IServiceCollection`, configuración, `IAsyncEnumerable`/streaming, EF Core, Blazor Interactive Server, ASP.NET Core, versiones de paquetes. No juzgo la calidad del modelo ni la didáctica. Trabajé a ciegas: no leí otros informes del ciclo.

**Qué revisé.** BIT-16-04 completo (§2 tensiones, §3 contradicciones, §5 MI, §6.2 arquitectura, §6.3 M1–M12, §7 pendientes), N2 §2–§9 y sus dos notas del 2026-10-28, N6 §4, §8, Anexos A y B y sus notas, N4 §4, N5 §3.1 y §4, la evidencia de integración que toca .NET (`Integracion-Evidencia/A-arquitectura/exp-capas/`, `C-operacion-demo/X1-*`) y el código del caso base en `Lab-E2E.WebBlazor` (`59399ba`, sólo lectura): `ApiWeb/{Program.cs, Sessions/, Infrastructure/, Application/, Domain/Entities/}` y `Web/{Program.cs, Sessions/, Components/App.razor, Routes.razor}`.

**Evidencia propia** (en [`evidencia-senior-dotnet/`](evidencia-senior-dotnet/README.md)). Cuatro sondas **sin modelo**, compiladas y corridas en `mcr.microsoft.com/dotnet/sdk:10.0` (SDK 10.0.403, runtime 10.0.14) por el recurso `build`, más una consulta a nuget.org (2026-10-28T09:45 -03) y una a la doc de Ollama. No usé `<recurso-compartido>`. Intermedios en `{dir-de-trabajo}/senior-dotnet/`, sin bin/obj.

---

## 1. Hallazgos

### SENIOR-01 — El orden del pipeline elegido apaga los spans de herramientas que la guía promete

- **Ubicación**: BIT-16-04 §3.1 R-C07 (l. 110), §6.2 nodo `PIPE` (l. 270), §6.3 M8 (l. 334); reparaciones de N2 (§4.5 y P6) y N5 (§4.1); contradice N5 §1.2 (l. 42: «spans invoke_agent/execute_tool»).
- **Severidad**: S2 · **Evidencia**: E1 · **Capa**: integración (decisión R-C07).
- **Afirmación**: con `UseOpenTelemetry` por fuera de `UseFunctionInvocation` (el orden que fija R-C07), el pedido produce **un solo span `chat`**; desaparecen `orchestrate_tools`, `execute_tool <nombre>` y el span por cada ida y vuelta al modelo. Con la telemetría por dentro de la invocación de funciones aparecen los cuatro.
- **Ancla** (`S-sonda1-salida.txt`, [S1], MEAI 10.11.0, cliente guionado que pide `contar_localidades_por_provincia`):
  ```text
  OTel afuera: UseOpenTelemetry → UseFunctionInvocation → cliente   → spans = 1  (chat)
  OTel adentro: UseFunctionInvocation → UseOpenTelemetry → cliente  → spans = 4  (orchestrate_tools; chat; execute_tool contar_localidades_por_provincia; chat)
  ```
  `FunctionInvokingChatClient` sólo emite sus spans si encuentra la fuente en el cliente interior. R-C07 se resolvió mirando la caché (V3 de N5: con la telemetría afuera se ven los aciertos), pero no miró las herramientas.
- **Impacto si no se corrige**: el lector arma la demo con el orden de la guía y en el Aspire Dashboard no ve qué herramienta pidió el modelo, con qué argumentos ni cuántas iteraciones hubo. Justo eso es lo que hay que mirar en D1 y D6 (CP alterado, baja sin confirmar).
- **Propuesta de dirección**: que el orden enseñado deje la telemetría **por dentro** de `UseFunctionInvocation` (`[caché] → límite → UseFunctionInvocation → UseOpenTelemetry → cliente`). Que la guía diga qué se pierde en cada posición y que, si además se quieren ver los aciertos de caché, se mida aparte (la doble capa con el mismo `sourceName` **no la probé**). Hay que reabrir R-C07, rehacer M8 y la nota de N2 P6 («un span por pedido» es exactamente lo que se pierde).

### SENIOR-02 — `ServiceLifetime.Scoped` sin separar el cliente interno crea un `HttpClient` por petición

- **Ubicación**: BIT-16-04 §3.2 R-C04 (l. 108), §6.3 M6 (l. 332) y M10 (l. 336); MI-23; snippets de composición N2 §4.5, N5 §4.1, N1 §4 (l. 238), con `AddChatClient(new OllamaApiClient(new Uri(...), ...))`.
- **Severidad**: S2 · **Evidencia**: E1 · **Capa**: integración (R-C04 resolvió el «qué» sin el «cómo»).
- **Afirmación**: R-C04 concluye bien que, con el cliente Singleton, la herramienta no resuelve el `SessionContext` de la petición. Pero la salida que propone («la demo usa Scoped») tiene un costo que ningún borrador nombra. Si la fábrica de `AddChatClient` crea el `OllamaApiClient` desde una `Uri`, cada scope (cada petición REST o cada circuito Blazor) crea **un `OllamaApiClient` y un `HttpClient` nuevos**, con el timeout por defecto de 100 s. En ningún núcleo aparecen `IHttpClientFactory` ni `AddHttpClient`.
- **Ancla** (`S-sonda1-salida.txt`, [S2]):
  ```text
  AddChatClient(fábrica con new OllamaApiClient(Uri), Scoped), 3 scopes → OllamaApiClient distintos = 3; HttpClient distintos = 3; timeout = 00:01:40
  Interno Singleton por clave + IHttpClientFactory, externo Scoped → OllamaApiClient distintos en 2 scopes = 1; timeout = 00:03:00
  Mismo patrón, scope sesion-A → la herramienta vio: sesion-A · scope sesion-B → sesion-B
  ```
- **Impacto si no se corrige**: el lector copia un patrón que abre y descarta conexiones en cada pedido (es el antipatrón clásico de `new HttpClient()` por operación) y que corta a los 100 s con paredes de 13–58 s por llamada (X2), sin ningún lugar dónde configurar el timeout que pide M10.
- **Propuesta de dirección**: que la guía enseñe el patrón que verifiqué: el **cliente del proveedor como Singleton por clave** (`AddKeyedSingleton<IChatClient>`), construido sobre un `HttpClient` de `IHttpClientFactory` con el timeout tomado de las opciones; el **pipeline externo** (`AddChatClient(sp => sp.GetRequiredKeyedService<IChatClient>(…), ServiceLifetime.Scoped)`) con `UseFunctionInvocation`; o, en su lugar, herramientas armadas por petición sobre un cliente Singleton (N6 §4.1). Va dentro del ADR de ciclo de vida (MI-23).

### SENIOR-03 — La página de chat Blazor no hereda la sesión: la copia de ApiWeb no la propaga al circuito

- **Ubicación**: BIT-16-04 §2 tensión 7 (l. 78), §6.2 (`UI`, `CTRL`), MI-05, MI-20; N6 Anexo A (l. 447, «API + página de chat Blazor») y su reparación (l. 593–595); contrato SUP-05.
- **Severidad**: S2 · **Evidencia**: E3, sobre código citado (E2) · **Capa**: integración (RA-4 y R-C19 se cruzan).
- **Afirmación**: la demo copia `Sessions/` de **ApiWeb**. Ahí `SessionContext` es de ámbito «una petición HTTP» y lo fija `SessionHeaderMiddleware` con `X-Sesion-Id`. En Interactive Server, los servicios Scoped del componente salen del **scope del circuito**, no del de la petición que pasó por el middleware. La Web del caso base lo resuelve con otro mecanismo, que no se copia: cookie `sesion-movilidad` → `App.razor` (`<Routes @rendermode="InteractiveServer" SessionId="@Session.Id" />`) → `Routes.razor` (`Contexto.Set(SessionId)`). Su `SessionContext` dice «una petición HTTP, **o un circuito de Blazor**»; el de ApiWeb sólo dice «una petición HTTP» (`S-caso-base-lectura.txt`).
- **Contraejemplo**: la persona carga Goya por `POST /api/v1/localidades` con `X-Sesion-Id: abc` y después, en la página de chat, pregunta «¿cuántas localidades hay en Corrientes?». El circuito tiene un `SessionContext` con el `Guid` provisorio del constructor, el `SessionSeeder` siembra un espacio nuevo y la herramienta cuenta los datos de otra sesión. Nada falla a la vista. Lo mismo pasa con la aprobación de D6: aprueba sobre otro conjunto de datos.
- **Impacto si no se corrige**: el medio móvil de MI-20 (G1, G2, G9 en el emulador) se verificaría sobre una sesión distinta de la del recorrido D1–D7, y la guía enseñaría a poner Blazor y controllers en el mismo host sin resolver la identidad.
- **Propuesta de dirección**: decidir la topología. O (a) la página vive en el mismo host y trae de la **Web** el mecanismo cookie + `Routes` como desvío declarado de la copia (con `PROCEDENCIA`), o (b) se arma un proyecto Web aparte que copia la Web, como en el caso base. Y escribir, para el componente, el patrón de streaming: `await foreach` sobre `GetStreamingResponseAsync`, `InvokeAsync(StateHasChanged)` y cancelación al desechar el componente. EF Core ya está bien resuelto para circuitos (ver «Bien», B-1).

### SENIOR-04 — El contrato HTTP del asistente no dice cómo sobrevive la aprobación entre dos peticiones

- **Ubicación**: N6 §1.3 C1 («`POST /api/v1/asistente` (streaming)»), N6 §4.4, N4 §4.3, BIT-16-04 R-C02, I-10, MI-14 (ESC-04), §6.2 `NEW`.
- **Severidad**: S2 · **Evidencia**: E2 (omisión) + E1 (reflexión de la API disponible) · **Capa**: núcleo N6 (Anexo A), heredado por la integración.
- **Afirmación**: todos los ejemplos de aprobación (N4 §4.3, N6 §4.4, E-B3) corren **en un mismo proceso y un mismo método**: `RunAsync` devuelve `ToolApprovalRequestContent` y en la línea siguiente se responde sobre la misma `AgentSession` en memoria. En la demo, la decisión la toma una persona **en otra petición HTTP** a un controller sin estado. Ningún borrador define dónde vive la `AgentSession` pendiente (clave: `X-Sesion-Id` y conversación), cómo vuelve el `RequestId` ni qué devuelve el endpoint de streaming cuando la corrida termina en una aprobación pendiente. Las piezas existen en las versiones fijadas (`S-sonda1-salida.txt`, [S3]): `AIAgent.SerializeSessionAsync(AgentSession, JsonSerializerOptions, CancellationToken) → ValueTask<JsonElement>`, `DeserializeSessionAsync(JsonElement, …)` y, para el streaming, `TypedResults.ServerSentEvents<T>(IAsyncEnumerable<T>, string eventType)` en ASP.NET Core 10.
- **Impacto si no se corrige**: cada implementador inventa un contrato distinto. Lo más probable es una sesión en un `static Dictionary` o una nueva corrida que vuelve a pedir la herramienta. Es retrabajo seguro en D1 y D6, que son los escenarios centrales de MI-14.
- **Propuesta de dirección**: que el Anexo A fije el contrato: (1) el evento o respuesta «aprobación pendiente» con id, herramienta y argumentos (G9); (2) un endpoint para aprobar o rechazar por id; (3) la sesión serializada en un almacén Scoped o `IDistributedCache` con clave sesión + conversación y vencimiento; (4) streaming por SSE (`TypedResults.ServerSentEvents`, que también se puede devolver desde un controller) o `IAsyncEnumerable<T>`. En la página Blazor la sesión puede vivir en el componente. La seguridad de ese almacén no es mía (ver solicitudes).

### SENIOR-05 — «Agregados por medio» no se traduce a SQL con el mapeo de `Medios` del caso base

- **Ubicación**: BIT-16-04 §2 tensión 3 (l. 74), MI-21, §6.2 `SVC` («ResultadosDeEncuestaService (nuevo, agregados)»); N6 §1.1 (l. 53), Anexo A (l. 451) y D4 («¿Qué medio usa más la gente?»).
- **Severidad**: S2 · **Evidencia**: E1 · **Capa**: núcleo N6 (caso de uso nuevo sin diseño de persistencia).
- **Afirmación**: en el caso base, `RespuestaDeEncuesta.Medios` es `IReadOnlyList<string>` y se persiste **como texto separado por comas** con un `ValueConverter` (`AppDbContext.cs`). Con EF Core Sqlite 10.0.14, el agregado «por medio» del lado del servidor **no traduce**. Además, `IEncuestaRepository` no tiene ninguna lectura que lo sostenga, y el plan no dice qué puerto ni qué consulta usa `ResultadosDeEncuestaService`.
- **Ancla** (`S-sonda4-salida.txt`, entidad y `OnModelCreating` transcritos del caso base):
  ```text
  [A SelectMany(Medios).GroupBy en el servidor] InvalidOperationException: The LINQ expression 'e => e.Medios' could not be translated …
  [B Count(e => e.Medios.Contains("colectivo"))] InvalidOperationException …
  [C GroupBy(Motivo) en el servidor] OK
  [D proyección sólo de Medios + agregado en memoria] OK → colectivo 2, bicicleta 1, auto 1
  [SQL de D] SELECT "e"."Medios" FROM "Encuestas" AS "e" WHERE "e"."SessionId" = 's'
  ```
- **Impacto si no se corrige**: el constructor de la demo escribe el `GroupBy` natural y le falla en ejecución. La salida rápida es traer la entidad entera (`ToListAsync()` con `Nombre` y `Edad`) y agrupar en memoria, y eso contradice MI-21 en la consulta, no sólo en lo que se devuelve.
- **Propuesta de dirección**: diseñar el caso de uso agregando, sin editar la copia: un puerto nuevo de lectura en `Application/Abstractions` (no se modifica `IEncuestaRepository`), su implementación EF Core en `Infrastructure/Persistence`, filtro por `SessionId`, `GroupBy` en el servidor para motivo y localidad, y **para medios, proyectar sólo la columna `Medios` y agregar en memoria** (D). Que la consulta nunca proyecte `Nombre` ni `Edad`, y que una prueba de `Cableado/` lo compruebe con `ToQueryString()`.

### SENIOR-06 — M10 dice «por configuración» sin mecanismo .NET, y la vía `/v1` no puede cumplirlo

- **Ubicación**: BIT-16-04 §6.3 M10 (l. 336), R-C08, R-C12 (l. 114), §3.3 I-1/I-2, MI-13, MI-17, MI-18; reparación de N6 §4.3 (l. 599); snippets N2 §4.5 y N5 §4.1 (`builder.Configuration["OLLAMA_ENDPOINT"]`), N4 §4.1 (`Environment.GetEnvironmentVariable`).
- **Severidad**: S2 · **Evidencia**: E1 + E4 + E2 · **Capa**: integración.
- **Afirmación**: M10 pide endpoint, modelo, dimensión, `num_ctx` y timeout por configuración, pero:
  1. **Dos convenciones sin puente**. Variables planas `OLLAMA_*`, que se leen como claves raíz o con `Environment.GetEnvironmentVariable`, junto a secciones jerárquicas `AI:Proveedor` y `Ayuda:Estrategia`. Ningún borrador tiene clase de opciones, *binding* ni validación al arrancar (`ValidateOnStart`), y `OLLAMA_ENDPOINT` no cae en la sección `AI`.
  2. **`num_ctx` sin vía .NET escrita**. En OllamaSharp 5.5.0 existen `ChatRequest.Options` (`RequestOptions.NumCtx : int?`, accesible por `RawRepresentationFactory`) y `OllamaOption.NumCtx` con `AbstractionMapper.TryAddOllamaOption` (`S-sonda3-salida.txt`, reflexión; que el segundo camino salga por `AdditionalProperties` **no lo verifiqué en el cable**).
  3. **Con `AI:Proveedor = OpenAICompatible`, M10 no se puede cumplir.** La doc de Ollama dice, literal: «The OpenAI API does not have a way of setting the context size for a model. If you need to change the context size, create a Modelfile…» (https://docs.ollama.com/api/openai-compatibility, consultada 2026-10-28; `S-ollama-openai-compat-2026-10-28.txt`). Crear un modelo en el servidor es una acción de REED-16 §12 tipo 4.
  4. **La dimensión no puede salir de configuración con el atributo.** El constructor es `VectorStoreVectorAttribute(Int32 dimensions)` y un argumento de atributo tiene que ser una constante. Hace falta `VectorStoreCollectionDefinition` con `VectorStoreVectorProperty(name, type, dimensions)` (`S-sonda1-salida.txt`, [S3]). Ojo: `BuscadorDeRequisitos.cs` de la integración ya lo hace bien, y toma la dimensión del primer vector del modelo.
- **Impacto si no se corrige**: con la vía `/v1` en la demo (MI-13), el control contra el truncado silencioso de X3 queda inaplicable sin aviso, y cada ejemplo lee la configuración a su manera.
- **Propuesta de dirección**: una clase de opciones única ligada a la sección `AI` (endpoint, modelo, modelo de embeddings, `num_ctx`, timeout, proveedor), con `AddOptions<…>().BindConfiguration("AI").ValidateDataAnnotations().ValidateOnStart()` y `localhost` por defecto (R-PRIV). Las variables `OLLAMA_*` quedan como alias declarados o se reemplazan por `AI__*`; la elección es de la mesa, pero tiene que ser una sola. Escribir la vía de `num_ctx` por OllamaSharp y declarar que por `OpenAICompatible` no hay `num_ctx` por pedido. Enseñar la dimensión con definición en tiempo de ejecución.

### SENIOR-07 — El Anexo A no cierra: la copia no compila sola y `Directory.Packages.props` no tiene fuente para lo que no es IA

- **Ubicación**: BIT-16-04 §2 tensión 7 y MI-05 («copia literal de Domain/, Application/, Controllers/ y Sessions/»); N6 Anexo A (l. 444 `Directory.Packages.props … (§3)`, l. 457) y Anexo B fila 09 (l. 494, «NUnit 4.x»).
- **Severidad**: S3 · **Evidencia**: E1 · **Capa**: núcleo N6 (Anexo A), arrastrado por la integración.
- **Afirmación**:
  1. **Cierre de compilación.** `Controllers/` usa `MovilidadUrbana.ApiWeb.Contracts` y `Sessions/SessionHeaderMiddleware.cs` usa `MovilidadUrbana.ApiWeb.Infrastructure.Sessions` (`S-caso-base-lectura.txt`). Sin `Contracts/` ni `Infrastructure/{Persistence, Sessions, DependencyInjection.cs}` (que §6.2 sí marca como «copia» para Persistence), la lista de MI-05 no compila. Además, una copia literal conserva los namespaces `MovilidadUrbana.ApiWeb.*` dentro de `MovilidadUrbana.Asistente`: es válido, pero hay que declararlo.
  2. **Versiones fuera de las tablas.** Las tablas de §3 (N2, N5, N6, X0) cubren la IA, EF Core y OTel, pero no las pruebas ni el hosting. Al 2026-10-28 (`S-nuget-2026-10-28.tsv`): **NUnit 5.0.0 es estable desde el 2026-09-27** (el Anexo B dice «4.x»; el caso base usa 4.3.2, `NUnit3TestAdapter` 5.0.0 y `Microsoft.NET.Test.Sdk` 17.14.0; hoy van 6.3.1 y 18.11.0); EF Core Sqlite y `Microsoft.AspNetCore.Mvc.Testing` están en 10.0.14 (el caso base, en 10.0.11); `Microsoft.Extensions.Http.Resilience` 10.11.0 GA. Las versiones de IA de X0 **siguen vigentes** (B-2).
- **Impacto si no se corrige**: el primer `dotnet build` de la demo falla, y cada constructor elige otra línea de NUnit o de EF Core.
- **Propuesta de dirección**: que la lista de copia de MI-05 sea el **cierre** real (Domain, Application, Contracts, Controllers, Sessions, Infrastructure/Persistence + Sessions + DependencyInjection) y se verifique con `dotnet build` además de `diff -r`. Que el Anexo D sume una fila por paquete de prueba y de hosting, con una decisión explícita: la línea del caso base (NUnit 4.x, último parche) o la vigente (5.0.0), con fecha.

---

## 2. Lo que revisé y está bien

- **B-1. EF Core y DI del caso base, bien elegidos para lo que viene.** `AddDbContextFactory<AppDbContext>` («Factory y no contexto de ámbito: un circuito de Blazor vive más que una petición») y repositorios Scoped que crean y desechan el contexto por operación. Sirve igual para controllers, circuitos y herramientas que ejecuta `FunctionInvokingChatClient`. Copiarlo literal es lo correcto. El diagnóstico de R-C04 con `ValidateScopes=true` (X1 [B]) es correcto y reproducible; mi sonda lo confirma desde el otro lado ([S2]).
- **B-2. Versiones y estado GA/preview de X0 vigentes; el camino por defecto no usa API experimental.** Re-consulté nuget.org a las 09:45 -03 del 2026-10-28: MEAI y MEAI.OpenAI 10.11.0, OpenAI 2.14.0, OllamaSharp 5.5.0, MEVD 10.11.0, InMemory 1.0.1, MAF y Workflows 1.26.0, MCP.AspNetCore 2.3.0 y OTel 1.20.1, todos estables. Siguen sólo en preview SqliteVec 1.0.3, DataIngestion y Agents.AI.Hosting (`S-nuget-2026-10-28.tsv`). Por reflexión, con control positivo: `ChatOptions.Reasoning`, `ReasoningOptions`, `ApprovalRequiredAIFunction`, `ToolApproval*Content`, `AIContextProvider` y `ChatClientAgentOptions.AIContextProviders` **no** llevan `[Experimental]` en estas versiones; los reducers e `IImageGenerator` sí (`MEAI001`) (`S-sonda2-salida.txt`). MI-12 es viable sin suprimir diagnósticos. Sugerencia menor: sacar `NoWarn MEAI001;MAAI001` de los `.csproj` de `Examples/`, para que el uso experimental se vea.
- **B-3. La forma MEAI del adaptador es idiomática.** Puerto en `Application/Abstractions` y adaptador que recibe `IChatClient` (RA-2). Herramientas como `AIFunction` finas sobre casos de uso que validan dentro de la función (R-C03). `GetResponseAsync<T>` con `TryGetResult` y camino sin IA (M4). Razonamiento por `ChatOptions.Reasoning`, independiente del proveedor (I-8). `MaximumIterationsPerRequest` explícito (M5): el valor por defecto medido es 40, y `MaximumConsecutiveErrorsPerRequest` es 3 (`S-sonda2-salida.txt`).

---

## 3. Posición sobre los MI de BIT-16-04 §5 que caen en mi mandato

| MI | Posición | Fundamento |
|---|---|---|
| MI-04 | propuesta | Con las capas como carpetas de un solo ensamblado, la regla se puede probar en NUnit por reflexión: ningún tipo de los namespaces `*.Domain`/`*.Application` referencia `Microsoft.Extensions.AI*`. Es más robusto que `grep` (no depende de `using`) y cabe en `Cableado/`. |
| MI-05 | otra | A favor de la copia literal y de `Controllers/`, **con dos condiciones** (SENIOR-07): que la lista sea el cierre de compilación (más `Contracts/` e `Infrastructure/{Persistence, Sessions, DependencyInjection}`), verificado con `dotnet build` además de `diff -r`; y que se declare que los namespaces siguen siendo `MovilidadUrbana.ApiWeb.*`. H1–H5 sin endurecer y normalización en el adaptador: de acuerdo. |
| MI-06 | propuesta | Idiomático: el adaptador de `Infrastructure/AI` es el único que conoce `IChatClient` y el formato del proveedor; un puerto de «armado de contexto» en Application filtraría tipos de MEAI o duplicaría el modelo de mensajes. |
| MI-07 | propuesta | Dos adaptadores de `IAyuda` elegidos por `Ayuda:Estrategia` se resuelven limpio con una fábrica o servicios con clave en la composición. Pido que la elección pase por la misma clase de opciones validada al arrancar (SENIOR-06). |
| MI-09 | propuesta | El paso `IChatClient` + `UseFunctionInvocation` → `AsAIAgent` sobre el mismo cliente y la misma `AIFunction` está verificado (E-B3, N6 [E5]) y es un diff chico real. Reescribir los genéricos con Movilidad Urbana no cambia nada técnico. |
| MI-12 | propuesta | Re-verificado hoy (B-2): el camino GA por defecto existe completo, sin API `[Experimental]`. SqliteVec sigue en preview y depende de `sqlite-vec` alpha y SQLitePCLRaw 3.x. |
| MI-13 | alternativa | El selector en la demo choca con M10/MI-18: por `/v1` no hay `num_ctx` por pedido (doc de Ollama, SENIOR-06). Mostrar el cambio de proveedor en los ejemplos 01 y 06, con prompts cortos y la limitación declarada, enseña lo mismo sin dejar inaplicable un control mínimo de la demo. Si la mesa lo quiere en la demo, que `OpenAICompatible` quede como variante declarada «sin `num_ctx`», nunca por defecto. |
| MI-15 | propuesta | Una constante única para `sourceName`, `AddSource` y `AddMeter` es lo correcto (X1 [A]). Queda condicionada a SENIOR-01: con el orden actual, el nombre coincide pero los spans de herramientas no salen igual. |
| MI-17 | otra | Validar sí, pero no como «dimensión de configuración en el atributo», que no compila (SENIOR-06.4). Propongo: definición de colección en tiempo de ejecución, dimensión **medida** del primer embedding al indexar (como `BuscadorDeRequisitos`) y comparada con la esperada de configuración. Fallar rápido en el arranque (servicio hospedado), y en `Cableado/` hacerlo con el generador falso. |
| MI-20 | propuesta | Coherente con SUP-05 (la demo cubre la web Blazor Interactive Server). Condicionada a SENIOR-03: sin resolver cómo llega la sesión al circuito, la página opera sobre otros datos. Pido que el patrón de streaming del componente quede escrito. |
| MI-23 | otra | Dentro de D-06, no como ADR aparte, pero con el contenido verificado en SENIOR-02 (proveedor Singleton por clave sobre `IHttpClientFactory`, pipeline Scoped, o herramientas por petición). El ciclo de vida es una consecuencia de D-06 (herramientas y sesión), no una decisión independiente. |
| MI-24 | abstención | Concurrencia y tiempos son de Operación y Rendimiento. Desde .NET sólo dejo el dato: hay mecanismos disponibles (SSE en ASP.NET Core 10, sesión serializable de MAF) que no condicionan la decisión. |

---

## 4. Solicitudes de convocatoria (fuera de mi mandato)

1. **AH-01 (seguridad).** El almacén de la aprobación pendiente que pide SENIOR-04 tiene como clave `X-Sesion-Id`, que en el caso base elige el cliente (hasta 64 caracteres, sin autenticación). Hay que juzgar si quien conoce o adivina otro id puede aprobar una baja ajena, y qué datos de la sesión serializada (argumentos de la herramienta, historial) se guardan.
2. **Operación y Rendimiento.** (a) Con SENIOR-01 cambia qué spans existen: M8 tiene que decir cuáles exige. (b) N5 §4.2 usa `ConcurrencyLimiter` con `QueueLimit = int.MaxValue`: con `OLLAMA_NUM_PARALLEL=1` y 13–58 s por llamada, la cola no tiene techo y el rechazo se vuelve `InvalidOperationException` (un 500). Hay que juzgar si M9 necesita una cola acotada y un 429.
