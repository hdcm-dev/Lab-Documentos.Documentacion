---
doc_id: BIT-16-MESA-C2-00b
doc_type: revision-adversarial
title: Ciclo 2 · Abogado del diablo: revisión de los NO_PROCEDE y de los no aplicados del ciclo 1 (M§9)
version: v1
status: para la presidencia
origin: agent (abogado del diablo; no vota, no edita lo votado)
last_review: 2026-10-26
traces: [BIT-16-04 v1, BIT-16-MESA-C1-03, -04, -05, -06, -07, -08, BIT-16-MESA-C2-00, I-02, I-06, M§5.5, M§9]
---

# Ciclo 2 · Abogado del diablo: NO_PROCEDE, no aplicados y los tres cambios más caros

**Mandato** (M§9, «consenso vacío»): con un jurado que votó 94 de 94 ítems por unanimidad, revisar si el único `NO_PROCEDE` (PR-07) y lo que de hecho no se aplicó se descartaron con fundamento o por inercia. Además, atacar los tres cambios más costosos aprobados en el ciclo 1.

**Alcance y no duplicación.** La auditoría de homogeneidad (`00-Auditoria-Homogeneidad.md`) ya cubre X-007, X-008, X-002, los votos `MEJORAR_PLAN` que no volvieron a auditoría, H-004, H-008 y el «11 a 200 s» de PAR-10. Acá no se repiten: se remite a ella. Este informe agrega lo que esa auditoría no ve.

**Niveles de evidencia.** E1 = lo corrí o lo leí en la fuente primaria (código del caso base en `8fb4c3a`). E2 = texto de la bitácora o del plan, con línea. Los cálculos se derivan de cifras del propio plan y se muestran. Lo que no está probado va como pregunta.

## 0. Qué se revisó

| Objeto | Estado en el ciclo 1 | Revisado acá |
|---|---|---|
| PR-07 (`NO_PROCEDE` 0-5-0) | NA del plan, sin parche | §1 |
| `NO_APLICAR` | **Ninguno** (`06-Aprobacion.md` l. 45). No hay un rechazo formal que revisar | — |
| No aplicados de hecho | (a) colisión «nivel A/B», diferida (`07-…` §4); (b) exclusiones de §E.4; (c) X-008 y X-002 (auditoría §2.2); (d) «imprecisión» de PAR-17, sin identificar (auditoría §5); (e) Operación y entrega, postergada por cupo (`01-Convocatoria.md` l. 43) | (a) y (b) en §2; (c) y (d) remitidos; (e) ya está en la convocatoria de este ciclo |
| Los tres cambios más costosos | Según el campo «Costo» de `05-Parches.md`: **PAR-14** (el único «alto», l. 643), **PAR-13** (medio; la mayor cantidad de artefactos nuevos de construcción: tres proyectos `_Comun`, arnés, escritor R-LLM, capa de opciones y guarda de truncado, l. 589) y **PAR-17** (medio: middleware `/mcp`, armado del pedido, almacén de conversaciones y cuatro pruebas de aislamiento, l. 758). PAR-19 (tres scripts y dos listas) queda cuarto y no se ataca | §3 |

## 1. PR-07: el rechazo vale por la letra, pero la intención no está cubierta

**Lo que pedía.** I-02 l. 69: «**Revisar si** el primer agente de la guía (el más sencillo) debe actuar sobre un sistema familiar para el lector y externo a la demo (p. ej. el repositorio local por git o un servidor MCP de ejemplo), para que el patrón se entienda **antes de mezclarlo con el dominio**». Es una pregunta con dos ejemplos, no una especificación.

**Los tres fundamentos del rechazo, uno por uno:**

| Fundamento (`04-Veredictos.md` l. 108; `03-Consolidacion.md` l. 227) | Veredicto del abogado | Evidencia |
|---|---|---|
| RD-PO-1 / I-06: el único caso práctico es Movilidad Urbana | **Se sostiene** para los dos ejemplos literales. Un agente sobre git sería un segundo caso práctico. RD-PO-1 es vinculante y no se vota | I-06 §1, RD-PO-1 (E2) |
| «Suma dependencias de ejecución no sondeadas» (desarrollo, `02-Informes/desarrollo.md` l. 59; juez de costo-beneficio) | **Se sostiene sólo para git.** Para el «servidor MCP de ejemplo» es falso: `ModelContextProtocol` 2.3.0 está sondeado (N4 §3.1, N6 E1) y el plan lo usa en 13 | plan v1 l. 585 (E2) |
| «La intención la cubre PR-20: una herramienta de sólo lectura **sobre catálogos y localidades**, que el lector ya conoce por §0.3» | **No se sostiene en la v1.** El 08 de la v1 no trabaja sobre catálogos: sus herramientas son `listar_localidades` y `contar_localidades` sobre `LocalidadService`, con `_Comun (Persistencia)` (EF Core Sqlite), la sesión puesta por el código, dos sesiones en paralelo, 4 negativas y un oráculo por regex. `Catalogos` sólo aparece para validar el argumento de provincia. El primer contacto con tool calling llega cargado con persistencia, sesiones y aislamiento: es justo la mezcla con el dominio que PR-7 quería evitar | plan v1 l. 543 (§D) frente a l. 634 (fila 08) (E2) |

