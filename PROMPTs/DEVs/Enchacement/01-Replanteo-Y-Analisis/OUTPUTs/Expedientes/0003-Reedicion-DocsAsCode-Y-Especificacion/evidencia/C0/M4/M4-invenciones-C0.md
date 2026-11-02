# M4 Invenciones del caso C0: refutación

Medida M4 del folio previo de ensayos (§7): cada cita `ruta:línea` existe en el insumo y lo sostiene. Pasa si da 0.
Rutas relativas al directorio de cada corrida (`C0-r1`, `C0-r2`). El insumo es `repo/LD/` (copia sin `.git`, así que
el chequeo vale contra esa copia, no contra un SHA) y `conocimiento.md` para las citas al conocimiento.

## 1. Instrumento

- `m4_citas.py` (en esta carpeta): `python3 -I m4_citas.py <dir-de-la-corrida>`. Extrae cada cita en backticks con
  la forma `ruta:N` o `ruta:N-M` de `salida/A-01.md` y de los demás `.md` de `salida/` (salvo `_inventario/`, que son
  salidas crudas de comandos). Una cita de continuación (`:N`) hereda la última ruta citada en la misma línea. Las
  rutas resuelven contra `repo/LD/`, salvo `salida/…` y `conocimiento.md`, que resuelven contra la corrida; un nombre
  corto (por ejemplo `docs-guard.yml`) se acepta sólo si hay un único archivo con ese sufijo, y queda marcado.
- Salidas: `citas-C0-r1.tsv`, `citas-C0-r2.tsv` (una fila por cita, con su estado).
- Lo que el script no cubre: citas fuera de backticks (se buscaron con `grep` y no hay) y la exactitud de lo afirmado,
  que sale de la muestra manual de §3.

## 2. Resultado del script

| Corrida | Citas | Archivo inexistente | Línea fuera de rango | Resueltas por sufijo único |
| --- | --- | --- | --- | --- |
| C0-r1 | 96 (todas en `A-01.md`) | 0 | 0 | 2 (`docs-guard.yml:60`, `docs-enlaces-semanal.yml:43`, ambas en `.github/workflows/`) |
| C0-r2 | 97 (todas en `A-01.md`) | 0 | 0 | 3 (las dos anteriores y `mini-demo-movilidad.yml:35`) |

Los demás artefactos de `salida/` no citan `ruta:línea` propias. En C0-r1, `salida/CHANGELOG.md` es una copia del
`CHANGELOG.md` del repo con una entrada nueva; sus `` `:63` `` y semejantes son texto heredado sin ruta, no citas del
aplicador.

## 3. Muestra manual: 20 citas por corrida

Criterio: la línea o el rango citado contiene lo que la ficha afirma. «Desplazada» = el texto está en la línea
contigua, no en la citada.

### C0-r1

| # | Fila | Cita | Afirmación | Veredicto |
| --- | --- | --- | --- | --- |
| 1 | Cabecera | `README.md:14` | Se identifica como Lab-Documentos | Sostiene |
| 2 | Cabecera | `tools/docs-guard/arbol.tsv:7` | Dueño/nombre del repo | Sostiene |
| 3 | §1 | `README.md:30`, `AGENTS.md:41-124`, `.github/workflows/docs-guard.yml:38`, `scripts/ci-local.sh:35` | Citan la carpeta `Sistema-De-Documentacion-E-Integracion/` ausente | Sostiene |
| 4 | §1 | `tools/docs-guard/excepciones.txt:7` | Declara la huella `f12ab882…2cc5` de `AGENTS.md` | Sostiene |
| 5 | D-01 | `README.md:16-17` | «Repositorio de guías de estudio y conceptos» | Sostiene |
| 6 | D-01 | `CHANGELOG.md:336` | La demo «ilustra la guía» | Sostiene |
| 7 | D-03 | `AGENTS.md:46` | «sin sitio publicado» | Sostiene |
| 8 | D-04 | `tools/docs-guard/prefijos.txt:1-40` | Registro cerrado de prefijos | Sostiene |
| 9 | D-05 | `tools/docs-guard/arbol.tsv:8` | El hermano `.Documentacion` existe como repo público | Sostiene |
| 10 | D-06 | `Concepts/Framework-Concept/Developer-Guide.md:5` | Declara `version: 1.0.0` | Sostiene |
| 11 | D-07 | `tools/docs-guard/prefijos.txt:11`, `:27` | `DOC` y `RD` registrados | Sostiene |
| 12 | D-07 | `.github/workflows/docs-guard.yml:21-22` | Workflow reutilizable por otros repos | Sostiene |
| 13 | D-08 | `tools/docs-guard/esquemas/cuerpo.schema.json:7` | Campos requeridos del esquema | Sostiene |
| 14 | D-10 | `.github/workflows/framework-concept-demo.yml:5-6` | `fw-ok` es el único check requerido de `main` | Sostiene |
| 15 | D-10 | `scripts/ci-local.sh:70-71`, `:79`, `:90` | lychee, mermaid y markdownlint se bajan de la red | Sostiene |
| 16 | D-11 | `CHANGELOG.md:32-39`, `:320-326`, `:340-345`, `:34` | Tres delegaciones por expediente; decide el PO | Sostiene |
| 17 | D-14 | `tools/docs-guard/arbol.tsv:3-4`, `AGENTS.md:109-110` | Repo público; regla de lo privado | Sostiene |
| 18 | D-17 | `.github/workflows/docs-enlaces-semanal.yml:18`, `:25`, `:46`; `tools/docs-guard/semanal.sh:16` | Lunes 06:17 UTC, carpeta `Guides`, frescura 365 días | Sostiene |
| 19 | CL-12 | `CHANGELOG.md:195-196` | Plantilla `Como-Intervenir` e instancia, ausentes en la copia | Sostiene |
| 20 | CL-04 | `.github/workflows/framework-concept-demo.yml:10-11` | «la demo compila con avisos como error» | **Desplazada**: «build … con avisos como error» está en la línea 9; 10-11 tienen sólo la cola de esa oración y una línea vacía |

