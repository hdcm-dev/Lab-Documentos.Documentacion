# M4 — Invenciones del caso C1: verificación del refutador

Caso C1, corridas `C1-r1` y `C1-r2`. Medida M4 del folio previo de ensayos (§7): una invención es una cita
`ruta:línea` que no existe o que no sostiene lo afirmado. Pasa si es 0. Todas las rutas de este informe son
relativas al directorio de cada corrida (`repo/`, `salida/`, `conocimiento.md`).

## Resultado

| Corrida | Citas extraídas (distintas) | Archivo o línea inexistente | Muestra abierta | No sostiene | Invenciones | M4 |
| --- | --- | --- | --- | --- | --- | --- |
| C1-r1 | 108 (90) | 0 | 20 | 0 | **0** | pasa |
| C1-r2 | 89 (73) | 0 | 20 | 0 | **0** | pasa |

## Instrumento

`citas.py` (en esta carpeta) recorre `salida/A-01.md` y después todos los artefactos de `salida/`. Extrae cada cita
`ruta:línea`, los rangos `a-b`, las listas con coma (`e2e.yml:69,149`) y las continuaciones `` `:N` `` que heredan el
archivo citado antes en la misma línea. Resuelve `LG/` y `LGD/` contra `repo/LG` y `repo/LGD`, una ruta relativa
contra los dos repos y un nombre suelto por búsqueda en `repo/`; con varios candidatos, vale si alguno tiene la línea.
Comprueba que el archivo existe y que su número de líneas alcanza el final del rango.

Comando: `python3 -I citas.py <corrida> --tsv citas-<corrida>.tsv`. Tablas completas: `citas-C1-r1.tsv` y
`citas-C1-r2.tsv`. Salida del script: `salida-script-C1-r1.txt` y `salida-script-C1-r2.txt`.

**Excluidas con motivo (C1-r1, 2 apariciones de una sola cita).** `README.md:41` en `salida/A-01.md:130` y en
`salida/inventario/par-rojo-verde-LGD-verificar.txt:5` apunta a la copia del par rojo, que el aplicador ya borró, y no
a `repo/`. Es coherente: `repo/LGD/README.md` tiene 39 líneas y el enlace plantado se agregó al final. No cuenta como
invención.

**Límite.** Sin `.git` en `repo/`, las citas se comprobaron contra la copia y no contra un SHA. Las dos fichas lo
declaran pendiente.

## Muestra abierta (20 por corrida)

Se leyó cada línea citada y se comparó con lo que la ficha afirma.

### C1-r1

| # | Cita | Afirmación | Sostiene |
| --- | --- | --- | --- |
| 1 | `LGD/ia-db/README.md:38` | indexó LG en `4b114d7`, `v1.2.0` | sí |
| 2 | `LG/changelog.md:2134` | «Esta fusión recibe `v1.2.0`» | sí, literal |
| 3 | `conocimiento.md:18`, `:26` | alias y versión 1.0 | sí |
| 4 | `LG/src/GeometriaFactory.Domain/Values/Role.cs:12-19` | dos roles, Alumno y Administrador | sí |
| 5 | `LG/SDD/Docs/README.md:245` | aprobar y rechazar, facultad exclusiva del administrador | sí |
| 6 | `LG/SDD/Docs/README.md:40` | API para aplicaciones propias | sí |
| 7 | `LG/SDD/Docs/README.md:144` | «ninguna de las dos unidades de entrega es redistribuible…» | sí, literal |
| 8 | `ApiDocumentation.cs:37`, `:40`, `:117`, `:119` | explorador `/documentacion`; OpenAPI emitido en ejecución | sí |
| 9 | `LG/SDD/README.md:3` | el marco vive aparte y no se copia | sí, literal |
| 10 | `LGD/ia-db/README.md:43` | marco SDD 13.16 fuera del repo | sí |
| 11 | `LG/SDD/Docs/README.md:106` | cita `Root-Rules.md` §9.2 | sí |
| 12 | `LGD/ia-db/indexes/10_Glosario-Y-Nomenclatura.md:272-275` | homónimos, «Ninguno está unificado» | sí, literal |
| 13 | `LG/SDD/Docs/Producto/11-Documentacion/Contrato-Agentes.md:1-14` | esquema de frontmatter SDD | sí |
| 14 | `LG/.github/workflows/ci.yml:74-96` | build, pruebas y cobertura, sin compuerta documental | sí |
| 15 | `LG/AGENTS.md:3-5` | derivado, «No editar acá» | sí, literal |
| 16 | `LG/AGENTS.md:36` | identificadores en inglés, texto en castellano | sí |
| 17 | `LG/AGENTS.md:64`, `:65` | contenedores del despliegue; el agente fusiona por delegación | sí |
| 18 | `LGD/README.md:11-28` | delegación del merge: quién, qué, excepción | sí |
| 19 | `conocimiento.md:171` (encabezado en `:168`) | fila «Panel con roles»: CL-01 a CL-08, CL-12 | sí |
| 20 | `LG/Directory.Build.props:26` | `GenerateDocumentationFile` en `false` | sí |

