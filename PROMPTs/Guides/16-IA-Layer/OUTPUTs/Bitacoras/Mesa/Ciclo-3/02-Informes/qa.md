---
doc_id: BIT-16-MESA-C3-02-QA
doc_type: informe-de-especialista
title: Ciclo 3 · Informe de Verificación/QA (núcleo)
version: v1
status: entregado
origin: agent (especialista Verificación/QA, a ciegas respecto de los demás informes del ciclo 3)
last_review: 2026-10-26
traces: [BIT-16-04 v2, BIT-16-MESA-C2-06, BIT-16-MESA-C2-08, BIT-16-MESA-C2-09, BIT-16-03, I-06, M§5]
---

# Ciclo 3 · Verificación/QA

Mandato: AC-1…AC-10 después del recorte; el falso positivo de AC-8; que cada papeleta tenga un criterio verificable.
Objeto: `../../../04-Plan-De-Integracion.md` (v2). Todas las mediciones de abajo se corrieron el 2026-10-26 con GNU grep 3.11 (`/usr/bin/grep`), no con el `grep` del shell interactivo, que es otro motor y da otros resultados (ver QA3-02).

## 1. Revisado y bien (E1)

- **TURNO-1 suma bien**: 58 llamadas y 12.400 s, fila por fila (§E.5). Con 4 h quedan 2.000 s, y 13 + 17 + 12 + 03 ext. suman 400 + 160 + 800 + 640 = 2.000 s: la frase «con 4 h, hasta 03, extensión» es exacta. El pesimista de TURNO-1 es el 86,1 % del tope (regla del 90 %: cumple, margen de 560 s).
- **Excepciones de AC-8 exactas**: los dos patrones de la celda AC-8 sobre `OUTPUTs/Bitacoras/` (sin el ciclo 3) dan 56 + 13 líneas. Todas las que no están en `Compuertas/rd-po-4.excepciones` caen en los seis archivos pendientes declarados de R-06 (Sondeo, N2, N4, N4-Evidencia/compilecheck, N5, informe QA del ciclo 1): 37 líneas, 0 fuera de esa lista. Ninguna excepción quedó huérfana (0 excepciones sin coincidencia). Los 5 positivos marcan 5/5.
- **Lista cerrada de AC-3b = §E.2**: «01–09, 11–13, 15–17» es exactamente el conjunto de filas con modelo (10 y 14 sin modelo).

## 2. Hallazgos nuevos

### QA3-01 · El falso positivo de AC-8 es «coincidente(s)», y uno de los dos está escondido en un archivo pendiente (S3, E1)

El patrón 1 sin borde de palabra (`reclamo|ticket|incidente|bache`, `-i`) marca **«coincidente»**, que contiene la cadena «incidente». Ocurrencias hoy: `Mesa/Ciclo-1/03-Consolidacion.md:85` (listada como excepción con un motivo que no nombra la palabra) y `Nucleos/N5-Operacion-Calidad-Seguridad.md:608` («fechas coincidentes»), que **no** está en las excepciones porque N5 figura entero como pendiente de R-06. Cuando N5 se reescriba, esa línea va a seguir marcando y alguien la va a «arreglar» como si fuera dominio ajeno o la va a sumar a mano. Y la guía, que redacta oráculos del tipo «los porcentajes coinciden con…», tiene alta probabilidad de escribir «coincidentes».

**Dirección (verificada)**: patrón 1 en PCRE con lookbehind, `grep -rniP "reclamo|ticket|bache|(?<!co)incidente"`. Medido: sobre la bitácora baja de 56 a 54 líneas (salen exactamente las dos de «coincidentes»); los 5 positivos siguen 5/5; `TipoIncidente` y `ReportarIncidente` siguen marcando. Se agrega `Compuertas/rd-po-4.negativos` («porcentajes coincidentes», «fechas Coincidentes», «la cifra es coincidente») y la compuerta **falla si marca alguna línea de ese archivo**. La excepción de `Ciclo-1/03:85` sale de la lista.

### QA3-02 · AC-7 y AC-8 pasan en vacío con la lista externa vacía o ausente, y la bitácora ya tiene una fuga R-PRIV (S1, E1)

