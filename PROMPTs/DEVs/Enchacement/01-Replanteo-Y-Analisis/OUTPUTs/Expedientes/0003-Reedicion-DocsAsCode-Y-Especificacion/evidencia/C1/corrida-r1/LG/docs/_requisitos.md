---
doc_id: SDOC-RRD
doc_type: anexo
title: Registro de requerimientos documentales
description: Requerimientos documentales iniciales por audiencia, con criterio Dado/Cuando/Entonces y la decisión pendiente de una persona.
status: borrador
origin: ia-generated
confidence: media
owner: pendiente (lo asigna una persona; ver A-01 §4)
last_review: 2026-11-01
audience: [desarrollo, agente, po]
traces: [SDOC-PREFIJOS]
---

# Registro de requerimientos documentales (A-04)

Propuestas de agente (clase P). La columna «Decisión» la llena una persona.

| ID | Audiencia | Tarea | Pieza | Criterio | Decisión |
| --- | --- | --- | --- | --- | --- |
| RD-01 | Alumno | Entender una advertencia: el par valor declarado / valor derivado sobre su trabajo (`SDD/Docs/README.md:242`, `:244`) | CL-06, archivo pendiente (no hay ayuda al usuario final en el árbol) | Dado un trabajo con una advertencia, cuando el alumno abre la vista del trabajo, entonces llega a una explicación del par declarado/derivado sin salir de la aplicación; instrumento: pendiente (control de enlaces y trazas de la ayuda) | pendiente |
| RD-02 | Administrador | Aprobar o rechazar un trabajo en `Pendiente` y dejar su comentario (`SDD/Docs/README.md:245-246`) | CL-06, archivo pendiente | Dado un trabajo en `Pendiente`, cuando el administrador busca cómo resolverlo, entonces la ayuda de su rol describe aprobar, rechazar y el comentario, y no aparece en la ayuda del alumno; instrumento: pendiente | pendiente |
| RD-03 | Consumidor de la API (aplicación propia) | Conocer la superficie `/v1/` (`SDD/Docs/README.md:40`) | CL-05, `/openapi/v1.json` (`src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:37`, `:117`) | Dado un PR que cambia un punto de acceso, cuando corre la compuerta, entonces el diff del contrato aparece en el PR; instrumento: diff del contrato, pendiente (no existe en la CI, `.github/workflows/ci.yml:45-96`) | pendiente |
| RD-04 | Agente | Ubicarse en el producto sin recorrer el árbol | CL-08, `Lab-Geometria.Documentacion/ia-db/README.md` | Dado el índice anclado en `ia-db/source.lock`, cuando `main` de este repo avanza, entonces el carril programado avisa el atraso en commits; instrumento: carril programado (A-10), pendiente | pendiente |
