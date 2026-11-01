---
doc_id: DOC-LABDOC-RRD
doc_type: rrd
title: Registro de requerimientos documentales de Lab-Documentos
description: RRD inicial del repositorio, salido del diseño documental A-01; toda decisión queda pendiente de una persona.
status: borrador
origin: ia-generated
confidence: media
owner: Lab-Documentos — diseño documental
last_review: 2026-11-01
audience: [humano, agente]
traces: [IDX-LABDOC-AGENTS]
version: 1.0
---

# Registro de requerimientos documentales de Lab-Documentos

Cada fila es un requerimiento documental: una sola audiencia, la tarea que necesita lograr, la pieza del catálogo que
la sirve, un criterio Dado/Cuando/Entonces con su instrumento y la decisión de una persona. Lo propuso el aplicador
del diseño (clase P); la decisión de cada fila la toma una persona (clase H), por eso todas dicen «pendiente».

| ID | Audiencia | Tarea | Pieza | Criterio | Decisión |
| --- | --- | --- | --- | --- | --- |
| RD-01 | agente | Saber qué leer, cómo validar y qué no puede cambiar antes de proponer un cambio | CL-03, `AGENTS.md` | Dado un clon del repositorio en el SHA de la rama principal, cuando se siguen los enlaces de `AGENTS.md`, entonces todos resuelven; instrumento: PR-1 enlaces sobre `AGENTS.md` | pendiente |
| RD-02 | estudiante | Encontrar la guía de estudio de una categoría | CL-10, `Guides/README.md` | Dado `Guides/README.md`, cuando se sigue cada enlace de su tabla de categorías, entonces llega a una carpeta o un README que existe; instrumento: PR-1 enlaces | pendiente |
| RD-03 | agente | Encontrar el documento al que traza una página por su ID, sin ambigüedad | CL-10, frontmatter de cada página de `Guides/` y `Concepts/` | Dado un documento nuevo con frontmatter dentro de la carpeta que verifica la compuerta, cuando corre PR-5, entonces cada traza resuelve a un único `doc_id`; instrumento: PR-5 trazas | pendiente |
| RD-04 | docente | Saber qué cambió en las guías y con qué alcance | CL-13, `CHANGELOG.md` | Dado un pull request que cambia `Guides/` o `Concepts/`, cuando se lo revisa, entonces trae una entrada en `CHANGELOG.md`; instrumento: revisión del pull request (sin control automático) | pendiente |
| RD-05 | humano | Que lo de clase H no entre sin una persona | CL-12, `docs/diseno-documental/Como-Intervenir.md` | Dado un pull request que toca `AGENTS.md`, `tools/docs-guard/excepciones.txt` o `.github/workflows/`, cuando se fusiona, entonces una persona lo aprobó; instrumento: revisión del pull request (sin control automático) | pendiente |
