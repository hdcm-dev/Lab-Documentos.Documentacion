# A-11 · entrada para `changelog.md` de Lab-Geometria

**Destino:** `changelog.md`. **Línea de inserción:** al final, después de la línea 2140 del árbol leído (el registro
crece hacia abajo; su última entrada empieza en la línea 2122).

```markdown
## Adopción de la documentación como código — {fecha del merge}

Entra `docs/`, el sistema documentador nuevo: ficha de diseño, registro de requerimientos documentales, nota del
esquema de frontmatter, «Cómo intervenir», registro de audiencias y línea de base. Entra la compuerta `docs-guard`
como copia con huella (`.docs-guard/` y `.docs-guard-origen/`) y su workflow `.github/workflows/docs-guard.yml`, que
verifica sólo `docs/` y avisa: ningún control bloquea hasta que el Product Owner lo decida. El corpus `SDD/` no cambia.
```
