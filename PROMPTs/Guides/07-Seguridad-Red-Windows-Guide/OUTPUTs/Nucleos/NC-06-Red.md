# NC-06 — La red

**Tipo:** registro de análisis y planificación por núcleo conceptual
**Fecha:** 2026-09-17
**Cohesión:** ver [NC-00-Cohesion.md](NC-00-Cohesion.md)
**Trazabilidad:** este núcleo se materializa en §7 del entregable.

## Pregunta del lector que responde
¿Con quién habla mi servidor? (pregunta original del usuario)

## Ideas agrupadas (por afinidad/dependencia, no por extensión)
- Conexión establecida vs. puerto en escucha; problema del muestreo.
- Get-NetTCPConnection con proceso dueño; netstat -anob.
- Procesos que no deberían tener red.
- Diferencial de destinos (Compare-Object); detección continua (Sysmon EID 3, firewall, beaconing).

## Depende de / Aporta a
Depende de: NC-01, NC-05. Aporta a: NC-11.

## Decisiones de tratamiento
- Responde directamente la consulta 'conexiones activas'.
- Se insiste en el muestreo como límite y se ofrece el diferencial como solución de bajo costo.

## Riesgo de integración y cómo se mitigó
Riesgo: exigir equipamiento inexistente. Mitigación: primero comandos nativos; el tooling continuo se 'nombra para pedir', no se exige.
