---
doc_id: EXP0003-F014
doc_type: informe
title: Informe de la comisión de Trazabilidad documental — unicidad y resolución de IDs, prefijos, trazas, citas y versiones del cuerpo SDEI, y lo que el libro y el conocimiento conservan
status: vigente
origin: agent
confidence: alta en lo medido (ensayos sobre una copia de LD en 0bed863 y un clon nuevo, 2026-11-01); media en las posiciones, rotuladas «criterio propio» donde no las funda una fuente
owner: comisión C-DOC-SIS (variable, Trazabilidad documental) de la mesa de la reedición DocsAsCode
last_review: 2026-11-01
audience: [presidencia, refutador, análisis de decisiones, jurado de veredicto, comisiones, PO]
traces: [TP:48, TP:54, TP:73, TP:96-98, PP:335-386, RM:225, EXP0003-F001, EXP0003-F004]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-01 |
| Autor | Comisión C-DOC-SIS (variable, `RM:225`), titulada por un especialista en documentación técnica de sistemas, a ciegas |
| Corrige | — |

| Cabecera de comisión | Valor |
| --- | --- |
| Rol | Trazabilidad documental: ¿los IDs, prefijos, trazas, citas entre documentos y versiones del cuerpo son únicos y resolubles, y el libro y el conocimiento los conservan? (folio 004 §6) |
| Preguntas a cargo | P-01, P-02, P-04, P-08, P-09, P-10, P-12, P-13, P-14, P-22 (`PP` §7) |
| No-competencia | Ayuda al usuario final; estilo; la CI como ejecución (es de `C-VER`). Frontera K4 del folio 004: en P-15 y P-16 sólo entro si tocan prefijos, y no entro |
| Norma | `IA.Knowledge.Base/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 (`MEP`) |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Líneas 1–111 (cabecera y §0, con el mapa de carga; fila «Sos una comisión», `MEP:106`); §2.2; §3.2; §3.3; §4; §5.2 |
| Otros documentos cargados | `Cadena-De-Consecuencias` 2.0 §2 y §3 (`CC`); `Rule-Escalas-De-Juicio` 1.2 §3.3 (`EJ`); `Mesa-Consulta-A-Un-Tercero` 2.0, cabecera (no rige: no hay tercero, lectura A de `PP` §6.5); `Conformacion-Pull-Request-Automatico` 2.0 §3.1 (`CPA`) |
| Insumos leídos | `PP` entero; folios 001 y 004; `N1` entero; `N2` §4, §6; `N3` §3.4, §6; `N4` §5; `N5` §3–§4; `N7` §4.2–§5; `N6` (lista de fuentes). El cuerpo SDEI en la base `0bed863`, leído directamente. No se leyeron informes de otras comisiones (`01x-*`) |
| Medios propios | Lectura con `git`, `grep` y `sed`; ensayos de `dg.py` sobre una copia `git archive` de LD en `0bed863`; un clon nuevo de LD por HTTPS; API pública de GitHub; cuatro consultas web (§8) |

Alias: los del folio 001 §1 (`TP`, `PP`, `N1`–`N7`, `SDEI/`, `MEP`, `RM`, `{servicio-privado}`, `{host-de-pruebas}`,
`{dir-de-trabajo}`). Además: **LD** = Lab-Documentos; **LDD** = Lab-Documentos.Documentacion; **EXP2/** = la
carpeta del expediente 0002 en LDD; **DG** = `tools/docs-guard/dg.py` de LD; **REG** = `tools/docs-guard/prefijos.txt`
de LD; **ESQ** = `SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md`; **GV** = `SDEI/Sistema-Documentador-Tecnico-Guide.md`
(la guía obsoleta). `<org>` es la organización de GitHub de LD y LDD.

# Informe de la comisión C-DOC-SIS — expediente 0003

## Índice

1. [Definiciones y forma de este informe](#1-definiciones-y-forma-de-este-informe)
2. [Ensayos corridos](#2-ensayos-corridos)
3. [Hallazgos](#3-hallazgos)
4. [Dictamen por pregunta](#4-dictamen-por-pregunta)
5. [Cadena de consecuencias de las recomendaciones](#5-cadena-de-consecuencias-de-las-recomendaciones)
6. [Lo que revisé y está bien](#6-lo-que-revisé-y-está-bien)
7. [Solicitudes de convocatoria](#7-solicitudes-de-convocatoria)
8. [Fuentes externas](#8-fuentes-externas)
9. [Excepciones a conocimientos](#9-excepciones-a-conocimientos)
10. [Lo no verificado e incidencias](#10-lo-no-verificado-e-incidencias)

---

## 1. Definiciones y forma de este informe

| Término | Definición en este informe | Fuente |
| --- | --- | --- |
| **ID** | Cadena con la forma `^[A-Z][A-Z0-9]*(-[A-Z0-9]+)+$` cuyo primer segmento es un prefijo del registro | `DG:51` (`RE_ID`); `cuerpo.schema.json:9` |
| **Declaración** | Lo que DG reconoce como lugar donde un ID nace: el `doc_id` del frontmatter, una fila `RD-nn` de un RRD y un encabezado que **empieza** con un ID | `DG:456-482` (`declaraciones`) |
| **Resoluble** | Una traza a ese ID da verde en PR-5 (`traces-resolve`) | `DG` ayuda, subcomando `trazas` |
| **Único** | El ID tiene una sola declaración en las rutas que mira PR-5 (`id-duplicado` en 0) | `DG` ayuda, `id-duplicado` |
| **Cita muerta** | Un SHA citado que no es ancestro de `main` y que un clon nuevo no tiene | Criterio propio, medido con `git merge-base --is-ancestor` y un clon nuevo (§2) |
| **Versión del cuerpo** | El valor `version` del README del cuerpo (`2.0.0-borrador`) | `SDEI/README.md:3` y `:22` |

**Ejemplo.** `CQ-01` es un ID (prefijo `CQ` interno, REG:23), está definido en una fila de tabla del anexo de criterios
y aparece en siete lugares del cuerpo, pero **no es resoluble**: una página con `traces: [CQ-01]` da
`ERROR traza-no-resuelve` (§2, E3), porque una fila de tabla no es una declaración para DG.

**Lectura P0–P3** (folio 001 §9): **P0** viola una restricción dura (un guion publicado que no corre, un dato falso
sobre el ejemplo conductor, la compuerta en rojo) o hace imposible el objetivo; **P1** retrabajo o lectura divergente
(un término con dos sentidos, dos reglas que se contradicen); **P2** pérdida acotada (una cita vieja, una referencia sin
fecha); **P3** claridad.

**Clase de ancla** (`EJ` §3.3): E1 comando con salida; E2 cita literal con archivo y línea; E3 contraejemplo; E4 regla
declarada; C conjetura o hallazgo heredado no abierto.

## 2. Ensayos corridos

Todos el 2026-11-01, en `{host-de-pruebas}`, sobre una copia `git archive HEAD` del worktree de LD (`0bed863`) en
`{dir-de-trabajo}`, con el DG de esa base y `python3 -I`. Nada se escribió en un repositorio. Las copias se borraron
al terminar.

| # | Qué | Comando (resumido) | Salida |
| --- | --- | --- | --- |
| E1 | Registro de declaraciones de `SDEI/` | Script propio que importa `dg.registro()` y cuenta | `IDs declarados: 51`; `duplicados: 0` |
| E2 | Menciones de IDs con prefijo **interno** que no están en el registro | El mismo script: toda cadena `RE_ID` cuyo prefijo REG marca `interno` y que no está en el registro | `menciones internas no declaradas: 155`. Por familia: `VER-*` 74, `CQ-01..14` 14, `PE-01..12` 12, `OBJ-SDEI-01..05` 5, `ACT-SDEI-1..6` 6, `TEM-01/02/03/07`, más ejemplos deliberados (`ESC-1`, `TEM-99`, bloques de código) |
| E3 | ¿Resuelven? Una página de prueba con `traces: [X]`, una corrida por X | `dg.py trazas SDEI/` | `CQ-01`, `PE-01`, `ACT-SDEI-2`, `VER-E01`, `OBJ-SDEI-01`, `TEM-01`: **ERROR traza-no-resuelve**. `TEM-04`: verde. `TEM-SDEI-01@1.0`: **ERROR traza-sin-version** («la declaración no tiene **Versión:** ni version»). `IDX-SDEI@2.0`: verde. `DOC-SDT-0001`: verde |
| E4 | Identidad del libro | Página `DocsAsCode-Developer-Guide.md` con `doc_id: DOC-SDEI-LIBRO` (y otra corrida con `DOC-SDEI-GUIA`), `doc_type: guia-de-estudio`, `description`, `traces` a `IDX-SDEI` y temas | `PR-2 esquema: verde (errores=0)`; `PR-5 traces-resolve: verde … ids-duplicados=0`; `PR-3 anti-inyeccion: verde` — con los dos `doc_id` |
| E5 | Archivar la guía obsoleta | Sacar GV de la copia y correr `dg.py trazas SDEI/ AGENTS.md README.md Guides/README.md` (las rutas de `trazas-extra`, `docs-guard.yml:44-48`) | `README.md:1: ERROR traza-no-resuelve: DOC-SDT-0001`; `Guides/README.md:1: ERROR traza-no-resuelve: DOC-SDT-0001`; `PR-5 … ROJO (errores=2)`. Con GV en su lugar: verde |
| E6 | Versión del conocimiento | `Conocimientos/knowledge-DocsAsCode-Designing-Specification.md` con `doc_id: ANX-SDEI-ESPECIFICACION`, `doc_type: anexo`, `**Versión:** 1.1` en el cuerpo, y una página que traza `ANX-SDEI-ESPECIFICACION@1.1` | Sin `version` en el frontmatter: **ERROR traza-sin-version**. Con `version: "1.0"`: **ERROR traza-version-desfasada: la declaración está en 1.0**. Con `version: "1.1"`: verde. `esquema`: verde en los tres |
| E7 | SHA citados por el cuerpo tras la reescritura | `git merge-base --is-ancestor <sha> origin/main`; clon nuevo `git clone --filter=blob:none --no-checkout https://github.com/<org>/Lab-Documentos.git`; `git cat-file -t` | `080f158` y `fe10086`: **no-ancestro**; en el clon nuevo, `fatal: Not a valid object name`. `e3841b6` y `6878568`: ancestros y presentes. API `GET /repos/<org>/Lab-Documentos/commits/080f158`: `200`; enlace de blob en `080f158`: `200` |
| E8 | ¿El merge equivalente tiene el mismo contenido? | `git log -1 --format='%s %T'` y `git diff --quiet A B -- <rutas>` | `080f158` y `e3841b6`: mismo asunto («Merge pull request #19 …»), **árboles distintos**; `git diff --stat` = 3 archivos de otras guías (`Guides/Despliegue/…`, `Guides/Testing/…`), 5+/5−. **Idénticos** en `tools/docs-guard`, `Guides/Documentacion-Tecnica`, `scripts` y `.github`. Igual para `fe10086` frente a `6878568` (#25) |
| E9 | Usos de `PE` | `git grep -n -i "pregunta de evaluaci"` en LD; historia con `git log -S` | Una sola aparición: `REG:24`. Cero usos de `PE` como pregunta de evaluación en el cuerpo. `PE-01..12` como patrón: 14 líneas en `Patrones-De-Ejemplos.md`. Las dos lecturas nacen el mismo día: REG en `233c3ce` y el anexo en `fe175ed` (2026-10-27) |
| E10 | Delegación de merge para el 0003 | `grep -n 0003` sobre los `CHANGELOG.md` de LD y LDD | 0 líneas |

## 3. Hallazgos

Tope: 12. Doce emitidos.

| Id | Nivel | Ancla | Hallazgo | Impacto si no se corrige | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| DS-01 | **P0** | E1 (E7, E8) | Ocho líneas de cuatro temas citan `080f158`, que la reescritura dejó fuera de `main`: `TEM-01:218,343`, `TEM-02:218,342`, `TEM-03:162,221`, `TEM-07:187,200`. El guion de `TEM-07:200` (`git checkout --quiet 080f158`) falla en un clon nuevo (E7). Sube a E1 el `N1-17`, que entraba como C por heredado | Un guion publicado que no corre: restricción dura (folio 001 §9). El libro lo heredaría | Re-citar «merge del PR #19, `e3841b6`». E8 prueba que el contenido que esas líneas describen (DG, el cuerpo, `scripts`, `.github`) es idéntico: **las salidas registradas siguen valiendo sin volver a correr** |
| DS-02 | P1 | E1 (E2, E3); E2 `ESQ:98-100` | ESQ dice que **interno** «quiere decir que el ID se declara en este repositorio; si no resuelve, bloquea». Pero los IDs definidos en filas de tabla (`CQ-*`, `PE-*`, `VER-*`, `OBJ-SDEI-*`, `ACT-SDEI-*`, 111 menciones) no son declaraciones para DG (`DG:456-482`) y **no se pueden trazar** | Quien escribe el libro o el conocimiento cree que puede trazar a un criterio, un patrón o un actor y la compuerta da rojo; o se trazan a mano en prosa y nadie lo verifica | Ahora, sólo texto: ESQ §5 dice qué declara un ID (`doc_id`, encabezado que empieza con el ID, fila `RD-` de un RRD) y que los IDs de tabla son **citables, no trazables**. Registrar filas de tabla como declaración es cambio de DG: a un expediente de herramienta (P-04) |
| DS-03 | P1 | E1 (E9); E2 `REG:24`, `ESQ:117`, `ESQ:199-200` | `PE` significa «pregunta de evaluación» en el registro y «Patrón de ejemplo» en el anexo; el anexo manda que ante diferencia **manda el archivo**. Por la letra, `PE-01` es hoy una pregunta de evaluación que nadie escribió | Lectura divergente entre agente (que lee REG) y persona (que lee el anexo); el libro hereda la ambigüedad en su glosario | Corregir REG:24 a «patrón de ejemplo» (P-14) |
| DS-04 | P1 | E1 (E3); E2 `ESQ:137-139`; H1 de los temas | `TEM-04`, `TEM-05` y `TEM-06` resuelven **por accidente**: sus H1 empiezan con el ID (`TEM-04-Doble-Audiencia.md:15`, `TEM-05…:15`, `TEM-06…:15`); `TEM-01`, `TEM-02`, `TEM-03` y `TEM-07` no resuelven (H1 «Tema 0n —»). ESQ:137-139 declara ambigua la forma corta. El cuerpo menciona `TEM-01` 10 veces, `TEM-03` 6, `TEM-07` 9 (E2) | Un ID que la convención declara ambiguo existe para tres temas y no para cuatro; el libro, que no puede redeclarar IDs en encabezados (`N2` R-4), choca con `TEM-04..06` si copia esos H1 | Igualar los H1 de 04–06 a «Tema 0n —» (es lo que hacen 01–03 y 07); las menciones cortas en prosa quedan como abreviatura, no como ID |
| DS-05 | P1 | E1 (E5); E2 `GV:5`, `GV:27` | Archivar GV (mover o borrar) pone PR-5 en rojo: `README.md:11` y `Guides/README.md:11` trazan `DOC-SDT-0001`, y esas dos rutas entran por `trazas-extra`. Además siete enlaces del cuerpo la citan (`N1` §3, verificado con `git grep`). GV:27 promete «un archivo inmutable» que no está definido en ningún lado | El cambio que archive rompe la compuerta o deja enlaces muertos | Antes de archivar: re-apuntar las dos trazas a `IDX-SDEI` y retirar las siete remisiones. «Archivo inmutable» = borrar el archivo y citar su enlace permanente al SHA de un commit ancestro de `main` (§8, fuente 1) |
| DS-06 | P1 | E1 (E6) | Con frontmatter, DG toma la versión del campo `version` y **ignora** el `**Versión:**` que exige la forma de la base de conocimiento. Sin `version`, una traza `@x.y` al conocimiento da `traza-sin-version`; con dos valores distintos, `traza-version-desfasada`. Es el «caso R» de `N4` §5, ahora medido sobre el conocimiento | El conocimiento P2 no se puede trazar por versión, o se traza a una versión que no es la del control de cambios | Regla en el conocimiento: `version` del frontmatter **igual** a `**Versión:**`, con la del control de cambios como fuente; comprobable con `grep` (P-22) |
| DS-07 | P2 | E1 (E3) | Ningún documento fuente del cuerpo tiene versión propia: la única es la del README (`IDX-SDEI@2.0` resuelve; `TEM-SDEI-01@1.0` da `traza-sin-version`) | El libro no puede trazar a «la versión del tema que reunió»: la compuerta no ve si una fuente cambió después de la edición del libro | La correspondencia libro→fuente se fija por **SHA de commit** en el anexo de correspondencia del libro, no por versión (P-01) |
| DS-08 | P2 | E2 LDD `ia-db/README.md:33,120,122`; E2 `semanal.sh:97-105`; E1 (E7) | El `base_commit` de la ia-db de LDD es `fe10086`, muerto en un clon nuevo. El carril semanal, ante un SHA que no encuentra, escribe «no está en ningún repo del árbol» (`semanal.sh:99`) en lugar de medir el desfase | El aviso que el cuerpo promete para `CTX-SDEI-3` (`01-Mapa.md:68`, `TEM-04:98`) se degrada sin rojo | Re-anclar a `6878568` (#25), equivalente por E8, o reindexar. Si el carril debe dar rojo ante un SHA muerto es de `C-VER` |
| DS-09 | P2 | E2 `GV:5`, `GV:27`; `SDEI/README.md:22`; E1 `git tag -l` | GV se archiva «en la versión siguiente del cuerpo», pero el cuerpo está en `2.0.0-borrador`, nunca se etiquetó (la única etiqueta del repositorio es `docs-guard-v1.0.0`) y nada dice cuál es la versión siguiente | Dos aplicadores eligen momentos distintos para archivar (P-08) | El README del cuerpo dice qué es una versión del cuerpo y que la siguiente a `2.0.0-borrador` es `2.0.0` (precedencia de SemVer, §8, fuente 2) |
| DS-10 | P1 | E2 `Glosario.md:57`; `MovilidadUrbana-Mini-Demo/README.md:45`; `00-Marco.md:130`; `semanal.sh:14`; conteo `grep -rio` | «Deriva» tiene dos sentidos: contenido contra código (glosario) y SHA fijado contra `main` (tutorial). Para lo segundo el cuerpo usa «desfase» 12 veces y «atraso» 4; la herramienta dice «atraso» | Lectura divergente en el capítulo de referencia del libro | Glosario con dos entradas: **deriva** (contenido) y **desfase del ancla** (SHA contra `main`), por mayoría de uso (P-13) |
| DS-11 | P2 | E2 `TEM-03:193-197`; EXP2/`actuaciones/259-…md:80-81` | `TEM-03` muestra como `[Compilado: …]` la salida de `04-adopciones.sh`, que el folio 259 dice que «nunca se reprodujo». Las marcas de `TEM-01:218`, `TEM-02:218` y `TEM-03:193,221` remiten a `evidencia/E1-U4b/` de LDD como ruta, sin URL ni SHA | Una marca de procedencia que afirma más de lo que hay; una cita que no se puede abrir desde el libro publicado | Enlace permanente al SHA de LDD donde está la evidencia (`bc1ebe6`, ancestro de `main` de LDD, medido) y rótulo «no reproducido» para `04-adopciones.sh` hasta U25 (P-12) |
| DS-12 | P1 | E1 (E10); E2 `CPA` §3.1; LD `AGENTS.md:54` | No hay delegación de merge para el expediente 0003 en ningún `CHANGELOG`. `AGENTS.md:54` manda usar «la delegación cuyo alcance incluye el PR» y `CPA` §3.1: «si el agente no la encuentra, rige el padre». En el pedido (`CH`) no hay frase del PO que nombre el merge | Si un agente fusiona por analogía con el 0002, fusiona sin delegación | P-09 |

## 4. Dictamen por pregunta

Cada pregunta, por separado y sin «depende» (`MEP` §2.2). Las alternativas son las de `PP` §7.

### P-01 — Relación entre el libro y los documentos fuente

**Posición: A (edición de lectura; manda la fuente; corrección doble en el mismo PR), con un control de correspondencia
por SHA.** El libro es una edición que reúne; los documentos fuente siguen siendo la fuente normativa y los únicos que
declaran IDs.

- **Fundamento.** (1) Unicidad: el libro no puede redeclarar IDs sin dar `id-duplicado` (`N2` E3; R-4), así que con B
  habría que mover 29 `doc_id` y 22 declaraciones al libro y re-apuntar todas las trazas. (2) La industria sostiene la
  fuente única y el enlace en lugar de la copia: GitLab hace de su documentación la fuente única y pide compartir el
  enlace «instead of rephrasing the information» (§8, fuente 3). El estándar DITA arma un libro como un *bookmap*, «references
  to topics organized as book content» (§8, fuente 4): el libro **referencia** temas, no los reemplaza. C sería la forma
  pura de esto, pero impide las seis intervenciones que pide `TP:58-67`; A es el compromiso.
- **Agregado necesario (para que A sea verificable):** DS-07 muestra que la compuerta no puede detectar que una fuente
  cambió después de la edición, porque las fuentes no tienen versión. Por eso el anexo de correspondencia del libro
  lleva, por capítulo, el `doc_id` fuente y el **SHA del commit de LD** sobre el que se editó. Comprobación sin tocar
  herramientas: `git diff --stat <sha>..HEAD -- <fuente>` vacío. El `traces` del libro apunta a los `doc_id` fuente
  sin versión (E4: verde).
- **Riesgo.** Deriva entre libro y fuente si la corrección doble se olvida. Lo acota la comprobación anterior y el
  prólogo que dice que manda la fuente.
- **Evidencia que la sostendría.** El PR del libro con `id-duplicado = 0` y el anexo de correspondencia con SHA; en el
  PR siguiente que toque una fuente, el `git diff --stat` mostrando qué capítulo quedó atrás.

### P-02 — `doc_id` del libro

**Posición nueva: `DOC-SDEI-LIBRO`, `doc_type: guia-de-estudio`, sin tocar archivos comunes.**

- **Fundamento.** Las dos variantes con prefijo `DOC` pasan las tres compuertas (E4: `DOC-SDEI-GUIA` y
  `DOC-SDEI-LIBRO`, verdes; `N2` E4 ya había medido `DOC-SDEI-LIBRO`). El **caso que funciona** (`MEP` §3.3) es el libro
  de FRAMEWORK MAUI, `FC-GUIA-LIBRO` (`Concepts/Framework-Concept/MAUI-Framework-Developer-Guide.md`, frontmatter): su
  último segmento dice qué es la pieza. Igualar esa columna da `…-LIBRO`. «GUIA» no distingue el libro de los otros
  documentos de la guía de estudio. `LIB` exigiría un prefijo nuevo en REG, que es archivo común (P-04), para una sola
  pieza. Su `doc_type: libro` no se copia: está fuera del vocabulario de `cuerpo.schema.json:10` (`N2` §4.1).
- **Riesgo.** `DOC` se define como «documento temático por tipo de documentación» (REG:11); el libro lo estira. Es
  reversible: hoy nadie traza al libro (lo pide P-01).
- **Evidencia.** El PR del libro en verde en PR-2, PR-3 y PR-5 con ese `doc_id`.

### P-04 — Qué entra en el PR común y cuándo

**Posición: C, ajustada.** Un PR común por repositorio, chico y anunciado a FRAMEWORK MAUI, con:

1. LD: REG:24 corregido a «patrón de ejemplo» (DS-03) y la fila `FC` en ESQ §5 (`N1-06`, verificado: REG:20 la
   tiene y ESQ:102-132 no).
2. LD y LDD: la fila de delegación del 0003 en `CHANGELOG.md`, si el PO la da (P-09).
3. Nada de `KNW` ni `LIB` (P-02 y P-22 no los necesitan).

Los cambios de DG (exclusión de carpetas, precedencia de versión, IDs locales, versión de IDs en sección, filas de
tabla como declaración de DS-02) van a **un expediente de herramienta propio**.

- **Fundamento.** Todo lo que entra en 1 y 2 es texto o dato que DG no interpreta (la descripción de REG no la usa
  ningún control: E9 muestra que el texto «pregunta de evaluación» sólo existe ahí). Lo de B cambia el comportamiento
  de una compuerta que comparten LD, LDD y FRAMEWORK MAUI; DS-02, DS-06 y `N4` §5 muestran que esas decisiones
  interactúan (qué declara un ID, de dónde sale su versión), y decidirlas por pieza en un PR de contenido es lo que
  produjo el «caso R». El dibujado de mermaid (A) es de `C-VER` (P-20).
- **Riesgo.** El expediente de herramienta se posterga y los huecos de DS-02 y DS-06 quedan; lo acota el texto de
  ESQ §5 (DS-02) y la regla de versión del conocimiento (DS-06), que no necesitan DG.
- **Evidencia.** Diff del PR común sin cambios en `dg.py`, `esquemas/` ni workflows; `ci-local.sh todo` verde.

### P-08 — Cuándo se archiva la guía obsoleta y en qué versión viaja el libro

**Posición: el libro viaja dentro de `2.0.0-borrador`; la guía se archiva en el corte de `2.0.0`, no en el PR del
libro. El PR del libro sí retira las remisiones a la guía.**

- **Fundamento.** SemVer: una pre-release «indicates that the version is unstable» y precede a la versión normal
  (§8, fuente 2). `2.0.0` nunca salió (sin etiqueta, DS-09), así que sumar el libro a la pre-release no rompe nada
  publicado, y la «versión siguiente» de `GV:27` es, por precedencia, `2.0.0`. Archivar en el PR del libro (alternativa
  de `N1` §8 punto 3) mezcla dos cambios con riesgos distintos: E5 muestra que archivar pone PR-5 en rojo por dos
  archivos de la raíz. El paso a `vigente` es de clase H (`SDEI/README.md:23`: «pasan a `vigente` cuando una persona
  los revisa»), y es el momento natural de cortar la versión.
- **Cómo se archiva** (DS-05): re-apuntar `README.md:11` y `Guides/README.md:11` a `IDX-SDEI`; borrar GV; la fila de
  `SDEI/README.md:124` pasa a citar el enlace permanente de GV al SHA del último commit que la contiene. Eso es el
  «archivo inmutable» de `GV:27` sin una copia que la compuerta tenga que seguir mirando.
- **Riesgo.** Los 33 avisos de `url-fecha` de GV siguen hasta el corte (`N1` §2). Es ruido, no rojo.
- **Evidencia.** El PR del libro con `git grep Sistema-Documentador-Tecnico-Guide -- SDEI/` limitado a la fila del
  README; el PR del corte con PR-5 verde sin GV.

### P-09 — Cómo se asienta la delegación del merge del 0003

**Posición: providencia en el expediente 0003 con el testimonio del PO (literal, fecha y huella) y fila en el
`CHANGELOG.md` de LD y LDD en el PR común. Hasta que esté, conformación manual. Si no hay testimonio, es una pregunta
de una línea al PO, no una escalada.**

- **Fundamento.** `CPA` §3.1: la delegación «la decide el responsable del producto y se asienta con fecha y con quién lo
  decidió en un lugar versionado del repositorio destino»; «si el agente no la encuentra, rige el padre». E10: no hay
  ninguna. El precedente del 0002 asentó también **el primer merge** por pedido explícito del PO (LD `CHANGELOG.md`,
  «Delegación del merge», fila «Alcance»). La delegación del 2026-09-14 que cita la carta habla de qué propuesta queda
  aprobada, no del merge. Ampliar la del 0002 cambia su alcance asentado, y eso también lo decide el PO. Pedir la
  frase que falta es un **obstáculo** (`CC` §3): la decisión de conformar automático está tomada por el plan; falta
  quién tiene la llave.
- **Riesgo.** Si el PO tarda, el primer PR común se fusiona a mano. Es reversible y no frena el contenido.
- **Evidencia.** El folio de providencia con la huella del testimonio y la fila del `CHANGELOG` citada en el informe de
  conformación de cada PR (`CPA` §5.3).

### P-10 — Cómo se citan los commits que la reescritura dejó fuera de `main`

**Posición: A. «PR #n, merge `<sha nuevo>`»: `080f158` → «PR #19, `e3841b6`»; `fe10086` → «PR #25, `6878568`».**

- **Fundamento.** E8: el merge equivalente es idéntico en todas las rutas que el cuerpo describe, así que la cita nueva
  dice lo mismo que la vieja y las salidas registradas siguen valiendo. «Sólo número de PR» no fija un estado: un PR
  apunta a una rama que se movió. La URL de `refs/pull` funciona hoy (E7: `200`), pero GitHub sólo describe esas vistas
  como restos que su soporte puede quitar (§8, fuente 5), y un clon nuevo no tiene esos commits (E7). GitHub recomienda
  el enlace al SHA porque el de rama «might not be the same when someone looks at it later» (§8, fuente 1).
- **Riesgo.** Los árboles no son idénticos (3 archivos ajenos difieren), así que «equivalente» se declara con su
  alcance: «mismo contenido en `tools/docs-guard`, `Guides/Documentacion-Tecnica`, `scripts` y `.github`».
- **Evidencia.** `git grep -n '080f158\|fe10086'` vacío en LD; el guion de `TEM-07` corrido en un clon nuevo.

### P-12 — Cómo se cierran U25 y U26

**Posición: B, ajustada. U26 (marcas a URL + SHA) va antes del libro; U25 (corrida nueva) va a los ensayos de la fase
4 y no bloquea el libro, salvo para `04-adopciones.sh`.**

- **Fundamento.** Lo que hacía falta U25 para el libro era que las salidas se pudieran sostener contra un SHA vivo.
  DS-01 y E8 lo resuelven sin correr nada: la salida de `080f158` es la de `e3841b6`. Las marcas pasan a enlace
  permanente de LDD al SHA donde está `evidencia/E1-U4b/` (`bc1ebe6`, ancestro de `main` de LDD, medido). La única
  salida que no tiene corrida original reproducida es `04-adopciones.sh` (EXP2/259:80-81): se rotula «no reproducido»
  en `TEM-03:193` y en el libro hasta que U25 la corra.
- **Riesgo.** Se pierde la comprobación de que los guiones siguen corriendo hoy. La recupera U25 en la fase 4.
- **Evidencia.** Las cinco marcas y las cuatro menciones de `256` §2 con URL que responde `200` y SHA ancestro de `main`.

### P-13 — Términos con dos o más sentidos

**Posición: las cuatro propuestas de `PP` §7.3, con dos precisiones.**

| Término | Sentido único | Precisión de esta comisión |
| --- | --- | --- |
| letra / intención / comportamiento | Lo que se promete / para qué / lo que el código hace (`N1-03`) | `TEM-01:283-284` dice «la letra (el código)»: se corrige ahí, no en la ficha |
| deriva / desfase | Deriva: contenido contra código. **Desfase del ancla**: SHA fijado contra `main` | «desfase», no «atraso» ni «deriva»: es la palabra del cuerpo en 12 de 16 usos (DS-10) |
| compuerta | Control, compuerta del carril PR, compuerta de escalón (`N1-11`) | — |
| PR-7 | «fijadas y referencias», nombrando `autoprueba` donde se cuentan los grupos (`N1-10`) | — |

- **Fundamento.** ISO/IEC/IEEE 29148:2018 pide requisitos sin ambigüedad (*unambiguous*) y ISO/IEC/IEEE 24765:2017 es el
  ejemplo de vocabulario controlado de la ingeniería de software: un término, una definición (normas citadas sin
  apartado). En el libro, el glosario es el capítulo de referencia; un término con dos sentidos ahí se replica en todas
  las partes.
- **Evidencia.** `grep` sin «letra (el código)» ni «deriva» en el sentido de SHA; glosario con las entradas nuevas.

### P-14 — Qué significa `PE`

**Posición: «patrón de ejemplo» en el registro; los pendientes de folios nuevos con `PEND-`; los `PE-n` de los folios
cerrados del 0002 no se reescriben.**

- **Fundamento.** E9: el sentido «pregunta de evaluación» no tiene ni un uso; «patrón de ejemplo» tiene 12 IDs
  definidos y citas en Marco, Mapa, README y anexos. Cambiar el registro es una línea de texto en un archivo que DG no
  interpreta en esa columna. Los `PE-1..14` del folio 290 de LDD están fuera de la compuerta y en un folio cerrado: se
  corrigen por corrigenda si hace falta (regla del expediente), no reescribiendo.
- **Riesgo.** Ninguno medido: ningún ID `PE-` traza hoy (DS-02).
- **Evidencia.** REG:24 = ESQ:117; `git grep -i 'pregunta de evaluaci'` vacío.

### P-22 — Prefijo y `doc_type` del conocimiento

**Posición: B. `ANX-SDEI-ESPECIFICACION`, `doc_type: anexo`, con `version` en el frontmatter igual a `**Versión:**`.
`KNW` y `doc_type: conocimiento` entran cuando LD tenga un segundo conocimiento.**

- **Fundamento.** B pasa la compuerta sin tocar archivos comunes (`N3` §3.4; E6). A agrega un prefijo y un valor al
  vocabulario cerrado para una sola pieza. La condición para revisarla es un hecho comprobable
  (`CC` §2, paso 4): un segundo archivo en `SDEI/Conocimientos/` u otra carpeta de conocimientos de LD. DS-06 agrega lo
  que ninguna de las dos alternativas decía: sin `version` igual a `**Versión:**`, el conocimiento no se puede trazar
  por versión.
- **Riesgo.** Renombrar el `doc_id` el día que llegue `KNW` cuesta re-apuntar las trazas que haya. Hoy son cero.
- **Evidencia.** El PR del conocimiento con PR-2 y PR-5 verdes y una traza `ANX-SDEI-ESPECIFICACION@1.0` que resuelve.

## 5. Cadena de consecuencias de las recomendaciones

`CC` §2, los cuatro pasos, para las preguntas donde la recomendación elige entre opciones con costo distinto.

| Decisión | 1. ¿Dónde cae el costo? | 2. ¿Cuánto pesa? | 3. ¿Qué pierde la alternativa? | 4. ¿Es reversible? |
| --- | --- | --- | --- | --- |
| P-01 A frente a B | En la disciplina de corrección doble del editor | Un `git diff --stat` por PR que toque fuentes | B: re-declarar 29 `doc_id` y 22 IDs y re-apuntar trazas (`N2` E6); C: pierde las seis intervenciones | A sí: el libro se puede regenerar o promover después |
| P-02 `…-LIBRO` frente a `LIB` | En la semántica estirada de `DOC` | 0 archivos comunes (E4) | `LIB`: un PR común para un prefijo de una pieza | Sí; 0 trazas al libro hoy |
| P-04 C frente a B | En los huecos DS-02 y DS-06, que esperan | Dos reglas de texto los cubren mientras tanto | B: decisiones de compuerta que interactúan, tomadas por pieza | Sí |
| P-08 archivar al corte | En 33 avisos por corrida hasta `2.0.0` | Medido: 33 (`N1` §2) | Archivar con el libro: PR-5 rojo si se olvidan dos trazas (E5) | Sí |
| P-09 testimonio antes que analogía | En el primer merge, manual | Un merge | Analogía con el 0002: fusionar sin delegación, contra `CPA` §3.1 | Manual sí; un merge sin delegación alcanza a quien clonó |
| P-12 U26 antes, U25 después | En la comprobación de que los guiones corren hoy | Un guion sin reproducir (`04-adopciones.sh`) | U25 antes: bloquea el libro por una corrida que E8 vuelve innecesaria para la cita | Sí |
| P-22 B frente a A | En renombrar el `doc_id` si llega `KNW` | 0 trazas hoy | A: PR común para una pieza | Sí; condición: segundo conocimiento en LD |

## 6. Lo que revisé y está bien

1. **Unicidad en el cuerpo.** 51 IDs declarados, `id-duplicado` en 0 (E1), y el libro con cualquiera de los dos `doc_id`
   `DOC-SDEI-*` no agrega duplicados (E4).
2. **Las salidas registradas sobre `080f158` y `fe10086` siguen siendo verdaderas** contra sus merges equivalentes: el
   contenido de la herramienta y del cuerpo es idéntico (E8). El defecto es la cita, no el dato.
3. **La regla «manda el archivo»** (`ESQ:199-200`) está bien pensada: da una fuente única para el registro. Lo que
   falla es el dato del archivo en `PE` (DS-03), no la regla.

## 7. Solicitudes de convocatoria

| Señal | Ubicación | A quién |
| --- | --- | --- |
| El carril semanal escribe «no está en ningún repo del árbol» ante un SHA muerto en lugar de dar rojo o aviso | `tools/docs-guard/semanal.sh:97-105`; DS-08 | `C-VER` (la CI como ejecución) |
| Las nueve trazas de la prueba de ayuda por rol dan «no verificable» (E1 de `N1` §2, repetido en mis corridas: `avisos=9`) | `Examples/Prueba-Ayuda-Por-Rol/Web/Ayuda/es/**` | `C-DOC-USR` (frontera K4: no toca prefijos) |

## 8. Fuentes externas

Consultadas el 2026-11-01. Ninguna se cita con apartado que no se haya abierto.

| # | Fuente | Qué sostiene |
| --- | --- | --- |
| 1 | GitHub Docs, *Getting permanent links to files*, https://docs.github.com/en/repositories/working-with-files/using-files/getting-permanent-links-to-files | «This will permanently link to the exact version of the file in that commit»; el enlace de rama puede cambiar. P-08, P-10, P-12 |
| 2 | *Semantic Versioning 2.0.0*, https://semver.org/ | Ítem 3: una versión publicada «MUST NOT be modified»; ítem 9: la pre-release «indicates that the version is unstable» y tiene menor precedencia que la normal. P-08, DS-09 |
| 3 | GitLab, *Documentation Style Guide*, https://docs.gitlab.com/development/documentation/styleguide/ (fuente de `N6:117`, reabierta) | La documentación es la fuente única (SSoT); compartir «the link to the documentation instead of rephrasing the information». P-01 |
| 4 | OASIS, *DITA Version 1.3*, elemento `bookmap`, https://docs.oasis-open.org/dita/dita/v1.3/os/part3-all-inclusive/langRef/technicalContent/bookmap.html | «Bookmaps consist of references to topics organized as book content». P-01 |
| 5 | GitHub Docs, *Removing sensitive data from a repository*, https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/removing-sensitive-data-from-a-repository | Tras reescribir la historia, los commits viejos siguen accesibles por «cached views» y PR que los referencian, que el soporte puede quitar; `refs/pull/` es de sólo lectura. P-10 |
| 6 | ISO/IEC/IEEE 29148:2018, *Requirements engineering* (norma, sin apartado) | Característica *unambiguous* y trazabilidad de requisitos. P-13 |
| 7 | ISO/IEC/IEEE 24765:2017, *Vocabulary* (norma, sin apartado) | Vocabulario controlado de la ingeniería de sistemas y software. P-13 |

Contraste con `N6` como hipótesis: `N6` no trae fuentes sobre identificadores, enlaces permanentes ni versionado de
pre-release; las 1, 2, 4 y 5 son de esta comisión. La 3 confirma la de `N6:117`.

## 9. Excepciones a conocimientos

Ninguna. Las posiciones cumplen `CPA` §3.1 (P-09) y la forma de la base (P-22, con la regla de versión de DS-06).

## 10. Lo no verificado e incidencias

- **Los siete enlaces a GV** se tomaron de `N1` §3 y se confirmaron con `git grep -n Sistema-Documentador-Tecnico-Guide`
  (nueve líneas, dos en `CHANGELOG.md`); no se corrió lychee sin GV.
- **El conteo de E2** cuenta menciones, no IDs distintos, e incluye ejemplos deliberados dentro de bloques de código
  (`ESC-1`, `TEM-99`, `DEMO-MU-22`); las cifras por familia de §2 son las que importan.
- **`AK-2` y `AK-6`** (`N1-08`) no se reabrieron: siguen como C.
- **El carril semanal** se leyó, no se corrió (DS-08 es E2 sobre `semanal.sh:97-105` más E7).
- **`VER-E06`** no existe y `git log -S 'VER-E06'` no da historia: es un hueco de numeración, no un ID perdido. No se
  emitió como hallazgo.
- **Mensajes de otra sesión**: no llegó ninguno a mitad de turno ni texto que cambiara el encargo.
- **Incidencia**: se clonó LD por HTTPS en `{dir-de-trabajo}` para E7 y se borró al terminar. No hubo escritura en
  ningún repositorio.

Sigue: refutación (`C-REF`) · análisis de decisiones (`R-DECISIONES`) · jurado de veredicto
