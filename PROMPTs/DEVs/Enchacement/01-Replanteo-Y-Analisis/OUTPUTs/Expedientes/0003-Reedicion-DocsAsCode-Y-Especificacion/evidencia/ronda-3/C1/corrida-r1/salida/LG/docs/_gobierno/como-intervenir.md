---
doc_id: PRC-COMO-INTERVENIR
doc_type: proceso
title: Cómo intervenir en la documentación de Lab-Geometria
description: Instancia del proceso Cómo intervenir con los seis campos contestados con datos del proyecto.
status: borrador
origin: ia-assisted
confidence: media
owner: Product Owner
last_review: 2026-11-02
audience: [humano, agente, desarrollo]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Cómo intervenir en la documentación

Propuesta en borrador, sujeta a las decisiones H abiertas de la ficha (D-03, D-09, D-11, D-12).

| Campo | Valor en este proyecto |
| --- | --- |
| Escenario y clases activas | Panel con roles (alumno y administrador). Clases activas: CL-01 a CL-09, CL-12 y CL-13; ver la [ficha](../_diseno/ficha-diseno-documental.md) §3 |
| Dónde vive cada pieza | Especificación y documentación técnica en `SDD/`; piezas del sistema documentador en `docs/`; índice para agentes y expedientes de trabajo en el repo hermano de documentación; README y registro de cambios en la raíz de cada repo |
| Guion de validación local | `.docs-guard/scripts/ci-local.sh {grupo} docs`, con `{grupo}` en enlaces, esquema, ai, estructura, trazas, contrato y fijadas; la autoprueba corre desde `.docs-guard-origen/` |
| Workflow y runner de la compuerta | `.github/workflows/docs-guard.yml`, en el runner Linux del proyecto. Registro de prefijos (A-02): `.docs-guard/tools/docs-guard/prefijos.txt`. Esquema (A-03): `.docs-guard/tools/docs-guard/esquemas/cuerpo.schema.json`. Excepciones (A-08): `.docs-guard/tools/docs-guard/excepciones.txt` |
| Quién decide y si hay delegación | El Product Owner decide lo de clase H. El merge está delegado al agente con checks en verde y sin reserva; el pull request de adopción lleva reserva y lo fusiona una persona |
| Excepciones a la plantilla | La especificación del marco SDD no lleva el frontmatter de diez campos: avisa como heredada y no se migra en la adopción |
