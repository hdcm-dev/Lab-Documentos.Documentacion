---
doc_id: RD-INICIAL
doc_type: rrd
title: Registro de requerimientos documentales de Colmenar
description: RRD inicial de la adopción; una fila por pieza nueva y por clase activa sin pieza. Propuesta en borrador.
status: borrador
origin: ia-assisted
confidence: media
owner: pendiente (D-11)
last_review: 2026-11-02
audience: [desarrollo, po]
traces: [FIC-DISENO-DOCUMENTAL, FIC-NO-EXISTE]
---

# Registro de requerimientos documentales de Colmenar

Propuesta del aplicador, en borrador. Cada fila la decide una persona; mientras tanto, «pendiente». Las audiencias de
la columna 2 orientan la escritura; no son permisos (las de entrega viven en el registro de audiencias).

| ID | Audiencia | Tarea | Pieza | Criterio | Decisión |
| --- | --- | --- | --- | --- | --- |
| RD-01 | desarrollo | Saber qué se decidió del sistema documentador y qué queda abierto | CL-01, `docs/_diseno/ficha-diseno-documental.md` | Dado un pull request que toca documentación, cuando la compuerta corre, entonces la ficha pasa esquema y trazas; instrumento: PR-2 y PR-5 | pendiente |
| RD-02 | agente | Encontrar dónde está la documentación y qué no decide | CL-03, `AGENTS.md` | Dado un asistente que abre el repositorio, cuando lee `AGENTS.md`, entonces cada enlace resuelve a una pieza que existe; instrumento: PR-1 | pendiente |
| RD-03 | desarrollo | Intervenir en la documentación con el guion local y la regla de fusión | CL-12, `docs/_gobierno/como-intervenir.md` | Dado un cambio documental, cuando quien lo propone sigue la página, entonces corre los mismos grupos que la CI; instrumento: PR-2 y revisión | pendiente |
| RD-04 | desarrollo | Registrar los cambios de cada entrega y las exigencias EX que cumple | CL-13, `CHANGELOG.md` | Dado un pull request de entrega, cuando se fusiona, entonces el CHANGELOG tiene su entrada con las exigencias EX; instrumento: revisión | pendiente |
| RD-05 | persona-usuaria | Usar cada pantalla con la ayuda de su perfil, en español o en portugués | CL-06, carpeta de ayuda de la app (pendiente) | Dado un perfil con sesión, cuando abre la ayuda, entonces recibe sólo la de su perfil y en su idioma; instrumento: pruebas de entrega pareadas (pendiente) | pendiente |
| RD-06 | desarrollo | Leer la documentación técnica de la app | CL-07, `docs/tecnica/` | Dado un documento técnico nuevo, cuando la compuerta corre, entonces pasa enlaces, esquema y mermaid; instrumento: PR-1, PR-2 y PR-4 | pendiente |
| RD-07 | desarrollo | Consultar la referencia del código generada desde sus comentarios | CL-04, build de la app y del paquete | Dado un build con avisos como error, cuando falta un comentario público, entonces el build da rojo; instrumento: build (pendiente) | pendiente |
| RD-08 | persona-usuaria | Aprender a usar la app paso a paso en el sitio público | CL-06 y CL-14, sitio público (pendiente) | Dado el build del sitio, cuando se publica, entonces sólo contiene piezas de nivel publico; instrumento: paquete-sin-fuga e indice-sin-fuga (pendiente) | pendiente |
| RD-09 | humano | Resolver los ejercicios del curso con enunciado y solución | CL-10, repositorio dedicado del curso (pendiente) | Dado un ejercicio, cuando se publica, entonces tiene enunciado, solución y source.lock al SHA de la app; instrumento: compuerta completa del repositorio del curso | pendiente |
| RD-10 | po | Saber a quién se entrega cada pieza | Registro de audiencias, `docs/_gobierno/registro-audiencias.md` | Dado el registro, cuando una persona decide las filas abiertas, entonces cada audiencia tiene acceso, nivel y punto de cumplimiento con ruta:línea; instrumento: revisión | pendiente |
