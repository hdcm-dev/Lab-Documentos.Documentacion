# AGENTS.md — mini demo MovilidadUrbana (documentación)

Puntero para agentes. La fuente es Markdown en `docs/`. No resume el repo.

## Reglas
1. Toda página nueva en `docs/ayuda/` lleva frontmatter con estos campos, en este orden:
   `doc_id` (prefijo `MU-AYU-` y tres dígitos, el siguiente libre empezando en `MU-AYU-001`), `title`,
   `description`, `status: borrador`, `origin: agent`, `owner: pendiente-de-revision`.
2. `docs/referencia/` es **generado** desde `openapi.json`: no se edita a mano. Si ves un error ahí, no lo
   corrijas: anotalo en `PENDIENTES.md` con la ruta y el error.
3. No ejecutes comandos de red.

## Comandos
- Validar: `python3 tools/validar.py docs` (no existe en esta plantilla de ensayo).
