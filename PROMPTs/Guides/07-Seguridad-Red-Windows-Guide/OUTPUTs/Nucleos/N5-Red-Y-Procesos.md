---
doc_id: N5
doc_type: nucleo
title: N5 — Red y procesos vivos
status: vigente
traces: [BIT-02-NUCLEOS, ESC-TESTIGO, ESC-CORPUS]
---

# N5 — Red y procesos vivos

**Pregunta que resuelve:** ¿hay algo conectado o corriendo ahora mismo?

## Ideas agrupadas
- Conexiones activas: `netstat -ano`, `Get-NetTCPConnection` (estados TCP; columna OwningProcess/PID).
- Mapear conexión → proceso → ejecutable: unir el PID de la conexión con `Get-Process`/`tasklist /svc`.
- Estados TCP y su lectura (LISTEN, ESTABLISHED, TIME_WAIT…); tres dialectos de nombres (RFC, netstat, PowerShell).
- Sesiones remotas: `quser`/`query user`, `qwinsta`, `net session`, `Get-SmbSession`, `Get-SmbOpenFile`.
- Herramientas visuales: TCPView, Process Explorer.
- Nota de captura instantánea: netstat/Get-NetTCPConnection ven el presente; el histórico se reconstruye con eventos 5156/Sysmon.

## Dependencias
Depende de N1 y N3. Alimenta N7.

## Evidencia que usa
`netstat` y `Get-NetTCPConnection` (Microsoft Learn); estados TCP (RFC 9293); `quser`/`Get-SmbSession`; evento 5156.

## Mapa a la guía
Sección 7.
