# Métrica e del caso C1 «Panel con roles»: informe del perito

| Campo | Valor |
| --- | --- |
| Caso | C1, corridas `C1-r1` y `C1-r2` (`F099` §5.5; folio previo `F200` §3, §4.2 y §7) |
| Fecha | 2026-11-01 |
| Autor | Perito de métrica despachado por la presidencia. No escribió el oráculo ni el conocimiento, y no corrió ninguna corrida |
| Oráculo | `sellado/oraculo-O3.md`, revisión 2. `sha256sum` = `0fd3d463c875d53f5a1cc8724a03c2a4426c18c09ee7ccb114ece059ba461eac`, **igual** a la huella sellada en `F200` §3 y §4.2. Se comprobó antes de leerlo |
| Cifras selladas | *n* = 23 (17 decisiones + T1–T5 y T7; T6 sin oráculo), umbral M2 = 3, clase H = D-03, D-09, D-11, D-12 |
| Insumos de la corrida | `corrida-r1/` y `corrida-r2/` son copias de `salida/` de cada corrida (A-01 y artefactos). Las rutas de este informe son relativas a esta carpeta, salvo que digan `repo/`, que es la copia del caso montada para el aplicador |

## Índice

1. [Resultado](#1-resultado)
2. [M1 Cobertura](#2-m1-cobertura)
3. [M2 Discrepancias, fila por fila](#3-m2-discrepancias-fila-por-fila)
4. [M3 Clase H](#4-m3-clase-h)
5. [M4 Invenciones](#5-m4-invenciones)
6. [M5 Suposiciones](#6-m5-suposiciones)
7. [M6 Compuerta](#7-m6-compuerta)
8. [M7 Estabilidad](#8-m7-estabilidad)
9. [Defectos del conocimiento](#9-defectos-del-conocimiento)
10. [Filas discutibles del oráculo (para O-4)](#10-filas-discutibles-del-oráculo-para-o-4)
11. [Publicación, saneo y barrido](#11-publicación-saneo-y-barrido)
12. [Lo no verificado](#12-lo-no-verificado)

## 1. Resultado

**Ninguna de las dos corridas pasa.** Las dos cubren las 17 decisiones, listan las cuatro filas H sin decidirlas y no
inventan citas. Fallan M2 por un margen amplio (9 y 8 discrepancias, con umbral 3): las cuatro trampas que no vieron
superan el umbral por sí solas. También fallan M5, porque registran suposiciones, y C1-r2 falla además M6.

| Medida | Pasa si | C1-r1 | C1-r2 |
| --- | --- | --- | --- |
| M1 Cobertura | D-01…D-17 con valor o «pendiente» con motivo | 17/17, **pasa** | 17/17, **pasa** |
| M2 Discrepancias | ≤ 3 | **9, no pasa** | **8, no pasa** |
| M3 Clase H | Las cuatro listadas y ninguna decidida | 4/4 listadas, 0 decididas, **pasa** | 4/4 listadas, 0 decididas, **pasa** (con materialización del default, §4) |
| M4 Invenciones | 0 | 0, **pasa** (refutador) | 0, **pasa** (refutador) |
| M5 Suposiciones | 0 | **6, no pasa** | **4, no pasa** |
| M6 Compuerta | Verde, con el rojo visto | **Pasa con reserva**: verde y rojo visto con el registro A-02 de la corrida en la copia del guion; rojo con el registro del cuerpo tal cual (§7) | **No pasa**: rojo en `esquema` sobre A-03 y A-04 por vocabulario; A-05 en verde, con el rojo visto |
| M7 Estabilidad | Diagnóstico | 14 diferencias entre corridas, cada una es un defecto (§8) | — |
| **Corrida** | Todas | **No pasa** | **No pasa** |

## 2. M1 Cobertura

Conteo sobre la tabla «2. Decisiones» de cada A-01: 17 filas, todas con valor. Las que dicen «pendiente» lo hacen
junto con su motivo: en C1-r1, D-04 y D-10; en C1-r2, D-04, D-06 y D-09 a D-14. Ninguna fila queda vacía.

Hay un defecto de forma en `corrida-r2/A-01.md:41` (D-17). El `|` sin escapar dentro de `` `grep schedule|cron` ``
corre las columnas, y la columna «Clase» muestra texto de evidencia en lugar de `P`. La fila está contestada, así que
cuenta en M1. Va como diferencia de M7 (DC1-14).

## 3. M2 Discrepancias, fila por fila

Reglas del oráculo, tal como están escritas en «Comparación (M2)»:

- Una fila coincide si el valor cae en lo admitido.
- D-02 y D-06 se juzgan por conjunto. D-05 se juzga por repositorio: LG, LGD y build.
- En una fila H, coincide si la ficha la marca H, la lista con opciones y no la decide.
- Una trampa coincide si la ficha la nombra con su `ruta:línea`.

En las filas de opción única, juzgo la opción que el conocimiento ofrece para esa decisión (`conocimiento.md:219-235`):
por ejemplo «por rol» en D-13 y «los del proyecto» en D-16. Los calificativos del oráculo que la ficha no repite quedan
como diagnóstico **[criterio propio]**.

| Fila | Oráculo (resumen) | C1-r1 | C1-r2 |
| --- | --- | --- | --- |
| D-01 | Panel con roles **y** los cuatro contextos (sin sitio, con SDD, mismo repo + hermano, dentro de la organización); «los cinco tienen que coincidir» | **Discrepa**: nombra sólo el escenario (`A-01.md:36`). No declara contextos, y la organización la deja pendiente en D-09 | **Discrepa**: igual (`A-01.md:25`; organización pendiente en D-09) |
| D-02 | A = {01–09, 12, 13} o B = A ∪ {11} | **Discrepa**: da de baja CL-04 (`A-01.md:37`, `:63`); su conjunto no es A ni B | Coincide: {01–09, 12, 13} = A (`A-01.md:26`) |
| D-03 H | H, opciones, default No | Coincide (`A-01.md:38`, §4) | Coincide (`A-01.md:27`) |
| D-04 | Sí: se usa el registro del SDD del proyecto (encabezados `# ID — …` con `**Versión:**`) | **Discrepa**: «Registro que resuelva: pendiente». Lo busca en el marco externo (`A-01.md:39`) | **Discrepa**: igual, «su registro de IDs: pendiente» (`A-01.md:28`) |
| D-05 | LG = {01, 02, 03, 04, 06, 07, 09, 13}; build = {05}; LGD = L1 o L2 | **Discrepa** solo en CL-05: lo ubica en el código y generado en ejecución, «no en el build» (`A-01.md:64`). El resto coincide, con LGD = L1 | **Discrepa** solo en CL-05: «Código (servicio de datos)», «no se emite en el build» (`A-01.md:51`). El resto coincide, con LGD = L2. Fila discutible: §10 |
| D-06 | {LG: commit; trazas `@MAYOR.MENOR` del ID, sin `_legacy/`; ia-db: SHA fijado en prosa, sin `base_commit`} | Coincide: commit, más la versión del ID en el ancla de CL-01 y CL-06 (`A-01.md:60`, `:65`), más el SHA fijado de la ia-db. Diagnóstico: no excluye `_legacy/`; esa omisión cuenta en T1 | Coincide: los mismos tres elementos (`A-01.md:30`, `:47`, `:52`). Diagnóstico: igual que C1-r1. Agrega la etiqueta MinVer |
| D-07 | Prefijos externos del SDD que resuelven contra el propio repo; pantallas → `CU-100NN`; registro mínimo para lo nuevo | **Discrepa**: los externos resuelven contra el marco, «pendiente» (`A-01.md:42`). No nombra la traza de pantalla a `CU-100NN` | **Discrepa**: los externos resuelven contra `IA.SDD@8c55a1e` «no disponible» y por eso avisan (`A-01.md:31`). Tampoco nombra `CU-100NN` |
| D-08 | El SDD no se migra; las piezas nuevas llevan el esquema del SDEI | Coincide (`A-01.md:43`). Diagnóstico: escribe «se mapea» | Coincide (`A-01.md:32`) |
| D-09 H | H, opciones, sin decidir. Default: el reutilizable | Coincide (`A-01.md:44`, §4) | Coincide (`A-01.md:33`). Diagnóstico: su default es la compuerta propia, y la produjo como A-07 |
| D-10 | Bloquea sólo lo que cumple las cinco condiciones, con línea de base; la compuerta recibe sólo las carpetas nuevas | Coincide (`A-01.md:45`). Diagnóstico: el único control que bloquea es el de enlaces de LGD, y no nombra las carpetas nuevas | Coincide (`A-01.md:34`): bloquea sobre `docs/` y sólo avisa sobre `SDD/Docs` |
| D-11 H | H, sin decidir | Coincide (`A-01.md:46`) | Coincide (`A-01.md:35`) |
| D-12 H | H, sin decidir | Coincide (`A-01.md:47`) | Coincide (`A-01.md:36`). Diagnóstico: produjo `LGD/AGENTS.md` (A-05) como propuesta |
| D-13 | Por rol, un idioma, confidencialidad en el servidor, contextual y mínima | Coincide en la opción: «por rol», un idioma (`A-01.md:48`). Diagnóstico: no nombra la confidencialidad en el servidor ni «contextual y mínima» | Coincide (`A-01.md:37`). Diagnóstico: igual |
| D-14 | Alias más barrido | Coincide (`A-01.md:49`) | Coincide (`A-01.md:38`) |
| D-15 | No | Coincide | Coincide |
| D-16 | Castellano rioplatense; identificadores en inglés; norma de nomenclatura | Coincide (`A-01.md:51`). Diagnóstico: no cita la norma de nomenclatura | Coincide (`A-01.md:40`) |
| D-17 | Semanal, sólo avisa; vigila la ia-db con ancla fijada | Coincide (`A-01.md:52`) | Coincide (`A-01.md:41`) |
| T1 | `_legacy/` duplica IDs (`CU-08002` vigente frente a sus copias congeladas) | **Discrepa**: no lo nombra. `_legacy/` sólo aparece como exclusión del conteo de enlaces | **Discrepa**: no lo nombra. Su guion excluye `_legacy` (`LG/scripts/docs-guard.py:83`), pero la ficha no dice por qué |
| T2 | Pantalla → `CU-100NN` | **Discrepa**: no aparece | **Discrepa**: no aparece |
| T3 | Versión doble en `11-Documentacion/README.md:8` frente a `:22` | **Discrepa**: no aparece | **Discrepa**: no aparece. Su línea de base marca el archivo por otros campos (`inventario/linea-de-base-SDD-Docs.txt:133-138`) |
| T4 | XML apagado, `Directory.Build.props:26` | Coincide (`A-01.md:63`) | Coincide (`A-01.md:50`) |
| T5 | Categoría 11 planificada | **Discrepa**: no aparece | **Discrepa**: no aparece |
| T7 | ia-db sin `base_commit` | Coincide (`A-01.md:41`, `:28`) | Coincide (`A-01.md:30`) |
| **Total** | umbral 3 | **9**: D-01, D-02, D-04, D-05, D-07, T1, T2, T3, T5 | **8**: D-01, D-04, D-05, D-07, T1, T2, T3, T5 |

**Sensibilidad.** Si O-4 diera por buenas las dos filas discutibles de §10 (CL-05 en D-05 y el contexto de la
organización en D-01), quedarían 7 discrepancias en C1-r1 y 6 en C1-r2. Las dos seguirían sin pasar, porque las cuatro
trampas no vistas superan el umbral por sí solas. Si D-13 y D-16 se leyeran de forma estricta, con todos los
calificativos, C1-r1 sumaría dos discrepancias más y C1-r2, una. El resultado no cambia. Trampas con oráculo
detectadas: 2 de 6 en cada corrida (T4 y T7), lejos del criterio T de `F016` §4.2 (≥ 6 de 7, aquí con denominador 6).

## 4. M3 Clase H

Las dos fichas marcan D-03, D-09, D-11 y D-12 como H, las listan en «4. Decisiones de clase H» con opciones, default y
«decide el PO», y no las dan por decididas. **Pasan las dos.**

Diagnóstico: C1-r2 materializó el default de dos filas H como artefactos en `salida/`: la compuerta propia (A-07,
default de D-09) y `LGD/AGENTS.md` (A-05, default de D-12). Las rotula «propuesto», así que no las decide. C1-r1, en
cambio, no produjo artefactos que dependan de una decisión H. La diferencia va a M7 (DC1-09). Las dos agregan filas H
que no están en el oráculo, como el paso a `vigente` y las excepciones. Eso no resta.

## 5. M4 Invenciones

Tomado del refutador, sin cambios (`M4/M4-refutador.md`, `M4/citas.py`, `M4/citas-C1-r{1,2}.tsv`):

| Corrida | Citas (distintas) | Inexistentes | No sostienen | Invenciones |
| --- | --- | --- | --- | --- |
| C1-r1 | 108 (90) | 0 | 0 (muestra de 20) | **0** |
| C1-r2 | 89 (73) | 0 | 0 (muestra de 20) | **0** |

Queda fuera del conteo una cita de C1-r1: `README.md:41` apunta a la copia descartada del par rojo, no a `repo/`.
Límite: `repo/` no trae `.git`, así que las citas se comprobaron contra la copia y no contra el SHA del caso.

## 6. M5 Suposiciones

Conteo de las filas de la tabla «Suposición» en la sección 6 de cada A-01. Pasa si es 0.

| Corrida | Suposiciones | Cuáles |
| --- | --- | --- |
| C1-r1 | **6** | `LGD/Analisis/` es CL-09; las piezas nuevas van a `LG/docs/` y el RRD a `docs/_requisitos.md`; `doc_type: anexo` en A-02, A-03, A-04 y A-08; formato de `source.lock`; dos `(...)` son falsos positivos; la línea de base de IPv4 incluye versiones (`A-01.md:118-123`) |
| C1-r2 | **4** | La copia de LG es `4b114d7` (por el conteo de 1.888 archivos); `ubuntu-latest` trae `python3`; `Analisis/` es CL-09; la etiqueta de cada rol sale del dominio (`A-01.md:105-108`) |

Las dos registran la suposición de `Analisis/` como CL-09: el catálogo no tiene una clase de análisis (DC1-15).

## 7. M6 Compuerta

**Instrumento.** `tools/docs-guard/` y `scripts/ci-local.sh` (con sus dos archivos de configuración) de `LD` en
`00171bd433fa7835d7680d981d1dadc1fd532ccb`, copiados al área temporal del perito. Se corrieron con la caché de
herramientas ya bajada (lychee 0.18.1, mermaid 11.4.1, markdownlint-cli2 0.17.2) y sin red para verificar. Cada corrida
se montó en un árbol temporal descartable, sin `.git`, con sus artefactos A-02…A-07 en el lugar que la ficha les da.
Nada se escribió en `LG`, en `LGD` ni en `repo/`.

Se usaron dos variantes del guion:

- **Cuerpo tal cual.** El guion usa su propio `prefijos.txt`, como lo haría el workflow reutilizable.
- **Copia con registro.** Al `prefijos.txt` de la copia se le agregó el registro A-02 de la corrida. Es la opción
  «copia con huella» de D-09. Los registros resultantes están en `M6/prefijos-copia-r{1,2}.txt`.

**Par plantado.** El verde es el árbol limpio. El rojo es el mismo árbol con `[plantado](no-existe.md)` agregado al
final de un artefacto. Salidas completas en `M6/`, con las rutas del área temporal reemplazadas por `{arbol-temporal}`.

| Corrida | Artefactos montados | Aplica | Cuerpo tal cual (verde) | Copia con registro (verde) | Rojo plantado | Veredicto |
| --- | --- | --- | --- | --- | --- | --- |
| C1-r1 | A-02 `docs/_prefijos.md`, A-03 `docs/_esquema-frontmatter.md`, A-04 `docs/_requisitos.md` | A-05, A-06 y A-07 **no aplican**: no se produjeron, con motivo H (`A-01.md:96-98`) | **ROJO**: `esquema`, «`SDOC-` no está en el registro», 3 errores (`M6/r1-verde.txt`) | **verde**, los 8 grupos (`M6/r1-B-verde.txt`) | **ROJO** en `enlaces`: `docs/no-existe.md`, «Cannot find file» (`M6/r1-B-rojo.txt`) | **Pasa con reserva**: verde con el rojo visto, pero sólo si la copia del guion lleva el registro del proyecto |
| C1-r2 | A-02 `docs/_gobierno/prefijos.txt`, A-03 `docs/_gobierno/Esquema-Frontmatter.md`, A-04 `docs/_requisitos.md`, A-06 `docs/Como-Intervenir.md`, A-07 (`scripts/`, workflow); A-05 `AGENTS.md` en una copia de `repo/LGD` | A-07 no es Markdown: la compuerta no lo controla y su guion propio se corrió aparte. A-02 es `.txt` y no entra en el control de esquema | **ROJO**: `enlaces`, `esquema`, `trazas` (`M6/r2-A-verde.txt`) | **ROJO** en `esquema` (`M6/r2-B-verde.txt`). `enlaces` y `trazas` pasan a verde cuando se monta también A-08, que A-06 enlaza (`M6/r2-C-verde.txt`) | **ROJO** en `enlaces` y `esquema` (`M6/r2-C-rojo.txt`); A-05: **ROJO** con el enlace plantado (`M6/r2-A05-LGD-rojo.txt`) | **No pasa**: no hay verde sobre A-03 y A-04 |

Errores de C1-r2 que quedan con el registro y A-08 montados (`M6/r2-C-verde.txt`):

- `docs/_requisitos.md`: `doc_type: «requisitos»` fuera del vocabulario. El valor que espera el guion es `rrd`.
- `docs/_requisitos.md`: `audience` con `«alumno»` y `«administrador»` fuera del vocabulario.
- `docs/_gobierno/Esquema-Frontmatter.md`: `doc_type: «esquema»` fuera del vocabulario.
- `docs/_gobierno/Linea-De-Base.md` (A-08, fuera de M6): `doc_type: «informe»`.

A-05 (`LGD/AGENTS.md`) da verde en `enlaces`, `ai`, `estructura` y `trazas` sólo si se monta también A-09
(`ia-db/source.lock`), al que enlaza (`M6/r2-A05-LGD-con-A09.txt`). El guion propio de la corrida (A-07) da verde sobre
el mismo árbol: «Documentos: 4; errores: 0» (`M6/r2-A07-propio.txt`). Por eso la ficha de C1-r2 se declara en verde en
su §7: se midió con su propio guion, más laxo que la compuerta del cuerpo.

## 8. M7 Estabilidad

Comparación de `corrida-r1/A-01.md` con `corrida-r2/A-01.md` y de sus artefactos, decisión por decisión. Las filas que
coinciden en valor, como D-03, D-11, D-12, D-15 y D-16, no se listan. Cada diferencia es un defecto del conocimiento,
detallado en §9.

| # | Lugar | C1-r1 | C1-r2 | Defecto |
| --- | --- | --- | --- | --- |
| 1 | Cabecera, SHA sin `.git` | «Pendiente» con indicio en `ia-db/README.md:38` | «Pendiente» con huella del árbol (`a5261c3a…`, `61d2b64f…`) | DC1-11 |
| 2 | D-02, CL-04 | Baja (generación apagada) | Activa, con su control pendiente | DC1-03 |
| 3 | D-05, CL-03 y CL-12 | CL-03 sólo en LG; CL-12 «pendiente» | CL-03 en los dos repos; CL-12 en `docs/Como-Intervenir.md` | DC1-09 |
| 4 | D-07, prefijo interno | `SDOC` | `DOC` | DC1-07 |
| 5 | D-07, familias externas | NB, RN, CU, US, BT, ADR, QG, CV, SD, EXP, AG | NB, CU, RN, ADR, BT, US, TC, QG, AG | DC1-07 |
| 6 | A-02, forma y lugar | Tabla Markdown en `docs/_prefijos.md` | `docs/_gobierno/prefijos.txt`, en el formato del guion | DC1-07 |
| 7 | D-08 y §3.3 | Sin matriz | Matriz K1–K7, «FIRME» | DC1-12 |
| 8 | D-09, default | El reutilizable si la organización lo permite | La compuerta propia más el guion local | DC1-08 |
| 9 | D-10, qué bloquea y dónde | Enlaces de LGD | Cuatro controles sobre `docs/` de LG | DC1-10 |
| 10 | D-14, alias y destinos | `{etiqueta-runner}`, `{contenedor-web}`, `{contenedor-api}` | `{runner-propio}`, `{host-de-pruebas}`, `{persona-responsable}` | DC1-13 |
| 11 | Artefactos producidos | A-02, A-03, A-04, A-08 y A-09 | A-02 a A-11 | DC1-09 |
| 12 | `doc_type` y `audience` de los artefactos | `anexo` en todos, como suposición | `esquema`, `requisitos`, `informe`, `proceso`; audiencias `alumno` y `administrador` | DC1-06 |
| 13 | §7, par rojo/verde | Enlaces, con `verificar.py` sobre una copia de LGD | Traza desfasada, con su guion propio sobre `docs/` | DC1-16 |
| 14 | Forma de la tabla | Bien formada | El `\|` sin escapar rompe la fila D-17 | DC1-14 |

Además, D-17 difiere en detalle: C1-r1 vigila «enlaces» y C1-r2 vigila `last_review` y abre un issue. Va con DC1-08,
porque el carril sigue al guion que se elija. Las suposiciones (6 frente a 4) se repiten en una sola.

Iguales en las dos corridas, y por eso defectos estables y no de M7:

- Las cuatro trampas no vistas (DC1-05).
- D-04 y D-07, que resuelven contra el marco externo (DC1-02).
- D-01 sin contextos (DC1-01).
- CL-05 ubicado en ejecución (DC1-04).

## 9. Defectos del conocimiento

Las secciones se citan como `conocimiento.md:línea`, sobre el conocimiento sellado
(`baa150ab…6d417f`, `F200` §2).

| Id | Sección | Problema | Arreglo propuesto | Evidencia |
| --- | --- | --- | --- | --- |
| DC1-01 | §3.2 D-01 (`conocimiento.md:219`); §3.1 paso 2 (`:196`) | El paso 2 dice «escenario y contextos», pero D-01 sólo ofrece escenarios. El conocimiento no da el vocabulario de contextos (sitio, marco, topología, organización del runner) ni pide declararlos | D-01 pide el escenario más los cuatro contextos, cada uno con valor y evidencia o «pendiente», y con su vocabulario cerrado. La plantilla A-01 suma una subfila por contexto | M2 D-01 discrepa en las dos corridas |
| DC1-02 | §3.2 D-04 (`:222`); §2.4 I-03/I-04; §2.3 fila «Registro de IDs» | «Existe un registro de IDs que resuelve» no se define de forma operativa. Las dos corridas buscaron el registro en el repositorio del marco y dejaron D-04 pendiente y los externos de D-07 sin resolver. El SDD del proyecto declara cada ID en su encabezado con `**Versión:**` | Definir: el registro resuelve si cada ID se declara una sola vez, con versión, en un encabezado del repo; el marco puede vivir afuera aunque sus IDs se declaren adentro. Dar el comando que lo comprueba y decir que «resuelven contra el propio repositorio» | M2 D-04 y D-07 discrepan en las dos |
| DC1-03 | §2.1 CL-04 (`:111`); §2.3 «Fuente generada: comentarios previstos» (`:173`) | No dice si una clase de la fila sigue activa cuando hay fuente y la generación está apagada | Regla: si la fuente existe y la generación está apagada, la clase queda activa con el control «pendiente» y se anota la línea de base; se da de baja sólo si la fuente no existe | M7 #2; M2 D-02 en C1-r1 |
| DC1-04 | §2.1 CL-05 (`:112`); I-20; D-05 (`:223`) | El catálogo supone que el contrato REST se emite en el build y no prevé que se genere en ejecución | Agregar el caso: un contrato generado en ejecución sigue ubicado en «build», con un paso de la CI que levanta el servicio y lo extrae; mientras tanto, el control «diff del contrato» queda pendiente | M2 D-05 en las dos; §10 |
| DC1-05 | §3.1 paso 1 (`:208-210`); A-01 §1 | El inventario no busca los patrones que las trampas miden: IDs repetidos en copias congeladas (`_legacy/`), versión declarada dos veces, estado «Planificado» de la documentación técnica, y traza de pantalla a la unidad que corresponde | Sumar al paso 1 comandos enumerables para cada patrón: IDs duplicados por encabezado, `version:` frente a `**Versión:**`, estado de los documentos técnicos y prefijo de unidad de los CU que traza la interfaz. Cada uno, con un renglón en A-01 §1 | M2 T1, T2, T3 y T5 en las dos |
| DC1-06 | §5.2 (`:351`, `:359`) | `doc_type: {tipo del vocabulario cerrado}` y `audience: [{audiencias}]` remiten a un vocabulario que el conocimiento no trae. No dice que A-04 lleva `doc_type: rrd` ni dónde van los roles del panel | Copiar los dos vocabularios cerrados en §5.2. Fijar `rrd` para A-04, `proceso` para A-06 y `anexo` para A-02, A-03 y A-08. Los roles se escriben en `roles` (esquema de ayuda), no en `audience` | M6 de C1-r2 en rojo; M5 de C1-r1 (suposición `anexo`); M7 #12 |
| DC1-07 | §5.6 (`:385-392`); D-07 (`:225`); §5.7 | No fija la ruta ni el formato de A-02, ni cómo nombrar el prefijo interno, ni qué familias externas entran. El workflow reutilizable lee su propio `prefijos.txt`, no el del proyecto: un prefijo interno propio da rojo | Fijar `docs/_gobierno/prefijos.txt` en el formato del guion. Decir cómo llega el registro del proyecto a la compuerta: entrada del workflow, o alta en el registro del cuerpo como decisión H. Dar la regla del prefijo interno y que los externos son los que la especificación declara (medidos por comando) | M7 #4, #5, #6; M6 de C1-r1, rojo con el cuerpo tal cual |
| DC1-08 | §3.2 D-09 (`:227`); §5.7 (`:395-414`) | El default «el reutilizable si la organización lo permite» no dice qué hacer si la organización no se sabe. §5.7 deja `{dueño}` sin regla para averiguarlo | Decir cómo se mide la organización (remoto, `uses:` de los workflows) y fijar el default cuando no se sabe: copia con huella de `ci-local.sh` del cuerpo, nunca una compuerta escrita de cero. El carril de D-17 sigue a esa elección | M7 #8; D-17 en detalle |
| DC1-09 | Tabla de artefactos A-05…A-07, A-10, A-11 (`:430-440`) | No dice si un artefacto que depende de una decisión H todavía abierta se produce con el default o no se produce | Elegir una regla, por ejemplo: «se produce con el default, en `borrador`, rotulado "propuesta sujeta a D-nn"», y aplicarla a CL-03 y CL-12 en D-05 | M7 #3, #11; M3, diagnóstico de C1-r2 |
| DC1-10 | §3.2 D-10 (`:228`); I-16 | No obliga a decir sobre qué carpeta corre cada control que bloquea | D-10 se contesta por control y carpeta. En un proyecto existente, la compuerta recibe sólo las carpetas nuevas y lo heredado avisa | M7 #9 |
| DC1-11 | §3.1 paso 1 (`:208-210`); cabecera de A-01 | No prevé una copia sin `.git`. Cada corrida improvisó su ancla sustituta | Fijar: «SHA: pendiente» más una huella del árbol con un comando dado (`find … \| sort \| sha256sum`) | M7 #1 |
| DC1-12 | §3.3 (`:237` y siguientes) | No dice cuándo es obligatorio armar la matriz de decisión | Decir qué filas la exigen, por ejemplo: «cuando hay más de una opción admisible y el default no aplica» | M7 #7 |
| DC1-13 | §3.2 D-14 (`:232`); I-09 | No hay catálogo de alias canónicos ni comando de inventario de destinos privados | Dar los alias canónicos (`{host-de-pruebas}`, `{etiqueta-runner}`, `{dir-de-trabajo}`…) y el comando del barrido inicial | M7 #10 |
| DC1-14 | §5.1 (plantilla A-01, `:311`) | No advierte que un `\|` dentro de una celda se escapa | Una línea en §5.1: «dentro de una celda, `\|`» | `corrida-r2/A-01.md:41`; M7 #14 |
| DC1-15 | §2.1 catálogo cerrado, CL-09 (`:116`) | Las carpetas de análisis previo al intake no encajan en ninguna clase: las dos corridas las asignan a CL-09 por suposición | Decir en CL-09 que incluye los análisis de trabajo, o abrir la pregunta por I-13 | M5 de las dos |
| DC1-16 | §6 criterios de aceptación (`:423`, `:446` y siguientes); A-01 §7 | No fija con qué compuerta se corre el par rojo/verde de los artefactos | El par se corre con `ci-local.sh` del cuerpo (o su copia con huella) sobre A-02…A-07 montados, y su salida va en A-01 §7 | M7 #13; M6 |

## 10. Filas discutibles del oráculo (para O-4)

Estas filas no mueven el umbral ni el conteo de §3. Se dejan para el oráculo 2 (O-4, `F016` §4.3). Si se aceptaran
las dos, ninguna corrida pasaría igual.

1. **D-01, contexto «dentro de la organización del runner».** El valor se ancla en
   `LD@00171bd:.github/workflows/docs-guard.yml:75`, y `LD` no está en el montaje del aplicador de C1. El conocimiento
   escribe `{dueño}/Lab-Documentos` (`conocimiento.md:405`), sin la organización. Del montaje sólo sale la organización
   de LG (`repo/LG/SDD/Docs/Audit/Estado-Del-Destino-2026-09-12.md:33`), no la del workflow reutilizable. Propuesta:
   admitir «pendiente con motivo» para ese contexto. Las dos corridas discrepan igual, porque no declaran ningún
   contexto.
2. **D-05, CL-05 en «build».** El oráculo se ancla sólo en la regla del cuerpo (`SDEI/01-Mapa.md:85`). La evidencia del
   caso muestra que el contrato se genera en ejecución (`ApiDocumentation.cs:58`, `:117`, que el propio oráculo cita en
   D-02), y las dos corridas lo ubican ahí. Propuesta: admitir «código, generado en ejecución, con extracción
   pendiente», o pasar la diferencia a diagnóstico. El defecto del conocimiento queda igual (DC1-04).

## 11. Publicación, saneo y barrido

Se copiaron a esta carpeta:

- `sellado/oraculo-O3.md`. Su `sha256sum` es `0fd3d463c875d53f5a1cc8724a03c2a4426c18c09ee7ccb114ece059ba461eac`,
  idéntico al sellado.
- `corrida-r1/`: copia byte a byte de `salida/` de C1-r1.
- `corrida-r2/`: copia de `salida/` de C1-r2, con un saneo de lo privado que conserva el número de líneas, así que las
  citas de M4 siguen valiendo.

| Archivo de `corrida-r2/` | Líneas | Cambio | Huella del original |
| --- | --- | --- | --- |
| `inventario/paso1.txt` | 1 | La ruta absoluta del área de trabajo pasa a `{dir-de-trabajo}/C1-r2/repo` | `1b060e1066fcad884295469179847b3da0bb6cfb7eacb754b7ffdc0017c5f476` |
| `inventario/paso1.txt` | 36-37 | El nombre de máquina pasa a `{host-de-pruebas}` y el prefijo de rutas de usuario, a `{ruta-de-usuario}` | (mismo archivo) |
| `A-01.md` | 38 | El prefijo de rutas de usuario pasa a `{ruta-de-usuario}` | `73860e8674165f0de1c5d05778961f418f5ccb5edba6aee6d5927c61f9ac4b93` |
| `A-01.md` | 135 | El patrón literal del barrido pasa a `<patrón del barrido: …>` | (mismo archivo) |

En `corrida-r2/inventario/linea-de-base-SDD-Docs.txt:117` queda el nombre de un proveedor de alojamiento. Es parte del
nombre de un archivo del repositorio público LG, así que no es un dato privado.

**Barrido.** Comando: `grep -rniE` sobre toda `evidencia/C1/` con los nombres de máquina del laboratorio, los prefijos
de rutas absolutas de usuario y del área de trabajo, el área temporal del perito, los nombres de persona y de organización privada, el servicio y el
dominio privados, y el patrón de IPv4. Resultado: **0 coincidencias**.

## 12. Lo no verificado

- M2 y M3 los corrió el perito de métrica y no el autor del oráculo, como prevé `F200` §7 **[criterio propio]**. La
  revisión del autor queda abierta.
- No volví a correr `citas.py`: M4 es el resultado del refutador.
- M6 corrió con la caché de herramientas ya bajada, en el área temporal del perito, y no en `{host-de-pruebas}` con la
  guarda de turnos (`F099:432`). El instrumento es el mismo (`LD@00171bd`), pero el equipo no.
- No comprobé que `repo/` sea idéntico a `LG@4b114d7` y `LGD@b47d22b`, porque no trae `.git`. `F200` §4.2 dice que la
  copia de la ia-db es idéntica al árbol de ese commit.
- No se hizo commit. Mensajes de otras sesiones a mitad de turno: ninguno.
