# Informe de comisión — Entrenamiento, ajuste fino y métricas (ronda de estructura)

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-07 |
| Autor | comisión de entrenamiento, ajuste fino y métricas |
| Corrige | — |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | líneas 1–111 (cabecera y §0), carta (§5.2), §2.2, §3.2, §3.3, §4 |
| Otros documentos cargados | Cadena-De-Consecuencias 2.0 (§2) · pliego operativo (evidencia/002) · Profile Study-Guide-Documentation |

Clase de objeto: diseño de una norma o decisión (temario, marco y estructura de la guía).
Encargo: refutar, no verificar. Trabajé a ciegas: no leí el informe de ninguna otra comisión.
Competencia: preentrenamiento, fine-tuning, datasets, alineación y métricas de evaluación de modelos.
Tope declarado: 12 hallazgos. Emitidos: 9. Prefijo de familia: `EM-`.

---

## 1. Hallazgos sobre el enunciado y el objetivo

| # | Nivel | Ancla | Detectabilidad | Aguas arriba | Resumen |
| --- | --- | --- | --- | --- | --- |
| EM-01 | P1 | E2 | enumerable | pedido (folio 001) + contrato (folio 002) | «Entrenar» con Ollama es inviable: Ollama no entrena; la cadena de herramientas de los ejemplos de entrenamiento no está fijada |
| EM-02 | P1 | E2 | interpretativo | pedido (folio 001) | «Entrenarlos» tiene dos lecturas (preentrenar desde cero / ajustar fino) y el enunciado no las desambigua |
| EM-03 | P1 | E4 | interpretativo | contrato (folio 002) | Cifras de evaluación sin protocolo de reproducibilidad violan la restricción dura «evidencia verificable» |
| EM-04 | P1 | E2 | interpretativo | pedido (folio 001) + Profile | Audiencia principiante vs. dominio con matemática: falta un contrato de profundidad por documento |
| EM-05 | P2 | E2 | enumerable | pedido (folio 001) | «Métricas» sin partición: calidad de modelo vs. rendimiento de servicio; frontera con el dominio de inferencia sin trazar |
| EM-06 | P2 | E2 | interpretativo | pedido (folio 001) | «Estándares de la industria» en evaluación de LLMs son benchmarks de facto con contaminación conocida, no normas con número; la guía debe enseñarlo o inducirá criterio falso |
| EM-07 | P2 | E2 | enumerable | pedido (folio 001) | Licencias de modelos y datasets omitidas del alcance explícito, siendo que la guía enseña a descargar y ajustar |
| EM-08 | P2 | E2 | enumerable | pedido (folio 001) | «Datos y corpus» no figura como tema nombrado: debe ser núcleo propio, no fragmento repartido |
| EM-09 | P3 | E4 | enumerable | convenciones de la casa | Convención terminológica bilingüe (término de industria en inglés + definición en español) sin fijar para este dominio |

### EM-01 — P1 · E2 · enumerable · aguas arriba: pedido (folio 001) y contrato (folio 002)

**Cita.** Folio 001, línea 27: «los pasos necesarios para montar modelos, descargarlos, entrenarlos».
Carta de despacho (evidencia/005), líneas 29–31: ejemplos «operables en un entorno local con
Ollama/modelos Qwen cuando aplique». Folio 002, MEDIOS: «Sin observar: entrenamiento a escala (sin GPU
dedicada declarada)».

