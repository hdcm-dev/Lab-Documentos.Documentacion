# Inserción en `changelog.md` de `LG` (A-11, CL-13)

**Punto de inserción.** Al final del archivo, después de la última entrada («Mesa delegada: seis decisiones que
eran del Product Owner — 2026-09-15», `LG/changelog.md:2122`): el registro va en orden cronológico ascendente
(`LG/changelog.md:36`, etapa `a`, primera). Va en la rama del pull request de adopción, no después de la fusión
(`LG/changelog.md:5`).

```markdown
## Adopción del sistema documentador — {fecha de la fusión}

**Rama:** `{rama-de-adopcion}`. Ficha de diseño documental A-01 (`docs/_diseno/ficha-diseno-documental.md`).

### Agregado

- `docs/_requisitos.md`: RRD inicial, `RD-01…RD-06`, todas las filas con decisión pendiente.
- `docs/_gobierno/como-intervenir.md`: instancia del proceso «Cómo intervenir».
- `SDD/Docs/Producto/11-Documentacion/Contrato-Agentes.md`: tres punteros del diseño documental en §7; `AGENTS.md` regenerado.

### Pendiente

- La compuerta documental (registro de prefijos, esquema de frontmatter, workflow, línea de base): espera la copia de la compuerta de origen y la decisión D-09.
```
