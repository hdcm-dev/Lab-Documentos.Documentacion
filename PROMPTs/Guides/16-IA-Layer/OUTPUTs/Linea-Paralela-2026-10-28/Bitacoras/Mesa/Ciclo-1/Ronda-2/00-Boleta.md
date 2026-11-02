---
doc_id: BIT-16-C1-R2-00
doc_type: boleta
title: Boleta de la segunda ronda del ciclo 1 (votación por opción)
status: entregado
origin: agent
owner: relator (M§4.2; no vota)
last_review: 2026-10-28
audience: [jurado, presidencia, cuerpo-auditor]
traces: [Mesa/Ciclo-1/07-Dictamen-Presidencia.md §3, Mesa/Ciclo-1/02-Revision-Homogeneidad.md §2, §3, §5, Mesa/Ciclo-1/01-Consolidado.md, Mesa/Ciclo-1/02-Voto-*.md, Mesa/Ciclo-1/03-Parches.md, Mesa/Ciclo-1/05-Aplicacion.md §6 (D-5, D-6), Ronda-2/Consulta-*.md, M§5.3, M§6]
---

# Boleta de la segunda ronda del ciclo 1

Escribo como relator: consolido y armo la boleta, no voto ni juzgo. Las opciones salen de tres fuentes y de ninguna más: las posiciones de los cinco jueces en `02-Voto-*.md`, lo que pidió la revisión de homogeneidad y lo que cambian las siete consultas dirigidas de esta ronda (`Ronda-2/Consulta-*.md`). Cuando una consulta cambia el panorama, lo digo en «Qué cambian las consultas», citando la consulta. Esta boleta no reproduce la evidencia: la evidencia está en cada consulta y en su carpeta `evidencia-*`.

**R-PRIV.** Esta boleta no tiene direcciones, puertos, usuarios ni rutas del home. Los servidores se nombran «la estación de laboratorio» (el Ollama de 4 CPU / 5 GB) y «el segundo servidor de prueba» (el que autorizó el dictamen §4).

## 0. Reglas de esta ronda

1. **Se vota la opción, no `PROCEDE`** (dictamen §3.4). Cada juez marca **una clave** por ítem (A, B, C…) con una línea de fundamento. Un voto sin fundamento no cuenta para el quórum (M§5.3).
2. **Decide la mayoría de 3 o más sobre una misma clave.** Un empate o un 2-2-1 en esta segunda ronda **no** pasa a `INSUFICIENTE`: según M§5.3, es el disparador 6 de escalada (M§6, «empate persistente»). `INSUFICIENTE` sigue disponible como voto individual, con el pedido concreto que lo destrabaría, y cuenta como una clave más en el conteo.
3. **Ítems dependientes.** Varios ítems dependen de otro, que figura en «Depende de». En un ítem dependiente, el juez puede dar un **voto condicionado**, con una clave por cada rama del antecedente (por ejemplo: «si C1-48 = A, entonces B; si C1-48 = B o C, entonces A»). Se cuenta la clave que corresponde a la rama ganadora del antecedente. Si un ítem ya trae una opción que «sigue al antecedente», elegirla equivale a ese voto condicionado.
4. **Regla de perímetro** (02-Revision-Homogeneidad §3.1, punto 1; P-05): no se suma a la demo una pieza que el perímetro votado no tiene. Una opción de un ítem dependiente que contradiga la rama ganadora de C1-48 se registra igual, pero el cuerpo auditor no la puede aplicar: se convierte en escalada (disparador 3, cambio de alcance).
5. **Re-registros** (`re-registro`): la opción A es siempre «re-registrar como dice la revisión», con lo que suma la consulta si corresponde. La opción B es la alternativa real que alguien sostuvo. **Precisiones** (`precision`): las opciones fijan el texto de la resolución, no si el ítem procede.
6. **Orden de votación:** §1 → §2 → §3 → §4 → §5. Los jueces pueden votar todo en una sola pasada, usando votos condicionados donde haya dependencia.

## 1. Bloque del perímetro

Orden: C1-48 → C1-40 → C1-62 → C1-55 y C1-56 → C1-14 y C1-28 (suspensos parciales, §5).

### C1-48 · Perímetro de la demo — `voto-por-opcion`

**Pregunta.** ¿Qué piezas lleva la demo? La tabla D1–D7 → ESC → CTX que pidió el juez de evidencia ya existe: es la del parche P-05, con la columna «afirmación de la guía que la necesita como E1».

**Posiciones en la ronda 1.** Costo-beneficio y riesgo votaron A (demo mínima). Impacto votó A en piezas, pero con controles completos sobre lo que queda. Coherencia histórica votó «otra»: lo ya resuelto, que incluye SUP-05, DC-05, I-04 y la tensión 7, más los controles que pasen el corte de la tensión 6. Evidencia votó `INSUFICIENTE` y pidió decidir pieza por pieza con la tabla.

**Qué cambian las consultas.**
- **Senior .NET (PC-01).** M13 quedó verificado por compilación y corrida: Host ajeno → 400, sin token → 401, Origin ajeno con el middleware → 403. Hay que sumar la validación de Origin, porque el SDK 2.3.0 no la hace. El costo de llevar MCP a la demo ya se conoce y es bajo.
- **Senior .NET (PC-09).** Un catálogo único de `AIFunction` alimenta al bucle y al MCP (`McpServerTool.Create`): MCP deja de ser una segunda definición de las herramientas.
- **AH-01 (PC-12).** «/mcp sólo lecturas» alcanza para la integridad, no para la confidencialidad.
- **AH-01 (PC-13).** Si C1-40 sale B, desaparece de la demo el contrato de aprobación.