(1) AC-7 se apoya en `$R_PRIV_LISTA` y AC-8 en `$RD_PO_LISTA`, las dos «fuera del repo» y las dos sin crear (cierre del ciclo 2). Con GNU grep, `grep -f` sobre una lista vacía devuelve rc = 1 (sin coincidencias) y sobre una lista inexistente rc = 2 con el error sólo en stderr: un script que cuenta líneas de salida da «0 hallazgos» en los dos casos. El motor que se use cambia el resultado: el `grep` del shell de esta sesión (ugrep) con lista vacía marca **todas** las líneas. Ninguna fila de §G.3 tiene a cargo esas listas.

(2) La compuerta, si existiera, hoy fallaría: `Mesa/Ciclo-2/09-Respuestas-De-La-Presidencia.md` l. 31 nombra dos máquinas de la LAN del PO (una de ellas dos veces) y la red superpuesta por la que se accede. Es «hostname de la LAN» según R-PRIV (BIT-16-00 l. 68), y el contrato clasifica la fuga R-PRIV como S1 (l. 106). No hay commit, así que todavía no salió. Este informe no repite los nombres.

**Dirección**: fila DEP-16 con dueño para las dos listas; la compuerta verifica primero que cada lista exista, no esté vacía y marque un positivo propio guardado junto a ella (el mismo mecanismo que `rd-po-4.positivos`), y fija el motor (`/usr/bin/grep`, GNU). Reescribir l. 31 de `09-Respuestas` sin nombres de máquina («en una máquina distinta de la de las compilaciones, accesible sólo por la red privada del PO»).

### QA3-03 · El criterio de 05 no se puede cumplir: M = 5 con «comparación pareada por §10.4» (S2, E1)

La fila 05 de §E.2 tiene M = 5 preguntas y dice «Comparación pareada por §10.4». La regla única de §10.4 (§E.1, l. 648) afirma una diferencia sólo con al menos 6 pares discordantes, todos en el mismo sentido, y fija «el M mínimo para comparar es 6». Con M = 5 la afirmación central de 05 (con-prefijo ≪ sin-prefijo) **nunca** puede afirmarse, salga lo que salga. Además lo que compara 05 son tiempos (`prompt_eval_duration`), no un resultado pasa/falla: la regla no dice qué es un «par discordante» con una métrica continua. El oráculo, tal como está, no distingue un ejemplo que anda de uno que no.

**Dirección**: una de dos, declarada en la fila. (a) M = 6 y «discordante a favor» = `prompt_eval_duration` de con-prefijo menor que la mitad del de sin-prefijo en el mismo par, con `estado_cache` registrado; la binomial de §10.4 se aplica sobre eso. (b) 05 queda como **demostración** (sin tasa ni comparación inferencial, como 01): informa los cinco pares y la vuelta a frío con un carácter cambiado, y la guía no afirma «≪». El costo de (a) es una consulta más × 2 en el Ollama propio.

### QA3-04 · DEP-14 está resuelto, y TURNO-3 no tiene presupuesto aunque AC-3b le exige registro «nunca por presupuesto» (S2, E1)

(1) `<gestor-de-turnos> estado` lista `[[recurso-modelo-propio]] cupo 1 · en uso 0`; `<gestor-de-turnos> salud [recurso-modelo-propio]` devuelve versión `0.40.11`, modelos `qwen2.5:0.5b@a8b0c5157701` y `qwen3-embedding:0.6b@ac6da0dfba84` y capacidad de embedding verdadera; PROTOCOLO.md l. 10 lo declara con ttl 60. El plan sigue diciendo que el gestor aborta (§G.3 DEP-14) y que `[recurso-modelo-propio]` compite por CPU con `build` (R-02), cuando PROTOCOLO.md l. 34 los ubica en máquinas distintas. Rige EMB-B (09-Respuestas §3), y el cierre del ciclo 3 lo tiene que registrar.

(2) Con EMB-B vigente, TURNO-3 pasa a ser trabajo real: 02, 05, 06, fase de embeddings de 07, 16 y PD-2, DEP-03, todo con turno (PROTOCOLO.md l. 20). §E.5 no tiene tabla ni pesimista para TURNO-3, ni línea de corte, y PROTOCOLO limita cada turno a 60 min. Pero AC-3b exige un registro válido de **cada** pieza de TURNO-3 con modelo y admite la excepción «por dependencia, nunca por presupuesto». Un criterio sin cota de costo no se puede planificar ni auditar.

