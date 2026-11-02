# M4 — Invenciones del caso C0, ronda 2: verificación del refutador

Caso C0, corridas `C0-r1` y `C0-r2` de la ronda 2. Medida M4 del folio previo de ensayos (§7; criterio de 099
§5.5): una invención es una cita `ruta:línea` que no existe o que no sostiene lo afirmado. Pasa si es 0. Todas las
rutas de este informe son relativas al directorio de cada corrida (`repo/`, `salida/`, `conocimiento.md`). El repo
leído es `repo/LD` (Lab-Documentos), recibido **sin `.git`**: no hay commit contra el cual repetir la comprobación,
así que vale el árbol recibido. Las citas de las fichas son relativas a la raíz de `repo/LD`. La carpeta del cuerpo
`SDEI` (`Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion`) llega sin permisos de lectura en las
dos corridas; ninguna cita apunta adentro de ella.

## Resultado

| Corrida | Citas del aplicador (distintas) | En A-01 / en otros artefactos | Archivo o línea inexistente | Muestra abierta | No sostiene | Invenciones | M4 |
| --- | --- | --- | --- | --- | --- | --- | --- |
| C0-r1 | 198 (72) | 101 / 97 | 0 | 20 | 0 | **0** | pasa |
| C0-r2 | 293 (61) | 92 / 201 | 1 | 20 | 0 | **1** (fuera de la ficha) | no pasa en sentido estricto; la ficha `A-01` tiene 0 |

## Instrumento

`citas.py` (en esta carpeta) recorre `salida/A-01.md` y después todos los artefactos de texto de `salida/`
(`.md`, `.txt`, `.tsv`). Extrae cada cita `ruta:línea`, los rangos `a-b`, las listas con coma, las continuaciones
`` `:N` `` y las continuaciones sueltas `, :N`. Resuelve la ruta contra `repo/LD/`; un nombre suelto que no está en la
raíz se busca por nombre en `repo/`. Comprueba que el archivo existe y que su número de líneas alcanza el final del
rango.

Separa tres clases de origen, porque `salida/` de estas corridas trae mucho texto que no escribió el aplicador:

- **aplicador**: los `.md` de `salida/` escritos por él. En las copias montadas del repo (carpetas `montaje/` y
  `origen/`) sólo cuentan las líneas que no están en el archivo del repo con la misma ruta. En C0-r1 eso deja una
  sola fuente además de A-01: la ficha montada `salida/_trabajo/montaje/docs/_diseno/ficha-diseno-documental.md`; las
  otras 583 copias de `montaje/` y `origen/` son el repo tal cual. En C0-r2, las dos fichas del par
  `salida/verificacion/montaje/{rojo,verde}/ficha.md` y la nota `salida/notas-ronda-1.md`.
- **cruda**: salidas de comandos (`.txt`, `.tsv`). Cada línea con forma `ruta:n:…` (grep o `dg.py`) se contrasta con
  la línea `n` del repo (procedencia): 5998 coinciden en C0-r1 y 5203 en C0-r2. La única que no coincide,
  `salida/_trabajo/ver-trazas-rojo.txt:2`, es el rojo plantado sobre la ficha montada (`docs/_diseno/…`, que existe
  en `salida/_trabajo/montaje/`): se esperaba que no estuviera en el repo. Las 9 y 6 citas crudas que el script marca
  como inexistentes son un límite de la expresión regular, no del texto: la ruta del repo tiene espacios
  (`Guides/IA/SDD-Guide/Spec-Driven Development-SDD.md:79` y `Guides/Metodologia-Agiles/Scrum-Guide/
  Metodologias-Agiles-Jira-Guide.md:199` y `:260`). Abiertas a mano, las tres líneas existen y tienen el dominio que
  informa `dg.py`. Las salidas crudas no están fabricadas.
- **copia**: líneas idénticas al repo dentro de las copias montadas: no cuentan.

Comando: `python3 -I citas.py . --tsv citas-<corrida>.tsv`, corrido desde el directorio de la corrida. Tablas
completas: `citas-C0-r1.tsv` y `citas-C0-r2.tsv` (columna `clase`). Salida del script: `salida-script-C0-r1.txt` y
`salida-script-C0-r2.txt`.

