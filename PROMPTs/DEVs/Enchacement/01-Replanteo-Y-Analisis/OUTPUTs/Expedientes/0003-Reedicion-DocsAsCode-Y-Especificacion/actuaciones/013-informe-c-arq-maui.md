---
doc_id: EXP0003-F013
doc_type: informe
title: Informe de la comisión C-ARQ-MAUI — la demo (web, API y móvil) y la topología multirrepo frente al sistema real, y su utilidad para un proyecto MAUI .NET
status: vigente
origin: agent
confidence: alta en lo medido (corrida completa de verificar.sh, contraste con el código en el SHA fijado, API pública de GitHub, compilación y arranque de la prueba de ayuda por rol); media en las posiciones, rotuladas «criterio propio» donde no las sostiene una fuente
owner: comisión C-ARQ-MAUI (silla variable «Arquitectura», arquitecto de apps móviles MAUI .NET) de la mesa de la reedición DocsAsCode
last_review: 2026-11-01
audience: [presidencia, refutador, análisis de decisiones, jurado de veredicto, PO]
traces: [EXP0003-F001, EXP0003-F004, DB-R02-02, P-06, P-11, P-16, P-18, P-21, P-26, P-27, P-28]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-01 |
| Autor | Comisión C-ARQ-MAUI, a ciegas: no leyó ningún informe de otra comisión (`mesa/01x-*`) |
| Corrige | — |

