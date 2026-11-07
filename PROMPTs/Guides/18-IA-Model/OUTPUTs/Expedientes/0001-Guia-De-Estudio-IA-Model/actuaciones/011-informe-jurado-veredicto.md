# Folio de veredicto — jurado (ronda de estructura)

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-07 |
| Autor | jurado (veredicto de la ronda de estructura) |
| Corrige | — |

Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas: cabecera y §0 (líneas 1–111, con el Mapa de
carga), §2 (§2.1–§2.3), §3 (§3.1–§3.4), §4, §7, §8 — la fila del jurado del Mapa de carga. Además
cargado entero: Cadena-De-Consecuencias 2.0 (§2 antes de cada elección entre opciones; sus criterios
de §6 se verifican sobre este folio). Excepcion-A-Un-Conocimiento 2.1 no se cargó: no hay ficha que
votar — `despacho/` no contiene ningún `*-ficha-*.md` (verificación E1 del refutador, cabecera de su
informe) y los cinco informes declaran no proponer excepciones.

Insumos leídos: folios 001, 002 y 003; pliego operativo (evidencia 002); los cinco informes de
comisión y el del refutador (`despacho/`); mi carta (evidencia 010); Profile
Study-Guide-Documentation. Clase de objeto: diseño de una norma o decisión; lectura P0–P3 la del
folio 002. Conforme a Rule-Mesa §3.5.4, este folio vota cada hallazgo consolidado con las cinco
funciones objetivo (evidencia, impacto, costo-beneficio, coherencia histórica, riesgo e
irreversibilidad); el fundamento de cada voto va en una línea. No emito hallazgos ni redacto
contenido nuevo: donde elijo entre propuestas, elijo entre lo que el panel escribió, con su motivo.

---

## 1. Veredicto por hallazgo

Cuórum: las cinco funciones objetivo aplicadas a cada ítem. Ningún `PROCEDE` de este folio es
irreversible en P2/P3 (todas las correcciones son aditivas o de consolidación documental): el veto
del juez de riesgo no se activa. Ningún hallazgo quedó anclado sólo en C tras el re-anclado de la
consolidación (RF-05): ninguno se degrada a pregunta.