**Respuestas del coordinador.** `salida/respuestas.md` cuenta como fuente sólo si la respuesta cita un archivo del
directorio. En las dos corridas las seis respuestas (Q-1 a Q-6) son «no disponible: tratalo como dato faltante», con
fuente «—»: ninguna sirve de fuente. Las dos fichas sólo las usan para dejar filas en «pendiente».

## Lista de invenciones

- **C0-r1: ninguna.**
- **C0-r2: una.** `salida/notas-ronda-1.md:12` cita `tools/docs-guard/arbol.tsv:55` para la topología (repo
  hermano `.Documentacion`). `tools/docs-guard/arbol.tsv` tiene 10 líneas: la línea 55 no existe. La línea que
  sostiene lo afirmado es la 8 (`…/Lab-Documentos.Documentacion  LAB/Lab-Documentos/Lab-Documentos.Documentacion`).
  La nota es de trabajo (estado de la ronda 1 para retomar), pero está en `salida/`. En la ficha final, la misma fila
  D-01 · topología cita bien `tools/docs-guard/arbol.tsv:7-8` (`salida/A-01.md:39`), y D-05 cita `:8`. La cita no
  pasó a la ficha.

**Cita ambigua, no inventada.** `salida/A-01.md:119` (C0-r2) dice `ficha.md:1: ERROR traza-no-resuelve: …`. Es la
salida textual de `dg.py` sobre el montaje rojo, y se refiere a `salida/verificacion/montaje/rojo/ficha.md`, cuya
línea 1 existe. El script la resolvió por nombre contra un fixture del repo (`tools/docs-guard/fixtures/anclas/rojo/ficha.md`),
que también existe. No es una invención.

## Muestra abierta (20 por corrida)

Se leyó cada línea citada y se comparó con lo que la ficha afirma.

### C0-r1

| # | Cita | Afirmación | Sostiene |
| --- | --- | --- | --- |
| 1 | `README.md:14` | el proyecto es Lab-Documentos | sí (`# Lab-Documentos`) |
| 2 | `README.md:16-17` | corpus de guías de estudio | sí, literal |
| 3 | `README.md:30-31` | cuerpo `SDEI` con el proceso «Cómo intervenir» | sí |
| 4 | `AGENTS.md:45-46` | sin sitio publicado | sí («leídas en GitHub, sin sitio publicado») |
| 5 | `AGENTS.md:109-110` | regla de privado y alias `SDD-B` | sí, literal |
| 6 | `AGENTS.md:17-19` | `AGENTS.md` es un puntero | sí, literal |
| 7 | `AGENTS.md:139` | cambiar `AGENTS.md` es clase H | sí, literal |
| 8 | `CHANGELOG.md:34` | folio del expediente 0003 en el repo hermano `.Documentacion` | sí |
| 9 | `CHANGELOG.md:336` | la demo compilable ilustra la guía | sí, literal |
| 10 | `.github/workflows/docs-guard.yml:60` | runner `self-hosted` con etiqueta propia (alias `{etiqueta-runner}`) | sí |
| 11 | `.github/workflows/docs-guard.yml:72-81` | toma `scripts/` y `tools/docs-guard/` del mismo repo al SHA del evento | sí (`ref: … github.sha`, `sparse-checkout`) |
| 12 | `tools/docs-guard/README.md:148-157` | tabla de qué controles bloquean y cuáles avisan | sí |
| 13 | `tools/docs-guard/arbol.tsv:8` | repo hermano `Lab-Documentos.Documentacion` | sí |
| 14 | `scripts/ci-local.sh:64-83` | lychee y mermaid se bajan de internet | sí (`curl` y `npm ci`) |
| 15 | `tools/docs-guard/prefijos.txt:8-40` | prefijos del registro (ACT, ADR, ARQ, … TEM) | sí (todos en el rango) |
| 16 | `tools/docs-guard/esquemas/cuerpo.schema.json:7` | diez campos más `description` | sí (`required` en la 7; la 5 lo dice literal) |
| 17 | `tools/docs-guard/dg.py:537-546` | función `registro()` | sí |
| 18 | `Concepts/Framework-Concept/Demo/tools/FrameworkConcept.Receptor/Program.cs:32` | el receptor expone endpoints REST | sí (`app.MapGet("/salud", …)`) |
| 19 | `.github/workflows/docs-enlaces-semanal.yml:3-6` | carril que sólo avisa y abre un único issue | sí, literal |
| 20 | `.github/workflows/docs-enlaces-semanal.yml:16-19` | semanal, lunes 06:17 UTC, y a mano | sí (`cron: "17 6 * * 1"`, `workflow_dispatch`) |

