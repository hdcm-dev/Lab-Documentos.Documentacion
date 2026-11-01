---
doc_id: SDOC-ESQUEMA-FRONTMATTER
doc_type: anexo
title: Esquema de frontmatter del sistema documentador
description: Campos obligatorios del frontmatter de las piezas nuevas y su correspondencia con el esquema que ya usa el corpus SDD.
status: borrador
origin: ia-generated
confidence: media
owner: pendiente (lo asigna una persona; ver A-01 §4)
last_review: 2026-11-01
audience: [desarrollo, agente]
traces: [SDOC-PREFIJOS]
---

# Esquema de frontmatter (A-03)

**Piezas nuevas** (fuera de lo que emite el marco SDD): diez campos más `description`, todos obligatorios;
`confidence` es obligatorio si `origin` no es `human`.

| Campo | Valores |
| --- | --- |
| `doc_id` | `{PREFIJO}-{SUFIJO}`, prefijo interno de `_prefijos.md` |
| `doc_type` | vocabulario cerrado: **pendiente**, el vocabulario completo no está en lo leído; en uso: `anexo`, `ficha`, `proceso` |
| `title` | texto |
| `description` | de 10 a 160 caracteres |
| `status` | `borrador` · `vigente` · `obsoleto`; pasar a `vigente` es acto de una persona |
| `origin` | `human` · `ia-assisted` · `ia-generated` |
| `confidence` | `alta` · `media` · `baja` |
| `owner` | responsable |
| `last_review` | `AAAA-MM-DD` |
| `audience` | lista |
| `traces` | lista de `ID` o `ID@MAYOR.MENOR` |

**Lo heredado avisa.** El corpus `SDD/` usa otro esquema (ejemplo: `SDD/Docs/Producto/11-Documentacion/Contrato-Agentes.md:1-14`:
`doc_id`, `doc_type`, `title`, `status`, `rol_intervencion`, `owner`, `version`, `last_review`, `momento`,
`traces`) y sólo 12 de 1288 archivos Markdown lo llevan (`salida/inventario/paso-1.txt`). Esos archivos no
se migran con la adopción: un control de frontmatter sobre ellos avisa.

| SDD | Este esquema |
| --- | --- |
| `doc_id`, `doc_type`, `title`, `owner`, `last_review`, `traces` | mismo campo |
| `status` (`Vigente`, `Aprobado`) | `status`; correspondencia de valores **pendiente** de una persona |
| `version` | `version` (pieza con versión propia trazable) |
| `rol_intervencion`, `momento` | sin equivalente; se conservan |
| — | `description`, `origin`, `confidence`, `audience`: faltan en SDD |
