---
doc_id: BIT-16-N6
doc_type: dossier-de-investigacion
title: N6 — El caso práctico: Movilidad Urbana con capa de IA
status: borrador-para-mesa
origin: agent
confidence: 0.8
owner: investigador del núcleo N6
last_review: 2026-10-25
audience: [mesa-evaluadora, presidencia, redactores]
traces: [BIT-16-01 §N6, BIT-16-00 DC-05 DC-06 DC-07 DC-08, BIT-16-N1, BIT-16-N2, BIT-16-N4]
---

# N6 — El caso práctico: Movilidad Urbana con capa de IA (dossier de investigación)

Material de trabajo de la mesa, no la guía final. Cada afirmación técnica lleva una fuente (`F…`, §7) o una evidencia ejecutada (`E…`, §4.0). Lo que es **criterio propio** se marca así. Lo que no se pudo comprobar se marca **no verificado** y se junta en §8.

Caso base leído (sólo lectura): ia-db de Lab-E2E.WebBlazor v3.1 (README e índices 00, 01, 02, 03, 12) y el código de `src/MovilidadUrbana.ApiWeb/` y `src/MovilidadUrbana.Web/` en el commit `8fb4c3a` (2026-09-18), repo público `hdcm-dev/Lab-E2E.WebBlazor` [F01][F02].

## Índice

