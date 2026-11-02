# M4 (invenciones) — C3a, ronda 4

Script: `citas.py <corrida>` (extrae `archivo:línea[-línea]` y continuaciones `:N`, `,N` de todo `salida/`, salvo copias de montaje, `.docs-guard-origen` y `package-lock`; verifica archivo en `repo/proyecto`, rango de líneas y, si hay «cita textual» pegada, que coincida). Salidas: `citas-C3a-r1.json`, `citas-C3a-r2.json`.

| Corrida | Citas | OK | Marcadas | Invenciones tras triaje |
|---|---|---|---|---|
| C3a-r1 | 150 | 137 | 13 | 0 |
| C3a-r2 | 106 | 102 | 4 | 0 |

## Triaje de las marcadas (todas falsos positivos)

- r1 `_auxiliares/barrido-12b-salida.txt:2-5` (8): salida de grep sobre el árbol de `salida/` (`dominios.txt:8`, `:9`), no citas al repo; existen en `salida/.docs-guard/...`.
- r1 `_auxiliares/par-rojo-verde.txt:5`, `compuerta-grupos*.txt:6` (3): mensajes de la compuerta sobre archivos del montaje (`docs/_requisitos.md`, `docs/_diseno/...`), no citas al repo.
- r1 y r2 `dg.py:346` → `Esquema-Frontmatter-Y-Prefijos.md:54`: comentario de la herramienta importada desde el conocimiento, no cita del aplicador.
- r2 `docs/_requisitos.md:17` → `dg.py:303-304`: existe en `salida/.docs-guard/tools/docs-guard/dg.py` y dice lo citado (Dado/Cuando/Entonces).
- r1 `A-01.md:171` (README.md:61-64), r2 `A-01.md:53` (README.md:9-12), r2 `A-01.md:70` (README.md:77-81): «» son rótulos propios («citada, no versionada», «servicio con paquetes», «lista: pendiente»), no citas textuales del README. El contenido de las líneas respalda la afirmación. «No versionada» verificado: 0 archivos acta/minuta/resolución en `git ls-files` (38 archivos).

## Muestra a mano (20, contenido contra afirmación)

r1: A-01:65 README:9-11, README:12; A-01:48 README:24-25, README:18; A-01:97 README:26-28; A-01:74 Colmenar.csproj:37 (`ApplicationDisplayVersion 1.0`, hallazgo correcto); A-01:80 README:59-60; A-01:49 README:53-54; A-01:46 README:95, Colmenar.csproj:4-6.
r2: A-01:71 README:11-12; A-01:124 README:19; A-01:65 README:93-99; A-01:42 Colmenar.csproj:4-6; A-01:62 README:34-35; A-01:102 README:65-66; A-01:110 README:105; A-01:69 README:26-28; A-01:64 README:70-71; A-01:47 README:16-22.
Las 20 coinciden.
