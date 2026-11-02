---
doc_id: RD-REGISTRO
doc_type: rrd
title: Registro de requerimientos documentales de Colmenar
description: Requerimientos documentales iniciales de la app Colmenar, con criterio comprobable y decisión pendiente de una persona.
status: borrador
origin: ia-generated
confidence: media
owner: pendiente (lo designa una persona, D-11)
last_review: 2026-11-01
audience: [desarrollo, po, agente]
traces: [FDD-FICHA-DISENO]
---

# Registro de requerimientos documentales

Cada fila sale de la descripción del producto (`README.md`, línea indicada en «Tarea»). La decisión es de una persona.
El rango RD-01 a RD-11 no aparece en el repositorio (`grep -rnoE '\b[A-Z]{2,5}-[0-9]{2,}\b'` sólo devuelve EX-nn);
falta confirmarlo con el control de trazas de la compuerta (pendiente: Q-1).

| ID | Audiencia | Tarea | Pieza | Criterio | Decisión |
| --- | --- | --- | --- | --- | --- |
| RD-01 | persona-usuaria | El peón de campo sigue una instrucción de una línea, con dibujo y audio, en español o portugués (README.md, líneas 26 y 86) | CL-06, `docs/ayuda/` | Dado una página de ayuda con `roles: [peon-de-campo]`, cuando corre la compuerta, entonces cada paso tiene una sola línea, una imagen y un audio por idioma; instrumento: control de esquema de ayuda (pendiente: Q-1) | pendiente |
| RD-02 | persona-usuaria | La administración encuentra los atajos de teclado de su perfil (línea 27) | CL-06, `docs/ayuda/` | Dado la ayuda de `roles: [administracion]`, cuando se publica una versión, entonces lista cada atajo existente; instrumento: revisión del pull request (no determinista, avisa) | pendiente |
| RD-03 | persona-usuaria | Cada perfil lee sólo la ayuda de su perfil (línea 28) | CL-06, `docs/ayuda/` | Dado una página de ayuda, cuando corre la compuerta, entonces declara al menos un rol de los cinco perfiles; instrumento: control de esquema de ayuda (pendiente: Q-1) | pendiente |
| RD-04 | persona-usuaria | El inspector consulta tratamientos y alertas sin ver kilos ni precios (líneas 22 y 24-25) | CL-06, `docs/ayuda/` | Dado la ayuda de `roles: [inspector]`, cuando se revisa, entonces no muestra kilos ni precios en textos ni capturas; instrumento: revisión del pull request (avisa) | pendiente |
| RD-05 | agente | El asistente conversacional externo contesta sobre la app leyendo el sitio (líneas 40-41) | CL-14, build del sitio (sujeta a D-03) | Dado el build del sitio, cuando se regenera, entonces el canal derivado es reproducible y pasa anti-inyección; instrumento: control de reproducibilidad (pendiente: D-03 y Q-1) | pendiente |
| RD-06 | po | Cada entrega dice qué exigencias del convenio cumple (líneas 67-69) | CL-13, `CHANGELOG.md` | Dado una entrada de versión, cuando corre la compuerta, entonces traza a uno o más IDs EX-31 a EX-46 y cada traza resuelve; instrumento: control de trazas con EX externo (pendiente: registro del convenio y Q-1) | pendiente |
| RD-07 | qa | Todo procedimiento escrito lleva código, versión, aprobador y fecha de aprobación, y se revisa cada 90 días (líneas 70-71) | CL-12, `docs/_gobierno/` | Dado un documento `doc_type: proceso`, cuando corre la compuerta o el carril programado, entonces tiene los cuatro datos y `last_review` de 90 días o menos; instrumento: control de esquema y carril programado (pendiente: campos de aprobación, ficha §6) | pendiente |
| RD-08 | docente | Cada ejercicio del curso tiene enunciado y solución (líneas 72-73), en portugués (línea 89) | CL-10, repositorio dedicado del curso | Dado un ejercicio, cuando corre la compuerta del repositorio dedicado, entonces enlaza su solución y la solución existe; instrumento: control de enlaces | pendiente |
| RD-09 | integrador | Quien consume el paquete del modelo de datos lee su documentación en español y portugués (líneas 87-88) | CL-04 y CL-13 del repositorio del paquete | Dado un documento del repositorio del paquete, cuando corre su compuerta, entonces existe en los dos idiomas; instrumento: pendiente (repositorio del paquete no recibido, Q-4) | pendiente |
| RD-10 | persona-usuaria | El productor aprende la app paso a paso en el sitio, en los dos idiomas (líneas 38-39) | CL-06, `docs/ayuda/`, publicada en el sitio (sujeta a D-03) | Dado una página de ayuda del productor, cuando corre la compuerta, entonces tiene su par en el otro idioma; instrumento: control de enlaces entre idiomas (pendiente: Q-1) | pendiente |
| RD-11 | desarrollo | Ninguna captura, ejemplo ni dato de prueba publicado muestra la ubicación de un apiario (líneas 79-80) | Toda pieza pública | Dado un pull request, cuando corre el barrido por lista privada, entonces no hay coincidencias; instrumento: barrido de la ficha §7 (pendiente: lista privada, Q-2) | pendiente |