| # | Nivel · Ancla | Voto | Motivo (una línea) |
| --- | --- | --- | --- |
| FP-01 | P1 · E2 | PROCEDE | Omitir generación no textual sería P0 aguas abajo; el doc 10 lo cubre; el alcance del laboratorio va a la fila 2 del lote, con default conceptual |
| FP-02 | P1 · E2 | PROCEDE | Dos lecturas reales de «no conoce del tema»; ACT-01 declara los prerrequisitos (lectura que menos agrega) y la fila 3 del lote lo ratifica |
| FP-03 | P1 · E2 | PROCEDE | Re-anclado por RF-05 (`grep -niE '\brag\b'` → sin salida, rc=1): la conclusión resiste; nivel unificado P2 y consolidado con H-IR-05 (asentar el agregado marcado, fila 4 del lote) |
| FP-04 | P2 · E2 | PROCEDE | Sin tabla de modelos de referencia con etiqueta exacta, las cifras de la guía quedan sin sujeto; la tabla vive en el doc 11 y todos la citan |
| FP-05 | P2 · E2 | PROCEDE | Consolidado con ARQIA-02 y H-EDI-06: capa volátil única y fechada (doc 11, `last_review`); los fundamentos no citan cifras de modelos salvo vía esa tabla |
| FP-06 | P2 · E4 | PROCEDE | OSAID 1.0 es la norma de referencia del término; «pesos abiertos» entra al glosario y el doc 11 distingue open source / open weights / licencia |
| FP-07 | P3 · E2 | PROCEDE | Regla de corte del glosario (entra el término que algún núcleo usa) barata, reversible y cierra la frontera «términos asociados» |
| EM-01 | P1 · E2 | PROCEDE | Ollama no entrena (doc oficial); la cadena HF (PEFT/TRL) → GGUF (llama.cpp) → Ollama queda fijada en el doc 06; consolidado con ARQIA-01 |
| EM-02 | P1 · E2 | PROCEDE | Lectura que menos agrega, declarada: «entrenar» = ajuste fino operable + demo juguete conceptual del preentrenamiento; se asienta en M2, sin pregunta al PO (el árbol la contesta) |
| EM-03 | P1 · E4 | PROCEDE | «Evidencia verificable» exige bloque «protocolo» por cada cifra (modelo/digest, parámetros, semilla, dataset); se norma una sola vez en M3 |
| EM-04 | P1 · E2 | PROCEDE | Contrato de profundidad (intuición primero; fórmula de una línea; sin cálculo diferencial en el hilo) en M3; evita la divergencia P1 entre redactores |
| EM-05 | P2 · E2 | PROCEDE | Frontera declarada: métricas de calidad (a–d) → doc 07; métricas de servicio (e) → doc 08, con enlace cruzado en M2 |
| EM-06 | P2 · E2 | PROCEDE | Contaminación y caducidad de benchmarks como contenido de primera clase del doc 07: realiza «formar criterio», no lo decora |
| EM-07 | P2 · E2 | PROCEDE | Licencias de pesos y datasets al doc 04 (y doc 11): práctica que «descargarlos» exige el primer día |
| EM-08 | P2 · E2 | PROCEDE | «Datos y corpus» es núcleo propio (doc 04) por la propia regla de afinidad del pedido; repartido sería apéndice |
| EM-09 | P3 · E4 | PROCEDE | Glosario bilingüe con forma canónica única por término (M1); consolidado con H-EDI-08 |
| H-IR-01 | P1 · E2 | PROCEDE | Consolidado con RF-03/ARQIA-04/H-EDI-01: Ollama/Qwen = decisión del contrato con origen en MEDIOS, no requisito del pedido; vía mixta (operar en el banco, criterio sobre el espacio de motores) |
| H-IR-02 | P1 · E1 | PROCEDE | E1 contundente (once modelos, ninguno de embeddings); es obstáculo, no escalada: pregunta de una línea a quien administra el banco, con el camino alternativo declarado |
| H-IR-03 | P2 · E1 | PROCEDE | Falla reproducida; `OLLAMA_HOST` parametrizado + paso 0 de verificación, enseñado una vez (doc 08) y citado después |
| H-IR-04 | P2 · E4 | PROCEDE | Contextos de recursos en M1 y modelo chico de referencia por ejemplo; default CPU x86-64 / 16 GB declarado; fila 1 del lote |
| H-IR-05 | P3 · E2 | PROCEDE | Mismo hecho que FP-03; nivel único P2: la corrección es asentar el agregado marcado, no retrabajar nada (fila 4 del lote) |
| ARQIA-01 | P1 · E2 | PROCEDE | Consolidado con EM-01: MEDIOS declara el segundo medio (ajuste fino PEFT sobre modelo chico) para la fase 3; «ilustrativo» queda sólo para preentrenamiento a escala |
| ARQIA-02 | P1 · E3 | PROCEDE | Capa estable / capa volátil con inventario único fechado y versiones fijadas por ejemplo; consolidado con FP-05 y H-EDI-06 |
| ARQIA-03 | P1 · E2 | PROCEDE | M2 define operativamente «autocontenido» (seguible sin abrir otro documento) y «no delta» (ninguno exige versión anterior; definiciones una sola vez, citadas) antes de despachar redactores |
| ARQIA-04 | P2 · E2 | PROCEDE | «Tipo Qwen» es medio medido, no alcance: ejemplos sobre el banco, comparativas documentales sobre el ecosistema abierto; fila 4 del lote |
| ARQIA-05 | P2 · E2 | PROCEDE | El bloque didáctico absorbe la sección «Preguntas guía» del Profile (aditivo, sin ficha); consolidado con H-EDI-07 y RF-02.4 |
| ARQIA-06 | P2 · E1 | PROCEDE | Comando y salida correctos: prefijo `IAM-` libre; prefijo y vocabulario `doc_type` se fijan antes de la fase 3 |
| ARQIA-07 | P2 · E2 | PROCEDE | El grafo de dependencias es entregable de M2 y la ruta de lectura de M0 deriva de él; ningún documento asume material que el grafo no le da por leído |
| ARQIA-08 | P3 · E2 | PROCEDE | La frase trunca se registra como ilegible en la tabla frase→función; fila de cortesía P3 en el lote, sin default que bloquee |
| H-EDI-01 | P1 · E1 | PROCEDE | E1 correcto y convergencia independiente triple (con H-IR-01 y ARQIA-04); la corrección va al origen según RF-03 |
| H-EDI-02 | P1 · E2 | PROCEDE | Portada-índice + cuerpo multi-documento: única lectura que satisface pedido y Profile a la vez; ratificada por el refutador contra la solución más chica; no sale al PO (el árbol contesta) |
| H-EDI-03 | P1 · E2 | PROCEDE | Dos rutas de lectura sobre los mismos documentos (formativa y de referencia) + prerrequisitos por documento, en M2 y M0 |
| H-EDI-04 | P2 · E2+E4 | PROCEDE | Autor-año (APA 7.ª) con lista de referencias por documento, asentado en M3; elección técnica dentro de las restricciones: la mesa la resuelve sola, no va al lote |
| H-EDI-05 | P2 · E1+E2 | PROCEDE | Frontmatter normado de la casa en todos los documentos y alta en la ia-db como tarea de publicación del plan; la ruta pedida no se mueve |
| H-EDI-06 | P2 · E4 | PROCEDE | Política de vigencia (versiones fijadas, fecha/entorno de validación, disparadores de `last_review`) normada en M3 y concentrada en el doc 11 |
| H-EDI-07 | P2 · E2 | PROCEDE | Forma normada del bloque didáctico (pregunta → criterio → respuesta → reenvío) en la plantilla de M3; consolidado con ARQIA-05 |
| H-EDI-08 | P3 · E2 | PROCEDE | Tabla de normalización de grafías (Qwen, open source, borrador) en M1; el testimonio no se toca |
| RF-01 | P1 · E1+E2 | PROCEDE | 31 núcleos para unos diez lugares, con E1/E2 enumerados; se adopta la tabla núcleo→dueño único de su §5 como temario consolidado (§2 de este folio) |
| RF-02 | P1 · E2 | PROCEDE | Presupuesto editorial medible: 15 documentos, 2–3 laboratorios operables por documento con dueño único, M3 único que absorbe los cinco aparatos, bloque didáctico absorbido; ataca el costo de aplicar, el defecto más caro de la clase |
| RF-03 | P1 · E2 | PROCEDE | Las cartas endurecieron dos medios en requisito; la corrección va al origen y los agregados salen marcados con default (fila 4): no se asientan por silencio |
| RF-04 | P2 · E2 | PROCEDE | Gobernanza regulatoria (NIST AI RMF, ISO/IEC 42001, AI Act) sin frase del pedido: queda fuera de alcance; el doc 11 conserva lo con origen (panorama, licencias, model cards, criterio de selección); reversible si el PO la pide |
| RF-05 | P2 · E1 | PROCEDE | El ancla de FP-03 estaba mal construida (re-corrida: `grep -ci` → 1 por «fragmentes»); se re-ancla antes de este veredicto; el hallazgo de fondo sobrevive |
| RF-06 | P2 · E2 | PROCEDE | Catorce dudas sin filtro violaban el pliego §4 (reglas 7 bis y 10); lote de cuatro filas + cortesía P3 + obstáculo por canal directo (§5 de este folio) |
| RF-07 | P2 · E1 | PROCEDE | Hecho de la corrida, autocorrección sin escalar: bitácora 02 de la ronda antes del cierre y una por fase en adelante |
| RF-08 | P3 · E2 | PROCEDE | Corrección de trazabilidad: la forma multi-documento se funda en el Profile (vía sección Framework del pedido), con «Reglas» como refuerzo de la cohesión global; costo nulo |

