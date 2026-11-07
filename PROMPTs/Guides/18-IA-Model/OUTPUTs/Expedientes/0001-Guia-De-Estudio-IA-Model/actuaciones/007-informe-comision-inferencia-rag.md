# Informe — Comisión de Inferencia local, RAG y bases vectoriales (ronda de estructura)

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-07 |
| Autor | comisión de inferencia local, RAG y bases vectoriales |
| Corrige | — |

Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas: cabecera y §0 (líneas 1–111), la carta
(evidencia 006, forma de §5.2), §2.2, §3.2, §3.3 y §4. Documentos cargados además:
Cadena-De-Consecuencias 2.0 (§2, antes de recomendar entre opciones). Escalas y forma del folio por el
pliego operativo (evidencia 002). No se propone excepción a ningún conocimiento: no se cargó
Excepcion-A-Un-Conocimiento.

Insumos leídos: folios 001 y 002, pliego operativo (evidencia 002), carta (evidencia 006), Profile
Study-Guide-Documentation, convenciones de la casa (`ia-db/README.md` e
`ia-db/indexes/10_Convenciones-y-Glosario.md` del repo destino). Trabajé a ciegas: ningún informe de
otra comisión.

Nota de redacción: el endpoint real del banco de ensayo no se versiona (repositorio público); en este
folio y en la guía se escribe `localhost:11434` o `OLLAMA_HOST`, conforme a MEDIOS del folio 002.

---

## 1. Hallazgos sobre el enunciado y el objetivo

### H-IR-01 — «Ollama» entra al objetivo de los ejemplos sin frase del pedido — P1 · E2

**Ancla.** El pedido (folio 001, bloque testimonio) pide entender «motor de inferencia» como concepto
(«…metricas, motor de inferencia, y toda los conceptos relacionadas…») y sólo afirma un estado:
«Actualmente tenemos corriendo diferentes modelos de qween». No contiene la palabra «Ollama». La carta
de esta comisión fija «ejemplos prácticos operables sobre modelos open source tipo Qwen (“Contexto” del
pedido)… operables en un entorno local con Ollama/modelos Qwen cuando aplique», y la pregunta 4 del
contrato (folio 002) dice «verificables en un entorno local con modelos open source tipo Qwen». Ollama
aparece sólo en MEDIOS, como banco de ensayo. Lo dado por fijo sin origen en el pedido: *Ollama como el
motor de los ejemplos*. Es mi primer hallazgo, como la carta ordena.

**Impacto si no se corrige.** La guía enseñaría un producto en lugar del concepto que el pedido nombra:
el estudiante sabría operar Ollama sin criterio para elegir motor (la restricción «formar criterio» del
objetivo), y el temario quedaría atado a una herramienta que el pedido no fijó.

**Dirección de la corrección.** Declarar la elección de Ollama como decisión del contrato con su origen
(MEDIOS: es el banco disponible y verificado), no como requisito del pedido; y el núcleo de motores de
inferencia (N1, abajo) presenta el espacio —llama.cpp, Ollama, vLLM, servidores gestionados— con cuadro
comparativo y criterio de elección. Los ejemplos operables corren sobre el banco; el concepto no se
reduce a él. (Cadena de consecuencias §2 corrida en §4 de este informe.)

### H-IR-02 — El banco de ensayo no tiene ningún modelo de embeddings: los ejemplos de RAG y bases vectoriales son inviables hoy — P1 · E1

**Ancla.** Comando contra el banco declarado en MEDIOS (endpoint del contexto de ejecución;
2026-11-07):

```
curl -s http://localhost:11434/api/tags | jq -r '.models[].name'
qwen3-coder:30b
gpt-oss:20b
qwen3.5:35b-a3b
qwen2.5:14b-instruct
qwen2.5-coder:14b
gemma4:e4b-it-qat
qwen2.5vl:7b
qwen2.5:7b-instruct
qwen2.5-coder:7b
qwen2.5-coder:3b-base
qwen3.5:4b
```

Once modelos, todos generativos (uno multimodal de visión); ninguno de embeddings. `/api/version` →
`0.32.0-rc0`. El pedido nombra «base de datos vectoriales» (folio 001); sin modelo de embeddings no hay
ejemplo reproducible de indexación ni de recuperación semántica: ejemplo práctico inviable (lectura P1
del contrato).

