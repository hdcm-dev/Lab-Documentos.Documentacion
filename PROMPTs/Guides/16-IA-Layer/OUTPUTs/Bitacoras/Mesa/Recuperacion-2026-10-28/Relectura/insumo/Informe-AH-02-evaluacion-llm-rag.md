---
doc_id: BIT-16-C1-INF-AH-02-evaluacion-llm-rag
doc_type: informe-de-especialista
title: Informe de AH-02 — Evaluación de sistemas LLM y RAG (ciclo 1)
status: hecho
origin: agent
owner: AH-02 Evaluación de sistemas LLM y RAG (panel del ciclo 1)
date: 2026-10-28
traces: [BIT-16-C1-00 §4.2, REED-16 §8.3, BIT-16-00 §2–§3, BIT-16-04 §1, §2, §5, §6.3, §7, BIT-16-N0b, BIT-16-N3, BIT-16-N5, BIT-16-N6]
evidencia: evidencia-AH-02-evaluacion-llm-rag/
---

# Informe de AH-02: Evaluación de sistemas LLM y RAG

**Pregunta del mandato** (carta BIT-16-C1-00 §4.2): ¿las pruebas de `Examples/` y `Demos/` demuestran lo que la guía afirma, con aserciones que no dependen del azar? ¿La guía enseña a evaluar la calidad de las respuestas y de la recuperación con herramientas vigentes de .NET?

**Respuesta corta.** Todavía no existen `Examples/` ni `Demos/`. Lo que se juzga es el **diseño** de sus pruebas (N5 §2.4–§2.6, §4.5–§4.6, §8.4; N6 Anexo A y Q1–Q10; BIT-16-04 M11, MI-07, MI-08, MI-16, MI-24, P-01…P-06) y las mediciones que ya sostienen decisiones. El esqueleto está bien: separa el cliente falso de la evaluación, el evaluador determinista del juez, el registro R-LLM y el aviso de que «N chico no es una cifra de fiabilidad». Hay tres huecos de método:

1. El juez local que se propone choca con una advertencia oficial que la bitácora no cita.
2. La cifra de recuperación que respalda C4 y ESC-02 se midió sobre otro corpus. Sobre el corpus real, la similitud no separa las preguntas respondibles de las no respondibles.
3. La suite `ConModelo/` no dice qué hace fallar una prueba.

Además, varias decisiones se apoyan en tasas cuyo N no alcanza para lo que se les atribuye.

Límites del mandato: no opino sobre seguridad, forma ni arquitectura. Tampoco opino sobre cómo se enuncian las definiciones y los umbrales (eso es del Formal). Cuando nombro hit@k o recall@k, lo hago para decir **qué se mide**, no cómo se define.

## Índice