| Clave | Opción |
|---|---|
| **A** | **Demo mínima, D1–D6 (P-05, rama A).** Quedan afuera de la demo el servidor MCP HTTP (D7), el selector de proveedor, `AyudaRag` y la página de streaming de tokens; van a `Examples/` con su número (D7 a `Examples/08`, con M13). Lo que queda en la demo lleva sus controles M1–M15 completos (P-27). |
| **B** | **Demo mínima más D7 (P-05, rama B).** D1–D6 y el servidor MCP HTTP de sólo lectura, con M13 completo según PC-01 (loopback, `AllowedHosts`, Origin, autenticación en CTX-PROD) y el catálogo único de PC-09. Lo demás va a `Examples/` igual que en A. |
| **C** | **Perímetro ya resuelto con corte** (coherencia histórica). La demo conserva las piezas que fijaron SUP-05, DC-05, la tensión 7 e I-04 (Blazor y API, capas visibles). Cada pieza o control que se quiera sumar entra sólo si pasa el criterio de corte de la tensión 6 (P-27). Lo que no pasa va a `Examples/` o a la lista CTX-PROD. |
| **D** | `INSUFICIENTE`: la tabla de P-05 no alcanza; el juez dice qué fila falta. |

### C1-40 · Escrituras: aprobar herramientas que escriben o no ofrecerlas — `voto-por-opcion` — depende de C1-48

**Pregunta.** En la demo, ¿cómo se confirma una escritura que nace de una propuesta del modelo? La parte común de P-35 es firme y no se vota: toda escritura la confirma la persona, M3 es una invariante con 0 ejecuciones sin confirmación en `Cableado/`, y ESC-03 nunca escribe.

**Posiciones en la ronda 1.** Evidencia, impacto y coherencia histórica votaron A (MI-14); impacto agregó «con el principio de B». Costo-beneficio y riesgo votaron B. Fue 3-2. Evidencia votó A porque la pieza central de B, `AccionPropuesta`, no estaba compilada y su seguridad era PC-13 (C).

**Qué cambian las consultas.**
- **AH-01 (PC-13 cerrada, E1 + E3).** Las dos ramas son defendibles, y AH-01 prefiere B para la demo. En la sonda D1 la aprobación de MAF resiste en memoria los argumentos forjados, los ids inventados, la repetición y el envío en otra sesión. No resiste una sesión serializada alterada: ejecuta 77 en vez de 7. Además, el `RequestId` no es secreto (`ficc_` + CallId). La sonda D3 mostró que `GetResponseAsync<AccionPropuesta>` acepta tipo=5 e id=-1, así que B exige validar la propuesta. Desaparece la objeción de evidencia contra B, que era la falta de prueba.
- **Comparación 2b/4b.** D6 dio 10/10 bajas sin confirmar también con el 2b: el riesgo viene de ofrecer la herramienta, no del tamaño del modelo. `LocalidadRules` deja pasar el «3400» inventado. Cualquiera de las dos ramas necesita una confirmación fuera del modelo.

| Clave | Opción |
|---|---|
| **A** | **Rama A (MI-14).** ESC-04 usa `ApprovalRequiredAIFunction` sobre la baja y el alta en la demo, con el contrato de P-13 rama A y las condiciones A1–A5 de AH-01: almacén sólo en el servidor; id de aprobación aleatorio del servidor, atado a SessionId + ConversacionId y distinto del `RequestId`; aprobación de un solo uso y con vencimiento; la entidad se vuelve a leer al ejecutar; pruebas D1b y D1h. `AccionPropuesta` queda en `Examples/07` como «diseño alternativo a medir». |
| **B** | **Rama B (ABOGAD-01).** La demo no ofrece herramientas que escriban. El modelo devuelve una `AccionPropuesta` tipada y la persona ejecuta la operación normal, con las condiciones B1–B4 de AH-01: ninguna herramienta de escritura; propuesta validada (enum definido, id existente en la sesión, `LocalidadRules`); la UI muestra la entidad que resuelve el servidor, codificada; 0 escrituras sin el clic de la persona; más la prueba D3. `ApprovalRequiredAIFunction` se enseña en `Examples/07` con A1–A5. |
| **C** | **Sigue al perímetro.** Rama B si C1-48 = A o B (demo mínima); rama A si C1-48 = C. |

### C1-62 · MI-14: el alta también se confirma — `voto-por-opcion` — depende de C1-40

**Pregunta.** ¿Con qué texto se registra MI-14? Se vota junto con C1-40; un voto que no coincida con la rama ganadora de C1-40 se trata según la regla 4.

**Posiciones en la ronda 1.** Evidencia, impacto y coherencia histórica votaron la propuesta. Costo-beneficio y riesgo votaron «otra» (la del abogado). Nadie votó la alternativa.

**Qué cambian las consultas.** Las mismas que en C1-40. Además, la comparación 2b/4b dio el CP inventado 10/10 con el 4b y 1/10 con el 2b (D1): el alta asistida necesita confirmación con cualquiera de los dos modelos.

