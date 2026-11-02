---
corpus_id: DOCS-LG
version: 0.1.0-borrador
title: Sistema documentador de Lab-Geometria
description: Cuerpo nuevo del sistema documentador; lo verifica la compuerta docs-guard en cada pull request.
---

# Sistema documentador de Lab-Geometria

Carpeta nueva de la adopción de la documentación como código. Todo documento de esta carpeta abre con el frontmatter
de [la nota de esquema](_gobierno/esquema-frontmatter.md) y lo verifica la compuerta de
[`.github/workflows/docs-guard.yml`](../.github/workflows/docs-guard.yml). El corpus `SDD/` queda como está: es
heredado y la compuerta no lo recibe.

| Pieza | Archivo |
| --- | --- |
| Ficha de diseño documental | [`_diseno/ficha-diseno-documental.md`](_diseno/ficha-diseno-documental.md) |
| Registro de requerimientos documentales | [`_requisitos.md`](_requisitos.md) |
| Nota del esquema de frontmatter | [`_gobierno/esquema-frontmatter.md`](_gobierno/esquema-frontmatter.md) |
| Cómo intervenir | [`_gobierno/como-intervenir.md`](_gobierno/como-intervenir.md) |
| Registro de audiencias | [`_gobierno/audiencias.md`](_gobierno/audiencias.md) |
| Línea de base y controles de entrega | [`_gobierno/linea-de-base.md`](_gobierno/linea-de-base.md) |

El registro de prefijos y el esquema viven en la copia de la compuerta, `.docs-guard/tools/docs-guard/`.