### C0-r2

| # | Cita | Afirmación | Sostiene |
| --- | --- | --- | --- |
| 1 | `AGENTS.md:45-53` | piezas del mismo repo (cuerpo, `Guides/`, `tools/docs-guard/`, `ci-local.sh`) | sí |
| 2 | `AGENTS.md:62-63` | el índice del proyecto es el README del cuerpo | sí (paso 2: «README del cuerpo: la tabla de contenido con el `doc_id`…») |
| 3 | `CHANGELOG.md:322` | asiento en el repo hermano `.Documentacion` | sí |
| 4 | `CHANGELOG.md:335` | la guía de estudio del Framework Concept | sí (`Developer-Guide.md`, guía de estudio) |
| 5 | `CHANGELOG.md:14` | el CHANGELOG nombra páginas de ayuda del cuerpo | sí (ayuda por rol, bajo el encabezado del cuerpo `SDEI`) |
| 6 | `CHANGELOG.md:362` | ídem, no contrastables en el árbol legible | sí (`Examples/Prueba-Ayuda-Por-Rol/`; la carpeta no está en el árbol legible) |
| 7 | `CHANGELOG.md:160` | `DOC-SDT-0001` declarado obsoleto | sí (`status: obsoleto`) |
| 8 | `README.md:11` | traza a `DOC-SDT-0001` | sí (`traces: [GUIAS-INDICE, DOC-SDT-0001]`) |
| 9 | `Guides/README.md:11` | traza a `DOC-SDT-0001` | sí |
| 10 | `Concepts/Framework-Concept/00-Marco.md:94` | `ESC-1` declarado ahí (y 115 lugares más) | sí (`### ESC-1 Primer arranque`; 116 menciones en `salida/inventario/1-trazas.txt`) |
| 11 | `Concepts/Framework-Concept/Demo/tools/FrameworkConcept.Receptor/AutenticacionDelReceptor.cs:69-70` | una sola política `RequireAuthenticatedUser().RequireClaim("sub")` | sí, literal |
| 12 | `.github/workflows/docs-guard.yml:11-12` | PR-5 resuelve trazas también sobre los punteros de la raíz | sí |
| 13 | `.github/workflows/docs-guard.yml:16` | mismo guion en CI y en local | sí (`Su equivalente local, con los mismos pasos…: scripts/ci-local.sh`) |
| 14 | `.github/workflows/docs-guard.yml:38` | RUTA por defecto = carpeta del cuerpo `SDEI` | sí |
| 15 | `.github/workflows/docs-guard.yml:32-48` | se ofrece como reutilizable | sí (`workflow_call` con entradas) |
| 16 | `.github/workflows/framework-concept-demo.yml:5` | sólo un comentario dice que `fw-ok` es el único check requerido | sí, literal (es comentario) |
| 17 | `.github/workflows/framework-concept-demo.yml:7` | comentario con `self-hosted, {etiqueta-runner}` | sí (comentario `P6.4 runs-on [self-hosted, …]`) |
| 18 | `tools/docs-guard/esquemas/cuerpo.schema.json:7-19` | campos obligatorios y vocabulario cerrado de `doc_type` y `audience` | sí (`enum` en 10 y 18) |
| 19 | `tools/docs-guard/README.md:178` | agregar una excepción la aprueba una persona | sí («Clase H: la aprueba una persona») |
| 20 | `.github/workflows/docs-enlaces-semanal.yml:17-18` | carril semanal (lunes) | sí (`cron: "17 6 * * 1"`) |

Fuera de la muestra también se leyeron, en C0-r1, `CHANGELOG.md:342`, `.github/workflows/docs-guard.yml:75`,
`tools/docs-guard/README.md:31` y `.github/workflows/framework-concept-demo.yml:159`; en C0-r2,
`tools/docs-guard/prefijos.txt:1-5`, `tools/docs-guard/README.md:196` y `:201-205`, y `CHANGELOG.md:36`. Todas
sostienen lo afirmado. `tools/docs-guard/README.md:196` (C0-r2, D-06) habla del atraso de `base_commit` y
`source.lock`, y la etiqueta `sdei-v2.0.0-borrador` sale de `CHANGELOG.md:36`, citada en la misma celda: la celda se
sostiene con las dos citas juntas.
