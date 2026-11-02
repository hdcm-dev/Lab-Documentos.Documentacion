---
doc_id: BIT-16-MESA-C2-02-DID
doc_type: informe-de-especialista
title: Ciclo 2 · Informe de didáctica
version: v1
status: para la consolidación
origin: agent (especialista en didáctica, pedido del PO)
last_review: 2026-10-26
traces: [BIT-16-04 v1, BIT-16-MESA-C1-02-DID, BIT-16-MESA-C1-07 (AJ-05), M§8]
---

# Ciclo 2 · Didáctica

**Objeto**: `../../../04-Plan-De-Integracion.md`, ESTRUCTURA APROBADA v1. Las líneas citadas (l. n) son de ese archivo.
**Mandato**: recorrido, OA observables y su alineación con §15 y con las preguntas guía (ratificar la asignación de OA que hizo la secretaría), carga cognitiva, prerrequisitos, orden de los 17 ejemplos.
**A ciegas**: no leí ningún otro informe del ciclo 2. Leí el ciclo 1 (mi informe, `07-Aplicacion-Y-Verificacion.md` y `08-Cierre.md`) para no repetir H-DID-01…07, ya corregidos.

**Nota sobre el despacho.** El despacho llama AJ-08 a «los OA asignados a las preguntas guía». En `../Ciclo-1/07-Aplicacion-Y-Verificacion.md` §2 esa asignación es **AJ-05**; AJ-08 es la fila S-12 de BIT-16-02 (`01-Convocatoria.md`), que no es de mi mandato. El plan coincide con el 07: cada línea de preguntas reasignadas dice «AJ-05; los revalida didáctica» (l. 382, 391, 412, 472, 490, 501). Reviso AJ-05. Mi posición sobre su ratificación: **ratificar con cambios** (H-DID2-01). De las 21 preguntas que reasignó AJ-05, 8 quedan mal atadas.

## 1. Hallazgos

### H-DID2-01 · AJ-05: 8 de las 21 preguntas reasignadas quedan atadas a un OA que no ejercitan, y hay dos duplicados entre secciones

```json
{
  "id": "H-DID2-01",
  "especialista": "didáctica",
  "capa_origen": "plan",
  "ubicación": "§C, líneas «Preguntas guía» de §1 (l. 382), §2 (l. 391), §4 (l. 412), §12 (l. 490); §6 (l. 432) frente a §7 (l. 441)",
  "afirmación": "La asignación de OA que hizo AJ-05 ata 8 de 21 preguntas a un OA cuya conducta la pregunta no ejercita, y deja la decisión local o nube preguntada dos veces con el mismo OA, contra la regla «cada pregunta vive en un solo lugar» (l. 347).",
  "evidencia": { "nivel": "E2", "ancla": "Desajustes (pregunta → OA asignado → texto del OA en §A.3): (1) §1 «¿En qué se distingue una capa de IA de "llamar a una API de IA"?» → OA-0.2, que es «Ubicar cada pieza de la imagen… en Presentación, Application, Domain o Infrastructure» (l. 104); la pregunta es la tesis, no la ubicación. (2) §2 «¿Cómo diseño una pantalla para una respuesta que puede estar mal?» → OA-A2, «Fijar… la métrica, los tipos de error y el umbral» (l. 116); la pregunta es de diseño de interacción (§2.5, pautas B01). (3) §2 «¿Qué cambia si el modelo es local o en la nube?» → OA-O4, cuyo § es §12.4 (l. 122), y §12 repite la decisión: «¿Ollama, Foundry Local o la nube?» (OA-O4; l. 490), aunque §2 se declara «casa única» (l. 391) y §14 remite a §2 (l. 510). (4) §4 «¿Qué cambió el diseño de aplicaciones: el tamaño del modelo o el uso de herramientas?» → OA-0.1, «decidir si hace falta un modelo» (l. 103); es una pregunta histórica que no cambia esa decisión (regla H-038, l. 347). (5) §4 «`IChatClient` ya es una abstracción: ¿hace falta otra interfaz encima?» → OA-D1, «Consumir… y cambiar de adaptador» (l. 106); la pregunta es la decisión puerto propio frente a IChatClient (§4.4), que ningún OA formula (ver H-DID2-02). (6) §12 «¿La caché de respuestas me ahorra siempre?» → OA-O4 (local, compartido o nube, §12.4); la caché es §12.3. (7) §12 «¿Qué cambia del prototipo a producción?» → OA-O2, «Configurar endpoint, modelo, num_ctx y timeouts por variable» (l. 120); la pregunta es §12.8. (8) §12 «¿Por qué mi modelo local tarda minutos?» → OA-O2; es latencia y cola (Sondeo §0), no configuración. Duplicado adicional: §6 «Si mi corpus entra en la ventana, ¿tengo que hacer RAG igual?» (OA-D3, l. 432) y §7 «¿Cuándo conviene RAG y cuándo no?» (OA-A3, l. 441) piden la misma decisión. Las otras 13 asignaciones de AJ-05 (p. ej. §13 → OA-A1; §10 «¿Puedo usar un LLM para evaluar a otro?» → OA-O3) son correctas." },
  "severidad": "S2",
  "confianza": 0.75,
  "impacto_si_no_se_corrige": "§15 se arma con un ítem por OA a partir de las preguntas guía (l. 517): un OA con preguntas que no lo ejercitan llega a la autoevaluación con un ítem que no verifica lo que promete, y el criterio de inclusión de l. 129 se cumple sólo en la forma.",
  "propuesta_de_dirección": "Ratificar AJ-05 con cambios: que cada pregunta quede atada a un OA cuya conducta la respuesta efectivamente ejercita (si ninguno existe, que se cree el OA o se saque la pregunta), y que la decisión local o nube y la de «RAG sí o no» vivan en una sola sección, con remisión desde la otra."
}
```

