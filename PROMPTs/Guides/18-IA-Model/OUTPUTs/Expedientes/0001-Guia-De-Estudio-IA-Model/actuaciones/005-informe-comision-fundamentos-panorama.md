# Informe — Comisión de Fundamentos, arquitecturas y panorama de modelos

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-07 |
| Autor | comisión de fundamentos, arquitecturas y panorama (ronda de estructura) |
| Corrige | — |

Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas: cabecera y §0 (líneas 1–111), la carta (evidencia
004), §2.2, §3.2, §3.3 y §4. Además cargados: Cadena-De-Consecuencias 2.0 (§2, antes de recomendar
entre opciones). Excepcion-A-Un-Conocimiento no se cargó: esta comisión no propone apartarse de
ninguna convención que rige. Insumos leídos: folios 001 y 002, pliego operativo (evidencia 002),
Profile Study-Guide-Documentation, ia-db README e índice 10 del repo destino.

Prefijo de hallazgos de este informe: `FP-` (fundamentos y panorama).

---

## 1. Hallazgos sobre el enunciado y el objetivo

Lectura P0–P3 del caso (carta y folio 002): P0 viola restricción dura; P1 hueco/solapamiento con
retrabajo del conjunto o ejemplo inviable; P2 pérdida acotada; P3 claridad.

### FP-01 · P1 · E2 · interpretativo — «Modelos IA generativas, modelos multimodales» incluye generación de imagen; el temario que se perfila es sólo-lenguaje

**Cita**: folio 001, bloque de testimonio, sección «Contexto»: «…modelos IA generativas, modelos
multimodales, arquitecturas, base de datos vectoriales…». El contrato (folio 002, PREGUNTAS DEL CASO
4) baja los ejemplos a «montar, descargar, entrenar, inferir, medir, RAG», todos verbos de modelo de
lenguaje; ninguna pregunta del caso nombra la generación de imagen o audio.

**Qué falla**: en la industria, «modelos generativos» cubre al menos dos familias arquitectónicas:
autoregresiva (LLM) y de difusión (imagen/audio/video) (Rombach et al., 2022, «High-Resolution Image
Synthesis with Latent Diffusion Models», CVPR). Y «multimodal» cubre tanto comprensión
(visión-lenguaje, p. ej. Qwen2.5-VL — Bai et al., 2025, arXiv:2502.13923) como generación no textual.
Si el temario sale sólo-lenguaje, omite un tema que el pedido nombra: eso es la definición de P0 del
contrato. Lo marco P1 porque todavía no hay temario que lo omita: es el hueco que obligaría a
retrabajo si no se fija ahora.

**Impacto si no se corrige**: temario cerrado en ronda 1 sin difusión ni multimodal generativo;
reabrirlo en ronda 2 retrabaja núcleos, mapa conceptual y cohesión global.

**Dirección**: el temario incluye un núcleo de multimodalidad y modelos generativos no textuales
(propuesto abajo como N4) con la difusión al menos a nivel conceptual; el alcance de su laboratorio
(¿se genera imagen localmente o sólo se explica?) va a la duda 1 del lote.

### FP-02 · P1 · E2 · interpretativo — «Un estudiante que aún no conoce del tema» no fija los prerrequisitos reales, y los ejemplos operables los exigen

**Cita**: folio 001, «Objetivo»: «Iniciar a aquien a un estudiante que aun no conoce del tema».
Folio 002, RESTRICCIONES DURAS: «romper la audiencia principiante» es P0. Pero los ejemplos pedidos
(«montar modelos, descargarlos, entrenarlos» — folio 001, «Contexto») exigen terminal, y cualquier
ajuste exige Python.

**Qué falla**: dos lecturas legítimas de «no conoce del tema»: (a) no conoce IA ni computación;
(b) no conoce IA, pero es perfil técnico (el repo destino es un laboratorio de desarrollo .NET y sus
guías 01–16 asumen desarrollador). La que menos agrega es (b): no obliga a escribir un curso de
terminal ni de Python que el pedido no nombra. Pero nadie la declaró: es un supuesto sin origen.

**Impacto**: cada redactor resolverá el nivel por su cuenta → tono y profundidad divergentes entre
núcleos (retrabajo de conjunto); o la guía «rompe la audiencia» en un sentido que nadie fijó.

**Dirección**: el marco de referencia declara el actor-lector con sus prerrequisitos explícitos
(propuesta: «sin conocimiento previo de IA; con manejo básico de terminal y de algún lenguaje de
programación») y la resolución de la mesa lo asienta como decisión; si la presidencia considera que
redefine la audiencia del pedido, va al lote.

