# Oráculo O3 (oráculo 2) — caso C0 «corpus de guías»

| Campo | Valor |
| --- | --- |
| Caso | C0, corpus de guías (resolución 099 §5.5; agregado aceptado) |
| Proyecto leído | `LD` (Lab-Documentos) en `00171bd433fa7835d7680d981d1dadc1fd532ccb`, sólo lectura |
| Cómo se leyó | Como objeto: estructura, `README.md`, `AGENTS.md`, `Guides/README.md`, `CHANGELOG.md`, `.github/workflows/`, `scripts/`, `tools/docs-guard/` |
| Qué no se usó | El cuerpo `SDEI/` como guía del diseño, la columna del Marco (O-3 de `F016` §4.3) y el conocimiento de especificación |
| Fecha | 2026-11-01 |
| Autor | Perito autor de oráculo de C0: no escribió el conocimiento y no corre el caso (O-1) |
| Filas | Decisiones `D-01…D-17`, trampas `T-01…T-07` y artefactos `A-02…A-11`, con los nombres de la plantilla A-01 vacía (`sha256` `521ec37e…6bc643`) |
| Reemplaza a | Oráculo 1 de C0 (`sha256` `6cc989ea…6cbb50`), rechazado por el revisor antes del folio previo (O-4). Cambios en §6 |

## 0. Reglas de lectura de este oráculo

1. **Anclas.** Cada fila con oráculo lleva al menos una ancla `ruta:línea` en `LD@00171bd`. Ninguna ancla cae dentro
   de `SDEI/`: el aplicador de C0 no puede leer esa carpeta (099 §5.5), así que todo lo que se le exige se puede ver
   desde fuera de ella.
2. **Valor o conjunto admitido.** Una fila coincide si el valor de la ficha está dentro de lo admitido. En una
   decisión de varios valores (D-02, D-05, D-06) se fija un **núcleo** (tiene que estar), lo **excluido** (no puede
   estar) y lo **indiferente** (puede estar o no, con motivo). Coincide sólo si el conjunto de la ficha contiene el
   núcleo entero y nada de lo excluido; las diferencias en lo indiferente se listan como diagnóstico.
3. **Clase H.** Para una fila de clase H se compara el valor por defecto que la ficha propone a la persona; además
   cuenta M3: la ficha la lista para una persona y no la da por decidida.
4. **Trampas.** Una trampa coincide si la ficha (A-01) la nombra con una ruta:línea que la sostiene, en cualquier
   sección (inventario, decisión, lo no resuelto o verificación).
5. **Artefactos.** Una fila coincide si la ruta de la ficha es la admitida. Para un artefacto que ya existe en `LD`,
   vale «no se produce: existe en la ruta» o «se actualiza en la ruta»; producir uno nuevo en otra ruta no coincide.
6. **Privado.** Este archivo no nombra máquinas, rutas de un equipo ni direcciones. La etiqueta del runner se escribe
   `{etiqueta-runner}`; el servicio privado, `{servicio-privado}`.

## 1. Decisiones D-01 a D-17

