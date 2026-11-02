---
doc_id: BIT-16-C1-R2-04-COH
doc_type: aprobacion
title: Aprobación del juez de coherencia histórica, ronda 2 del ciclo 1, vuelta 1
status: entregado
origin: agent
owner: juez de coherencia histórica (REED-16 §9.4)
last_review: 2026-10-28
audience: [presidencia, cuerpo-auditor, aplicación]
traces: [Ronda-2/03-Parches.md (P2-01…P2-15), Ronda-2/02-Voto-coherencia-historica.md, Mesa/Ciclo-1/07-Dictamen-Presidencia.md §1–§4, Mesa/Ciclo-1/03-Parches.md (P-03, P-05, P-14, P-15, P-22, P-23, P-39, P-40), Mesa/Ciclo-1/05-Aplicacion.md (fila P-39, D), BIT-16-04 §4 (R-C02, R-C07, R-C13, R-C14, R-C16), §5 (MI-07, MI-08), §6.2 (diagrama único)]
---

# Aprobación de coherencia histórica — ronda 2, vuelta 1

**Pregunta fija.** ¿El parche es coherente con DC-01…DC-08, I-06, BIT-16-04, el ciclo 1 y el dictamen de presidencia? Y el chequeo obligatorio: ¿corrige en la capa donde nació el defecto?

**Votos míos que perdieron.** En C1-48 voté C, en C1-40 C, en C1-55 y C1-56 C, y en C1-37 A (doble capa). Ganaron A, B, B, B y B, respectivamente, sin veto. Esta aprobación juzga si los parches implementan **la opción ganadora** sin dejar contradicciones en el registro. No vuelve a votar la opción.

**Hallazgo transversal.** Ningún parche de esta ronda anota cuatro lugares de BIT-16-04 que siguen afirmando, para la demo, lo que la ronda acaba de sacar de ella:

| Lugar | Qué sigue afirmando | Lo que la ronda decidió | Parche que lo debe anotar |
|---|---|---|---|
| §4 R-C13 (= RA-6 = C-6) | `IAyuda` con dos adaptadores elegidos por configuración en la demo | C1-55 = B: sólo `AyudaContextoFijo`; `AyudaRag` en `Examples/05` | P2-02 |
| §4 R-C16 (= C-7) | Candidato nuevo de ESC-02 en el marco | C1-56 = B: sólo en `Examples/04` | P2-02 |
| §4 R-C14 | Selector de proveedor en la composición (`AddAI`) | P-39 y C1-61 = A: sólo en `Examples/01` y `06`. En `05-Aplicacion` la fila P-39 quedó **D (diferida)** justo en «R-C14 en `Examples/06`» | P2-08 |
| §6.2, el **único diagrama de capas de la guía** | `/mcp: sólo lecturas` en Presentación; `AyudaRag` y la recuperación (vías A, B, C) en `Infrastructure/AI`; `AI:Proveedor`; «escrituras con `ApprovalRequiredAIFunction`»; pipeline `UseOpenTelemetry → [caché] → límite → UseFunctionInvocation`; y el párrafo «lo que el lector tiene que llevarse», puntos (2)–(4) | P2-02 (perímetro), P2-03 (sin escritura), P2-06 (orden), P2-08 (proveedor) | P2-02, con una sola nota consolidada |

El defecto nació en la integración. Los parches corrigen en la capa de la integración (MI-07, MI-08, §6.1, M8, M10), pero no en las resoluciones donde nació. P2-02 y P2-08 sólo nombran P-15 y P-39 como «derivados a revalidar». Por regla 2 de 03-Parches §0, la nota de esta ronda tendría prelación, pero la relectura integral encontraría R-C13, R-C14, R-C16 y §6.2 sin ninguna nota que los remita. Además, §6.2 es la fuente del diagrama de la guía. Lo pido en mi voto de la ronda 1 y en el de esta ronda: toda reapertura queda como nota fechada **en la resolución que reabre**.

## Decisiones