### H-DID2-02 · El criterio de inclusión se verificó en un solo sentido: hay secciones sin OA, entre ellas la decisión central de la tesis

```json
{
  "id": "H-DID2-02",
  "especialista": "didáctica",
  "capa_origen": "plan",
  "ubicación": "§A.3 (tabla OA, l. 101–127; criterio de inclusión, l. 129); §A.1 (tesis, l. 46); §C §4 (l. 407, 411), §10 (l. 468), §11 (l. 477), §12 (l. 486)",
  "afirmación": "El chequeo del ciclo 1 comprobó «todo OA tiene ruta» (OA → sección), pero el criterio dice lo inverso, «ninguna sección… entra sin un OA», y ese sentido no se corrió: al menos once subsecciones no figuran en la columna «§» de ningún OA, incluida §4.4, que enseña la decisión central de la tesis.",
  "evidencia": { "nivel": "E2", "ancla": "l. 129: «ninguna sección, ejemplo o pregunta guía entra sin un OA de esta tabla». 07-Aplicacion-Y-Verificacion §4: «Todo OA tiene ruta de lectura que pasa por su sección | Pasa: 0 faltantes en 25 OA | script de cobertura OA → §0.2» (sólo ese sentido). Subsecciones de §C que no aparecen en la columna «§» de ningún OA (l. 103–127): §2.5 (diseñar para respuestas que pueden estar mal), §4.1 (por qué ahora), §4.4 (dos niveles de contrato: puerto propio e IChatClient), §4.5 (antipatrones de ubicación), §10.1, §10.7 (conjunto de oro, casa única), §11.2 (inyección), §11.5 (MCP sin control de acceso), §11.6 (secretos), §12.3 (costo y latencia), §12.6–§12.9 (contenedor, Aspire con la advertencia de H-056, prototipo a producción, realimentación). La tesis (l. 46) pone en el centro «Ese contrato es un puerto propio de Application cuando el prompt es un detalle… y puede ser el mismo IChatClient cuando la funcionalidad es la conversación»; ningún OA formula esa decisión (OA-0.2 es ubicar piezas; OA-D1 es consumir IChatClient), y §4 no tiene ejemplo propio: lista 01 y 02 (l. 411), que son de §5.1–§5.2 y §5.6 (l. 627–628)." },
  "severidad": "S2",
  "confianza": 0.8,
  "impacto_si_no_se_corrige": "La idea que la guía declara como su tesis no tiene objetivo, ni ítem en §15, ni ejemplo en su sección: el lector puede terminar la guía sin haber practicado ni comprobado la decisión que la guía dice enseñar, y las subsecciones sin OA quedan sin criterio para el recorte del presupuesto de extensión (l. 361).",
  "propuesta_de_dirección": "Correr el criterio de inclusión en los dos sentidos (sección → OA y OA → sección) y, para cada subsección sin OA, o sumarla a un OA existente, o crear el OA (en especial «decidir entre puerto propio e IChatClient como contrato»), o declararla de contexto sin ítem en §15; que §4 tenga un ejemplo propio o una remisión explícita al paso de la demo que contrasta los dos contratos."
}
```

