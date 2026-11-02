# E11 — Enlace a Lab-Geometria tras la fusión de #236

2026-11-02. Integración parte B, guía 16.

## Verificación

- `git fetch` en el clon de Lab-Geometria: `origin/main` = `c5afa0e` (merge de #236); `5f07b12` es ancestro de `main`.
- `c5afa0e` contiene `SDD/Expedientes/0002-Capa-De-IA-Pistas-Y-Borrador/` y `ai-layer/` (incluye `ensayos/banco.json`, criterio y corrida 2026-11-01).
- HTTP 200: `tree/c5afa0e/SDD/Expedientes/0002-Capa-De-IA-Pistas-Y-Borrador`, `tree/c5afa0e/ai-layer`, `tree/c5afa0e/ai-layer/ensayos`, `tree/main/ai-layer`, `blob/5f07b12/.../Observation.cs`.

## Cambios (en el clon; se copian al worktree del PR único)

Convención del capítulo: URL fija a commit. Se mantiene `5f07b12` para el producto y se usa `c5afa0e` para especificación y ensayo.

- Libro §16 (l. 3091): «en la rama de trabajo `g16/ai-layer-v1`, que no se fusionó a `main`» → en `main`, con enlaces al expediente 0002 y a `ai-layer` en `c5afa0e`.
- Libro §16.3 (l. 3157): «versionados en esa rama de trabajo» → enlace a `ai-layer/ensayos` en `c5afa0e`.
- REF-207: agrega `c5afa0e`; consultado 2026-11-02.
- `tools/compuerta-referencias.excepciones`: se quita la línea `g16/ai-layer-v1` (el libro ya no nombra la rama).
- Conocimiento (`knowledge-AI-Layer-Integration-Designing-Specification.md`, l. 570): no menciona rama; sin cambios.

## Compuertas

| Compuerta | rc | Resultado |
|---|---|---|
| `contar.sh` | 0 | 59386 / 60000 (antes 59385) |
| `verificar-markdown.py guia` | 0 | 4 rutas exceptuadas |
| `compuerta-referencias.sh` | 0 | 0 rotas en 21 archivos |
| `compuerta-intervalos.py` libro + Evidencia/R-LLM | 0 | 28/28; 21/21 |
| `compuerta-rpriv.sh` con listas (libro y Conocimiento) | 0 | 0 hallazgos (patrones=3, lista=20, históricos=2) |
| `tools/medios/mermaid.sh` | 0 | ok |

## sha256

- libro: `9a00c490496a2eafa19b429be4a3a95370b0911798bf5a426a229be34cde76d7`
- `compuerta-referencias.excepciones`: `270caf569fa1f4e77713b90f216fa0a73384d276a418f6eec4a79db4ab39a2bc`
