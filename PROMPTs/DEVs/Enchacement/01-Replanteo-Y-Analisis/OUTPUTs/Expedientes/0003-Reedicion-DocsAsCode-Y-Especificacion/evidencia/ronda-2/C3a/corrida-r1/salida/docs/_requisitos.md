---
doc_id: RD-REGISTRO
doc_type: rrd
title: Registro de requerimientos documentales de Colmenar
description: Requerimientos documentales iniciales de Colmenar, con criterio Dado/Cuando/Entonces y decisión pendiente.
status: borrador
origin: ia-generated
confidence: media
owner: pendiente (D-11)
last_review: 2026-11-01
audience: [desarrollo, po, agente]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Registro de requerimientos documentales

Rango `RD-01` a `RD-09`: sin uso en el repositorio (`grep -rnoE '\b(RD|FIC|PRC|EX)-[A-Z0-9]+'` sólo devuelve EX
en `README.md:67-68`); falta correr el control de trazas de la compuerta (pendiente de D-09).

| ID | Audiencia | Tarea | Pieza | Criterio | Decisión |
| --- | --- | --- | --- | --- | --- |
| RD-01 | persona-usuaria | El peón entiende una tarea de carga de visita sin leer pantallas largas (`README.md:26`, `README.md:86`) | CL-06, `docs/ayuda/peon/` | Dado un tema de ayuda con `roles: [peon]`, cuando se valida, entonces cada paso es una línea con dibujo y audio en español y en portugués; instrumento: control de esquema de ayuda | pendiente |
| RD-02 | persona-usuaria | La administración encuentra los atajos de teclado (`README.md:27`) | CL-06, `docs/ayuda/administracion/` | Dado un atajo en la app de Windows, cuando cambia en un pull request, entonces el mismo pull request cambia su tema de ayuda; instrumento: revisión del pull request | pendiente |
| RD-03 | persona-usuaria | El productor aprende a usar la app paso a paso en su idioma (`README.md:38-39`) | CL-06 y CL-14, sitio público (sujeto a D-03) | Dado un tema publicado en español, cuando se construye el sitio, entonces existe su par en portugués; instrumento: control de enlaces y trazas | pendiente |
| RD-04 | agente | El asistente del organismo sanitario responde sobre la app leyendo el sitio (`README.md:40-41`) | CL-14 (sujeto a D-03) | Dado el build del sitio, cuando se regenera, entonces el canal derivado es reproducible y pasa el control anti-inyección; instrumento: reproducibilidad | pendiente |
| RD-05 | po | Cada entrega dice qué exigencias EX-31 a EX-46 cumple (`README.md:67-69`) | CL-13, `CHANGELOG.md` | Dada una entrada de versión, cuando se valida, entonces lista sus exigencias y cada una está entre EX-31 y EX-46; instrumento: control de trazas con prefijo externo `EX` | pendiente |
| RD-06 | qa | Todo procedimiento escrito cumple la norma de calidad (`README.md:70-71`) | CL-12, `docs/_gobierno/` | Dado un documento `doc_type: proceso`, cuando se valida, entonces tiene `doc_id`, `version`, `approved_by` y `approval_date`, y su `last_review` no supera 90 días; instrumento: esquema y carril programado | pendiente |
| RD-07 | docente | Cada ejercicio del curso tiene enunciado y solución, en portugués (`README.md:72-73`, `README.md:89`) | CL-10, repo dedicado | Dado un ejercicio, cuando se valida el cuerpo, entonces tiene enunciado y solución enlazados; instrumento: compuerta completa del repo dedicado | pendiente |
| RD-08 | agente | Un asistente sabe qué cambio no se fusiona sin el técnico sanitario jefe (`README.md:65-66`) | CL-03, `AGENTS.md` | Dado `AGENTS.md`, cuando se valida, entonces enlaza a la lista de lo que no decide un agente y sus enlaces resuelven; instrumento: control de enlaces | pendiente |
| RD-09 | desarrollo | Ningún material publicado muestra ubicaciones de apiarios ni nombres de alumnos (`README.md:79-81`) | CL-06, CL-10 y CL-13 | Dado un pull request a un repo público, cuando corre el barrido por lista privada, entonces no da salida; instrumento: barrido de §3.6 | pendiente |