### H-DID2-03 · §15 usa un solo formato de ítem («¿qué escalón elegís?») para OA que piden conductas procedimentales

```json
{
  "id": "H-DID2-03",
  "especialista": "didáctica",
  "capa_origen": "plan",
  "ubicación": "§C §15 (l. 515); §A.3 (l. 106, 114, 119, 120, 127)",
  "afirmación": "§15 promete un ítem por OA «como un caso de Movilidad Urbana ("te piden…, ¿qué escalón elegís y por qué?")», pero buena parte de los OA son procedimentales o no tienen escalón, y un ítem escrito de decisión no observa la conducta que esos OA declaran.",
  "evidencia": { "nivel": "E2", "ancla": "l. 515: «un ítem por objetivo de §0.1 (25 ítems), cada uno como un caso de Movilidad Urbana ("te piden…, ¿qué escalón elegís y por qué?")». OA sin escalón y con verbo de ejecución: OA-D1 «cambiar de adaptador tocando sólo la raíz de composición» (l. 106); OA-D9 «Escribir pruebas de cableado con un IChatClient falso… y registrar una corrida R-LLM» (l. 114); OA-O1 «Configurar UseOpenTelemetry y comprobar con un exportador en memoria» (l. 119); OA-O2 «Configurar endpoint, modelo, num_ctx y timeouts por variable» (l. 120); OA-A1 «Registrar una decisión… como ADR» (l. 115); OA-SK1 «Pasar una herramienta [KernelFunction] a [Description] + AIFunctionFactory» (l. 127). Los ejemplos ya traen un criterio ejecutable que podría servir de ítem (p. ej. 02: «grep -lE … lista sólo Program.cs», l. 628; 14: «nombre, descripción y parámetros coinciden», l. 640)." },
  "severidad": "S2",
  "confianza": 0.7,
  "impacto_si_no_se_corrige": "La corrección del ciclo 1 hizo observables los OA (H-035) pero la autoevaluación los vuelve a medir como declarativos: el lector contesta «elegiría tal cosa» sin haber hecho lo que el OA promete, y la alineación OA ↔ §15 se cumple en el conteo (25 = 25) y no en lo que se observa.",
  "propuesta_de_dirección": "Que el tipo de ítem de §15 siga al verbo del OA: los OA de decisión, con caso y justificación; los procedimentales, con una tarea sobre el ejemplo que el OA cita y su criterio de logro verificable por el propio lector (el oráculo o el comando del README); y que el formato «¿qué escalón?» quede sólo para los OA que tienen escalón."
}
```

### H-DID2-04 · En §8 la aprobación por agente y la instancia positiva del escalón 2 se citan antes de enseñar agentes; la verificación de orden de PAR-14 no lo detectó

