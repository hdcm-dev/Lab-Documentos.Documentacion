---
doc_id: FIC-LINEA-DE-BASE
doc_type: anexo
title: Línea de base de la compuerta antes de la adopción
description: Hallazgos de cada grupo de docs-guard por carpeta, medidos antes de activar bloqueos; texto para el pull request de adopción.
status: borrador
origin: ia-generated
confidence: media
owner: aplicador
last_review: 2026-11-02
audience: [humano, agente]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Línea de base de la compuerta antes de la adopción

Va en la descripción del pull request de adopción. Medido sin red con `scripts/ci-local.sh {grupo} {carpeta}` sobre una
copia del árbol recibido, sin la carpeta del cuerpo `SDEI` (sin permiso de lectura). Los enlaces que entran a esa
carpeta cuentan como rotos en esta medición. Archivo de excepciones: sin altas.

| Grupo | `Guides` (heredado) | `Concepts` (heredado) | `docs` (nuevo) |
| --- | --- | --- | --- |
| PR-1 enlaces | rojo, 195 errores de lychee | rojo, 16 errores de lychee | ver la ficha, §7 |
| PR-2 esquema | rojo, 309 errores y 30 avisos | rojo, 16 errores | ver la ficha, §7 |
| PR-3 anti-inyección | rojo, 824 errores y 101 avisos | rojo, 108 errores y 1 aviso | ver la ficha, §7 |
| PR-4 estructura | rojo, 133 errores de markdownlint y 3 mermaid inválidos | rojo, 1 mermaid inválido | ver la ficha, §7 |
| PR-5 trazas | rojo, 1412 errores y 602 IDs duplicados | rojo, 12 errores y 4 IDs duplicados | ver la ficha, §7 |
| PR-6 contrato | verde, 0 contratos | verde, 0 contratos | ver la ficha, §7 |
| PR-7 fijadas | verde, 854 avisos de url-fecha | verde, 93 avisos de url-fecha | ver la ficha, §7 |
| avisos | 711 avisos | 86 avisos | ver la ficha, §7 |

Lo heredado avisa; la carpeta nueva `docs` bloquea cuando su línea de base da 0.
