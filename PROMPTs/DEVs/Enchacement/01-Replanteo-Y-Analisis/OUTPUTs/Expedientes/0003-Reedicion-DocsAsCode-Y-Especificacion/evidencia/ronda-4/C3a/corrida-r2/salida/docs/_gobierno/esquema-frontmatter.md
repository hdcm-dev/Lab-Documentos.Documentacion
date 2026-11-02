---
doc_id: FIC-ESQUEMA-FRONTMATTER
doc_type: anexo
title: Esquema de frontmatter y vocabulario de Colmenar
description: Nota que describe el esquema de frontmatter del proyecto y su vocabulario cerrado. Acompaña a A-03.
status: borrador
origin: ia-assisted
confidence: media
owner: aplicador
last_review: 2026-11-02
audience: [humano, agente, desarrollo]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Esquema de frontmatter y vocabulario de Colmenar

Nota de A-03 (D-08). El esquema JSON vive en `.docs-guard/tools/docs-guard/esquemas/cuerpo.schema.json` y lo lee la
compuerta. Diez campos más `description`; `confidence` obligatorio si `origin` no es `human`.

- **`doc_type`** (vocabulario del proyecto): `ficha`, `anexo`, `rrd`, `proceso`, `indice`, `guia-de-estudio`,
  `guia-practica`.
- **`audience`** (orienta la escritura, no da acceso): `humano`, `agente`, `desarrollo`, `qa`, `po`, `analista`,
  `persona-usuaria`, `estudiante`, `docente`. Los roles del panel van en `roles` del esquema de ayuda, no en
  `audience` (§5.2).
- **Norma de calidad.** Los procedimientos (CL-12) suman `aprobado_por` y `fecha_aprobacion` al esquema del proyecto
  por PR; no se igualan a `owner` ni a `last_review` (D-08; README.md:70-71). Pendiente de decidir por una persona.
- Lo heredado sin frontmatter avisa; lo nuevo con frontmatter bloquea (D-08, D-10).