**Dirección**: tabla TURNO-3 con la misma forma que TURNO-1 (llamadas, clase, pesimista), con las clases del 0,5B y de embeddings medidas por DEP-03, y la regla de que ninguna fase pasa del ttl sin renovar. DEP-14 y R-02 se actualizan con estas citas.

### QA3-05 · El alcance de la demo está enumerado en ocho lugares, y uno ya contradice la respuesta 1 de la presidencia (S2, E1)

En el cuerpo del plan, «PD-1…PD-7» aparece en l. 382, 408, 517, 790 y 914; «PD-1…PD-6» en AC-3b (l. 932); «cinco escenarios» en l. 790, 792 y 996. §F.1 l. 790 dice «Recorre los cinco escenarios con siete pasos», que la respuesta 1 de 09-Respuestas deja de exigir. Si el recorte de H2-054 se aplica sólo en §F.1, AC-3b sigue exigiendo registros de pasos que ya no existen, el cableado de §F.8 sigue pidiendo un guion para PD-1…PD-7 y la línea de corte de §E.5 suma pasos que no corren. Es la misma clase de error que dejó huérfana a DEP-12.

**Dirección**: una sola fuente. §F.1 gana una columna «humo contra el modelo (sí/no)» y AC-3b deja de enumerar: «toda fila de §E.2 con modelo y toda fila de §F.1 con humo = sí». Verificación: un script extrae las dos columnas y las compara con las tablas de turnos de §E.5 y con la lista de AC-3b; cero diferencias. Las otras menciones pasan a «los pasos de §F.1».

### QA3-06 · El criterio de dificultad B/I/A no es decidible: «oráculo de seguridad» no está definido (S3, E1)

§E.2 l. 3: **A** si el ejemplo «introduce MAF, evaluación con juez o un **oráculo de seguridad**». 08 (la sesión ajena nunca se alcanza), 09 (OA-S2, ninguna escritura sin aprobación), 13 (un servidor guionado que anuncia `borrar_todo` y el cliente no la monta) y 17 (spans sin mensajes con el contenido apagado) tienen oráculos de seguridad o privacidad, y están en **I**. Dos auditores con el mismo texto clasifican distinto. Así la ratificación del criterio no ratifica nada verificable.

**Dirección**: definir sobre columnas que ya existen, para que lo decida un script: **A** = Paquetes incluye `Microsoft.Agents.AI*` o `*.Evaluation*`, o Entradas incluye una **entrada adversarial construida** (documento o servidor malicioso), o el escalón de §B.3 cruza las dos escaleras. Con esa definición 13 sube a A, por su servidor que anuncia `borrar_todo`. Si la mesa no quiere eso, lo excluye a propósito («adversarial contra el modelo», no contra el cliente) y la clasificación de 13 queda en I, pero declarada.

## 3. Posiciones sobre la agenda

