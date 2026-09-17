# NC-02 — Anatomía de la intrusión

**Tipo:** registro de análisis y planificación por núcleo conceptual
**Fecha:** 2026-09-17
**Cohesión:** ver [NC-00-Cohesion.md](NC-00-Cohesion.md)
**Trazabilidad:** este núcleo se materializa en §3 del entregable.

## Pregunta del lector que responde
¿Qué hace un atacante y por qué borra los logs?

## Ideas agrupadas (por afinidad/dependencia, no por extensión)
- IoC como concepto transversal.
- Etapas MITRE ATT&CK (acceso→ejecución→persistencia→escalada→evasión→credenciales→recon→lateral→exfiltración).
- Por qué borrar logs (y qué NO logra: 1102, copias WEF, artefactos).
- Living off the land / LOLBins.

## Depende de / Aporta a
Depende de: NC-01. Aporta a: NC-03 (método) y NC-10 (pentest).

## Decisiones de tratamiento
- Cada etapa se enlaza con el capítulo donde se ve su rastro (tabla).
- El diagrama mermaid incluye el bucle 'borrar logs' en evasión.

## Riesgo de integración y cómo se mitigó
Riesgo: quedar en taxonomía abstracta. Mitigación: cada etapa cita el rastro observable concreto.
