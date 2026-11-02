<a id="anexo-g"></a>
## Anexo G · Lecturas para seguir

La guía termina donde termina lo que se ejecutó sobre Movilidad Urbana desde la capa de aplicación. Tres temas quedaron afuera a propósito: las cachés KV del servidor de inferencia, que siguen a [§6](#s6); el gobierno de IA responsable completo, que sigue a [§2.4](#s2-4); y la orquestación de varios agentes en el escalón 3, que sigue a [§8.7](#s8-7). Para cada lectura se dice qué trae, por qué no entró y qué tendría que cambiar para que entre. Nada de esto se ejecutó en el laboratorio; las referencias completas están en el [Anexo D](#anexo-d).

<a id="anexo-g-1"></a>
### G.1 Cachés KV en el servidor de inferencia

[§6.3](#s6-3) separó el contexto completo con prefijo estable, que la aplicación controla con el texto que manda, del CAG del artículo, que guarda la caché KV del corpus en el proceso del modelo [REF-67]; por `IChatClient` esa caché no se ve ([§6.4](#s6-4)). Los cuatro trabajos siguientes parten de ella: tres la precalculan, la entrenan o la gestionan, y el cuarto extiende el CAG que la usa. Criterio de la guía: son técnicas del servidor de inferencia o del modelo, y con un servidor por HTTP, como Ollama en esta guía, la aplicación no puede activarlas.

| Trabajo | Qué propone | Por qué no entró | Sigue a |
|---|---|---|---|
| Cartridges [REF-78] | La memoria de la caché KV «scales with input length», crece con la entrada; propone entrenar fuera de línea una caché KV más chica por corpus y cargarla al responder [REF-78] | pide entrenar, y la guía trabaja sobre modelos ya entrenados ([§7.7](#s7-7)) | [§6.3](#s6-3), [§6.5](#s6-5) |
| TurboRAG [REF-82] | Precalcula y guarda las cachés KV de los documentos y las recupera al consultar; ajusta un modelo preentrenado para conservar la precisión [REF-82] | pide ajustar el modelo y guardar cachés que la aplicación no ve | [§7](#s7) |
| Cache-Craft [REF-83] | En RAG, decide qué cachés KV de fragmentos se reutilizan, recalcula una parte para no degradar la salida y las guarda y desaloja en el hardware [REF-83] | es gestión de memoria del servidor | [§6.4](#s6-4), [§7](#s7) |
| ACC [REF-79] | Escalar CAG a bases «large and dynamic», grandes y cambiantes, sigue abierto; propone comprimir el contexto en forma adaptativa y un híbrido CAG-RAG con recuperación selectiva [REF-79] | se apoya en el CAG del artículo | [§6.6](#s6-6) |

El híbrido de ACC es la combinación de escalones que [§6.6](#s6-6) ya anticipa [REF-67]. Las cifras de estos trabajos son de sus autores. Criterio de la guía: entran cuando el servidor de modelos exponga esa caché por API y el adaptador la lleve al contrato; hasta entonces, la aplicación decide lo de [§6](#s6): qué texto manda, en qué orden y contra qué ventana efectiva.

<a id="anexo-g-2"></a>
### G.2 Gobierno de IA responsable

[§2.4](#s2-4) tomó de dos marcos sólo lo que cambia una decisión de la capa: el éxito definido antes de construir, con métricas, tipos de error y criterio de liberación [REF-04], y la decisión de seguir [REF-05]. Quedan afuera las evaluaciones de impacto, las responsabilidades dentro de la organización y la gestión de riesgos durante toda la vida del sistema. Criterio de la guía: los actores de esta guía deciden sobre la capa ([§2.3](#s2-3)), no sobre la política de la organización.

| Lectura | Qué trae que la guía no desarrolla | Qué tomó la guía |
|---|---|---|
| Microsoft, *Responsible AI Standard*, v2 [REF-04] | Metas de responsabilidad, transparencia, equidad, confiabilidad y seguridad, privacidad y seguridad, e inclusión; la primera, «Microsoft AI systems are assessed using Impact Assessments», es evaluar cada sistema con una evaluación de impacto [REF-04] | la meta de adecuación al propósito (*fit for purpose*): métricas, tipos de error y criterio de liberación ([§2.4](#s2-4)); procesos para informar fallas ([§12.9](#s12-9)) |
| NIST, *AI RMF 1.0* [REF-05] | Un núcleo con GOVERN, MAP, MEASURE y MANAGE, donde GOVERN es «a cross-cutting function», transversal a las otras tres [REF-05] | costo del error y decisión de seguir ([§2.4](#s2-4)) |
| NIST, *Generative AI Profile* [REF-06] | Los riesgos «unique to or exacerbated by» la IA generativa, propios o agravados por ella, con acciones sugeridas para cada uno [REF-06] | la definición de alucinación (*confabulation*, en NIST), en el [Anexo C](#anexo-c) |
| Amershi y otros [REF-01] | Las 18 pautas de interacción entre personas e IA, para el diseño detallado de la experiencia | las del momento del error ([§2.5](#s2-5)) |

Criterio de la guía: en CTX-PROD con CTX-SENS, como la encuesta que guarda `Nombre` y `Edad` ([§11.4](#s11-4)), la organización elige su marco, y la capa le aporta piezas que ya tiene: la métrica y el error caro de cada escenario, la ficha de riesgo ([Anexo A](#anexo-a-11)), el registro de decisiones ([§13](#s13)) y el conjunto de oro ([§10.7](#s10-7)).

<a id="anexo-g-3"></a>
### G.3 Orquestación de varios agentes en el escalón 3

La guía trata el escalón 3 en forma conceptual ([§8.7](#s8-7)) porque ningún pedido del caso lo necesita: el ejemplo 12 fija el camino en el código y sólo cambia cuántos agentes hay ([§8.8](#s8-8)), no hay ADR del escalón 3 ([§13.15](#s13-15)) y las tareas de varios pasos quedan sin medir ([§14.6](#s14-6)).

- **Orquestaciones de MAF.** La documentación enumera «sequential, concurrent, handoff, group-chat, and Magentic patterns for coordinating agents», los patrones para coordinar agentes [REF-129], y el anuncio de la versión 1.0 los da como estables, con checkpoints, aprobación humana y pausa para procesos largos [REF-43]. Que en *handoff* y Magentic un modelo elija al siguiente agente es criterio de la guía ([§8.8](#s8-8)), no de la fuente.
- **El patrón y su costo.** En orquestador-trabajadores, «a central LLM dynamically breaks down tasks, delegates them to worker LLMs, and synthesizes their results»: un modelo central reparte la tarea y junta los resultados [REF-115]. Para los agentes autónomos, la misma fuente advierte más costo y errores que se acumulan, y pide «extensive testing in sandboxed environments», probar en entornos aislados, con guardas [REF-115].
- **Riesgos.** Además de los tres que usa [§11.1](#s11-1), la lista de OWASP para aplicaciones agénticas nombra ASI07 *Insecure Inter-Agent Communication*, ASI08 *Cascading Failures* y ASI10 *Rogue Agents* [REF-164]. Criterio de la guía: pesan con varios agentes; la guía no desarrolla su contenido.

Criterio de la guía: antes de llevar un pedido de Movilidad Urbana al escalón 3 hacen falta el criterio de salto escrito ([§8.1](#s8-1)); las métricas deterministas de 12 sobre los mismos pedidos, contra un solo agente ([§8.8](#s8-8)); el tope de iteraciones y de errores seguidos ([§8.2](#s8-2)); y toda escritura aprobable, con el pedido armado por el código, también cuando un agente le pasa la tarea a otro ([Anexo B](#anexo-b-herramientas)). Con eso se reabre ADR-07 ([§13.8](#s13-8)).

<!-- PENDIENTES:
Quitado por falta de respaldo citable o por la regla de cifras:
- Cifras de los trabajos de G.1 (Cartridges: «38.6x less memory», «26.4x higher throughput»; TurboRAG: TTFT «up to 9.4x»; Cache-Craft: 51 %, 75 %, 1.6X, 2X): son de sus autores y no están en la tabla de cifras citables; no entran. La prosa dice «las cifras de estos trabajos son de sus autores».
- REF-81 (economía de guardar y reutilizar cachés KV, arXiv 2503.14647): vecino de G.1 en el dossier N3b, pero el plan nombra sólo cuatro trabajos; no se agregó (desvío evitado).
- Que TurboRAG «no requiera modificar el servidor de inferencia» (el resumen dice «without any requirement in modification of models and inference systems» y a la vez que ajusta un modelo preentrenado): contradictorio en la misma fuente; la tabla dice sólo lo que hace y el ajuste.
- Paquete A2A de MAF y su estado: no está en 00-Versiones (Anexo F) y la guía no usa A2A; se quitó la mención («A2A 1.0 support coming soon», REF-43, 2026-04-03) para no dar un estado sin fila.
- API de las orquestaciones (CreateHandoffBuilderWith, CreateMagenticBuilderWith, AgentWorkflowBuilder): sólo la respalda la reflexión del dossier N4 (E01), sin REF ni archivo del repositorio; no se nombran.
- Ejecución distribuida o durable de workflows: no verificada en N4; no entra.
- Meta T3 del Standard (informar que se interactúa con IA): el cuerpo no la usa; no se agregó.
- Contenido de ASI07, ASI08 y ASI10 más allá del nombre: el dossier N5 sólo verificó los nombres contra el PDF (como §11).
Fuentes dadas de alta: ninguna. Verificaciones hechas por esta redacción el 2026-10-27, con curl, sin alta nueva:
- API de arXiv (export.arxiv.org/api/query) sobre REF-67, REF-78, REF-79, REF-82, REF-83 (y REF-81): títulos, primer autor y resúmenes. Títulos para completar el Anexo D (las entradas dicen «sin título registrado»): REF-78 «Cartridges: Lightweight and general-purpose long context representations via self-study» (Eyuboglu et al., 2025-06-06); REF-79 «Enhancing Cache-Augmented Generation (CAG) with Adaptive Contextual Compression for Scalable Knowledge Integration» (Agrawal, Kumar, 2025-05-13); REF-82 «TurboRAG: Accelerating Retrieval-Augmented Generation with Precomputed KV Caches for Chunked Text» (Lu et al., 2024-10-10); REF-83 «Cache-Craft: Managing Chunk-Caches for Efficient Retrieval-Augmented Generation» (Agarwal et al., 2025-02-05); REF-67 «Don't Do RAG: When Cache-Augmented Generation is All You Need for Knowledge Tasks» (Chan et al.). Citas textuales de la tabla de G.1 tomadas de esos resúmenes. No se editó 00-Referencias.md: queda para quien edita el Anexo D.
- PDF de REF-04 (pdftotext): grupos «Accountability / Transparency / Fairness / Reliability & Safety / Privacy & Security / Inclusiveness Goals»; «Goal A1: Impact assessment» y «Microsoft AI systems are assessed using Impact Assessments».
- PDF de REF-05: «the Core is composed of four functions: GOVERN, MAP, MEASURE, and MANAGE»; «GOVERN is a cross-cutting function…».
- PDF de REF-06: «risks that are novel to or exacerbated by the use of GAI» / «risks unique to or exacerbated by the development and use of GAI»; «suggested actions».
- Página de REF-129 (ms.date 2026-07-29): la frase de las orquestaciones, textual.
- Página de REF-43: «Stable support for the orchestration patterns that emerged from Microsoft Research and AutoGen: sequential, concurrent, handoff, group chat, and Magentic-One. All patterns support streaming, checkpointing, human-in-the-loop approvals, and pause/resume for long-running workflows».
- Página de REF-115: la frase de orquestador-trabajadores y «The autonomous nature of agents means higher costs, and the potential for compounding errors. We recommend extensive testing in sandboxed environments, along with the appropriate guardrails».
Verificación adversarial 2026-10-27: confirmados contra arXiv (resúmenes de REF-78/79/82/83), REF-43, REF-115 y REF-129 por curl, y N0b B04 (Goal A3). Correcciones: G.1 ya no dice que ACC «opera sobre» la caché KV (su resumen habla de comprimir el contexto); la fila de REF-04 nombra la meta A3; «12» pasa a «el ejemplo 12».
Desvíos de la ficha y criterios propios:
- El plan da para G sólo la lista de temas (Cartridges, TurboRAG, Cache-Craft, ACC; gobierno de IA responsable completo; multiagente del escalón 3, handoff, Magentic), sin subsecciones, escenarios, preguntas guía, diagramas ni ejemplos. Se usaron tres subsecciones, una por tema, con anclas anexo-g-1 … anexo-g-3 (criterio de esta redacción, como anexo-e-N); títulos «G.n» sin «§» para no disparar la compuerta de remisiones al plan.
- Sin snippets, salidas, mermaid ni preguntas guía: no hay código de la guía que ejecute estas lecturas; el límite del escalón 2 ya lo muestra §8.8 con 12 (comentario de Examples/12-Uno-O-Varios-Agentes/Application/Workflows/CaminoDelResumen.cs, «En ningún punto un modelo elige el paso siguiente: eso sería el escalón 3 (handoff, Magentic), que la guía deja sin ejemplo»), y no se repite.
- G.2 suma la fila de Amershi y otros (REF-01): el dossier N0b deja fuera, junto con el gobierno completo, el «diseño UX detallado» y dice que esas fuentes se citan como lectura ampliada.
- G.3 suma REF-164 (ASI07, ASI08, ASI10) como lectura de riesgos con varios agentes; la asignación es criterio de la guía.
- La lista final de G.3 es criterio de la guía armado con piezas del cuerpo (§8.1, §8.2, §8.5/B.5, §8.8, §13.8); no agrega controles nuevos.
Procedencia de las salidas: ninguna salida de modelo.
Conteo de palabras de prosa (comando de la carta §16.3): 1.015 (buena parte en celdas de tabla y citas literales). Tope: el plan no reparte los 7.430 de Anexos; A 2.261, B 1.515 y E 1.675 suman 5.451 y dejan 1.979 para C, D, F (tablas de F fuera del conteo) y G. Si la relectura recorta: la oración final de G.1, la fila de Amershi y la lista final de G.3.
Snippets por encima del tope: ninguno.
Marcas «criterio de la guía»: 7 (≤ 8).
Remisiones usadas: s2-3, s2-4, s2-5, s6, s6-3, s6-4, s6-5, s6-6, s7, s7-7, s8-1, s8-2, s8-7, s8-8, s10-7, s11-1, s11-4, s12-9, s13, s13-8, s13-15, s14-6, anexo-a-11, anexo-b-herramientas, anexo-c, anexo-d. Todavía no existen en secciones/: anexo-c y anexo-d (previstas en la carta §13).
REF citados: REF-01, REF-04, REF-05, REF-06, REF-43, REF-67, REF-78, REF-79, REF-82, REF-83, REF-115, REF-129, REF-164.
Cifras citadas: ninguna medición. «18 pautas» es cifra de fuente (REF-01), ya usada en §2.5.
Compuertas corridas sobre la sección sin este comentario: remisiones al plan 0; familias de ID 0; voseo 0; IPs, rutas y puertos 0; alias: «LLM» sólo dentro de una cita literal en inglés. AC-7/AC-8 sin correr (las corre la integración).
-->
