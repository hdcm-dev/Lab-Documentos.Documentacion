---
doc_id: PRC-01
doc_type: proceso
title: Cómo intervenir — Fábrica de Geometría
description: Instancia del proceso Cómo intervenir para Lab-Geometria y su repo hermano de documentación.
status: borrador
origin: ia-generated
confidence: media
owner: pendiente (D-11)
last_review: 2026-11-01
audience: [desarrollo, agente, po]
traces: [FDD-01]
---

# PRC-01 — Cómo intervenir

**Versión:** 0.1

> Propuesta del aplicador (A-06), sujeta a D-09 y D-11. `doc_type`/`audience` sujetos a A-03 (pendiente).
> `FDD-01` es el ID propuesto para la ficha A-01 cuando entre al repo.

| Campo | Valor del proyecto |
| --- | --- |
| Escenario y clases activas | Panel con roles (`Student`, `Administrator`). Activas: CL-01 a CL-09, CL-12, CL-13. Ver A-01 §3 |
| Dónde vive cada pieza | Especificación SDD en `SDD/Docs/` (`LG`); técnica en `SDD/Docs/Unidades-Entrega/*/05-*, 09-*, 11-*` y `samples/*/README.md`; `AGENTS.md` en la raíz (derivado de `SDD/Docs/Producto/11-Documentacion/Contrato-Agentes.md`); índice para agentes en `ia-db/` del repo hermano `.Documentacion`; expedientes en `SDD/Expedientes/` y `Analisis/`, `PROMPTs/` del hermano; README y changelog en cada repo; RRD en `docs/_requisitos.md` |
| Guion de validación local | Producto: `bash scripts/build.sh`, `bash scripts/test.sh`, `bash scripts/coverage.sh`. Documentación: `{copia-proyecto}/scripts/ci-local.sh {grupo} docs` — pendiente: la copia de la compuerta (D-09). En el hermano: `python .github/scripts/verificar.py` |
| Workflow y runner de la compuerta | Pendiente de D-09 (persona). Default: copia con huella de la compuerta de origen, con `{copia-proyecto}` = `docs/_gobierno/compuerta/` y `{copia-origen}` = `docs/_gobierno/compuerta-origen/`, en el runner Linux del proyecto |
| Quién decide y si hay delegación | Decide el Product Owner. Delegación del merge en `LG` (checks en verde, sin reserva) y en el hermano (guarda G1–G4, sin reserva); fuera de ellas fusiona una persona. Pendiente de confirmación en D-11 |
| Excepciones a la plantilla | La compuerta corre como copia con huella (no el reutilizable): el registro de prefijos A-02 vive en `docs/_gobierno/compuerta/tools/docs-guard/prefijos.txt`; el esquema A-03 en `docs/_gobierno/compuerta/tools/docs-guard/esquemas/cuerpo.schema.json` (pendiente); las excepciones A-08 en `docs/_gobierno/compuerta/tools/docs-guard/excepciones.txt` (pendiente) |
