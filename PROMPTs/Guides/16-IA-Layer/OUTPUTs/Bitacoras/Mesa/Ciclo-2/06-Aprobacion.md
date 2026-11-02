---
doc_id: BIT-16-MESA-C2-06
doc_type: aprobacion
title: Ciclo 2 · Mesa de decisión sobre los parches (M§5.5)
version: v1
status: cerrado
origin: agent (secretaría; transcribe las decisiones, no vota)
last_review: 2026-10-26
traces: [BIT-16-MESA-C2-05, BIT-16-MESA-C2-04, M§5.5, M§6]
---

# Ciclo 2 · Aprobación de los parches

Resultados posibles (M§5.5): `APLICAR`, `MEJORAR_PLAN`, `NO_APLICAR`, `ESCALAR`. Conteo: A aplicar · M mejorar plan · N no aplicar · E escalar, sobre los cinco jueces (evidencia, impacto, costo-beneficio, coherencia, riesgo). Decide la mayoría. Las objeciones en minoría no se aplican: quedan registradas abajo y pasan al ciclo 3 como deuda o pregunta (`08-Cierre.md`).

## 1. Decisiones

| Parche | Sección | Capa | Resultado | Conteo | Objeción en minoría | Chequeo de capa de origen |
|---|---|---|---|---|---|---|
| PAR2-01 | §E.5 (reescrita), §12.7 | plan | **APLICAR** | A4-M1-N0-E0 | J1 (§2.1) | correcta |
| PAR2-02 | §E.2, §E.5, §F.6, §G, fichas §4 y §13 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR2-03 | §F.10, AC-3a…AC-10 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR2-04 | §E.1, arnés | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR2-05 | §E.1, `num_ctx`, embeddings, variables | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta (reemite AJ-01) |
| PAR2-06 | §E.1, Dominio y R-LLM; §10.4 | plan | **APLICAR** | A4-M1-N0-E0 | J3 (§2.2) | correcta |
| PAR2-07 | §E.1, regla de Domain y versiones | plan | **APLICAR** | A4-M1-N0-E0 | J4 (§2.3) | correcta |
| PAR2-08 | §E.6 nueva | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR2-09 | §E.2, filas 01–17 | plan | **APLICAR** | A4-M1-N0-E0 | J3 (§2.4) | correcta |
| PAR2-10 | §E.4 (d) | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR2-11 | §F.1 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR2-12 | §F.2 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR2-13 | §F.3–§F.5 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR2-14 | §F.6–§F.9 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR2-15 | §A.3 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR2-16 | §A.4, §B.2, §B.3 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR2-17 | §C preámbulo y Parte 0 | plan | **APLICAR** | A4-M1-N0-E0 | J3 (§2.5) | correcta |
| PAR2-18 | §C fichas §1–§15 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta (reemite AJ-05) |
| PAR2-19 | §C Anexos | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR2-20 | §D | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR2-21 | §G.1–§G.4 | plan | **APLICAR** | A4-M1-N0-E0 | J4 (§2.6) | correcta |
| PAR2-22 | §H y changelog del ciclo 1 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR2-23 | BIT-16-02 §6 | capa de origen (cohesión) | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR2-24 | `Ciclo-1/05-Parches.md` | capa de origen (registro del ciclo 1) | **APLICAR** | A3-M2-N0-E0 | J2 y J4 (§2.7) | correcta |
| PAR2-25 | Gestor de recursos de la raíz del workspace | capa externa, con dueño | **APLICAR** (como pedido) | A4-M1-N0-E0 | J5 (§2.8) | correcta: la mesa no escribe fuera de su perímetro (R-ESCR); la presidencia pasa el pedido al dueño (MD-2) |
| PAR2-26 | N6 l. 504 | capa de origen (dossier) | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR2-27 | Sin cambio de texto | — | **APLICAR** (ratificación) | A5-M0-N0-E0 | — | — |

**27 de 27 `APLICAR`**; 19 por unanimidad (70 %), 8 con objeción en minoría. Ningún `NO_APLICAR` y ningún `ESCALAR`. Ningún parche activa los disparadores de M§6: no cambian lo que el contrato promete (SUP-05 sigue cubriendo la web y la API REST del caso base), no hay irreversibles y ESC-001 no se reabre.

**Ratificaciones registradas acá** (PAR2-27): AJ-04 (una sola regla en AC-8), AJ-06 (IDs v0 → v1, con sus dos residuos corregidos por PAR2-18 y PAR2-19), AJ-07 (líneas de fuente y escenarios en §0, §2, §3 y §15) y AJ-08 (S-12 remite a `Ciclo-1/01-Convocatoria.md`, que existe). AJ-02 se ratifica con la corrección de 07 dentro de PAR2-01. AJ-01 y AJ-05 se reemiten (PAR2-05, PAR2-18) y AJ-03 se reemplaza (PAR2-01).