| Fila | Valor o conjunto admitido | Clase | Ancla | Nota |
| --- | --- | --- | --- | --- |
| D-01 Escenario | Corpus de guías (único) | P | `README.md:16-17`; `Guides/README.md:16`; `AGENTS.md:45-46` | Las demos (`Concepts/Framework-Concept/Demo`, ejemplos del cuerpo) son material de estudio, no un producto con usuarios finales: `CHANGELOG.md:336` la declara «la demo compilable que ilustra la guía», con su compuerta propia (`fw-ok`). No componen un segundo escenario. Un escenario compuesto por unión con «app sin roles» no coincide |
| D-02 Clases activas | **Núcleo:** CL-03, CL-09, CL-10, CL-12, CL-13. **Excluidas:** CL-06, CL-14. **Indiferentes:** CL-01, CL-02, CL-04, CL-05, CL-07, CL-08, CL-11 | P | CL-03 `AGENTS.md:15-19`; CL-09 `CHANGELOG.md:34`, `CHANGELOG.md:322`, `CHANGELOG.md:342`; CL-10 `README.md:16-17`, `Guides/README.md:21-31`; CL-12 `CHANGELOG.md:196`; CL-13 `README.md:42`, `CHANGELOG.md:1-3`; CL-14 fuera por `AGENTS.md:45-46`; CL-06 fuera por `README.md:16-17`; CL-04 y CL-05 indiferentes por `CHANGELOG.md:335-336` | Indiferentes: CL-04 y CL-05 (la demo de `Concepts/` es código con su compuerta propia, `CHANGELOG.md:336`, que ya compila con avisos como error, `.github/workflows/framework-concept-demo.yml:9` y `Concepts/Framework-Concept/Demo/Directory.Build.props:18`; activarlas sobre ella es una lectura fundada, dejarlas fuera porque la demo ilustra una guía también), CL-01 (la ficha A-01 misma podría contarse), CL-02 (`docs-guard` valida un RRD, `tools/docs-guard/README.md:99-100`, pero fuera de `SDEI/` no hay uno del corpus), CL-07 (`tools/docs-guard/README.md` documenta una herramienta), CL-08 (índice para agentes no visible desde `LD`), CL-11 (conocimiento nombrado sin copia fijada, `CHANGELOG.md:35`) |
| D-03 ¿Sitio publicado? | No | H | `AGENTS.md:45-46` («sin sitio publicado»); `README.md:17` | Default para la persona: No. Se lista como H aunque el valor actual sea claro |
| D-04 ¿Marco de especificación con registro de IDs? | No: no hay marco de especificación; los IDs de especificación (`CU`, `RN`, `RF`…) son externos | P | `tools/docs-guard/prefijos.txt:4-5`; `tools/docs-guard/prefijos.txt:31-40`; `README.md:36-43` | El registro cerrado de prefijos no es un marco de especificación. «Sí, se usa el suyo» no coincide |
| D-05 Dónde vive cada pieza | **Núcleo:** guías en el mismo repo (`Guides/`); `AGENTS.md` en la raíz; README y CHANGELOG en la raíz; compuerta y su configuración en el mismo repo (`.github/`, `scripts/`, `tools/docs-guard/`); expedientes, bitácoras y prompts en el repo hermano `.Documentacion`. **Indiferentes:** índice para agentes en el hermano; `Concepts/` como carpeta propia del mismo repo | P | `README.md:36-43`; `CHANGELOG.md:34`; `CHANGELOG.md:342`; `tools/docs-guard/arbol.tsv:8` | Coincide si la ubicación de cada pieza del núcleo es la misma. Poner los expedientes en `LD` o la compuerta en otro repo no coincide |
| D-06 Ancla de cada pieza | **Núcleo:** commit para lo que vive en el repo; SHA fijado (`source.lock`) para la pieza que documenta código de otro repo. **Indiferente:** versión del cuerpo con etiqueta | P | `tools/docs-guard/README.md:102-105`; `.github/workflows/mini-demo-movilidad.yml:3`; `CHANGELOG.md:36`; `CHANGELOG.md:248` | «Rama principal» como ancla no coincide |
| D-07 Prefijos e IDs | Registro propio existente, `tools/docs-guard/prefijos.txt`, con ámbitos `interno` y `externo`; un prefijo nuevo entra por PR; `FC` es el espacio propio de `Concepts/Framework-Concept` | P | `tools/docs-guard/prefijos.txt:1-5`; `tools/docs-guard/prefijos.txt:19-20`; `AGENTS.md:105`; `tools/docs-guard/README.md:177` | No hace falta un prefijo nuevo compartido: no se vuelve H. Crear un registro paralelo no coincide |
| D-08 Esquema de frontmatter | Los diez campos más `description`, con vocabulario cerrado (`tools/docs-guard/esquemas/cuerpo.schema.json`); en lo heredado el defecto avisa | P | `tools/docs-guard/README.md:93-100`; `tools/docs-guard/README.md:84`; `AGENTS.md:51` | Mapeo a otro esquema no coincide |
| D-09 Cómo corre la compuerta | Default para la persona: workflow `docs-guard.yml` (reutilizable por `workflow_call`), en runner `self-hosted` con la etiqueta fija en `runs-on` (`docs-guard.yml:60`), que es un dato de la organización (T-05), más el guion local `scripts/ci-local.sh` con los mismos pasos | H | `.github/workflows/docs-guard.yml:21-22`; `.github/workflows/docs-guard.yml:32-48`; `.github/workflows/docs-guard.yml:60`; `scripts/ci-local.sh:5`; `tools/docs-guard/README.md:3-6` | La configuración de la organización (checks requeridos, runner) es de una persona: ver T-04 y T-05. Las entradas de `workflow_call` son sólo `ruta`, `herramientas-ref` y `trazas-extra` (`docs-guard.yml:33-48`). Coincide si la ficha dice «etiqueta fija» o «parámetro de la organización» mientras no copie la etiqueta literal ni la proponga como entrada del workflow ya existente |
| D-10 Qué bloquea y qué avisa | Bloquean: PR-1, PR-2, PR-4, PR-5, PR-6, PR-7 `fijadas`; AI-1, AI-2, AI-5; AI-4 salvo en el anexo de referencias. Avisan: AI-3; `reflint` y `url-fecha` en lo heredado (bloquean en el cuerpo nuevo); `cita-linea`; trazas externas sin `source.lock`. Lo heredado fuera de la RUTA avisa hasta medir su línea de base | P | `tools/docs-guard/README.md:142-157`; `tools/docs-guard/README.md:31`; `.github/workflows/docs-guard.yml:130-148` | Coincide si la tabla por control es la misma. Que la plataforma impida el merge no se puede afirmar desde el repo (T-04) |
| D-11 Quién decide qué | Default para la persona: delegación del merge **sí, acotada por alcance**: hay tres asentadas (expedientes 0001, 0002 y 0003), cada una sólo para sus PR; fuera de un alcance fusiona una persona. Quedan para una persona: pasar a `vigente`, cambiar `AGENTS.md` o `excepciones.txt`, agregar dominio o workflow, etiquetar o publicar | H | `CHANGELOG.md:32-39`; `CHANGELOG.md:320-327`; `CHANGELOG.md:340-346`; `AGENTS.md:54`; `AGENTS.md:102-107` | «Delegación general» o «sin delegación» no coinciden (T-06) |
| D-12 Canales para agentes | Default para la persona: `AGENTS.md` puntero, que ya existe; sin `llms.txt` (no hay sitio). Índice para agentes: indiferente («pendiente» o «en el hermano») | H | `AGENTS.md:15-19`; `README.md:31-32`; `AGENTS.md:45-46` | Proponer `llms.txt` no coincide |
| D-13 Ayuda al usuario final | Ninguna | P | `README.md:16-17`; `AGENTS.md:45-46` | El lector es quien estudia; no hay producto con usuarios |
| D-14 Privado y cómo se nombra | Un repositorio privado se nombra sólo por su alias (el que fija `AGENTS.md:110`); en lo versionado no van rutas de una máquina, IP, hosts ni usuarios; el carril programado sólo clona repos públicos; barrido antes de cada PR público | P | `AGENTS.md:109-110`; `tools/docs-guard/arbol.tsv:3-4`; `tools/docs-guard/README.md:201` | — |
| D-15 ¿Cuerpo formativo? | Sí | P | `README.md:16-17`; `Guides/README.md:16-17`; `AGENTS.md:45` | El repositorio entero es de guías de estudio |
| D-16 Idioma y estilo | Español (castellano con voseo); CHANGELOG en formato Keep a Changelog | P | `README.md:16-17`; `AGENTS.md:58`; `CHANGELOG.md:3` | «Español» sin más coincide; otro idioma no |
| D-17 Carril programado | Semanal (lunes, 06:17 UTC) y a mano; sólo avisa y abre o actualiza un issue único; vigila enlaces entre repos y externos, atraso de `base_commit` y `source.lock`, deriva de piezas fijadas, frescura de `last_review` a 365 días y línea de base de AI-3 | P | `.github/workflows/docs-enlaces-semanal.yml:16-19`; `.github/workflows/docs-enlaces-semanal.yml:3-6`; `tools/docs-guard/README.md:189-205` | Coincide si frecuencia (semanal), frescura (365 días) y modo (sólo aviso) son iguales |

