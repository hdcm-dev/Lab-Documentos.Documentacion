---
doc_id: N3
doc_type: nucleo
title: N3 — El registro de eventos de Windows
status: vigente
traces: [BIT-02-NUCLEOS, ESC-TESTIGO, ESC-CORPUS]
---

# N3 — El registro de eventos de Windows

**Pregunta que resuelve:** ¿dónde queda escrito lo que pasó y cómo lo leo?

## Ideas agrupadas
- Canales de log: Security, System, Application, y los operativos.
- Anatomía de un evento: ID, proveedor, hora, campos.
- Herramientas de lectura: Visor de eventos (GUI), `Get-WinEvent`, `wevtutil`.
- IDs de acceso: 4624 (logon ok) con sus Logon Types, 4625 (fallo) con subestados, 4634/4647, 4648, 4672.
- Detección de manipulación: 1102 (borrado del log de seguridad), 1100/104, huecos temporales.
- Correlación por Logon ID entre eventos de una misma sesión.

## Dependencias
Depende de N1 y N2. Es el eje del que salen N4 y N5. Se enriquece con N6.

## Evidencia que usa
Documentación de eventos 4624 y 1102 (Microsoft); referencia de `Get-WinEvent`/`wevtutil`.

## Mapa a la guía
Secciones 4 y 5. Núcleo central del caso (evento 1102).
