---
doc_id: RD-COLMENAR
doc_type: rrd
title: Registro de requerimientos documentales de Colmenar
description: RRD inicial de la adopción de documentación como código en Colmenar, una fila por pieza nueva o clase activa sin pieza.
status: borrador
origin: ia-generated
confidence: media
owner: aplicador
last_review: 2026-11-02
audience: [desarrollo, po]
traces: [FIC-COLMENAR-DISENO]
---

# Registro de requerimientos documentales

| ID | Audiencia | Tarea | Pieza | Criterio | Decisión |
| --- | --- | --- | --- | --- | --- |
| RD-01 | desarrollo | Saber qué decidir y dónde vive cada pieza | CL-01 `docs/_diseno/ficha-diseno-documental.md` | Dado un PR que cambia la documentación, Cuando corre la compuerta, Entonces la ficha pasa esquema y trazas; instrumento: PR-2 y PR-5 | pendiente |
| RD-02 | agente | Encontrar la documentación y el guion local antes de proponer | CL-03 `AGENTS.md` | Dado un agente que abre el repo, Cuando lee `AGENTS.md`, Entonces cada enlace resuelve; instrumento: PR-1 | pendiente |
| RD-03 | desarrollo | Saber cómo intervenir en el repo | CL-12 `docs/_gobierno/como-intervenir.md` | Dado un PR nuevo, Cuando corre la compuerta, Entonces la instancia pasa esquema y enlaces; instrumento: PR-1 y PR-2 | pendiente |
| RD-04 | persona-usuaria | Usar la app según su perfil y su idioma | CL-06 ayuda por rol y por idioma (sin pieza todavía) | Dado un perfil del registro de audiencias, Cuando abre la ayuda, Entonces recibe sólo la de su perfil; instrumento: par de entrega pendiente | pendiente |
| RD-05 | desarrollo | Entender la arquitectura de la app | CL-07 `docs/tecnica/` (sin pieza todavía) | Dado un documento técnico nuevo, Cuando corre la compuerta, Entonces pasa esquema, enlaces y mermaid; instrumento: PR-2 y PR-4 | pendiente |
| RD-06 | desarrollo | Consultar la referencia de la API pública del código | CL-04 comentarios del código (generación apagada) | Dado un build, Cuando se compila con avisos como error, Entonces no hay comentarios faltantes; instrumento: build pendiente | pendiente |
| RD-07 | estudiante | Resolver los ejercicios del curso | CL-10 guía de estudio en repo dedicado (sin pieza todavía) | Dado un ejercicio, Cuando se publica, Entonces tiene enunciado y solución; instrumento: compuerta completa del repo dedicado | pendiente |
| RD-08 | desarrollo | Saber qué cambió en cada versión y qué exigencias EX cumple | CL-13 `CHANGELOG.md` | Dado un PR de entrega, Cuando corre la compuerta, Entonces el CHANGELOG tiene su entrada; instrumento: control pendiente | pendiente |
| RD-09 | persona-usuaria | Leer en el sitio público cómo usar la app | CL-14 canales derivados del build del sitio (sin pieza todavía) | Dado un build del sitio, Cuando se regenera, Entonces la salida es reproducible; instrumento: control pendiente | pendiente |
| RD-10 | po | Saber a quién se entrega cada página | `docs/_gobierno/registro-audiencias.md` | Dado una página con `delivery:`, Cuando corre la compuerta, Entonces cada valor está en el registro; instrumento: control pendiente | pendiente |