**Cuenta:** detectados 45 · PROCEDE 45 · NO PROCEDE 0 · ARCHIVA 0.

**Constancia de homogeneidad** (Rule-Mesa §3.5.4): todos los ítems salieron 5–0, por encima del
80 %. Se deja el ciclo marcado como sospechoso de homogeneidad; no hay `NO_PROCEDE` que el refutador
deba revisar, y consta que el refutador ya atacó el conjunto por evidencia y por aplicación (degradó
un ancla —RF-05— y recortó un agregado —RF-04—), que las comisiones trabajaron a ciegas y que la
convergencia triple sobre Ollama/Qwen fue independiente: la homogeneidad tiene causa observable, no
complacencia. Rendimiento del ciclo: 45 procedentes / 6 especialistas (cinco comisiones + refutador)
= 7,5 por especialista.

---

## 2. Temario consolidado (responde la PREGUNTA 1 del caso)

Se adopta el mapa del refutador (§5 de su informe), que resuelve los solapamientos probados en RF-01
por la señal que el folio 003 asignó, sin dejar hueco: cada tema que el pedido nombra tiene un dueño
único (cobertura verificada por el refutador, dictamen d). Once núcleos temáticos; dependencias
directas (las transitivas se omiten); «doc» relativo a `Guides/IA/IA-Model/`.

