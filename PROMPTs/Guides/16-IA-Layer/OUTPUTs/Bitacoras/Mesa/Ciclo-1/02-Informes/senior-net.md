---
doc_id: BIT-16-MESA-C1-INF-SENIOR-NET
doc_type: informe-de-especialista
rol: Desarrollador senior .NET (pedido por el PO)
objeto: BIT-16-04 Plan de integración v0
ciclo: 1 (a ciegas)
fecha: 2026-10-26
---

# Informe del especialista: Desarrollador senior .NET

**Mandato**: ¿lo que se propone enseñar es idiomático y vigente en .NET 10? Paquetes y versiones, DI, configuración, async, abstracciones de M.E.AI, MAF, SK, EF Core, Blazor y API, y las trampas reales.

**Objeto**: `04-Plan-De-Integracion.md` (v0), contrastado con N2, N4, N5, N6, el Sondeo-Entorno y los insumos I-01 a I-06.

**Evidencia propia (E1)**. Todo se reproduce sin compilar y sin tocar el servidor de la LAN. Trabajé en un directorio fuera del repo, dentro del scratchpad de la sesión:

- `curl https://api.nuget.org/v3-flatcontainer/<id>/index.json` para conocer las últimas estables al 2026-10-26, y `registration5-gz-semver2` para las fechas.
- Bajé y descomprimí los `.nupkg` de `ollamasharp` 5.5.0, `microsoft.extensions.ai` y `.abstractions` 10.11.0, `microsoft.extensions.http.resilience` 10.11.0, `microsoft.agents.ai` 1.26.0, `modelcontextprotocol` y `.core` 2.3.0, `aspire.projecttemplates` 13.6.4 y `microsoft.aspnetcore.app.ref` 10.0.14. Después leí sus `.nuspec` (grupo `net10.0`), su XML de documentación y el contenido de las plantillas.

Resultados que cito abajo:

- **Últimas estables**: Microsoft.Extensions.Hosting 10.0.14; EF Core Sqlite 10.0.14; Caching.Memory 10.0.14; NUnit **5.0.0** (2026-09-27); NUnit3TestAdapter **6.3.1** (2026-10-09); Microsoft.NET.Test.Sdk **18.11.0**; MEAI, Evaluation, VectorData y Http.Resilience 10.11.0; MAF 1.26.0; MCP 2.3.0; OpenTelemetry 1.20.1; OllamaSharp 5.5.0.
- **Dependencias `net10.0` de `Microsoft.Agents.AI` 1.26.0**: MEAI 10.10.0, MEAI.Abstractions 10.10.1, MEAI.Evaluation 10.10.0, Compliance.Abstractions 10.10.0, VectorData.Abstractions 10.10.0, DependencyInjection.Abstractions y Logging.Abstractions 10.0.12, ML.Tokenizers 2.0.0.
- **Dependencias de `ModelContextProtocol` 2.3.0**: Hosting.Abstractions y Caching.Abstractions 10.0.13. `ModelContextProtocol.Core` 2.3.0 depende de MEAI.Abstractions 10.11.0.
- **OllamaSharp 5.5.0**: trae `OllamaSharp.ChatOptionsExtensions.AddOllamaOption(ChatOptions, OllamaOption, object)`, que el XML documenta así: «Adds Ollama specific options to the additional properties of ChatOptions… like OllamaOption.NumCtx for the option 'num_ctx'». También trae `AbstractionMapper.TryAddOllamaOption`, que «Tries to find Ollama options in the additional properties». `OllamaOption` **no** tiene `KeepAlive`: `KeepAlive` existe sólo en `ChatRequest`/`EmbedRequest`.
- **MEAI 10.11.0**: `AddChatClient(IServiceCollection, IChatClient, ServiceLifetime lifetime = Singleton)`. `FunctionInvokingChatClient(IChatClient, ILoggerFactory, IServiceProvider functionInvocationServices)`. `AllowConcurrentInvocation`: «The default value is false». `ChatResponse<T>.TryGetResult(out T)` existe.
- **Http.Resilience 10.11.0**: `HttpStandardResilienceOptions.AttemptTimeout` usa un «custom Timeout of 10 seconds». La plantilla `aspire-servicedefaults/Extensions.cs` (13.6.4) hace `builder.Services.ConfigureHttpClientDefaults(http => { http.AddStandardResilienceHandler(); … })`.
- **ASP.NET Core 10.0.14**: `TypedResults.ServerSentEvents(IAsyncEnumerable<T>, string)` y la sobrecarga con `SseItem<T>`. El XML de `IHttpContextAccessor` dice: «This interface should be used with caution… It also creates a dependency on "ambient state"».

