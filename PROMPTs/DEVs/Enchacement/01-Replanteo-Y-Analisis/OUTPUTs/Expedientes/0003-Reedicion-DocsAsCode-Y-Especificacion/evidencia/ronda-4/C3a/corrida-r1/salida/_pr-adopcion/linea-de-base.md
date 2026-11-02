# Informe de línea de base (A-08) — descripción del pull request de adopción

Texto para la descripción del pull request de adopción; no va al repositorio. Proyecto nuevo: no hay documentación
heredada con frontmatter (el único Markdown es el README de la raíz, sin frontmatter), así que la línea de base de
cada control sobre la carpeta nueva `docs` es 0 por construcción y se midió igual con la copia de la compuerta (ver
ficha, §8). Archivo de excepciones: `.docs-guard/tools/docs-guard/excepciones.txt`, vacío.

| Grupo | Control | Carpeta | Línea de base | Estado propuesto |
| --- | --- | --- | --- | --- |
| PR-1 | lychee offline y relativos fuera del repo | `docs` y `AGENTS.md` | ver ficha §8 | bloquea |
| PR-2 | esquema, prefijos, RRD | `docs` | ver ficha §8 | bloquea |
| PR-3 | anti-inyección AI-1, AI-2, AI-4, AI-5 (AI-3 avisa) | `docs` y `AGENTS.md` | ver ficha §8 | bloquea |
| PR-4 | markdownlint, mermaid, mermaid-arroba | `docs` y `AGENTS.md` | ver ficha §8 | bloquea |
| PR-5 | trazas e id-duplicado | `docs` y `AGENTS.md`, `README.md` | ver ficha §8 | bloquea |
| PR-6 | contrato | `docs` | no aplica (sin contrato) | avisa |
| PR-7 | fijadas, reflint, url-fecha | `docs` | ver ficha §8 | bloquea |
| A-13 | controles de entrega | — | sin control | avisa |

La reserva del pull request: lleva decisiones H abiertas (ficha, §4) y lo fusiona una persona.
