---
doc_id: BIT-16-N0b
doc_type: dossier-complementario
title: N0b — Mirada de producto, datos para la IA, perfil «AI Engineer» y registro de decisiones de arquitectura
status: borrador para el jurado
origin: agent (investigador del despacho N0b)
confidence: 0.75
last_review: 2026-10-26
audience: [jurado de la mesa evaluadora, plan de integración]
traces: [BIT-16-03, Mesa/I-02 PR-1, Mesa/I-03 PR-9 PR-10, Mesa/I-04 PR-13 PR-14, N1, N2, N3, N4, N5, N6]
---

# N0b — Producto, datos, perfil y decisiones de arquitectura

Dossier complementario del marco de referencia N0. Le da al jurado lo necesario para votar cinco propuestas de la presidencia: **PR-1** (actor «AI Engineer»), **PR-9** (mirada de producto), **PR-10** (datos para la IA), **PR-13** (registro de decisiones de arquitectura) y **PR-14** (objetivos de aprendizaje por actor). Para cada tema contesta una sola pregunta: **¿hay fuentes de peso para tratarlo en la guía?**

Convenciones: los niveles de evidencia son los del contrato (BIT-16-00 §3): **E1** ejecutado, **E2** cita literal con ubicación, **E3** contraejemplo construido y **E4** regla o documentación oficial con URL y fecha. Las fuentes de este dossier llevan el prefijo `B` (§7), y las de los núcleos se citan como `N3 F26`, `N1 §4.7`, etc. Lo que es **[criterio propio]** se marca así. Los insumos I-02 a I-04 aportan forma y no son citables: acá **no se usan como evidencia**.

## Índice

