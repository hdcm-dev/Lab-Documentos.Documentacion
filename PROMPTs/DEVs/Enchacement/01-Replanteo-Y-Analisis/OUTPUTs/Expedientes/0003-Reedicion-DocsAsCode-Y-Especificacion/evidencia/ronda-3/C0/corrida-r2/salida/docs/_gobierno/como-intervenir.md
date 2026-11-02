---
doc_id: PRC-COMO-INTERVENIR
doc_type: proceso
title: Cómo intervenir en el sistema documentador del repositorio
description: Instancia del proceso «Cómo intervenir» para este repositorio, con los seis campos contestados.
status: borrador
origin: ia-generated
confidence: media
owner: aplicador
last_review: 2026-11-02
audience: [humano, agente]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Cómo intervenir en el sistema documentador del repositorio

Propuesta sujeta a D-09 y D-11 de la [ficha de diseño](../_diseno/ficha-diseno-documental.md). Puede existir otra
instancia dentro del cuerpo `SDEI`, que no se pudo leer: si existe, esta página se funde con ella y no se duplica.

| Campo | Valor |
| --- | --- |
| Escenario y clases activas | Corpus de guías. Activas: CL-01 (sólo la ficha), CL-02, CL-03, CL-09, CL-10, CL-12 y CL-13 |
| Dónde vive cada pieza | En este repositorio, salvo CL-09, que vive en el repo hermano de documentación (sin verificar en el hermano) |
| Guion de validación local | `scripts/ci-local.sh {grupo} docs`; registro de prefijos `tools/docs-guard/prefijos.txt` (A-02); esquema `tools/docs-guard/esquemas/cuerpo.schema.json` (A-03, sin cambios); excepciones `tools/docs-guard/excepciones.txt` (A-08, sin altas) |
| Workflow y runner de la compuerta | `.github/workflows/docs-guard.yml`, con la carpeta `docs` sumada a su RUTA (A-07); runner Linux del proyecto, `{etiqueta-runner}` |
| Quién decide y si hay delegación | Las delegaciones del merge vigentes están en `CHANGELOG.md`, cada una con su alcance; el PR de adopción tiene decisiones H abiertas: lleva reserva y lo fusiona una persona |
| Excepciones a la plantilla | La compuerta de origen y la del proyecto son la misma (este repositorio es el de la compuerta): no hay copia con huella ni copia de origen separada |
