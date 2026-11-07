# Informe — Comisión de Arquitectura de sistemas IA y análisis de sistemas (ronda de estructura)

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-07 |
| Autor | comisión de arquitectura de sistemas IA y análisis de sistemas (ad hoc) |
| Corrige | — |

Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas: cabecera y §0 (líneas 1–111), la carta de despacho,
§2.2, §3.2, §3.3, §4. Además cargados: Cadena-De-Consecuencias 2.0 (§2, antes de recomendar entre
opciones); pliego operativo (evidencia/002, condensación de Expediente 1.0, Escalas-De-Juicio 1.2,
Mesa 1.1, Detencion-Y-Lote 1.1); Profile `Study-Guide-Documentation` y su RuleSet
(`RuleSet-Study-Guide`: Rule-All, Rule-Workflow, Rule-Evidences, Rule-Markdown, Rule-Documentation,
Rule-Indexing, Rule-Agents, Rule-Dual-Audience, Rule-Narrative-Voice); convenciones de la casa
(`ia-db/README.md` e `ia-db/indexes/10_Convenciones-y-Glosario.md` del repo destino); folios 001 y 002.

Mandato: refutar el temario, el marco y la estructura propuestos por el contrato de entrada, y entregar
los núcleos conceptuales de mi dominio. No me corresponden el contenido interno de cada tema, el estilo
editorial ni los veredictos de evidencia.

---

## 1. Hallazgos sobre el enunciado y el objetivo

Prefijo de familia: **ARQIA-** (propio de este informe; la presidencia lo consolida).

### ARQIA-01 · P1 · E2 · interpretativo — El banco de ensayo declarado no cubre «entrenarlos»

- **Ancla**: folio 001, línea 27 del testimonio: «los pasos necesarios para montar modelos,
  descargarlos, **entrenarlos**»; folio 002, campo MEDIOS: el único banco verificado es la API de
  Ollama (`GET /api/tags` → 200). Ollama es un motor de inferencia: no entrena ni ajusta modelos
  (documentación oficial, https://github.com/ollama/ollama — consulta 2026-11-07: el servidor sirve
  modelos empaquetados; no expone entrenamiento).
- **Qué falla**: «entrenar» es un tema que el pedido nombra. Si la única vía operable es Ollama, todo
  el eje de entrenamiento queda «ilustrativo» y la guía omite en la práctica un tema nombrado — eso,
  aguas abajo, es el P0 de la lectura del caso («omitir un tema que el pedido nombra»). Hoy es un hueco
  de medios del contrato, no todavía una omisión: por eso P1 y no P0.
- **Impacto si no se corrige**: el núcleo de entrenamiento (N3, abajo) sale sin ejemplo ejecutable y el
  estudiante no recibe la «experiencia teórico-práctica» que el Objetivo del pedido exige.
- **Dirección**: declarar en MEDIOS un segundo medio para ajuste fino reproducible en hardware chico
  (fine-tuning con PEFT/LoRA o QLoRA sobre un modelo ≤1.5B; Hu et al. 2021; Dettmers et al. 2023, ambas
  técnicas diseñadas justamente para GPU/CPU modestas), y reservar «ilustrativo» sólo para el
  pre-entrenamiento a escala. La viabilidad en CPU de un ajuste LoRA sobre un modelo de ~0.5B es
  verificable con una corrida corta; no está demostrada la inviabilidad.

### ARQIA-02 · P1 · E3 · interpretativo — «Material de consulta y referencia» sobre un catálogo volátil, sin capa de estabilidad

- **Ancla (contraejemplo construido)**: el pedido exige que el material «sirva de consulta y también de
  referencia» (folio 001, línea 37). Un lector que en 2027 ejecute `ollama pull <tag>` con un tag
  transcripto de la guía puede encontrar el tag retirado o reemplazado: el recorrido queda sin salida y
  ninguna sección de la estructura propuesta lo prevé. Señal de contexto: una búsqueda web del
  2026-11-07 sobre el catálogo Qwen/Ollama devolvió sólo fuentes terciarias inconsistentes entre sí
  (misma cifra repetida en páginas clonadas, fechas de versión contradictorias) — lo registro como
  señal de volatilidad del catálogo, no como fuente de ninguna afirmación de la guía.
