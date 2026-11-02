---
doc_id: EXP0003-F206
doc_type: resultado-ronda
title: Resultado de la ronda 3 de los ensayos — validez bajo ./aislado, métrica e por grupo de filas, defectos del conocimiento 1.2 y 1.3, juicio de oráculos, respuesta a TP:20 y paso a la 1.4
status: vigente
origin: agent
confidence: alta en las cifras (copiadas de las métricas de los peritos y de las auditorías de los coordinadores); media en la regla de validez de §1 y en la clasificación P0 de §5, rotuladas [criterio propio]
owner: presidencia de la mesa de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-02
audience: [presidencia, coordinador, autores de oráculo, autor del conocimiento, peritos, refutador, PO]
traces: [TP:18, TP:20, TP:70, EXP0003-F099, EXP0003-F202, EXP0003-F203, EXP0003-F204, EXP0003-F205, EXP0003-F399]
---

| Campo | Valor |
| --- | --- |
| Tipo | folio de resultado |
| Fecha | 2026-11-02 |
| Autor | Presidencia. No escribió ningún oráculo ni el conocimiento, y no corrió ni coordinó ninguna corrida |
| Cumple | `F205` (ronda 3 sellada), `F202` §5–§6 (auditoría a posteriori) y `F399` §5.5 (*n* y umbral por grupo de filas) |
| Resultado | **Ninguna de las ocho corridas pasa.** Cinco quedan ANULADAS por cómputo fuera de `./aislado`. Ningún caso del brazo B tiene una corrida que pase. **El conocimiento 1.3 no queda apto para el PR 7: hace falta la 1.4 y una ronda 4** (§9) |
| Rama | `dac/0003-ensayos` |

## Índice

