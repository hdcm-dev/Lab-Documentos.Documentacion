---
doc_id: BIT-16-MESA-C3-02-DESARROLLO
doc_type: informe-de-especialista
title: Ciclo 3 · Informe del desarrollador de código (pedido del PO)
version: v1
status: entregado (a ciegas respecto de los demás informes del ciclo 3)
origin: agent (especialista Desarrollo)
last_review: 2026-10-26
objeto: BIT-16-04 v2 (04-Plan-De-Integracion.md), ESTRUCTURA APROBADA v2
traces: [BIT-16-04 v2 §E.1, §E.2, §E.5, §F.1, §G.3, §G.4; BIT-16-MESA-C2-06 §2.1, §2.4, §2.6, §2.8; BIT-16-MESA-C2-09 §3; Sondeo-Entorno; <gestor-de-turnos> (sólo lectura)]
---

# Ciclo 3 · Desarrollo

Mandato: RV-03 (tope y fórmula de clases), factibilidad final de TURNO-1/2/3, DEP-12, arnés: qué se puede construir de verdad.

## 0. Observaciones E1 tomadas hoy (2026-10-26, sólo lectura)

- **Gestor de recursos** (`<gestor-de-turnos> estado`, `<gestor-de-turnos> salud`, lectura del script): `[recurso-modelo-propio]` existe con cupo 1 y ttl 60 min (arreglo `TTL`, l. 24), figura en la lista `TODOS` (l. 46), tiene rama de salud (l. 254–258) y `renovar` existe (l. 173–179; ttl máximo 240 min, l. 107). Un recurso sin ttl ya no aborta (l. 26–33). Salud: `[recurso-modelo-propio]: {"version":"0.40.11"} modelos=qwen2.5:0.5b@a8b0c5157701,qwen3-embedding:0.6b@ac6da0dfba84 qwen3-embedding_con_capacidad_embedding=True`. El comentario del script dice que el contenedor es el contenedor del Ollama propio del gestor, **en otra máquina, sólo por la red privada del laboratorio** (l. 55). **DEP-14 está resuelta**: los cuatro puntos de la objeción de J5 a PAR2-25 (06-Aprobacion §2.8) se cumplen. Rige **EMB-B**. Las direcciones no se transcriben (R-PRIV).
- **Servidor compartido**: `GET /api/version` = 0.32.0-rc0; `/api/tags` lista `qwen3.5:4b` con digest `2a654d98e6fb` (el del plan); **`GET /api/ps` = `{"models":[]}`**: no hay ningún modelo cargado. `<gestor-de-turnos> salud <recurso-compartido>` lo confirma («cargados: ninguno»).
- **Protocolo** (`PROTOCOLO.md`): «Llamadas sueltas cortas a <recurso-compartido> (< 1 min, un prompt) van sin turno». Otras sesiones pueden llamar al servidor, con cualquier modelo, mientras esta corrida tiene el turno.
- **Registro del gestor**: la máquina del Ollama propio aloja además dos emuladores Android reservados a otras sesiones (`emulador-gda`, `emulador-fc`) y una VM del PO que «no se toca ni se ahoga» (script, l. 50–52).
- **Caso base** `8fb4c3a`: `Catalogos.Provincias` tiene 7 provincias; `Medios` 6, `Frecuencias` 3, `Motivos` 4.

## 1. Posiciones sobre la agenda

### RV-03 · tope de horas y clases de t → **(b) 6 h**, con M = 135 s y la compuerta 15a/15b

Fórmula de AJ-02: con p = 1.000 y s = 100, t = 1.000/9,4 + 100/4 = 106,4 + 25 = **131,4 s** (la objeción de J1 es aritméticamente correcta). El juez de M.E.AI.Evaluation devuelve razonamiento y puntaje, no un número solo: s ≤ 50 no tiene respaldo, así que M = **135 s, E3**, hasta que se mida (H-04). 15 completo cuesta 52 × 135 = 7.020 s.

