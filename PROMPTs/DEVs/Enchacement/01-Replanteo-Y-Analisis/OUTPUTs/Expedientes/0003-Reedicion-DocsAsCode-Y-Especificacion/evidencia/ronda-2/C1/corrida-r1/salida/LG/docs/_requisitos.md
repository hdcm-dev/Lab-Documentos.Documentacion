---
doc_id: RD-00
doc_type: rrd
title: Registro de requerimientos documentales — Fábrica de Geometría
description: RRD inicial de la adopción de documentación como código; filas propuestas, todas con decisión pendiente.
status: borrador
origin: ia-generated
confidence: media
owner: pendiente (D-11)
last_review: 2026-11-01
audience: [desarrollo, devops, persona-usuaria, agente]
traces: []
---

# RD-00 — Registro de requerimientos documentales

**Versión:** 0.1

> Propuesta del aplicador (A-04). `doc_type` y `audience` sujetos al vocabulario de A-03, pendiente
> (D-09). Rango `RD-01…RD-07`: `RD-` sin uso en `LG` ni `LGD` (`grep -rhoE '\bRD-[0-9A-Z]+'` → 0).
> Cada fila espera la decisión de una persona.

| ID | Audiencia | Tarea | Pieza | Criterio | Decisión |
| --- | --- | --- | --- | --- | --- |
| RD-01 | desarrollo | Levantar el producto en limpio | CL-07 · `Guia-Inicio-Rapido.md` de Web, hoy «no emitida» (`AGENTS.md:83`) | Dado un clon limpio, cuando se busca la guía de inicio rápido de Web, entonces existe y sus enlaces resuelven; instrumento: control de enlaces de la compuerta (D-09) | pendiente |
| RD-02 | devops | Desplegar y volver atrás | CL-07 · `Guia-Despliegue.md`, hoy «no emitida» (`AGENTS.md:84`) | Dado un despliegue, cuando se busca cómo revertirlo, entonces la guía existe y nombra la etiqueta anterior; instrumento: control de enlaces de la compuerta (D-09) | pendiente |
| RD-03 | persona-usuaria | Entender el producto | CL-01 · `Vision-General-Sistema.md`, hoy «no emitida» (`AGENTS.md:82`) | Dado el índice `SDD/Docs/README.md`, cuando se sigue el enlace a la visión general, entonces resuelve; instrumento: control de enlaces de la compuerta (D-09) | pendiente |
| RD-04 | persona-usuaria (alumno) | Cargar, enviar y ver su trabajo | CL-06 · ayuda del rol `Student` | Dado el papel `Student`, cuando abre la ayuda, entonces sólo ve tareas de su papel; instrumento: control de trazas de la ayuda (D-09) | pendiente |
| RD-05 | persona-usuaria (administrador) | Habilitar cuentas y resolver trabajos | CL-06 · ayuda del rol `Administrator` | Dado el papel `Administrator`, cuando abre la ayuda, entonces ve las tareas de su papel; instrumento: control de trazas de la ayuda (D-09) | pendiente |
| RD-06 | desarrollo | Consumir la API `/v1/` sin levantar el servicio | CL-05 · contrato OpenAPI extraído por un paso de la CI | Dado un pull request que cambia la superficie, cuando corre la CI, entonces el diff del contrato extraído aparece; instrumento: diff del contrato (pendiente: paso de extracción) | pendiente |
| RD-07 | agente | Ubicarse en el repo de documentación | CL-03 · `AGENTS.md` puntero en la raíz de `LGD` | Dado `LGD`, cuando un agente abre la raíz, entonces encuentra `AGENTS.md` y sus enlaces resuelven; instrumento: control «existe y enlaces resuelven» | pendiente |
