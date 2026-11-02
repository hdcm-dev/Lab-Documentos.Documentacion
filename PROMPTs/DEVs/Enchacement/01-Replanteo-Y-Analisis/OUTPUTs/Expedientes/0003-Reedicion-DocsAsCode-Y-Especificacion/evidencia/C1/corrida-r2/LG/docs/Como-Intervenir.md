---
doc_id: DOC-COMO-INTERVENIR
doc_type: proceso
title: Cómo intervenir en la documentación de Lab-Geometria
description: Escenario, ubicación de piezas, validación local, compuerta, decisiones y excepciones del sistema documentador.
status: borrador
origin: ia-generated
confidence: media
owner: Product Owner del laboratorio
last_review: 2026-11-01
audience: [desarrollo, agente]
traces: [DOC-ESQUEMA-FRONTMATTER@1.0, DOC-RRD@1.0, DOC-LINEA-DE-BASE@1.0]
version: 1.0
---

# Cómo intervenir (A-06)

| Campo | Valor en este proyecto |
| --- | --- |
| Escenario y clases activas | Panel con roles (alumno y administrador). Activas: CL-01 a CL-09, CL-12 y CL-13. Detalle y motivos en la ficha A-01 §3 |
| Dónde vive cada pieza | Especificación SDD en `SDD/` de `Lab-Geometria`; documentación del sistema documentador en `docs/`; `AGENTS.md` y `changelog.md` en la raíz de cada repo; ia-db, análisis y prompts en `Lab-Geometria.Documentacion` |
| Guion de validación local | `bash scripts/docs-guard.sh` (verifica `docs/`); `bash scripts/docs-guard.sh --linea-de-base SDD/Docs` mide lo heredado sin bloquear |
| Workflow y runner de la compuerta | `.github/workflows/docs-guard.yml`; runner propuesto `ubuntu-latest`, pendiente de la decisión D-09 |
| Quién decide y delegación | Decide el Product Owner del laboratorio (`equipo_n = 1`). La delegación del merge al agente consta en `AGENTS.md` (límites) y en el README de `Lab-Geometria.Documentacion` (sección «Delegación del merge al agente») |
| Excepciones a la plantilla | `docs/` es la única carpeta que bloquea; `SDD/` conserva su frontmatter propio y avisa (ver [línea de base](_gobierno/Linea-De-Base.md)). `AGENTS.md` de `Lab-Geometria` es un derivado de `Contrato-Agentes.md` y no un puntero (decisión D-12 pendiente) |

Los requerimientos que esta página atiende están en el [registro](_requisitos.md); el esquema, en
[`_gobierno/Esquema-Frontmatter.md`](_gobierno/Esquema-Frontmatter.md).
