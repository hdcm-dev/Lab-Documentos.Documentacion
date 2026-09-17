# NC-07 — Artefactos que sobreviven al borrado

**Tipo:** registro de análisis y planificación por núcleo conceptual
**Fecha:** 2026-09-17
**Cohesión:** ver [NC-00-Cohesion.md](NC-00-Cohesion.md)
**Trazabilidad:** este núcleo se materializa en §8 del entregable.

## Pregunta del lector que responde
¿Qué queda cuando los logs ya no están?

## Ideas agrupadas (por afinidad/dependencia, no por extensión)
- Definición de artefacto forense.
- Prefetch, Amcache/ShimCache, MFT/USN Journal, SRUM.
- KAPE y Velociraptor para recolectar sin ser forense.
- Memoria RAM: lo más valioso y más frágil.

## Depende de / Aporta a
Depende de: NC-04, NC-05. Aporta a: NC-11.

## Decisiones de tratamiento
- Es la segunda gran respuesta a 'borran los logs'.
- Afirmaciones fuertes ancladas a bibliografía (parche P-02).

## Riesgo de integración y cómo se mitigó
Riesgo: exigir herramientas forenses complejas. Mitigación: se separa 'qué debe saber que existe' de 'qué puede hacer' (capturar RAM a tiempo).
