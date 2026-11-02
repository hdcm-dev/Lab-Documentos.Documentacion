# M4 (invenciones) — C0, ronda 3

Script: `verificar-citas.sh <corrida>`; tablas completas: `citas-C0-r1.tsv`, `citas-C0-r2.tsv`. Se excluyen `salida/inventario/` y `salida/verificacion/` (volcados de herramientas). Respuestas del coordinador: no legibles para este refutador (permiso), no se cuentan.

| Corrida | Citas | OK repo | OK salida | No verificables | Invenciones |
|---|---|---|---|---|---|
| C0-r1 | 50 | 49 | 0 | 1 | 0 |
| C0-r2 | 52 | 52 | 0 | 0 | 0 |

No verificable (C0-r1): `Esquema-Frontmatter-Y-Prefijos.md:54` en `salida/prueba/tools/docs-guard/dg.py:346`. El archivo no está en `repo/`; es un anexo del marco que `conocimiento.md` cita como `99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:41-55` (la línea 54 cae dentro). Es una cita heredada del conocimiento, no una invención.

## Muestra de 20 citas verificadas (contenido de la línea)

- C0-r1 `AGENTS.md:139` → Cambiar 'AGENTS.md' es clase H. La compuerta lo excluye del aviso AI-3 (frases dirigidas a
- C0-r1 `.github/workflows/mini-demo-movilidad.yml:3` → # Baja por git archive el SHA de source.lock (Lab-E2E.WebBlazor, repositorio público: no 
- C0-r1 `README.md:36-39` → / Carpeta / Contenido /
- C0-r1 `.github/workflows/docs-enlaces-semanal.yml:17-18` →   schedule:
- C0-r1 `CHANGELOG.md:13` → - **Datos vencidos (AC-11 a AC-17, P-10 y P-12):** 'traces: []' contado en pasado; cita de
- C0-r1 `.github/workflows/framework-concept-demo.yml:43` →     runs-on: [self-hosted, <runner>]
- C0-r1 `CHANGELOG.md:320-324` → #### Delegación del merge (Conformacion-Pull-Request-Automatico 2.0)
- C0-r1 `AGENTS.md:15-19` → # AGENTS.md — Lab-Documentos
- C0-r1 `CHANGELOG.md:36` → - **Alcance:** los PR del expediente 0003 en este repositorio, incluido el primer merge (e
- C0-r1 `README.md:42` → / ['CHANGELOG.md'](CHANGELOG.md) / Cambios del repositorio y delegaciones vigentes /
- C0-r2 `.github/workflows/docs-guard.yml:60` →     runs-on: [self-hosted, <runner>]
- C0-r2 `AGENTS.md:109-110` → Dos reglas que la compuerta no ve y que no se negocian: en lo versionado no van rutas de u
- C0-r2 `README.md:27-32` → 1. [Guías](Guides/README.md): el índice por categoría.
- C0-r2 `AGENTS.md:139-142` → Cambiar 'AGENTS.md' es clase H. La compuerta lo excluye del aviso AI-3 (frases dirigidas a
- C0-r2 `CHANGELOG.md:340-346` → #### Delegación del merge (Conformacion-Pull-Request-Automatico 2.0)
- C0-r2 `Concepts/Framework-Concept/Conocimientos/Knowledge-App-Hibrida-OTA-Offline-First.md:4` → **Naturaleza:** propio
- C0-r2 `.github/workflows/docs-guard.yml:63` →       RUTA: ${{ inputs.ruta // 'Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-In
- C0-r2 `README.md:16-17` → Repositorio de guías de estudio y conceptos para el desarrollo de software: arquitectura,
- C0-r2 `CHANGELOG.md:320-327` → #### Delegación del merge (Conformacion-Pull-Request-Automatico 2.0)
- C0-r2 `AGENTS.md:54` → / ['CHANGELOG.md'](CHANGELOG.md) / Cambios del repositorio y las delegaciones del merge vi