- **Impacto**: la guía envejece entera, no por partes; retrabajo del conjunto cuando rote el catálogo.
- **Dirección**: separar en la estructura una **capa estable** (conceptos, arquitecturas, métricas,
  procedimientos) de una **capa volátil** (inventario de modelos concretos, tags, cifras de
  benchmarks), concentrando la volátil en un único documento de inventario con fecha de validación y
  versiones fijadas por ejemplo (tag exacto + fecha de verificación), conforme a `last_review` del
  frontmatter normado de la casa (ia-db índice 10, §1.1). Cada ejemplo operable fija su versión.

### ARQIA-03 · P1 · E2 · interpretativo — «Autocontenida y no delta» (pedido) contra «interconectado» (Profile): sin definición operativa, divergencia entre redactores

- **Ancla**: folio 001, línea 45: «Debe ser autocontenida y no delta»; Profile
  `Study-Guide-Documentation`, criterio «Interconectado: cada documento enlaza con los que lo preceden
  y lo continúan» y «los ejes se definen una sola vez, en documentos propios, y el resto de la guía los
  referencia».
- **Qué falla**: ambas cláusulas rigen y admiten lecturas opuestas (¿repetir definiciones en cada
  documento, o nunca repetirlas y enlazar?). Con redactores en paralelo en fase 3, cada uno resolverá
  distinto: es exactamente el P1 del pliego («interpretación divergente entre quienes lo aplican»).
- **Impacto**: conjunto documental mezclado — unos documentos enciclopédicos y otros delta — que la
  ronda 2 obligaría a rehacer.
- **Dirección**: el documento de cohesión global define «autocontenido» de forma operativa antes de la
  fase 3. Propuesta a debatir: autocontenido = legible de punta a punta sin abrir otro documento para
  **seguir el hilo** (toda sigla se expande en primera aparición y todo término del glosario se enlaza),
  y no-delta = ningún documento exige haber leído una versión anterior; las definiciones normativas
  viven una sola vez (marco de referencia/glosario) y se citan.

### ARQIA-04 · P2 · E2 · interpretativo — «Tipo Qwen» se funda en una frase descriptiva: elección de medio, no restricción de alcance

- **Ancla**: folio 001, línea 27: «Actualmente tenemos corriendo diferentes modelos de qween» — frase
  descriptiva del estado, no prescriptiva. El filtro «Comportamiento no es restricción»
  (Mesa-De-Expertos-A-Pedido §3.3) manda: lo fijo es un requisito con su literal; lo que el entorno
  hace hoy es variable. La carta y el contrato derivan de «Contexto» la cláusula «ejemplos operables
  sobre modelos open source tipo Qwen».
- **Qué falla**: si «tipo Qwen» se lee como alcance (sólo Qwen), se recorta sin pedido la cláusula
  «basarse en las tendencias del mercado y los estándares de la industria» (folio 001, línea 39), que
  exige comparar familias abiertas (Qwen, Llama, Mistral, Gemma, DeepSeek...).
- **Impacto**: cuadros comparativos empobrecidos y criterio de selección de modelo no formado.
- **Dirección**: declarar Qwen como **banco de ensayo disponible y medido** (E1 del contrato) donde
  corren los ejemplos, y mantener el alcance conceptual y comparativo sobre el ecosistema open source
  completo (documental, sin corridas sobre lo que el banco no tiene). Es la lectura que menos agrega.

### ARQIA-05 · P2 · E2 · enumerable — La estructura tipo del Profile no tiene lugar para las «respuestas explicativas que realimenten el texto»

- **Ancla**: folio 001, línea 37: «preguntas guías formadoras de conceptos que formen criterio
  articuladas con **respuestas explicativas y que realimenten el texto y ejemplos**»; Profile,
  «Estructura de cada documento temático», sección 4: «Preguntas guía — las que el lector debe poder
  responder» (sin respuestas).
- **Impacto**: cada redactor inventará dónde poner las respuestas (inline, anexo, ausentes); el pedido
  nombra la pieza y la estructura no la asigna.
- **Dirección**: extender el patrón de seis secciones del documento temático con una subsección
  «Respuestas razonadas» (o anexo por documento) que responda cada pregunta guía y enlace de vuelta a
  la sección y al ejemplo que la motivan. Es aditivo y no contradice el Profile (su lista no es
  cerrada); no requiere ficha de excepción.

### ARQIA-06 · P2 · E1 · enumerable — La guía nueva necesita prefijo `doc_id` propio; `IAM-` está libre

