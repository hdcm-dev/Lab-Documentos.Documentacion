---
doc_id: FIC-LINEA-DE-BASE
doc_type: anexo
title: Línea de base de la compuerta y controles de entrega
description: Hallazgos de cada control antes de bloquear, por carpeta, y la tabla de controles de entrega y de punto de uso.
status: borrador
origin: ia-generated
confidence: media
owner: Product Owner
last_review: 2026-11-02
audience: [desarrollo, po]
traces: [FIC-FICHA]
---

# Línea de base de la compuerta

A-08 y A-13 de la [ficha](../_diseno/ficha-diseno-documental.md). Este texto es también la descripción del pull request
de adopción. Medido el 2026-11-02 con la copia del proyecto (`.docs-guard/`), sin red, sobre el árbol leído más los
artefactos de la adopción. El archivo de excepciones de la copia arranca vacío.

## Línea de base por control y carpeta

| Control | `docs/` (nueva) | `SDD/` (heredada) | Punteros `AGENTS.md` y `README.md` | Estado propuesto en `docs/` |
| --- | --- | --- | --- | --- |
| PR-1 enlaces (lychee, sin red) | 0 | 3514 | sin enlaces | avisa hasta su par rojo/verde propio |
| PR-1 relativos fuera del repo | 0 | 0 | — | avisa hasta su par |
| PR-2 esquema y prefijos | 0 | 119 | sin frontmatter | avisa hasta su par |
| PR-3 anti-inyección AI-1, AI-2, AI-4, AI-5 | 0 | 87 (AI-2 6, AI-4 81) | 0 | avisa hasta su par |
| PR-3 AI-3 | 0 | 0 | 0 | avisa siempre |
| PR-4 markdownlint | 0 | 645 | 0 | avisa hasta su par |
| PR-4 mermaid-arroba | 0 | 0 | — | avisa hasta su par |
| PR-5 trazas e id-duplicado | 0 | 932 (897 id-duplicado, 35 traza-mal-formada) | 0 | avisa; par corrido en la ficha, §8 |
| PR-6 contrato | no aplica | no aplica | — | avisa: el contrato se genera en ejecución y la CI no lo extrae |
| PR-7 fijadas, reflint | 0 | 0 | — | avisa hasta su par |
| PR-7 url-fecha | 0 | 73 avisos | — | avisa |

La regla de bloqueo pide cinco condiciones: determinista y sin red, defecto del mismo pull request, par rojo/verde,
línea de base 0 y sin falsos positivos conocidos. En `docs/` la línea de base es 0 en todos los controles. Ninguno
bloquea en esta adopción: volver obligatorio el check es un acto del Product Owner, y la plataforma no se midió. Lo
heredado de `SDD/` sólo avisa; sanearlo es una decisión aparte.

Prefijos heredados fuera del registro: las familias del corpus `SDD/` que no entran en
`.docs-guard/tools/docs-guard/prefijos.txt` se cuentan con el comando 7 de la ficha y van a un saneamiento aparte.

## Controles de entrega y de punto de uso

Ningún control de esta tabla está implementado en la compuerta de origen: todos avisan, con su par pendiente.

| Control | Estado | Par rojo/verde |
| --- | --- | --- |
| `audiencia-vocabulario` | avisa | pendiente |
| `delivery-clave-cercana` | avisa | pendiente |
| `nivel-vs-repo` | avisa | pendiente |
| `cruce-de-audiencia` | avisa | pendiente |
| `indice-sin-fuga` | avisa | pendiente |
| `paquete-sin-fuga` | avisa | pendiente |
| `ampliacion-de-acceso` | avisa | pendiente |
| `contrato-por-exposicion` | avisa | pendiente |
| `contexto-resuelve` | avisa | pendiente |
| `anclas` extendidas | avisa | pendiente |
| `traduccion-atrasada` | avisa | pendiente: un solo idioma |
| `anti-inyeccion-en-recursos` | avisa | pendiente |
| Pruebas de entrega pareadas | avisa | pendiente |