**Inercia comprobable.** Los cinco jueces y los cinco informes que opinaron repiten el mismo par «RD-PO-1 + lo cubre PR-20/05». El abogado del diablo del ciclo 1 lo cuenta entre «los rechazos bien fundados» (`02-Informes/abogado-del-diablo.md` l. 166) y nadie confrontó la frase de cobertura con la fila 08 que reescribió PAR-14. El motivo de §D se escribió en la v0 y no se revalidó después del parche.

**Hay una salida dentro del dominio, que nadie consideró.** `Catalogos` del caso base es una clase estática sin persistencia ni sesión. Es E1: `src/MovilidadUrbana.ApiWeb/Domain/Catalogos.cs` en `8fb4c3a` (`public static class Catalogos` con `Provincias`, `Medios`, `Frecuencias` y `Motivos` como listas fijas). Una herramienta pura sobre esa clase (por ejemplo `listar_provincias()` o `medio_de_transporte(texto) → clave`) muestra el patrón «el modelo pide, la app ejecuta» sin base, sin sesión y sin negativas de aislamiento. Además cumple RD-PO-1 al pie de la letra. El lector ya conoce el catálogo por 04.

**Propuesta.** (1) Mantener `NO_PROCEDE` para el sistema externo: RD-PO-1 manda. (2) Abrir un ítem nuevo en el ciclo 2, **PR-07b**: un «paso 0» de 08 (o una sección mínima de §8.2 antes de §8.3) con una herramienta pura sobre `Catalogos`, en `--fake` más M = 3 entradas. Costo estimado: unas 6 llamadas (3 entradas × 2 peticiones, igual que en 08), que a 60/200 s son 6/20 min de `<recurso-compartido>`. (3) Corregir el fundamento de la fila PR-7 en §D, que hoy dice «sobre catálogos y localidades» y no es cierto de la v1.

## 2. Lo que de hecho no se aplicó

### 2.1 La colisión «nivel A/B»: se difirió con una regla que la secretaría no se aplicó a sí misma

`07-Aplicacion-Y-Verificacion.md` l. 77 no corrige la colisión porque «cambiaría texto aprobado de PAR-14, PAR-15 y PAR-19». Pero en la misma aplicación, AJ-05 (l. 32) cambió texto aprobado de PAR-03, PAR-05, PAR-08 y PAR-11: recortó las preguntas guía de §10 y §12 a 5 y asignó OA. AJ-01 a AJ-04 también tocaron texto aprobado (E2). La regla se aplicó en un caso y en el otro no. Las dos salidas coherentes son ratificar todos los AJ o ninguno. Para la colisión, el arreglo es un renombre mecánico (T-A/T-B/T-C en §E.5, en la columna «Turno» de §E.2 y en AC-3b) con riesgo nulo. Diferirlo no protegió nada y dejó en la v1 un término con dos sentidos dentro de un criterio de cierre (AC-3b dice «ejemplo de nivel A de §E.5»).

**Propuesta.** Votar T-A/T-B/T-C en el primer bloque del ciclo 2, junto con la ratificación de AJ-01…AJ-08, con la misma regla para todos.

### 2.2 §E.4 (d): la exclusión del multiagente del escalón 3 cita un motivo que no es

`04-Plan-De-Integracion.md` l. 658: «Multiagente del escalón 3 (handoff, Magentic): conceptual, sin ejemplo (RD-PO-3; §B.3)». Pero RD-PO-3 (I-06 §1) habilita la explicación conceptual sólo «si una idea no encaja en ese dominio», y nadie argumentó que un handoff no encaje en Movilidad Urbana. Un agente de localidades que deriva a uno de encuestas encaja sin forzar nada. §B.3 (l. 275) tampoco da un motivo de exclusión. El motivo real, que el plan no escribe, es de costo y de riesgo: turnos de `<recurso-compartido>` (§E.5) y la selección entre varias herramientas en Qwen sin medir (R-08, DEP-10). La decisión de excluir puede ser correcta, pero hoy se apoya en una cita que no la sostiene.

**Propuesta.** Reescribir el motivo de (d): «costo de turno y R-08: con `qwen3.5:4b` la selección entre varias herramientas no está medida (DEP-10)». Y dejar como pregunta, no como cambio: si DEP-10 da al menos 3 de 5, ¿un handoff mínimo entra en el nivel de turno B?