**Impacto si no se corrige.** Los núcleos N3–N5 quedarían ilustrativos donde el pedido exige ejemplos
operables, o un redactor los escribiría sin correrlos (viola «toda afirmación respaldada por evidencia
verificable»).

**Dirección de la corrección.** Incorporar al banco un modelo de embeddings antes de la fase de
redacción —candidato natural por coherencia con el corpus: la familia Qwen3-Embedding (0.6B entra en
CPU; Zhang et al. 2025, abajo), disponible en la biblioteca de Ollama—, con verificación
`POST /api/embed` → vector de dimensión declarada. Esta comisión no lo incorpora por sí: el banco no es
de su siembra y su carta la limita a `despacho/`; queda como obstáculo pedido (duda 1 del cierre).

### H-IR-03 — Ejemplos con `localhost` sin parametrizar fallan fuera de la topología del banco — P2 · E1

**Ancla.** Desde el contexto de esta comisión: `curl http://127.0.0.1:11434/api/tags` → sin respuesta
(exit 7); el mismo comando contra el endpoint del banco declarado en el contexto de ejecución → 200 con
el listado de arriba. MEDIOS del folio 002 prescribe «en el texto público, localhost»: correcto para no
versionar rutas internas, pero si los ejemplos de la guía escriben `localhost` *a secas*, el estudiante
que corre el modelo en otra máquina, en un contenedor o en una red local (los contextos CTX-B/C/D que
propongo abajo) reproduce exactamente esta falla.

**Impacto si no se corrige.** Pérdida acotada: ejemplos correctos en una sola topología; el primer
tropiezo del principiante es de plomería y no de concepto.

**Dirección de la corrección.** Todo ejemplo de mi dominio se parametriza
(`OLLAMA_HOST=${OLLAMA_HOST:-http://localhost:11434}`) y abre con un paso 0 de verificación del
endpoint (`GET /api/tags` esperado 200), enseñado una sola vez en el núcleo N1 y referenciado después.

### H-IR-04 — Hardware mínimo del estudiante sin declarar: riesgo sobre la audiencia principiante — P2 · E4

**Ancla.** Restricción dura del contrato (folio 002): «romper la audiencia principiante» es P0;
MEDIOS acota los ejemplos a «lo reproducible en CPU/GPU chica». Pero ni el pedido ni el contrato
declaran el piso de hardware del *lector*. El banco corre modelos de 3B a 35B; un ejemplo escrito
contra `qwen3.5:35b-a3b` (18+ GB sólo de pesos en Q4) no es reproducible por un principiante típico.

**Impacto si no se corrige.** Cada redactor elige modelo por comodidad del banco y la guía queda
heterogénea: unos ejemplos corren en cualquier notebook y otros exigen una GPU que nadie declaró.

**Dirección de la corrección.** El marco de referencia fija contextos de recursos (CTX, §3 abajo) y
cada ejemplo declara su contexto mínimo y un modelo chico de referencia (p. ej. `qwen3.5:4b` o
`qwen2.5:7b-instruct`, ambos en el banco) con variante CPU; lo que exige más se marca con su contexto.
El piso concreto es una decisión de quien pidió (duda 2 del cierre); mientras tanto rige un supuesto
declarado: CPU x86-64 con 16 GB de RAM, sin GPU.

### H-IR-05 — «RAG» figura en el contrato como tema sin frase literal del pedido: agregado sin marcar — P3 · E2

**Ancla.** La pregunta 4 del contrato (folio 002) enumera «(montar, descargar, entrenar, inferir,
medir, RAG)» y esta comisión se llama «de RAG»; el pedido (folio 001) dice «base de datos vectoriales»
y «términos asociados», nunca «RAG». La inferencia es razonable —RAG es el uso dominante de una base
vectorial junto a un modelo local (Lewis et al. 2020)— pero es un agregado, y el método manda marcar
los agregados y que quien pidió decida (§3.1 de la norma, vía carta).

**Impacto si no se corrige.** Trazabilidad: en la ronda 2 nadie podrá distinguir qué parte del alcance
vino del pedido y cuál la agregó el contrato.

**Dirección de la corrección.** Asentar «RAG» en el contrato como agregado derivado de «base de datos
vectoriales» + «ejemplos prácticos», marcado, para ratificación en el lote del cierre. El temario de
abajo lo incluye bajo ese supuesto declarado.

