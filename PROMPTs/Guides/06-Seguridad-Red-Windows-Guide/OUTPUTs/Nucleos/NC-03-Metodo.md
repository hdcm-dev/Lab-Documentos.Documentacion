# NC-03 — Método de investigación sin destruir evidencia

**Tipo:** registro de análisis y planificación por núcleo conceptual
**Fecha:** 2026-09-17
**Cohesión:** ver [NC-00-Cohesion.md](NC-00-Cohesion.md)
**Trazabilidad:** este núcleo se materializa en §4 del entregable.

## Pregunta del lector que responde
¿Cómo se investiga sin arruinar la evidencia ni alertar al atacante?

## Ideas agrupadas (por afinidad/dependencia, no por extensión)
- Principio de no daño (destruir evidencia / alertar).
- Orden de volatilidad (RFC 3227).
- Línea de base y técnica del diferencial.
- Preservar antes de mirar; cadena de custodia; triage.

## Depende de / Aporta a
Depende de: NC-02. Aporta a: NC-04..NC-08 (todo lo operativo pasa por aquí).

## Decisiones de tratamiento
- Es capítulo-compuerta: precede a todo comando.
- Introduce el diferencial que NC-06 usa en la red.
- Supuesto de acceso legítimo (parche P-05).

## Riesgo de integración y cómo se mitigó
Riesgo: sonar burocrático y saltearse. Mitigación: se justifica con consecuencias concretas (apagar borra la RAM).
