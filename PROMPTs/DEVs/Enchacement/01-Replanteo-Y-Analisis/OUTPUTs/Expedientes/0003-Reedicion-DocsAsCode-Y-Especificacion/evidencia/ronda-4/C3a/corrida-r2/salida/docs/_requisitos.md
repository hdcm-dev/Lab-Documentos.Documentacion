---
doc_id: FIC-RRD-COLMENAR
doc_type: rrd
title: Registro de requerimientos documentales (RRD) — Colmenar
description: RRD inicial de la adopción. Una fila por pieza nueva y por clase activa sin pieza. Propuesta sujeta a D-04 y D-18.
status: borrador
origin: ia-assisted
confidence: media
owner: aplicador
last_review: 2026-11-02
audience: [humano, agente, desarrollo]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Registro de requerimientos documentales — Colmenar

Propuesta (A-04, CL-02). El criterio usa Dado/Cuando/Entonces literal (`dg.py:303-304`). La decisión la toma
una persona (I-18): queda `pendiente`. Numeración `RD-nn` libre en todo el repo (comando 9 = 0 para `RD`).

| ID | Audiencia | Tarea | Pieza | Criterio | Decisión |
| --- | --- | --- | --- | --- | --- |
| RD-01 | desarrollo | Conocer el esquema de frontmatter del proyecto | CL-01 y `docs/_gobierno/esquema-frontmatter.md` (A-03) | Dado un documento nuevo con frontmatter, cuando corre la compuerta, entonces valida contra `cuerpo.schema.json`; instrumento: control `esquema` | pendiente |
| RD-02 | agente | Saber qué no decide y qué guion correr antes de proponer | CL-03 y `AGENTS.md` (A-05) | Dado un agente que va a proponer un cambio, cuando abre `AGENTS.md`, entonces encuentra los enlaces a A-03, A-07 y A-01 §4 resueltos; instrumento: control `esquema`/`trazas` | pendiente |
| RD-03 | persona-usuaria | Encontrar ayuda por rol en el punto de uso | CL-06 y la carpeta de ayuda de la interfaz | Dado un rol con permisos propios, cuando abre la ayuda, entonces ve la ayuda de su rol y no la de otro; instrumento: control de trazas de la ayuda | pendiente |
| RD-04 | desarrollo | Intervenir el repo siguiendo el proceso | CL-12 y `docs/_gobierno/como-intervenir.md` (A-06) | Dado un cambio documental, cuando se abre el PR, entonces el proceso nombra guion, runner, quién decide y excepciones; instrumento: revisión del PR | pendiente |
| RD-05 | desarrollo | Verificar que la copia de la tabla veterinaria no derivó | CL-11 y la copia con huella | Dado el carril programado, cuando corre en cosecha, entonces compara la huella SHA-256 de la copia con la publicada y avisa si difiere; instrumento: A-10 | pendiente |
| RD-06 | estudiante | Resolver cada ejercicio del curso con enunciado y solución | CL-10 (repo dedicado) | Dado un ejercicio del curso, cuando el alumno lo abre, entonces ve enunciado y solución trazados a la versión del cuerpo; instrumento: compuerta completa del repo dedicado | pendiente |