```json
{
  "id": "H-DID2-04",
  "especialista": "didáctica",
  "capa_origen": "plan",
  "ubicación": "§C §8 (l. 448); §E.2 filas 10, 11 y 12 (l. 636–638); 07-Aplicacion-Y-Verificacion §3, PAR-14",
  "afirmación": "§E.2 promete que «cada ejemplo usa sólo lo que ya se enseñó» (l. 623), pero §8.5 se apoya en el ejemplo 11 y §8.6 en la variante B del 12, y los dos necesitan `AsAIAgent`/`AgentSession`, que se enseñan recién en §8.7; además, la secuencia de § de los ejemplos 10 → 11 decrece, contra lo que reporta la verificación de PAR-14.",
  "evidencia": { "nivel": "E2", "ancla": "l. 448: «§8.5 Aprobación humana… (ej. 09 y 11…)» · «§8.6 Workflows… instancia positiva (ej. 12, variante B)» · «§8.7 Agentes de MAF (AsAIAgent, AgentSession)… (ej. 11…)». Fila 11 (l. 637): «§8.5, §8.7 · … AsAIAgent… la AgentSession se conserva entre las dos (SerializeSessionAsync…)». Fila 12 (l. 638): «§8.6, §8.8 · … (B) un workflow secuencial (BuildSequential) de redactor + verificador de cifras», con «Microsoft.Agents.AI 1.26.0»; BuildSequential orquesta agentes (§B.3, l. 273). Orden: fila 10 «§8.6» (l. 636), fila 11 «§8.5, §8.7» (l. 637). 07 §3: «PAR-14 | pasa · … § no decrecientes salvo 14»." },
  "severidad": "S2",
  "confianza": 0.75,
  "impacto_si_no_se_corrige": "La instancia positiva del escalón 2, que el ciclo 1 sumó para que el lector pueda comparar workflow y agente (H-DID-07, H-017), llega construida con piezas del escalón 3 que el lector todavía no vio; o el lector la saltea, o la decisión «¿agente o workflow?» se aprende al revés.",
  "propuesta_de_dirección": "Que ninguna subsección de §8 dependa de un ejemplo que usa conceptos de una subsección posterior: o la instancia positiva del escalón 2 se construye sin agentes (nodos que son funciones o llamadas, que §B.3 admite: «nodos: funciones, llamadas o agentes», l. 251), o se trata en §8.8 después de §8.7 con una remisión desde §8.6; y que §8.5 use 09 como su ejemplo y deje 11 para §8.7. Que la verificación de orden compare el primer § de cada fila y los conceptos que el ejemplo usa, no sólo el último §."
}
```

### H-DID2-05 · Prerrequisitos: las rutas derivadas de la columna «§» no incluyen lo que los ejemplos citados necesitan, y §0.3 omite saberes que la guía usa

