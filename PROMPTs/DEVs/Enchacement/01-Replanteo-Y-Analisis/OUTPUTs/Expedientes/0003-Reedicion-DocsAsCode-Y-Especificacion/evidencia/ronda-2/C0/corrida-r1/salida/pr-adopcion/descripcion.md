# Adopción del diseño documental (A-01) — informe de línea de base (A-08)

Descripción del pull request de adopción. Agrega la ficha de diseño documental
`docs/_diseno/ficha-diseno-documental.md` (A-01, `borrador`) y su entrada del CHANGELOG. No cambia la compuerta,
su configuración, `AGENTS.md` ni ninguna guía.

## Línea de base por control y carpeta

Medida con `python3 -I -B tools/docs-guard/dg.py CONTROL --raiz . CARPETA` desde la raíz del repositorio, antes de
activar cualquier bloqueo. «Punteros» = `AGENTS.md README.md Guides/README.md`. Salidas completas en
`salida/_trabajo/base/` del lugar de trabajo del aplicador.

| Control (grupo) | `Guides/` | `Concepts/` | Punteros | `docs/_diseno/` (nuevo) | Bloquea o avisa |
| --- | --- | --- | --- | --- | --- |
| `fuera` (PR-1) | 0 | 0 | 0 | — | Bloquea según la tabla del proyecto |
| lychee (PR-1) | sin medir: sin red | sin medir | sin medir | sin medir | Pendiente |
| `esquema` (PR-2) | 309 errores, 30 avisos | 16 errores | 4 errores | 0 | Avisa en lo heredado; bloquea en lo nuevo |
| `ai` (PR-3) | 824 errores (AI-1=354, AI-2=3, AI-4=552, AI-5=2), AI-3=13 | 108 errores (AI-1=38, AI-4=70) | 0 errores, AI-3=1 | 0 errores (AI-3=1 por `AGENTS.md`) | Avisa en lo heredado; bloquea en lo nuevo |
| markdownlint y mermaid (PR-4) | sin medir: sin red | sin medir | sin medir | sin medir | Pendiente |
| `mermaid-arroba` (PR-4) | 0 (273 bloques) | 0 (50 bloques) | 0 | — | Bloquea |
| `trazas` (PR-5) | 1404 errores, 602 `id-duplicado` | 4 errores, 4 `id-duplicado` | 8 errores | 0 sin punteros | Avisa en lo heredado; bloquea en lo nuevo |
| `contratos` (PR-6) | 0 | 0 | — | 0 | Bloquea |
| `fijadas` (PR-7) | 0 (0 piezas) | 0 | — | 0 | Bloquea |
| `reflint` (PR-7) | 0 (51 referencias) | 0 | — | 0 | Avisa en lo heredado (tabla del proyecto) |
| `url-fecha` (PR-7) | 0 errores, 854 avisos | 0 errores, 93 avisos | — | 0 | Avisa en lo heredado |
| RUTA por defecto (cuerpo `SDEI`) | — | — | — | — | Pendiente: carpeta no legible en la copia recibida |

## Prefijos heredados fuera del registro

18 prefijos en uso que no están en `tools/docs-guard/prefijos.txt`: AG, AIP, ANALISIS, ANEXO, CUADERNO, D, E2E, EP,
F, G, GF, GHA, GHF, GUIA, GUIAS, LAB, N, US. 56 IDs se declaran más de una vez en la raíz (606 hallazgos
`id-duplicado`). No se resuelven en esta adopción: van a un saneamiento aparte, de clase P.

## Excepciones

`tools/docs-guard/excepciones.txt` ya existe (una excepción de AI-3 para `AGENTS.md`). Su huella no coincide con la
del archivo actual, así que AI-3 vuelve a avisar en `AGENTS.md`. Renovarla es de clase H: la aprueba una persona en
otro pull request.

## Quién fusiona

El PR no cae en el alcance de ninguna delegación asentada en el CHANGELOG: lo fusiona una persona.