| N.º | Núcleo | Alcance (una línea) | Documento | Depende de |
| --- | --- | --- | --- | --- |
| 01 | Representación del lenguaje | Del texto a tokens, vocabularios y embeddings; similitud y ventana de contexto | `01-Representacion-Del-Lenguaje.md` | — |
| 02 | Arquitectura Transformer y variantes | Atención, decoder-only, posición, MoE: la mecánica común del parque de modelos vigente | `02-Arquitectura-Transformer.md` | 01 |
| 03 | Del modelo base al asistente | Base/instruct, alineación como taxonomía, muestreo, prompting, modos de razonamiento, alucinación | `03-Del-Modelo-Base-Al-Asistente.md` | 02 |
| 04 | Datos y corpus | Formatos de datasets, limpieza/deduplicación/contaminación, licencias y procedencia de pesos y datos | `04-Datos-Y-Corpus.md` | 03 |
| 05 | Preentrenamiento y leyes de escala | Objetivo autoregresivo, loss/perplexity, checkpoints, economía del preentrenamiento; demo juguete en CPU | `05-Preentrenamiento-Y-Leyes-De-Escala.md` | 04 |
| 06 | Ajuste fino y alineación | SFT, LoRA/QLoRA, DPO/RLHF; cadena HF (PEFT/TRL) → GGUF → Ollama hasta servir el resultado | `06-Ajuste-Fino-Y-Alineacion.md` | 05 |
| 07 | Evaluación y métricas de calidad | Perplexity, métricas de tarea, benchmarks y su contaminación, LLM-juez, evals propios con protocolo | `07-Evaluacion-Y-Metricas.md` | 03, 06 |
| 08 | Inferencia local: motores y cuantización | Motores (llama.cpp/Ollama/vLLM), GGUF, cuantización, memoria, métricas de servicio; montar, descargar, servir | `08-Inferencia-Local.md` | 02, 03 |
| 09 | Bases vectoriales y RAG | Embeddings aplicados, índices ANN/HNSW, motores vectoriales y el pipeline RAG con su diagnóstico por etapas | `09-Bases-Vectoriales-Y-RAG.md` | 01, 08 |
| 10 | Multimodalidad y generación no textual | VLM, audio y difusión a nivel conceptual; qué cambia y qué no respecto del transformer | `10-Multimodalidad-Y-Generacion-No-Textual.md` | 02, 03 |
| 11 | Panorama y ecosistema abierto (capa volátil) | Familias, licencias/pesos abiertos, model cards, tabla de modelos de referencia, criterio de selección; única pieza deliberadamente fechada | `11-Panorama-Y-Ecosistema-Abierto.md` | 05, 06, 07, 08, 09, 10 |