| Clave | Opción |
|---|---|
| **A** | **Propuesta.** ESC-03 devuelve una propuesta y ESC-04 usa `ApprovalRequiredAIFunction` para las escrituras. Es coherente con C1-40 = A. |
| **B** | **Otra (abogado).** Toda escritura la confirma la persona, sin herramientas que escriban en la demo; `ApprovalRequiredAIFunction` va en `Examples/07`. Es coherente con C1-40 = B. |
| **C** | **Alternativa.** El alta va sin aprobación, con reglas más estrictas (N6 P6). Nadie la votó en la ronda 1, y contradice la parte común de P-35. |
| **D** | **Sigue a C1-40.** A si C1-40 = A; B si C1-40 = B. |

### C1-55 · MI-07: `IAyuda` con contexto fijo y RAG — `voto-por-opcion` — depende de C1-48

**Pregunta.** ¿La demo trae los dos adaptadores de `IAyuda` o sólo el escalón 0? La parte común de P-23 es firme: `AyudaContextoFijo` va por defecto, se usa el oro de P-22, y no hay conclusión comparativa antes de correrlo.

**Posiciones en la ronda 1.** Evidencia, impacto y coherencia histórica votaron la propuesta; evidencia e impacto la condicionaron al oro de C1-24. Costo-beneficio votó la alternativa. Riesgo votó la alternativa condicionada: «si C1-48 queda en B, voto la propuesta». Fue 3-2.

**Qué cambian las consultas.** Ninguna consulta midió `IAyuda`. El dato de costo sigue siendo CAT-OP-07: unos 25–70 s por pregunta en la estación de laboratorio. La consulta del segundo servidor midió una lectura de prompt de unos 107–110 tok/s en ese servidor y de unos 19 en la estación; eso da un lugar más barato para correr la comparación pareada fuera de la demo, pero no cambia el costo dentro de la demo.

| Clave | Opción |
|---|---|
| **A** | **Propuesta.** La demo registra `AyudaContextoFijo` y `AyudaRag` por servicio con clave (`Ayuda:Estrategia`, validado al arrancar) y corre el mismo oro con las dos, en comparación pareada. Con C1-48 = A, choca con la regla de perímetro. |
| **B** | **Alternativa.** La demo trae sólo `AyudaContextoFijo`. `AyudaRag` y la comparación pareada van a `Examples/05`, con el mismo oro. |
| **C** | **Sigue al perímetro** (la posición de riesgo). B si C1-48 = A o B; A si C1-48 = C. |

### C1-56 · MI-08: ESC-02, búsqueda del requisito por significado — `voto-por-opcion` — depende de C1-48

**Pregunta.** ¿El candidato de ESC-02 va en la demo o sólo en `Examples/04`? Las definiciones y el oro de P-22 son firmes.

**Posiciones en la ronda 1.** Evidencia, impacto, coherencia histórica y riesgo votaron la propuesta, con las métricas de C1-24. Costo-beneficio votó la alternativa. Fue 4-1, pero la revisión lo devuelve a la ronda porque la propuesta suma una pieza que el perímetro mínimo no tiene (P-05, fila D5).

**Qué cambian las consultas.** Ninguna lo toca de forma directa.

| Clave | Opción |
|---|---|
| **A** | **Propuesta.** El candidato «buscar el requisito por significado» va en la demo, con hit@1, hit@3, recall@3, MRR@3 y abstención (P-22). Con C1-48 = A, choca con la regla de perímetro. |
| **B** | **Alternativa.** ESC-02 no tiene candidato en la demo. El candidato vive en `Examples/04` con las mismas métricas, y la fila N6 de 03 §4.1 se completa con lo que la demo cubre de verdad. |
| **C** | **Sigue al perímetro.** B si C1-48 = A o B; A si C1-48 = C. |

## 2. Ubicación de la normalización

Orden: C1-38 → C1-53.

### C1-38 · ¿Dónde vive la normalización contra el catálogo? — `voto-por-opcion`

**Pregunta.** Hay que elegir una ubicación con carpeta. Según la revisión, un archivo nuevo dentro de `Application/` copiado hace que `diff -r` deje de dar 0. La prueba de cierre es común a todas las opciones: `medio: "piedra"` por la herramienta y por el endpoint normal, en `Cableado/`.

**Posiciones en la ronda 1.** Coherencia histórica votó B (adaptador). Riesgo votó A (pieza del núcleo, como agregado). Impacto votó A, invocada desde el adaptador. Costo-beneficio votó «otra»: una pieza nueva en Application que el adaptador invoca. Evidencia votó `INSUFICIENTE`, con la misma síntesis. Según cómo se agrupen, sale 2-2-1 o 3-1-1.

**Qué cambian las consultas.**
- **Comparación 2b/4b.** La normalización no puede quedar en el modelo. Sin enum, el 2b propuso medios fuera del catálogo 10/10, y el 4b propuso «bondi» 1/10 en D3-T. «El catálogo normaliza; la regla decide» es obligatorio. No decide la ubicación, pero descarta dejarla en el prompt.
- **AH-01 (PC-15, hallazgos laterales).** La ApiWeb no hace cumplir `LargoMaximoDelNombre = 60`, y `GetResponseAsync<T>` acepta enums no definidos. Hace falta validar del lado del servidor antes del caso de uso, en cualquier ubicación.