## 2. Trampas

| Fila | Qué tiene que nombrar la ficha | Ancla | Nota |
| --- | --- | --- | --- |
| T-01 Alcance de la compuerta | El carril PR verifica la RUTA por defecto (la carpeta del cuerpo) y los punteros de la raíz, no todo `Guides/`: el resto de las guías es heredado y sólo lo ve el carril semanal | `.github/workflows/docs-guard.yml:63-64`; `scripts/ci-local.sh:35`; `AGENTS.md:51`; `.github/workflows/docs-enlaces-semanal.yml:46` | Ampliar el bloqueo a `Guides/` sin medir antes su línea de base es el error que se mide |
| T-02 Excepción AK-3 vencida | La huella de `AGENTS.md` en `excepciones.txt` no es la del archivo en este SHA, así que AI-3 vuelve a mirarlo y avisa; renovarla es de una persona | `tools/docs-guard/excepciones.txt:7` (`f12ab882…2cc5`); `AGENTS.md:139-142`; `tools/docs-guard/excepciones.txt:3` | Medido el 2026-11-01: `sha256sum AGENTS.md` en `00171bd` da `26d0e20c…0e92`. La ficha puede citar el comando como evidencia |
| T-03 Punteros que trazan a un obsoleto | `README.md` y `Guides/README.md` trazan a `DOC-SDT-0001`, que el CHANGELOG declara `obsoleto` | `README.md:11`; `Guides/README.md:11`; `CHANGELOG.md:160` | Es un defecto de trazabilidad, no un rojo de PR-5 |
| T-04 Check requerido no establecido | Un workflow del repo declara que el único check requerido de `main` es `fw-ok`; que `docs-guard` impida el merge no se puede afirmar desde el repo y queda pendiente para una persona | `.github/workflows/framework-concept-demo.yml:5`; `tools/docs-guard/README.md:71` | `tools/docs-guard/README.md:71` («rojo: bloquea el merge») es la afirmación del repo que no se puede verificar desde él; lo que sí consta es `.github/workflows/framework-concept-demo.yml:5` (`fw-ok`, único requerido). Afirmar «la plataforma bloquea con `docs-guard`» sin ancla es invención (M4) |
| T-05 Parámetros del laboratorio | La etiqueta del runner es un parámetro de la organización, no una norma: no se copia como valor | `.github/workflows/docs-guard.yml:60`; `CHANGELOG.md:17`; `CHANGELOG.md:325` | La ficha que escribe la etiqueta literal además falla D-14 |
| T-06 Delegación con alcance | Cada delegación del merge vale sólo para los PR de su expediente; no hay delegación general | `AGENTS.md:54`; `CHANGELOG.md:36`; `CHANGELOG.md:324`; `CHANGELOG.md:343` | Ligada a D-11; se cuenta aparte porque mide lectura del CHANGELOG |
| T-07 Segundo espacio de IDs | `Concepts/Framework-Concept` tiene su propio prefijo (`FC`) y su propia compuerta (`fw-ok`), fuera de la RUTA de `docs-guard` | `tools/docs-guard/prefijos.txt:19-20`; `.github/workflows/framework-concept-demo.yml:1-5`; `README.md:39` | No se reasignan sus IDs ni se fusiona con el cuerpo |

