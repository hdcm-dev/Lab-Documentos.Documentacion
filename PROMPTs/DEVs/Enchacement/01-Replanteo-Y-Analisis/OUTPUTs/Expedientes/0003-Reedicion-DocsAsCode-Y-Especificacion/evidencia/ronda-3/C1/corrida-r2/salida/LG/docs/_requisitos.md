---
doc_id: RD-REGISTRO
doc_type: rrd
title: Registro de requerimientos documentales de Fábrica de Geometría
description: RRD inicial de la adopción de la documentación como código; una fila por pieza nueva y por clase activa sin pieza.
status: borrador
origin: ia-generated
confidence: media
owner: Product Owner
last_review: 2026-11-02
audience: [desarrollo, po]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Registro de requerimientos documentales

Propuesta sujeta a la revisión del Product Owner: cada decisión queda `pendiente` hasta que una persona la evalúe.

| ID | Audiencia | Tarea | Pieza | Criterio | Decisión |
| --- | --- | --- | --- | --- | --- |
| RD-01 | desarrollo | Saber qué decidió el diseño documental y con qué evidencia | CL-01 `docs/_diseno/ficha-diseno-documental.md` | Dado un pull request que toca `docs/`, cuando corre la compuerta, entonces la ficha pasa el esquema y sus trazas resuelven; instrumento: PR-2 y PR-5 | pendiente |
| RD-02 | po | Evaluar cada requerimiento documental con su criterio | CL-02 `docs/_requisitos.md` | Dado el RRD, cuando corre PR-2, entonces cada fila tiene las seis columnas, criterio Dado/Cuando/Entonces y decisión válida; instrumento: PR-2 esquema RRD | pendiente |
| RD-03 | agente | Encontrar el contrato documental y el guion local antes de proponer un cambio en el repositorio hermano | CL-03 `AGENTS.md` de `Lab-Geometria.Documentacion` | Dado el repositorio hermano, cuando corre PR-1 sobre su raíz, entonces `AGENTS.md` existe y sus enlaces resuelven; instrumento: PR-1 enlaces | pendiente |
| RD-04 | consumidor-api | Leer la referencia de los tipos públicos emitida desde los comentarios del código | CL-04 archivo XML de documentación de `GeometriaFactory.Contracts` | Dado `GenerateDocumentationFile` encendido, cuando corre el build, entonces termina sin advertencias; instrumento: build con avisos como error | pendiente |
| RD-05 | consumidor-api | Detectar un cambio del contrato REST en el mismo pull request | CL-05 `openapi/v1.json` extraído en la CI | Dado el contrato extraído del servicio levantado en la CI, cuando cambia un punto de acceso, entonces el diff del contrato lo muestra; instrumento: PR-6 contrato | pendiente |
| RD-06 | alumno | Entender qué hacer en cada pantalla según su rol | CL-06 ayuda por rol de `GeometriaFactory.Web` | Dado una página de ayuda con `traces`, cuando corre PR-5, entonces cada traza resuelve a un caso de uso de la unidad Web; instrumento: PR-5 trazas | pendiente |
| RD-07 | desarrollo | Saber cómo intervenir la documentación del proyecto | CL-12 `docs/_gobierno/como-intervenir.md` | Dado el proceso, cuando corre la compuerta, entonces contesta los seis campos y pasa en verde; instrumento: PR-2 y revisión del PR | pendiente |
| RD-08 | desarrollo | Saber a qué audiencia se entrega cada pieza y con qué nivel | A-12 `docs/_gobierno/registro-audiencias.md` | Dado el registro de audiencias, cuando corre PR-2, entonces su frontmatter es válido y cada audiencia declara `incluye` y nivel; instrumento: PR-2 esquema | pendiente |
| RD-09 | agente | Saber contra qué revisión vale el índice para agentes | CL-08 `ia-db/source.lock` del repositorio hermano | Dado el `source.lock`, cuando corre el carril programado, entonces informa el atraso contra la rama principal; instrumento: carril programado (aviso) | pendiente |