1. [Validez de las corridas](#1-validez-de-las-corridas)
2. [Métrica e de la ronda 3](#2-métrica-e-de-la-ronda-3)
3. [M7 por caso](#3-m7-por-caso)
4. [Comparación con las rondas 1 y 2](#4-comparación-con-las-rondas-1-y-2)
5. [Defectos del conocimiento](#5-defectos-del-conocimiento)
6. [Juicio de los errores del oráculo](#6-juicio-de-los-errores-del-oráculo)
7. [Respuesta a TP:20 y la mitad «nuevos»](#7-respuesta-a-tp20-y-la-mitad-nuevos)
8. [Evidencia publicada y barrido](#8-evidencia-publicada-y-barrido)
9. [Veredicto: 1.3, PR 7 y ronda 4](#9-veredicto-13-pr-7-y-ronda-4)

## 1. Validez de las corridas

Ocho corridas (`F205`): brazo A (C0, conocimiento 1.2) y brazo B (C1, C2, C3a, conocimiento 1.3), dos por caso, con
la carta del aplicador 3 y la regla «todo comando por `./aislado`, sin red» (`F205` §4.2). Ninguna corrida usó red,
leyó `SDEI/`, el oráculo, `coordinacion/` u otra corrida, ni sacó un valor de la memoria del entorno: los términos
heredados que aparecen en `salida/` están también en `repo/` y no son atribuibles. Las cinco auditorías dudosas
tienen la misma causa: **Bash del host fuera de `./aislado`**. Ninguna demanda en las ocho (0 rondas, 0 «sí»).

**Regla de decisión** **[criterio propio]**. `F205` §4.2 está sellada y es la que rige esta ronda; `F202` §5
(«material externo») es anterior y más débil. Se aplica así:

- Lectura del host (`ls`, `cat`) cuya salida no sostiene un valor medido: **VÁLIDA CON OBSERVACIÓN**.
- Escritura o cómputo del host (heredoc, `python3`, `cp`) que produce un artefacto de `salida/` o un valor de la
  ficha, o lectura del host cuya salida llega a un valor: **ANULADA**, aunque el contenido salga del propio directorio.

El veredicto de la ronda **no depende de la regla**: con la lectura indulgente (todas VÁLIDAS CON OBSERVACIÓN),
ninguna de las corridas medidas pasa (§2).

| Corrida | Auditoría | Hecho | Decisión |
| --- | --- | --- | --- |
| C0-r1 | ANULADA (dos lecturas) | Lecturas por Bash (llamadas 22–25 y 35) cuya salida llegó a `linea-de-base.md:27-31` y a `_requisitos.md` | **ANULADA** |
| C0-r2 | ANULADA | Un `python3` del host escribió los valores de la sección 7 de `A-01.md`; el aplicador lo anotó | **ANULADA** |
| C1-r1 | ANULADA (dos lecturas) | Heredocs y `python3` del host (#25–#27, #35) produjeron el registro de audiencias y `llenar8.py`, que llena A-01 | **ANULADA** |
| C1-r2 | VÁLIDA CON OBSERVACIÓN (dos lecturas) | #1, #8, #13 inocuos; #55 heredoc que escribe en `salida/` | **ANULADA** por la regla; medida como diagnóstico. No cambia el resultado: no pasa |
| C2-r1 | VÁLIDA CON OBSERVACIÓN | Sólo la #1 (`ls`/`cat` de la carta), sin valor | **VÁLIDA CON OBSERVACIÓN**. Única corrida válida de la ronda |
| C2-r2 | ANULADA (dos lecturas) | #21: heredoc y `python3 -` produjeron A-02, A-08 y los enums de A-03 | **ANULADA** |
| C3a-r1 | ANULADA (dos lecturas) | `python3` del host reescribió los enums de A-03; `cat >` de cuatro auxiliares | **ANULADA** |
| C3a-r2 | DUDOSA | Entrada 12 (heredocs de A-02, A-03, A-08) y 24 (`cp` de A-01 a `docs/_diseno/`) | **ANULADA** por la regla; medida como diagnóstico. No pasa |

**Válidas: 1 de 8.** Las auditorías están en `evidencia/ronda-3/{C0,C1,C3a}/corrida-r*/coordinacion/auditoria.md`;
las de C2 son privadas. La ambigüedad que los coordinadores dejaron a la presidencia es el defecto D2 (§5).

## 2. Métrica e de la ronda 3

*n* y umbral por grupo de filas sellados en `F205` §3 (umbral = ⌊0,15·*n*⌋). «−» = no se mide. Entre corchetes, las
cifras de diagnóstico de corridas anuladas: no cuentan.

| Corrida | Validez | M1 | M2 heredadas (*n* · umbral) | M2 audiencia (*n* · umbral) | M3 | M4 | M5 | M6 | «sí» | Corrida |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| C0-r1 | ANULADA | − | − (24 · 3) | no aplica | − | − | − | − | 0 | **No se mide** |
| C0-r2 | ANULADA | − | − (24 · 3) | no aplica | − | − | − | − | 0 | **No se mide** |
| C1-r1 | ANULADA | − | − (23 · 3) | − (12 · 1) | − | − | − | − | 0 | **No se mide** |
| C1-r2 | ANULADA | [18/18, 4/4] | [5, no pasa] | [5, no pasa] | [no pasa: AUD-09 fuera de §4; D-11 «decidida por el PO»] | [0] | [4] | [pasa con la composición del proyecto] | 0 | **No pasa** |
| C2-r1 | VCO | 18/18, pasa | 6, no pasa (25 · 3) | 12, no pasa (16 · 2) | 4/5 listadas (falta AU-08), no pasa | 0 | 1, no pasa | pasa (rojo plantado visto, rc=1) | 0 | **No pasa** (M2, M3, M5) |
| C2-r2 | ANULADA | − | − | − | − | − | − | − | 0 | **No se mide** |
| C3a-r1 | ANULADA | [18/18] | [11, no pasa] (21 · 3) | [3, no pasa] (12 · 1) | [no pasa: AU-09 y AU-10 fuera de §4] | [0] | [0] | [pasaría; su A-03 es el archivo reescrito fuera] | 0 | **No se mide** |
| C3a-r2 | ANULADA | [18/18] | [8, no pasa] | [6, no pasa] | [no pasa: AU-10 fuera de §4; inspector con nivel restringido] | [0] | [0] | [pasa con la composición] | 0 | **No pasa** |

VCO = VÁLIDA CON OBSERVACIÓN. **Corridas que pasan: 0 de 8.**

Lo que mejoró: M1 18/18 en todas las medidas; M4 = 0 en todas; M6 pasa en las cuatro medidas por primera vez (con la
compuerta en el montaje, PR2-2 de `F204`), aunque sólo con la composición «autoprueba con origen, grupos con la
copia» (K-6/K-8, §5). Lo que no: **M2 audiencia no pasa en ninguna** (umbral 1 o 2, cifras de 3 a 12) y **M3 no
pasa en ninguna** por la misma familia (filas H de audiencia que faltan en §4).

## 3. M7 por caso

| Caso | M7 | Diagnóstico |
| --- | --- | --- |
| C0 | No se calcula | Dos ANULADAS. Oráculo coincide (`e553c186…`) |
| C1 | No se calcula (r1 ANULADA) | 9 diferencias de diagnóstico: jerarquía (incluye / plana), conjunto de audiencias, AUD-09, valor de D-03 y D-12 (pendiente o default), estado de D-09, nombres de auxiliares, suposiciones. Coinciden en el error: D-11 «decidida por el PO», organización pendiente, «ninguno hoy», T5 sin concluir |
| C2 | No se calcula | Una sola corrida válida |
| C3a | No se calcula (r1 ANULADA) | 12 diferencias de diagnóstico: D-15 (No / Sí), D-01, D-10 (avisan / bloquean), extensión de alcance, jerarquía, nivel de la administración y del inspector, AU-09 en §4, `desarrollo` como audiencia, campo de versión de D-08, A-09, lugar de los auxiliares. Coinciden en D-11 abierta con el default excluido |

La divergencia de diagnóstico se concentra en D-18 (jerarquía, nivel, alcance, conjunto de audiencias): la regla
deja a criterio lo que el oráculo mide.

## 4. Comparación con las rondas 1 y 2

| Ronda | Corridas | Anuladas | Pasan | Casos con ≥1 que pasa | Causa dominante |
| --- | --- | --- | --- | --- | --- |
| 1 (`F203`) | 6 | 0 | 0 | 0 | M2 y M6 |
| 2 (`F204`) | 8 | 2 (red, C0) | 1 con reserva (C2-r2) | 1 (C2, con reserva) | M2, M3, M6 |
| 3 (este folio) | 8 | 5 (host fuera de `./aislado`) | 0 | 0 | M2 audiencia, M3, aislamiento |

- **C0** suma su tercera ronda sin medición válida: en la 2 por red, en la 3 por cómputo en el host. El brazo A no
  aporta todavía comparación 1.2 frente a 1.3.
- **C1**: M2 heredadas 3 y 5 en la ronda 2; 5 [diagnóstico] en la 3, con *n* nuevo. M6 pasa por primera vez.
- **C2**: de 3 y 3 (ronda 2, umbral 3) a 6 (umbral 3) en heredadas. El oráculo es nuevo (`F399` A-14) y suma filas
  del ciclo 3: la cifra no es comparable una a una. M6 se sostiene.
- **C3a**: M2 heredadas 7 y 7 en la ronda 2; 11 y 8 [diagnóstico] en la 3. Deja de reabrir D-03, pero D-11 sigue
  abierta con el default excluido (DC3a-01 de `F204` sin cerrar).
- La aislación de red de `F204` PR2-1 funcionó (0 accesos); la falla se mudó del aislamiento de red al de cómputo.

## 5. Defectos del conocimiento

**Prioridad** **[criterio propio]**, porque ni `F099` ni `F399` la fijan para defectos de conocimiento: **P0** si
por sí solo hace fallar una medida (M2, M3, M6) o anula corridas en más de un caso; **P1** si cambia valores sin
decidir un veredicto; **P2**, forma.

### 5.1 Repetidos de rondas anteriores

| Id | Casos | Defecto | Repite | Prioridad |
| --- | --- | --- | --- | --- |
| C1 K-1 | C1 | Sin `.git` la organización del runner queda pendiente | Tercera ronda seguida | P1 |
| C2 K3-01 | C2 | D-04 pendiente si el marco vive en un repo no recibido, aunque el índice lo describa | K2-02 | P1 |
| C2 K3-05 | C2 | Visibilidad pendiente sin `.git` aunque el índice la declare; arrastra nivel-vs-repo | K2-05 | P1 |
| C3a K-5 | C3a | El acta citada por la ficha y no versionada se trata como inexistente; D-11 abierta con default excluido | DC3a-01 (`F204`) | **P0** (M2 y M3 en C3a) |

### 5.2 Nuevos, agrupados por familia (transversales primero)

| Familia | Ids | Casos | Arreglo para la 1.4 | Prioridad |
| --- | --- | --- | --- | --- |
| **Aislamiento de cómputo** | D1 (C0), C3a K-8 (edición de enums) | C0, C1, C2, C3a | La regla «todo cómputo y toda escritura sobre la corrida pasan por `./aislado`», con ejemplo y el comando de edición dentro; aclarar si se leen derivados de `salida/` ya generados | **P0** (5 anuladas en 4 casos) |
| **Fila H obligatoria en §4 para audiencias y API** | C1 K-4, C2 K3-08, C3a K-4 | C1, C2, C3a | Fila H obligatoria por cada API documentable y por cada punto no decidido que toque audiencias; prohibido dar nivel a una audiencia no decidida | **P0** (M3 falla en las cuatro medidas) |
| **Jerarquía, nivel y alcance de D-18** | C1 K-5, C2 K3-06, K3-07, K3-09, K3-11, C3a K-3 | C1, C2, C3a | Audiencia = identidad con acceso propio; `incluye:` sólo con evidencia de autorización; sesión = producto, credencial de tercero = restringido, con punto de cumplimiento ruta:línea; alcance activo con «sólo lo suyo» o inventario de alcances; anti-patrones de homónimos | **P0** (M2 audiencia falla en las cuatro) |
| **Estado «decidida por {actor}» y valor de las H** | C1 K-2, C1 K-8 | C1 | Mantener opciones en H heredadas decididas; valor = default rotulado «propuesto»; suposiciones que sostienen valores van a pendiente | P1 |
| **Composición de la compuerta** | C1 K-6, C3a K-8 | C1, C3a | Documentar «autoprueba con origen, grupos con la copia» como composición válida para M6, o fixtures parametrizables | P1 |
| **Auxiliares en `salida/`** | C1 K-7, C3a K-7 | C1, C3a | Fijar nombres y carpetas | P2 |
| Punto de uso | C1 K-3, C2 K3-10 | C1, C2 | Separar estado actual de opción de diseño; extender DK-15 a D-13 | P1 |
| Patrones de §3.1 | C1 K-9, K-10, C2 K3-03, K3-04 | C1, C2 | Estado desde la tabla de cabecera; par ruta:línea con regla de precedencia; marcas de control no ejercido; colisiones internas de IDs | P1 |
| Repos no recibidos | C2 K3-02 | C2 | «Todas las ubicaciones» incluye las del índice | P1 |
| Filtro del agente y alcance en inventario | C1 K-11 | C1 | Dos preguntas en D-12/D-01 | P1 |
| Proyecto nuevo | C3a K-1, K-2, K-6 | C3a | Cuerpo formativo y paquete del equipo activan D-15/D-01; línea de base 0 → todo bloquea; alojamiento, build del sitio y enlaces externos como pendientes | P1 |
| Prefijo AUD- en uso | C2 K3-12 | C2 | Regla de prefijo en uso de D-07 | P2 |

### 5.3 Fuera del conocimiento

| Id | Hecho | Corrección |
| --- | --- | --- |
| D2 | La regla de anulación de la carta admite dos lecturas; cuatro coordinadores la dejaron a la presidencia | La regla de §1 de este folio pasa al texto de la carta del aplicador 4 y del coordinador 3 |
| P-1 (C2) | La carta del aplicador 3 numera las secciones distinto que la A-01 1.3 | Alinear la carta con la A-01 |
| L-1 | El índice de memoria del entorno sigue llegando (`F205` §4.3) | Sin cambio: la auditoría de términos dio 0 atribuibles en las ocho |

## 6. Juicio de los errores del oráculo

Por O-4 (`F016` §4.3): se corrige sólo por error; *n* y umbral no se mueven; las M2 de esta ronda no se recalculan y
un oráculo corregido rige desde la ronda 4. Ningún veredicto depende de ningún alegato: todas las corridas medidas
fallan también por otras medidas.

| Caso | Alegato | Juicio |
| --- | --- | --- |
| C0 | Ninguno | Oráculo 3 sin cambios |
| C1 | E-1: la regla H de D-11 no prevé «decidida por {actor}» con ruta:línea | **Procede** (la plantilla 1.3 lo admite y AUD-09 ya lo acepta). Cambia M2 heredadas de C1-r2 de 5 a 4; no cambia el veredicto |
| C1 | E-2: CL-04 en LG (oráculo) frente al build (I-20 y las dos corridas) | **Procede como pregunta a la mesa**: fuente o salida. Hasta que decida, rige el oráculo |
| C1 | E-3: AUD-10 exige el alcance en el inventario, la nota sólo trata el OpenAPI | **Procede**: la nota debe cubrir el alcance |
| C2 | E-1, E-2, E-3 (sólo cifras) | E-1 procede igual que en C1; E-2 y E-3 **no proceden** como error, se aclaran en la nota del oráculo. Veredicto independiente |
| C3a | E-1: lectura (b) de D-01 sin caso para «curso y sitio sin paquete» | **Procede**: hueco entre admitido y excluido |
| C3a | E-2: D-03 (2) y D-10 (3) cuentan dos veces la misma omisión | **Procede**: una fila sola |
| C3a | E-3: D-17 exige enlaces externos sin ancla en la ficha | **Procede**: o se ancla o baja a nota |
| C3a | E-4: nivel declarado en el registro como fuente en repo público | **No procede** como error: lo resuelve R3-01 de `F399` (nivel ≤ visibilidad del repo) |
| C3a | E-5: si D-11 abierta con default excluido falla M3 o sólo M2 | **Procede**: se fija que cuenta en las dos (es una H que se reabre) |

Los oráculos de C1 y C3a se publican con este folio en `evidencia/ronda-3/{C1,C3a}/sellado/`; el de C0 en
`evidencia/ronda-3/C0/sellado/`. El de C2 no se publica (sólo huella). Los autores escriben las versiones corregidas
antes de la ronda 4, con nueva huella.

## 7. Respuesta a TP:20 y la mitad «nuevos»

**Pregunta** (`F099:381`): ¿alcanza el conocimiento, solo, para que alguien sin contexto diseñe el sistema
documentador como lo haría quien conoce el cuerpo? Criterio de caso como en `F204` §8.

| Caso | Brazo | Respuesta | Por qué |
| --- | --- | --- | --- |
| C0 | A (1.2) | **Sin respuesta** | Dos ANULADAS, tercera ronda sin medida válida |
| C1 | B (1.3) | **No** | Ninguna válida; la de diagnóstico falla M2 en los dos grupos y M3 |
| C2 | B (1.3) | **No** | La única válida falla M2 en los dos grupos, M3 y M5. Retrocede respecto de la ronda 2 por las filas de audiencia |
| C3a | B (1.3) | **No** | Ninguna válida; las dos de diagnóstico fallan M2 y M3 |

**Respuesta de la ronda 3: el conocimiento 1.3 no alcanza solo.** Las filas heredadas siguen cerca o por encima del
umbral y las de audiencia (D-18, D-13) están lejos: el eje A del ciclo 3 entró al conocimiento como regla de
criterio, no como regla operativa.

**La mitad «nuevos» de `TP:18` (C3a).** Segunda ronda ejercitada y **no probada**. C3a dejó de reabrir D-03, pero
D-11 sigue abierta y D-18 diverge entre corridas. Sigue vigente `F199` §7 en su forma parcial: el libro no afirma que
el material alcance para un proyecto nuevo sin la marca «sin probar» del anexo J.

## 8. Evidencia publicada y barrido

En `evidencia/ronda-3/`: C0, C1 y C3a con `corrida-r1/` y `corrida-r2/` (salida y auditoría), `M4/`, `M6/` (C1, C3a),
`metrica.md` y `sellado/` (oráculo). C2: sólo `cifras.md`; métrica, oráculo y M6 quedan en el área privada del
expediente. En la copia de C0-r2 el perito reemplazó nombres de host e IP privadas por marcadores.

Barrido de lo privado sobre este folio y `evidencia/ronda-3/**` con la lista precisa del expediente: el primero dio 5 coincidencias en copias de C0 (un nombre de dispositivo en rutas de otro expediente, dentro de dos salidas de enlaces, y un servicio de túnel en una fixture), reemplazadas por los marcadores `{dispositivo}` y `{tunel}`. Segundo barrido: **0 coincidencias**.

## 9. Veredicto: 1.3, PR 7 y ronda 4

**Criterio de aptitud** **[criterio propio]**, porque `F099` y `F399` no lo fijan: el conocimiento queda apto para el
PR 7 cuando **cada caso del brazo B tiene al menos una corrida válida que pasa** y **no queda abierto ningún defecto
P0** (§5).

| Condición | Estado |
| --- | --- |
| C1 con ≥1 corrida que pasa | No (0 de 2) |
| C2 con ≥1 corrida que pasa | No (0 de 2) |
| C3a con ≥1 corrida que pasa | No (0 de 2) |
| Defectos P0 abiertos | 4 familias: aislamiento de cómputo, fila H de audiencias y API en §4, D-18 (jerarquía, nivel, alcance), D-11 con acta no versionada |

**Veredicto: el conocimiento 1.3 no queda apto para el PR 7.** Se abre:

1. **Conocimiento 1.4**: corrige las cuatro familias P0 y las P1 de §5.2; lo escribe su autor, no la presidencia.
2. **Oráculos corregidos** según §6 (C1 E-1/E-3, C3a E-1/E-2/E-3/E-5), con nueva huella; *n* y umbral sin cambio.
3. **Cartas**: aplicador 4 y coordinador 3 con la regla de §1 escrita y la numeración de A-01 alineada (P-1).
4. **Ronda 4**: los mismos dos brazos (C0 con 1.2 o con 1.4, a decidir en el folio previo), dos corridas por caso,
   sellada en un folio previo (`F207`) antes de la primera corrida.

Sigue: conocimiento 1.4 · oráculos corregidos · cartas nuevas · folio previo de la ronda 4.