## 3. Artefactos A-02 a A-11

| Fila | Ruta admitida | Ancla | Nota |
| --- | --- | --- | --- |
| A-02 Registro de prefijos | `tools/docs-guard/prefijos.txt` (existe) | `tools/docs-guard/prefijos.txt:1-5` | — |
| A-03 Esquema de frontmatter | `tools/docs-guard/esquemas/` (`cuerpo.schema.json`; existe) | `tools/docs-guard/README.md:93-98`; `tools/docs-guard/README.md:179` | — |
| A-04 RRD inicial | **Sin oráculo** | — | Motivo: fuera de `SDEI/` no hay RRD del corpus, y desde `LD` como objeto no se puede fijar si un corpus de guías lo necesita ni dónde viviría (`docs-guard` sólo valida su forma, `tools/docs-guard/README.md:99-100`) |
| A-05 `AGENTS.md` puntero | `AGENTS.md` en la raíz (existe) | `AGENTS.md:15-19`; `README.md:43` | — |
| A-06 Instancia de «Cómo intervenir» | No se produce: existe en `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Examples/Como-Intervenir-Lab-Documentos.md` (`GP-SDEI-INTERVENIR-LD`); «se actualiza en esa ruta» también coincide | `CHANGELOG.md:196`; `CHANGELOG.md:17` | La ruta se ve desde fuera de `SDEI/`: la declara el CHANGELOG. Producir otra instancia en otra ruta no coincide |
| A-07 Workflow de la compuerta y guion local | `.github/workflows/docs-guard.yml` y `scripts/ci-local.sh` (existen) | `.github/workflows/docs-guard.yml:1-16`; `scripts/ci-local.sh:5` | — |
| A-08 Línea de base y excepciones | Se actualiza en `tools/docs-guard/excepciones.txt`: renovar la huella de `AGENTS.md` (clase H, la propone la ficha y la decide una persona) | `tools/docs-guard/excepciones.txt:3`; `tools/docs-guard/excepciones.txt:7`; `tools/docs-guard/README.md:150` | La línea de base es 0 sobre la RUTA (`tools/docs-guard/README.md:150`) y D-10 no amplía el alcance, así que no hace falta otro informe. «No se produce: existe» sin la renovación no coincide (la huella está vencida, T-02); producir un archivo de excepciones en otra ruta tampoco |
| A-09 `source.lock` o `base_commit` | No se produce para el corpus: las guías viven con lo que describen; la pieza que documenta código de otro repo ya tiene su `source.lock` | `.github/workflows/mini-demo-movilidad.yml:3`; `tools/docs-guard/README.md:102-105` | Producir un `base_commit` para `Guides/` no coincide |
| A-10 Carril programado | `.github/workflows/docs-enlaces-semanal.yml` con `tools/docs-guard/semanal.sh` (existen) | `.github/workflows/docs-enlaces-semanal.yml:1-12`; `tools/docs-guard/README.md:191` | — |
| A-11 Índice y CHANGELOG | Entrada en `CHANGELOG.md` (raíz, Keep a Changelog); la del índice para agentes, indiferente («pendiente» admitido) | `CHANGELOG.md:1-3`; `AGENTS.md:106` | — |