- **Ancla (comando y salida)**: las guías estructuradas de la casa identifican documentos por
  `doc_id` con prefijo (ia-db índice 10 §1.1). Barrido de prefijos existentes en el destino:
  `grep -rh '^doc_id:' <worktree-guia>/Guides/ | sed 's/doc_id: *//' | grep -oE '^[A-Za-z]+' | sort | uniq -c | sort -rn`
  → TEM 86, DOC 40, FAM 28, MARCO 17, ANEXO 13, DEMO 12, ANX 11, GUIA 8, GF 7, E 7, ARQ 7, MET 6,
  MAPA 4, ADR 4, GP 3, GHF 3, GHA 2, THREAT 1, TESTPLAN 1, TESTCASES 1. Colisión del candidato:
  `grep -rln 'IAM-' <worktree-guia>/Guides | wc -l` → `0`; ídem sobre `ia-db/` del repo de
  documentación → `0`.
- **Impacto si no se fija**: documentos de la fase 3 con `doc_id` ad hoc o en colisión con `ARQ-`/`E-`.
- **Dirección**: fijar el prefijo del conjunto (propongo `IAM-`, libre por el comando de arriba) y el
  vocabulario `doc_type` del bloque normado (tema | marco-de-referencia | mapa | anexo | indice) antes
  de despachar redactores.

### ARQIA-07 · P2 · E2 · interpretativo — El recorrido de lectura no está declarado como entregable de la estructura

- **Ancla**: Profile, «Resultado esperado»: «conjunto documental navegable desde su README... recorrer
  la temática de forma ordenada»; restricción dura del contrato: audiencia principiante. El contrato
  (folio 002) fija el documento raíz como «índice y mapa de lectura», pero ninguna cláusula exige que
  el orden de lectura respete las **dependencias entre núcleos**.
- **Impacto**: un principiante que entre por «bases vectoriales» sin tokens/embeddings no forma
  criterio; la audiencia principiante se rompe por orden, no por contenido.
- **Dirección**: el documento de cohesión global declara el grafo de dependencias entre núcleos (lo
  entrego en §2) y el documento raíz deriva de él la ruta de lectura; ningún documento temático asume
  material que el grafo no le da por leído.

### ARQIA-08 · P3 · E2 · enumerable — Frase trunca del pedido sin función asignable

- **Ancla**: folio 001, línea 27: «Actualmente tenemos funcionando modelos open sorce con el modelo.»
  — la frase termina sin el nombre del modelo.
- **Impacto**: nulo si se trata como descriptiva (duplicada por la frase siguiente sobre Qwen); el
  enunciado no debe asignarle función inventada.
- **Dirección**: registrarla como ilegible en la tabla frase→función; pregunta de cortesía al lote
  (¿nombraba otro modelo del entorno?), sin bloquear nada.

---

## 2. Núcleos conceptuales del dominio (entregable 1 y 2)

Criterio de núcleo: agrupa ideas con dependencia semántica fuerte entre sí y una interfaz chica hacia
afuera (regla de descomposición del pedido, folio 001, líneas 49–58); no es fragmento porque quitarle
una parte rompe su coherencia interna, y no absorbe a otro porque la dependencia entre ambos es
direccional y nombrable. Ocho núcleos temáticos más dos piezas estructurales del Profile.

Cobertura contra los temas que el pedido nombra (restricción dura: ninguno omitido): montar/descargar
→ N4; entrenar → N3; arquitecturas y transformers → N2; métricas → N5; motor de inferencia → N4; NLP →
N1; IA generativa → N2/N3; multimodales → N7; bases vectoriales → N6; términos asociados → glosario
del marco (M2).

### N1 — Representación del lenguaje (fundamentos de NLP)

- **Agrupa**: texto como datos; tokens y tokenización (BPE, SentencePiece); vocabularios; embeddings
  densos; la idea de espacio semántico. **Por qué es núcleo**: todo lo demás consume su vocabulario;
  no tiene dependencias (raíz del grafo).
- **Depende de**: — . **Lo dependen**: N2, N6.
- **Definiciones imprescindibles**: token, tokenizador, vocabulario, embedding, dimensión, ventana de
  contexto (como presupuesto de tokens), corpus.
- **Ejemplos operables**: (a) tokenizar la misma frase en español e inglés con el tokenizador de un
  modelo Qwen local y contar tokens (API de Ollama o `tokenizers` de Hugging Face), para ver que el
  costo depende del idioma; (b) obtener embeddings de tres frases con un modelo de embeddings local
  (p. ej. vía `/api/embed` de Ollama) y calcular similitud coseno a mano.
- **Cuadros candidatos**: BPE vs WordPiece vs SentencePiece; palabra vs subpalabra vs carácter.
- **Preguntas guía → criterio**: «¿Por qué el mismo texto cuesta distinto número de tokens según el
  modelo?» → criterio de estimación de costos y de ventana; «¿Qué significa que dos frases estén
  "cerca"?» → criterio para elegir modelo de embeddings (base de N6).
