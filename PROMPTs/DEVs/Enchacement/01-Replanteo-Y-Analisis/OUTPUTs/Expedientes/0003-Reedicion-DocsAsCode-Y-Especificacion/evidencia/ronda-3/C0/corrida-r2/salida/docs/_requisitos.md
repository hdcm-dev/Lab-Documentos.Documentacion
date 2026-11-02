---
doc_id: FIC-RRD-ADOPCION
doc_type: rrd
title: Registro de requerimientos documentales de la adopción
description: RRD inicial de la adopción del sistema documentador; una fila por pieza nueva y por clase activa sin pieza.
status: borrador
origin: ia-generated
confidence: media
owner: aplicador
last_review: 2026-11-02
audience: [humano, agente]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Registro de requerimientos documentales de la adopción

Rango `RD-100` en adelante: libre en el árbol leído (comando 9 con `RD-1[0-9][0-9]`, cuenta 0); la carpeta del cuerpo
`SDEI` no se pudo leer y queda sin verificar. Cada decisión la toma una persona (I-18).

| ID | Audiencia | Tarea | Pieza | Criterio | Decisión |
| --- | --- | --- | --- | --- | --- |
| RD-100 | humano | Saber qué piezas tiene el repositorio, dónde viven y quién decide | CL-01, `docs/_diseno/ficha-diseno-documental.md` | Dado el repositorio adoptado, cuando abre la ficha, entonces encuentra D-01 a D-17 con valor o pendiente; instrumento: PR-2 esquema y PR-5 trazas | pendiente |
| RD-101 | agente | Proponer un cambio sin decidir nada de clase H | CL-12, `docs/_gobierno/como-intervenir.md` | Dado un cambio documental, cuando lee el proceso, entonces encuentra el guion local, el workflow y la lista H; instrumento: PR-1 enlaces | pendiente |
| RD-102 | humano | Evaluar cada requerimiento documental | CL-02, `docs/_requisitos.md` | Dado este registro, cuando la compuerta lo lee, entonces cada fila tiene seis columnas y criterio Dado/Cuando/Entonces; instrumento: PR-2 esquema RRD | pendiente |
| RD-103 | humano | Conocer la línea de base de cada control antes de volverlo bloqueante | A-08, `docs/_diseno/linea-de-base.md` | Dado el informe, cuando se activa un bloqueo, entonces el control tiene su línea de base anotada por carpeta; instrumento: revisión del PR | pendiente |
| RD-104 | estudiante | Seguir una guía de estudio con su demo | CL-10, `Guides/` y `Concepts/` | Dado una guía heredada, cuando se saneen sus hallazgos, entonces pasa la compuerta en su carpeta; instrumento: grupos PR-1 a PR-7 | pendiente |
| RD-105 | agente | Encontrar expedientes y bitácoras previos al cambio | CL-09, repo hermano | Dado el repo hermano, cuando busca el expediente de un cambio, entonces lo encuentra por su número; instrumento: barrido de lo privado y enlaces del carril programado | pendiente |