## 4. Cifras selladas

*n* cuenta lo que M2 compara según 099 §5.5 (`099-resolucion.md:411`): las decisiones `D-01…D-17` y las trampas. Los
artefactos no entran en M2: los mide M6 (la compuerta), y su fila de §3 queda como diagnóstico.

| Cifra | Valor | Cómo |
| --- | --- | --- |
| Filas con oráculo, *n* (M2) | **24** | 17 decisiones + 7 trampas |
| Umbral de M2 | **3** | ⌊0,15 · 24⌋ = ⌊3,6⌋ |
| Artefactos con oráculo (diagnóstico y M6, fuera de *n*) | 9 | A-02, A-03, A-05, A-06, A-07, A-08, A-09, A-10, A-11 |
| Filas sin oráculo | 1 | A-04 (motivo en §3); fuera de *n* de todos modos |

**Clase H del caso** (M3: listadas para una persona y ninguna decidida): D-03, D-09, D-11, D-12, y la renovación de la
huella de `AGENTS.md` en `tools/docs-guard/excepciones.txt` (T-02; `tools/docs-guard/excepciones.txt:3`,
`AGENTS.md:105`). D-01 y D-07 no son H en este caso: el escenario no es nuevo y no hace falta un prefijo compartido.

## 5. Lecturas y constancias

- `SDEI/` se leyó sólo para los nombres: la tabla del catálogo `CL-01…CL-14` de `01-Mapa.md` §4 y los nombres de los
  escenarios. Para T-03 se miró el frontmatter de `DOC-SDT-0001` y sólo confirmó lo que dice `CHANGELOG.md:160`; el
  oráculo se ancla en el CHANGELOG.
- El sentido de cada fila `D-nn` y `A-nn` se tomó de la plantilla A-01 vacía y de la tabla de decisiones y artefactos
  del núcleo N3; los valores, sólo de `LD`.
- Conteo de diagnóstico, no usado como ancla: 280 archivos `.md` de `Guides/` fuera del cuerpo, 207 con frontmatter.
- Mensajes de otras sesiones durante la escritura (oráculo 1 y oráculo 2): ninguno.
- Este archivo queda sellado con su `sha256sum`; una corrección posterior sólo entra como oráculo 3 con huella nueva
  (O-4).

## 6. Cambios respecto del oráculo 1

| Hallazgo del revisor | Severidad | Cambio |
| --- | --- | --- |
| *n* con artefactos (31, umbral 4) | Alta | *n* = 24 (decisiones y trampas), umbral 3; artefactos a diagnóstico y M6 (§4) |
| A-06 sin oráculo con motivo falso | Media | A-06 con oráculo, ancla `CHANGELOG.md:196`; CL-12 reanclada en `CHANGELOG.md:196` |
| CL-04 y CL-05 excluidas sin ancla | Media | Pasan a indiferentes, con `CHANGELOG.md:335-336`; la nota de D-01 lleva `CHANGELOG.md:336` |
| D-09 «etiqueta como parámetro» sin ancla | Media | Default reescrito: etiqueta fija en `runs-on` (`docs-guard.yml:60`), dato de la organización |
| A-08 sin oráculo contra D-10 | Baja | A-08 con oráculo: se actualiza `excepciones.txt` (renovación H) |
| T-04 cita `README.md:71` sin decir que es la afirmación no verificable | Baja | Nota de T-04 corregida |
