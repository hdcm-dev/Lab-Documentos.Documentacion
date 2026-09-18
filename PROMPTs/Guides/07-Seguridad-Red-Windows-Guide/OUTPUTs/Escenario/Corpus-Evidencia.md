---
doc_id: ESC-CORPUS
doc_type: corpus
title: Corpus de evidencia ilustrativa del escenario testigo
status: vigente
origin: ia-assisted
confidence: alta
audience: [humano, agente]
traces: [ESC-TESTIGO, GUIA-PRINCIPAL]
---

# Corpus de evidencia ilustrativa — `SRV-MADERA01`

## Propósito

Reúne los fragmentos ilustrativos de logs y salidas que la guía usa, derivados de la cronología del `ESC-TESTIGO`. **Todos son sintéticos y rotulados como ilustrativos**; ninguno proviene de una captura real. Su valor es la coherencia: las horas, cuentas, IPs y PIDs concuerdan entre todos los fragmentos y con la línea de tiempo del escenario.

## Constantes del escenario (fuente única)

| Dato | Valor |
|---|---|
| IP del atacante (fuerza bruta y RDP) | `198.51.100.77` |
| IP del canal de control (C2) | `203.0.113.9:443` |
| Cuenta de puerta trasera | `sqlbackup` (creada Día 1 03:14) |
| Proceso malicioso | `svch0st.exe`, PID 6688, padre 4120 |
| Logon ID del acceso RDP | `0x5F3A2` |
| Logon ID del borrado (1102) | `0x7A441` |
| Momento del borrado de log | Día 2 03:05 |

## Fragmentos (por evento)

- **4625 (fuerza bruta):** 843 eventos, subestado `0xC000006A`, origen `198.51.100.77`, ventana 02:14–03:11 Día 1.
- **4624 (acceso Administrador):** Logon Type 10, origen `198.51.100.77`, cuenta `Administrador`, LogonID `0x5F3A2`, 03:12 Día 1.
- **4624 (acceso sqlbackup):** Logon Type 10, origen `198.51.100.77`, cuenta `sqlbackup`, LogonID `0x7A441`, 03:03:40 Día 2 (la sesión que borra el log).
- **4720 + 4732:** alta de `sqlbackup` y su promoción a `Administradores`, 03:14 Día 1.
- **7045 / 4698:** servicio y tarea de persistencia, 03:20 Día 1.
- **netstat -ano:** conexión saliente `10.10.0.10:49712 → 203.0.113.9:443` (PID 6688), Día 2 02:50.
- **Win32_Process 6688:** `svch0st.exe` en `C:\Users\sqlbackup\AppData\Local\Temp\`, línea de comando `-c 203.0.113.9:443`, padre 4120.
- **1102 (borrado):** sujeto `sqlbackup`, LogonID `0x7A441`, 03:05 Día 2.

## Regla de consistencia

Cualquier salida nueva que se agregue a la guía debe respetar estas constantes. Si un fragmento las contradice (otra IP, otra hora), es un error de coherencia, no una variante válida.
