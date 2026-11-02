# A-11 — Entradas para el índice y los CHANGELOG (propuesta)

Se entregan la entrada y su punto de inserción, no el archivo entero.

## 1. `LG/changelog.md` — al final del archivo (después de la línea 2140; el registro crece hacia abajo)

```markdown
## Diseño del sistema documentador — {fecha de fusión}

**Rama:** `{rama de adopción}`.

### Agregado

- Ficha de diseño documental (`FDD-01`), registro de requerimientos documentales `docs/_requisitos.md`
  (`RD-01…RD-07`, decisión pendiente) y la instancia «Cómo intervenir» `docs/_gobierno/como-intervenir.md`.
- Registro de prefijos del proyecto en la copia de la compuerta documental (sujeto a D-09).
```

## 2. `LGD/changelog.md` — antes de la línea 12 (el registro crece hacia arriba; la primera entrada está en la línea 12)

```markdown
## {fecha} — `AGENTS.md` puntero y carril programado de `ia-db`

- `AGENTS.md` en la raíz: puntero a `ia-db/README.md`, a `Verificar` y a lo que un agente no decide.
- `.github/workflows/carril-programado.yml`: semanal, sólo avisa con un issue cuando `ia-db/` se atrasa
  frente a la rama principal del repo del código o su ancla supera 365 días.
```

## 3. Índice para agentes `LGD/ia-db/indexes/01_Corpus-Documental-SDD.md` — al final de §8 «Dónde está cada plan y cada bitácora» (antes de la línea 213, donde empieza §9)

```markdown
- **Diseño documental** (fuera de `SDD/`): la ficha `FDD-01`, el RRD `docs/_requisitos.md` y
  `docs/_gobierno/como-intervenir.md` del repo del código, y el carril programado de este repo.
```