### Solicitud de convocatoria (no es hallazgo): entrenamiento y ajuste fino local

Señal y ubicación: el pedido nombra «entrenarlos» (folio 001, bloque testimonio, sección «Contexto») y
MEDIOS del folio 002 declara «Sin observar: entrenamiento a escala», acotando a «CPU/GPU chica o
marcado ilustrativo». Omitir un tema que el pedido nombra es P0: alguien tiene que resolver cómo se
cubre «entrenar» sin romper MEDIOS (ajuste fino ligero local —LoRA/QLoRA sobre un Qwen chico— es
materia de un especialista en entrenamiento, no de esta comisión; mi competencia termina en servir e
indexar). Pido convocatoria de la comisión de entrenamiento/ajuste fino, si no está ya en el panel.

---

## 2. Núcleos conceptuales del dominio (encargo 1 y 2 de la carta)

Dependencias externas: «Arquitecturas» = núcleo de transformers/atención/tokenización (otra comisión);
«Métricas» = núcleo de evaluación de modelos (otra comisión). Los cinco núcleos de abajo forman una
cadena: N1 → N2 (operar lo que N1 sirve) y N3 → N4 → N5 (representar, indexar, recuperar), con N5
dependiendo también de N1.

### N1 — Inferencia local y motores de inferencia

**Qué agrupa.** Qué es inferir (modelo entrenado + runtime), pesos y formatos (GGUF y safetensors),
descarga y montaje de un modelo, el motor como servidor (API HTTP), parámetros de generación
(temperature, top_p/top_k, ventana de contexto, tokens máximos), streaming, y el panorama de motores:
llama.cpp, Ollama, vLLM, y el criterio para elegir (uso personal vs. servicio concurrente).

**Por qué es un núcleo y no un fragmento.** Todas estas ideas dependen de una sola distinción —*el
modelo no es el programa que lo corre*— y se aprenden operando el mismo artefacto; partirlas (p. ej.
«descargar modelos» separado de «servir modelos») fragmenta por extensión, contra la regla de
descomposición del pedido.

**Dependencias.** Requiere: Arquitecturas (qué es un token, qué es la ventana de contexto). Alimenta:
N2, N5, y los núcleos de otras comisiones que necesiten un modelo corriendo.

**Definiciones imprescindibles.** Inferencia; motor/runtime; pesos; GGUF; servidor de inferencia y su
API; ventana de contexto; parámetros de muestreo; token por segundo (throughput) vs. latencia del
primer token.

**Ejemplos prácticos candidatos (operables en el banco).**
1. Montar y correr: `ollama pull qwen3.5:4b` → `ollama run` → la misma pregunta por API
   (`POST /api/generate`), con el paso 0 de H-IR-03.
2. Leer la ficha del modelo desde la API: `GET /api/tags` y `POST /api/show` — familia, tamaño de
   parámetros, cuantización, ventana de contexto (en el banco, `qwen3-coder:30b` declara
   `context_length: 262144`; verificado 2026-11-07).
3. El efecto de temperature: tres corridas de la misma consigna con 0.0 / 0.7 / 1.5 y comparación de
   salidas (reproducibilidad con seed donde el motor la soporte).
4. Multimodal mínimo: describir una imagen con `qwen2.5vl:7b` (en el banco), como puente al núcleo
   multimodal de otra comisión.

**Cuadros comparativos candidatos.** Motores (llama.cpp / Ollama / vLLM: público objetivo, hardware,
concurrencia, formato de pesos, API); «modelo vs. motor vs. aplicación» (qué cambia al cambiar cada
uno); parámetros de generación y su efecto.

**Preguntas guía y criterio que forman.** «¿Qué cosas cambian si cambio de motor sin cambiar de
modelo?» → separa artefacto de runtime. «¿Por qué la misma pregunta da respuestas distintas en dos
corridas?» → muestreo estocástico, criterio de reproducibilidad. «¿Cuándo me alcanza Ollama y cuándo
necesito vLLM?» → criterio de elección por concurrencia y hardware (Kwon et al. 2023).

### N2 — Cuantización y recursos

