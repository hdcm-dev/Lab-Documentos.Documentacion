---
doc_id: DOC-LINEA-DE-BASE
doc_type: informe
title: Línea de base de la compuerta documental
description: Medición de cada control sobre lo que ya existe en Lab-Geometria antes de activar bloqueos.
status: borrador
origin: ia-generated
confidence: media
owner: Product Owner del laboratorio
last_review: 2026-11-01
audience: [desarrollo, agente]
traces: [DOC-ESQUEMA-FRONTMATTER@1.0]
version: 1.0
---

# Línea de base (A-08)

Medida el 2026-11-01 sobre la copia leída (sin `.git`; ver la ficha A-01, cabecera).

| Control | Corpus | Línea de base | Estado |
| --- | --- | --- | --- |
| Frontmatter con esquema (`docs-guard.py`) | `SDD/Docs` sin `_legacy` | 560 documentos; 585 errores (555 sin frontmatter, 15 campos faltantes en 5 con frontmatter propio, más prefijos y vocabularios) | avisa |
| Frontmatter con esquema | `docs/` | 0 | bloquea (cumple las cinco condiciones; ver A-01 D-10) |
| Enlaces relativos que resuelven (medición aparte) | `Lab-Geometria` sin `_legacy` | 6.587 enlaces; 23 rotos en 15 archivos | avisa |
| Enlaces y forma de la ia-db (`verificar.py`) | `Lab-Geometria.Documentacion` | 0 errores, 0 avisos | avisa hasta tener par rojo/verde propio |
| Trazas que resuelven y trazas desfasadas | `docs/` | 0 | bloquea |

El archivo de excepciones (`_gobierno/excepciones.txt`) arranca vacío.
