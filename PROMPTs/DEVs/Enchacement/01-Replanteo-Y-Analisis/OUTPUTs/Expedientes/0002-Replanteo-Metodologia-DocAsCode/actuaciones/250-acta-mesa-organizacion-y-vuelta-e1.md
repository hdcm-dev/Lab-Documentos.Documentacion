---
doc_id: EXP0002-F250
doc_type: acta
title: Acta de la mesa-comisión de organización del repositorio y vuelta de E1 — propuestas, puntajes, fallo y plan por olas
status: vigente
origin: agent
confidence: alta en las citas verificadas por el jurado (comando y salida en §4); media en el orden de las olas y en los puntajes, que son criterio del jurado
owner: presidencia de la mesa de Replanteo y análisis DocAsCode (vuelta de E1)
last_review: 2026-10-28T13:06:05-03:00
audience: [PO, presidencia, refutador, agentes que reparen E1, mesa de la opción B, bitacorista, línea Framework-Concept]
traces: [EXP0002-F132, EXP0002-F133, EXP0002-F240, EXP0002-F245, EXP0002-F249, EXP0002-F256, N09, N10]
---

| Campo | Valor |
| --- | --- |
| Tipo | acta (mesa-comisión con jurado, Knowledge-Mesa-De-Expertos-A-Pedido) |
| Fecha | 2026-10-28T13:06:05-03:00 |
| Autor | Jurado de la mesa-comisión. Evalúa, verifica citas, falla e injerta; no redacta reparaciones |
| Objeto | Organizar los dos repositorios en casos de trabajo separados sin perder información, y fijar la vuelta única de E1 tras la compuerta E1-G INSUFICIENTE (`245`) |
| Corrige | Nada. `245` y `249` no se editan: este folio responde `245` §9 y concreta `249` §2 |
| Ajuste al versionar | 2026-10-28, presidencia: DEC-04 queda ajustada por la medida de §7.1 (sin redacción de la evidencia de G-f, que ya está en `main`) y la cuenta de marcas de G-g pasa al folio `256`. El fallo no cambia |

# 250 — Acta de la mesa-comisión: organización y vuelta de E1

## Índice