- [1. Evidencia producida](#1-evidencia-producida)
- [2. Hallazgos](#2-hallazgos)
- [3. Lo que revisé y está bien](#3-lo-que-revisé-y-está-bien)
- [4. Posición sobre los MI de mi mandato](#4-posición-sobre-los-mi-de-mi-mandato)
- [5. Pendientes P-01…P-06 y M11](#5-pendientes-p-01p-06-y-m11)
- [6. Solicitudes de convocatoria](#6-solicitudes-de-convocatoria)

## 1. Evidencia producida

En `evidencia-AH-02-evaluacion-llm-rag/` (README con niveles):

- **S-R (E1)**: sonda de recuperación con `qwen3-embedding:0.6b` (`ac6da0dfba84…`) contra el Ollama propio en contenedor (<equipo-de-contingencia>), por turno `modelo-compartido` (2026-10-28T12:56Z), con dos repeticiones. Compara el corpus A, la paráfrasis de N3 E3 (historia), con el corpus B, los **12 enunciados reales de `*Policy`** tal como los lee `CorpusDeRequisitos` (EA-6 `salida-real.txt`). Usa las mismas 8 preguntas de N3 E3 más 3 no respondibles. Resultado:

  | Corpus | Preguntas con oro | hit@1 | hit@3 | MRR@5 | Repetición 2 |
  |---|---|---|---|---|---|
  | A (paráfrasis E3) | 8 | 8/8 | 8/8 | 1.000 | idéntica (mismos puntajes y la misma huella de vectores) |
  | B (`*Policy` reales) | **6** (2 de las 8 no tienen enunciado que las responda) | 5/6 | 6/6 | 0.917 | idéntica |

  Con el corpus B, el top-1 de preguntas **no respondibles** puntúa **más alto** que el de una respondible: «Si elimino una ciudad, ¿se pierden las encuestas?» → 0.445 y «¿Puedo viajar en avión?» → 0.383, frente a «¿Cuántos números lleva el CP?» → 0.363, que es correcta. En la respondible, el margen sobre el segundo es de 0.015.
- **S-I (E1, cálculo)**: intervalos de Wilson al 95 % de las tasas de BIT-16-04: 2/5 → [0.12, 0.77]; 1/1 → [0.21, 1.00]; 2/10 → [0.06, 0.51]; 11/13 → [0.58, 0.96]; 3/3 → [0.44, 1.00]. Para un juez con 16/20 de acuerdo → [0.58, 0.92]; con 8/10 → [0.49, 0.94]. Con 0 fallas en n = 10, la cota superior del 95 % es 0.26.
- **S-N (E1)**: nuget.org al 2026-10-28T12:57Z. `Microsoft.Extensions.AI.Evaluation`, `.Quality` y `.Reporting` están en 10.11.0 GA; `.NLP` y `.Safety` sólo en 10.11.0-preview.1.26513.7. Coincide con N5 §3.1 y X0.
- **F-Q (E4)**: referencia de API de `RetrievalEvaluator` y `GroundednessEvaluator` (learn.microsoft.com, `updated_at` 2026-10-16, leída el 2026-10-28). Dice literalmente: «the performance of this prompt (and the resulting evaluation) can vary depending on the model used, and can be especially poor when a smaller / local model is used», y que el prompt se probó y ajustó con **GPT-4o**. Puntaje de 1 a 5.

## 2. Hallazgos

### AH-02--01 · El juez local de MI-16/P-03 no se apoya en la advertencia oficial y no cabe en el turno de <equipo-de-contingencia>

- **Ubicación**: N5 §2.6 («Qué no es»), §4.6 (cierre), §5 P4, §8.4 y su reparación del 2026-10-28; BIT-16-04 R-C09 (L112), MI-16 (L175), P-03 (L348); N0b PG-5.
- **Capa de origen**: núcleo (N5), arrastrado a la integración.
- **Afirmación**: la bitácora trata la fiabilidad del juez Qwen local como «[no verificado]» que se resolvería calibrando con 10–20 casos. La documentación oficial de los evaluadores de Quality dice otra cosa: con modelos chicos o locales el desempeño «can be especially poor», y el prompt está ajustado para GPT-4o. N5 cita F07/F08, pero no esta advertencia. Con 10–20 casos, además, la calibración no certifica nada: 16/20 de acuerdo deja un IC95 de [0.58, 0.92].
- **Evidencia**: E4 (F-Q, citas literales) y E1 (S-I). El costo tampoco cierra. Con lo medido en <equipo-de-contingencia>, una llamada al 4b tarda entre 13 y 58 s (X2) y la vía A con contexto, 96 s (EA-6). Los evaluadores de Quality agregan su propio prompt de rúbrica. Así, 10–20 casos × 2 adaptadores (MI-07) × 3 evaluadores × N corridas sin caché supera con holgura los 45 min. **[estimación sobre E1 ajeno; no medido]**.
- **Severidad**: S2. Es una recomendación de herramienta sin el contexto que la limita, y la guía la presentaría como método de evaluación de la demo.
- **Confianza**: 0.85.
- **Impacto si no se corrige**: el lector adopta un juez de 4B como medida de calidad de C4, lee puntajes 1–5 de un evaluador que el fabricante desaconseja para ese tamaño y cree que «calibró» con 10 casos.
- **Propuesta de dirección**:
  1. La guía enseña el juez de MEAI.Evaluation como **método**, con la advertencia oficial citada y los sesgos de B13.
  2. En <equipo-de-contingencia>, el juez se declara **«no medido»**. La calidad de C4 se mide primero con aserciones deterministas sobre la salida: cita presente y perteneciente al conjunto esperado, abstención en las no respondibles, evaluador propio del estilo de `MedioEnCatalogoEvaluator`.
  3. Si se corre un juez (en <estación-2>, MI-03), se informa el acuerdo con las anotaciones humanas como k/n con intervalo. Nunca funciona como compuerta.

> **2026-10-28 — Parche P2-11 (ciclo 1, ronda 2).** El costo estimado acá quedó medido en PC-08: unos 34 s por evaluación en el segundo servidor y 1285 s por caso con 7 evaluadores en la estación (N = 1, anfitrión sin reservar); la estimación por fórmula subestimó un 35 %. Texto en N5 §2.6 y BIT-16-04 §5 (MI-16).


### AH-02--02 · La cifra de recuperación que respalda C4 y ESC-02 se midió sobre otro corpus, y su conjunto de oro no se traslada

- **Ubicación**: N3 §5 (L351, L354), §6 C6, nota de reanudación (fila E3) y reparación (P-05); N0b §3.2.2 (L137); BIT-16-04 P-05 (L350), MI-08 (L167).
- **Capa de origen**: núcleo (N3), arrastrado a la integración.
- **Afirmación**: N3 dice «con 8 preguntas coloquiales sobre 12 reglas del dominio, `qwen3-embedding:0.6b` acertó 8/8 (MRR 1.000)». Pero esas 12 «reglas» son una **paráfrasis escrita a mano** (`E3-rag-real-Program.cs`) y no los enunciados de `*Policy` que la demo indexa (EA-5: «Localidad, codigo postal: 4 dígitos.»). Sobre el corpus real, 2 de las 8 preguntas no tienen ningún enunciado que las responda (baja de localidad, aislamiento de sesión). En otras 3, el «relevante» existe pero **no contiene la respuesta**: «Encuesta, medios: Al menos uno.» no dice si «a pie» está permitido. Con eso quedan hit@1 = 5/6 y MRR = 0.917 sobre 6. P-05 dice «re-medir en <equipo-de-contingencia>», pero no dice sobre qué corpus ni con qué conjunto. Por otro lado, N3 L354 dice que «se evalúa la respuesta con `GroundednessEvaluator` y `RetrievalEvaluator`». `RetrievalEvaluator` no juzga la respuesta: juzga la relevancia y el orden de los fragmentos recuperados (F-Q).
- **Evidencia**: E1 (S-R) y E2 (N3 L351 frente a EA-6 `salida-real.txt` [1]).
- **Severidad**: S2. La evidencia no corresponde al objeto que la guía va a enseñar, y el conjunto de oro no es reproducible sobre la demo.
- **Confianza**: 0.9.
- **Impacto si no se corrige**: la guía publica «8/8, MRR 1.000» como la recuperación de la ayuda de Movilidad Urbana. Un lector que corra la demo obtiene otra cifra sobre otro corpus. Además, el oro premia recuperar un enunciado que no responde.
- **Propuesta de dirección**: rehacer el conjunto de oro de C4/ESC-02 **sobre el corpus que genera el código**. Lleva tres columnas (pregunta, enunciado esperado, respuesta esperada, como pide B09 en N0b PG-4), etiquetas respondible/no respondible y versión atada a `*Policy`. La cifra de N3 E3 queda como historia del corpus sintético. La guía separa dos cosas: «el relevante está en el top-k» y «el top-k alcanza para responder».

### AH-02--03 · Con el corpus real, el puntaje de similitud no separa respondibles de no respondibles, y nada mide la abstención

- **Ubicación**: BIT-16-04 MI-07 (L166), MI-08 (L167), P-06 (L351), M12 («la ayuda muestra la fuente»); N3 §5 P4–P5; N6 Anexo A D5.
- **Capa de origen**: integración.
- **Afirmación**: el conjunto de oro de C4 y la métrica de ESC-02 sólo prevén recall@k/MRR. En el corpus real, el top-1 de dos preguntas no respondibles (0.445 y 0.383) supera al top-1 de una respondible bien recuperada (0.363). Ningún umbral de similitud permite que `AyudaRag` diga «no sé» sin rechazar también respuestas correctas. E-B5 mostró lo mismo en otro escenario («en avión» → `moto`, 0.641). recall@k no mide esto, porque las no respondibles no tienen relevante. Por otro lado, la sonda muestra que la recuperación con digest fijo es **determinista**: dos repeticiones dieron puntajes idénticos. Eso permite aserciones duras sobre el ranking, cosa que la generación no permite.
- **Evidencia**: E1 (S-R) y E3. Escenario: «¿Si elimino una ciudad se pierden las encuestas?». El top-3 trae `E.Localidad`, `E.Medios` y `E.Distancia`, y la ayuda responde citando una fuente que no habla de la baja.
- **Severidad**: S2. La propuesta de MI-07, comparar `AyudaContextoFijo` con `AyudaRag`, quedaría sin la dimensión donde más difieren.
- **Confianza**: 0.8. El N es chico: 3 no respondibles. La inversión de puntajes se observó y alcanza como contraejemplo, pero no como tasa.
- **Impacto si no se corrige**: la demo compara los dos adaptadores sólo en las preguntas donde ambos aciertan. La guía no enseña que la abstención se evalúa aparte y que no la resuelve un umbral de coseno.
- **Propuesta de dirección**: (1) el conjunto de oro de C4 incluye no respondibles y se mide la **tasa de abstención correcta** de cada adaptador sobre el mismo conjunto (comparación pareada); (2) la guía muestra la inversión de puntajes como ejemplo de por qué «la similitud siempre devuelve algo»; (3) las pruebas de recuperación con modelo de embeddings y digest fijos se escriben como aserciones exactas sobre el ranking (top-k esperado), y las de generación como propiedades y tasas.

### AH-02--04 · Hay decisiones apoyadas en tasas que no admiten la lectura que se les da, y la garantía de seguridad se plantea como tasa

- **Ubicación**: BIT-16-04 §1 EA-6 (L54), §2 tensión 1 (L72), MI-01, MI-24 (L183), R-C20, P-01 (L346); EA-6 `salida-real.txt`.
- **Capa de origen**: integración.
- **Afirmación**: BIT-16-04 §1 avisa bien que «N chico… no son cifras de fiabilidad». Sin embargo:
  - La tensión 1 usa «A acierta y cita; B omite recuperar 2/5» para ordenar A antes que B. En `salida-real.txt`, la vía A corrió **una sola vez** (N = 1, IC95 [0.21, 1.00]) y la B cinco veces (2/5 fallas, IC95 [0.12, 0.77]). La comparación es asimétrica y no pareada, así que no separa las vías.
  - MI-24 pone como referencia del umbral de C2 el «falso aceptado 2/10» (IC95 [0.06, 0.51]).
  - P-01 pide medir con N = 10 «la tasa de escrituras efectivamente cortadas». Para una garantía de seguridad (M3), una tasa con N = 10 y 0 fallas sólo acota el riesgo en 26 %. La garantía no viene del modelo sino de `ApprovalRequiredAIFunction`, y eso se prueba con una aserción determinista.
- **Evidencia**: E1 (S-I; EA-6 `salida-real.txt` [R3] con una corrida y [R4] con cinco) y E2 (BIT-16-04 L54 y L72).
- **Severidad**: S2. Una salida de modelo con N chico se presenta como fundamento de una regla.
- **Confianza**: 0.85.
- **Impacto si no se corrige**: la guía enseña a elegir arquitectura con 1 frente a 5 corridas y a «medir» una garantía de seguridad como si fuera una frecuencia.
- **Propuesta de dirección**: con N ≤ 10, la guía sólo afirma **existencia** («se observó que el 4b omite la herramienta»). Las comparaciones entre vías usan las mismas preguntas, el mismo N y las mismas semillas. MI-01 se sostiene con el argumento de diseño, no con la tasa. Las invariantes (ninguna escritura sin aprobación, ningún valor fuera de catálogo persistido) se afirman en `Cableado/` de forma determinista, y en `ConModelo/` como aserción que **falla ante una sola violación**, no como tasa. La forma de enunciar los intervalos es del Formal (§6).

### AH-02--05 · `ConModelo/` (M11, Q6) no define qué hace fallar una prueba, y su salteo silencioso se lee como «medido»

- **Ubicación**: N6 Anexo A (L463: «se saltean si no responde; registran R-LLM»), §6 Q6 (L368); BIT-16-04 M11 (L337), P-02 (L347); N5 §6.1 criterio 5.
- **Capa de origen**: núcleo (N6), arrastrado a la integración.
- **Afirmación**: la suite contra el modelo tiene destino, categoría y registro, pero no criterio de aserción. No distingue entre (a) propiedades que se verifican en **cada** corrida y hacen fallar la prueba, (b) tasas que se informan con k/n frente a un criterio escrito antes y que no son compuerta, y (c) el caso «no corrió». Con NUnit, una prueba que se saltea porque el endpoint no responde y no se marca `Inconclusive`/`Ignore` con motivo deja un reporte en verde. En <equipo-de-contingencia>, donde el turno es exclusivo y de 45 min, eso va a pasar seguido. P-02 pide «N mayor» sin decir cuál ni para qué afirmación.
- **Evidencia**: E2 (citas) y E3. Escenario: CI sin `OLLAMA_ENDPOINT` → `ConModelo/` en verde → el README de la demo dice «probado contra Qwen».
- **Severidad**: S2. El ejemplo no es reproducible sin preguntar, y la salida de modelo se trataría como probada.
- **Confianza**: 0.8.
- **Impacto si no se corrige**: las pruebas no demuestran lo que la guía afirma. O pasan por azar con una tasa ajustada, o no corren y nadie se entera.
- **Propuesta de dirección**: M11 se reformula en tres tipos de aserción, (a) invariantes por corrida, (b) tasas informadas con N declarado y criterio previo, y (c) «no medido» explícito y visible en el reporte. Cada prueba de `ConModelo/` declara a qué tipo pertenece. P-02 fija N según la afirmación que se quiere sostener: para «ocurre», alcanza con pocas corridas; para acotar una tasa de falla, la regla del tres da 3/n como cota.

## 3. Lo que revisé y está bien

1. **N5 §2.4–§2.6 y §5 P4** separan bien el `IChatClient` falso (prueba tu código, es determinista, corre en cada build) de MEAI.Evaluation (mide la respuesta, no es determinista, se lee como tendencia, con F08). Lo mismo vale para el evaluador propio determinista (§4.5, verificado en V5) frente al juez. Es la base correcta de R-LLM y la guía debe conservarla.
2. **Registro R-LLM de EA-6 y X2**: modelo@digest, temperatura, semilla por corrida, `think=false`, N, criterio escrito antes y salidas crudas en archivo. Además, BIT-16-04 §1 declara que esas tasas «no son cifras de fiabilidad para citar en la guía». Los defectos de AH-02--04 son de **uso** de esas tasas, no de registro.
3. **Herramientas de evaluación vigentes**: `Microsoft.Extensions.AI.Evaluation`, `.Quality` y `.Reporting` están en 10.11.0 GA, y `.NLP` y `.Safety` sólo en preview (S-N, 2026-10-28). Coincide con N5 §3.1 y X0. También es correcta la marca `AIEVAL001` de los evaluadores orientados a agentes (V7/R7) y la advertencia de que Safety no funciona offline (F12).

## 4. Posición sobre los MI de mi mandato

| MI | Posición | Fundamento |
|---|---|---|
| MI-07 | **propuesta**, con condiciones | `IAyuda` con dos adaptadores sirve para evaluar si el conjunto de oro es **el mismo** para los dos (comparación pareada), está armado sobre el corpus real con no respondibles y mide abstención y cita además de recuperación (AH-02--02, --03). El juez no es necesario para esta comparación. |
| MI-08 | **propuesta**, con condiciones | Buscar el requisito por significado es un escenario medible de forma **determinista** con digest fijo (S-R: dos repeticiones idénticas). Por eso puede llevar aserciones exactas. Con 6 preguntas respondibles, el número no alcanza más que para enseñar el método. Hace falta un conjunto mayor y versionado con `*Policy`, con no respondibles. La definición de la métrica es del Formal. |
| MI-16 | **otra** | Que no haya juez local calibrado como pieza de la demo en <equipo-de-contingencia>. La guía enseña el juez con la advertencia oficial (F-Q) y sus sesgos (B13). En <equipo-de-contingencia> se declara «no medido». Si se corre en <estación-2>, el acuerdo con las anotaciones se informa como k/n con intervalo y nunca como compuerta. 10–20 casos sólo detectan una falla grosera (AH-02--01). |
| MI-24 | **otra** (sólo la parte del umbral de C2) | El umbral no se fija con 2/10 (IC95 [0.06, 0.51]). La métrica automatizable es la tasa de propuestas que **alteran un dato dado sin declararlo**, medida contra un oro y no contra la persona. El umbral lo decide ACT-ARQ por escenario (N0b §3.1.3), con un N suficiente para la cota que pida. La parte «sincrónico o en segundo plano» no es de mi mandato: me abstengo. |
| MI-03 | **propuesta** (sólo la parte de evaluación) | El juez y cualquier tasa con N grande no caben en un turno de 45 min (estimación de AH-02--01). Si <estación-2> no se aprueba, se declaran «no medido» y no se dejan de lado en silencio. |
| MI-11 (sólo M11) | **otra** | M11 sí, reformulado en tres tipos de aserción: invariantes por corrida, tasas informadas y «no medido» explícito (AH-02--05). Sobre el resto de M1–M12 no opino: no es mi mandato. |

## 5. Pendientes P-01…P-06 y M11

| # | Posición de AH-02 |
|---|---|
| P-01 | La parte de seguridad se convierte en **invariante**: una sola escritura sin aprobación hace fallar la prueba. La tasa de `ToolApprovalRequestContent` emitido se informa con k/n. N = 10 alcanza para mostrar que el modelo a veces no pide aprobación, no para acotar el riesgo (AH-02--04). |
| P-02 | Para cada prueba hay que declarar qué afirmación sostiene y con qué N (AH-02--05). |
| P-03 | **No medido en <equipo-de-contingencia>**, por estimación de costo. Depende de MI-03. No bloquea la guía si el juez se enseña como método (AH-02--01). |
| P-04 | Fuera de mi foco (MCP y workflows). Pido que siga R-LLM y la regla de AH-02--05. |
| P-05 | **Medido en parte en este ciclo** (S-R) con las preguntas viejas sobre el corpus real. Sigue pendiente con el conjunto de oro nuevo (AH-02--02). Es barato: sólo embeddings, menos de 1 min por corrida. |
| P-06 | Depende de MI-07 con las condiciones de §4. Mientras el juez no esté aprobado, se corre sin él. |
| M11 | Ver MI-11 en §4. |

## 6. Solicitudes de convocatoria

1. **Formal**: que enuncie la métrica de ESC-02/C4. N3 L128 define hit rate@k y lo llama recall@k, y el código de E3 imprime «recall@1/recall@3» y «MRR@5» con truncamiento. También le corresponde cómo se escriben k/n e intervalos en la guía (AH-02--04). Yo juzgo qué se mide; la enunciación es suya.
2. **Operación y entrega (con Rendimiento y costo)**: que mida o estime el costo en tiempo de los evaluadores de Quality con el 4b en <equipo-de-contingencia>, contando el prompt de rúbrica y el `prompt_eval` en CPU, para decidir MI-03 con datos y no con mi estimación (AH-02--01).
