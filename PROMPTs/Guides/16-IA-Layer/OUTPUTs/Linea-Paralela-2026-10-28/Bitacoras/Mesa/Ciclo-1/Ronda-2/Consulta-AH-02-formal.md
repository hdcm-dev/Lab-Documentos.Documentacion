---
doc_id: BIT-16-C1R2-CON-AH-02-formal
doc_type: consulta-dirigida
title: Consulta dirigida a AH-02 (Evaluación + Formal) — PC-10 y regla R-LLM operativa
status: hecho
origin: agent
owner: AH-02 Evaluación de sistemas LLM y RAG, con mandato formal/matemático (consulta dirigida)
date: 2026-10-28
traces: [BIT-16-C1-07 §3.3, BIT-16-C1-01 tabla C (PC-10), C1-25, C1-26, C1-41, C1-43, C1-49, P-24, BIT-16-00 R-LLM, CAT-FO-02, AH-02--04, AH-02--05]
evidencia: evidencia-AH-02-formal/
---

# Consulta dirigida a AH-02: PC-10 y la regla R-LLM operativa

**Mandato** (dictamen BIT-16-C1-07 §3.3): resolver PC-10 antes de que vote la segunda ronda. La pregunta es si las corridas con semillas 1..N del mismo pedido a T 0,7 cuentan como ensayos independientes para R-LLM o si hay que variar el pedido. Con esa respuesta se fija la regla R-LLM operativa para la redacción: N mínimo, intervalo y forma de reportar k/n.

**Ítems que toca:** C1-25 (P-24), C1-43 y C1-49 (MI-01, EA-6), C1-41 (MI-02, AD-S1), C1-26 (`ConModelo/`) y la referencia «2/10» de MI-24.

---

## 1. PC-10: ¿las semillas 1..N de un mismo pedido son ensayos independientes?

### Respuesta

**Son independientes para estimar la tasa *de ese pedido*. No lo son para estimar la tasa *de la tarea*.** La pregunta mezcla dos estimandos, y para cada uno la respuesta es distinta:

1. **Estimando «este pedido»** (p(éxito | pedido x, modelo@digest, opciones)). Cada semilla distinta es un sorteo de la misma distribución condicional. Medimos que la semilla determina la salida por completo: la misma semilla reproduce byte a byte la misma respuesta, también desde otro cliente y en otro momento. Tampoco detectamos que el valor de la semilla (consecutivas o lejanas) cambie la tasa. Con semillas distintas, k/n es un binomial y Wilson vale **para ese pedido**. Hay que tener en cuenta que **repetir una semilla no es un ensayo nuevo**: es una reproducción.
2. **Estimando «la tarea»** («el 4b elige bien la herramienta de requisitos»). La unidad de muestreo es el **pedido**, y las semillas de un mismo pedido forman un conglomerado: comparten la media condicional del pedido. Medimos heterogeneidad real entre pedidos (p = 0,018), con una ICC de 0,29 y un efecto de diseño de 3,0. Las 48 corridas valen como unas **16 independientes**, y las semillas de un pedido no dicen nada de otro: P0 dio 5/8 y los otros cinco pedidos, 8/8. Para afirmar algo sobre la tarea **hay que variar el pedido**.

Las cifras que hoy sostienen decisiones (EA-6 [R4], X2 D1/D6, AD-S1 «bici»/«a pie», Sondeo §R.4) son todas tasas **de un pedido**. Se pueden reportar así, pero no se leen como tasas de la tarea ni del modelo.

### Evidencia

**E4, fuentes externas (consultadas el 2026-10-28):**

