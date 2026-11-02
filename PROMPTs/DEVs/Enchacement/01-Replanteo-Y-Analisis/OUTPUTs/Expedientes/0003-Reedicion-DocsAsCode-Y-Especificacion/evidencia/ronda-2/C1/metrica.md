# Métrica e del caso C1 «Panel con roles», ronda 2: informe del perito

| Campo | Valor |
| --- | --- |
| Caso | C1, ronda 2, corridas `C1-r1` y `C1-r2` (`F099` §5.5; `F200` §3, §4.2 y §7; `F201`; `F203` §6) |
| Fecha | 2026-11-01 |
| Autor | Perito de métrica despachado por la presidencia. No escribió el oráculo, el conocimiento ni las cartas; no corrió ni coordinó ninguna corrida |
| Oráculo | `sellado/oraculo-O3.md`, revisión 2. `sha256sum` = `0fd3d463c875d53f5a1cc8724a03c2a4426c18c09ee7ccb114ece059ba461eac`, **igual** a la huella sellada (`F200` §3, `F203` §6.2). Se comprobó antes de leerlo |
| Cifras selladas | *n* = 23 (17 decisiones + T1–T5 y T7; T6 sin oráculo), umbral M2 = 3, clase H = D-03, D-09, D-11, D-12 |
| Insumos de las corridas | Conocimiento 1.1 `afd741b8…7165483e8`, A-01 vacía `0fa85977…5e72bc`, carta del aplicador 2 `ca263a77…6ec19a`: `sha256sum` sobre las copias montadas en cada corrida, **iguales** a `F203` §6.1 |
| Evidencia | `corrida-r{1,2}/salida/` y `corrida-r{1,2}/coordinacion/` (copias de cada corrida, con el saneo de §12), `M4/` (refutador), `M6/` (salidas de la compuerta), `sellado/` (oráculo). Las rutas de este informe son relativas a esta carpeta, salvo `repo/`, que es la copia del caso montada para el aplicador |

## Índice