- **Fuentes**: Sennrich et al. 2016 (BPE, arXiv:1508.07909); Reimers & Gurevych 2019
  (Sentence-BERT, arXiv:1908.10084).

### N2 — Arquitectura Transformer y familias de modelos

- **Agrupa**: atención y autoatención; encoder/decoder/decoder-only; posicionales; MoE; de BERT a los
  LLM generativos; qué es «generativo» y qué es un parámetro. **Por qué es núcleo**: es la física de
  todo el resto; separarlo de N3 evita mezclar «qué es» con «cómo se fabrica».
- **Depende de**: N1. **Lo dependen**: N3, N4, N7.
- **Definiciones imprescindibles**: atención, cabeza, capa, parámetro, decoder-only, autoregresivo,
  MoE (parámetros totales vs activos), ventana de contexto (como arquitectura).
- **Ejemplos operables**: (a) comparar en el banco local un modelo denso y uno MoE de la misma familia
  (memoria ocupada vs velocidad, `ollama ps`); (b) demostrar la autoregresión pidiendo generación
  token a token con `stream` y observando la salida incremental.
- **Cuadros candidatos**: encoder-only vs encoder-decoder vs decoder-only (ejemplo, uso, por qué);
  denso vs MoE.
- **Preguntas guía → criterio**: «¿Por qué un modelo de 30B MoE puede responder más rápido que uno
  denso de 14B?» → criterio de selección por hardware; «¿Qué limita la ventana de contexto?» →
  criterio para dimensionar prompts y RAG.
- **Fuentes**: Vaswani et al. 2017 (arXiv:1706.03762); Devlin et al. 2019 (BERT, arXiv:1810.04805);
  Brown et al. 2020 (GPT-3, arXiv:2005.14165); Shazeer et al. 2017 (MoE, arXiv:1701.06538); Qwen
  Team 2025 (Qwen2.5 Technical Report, arXiv:2412.15115; Qwen3 Technical Report, arXiv:2505.09388).

### N3 — Ciclo de vida de entrenamiento y alineación

- **Agrupa**: pre-entrenamiento y leyes de escala; fine-tuning supervisado; alineación (RLHF, DPO);
  ajuste eficiente (PEFT: LoRA, QLoRA); datasets y contaminación. **Por qué es núcleo**: responde
  «entrenarlos» del pedido con una sola historia causal, del corpus crudo al modelo instruido.
- **Depende de**: N2. **Lo dependen**: N5, N8.
- **Definiciones imprescindibles**: pre-entrenamiento, fine-tuning, instruct vs base, RLHF, DPO, LoRA
  (rango, adaptadores), cuantización en entrenamiento (QLoRA), época, learning rate, overfitting.
- **Ejemplos operables** (sujeto a ARQIA-01): (a) ajuste LoRA/QLoRA de un modelo ≤1.5B sobre un
  dataset chico de instrucciones en español (transformers+PEFT), con métricas antes/después;
  (b) comparar en el banco la variante base y la instruct del mismo tamaño ante la misma instrucción;
  (c) ilustrativo y marcado como tal: órdenes de magnitud del pre-entrenamiento (Hoffmann et al. 2022).
- **Cuadros candidatos**: pre-entrenamiento vs SFT vs alineación (datos, costo, qué cambia);
  full fine-tune vs LoRA vs QLoRA (memoria, calidad, cuándo).
- **Preguntas guía → criterio**: «¿Cuándo conviene ajustar un modelo y cuándo basta RAG o prompt?» →
  criterio de intervención (se cruza con N6); «¿Por qué un modelo instruido obedece y uno base
  completa?» → criterio para elegir variante.
- **Fuentes**: Kaplan et al. 2020 (arXiv:2001.08361); Hoffmann et al. 2022 (Chinchilla,
  arXiv:2203.15556); Ouyang et al. 2022 (InstructGPT/RLHF, arXiv:2203.02155); Rafailov et al. 2023
  (DPO, arXiv:2305.18290); Hu et al. 2021 (LoRA, arXiv:2106.09685); Dettmers et al. 2023 (QLoRA,
  arXiv:2305.14314).

### N4 — Inferencia y despliegue local

