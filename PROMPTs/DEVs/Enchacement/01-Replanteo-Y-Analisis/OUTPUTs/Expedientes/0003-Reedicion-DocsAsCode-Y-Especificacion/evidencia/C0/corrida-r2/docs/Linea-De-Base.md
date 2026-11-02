---
doc_id: ANX-LD-LINEA-DE-BASE
doc_type: anexo
title: Línea de base de la compuerta de documentación de Lab-Documentos
description: Hallazgos de cada control de docs-guard sobre lo que ya hay, medidos antes de decidir qué bloquea.
status: borrador
origin: ia-generated
confidence: media
owner: Lab-Documentos — guía del sistema documentador
last_review: 2026-11-01
audience: [humano, agente]
traces: [GP-LD-INTERVENIR, RD-LD-REGISTRO]
version: 1.0
---

# Línea de base de la compuerta de documentación de Lab-Documentos

Informe de línea de base (A-08 de la ficha de diseño documental A-01). Cuenta los hallazgos de cada control sobre lo
que ya existe en el repositorio, antes de que la compuerta empiece a bloquear sobre una carpeta nueva.

## Índice

1. [Cómo se midió](#1-cómo-se-midió)
2. [Resultados por control](#2-resultados-por-control)
3. [Lo que no se pudo medir](#3-lo-que-no-se-pudo-medir)
4. [Excepciones](#4-excepciones)
5. [Lectura para la decisión](#5-lectura-para-la-decisión)

## 1. Cómo se midió

Fecha de la medición: 2026-11-01, sobre una copia del repositorio sin historia de Git. Cada control se corrió con
`python3 -I tools/docs-guard/dg.py CONTROL CARPETA --raiz RAÍZ`, de sólo lectura y sin red. La copia leída no tiene
la carpeta del cuerpo del sistema documentador, que es la carpeta por defecto del workflow y del guion local.

## 2. Resultados por control

Cifras: errores y avisos que informa la última línea de cada control.

| Control | Carpeta por defecto del guion | `Guides/` | `Concepts/` | Punteros de la raíz |
| --- | --- | --- | --- | --- |
| PR-1 `fuera` | error de uso: la carpeta no existe | 0 errores | 0 errores | — |
| PR-2 `esquema` | error de uso | 309 errores (267 `esquema-cuerpo`, 42 `prefijo`) y 30 avisos | 16 errores (15 `esquema-cuerpo`, 1 `prefijo`) | 4 errores |
| PR-3 `ai` | error de uso | 824 errores y 100 avisos | 108 errores | `AGENTS.md`: 0 errores, 1 aviso AI-3 |
| PR-4 `mermaid-arroba` | error de uso | 0 errores en 273 bloques | 0 errores en 50 bloques | — |
| PR-5 `trazas` | error de uso | 1404 errores (602 `id-duplicado`, 704 `traza-ambigua`, 97 `traza-no-resuelve`, 1 `traza-mal-formada`) | 4 errores (`id-duplicado`) | 8 errores `traza-no-resuelve` |
| PR-6 `contratos` | 0 errores, sin contratos | 0 errores, sin contratos | 0 errores, sin contratos | — |
| PR-7 `fijadas` | 0 errores, sin piezas fijadas | 0 errores, sin piezas fijadas | 0 errores, sin piezas fijadas | — |
| PR-7 `reflint` | error de uso | 0 errores | 0 errores | — |
| PR-7 `url-fecha` | error de uso | 0 errores, 854 avisos | 0 errores, 93 avisos | — |

Los prefijos que faltan en el registro, sobre `Guides/`, `Concepts/` y los punteros de la raíz, son diez: `ANEXO`
(13 apariciones), `GUIA` (8), `E2E` (7), `GF` (7), `GHF` (3), `GHA` (2), `ANALISIS`, `CUADERNO`, `GUIAS` y `LAB` (1
cada uno).

## 3. Lo que no se pudo medir

PR-1 con lychee, PR-4 con markdownlint-cli2 y el parser de mermaid, y el paso `autoprueba` completo necesitan bajar
herramientas por red. La medición se hizo sin red, así que su línea de base queda pendiente hasta una corrida del
guion completo en el runner del proyecto.

## 4. Excepciones

El archivo de excepciones `tools/docs-guard/excepciones.txt` ya existe y tiene una línea: `AGENTS.md` exceptuado de
AI-3. La huella declarada no coincide con la del archivo leído, así que AI-3 vuelve a mirarlo y avisa (el aviso de la
tabla). Renovar la huella es de clase H. Este informe no agrega excepciones: para la carpeta nueva `docs/` el archivo
de excepciones arranca sin líneas que la toquen.

## 5. Lectura para la decisión

Sobre lo heredado, PR-2, PR-3 y PR-5 tienen línea de base distinta de 0: no pueden bloquear ahí y quedan en aviso
hasta sanear. PR-1 `fuera`, PR-4 `mermaid-arroba`, PR-6, PR-7 `fijadas`, `reflint` y `url-fecha` dan 0 errores en
`Guides/` y `Concepts/`. Con la carpeta por defecto ausente, una corrida sin argumento da error de uso en casi todos
los grupos, y el agregador lo cuenta como rojo.
