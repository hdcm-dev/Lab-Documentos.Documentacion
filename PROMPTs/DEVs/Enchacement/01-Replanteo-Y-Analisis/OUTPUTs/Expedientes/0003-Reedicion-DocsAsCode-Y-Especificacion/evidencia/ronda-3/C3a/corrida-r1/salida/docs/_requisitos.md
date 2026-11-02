---
doc_id: RD-REGISTRO
doc_type: rrd
title: Registro de requerimientos documentales de Colmenar
description: RRD inicial de la adopción; una fila por pieza nueva y por clase activa sin pieza.
status: borrador
origin: ia-generated
confidence: media
owner: equipo de la app
last_review: 2026-11-02
audience: [humano, desarrollo, po]
traces: [FIC-FICHA]
---

# Registro de requerimientos documentales de Colmenar

Toda decisión queda `pendiente`: la toma una persona.

| ID | Audiencia | Tarea | Pieza | Criterio | Decisión |
| --- | --- | --- | --- | --- | --- |
| RD-01 | desarrollo | saber qué piezas tiene el proyecto y quién decide | CL-01 docs/_diseno/ficha-diseno-documental.md | Dado un cambio documental, Cuando lo prepara, Entonces encuentra su clase y su ubicación en la ficha; instrumento: compuerta PR-5 trazas | pendiente |
| RD-02 | desarrollo | proponer un requerimiento documental | CL-02 docs/_requisitos.md | Dado un requerimiento nuevo, Cuando lo agrega, Entonces la fila tiene las seis columnas; instrumento: compuerta PR-2 esquema | pendiente |
| RD-03 | desarrollo | orientar a un asistente automático | CL-03 AGENTS.md | Dado un asistente en el repo, Cuando abre AGENTS.md, Entonces llega en un enlace a la guía, al guion local y a lo que no decide; instrumento: compuerta PR-1 enlaces | pendiente |
| RD-04 | desarrollo | leer la referencia del código | CL-04 comentarios XML | Dado el build, Cuando genera la referencia, Entonces no hay avisos de documentación; instrumento: build con avisos como error (pendiente) | pendiente |
| RD-05 | persona-usuaria | aprender su tarea en la app según su perfil y su idioma | CL-06 ayuda por rol e idioma | Dado un perfil, Cuando abre la ayuda, Entonces ve sólo la de su perfil y en su idioma; instrumento: pruebas de entrega pareadas (pendiente) | pendiente |
| RD-06 | desarrollo | entender la arquitectura de la app | CL-07 docs/tecnica/ | Dado un documento técnico, Cuando se fusiona, Entonces pasa enlaces, frontmatter y mermaid; instrumento: compuerta PR-1, PR-2, PR-4 | pendiente |
| RD-07 | desarrollo | intervenir el sistema documentador | CL-12 docs/_gobierno/como-intervenir.md | Dado un cambio, Cuando sigue el proceso, Entonces corre el guion local y sabe quién decide; instrumento: revisión del PR | pendiente |
| RD-08 | desarrollo | saber qué cambió en cada versión | CL-13 CHANGELOG.md | Dado un PR que cambia la app, Cuando se fusiona, Entonces tiene su entrada; instrumento: control de entrada (pendiente) | pendiente |
| RD-09 | persona-usuaria | aprender a usar la app desde el sitio | CL-14 canales del sitio | Dado el build del sitio, Cuando se publica, Entonces los canales para agentes salen de la misma fuente; instrumento: reproducibilidad (pendiente) | pendiente |
| RD-10 | desarrollo | saber a quién se entrega cada pieza | docs/_gobierno/registro-audiencias.md | Dado una página con delivery, Cuando pasa la compuerta, Entonces su audiencia está en el registro; instrumento: audiencia-vocabulario (pendiente) | pendiente |