| Parche | Decisión | ¿Capa correcta? | Fundamento |
|---|---|---|---|
| P2-01 | **APLICAR** | Sí | Implementa C1-01 = A (5-0) y repite el cierre del dictamen §2: la exclusión del commit no cierra, y los identificadores en la bitácora se toleran hasta el barrido previo al primer commit. La redacción in situ (b) usa la excepción del dictamen §1 para lo que ese párrafo permite: borrar un dato que R-PRIV prohíbe, en evidencia de esta misma ronda. Los sintéticos se excluyen por valor exacto y nunca por archivo, así que la regla de P-01 no se debilita. La capa es correcta: el patrón se suma a la compuerta (pedido e integración) y la regla de redacción a RV-01 (guía). |
| P2-02 | **MEJORAR_PLAN** | Sí, pero incompleta | Implementa bien la opción ganadora (C1-48 = A, C1-55 = B, C1-56 = B) y anula las otras ramas por nota, sin borrarlas. Le falta anotar las resoluciones donde nació el perímetro anterior (ver la mejora). **Lectura de «streaming de tokens»: ratifico la de P2-02.** `Examples/02` es el ejemplo dedicado a `GetStreamingResponseAsync`/`ChatResponseUpdate`. La página de la demo conserva `IAsyncEnumerable<EventoDelAsistente>` con `EtapaIniciada`, `TextoParcial` y `Final`. Motivo de coherencia: P-14 (MI-20, 5-0) y P-40 (C1-47) son firmes, y la boleta de C1-48 no los abrió. La lectura literal sacaría `TextoParcial` y modificaría dos parches firmes sin votación. Eso es justamente lo que la regla de perímetro (boleta §0.4) prohíbe en la dirección contraria. |
| P2-03 | **APLICAR** | Sí | Implementa C1-40 = B (4-1), C1-62 = B y C1-14 = B. La parte común de P-35 se mantiene (M3 invariante, ESC-03 nunca escribe), y R-C02 recibe su nota, que es donde nació el defecto. «El alta también se confirma» sigue siendo R-C02 tal como se escribió: sólo cambia el mecanismo. La rama A no se pierde, porque pasa entera a `Examples/07` con A1–A5. El nodo `TOOLS` de §6.2 («escrituras con `ApprovalRequiredAIFunction`») lo cubre la nota consolidada que pido en P2-02. |
| P2-04 | **APLICAR** | Sí | Es la condición que puse en la ronda 1 para pasar de B a A: la pieza queda fuera del árbol copiado (tensión 7, `diff -r` = 0), y R-C03 y M2 se cumplen en el adaptador. Las dos validaciones nuevas (enum no definido y largo 60) viven en `Agregado/` y no endurecen la copia: C1-53 = A queda intacta. Que se registre como **divergencia** la condición «mismo error por los dos caminos» del juez de evidencia, en lugar de aplicarla en silencio o descartarla, es lo coherente. La deuda heredada se declara en `PROCEDENCIA.md`, junto a ARQUIT-05. |
| P2-05 | **APLICAR** | Sí | Reabre R-C04 con evidencia nueva (PC-11, sonda D2, E1) y deja nota en R-C04, M6, MI-23 y §7 P-10, como pedí. El título dice lo que se probó, y la condición de citar el valor por defecto de `ValidateScopes` según el entorno, o reformular el título, evita afirmar lo que la sonda no midió. Dejarlo dentro de D-06 es coherente con P-13, que tomó D-11 para el estado de la conversación. |
| P2-06 | **MEJORAR_PLAN** | Sí | Implementa C1-37 = B (4-1; yo voté la doble capa). El motivo nuevo, el doble conteo medido de 48 contra 24 en PC-02, es evidencia que la mayoría podía usar, y reabre R-C07 con nota en R-C07 mismo. La condición de la clave (C1-37-clave = A) vale en cualquier orden. Falta una cosa: R-C07 ubicaba el **limitador de concurrencia** entre la caché y `UseFunctionInvocation`, y la cadena nueva de M8 no lo nombra. P-03 (M9) lo reformuló como `AddRateLimiter` con 503 y `Retry-After`, y la nota tiene que decir dónde queda, para que M8 y M9 no se lean como contradictorios. |
| P2-07 | **APLICAR** | Sí | Implementa C1-59 = A y C1-28 = A, con M13 en `Examples/08` por C1-48 = A. Así resuelve el «Estado» condicional de BIT-16-04 (l. 645). Es coherente con ESC-05 (riesgo dominante: exposición sin control de acceso), con la especificación MCP 2025-06-18 (Origin MUST) y con P-15 (MCP como adaptador de entrada, catálogo único). M7 cita la ley con URL y fecha, y ResDAC queda rotulado como práctica, no como norma. |
| P2-08 | **MEJORAR_PLAN** | Sí, pero incompleta | Implementa C1-61 = A y C1-45 = A (re-registro del dictamen §3.2) y es coherente con P2-01 (las credenciales no van en el cuerpo). Le falta cerrar el diferimiento **D** de P-39 en `05-Aplicacion` («`Proveedor` en `Demos/` y R-C14 en `Examples/06`: diferidos») y anotar R-C14, que sigue afirmando el selector en la composición. |
| P2-09 | **APLICAR** | Sí | No tiene ítem votado: reemplaza lo supuesto por lo medido (PC-04, PC-06, con la versión del servidor y la fecha) en las resoluciones donde nació (R-C08, MI-18). Entra en el mandato del dictamen §3.3 (consulta dirigida con experimentos) y en la regla 0.2 de prelación. No cambia ninguna decisión: P-20 y P-19 quedan, con el dato corregido. |
| P2-10 | **APLICAR** | Sí | Coherente con DC-06 (sólo «Qwen»), con la tensión 4 y P-24 (el 4b sigue provisional) y con el dictamen §4: el segundo servidor queda como apoyo de la mesa, bajo demanda, y la guía lo nombra sólo como «estación de laboratorio con más núcleos». Pasar el apagado a la presidencia no contradice §4, que no fijó apagado. El rótulo no dice «mejor»: dice en qué pedido difiere, con R-LLM-3e. |
| P2-11 | **APLICAR** | Sí | Es P-38 (MI-16 re-registrado NO_PROCEDE de la propuesta), con las cifras de costo de PC-08 como dato y no como compuerta. Coherente con la tensión 6, que deja la evaluación continua con umbral en CTX-PROD. |
| P2-12 | **APLICAR** | Sí | Reemplaza un campo hipotético por uno real del caso único (I-06, RD-PO-1). La precondición de principales distintos es coherente con el aislamiento por `SessionId` (R-C04/P2-05) y con M14 sin herramientas de escritura (P2-03). `Examples/11` no vuelve (P-44). |
| P2-13 | **APLICAR** | Sí | Reemplaza P-24 (2) y el N ≥ 96 de P-02 con fuente (AH-02, PC-10). El texto viejo queda a la vista y se reemplaza por nota, sin borrarlo. La tensión 1 conserva «A por defecto por diseño», y la réplica de EA-6 se suma como tasa de un pedido. MI-24 NO_PROCEDE es coherente con R-C20 y R-PO-7 (no hay umbral sin métrica). |
| P2-14 | **APLICAR** | Sí | Las definiciones se fijan en los núcleos donde nacieron (N1 §2.13, N4 §2.1/§2.2/§2.9, N6 §2, N0b D-07), con fuentes fechadas. D-07 no cambia de decisión: sólo renombra las alternativas. Dejar «Workflow» esperando a C1-32, con una marca que impide el cierre, respeta que la presidencia todavía no decidió. Esto no es un disparador de REED-16 §12. |
| P2-15 | **APLICAR** | Sí | Confirma P-34 sin cambiarlo y dice qué levanta cada bloqueo. Coincide con mi voto de C1-36: un S1 bloquea lo que deriva de él, no la redacción en general, y «validado» y el cierre siguen bloqueados como pide REED-16 §6.2. |