**La contradicción.** Ollama es un motor de inferencia: sirve modelos y puede importar adaptadores ya
entrenados (directiva `ADAPTER` del Modelfile), pero no tiene comando de entrenamiento ni de ajuste
fino (doc oficial: https://docs.ollama.com/modelfile — secciones `FROM`/`ADAPTER`; el repositorio
https://github.com/ollama/ollama no documenta ninguna orden de entrenamiento). Si el temario deja
implícito que la herramienta del banco de ensayo cubre «entrenarlos», todo el eje práctico de mi
dominio nace inviable: eso es un ejemplo práctico inviable (P1 según la lectura del caso).

**Impacto si no se corrige.** Los redactores de la fase 3 descubren el hueco al escribir, improvisan
cadenas de herramientas distintas por documento y el conjunto pierde coherencia (retrabajo del
conjunto).

**Dirección de la corrección.** El temario fija la cadena de herramientas por actividad: ajuste fino
con el ecosistema Hugging Face (`transformers` + PEFT + TRL; docs oficiales
https://huggingface.co/docs/peft y https://huggingface.co/docs/trl) sobre modelos Qwen chicos;
conversión a GGUF con llama.cpp (https://github.com/ggml-org/llama.cpp); Ollama entra recién para
servir el resultado (Modelfile con `ADAPTER` o modelo fusionado). El puente «entrené acá → lo sirvo
acá» se enseña explícitamente: es una de las transferencias de criterio más valiosas de la guía.

### EM-02 — P1 · E2 · interpretativo · aguas arriba: pedido (folio 001)

**Cita.** Folio 001, línea 27: «entrenarlos». La tabla de enunciado (bitácora 01 §2, que el folio 002
hace propia) lo clasifica como «contenido práctico operable» sin distinguir preentrenamiento de ajuste.

**Las dos lecturas.** (a) Preentrenar desde cero: requiere corpus de billones de tokens y cómputo de
cluster — Hoffmann et al., 2022 (Chinchilla, arXiv:2203.15556) estiman ~20 tokens por parámetro para
entrenamiento cómputo-óptimo; inviable localmente salvo modelos juguete. (b) Ajustar un modelo
existente: operable en hardware local con PEFT. La lectura que menos agrega (norma §3.1) es la (b)
más una demostración juguete de la (a) con fines conceptuales.

**Impacto.** Sin la distinción declarada en el temario, dos redactores pueden interpretar el alcance
del núcleo de entrenamiento de forma divergente (definición de P1 del pliego §2).

**Dirección.** El temario declara: preentrenamiento se enseña conceptualmente con una demo juguete
reproducible (modelo de caracteres de pocos millones de parámetros en CPU) y fuentes; «entrenar» como
práctica real es ajuste fino. La decisión queda en el documento de cohesión, citando el pedido.

### EM-03 — P1 · E4 · interpretativo · aguas arriba: contrato (folio 002)

**Regla declarada.** Folio 002, RESTRICCIONES DURAS: «toda afirmación respaldada por evidencia
verificable». Las salidas de un LLM con muestreo son no deterministas: una cifra de evaluación medida
localmente sin fijar versión exacta del modelo (tag/digest), parámetros de muestreo (temperature,
top_p), semilla y conjunto de ítems no es verificable por el lector.

**Impacto.** La guía publicaría cifras que el estudiante no puede reproducir, violando una restricción
dura del contrato en el corazón del núcleo de métricas; además formaría el criterio contrario al que
debe formar (toda cifra de eval va acompañada de su protocolo).

**Dirección.** La estructura de la guía exige, para todo ejemplo que produce una cifra, un bloque
«protocolo»: modelo con versión/digest, parámetros de generación, semilla cuando el motor la soporta,
dataset con versión, y la advertencia de variabilidad. Donde aplique, `temperature 0` o decodificación
determinista. Esto entra como criterio de calidad transversal del conjunto, no como nota al pie.

### EM-04 — P1 · E2 · interpretativo · aguas arriba: pedido (folio 001) y Profile

**Cita.** Folio 001, línea 27: «pensada para quien nunca ha visto el tema»; línea 33: «Iniciar …
a un estudiante que aún no conoce del tema». Profile, «Criterios de calidad»: «Formativo, no
enciclopédico». Mi dominio es el de mayor densidad matemática de la guía (función de pérdida,
gradientes, perplexity como exponencial de la pérdida media, modelos de recompensa).

**El hueco.** Ni el pedido ni el contrato fijan el nivel matemático máximo. Sin ese tope, un redactor
escribe con derivadas y otro sin fórmulas, y la audiencia principiante se rompe en los documentos de
mi dominio antes que en ningún otro (P0 del caso si ocurre; como riesgo de diseño del temario, P1:
interpretación divergente entre quienes aplican).

**Dirección.** El marco de referencia declara un «contrato de profundidad»: intuición y ejemplo
numérico primero; fórmula sólo si se lee en una línea y cada símbolo se nombra; nada que requiera
cálculo diferencial para seguir el hilo; la profundidad extra va a anexos con fuente. Cada documento
temático lo declara cumplido en su frontmatter o cabecera.

### EM-05 — P2 · E2 · enumerable · aguas arriba: pedido (folio 001)

**Cita.** Folio 001, línea 27: «metricas, motor de inferencia» — dos sustantivos contiguos sin
frontera. «Métricas» abarca al menos: (a) métricas de entrenamiento (loss, perplexity), (b) métricas
de calidad de tarea (exact match, BLEU, ROUGE, pass@k), (c) benchmarks y leaderboards, (d) evaluación
por juez LLM, (e) métricas de servicio (tokens/s, latencia, memoria).

**Impacto.** Sin partición declarada, (e) se solapa con el dominio de despliegue e inferencia o queda
huérfana; pérdida acotada y solapamiento evitable.

**Dirección.** El mapa de cohesión asigna (a)–(d) al núcleo de evaluación de este dominio y (e) al
dominio de inferencia, con enlace cruzado explícito («qué medís del modelo vs. qué medís del
servicio»). No emito hallazgo sobre contenido de inferencia: la frontera es lo que señalo, y está en
mi lado del límite.

### EM-06 — P2 · E2 (omisión) · interpretativo · aguas arriba: pedido (folio 001)

**Cita.** Folio 001, línea 39: «Es importante basarse en las tendencias del mercado y los estandares
de la industria». En evaluación de LLMs no existen normas con número al estilo ISO: los «estándares»
son benchmarks de facto (MMLU — Hendrycks et al., 2021, arXiv:2009.03300; HumanEval — Chen et al.,
2021, arXiv:2107.03374; MT-Bench/Chatbot Arena — Zheng et al., 2023, arXiv:2306.05685) cuya validez
está erosionada por contaminación de datos de entrenamiento, documentada en la academia (Sainz et
al., 2023, «NLP Evaluation in trouble: On the Need to Measure LLM Data Contamination», Findings of
EMNLP 2023).

**Impacto.** Si la guía presenta leaderboards y cifras de benchmark como verdad estable, forma el
criterio equivocado en el estudiante: exactamente lo contrario del objetivo («formar criterio»).

**Dirección.** El núcleo de evaluación incluye, como contenido de primera clase, la caducidad y
contaminación de benchmarks y el criterio «ninguna cifra sin protocolo ni fecha»; «estándar de la
industria» se usa en la guía con esa calificación.

### EM-07 — P2 · E2 (omisión) · enumerable · aguas arriba: pedido (folio 001)

**Cita.** Folio 001, línea 27 nombra «montar modelos, descargarlos, entrenarlos»; ninguna frase del
pedido ni del contrato nombra licencias de modelos ni de datasets. La familia Qwen no es homogénea:
la mayoría de los pesos Qwen2.5/Qwen3 son Apache-2.0, pero hubo variantes bajo licencias propias
(p. ej. Qwen2.5-72B bajo «Qwen license», Qwen2.5-3B bajo licencia de investigación) — fuente: fichas
de modelo oficiales en https://huggingface.co/Qwen y doc oficial https://qwen.readthedocs.io. Para
datasets, la auditoría de procedencia y licencias de la Data Provenance Initiative (Longpre et al.,
2024, Nature Machine Intelligence) muestra tasas altas de licenciamiento mal atribuido en corpus
públicos de ajuste.

**Impacto.** Una guía que enseña a descargar y ajustar sin enseñar a leer la licencia del modelo y
del dataset deja al estudiante sin un criterio que la práctica real exige en el primer día. Pérdida
acotada: se corrige agregando el tema al núcleo de datos.

**Dirección.** El núcleo de datos incluye «licencias y procedencia» (del modelo y del dataset) con
ejercicio operable: leer la ficha de un modelo Qwen y de un dataset y decidir si un uso dado está
permitido.

### EM-08 — P2 · E2 (omisión) · enumerable · aguas arriba: pedido (folio 001)

**Cita.** La lista temática explícita del pedido (folio 001, línea 27) no nombra «datos», «corpus» ni
«datasets»; quedan cubiertos sólo por la cláusula general «toda los conceptos relacionadas». La regla
de descomposición del pedido (folio 001, líneas 49–50) manda formar núcleos «por la afinidad y
dependencia entre las ideas».

**Impacto.** Sin núcleo propio, el tratamiento de datos se fragmenta como apéndice del entrenamiento
y del ajuste, violando la propia regla de núcleos del pedido; no hay entrenamiento ni evaluación sin
datos, y el efecto de la calidad de datos está medido en la literatura (Lee et al., 2022,
«Deduplicating Training Data Makes Language Models Better», arXiv:2107.06499).

**Dirección.** «Datos y corpus» entra al temario como núcleo de primer nivel (propuesto abajo, N-EM-1).

### EM-09 — P3 · E4 · enumerable · aguas arriba: convenciones de la casa

**Regla.** Convenciones del repo destino (ia-db índice 10: terminología cruzada con fuente por
definición) y restricción de idioma del contrato (folio 002: español). Mi dominio está plagado de
términos de industria sin traducción asentada (fine-tuning, loss, embeddings, token, checkpoint,
reward model).

**Impacto.** Claridad: sin convención, cada documento traduce distinto («ajuste fino» / «afinado» /
«fine-tuning») y el glosario pierde unicidad.

**Dirección.** El glosario fija por término: forma canónica en la guía (término inglés de industria
en cursiva o su traducción elegida, una sola), definición en español y fuente; los documentos la
referencian.

---

## 2. Lo que revisé y está bien

1. **El contrato declara el límite de observación de entrenamiento** (folio 002, MEDIOS: ejemplos
   limitados a CPU/GPU chica o marcados «ilustrativo»): la restricción correcta para que mi dominio
   no prometa lo que el banco no puede medir. EM-01/EM-02 piden fijarla en el temario, no cambiarla.
2. **La resolución «documento raíz + conjunto en la carpeta»** (folio 002, ENUNCIADO) es la lectura
   que menos agrega y es la única compatible con un recorrido formativo de este volumen temático;
   desde mi dominio no hay nada que refutarle.
3. **El banco de ensayo verificado con modelos Qwen reales** (folio 002, MEDIOS: `GET /api/tags` →
   200 con `qwen3-coder:30b` entre otros) hace operables los ejemplos de evaluación e inferencia de
   mi dominio sin depender de servicios externos.

---

## 3. Núcleos conceptuales propuestos (dominio: entrenamiento, ajuste y métricas)

Prefijo de propuesta: N-EM-n. Las dependencias hacia núcleos de otros dominios se nombran por tema
(arquitecturas, inferencia/despliegue, bases vectoriales/RAG): su numeración la decide la integración.

### N-EM-1 · Datos y corpus

- **Qué agrupa:** qué «come» un modelo; corpus de preentrenamiento vs. datasets de instrucciones vs.
  datasets de preferencias; formatos (texto plano, instruct, chat/ChatML, pares preferidos);
  limpieza, deduplicación y contaminación; licencias y procedencia de datos y modelos.
- **Por qué es núcleo y no fragmento:** todas las fases (preentrenar, ajustar, alinear, evaluar)
  consumen datos con formas distintas; la afinidad es «el dato y su ciclo de vida», no la fase que lo
  usa. Repartirlo convertiría cada pieza en apéndice (EM-08).
- **Dependencias:** ninguna entrante de mi dominio (es la base); salientes hacia N-EM-2/3/4/5; cruce
  con el dominio de arquitecturas (tokenización: el dato se vuelve tokens allí).
- **Definiciones imprescindibles:** corpus, dataset, muestra/ejemplo, token (remisión a
  arquitecturas), formato instruct, formato chat (plantilla de conversación), dataset de
  preferencias, deduplicación, contaminación (train/test leakage), licencia de pesos vs. licencia de
  dataset.
- **Ejemplos prácticos candidatos (operables, CPU):**
  1. Descargar un dataset de instrucciones público chico desde Hugging Face, contar ejemplos,
     inspeccionar campos y detectar duplicados exactos con un script de hash.
  2. Construir a mano un mini-dataset propio de 50 pares instrucción→respuesta en formato chat de
     Qwen (plantilla de `tokenizer_config`), que los núcleos N-EM-3 y N-EM-5 reutilizan.
  3. Leer la ficha de licencia de dos modelos Qwen (uno Apache-2.0 y una variante con licencia
     propia) y de un dataset, y resolver tres casos de uso (¿puedo? sí/no y por qué).
- **Cuadros comparativos candidatos:** formatos de dataset (plano / instruct / chat / preferencias:
  campos, fase que lo consume, ejemplo); licencias frecuentes de pesos y datos (qué permiten).
- **Preguntas guía → criterio que forman:** «¿Por qué el mismo texto repetido muchas veces empeora el
  modelo?» → calidad sobre cantidad, dedup como higiene (Lee et al., 2022). «¿Qué mirás antes de usar
  un dataset ajeno?» → procedencia y licencia antes que contenido. «¿Por qué un dataset de
  preferencias no sirve para SFT?» → la forma del dato codifica la señal de aprendizaje.
- **Fuentes:** Lee et al., 2022 (arXiv:2107.06499); Longpre et al., 2024 (Data Provenance
  Initiative, Nature Machine Intelligence); fichas oficiales Qwen (https://huggingface.co/Qwen).

### N-EM-2 · Preentrenamiento y leyes de escala

- **Qué agrupa:** el objetivo de predecir el siguiente token; loss y perplexity; qué es un
  checkpoint; base vs. instruct; leyes de escala (parámetros/datos/cómputo) y por qué los modelos
  tienen los tamaños que tienen; por qué nadie preentrena en su casa.
- **Por qué es núcleo:** es el concepto generador de todo lo demás (un LLM «es» su preentrenamiento;
  el resto son retoques); separado de ajuste fino porque sus escalas, datos y objetivos difieren en
  órdenes de magnitud (EM-02).
- **Dependencias:** entra desde N-EM-1 y desde arquitecturas (transformer); sale hacia N-EM-3 (de
  un checkpoint base se parte) y N-EM-5 (perplexity nace acá).
- **Definiciones imprescindibles:** modelado de lenguaje autoregresivo, función de pérdida
  (intuición: «qué tan sorprendido quedó»), perplexity, época/paso/batch, checkpoint, modelo base,
  ley de escala, cómputo-óptimo (Chinchilla).
- **Ejemplos prácticos candidatos:**
  1. Demo juguete: entrenar un modelo de caracteres de ~1 M de parámetros en CPU sobre un corpus
     pequeño en español, viendo la curva de loss y muestras generadas cada N pasos (marcada
     «medible»: corre en minutos).
  2. Calcular la perplexity de un modelo Qwen chico en GGUF sobre dos textos (uno en español
     corriente, uno técnico) con la herramienta de perplexity de llama.cpp, y explicar la diferencia.
  3. Comparar en el banco local `qwen` base vs. instruct ante la misma entrada y observar que el
     base «continúa» y el instruct «responde» (puente a N-EM-4).
- **Cuadros comparativos candidatos:** base vs. instruct vs. razonador (qué esperar de cada uno);
  Kaplan 2020 vs. Hoffmann 2022 (qué predice cada ley de escala y qué cambió); órdenes de magnitud
  (demo juguete / Qwen 0.5B / Qwen 72B: datos, cómputo, hardware).
- **Preguntas guía → criterio:** «¿Por qué un loss más bajo no garantiza mejor modelo para tu
  tarea?» → proxy vs. objetivo real; distribución de los datos. «¿Por qué descargás un modelo en vez
  de entrenarlo?» → economía del preentrenamiento (leyes de escala). «¿Base o instruct para tu
  caso?» → base para continuar/ajustar, instruct para usar.
- **Fuentes:** Vaswani et al., 2017 (arXiv:1706.03762); Brown et al., 2020 (arXiv:2005.14165);
  Kaplan et al., 2020 (arXiv:2001.08361); Hoffmann et al., 2022 (arXiv:2203.15556); Qwen2.5
  Technical Report (Qwen Team, 2024, arXiv:2412.15115).

### N-EM-3 · Ajuste fino (fine-tuning)

- **Qué agrupa:** SFT; ajuste completo vs. PEFT (LoRA, QLoRA); cuándo ajustar vs. RAG vs. prompting;
  el flujo completo entrenar → fusionar/exportar → servir; sobreajuste y olvido catastrófico.
- **Por qué es núcleo:** es la práctica operable que el pedido llama «entrenarlos» en un entorno
  local (EM-01/EM-02); agrupa decisión (cuándo), técnica (cómo) y flujo (hasta servirlo), que se
  explican juntas o no forman criterio.
- **Dependencias:** entra desde N-EM-1 (dataset instruct) y N-EM-2 (checkpoint base); sale hacia
  N-EM-4 (la alineación es un ajuste con otra señal), N-EM-5 (evaluar antes/después) y el dominio de
  inferencia/despliegue (GGUF, Modelfile, Ollama); cruce con bases vectoriales (la alternativa RAG).
- **Definiciones imprescindibles:** SFT, hiperparámetro, learning rate, LoRA (adaptador de bajo
  rango: intuición «capa de corrección chica sobre pesos congelados»), cuantización (remisión a
  inferencia), QLoRA, adapter vs. modelo fusionado, sobreajuste, olvido catastrófico.
- **Ejemplos prácticos candidatos:**
  1. QLoRA/LoRA sobre un Qwen chico (0.5B–1.5B) con PEFT+TRL sobre el mini-dataset de N-EM-1
     (~200 ejemplos), en CPU o GPU chica; curva de loss y muestras antes/después. Marcado «medible»
     con tiempos esperados por hardware.
  2. Exportar el adaptador, convertir con llama.cpp a GGUF y servirlo en Ollama con un Modelfile
     (`FROM` + `ADAPTER`); verificar en el banco local que el modelo ajustado responde distinto al
     original ante el mismo prompt.
  3. Contraejemplo didáctico: ajustar con 20 ejemplos repetidos y mostrar el sobreajuste (el modelo
     recita el dataset); forma el criterio «más pasadas no es mejor».
  4. Resolver tres casos «¿fine-tuning, RAG o prompt?» sobre el cuadro de decisión, con respuesta
     razonada.
- **Cuadros comparativos candidatos:** prompting vs. RAG vs. fine-tuning vs. preentrenar (datos
  necesarios, costo, reversibilidad, cuándo conviene, qué problema NO resuelve); ajuste completo vs.
  LoRA vs. QLoRA (memoria, hardware mínimo, calidad esperada, artefacto resultante).
- **Preguntas guía → criterio:** «¿Tu problema es de conocimiento o de comportamiento?» → hechos
  actualizables → RAG; estilo/formato/tarea → ajuste. «¿Qué perdés al ajustar?» → olvido y
  mantenimiento del artefacto. «¿Por qué LoRA y no tocar todos los pesos?» → costo/beneficio y
  reversibilidad del adaptador.
- **Fuentes:** Hu et al., 2021 (LoRA, arXiv:2106.09685); Dettmers et al., 2023 (QLoRA,
  arXiv:2305.14314); docs oficiales PEFT (https://huggingface.co/docs/peft) y TRL
  (https://huggingface.co/docs/trl); Modelfile de Ollama (https://docs.ollama.com/modelfile).

### N-EM-4 · Alineación y preferencias

- **Qué agrupa:** por qué un modelo «crudo» no sigue instrucciones ni límites; instrucción + RLHF;
  modelos de recompensa; DPO como alternativa directa; rechazos y comportamiento de seguridad; el
  system prompt como capa de dirección en uso (no de entrenamiento).
- **Por qué es núcleo:** responde una pregunta distinta de N-EM-3 (no «cómo le enseño mi tarea» sino
  «cómo se vuelve útil e inofensivo»), con técnicas y datos propios (preferencias); el estudiante lo
  ve a diario en los rechazos del modelo y necesita el mapa causal.
- **Dependencias:** entra desde N-EM-3 (es la segunda etapa del post-entrenamiento) y N-EM-1 (datos
  de preferencias); sale hacia N-EM-5 (evaluar alineación es distinto de evaluar capacidad).
- **Definiciones imprescindibles:** alineación, RLHF, modelo de recompensa, DPO, par preferido/
  rechazado, system prompt, rechazo (refusal), jailbreak (sólo como fenómeno, con remisión al
  tratamiento de seguridad que decida la integración).
- **Ejemplos prácticos candidatos:**
  1. En el banco local: la misma pregunta al Qwen base y al instruct; mapear la diferencia a las
     etapas de post-entrenamiento (operable, sin entrenar nada).
  2. Efecto del system prompt: tres system prompts distintos sobre el mismo modelo y la misma
     pregunta; criterio «el system prompt dirige, no re-entrena».
  3. (Ilustrativo-opcional) Mini-corrida de DPO con TRL sobre un modelo 0.5B con 50 pares de
     preferencias sintéticos propios, mostrando el cambio de conducta en un eje acotado (tono).
- **Cuadros comparativos candidatos:** SFT vs. RLHF vs. DPO (qué dato necesita, qué optimiza, costo,
  qué logra); capas de dirección de conducta (preentrenamiento → SFT → preferencias → system prompt
  → prompt del usuario: qué fija cada una y qué cuesta cambiarla).
- **Preguntas guía → criterio:** «¿Por qué el modelo se niega a algo razonable a veces?» → la
  alineación es estadística, no reglas. «¿Cuándo basta un system prompt y cuándo hace falta
  re-ajustar?» → costo y persistencia de cada capa. «¿Qué es exactamente lo que premia el modelo de
  recompensa?» → preferencia humana muestreada, con sus sesgos.
- **Fuentes:** Ouyang et al., 2022 (InstructGPT/RLHF, arXiv:2203.02155); Rafailov et al., 2023
  (DPO, arXiv:2305.18290); Bai et al., 2022 (entrenamiento con preferencias para inocuidad,
  arXiv:2204.05862).

### N-EM-5 · Evaluación y métricas de calidad

- **Qué agrupa:** perplexity como métrica intrínseca; métricas de tarea (exact match, BLEU, ROUGE,
  pass@k); benchmarks y leaderboards (MMLU, HumanEval, MT-Bench/Arena) y su contaminación; LLM como
  juez; evals propios con un harness; protocolo de reproducibilidad (EM-03); frontera con métricas
  de servicio (EM-05, dominio de inferencia).
- **Por qué es núcleo:** «¿este modelo es bueno?» es la pregunta que cierra todas las demás (elegir
  modelo, validar un ajuste, comparar versiones); sus herramientas y trampas son comunes a todas las
  fases, así que fragmentarla por fase duplicaría el contenido.
- **Dependencias:** entra desde todos los N-EM; cruce con bases vectoriales/RAG (evaluación de
  recuperación: recall@k queda del lado de aquel dominio, la evaluación de la respuesta generada de
  este); salida hacia el cierre del recorrido (criterio de elección de modelo).
- **Definiciones imprescindibles:** métrica intrínseca vs. extrínseca, exact match, BLEU, ROUGE,
  pass@k, benchmark, leaderboard, contaminación, LLM-as-judge, eval propio, protocolo de evaluación.
- **Ejemplos prácticos candidatos:**
  1. Eval propio mínimo: 30 preguntas con respuesta esperada (del dominio del equipo) corridas por
     script contra el banco local; exact match + revisión manual; repetir tras el ajuste de N-EM-3
     (antes/después medible).
  2. Correr un subconjunto chico de un benchmark público (p. ej. unas decenas de ítems de MMLU) con
     lm-evaluation-harness (EleutherAI, https://github.com/EleutherAI/lm-evaluation-harness) sobre un
     Qwen chico local, con protocolo completo declarado.
  3. LLM como juez: usar un Qwen grande del banco para puntuar con rúbrica las salidas del Qwen
     chico; comparar con el juicio propio y discutir sesgos del juez (posición, verbosidad).
  4. Perplexity antes/después del ajuste fino sobre texto del dominio (puente con N-EM-2/3).
- **Cuadros comparativos candidatos:** familias de métricas (qué mide, cuándo sirve, trampa
  conocida); benchmarks frecuentes (tarea, tamaño, estado de contaminación conocida, fecha); juez
  humano vs. juez LLM vs. métrica automática (costo, fiabilidad, cuándo).
- **Preguntas guía → criterio:** «¿Qué preguntás antes de creer una cifra de leaderboard?» →
  protocolo, fecha, contaminación (EM-06). «¿Por qué tu eval de 30 preguntas vale más que un
  benchmark famoso?» → validez para TU tarea vs. comparabilidad pública. «¿Cuándo el juez LLM te
  engaña?» → sesgos conocidos del juez (Zheng et al., 2023).
- **Fuentes:** Papineni et al., 2002 (BLEU, ACL); Lin, 2004 (ROUGE, ACL); Hendrycks et al., 2021
  (MMLU, arXiv:2009.03300); Chen et al., 2021 (HumanEval/pass@k, arXiv:2107.03374); Zheng et al.,
  2023 (MT-Bench, arXiv:2306.05685); Sainz et al., 2023 (contaminación, Findings of EMNLP 2023).

**Grafo de dependencias del dominio:** N-EM-1 → N-EM-2 → N-EM-3 → N-EM-4, y N-EM-5 recibe de los
cuatro. Entradas externas: arquitecturas → N-EM-2; salidas externas: N-EM-3 → inferencia/despliegue;
N-EM-5 ↔ bases vectoriales (evaluación de RAG, frontera declarada).

---

## 4. Cadena de consecuencias (§2, corrida antes de recomendar la cadena de herramientas de EM-01)

Opciones para el eje práctico de «entrenar»: (A) sólo teoría, sin práctica de ajuste; (B) ajuste
completo de un modelo mediano; (C) LoRA/QLoRA sobre un Qwen chico con PEFT/TRL + export a Ollama.

1. **¿Dónde cae?** (A) cae en el estudiante: pierde la única práctica que forma criterio de
   entrenamiento y el pedido la nombra («entrenarlos»). (B) cae en el banco de ensayo: memoria y
   horas de cómputo que el contrato declara no observables (folio 002, MEDIOS). (C) cae en la guía:
   dos ecosistemas que explicar (HF para entrenar, Ollama para servir).
2. **¿Cuánto pesa ahí?** (A) incumple una frase literal del pedido: peso máximo. (B) el ajuste
   completo de un 7B en fp16 excede con holgura una máquina sin GPU dedicada (sólo los pesos son
   ~15 GB; con gradientes y estados del optimizador, varias veces eso — doc PEFT, motivación de
   LoRA/QLoRA en Hu 2021 y Dettmers 2023); no medible en este banco: la medida local falta y se
   asienta como falta. (C) un 0.5B con LoRA corre en CPU en tiempos de ejercicio (minutos a pocas
   horas según corpus); medible en el banco en la fase 3.
3. **¿Qué pierde la alternativa?** Elegir (C) pierde la experiencia de ajuste a escala real (queda
   cubierta por teoría + fuentes en N-EM-2/3) y suma la complejidad de dos herramientas; (A) pierde
   el objetivo del pedido; (B) pierde la operabilidad, restricción del contrato.
4. **¿Es reversible?** (C) es reversible: si la fase 3 mide que el QLoRA de 0.5B no corre en tiempos
   de ejercicio en el banco, se degrada ese ejemplo a «ilustrativo» sin tocar la estructura.
   Condición de revisión comprobable: la corrida del verificador técnico de la fase 3 con su tiempo
   medido. **Recomendación: (C).**

---

## 5. Marco de referencia propuesto desde este dominio (escenarios / contextos / actores)

Siguiendo la convención de la casa (catálogos `ESC-/CTX-/ACT-` por guía, ia-db índice 10 §«Antes de
citar»): numeración final a cargo de la integración; acá, nombres estables.

**Escenarios (situaciones donde se aplica mi dominio):**
- ESC «Elegir modelo»: hay que decidir qué modelo usar para una tarea → evaluación comparativa (N-EM-5, N-EM-2).
- ESC «Adaptar modelo»: el modelo elegido no se comporta como hace falta → decisión prompt/RAG/ajuste y, si toca, ajuste (N-EM-3, N-EM-1).
- ESC «Validar y vigilar»: hay que demostrar que el modelo (original o ajustado) sirve y sigue sirviendo ante versiones nuevas → eval propio y protocolo (N-EM-5).
- ESC «Entender lo que corre»: el equipo ya opera modelos (caso Qwen del pedido) y necesita el mapa causal de por qué se comportan así (N-EM-2, N-EM-4).

**Contextos (donde cambian las respuestas):**
- CTX «CPU sola» / CTX «GPU de consumo» / CTX «cómputo remoto o nube»: cambian tamaño de modelo ajustable, técnica (QLoRA vs. LoRA vs. completo) y qué ejemplos son medibles.
- CTX «datos abiertos» / CTX «datos propios o sensibles»: cambian licencias aplicables, qué se puede subir a servicios externos y cómo se arma el dataset (N-EM-1).

**Actores (roles, responsabilidad y alcance):**
- ACT «Estudiante»: recorre la guía; decide sobre sus propios ejercicios; no decide sobre datos ajenos.
- ACT «Integrador de aplicaciones»: consume modelos servidos; decide prompts y RAG; no re-entrena (enlace con la guía 16 ya fusionada).
- ACT «Entrenador/ajustador de modelos»: decide dataset, técnica e hiperparámetros; responde por el protocolo de reproducibilidad.
- ACT «Evaluador»: diseña y corre los evals; decide el veredicto comparativo; no corrige el modelo.
- ACT «Responsable de datos»: decide licencias, procedencia y uso permitido (N-EM-1); con veto sobre datasets.

---

## 6. Fuentes externas citadas (consolidado)

Todas verificables por autor, año e identificador; papers en arXiv/ACL por su ID; docs oficiales por
URL (consultadas como referencia de dominio; fecha de este informe: 2026-11-07).

| Afirmación que funda | Fuente |
| --- | --- |
| Arquitectura transformer | Vaswani et al., 2017, «Attention Is All You Need», arXiv:1706.03762 |
| Aprendizaje few-shot a escala | Brown et al., 2020, «Language Models are Few-Shot Learners», arXiv:2005.14165 |
| Leyes de escala | Kaplan et al., 2020, arXiv:2001.08361 |
| Cómputo-óptimo (≈20 tokens/parámetro) | Hoffmann et al., 2022, «Training Compute-Optimal LLMs», arXiv:2203.15556 |
| RLHF / instrucciones | Ouyang et al., 2022, arXiv:2203.02155 |
| Preferencias e inocuidad | Bai et al., 2022, arXiv:2204.05862 |
| LoRA | Hu et al., 2021, arXiv:2106.09685 |
| QLoRA | Dettmers et al., 2023, arXiv:2305.14314 |
| DPO | Rafailov et al., 2023, arXiv:2305.18290 |
| Deduplicación mejora modelos | Lee et al., 2022, arXiv:2107.06499 |
| Licencias y procedencia de datasets | Longpre et al., 2024, Data Provenance Initiative, Nature Machine Intelligence |
| MMLU | Hendrycks et al., 2021, arXiv:2009.03300 |
| HumanEval / pass@k | Chen et al., 2021, arXiv:2107.03374 |
| Juez LLM y sus sesgos | Zheng et al., 2023, arXiv:2306.05685 |
| Contaminación de benchmarks | Sainz et al., 2023, Findings of EMNLP 2023 |
| BLEU / ROUGE | Papineni et al., 2002, ACL · Lin, 2004, ACL |
| Qwen: modelos y licencias | Qwen2.5 Technical Report, arXiv:2412.15115 · https://huggingface.co/Qwen · https://qwen.readthedocs.io |
| Ollama no entrena; ADAPTER | https://docs.ollama.com/modelfile · https://github.com/ollama/ollama |
| PEFT / TRL | https://huggingface.co/docs/peft · https://huggingface.co/docs/trl |
| Conversión GGUF, perplexity | https://github.com/ggml-org/llama.cpp |
| Harness de evaluación | EleutherAI, https://github.com/EleutherAI/lm-evaluation-harness |

---

## 7. Dudas para quien pidió (formato rol · pregunta · por qué · prioridad · qué hago si no contesta)

1. PO · ¿Hay alguna GPU disponible (aunque sea de consumo) para los ejemplos de ajuste fino, o todo
   debe correr en CPU? · define el tamaño de modelo y los tiempos de los ejemplos operables de
   N-EM-3 · alta · asumo CPU sola: ejemplos con Qwen ≤1.5B y corridas cortas marcadas «medible»,
   el resto «ilustrativo».
2. PO · ¿Los ejemplos pueden descargar datasets públicos de Hugging Face, o la guía debe ser
   autocontenida con un mini-dataset propio versionado? · toca licencias, reproducibilidad y tamaño
   del repo · media · hago las dos: mini-dataset propio versionado como camino principal, dataset
   público citado como camino alternativo.
3. PO · ¿«Entrenarlos» incluye preentrenar desde cero como práctica, o basta la demo juguete más la
   teoría con fuentes? · fija el alcance del núcleo N-EM-2 y evita retrabajo · media · rige la
   lectura que menos agrega (EM-02): demo juguete + teoría; preentrenamiento real queda declarado
   fuera de alcance.

Sigue: incorporación verbatim de este informe como folio por la presidencia y veredicto del jurado · presidencia de la mesa
