# Propuesta de cambio en la fuente de AGENTS.md de Lab-Geometria (A-05, sujeta a D-12)

`AGENTS.md` de Lab-Geometria es derivado («No editar acá»): el cambio se propone en su fuente,
`SDD/Docs/Producto/11-Documentacion/Contrato-Agentes.md`, y `AGENTS.md` se regenera. Insertar como subsección nueva,
al final del contrato, antes de su control de cambios:

```markdown
## Sistema documentador

- Documentación del sistema documentador y su contrato de frontmatter: [docs/_gobierno/como-intervenir.md](docs/_gobierno/como-intervenir.md) y `.docs-guard/tools/docs-guard/esquemas/cuerpo.schema.json`.
- Antes de proponer: `bash .docs-guard/scripts/ci-local.sh {grupo} docs` (el mismo guion que corre `.github/workflows/docs-guard.yml`).
- Lo que no decide un agente: [docs/_diseno/ficha-diseno-documental.md](docs/_diseno/ficha-diseno-documental.md) §4.
```
