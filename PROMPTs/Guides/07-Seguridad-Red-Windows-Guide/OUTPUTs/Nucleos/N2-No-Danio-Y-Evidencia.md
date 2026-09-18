---
doc_id: N2
doc_type: nucleo
title: N2 — Reglas de no daño y manejo de evidencia
status: vigente
traces: [BIT-02-NUCLEOS, ESC-TESTIGO]
---

# N2 — Reglas de no daño y manejo de evidencia

**Pregunta que resuelve:** ¿qué NO hacer para no destruir la prueba antes de mirarla?

## Ideas agrupadas
- Orden de volatilidad (RFC 3227): recolectar primero lo más efímero (memoria, conexiones, procesos) y después lo persistente (discos, logs archivados).
- Principio de mínima alteración: cada comando que se ejecuta deja huella; preferir lectura antes que cambios.
- Cadena de custodia y registro de acciones (qué se corrió, cuándo, con qué cuenta).
- Encuadre NIST SP 800-61: preparación, detección/análisis, contención/erradicación/recuperación, post-incidente.
- Cuándo NO seguir solo: cuándo escalar a un profesional o desconectar.

## Dependencias
Depende de N1 (para nombrar lo que se preserva). Antecede a N3–N5 (condiciona el orden de recolección).

## Evidencia que usa
RFC 3227 (orden de volatilidad); NIST SP 800-61r2 (ciclo de manejo de incidentes).

## Mapa a la guía
Sección 3. Es la que va **antes** del primer comando.