## Mejoras pedidas

### P2-02 — agregar destinos donde nació el perímetro

Sumar a «Destino» y a «Texto exacto», con el encabezado de esta ronda:

1. **BIT-16-04 §4, R-C13:** «Con C1-55 = B, la demo registra un solo adaptador de `IAyuda` (`AyudaContextoFijo`, escalón 0). El puerto queda, y el segundo adaptador (`AyudaRag`) con el mismo oro vive en `Examples/05`. Reemplaza "dos adaptadores elegidos por configuración" para la demo; C-9/D-04 (c) "RAG como variante" se lee como variante de `Examples/05`.»
2. **BIT-16-04 §4, R-C16:** «Con C1-56 = B, el candidato "buscar el requisito por significado" queda resuelto como pieza de `Examples/04`, no del recorrido de la demo; la fila N6 de `03-Marco` §4.1 queda como dice P2-02.»
3. **BIT-16-04 §6.2, una sola nota consolidada** (el diagrama es el único de la guía, y la guía lo redibuja desde esta nota): `MCP` sale de Presentación y pasa a `Examples/08` (P2-02, P2-07); `AyudaRag`, la recuperación (`RET`), `IngestaDeRequisitos` e `IAlmacenDeRequisitos` pasan a `Examples/04` y `05` (P2-02; la nota de P-15 (2) se lee para esos ejemplos); `PROV` deja de ser un selector de la demo (P2-08); `TOOLS` pasa a «sólo lectura; las escrituras como `AccionPropuesta` validada y operación normal de la API» (P2-03); `PIPE` toma el orden de P2-06; `AGT` se marca según lo que la demo use después de P2-03 (sin aprobación integrada), o pasa a `Examples/07`; y el párrafo «lo que el lector tiene que llevarse» (2)–(4) se lee con esos cambios (la persona confirma toda escritura **con la operación normal**; la recuperación y el proveedor por configuración, en los ejemplos).
4. **Verificación adicional:** las tres notas existen; el diagrama de la sección de arquitectura de la guía no tiene `/mcp`, `AyudaRag`, `VectorStore` ni `ApprovalRequiredAIFunction` dentro del recuadro de la demo; las piezas de ejemplos se dibujan aparte y con su rótulo.
5. **La aprobación deja escrita la lectura del streaming** (verificación de P2-02): adopto la lectura de P2-02. `Examples/02` es el ejemplo dedicado, y la demo conserva `EventoDelAsistente` con `TextoParcial` (P-14, P-40 firmes).