- **Agrupa**: motores de inferencia (llama.cpp/Ollama; vLLM como contraste de servidor); cuantización
  post-entrenamiento y GGUF; KV-cache; parámetros de muestreo (temperature, top-p); dimensionamiento
  de hardware; montar/descargar/servir. **Por qué es núcleo**: es el eje «manos a la obra» del pedido
  (montar, descargar, motor de inferencia) y su interfaz con N2 es sólo «qué forma tiene el modelo».
- **Depende de**: N2. **Lo dependen**: N5, N6.
- **Definiciones imprescindibles**: motor de inferencia, cuantización (Q4/Q8, pérdida vs memoria),
  GGUF, KV-cache, muestreo, tokens/s, prefill vs decode.
- **Ejemplos operables**: (a) montar Ollama y descargar un Qwen chico con tag fijado y fecha de
  verificación (ARQIA-02); (b) misma pregunta a dos cuantizaciones del mismo modelo: memoria, tokens/s
  y calidad percibida; (c) barrido de `temperature` sobre un prompt fijo para formar criterio de
  determinismo; (d) medición simple de tokens/s con la API (`eval_count`/`eval_duration`).
- **Cuadros candidatos**: llama.cpp/Ollama vs vLLM (lote de a uno vs servicio concurrente, PagedAttention);
  tabla cuantización → memoria → degradación.
- **Preguntas guía → criterio**: «¿Qué modelo entra en mi hardware y a qué costo de calidad?» →
  criterio de dimensionamiento; «¿Cuándo un motor local deja de alcanzar?» → criterio de paso a
  servicio (enlaza con guía 16, que se referencia y no se duplica).