**Aviso de numeración** (J1, verificado por la secretaría): el contexto común del despacho llama AJ-08 a «OA asignados a preguntas guía». En `Ciclo-1/07-Aplicacion-Y-Verificacion.md` (l. 35) AJ-08 es la remisión de S-12; los OA son AJ-05 (l. 32). PAR2-18 y PAR2-27 usan la numeración correcta.

## 2. Objeciones en minoría (no aplicadas; pasan al ciclo 3)

### 2.1 PAR2-01 · J1 evidencia (`MEJORAR_PLAN`)

Las cifras medidas están en su fuente y las dos tablas suman bien. (1) La clase M declara 120 s «por fórmula (E3)» sin decir qué s usa: con s = 100, como en la clase K, la fórmula da 1000/9,4 + 100/4 = 131,4 s. Con 131,4 s, la pieza 15 cuesta 6.833 s, y con 6 h quedan 6.560 s, así que «con 6 h, hasta 15» deja de ser cierto. Corrección pedida: declarar s por clase (el juez de 15 devuelve un puntaje: s ≤ 50, rotulado E3) o subir M a 135 s y rehacer «Qué entra según el tope». (2) Con EMB-C, la lista de TURNO-3 deja «no ejecutado» a 02, 05, 06, 07, 16 y PD-2, pero no nombra la fila «Estabilidad» de TURNO-1 ni la pieza 15 de TURNO-2, que dependen de 07. (3) El 253 de 07 se midió con el tokenizador de `qwen2.5`, y la re-ejecución dio 259 y 264: citar «~250–265» (sigue en clase K).

### 2.2 PAR2-06 · J3 costo-beneficio (`MEJORAR_PLAN`)

De acuerdo en el fondo. La repetición por truncado «dentro del tope» no figura en §E.5: con 4 h el margen de TURNO-2 es 0 s (2.000 de 2.000); en 07 la repetición puede llegar a ~640 s y en 16 a ~3.600 s. Pide escribir que la repetición se descuenta del medidor como cualquier llamada, que desplaza a la última pieza de TURNO-2 que no corrió (nunca a una de TURNO-1), y que en TURNO-1 sólo se permite si el pesimista recalculado sigue por debajo del 90 %.

### 2.3 PAR2-07 · J4 coherencia (`MEJORAR_PLAN`)

`_Comun` se llama `MovilidadUrbana.Dominio` (proyecto y carpeta, plan §E.1). Si la demo y `_Comun` comparten el namespace `MovilidadUrbana.Asistente` y `diff-dominio.sh` corre sin normalización, el nombre del proyecto y el namespace quedan desalineados, y la pregunta abierta (referenciar `_Comun` en lugar de copiarlo) cambia lo que se compara. Pide fijar una de dos: (a) mismo namespace de dominio y nombre de proyecto coherente, declarado; o (b) la demo referencia `_Comun` por `ProjectReference` y el diff desaparece.

### 2.4 PAR2-09 · J3 costo-beneficio (`MEJORAR_PLAN`)

(1) 15 gasta 52 llamadas M (6.240 s), y su propio texto dice que con 10 casos la calibración sólo puede descartar al juez. Pide una compuerta en secuencia: 15a, las 10 de calibración con un evaluador (10 llamadas, 1.200 s); 15b, las 16 salidas de 07 y el segundo evaluador sólo si 15a llega a 8 de 10. Si el juez queda descartado, se ahorran 5.040 s. (2) En 16, si `hash_instrucciones` y `hash_herramientas` coinciden entre «origen» y «aprobación», la segunda variante debería reproducir con `--fake` las respuestas grabadas de la primera y probar sólo la defensa en código (ahorro de 12 llamadas H, 2.400 s); si difieren, sigue el pareado de 3 × 6.

### 2.5 PAR2-17 · J3 costo-beneficio (`MEJORAR_PLAN`)

(1) La compensación de palabras está mal sumada: los costos que declara cada parche dan +910 (PAR2-06 40, PAR2-09 250, PAR2-14 80, PAR2-16 110, PAR2-18 130, PAR2-19 150, PAR2-15 30, PAR2-17 120) y −285 (PAR2-18 −260, PAR2-15 −25): saldo ~+625, no ~+220. No se puede tomar del margen del 15 %, que es el disparador de la relectura S-14; si no alcanza, la papeleta de RV-04 tiene que decirlo con el número correcto. (2) Los ~diez scripts de verificación de la guía que suma el ciclo (`contar.sh`, `toc.sh`, `rutas.sh`, el de remisiones, el del criterio, el de preguntas por OA) se solapan: pide una sola herramienta con subcomandos.

