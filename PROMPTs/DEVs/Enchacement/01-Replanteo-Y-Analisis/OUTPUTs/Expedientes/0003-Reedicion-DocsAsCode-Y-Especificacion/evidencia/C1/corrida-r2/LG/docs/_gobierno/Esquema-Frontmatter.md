---
doc_id: DOC-ESQUEMA-FRONTMATTER
doc_type: esquema
title: Esquema de frontmatter de la documentación
description: Campos obligatorios, vocabularios y regla de adopción del frontmatter para docs/ en Lab-Geometria.
status: borrador
origin: ia-generated
confidence: media
owner: Product Owner del laboratorio
last_review: 2026-11-01
audience: [desarrollo, agente]
traces: []
version: 1.0
---

# Esquema de frontmatter (A-03)

Rige para todo documento nuevo bajo `docs/`. Lo comprueba `scripts/docs-guard.py`.

| Campo | Obligatorio | Valores |
| --- | --- | --- |
| `doc_id` | sí | `{PREFIJO}-{SUFIJO}`, prefijo interno de [`prefijos.txt`](prefijos.txt) |
| `doc_type` | sí | esquema, proceso, requisitos, informe, ficha |
| `title` | sí | texto |
| `description` | sí | de 10 a 160 caracteres |
| `status` | sí | `borrador`, `vigente`, `obsoleto`; pasar a `vigente` lo hace una persona |
| `origin` | sí | `human`, `ia-assisted`, `ia-generated` |
| `confidence` | si `origin` no es `human` | `alta`, `media`, `baja` |
| `owner` | sí | responsable |
| `last_review` | sí | `AAAA-MM-DD` |
| `audience` | sí | lista |
| `traces` | sí | lista de `ID` o `ID@MAYOR.MENOR` |
| `version` | si la pieza se traza con versión | `MAYOR.MENOR` |

**Lo heredado.** El corpus `SDD/` usa otro frontmatter (12 de 1.288 archivos `.md` lo llevan; ver
el informe de línea de base). No se migra en esta adopción: se mide y avisa. Su migración es una
decisión aparte.
