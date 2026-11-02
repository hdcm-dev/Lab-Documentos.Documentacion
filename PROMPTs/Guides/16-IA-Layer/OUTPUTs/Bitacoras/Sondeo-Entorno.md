# Sondeo del entorno de ejecución (evidencia E1)

> Fecha de las corridas: 2026-10-25/26. Lo que mide este informe es el **servidor Ollama de la LAN del laboratorio**. En los comandos de abajo aparece `$OLLAMA_ENDPOINT`. Su valor real no se escribe acá: en los ejemplos y en la demo, el valor por defecto es `http://localhost:11434` y se pisa con la variable de entorno `OLLAMA_ENDPOINT`.
>
> Trabajo intermedio en `{dir-de-trabajo}/sondeo/` (scripts `py/probe.py`, `py/nothink.py`, `py/json_nothink.py`, proyecto `dotnet/SondeoIChatClient`, logs `*.log`). La caché de NuGet está en el volumen Docker `<volumen-nuget>`, que las fases siguientes pueden reutilizar.

## 0. Condiciones de la medición (leer antes de las cifras)

- `GET /api/version` → `{"version":"0.32.0-rc0"}`. Es una **release candidate** de Ollama.
- `GET /api/ps` siempre mostró `size_vram: 0`: el modelo cargado corre **en CPU, sin GPU**. Hay un solo modelo residente a la vez, y `qwen3.5:4b` quedó cargado con `context_length: 65536`.
- El servidor es **compartido**. Mientras corría este sondeo, otros agentes de la misma corrida lo estaban usando (sobre todo con `qwen3.5:4b`), y cada cambio de modelo obliga a descargar uno y cargar otro. Por eso las latencias de abajo son **latencias bajo carga, no de banco exclusivo**. La dispersión es enorme: la misma consulta de tools con `qwen2.5:7b-instruct` tardó 68,8 s y un `GetResponseAsync` con el mismo modelo pasó los 600 s sin recibir el primer byte.
- Consecuencia práctica (criterio propio): en este servidor el cuello de botella es **la cola y el cambio de modelo**, no el tamaño del modelo. Conviene que los ejemplos y la demo usen **un solo modelo**, el que ya está residente, y timeouts largos (≥ 5 min).

## 1. Modelos disponibles y capacidades declaradas

Comandos:

```bash
curl -s $OLLAMA_ENDPOINT/api/tags
curl -s $OLLAMA_ENDPOINT/api/show -d '{"model":"<modelo>"}'   # capabilities + model_info.*.context_length
```

| Modelo | Parámetros / cuant. | Tamaño | `capabilities` (`/api/show`) | Contexto nativo |
|---|---|---|---|---|
| qwen2.5:7b-instruct | 7.6B Q4_K_M | 4,68 GB | completion, tools | 32768 |
| qwen3.5:4b | 4.7B Q4_K_M | 3,39 GB | completion, vision, tools, thinking | 262144 (cargado con 65536) |
| qwen2.5:14b-instruct | 14.8B Q4_K_M | 8,99 GB | completion, tools | 32768 |
| gemma4:e4b-it-qat | 7.5B Q4_0 | 6,15 GB | completion, vision, audio, tools, thinking | 131072 |
| gpt-oss:20b | 20.9B MXFP4 | 13,79 GB | completion, tools, thinking | 131072 |
| qwen3-coder:30b | 30.5B Q4_K_M | 18,56 GB | completion, tools | 262144 |
| qwen2.5vl:7b | 8.3B Q4_K_M | 5,97 GB | completion, vision | 128000 |
| qwen2.5-coder:7b / :14b / :3b-base | — | — | completion, tools, insert (7b) | 32768 |

**Ningún modelo declara la capacidad `embedding`.** En el servidor no hay ningún modelo dedicado a embeddings. `gemma4`, `gpt-oss` y `qwen3-coder` sólo se inspeccionaron con `/api/show`: no se midieron porque cargarlos le quitaba el servidor a los demás agentes.

## 2. Chat por `/v1/chat/completions`

Prompt: «Explicá en dos oraciones qué es un sistema RAG.», `temperature: 0`, `max_tokens: 200` (`py/probe.py chat`). La medición nativa se hizo por `/api/chat` con `num_predict: 200`, y su `eval_rate` sale de `eval_count / eval_duration`.

```text
qwen2.5:7b-instruct run1: 162.2s prompt=43 compl=83 ~0.5 tok/s(total) finish=stop reasoning=False | 'Un Sistema RAG (Retrieval-Augmented Generation) es una arquitectura ...'
qwen2.5:7b-instruct ERR timed out                      # segunda corrida, timeout de 300 s
   native: eval_count=83 eval_rate=0.9 tok/s prompt_eval=43 load=1.29s total=103.4s
qwen3.5:4b run1: 127.5s prompt=24 compl=200 ~1.6 tok/s(total) finish=length reasoning=True | ''
qwen3.5:4b run2: 134.7s prompt=24 compl=200 ~1.5 tok/s(total) finish=length reasoning=True | ''
   native: eval_count=200 eval_rate=4.1 tok/s prompt_eval=24 load=0.73s total=49.7s
```

**Hallazgo: `qwen3.5:4b` razona por defecto.** Con 200 tokens de presupuesto, gasta todo en `reasoning` y devuelve `content` vacío (`finish=length`). Al apagar el razonamiento (`py/nothink.py`):

```text
qwen3.5:4b native think=false 23.7s: eval=82 rate=3.8 tok/s thinking=False | 'Un sistema **RAG** (Retrieval-Augmented Generation) combina ...'
qwen3.5:4b v1 reasoning_effort=none 23.1s compl=82 finish=stop reasoning=False | 'Un sistema **RAG** (Retrieval-Augmented Generation) combina ...'
```

