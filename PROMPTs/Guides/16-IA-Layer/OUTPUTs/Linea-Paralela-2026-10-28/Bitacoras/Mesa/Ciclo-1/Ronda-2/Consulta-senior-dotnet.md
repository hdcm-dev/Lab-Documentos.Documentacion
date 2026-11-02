---
doc_id: BIT-16-C1R2-CON-senior-dotnet
doc_type: consulta-dirigida
title: Consulta dirigida al Senior .NET — PC-01, PC-03, PC-04, PC-05, PC-09
status: hecho
origin: agent
owner: especialista Senior .NET (panel del ciclo 1)
last_review: 2026-10-28
audience: [presidencia, jurado de la ronda 2, redacción]
traces: [Mesa/Ciclo-1/07-Dictamen-Presidencia.md §3.3, Mesa/Ciclo-1/01-Consolidado.md (C1-11, C1-16, C1-21, C1-28, C1-34; tabla C), Mesa/Ciclo-1/03-Parches.md (P-01, P-11, P-19), Nucleos/N3b §0.3, Nucleos/N4 §4, Nucleos/N6 §2 y §4.5]
---

# Consulta dirigida al Senior .NET — ciclo 1, ronda 2

**Mandato.** Lo fija el dictamen de la presidencia, §3.3: resolver como consulta dirigida las preguntas C que me tocan (PC-01, PC-03, PC-04, PC-05 y PC-09), con experimentos cuando hagan falta. No voto ítems. Al final de cada respuesta digo qué cambia para los ítems del jurado.

**Cómo trabajé.** Corrí cuatro sondas en `mcr.microsoft.com/dotnet/sdk:10.0` (SDK 10.0.403, runtime 10.0.14):

- tres sin modelo, por el recurso `build`;
- una contra el servidor Ollama de la LAN del laboratorio, por el recurso `<recurso-compartido>`, con el endpoint pasado sólo como `OLLAMA_ENDPOINT`.

En las pruebas del cuerpo HTTP, el servidor falso es un Kestrel en loopback con puerto efímero. Registra encabezados y cuerpo tal como llegan por el socket, no lo que la aplicación cree que manda.

Paquetes vigentes en nuget.org a las 12:22 -03 (sin cambios respecto de las 09:45): ModelContextProtocol(.AspNetCore) 2.3.0, OllamaSharp 5.5.0, Microsoft.Extensions.AI(.OpenAI) 10.11.0, Microsoft.Agents.AI 1.26.0 y OpenAI 2.14.0. La evidencia cruda está en [`evidencia-senior-dotnet/`](evidencia-senior-dotnet/README.md).

## Resumen

| Pregunta | Respuesta corta | Nivel |
|---|---|---|
| PC-01 | `AllowedHosts` funciona: el HostFiltering que ya registra `WebApplication.CreateBuilder` lo lee de la configuración, y con un Host ajeno responde 400. `MapMcp("/mcp").RequireAuthorization()` compila y da 401 sin token y 200 con token. **El SDK 2.3.0 no valida `Origin`**, aunque la especificación MCP lo exige («MUST»): hay que agregar un middleware, que probé (403). | E1 + E4 |
| PC-03 | **No es un artefacto de la sonda.** OllamaSharp 5.5.0 serializa `OllamaRequest.<clave-de-cabeceras>` en el cuerpo JSON de `/api/chat` y `/api/embed`, porque esa propiedad no tiene `[JsonIgnore]`. Con `DefaultRequestHeaders` o con encabezados en el `HttpClient`, el cuerpo lleva `{}`. Con `ChatRequest.<clave-de-cabeceras>` (por pedido), el **valor** del encabezado va dos veces: como encabezado HTTP y dentro del cuerpo. | E1 |
| PC-04 | **No** (confirmado contra el servidor real: 706 tokens cacheados informados por Ollama, `null` en .NET). OllamaSharp 5.5.0 descarta `prompt_eval_cached_count`: `ChatDoneResponseStream` no tiene esa propiedad ni `[JsonExtensionData]`. Por eso `CachedInputTokenCount` queda `null` y no aparece en `AdditionalCounts`, ni en `RawRepresentation`, ni en streaming. Hay dos caminos: un `DelegatingHandler` que lee la última línea de `/api/chat`, o la vía `/v1`, donde Ollama 0.40.11 sí devuelve `cached_tokens` y MEAI.OpenAI llena `CachedInputTokenCount` (probado). | E1 + R-LLM |
| PC-05 | **OllamaSharp traduce los tres** (y además `FrequencyPenalty`, `Seed` y `MaxOutputTokens`) a `options.top_p`, `top_k` y `presence_penalty`. **Por `/v1`, MEAI.OpenAI traduce `TopP` y `PresencePenalty`, pero descarta `TopK` en silencio**, aunque se mande en `AdditionalProperties`. Sólo llega con `RawRepresentationFactory` + `ChatCompletionOptions.Patch`, y la doc de Ollama no lista `top_k` entre los campos de `/v1`. Además, por `/v1`, `MaxOutputTokens` → `max_completion_tokens` **no tiene efecto** con Ollama 0.40.11 (pedí 3 y salieron 57). | E1 + E4 + R-LLM |
| PC-09 | La fuente única es un `AIFunction` creado con `AIFunctionFactory.Create(MethodInfo, createInstanceFunc, options)`. El servidor lo publica con `McpServerTool.Create(AIFunction, McpServerToolCreateOptions)` y `WithTools(IEnumerable<McpServerTool>)`. El esquema que ve un cliente MCP real es **idéntico byte a byte** al `JsonSchema` del `AIFunction`. La misma lista sirve a `IChatClient` + `UseFunctionInvocation` y a `ChatClientAgent`, y cada lado resuelve el `SessionContext` de su propio scope. Paquetes: ModelContextProtocol.AspNetCore 2.3.0, MEAI 10.11.0 y MAF 1.26.0. | E1 |