## Hallazgos (M§8)

### H-SN-01 · S2 · E3 · confianza 0,8 — La sesión de la página Blazor no la resuelve el middleware

- **Ubicación**: §F.5, primer punto; §F.2, fila «MovilidadUrbana.Web (Blazor Interactive Server)»; §F.3 (`BZ --> PT`).
- **Afirmación**: el plan dice que la sesión de la página Blazor llega «por la cookie del circuito» y que la resuelve `SessionHeaderMiddleware` → `ISessionContext` scoped. En Interactive Server, el scope de DI de los componentes es el del **circuito**, que se crea sobre la conexión SignalR. No es el scope de la petición HTTP que atraviesa el middleware. Además, `HttpContext` no es una fuente fiable dentro de un componente interactivo.
- **Contraejemplo**: la persona abre la página de chat. El componente usa `IAsistenteDeMovilidad`, y las herramientas se arman «por petición» desde el scope del circuito. El `ISessionContext` de ese circuito nunca pasó por el middleware. Según N6 (corrección de §4.5), el middleware «corre siempre; sin encabezado, la petición recibe una sesión nueva». Resultado: `listar_localidades` ve una sesión vacía o ajena a la de la API. La prueba Q4 (dos sesiones concurrentes) sólo recorre el camino de la API, así que no lo detecta.
- **Ancla**: «La sesión llega por `X-Sesion-Id` (API) o por la cookie del circuito (página Blazor) y la resuelve `SessionHeaderMiddleware` → `ISessionContext` scoped (N6 F05).»
- **Impacto**: la demo enseñaría un aislamiento que en la página no se cumple. Además, «herramientas por petición» (T1) significa en Blazor «por circuito», y el plan no lo distingue.
- **Dirección**: definir cómo se fija la identidad mínima en el circuito, por ejemplo con un valor capturado en el render inicial y entregado al estado del circuito, o con un `CircuitHandler`. Decir en la guía que en Interactive Server el scope es el circuito. Extender la prueba de sesión ajena (PR-20, AC-4) al camino Blazor.

### H-SN-02 · S2 · E1 · confianza 0,85 — D-03 tiene respuesta: `num_ctx` se pasa por `IChatClient`

- **Ubicación**: §G.3 D-03; §E.1 «`num_ctx`»; §E.3 fila `12` (alternativa con `HttpClient` a `/api/chat`); §G.2 R-03.
- **Afirmación**: el plan da por no verificado cómo pasar `num_ctx` desde `IChatClient` con OllamaSharp 5.5.0, y prevé bajar a HTTP crudo. El paquete trae la vía: `ChatOptions.AddOllamaOption(OllamaOption.NumCtx, n)`, que escribe en `AdditionalProperties`, y el mapeador de OllamaSharp lo lee de ahí. `keep_alive` **no** está en `OllamaOption`.
- **Ancla**: XML de OllamaSharp 5.5.0, `M:OllamaSharp.ChatOptionsExtensions.AddOllamaOption(...)`: «The Ollama option to set, like OllamaOption.NumCtx for the option 'num_ctx'».
- **Impacto**: si se mantiene el camino alternativo, `12` deja de mostrar el contrato que la guía enseña, y la mitigación de R-03 (el truncado silencioso, que afecta a **todos** los ejemplos) queda fuera del pipeline de M.E.AI.
- **Dirección**: cerrar D-03 con esta vía y confirmarla con una corrida que compare `prompt_eval_count` con y sin la opción. Fijarla en el adaptador o en un `ConfigureOptions` del pipeline, nunca en Application. Dejar `keep_alive` como pregunta abierta: ¿OllamaSharp respeta `RawRepresentationFactory` para setear `ChatRequest.KeepAlive`? No lo verifiqué.

