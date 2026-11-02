---
doc_id: FDD-ESQUEMA-FRONTMATTER
doc_type: anexo
title: Esquema de frontmatter y vocabulario de Colmenar
description: Campos del frontmatter y valores admitidos de doc_type y audience en la documentación de la app Colmenar.
status: borrador
origin: ia-generated
confidence: media
owner: pendiente (lo designa una persona, D-11)
last_review: 2026-11-01
audience: [desarrollo, agente]
traces: [FDD-FICHA-DISENO]
---

# Esquema de frontmatter y vocabulario

Propuesta sujeta a D-09: el esquema que lee la compuerta es `docs-guard/proyecto/tools/docs-guard/esquemas/cuerpo.schema.json`,
copia del de origen con el vocabulario de abajo. Ese JSON no se produjo: falta la compuerta de origen para copiar su
formato (demanda Q-1, contestada «no disponible»).

## Campos

Los diez campos más `description`: `doc_id`, `doc_type`, `title`, `description`, `status`, `origin`, `confidence`,
`owner`, `last_review`, `audience`, `traces`. `confidence` es obligatorio si `origin` no es `human`. Una pieza con
versión propia trazable la declara en `version`.

Pendiente: la norma de calidad de la cooperativa pide en todo procedimiento escrito código, versión, quién lo aprobó
y fecha de aprobación, y revisión cada 90 días como máximo. El código es `doc_id`, la versión es `version` y la
revisión es `last_review`; quién aprobó y la fecha de aprobación no tienen campo en el esquema. Cómo se agregan lo
decide quien mantiene el esquema (ver la ficha, §6).

## Vocabulario de `doc_type`

`ficha`, `anexo`, `rrd`, `proceso`, `operativa`, `guia-practica`, `indice`. Los demás valores de la lista de origen
(`tema`, `marco-de-referencia`, `familia`, `mapa`, `anexo-referencias`, `guia-de-estudio`, `study-note`) no se usan en
este repositorio; `guia-de-estudio` corresponde al repositorio dedicado del curso, si se crea.

## Vocabulario de `audience`

`humano`, `agente`, `desarrollo`, `qa`, `po`, `analista`, `persona-usuaria`, `integrador`, `docente`, `estudiante`.
`integrador` es valor nuevo del proyecto: quien consume el paquete público del modelo de datos.

Los perfiles de la app (productor, peón de campo, técnico sanitario, administración, inspector) no van en `audience`:
van en `roles` del esquema de ayuda.
