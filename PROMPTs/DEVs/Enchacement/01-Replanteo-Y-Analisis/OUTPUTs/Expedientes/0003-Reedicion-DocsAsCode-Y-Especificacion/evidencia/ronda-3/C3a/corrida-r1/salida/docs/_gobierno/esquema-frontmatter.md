---
doc_id: FIC-ESQUEMA
doc_type: anexo
title: Esquema de frontmatter de Colmenar
description: Nota del esquema de frontmatter y su vocabulario; el esquema vive en la copia de la compuerta.
status: borrador
origin: ia-generated
confidence: media
owner: equipo de la app
last_review: 2026-11-02
audience: [humano, desarrollo]
traces: [FIC-FICHA]
---

# Esquema de frontmatter de Colmenar

Propuesta sujeta a D-09 (ruta de la copia de la compuerta). El esquema es
`.docs-guard/tools/docs-guard/esquemas/cuerpo.schema.json`: los diez campos más `description`.

- `doc_type`: `ficha`, `anexo`, `rrd`, `proceso`, `registro-audiencias`, `operativa`.
- `audience` (orienta la escritura, no da acceso): `humano`, `desarrollo`, `qa`, `devops`, `po`, `analista`,
  `persona-usuaria`. Los perfiles de la app van en `roles` del esquema de ayuda y la entrega, en `delivery:`, cerrado a
  las audiencias del registro de audiencias (`AUD-REGISTRO`).
- Norma de calidad: todo procedimiento escrito lleva código, versión, quién lo aprobó y fecha de aprobación. El código
  es `doc_id`; la versión va en `version`; aprobador y fecha de aprobación van en el cuerpo, bajo «Aprobación», hasta
  que una persona sume los campos al esquema por PR. No se igualan a `owner` ni a `last_review`.
- Ningún procedimiento pasa más de 90 días sin revisarse: el carril programado lo vigila con `last_review`.
