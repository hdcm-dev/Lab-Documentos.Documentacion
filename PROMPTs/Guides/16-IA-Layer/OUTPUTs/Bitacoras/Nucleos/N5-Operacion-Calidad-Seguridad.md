# N5: Operación, calidad y seguridad de la capa de IA (dossier de investigación)

> **Qué es este documento**: material de trabajo para la mesa evaluadora, no la guía final. Reúne definiciones, el estado verificado de la tecnología al **2026-10-25**, snippets, preguntas guía y criterios del núcleo N5. Cada afirmación remite a una fuente de la §7 (ids `F01`…) o a evidencia ejecutada (`E01`…, §3.6). Lo que es criterio del investigador va marcado **[criterio propio]**; lo que no se pudo verificar, **[no verificado]**.
>
> Privacidad (R-PRIV): la API de IA local se nombra «el servidor Ollama de la LAN del laboratorio». En código, el endpoint sale de `OLLAMA_ENDPOINT` y por defecto vale `http://localhost:11434`. La sonda N5 corrió **sin** modelo real, con un `IChatClient` falso, a propósito (ver §3.6).

## Índice

1. [Ideas agrupadas y dependencias con los otros núcleos](#1-ideas-agrupadas-y-dependencias-con-los-otros-núcleos)
2. [Definiciones precisas](#2-definiciones-precisas)
3. [Estado actual verificado](#3-estado-actual-verificado-2026-10-25)
4. [Snippets representativos](#4-snippets-representativos)
5. [Preguntas guía con respuestas explicativas](#5-preguntas-guía-con-respuestas-explicativas)
6. [Criterios de calidad y antipatrones](#6-criterios-de-calidad-y-antipatrones)
7. [Tabla de fuentes](#7-tabla-de-fuentes)
8. [Abierto / no verificado](#8-abierto--no-verificado)

---

## 1. Ideas agrupadas y dependencias con los otros núcleos

### 1.1 Grupos de ideas de N5

| Grupo | Ideas | Por qué van juntas |
|---|---|---|
| G1 Observabilidad | OpenTelemetry, convenciones semánticas GenAI, `UseOpenTelemetry`, `UseLogging`, `EnableSensitiveData`, métricas de tokens y latencia, Aspire Dashboard y su visualizador GenAI | Las tres responden a la misma pregunta: qué hizo el modelo, cuánto tardó y cuánto costó. Comparten el mismo vocabulario de atributos (`gen_ai.*`) |
| G2 Evaluación y pruebas | pruebas deterministas con `IChatClient` falso, contrato de salida estructurada, `Microsoft.Extensions.AI.Evaluation` (Quality, NLP, Safety, Reporting, Console), evaluadores propios (`IEvaluator`), caché de respuestas para CI | Tres capas de prueba encadenadas: la lógica propia (determinista), el contrato con el modelo (esquema) y la calidad de la respuesta (evaluación por LLM o por servicio) |
| G3 Seguridad | OWASP Top 10 for LLM Applications 2025 (LLM01…LLM10), OWASP Top 10 for Agentic Applications 2026, inyección directa e indirecta, inyección indirecta en RAG, privilegio mínimo y aprobación humana de herramientas, datos personales en prompts y en telemetría | Los riesgos se cruzan: una inyección indirecta (LLM01) se vuelve grave cuando el agente tiene agencia excesiva (LLM06) y deja datos personales a la vista (LLM02) en las trazas |
| G4 Costo, latencia y caché | tokens como unidad de costo, `DistributedCachingChatClient` / `UseDistributedCache`, clave de caché, limitación de tasa (`DelegatingChatClient`), consumo sin límite (LLM10) | Para bajar costo o latencia se compone el mismo pipeline de *middleware*, y el orden de las capas cambia lo que se ve en la telemetría (E2) |
| G5 Local vs nube | Ollama, Foundry Local, ONNX Runtime GenAI, nube (OpenAI/Azure), ventana de contexto, cuantización | Es una sola decisión de despliegue, con efecto sobre la privacidad, el costo, la latencia y la calidad |
| G6 Configuración y secretos | user-secrets, variables de entorno (`__` como separador), `OLLAMA_ENDPOINT`, connection strings de Aspire | Hace falta para que el código sea portable y publicable sin filtrar infraestructura (R-PRIV) |

### 1.2 Dependencias con los otros núcleos

Partición tomada del contrato de entrada (§6): N0 marco didáctico, N1 capa en el stack, N2 abstracciones .NET, N3 RAG, N4 agentes, N5 este núcleo y N6 caso práctico e integración.

```mermaid
flowchart LR
  N1["N1 Capa de IA en el stack"] -->|alucinación, grounding,<br/>Monitoring & Logging de la imagen| N5
  N2["N2 Abstracciones .NET<br/>(IChatClient, pipeline)"] -->|ChatClientBuilder, Use*,<br/>GetResponseAsync&lt;T&gt;| N5
  N3["N3 RAG"] -->|contexto recuperado =<br/>entrada no confiable| N5
  N4["N4 Agentes y herramientas"] -->|herramientas, bucle,<br/>spans invoke_agent/execute_tool| N5
  N5["N5 Operación, calidad<br/>y seguridad"] -->|pipeline de producción,<br/>pruebas, controles OWASP| N6["N6 Caso Movilidad Urbana"]
  N5 -.revisa.-> N3
  N5 -.revisa.-> N4
  N0["N0 Marco didáctico"] -->|escenarios y actores| N5
```

| Con | Qué recibe N5 | Qué entrega N5 |
|---|---|---|
| N0 | Escenarios didácticos (el lector que despliega, el que prueba) | Preguntas guía §5 formuladas por escenario |
| N1 | Definición de alucinación/grounding y la franja «Monitoring & Logging» del diagrama | Herramientas para medir el grounding (`GroundednessEvaluator`) y para observar la capa |
| N2 | El pipeline `ChatClientBuilder` y la salida estructurada `GetResponseAsync<T>` | El orden recomendado de las capas de *middleware* (caché, telemetría, rate limiting) con evidencia E2, y las pruebas de contrato E3 |
| N3 | Qué entra al contexto desde la base vectorial | Tratar el contenido recuperado como no confiable (LLM01 indirecta, LLM08), `RetrievalEvaluator` y `GroundednessEvaluatorContext` |
| N4 | Herramientas (`AIFunction`) y el bucle de invocación | Privilegio mínimo, aprobación humana (`ApprovalRequiredAIFunction`), límites de iteración (`MaximumIterationsPerRequest`), `ToolCallAccuracyEvaluator`, OWASP Agentic |
| N6 | El caso de uso concreto (p. ej. clasificar respuestas de encuesta) | El proyecto de pruebas, la configuración de telemetría y secretos, la lista de controles que la demo tiene que mostrar |

---

## 2. Definiciones precisas

Formato: **qué es** / **qué problema resuelve** / **qué no es**.

### 2.1 Observabilidad de la capa de IA (OpenTelemetry + convenciones GenAI)
- **Qué es**: instrumentar cada llamada al modelo con *spans*, métricas y eventos de OpenTelemetry que siguen las *Semantic Conventions for Generative AI*: atributos `gen_ai.operation.name`, `gen_ai.provider.name`, `gen_ai.request.model`, `gen_ai.usage.input_tokens`, entre otros. El nombre del span sigue el patrón `{gen_ai.operation.name} {gen_ai.request.model}` (`F02`).
- **Problema**: sin esto, una llamada al modelo es una caja negra. No se sabe qué modelo respondió, cuántos tokens consumió (es decir, cuánto costó) ni cuánto tardó.
- **Qué no es**: no es una convención estable. Todo el documento está en estado **Development** (`F02`, `F03`). Tampoco registra el contenido por defecto: los mensajes (`gen_ai.input.messages`, `gen_ai.output.messages`, `gen_ai.system_instructions`) son atributos **Opt-In** (`F02`).

### 2.2 `OpenTelemetryChatClient` / `UseOpenTelemetry`
- **Qué es**: un `IChatClient` delegante de `Microsoft.Extensions.AI` que «adheres to the OpenTelemetry Semantic Conventions for Generative AI systems» y suma métricas y spans alrededor de cualquier `IChatClient` (`F05`).
- **Problema**: da telemetría GenAI sin depender del proveedor. Funciona igual con Ollama, OpenAI o un cliente falso (E2).
- **Qué no es**: no exporta nada por sí solo. Hace falta registrar el `ActivitySource` y el `Meter` en el SDK de OpenTelemetry, y un exportador. Por defecto **no** incluye contenido: `EnableSensitiveData` vale `false` salvo que `OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT=true`, y fijar la propiedad gana sobre la variable (`F06`).

### 2.3 Aspire y su dashboard
- **Qué es**: Aspire, que desde la versión 13 dejó de llamarse «.NET Aspire» y tiene casa en aspire.dev (`F09`), orquesta recursos de desarrollo (contenedores, proyectos) desde un AppHost. Su dashboard muestra trazas, métricas y logs OTLP, y trae un **visualizador GenAI**, «a specialized dialog for viewing GenAI telemetry data», que «works best when message content is recorded to telemetry» (`F10`).
- **Problema**: ver en desarrollo, sin montar una plataforma de observabilidad, la conversación, las herramientas y los tokens de cada llamada.
- **Qué no es**: no es un sistema de monitoreo de producción. La integración Ollama de Aspire no es de Microsoft: es del **Community Toolkit** (`CommunityToolkit.Aspire.Hosting.Ollama`) (`F11`).

### 2.4 Prueba determinista con `IChatClient` falso
- **Qué es**: implementar `IChatClient` con respuestas fijas para probar la lógica propia (parseo, validación, reglas) sin modelo. La documentación oficial muestra la estructura con un `SampleChatClient` (`F05`) y dice que la abstracción «facilitates testing and mocking» (`F04`).
- **Problema**: los modelos no devuelven lo mismo ante entradas idénticas (N1 `F03`). Con un falso, una prueba de CI no pasa ni falla por azar.
- **Qué no es**: no mide la calidad del modelo. Prueba *tu* código ante respuestas conocidas, incluidas las malformadas (E3).

### 2.5 Prueba de contrato de salida estructurada
- **Qué es**: verificar que (a) el esquema JSON que se le pide al modelo es el esperado y (b) el código maneja tanto una respuesta válida como una inválida. `GetResponseAsync<T>` envía un `ChatResponseFormatJson` con esquema derivado de `T` y expone `TryGetResult` (E3).
- **Problema**: el modelo puede no respetar el formato. OWASP pide «define and validate expected output formats» con código determinista (`F13`).
- **Qué no es**: no valida la semántica. Un JSON bien formado puede traer un valor fuera de catálogo. Eso lo atrapa un evaluador propio (E4).

### 2.6 `Microsoft.Extensions.AI.Evaluation`
- **Qué es**: un conjunto de bibliotecas para evaluar «the quality and safety of responses generated by AI models», construido sobre las abstracciones de M.E.AI (`F07`). Paquetes: `Evaluation` (núcleo), `Quality` (evaluadores que **usan un LLM** como juez), `NLP` (BLEU/GLEU/F1, sin IA), `Safety` (usa el **servicio de evaluación de Microsoft Foundry**), `Reporting` (caché de respuestas y almacenamiento de resultados), `Reporting.Azure` y `Console` (la herramienta `dotnet aieval`) (`F07`).
- **Evaluadores de calidad** (`F07`): `RelevanceEvaluator`, `CompletenessEvaluator`, `RetrievalEvaluator`, `FluencyEvaluator`, `CoherenceEvaluator`, `EquivalenceEvaluator`, `GroundednessEvaluator`, `RelevanceTruthAndCompletenessEvaluator` (experimental) y, orientados a agentes, `IntentResolutionEvaluator`, `TaskAdherenceEvaluator` y `ToolCallAccuracyEvaluator`. **[corregido en la verificación adversarial]** La página `F07` marca como experimental solo a `RelevanceTruthAndCompletenessEvaluator`, pero en el ensamblado 10.11.0 los tres orientados a agentes también llevan `[Experimental("AIEVAL001")]` (V7): usarlos exige suprimir `AIEVAL001`.
- **Evaluadores de seguridad** (`F07`): `GroundednessProEvaluator`, `ProtectedMaterialEvaluator`, `UngroundedAttributesEvaluator`, `HateAndUnfairnessEvaluator`, `SelfHarmEvaluator`, `ViolenceEvaluator`, `SexualEvaluator`, `CodeVulnerabilityEvaluator`, `IndirectAttackEvaluator` y `ContentHarmEvaluator` (los cuatro de daño en una sola pasada).
- **Problema**: medir de forma repetible cualidades que una aserción clásica no captura: relevancia, coherencia, fidelidad al contexto y uso de herramientas.
- **Qué no es**: no es determinista cuando el juez es un LLM. La propia documentación sugiere no hacer fallar el build por un resultado individual y seguir tendencias en el reporte (`F08`). Safety **no funciona offline**: requiere suscripción de Azure y un proyecto de Foundry (`F12`).

### 2.7 Inyección de prompt (directa e indirecta)
- **Qué es**: según OWASP LLM01:2025, la **directa** ocurre cuando «a user's prompt input directly alters the behavior of the model». La **indirecta**, cuando «an LLM accepts input from external sources, such as websites or files» y ese contenido trae instrucciones ocultas (`F13`). El trabajo de Greshake et al. (2023) mostró la inyección indirecta en aplicaciones reales integradas con LLM (`F20`).
- **En RAG**: según OWASP, RAG «do[es] not fully mitigate prompt injection», y un documento alterado en el repositorio de recuperación se convierte en vía de inyección indirecta (`F13`). En la imagen de entrada, la Vector DB es una superficie de ataque (LLM08 Vector and Embedding Weaknesses, `F14`).
- **Qué no es**: no se resuelve con un system prompt más firme. OWASP lo plantea como defensa en capas: restringir comportamiento, validar formato, filtrar entrada y salida, privilegio mínimo, aprobación humana, segregar contenido externo y pruebas adversariales (`F13`). *Spotlighting* (Hines et al., 2024) es una técnica de segregación que marca el contenido no confiable (`F21`).

### 2.8 Agencia excesiva y privilegio mínimo de herramientas
- **Qué es**: LLM06:2025 Excessive Agency (`F14`). En agentes, ASI02 *Tool Misuse and Exploitation* y ASI03 *Identity and Privilege Abuse* del OWASP Top 10 for Agentic Applications 2026 (`F15`, nombres confirmados contra el PDF oficial en la verificación adversarial, V10).
- **En .NET**: el bucle de `FunctionInvokingChatClient` tiene límites configurables (`MaximumIterationsPerRequest`, por defecto 40; `MaximumConsecutiveErrorsPerRequest`, por defecto 3; `TerminateOnUnknownCalls`, por defecto `false`; valores leídos en V6), y existe `ApprovalRequiredAIFunction` con `ToolApprovalRequestContent` para pedir aprobación antes de ejecutar (E7, verificado por inspección del ensamblado 10.11.0; los dos tipos viven en `Microsoft.Extensions.AI.Abstractions` y no llevan `[Experimental]` a nivel de tipo, V6; la semántica exacta queda para N4).
- **Qué no es**: describir en el prompt «no borres nada» no es un control de autorización. OWASP pide mantener funciones y tokens en el código y no exponérselos al modelo (`F13`).

### 2.9 Caché de respuestas (`DistributedCachingChatClient`)
- **Qué es**: un `IChatClient` delegante que guarda las respuestas como JSON en un `IDistributedCache`. Si llega la misma historia, devuelve la respuesta guardada sin llamar al modelo (`F05`, `F16`).
- **Problema**: costo y latencia ante solicitudes repetidas. En evaluación hace que CI sea reproducible y barato: la entrada vence a los 14 días por defecto (`F08`).
- **Qué no es**: no es una caché semántica (preguntas parecidas no coinciden) y no garantiza fidelidad total al deserializar (`RawRepresentation` se pierde) (`F16`). Las opciones forman parte de la clave: con otra temperatura, la caché no acierta (E2).

### 2.10 Ventana de contexto y cuantización (criterio general)
- **Ventana de contexto**: Ollama documenta 4096 tokens por defecto en su FAQ (`F17`), mientras que la página «Context length» describe un valor por defecto que depende de la VRAM (4k con menos de 24 GiB, 32k entre 24 y 48 GiB, 256k con 48 GiB o más) y se ajusta con `OLLAMA_CONTEXT_LENGTH` (`F18`). Las dos páginas se contradicen (§8). Más contexto no es mejor contexto: Liu et al. (2023) muestran que el rendimiento cae cuando la información relevante queda en el medio de contextos largos (`F22`).
- **Cuantización**: «lowers the memory requirements of loading and using a model by storing the weights in a lower precision while trying to preserve as much accuracy as possible» (int8, int4…) (`F19`). Es un trade-off entre memoria y calidad, no una mejora gratis.
- **Qué no es**: la ventana no es memoria. Lo que no se reenvía, el modelo no lo ve (N1 §2.4).

### 2.11 Local vs nube
- **Ollama**: un servidor local que escucha en `127.0.0.1:11434` por defecto, cambiable con `OLLAMA_HOST`. Procesa una petición por modelo a la vez por defecto (`OLLAMA_NUM_PARALLEL`=1) y descarga el modelo de memoria a los 5 minutos de inactividad (`F17`). Para .NET, el paquete recomendado es `OllamaSharp`, porque `Microsoft.Extensions.AI.Ollama` está **deprecado** (E0).
- **Foundry Local**: «an end-to-end local AI solution» que corre en el dispositivo, con SDK para C#, JS, Rust y Python, inferencia vía ONNX Runtime y API compatible con OpenAI. Es GA desde el 2026-04-09 según el blog oficial (`F23`, `F24`). Está pensado para un usuario por dispositivo. La propia documentación dice que no es un stack de inferencia de servidor y recomienda vLLM/Triton para concurrencia (`F23`).
- **ONNX Runtime GenAI**: bucle de generación para modelos ONNX con API C# (`F25`). La página oficial dice que «this API is in preview and is subject to change» (lo dice de la API `generate()` en general), aunque el paquete NuGet 0.18.0 se publica sin sufijo de preview (E0).
- **Nube**: más capacidad y modelos más grandes, a cambio de costo por token y de que los datos salen de la organización **[criterio propio]**.

### 2.12 Secretos en desarrollo
- **Qué es**: Secret Manager (`dotnet user-secrets`) guarda los secretos fuera del árbol del proyecto, en `~/.microsoft/usersecrets/<id>/secrets.json` en Linux. Microsoft advierte que «doesn't encrypt the stored secrets… It's for development purposes only» (`F26`).
- **Variables de entorno**: pisan las fuentes de configuración anteriores. Usar `__` en lugar de `:` porque Bash no admite `:` (`F26`).
- **Qué no es**: ni user-secrets ni las variables de entorno sirven como almacén de producción. Para eso Microsoft remite a Azure Key Vault (`F26`).

---

## 3. Estado actual verificado (2026-10-25)

### 3.1 Paquetes NuGet (E0: `https://api.nuget.org/v3-flatcontainer/<id>/index.json` y registro `registration5-gz-semver2`, consultados el 2026-10-25)

| Paquete | Última estable | Última preview | Fecha de la última | Estado |
|---|---|---|---|---|
| Microsoft.Extensions.AI | 10.11.0 | — | 2026-10-14 | GA |
| Microsoft.Extensions.AI.Abstractions | 10.11.0 | — | 2026-10-14 | GA |
| Microsoft.Extensions.AI.Evaluation | 10.11.0 | — | 2026-10-14 | GA |
| Microsoft.Extensions.AI.Evaluation.Quality | 10.11.0 | — | 2026-10-14 | GA |
| Microsoft.Extensions.AI.Evaluation.Reporting | 10.11.0 | — | 2026-10-14 | GA |
| Microsoft.Extensions.AI.Evaluation.Reporting.Azure | 10.11.0 | — | 2026-10-14 | GA |
| Microsoft.Extensions.AI.Evaluation.Console (`dotnet aieval`) | 10.11.0 | — | 2026-10-14 | GA |
| Microsoft.Extensions.AI.Evaluation.Safety | **—** | 10.11.0-preview.1.26513.7 | 2026-10-14 | **solo preview** (la doc instala con `--prerelease`, `F12`) |
| Microsoft.Extensions.AI.Evaluation.NLP | **—** | 10.11.0-preview.1.26513.7 | 2026-10-14 | **solo preview** |
| Microsoft.Extensions.AI.Ollama | — | 9.7.0-preview.1.25356.2 | 2025-07-08 | **DEPRECADO**: «This package is deprecated and the OllamaSharp package is recommended», alternativa `OllamaSharp` |
| OllamaSharp | 5.5.0 | — | 2026-09-30 | GA (tercero, recomendado por Microsoft) |
| CommunityToolkit.Aspire.Hosting.Ollama | 13.6.1 | 13.6.1-beta.950 | 2026-10-26 | GA, Community Toolkit. El 2026-10-25 la estable era 13.6.0 (2026-10-01); 13.6.1 confirmada el 2026-10-26 en la reanudación (R1) |
| CommunityToolkit.Aspire.OllamaSharp | 13.6.1 | 13.6.1-beta.950 | 2026-10-26 | GA, Community Toolkit. El 2026-10-25 la estable era 13.6.0 (2026-10-01); 13.6.1 confirmada el 2026-10-26 en la reanudación (R1) |
| Aspire.Hosting.OpenAI | 13.6.4 | — | 2026-10-24 | GA |
| Aspire.OpenAI (cliente) | **—** | 13.6.4-preview.1.26523.11 | 2026-10-24 | solo preview |
| Aspire.Hosting.AppHost / Aspire.AppHost.Sdk | 13.6.4 | — | 2026-10-24 | GA |
| `Aspire.Hosting.Ollama` | — | — | — | **no existe** en nuget.org (404). La integración es de CommunityToolkit |
| OpenTelemetry / OpenTelemetry.Extensions.Hosting / OpenTelemetry.Exporter.OpenTelemetryProtocol | 1.20.1 | — | 2026-10-20 | GA |
| Microsoft.Extensions.Caching.Memory | 10.0.14 | 11.0.0-rc.3.26522.148 | — | GA |
| Microsoft.Extensions.Caching.StackExchangeRedis | 10.0.14 (2026-10-25) | 11.0.0-rc.3.26522.148 | 2026-10-25 | GA |
| Microsoft.Extensions.Caching.Hybrid | 10.11.0 | — | 2026-10-14 | GA |
| Microsoft.Extensions.Compliance.Redaction | 10.11.0 | — | — | GA (redacción de datos en logs, ver §8) |
| Microsoft.ML.OnnxRuntimeGenAI (y `.Cuda`) | 0.18.0 | — | 2026-10-14 | versión 0.x. La doc la llama preview (`F25`) |
| Microsoft.AI.Foundry.Local | 2.2.1 | — | 2026-10-21 | GA (`F24`) |

### 3.2 Convenciones semánticas GenAI de OpenTelemetry
- **Se mudaron de repositorio**. La página `opentelemetry.io/docs/specs/semconv/gen-ai/` y el `README` del repo `semantic-conventions` dicen ahora «GenAI semantic conventions have moved to the OpenTelemetry GenAI semantic conventions repository… no longer maintained in this repository» (`F01`). El repo nuevo `open-telemetry/semantic-conventions-genai` se creó el 2026-05-05 y su último push fue el 2026-10-24 (API de GitHub, E0; al 2026-10-26 el último push es de ese día, R5). No tiene releases publicados y su *Schema URL* figura como «TODO» (`F03`).
- **Estado**: todos los documentos (`README`, `client-inference.md`, `gen-ai-agent-spans.md`, `gen-ai-spans.md`) dicen **Status: Development** (`F02`, `F03`).
- **Documentos actuales**: Client Inference, Client Embeddings, Events, Exceptions, Metrics, Inference Token Metrics, Model spans, Agent spans, más Anthropic, Azure AI Inference, AWS Bedrock, OpenAI y MCP (`F03`). **[corregido en la reanudación de la verificación adversarial]** *Client Embeddings* (`client-embeddings.md`, métricas `gen_ai.client.embeddings.duration` y `gen_ai.client.embeddings.operation.input_tokens`) entró al índice el 2026-10-26 (R5); la lista anterior, del 2026-10-25, no lo traía.
- **Transición**: la versión v1.37.0 del repo anterior pedía a las instrumentaciones introducir `OTEL_SEMCONV_STABILITY_OPT_IN` con el valor `gen_ai_latest_experimental` para emitir la última versión experimental y dejar de emitir la de v1.36.0 o anterior (`F27`). **[verificado en la verificación adversarial]** El repo nuevo no menciona `OTEL_SEMCONV_STABILITY_OPT_IN` ni `gen_ai_latest_experimental` en ningún archivo (V8: clon superficial de `main` y `grep -r`, sin coincidencias).
- **Lo que emite M.E.AI 10.11.0** (E2, E6): `ActivitySource` y `Meter` llamados `Experimental.Microsoft.Extensions.AI`; span `chat {modelo}` con `gen_ai.operation.name`, `gen_ai.request.model`, `gen_ai.provider.name`, `gen_ai.request.temperature`, `gen_ai.response.model`, `gen_ai.usage.input_tokens` y `gen_ai.usage.output_tokens`; métricas `gen_ai.client.token.usage` ({token}), `gen_ai.client.operation.duration` (s), `gen_ai.client.operation.time_to_first_chunk` (s) y `gen_ai.client.operation.time_per_output_chunk` (s). M.E.AI ya usa `gen_ai.provider.name`, el atributo que la convención vigente marca como Required (`F02`). Con el cliente falso de la sonda ese atributo sale **vacío** (E2: `gen_ai.provider.name=`), porque el valor sale de los metadatos del proveedor.
- **[corregido en la verificación adversarial] Desfase de nombres de métricas** (V9): los cuatro nombres de métricas que emite M.E.AI 10.11.0 coinciden con la última versión del repo anterior que traía GenAI (`semantic-conventions` v1.41.0). En el repo nuevo (`semantic-conventions-genai`, `main` al 2026-10-21) `gen_ai.client.token.usage` ya no existe, y las métricas de inferencia pasaron a `gen_ai.client.inference.duration`, `gen_ai.client.inference.time_to_first_chunk`, `gen_ai.client.inference.time_per_output_chunk` y `gen_ai.client.inference.usage.input_tokens`/`output_tokens` (más `cache_read`, `cache_write` y `reasoning`). `gen_ai.client.operation.duration` sigue definida para operaciones genéricas. Un dashboard armado con los nombres de la convención vigente no encuentra las métricas de M.E.AI 10.11.0.

### 3.3 Aspire
- Aspire 13 dejó de llamarse «.NET Aspire» y la documentación vive en **aspire.dev**. Las URLs de learn.microsoft.com redirigen con 301 (p. ej. `/dotnet/aspire/community-toolkit/ollama` → `aspire.dev/integrations/ai/ollama/`) (`F09`, `F11`).
- Ollama en el AppHost: `builder.AddOllama("ollama")`, `.AddModel(...)`, `.WithDataVolume()`, `.WithGPUSupport()`, `.WithOpenWebUI()`, y `.WithReference(modelo)` en el proyecto consumidor (`F11`). Del lado del cliente: `builder.AddOllamaApiClient("…").AddChatClient()` / `.AddEmbeddingGenerator()` y sus variantes con clave. La connection string tiene la forma `Endpoint=http://localhost:11434;Model=llama3` (`F11b`).
- El dashboard trae el visualizador GenAI, que aparece en Aspire 9.5 (`F10`, `F28`; confirmado en la página oficial `aspire.dev/whats-new/aspire-9-5/`: «Aspire 9.5 introduces the GenAI visualizer», versión del 2025-09-25) y se mejoró en 13.2 (`F28`). Imagen independiente: `mcr.microsoft.com/dotnet/aspire-dashboard`, UI en 18888 y OTLP en 18889/18890, con `ASPIRE_DASHBOARD_UNSECURED_ALLOW_ANONYMOUS=true` **solo para desarrollo local** (`F28`).

### 3.4 OWASP
- **Top 10 for LLM Applications 2025** (`F14`), nombres exactos: LLM01:2025 Prompt Injection · LLM02:2025 Sensitive Information Disclosure · LLM03:2025 Supply Chain · LLM04:2025 Data and Model Poisoning · LLM05:2025 Improper Output Handling · LLM06:2025 Excessive Agency · LLM07:2025 System Prompt Leakage · LLM08:2025 Vector and Embedding Weaknesses · LLM09:2025 Misinformation · LLM10:2025 Unbounded Consumption. La página no anuncia una edición 2026 de esta lista (`F14`).
- **Top 10 for Agentic Applications 2026**, publicado el 2025-12-09 (`F15`): ASI01 Agent Goal Hijack · ASI02 Tool Misuse and Exploitation · ASI03 Identity and Privilege Abuse · ASI04 Agentic Supply Chain Vulnerabilities · ASI05 Unexpected Code Execution · ASI06 Memory & Context Poisoning · ASI07 Insecure Inter-Agent Communication · ASI08 Cascading Failures · ASI09 Human-Agent Trust Exploitation · ASI10 Rogue Agents. La página oficial no los muestra fuera del documento descargable. **[verificado en la verificación adversarial]** Los diez nombres coinciden con el PDF oficial («OWASP Top 10 For Agentic Applications 2026», Version 2026, December 2025, CC BY-SA 4.0), descargado del enlace de la página `F15` (V10). El PDF escribe ASI06 con `&`.

### 3.5 Local
- Foundry Local es GA (blog oficial del 2026-04-09, `F24`). Lo soportan Windows, macOS (Apple silicon) y Linux, y su catálogo curado incluye Qwen, Phi, Mistral, DeepSeek y GPT OSS (`F23`). En Windows, la doc instala `Microsoft.AI.Foundry.Local.WinML` (según el resumen de búsqueda, `F24`). **[verificado en la verificación adversarial]** El paquete existe en nuget.org: última estable 1.2.4, del 2026-07-30, con otra numeración que `Microsoft.AI.Foundry.Local` 2.2.1 (V1). Que la doc lo indique para Windows sigue sin verificar.
- Ollama: valores por defecto en `F17`/`F18`, deprecación de `Microsoft.Extensions.AI.Ollama` en E0.

### 3.6 Evidencia ejecutada (sonda N5)

Proyecto de consola `net10.0` corrido en un contenedor con .NET SDK 10.0.400. Paquetes: Microsoft.Extensions.AI 10.11.0, Evaluation/Quality/Reporting 10.11.0, Caching.Memory 10.0.14, OpenTelemetry 1.20.1. Comando: `dotnet run` dentro del contenedor, con la caché de NuGet en un volumen fuera del repo. No se usó modelo real: todas las respuestas salen de un `FakeChatClient` (§4.3). Salida literal, con una sola grafía cambiada: la versión de ensamblado de cuatro componentes se escribe «10.11.0 rev 0» para que no la marque el patrón de IP de AC-7:

```text
E1 M.E.AI asm: 10.11.0 rev 0; Eval.Quality asm: 10.11.0 rev 0
E2 inner calls after 3 requests (2 iguales + 1 con otra temperatura): 2
E2 span: chat fake-model | gen_ai.operation.name=chat, gen_ai.request.model=fake-model, gen_ai.provider.name=, gen_ai.request.temperature=0, gen_ai.response.model=fake-model, gen_ai.usage.input_tokens=12, gen_ai.usage.output_tokens=8
E2 span: chat fake-model | gen_ai.operation.name=chat, gen_ai.request.model=fake-model, gen_ai.provider.name=, gen_ai.request.temperature=0.7, gen_ai.response.model=fake-model, gen_ai.usage.input_tokens=12, gen_ai.usage.output_tokens=8
E3 TryGetResult=True -> Bache/Alta
E3 malformed TryGetResult=False
E3 malformed .Result throws JsonException
E3 schema sent: {"$schema":"https://json-schema.org/draft/2020-12/schema","type":"object","properties":{"categoria":{"type":"string"},"prioridad":{"type":"string"}},"required":["categoria","prioridad"]}
E4 custom metric value=False failed=True reason=prioridad fuera del catálogo: Urgentisima
E4 GroundednessEvaluator.GroundednessMetricName=Groundedness; ctx=Microsoft.Extensions.AI.Evaluation.Quality.GroundednessEvaluatorContext
E4 RelevanceEvaluator metric=Relevance; Coherence=Coherence; ToolCallAccuracy=Tool Call Accuracy
E5 scenario metric=True
E5 files: results/probe/N5.Clasificacion.Bache/1.json cache/N5.Clasificacion.Bache/1/<hash>/contents.data cache/N5.Clasificacion.Bache/1/<hash>/entry.json
E6 activity:Experimental.Microsoft.Extensions.AI
E6 meter:Experimental.Microsoft.Extensions.AI instrument:gen_ai.client.token.usage unit:{token}
E6 meter:Experimental.Microsoft.Extensions.AI instrument:gen_ai.client.operation.duration unit:s
E6 meter:Experimental.Microsoft.Extensions.AI instrument:gen_ai.client.operation.time_to_first_chunk unit:s
E6 meter:Experimental.Microsoft.Extensions.AI instrument:gen_ai.client.operation.time_per_output_chunk unit:s
```

Lectura:
- **E2**: con `UseDistributedCache` **antes** de `UseOpenTelemetry` (la caché queda más afuera), de 3 llamadas solo 2 llegaron al cliente interno y solo 2 generaron span. El acierto de caché **no aparece en la telemetría**. La temperatura forma parte de la clave: con otra temperatura, no acertó.
- **E3**: `GetResponseAsync<T>` manda un esquema JSON 2020-12 derivado del record. Ante texto no JSON, `TryGetResult` devuelve `false` y `.Result` lanza `JsonException`. El contrato se puede probar sin modelo.
- **E4/E5**: un `IEvaluator` propio, determinista, detecta un valor fuera de catálogo dentro de un JSON válido. `DiskBasedReportingConfiguration` guarda resultados (`results/…`) y caché (`cache/…`) en disco.
- **E7** (inspección de ensamblados 10.11.0): están presentes `ApprovalRequiredAIFunction`, `ToolApprovalRequestContent`, `MaximumIterationsPerRequest`, `MaximumConsecutiveErrorsPerRequest`, `TerminateOnUnknownCalls`, `IncludeDetailedErrors` y `AllowConcurrentInvocation`. No aparece ningún tipo `HybridCach*` dentro de M.E.AI.

---

## 4. Snippets representativos

Compatibles con Microsoft.Extensions.AI 10.11.0 y OllamaSharp 5.5.0. Donde dice «adaptado», el cambio respecto del original se indica.

### 4.1 Pipeline de producción: caché + rate limiting + telemetría (adaptado de `F05`, sección *Functionality pipelines* y *Custom IChatClient middleware*)

```csharp
using Microsoft.Extensions.AI;
using OllamaSharp;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// Endpoint por configuración (variable de entorno OLLAMA_ENDPOINT); default localhost (R-PRIV).
var endpoint = builder.Configuration["OLLAMA_ENDPOINT"] ?? "http://localhost:11434";
var model = builder.Configuration["OLLAMA_MODEL"] ?? "qwen3";

builder.Services.AddDistributedMemoryCache();           // en producción: Redis (StackExchangeRedis)
builder.Services.AddChatClient(new OllamaApiClient(new Uri(endpoint), model))
    .UseOpenTelemetry()                                   // más afuera: ve también los aciertos de caché
    .UseDistributedCache()
    .UseLogging();

// Registrar la fuente y el medidor que emite M.E.AI (nombre verificado en E6).
builder.Services.AddOpenTelemetry()
    .WithTracing(t => t.AddSource("Experimental.Microsoft.Extensions.AI").AddOtlpExporter())
    .WithMetrics(m => m.AddMeter("Experimental.Microsoft.Extensions.AI").AddOtlpExporter());
```

Cambios respecto de `F05`: el orden es telemetría → caché (en `F05` aparece caché → funciones → telemetría), por E2. También se registra en el SDK de OpenTelemetry con `AddSource`/`AddMeter` usando el nombre verificado en E6 y el exportador OTLP. `AddOtlpExporter` es del paquete `OpenTelemetry.Exporter.OpenTelemetryProtocol` 1.20.1. **[verificado en la verificación adversarial]** El snippet compila tal cual en un proyecto `Microsoft.NET.Sdk.Web` `net10.0` (M.E.AI 10.11.0, OllamaSharp 5.5.0, OpenTelemetry.Extensions.Hosting y Exporter.OpenTelemetryProtocol 1.20.1), y el `IChatClient` resuelto por DI es un `OpenTelemetryChatClient`, es decir, la telemetría queda más afuera (V2). **[criterio propio]** Qué capa va más afuera depende de qué se quiere medir: con la telemetría afuera, el span de un acierto de caché sale muy rápido y, como la caché devuelve la respuesta guardada con su `Usage`, también trae tokens. Esto quedó medido en V3: telemetría afuera y caché adentro, dos llamadas idénticas, una sola al cliente interno, **dos spans** y los dos con `gen_ai.usage.input_tokens=12`. Para medir costo real hay que contar solo los spans de la capa interna.

### 4.2 Rate limiting como *middleware* (tomado de `F05`, *Custom IChatClient middleware*)

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using OllamaSharp;
using System.Threading.RateLimiting;

RateLimiter rateLimiter = new ConcurrencyLimiter(new() { PermitLimit = 1, QueueLimit = int.MaxValue });

IChatClient client = new OllamaApiClient(new Uri("http://localhost:11434"), "llama3.1");
client = client.AsBuilder()
    .UseDistributedCache(new MemoryDistributedCache(Options.Create(new MemoryDistributedCacheOptions())))
    .Use(async (messages, options, nextAsync, cancellationToken) =>
    {
        using var lease = await rateLimiter.AcquireAsync(permitCount: 1, cancellationToken).ConfigureAwait(false);
        if (!lease.IsAcquired)
            throw new InvalidOperationException("Unable to acquire lease.");
        await nextAsync(messages, options, cancellationToken);
    })
    .UseOpenTelemetry()
    .Build();
```

Responde a LLM10 Unbounded Consumption (`F14`) y a `OLLAMA_NUM_PARALLEL`=1 (`F17`).

**[corregido en la verificación adversarial]** El snippet de `F05` (copiado tal cual en la versión anterior de este dossier) llama a `.UseDistributedCache()` sin argumento y fuera de DI, y además no traía `using OllamaSharp;`. Compilado y corrido con M.E.AI 10.11.0, `Build()` lanza `InvalidOperationException: No service for type 'Microsoft.Extensions.Caching.Distributed.IDistributedCache' has been registered.` (V4). Sin un `IServiceProvider`, la caché se pasa como instancia, como hace la sección *Cache responses* de `F05` (requiere `Microsoft.Extensions.Caching.Memory`). La otra salida es registrarla en DI y construir con `Build(services)`, como en el ejemplo `UseRateLimiting` de `F05`.

### 4.3 `IChatClient` falso para pruebas deterministas (adaptado de `F05`, *Implementation examples*; compilado y corrido en E2–E5)

```csharp
sealed class FakeChatClient(Func<IEnumerable<ChatMessage>, string> responder) : IChatClient
{
    public int Calls;
    public ChatOptions? LastOptions;

    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages,
        ChatOptions? options = null, CancellationToken ct = default)
    {
        Interlocked.Increment(ref Calls);
        LastOptions = options;
        return Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, responder(messages)))
        {
            ModelId = options?.ModelId,
            Usage = new UsageDetails { InputTokenCount = 12, OutputTokenCount = 8 }
        });
    }

    public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages,
        ChatOptions? options = null, [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
    {
        var r = await GetResponseAsync(messages, options, ct);
        foreach (var u in r.ToChatResponseUpdates()) yield return u;
    }

    public object? GetService(Type t, object? k = null) => t.IsInstanceOfType(this) ? this : null;
    public void Dispose() { }
}
```

Cambios respecto de `F05`: el `SampleChatClient` oficial responde al azar, y este responde con una función inyectada. Además cuenta llamadas, guarda las opciones recibidas y completa `Usage`, para poder hacer aserciones sobre caché, esquema y telemetría.

> **Rótulo R-06** (dominio ilustrativo del dossier; la guía usa Movilidad Urbana): la categoría de ejemplo de E3/E5 y de §4.4 es la de la sonda ejecutada; se deja tal cual.

### 4.4 Prueba de contrato de salida estructurada (propio, verificado en E3)

```csharp
record Clasificacion(string Categoria, string Prioridad);

// Caso feliz
var ok = new FakeChatClient(_ => """{"categoria":"Bache","prioridad":"Alta"}""");
var r1 = await ok.GetResponseAsync<Clasificacion>("Clasificá: hay un pozo en Mitre 300");
Assert.IsTrue(r1.TryGetResult(out var c) && c.Prioridad == "Alta");

// El modelo no respeta el formato: el código no debe romperse
var bad = new FakeChatClient(_ => "no es JSON");
var r2 = await bad.GetResponseAsync<Clasificacion>("x");
Assert.IsFalse(r2.TryGetResult(out _));

// El esquema que se envía es parte del contrato
var schema = (bad.LastOptions?.ResponseFormat as ChatResponseFormatJson)?.Schema?.ToString();
StringAssert.Contains(schema, "\"required\"");
```

(Aserciones al estilo MSTest. La sonda imprime lo mismo con `Console.WriteLine`.)

### 4.5 Evaluador propio determinista (adaptado de `F08`, `WordCountEvaluator`; verificado en E4)

```csharp
using System.Text.Json;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.AI.Evaluation;

sealed class PrioridadValidaEvaluator : IEvaluator
{
    public const string Nombre = "Prioridad válida";
    static readonly string[] Validas = ["Baja", "Media", "Alta"];
    public IReadOnlyCollection<string> EvaluationMetricNames => [Nombre];

    public ValueTask<EvaluationResult> EvaluateAsync(IEnumerable<ChatMessage> messages, ChatResponse modelResponse,
        ChatConfiguration? chatConfiguration = null, IEnumerable<EvaluationContext>? additionalContext = null,
        CancellationToken cancellationToken = default)
    {
        bool ok = false; string reason;
        try
        {
            var c = JsonSerializer.Deserialize<Clasificacion>(modelResponse.Text, new JsonSerializerOptions(JsonSerializerDefaults.Web));
            ok = c is not null && Validas.Contains(c.Prioridad);
            reason = ok ? "prioridad dentro del catálogo" : $"prioridad fuera del catálogo: {c?.Prioridad}";
        }
        catch (JsonException) { reason = "la respuesta no es JSON"; }

        var metric = new BooleanMetric(Nombre, ok, reason)
        {
            Interpretation = new EvaluationMetricInterpretation(
                ok ? EvaluationRating.Good : EvaluationRating.Unacceptable, failed: !ok, reason: reason)
        };
        return new(new EvaluationResult(metric));
    }
}
```

Cambios respecto de `F08`: usa `BooleanMetric` en lugar de `NumericMetric` y valida contra un catálogo de dominio en lugar de contar palabras.

### 4.6 Evaluación con LLM juez, caché y reporte (adaptado de `F08`; el juez es cualquier `IChatClient`)

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.AI.Evaluation;
using Microsoft.Extensions.AI.Evaluation.Quality;
using Microsoft.Extensions.AI.Evaluation.Reporting;
using Microsoft.Extensions.AI.Evaluation.Reporting.Storage;
using OllamaSharp;

IChatClient juez = new OllamaApiClient(
    new Uri(Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT") ?? "http://localhost:11434"),
    Environment.GetEnvironmentVariable("OLLAMA_MODEL") ?? "qwen3");

ReportingConfiguration config = DiskBasedReportingConfiguration.Create(
    storageRootPath: Path.Combine(Path.GetTempPath(), "eval"),
    evaluators: [new RelevanceEvaluator(), new CoherenceEvaluator(), new GroundednessEvaluator(), new PrioridadValidaEvaluator()],
    chatConfiguration: new ChatConfiguration(juez),
    enableResponseCaching: true,
    executionName: Environment.GetEnvironmentVariable("BUILD_NUMBER") ?? $"{DateTime.Now:yyyyMMddTHHmmss}");

await using ScenarioRun run = await config.CreateScenarioRunAsync("MovilidadUrbana.RespuestasDeEncuesta.Clasificar");
var mensajes = new List<ChatMessage> { new(ChatRole.User, "Clasificá: hay un pozo en Mitre 300") };
ChatResponse respuesta = await run.ChatConfiguration!.ChatClient.GetResponseAsync(mensajes);
EvaluationResult resultado = await run.EvaluateAsync(mensajes, respuesta,
    additionalContext: [new GroundednessEvaluatorContext("<texto recuperado por RAG>")]);
```

Generar el reporte (`F08`):

```bash
dotnet tool install --create-manifest-if-needed Microsoft.Extensions.AI.Evaluation.Console
dotnet tool run aieval report --path <ruta-del-storage> --output report.html
```

Cambios respecto de `F08`: el juez es Ollama en lugar de Azure OpenAI, se agrega `GroundednessEvaluator` con su contexto (tipo verificado en E4) y el nombre de ejecución sale del número de build, como sugiere `F08`. **[verificado en la verificación adversarial]** El snippet compila tal cual (solo cambia `await using` por un bloque `await using (...) { }` para convivir con otro código en el mismo `Program.cs`). Con un juez falso, `EvaluateAsync(..., additionalContext: [new GroundednessEvaluatorContext("…")])` corre y devuelve las métricas `Relevance`, `Coherence`, `Groundedness` y `Prioridad válida` (V5). `GroundednessEvaluatorContext` tiene un único constructor `(string)` (V6). **[no verificado]** que un modelo Qwen local sea un juez fiable (§8).

### 4.7 Telemetría con contenido solo en desarrollo (adaptado de `F05` y `F06`)

```csharp
builder.Services.AddChatClient(inner)
    .UseOpenTelemetry(configure: c =>
        c.EnableSensitiveData = builder.Environment.IsDevelopment());
```

Alternativa sin código: `OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT=true` solo en el entorno de desarrollo (`F06`, `F10`).

**[verificado en la verificación adversarial]** El snippet compila (V2). Sin la variable, `EnableSensitiveData` vale `false`. Con la variable definida **al arrancar el proceso** vale `true`. Si se fija con `Environment.SetEnvironmentVariable` con el proceso ya corriendo, el valor siguió en `false` en la sonda (V6): la variable se define en el entorno de ejecución, no desde el código.

### 4.8 Ollama en Aspire (tomado de `F11` y `F11b`)

```csharp
// AppHost
var ollama = builder.AddOllama("ollama").WithDataVolume();
var qwen = ollama.AddModel("qwen3");
builder.AddProject<Projects.MovilidadUrbana_Web>("web").WithReference(qwen);

// Proyecto consumidor (CommunityToolkit.Aspire.OllamaSharp)
builder.AddOllamaApiClient("ollama-qwen3").AddChatClient();
```

Cambios respecto de `F11`: los nombres del recurso y del proyecto, y el modelo. **[corregido en la verificación adversarial]** La versión anterior usaba `AddOllamaApiClient("qwen3")`. Según `F11` y `F11b`, el recurso de modelo toma el nombre `"<servidor>-<modelo saneado>"`: `"llama3"` sobre `"ollama"` da `"ollama-llama3"`, y los puntos pasan a guiones (`"phi3.5"` da `"ollama-phi3-5"`). El proyecto consumidor recibe una connection con ese nombre, así que para `AddModel("qwen3")` corresponde `"ollama-qwen3"`. La regla está en la doc, pero el snippet no se compiló ni se corrió con Aspire **[no verificado]**.

### 4.9 Secretos y configuración (tomado de `F26`)

```bash
dotnet user-secrets init
dotnet user-secrets set "OpenAI:ApiKey" "<valor>"
# Variables de entorno en Bash: usar __ en lugar de :
export Ollama__Endpoint="http://localhost:11434"
```

**[corregido en la verificación adversarial]** `Ollama__Endpoint` llega a la configuración como la clave `Ollama:Endpoint` (`F26`), y ningún snippet de este dossier la lee: 4.1 lee `builder.Configuration["OLLAMA_ENDPOINT"]` y 4.6 lee `Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT")`. El ejemplo ilustra la regla del `__`. Para los snippets de arriba, la variable es `OLLAMA_ENDPOINT`.

---

## 5. Preguntas guía con respuestas explicativas

**P1. ¿Para qué agrego `UseOpenTelemetry` si ya tengo logs?**
El log cuenta *que* pasó algo. Los spans y métricas GenAI dicen *cuánto* (tokens, duración, tiempo al primer chunk) con atributos estándar que cualquier backend OTLP entiende (E6, `F02`). Aplica cuando hay más de una llamada al modelo por operación o hay que controlar el costo. Si es una prueba de concepto de una sola llamada, alcanza con `UseLogging` **[criterio propio]**.

**P2. ¿Activo `EnableSensitiveData` en producción para depurar mejor?**
En general, no. Por defecto, la telemetría lleva metadatos pero no contenido (`F06`). Con contenido, las trazas pasan a guardar prompts, argumentos y resultados de herramientas, que en Movilidad Urbana pueden incluir datos personales del ciudadano. Eso es LLM02 Sensitive Information Disclosure trasladado al backend de observabilidad (`F14`). Activarlo en desarrollo es razonable, y el visualizador de Aspire lo necesita para mostrar conversaciones (`F10`). En producción, solo con una política de retención y redacción explícita **[criterio propio]**.

**P3. ¿Puedo confiar en que la convención `gen_ai.*` no cambie?**
No. Está en Development y en 2026 se mudó de repositorio (`F01`, `F03`). Cambió `gen_ai.system` por `gen_ai.provider.name` (el registro de atributos de v1.37.0 marca `gen_ai.system` como «Deprecated… Replaced by `gen_ai.provider.name`», V8; M.E.AI ya emite la clave nueva, E2). Además, los nombres de las métricas de inferencia cambiaron en el repo nuevo y M.E.AI 10.11.0 todavía emite los de v1.41.0 (§3.2, V9), y la v1.37.0 previó un opt-in para la transición (`F27`). Conclusión práctica: los dashboards y alertas tienen que depender de pocos atributos y quedar versionados junto con la instrumentación **[criterio propio]**.

**P4. ¿Cuándo uso un `IChatClient` falso y cuándo `Microsoft.Extensions.AI.Evaluation`?**
El falso prueba **tu** código: parseo, ramas de error, reglas de dominio y que el esquema enviado sea el correcto (E3). Es determinista, corre en cada build y no necesita red. La evaluación mide **la respuesta del modelo**: relevancia, coherencia, groundedness, uso de herramientas (`F07`). Necesita un modelo juez, no es determinista y conviene mirarla como tendencia y no como compuerta dura (`F08`). Un proyecto serio tiene las dos. Si solo puede tener una, que sea la determinista, porque la otra sin la primera mide un sistema cuyo código no está probado **[criterio propio]**.

**P5. Mi salida estructurada «anda» con Qwen. ¿Hace falta probar el caso malformado?**
Sí. Que hoy ande no es un contrato. OWASP pide validar los formatos con código determinista (`F13`). E3 muestra que `.Result` lanza `JsonException` ante una respuesta no JSON: si el código usa `.Result` sin `TryGetResult`, la primera respuesta rara del modelo tira abajo la petición. Además, un JSON válido puede traer valores fuera de catálogo («Urgentisima», E4). Por eso conviene un evaluador o validador de dominio.

**P6. ¿Los evaluadores de Safety me sirven con un modelo local?**
No directamente. Usan el servicio de evaluación de Microsoft Foundry y requieren suscripción de Azure, un hub y un proyecto (`F12`). El paquete está solo en preview (E0). Con un modelo local se pueden usar los de Quality (el juez es cualquier `IChatClient`) y los de NLP (sin IA, también en preview). Para seguridad sin nube quedan las pruebas adversariales propias que OWASP recomienda (`F13`) **[criterio propio]**.

**P7. Hago RAG sobre respuestas de encuesta que escriben los ciudadanos. ¿Qué riesgo nuevo agrego?**
Inyección indirecta. El texto recuperado llega al contexto del modelo y puede traer instrucciones (`F13`, `F20`). Si el mismo flujo tiene herramientas que escriben (cambiar el estado de una respuesta de encuesta), el riesgo se compone con LLM06 Excessive Agency (`F14`). Controles: separar y marcar el contenido no confiable (*spotlighting*, `F21`), privilegio mínimo en herramientas, aprobación humana para las acciones de escritura (`ApprovalRequiredAIFunction`, E7) y evaluar con `IndirectAttackEvaluator` cuando se tenga Foundry (`F07`).

**P8. ¿La caché de respuestas me ahorra siempre?**
Solo ante solicitudes idénticas: misma historia y mismas opciones. E2 muestra que con otra temperatura no acierta. Sirve en evaluaciones repetidas (`F08`), en preguntas frecuentes literales o en clasificación de textos repetidos. No sirve en chat libre, donde casi ninguna historia se repite **[criterio propio]**. Ojo con el orden de las capas: si la caché está más afuera que la telemetría, los aciertos no se ven (E2). Y cuidado con cachear respuestas con datos personales en una caché compartida **[criterio propio]**.

**P9. ¿Ollama, Foundry Local o la nube?**
Ollama es un servidor local fácil de compartir en una red de laboratorio. Atiende una petición por modelo por defecto (`F17`), así que para varios usuarios simultáneos hay que ajustar `OLLAMA_NUM_PARALLEL` y medir. Foundry Local está pensado para embeber el modelo en la app del usuario final, un usuario por dispositivo, y Microsoft dice explícitamente que no es un stack de servidor (`F23`). ONNX Runtime GenAI es la pieza de bajo nivel, con la API declarada en preview (`F25`). La nube aporta modelos más grandes a cambio de costo por token y de sacar los datos de la organización. Como el código depende de `IChatClient`, la decisión se toma en la raíz de composición y se puede revisar sin tocar los casos de uso (N2) **[criterio propio]**.

**P10. ¿Subo la ventana de contexto al máximo para «que entre todo»?**
No por reflejo. Más contexto consume más memoria (multiplicado por `OLLAMA_NUM_PARALLEL`, `F17`) y no garantiza que el modelo use bien la información del medio (`F22`). Conviene recuperar menos y mejor (N3) y fijar la ventana de forma explícita, porque el valor por defecto de Ollama depende de la versión y de la VRAM (`F17` vs `F18`).

**P11. ¿Dónde pongo la API key del proveedor de nube?**
En desarrollo, en user-secrets, sabiendo que no se cifran (`F26`). En CI y en producción, en variables de entorno del entorno de ejecución o en un almacén de secretos (`F26`). Nunca en `appsettings.json` versionado. En repos públicos, tampoco el endpoint real de la infraestructura: va `http://localhost:11434` por defecto y se pisa por variable (R-PRIV).

---

## 6. Criterios de calidad y antipatrones

### 6.1 Criterios de calidad (para que la mesa revise N6 y la guía)
1. Toda llamada al modelo pasa por un pipeline con telemetría registrada en el SDK de OpenTelemetry (fuente y medidor `Experimental.Microsoft.Extensions.AI`, E6).
2. `EnableSensitiveData` queda atado al entorno, nunca `true` fijo en el código (`F06`).
3. Hay pruebas deterministas con `IChatClient` falso para el caso feliz, la respuesta malformada y el valor fuera de catálogo (E3, E4).
4. La salida estructurada se consume con `TryGetResult` o capturando `JsonException`, nunca con `.Result` a ciegas (E3).
5. Las evaluaciones con LLM juez usan caché y un nombre de ejecución estable, y se leen como tendencia (`F08`).
6. Cada herramienta con efectos (escritura) tiene autorización en código, aprobación humana cuando corresponde y límites de iteración (`F13`, E7).
7. El contenido recuperado (RAG) y el que viene del usuario se tratan como no confiables (`F13`).
8. Hay un límite de concurrencia o tasa frente al servidor de modelos (LLM10, `F05`, `F17`).
9. Ningún secreto ni endpoint real queda en archivos versionados (`F26`, R-PRIV).
10. Cada paquete en preview (Safety, NLP, Aspire.OpenAI, OnnxRuntimeGenAI) se declara como tal en la guía (E0).

### 6.2 Antipatrones
| Antipatrón | Por qué es malo | Fuente |
|---|---|---|
| Usar `Microsoft.Extensions.AI.Ollama` | Deprecado; recomiendan OllamaSharp | E0 |
| Buscar `Aspire.Hosting.Ollama` | No existe. La integración es `CommunityToolkit.Aspire.Hosting.Ollama` | E0, `F11` |
| Citar `opentelemetry.io/docs/specs/semconv/gen-ai/` como especificación vigente | La página dice «Moved… no longer maintained» | `F01` |
| `EnableSensitiveData = true` fijo | Datos personales en las trazas (LLM02) | `F06`, `F14` |
| Caché más afuera que la telemetría sin saberlo | Los aciertos desaparecen de las métricas | E2 |
| Hacer fallar el build por un puntaje individual de un LLM juez | Pruebas inestables. La doc sugiere usar tendencias | `F08` |
| «Seguridad por system prompt» | No es un control. OWASP pide privilegio mínimo en código | `F13` |
| Herramientas de escritura sin aprobación ni límite de iteraciones | Agencia excesiva (LLM06, ASI02) | `F14`, `F15` |
| Concatenar texto recuperado al prompt sin marcarlo | Inyección indirecta | `F13`, `F21` |
| Ventana de contexto «al máximo» por defecto | Memoria y calidad, «lost in the middle» | `F17`, `F22` |
| Exponer el dashboard de Aspire con acceso anónimo fuera de local | La variable es solo para desarrollo | `F28` |
| Usar user-secrets como almacén de producción | No cifra. Es solo para desarrollo | `F26` |
| Asumir que Foundry Local sirve a muchos usuarios | Pensado para un usuario por dispositivo | `F23` |

---

## 7. Tabla de fuentes

Fecha de consulta: 2026-10-25 en todas.

| id | URL | Qué respalda |
|---|---|---|
| F01 | https://opentelemetry.io/docs/specs/semconv/gen-ai/ y https://raw.githubusercontent.com/open-telemetry/semantic-conventions/main/docs/gen-ai/README.md | Las convenciones GenAI se mudaron de repositorio |
| F02 | https://github.com/open-telemetry/semantic-conventions-genai/blob/main/docs/gen-ai/client-inference.md (y `gen-ai-spans.md`, `gen-ai-agent-spans.md`) | Estado Development, nombre de span, `gen_ai.provider.name` Required, atributos Opt-In de contenido, spans `invoke_agent`/`create_agent` |
| F03 | https://github.com/open-telemetry/semantic-conventions-genai (README y `docs/gen-ai/README.md`) | Repo nuevo, sin releases, Schema URL «TODO», lista de documentos |
| F04 | https://learn.microsoft.com/en-us/dotnet/ai/microsoft-extensions-ai (ms.date 2026-09-14) | Paquetes M.E.AI, `UseOpenTelemetry`, «facilitates testing and mocking» |
| F05 | https://learn.microsoft.com/en-us/dotnet/ai/ichatclient (ms.date 2026-03-13) | Caché, telemetría, logging, pipeline, `DelegatingChatClient`, rate limiting, DI, `SampleChatClient`, reducción y ruteo experimentales |
| F06 | https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.ai.opentelemetrychatclient.enablesensitivedata | Default `false`, `OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT` |
| F07 | https://learn.microsoft.com/en-us/dotnet/ai/evaluation/libraries (ms.date 2026-04-09) | Paquetes y evaluadores de Evaluation, caché, `dotnet aieval` |
| F08 | https://learn.microsoft.com/en-us/dotnet/ai/evaluation/evaluate-with-reporting (ms.date 2026-04-09) | `DiskBasedReportingConfiguration`, `ScenarioRun`, `WordCountEvaluator`, caché de 14 días, tendencias en lugar de compuerta, comandos de reporte |
| F08b | https://learn.microsoft.com/en-us/dotnet/ai/evaluation/evaluate-ai-response (ms.date 2026-04-09) | Quickstart `CoherenceEvaluator`, `NumericMetric`, `Interpretation` |
| F09 | https://aspire.dev/whats-new/aspire-13/ (vía resultado de búsqueda) y https://visualstudiomagazine.com/articles/2025/11/12/microsoft-releases-aspire-13.aspx | Renombre «.NET Aspire» → «Aspire», aspire.dev |
| F10 | https://aspire.dev/dashboard/explore/ | Visualizador GenAI, necesita contenido registrado |
| F11 | https://aspire.dev/integrations/ai/ollama/ollama-host/ (redirige desde learn.microsoft.com/dotnet/aspire/community-toolkit/ollama) | `CommunityToolkit.Aspire.Hosting.Ollama`, `AddOllama`/`AddModel`/`WithDataVolume`/`WithGPUSupport`/`WithOpenWebUI` |
| F11b | https://aspire.dev/integrations/ai/ollama/ollama-connect/ | `CommunityToolkit.Aspire.OllamaSharp`, `AddOllamaApiClient().AddChatClient()`, connection string |
| F12 | https://learn.microsoft.com/en-us/dotnet/ai/evaluation/evaluate-safety (ms.date 2026-04-09) | Safety requiere Azure y un proyecto Foundry, `--prerelease`, `ContentSafetyServiceConfiguration` |
| F13 | https://genai.owasp.org/llmrisk/llm01-prompt-injection/ | Definiciones de inyección directa e indirecta, 7 mitigaciones, RAG no mitiga |
| F14 | https://genai.owasp.org/llm-top-10/ | Nombres LLM01–LLM10:2025 |
| F15 | https://genai.owasp.org/resource/owasp-top-10-for-agentic-applications-for-2026/ (fecha 2025-12-09); nombres ASI de https://www.giskard.ai/knowledge/owasp-top-10-for-agentic-application-2026, https://www.f5.com/glossary/owasp-top-10-for-agentic-ai-applications y https://www.promptfoo.dev/docs/red-team/owasp-agentic-ai/ | OWASP Agentic 2026. Los nombres se confirmaron con el PDF oficial, enlazado desde esa página (`genai.owasp.org/download/52117/`), en la verificación adversarial |
| F16 | https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.ai.distributedcachingchatclient | Serialización JSON, fidelidad no garantizada, `CacheKeyAdditionalValues`, thread-safety |
| F17 | https://docs.ollama.com/faq | Contexto por defecto 4096, `OLLAMA_CONTEXT_LENGTH`/`num_ctx`, `OLLAMA_KV_CACHE_TYPE`, `OLLAMA_HOST`, `OLLAMA_KEEP_ALIVE`, `OLLAMA_NUM_PARALLEL`=1, datos locales |
| F18 | https://docs.ollama.com/context-length | Contexto por defecto según VRAM, `ollama ps` |
| F19 | https://huggingface.co/docs/transformers/main/en/quantization/overview | Definición de cuantización |
| F20 | https://arxiv.org/abs/2302.12173 (Greshake et al., «Not what you've signed up for…») | Inyección indirecta en aplicaciones reales |
| F21 | https://arxiv.org/abs/2403.14720 (Hines et al., «Defending Against Indirect Prompt Injection Attacks With Spotlighting») | Spotlighting |
| F22 | https://arxiv.org/abs/2307.03172 (Liu et al., «Lost in the Middle») | Uso de contextos largos |
| F23 | https://learn.microsoft.com/en-us/azure/foundry-local/what-is-foundry-local (ms.date 2026-05-15) | Qué es Foundry Local, plataformas, catálogo, no es stack de servidor |
| F24 | https://devblogs.microsoft.com/foundry/foundry-local-ga/ (2026-04-09) y https://learn.microsoft.com/en-us/azure/foundry-local/get-started | GA de Foundry Local, paquete WinML |
| F25 | https://onnxruntime.ai/docs/genai/ | ONNX Runtime GenAI, API C#, «in preview» |
| F26 | https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets (ms.date 2026-05-13) | Secret Manager no cifra, ruta en Linux, `__`, Key Vault |
| F27 | https://raw.githubusercontent.com/open-telemetry/semantic-conventions/v1.37.0/docs/gen-ai/gen-ai-spans.md | `OTEL_SEMCONV_STABILITY_OPT_IN=gen_ai_latest_experimental` |
| F28 | https://opentelemetry.io/blog/2026/genai-observability/ y https://devblogs.microsoft.com/aspire/aspire-dashboard-improvements-export-and-telemetry/ (2026-03-31) | Spans `invoke_agent`/`chat`/`execute_tool`, `docker run` del dashboard, acceso anónimo solo local, visualizador en 9.5 y mejoras en 13.2 |
| E0 | API de nuget.org (flatcontainer + registration5-gz-semver2) y API de GitHub `repos/open-telemetry/semantic-conventions-genai` | Versiones, fechas, deprecación, existencia de paquetes, fecha de creación del repo |
| E1–E6 | Sonda N5 (§3.6), .NET SDK 10.0.400 en contenedor | Comportamiento de caché, telemetría, salida estructurada, evaluación y reporte |
| E7 | Inspección de `Microsoft.Extensions.AI.dll` y `.Abstractions.dll` 10.11.0 | Tipos de aprobación y límites del bucle de funciones |

---

## 8. Abierto / no verificado

1. ~~**Nombres ASI01–ASI10**~~ **Resuelto en la verificación adversarial**: confirmados contra el PDF oficial (V10).
2. ~~**Opt-in de estabilidad en el repo nuevo**~~ **Resuelto en la verificación adversarial**: el repo nuevo no lo menciona (V8). El texto citado es de v1.37.0 (`F27`).
3. **Contexto por defecto de Ollama**: la FAQ (`F17`) dice 4096 y «Context length» (`F18`) dice que depende de la VRAM. No verifiqué cuál aplica a la versión del servidor Ollama de la LAN del laboratorio. Hay que medirlo con `ollama ps`.
4. **Qwen como juez de evaluación**: no verifiqué la calidad ni la estabilidad de `RelevanceEvaluator`/`CoherenceEvaluator`/`GroundednessEvaluator` con un modelo Qwen local. La documentación oficial usa `gpt-5` (`F08`). La sonda N5 no tocó el servidor (sin `OLLAMA_ENDPOINT` en el entorno de este despacho). Pendiente para N6: una corrida real con caché.
5. **Snippets**: en la verificación adversarial 4.1, 4.2 (corregido), 4.3, 4.4, 4.5, 4.6 y 4.7 compilaron y corrieron (V2–V5). Sigue pendiente el **4.8** (Aspire), que no se compiló.
6. **`ApprovalRequiredAIFunction` / `ToolApprovalRequestContent`**: existen en 10.11.0 (E7) y no llevan `[Experimental]` a nivel de tipo (V6). Su semántica sigue sin verificar. N4 la tiene que documentar.
7. **Caché con `HybridCache`**: M.E.AI no tiene `UseHybridCache` en 10.11.0 (E7: no hay tipos `HybridCach*`). `Microsoft.Extensions.Caching.Hybrid` 10.11.0 existe por separado. **Verificación adversarial**: `HybridCache` **no** implementa `IDistributedCache` (V6), así que no se le puede pasar directamente a `UseDistributedCache`.
8. **Redacción de datos personales en logs** (`Microsoft.Extensions.Compliance.Redaction` 10.11.0): existe (E0), pero no verifiqué cómo integrarlo con `LoggingChatClient` ni con los atributos OTel de contenido.
9. **Foundry Local en Linux con C#**: la doc dice que Linux está soportado (`F23`), pero no probé el paquete `Microsoft.AI.Foundry.Local` 2.2.1 ni el `.WinML` (este último existe en NuGet como 1.2.4, V1, pero no lo probé).
10. **ONNX Runtime GenAI y `IChatClient`**: **verificación adversarial**: el tipo `OnnxRuntimeGenAIChatClient` (y `OnnxRuntimeGenAIChatClientOptions`) está en `Microsoft.ML.OnnxRuntimeGenAI.dll` del paquete `Microsoft.ML.OnnxRuntimeGenAI.Managed` 0.18.0, que depende de `Microsoft.Extensions.AI.Abstractions` 9.8.0 (V11). No verifiqué su uso ni la documentación oficial.
11. ~~**Versión del visualizador GenAI**~~ **Resuelto en la verificación adversarial**: la página oficial `aspire.dev/whats-new/aspire-9-5/` dice «Aspire 9.5 introduces the GenAI visualizer».
12. **Fecha de publicación del OWASP Top 10 for LLM Applications 2025**: no la verifiqué en la página oficial.

---

## Verificación adversarial

Hecha el 2026-10-25 por un verificador independiente del autor del dossier. El mandato era refutar. Cada afirmación verificable se volvió a contrastar con la fuente primaria. Las URLs de learn.microsoft.com, aspire.dev, docs.ollama.com, genai.owasp.org y onnxruntime.ai se abrieron de nuevo. nuget.org se consultó por `flatcontainer` y `registration5-gz-semver2`, y GitHub por su API y un clon superficial. Los snippets se compilaron y corrieron. Evidencia ejecutada (sonda de verificación en un directorio de trabajo fuera del repo, contenedor `mcr.microsoft.com/dotnet/sdk:10.0`, que hoy reporta SDK 10.0.403, con la caché de NuGet en un volumen Docker; sin modelo real, con el mismo `FakeChatClient` de §4.3):

```text
V2  V41 build ok: OpenTelemetryChatClient                      (4.1 tal cual en Sdk.Web + 4.7 tal cual)
V3  VORD inner=1 spans=2 tokens=12,12                          (telemetría afuera, caché adentro, 2 llamadas iguales)
V4  V42 build threw InvalidOperationException: No service for type 'Microsoft.Extensions.Caching.Distributed.IDistributedCache' has been registered.
    V42 build ok                                               (después de pasar MemoryDistributedCache como instancia)
V5  V44 ok=True / V44 bad=False schema={... "required":["categoria","prioridad"]}
    V46 metrics: Relevance; Coherence; Groundedness; Prioridad válida   (4.6 con additionalContext)
V6  VFIC MaxIter=40 MaxErr=3 TermUnknown=False Detailed=False Concurrent=False
    VTYPE ApprovalRequiredAIFunction: SI asm=Microsoft.Extensions.AI.Abstractions experimental=
    VTYPE ToolApprovalRequestContent: SI asm=Microsoft.Extensions.AI.Abstractions experimental=
    VSENS default=False / VSENS env=False (variable fijada con el proceso corriendo)
    VSENS default=True  / VSENS env=True  (docker run -e OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT=true)
    VHYB HybridCache implements IDistributedCache: False
    VDCC props: JsonSerializerOptions,CacheKeyAdditionalValues,CoalesceStreamingUpdates
    VGEC ctors: String
V7  VQ IntentResolutionEvaluator/TaskAdherenceEvaluator/ToolCallAccuracyEvaluator/RelevanceTruthAndCompletenessEvaluator: experimental=AIEVAL001
    VQ CompletenessEvaluator/RetrievalEvaluator/FluencyEvaluator/EquivalenceEvaluator: experimental=(ninguno)
V8  git clone --depth 1 open-telemetry/semantic-conventions-genai; grep -r "OTEL_SEMCONV_STABILITY_OPT_IN\|gen_ai_latest_experimental" -> sin coincidencias
    semantic-conventions v1.37.0 docs/registry/attributes/gen-ai.md: `gen_ai.system` "Deprecated, use `gen_ai.provider.name` instead."
V9  semconv v1.41.0 gen-ai-metrics.md: gen_ai.client.operation.duration, ...time_per_output_chunk, ...time_to_first_chunk, gen_ai.client.token.usage
    semconv v1.42.0–v1.44.0: sin métricas gen_ai.client.* (mudado)
    semantic-conventions-genai main client-inference.md: gen_ai.client.inference.{duration,time_to_first_chunk,time_per_output_chunk,usage.*,operation.*}
V10 PDF oficial genai.owasp.org/download/52117/ (pdftotext): "OWASP Top 10 For Agentic Applications 2026 … Version 2026 December 2025"; ASI01 Agent Goal Hijack … ASI10 Rogue Agents
V11 Microsoft.ML.OnnxRuntimeGenAI.Managed 0.18.0 nupkg: Microsoft.ML.OnnxRuntimeGenAI.dll contiene OnnxRuntimeGenAIChatClient y OnnxRuntimeGenAIChatClientOptions; nuspec depende de Microsoft.Extensions.AI.Abstractions 9.8.0
V1  nuget: (las 29 filas de §3.1) coinciden; además Microsoft.AI.Foundry.Local.WinML 1.2.4 (2026-07-30)
```

| Afirmación | Veredicto | Evidencia |
|---|---|---|
| Versiones y estados de §3.1 (M.E.AI y Evaluation 10.11.0 GA; Safety/NLP solo 10.11.0-preview.1.26513.7; OllamaSharp 5.5.0; CommunityToolkit 13.6.1/13.6.1-beta.950 al 2026-10-26 (13.6.0/13.6.1-beta.938 el 2026-10-25); Aspire.* 13.6.4; Aspire.OpenAI solo preview; OpenTelemetry 1.20.1; Caching 10.0.14/11.0.0-rc.3; Hybrid y Redaction 10.11.0; OnnxRuntimeGenAI 0.18.0; Foundry.Local 2.2.1) | confirmada | V1 (flatcontainer + registration, fechas coincidentes) |
| `Aspire.Hosting.Ollama` no existe en nuget.org | confirmada | V1: HTTP 404 |
| `Microsoft.Extensions.AI.Ollama` deprecado, alternativa OllamaSharp, 9.7.0-preview.1.25356.2 del 2025-07-08 | confirmada | V1: campo `deprecation` del registro |
| La página `opentelemetry.io/docs/specs/semconv/gen-ai/` dice que se mudó | confirmada | `F01` reabierta: «GenAI semantic conventions have moved…», «no longer maintained in this repository» |
| Repo `semantic-conventions-genai` creado el 2026-05-05, último push el 2026-10-24, sin releases, Schema URL «TODO» | confirmada | API de GitHub (`created_at`, `pushed_at`, `releases`=0, `tags`=[]); `README.md` raíz, sección «Schema URL: TODO» |
| Estado Development, span `{gen_ai.operation.name} {gen_ai.request.model}`, `gen_ai.provider.name` Required, mensajes Opt-In | confirmada | `client-inference.md` del repo nuevo |
| Lista de documentos del repo nuevo (§3.2) | confirmada | `docs/gen-ai/README.md` (V8, clon) |
| Spans `invoke_agent` / `create_agent` / `execute_tool` | confirmada | `gen-ai-agent-spans.md` (clon) y `F28` |
| `OTEL_SEMCONV_STABILITY_OPT_IN=gen_ai_latest_experimental` en v1.37.0; ausente en el repo nuevo | confirmada (antes no verificada) | `F27` línea 35; V8 |
| `gen_ai.system` reemplazado por `gen_ai.provider.name` (atribuido a `F02`) | corregida (la fuente) | Lo dice el registro de atributos de v1.37.0, no `F02` (V8) |
| M.E.AI 10.11.0 emite `gen_ai.client.token.usage`, `…operation.duration`, `…time_to_first_chunk`, `…time_per_output_chunk` y eso es la convención GenAI | corregida | Los nombres son los de semconv v1.41.0. El repo nuevo usa `gen_ai.client.inference.*` y ya no define `gen_ai.client.token.usage` (V9) |
| M.E.AI «ya usa» `gen_ai.provider.name` | confirmada con matiz | E2: la clave aparece, pero vacía con el cliente falso |
| `EnableSensitiveData` vale `false` salvo `OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT=true`, y la propiedad gana | confirmada | `F06` reabierta; V6 (la variable se lee del entorno del proceso) |
| `OpenTelemetryChatClient` «adheres to the OpenTelemetry Semantic Conventions for Generative AI systems» | confirmada | `F05` reabierta |
| «facilitates testing and mocking» | confirmada | `F04` reabierta (ms.date 2026-09-14) |
| `SampleChatClient` responde al azar | confirmada | `F05` *Implementation examples* |
| Orden en `F05` *Functionality pipelines*: caché → funciones → telemetría | confirmada | `F05` |
| Snippet 4.1 compila en ASP.NET Core y la telemetría queda afuera | confirmada (antes no verificada) | V2 |
| Con la telemetría afuera, los aciertos de caché generan span y reportan tokens | confirmada (antes criterio) | V3 |
| Snippet 4.2 «tomado de `F05`» funciona tal cual | corregida | V4: `Build()` lanza `InvalidOperationException` sin `IDistributedCache`. Faltaba `using OllamaSharp;`. Corregido pasando la caché como instancia |
| Snippets 4.3, 4.4 y 4.5 compilan y se comportan como dicen E3/E4 | confirmada | V5 |
| Snippet 4.6 con `additionalContext` y `GroundednessEvaluatorContext(string)` | confirmada (antes no verificada) | V5, V6 |
| Snippet 4.7 compila | confirmada | V2 |
| Snippet 4.8: `AddOllamaApiClient("qwen3")` | corregida | `F11`/`F11b`: el nombre del recurso es `ollama-qwen3`. No se compiló con Aspire (no verificado) |
| Snippet 4.9: `Ollama__Endpoint` | corregida (aclaración) | Llega como la clave `Ollama:Endpoint`, que no lee ningún snippet. Los snippets leen `OLLAMA_ENDPOINT` |
| Paquetes de Evaluation y sus roles (Quality usa LLM; NLP sin IA; Safety con el servicio de Foundry; Reporting; Reporting.Azure; Console/`dotnet aieval`) | confirmada | `F07` reabierta (ms.date 2026-04-09) |
| Lista de evaluadores de Quality y de Safety; `ContentHarmEvaluator` cubre cuatro métricas en una pasada | confirmada | `F07` |
| Solo `RelevanceTruthAndCompletenessEvaluator` es experimental | corregida | En el ensamblado 10.11.0, Intent/TaskAdherence/ToolCallAccuracy también llevan `AIEVAL001` (V7) |
| Caché de evaluación de 14 días; no fallar el build por resultados individuales; comandos `dotnet tool install …` / `aieval report`; `executionName` desde el número de build; doc con `gpt-5`; `WordCountEvaluator` con `NumericMetric` | confirmada | `F08` reabierta |
| Safety requiere suscripción de Azure, hub y proyecto de Foundry, `--prerelease`, `ContentSafetyServiceConfiguration` | confirmada | `F12` reabierta |
| `DistributedCachingChatClient`: JSON, `RawRepresentation` ignorada, thread-safety, `CacheKeyAdditionalValues` | confirmada | `F16` reabierta; V6 |
| `FunctionInvokingChatClient`: `MaximumIterationsPerRequest`, `MaximumConsecutiveErrorsPerRequest`, `TerminateOnUnknownCalls`, `IncludeDetailedErrors`, `AllowConcurrentInvocation` | confirmada | V6 (con valores por defecto 40/3/false/false/false) |
| `ApprovalRequiredAIFunction` / `ToolApprovalRequestContent` existen; ¿`[Experimental]`? | confirmada; sin `[Experimental]` a nivel de tipo | V6 |
| `HybridCache` como backend de `UseDistributedCache` | refutada | V6: no implementa `IDistributedCache` |
| OWASP LLM01: definiciones directa/indirecta, RAG no mitiga, 7 mitigaciones, «define and validate expected output formats», funciones y tokens en código | confirmada | `F13` reabierta |
| LLM01–LLM10:2025 (nombres exactos) y que no hay edición 2026 | confirmada | `F14` reabierta |
| Fecha de publicación del Top 10 LLM 2025 | no verificada | `F14` no la da (solo traducciones de 2025-03-12 y 2025-07-22) |
| OWASP Agentic 2026 publicado el 2025-12-09; nombres ASI01–ASI10 | confirmada (antes por fuentes secundarias) | `F15` muestra «December 9, 2025»; V10 (PDF oficial «December 2025»). ASI06 se escribe con `&` |
| Ollama: 4096 por defecto (FAQ), `OLLAMA_CONTEXT_LENGTH`, `num_ctx`, `127.0.0.1:11434`, `OLLAMA_HOST`, 5 min de keep-alive, `OLLAMA_NUM_PARALLEL`=1, la RAM escala con paralelo × contexto, `OLLAMA_KV_CACHE_TYPE` | confirmada | `F17` reabierta |
| Contexto según VRAM (4k/32k/256k) y contradicción con la FAQ | confirmada | `F18` reabierta |
| Definición de cuantización (cita) | confirmada | `F19` (texto literal en el HTML) |
| Greshake et al. 2023, Hines et al. 2024 (Spotlighting), Liu et al. 2023 (Lost in the Middle) | confirmada | API de arXiv: títulos, autores y fechas 2023-02-23, 2024-03-20, 2023-07-06 |
| Foundry Local: «end-to-end local AI solution», SDK C#/JS/Rust/Python, ONNX Runtime, API compatible con OpenAI, Windows/macOS (Apple silicon)/Linux, catálogo (GPT OSS, Qwen, DeepSeek, Mistral, Phi), un usuario por dispositivo, no es stack de servidor, vLLM/Triton | confirmada | `F23` reabierta (ms.date 2026-05-15) |
| Foundry Local GA el 2026-04-09 | confirmada | `F24`: «General Availability (GA) of Foundry Local», 2026-04-09 |
| `Microsoft.AI.Foundry.Local.WinML` | confirmada su existencia | V1: 1.2.4. No se verificó que la doc lo indique para Windows |
| ONNX Runtime GenAI: «this API is in preview and is subject to change» | confirmada con matiz | `F25`: lo dice de la API `generate()`. El cuerpo de la página no menciona C# (solo el menú lateral) |
| `OnnxRuntimeGenAIChatClient` existe | confirmada (antes no verificada) | V11 |
| Aspire 13: renombre y aspire.dev; 301 desde learn.microsoft.com | confirmada | `aspire.dev/whats-new/aspire-13/` («dropping its previous .NET prefix», 2025-11-11); `curl` → 301 a `aspire.dev/integrations/ai/ollama/` |
| Integración Ollama del Community Toolkit: `AddOllama`, `AddModel`, `WithDataVolume`, `WithGPUSupport`, `WithOpenWebUI`, `WithReference`; cliente `AddOllamaApiClient().AddChatClient()`/`AddEmbeddingGenerator()` y variantes con clave; connection string `Endpoint=http://localhost:11434;Model=llama3` | confirmada | `F11`, `F11b` reabiertas |
| Visualizador GenAI: cita de `F10`; aparece en 9.5; mejoras en 13.2 | confirmada (la 9.5 antes por fuente secundaria) | `F10`; `aspire.dev/whats-new/aspire-9-5/`; `F28` (devblog del 2026-03-31) |
| Dashboard independiente: UI 18888, OTLP 18889/18890, `ASPIRE_DASHBOARD_UNSECURED_ALLOW_ANONYMOUS=true` solo local | confirmada | `F28` (blog de OTel: `docker run … -p 18888:18888 -p 4317:18889 -p 4318:18890`). El devblog de Aspire no trae ese comando |
| Secret Manager no cifra y es solo para desarrollo; ruta en Linux; `__` porque Bash no admite `:`; Key Vault para producción | confirmada | `F26` reabierta (ms.date 2026-05-13) |
| Sonda N5 con .NET SDK 10.0.400 | confirmada | `project.assets.json` de la sonda original: `sdk/10.0.400` |
| Que un Qwen local sea un juez fiable; semántica de aprobación de herramientas; integración de Redaction con `LoggingChatClient`; Foundry Local en Linux con C#; versión de Ollama del servidor del laboratorio | no verificada | Fuera del alcance ejecutable sin modelo real (se mantienen en §8) |

### Reanudación de la verificación adversarial (2026-10-26)

Segunda pasada independiente, hecha al reanudar la corrida. No reusó la sonda anterior: se escribió una nueva (consola `net10.0`, contenedor `mcr.microsoft.com/dotnet/sdk:10.0`, que reporta SDK 10.0.403, caché de NuGet fuera del repo, sin modelo real) y se volvieron a consultar nuget.org, la API de GitHub y las páginas oficiales. Salida literal de la sonda:

```text
R7 RelevanceEvaluator exp=(ninguno)            (ídem Coherence, Groundedness, Completeness, Retrieval, Fluency, Equivalence)
R7 RelevanceTruthAndCompletenessEvaluator exp=AIEVAL001
R7 IntentResolutionEvaluator exp=AIEVAL001
R7 TaskAdherenceEvaluator exp=AIEVAL001
R7 ToolCallAccuracyEvaluator exp=AIEVAL001
R6 ApprovalRequiredAIFunction asm=Microsoft.Extensions.AI.Abstractions exp=(ninguno)
R6 ToolApprovalRequestContent asm=Microsoft.Extensions.AI.Abstractions exp=(ninguno)
R6 FIC MaxIter=40 MaxErr=3 TermUnknown=False Detailed=False Concurrent=False
R6 HybridCache:IDistributedCache=False
R6 GEC ctors=String
R6 HybridCach* in MEAI: 0
R6 EnableSensitiveData default=False env=
R3 tel-afuera inner=1 spans=2 tokens=12,12
R2 cache-afuera inner=2 spans=2 name=chat m     (2 iguales + 1 con temperatura 0.7)
R4 InvalidOperationException: No service for type 'Microsoft.Extensions.Caching.Distributed.IDistributedCache' has been registered.
---  (OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT=true al arrancar)
R6 EnableSensitiveData default=True env=true
```

R1 (nuget.org, `flatcontainer` y `registration5-gz-semver2`, 2026-10-26): las 29 filas de §3.1 coinciden en versión y fecha; `Aspire.Hosting.Ollama` sigue en 404; `Microsoft.Extensions.AI.Ollama` conserva el campo `deprecation` con `alternatePackage` = `OllamaSharp`. R5: API de GitHub y `docs/gen-ai/*.md` de `semantic-conventions-genai` (`main`, 2026-10-26).

| Afirmación | Veredicto | Evidencia |
|---|---|---|
| CommunityToolkit.Aspire.Hosting.Ollama / .OllamaSharp: estable 13.6.1, preview 13.6.1-beta.950, 2026-10-26 | confirmada (antes pendiente de recheck) | R1: registro con `13.6.1` publicado el 2026-10-26 |
| Resto de versiones, fechas y estados de §3.1 | confirmada | R1 |
| Lista de documentos del repo `semantic-conventions-genai` | corregida | R5: el índice suma *Client Embeddings*, agregado el 2026-10-26 (commit «Use `gen_ai.client.embeddings.duration`…») |
| Repo nuevo sin releases, estado Development | confirmada | R5: `releases`=0; README «Status: Development» |
| Métricas del repo nuevo `gen_ai.client.inference.*`, sin `gen_ai.client.token.usage`; `gen_ai.client.operation.duration` sigue en `gen-ai-metrics.md` | confirmada | R5: `grep` de `gen_ai.client.*` sobre los `.md` |
| La página de opentelemetry.io dice «moved… no longer maintained» | confirmada | Reabierta (semconv 1.44.0) |
| Solo `RelevanceTruthAndCompletenessEvaluator` marcado experimental en `F07`, pero los tres de agentes también llevan `AIEVAL001` | confirmada | `F07` reabierta (una sola †); R7 |
| `ApprovalRequiredAIFunction`/`ToolApprovalRequestContent` en Abstractions, sin `[Experimental]` de tipo | confirmada | R6 |
| Valores por defecto de `FunctionInvokingChatClient` 40/3/false | confirmada | R6 |
| `HybridCache` no implementa `IDistributedCache`; no hay `HybridCach*` en M.E.AI | confirmada | R6 |
| `GroundednessEvaluatorContext` con único constructor `(string)` | confirmada | R6 |
| `EnableSensitiveData` falso por defecto y verdadero con la variable al arrancar | confirmada | R6; `F06` reabierta (texto literal del default y de que la propiedad gana) |
| Telemetría afuera: dos spans con tokens y una sola llamada interna; caché afuera: los aciertos no generan span; la temperatura entra en la clave | confirmada | R3, R2 |
| `.UseDistributedCache()` sin argumento y fuera de DI lanza en `Build()` | confirmada | R4 |
| Ollama: 4096 por defecto (FAQ), 127.0.0.1:11434, `OLLAMA_HOST`, 5 minutos, `OLLAMA_NUM_PARALLEL`=1 y RAM ∝ paralelo × contexto; «Context length» por VRAM 4k/32k/256k | confirmada | `F17`, `F18` reabiertas |
| Caché de evaluación de 14 días; no bloquear builds y seguir tendencias | confirmada con matiz | `F08` reabierta: agrega «only fail individual builds when there's a significant drop» |
| ms.date de `F04` (2026-09-14), `F05` (2026-03-13), `F07`/`F08`/`F12` (2026-04-09) | confirmada | Metadato `ms.date` de cada página |
| Aspire 9.5 introduce el visualizador GenAI | confirmada | `aspire.dev/whats-new/aspire-9-5/` reabierta |
| Foundry Local no es stack de servidor; remite a vLLM/Triton | confirmada | `F23` reabierta |
| OWASP Agentic 2026 fechado el 2025-12-09 | confirmada | `F15` reabierta |
