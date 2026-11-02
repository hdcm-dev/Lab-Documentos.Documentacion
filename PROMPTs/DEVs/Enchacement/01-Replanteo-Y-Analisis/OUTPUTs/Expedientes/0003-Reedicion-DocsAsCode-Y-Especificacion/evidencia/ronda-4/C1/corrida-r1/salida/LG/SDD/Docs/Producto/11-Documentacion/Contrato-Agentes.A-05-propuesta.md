# A-05 para Lab-Geometria: propuesta sobre la fuente de `AGENTS.md`

Propuesta sujeta a D-12 (abierta). `AGENTS.md` es derivado («No editar acá», `AGENTS.md` líneas 3 a 5): el cambio se
propone en su fuente, `SDD/Docs/Producto/11-Documentacion/Contrato-Agentes.md`, y `AGENTS.md` se regenera desde ella.

**Dónde:** §7 «A dónde ir, por intención», después de la fila «saber cómo se nombra algo» (línea 129 del archivo en el
árbol leído). **Qué:** tres filas, una por puntero de A-05.

```markdown
| saber dónde está la documentación del sistema documentador y su frontmatter | `docs/README.md` y `docs/_gobierno/esquema-frontmatter.md` |
| validar un cambio documental antes de proponerlo | `.docs-guard/scripts/ci-local.sh <grupo> docs`, como lo dice `docs/_gobierno/como-intervenir.md` §3 |
| saber qué no decide un agente | `docs/_diseno/ficha-diseno-documental.md` §4, decisiones de clase H |
```

**Control de cambios** del contrato: una fila nueva que diga que §7 suma los tres punteros del sistema documentador,
con su fecha. La versión la sube quien aplique el cambio.
