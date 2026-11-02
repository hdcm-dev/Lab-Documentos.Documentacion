---
doc_id: RD-LD-RRD
doc_type: rrd
title: Registro de requerimientos documentales de la adopción en Lab-Documentos
description: RRD inicial de la adopción del sistema documentador; una fila por pieza nueva y por clase activa sin pieza.
status: borrador
origin: ia-generated
confidence: media
owner: aplicador
last_review: 2026-11-02
audience: [humano, agente]
traces: [FIC-LD-DISENO]
---

# Registro de requerimientos documentales de la adopción

Propuesta sujeta a D-09 y D-11 (decisiones H abiertas en la ficha de diseño documental). Rango `RD-50` a `RD-59`:
libre en lo leído; la carpeta del cuerpo SDEI no se pudo leer y la unicidad contra ella queda pendiente.

| ID | Audiencia | Tarea | Pieza | Criterio | Decisión |
| --- | --- | --- | --- | --- | --- |
| RD-50 | humano | Saber qué piezas tiene el sistema documentador del repositorio y quién decide cada una | CL-01, ficha de diseño documental | Dado el repositorio adoptado, cuando una persona abre la ficha, entonces encuentra D-01 a D-17 con valor o pendiente; instrumento: esquema y trazas (PR-2, PR-5) | pendiente |
| RD-51 | agente | Elegir un prefijo registrado antes de declarar un ID | Registro de prefijos, `tools/docs-guard/prefijos.txt` | Dado un ID nuevo, cuando la compuerta corre, entonces un prefijo fuera del registro da rojo; instrumento: PR-2 esquema | pendiente |
| RD-52 | humano | Conocer la línea de base de cada control sobre lo heredado | CL-01, informe de línea de base | Dado lo heredado en `Guides/` y `Concepts/`, cuando se propone bloquear un control, entonces su línea de base figura en el informe; instrumento: revisión del PR | pendiente |
| RD-53 | agente | Encontrar la ruta de lectura y qué no decide | CL-03, `AGENTS.md` | Dado un agente nuevo, cuando abre `AGENTS.md`, entonces cada enlace resuelve; instrumento: PR-1 enlaces | pendiente |
| RD-54 | estudiante | Leer una guía con frontmatter válido | CL-10, guías de `Guides/` | Dado una guía heredada, cuando se migra al esquema, entonces PR-2 da verde sobre su carpeta; instrumento: PR-2 esquema | pendiente |
| RD-55 | humano | Ver los cambios del repositorio y las delegaciones vigentes | CL-13, `CHANGELOG.md` | Dado un PR de la adopción, cuando se fusiona, entonces el CHANGELOG tiene su entrada; instrumento: revisión del PR | pendiente |
