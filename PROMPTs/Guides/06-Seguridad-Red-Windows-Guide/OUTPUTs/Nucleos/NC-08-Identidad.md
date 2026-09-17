# NC-08 — Identidad y Active Directory

**Tipo:** registro de análisis y planificación por núcleo conceptual
**Fecha:** 2026-09-17
**Cohesión:** ver [NC-00-Cohesion.md](NC-00-Cohesion.md)
**Trazabilidad:** este núcleo se materializa en §9 del entregable.

## Pregunta del lector que responde
¿Quién tiene poder sobre el dominio y quién se lo dio?

## Ideas agrupadas (por afinidad/dependencia, no por extensión)
- Por qué el atacante persigue las identidades.
- Grupos privilegiados; cuentas nuevas/latentes.
- Ataques clásicos (brute force, Kerberoasting, PtH/PtT, DCSync, Golden Ticket) y sus rastros.
- Herramientas de auditoría (PingCastle, Purple Knight, BloodHound).

## Depende de / Aporta a
Depende de: NC-01, NC-04. Aporta a: NC-10, NC-11.

## Decisiones de tratamiento
- Se presenta como introducción y se remite a especialista para lo serio.
- Nota RSAT y nota de auditoría requerida (parche P-03).

## Riesgo de integración y cómo se mitigó
Riesgo: presuponer conocimiento de AD. Mitigación: cada ataque se explica en una frase + su rastro; fallback net group.
