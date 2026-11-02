# N2 — Abstracciones y proveedores de IA en .NET (dossier de investigación)

> **Naturaleza**: material de trabajo para la mesa evaluadora. No es la guía final.
> **Fecha de relevamiento**: 2026-10-25. Las versiones salen de la API de nuget.org consultada ese día; las afirmaciones conceptuales, de las páginas citadas en la [tabla de fuentes](#7-tabla-de-fuentes) (columna «Fuente»).
> **Convención**: `[Fx]` remite a la tabla de fuentes. `[E1]`…`[E4]` son evidencias ejecutadas (comando + salida) que están en la [sección 4.0](#40-evidencia-ejecutada). Lo que es criterio del investigador va marcado **(criterio propio)**. Lo que no se pudo comprobar va marcado **(no verificado)**.

## Índice

- [1. Ideas agrupadas y dependencias con otros núcleos](#1-ideas-agrupadas-y-dependencias-con-otros-núcleos)
- [2. Definiciones](#2-definiciones)
- [3. Estado actual verificado (2026-10-25)](#3-estado-actual-verificado-2026-10-25)
- [4. Snippets representativos](#4-snippets-representativos)
- [5. Preguntas guía con respuestas](#5-preguntas-guía-con-respuestas)
- [6. Criterios de calidad y antipatrones](#6-criterios-de-calidad-y-antipatrones)
- [7. Tabla de fuentes](#7-tabla-de-fuentes)
- [8. Abierto / no verificado](#8-abierto--no-verificado)
- [9. Verificación adversarial](#9-verificación-adversarial)

---

## 1. Ideas agrupadas y dependencias con otros núcleos

### 1.1 Ideas del núcleo

| Grupo | Ideas | Por qué van juntas |
|---|---|---|
| **G1 Contrato** | `IChatClient`, `IEmbeddingGenerator<TInput,TEmbedding>`, `ChatMessage`/`ChatRole`, `ChatResponse`/`ChatResponseUpdate`, `ChatOptions`, `AIContent` | Son el vocabulario de intercambio que vive en `Microsoft.Extensions.AI.Abstractions` [F1][F2]. |
| **G2 Modos de llamada** | respuesta completa (`GetResponseAsync`), streaming (`GetStreamingResponseAsync` → `IAsyncEnumerable<ChatResponseUpdate>`), salida estructurada (`GetResponseAsync<T>`), historial sin estado y `ConversationId` con estado | Las tres formas de pedirle algo a un modelo con el mismo contrato [F2][F4]. |
| **G3 Pipeline / middleware** | `ChatClientBuilder`, `UseFunctionInvocation`, `UseLogging`, `UseOpenTelemetry`, `UseDistributedCache`, `ConfigureOptions`, `Use(...)`, `DelegatingChatClient` | Patrón decorador, igual que el pipeline de ASP.NET Core [F2]. |
| **G4 Integración en la app** | `AddChatClient`, `AddEmbeddingGenerator`, registros por clave, configuración por variable de entorno | Lo que conecta la capa de IA con la inyección de dependencias del host [F2][F5]. |
| **G5 Proveedores** | OllamaSharp (nativo para Ollama), OpenAI .NET SDK + `Microsoft.Extensions.AI.OpenAI` (OpenAI, Azure OpenAI v1 y endpoints compatibles como `/v1` de Ollama), lo que queda de Azure AI Inference | Implementaciones concretas del contrato G1 [F6][F7][F8][F9][F10]. |
| **G6 Ecosistema alrededor** | Semantic Kernel (en mantenimiento), Microsoft Agent Framework (sucesor), plantillas `aichatweb` y `mcpserver`, evaluación | Dónde termina MEAI y dónde empieza otra pieza [F3][F11][F12][F13]. |

### 1.2 Dependencias con los otros núcleos

El reparto N1…N6 que sigue es **supuesto** del investigador (al momento de escribir, la carpeta de núcleos estaba vacía). La presidencia debe confirmarlo en el documento de cohesión. *(Verificación del 2026-10-26: los seis dosieres ya existen y sus títulos coinciden con este reparto: N1 capa de IA en el stack, N3 RAG, N4 agentes y orquestación, N5 operación, calidad y seguridad, N6 caso MovilidadUrbana.)*

| Núcleo (supuesto) | Qué le da N2 | Qué toma N2 |
|---|---|---|
| **N1** Marco conceptual (diagrama AI Layer, ubicación en el stack) | La pieza concreta que en .NET materializa la caja «LLM / Generative Models»: `IChatClient` como puerto de la capa. | Vocabulario y fronteras de la capa (qué es «AI Layer» y qué no). |
| **N3** RAG, embeddings y vector DB | `IEmbeddingGenerator` y su pipeline (caché y telemetría); el chat que redacta la respuesta con contexto. | `Microsoft.Extensions.VectorData` y `Microsoft.Extensions.DataIngestion` (fuera de N2) [F3]. |
| **N4** Agentes y orquestación (Agent Framework, MCP, LangGraph) | Tool calling (`AIFunctionFactory`, `FunctionInvokingChatClient`): el ciclo «modelo pide, la app ejecuta». MAF depende de MEAI 10.10.x [E3]. | El criterio de cuándo un *tool loop* deja de alcanzar y hace falta orquestación [F3]. |
| **N5** Operación: observabilidad, seguridad, costos, infraestructura | `UseOpenTelemetry` (convenciones semánticas GenAI de OpenTelemetry), `UseLogging`, `UseDistributedCache`, límites de iteración del tool loop [F2][E4]. | Exportadores, Aspire, Redis como `IDistributedCache`, contenedores. |
| **N6** Caso MovilidadUrbana y demo | Los snippets de registro en DI y la elección de proveedor (OllamaSharp o el adaptador OpenAI contra el servidor Ollama de la LAN del laboratorio). | Los casos de uso concretos (clasificar reclamos, resumir, consultar). |

---

## 2. Definiciones

### 2.1 Microsoft.Extensions.AI (MEAI)

- **Qué es**: un conjunto de bibliotecas base de .NET que dan «una capa unificada de abstracciones en C# para interactuar con servicios de IA», como modelos de lenguaje chicos y grandes (SLM y LLM), embeddings y middleware [F3]. Son dos paquetes: `Microsoft.Extensions.AI.Abstractions` (tipos de intercambio) y `Microsoft.Extensions.AI` (utilidades: invocación automática de funciones, telemetría, caché, integración con DI) [F1].
- **Qué problema resuelve**: desacopla el código de la aplicación del proveedor del modelo. Así se puede cambiar de proveedor, testear con dobles, reusar middleware del ecosistema y mantener una API uniforme [F1].
- **Qué no es**: «MEAI alone isn't an agent framework». Una llamada suelta, un chat o un tool loop se arman con MEAI sin volverse «agénticos». Para orquestación de varios pasos con un objetivo, la doc deriva a Microsoft Agent Framework (MAF) [F3]. Tampoco ofrece APIs a medida de un proveedor puntual [F3].
- **Origen**: `IChatClient` e `IEmbeddingGenerator` «se extrajeron de Semantic Kernel» y se movieron al namespace `Microsoft.Extensions.AI` [F3].

### 2.2 `IChatClient`

- **Qué es**: la abstracción de un cliente para servicios de chat. Manda y recibe mensajes con contenido multimodal (texto, imagen, audio), completos o en streaming, y deja pedir servicios tipados del cliente o del servicio subyacente (`GetService`) [F2].
- **Qué resuelve**: un único contrato que implementan los SDK de proveedores (OllamaSharp, el adaptador de OpenAI) y que consume el código de la app [F1][F2].
- **Qué no es**: no guarda historial por su cuenta. Con servicios sin estado, el que llama mantiene la lista de mensajes. Con servicios con estado se usa `ChatOptions.ConversationId` [F2].

### 2.3 `IEmbeddingGenerator<TInput, TEmbedding>`

- **Qué es**: un generador genérico de embeddings. `TInput` es el tipo de entrada y `TEmbedding` hereda de `Embedding`. Por ejemplo, `Embedding<float>` expone `ReadOnlyMemory<float> Vector` [F4].
- **Qué resuelve**: vectoriza texto (u otra entrada) con un contrato común y admite el mismo patrón de pipeline (caché, telemetría) [F4].
- **Qué no es**: no es un vector store ni hace búsqueda por similitud. Eso es `Microsoft.Extensions.VectorData` (N3) [F3].

### 2.4 `ChatMessage`, `ChatRole`, `ChatResponse`, `ChatResponseUpdate`

- `ChatResponse` expone una lista ordenada de `ChatMessage`. El último mensaje es el final de la respuesta. Los mensajes se vuelven a sumar al historial con `AddMessages` [F2].
- `ChatResponseUpdate` es cada fragmento del streaming. `ToChatResponse`/`AddMessages` recomponen los fragmentos en una respuesta [F2].

### 2.5 `ChatOptions`

- **Qué es**: los parámetros por llamada. Las opciones comunes están tipadas (`Temperature`, `ModelId`, `Tools`…). Lo específico del proveedor va por `AdditionalProperties` o por `RawRepresentationFactory` [F2].
- Propiedades presentes en 10.11.0, sacadas por reflexión [E4]: `ConversationId, Instructions, Temperature, MaxOutputTokens, TopP, TopK, FrequencyPenalty, PresencePenalty, Seed, Reasoning, ResponseFormat, ModelId, StopSequences, AllowMultipleToolCalls, ToolMode, Tools, AllowBackgroundResponses, ContinuationToken, RawRepresentationFactory, AdditionalProperties`.

### 2.6 Salida estructurada (`GetResponseAsync<T>`)

- **Qué es**: el método de extensión `ChatClientStructuredOutputExtensions.GetResponseAsync<T>`. Pide una respuesta que cumpla con el tipo `T` y la entrega deserializada en `response.Result` [F5].
- **Matiz**: el parámetro opcional `useJsonSchemaResponseFormat` (`bool?`) decide si se manda el JSON Schema como `response_format` nativo [E4][F5]. Que el modelo y el endpoint soporten JSON Schema depende del proveedor. La doc de Ollama sobre compatibilidad OpenAI lista «JSON mode» y `response_format`, pero no nombra `json_schema` [F9] (ver §8).

### 2.7 `ChatClientBuilder` y middleware

- **Qué es**: un builder fluido que envuelve un `IChatClient` en capas de `IChatClient` delegantes (decoradores). Cada `Use*` agrega una capa y el orden importa («Explore changing the order…») [F2].
- Componentes de `Microsoft.Extensions.AI` [F2]:
  - `FunctionInvokingChatClient` (`UseFunctionInvocation`): ejecuta automáticamente las funciones que pide el modelo y le devuelve el resultado. Expone `MaximumIterationsPerRequest`, `MaximumConsecutiveErrorsPerRequest`, `AllowConcurrentInvocation`, `IncludeDetailedErrors`, `TerminateOnUnknownCalls`, `AdditionalTools` y `FunctionInvoker` [E4].
  - `LoggingChatClient` (`UseLogging`): registra cada pedido y cada respuesta en un `ILogger`.
  - `OpenTelemetryChatClient` (`UseOpenTelemetry`): genera spans y métricas según las convenciones semánticas GenAI de OpenTelemetry. `EnableSensitiveData` incluye el contenido.
  - `DistributedCachingChatClient` (`UseDistributedCache`): cachea por historial sobre un `IDistributedCache`.
  - `ConfigureOptions`: completa `ChatOptions` en cada llamada.
  - `DelegatingChatClient`: clase base para escribir middleware propio. *(Corrección de la verificación: el tipo vive en el ensamblado `Microsoft.Extensions.AI.Abstractions`, no en `Microsoft.Extensions.AI`; el namespace es `Microsoft.Extensions.AI` en los dos casos [V-E1].)*
- **Experimentales en 10.11.0** [E4][F2]: reducción de historial (`MessageCountingChatReducer`, `SummarizingChatReducer`, `ReducingChatClient`), ruteo (`RoutingChatClient`, `FailoverChatClient`, `OrderedFailoverChatClient`, `SemanticRoutingChatClient`), `IImageGenerator`, `ISpeechToTextClient`, `ITextToSpeechClient`, `IRealtimeClient` e `IHostedFileClient`.

### 2.8 Registro en DI (`AddChatClient`, `AddEmbeddingGenerator`)

- `services.AddChatClient(...)` devuelve un `ChatClientBuilder`. Sobre él se encadenan los `Use*`, y los que necesitan servicios (por ejemplo `IDistributedCache` o `ILoggerFactory`) los resuelven del contenedor. Se pueden inyectar varios pipelines con claves distintas [F2]. `AddEmbeddingGenerator` hace lo mismo para embeddings [F6].

### 2.9 Proveedores

- **OllamaSharp**: bindings .NET de la API de Ollama, local o remota. `OllamaApiClient` implementa `IChatClient` e `IEmbeddingGenerator` [F7]. Es el paquete que NuGet recomienda como reemplazo del deprecado `Microsoft.Extensions.AI.Ollama` [E2]. Tiene soporte para Native AOT con un `JsonSerializerContext` propio [F7].
- **OpenAI .NET SDK (`OpenAI`) + `Microsoft.Extensions.AI.OpenAI`**: el adaptador implementa `IChatClient` «para el paquete `OpenAI` y endpoints compatibles con OpenAI» [F6]. Las extensiones son `.AsIChatClient()` sobre `ChatClient` y `.AsIEmbeddingGenerator()` sobre `EmbeddingClient` [F6]. Para apuntar a otro endpoint se usa `OpenAIClientOptions.Endpoint`, el mismo mecanismo que muestra Microsoft para el v1 de Azure OpenAI [F10] y que compila contra el `/v1` de Ollama [E3].
- **Endpoint compatible OpenAI de Ollama**: la URL base es `http://localhost:11434/v1/`. Ofrece, entre otros, `/v1/chat/completions`, `/v1/completions`, `/v1/embeddings`, `/v1/responses` (desde Ollama v0.13.3) y `/v1/models`. En local el cliente necesita una API key, pero Ollama la ignora. En `/v1/chat/completions` no soporta `tool_choice`, logprobs, `n`, `logit_bias` ni `user`; en `/v1/responses` no soporta la variante con estado (`previous_response_id`, `conversation`) [F9].
- **Azure OpenAI v1**: desde agosto de 2025 se puede optar por el API «v1» de Azure OpenAI, que se consume con el **cliente OpenAI estándar** (`OpenAIClient` + `OpenAIClientOptions.Endpoint` = `https://<recurso>.openai.azure.com/openai/v1/`), con API key o con `BearerTokenPolicy` + `DefaultAzureCredential`. Para eso ya no hace falta un cliente específico de Azure [F10]. *(Matiz de la verificación: el ejemplo C# de Entra ID de [F10] lleva `#pragma warning disable OPENAI001`, o sea que ese camino usa API marcada como experimental en el SDK `OpenAI`.)*
- **Azure AI Inference**: el SDK beta (`Azure.AI.Inference`) **se retiró el 2026-08-26**. Microsoft indica pasar al API OpenAI/v1 con el SDK OpenAI estable [F8].

> **2026-10-28 — Parche P2-08 (ciclo 1, ronda 2).** Diferencias entre las vías hacia el mismo Ollama 0.40.11, medidas capturando el cuerpo del pedido con un servidor HTTP falso y, en D y E, contra el servidor real con `qwen3.5:4b@d8b0f5e9760c` (Senior .NET, PC-05, `R2-cuerpo-salida.txt` §PC-05 [A]–[E] y `R2-real-salida.txt`; documentación de compatibilidad con OpenAI de Ollama, https://docs.ollama.com/api/openai-compatibility, consultada el 2026-10-28):
>
> | `ChatOptions` | OllamaSharp 5.5.0 → `/api/chat` | MEAI.OpenAI → `/v1/chat/completions` |
> |---|---|---|
> | `TopP`, `PresencePenalty`, `FrequencyPenalty`, `Seed` | viajan en `options` | viajan |
> | `TopK` | viaja (`top_k`) | **se descarta en silencio**, también con `AdditionalProperties["top_k"]`; llega sólo con `RawRepresentationFactory` y `ChatCompletionOptions.Patch` (API experimental), y la documentación de Ollama no lista `top_k` en `/v1` |
> | `MaxOutputTokens` | `num_predict`, se respeta | se traduce a `max_completion_tokens` y Ollama 0.40.11 **lo ignora**: se pidieron 3 y salieron 57, con `finish_reason` `stop`; la documentación lista sólo `max_tokens` |
> | `num_ctx`, `min_p`, `repeat_penalty` | por `AdditionalProperties` | `num_ctx` no se puede fijar por pedido (P-39); mezclar las dos vías sobre el mismo modelo lo recarga en cada alternancia (P2-09) |
> | `Reasoning.Effort = None` | `think: false` | `reasoning_effort: "none"` |
> | `CachedInputTokenCount` | queda `null` (P2-09) | llega lleno (`prompt_tokens_details.cached_tokens`) |


### 2.10 Semantic Kernel (SK) y Microsoft Agent Framework (MAF)

- MAF «unifica los cimientos enterprise de Semantic Kernel con las orquestaciones de AutoGen». La versión 1.0 salió el 2026-04-03 para .NET y Python, con APIs estables y compromiso de soporte a largo plazo. El post invita a migrar desde SK y AutoGen [F11]. *(Dato de la verificación: en nuget.org `Microsoft.Agents.AI` 1.0.0 figura publicado el 2026-04-02 16:40 UTC, un día antes del post [F15].)*
- SK v1.x sigue recibiendo correcciones de bugs críticos y de seguridad «mientras haya una cantidad sustancial de desarrolladores usándolo y por al menos un año después de que MAF salga de preview y sea GA». La mayoría de las funciones nuevas van a MAF [F12]. Si GA fue el 2026-04-03, ese piso se cumple hacia abril de 2027 **(inferencia propia; no hay fecha oficial publicada)**.
- La página oficial del ecosistema .NET + IA (ms.date 2026-04-15) ya **no menciona a Semantic Kernel** en su tabla de decisión (sólo lo nombra como origen de `IChatClient`/`IEmbeddingGenerator`). Recomienda MEAI para agregar IA a una app y, para sistemas agénticos, «Copilot SDK for a ready-made harness, or Microsoft Agent Framework for multi-step goal pursuit, routing, or handoffs» [F3].
- Relación técnica verificada en los nuspec: `Microsoft.SemanticKernel.Abstractions` 1.81.0 depende de `Microsoft.Extensions.AI` ≥ 10.5.0, y `Microsoft.Agents.AI` 1.26.0 depende de `Microsoft.Extensions.AI` ≥ 10.10.0 [E3]. Los dos están construidos **sobre** MEAI y no compiten con él.

### 2.11 Plantillas `dotnet new`

- **`aichatweb`** (paquete `Microsoft.Extensions.AI.Templates`, sólo preview): una app web de chat Blazor con RAG. Parámetros relevados del `template.json` de 10.11.0-preview.3.26513.7 [E1]:
  - `--provider`: **obligatorio** (`isRequired: true`, sin valor por defecto), con las opciones `azureopenai`, `ollama` («llama3.2 y all-minilm») y `openai`. `azureaifoundry` está comentada.
  - `--vector-store`: `local` (por defecto, un JSON en disco), `azureaisearch` o `qdrant` (con Aspire).
  - `--aspire` (falso por defecto) y `--managed-identity`.
  - Framework: `net10.0` (por defecto) o `net9.0`.
  - El proyecto generado referencia `Microsoft.Extensions.AI` 10.11.0, `Microsoft.Extensions.AI.OpenAI` 10.11.0, `OllamaSharp` 5.4.12 y `Microsoft.Extensions.DataIngestion` 10.11.0-preview [E1].
- **`mcpserver`**: **no está** en `Microsoft.Extensions.AI.Templates` 10.11.0 (ese paquete trae una sola plantilla) [E1]. Vive en **`Microsoft.McpServer.ProjectTemplates`** 1.2.1 (2026-05-08), con identidad `Microsoft.McpServer.ProjectTemplates.McpServer.CSharp`, transporte `local`/`remote` y frameworks net10.0/net9.0/net8.0 [E1].
- El proveedor dejó de tener valor por defecto por el retiro de GitHub Models (2026-07-30). Según el release v10.8.4 de dotnet/extensions («Removed the GitHub Models provider… The `--provider` option is now required with no default»), la plantilla se ajustó el mismo día del retiro, horas antes (paquete `10.8.4-preview.3.26379.3` publicado en nuget.org el 2026-07-30 03:41 UTC) [F14][F15].

---

## 3. Estado actual verificado (2026-10-25)

Fuente de versiones y fechas: `https://api.nuget.org/v3-flatcontainer/<id>/index.json` y `https://api.nuget.org/v3/registration5-gz-semver2/<id>/index.json` [E2].

| Paquete | Última estable | Última preview | Fecha (última) | Estado | Doc oficial |
|---|---|---|---|---|---|
| `Microsoft.Extensions.AI.Abstractions` | **10.11.0** | — (la última es estable) | 2026-10-14 | GA | [F1] |
| `Microsoft.Extensions.AI` | **10.11.0** | — | 2026-10-14 | GA (con tipos `[Experimental]`, §2.7) | [F1][F2] |
| `Microsoft.Extensions.AI.OpenAI` | **10.11.0** | — | 2026-10-14 | GA. Depende de `OpenAI` 2.14.0 | [F6] |
| `OpenAI` (SDK oficial .NET) | **2.14.0** | — | 2026-09-15 | GA | [F6][F10] |
| `OllamaSharp` | **5.5.0** | — | 2026-09-30 | GA (comunidad). Depende de MEAI ≥ 10.8.0 | [F7] |
| `Microsoft.Extensions.AI.Ollama` | ninguna | 9.7.0-preview.1.25356.2 | 2025-07-08 | **DEPRECADO** en NuGet. Alternativa: `OllamaSharp`. «No further updates, features, or fixes are planned» | [E2] |
| `Azure.AI.Inference` | ninguna | 1.0.0-beta.5 | 2025-05-14 | **Retirado 2026-08-26**. Migrar a OpenAI/v1 | [F8] |
| `Microsoft.Extensions.AI.AzureAIInference` | ninguna | 10.0.0-preview.1.25559.3 | 2025-11-11 | Sin marca de deprecación en NuGet, pero depende del `Azure.AI.Inference` retirado. Sin versiones nuevas desde hace casi un año **(estado de abandono inferido)** | [E2] |
| `Azure.AI.OpenAI` | 2.1.0 (2024-12-06) | 2.9.0-beta.1 (2026-03-13) | 2026-03-13 | Sin estable nueva desde 2024. El v1 de Azure OpenAI ya se consume con `OpenAI` [F10]. El quickstart de salida estructurada todavía usa `AzureOpenAIClient` [F5] | [F10] |
| `Microsoft.SemanticKernel` | **1.81.0** | — | 2026-10-06 | GA, en modo mantenimiento (correcciones críticas y de seguridad) | [F12] |
| `Microsoft.SemanticKernel.Connectors.Ollama` | ninguna | 1.81.0-alpha | 2026-10-06 | alpha | — |
| `Microsoft.Agents.AI` (MAF) | **1.26.0** | — | 2026-10-23 | GA desde 1.0 (2026-04-03) | [F11] |
| `Microsoft.Agents.AI.OpenAI` | **1.26.0** | — | 2026-10-23 | GA | [F11] |
| `Microsoft.Extensions.AI.Evaluation` | **10.11.0** | — | 2026-10-14 | GA | [F3] |
| `Microsoft.Extensions.VectorData.Abstractions` | **10.11.0** | — | 2026-10-14 | GA (N3) | [F3] |
| `Microsoft.Extensions.DataIngestion` | ninguna | 10.11.0-preview.1.26513.7 | 2026-10-14 | preview (N3) | [F3] |
| `Microsoft.Extensions.AI.Templates` (`aichatweb`) | ninguna | 10.11.0-preview.3.26513.7 | 2026-10-14 | preview | [F13] |
| `Microsoft.McpServer.ProjectTemplates` (`mcpserver`) | **1.2.1** | — | 2026-05-08 | GA | — |
| `ModelContextProtocol` (SDK C# de MCP) | **2.3.0** | — | 2026-10-20 | GA (N4) | — |

Marcos destino de MEAI 10.11.0: `net10.0`, `net9.0`, `net8.0`, `netstandard2.0` y `net462` [E3].

---

## 4. Snippets representativos

### 4.0 Evidencia ejecutada

- **[E1] Contenido de las plantillas**: se bajaron los `.nupkg` de `microsoft.extensions.ai.templates/10.11.0-preview.3.26513.7` y de `microsoft.mcpserver.projecttemplates/1.2.1` desde el flatcontainer de nuget.org, se descomprimieron y se inspeccionó `template.json`. Salida resumida: `content/` contiene sólo `AIChatWeb-CSharp` (`shortName: aichatweb`). `AiServiceProvider` tiene `"isRequired": true` y las opciones `azureopenai|ollama|openai`. `VectorStore` tiene `local|azureaisearch|qdrant` y por defecto `local`. El paquete MCP trae `shortName: mcpserver`, con opciones `local|remote` y `net10.0|net9.0|net8.0`.
- **[E2] Versiones y deprecación**: consulta de `registration5-gz-semver2` para cada paquete. Para `microsoft.extensions.ai.ollama` cada versión trae `deprecation.alternatePackage.id = "OllamaSharp"` y el mensaje *«This package is deprecated and the OllamaSharp package is recommended… No further updates, features, or fixes are planned for the Microsoft.Extensions.AI.Ollama package.»*
- **[E3] Dependencias (nuspec)**:
  - `Microsoft.Extensions.AI.OpenAI 10.11.0` → `Microsoft.Extensions.AI.Abstractions 10.11.0` y `OpenAI 2.14.0`.
  - `OllamaSharp 5.5.0` → `Microsoft.Extensions.AI 10.8.0` y `Microsoft.Extensions.AI.Abstractions 10.8.0`.
  - `Microsoft.SemanticKernel.Abstractions 1.81.0` → `Microsoft.Extensions.AI 10.5.0`.
  - `Microsoft.Agents.AI 1.26.0` → `Microsoft.Extensions.AI 10.10.0`, `Microsoft.Extensions.AI.Evaluation 10.10.0` y `Microsoft.Extensions.VectorData.Abstractions 10.10.0`.
- **[E3b] Sonda de compilación**: proyecto de consola net10.0 en un directorio de trabajo fuera del repo, compilado y corrido en el contenedor `mcr.microsoft.com/dotnet/sdk:10.0` (SDK 10.0.400 según el investigador, **no verificado**: en la verificación esa misma etiqueta reportó `dotnet --version` = 10.0.403), con `Microsoft.Extensions.AI` 10.11.0, `Microsoft.Extensions.AI.OpenAI` 10.11.0 y `OllamaSharp` 5.5.0. El código es el de §4.1 a §4.6. Comando: `docker run --rm -v <sonda>:/src -v <volumen-nuget>:/root/.nuget/packages -w /src mcr.microsoft.com/dotnet/sdk:10.0 dotnet run`. Resultado: `0 Warning(s)`, sin errores. Corrió contra un `IChatClient` falso, porque no había modelo en `localhost`:

  ```text
  Structured: Semaforos / 1
  Hola desde el fake.
  OllamaSharp is IChatClient: True; OpenAI adapter type: OpenAIChatClient; meta=openai
  ```

  Esto prueba que las firmas compilan y que el pipeline (caché → function invocation → OTel → logging) y `GetResponseAsync<T>` funcionan de punta a punta sobre el contrato. **No prueba** el comportamiento contra un modelo real (§8).
- **[E4] Reflexión sobre 10.11.0**: con `dotnet run -- --reflect` en la misma sonda se listaron las propiedades de `FunctionInvokingChatClient`, la firma de `GetResponseAsync<T>` y los tipos con `[Experimental]`. Los resultados están en §2.5 y §2.7.

### 4.1 Chat básico, historial y streaming (OllamaSharp)

Origen: [F2] (adaptado: la URL sale de la variable de entorno).

```csharp
using Microsoft.Extensions.AI;
using OllamaSharp;

string endpoint = Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT") ?? "http://localhost:11434";
IChatClient client = new OllamaApiClient(new Uri(endpoint), "qwen3"); // modelo: el que exponga el servidor

// Historial explícito (servicio sin estado)
List<ChatMessage> history = [new(ChatRole.System, "Sos un asistente de movilidad urbana.")];
history.Add(new(ChatRole.User, "¿Qué es un reclamo?"));
ChatResponse response = await client.GetResponseAsync(history);
Console.WriteLine(response.Text);
history.AddMessages(response);

// Streaming
List<ChatResponseUpdate> updates = [];
await foreach (ChatResponseUpdate update in client.GetStreamingResponseAsync(history))
{
    Console.Write(update);
    updates.Add(update);
}
history.AddMessages(updates);
```

### 4.2 Mismo contrato, otro proveedor: SDK OpenAI contra el `/v1` de Ollama

Origen: el patrón `OpenAIClientOptions.Endpoint` del v1 de Azure OpenAI [F10], `AsIChatClient()` [F6] y la URL base `/v1` de Ollama [F9]. Compila según [E3b].

```csharp
using System.ClientModel;
using Microsoft.Extensions.AI;
using OpenAI;

string endpoint = Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT") ?? "http://localhost:11434";

IChatClient client = new OpenAIClient(
        new ApiKeyCredential("ollama"), // el SDK exige una clave; Ollama local la ignora [F9]
        new OpenAIClientOptions { Endpoint = new Uri($"{endpoint.TrimEnd('/')}/v1") })
    .GetChatClient("qwen3")
    .AsIChatClient();

IEmbeddingGenerator<string, Embedding<float>> embeddings = new OpenAIClient(
        new ApiKeyCredential("ollama"),
        new OpenAIClientOptions { Endpoint = new Uri($"{endpoint.TrimEnd('/')}/v1") })
    .GetEmbeddingClient("all-minilm")
    .AsIEmbeddingGenerator();
```

### 4.3 Tool calling con `UseFunctionInvocation`

Origen: [F2] (adaptado al dominio).

```csharp
using System.ComponentModel;
using Microsoft.Extensions.AI;

[Description("Devuelve el estado de un reclamo por número")]
static string ConsultarEstado([Description("Número de reclamo")] int numero) => $"Reclamo {numero}: En curso";

IChatClient chat = client.AsBuilder()
    .UseFunctionInvocation()
    .Build();

ChatOptions options = new() { Tools = [AIFunctionFactory.Create(ConsultarEstado)] };
Console.WriteLine(await chat.GetResponseAsync("¿Cómo va el reclamo 42?", options));
```

### 4.4 Salida estructurada

Origen: [F5] (adaptado: un record de dominio en lugar de `Sentiment`).

```csharp
record Clasificacion(string Categoria, int Prioridad);

ChatResponse<Clasificacion> r =
    await chat.GetResponseAsync<Clasificacion>("Clasificá: 'semáforo roto en la esquina'");
Console.WriteLine($"{r.Result.Categoria} / {r.Result.Prioridad}");
```

### 4.5 Registro en DI con pipeline (caché, tools, telemetría, logging)

Origen: [F2], secciones «Dependency injection» y «Functionality pipelines». Compila según [E3b].

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OllamaSharp;

var builder = Host.CreateApplicationBuilder(args);   // en ASP.NET Core: WebApplication.CreateBuilder
string endpoint = builder.Configuration["OLLAMA_ENDPOINT"] ?? "http://localhost:11434";

builder.Services.AddDistributedMemoryCache();          // en producción: Redis como IDistributedCache (N5)
builder.Services.AddChatClient(new OllamaApiClient(new Uri(endpoint), "qwen3"))
    .UseDistributedCache()
    .UseFunctionInvocation()
    .UseOpenTelemetry(sourceName: "MovilidadUrbana.AI")
    .UseLogging();
builder.Services.AddEmbeddingGenerator(new OllamaApiClient(new Uri(endpoint), "all-minilm"));
```

En un servicio de la capa Application se consume por constructor: `public sealed class ClasificadorDeReclamos(IChatClient chat) { … }`.

> **2026-10-28 — Parche P2-05 (ciclo 1, ronda 2).** Si este fragmento se usa con herramientas que resuelven servicios scoped, rige N0b D-06 corregido: con `AddChatClient` Singleton y `ValidateScopes = false`, todas las conversaciones comparten un único espacio, sin error; se registra Scoped o se crean las herramientas por petición (condición (c) del juez de riesgo).


### 4.6 Embeddings con pipeline

Origen: [F4].

```csharp
IEmbeddingGenerator<string, Embedding<float>> generator =
    new EmbeddingGeneratorBuilder<string, Embedding<float>>(new OllamaApiClient(new Uri(endpoint), "all-minilm"))
        .UseDistributedCache(cache)
        .UseOpenTelemetry(sourceName: "MovilidadUrbana.AI")
        .Build();

ReadOnlyMemory<float> vector = await generator.GenerateVectorAsync("semáforo roto");
```

### 4.7 Middleware propio con `DelegatingChatClient`

Origen: [F2], `RateLimitingChatClient`. Conviene reproducirlo tal cual en la guía como ejemplo canónico de decorador. Variante corta con `Use(...)`:

```csharp
client = client.AsBuilder()
    .Use(async (messages, options, nextAsync, ct) =>
    {
        // antes: p. ej. redactar datos personales, medir, limitar
        await nextAsync(messages, options, ct);
        // después
    })
    .Build();
```

### 4.8 Plantillas

Origen: [E1], [F13].

```bash
dotnet new install Microsoft.Extensions.AI.Templates          # preview
dotnet new aichatweb -n ChatDemo --provider ollama            # --provider es obligatorio
dotnet new install Microsoft.McpServer.ProjectTemplates
dotnet new mcpserver -n ReclamosMcp
```

*(Verificado en la verificación adversarial [V-E2])* El `dotnetcli.host.json` de `aichatweb` 10.11.0-preview.3.26513.7 mapea `AiServiceProvider` → `--provider`, `VectorStore` → `--vector-store`, `UseManagedIdentity` → `--managed-identity` y `UseAspire` → `--aspire`. Los cuatro comandos de arriba se corrieron en `mcr.microsoft.com/dotnet/sdk:10.0`: las dos instalaciones terminan en `Success`, `dotnet new aichatweb` sin `--provider` falla con «Missing mandatory option(s) for the template 'AI Chat Web App': '--provider'» y con `--provider ollama` crea el proyecto; `dotnet new mcpserver` crea el proyecto y restaura.

---

## 5. Preguntas guía con respuestas

**P1. ¿Por qué programar contra `IChatClient` y no directamente contra el SDK del proveedor?**
Porque el contrato desacopla. El código de Application depende de una interfaz de `Microsoft.Extensions.*`, igual que de `ILogger`, y el proveedor se elige en el registro de DI. Eso deja cambiar Ollama por OpenAI o Azure, testear con un doble (la sonda [E3b] usa un `IChatClient` falso de 15 líneas) y reusar middleware [F1]. **Cuándo no**: si se necesita una función exclusiva del proveedor que el contrato no expone, se baja con `GetService<T>()` al cliente nativo o se usa `RawRepresentationFactory` [F2], sin abandonar la abstracción en el resto del código.

**P2. ¿Referencio `Microsoft.Extensions.AI` o sólo `.Abstractions`?**
Una aplicación referencia `Microsoft.Extensions.AI` (trae la abstracción y el middleware) más uno o más proveedores. Una biblioteca que *implementa* un proveedor referencia sólo `.Abstractions` [F1]. **Criterio propio**: en una solución por capas, el proyecto Domain no referencia ninguno de los dos. Application puede depender de `.Abstractions` (sólo el contrato) e Infrastructure/host de `Microsoft.Extensions.AI` y del proveedor.

**P3. Para hablar con Ollama, ¿OllamaSharp o el SDK OpenAI contra `/v1`?**
Las dos dan un `IChatClient`. OllamaSharp es el nativo y el reemplazo oficial del paquete deprecado [E2], y expone la API completa de Ollama (gestión de modelos, etc.) [F7]. El SDK OpenAI con `Endpoint` apuntado a `/v1` sirve cuando se quiere el mismo código para Ollama, OpenAI y Azure OpenAI v1 [F9][F10]. Hay que aceptar las limitaciones del modo compatible: sin `tool_choice`, sin logprobs, sin Responses con estado [F9]. **Criterio propio**: para la demo con el servidor Ollama de la LAN del laboratorio, OllamaSharp es lo más directo. Mostrar también el adaptador OpenAI enseña que el contrato aguanta el cambio de proveedor.

**P4. ¿`Microsoft.Extensions.AI.Ollama` sigue sirviendo?**
No. Está deprecado en NuGet, quedó en 9.7.0-preview (julio de 2025) y su mensaje dice que no habrá más actualizaciones [E2]. Muchos tutoriales de 2024 y 2025 todavía lo usan. Es una señal para revisar la fecha del material que se consulta.

**P5. ¿Cuándo uso `GetResponseAsync`, cuándo streaming y cuándo `GetResponseAsync<T>`?**
- Streaming: cuando una persona está mirando el texto. Mejora la latencia percibida y en Blazor Interactive Server encaja con renderizar a medida que llegan los `ChatResponseUpdate` [F2] *(la API de streaming sale de [F2]; el encaje con Blazor Interactive Server es criterio propio, [F2] no habla de Blazor)*.
- `GetResponseAsync<T>`: cuando el resultado lo consume *código* (clasificar un reclamo, extraer campos). La validación por tipo reemplaza el parseo frágil de texto [F5].
- `GetResponseAsync`: para todo lo demás (resúmenes que se guardan, pasos de backend).

**Cuándo no** confiar en `<T>`: si el modelo o el endpoint no soporta JSON Schema puede fallar. Hay que probarlo con el modelo real, y en ese caso validar `r.Result` y prever el error [F5][F9].

**P6. ¿El orden de los `Use*` importa?**
Sí. Cada `Use` envuelve al siguiente, y la doc invita a experimentar con el orden [F2]. Ejemplos de razonamiento **(criterio propio, derivado del modelo decorador de [F2])**:
- Si la caché va por fuera de la invocación de funciones, se cachea la respuesta final ya resuelta y un acierto no vuelve a ejecutar las tools.
- Si OpenTelemetry va por dentro de la invocación de funciones, se ve un span por cada ida y vuelta al modelo. Si va por fuera, un solo span por pedido del usuario.

**P7. ¿Cuándo MEAI no alcanza y hace falta Microsoft Agent Framework?**
Cuando el problema deja de ser «acceso al modelo» y pasa a ser «orquestación»: varios pasos hacia un objetivo, decisiones intermedias, varios agentes, handoffs [F3]. Un chat con un tool loop (`UseFunctionInvocation`) sigue siendo MEAI. MAF está construido sobre MEAI [E3], así que lo aprendido acá se reusa (N4).

**P8. Tengo un proyecto con Semantic Kernel. ¿Lo migro?**
Microsoft dice que para proyectos existentes o que deben salir ya «está perfectamente bien usar Semantic Kernel». Para proyectos nuevos recomienda MAF, y SK recibe correcciones críticas por al menos un año después del GA de MAF [F12]. **Criterio propio**: en una guía de estudio nueva (octubre de 2026), SK se presenta como contexto histórico y como camino de migración, no como punto de partida.

**P9. ¿Sigo usando `Azure.AI.OpenAI` o `Azure.AI.Inference` para Azure?**
`Azure.AI.Inference` se retiró el 2026-08-26 [F8]. Para Azure OpenAI y los modelos de Foundry, Microsoft documenta el API v1 con el cliente `OpenAI` estándar y `BearerTokenPolicy` para Entra ID [F10]. `Azure.AI.OpenAI` no tiene estable nueva desde 2024 [E2], aunque algún quickstart todavía lo usa [F5].

**P10. ¿La plantilla `aichatweb` es un buen punto de partida para un proyecto real?**
Sirve para ver armado de punta a punta un chat Blazor con RAG (ingesta, vector store local en JSON, citas). Pero es preview, su vector store por defecto es «for prototyping» y obliga a elegir el proveedor [E1]. **Criterio propio**: usarla como referencia de lectura y copiar patrones a una solución por capas como MovilidadUrbana, no como base de producción.

> **2026-10-28 — Parche P-03 (ciclo 1).** P6 («¿El orden de los `Use*` importa?»): R-C07 quedó reabierta; hasta PC-02 la guía muestra los spans de cada orden y no recomienda uno. Texto completo en BIT-16-04 §3.2 y en N5 §4.2.


---

## 6. Criterios de calidad y antipatrones

### Criterios de calidad

1. **El contrato en Application, el proveedor en el host**: el código de casos de uso recibe `IChatClient`/`IEmbeddingGenerator` por DI, y sólo el `Program.cs` sabe si es Ollama u OpenAI [F1][F2].
2. **Endpoint y modelo por configuración**: `OLLAMA_ENDPOINT` (o la configuración equivalente) con `http://localhost:11434` como valor por defecto. Nunca direcciones fijas en el código **(criterio propio, coherente con las reglas del encargo)**.
3. **Observabilidad desde el día uno**: `UseOpenTelemetry` y/o `UseLogging` en el pipeline. `EnableSensitiveData` sólo en desarrollo, porque vuelca prompts y respuestas a la telemetría [F2].
4. **Tool loop acotado**: fijar `MaximumIterationsPerRequest` y `MaximumConsecutiveErrorsPerRequest` en `FunctionInvokingChatClient` [E4]. Exponer como tools sólo operaciones que la app permitiría a ese usuario **(criterio propio)**.
5. **Salida estructurada para lo que consume código**, siempre con validación del resultado y manejo del error [F5].
6. **Testear con dobles**: un `IChatClient` falso para unit tests. Las pruebas contra el modelo real son de integración y aparte **(criterio propio, demostrado en [E3b])**.
7. **Versiones alineadas**: todos los paquetes `Microsoft.Extensions.AI*` en la misma versión. OllamaSharp y MAF arrastran mínimos distintos de MEAI (10.8.0 y 10.10.0) [E3], y conviene fijar la versión explícitamente **(criterio propio)**.
8. **Marcar lo experimental**: si se usan reducers, ruteo o failover, avisar que son `[Experimental]` y que el compilador emite el diagnóstico correspondiente [E4][F2].

### Antipatrones

| Antipatrón | Por qué es malo | Fuente |
|---|---|---|
| Usar `Microsoft.Extensions.AI.Ollama` | Deprecado, sin parches | [E2] |
| Usar `Azure.AI.Inference` / `Microsoft.Extensions.AI.AzureAIInference` en código nuevo | El SDK base se retiró el 2026-08-26 | [F8] |
| Seguir tutoriales con GitHub Models como proveedor por defecto | El servicio se retiró el 2026-07-30 | [F14] |
| Instanciar `OllamaApiClient` u `OpenAIClient` dentro de un servicio de dominio | Acopla el dominio al proveedor e impide testear | [F1] (criterio propio) |
| Parsear a mano el texto libre del modelo para sacar datos | Frágil; existe `GetResponseAsync<T>` | [F5] |
| Mandar el historial completo sin límite | Crece el costo y se agota el contexto. Para eso existen los reducers (experimentales) | [F2] |
| Activar `EnableSensitiveData` en producción | Filtra contenido de usuarios a la telemetría | [F2] (criterio propio sobre el riesgo) |
| Arrancar un proyecto nuevo de agentes en Semantic Kernel | Las funciones nuevas van a MAF | [F12] |
| Suponer que el modo compatible OpenAI de Ollama es 100 % OpenAI | No soporta `tool_choice`, logprobs ni Responses con estado | [F9] |

---

## 7. Tabla de fuentes

| Id | Fuente | Qué respalda | Consultado |
|---|---|---|---|
| F1 | https://learn.microsoft.com/en-us/dotnet/ai/microsoft-extensions-ai (ms.date 2026-09-14) | Paquetes Abstractions vs MEAI, qué referenciar, `IChatClient`, `IEmbeddingGenerator`, `IImageGenerator` experimental | 2026-10-25 |
| F2 | https://learn.microsoft.com/en-us/dotnet/ai/ichatclient (ms.date 2026-03-13, actualizado 2026-08-19) | Chat, historial, streaming, tools, caché, OTel, logging, `ChatOptions`, pipelines, `DelegatingChatClient`, DI, con estado / sin estado, reducción y ruteo experimentales | 2026-10-25 |
| F3 | https://learn.microsoft.com/en-us/dotnet/ai/dotnet-ai-ecosystem (ms.date 2026-04-15) | Tabla de decisión MEAI / MEDI / MEVD / MCP / MAF / Foundry. «MEAI alone isn't an agent framework». Origen en SK | 2026-10-25 |
| F4 | https://learn.microsoft.com/en-us/dotnet/ai/iembeddinggenerator (ms.date 2025-12-11) | `IEmbeddingGenerator`, `GenerateVectorAsync`, pipeline de embeddings | 2026-10-25 |
| F5 | https://learn.microsoft.com/en-us/dotnet/ai/quickstarts/structured-output (ms.date 2026-03-04) | `GetResponseAsync<T>`, `response.Result`, uso de `AzureOpenAIClient` en el quickstart | 2026-10-25 |
| F6 | https://github.com/dotnet/extensions/blob/main/src/Libraries/Microsoft.Extensions.AI.OpenAI/README.md | `AsIChatClient`, `AsIEmbeddingGenerator`, «OpenAI-compatible endpoints», `AddChatClient`/`AddEmbeddingGenerator` | 2026-10-25 |
| F7 | https://github.com/awaescher/OllamaSharp | OllamaSharp implementa `IChatClient`/`IEmbeddingGenerator`, uso, Native AOT | 2026-10-25 |
| F8 | https://learn.microsoft.com/en-us/azure/foundry-classic/foundry-models/supported-languages (actualizado 2026-10-19) | «Azure AI Inference beta SDK retired on August 26, 2026», migrar a OpenAI/v1 | 2026-10-25 |
| F9 | https://docs.ollama.com/api/openai-compatibility | Base `/v1`, API key ignorada en local, endpoints y funciones soportadas / no soportadas | 2026-10-25 |
| F10 | https://learn.microsoft.com/en-us/azure/ai-foundry/openai/api-version-lifecycle (ms.date 2026-05-13; la URL canónica actual es https://learn.microsoft.com/en-us/azure/foundry/openai/api-version-lifecycle) | API v1 de Azure OpenAI con el cliente `OpenAI` estándar, `OpenAIClientOptions.Endpoint`, `BearerTokenPolicy` | 2026-10-25 |
| F11 | https://devblogs.microsoft.com/agent-framework/microsoft-agent-framework-version-1-0/ (2026-04-03) | MAF 1.0 GA, unifica SK y AutoGen, invitación a migrar | 2026-10-25 |
| F12 | https://devblogs.microsoft.com/agent-framework/semantic-kernel-and-microsoft-agent-framework/ (2025-10-07) | Política de soporte de SK y recomendación para proyectos nuevos | 2026-10-25 |
| F13 | https://devblogs.microsoft.com/dotnet/announcing-dotnet-ai-template-preview1 (2025-03-06) | Origen de la plantilla `aichatweb` e instalación | 2026-10-25 |
| F14 | https://github.blog/changelog/2026-07-30-github-models-is-now-retired/ y https://github.com/dotnet/extensions/releases/tag/v10.8.4 | Retiro de GitHub Models el 2026-07-30. Plantilla sin proveedor por defecto desde 10.8.4 (la verificación reemplazó el espejo secundario newreleases.io por el release primario de GitHub) | 2026-10-25 |
| F15 | https://api.nuget.org/v3-flatcontainer/{id}/index.json y https://api.nuget.org/v3/registration5-gz-semver2/{id}/index.json | Todas las versiones, fechas y marcas de deprecación de §3 | 2026-10-25 |
| E1–E4 | Evidencias ejecutadas (§4.0) | Plantillas, deprecaciones, dependencias, compilación y reflexión | 2026-10-25 |

---

## 8. Abierto / no verificado

1. **Comportamiento contra un modelo real (qwen en el servidor Ollama de la LAN del laboratorio)**: la sonda [E3b] corrió contra un cliente falso. Quedan **no verificados** contra el modelo real:
   - el tool calling con `UseFunctionInvocation`, tanto por OllamaSharp como por `/v1`;
   - `GetResponseAsync<T>` con `useJsonSchemaResponseFormat` en su valor por defecto;
   - los embeddings (qué modelo de embeddings está disponible en ese servidor).

   Debe probarlo N6 o la demo.
2. **Soporte de `json_schema` en el `/v1` de Ollama**: la doc lista `response_format` y «JSON mode», pero no nombra `json_schema` [F9]. La API nativa de Ollama acepta esquemas: *(verificado en la verificación adversarial)* el campo `format` de `/api/chat` admite «`json` or a JSON schema» (https://docs.ollama.com/api/chat, https://docs.ollama.com/capabilities/structured-outputs). Que OllamaSharp traduzca `useJsonSchemaResponseFormat` a ese campo sigue **no verificado**. Es otra razón para preferir OllamaSharp.
3. ~~**Alias de CLI de la plantilla `aichatweb`**~~: **resuelto** en la verificación adversarial (§4.8, [V-E2]).
4. **Fecha de fin de soporte de Semantic Kernel**: no hay fecha oficial. «Abril de 2027» es una inferencia a partir de [F11] y [F12].
5. **`Microsoft.Extensions.AI.AzureAIInference`**: NuGet no lo marca deprecado, pero depende del SDK retirado. Su estado oficial queda **no verificado**.
6. **`Azure.AI.OpenAI`**: no se encontró un aviso explícito de deprecación. Lo único firme es que el v1 se consume con `OpenAI` [F10] y que no hay estable nueva desde 2024 [E2].
7. **Snippets del README de `Microsoft.Extensions.AI.OpenAI`**: la herramienta de lectura devolvió extractos, no los bloques completos [F6]. Si la guía los cita textuales, hay que copiarlos del archivo en GitHub. *(Verificación: el README crudo, https://raw.githubusercontent.com/dotnet/extensions/main/src/Libraries/Microsoft.Extensions.AI.OpenAI/README.md, confirma la frase «for the `OpenAI` package and OpenAI-compatible endpoints», `.AsIChatClient()`, `.AsIEmbeddingGenerator()` y los registros `AddChatClient`/`AddEmbeddingGenerator`; la copia textual sigue pendiente para la guía.)*
8. **Notas de versión de MEAI 10.9 a 10.11**: no se relevaron cambios puntuales (breaking changes) entre esas versiones.
9. **Reparto N1…N6**: era un supuesto (§1.2). Los títulos de los seis dosieres lo confirman (verificación del 2026-10-26). Falta que la presidencia lo ratifique en la cohesión.

---

## 9. Verificación adversarial

> **Fecha**: 2026-10-25. **Mandato**: refutar cada afirmación verificable contrastándola de forma independiente con la fuente primaria. Las correcciones ya están aplicadas en el cuerpo del dosier (marcadas «verificación»).
>
> **Evidencias propias de la verificación** (independientes de E1–E4):
> - **[V-E1] Sonda propia de compilación y reflexión**: proyecto de consola net10.0 en un directorio de trabajo fuera del repo, con `Microsoft.Extensions.AI` 10.11.0, `Microsoft.Extensions.AI.OpenAI` 10.11.0, `OllamaSharp` 5.5.0, `Microsoft.Extensions.Hosting` y `Microsoft.Extensions.Caching.Memory` 10.0.0. Comando: `docker run --rm -v <sonda>:/src -v <volumen-nuget>:/root/.nuget/packages -w /src mcr.microsoft.com/dotnet/sdk:10.0 dotnet build`. Los snippets §4.1 a §4.7 se pegaron **tal cual** (sólo envueltos en funciones locales) y el build dio `0 Error(s)` (SDK 10.0.403); las únicas advertencias fueron CS8321 por las funciones locales envoltorio de la propia sonda, ninguna de los snippets. La reflexión (`--reflect`) devolvió exactamente la lista de propiedades de `ChatOptions` de §2.5 y la de `FunctionInvokingChatClient` de §2.7; las seis sobrecargas de `ChatClientStructuredOutputExtensions.GetResponseAsync<T>` con `Nullable<bool> useJsonSchemaResponseFormat`; y `[Experimental]` en todos los tipos que lista §2.7 (`MessageCountingChatReducer`, `SummarizingChatReducer`, `ReducingChatClient`, `RoutingChatClient`, `FailoverChatClient`, `OrderedFailoverChatClient`, `SemanticRoutingChatClient`, `IImageGenerator`, `ISpeechToTextClient`, `ITextToSpeechClient`, `IRealtimeClient`, `IHostedFileClient`), mientras que `DistributedCachingChatClient`, `OpenTelemetryChatClient`, `LoggingChatClient`, `ConfigureOptionsChatClient` y `DelegatingChatClient` no lo son. `OpenTelemetryChatClient` expone `EnableSensitiveData`. En ejecución (`--meta`): `AsIChatClient()` sobre el `ChatClient` de OpenAI devuelve `OpenAIChatClient` con `ProviderName = openai`; `OllamaApiClient` reporta `ProviderName = ollama` y además es `IEmbeddingGenerator<string, Embedding<float>>`.
> - **[V-E2] Plantillas**: se bajaron y descomprimieron los `.nupkg` de `microsoft.extensions.ai.templates/10.11.0-preview.3.26513.7` y `microsoft.mcpserver.projecttemplates/1.2.1`; se leyeron `template.json` y `dotnetcli.host.json`; y se corrieron en el contenedor SDK 10.0 los cuatro comandos de §4.8 (salidas citadas en §4.8).
> - **[V-E3] nuget.org**: `https://api.nuget.org/v3-flatcontainer/<id>/index.json` (últimas versiones) y `https://api.nuget.org/v3/registration5-gz-semver2/<id>/index.json` (fecha `published`, `deprecation`, `dependencyGroups`) para los 19 paquetes de §3 más `Microsoft.SemanticKernel.Abstractions` 1.81.0, `Microsoft.Agents.AI` 1.0.0 y `Microsoft.Extensions.AI.Templates` 10.8.4.

| Afirmación | Veredicto | Evidencia |
|---|---|---|
| Versiones «última estable / preview» de los 19 paquetes de §3 | confirmada | [V-E3]: coinciden todas (MEAI/Abstractions/OpenAI/Evaluation/VectorData 10.11.0; OpenAI 2.14.0; OllamaSharp 5.5.0; MEAI.Ollama 9.7.0-preview.1.25356.2; Azure.AI.Inference 1.0.0-beta.5; MEAI.AzureAIInference 10.0.0-preview.1.25559.3; Azure.AI.OpenAI 2.1.0 / 2.9.0-beta.1; SK 1.81.0; SK.Connectors.Ollama 1.81.0-alpha; Agents.AI y Agents.AI.OpenAI 1.26.0; DataIngestion 10.11.0-preview.1.26513.7; Templates 10.11.0-preview.3.26513.7; McpServer.ProjectTemplates 1.2.1; ModelContextProtocol 2.3.0) |
| Fechas de publicación de §3 | confirmada (dos celdas vacías completadas: corregida) | [V-E3]: 10.11.0 el 2026-10-14; OpenAI 2.14.0 el 2026-09-15; OllamaSharp 5.5.0 el 2026-09-30; MEAI.Ollama el 2025-07-08; Azure.AI.Inference el 2025-05-14; MEAI.AzureAIInference el 2025-11-11; Azure.AI.OpenAI 2.1.0 el 2024-12-06 y 2.9.0-beta.1 el 2026-03-13; SK el 2026-10-06; MAF el 2026-10-23; MCP templates el 2026-05-08; ModelContextProtocol el 2026-10-20. Evaluation (2026-10-14) y SK.Connectors.Ollama (2026-10-06) figuraban «—» |
| `Microsoft.Extensions.AI.Ollama` deprecado, alternativa OllamaSharp, «No further updates, features, or fixes are planned» | confirmada | [V-E3]: `deprecation.alternatePackage.id = "OllamaSharp"` y mensaje textual idéntico |
| `Azure.AI.OpenAI` sin estable nueva desde 2024 | confirmada | [V-E3]: estables sólo 2.0.0 y 2.1.0 |
| `MEAI.AzureAIInference` sin marca de deprecación y dependiente de `Azure.AI.Inference` | confirmada | [V-E3]: `deprecation: null`; depende de `Azure.AI.Inference ≥ 1.0.0-beta.5` |
| Dependencias E3 (MEAI.OpenAI → Abstractions 10.11.0 + OpenAI 2.14.0; OllamaSharp → MEAI 10.8.0; SK.Abstractions → MEAI 10.5.0; Agents.AI → MEAI 10.10.0, Evaluation 10.10.0, VectorData 10.10.0) | confirmada | [V-E3] `dependencyGroups`. Matiz: `Microsoft.Agents.AI` 1.26.0 depende de `Microsoft.Extensions.AI.Evaluation` sólo en net8/9/10, no en net472 ni netstandard2.0 |
| Marcos destino de MEAI 10.11.0: net10.0, net9.0, net8.0, netstandard2.0, net462 | confirmada | [V-E3]: cinco `dependencyGroups` con esos TFMs |
| MAF 1.0 GA el 2026-04-03 | confirmada (con matiz) | [F11] fechado el 3 de abril de 2026; en nuget.org `Microsoft.Agents.AI` 1.0.0 figura el 2026-04-02 16:40 UTC [V-E3] |
| Cita de MAF: unifica SK + AutoGen, APIs estables, soporte a largo plazo, invitación a migrar | confirmada | [F11] (textual) |
| Política de soporte de SK (críticos y seguridad, ≥ 1 año post-GA de MAF, mayoría de funciones nuevas en MAF, «perfectly fine» para proyectos existentes) | confirmada | [F12], fechado 2025-10-07 |
| «Abril de 2027» como piso de soporte de SK | no verificada (inferencia, ya marcada así) | No hay fecha oficial en [F11] ni en [F12] |
| Página del ecosistema: ms.date 2026-04-15, «MEAI alone isn't an agent framework», origen en SK, SK fuera de la tabla de decisión | confirmada | [F3] (metadatos y texto) |
| Página del ecosistema: «MAF para sistemas agénticos» | corregida | [F3] dice «Copilot SDK for a ready-made harness, or Microsoft Agent Framework…»: se agregó la mención de Copilot SDK |
| Definición de MEAI, dos paquetes, qué referenciar (app vs. biblioteca), beneficios, `IImageGenerator` experimental | confirmada | [F1], ms.date 2026-09-14 |
| `IChatClient`: multimodal, completo o streaming, `GetService`; historial sin estado y `ConversationId` con estado; `AddMessages`/`ToChatResponse`; último mensaje = final | confirmada | [F2] (ms.date 2026-03-13, `updated_at` 2026-08-19) |
| `ChatOptions`: tipadas + `AdditionalProperties` + `RawRepresentationFactory`; lista de 20 propiedades en 10.11.0 | confirmada | [F2]; [V-E1] reflexión con la lista idéntica |
| Middleware `UseFunctionInvocation`/`UseLogging`/`UseOpenTelemetry`/`UseDistributedCache`/`ConfigureOptions`, «Explore changing the order», convenciones semánticas GenAI de OTel, `EnableSensitiveData` | confirmada | [F2]; [V-E1] |
| Propiedades de `FunctionInvokingChatClient` | confirmada | [V-E1]: `IncludeDetailedErrors, AllowConcurrentInvocation, MaximumIterationsPerRequest, MaximumConsecutiveErrorsPerRequest, AdditionalTools, TerminateOnUnknownCalls, FunctionInvoker` |
| `DelegatingChatClient` como «componente de `Microsoft.Extensions.AI`» | corregida | [V-E1]: está en el ensamblado `Microsoft.Extensions.AI.Abstractions` (el namespace sí es `Microsoft.Extensions.AI`) |
| Tipos experimentales en 10.11.0 (reducers, ruteo, failover, imagen, voz, realtime, archivos alojados) | confirmada | [V-E1]: todos llevan `[Experimental]`. `RoutingChatClient` está en Abstractions; el resto de los reducers y el ruteo, en MEAI. [F2] los marca «experimental and subject to change» |
| `GetResponseAsync<T>`, `response.Result`, parámetro `bool? useJsonSchemaResponseFormat`; el quickstart usa `AzureOpenAIClient` | confirmada | [F5] (ms.date 2026-03-04; usa `AzureOpenAIClient` y el paquete `Azure.AI.OpenAI`); [V-E1] firmas |
| DI: `AddChatClient` devuelve `ChatClientBuilder`, pipelines con claves, `AddEmbeddingGenerator` | confirmada | [F2] §Dependency injection; README de [F6]; [V-E1] compila §4.5 |
| `IEmbeddingGenerator`, `Embedding<float>.Vector` como `ReadOnlyMemory<float>`, `GenerateVectorAsync`, pipeline con caché + OTel | confirmada | [F4] (ms.date 2025-12-11); [V-E1] compila §4.6 |
| OllamaSharp: bindings local/remoto, implementa `IChatClient` e `IEmbeddingGenerator`, Native AOT con `JsonSerializerContext` | confirmada | README de [F7] (opt-in Native AOT con `JsonSerializerContext` propio); [V-E1] |
| MEAI.OpenAI: «for the `OpenAI` package and OpenAI-compatible endpoints», `.AsIChatClient()`, `.AsIEmbeddingGenerator()` | confirmada | README crudo de [F6] |
| Ollama `/v1`: base URL, API key exigida e ignorada, `/v1/responses` desde v0.13.3, sin `tool_choice`/logprobs/`n`/Responses con estado, `json_schema` no nombrado | confirmada (lista de endpoints ampliada: corregida) | [F9]: HTML leído y casillas de soporte inspeccionadas (`tool_choice`, `logprobs`, `n`, `logit_bias`, `user` sin marcar; `tools`, `response_format`, «JSON mode» marcados). Se sumaron `/v1/completions` y los campos no soportados `logit_bias` y `user` |
| API nativa de Ollama acepta JSON Schema | confirmada (antes «no verificado») | https://docs.ollama.com/api/chat: `format` = «`json` or a JSON schema»; https://docs.ollama.com/capabilities/structured-outputs |
| Azure OpenAI v1 desde agosto de 2025 con el cliente `OpenAI` estándar, `OpenAIClientOptions.Endpoint`, `BearerTokenPolicy` | confirmada (con matiz) | [F10] (ms.date 2026-05-13): «Starting in August 2025, you can opt in…». Matiz agregado: el ejemplo C# con Entra ID usa `#pragma warning disable OPENAI001` |
| `Azure.AI.Inference` beta retirado el 2026-08-26, migrar a OpenAI/v1 | confirmada | [F8]: «Azure AI Inference beta SDK retired on August 26, 2026» (`updated_at` 2026-10-19) |
| Retiro de GitHub Models el 2026-07-30 | confirmada | [F14] changelog: «As of July 30, 2026, GitHub Models is now retired» |
| Plantilla sin proveedor por defecto desde 10.8.4, «antes» del retiro | corregida (precisión y fuente) | Release primario https://github.com/dotnet/extensions/releases/tag/v10.8.4 («Removed the GitHub Models provider… `--provider` option is now required with no default»); el paquete 10.8.4 salió el 2026-07-30 03:41 UTC, el mismo día del retiro [V-E3]. Se reemplazó la fuente secundaria (newreleases.io) |
| `aichatweb`: `--provider` obligatorio (azureopenai/ollama/openai, `azureaifoundry` comentada), `--vector-store` local/azureaisearch/qdrant, `--aspire`, `--managed-identity`, net10.0/net9.0, «for prototyping» | confirmada | [V-E2] `template.json` (`"isRequired": true`; `// "choice": "azureaifoundry"`; «Local on-disk (for prototyping)») |
| Alias de CLI `--provider`/`--vector-store` (antes «no verificado») | confirmada | [V-E2] `dotnetcli.host.json` y ejecución real de `dotnet new aichatweb` con y sin `--provider` |
| Proyecto generado por `aichatweb` referencia MEAI 10.11.0, MEAI.OpenAI 10.11.0, OllamaSharp 5.4.12, DataIngestion 10.11.0-preview | confirmada | [V-E2] `PackageReference` del contenido de la plantilla |
| `mcpserver` no está en MEAI.Templates; vive en `Microsoft.McpServer.ProjectTemplates` 1.2.1, identidad `…McpServer.CSharp`, local/remote, net10/9/8 | confirmada | [V-E2]: `content/` de MEAI.Templates sólo trae `AIChatWeb-CSharp`; `template.json` del paquete MCP; `dotnet new mcpserver` se ejecutó bien |
| Comandos de §4.8 (`dotnet new install …` sin versión instala la preview) | confirmada | [V-E2]: `Success: Microsoft.Extensions.AI.Templates@10.11.0-preview.3.26513.7 installed…` |
| Snippets §4.1–§4.7 usan APIs que existen en 10.11.0 / OllamaSharp 5.5.0 / OpenAI 2.14.0 | confirmada | [V-E1]: pegados tal cual compilan sin errores y sin advertencias propias |
| E3b: tipo `OpenAIChatClient` y `meta=openai` | confirmada | [V-E1] `--meta` |
| E3b: SDK 10.0.400 | no verificada | Hoy la etiqueta `sdk:10.0` reporta 10.0.403; no se puede reconstruir la imagen que usó el investigador |
| E3b: el pipeline caché → tools → OTel → logging y `GetResponseAsync<T>` corren de punta a punta contra un `IChatClient` falso | no verificada (no reproducida) | La verificación compiló el mismo código pero no corrió el doble de 15 líneas del investigador (no está en el dosier) |
| Comportamiento contra un modelo real (tool calling, `<T>`, embeddings) | no verificada (ya marcada así) | Fuera del alcance de esta verificación; queda para N6 o la demo (§8.1) |
| Streaming «encaja con Blazor Interactive Server» atribuido a [F2] | corregida (atribución) | [F2] no menciona Blazor: se marcó como criterio propio |
| Reparto N1…N6 de §1.2 | confirmada (2026-10-26) | Primera línea de `Nucleos/N1…N6-*.md`: los temas coinciden con el supuesto. Falta la ratificación de la presidencia |
| Versiones de §3 vigentes al 2026-10-26 (segunda pasada) | confirmada | flatcontainer: MEAI 10.11.0, OpenAI 2.14.0, OllamaSharp 5.5.0, Agents.AI 1.26.0, SK 1.81.0, ModelContextProtocol 2.3.0 y Templates 10.11.0-preview.3.26513.7 siguen siendo las últimas |

---

## 2026-10-28 — Nota de reanudación (caída de equipo anterior)

> **Contexto**: equipo anterior se cayó el 2026-10-28 a las 00:50 (-03) y la corrida sigue en estación 1. Esta nota es **sólo agregado**: no cambia nada de lo de arriba.
>
> - **El trabajo del 26 y el 27 hecho en equipo anterior se perdió** (la copia de esta carpeta es la del 2026-10-26 a la mañana). No se reconstruye de memoria. Si algo de ese período afectaba a N2, se rehace con evidencia nueva.
> - **Las mediciones previas valen como historia** del servidor Ollama de la LAN del laboratorio (dado de baja el 2026-10-28). No se borran ni se corrigen, pero tampoco sirven como evidencia del entorno nuevo. Nada de lo que hay acá se midió contra el Ollama propio en contenedor (estación 1).
> - Las evidencias propias de N2 ([E1]–[E4], [V-E1]–[V-E3]) son de nuget.org, de los `.nupkg` de las plantillas y de compilación y reflexión contra un `IChatClient` falso: **ninguna dependía del servidor**. N2 no tiene carpeta `N2-Evidencia/`.
> - El único rastro de pruebas contra modelos real que toca a N2 está **fuera** del dosier, en `../Sondeo-Entorno.md` §3, §4 y §6 (tool calling y `json_schema` por HTTP crudo, `IChatClient` por las dos vías). Ese material mide el servidor dado de baja, así que también vale sólo como historia.

### Clasificación de lo abierto y de lo medido contra el modelo

(a) = dependía del servidor Ollama de la LAN → **pendiente de re-verificación contra el Ollama propio en contenedor (estación 1)**. (b) = abierto pero independiente del servidor → sigue abierto tal cual.

| Ítem (ubicación) | Clase | Por qué | Cómo se re-verifica / qué queda |
|---|---|---|---|
| §8.1 — tool calling con `UseFunctionInvocation`, por OllamaSharp y por `/v1` (también §9, fila «Comportamiento contra un modelo real») | (a) | Necesita un modelo de chat con capacidad `tools`. La sonda [E3b] corrió contra un doble. El sondeo histórico midió `tool_calls` por HTTP crudo, no por MEAI | Primero `curl $OLLAMA_ENDPOINT/api/tags` y `/api/show` para leer las `capabilities` de los modelos presentes. Hoy están `qwen2.5:0.5b` y `qwen3-embedding:0.6b`; si el 0.5b no alcanza, se baja un modelo mayor con la mesa, como dice Reanudar §3. Después, una sonda net10.0 en `{dir-de-trabajo}/` con el snippet §4.3 (con dominio de Movilidad Urbana, RD-PO-3) por las dos vías. N corridas por vía, con modelo, digest, `finish_reason` y latencia. Todo por `$R/<envoltorio-de-turnos> <recurso-compartido> …` |
| §8.1 — `GetResponseAsync<T>` con `useJsonSchemaResponseFormat` por defecto | (a) | Se compiló y corrió sólo contra un doble ([E3b]) | La misma sonda con el snippet §4.4 (record de Movilidad Urbana). Se registra la tasa de `r.Result` válido sobre N corridas y el cuerpo HTTP que sale, con un `DelegatingHandler` que lo loguee. Así se ve si va `format: <schema>` (OllamaSharp) o `response_format` (`/v1`) |
| §8.1 — qué modelo de embeddings hay disponible | (a) | La respuesta histórica, de `Sondeo-Entorno.md` §5 y N3 [E2], era que el servidor de la LAN no tenía ninguno | En estación 1 está `qwen3-embedding:0.6b`. Se verifica con `/api/embed` (dimensión esperada: 1024, según N3 [E3]) y corriendo el snippet §4.6. Ojo: §4.5 y §4.6 usan `all-minilm`, que no está en estación 1 |
| Nombres de modelo en los snippets (`"qwen3"` en §4.1, §4.2 y §4.5; `"all-minilm"` en §4.2, §4.5 y §4.6) | (a) | No es una medición, pero el nombre tiene que existir en el servidor. Ninguno de los dos estaba en el servidor de la LAN (ver la tabla de `Sondeo-Entorno.md` §1) ni está hoy en estación 1 | Se cruza con `/api/tags` del Ollama propio. La guía debería sacar el modelo de configuración (p. ej. `OLLAMA_MODEL`), como hace N3 con `OLLAMA_EMBEDDING_MODEL`. Lo decide la integración |
| §8.2 — `json_schema` en el `/v1` de Ollama: soporte en ejecución | (a) | El sondeo histórico (§4) lo vio funcionar en ejecución contra el servidor de la LAN, con `qwen2.5:7b-instruct` | Un `curl` a `/v1/chat/completions` con `response_format: {type: json_schema, …}` contra el Ollama propio, más la sonda .NET de la fila de `<T>`. Se anota la versión de Ollama del contenedor (`/api/version`) |
| §8.2 — qué dice la doc de `/v1` sobre `json_schema` | (b) | Es lectura de [F9] | Se relee la página con fecha. Sigue abierto tal cual |
| §8.2 — si OllamaSharp traduce `useJsonSchemaResponseFormat` al campo `format` | (b), y también (a) | Se puede resolver sin servidor, leyendo el `AbstractionMapper` de OllamaSharp 5.5.0 en su commit (como hizo N3b [G9]) o por reflexión. La captura HTTP de la fila de `<T>` lo confirma en ejecución | Lectura del fuente con commit fijado. La ejecución queda atada a la sonda de la fila de `<T>` |
| §5 P3 y §1.2, fila N6 — «para la demo con el servidor Ollama de la LAN del laboratorio, OllamaSharp es lo más directo» | (b), con destino cambiado | Es criterio propio sobre el protocolo, no una medición. Pero el servidor que nombra ya no existe | El criterio sigue abierto tal cual. La integración tiene que leerlo como «el Ollama propio en contenedor (estación 1)» |
| §4.0 [E3b] — corrida contra el `IChatClient` falso; §9, «SDK 10.0.400 no verificada» y «pipeline de punta a punta no reproducido» | (b) | No usan servidor | Siguen tal cual. El doble de 15 líneas se perdió con el trabajo intermedio de equipo anterior. Si hace falta, se reescribe en `{dir-de-trabajo}/`, no de memoria |
| §3 — versiones y fechas de nuget.org (vigentes al 2026-10-25/26) | (b) | No dependen del servidor | Siguen tal cual. Antes de redactar conviene una pasada al flatcontainer con fecha |
| §8.3 — alias de CLI de `aichatweb` | — | Ya estaba resuelto ([V-E2]) | Sin cambio |
| §8.4 — fecha de fin de soporte de Semantic Kernel | (b) | Fuentes documentales | Sigue abierto tal cual |
| §8.5 — estado oficial de `Microsoft.Extensions.AI.AzureAIInference` | (b) | nuget.org y docs | Sigue abierto tal cual |
| §8.6 — aviso de deprecación de `Azure.AI.OpenAI` | (b) | nuget.org y docs | Sigue abierto tal cual |
| §8.7 — copia textual de los snippets del README de `Microsoft.Extensions.AI.OpenAI` | (b) | Fuente en GitHub | Sigue abierto tal cual |
| §8.8 — notas de versión de MEAI 10.9 a 10.11 | (b) | Fuente en GitHub | Sigue abierto tal cual |
| §8.9 — ratificación del reparto N1…N6 por la presidencia | (b) | Es de proceso | Sigue abierto tal cual (fase de integración) |

### Para la fase de integración (no corregido acá)

- **Contradicción de capas con N1 y N6.** Acá, §5 P2 (criterio propio) y §6 criterio 1 ponen `IChatClient` en Application («el código de casos de uso recibe `IChatClient`/`IEmbeddingGenerator` por DI»), y §4.5 inyecta `IChatClient` en un servicio de Application. N1 §2.14 y N6 §1 (regla del mapeo) dicen lo contrario: Application define puertos en lenguaje del dominio, e `Infrastructure/AI/` es el único lugar que conoce `IChatClient`. N0b deja las dos como alternativas. La integración tiene que elegir una.
- **Modelo de embeddings distinto entre núcleos.** N2 usa `all-minilm`; N1 §4 usa `nomic-embed-text`; N3 y N3b proponen `qwen3-embedding:0.6b`, porque es el que se midió mejor (N3 [E3]).
- **§8.2 «otra razón para preferir OllamaSharp»** se apoya en que la doc de `/v1` no nombra `json_schema`. El sondeo histórico (§4) lo vio aceptado por `/v1` en ejecución. El argumento se debilita, aunque la recomendación de OllamaSharp sigue teniendo otros apoyos (el sondeo §8 y N4).
- **Fecha del GA de MAF.** N2 §2.10 la da el 2026-04-03 (el post), con el matiz de nuget.org (2026-04-02). N1 §3.1 la da como «1.0.0 = 2026-04-02». Es un desacuerdo menor de criterio sobre qué fecha se cita.
- **Dominio ajeno a Movilidad Urbana (RD-PO-3).** El dominio de «reclamos» y «semáforos» aparece en: §4.1 («¿Qué es un reclamo?»), §4.3 (`ConsultarEstado`, «reclamo 42»), §4.4 (`Clasificacion`, «semáforo roto en la esquina»), §4.5 (`ClasificadorDeReclamos`), §4.6 («semáforo roto»), §4.8 (`ReclamosMcp`), §5 P5 («clasificar un reclamo»), §1.2 fila N6 («clasificar reclamos») y la salida de [E3b] («Semaforos / 1»). Se reemplaza al redactar, con `Localidad`, `Provincia`, `RespuestaDeEncuesta`, medios de transporte y sesiones.

## 2026-10-28 — Reparación de integración (BIT-16-04)

> Nota agregada en la fase de integración ([`../04-Integracion.md`](../04-Integracion.md)). **Sólo agregado**: no se modificó nada de lo anterior. Los IDs entre paréntesis (RA-*, T*, C-*, R-C*, I-*, MI-*) remiten a las resoluciones de BIT-16-04; la evidencia nueva está en `../Integracion-Evidencia/`. Lo marcado MI-nn es criterio propio que vota la mesa en el ciclo 1.

- **§5 P2, §6 criterio 1 y §4.5** (RA-2 = C-1). Rige D-01 (c): el caso de uso recibe un puerto de `Application/Abstractions`, y el adaptador de `Infrastructure/AI` recibe `IChatClient`. Application no referencia `Microsoft.Extensions.AI.Abstractions`. La inyección directa queda como deuda de prototipo (N1 P2) o para una app que es un chat genérico (N1 P3). El criterio 1 se reformula: «el **adaptador** recibe `IChatClient`/`IEmbeddingGenerator` por DI; sólo `Program.cs` conoce al proveedor». El ejemplo de §4.5 pasa a `ExtractorDeLocalidadLlm(IChatClient) : IExtractorDeLocalidad` en `Infrastructure/AI` (I-4). Evidencia: EA-2, EA-3.
- **§8.1** (T4). Tool calling y `GetResponseAsync<T>` **verificados en estación 1 por las dos vías** (E-B1: `qwen3.5:4b` 5/5 por OllamaSharp y 5/5 por `/v1`; E-B2: forma válida 13/13, válida para el dominio 11/13). Forma ≠ validez: la regla del dominio decide.
- **§8.2** (T4, C-5). Verificado que OllamaSharp traduce `useJsonSchemaResponseFormat` a `format` (con esquema: el objeto JSON Schema; sin esquema: `"json"`) (E-B2b). El argumento «la doc de `/v1` no nombra `json_schema`, otra razón para preferir OllamaSharp» **cae**: `/v1` de 0.40.11 aceptó `response_format: json_schema` desde .NET. OllamaSharp sigue como principal por API nativa (`think`, `format`, `/api/embed`) y por ser el reemplazo oficial.
- **§4.1, §4.2, §4.5 y §4.6, modelos** (T4, C-2, I-1). El modelo va por `OLLAMA_MODEL` y el de embeddings por `OLLAMA_EMBEDDING_MODEL`; ningún literal `qwen3` ni `all-minilm` (no están en el servidor vigente). El razonamiento se apaga con `ChatOptions.Reasoning = new ReasoningOptions { Effort = ReasoningEffort.None }` (E-B2b).
- **§4.5 y P6, pipeline** (R-C06, R-C07). (1) Si se cambia `sourceName`, cambia también el `Meter`, y el SDK tiene que registrar ese mismo nombre en `AddSource`/`AddMeter`: con nombres distintos se exportan 0 spans (X1 [A]). (2) El orden con la caché por fuera de la telemetría es el antipatrón de N5 (E2, V3): el orden de la guía es `UseOpenTelemetry` → caché → límite de concurrencia → `UseFunctionInvocation` → cliente.
- **§2.10, fecha de GA de MAF** (C-10). Se citan las dos fechas: anuncio 2026-04-03, 1.0.0 en nuget.org 2026-04-02.
- **RD-PO-3** (C-12 = R-C18). §4.1 «¿Qué es un reclamo?» → «¿Qué datos pide la encuesta de movilidad?»; §4.3 `ConsultarEstado` → `contar_localidades_por_provincia(provincia)` sobre `LocalidadService.GetAllAsync` (I-5); §4.4 `Clasificacion` → `LocalidadPropuesta` con «Agregá Goya, Corrientes, CP 3450, unos 90 mil habitantes»; §4.5 `ClasificadorDeReclamos` → `ExtractorDeLocalidadLlm`; §4.6 «semáforo roto» → «El código postal debe tener 4 dígitos.»; §4.8 `ReclamosMcp` → `MovilidadUrbanaMcp` con `listar_localidades`; §5 P5 y §1.2 fila N6 → «extraer los campos de una localidad»; la salida de [E3b] se rehace. Piezas ya compiladas y corridas en la sonda B (`../Integracion-Evidencia/B-abstracciones-agentes/sonda/`).

> **2026-10-28 — Ciclo 1 de la mesa: convención de ids en estas notas.** «Parche P-nn (ciclo 1)» es un parche de `Mesa/Ciclo-1/03-Parches.md`, aplicado según `Mesa/Ciclo-1/05-Aplicacion.md`; «P-nn» sin calificar dentro de un texto de parche también es un parche. Los pendientes de BIT-16-04 §7 se citan como «pendiente P-nn de BIT-16-04». El plan vinculante de redacción es `Mesa/Ciclo-1/06-Plan-De-Redaccion.md`.

> **2026-10-28 — Parche P-31 (ciclo 1).** `doc_id` de este registro: `BIT-16-N2`. Se cita con ese id desde el ciclo 1.

> **2026-10-28 — Parche P-04 (ciclo 1).** Aplicación por escenario, plantilla de N3b y esqueleto de BIT-16-03 §4.1/§4.2. Cada recomendación de §3–§6 de este registro queda atada a un ESC y a un CTX, o declarada «vale para todos» con su motivo. **Ajuste vinculante (juez de evidencia):** cada celda cita la sección del registro (o la celda de BIT-16-03 §4.1/§4.2) que la respalda; si no hay respaldo, dice «sin respaldo en el registro: pendiente». Ninguna celda queda en blanco.
>
> | Escenario | Qué de este núcleo aplica | Contexto que lo cambia (CTX-LOCAL, CTX-PROTO, CTX-SENS, CTX-PROD) | Criterio o antipatrón de §6 que lo rige | Ejemplo o pieza de la demo |
> |---|---|---|---|---|
> | ESC-01 consulta de datos | `IChatClient`, historial y streaming (§2.2, §4.1) | CTX-LOCAL/CTX-NUBE: mismo código, distinto registro del cliente; CTX-PROTO/CTX-PROD: configuración por entorno; CTX-SENS: qué se envía al proveedor (03 §4.2, fila N2) | §6 criterios 1–3; antipatrones «Instanciar `OllamaApiClient` u `OpenAIClient` dentro de un servicio de dominio», «Mandar el historial completo sin límite» | `Examples/01`, `Examples/02` |
> | ESC-02 búsqueda por significado | Sólo `IEmbeddingGenerator` (§2.3, §4.6; 03 §4.1 «○ sólo embeddings») | CTX-LOCAL/CTX-NUBE: modelo de embeddings por configuración (§6 criterio 2) | §6 criterio 7 «Versiones alineadas» | `Examples/04` |
> | ESC-03 extracción a estructura | `GetResponseAsync<T>` (§2.6, §4.4) | vale para todos con matiz: cómo se pide el formato depende del proveedor (§4.2: `/v1` manda `response_format`) | §6 criterio 5; antipatrón «Parsear a mano el texto libre del modelo» | D1–D3; `Examples/03` |
> | ESC-04 acción con aprobación | `UseFunctionInvocation` (§4.3) y middleware (§2.7, §4.5, §4.7) | CTX-PROTO/CTX-PROD: límites del bucle (§6 criterio 4) | §6 criterio 4; antipatrón «Suponer que el modo compatible OpenAI de Ollama es 100 % OpenAI» | D6; `Examples/06` |
> | ESC-05 integración con terceros (MCP) | 03 §4.1 «○»: el cliente MCP entrega herramientas a `IChatClient` (remite a N4 §4.6) | sin respaldo en el registro: pendiente | sin respaldo en el registro: pendiente | `Examples/08` |

> **2026-10-28 — Parche P-31 (ciclo 1).** Las fuentes de §7 de este registro entran a la guía por el catálogo único `REF-nnn` del Anexo D (texto en BIT-16-04 §8, nota de Parche P-31). Este registro no se renumera.

> **2026-10-28 — Parche P-34 (ciclo 1).** Este registro todavía no está validado (REED-16 §6.2). Sus secciones «Marcas [C] resueltas» y «Validación del núcleo» se agregan al aplicar el ciclo 1.

## Marcas [C] resueltas (2026-10-28)

> Agregado por la aplicación del ciclo 1 (Parche P-34; REED-16 §6.2, sección 4). Sólo agregado.

| Marca | Situación |
|---|---|
| 01 l. 115 «verificar el orden y semántica del pipeline» | semántica **resuelta en** N2 §2.7 y §4.5; el orden **sigue abierta**: R-C07 reabierta y PC-02 pendiente (Parche P-03) |
| 01 l. 117 «posicionamiento oficial vigente» de MEAI, SK y MAF | **resuelta en** N2 §2.10 y BIT-16-04 tensión 2 |
| 00 l. 142, SUP-08 «estado de soporte LTS» | **resuelta en** Parche P-28: `release-metadata` oficial, 2026-10-28T09:45, .NET 10.0 `lts`, `active`, fin de soporte 2028-11-14 (`Mesa/Ciclo-1/evidencia-verificacion-qa/R3-dotnet-soporte.txt`) |
| 03 l. 48 «soporte de herramientas de Qwen en Ollama» | **resuelta en** `Sondeo-Entorno.md` §R.4 (tool calling con R-LLM, N = 10) y BIT-16-04 tensión 4; la frase «el servidor Ollama de la LAN» de esa fila queda **superada por** el entorno vigente (RV-01) |

## Validación del núcleo (ciclo 1)

> Agregado por la aplicación del ciclo 1 (Parche P-34; REED-16 §6.2, sección 6). Veredicto a la fecha de aplicación; lo revisa la relectura integral.

- **Parches del ciclo 1 que lo alcanzan:** P-03 (remisión en P6), P-04, P-31, P-34; le alcanzan P-11 y P-39 por sus snippets.
- **Severidades abiertas sobre él:** S1: ninguno. S2 abiertos: C1-37 (orden del pipeline, PC-02), C1-11 (`OpcionesDeIA`: parte verificada en sonda, falta `Examples/01`).
- **Veredicto:** **No validado.**