- Miller, E. *Adding Error Bars to Evals: A Statistical Approach to Language Model Evaluations*. arXiv:2411.00640v1, 1 nov 2024, <https://arxiv.org/html/2411.00640v1>. En §2.2: «Because the inclusion of questions is non-independent, a key assumption of the Central Limit Theorem (or a bootstrap) is violated, and so a naive application of Equation 1 will yield inconsistent standard errors.» En §3 la varianza se descompone en «the variance of the conditional mean […] associated with choosing questions from the super-population» y «the mean conditional variance». En §3.1, `Var(s_i) = σ_i²/K` para K respuestas por pregunta, y se advierte que «multiple answers to the same question would violate the assumption of independent draws» si se las junta en un solo error estándar. Volver a muestrear respuestas achica sólo el segundo término de la varianza, nunca el primero.
- Bowyer, S.; Aitchison, L.; Ivanova, D. R. *Position: Don't Use the CLT in LLM Evals With Fewer Than a Few Hundred Datapoints*. arXiv:2503.01747v3, 28 may 2025 (ICML 2025), <https://arxiv.org/html/2503.01747v3>. En §3.1: «We would, therefore, recommend using WS or Bayesian intervals in practice» (WS = Wilson score); Clopper-Pearson les resulta demasiado conservador. En §3.2, Fig. 3: «neither simple CLT nor clustered CLT intervals produce correct coverage» con N chico y datos agrupados. Recomiendan un beta-binomial bayesiano por conglomerado. En §3.4, para comparaciones pareadas, recomiendan el método bayesiano pareado.
- Ollama, *Modelfile reference*, parámetro `seed`, <https://docs.ollama.com/modelfile> (2026-10-28): «Setting this to a specific number will make the model generate the same text for the same prompt.» Busqué en el código de Ollama v0.40.11 cómo se siembra el muestreador y no lo encontré. Por eso el comportamiento se sostiene con el experimento de abajo y no con el código.
- He, H. (Thinking Machines). *Defeating Nondeterminism in LLM Inference*, 10 sep 2025, <https://thinkingmachines.ai/blog/defeating-nondeterminism-in-llm-inference/>. La salida de un servidor con lotes puede depender de la carga, porque los kernels no son invariantes al tamaño del lote. Es una advertencia: en otro servidor o con concurrencia mayor a 1, la reproducibilidad por semilla puede romperse. Eso no afecta la independencia, pero sí el uso de «misma semilla» como emparejamiento.

**E1, sonda R-LLM** (`evidencia-AH-02-formal/`, 2026-10-28 15:05–15:30 UTC, turno `<recurso-compartido>` dueño `ah02-pc10`, rc=0). Ollama propio en contenedor (estación 1), Ollama 0.40.11, `qwen3.5:4b@d8b0f5e9760c…`, `/api/chat`, T 0,7, `num_predict` 300, `think:false`. Sistema y herramientas iguales a EA-6 [R4] (`buscar_requisitos`, `contar_localidades_por_provincia`). El criterio, escrito antes de correr, es el de EA-6: OK si hay exactamente una llamada y es a `buscar_requisitos`. P0 es la pregunta de EA-6; P1–P5 son otras cinco preguntas de requisitos.

| Bloque | Diseño | Resultado (`salida-analisis-pc10.txt`) |
|---|---|---|
| A | 6 pedidos × semillas 1..8, en orden intercalado por semilla | P0 `01101011` 5/8, Wilson [0,31; 0,86]. P1–P5: 8/8 cada uno, Wilson [0,68; 1,00]. Agregado 45/48 |
| A, conglomerado | ICC de ANOVA; efecto de diseño 1+(m−1)·ICC | **ICC = 0,286; efecto de diseño 3,00; n efectivo ≈ 16 de 48** |
| A, homogeneidad | χ² entre pedidos, p por permutación (20 000) | χ² = 16,0 (gl 5), **p = 0,018**: los pedidos difieren |
| A, intervalos | Wilson ingenuo sobre 48 frente a bootstrap que remuestrea pedidos | [0,83; 0,98] frente a [0,81; 1,00] (con K = 6 el bootstrap también es frágil, según Bowyer §3.2) |
| A, efecto de la semilla | Cochran Q con los pedidos como bloques, p por permutación | Q = 7,0 (gl 7), p = 1,00: no se detecta que una semilla arrastre el mismo resultado en todos los pedidos. Prueba de poca potencia: las 3 fallas están todas en P0 |
| B | P0 × semillas 1001..1008 | 7/8. Frente a 5/8 con 1..8, Fisher exacto p = 0,57: **no se detecta efecto** del valor de la semilla (potencia baja) |
| C | P0 × semillas 1, 2, 3 repetidas | **3/3 idénticas** en llamadas y texto a las del bloque A, aunque la caché de prefijo estaba en otro estado (la semilla 1 corrió en frío en A) |
| Réplica de EA-6 | P0, semillas 1..5, con otro cliente (Python contra `/api/chat`; EA-6 usó MEAI 10.11.0 + OllamaSharp 5.5.0) | Mismo patrón FALLA-OK-OK-FALLA-OK que EA-6 [R4] l. 25–29. Mismos argumentos, incluida la semilla 3 sin «¿». La semilla 1 da el mismo texto que EA-6 [R5] («Como soy un modelo de lenguaje y no tengo acceso directo…»). **La semilla fija la salida con independencia del cliente** |

**Lectura formal.** Dado el pedido y la semilla, la salida es una función determinista. Las semillas distintas actúan como sorteos de p(y | x): no se detecta efecto del valor ni del orden. Entre pedidos, en cambio, la tasa cambia (P0 es el único que falla), así que las semillas de un pedido no son ensayos de otro pedido.