### H-SN-03 · S2 · E1 · confianza 0,85 — Central Package Management sin fijar transitivos no da «versiones alineadas»

- **Ubicación**: §E.1 «Versiones … con Central Package Management, por la mezcla que arrastra MAF: N6 T4»; §F.8 `Cableado/` («versiones alineadas (`dotnet list package --include-transitive` sin M.E.AI/MEVD mezclados)»); §F.3 (última línea); AC-6.
- **Afirmación**: `Microsoft.Agents.AI` 1.26.0 (`net10.0`) arrastra MEAI.Evaluation 10.10.0, VectorData.Abstractions 10.10.0, Compliance.Abstractions 10.10.0 y MEAI.Abstractions 10.10.1. Central Package Management sin `CentralPackageTransitivePinningEnabled` sólo gobierna las referencias directas. En `07`, `14`, `17` o en la demo, que referencian MAF pero no Evaluation, la restauración deja Evaluation 10.10.0 junto a MEAI 10.11.0. La prueba de cableado que el plan exige falla, o hay que debilitarla.
- **Ancla**: nuspec de `microsoft.agents.ai` 1.26.0, grupo `net10.0`: `Microsoft.Extensions.AI.Evaluation 10.10.0`, `Microsoft.Extensions.VectorData.Abstractions 10.10.0`, `Microsoft.Extensions.AI.Abstractions 10.10.1`.
- **Impacto**: AC-6 y Q7 son inalcanzables tal como están escritos, o se «cumplen» dejando fuera los transitivos. Habría retrabajo en la construcción.
- **Dirección**: declarar en `Examples/` y en `Demos/` el pinning de transitivos de CPM, listar en `Directory.Packages.props` los transitivos de la familia (Evaluation, VectorData.Abstractions, Compliance.Abstractions) y que la prueba de versiones lo verifique por nombre.

### H-SN-04 · S2 · E1 · confianza 0,9 — Versiones fijadas atrasadas

- **Ubicación**: §E.1, tabla de versiones, filas `Microsoft.Extensions.Hosting` y `NUnit · NUnit3TestAdapter · Microsoft.NET.Test.Sdk`; §G.3 D-07.
- **Afirmación**: el plan fija Hosting **10.0.0** («la que compiló en N4 V01») mientras el resto de `Microsoft.Extensions.*` va en 10.0.14, y MAF y MCP ya exigen 10.0.12 y 10.0.13 en sus abstracciones. Así quedan mezclados parches del mismo tren. La pila de pruebas está dos versiones mayores atrás: NUnit 4.3.2 frente a 5.0.0 (2026-09-27), el adaptador 5.0.0 frente a 6.3.1 y Test.Sdk 17.14.0 frente a 18.11.0. D-07 lo duda, pero la tabla igual las presenta como las versiones a fijar.
- **Ancla**: nuget.org flatcontainer, 2026-10-26: `microsoft.extensions.hosting` → 10.0.14; `nunit` → 5.0.0; `nunit3testadapter` → 6.3.1; `microsoft.net.test.sdk` → 18.11.0. Plan: «`Microsoft.Extensions.Hosting` | 10.0.0 (la que compiló en N4 V01)».
- **Impacto**: una guía de octubre de 2026 enseñaría una pila de pruebas vieja. Con NUnit 5, que es versión mayor, la elección no es neutra: si se alinea más tarde hay retrabajo en `15` y en `tests/`.
- **Dirección**: alinear `Microsoft.Extensions.*` al último parche común del tren 10.0 y no referenciar Hosting en proyectos `Microsoft.NET.Sdk.Web`, que lo traen del framework compartido. Llevar a la mesa, como decisión explícita, si se usa NUnit 4.x (fiel al caso base) o 5.x (vigente), con su costo, en lugar de dejarlo implícito en una tabla.

### H-SN-05 · S3 · E1 · confianza 0,75 — Los timeouts largos se pierden con el handler de resiliencia por defecto