```json
{
  "id": "H-DID2-05",
  "especialista": "didáctica",
  "capa_origen": "plan",
  "ubicación": "§C §0.2 y §0.3 (l. 367–368); §A.3 (l. 119, 121, 124, 126, 127); §E.2 filas 11, 15, 16, 17 (l. 637, 641–643); §F.5 (l. 776)",
  "afirmación": "Las rutas se derivan sólo de la columna «§» de los OA (l. 367), así que no traen los prerrequisitos de los ejemplos que esos mismos OA citan; y §0.3, que ahora declara lo que se da por sabido, omite EF Core, NUnit, el circuito de Blazor Interactive Server y la lectura de una proporción con intervalo, que la guía usa.",
  "evidencia": { "nivel": "E2", "ancla": "Rutas (l. 367): ACT-SEC «tronco + §7.6, §8.2–§8.5, §8.9, §11»; ACT-OPS «tronco + §5.5–§5.7, §10, §12»; SK «tronco + §9.7 y el ejemplo 14». Pero OA-S2 cita el ejemplo 16 (l. 124), que usa «MEVD, InMemory» y embeddings (l. 642), enseñados en §7.1–§7.4, fuera de la ruta; OA-S4 cita 11 y PD-6 (l. 126), que usan AsAIAgent de §8.7, fuera de la ruta; ACT-SEC tampoco pasa por §5 (IChatClient, ChatOptions), base de §8.2. OA-O1 cita 17 (l. 119), que enseña «el orden de las capas» del pipeline (l. 643), cuya casa es §5.4, fuera de la ruta de OPS; OA-O3 cita 15, cuya entrada es «el registro R-LLM de 07» (l. 641), de §7. OA-SK1 (l. 127) usa AIFunctionFactory, de §8.2, fuera de la ruta SK. §0.3 (l. 368) da por sabidos «C# y .NET 10, inyección de dependencias…, ASP.NET Core… y la idea de capas»; no menciona EF Core (usado desde 08 por `_Comun/Persistencia`, l. 570), NUnit (15 y `tests/`, l. 798), el circuito de Blazor Interactive Server (§F.5: «herramientas por petición quiere decir por circuito», l. 776) ni proporciones con intervalo (Clopper-Pearson, l. 613; «cada tasa como k/M con intervalo», l. 506)." },
  "severidad": "S3",
  "confianza": 0.75,
  "impacto_si_no_se_corrige": "El lector secundario que sigue su ruta llega a los ejemplos que su propio OA le asigna sin las piezas que el ejemplo usa, y el lector principal encuentra en §8, §10 y §14 nociones que ni se explican ni se declaran como sabidas; el defecto que corrigió H-DID-04 reaparece por el lado de los ejemplos.",
  "propuesta_de_dirección": "Que la derivación de cada ruta incluya, además de las secciones de los OA, las secciones de donde vienen los conceptos de los ejemplos que esos OA citan (o que el OA cite un ejemplo alcanzable desde su ruta), y que §0.3 liste como sabido o como explicado en la guía cada noción que los ejemplos y la demo usan."
}
```

### H-DID2-06 · Los niveles B/I/A no tienen criterio declarado, se apartan de PR-3 sin decirlo y chocan con los niveles de turno

```json
{
  "id": "H-DID2-06",
  "especialista": "didáctica",
  "capa_origen": "plan",
  "ubicación": "§E.2 (l. 623, columna «Nivel» de l. 627–643); §E.5 (l. 664–668); §D PR-3 (l. 539); §F.10 AC-3b (l. 818)",
  "afirmación": "El rótulo de dificultad B/I/A no tiene un criterio de asignación, da resultados que contradicen la carga real y la propuesta PR-3 adoptada, y comparte letras con los niveles de turno A/B/C, que es la colisión pendiente del ciclo 1.",
  "evidencia": { "nivel": "E2", "ancla": "l. 623: «El nivel (B básico, I intermedio, A avanzado) es un rótulo de dificultad, no un bloque (PR-3)»; no hay criterio. PR-3 del PO (I-02 l. 65): avanzado = «RAG operable con ingesta, citas, evaluación y observabilidad, más un workflow o multi-agente»; en v1, 06 y 07 (RAG con citas) son «I» (l. 632–633), y el desvío no figura entre los declarados de PR-3 (l. 539: sólo (a) aprobación y (b) ejemplos separados). Incoherencias de carga: 10 (workflow «sin modelo», l. 636) es «A», mientras 11 (agente, dos peticiones, SerializeSessionAsync, texto del pedido armado por el código, l. 637) es «I»; 14 (no llama al modelo, compara metadatos, l. 640) es «I» como 07. Colisión: la fila 01 dice «B» en Nivel y «A» en Turno (l. 627); AC-3b dice «cada ejemplo de nivel A de §E.5» (l. 818)." },
  "severidad": "S3",
  "confianza": 0.7,
  "impacto_si_no_se_corrige": "El lector usa el rótulo para decidir qué hacer primero o qué saltear (§0.5 publica el mapa de Examples/, l. 370), y un rótulo sin criterio lo orienta mal; la colisión hace que «nivel A» signifique «avanzado» en el README del ejemplo y «obligatorio» en el criterio de cierre.",
  "propuesta_de_dirección": "Que el nivel de dificultad tenga un criterio declarado (por ejemplo, cuántos conceptos nuevos suma y cuántas piezas de la solución toca) y se reasigne con él, declarando en §D el desvío frente a PR-3 si 06 y 07 no quedan en avanzado. Sobre la colisión: la propuesta T-A/T-B/T-C deja las mismas letras a la vista; desde lo didáctico conviene que lo que ve el lector (dificultad) conserve sus nombres y que el turno, que es interno de la construcción, use un nombre que no se lea como dificultad y no aparezca en la guía ni en los README."
}
```