**Límites de la sonda.** Hay un solo modelo y una sola tarea. K = 6 y m = 8 son chicos: la ICC es ilustrativa y no se le calcula intervalo. Las pruebas de «no efecto» de la semilla tienen potencia baja, así que dicen «no detectado», no «ausente». La reproducibilidad vale para este servidor con concurrencia 1. Nada de esto es una cifra de fiabilidad del 4b.

### Consecuencia para los ítems del jurado

- **C1-25 / P-24.** El rótulo provisorio «N semillas de un mismo pedido» pasa a ser **definitivo y obligatorio**. Toda tasa declara su estimando (§2, R-LLM-1). La regla «con N ≤ 10 sólo existencia» de P-24 se mantiene **para afirmaciones verbales**. El k/n con su intervalo se puede mostrar siempre, porque R-LLM pide «tasas observadas», pero sin adjetivos ni comparaciones (§2, R-LLM-3c).
- **C1-43 / C1-49 (MI-01, EA-6).** EA-6 [R4] queda **replicado y ampliado**: P0 da 12/16 con 16 semillas distintas (Wilson [0,51; 0,90]), y **los otros cinco pedidos de requisitos dan 40/40** (Wilson [0,91; 1,00]). «B omite la herramienta» existe, pero **depende del pedido**: pasó en 1 de 6 preguntas de requisitos, y en la tarea los pedidos que pasan siempre son 5/6, Wilson [0,44; 0,97]. Esto refuerza la posición B de C1-43: «A por defecto» se sostiene **por diseño** (EA-5) y no por la tasa de EA-6. La tensión 1 no puede decir «B omite recuperar 2/5» como rasgo de la vía. Debe decir «con el 4b, en una de seis preguntas de requisitos, B a veces contesta sin buscar (12/16 corridas buscaron)».
- **C1-41 (MI-02, AD-S1).** Los 10/10 del 2b y del 4b son tasas de **dos pedidos** («bici», «a pie») con las mismas semillas. No hay ningún par discordante, así que la comparación pareada no separa a los modelos (R-LLM-3e). Esto confirma que la evidencia respalda «la familia qwen3.5 con *tools*» y no «el 4b».
- **MI-24 («falso aceptado 2/10») y X2 D1/D6.** Son tasas **del pedido D1** y **del pedido D6**. No fijan un umbral de la tarea (R-LLM-3d). D6 «borra sin confirmar 10/10» es una existencia que justifica el control. La garantía se prueba como invariante (R-LLM-3b).
- **C1-26 (`ConModelo/`).** Los tres tipos de aserción de AH-02--05 se definen con R-LLM-3: invariante (falla ante una violación), tasa informada (k/n con su estimando) y «no medido» (`Inconclusive`). Además, repetir la corrida **con las mismas semillas** no aporta evidencia nueva: es una prueba de reproducibilidad, no un ensayo más.
- **Comparaciones «mismas semillas» (P-24 (2)).** Usar las mismas semillas sirve para reproducir, no para emparejar. Con otro pedido o con otra vía (otro prompt), la misma semilla no acopla los resultados de forma conocida: el Cochran Q no detectó acople. **Lo que empareja es el pedido.** La regla queda así: «mismos pedidos y mismo m; semillas declaradas (pueden ser las mismas, por reproducibilidad)».

> **2026-10-28 — Parche P2-13 (ciclo 1, ronda 2).** Al citar la viñeta C1-43 / C1-49, «40/40 (Wilson [0,91; 1,00])» se lee «8/8 en cada uno de los otros cinco pedidos (este pedido)» y «5/6, Wilson [0,44; 0,97]» se lee «omisión observada en 1 de 6 pedidos (existencia); K = 6 no alcanza para una tasa de la tarea» (R-LLM-3d; posición del juez de impacto). Texto en BIT-16-04 §1 (EA-6).


---

## 2. Regla R-LLM operativa para la redacción

Esta regla desarrolla la restricción dura R-LLM de BIT-16-00 (modelo + digest + parámetros + entrada exacta + salida + fecha; aserciones sobre forma y propiedades; tasas observadas). **Los umbrales numéricos (m ≥ 10, K ≥ 10, ≥ 6 discordantes) son criterio de método de AH-02:** convenciones elegidas por su consecuencia (columna «por qué»), no hechos medidos. El jurado puede votarlos como opción.

**R-LLM-1 — Estimando declarado.** Toda cifra contra el modelo dice si habla de **«este pedido»** (la unidad es la semilla) o de **«la tarea»** (la unidad es el pedido). Si no lo dice, se entiende «este pedido».

