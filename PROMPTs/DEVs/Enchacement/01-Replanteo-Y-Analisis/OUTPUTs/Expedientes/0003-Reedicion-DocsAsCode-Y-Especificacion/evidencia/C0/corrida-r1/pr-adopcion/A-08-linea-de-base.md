# Informe de línea de base de la compuerta documental (A-08)

Cuerpo del pull request de adopción del diseño documental (ficha A-01). No es un archivo del repositorio: va en la
descripción del pull request. Medido sobre la copia del repositorio que se entregó al aplicador (sin `.git`: SHA
pendiente), el 2026-11-01, con `python3 -I -B tools/docs-guard/dg.py CONTROL CARPETA --raiz .` desde la raíz. Las
salidas completas están en `salida/_inventario/`.

## Por control

| Grupo | Control | `Guides/` | `Concepts/` | Raíz (`AGENTS.md`, `README.md`, `Guides/README.md`) | ¿Bloquea hoy? |
| --- | --- | --- | --- | --- | --- |
| PR-1 | `fuera` (relativos que salen del repo) | 0 errores | 0 errores | — | Puede bloquear: línea de base 0 |
| PR-1 | lychee `--offline` (enlaces y anclas) | pendiente: no medido | pendiente: no medido | pendiente: no medido | Pendiente: lychee se baja de la red y el aplicador no tiene red |
| PR-2 | `esquema` | 309 errores, 30 avisos (207 archivos con frontmatter, 71 sin él) | 16 errores | — | Avisa: línea de base distinta de 0 |
| PR-3 | `ai` | 824 errores (AI-1 354, AI-2 3, AI-4 552, AI-5 2), 100 avisos (AI-3 13) | 108 errores (AI-1 38, AI-4 70) | `AGENTS.md`: 0 errores, 1 aviso AI-3 | Avisa en lo heredado |
| PR-4 | markdownlint-cli2 y `mermaid-parse` | pendiente: no medido | pendiente: no medido | pendiente: no medido | Pendiente: herramientas por red |
| PR-4 | `mermaid-arroba` | 0 (273 bloques) | 0 (50 bloques) | — | Puede bloquear: línea de base 0 |
| PR-5 | `trazas` | 1404 errores (602 IDs duplicados) | 4 errores (4 IDs duplicados) | 8 errores más: trazas a IDs que no están en la copia | Avisa: línea de base distinta de 0 |
| PR-6 | `contratos` | no aplica: sin `contracts/openapi.json` | no aplica | — | — |
| PR-7 | `fijadas` | no aplica: 0 piezas | no aplica: 0 piezas | — | — |
| PR-7 | `reflint` | 0 (51 referencias) | 0 | — | Puede bloquear: línea de base 0 |
| PR-7 | `url-fecha` | 0 errores, 854 avisos | 0 errores, 93 avisos | — | Avisa en lo heredado (no hay cuerpo nuevo) |
| — | `frescura` (365 días) | 0 avisos (220 documentos con `last_review`) | incluido | — | Carril programado: sólo avisa |

## Hallazgos que cambian la adopción

1. La carpeta por defecto de la compuerta, `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion`,
   no existe en la copia: `dg.py esquema` sobre ella termina con «ERROR: no existe …» y código 2. La usan
   `.github/workflows/docs-guard.yml` (líneas 38 y 63) y `scripts/ci-local.sh` (línea 35).
2. Ningún `README.md` fuera de `tools/docs-guard/fixtures/` declara `corpus_id`: no hay «cuerpo nuevo», así que todo
   lo que hay es heredado.
3. La huella de `AGENTS.md` en `tools/docs-guard/excepciones.txt` (línea 7 del archivo, `f12ab882…`) no coincide con
   la del archivo (`sha256sum AGENTS.md` da `26d0e20c…`): la excepción de AI-3 no rige y AI-3 avisa en la línea 17.
   Renovarla es de clase H.
4. Carpetas con línea de base 0 en `esquema`, `ai` y `trazas` a la vez: `Guides/Dot-NET-Arquitectura-Guide/Examples/`,
   `Guides/Dot-NET-Arquitectura-Guide/Exercices/` y `Guides/IA/Claude-Guide.md/`. Son las únicas candidatas a que la
   compuerta bloquee sobre ellas con el parámetro `ruta` sin sanear antes.
5. Los IDs duplicados (602 en `Guides/`) vienen de guías que repiten los mismos `doc_id` y encabezados (`MARCO-ACTORES`,
   `ACT-01`, `ESC-1`, `GUIA-INDICE`…). Sanearlos es una migración aparte, con su propia decisión.

## Archivo de excepciones

`tools/docs-guard/excepciones.txt` ya existe con una excepción (la de `AGENTS.md`, hoy vencida). El diseño no lo
vacía ni lo cambia: tocarlo es de clase H (`AGENTS.md`, línea 105).
