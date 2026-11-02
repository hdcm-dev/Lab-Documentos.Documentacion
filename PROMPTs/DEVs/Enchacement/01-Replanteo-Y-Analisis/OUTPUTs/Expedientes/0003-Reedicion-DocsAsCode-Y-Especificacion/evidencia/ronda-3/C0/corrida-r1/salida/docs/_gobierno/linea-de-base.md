---
doc_id: FIC-LD-LINEA-BASE
doc_type: anexo
title: Línea de base de la compuerta sobre lo heredado de Lab-Documentos
description: Hallazgos de cada grupo de la compuerta sobre Guides y Concepts, medidos sin red antes de proponer bloqueo.
status: borrador
origin: ia-generated
confidence: media
owner: aplicador
last_review: 2026-11-02
audience: [humano, agente, devops]
traces: [FIC-LD-DISENO]
---

# Línea de base de la compuerta sobre lo heredado

Texto para la descripción del pull request de adopción. El archivo de excepciones de la adopción es el que ya tiene
el repositorio (`tools/docs-guard/excepciones.txt`, una excepción de AI-3 para `AGENTS.md`): la adopción no agrega
ninguna, porque agregar una excepción es de clase H.

Medición: `scripts/ci-local.sh {grupo} {carpeta}` desde la raíz del árbol recibido, sin red, con las herramientas ya
instaladas en la caché del entorno. La carpeta del cuerpo SDEI no se pudo leer (sin permiso): su línea de base queda
pendiente, y la de `Guides/` la incluye sólo en lo que cada herramienta alcanzó a recorrer.

| Grupo | `Guides/` | `Concepts/` | Regla (D-10) |
| --- | --- | --- | --- |
| PR-1 enlaces | rojo: 129 líneas de error de lychee; relativos fuera del repo, 0 | rojo: 16 errores de lychee en 285 enlaces; relativos fuera del repo, 0 | avisa |
| PR-2 esquema | rojo: 309 errores, 30 avisos, 207 archivos con frontmatter, 71 sin frontmatter | rojo: 16 errores, 13 archivos con frontmatter, 7 sin frontmatter | avisa |
| PR-3 ai | rojo: 824 errores (AI-1 354, AI-2 3, AI-4 552, AI-5 2), AI-3 14 | rojo: 108 errores (AI-1 38, AI-4 70), AI-3 1 | avisa |
| PR-4 estructura | rojo: markdownlint 133 errores, mermaid inválidos, permiso denegado en el cuerpo SDEI; mermaid-arroba 0 | rojo: markdownlint 0, mermaid 1 inválido de 51; mermaid-arroba 0 | avisa |
| PR-5 trazas | rojo: 1412 errores, 602 IDs duplicados, 983 de 1793 trazas resueltas | rojo: 12 errores, 4 IDs duplicados, 101 de 109 resueltas | avisa |
| PR-6 contrato | verde: 0 contratos | verde: 0 contratos | sin cambio |
| PR-7 fijadas | verde: 0 piezas; reflint 0 en 51 referencias; url-fecha 854 avisos | verde: 0 piezas; url-fecha 93 avisos | sin cambio |

Ningún grupo rojo sobre lo heredado cumple la cuarta condición de la regla de bloqueo (línea de base 0): todos
avisan sobre `Guides/` y `Concepts/` hasta que un saneamiento aparte los lleve a 0.
