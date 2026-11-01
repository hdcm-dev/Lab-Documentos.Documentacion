---
doc_id: DOC-RRD
doc_type: requisitos
title: Registro de requerimientos documentales
description: Requerimientos documentales iniciales de Lab-Geometria, uno por fila, con criterio verificable.
status: borrador
origin: ia-generated
confidence: baja
owner: Product Owner del laboratorio
last_review: 2026-11-01
audience: [desarrollo, agente, alumno, administrador]
traces: [DOC-ESQUEMA-FRONTMATTER@1.0]
version: 1.0
---

# Registro de requerimientos documentales (A-04)

Filas propuestas por el aplicador; la decisión de cada una es de una persona.

| ID | Audiencia | Tarea | Pieza | Criterio | Decisión |
| --- | --- | --- | --- | --- | --- |
| RD-01 | agente | Ubicar la documentación y lo que no decide antes de proponer un cambio | CL-03 `AGENTS.md` | Dado un clon limpio, cuando el agente abre `AGENTS.md`, entonces llega a la documentación, al guion local y a la lista de decisiones H en un salto; instrumento: compuerta (enlaces que resuelven) | pendiente |
| RD-02 | desarrollo | Saber dónde vive una pieza y cómo validarla antes del PR | CL-12 `docs/Como-Intervenir.md` | Dado un cambio de documentación, cuando quien desarrolla corre `bash scripts/docs-guard.sh`, entonces obtiene el mismo resultado que la CI; instrumento: `docs-guard.yml` | pendiente |
| RD-03 | alumno | Entender qué significa una discrepancia entre valor declarado y derivado en su trabajo | CL-06, archivo pendiente (D-13) | Dado un trabajo con discrepancias, cuando el alumno abre la ayuda de la vista del trabajo, entonces encuentra la explicación del par declarado/derivado; instrumento: pendiente (enlaces y trazas de la ayuda) | pendiente |
| RD-04 | administrador | Habilitar cuentas y resolver trabajos sin leer el corpus SDD | CL-06, archivo pendiente (D-13) | Dado un administrador nuevo, cuando abre la ayuda del panel de cuentas, entonces encuentra los pasos de habilitación; instrumento: pendiente | pendiente |
| RD-05 | agente | Saber contra qué revisión de `Lab-Geometria` vale la ia-db | CL-08 `LGD/ia-db/source.lock` | Dado un `main` que avanzó, cuando corre el carril programado, entonces abre un issue con el atraso en commits; instrumento: carril programado | pendiente |
