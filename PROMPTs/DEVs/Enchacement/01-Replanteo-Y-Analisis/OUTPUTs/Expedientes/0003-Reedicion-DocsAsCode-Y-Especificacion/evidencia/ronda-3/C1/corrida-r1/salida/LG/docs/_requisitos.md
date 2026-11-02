---
doc_id: RD-REGISTRO
doc_type: rrd
title: Registro de requerimientos documentales de Lab-Geometria
description: RRD inicial de la adopción de la documentación como código; una fila por pieza nueva y por clase activa sin pieza.
status: borrador
origin: ia-assisted
confidence: media
owner: Product Owner
last_review: 2026-11-02
audience: [humano, agente, po, desarrollo]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Registro de requerimientos documentales

Propuesta en borrador: cada decisión la toma una persona (columna Decisión).

| ID | Audiencia | Tarea | Pieza | Criterio | Decisión |
| --- | --- | --- | --- | --- | --- |
| RD-01 | po | Aprobar el diseño del sistema documentador | CL-01, `docs/_diseno/ficha-diseno-documental.md` | Dado el pull request de adopción, cuando la compuerta corre el grupo trazas sobre `docs/`, entonces los artefactos que trazan a la ficha resuelven; instrumento: trazas | pendiente |
| RD-02 | desarrollo | Saber qué requerimiento documental cubre cada pieza | CL-02, `docs/_requisitos.md` | Dado este registro, cuando la compuerta corre el grupo esquema, entonces cada fila tiene ID RD-nn, criterio y decisión; instrumento: esquema | pendiente |
| RD-03 | agente | Encontrar el contrato documental antes de proponer un cambio | CL-03, `AGENTS.md` de cada repo | Dado un agente en la raíz del repo, cuando lee `AGENTS.md`, entonces encuentra enlaces que resuelven al esquema, al guion local y a la lista de decisiones H; instrumento: enlaces | pendiente |
| RD-04 | desarrollo | Leer la referencia del código sin abrir las fuentes | CL-04, documentación XML del build | Dado el build en Release, cuando se activa la generación de la documentación XML, entonces el build termina sin advertencias; instrumento: build con avisos como error (pendiente) | pendiente |
| RD-05 | desarrollo | Comparar el contrato HTTP publicado contra el anterior | CL-05, documento OpenAPI extraído en la CI | Dado el servicio levantado en la CI, cuando se extrae el documento OpenAPI, entonces el diff contra el versionado es vacío o está declarado; instrumento: contrato (pendiente) | pendiente |
| RD-06 | persona-usuaria | Entender cada pantalla según su rol | CL-06, ayuda del front (sin pieza todavía) | Dado un alumno o un administrador, cuando abre la ayuda de una pantalla, entonces ve sólo la de su rol; instrumento: par de entrega pendiente | pendiente |
| RD-07 | humano | Intervenir en el proyecto sabiendo dónde vive cada pieza y quién decide | CL-12, `docs/_gobierno/como-intervenir.md` | Dado el proceso, cuando se revisa, entonces contesta los seis campos con datos del proyecto; instrumento: revisión de una persona | pendiente |
| RD-08 | po | Saber qué audiencia recibe cada pieza y con qué nivel | A-12, `docs/_gobierno/registro-audiencias.md` | Dado el registro, cuando se agrega una página con delivery, entonces su valor está en el registro; instrumento: audiencia-vocabulario (pendiente) | pendiente |
