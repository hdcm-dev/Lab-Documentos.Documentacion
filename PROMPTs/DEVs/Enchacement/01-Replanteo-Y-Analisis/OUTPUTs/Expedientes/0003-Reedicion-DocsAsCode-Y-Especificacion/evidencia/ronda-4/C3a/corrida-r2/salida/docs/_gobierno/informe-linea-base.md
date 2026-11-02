---
doc_id: FIC-LINEA-BASE
doc_type: anexo
title: Informe de línea de base de la compuerta — Colmenar
description: "Línea de base de cada control antes de activar su bloqueo (A-08). Proyecto nuevo: 0 por construcción."
status: borrador
origin: ia-assisted
confidence: media
owner: aplicador
last_review: 2026-11-02
audience: [humano, desarrollo]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Informe de línea de base de la compuerta — Colmenar

Propuesta (A-08, D-10). El informe va en la descripción del PR de adopción; el `excepciones.txt` vacío vive en
`.docs-guard/tools/docs-guard/excepciones.txt`. El repo no tiene documentación con frontmatter (sólo `README.md` de
código, sin frontmatter): es **proyecto nuevo** para la documentación (§3.4), con línea de base 0 por construcción.

| Control (grupo) | Línea de base | Medida con |
| --- | --- | --- |
| `trazas` (PR-5) id-duplicado / traces-resolve | 0 | comando 1: `dg.py trazas` → «verde errores=0 ids-duplicados=0» |
| `esquema` (PR-2) | 0 | no hay documentos con frontmatter en el repo (comando 1b = 0) |
| `fuera` (PR-1) enlaces | 0 | no hay `.md` versionados fuera de `README.md` |
| `ai` (PR-3) anti-inyección | 0 | sin documentos del cuerpo |
| `mermaid-arroba` (PR-4) | 0 | sin bloques mermaid |
| `url-fecha` / `reflint` (PR-7) | 0 | sin documentos del cuerpo nuevos |

Controles de entrega (A-13): avisan hasta tener su par rojo/verde (DE-30). Volver obligatorio el check es un acto
de clase H (A-01 §4): la plataforma del alojamiento lo permite (README.md:98-99).