- **Fuentes**: Kwon et al. 2023 (vLLM/PagedAttention, arXiv:2309.06180); proyecto llama.cpp y formato
  GGUF (https://github.com/ggml-org/llama.cpp — consulta 2026-11-07); documentación de Ollama
  (https://github.com/ollama/ollama — consulta 2026-11-07); Dettmers et al. 2022 (LLM.int8,
  arXiv:2208.07339).

### N5 — Evaluación y métricas

- **Agrupa**: perplejidad; métricas de solapamiento (BLEU, ROUGE) y sus límites; benchmarks (MMLU,
  HELM) y contaminación; evaluación humana y LLM-como-juez; evaluación propia sobre casos del dominio.
  **Por qué es núcleo**: sin él, ni N3 ni N4 pueden afirmar «mejor»; es la bisagra con la regla dura
  «toda afirmación respaldada por evidencia verificable».
- **Depende de**: N3, N4. **Lo dependen**: N8.
- **Definiciones imprescindibles**: perplejidad, BLEU, ROUGE, benchmark, contaminación de datos,
  LLM-judge, evaluación offline vs online.
- **Ejemplos operables**: (a) mini-set de 20 preguntas propias del dominio del lector corrido contra
  dos modelos del banco, con planilla de resultados; (b) usar un modelo local como juez del ejercicio
  (a) y contrastar con el juicio humano, mostrando el sesgo del juez.
- **Cuadros candidatos**: métrica → qué mide → qué no mide → cuándo usarla; benchmark público vs
  evaluación propia.
- **Preguntas guía → criterio**: «¿Por qué un buen puntaje en MMLU no garantiza mi caso de uso?» →
  criterio de desconfianza informada frente a tablas de líderes; «¿Cómo decido entre dos modelos para
  mi tarea?» → criterio de evaluación propia reproducible.
- **Fuentes**: Papineni et al. 2002 (BLEU, ACL); Lin 2004 (ROUGE, ACL); Hendrycks et al. 2021 (MMLU,
  arXiv:2009.03300); Liang et al. 2022 (HELM, arXiv:2211.09110); Zheng et al. 2023 (LLM-as-a-judge,
  arXiv:2306.05685).

### N6 — Embeddings aplicados, bases vectoriales y RAG

- **Agrupa**: búsqueda semántica; índices ANN (HNSW); bases vectoriales (FAISS como biblioteca,
  pgvector/Qdrant como servicio); pipeline RAG (chunking, recuperación, aumentación); cuándo RAG y
  cuándo fine-tuning. **Por qué es núcleo**: el pedido nombra «bases de datos vectoriales» y su
  coherencia interna (representar→indexar→recuperar→aumentar) es una sola cadena causal.
- **Depende de**: N1, N4. **Lo dependen**: N8.
- **Definiciones imprescindibles**: vector índice, ANN, recall@k, HNSW, chunk, recuperador, contexto
  aumentado, alucinación (como riesgo que RAG mitiga y no elimina).
- **Ejemplos operables**: (a) indexar un puñado de documentos propios con un modelo de embeddings
  local y responder preguntas con y sin recuperación, comparando; (b) variar el tamaño de chunk y
  medir el efecto en la respuesta; (c) FAISS en memoria vs pgvector como servicio, mismo dataset.
- **Cuadros candidatos**: FAISS vs pgvector vs Qdrant (biblioteca/servicio, filtros, operación);
  RAG vs fine-tuning vs prompt largo (costo, frescura del dato, cuándo).
- **Preguntas guía → criterio**: «¿Cuándo el error está en el recuperador y cuándo en el generador?» →
  criterio de diagnóstico por etapa; «¿Qué gano y qué pierdo al achicar los chunks?» → criterio de
  diseño de pipeline.
- **Fuentes**: Lewis et al. 2020 (RAG, arXiv:2005.11401); Malkov & Yashunin 2016 (HNSW,
  arXiv:1603.09320); Johnson, Douze & Jégou 2017 (FAISS, arXiv:1702.08734); Reimers & Gurevych 2019
  (arXiv:1908.10084).

### N7 — Modelos multimodales

- **Agrupa**: representaciones compartidas texto-imagen (CLIP); modelos visión-lenguaje
  (familia Qwen-VL); audio y voz a texto; qué cambia en tokenización, inferencia y evaluación cuando
  entra otra modalidad. **Por qué es núcleo**: el pedido lo nombra y su dependencia con N2 es
  direccional (extiende la arquitectura, no la redefine).
- **Depende de**: N2 (y usa N4 para correr). **Lo dependen**: N8.
- **Definiciones imprescindibles**: modalidad, encoder visual, proyección, VQA, OCR por modelo,
  tokens de imagen.
- **Ejemplos operables**: (a) describir una imagen local con un modelo visión-lenguaje del banco
  (si el banco lo tiene; si no, se declara y el ejemplo queda condicionado al inventario de ARQIA-02);
  (b) el mismo documento escaneado por OCR clásico vs modelo multimodal, comparando.
- **Cuadros candidatos**: unimodal vs multimodal (qué agrega, qué cuesta); tareas multimodales típicas.
- **Preguntas guía → criterio**: «¿Cuándo un problema de imagen es de un modelo multimodal y cuándo de
  visión clásica?» → criterio de selección de herramienta.
- **Fuentes**: Radford et al. 2021 (CLIP, arXiv:2103.00020); Qwen Team 2024–2025 (Qwen2-VL,
  arXiv:2409.12191).

### N8 — Ecosistema abierto, selección de modelo y gobernanza

- **Agrupa**: el mapa de familias abiertas (Qwen, Llama, Mistral, Gemma, DeepSeek) y sus licencias
  (open weights vs open source); Hugging Face como registro; criterio integral de selección (tarea ×
  hardware × licencia × evaluación propia); marcos de gobernanza y riesgo. **Por qué es núcleo**: es
  donde «tendencias del mercado y estándares de la industria» (pedido) se vuelve criterio y no
  catálogo; integra N3–N7. Es también la **capa volátil** de ARQIA-02: concentra lo que caduca.
- **Depende de**: N3, N4, N5, N6, N7 (cierre e integración).
- **Definiciones imprescindibles**: open weights, licencia de modelo, model card, destilación,
  ventana de soporte de una familia.
- **Ejemplos operables**: (a) leer la model card de un modelo del banco y extraer licencia, datos
  declarados y límites; (b) ejercicio de selección guiada: tarea dada → candidatos → evaluación propia
  de N5 → decisión documentada.
- **Cuadros candidatos**: familias abiertas (tamaños, licencia, multimodalidad, fecha de corte del
  cuadro); marcos de gobernanza (NIST AI RMF vs ISO/IEC 42001 vs AI Act: naturaleza, obligatoriedad,
  a quién aplica).
- **Preguntas guía → criterio**: «¿Puedo usar este modelo en este producto?» → criterio
  licencia-riesgo; «¿Qué reviso cuando sale una familia nueva?» → criterio de actualización del
  inventario (evento de cierre del documento volátil).
- **Fuentes**: NIST AI 100-1, AI Risk Management Framework 1.0, 2023
  (https://doi.org/10.6028/NIST.AI.100-1); ISO/IEC 42001:2023 (sistema de gestión de IA); Reglamento
  (UE) 2024/1689 (AI Act); Mitchell et al. 2019 (Model Cards, arXiv:1810.03993).

### Piezas estructurales (no son núcleos temáticos)

- **M1 — Marco de referencia** (escenarios/contextos/actores, §3 de este informe) y **mapa
  conceptual**: exigidos por el Profile; se escriben antes que los núcleos.
- **M2 — Documento de cohesión global + glosario**: exigido por la regla de descomposición del pedido;
  lleva el grafo de dependencias (abajo), la definición operativa de «autocontenido» (ARQIA-03), el
  prefijo `doc_id` (ARQIA-06) y la política capa estable/volátil (ARQIA-02).

**Grafo de dependencias** (ruta de lectura derivada, ARQIA-07):
`N1 → N2 → {N3, N4, N7} → N5 → N6 → N8`, con N6 necesitando N1+N4 y N8 integrando todo.
Ruta sugerida para principiante: M1 → N1 → N2 → N4 → N3 → N5 → N6 → N7 → N8 → anexos.

**Cadena de consecuencias (§2, corrida antes de recomendar la descomposición).** Opción A: ocho
núcleos + dos piezas (recomendada). Opción B: cuatro macro-núcleos (fundamentos / fabricar / operar /
aplicar). (1) ¿Dónde cae? A: en el lector, más documentos que navegar, y en la fase 3, ocho encargos;
B: en cada redactor, documentos de doble tema. (2) ¿Cuánto pesa? A: diez documentos temáticos,
dentro del patrón de la casa (las guías estructuradas del destino tienen 13–17 piezas por corpus,
ia-db índice 10, tabla de siglas); B: documentos de más de un eje causal, que el propio pedido prohíbe
(«no fragmentes únicamente por extensión» vale también al revés: no fusionar por brevedad ideas sin
afinidad — entrenamiento e inferencia tienen actores y hardware distintos). (3) ¿Qué pierde la
alternativa? A pierde compacidad; B pierde la validación independiente por núcleo que la regla del
pedido exige. (4) ¿Reversible? Fusionar núcleos después es barato; partir documentos escritos es
retrabajo. A es la reversible. Recomiendo A.

---

## 3. Marco de referencia propuesto (entregable 3)

Con los catálogos `ESC-/CTX-/ACT-` de la casa (ia-db índice 10; decisión cerrada del contrato).

**Escenarios** (situaciones donde se aplica el tema):

| ID | Escenario | Núcleos que lo sirven |
| --- | --- | --- |
| ESC-01 | Entender y elegir un modelo para una tarea | N2, N5, N8 |
| ESC-02 | Montar inferencia local y servirla | N4 |
| ESC-03 | Construir un asistente sobre documentos propios (RAG) | N1, N6 |
| ESC-04 | Adaptar un modelo a un dominio (fine-tuning) | N3, N5 |
| ESC-05 | Evaluar, comparar y decidir con evidencia | N5, N8 |
| ESC-06 | Trabajar con imágenes/audio además de texto | N7 |
| ESC-07 | Integrar el modelo en una aplicación | referencia a la guía 16 (no se duplica) |

**Contextos** (variantes que cambian las respuestas): CTX-01 equipo de escritorio, CPU o GPU chica
(el del banco de ensayo); CTX-02 servidor con GPU dedicada; CTX-03 sólo API de terceros (sin pesos
locales); CTX-04 datos sensibles / operación sin salida a internet. Cada documento temático dice qué
cambia por contexto; los ejemplos operables de esta guía corren en CTX-01 (medio verificado del
contrato).

**Actores**: ACT-01 estudiante/lector (destinatario; decide qué aprender y qué probar); ACT-02
desarrollador integrador (consume modelos, decide prompt/RAG/fine-tune); ACT-03 operador de
infraestructura (dimensiona y sirve, dueño de CTX-01/02); ACT-04 evaluador (dueño de N5, acepta o
rechaza con evidencia); ACT-05 responsable de datos y cumplimiento (dueño de licencias y gobernanza,
N8). El Profile pide que cada documento ubique al lector: qué le toca decidir a cada actor y qué no.

---

## 4. Lo que revisé y está bien (hasta tres)

1. La normalización de la ruta del entregable (folio 002, ENUNCIADO): el pedido escribe una ruta con
   «Lab-Documentos/Lab-Documentos»; el contrato toma la lectura que menos agrega (raíz
   `Guides/IA/IA-Model/IA-Model-Guide.md` como índice del conjunto) y la deja a ratificación de esta
   ronda. La ratifico desde mi dominio: coincide con el patrón estructural de la casa (marco → mapa →
   temas → anexos).
2. La decisión cerrada de referenciar la guía 16 sin duplicarla: coherente con Rule-Documentation
   (única fuente de verdad) y con mi ESC-07.
3. El barrido del índice de convenciones con comando y descartes motivados (folio 002, CONVENCIONES;
   evidencia 003): los descartes de dominio .NET/SQL no dejan hueco en mi dominio.

---

## 5. Solicitud de convocatoria (fuera de mi competencia)

- **Señal**: folio 001, línea 37 — «preguntas guías formadoras de conceptos... articuladas con
  respuestas explicativas y que realimenten el texto y ejemplos»; y línea 39 — «editores de material
  bibliográfico, académicos y de libros». **Ubicación**: testimonio del pedido, sección Solicitudes.
  El diseño didáctico de esa realimentación (secuencia pregunta→respuesta→texto) y su edición son
  competencia de una comisión de pedagogía/edición académica, no de esta. Emito solicitud de
  convocatoria; mi ARQIA-05 sólo reserva el lugar estructural de la pieza.

---

## 6. Dudas para quien pidió (formato del lote)

| # | Rol · Pregunta | Por qué | Prioridad | SI NO RESPONDÉS |
| --- | --- | --- | --- | --- |
| 1 | PO · ¿El ejemplo de fine-tuning puede asumir sólo CPU/GPU chica del banco actual, o hay una GPU disponible para la fase 3? | Define el tamaño de modelo y el tiempo del ejemplo operable de N3 (ARQIA-01) | P1 | Rige CPU/GPU chica: ejemplo QLoRA/LoRA con modelo ≤1.5B y duración declarada; nada queda bloqueado |
| 2 | PO · ¿«Tipo Qwen» limita los ejemplos a Qwen o es sólo el banco disponible? | Afecta el alcance comparativo de N8 y los cuadros (ARQIA-04) | P2 | Rige: Qwen como banco de corridas, comparativas documentales con otras familias abiertas |
| 3 | PO · La frase trunca «Actualmente tenemos funcionando modelos open sorce con el modelo.» ¿nombraba algún otro modelo del entorno? | Sólo cortesía de fidelidad del enunciado (ARQIA-08) | P3 | Se trata como descriptiva y duplicada por la frase siguiente; nada bloqueado |

---

## 7. Fuentes externas citadas (consolidado)

Papers: Vaswani et al. 2017 (arXiv:1706.03762) · Devlin et al. 2019 (arXiv:1810.04805) · Brown et al.
2020 (arXiv:2005.14165) · Sennrich et al. 2016 (arXiv:1508.07909) · Shazeer et al. 2017
(arXiv:1701.06538) · Kaplan et al. 2020 (arXiv:2001.08361) · Hoffmann et al. 2022 (arXiv:2203.15556) ·
Ouyang et al. 2022 (arXiv:2203.02155) · Rafailov et al. 2023 (arXiv:2305.18290) · Hu et al. 2021
(arXiv:2106.09685) · Dettmers et al. 2023 (arXiv:2305.14314) · Dettmers et al. 2022
(arXiv:2208.07339) · Kwon et al. 2023 (arXiv:2309.06180) · Lewis et al. 2020 (arXiv:2005.11401) ·
Malkov & Yashunin 2016 (arXiv:1603.09320) · Johnson et al. 2017 (arXiv:1702.08734) · Reimers &
Gurevych 2019 (arXiv:1908.10084) · Radford et al. 2021 (arXiv:2103.00020) · Qwen Team 2024–2025
(arXiv:2409.12191, 2412.15115, 2505.09388) · Papineni et al. 2002 (BLEU, ACL) · Lin 2004 (ROUGE, ACL)
· Hendrycks et al. 2021 (arXiv:2009.03300) · Liang et al. 2022 (arXiv:2211.09110) · Zheng et al. 2023
(arXiv:2306.05685) · Mitchell et al. 2019 (arXiv:1810.03993).
Normas y docs oficiales: NIST AI 100-1 (AI RMF 1.0, 2023, https://doi.org/10.6028/NIST.AI.100-1) ·
ISO/IEC 42001:2023 · Reglamento (UE) 2024/1689 · Ollama (https://github.com/ollama/ollama, consulta
2026-11-07) · llama.cpp/GGUF (https://github.com/ggml-org/llama.cpp, consulta 2026-11-07).
Registro de investigación: WebSearch del 2026-11-07 sobre catálogo Qwen/Ollama — resultados terciarios
inconsistentes; usados sólo como señal de volatilidad (ARQIA-02), no como fuente de afirmaciones.

Sigue: incorporación de este informe como folio y veredicto del jurado · presidencia de la mesa