- **Ubicación**: §E.1 «Timeouts: `HttpClient` de 5 a 10 minutos»; §F.9; §C §12.7 (Aspire).
- **Afirmación**: el plan no dice cómo se fija el timeout en cada adaptador ni cómo entra el `HttpClient` en DI. Si el `HttpClient` de OllamaSharp sale de `IHttpClientFactory` y se aplican los ServiceDefaults de Aspire (§12.7), la plantilla agrega `AddStandardResilienceHandler()` a **todos** los clientes, y ese handler corta cada intento a los 10 s. Las llamadas medidas en el Sondeo tardan entre 11 y 200 s: se cortarían, y los reintentos reenviarían el prompt al servidor compartido, que corre en CPU.
- **Ancla**: plantilla `aspire-servicedefaults/Extensions.cs` (Aspire.ProjectTemplates 13.6.4): `ConfigureHttpClientDefaults(http => { http.AddStandardResilienceHandler(); …})`. XML de Http.Resilience 10.11.0, `AttemptTimeout`: «custom Timeout of 10 seconds».
- **Impacto**: es una falla difícil de diagnosticar justo en la sección que enseña a operar, y suma carga a un recurso compartido (R-01, R-04).
- **Dirección**: especificar el timeout por adaptador (en OllamaSharp, `HttpClient.Timeout`; en el SDK OpenAI, `NetworkTimeout` más su política de reintentos) y advertir que el handler estándar hay que ajustarlo o excluirlo para el cliente del modelo. Pregunta (C): ¿qué reintentos aplica por defecto el SDK `OpenAI` 2.14.0 ante un timeout, y conviene apagarlos contra el servidor compartido?

### H-SN-06 · S3 · E1 · confianza 0,7 — El endpoint de streaming no tiene formato ni estilo definidos

- **Ubicación**: §F.3, nodo `EP` («asistente (streaming)»); §F.2, fila «Controllers de `/api/v1` → **Copia mínima** … como endpoints»; §C §5.2.
- **Afirmación**: el plan no dice qué formato usa el streaming por HTTP, y es ambiguo entre copiar los controllers del caso base y escribir Minimal APIs. ASP.NET Core 10 trae `TypedResults.ServerSentEvents(IAsyncEnumerable<T>)`, el idioma vigente para empujar `ChatResponseUpdate` al cliente.
- **Ancla**: XML de `Microsoft.AspNetCore.App.Ref` 10.0.14: `M:Microsoft.AspNetCore.Http.TypedResults.ServerSentEvents``1(System.Collections.Generic.IAsyncEnumerable{``0},System.String)`. Plan: «Endpoints /api/v1 … asistente (streaming)».
- **Impacto**: cada constructor puede resolverlo distinto (JSON en streaming, SSE a mano, texto plano), con retrabajo. Además se pierde mostrar un idioma propio de .NET 10.
- **Dirección**: elegir y declarar el formato (SSE con `ServerSentEvents`) y el estilo de endpoint (controllers fieles al caso base o Minimal API), con su motivo. Exigir que el `CancellationToken` de la petición llegue a `GetStreamingResponseAsync`, para que el cliente que se va libere el turno del servidor.

### H-SN-07 · S3 · E2 · confianza 0,8 — `AIEVAL001` como ejemplo de supresión no corresponde a `15`

- **Ubicación**: §E.1 «Build: … Sin `NoWarn` salvo los diagnósticos experimentales documentados que el ejemplo use (p. ej. `AIEVAL001` en `15`)»; §E.4, fila `15`.
- **Afirmación**: `15` usa `RelevanceEvaluator` y `GroundednessEvaluator`, y según N5 (V7) esos dos no son experimentales. `AIEVAL001` aparece sólo en `IntentResolutionEvaluator`, `TaskAdherenceEvaluator`, `ToolCallAccuracyEvaluator` y `RelevanceTruthAndCompletenessEvaluator`. El ejemplo invita a una supresión sin motivo.
- **Ancla**: N5 §2: «en el ensamblado 10.11.0 los tres orientados a agentes también llevan `[Experimental("AIEVAL001")]` (V7)». Plan §E.4 `15`: «`RelevanceEvaluator` y `GroundednessEvaluator` con juez local».
- **Impacto**: enseña a suprimir un diagnóstico de forma preventiva, que es justo el antipatrón que AC-1 quiere evitar.
- **Dirección**: sacar `AIEVAL001` del ejemplo de §E.1, salvo que `15` sume un evaluador experimental. Pregunta para la mesa: ¿se suma `ToolCallAccuracyEvaluator`, que evalúa justamente lo que enseñan `05` y `07`? Si se suma, la supresión va acotada al archivo (`#pragma`) y no como `NoWarn` del proyecto.