- [1. Ideas agrupadas y dependencias](#1-ideas-agrupadas-y-dependencias)
- [2. Definiciones](#2-definiciones)
- [3. Estado actual verificado (2026-10-25)](#3-estado-actual-verificado-2026-10-25)
- [4. Snippets y evidencia](#4-snippets-y-evidencia)
- [5. Preguntas guía con respuestas](#5-preguntas-guía-con-respuestas)
- [6. Criterios de calidad y antipatrones](#6-criterios-de-calidad-y-antipatrones)
- [7. Tabla de fuentes](#7-tabla-de-fuentes)
- [8. Abierto / no verificado](#8-abierto--no-verificado)
- [Anexo A. Diseño propuesto de la demo](#anexo-a-diseño-propuesto-de-la-demo)
- [Anexo B. Diseño propuesto de los ejemplos](#anexo-b-diseño-propuesto-de-los-ejemplos)

---

## 1. Ideas agrupadas y dependencias

### 1.1 Lo que el dominio real ofrece (y lo que no)

Antes de proponer IA hay que mirar qué datos tiene el caso. El resumen, verificado en el código [F02]:

| Elemento | Qué es | Forma de los datos | Relevancia para una capa de IA |
|---|---|---|---|
| `Localidad` | ABM: `Nombre`, `Provincia`, `CodigoPostal` (4 dígitos), `Habitantes` (≥ 1), aislada por `SessionId` | **estructurada**, pocas filas por sesión (siembra: Corrientes y Resistencia) | Consulta exacta → herramienta, no RAG. Alta desde texto libre → extracción estructurada |
| `RespuestaDeEncuesta` | 3 pasos: persona (nombre, edad 16–110, localidad), medios (catálogo de 6) + frecuencia (3), distancia 0–500 km, minutos 1–600, motivo (4) | **estructurada**, toda por catálogo o número | Encuesta conversacional (texto → `EncuestaModel`); **no hay campo de texto libre** |
| `Catalogos` | Provincias (7, lista de `string` sin clave aparte); Medios (6), Frecuencias (3), Motivos (4): tuplas `(Clave, Etiqueta)`, clave persistida → etiqueta visible | listas cerradas | Vocabulario controlado para normalizar lo que propone el modelo |
| `*Rules` | `LocalidadRules`, `EncuestaRules`: predicados puros | código | La **autoridad** que decide si una propuesta del modelo vale |
| `*Policy` | Requisitos enunciados para la persona («4 dígitos.», «Entre 16 y 110 años.») | **texto corto** (12 enunciados) | Único texto propio del dominio: corpus mínimo para ayuda con RAG |
| `Result` / mensajes | «Revise los campos marcados en rojo.» + errores por campo | texto + claves | Retroalimentación que el modelo puede leer y corregir |
| Casos de uso | `LocalidadService` (`GetAllAsync`, `SaveAsync`, `DeleteAsync`), `EncuestaService` (`CountAsync`, `ValidarPaso`, `RegistrarAsync`) | métodos .NET | Candidatos directos a herramientas (`AIFunction`) |

Tres hechos del código que condicionan el diseño:

1. **No hay consulta de resultados de la encuesta.** `IEncuestaRepository` sólo tiene `AddAsync` y `CountAsync` [F02, `Application/Abstractions/IEncuestaRepository.cs`]. Un asistente que «responde sobre resultados de la encuesta» necesita un caso de uso de lectura nuevo (p. ej. `ResultadosDeEncuestaService.ResumirAsync` con conteos por medio, motivo y localidad). Es una **extensión del dominio** que la demo debe declarar.
2. **No hay texto libre ni reglamento.** Ni la encuesta ni el ABM tienen comentarios abiertos, y el repo no trae un reglamento o normativa de movilidad [F02][F03]. La idea de «resumir o clasificar respuestas abiertas» **no aplica tal cual**: exige agregar un campo (p. ej. `Comentario`) al dominio. El RAG sólo tiene, como corpus propio, los 12 enunciados de `*Policy`, las etiquetas de `Catalogos` y los mensajes de error. Cualquier corpus mayor (una «guía de uso», un «reglamento de ejemplo») sería **contenido escrito para la demo** y debe rotularse como tal.
3. **La validación es más laxa que la política mostrada** (huecos H1–H5 de la ia-db [F03 §8]). Provincia, localidad de la encuesta, frecuencia y motivo sólo exigen «no vacío»; `medios` se valida por cantidad y `RegistrarAsync` descarta en silencio las claves desconocidas (H4: `["avion"]` pasa la validación y se registra con lista vacía). En una UI con `<select>` el hueco no se nota. Con un modelo que **propone texto**, el hueco queda expuesto: el modelo puede devolver «Corrientes Capital», «colectivo urbano» o «laburo», y la regla lo acepta. Ésta es la tensión central del núcleo.

### 1.2 Capacidades candidatas, evaluadas contra el dominio

| Id | Capacidad | Encaje con el dominio real | Mecanismo (núcleo) | Veredicto **[criterio propio]** |
|---|---|---|---|---|
| C1 | **Asistente de consulta**: «¿cuántas localidades tengo en Corrientes?», «¿qué medio usa más la gente?» | Alto. Los datos son estructurados y pocos; la respuesta exacta sale de un caso de uso | Tool calling sobre casos de uso de lectura (N2, N4) | **Entra**. Necesita el caso de uso nuevo de §1.1.1 |
| C2 | **Alta asistida de localidad** desde texto libre («agregá Goya, Corrientes, CP 3450, unos 90 mil habitantes») | Alto. El modelo extrae; `LocalidadService.SaveAsync` valida y decide | Salida estructurada (N2) + reglas del dominio | **Entra**. Demostrado con cliente falso en E1 §[3] |
| C3 | **Encuesta conversacional**: el modelo arma un `EncuestaModel` por paso y `ValidarPaso` le devuelve los errores | Alto, con riesgo. Sin normalizar contra `Catalogos`, H3–H5 dejan pasar valores fuera del catálogo | Salida estructurada + bucle de corrección + normalización | **Entra** con normalización obligatoria (§6) |
| C4 | **Ayuda con RAG** sobre requisitos y uso de la app | Bajo-medio. El corpus propio es chico (12 enunciados), así que cabría entero en el prompt | Embeddings + almacén vectorial (N3) | **Entra como ejercicio didáctico**, con la advertencia explícita de que, con este tamaño, meter todo el texto en el contexto también funciona (§5 P3) |
| C5 | **Agente con aprobación humana** para acciones que escriben (alta, baja) | Alto. La baja es destructiva y no arrastra dependientes [F03 §2] | `ApprovalRequiredAIFunction` (N4, N5) | **Entra** en la demo, sobre `DeleteAsync` |
| C6 | **Servidor MCP** que expone los casos de uso a clientes externos (VS Code, otros agentes) | Medio. Es otra superficie de entrada, como la API REST | `ModelContextProtocol.AspNetCore` (N4) | **Entra**. Demostrado en E1 §[5] |
| C7 | **Resumen o clasificación de respuestas abiertas** | **Nulo hoy**: no hay campo abierto | Clasificación con salida estructurada | **Fuera de la demo**. Va a Examples/ con datos propios del ejemplo, o se agrega `Comentario` como extensión declarada si la mesa lo decide |
| C8 | **Workflow de la encuesta** de 3 pasos con Agent Framework Workflows | Bajo. El asistente de 3 pasos ya es código determinista; MAF recomienda «si podés escribir una función, hacelo» [F08] | Workflows (N4) | **Fuera de la demo**. Sirve como contraejemplo en la guía |

### 1.3 Mapeo a las capas de la imagen y a Domain/Application/Infrastructure

Las capas de la imagen («IA ya es parte del stack», LIDR; `INPUTs/AI-Layer.png`) frente a las carpetas del caso base [F04, §2–§3]. Ubicación de puerto y adaptador alineada con N1 §4.7 (puerto en `Application/Abstractions`, adaptador en `Infrastructure`).

| Capacidad | Capa de la imagen | Domain | Application | Infrastructure | Presentación |
|---|---|---|---|---|---|
| C1 | AI Services & Agents → Backend | `Catalogos` (etiquetas) | caso de uso nuevo `ResultadosDeEncuestaService`; puerto `IAsistenteDeMovilidad` | adaptador con `IChatClient` + herramientas que envuelven servicios de Application | endpoint `POST /api/v1/asistente` (streaming) |
| C2 | LLM / Generative Models | `LocalidadRules` (deciden) | puerto `IExtractorDeLocalidad`; `LocalidadService.SaveAsync` sin cambios | adaptador `GetResponseAsync<LocalidadPropuesta>` | endpoint `POST /api/v1/localidades/desde-texto` |
| C3 | LLM / Generative Models | `EncuestaRules`, `Catalogos` | puerto `IExtractorDeEncuesta`; `EncuestaService.ValidarPaso` | adaptador + normalizador a claves de catálogo | endpoint por paso |
| C4 | RAG Pipeline (Retrieval · Embeddings · Vector DB) | — | puerto `IAyuda` | `IEmbeddingGenerator`, `VectorStoreCollection` (InMemory o SqliteVec), ingesta de `*Policy` | endpoint `POST /api/v1/ayuda` |
| C5 | AI Services & Agents | — | `LocalidadService.DeleteAsync` | `ApprovalRequiredAIFunction` | la UI muestra la solicitud y devuelve la decisión |
| C6 | Third-Party Integrations | — | servicios existentes | — | `Mcp/` con `[McpServerToolType]`, `app.MapMcp("/mcp")` (adaptador **de entrada**, como un controller) |
| Persistencia | Database: SQL DB / Vector DB | entidades | repositorios (puertos) | EF Core SQLite; vectores en memoria o en SQLite con `sqlite-vec` | — |
| Observabilidad, caché | Infrastructure: Monitoring & Logging; Cache (Redis) | — | — | `UseOpenTelemetry`, `UseLogging`, `UseDistributedCache` en el pipeline del cliente (N2 §4.5, N5) | — |

Regla que surge del mapeo **[criterio propio, coherente con N1]**: `Domain/` no recibe ninguna dependencia de IA. `Application/` define los puertos en lenguaje del caso de uso. `Infrastructure/AI/` es el único lugar que conoce `IChatClient`, prompts y almacén vectorial. Las herramientas son adaptadores finos que **llaman a los casos de uso**, nunca al repositorio. El caso base ya tiene una excepción a evitar: `LocalidadesController` lee del repositorio salteando el servicio [F04 §3.2].

### 1.4 Tensiones de integración detectadas

| # | Tensión | Evidencia | Resolución propuesta |
|---|---|---|---|
| T1 | `AddChatClient` registra el cliente como **Singleton** por defecto, y el aislamiento de datos es por `SessionContext` **Scoped** [F04 §4] | Reflexión: `AddChatClient(..., ServiceLifetime lifetime=Singleton)` [E2] | Armar `ChatOptions.Tools` **por petición**, desde servicios resueltos en el scope (como en E1 §[2]), o registrar el cliente con `ServiceLifetime.Scoped`. **No verificado**: qué `IServiceProvider` recibe `AIFunctionArguments.Services` cuando el cliente es singleton |
| T2 | Huecos H1–H5: el modelo propone texto y la regla sólo exige «no vacío» | [F03 §8] | Normalizar contra `Catalogos` en el adaptador (clave exacta o rechazo) **antes** de llamar al caso de uso. En la demo, además, endurecer la regla en la copia propia y declararlo como desvío del caso base |
| T3 | EF Core SQLite 10.0.x pide `SQLitePCLRaw` 2.1.x y `CommunityToolkit.VectorData.SqliteVec` pide ≥ 3.0.3 | nuspec [E3] | En la sonda resolvió a 3.0.3, sin advertencias, y EF Core siguió operando [E1 §[1]]. Viable, pero es una combinación de versiones mayores distintas **sin respaldo oficial**: la demo puede arrancar con InMemory y dejar SqliteVec como variante |
| T4 | Versiones mezcladas de MEAI: `Microsoft.Agents.AI` 1.26.0 arrastra `Microsoft.Extensions.VectorData.Abstractions` 10.10.0 aunque haya 10.11.0 | `dotnet list package --include-transitive` [E1] | Referenciar explícitamente todos los `Microsoft.Extensions.AI*` y `VectorData` en 10.11.0 (Central Package Management) |
| T5 | La encuesta trae datos personales (nombre, edad, localidad) | [F02, `RespuestaDeEncuesta.cs`] | Modelo local por defecto (Ollama). Herramientas que devuelven agregados, no filas con nombre. Remite a N5 |
| T6 | La cultura `es-AR` fija formatos («12,5 km») [F04 §5] | `Program.cs` del caso | El modelo puede escribir «12.5». Parsear números en el adaptador con cultura invariante y formatear al mostrar |
| T7 | `RegistrarAsync` no valida y usa `!.Value` (H6) | [F03 §8] | Ninguna herramienta expone `RegistrarAsync` directo: sólo un «registrar» que valida los tres pasos, igual que hace el controller de la API [F05 §3] |

### 1.5 Dependencias con los otros núcleos

| Núcleo | Qué toma N6 | Qué devuelve N6 |
|---|---|---|
| N0 | Escenarios, contextos y actores (BIT-16-03, todavía no escrito) | La demo como instancia de cada escenario aplicable |
| N1 | Regla puerto/adaptador; espectro llamada directa → estructurada → RAG → herramientas → agente | §1.3 dibuja la demo sobre ese mapa: si algo no entra, N1 se corrige |
| N2 | `IChatClient`, `GetResponseAsync<T>`, pipeline, `AddChatClient`, OllamaSharp 5.5.0 | T1 (singleton contra scoped), T4 (versiones) |
| N3 | `VectorStoreCollection`, InMemory/SqliteVec, ingesta | T3 (SQLitePCLRaw), el veredicto de C4 (corpus chico) |
| N4 | `AIFunctionFactory`, MAF `AsAIAgent`, aprobación humana, MCP, LangGraph | C5, C6, C8. LangGraph no entra en la demo: N4 concluye que no hay port oficial a .NET [N4 §2.13] |
| N5 | Pruebas con cliente falso, R-LLM, OTel, OWASP LLM06 | Escenarios E3 concretos: valores fuera de catálogo, baja sin aprobación |

---

## 2. Definiciones

Cada definición indica qué es, qué problema resuelve y qué no es.

**Caso de uso como herramienta.** Es un método de `Application/` (p. ej. `LocalidadService.SaveAsync`) envuelto en un `AIFunction` con `AIFunctionFactory.Create`, de modo que el modelo pueda pedir su ejecución con argumentos JSON. `FunctionInvokingChatClient` ejecuta la llamada y le devuelve el resultado al modelo [F06][E1 §[2]]. *Resuelve* que el modelo actúe sobre la aplicación sin saltear sus reglas. *No es* darle al modelo acceso al repositorio ni a SQL.

**Extracción estructurada.** Pedirle al modelo una salida con la forma de un tipo C# (`GetResponseAsync<T>`), deserializada en `ChatResponse<T>.Result` [F07]. *Resuelve* convertir texto libre en un `LocalidadModel` o un `EncuestaModel`. *No es* validación: el tipo garantiza la forma, no la semántica. En E1 §[3] el JSON es válido y aun así `Habitantes = 0` viola `LocalidadRules`.

**Normalización contra catálogo** **[criterio propio]**. Es el paso del adaptador que traduce lo que propuso el modelo («colectivo urbano») a una clave de `Catalogos` (`colectivo`) o lo rechaza. *Resuelve* los huecos H3–H5. *No es* tarea del modelo (no se le pide «elegí bien» y se confía). Tampoco es tarea del dominio, que ya tiene sus reglas.

**RAG (Retrieval-Augmented Generation).** Hacer que el modelo use datos propios sin reentrenarlo: se trocean los datos, se vectorizan, se guardan con metadatos para citar y, ante una pregunta, se recuperan los fragmentos más cercanos y se pasan en el prompt [F09]. *Resuelve* preguntas sobre texto propio que el modelo no conoce. *No es* la forma de consultar datos estructurados exactos («¿cuántas localidades hay?»): para eso hay herramientas o SQL (ver P2).

**Almacén vectorial (MEVD).** `Microsoft.Extensions.VectorData.Abstractions` define `VectorStore` y `VectorStoreCollection<TKey,TRecord>`. Los proveedores implementan esas clases y se pueden intercambiar sin cambiar la lógica [F10]. El proveedor en memoria se recomienda para prototipos y **no** para pruebas, por las diferencias con la base de producción [F10].

**Agente.** En Agent Framework, `AIAgent` usa un LLM para procesar entradas, llamar herramientas y servidores MCP y responder. Se construye desde un `IChatClient` con `AsAIAgent(instructions, name)` [F08][F11][E1 §[4]]. *Resuelve* tareas abiertas o conversacionales con uso autónomo de herramientas. *No es* lo indicado para procesos de pasos bien definidos: ahí va un workflow o, mejor, una función [F08].

**Aprobación humana (human-in-the-loop).** Se envuelve un `AIFunction` en `ApprovalRequiredAIFunction`. La corrida termina con un `ToolApprovalRequestContent` en lugar de ejecutar, y el llamador responde con `CreateResponse(true|false)` en la misma `AgentSession` [F12]. *Resuelve* el riesgo de agencia excesiva en acciones de alto impacto (OWASP LLM06:2025 recomienda aprobación humana y minimizar las extensiones [F13]). *No es* un control de autorización: no reemplaza saber quién es el usuario.

**Servidor MCP.** Un proceso que expone herramientas por el Model Context Protocol. En .NET se arma con `AddMcpServer().WithHttpTransport().WithTools<T>()` y `app.MapMcp()` [F14][F18]. Los métodos marcados con `[McpServerTool]` pueden recibir servicios del contenedor como parámetros [F18][E1 §[5]] (la página de getting-started de F14 no lo dice; lo dice la página conceptual de herramientas, F18). *Resuelve* que clientes externos (IDE, otros agentes) usen los casos de uso. *No es* un reemplazo de la API REST para la UI propia. Del lado cliente, `McpClient.ListToolsAsync` devuelve herramientas que **son** `AIFunction` y entran directo en `ChatOptions.Tools` [F14][E1 §[5]].

**Cliente falso (doble de `IChatClient`).** Una implementación de `IChatClient` con respuestas guionadas, incluidas llamadas a herramientas (`FunctionCallContent`). *Resuelve* probar de forma determinista el cableado (herramientas, reglas, aprobación, MCP) sin modelo. *No es* una prueba de la calidad del modelo: para eso están las corridas R-LLM contra Qwen (N5).

---

## 3. Estado actual verificado (2026-10-25)

Versiones obtenidas de `https://api.nuget.org/v3-flatcontainer/<id>/index.json` y de `registration5-gz-semver2` (fechas y deprecaciones) el 2026-10-25 [F15]. «Preview» indica la preview más reciente publicada **sólo** cuando no hay estable más nueva.

| Paquete | Estable | Preview | Fecha (última) | Estado | Rol en N6 |
|---|---|---|---|---|---|
| `Microsoft.Extensions.AI` / `.Abstractions` | **10.11.0** | — | 2026-10-14 | GA | `IChatClient`, herramientas, salida estructurada |
| `OllamaSharp` | **5.5.0** | — | 2026-09-30 | GA (comunidad) | proveedor contra el servidor Ollama del laboratorio |
| `Microsoft.Extensions.AI.Ollama` | — | 9.7.0-preview.1.25356.2 | 2025-07-08 | **DEPRECADO** → `OllamaSharp` (N2 [E2]) | no usar |
| `Microsoft.Extensions.VectorData.Abstractions` | **10.11.0** | — | 2026-10-14 | GA | almacén vectorial |
| `CommunityToolkit.VectorData.InMemory` | **1.0.1** | — | 2026-08-10 | GA | vectores de la demo (opción por defecto) |
| `CommunityToolkit.VectorData.SqliteVec` | — | **1.0.3-preview** | 2026-10-09 | preview; depende de `sqlite-vec` 0.1.7-alpha.2.1 y `SQLitePCLRaw` ≥ 3.0.3 | variante «vectores en SQLite» |
| `Microsoft.SemanticKernel.Connectors.InMemory` / `.SqliteVec` | — | 1.74.0-preview | 2026-03-20 | **DEPRECADOS (Legacy)**: renombrados a `CommunityToolkit.VectorData.*` | no usar |
| `Microsoft.Agents.AI` / `.Abstractions` / `.Workflows` | **1.26.0** | — | 2026-10-23 | GA | agente con aprobación |
| `Microsoft.Agents.AI.Hosting` | — | 1.26.0-preview.261023.1 | 2026-10-23 | preview | no se usa |
| `ModelContextProtocol` / `.AspNetCore` / `.Core` | **2.3.0** | — | 2026-10-20 | GA | servidor y cliente MCP |
| `Microsoft.Extensions.AI.Evaluation` / `.Quality` / `.Reporting` | **10.11.0** | — | 2026-10-14 | GA | evaluación (N5) |
| `Microsoft.Extensions.DataIngestion` | — | 10.11.0-preview.1.26513.7 | 2026-10-14 | preview | ingesta (opcional; corpus chico) |
| `Microsoft.EntityFrameworkCore.Sqlite` | **10.0.14** | 11.0.0-rc.3.26522.148 | 10.0.14: 2026-10-25 | GA (10) / RC (11) | persistencia; el caso base fija 10.0.11 [F01] |
| `Microsoft.Extensions.Caching.StackExchangeRedis` | **10.0.14** | 11.0.0-rc.3.26522.148 | — | GA | caché distribuida (N5, opcional) |

Mensaje literal de la deprecación (registro de nuget.org, catálogo del 2026-07-27): *«This package has been renamed from Microsoft.SemanticKernel.Connectors.InMemory to CommunityToolkit.VectorData.InMemory since this package has no dependency on Semantic Kernel and it is an implementation of Microsoft.Extensions.VectorData.Abstractions that can be used with any framework. The new package is v1 stable.»* [F15]. Learn ya usa el paquete nuevo en su ejemplo mínimo [F10]. Hay tutoriales que todavía citan `Microsoft.SemanticKernel.Connectors.InMemory`.

Documentación oficial por pieza: MEAI [F06][F07], vectores [F10], RAG [F09], Agent Framework [F08][F11][F12], MCP [F14][F16].

---

## 4. Snippets y evidencia

### 4.0 Evidencia ejecutada

- **[E1] Sonda de integración N6.** Proyecto `Microsoft.NET.Sdk.Web` net10.0 con EF Core SQLite 10.0.14, MEAI 10.11.0, OllamaSharp 5.5.0, InMemory 1.0.1, SqliteVec 1.0.3-preview, ModelContextProtocol.AspNetCore 2.3.0 y Microsoft.Agents.AI 1.26.0. Se compiló y corrió en `mcr.microsoft.com/dotnet/sdk:10.0` (SDK 10.0.403), con los intermedios fuera del repo y la caché NuGet en un volumen Docker. Comando: `docker run --rm -v <sonda>:/work -v <volumen-nuget>:/root/.nuget/packages -w /work mcr.microsoft.com/dotnet/sdk:10.0 dotnet run`. Fuente y salida completas en [`N6-Evidencia/`](N6-Evidencia/) (`sonda-Program.cs`, `sonda-N6Probe.csproj`, `sonda-salida.txt`). Salida relevante:

  ```text
  [1] EF Core SQLite: 2 localidades
  [1] SQLitePCLRaw.core 3.0.3.3048
  [1] SqliteVec top1 = pol-cp (LocalidadPolicy.RequisitoDelCodigoPostal)
  [1] EF Core sigue operativo tras sqlite-vec: 2 localidades
  [2] resultado de herramienta visto por el modelo: c1=INVALIDO: codigoPostal: El código postal debe tener 4 dígitos.
  [2] resultado de herramienta visto por el modelo: c2=Se agregó la localidad Goya.
  [2] localidades en base: 3
  [2] ApprovalRequiredAIFunction existe: True
  [3] propuesta tipada: LocalidadPropuesta { Nombre = Bella Vista, Provincia = Corrientes, CodigoPostal = 3432, Habitantes = 0 }
  [3] errores de dominio: habitantes: Ingrese una cantidad de habitantes mayor a cero.
  [4] agente AsistenteMovilidad: Hay 3 localidades.
  [5] herramientas MCP: listar_localidades
  [5] listar_localidades → ["[\"Corrientes (Corrientes)\",\"Resistencia (Chaco)\",\"Goya (Corrientes)\"]"]
  [5] McpClientTool es AIFunction: True
  ```

  Qué prueba: (1) EF Core 10 y SqliteVec conviven en el mismo proceso con SQLitePCLRaw 3.0.3. (2) La herramienta que envuelve el caso de uso **rechaza** el CP inválido que «propuso el modelo», y el resultado del rechazo vuelve al modelo. La «corrección» del turno siguiente está **guionada** en el cliente falso, no la decide ningún modelo. Además, la sonda usa un `LocalidadService` y unas `LocalidadRules` **simplificados** (devuelven `string`, sin `Result` ni chequeo de duplicados), no los del caso base. La verificación adversarial repitió §4.1 con el `LocalidadService`, el `Result` y las reglas **copiados del commit `8fb4c3a`** y obtuvo el mismo rechazo [E5]. (3) La salida tipada no implica validez. (4) MAF construye un agente sobre el mismo `IChatClient`. (5) Un servidor MCP HTTP expone un caso de uso que recibe servicios por DI, y un `McpClient` lo lista y lo invoca. La corrida muestra una sola advertencia de compilación, ASP0000, por el `BuildServiceProvider` de la sonda. Ojo: el `.csproj` de la sonda suprime `MEAI001;MEVD9000;MEVD9001;CS8618;MAAI001` con `NoWarn`, así que «sin advertencias» vale con esa supresión. La verificación adversarial compiló los snippets de §4.1–§4.6 **sin** `NoWarn` y dio `0 Error(s)`, `0 Warning(s)` [E5]. **Qué no prueba**: el comportamiento de Qwen. El modelo es un cliente falso guionado, porque no hay Ollama en `localhost` en esta máquina. Esas corridas quedan para la fase de demo (§8).
- **[E2] Reflexión sobre MEAI 10.11.0** ([`N6-Evidencia/reflexion-Program.cs`](N6-Evidencia/reflexion-Program.cs), salida en `reflexion-salida.txt`): `AddChatClient(IServiceCollection, IChatClient, ServiceLifetime lifetime=Singleton)`; `AIFunctionArguments` expone `Services` y `Context`; `FunctionInvokingChatClient` expone `MaximumIterationsPerRequest`, `MaximumConsecutiveErrorsPerRequest`, `IncludeDetailedErrors`, `AllowConcurrentInvocation`, `TerminateOnUnknownCalls`, `AdditionalTools`, `FunctionInvoker`; existen `ApprovalRequiredAIFunction`, `ToolApprovalRequestContent` y `ToolApprovalResponseContent`, sin `[Experimental]` en `ApprovalRequiredAIFunction`.
- **[E3] Dependencias (nuspec, nuget.org)**: EF Core Sqlite 10.0.11 → `SQLitePCLRaw.bundle_e_sqlite3` 2.1.12; 10.0.14 → 2.1.13; EF Core 11.0.0-rc.3 → 3.0.5; `CommunityToolkit.VectorData.SqliteVec` 1.0.3-preview → `SQLitePCLRaw.bundle_e_sqlite3` ≥ 3.0.3, `sqlite-vec` ≥ 0.1.7-alpha.2.1, `Microsoft.Extensions.VectorData.Abstractions` ≥ 10.8.2; `CommunityToolkit.VectorData.InMemory` 1.0.1 → MEVD ≥ 10.8.2, MEAI.Abstractions ≥ 10.8.3; `ModelContextProtocol` 2.3.0 → `ModelContextProtocol.Core` [2.3.0].
- **[E4] Lectura del caso base**: `git log -1` = `8fb4c3a 2026-09-18`. Archivos leídos: `Program.cs` de Web y ApiWeb, `Domain/*`, `Application/*`, `Infrastructure/Persistence/{SessionSeeder,EncuestaRepository}.cs` y `Controllers/EncuestasController.cs` de ApiWeb.

### 4.1 Caso de uso como herramienta, sin saltear reglas

Origen: tool calling de [F06], adaptado al dominio. Equivale a E1 §[2].

```csharp
// Infrastructure/AI/HerramientasDeLocalidad.cs — adaptador fino: llama al caso de uso, nunca al repositorio
public sealed class HerramientasDeLocalidad(LocalidadService service)
{
    [Description("Da de alta una localidad. Devuelve el resultado de la validación del dominio.")]
    public async Task<object> AgregarAsync(
        [Description("Nombre de la localidad")] string nombre,
        [Description("Una de: Buenos Aires, Chaco, Córdoba, Corrientes, Entre Ríos, Mendoza, Santa Fe")] string provincia,
        [Description("Código postal de 4 dígitos")] string codigoPostal,
        [Description("Cantidad de habitantes, entero ≥ 1")] int habitantes)
    {
        Result r = await service.SaveAsync(new LocalidadModel
            { Nombre = nombre, Provincia = provincia, CodigoPostal = codigoPostal, Habitantes = habitantes });
        return new { r.IsSuccess, r.Message, r.Errors };   // el modelo lee los errores y puede corregir
    }

    public IList<AITool> Crear() => [AIFunctionFactory.Create(AgregarAsync, "agregar_localidad")];
}

// En el scope de la petición (T1): las herramientas se arman con los servicios de ESTA sesión
IChatClient chat = innerClient.AsBuilder().UseFunctionInvocation().Build();
var options = new ChatOptions { Tools = herramientas.Crear() };
ChatResponse resp = await chat.GetResponseAsync(pedidoDelUsuario, options);
```

### 4.2 Extracción estructurada + normalización + reglas

Origen: `GetResponseAsync<T>` de [F07]. Normalización **[criterio propio]**. La parte tipada equivale a E1 §[3].

```csharp
public sealed record EncuestaPaso2Propuesta(string[] Medios, string Frecuencia);

ChatResponse<EncuestaPaso2Propuesta> r = await chat.GetResponseAsync<EncuestaPaso2Propuesta>(
    $"Extraé los medios de transporte y la frecuencia. Medios válidos: " +
    $"{string.Join(", ", Catalogos.Medios.Select(m => m.Clave))}. Frecuencias válidas: " +
    $"{string.Join(", ", Catalogos.Frecuencias.Select(f => f.Clave))}.\nTexto: {textoDelUsuario}");

// El modelo propone; el catálogo normaliza; la regla decide.
var desconocidos = r.Result.Medios.Where(m => !Catalogos.Medios.Any(c => c.Clave == m)).ToList();
var model = new EncuestaModel { Frecuencia = r.Result.Frecuencia };
foreach (var m in r.Result.Medios.Except(desconocidos)) model.AlternarMedio(m, elegido: true);
var errores = new Dictionary<string, string>(encuestaService.ValidarPaso(2, model));
if (desconocidos.Count > 0) errores["medios"] = $"Medios fuera del catálogo: {string.Join(", ", desconocidos)}";
```

### 4.3 Ayuda con RAG sobre los requisitos del dominio

Origen: ejemplo mínimo de [F10] con `CommunityToolkit.VectorData.InMemory`. Equivale a E1 §[1], que usa `SqliteVectorStore`.

```csharp
var store = new InMemoryVectorStore(new() { EmbeddingGenerator = embeddings }); // IEmbeddingGenerator de OllamaSharp (N2 §4.6)
var col = store.GetCollection<string, Fragmento>("ayuda");
await col.EnsureCollectionExistsAsync();
await col.UpsertAsync([
    new() { Id = "loc-cp",   Fuente = "LocalidadPolicy.RequisitoDelCodigoPostal", Texto = LocalidadPolicy.RequisitoDelCodigoPostal, Embedding = "Código postal: " + LocalidadPolicy.RequisitoDelCodigoPostal },
    new() { Id = "enc-edad", Fuente = "EncuestaPolicy.RequisitoDeLaEdad",        Texto = EncuestaPolicy.RequisitoDeLaEdad,        Embedding = "Edad: " + EncuestaPolicy.RequisitoDeLaEdad },
    // … los 12 requisitos de *Policy, generados desde el código: si cambia la regla, cambia el corpus
]);
await foreach (var hit in col.SearchAsync(pregunta, top: 3))
    contexto.AppendLine($"[{hit.Record.Fuente}] {hit.Record.Texto}");   // la Fuente habilita la cita

public sealed class Fragmento
{
    [VectorStoreKey] public string Id { get; set; } = "";
    [VectorStoreData] public string Fuente { get; set; } = "";
    [VectorStoreData] public string Texto { get; set; } = "";
    [VectorStoreVector(384)] public string Embedding { get; set; } = ""; // la dimensión la fija el modelo de embeddings (no verificado para el del laboratorio)
}
```

### 4.4 Baja con aprobación humana

Origen: [F12], adaptado al dominio.

```csharp
AIFunction baja = new ApprovalRequiredAIFunction(
    AIFunctionFactory.Create((int id) => localidadService.DeleteAsync(id), "eliminar_localidad",
        "Elimina una localidad por Id. Requiere aprobación de la persona."));

AIAgent agente = chatClient.AsAIAgent(instructions: "Asistente del ABM de localidades.", tools: [baja]);
AgentSession session = await agente.CreateSessionAsync();
AgentResponse resp = await agente.RunAsync("Borrá Resistencia", session);

var pedido = resp.Messages.SelectMany(m => m.Contents).OfType<ToolApprovalRequestContent>().FirstOrDefault();
if (pedido is not null)   // la UI muestra el pedido; la persona decide
    resp = await agente.RunAsync(new ChatMessage(ChatRole.User, [pedido.CreateResponse(aprobado)]), session);
```

`AsAIAgent(instructions:, name:)` sobre `IChatClient` está verificado en E1 §[4]. La sobrecarga con `tools:` sobre un `IChatClient` también está verificada: existe `ChatClientExtensions.AsAIAgent(IChatClient, string instructions, string name, string description, IList<AITool> tools, ILoggerFactory, IServiceProvider)` en Microsoft.Agents.AI 1.26.0, y este snippet compiló y corrió con un cliente falso: la corrida devolvió el `ToolApprovalRequestContent` y, con `CreateResponse(false)`, la base no cambió [E5]. [F12] la muestra sobre un cliente de Foundry (`AIProjectClient`).

### 4.5 Servidor MCP como adaptador de entrada

Origen: [F14][F16]; equivale a E1 §[5].

```csharp
// Program.cs
// En ModelContextProtocol.AspNetCore 2.3.0 el modo sin sesión ya es el valor por defecto
// (SessionMode = Stateless, Stateless = true; E5). La doc del SDK lo escribe así [F18b]:
builder.Services.AddMcpServer()
    .WithHttpTransport(o => o.SessionMode = HttpServerSessionMode.Stateless)   // using ModelContextProtocol.AspNetCore;
    .WithTools<LocalidadMcpTools>();
app.MapMcp("/mcp");

// Mcp/LocalidadMcpTools.cs — los servicios llegan por DI como parámetros del método
[McpServerToolType]
public sealed class LocalidadMcpTools
{
    [McpServerTool(Name = "listar_localidades"), Description("Lista las localidades cargadas")]
    public static Task<IReadOnlyList<Localidad>> Listar(LocalidadService service, CancellationToken ct)
        => service.GetAllAsync(ct);
}
```

Cuidado con la sesión: el caso base aísla por `X-Sesion-Id` con un middleware [F05 §5]. El middleware se registra para todas las rutas (`app.UseMiddleware<SessionHeaderMiddleware>()`): si el cliente MCP **no** manda el encabezado, cada petición recibe una sesión nueva, sembrada con los datos iniciales [F02, `Sessions/SessionHeaderMiddleware.cs`]. Ese `X-Sesion-Id` no tiene nada que ver con el `Mcp-Session-Id` del protocolo [F18b]. La configuración HTTP de Visual Studio (`.mcp.json`) trae un campo `headers` [F16]. **No verificado**: si VS Code u otros clientes MCP genéricos mandan encabezados propios. Propuesta **[criterio propio]**: en la demo, el servidor MCP usa una sesión fija de demostración y se declara.

### 4.6 Prueba con cliente falso

Origen: el contrato `IChatClient` [F06]. Implementación en `N6-Evidencia/sonda-Program.cs` (`GuionChatClient`). Patrón:

```csharp
var fake = new GuionChatClient(new FunctionCallContent("c1", "agregar_localidad",
    new Dictionary<string, object?> { ["nombre"] = "Goya", ["provincia"] = "Corrientes", ["codigoPostal"] = "34", ["habitantes"] = 89959 }));
IChatClient chat = fake.AsBuilder().UseFunctionInvocation().Build();
await chat.GetResponseAsync("…", new ChatOptions { Tools = herramientas.Crear() });

Assert.That(fake.ResultadosVistos.Single(), Does.Contain("codigoPostal"));          // el dominio rechazó
Assert.That(await localidadService.GetAllAsync(), Has.Count.EqualTo(2));             // y no se escribió nada
```

---

## 5. Preguntas guía con respuestas

**P1. ¿Qué aporta una capa de IA a una app de ABM y encuesta tan estructurada como Movilidad Urbana?**
Aporta en la **entrada** y en la **consulta**, no en las reglas. En la entrada, convierte texto libre en modelos tipados (C2, C3) que después pasan por las mismas reglas que la UI. En la consulta, permite preguntas en lenguaje natural respondidas con datos exactos que vienen de casos de uso (C1). No aporta nada a la validación ni a la persistencia: esas siguen siendo `*Rules` y EF Core. Si la app sólo tuviera formularios y la gente estuviera cómoda con ellos, la capa de IA sería costo sin beneficio. MAF lo dice así: «If you can write a function to handle the task, do that instead of using an AI agent» [F08].

**P2. ¿Uso RAG para que el asistente responda «cuántas localidades hay en Corrientes»?**
No. Es un dato estructurado y exacto, y lo devuelve `LocalidadService.GetAllAsync` filtrado por provincia. RAG recupera fragmentos **parecidos** por similitud de embeddings [F09][F10]: puede traer las localidades de Chaco porque «se parecen», y no cuenta. La regla práctica **[criterio propio]**: si la pregunta tiene una respuesta exacta que una consulta puede calcular, va por herramienta. Si la respuesta está en texto propio que el modelo no conoce, va por RAG.

**P3. Entonces, ¿para qué sirve RAG en este caso?**
Para la ayuda (C4): «¿qué tengo que poner en el código postal?» se responde con `LocalidadPolicy.RequisitoDelCodigoPostal`, citando la fuente. Con 12 enunciados, el corpus cabe entero en el prompt y RAG es, sobre todo, didáctico. La guía tiene que decirlo: el umbral en el que RAG empieza a convenir es cuando el corpus no entra en la ventana de contexto o cuando el costo en tokens de mandarlo entero es alto. Ese criterio es **propio**, armado sobre dos hechos documentados: los modelos tienen una ventana de contexto con límite y se cobra por token [F17], y RAG ayuda a «overcome LLM token limits» [F10]. Ese umbral **no se midió** en este caso (§8). Generar el corpus **desde el código** de `*Policy` tiene una ventaja: si cambia una regla, cambia la ayuda.

**P4. El modelo devolvió un JSON perfecto. ¿Lo guardo?**
No sin validar. La salida estructurada garantiza la forma, no la verdad. En E1 §[3] el JSON es válido y `Habitantes = 0` viola la regla. En este dominio hay un riesgo extra: las reglas de provincia, localidad, frecuencia y motivo sólo exigen «no vacío» (H1, H3, H5) y los medios desconocidos se descartan sin aviso (H4) [F03]. El orden correcto es: el modelo propone, el adaptador normaliza contra `Catalogos`, el caso de uso valida y decide. Si falla, los errores por campo vuelven al modelo o a la persona.

**P5. ¿La herramienta llama al servicio o al repositorio?**
Al servicio de Application, siempre. El repositorio no valida duplicados ni reglas: eso lo hace `LocalidadService.SaveAsync` [F02]. Una herramienta sobre el repositorio sería una puerta trasera, y además replicaría la excepción que ya tiene `LocalidadesController` [F04 §3.2]. Corolario **[criterio propio]**: si una herramienta necesita algo que el servicio no expone (p. ej. resultados agregados de la encuesta), se agrega el caso de uso, no un atajo.

**P6. ¿Cuándo pido aprobación humana y cuándo no?**
Para lo que escribe con impacto y no se deshace: la baja de una localidad (`DeleteAsync`). OWASP LLM06:2025 recomienda limitar las extensiones al mínimo necesario y exigir aprobación humana para acciones de alto impacto [F13]. Las lecturas no lo necesitan. El alta es intermedia: es reversible y está validada, así que puede ir sin aprobación en la demo **[criterio propio]**. La aprobación no reemplaza la autorización. En el caso base, `X-Sesion-Id` no autentica: quien conoce el id ve los datos [F05 §5].

**P7. ¿Necesito un agente o alcanza con `UseFunctionInvocation`?**
Para C1 y C2 alcanza con un `IChatClient` con herramientas: una pregunta, una o dos llamadas, una respuesta [F06]. El agente de MAF suma sesión, middleware de agente y aprobación integrada [F08][F12], y se justifica en C5. Para la encuesta en tres pasos (C8), lo natural es el código que ya existe: es un proceso de pasos fijos. La tabla de MAF indica un workflow cuando «the process has well-defined steps», cuando se necesita control explícito del orden de ejecución o cuando hay que coordinar varios agentes o funciones. Por el primer criterio, la encuesta podría ser un workflow. Lo que la deja afuera es la frase siguiente de la misma página: «If you can write a function to handle the task, do that instead» [F08].

**P8. ¿Expongo la app por MCP o por la API REST?**
Según quién consuma. La API REST es para clientes que el equipo programa (la web, la app). MCP es para que **otros agentes** descubran y usen las capacidades sin código de integración. En E1 §[5], las herramientas del cliente MCP **son** `AIFunction` y entran directo en `ChatOptions.Tools`. Cada herramienta expuesta es superficie de agencia (N5), así que por MCP se exponen sólo lecturas en la demo **[criterio propio]**.

**P9. ¿Qué cambia si mañana el modelo no es Qwen local sino uno en la nube?**
En el código, sólo la composición (`AddChatClient` con otro proveedor; N2 §4.2). En el análisis, mucho: los datos de la encuesta (nombre, edad, localidad) salen de la máquina (T5). Por eso la demo usa modelo local por defecto y herramientas que devuelven agregados.

---

## 6. Criterios de calidad y antipatrones

### Criterios de calidad

| # | Criterio | Cómo se verifica | Fuente |
|---|---|---|---|
| Q1 | `Domain/` sin dependencias de IA | `grep` de `Microsoft.Extensions.AI` en `Domain/` vacío; idealmente prueba de arquitectura | [F04 §3.1] (el caso base no tiene pruebas de arquitectura) |
| Q2 | Toda escritura pasa por un caso de uso | Las herramientas reciben servicios de Application, nunca `I*Repository` | [F02], §4.1 |
| Q3 | Normalización contra `Catalogos` antes de validar | Prueba con cliente falso que propone `"avion"` y espera error, no lista vacía | [F03 H4] |
| Q4 | Herramientas armadas por scope de petición | Prueba con dos sesiones concurrentes: cada una ve sólo sus localidades | [E2], T1 |
| Q5 | Acción destructiva con `ApprovalRequiredAIFunction` | Prueba: sin respuesta de aprobación, la base no cambia | [F12] |
| Q6 | Pruebas deterministas con cliente falso + corridas R-LLM separadas | Suite de cableado sin red; corridas contra Qwen con modelo, digest, parámetros, entrada, salida, fecha y tasa | BIT-16-00 R-LLM |
| Q7 | Versiones alineadas y fijadas | `Directory.Packages.props`; `dotnet list package --include-transitive` sin MEAI/MEVD mezcladas | [E1], T4 |
| Q8 | Endpoint por `OLLAMA_ENDPOINT` con valor por defecto `http://localhost:11434` | Revisión de configuración; nada de la LAN en el repo | BIT-16-00 R-PRIV |
| Q9 | Citas en las respuestas de ayuda | Cada fragmento lleva `Fuente`; la respuesta la muestra | [F09] (metadatos para citas) |
| Q10 | Límite de iteraciones de herramientas | `FunctionInvokingChatClient.MaximumIterationsPerRequest` / `MaximumConsecutiveErrorsPerRequest` configurados | [E2] |

### Antipatrones

| Antipatrón | Por qué falla en este caso | Fuente |
|---|---|---|
| RAG sobre la tabla de localidades | Recupera por parecido, no cuenta ni filtra exacto | [F09], P2 |
| Herramienta sobre el repositorio | Saltea duplicados y reglas | [F02] |
| Confiar en `GetResponseAsync<T>` como validación | Forma ≠ validez (E1 §[3]) | [F07] |
| Pedirle al modelo «usá sólo valores del catálogo» y no normalizar | H3–H5 dejan pasar lo que el modelo invente | [F03] |
| Exponer `RegistrarAsync` como herramienta | No valida y usa `!.Value` (H6) | [F03] |
| `AddChatClient` singleton con herramientas que capturan servicios scoped | Mezcla sesiones o falla al resolver | [E2], T1 |
| Agente o workflow para la encuesta de 3 pasos | Complejidad sin beneficio: ya es código determinista | [F08] |
| Herramienta que devuelve filas con nombre y edad | Expone datos personales al modelo y a la conversación | T5, [F13] |
| Usar `Microsoft.SemanticKernel.Connectors.InMemory` o `Microsoft.Extensions.AI.Ollama` | Deprecados | [F15] |
| Probar el InMemory store y asumir que vale para producción | Learn desaconseja usarlo en pruebas | [F10] |

---

## 7. Tabla de fuentes

| Id | Fuente | Qué respalda | Consultado |
|---|---|---|---|
| F01 | ia-db Lab-E2E.WebBlazor v3.1: `/LAB/Lab-E2E.WebBlazor/Lab-E2E.WebBlazor.Documentacion/ia-db/README.md` e `indexes/00_MASTER-INDEX.md` (repo fuente público https://github.com/hdcm-dev/Lab-E2E.WebBlazor, commit `8fb4c3a`) | Stack, versiones (EF Core 10.0.11), aplicaciones independientes | 2026-10-25 |
| F02 | Código fuente `src/MovilidadUrbana.ApiWeb/` (Domain, Application, Infrastructure, Controllers) y `src/MovilidadUrbana.Web/Program.cs`, commit `8fb4c3a` | Entidades, catálogos, servicios, repositorios, ausencia de consulta de resultados | 2026-10-25 |
| F03 | ia-db `indexes/02_Dominio-Y-Reglas.md` | Reglas, políticas, mensajes, huecos H1–H7 | 2026-10-25 |
| F04 | ia-db `indexes/01_Arquitectura.md` | Capas, regla de dependencias, registro DI (scoped), excepción del controller | 2026-10-25 |
| F05 | ia-db `indexes/12_Api-REST.md` | Rutas, `X-Sesion-Id`, validación de los tres pasos en la API | 2026-10-25 |
| F06 | https://learn.microsoft.com/en-us/dotnet/ai/ichatclient (vía N2 F2) | `IChatClient`, tools, `UseFunctionInvocation`, DI | 2026-10-25 |
| F07 | https://learn.microsoft.com/en-us/dotnet/ai/quickstarts/structured-output (vía N2 F5) | `GetResponseAsync<T>`, `Result` | 2026-10-25 |
| F08 | https://learn.microsoft.com/en-us/agent-framework/overview/ (ms.date 2026-07-29) | Agente vs workflow; «If you can write a function…»; MAF sucesor de SK y AutoGen | 2026-10-25 |
| F09 | https://learn.microsoft.com/en-us/dotnet/ai/conceptual/rag (ms.date 2026-09-14) | Definición y proceso de RAG, metadatos para citas | 2026-10-25 |
| F10 | https://learn.microsoft.com/en-us/dotnet/ai/vector-stores/overview (ms.date 2026-02-28, act. 2026-07-23) | MEVD, `InMemoryVectorStore` con `EmbeddingGenerator`, atributos, recomendación de InMemory sólo para prototipos | 2026-10-25 |
| F11 | https://learn.microsoft.com/en-us/agent-framework/integrations/by-component/model-providers/ollama (ms.date 2026-10-15) | `OllamaApiClient(...).AsAIAgent(...)`; variables `OLLAMA_ENDPOINT` y `OLLAMA_MODEL_NAME` en la pestaña C# (`OLLAMA_MODEL` es de la pestaña Python). La nota «Not all models support function calling» está **sólo en la pestaña Python** | 2026-10-25 |
| F12 | https://learn.microsoft.com/en-us/agent-framework/agents/tools/tool-approval (ms.date 2026-10-15) | `ApprovalRequiredAIFunction`, `ToolApprovalRequestContent`, `CreateResponse`, `AgentSession` | 2026-10-25 |
| F13 | https://genai.owasp.org/llmrisk/llm062025-excessive-agency/ | LLM06:2025 Excessive Agency: minimizar extensiones, aprobación humana | 2026-10-25 |
| F14 | https://csharp.sdk.modelcontextprotocol.io/v2/concepts/getting-started.html (la v2 es la versión por defecto del sitio y la que corresponde al paquete 2.3.0; la v1 sigue publicada) y https://github.com/modelcontextprotocol/csharp-sdk | `AddMcpServer`, `WithHttpTransport`, `MapMcp`, `[McpServerToolType]`, `McpClient`, `ListToolsAsync` con `IChatClient`; paquetes Core/ModelContextProtocol/AspNetCore. El getting-started usa `WithToolsFromAssembly()`, no `WithTools<T>()`, y no menciona servicios por DI como parámetros (ver F18) | 2026-10-25 |
| F18 | https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/concepts/tools/tools.md | `WithTools<MyTools>()`; «methods can accept special parameter types that are resolved automatically: … and any service registered through dependency injection» | 2026-10-25 |
| F18b | https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/concepts/stateless/stateless.md | `options.SessionMode = HttpServerSessionMode.Stateless`, el modo sin sesión como valor por defecto y `Mcp-Session-Id` | 2026-10-25 |
| F19 | https://learn.microsoft.com/en-us/dotnet/api/system.string.gethashcode (Remarks) | «two subsequent runs of the same program may return different hash codes» | 2026-10-25 |
| F15 | https://api.nuget.org/v3-flatcontainer/{id}/index.json y https://api.nuget.org/v3/registration5-gz-semver2/{id}/index.json | Versiones, fechas, deprecaciones y renombres de §3 | 2026-10-25 |
| F16 | https://learn.microsoft.com/en-us/dotnet/ai/quickstarts/build-mcp-server (ms.date 2026-03-04) | Plantilla `mcpserver` (preview), transportes local/remote | 2026-10-25 |
| F17 | https://learn.microsoft.com/en-us/dotnet/ai/conceptual/understanding-tokens (ms.date 2026-03-04) | Ventana de contexto, límites y precio por token | 2026-10-25 |
| E1–E4 | §4.0 y `N6-Evidencia/` | Sonda de integración, reflexión, dependencias, lectura del caso | 2026-10-25 |
| E5 | `N6-Evidencia/verif-adv-*` (verificación adversarial) | Los snippets de §4.1–§4.6 compilados sin `NoWarn` contra el dominio copiado de `8fb4c3a`, más la reflexión sobre `HttpServerTransportOptions` y `AsAIAgent` | 2026-10-25 |

---

## 8. Abierto / no verificado

1. **Comportamiento real con Qwen**: no se corrió contra el servidor Ollama del laboratorio. En esta máquina no hay Ollama en `localhost` y el endpoint del laboratorio no se escribe acá. Pendiente para la fase de demo: tasa de llamadas correctas a herramientas, tasa de JSON válido en `GetResponseAsync<T>`, tasa de valores fuera de catálogo, con registro R-LLM (modelo, digest, parámetros, entrada, salida, fecha). [F11] advierte que no todos los modelos hacen function calling (la nota está en la pestaña Python de la página).
2. **Modelo de embeddings del laboratorio** y su dimensión (el 384 de §4.3 es de ejemplo). **No verificado**.
3. **T1**: qué `IServiceProvider` llega a `AIFunctionArguments.Services` cuando el `IChatClient` se registró singleton. La reflexión confirma que la propiedad existe, no su contenido en tiempo de ejecución.
4. ~~**`AsAIAgent(..., tools: [...])` sobre `IChatClient`**~~ **Resuelto en la verificación adversarial**: la sobrecarga existe en 1.26.0, y el snippet de §4.4 compiló y corrió con un cliente falso [E5].
5. **SqliteVec + EF Core 10 en producción**: E1 muestra que conviven con SQLitePCLRaw 3.0.3 en linux-x64, pero no hay declaración oficial de soporte de EF Core 10 sobre SQLitePCLRaw 3.x, y `sqlite-vec` está en alpha. No se probaron otros RID (Windows, ARM).
6. **Propagación de `X-Sesion-Id` por clientes MCP genéricos**: no verificado para VS Code. La configuración HTTP de Visual Studio trae `headers` [F16]. Sin encabezado, el middleware del caso base le da a cada petición una sesión nueva [F02].
7. **Umbral corpus/ventana a partir del cual RAG conviene** frente a mandar todo el texto: no medido en este caso.
8. **Fuentes de N0**: los IDs de escenario, contexto y actor (BIT-16-03) todavía no existen. §1.5 los referencia de forma genérica.
9. **`Microsoft.Agents.AI.Hosting`** sigue en preview, mientras el resto de MAF está en 1.26.0 GA. No se investigó qué agrega.
10. ~~Las páginas de MEAI (F06, F07) se tomaron del relevamiento de N2 y no se volvieron a leer en este núcleo.~~ **Resuelto en la verificación adversarial**: F06 (ms.date 2026-03-13) y F07 (2026-03-04) se volvieron a abrir y confirman lo citado. Versiones de §3 vueltas a consultar en el flatcontainer el 2026-10-26: sin cambios.

---

## Anexo A. Diseño propuesto de la demo

**Propuesta para la mesa; criterio propio salvo donde se cita.**

Ruta: `Demos/MovilidadUrbana.Asistente/`. Es una solución autocontenida que **reimplementa** el dominio mínimo (copia de `Domain/` y `Application/` del caso base con procedencia `8fb4c3a` en cada archivo, DC-05). No referencia Lab-E2E.WebBlazor.

```text
Demos/MovilidadUrbana.Asistente/
├── MovilidadUrbana.Asistente.slnx
├── Directory.Packages.props            versiones fijadas (§3)
├── .gitignore                          bin/ obj/ datos/ *.db (DC-08)
├── README.md                           cómo correr, OLLAMA_ENDPOINT, OLLAMA_MODEL, qué es copia y qué es nuevo
├── src/MovilidadUrbana.Asistente/      ASP.NET Core net10.0 (API + página de chat Blazor opcional)
│   ├── Domain/                         copia: Catalogos, Entities, Rules (+ endurecimiento declarado de T2)
│   ├── Application/
│   │   ├── Localidades/ Encuestas/     copia de servicios, modelos y políticas
│   │   ├── Encuestas/ResultadosDeEncuestaService.cs   NUEVO: agregados por medio, motivo y localidad
│   │   └── Abstractions/               repos + puertos IA: IAsistenteDeMovilidad, IExtractorDeLocalidad, IExtractorDeEncuesta, IAyuda
│   ├── Infrastructure/
│   │   ├── Persistence/                EF Core SQLite (copia)
│   │   └── AI/                         AddAI(config): OllamaSharp, pipeline (FunctionInvocation, OTel, Logging),
│   │                                   herramientas, normalizador de catálogo, almacén vectorial, ingesta de *Policy
│   ├── Endpoints/                      /api/v1/localidades (copia mínima), /api/v1/asistente (streaming),
│   │                                   /api/v1/localidades/desde-texto, /api/v1/encuestas/pasos/{n}/desde-texto, /api/v1/ayuda
│   ├── Mcp/                            LocalidadMcpTools, EncuestaMcpTools (sólo lecturas)
│   └── Program.cs                      compone: AddInfrastructure, AddApplication, AddAI, MapMcp("/mcp")
└── tests/MovilidadUrbana.Asistente.Tests/   NUnit (como el caso base)
    ├── Cableado/                       cliente falso: herramientas, normalización, aprobación, sesiones, MCP en proceso
    └── ConModelo/                      [Category("LLM")] contra OLLAMA_ENDPOINT; se saltean si no responde; registran R-LLM
```

Recorrido de la demo, un escenario por capacidad:

| # | Escenario | Capacidad | Qué debe mostrar | Prueba de cableado (determinista) |
|---|---|---|---|---|
| D1 | «Agregá Goya, Corrientes, CP 34, 89959 habitantes» | C2 + 4.1 | El dominio rechaza el CP; el modelo corrige o la persona ve el error | E1 §[2] |
| D2 | «En Bella Vista no sé cuántos viven» | C2 | Extracción tipada que no pasa las reglas; la UI pide el dato | E1 §[3] |
| D3 | «Voy en bondi y a veces en bici, casi todos los días» | C3 + 4.2 | Normalización a `colectivo`, `bicicleta`, `diaria`; un medio inventado se rechaza en lugar de descartarse | Q3 |
| D4 | «¿Qué medio usa más la gente?» | C1 | Respuesta desde `ResultadosDeEncuestaService` (agregados, sin nombres) | Q2, T5 |
| D5 | «¿Cuántos dígitos lleva el código postal?» | C4 + 4.3 | Respuesta con cita `[LocalidadPolicy.RequisitoDelCodigoPostal]` | top-1 esperado con un generador de embeddings falso (E1 §[1]). Ojo: el `HashEmbeddingGenerator` de E1 usa `string.GetHashCode()`, que **no** es estable entre corridas [F19]. Es consistente dentro de un proceso, pero para una prueba reproducible en CI hace falta un hash estable (p. ej. FNV o SHA-256) |
| D6 | «Borrá Resistencia» | C5 + 4.4 | Solicitud de aprobación; sin aprobación no se borra | Q5 |
| D7 | Cliente MCP lista y llama `listar_localidades` | C6 + 4.5 | Otro agente usa la app sin código de integración | E1 §[5] |

Decisiones para la mesa: (a) página Blazor de chat sí o no (más fiel a MovilidadUrbana.Web, más costo); (b) vectores en InMemory (GA) o en SqliteVec (preview, T3); (c) endurecer reglas en la copia (T2) o sólo normalizar en el adaptador; (d) agregar `Comentario` a la encuesta para habilitar C7 o dejar C7 sólo en Examples/.

## Anexo B. Diseño propuesto de los ejemplos

Cada uno es una consola net10.0 independiente en `Examples/NN-Nombre/`, con un concepto por ejemplo, temática de movilidad urbana, `OLLAMA_ENDPOINT` (por defecto `http://localhost:11434`) y `OLLAMA_MODEL`. Todos compilan sin modelo y tienen un modo `--fake` que usa un cliente falso, para que la CI compile y corra sin red **[criterio propio]**.

| # | Carpeta | Concepto | Paquetes | Núcleo | Fuente del patrón |
|---|---|---|---|---|---|
| 01 | `01-Chat-Basico` | `IChatClient` con OllamaSharp, historial | MEAI 10.11.0, OllamaSharp 5.5.0 | N2 | N2 §4.1 |
| 02 | `02-Streaming` | `GetStreamingResponseAsync`, `ChatResponseUpdate` | ídem | N2 | N2 §4.1 |
| 03 | `03-Salida-Estructurada` | `GetResponseAsync<LocalidadPropuesta>` + validación por reglas | ídem | N2, N6 | [F07], §4.2 |
| 04 | `04-Embeddings-Y-Busqueda` | `IEmbeddingGenerator` + similitud coseno a mano sobre los requisitos | ídem | N3 | N2 §4.6 |
| 05 | `05-RAG-En-Memoria` | `InMemoryVectorStore` + respuesta con citas | + MEVD 10.11.0, InMemory 1.0.1 | N3 | [F10], §4.3 |
| 06 | `06-Tool-Calling` | caso de uso como herramienta; el dominio rechaza; el modelo corrige | MEAI | N4, N6 | [F06], §4.1 |
| 07 | `07-Agente-Con-Aprobacion` | `AsAIAgent` + `ApprovalRequiredAIFunction` | + Microsoft.Agents.AI 1.26.0 | N4, N5 | [F11][F12], §4.4 |
| 08 | `08-Servidor-Y-Cliente-MCP` | servidor HTTP + `McpClient` + herramientas MCP en `IChatClient` | ModelContextProtocol.AspNetCore 2.3.0 | N4 | [F14], §4.5 |
| 09 | `09-Pruebas-Con-Cliente-Falso` | NUnit: cableado determinista frente a corrida R-LLM | NUnit 4.x, MEAI | N5 | §4.6 |
| (opc.) | `10-Workflow` | MAF Workflows como **contraejemplo** de la encuesta (C8) | Microsoft.Agents.AI.Workflows 1.26.0 | N4 | N4 §G3 |
| (opc.) | `11-Clasificacion-De-Comentarios` | C7 con comentarios de ejemplo escritos para el ejemplo (rotulados) | MEAI | N2 | [F07] |

La lista tiene 9 ejemplos más 2 opcionales. Si la mesa quiere 8, se fusionan 01 y 02.

---

## Revisión de la mesa, ciclo 1 (2026-10-26)

- **`LocalidadPropuesta.Habitantes`** (H-004): la sonda (`N6-Evidencia/sonda-Program.cs:94`) lo declara `int`, y eso obliga al modelo a inventar el dato cuando el pedido no lo trae. En el caso base, `LocalidadModel.Habitantes` es `int?` y `LocalidadRules.HabitantesValidos(int?)` rechaza `null` (`8fb4c3a`). Corrección: `int?` en la propuesta; la ausencia la detectan las reglas. El `Habitantes = 0` del guion de §4.0 era de un cliente falso y no describe la conducta del modelo. (Re-votado en el ciclo 2, RV-06: el defecto nace en esta sonda y no en el caso base; severidad S3. La garantía contra la invención no la da el `int?`: la da el código, BIT-16-04 §A.4, punto 1.)
- **`listar_localidades`** (H-011): la ejecución de E1 §[5] devuelve nombres sin id, y `eliminar_localidad` pide un id, así que «Borrá Resistencia» no se puede encadenar. Corrección: la lectura devuelve id, nombre y provincia (`LocalidadDto` ya los tiene). La selección entre varias herramientas sobre Qwen no se midió (sólo una herramienta, Sondeo §3): queda la sonda DEP-10 del plan.
- **P6 (alta sin aprobación)**: la mesa resolvió aprobación para toda escritura y ninguna escritura con contexto recuperado (BIT-16-02 §5; H-012). El criterio propio de P6 queda como alternativa descartada.
- **Sesión en la web**: el aislamiento por circuito es el del caso base (`SessionMiddleware` + `Routes.SessionId`), no `SessionHeaderMiddleware` (H-008).

## Verificación adversarial

Se hizo el 2026-10-25, de forma independiente al investigador. Se contrastó cada afirmación con nuget.org (flatcontainer, registration5-gz-semver2 y nuspec), con las páginas de Learn y del SDK MCP abiertas de nuevo, con el código del caso base en `8fb4c3a` y con una sonda propia [E5]. E5 compila los snippets de §4.1–§4.6 **sin** `NoWarn` contra `Domain/` y `Application/` copiados del caso base, en `mcr.microsoft.com/dotnet/sdk:10.0` (SDK 10.0.403), con los intermedios fuera del repo. Comando: `docker run --rm -v <sonda>:/work -v <volumen-nuget>:/root/.nuget/packages -w /work mcr.microsoft.com/dotnet/sdk:10.0 dotnet build` y después `dotnet run`. Resultado: `0 Error(s)`, `0 Warning(s)`. Archivos: `N6-Evidencia/verif-adv-*`.

| Afirmación | Veredicto | Evidencia |
|---|---|---|
| Versiones de §3: MEAI/Abstractions/MEVD/Evaluation 10.11.0 (2026-10-14), OllamaSharp 5.5.0 (2026-09-30), InMemory 1.0.1 (2026-08-10), SqliteVec 1.0.3-preview (2026-10-09), Microsoft.Agents.AI* 1.26.0 y Hosting 1.26.0-preview.261023.1 (2026-10-23), ModelContextProtocol* 2.3.0 (2026-10-20), DataIngestion 10.11.0-preview.1.26513.7, EF Core Sqlite y Caching.StackExchangeRedis 10.0.14 (2026-10-25) / 11.0.0-rc.3.26522.148 | confirmada | flatcontainer y registration5-gz-semver2, consultados el 2026-10-25 |
| `Microsoft.Extensions.AI.Ollama` deprecado → OllamaSharp; `Microsoft.SemanticKernel.Connectors.InMemory`/`.SqliteVec` 1.74.0-preview deprecados («Legacy») → `CommunityToolkit.VectorData.*` | confirmada | registro: `deprecation.reasons` = `Other` / `Legacy`, `alternatePackage` coincide |
| Mensaje literal de la deprecación, catálogo del 2026-07-27 | confirmada | `deprecation.message`; `@id` `catalog0/data/2026.07.27.09.48.18/…1.74.0-preview.json` |
| E3: EF Core Sqlite 10.0.11 → SQLitePCLRaw 2.1.12; 10.0.14 → 2.1.13; 11.0.0-rc.3 → 3.0.5; SqliteVec → SQLitePCLRaw 3.0.3, sqlite-vec 0.1.7-alpha.2.1, MEVD 10.8.2; InMemory → MEVD 10.8.2, MEAI.Abstractions 10.8.3; ModelContextProtocol 2.3.0 → Core [2.3.0] | confirmada | nuspec en `v3-flatcontainer/<id>/<ver>/<id>.nuspec` |
| T4: Microsoft.Agents.AI 1.26.0 arrastra MEVD.Abstractions 10.10.0 | confirmada | nuspec: MEVD.Abstractions 10.10.0; además MEAI 10.10.0 y MEAI.Abstractions 10.10.1 |
| Caso base: commit `8fb4c3a` del 2026-09-18, repo `hdcm-dev/Lab-E2E.WebBlazor` público, ia-db v3.1, EF Core 10.0.11 | confirmada | `git log -1`; API de GitHub (`private: false`); `00_MASTER-INDEX.md` línea 7 y línea 76 |
| §1.1: entidades, rangos (CP de 4 dígitos, edad 16–110, distancia 0–500, minutos 1–600), 6 medios, 3 frecuencias, 4 motivos, 7 provincias, 12 enunciados de `*Policy` (4 + 8), siembra Corrientes/Resistencia, `IEncuestaRepository` con sólo `AddAsync`/`CountAsync`, H1–H7 | confirmada | `Domain/*`, `Application/*`, `SessionSeeder.cs`, `02_Dominio-Y-Reglas.md` §8 |
| `Catalogos.Provincias` como «clave → etiqueta» | **corregida** | `Catalogos.cs`: `Provincias` es `IReadOnlyList<string>`; sólo Medios, Frecuencias y Motivos son `(Clave, Etiqueta)` |
| H4 (`["avion"]` pasa y se registra vacío) | confirmada | `ValidarPaso` caso 2 cuenta `Medios.Count`; `RegistrarAsync` filtra contra `Catalogos.Medios` |
| Excepción de `LocalidadesController` (lee del repositorio); registro Scoped; `X-Sesion-Id` no autentica; la API valida los tres pasos | confirmada | `01_Arquitectura.md` §3.2 y §4; `12_Api-REST.md` §3 y §5; código de los controllers |
| E1 «Restore y build con 0 Warning(s)» | **corregida** | el `.csproj` de la sonda suprime `MEAI001;MEVD9000;MEVD9001;CS8618;MAAI001` y la salida muestra ASP0000. E5 sin `NoWarn`: 0/0 |
| E1 (2): «el modelo corrige en el turno siguiente» | **corregida** | la corrección está guionada en `GuionChatClient`; el `LocalidadService` de la sonda es una reimplementación simplificada. E5 lo repite con el `LocalidadService` real y obtiene `{"isSuccess":false,…,"errors":{"codigoPostal":…}}` |
| E2: `AddChatClient(..., lifetime=Singleton)`, propiedades de `FunctionInvokingChatClient` y `AIFunctionArguments`, `ApprovalRequiredAIFunction` sin `[Experimental]` | confirmada | `reflexion-salida.txt`; E5: atributos de `ApprovalRequiredAIFunction` vacíos, y compila sin suprimir MEAI001 |
| §4.1 snippet (`AIFunctionFactory.Create(AgregarAsync, …)`, `Result` con `IsSuccess`/`Message`/`Errors`) | confirmada | E5 compila y corre contra `Result.cs`/`LocalidadService.cs` reales |
| §4.2 snippet (`GetResponseAsync<T>`, `ChatResponse<T>.Result`, `AlternarMedio`, `ValidarPaso` devuelve `IReadOnlyDictionary`) | confirmada | E5: `medios=Medios fuera del catálogo: avion`; F07 usa `response.Result` |
| §4.3 snippet (`InMemoryVectorStore(new() { EmbeddingGenerator })`, propiedad vector `string`, `SearchAsync(…, top:)`) | confirmada | E5; F10, ejemplo mínimo con `CommunityToolkit.VectorData.InMemory` |
| §4.4: `AsAIAgent(instructions:, tools:)` sobre `IChatClient` («no verificado») | **corregida → confirmada** | E5: `ChatClientExtensions.AsAIAgent(IChatClient, String instructions, String name, String description, IList tools, ILoggerFactory, IServiceProvider)`; corrida con `ToolApprovalRequestContent` → `CreateResponse(false)` y la base sin cambios |
| F12: `ApprovalRequiredAIFunction`, `ToolApprovalRequestContent`, `CreateResponse(true/false)`, `AgentSession`, `CreateSessionAsync`, ms.date 2026-10-15, ejemplo sobre Foundry | confirmada | F12 abierta de nuevo: usa `AIProjectClient(...).AsAIAgent(model:, instructions:, tools:)` |
| §4.5 `WithHttpTransport(o => o.Stateless = true)` | **corregida** | en 2.3.0 el modo sin sesión ya es el valor por defecto (`SessionMode = Stateless`, `Stateless = True` por reflexión), y la doc del SDK usa `options.SessionMode = HttpServerSessionMode.Stateless` [F18b]. El snippet cambiado compiló (E5) |
| §4.5: el middleware de `X-Sesion-Id` «sólo aplica si el cliente manda el encabezado» | **corregida** | `SessionHeaderMiddleware` corre siempre; sin encabezado, la petición recibe una sesión nueva |
| §2: `[McpServerTool]` recibe servicios por DI [F14] | **corregida (fuente)** | el getting-started de F14 no lo dice (usa `WithToolsFromAssembly`); lo dice `docs/concepts/tools/tools.md` [F18]. También E1 §[5] |
| `McpClient.ListToolsAsync` devuelve herramientas que son `AIFunction` | confirmada | E1 §[5] (`McpClientTool es AIFunction: True`); F14 pasa `ListToolsAsync` a un `IChatClient` |
| F08: «If you can write a function…», MAF sucesor de SK y AutoGen, definición de agente, ms.date 2026-07-29 | confirmada | F08 abierta de nuevo |
| P7: «MAF reserva los workflows para coordinar varios agentes o funciones» | **corregida** | la tabla de F08 da tres criterios, incluido «the process has well-defined steps»; lo que deja la encuesta afuera es «If you can write a function…» |
| F11: «aclara que no todos los modelos soportan function calling»; variable `OLLAMA_ENDPOINT` | **corregida (precisión)** | la nota está sólo en la pestaña Python; en C# las variables son `OLLAMA_ENDPOINT` y `OLLAMA_MODEL_NAME`. ms.date 2026-10-15 confirmada |
| F09: definición de RAG y metadatos para citas (ms.date 2026-09-14) | confirmada | F09: «store relevant metadata for citations or references» |
| F10: InMemory para prototipos, «Avoid using the InMemory provider for testing»; proveedores intercambiables (`VectorStore`, `VectorStoreCollection<TKey,TRecord>`); ms.date 2026-02-28, act. 2026-07-23 | confirmada | F10 abierta de nuevo |
| P3: umbral de RAG atribuido a F17 | **corregida (atribución)** | F17 sólo documenta la ventana de contexto y el precio por token; el umbral es criterio propio sobre F17 y F10 |
| F13 OWASP LLM06:2025: minimizar extensiones y aprobación humana para acciones de alto impacto | confirmada | estrategias #1 y #6 de la página |
| F16: plantilla `Microsoft.McpServer.ProjectTemplates` en preview, transporte local (stdio) y remoto (http), ms.date 2026-03-04 | confirmada | F16 abierta de nuevo |
| F06/F07 («no se volvieron a leer») | confirmada | F06 (ms.date 2026-03-13): `UseFunctionInvocation`, `ChatOptions.Tools`, `AddChatClient`. F07 (2026-03-04): `GetResponseAsync<T>` y `.Result` |
| D5: «generador determinista» en E1 §[1] | **corregida** | `HashEmbeddingGenerator` usa `string.GetHashCode()`, que no es estable entre corridas [F19] |
| T1: qué `IServiceProvider` llega a `AIFunctionArguments.Services` con un cliente singleton | no verificado | no se ejecutó; sigue abierto (§8.3) |
| T3: SqliteVec + EF Core 10 con SQLitePCLRaw 3.0.3 en producción y en otros RID | no verificado | E1 sólo cubre linux-x64; no hay declaración oficial |
| Comportamiento real con Qwen, dimensión del modelo de embeddings del laboratorio, envío de encabezados por VS Code | no verificado | sin modelo ni cliente en esta verificación |
| `CommunityToolkit.VectorData.SqliteVec` «preview» y «la demo puede arrancar con InMemory» | confirmada (estado) / criterio propio (decisión) | flatcontainer: no hay versión estable de SqliteVec |
| F14: URL del getting-started del SDK MCP en `/v1/` | **corregida** | el sitio redirige a `./v2/` (`"default":"v2"` en su selector de versiones) y el paquete es 2.3.0. La página v2 también usa `WithToolsFromAssembly`, `McpServerToolType`, `ListToolsAsync` y `McpClient.CreateAsync`, así que lo citado se sostiene |

**Segunda pasada (2026-10-26).** Volví a consultar de forma independiente el flatcontainer y `registration5-gz-semver2`: las versiones y fechas de §3 no cambiaron (MEAI 10.11.0 del 2026-10-14, OllamaSharp 5.5.0 del 2026-09-30, Microsoft.Agents.AI 1.26.0 del 2026-10-23, ModelContextProtocol 2.3.0 del 2026-10-20, SqliteVec 1.0.3-preview del 2026-10-09, InMemory 1.0.1 del 2026-08-10, EF Core Sqlite 10.0.14 del 2026-10-25, Hosting 1.26.0-preview.261023.1), y las dos deprecaciones siguen igual (`Microsoft.Extensions.AI.Ollama` → `OllamaSharp`, `reasons: Other`; `Microsoft.SemanticKernel.Connectors.InMemory` 1.74.0-preview → `CommunityToolkit.VectorData.InMemory`, catálogo `2026.07.27.09.48.18`). F06–F19 responden HTTP 200. Encontré estas citas literales en las páginas: «If you can write a function to handle the task, do that instead of using an AI agent.» y «well-defined steps» (F08), «Avoid using the InMemory provider for testing…» y «Overcome LLM token limits» (F10), «metadata for citations or references» (F09), `CreateResponse(true)` y `ToolApprovalRequestContent` (F12), «any service registered through dependency injection» y `WithTools<MyTools>` (F18), `SessionMode = HttpServerSessionMode.Stateless` (F18b), «two subsequent runs of the same program may return different hash codes» (F19), `OLLAMA_ENDPOINT` y `OLLAMA_MODEL_NAME` (F11), y «human-in-the-loop control to require a human to approve high-impact actions» (F13). El repo `hdcm-dev/Lab-E2E.WebBlazor` es público (`"private": false`). E5 escribe `HttpServerSessionMode` con su nombre completo, `ModelContextProtocol.AspNetCore.HttpServerSessionMode`, y eso confirma el `using` del comentario de §4.5. Lo único nuevo que corregí es la URL de F14.