### 2.3 Remitidos

- X-008 (variante RAG eliminada contra lo que pedían J2 y J4) y X-002 (juez en Ollama propio «no planificado»): auditoría §2.2 y §4, puntos 2 y 11.
- La «imprecisión menor» de PAR-17 que el juez de evidencia nunca detalló: auditoría §5. En §3.3 este informe ataca PAR-17 por otro lado.
- Operación y entrega, postergada por cupo cuando el techo ya se había pasado en 3 por pedido del PO y por AH-02 (`01-Convocatoria.md` l. 43). Seis informes la pidieron. Con lo de §3.1 se ve que el tema que dejó sin dueño (el presupuesto de turnos) es justo el más frágil de la v1. Su convocatoria ya está en este ciclo.

## 3. Los tres cambios más costosos

### 3.1 PAR-14 (con PAR-15): el aparato de medición no entra en el presupuesto que el mismo plan fija

PAR-14 le da a 11 ejemplos un conjunto de M entradas, una tasa k/M con intervalo Clopper-Pearson y un registro R-LLM. Con la estimación que la secretaría corrigió en AJ-02, el plan no se puede cumplir en el escenario pesimista **ni siquiera con la prioridad que AJ-03 agregó para salvarlo**. Cuentas con las cifras del propio plan (l. 662–671, E2):

| Conjunto prioritario de AJ-03 | Llamadas | t pesimista (AJ-02) | Horas |
|---|---|---|---|
| PD-1…PD-6 (6 × 2) + 07 chat (16) | 28 | ≥ 475 s («07, 11 y PD-n») | 3,69 h |
| 08 (8 × 2) + 09 (5 × 3) | 31 | 200 s | 1,72 h |
| **Subtotal de la prioridad** | 59 | | **5,42 h** |
| Sondas DEP-03, -09, -10 y -13, que van antes de construir | 20 | 200 s | 1,11 h |
| **Total** | 79 | | **6,5 h frente a un tope de 4 h** |

Con t nominal (60 s) el conjunto da 1,3 h y entra. El problema es que AJ-02 dice que el pesimista «subestima» las llamadas largas y lo sube a 475 s, y con eso la línea de corte ya no alcanza.

A la vez, el propio plan dice que esas tasas no deciden nada: «Las tasas son informativas (sin umbral)» (AC-3b, l. 818), y «10/10 es compatible con 69 %; 5/5, con 48 %» (§E.1). La construcción gasta la mayor parte del turno en cifras que la guía declara no interpretables. Lo que sí sostiene la tesis de la guía son las **garantías del código** (AC-4, 100 % en toda corrida), y esas se prueban en cableado, sin modelo.

**Ataque.** H-001 (la entrada distinta como unidad de muestra) estuvo bien votado, pero responde *cómo* medir, no *si* cada ejemplo tiene que medir. Que los once ejemplos midan lo agregó PAR-14, y nadie pesó ese costo (la auditoría, §1.4, ve el mismo patrón en H-001).

**Propuesta para votar, sin reabrir H-001.** Separar dos clases de ejemplo:
- **Demostración** (01, 03, 04, 08, 09, 11 y los PD-n): 1 o 2 entradas observadas, con el rótulo de laboratorio, más las garantías de código en cableado. Sin tasa.
- **Medición**, donde medir es la lección: 06 y 07 (hit rate y oráculo de la afirmación central), 15 (calibración) y 16 (inyección).

Una cota de la variación: si 01, 03, 04, 08, 09 y 11 pasan de su M a 2 entradas, el nivel A pierde unas 46 llamadas (01 −4, 03 −6, 04 −6, 08 −12, 09 −9, 11 −9, con el número de peticiones por entrada de §E.5), y la estabilidad baja de 24 a 9 llamadas. La cifra exacta la tiene que dar el juez de costo-beneficio con el t por ejemplo de DEP-13.

### 3.2 AJ-03 contradice AC-3b (contradicción nueva, S2)

AJ-03 (l. 671) dice: «lo que exceda el tope pasa a "no ejecutado contra el modelo", sin cifras y como deuda, **igual que el nivel B**». AC-3b (l. 818) dice: «Cada PD-1…PD-6 y cada ejemplo **de nivel A** de §E.5 tiene **al menos un registro R-LLM válido** […] Una corrida saltada **no** cierra». La deuda declarada está prevista sólo para el nivel B. Con §3.1, el escenario pesimista deja ejemplos del nivel A sin correr. Entonces, o la construcción no puede cerrar nunca, o AJ-03 baja en silencio ejemplos del nivel A al régimen del B. Ninguna de las dos está escrita. Esto nació en la aplicación y el chequeo de coherencia de `07-…` §4 no lo detectó.