| Clave | Opción |
|---|---|
| **A** | **Carpeta agregada fuera del árbol copiado** (P-17, rama con mayoría): `Agregado/Application/Normalizacion/NormalizadorDeCatalogos.cs`. Es núcleo, porque no referencia MEAI ni Infrastructure. Figura en `PROCEDENCIA.md` y el adaptador de herramientas la invoca antes del caso de uso. `diff -r` da 0 sobre todo lo copiado. |
| **B** | **En el adaptador de `Infrastructure/AI`** (coherencia histórica; R-C03, M2): la normalización va dentro de la función .NET. La guía cambia «el caso de uso y las reglas deciden» por «el adaptador normaliza contra `Catalogos` y el caso de uso decide lo demás». |
| **C** | **Archivo agregado dentro de `Application/` de la copia.** El criterio de MI-05 se reescribe como «`diff -r` = 0 sobre los 18 archivos copiados; el agregado figura en `PROCEDENCIA.md`». Es la forma que sugirió la revisión §3.2 como alternativa a la carpeta separada. |

### C1-53 · MI-05: demo como copia literal de ApiWeb — `voto-por-opcion` — depende de C1-38

**Pregunta.** ¿Con qué condición se re-registra MI-05? Las condiciones de C1-19 (cierre de compilación con `dotnet build`, namespaces declarados, `LocalidadesController` como deuda heredada) no están en discusión.

**Posiciones en la ronda 1.** Los cinco votaron la propuesta, pero con condiciones incompatibles: coherencia histórica la ató a C1-38 B, riesgo a C1-38 A, y costo-beneficio a la síntesis.

**Qué cambian las consultas.** Ninguna de forma directa. AH-01 condicionaba su apoyo a MI-05 a que M2 quedara; con cualquiera de las tres opciones de C1-38, M2 queda.

| Clave | Opción |
|---|---|
| **A** | **Propuesta con la ubicación ganadora de C1-38.** Copia literal más las condiciones de C1-19, y el criterio de verificación según la opción de C1-38: «`diff -r` = 0 sobre todo lo copiado» si gana A o B, o «sobre los 18 archivos copiados» si gana C. H1–H5 no se endurecen. |
| **B** | **Alternativa.** Se reimplementa el dominio mínimo, se endurecen las reglas y se agrega ESC-06. Es la salida que AH-01 anunció si M2 caía. |

## 3. Re-registros

### C1-67 · MI-19: N5 P7 con un campo `Comentario` hipotético — `re-registro`

**Contexto.** En sustancia fue 5-0 contra la propuesta. PC-14 está cerrada: AH-01 valida la variante `Localidad.Nombre` como patrón, siempre que la guía declare la precondición de que quien escribe y quien lee son principales distintos. Hay cuatro caminos a esa precondición, y para CTX-PROD el ejemplo es `RespuestaDeEncuesta.Localidad`. En la sonda L (R-LLM), el 4b pidió 0/10 bajas (Wilson 0–0,28) y repitió el texto inyectado 10/10.

| Clave | Opción |
|---|---|
| **A** | Re-registrar como `NO_PROCEDE` de la propuesta, con la resolución de la revisión §2.1 completada por PC-14: entra la variante `Localidad.Nombre` con la precondición y los cuatro caminos, se suma la prueba M14 sobre ese campo, y la tasa de L va como tasa observada. `Examples/11` sale (P-44). |
| **B** | Re-registrar como `NO_PROCEDE` de la propuesta, con la resolución de Edición: explicación conceptual sin ejemplo, aunque PC-14 lo habilite. `Examples/11` sale. |

### C1-72 · MI-24: investigar «sincrónico o en segundo plano» y el umbral de C2 — `re-registro`

**Contexto.** En sustancia fue 5-0 contra «investigar». La consulta AH-02 (PC-10) cambia la forma de la parte (b): el 2/10 de X2 D1 es una tasa **de un pedido** y no sirve para fijar un umbral de tarea. Una tasa de tarea pide K ≥ 10 pedidos y m ≥ 3 semillas por pedido (R-LLM-3d). AH-02 también descarta el intervalo normal (CLT), que es la base del «N ≥ 96» de P-02.

| Clave | Opción |
|---|---|
| **A** | Re-registrar como `NO_PROCEDE` de «investigar»: (a) resuelta por C1-47 (P-40); (b) sin umbral hasta definir la métrica (C1-02/P-02) y medir con N suficiente; en la guía, «no medido». La cota «N ≥ 96» de P-02 se reemplaza por la regla R-LLM-3d de AH-02. |
| **B** | Mantener `PROCEDE` en la parte (b) (Requisitos): investigar ahora el umbral de C2 con la métrica de P-02 y una corrida R-LLM-3d (K ≥ 10 pedidos), dentro del ciclo. |

### C1-61 · MI-13: dónde se demuestra el cambio de proveedor — `re-registro`

**Contexto.** Los cinco votaron la alternativa (P-39). La consulta Senior .NET (PC-05) suma límites medidos de la vía `/v1`: MEAI.OpenAI descarta `TopK` en silencio, Ollama 0.40.11 ignora `max_completion_tokens` (se pidieron 3 tokens y salieron 57) y `num_ctx` no se puede fijar por pedido.

| Clave | Opción |
|---|---|
| **A** | Re-registrar como `NO_PROCEDE` de la propuesta, con la alternativa adoptada: sólo en `Examples/01` y `Examples/06`, con la limitación declarada y la tabla de diferencias de PC-05 (`TopK`, `MaxOutputTokens`, `num_ctx`). |
| **B** | Mantener la propuesta: composición de la demo más el ejemplo 01 (la posición de Requisitos, Implementador, Didáctica y Arquitectura en el panel), como variante rotulada «sin num_ctx». |

### C1-64 · MI-16: juez calibrado con 10–20 casos — `re-registro`

