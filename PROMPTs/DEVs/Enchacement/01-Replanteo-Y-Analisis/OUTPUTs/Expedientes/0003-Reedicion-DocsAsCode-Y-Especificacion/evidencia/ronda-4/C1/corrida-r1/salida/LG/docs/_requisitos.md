---
doc_id: RD-RRD
doc_type: rrd
title: Registro de requerimientos documentales
description: RRD inicial de la adopción; una fila por pieza nueva y por clase activa que todavía no tiene pieza.
status: borrador
origin: ia-generated
confidence: media
owner: Product Owner
last_review: 2026-11-02
audience: [desarrollo, po]
traces: [FIC-FICHA]
---

# Registro de requerimientos documentales

Cada fila la decide una persona; mientras tanto, «pendiente». El rango `RD-01` a `RD-12` está libre en todo el
repositorio (comando 9 de la [ficha](_diseno/ficha-diseno-documental.md)).

| ID | Audiencia | Tarea | Pieza | Criterio | Decisión |
| --- | --- | --- | --- | --- | --- |
| RD-01 | po | Aprobar el diseño documental | CL-01, `docs/_diseno/ficha-diseno-documental.md` | Dado el pull request de adopción, Cuando la persona revisa la ficha, Entonces cada decisión H tiene su estado y su default; instrumento: compuerta PR-2 y PR-5 | pendiente |
| RD-02 | desarrollo | Escribir un documento nuevo con frontmatter válido | `docs/_gobierno/esquema-frontmatter.md` y el esquema de la copia | Dado un documento nuevo en `docs/`, Cuando abre el pull request, Entonces PR-2 da verde sólo con el vocabulario declarado; instrumento: PR-2 esquema | pendiente |
| RD-03 | desarrollo | Saber cómo intervenir sin preguntar | CL-12, `docs/_gobierno/como-intervenir.md` | Dado un cambio documental, Cuando la persona sigue los seis campos, Entonces corre el guion local y la compuerta da el mismo resultado que la CI; instrumento: PR-1 a PR-7 | pendiente |
| RD-04 | agente | Encontrar el contrato y el guion antes de proponer | CL-03, `AGENTS.md` de cada repositorio | Dado un agente que entra al repositorio, Cuando lee `AGENTS.md`, Entonces los tres punteros resuelven; instrumento: PR-1 enlaces | pendiente |
| RD-05 | desarrollo | Trazar un documento a un ID que existe | Registro de prefijos de la copia | Dado un documento con `traces`, Cuando la traza nombra un ID inexistente, Entonces PR-5 da rojo; instrumento: PR-5 trazas | pendiente |
| RD-06 | po | Ver la línea de base de cada control antes de que bloquee | `docs/_gobierno/linea-de-base.md` | Dado un control, Cuando su línea de base sobre `docs/` es 0 y tiene par rojo/verde, Entonces pasa de avisa a bloquea; instrumento: tabla de la línea de base | pendiente |
| RD-07 | alumno | Recibir sólo la documentación que su sesión autoriza | `docs/_gobierno/audiencias.md` | Dado un alumno con sesión, Cuando pide una pieza de nivel producto, Entonces recibe 200 con contenido, y sin sesión distinto de 200 sin contenido; instrumento: prueba de entrega pareada | pendiente |
| RD-08 | docente | Saber qué documentación es sólo del administrador | `docs/_gobierno/audiencias.md` | Dado el registro de audiencias, Cuando se declara una pieza para el administrador, Entonces su fila nombra el punto que la hace cumplir; instrumento: `nivel-vs-repo` | pendiente |
| RD-09 | desarrollo | Leer la referencia de la API generada desde el código | CL-04, comentarios XML del código | Dado el build, Cuando se encienda la generación de documentación, Entonces el build termina sin avisos; instrumento: build con avisos como error | pendiente |
| RD-10 | desarrollo | Comparar el contrato REST con el versionado | CL-05, documento OpenAPI `/openapi/v1.json` | Dado un pull request que cambia la superficie, Cuando un paso de la CI levanta el servicio y extrae el contrato, Entonces PR-6 compara contra el versionado; instrumento: PR-6 contrato | pendiente |
| RD-11 | agente | Saber cuánto atrasa el índice frente al código | CL-08, `ia-db/` del repositorio hermano | Dado el índice anclado a un SHA, Cuando corre el carril semanal, Entonces el issue informa el atraso; instrumento: carril programado | pendiente |
| RD-12 | alumno | Entender un campo del formulario de envío | CL-06, microtexto de `GeometriaFactory.Web` | Dado el formulario de envío, Cuando el alumno lee la ayuda del campo, Entonces el texto traza a la regla que lo valida; instrumento: `contexto-resuelve` | pendiente |
