# Métrica e del caso C0 (corpus de guías): M1 a M7 por corrida

| Campo | Valor |
| --- | --- |
| Caso | C0, corpus de guías (`F099` §5.5; folio previo `F200` §3, §4.1 y §7) |
| Fecha | 2026-11-01 |
| Autor | Perito de métrica despachado por la presidencia. No escribió el conocimiento, el oráculo ni ninguna corrida |
| Oráculo | Oráculo 2, `sha256sum` = `a9362f1f2048ca7f91ecc2574a3957fbeddac9fbdb26ab8c9cfda64cae1fff25`, comprobado antes de leerlo: coincide con `F200` §3. Copia publicada en `sellado/oraculo-O3-2.md`, con la misma huella |
| Cifras selladas | *n* = 24 (D-01…D-17 y T-01…T-07), umbral M2 = 3, clase H = D-03, D-09, D-11, D-12 y renovación de la huella de `AGENTS.md` en `excepciones.txt` |
| Corridas | `C0-r1` y `C0-r2` en `{dir-de-trabajo}/ensayos/corridas/`; conocimiento con la huella de `F200` §2 (`baa150ab…6d417f`) en las dos |
| M4 | Del refutador: `M4/M4-invenciones-C0.md` (no se volvió a correr) |
| Mensajes de otras sesiones a mitad de turno | Ninguno |

## Índice