### FP-03 · P1 · E2 · enumerable — «RAG» entró a las preguntas del caso sin origen declarado en el pedido

**Cita**: folio 002, PREGUNTAS DEL CASO 4: «…montar, descargar, entrenar, inferir, medir, RAG…».
El pedido (folio 001) nombra «base de datos vectoriales» pero la palabra RAG no aparece en el bloque
de testimonio (verificación: `grep -ci 'rag' sobre el bloque` → 0 ocurrencias como término; sí
aparece «base de datos vectoriales» una vez, «Contexto»).

**Qué falla**: la norma manda declarar el origen de cada cláusula del objetivo; lo que no lo tiene es
agregado y sale marcado (Mesa-De-Expertos-A-Pedido §0, renglón 2; §3.1, «Todo pedido que plantea un
problema»). El agregado acá es defendible —RAG es el caso de uso dominante de las bases vectoriales
en la industria (Lewis et al., 2020, «Retrieval-Augmented Generation for Knowledge-Intensive NLP
Tasks», NeurIPS)— pero defendible no es declarado.

**Impacto**: si no se asienta, la ronda 2 puede impugnar el núcleo RAG entero como agregado; o peor,
el patrón inverso: el PO esperaba bases vectoriales como tema de ingeniería de datos (índices,
operación) y recibe sólo RAG.

**Dirección**: la resolución declara «RAG = lectura aplicada de “base de datos vectoriales”, la que
menos agrega para una guía de estudio práctica, con su fuente», y el núcleo correspondiente (N6
abajo) cubre la base vectorial como objeto propio, no sólo como pieza del patrón RAG.

### FP-04 · P2 · E2 · enumerable — «Tipo Qwen» sin tabla de modelos de referencia con versión fijada deja los ejemplos no reproducibles

**Cita**: carta, Objetivo: «ejemplos prácticos operables sobre modelos open source tipo Qwen»;
folio 001: «Actualmente tenemos corriendo diferentes modelos de qween»; folio 002, MEDIOS: banco con
`qwen3-coder:30b entre otros`. Restricción dura: «toda afirmación respaldada por evidencia
verificable».