- [1. Relación con los insumos del PO y con los núcleos](#1-relación-con-los-insumos-del-po-y-con-los-núcleos)
- [2. Definiciones con fuente](#2-definiciones-con-fuente)
- [3. Desarrollo](#3-desarrollo)
  - [3.1 (a) Mirada de producto](#31-a-mirada-de-producto)
  - [3.2 (b) Datos para la IA](#32-b-datos-para-la-ia)
  - [3.3 (c) Perfil «AI Engineer» y objetivos de aprendizaje](#33-c-perfil-ai-engineer-y-objetivos-de-aprendizaje)
  - [3.4 (d) Borrador del registro de decisiones de arquitectura](#34-d-borrador-del-registro-de-decisiones-de-arquitectura)
- [4. Preguntas guía con respuesta explicativa](#4-preguntas-guía-con-respuesta-explicativa)
- [5. Criterios de calidad y antipatrones](#5-criterios-de-calidad-y-antipatrones)
- [6. Recomendación para el jurado](#6-recomendación-para-el-jurado)
- [7. Tabla de fuentes](#7-tabla-de-fuentes)
- [8. Evidencia ejecutada](#8-evidencia-ejecutada)
- [9. Abierto / no verificado](#9-abierto--no-verificado)

---

## 1. Relación con los insumos del PO y con los núcleos

| Propuesta | Qué pide | Qué hay hoy en los núcleos | Qué aporta este dossier |
|---|---|---|---|
| PR-9 (I-03) | Mirada de producto: cuándo la IA aporta valor, diseño con respuestas no deterministas, definición del éxito | Hay piezas técnicas sueltas: «si podés escribir una función, hacelo» (N1 P1, N4 P2, N6 P1), la simplicidad según Anthropic (N4 F21) y «temperatura 0 ≠ determinismo» (N1 §8.6, sin fuente). **Ningún núcleo trata el éxito ni el diseño de la experiencia** | Seis fuentes de peso verificadas (B01 a B07; B06 es la ubicación de B05) y una propuesta de subsección corta (§3.1, §6) |
| PR-10 (I-03) | Datos para la IA: calidad, preparación, conjuntos de evaluación, realimentación | N3 cubre fragmentación (N3 F26), conjunto de oro y recall@k/MRR (N3 E3, P5), evaluadores de recuperación y fidelidad (N3 F25), y N5 cubre `Microsoft.Extensions.AI.Evaluation` (N5 F07, F08). **Falta**: cómo se arma el conjunto de evaluación, la calidad del contenido fuente y la realimentación | Guía oficial de la fase de preparación de RAG (B08, B09), tres papers de evaluación (B10 a B12), el sesgo del LLM juez (B13) y la realimentación (B03, B05, B14). Veredicto: **alcanza para una subsección**, no para una sección propia (§3.2) |
| PR-1 (I-02) | Agregar el actor «AI Engineer» o declarar que el desarrollador .NET asume ese rol, definido por responsabilidades | BIT-16-03 §3: ACT-DEV, ACT-ARQ, ACT-OPS, ACT-SEC, ACT-USR. Ningún actor decide el **criterio de éxito** de un escenario | Definiciones con fuente (B14 a B18) y una propuesta: **faceta de ACT-DEV, no actor nuevo**, más un ajuste en ACT-ARQ (§3.3) |
| PR-14 (I-04) | Objetivos de aprendizaje por actor al abrir la guía | No existen | Lista de objetivos por actor **[criterio propio]**, trazada a secciones y fuentes (§3.3.4) |
| PR-13 (I-04) | Registro de decisiones de arquitectura con alternativas, criterio y consecuencias | Las decisiones están, pero dispersas en N1 a N6 | Borrador de diez decisiones en formato ADR ligero, **todas con fuente en los núcleos**, y la marca de las que piden alternativas sin respaldo (§3.4) |

---

## 2. Definiciones con fuente

| Término | Definición | Fuente |
|---|---|---|
| **Adecuado al propósito** (*fit for purpose*) | «Microsoft AI systems are fit for purpose in the sense that they provide valid solutions for the problems they are designed to solve.» Exige documentar, por cada uso previsto, el problema, las **métricas de desempeño** y los **tipos de error**, cada uno con su criterio de liberación (A3.3), y un **plan de evaluación** (A3.4) | B04, Goal A3, p. 6 (E2; corregido en la verificación adversarial: decía p. 5) |
| **Función de recompensa** (en diseño de producto) | El mecanismo con que el sistema decide qué cuenta como éxito o fracaso. Se diseña de forma colaborativa, y «Weighing the cost of false positives and false negatives is a critical decision» | B02, capítulo *User Needs + Defining Success* (E2) |
| **Confabulación** | «The production of confidently stated but erroneous or false content (known colloquially as "hallucinations" or "fabrications") by which users may be misled or deceived.» | B07, §2, riesgo 2 (E2) |
| **Conjunto de evaluación de RAG** | Colección con tres datos por caso: **Query** («represents a legitimate user's potential prompt»), **Context** (el texto real que la responde, con página) y **Answer** (una respuesta válida) | B09, *Gather test query output* (E2) |
| **Consulta no respondible** (*unaddressed query*) | Una consulta que los documentos no cubren. Se incluye a propósito para comprobar que el sistema dice que no sabe | B09, *Unaddressed queries* (E2) |
| **Evaluación sin referencia** (*reference-free*) | Métricas para recuperación, fidelidad y calidad de generación que funcionan «without having to rely on ground truth human annotations» | B10, resumen (E2) |
| **LLM como juez** | Un LLM fuerte que evalúa respuestas abiertas. Tiene sesgos documentados: «position, verbosity, and self-enhancement biases, as well as limited reasoning ability» | B13, resumen (E2) |
| **AI engineering** | Construir aplicaciones sobre modelos fundacionales ya entrenados («adapting foundation models to solve real-world problems»). Evolucionó desde la ingeniería de ML y, comparada con ella, «is moving closer to product» | B15 (README, *About the book*) y B16 (resúmenes de los capítulos 1 y 10) (E2) |
| **AI Engineer** (formulación de 2023) | El rol intermedio entre investigación de ML e ingeniería de software que crece por oferta y demanda («~5000 LLM researchers in the world, but ~50m software engineers»). Le toca «product-specific data and evals» | B14 (E2) |
| **ADR** | Registro de una decisión de arquitectura significativa: contexto, decisión, estado y consecuencias, todas, «not just the "positive" ones». Microsoft agrega las alternativas descartadas, el nivel de confianza y que el registro sea de sólo agregado | B19, B20 (E2) |

---

## 3. Desarrollo

### 3.1 (a) Mirada de producto

**Pregunta: ¿hay fuentes de peso?** **Sí.** Hay cinco fuentes institucionales o revisadas por pares, verificadas hoy. Ninguna es de .NET, y no hace falta que lo sea, porque la mirada de producto no depende del stack.

#### 3.1.1 Cuándo la IA aporta valor y cuándo no

| Fuente | Lo que dice (literal) | Aplicación a la guía |
|---|---|---|
| B02 (Google PAIR, *User Needs + Defining Success*) | «It's important to question whether adding AI to your product will improve it.» «Often a rule or heuristic-based solution will work just as well, if not better, than an AI version.» La IA probablemente **no** es mejor para: «Maintaining predictability», «Providing static or limited information», «Minimizing costly errors» | Es la misma regla que N1 P1, N4 P2 y N6 P1 («If you can write a function…»), ahora desde el producto. Las tres condiciones de «no conviene» son una lista de control para cada escenario ESC-01 a ESC-05 |
| B02 | Automatizar cuando la gente quiere evitar la tarea; aumentar cuando la valora. Aun automatizando, debe haber «almost always … an option for human oversight» | Fundamenta ESC-03 (la aplicación decide) frente a ESC-04 (decide el modelo) y la aprobación humana de N4 y N6 |
| B03 (Anthropic, 2024-12-19) | «finding the simplest solution possible, and only increasing complexity when needed. This might mean not building agentic systems at all.» «For many applications, however, optimizing single LLM calls with retrieval and in-context examples is usually enough.» Y además: «you should consider adding complexity only when it demonstrably improves outcomes» | El valor se **demuestra midiendo**. Une producto con evaluación (§3.2) |
| B05, B06 (NIST AI RMF 1.0, 2023-01-26) | MAP 1.4: «The business value or context of business use has been clearly defined». MAP 3.1: «Potential benefits … are examined and documented». MAP 3.2: «Potential costs, including non-monetary costs, which result from expected or realized AI errors…». MANAGE 1.1: «A determination is made as to whether the AI system achieves its intended purposes … and whether its development or deployment should proceed» | Da la forma de una **decisión de seguir o no** (*go/no-go*), con beneficio y costo del error documentados. Es un marco voluntario de EE. UU., no una norma .NET: la guía lo usa como estructura de preguntas, no como requisito |
| B04 (Microsoft Responsible AI Standard v2, junio de 2022) | Goal A3 «Fit for purpose»: problema, métricas de desempeño y tipos de error, cada uno con su criterio de liberación, más un plan de evaluación (A3.3, A3.4) | La «definición de éxito» con fuente: **métrica + tipos de error + umbral + plan de evaluación**, antes de construir |

**Síntesis [criterio propio, sobre B02 a B06]**: antes de elegir la estrategia técnica (N1), cada escenario contesta cuatro preguntas: (1) ¿qué hace hoy la persona y por qué la IA lo mejoraría?; (2) ¿hay una regla o un formulario que alcance?; (3) ¿qué cuesta un error (falso positivo o falso negativo) y quién lo absorbe?; (4) ¿con qué métrica y con qué umbral se decide seguir? En Movilidad Urbana encaja con lo que N6 ya concluyó: la IA aporta en la **entrada** (texto libre → modelo tipado) y en la **consulta** (lenguaje natural → caso de uso), no en las reglas (N6 P1). La encuesta de tres pasos queda afuera como contraejemplo (N6 C8).

#### 3.1.2 Diseñar con respuestas no deterministas

Las 18 pautas de Amershi et al. (CHI 2019, B01) son una fuente revisada por pares de referencia para la experiencia (que sea «la más citada» **no verificado**) de uso de sistemas con IA. Están agrupadas por momento de la interacción: «"Initially" (Guideline 1 & Guideline 2), "During interaction" (Guideline 3 - Guideline 6), "When wrong" (Guideline 7 - Guideline 11), and "Over time" (Guideline 12 - Guideline 18)» (B01, §3). Se validaron con 49 practicantes de diseño sobre 20 productos (B01, resumen). Las que tocan directamente a una capa de IA en una app .NET:

| Pauta (literal, B01 Tabla 1) | Qué implica en la capa de IA | Dónde ya está en los núcleos |
|---|---|---|
| G1 «Make clear what the system can do.» / G2 «Make clear how well the system can do what it can do.» | El asistente declara su alcance y advierte que puede equivocarse | No está. Va a N6 (página de chat o README de la demo) |
| G9 «Support efficient correction.» | El usuario corrige lo que el modelo propuso antes de que se guarde | N6 D1, D2: el dominio rechaza y la persona ve el error |
| G10 «Scope services when in doubt.» («gracefully degrade … when uncertain») | Ante duda, preguntar o caer al camino sin IA | N1 §4.7: `TryGetResult` → `null` → «la aplicación decide el camino sin IA» |
| G11 «Make clear why the system did what it did.» | Citas en RAG; mostrar qué herramienta se llamó | N3 C7, N6 Q9 (citas) |
| G15 «Encourage granular feedback.» | Capturar la valoración del usuario por respuesta | No está. Ver §3.2.4 |
| G18 «Notify users about changes.» | Avisar cuando cambia el modelo o su versión | Relaciona con CTX-PROD («un plan cuando el modelo … cambia de versión», BIT-16-03) |

Para T3, el Standard de Microsoft pide informar a las personas que interactúan con un sistema de IA, salvo que sea obvio por el contexto (B04, Goal T3, p. 12; decía p. 9). En la demo es obvio por construcción, y la guía sólo lo menciona.

**Qué no dicen estas fuentes**: ninguna habla de la temperatura ni del muestreo. La afirmación «temperatura 0 no garantiza determinismo» sigue **sin fuente** (N1 §8.6) y no sale de este dossier.

#### 3.1.3 Definir el éxito

Con fuente: el éxito se define **antes** como métrica + tipos de error + criterio de liberación + plan de evaluación (B04 A3.3–A3.5), con beneficio y costo del error documentados (B05 MAP 3.1, 3.2). Después se decide si seguir (B05 MANAGE 1.1). PAIR agrega que el costo relativo de falsos positivos y falsos negativos es la decisión crítica (B02). Anthropic agrega que la complejidad se suma sólo cuando demostrablemente mejora los resultados (B03).

Aplicado a la demo **[criterio propio]**: para C2/C3 (extracción), la métrica es la tasa de propuestas que pasan las reglas sin corrección humana, y el error caro es el **falso aceptado**, un valor fuera de catálogo que entra (N6 T2, H3–H5). Para C4 (ayuda RAG) se usan recall@k sobre el conjunto de oro y la fidelidad de la respuesta (N3 P5), y el error caro es la respuesta que cita y contradice (N3 E5). Para C5 (baja), cero bajas sin aprobación (N6 Q5). Son métricas **del escenario**, no del modelo, que es justo lo que pide PR-9.

> **2026-10-28 — Parche P-02 (ciclo 1).** «Falso aceptado» tenía tres sentidos en esta bitácora. Desde hoy se separan así:
> 1. **Falso aceptado** (métrica de C2, la única que lleva ese nombre): proporción de propuestas de alta que alteran o inventan un dato que el texto de entrada dio, o que no dio, sin declararlo, y que pasan las reglas de `LocalidadRules`. Se mide contra un conjunto de oro de textos de entrada con el dato esperado, con N y el criterio escritos antes de correr. La unidad es la propuesta. El denominador son las propuestas que pasan las reglas.
> 2. **Escritura sin confirmación**: toda escritura que se ejecuta sin la confirmación de la persona. No es una tasa. Es una invariante de construcción que tiene que dar 0 y se prueba en `Cableado/` (M3, P-35).
> 3. **Propuesta corregida por la persona** (R-C02): métrica de producto de CTX-PROD, que la demo no mide.
>
> El 2/10 de X2 D1 (Wilson 95 % [0,06; 0,51]) fue una observación del sentido 1 sobre un solo pedido. No sostiene ningún umbral. La guía dice «no medido» para el falso aceptado de C2. El umbral lo fija ACT-ARQ por escenario, después de medir con un N que dé un intervalo con ancho menor o igual a 0,2, o sea N ≥ 96 para p cerca de 0,5. Ese N es un criterio propio derivado de la aproximación normal y no se corre en este ciclo.

> **2026-10-28 — Parche P2-13 (ciclo 1, ronda 2).** MI-24 se re-registra **NO_PROCEDE de «investigar»** (C1-72 = A): (a) quedó resuelta por P-40; (b) no hay umbral para el falso aceptado de C2 hasta definir la métrica (P-02, sentido 1) y medirla con N suficiente; en la guía, «no medido». En la nota de P-02, la frase «con un N que dé un intervalo con ancho menor o igual a 0,2, o sea N ≥ 96 para p cerca de 0,5. Ese N es un criterio propio derivado de la aproximación normal» se reemplaza por: «con una tasa de la tarea según R-LLM-3d (K ≥ 10 textos de entrada redactados antes, m ≥ 3 semillas por texto, intervalo sobre los textos)». El 2/10 de X2 D1 es una tasa de un pedido y no fija un umbral de tarea; AH-02 descarta el intervalo normal con estos N.



### 3.2 (b) Datos para la IA

**Pregunta: ¿hay fuentes de peso?** **Sí, para una subsección. No para una sección propia.** El «data-driven AI» en sentido amplio (entrenamiento, ajuste fino, ingeniería de datasets) cae **fuera de alcance**, porque la guía no entrena ni ajusta modelos (B16, cap. 8, trata justamente el armado de datasets para entrenar). Lo que sí entra con fuente es lo que hace falta para una capa de IA sobre modelos ya entrenados: **(1) calidad y preparación del contenido fuente de RAG, (2) conjunto de evaluación y (3) realimentación.**

#### 3.2.1 Calidad y preparación del contenido fuente

La serie oficial del Azure Architecture Center «Design and develop a RAG solution» (B08, ms.date 2025-12-17; act. 2026-07-02) divide el trabajo en fases: preparación, fragmentación, enriquecimiento, embeddings, recuperación y evaluación de punta a punta. Cierra así: «You should evaluate each step independently for optimization, but remember that the end result is what your customers experience.» La fase de preparación (B09, ms.date 2025-10-10) aporta lo que hoy no tiene ningún núcleo:

- **Dominio primero**: «clearly define the business requirements for the solution or use case. These requirements help you determine what kind of questions the solution should answer and what source data or documents help answer those questions.» Es el enlace explícito entre producto (§3.1) y datos.
- **Calidad del contenido**: «Language models and other AI services don't produce good results if you provide them with poor-quality content.» Además: pertinencia, representación («at least two pieces of content for each variation and format») y calidad física.
- **Restricciones de seguridad desde la preparación**: «If your workload requires that different users only have access to distinct content … ensure that you understand how to retain those access permissions in your chunking solution.» Coincide con N3 P9 y C5 (filtro por permiso) y con OWASP LLM08 (N3 F27).
- **Datos personales**: «Real content must go through a cleaning process to remove personal data». Encaja con CTX-SENS y con N6 T5.

La técnica de fragmentación ya está en N3 (N3 F26: 512 tokens con 25 % de solapamiento como punto de partida; por encabezado en documentos estructurados). Este dossier no la repite.

#### 3.2.2 Conjunto de evaluación

B09 define el formato (**Query / Context / Answer**), la generación sintética asistida por un LLM con revisión obligatoria («A SME should review and validate the output») y las **consultas no respondibles**, para comprobar que el sistema dice que no sabe. Además: «Review the body of questions and answers periodically to ensure that they continue to accurately reflect the source documents.»

Literatura revisada por pares:

| Fuente | Aporte | Publicación verificada |
|---|---|---|
| B10 RAGAS (Es, James, Espinosa-Anke, Schockaert) | Evalúa por separado la recuperación («identify relevant and focused context passages»), la fidelidad («exploit such passages in a faithful way») y la calidad de generación, sin anotación humana | arXiv 2309.15217 (2023-09-26); EACL 2024 System Demonstrations, `2024.eacl-demo.16` |
| B11 ARES (Saad-Falcon, Khattab, Potts, Zaharia) | Tres dimensiones: «context relevance, answer faithfulness, and answer relevance». Jueces chicos ajustados con datos sintéticos, más «a small set of human-annotated datapoints» | arXiv 2311.09476 (2023-11-16); NAACL 2024, `2024.naacl-long.20` |
| B12 Encuesta de evaluación RAG (Yu et al.) | Revisa métricas de recuperación y generación (relevancia, exactitud, fidelidad) y los límites de los benchmarks actuales | arXiv 2405.07437 (2024-05-13); versión publicada en *Big Data*, Communications in Computer and Information Science (Springer, 2025), pp. 102–120, DOI `10.1007/978-981-96-1024-2_8` (Crossref; corregido en la verificación adversarial, decía «venue no verificado») |
| B13 LLM como juez (Zheng et al.) | Acuerdo de más del 80 % con preferencias humanas para jueces fuertes, pero con sesgos de posición, verbosidad y autofavorecimiento | arXiv 2306.05685; NeurIPS 36 (Crossref `10.52202/075280-2020`) |

**Puente con .NET (ya verificado en los núcleos)**: las tres dimensiones de B10 y B11 se corresponden con evaluadores de `Microsoft.Extensions.AI.Evaluation.Quality`: `RetrievalEvaluator` (recuperación), `GroundednessEvaluator` (fidelidad) y `RelevanceEvaluator` (relevancia de la respuesta) (N3 F25, N5 F07). Que la correspondencia es conceptual y no de implementación es **[criterio propio]**, porque Microsoft no cita RAGAS ni ARES en esas páginas (no verificado que no lo haga en otras). Los paquetes `Evaluation`, `Quality` y `Reporting` están estables en 10.11.0, y `NLP` y `Safety` sólo en preview (§8, B-E3). B13 respalda lo que N5 ya dice por fuente oficial: leer el puntaje del juez como tendencia y no como compuerta del build (N5 F08). B16 (cap. 3) coincide: «AI judges should be supplemented with exact evaluation, human evaluation, or both.»

**Lo que la demo ya tiene y lo que le falta [criterio propio]**: N3 E3 ya armó un conjunto de oro de 8 preguntas sobre 12 reglas, con recall@k y MRR. Le faltan tres cosas, según B09: (1) la **respuesta esperada** además del fragmento esperado; (2) **consultas no respondibles** («¿cuánto sale el boleto?»), que tienen que dar «no sé», y esto se cruza con N3 C7; (3) que la revisión del conjunto quede atada al cambio de las `*Policy`. Como N6 genera el corpus desde el código (N6 P3), el conjunto de oro tiene que versionarse con ese código.

> **2026-10-28 — Parche P-22 (ciclo 1).** l. 137: las métricas del conjunto de evaluación de ESC-02 son hit@k, recall@k, MRR@k y abstención, con las definiciones de N3 §2.8 (nota de Parche P-22).


#### 3.2.3 Datos propios que **no** son texto

Para los datos tabulares del dominio, la decisión ya está tomada con evidencia: van por herramienta sobre el caso de uso, no por RAG (N3 P1, A2; N6 P2). «Preparar los datos» de una tabla para la IA, entonces, es diseñar el caso de uso que la herramienta expone (agregados sin datos personales, N6 T5), no indexarla. Esto se dice en la guía para evitar la lectura «datos para la IA = vectorizar todo».

#### 3.2.4 Realimentación

| Fuente | Qué dice |
|---|---|
| B01 G15 | «Enable the user to provide feedback indicating their preferences during regular interaction with the AI system.» |
| B04 Goal RS3 | Monitoreo, realimentación y evaluación continuos. RS3.1 incluye «processes by which customers can submit information about failures and concerns» |
| B05 TEVV (Apéndice A) | Tareas de operación: «ongoing monitoring for periodic updates, testing, … the tracking of incidents or errors reported» |
| B16 cap. 10 | La realimentación conversacional sirve para analítica, mejora del producto y el *data flywheel*. Tradicionalmente fue responsabilidad de producto, y «more AI engineers are now becoming involved» |

**Alcance propuesto [criterio propio]**: la guía explica el circuito (el usuario marca la respuesta → se registra sin datos personales → alimenta el conjunto de evaluación). La demo **no** lo implementa, porque es CTX-PROTO (BIT-16-02 §5, tensión demo/producción) y queda en la lista de CTX-PROD. Si la mesa quiere un ejemplo, alcanza con un endpoint que guarde `(id de respuesta, pulgar arriba/abajo)` junto a la traza de N5, pero eso **no se compiló** en este despacho.

### 3.3 (c) Perfil «AI Engineer» y objetivos de aprendizaje

**Pregunta: ¿hay una definición con fuente de peso?** **Parcial.** Hay dos formulaciones influyentes: el ensayo de 2023 (B14) y el libro de O'Reilly de 2025 (B15, B16), del que se leyeron sólo el README y los resúmenes oficiales de los capítulos publicados por la autora. Hay también una descripción de rol de Microsoft (B17, B18). **No hay** una definición normativa (estándar o clasificación ocupacional) que haya podido verificar.

#### 3.3.1 Lo que dicen las fuentes

| Fuente | Responsabilidades que asigna | Peso |
|---|---|---|
| B14, Latent Space, 30-jun-2023 (la firma de la página es «Latent Space»; la atribución a swyx sale de los enlaces del sitio, §9) | «product-specific data and evals» son su trabajo; los MLE/MLR se ocupan de lo propio del modelo fundacional. «the API line is permeable» | Ensayo influyente (que haya acuñado el uso del término: **no verificado**). No es revisado por pares |
| B15, B16, Chip Huyen, *AI Engineering: Building Applications with Foundation Models*, O'Reilly, 2025 | Adaptar modelos fundacionales: evaluación (caps. 3–4), prompts, RAG y agentes (5–6), ajuste fino y datasets (7–8), inferencia (9), arquitectura y realimentación (10). Primera pregunta del libro: «Should I build this AI application?» | Libro técnico de editorial reconocida. Sólo se leyeron el README y los resúmenes de capítulos del repo de la autora |
| B17, Microsoft Learn, *Azure AI Apps and Agents Developer Associate* (AI-103; act. 2026-08-11) | «Planning and managing Azure AI solutions», «Implementing generative AI and agentic solutions», más visión, texto y extracción. Colabora con «business stakeholders, solution architects, data scientists, DevOps engineers, and cloud security engineers» | Descripción institucional de rol. **Exige Python**: la anterior, AI-102 (B18), que admitía C#, figura «retired» |
| B05 Apéndice A (NIST) | No define «AI Engineer». Reparte tareas por fase: *AI Design*, *AI Development*, *AI Deployment* (que incluye explícitamente a «system integrators, software developers»), *Operation and Monitoring* y TEVV | Marco institucional. Útil porque define **actores por tareas**, como N0 |

**Hallazgo para la guía (E4)**: la certificación de Microsoft que hoy nombra el rol «AI Engineer» pide experiencia en **Python** y Foundry (B17). La que admitía C# está retirada (B18). Una guía .NET no puede apoyarse en esa certificación como definición del perfil ni prometer alineación con ella.

#### 3.3.2 Cómo encaja en el marco N0

Hay dos alternativas, las dos con algún respaldo:

| Opción | A favor | En contra |
|---|---|---|
| **A. Actor propio ACT-AIE** | Lo pide el lector que «no tiene el perfil». B14 y B17 lo tratan como rol diferenciado | N0 define actores **por decisiones** (BIT-16-03 §3). Las del «AI Engineer» de B14, B16 y B17 (implementar, describir herramientas, probar, evaluar, integrar) ya están repartidas entre ACT-DEV (implementa, prueba), ACT-ARQ (qué estrategia y qué marco) y ACT-OPS (operación). Un actor nuevo duplica filas en las matrices §4.3 |
| **B. Faceta de ACT-DEV** (recomendada) | B05 ubica a los «software developers» y «system integrators» como actores de *AI Deployment*: el desarrollador que integra IA **es** ese actor. B16 lo describe como evolución de la ingeniería sobre modelos ya hechos, no como una disciplina de entrenamiento. Mantiene N0 estable | Hay que nombrar explícitamente las responsabilidades nuevas para que el lector las vea |

**Propuesta [criterio propio, sobre B05, B14, B16, B17]**: opción B. En BIT-16-03 §3, ACT-DEV pasa a llamarse «Desarrollador .NET que integra IA (el rol que el mercado llama *AI Engineer*)» y suma tres responsabilidades a **Decide**: (1) diseñar y mantener el **conjunto de evaluación** del escenario (§3.2.2; B14 «product-specific data and evals»); (2) instrumentar la **realimentación** (§3.2.4; B16 cap. 10); (3) documentar las **decisiones de la capa** en el registro (§3.4). En **No decide** se agrega «el umbral de éxito del escenario» (lo fija ACT-ARQ con negocio).

**Ajuste derivado**: hoy ningún actor de N0 decide **el criterio de éxito** de un escenario. B05 (MAP 1.4, *AI Design* con «product managers») y B04 (A3.3) lo ponen antes de construir. Se propone sumarlo a ACT-ARQ: «decide, con el responsable de negocio, la métrica, los tipos de error y el umbral que habilitan un escenario». **No** se propone un actor «producto», para respetar el criterio de BIT-16-03 de no multiplicar actores sin decisiones propias **dentro de la guía**. Si el jurado prefiere un ACT-PROD, B05 lo respalda.

#### 3.3.3 Lo que la guía no debe hacer con el perfil

- No usar cifras de mercado ni de demanda laboral. Las de B14 son de 2023 y de un ensayo.
- No nombrar cursos ni certificaciones como objetivo del lector (B17 es Python y Foundry).
- No definir el rol por las herramientas, que cambian. B16 dice lo mismo: «focuses on the fundamentals … instead of any specific tool or API».

#### 3.3.4 Objetivos de aprendizaje por actor (PR-14)

**[criterio propio, declarado]**. Se redactan como desempeños observables («al terminar, el lector puede…»), y cada uno se traza a una sección prevista de la guía (BIT-16-02 §7) y a su fuente en los núcleos. ACT-USR no es lector (BIT-16-03 §3), así que no lleva objetivos.

| Actor | Al terminar, el lector puede… | § prevista | Respaldo |
|---|---|---|---|
| **Todos** | OA-0.1 Decidir si un escenario necesita IA, con las cuatro preguntas de §3.1.1 | §1/§3 | B02, B03, N1 P1 |
| | OA-0.2 Ubicar cualquier pieza de la imagen de entrada en Domain / Application / Infrastructure | §3 | N1 §4.7, N6 §1.3 |
| **ACT-DEV (integra IA)** | OA-D1 Consumir un modelo con `IChatClient` y cambiar de proveedor tocando sólo la raíz de composición | §4 | N2 P1, P3 |
| | OA-D2 Obtener salida tipada con `GetResponseAsync<T>` y manejar la respuesta inválida (`TryGetResult`) antes de pasarla a las reglas del dominio | §4, §8 | N5 P5, N6 P4 |
| | OA-D3 Exponer un caso de uso como herramienta sin saltear sus reglas, con aprobación para lo destructivo | §6 | N4 P9, N6 P5–P6 |
| | OA-D4 Armar un RAG con citas y medir la recuperación con un conjunto de oro (recall@k, MRR), con consultas no respondibles incluidas | §5 | N3 P5, B09 |
| | OA-D5 Escribir pruebas deterministas con un `IChatClient` falso y separarlas de las corridas contra el modelo | §7 | N5 P4, N6 Q6 |
| | OA-D6 Elegir entre tool calling, agente y workflow para un caso dado, y justificarlo | §6 | N4 P1–P3, B03 |
| **ACT-ARQ** | OA-A1 Registrar las decisiones de la capa como ADR con alternativas y consecuencias (§3.4) | §3 | B19, B20 |
| | OA-A2 Fijar para cada escenario la métrica de éxito, los tipos de error y el umbral para seguir | §2/§3 | B04 A3, B05 MAP 1.4/MANAGE 1.1 |
| | OA-A3 Elegir la estrategia de conocimiento (herramienta, contexto completo, RAG) y el almacén vectorial según datos y contexto | §5 | N3 P1–P2, N6 P2–P3 |
| | OA-A4 Decidir el marco (MEAI, MAF, SK como migración) y no confundir LangGraph ni Microsoft Graph con lo disponible en .NET | §6 | N4 P4–P7, I-01 (evidencia E-PO-1..6) |
| **ACT-OPS** | OA-O1 Instrumentar la capa con OpenTelemetry y saber qué cambia al activar `EnableSensitiveData` | §7 | N5 P1–P3 |
| | OA-O2 Configurar endpoint, modelo y secretos por ambiente, sin direcciones ni claves versionadas | §7 | N5 P11, N2 crit. 2 |
| | OA-O3 Leer la evaluación con LLM juez como tendencia, con caché, y conocer sus sesgos | §7 | N5 F08, B13 |
| | OA-O4 Elegir entre modelo local y en la nube por concurrencia, datos y costo | §7 | N5 P9–P10 |
| **ACT-SEC** | OA-S1 Mapear los riesgos OWASP (LLM01, LLM06, LLM08) de cada escenario a su control mínimo | §7 | N5 §2.7–2.8, N3 F27 |
| | OA-S2 Decidir qué herramientas requieren aprobación humana y qué datos pueden llegar a qué modelo | §6, §7 | N6 P6, P9, T5 |
| | OA-S3 Exigir que el filtro por permiso se aplique en la recuperación y no después | §5 | N3 C5, B09 |

Son 19 objetivos: dos comunes y 17 por actor (6 + 4 + 4 + 3; decía 20 y 18). **Formato sugerido en la guía**: una tabla al abrir la §0, con la columna «§» como ruta de lectura por rol. Así le responde al lector que «no tiene el perfil» qué gana y en qué orden.

### 3.4 (d) Borrador del registro de decisiones de arquitectura

**Formato**: ADR ligero con contexto, alternativas, criterio, decisión, consecuencias y fuente. Toma de Nygard (B19) las consecuencias «not just the "positive" ones», y de Microsoft (B20) las alternativas descartadas, el registro de sólo agregado y el nivel de confianza. Todas las alternativas tienen fuente en los núcleos. Las que **no** la tienen se listan aparte (§3.4.11) y no se inventan.

#### D-01 · Dónde vive la llamada al modelo

- **Contexto**: la imagen de entrada pone la «AI Layer» entre Business Logic y Database. El caso base usa Domain/Application/Infrastructure en carpetas de un solo ensamblado (N1 §2.14, F21).
- **Alternativas**: (a) componente Blazor o controller que llama al SDK; (b) servicio de Application que inyecta `IChatClient`; (c) puerto de aplicación en `Application/Abstractions` con un adaptador en `Infrastructure/AI` que usa `IChatClient`.
- **Criterio**: regla de dependencia («strictly through interfaces defined in Application Core», N1 F12), poder probar sin modelo, prompts fuera del dominio.
- **Decisión propuesta**: (c). La (b) se acepta en un prototipo, como deuda declarada (N1 P2).
- **Consecuencias**: más un tipo por funcionalidad. El dominio no conoce prompts. Las pruebas usan un doble del puerto. El compilador no impide violar la regla porque las capas son carpetas (N1 §2.14), así que hace falta una prueba de arquitectura o un `grep` (N6 Q1).
- **Fuente**: N1 §2.14, §4.7, P2, P3, P8; N6 §1.3. **Confianza**: alta.

#### D-02 · Contrato de acceso al modelo y adaptador del proveedor

- **Contexto**: hay SDK por proveedor y una abstracción común.
- **Alternativas**: (a) SDK del proveedor directo; (b) `IChatClient`/`IEmbeddingGenerator` con OllamaSharp; (c) `IChatClient` con el SDK de OpenAI contra el `/v1` de Ollama; (d) `Microsoft.Extensions.AI.Ollama`.
- **Criterio**: proveedor intercambiable, middleware reutilizable, paquetes vigentes.
- **Decisión propuesta**: (b) en la demo. (c) se muestra como prueba de que el contrato aguanta el cambio. (d) se descarta porque está deprecado. Para funciones exclusivas se baja con `GetService<T>()` sin abandonar el contrato.
- **Consecuencias**: el modo compatible no soporta `tool_choice`, logprobs ni Responses con estado (N2 F9). Las versiones de `Microsoft.Extensions.AI*` deben alinearse (N2 crit. 7, N6 T4).
- **Fuente**: N2 P1–P4, §6. **Confianza**: alta.

#### D-03 · Modelo local o en la nube

- **Contexto**: el caso trae datos personales (nombre, edad) y la corrida usa Qwen en un servidor Ollama de la LAN (CTX-LOCAL).
- **Alternativas**: Ollama local o de LAN, Foundry Local (un usuario por dispositivo), servicio gestionado en la nube.
- **Criterio**: salida de datos (CTX-SENS), concurrencia (`OLLAMA_NUM_PARALLEL` = 1 por defecto), costo por token, capacidad.
- **Decisión propuesta**: local por defecto. La elección se hace en la raíz de composición y se puede revisar sin tocar los casos de uso.
- **Consecuencias**: con un servidor local hay que medir y ajustar la concurrencia. Pasar a la nube cambia poco el código y mucho el análisis de datos (N6 P9).
- **Fuente**: N5 §2.11, P9; N6 T5, P9; DC-06. **Confianza**: alta en el criterio. La calidad de Qwen para tool calling todavía no se midió (N6 §8.1).

#### D-04 · Estrategia de conocimiento: herramienta, contexto completo o RAG

- **Contexto**: hay datos tabulares (localidades, encuesta) y un corpus chico de texto (12 enunciados de `*Policy`).
- **Alternativas**: (a) herramienta sobre el caso de uso; (b) todo el texto en el prompt; (c) RAG; (d) CAG, todavía **no investigado** (dossier aparte por PR-8).
- **Criterio**: ¿la pregunta tiene una respuesta exacta que calcula una consulta? → (a). ¿El corpus cabe holgado en el contexto? → (b). ¿Es texto propio que no entra o cambia seguido? → (c).
- **Decisión propuesta**: (a) para C1, (c) sólo como ejercicio didáctico en C4, avisando que (b) también funciona con ese tamaño.
- **Consecuencias**: RAG agrega una superficie de datos (LLM08) y error de recuperación. El umbral corpus/ventana desde el cual conviene RAG **no se midió** (N6 §8.7).
- **Fuente**: N1 P4; N3 P1, A2; N6 P2, P3; BIT-16-02 §5. **Confianza**: alta en (a) frente a (c); media en el umbral.

#### D-05 · Almacén vectorial: base existente o dedicada

- **Contexto**: la imagen pone «Vector DB» en la AI Layer y en Database. El caso base usa SQLite, que en EF Core no tiene vectores.
- **Alternativas**: (a) vectores en la base existente con EF Core (SQL Server 2025, `VectorDistance`); (b) motor dedicado vía `Microsoft.Extensions.VectorData` (Qdrant, PgVector…); (c) `InMemory` reconstruido al arrancar; (d) `SqliteVec` sobre el mismo archivo.
- **Criterio**: volumen, ANN maduro, búsqueda híbrida nativa, estado GA o preview, convivencia de dependencias.
- **Decisión propuesta**: (c) en la demo, que es GA. (d) queda como variante marcada preview, por el conflicto de SQLitePCLRaw (N6 T3). (a) se explica como la opción natural cuando la base ya soporta vectores.
- **Consecuencias**: InMemory no sirve para pruebas de integración (N3 A5). Hay que reindexar si cambia el modelo de embeddings (N3 C1, A4). El servidor de la LAN no hace embeddings (N3 §0.4).
- **Fuente**: N3 §0, P2, §6; N6 T3, Anexo A (b). **Confianza**: alta.

#### D-06 · Herramientas: sobre casos de uso, con aprobación, con alcance por petición

- **Contexto**: ESC-04 deja que el modelo elija acciones. El caso base tiene un controller que saltea el servicio.
- **Alternativas**: (a) herramienta sobre el repositorio o el `DbContext`; (b) herramienta sobre el servicio de Application; (c) herramienta genérica de SQL. Para las escrituras: con o sin `ApprovalRequiredAIFunction`.
- **Criterio**: no saltear reglas, privilegio mínimo (OWASP LLM06), aislamiento por sesión.
- **Decisión propuesta**: (b). Aprobación para la baja; las lecturas sin aprobación; por MCP sólo lecturas. El `SessionId` lo pone el código. Las herramientas se arman **por petición** desde el scope, porque `AddChatClient` registra singleton por defecto (N6 T1).
- **Consecuencias**: si falta un caso de uso, se agrega (p. ej. `ResultadosDeEncuestaService`), no se toma un atajo. Qué `IServiceProvider` recibe `AIFunctionArguments.Services` con un cliente singleton sigue **sin verificar** (N6 §8.3).
- **Fuente**: N4 P9, §6; N6 P5, P6, P8, T1, T7; N1 §6.2. **Confianza**: alta, salvo el detalle de T1.

> **2026-10-28 — Parche P-12 (ciclo 1).** D-06 suma este contenido obligatorio. No hay un D-11 propio (MI-23).
> - **El cliente del proveedor** (`OllamaApiClient` o `OpenAIClient`) es Singleton, se registra con clave y usa un `HttpClient` de `IHttpClientFactory` con el timeout de `OpcionesDeIA` (P-11). Registrarlo Scoped crea un `HttpClient` por petición o por circuito (SENIOR-02).
> - **El pipeline externo** (`UseFunctionInvocation` con las herramientas que leen `SessionContext`) es Scoped, o las herramientas se crean por petición.
> - **Development y Production se comportan distinto.** Con `ValidateScopes = true` (Development), resolver un Scoped desde un Singleton falla al arrancar. Con `ValidateScopes = false` (Production por defecto), no falla: el Singleton toma el `SessionContext` raíz, que está vacío, y **pierde la sesión sin error** (O4, X1 [B]). El cruce de datos entre sesiones **no está probado**: es PC-11, que va a AH-01.
> - **El pendiente P-10 de BIT-16-04 deja de ser opcional.** La prueba de cableado corre con `ValidateScopes = true` y con `false`. En los dos casos, una herramienta llamada en la sesión A ve el `SessionId` de A.

> **2026-10-28 — Parche P2-05 (ciclo 1, ronda 2).** Corrige P-12 en dos frases y en el título, y re-registra MI-23 (C1-46 y C1-71 = A): el ciclo de vida del cliente queda **dentro de D-06**, sin ADR propio.
> **Título del contenido de D-06:** «Singleton fuera de Development: todas las conversaciones comparten un único espacio y pueden leer y borrar lo que otra escribió, sin error».
> **Frase 1 de P-12, corregida.** Donde dice «con `ValidateScopes = false` … el Singleton toma el `SessionContext` raíz, que está vacío, y pierde la sesión sin error. El cruce de datos entre sesiones no está probado», se lee: «Con `ValidateScopes = false`, un pipeline Singleton toma el `SessionContext` de la raíz. El del caso base pone un `Guid` provisorio en el constructor, así que todas las conversaciones comparten ese espacio. En la sonda D2 de AH-01, con dos sesiones concurrentes, la sesión B vio la localidad que creó A y la borró, sin error. Como en el caso base la autorización es el filtro por `SessionId` del repositorio, el cruce es de datos y de autorización» (AH-01, PC-11, `evidencia-AH-01-seguridad/D-salida.txt`, E1).
> **Frase 2 de P-12, corregida.** Donde dice «con `ValidateScopes = true` (Development), resolver un Scoped desde un Singleton falla al arrancar», se lee: «con `ValidateScopes = true` y sin `ValidateOnBuild`, como en la sonda, falla **en cada llamada a la herramienta**, con `InvalidOperationException`, no al construir el contenedor. `ValidateOnBuild` no se probó» (**condición vinculante del juez de riesgo (a)**: la frase se acota a lo medido).
> **Lo que aísla:** el pipeline Scoped, o las herramientas creadas por petición con un pipeline Singleton (D2, aislado en los dos casos, también con concurrencia). Lo mismo vale para los dos transportes: el bucle (`IChatClient` o `ChatClientAgent`) y el servidor MCP resuelven el `SessionContext` de su propio scope (Senior .NET, PC-09, `evidencia-senior-dotnet/R2-mcp-salida.txt`).
> **P-10, forma (a)–(c):** la prueba de `Cableado/` (a) usa la clase real `Infrastructure/Sessions/SessionContext.cs` copiada, no un doble; (b) corre dos sesiones concurrentes con barrera, con `ValidateScopes` en `true` y en `false`, y con el pipeline Singleton y Scoped; (c) afirma que no hay cruce: con Scoped, B no ve ni borra lo de A (`borradas 0`), y con Singleton y `false` la prueba debe fallar, como caso rojo que demuestra que la prueba detecta. La sonda D2 es la base.
> **Condición de redacción (juez de evidencia):** «fuera de Development» se apoya en el valor por defecto de `ValidateScopes` según el entorno, que la sonda no midió (lo fijó a mano). La guía cita la documentación oficial de ASP.NET Core con URL, versión y fecha de consulta, o escribe el título en términos de `ValidateScopes = false`.
> **Ajuste vinculante incorporado (juez de evidencia):** la condición de cita se cumple así. La guía cita https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection/overview §«Scope validation» (ms.date 2026-01-26, consultada el 2026-10-28) para «en Development el proveedor valida los scopes». Si afirma ese valor por defecto para `WebApplication.CreateBuilder`, cita además «ASP.NET Core Web Host: Scope validation» con su ms.date, o lo dice en términos de `ValidateScopes = false`. «Fuera de Development no valida» se escribe como consecuencia de esa cita, no como hecho medido. Si la redacción no tiene la cita a mano, toma el título en términos de `ValidateScopes = false` (juez de costo-beneficio).



#### D-07 · Nivel de orquestación

- **Contexto**: hay varias formas de agregar autonomía.
- **Alternativas**: llamada única → `IChatClient` con `UseFunctionInvocation` → agente de MAF (`AsAIAgent`) → workflow de MAF (con checkpoints o `RequestPort`) → orquestación multiagente. SK sólo como migración; AutoGen no (archivado).
- **Criterio**: ¿se puede escribir la función? ¿Los pasos se conocen de antemano? ¿Hace falta sesión, aprobación integrada o pausa larga?
- **Decisión propuesta**: C1 y C2 con `IChatClient` y herramientas; C5 con un agente MAF con aprobación; la encuesta de tres pasos se queda como código y funciona como **contraejemplo** de workflow (C8).
- **Consecuencias**: cada escalón suma latencia, costo y puntos de falla. Hay que cortar el bucle (`MaximumIterationsPerRequest`).
- **Fuente**: N4 P1–P3, P6, P7, §6.1; N4 F21 = B03; N6 P7, C8. **Confianza**: alta.

> **2026-10-28 — Parche P2-14 (ciclo 1, ronda 2).** El «nivel de orquestación» es el escalón elegido entre: llamada única, **agente mínimo** (`IChatClient` con `UseFunctionInvocation`), **agente de MAF**, workflow de MAF y orquestación multiagente. La decisión de D-07 no cambia: sólo se renombran las alternativas. MCP no es un nivel de orquestación sino el transporte de herramientas entre procesos (`McpClientTool` hereda de `AIFunction`). CASO-8 (la encuesta) es código, un proceso sin modelo, y sirve de contraejemplo de «workflow de MAF».


#### D-08 · Quién decide: la salida del modelo es una propuesta

- **Contexto**: la salida estructurada garantiza la forma, no la validez. Las reglas del caso sólo exigen «no vacío» en varios campos (H1–H5).
- **Alternativas**: (a) confiar en `GetResponseAsync<T>`; (b) poner las reglas en el system prompt; (c) el modelo propone → el adaptador normaliza contra `Catalogos` → el caso de uso valida y decide.
- **Criterio**: las reglas se hacen cumplir en código (OWASP LLM01); robustez ante JSON inválido.
- **Decisión propuesta**: (c), consumiendo con `TryGetResult`.
- **Consecuencias**: un normalizador por campo de catálogo. Los errores por campo vuelven al modelo o a la persona (B01 G9).
- **Fuente**: N1 P9, §6.2; N5 P5; N6 P4, T2, Q3. **Confianza**: alta.

#### D-09 · Pipeline transversal del cliente: telemetría, caché y límites

- **Contexto**: `ChatClientBuilder` encadena middleware, y el orden importa.
- **Alternativas**: con o sin `UseOpenTelemetry`/`UseLogging`, caché distribuida, rate limiting; caché por fuera o por dentro de la telemetría; `EnableSensitiveData` fijo o por entorno.
- **Criterio**: observabilidad desde el día uno, sin datos personales en las trazas (LLM02), costo.
- **Decisión propuesta**: telemetría y logging siempre; `EnableSensitiveData` sólo en desarrollo; caché sólo donde hay pedidos idénticos; límite de concurrencia frente al servidor de modelos.
- **Consecuencias**: con la caché más afuera que la telemetría, los aciertos no se ven (N5 E2). Las convenciones `gen_ai.*` están en Development y cambian: los dashboards se versionan (N5 P3).
- **Fuente**: N2 P6, crit. 3; N5 P1–P3, P8, §6. **Confianza**: alta.

#### D-10 · Estrategia de pruebas y evaluación

- **Contexto**: las salidas no son deterministas.
- **Alternativas**: (a) sólo pruebas contra el modelo real; (b) sólo `IChatClient` falso; (c) suite determinista con cliente falso en cada build, más corridas contra el modelo y evaluación con LLM juez, leídas como tendencia.
- **Criterio**: reproducibilidad en CI, medir la respuesta y no sólo el código.
- **Decisión propuesta**: (c), con conjunto de oro y consultas no respondibles para RAG (§3.2.2).
- **Consecuencias**: dos suites (`Cableado/`, `ConModelo/` en N6 Anexo A). El juez tiene sesgos (B13) y Safety requiere Azure (N5 P6). La calidad de Qwen como juez está **sin verificar** (N5 §8.4).
- **Fuente**: N5 P4–P6, §6; N6 Q6; N3 P5; B09; B13. **Confianza**: alta en la estructura y media en el juez local.

#### 3.4.11 Decisiones pedidas en PR-13 sin respaldo en los núcleos

| Decisión pedida | Estado | Qué haría falta |
|---|---|---|
| **Sincrónico o en segundo plano** (cola, `BackgroundService`, respuestas en segundo plano) | **Sin fuente en N1 a N6.** Sólo consta que `ChatOptions` tiene `AllowBackgroundResponses` y `ContinuationToken` (N2 §2.5, reflexión), sin semántica estudiada. El harness de MAF tiene «agentes en segundo plano» como experimentales en Python (N4 §8.9) | Investigar antes de redactar o dejarla fuera del registro. **No se inventan alternativas** |
| Ciclo de vida del cliente en DI (singleton o scoped) como decisión aparte | Parcial: está la tensión N6 T1, pero sin verificar en ejecución | Ejecutar la sonda de T1. Mientras tanto queda dentro de D-06 |
| CAG frente a RAG | Pendiente del dossier de PR-8 | Se suma a D-04 cuando exista |

**Cómo ilustrarlas con la demo [criterio propio]**: cada ADR remite a su lugar en `Demos/MovilidadUrbana.Asistente/`: D-01 a `Application/Abstractions` + `Infrastructure/AI`, D-06 a `Mcp/` y a las herramientas, D-10 a `tests/Cableado` y `tests/ConModelo` (N6 Anexo A). Esto responde al pedido de que la demo **muestre** las capas.

> **2026-10-28 — Parche P-13 (ciclo 1).** **D-11 (en 03-Parches, «D-07 bis»), estado de la conversación.** El puerto `IAsistenteDeMovilidad` (string → string, `PuertosDeIA.cs` l. 15) no transporta sesión, historial, aprobación ni streaming. Decisión: el estado de la conversación vive en Infrastructure, en un almacén con clave `SessionId + ConversacionId` y vencimiento, por defecto 30 minutos (elegido). El puerto pasa a recibir `(SessionId, ConversacionId, texto, CancellationToken)` y a devolver `IAsyncEnumerable<EventoDelAsistente>`. Los tipos de `EventoDelAsistente` son de Application: `TextoParcial`, `EtapaIniciada(nombre)` (P-40) y `Final`. No se filtran tipos de MEAI al núcleo (MI-06). Alternativas descartadas: estado en el cliente, porque el historial viaja y se puede alterar; estado sin vencimiento, porque crece sin techo.
> **Ajustes de la aplicación:** (1) numeración: el ADR es **D-11** y no «D-07 bis», porque P-31 conserva el esquema `D-nn` y D-07 es el nivel de orquestación (juez de coherencia histórica; ajuste editorial). El ciclo de vida del cliente sigue sin ADR propio: va dentro de D-06 (Parche P-12, MI-23). (2) **Contrato de aprobación (rama A) y `AccionPropuesta` (rama B):** diseñados en 03-Parches P-13; se aplican cuando la segunda ronda de C1-40/C1-62 (Parche P-35) quede registrada con mayoría ≥ 3. La rama A no se implementa sin PC-12 respondida como E3 y, mientras el `SessionId` no esté autenticado, la guía declara que el 404 por sesión distinta no es control de acceso (condición del juez de riesgo).

> **2026-10-28 — Parche P2-03 (ciclo 1, ronda 2).** Con C1-14 = B, `EventoDelAsistente` suma `AccionPropuesta(tipo, datos)` y no suma `AprobacionPendiente`. No hay `POST /api/v1/asistente/aprobaciones/{id}` en la demo: ese contrato vive en `Examples/07`. El almacén de D-11 guarda el historial, que es dato de la persona (la sesión serializada guarda los argumentos y el texto de la persona: AH-01, D1g). Por eso lleva el vencimiento de D-11 (30 min, elegido) y **no va a los registros**: ni el historial ni los argumentos se escriben en logs ni en atributos de telemetría fuera de Development (M8, P2-06).



---

## 4. Preguntas guía con respuesta explicativa

**PG-1. Mi jefe quiere «ponerle IA» a la app. ¿Por dónde empiezo?**
Por el problema, no por el modelo. PAIR lo dice literal: «It's important to question whether adding AI to your product will improve it», y avisa que una regla suele andar igual o mejor (B02). Si la tarea pide predictibilidad, da información estática o tiene errores caros, la IA probablemente no es mejor (B02). Si la tarea tiene una especificación determinista, código (N1 P1). Si pasa el filtro, se define el éxito **antes** de construir: métrica, tipos de error y umbral (B04 A3.3), con el costo del error documentado (B05 MAP 3.2). Sin esa definición no hay forma de decidir después si seguir (B05 MANAGE 1.1).

**PG-2. ¿Cómo diseño una pantalla para una respuesta que puede estar mal?**
Asumiendo que a veces va a estar mal. B01 dedica cinco pautas al momento «When wrong» (G7–G11): invocar y descartar fácil, corregir fácil (G9), acotar ante la duda (G10) y explicar por qué (G11). En la capa de IA eso se traduce en: la salida es una propuesta que la persona confirma o corrige (D-08); si la salida no es válida, se cae al camino sin IA (`TryGetResult` → `null`, N1 §4.7); en RAG se muestra la cita (N3 C7). Y antes de todo eso, avisar qué puede hacer el sistema y qué tan bien (G1, G2). Ojo: mostrar la cita no prueba que la respuesta sea correcta, porque Qwen citó una regla y la contradijo (N3 E5).

**PG-3. ¿«Datos para la IA» significa vectorizar toda la base?**
No. Los datos tabulares se consultan con herramientas sobre los casos de uso, porque RAG trae lo parecido y no cuenta (N3 P1, N6 P2). Preparar datos para la IA es, en cambio, (1) cuidar la calidad del **texto** que va a RAG («Language models … don't produce good results if you provide them with poor-quality content», B09), con sus permisos y sin datos personales; (2) armar el **conjunto de evaluación**; (3) cerrar el circuito de **realimentación**. Entrenar o ajustar modelos queda fuera del alcance de esta guía.

**PG-4. ¿Cómo armo un conjunto de evaluación si no tengo usuarios reales todavía?**
Con tres columnas, pregunta, contexto esperado y respuesta esperada (B09), a partir de los documentos reales. Se pueden generar preguntas sintéticas con un LLM a partir de cada fragmento, pero un experto las revisa siempre («A SME should review and validate the output», B09). Hay que agregar preguntas que los documentos **no** responden, para verificar el «no sé» (B09). Primero se mide la recuperación sola (recall@k, MRR, N3 P5), después la respuesta (fidelidad, relevancia: B10, B11; en .NET, `GroundednessEvaluator` y `RelevanceEvaluator`, N5 F07). El conjunto se revisa cuando cambian las fuentes (B09). En la demo, que genera el corpus desde las `*Policy`, eso significa versionarlo con el código.

**PG-5. ¿Puedo usar un LLM para evaluar a otro LLM?**
Sí, con cuidado. Los jueces fuertes llegan a más del 80 % de acuerdo con preferencias humanas, pero tienen sesgos de posición, verbosidad y autofavorecimiento (B13). Por eso la documentación de .NET sugiere seguir tendencias y no hacer fallar el build por un puntaje (N5 F08), y B16 pide complementar con evaluación exacta o humana. En el laboratorio, además, la calidad de Qwen como juez está sin medir (N5 §8.4): primero se calibra con un puñado de casos anotados a mano. Es la idea de ARES, que usa unos cientos de anotaciones humanas para corregir al juez (B11).

**PG-6. ¿Qué es un «AI Engineer»? ¿Lo tengo que contratar o lo tengo que ser?**
En esta guía es el **desarrollador .NET que integra IA**, definido por lo que decide: implementa los escenarios con las abstracciones elegidas, y además diseña el conjunto de evaluación, instrumenta la realimentación y registra las decisiones de la capa (§3.3.2). Las fuentes lo describen como alguien que construye sobre modelos ya entrenados (B16) y que se hace cargo de «product-specific data and evals» (B14). No es un investigador de modelos. Lo que cambia frente al desarrollo clásico es que el resultado no es determinista, así que evaluar pasa a ser parte del trabajo diario (B16, caps. 3–4). Cuidado con las certificaciones: la de Microsoft que hoy nombra el rol pide Python (B17).

**PG-7. ¿Para qué escribir un ADR si el código ya muestra la decisión?**
Porque el código muestra lo elegido, no lo descartado ni por qué. Nygard pide registrar todas las consecuencias, también las negativas (B19). Microsoft agrega las alternativas descartadas, el nivel de confianza y que el registro sea de sólo agregado: si la decisión cambia, se escribe otra que la reemplaza (B20). En una capa de IA esto pesa más, porque varias decisiones dependen de piezas volátiles (paquetes en preview, versiones semanales de MAF, N4 §6.1; convenciones `gen_ai.*` en Development, N5 P3). Cuando cambien, el ADR dice qué revisar.

> **2026-10-28 — Parche P-38 (ciclo 1).** PG-5: la demo no trae juez; método enseñado, acuerdo k/n con intervalo y nunca como compuerta (N5 §4.6).


---

## 5. Criterios de calidad y antipatrones

### 5.1 Criterios

| # | Criterio | Fuente |
|---|---|---|
| Q-P1 | Cada escenario de la guía declara qué problema resuelve y por qué una regla no alcanza | B02, N1 P1 |
| Q-P2 | Cada escenario de la demo tiene métrica, error caro y umbral, escritos antes del código | B04 A3.3, B05 MAP 3.1–3.2 |
| Q-P3 | La interfaz declara capacidades y límites, permite corregir y degrada ante la duda | B01 G1, G2, G9, G10 |
| Q-D1 | El conjunto de evaluación tiene pregunta, contexto y respuesta esperados, e incluye consultas no respondibles | B09 |
| Q-D2 | La recuperación se mide aparte de la respuesta | N3 C6, B08, B10, B11 |
| Q-D3 | Las preguntas sintéticas pasan revisión humana | B09 |
| Q-D4 | El contenido fuente conserva permisos y no lleva datos personales | B09, N3 C5, CTX-SENS |
| Q-R1 | Los actores se definen por decisiones; el «AI Engineer» es una faceta de ACT-DEV con sus tres responsabilidades nombradas | BIT-16-03 §3, B05 Ap. A |
| Q-R2 | Los objetivos de aprendizaje son observables y cada uno remite a una sección | §3.3.4 [criterio propio] |
| Q-A1 | Cada ADR lista alternativas con fuente, consecuencias negativas y confianza; las decisiones sin fuente se declaran | B19, B20 |

### 5.2 Antipatrones

| Antipatrón | Por qué falla | Fuente |
|---|---|---|
| «Ponerle IA» sin problema definido | No hay forma de decidir si funcionó | B02, B05 MANAGE 1.1 |
| Medir la calidad del modelo y no la del escenario | Un modelo «mejor» puede no mover la métrica que importa | B04 A3, B03 («demonstrably improves outcomes») |
| Conjunto de evaluación sólo con preguntas respondibles | Nunca se prueba el «no sé» y aparecen confabulaciones | B09, B07 |
| Preguntas sintéticas sin revisión | Evalúa el sistema con un examen que nadie verificó | B09 |
| Juez LLM como compuerta dura del build | Sesgos e inestabilidad | B13, N5 F08 |
| «Datos para la IA» = vectorizar tablas | Recupera lo parecido, no lo exacto | N3 A2, N6 P2 |
| Definir el perfil por herramientas o certificaciones | Caduca, y la certificación vigente no es .NET | B16, B17, B18 |
| ADR que sólo lista ventajas, o alternativas inventadas | No sirve para revisar la decisión; viola R-EVID | B19, B20, BIT-16-00 R-EVID |

---

## 6. Recomendación para el jurado

| Propuesta | Recomendación | Dónde en la guía | Qué queda fuera y por qué |
|---|---|---|---|
| **PR-9** Mirada de producto | **APLICAR, versión corta.** Subsección «¿Vale la pena? Valor, error y éxito» con las cuatro preguntas de §3.1.1, la definición de éxito de §3.1.3 y la tabla de pautas B01 aplicables (7 de 18, en 6 filas) | §2 (marco de referencia, al definir escenarios) o al abrir §3; la tabla B01 completa en un anexo para ACT-ARQ | Fuera: gobierno de IA responsable completo (evaluaciones de impacto, Standard entero), diseño UX detallado. **Motivo**: la guía es técnica de integración; esas fuentes se citan como lectura ampliada |
| **PR-10** Datos para la IA | **APLICAR como subsección**, no como sección: «Preparar contenido, evaluar y realimentar», dentro de §5 (RAG) para preparación y conjunto de oro, y de §7 (operar y evaluar) para realimentación. En la demo: sumar respuesta esperada y consultas no respondibles al conjunto de oro de C4 | §5 y §7 | Fuera: ingeniería de datasets para entrenamiento o ajuste fino, etiquetado. **Motivo**: la guía no entrena modelos (B16 cap. 8 lo trata para entrenar) |
| **PR-1** Actor «AI Engineer» | **APLICAR con la opción B**: faceta de ACT-DEV con tres responsabilidades nuevas, más el criterio de éxito en ACT-ARQ (§3.3.2). Alternativa votable: ACT-PROD con respaldo B05 | §2 (tabla de actores) | Fuera: cifras de mercado, certificaciones. **Motivo**: sin fuente de peso y, en el caso de la certificación, no .NET |
| **PR-14** Objetivos de aprendizaje | **APLICAR** la tabla de §3.3.4 (19 objetivos), como ruta de lectura por rol | §0 | Ninguna exclusión. Es criterio propio declarado y revisable por didáctica |
| **PR-13** Registro de decisiones | **APLICAR** D-01 a D-10 como sección propia («Decisiones de arquitectura de la capa de IA») o como cierre de §3, cada una con remisión a la demo | §3 (o §3 bis), con remisiones desde §4–§8 | Fuera hasta tener fuente: **sincrónico o en segundo plano**. Pendientes: CAG en D-04 (PR-8) y el detalle de T1 en D-06 |
| PR-15 (relacionada) | Las cuatro preocupaciones se cubren así: arquitectura → D-01..D-10; datos y recuperación → §5 + §3.2; evaluación → §7 + D-10; perfil → §0 + §2 | — | — |

**Severidad si no se aplica [criterio propio]**: PR-13 y PR-10 son S2, porque sin ellas la guía da código sin el criterio que pide el Profile ni el método para saber si funciona. PR-9, PR-1 y PR-14 son S3: mejoran la orientación, pero la guía no queda incorrecta sin ellas.

---

## 7. Tabla de fuentes

Fecha de consulta de todas: **2026-10-26**.

| Id | Fuente | URL / identificador | Qué respalda |
|---|---|---|---|
| B01 | Amershi, Weld, Vorvoreanu, Fourney, Nushi, Collisson, Suh, Iqbal, Bennett, Inkpen, Teevan, Kikin-Gil, Horvitz. «Guidelines for Human-AI Interaction». CHI 2019 (publicado 2019-05-02) | DOI `10.1145/3290605.3300233`; PDF https://www.microsoft.com/en-us/research/wp-content/uploads/2019/01/Guidelines-for-Human-AI-Interaction-camera-ready.pdf; HAX: https://www.microsoft.com/en-us/haxtoolkit/ai-guidelines/ | 18 pautas, cuatro momentos, validación con 49 practicantes |
| B02 | Google PAIR, *People + AI Guidebook*, capítulos *User Needs + Defining Success* y *Data Collection + Evaluation* (sin fecha visible en el capítulo) | https://pair.withgoogle.com/chapter/user-needs/ ; https://pair.withgoogle.com/chapter/data-collection/ ; índice https://pair.withgoogle.com/guidebook/chapters | Cuándo la IA aporta valor; automatizar o aumentar; función de recompensa; costo FP/FN |
| B03 | Anthropic, «Building effective agents» (2024-12-19) | https://www.anthropic.com/engineering/building-effective-agents (hoy redirige a https://www.anthropic.com/research/building-effective-agents) (= N4 F21, N1 F02) | Simplicidad; «demonstrably improves outcomes»; criterios de éxito claros |
| B04 | Microsoft, *Responsible AI Standard, v2 — General Requirements*, junio de 2022 | https://blogs.microsoft.com/wp-content/uploads/prod/sites/5/2022/06/Microsoft-Responsible-AI-Standard-v2-General-Requirements-3.pdf | Goal A3 Fit for purpose (A3.1–A3.8, p. 6), T3 Disclosure (p. 12), RS3 Ongoing monitoring, feedback and evaluation |
| B05 | NIST, *AI RMF 1.0*, NIST AI 100-1 (2023-01-26) | DOI `10.6028/NIST.AI.100-1`; https://nvlpubs.nist.gov/nistpubs/ai/NIST.AI.100-1.pdf | GOVERN/MAP/MEASURE/MANAGE; MAP 1.1, 1.4, 3.1, 3.2; MEASURE 2.3; MANAGE 1.1; Apéndice A (actores por tareas) |
| B06 | Ídem B05, Tabla 2 (MAP, pp. 26–27), Tabla 4 (MANAGE, p. 32) y Apéndice A (pp. 35–36), numeración impresa | ídem | Ubicación de las citas |
| B07 | NIST, *AI RMF: Generative AI Profile*, NIST AI 600-1 (julio de 2024) | DOI `10.6028/NIST.AI.600-1`; https://nvlpubs.nist.gov/nistpubs/ai/NIST.AI.600-1.pdf | Definición de confabulación; 12 riesgos de IA generativa |
| B08 | Microsoft, Azure Architecture Center, «Design and develop a RAG solution» (ms.date 2025-12-17; act. 2026-07-02) | https://learn.microsoft.com/en-us/azure/architecture/ai-ml/guide/rag/rag-solution-design-and-evaluation-guide | Fases de diseño y evaluación de RAG; evaluar cada paso y el resultado final |
| B09 | Microsoft, Azure Architecture Center, «RAG preparation phase» (título de la página: «Develop a RAG Solution on Azure - Preparation Phase»; ms.date 2025-10-10; act. 2026-07-02) | https://learn.microsoft.com/en-us/azure/architecture/ai-ml/guide/rag/rag-preparation-phase | Dominio, calidad del contenido, permisos, datos personales, Query/Context/Answer, consultas sintéticas con revisión, consultas no respondibles |
| B10 | Es, James, Espinosa-Anke, Schockaert. «Ragas: Automated Evaluation of Retrieval Augmented Generation» | arXiv `2309.15217` (2023-09-26); ACL Anthology `2024.eacl-demo.16` | Evaluación sin referencia en tres dimensiones |
| B11 | Saad-Falcon, Khattab, Potts, Zaharia. «ARES: An Automated Evaluation Framework for Retrieval-Augmented Generation Systems» | arXiv `2311.09476` (2023-11-16); ACL Anthology `2024.naacl-long.20` | Relevancia de contexto, fidelidad y relevancia de respuesta; jueces corregidos con pocas anotaciones |
| B12 | Yu, Gan, Zhang, Tong, Liu, Liu. «Evaluation of Retrieval-Augmented Generation: A Survey» | arXiv `2405.07437` (2024-05-13); DOI `10.1007/978-981-96-1024-2_8` (CCIS, *Big Data*, Springer, 2025) | Panorama de métricas y límites de los benchmarks |
| B13 | Zheng, Chiang, Sheng, Zhuang et al. «Judging LLM-as-a-Judge with MT-Bench and Chatbot Arena», NeurIPS 36 | arXiv `2306.05685`; Crossref `10.52202/075280-2020` | Acuerdo de jueces fuertes con preferencias humanas; sesgos |
| B14 | Latent Space, «The Rise of the AI Engineer» (2023-06-30, `datePublished` del JSON-LD de la página) | https://www.latent.space/p/ai-engineer | Formulación del rol; «product-specific data and evals» |
| B15 | Chip Huyen, *AI Engineering: Building Applications with Foundation Models*, O'Reilly Media, 2025 (ISBN-13 9781098166304 según librerías y catálogos; ver §9) | Repo de la autora: https://github.com/chiphuyen/aie-book (README) | Definición de la disciplina; público («AI engineers, ML engineers…»); preguntas del libro |
| B16 | Ídem, resúmenes de capítulos publicados por la autora | https://github.com/chiphuyen/aie-book/blob/main/chapter-summaries.md | Cap. 1 (de ML engineering a AI engineering), 3–4 (evaluación, juez), 8 (datasets), 10 (arquitectura, realimentación, «closer to product») |
| B17 | Microsoft Learn, *Microsoft Certified: Azure AI Apps and Agents Developer Associate* (examen AI-103; act. 2026-08-11) | https://learn.microsoft.com/en-us/credentials/certifications/azure-ai-apps-and-agents-developer-associate/ | Descripción institucional del rol; exige Python y Foundry |
| B18 | Microsoft Learn, *Azure AI Engineer Associate* (AI-102; «retired»; act. 2026-06-30) | https://learn.microsoft.com/en-us/credentials/certifications/azure-ai-engineer/ | Descripción anterior del rol, con C#; retirada |
| B19 | Michael Nygard, «Documenting Architecture Decisions» (2011-11-15) | https://www.cognitect.com/blog/2011/11/15/documenting-architecture-decisions | Formato ADR: contexto, decisión, estado, consecuencias |
| B20 | Microsoft, Azure Well-Architected Framework, «Maintain an architecture decision record (ADR)» (ms.date 2026-04-10) | https://learn.microsoft.com/en-us/azure/well-architected/architect-role/architecture-decision-record | Alternativas descartadas, confianza, registro de sólo agregado |
| B-NuGet | API de contenido de nuget.org | `https://api.nuget.org/v3-flatcontainer/{id}/index.json` | Estado de los paquetes de evaluación e ingesta (§8) |

Fuentes vistas y **no usadas como respaldo**: artículos de terceros sobre la sucesión AI-102 → AI-103 (dev.to, tutorialsdojo, exponenta), reemplazados por B17/B18; resumen de terceros del Standard de Microsoft (aigl.blog), reemplazado por B04.

---

## 8. Evidencia ejecutada

Intermedios en `{dir-de-trabajo}/n0b/`.

| Id | Comando | Extracto del resultado |
|---|---|---|
| B-E1 | `curl "https://export.arxiv.org/api/query?id_list={2309.15217,2311.09476,2405.07437,2306.05685}"` | Títulos, fechas y autores de la §7. Ninguno trae `journal_ref` en arXiv |
| B-E2 | `curl https://api.crossref.org/works/{10.1145/3290605.3300233, 10.6028/NIST.AI.100-1, 10.6028/NIST.AI.600-1}` | «Guidelines for Human-AI Interaction» — *Proceedings of the 2019 CHI Conference…* — 2019-05-02; «Artificial Intelligence Risk Management Framework (AI RMF 1.0)» — 2023-01-26 — Tabassi; NIST.AI.600-1 — 2024-07-26 |
| B-E3 | `curl https://api.nuget.org/v3-flatcontainer/<id>/index.json` | `microsoft.extensions.ai.evaluation`, `.quality`, `.reporting`: última **10.11.0** estable. `.nlp`, `.safety`: **10.11.0-preview.1.26513.7**, sin estable. `microsoft.extensions.dataingestion`: **10.11.0-preview.1.26513.7**, sin estable. `microsoft.extensions.ai`: 10.11.0. Coincide con N3 §0 y N5 §3.1 |
| B-E4 | `pdftotext -layout` sobre el PDF de B01 + `grep` | Tabla 1 con G1..G18; texto: «"Initially" (Guideline 1 & Guideline 2), "During interaction" (Guideline 3 - Guideline 6), "When wrong" (Guideline 7 - Guideline 11), and "Over time" (Guideline 12 - Guideline 18)» |
| B-E5 | `pdftotext` sobre B04 + `grep -n "Goal A3\|Goal T3\|Goal RS3"` | Líneas 137 (A3 Fit for purpose), 392 (T3), 868 (RS3); portada «June 2022»; 27 páginas |
| B-E6 | `pdftotext` sobre B05 y B07 + `grep "MAP 1.4\|MAP 3.1\|MANAGE 1.1\|Appendix A"` | Citas de §3.1.1 y §3.3.1 (Tabla 2 p. 26, Tabla 4, Apéndice A p. 35); B07: «2. Confabulation: The production of confidently stated but erroneous or false content…» |
| B-E7 | `curl https://raw.githubusercontent.com/chiphuyen/aie-book/main/{README.md,chapter-summaries.md}` | Diez capítulos, del 1 («Introduction to Building AI Applications with Foundation Models») al 10 («AI Engineering Architecture and User Feedback») |
| B-E8 | `curl -sL https://aclanthology.org/{2024.eacl-demo.16,2024.naacl-long.20}/` | `<title>RAGAs: Automated Evaluation of Retrieval Augmented Generation - ACL Anthology</title>`; `<title>ARES: … - ACL Anthology</title>` |
| B-E9 | `curl` de B19 y B20, extracción de texto | B19: secciones Context, Decision, Status, Consequences («not just the "positive" ones»). B20: ms.date 2026-04-10, «append-only log», «alternatives that you ruled out» |

No se compiló código. Este despacho no requería snippets nuevos, y los de D-01 a D-10 ya están compilados en sus núcleos.

---

## 9. Abierto / no verificado

1. **Autor de B14**: la firma de la página dice «Latent Space», y el texto en primera persona agradece al co-anfitrión Alessio Fanelli. La atribución a swyx (Shawn Wang) sale de los enlaces del sitio y del uso habitual, pero **no se confirmó en el texto**. La guía puede citar «Latent Space (2023)».
2. **ISBN de B15**: el repo de la autora cita `isbn = {978-1801819312}`, que según Open Library corresponde a **otro libro** (*Machine Learning with PyTorch and Scikit-Learn*, Raschka et al., Packt, 2022): es un error del repo y no se debe copiar. Open Library confirma 9781098166304 como *AI Engineering*, Chip Huyen, O'Reilly (con fecha 2024 en su ficha), y la URL de O'Reilly usa 9781098166298 (probablemente el e-book). La página de O'Reilly devolvió 403. En la guía conviene citar autor, título, editorial y año, sin ISBN, o el 9781098166304 con esa nota.
3. **Contenido completo de B15/B16**: se leyeron sólo el README y los resúmenes oficiales. Las afirmaciones del cuerpo del libro (p. ej. los siete ejes de «host vs API» del cap. 4) **no se verificaron** en el texto.
4. **Vigencia de B04**: no verifiqué si Microsoft publicó una versión posterior a la v2 del Responsible AI Standard. La v2 sigue descargable en su URL oficial.
5. **PAIR**: el capítulo no muestra fecha. Existe una ruta `guidebook-v2` (resultado de búsqueda) que no abrí; no sé si los textos citados cambiaron en esa versión.
6. **Venue de B12**: sin `journal_ref` en arXiv, pero Crossref registra la versión publicada en Springer CCIS (*Big Data*, 2025, pp. 102–120, DOI `10.1007/978-981-96-1024-2_8`, mismos seis autores). Resuelto en la verificación adversarial; el tipo de revisión de ese volumen no se verificó.
7. **Correspondencia RAGAS/ARES ↔ evaluadores de .NET**: es conceptual, **[criterio propio]**. No verifiqué si alguna página de Microsoft la declara.
8. **Decisión «sincrónico o en segundo plano»**: sin fuente en los núcleos (§3.4.11). La semántica de `AllowBackgroundResponses`/`ContinuationToken` no está estudiada.
9. **Realimentación en la demo**: el endpoint sugerido en §3.2.4 no se compiló ni se probó.
10. **Objetivos de aprendizaje y propuesta de actor**: criterio propio. Los tiene que revisar el especialista en didáctica de la mesa (DC-02).
11. **AI-103**: la página dice Python y Foundry. No abrí la guía de estudio (`aka.ms/AI103-StudyGuide`), así que no sé si el examen menciona .NET o C# en algún punto.

---

## Verificación adversarial

Verificador adversarial, 2026-10-26. Se volvieron a descargar todas las fuentes primarias, sin reusar los intermedios del investigador. Los nuevos intermedios están en `{dir-de-trabajo}/n0b-verif/`: los PDF y su `pdftotext`, el HTML de cada página con su texto extraído, `arxiv.xml` y las respuestas de Crossref, nuget.org y Open Library. Las citas literales se buscaron como cadenas exactas en el texto extraído. Las páginas son la numeración impresa del PDF. Se revisó además que no hubiera IPs privadas ni hosts de la LAN (`grep` de 10.x, 172.16–31, 192.168, 100.x, `.lan`, nombres de host): **no hay ninguno**.

| Afirmación | Veredicto | Evidencia |
|---|---|---|
| B04 Goal A3 «fit for purpose in the sense…», en p. 5 | **Corregido**: la cita es correcta, pero está en p. 6 | `pdftotext -f 6 -l 6 msrai.pdf` muestra «Goal A3» con el pie «6». Ninguna otra página tiene el encabezado |
| B04 A3 «A3.1–A3.6» | **Corregido**: llega hasta A3.8 | `msrai.txt`, líneas de A3.7 y A3.8 («Communicate with care about system benefits») |
| B04 Goal T3 en p. 9; «salvo que sea obvio» | **Corregido**: está en p. 12. El texto se confirma | Pie de la PDF p. 12. «unless it is obvious from the circumstances or context of use» |
| B04 A3.3 (problema, métricas y tipos de error con criterio de liberación), A3.4 (plan de evaluación), RS3.1 («processes by which customers can submit information about failures and concerns»), «June 2022», 27 páginas | Confirmado | `msrai.txt`; `file msrai.pdf` → 27 page(s) |
| B01: DOI, CHI 2019, 2019-05-02, autores | Confirmado | Crossref `10.1145/3290605.3300233` |
| B01: 18 pautas; 49 practicantes; 20 productos; cita de los cuatro momentos | Confirmado. La cita de los momentos está en la Fase 1 (§3) y describe la primera iteración. Los mismos grupos rotulan la Tabla 1 final | `amershi.txt`, resumen y Fase 1 |
| B01 Tabla 1: G1, G2, G9, G10 («gracefully degrade … when uncertain»), G11, G15 (texto citado en §3.2.4), G18 | Confirmado, literal | `amershi.txt`, Tabla 1 |
| B01 «la fuente revisada por pares más citada» | **No verificado**. Se atenuó en el cuerpo | No se hizo ningún conteo de citas comparativo |
| Tabla B01 «6 de 18» (§6) | **Corregido**: son 7 pautas en 6 filas | G1, G2, G9, G10, G11, G15, G18 |
| B02 PAIR: las cinco citas (cuestionar si la IA mejora; «rule or heuristic-based»; las tres condiciones de «probably not better»; FP/FN «critical decision»; «almost always … an option for human oversight») y la función de recompensa colaborativa | Confirmado, literal | `pair-un.html.txt`. Títulos de los capítulos «User Needs + Defining Success» y «Data Collection + Evaluation» |
| B02 «sin fecha»; ruta `guidebook-v2` | Se confirma que la ruta aparece en el índice. Si el texto cambió en v2: **no verificado** | `pairidx.html` |
| B03 Anthropic: las tres citas y la fecha 2024-12-19 | Confirmado. La URL `/engineering/…` hoy redirige a `/research/…` (se anotó en §7) | `anth.html`, «Dec 19, 2024»; `curl -L`, `url_effective` |
| B05 NIST AI 100-1: 2023-01-26, Tabassi; MAP 1.4, 3.1, 3.2 y MANAGE 1.1, literales | Confirmado | Crossref; `nist100.txt` |
| B06 «Tabla 2 y Tabla 4, pp. 26–27 y siguientes» | **Precisado**: Tabla 2 en pp. 26–27, Tabla 4 en p. 32, Apéndice A en pp. 35–36 | Pies «Page 26/27/32/35/36» de las PDF 31, 32, 37, 40 y 41 |
| B05 Apéndice A: *AI Deployment* con «system integrators, software developers»; *AI Design* con «product managers»; TEVV «ongoing monitoring for periodic updates…» | Confirmado | `nist100.txt` |
| B07 NIST AI 600-1: definición de confabulación (riesgo 2), 12 riesgos, julio de 2024 | Confirmado | `nist600.txt`, riesgos numerados del 1 al 12; Crossref 2024-07-26 |
| B08: ms.date 2025-12-17, act. 2026-07-02; las seis fases; la cita de cierre | Confirmado | Meta `ms.date` y `updated_at`; nombres de fase en `rag.html.txt` |
| B09: ms.date 2025-10-10, act. 2026-07-02; las nueve citas de §2, §3.2.1, §3.2.2 y PG-4 | Confirmado, literal. **Título corregido**: el H1 es «RAG preparation phase» | `prep.html`, meta, `<h1>` y cadenas exactas |
| B10 RAGAS: autores, arXiv 2309.15217 (2023-09-26), citas del resumen; ACL `2024.eacl-demo.16` | Confirmado | `arxiv.xml`; ACL Anthology, pp. 150–158, St. Julians |
| B11 ARES: autores, 2311.09476 (2023-11-16), las tres dimensiones, «small set of human-annotated datapoints»; ACL `2024.naacl-long.20`; «unos cientos de anotaciones» (PG-5) | Confirmado. El resumen dice «only a few hundred human annotations during evaluation» | `arxiv.xml`; ACL Anthology, pp. 338–354 |
| B12: autores y 2405.07437 (2024-05-13); «venue no verificado» | **Corregido**: está publicado en Springer CCIS *Big Data* (2025), pp. 102–120, DOI `10.1007/978-981-96-1024-2_8` | Crossref, mismos seis autores |
| B13: más del 80 % de acuerdo y los sesgos citados; NeurIPS 36, DOI `10.52202/075280-2020` | Confirmado | `arxiv.xml` (resumen); Crossref «Advances in Neural Information Processing Systems 36» |
| B14 Latent Space: «product-specific data and evals», «the API line is permeable», «~5000 … ~50m», agradecimiento a Alessio; fecha | Confirmado. La fecha es `datePublished` 2023-06-30 en el JSON-LD (se corrigió el «el texto ubica el año»). El JSON-LD da como `publisher` a «Latent Space» y no trae autor | `ls.html` |
| B14 «acuñó el uso del término» | **No verificado**. Se marcó en el cuerpo | Sin fuente |
| B15 README: «adapting foundation models…», «Should I build this AI application?», «focuses on the fundamentals … instead of any specific tool or API», O'Reilly 2025 | Confirmado | `readme.html` |
| B15 ISBN `978-1801819312` del repo | **Refutado como ISBN de este libro**: Open Library lo asigna a *Machine Learning with PyTorch and Scikit-Learn* (Packt, 2022). 9781098166304 es *AI Engineering*, Chip Huyen, O'Reilly | API `openlibrary.org/api/books`; se corrigió §9.2 |
| B16: diez capítulos con los títulos de B-E7; «moving closer to product», «more AI engineers…» y *data flywheel* (cap. 10); «AI judges should be supplemented…» (cap. 3); de ML a AI engineering (cap. 1); cap. 8 *Dataset Engineering* | Confirmado, con el capítulo ubicado por línea | `ch.html` (encabezados `## Chapter N`) |
| B17 AI-103: act. 2026-08-11; «Role AI Engineer»; Python y Foundry; las responsabilidades y los colaboradores citados; sin C# | Confirmado | `ai103.html` (`updated_at`, texto) |
| B18 AI-102: «retired»; C# entre los lenguajes; act. 2026-06-30 | Confirmado | `ai102.html` |
| B19 Nygard: 2011-11-15; Context, Decision, Status, Consequences; «not just the "positive" ones» | Confirmado | `nygard.html` |
| B20 ADR (WAF): ms.date 2026-04-10; «append-only», «alternatives that you ruled out», confianza | Confirmado | `adr.html` |
| B-E3 NuGet: Evaluation, Quality, Reporting y `Microsoft.Extensions.AI` en 10.11.0 estable; NLP, Safety y DataIngestion en 10.11.0-preview.1.26513.7, sin estable | Confirmado (re-ejecutado) | `api.nuget.org/v3-flatcontainer/<id>/index.json` |
| D-02 «`Microsoft.Extensions.AI.Ollama` deprecado» | Confirmado: deprecado con `alternatePackage` OllamaSharp | Registro de nuget.org (`deprecation`) |
| D-03 `OLLAMA_NUM_PARALLEL` = 1 por defecto | Confirmado | `ollama/docs/faq.mdx` (main): «default 1» |
| Recuento de §3.3.4 «20 objetivos: dos comunes y 18 por actor» | **Corregido**: son 19 (2 + 17), también en §6 | Conteo de filas: D1–D6, A1–A4, O1–O4, S1–S3 |
| «Cinco fuentes de peso (B01 a B07)» en §1 | **Corregido**: son seis distintas, porque B06 es la ubicación de B05 | Tabla §7 |
| Referencias a los núcleos (N3 F26 512/25 %, N2 F9, N5 F08, N4 F21, N1 F02 y F12) | Se comprobó por muestreo que existen y dicen lo atribuido. No se re-verificaron contra sus fuentes, porque ya están verificadas en sus núcleos | `grep` sobre `Nucleos/N1..N5` |
| Correspondencia RAGAS/ARES con los evaluadores de .NET; objetivos de aprendizaje; propuesta de actor; severidades | Criterio propio, declarado como tal. No es refutable por fuente | — |

---

## 2026-10-28 — Nota de reanudación (caída de equipo anterior)

> Nota agregada en la reanudación desde estación 1 (`Reanudar.md` §4.1, tercer punto). No se modificó nada de lo anterior. Convención de nombres desde hoy: el servidor contra el que midieron los núcleos hasta el 2026-10-26 es **el servidor Ollama de la LAN del laboratorio (dado de baja el 2026-10-28)**; el que lo reemplaza es **el Ollama propio en contenedor (estación 1)**, que se usa sólo por `OLLAMA_ENDPOINT` (R-PRIV).

**Qué se perdió.** equipo anterior murió el 2026-10-28 a las 00:50. Lo que se trabajó ahí el 26 y el 27 se perdió. Para este dossier eso incluye los intermedios que cita la §8 (`{dir-de-trabajo}/n0b/`) y los de la verificación adversarial (`…/n0b-verif/`: PDF, `pdftotext`, HTML, `arxiv.xml`, respuestas de Crossref, nuget.org y Open Library). En estación 1 la ruta `{dir-de-trabajo}/` existe, pero se creó hoy y sólo tiene `recursos/`: no hay nada de `n0b*` (verificado con `ls` el 2026-10-28). N0b no tiene carpeta `N0b-Evidencia/`. **No se reconstruye de memoria**: el dossier vale tal como quedó escrito el 2026-10-26, y las extracciones de la §8 quedan sólo transcriptas. Todas se pueden volver a correr, porque son fuentes públicas (arXiv, Crossref, nuget.org, PDF institucionales) y no dependen del servidor de IA.

**Cuánto depende N0b del servidor.** Poco. N0b es un dossier de fuentes y de criterio: sus nueve ejecuciones (B-E1 a B-E9) son descargas de fuentes y consultas de registro, y ninguna tocó un modelo («No se compiló código», §8). Las únicas afirmaciones medidas contra un modelo son **heredadas** de N3, N5 y N6, y es ahí donde se re-verifican. Las mediciones previas contra el servidor Ollama de la LAN del laboratorio **valen como historia de ese servidor dado de baja**: describen lo que pasó con ese modelo, esa versión y esa carga, y no se trasladan al Ollama propio en contenedor (estación 1) sin volver a correrlas.

### Clasificación de lo abierto y de lo medido contra el modelo

Clases: **(a)** dependía del servidor Ollama de la LAN del laboratorio o de otro Ollama de equipo anterior (modelo, latencia, digest, tool calling, salida de una prueba) → **pendiente de re-verificación contra el Ollama propio en contenedor (estación 1)**; **(b)** abierto pero independiente del servidor → **sigue abierto tal cual**.

| # | Ítem (ubicación en N0b) | Clase | Por qué | Cómo se re-verifica / qué sigue |
|---|---|---|---|---|
| R1 | «Qwen citó una regla y la contradijo (N3 E5)» (§4 PG-2; también en §3.1.3 como «error caro» de C4) | (a) | Es la salida de una prueba de chat contra Qwen 2.5 7B en el servidor de la LAN (N3 §0.6, N3 §8.9) | Volver a correr el programa de `N3-Evidencia/` (`E3-rag-real-Program.cs` con `E5-chat-prompt-mejorado.json`) contra `OLLAMA_ENDPOINT`, por `<envoltorio-de-turnos> <recurso-compartido>`, con registro R-LLM (modelo, digest de `api/show`, parámetros, entrada, salida, fecha). Hoy en estación 1 no está el 7B: una corrida con otro modelo es **evidencia nueva**, no confirmación de E5. Hasta entonces PG-2 cita E5 como historia |
| R2 | «N3 E3 ya armó un conjunto de oro de 8 preguntas sobre 12 reglas, con recall@k y MRR» (§3.2.2; base de PG-4 y de D-10) | (a) | Recuperación medida con embeddings en un Ollama en contenedor de equipo anterior (volumen `<contenedor-del-arnés>`, perdido) | Re-correr `E3-rag-real-Program.cs` contra el `qwen3-embedding:0.6b` del Ollama propio en contenedor (estación 1) y comparar con lo registrado (8/8, MRR 1,000; `nomic-embed-text` no está hoy). Cuando se re-corra, sumar lo que pide §3.2.2: respuesta esperada y consultas no respondibles |
| R3 | D-03, contexto: «la corrida usa Qwen en un servidor Ollama de la LAN (CTX-LOCAL)» | (a) | El servidor ya no existe; el CTX-LOCAL de la demo pasa a ser el Ollama propio en contenedor (estación 1), sin GPU y de 4 núcleos | Lo fija el sondeo nuevo de `Sondeo-Entorno.md` (versión, `api/tags`, `api/show`). El criterio de D-03 (local por defecto, elección en la raíz de composición) no depende del servidor y no cambia |
| R4 | D-03, confianza: «La calidad de Qwen para tool calling todavía no se midió (N6 §8.1)» | (a) | Nunca se midió; se iba a medir contra el servidor de la LAN | Lo mide N6 en la fase de demo: N corridas por `<envoltorio-de-turnos> <recurso-compartido>` con tasa de llamadas correctas, de JSON válido y de valores fuera de catálogo, con R-LLM. Antes, la mesa decide qué modelo de chat con tools se baja al Ollama propio en contenedor (estación 1) (hoy sólo tiene `qwen2.5:0.5b`, según `Reanudar.md` §3) o si se usa estación 2 |
| R5 | D-03, criterio: `OLLAMA_NUM_PARALLEL` = 1 por defecto | (b) para la cita; (a) para el valor real | La cita es de la FAQ de Ollama (confirmada en la verificación adversarial). El valor efectivo en el contenedor nuevo es una propiedad del servidor | La cita sigue tal cual. El valor del contenedor se registra en el sondeo nuevo (variables del contenedor), sin escribir dirección ni puerto |
| R6 | D-05, consecuencia: «El servidor de la LAN no hace embeddings (N3 §0.4)» | (a) | Era un hecho de ese servidor. Según `Reanudar.md` §3, el Ollama propio en contenedor (estación 1) tiene `qwen3-embedding:0.6b` | Una llamada a `/api/embed` en el sondeo nuevo, con la dimensión devuelta (N3 registró 1024). Si responde, la consecuencia de D-05 queda como historia y la demo ya no necesita «otro Ollama» para embeddings |
| R7 | D-04, consecuencia: «El umbral corpus/ventana desde el cual conviene RAG no se midió (N6 §8.7)» | (a) | Depende del modelo y de `num_ctx` del servidor. N3b midió truncamiento silencioso con el `num_ctx` por defecto en un Ollama propio de equipo anterior (N3b §0.5, X4b), también perdido | Medir contra el Ollama propio en contenedor (estación 1) con `num_ctx` explícito, por `<envoltorio-de-turnos>`. Con el corpus real (~250–265 tokens, N3b §0.6) el umbral no se alcanza: sólo hace falta si la mesa aprueba el corpus sintético de N3b §3.7 |
| R8 | D-10 y PG-5: «La calidad de Qwen como juez está sin verificar (N5 §8.4)» | (a) | Nunca se midió; se iba a correr contra el servidor de la LAN | Corrida real de `RelevanceEvaluator`/`GroundednessEvaluator` con caché contra el Ollama propio en contenedor (estación 1), calibrada con un puñado de casos anotados a mano (idea de B11), con R-LLM. Con un modelo de 0,5B el resultado probablemente no sirva como juez; eso se mide, no se supone |
| R9 | §8: intermedios de B-E1 a B-E9 y de la verificación adversarial | (b) | Fuentes públicas; no tocan el servidor de IA | Perdidos; se re-corren si la integración necesita la evidencia en disco. Lo que se re-corra se guarda en una `N0b-Evidencia/` nueva |
| R10 | B-E3: versiones NuGet de `Microsoft.Extensions.AI.Evaluation*` y `DataIngestion` (10.11.0 / 10.11.0-preview.1.26513.7) | (b) | Registro de nuget.org, fechado el 2026-10-26 | Sigue tal cual; es volátil y se vuelve a consultar al redactar (N1b: «la fecha de un tutorial es un dato técnico») |
| R11 | §9.1 Autor de B14 | (b) | Fuente web | Sigue abierto |
| R12 | §9.2 ISBN de B15 | (b) | Catálogos | Sigue abierto |
| R13 | §9.3 Contenido completo de B15/B16 | (b) | Libro | Sigue abierto |
| R14 | §9.4 Vigencia de B04 | (b) | Fuente institucional | Sigue abierto |
| R15 | §9.5 PAIR `guidebook-v2` | (b) | Fuente web | Sigue abierto |
| R16 | §9.6 Tipo de revisión de B12 | (b) | Fuente editorial | Sigue abierto |
| R17 | §9.7 Correspondencia RAGAS/ARES ↔ evaluadores .NET | (b) | Criterio propio sobre documentación | Sigue abierto |
| R18 | §9.8 y §3.4.11: decisión «sincrónico o en segundo plano»; semántica de `AllowBackgroundResponses`/`ContinuationToken` | (b) | Se estudia con documentación y reflexión, sin modelo | Sigue abierto; ningún núcleo la investigó (N2 sólo tiene la reflexión, N4 §8.9 la nota del harness) |
| R19 | §9.9 Endpoint de realimentación sin compilar | (b) | Se compila y se prueba con cliente falso | Sigue abierto |
| R20 | §9.10 Objetivos de aprendizaje y propuesta de actor | (b) | Criterio propio para DC-02 | Sigue abierto |
| R21 | §9.11 Guía de estudio de AI-103 | (b) | Fuente web | Sigue abierto |
| R22 | §3.4.11 y D-06: sonda de N6 T1 (qué `IServiceProvider` llega a `AIFunctionArguments.Services` con cliente singleton) | (b) | Es comportamiento de DI; se prueba con un `IChatClient` falso | Sigue abierto; la sonda se corre con cliente falso, sin recurso `<recurso-compartido>` (sí con el recurso `build`) |
| R23 | §3.4.11 y D-04: «CAG pendiente del dossier de PR-8» | (b) | No depende del servidor; el dossier N3b ya existe (2026-10-26) | Sigue como está acá; la actualización de D-04 con N3b es de la fase de integración (ver la contradicción anotada para el plan) |

**Resumen.** De 23 ítems, 8 tienen alguna parte en la clase (a) (R1–R8; R5 sólo por el valor real del contenedor) y todos se re-verifican en los núcleos de origen (N3, N5, N6) o en el sondeo nuevo, no en N0b. Los once del §9 y los demás quedan abiertos tal cual. Ninguna recomendación del §6 (PR-9, PR-10, PR-1, PR-14, PR-13) depende de una medición contra el servidor dado de baja; sólo cambian las confianzas de D-03 y D-10 y el ejemplo de PG-2 cuando se re-verifiquen R1, R4 y R8.

## 2026-10-28 — Reparación de integración (BIT-16-04)

> Nota agregada en la fase de integración ([`../04-Integracion.md`](../04-Integracion.md)). **Sólo agregado**: no se modificó nada de lo anterior. Los IDs entre paréntesis (RA-*, T*, C-*, R-C*, I-*, MI-*) remiten a las resoluciones de BIT-16-04; la evidencia nueva está en `../Integracion-Evidencia/`. Lo marcado MI-nn es criterio propio que vota la mesa en el ciclo 1.

- **D-01** (RA-2 = C-1). Confirmada por la integración: rige la (c). EA-2/EA-3 muestran que la copia literal de `Domain/`+`Application/` de ApiWeb más los puertos nuevos compila y que no hay `using` de IA fuera de `Infrastructure/AI`. La regla se hace cumplir con una prueba de arquitectura (MI-04).
- **D-02** (R-C14, I-2, I-6). El cambio de proveedor vive en la composición (`AddAI`) con la clave `AI:Proveedor = OllamaSharp | OpenAICompatible`. La vía .NET contra `/v1` **ya se ejecutó** (E-B1 5/5, E-B2 4/5 válidos para el dominio): ya no está pendiente. Dónde se muestra (demo + ejemplo 01, o sólo ejemplos) lo decide la mesa (MI-13).
- **D-03** (R-C08, R-C11). Contexto vigente: el Ollama propio en contenedor (estación 1), 0.40.11, CPU de 4 núcleos sin GPU, contexto 4096 al cargar. `OLLAMA_NUM_PARALLEL=1` es el valor **configurado** del contenedor (X4). El modelo sale de configuración; propuesta `qwen3.5:4b` con razonamiento apagado (MI-02).
- **D-04, §3.4.11 fila 3 y §6 fila PR-13** (C-9, R-C13). CAG ya está investigado en N3b (escalones 0/1/1b). La alternativa (d) «no investigado» queda desactualizada. Decisión propuesta: (b) contexto fijo por defecto en C4, (c) RAG como variante didáctica, (a) herramienta para C1 (MI-07).
- **D-05** (R-C12). «El servidor no hace embeddings» es historia del servidor dado de baja. estación 1 sirve `qwen3-embedding:0.6b` con dimensión 1024 por HTTP (Sondeo §R.3) y desde `IEmbeddingGenerator` .NET (EA-6, E-B4). La dimensión va por configuración y se valida al arrancar (MI-17).
- **D-06 y §3.4.11 fila 2** (R-C02, R-C04). T1 resuelto con X1 [B]: con el cliente Singleton y `ValidateScopes=true`, la herramienta no puede resolver el `SessionContext` (`InvalidOperationException`); con `ServiceLifetime.Scoped`, cada sesión ve el suyo. La forma (ADR propio o dentro de D-06) va a la mesa (MI-23). Además, **el alta también se aprueba en ESC-04** (`ApprovalRequiredAIFunction` sobre `agregar_localidad`): X2 D1 muestra que el 4b inventa un CP ante uno inválido 10/10, y que 2/10 («3400») pasarían la regla (MI-14).
- **D-09** (R-C06, R-C07). Un solo nombre de fuente y medidor OTel (X1 [A]: con nombres distintos se exportan 0 spans). El orden del pipeline lo fija N5 (telemetría por fuera de la caché).
- **D-10 y PG-5** (R-C09). El juez tiene dueño: N5 escribe el método y la corrida vive en `tests/ConModelo/` de la demo, con calibración de 10–20 casos de C4 (MI-16). No se corrió.
- **§3.1.3** (R-C20). Primera medición de «falso aceptado» en C2: 2 de 10 con `qwen3.5:4b` si no hubiera confirmación (X2 D1). Con la confirmación, la métrica pasa a «propuestas que la persona tuvo que corregir». El umbral sigue siendo de la mesa (MI-24).
- **R22 y R23 de la nota de reanudación**: cerrados (R22 por X1; R23 por esta nota).

> **2026-10-28 — Parche P-02 (ciclo 1).** «Falso aceptado» tenía tres sentidos en esta bitácora. Desde hoy se separan así:
> 1. **Falso aceptado** (métrica de C2, la única que lleva ese nombre): proporción de propuestas de alta que alteran o inventan un dato que el texto de entrada dio, o que no dio, sin declararlo, y que pasan las reglas de `LocalidadRules`. Se mide contra un conjunto de oro de textos de entrada con el dato esperado, con N y el criterio escritos antes de correr. La unidad es la propuesta. El denominador son las propuestas que pasan las reglas.
> 2. **Escritura sin confirmación**: toda escritura que se ejecuta sin la confirmación de la persona. No es una tasa. Es una invariante de construcción que tiene que dar 0 y se prueba en `Cableado/` (M3, P-35).
> 3. **Propuesta corregida por la persona** (R-C02): métrica de producto de CTX-PROD, que la demo no mide.
>
> El 2/10 de X2 D1 (Wilson 95 % [0,06; 0,51]) fue una observación del sentido 1 sobre un solo pedido. No sostiene ningún umbral. La guía dice «no medido» para el falso aceptado de C2. El umbral lo fija ACT-ARQ por escenario, después de medir con un N que dé un intervalo con ancho menor o igual a 0,2, o sea N ≥ 96 para p cerca de 0,5. Ese N es un criterio propio derivado de la aproximación normal y no se corre en este ciclo.

> **2026-10-28 — Ciclo 1 de la mesa: convención de ids en estas notas.** «Parche P-nn (ciclo 1)» es un parche de `Mesa/Ciclo-1/03-Parches.md`, aplicado según `Mesa/Ciclo-1/05-Aplicacion.md`; «P-nn» sin calificar dentro de un texto de parche también es un parche. Los pendientes de BIT-16-04 §7 se citan como «pendiente P-nn de BIT-16-04». El plan vinculante de redacción es `Mesa/Ciclo-1/06-Plan-De-Redaccion.md`.

> **2026-10-28 — Parche P-01 (ciclo 1).** Redacción in situ por R-PRIV (C1-01; jurado 5/5, aprobación 5/5): se redactaron 3 ruta(s) absoluta(s) del home, reemplazadas por rutas desde la raíz del workspace o por variable (`$WORKSPACE`, `$FC_WORK`). No cambió ninguna afirmación (diff palabra por palabra en `Mesa/Ciclo-1/05-Aplicacion.md`). Es la excepción a «sólo agregado» que prevé 03-Parches §0.1; el dictamen de la presidencia sobre esa excepción queda registrado como pendiente en 05-Aplicacion. La salida de la compuerta antes y después está en `Mesa/Ciclo-1/aplicacion/rpriv-2026-10-28-antes.txt` y `rpriv-2026-10-28-despues.txt`.

> **2026-10-28 — Parche P-31 (ciclo 1).** Las fuentes de §7 de este registro entran a la guía por el catálogo único `REF-nnn` del Anexo D (texto en BIT-16-04 §8, nota de Parche P-31). Este registro no se renumera.

> **2026-10-28 — Parche P-34 (ciclo 1).** Este registro todavía no está validado (REED-16 §6.2). Sus secciones «Marcas [C] resueltas» y «Validación del núcleo» se agregan al aplicar el ciclo 1.

> **2026-10-28 — Parche P2-13 (ciclo 1, ronda 2).** R-C20: el N ≥ 96 de la nota de P-02 se reemplaza por una tasa de la tarea según R-LLM-3d (K ≥ 10 textos redactados antes, m ≥ 3 semillas por texto, intervalo sobre los textos). Texto en §3.1.3.


## Marcas [C] resueltas (2026-10-28)

> Agregado por la aplicación del ciclo 1 (Parche P-34; REED-16 §6.2, sección 4). Sólo agregado.

Este registro no tiene marcas `[C:]` de BIT-16-01: N0b se sumó después de la fundación por PR-9, PR-10, PR-13 y PR-14 (BIT-16-04 §6.1). Nada que resolver.

## Validación del núcleo (ciclo 1)

> Agregado por la aplicación del ciclo 1 (Parche P-34; REED-16 §6.2, sección 6). Veredicto a la fecha de aplicación; lo revisa la relectura integral.

- **Parches del ciclo 1 que lo alcanzan:** P-01 (rutas redactadas, compuerta en 0), P-02 (S1 C1-02: aplicado y verificado sobre la bitácora con `grep`), P-12 (S2 C1-12: aplicado; prueba del pendiente P-10 de BIT-16-04 diferida a `Cableado/`), P-13 (S2 C1-14: D-11 firme; contrato condicionado a la segunda ronda), P-22 (§3.2.2), P-34, P-38 (PG-5).
- **Severidades abiertas sobre él:** S1: ninguno (C1-02 cerrado sobre la bitácora; la guía lo hereda como RV-02). S2 con verificación diferida: C1-12, C1-14.
- **Veredicto:** **No validado.** Desbloqueado para redactar las secciones que derivan de él (REED-16 §6.2 (a), Parche P-34). Se revalida en la relectura integral, con la prueba del pendiente P-10 de BIT-16-04 corrida.