| Cabecera de comisión | Valor |
| --- | --- |
| Rol | Arquitectura (variable): ¿lo que el cuerpo, el libro y el conocimiento dicen de la demo (web, API y móvil) y de la topología multirrepo corresponde al sistema real y sirve para un proyecto MAUI .NET nuevo o existente? (folio 004, fila `C-ARQ-MAUI`) |
| Preguntas a cargo | P-06, P-11, P-16, P-18, P-21, P-26, P-27, P-28 |
| No-competencia | Forma editorial, citación y umbrales; el diseño de los servicios (lectura L-3) |
| Norma | `KB-privada/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Líneas 1–111 (cabecera y §0, con el «Mapa de carga»); §2.2 (con su subsección); §3.2; §3.3; §3.4; §4; §5.2 |
| Otros documentos cargados | `Cadena-De-Consecuencias` 2.0 §2 y §3; `Mesa-Consulta-A-Un-Tercero` 2.0 §0 y §1 (no hay tercero: no rige) |
| Insumos leídos | Contrato de entrada (`DB-R02-02`, entero); folio 001 §9; folio 004 (tabla del panel y §8); núcleo N3 §5.6; núcleo N4 §3–§9; núcleo N1, fila N1-24; `01-Cohesion-Global.md`, filas C-04 a C-08; folios 010 (forma), 001 §D1 y 290 §10 del expediente 0002. El cuerpo SDEI se leyó **directamente** en el worktree de LD (`0bed863`). `Nucleo-N5-privado.md` no hizo falta y no se transcribe nada de él |
| Medios propios | Lectura con `git`, `grep` y `sed`; API pública de GitHub; `verificar.sh` de la mini demo corrido entero; compilación y arranque de la prueba de ayuda por rol en una copia; tres consultas web (§6) |

**Convención de citas.** `SDEI/` = `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/` de
Lab-Documentos en `0bed863`. `DEMO/` = `SDEI/Examples/MovilidadUrbana-Mini-Demo/`. `LE@8fb4c3a` = Lab-E2E.WebBlazor en
el SHA de `DEMO/source.lock:5`. `LG` = Lab-Geometria, `LGD` = Lab-Geometria.Documentacion. Las carpetas de trabajo se
nombran `{dir-de-trabajo}`. Lo que es opinión de esta comisión lleva **[criterio propio]**.

## Índice

1. [Definiciones y forma de este informe](#1-definiciones-y-forma-de-este-informe)
2. [Lo que el objetivo da por fijo, mirado desde Arquitectura](#2-lo-que-el-objetivo-da-por-fijo-mirado-desde-arquitectura)
3. [Hallazgos](#3-hallazgos)
4. [Dictamen por pregunta](#4-dictamen-por-pregunta)
5. [Ensayos corridos](#5-ensayos-corridos)
6. [Fuentes externas](#6-fuentes-externas)
7. [Lo que revisé y está bien](#7-lo-que-revisé-y-está-bien)
8. [Solicitudes de convocatoria](#8-solicitudes-de-convocatoria)
9. [Excepciones a conocimientos](#9-excepciones-a-conocimientos)
10. [Lo no verificado](#10-lo-no-verificado)
11. [Inventario de lo creado y lo borrado](#11-inventario-de-lo-creado-y-lo-borrado)
12. [Barrido de lo privado de este folio](#12-barrido-de-lo-privado-de-este-folio)

---

## 1. Definiciones y forma de este informe

| Término | Definición en este informe | Fuente |
| --- | --- | --- |
| **Sistema real** | El código y los repositorios tal como están en el SHA que el cuerpo cita, medidos con comando | Criterio propio |
| **App MAUI** | Proyecto .NET con `<UseMaui>true</UseMaui>` y uno o más destinos de plataforma (`net10.0-android`, `-ios`, `-maccatalyst`, `-windows`) | `LE@8fb4c3a:src/MovilidadUrbana.MAUI/MovilidadUrbana.MAUI.csproj:9,12`; MS Learn (§6, F2) |
| **Letra de plataforma** | Texto que la persona usuaria ve y que no vive en C# ni en XAML: `.resx`, `Strings.xml` de Android, `InfoPlist.strings` de iOS, `.resw` de Windows | MS Learn, «Localization» (§6, F3) |
| **Descripción, control o decisión** | El filtro de `MEP` §3.3: una descripción se corrige contra el producto; un control no ejercido va a deuda declarada; una decisión de diseño no se corrige en el documento | `MEP` §3.3 |

**Lectura P0–P3**: la del folio 001 §9, sin cambios. En este informe, P1 es además «un arquitecto MAUI que lee el cuerpo
infiere una arquitectura distinta de la real».

**Ejemplo de la forma.** «Una app MAUI con una API web» (`SDEI/00-Marco.md:83`) es una **descripción**: se contrasta con
`LE@8fb4c3a` (§5, E2) y se corrige si no coincide. «Build con avisos como error» (`SDEI/01-Mapa.md:84`) es un **control**:
si el ejemplo no lo ejerce, no se reescribe, va a deuda declarada.

## 2. Lo que el objetivo da por fijo, mirado desde Arquitectura

La carta manda que lo que el objetivo da por fijo sin origen sea el primer hallazgo. Desde esta silla:

| Lo dado por fijo | Origen | Lectura |
| --- | --- | --- |
| Que los casos de prueba de efectividad son Geometría y el servicio privado | Pedido, E-04 (prompt :20) | Con origen. **No** incluye la app MAUI de la mini demo |
| Que el conocimiento sirva «para un proyecto MAUI .NET» | Pregunta de la silla (folio 004); el pedido nombra arquitectos MAUI (E-16, prompt :73) y «proyectos nuevos o existentes» (E-03, prompt :18), pero no pide probarlo sobre un MAUI | Correr el caso C3 (app MAUI) como obligatorio es un **agregado** de esta silla; sale marcado (H11, P-26) |
| Que la mini demo describe «la app» | `DEMO/README.md:17` | Es una de **tres** apps; la demo fija sólo `ApiWeb` y `MAUI` (`DEMO/source.lock:7`). La web queda fuera y no se dice en el Marco (H01) |

## 3. Hallazgos

Tope: 12. Ancla según `Escalas-De-Juicio` §3.3.

| Id | Nivel | Ancla con cita | Hallazgo | Impacto si no se corrige | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| H01 | P1 | E1: `SDEI/00-Marco.md:83` («una app MAUI con una API web») frente a E2 de §5: tres apps con capas propias; la app MAUI no tiene `HttpClient` ni `BaseAddress` (`git grep` vacío) y apunta sólo a `net10.0-android` (`MovilidadUrbana.MAUI.csproj:9`); usa SQLite local (`MovilidadUrbana.MAUI.csproj:36`) | El Marco describe el ejemplo conductor como cliente-servidor. El sistema real son tres aplicaciones independientes, y la móvil no consume la API. `DEMO/docs/tecnica/arquitectura.md:26-29` lo dice bien; el Marco no | Un arquitecto MAUI lee que el contrato REST (CL-05) es el contrato de su app y diseña la traza móvil→API, que el ejemplo no tiene | Descripción: corregir `00-Marco.md:83` con lo que dice `arquitectura.md` §1 y declarar que la demo fija dos de las tres apps |
| H02 | P1 | E1: `SDEI/00-Marco.md:105`, columna `ESC-SDEI-2` «CL-02 a CL-07, CL-12»; E2 de §5: no hay `AGENTS.md` en Lab-E2E.WebBlazor ni en su `.Documentacion` (`git ls-tree -r` sin coincidencias); sí hay `ia-db/` en el hermano (`ia-db/README.md` y 13 índices) y `CHANGELOG.md` en los dos | La fila prescribe CL-03, que el ejemplo no tiene, y omite CL-08 y CL-13, que el ejemplo sí tiene | La fila sirve de oráculo para el ensayo (N3 §5.6, C3): un oráculo con tres celdas mal da coincidencias falsas | Separar en la tabla «clases que el escenario pide» de «clases presentes en el ejemplo, medido en `SHA`»; sumar CL-08 y CL-13 a `ESC-SDEI-2` (P-16) |
| H03 | P1 | E1: `SDEI/01-Mapa.md:84` (CL-04, control «Build con avisos como error») y `SDEI/00-Marco.md:107` («OpenAPI y comentarios XML» para `ESC-SDEI-2`); `git grep GenerateDocumentationFile\|TreatWarningsAsErrors` en `LE@8fb4c3a` → sólo `ApiWeb.csproj:10`, ninguno con avisos como error | La mitad XML existe sólo en la API; en la app MAUI no. El control de CL-04 no lo ejerce ningún proyecto del ejemplo | Lo mismo que N4 H4 mide en Geometría se repite en el ejemplo MAUI: el patrón no es de un caso | Control no ejercido: **no** reescribir el Mapa; asentarlo como deuda declarada y rotular la celda de `ESC-SDEI-2` «XML: sólo API» |
| H04 | P1 | E1: `SDEI/TEM-07-Marco-SDD.md:171-172` («Ninguna de las dos existe todavía») frente a IA.SDD en `bac7e48` —el mismo SHA que cita `TEM-07:165`—: `Conocimiento/Knowledge-Logica-De-Decision.md` 1.0 con §3.9 «Cada decisión es una lección» y §5.3 «Lección», y `Master-Prompt.md:1025` y `Mesa-Rules.md:570`, que mandan correr su §2 «antes de detener» | La capa A existe como copia en IA.SDD y una forma de la capa B existe en la norma de su orquestador. En Lab-Geometria no hay copia; hay una aplicación citada por nombre (`LG` `5f07b12`, `ADR-10010…md:8,61`) | El libro afirma algo falso sobre un repositorio público que él mismo cita en el mismo SHA | Descripción: reescribir con lo medido (P-21). Las diferencias de campos entre la capa A del diseño y la lección de §5.3 se dicen, no se ocultan |
| H05 | P1 | E1: `SDEI/00-Marco.md:129-131` y `:183-184`, `SDEI/99-Anexos/Ejercicios.md:114-118`, `SDEI/01-Mapa.md:70`; frente a `tools/docs-guard/semanal.sh:14` («atraso: cada base_commit (y el sha de cada source.lock) contra main») y `.github/workflows/mini-demo-movilidad.yml:17-23` (A1 sólo en `pull_request` con `paths` y `workflow_dispatch`) | El cuerpo promete que un aviso programado detecta que **el símbolo** que cita la ficha cambió. El carril semanal cuenta commits de atraso; la deriva por símbolo (A1) corre sólo cuando un PR toca la demo o a mano | Una persona que adopta el sistema en un MAUI cree que un renombre de método en la app le llega solo, y no le llega | Es un **control** declarado y no ejercido: o se programa A1 (clase H, workflow) o se declara la deuda; reescribir el texto sin más lo absuelve (P-18) |
| H06 | P1 | E1: `SDEI/99-Anexos/Como-Decidir.md:82` (F1 excluye lo que «no corre en el runner que fija el caso», con la etiqueta literal), `SDEI/99-Anexos/Lista-De-Verificacion.md:154` (`VER-W09`, «etiqueta exacta»); E1 de §5, E3: la corrida `41327937941` de `docs-guard` corrió en un runner con otro nombre de host que la etiqueta | La etiqueta del laboratorio está escrita como filtro y como verificación para cualquier caso. Ya no nombra la máquina que corre los trabajos. Un MAUI que compila iOS o Mac Catalyst necesita un Mac (F2), así que una sola etiqueta no le alcanza | Un proyecto MAUI que aplique el filtro F1 tal cual descarta toda alternativa que compile iOS, o lo cumple de nombre con una etiqueta que no describe su máquina | Parámetro del caso en el conocimiento (`runs-on` por plataforma); el valor del laboratorio, como ejemplo. Renombrar es otra decisión (P-11) |
| H07 | P2 | E1: `DEMO/README.md:194-197` (gramática del ancla: `.cs` y `.xaml`) y `tools/docs-guard/dg.py:608` (todo lo que no es `.xaml` se lee como C#); F3: en MAUI la letra localizada vive en `.resx`, `Platforms/Android/Resources/values-*/Strings.xml` e `InfoPlist.strings` | La compuerta no puede anclar la letra de una app MAUI localizada ni la de plataforma. El límite no está declarado en §8 de la demo | Un MAUI con localización escribe fichas cuyas filas `muestra` no se pueden comprobar, o las ancla al `.Designer.cs` generado | Declarar el límite en `DEMO/README.md` §8 y en el conocimiento; extender `dg.py` es herramienta (clase H, P-04) |
| H08 | P2 | E1: `grep -rl` sobre los `.md` de `SDEI/` (sin la guía obsoleta): 0 menciones de iOS, Android, `Platforms/`, `net10.0-android`, APK, AAB o `.ipa` (§5, E7); `SDEI/01-Mapa.md:76-77` (catálogo cerrado) | El catálogo de catorce clases no ubica los textos de distribución de una app móvil (notas de versión por tienda, textos de permisos de plataforma) ni la ayuda empaquetada en la app | Quien aplica el conocimiento a un MAUI tiene que abrir clases nuevas por expediente para lo primero que va a documentar, o las mete por analogía sin decirlo | En el conocimiento, una lista de parámetros por stack que incluya «plataformas destino y su runner» y una nota que ubique los textos de plataforma (CL-06 o clase nueva por expediente). **[criterio propio]** |
| H09 | P1 | E1: `SDEI/Examples/Lanzar-Example.md:18,35` (ruta absoluta del espacio de trabajo), `:51,59` (`@devcontainers/cli@latest`), `:92` (`cloudflared:latest`), `:101` (túneles `jump-host-tunnel-*` del usuario), `:140` (`Rule-Evidences.md`: `git ls-files` en LD → nada); `SDEI/01-Mapa.md:89` (CL-09: los prompts van al hermano) | Es un tool-prompt de un entorno concreto, con versiones móviles y una referencia que no resuelve. Lo medido: compila y arranca en `Production` con 9 páginas (§5, E4) | Si entra íntegro al libro, el libro hereda rutas del entorno y un procedimiento que publica la app por un túnel abierto, sin versiones fijas, contra la práctica que el propio cuerpo aplica a las actions (F4) | P-06: al libro, el procedimiento genérico; el tool-prompt, al hermano |
| H10 | P1 | E1: §5, E6: `LGD` `main` (`0202722`) indexa `LG` `89f3ab3`, 209 commits detrás de `5f07b12`; el PR #3 (`b47d22b`) indexa `4b114d7`, 5 commits detrás; el clon local tiene otra 4.0 sin commitear (33 entradas en `git status`) | Hay tres índices posibles para el mismo caso | Dos corridas ciegas con insumos distintos miden insumos, no el conocimiento | P-26: un par fijo y versionado, código e índice del mismo SHA |
| H11 | P1 | E1: N3 §5.6, tabla de casos, fila «C3 opcional — App sin roles»; §5, E1: la demo se verifica entera en 21 s y el código pesa 103 archivos | El único caso MAUI de la prueba de reproducción es opcional | La pregunta de esta silla («¿sirve para un MAUI?») queda sin medida, aunque es el caso más barato | Correr C3 como caso obligatorio, marcado como agregado de esta silla (§2); oráculo escrito antes y fuera de la fila del Marco (H02) |
| H12 | P3 | E1: `DEMO/README.md:114` frente a la salida de C4 (§5, E1): `:62` es `ancla-no-contiene` y `:63` es `ancla-valor-distinto` | El ejemplo de mensaje rojo no coincide con lo que da la compuerta | Quien busca el mensaje lo encuentra en otra línea | Copiar la línea real (`:63`) |

## 4. Dictamen por pregunta

Cada respuesta sale de `Cadena-De-Consecuencias` §2: dónde cae, cuánto pesa, qué pierde la alternativa y si es reversible.

### P-06 — ¿Cómo entra `Lanzar-Example`?

**Posición.** Ninguna de las dos alternativas tal cual. **Una nueva, C**: el libro lleva el **procedimiento genérico**
(devcontainer → compilar → lanzar desacoplado → verificar por URL → bajar), con versiones fijadas y sin datos del
entorno, y remite al ejemplo; el tool-prompt operativo (invocación, túnel, `--estado`, `--bajar`) se mueve al hermano
LDD, donde el Mapa ubica los prompts (`01-Mapa.md:89`), y se corrige `Rule-Evidences.md` por la regla que exista o se
quita.

| Paso de la cadena | A. Íntegro en 14.3 | B. Reescrito o movido a LDD | C. Procedimiento en el libro, tool-prompt en LDD |
| --- | --- | --- | --- |
| ¿Dónde cae? | En el lector del libro, que hereda rutas del entorno, `latest` y un túnel abierto (H09) | B reescrito: igual que C en el libro; B movido: el libro pierde el único ejemplo «levantar y mirar» | En dos archivos que hay que mantener de acuerdo |
| ¿Cuánto pesa? | 7 líneas con defecto (`:18,35,51,59,92,101,140`) | — | El procedimiento son los pasos 1-3 y 5-6: lo medido en E4 los reproduce |
| ¿Qué pierde? | Nada de contenido; pierde que el libro sea autocontenido sin entorno | El túnel como ejemplo de publicación | El tono «tool-prompt» dentro del libro |
| ¿Reversible? | Sí, pero un libro publicado con rutas del entorno ya circuló | Sí | Sí |

**Fundamento.** El cuerpo fija sus actions por SHA (`mini-demo-movilidad.yml`, cabecera: «actions fijadas por SHA»), que
es la práctica de GitHub (F4); un procedimiento con `latest` contradice esa práctica en el mismo libro. **Riesgo**: que
el procedimiento del libro y el prompt de LDD diverjan; mitigación: el libro cita el prompt por ruta y SHA.
**Evidencia que lo sostendría**: una corrida del procedimiento del libro, sin el prompt, en un contenedor limpio, con
la salida «9 páginas, 0 fallas» y `200` en `/ingresar` (E4 ya lo da para los pasos 2-3).

### P-11 — ¿Qué se hace con la etiqueta de runner?

**Posición.** **B + A, sin renombrar ahora.** En el conocimiento, `runs-on` es un **parámetro del caso, por
plataforma** (Linux para docs y API; Mac para iOS y Mac Catalyst); el valor del laboratorio va como ejemplo. En el
Marco, una nota: la etiqueta es histórica y hoy la sirve otra máquina (`00-Marco.md:52` ya dice «no una dirección»).
F1 y `VER-W09` dejan de llevar el literal y dicen «la etiqueta que fija el caso».

| Paso | A. Nota | B. Parámetro | C. Renombrar en LD, LDD, LG y el runner |
| --- | --- | --- | --- |
| ¿Dónde cae? | En el lector del Marco | En el conocimiento y en dos anexos (F1, `VER-W09`) | En tres repositorios de workflows y en la configuración del runner |
| ¿Cuánto pesa? | Una línea | Tres líneas | `grep runs-on`: 4 workflows en LD con 7 ocurrencias, más `e2e.yml:89` en Lab-E2E y los de LG; un runner a reetiquetar |
| ¿Qué pierde? | Sola, deja F1 inaplicable a un MAUI (H06) | Nada medido | Durante el cambio, los trabajos quedan en cola sin runner que los tome; GitHub avisa que al reemplazar un runner hay que reasignar las etiquetas (F1) |
| ¿Reversible? | Sí | Sí | Sí, pero toca archivos comunes con FRAMEWORK MAUI (`framework-concept-demo.yml`): clase H |

**Fundamento.** GitHub describe las etiquetas como características del runner, no como nombre de máquina (F1). Un
MAUI que compila iOS necesita un Mac (F2): un parámetro único no alcanza. **Riesgo**: que la nota envejezca otra vez;
mitigación: el conocimiento no fija el valor. **Evidencia**: la API de jobs (E3) muestra el nombre real del runner
detrás de la etiqueta; volver a consultarla al cerrar.

### P-16 — ¿Qué clases activa cada escenario?

**Posición.** Desde esta silla respondo **`ESC-SDEI-2`** y la forma de la tabla; `ESC-SDEI-1`, `-3` y `-4` las dejo a
quienes las miden. **Sumar CL-08 y CL-13 a `ESC-SDEI-2`**, y **rotular CL-03 y la mitad XML de CL-04 como «no presentes
en el ejemplo»** (H02, H03). Para la forma: la tabla separa **lo que el escenario pide** de **lo que el ejemplo tiene,
medido en su SHA**. Esto sirve también a la alternativa «escenarios compuestos»: un escenario compuesto suma columnas
pedidas; lo presente se mide igual.

**Cadena.** Cae en la fila `00-Marco.md:105` y en el oráculo de C3. Pesa una celda y una fila nueva. La alternativa
(dejar la fila como está) pierde la validez de la fila como oráculo (C-04 del documento de cohesión ya lo vio para
Geometría; H02 lo muestra para el MAUI). Reversible.

**Fuente externa.** Ninguna norma fija qué clases activa un escenario; es diseño del cuerpo **[criterio propio]**.
**Riesgo**: duplicar la tabla. **Evidencia**: `git ls-tree` de cada repositorio del ejemplo, en su SHA, contra cada
celda (E2 lo hace para `ESC-SDEI-2`).

### P-18 — ¿Qué dice el cuerpo del aviso programado?

**Posición.** **Reescribir lo que el carril hace hoy y declarar como deuda lo que no hace.** El texto dice: el carril
semanal avisa cuántos commits atrás quedó el SHA de `source.lock` y de cada `base_commit`; la deriva por símbolo (A1)
la mide `mini-demo-movilidad` cuando corre (PR que toca la demo o a mano). La deuda: «A1 no está programado», con su
evento de cierre: el PR común que lo programe o la decisión de no hacerlo.

**Por qué no sólo reescribir.** El filtro «descripción o control» (`MEP` §3.3): «avisa cuando el símbolo cambió» es un
control que el sistema no ejerce. Reescribirlo sin más lo absuelve sin que nadie vote la derogación.

**Cadena.** Programar A1 cae en un workflow común (clase H) y pesa una corrida de 21 s por semana (E1). No programarlo
pierde el aviso para quien documenta desde otro repositorio, que es justo el `CTX-SDEI-3`. Las dos son reversibles: se
toma la reescritura con deuda ahora y se anota la condición para revisarla (que el PR común se abra).

**Para un MAUI.** Es el caso típico: la app vive en su repositorio y la documentación en otro. Sin A1 programado, un
renombre en `LocalidadRules` no avisa a nadie hasta el próximo PR de la demo. **Evidencia**: la próxima corrida
programada del carril (el lunes 2026-11-02; hoy no hay ninguna corrida `schedule` registrada, E3) mostrará sólo la
tabla de atraso.

### P-21 — ¿Qué se hace con «las capas A y B no existen» en `TEM-07`?

**Posición.** **Verificado: existen en IA.SDD; se reescribe.** En `bac7e48`, el mismo SHA que `TEM-07:165` cita, IA.SDD
tiene `Conocimiento/Knowledge-Logica-De-Decision.md` 1.0, cuya §3.9 manda registrar cada decisión como lección y cuya
§5.3 da su forma; y `Master-Prompt.md:1025` y `Mesa-Rules.md:570` mandan correr su §2 antes de detenerse. El texto
nuevo dice: la capa A existe como ese conocimiento en IA.SDD (copia de la base común); una forma de la capa B existe en
la norma del orquestador de IA.SDD; en Lab-Geometria no hay copia, sólo una aplicación citada (`ADR-10010`, l. 8 y 61).
Y dice la diferencia: la lección de §5.3 registra pregunta, análisis, salida y regla; no tiene los campos «evidencia» ni
«resultado» que `TEM-07:176` pide a la capa A.

**Cadena.** Cae en un párrafo de `TEM-07`. La alternativa «dejar» mantiene una afirmación falsa sobre un repositorio
público. Reversible. **Es una descripción** (`MEP` §3.3), no una decisión: el diseño de las capas está rotulado
«borrador» (`TEM-07:171`), no es un ADR aceptado.

**Riesgo.** Que el cuerpo cite la base común, que es privada: se cita la copia pública de IA.SDD por SHA, como ya hace
`TEM-07:165`. **Evidencia**: `git show bac7e48:<ruta> | grep -n` de las tres líneas (E5).

### P-26 — ¿Qué oráculo y qué insumos tiene cada caso?

**Posición.**

1. **Oráculo**: ni la columna del Marco (C-04; H02 y H03 la muestran mal también para el MAUI) ni un núcleo escrito
   por quien diseñó el conocimiento. Un **agente distinto** lo escribe desde el repositorio del caso en su SHA, con
   ruta:línea por decisión y su `sha256sum` antes de la corrida (el paso 1 de N3 §5.6, sin cambios). N4 §4 y la hoja
   de integración privada sirven de **borrador** de ese oráculo, no de oráculo.
2. **Insumos de Geometría**: un **par coherente y versionado**: `LG` en `4b114d7` (etiqueta `v1.2.0`) y `LGD` en
   `b47d22b` (cabeza del PR #3, alcanzable por `refs/pull/3/head`), porque esa ia-db indexa exactamente `4b114d7`
   (E6). Se descartan: la ia-db de `main` (209 commits de atraso) y la 4.0 local sin commitear (no reproducible).
3. **Insumos comunes**: el conocimiento en un SHA, el repositorio del caso en su SHA y la plantilla vacía (N3). El
   README de la ia-db entra porque es el punto de entrada del caso (N4), no como pista.
4. **Caso C3 (MAUI) obligatorio**, marcado como agregado de esta silla (§2): `LE@8fb4c3a`, con la demo como **no**
   insumo (es la respuesta).

**Cadena.** El par fijo cae en la carta del aplicador y pesa dos SHA. Usar la ia-db local pierde reproducibilidad;
usar `main` mide un índice viejo. C3 pesa una corrida más; omitirlo deja la pregunta de la silla sin medida. Todo
reversible. **Fuente**: la regla de «pesos fijados antes» del propio cuerpo (`Como-Decidir.md:74-76`, citada por N3)
**[sin fuente externa: diseño del ensayo]**. **Riesgo**: que el PR #3 se cierre sin fusionar y el `refs/pull` deje de
servirse; mitigación: copiar el índice al almacén de evidencia con su huella. **Evidencia**: dos corridas con el mismo
par dan las mismas decisiones salvo lo ambiguo del conocimiento.

### P-27 — ¿Dónde viven los ensayos?

**Posición.** **Geometría: rama descartable en un worktree propio de `LGD`, sin PR y sin merge**; lo que el expediente
retoma es el folio con cifras, comando y huella. **Servicio privado: sólo en la carpeta privada de la mesa**, sin PR a
su repositorio; al expediente público va el resultado con alias.

**Cadena.** Un PR en `LGD` cae en un repositorio con dos PR abiertos (#2 de arranque, cuyo merge vuelve al PO, y #3
con otra ia-db; E6) y pesa coordinación con otra sesión. Un PR en el repositorio privado cae fuera del alcance (lectura
L-3: «cambios en los productos son otro pedido») y cuesta un primer merge que vuelve al PO. La rama descartable pierde
que el ensayo quede a la vista de quien no está en la mesa; la norma ya lo resuelve: «la evidencia cruda queda local» y
se versiona el folio con su huella (`MEP` §3.2). Todo reversible. **Riesgo**: perder la evidencia local antes del
cierre; mitigación: huella en el folio y copia en el respaldo del host. **Evidencia**: el folio del ensayo cita la rama,
su SHA y la huella de la carpeta.

### P-28 — ¿El ensayo en Geometría es la primera mitad del escalón 2?

**Posición.** **No; es insumo del escalón 2, no su mitad.** Se llama «escalón 2», no «G2» (N4 §9).

**Fundamento.** El escalón 2 es «una piloto sobre Lab-Geometria, el primer proyecto con SDD que adopta la compuerta en su
propia CI» (`TEM-07:24-26`) y vive en el expediente 0002, con su compuerta de dictamen (0002, folio 001, D1). El
ensayo del 0003 mide **reproducibilidad del conocimiento** en una rama descartable (P-27). Tienen salidas distintas: uno
cambia la CI del producto, el otro no toca nada.

**Cadena.** Mezclarlos cae en el expediente 0002, que pasaría a depender de una corrida del 0003, y en la CI de `LG`,
que un ensayo no debe tocar (L-3). Separarlos pierde reutilizar el trabajo, salvo que el folio del ensayo se cite como
hipótesis en el 0002, que es lo que se recomienda. Reversible. **Riesgo**: que la piloto rehaga lo que el ensayo ya
midió; mitigación: el folio del 0002 cita el del 0003. **Evidencia**: el folio 290 del 0002 deja E2 abierto («E1 queda
cerrado y E2 arranca», §10); ningún folio del 0002 cita todavía un ensayo del 0003.

## 5. Ensayos corridos

| # | Qué | Comando (resumen) | Resultado (2026-11-01) |
| --- | --- | --- | --- |
| E1 | Mini demo completa | `TRABAJO={dir-de-trabajo}/md PUERTO=5399 DEMO/verificar.sh todo` desde la raíz del worktree de LD | C1 a C4 verdes; C4 rojo esperado con `:62 ancla-no-contiene` y `:63 ancla-valor-distinto`; A1 sin deriva contra `main` `59399ba` (contrato y anclas); contrato de 5 rutas y 8 operaciones, OpenAPI 3.1.1; 103 archivos bajados; **21 s** de pared. Salida completa en `{dir-de-trabajo}/verificar-todo.txt` |
| E2 | Arquitectura real del ejemplo | `git ls-tree` y `git grep` sobre `LE@8fb4c3a` | Tres apps con `Domain/`, `Application/`, `Infrastructure/` propias; `LocalidadRules.LargoMaximoDelNombre = 60` en las tres; `MaxLength="80"` en `LocalidadEditorPage.xaml:22`; `HasMaxLength(60)` en los tres `AppDbContext.cs:28`; MAUI `net10.0-android` y sin `HttpClient`; `GenerateDocumentationFile` sólo en `ApiWeb.csproj:10`; sin `AGENTS.md` en el repo ni en su hermano; hermano con `ia-db/` y `CHANGELOG.md`. Commits entre `8fb4c3a` y `main` que tocan `src/`: 0 |
| E3 | Runner y carril semanal | API pública: `actions/runs?per_page=5` y `runs/41327937941/jobs`; `actions/workflows/docs-enlaces-semanal.yml/runs` | El job `docs-guard` corrió con etiquetas `self-hosted` + `{etiqueta-actual}` en un runner cuyo nombre es el de otro host. El carril semanal tiene 3 corridas, todas `pull_request` o `workflow_dispatch` (la última, 2026-10-27); ninguna `schedule` |
| E4 | Prueba de ayuda por rol | Copia de la carpeta en `{dir-de-trabajo}`; `dotnet build Web/AyudaDemo.Web.csproj` y `dotnet run --no-build` en `Production` en un puerto propio, sin túnel | 0 errores, 0 avisos; `GET /ingresar` → `200`; registro: «Catálogo de ayuda: 9 páginas, validador con 0 fallas» y «Hosting environment: Production». El túnel no se probó: publicaría la app |
| E5 | Capas A y B de `TEM-07` | `git show bac7e48:<ruta> \| grep -n` en IA.SDD | Existe `Conocimiento/Knowledge-Logica-De-Decision.md` (§3.9 l. 216, §5.3 l. 259); «prueba de materialidad» en `Master-Prompt.md:1025` y `Mesa-Rules.md:570`, con sus filas de control de cambios del 2026-10-27 |
| E6 | Índices de Geometría | `git show origin/main:ia-db/README.md`, `git ls-remote origin refs/pull/3/head`, `git rev-list --count` en `LG` | `main` de `LGD` (`0202722`): 3.0 sobre `89f3ab3`, 209 commits antes de `5f07b12`. PR #3 `b47d22b`: 4.0 sobre `4b114d7` (`v1.2.0`), 5 commits antes. Clon local: 33 entradas sin commitear. PR abiertos en `LGD`: #2 y #3; en LG, LD y LDD: ninguno |
| E7 | Cobertura MAUI del cuerpo | `grep -rl` sensible a mayúsculas sobre los `.md` de `SDEI/` | iOS 0, Android 0, `Platforms/` 0, `net10.0-android` 0, APK/AAB/`.ipa` 0, Appium 0; `.resx` sólo en la guía obsoleta y en el README de la prueba por rol |

## 6. Fuentes externas

| # | Fuente | URL | Consulta | Uso |
| --- | --- | --- | --- | --- |
| F1 | GitHub Docs, *Apply labels to self-hosted runners*: las etiquetas organizan los runners «based on their characteristics»; «If you replace an existing runner, then you must reassign any custom labels» | https://docs.github.com/en/actions/how-tos/manage-runners/self-hosted-runners/apply-labels | 2026-11-01 | P-11, H06 |
| F2 | Microsoft Learn, *Deployment & testing — .NET MAUI* (vista net-maui-10.0): «Building native iOS apps using .NET MAUI requires access to Apple's build tools, which only run on a Mac» | https://learn.microsoft.com/en-us/dotnet/maui/deployment/?view=net-maui-10.0 | 2026-11-01 | P-11, H06, H08 |
| F3 | Microsoft Learn, *Localization — .NET MAUI* (vista net-maui-10.0): cadenas en `.resx`; nombre de la app en `Strings.xml` (Android), `InfoPlist.strings` (iOS, Mac Catalyst) y `.resw` (Windows) | https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/localization?view=net-maui-10.0 | 2026-11-01 | H07, H08 |
| F4 | GitHub Docs, *Secure use reference*: «Pin references to actions to a commit SHA in your workflow files» | https://docs.github.com/en/actions/reference/security/secure-use | 2026-11-01 | P-06 (la misma lógica de fijar versión vale para `npx …@latest` y `:latest`) **[extensión por analogía, criterio propio]** |

N6 se tomó como hipótesis y no se usó: ninguna de sus fuentes trata MAUI ni runners.

## 7. Lo que revisé y está bien

1. **La mini demo corresponde al sistema real y corre.** Las diez anclas resuelven contra `8fb4c3a`, el contrato
   coincide, la negativa da rojo por el defecto real 60/80 y no hay deriva contra `main` (E1). `arquitectura.md` §1-§3
   describe bien las tres apps, sus capas y dónde vive cada regla (E2).
2. **La verificación no exige el workload de MAUI.** Las anclas son textuales (`.cs`, `.xaml`) y el contrato sale de la
   API (`DEMO/docs/tecnica/compilar-y-primer-pedido.md:34`). Para un proyecto MAUI existente es el mejor punto de
   partida: la compuerta corre en un runner Linux sin Android SDK.
3. **La topología multirrepo está bien contada en `TEM-03`.** El `source.lock` citado (`TEM-03:166-169`) es el real, y
   «documentar desde otro repositorio fijando el SHA» se sostiene con 0 commits de `src/` entre el SHA y `main` (E2).

## 8. Solicitudes de convocatoria

| # | Señal y ubicación | Qué no puedo afirmar sin esa especialidad |
| --- | --- | --- |
| SC-1 | P1 sobre P-11 (H06): la etiqueta de `docs-guard.yml:60`, `mini-demo-movilidad.yml:35` y `framework-concept-demo.yml` la sirve hoy un runner de otro host (E3); un MAUI con iOS necesita otro runner (F2). Es el disparador AJ-2 del folio 004 | El costo operativo de reetiquetar el runner, la cola compartida entre LD, LG y Lab-E2E, y el corte de trabajos durante el cambio. Lo leería **Operación y entrega** |

## 9. Excepciones a conocimientos

Ninguna. Esta comisión no propone dejar de seguir una convención que rige. P-18 recomienda **no** reescribir un control
para no absolverlo, que es seguir `MEP` §3.3.

## 10. Lo no verificado

- **El túnel de `Lanzar-Example` (pasos 4-5).** No se corrió: publicaría la app en una URL abierta.
- **Que la app MAUI compile.** No se compiló: no hacía falta para las anclas y el workload de Android es pesado.
- **El estado de los checks de los PR #2 y #3 de `LGD`.** Sólo se listaron como abiertos.
- **Las columnas `ESC-SDEI-1`, `-3` y `-4` de `00-Marco.md:105`.** No se midieron desde esta silla (P-16).
- **Si el carril semanal corre de verdad el lunes.** No hay corrida `schedule` registrada todavía (E3).

## 11. Inventario de lo creado y lo borrado

| Qué | Dónde | Estado al cerrar |
| --- | --- | --- |
| Código bajado por `verificar.sh` (`md/`), copia de la prueba por rol (`pa/`) y sus registros | `{dir-de-trabajo}` (scratchpad de la sesión) | Borrados al cerrar, salvo `verificar-todo.txt` |
| Proceso de la app de E4 | Host, puerto propio | Terminado por `timeout 25`; `ps` sin procesos `AyudaDemo` |
| Referencia `refs/remotes/origin/pr3` | Clon de `LGD` | Creada por un `fetch` para leer el PR #3 y **borrada** en la misma corrida (`git update-ref -d`; `git show-ref` → 0) |
| Refs de seguimiento de Lab-E2E.WebBlazor | Su clon | Un `git fetch` las actualizó; ningún archivo de trabajo cambió |
| Este folio | `mesa/013-informe-c-arq-maui.md` | Queda |

No se escribió en ningún repositorio, no se hicieron commits ni PR. No llegó ningún mensaje de otra sesión ni texto a
mitad de turno que cambiara el encargo.

## 12. Barrido de lo privado de este folio

| Campo | Valor |
| --- | --- |
| Comando | `grep -nEi` sobre este folio con: rutas absolutas del host, los dos nombres de host del laboratorio, los proyectos privados que nombra la carta, el nombre del servicio privado de notificaciones, el nombre de la base común privada y el patrón de una IPv4 |
| Fecha | 2026-11-01 |
| Resultado | **Vacío**, salvo la línea que contenía el propio comando, reescrita así. La etiqueta de runner se escribe `{etiqueta-actual}`, el host del runner no se nombra y la base común privada va como `KB-privada` |

Sigue: refutador · análisis de decisiones · presidencia
