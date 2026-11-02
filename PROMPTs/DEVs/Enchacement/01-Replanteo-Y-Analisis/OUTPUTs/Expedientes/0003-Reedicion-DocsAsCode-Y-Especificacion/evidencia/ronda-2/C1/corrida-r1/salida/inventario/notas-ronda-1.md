# Notas de trabajo de la ronda 1 (para retomar)

Hallazgos medidos, con su cita, para completar A-01 después de las respuestas:

- CL-03: `LG/AGENTS.md` existe, derivado de `LG/SDD/Docs/Producto/11-Documentacion/Contrato-Agentes.md` (`LG/AGENTS.md:3-5`); `LGD` no tiene `AGENTS.md`.
- CL-04: comentarios `///` presentes; `LG/Directory.Build.props:26` `GenerateDocumentationFile=false` → activa, control pendiente (DK-13).
- CL-05: OpenAPI en ejecución (`LG/src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:58`, `:117`); ningún paso de CI lo extrae (`grep -rliE openapi scripts .github` sin salida) → activa, control pendiente.
- CL-06: no hay ayuda al usuario final (búsqueda negativa en §1, patrón 4).
- CL-07: técnica en `LG/SDD/Docs/Unidades-Entrega/*/05-Arquitectura-Tecnica`, `09-Devops`, `11-Documentacion`; frontera con CL-01 pendiente de DK-14 (Q-7).
- CL-08: `LGD/ia-db/`, anclado en prosa a `4b114d7`/`v1.2.0` (`LGD/ia-db/README.md:38`); sin `source.lock`.
- CL-09: `LGD/Analisis/`, `LGD/PROMPTs/` (del PO, `LGD/README.md:5`); `LG/SDD/Expedientes/` y `LG/SDD/Docs/Audit/` → frontera DK-14 (Q-7).
- CL-11: el marco SDD no se copia (`LG/SDD/README.md:3`); el conocimiento de PR se cita por ruta absoluta, sin copia (`LGD/README.md:13-15`).
- CL-13: `LG/README.md`, `LG/changelog.md`, `LGD/README.md`, `LGD/changelog.md`.
- D-11: delegación de merge en `LGD/README.md:11-31` (LGD) y `LG/AGENTS.md:65` (LG).
- D-15: no; propósito producto (`LG/SDD/Docs/README.md:36-38`).
- D-16: castellano para personas, identificadores en inglés (`LG/AGENTS.md:36-37`); enums por nombre (`LG/src/GeometriaFactory.Domain/Values/Role.cs:7-9`).
- CI: `LG/.github/workflows/ci.yml:39-47` (ubuntu-latest, PR y push a main); `LG/.github/workflows/e2e.yml:69` (runner propio, etiqueta privada → alias `{etiqueta-runner}`); `LGD/.github/workflows/verificar.yml:3-14`.
- No hay tabla de bloqueo documental ni tabla P/H en el proyecto (grep sin salida, excepto vocablos no relacionados).