Elección A/B del refutador (unión de 31 vs consolidación con dueño único): se vota **B**, por los
pasos 2 y 4 de su cadena — el costo de A cae en la fase 3 y en el lector (62–124 laboratorios,
triple dueño), B es reversible (partir un documento aprobado es aditivo; fundir dos escritos es
retrabajo) — con su condición de revisión: si en la ronda 2 un documento supera el patrón de la casa
o su tope de laboratorios, se parte por el eje que el grafo declara.

Ruta de lectura del principiante (deriva del grafo, la publica M0):
M0 → M1 → 01 → 02 → 03 → 08 → 04 → 05 → 06 → 07 → 09 → 10 → 11.

---

## 3. Marco de referencia aprobado (responde la PREGUNTA 2 del caso)

Catálogos propios de esta guía, con nombres estables, conforme a la convención de la casa (todo
prefijo ESC-/CTX-/ACT- se cita con su guía). Consolidan las cuatro propuestas; las fusiones llevan
motivo.

**Escenarios:**

| ID | Escenario |
| --- | --- |
| ESC-01 | Entender y elegir un modelo para una tarea (ficha/informe técnico, licencia, hardware) |
| ESC-02 | Montar y servir un modelo localmente |
| ESC-03 | Preguntarle a un corpus propio: indexar y responder con fuentes (RAG) |
| ESC-04 | Adaptar un modelo a un dominio (ajuste fino, con la decisión prompt/RAG/ajuste antes) |
| ESC-05 | Evaluar, comparar y decidir con evidencia |
| ESC-06 | Trabajar con más de una modalidad (imagen, audio) |
| ESC-07 | Integrar el modelo en una aplicación — referencia a la guía 16 del destino, no se duplica |

(«Primer contacto» y «consulta puntual de referencia» de la propuesta editorial no son escenarios
del dominio sino las dos rutas de lectura: viven en M2/M0 — H-EDI-03.)

**Contextos:**

| ID | Contexto |
| --- | --- |
| CTX-01 | Equipo local sólo CPU (8–16 GB RAM): piso del lector; todo ejemplo base corre acá (default de la fila 1 del lote) |
| CTX-02 | Equipo con GPU de consumo |
| CTX-03 | Servidor compartido en red local (el banco del caso; `OLLAMA_HOST` parametrizado) |
| CTX-04 | Modelo consumido por API de terceros (sin pesos propios) |
| CTX-05 | Datos propios o sensibles: operación sin salida a internet |
| CTX-06 | Contenedor / CI: reproducibilidad, modelos como artefactos versionados |

**Actores** (definidos por lo que deciden):

| ID | Actor |
| --- | --- |
| ACT-01 | Estudiante-lector: sin conocimiento previo de IA, con terminal y programación básica (supuesto declarado; fila 3 del lote); en ESC-04 asume el rol de ajustador bajo el protocolo de M3 |
| ACT-02 | Desarrollador integrador: consume la API del motor; no decide qué modelo corre |
| ACT-03 | Operador del banco / infraestructura: decide recursos, versiones del motor y modelos disponibles |
| ACT-04 | Evaluador: diseña y corre los evals; decide el veredicto comparativo con evidencia |
| ACT-05 | Curador de datos: decide qué entra al corpus/índice, su troceo, licencias y procedencia |
| ACT-06 | Mantenedor de la guía: decide vigencia, `last_review` y la capa volátil |

