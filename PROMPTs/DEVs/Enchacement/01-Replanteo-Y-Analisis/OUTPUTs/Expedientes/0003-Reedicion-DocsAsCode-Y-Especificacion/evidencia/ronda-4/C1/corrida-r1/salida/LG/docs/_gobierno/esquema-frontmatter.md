---
doc_id: FIC-ESQUEMA
doc_type: anexo
title: Esquema de frontmatter y vocabulario del sistema documentador
description: Los diez campos más description y el vocabulario de doc_type y audience que usa la carpeta docs/.
status: borrador
origin: ia-generated
confidence: media
owner: Product Owner
last_review: 2026-11-02
audience: [desarrollo, agente, po]
traces: [FIC-FICHA]
---

# Esquema de frontmatter y vocabulario

El esquema es `.docs-guard/tools/docs-guard/esquemas/cuerpo.schema.json` (A-03 de la
[ficha](../_diseno/ficha-diseno-documental.md)). Vale para la carpeta `docs/`; el corpus `SDD/` conserva el suyo
(`doc_id`, `doc_type`, `status`, `rol_intervencion`, `owner`, `version`, `last_review`, `momento`, `traces`) y la tabla
de cabecera de cada documento, y no se migra en esta adopción.

## Campos

`doc_id`, `doc_type`, `title`, `description` (de 10 a 160 caracteres), `status` (`borrador`, `vigente`, `obsoleto`),
`origin` (`human`, `ia-assisted`, `ia-generated`), `confidence` (obligatorio si `origin` no es `human`), `owner`,
`last_review` (`AAAA-MM-DD`), `audience` y `traces` (`ID` o `ID@MAYOR.MENOR`). Un documento declara su ID una sola
vez, en `doc_id`, y su H1 no lo repite.

## Vocabulario

| Campo | Valores | De dónde sale |
| --- | --- | --- |
| `doc_type` | `ficha`, `anexo`, `rrd`, `proceso`, `registro-audiencias` | Los tipos de los artefactos de la adopción |
| `audience` | `humano`, `agente`, `desarrollo`, `qa`, `devops`, `po`, `alumno`, `docente` | Los roles de lectura del README del corpus SDD y las dos personas del aula |

`audience` orienta la escritura y no da acceso. A quién se entrega una pieza lo dice el
[registro de audiencias](audiencias.md). Un valor nuevo entra por pull request en el esquema de la copia y en esta
tabla, nunca en la compuerta de origen (`.docs-guard-origen/`).

## Términos que no se traducen

Las claves del frontmatter, los IDs y prefijos (`FIC`, `PRC`, `RD`, `AUD` y las familias SDD), los valores del
contrato (`Student`, `Administrator`, rutas `/v1/`, códigos de condición) y los nombres de código en inglés.