### 2.6 PAR2-21 · J4 coherencia (`MEJORAR_PLAN`)

(1) PAR2-11 saca la ruta de chat con SSE, pero **DEP-12** sigue exigiendo que un controller devuelva `TypedResults.ServerSentEvents` y bloquea PD-1: queda una dependencia huérfana que contradice §F. (2) DEP-15 tiene que listar también AC-7 (compuerta de nombres sintéticos) y toda fila de §E.2 que use entradas o siembra escritas para el ejemplo, porque PAR2-03, PAR2-06 y PAR2-11 ya presuponen que P-12 se resuelve con «cumple».

### 2.7 PAR2-24 · J2 impacto y J4 coherencia (`MEJORAR_PLAN`)

El error está verificado y la capa es la correcta, pero reemplazar «85» por «93» reescribe en silencio un registro cerrado del ciclo 1, cuando PAR2-22 establece que las filas del ciclo 1 no se reescriben. Piden fe de erratas: «85 [errata del ciclo 2, PAR2-24: 93; error de suma 63 + 9 + 21]» en los dos lugares, más la nota del cruce id por id. La nota agregada por el parche aplicado conserva la trazabilidad del cambio.

### 2.8 PAR2-25 · J5 riesgo (`MEJORAR_PLAN`)

El pedido no satisface su propio criterio contra el script real: (1) `cupos.conf` sólo carga CUPO (l. 25–28), no TTL: el ttl de `[recurso-modelo-propio]` tiene que ir al arreglo `TTL` del script (l. 24); (2) `estado` y `recursos` recorren la lista fija de recursos (l. 39, l. 269): sin agregarlo ahí, «estado lo lista» no se cumple; (3) la función de salud (l. 236–252) termina en «recurso desconocido»: necesita su rama; (4) el ttl máximo es de 240 min (l. 98) y TURNO-2 dura 5,36 h: la renovación (hoy «opcional») o partir el turno tiene que estar en el pedido. El cambio tiene que ser sólo aditivo, porque el gestor lo comparten otras sesiones.

## 3. Papeletas que los parches mandan votar en la aprobación

Los parches traen papeletas de re-voto con su costo. **En las decisiones de este ciclo no hay votos sobre ellas**: el jurado votó los 27 parches, no las opciones. Rige lo que cada parche declara como provisional, y las papeletas pasan al ciclo 3.

| Papeleta | Parche | Opciones | Régimen provisional vigente en la v2 |
|---|---|---|---|
| RV-03 (tope de `<recurso-compartido>`) | PAR2-01 | (a) 4 h · (b) 6 h · (c) 9 h; en los tres, clases de t y regla del 90 % | 4 h: TURNO-1 completo y de TURNO-2 hasta «03, extensión» |
| H2-056 (fusiones) | PAR2-01 | F1 01 + 02 · F2 06 + 07 · F3 14 opcional, por separado | Sin fusiones: 17 ejemplos |
| RV-05 (OA) | PAR2-15 | (a) 26 OA · (b) 25 OA con OA-S3 fundido en OA-S2 | Tabla v1 + OA-A5 (26 filas); OA-S2 con §11.2 |
| RV-04 (extensión) | PAR2-17 | (a) topes y §0.5 al Anexo E · (b) Parte 0 ≤ 1.500 y Anexos ≤ 6.700 | Topes de la v1; total ≤ 43.700 |
| RV-01 (casos integradores) | PAR2-18 | (a) sin casos · (b) optativos fuera del conteo · (c) tres casos | (a) |
| RV-11 (juez de 15) | PAR2-22 | (a) sesgo declarado con calibración propia · (b) juez de otra familia, sólo con DEP-14 | (a) |
| P-12 / DEP-15 (contenido escrito para el ejemplo) | PAR2-21 | cumple · no cumple · variante intermedia (reglamento de 05 sin localidades ficticias) | Propuesta del plan («cumple»), sin decisión: DEP-15 queda abierta como condición previa de 04, PD-4, 05, 12, 16 y PD-1 |
| Criterio de dificultad B/I/A | PAR2-02 | ratificar o enmendar el criterio del cuerpo auditor | Criterio aplicado (07 A, 08 I, 11 A, 17 I) |

**Preguntas a la presidencia** (no son escaladas al PO: el contrato alcanza para responderlas). (1) H2-055: ¿el contrato exige que la demo sola recorra los cinco escenarios? SUP-05 sólo pide que cubra la web y la API REST; si no lo exige, PD-7 sale y ESC-05 se cubre con 13. (2) H2-049: I-05 §5.2, ¿PR-17 abre un escenario nuevo en N0 o es una variante de ESC-04? (fila pendiente en BIT-16-02 §6).