Descartes con motivo: «docente/tutor» y «agente de IA lector» no deciden sobre el dominio — el
agente lector es audiencia del RuleSet (doble audiencia), no actor; «entrenador/ajustador» se funde
en ACT-01 actuando en ESC-04 (en una guía de estudio quien ajusta es el lector practicando);
«responsable de datos» y «curador del corpus» se funden en ACT-05 (misma pregunta: qué dato entra y
con qué derecho).

---

## 4. Estructura documental aprobada (responde la PREGUNTA 3 del caso)

Todo bajo `Guides/IA/IA-Model/` del repo destino, con `IA-Model-Guide.md` como raíz (la ruta literal
del pedido como portada-índice; H-EDI-02, ratificada por el refutador contra la solución más chica,
con la cita de origen corregida por RF-08: la forma la funda el Profile vía la sección Framework del
pedido).

| Pieza | Ruta | Qué lleva |
| --- | --- | --- |
| M0 — Raíz | `IA-Model-Guide.md` | Portada, tabla de contenido, las dos rutas de lectura (formativa y de referencia) derivadas del grafo de M2 |
| M1 — Marco de referencia | `Marco-De-Referencia.md` | Catálogos ESC/CTX/ACT de §3, glosario bilingüe (forma canónica única por término, con fuente; EM-09/H-EDI-08/FP-07), tabla de normalización de grafías |
| M2 — Cohesión global | `Cohesion-Global.md` | Grafo de dependencias (mermaid), definición operativa de autocontenido/no-delta (ARQIA-03), fronteras entre núcleos (EM-05), lecturas declaradas del pedido (EM-02) |
| M3 — Convenciones | `Convenciones.md` | Citado autor-año (APA 7.ª) + lista por documento; patrón de ejemplo operable (entorno, versiones fijadas, salida esperada); bloque «protocolo» por cifra (EM-03); contrato de profundidad (EM-04); política de vigencia y capa volátil (H-EDI-06/ARQIA-02); plantilla del documento temático con el bloque didáctico |
| Temáticos (11) | `01-…` a `11-…` según §2 | Un documento por núcleo, dueño único, estructura interna común |

15 piezas en total: dentro del patrón de la casa (13–17 por corpus) y del presupuesto de RF-02.
Identidad: frontmatter normado de la casa (`doc_id` con prefijo `IAM-`, libre por E1 de ARQIA-06;
`doc_type` ∈ tema | marco-de-referencia | mapa | anexo | indice; `origin`, `confidence`,
`last_review`, `audience`, `traces`) y alta de la guía en `ia-db/indexes/` como tarea de publicación
del plan (H-EDI-05).

**Estructura interna común del documento temático** — las seis secciones del Profile, con el único
ajuste fundado (ARQIA-05/H-EDI-07/RF-02.4: el bloque didáctico absorbe «Preguntas guía»; aditivo,
sin ficha), más la envoltura que las decisiones de arriba exigen:

0. Envoltura: frontmatter normado + índice propio + prerrequisitos («qué leer antes», del grafo de
   M2) y enlaces precedente/siguiente. El aparato (protocolo, citado, vigencia) se cumple **citando
   M3**, no repitiéndolo.
1. Definición — qué es, qué problema resuelve, qué no es.
2. Aplicación por escenario — qué aporta en cada ESC y qué cambia por CTX.
3. Ejemplos concretos — 2 a 3 operables por documento con dueño único (corren en el banco, se
   declaran reproducibles en CTX-01 o marcan su contexto); el resto «ilustrativo» marcado.
4. Bloque didáctico — pregunta guía → criterio que forma → respuesta explicativa → reenvío a la
   sección o ejemplo que la realimenta (absorbe la sección «Preguntas guía» del Profile).
5. Criterios de calidad — cómo se distingue una versión buena de una pobre.
6. Anexo — plantilla o lista de verificación comentada, cuando corresponda.