---

## PC-01 · `AllowedHosts` y `RequireAuthorization()` sobre `MapMcp`

**Pregunta (C1-28; AH-01 «Yo no lo compilé: es C»).** ¿Cómo se restringe `AllowedHosts` y se aplica `RequireAuthorization()` sobre `MapMcp` en ModelContextProtocol.AspNetCore 2.3.0?

**Versión.** La 2.3.0 sigue siendo la última publicada (`R2-nuget-2026-10-28.txt`, 12:22 -03). `MapMcp(IEndpointRouteBuilder, String)` devuelve `IEndpointConventionBuilder` (`R2-reflex-salida.txt`), así que admite `RequireAuthorization()` como cualquier endpoint de ASP.NET Core.

**Experimento** (`R2-mcp-Program.cs`, salida en `R2-mcp-salida.txt`). Levanté una app en `127.0.0.1` con `AddMcpServer().WithHttpTransport(o => o.Stateless = true).WithTools(...)` y un esquema de autenticación de demostración que compara el token con `Mcp:Token`. Le mandé un `initialize` real por POST:

| Configuración | Pedido | Resultado |
|---|---|---|
| `AllowedHosts="localhost;127.0.0.1"` + `MapMcp("/mcp").RequireAuthorization()` | sin token | **401** |
| | token incorrecto | **401** |
| | token correcto | **200** (`initialize` responde) |
| | `Host: atacante.example` + token correcto | **400** (HostFiltering) |
| | `Host: localhost` + token correcto | 200 |
| Control (como N6 §4.5 hoy): `AllowedHosts="*"`, sin `RequireAuthorization` | `Host: atacante.example`, sin token | **200** |
| | idem + `Origin: http://atacante.example` | **200** |
| `AllowedHosts` restringido, sin auth | `Host` válido + `Origin` ajeno | **200**: el SDK no valida `Origin` |
| `AllowedHosts` restringido + middleware de `Origin` + `RequireAuthorization` | `Origin` ajeno + token | **403** |
| | `Origin` permitido + token | 200 |
| | sin `Origin` (cliente que no es navegador) + token | 200 |

En el endpoint queda registrada `IAuthorizeData=1` (metadata de autorización) para `/mcp/`.

**Respuesta.** El patrón compila y se comporta como se espera:

```csharp
// appsettings: "AllowedHosts": "localhost;127.0.0.1"   (HostFiltering ya está en WebApplication.CreateBuilder)
builder.WebHost.UseUrls("http://127.0.0.1:0");          // loopback por defecto; el puerto, por configuración
builder.Services.AddAuthentication(/* esquema real en CTX-PROD */).AddScheme<...>(...);
builder.Services.AddAuthorization();
builder.Services.AddMcpServer().WithHttpTransport(o => o.Stateless = true).WithTools(...);
var app = builder.Build();
app.UseWhen(c => c.Request.Path.StartsWithSegments("/mcp"), r => r.Use(async (c, next) =>
{   // MCP 2025-06-18: «Servers MUST validate the Origin header». El SDK 2.3.0 no lo hace.
    var origin = c.Request.Headers.Origin.ToString();
    if (origin.Length > 0 && !permitidos.Contains(origin, StringComparer.OrdinalIgnoreCase)) { c.Response.StatusCode = 403; return; }
    await next();
}));
app.UseAuthentication(); app.UseAuthorization();
app.MapMcp("/mcp").RequireAuthorization();
```

Tres precisiones:

1. **`AllowedHosts` no es una opción del SDK de MCP.** Lo aplica el `HostFilteringMiddleware` de ASP.NET Core, que `WebApplication.CreateBuilder` registra y que lee la clave `AllowedHosts`. Con `WebApplication.CreateSlimBuilder` no viene registrado. Esta última afirmación no la probé en esta ronda: queda **[C: a verificar]** si la demo usara el builder *slim*.
2. **Falta la validación de `Origin`.** La especificación del transporte Streamable HTTP dice: «Servers MUST validate the Origin header on all incoming connections to prevent DNS rebinding attacks … When running locally, servers SHOULD bind only to localhost … Servers SHOULD implement proper authentication» (https://modelcontextprotocol.io/specification/2025-06-18/basic/transports, consultada el 2026-10-28; `R2-mcp-spec-transports-origin.txt`). Con 2.3.0, un `Origin` ajeno con `Host` válido pasa (caso [C]). `AllowedHosts` cubre el rebinding clásico, en el que el `Host` es el dominio del atacante, pero la regla «MUST» del protocolo pide además validar `Origin`. Eso lo hace un middleware de la app.
3. **Hay autorización por herramienta.** 2.3.0 trae `HttpMcpServerBuilderExtensions.AddAuthorizationFilters` y un esquema `AddMcp(...)` (`McpAuthenticationHandler`, metadatos de recurso protegido OAuth). Lo verifiqué sólo por reflexión (`R2-mcp-salida.txt` [D]–[F]), sin probar su comportamiento.

**Consecuencia para los ítems del jurado.**

- **C1-28 (M13).** La propuesta de M13 («loopback por defecto, `AllowedHosts` restringido por configuración, autenticación en CTX-PROD») queda **verificada por compilación y corrida**: ya no es C. Hay que **agregar a M13 la validación de `Origin`** (middleware, 403), porque el SDK no la hace y la especificación la exige.
- La aserción de M13 en `Cableado/` puede ser la misma tabla de arriba: 400 con un Host ajeno, 401 sin token y 403 con un Origin ajeno.
- La fila de N4 l. 540 («`AllowedHosts="*"`… DNS rebinding») se completa con «y sin validar `Origin`».
- Si gana ABOGAD-01 (C1-40) y M13 va a `Examples/08`, este snippet es el de ese ejemplo.

---

## PC-03 · `<clave-de-cabeceras>` en el cuerpo JSON

**Pregunta (C1-11, C1-01; P-11 verificación (4), P-01).** ¿La clave `<clave-de-cabeceras>` que aparece en el cuerpo de `POST /api/chat` y `/api/embed` (captura de E-B2b) es un artefacto de la sonda, o OllamaSharp 5.5.0 serializa encabezados de la app en el cuerpo?

**Experimento** (`R2-cuerpo-Program.cs`, salida en `R2-cuerpo-salida.txt`, §PC-03). El servidor falso captura los encabezados HTTP y el cuerpo en el socket:

| Caso | Encabezado HTTP recibido | Cuerpo recibido |
|---|---|---|
| [A] cliente sin encabezados | — | `…"stream":false,"<clave-de-cabeceras>":{}}` |
| [B] `OllamaApiClient.DefaultRequestHeaders["X-Prueba-Clave"]` | `X-Prueba-Clave: VALOR-SENSIBLE-DE-PRUEBA` | `"<clave-de-cabeceras>":{}` |
| [C] `ChatRequest.<clave-de-cabeceras>["X-Por-Pedido"]` (por `RawRepresentationFactory`) | `X-Por-Pedido: VALOR-POR-PEDIDO` | **`"<clave-de-cabeceras>":{"X-Por-Pedido":"VALOR-POR-PEDIDO"}`** |
| [D] embeddings con `DefaultRequestHeaders` | `X-Prueba-Clave: …` | `{"model":"emb-x","input":["texto"],"options":null,"<clave-de-cabeceras>":{}}` |
| [E] encabezado en `HttpClient.DefaultRequestHeaders` | `X-Prueba-Clave: VALOR-EN-HTTPCLIENT` | `"<clave-de-cabeceras>":{}` |
| [F]/[G] `JsonSerializer.Serialize(ChatRequest)`, con opciones por defecto y con `OutgoingJsonSerializerOptions` | — | `"<clave-de-cabeceras>":{"X-K":"v"}` |
| [H] atributos de `OllamaRequest.<clave-de-cabeceras>` | — | ninguno (sin `[JsonIgnore]`) |

**Respuesta.** **No es un artefacto.** `OllamaRequest.<clave-de-cabeceras>` (`Dictionary<string,string>`, base de `ChatRequest` y `EmbedRequest`) no tiene `[JsonIgnore]`, así que OllamaSharp 5.5.0 la serializa siempre:

- vacía (`{}`) en el uso normal;
- **con los valores** cuando la app pone encabezados **por pedido** en `ChatRequest.<clave-de-cabeceras>`. En ese caso cada valor viaja dos veces: como encabezado HTTP y como texto del cuerpo JSON.

Los encabezados globales (`OllamaApiClient.DefaultRequestHeaders` o `HttpClient.DefaultRequestHeaders`) **no** se copian al cuerpo.

Esto importa por cuatro razones:

1. Un token puesto por pedido termina en cualquier registro que guarde cuerpos: logging de `HttpClient` con cuerpo, proxies, capturas de sondas o un `DelegatingHandler` de depuración. Los encabezados suelen redactarse; los cuerpos no.
2. Ollama ignora la clave. Un proveedor compatible estricto podría rechazar el pedido por un campo desconocido. Esto no lo probé: es **[C]**.
3. Las capturas de E-B2b muestran `{}`, así que **no hubo fuga** en la bitácora.
4. El patrón de la guía debe poner la autenticación en el `HttpClient` (o en un `DelegatingHandler`) y no en `ChatRequest.<clave-de-cabeceras>`.

**Consecuencia para los ítems del jurado.**

- **C1-11 (M10):** la clase de opciones única no debe enseñar encabezados por pedido vía `<clave-de-cabeceras>`. Si hay credencial, va en el `HttpClient` del `IHttpClientFactory`.
- **C1-01 / P-01 (R-PRIV):** sumar a la compuerta un `grep '"<clave-de-cabeceras>":{"'` (valor no vacío) sobre las capturas de cuerpo de `OUTPUTs/`. Hoy da cero.
- **P-11 verificación (4):** se cierra con «comportamiento de OllamaSharp 5.5.0, no de la sonda; vacío en el uso de la guía».
- Si la guía muestra un cuerpo capturado, conviene una nota de una línea que explique por qué aparece `"<clave-de-cabeceras>":{}`.

---

## PC-04 · `prompt_eval_cached_count` desde `IChatClient`

**Pregunta (C1-21; P-19).** ¿OllamaSharp 5.5.0 expone `prompt_eval_cached_count` desde `IChatClient`, por `RawRepresentation` o por `AdditionalProperties`/`AdditionalCounts` de `UsageDetails`?

**Experimento sin modelo** (`R2-cuerpo-salida.txt`, §PC-04). El falso devuelve `prompt_eval_count` 1467 y `prompt_eval_cached_count` 954:

- [A] `Usage`: `InputTokenCount=1467`, `CachedInputTokenCount=null`, `AdditionalCounts=null`.
- [B] `ChatResponse.AdditionalProperties`: sólo `load_duration`, `total_duration`, `prompt_eval_duration` y `eval_duration`.
- [C] `RawRepresentation` es `ChatDoneResponseStream`. Sus propiedades son `TotalDuration`, `LoadDuration`, `PromptEvalCount`, `PromptEvalDuration`, `EvalCount`, `EvalDuration`, `DoneReason`, `Model`, `CreatedAt`, `Message` y `Done`. **Ninguna es de caché.**
- [E] Ningún tipo de OllamaSharp tiene una propiedad con «Cache» en el nombre.
- [F] Sólo `ModelInfo.ExtraInfo` y `ProjectorInfo.ExtraInfo` tienen `[JsonExtensionData]`. El campo desconocido se **descarta al deserializar**.
- [G] En streaming, `UsageContent` trae `CachedInputTokenCount=null`.
- [H] **Remedio probado:** un `DelegatingHandler` lee la última línea NDJSON de `/api/chat` y deja `prompt_eval_count=1467` y `prompt_eval_cached_count=954` en una caja por pedido (`AsyncLocal` que fija quien llama). La respuesta del `IChatClient` no cambia. Tiene un límite: el handler lee el cuerpo completo, así que en streaming sólo sirve si se acepta perder la entrega incremental.
- [I] **Por `/v1`** (MEAI.OpenAI 10.11.0), si el servidor devuelve `usage.prompt_tokens_details.cached_tokens`, `CachedInputTokenCount=954` llega lleno.

**Experimento contra el modelo** (R-LLM; `R2-real-Program.cs`, salida en `R2-real-salida.txt`, §PC-04 real abajo). Ollama 0.40.11 informó 706 tokens cacheados (pedido repetido) y 198 (otra pregunta), y por `IChatClient` `CachedInputTokenCount` fue `null` en los tres casos. Por `/v1` llegó lleno (198 y 707).

**Respuesta.** **No.** Por `IChatClient` sobre OllamaSharp 5.5.0, `prompt_eval_cached_count` no es alcanzable por ningún camino: ni `UsageDetails` (`CachedInputTokenCount`, `AdditionalCounts`), ni `AdditionalProperties`, ni `RawRepresentation`, ni streaming. Esto confirma, con experimento, lo que N3b §0.3 afirmaba con fuente ([G9]). La señal existe en el servidor (0.40.11; Informe del Experto IA, S4) pero el cliente la pierde.

**Consecuencia para los ítems del jurado.**

- **C1-21 / P-19.** La frase «la señal de reuso es `prompt_eval_cached_count`, si el cliente la expone (PC-04)» se resuelve así: «el servidor la informa; OllamaSharp 5.5.0 no la expone. Se lee con un `DelegatingHandler` sobre `/api/chat` o por `/v1`, si el servidor llena `cached_tokens`». Las dos vías quedan probadas contra el servidor real.
- La verificación de P-19 («registro R-LLM con `prompt_eval_cached_count` antes y después») se hace con el handler y no con `UsageDetails`.
- La tabla de N3b l. 327 («Esperar `CachedInputTokenCount` con OllamaSharp → no lo llena») queda **confirmada** por E1.

---

## PC-05 · `TopP`, `TopK` y `PresencePenalty` por OllamaSharp y por `/v1`

**Pregunta (C1-34).** ¿`ChatOptions.TopP`, `TopK` y `PresencePenalty` se traducen por OllamaSharp y por `/v1`?

**Experimento** (`R2-cuerpo-salida.txt`, §PC-05). Usé `ChatOptions { Temperature 0.7, TopP 0.8, TopK 20, PresencePenalty 1.5, FrequencyPenalty 0.1, Seed 7, MaxOutputTokens 64 }` y capturé el cuerpo:

| Vía | Cuerpo capturado (opciones) |
|---|---|
| [A] OllamaSharp `/api/chat` | `"options":{"presence_penalty":1.5,"frequency_penalty":0.1,"temperature":0.7,"seed":7,"num_predict":64,"top_k":20,"top_p":0.8}` |
| [B] MEAI.OpenAI `/v1/chat/completions` | `"temperature":0.7,"top_p":0.8,…,"max_completion_tokens":64,"frequency_penalty":0.1,"presence_penalty":1.5,"seed":7`: **sin `top_k`** |
| [C] `/v1` + `AdditionalProperties["top_k"]=20` | igual que [B]: **`top_k` descartado en silencio** |
| [D] `/v1` + `RawRepresentationFactory` → `ChatCompletionOptions.Patch.Set("$.top_k", 20)` | `…,"seed":7,"top_k":20` (llega; API `[Experimental]` SCME0001) |
| [E] OllamaSharp + `AdditionalProperties` `top_k`, `min_p`, `repeat_penalty` | `"options":{"repeat_penalty":1,"top_k":20,"min_p":0}` |

**Fuente de Ollama.** En https://docs.ollama.com/api/openai-compatibility (consultada el 2026-10-28 a las 12:05 -03; `R2-ollama-openai-compat-campos.txt`), los campos admitidos de `/v1/chat/completions` incluyen `frequency_penalty`, `presence_penalty`, `seed`, `stop`, `temperature`, `top_p`, `max_tokens` y `reasoning_effort`. **No incluyen `top_k` ni `max_completion_tokens`.**

**Respuesta.**

- **Por OllamaSharp, sí:** los tres, y también `FrequencyPenalty`, `Seed` y `MaxOutputTokens` (→ `num_predict`). Los parámetros sin propiedad en `ChatOptions` (`min_p`, `repeat_penalty`, `num_ctx`) van por `AdditionalProperties` con el nombre de Ollama.
- **Por `/v1`:** `TopP` y `PresencePenalty` sí. **`TopK` no:** MEAI.OpenAI lo descarta y la doc de Ollama no lo lista. Aunque se fuerce por `Patch`, la doc no garantiza que Ollama lo aplique.
- **Hallazgo lateral:** MEAI.OpenAI 10.11.0 traduce `MaxOutputTokens` a **`max_completion_tokens`**, y la doc de `/v1` de Ollama lista sólo `max_tokens`. **Contra el servidor real, Ollama 0.40.11 lo ignora:** pedí 3 tokens y salieron 57, con `finish_reason` `stop` (§PC-04 real, casos D y E).

**Consecuencia para los ítems del jurado.**

- **C1-34.** «Fijar por configuración los parámetros del modo sin razonamiento» es implementable **por la vía OllamaSharp** con `ChatOptions` tipadas: `top_k` 20, `top_p` 0,95 y `presence_penalty` 1,5 del Modelfile (Sondeo §R.1). Por `/v1`, la guía debe decir que `TopK` no viaja y que el valor que rige es el del Modelfile del modelo.
- **C1-11:** la clase de opciones puede llevar `TopP`, `TopK` y `PresencePenalty` sólo si se declara que `TopK` aplica únicamente con el proveedor Ollama nativo.
- Esto entra en la tabla de diferencias entre vías de N2 (proveedor «por configuración», C1-11 y MI-13).

---

## PC-09 · Una única definición de herramienta para el bucle y para MCP

**Pregunta (C1-16; ARQUIT-01).** ¿Cómo se comparte una única definición de herramienta entre el bucle `IChatClient`/MAF y el servidor MCP en .NET 10, con qué API y versión?

**API** (reflexión, `R2-reflex-salida.txt`), en ModelContextProtocol 2.3.0:

- `McpServerTool.Create(AIFunction function, McpServerToolCreateOptions options)`
- `McpServerTool.Create(MethodInfo, Func<RequestContext<CallToolRequestParams>,object> createTargetFunc, …)`
- `McpServerTool.Create(Delegate, …)`

En MEAI 10.11.0: `AIFunctionFactory.Create(MethodInfo method, Func<AIFunctionArguments,object> createInstanceFunc, AIFunctionFactoryOptions options)`.

**Experimento** (`R2-mcp-Program.cs`, salida en `R2-mcp-salida.txt`, §PC-09):

```csharp
// Fuente de verdad única: AIFunction sobre un método de una clase con dependencias Scoped
static IReadOnlyList<AIFunction> CatalogoDeHerramientas() =>
[
    AIFunctionFactory.Create(
        typeof(HerramientasDeLectura).GetMethod(nameof(HerramientasDeLectura.ContarPorMedio))!,
        args => ActivatorUtilities.CreateInstance<HerramientasDeLectura>(args.Services!),
        new AIFunctionFactoryOptions { Name = "contar_por_medio" }),
];
// Servidor MCP (adaptador de entrada)
builder.Services.AddMcpServer().WithHttpTransport(o => o.Stateless = true)
    .WithTools(CatalogoDeHerramientas().Select(f => McpServerTool.Create(f, new McpServerToolCreateOptions { ReadOnly = true })));
// Bucle propio (otro adaptador de entrada), en el scope de la petición
IChatClient bucle = new ChatClientBuilder(inner).UseFunctionInvocation().Build(scope.ServiceProvider);
await bucle.GetResponseAsync(pregunta, new ChatOptions { Tools = [.. CatalogoDeHerramientas()] });
AIAgent agente = new ChatClientAgent(inner, instructions: "…", tools: [.. CatalogoDeHerramientas()], services: scope.ServiceProvider);
```

Resultados:

- [A] Un `McpClient` real por HTTP (`McpClient.CreateAsync(new HttpClientTransport(...))`) lista `contar_por_medio` con la misma descripción, `readOnlyHint=True` e `inputSchema` = `{"type":"object","properties":{"medio":{"description":"…","type":"string"}},"required":["medio"]}`.
- [C] `AIFunction.JsonSchema`: **el mismo texto, byte a byte**.
- [B] `tools/call` por MCP: «18 respuestas con «caminata» (vista desde la sesión sesion-MCP)». El `SessionContext` se resolvió del scope de la petición HTTP: el SDK le pasa `RequestServices` al `AIFunctionArguments.Services`.
- [D] `IChatClient` + `UseFunctionInvocation` (cliente falso con guion): «… vista desde la sesión sesion-BUCLE».
- [E] `ChatClientAgent` (MAF 1.26.0) con la misma lista: el mismo resultado.

**Respuesta.** La forma idiomática y compilada en .NET 10 es tomar **el `AIFunction` como definición única**:

- se crea con `AIFunctionFactory.Create(MethodInfo, createInstanceFunc, options)` sobre una clase de adaptador que recibe por constructor los casos de uso de Application;
- el bucle lo usa directo (`ChatOptions.Tools`, o `tools:` de `ChatClientAgent`);
- MCP lo envuelve con `McpServerTool.Create(AIFunction, McpServerToolCreateOptions)` y lo registra con `WithTools(IEnumerable<McpServerTool>)`.

Nombre, descripción y esquema salen de un solo lugar. Las anotaciones MCP (`ReadOnly`, `Destructive`, `Title`) se ponen en `McpServerToolCreateOptions`, es decir, en el lado MCP.

Hay dos alternativas, y las dos dejan dos definiciones:

- `[McpServerToolType]`/`[McpServerTool]` para MCP más `AIFunctionFactory.Create` aparte para el bucle, que es lo que hacen hoy N6 §4.5 y §4.1. Nombre, descripción y esquema quedan duplicados, y habría que fijar `Name` en los dos lados para que coincidan. No comparé los nombres por defecto de cada vía: es **[C]**.
- Que el bucle consuma el propio servidor MCP con `McpClient.ListToolsAsync` (los `McpClientTool` son `AIFunction`). Suma un salto HTTP en proceso.

Una advertencia: un `ApprovalRequiredAIFunction` sigue siendo un `AIFunction`, pero por MCP la aprobación no viaja. El servidor MCP ejecutaría la herramienta sin pedirla. Por eso la lista que va a MCP debe filtrarse a herramientas de lectura. Esto lo infiero de la API (`McpServerTool.Create` recibe un `AIFunction` y lo invoca) y **no lo probé**: es **[C: a verificar]** y toca a PC-12/C1-40.

**Consecuencia para los ítems del jurado.**

- **C1-16 (ARQUIT-01).** «Herramientas y servidor MCP como adaptadores de entrada que consumen casos de uso» tiene un mecanismo concreto y compilado. Un catálogo único de `AIFunction` en el adaptador de entrada (fuera de `Infrastructure/AI`) alimenta a los dos transportes. La fila MCP de N4 y la C6 de N6 deben cambiar `[McpServerToolType]` por `WithTools(catálogo.Select(f => McpServerTool.Create(f, …)))`, o justificar las dos definiciones.
- **C1-28 (M7 extendido a toda herramienta MCP):** con el catálogo único, M7 se verifica una sola vez sobre la lista. Una prueba de cableado puede comparar el `tools/list` de MCP con los `JsonSchema` del catálogo, como en [A]/[C].
- **C1-12:** el patrón resuelve el `SessionContext` del scope en los dos lados sin Singleton raíz (E1 [B]/[D]).

---

## §PC-04 real · contra el servidor Ollama de la LAN (R-LLM)

**Registro R-LLM** (`R2-real-Program.cs`, salida en `R2-real-salida.txt`):

- **Fecha:** 2026-10-28T12:52 -03.
- **Modelo:** `qwen3.5:4b`, digest `d8b0f5e9760cd1682034f292d7ef72ec46f432149be0df7574bf2d6e92e38c04`, en Ollama 0.40.11.
- **Paquetes:** MEAI 10.11.0, OllamaSharp 5.5.0, OpenAI 2.14.0.
- **Parámetros:** `Temperature 0`, `Seed 1`, `MaxOutputTokens 16` en /api/chat y 3 en /v1, `Reasoning.Effort None`. `num_ctx` sin fijar: rige el del modelo cargado.
- **Mensaje de sistema:** 1814 caracteres. La primera línea lleva un *nonce* (`a6cb6d13`) para que el caso A arranque en frío. Siguen 60 líneas «Localidad NN: k respuestas» con k = (NN·7 mod 23) + 1.
- **Cuerpos enviados:** registrados sin los mensajes.

| Caso | Pregunta | Salida | Pared | `Usage.CachedInputTokenCount` por `IChatClient` | `prompt_eval_cached_count` (handler) |
|---|---|---|---|---|---|
| A, frío (`/api/chat`, OllamaSharp) | Localidad 17 | «5» (correcta) | 48,3 s | **null** | 0 de 710 |
| B, mismo pedido | Localidad 17 | «5» | 1,0 s | **null** | **706** de 710 |
| C, misma tabla, otra pregunta | Localidad 42 | «19» (correcta) | 30,0 s | **null** | **198** de 710 |
| D (`/v1`, MEAI.OpenAI), misma tabla, otro pedido; `MaxOutputTokens 3` | «Enumerá las localidades 1 a 10…» | 10 líneas correctas; **57 tokens de salida**; `FinishReason=stop` | 38,8 s | **198** | (crudo: `cached_tokens` 198) |
| E, igual a D | idem | idem; 57 tokens | 10,3 s | **707** | (crudo: `cached_tokens` 707) |

Cuerpo enviado en D y E: `{"temperature":0,"model":"qwen3.5:4b","reasoning_effort":"none","max_completion_tokens":3,"seed":1}`.

Es N = 1 por caso. Afirmo **propiedades** (qué campo llega a .NET y si se respeta un límite) y no tasas de reuso: R-LLM las pediría, y el reuso parcial ya lo midió el Experto IA (S4).

**Lectura.**

1. **PC-04, confirmado contra el servidor real.** Ollama 0.40.11 informa la caché (706 y 198 tokens), y por `IChatClient` sobre OllamaSharp 5.5.0 `CachedInputTokenCount` queda `null` en los tres casos. El `DelegatingHandler` la recupera. **Por `/v1`, Ollama sí devuelve `prompt_tokens_details.cached_tokens` y MEAI.OpenAI llena `CachedInputTokenCount`** (198 y 707). Los dos caminos de la respuesta a PC-04 funcionan con este servidor.
2. El reuso parcial con otra pregunta (C: 198 de 710; D: 198 de 711) concuerda con el «parcial en modelo híbrido» de EXPERT-01/P-19. Es la misma cifra en dos vías distintas: el *checkpoint* reutilizable quedó en el token 198 **(inferencia)**.
3. **Hallazgo nuevo (PC-05): por `/v1`, `MaxOutputTokens` no tiene efecto con Ollama 0.40.11.** MEAI.OpenAI 10.11.0 manda `max_completion_tokens` y Ollama lo ignora (pedí 3 y salieron 57, `finish_reason` `stop`), en concordancia con su doc, que lista sólo `max_tokens`. Por `/api/chat`, `MaxOutputTokens` → `num_predict` sí viaja. No probé si `num_predict` corta: las respuestas de A–C ya eran más cortas que el límite.
4. `Reasoning.Effort = None` se traduce a `reasoning_effort: "none"` por `/v1` y a `think: false` por OllamaSharp. Las salidas no mostraron razonamiento.

**Consecuencia adicional.**

- **C1-13 / CAT-OP-01 (timeout) y C1-11 (M10):** si la demo usa `/v1` como proveedor alternativo, **no puede contar con `MaxOutputTokens` para acotar la pared**. Hay que declararlo en la tabla de diferencias entre vías de N2, o forzar `max_tokens` con `RawRepresentationFactory` + `Patch`. Esta última vía no la probé contra el servidor: es **[C: a verificar]**.
- **C1-21 / P-19:** la verificación R-LLM de P-19 puede reusar esta sonda, con N > 1.
