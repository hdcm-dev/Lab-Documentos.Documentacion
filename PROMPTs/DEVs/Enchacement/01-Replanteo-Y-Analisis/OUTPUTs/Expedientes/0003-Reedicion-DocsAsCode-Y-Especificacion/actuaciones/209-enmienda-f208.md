---
doc_id: EXP0003-F209
doc_type: enmienda
title: Enmienda de F208 — corrección de la descripción de los defectos C1 K4-01 y C2 K4-02 y rótulo enmendado del PR 7
status: vigente
origin: agent
confidence: alta (contrastado contra la plantilla A-01 §4, §5.1 y §6, y contra la DE-32 del conocimiento 1.4)
owner: presidencia de la mesa de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-02
audience: [presidencia, coordinador, autor del conocimiento, PO]
traces: [EXP0003-F208]
---

| Campo | Valor |
| --- | --- |
| Tipo | folio de enmienda |
| Fecha | 2026-11-02 |
| Enmienda | `F208` §5.3 y §9 (descripción de C1 K4-01 y C2 K4-02, y rótulo del PR 7). F208 no se reescribe |
| Origen | Hallazgos de coherencia COH-01 y COH-02 de la revisión general del 2026-11-02 |
| Resultado | Se corrigen las dos descripciones; los defectos siguen abiertos y siguen siendo P0. El veredicto de F208 §9 no cambia |

## 1. C1 K4-01

**Lo que dijo F208:** la regla «propuesta sujeta a D-nn» no está en la plantilla A-01 §6 ni es DE obligatoria.

**Corrección:** la columna «propuesta sujeta a D-nn» **sí está** en A-01 §6. El defecto es que no hay una DE
obligatoria ni una instrucción en la carta que exija producir A-02…A-13 con el default cuando una H está abierta.

## 2. C2 K4-02

**Lo que dijo F208:** falta exigir un default concreto y una fila por API documentable.

**Corrección:** la fila por API documentable **ya es obligatoria** (A-01 §4, §5.1 y DE-32). Lo único abierto es
que la fila H admite el default «pendiente»; falta exigir un default concreto.

## 3. Rótulo enmendado del PR 7

Reemplaza al rótulo de `F208` §9:

> **Borrador ensayado, no probado.** Conocimiento 1.4, ensayado en la ronda 4 del expediente 0003 (`EXP0003-F208`,
> 2026-11-02; enmendado por `EXP0003-F209`): ocho corridas válidas bajo aislamiento total, ninguna pasa la métrica e.
> Ningún caso del brazo B (C1, C2, C3a) tiene una corrida que pase. P0 abiertos:
>
> - **C1 K4-01**: con una H abierta, los artefactos A-02…A-13 deben producirse con el default y el rótulo
>   «propuesta sujeta a D-nn»; la columna está en la plantilla A-01 §6, pero ninguna DE obligatoria ni la carta
>   exigen producirlos.
> - **C2 K4-01**: sin el repo del código, la regla de acceso propio deja D-18 entero pendiente; falta admitir la
>   ruta:línea del índice como prueba, rotulada «según el índice».
> - **C2 K4-02**: la fila H de exponer documentación de API admite default «pendiente»; falta exigir un default
>   concreto (no «pendiente») en la fila H de cada API documentable.
> - **C3a K4-01**: el alcance «sólo lo suyo» con autorización en repo ajeno queda «no activado»; falta activar las
>   extensiones de alcance y superficie y separar el nivel por pieza del nivel por audiencia.
>
> Úsese como guía con criterio, no como procedimiento validado.