**Qué agrupa.** Precisión numérica (FP16/INT8/INT4), esquemas (K-quants de llama.cpp, GPTQ, AWQ),
estimación de memoria (pesos + caché KV), el trade-off calidad/memoria/velocidad, y cómo elegir
variante para un hardware dado.

**Por qué es núcleo.** Es la decisión que el operador local toma *siempre* (todo el banco corre Q4_K_M
o MXFP4 — E1 del listado de H-IR-02) y tiene criterio propio medible; dentro de N1 quedaría como receta
sin criterio.

**Dependencias.** Requiere N1 y Arquitecturas (parámetros, caché KV). Alimenta: elección de modelos en
N3–N5 y el núcleo de métricas (degradación por cuantización se mide).

**Definiciones imprescindibles.** Cuantización; bits por peso; Q4_K_M y la nomenclatura de llama.cpp;
GPTQ/AWQ como cuantización post-entrenamiento; caché KV; VRAM vs. RAM; offloading.

**Ejemplos prácticos candidatos.** 1) La cuenta de memoria: estimar el tamaño de `qwen3.5:4b` en Q4 vs.
FP16 y contrastar con el `size` real de `/api/tags`. 2) Misma consigna sobre dos cuantizaciones del
mismo modelo (pull de una variante Q8 de un modelo chico) midiendo tokens/s y comparando calidad de
salida. 3) Techo de hardware: qué modelos del banco entrarían en 8 / 16 / 32 GB, tabla hecha a mano por
el estudiante con los datos de `/api/show`.

**Cuadros comparativos candidatos.** Niveles de cuantización (bits, memoria relativa, pérdida típica,
cuándo usar); GPTQ vs. AWQ vs. K-quants (método, dónde se usa, formato).

**Preguntas guía.** «¿Por qué un modelo de 30B “pesa” 18 GB y no 60?» → bits por peso. «¿Qué pierdo al
bajar de Q8 a Q4 y cómo lo compruebo?» → criterio de evaluación empírica, no fe (Frantar et al. 2023;
Lin et al. 2023).

### N3 — Embeddings y representación semántica

**Qué agrupa.** Texto como vector; similitud (coseno, producto punto); modelos de embeddings y en qué
se diferencian de los generativos; dimensión; embeddings multilingües; benchmark MTEB como criterio de
elección.

**Por qué es núcleo.** Es el cambio conceptual (significado ≈ geometría) del que dependen N4 y N5
enteros; sin él la base vectorial es magia.

**Dependencias.** Requiere Arquitecturas (el transformer como codificador). Alimenta N4 y N5. Hoy
bloqueado en lo operable por H-IR-02.

**Definiciones imprescindibles.** Embedding; dimensión; similitud coseno; modelo bi-encoder;
normalización; distancia como inverso de afinidad semántica.

**Ejemplos prácticos candidatos** (tras resolver H-IR-02). 1) `POST /api/embed` sobre tres frases, dos
afines y una ajena: calcular el coseno a mano (una decena de líneas de Python) y ver que la geometría
coincide con la intuición. 2) El mismo trío en otro idioma: embeddings multilingües. 3) «Buscar sin
base»: similitud por fuerza bruta sobre 50 frases con NumPy — motivación de N4.

**Cuadros comparativos candidatos.** Modelo generativo vs. modelo de embeddings (entrada, salida, uso);
familias de embeddings abiertas (dimensión, multilingüe, tamaño, puntaje MTEB citado con fecha).

**Preguntas guía.** «¿Por qué no uso el modelo de chat para obtener vectores?» → especialización de
objetivos de entrenamiento. «¿Cómo elijo modelo de embeddings sin probarlos todos?» → benchmarks
públicos y su lectura crítica (Muennighoff et al. 2023).

### N4 — Bases de datos vectoriales e indexación

**Qué agrupa.** Qué resuelve una base vectorial (vecino más cercano aproximado a escala); índices (HNSW;
IVF y cuantización de producto como idea); exacto vs. aproximado y recall; métrica de distancia;
filtrado por metadatos; colecciones y upsert; panorama: FAISS (biblioteca), Qdrant/Chroma (servidor),
pgvector (extensión de una base relacional) y criterio de elección.

**Por qué es núcleo.** Tema nombrado literal por el pedido («base de datos vectoriales»), con conceptos
propios (ANN, recall, índice) que no pertenecen ni a embeddings ni a RAG.