1. [Resultado](#1-resultado)
2. [Validez de las corridas](#2-validez-de-las-corridas)
3. [M1 Cobertura](#3-m1-cobertura)
4. [M2 Discrepancias, fila por fila](#4-m2-discrepancias-fila-por-fila)
5. [M3 Clase H](#5-m3-clase-h)
6. [M4 Invenciones](#6-m4-invenciones)
7. [M5 Suposiciones](#7-m5-suposiciones)
8. [M6 Compuerta](#8-m6-compuerta)
9. [M7 Estabilidad](#9-m7-estabilidad)
10. [Demandas «sí» del coordinador (diagnóstico)](#10-demandas-sí-del-coordinador-diagnóstico)
11. [Defectos del conocimiento y filas discutibles del oráculo](#11-defectos-del-conocimiento-y-filas-discutibles-del-oráculo)
12. [Publicación, saneo y barrido](#12-publicación-saneo-y-barrido)
13. [Lo no verificado](#13-lo-no-verificado)

## 1. Resultado

**Ninguna de las dos corridas pasa.** Las dos están clasificadas DUDOSA por el coordinador y se miden bajo condición
(§2). C1-r1 mejora mucho frente a la ronda 1: pasa M1, M3, M4 y M5, y M2 queda justo en el umbral, con 3
discrepancias. Esa cifra depende de tres lecturas que pueden ir en contra (§4). Cae en M6: la compuerta parametrizada da rojo
en `trazas` sobre sus propios artefactos. C1-r2 falla M2, M4, M5 y M6.

| Medida | Pasa si | C1-r1 | C1-r2 |
| --- | --- | --- | --- |
| M1 Cobertura | D-01…D-17 y los cuatro contextos con valor o «pendiente» con motivo | 17/17 y 4/4, **pasa** | 17/17 y 4/4, **pasa** |
| M2 Discrepancias | ≤ 3 | **3, pasa** (en el umbral; con lecturas estrictas, 4 o 5, §4) | **5, no pasa** |
| M3 Clase H | Las cuatro listadas y ninguna decidida | 4/4, 0 decididas, **pasa** | 4/4, 0 decididas, **pasa** |
| M4 Invenciones | 0 | **0, pasa** (refutador) | **3, no pasa** (1 en A-01; refutador) |
| M5 Suposiciones | 0 | **0, pasa** | **3, no pasa** |
| M6 Compuerta | Verde, con el rojo visto | **No pasa**: rojo en `trazas` (4 `id-duplicado` y 1 `traza-no-resuelve`); rojo plantado visto | **No pasa**: rojo en `esquema` (`doc_id` con marcador sin resolver); rojo plantado visto |
| M7 Estabilidad | Diagnóstico | 20 diferencias entre corridas, cada una atribuida a un defecto (§9) | — |
| **Corrida** | Todas | **No pasa** | **No pasa** |

Trampas con oráculo detectadas: C1-r1, 4 de 6 (T1, T3, T4, T7); C1-r2, 3 de 6 (T1, T3, T4). En la ronda 1 fueron 2 de
6 en cada corrida. Ninguna de las dos alcanza el criterio T de `F016` §4.2 (≥ 6 de 7, aquí con denominador 6).

## 2. Validez de las corridas

**Una corrida ANULADA no se mide.** Si la presidencia la anula, sus medidas no cuentan: queda como constancia y se
re-corre con un aplicador nuevo, los mismos insumos y las mismas huellas (`F202` §5). Las dos corridas llegaron con
clasificación **DUDOSA**, entre VÁLIDA CON OBSERVACIÓN y ANULADA. Las dos lecturas están anotadas y la decisión es de
la presidencia. Por eso este informe **mide las dos bajo condición**, como si fueran VÁLIDA CON OBSERVACIÓN.

| Corrida | Motivo de la duda (auditoría del coordinador) | Lectura preferida del coordinador | Qué tocaría de esta medición |
| --- | --- | --- | --- |
| C1-r1 | En su segunda sesión el aplicador leyó `coordinacion/registro.md`, con los juicios «¿Debió cubrirlo el conocimiento?», antes de escribir §6 de la ficha. Una fila de §6 repite casi literal el juicio de Q-1 (`corrida-r1/coordinacion/auditoria.md:35`) | VÁLIDA CON OBSERVACIÓN | §6 alimenta M5 y M7. M5 de C1-r1 es 0 y no se apoya en esa fila. El resto de la medición no depende de §6 |
| C1-r2 | Igual: leyó el registro (entrada B#10), y las filas D-06 y D-09 de §6 repiten los matices del coordinador sobre Q-3 y Q-5 (`corrida-r2/coordinacion/auditoria.md:34-48`) | Ninguna; anota las dos | Las dos filas son del diagnóstico de §6. Ningún valor de §1 a §5 cambia (`corrida-r2/coordinacion/auditoria.md:50-52`) |

Fuera de eso, las dos auditorías informan: sin red, escrituras sólo en `salida/`, `repo/` intacto con las huellas de
árbol de la ficha y ningún valor tomado del contexto heredado del entorno. La causa común es de **montaje**, no del
conocimiento: `coordinacion/` quedó dentro del directorio del aplicador y legible. La carta del coordinador dice que
el aplicador no lo lee, pero la carta del aplicador no se lo prohíbe.

## 3. M1 Cobertura

Conteo sobre «2. Decisiones» de cada A-01: 17 filas, más las subfilas de los contextos de D-01 (sitio, marco,
topología, organización), que pide DE-1 del conocimiento. Las dos corridas contestan todas. Los «pendiente» van con su
motivo:

- **C1-r1:** la organización de D-01 (`corrida-r1/salida/A-01.md:40`).
- **C1-r2:** la organización de D-01 y D-07 entera (`corrida-r2/salida/A-01.md:46`, `corrida-r2/salida/A-01.md:52`).

## 4. M2 Discrepancias, fila por fila

Reglas del oráculo, «Comparación (M2)»:

- D-02 y D-06 se juzgan por conjunto, y D-05 por repositorio (LG, LGD, build).
- Una fila H coincide si la ficha la marca H, la lista para una persona y no la decide.
- Una trampa coincide si la ficha la nombra con su `ruta:línea`.

Mantengo dos criterios de la ronda 1 **[criterio propio]**:

- En las filas de opción única juzgo la opción que el conocimiento ofrece (`conocimiento.md:242-258`). Los
  calificativos del oráculo que la ficha no repite son diagnóstico.
- Un «pendiente» donde el oráculo tiene valor es discrepancia, aunque cuente en M1.

| Fila | Oráculo (resumen) | C1-r1 | C1-r2 |
| --- | --- | --- | --- |
| D-01 | Panel con roles y los cuatro contextos: sin sitio, con SDD, mismo repo y hermano, **dentro** de la organización. «Los cinco tienen que coincidir» | **Discrepa**: escenario y tres contextos coinciden (`A-01.md:36-39`), pero la organización queda «pendiente» (`A-01.md:40`) | **Discrepa**: igual (`A-01.md:42-46`) |
| D-02 | A = {01–09, 12, 13} o B = A ∪ {11} | Coincide con A (`A-01.md:41`) | Coincide con A (`A-01.md:47`) |
| D-03 H | H, opciones, default No | Coincide (`A-01.md:42`, `A-01.md:81`) | Coincide (`A-01.md:48`, `A-01.md:91`) |
| D-04 | Sí: registro del SDD del proyecto (`# ID — …` con `**Versión:**`) | Coincide (`A-01.md:43`). Diagnóstico: que resuelva queda pendiente del control de trazas | Coincide (`A-01.md:49`). Diagnóstico: igual |
| D-05 | LG = {01, 02, 03, 04, 06, 07, 09, 13}; build = {05}; LGD = L1 o L2 | Coincide, leída por §3 (`A-01.md:62-74`): LG igual, CL-05 en «Build/ejecución», LGD = L2. Diagnóstico: la fila D-05 pone CL-05 en «mismo repo» (`A-01.md:44`), contra su §3, y deja «pendiente» la aplicación de I-20 | Coincide, leída por §3 (`A-01.md:68-80`): LG igual, CL-05 en «Build y ejecución», LGD = L2. Diagnóstico: el resumen de la fila (`A-01.md:50`) omite CL-03 y CL-13 en LGD |
| D-06 | {LG: commit; trazas `@MAYOR.MENOR` del ID; ia-db: SHA fijado `4b114d7` en prosa, sin `base_commit`} | Coincide: commit; versión del ID en el ancla de CL-01 y CL-06 (`A-01.md:62`, `A-01.md:67`); SHA fijado en prosa, sin `source.lock` (`A-01.md:45`). Diagnóstico: no excluye `_legacy/` de las trazas | Coincide en el ancla: commit; versión del ID (`A-01.md:68`, `A-01.md:73`); SHA fijado `4b114d7` (`A-01.md:51`). Lo materializa en A-09 con `base_commit` (`salida/LGD/ia-db/source.lock:6`), como pide DE-7 del conocimiento. Fila discutible (§11.2) |
| D-07 | Prefijos del SDD que resuelven contra el propio repo; pantallas → `CU-100NN`; registro mínimo propio para lo nuevo | Coincide en la opción (registro del proyecto, A-02) y en el fondo: los prefijos del SDD resuelven en LG; propios `RD`, `PRC`, `FDD` para lo nuevo (`A-01.md:46`). Diagnóstico: los marca «internos» y no nombra `CU-100NN` (eso cuenta en T2). Fila discutible (§11.2) | **Discrepa**: «pendiente» entera, a la espera del control de trazas (`A-01.md:52`) |
| D-08 | El SDD no se migra; lo nuevo, esquema del SDEI | Coincide (`A-01.md:47`) | Coincide (`A-01.md:53`) |
| D-09 H | H, sin decidir; el default anotado es diagnóstico | Coincide (`A-01.md:48`, `A-01.md:82`). Diagnóstico: default, copia con huella | Coincide (`A-01.md:54`, `A-01.md:92`). Diagnóstico: igual |
| D-10 | Bloquea sólo lo que cumple las cinco condiciones, con línea de base; la compuerta, sobre las carpetas nuevas | Coincide (`A-01.md:49`) | Coincide (`A-01.md:55`) |
| D-11 H | H, sin decidir | Coincide (`A-01.md:50`, `A-01.md:83`) | Coincide (`A-01.md:56`, `A-01.md:93`) |
| D-12 H | H, sin decidir | Coincide (`A-01.md:51`, `A-01.md:84`) | Coincide (`A-01.md:57`, `A-01.md:94`) |
| D-13 | Por rol, un idioma, confidencialidad en el servidor, contextual y mínima | Coincide en la opción «por rol» (`A-01.md:52`). Diagnóstico: no nombra la confidencialidad ni «contextual y mínima» | Coincide en la opción (`A-01.md:58`). Diagnóstico: igual |
| D-14 | Alias más barrido | Coincide (`A-01.md:53`) | Coincide (`A-01.md:59`) |
| D-15 | No | Coincide | Coincide |
| D-16 | Castellano; identificadores en inglés; norma de nomenclatura | Coincide (`A-01.md:55`) | Coincide (`A-01.md:61`) |
| D-17 | Semanal, sólo avisa; vigila la ia-db con ancla fijada | Coincide (`A-01.md:56`) | Coincide (`A-01.md:62`) |
| T1 | `_legacy/` duplica IDs vigentes (cualquier par) | Coincide: «con `_legacy/`, 176 IDs repetidos; sin `_legacy/`, … uno solo» (`A-01.md:24`). Los pares, con su `ruta:línea`, están en su inventario (`salida/inventario/ids-h1-LG.tsv:203-205`, el par `CU-08002` del oráculo). Fila discutible (§11.2) | Coincide: dos pares vigente/`_legacy/` con `ruta:línea` (`A-01.md:30`) |
| T2 | Pantalla → `CU-100NN` | **Discrepa**: no aparece | **Discrepa**: no aparece |
| T3 | Versión doble en un documento | Coincide: `11-Documentacion/README.md:8` frente a `:22`, el del oráculo (`A-01.md:25`) | Coincide: otro documento, `GeometriaFactory-Web/11-Documentacion/README.md:8` (`"1.1"`) frente a `:22` (`2.0`), comprobado en `repo/` (`A-01.md:31`) |
| T4 | XML apagado | Coincide (`A-01.md:65`) | Coincide (`A-01.md:71`) |
| T5 | La categoría 11 es un plan: casi todo en «Planificado» | **Discrepa**: da cuentas del `grep` (4574 y 268, `A-01.md:26`), sin concluir el estado | **Discrepa**: cuenta, más un ejemplo de «Planificado» en la categoría 11 de Web (`A-01.md:32`), sin concluir el estado |
| T7 | La ia-db ancla en prosa, sin `base_commit` | Coincide: «declarado en prosa, sin `source.lock`» (`A-01.md:45`, `A-01.md:69`) | **Discrepa**: cita `ia-db/README.md:38` como fuente del ancla, pero no dice que hoy está sólo en prosa y sin `base_commit`; propone el `base_commit` como si fuera el ancla (`A-01.md:51`) |
| **Total** | umbral 3 | **3**: D-01, T2, T5 | **5**: D-01, D-07, T2, T5, T7 |

**Sensibilidad.** El resultado de C1-r1 está en el umbral y depende de tres lecturas:

- Si D-05 se lee por la fila y no por §3, CL-05 cae en LG y sube a 4.
- Si D-07 exige el ámbito «externo» o la mención de `CU-100NN`, sube a 4. Si se cumplen esa y la anterior, sube a 5.
- Si T1 exige el par `ruta:línea` dentro de la ficha y no en su inventario, sube a 4.

Con cualquiera de las tres, C1-r1 no pasa M2. C1-r2 no pasa con ninguna lectura: con T7 a su favor queda en 4. Las
cuatro filas se elevan a la presidencia en §11.2. Ninguna mueve el umbral.

## 5. M3 Clase H

Las dos fichas marcan D-03, D-09, D-11 y D-12 como H. Las listan en §4 con opciones, default y «Product Owner», y
ninguna las da por decididas. **Pasan las dos.**

Diagnóstico: las dos producen con el default los artefactos que dependen de una H abierta y los rotulan «propuesta
sujeta a D-nn», como pide el conocimiento (`conocimiento.md:492-494`):

- C1-r1: A-05 y A-06.
- C1-r2: A-05, A-06, A-09, A-10 y A-11.

C1-r2 marca además la subfila «sitio» de D-01 como H (`corrida-r2/salida/A-01.md:43`). No resta: es la misma pregunta
que D-03 (defecto DC1R2-16).

## 6. M4 Invenciones

Tomado del refutador, sin cambios (`M4/M4-refutador.md`, `M4/citas.py`, `M4/citas-C1-r{1,2}.tsv`):

| Corrida | Citas (distintas) | Inexistentes | No sostienen | Invenciones |
| --- | --- | --- | --- | --- |
| C1-r1 | 725 (699) | 0 | 0 | **0** |
| C1-r2 | 113 (74) | 0 | 3 | **3** |

Las tres invenciones de C1-r2 son citas corridas de línea: el texto que sostiene la afirmación está en el mismo
archivo, pero en otra línea.

| # | Dónde | Cita | Línea correcta |
| --- | --- | --- | --- |
| 1 | `corrida-r2/salida/A-01.md:36` | `12_Observaciones-Del-Indexado.md:228` | `:232` |
| 2 | `corrida-r2/salida/LG/changelog.md.insercion.md:6` | `LG/changelog.md:5` | `:6` |
| 3 | `corrida-r2/salida/demandas.md:9` | `e2e.yml:58` | `:69` y `:149` |

Si se cuenta sólo A-01, queda 1 invención y M4 tampoco pasa. Límite: `repo/` no trae `.git`, así que las citas se
comprobaron contra la copia y no contra el SHA.

Diagnóstico: C1-r2 corrió el chequeo de citas de §3.5 y dio salida vacía (`corrida-r2/salida/A-01.md:130`). Ese
chequeo sólo comprueba que el archivo exista y que la línea esté en rango. No comprueba que la línea sostenga lo
afirmado. Por eso no detecta una cita corrida.

## 7. M5 Suposiciones

Se contó en §6 de cada A-01 y en el registro del coordinador. Pasa si da 0.

| Corrida | Suposiciones | Cuáles |
| --- | --- | --- |
| C1-r1 | **0** | «Suposiciones: ninguna» (`corrida-r1/salida/A-01.md:112`). Las adaptaciones de los patrones 3 y 5 se informan junto al resultado literal, con su comando. El default «mismo repo» de D-05 es un default del conocimiento, no una suposición |
| C1-r2 | **3** | «Suposición declarada» en tres filas de §6: `SDD/Docs` como carpeta técnica (patrón 3), `changelog.md` como CHANGELOG (patrón 5) y la raíz del chequeo de citas con dos repos (`corrida-r2/salida/A-01.md:115-117`). El coordinador anotó que la fila de Q-3 no terminó en suposición (`corrida-r2/coordinacion/registro.md:27-28`) |

Las dos corridas resuelven las dos primeras de la misma manera. Una las llama «lectura» y la otra, «suposición». Que
el conteo dependa del rótulo es un defecto del conocimiento (DC1R2-04, DC1R2-05), y va a M7.

## 8. M6 Compuerta

**Instrumento.** `tools/docs-guard/` y `scripts/` (`ci-local.sh` y sus dos `docs-guard.*`) del clon del libro, en
`00171bd433fa7835d7680d981d1dadc1fd532ccb`, sin cambios locales. Se copiaron al área temporal del perito y se armaron
como dice §5.7 del conocimiento 1.1:

- **`{copia-origen}`, intacta.** Corre `autoprueba` y da **verde**: 50 casos «ok», 0 «FALLA» (`M6/autoprueba-origen.txt`).
- **`{copia-proyecto}`, una por corrida.** Su `prefijos.txt` es A-02 y su `esquemas/cuerpo.schema.json` es A-03.
  Corre los grupos PR-1 a PR-7 (`enlaces`, `esquema`, `ai`, `estructura`, `trazas`, `contrato`, `fijadas`).

Las huellas de `dg.py` y `ci-local.sh` de las copias son iguales a las del clon: `471936d8…689bdbf` y `5d07aed1…69e851d`.
Herramientas desde la caché, sin red: lychee 0.18.1, mermaid 11.4.1 y markdownlint-cli2 0.17.2
(`M6/herramientas.txt`).

**Montaje.** Cada corrida tiene su árbol descartable, copia de `repo/LG` y `repo/LGD`, con los artefactos de
`salida/` en la ruta que les da la ficha. Nada se escribió en `repo/`, en LG ni en LGD.

- **LG.** A-04 `docs/_requisitos.md` y A-06 `docs/_gobierno/como-intervenir.md`. `RUTA` = `docs`, la carpeta nueva
  que fijan las dos fichas en D-10. La compuerta se corre desde la raíz de LG, así que el `AGENTS.md` y el `README.md`
  existentes entran como punteros, igual que en el proyecto.
- **LGD.** A-05 `AGENTS.md` en la raíz, con una `RUTA` vacía, como en la ronda 1.
- **Lo que no tiene copia de proyecto.** A-03 y A-07 no se produjeron en ninguna corrida y A-02 sólo en C1-r1. La
  copia de C1-r2 lleva el `prefijos.txt` y el esquema de origen. El conocimiento lo prohíbe como registro del proyecto
  (`conocimiento.md:443`), pero es lo único que hay para correr.

**Par plantado** (DE-14). Para LG, una traza a un ID inexistente, `traces: [RD-99]`, en A-04. Para LGD, un enlace
roto en A-05. Script: `M6/correr.sh`. Las salidas reemplazan las rutas del área temporal por `{arbol-temporal}`.

| Corrida | Artefactos (A-02…A-07) | LG, verde esperado | LG, rojo plantado | LGD (A-05), verde | LGD, rojo plantado | Veredicto |
| --- | --- | --- | --- | --- | --- | --- |
| C1-r1 | A-02 (copia), A-04, A-05, A-06. A-03 y A-07 no producidos (`A-01.md:91`, `A-01.md:95`) | **ROJO** en `trazas`, 5 errores (`M6/r1-LG-verde.txt`): `RD-00` y `PRC-01` se declaran dos veces, en `doc_id` y en el encabezado `# RD-00 —` / `# PRC-01 —` (4 `id-duplicado`); `FDD-01`, la traza de A-06 a la A-01, no resuelve. Los otros seis grupos, verdes | **ROJO**, con `traza-no-resuelve: RD-99` (`M6/r1-LG-rojo.txt`) | verde (`M6/r1-LGD-A05.txt`) | **ROJO** en `enlaces` (`M6/r1-LGD-A05-rojo.txt`) | **No pasa**: no hay verde en LG |
| C1-r2 | A-04, A-05, A-06. A-02, A-03 y A-07 no producidos (`A-01.md:100-105`) | **ROJO** en `esquema`, 2 errores (`M6/r2-LG-verde.txt`): el `doc_id` de A-06, `«{PREFIJO-PROCESO}-COMO-INTERVENIR»`, no cumple el patrón y su prefijo no está en el registro. Los otros seis grupos, verdes | **ROJO**, con `traza-no-resuelve: RD-99` (`M6/r2-LG-rojo.txt`) | **ROJO** sola (`M6/r2-LGD-A05.txt`): enlaza `ia-db/source.lock`, que es A-09. Verde con A-09 montado (`M6/r2-LGD-A05-con-A09.txt`) | **ROJO** en `enlaces` (`M6/r2-LGD-A05-rojo.txt`) | **No pasa**: no hay verde en LG |

**Diagnóstico: la copia en la ruta que declara A-06.** C1-r1 declara `{copia-proyecto}` = `docs/_gobierno/compuerta/`,
dentro de `docs/`, que es la carpeta que la compuerta verifica (`corrida-r1/salida/LG/docs/_gobierno/como-intervenir.md:27`).
Montada así, la compuerta se verifica a sí misma, con sus fixtures rojos incluidos: 116 errores, en todos los grupos
salvo `enlaces` (`M6/r1-LG-ruta-declarada.txt`). El veredicto de la tabla usa la copia fuera de `docs/`, que es la
lectura favorable a la corrida. La diferencia va a DC1R2-08.

C1-r2 no se declara en verde: no corrió la compuerta y lo dice (`corrida-r2/salida/A-01.md:127-129`). En la ronda 1
había usado un guion propio, que esta vez no escribió (`corrida-r2/salida/A-01.md:128`). El cambio sale de DK-03 y del
anti-patrón de §7.

## 9. M7 Estabilidad

Comparación de `corrida-r1/salida/` con `corrida-r2/salida/`, decisión por decisión y artefacto por artefacto. No se
listan las filas que coinciden en valor: D-02, D-03, D-04, D-08 a D-10 y D-13 a D-17, salvo los detalles anotados.
Cada diferencia es un defecto del conocimiento (§11).

| # | Lugar | C1-r1 | C1-r2 | Defecto |
| --- | --- | --- | --- | --- |
| 1 | Demandas | 8: compuerta, lista privada, visibilidad, remoto, check obligatorio, SHA, texto de DK-14, texto de I-20 | 5: compuerta, lista privada, salidas de `git`, visibilidad y check obligatorio, organización y plataforma | DC1R2-01, DC1R2-02, DC1R2-03 |
| 2 | §1, patrón 1 sin compuerta | Encabezados H1: 176 IDs repetidos con `_legacy/`, 1 sin `_legacy/` (`EXP-0001`) | `doc_id`: 2 pares vigente/`_legacy/` | DC1R2-01 |
| 3 | §1, espacios de IDs | US, CU, ADR, BT, RN, NB, RC, EXP, E, M declarados; QG, PT, AG… mencionados | Cuentas por prefijo, con TC, DXC y DIV, y `DOC-` de `doc_id` | DC1R2-01 |
| 4 | §1, patrón 3 | `{carpeta-tecnica}` = `SDD/Docs`, más una acotación | Default `docs/tecnica` (0) y `SDD/Docs` como suposición | DC1R2-04 |
| 5 | §1, patrón 6 | 74 advertencias, todas a reserva | 69, con una selección de las que tocan la adopción | DC1R2-15 |
| 6 | D-01, subfila «sitio» | Clase P | Clase H (D-03) | DC1R2-16 |
| 7 | D-06 y A-09 | A-09 no producido: SHA abreviado y formato de `source.lock` no fijado | A-09 producido, con `base_commit: 4b114d7` abreviado | DC1R2-09 |
| 8 | D-07 | Valor: A-02 con `RD`, `PRC` y `FDD`, más los prefijos del SDD como internos | «Pendiente» entera | DC1R2-10 |
| 9 | A-02 | Producido: `prefijos.txt` en la ruta de la copia | No producido | DC1R2-01, DC1R2-10 |
| 10 | A-04, identificador | `doc_id: RD-00` y encabezado `# RD-00 —` (rojo `id-duplicado`) | `doc_id: RD-REGISTRO`; H1 sin ID | DC1R2-06 |
| 11 | A-04, filas | RD-01…RD-07: tres guías técnicas «no emitidas», dos ayudas por rol, contrato y `AGENTS.md` | RD-01…RD-06: dos ayudas por rol, contrato, `AGENTS.md`, «Cómo intervenir» e índice | DC1R2-19 |
| 12 | A-06, `doc_id` y trazas | `PRC-01`, prefijo inventado; traza a `FDD-01`, que no existe | `{PREFIJO-PROCESO}-…`, marcador (rojo en `esquema`) | DC1R2-07 |
| 13 | A-06, ruta de `{copia-proyecto}` | `docs/_gobierno/compuerta/`, dentro de la carpeta verificada | «Pendiente de D-09» | DC1R2-08 |
| 14 | A-05 y D-12 | Sólo `LGD/AGENTS.md`; el de LG no se toca | `LGD/AGENTS.md`, más una inserción en la fuente del `AGENTS.md` derivado de LG | DC1R2-11 |
| 15 | A-05, forma | Punteros en texto, sin enlaces | Punteros con enlaces, uno a A-09 (rojo sin A-09) | DC1R2-20 |
| 16 | D-11, default en §4 | «El mapa medido» | El PR de adopción lleva reserva: lo fusiona una persona | DC1R2-18 |
| 17 | D-14, alias | `{etiqueta-runner}`, `{dir-de-trabajo}`, `{usuario}` | `{etiqueta-runner}`, `{repo-codigo}` (no canónico), `{organizacion}` | DC1R2-17 |
| 18 | A-11, forma | Un archivo con tres entradas | Tres archivos `.insercion.md` | DC1R2-20 |
| 19 | §6 y M5 | Las lagunas de los patrones 3 y 5, como «lectura»: 0 suposiciones | Las mismas, más la raíz del chequeo de citas: 3 suposiciones | DC1R2-04, DC1R2-05 |
| 20 | Trampas | Nombra T7 y no da el par de T1 dentro de la ficha | Da el par de T1 y no nombra T7 | DC1R2-01, DC1R2-09 |

Iguales en las dos corridas, y por eso defectos estables y no de M7: D-01 sin la organización (DC1R2-14), T2
(DC1R2-12), T5 (DC1R2-13), las fronteras de DK-14 (DC1R2-02) y la compuerta ausente (DC1R2-01).

**Frente a la ronda 1** (14 diferencias): ya no difieren CL-04 (DK-13), D-08, D-09 (las dos eligen la copia con
huella), D-10 ni la forma de la tabla. Aparecen diferencias nuevas en los artefactos que la 1.1 manda producir con el
default (#7, #9, #10, #12 a #15). Siguen las del inventario (#2 a #5), porque la compuerta de la que dependen no
llegó.

## 10. Demandas «sí» del coordinador (diagnóstico)

Las cifras son las del registro de cada corrida. Un «sí» quiere decir que el conocimiento debió cubrir esa demanda.

| Corrida | Demandas | Con material | «Sí» | «Dudoso» | «No» |
| --- | --- | --- | --- | --- | --- |
| C1-r1 | 8, en 1 ronda de 3 | 0 | **2**: Q-7 (texto de DK-14) y Q-8 (ubicación según I-20) | 2: Q-1 (compuerta de origen) y Q-6 (SHA y atraso sin `.git`) | 4 |
| C1-r2 | 5, en 1 ronda de 3 | 1 parcial (Q-5, ubicación de la etiqueta) | **1**: Q-3 (SHA, remoto y etiquetas sin `.git`) | 1: Q-5 (organización y plataforma del runner) | 3 |
| **Total** | 13 | 1 | **3** | 3 | 7 |

Los tres «sí» y los tres «dudoso» están entre los defectos de §11: DC1R2-02, DC1R2-03, DC1R2-09, DC1R2-01 y
DC1R2-14. La compuerta de origen, Q-1, se pidió en las dos corridas, y en las dos volvió «no disponible». Es el insumo
del que más depende el resto: el patrón 1, D-07, A-02, A-03, A-07, A-08 y toda la §7 de la ficha.

## 11. Defectos del conocimiento y filas discutibles del oráculo

### 11.1 Defectos del conocimiento

Las secciones se citan como `conocimiento.md:línea`, sobre la 1.1 sellada (`afd741b8…7165483e8`).

| Id | Sección | Problema | Arreglo propuesto | Evidencia |
| --- | --- | --- | --- | --- |
| DC1R2-01 | §8 (`:563-566`); §3.1 patrón 1 (`:214`, `:222`); §5.7; DE-14 | El conocimiento depende de la compuerta de origen, que no vive en él ni vino en el montaje. Sin ella, las dos corridas dejan «pendiente» el patrón 1, D-07, A-03, A-07, A-08 y toda §7, y cada una improvisa un inventario de IDs distinto | En el montaje: la compuerta de origen en SHA fijo, como insumo con huella (`F099` §5.5 no la lista). En el conocimiento: un camino sin ella, con comandos sin red para el patrón 1 y los espacios de IDs (`doc_id:` y `^# [A-Z]+-[0-9]+`, con y sin `_legacy/`), y A-02 y A-03 producidos igual, como propuesta, en el formato de §5.6 y §5.7 | Q-1 en las dos; M7 #1–#3, #9; M6 |
| DC1R2-02 | §2.1 (`:122`) | «Fronteras de CL-01, CL-07, CL-09, CL-10: DK-14» nombra la regla sin transcribirla, y el registro DK no es parte del conocimiento | Transcribir la regla de fronteras en §2.1: qué carpetas de especificación, técnica, análisis y guía van a cada clase | Q-7 («sí»); §6 de las dos fichas |
| DC1R2-03 | §3.2 D-05 (`:246`); I-20 (`:147`) | Da las tres preguntas de I-20 y «la primera que da sí ubica la pieza», pero no qué ubicación corresponde a cada respuesta, que queda en `TEM-03`, externo | Una tabla pregunta → ubicación (build, mismo repo, hermano) | Q-8 («sí»); `corrida-r1/salida/A-01.md:44` |
| DC1R2-04 | §3.1 patrones 3 y 5 (`:224`, `:226`) | `{carpeta-tecnica}` no se define cuando `docs/tecnica/` no existe. El patrón 5 fija `CHANGELOG.md` en mayúsculas. Ante el mismo hueco, una corrida informa una «lectura» y la otra declara una «suposición» | Definir `{carpeta-tecnica}` = las ubicaciones de CL-07 en A-01 §3; buscar el CHANGELOG sin distinguir mayúsculas; decir que un comando adaptado, informado junto al literal, no es una suposición | M5; M7 #4, #19 |
| DC1R2-05 | §3.5, chequeo de citas (`:308-313`) | «Corrido desde la raíz del repo leído» no dice qué raíz usar cuando hay dos repos. El chequeo no detecta una cita corrida de línea | Con varios repos, citar con prefijo de repo y correr desde el directorio que los contiene. Agregar una comprobación por muestra de que la línea sostiene lo afirmado | M5 de C1-r2; M4 de C1-r2 |
| DC1R2-06 | §5.2 y §5.3; D-04 (`:245`) | No dice que un `doc_id` en el frontmatter y un encabezado `# ID —` del mismo ID son dos declaraciones. La compuerta da `id-duplicado` | Una pieza nueva declara su ID una sola vez: `doc_id` en el frontmatter y H1 sin el ID. Si el proyecto usa encabezados con ID, va sin `doc_id` | M6 de C1-r1 (4 `id-duplicado`); M7 #10 |
| DC1R2-07 | §5.6 (`:443-445`) | «A-06 el de procesos; A-01, la nota de A-03 y A-08 el de anexos o fichas» no da un nombre de prefijo por defecto, salvo `RD` | Dar prefijos por defecto para procesos y para anexos o fichas, libres en el repo y fuera del registro de origen, y la regla de que una traza no apunta a una pieza que todavía no tiene `doc_id` | M6 de C1-r2 (`esquema`) y de C1-r1 (`FDD-01`); M7 #12 |
| DC1R2-08 | §5.7 (`:455-456`); A-06 (`:503`) | No da una ruta por defecto para `{copia-proyecto}`, ni dice que tiene que quedar fuera de la carpeta que verifica la compuerta. Dentro de `docs/`, la compuerta se verifica a sí misma | Ruta por defecto fuera de las carpetas verificadas (por ejemplo, junto a `scripts/` del proyecto), declarada en A-06 | `M6/r1-LG-ruta-declarada.txt` (116 errores); M7 #13 |
| DC1R2-09 | D-06 (`:247`); A-09 (`:506`); §6 | No da el formato de `source.lock` ni dice si alcanza el SHA abreviado del índice. Tampoco pide decir cómo se ancla hoy la pieza antes de proponer A-09 | Plantilla de `source.lock`, con SHA abreviado más «completo: pendiente» si falta `.git`. En D-06, anotar el mecanismo actual (prosa, `base_commit`, `source.lock`) con su `ruta:línea` | M7 #7, #20; T7 en C1-r2; Q-6 y Q-3 |
| DC1R2-10 | D-07 (`:248`); §5.6 (`:432-441`) | No dice qué ámbito llevan los prefijos de un marco de especificación declarado en el repo cuando la compuerta corre sólo sobre las carpetas nuevas: «interno» no resuelve desde `docs/`; «externo» sin `source.lock` avisa. Tampoco dice qué valor dar a D-07 si el control de trazas no está | Fijar «externo» para los IDs del marco cuando la compuerta no los recorre, con su razón. Sin el control, D-07 se contesta con la opción, el registro propuesto y la unicidad «pendiente» | M7 #8, #9; §11.2 |
| DC1R2-11 | D-12; DK-09 (`:494`); CL-03 | «Una instancia que ya existe se actualiza en su ruta» choca con un `AGENTS.md` derivado («no editar acá»). No dice si se actualiza su fuente o se deja | Regla para una instancia derivada: se propone el cambio en su fuente, rotulado «propuesta sujeta a D-12», o no se toca | M7 #14 |
| DC1R2-12 | §3.1 patrón 4 (`:217`, `:225`); D-13; D-07 | La traza de la interfaz a su unidad sólo se mira en `{carpeta-ayuda}`. Si la ayuda no existe, nada pide fijar a qué unidad trazará la ayuda nueva | En D-13 o D-07: «las pantallas trazan a los casos de uso de la unidad de la interfaz», con el prefijo medido en la especificación del proyecto | T2 falla en las dos (ronda 1 y ronda 2) |
| DC1R2-13 | §3.1 patrón 3 (`:216`, `:224`) | Pide la cuenta, pero no la conclusión. Con 4574 líneas, ninguna corrida dice que la documentación técnica de entrega está planificada | Pedir el estado por documento de la carpeta técnica (vigente o planificado) y una línea en A-01 con la proporción y su `ruta:línea` | T5 falla en las dos (ronda 1 y ronda 2) |
| DC1R2-14 | D-01, contexto organización (`:242`); D-09 (`:250`) | La organización sólo se mide por el remoto `origin` y por `uses:`. Sin `.git` queda «pendiente» en las dos corridas, aunque el repo la nombra en su texto. El arreglo DK-11 de la ronda 1 no alcanzó | Admitir como evidencia secundaria declarada, igual que DK-15, la organización que el propio repo nombra en su texto, y decir dónde se lee la organización de la compuerta de origen | D-01 discrepa en las dos (ronda 1 y ronda 2); Q-4 y Q-5 |
| DC1R2-15 | §3.1 patrón 6 (`:219`) | «Lectura del índice» no es un comando: 74 advertencias frente a 69 | Dar el comando que cuenta las advertencias y su estado | M7 #5 |
| DC1R2-16 | D-01, subfila «sitio» (`:242`); D-03 (`:244`) | El contexto «sitio» repite la pregunta de D-03, que es H, sin decir qué clase lleva la subfila | La subfila remite a D-03 y hereda su clase | M7 #6 |
| DC1R2-17 | §3.6 (`:320-321`) | La lista de alias canónicos no trae uno para el repositorio remoto ni para una persona nombrada | Sumar `{repo-codigo}` (o `{repositorio}`) y `{persona}` a los canónicos | M7 #17 |
| DC1R2-18 | D-11 (`:252`); §5.1, sección 4 | No dice si el PR de adopción, con decisiones H abiertas, cuenta como «con reserva» para la delegación medida | Fijarlo: un PR con decisiones H abiertas lleva reserva y lo fusiona una persona | M7 #16 |
| DC1R2-19 | §5.3 (`:410-414`); A-04 | No dice qué filas mínimas lleva el RRD inicial | Una fila por clase activa sin pieza (brecha) y por cada pieza nueva de la adopción | M7 #11 |
| DC1R2-20 | §5.5 (`:425-427`); A-11 (`:508`) | No fija si los punteros de A-05 son enlaces ni la forma de «la entrada y su punto de inserción» de A-11. Un puntero que enlaza a un artefacto todavía no producido da rojo | Punteros como enlaces a piezas que existen o que entran en el mismo PR. A-11, un archivo por destino con la ruta y la línea de inserción | M7 #15, #18; M6 de C1-r2 en LGD |

**Montaje (no es defecto del conocimiento).** `coordinacion/` quedó legible para el aplicador en las dos corridas, y
de ahí salió la clasificación DUDOSA (§2). Hay que dejarlo fuera de su directorio o sin permiso de lectura, como
recomiendan las dos auditorías.

### 11.2 Filas discutibles del oráculo (para O-4)

No encontré un error probado del oráculo: ningún valor es falso en `4b114d7`/`b47d22b`. Estas cuatro filas admiten
dos lecturas y deciden si C1-r1 pasa M2 (§4). No muevo el umbral ni el conteo. Las elevo a la presidencia.

1. **D-06, «sin `base_commit`».** Si describe el estado actual (T7), una ficha que propone A-09 con `base_commit`
   coincide. Si es parte del diseño, choca con DE-7 del conocimiento, que exige A-09 para toda pieza fuera del repo
   del código. Juzgué la primera lectura (C1-r2 coincide).
2. **D-07, «prefijos externos del SDD».** El oráculo los llama externos. El conocimiento llama «interno» a lo que se
   declara en el repo (`conocimiento.md:440`), y los IDs del SDD se declaran en LG. Juzgué por la opción y el
   fondo (C1-r1 coincide). Con la lectura literal, C1-r1 discrepa.
3. **T1, «la nombra con `ruta:línea`».** C1-r1 da la cuenta en la ficha, y el par exacto del oráculo está en su
   inventario. Juzgué que coincide.
4. **D-05, fila o §3.** El oráculo no dice si se lee el resumen de la fila o la tabla de §3, que el conocimiento
   declara como el lugar de «todas las ubicaciones». Juzgué por §3, en las dos corridas.

## 12. Publicación, saneo y barrido

Se copiaron a esta carpeta:

- `sellado/oraculo-O3.md`, con `sha256sum` `0fd3d463…5ba461eac`, idéntico al sellado.
- `corrida-r1/salida/`, `corrida-r1/coordinacion/`, `corrida-r2/salida/` y `corrida-r2/coordinacion/`, de cada
  corrida.
- `M6/`: salidas de la compuerta y `correr.sh`.

El saneo de lo privado conserva el número de líneas, así que las citas de M4 y de este informe siguen valiendo. Los
reemplazos usan alias: `{etiqueta-runner}`, `{host-de-pruebas}`, `{dir-de-trabajo}`, `{dir-de-sesion}`,
`{indice-de-memoria}`, `{ruta-de-usuario}`, `{ruta-absoluta}`, `{dir-de-despliegue}`, `{ipv4}` y
`<patrón de rutas absolutas>`. Todos los demás archivos son copia byte a byte.

| Archivo | Líneas cambiadas | Qué se cambió | Huella del original |
| --- | --- | --- | --- |
| `corrida-r1/coordinacion/auditoria.md` | 8, 36, 37, 38, 51, 54 | Ruta de la sesión del arnés, nombre del índice de memoria, nombre de máquina y rutas absolutas de ejemplo | `dde8ee91573527cb711a000e9374cda3941eb080a13fb4b07da99a1758a24e11` |
| `corrida-r1/salida/A-01.md` | 53 | Patrón literal de rutas absolutas del comando de D-14 | `ded0994609190f90063fc90b86bdb367b987c987df090948ce55041f2ef00d55` |
| `corrida-r1/salida/inventario/p3-LG-SDD-Docs.txt` | 1810, 2429, 2449, 3974 | Texto de `repo/` que trae una ruta de despliegue en el directorio personal, tres IPv4 y una ruta absoluta de usuario | `837834950774b4059968f85be3da0b561e74dc79685e20584bb2c8be63f6e556` |
| `corrida-r2/coordinacion/auditoria.md` | 7, 31, 32 | Directorio de trabajo, ruta de la sesión del arnés y nombre del índice de memoria | `ddf3a599ab15ccfd931bbe99e4b5762cfc46a82de720c8be34ecd59ff4d1cad0` |
| `corrida-r2/coordinacion/registro.md` | 12 | Etiqueta literal del runner propio, en la respuesta a Q-5 | `552023a1acb856d1fd96300219053a1359800838d3f43001cb32ce7620d99aae` |
| `corrida-r2/salida/respuestas.md` | 9 | Igual | `f7c965dd30dfd57fd9797450999b721e32dbf0f18a8aa3a501b45f04cd073137` |

`p3-LG-SDD-Docs.txt` es una salida cruda de `grep` sobre `repo/`. El refutador comprobó su procedencia antes del
saneo (`M4/M4-refutador.md`, «Salidas crudas»). Contra la copia saneada, esas cuatro líneas ya no coinciden byte a
byte con `repo/`.

**Barrido.** `grep -rnIiE` sobre toda `evidencia/ronda-2/C1/`, con esta lista privada: rutas absolutas del equipo y
de usuario, el prefijo del directorio personal, los nombres de máquina del laboratorio, el nombre y el correo del
usuario, la ruta de la sesión del arnés, el área temporal del perito, el índice de memoria y el patrón de IPv4.
Resultado: **0 coincidencias**. El nombre público de la organización de GitHub que cita el oráculo no es privado, y
el folio `F203` ya lo publicó.

## 13. Lo no verificado

- M2 y M3 los corrió el perito de métrica y no el autor del oráculo, como prevé `F200` §7 **[criterio propio]**. La
  revisión del autor queda abierta, y con ella las cuatro filas de §11.2.
- No volví a correr `citas.py`: M4 es el resultado del refutador.
- M6 corrió en el área temporal del perito, con la caché de herramientas y sin red. No corrió en `{host-de-pruebas}`
  con la guarda de turnos (`F099:432`) ni en un worktree de LGD: usé una copia de `repo/LGD`. El instrumento es el de
  `00171bd`.
- Comprobé en `repo/` la versión doble que cita C1-r2 (T3) y el par `CU-08002` del inventario de C1-r1 (T1). No
  comprobé que `repo/` sea idéntico a LG en `4b114d7` y LGD en `b47d22b`, porque no trae `.git`. Las dos auditorías
  informan las mismas huellas de árbol que las fichas.
- La clasificación final de las dos corridas es de la presidencia (§2). Si alguna se anula, sus cifras de §1 no
  cuentan.
- No se hizo commit. Mensajes de otras sesiones a mitad de turno: ninguno.
