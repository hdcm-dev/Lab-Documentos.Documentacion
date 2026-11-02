# Inserción en `changelog.md` de `LGD` (A-11, CL-13)

**Punto de inserción.** Antes de la entrada más reciente, «2026-10-26 — ia-db 4.0: regeneración completa sobre
`4b114d7`» (`LGD/changelog.md:12`), después del separador (`LGD/changelog.md:10`): este registro va de la más nueva a
la más vieja (`LGD/changelog.md:12`, `LGD/changelog.md:146`).

```markdown
## {fecha de la fusión} — Adopción del sistema documentador

### Agregado

- `ia-db/source.lock`: ancla del índice contra el repositorio del código (`base_commit` `4b114d7`, etiqueta `v1.2.0`), la misma revisión que ya declaraba `ia-db/README.md` §2.
- `.github/workflows/carril-programado.yml`: carril semanal que sólo avisa, con un issue, el atraso del índice y su frescura (365 días).
- `AGENTS.md`: puntero de tres líneas para agentes.
```
