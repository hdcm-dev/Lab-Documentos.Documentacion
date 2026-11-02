---
doc_id: RD-LD-REGISTRO
doc_type: rrd
title: Registro de requerimientos documentales de Lab-Documentos
description: RRD inicial del repositorio; cada fila espera la decisión de una persona responsable.
status: borrador
origin: ia-generated
confidence: media
owner: Lab-Documentos — guía del sistema documentador
last_review: 2026-11-01
audience: [humano, agente]
traces: [GP-LD-INTERVENIR]
version: 1.0
---

# Registro de requerimientos documentales de Lab-Documentos

Registro inicial (A-04 de la ficha de diseño documental A-01). Cada fila nombra una sola audiencia, la tarea que
necesita resolver, la pieza que la sirve y el criterio con el que se comprueba. La columna «Decisión» la completa una
persona responsable: hasta entonces queda `pendiente`.

La numeración empieza en `RD-101` para no chocar con las filas `RD-nn` del cuerpo del sistema documentador, que el
CHANGELOG del repositorio menciona y que no estaban en la copia leída.

| ID | Audiencia | Tarea | Pieza | Criterio | Decisión |
| --- | --- | --- | --- | --- | --- |
| RD-101 | agente | Encontrar la ruta de lectura y el guion de validación antes de proponer un cambio | CL-03, `AGENTS.md` | Dado el `AGENTS.md` de la raíz, cuando corre el grupo PR-1 de la compuerta, entonces todos sus enlaces y anclas resuelven; instrumento: PR-1 enlaces | pendiente |
| RD-102 | estudiante | Llegar a la guía de una categoría desde el índice de guías | CL-10, `Guides/README.md` | Dado el índice `Guides/README.md`, cuando corre el grupo PR-1, entonces cada fila enlaza a una carpeta o archivo que existe; instrumento: PR-1 enlaces | pendiente |
| RD-103 | agente | Seguir una traza de un documento hasta el documento que la declara | CL-10, páginas de `Guides/` con `traces` | Dado un documento nuevo de `Guides/` con `traces`, cuando corre el grupo PR-5, entonces cada traza resuelve a un ID declarado una sola vez; instrumento: PR-5 trazas | pendiente |
| RD-104 | humano | Saber qué cambió en el repositorio y bajo qué delegación se fusionó | CL-13, `CHANGELOG.md` | Dado un pull request que cambia `Guides/`, `Concepts/` o `tools/`, cuando se revisa, entonces `CHANGELOG.md` tiene una entrada que lo describe; instrumento: revisión del pull request (no hay control automático) | pendiente |
| RD-105 | docente | Saber si una guía está vigente o en borrador antes de usarla en clase | CL-10, frontmatter de cada guía | Dado un documento nuevo de `Guides/`, cuando corre el grupo PR-2, entonces su frontmatter tiene `status` del vocabulario cerrado; instrumento: PR-2 esquema | pendiente |