**Propuesta.** Al ratificar AJ-03, reescribir AC-3b con la regla única de AJ-03: lo que excede el tope pasa a deuda declarada en cualquier nivel, y PD-1…PD-6 nunca. Si PD-n tampoco entra, que se escale como alcance y no como deuda.

### 3.3 PAR-13: dos copias del dominio y una regla que no se puede verificar como está escrita

PAR-13 (plan l. 572) fija: «`Examples/_Comun/MovilidadUrbana.Dominio/Domain` es idéntico a `Demos/…/Domain` (`diff -r` vacío salvo los namespaces)». Hay dos problemas (E2):
1. **Dos copias mantenidas a mano** del mismo `Domain` endurecido, con una regla que obliga a sincronizarlas. Es una segunda fuente de verdad que se cuida con un chequeo en lugar de eliminarse.
2. **La verificación no corre tal cual.** Si los namespaces difieren (`MovilidadUrbana.Dominio` frente a `MovilidadUrbana.Asistente.Domain`, l. 572 y l. 214 de PAR-03), `diff -r` sale distinto en cada archivo. «Vacío salvo los namespaces» necesita una normalización que nadie definió.

**Pregunta para senior .NET y arquitectura.** ¿Por qué la demo no referencia el mismo `MovilidadUrbana.Dominio` por `ProjectReference` relativa, como ya lo hacen los ejemplos? Si hay un motivo (por ejemplo, ADR-11: «capas como carpetas de un ensamblado», fiel al caso base), hay que escribirlo, y la verificación tiene que ser un script con la normalización explícita (`sed` del namespace y después `diff -r`).

### 3.4 PAR-17: el almacén de conversaciones de la API duplica 11 y descansa en una API sin sondear

PAR-17 (plan l. 771) agrega `IAlmacenDeConversaciones` (memoria, clave sesión + conversación, vence a los 15 min) y la serialización con `SerializeSessionAsync`, sólo para que PD-6 funcione **por la API** en dos peticiones. Pero:
- `SerializeSessionAsync` hoy «sólo se conoce por el XML» (DEP-11, l. 870). La confianza de ADR-12 es «media hasta la sonda DEP-11» (l. 497).
- En Blazor, la `AgentSession` vive en el estado del circuito y no necesita serializarse (l. 771).
- El ejemplo 11 ya enseña la serialización entre dos peticiones (fila 11 de §E.2).

**Pregunta para el ciclo 2 (no es una afirmación).** ¿Hace falta PD-6 en la API, o alcanza con la página Blazor, donde el estado del circuito resuelve la conversación sin tocar DEP-11? Si la API se mantiene, el plan tiene que decir qué pasa si DEP-11 falla. Hoy no hay respaldo escrito para la API, aunque sí lo hay para 09 («si DEP-09 falla, la aprobación se enseña en 11»).

## 4. Resumen para la presidencia

| # | Ítem | Severidad | Pedido |
|---|---|---|---|
| 1 | PR-07: cobertura de la intención falsa en la v1 | S3 | Mantener `NO_PROCEDE`; abrir PR-07b (herramienta pura sobre `Catalogos`); corregir el texto de §D |
| 2 | PAR-14/PAR-15: la prioridad de AJ-03 da 5,4 h pesimistas (6,5 h con las sondas) contra un tope de 4 h | S2 | Votar la separación entre demostración y medición; J3 con cifras de DEP-13 |
| 3 | AJ-03 frente a AC-3b | S2 | Una sola regla de deuda; PD-n fuera del recorte o escalada |
| 4 | Colisión «nivel A/B» diferida con doble criterio | S3 | T-A/T-B/T-C junto con la ratificación de los AJ |
| 5 | PAR-13: `Domain` duplicado y `diff -r` no ejecutable tal cual | S3 | Referencia única o script con normalización |
| 6 | PAR-17: almacén de la API atado a DEP-11, que nadie sondeó | S3 | Pregunta: ¿PD-6 sólo en Blazor? Si no, escribir el respaldo |
| 7 | §E.4 (d): RD-PO-3 citado como motivo | S4 | Reescribir el motivo; dejar el handoff como pregunta sujeta a DEP-10 |

**Lo que revisé y se sostiene:** el `NO_PROCEDE` de PR-07 en su forma literal (RD-PO-1); §E.4 (e), que no suma una credencial al repo público (P-13, coherente con la regla de repos públicos); la ausencia de `NO_APLICAR`, que es un hecho del registro (`06-…` l. 45) y no esconde rechazos. Lo no aplicado de hecho está trazado en el cierre como deuda.

ESC-001 no se reabre: rige el default B (SUP-09).
