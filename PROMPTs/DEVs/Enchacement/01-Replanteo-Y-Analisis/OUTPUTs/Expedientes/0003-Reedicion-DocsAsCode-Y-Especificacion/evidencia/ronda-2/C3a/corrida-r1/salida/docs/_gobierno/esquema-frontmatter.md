---
doc_id: FIC-ESQUEMA-FRONTMATTER
doc_type: anexo
title: Esquema de frontmatter y vocabulario de Colmenar
description: Campos obligatorios, vocabulario de doc_type y audience, y extensión para procesos de la norma de calidad.
status: borrador
origin: ia-generated
confidence: media
owner: pendiente (D-11)
last_review: 2026-11-01
audience: [desarrollo, agente, po]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Esquema de frontmatter y vocabulario

Propuesta sujeta a D-09: el esquema ejecutable es el `esquemas/cuerpo.schema.json` de la copia de la compuerta;
esta nota lo describe. El archivo JSON no se produjo porque la compuerta de origen no se recibió.

## Campos

Los diez campos más `description`: `doc_id`, `doc_type`, `title`, `description` (10 a 160 caracteres), `status`
(`borrador`, `vigente`, `obsoleto`), `origin` (`human`, `ia-assisted`, `ia-generated`), `confidence` (obligatorio
si `origin` no es `human`), `owner`, `last_review` (AAAA-MM-DD), `audience`, `traces`.

## Extensión para procesos (`doc_type: proceso`)

La norma de calidad de la cooperativa pide en todo procedimiento escrito código, versión, quién lo aprobó y fecha de
aprobación, y una revisión cada 90 días como máximo (`README.md:70-71`). Mapeo:

| Exigencia de la norma | Campo |
| --- | --- |
| Código | `doc_id` (prefijo `PRC`) |
| Versión | `version` |
| Quién lo aprobó | `approved_by` |
| Fecha de aprobación | `approval_date` |
| Revisión cada 90 días | `last_review`, con frescura de 90 días en el carril programado |

## Vocabulario

- `doc_type`: `ficha`, `anexo`, `rrd`, `proceso`, `guia-de-estudio`, `guia-practica`, `indice`.
- `audience`: `humano`, `agente`, `desarrollo`, `qa`, `devops`, `po`, `analista`, `persona-usuaria`, `estudiante`,
  `docente`, `integrador`.
- `roles` (sólo ayuda al usuario final): `productor`, `peon`, `tecnico-sanitario`, `administracion`, `inspector`
  (`README.md:16-22`). `inspector` queda sujeto a lo no decidido en `README.md:105`.