### C0-r2

| # | Fila | Cita | Afirmación | Veredicto |
| --- | --- | --- | --- | --- |
| 1 | Cabecera | `CHANGELOG.md:6` | Entrada más nueva del 2026-11-01 | Sostiene |
| 2 | Cabecera | `conocimiento.md:18`, `:26` | Alias y versión 1.0 del conocimiento | Sostiene |
| 3 | Alias | `.github/workflows/framework-concept-demo.yml:12` | Ahí aparece el nombre de la máquina del runner | Sostiene |
| 4 | §1 | `AGENTS.md:50` | Enlaza la carpeta ausente del cuerpo `SDEI` | Sostiene |
| 5 | D-04 | `tools/docs-guard/prefijos.txt:1-5`, `tools/docs-guard/README.md:87` | Registro cerrado con ámbito; registro generado de IDs | Sostiene |
| 6 | D-06 | `Guides/Documentacion-Tecnica/Creacion-Guias-Tecnicas/README.md:1-11` | La guía no declara `version` | Sostiene |
| 7 | D-07 | `tools/docs-guard/prefijos.txt:27`, `:30`, `:17` | `RD`, `GP`, `ANX` registrados | Sostiene |
| 8 | D-09 | `.github/workflows/docs-guard.yml:32` | `workflow_call` (reutilizable) | Sostiene |
| 9 | D-10 | `tools/docs-guard/README.md:148-157` | Qué controles bloquean y cuáles avisan | Sostiene |
| 10 | D-10 | `CHANGELOG.md:37` | Guarda G1–G4 de la delegación | Sostiene |
| 11 | D-14 | `CHANGELOG.md:100` | Nombre de la máquina del runner en lo versionado | Sostiene |
| 12 | D-16 | `AGENTS.md:58` | «Leé» | Sostiene |
| 13 | D-16 | `Guides/README.md:17` | «seguí» | **Desplazada**: «seguí» está en la línea 16; la 17 es el enlace al README |
| 14 | §3 | `conocimiento.md:171` | Fila «Corpus de guías»: CL-02, CL-03, CL-08 a CL-13 | Sostiene |
| 15 | CL-01 | `conocimiento.md:313`; `tools/docs-guard/prefijos.txt:34-36` | La ficha es CL-01; `ADR`, `CU` son externos | Sostiene |
| 16 | CL-04 | `Concepts/Framework-Concept/Demo/Directory.Build.props:18` | Sólo `TreatWarningsAsErrors` | Sostiene |
| 17 | CL-11 | `Concepts/Framework-Concept/Conocimientos/Knowledge-App-Hibrida-OTA-Offline-First.md:4` | «Naturaleza: propio» | Sostiene |
| 18 | §4 | `AGENTS.md:105`, `:139`; `tools/docs-guard/README.md:178` | Cambiar `AGENTS.md` y `excepciones.txt` es clase H | Sostiene |
| 19 | S-3 | `CHANGELOG.md:12`, `:14` | Nombra `RD-01` y `RD-21` a `RD-27` | Sostiene |
| 20 | S-5 | `tools/docs-guard/esquemas/cuerpo.schema.json:18` | El vocabulario de `audience` no tiene «mantenedor» | Sostiene |

## 4. Conteo de invenciones

| Corrida | Inexistentes (script) | No sostiene (muestra de 20) | M4 estricto | Pasa (0) |
| --- | --- | --- | --- | --- |
| C0-r1 | 0 de 96 | 1: `.github/workflows/framework-concept-demo.yml:10-11` (desplazada una línea) | 1 | No, por desplazamiento |
| C0-r2 | 0 de 97 | 1: `Guides/README.md:17` (desplazada una línea) | 1 | No, por desplazamiento |

Ninguna cita apunta a un archivo inexistente ni a una línea fuera del archivo, y ninguna afirmación de la muestra es
falsa: los dos casos son errores de una línea con el texto citado en la línea contigua. Si M4 cuenta sólo las citas
fabricadas, las dos corridas dan 0; si cuenta además «la línea citada no lo dice», dan 1 cada una. La lectura de
cuál de las dos vale queda para la presidencia; este refutador informa ambas.

Lo no verificado: las 76 y 77 citas fuera de la muestra se comprobaron sólo por existencia (archivo y línea), no por
contenido. Las tres citas por nombre corto resuelven a un único archivo, pero no traen la ruta completa que pide la
forma `ruta:línea`.
