# A-11 — Entradas en el índice y en el registro de cambios

Propuesta sujeta a D-12. Un bloque por destino, con su ruta y la línea de inserción; no el archivo entero.

## Destino 1: `Lab-Geometria.Documentacion/ia-db/README.md`

Punto de entrada del índice para agentes (`LGD/README.md:35-39`: «entrada única con manifiesto»). Insertar como
fila nueva de la tabla de rutas por intención, después de la línea 22 (fila del front):

```markdown
| El sistema documentador: ficha de diseño, RRD, proceso «Cómo intervenir», audiencias y compuerta `docs-guard` | `Lab-Geometria` `docs/` y `.docs-guard/`, en el SHA de [`source.lock`](source.lock) |
```

## Destino 2: `Lab-Geometria/changelog.md`

Insertar como entrada nueva al principio de las entradas fechadas (antes de la primera línea `## …— AAAA-MM-DD`):

```markdown
## Adopción de la documentación como código — 2026-11-02

- `docs/`: ficha de diseño documental, RRD, «Cómo intervenir», registro de audiencias, línea de base y controles de entrega.
- `.docs-guard/` y `.docs-guard-origen/`: copia con huella de la compuerta documental; `.github/workflows/docs-guard.yml`.
```
