---
doc_id: FIC-LINEA-DE-BASE
doc_type: anexo
title: Informe de línea de base de la compuerta de Colmenar
description: Línea de base por control antes de activar bloqueos; texto para la descripción del pull request de adopción.
status: borrador
origin: ia-generated
confidence: baja
owner: pendiente (D-11)
last_review: 2026-11-01
audience: [desarrollo, po]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Línea de base

Texto para la descripción del pull request de adopción. Archivo de excepciones:
`.docs-guard/proyecto/tools/docs-guard/excepciones.txt`, vacío.

| Control | Carpeta | Línea de base | Modo |
| --- | --- | --- | --- |
| Trazas e ID duplicado | raíz | pendiente: la compuerta de origen no se recibió | avisa |
| Esquema de frontmatter | `docs/` | pendiente: ídem; el único Markdown del repo, `README.md`, no tiene frontmatter | avisa |
| Enlaces | `docs/` | pendiente: ídem | avisa |
| Versión declarada dos veces | raíz | 0 (`grep -rlE '^version:' --include='*.md' . \| xargs -r grep -l 'Versión:\*\*'` sin salida) | avisa |
| Estado planificado | `docs/tecnica` | pendiente: la carpeta no existe | avisa |
| Trazas de la ayuda | `docs/ayuda` | pendiente: la carpeta no existe; `^traces:` da 0 en todo el repo | avisa |

Todo avisa: la línea de base no está medida y la obligatoriedad de checks del plan no tiene evidencia de
configuración (D-10).
