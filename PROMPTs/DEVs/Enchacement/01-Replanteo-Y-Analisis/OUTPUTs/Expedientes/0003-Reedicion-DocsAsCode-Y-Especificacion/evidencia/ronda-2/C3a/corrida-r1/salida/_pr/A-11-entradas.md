# A-11 — entradas y punto de inserción

## CHANGELOG (CL-13)

Punto de inserción: `CHANGELOG.md` no existe en el SHA leído (`find . -iname CHANGELOG.md` sin salida); se crea en la
raíz con esta primera entrada, bajo un encabezado «Sin publicar».

```markdown
## Sin publicar

- Documentación: adopción de la documentación como código (ficha de diseño, registro de prefijos, esquema de
  frontmatter, RRD inicial, cómo intervenir, AGENTS.md, compuerta y carril programado). Exigencias EX: ninguna.
```

## Índice para agentes (CL-08)

Punto de inserción: repo hermano `.Documentacion`, que no existe todavía (pendiente). Entrada propuesta:

```markdown
- Colmenar — ficha de diseño documental: `docs/_diseno/ficha-diseno-documental.md` @ {sha}
```