1. [Testimonio del mandato](#1-testimonio-del-mandato)
2. [Composición](#2-composición)
3. [Propuestas](#3-propuestas)
4. [Verificación de citas](#4-verificación-de-citas)
5. [Puntajes](#5-puntajes)
6. [Fallo](#6-fallo)
7. [Decisiones](#7-decisiones)
8. [Plan de unidades por ola](#8-plan-de-unidades-por-ola)
9. [Resguardo](#9-resguardo)
10. [Lo que sale al PO](#10-lo-que-sale-al-po)
11. [Riesgos](#11-riesgos)
12. [Lo no verificado](#12-lo-no-verificado)
13. [Pase](#13-pase)

## 1. Testimonio del mandato

Literal del PO, 2026-10-28:

> «no pierdas información, si tenes que crear una rama y arreglar el repositorio para separar los casos de trabajo y
> luego integrar, armar una mesa comisión que gestione eso, tomate el trabajo de organizar y gestionar las tareas en el
> repositorio y dejarlo en condiciones, para poder hacer los avances y las pruebas y terminar integrando todo»

Y, sobre la vuelta de E1:

> «Sí, mesa y reparaciones»

La mesa decide y su fallo queda aprobado en nombre del PO, por la delegación «la mesa decide y queda aprobado» del
2026-09-14 y por este mandato. Lo irreversible con consecuencia externa no entra en la delegación: sale al PO (§10).

## 2. Composición

| Silla | Quién | Tarea |
| --- | --- | --- |
| Presidencia | Agente de la presidencia de la compuerta E1-G | Convoca, despacha, recibe el fallo |
| Relevamiento R1 | Agente | Líneas de trabajo, estado git, colisiones, inalcanzables |
| Relevamiento R2, R3 | Agentes | Qué existe sólo en las ramas `rescate/hpdev-2026-10-28` de cada repo, por clase (a)–(d) |
| Relevamiento R4 | Agente | Fugas S2 del HEAD y de la historia (F1–F10, H1–H6), sin transcribir valores |
| Relevamiento R5 | Agente | Catálogo de defectos de E1-G: DEF-01…DEF-76 (74 distintos) |
| Comisión C-ORDEN | Agente, a ciegas | Plan con enfoque «riesgo primero» |
| Comisión C-ENTREGA | Agente, a ciegas | Plan con enfoque «flujo primero» |
| Comisión C-NORMA | Agente, a ciegas | Plan con enfoque «norma primero» |
| Jurado | Agente distinto de los anteriores | Este folio |

Las notas de trabajo de R1–R5 y las tres propuestas no se versionan, porque contienen archivo:línea de fugas y, en
`R4`, la referencia a los valores. Van al resguardo privado (§9, ítem 7).

Regla de la carta común para todas las sillas: en esta etapa no se modifica nada en los checkouts ni en git.

## 3. Propuestas

| Comisión | Decisiones | Unidades | Olas | Rasgo |
| --- | --- | --- | --- | --- |
| C-ORDEN | 14 | 22 | 0–4 | Resguardo y redacción primero; empaqueta los inalcanzables sin crear refs; mantiene las ramas negativas hasta citarlas; prueba PR-7 con una pieza sintética |
| C-ENTREGA | 19 | 30 | 0–4 | Un dueño por archivo y por ola, CHANGELOG diferido, unidades chicas. **Midió que la evidencia de G-f contiene literales del patrón** y propone redactarla antes de versionarla |
| C-NORMA | 16 | 22 | 0–2 | Corrigendas a la norma: definición de P0, la contradicción de `N10` §3.3 frente a §14, mecánica de la mesa B, despacho de Verificar sobre cada merge de LDD |

## 4. Verificación de citas

El jurado verificó por su cuenta, sólo con lectura, al menos cinco citas de cada propuesta. ✔ significa que coincide;
✘, que no coincide o ya caducó.

### 4.1 Comunes a las tres

| Cita | Comando | Resultado |
| --- | --- | --- |
| Puntas de `main` y de los rescates | `git rev-parse --short` | ✔ LD `227954a`, rescate `674466c`; LDD `0492a1a`, rescate `20cd8bb` |
| `INFORME.md:298` del ensayo E01 (piezas crudas no versionables) y sus sha256 | `git show origin/main:…/E01-…/INFORME.md \| sed -n 296,310p` | ✔ La línea 298 es el encabezado; la tabla de las 4 piezas está en 301-304 (arm64 `eb6250e0…`, x64 `3a7d2e35…`, v1 `b7828d72…`, v2 `b7fb650c…`) |
| Las 4 piezas (c) sólo están en el rescate de LDD | `git ls-tree -r rescate/hpdev-2026-10-28 \| grep 'E01.*evidencia/local/'` | ✔ 2 `.apk` y 2 `.zip` |
| `verificar.yml:57` llama a `docs-guard@f603984` con `ruta: .github` | `git show origin/main:.github/workflows/verificar.yml` | ✔ Líneas 57 y 59; los disparadores (14-16) son `pull_request` y `workflow_dispatch`, sin `push` |
| `framework-concept-demo.yml:7,12,42,87,148,168` con el runner caído | `git show origin/main:… \| grep -n i7infra` | ✔ Las seis líneas |
| Guía 16: 373 archivos | `find PROMPTs/Guides/16-IA-Layer -type f \| wc -l` | ✘ **Caducó: hoy da 390.** La sesión viva sigue escribiendo, así que una aceptación con un número fijo fallaría |
| Inalcanzables: 62 en LD y 2 en LDD | `git fsck --unreachable --no-reflogs \| grep -c commit` | ✘ **Caducó: hoy 63 en LD y 9 en LDD.** En LDD aparece `88e8265` (2026-10-28, versión anterior al rebase de la constancia 044 de FC) y siete commits de 2026-08/09. El inventario se toma al ejecutar |
| H1 de TEM-04, 05 y 06 empiezan con el ID | `sed -n 15p` de los tres temas en `origin/main` | ✔ `# TEM-04 …`, `# TEM-05 …`, `# TEM-06 …` |
| `132` §3, mesa de E1-G | `grep -n '^## 3' -A6` | ✔ Núcleo + `C-ARQ-NET`, `C-ANALISTA`, `C-ACADEMICO` + `C-DEVOPS`, `C-CONFIG-RELEASE` |
| `240:76-83`, la cita a «230» no se reconstruye | `sed -n 76,83p` | ✔ |

### 4.2 C-ORDEN

| Cita | Resultado |
| --- | --- |
| `N10:505`, `:519` (onda 0 sin rama, folios «hechos») | ✔ |
| `dg.py:797` (raíces del workspace, dudosa de R4) | ✔ La línea es la lista de raíces |
| Hashes de las 4 piezas contra `INFORME.md` | ✔ (§4.1) |
| U01: «barrido S2 sobre los 13 archivos vacío» | ✘ No se cumple sin redactar antes. `grep -cE -f <patrón privado>` da 11 líneas en `S2-folios.txt` y 11 en `G-f-barrido-s2.txt`, y la propuesta no prevé esa redacción. Ajuste de la presidencia (§7.1): esas líneas salen de las clases genéricas del patrón, no de la lista literal privada, que da 0 |
| U04 etiqueta DEF-63 | ✘ DEF-63 es `evidencia/local` de FC, no la guía 06/15 (lo cubre su U06) |
| Cobertura de DEF | Etiqueta 73 de 76: faltan DEF-26 (alias de DEF-50), DEF-40 (fila de control) y DEF-55 (decidido en DEC-08 sin unidad) |

### 4.3 C-ENTREGA

| Cita | Resultado |
| --- | --- |
| Hallazgo propio: 11 coincidencias en `S2-folios.txt` (12, 47-51, 53-56, 58) y 12 en `G-f-barrido-s2.txt` (16, 47, 87, 95, 97, 100, 103, 107, 108×2, 125, 175) | ✔ Exacto: 11 líneas y 11 apariciones en el primero; 11 líneas y 12 apariciones en el segundo. Los otros 11 borradores dan 0. Ajuste de la presidencia (§7.1): ninguna coincidencia es un literal privado |
| Stash de LDD `c890bbb`/`7991ed1` | ✔ |
| `README.md` del cuerpo:59-63, `OBJ-SDEI-01…05` | ✔ |
| `INFORME.md:298` y `entorno-y-hashes.txt:15-16` | ✔ Las líneas 15-16 son los dos zips |
| U12: `cita-linea.mjs:6` en Lab-Documentos | ✘ El archivo existe sólo en LDD, `…/0002-…/evidencia/C-VERIFICACION/herramientas/` |
| U43 depende de U11-H-A (PR H) | ✘ Contradice su propia decisión DEC-H («E1-G2 no espera los merges H») |
| Cobertura de DEF | 75 de 76; falta DEF-40 (fila de control) |

### 4.4 C-NORMA

| Cita | Resultado |
| --- | --- |
| `N10` §3.3 (clase H a conformación «PO») frente a `N10` §14 («Todo PR, incluido el primer merge…») | ✔ `N10:74-76` frente a `N10:512`. Hallazgo propio y valioso |
| `refs/pull/14/head` = `5f1e0b4` en el remoto de LD | ✔ `git ls-remote` |
| Carátula `README.md:16` cita el folio `230` | ✔ |
| `grep -c obligatorio` en `R07` = 0 | ✔ 0 |
| `245:101-104`: `8c3fc99` cita `130` antes de que exista | ✔ |
| `131:54`, L6 opción (b) | ✔ |
| `Knowledge-Mesa-De-Expertos-A-Pedido:328` como fundamento de «cuatro rondas sin cierre, sube a quien pidió» | ✘ La línea 328 es el criterio de corte por rondas («dos rondas seguidas sin hallazgos; si no, por decisión»). No dice eso |
| R1-10: «en `34bdd44` no había `workflow_dispatch`», por eso agrega un commit con el disparador | ✘ `git show 34bdd44:.github/workflows/verificar.yml` y `60d94f3:…` ya tienen `workflow_dispatch`: el commit extra sobra |
| R1-09: borrar las ramas negativas «con 404 comprobado» | ✘ Repite el modo de pérdida de R1 (61 commits sueltos) si no se anclan antes |
| Cobertura de DEF | 76 de 76 |

## 5. Puntajes

Escala de 1 a 5 por criterio. Total sobre 30.

| Criterio | C-ORDEN | C-ENTREGA | C-NORMA |
| --- | --- | --- | --- |
| Fundamento (citas verificables) | 4 | 4 | 4 |
| Preservación (nada se pierde) | 5 | 5 | 4 |
| Seguridad (fugas contenidas, nada irreversible sin el PO) | 4 | 5 | 4 |
| Respeto de otras líneas | 5 | 5 | 5 |
| Ejecutabilidad (unidades chicas, aceptación con comando, olas coherentes) | 4 | 4 | 4 |
| Cierre de DEF-nn | 4 | 5 | 5 |
| **Total** | **26** | **28** | **26** |

Razones de las diferencias:

- **Seguridad.** Sólo C-ENTREGA detectó que versionar `evidencia/E1-G` tal cual publicaría literales privados. Es el
  único hallazgo que, si se pasaba por alto, producía una fuga nueva en el primer PR.
- **Preservación.** C-NORMA borra las ramas negativas al terminar. C-ORDEN y C-ENTREGA las anclan antes.
- **Ejecutabilidad.** Las tres tienen un defecto de dependencia o de premisa: el gate S2 de C-ORDEN sin remedio, la
  dependencia H de C-ENTREGA y el commit innecesario de C-NORMA. C-ENTREGA es la de unidades más chicas y con un solo
  dueño por archivo.
- **Cierre.** C-NORMA etiqueta los 76, C-ENTREGA 75 y C-ORDEN 73. Ninguna deja un defecto real sin tratar.

## 6. Fallo

**Se elige C-ENTREGA como base** (28/30) y se le injerta lo mejor de las otras dos. El plan final queda aprobado en
nombre del PO, salvo lo de §10.

Injertos:

| De | Qué | Dónde |
| --- | --- | --- |
| C-NORMA | Definición de P0 en la compuerta (dato privado introducido por el escalón en HEAD; falso verde; evidencia irreproducible) | DEC-11 |
| C-NORMA | Corrigenda de la contradicción de `N10` §3.3 frente a §14 | DEC-20, U10 (252) |
| C-NORMA | Despacho de Verificar sobre cada merge de LDD de la vuelta (no hay `push`) | DEC-12 |
| C-NORMA | Lista VER de R07 §5.3 y §5.13, y medida paralela sobre los 51 para comparar | DEC-15 |
| C-NORMA | Mecánica de la mesa B (cartas archivadas, a ciegas, verificadores sin silla) | DEC-17 |
| C-NORMA | Lo ajeno o pendiente del PO va como reserva nombrada: no cuenta como falla del escalón, pero el pase a E2-U0 lo espera | DEC-11 |
| C-NORMA | Comprobación de que `git status` de la guía 16 no cambia antes y después del resguardo; diffs limitados a `OUTPUTs/` | U00, U01, U28 |
| C-NORMA | Copiar las salidas de Actions a la evidencia (retención) | U32, riesgos |
| C-ORDEN | PR-7 «fijadas» probado con una pieza BASE-FIJADA sintética en rama no fusionable | DEC-13, U29 |
| C-ORDEN | Ramas negativas conservadas hasta que el folio cite los SHA; prohibición de comandos que disparan gc | DEC-02, DEC-13 |
| C-ORDEN | Prioridad de F7 y F8 (datos personales) dentro de la redacción | DEC-06 |
| C-ORDEN | Cierre ordenado (worktrees, ramas, MANIFIESTO) | U44 |
| C-ORDEN | Ratificación de la severidad de DEF-57 por la mesa B | DEC-05, DEC-17 |

Correcciones del jurado al plan base:

1. `cita-linea.mjs:6` se redacta en LDD (U28), no en un PR H de LD.
2. U43 ya no depende de U11-H-A: E1-G2 no espera los merges H y los declara como reserva.
3. Las aceptaciones con cantidades fijas (guía 16, inalcanzables) pasan a cantidades medidas en el momento.
4. Los folios 014 y 090 se redactan con una edición mínima declarada en 254, porque una corrigenda sola no saca el
   valor del HEAD.
5. Esta acta es el folio 250. La serie sigue en 251. (Ajuste: 240, 245, 249 y `evidencia/E1-G` entraron por el PR #27,
   merge `1bfc847`; esta acta entra en un PR propio de U01, rama `exp0002/e1g-acta-250`.)
6. Las notas de trabajo de la mesa también van al resguardo.

## 7. Decisiones

| Id | Pregunta | Decisión (síntesis) | Al PO |
| --- | --- | --- | --- |
| DEC-01 | Resguardo y clases de rescate | (a) y (d) no se integran; (b) no existe; (c) más los bundles de las dos ramas, todos los inalcanzables, el tar de la guía 16, los originales sin redactar y las notas de la mesa van a `{resguardo-privado}` antes de cualquier rama | No |
| DEC-02 | ¿Se borran rescates y objetos sueltos? | No, hasta E1-G2 y con ok del PO. Nada que dispare gc antes de U00 | **Sí** |
| DEC-03 | Lugar del resguardo | hpdev, fuera de los repos y de `{dir-de-trabajo}`, con réplica en infravm y `MANIFIESTO.sha256`; constancia 253 sin rutas. Se informa al PO | No |
| DEC-04 | Versionar 240/245/249/250 y `evidencia/E1-G` | Primer PR de la vuelta, sin literal privado en el diff, y la cuenta de G-g corregida (5 + 3). Ajustada en §7.1: `S2-folios.txt` y `G-f-barrido-s2.txt` no necesitan redacción; la cuenta va al folio `256` | No |
| DEC-05 | Severidad de DEF-57 e historia | No es P0 del escalón (lo introdujo `a4d26c8` de FC y lo sacó `7392d8d`). Es P0 de exposición de FC. Reescribir H1–H6 sale al PO, con default «no reescribir y rotar» | **Sí** |
| DEC-06 | Redacción hacia adelante | Esta mesa: F1, F2, F4 (con edición mínima declarada), F5 (con aviso), F6, F7, F8 y `cita-linea.mjs:6`. Aviso: F3 y `evidencia/local` a FC; F9 y F10 al PO; DEF-67 a Lab-E2E | No |
| DEC-07 | Patrón S2 | Dos partes: pública por clase (corrigenda 254) y lista literal privada en el resguardo; `grep -Ff` vacío como aceptación | No |
| DEC-08 | `{raíz-de-máquinas}` en FC (044:28) frente a la carta | En lo propio rige la carta; en FC, conflicto al PO con default «alias también en FC» | **Sí** |
| DEC-09 | Ramas y orden | Un worktree por unidad; prefijos `exp0002/e1g-*`, `e1r-*`, `e1r-rojo-*`, `e1r-h-*`, `e1g2-*`, `fc/*`; un dueño por archivo y ola; CHANGELOG en U33; merges seriales por CPA al SHA | No |
| DEC-10 | G-a | Defecto del plan para el E1 ejecutado; la corrigenda 251 con hora ISO se fusiona antes de toda rama `e1r`, y se mide con `%cI` y `created_at` | No |
| DEC-11 | Corte y P0 | 245 §7 ratificado; una sola vuelta; definición de P0; lo ajeno va como reserva y el pase a E2-U0 lo espera; nada se aprueba por silencio | No |
| DEC-12 | G-b | Equivalencia por árbol en LD; despacho sobre refs en `34bdd44` y `60d94f3` sin commits; denominador de 16 más E1-R, con E1-U6 declarado; despacho por merge de LDD | No |
| DEC-13 | G-c | Cada regla con exit≠0; pares rojo/verde sintéticos; BASE-FIJADA sintética; las ramas se conservan hasta citarlas | No |
| DEC-14 | G-d | Traces agregadas o modificadas por E1 en LD al 100 %, sin regresión ajena (≥ 83/89 en FC); LDD se informa; H1 a `# Tema 0n —` | No |
| DEC-15 | G-g | Lista VER cerrada en 251; guiones nuevos por tema en `evidencia/E1-R/ensayos/`, rotulados como nuevos (240 §4) | No |
| DEC-16 | Fase 1b y P-LECT | Decide el PO o su delegado por escrito (H); P-LECT con lector identificado, tres clases y PR simulado | **Sí** |
| DEC-17 | Mesa B | Por folio 263, según 132 §3, con agentes distintos y la mecánica de la mesa; ratifica DEC-05 | No |
| DEC-18 | Anexo L6 | Ola 4, Anexo A de 265, con evidencia de G-d y del P-LECT nuevo | No |
| DEC-19 | 230, 211 y numeración | Corrigenda 252 por referencia; 230 vacante; 211 citado por nombre; serie 250–265 | No |
| DEC-20 | Clase H | Rige la carta: H espera al PO; contradicción de N10 a la corrigenda 252; E1-G2 no espera los H | **Sí** |

El texto completo de cada decisión, con su fundamento, está en el plan estructurado que acompaña este folio, y se
transcribe a 251–254 cuando corresponde.

### 7.1 Ajuste de la presidencia a DEC-04

El fallo se mantiene: 240, 245, 249, esta acta y `evidencia/E1-G` se versionan sin ningún literal privado y con la
cuenta de G-g corregida. Lo que cambia es el medio. La presidencia midió sobre `main` (`d05955b`, tras el PR #27,
merge `1bfc847`) los dos archivos que el jurado señaló:

| Medida | `S2-folios.txt` | `G-f-barrido-s2.txt` |
| --- | --- | --- |
| Patrón completo, como el jurado (`grep -cE`) | 11 líneas | 11 líneas |
| Patrón completo sin distinguir mayúsculas (`grep -ciE`) | 12 líneas | 12 líneas |
| Sólo la lista literal privada (`grep -ciE` y `grep -ciF`) | **0** | **0** |

Todas las coincidencias salen de las clases genéricas del patrón: directorio personal, `/Users/`, `C:\Users`, red
`10.x` y red `192.168.x`. Son la descripción del propio patrón (`C:\Users`), el emulador de Android (`10.0.2.2`), un
número de versión (`10.0.400.1`), la red host-only de VirtualBox (`192.168.56.x`), rutas de runners alojados de
GitHub (`/home/runner`, `/Users/runner`), la ruta sintética `/home/x/otra` y una URL pública de NuGet (la línea que
sólo aparece sin distinguir mayúsculas). Son falsos positivos ya clasificados por los propios archivos. Por eso:

1. `S2-folios.txt` y `G-f-barrido-s2.txt` quedan como están en `main`. No se redactan y no van al resguardo.
2. La aceptación de U01 «patrón privado = 0» se lee sobre la lista literal privada. Las clases genéricas se
   clasifican caso por caso, como manda S2.
3. La cuenta de marcas de G-g (DEF-76) no se corrige en `245` ni en la evidencia: la corrige el folio `256`.
4. El riesgo «volver a filtrar en el primer PR» de §11 no se materializó.

## 8. Plan de unidades por ola

Clases: **D** determinista, **P** propuesta de agente (CPA), **H** espera al PO y **presidencia**.

### Ola 0 — contención y preservación

| Id | Unidad | Clase | Repo / rama | Aceptación (síntesis) | DEF |
| --- | --- | --- | --- | --- | --- |
| U00-RESG | Resguardo privado | D | refs locales `refs/resguardo/*` | `git bundle verify` en 4 bundles; 0 inalcanzables sin ancla; sha256 de las 4 piezas igual a INFORME:301-304; tar de la guía 16 con la misma cantidad que `find`; `git status` de LDD sin cambios; MANIFIESTO en 2 copias | 76 |
| U01-EVID | PR 240/245/249/250 y `evidencia/E1-G` (ajustada en §7.1) | P | LDD `exp0002/e1g-resolucion` (#27) y `exp0002/e1g-acta-250` | Patrón privado = 0 en el diff; sólo rutas bajo `OUTPUTs/`; 10 archivos en E1-G; Verificar verde y despacho sobre el merge | 76 |
| U02-AVISO | Lote al PO y avisos | presidencia | — | Mensaje sin valores; respuestas o «pendiente» en 260 | 57, 61-64, 66, 67 |
| U03-FC | Redacción de FC (la ejecuta FC o el PO) | P | LDD `fc/redaccion-s2-ola0` | `evidencia/local` versionados = 0; patrón sin reales en Concepts | 61, 62, 63 |

### Ola 1 — criterios de la vuelta y propuestas H

| Id | Unidad | Clase | Repo / rama | Aceptación (síntesis) | DEF |
| --- | --- | --- | --- | --- | --- |
| U10-DEC | Folios 251, 252, 253 | P | LDD `exp0002/e1g-corrigendas-vuelta` | Hora ISO con zona; dg.py sin errores en trazas `EXP0002-F*` (N09/N10 por convención previa, como en 249); merge anterior a toda rama `e1r` | 01, 02, 06, 07, 18, 55, 75 |
| U11-H-A | `verificar.yml`: SHA vigente, ruta del expediente y `push` | H | LDD `exp0002/e1r-h-verificar` | PR verde, «espera PO» | 05, 06, 17 |
| U12-H-B | CI de trazas de LD, fixtures y controles de dg.py, raíces | H | LD `exp0002/e1r-h-ci-trazas` | `ci-local.sh todo` y `autoprueba` en verde; rojo por fixture | 11, 12, 16, 29, 30, 34 |
| U13-H-C | `AGENTS.md:54` | H | LD `exp0002/e1r-h-agents` | lychee verde, «espera PO» | 41 |
| U14-H-D | Propuesta de etiquetas, tag y owner (255) | H | LDD `exp0002/e1r-h-politicas` | El tag existe sólo con el ok del PO | 21, 69 |

### Ola 2 — reparaciones E1-R (worktrees en paralelo, merges seriales)

| Id | Unidad | Clase | Repo / rama | Aceptación (síntesis) | DEF |
| --- | --- | --- | --- | --- | --- |
| U20-TRZ | H1 de TEM-04/05/06 y GUIA-INDICE | P | LD `exp0002/e1r-trazas` | Sin traza-ambigua; FC ≥ 83/89; no toca Concepts ni AGENTS | 14, 15 |
| U21-TXT-A | Marco, TEM-01…03, anexos | P | LD `exp0002/e1r-texto-marco` | Tabla DEF → archivo:línea; `ci-local.sh todo` verde | 19, 20, 23-25, 29-34, 38, 42, 43, 46 |
| U22-TXT-B | TEM-04…07, Ejercicios, Lista | P | LD `exp0002/e1r-texto-temas` | «Fuentes y observaciones» en 04-07; VER-I04 condicionado | 35, 36, 37, 54 |
| U23-TXT-C | Tutorial, Como-Intervenir, Examples | P | LD `exp0002/e1r-texto-tutorial` | Anterior/siguiente; índice; atajo ensayado | 22, 39, 44, 45, 47, 48, 52, 53 |
| U24-1B | Fase 1b coherente | P | LD `exp0002/e1r-fase-1b` | El mismo decisor en todos los archivos | 27, 28 |
| U25-ENS-LDD | Guiones nuevos TEM-01…07 | P | LDD `exp0002/e1r-ensayos` | 7 carpetas; `bash guion.sh \| diff - salida.txt` vacío; rótulo de 240 §4 | 13, 50, 51 |
| U26-ENS-LD | Remisiones a los ensayos | P | LD `exp0002/e1r-remisiones-ensayo` | 0 remisiones a `E1-U4b`/`E1-U4c`; URL+SHA con respuesta 200 | 26, 50 |
| U27-FUGA-LD | F1, F2 | P | LD `exp0002/e1r-fugas-ld` | 0 reales en LD | 58, 59 |
| U28-FUGA-LDD | F4–F8, `cita-linea.mjs:6`, corrigenda 254 | P | LDD `exp0002/e1r-fugas-ldd` | Sólo `OUTPUTs/`; `grep -Ff` vacío; quedan sólo F3, F9, F10 y los falsos positivos | 60, 64, 66, 68 |
| U29-RV | Pares rojo/verde | P | `exp0002/e1r-rojo-*` (no se fusionan) | Roja y verde por control; material sintético; ancla local; se borran sólo tras 260 | 08-12 |
| U30-GB | Equivalencia por árbol y despachos | P | refs `exp0002/e1r-gb-u0b`, `-u0c` sin commits | Árboles iguales; success con head_sha `34bdd44` y `60d94f3` | 03, 04 |
| U31-MED | E-F4, E-F10, E-F13, E-F14, fuentes | P | LDD `exp0002/e1r-medidas` | Comando, salida y SHA de 40 caracteres | 71, 73 |

Orden de merge en LD: U20 → U21 → U22 → U23 → U24 → U26 → U27. En LDD: U25 ∥ U28 ∥ U31, serializados al fusionar.

### Ola 3 — integración

| Id | Unidad | Clase | Repo / rama | Aceptación (síntesis) | DEF |
| --- | --- | --- | --- | --- | --- |
| U32-REG | Registro de E1-R (260) y `evidencia/E1-R` | P | LDD `exp0002/e1r-registro` | Tabla PR → SHA → corrida → DEF re-medida sobre main | 73 |
| U33-CHLOG | CHANGELOG único de la vuelta | P | ambos `exp0002/e1r-changelog` | Una entrada por merge; FC intacto | — |
| U34-IADB | ia-db v4.2 | P | LDD `exp0002/e1r-iadb` | 0 piezas sin indexar desde `fe10086` | 56 |
| U35-LECC | Lecciones a DocsAsCode-Bitacoras | P | LDD `exp0002/e1r-lecciones` | Índice enlazado; sólo `OUTPUTs/` | 72 |

### Ola 4 — re-verificación E1-G2 y cierre

| Id | Unidad | Clase | Repo / rama | Aceptación (síntesis) | DEF |
| --- | --- | --- | --- | --- | --- |
| U40-SWEEP | Barrido S2 de los 3 repos | P | LDD `exp0002/e1g2-barrido` | 0 sin clasificar; 0 reales propios; lo ajeno, con dueño | 65, 68 |
| U41-MED | G-a…G-g, verificador y refutador | P | LDD `exp0002/e1g2-medidas` | Instrumentos de 251; G-a por `%cI` y `created_at` | 56 |
| U42-PLECT | P-LECT nuevo con PR simulado | P | `exp0002/e1g2-plect-*` | 0 sin respuesta y 0 no alcanzadas; PR cerrado sin merge | 49 |
| U43-RES | Mesa B (263) y resolución de E1-G2 (265) con L6 | presidencia | LDD `exp0002/e1g2-resolucion` | Voto por criterio y corte; L6 completo; control del recuento | 40, 70, 74 |
| U44-CIERRE | Worktrees, ramas, MANIFIESTO | D | local | Sólo main, rescates y H abiertas; MANIFIESTO OK | — |

Cobertura: las 30 unidades etiquetan DEF-01…DEF-76 sin faltantes. El jurado lo comprobó por script sobre el plan
estructurado. DEF-26 remite a DEF-50 y DEF-40 es la fila de control.

## 9. Resguardo

Privado, no versionado y declarado como `{resguardo-privado}`: una carpeta de hpdev fuera de los repos y de
`{dir-de-trabajo}`, con réplica en infravm y un `MANIFIESTO.sha256` que se verifica en las dos copias. Contenido:

1. Un `git bundle` de cada rama `rescate/hpdev-2026-10-28` (LD `674466c`, LDD `20cd8bb`): la foto del puente 1.0, la
   ia-db v4.0 y las versiones sin redactar de FC.
2. Las 4 piezas (c) de E01 (2 APK y 2 zips), con sha256 verificado contra `INFORME.md:301-304`.
3. Todos los commits inalcanzables, contados al ejecutar (hoy 63 en LD y 9 en LDD), anclados en `refs/resguardo/*`
   locales y empaquetados en un bundle. Incluyen la rama negativa borrada, `5f1e0b4`, el stash `c890bbb`/`7991ed1` y
   `88e8265`.
4. Un tar de sólo lectura de `PROMPTs/Guides/16-IA-Layer` con su manifest (hoy 390 archivos, de los que al menos 316
   no tienen otra copia), hecho sin tocar el árbol.
5. Los originales sin redactar de `evidencia/E1-G/S2-folios.txt` y `G-f-barrido-s2.txt`.
6. Los valores reales de la mesa: la parte privada del patrón S2, el archivo local de valores de R4 y los `.hits`.
7. Las notas de trabajo de la mesa (R1–R5, sus crudos, las propuestas y el plan).
8. Más adelante, las refs de las ramas rojo/verde, de los despachos de G-b y del PR simulado, una vez citadas.

Lo de clase (a) y (d) no se integra, porque ya está en `main` o se regenera, pero queda en el bundle. Lo de clase (b)
no existe (R2 = 0, R3 = 0), así que ningún PR nace del rescate. Los valores que se redactan hacia adelante sólo
sobreviven como dato en el resguardo y en la historia pública, hasta que el PO decida (§10).

## 10. Lo que sale al PO

Es un lote: cada ítem lleva default y reversibilidad, y nada se asienta por silencio.

| # | Ítem | Default sugerido | Reversible |
| --- | --- | --- | --- |
| 1 | Reescribir la historia pública (H1–H6 de R4, incluido DEF-57 en `a4d26c8`), con force-push y pedido de purga al proveedor | No reescribir; rotar lo rotable. Si se reescribe, una sola operación después de E1-G2, con bundles y mapa de SHA | **No** |
| 2 | Borrar las ramas de rescate y las refs del resguardo después de E1-G2 | Conservarlas | Borrarlas, no |
| 3 | Paquete H: U11 (`verificar.yml`), U12 (CI de trazas y dg.py), U13 (`AGENTS.md:54`), U14 (etiquetas, tag `docs-guard-v1.0.0`, owner/alias) | Aprobar U11 y U12 primero | Sí, salvo el tag |
| 4 | `{raíz-de-máquinas}` en 24 líneas de FC (folio 044:28) frente a la carta común | Alias también en FC, por PR de su sesión | Sí |
| 5 | F9 y F10: identificadores privados y usuario en prompts del PO fuera de `OUTPUTs/` | Redacción por el PO | Sí |
| 6 | F5 (DEF-66): entró por el PR #24 del PO; esta mesa lo redacta en U28 | Aceptar la redacción | Sí |
| 7 | Quién decide la fase 1b (D-15, D-16) y si hay delegación escrita | Pendiente de delegación | Sí |
| 8 | Lugar del resguardo (informativo; lo decidió la mesa) | hpdev + infravm | Sí |

Avisos a otras líneas (no son decisiones del PO): a Framework-Concept, F3, los 12 archivos versionados de
`evidencia/local`, el `runs-on` de `framework-concept-demo.yml`, los 6 errores de trazas previos y `GUIA-INDICE` en
su `Developer-Guide.md`; al dueño de Lab-E2E.WebBlazor, DEF-67; a la guía 16, que tiene archivos sin copia
versionada, resguardados en U00 sin tocar su carpeta.

## 11. Riesgos

- **Volver a filtrar** en el primer PR, si se versiona la evidencia de G-f tal cual. Mitigación: U01 redacta y su
  aceptación exige patrón = 0. (Ajuste, §7.1: medido, la lista literal privada da 0; no hubo que redactar.)
- **Sesión viva de la guía 16** en el checkout principal de LDD. Mitigación: worktrees, U00 primero y comandos
  prohibidos.
- **Inalcanzables que cambian** mientras se trabaja y que caen con gc. Mitigación: inventario al ejecutar y nada que
  dispare gc antes de U00.
- **`main` de LDD se mueve** por la línea FC. Mitigación: rebase antes de la guarda y merge al SHA.
- **G-a de la vuelta** cae si una rama `e1r` nace antes de 251. Mitigación: dependencia dura de U10.
- **Verificar con la suite mínima** hasta que el PO fusione U11. Mitigación: dg.py en local y reserva declarada.
- **Runner de FC**: según 245 §6, hpdev tiene las mismas etiquetas. Hay que verificarlo con una corrida antes de
  tratarlo como bloqueo.
- **SHA públicos** de las ramas rojo/verde. Mitigación: material sintético y revisión del diff.
- **Retención de Actions**. Mitigación: salidas copiadas a la evidencia.
- **Historia expuesta** hasta que el PO decida (§10, ítem 1).
- **Contradicción de N10** (§3.3 frente a §14). Mitigación: corrigenda 252 y cláusula en cada carta.
- **Vuelta única**: si E1-G2 no da PROCEDE, E1 vuelve al PO para replanteo.
- **Resguardo en dos discos**: sin réplica se repite la pérdida de i7infra. Mitigación: dos copias verificadas antes
  de cerrar la ola 0.

## 12. Lo no verificado

- Las cantidades de R2 y R3 por clase (179/341, 4/283) no se volvieron a contar. Se toman de esos relevamientos.
- El árbol de `34bdd44` frente a su cabeza no se volvió a medir. Se mide en U30.
- Que hpdev-runner-dev tome los trabajos de `framework-concept-demo.yml` no se probó. Queda como riesgo.
- Las URL de las corridas citadas por `245` no se volvieron a consultar.

## 13. Pase

A la presidencia, para ejecutar la ola 0 (U00 → U01 → U02) y despachar el lote de §10 al PO · presidencia.