**Qué falla**: «tipo Qwen» no es una versión. La familia Qwen3 publica pesos abiertos en tamaños
densos 0.6B–32B y MoE 30B-A3B y 235B-A22B, Apache-2.0 (Yang et al., 2025, «Qwen3 Technical Report»,
arXiv:2505.09388; repositorio oficial github.com/QwenLM/Qwen3; biblioteca Ollama
https://ollama.com/library/qwen3 — consultadas 2026-11-07). Un ejemplo escrito contra «un Qwen»
cualquiera da salidas distintas por tamaño, cuantización y versión: no es verificable.

**Impacto**: ejemplos que el estudiante no puede reproducir tal cual; las cifras de la guía (memoria,
velocidad, calidad) quedan sin sujeto.

**Dirección**: la estructura incluye, en el marco de referencia o en el núcleo de panorama, una tabla
única de «modelos de referencia de la guía» con etiqueta exacta (p. ej. `qwen3:0.6b`, `qwen3:8b`,
`qwen3-coder:30b`), tamaño, cuantización y para qué núcleos sirve cada uno; todos los ejemplos citan
esa tabla. La elección concreta de etiquetas corresponde a la comisión de inferencia local (ver
solicitud de convocatoria 2).

### FP-05 · P2 · E2 · interpretativo — Lo coyuntural (panorama, tendencias) y lo estable (fundamentos) tienen vida útil distinta y la estructura debe separarlos

**Cita**: folio 001, «Solicitudes»: «Es importante basarse en las tendencias del mercado y los
estandares de la industria»; «Este material debe servir de consulta y tambien de referencia».

**Qué falla**: un panorama de modelos fechado en 2026 caduca en meses (la propia familia Qwen pasó de
Qwen2.5 a Qwen3 en menos de un año: Yang et al., 2025); la atención y la tokenización no caducan. Si
ambos viven mezclados en los mismos documentos, la «referencia» entera envejece al ritmo de su parte
más volátil.

**Impacto**: pérdida acotada hoy; en seis meses, una guía de consulta con afirmaciones de mercado
vencidas sin marcar.

**Dirección**: la estructura aísla el panorama/taxonomía de modelos (N5) en documentos propios con
`last_review` del frontmatter de la casa (ia-db índice 10 §1.1) como contrato de caducidad explícito,
y los núcleos de fundamentos no citan cifras de modelos concretos salvo vía la tabla de FP-04.

### FP-06 · P2 · E4 · enumerable — «Open source» aplicado a modelos exige definición propia en la guía: la industria lo usa de forma impugnada

**Cita**: folio 001: «Actualmente tenemos funcionando modelos open sorce»; restricción dura «no
inventar información».

**Qué falla**: la Open Source Initiative publicó la Open Source AI Definition 1.0 (OSI, 2024,
https://opensource.org/ai/open-source-ai-definition — consultada 2026-11-07), bajo la cual la mayoría
de los modelos llamados «open source» (pesos abiertos con licencia propia, datos no publicados) no
califican; Llama usa licencia comunitaria propia de Meta, Qwen3 usa Apache-2.0. Una guía que repita
«open source» sin esta distinción afirma algo que la norma de referencia del término contradice.

**Impacto**: el estudiante forma un criterio equivocado justo en el eje que el pedido usa para
delimitar su parque de modelos.

**Dirección**: el núcleo de panorama (N5) define y distingue open source / open weights / licencias
por familia, con la OSAID 1.0 como fuente; el glosario adopta «pesos abiertos» como término preciso.

### FP-07 · P3 · E2 · interpretativo — «Términos asociados» es una frontera abierta; el glosario debe cerrarla por los núcleos

**Cita**: folio 001, «Contexto»: «…y toda los conceptos relacionadas… términos asociados».

**Qué falla**: sin regla de corte, «términos asociados» admite cualquier cosa (MLOps, ética, agentes,
hardware). Claridad de alcance, no hueco: el contrato ya acota por las frases del pedido.

**Impacto**: discusiones de alcance repetidas en la redacción.

**Dirección**: regla editorial en la estructura: entra al glosario el término que algún núcleo usa;
un término sin núcleo que lo use señala o un hueco del temario o un descarte, y se decide, no se
acumula.

**Resumen**: P0: 0 · P1: 3 (FP-01, FP-02, FP-03) · P2: 3 (FP-04, FP-05, FP-06) · P3: 1 (FP-07).

---

## 2. Solicitudes de convocatoria (señales fuera de mi competencia)

1. **Entrenamiento y ajuste**: el pedido manda «entrenarlos» (folio 001, «Contexto») y el contrato
   declara «sin GPU dedicada… los ejemplos de entrenamiento se limitan a lo reproducible en CPU/GPU
   chica o se marcan ilustrativo» (folio 002, MEDIOS). Decidir qué es operable (¿LoRA/QLoRA sobre un
   Qwen chico?, ¿sólo ilustrativo?) es de una comisión de entrenamiento/ajuste.
2. **Operación local de inferencia**: «motor de inferencia» (folio 001, «Contexto») y la elección de
   etiquetas/cuantizaciones concretas de la tabla de FP-04 son de una comisión de inferencia local
   (Ollama/llama.cpp/vLLM, GGUF, memoria).
3. **Decisión pedagógico-editorial**: «preguntas guías formadoras de conceptos… articuladas con
   respuestas explicativas y que realimenten el texto» (folio 001, «Solicitudes») fija un dispositivo
   didáctico cuyo diseño (dónde van las respuestas, cómo «realimentan») es editorial, no de dominio.

---

## 3. Núcleos conceptuales propuestos (dominio de esta comisión)

Criterio de núcleo: agrupa ideas con dependencia fuerte, se estudia y valida con relativa
independencia, y ningún otro núcleo puede explicarse sin presuponerlo o referenciarlo (regla de
descomposición del pedido, folio 001 «Reglas»).

### N1 — El lenguaje como datos: tokens, vocabularios y representaciones

- **Qué agrupa**: qué ve realmente un modelo (texto → tokens → ids → vectores); tokenización por
  subpalabras (BPE — Sennrich et al., 2016, «Neural Machine Translation of Rare Words with Subword
  Units», ACL); embeddings como representación semántica; similitud coseno; la noción de contexto.
- **Por qué es núcleo**: todo lo demás (atención, generación, RAG, métricas) opera sobre estas
  representaciones; es la frontera exacta entre «el texto» y «el modelo». No es fragmento: sin él,
  cada núcleo posterior tendría que redefinir token y embedding.
- **Dependencias**: ninguna entrante; salientes hacia N2, N3, N6, N7.
- **Definiciones imprescindibles**: token, vocabulario, tokenización por subpalabras, embedding,
  dimensión, similitud coseno, ventana de contexto.
- **Ejemplos operables (candidatos)**: (1) tokenizar la misma frase en español y en inglés y contar
  tokens (API de Ollama o tokenizer de Qwen publicado en Hugging Face) — ver que español «cuesta» más
  tokens; (2) pedir embeddings a un modelo de embeddings local y medir coseno entre tres frases, dos
  afines y una ajena; (3) demostrar la ventana de contexto: un dato al inicio de un prompt largo que
  el modelo chico pierde.
- **Cuadros candidatos**: caracteres vs palabras vs subpalabras (ventajas/limitaciones); tamaños de
  vocabulario de 2–3 familias con fuente.
- **Preguntas guía → criterio**: «¿Por qué un modelo no puede “ver” una letra dentro de un token?» →
  criterio para diagnosticar fallas de deletreo/aritmética; «¿Qué significa que dos textos estén
  “cerca” en el espacio de embeddings?» → criterio para decidir cuándo la búsqueda semántica aplica.

### N2 — La arquitectura Transformer y sus variantes

- **Qué agrupa**: atención (Vaswani et al., 2017, «Attention Is All You Need», NeurIPS); por qué
  desplazó a las recurrentes; encoder / decoder / decoder-only; posición (RoPE — Su et al., 2024,
  «RoFormer», Neurocomputing); parámetros y capas; mezcla de expertos (MoE — Fedus et al., 2022,
  «Switch Transformers», JMLR) como está en Qwen3-30B-A3B (Yang et al., 2025); variantes de atención
  eficiente y contexto largo (conceptual).
- **Por qué es núcleo**: es la explicación mecánica común a casi todo el parque de modelos vigente;
  separa «qué es un modelo» de «qué modelos hay» (N5).
- **Dependencias**: entra N1; sale hacia N3, N4, N5.
- **Definiciones imprescindibles**: atención, query/key/value (a nivel intuición), cabeza, capa,
  parámetro, decoder-only, autoregresivo, MoE, parámetros activos vs totales.
- **Ejemplos operables (candidatos)**: (1) comparar en el banco local un denso (`qwen3:8b`) con el
  MoE (`qwen3-coder:30b` / 30B-A3B): tamaño en disco vs memoria vs velocidad percibida, misma
  pregunta; (2) generar token a token (streaming de la API de Ollama) para ver el carácter
  autoregresivo; (3) diagrama mermaid del flujo prompt → tokens → capas → logits → muestreo.
- **Cuadros candidatos**: RNN vs Transformer (paralelismo, dependencias largas); denso vs MoE
  (parámetros totales/activos, memoria, para quién conviene); encoder-only vs decoder-only vs
  encoder-decoder con un ejemplo de modelo real por celda.
- **Preguntas guía → criterio**: «¿Por qué 30B-A3B corre “como un 3B” pero ocupa como un 30B?» →
  criterio para leer fichas de modelos MoE; «¿Qué limita realmente la longitud de contexto?» →
  criterio para no confundir ventana publicada con ventana útil.

### N3 — Del modelo base al asistente: LLM generativos, alineación y uso

- **Qué agrupa**: pre-entrenamiento con predicción del siguiente token y aprendizaje en contexto
  (Brown et al., 2020, «Language Models are Few-Shot Learners», NeurIPS); leyes de escala
  (Hoffmann et al., 2022, «Training Compute-Optimal Large Language Models», arXiv:2203.15556); la
  distinción base / instruct / chat y la alineación por instrucciones y preferencias (Ouyang et al.,
  2022, «Training language models to follow instructions with human feedback», NeurIPS) — como
  taxonomía de qué es cada cosa, no como procedimiento de entrenamiento (eso es de la comisión de
  entrenamiento); muestreo: temperatura, top-p; prompting y mensajes de sistema; modos de
  razonamiento (thinking) como los de Qwen3 (Yang et al., 2025); alucinación como propiedad del
  mecanismo.
- **Por qué es núcleo**: es el puente entre la mecánica (N2) y el uso; concentra el vocabulario que
  el estudiante va a encontrar en cualquier ficha de modelo (base, instruct, SFT, RLHF, temperatura).
- **Dependencias**: entra N2; sale hacia N4, N5, N6, N7.
- **Definiciones imprescindibles**: modelo base, modelo instruct, mensaje de sistema, temperatura,
  top-p, few-shot, alucinación, ventana de conversación.
- **Ejemplos operables (candidatos)**: (1) misma pregunta a temperatura 0 y 1.2 (opciones de la API
  de Ollama), tres corridas cada una: determinismo vs variedad; (2) few-shot: tarea de clasificación
  que falla sin ejemplos y sale con tres ejemplos en el prompt; (3) provocar y documentar una
  alucinación verificable (pregunta sobre un hecho inexistente) y mostrar cómo el mensaje de sistema
  y el «no sé» la mitigan; (4) comparar respuesta con y sin modo thinking en un Qwen3 que lo soporte.
- **Cuadros candidatos**: base vs instruct (qué pasa si prompteás uno como el otro); parámetros de
  muestreo con efecto y rango útil; prompting vs RAG vs fine-tuning — cuándo cada uno (la fila de
  fine-tuning se valida con la comisión de entrenamiento).
- **Preguntas guía → criterio**: «¿Por qué el modelo “inventa” con total fluidez?» → criterio para no
  tratar la salida como fuente de verdad; «¿Cuándo bajar la temperatura a 0 es un error?» → criterio
  de configuración por tipo de tarea.

### N4 — Multimodalidad y generación no textual

- **Qué agrupa**: representaciones compartidas texto-imagen (CLIP — Radford et al., 2021, «Learning
  Transferable Visual Models From Natural Language Supervision», ICML); modelos visión-lenguaje
  (Qwen2.5-VL — Bai et al., 2025, arXiv:2502.13923) y audio (Whisper — Radford et al., 2023, «Robust
  Speech Recognition via Large-Scale Weak Supervision», ICML); difusión para generación de imagen
  (Rombach et al., 2022, CVPR) como segunda gran familia generativa, a nivel conceptual; qué cambia y
  qué no respecto del transformer de N2.
- **Por qué es núcleo**: el pedido lo nombra («modelos multimodales», «modelos IA generativas») y su
  mecánica no se deduce de N3; es donde vive FP-01.
- **Dependencias**: entra N2 y N3; sale hacia N5.
- **Definiciones imprescindibles**: modalidad, encoder de visión, espacio compartido, VLM, difusión,
  prompt de imagen, transcripción vs comprensión de audio.
- **Ejemplos operables (candidatos)**: (1) describir una imagen local con un VLM del banco (p. ej.
  `qwen2.5vl` u otro VLM disponible en Ollama; la etiqueta exacta la fija la tabla de FP-04); (2) el
  mismo VLM leyendo texto dentro de una captura (OCR implícito) y sus límites; (3) si la duda 1 del
  lote habilita generación de imagen local: una corrida mínima de un modelo de difusión abierto, si
  la comisión de inferencia la declara viable en el banco; si no, ejemplo marcado «ilustrativo».
- **Cuadros candidatos**: comprensión multimodal vs generación multimodal (qué modelo hace cuál);
  autoregresivo vs difusión (qué genera, cómo itera, costo).
- **Preguntas guía → criterio**: «¿“Multimodal” significa que genera imágenes?» → criterio para leer
  capacidades reales en una ficha; «¿Por qué un VLM se equivoca contando objetos?» → criterio sobre
  límites de la percepción por tokens visuales.

### N5 — Panorama y taxonomía del ecosistema de modelos abiertos

- **Qué agrupa**: familias vigentes de pesos abiertos (Qwen, Llama, Mistral, DeepSeek, Gemma, Phi) y
  cómo leerlas: tamaño, generación, especialización (coder, VL, embeddings); licencias y la
  distinción open source / open weights (OSI, Open Source AI Definition 1.0, 2024 — FP-06); el hub
  como infraestructura (Hugging Face) y la model card como documento de referencia (Mitchell et al.,
  2019, «Model Cards for Model Reporting», FAT*); formatos y cuantización como concepto de catálogo
  (GGUF, safetensors — el detalle operativo es de la comisión de inferencia); cómo se anuncia y
  deprecia un modelo; dónde mirar tendencias sin casarse con ellas.
- **Por qué es núcleo**: responde «qué modelos hay y cómo elegir» — la pregunta de mercado que el
  pedido manda («tendencias del mercado y estándares de la industria») — y es el único núcleo
  deliberadamente fechado (FP-05).
- **Dependencias**: entra N2, N3, N4; sale hacia N6 y N7; provee la tabla de modelos de referencia
  (FP-04) a toda la guía.
- **Definiciones imprescindibles**: pesos abiertos, licencia de modelo, model card, checkpoint,
  cuantización (como propiedad del artefacto), familia vs versión vs variante, deprecación.
- **Ejemplos operables (candidatos)**: (1) leer en voz de la guía una model card real de Qwen3 en
  Hugging Face: dónde está la licencia, el tamaño, los límites declarados; (2) `ollama list` y la
  biblioteca https://ollama.com/library (consultada 2026-11-07): mapear cada etiqueta local a
  familia/tamaño/cuantización; (3) ejercicio de elección guiada: tres requisitos (traducir,
  programar, describir imágenes) → elegir modelo del parque local justificando con la taxonomía.
- **Cuadros candidatos**: familias abiertas con licencia, tamaños y especializaciones, cada celda con
  fuente y fecha; «qué significa cada parte de una etiqueta» (`qwen3-coder:30b-a3b-q4_K_M` descompuesta);
  criterio de elección tarea → tamaño → variante.
- **Preguntas guía → criterio**: «¿Este modelo es open source?» → criterio OSAID vs marketing;
  «¿Más parámetros es mejor para mi caso?» → criterio costo/calidad/latencia por tarea.

### N6 — Embeddings aplicados, bases vectoriales y RAG

- **Qué agrupa**: del embedding (N1) a la base vectorial: indexación y búsqueda aproximada de vecinos
  (ANN; HNSW — Malkov y Yashunin, 2020, «Efficient and robust approximate nearest neighbor search
  using Hierarchical Navigable Small World graphs», IEEE TPAMI); modelos de embeddings de oración
  (Reimers y Gurevych, 2019, «Sentence-BERT», EMNLP); qué es una base de datos vectorial y qué la
  distingue de un índice en una base general; el patrón RAG (Lewis et al., 2020, NeurIPS): trocear,
  indexar, recuperar, aumentar el prompt; sus modos de falla (recuperación mala → respuesta mala).
- **Por qué es núcleo**: el pedido nombra «base de datos vectoriales» como tema propio; su mecánica
  (índices, similitud, recall) no pertenece ni a N1 ni a N3, y el patrón que las une (RAG) atraviesa
  ambos. Resuelve FP-03 cubriendo la base vectorial como objeto y no sólo como pieza del patrón.
- **Dependencias**: entra N1, N3, N5; sin salientes obligatorias (hoja aplicada del grafo).
- **Definiciones imprescindibles**: base vectorial, índice ANN, recall, chunking, recuperación,
  aumento del prompt, re-ranking (mención).
- **Ejemplos operables (candidatos)**: (1) mini-RAG punta a punta en el banco: 10 fragmentos de un
  texto propio, embeddings con un modelo local, similitud coseno a mano (sin motor) → responde con
  contexto recuperado; (2) el mismo corpus en un motor vectorial embebido open source (el concreto lo
  valida la comisión de inferencia/operación) mostrando qué agrega el motor sobre el coseno a mano;
  (3) demostrar un fallo de RAG por chunking malo y corregirlo: misma pregunta, dos troceos.
- **Cuadros candidatos**: búsqueda léxica vs semántica vs híbrida; «cuándo RAG y cuándo no» (contra
  prompt largo y contra fine-tuning, en coordinación con el cuadro de N3).
- **Preguntas guía → criterio**: «Si la respuesta es mala, ¿falló el modelo o la recuperación?» →
  criterio de diagnóstico por etapas; «¿Qué gano con una base vectorial sobre un array de vectores?»
  → criterio de escala y operación.

### N7 — Evaluación: métricas, benchmarks y sus límites

- **Qué agrupa**: métricas intrínsecas (perplejidad) y por tarea; benchmarks de conocimiento y código
  (MMLU — Hendrycks et al., 2021, «Measuring Massive Multitask Language Understanding», ICLR;
  HumanEval — Chen et al., 2021, «Evaluating Large Language Models Trained on Code»,
  arXiv:2107.03374); evaluación por preferencia humana y arenas (Chiang et al., 2024, «Chatbot Arena:
  An Open Platform for Evaluating LLMs by Human Preference», arXiv:2403.04132); contaminación y
  saturación de benchmarks como límite de lectura; cómo leer la tabla de resultados de un informe
  técnico (la de Qwen3 como caso: Yang et al., 2025).
- **Por qué es núcleo**: «metricas» está nombrado en el pedido (folio 001, «Contexto»); formar
  criterio de elección (N5) sin saber leer una evaluación es imposible; y su mecánica es independiente
  de la arquitectura. La *medición operativa* de rendimiento local (tokens/s, memoria) no es de este
  núcleo: es de la comisión de inferencia.
- **Dependencias**: entra N3 (y N5 como consumidor principal).
- **Definiciones imprescindibles**: benchmark, perplejidad (intuición), exactitud por tarea,
  pass@k (intuición), evaluación por preferencia, contaminación de datos.
- **Ejemplos operables (candidatos)**: (1) mini-eval propia en el banco: 10 preguntas con respuesta
  cerrada, dos modelos Qwen de tamaños distintos, tabla de aciertos — ver que la eval propia chica es
  ruidosa pero orienta; (2) leer juntos (guiado) la tabla de benchmarks del informe de Qwen3 y
  contrastar dos celdas con la mini-eval local; (3) el mismo prompt de código evaluado con «¿compila
  y pasa un test?» como pass@1 casero.
- **Cuadros candidatos**: qué mide y qué no mide cada benchmark citado; «señales de alerta» al leer
  una tabla de resultados (autoevaluación, benchmark saturado, sin versión).
- **Preguntas guía → criterio**: «¿Un punto más de MMLU significa un modelo mejor para mí?» →
  criterio de validez externa; «¿Por qué toda cifra de benchmark lleva fecha y versión?» → criterio
  de caducidad (enlaza FP-05).

**Grafo de dependencias (resumen)**: N1 → N2 → N3 → {N4, N5}; N1+N3+N5 → N6; N3 → N7 → alimenta N5.
Recorrido lineal posible para el estudiante: N1, N2, N3, N7, N5, N4, N6 — o N4 antes de N7; el orden
fino es decisión editorial (solicitud de convocatoria 3). Los núcleos de otras comisiones
(entrenamiento/ajuste; inferencia y operación local) encajan entre N3 y N5 sin solaparse con éstos si
se respeta el reparto declarado en cada núcleo.

---

## 4. Propuesta de marco de referencia (desde este dominio)

Conforme al Profile (ejes Escenarios/Contextos/Actores) y a la convención de la casa de que todo
catálogo ESC-/CTX-/ACT- es propio de su guía y se cita con ella (ia-db índice 10 §: «Antes de citar
ESC-2… hay que decir de qué guía»), se propone catálogo propio de esta guía:

**Escenarios** (situaciones donde el tema se aplica):
- ESC-1 · Entender un modelo publicado: leer una ficha/informe técnico y saber qué es y qué puede.
- ESC-2 · Elegir un modelo para una tarea dada, dentro de restricciones de hardware y licencia.
- ESC-3 · Montar y probar un modelo localmente y conversar con él de forma controlada.
- ESC-4 · Construir una aplicación que usa un modelo (chat con contexto propio, RAG).
- ESC-5 · Evaluar y comparar: decidir con evidencia si un modelo o configuración es mejor que otra.
- (La comisión de entrenamiento puede proponer un ESC de ajuste; se integra sin renumerar los de acá
  si la presidencia asigna rangos.)

**Contextos** (entornos que cambian las respuestas):
- CTX-1 · Máquina local sin GPU dedicada (el banco del contrato: folio 002, MEDIOS).
- CTX-2 · Máquina local con GPU de consumo.
- CTX-3 · Modelo consumido por API de terceros (sin pesos propios).
- CTX-4 · Entorno con datos propios/sensibles donde el modelo debe correr adentro.

**Actores**:
- ACT-1 · Estudiante-lector: sin conocimiento previo de IA, con terminal y programación básica
  (prerrequisito a ratificar — FP-02).
- ACT-2 · Desarrollador integrador: consume modelos vía API local o remota.
- ACT-3 · Evaluador: diseña la comparación y lee benchmarks (N7).
- ACT-4 · Autor/mantenedor de la guía: responsable de la caducidad del panorama (FP-05).

Cadena de consecuencias (§2, los cuatro pasos) sobre la única elección que esta comisión recomienda
— **difusión y generación no textual: núcleo propio dentro de N4 vs núcleo separado**:
1. *Dónde cae*: en el estudiante (carga de recorrido) y en el mapa de cohesión (una arista más).
2. *Cuánto pesa*: separado agrega un documento entero con un solo laboratorio viable dudoso en CTX-1
   (sin medir en el banco: la viabilidad de difusión local la mide la comisión de inferencia; se
   asienta como «sin medir, pedido a esa comisión»).
3. *Qué pierde la alternativa*: dentro de N4, la difusión queda a nivel conceptual y pierde
   profundidad operable; separado, pierde cohesión con VLM y duplica el marco multimodal.
4. *Reversible*: integrarlo en N4 es reversible (promover una sección a documento es aditivo);
   separarlo y después fundirlo retrabaja el mapa. → Se recomienda **dentro de N4**, con condición de
   revisión comprobable: si la comisión de inferencia declara viable un laboratorio de difusión en el
   banco, se promueve a documento propio.

---

## 5. Lo que revisé y está bien (≤3)

1. **Cobertura temática del contrato**: contrasté cada sustantivo temático del bloque de testimonio
   (folio 001, «Contexto») contra las PREGUNTAS DEL CASO y el OBJETIVO del folio 002: montar,
   descargar, entrenar, arquitecturas, transformers, métricas, motor de inferencia, NLP, generativa,
   multimodal, bases vectoriales — todos tienen casilla. No hay omisión P0 en el contrato.
2. **Lectura «documento raíz + conjunto»** (folio 002, ENUNCIADO): coherente con el Profile
   («conjunto documental navegable desde su README») y con la frase literal del pedido; es la lectura
   que menos agrega y está declarada como a ratificar. Esta comisión la ratifica desde su dominio.
3. **Banco de ensayo**: el contrato trae E1 real (`GET /api/tags` → 200 con `qwen3-coder:30b`), lo
   que hace operables los ejemplos candidatos de N2, N3, N6 y N7 sin supuesto de hardware.

---

## 6. Fuentes externas (todas con autor/año o URL oficial; consultas web del 2026-11-07)

1. Vaswani, A. et al. (2017). «Attention Is All You Need». NeurIPS.
2. Sennrich, R., Haddow, B., Birch, A. (2016). «Neural Machine Translation of Rare Words with Subword Units». ACL.
3. Brown, T. et al. (2020). «Language Models are Few-Shot Learners». NeurIPS.
4. Ouyang, L. et al. (2022). «Training language models to follow instructions with human feedback». NeurIPS.
5. Hoffmann, J. et al. (2022). «Training Compute-Optimal Large Language Models». arXiv:2203.15556.
6. Su, J. et al. (2024). «RoFormer: Enhanced Transformer with Rotary Position Embedding». Neurocomputing.
7. Fedus, W., Zoph, B., Shazeer, N. (2022). «Switch Transformers». JMLR 23.
8. Radford, A. et al. (2021). «Learning Transferable Visual Models From Natural Language Supervision» (CLIP). ICML.
9. Radford, A. et al. (2023). «Robust Speech Recognition via Large-Scale Weak Supervision» (Whisper). ICML.
10. Rombach, R. et al. (2022). «High-Resolution Image Synthesis with Latent Diffusion Models». CVPR.
11. Lewis, P. et al. (2020). «Retrieval-Augmented Generation for Knowledge-Intensive NLP Tasks». NeurIPS.
12. Reimers, N., Gurevych, I. (2019). «Sentence-BERT». EMNLP.
13. Malkov, Y., Yashunin, D. (2020). «Efficient and robust approximate nearest neighbor search using HNSW». IEEE TPAMI.
14. Hendrycks, D. et al. (2021). «Measuring Massive Multitask Language Understanding» (MMLU). ICLR.
15. Chen, M. et al. (2021). «Evaluating Large Language Models Trained on Code» (HumanEval). arXiv:2107.03374.
16. Chiang, W.-L. et al. (2024). «Chatbot Arena». arXiv:2403.04132.
17. Mitchell, M. et al. (2019). «Model Cards for Model Reporting». FAT*.
18. Yang, A. et al. (2025). «Qwen3 Technical Report». arXiv:2505.09388. Repo oficial: https://github.com/QwenLM/Qwen3 (Apache-2.0).
19. Bai, S. et al. (2025). «Qwen2.5-VL Technical Report». arXiv:2502.13923.
20. Open Source Initiative (2024). «The Open Source AI Definition 1.0». https://opensource.org/ai/open-source-ai-definition (consultada 2026-11-07).
21. Ollama, biblioteca oficial de modelos. https://ollama.com/library/qwen3 (consultada 2026-11-07; búsqueda web del mismo día para el estado del catálogo — los resultados de terceros sobre líneas posteriores a Qwen3 no se pudieron confirmar en fuente oficial y no se afirman en este informe).

---

## 7. Dudas para quien pidió

| Rol | Pregunta | Por qué | Prioridad | Qué hago si no contesta |
| --- | --- | --- | --- | --- |
| PO | ¿La guía debe cubrir generación de imagen/audio con laboratorio operable, o alcanza el nivel conceptual dentro del núcleo multimodal? | «Modelos IA generativas, modelos multimodales» (folio 001) admite ambas lecturas y cambia un documento y un laboratorio (FP-01) | Alta | Rige la lectura que menos agrega: difusión y audio a nivel conceptual dentro de N4, con ejemplo marcado «ilustrativo»; la promoción a laboratorio queda como ítem diferido con evento de cierre «la comisión de inferencia declara viable difusión en el banco» |
| PO | ¿El estudiante-lector tiene manejo básico de terminal y de un lenguaje de programación? | «No conoce del tema» no fija prerrequisitos y los ejemplos operables los exigen (FP-02) | Media | Asumo terminal + programación básica, lo declaro en ACT-1 del marco y toda pieza que exija más lo marca al inicio |

Sigue: incorporación de este informe como folio por la presidencia · quien preside.
