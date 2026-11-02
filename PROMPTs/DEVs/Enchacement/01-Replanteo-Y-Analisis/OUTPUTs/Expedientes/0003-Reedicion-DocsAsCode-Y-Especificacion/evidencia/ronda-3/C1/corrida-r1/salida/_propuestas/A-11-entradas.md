# A-11 — Entradas en el índice del proyecto y en el registro de cambios

## Destino 1: índice para agentes, `LGD/ia-db/README.md`

Línea de inserción: después de la línea 29 (última fila de la «Tabla de navegación»).

```markdown
| Cómo se documenta el proyecto: la ficha de diseño documental, el registro de prefijos, el esquema y la compuerta `docs-guard` | `docs/_diseno/ficha-diseno-documental.md` del repo del código, en el SHA de [`source.lock`](source.lock) |
```

## Destino 2: registro de cambios del código, `LG/changelog.md`

Línea de inserción: al final del archivo (después de la línea 2140; el registro va de la etapa más vieja a la más nueva).

```markdown
## Adopción de la documentación como código — {fecha de fusión}

- `docs/`: ficha de diseño documental (`FIC-DISENO-DOCUMENTAL`), RRD inicial, proceso «Cómo intervenir» y registro de audiencias, en borrador.
- `.docs-guard/` y `.docs-guard-origen/`: copia con huella de la compuerta de origen; `.github/workflows/docs-guard.yml` avisa hasta tener línea de base 0.
```

## Destino 3: registro de cambios de la documentación, `LGD/changelog.md`

Línea de inserción: antes de la línea 12 (la entrada más nueva va primero).

```markdown
## {fecha de fusión} — `AGENTS.md`, `ia-db/source.lock` y carril semanal de atraso

- `AGENTS.md` puntero; `ia-db/source.lock` fija el SHA del código indexado; `docs-atraso-semanal` avisa con un issue.
```