**Contexto.** Votaron la alternativa cuatro jueces, y el quinto propuso un protocolo de R-C09 sin compuerta. La consulta del segundo servidor (PC-08) midió el costo: 28 evaluaciones en 950 s en el segundo servidor, y 21 min por caso en la estación de laboratorio. El diseño 10×2×3 con N=1 cabe en unos 35 min en el segundo servidor y en 2,6–5,1 h en la estación. Condiciones medidas: razonamiento apagado, `num_ctx` de al menos 8192 y Retrieval fuera.

| Clave | Opción |
|---|---|
| **A** | Re-registrar como `NO_PROCEDE` de la propuesta, con la alternativa adoptada (P-38): la demo no trae juez; el método se enseña con la advertencia oficial; en la estación de laboratorio, «no medido»; en el segundo servidor, k/n con intervalo y nunca como compuerta, con las condiciones de PC-08. |
| **B** | Re-registrar con el protocolo de R-C09 sin compuerta: correr el juez en el segundo servidor (10–20 casos × 2 adaptadores × 3 evaluadores) como parte del ciclo de demo, e informar el acuerdo como k/n con intervalo. La demo sigue sin juez. |

### C1-42 · Causa de «≥ 7B no corre» y vía de MI-03 — `re-registro`

**Contexto.** Los cinco votaron B (P-37). La consulta del segundo servidor (PC-07) agrega un hecho medido: `qwen3.5:35b-a3b` ocupa 21 GiB cargado, más de cuatro veces el límite de 5 GB del contenedor de la estación. Un denso de 7–9B sigue sin medirse.

| Clave | Opción |
|---|---|
| **A** | Re-registrar con la opción B: «no se midió en la estación; el contenedor está limitado a 4 CPU / 5 GB», con el hecho del 35b-a3b (21 GiB cargado) y la vía por la mesa, no por REED-16 §12 fila 4. |
| **B** | Posición A (Experto IA): la frase atribuye la causa a la lectura de prompt de 18–20 tok/s en CPU («no entra en la estación»). |

### C1-43 · ¿EA-6 respalda «A por defecto»? — `re-registro`

**Contexto.** Los cinco votaron B. La consulta AH-02 (PC-10) replicó EA-6: en P0 dio 12/16 (Wilson [0,51; 0,90]) y en los otros cinco pedidos 40/40. Que B omita la herramienta depende del pedido: 5 de 6 pedidos pasan siempre. Eso refuerza «A por diseño» y obliga a reescribir la tensión 1.

| Clave | Opción |
|---|---|
| **A** | Re-registrar con la opción B: EA-6 no respalda «A por defecto»; MI-01 se sostiene por diseño; la tensión 1 se reescribe con la réplica de PC-10, como tasa de un pedido. |
| **B** | Posición A (Experto IA): la tasa observada (P0 12/16) respalda «A por defecto». |

### C1-44 · Juez local (MI-16) — `re-registro`

**Contexto.** Votaron B cuatro jueces, y el quinto una variante de B. Las mediciones de PC-08 son las mismas que en C1-64.

| Clave | Opción |
|---|---|
| **A** | Re-registrar con la opción B: no hay juez en la demo; el método se enseña; «no medido» en la estación de laboratorio; en el segundo servidor, k/n con intervalo y nunca como compuerta; se reemplaza la marca «no medido» del costo por las cifras de PC-08. |
| **B** | Posición A (Experto IA): un juez calibrado con 10–20 casos anotados, que ahora se puede correr en el segundo servidor (unos 35 min). |

### C1-45 · Dónde se demuestra el cambio de proveedor — `re-registro` — depende de C1-61

**Contexto.** Los cinco votaron B. Es el mismo objeto que C1-61, y PC-05 agrega la tabla de diferencias de la vía `/v1`.

| Clave | Opción |
|---|---|
| **A** | Re-registrar con la opción B: sólo los ejemplos 01 y 06, con la limitación declarada y la tabla de PC-05. |
| **B** | Posición A: en la composición de la demo y en el ejemplo 01. |

### C1-46 · Forma del ADR del ciclo de vida (MI-23) — `re-registro`

**Contexto.** Votaron B cuatro jueces; evidencia lo declaró indiferente, siempre que el contenido sea obligatorio. P-13 ya usó el número D-11 para el estado de la conversación (05-Aplicacion, fila P-13). La consulta AH-01 (PC-11) cambia el contenido obligatorio: ver C1-12.

| Clave | Opción |
|---|---|
| **A** | Re-registrar con la opción B: va dentro de D-06, con el contenido de C1-12 tal como quede en la precisión de esta ronda. |
| **B** | Posición A (Arquitectura): un ADR propio para el ciclo de vida, con número nuevo, porque D-11 ya está tomado. |

### C1-50 · MI-02: modelos — `re-registro` — depende de C1-41

**Contexto.** Los cinco votaron con el rótulo «provisional». La comparación 2b/4b ya corrió (N=10 por pedido y modelo, una corrida). En D3 el 4b falló 0/10 y el 2b 10/10. En D1 el 4b inventó el CP 10/10 y el 2b 1/10. En D6 los dos borraron sin confirmar 10/10. El 2b medido es Q8_0 de 2,68 GB, no el q4_K_M de 1,9 GB que dice AD-W1. En el segundo servidor, PC-07 no separa al 35b del 4b, que además es unas 4 veces más rápido por llamada.

