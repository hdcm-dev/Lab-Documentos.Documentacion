---
doc_id: DOC-LABDOC-COMO-INTERVENIR
doc_type: proceso
title: Cómo intervenir en la documentación de Lab-Documentos
description: Instancia de una página del proceso «Cómo intervenir» para este repositorio, con los seis campos del diseño.
status: borrador
origin: ia-generated
confidence: media
owner: Lab-Documentos — diseño documental
last_review: 2026-11-01
audience: [humano, agente]
traces: [DOC-LABDOC-RRD@1.0, IDX-LABDOC-AGENTS]
---

# Cómo intervenir en la documentación de Lab-Documentos

Instancia del proceso para este repositorio. Cada campo sale de la ficha de diseño documental A-01; lo que la ficha
dejó «pendiente» o para una persona figura igual acá.

## Índice

1. [Escenario y clases activas](#1-escenario-y-clases-activas)
2. [Dónde vive cada pieza](#2-dónde-vive-cada-pieza)
3. [Guion de validación local](#3-guion-de-validación-local)
4. [Workflow y runner de la compuerta](#4-workflow-y-runner-de-la-compuerta)
5. [Quién decide y delegación](#5-quién-decide-y-delegación)
6. [Excepciones a la plantilla](#6-excepciones-a-la-plantilla)

## 1. Escenario y clases activas

Corpus de guías: guías de estudio y conceptos en Markdown, leídas en GitHub, sin sitio publicado. Clases activas:
CL-02, CL-03, CL-07, CL-08, CL-09, CL-10, CL-12 y CL-13. Frente a la fila del escenario, CL-07 entra por la demo
compilable de `Concepts/Framework-Concept/Demo/` y CL-11 sale porque no hay piezas fijadas.

## 2. Dónde vive cada pieza

| Clase | Dónde | Ancla |
| --- | --- | --- |
| CL-02 | `docs/_requisitos.md` | Commit |
| CL-03 | `AGENTS.md` en la raíz | Commit |
| CL-07 | `Concepts/Framework-Concept/Demo/`, junto al código | Commit |
| CL-08 | Repo hermano `.Documentacion` | SHA fijado y etiqueta: pendiente |
| CL-09 | Repo hermano `.Documentacion` | Commit del hermano; SHA fijado de este repo: pendiente |
| CL-10 | `Guides/` y `Concepts/` | Versión del cuerpo y etiqueta: pendiente |
| CL-12 | Esta página | Versión de la plantilla: pendiente |
| CL-13 | `README.md` y `CHANGELOG.md` en la raíz | Fecha de la entrada |

## 3. Guion de validación local

Desde la raíz del repositorio, `scripts/ci-local.sh todo CARPETA`, con la carpeta que se cambió. El guion corre los
mismos pasos que la CI. Hoy su carpeta por defecto no existe en el repositorio, así que hay que pasarla siempre.

## 4. Workflow y runner de la compuerta

`.github/workflows/docs-guard.yml` en cada pull request, con la etiqueta de runner del proyecto para Linux
(`{etiqueta-runner}`). El carril programado es `.github/workflows/docs-enlaces-semanal.yml`, los lunes, y sólo avisa.
Qué carpeta verifica la compuerta y si su check es obligatorio antes del merge lo decide una persona (A-01, §4).

## 5. Quién decide y delegación

Un agente propone (clase P); una persona decide lo de clase H: pasar a `vigente`, cambiar `AGENTS.md`,
`tools/docs-guard/excepciones.txt`, `tools/docs-guard/dominios.txt` o un workflow, y etiquetar. Las delegaciones del
merge asentadas en `CHANGELOG.md` cubren sólo los expedientes que nombran; fuera de ellas fusiona una persona.

## 6. Excepciones a la plantilla

Ninguna aprobada. Lo heredado de `Guides/` y `Concepts/` avisa hasta sanear su línea de base (A-08).
