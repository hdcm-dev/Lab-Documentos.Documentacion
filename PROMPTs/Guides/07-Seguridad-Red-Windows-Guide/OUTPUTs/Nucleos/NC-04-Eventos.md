# NC-04 — El registro de eventos

**Tipo:** registro de análisis y planificación por núcleo conceptual
**Fecha:** 2026-09-17
**Cohesión:** ver [NC-00-Cohesion.md](NC-00-Cohesion.md)
**Trazabilidad:** este núcleo se materializa en §5 del entregable.

## Pregunta del lector que responde
¿Qué quedó anotado y cómo sé si lo borraron?

## Ideas agrupadas (por afinidad/dependencia, no por extensión)
- Qué es el Event Log; Event ID; registros Security/System/Application.
- Get-WinEvent; tabla de Event IDs clave; anatomía del 4624 (Logon Type).
- Detección del borrado: 1102/104, RecordId, 4719/1100/4616.
- WEF (defensa de fondo) y exportación preventiva.

## Depende de / Aporta a
Depende de: NC-03. Aporta a: NC-07, NC-08, NC-11.

## Decisiones de tratamiento
- Prioridad al par borrado↔detección, porque es el problema declarado por el usuario.
- WEF se explica aunque exceda 'iniciación', por ser LA defensa contra el borrado.

## Riesgo de integración y cómo se mitigó
Riesgo: volverse listado de Event IDs sin criterio. Mitigación: cada ID trae 'por qué importa' y se cruza en las preguntas guía.