Con el TURNO-1 corregido (H-01: PD-1 son 2 entradas, +950 s) y una carga en frío (H-02, +80 s), TURNO-1 da **13.430 s ≈ 3,73 h**:
- **4 h** (14.400 s; 90 % = 12.960 s): TURNO-1 pasa el 90 %. La línea de corte saca la estabilidad (−240) y sigue arriba (13.190); saca DEP-10 (−2.850) → 10.340 s. Se construye, pero sin la única sonda de varias herramientas que mitiga R-08, y el contrato de 08, 09, 11 y PD-6 pasa a `eliminar_localidad(nombre, provincia)`. TURNO-2 llega a 13, 17, 12, 03 ext., 04 ext. y 15a (1.350 s), con 70 s de sobra.
- **6 h** (21.600 s): TURNO-1 completo (62 %), DEP-10 adentro; TURNO-2: 13, 17, 12, 03 ext., 04 ext. (2.640 s) y 15a (1.350 s) → quedan 4.180 s; 15b (5.670 s) y 16 (7.200 s) no entran; 08 ext. (3.200 s) entra sólo si la regla permite saltar (H-05).
- **9 h** (32.400 s): todo TURNO-2 si 15b corre (13.430 + 2.640 + 7.020 + 7.200 + 3.200 = 33.490 s, **no entra**: 08 ext. queda afuera); con 15b descartado por 15a, sí.

Fundamento: la opción (b) es la única que conserva DEP-10 sin forzar el cambio de contrato. «Con 6 h, hasta 15» deja de ser cierto con 135 s (6.833 a 7.020 s > 6.560 s disponibles): la tabla de «Qué entra» se rehace con estos números. Si el jurado prefiere no pedir más horas al servidor compartido, la opción (a) es construible, pero el plan debe decir de antemano que DEP-10 sale.

### Compuerta 15a/15b (objeción de J3 a PAR2-09, §2.4 (1)) → **adoptar**

15a: 10 casos de calibración con un evaluador (10 llamadas M, 1.350 s); 15b sólo si 15a llega a 8/10. Con cualquier tope, 15a entra y 15b no: la compuerta es lo que hace que 15 produzca algo. Se ahorran 5.670 s si el juez cae.

### DEP-12 → **partirla: queda sólo el pinning de transitivos; sale el SSE; deja de bloquear PD-1**

E1: §F.1 dice «la API … no tiene ruta de chat» y la página Blazor Interactive Server transmite por su circuito (SignalR), no por SSE; ningún controller del plan devuelve `TypedResults.ServerSentEvents` (§F.2, fila Controllers). Texto propuesto: «DEP-12 · `dotnet list package --include-transitive` con el pinning de transitivos activo (cierra X-005) · Constructores, primera compilación · AC-6». La columna «Bloquea» pierde PD-1.

### DEP-14 / ESC-001 → **EMB-B vigente desde hoy, con evidencia E1** (§0)

La presidencia puede registrarlo en `08-Cierre.md` del ciclo 3 con la salida de `<gestor-de-turnos> salud [recurso-modelo-propio]`, sin las direcciones. Consecuencia en el plan: H-03 (provisión e inventario).

### RV-11 · juez → **(a) sesgo declarado**

La opción (b) dependía de DEP-14, que ya está resuelta, pero el Ollama propio sólo tiene modelos Qwen (`qwen2.5:0.5b`, `qwen3-embedding:0.6b`): no hay juez de otra familia. El compartido tiene `gemma4:e4b-it-qat`, pero usarlo cambia el modelo residente (R-04). Para (b) habría que pedirle al gestor un modelo más, sin presupuesto. Se mantiene (a).

### H2-056 · fusiones → **F1 no, F2 no, F3 sí**

- F1 (01 + 02): 01 corre en el compartido (TURNO-1) y 02 en el propio (TURNO-3). `ejemplo.json` tiene un solo `recurso` (§E.1, contrato por ejemplo) y ninguna fase pide dos recursos (orden global). Con la fusión, el ejemplo no tiene una fase donde correr. Ahorro: 0 llamadas.
- F2 (06 + 07): ahorra una fase de embeddings (del orden de 30 vectores con un modelo de 0,6B), pero 06 compara contra las líneas base con la regla pareada (§10.4) y mezclarlo con la generación ensucia lo que mide. Ahorro chico, costo didáctico.
- F3 (14 opcional): 0 llamadas, sin costo de construcción.

