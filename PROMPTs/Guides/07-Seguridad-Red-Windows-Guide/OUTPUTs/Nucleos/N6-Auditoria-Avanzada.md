---
doc_id: N6
doc_type: nucleo
title: N6 — Auditoría avanzada y telemetría
status: vigente
traces: [BIT-02-NUCLEOS, ESC-TESTIGO]
---

# N6 — Auditoría avanzada y telemetría

**Pregunta que resuelve:** ¿cómo hago que el sistema registre lo que hoy no registra?

## Ideas agrupadas
- Por qué faltan datos: política de auditoría "de fábrica" (vicio del escenario).
- Auditoría básica vs. avanzada (Advanced Audit Policy Configuration) y el hecho de que la avanzada anula la básica.
- `auditpol /get /category:*` para ver qué se está auditando; `/set` para habilitar.
- Registrar la línea de comandos en 4688 (política "Include command line in process creation events").
- Sysmon (Sysinternals): qué agrega (Event IDs 1/3/7/8/11/13/22), la config de referencia de la comunidad.
- Reenvío de eventos (WEF) como paso siguiente (mención).

## Dependencias
Alimenta N3 (mejora lo que el registro captura) y N7. Depende de N1–N3.

## Evidencia que usa
`auditpol`; política de creación de procesos con línea de comandos; Sysmon.

## Mapa a la guía
Sección 8.
