# NC-05 — El sistema vivo

**Tipo:** registro de análisis y planificación por núcleo conceptual
**Fecha:** 2026-09-17
**Cohesión:** ver [NC-00-Cohesion.md](NC-00-Cohesion.md)
**Trazabilidad:** este núcleo se materializa en §6 del entregable.

## Pregunta del lector que responde
¿Qué está corriendo y con qué relaciones ahora mismo?

## Ideas agrupadas (por afinidad/dependencia, no por extensión)
- Procesos, PID, ruta y firma digital.
- Nombres impostores; árbol de procesos (padre→hijo) como anti-LOLBin.
- Servicios y tareas programadas (persistencia).
- Sesiones/usuarios activos; Script Block Logging.

## Depende de / Aporta a
Depende de: NC-01, NC-03. Aporta a: NC-06, NC-07.

## Decisiones de tratamiento
- El árbol de procesos es el eje: desenmascara el 'vivir de la tierra' de NC-02.
- Se cruza cada hallazgo con el evento correspondiente de NC-04.

## Riesgo de integración y cómo se mitigó
Riesgo: confundir muestreo con monitoreo. Mitigación: se marca que es una foto y se remite a telemetría continua.