### H-DID2-07 · §4.2 se lee antes que §4.1 pero se numera después, para conservar una remisión de la bitácora

```json
{
  "id": "H-DID2-07",
  "especialista": "didáctica",
  "capa_origen": "plan",
  "ubicación": "§C §4, viñetas «Subsecciones» y «Orden interno» (l. 407–408)",
  "afirmación": "El plan resuelve «vocabulario antes que hitos» con una instrucción de lectura que contradice la numeración («§4.2 se lee antes de §4.1»), y la justifica por una remisión de N1b, que es de la bitácora y no del lector.",
  "evidencia": { "nivel": "E2", "ancla": "l. 408: «Orden interno: §4.2 se lee antes de §4.1 (el vocabulario precede a los hitos: H-036, PR-2). Se numera así para que §4.1 conserve la remisión de N1b.» La guía no remite a la bitácora (R-PO-2, citado en l. 524 y l. 827), así que la remisión de N1b no tiene lector en la guía." },
  "severidad": "S3",
  "confianza": 0.8,
  "impacto_si_no_se_corrige": "En un documento único que se lee de arriba abajo (DC-01), el lector principal se encuentra la tabla de hitos con tokens, ventanas y salida estructurada antes del vocabulario que la explica, que es lo que H-036 quiso evitar; la corrección queda en una nota que el lector no ve.",
  "propuesta_de_dirección": "Que el orden de lectura y el de la numeración coincidan en §4, y que la trazabilidad con N1b se resuelva en la bitácora, no en la estructura de la guía."
}
```

## 2. Sobre los pendientes que el cierre del ciclo 1 me traslada

- **AJ-05 (OA asignados a preguntas guía)**: ratificar con cambios, según H-DID2-01. Las asignaciones correctas se pueden ratificar tal cual.
- **Colisión «nivel A/B»**: H-DID2-06. La propuesta T-A/T-B/T-C resuelve la ambigüedad en la bitácora pero no la cuestión de qué rótulo ve el lector.
- **Las demás** (homogeneidad del jurado, deuda declarada, preguntas de nivel C, Operación y entrega) no son de mi mandato.

## 3. Revisado y bien

1. **Orden de lectura de los ejemplos (§E.2–§E.3) y demo de la lectura a la escritura (§F.1)**: 08 «Primera herramienta» ya cae en §8.2 después de los básicos, 05 no depende de RAG, PD-1 es lectura. H-DID-02 del ciclo 1 queda resuelto, salvo el punto de §8 de H-DID2-04.
2. **OA observables y con verbo de conducta (§A.3)**: los 25 OA nombran una conducta comprobable y cubren uno o varios agentes (OA-D7), MCP (OA-D8) y la escalera de conocimiento para DEV (OA-D3). H-DID-03 queda resuelto en la tabla; lo que falta es la autoevaluación que los observa (H-DID2-03).
3. **Instancia positiva del escalón 2 y cierres por escalón en §8 (l. 448)**: los encabezados «Escalón 1/2/3» y las preguntas de cierre por subsección («¿esto se resolvía con una función?», «¿qué perderías con UseFunctionInvocation?») dan a cada escalón su cierre, como pedía H-DID-06, sin partir §8.

## 4. Solicitudes de convocatoria

- **SC-1 (arquitectura o IA)**: confirmar si la variante B del ejemplo 12 se puede armar como workflow de camino fijo con nodos que no son agentes (redactor como llamada, verificador como función) sin perder lo que el ejemplo mide (costo de la variante con más agentes, OA-D7). La dirección de H-DID2-04 depende de eso, y no me toca juzgarlo.
