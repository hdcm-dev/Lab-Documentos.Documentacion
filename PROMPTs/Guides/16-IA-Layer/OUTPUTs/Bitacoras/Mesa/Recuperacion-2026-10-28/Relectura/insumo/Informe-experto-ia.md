---
doc_id: BIT-16-C1-INF-experto-ia
titulo: Informe del experto en IA — mesa, ciclo 1
fecha: 2026-10-28
especialista: Experto en IA (perfil del PO, REED-16 §8; convocatoria fila 8)
mandato: corrección de los conceptos (LLM, tokens y ventana de contexto, embeddings y similitud, chunking, recuperación, CAG, tool calling, agentes y orquestación, caracterización de LangGraph, límites de los Qwen medidos en <equipo-de-contingencia>); más el ítem de chequeo de licencias por modelo y tamaño (convocatoria §6)
modo: a ciegas (no se leyó ningún otro Informe-*.md)
evidencia: evidencia-experto-ia/ (README con criterios fijados antes de correr, sonda_experto.py, salidas/*.jsonl, fuentes.txt)
---

# Informe del experto en IA — ciclo 1

## 0. Alcance y método

- **Objeto revisado.** `Nucleos/N1`, `N1b`, `N3`, `N3b` y `N4` en las secciones de definiciones, desarrollo y evidencia, con sus notas de reanudación y de reparación del 2026-10-28; `04-Integracion.md` §1–§5; `Sondeo-Entorno.md` §R.0–§R.5; `Mesa/I-01`; las evidencias `Integracion-Evidencia/B-abstracciones-agentes/sonda/` (E-B5) y `C-operacion-demo/X3-*`. N0b, N2, N5 y N6 sólo se leyeron donde tocan conceptos de mi mandato.
- **Fuera de mandato.** No juzgo APIs .NET ni la forma. Lo que vi y no es mío va en §5 como solicitud de convocatoria.
- **Evidencia nueva.** Cinco sondas E1 contra el Ollama propio en contenedor (<equipo-de-contingencia>), con turno exclusivo del recurso `modelo-compartido`, criterios de éxito escritos antes de correr (R-LLM) y el endpoint sólo en `OLLAMA_ENDPOINT` (R-PRIV). Se suma la consulta E4 de las fuentes vigentes (Hugging Face, registro de Ollama, PyPI, npm, NuGet, docs de LangGraph y de Agent Framework), con URL y fecha en `evidencia-experto-ia/fuentes.txt`. Todas son del 2026-10-28.

| Sonda | Pregunta | Resultado |
|---|---|---|
| S1 | ¿Cambia E-B5 si la consulta lleva la instrucción que pide `qwen3-embedding`? | 4/7 sin instrucción, 5/7 con instrucción en inglés, 3/7 en español. «en avión» siempre devuelve un medio |
| S2 | ¿Cuentan igual los tokenizadores de Qwen 2.5 y Qwen 3.5? | Mismo texto: 270 frente a 226 tokens (−16 %) |
| S3 | ¿El truncado silencioso de X3 vale para `qwen3.5:4b`? ¿Se pierde el dato? | Sí: 2050 tokens, HTTP 200, respuesta equivocada («colectivo» en lugar de «tren») |
| S4 | Caché de prefijo con el 4b híbrido en 0.40.11 | Parcial: 954 de 1.467 tokens reutilizados, 43 % del tiempo de prompt; `prompt_eval_cached_count` existe |
| S5 | ¿El presupuesto de prompt es `num_ctx` o `num_ctx`/2? | Con 4096, un prompt de 2.943 tokens entra completo: el recorte a la mitad ocurre sólo al desbordar |

Procesamiento del prompt de `qwen3.5:4b` en <equipo-de-contingencia>: **unos 18–20 tokens por segundo** (S3, S4, S5).

## 1. Hallazgos

### EXPERT-01 — La caché de prefijo y el escalón 1 de N3b se apoyan en cifras de otro modelo y de otra versión

- **Ubicación.** `Nucleos/N3b` §0 punto 4, §2.4, §3.3 (escalón 1), §8 X4b, lecturas 1 y 3. Lo hereda `04-Integracion.md` §3.1 RA-9.
- **Severidad.** S2. **Evidencia.** E1 (S4) + E2 (X4b, citado).
- **Afirmación.** «Pasó de 102,7 s en frío a 1,1 s», «unas 93 veces menos», «`prompt_eval_count` no sirve para detectar aciertos» y «`prompt_eval_cached_count` no existe en esta versión» se midieron con `qwen2.5:0.5b`, que es un transformer denso, en Ollama 0.32.0-rc0. Con el modelo propuesto (`qwen3.5:4b`, que es **híbrido de arquitectura**: 24 capas `linear_attention` y 8 `full_attention`, según `config.json`) en 0.40.11, la reutilización es **parcial**. En el caso B se reutilizaron 954 de 1.467 tokens (`prompt_eval_cached_count`) y el prompt costó 33,6 s frente a 77,8 s en frío (43 %), no el 1 % de X4b. El caso C (prefijo alterado) volvió a 0 tokens cacheados. N3b planteó esa limitación como «hipótesis, no verificada» (§0.4, X3). Con S4 queda medida.
- **Impacto si no se corrige.** La guía prometería que el escalón 1 baja el costo del corpus en dos órdenes de magnitud con el modelo de la guía, y no es así. Además, N1b (nota de reparación del 2026-10-28, ítem «§3.2 filas 18 y 23»: «familia Qwen3.5, híbrido con razonamiento») y N3b (híbrido de arquitectura) usan la palabra «híbrido» con dos sentidos distintos. El lector no tiene cómo separarlos.
- **Propuesta de dirección.** Que la guía cite el efecto con los números del modelo propuesto y lo rotule como «parcial en modelos híbridos (reutilización por *checkpoints*)». Que la señal de acierto sea `prompt_eval_cached_count`, presente en 0.40.11, y que el 93× quede como dato histórico de un modelo denso. Que la guía distinga **«híbrido de razonamiento»** (modo con y sin pensamiento) de **«arquitectura híbrida»** (atención lineal + completa).
- **Capa de origen.** Núcleo (N3b), con un arrastre en la integración.

### EXPERT-02 — La regla de la ventana se puede leer como «el presupuesto es la mitad», y X3 no discriminaba

- **Ubicación.** `04-Integracion.md` §1 fila X3 («límite = contexto/2 + 2») y §3.2 R-C08; `Nucleos/N3b` §8 X4b, lectura 4 («Ollama libera la mitad de la ventana para generar»); MI-18.
- **Severidad.** S2. **Evidencia.** E1 (S3, S5) + E1 (X3).
- **Afirmación.** Hay tres problemas:
  1. **El recorte a `num_ctx`/2 + 2 se produce sólo cuando el prompt desborda `num_ctx`.** Con `num_ctx` 4096, un prompt de 2.943 tokens entró completo y la respuesta fue correcta (S5). La explicación «libera la mitad de la ventana para generar» induce a pensar que todo prompt tiene ese techo.
  2. **X3 no podía mostrar la pérdida de información.** Sus 320 líneas decían «colectivo» y la respuesta «colectivo» era correcta aunque se truncó. S3 repite la prueba con el dato sólo en la primera línea: con `qwen3.5:4b`, sin `num_ctx`, `prompt_eval_count` dio 2050, HTTP 200, `done_reason` `stop` y la respuesta salió **equivocada**.
  3. X3 se midió sólo con `qwen2.5:0.5b`. S3 extiende el resultado al modelo propuesto.
- **Impacto si no se corrige.** O el lector reserva media ventana sin necesidad (con 4096, la mitad es toda la diferencia entre que RAG entre o no entre), o confía en una prueba que pasa aunque el defecto exista.
- **Propuesta de dirección.** Que la guía enuncie el comportamiento así: «si el prompt supera `num_ctx`, Ollama 0.40.11 conserva unos pocos tokens del principio y la cola, y lo deja en `num_ctx`/2 + 2, sin error; por debajo de `num_ctx`, entra completo». Que el presupuesto se defina como `num_ctx` menos la salida máxima. Que toda prueba de ventana ponga el dato que se pregunta en la zona que el truncado descarta.
- **Capa de origen.** Integración (X3, R-C08) y núcleo (N3b X4b).

### EXPERT-03 — El límite que más pesa del 4b en <equipo-de-contingencia> (la lectura del prompt, unos 18–20 tok/s) no figura en ninguna decisión

- **Ubicación.** `Sondeo-Entorno.md` §R.2 y §R.5 puntos 1 y 6(b) (sólo dan unos 7 tok/s de generación; «contextos grandes… sin medir»). Afecta a `04-Integracion.md` §2 tensión 1 (vía A por defecto) y a `Nucleos/N3` §2.6 (punto de partida de 512 tokens con 25 % de solapamiento), y alcanza a MI-01, MI-07 y MI-16.
- **Severidad.** S2. **Evidencia.** E1 (S3: 2.050 tokens en unos 100 s; S4: 1.466 en 77,8 s; S5: 2.943 en 167 s).
- **Afirmación.** En <equipo-de-contingencia>, `qwen3.5:4b` procesa el prompt a unos 18–20 tokens por segundo en CPU. Llenar una ventana de 4096 cuesta entre 3,5 y 4 minutos. Cada fragmento de 512 tokens agrega 25–30 s a **cada** pregunta de la vía A. El costo de la generación (7 tok/s) es el que se informó, pero no domina cuando hay contexto recuperado.
- **Impacto si no se corrige.** Si la demo sigue el punto de partida de Azure AI Search (512 tokens, top-k 3–5), cada respuesta tarda minutos y el lector va a atribuir la lentitud a RAG o a .NET, no al hardware. El juez de MI-16, que lee pregunta, contexto y respuesta, tampoco entra en el turno de 45 min con N razonable.
- **Propuesta de dirección.** Que la guía tenga una tabla de presupuesto del entorno (tok/s de prompt y de generación, carga en frío, ventana cargada) rotulada «<equipo-de-contingencia>, CPU, 2026-10-28». Que el tamaño de fragmento y el k de la demo se elijan **con esa tabla** y se declaren como decisión del entorno, separada del punto de partida general de N3 §2.6. Que el pedido a <estación-2> de MI-03 incluya esta medición.
- **Capa de origen.** Laboratorio (sondeo), propagado a la integración.

### EXPERT-04 — El muestreo y el modo de razonamiento de Qwen3.5 están tratados con reglas genéricas que el fabricante contradice

- **Ubicación.** `Nucleos/N1` §2.6 y §5 P7 («0 o muy baja»; «no tocar a la vez `Temperature` y `TopP`»). `Sondeo-Entorno.md` §R.1 (`parameters` del Modelfile: `temperature 1`, `top_k 20`, `top_p 0.95`, `presence_penalty 1.5`). `Nucleos/N1b` §3.2 (ninguna fila para los modelos de razonamiento, aunque la reparación RA-9 c reconoce que «sí tocan el contrato»).
- **Severidad.** S3. **Evidencia.** E4 (model card de Qwen/Qwen3.5-4B, 2026-10-28) + E1 (Sondeo §R.1).
- **Afirmación.** Hay tres puntos:
  1. El model card de Qwen3.5-4B recomienda parámetros **por modo**. Sin razonamiento, para tareas generales: `temperature=0.7, top_p=0.8, top_k=20, presence_penalty=1.5`. Con razonamiento: `temperature=1.0, top_p=0.95…`. Es decir, ajusta temperatura **y** top_p a la vez, lo contrario de la regla de N1 P7.
  2. El Modelfile del tag trae los valores **del modo con razonamiento**. Por eso, si la demo apaga el razonamiento y sólo fija `Temperature`, `top_p` queda en 0,95 y no en el 0,8 que recomienda el fabricante. Nadie lo decidió.
  3. El card dice que «Qwen3.5 models operate in thinking mode by default» y aconseja «at least 128K tokens to preserve thinking capabilities». Con 4096 cargados en <equipo-de-contingencia>, el razonamiento encendido no es una configuración que el fabricante sostenga. Hoy no hay en la línea de tiempo de N1b ninguna fila con fuente que explique al lector qué es un modelo de razonamiento.
- **Impacto si no se corrige.** La guía daría como regla general algo que el fabricante del modelo de la guía contradice, y la demo correría con un muestreo que nadie eligió.
- **Propuesta de dirección.** Que la guía enseñe que **el muestreo lo recomienda el fabricante por modelo y por modo**, y que la regla genérica de Azure quede como regla de ese proveedor. Que la demo fije por configuración todos los parámetros del modo sin razonamiento, o que declare la temperatura 0 como decisión propia medida con R-LLM. Que N1b sume una fila con fuente sobre los modelos de razonamiento y el modo híbrido con y sin pensamiento, ligada a MI-02.
- **Capa de origen.** Núcleo (N1, N1b).

### EXPERT-05 — «Equivalente funcional: mismo modelo» exagera la equivalencia entre los workflows de MAF y LangGraph

- **Ubicación.** `Mesa/I-01` §2, tabla de vías («Equivalente funcional: mismo modelo, otro proveedor»). `04-Integracion.md` §2, tensión 5. `Nucleos/N4` §2.5 y §2.13, que no tienen una comparación explícita.
- **Severidad.** S3. **Evidencia.** E4 (docs.langchain.com/oss/python/langgraph/graph-api; learn.microsoft.com/en-us/agent-framework/concepts/workflows/, ms.date 2026-07-30; consultadas el 2026-10-28).
- **Afirmación.** Los dos comparten la ejecución por *supersteps* al estilo Pregel, los checkpoints y la intervención humana. El **modelo de programación es distinto**:
  - en LangGraph, el grafo opera sobre un **estado compartido** («A shared data structure…»), con un reductor por clave («Each key in the State has its own independent reducer function»); permite fan-out dinámico con `Send` desde aristas condicionales y controla el flujo con `Command`;
  - en MAF .NET, «It connects typed executors through edges», las aristas «route values between executors» y el estado es un mecanismo aparte («State management»).
  Llamarlo «mismo modelo» no está sostenido por las fuentes. Que es «el LangGraph de .NET» ya figura como criterio propio, y eso está bien.
- **Impacto si no se corrige.** Un lector que viene de LangGraph va a buscar el `State` con reductores y el `Send`, no los va a encontrar con esa forma, y va a concluir que la guía lo engañó. Las versiones sí están bien (PyPI 1.2.18 y npm 1.5.3 del 2026-10-26; NuGet `owner:langchain` → 0, re-consultado hoy).
- **Propuesta de dirección.** Que la guía diga «equivalente en capacidades (grafo, supersteps, checkpoints, HITL), no en modelo de programación» y agregue una tabla corta de diferencias: estado compartido con reductores frente a mensajes tipados; `Send` frente a fan-out declarado; `interrupt`/`Command` frente a `RequestPort`; servidor propio frente a `InProcessExecution`. Si la mesa quiere ir más allá de las docs (semántica de checkpointer o `thread_id`), corresponde la convocatoria en caliente de AH-03 que ya prevé la convocatoria.
- **Capa de origen.** Integración (I-01, tensión 5), sobre un hueco del núcleo N4.

### EXPERT-06 — Los tokens dependen del modelo, pero los conteos y la regla de MI-18 usan otro tokenizador

- **Ubicación.** `Nucleos/N3b` §0 punto 6 y §8 X4b, lectura 7 («~250–265 tokens con el tokenizador de Qwen 2.5»). `04-Integracion.md` §1 X3 (10.082 tokens, contados con el 0.5b) y §5 MI-18 («comparar `prompt_eval_count` con el largo esperado»). `Nucleos/N3` §4.6 (`TiktokenTokenizer.CreateForModel("gpt-5")` para fragmentar texto que va a Qwen).
- **Severidad.** S3. **Evidencia.** E1 (S2) + E4 (`vocab_size` 248.320 en Qwen3.5-4B frente a 151.936 en Qwen2.5-0.5B, `config.json` de Hugging Face).
- **Afirmación.** Sobre el mismo texto en español, `qwen3.5:4b` cuenta un 16 % menos de tokens que `qwen2.5:0.5b` (226 frente a 270; 5,0 frente a 4,2 caracteres por token). La plantilla de chat agrega tokens propios de cada modelo. Si el «largo esperado» de MI-18 se cuenta con otro tokenizador (Tiktoken, Qwen 2.5) o sin la plantilla, la comparación da diferencias aunque no haya truncado, o las tapa.
- **Impacto si no se corrige.** La regla de MI-18, bien intencionada, produciría errores falsos en la demo, y las cifras de tamaño del corpus citadas en la guía no serían del modelo de la guía. La conclusión de N3b §0.6 (debajo de cualquier mínimo cacheable) no cambia, porque no depende del número exacto.
- **Propuesta de dirección.** Que la guía explicite que **el token es una unidad del modelo**: un conteo vale para el modelo con que se hizo. Que MI-18 se formule con un largo esperado medido con el mismo modelo, por ejemplo una calibración por `prompt_eval_count` al arrancar, con un margen. Otra opción es tomar como firma de truncado `prompt_eval_count == ⌊num_ctx/2⌋ + 2` cuando el largo estimado supera `num_ctx` (EXPERT-02). Que el chunking por tokens declare con qué tokenizador cuenta y que, con Qwen, el conteo es una aproximación.
- **Capa de origen.** Núcleo (N3b, N3) e integración (MI-18).

### EXPERT-07 — ESC-02 «requisito por significado» con recall@k sobre 12 enunciados necesita k chico, consultas sin respuesta y un umbral por modelo; N3 no dice que `qwen3-embedding` es *instruction-aware*

- **Ubicación.** `04-Integracion.md` §3.1 R-C16 y §5 MI-08. `Nucleos/N3` §2.2 y §2.8.
- **Severidad.** S3. **Evidencia.** E1 (S1, E-B5) + E4 (model card de Qwen3-Embedding-0.6B).
- **Afirmación.** Con 12 documentos, recall@5 cubre el 42 % del corpus y recall@12 vale 1 por construcción: la métrica discrimina poco si no se fija k ∈ {1, 3}. La similitud siempre devuelve algo: «en avión» devolvió `moto`, `tren` y `tren` en las tres variantes de S1. ESC-02 necesita entonces preguntas sin respuesta y un umbral. Ese umbral **no es portable**: la instrucción de consulta corrió los puntajes absolutos (por ejemplo, «en el ferrocarril» bajó de 0,788 a 0,608). Además, el card de Qwen3-Embedding dice «Instruction Aware: Yes». Ahí la consulta lleva `Instruct: {tarea}\nQuery:{consulta}` y el documento va sin instrucción, con una mejora típica del 1 al 5 % y la instrucción en inglés. N3 §2.2 documenta los prefijos de `nomic-embed-text` y omite este rasgo del modelo que sí se usa. S1 muestra que tampoco salva la normalización de T3 (5/7 en inglés, 3/7 en español), y eso **refuerza** T3.
- **Impacto si no se corrige.** Un ESC-02 medido con un k grande y sin consultas sin respuesta da números altos que no dicen nada, y un umbral copiado de otro formato de consulta corta mal.
- **Propuesta de dirección.** Que MI-08 se apruebe con métricas recall@1, recall@3 y MRR, con un subconjunto de preguntas sin respuesta y con un umbral calibrado para el modelo y el formato de consulta, todo declarado. Que N3 §2.2 sume la asimetría consulta/documento de `qwen3-embedding` y que la guía la muestre como una decisión que se mide, no como una receta.
- **Capa de origen.** Núcleo (N3) e integración (R-C16).

## 2. Lo que revisé y está bien

1. **Licencias por modelo y tamaño** (ítem de chequeo de la convocatoria §6). Las tres son **Apache 2.0**. `qwen3.5:4b`: tag de Ollama con capa de licencia Apache 2.0 y Hugging Face `license: apache-2.0`. `qwen2.5:0.5b`: capa Apache 2.0 y Hugging Face `apache-2.0`; la nota de N1b de que 3B y 72B quedan fuera también figura en ollama.com/library/qwen2.5. `qwen3-embedding:0.6b`: Hugging Face `apache-2.0`, pero **el tag de Ollama no trae capa de licencia**, así que la guía debe citar Hugging Face. Además, el sha256 del manifiesto del registro de Ollama **coincide** con los tres digests de `/api/tags` en <equipo-de-contingencia> (d8b0f5e9…, ac6da0df…, a8b0c515…). La procedencia del modelo medido es la del registro público. Evidencia E4/E1, en `fuentes.txt`.
2. **Tool calling y agente** (N4 §2.1–2.4, N1 §2.13, N1b «Function calling»). La definición es correcta y tiene la frontera bien puesta: el modelo propone y la app ejecuta; el `enum` del esquema es una pista y no un control (Sondeo §R.4: `"piedra"` con `finish_reason: tool_calls`); la aprobación no reemplaza la validación. La distinción entre agente y workflow sigue a Anthropic y a Microsoft con cita literal. Los límites medidos de los Qwen (0.5b 0/10 cuando hay que interpretar; 4b 10/10, y 4–5 veces más lento con el razonamiento encendido) son E1 con R-LLM y están bien rotulados como «separan modelos, no son fiabilidad».
3. **CAG y la decisión de T3.** N3b §2.2–§2.5 define CAG como lo hace el paper (precalcular y reutilizar la caché KV) y separa la caché de respuestas, la caché de prefijo, el CAG del paper y el contexto largo sin caché, sin confundirlos. La lectura crítica de las tablas 2 y 3 del paper es correcta. Que ESC-01 vaya por herramienta (el top-k no cuenta, E-B4) y que se descarte normalizar con embeddings (E-B5) es conceptualmente correcto, y S1 lo refuerza: ninguna variante con instrucción mejora 2 aciertos o más.

## 3. Posición sobre los MI de BIT-16-04 §5 que caen en mi mandato

| MI | Posición | Fundamento |
|---|---|---|
| MI-01 | propuesta | Las tres vías son conceptualmente distintas y A como opción por defecto es lo correcto con este modelo: en EA-6, B omite recuperar 2 de 5 veces. Condición: el k y el tamaño de fragmento de A se fijan con el presupuesto medido (EXPERT-03) |
| MI-02 | propuesta | `qwen3.5:4b` sin razonamiento es el único que interpreta sinónimos (10/10 frente a 0/10) y la licencia es Apache 2.0. Dejar el razonamiento sólo como mención es coherente con el card (pide ≥ 128K de contexto para pensar; <equipo-de-contingencia> carga 4096). `qwen3-embedding:0.6b` con 1024 está confirmado (norma 1,0). `qwen2.5:0.5b` como prueba de humo, también. Agregar los parámetros de muestreo del modo sin razonamiento (EXPERT-04) |
| MI-03 | propuesta | Con 18–20 tok/s de prompt en CPU, el comparativo ≥ 7B, el contexto grande y el juez no entran en <equipo-de-contingencia>. Medir en <estación-2> con la misma sonda antes de adoptarlo, incluido el tok/s de prompt |
| MI-07 | propuesta | El escalón 0 por defecto es lo correcto: el corpus real ocupa unos 250 tokens (unos 210 en tokens de qwen3.5 y unos 12 s de prompt, ambos estimados a partir de S2 y S4, no medidos sobre ese corpus). RAG como variante didáctica, con el mismo conjunto de oro |
| MI-08 | otra | Sí al candidato, pero sólo con recall@1, recall@3 y MRR, preguntas sin respuesta y un umbral calibrado por modelo y formato de consulta (EXPERT-07). Sin eso la métrica no discrimina con 12 documentos |
| MI-10 | propuesta | Organizar por mecanismo es lo conceptualmente correcto. El consumo HTTP de LangGraph se ejecuta sólo si se levanta `langgraph dev`, y si no queda como «no ejecutado». Condición: corregir «mismo modelo» (EXPERT-05) |
| MI-14 | propuesta | Es un límite del modelo medido: ante «CP 34», el 4b inventa un código postal 10/10 y borra sin confirmar 10/10 (X2). La confirmación del alta es una defensa contra un modo de falla del LLM, no un exceso de cautela |
| MI-16 | propuesta | Un juez de 4B sin calibrar no es confiable, y la calibración con 10–20 casos anotados es lo mínimo. Advertencia: con 18–20 tok/s de prompt, cada juicio con contexto cuesta minutos; dimensionar N con EXPERT-03 o llevarlo a <estación-2> (MI-03) |
| MI-17 | propuesta | `qwen3-embedding` admite dimensiones de 32 a 1024 (MRL). Una dimensión mal configurada o un cambio de modelo da vectores incomparables sin error. Validar al arrancar es necesario |
| MI-18 | otra | Mantener `num_ctx` explícito y la detección del truncado, pero (a) con el largo esperado medido con el mismo modelo y la plantilla, o con la firma `⌊num_ctx/2⌋ + 2` al desbordar (EXPERT-06); (b) con el presupuesto = `num_ctx` − salida y no `num_ctx`/2 (EXPERT-02, S5); (c) con pruebas que pongan el dato en la zona que se descarta (S3) |

No me pronuncio sobre MI-04 a MI-06, MI-09, MI-11 a MI-13, MI-15 ni MI-19 a MI-24: son de arquitectura, de APIs .NET, de forma, de operación o de datos personales.

## 4. Pendientes que este informe deja medidos

- El truncado silencioso con el modelo propuesto y la pérdida del dato (S3) cierran la extensión de X3 al 4b.
- El presupuesto por debajo de `num_ctx` (S5) cierra la ambigüedad de «contexto/2».
- La caché de prefijo con el 4b en 0.40.11 (S4) cierra la hipótesis de N3b §0.4 y §9.2 para esta versión: hay reutilización parcial.
- Lo que sigue abierto: el efecto de la instrucción de consulta sobre los `*Policy` reales (S1 se corrió sobre el catálogo de medios), y el throughput de prompt en <estación-2>.

## 5. Solicitudes de convocatoria

- **Senior .NET.** Hay dos preguntas que quedan del lado de las APIs y no son mías. (a) Si OllamaSharp 5.5.0 expone `prompt_eval_cached_count` en algún punto alcanzable desde `IChatClient` (`RawRepresentation`, `AdditionalProperties` de `UsageDetails`), porque N3b §0.3 dice que no llena `CachedInputTokenCount` y EXPERT-01 propone usar esa señal. (b) Si `ChatOptions` (`TopP`, `TopK`, `PresencePenalty`) se traduce en las dos vías (OllamaSharp y `/v1`), de modo que la demo pueda fijar el muestreo del modo sin razonamiento (EXPERT-04).