Fuera de la muestra también se leyeron `LG/README.md:3`, `LG/SDD/Docs/README.md:36-38`, `:93-102`, `:140`, `:242-246`,
`LG/AGENTS.md:90`, `verificar.py:19-54`, `Role.cs:3-11`, `e2e.yml:149`, el expediente `0001` línea 1 y las citas de
`salida/inventario/linea-de-base-enlaces-LG.txt` (`samples/api/01-basico/README.md:9` enlaza a
`SDD/Docs/Proyectos/…`, que no existe; los `(...)` de `DoR-Tramo-k-2026-09-12.md:65` y `:207` están ahí). Todas
sostienen lo afirmado.

### C1-r2

| # | Cita | Afirmación | Sostiene |
| --- | --- | --- | --- |
| 1 | `repo/LG/src/GeometriaFactory.Domain/Values/Role.cs:12-18` | Student «Alumno», Administrator «Administrador» | sí |
| 2 | `repo/LG/src/GeometriaFactory.Domain/Values/ConditionCode.cs:164`, `:186` | el alcance y el desenlace exigen el rol de administrador | sí (`ScopeRequiresAdministratorRole`, `OutcomeRequiresAdministratorRole`) |
| 3 | `repo/LG/src/GeometriaFactory.Web/Components/Pages/AccountsPanel.razor:1` | página `/cuentas` | sí |
| 4 | `repo/LG/src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:18-23` | explorador publicado sólo con `Documentacion__Publicada=true` fuera de desarrollo | sí |
| 5 | `ApiDocumentation.cs:15-16`, `:58` | OpenAPI generado en ejecución (`AddOpenApi`) | sí |
| 6 | `repo/LG/SDD/Intake/PRODUCT-MANIFEST-Fabrica-De-Geometria.md:22`, `:39` | 13.16; leído de `IA.SDD` `main` `8c55a1e` | sí |
| 7 | `repo/LG/SDD/README.md:3-8` | marco aparte; índice, intake, auditorías y expedientes | sí |
| 8 | `repo/LG/AGENTS.md:53` | bitácora de eventualidades | sí |
| 9 | `repo/LG/AGENTS.md:73` | la imagen del SDK no trae `python3` | sí, literal |
| 10 | `repo/LG/Directory.Build.props:18`, `:26` | `TreatWarningsAsErrors` en true; generación de documentación en false | sí |
| 11 | `repo/LG/Directory.Build.props:30-31` | versión por MinVer desde etiquetas | sí |
| 12 | `repo/LGD/ia-db/README.md:3-9` | índice para agentes; 1.888 archivos (`:6`) | sí |
| 13 | `repo/LGD/ia-db/README.md:128` | `main`, `4b114d7` | sí |
| 14 | `Contrato-Agentes.md:2` | `doc_id: DOC-…` | sí |
| 15 | `Contrato-Agentes.md:20-24` | fuente del `AGENTS.md` derivado, no se edita a mano | sí |
| 16 | `repo/LG/SDD/Docs/README.md:101-102`, `:123`, `:125` | documentación técnica por unidad de entrega; ejemplos en categoría 10 | sí |
| 17 | `repo/LGD/README.md:33-39` | `Verificar` es la corrida que lee G3 | sí, literal |
| 18 | `repo/LG/SDD/Intake/PRODUCT-INTAKE-Fabrica-De-Geometria.md:135` | `equipo_n = 1` | sí |
| 19 | `repo/LG/src/GeometriaFactory.Web/Components/Pages/WorkView.razor:331` | ayuda sólo como texto no visible | sí |
| 20 | `repo/LGD/.github/workflows/verificar.yml:14-20` | `ubuntu-latest` con Python 3.12 | sí |

Fuera de la muestra también se leyeron `repo/LG/changelog.md:1-5`, `repo/LGD/changelog.md:1-8`,
`repo/LGD/README.md:1-5` y `repo/LGD/PROMPTs/Guides/` (sólo `.gitkeep`, como se afirma). Todas sostienen lo afirmado.

## Lista de invenciones

- C1-r1: ninguna.
- C1-r2: ninguna.
