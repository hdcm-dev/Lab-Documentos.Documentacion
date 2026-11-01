---
doc_id: GP-LD-INTERVENIR
doc_type: proceso
title: Cómo intervenir en la documentación de Lab-Documentos
description: Instancia del proceso «Cómo intervenir» para este repositorio, con los seis campos que pide la plantilla.
status: borrador
origin: ia-generated
confidence: media
owner: Lab-Documentos — guía del sistema documentador
last_review: 2026-11-01
audience: [humano, agente]
traces: [RD-LD-REGISTRO]
version: 1.0
---

# Cómo intervenir en la documentación de Lab-Documentos

Instancia del proceso «Cómo intervenir» (A-06 de la ficha de diseño documental A-01). Contesta los seis campos de la
plantilla con datos del repositorio. Lo que la ficha dejó pendiente o para una persona se dice en cada campo.

## Índice

1. [Escenario y clases activas](#1-escenario-y-clases-activas)
2. [Dónde vive cada pieza](#2-dónde-vive-cada-pieza)
3. [Guion de validación local](#3-guion-de-validación-local)
4. [Workflow y runner de la compuerta](#4-workflow-y-runner-de-la-compuerta)
5. [Quién decide y delegación](#5-quién-decide-y-delegación)
6. [Excepciones a la plantilla](#6-excepciones-a-la-plantilla)

## 1. Escenario y clases activas

Escenario: **corpus de guías**. El repositorio reúne guías de estudio y conceptos escritos en Markdown y leídos sin
sitio publicado.

Clases activas: CL-01 (sólo la ficha de diseño documental), CL-02, CL-03, CL-08, CL-09, CL-10, CL-12 y CL-13. CL-11
queda de baja: no hay copias fijadas con huella en el repositorio. El detalle de cada alta y baja está en la sección 3
de la ficha A-01.

## 2. Dónde vive cada pieza

| Pieza | Clase | Dónde | Ancla |
| --- | --- | --- | --- |
| Ficha de diseño documental | CL-01 | Este repositorio | Commit |
| Registro de requerimientos documentales | CL-02 | `docs/_requisitos.md` | Commit |
| Puntero para agentes | CL-03 | `AGENTS.md` en la raíz | Commit |
| Índice interno para agentes | CL-08 | Repositorio hermano `.Documentacion` | SHA fijado: pendiente, no se pudo leer el hermano |
| Expedientes, bitácoras y prompts | CL-09 | Repositorio hermano `.Documentacion` | Commit del hermano |
| Guías de estudio | CL-10 | `Guides/` y `Concepts/` | Versión de cada guía y etiqueta: pendiente |
| Este proceso | CL-12 | `docs/Como-Intervenir.md` | Versión de la plantilla |
| README y CHANGELOG | CL-13 | Raíz del repositorio | Fecha de la entrada |

## 3. Guion de validación local

Desde la raíz del repositorio, `scripts/ci-local.sh todo RUTA`, con `RUTA` igual a la carpeta que se cambió. Sin
argumento, el guion verifica la carpeta del cuerpo del sistema documentador, que no estaba en la copia leída: en ese
caso el resultado es un error de uso, no un verde.

Los controles de `tools/docs-guard/dg.py` usan sólo la biblioteca estándar de Python y se pueden correr sueltos, por
ejemplo `python3 -I tools/docs-guard/dg.py trazas docs`.

## 4. Workflow y runner de la compuerta

El workflow es `.github/workflows/docs-guard.yml`, que corre los mismos pasos que el guion local y es reutilizable por
otros repositorios. Corre en un runner propio con la etiqueta `{etiqueta-runner-linux}`, alias de la etiqueta de
runner de Linux que declara el workflow. Qué carpeta verifica la compuerta en este repositorio, y si cambia la
carpeta por defecto, lo decide una persona (D-09 en la sección 4 de la ficha A-01).

El carril programado es `.github/workflows/docs-enlaces-semanal.yml`: una vez por semana, sólo avisa y deja su informe
en un issue.

## 5. Quién decide y delegación

Un agente propone lo de clase P y no cierra lo de clase H; la tabla de qué es cada cosa está en la sección 5 de
`AGENTS.md`. Las delegaciones del merge vigentes están asentadas en `CHANGELOG.md`, cada una con su alcance por
expediente; fuera de esos alcances fusiona una persona.

## 6. Excepciones a la plantilla

Ninguna declarada. La plantilla de origen y una instancia anterior para este repositorio viven en el cuerpo del
sistema documentador, que no estaba en la copia leída: cuando se lo restituya, una persona decide cuál de las dos
instancias queda.