| Clave | Opción |
|---|---|
| **A** | Re-registrar la propuesta con un rótulo provisional nuevo: «elegido frente al 2b porque normaliza al catálogo (D3); el 2b respeta mejor el dato inválido (D1); ninguno confirma antes de borrar (D6); N = 10, una corrida». El 2b se cita con su cifra medida y su digest. |
| **B** | Alternativa de MI-02: un modelo mayor (`qwen3.5:35b-a3b`) en el segundo servidor como modelo por defecto. |

### C1-51 · MI-03: Ollama en el segundo servidor — `re-registro`

**Contexto.** Los cinco votaron «otra» (Operación). El servidor ya está levantado y medido con el mismo `sondeo.py`: mismas tasas que en la estación y paredes entre 1,5 y 5,7 veces menores. Cubre PC-07, PC-08 y la lectura de prompts largos. La concurrencia quedó «no medido». P-37 dice «se apaga al terminar», pero el contenedor quedó arriba para la redacción. Cuándo se apaga lo decide la presidencia, no esta boleta.

| Clave | Opción |
|---|---|
| **A** | Re-registrar acotado al texto de Operación: bajo demanda, por la mesa, con versión, digest y límites registrados y sondeo previo (hecho). Cubre P-03, P-07, el juez (PC-08) y la lectura de prompts largos. La concurrencia y el contexto grande quedan en la estación con su rótulo, o «no medido». |
| **B** | La propuesta original completa: el segundo servidor para el comparativo ≥ 7B, la concurrencia, el contexto grande y el juez. Fue la posición de Requisitos, Verificación, Experto IA y AH-02 en el panel. |

### C1-59 · MI-11: lista mínima y criterio de corte — `re-registro` — depende de C1-28

**Contexto.** Los cinco votaron «otra», y la propuesta tal cual no tuvo votos. La lista vigente es la de P-27 (M1–M15, con el corte definido). La forma de M13 se decide en C1-28. PC-11 suma a M6 una prueba concurrente sin cruce.

| Clave | Opción |
|---|---|
| **A** | Re-registrar «otra»: M1–M15 de P-27, con M13 en la forma que gane en C1-28 y la prueba concurrente de M6 (PC-11, forma (a)–(c)). |
| **B** | La propuesta: M1–M12 con su corte, sin M13–M15. |

### C1-71 · MI-23: forma del ciclo de vida del cliente — `re-registro` — depende de C1-46

**Contexto.** Votaron «dentro de D-06» cuatro jueces; evidencia, indiferente. Es el mismo objeto que C1-46.

| Clave | Opción |
|---|---|
| **A** | Re-registrar la alternativa adoptada: dentro de D-06, igual que C1-46. |
| **B** | Un ADR propio (posición de Arquitectura). |

## 4. Precisiones

### C1-12 · Ciclo de vida del cliente: título y fundamento — `precision`

**Contexto.** La revisión §3.4 pidió cambiar «mezcla sesiones» por «pierde la sesión sin error», porque el cruce era PC-11 (C). Desde entonces, PC-11 está cerrada con E1 (AH-01, sonda D2). Con el `SessionContext` real (Guid provisorio en el constructor) y Singleton con `ValidateScopes=false`, las conversaciones comparten la raíz, y la sesión B vio y borró lo que creó A. Con `ValidateScopes=true`, la falla aparece en cada llamada a la herramienta, no al arrancar. La consulta Senior .NET (PC-09) confirma que hay un `SessionContext` por scope en los dos lados.

| Clave | Opción |
|---|---|
| **A** | Título: «Singleton fuera de Development: todas las conversaciones comparten un único espacio y pueden leer y borrar lo que otra escribió, sin error» (E1, PC-11). Se corrigen las dos frases de P-12 («pierde la sesión sin error» y «falla al arrancar»). La prueba de P-10 pasa a la forma (a)–(c) de AH-01: clase real del caso base, dos sesiones concurrentes con `ValidateScopes` en true y en false, y aserción de que no hay cruce. |
| **B** | La precisión de la revisión tal como se escribió: «pierde la sesión sin error», con el cruce como no probado. Ya no coincide con la evidencia de PC-11. |
| **C** | Volver al título original de ronda 1, «mezcla sesiones sin fallar», sin el detalle de qué comparte ni de cuándo falla con `ValidateScopes=true`. |

### C1-37 · Orden del pipeline — `precision`

**Contexto.** PC-02 ya corrió (Operación, E1, sonda sin modelo). La doble capa da spans de herramientas y aciertos de caché en la misma traza. Pero tiene dos costos: en cada fallo de caché, `gen_ai.client.token.usage` cuenta doble (48 contra 24 reales), y ningún atributo marca el acierto. En la rama A, un `Counter<long>` propio cuenta el acierto y el histograma queda limpio; Operación la recomienda, aclarando que no es un voto. En el orden de R-C07 no hay `execute_tool`. Según Operación, el bloqueo de P-34 sobre el orden se levanta.

| Clave | Opción |
|---|---|
| **A** | **Doble capa** (la primera rama de P-03): OTel externa → caché → `UseFunctionInvocation` → OTel interna → cliente, con el mismo `sourceName`. M8 advierte que los tokens se cuentan doble en cada fallo de caché y que el costo se mide con los spans internos o con un contador. |
| **B** | **Rama A de P-03:** caché → `UseFunctionInvocation` → OTel → cliente, con un `Counter<long>` propio para los aciertos, que sobrescribe `ReadCacheAsync` en el `Meter` de MI-15. Spans de herramientas e histograma limpio; el acierto no deja span. |
| **C** | **Orden de R-C07** (rama B de P-03): OTel → caché → `UseFunctionInvocation`. Hay un span por pedido en los dos casos y no hay spans de herramientas. Era la posición de coherencia histórica si la reapertura no se fundaba. |

