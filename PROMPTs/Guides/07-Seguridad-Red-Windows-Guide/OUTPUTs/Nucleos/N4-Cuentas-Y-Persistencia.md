---
doc_id: N4
doc_type: nucleo
title: N4 — Cuentas y persistencia
status: vigente
traces: [BIT-02-NUCLEOS, ESC-TESTIGO]
---

# N4 — Cuentas y persistencia

**Pregunta que resuelve:** ¿dejó el intruso una puerta abierta para volver?

## Ideas agrupadas
- Enumerar usuarios y grupos: `Get-LocalUser`, `Get-LocalGroupMember`, `net user`, `net localgroup`; en dominio, los grupos privilegiados.
- Cuentas nuevas o inesperadas contra la línea de base (evento 4720, 4732/4728/4756).
- Persistencia por servicio (evento 7045, `Get-Service`, `sc query`).
- Persistencia por tarea programada (evento 4698, `Get-ScheduledTask`).
- Persistencia por arranque automático (Autoruns de Sysinternals).

## Dependencias
Depende de N3 (los eventos que confirman las altas). Alimenta N7.

## Evidencia que usa
Eventos 4720/4732/7045/4698; cmdlets `Get-LocalUser`, `Get-ScheduledTask`; Autoruns.

## Mapa a la guía
Sección 6.
