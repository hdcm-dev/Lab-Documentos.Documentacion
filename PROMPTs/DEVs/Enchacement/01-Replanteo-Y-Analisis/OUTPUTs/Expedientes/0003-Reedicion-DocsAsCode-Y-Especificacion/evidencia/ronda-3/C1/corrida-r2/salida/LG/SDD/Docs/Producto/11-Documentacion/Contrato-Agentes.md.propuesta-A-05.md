# Propuesta A-05 para la fuente de `AGENTS.md`

`AGENTS.md` de Lab-Geometria es derivado («No editar acá»): el cambio se propone en su fuente,
`SDD/Docs/Producto/11-Documentacion/Contrato-Agentes.md`. Clase H: lo decide el Product Owner (propuesta sujeta a D-12).

Sumar, en la sección que se regenera como «A dónde ir, por intención», tres filas:

| Quiero… | Documento |
| --- | --- |
| el contrato de frontmatter de la documentación nueva | `.docs-guard/tools/docs-guard/esquemas/cuerpo.schema.json` y `docs/_gobierno/como-intervenir.md` |
| validar la documentación antes de proponer | `bash .docs-guard/scripts/ci-local.sh esquema docs` y `bash .docs-guard/scripts/ci-local.sh trazas docs` |
| saber qué no decide un agente en la documentación | `docs/_diseno/ficha-diseno-documental.md` §4 |