### C1-37-clave · Clave de caché con la sesión (condición de riesgo) — `precision` — depende de C1-37

**Contexto.** Era una condición aislada del juez de riesgo (revisión §3.5). PC-02 la verificó: si la clave no incluye la sesión, la sesión B recibe la respuesta de A. Con `CacheKeyAdditionalValues = [SessionId]` (MEAI 10.11.0) y la caché creada por scope, dos sesiones dan dos fallos. En las tres opciones de C1-37 la caché queda por fuera de `UseFunctionInvocation`, así que la condición vale para todas.

| Clave | Opción |
|---|---|
| **A** | Es obligatoria en cualquier orden: `CacheKeyAdditionalValues = [SessionId]`, la caché creada por scope (encaja con P-12) y una prueba de cableado de dos sesiones con el mismo texto, que tienen que dar dos fallos de caché. |
| **B** | La otra salida que dio riesgo: la caché no se aplica a los pedidos con herramientas que leen `SessionContext`, y la clave queda sin la sesión. |

### C1-41 · ¿La comparación D1–D6 es obligatoria antes de publicar? — `precision` — depende de C1-50 (se votan juntos)

**Contexto.** En la ronda 1, evidencia y coherencia histórica la dieron por obligatoria, costo-beneficio «si sobra turno», impacto «deseable, no bloquea», y riesgo no se pronunció. La comparación ya corrió en esta ronda: una corrida, N=10 por pedido y modelo, criterio escrito antes y salida cruda con hash. Por PC-10, es una comparación de **tasas de un pedido**, y una tasa de la tarea pediría K ≥ 10 pedidos (R-LLM-3d). Las paredes quedaron como observación, con el anfitrión sin reservar.

| Clave | Opción |
|---|---|
| **A** | El pendiente queda cumplido con la corrida de esta ronda. Se cambia el rótulo, como en C1-50 A, y el 4b sigue provisional en el sentido de P-24. No se exige otra corrida antes de publicar. |
| **B** | Sigue siendo obligatoria antes de publicar una comparación **de tarea** (K ≥ 10 pedidos redactados antes, m ≥ 3 semillas, pareada, según R-LLM-3d y 3e). La corrida de esta ronda vale como tasa de un pedido. |
| **C** | Es obligatorio replicar la misma comparación antes de publicar, con una segunda corrida y el anfitrión reservado, sin ampliarla a tarea. La pared se mide en esa misma corrida. |

### C1-49 · MI-01: lugar de la vía C — `precision`

**Contexto.** En la ronda 1, impacto, costo-beneficio y riesgo pusieron C en la sección de agentes. Evidencia y coherencia histórica pusieron tres vías enseñadas; evidencia agregó el rótulo «sólo con doble» y dejó la posición a Didáctica. El abogado sostuvo la alternativa. P-24 aplicó la primera posición por 3 votos. Qué cambian las consultas: la consulta de definiciones fija «agente mínimo» y «agente de MAF» para la sección de agentes, y PC-10 replica EA-6 (ver C1-43). Ninguna corrió la vía C con el modelo.

| Clave | Opción |
|---|---|
| **A** | A y B se enseñan en la sección de conocimiento. C se enseña en la sección de agentes como «la misma recuperación dentro del agente», con el rótulo «corrida sólo con un doble» (P-24). |
| **B** | Las tres vías se enseñan juntas en la sección de conocimiento, con C rotulada «sólo con doble» y como criterio de diseño. |
| **C** | Se enseñan A y B, y C se menciona en una línea (la alternativa de MI-01, del abogado). |

### C1-36 · ¿Qué bloquea la falta de las secciones 4 y 6? — `precision`

**Contexto.** La revisión §2.3 pidió una precisión, y P-34 la aplicó: no bloquea la redacción en general, pero sí las secciones que derivan de un núcleo con S1 abierto (N0b por P-02, N5 §4.2 por P-03); bloquea además declarar «validado» y el cierre. Lo que cambian las consultas: PC-02 corrió, así que la parte de P-03 que dependía del orden puede verificarse (C1-37).

| Clave | Opción |
|---|---|
| **A** | La precisión de la revisión (P-34): bloquea las secciones de núcleos con S1 abierto hasta que su parche esté aplicado y verificado; bloquea «validado» y el cierre. |
| **B** | Lo que votaron cuatro jueces en la ronda 1: no bloquea la redacción; sólo bloquea declarar «validado» y el cierre. |

### C1-01 · Compuerta R-PRIV — `precision`

**Contexto.** El dictamen §1 aceptó la redacción in situ, que queda firme. El dictamen §2 permite hostnames y nombres de contenedores en la bitácora mientras no se commitee, y exige un barrido de redacción antes del primer commit. P-01 fijó el comando (`rpriv.sh` con cuatro patrones y `RPRIV_LISTA`, alcance `OUTPUTs/` incluida `Mesa/`, salida con fecha, cierre cuando sale 0). La consulta Senior .NET (PC-03) agrega que OllamaSharp 5.5.0 serializa `<clave-de-cabeceras>` en el cuerpo; propone sumar `grep '"<clave-de-cabeceras>":{"'` sobre las capturas de cuerpo, que hoy da 0.