### H2-054 · recorte de pasos de la demo → **todos los pasos en `--fake` (costo 0); contra el modelo, PD-1, PD-5 y PD-6; PD-2, PD-3 y PD-4 sólo en cableado**

La respuesta 1 de la presidencia lo habilita. PD-5 y PD-6 prueban algo que 09 y 11 no prueban: el pedido pendiente guardado en el estado del circuito y la respuesta de aprobación armada en el servidor (AC-4, `Aprobacion_ArgumentosAlterados_SeRechaza`) dentro del host. PD-1 prueba el conjunto completo de herramientas compuesto en el circuito. PD-2/3/4 (K, 80 s cada uno) repiten la conducta de 07/03/04 y su composición ya la cubre el cableado: el ahorro es de 240 s, menor que la incertidumbre de la fórmula, así que la razón es simplificar y no ahorrar. PD-7 sigue sin modelo.

### P-12 / DEP-15 → **«cumple» para 16, la siembra y las entradas sintéticas; para 05, la variante intermedia**

Desde la construcción: 05 **no mide calidad**, sólo tiempos de prefijo (§E.2, fila 05). Su corpus sólo tiene que pesar unos 4.700 tokens y ser estable byte a byte. Puede salir entero del dominio real: los 12 literales de `*Policy` × las 7 provincias de `Catalogos` (84 fragmentos de unos 55 tokens, ≈ 4.600 tokens, E3) más las etiquetas de los catálogos. No hacen falta «localidades ficticias» y la medición no pierde nada. 16, la siembra y las entradas de 04/PD-4/12 no tienen fuente real posible (el caso base no trae texto libre ni respuestas sembradas): sin «cumple», 12, 16 y la pregunta de encuesta de PD-1 pasan a `--fake` (§G.4 P-12).

### CTX-NUEVA / CTX-EXISTENTE → **a favor, sin costo de construcción**

No cambia código, turnos ni manifiestos. La demo ya es CTX-EXISTENTE de hecho (copia de `8fb4c3a` más delta de §F.2, AC-10).

### Arnés · qué se puede construir de verdad

Construible con lo que hay: `verificar.sh` en el host con bash y docker; fases `build` → `[recurso-modelo-propio]` → `<recurso-compartido>`; medidor en `turnos.jsonl`; `TURNO_CMD` = `<gestor-de-turnos>` (envuelve y libera aunque el comando muera, `PROTOCOLO.md`). Hay que renovar: TURNO-1 dura unas 3,7 h y el ttl es de 45 min (renovable, máximo 240 min por concesión). Lo que no se puede construir tal como está escrito son los puntos H-02 y H-03.

## 2. Hallazgos nuevos

| ID | Ubicación | Afirmación | Nivel | Sev. |
|---|---|---|---|---|
| H-01 | §E.5 TURNO-1, fila PD-1; §F.1 PD-1 | PD-1 se presupuesta como 1 entrada y 2 llamadas L, pero §F.1 le asigna dos preguntas con herramienta (conteo y encuesta) y el ejemplo hermano aplica el oráculo de 12 «sobre la corrida de humo». Son 2 entradas y 4 llamadas L (1.900 s y no 950). TURNO-1 pasa a 13.350 s, por encima del 90 % de 4 h (12.960 s) | E1 (aritmética del propio plan) | S2 |
| H-02 | §E.1 `num_ctx`, regla «compartido» | El arnés aborta si `/api/ps` no lista el modelo, pero hoy `/api/ps` está vacío: TURNO-1 no arranca. Y como el protocolo deja hacer llamadas sueltas sin turno, otra sesión puede descargar `qwen3.5:4b` a mitad de la suite. Ninguna carga en frío está presupuestada | E1 | S2 |
| H-03 | §E.1 «Provisión» y variables; §E.6; §F.6; R-02 | El plan provisiona un contenedor local `<ollama>` (volumen, red `<red-del-arnés>`, `ollama pull` del arnés) y lo borra al cerrar. El recurso real es el contenedor del Ollama propio del gestor, en otra máquina, del gestor, por la red privada del laboratorio, con los modelos ya cargados. El arnés no es su dueño: no puede borrarlo y el contenedor del SDK no lo alcanza por nombre | E1 | S2 |
| H-04 | §G.3 DEP-13; §E.5 clase M | DEP-13 calibra K (2 llamadas), H (de DEP-09) y L (de DEP-10), pero ninguna llamada M: el costo de 15, la pieza más cara de TURNO-2, queda sin medir antes de correrla | E1 | S3 |
| H-05 | §E.5 línea de corte (3) | «TURNO-2 se corre en el orden de la tabla mientras quede tope» no dice si una pieza que no entra detiene la cola o se salta a la siguiente que sí entra. Con 6 h decide si 08 ext. (3.200 s) corre después de que 16 no entra | E1 | S3 |
| H-06 | §E.2 fila 05; §E.1 regla de tiempos | Los tiempos comparables «sólo se miden en el Ollama propio», con la única condición «sin build en curso». La máquina del Ollama propio aloja además dos emuladores Android de otras sesiones y una VM del PO, y el gestor no excluye recursos entre sí (R-02, H2-020). La carga ajena puede mover `prompt_eval_duration` y `estado_cache`, que es justo lo que mide 05 | E1 (ubicación); la contaminación es conjetura | S3 |