- Nativo: `"think": false` en `/api/chat` (documentado en https://docs.ollama.com/capabilities/thinking).
- Compatible OpenAI: `"reasoning_effort": "none"` en `/v1/chat/completions`. La documentación (https://docs.ollama.com/api/openai-compatibility) dice que «`reasoning_effort` and `reasoning.effort` control model thinking». Que el valor `none` funcione **se verificó en ejecución**, porque la página no lista los valores aceptados.

`qwen2.5:14b-instruct`: un `/api/chat` con `num_predict: 120` **no respondió en 900 s** (curl cortó con respuesta vacía), y la prueba de tools cortó a los 300 s. Bajo esta carga, **no es utilizable**.

## 3. Tool calling por `/v1/chat/completions`

Tool `contar_localidades(provincia: string)`. Pregunta: «¿Cuántas localidades hay registradas en Santa Fe? Usá la herramienta.». En la segunda vuelta se devuelve `{"provincia":"Santa Fe","cantidad":365}` como mensaje `role: tool` (`py/probe.py tools`).

```text
qwen2.5:7b-instruct: 68.8s finish=tool_calls tool_calls=[{"id": "call_hg9fx3zv", "index": 0, "type": "function", "function": {"name": "contar_localidades", "arguments": "{\"provincia\":\"Santa Fe\"}"}}] ok=True content=''
   round2 14.6s: 'En la provincia de Santa Fe, hay registradas 365 localidades.'
qwen3.5:4b: 199.6s finish=tool_calls tool_calls=[{"id": "call_d63qm4o5", "index": 0, "type": "function", "function": {"name": "contar_localidades", "arguments": "{\"provincia\":\"Santa Fe\"}"}}] ok=True content=''
   round2 22.1s: 'Según los datos registrados, en la provincia de **Santa Fe** hay **365 localidades**. ...'
qwen2.5:14b-instruct ERR timed out
```

Los dos modelos devuelven `tool_calls` bien formados, con `arguments` como JSON válido y `finish_reason: tool_calls`, y en la segunda vuelta integran el resultado. La documentación de Ollama aclara que `/v1/chat/completions` soporta `tools` **pero no `tool_choice`** (https://docs.ollama.com/api/openai-compatibility): no se le puede forzar el uso de la herramienta.

> **Rótulo R-06** (dominio ilustrativo del dossier; la guía usa Movilidad Urbana): las salidas de §4 y §11 son evidencia ejecutada con un texto de prueba de otro dominio; se dejan tal cual para no alterar la evidencia.

## 4. Salida estructurada

Esquema `{titulo: string, prioridad: enum[baja,media,alta], etiquetas: string[]}`, `additionalProperties: false`. Se probó con `response_format: {type: json_schema, json_schema: {..., strict: true}}` en `/v1` y con `format: <schema>` en `/api/chat` (`py/probe.py json`, `py/json_nothink.py`).

```text
qwen2.5:7b-instruct v1 json_schema 65.8s: OK {"titulo": "Reclamo ciudadano", "prioridad": "alta", "etiquetas": ["seguridad vial", "infraestructura", ...
qwen2.5:7b-instruct native format 25.2s: OK {"titulo": "Reclamo ciudadano", "prioridad": "alta", ...
qwen3.5:4b v1 json_schema 300.1s: timed out            # con razonamiento encendido
qwen3.5:4b native format 300.1s: timed out             # con razonamiento encendido
qwen3.5:4b /api/chat no-think 17.5s: OK {"titulo": "Reclamo Ciudadano", "prioridad": "media", "etiquetas": ["infraestructura viales", "seguridad vial", "señalización"]}
qwen3.5:4b /v1/chat/completions no-think 18.5s: OK {"titulo": "Reclamo Ciudadano", "prioridad": "media", ...}
```

Los dos modelos respetan el esquema por las dos vías, siempre que `qwen3.5:4b` tenga el razonamiento apagado. Con el razonamiento encendido, el 4b no terminó en 300 s. Que `/v1` acepte `json_schema` **se verificó en ejecución**: la página de compatibilidad sólo dice «`response_format`» y «JSON mode», y la de structured outputs (https://docs.ollama.com/capabilities/structured-outputs) documenta `format` para `/api/chat`.

Observación de calidad (criterio propio): ante el mismo texto de prueba, el 7b clasificó «alta» y el 4b «media». Que el esquema se cumpla no significa que el criterio sea bueno.

## 5. Embeddings

```bash
curl -s $OLLAMA_ENDPOINT/api/embed     -d '{"model":"qwen3.5:4b","input":"hola"}'
curl -s $OLLAMA_ENDPOINT/v1/embeddings -d '{"model":"qwen3.5:4b","input":"hola"}'
```

```text
### qwen3.5:4b /api/embed
{"error":"This server does not support embeddings. Start it with `--embeddings`"} [HTTP 501 0.437415s]
### qwen3.5:4b /v1/embeddings
{"error":{"message":"This server does not support embeddings. Start it with `--embeddings`","type":"api_error",...}} [HTTP 501 0.448161s]
qwen2.5:7b-instruct /api/embed 169.8s: HTTP Error 501: Not Implemented      # py/probe.py embed
qwen2.5:7b-instruct /v1/embeddings 300.1s: timed out
```

**En este servidor no hay embeddings con los modelos de chat.** Las dos rutas responden 501. El texto del error es el del runner interno que sirve el modelo, que se levantó sin modo embeddings. Por eso **la dimensión no se pudo medir**: el `embedding_length` que informa `/api/show` (3584 para el 7b, 2560 para el 4b) es el ancho interno del modelo, no un embedding servido.

Recomendaciones. Ninguna está instalada: instalar un modelo es un cambio de infraestructura y lo decide el PO.

| Modelo (librería Ollama) | Tamaño | Contexto | Dimensión | Fuente |
|---|---|---|---|---|
| `embeddinggemma` | 300M parámetros | 2K | 768 (MRL 512/256/128), según la familia; **no verificado en el tag de Ollama** | https://ollama.com/library/embeddinggemma (requiere Ollama ≥ 0.11.10); https://ai.google.dev/gemma/docs/embeddinggemma |
| `nomic-embed-text` (v1.5) | 274 MB | 2K | 768 (Matryoshka 512/256/128/64) | https://ollama.com/library/nomic-embed-text; https://huggingface.co/nomic-ai/nomic-embed-text-v1.5. **Exige prefijos de tarea** (`search_query:`, `search_document:`) |

La documentación de embeddings de Ollama (https://docs.ollama.com/capabilities/embeddings) usa `embeddinggemma` en todos sus ejemplos y documenta `/api/embed`. La de compatibilidad documenta `/v1/embeddings` con `model`, `input` y `dimensions`.

Mientras no haya un modelo de embeddings en el servidor, los ejemplos de RAG necesitan otra salida. Propuesta, como criterio propio: escribir el código contra `IEmbeddingGenerator<string, Embedding<float>>` y dejar el modelo como configuración (`OLLAMA_EMBED_MODEL`). La evidencia de RAG se corre contra un Ollama local en contenedor (`ollama/ollama` con `embeddinggemma`) o queda marcada como pendiente de instalar el modelo en el servidor de la LAN. **Ninguna de estas variantes se ejecutó en este sondeo.**

## 6. .NET: `IChatClient` real desde `mcr.microsoft.com/dotnet/sdk:10.0`

### 6.1 Consola nueva + paquetes desde nuget.org

```bash
docker run --rm -u 1000:1000 -e HOME=/tmp -e DOTNET_CLI_TELEMETRY_OPTOUT=1 -e DOTNET_NOLOGO=1 \
  -e NUGET_PACKAGES=/nuget/packages -v <volumen-nuget>:/nuget -v $PWD/NuevaConsola:/w -w /w \
  mcr.microsoft.com/dotnet/sdk:10.0 sh -c 'dotnet new console -n NuevaConsola -o . ;
    dotnet add package Microsoft.Extensions.AI; dotnet add package OllamaSharp;
    dotnet add package Microsoft.Extensions.AI.OpenAI; dotnet build'
```

```text
info : PackageReference for package 'Microsoft.Extensions.AI' version '10.11.0' added to file '/w/NuevaConsola.csproj'.
info : PackageReference for package 'OllamaSharp' version '5.5.0' added to file '/w/NuevaConsola.csproj'.
info : PackageReference for package 'Microsoft.Extensions.AI.OpenAI' version '10.11.0' added to file '/w/NuevaConsola.csproj'.
    0 Warning(s)
    0 Error(s)
```

SDK: `dotnet --version` → `10.0.403`. El aviso «An issue was encountered verifying workloads» aparece en cada comando y no afecta la consola.

Versiones restauradas (`dotnet list package --include-transitive`, proyecto `SondeoIChatClient`):

| Paquete | Versión | Tipo | Último en nuget.org (2026-10-26) |
|---|---|---|---|
| Microsoft.Extensions.AI | 10.11.0 | directo | 10.11.0 (GA) |
| Microsoft.Extensions.AI.OpenAI | 10.11.0 | directo | 10.11.0 (GA) |
| OllamaSharp | 5.5.0 | directo | 5.5.0 |
| Microsoft.Extensions.AI.Abstractions | 10.11.0 | transitivo | 10.11.0 |
| OpenAI | 2.14.0 | transitivo | 2.14.0 |
| System.Numerics.Tensors | 10.0.13 | transitivo | — |

Fuente de las versiones: `https://api.nuget.org/v3-flatcontainer/<id>/index.json`. **`Microsoft.Extensions.AI.Ollama` está deprecado.** Su última versión es `9.7.0-preview.1.25356.2`, y el catálogo de nuget.org (`registration5-gz-semver2`) la marca con este mensaje: «This package is deprecated and the OllamaSharp package is recommended. [...] No further updates, features, or fixes are planned». El paquete alternativo que indica es `OllamaSharp`. La guía no debe usarlo.

### 6.2 Ejecución contra el servidor

Proyecto `dotnet/SondeoIChatClient/Program.cs`. El endpoint sale de `OLLAMA_ENDPOINT` (por defecto `http://localhost:11434`), el modelo de `OLLAMA_MODEL`, y hay dos vías:

- `ollama` → `new OllamaApiClient(http) { SelectedModel = model }`, que ya es un `IChatClient`.
- `openai` → `new OpenAIClient(new ApiKeyCredential("ollama"), new OpenAIClientOptions { Endpoint = new Uri(endpoint + "/v1") }).GetChatClient(model).AsIChatClient()`.

Las pruebas son: `chat` (`GetResponseAsync`); `tools` (`ChatClientBuilder(inner).UseFunctionInvocation()` + `AIFunctionFactory.Create`); `json` (`GetResponseAsync<Clasificacion>` sobre un record con enum). Para apagar el razonamiento se usa la abstracción de MEAI 10.11, no una propiedad propia de cada proveedor:

```csharp
o.Reasoning = new ReasoningOptions { Effort = ReasoningEffort.None };
```

```bash
docker run --rm --network host -u 1000:1000 -e HOME=/tmp -e NUGET_PACKAGES=/nuget/packages \
  -e OLLAMA_ENDPOINT -e OLLAMA_MODEL=qwen3.5:4b -e SIN_RAZONAMIENTO=1 \
  -v <volumen-nuget>:/nuget -v $PWD/dotnet:/w -w /w/SondeoIChatClient \
  mcr.microsoft.com/dotnet/sdk:10.0 dotnet run -c Release --no-build -- ollama chat,tools,json   # y luego: openai
```

```text
### dotnet ollama qwen3.5:4b
via=ollama model=qwen3.5:4b client=OllamaSharp.OllamaApiClient sinRazonamiento=True
[chat] 18.9s in=24 out=57 -> Un **embedding** (o representación vectorial) es una transformación matemática que convierte datos no estructurados ...
  (tool invocada: provincia=Santa Fe)
[tools] 50.5s llamadas=1 -> Hay 365 localidades registradas en la provincia de Santa Fe.
[json] 16.4s ok=True -> Reclamo Ciudadano | Alta | Tráfico,Seguridad Vial,Infraestructura Urbana,Accidentes de Tránsito
### dotnet openai qwen3.5:4b
via=openai model=qwen3.5:4b client=Microsoft.Extensions.AI.OpenAIChatClient sinRazonamiento=True
[chat] 11.4s in=24 out=57 -> Un **embedding** (o representación vectorial) es una transformación matemática ...
  (tool invocada: provincia=Santa Fe)
[tools] 13.8s llamadas=1 -> Hay 365 localidades registradas en la provincia de Santa Fe.
[json] 13.2s ok=True -> Reclamo Ciudadano | Alta | Tráfico,Seguridad Vial,Infraestructura Urbana,Accidentes de Tránsito
```

- `ReasoningEffort.None` funcionó **por las dos vías**: no hubo `reasoning` y las respuestas salieron rápido. Que OllamaSharp traduzca `ChatOptions.Reasoning` a `think` se infiere del resultado y de los símbolos `ReasoningEffort`/`ThinkValue` del ensamblado. La traducción en sí **no se verificó en el código fuente**.
- La invocación automática de funciones (`UseFunctionInvocation`) ejecutó la tool una vez y el modelo integró el resultado.
- `GetResponseAsync<T>` deserializó el record, incluido el enum (`Alta`).
- Intento anterior con `qwen2.5:7b-instruct` por OllamaSharp: `TaskCanceledException ... HttpClient.Timeout of 600 seconds elapsing` en el primer `GetResponseAsync`. Fue la cola del servidor compartido más el cambio de modelo, no un error del cliente: el mismo modelo había respondido antes por HTTP directo (secciones 3 y 4). La vía OpenAI con el 7b no se volvió a correr.
- Los archivos generados en `bin/` y `obj/` quedan a nombre de `1000:1000` porque los contenedores corren con `-u 1000:1000`. Hay carpetas de root en otros directorios de `{dir-de-trabajo}/` (por ejemplo `n1-adv/bin`), pero son de fases anteriores, no de este sondeo.

## 7. Tabla de capacidades medidas

| Modelo | Chat `/v1` | Tool calling `/v1` | Salida estructurada | Embeddings | IChatClient .NET (OllamaSharp / OpenAI) | Observación |
|---|---|---|---|---|---|---|
| qwen3.5:4b | OK; razona por defecto. Con razonamiento apagado: ~3,8–4,1 tok/s, 11–24 s por respuesta corta | OK, `tool_calls` bien formados | OK por `json_schema` (`/v1`) y `format` (`/api/chat`), **sólo con razonamiento apagado** | No (501) | OK / OK (chat, tools, json) con `ReasoningEffort.None` | Es el modelo residente, el que menos espera |
| qwen2.5:7b-instruct | OK, ~0,9 tok/s (eval) bajo carga, 100–160 s | OK, `tool_calls` bien formados | OK por las dos vías | No (501) | Timeout de 600 s por cola (no reintentado) | Útil si el servidor está libre; obliga a cambiar de modelo |
| qwen2.5:14b-instruct | No respondió en 900 s | Timeout de 300 s | No medido | No medido | No medido | No usar en este servidor |
| gemma4, gpt-oss:20b, qwen3-coder:30b, qwen2.5vl | No medido (sólo `/api/show`) | — | — | — | — | — |

## 8. Recomendación para los ejemplos y la demo

1. **Chat, tools y salida estructurada: `qwen3.5:4b` con el razonamiento apagado.** En .NET: `ChatOptions.Reasoning = new ReasoningOptions { Effort = ReasoningEffort.None }`. En HTTP: `think:false` (nativo) o `reasoning_effort:"none"` (`/v1`). Es el único modelo que pasó las tres pruebas por las dos vías .NET en tiempos razonables. Al ser el residente, no fuerza cambios de modelo que perjudiquen a otros usuarios del servidor. Alternativa: `qwen2.5:7b-instruct`, que no razona y también cumple tools y esquema, pero tarda bastante más mientras el servidor esté compartido.
2. **Configuración:** `OLLAMA_ENDPOINT` (por defecto `http://localhost:11434`), `OLLAMA_MODEL` (por defecto `qwen3.5:4b`), `OLLAMA_EMBED_MODEL` y un timeout de `HttpClient`/`NetworkTimeout` de 5 a 10 minutos.
3. **Proveedor:** las dos vías funcionan. Propuesta (criterio propio): OllamaSharp 5.5.0 como vía principal, porque habla la API nativa (`think`, `format`, `/api/embed`), y `Microsoft.Extensions.AI.OpenAI` 10.11.0 para mostrar que el mismo código `IChatClient` cambia de proveedor sin tocar la aplicación. No usar `Microsoft.Extensions.AI.Ollama`, que está deprecado.
4. **Embeddings: hoy no hay modelo en el servidor.** Se recomienda `embeddinggemma` (o `nomic-embed-text`, con prefijos de tarea). Instalarlo queda **como pedido al PO**, porque toca infraestructura. Hasta entonces, el RAG de la guía se escribe contra `IEmbeddingGenerator` y su evidencia ejecutada requiere el modelo instalado o un Ollama local en contenedor.
5. **No prometer `tool_choice`:** Ollama no lo soporta en `/v1/chat/completions`. Los ejemplos tienen que pedirle el uso de la herramienta en el prompt.

---

> **2026-10-29 — Recuperación (bloque B-02 del plan, REC-06.4). Nota agregada; no reemplaza nada de lo anterior.** **Las secciones 0 a 8 son historia**: describen el servidor compartido del laboratorio (servidor de laboratorio retirado el 2026-10-28). Valen como registro de qué se midió, con qué método y qué se aprendió; no como estado del entorno. Sus cifras de latencia, su lista de modelos y la ausencia de embeddings no se citan como situación vigente.
>
> Lo que sigue es el **§R completo del insumo** (`$INSUMO/Bitacoras/Sondeo-Entorno.md`, desde «2026-10-28 — Reanudación» hasta el final; procedencia PB-02 y PB-05 en `Mesa/Recuperacion-2026-10-28/Procedencia.md`), copiado con tres adaptaciones y nada más: (1) R-PRIV: los equipos, el recurso de turno y la herramienta de turnos van por rol (estación 1 = estación de laboratorio de 4 núcleos; estación 2 = estación de laboratorio con más núcleos; `<recurso-compartido>`, `<gestor-de-turnos>`), y no se copian el modelo de CPU ni la memoria de los anfitriones (RPRI-18); (2) los crudos del sondeo están en esta bitácora, en [`Evidencia/Sondeo-2026-10-28/`](Evidencia/Sondeo-2026-10-28/) (copia PB-03, después de la compuerta R-PRIV), y la ruta se ajustó; (3) los nombres de archivo del insumo que llevan el nombre de un equipo se escriben con el rol entre `<…>`. **Las demás remisiones** (`Mesa/Ciclo-1/…`, `BIT-16-04`, `Integracion-Evidencia/…`, «Parche P-nn (ciclo 1)», «04-Integracion») **son documentos del insumo** (`$INSUMO/Bitacoras/…`), no de esta bitácora. Las cifras de R.1 a R.7 son las del origen (cotejo número por número en `Mesa/Recuperacion-2026-10-28/04-Aplicacion.md`, B-02). La «estación de laboratorio» de §R.0 a §R.6 es la estación 1.

## 2026-10-28 — Reanudación: el servidor medido ya no existe

> Nota agregada el 2026-10-28; no reemplaza nada de lo anterior. **Las secciones 0 a 8 describen el servidor Ollama de la LAN del laboratorio (dado de baja el 2026-10-28).** Valen como historia (qué se midió, con qué método y qué se aprendió de `qwen3.5:4b`, del razonamiento, de `tool_choice` y de los paquetes .NET), **no como estado del entorno**. Las cifras de latencia, la lista de modelos y la ausencia de embeddings de esas secciones ya no se pueden citar como situación vigente. Las versiones de paquetes de §6.1 se consultaron el 2026-10-26 y no se volvieron a consultar en este sondeo.
>
> Lo que sigue es el sondeo corto contra **el Ollama propio en contenedor de la estación 1** (estación de laboratorio de 4 núcleos), registrado como evidencia **E1**. Corridas del 2026-10-28 entre las 08:45 y las 08:51 (-03). El endpoint se pasó sólo por `OLLAMA_ENDPOINT`; su valor no se escribe (R-PRIV). Las corridas con más de un prompt se hicieron con turno exclusivo del recurso `<recurso-compartido>` (protocolo de recursos compartidos), así que **esta vez las latencias son de banco exclusivo**, no bajo carga.

### R.0 Condiciones de la medición

- Anfitrión: estación de laboratorio de 4 núcleos / 8 hilos (`lscpu`), **sin GPU** (modelo de CPU y memoria del anfitrión omitidos al copiar, RPRI-18). Contenedor `ollama/ollama@sha256:dea72d1e22270fe095b68fdf756d2b489d615643c5a2eaebbc5f569181e322d8`.
- `GET /api/version` → `{"version": "0.40.11"}` (el servidor viejo era `0.32.0-rc0`).
- `GET /api/ps` → `size_vram: 0` en todos los modelos (CPU) y **`context_length: 4096`** al cargar cada uno: con la configuración actual del contenedor, el contexto efectivo es 4096, no el nativo del modelo. El servidor viejo había cargado `qwen3.5:4b` con 65536. Para RAG o historiales largos la guía tendrá que fijar `num_ctx` (o la variable del servidor) y volver a medir: **no se probó en este sondeo**.
- `qwen3.5:4b` se descargó en esta misma sesión (`ollama list` lo mostró a las 08:45); `qwen2.5:0.5b` y `qwen3-embedding:0.6b` ya estaban.
- Scripts y salidas crudas: `Evidencia/Sondeo-2026-10-28/` (`sondeo.py`, `correr.sh`, `correr-extra.sh`, `salidas/*.jsonl`). Se corrieron así:

```bash
OLLAMA_ENDPOINT=... <gestor-de-turnos> <recurso-compartido> sondeo-e1 "<motivo>" 45 -- ./correr.sh        # info, chat, embed, tools 10x2
OLLAMA_ENDPOINT=... <gestor-de-turnos> <recurso-compartido> sondeo-e1 "<motivo>" 45 -- ./correr-extra.sh  # tools «a pie» 10x2, tools con razonamiento 5
```

### R.1 Modelos y capacidades declaradas (`/api/tags` + `/api/show`)

| Modelo | Digest (`/api/tags`) | Parámetros / cuant. | Tamaño | `capabilities` | Contexto nativo | `embedding_length` | `parameters` del Modelfile |
|---|---|---|---|---|---|---|---|
| qwen3.5:4b | `d8b0f5e9760cd1682034f292d7ef72ec46f432149be0df7574bf2d6e92e38c04` | 4.2B (4 205 751 296) Q4_K_M | 3,32 GB | completion, vision, tools, thinking | 262144 | 2560 | `temperature 1`, `top_k 20`, `top_p 0.95`, `presence_penalty 1.5` |
| qwen2.5:0.5b | `a8b0c51577010a279d933d14c2a8ab4b268079d44c5c8830c0a93900f1827c67` | 494.03M Q4_K_M | 0,40 GB | completion, tools | 32768 | 896 | (ninguno) |
| qwen3-embedding:0.6b | `ac6da0dfba84a81fdbfbaf330198c33cd77c4cdfc53e8bc50eb581914a15621d` | 595.78M Q8_0 | 0,64 GB | **embedding**, tools, thinking | 32768 | 1024 | (ninguno) |

Que `qwen3-embedding:0.6b` declare también `tools` y `thinking` es lo que devuelve `/api/show`; no se probó usarlo para chat y no tiene sentido hacerlo.

### R.2 Chat por `/api/chat` (una corrida por modelo)

Prompt: «En dos oraciones: ¿para qué sirve una encuesta de movilidad urbana que registra el medio de transporte que usa cada persona?». `stream: false`, `options: {temperature: 0, num_predict: 200}`; para `qwen3.5:4b`, además `think: false`. Salida: `salidas/02-chat.jsonl`. Los tiempos salen de los campos `*_duration` de la respuesta; tok/s = `eval_count / eval_duration`.

| Modelo | Carga | Total | Pared | `prompt_eval_count` | `eval_count` | tok/s (eval) | `done_reason` |
|---|---|---|---|---|---|---|---|
| qwen2.5:0.5b | 1,82 s | 5,69 s | 5,70 s | 60 | 200 | 56,16 | `length` |
| qwen3.5:4b (`think:false`) | 10,48 s | 18,86 s | 18,90 s | 37 | 52 | 7,43 | `stop` |

- `qwen3.5:4b` cumplió la consigna en 52 tokens y dos oraciones. `qwen2.5:0.5b` no la cumplió: arrancó una lista numerada y cortó por presupuesto (`length`). Es una sola corrida por modelo, así que vale como observación, no como tasa.
- La carga en frío del 4b (10,5 s) es más de la mitad del total. Con el modelo caliente, el costo dominante es la generación, a unos 7 tok/s.

### R.3 Embeddings (`qwen3-embedding:0.6b`)

Salida: `salidas/03-embed.jsonl`.

| Vía | Entrada | HTTP | Dimensión | Tiempo |
|---|---|---|---|---|
| `POST /api/embed` (frío) | 2 textos («Voy al trabajo en bicicleta todos los días.», «Uso el colectivo algunos días por semana.») | 200 | 1024 (2 vectores) | 3,04 s total, de los cuales 2,82 s de carga |
| `POST /api/embed` (caliente) | 1 texto | 200 | — | 0,13 s |
| `POST /v1/embeddings` | 1 texto | 200 | 1024 | 0,12 s |

**Ahora sí hay embeddings servidos**, por las dos rutas, y la dimensión medida (1024) coincide con el `embedding_length` de `/api/show`. Esto cierra el «hoy no hay modelo de embeddings» de §5 y §8.4 **para este servidor**: el modelo es `qwen3-embedding:0.6b`, no `embeddinggemma` ni `nomic-embed-text`, que siguen sin instalarse ni probarse.

### R.4 Tool calling por `/v1/chat/completions` (R-LLM)

Herramienta (salida completa en el registro `tools-resumen` de cada `.jsonl`):

```json
{"type":"function","function":{"name":"contar_respuestas_por_medio",
 "description":"Devuelve cuántas respuestas de la encuesta de Movilidad Urbana declararon un medio de transporte.",
 "parameters":{"type":"object","properties":{"medio":{"type":"string",
   "enum":["colectivo","auto","bicicleta","moto","caminata","tren"],
   "description":"Clave del medio de transporte de la encuesta."}},"required":["medio"]}}}
```

Las claves del `enum` son las del catálogo `Medios` del caso base (`MovilidadUrbana.ApiWeb/Domain/Catalogos.cs`). Mensaje de sistema: «Respondé usando las herramientas disponibles cuando hagan falta.». Parámetros: `temperature: 0.7`, `seed` = número de corrida (1..N), `max_tokens: 300`; en `qwen3.5:4b`, `reasoning_effort: "none"` salvo en la fila marcada. Se eligió temperatura 0.7, y no 0, para que la tasa tenga sentido: con 0 las N corridas serían la misma.

**Criterio de éxito** (lo aplica el script, no un humano): exactamente una entrada en `tool_calls`, `function.name == "contar_respuestas_por_medio"`, `arguments` que parsea como JSON, `medio` dentro del `enum` **y** igual a la clave esperada. Cada corrida se clasifica como éxito o como uno de estos fallos: `tool_calls=0`, `nombre`, `argumento fuera del enum`, `medio equivocado`.

| Modelo@digest | Pedido (clave esperada) | Razonamiento | N | Éxitos | Tasa | Pared (1.ª / resto) | Fallos observados |
|---|---|---|---|---|---|---|---|
| qwen2.5:0.5b@a8b0c515… | «¿Cuántas respuestas de la encuesta de Movilidad Urbana dicen que se viaja en bicicleta?» (`bicicleta`) | — | 10 | 10 | **10/10** | 4,49 s / 0,66–0,88 s | — |
| qwen3.5:4b@d8b0f5e9… | ídem (`bicicleta`) | apagado | 10 | 10 | **10/10** | 34,51 s / 4,65–4,78 s | — |
| qwen2.5:0.5b@a8b0c515… | «¿Cuánta gente contestó en la encuesta de Movilidad Urbana que va a pie?» (`caminata`) | — | 10 | 0 | **0/10** | 1,32 s / 0,46–0,84 s | 6 × `medio:"piedra"` (fuera del enum), 2 × `auto`, 1 × `tren`, 1 × sin llamada (texto incoherente) |
| qwen3.5:4b@d8b0f5e9… | ídem (`caminata`) | apagado | 10 | 10 | **10/10** | 20,61 s / 4,69–4,96 s | — |
| qwen3.5:4b@d8b0f5e9… | primer pedido (`bicicleta`) | **por defecto (encendido)** | 5 | 5 | **5/5** | 33,76 s / 19,12–25,90 s | — (120–163 tokens de completado por corrida, contra 34 con razonamiento apagado) |

Salidas: `salidas/04-tools.jsonl`, `salidas/05-tools-apie.jsonl` y `salidas/06-tools-razonando.jsonl`. La 1.ª corrida de cada serie del 4b incluye carga o recarga del modelo.

Lectura:

- Con un pedido literal («bicicleta» → `bicicleta`), los dos modelos aciertan siempre. **Ese pedido no discrimina.** El segundo pedido obliga a mapear un sinónimo («a pie») a la clave del catálogo (`caminata`), y ahí el 0.5b falla en las 10 corridas mientras el 4b acierta en las 10.
- **Ollama no hizo cumplir el `enum` del esquema de la herramienta**: el 0.5b devolvió `"medio":"piedra"` con `finish_reason: tool_calls`. La validación de argumentos tiene que quedar del lado de la aplicación (la función .NET o el filtro de invocación), no confiarse al servidor. Esto es una observación de este servidor y este modelo; **no se buscó documentación** que lo afirme o lo niegue.
- Las tasas son de N = 10 (N = 5 con razonamiento) sobre un solo pedido por fila. Sirven para separar los modelos, no para estimar fiabilidad en general.

### R.5 Consecuencias para la guía (criterio propio, a ratificar por la mesa)

1. **Chat, tools y salida estructurada: `qwen3.5:4b` con razonamiento apagado**, el mismo modelo que recomendaba §8.1. En este servidor: unos 7 tok/s y entre 5 y 19 s por respuesta corta o llamada a herramienta con el modelo caliente, más unos 10 a 35 s cuando hay que cargarlo. Con razonamiento encendido, las llamadas a herramientas tardaron de 4 a 5 veces más (19–26 s) sin ganar aciertos en este pedido. **La salida estructurada no se volvió a medir en este servidor**: queda pendiente de re-verificación.
2. **`qwen2.5:0.5b` no sirve para la guía como modelo de tools**: 0/10 en cuanto el pedido exige interpretar. Puede quedar sólo como modelo «de humo» para comprobar conectividad rápido (5,7 s por respuesta), y no se lo debe presentar como ejemplo de agente.
3. **Embeddings: `qwen3-embedding:0.6b`, dimensión 1024**, por `/api/embed` (OllamaSharp) o `/v1/embeddings` (vía OpenAI). Los valores por defecto de configuración que propone §8.2 se ajustan así: `OLLAMA_MODEL=qwen3.5:4b`, `OLLAMA_EMBED_MODEL=qwen3-embedding:0.6b`. El uso desde `IEmbeddingGenerator` en .NET **no se ejecutó en este sondeo**.
4. **Contexto efectivo de 4096**: cualquier ejemplo de RAG o de historial largo tiene que fijar el contexto explícitamente y medirlo. Tampoco se probó un contexto mayor.
5. **Validar los argumentos de las herramientas en la aplicación** (R.4): este hallazgo alimenta el núcleo de agentes y herramientas como caso E1.
6. **Alcance de la estación 1.** Para corridas de a una, con el recurso en turno, la estación 1 alcanza: una suite de 10 llamadas a herramientas con el 4b tarda menos de un minuto. No alcanza, o no se midió, para: (a) varios agentes o una demo con usuarios concurrentes, porque el turno es exclusivo y la CPU es de 4 núcleos; (b) contextos grandes (RAG con muchos fragmentos), que pesarán en el `prompt_eval`, sin medir; (c) modelos mayores que el 4b, como el 7b de la tabla vieja. Para esos casos **se recomienda levantar un Ollama en la estación con más núcleos y que lo decida la mesa**, midiendo con este mismo `sondeo.py` antes de adoptarlo. No se levantó ni se midió nada en esa estación en este sondeo.
7. **Pendiente de re-verificación contra este servidor**: salida estructurada (§4), las dos vías .NET `IChatClient` de §6.2 con `ReasoningEffort.None`, y el comportamiento de `reasoning_effort:"none"` y `think:false` en la versión 0.40.11 por la vía .NET. Por HTTP directo, los dos funcionaron en este sondeo (R.2 y R.4).

> **2026-10-28 — Ciclo 1 de la mesa: convención de ids en estas notas.** «Parche P-nn (ciclo 1)» es un parche de `Mesa/Ciclo-1/03-Parches.md`, aplicado según `Mesa/Ciclo-1/05-Aplicacion.md`; «P-nn» sin calificar dentro de un texto de parche también es un parche. Los pendientes de BIT-16-04 §7 se citan como «pendiente P-nn de BIT-16-04». El plan vinculante de redacción es `Mesa/Ciclo-1/06-Plan-De-Redaccion.md`.

> **2026-10-28 — Parche P-01 (ciclo 1).** Redacción in situ por R-PRIV (C1-01; jurado 5/5, aprobación 5/5): se redactaron 2 ruta(s) absoluta(s) del home, reemplazadas por rutas desde la raíz del workspace o por variable (`$WORKSPACE`, `{dir-de-trabajo}`). No cambió ninguna afirmación (diff palabra por palabra en `Mesa/Ciclo-1/05-Aplicacion.md`). Es la excepción a «sólo agregado» que prevé 03-Parches §0.1; el dictamen de la presidencia sobre esa excepción queda registrado como pendiente en 05-Aplicacion. La salida de la compuerta antes y después está en `Mesa/Ciclo-1/aplicacion/rpriv-2026-10-28-antes.txt` y `rpriv-2026-10-28-despues.txt`.

> **2026-10-28 — Parche P-37 (ciclo 1).** §R.5.6: donde dice que «≥ 7B no corre en la estación 1» se lee «no se midió en la estación 1; el contenedor está limitado a 4 CPU / 5 GB». Texto completo en BIT-16-04 §5 (MI-03).

> **2026-10-28 — Parche P2-10 (ciclo 1, ronda 2).** Completa P-37 (C1-42 y C1-51 = A). La frase sigue siendo «no se midió en la estación de laboratorio; el contenedor está limitado a 4 CPU / 5 GB», y se le suma el hecho medido: `qwen3.5:35b-a3b` ocupa 21,05–21,83 GiB cargado, más de cuatro veces el límite de 5 GB de ese contenedor; un denso de 7–9B sigue **sin medirse**. **MI-03 queda así:** el segundo servidor de prueba se usa **bajo demanda y por la mesa**, con versión, digest, límites y sondeo previo registrados (ya hechos: misma imagen por digest, 0.40.11, 14 CPU / 34 GiB, mismos digests de modelos, mismo `sondeo.py` con las mismas tasas, 10/10, 10/10, 0/10 y 5/5). Cubre P-03 (el juez, P2-11), P-07 (el comparativo con un modelo mayor) y los prompts largos (lectura de 107,5–110,3 tok/s frente a unos 19 en la estación). La concurrencia y el contexto grande se miden en la estación con su rótulo o quedan «no medido». Para P-07 se presupuestan, con el 35b-a3b, unos 51 s por cada 3500 tokens de prompt sin caché, 3,6 tok/s de salida y 22,8–24,0 s de carga en frío (N = 2) (PC-07, N = 3 para el prompt largo con `num_ctx` 8192). La frase de P-37 «se apaga al terminar» se reemplaza por «el apagado lo decide la presidencia» (Consulta del segundo servidor; §5 de este documento).
> **Ajustes vinculantes incorporados:** (juez de evidencia) la carga en frío del 35b-a3b es 22,8–24,0 s con N = 2; (juez de riesgo (a)) estado del segundo servidor al aplicar: el contenedor quedó **arriba** a pedido de la consulta, con límites 14 CPU / 34 GiB y `KEEP_ALIVE` de 10 min (el modelo se descarga, el contenedor no), en el equipo que es el respaldo de contingencia de la estación; el apagado lo decide la presidencia, **antes del cierre del ciclo 1** (riesgo (b)); ningún texto nuevo nombra el equipo ni el contenedor (riesgo (c)).



### R.6 Tabla única de cifras de la estación de laboratorio (2026-10-28)

> **2026-10-28 — Parche P-21 (ciclo 1).** §R.6, tabla única de cifras. Toda cifra de latencia de este cuaderno y de la guía sale de esta tabla, recalculada desde los `.jsonl` crudos de `Evidencia/Sondeo-2026-10-28/salidas/` con un script guardado junto a ellos (`cifras.py`). Columnas: fuente (archivo y línea), operación, modelo@digest, N, frío o caliente, tokens de prompt, tokens de salida, pared en s (mediana y rango), tok/s de lectura del prompt, tok/s de generación, límites del contenedor (4 CPU / 5 GB). Las filas obligatorias incluyen la lectura del prompt del 4b: unos 2050 tokens en unos 100 s, 1466 en 77,8 s y 2943 en 167 s (EXPERT-03), o sea unos 18–20 tok/s. Las cuatro cifras que CAT-OP-02 marcó como mal derivadas se reemplazan por las de esta tabla y la anterior queda tachada en una nota. El tamaño de fragmento y el k de la demo se eligen con esta tabla: con unos 19 tok/s de lectura, cada 1000 tokens de contexto suman unos 50 s de pared antes del primer token.
> **Plan de turnos (BIT-16-04 §7):** se adopta la tabla de turnos de CAT-OP §5. Cada pendiente P-01…P-15 lleva su pared estimada con esta tabla. Lo que no entra en un turno de 45 min se rotula «no medido», no se omite.
>
> **Aplicación (2026-10-28):** el script es `Evidencia/Sondeo-2026-10-28/cifras.py` y la tabla, `Evidencia/Sondeo-2026-10-28/cifras-2026-10-28.md` (28 filas, regenerable). Agrega por archivo, operación, modelo y estado frío/caliente: N, tokens de prompt, de salida y en caché, pared (mediana y rango), lectura del prompt en tok/s (sólo llamadas con más de 1 s de evaluación) y generación. Columna «fuente» con archivo y líneas, sin hosts (condición del juez de riesgo). Lectura del prompt del 4b en las llamadas sin caché: 18,8 tok/s (1466 tokens en 77,8 s, s4 A), 17,6 (2943 en 167,4 s, s5), 21,9 (1541 en 70,4 s, O5 frío) y 13,2 (1469 en 111,1 s, O3, 4b); mediana ≈ 19 tok/s, rango 13–22. La s3 (2050 tokens, 100,25 s de pared) no registró la duración de la lectura.
> **Las cuatro cifras de CAT-OP-02, reemplazadas** (las anteriores quedan sin efecto; no se borran): (1) §R.5.6 «una suite de 10 llamadas a herramientas con el 4b tarda menos de un minuto» → ~~menos de un minuto~~ **76,72 s** (`04-tools.jsonl`, l. 12–21) y **63,55 s** (`05-tools-apie.jsonl`, l. 12–21); (2) §R.5.1 «entre 5 y 19 s por respuesta corta o llamada a herramienta con el modelo caliente» → ~~5–19 s caliente~~: los 18,90 s del chat del 4b son **en frío** (`02-chat.jsonl` l. 3); en caliente, las herramientas del 4b dan **4,65–4,96 s** de mediana por serie (4,68 y 4,75 s); (3) MI-24 «paredes 13–58 s» (X2) → ~~13–58 s~~ **12,93–75,63 s**, total de las 30 llamadas **688,10 s**; (4) M5 «paredes de 5–92 s por iteración» → ~~por iteración~~: 4,65 s es una llamada HTTP sola (§R.4) y 91,8 s es una **operación** .NET completa con dos llamadas al modelo (E-B1); la guía no da cifra «por iteración».

> **2026-10-28 — Parche P2-10 (ciclo 1, ronda 2).** La tabla suma la columna «servidor» (estación de laboratorio | segundo servidor de prueba) y estas filas, cada una con su archivo crudo: (1) `qwen3.5:2b@0689d44085e0`, Q8_0, 2 683 396 812 bytes (`evidencia-comparacion-2b-4b/03-comparacion.jsonl`, línea 1); (2) recarga del 4b al alternar `num_ctx` (paso 3 de PC-06, sin `num_ctx` con el modelo cargado con 8192): 10,5–16,1 s de `load_duration`, N = 5, estación (`evidencia-operacion-telemetria/PC06-qwen3.5-4b-corto.jsonl`); aparte, como referencia de carga y no de recarga: carga en frío 11,5–19,2 s y carga con `num_ctx` 8192 11,4–22,8 s, N = 5 cada una; (3) lectura del 0.5b: 5134 tokens en 67–96 s, estación (`PC06-qwen2.5-0.5b.jsonl`); (4) juez, 7 evaluadores sobre un caso: 1285 s en la estación (N = 1 caso, anfitrión sin reservar; `evidencia-<estación-2>-ollama/pc08/eval-<estación-1>.jsonl`, registro `fin`) y unos 34 s por evaluación en el segundo servidor (28 evaluaciones en 950 s; `pc08/eval-<estación-2>.jsonl`); `pc08/costo-salida.txt` se nombra sólo como la estimación por fórmula, superada (P2-11); (5) 35b-a3b en el segundo servidor: 13,3 s por llamada a herramienta frente a 3,2 s del 4b, N = 10 + 10 (`evidencia-<estación-2>-ollama/pc07/resumen-salida.txt`). La estimación por la fórmula de tokens/19 subestimó el juez en la estación en un 35 %: las cifras del juez salen de la medición, no de la fórmula.
> **Decisión de la aplicación** (la boleta §6 y el relator le dejaron la decisión): **entran las cinco filas**, con las dos correcciones de arriba (fila (2): posición `MEJORAR_PLAN` del juez de costo-beneficio, en minoría, incorporada por ser mecánica; fila (4): ajuste vinculante del juez de evidencia). La columna «servidor» se agrega a las filas nuevas; las 28 filas de `cifras-2026-10-28.md` son todas de la estación. Comprobación hecha hoy: `Mesa/Ciclo-1/Ronda-2/aplicacion/verificar-pc06-2026-10-28.txt` (filas 2 y 3) y `verificar-p2-10-2026-10-28.txt` (fila 1). Las cinco filas nuevas, con la columna «servidor»:
>
> | # | Operación | Modelo@digest | N | Cifra | Servidor | Crudo (desde `Mesa/Ciclo-1/Ronda-2/`) |
> |---|---|---|---|---|---|---|
> | 1 | modelo 2b tal como se midió | `qwen3.5:2b@0689d44085e0`, Q8_0 | 1 | 2 683 396 812 bytes | estación | `evidencia-comparacion-2b-4b/03-comparacion.jsonl` l. 1 |
> | 2 | recarga al alternar `num_ctx` (paso 3) | `qwen3.5:4b@d8b0f5e9760c` | 5 | 10,5–16,1 s de `load_duration` | estación | `evidencia-operacion-telemetria/PC06-qwen3.5-4b-corto.jsonl` |
> | 2r | referencia: carga en frío / carga con 8192 | `qwen3.5:4b@d8b0f5e9760c` | 5 + 5 | 11,5–19,2 s / 11,4–22,8 s | estación | ídem |
> | 3 | lectura de 5134 tokens con `num_ctx` 8192 | `qwen2.5:0.5b@a8b0c5157701` | 5 | 67–96 s | estación | `evidencia-operacion-telemetria/PC06-qwen2.5-0.5b.jsonl` |
> | 4 | juez, 7 evaluadores sobre un caso | `qwen3.5:4b@d8b0f5e9760c` | 1 caso | 1285 s (anfitrión sin reservar) | estación | `evidencia-<estación-2>-ollama/pc08/eval-<estación-1>.jsonl` |
> | 4b | juez, 4 casos × 7 evaluadores | `qwen3.5:4b@d8b0f5e9760c` | 28 | 950 s, unos 34 s por evaluación | segundo servidor | `evidencia-<estación-2>-ollama/pc08/eval-<estación-2>.jsonl` |
> | 5 | llamada a herramienta, siguientes (mediana) | `qwen3.5:35b-a3b` frente a `qwen3.5:4b` | 10 + 10 | 13,3 s frente a 3,2 s | segundo servidor | `evidencia-<estación-2>-ollama/pc07/resumen-salida.txt` |


### R.7 Segundo servidor de prueba (estación 2, estación de laboratorio con más núcleos), 2026-10-28

> **2026-10-28 — Nota agregada (consulta dirigida MI-03, PC-07 y PC-08; dictamen de presidencia §4).** Se levantó un **segundo servidor de prueba**: Ollama propio en contenedor en una estación de laboratorio con más núcleos (estación 2), sin GPU, con la misma imagen por digest (`ollama/ollama@sha256:dea72d1e2227…`, 0.40.11). El contenedor está limitado a 14 CPU / 34 GiB, con `OLLAMA_NUM_PARALLEL=1`, `OLLAMA_MAX_LOADED_MODELS=1` y `OLLAMA_KEEP_ALIVE=10m`, y está publicado sólo en la red privada del laboratorio. Dirección sólo por variable (R-PRIV). Modelos con los mismos digests que aquí (`qwen3.5:4b@d8b0f5e9760c`, `qwen3-embedding:0.6b@ac6da0dfba84`, `qwen2.5:0.5b@a8b0c5157701`), más `qwen3.5:35b-a3b@72aac7c28be8`. El mismo `sondeo.py` (sha256 igual) dio las mismas tasas de §R.4: 10/10, 10/10, 0/10 y 5/5. Lectura del prompt del 4b: 107,5–110,3 tok/s, frente a unos 19 aquí; generación: 11–13 tok/s, frente a 7,4–10,7. Toda cifra de ese servidor lleva el rótulo «medido en la estación de laboratorio con más núcleos (contenedor 14 CPU / 34 GiB, Ollama 0.40.11), 2026-10-28» y **no** se mezcla con §R.6 sin la columna «servidor». Detalle, cifras y consecuencias: `Mesa/Ciclo-1/Ronda-2/Consulta-<estación-2>-ollama.md`; evidencia cruda: `Mesa/Ciclo-1/Ronda-2/evidencia-<estación-2>-ollama/`. En la guía se nombra sólo como «una estación de laboratorio con más núcleos».