| Clave | Opción |
|---|---|
| **A** | El comando de P-01 más el patrón de `<clave-de-cabeceras>` sobre las capturas de cuerpo (PC-03). El cierre es «el comando guardado da 0». La exclusión del commit no cierra la compuerta (dictamen §1 y §2). |
| **B** | El comando de P-01 tal cual, sin el patrón de `<clave-de-cabeceras>`. El cierre y la exclusión, igual que en A. |
| **C** | El comando de P-01 más el patrón de `<clave-de-cabeceras>`, con la exclusión del commit también válida como cierre en la bitácora, como dejaron abierto costo-beneficio y evidencia en la ronda 1. |

## 5. Suspensos parciales

### C1-14 · Contrato del asistente: la parte que depende del perímetro — `voto-por-opcion` — depende de C1-40

**Contexto.** La parte firme del 5-0 es el ADR del estado de la conversación (P-13, D-11), y no se vota. Lo que queda suspendido es el contrato de la aprobación pendiente. Lo que cambian las consultas: AH-01 (PC-12 y PC-13) fija las condiciones A1–A5 si hay endpoint de aprobación; el 404 por sesión distinta no es control de acceso, y la guía lo declara en las dos ramas. En la rama B, el almacén guarda el historial, que es dato de la persona: lleva vencimiento y no va a los registros. La sesión serializada guarda los argumentos pendientes y el texto de la persona (D1g).

| Clave | Opción |
|---|---|
| **A** | **P-13 rama A en la demo:** `AprobacionPendiente(id, herramienta, argumentos)` y `POST /api/v1/asistente/aprobaciones/{id}`, con id aleatorio del servidor (no el `RequestId`), atado a SessionId + ConversacionId, de un solo uso y con vencimiento; la entidad se vuelve a leer al ejecutar; pruebas D1b, D1h y la de dos sesiones. Corresponde a C1-40 = A. |
| **B** | **P-13 rama B en la demo:** evento `AccionPropuesta(tipo, datos)`, sin endpoint de aprobación; la UI ejecuta la operación normal. El historial lleva vencimiento y no va a los registros. El contrato de la rama A, con A1–A5, va en `Examples/07`. Corresponde a C1-40 = B. |
| **C** | **Sigue a C1-40:** A si C1-40 = A; B si C1-40 = B. |

### C1-28 · M13: forma del control de MCP — `voto-por-opcion` — depende de C1-48

**Contexto.** La parte firme del 5-0 es el largo máximo de entrada (M15) y M14 en `Cableado/`, y no se vota. La ubicación de M13 sigue a C1-48: va en la demo si C1-48 = B o C, y en `Examples/08` si C1-48 = A. Lo que se vota es la forma. Lo que cambian las consultas: Senior .NET (PC-01) dejó loopback, `AllowedHosts` y autenticación verificados por compilación y corrida, con 400, 401 y 403. El SDK 2.3.0 no valida Origin, aunque la especificación MCP 2025-06-18 lo exige con un MUST, y un middleware probado lo resuelve. PC-09 da el catálogo único. AH-01 (PC-12) suma la prueba por reflexión «ninguna herramienta con parámetro de sesión» y justifica «/mcp sólo lecturas» para la integridad.

| Clave | Opción |
|---|---|
| **A** | **M13 completo según las consultas:** loopback por defecto, `AllowedHosts` restringido (400), middleware de Origin sobre `/mcp` (403), `RequireAuthorization()` en CTX-PROD (401), herramientas publicadas desde el catálogo único (`WithTools(catálogo.Select(McpServerTool.Create))`) filtrado a lectura, prueba por reflexión sin parámetro de sesión, y la aserción de `Cableado/` con la tabla 400/401/403. |
| **B** | **M13 como en P-27**, sin validación de Origin y con dos definiciones de las herramientas, como N6 §4.5 hoy. Origin se anota en la lista CTX-PROD. |
| **C** | **M13 como en A, pero con dos definiciones de las herramientas** (atributo `[McpServerTool]` más `AIFunctionFactory`), justificadas en el texto, como permite PC-09. |

## 6. Fuera de esta boleta

- **C1-32, el sentido de «workflow».** La consulta de definiciones pide votar su opción A o su opción B «según el dictamen §3.4». El ítem no está en la lista de la segunda ronda del dictamen §3.2. Lo elevo a la presidencia para que decida si lo suma a esta ronda; no lo pongo en la boleta.
- **Cuándo se apaga el segundo servidor** (C1-51). Lo decide la presidencia (consulta del segundo servidor, PC-07 y PC-08).
- **§R.6 del Sondeo.** Varias consultas proponen filas nuevas: la recarga del 4b, el costo del juez y el 2b Q8_0. Las decide la aplicación, no el jurado.
- **Hallazgos laterales sin ítem.** La ApiWeb no hace cumplir `LargoMaximoDelNombre = 60` (toca a P-16 y a M15), y `GetResponseAsync<T>` acepta enums no definidos (AH-01, PC-15). Van al cuerpo auditor como derivados de P-16, P-27 y P-35.

## 7. Resumen de dependencias

| Antecedente | Dependientes |
|---|---|
| C1-48 | C1-40, C1-55, C1-56, C1-28 (ubicación de M13) |
| C1-40 | C1-62, C1-14 |
| C1-38 | C1-53 |
| C1-37 | C1-37-clave |
| C1-46 | C1-71 |
| C1-61 | C1-45 |
| C1-28 | C1-59 |
| C1-41 ↔ C1-50 | se votan juntos: el rótulo de C1-50 A presupone C1-41 A o C |