**R-LLM-2 — Semillas.** Cada corrida usa una semilla distinta y declarada (1..m por defecto; el valor no importa, §1 bloque B). La misma semilla con el mismo pedido es reproducción, no ensayo: no suma a n. Las semillas de un pedido no son ensayos de otro.

**R-LLM-3 — Qué se puede afirmar y con qué N.**

| Tipo de afirmación | N mínimo | Cómo se enuncia | Por qué |
|---|---|---|---|
| a) **Existencia** («el 4b a veces no llama a la herramienta») | n ≥ 1, con la salida cruda | «se observó en k de n corridas (…)» | Una observación basta para la existencia y no necesita intervalo |
| b) **Invariante o garantía** (ninguna escritura sin aprobación, ningún valor fuera de catálogo persistido) | No es una tasa | Se prueba de forma determinista en `Cableado/`. En `ConModelo/` es una aserción que **falla ante una sola violación**. Si se quiere una cota: con 0 en n, cota superior 95 % = 1 − 0,05^(1/n) (n = 10 → 0,26; 30 → 0,10; 59 → 0,05) | Con N chico una tasa no acota un riesgo de seguridad (AH-02--04) |
| c) **Tasa de un pedido** | m ≥ 10 semillas | «k/m, Wilson 95 % [a; b]», sin adjetivos («casi siempre», «confiable») | Con 10/10 Wilson da [0,72; 1,00]; con menos, el intervalo no excluye ni 0,6. Coincide con el N = 10 de §R.4, X2 y AD-S1. Wilson por Bowyer §3.1 |
| d) **Tasa de la tarea** | K ≥ 10 pedidos distintos, redactados y guardados antes de correr; m ≥ 3 semillas por pedido | Tabla por pedido (k/m) más «pedidos que pasan en m/m: j/K, Wilson 95 %». Si se da la media de las tasas por pedido, el intervalo se calcula sobre los K pedidos, **nunca Wilson sobre K·m** | La varianza entre pedidos domina (ICC 0,29, efecto de diseño 3 en §1). Más semillas sólo achican la varianza dentro del pedido (Miller §3.1) |
| e) **Comparación** (vías, modelos, opciones) | Mismos pedidos, mismo m, pareada | Sólo se dice «A difiere de B» si la prueba exacta pareada (signo/McNemar) da p < 0,05 bilateral sobre los pares discordantes: **≥ 6 discordantes, todos en el mismo sentido** (2·0,5⁶ = 0,031). Si no, «no separado con este N». Con estimando de tarea, el par es el pedido (la tasa de A frente a la de B en cada pedido) | Bowyer §3.4 recomienda pareado. Con 5 discordantes, p = 0,0625: no alcanza |

**R-LLM-4 — Formato del reporte** (cabecera de toda salida y de toda cifra en la guía):

> `k/n — <estimando: este pedido | tarea>, K pedidos × m semillas (s = 1..m), <modelo>@<digest 12>, T <t>, think <on/off>, <ruta API>, <criterio escrito antes>, <fecha>; Wilson 95 % [a; b]; crudo: <archivo>`

En la guía, la cifra lleva además el rótulo de RV-01 («medido en la estación de laboratorio…»). Con estimando de tarea va también la tabla por pedido o su archivo. **No se usa el intervalo normal (CLT)** con estos N (Bowyer, título y §3).

**R-LLM-5 — Presupuesto.** En esta sonda el 4b tardó una mediana de 27 s por llamada a herramienta (máx. 68 s; 59 llamadas en 25,4 min), con los mismos límites de contenedor de §R.6. Un turno de 45 min alcanza para unas 90 llamadas: entra una tasa de tarea mínima (K = 10 × m = 5 = 50) o cuatro tasas de pedido de m = 10. Lo que no entra en el turno se rotula «no medido» y se planifica en estación 2 (dictamen §4).

### Consecuencia para los ítems del jurado

- Reemplaza la frase de P-24 (2) «hasta que se responda, cada tasa dice "N semillas de un mismo pedido"» por R-LLM-1…R-LLM-4.
- El plan de redacción (06-Plan §7, fila R-LLM, compuerta `grep -L "modelo@"`) puede sumar una compuerta mecánica: toda cabecera R-LLM contiene `estimando:` y `semillas`.
- MI-08, MI-16 y P-05 (conjunto de oro, juez): sus métricas son tasas de la tarea sobre K preguntas. Les rige R-LLM-3d y 3e (pareado por pregunta), y el acuerdo del juez se reporta como k/n con intervalo, no como compuerta (coherente con MI-16 de AH-02).
- Nada de esta consulta escribe en la guía. La redacción lo toma en la sección de pruebas (N5) y en el Anexo E.