## Posición sobre las propuestas de mi mandato

| PR | Posición | Fundamento |
|---|---|---|
| PR-3 | apoya | Una consola `net10.0` por concepto, cada una con modo falso, es lo idiomático para aislar APIs. La demo integra. Condición: H-SN-03 (fijar transitivos), porque con 17 proyectos la deriva de versiones es segura. |
| PR-5 | apoya_con_cambios | El reordenamiento por autonomía es defendible. En MAF, sin embargo, el workflow (`WorkflowBuilder`, `[MessageHandler]`, `Workflows.Generators`) es **más** API que `AsAIAgent`. Hay que decir que el escalón mide autonomía y no dificultad de código, para que el lector no espere que el escalón 2 sea más fácil de programar que el 3. |
| PR-11 | apoya_con_cambios | Bien como sección visible. Para el camino mínimo, pregunta (C): ¿se evaluó `dotnet publish /t:PublishContainer` del SDK en lugar de un `Dockerfile` multietapa? Resolvería D-05 sin depender de la etiqueta de runtime. Sumar el ajuste de timeouts y reintentos (H-SN-05). |
| PR-16 | apoya | La forma operativa se programa con APIs verificadas en 10.11.0: `ChatResponse<T>.TryGetResult`, `ApprovalRequiredAIFunction`, herramientas sobre servicios, y la sesión puesta por el código (salvo H-SN-01). |
| PR-18 | apoya | El inventario de M.E.AI y MAF que ya resuelve el bucle, la aprobación, los checkpoints y la orquestación está verificado (N2 §2.7, N4 §2.1–§2.9). Construir un marco propio no es idiomático en .NET 10. |
| PR-19 | apoya | Las versiones y estados de las filas coinciden con nuget.org al 2026-10-26 (MEAI 10.11.0, MAF 1.26.0, SK 1.81.0, OpenAI 2.14.0). Sumar «LangGraph por HTTP» es correcto si se marca como no ejecutado. |
| PR-20 | apoya_con_cambios | La herramienta de sólo lectura con negativas es el primer ejercicio correcto. La prueba de sesión ajena tiene que cubrir también el camino Blazor (H-SN-01). |
| PR-22 | apoya | Compila en N4 V01, con la trampa real de `FunctionCallContent` ambiguo, y el par `[KernelFunction]` ↔ `[Description]` + `AIFunctionFactory` es la migración documentada (F29). |

## Revisado y está bien

1. La superficie de M.E.AI 10.11.0 que el plan usa existe tal cual: `ChatResponse<T>.TryGetResult`, `ChatOptions.Reasoning` con `ReasoningEffort.None` como abstracción y no como propiedad del proveedor, y `AddChatClient` con `ServiceLifetime`. `AllowConcurrentInvocation` es `false` por defecto, así que las herramientas se ejecutan en serie y no comparten el `DbContext` scoped en paralelo.
2. Los nombres de MAF coinciden con lo verificado en N4 para 1.26.0 y evitan los de las previews: `AsAIAgent`, `AgentSession`, `ToolApprovalRequestContent` con `CreateResponse`, `BindAsExecutor`, el paquete `Workflows.Generators` y el `CS0534`.
3. La elección de proveedor es la vigente: OllamaSharp 5.5.0 como vía principal, `Microsoft.Extensions.AI.OpenAI` 10.11.0 para mostrar el cambio de proveedor, y fuera el deprecado `Microsoft.Extensions.AI.Ollama`. `Domain/` queda sin M.E.AI, y `ModelContextProtocol.Core` 2.3.0 ya depende de MEAI.Abstractions 10.11.0, en línea con el resto.

## Solicitudes de convocatoria

- **Operación e infraestructura**: definir la política de reintentos y timeouts contra el servidor de modelos compartido y su relación con el gestor de turnos (`<recurso-compartido>`). Excede la idiomaticidad .NET (H-SN-05).
- **Seguridad**: validar si la identidad mínima en el circuito Blazor (H-SN-01) y la sesión fija de MCP alcanzan para lo que la guía promete sobre aislamiento.