**Dependencias.** Requiere N3. Alimenta N5.

**Definiciones imprescindibles.** Búsqueda de vecinos (kNN/ANN); recall; índice HNSW; colección;
metadato/payload; upsert; persistencia.

**Ejemplos prácticos candidatos.** 1) Chroma o Qdrant local (contenedor o proceso, sin GPU): crear
colección, insertar los vectores del ejemplo N3-3, consultar top-k y comparar con la fuerza bruta.
2) Filtrado: la misma consulta restringida por un metadato (`fuente = "capítulo 2"`). 3) pgvector:
la misma colección dentro de PostgreSQL, para el estudiante que ya conoce SQL — criterio «base nueva
vs. extensión de la que ya tengo». 4) Medir recall: exacto vs. HNSW sobre unas mil frases.

**Cuadros comparativos candidatos.** Fuerza bruta vs. IVF vs. HNSW (costo de construcción, costo de
consulta, recall); FAISS vs. Chroma vs. Qdrant vs. pgvector (tipo de pieza, persistencia, filtrado,
operación local).

**Preguntas guía.** «¿Cuándo me alcanza la fuerza bruta?» → tamaño del corpus como criterio. «¿Qué
estoy sacrificando con un índice aproximado y cómo lo mido?» → recall como contrato (Malkov &
Yashunin 2018; Johnson et al. 2019).

### N5 — RAG punta a punta (bajo el supuesto de H-IR-05)

**Qué agrupa.** La arquitectura recuperar-aumentar-generar; troceo (chunking) y sus decisiones; ingesta
del corpus; recuperación (vectorial, léxica BM25, híbrida) y reranking como idea; armado del contexto y
sus límites (posición de la evidencia); citado de fuentes; evaluación específica de RAG (¿la respuesta
está fundada en lo recuperado?); cuándo RAG y cuándo no (alternativa: contexto largo, ajuste fino).

**Por qué es núcleo.** Integra N1+N3+N4 en el caso de uso que justifica montarlos juntos; sus decisiones
(chunking, k, híbrido) tienen criterio propio que ningún núcleo previo enseña.

**Dependencias.** Requiere N1, N3, N4; se cruza con Métricas (evaluación) y con el núcleo de prompting
si otra comisión lo propone.

**Definiciones imprescindibles.** RAG; chunk; top-k; recuperación híbrida; reranking; groundedness
(respuesta fundada); alucinación en presencia de contexto.

**Ejemplos prácticos candidatos.** 1) RAG mínimo sin framework: ~80 líneas de Python sobre la API del
banco + la colección de N4, respondiendo preguntas sobre tres documentos propios con cita de la fuente
(didáctico: el estudiante ve cada pieza; coherente con el criterio de la casa de construir el artefacto
a mano antes de usar el framework). 2) El fracaso controlado: la misma pregunta sin recuperación →
alucinación o «no sé»; con recuperación → respuesta fundada. 3) Chunking: el mismo corpus troceado a
200 vs. 1000 caracteres, mismas preguntas, comparación de lo recuperado. 4) Posición de la evidencia:
mover el pasaje relevante al medio de un contexto largo y observar la degradación (Liu et al. 2023).

**Cuadros comparativos candidatos.** RAG vs. contexto largo vs. ajuste fino (costo, frescura del
conocimiento, trazabilidad de la fuente); recuperación vectorial vs. BM25 vs. híbrida (qué captura cada
una, cuándo falla).

**Preguntas guía.** «¿Por qué no meto todos mis documentos en el prompt?» → costo, ventana y “lost in
the middle”. «¿Cómo sé que la respuesta salió de mis documentos y no de la memoria del modelo?» →
criterio de evaluación con evidencia, el mismo que rige esta guía. «¿Qué cambio primero si el RAG
responde mal: el modelo, el chunking o el k?» → diagnóstico por etapas, una variable por vez.

---

## 3. Marco de referencia desde este dominio (encargo 3)

Propuesta para los catálogos propios de la guía (sigla propia y colisión declarada «de qué guía es cada
prefijo», conforme a `ia-db/indexes/10_Convenciones-y-Glosario.md` §4 del repo destino; los números
finales los integra la presidencia con las demás comisiones):