Direcciones propuestas:
- **H-01**: en la fila PD-1, 2 entradas, 4 llamadas L, 1.900 s; total de TURNO-1, 13.350 s (13.430 s con la carga de H-02); se rehace «Qué entra según el tope» (posición de RV-03). La otra salida es dejar como humo una sola pregunta (la de encuesta, porque el conteo ya lo cubre 08) y decirlo en §F.1.
- **H-02**: si `/api/ps` está vacío, no hay modelo ajeno que recargar. El arnés hace una llamada de precalentamiento sin `num_ctx` (para que la carga use el default del servidor), vuelve a leer `/api/ps`, exporta su `context_length` y registra `num_ctx_origen = arnes-ps-tras-carga`. Antes de cada entrada se vuelve a leer `/api/ps`: si el modelo desapareció, la siguiente llamada se marca `estado_cache: frio` y lleva su `load_duration_ms`. Se presupuesta una carga de clase K por turno, que se mide en DEP-13. «Aborta» queda sólo para el caso en que **otro** modelo esté cargado.
- **H-03**: el arnés no provisiona ni borra el Ollama propio. Toma `OLLAMA_PROPIO_ENDPOINT` del entorno (sin valor en el repo) y, dentro del turno `[recurso-modelo-propio]`, verifica `/api/version` = 0.40.11 y los digests de `/api/tags` (`a8b0c5157701`, `ac6da0dfba84`), que van al registro. En §E.6 salen las filas del contenedor, el volumen y la red del propio («dueño: gestor; la mesa no lo borra»). El contenedor y la red del compose (`ollama-embed`, §F.9) quedan para el lector. R-02 se reescribe: el propio ya no compite con `build` en la máquina de la corrida.
- **H-04**: la primera llamada de 15a sirve de calibración M. Si su t medido pasa de 135 s, se recalcula 15a/15b antes de seguir, dentro del medidor.
- **H-05**: escribir «la cola salta a la siguiente pieza que entra entera en el tope restante; ninguna pieza se empieza si su pesimista no entra».
- **H-06**: 05 registra la carga de la máquina del Ollama propio (`/proc/loadavg`) al empezar y al terminar cada par sin-prefijo/con-prefijo, y una corrida con carga por encima de un umbral (que fija DEP-03) se marca `excluida` con motivo «carga ajena». Pedir el turno de los emuladores no sirve: están reservados a otras sesiones. Queda el registro de carga y la exclusión.

## 3. Revisado y bien

- La suma de TURNO-1 (58 llamadas, 12.400 s) y de TURNO-2 (134 llamadas, 19.280 s) es aritméticamente correcta con las clases declaradas; el error de H-01 es de conteo de entradas, no de suma.
- El criterio de PAR2-25 se cumple en el gestor (ttl, lista, salud, renovación) sin cambios fuera de su perímetro: el cambio fue aditivo.
- El digest de `qwen3.5:4b` en el compartido (`2a654d98e6fb`) coincide con el del plan (§E.1), y Ollama sigue en 0.32.0-rc0: los rótulos de laboratorio siguen valiendo.