**PREGUNTA 4 del caso — ejemplos prácticos operables por núcleo** (respuesta cerrada, sin
«depende»; verbo del pedido → documento dueño): montar y descargar → doc 08 (pull/show, tabla de
hardware); inferir → docs 03 y 08 (temperatura, few-shot, streaming, tokens/s); entrenar → doc 06
(QLoRA sobre Qwen ≤1.5B con PEFT/TRL, export GGUF, servido en el banco; demo juguete de
preentrenamiento en doc 05); medir → doc 07 (mini-eval propio con protocolo, LLM-juez
contrastado); RAG y base vectorial → doc 09 (coseno a mano, motor vectorial local, mini-RAG sin
framework, chunking a dos tamaños); multimodal → doc 10 (descripción de imagen con el VLM del
banco); elección → doc 11 (model card + elección guiada con la tabla de referencia). Cada
laboratorio existe una sola vez y los demás documentos lo citan. Los de embeddings (doc 09) quedan
condicionados al obstáculo del banco, con el camino alternativo declarado; los de generación de
imagen, al default de la fila 2 del lote (conceptual + «ilustrativo»).

---

## 5. Lo abierto, con default (para el lote del PO) y el obstáculo

Se adopta el lote consolidado del refutador (RF-06), más la fila de cortesía que dejó a decisión:
viaja, porque es P3 sin default que bloquee y cierra la fidelidad del enunciado.

| # | Pregunta | SI NO RESPONDÉS |
| --- | --- | --- |
| 1 | ¿Hay GPU (aunque sea de consumo) para los laboratorios de ajuste fino, y cuál es el piso de hardware del lector? | Rige CPU sola y piso CPU x86-64 / 16 GB RAM: ajuste con Qwen ≤1.5B, labs largos «ilustrativo»; nada bloqueado |
| 2 | ¿La generación de imagen/audio lleva laboratorio operable o alcanza el nivel conceptual en el doc 10? | Rige conceptual con ejemplo «ilustrativo»; promoción diferida con evento de cierre: viabilidad declarada en el banco |
| 3 | ¿El lector tiene manejo básico de terminal y de un lenguaje de programación? | Rige el supuesto de ACT-01; cada pieza que exija más lo marca al abrir |
| 4 | Ratificación de agregados marcados: banco Qwen/Ollama como medio de los ejemplos (no alcance) y RAG como lectura aplicada de «base de datos vectoriales» | Quedan como decisión del contrato con origen en MEDIOS y agregado «propuesto, sin ratificar»; los ejemplos corren igual; nada irreversible depende |
| 5 | (Cortesía P3) La frase trunca del pedido «…modelos open sorce con el modelo.», ¿nombraba otro modelo del entorno? | Se trata como descriptiva, duplicada por la frase siguiente; nada bloqueado |

Obstáculo — no va al lote (decisión fundada; falta la llave): pregunta de una línea a quien
administra el banco: «¿incorporás un modelo de embeddings (p. ej. la variante chica de la familia
Qwen3-Embedding) y se verifica `POST /api/embed`?»; si no, rige el camino alternativo declarado por
la comisión de inferencia (biblioteca local, con el eje no fijo declarado).

Fichas de excepción: **no hay ninguna que votar** (verificado en cabecera); el punto 5 de la carta
queda sin materia.

Regla de cierre propia de la clase: cumplida — las cuatro preguntas del caso quedan respondidas por
separado, sin «depende» (§2, §3, §4 de este folio). Con una sola ronda, el criterio de corte de dos
rondas limpias no se alcanza: si la presidencia cierra el ciclo, el rótulo es **por decisión**, con
lo abierto de §5 enumerado, y no es una falta.

Sigue: incorporación de este folio como actuación, consolidación final y resolución de la
presidencia (bitácora 02 de la ronda antes del cierre, por RF-07) · presidencia de la mesa ·
Cierra con: folio `resolucion` del expediente.