**Escenarios** (situaciones donde se aplica lo de mi dominio):
- ESC-A «Montar un asistente local privado»: elegir, descargar y servir un modelo en hardware propio
  (N1, N2).
- ESC-B «Preguntarle a mi corpus»: indexar documentos propios y responder con fuentes (N3, N4, N5).
- ESC-C «Elegir modelo y variante para un hardware dado»: la decisión de compra/descarga (N2, con
  Métricas).
- ESC-D «Exponer el modelo como servicio a una aplicación»: de `ollama run` a una API que otra app
  consume (N1; frontera con la guía 16 del destino, que se referencia y no se duplica — decisión
  cerrada del folio 002).

**Contextos** (donde cambian las respuestas):
- CTX-A Notebook sólo CPU (8–16 GB RAM): modelos ≤4B, Q4; todo ejemplo base debe correr acá (H-IR-04).
- CTX-B Estación con GPU chica (≤16 GB VRAM): modelos 7–14B, cuantización elegida con criterio.
- CTX-C Servidor compartido en red local: el banco del caso; endpoint remoto, `OLLAMA_HOST` (H-IR-03),
  concurrencia.
- CTX-D Contenedor / CI: reproducibilidad, modelos como artefactos versionados.

**Actores** (definidos por lo que deciden, como manda la convención de la casa):
- ACT «Estudiante-operador»: decide qué modelo y variante corre en su hardware; el destinatario del
  pedido.
- ACT «Desarrollador integrador»: decide cómo una aplicación consume la API del motor; no decide qué
  modelo corre.
- ACT «Curador del corpus»: decide qué entra al índice, cómo se trocea y qué metadatos llevan los
  documentos (ESC-B).
- ACT «Administrador del banco»: decide recursos, versiones del motor y qué modelos están disponibles
  para los demás actores.

---

## 4. Cadena de consecuencias §2 — corrida antes de las recomendaciones

**Sobre H-IR-01 (atar ejemplos a Ollama vs. abrir el espacio de motores).** (1) ¿Dónde cae? Atarlos
cae en el estudiante: pierde el criterio de elección que el objetivo exige; abrir el espacio *sin
banco* cae en el redactor: afirmaciones sin ejemplo operable. (2) ¿Cuánto pesa? En el banco sólo hay
Ollama observable (E1 de H-IR-02); montar vLLM exige GPU dedicada que MEDIOS no declara: esa medida
falta y se asienta como falta. (3) ¿Qué pierde la alternativa? La vía mixta (operar en Ollama, comparar
motores en cuadro con fuentes) pierde la vivencia de un segundo motor; la vía «sólo Ollama» pierde el
criterio; la vía «montar todos» pierde la audiencia (CTX-A). (4) ¿Reversible? La mixta es reversible:
si después se suma un segundo motor al banco, se agrega un ejemplo sin reescribir el núcleo. Condición
de revisión: aparición de un segundo motor observable en el banco. **Recomendación: la vía mixta.**

**Sobre H-IR-02 (cómo volver operables N3–N5).** (1) Opciones: (a) incorporar un modelo de embeddings
al banco; (b) embeddings por biblioteca local en Python (sentence-transformers) sin tocar el banco;
(c) dejar N3–N5 ilustrativos. (2) Dónde cae y peso: (a) cae en el administrador del banco, costo de un
pull (reversible, aditivo; esta comisión no lo ejecuta: fuera de su siembra y de su carta); (b) cae en
el estudiante: segunda pila de herramientas (Python/HF) además del motor, y en CTX-A es viable pero
duplica el vocabulario; (c) cae en el objetivo: viola «ejemplos prácticos» para un tema nombrado
literal. (3) Qué pierde cada una: (a) nada didáctico, una dependencia del administrador; (b) la
coherencia «todo por la misma API»; (c) el pedido. (4) Reversibilidad: (a) y (b) reversibles.
**Recomendación: (a), con (b) como camino declarado si el banco no se toca; (c) no cumple el pedido.**

---

## 5. Fuentes externas (encargo 4)

Verificadas por web el 2026-11-07:
- Yang, A. et al. (2025). *Qwen3 Technical Report*. arXiv:2505.09388. https://arxiv.org/abs/2505.09388
- Zhang, Y. et al. (2025). *Qwen3 Embedding: Advancing Text Embedding and Reranking Through Foundation
  Models*. arXiv:2506.05176. https://arxiv.org/abs/2506.05176

