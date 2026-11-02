---
doc_id: BIT-16-N3b
doc_type: dossier-de-nucleo-complementario
title: N3b — CAG (Cache-Augmented Generation) y la escalera de estrategias de conocimiento
status: para el jurado
origin: agent
confidence: 0.75
owner: investigador del dossier complementario N3b (despacho de la presidencia, insumo I-03 PR-8)
last_review: 2026-10-26
audience: [mesa-evaluadora, jurado, plan de integración]
traces: [BIT-16-I03 PR-8, BIT-16-N3, BIT-16-N5, BIT-16-N6, BIT-16-03]
---

# N3b — CAG y la escalera de estrategias de conocimiento (dossier complementario)

> **Naturaleza**: material para que el jurado vote PR-8 de I-03. No es la guía final.
> **Fecha de relevamiento**: 2026-10-26. Toda versión, mínimo de tokens o comportamiento de proveedor se leyó ese día en la fuente que se indica.
> **Convención**: `[Gx]` remite a la [tabla de fuentes](#7-tabla-de-fuentes) de este dossier (prefijo G para no chocar con los `F` de N3, N5 y N6). `[X1]`…`[X4]` son evidencias ejecutadas ([§8](#8-evidencia-ejecutada)). Nivel de evidencia según el contrato: **E1** ejecutable, **E2** cita literal con ubicación, **E3** contraejemplo, **E4** regla. Lo que es criterio del investigador va marcado **(criterio propio)**; lo que no se pudo comprobar, **(no verificado)**.
> **Privacidad (R-PRIV)**: el servidor se nombra «servidor Ollama de la LAN del laboratorio». En código: `OLLAMA_ENDPOINT`, con default `http://localhost:11434`.
> **Insumos del PO**: I-03 es fuente de **forma**, no de contenido. Este dossier no lo cita como evidencia ni nombra el programa del que sale.

## Índice

- [0. Hallazgos que cambian el plan](#0-hallazgos-que-cambian-el-plan)
- [1. Relación con el insumo del PO y con los núcleos](#1-relación-con-el-insumo-del-po-y-con-los-núcleos)
- [2. Definiciones con fuente](#2-definiciones-con-fuente)
- [3. Desarrollo](#3-desarrollo)
- [4. Preguntas guía con respuesta explicativa](#4-preguntas-guía-con-respuesta-explicativa)
- [5. Criterios de calidad y antipatrones](#5-criterios-de-calidad-y-antipatrones)
- [6. Recomendación para el jurado](#6-recomendación-para-el-jurado)
- [7. Tabla de fuentes](#7-tabla-de-fuentes)
- [8. Evidencia ejecutada](#8-evidencia-ejecutada)
- [9. Abierto / no verificado](#9-abierto--no-verificado)

---

## 0. Hallazgos que cambian el plan

1. **CAG, tal como lo define el paper, no es algo que una app .NET haga a través de `IChatClient`.** El método de Chan et al. precalcula la caché KV del corpus, la **guarda en disco o en memoria** y la vuelve a cargar junto con cada consulta [G1 §2, ec. (1)–(2)]. La implementación pública lo hace con `transformers.DynamicCache` y `torch.save` sobre los pesos del modelo [G2, `kvcache.py` l. 8, 100–125]. Ninguna API de chat (OpenAI, Azure OpenAI, Anthropic, Ollama) expone la caché KV para guardarla y recargarla. Lo que una app sí puede hacer es la **versión de servicio**: poner el corpus como **prefijo estable** del prompt y dejar que el servidor reutilice el cálculo del prefijo (el *prompt caching* de los proveedores [G10][G11][G12] o la caché de prompt de llama.cpp que usa Ollama [G14][G15]). La guía tiene que nombrar esa diferencia **(criterio propio sobre E2)**.
2. **Los resultados del paper son más acotados de lo que dice el título.** En su propia Tabla 2, CAG **no** es el mejor en HotPotQA-Large: 0,7407 frente a 0,7535 de BM25 top-5 y 0,7463 de BM25 top-3 [G1 Tabla 2] (**E3**). En la Tabla 3, CAG genera **más lento** que BM25 top-3 en los tres tamaños (0,8512 s vs 0,7406 s en Small; 2,2631 s vs 0,6667 s en Large) [G1 Tabla 3] (**E3**). La ventaja fuerte y consistente es contra **contexto largo sin caché** («In-Context Learning» en el paper): 2,26 s vs 92,08 s en Large [G1 Tabla 3].
3. **`Microsoft.Extensions.AI` 10.11.0 sí tiene dónde informar tokens cacheados, pero no un control para pedir caché.** `UsageDetails.CachedInputTokenCount` existe [X1][G6], y el adaptador de OpenAI lo llena desde `InputTokenDetails.CachedTokenCount` [G7 l. 727]. `ChatOptions` no trae ninguna propiedad de caché de prompts [X1]. Para controles propios del proveedor (p. ej. `PromptCacheKey` de la Responses API de OpenAI) el camino es `ChatOptions.RawRepresentationFactory` [X1][G8]. **OllamaSharp 5.5.0 no llena `CachedInputTokenCount`** [G9].
4. **Ollama reutiliza el prefijo y se midió, pero es frágil.** En un Ollama 0.32.0-rc0 propio, la misma versión que el servidor de la LAN, un prefijo de ~4.700 tokens pasó de 102,7 s en frío a 1,1 s con otra pregunta, y un carácter cambiado al principio lo devolvió a 91,6 s [X4b]. En el servidor de la LAN el efecto no se pudo aislar [X3][X4a]:
   - corre **sólo en CPU** (`size_vram` 0) y procesa el prompt a menos de 10 tokens por segundo con `qwen3.5:4b`;
   - lo comparten otros clientes, y una recarga del modelo entre dos peticiones borró la caché;
   - `qwen3.5:4b` es un modelo **híbrido** con capas de atención lineal (`ssm.*` en el GGUF) [X2], lo que puede limitar la reutilización **(hipótesis, no verificada)**.
5. **Sin `num_ctx` explícito, Ollama trunca el corpus en silencio.** Con el default de 4096, un prompt de 4.728 tokens quedó en 2.050 y la API respondió sin error. Se perdieron las instrucciones y el principio del corpus, y la respuesta salió del último artículo [X4b]. Para CAG es el modo de falla más peligroso.
6. **Con el corpus real de Movilidad Urbana, CAG no tiene sentido en la nube y casi no se nota en local.** Los literales de `*Policy` del caso base, con la instrucción y una pregunta, suman **unos 250–265 tokens** con el tokenizador de Qwen 2.5, según la pregunta (253 en [X4b]; 259 y 264 en la re-ejecución adversarial). Quedan **por debajo del mínimo cacheable** de OpenAI y Azure OpenAI (1.024 tokens) [G10][G11] y de todos los modelos de Anthropic (512 a 4.096) [G12]. Con ese tamaño, el escalón que corresponde es «contexto fijo», no CAG. Un ejemplo comparativo necesita un corpus más grande, **escrito para la demo y rotulado como tal** (§3.7).

---

## 1. Relación con el insumo del PO y con los núcleos

### 1.1 Qué pide el insumo

I-03 (§4 y PR-8) propone **agregar CAG como estrategia de contexto** y ubicarlo en una «escalera de estrategias de conocimiento»: prompt con contexto fijo → CAG → RAG → RAG con agentes. Pide un dossier con verificación antes de redactar, distinguir CAG de la caché de respuestas de M.E.AI, revisar el *prompt caching* de los proveedores y el comportamiento de Ollama, y, si se valida, un ejemplo chico CAG vs RAG sobre Movilidad Urbana con tiempos medidos. La forma del temario (CAG antes que RAG) es el disparador; el contenido de este dossier sale de [G1]–[G24] y de [X1]–[X4].

### 1.2 Con qué núcleo se cruza

| Núcleo | Qué hay hoy | Qué aporta N3b |
| --- | --- | --- |
| **N1** Capa en el stack | Ventana de contexto: «la ventana no es memoria» (N1 §2.4, citado por N5 §2.10) | La caché de prefijo **es infraestructura del servidor del modelo**, no de la app: la app sólo controla el orden y la estabilidad del prompt (§3.4) **(criterio propio)** |
| **N2** Abstracciones | `IChatClient`, pipeline, OllamaSharp | `UsageDetails.CachedInputTokenCount`, `RawRepresentationFactory` para opciones del proveedor, OllamaSharp sin conteo de cacheados (§3.5) |
| **N3** RAG | Definición, ingesta, MEVD, criterio de recall | Los escalones **anteriores** a RAG y el criterio para saltar de uno a otro (§3.3). N3 §2.1 queda como el escalón 2 |
| **N4** Agentes | Recuperación como herramienta (N3 §1.2 → N4) | Es el escalón 3 (RAG agéntico); N3b sólo lo ubica |
| **N5** Operación | `DistributedCachingChatClient` (§2.9), contexto por defecto de Ollama contradictorio (§2.10, §8 punto 3), «lost in the middle» (F22) | Separa tres cachés que la guía no debe mezclar (§2.5). Mide el contexto que el servidor tiene cargado: 65.536 en `qwen3.5:4b` [X2], lo que resuelve en parte la duda de N5 §8.3 |
| **N6** Caso | C4 «Ayuda con RAG» con 12 enunciados; P3: «el corpus cabe entero en el prompt y RAG es, sobre todo, didáctico» | Confirma P3 con números de proveedor (mínimos de caché) y propone el ejemplo comparativo con su condición de viabilidad (§3.7) |
| **N0** Marco | ESC-01 Asistente sobre datos propios | La escalera es la «estrategia» de ESC-01 por contexto: CTX-LOCAL × CTX-PROTO en la demo, con lo que cambia en CTX-NUBE (descuentos y mínimos) y CTX-SENS (caché compartida entre usuarios) |

---

## 2. Definiciones con fuente

### 2.1 Caché KV (*key-value cache*)

- **Qué es**: el estado intermedio de inferencia de un transformer, las claves y valores de atención de los tokens ya procesados. El paper de CAG la describe como lo que «encapsulates the inference state of the LLM» [G1 §1, cita a Pope et al.]. Cuando se reutiliza, los tokens del prefijo no se vuelven a procesar.
- **Qué no es**: no es una caché de respuestas ni de embeddings. Vive en el servidor que corre el modelo, en memoria de GPU o CPU, y crece con el largo del contexto: Cartridges lo plantea como el problema de fondo, «the memory consumption of the KV cache scales with input length» [G19, abstract].

### 2.2 CAG (*Cache-Augmented Generation*), según el paper de origen

- **Definición literal** [G1, abstract]: «Our method involves preloading all relevant resources, especially when the documents or knowledge for retrieval are of a limited and manageable size, into the LLM's extended context and caching its runtime parameters. During inference, the model utilizes these preloaded parameters to answer queries without additional retrieval steps.»
- **Mecanismo en tres fases** [G1 §2]:
  1. *External Knowledge Preloading*: el corpus `D` se formatea para entrar en la ventana y se precalcula `C_KV = KV-Encode(D)`, que «is stored on disk or in memory for future use. The computational cost of processing D is incurred only once, regardless of the number of subsequent queries.»
  2. *Inference*: `r = M(D ⊕ q) = M(q | C_KV)`: la consulta se procesa sobre la caché cargada.
  3. *Cache Reset*: como la caché crece «in an append-only manner», se resetea **truncando** los tokens de la consulta, sin recargar desde disco.
- **En el código de los autores** [G2]: `kvcache.py` importa `transformers.cache_utils.DynamicCache` (l. 8), la serializa con `torch.save` (l. 117) y la limpia recortando `key_cache[i][:, :, :origin_len, :]` (l. 120–125). Requiere acceso directo al modelo (Hugging Face, `HF_TOKEN`).
- **Qué no es**: no es RAG sin vector store, ni «meter todo en el prompt» a secas. Lo que lo distingue es la **reutilización del cálculo** del corpus entre consultas. Sin esa reutilización, el paper lo llama *in-context learning* y lo mide aparte (§2.5).

### 2.3 *Prompt caching* de proveedores

Es la reutilización **del lado del servicio** del cálculo de un **prefijo idéntico**. La app no guarda nada; sólo puede ordenar el prompt para que el prefijo coincida.

| Proveedor | Cómo se activa | Mínimo | Vida | Dónde se ve | Fuente |
| --- | --- | --- | --- | --- | --- |
| **OpenAI** | «Prompt caching is enabled by default for supported OpenAI models.» | «1,024 tokens for GPT-5.6 and later and varies by request settings for earlier models» | Depende de la familia. GPT-5.6 y posteriores: `prompt_cache_options.ttl`, «30m» por defecto o «12h» en Responses, con «Minimum lifetime of 30 minutes or 12 hours». Modelos anteriores: `prompt_cache_retention`; `in_memory`, «around 5 to 10 minutes of inactivity, up to one hour»; `24h`, hasta 24 h | `cached_tokens` (y `cache_write_tokens` en GPT-5.6+); lectura «discounted up to 95%» (0,1× en GPT-5.6+); escritura 1,25× («30m») o 2,5× («12h») en GPT-5.6+, sin cargo en los anteriores | [G10] |
| **Azure OpenAI** | «Prompt caching is enabled by default for supported models.» | «A minimum of 1,024 tokens in length» y «The first 1,024 tokens in the prompt must be identical» | En memoria: «typically clears caches within 5 to 10 minutes of inactivity and always removes them within one hour»; extendida, hasta 24 h en los modelos listados | `cached_tokens` en `prompt_tokens_details`; en GPT-5.6+, también `cache_write_tokens` | [G11] (ms.date 2026-08-11) |
| **Anthropic** | Explícito: `cache_control` en bloques; o automático, con un `cache_control` en el nivel superior del request | 512, 1.024, 2.048 o 4.096 tokens según el modelo; por debajo, «are processed without caching, and no error is returned» | 5 min por defecto, renovada con cada uso; 1 h con costo extra | `cache_creation_input_tokens`, `cache_read_input_tokens`; escritura ×1,25 (5 min) o ×2 (1 h); lectura ×0,1 del precio base en la mayoría de los modelos, ×0,05 en Claude Opus 5.5 y Sonnet 5.5, ×0,025 en Claude Fable 5.1 y Mythos 5.1 | [G12] |

Detalle que importa para el diseño: en Anthropic el prefijo se arma en el orden `tools` → `system` → `messages` [G12], y en Azure «Place stable or repeated content at the beginning of the prompt and dynamic content at the end» [G11, *Best practices*]. Un cambio de un carácter en el prefijo es un fallo de caché: «A single character difference in the first 1,024 tokens results in a cache miss» [G11].

### 2.4 Caché de prompt local (llama.cpp, que usa Ollama)

- **llama.cpp server** [G15]: `cache_prompt`, «Re-use KV cache from a previous request if possible. This way the common prefix does not have to be re-processed, only the suffix that differs between the requests. […] enabling this option can cause nondeterministic results. Default: `true`».
- **Ollama 0.32.0-rc0**, la versión del servidor de la LAN [X2], lanza `llama-server` y le manda `"cache_prompt": true` en cada pedido de chat [G14, `llm/llama_server.go` l. 2104]. Reserva `-c` = `NumCtx × numParallel` y `-np` = `numParallel` (l. 372–373): cada petición paralela tiene su *slot* y su caché.
- **La documentación de Ollama no habla de esto.** La FAQ no menciona caché de prefijo [G13]. La referencia de `/api/chat` define `prompt_eval_duration` como «Time spent evaluating uncached prompt tokens» y lista un campo `prompt_eval_cached_count` («Number of prompt tokens read from the cache») [G16]. **El servidor de la LAN no lo devuelve** [X3] (es una versión anterior a la que documenta la página **(inferencia)**).
- **Qué la borra** (criterio propio sobre [G13][G14]): que el modelo se descargue (`keep_alive`, 5 min por defecto [G13]), que se recargue con otro `num_ctx`, o que otra petición con otro prefijo ocupe el mismo slot (con `OLLAMA_NUM_PARALLEL`=1 hay uno solo [G13]).

### 2.5 Tres cachés y un «sin caché» que la guía no debe confundir

| Mecanismo | Qué guarda | Dónde | Cuándo acierta | En .NET |
| --- | --- | --- | --- | --- |
| **Caché de respuestas** (`DistributedCachingChatClient`, `UseDistributedCache`) | La **respuesta** completa, serializada como JSON | `IDistributedCache` de la app | Mismos mensajes y mismas opciones: es parte de la clave (N5 §2.9, E2 de N5) | M.E.AI [G5] |
| ***Prompt caching* / caché de prefijo** | El **cálculo** del prefijo (caché KV) | Servidor del modelo | Mismo **prefijo**, aunque la pregunta cambie | Transparente; se ve en `UsageDetails.CachedInputTokenCount` si el adaptador lo informa [G6][G7] |
| **CAG del paper** | La caché KV del corpus, **persistida** y recargada | Proceso con acceso al modelo | Siempre que se cargue la caché | No hay soporte: exige correr el modelo en proceso (§3.4) |
| **Contexto largo sin caché** (*in-context learning* en [G1]) | Nada | — | Nunca: el corpus se procesa en cada consulta | Cualquier `IChatClient` |

La caché de respuestas **evita llamar al modelo**. Las otras dos **abaratan la llamada**: el modelo igual genera, pero no recalcula el corpus **(criterio propio, sobre [G5] y [G1])**.

### 2.6 Ventana declarada y ventana efectiva

- La ventana **declarada** es la que publica el modelo. La **efectiva** es la longitud en la que el modelo todavía rinde. El propio paper de CAG apoya su viabilidad en esa distinción: Llama 3.1 se entrenó con 128K, «and its effective context length is 32K in Llama 3.1 8B and 64K in Llama 3.1 70B» [G1 §1, citando RULER].
- RULER: «While these models all claim context sizes of 32K tokens or greater, only half of them can maintain satisfactory performance at the length of 32K» [G17, abstract]. Leng et al.: «only a handful of the most recent state of the art LLMs can maintain consistent accuracy at long context above 64k tokens» [G18, abstract].
- En Ollama hay una tercera ventana, la **configurada** (`num_ctx` u `OLLAMA_CONTEXT_LENGTH`), que puede ser menor que las otras dos. N5 §2.10 registró que la FAQ dice 4096 por defecto y la página «Context length» dice que depende de la VRAM [G13]. En el servidor de la LAN, `qwen3.5:4b` estaba cargado con `context_length` 65.536 sobre una ventana declarada de 262.144 [X2].

---

## 3. Desarrollo

### 3.1 Qué midió el paper

| Aspecto | Dato | Ubicación en [G1] |
| --- | --- | --- |
| Publicación | v1 2024-12-20; v2 2025-02-23; «5 pages, accepted by the Web Conference 2025 (WWW '25) as a short paper»; DOI 10.1145/3701716.3715490 (WWW Companion '25) | página abs, pie de p. 1 |
| Modelo | Llama 3.1 8B para todos los sistemas, en «Tesla V100 32G × 8 GPUs» | §3.1 |
| Datos | SQuAD 1.0 y HotPotQA, tres tamaños: HotPotQA 16/32/64 documentos (21k/43k/85k tokens); SQuAD 3/4/7 documentos (21k/32k/50k tokens) | Tabla 1 |
| Líneas de base | RAG con LlamaIndex: BM25 (disperso) y «OpenAI Indexes» (denso), top-1/3/5/10 | §3.2 |
| Métrica | BERTScore contra la respuesta de oro (similitud semántica, no *exact match*) | §3.1 |

**Resultados de calidad (Tabla 2, BERTScore)**: mejor RAG de cada tamaño contra CAG.

| Tamaño | HotPotQA: mejor RAG | HotPotQA: CAG | SQuAD: mejor RAG | SQuAD: CAG |
| --- | --- | --- | --- | --- |
| Small | 0,7676 (BM25 top-5) | **0,7951** | 0,7616 (BM25 top-3) | **0,7695** |
| Medium | 0,7633 (BM25 top-5) | **0,7821** | 0,7310 (denso top-10) | **0,7383** |
| Large | **0,7535** (BM25 top-5) | 0,7407 | 0,7658 (BM25 top-5) | **0,7734** |

Los autores lo resumen así: «CAG consistently achieved the highest BERTScore in most cases» y «as the data size increases, the performance gap between CAG and RAG narrows slightly, aligning with prior findings that long-context LLMs may experience degradation when handling very long contexts» [G1 §3.3]. También dicen que «the fact that sparse RAG outperforms dense RAG suggests that the datasets may not be sufficiently challenging» [G1 §3.3].

**Resultados de tiempo (Tabla 3, HotPotQA, segundos)**:

| Tamaño | BM25 top-3 (recup. + gen.) | Denso top-3 | CAG | Contexto sin caché |
| --- | --- | --- | --- | --- |
| Small | 0,0008 + 0,7406 | 0,4849 + 1,0093 | 0,8512 | 9,3197 |
| Medium | 0,0008 + 0,7148 | 0,4140 + 0,9566 | 1,4078 | 26,3717 |
| Large | 0,0008 + 0,6667 | 0,4123 + 0,9331 | 2,2631 | 92,0824 |

El paper atribuye la diferencia con el contexto sin caché a la precarga: «This efficiency stems from preloading the KV-cache, which eliminates the need to process the reference text on the fly» [G1 §3.3].

**Límites que declaran los autores** [G1, *Limitations*]: «Our method requires loading all relevant documents into the models context, making it well-suited for use cases such as internal knowledge bases of small companies, FAQs, and call centers, where the knowledge source is of a manageable size. However, this approach becomes impractical for significantly larger datasets.» El README agrega: «The performance of LLMs may degrade with very long contexts» [G2]. En la conclusión proponen un híbrido: «a system could preload a foundation context and use retrieval only to augment edge cases or highly specific queries» [G1 §4].

### 3.2 Lectura crítica (para el jurado)

| # | Observación | Tipo | Fundamento |
| --- | --- | --- | --- |
| L1 | El título («Don't Do RAG») promete más que los datos: en HotPotQA-Large gana BM25 | E3 | Tabla 2 |
| L2 | CAG es más lento que BM25 top-3 en todos los tamaños. Contra RAG denso depende de k: gana a denso top-10 en los tres tamaños, pero denso top-3 (recup. + gen.) es **más rápido** que CAG en Medium (1,3706 s vs 1,4078 s) y en Large (1,3454 s vs 2,2631 s), aunque el texto del paper diga «CAG remains more efficient than dense RAG». La ganancia consistente es contra contexto sin caché | E3 | Tabla 3; §3.3 |
| L3 | Un solo modelo (8B), dos datasets que los propios autores sospechan fáciles, una métrica semántica (BERTScore) | E2 | §3.1, §3.3 |
| L4 | No reportan memoria de la caché KV, tiempo de precarga ni costo de recalcularla cuando cambia el corpus | E2 (por ausencia; lectura completa de las 5 páginas) | [G1] completo |
| L5 | La actualización del conocimiento no se trata; la «Cache Reset» sólo descarta la consulta, no actualiza el corpus. El trabajo posterior de ACC dice que «challenges persist in scaling CAG to accommodate large and dynamic knowledge bases» | E2 | [G1 §2]; [G20, abstract] |
| L6 | Trabajos contemporáneos coinciden en la dirección, con un matiz de costo: «when resourced sufficiently, LC consistently outperforms RAG in terms of average performance. However, RAG's significantly lower cost remains a distinct advantage» | E2 | [G21, abstract] |

**Trabajos posteriores o vecinos con id verificado** (API de arXiv, 2026-10-26): ACC + híbrido CAG-RAG [G20, 2505.08261]; Cartridges, caché KV **entrenada** por corpus, «38.6x less memory» que ICL [G19, 2506.06266]; economía de guardar y reutilizar cachés KV en la nube [G22, 2503.14647]; TurboRAG, caché KV precalculada **por fragmento** [G23, 2410.07590]; Cache-Craft, gestión de cachés de fragmentos para RAG [G24, 2502.15734]. **No encontré** una réplica independiente que vuelva a correr los benchmarks de [G1] (búsqueda web estándar y extendida, 2026-10-26) **(no verificado)**.

### 3.3 La escalera de estrategias de conocimiento

| Escalón | Qué hace | Conviene cuando | Deja de convenir cuando | Fuente del criterio |
| --- | --- | --- | --- | --- |
| **0. Contexto fijo** | Instrucciones y datos chicos van en el prompt, sin caché que importe | El conocimiento entra con holgura, es corto y cambia con el código (los 12 enunciados de N6) | Crece hasta que el costo o la latencia de reenviarlo pesa | N6 P3; mínimos de caché [G10][G11][G12] **(umbral: criterio propio)** |
| **1. Contexto completo con prefijo cacheado** (CAG «de servicio») | El corpus entero va como prefijo **estable**; el servidor reutiliza su cálculo | El corpus entra en la ventana **efectiva**, cambia poco, y hay muchas consultas seguidas sobre el mismo corpus | El corpus excede la ventana efectiva; cambia más rápido de lo que dura la caché; cada usuario ve un subconjunto distinto | [G1 Limitations]; [G17][G18]; vida de caché [G10][G11][G12] |
| **1b. CAG del paper** | Caché KV persistida y recargada | Se controla el motor de inferencia en proceso | Se consume el modelo por API (el caso de esta guía) | [G1 §2], [G2] |
| **2. RAG** | Se recupera sólo lo relevante por consulta | Corpus mayor que la ventana efectiva, cambios frecuentes, permisos por documento, necesidad de citar el fragmento | La pregunta es un dato exacto (va por herramienta, N6 P2) o necesita varios saltos que una búsqueda no resuelve | N3; [G21] (costo); N6 P2 |
| **3. RAG agéntico** | La recuperación es una herramienta y el modelo decide cuándo y qué buscar, en varias fuentes | Preguntas de varios pasos, varias fuentes, recuperación condicional | Una búsqueda fija alcanza: el agente agrega costo y no determinismo | N3 §1.2 → N4; Self-Route como ruteo entre LC y RAG [G21] |

Los criterios de elección, y de dónde sale cada uno:

| Criterio | Qué dice la fuente | Cómo se usa en la escalera |
| --- | --- | --- |
| **Tamaño del corpus vs ventana efectiva** | CAG es «impractical for significantly larger datasets» [G1]; la ventana efectiva es menor que la declarada [G17][G18] | Escalón 1 sólo si el corpus entra en la ventana **efectiva medida**, con margen para la pregunta y la respuesta |
| **Frecuencia de cambio** | Prefijo idéntico o fallo de caché [G11]; vida de minutos [G10][G11][G12]; bases «dynamic» como problema abierto [G20] | Si el corpus cambia entre consultas, la caché no acierta y el escalón 1 se vuelve «contexto largo sin caché», el peor caso de [G1 Tabla 3] **(criterio propio)** |
| **Latencia** | Tabla 3 de [G1]; [X3]/[X4] | Contra contexto sin caché, la caché gana siempre; contra BM25 top-3, no; contra RAG denso, depende de k y del tamaño (L2) |
| **Costo** | Lecturas de caché a ×0,1 o menos según el modelo (Anthropic) o con descuento de hasta 95 % (OpenAI); escritura ×1,25 o ×2 (Anthropic) y ×1,25 o ×2,5 (OpenAI GPT-5.6+) [G10][G12]; «RAG's significantly lower cost» [G21] | Con caché, reenviar el corpus cuesta menos, pero no cero: RAG sigue mandando menos tokens **(criterio propio sobre [G12][G21])** |
| **Aislamiento de datos** (CTX-SENS) | Azure: «The system doesn't share prompt caches between Azure subscriptions» [G11] | Si cada usuario ve documentos distintos, un prefijo común no existe; el filtro por permisos es de RAG (N3 G4; la fuga entre contextos es N3 G6) **(criterio propio)** |

### 3.4 Dónde vive cada pieza en las capas

**(criterio propio, sobre N1 y [G5][G14])**

- **Domain**: nada.
- **Application**: el caso de uso arma el contexto, y es el único lugar donde se decide el **orden** del prompt: primero lo estable (instrucciones, corpus), al final lo variable (pregunta, historia). Ese orden es el único control que la app tiene sobre la caché de prefijo.
- **Infrastructure**: el adaptador (`IChatClient` concreto) y, si el proveedor lo pide, la opción propia vía `RawRepresentationFactory` (por ejemplo `PromptCacheKey` en `CreateResponseOptions` de OpenAI 2.14.0 [X1]). La caché de respuestas (`UseDistributedCache`) también vive acá, en el pipeline.
- **Servidor del modelo**: la caché KV. Ni la app ni M.E.AI la ven; sólo ven su efecto en `Usage`.

### 3.5 Soporte en .NET (versión 10.11.0)

| Pregunta | Respuesta | Evidencia |
| --- | --- | --- |
| ¿`ChatOptions` tiene algo para *prompt caching*? | **No.** Sus propiedades públicas son 20 (`AdditionalProperties`, `ConversationId`, `Instructions`, `RawRepresentationFactory`, `Reasoning`, `Tools`, etc.) y ninguna es de caché | [X1] |
| ¿Dónde se ven los tokens cacheados? | `UsageDetails.CachedInputTokenCount` (`long?`). Doc: «Gets or sets the number of input tokens that were read from a cache»; observación: «Cached input tokens should be counted as part of InputTokenCount» | [X1]; [G6]; fuente en el commit del paquete [G4 l. 26–33] |
| ¿El adaptador de OpenAI lo llena? | Sí, en Chat Completions (`CachedInputTokenCount = tokenUsage.InputTokenDetails?.CachedTokenCount`) y en Responses | [G7 l. 727]; [G7b l. 1651] |
| ¿Se puede pasar `prompt_cache_key`? | En OpenAI 2.14.0, `CreateResponseOptions` tiene `PromptCacheKey` y `PromptCacheRetentionPolicy`; `ChatCompletionOptions`, no. Se pasa devolviendo un `CreateResponseOptions` desde `RawRepresentationFactory`, que `OpenAIResponsesChatClient` acepta (l. 975). **No se ejecutó contra OpenAI** | [X1]; [G7b l. 975]; [G8] |
| ¿Y con Anthropic? | `cache_control` es un campo por bloque o del request [G12]; M.E.AI no tiene una propiedad para eso. Depende del adaptador del SDK de Anthropic **(no verificado)** | — |
| ¿OllamaSharp informa los tokens cacheados? | **No.** `ParseOllamaChatResponseUsage` sólo llena `InputTokenCount`, `OutputTokenCount` y `TotalTokenCount`; las duraciones (`load_duration`, `prompt_eval_duration`, …) van a `AdditionalProperties` | [G9] (commit `135abcc` = 5.5.0, [X1]) |
| ¿`UseDistributedCache` sirve para CAG? | No: guarda respuestas. Una pregunta nueva sobre el mismo corpus es un fallo de esa caché | [G5]; N5 §2.9 |

Snippet para la guía, en tres partes: prefijo estable, pregunta al final y lectura del uso. **Compila contra 10.11.0 sólo como forma** (los tipos se verificaron por reflexión en [X1]; el snippet entero no se compiló):

```csharp
// Application: el corpus va primero y no cambia entre consultas; la pregunta va al final.
// Cualquier byte distinto en el prefijo (una fecha, un id de sesión) anula la caché del servidor.
var mensajes = new List<ChatMessage>
{
    new(ChatRole.System, instrucciones + "\n\n" + corpus),   // prefijo estable
    new(ChatRole.User, pregunta)                             // sufijo variable
};
ChatResponse r = await chat.GetResponseAsync(mensajes, new ChatOptions { Temperature = 0 });

// Observabilidad: sólo algunos adaptadores lo informan (OpenAI sí; OllamaSharp 5.5.0, no).
long? cacheados = r.Usage?.CachedInputTokenCount;
```

### 3.6 Lo que hace Ollama, medido

Ver [X2]–[X4] en §8. Resumen para el jurado:

- **Estado del servidor** [X2]: Ollama 0.32.0-rc0 (la última estable publicada es v0.40.11, del 2026-10-24 [G14b]). `qwen3.5:4b` cargado con `context_length` 65.536, `size_vram` 0 (todo en CPU). `qwen3.5` es híbrido: capas de atención lineal (que el GGUF expone como `ssm.*`) y una capa de atención completa cada 4 (coincide con `layer_types` y `full_attention_interval` 4 del `config.json` de Qwen/Qwen3.5-4B en Hugging Face).
- **Primera corrida** [X3], con `qwen3.5:4b` y un prefijo de 4.441 tokens: el procesamiento del prompt tardó 474,7 s en frío (unos 9,4 tokens/s). Entre esa petición y la siguiente el modelo **se recargó** (`load_duration` 38,85 s): otra carga del servidor compartido lo descargó, y la segunda petición volvió a procesar todo el prefijo (395,9 s). La repetición exacta tardó 182,3 s: menos, pero lejos de un acierto completo. El campo `prompt_eval_cached_count` **no aparece** en las respuestas (el registro crudo `run1.jsonl` no guarda las claves ausentes, así que esto descansa en la nota del investigador y en que la misma versión en local no lo devuelve [X4b]; **no verificado** en el servidor de la LAN).
- **Intento con `qwen2.5:7b-instruct` en la LAN** [X4a]: la primera petición no respondió en 900 s porque el servidor estaba ocupado por otro cliente.
- **Corrida controlada** [X4b], en un Ollama propio en contenedor **de la misma versión** (0.32.0-rc0), con `qwen2.5:0.5b`:
  - con el mismo prefijo de ~4.700 tokens, el prompt pasó de 102,7 s en frío a 1,1 s con otra pregunta, y el log de `llama-server` dice `cached n_tokens = 4703`;
  - un carácter cambiado al principio lo devolvió a 91,6 s;
  - sin `num_ctx`, el default de 4096 **recortó el prompt a 2.050 tokens sin error en la API**: se perdió el principio del corpus y la respuesta salió del último artículo.

### 3.7 Ejemplo comparativo CAG vs RAG sobre Movilidad Urbana (propuesta, sin construir)

**Corpus.** El corpus real (12 enunciados de `*Policy`, N6 §1.1) es demasiado chico: queda por debajo del mínimo de caché de todos los proveedores [G10][G11][G12], y entonces el ejemplo mostraría el escalón 0, no CAG. La propuesta es un **«reglamento de ejemplo» sintético**, generado por código con semilla fija y rotulado en el propio texto como «escrito para la demo» (N6 §1.1 punto 2 ya exige ese rótulo). La forma es la de [X3]/[X4]: artículos numerados, cada uno con provincia, medio, motivo, distancia, tiempo y código postal, valores que aparecen en `Catalogos` del caso base.

**Diseño** **(criterio propio)**:

| Variante | Qué se mide | Cómo |
| --- | --- | --- |
| A. Contexto completo, una consulta por vez sin repetir prefijo | Peor caso: contexto sin caché | Reiniciar o cambiar el primer carácter del prefijo |
| B. Contexto completo con prefijo estable | CAG «de servicio» | Misma petición de sistema; N preguntas distintas seguidas |
| C. RAG top-k | Recuperación + generación | MEVD InMemory + `qwen3-embedding:0.6b` (N3 E3) sobre los artículos como fragmentos |
| Métricas | `prompt_eval_count`, `prompt_eval_duration`, tiempo total; aciertos exactos sobre preguntas con respuesta única (código postal del artículo *n*) | R-LLM: modelo, digest, opciones, entrada y salida |

**Viabilidad con el contexto efectivo medido** [X2][X3][X4]:

- **Ventana**: entra. 4.441 tokens con 70 artículos; el servidor tiene 65.536 configurados.
- **Tiempo**: es el límite real. A ~9 tokens/s de procesamiento de prompt en CPU, cada consulta en frío con 4.400 tokens cuesta del orden de 8 minutos [X3]. Una corrida de 8 preguntas × 3 variantes se va a horas y es sensible a las otras cargas del servidor (§3.6).
- **Mecanismo**: se ve con claridad en un Ollama propio en contenedor: 102,7 s → 1,1 s [X4b]. Un modelo de 0,5B alcanza para mostrar los tiempos, pero no la calidad, porque respondió mal [X4b punto 6].
- **Veredicto**: **viable como ejemplo de `Examples/`** con dos condiciones:
  - fijar `num_ctx` de forma explícita, porque sin él el corpus se trunca en silencio [X4b punto 4];
  - correrlo en un Ollama propio en contenedor, como hizo N3 con los embeddings (N3 E3), o en el servidor de la LAN sólo cuando no tenga otras cargas.
  
  Para comparar **calidad** hace falta un modelo de 7B o más, y en el servidor de la LAN eso cuesta minutos por consulta en frío [X3][X4a]. **No es viable** como parte de la demo interactiva en ese servidor tal como está hoy.

---

## 4. Preguntas guía con respuesta explicativa

**P1. Si mi corpus entra en la ventana, ¿tengo que hacer RAG igual?**
No necesariamente. El paper de CAG muestra que, con un corpus que entra en el contexto, precargarlo da respuestas comparables o mejores que RAG en la mayoría de sus casos [G1 Tabla 2], y RAG agrega componentes que hay que mantener [G1 §1]. Pero «entra» tiene que medirse contra la ventana **efectiva**, no la declarada: la mitad de los modelos que RULER evaluó no rinden bien a 32K aunque declaren más [G17]. Y hay que mirar las otras variables: si el corpus cambia todo el tiempo, si cada usuario ve documentos distintos o si se necesita citar el fragmento exacto, RAG sigue siendo la opción **(criterio propio)**.

**P2. ¿CAG es lo mismo que `UseDistributedCache`?**
No, y confundirlos lleva a diseños que no funcionan. `DistributedCachingChatClient` guarda la **respuesta** y sólo acierta si llega la misma conversación con las mismas opciones [G5]; N5 midió que con otra temperatura no acierta (N5 E2). CAG y el *prompt caching* guardan el **cálculo del corpus** en el servidor del modelo y aciertan con preguntas distintas sobre el mismo prefijo [G1][G11]. Se pueden combinar: la caché de respuestas evita llamar al modelo para preguntas repetidas y la de prefijo abarata las nuevas.

**P3. Uso OpenAI o Azure OpenAI desde .NET. ¿Qué tengo que activar?**
Nada: es automático en los modelos soportados [G10][G11]. Lo que sí hay que hacer es **diseñar el prompt** para que el prefijo coincida: lo estable al principio, lo variable al final, sin marcas de tiempo ni ids en el mensaje de sistema [G11, *Best practices*]. Para verificar que funciona, se lee `UsageDetails.CachedInputTokenCount`, que el adaptador de M.E.AI llena desde `cached_tokens` [G7]. Si el prompt tiene menos de 1.024 tokens, no hay caché posible [G11].

**P4. ¿Por qué no puedo hacer CAG «de verdad», como en el paper, desde mi app?**
Porque el paper guarda la caché KV en disco y la vuelve a cargar [G1 §2], y para eso hay que tener el modelo en proceso, como hace el código de los autores con `transformers` [G2]. Una app que consume el modelo por API (`IChatClient` contra Ollama, OpenAI o Azure) no ve ni toca esa caché. Lo que obtiene es la versión del servidor: una caché efímera, de minutos (u horas con retención extendida) [G10][G11][G12], que el servidor puede descartar cuando quiera. En el servidor de la LAN se vio: una recarga del modelo borró la caché entre dos peticiones [X3].

**P5. En Ollama, ¿qué cuida la caché del prefijo y qué la rompe?**
Ollama 0.32 delega en `llama-server` con `cache_prompt` activado [G14], y llama.cpp reutiliza el prefijo común con la petición anterior del mismo slot [G15]. La rompen tres cosas: que el modelo se descargue por `keep_alive` (5 minutos por defecto [G13]); que otra petición con un `num_ctx` distinto lo recargue; y que otra petición con otro prefijo use el mismo slot, porque con `OLLAMA_NUM_PARALLEL`=1 hay uno solo [G13]. En un servidor compartido, la tercera es la más probable **(criterio propio, consistente con [X3])**. Medido en local, el efecto es enorme: 102,7 s → 1,1 s con el mismo prefijo, y de vuelta a 91,6 s con un carácter cambiado al principio [X4b]. Y hay una cuarta trampa que no rompe la caché sino el corpus: si no se fija `num_ctx`, el default de 4096 recorta el prompt **sin error** y se pierde el principio [X4b]. Ollama no documenta esta caché en su FAQ [G13]: es un comportamiento del motor, no un contrato.

**P6. Los 12 requisitos de Movilidad Urbana, ¿van por CAG o por RAG?**
Por ninguno de los dos: por contexto fijo. Con la instrucción y una pregunta suman unos 250–265 tokens [X4b], menos que el mínimo cacheable de cualquier proveedor [G10][G11][G12], así que en la nube no hay caché para aprovechar, y en local reprocesarlos cuesta poco. N6 ya lo dijo para RAG (P3: «el corpus cabe entero en el prompt»). CAG empieza a importar cuando el corpus es bastante más grande que la pregunta y se consulta muchas veces seguidas **(criterio propio)**.

**P7. ¿Más ventana es mejor para hacer CAG?**
No por sí sola. Más ventana consume más memoria (`OLLAMA_NUM_PARALLEL` × contexto [G13]) y no garantiza que el modelo use bien lo que está en el medio (N5 F22; [G17][G18]). En el paper, la ventaja de CAG se achica al crecer el corpus [G1 §3.3], y en HotPotQA-Large ya gana BM25 [G1 Tabla 2]. Además, en CPU el costo de la primera pasada crece con cada token: en el servidor de la LAN, unos 9 tokens por segundo [X3].

---

## 5. Criterios de calidad y antipatrones

### 5.1 Criterios de calidad (para revisar la sección de la guía)

1. La guía define CAG **con la cita del paper** y aclara que lo que una app .NET puede usar es la reutilización de prefijo del servidor [G1][G14][G10].
2. Distingue las cuatro filas de §2.5 con una tabla y un ejemplo de qué acierta y qué no.
3. Todo número de proveedor (mínimo de tokens, vida, descuento) lleva fecha de consulta: cambian por modelo y por familia [G10][G11][G12].
4. El criterio de la escalera nombra la ventana **efectiva**, no la declarada [G1 §1][G17].
5. Toda medición de tiempo contra Ollama declara modelo, digest, `num_ctx`, `keep_alive`, si el modelo estaba cargado, y si el servidor era compartido (R-LLM; [X3]).
6. El ejemplo comparativo usa un corpus sintético **rotulado** y no presenta los tiempos de CPU como representativos de una GPU **(criterio propio)**.
7. La guía no repite el título del paper como conclusión: presenta sus límites (L1–L5).
8. Todo ejemplo con Ollama fija `num_ctx` explícitamente y verifica con `ollama ps` que el corpus entra; si no, el truncado es silencioso [X4b].

### 5.2 Antipatrones

| Antipatrón | Qué falla | Fuente |
| --- | --- | --- |
| Poner la fecha, el usuario o un id de sesión al principio del mensaje de sistema | Cada petición tiene un prefijo distinto y la caché nunca acierta | [G11] («A single character difference…») |
| Llamar «CAG» a `UseDistributedCache` | Sólo acierta con la misma conversación; preguntas nuevas pagan el corpus entero | [G5]; N5 §2.9 |
| Elegir CAG porque «el modelo tiene 128K» | La ventana efectiva es menor y la calidad cae con el largo | [G1 §1]; [G17][G18] |
| CAG con documentos de distintos usuarios en un solo prefijo | Fuga de datos entre usuarios; el modelo ve lo que el usuario no debería | N3 G6 **(criterio propio)** |
| Medir en un servidor compartido sin registrar `load_duration` | Una recarga ajena se confunde con un fallo de caché | [X3] |
| Mandar un corpus grande a Ollama sin fijar `num_ctx` | El default de 4096 lo trunca sin error y conserva la cola: se pierden las instrucciones y el principio del corpus | [X4b]; [G14 l. 276–316] |
| Usar `prompt_eval_count` para saber si hubo acierto de caché | Informa el total del prompt aunque se haya reutilizado; el indicador es `prompt_eval_duration` | [X4b]; [G16] |
| Contar con `prompt_eval_cached_count` en cualquier Ollama | El servidor de la LAN (0.32.0-rc0) no lo devuelve | [X3]; [G16] |
| Esperar `CachedInputTokenCount` con OllamaSharp | El adaptador no lo llena | [G9] |
| Reconstruir el corpus en cada request desde una base que cambia el orden de las filas | Mismo contenido, otro prefijo: fallo de caché | [G11] **(criterio propio sobre la regla de prefijo idéntico)** |

---

## 6. Recomendación para el jurado

**Sobre PR-8 en conjunto: aplicar con mejoras.** La escalera tiene respaldo y ordena bien el material de N3. CAG entra, pero con su definición exacta y su límite: en esta guía se enseña la **versión de servicio** (prefijo estable + caché del servidor) y el paper como fundamento, no como receta.

| Pieza | Veredicto propuesto | Dónde | Motivo |
| --- | --- | --- | --- |
| Escalera de estrategias (0 → 1 → 2 → 3) con criterio de elección | **Entra** | Apertura de la sección de conocimiento (antes de N3, como §N3.0 o como primera subsección); referencias desde N4 (escalón 3) | Ordena el material y tiene fuente para cada criterio (§3.3); la regla de N6 P2 (dato exacto → herramienta) queda como carril aparte |
| Definición de CAG con cita literal, mecanismo de tres fases y límites del paper | **Entra** | Escalón 1 | E2 completo en §2.2 y §3.1 |
| Lectura crítica L1–L3 (Tablas 2 y 3) | **Entra, breve** | Escalón 1, como «lo que el paper no dice» | E3 con números; forma criterio sin depender de un título provocador |
| Tabla de las cuatro cachés (§2.5) | **Entra** | Escalón 1, con referencia cruzada a N5 §2.9 | La pide I-03 §4 y evita la confusión más probable |
| Tabla de *prompt caching* por proveedor | **Entra, reducida** a cómo se activa, mínimo y dónde se ve; con fecha | Escalón 1, «Aplicación por escenario: CTX-NUBE» | Los números cambian por modelo; la guía da el criterio y la fecha, no un catálogo |
| Soporte .NET: `CachedInputTokenCount`, `RawRepresentationFactory`, OllamaSharp sin conteo | **Entra** | Escalón 1 + N5 (observabilidad) | E1/E2 verificados contra 10.11.0 |
| Comportamiento de Ollama (`cache_prompt`, slot, `keep_alive`) | **Entra como «comportamiento del motor, no contrato»** | Escalón 1, «Aplicación por escenario: CTX-LOCAL» | Sale del código ([G14]), no de la documentación de Ollama |
| Ejemplo comparativo CAG vs RAG | **Entra a `Examples/`, no a la demo** | `Examples/` nivel intermedio | Viable sólo chico y en servidor sin carga o Ollama propio (§3.7, §8) |
| CAG del paper (caché KV persistida, `transformers`) | **Queda fuera** | Se menciona en una línea | Requiere el modelo en proceso y Python; fuera del stack .NET de la guía (DC-07) |
| Variantes de investigación (Cartridges, TurboRAG, Cache-Craft, ACC) | **Quedan fuera**; a lo sumo una nota de «para seguir» | Anexo de lecturas | Son técnicas de servidor de inferencia, no de la capa de aplicación |
| Cifras de calidad de proveedores sobre caché | **Quedan fuera** | — | La caché no cambia la salida («has no impact on the output content» [G11]); no hay nada que medir en calidad |

---

## 7. Tabla de fuentes

| Id | URL / ubicación | Qué respalda | Consulta |
| --- | --- | --- | --- |
| G1 | https://arxiv.org/abs/2412.15605 (v2, PDF https://arxiv.org/pdf/2412.15605). Chan, Chen, Cheng, Huang. DOI 10.1145/3701716.3715490 | Definición, fases, ecuaciones (1)–(2), Tablas 1–3, *Limitations*, conclusión híbrida | 2026-10-26 |
| G2 | https://github.com/hhhuang/CAG (README y `kvcache.py`, rama `main`; licencia MIT; último push 2025-05-26) | Implementación con `DynamicCache`, `torch.save`, recorte; límites en el README | 2026-10-26 |
| G3 | https://export.arxiv.org/api/query?id_list=… (ids de G17–G24 y G1) | Títulos, fechas y abstracts de los trabajos relacionados | 2026-10-26 |
| G4 | https://github.com/dotnet/extensions/blob/25f07afa51034e37b334210642d7dc5f191c142d/src/Libraries/Microsoft.Extensions.AI.Abstractions/UsageDetails.cs | `CachedInputTokenCount` y su observación (l. 26–33); suma en `Add` (l. 125). El commit es el que lleva el paquete 10.11.0 ([X1]) | 2026-10-26 |
| G5 | https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.ai.distributedcachingchatclient (act. 2026-10-16) | «caches the results of response calls, storing them as JSON in an IDistributedCache»; `CacheKeyAdditionalValues`; fidelidad no garantizada | 2026-10-26 |
| G6 | https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.ai.usagedetails.cachedinputtokencount (act. 2026-10-16) | Resumen y observación de la propiedad | 2026-10-26 |
| G7 | https://github.com/dotnet/extensions/blob/25f07afa51034e37b334210642d7dc5f191c142d/src/Libraries/Microsoft.Extensions.AI.OpenAI/OpenAIChatClient.cs | Mapeo de `CachedTokenCount` (l. 727); `RawRepresentationFactory` → `ChatCompletionOptions` (l. 608) | 2026-10-26 |
| G7b | …/Microsoft.Extensions.AI.OpenAI/OpenAIResponsesChatClient.cs (mismo commit) | Mapeo en Responses (l. 1651); `RawRepresentationFactory` → `CreateResponseOptions` (l. 975) | 2026-10-26 |
| G8 | …/Microsoft.Extensions.AI.Abstractions/ChatCompletion/ChatOptions.cs (mismo commit), comentario de `RawRepresentationFactory` | «typically used to set an implementation-specific setting that isn't otherwise exposed» | 2026-10-26 |
| G9 | https://github.com/awaescher/OllamaSharp/blob/135abcc3e31ac6a1ec535ff4c891e11ed1328df4/src/OllamaSharp/MicrosoftAi/AbstractionMapper.cs | `ParseOllamaChatResponseUsage` sin tokens cacheados; duraciones a `AdditionalProperties` (l. 423–426) | 2026-10-26 |
| G10 | https://developers.openai.com/api/docs/guides/prompt-caching (redirigida desde platform.openai.com) | Activación por defecto, mínimo, vida, `cached_tokens`, descuento, `prompt_cache_key` | 2026-10-26 |
| G11 | https://learn.microsoft.com/en-us/azure/foundry/openai/how-to/prompt-caching (ms.date 2026-08-11) | Mínimo 1.024, primeros 1.024 idénticos, activación por defecto, vida, `cached_tokens`, breakpoints en GPT-5.6+, no se comparte entre suscripciones, *best practices* | 2026-10-26 |
| G12 | https://platform.claude.com/docs/en/build-with-claude/prompt-caching | `cache_control` explícito o automático, mínimos por modelo, TTL 5 min / 1 h, campos de uso, multiplicadores, orden del prefijo, 4 breakpoints | 2026-10-26 |
| G13 | https://docs.ollama.com/faq | 4096 por defecto, `OLLAMA_CONTEXT_LENGTH`, `num_ctx`, `keep_alive` 5 min, `OLLAMA_KV_CACHE_TYPE`, `OLLAMA_NUM_PARALLEL`=1, RAM ∝ paralelo × contexto; sin mención de caché de prefijo. También https://docs.ollama.com/context-length (por VRAM) | 2026-10-26 |
| G14 | https://github.com/ollama/ollama/blob/v0.32.0-rc0/llm/llama_server.go | `"cache_prompt": true` (l. 2104); `-c` = `NumCtx × numParallel`, `-np` (l. 372–373); truncado con context shift o error 400 (l. 276–316) | 2026-10-26 |
| G14b | https://api.github.com/repos/ollama/ollama/releases/latest | Última versión publicada: v0.40.11 (2026-10-24) | 2026-10-26 |
| G15 | https://github.com/ggml-org/llama.cpp/blob/master/tools/server/README.md | `cache_prompt` (default `true`, puede volver no determinista la salida), `--cache-reuse`, `--ctx-checkpoints` (32), `--checkpoint-min-step` (8192) | 2026-10-26 (rama `master`, no la versión que trae Ollama 0.32) |
| G16 | https://docs.ollama.com/api/chat | `prompt_eval_duration` = tokens no cacheados; `prompt_eval_cached_count`; `keep_alive`; `num_ctx`; `think` | 2026-10-26 |
| G17 | https://arxiv.org/abs/2404.06654 (RULER, Hsieh et al.) | Ventana efectiva menor que la declarada | 2026-10-26 |
| G18 | https://arxiv.org/abs/2411.03538 (Leng et al.) | Pocos modelos sostienen precisión arriba de 64k | 2026-10-26 |
| G19 | https://arxiv.org/abs/2506.06266 (Cartridges, Eyuboglu et al.) | Memoria de la caché KV ∝ largo; caché entrenada por corpus | 2026-10-26 |
| G20 | https://arxiv.org/abs/2505.08261 (ACC + híbrido CAG-RAG) | Bases grandes y dinámicas como problema abierto de CAG | 2026-10-26 |
| G21 | https://arxiv.org/abs/2407.16833 (Li et al., EMNLP 2024 Industry, Self-Route) | LC supera a RAG con recursos suficientes; RAG más barato; ruteo | 2026-10-26 |
| G22 | https://arxiv.org/abs/2503.14647 | Economía de guardar y reutilizar cachés KV | 2026-10-26 |
| G23 | https://arxiv.org/abs/2410.07590 (TurboRAG) | Caché KV precalculada por fragmento | 2026-10-26 |
| G24 | https://arxiv.org/abs/2502.15734 (Cache-Craft) | Gestión de cachés de fragmentos en RAG | 2026-10-26 |

---

## 8. Evidencia ejecutada

Intermedios en `{dir-de-trabajo}/n3b/` (fuera del repo). El endpoint real no se escribe: en los comandos figura `$OLLAMA_ENDPOINT`.

### X1 — Reflexión sobre M.E.AI 10.11.0, OpenAI 2.14.0 y OllamaSharp 5.5.0 (E1)

```text
$ docker run --rm -v <refl>:/w -v <volumen-nuget>:/root/.nuget -w /w mcr.microsoft.com/dotnet/sdk:10.0 dotnet run
== Microsoft.Extensions.AI.UsageDetails (Microsoft.Extensions.AI.Abstractions 10.11.0+25f07afa51034e37b334210642d7dc5f191c142d)
   AdditionalPropertiesDictionary`1 AdditionalCounts
   Nullable`1 CachedInputTokenCount
   Nullable`1 InputAudioTokenCount
   Nullable`1 InputTextTokenCount
   Nullable`1 InputTokenCount
   Nullable`1 OutputAudioTokenCount
   Nullable`1 OutputTextTokenCount
   Nullable`1 OutputTokenCount
   Nullable`1 ReasoningTokenCount
   Nullable`1 TotalTokenCount
== Microsoft.Extensions.AI.ChatOptions (…10.11.0…)
   AdditionalProperties, AllowBackgroundResponses, AllowMultipleToolCalls, ContinuationToken, ConversationId,
   FrequencyPenalty, Instructions, MaxOutputTokens, ModelId, PresencePenalty, RawRepresentationFactory, Reasoning,
   ResponseFormat, Seed, StopSequences, Temperature, ToolMode, Tools, TopK, TopP      (20; ninguna de caché)
[cache-type] Microsoft.Extensions.AI: CachingChatClient, DistributedCachingChatClient, DistributedCachingChatClientBuilderExtensions,
             CachingEmbeddingGenerator`2, DistributedCachingEmbeddingGenerator`2, DistributedCachingEmbeddingGeneratorBuilderExtensions
== OllamaSharp.Models.Chat.ChatDoneResponseStream (OllamaSharp 5.5.0+135abcc3e31ac6a1ec535ff4c891e11ed1328df4)
   … EvalCount, EvalDuration, LoadDuration, PromptEvalCount, PromptEvalDuration, TotalDuration   (sin campo de cacheados)
== OpenAI.Chat.ChatCompletionOptions (OpenAI 2.14.0+2e77b088…)          (ninguna propiedad con «Cache»)
== OpenAI.Responses.CreateResponseOptions (OpenAI 2.14.0+2e77b088…)
   String PromptCacheKey
   Nullable`1 PromptCacheRetentionPolicy
== OpenAI.Chat.ChatInputTokenUsageDetails: Int32 AudioTokenCount, Int32 CachedTokenCount
```

### X2 — Estado del servidor Ollama de la LAN del laboratorio (E1)

```text
$ curl -s $OLLAMA_ENDPOINT/api/version            → {"version":"0.32.0-rc0"}
$ curl -s $OLLAMA_ENDPOINT/api/ps                 → qwen3.5:4b  digest 2a654d98e6fb…  context_length 65536  size_vram 0
$ curl -s $OLLAMA_ENDPOINT/api/show -d '{"model":"qwen3.5:4b"}'
  general.architecture qwen35 · qwen35.context_length 262144 · qwen35.block_count 32
  qwen35.full_attention_interval 4 · qwen35.ssm.state_size 128 · qwen35.ssm.inner_size 4096 · qwen35.ssm.conv_kernel 4
$ curl -s $OLLAMA_ENDPOINT/api/tags (extracto)   → qwen2.5:7b-instruct 845dbda0ea48 7.6B Q4_K_M · qwen3.5:4b 2a654d98e6fb 4.7B Q4_K_M
```

### X3 — Caché de prefijo con `qwen3.5:4b`, servidor compartido (E1, contaminada)

- **Corpus**: «REGLAMENTO DE EJEMPLO (sintético, escrito para la prueba)», 70 artículos generados con `random.seed(7)` (16.748 bytes). Script `e1/corpus.py`.
- **Petición**: `POST /api/chat`, `stream:false`, `think:false`, `keep_alive:"30m"`, `options:{temperature:0, num_predict:24, seed:1}`, sin `num_ctx` (usa el del modelo cargado, 65.536). Sistema = «Respondé sólo con lo que dice el reglamento.\n» + corpus. Usuario = Q1 «¿Qué código postal usa la localidad de referencia del Artículo 7? Respondé sólo el número.» o Q2 «¿En qué provincia aplica el Artículo 12? Respondé sólo la provincia.» Valores esperados: 3961 y Santa Fe.
- **Fecha**: 2026-10-26, 07:25–07:46 (-03).

```text
$ MODEL=qwen3.5:4b OLLAMA_ENDPOINT=$OLLAMA_ENDPOINT python3 medir.py corpus70.txt A,B,C,D
{"tag": "A frío: corpus+Q1",                "wall_s": 480.8, "load_s": 1.16,  "prompt_eval_count": 4441, "prompt_eval_s": 474.71, "eval_count": 5, "answer": "3961"}
{"tag": "B mismo corpus, otra pregunta Q2", "wall_s": 435.2, "load_s": 38.85, "prompt_eval_count": 4438, "prompt_eval_s": 395.86, "eval_count": 3, "answer": "Santa Fe"}
{"tag": "C repetición exacta de A",         "wall_s": 183.9, "load_s": 0.56,  "prompt_eval_count": 4441, "prompt_eval_s": 182.32, "eval_count": 5, "answer": "3961"}
(D cancelada por el investigador; la respuesta JSON no trae prompt_eval_cached_count)
```

**Lectura**: las respuestas son correctas (2/2 valores exactos). El `load_duration` de 38,85 s en B muestra que el modelo se recargó entre A y B; la caché se perdió y B reprocesó el prefijo completo. C bajó a 182 s, lo que es compatible con una reutilización **parcial** o con menos carga en el servidor: con estos datos no se puede separar **(no concluyente)**. `prompt_eval_count` informa el total del prompt aun cuando hubo reutilización, así que no sirve para detectar aciertos en esta versión. Por ser `qwen3.5` un modelo híbrido con capas SSM, la reutilización de prefijos en llama.cpp depende de *checkpoints* de contexto [G15]; que eso explique C es una **hipótesis no verificada**.

### X4 — Caché de prefijo, controlada (E1)

**X4a. Intento en el servidor de la LAN con `qwen2.5:7b-instruct` (845dbda0ea48)**, corpus de 25 artículos (6.012 bytes), 2026-10-26 07:47–08:02. La primera petición **no llegó a responder en 900 s** (`TimeoutError: timed out`). `/api/ps` mostraba, durante la espera, sólo `qwen3.5:4b` cargado con su vencimiento renovado por otro cliente: el servidor estaba ocupado y el modelo pedido nunca se cargó. Se abandonó la medición en ese servidor para no competir con las otras cargas.

**X4b. Ollama propio en contenedor, misma versión que el servidor de la LAN** (`ollama/ollama:0.32.0-rc0`, CPU de 8 núcleos, sin GPU), modelo `qwen2.5:0.5b` (a8b0c5157701, 397 MB, transformer puro). Mismo corpus de 70 artículos y mismas peticiones que X3. Contenedor y volumen se borraron al terminar.

```text
$ docker run -d --name <ollama-n3b> -v <ollama-n3b>:/root/.ollama -p 127.0.0.1:<puerto>:11434 ollama/ollama:0.32.0-rc0
$ docker exec <ollama-n3b> ollama pull qwen2.5:0.5b

# 1) Sin num_ctx: el servidor usa su default
$ MODEL=qwen2.5:0.5b python3 medir.py corpus70.txt N
{"tag": "N sin num_ctx (default del servidor)", "wall_s": 53.2, "prompt_eval_count": 2050, "prompt_eval_s": 50.34, "answer": "8983"}
$ docker exec <ollama-n3b> ollama ps          → qwen2.5:0.5b  100% CPU  CONTEXT 4096
$ docker logs <ollama-n3b> | grep truncat
level=WARN source=llama_server.go:314 msg="truncating input prompt" limit=2050 prompt=4728 keep=4 new=2050

# 2) Con num_ctx 8192
$ NUM_CTX=8192 MODEL=qwen2.5:0.5b python3 medir.py corpus70.txt A,B,C,D,G
{"tag": "A frío: corpus+Q1",                               "load_s": 2.52, "prompt_eval_count": 4728, "prompt_eval_s": 102.65, "answer": "1812"}
{"tag": "B mismo corpus, otra pregunta Q2",                "load_s": 0.36, "prompt_eval_count": 4725, "prompt_eval_s": 1.10,   "answer": "Santa Fe"}
{"tag": "C repetición exacta de A",                        "load_s": 0.40, "prompt_eval_count": 4728, "prompt_eval_s": 1.22,   "answer": "8983"}
{"tag": "D corpus con 1 carácter cambiado al inicio + Q1", "load_s": 0.40, "prompt_eval_count": 4728, "prompt_eval_s": 91.60,  "answer": "1003"}
{"tag": "G repetición de A después de D",                  "load_s": 0.32, "prompt_eval_count": 4728, "prompt_eval_s": 0.07,   "answer": "1003"}
(ninguna respuesta trae prompt_eval_cached_count)

$ docker logs <ollama-n3b>   (extracto de llama-server)
task 14 (C) | cached n_tokens = 4703 … prompt eval time = 1224.18 ms / 25 tokens
task 20 (D) | cached n_tokens = 3 … prompt eval time = 91597.34 ms / 4725 tokens (51.58 tokens per second)
srv update: - cache state: 1 prompts, 55.508 MiB (limits: 8192.000 MiB, 8192 tokens …)
task 30 (G) | cached n_tokens = 4727 … prompt eval time = 66.09 ms / 1 tokens
load_model: context checkpoints enabled, max = 32, min spacing = 8192

# 3) Tamaño del corpus real: los literales de *Policy de Lab-E2E.WebBlazor (commit 8fb4c3a, ApiWeb)
$ grep -ho '"[^"]*"' src/MovilidadUrbana.ApiWeb/Application/*/*Policy.cs > policy.txt     → 14 literales, 750 bytes
  /api/chat con sistema = instrucción + policy.txt y una pregunta → prompt_eval_count 253
```

**Lectura** (R-LLM: modelo y digest arriba; `temperature` 0, `seed` 1, `num_predict` 24, `think` false, `keep_alive` 30m):

1. **La caché de prefijo de Ollama funciona y es grande**: con el mismo prefijo de ~4.700 tokens, la segunda pregunta (B) procesó 22 tokens nuevos en 1,1 s, contra 102,7 s en frío: unas **93 veces menos** de tiempo de prompt. El log confirma la reutilización: `cached n_tokens = 4703`.
2. **Un carácter cambiado al principio la anula**: D reutilizó 3 tokens (la plantilla) y reprocesó todo en 91,6 s. Es la regla de prefijo idéntico de [G11], ahora medida en local.
3. **`prompt_eval_count` no sirve para detectar aciertos**: informa el total del prompt (4.725–4.728) también cuando se reutilizó. Lo que cambia es `prompt_eval_duration`, de acuerdo con su definición («uncached prompt tokens», [G16]). `prompt_eval_cached_count` no existe en esta versión.
4. **El default de 4096 trunca en silencio**: sin `num_ctx`, el prompt de 4.728 tokens se recortó a 2.050 (se conservan 4 tokens del principio y la cola, porque Ollama libera la mitad de la ventana para generar [G14 l. 318–328]). La API no devolvió error: sólo un `WARN` en el log del servidor. La respuesta salió del Artículo 70, el último. Con CAG esto es grave, porque **se pierde justo el principio del corpus y las instrucciones**. Es la versión medida del aviso de N5 §2.10.
5. **G volvió a acertar después de D** (0,07 s). Lo compatible con el log es la caché de prompts en RAM de `llama-server` («cache state: 1 prompts … limits: 8192.000 MiB», `--cache-ram` en [G15]), que guarda el estado anterior del slot y lo restaura. **El mecanismo exacto no está verificado** (§9).
6. **Calidad**: `qwen2.5:0.5b` respondió mal Q1 (esperado 3961) en todas las corridas, y dos peticiones idénticas (A y C) dieron respuestas distintas (1812 y 8983) con `temperature` 0. Lo primero es el tamaño del modelo. Lo segundo coincide con el aviso de llama.cpp: con `cache_prompt` los logits «are not guaranteed to be bit-for-bit identical» y el resultado puede ser no determinista [G15]. Las pruebas de la guía tienen que afirmar propiedades, no texto (R-LLM).
7. **El corpus real de Movilidad Urbana mide ~250 tokens** con el tokenizador de Qwen 2.5, contando la instrucción y la pregunta: por debajo de cualquier mínimo de *prompt caching* en la nube [G10][G11][G12].

---

## 9. Abierto / no verificado

1. **Réplica independiente del paper**: no encontré un trabajo que vuelva a correr los benchmarks de [G1] (§3.2).
2. **Comportamiento exacto de la caché en modelos híbridos** (`qwen3.5`) dentro de Ollama 0.32.0-rc0: los `--ctx-checkpoints` de [G15] son de la rama `master` de llama.cpp; no verifiqué qué versión de llama.cpp trae esa versión de Ollama ni si pasa esos parámetros (en [G14] no aparecen).
3. **Adaptador de Anthropic para M.E.AI**: no verifiqué cómo expone `cache_control` ni si llena `CachedInputTokenCount`.
4. **`PromptCacheKey` desde M.E.AI contra OpenAI real**: sólo verificado por reflexión y lectura del código; no se ejecutó.
5. **El snippet de §3.5** no se compiló como unidad (sí sus tipos, por reflexión).
6. **Origen del `context_length` 65.536 del servidor**: no sé si viene de `OLLAMA_CONTEXT_LENGTH` del servidor o de un `num_ctx` de otro cliente; con `size_vram` 0 la regla por VRAM de [G13] daría 4k. Es configuración del PO.
7. **Por qué G acertó después de D en [X4b]**: lo compatible con el log es la caché de prompts en RAM de `llama-server` (`--cache-ram`), pero el log muestra «1 prompts» en la caché y no explica del todo la restauración. Tampoco verifiqué si Ollama 0.32 deja ese valor en su default.
8. **No determinismo con caché**: dos peticiones idénticas con `temperature` 0 dieron respuestas distintas en [X4b]. Es compatible con el aviso de [G15], pero la muestra es de un solo par y con un modelo de 0,5B.
9. **Medición de CAG vs RAG con calidad** (aciertos sobre preguntas con respuesta única): no se corrió; §3.7 es una propuesta.
10. **Mínimo de caché de OpenAI para modelos anteriores a GPT-5.6**: la página dice que «varies by request settings» [G10]; no lo detallé por modelo.

---

## Verificación adversarial

Hecha el 2026-10-26 por el verificador adversarial de N3b. Cada fuente se volvió a bajar de forma independiente: el PDF de arXiv v2, los archivos en los commits citados, las páginas de los proveedores y la API de arXiv. X1 y X4b se re-ejecutaron con un programa y un script propios. Los intermedios están en `{dir-de-trabajo}/n3b-verif/`; el contenedor y el volumen se borraron al terminar. X2, X3 y X4a no se re-ejecutaron, para no cargar el servidor compartido de la LAN; se contrastaron contra los registros crudos de `n3b/e1/`. Revisión de privacidad: no hay IP privadas, hosts de la LAN ni credenciales; la única dirección escrita es `127.0.0.1` con un puerto genérico.

| Afirmación | Veredicto | Evidencia |
| --- | --- | --- |
| G1: título, 4 autores, v1 2024-12-20, v2 2025-02-23, comentario «5 pages, accepted by the Web Conference 2025…», DOI 10.1145/3701716.3715490 | Confirmada | Página abs, metadatos `citation_*`, pie de p. 1 del PDF |
| Definición literal (abstract), tres fases y ec. (1)–(2), «stored on disk or in memory», «append-only», Pope et al. = ref. [9] | Confirmada | PDF v2 §Abstract, §1, §2 |
| Llama 3.1 8B, «Tesla V100 32G × 8 GPUs», BERTScore, LlamaIndex BM25 / «OpenAI Indexes» top-1/3/5/10 | Confirmada | §3.1, §3.2 |
| Tabla 1: 16/32/64 docs (21k/43k/85k) y 3/4/7 docs (21k/32k/50k) | Confirmada | Tabla 1 |
| Tabla 2: los 12 valores de §3.1, incluido HotPotQA-Large BM25 top-5 0,7535 > CAG 0,7407 y top-3 0,7463 | Confirmada | Tabla 2 (`pdftotext -layout`: la primera columna es HotPotQA) |
| Tabla 3: los 18 valores citados (0,8512 / 0,7406; 2,2631 / 0,6667; 92,0824…) | Confirmada | Tabla 3 |
| L2: «la ganancia de tiempo es contra RAG denso» | **Refutada en parte y corregida** | Denso top-3 (0,4140 + 0,9566 = 1,3706 s; 0,4123 + 0,9331 = 1,3454 s) es más rápido que CAG (1,4078 s; 2,2631 s) en Medium y Large. CAG gana a denso top-10 en los tres tamaños y a BM25 top-10 sólo en Small y Medium |
| Citas de §3.3, *Limitations* y §4 del paper | Confirmada | PDF v2 |
| G2: MIT, rama `main`, último push 2025-05-26; `DynamicCache` l. 8, `torch.save` l. 117, recorte l. 120–125; README «may degrade with very long contexts»; `HF_TOKEN` | Confirmada | API de GitHub; `kvcache.py` y README de `main` |
| X1: `UsageDetails` 10 propiedades con `CachedInputTokenCount`; `ChatOptions` 20 sin caché; seis tipos `*Caching*`; OllamaSharp `ChatDoneResponseStream` sin cacheados; `ChatCompletionOptions` sin «Cache»; `CreateResponseOptions.PromptCacheKey`/`PromptCacheRetentionPolicy`; `ChatInputTokenUsageDetails.CachedTokenCount` | Confirmada (E1 re-ejecutada) | Programa propio de reflexión, `mcr.microsoft.com/dotnet/sdk:10.0`; versiones informativas 10.11.0+25f07afa…, 2.14.0+2e77b088…, 5.5.0+135abcc3… |
| 10.11.0, OpenAI 2.14.0 y OllamaSharp 5.5.0 son las últimas en nuget.org | Confirmada | `api.nuget.org/v3-flatcontainer`, 2026-10-26 |
| G4 l. 26–33 y l. 125; G7 l. 608 y l. 727; G7b l. 975 y l. 1651; cita de G8 | Confirmada | Archivos crudos en el commit 25f07afa… |
| G9: `ParseOllamaChatResponseUsage` llena sólo 3 conteos; duraciones a `AdditionalProperties` l. 423–426; la etiqueta 5.5.0 = `135abcc` | Confirmada | Archivo en el commit; API de refs de GitHub |
| G5 y G6: citas, `CacheKeyAdditionalValues`, fidelidad, act. 2026-10-16 | Confirmada | Páginas de Learn (`updated_at` 2026-10-16) |
| G10: activación por defecto, mínimo de 1.024 en GPT-5.6+, «discounted up to 95%», `prompt_cache_key` | Confirmada | Página de OpenAI (301 desde platform.openai.com) |
| G10: vida «5 to 10 minutes… up to one hour», extendida 24 h, como regla general | **Corregida** | La página separa familias: GPT-5.6+ usa `prompt_cache_options.ttl`, «30m» por defecto o «12h», con lectura 0,1× y escritura 1,25× o 2,5×; los 5–10 min y las 24 h son de modelos anteriores (`prompt_cache_retention`). Tabla §2.3 y fila «Costo» de §3.3 corregidas |
| G11: las siete citas literales, `cache_write_tokens` en GPT-5.6+, breakpoints, ms.date 2026-08-11 | Confirmada | Página de Learn |
| G12: mínimos 512–4.096, «no error is returned», `cache_control` automático y explícito, 5 min renovados, 1 h, escritura ×1,25 o ×2, orden `tools` → `system` → `messages`, 4 breakpoints | Confirmada | Página de Claude Platform |
| G12: lectura ×0,1 para todos los modelos | **Corregida** | La página indica 0,05× en Opus 5.5 y Sonnet 5.5, y 0,025× en Fable 5.1 y Mythos 5.1; «All other models use the standard 0.1x» |
| G13: 4096 por defecto, `OLLAMA_CONTEXT_LENGTH`, `keep_alive` 5 min, `OLLAMA_NUM_PARALLEL` = 1, RAM ∝ paralelo × contexto, `OLLAMA_KV_CACHE_TYPE`; FAQ sin mención de caché de prefijo; página «Context length» por VRAM | Confirmada | FAQ y context-length (no aparecen «prompt cach», «cache_prompt» ni «reuse») |
| G14: `cache_prompt: true` l. 2104; `-c`/`-np` l. 372–373; truncado o 400 l. 276–316; la mitad de la ventana l. 318–328 (4096 − (4096 − 4)/2 = 2050) | Confirmada | `llm/llama_server.go` en `v0.32.0-rc0` |
| G14b: última versión v0.40.11, 2026-10-24 | Confirmada | API de releases de GitHub |
| G15: texto de `cache_prompt` (default `true`, «bit-for-bit»), `--ctx-checkpoints` 32, `--checkpoint-min-step` 8192, `--cache-ram` 8192 MiB, `--cache-reuse` | Confirmada | README de llama.cpp en `master` |
| G16: `prompt_eval_cached_count`, `prompt_eval_duration` «uncached prompt tokens» | Confirmada | docs.ollama.com/api/chat |
| G17–G24: ids, títulos y primeros autores; citas de RULER, Leng et al., Cartridges («38.6x less memory», frente a ICL), ACC y Li et al. (Self-Route, EMNLP 2024 Industry) | Confirmada | API de arXiv |
| X3: valores de A, B y C (4.441 tokens; 474,71 / 395,86 / 182,32 s; `load` 38,85 s; respuestas 3961 y Santa Fe); unos 9,4 tok/s | Confirmada contra el registro crudo, sin re-ejecutar | `n3b/e1/run1.jsonl` |
| X3: «`prompt_eval_cached_count` no aparece» en el servidor de la LAN | **No verificado** | `run1.jsonl` no registra las claves ausentes; sólo hay inferencia por versión. Marcado en §3.6 |
| X4a: *timeout* a los 900 s | Confirmada contra el registro crudo | `n3b/e1/run2.jsonl` (`TimeoutError: timed out`) |
| X2: versión, modelos, digest y `context_length` 65.536 del servidor de la LAN | **No re-ejecutada** | No se contactó el servidor. La arquitectura sí coincide con el `config.json` público de Qwen/Qwen3.5-4B: 32 capas, `full_attention_interval` 4, 262.144 posiciones, capas `linear_attention` (que el GGUF rotula `ssm.*`; «SSM» se precisó en §0 y §3.6) |
| X4b: caché de prefijo en Ollama 0.32.0-rc0 con `qwen2.5:0.5b` (a8b0c5157701, 397 MB) en CPU de 8 núcleos | Confirmada (E1 re-ejecutada) | Corrida propia: frío 74,98 s → B 0,84 s (22 tokens nuevos, `cached n_tokens = 4703`) → C 0,99 s → D, con 1 carácter cambiado, 77,16 s (`cached n_tokens = 4`) → G 0,05 s. La relación es la misma (unas 90 veces); los segundos absolutos dependen de la carga de la máquina (la original midió 102,65 s) |
| X4b: sin `num_ctx` trunca en silencio a 2.050 de 4.728 (`keep=4`) y `ollama ps` muestra 4096 | Confirmada (E1 re-ejecutada) | Mismo `WARN llama_server.go:314` y la misma respuesta (8983, del último artículo) |
| X4b: A y C idénticas con `temperature` 0 dan respuestas distintas | Confirmada (re-ejecutada) | De nuevo 1812 (frío) frente a 8983 (con caché): es un patrón repetible entre el camino frío y el cacheado, compatible con el aviso «bit-for-bit» de [G15] |
| X4b: G acierta después de D (§9.7) | Confirmada; el mecanismo sigue abierto | En la re-ejecución, el log muestra `cache state: 1 prompts … 4732 tokens` justo antes de D y luego `cached n_tokens = 4727` en G: compatible con el guardado del slot inactivo (`--cache-idle-slots`, que requiere `--cache-ram` [G15]). No se verificó en el código de Ollama |
| X4b: literales de `*Policy` en `8fb4c3a`: 14 literales, 750 bytes | Confirmada | `git show` de los dos `*Policy.cs` del ApiWeb (mismo contenido, otro orden) |
| X4b: el corpus real mide 253 tokens | **Corregida a un rango** | Re-ejecutado: 264 y 259 tokens según la pregunta. La conclusión (por debajo de cualquier mínimo de la nube) no cambia. §0.6 y P6 dicen ahora «unos 250–265» |
| Corpus sintético: 70 artículos, `seed(7)`, 16.748 bytes; Art. 7 → 3961, Art. 12 → Santa Fe | Confirmada | `corpus70.txt` y `corpus.py` |
| Referencias cruzadas: N5 §2.9 y §2.10, N6 P3 («cabe entero en el prompt»), 12 enunciados, N3 E3 (`qwen3-embedding:0.6b`), DC-07 | Confirmada | N5, N6, N3 y 00-Contrato |
| «N3 G6» como fuente del filtro por permisos | **Corregida** | En N3, el filtro por permisos está en G4; G6 es el riesgo de fuga entre contextos. §3.3 ajustado |
| No hay réplica independiente de [G1] | Sigue como **no verificado** | No se buscó de nuevo; queda como lo declaró el investigador (§9.1) |