### P2-06 — ubicar el limitador

Sumar a la nota de M8 y R-C07: «El limitador de concurrencia de R-C07 sale de la cadena del `IChatClient`. Es el de P-03 (M9): `AddRateLimiter` sobre el endpoint, con `PermitLimit`/`QueueLimit` por configuración y 503 con `Retry-After`. Si la aplicación lo mantiene también dentro de la cadena, la nota dice en qué posición queda y la prueba (2) de P-03 lo verifica en esa posición.» El nodo `PIPE` de §6.2 lo cubre la nota consolidada de P2-02.

### P2-08 — cerrar el diferimiento de P-39

Sumar a «Destino»: (1) **BIT-16-04 §4, R-C14**, nota: «el selector `AI:Proveedor` y la prueba de R-C14 con dos proveedores falsos viven en `Examples/01` y `06`; la composición de la demo registra un solo proveedor; Application no cambia en ninguno de los dos casos»; (2) **`05-Aplicacion`, fila P-39**, nota que cierra la D citando P2-08. Verificación adicional: `grep -n "R-C14"` en BIT-16-04 con la nota a la vista.

## Nota para la presidencia

- Ningún parche pide ESCALAR: ninguno cambia el alcance de REED-16 ni toca el caso único.
- C1-32 («workflow») sigue elevado y es la única dependencia abierta que bloquea el cierre (marca `[C: término de C1-32]`, P2-14).