| Tema | Opción | Fundamento |
|---|---|---|
| RV-03 (tope) | **(a) 4 h**, con la clase M corregida | Con 4 h la tabla es exacta (2.000 s, §1). Con s = 100, la clase M da 1.000/9,4 + 100/4 = **131,4 s**, no 120 (E1, aritmética): 15 cuesta 6.833 s, y con 6 h quedan 9.200 s después de TURNO-1, contra 2.640 + 6.833 = 9.473 s. «Con 6 h, hasta 15» es falso. Corregir M a 135 s o declarar s ≤ 50 para el juez (E3) y rehacer «Qué entra según el tope» |
| H2-056 (fusiones) | **F3 sí; F1 y F2 no** | F3 (14 opcional) no cambia ningún AC: 14 no llama al modelo. F1 (01 + 02) y F2 (06 + 07) juntan en una pieza un turno de `<recurso-compartido>` y uno de `[recurso-modelo-propio]`, y AC-3b cuenta registros por pieza: la pieza fusionada queda a medias si un turno corre y el otro no. Si se aprueban igual, AC-3b tiene que contar por (pieza, turno) |
| H2-054 (recorte de la demo) | **Humo contra el modelo sólo en PD-1, PD-5 y PD-6; PD-2, PD-3 y PD-4 sólo cableado; PD-7 queda, sin modelo** | Los AC que sólo la demo puede probar son la aprobación armada en el servidor entre dos peticiones (AC-4: PD-5, PD-6), la composición por scope (DEP-04: PD-1, PD-5, PD-6) y Host/`Origin` en `/mcp` (`Mcp_HostYOrigenAjenos_Rechaza`: PD-7, sin costo de turno). PD-2/3/4 repiten la conducta de 07/03/04. Ahorro en TURNO-1: 240 s. Se aplica con QA3-05, no a mano en §F.1 |
| RV-05 (OA) | **(a) 26 OA** | (b) obliga a reescribir las 3 menciones de OA-S3 del plan y a rehacer la verificación de remisiones de PAR2-19 en el último ciclo. (a) no cambia ningún criterio. Verificable igual con el script de preguntas por OA |
| RV-04 (extensión) | **(b) Parte 0 ≤ 1.500 y Anexos ≤ 6.700**, con la compensación recalculada antes del voto | (b) no mueve contenido ni remisiones. El margen es chico (estimación E3 de ~1.480 frente a 1.500), así que decide `tools/contar.sh` en S-14. La compensación de l. 372 no cierra con sus propios sumandos: los positivos que lista dan +760 (no +640) y los negativos −285 (no −420), o sea un saldo de +475, no +220 (E1). Con los costos que declara cada parche (J3) da +625. La papeleta se vota con un número que cierre |
| RV-01 (casos integradores) | **(a) sin casos** | Es la única opción que no suma superficie de verificación ni palabras sin compensar (la compensación ya está mal sumada) |
| RV-11 (juez) | **(a) sesgo declarado** | (b) se vuelve elegible porque DEP-14 está resuelto, pero no se puede ejecutar: el Ollama propio tiene sólo modelos de la familia Qwen (salud, E1), y PROTOCOLO.md l. 20 prohíbe hacer pull. Un juez de otra familia necesita otro pedido al gestor, y no hay ciclo 4 para votar su resultado |
| Criterio de dificultad B/I/A | **Enmendar** antes de ratificar | QA3-06: con el texto actual no es decidible |
| P-12 / DEP-15 | **Cumple, con un criterio mecánico** | RD-PO-3 exige «entidades de Movilidad Urbana», y el contenido sintético las usa. Para que el «cumple» sea verificable: `tools/verificar-sintetico.sh` comprueba en cada archivo escrito para el ejemplo (corpus de 05, documento de 16, siembra, entradas de 04/PD-4/12) el rótulo en la primera línea, provincia ∈ `Catalogos`, CP `^[0-9]{4}$`, medios y frecuencias ∈ catálogo, `Nombre` `^Persona [0-9]{2}$`, y que pasa AC-7 y AC-8. DEP-15 suma AC-7 a «Bloquea» (minoría de J4 a PAR2-21) |
| Par CTX-NUEVA / CTX-EXISTENTE | **Aprobar, con un criterio de aceptación** | La definición de BIT-16-03 §2 («cambia la respuesta correcta») da el criterio: la matriz de §3 (l. 92) suma la columna del par y la guía tiene al menos una recomendación por escenario cuya respuesta difiere entre los dos contextos, listada. Se actualizan en el mismo parche §F.1 («CTX-LOCAL × CTX-PROTO» pasa a × CTX-EXISTENTE) y P-05 de §G.4, que hoy dice «No por ahora» y usa otro nombre (CTX-EXIST). Verificación: `grep "CTX-EXIST\b"` = 0 |
| DEP-12 huérfana | **Partir la fila** | Queda sólo el pinning de transitivos (bloquea AC-6). La parte de `TypedResults.ServerSentEvents` sale, junto con PD-1 de «Bloquea»: el plan no tiene otra mención de SSE (E1, una sola coincidencia, l. 985) |
| §B.4 «Agente por código» | **Escalón 1, con estado como dimensión aparte** | l. 291 dice 3, y la fila 11 de §E.2 y §B.3 dicen que el estado no sube el escalón: es una contradicción entre secciones |
| R-06 (dominios ajenos) | **Criterio de salida: la lista de pendientes de `rd-po-4.excepciones` vacía antes del commit** | Hoy son 37 líneas en 6 archivos, todas dentro de la lista declarada (§1) |
| DEP-14 | **Resuelto: rige EMB-B** | QA3-04 (1) |