1. [Resumen](#1-resumen)
2. [M1 Cobertura](#2-m1-cobertura)
3. [M2 Discrepancias, fila por fila](#3-m2-discrepancias-fila-por-fila)
4. [M3 Clase H](#4-m3-clase-h)
5. [M4 Invenciones](#5-m4-invenciones)
6. [M5 Suposiciones](#6-m5-suposiciones)
7. [M6 Compuerta](#7-m6-compuerta)
8. [M7 Estabilidad](#8-m7-estabilidad)
9. [Defectos del conocimiento](#9-defectos-del-conocimiento)
10. [Errores del oráculo](#10-errores-del-oráculo)
11. [Publicación y barrido](#11-publicación-y-barrido)

## 1. Resumen

| Medida | Pasa si | C0-r1 | C0-r2 |
| --- | --- | --- | --- |
| M1 Cobertura | 17 de 17 contestadas o «pendiente» con motivo | 17/17, **pasa** | 17/17, **pasa** |
| M2 Discrepancias | ≤ 3 | **6, no pasa** | **3, pasa** (en el umbral; ver sensibilidad en §3.3) |
| M3 Clase H | 5 de 5 listadas, 0 decididas | 5/5, 0 decididas, **pasa** | 5/5, 0 decididas, **pasa** |
| M4 Invenciones | 0 | 1 con la lectura estricta, 0 fabricadas: **no pasa** (estricta) | 1 con la lectura estricta, 0 fabricadas: **no pasa** (estricta) |
| M5 Suposiciones | 0 | **6, no pasa** | **5, no pasa** |
| M6 Compuerta | Verde, con el rojo visto | **ROJO** (4 `id-duplicado`), rojo plantado visto: **no pasa** | **Verde**, rojo plantado visto: **pasa** |
| Corrida | Todas | **No pasa** (M2, M4, M5, M6) | **No pasa** (M4 estricta, M5) |

M7: 14 diferencias entre las dos corridas (§8). Cada una se cuenta como defecto del conocimiento (§9).

**Hecho que atraviesa todo el caso.** El montaje de C0 no incluye `SDEI/` (`F099:401`; `F200` §2, «la carta»), pero
`LD` la nombra como carpeta por defecto de la compuerta (`.github/workflows/docs-guard.yml:63`,
`scripts/ci-local.sh:35`), como destino de las trazas de los punteros y como lugar de la instancia de «Cómo
intervenir» (`CHANGELOG.md:196`). Las dos corridas vieron una carpeta **ausente**, no una carpeta excluida, y lo
dijeron (r1 S-1; r2 §6, fila «Inventario»). El oráculo está escrito contra `LD` completo. Eso explica varias
diferencias con el oráculo y una de M6; va a errores del oráculo (§10, E-1).

## 2. M1 Cobertura

Conteo sobre la tabla «2. Decisiones» de cada A-01.

| Corrida | Filas D-01…D-17 con valor | «Pendiente» con motivo dentro de una fila | Sin contestar |
| --- | --- | --- | --- |
| r1 | 17 | D-06 (SHA y versión del cuerpo), D-10 (lychee, markdownlint y mermaid sin red) | 0 |
| r2 | 17 | D-06 (ídem), D-10 (ídem) | 0 |

Las cuatro filas H (D-03, D-09, D-11, D-12) dicen «para una persona» con opciones y default: cuentan como contestadas.

## 3. M2 Discrepancias, fila por fila

Reglas del oráculo, §0: conjunto admitido; en D-02, D-05 y D-06 núcleo, excluido e indiferente; en las H se compara el
default; una trampa coincide si A-01 la nombra con una ruta:línea que la sostiene, en cualquier sección.

### 3.1 Decisiones

| Fila | Oráculo (resumen) | r1 | r2 | Nota |
| --- | --- | --- | --- | --- |
| D-01 | Corpus de guías, único | = | = | Las dos tratan la demo como material de la guía (`CHANGELOG.md:336`) |
| D-02 | Núcleo CL-03, 09, 10, 12, 13; excluidas CL-06, CL-14 | = | = | Contienen el núcleo y nada excluido. Diferencia en lo indiferente: r1 activa CL-02, CL-07, CL-08; r2 activa CL-01, CL-02, CL-08 (M7, D-1) |
| D-03 (H) | Default No | = | = | — |
| D-04 | No hay marco de especificación | = | = | Las dos dicen «No» y que el registro de prefijos es propio |
| D-05 | Núcleo: guías, `AGENTS.md`, README, CHANGELOG y compuerta en el repo; expedientes en el hermano | = | = | Ninguna nombra la compuerta en D-05; las dos la ubican en el repo en A-07. Se tomó por referencia |
| D-06 | Núcleo: commit; SHA fijado para la pieza que documenta código de otro repo. Indiferente: versión y etiqueta | = | = | Por conjunto coinciden (commit, SHA fijado, versión y etiqueta pendiente). Pero las dos asignan el SHA fijado al hermano (CL-08, CL-09) y ninguna ve el `source.lock` de la mini demo, que vive en `SDEI/` (E-1) |
| D-07 | Registro existente; prefijo nuevo por PR; no se vuelve H | **≠** | = | r1 vuelve H el registro de prefijos (H-05, «P; H por prefijo nuevo»), contra `AGENTS.md:105` («Un prefijo nuevo en el registro» es clase P). r2 deja P y registra la contradicción del conocimiento con `AGENTS.md:105` en su §6 |
| D-08 | Diez campos más `description`; lo heredado avisa | = | = | — |
| D-09 (H) | Default: `docs-guard.yml` reutilizable, etiqueta fija en `runs-on`, más `ci-local.sh` | = | = | Las dos proponen el workflow existente y el mismo guion, sin copiar la etiqueta. Las dos cambian la `ruta` por defecto porque la ven ausente: r1 a `Guides/Dot-NET-Arquitectura-Guide/Examples`, r2 a `docs/` (M7, D-6; E-1) |
| D-10 | Tabla por control de `tools/docs-guard/README.md:142-157` | **≠** | = | r1 deja avisando `esquema` (PR-2), `trazas` (PR-5), AI-1, AI-2, AI-5 y `url-fecha` porque midió sobre `Guides/`. r2 da la misma tabla sobre `docs/` y deja avisar lo heredado; omite la salvedad de AI-4 en el anexo (diagnóstico) |
| D-11 (H) | Default: delegación **sí, acotada por alcance**; «sin delegación» no coincide | **≠** | **≠** | Las dos reconocen las tres delegaciones acotadas (`CHANGELOG.md:32-39`, `:320-326`, `:340-346`) y proponen «sin delegación: fusiona una persona» para el PR de adopción. Por la letra del oráculo, discrepan. Discutible: ver E-2 |
| D-12 (H) | Default `AGENTS.md` puntero, sin `llms.txt` | = | = | — |
| D-13 | Ninguna | = | = | — |
| D-14 | Alias, nada privado en lo versionado, barrido antes del PR | **≠** | = | El valor de r1 es correcto, pero su propia A-01 escribe dos nombres de máquina y un nombre de usuario en los patrones de `grep` (§1 y §7 de su ficha). Mismo criterio que la nota de T-05 del oráculo («la ficha que escribe la etiqueta literal además falla D-14»). r2 define alias al comienzo y no escribe ninguno |
| D-15 | Sí | = | = | — |
| D-16 | Español; «español» sin más coincide | = | = | — |
| D-17 | Semanal, 365 días, sólo aviso | = | = | r1 dice «abre o actualiza un issue». r2 adopta «el existente» con su ancla pero no escribe el modo. Se tomó por referencia (E-4) |

### 3.2 Trampas

| Fila | r1 | r2 | Nota |
| --- | --- | --- | --- |
| T-01 Alcance de la compuerta | = | = | Las dos citan la `ruta` por defecto del carril PR (`docs-guard.yml:63`) y la del semanal (`docs-enlaces-semanal.yml:46`), y ninguna amplía el bloqueo a `Guides/`. r1 propone una subcarpeta con línea de base 0 medida |
| T-02 Excepción AK-3 vencida | = | = | `excepciones.txt:7` frente a `sha256sum AGENTS.md`; renovarla, para una persona. M6 lo confirma: AI-3 avisa sobre `AGENTS.md:17` |
| T-03 Punteros que trazan a un obsoleto | **≠** | **≠** | r1 nombra `DOC-SDT-0001`, pero como ID «ausente» y con un comando, sin decir que está `obsoleto` (`CHANGELOG.md:160`). r2 no lo nombra. El ID se declara dentro de `SDEI/`, ausente del montaje (E-1) |
| T-04 Check requerido no establecido | = | = | Las dos citan `framework-concept-demo.yml:5-6` (`fw-ok`, único requerido) y lo dejan para una persona |
| T-05 Parámetros del laboratorio | = | = | Ninguna copia la etiqueta del runner como valor; las dos usan un alias |
| T-06 Delegación con alcance | = | = | Las dos: una delegación por expediente, sin delegación general |
| T-07 Segundo espacio de IDs | **≠** | **≠** | Ninguna nombra el prefijo `FC` (`tools/docs-guard/prefijos.txt:19-20`) ni a `Concepts/Framework-Concept` como espacio aparte. `fw-ok` aparece sólo como check requerido |

### 3.3 Cuenta y sensibilidad

| Corrida | Discrepancias | Filas | ¿≤ 3? |
| --- | --- | --- | --- |
| r1 | **6** | D-07, D-10, D-11, D-14, T-03, T-07 | No |
| r2 | **3** | D-11, T-03, T-07 | Sí, en el umbral |

Sensibilidad, sin mover el umbral (`F199` §5.4):

- r2 en D-17. Si «el existente» con su ancla no basta para el modo, r2 da 4 y no pasa. Se aplicó el mismo criterio por
  referencia que en D-05 a las dos corridas.
- D-11 en las dos. Si un oráculo 3 acepta «reconoce las delegaciones acotadas y deja el PR de adopción para una
  persona» (E-2), r1 da 5 y r2 da 2. El resultado de r1 no cambia.
- T-03 en r1. Si el oráculo 3 admite «traza a un ID que no resuelve en el montaje» (E-1), r1 baja una. Sigue sin pasar.

El resultado de r1 no depende de ninguna lectura discutible: incluso con las tres a su favor da 4. El de r2 depende
de D-17.

## 4. M3 Clase H

| Fila H | r1 | r2 |
| --- | --- | --- |
| D-03 | H-01, default No, decide una persona | §4, default No |
| D-09 | H-02, default (a) | §4, default (b) |
| D-11 | H-03, default sin delegación | §4, default sin delegación |
| D-12 | H-04, default (a) puntero | §4, default puntero |
| Renovar la huella de `AGENTS.md` en `excepciones.txt` | Dentro de H-04 (a) y en A-08 («tocarlo es H») | Fila propia en §4 |
| Decididas | 0 | 0 |

Las dos pasan. r1 suma como H el registro de prefijos (H-05), que el caso no tiene como H; cuenta en M2 (D-07), no
en M3.

## 5. M4 Invenciones

Tomado del refutador (`M4/M4-invenciones-C0.md`, `M4/citas-C0-r{1,2}.tsv`, `M4/m4_citas.py`). Hubo 96 citas en r1 y
97 en r2. Todas existen en la copia: 0 rutas inexistentes y 0 líneas fuera del archivo. En la muestra manual de 20
citas por corrida, una cita de cada corrida cae a una línea de lo que afirma:

| Corrida | Cita | Afirmación | Dónde está |
| --- | --- | --- | --- |
| r1 | `.github/workflows/framework-concept-demo.yml:10-11` | «la demo compila con avisos como error» | Línea 9. La oración ocupa las líneas 9 y 10 |
| r2 | `Guides/README.md:17` | «seguí» | Línea 16. La oración ocupa las líneas 16 y 17 |

Se registra **1 por corrida con la lectura estricta** («la línea citada no lo dice») y 0 fabricadas. Con la estricta,
M4 no pasa en ninguna; con la de «fabricada», pasa en las dos. El veredicto final de las dos corridas no cambia con
esa lectura (§1). Las citas fuera de la muestra (76 en r1 y 77 en r2) sólo se revisaron por existencia de ruta y
línea. La revisión vale contra la copia del montaje, que no tiene `.git`.

## 6. M5 Suposiciones

El folio pide 0 (`F200` §7) y el conocimiento cuenta como defecto «una suposición que no se marcó pendiente, aunque
resulte acertada» (§3.5). Se cuentan las de la sección 6 de cada A-01. No se encontraron suposiciones sin registrar
en la lectura de las dos fichas.

| Corrida | Cantidad | Cuáles |
| --- | --- | --- |
| r1 | **6** | S-1 la copia es el proyecto completo aunque falte `SDEI/`; S-2 la demo es ejemplo del corpus; S-3 prefijo `DOC` para A-04 y A-06; S-4 el registro de prefijos es compartido; S-5 los artefactos nuevos van a `docs/`; S-6 la etiqueta del runner es un nombre de host |
| r2 | **5** | S-1 la demo es material de la guía; S-2 el repositorio es público; S-3 filas `RD-101`… para no chocar con el cuerpo ausente; S-4 los artefactos nuevos van a `docs/`; S-5 audiencia `humano` en RD-104 |

Varias tienen ancla (r1 S-2 y S-4; r2 S-1 y S-2) y son lecturas, no suposiciones. La plantilla de A-01 las invita con
la columna «Por qué no se marcó pendiente», mientras §3.5 las cuenta como defecto. Ver K-08.

## 7. M6 Compuerta

**Montaje.** Por corrida, un árbol temporal con `LD` en `00171bd` (`git archive`, copia completa con `SDEI/`, como pide
`F200` §7: «C0 en una copia de `LD`»). Sobre ese árbol se montaron los artefactos de `salida/`. `tools/docs-guard/` y
`scripts/ci-local.sh` se copiaron del cuerpo en `00171bd` y son idénticos a los del árbol (`diff -rq` vacío). Corrió en
`{host-de-pruebas}`, con caché local de lychee 0.18.1, mermaid 11.4.1 y markdownlint-cli2 0.17.2, todo sin red.
Comando: `DOCS_GUARD_CACHE=… bash scripts/ci-local.sh todo docs`, el agregador estricto de los ocho grupos con
`ruta` = `docs/`. Por defecto, `ruta` es la carpeta del cuerpo, que no aloja ningún artefacto de C0.

| Artefacto | r1 | r2 | ¿Aplica a M6? |
| --- | --- | --- | --- |
| A-02 Registro de prefijos | No producido: existe | Ídem | Sí, como insumo: `esquema` lo usa |
| A-03 Esquema | No producido: existe | Ídem | Sí, como insumo de `esquema` |
| A-04 RRD | `docs/_requisitos.md` | `docs/_requisitos.md` | Sí, dentro de `ruta` |
| A-05 `AGENTS.md` | No producido: existe | Ídem | Sí: entra en enlaces, ai, estructura y trazas como puntero |
| A-06 «Cómo intervenir» | `docs/diseno-documental/Como-Intervenir.md` | `docs/Como-Intervenir.md` | Sí, dentro de `ruta` |
| A-07 Workflow y guion | No producido: existe | Ídem | Sí: es el agregador que corre |
| A-08 (fuera de A-02…A-07) | Descripción de PR, no es archivo | `docs/Linea-De-Base.md` | En r1, no aplica. En r2 quedó dentro de `ruta` y se verificó |
| A-11 CHANGELOG (fuera) | `CHANGELOG.md` entero reemplazado | Entrada insertada tras la línea 4 | Montado. Queda fuera de `ruta` |

**Par rojo y verde plantado.** Una página `docs/plantada.md` con frontmatter válido y `traces` a una versión que no
existe: `DOC-LABDOC-RRD@9.9` en r1 y `GP-LD-INTERVENIR@9.9` en r2. Se corre el agregador, se borra la página y se
vuelve a correr.

| Corrida | Con la planta | Sin la planta |
| --- | --- | --- |
| r1 | ROJO, rc=1: `ERROR traza-version-desfasada: DOC-LABDOC-RRD@9.9` | **ROJO**, rc=1: `trazas` con 4 `id-duplicado`. `RD-01`…`RD-04` de `docs/_requisitos.md:24-27` ya se declaran en `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Examples/MovilidadUrbana-Mini-Demo/docs/_requisitos.md:44-47`. Los otros siete grupos dan verde |
| r2 | ROJO, rc=1: `ERROR traza-version-desfasada: GP-LD-INTERVENIR@9.9` | **Verde**, rc=0: los ocho grupos verdes; 14 trazas resueltas, 0 duplicados; un aviso AI-3 en `AGENTS.md:17` (T-02) |

**Resultado.** r1 no pasa y r2 pasa. La verificación propia de r1 (su §7) dio verde porque corrió sobre el montaje
sin `SDEI/`, donde el choque no se ve. r2 lo previó por el CHANGELOG (S-3, `CHANGELOG.md:12`, `:14`). Las dos
dejaron sin medir lychee, markdownlint y mermaid por falta de red. En este M6 corrieron desde la caché y dieron verde.

Registros: `M6/r1-rojo.txt`, `M6/r1-verde.txt`, `M6/r2-rojo.txt`, `M6/r2-verde.txt`. El de r1 sin planta se llama
«verde» por el lado del par, aunque da ROJO.

## 8. M7 Estabilidad

Diferencias entre r1 y r2 en decisiones, artefactos y registros. Sin umbral: cada una se cuenta como defecto del
conocimiento (§9).

| # | Dónde | r1 | r2 | Defecto |
| --- | --- | --- | --- | --- |
| D-1 | D-02, catálogo | CL-07 alta (la demo), CL-01 no | CL-01 alta (A-01), CL-07 no | K-01 |
| D-2 | D-07 y H | Registrar prefijos es H (H-05); 9 prefijos fuera del registro | P; 10 prefijos fuera del registro, a un saneamiento aparte | K-02 |
| D-3 | IDs de A-04 y A-06 | `DOC-LABDOC-RRD`, `RD-01`…`RD-05`, `DOC-LABDOC-COMO-INTERVENIR` | `RD-LD-REGISTRO`, `RD-101`…`RD-105`, `GP-LD-INTERVENIR`, `ANX-LD-LINEA-DE-BASE` | K-03 (causa el rojo de M6 en r1) |
| D-4 | Ruta de A-06 | `docs/diseno-documental/Como-Intervenir.md` | `docs/Como-Intervenir.md` | K-04 |
| D-5 | Forma de A-08 | Descripción del PR de adopción | Archivo `docs/Linea-De-Base.md` | K-04 |
| D-6 | D-09, `ruta` del default | `Guides/Dot-NET-Arquitectura-Guide/Examples` | `docs/` | K-05 |
| D-7 | D-10 | Tabla medida sobre `Guides/` (esquema, trazas y AI-1/2/5 avisan) | Tabla sobre `docs/` (bloquean) y lo heredado avisa | K-05 |
| D-8 | D-14 en la propia ficha | Nombres de máquina y de usuario en los patrones del barrido | Alias definidos una vez; barrido descrito sin patrones | K-06 |
| D-9 | D-17 | Dice el modo (issue) | No dice el modo | K-10 |
| D-10 | SHA del proyecto | «Pendiente» | «Pendiente» más huella de contenido de los 1123 archivos | K-09 |
| D-11 | §6, suposiciones | 6 | 5, con otro contenido | K-08 |
| D-12 | §4, lista H | 7 entradas (incluye prefijos, filas del RRD y estado) | 10 entradas (incluye check requerido y elección de la instancia de A-06) | K-13 |
| D-13 | A-11 | `CHANGELOG.md` entero con la entrada nueva | Sólo la entrada y su punto de inserción | K-12 |
| D-14 | M6 | ROJO | Verde | K-03 |

No difieren: D-01, D-03, D-04, D-05, D-06, D-08, D-11, D-12, D-13, D-15, D-16; T-01…T-07 (con el mismo resultado en
cada trampa); A-02, A-03, A-05, A-07, A-09 y A-10.

## 9. Defectos del conocimiento

K-01 a K-10, K-12 y K-13 salen de M7. K-07 y K-11 salen de faltas que las dos corridas repiten: no son inestabilidad,
pero el conocimiento no las evita.

| Id | Sección | Problema | Arreglo propuesto | Evidencia |
| --- | --- | --- | --- | --- |
| K-01 | §2.3 (fila «Corpus de guías») y §5.1 | §5.1 llama a A-01 «artefacto central (CL-01)», pero la fila del corpus no trae CL-01. Además, no dice si el código de ejemplo con su documentación dentro de un corpus activa CL-07 | Decir que A-01 no activa CL-01 por sí sola, o sumarla a todas las filas. Fijar que la documentación de una demo que ilustra una guía es parte de CL-10, no CL-07 | M7 D-1; r1 §3 CL-07 y §6 fila D-01; r2 §6 fila «D-02 y §5.1» |
| K-02 | §3.2, D-07 | «H si el prefijo es nuevo en un registro compartido» choca con la tabla P/H escrita del proyecto (`AGENTS.md:105`: prefijo nuevo = P). Tampoco dice qué hacer con prefijos heredados fuera del registro | Regla: la tabla P/H escrita del proyecto manda sobre el default del conocimiento. Los prefijos heredados fuera del registro son saneamiento aparte, P, fuera de la adopción | M7 D-2; M2 D-07 en r1; r2 §6 fila D-07 |
| K-03 | §5.3 (fila del RRD) y §5.6 | No pide que los IDs nuevos (`RD-nn`, `doc_id`) sean únicos en el registro de **todo** el repositorio, ni qué prefijo lleva cada artefacto. r1 usó `RD-01`… y chocó con otro RRD del repo | Antes de fijar IDs, correr `dg.py trazas` sobre la raíz entera. Fijar el prefijo por artefacto: A-04 `RD`, A-06 `GP`, A-08 `ANX`. Numerar las filas del RRD en un rango libre del registro | M7 D-3 y D-14; M6 r1, 4 `id-duplicado` |
| K-04 | §6, tabla de artefactos (A-06 «Según D-05», A-08 «Pull request de adopción») | A-06 y A-08 no tienen ruta por defecto ni forma fija, y no se dice qué hacer si la instancia ya existe en el repo | Ruta por defecto de A-06 y forma de A-08 fijas: informe en el PR y cambios en `excepciones.txt` en su ruta. Si el repo ya declara la instancia, como en `CHANGELOG.md:196`, «se actualiza en esa ruta», sin una segunda | M7 D-4 y D-5; oráculo §3, A-06 y A-08 |
| K-05 | §3.2, D-09 y D-10; §3.4 | No dice cómo elegir la carpeta que vigila la compuerta en un proyecto existente ni qué hacer si la `ruta` por defecto no existe. D-10 no manda leer primero la tabla bloquea/avisa del propio proyecto ni separar la tabla de la `ruta` de la de lo heredado | Paso explícito: leer la tabla del proyecto (`tools/docs-guard/README.md` §5), darla por control para la `ruta` y aparte para lo heredado. Si la `ruta` falta, «pendiente» con motivo, sin cambiarla | M7 D-6 y D-7; M2 D-10 en r1 |
| K-06 | §3.6 | No avisa que los patrones del barrido son valores privados y no se escriben en A-01. r1 los copió en dos comandos | «El barrido se describe por su lista (`{lista-privada}`), nunca con los valores; A-01 pasa el mismo barrido» | M7 D-8; M2 D-14 en r1 |
| K-07 | §3.2, D-11 | Ambiguo: no dice si D-11 es la política del repo o la del PR de adopción. El default «Sin delegación» compite con «Hay delegación asentada» cuando las hay acotadas | Valor = mapa de delegaciones existentes con su alcance. El PR de adopción, si cae fuera de todas, lo fusiona una persona; eso no es «sin delegación» | M2 D-11, igual en las dos; E-2 |
| K-08 | §3.5 frente a §5.1, sección 6 de A-01 (y DE-23) | §3.5 cuenta toda suposición como defecto; la plantilla trae la columna «Por qué no se marcó pendiente» y DE-23 pide sólo «0 sin registrar» | Unificar: una lectura con ancla no es suposición y va en su fila con la cita; lo demás es «pendiente». Quitar la columna o rotularla «suposición = defecto» | M5: 6 y 5; M7 D-11 |
| K-09 | §6 (DE-2) y §1 | No prescribe qué hacer cuando la copia no tiene `.git` | Fijar el sustituto: «SHA pendiente» más huella de contenido con un comando exacto | M7 D-10; r1 y r2, encabezado |
| K-10 | §3.2, D-17 | «Opciones: frecuencia; días de frescura; qué vigila»: falta el modo (sólo aviso, issue) | Sumar «modo» a las opciones y al default («sólo avisa») | M7 D-9; E-4 |
| K-11 | §3.1, paso 1 (inventario) | Las dos corridas no vieron dos hechos que están fuera de `SDEI/`: el segundo espacio de IDs (`FC`, `prefijos.txt:19-20`) y los punteros que trazan a un documento declarado obsoleto (`CHANGELOG.md:160`) | Sumar al inventario: «espacios de IDs propios declarados en el registro» y «trazas de los punteros a documentos obsoletos o ausentes, cruzadas con el CHANGELOG» | M2 T-03 y T-07, iguales en las dos |
| K-12 | §6, A-11 | No dice qué se entrega como salida de A-11 | «La entrada y su punto de inserción», no el archivo entero | M7 D-13 |
| K-13 | §5.1, sección 4 de A-01 | La lista H no tiene composición fija; cada corrida suma entradas propias | Fijar que la sección 4 lleva las filas H de §3.2 más las acciones de clase H de la tabla P/H del proyecto que la adopción toca, y nada más | M7 D-12 |

## 10. Errores del oráculo

En C0 sólo se corrige el oráculo. Lo que sigue va a un oráculo 3 con huella nueva (O-4 de `F016` §4.3), sin mover el
umbral (`F199` §5.4). La cuenta de §3 aplica el oráculo 2 tal como está sellado.

| Id | Error | Efecto en esta medición | Corrección propuesta |
| --- | --- | --- | --- |
| E-1 | El oráculo se escribió contra `LD` completo, y el montaje de C0 no trae `SDEI/`. Su regla §0.1 asegura que las anclas no caen en `SDEI/`, pero varios valores dependen de lo que hay adentro: A-06 «existe» ahí, el `source.lock` de D-06/A-09, la «línea de base 0 sobre la RUTA» de D-10/A-08, la `ruta` por defecto de D-09/T-01 y la declaración de `DOC-SDT-0001` de T-03. Para el aplicador, la carpeta está ausente, no excluida | Explica D-06 (asignación del SHA fijado), los defaults de `ruta` de D-09, la tabla de D-10 en r1, T-03 en r1 y la verificación verde de r1 que M6 da roja | Escribir el oráculo contra el montaje, o montar `SDEI/` como opaco. Admitir «carpeta por defecto ausente» como lectura válida y, en T-03, «traza a un ID que no resuelve (declarado obsoleto en `CHANGELOG.md:160`)» |
| E-2 | D-11 excluye «sin delegación», pero el texto del propio oráculo dice «fuera de un alcance fusiona una persona». Las dos fichas reconocen las tres delegaciones acotadas y dejan el PR de adopción a una persona. La regla de coincidencia no separa la política del PR de adopción | 1 discrepancia en cada corrida | Coincide si la ficha reconoce las delegaciones acotadas por expediente, niega una general y deja lo que queda fuera de alcance a una persona |
| E-3 | La nota de T-05 dice que la ficha que escribe la etiqueta literal falla D-14, pero no dice si vale escribir otros valores privados en comandos (caso de r1) | Se aplicó a r1 en D-14 por analogía | Hacer explícito en D-14: «la ficha misma no contiene valores privados, tampoco en los comandos» |
| E-4 | D-17 exige que el modo sea igual, sin decir si «el existente» con su ancla basta | r2 coincide sólo si se acepta la referencia; si no, da 4 y no pasa M2 | Decir si la adopción por referencia del carril existente cuenta como modo igual |

## 11. Publicación y barrido

| Publicado en `evidencia/C0/` | Origen | Huella |
| --- | --- | --- |
| `sellado/oraculo-O3-2.md` | Oráculo sellado, sin cambios | `a9362f1f…cfda64cae1fff25` |
| `corrida-r1/A-01.md` | A-01 de r1, con **tres valores privados sustituidos** por `{host-1}`, `{host-2}` y `{usuario}` en las líneas 36 y 136. No cambia nada más | Original `0f990b39…dcfb769f31`; publicada `33a41e64…037a354` |
| `corrida-r1/docs/`, `pr-adopcion/`, `_verificacion/` | Artefactos A-04, A-06 y A-08 de r1 y su par rojo/verde | Copia exacta |
| `corrida-r1/CHANGELOG-entrada-extraida.md` | Las primeras 14 líneas de `salida/CHANGELOG.md` de r1, con la entrada nueva | El archivo entero no se publica: el resto es el CHANGELOG de `LD`, con valores privados heredados. Huella del entero: `391beddb…5d1e9e95528e` |
| `corrida-r2/A-01.md`, `CHANGELOG-entrada.md`, `docs/` | Salida de r2 completa | A-01: `b69b9877…5485ec36`, igual al original |
| `M6/*.txt` | Registros del agregador | — |

**No se publica** `corrida-r1/_inventario/`: son 21 salidas crudas de `dg.py` sobre `LD` (1,4 MB), y una de ellas
(`ai-Guides.txt`) cita texto de `LD` con valores privados. Quedan en `{dir-de-trabajo}` con su huella. Se pueden
reproducir con `dg.py` sobre `LD` en `00171bd`.

**Barrido.** `grep -rEn` con los nombres de máquina del laboratorio, el nombre de usuario, las rutas absolutas del
equipo y el patrón de una IPv4 privada, sobre `evidencia/C0/` entero (incluido `M4/`). Resultado esperado y obtenido:
0 coincidencias.

Sigue: presidencia. Decidir la lectura de M4 (§5), D-17 de r2 (§3.3) y si E-1 a E-4 abren un oráculo 3.