Citadas de conocimiento del dominio (canónicas; el enlace se verifica en la fase de redacción, antes de
entrar al texto de la guía — sin apartado donde no estoy seguro del apartado):
- Lewis, P. et al. (2020). *Retrieval-Augmented Generation for Knowledge-Intensive NLP Tasks*. NeurIPS
  2020. arXiv:2005.11401.
- Malkov, Y.; Yashunin, D. (2018). *Efficient and Robust Approximate Nearest Neighbor Search Using
  Hierarchical Navigable Small World Graphs*. IEEE TPAMI. arXiv:1603.09320.
- Johnson, J.; Douze, M.; Jégou, H. (2019). *Billion-Scale Similarity Search with GPUs*. IEEE
  Transactions on Big Data. arXiv:1702.08734.
- Jégou, H.; Douze, M.; Schmid, C. (2011). *Product Quantization for Nearest Neighbor Search*. IEEE
  TPAMI.
- Kwon, W. et al. (2023). *Efficient Memory Management for Large Language Model Serving with
  PagedAttention* (vLLM). SOSP 2023. arXiv:2309.06180.
- Frantar, E. et al. (2023). *GPTQ: Accurate Post-Training Quantization for Generative Pre-trained
  Transformers*. ICLR 2023. arXiv:2210.17323.
- Lin, J. et al. (2023). *AWQ: Activation-aware Weight Quantization for LLM Compression and
  Acceleration*. MLSys 2024. arXiv:2306.00978.
- Muennighoff, N. et al. (2023). *MTEB: Massive Text Embedding Benchmark*. EACL 2023. arXiv:2210.07316.
- Liu, N. F. et al. (2023). *Lost in the Middle: How Language Models Use Long Contexts*. TACL 2024.
  arXiv:2307.03172.
- Robertson, S.; Zaragoza, H. (2009). *The Probabilistic Relevance Framework: BM25 and Beyond*.
  Foundations and Trends in Information Retrieval.
- Documentación oficial (consultadas como obras vivas; fecha de uso 2026-11-07): Ollama
  (https://docs.ollama.com — API `generate`, `embed`, `show`), llama.cpp y formato GGUF
  (https://github.com/ggml-org/llama.cpp), Qdrant (https://qdrant.tech/documentation/), Chroma
  (https://docs.trychroma.com/), pgvector (https://github.com/pgvector/pgvector), FAISS
  (https://github.com/facebookresearch/faiss).

Verificaciones E1 propias de este informe (2026-11-07, contra el banco declarado en MEDIOS):
`GET /api/tags` → 200, once modelos (listado en H-IR-02); `GET /api/version` → `0.32.0-rc0`;
`qwen3-coder:30b`: `parameter_size 30.5B`, `quantization_level Q4_K_M`, `context_length 262144`;
`curl http://127.0.0.1:11434/api/tags` desde este contexto → exit 7 (H-IR-03).

---

## 6. Lo que revisé y está bien (hasta tres)

1. **El banco de ensayo sostiene los ejemplos de inferencia del pedido**: vivo, versión declarada, ocho
   modelos Qwen de 3B a 35B más un multimodal de visión, todos cuantizados — exactamente el material
   que N1, N2 y el núcleo multimodal necesitan (E1 en H-IR-02 y §5).
2. **La clase de objeto del contrato es la correcta**: la guía no existe (folio 002, ENUNCIADO, con
   comandos `wc -l` → 0 y `git status` → `??`), y la variante «diseño de una norma» con fuentes
   externas y dictamen por pregunta es la que esta comisión aplicó.
3. **Las convenciones de la casa prevén lo que el Profile exige**: catálogos ESC-/CTX-/ACT- por guía
   con la advertencia explícita de colisión entre prefijos (índice 10, §4 del destino); el marco de §3
   entra sin excepción a ningún conocimiento.

---

Dudas para quien pidió, en el formato del cierre, entregadas en el resultado de esta comisión a la
presidencia (tres: motor único vs. espacio de motores; piso de hardware del lector; incorporación de un
modelo de embeddings al banco).

Sigue: consolidación de informes, refutación y veredicto del jurado · presidencia de la mesa
