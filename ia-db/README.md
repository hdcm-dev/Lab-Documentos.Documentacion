# ia-db — Lab-Documentos

> **Instrucción para IA**: este archivo es el **punto de entrada único** a la base de conocimiento
> del repositorio [`Lab-Documentos`](https://github.com/hdcm-dev/Lab-Documentos) (`/LAB/Lab-Documentos`).
> Leelo primero, ubicá el tema en la tabla de navegación y cargá **solo** el índice —o los dos— que
> correspondan. Ampliá a los archivos fuente únicamente cuando el índice resulte insuficiente: cada
> índice referencia sus fuentes con ruta exacta relativa a `Lab-Documentos/`. No recorras las
> ~87 600 líneas del corpus completo.

## Navegación

| Necesitás saber… | Leé este índice |
| --- | --- |
| Qué es el repositorio, qué guías tiene, de dónde salió cada una, qué comparten y qué hallazgos tiene el árbol | [00_MASTER-INDEX.md](indexes/00_MASTER-INDEX.md) |
| Qué tipos de documentación técnica existen (Vision, SRS, SAD, ADR, Runbook…), cuál producir en cada escenario y cómo evaluarla | [01_Documentacion-Tecnica.md](indexes/01_Documentacion-Tecnica.md) |
| Cómo escribir **un informe de solución** (arquitectura + despliegue + requisitos) y su plantilla de 13 secciones | [02_Informe-de-Solucion.md](indexes/02_Informe-de-Solucion.md) |
| Cómo organizar soluciones .NET: monolito/microservicios, `.sln`, capas, nombres, `.editorconfig`, Minimal APIs, repositorios | [03_Organizacion-Codigo-NET.md](indexes/03_Organizacion-Codigo-NET.md) |
| Cómo diseñar una API REST: recursos, métodos y códigos HTTP, errores, paginación, versionado, OpenAPI, seguridad, ASP.NET Core | [04_Diseno-REST-API.md](indexes/04_Diseno-REST-API.md) |
| Modelo de ramas adoptado (tronco + release), versionado, PRs, y las guías prácticas de GitFlow y GitHub Flow | [05_Modelo-de-Ramas-y-Practicas.md](indexes/05_Modelo-de-Ramas-y-Practicas.md) |
| GitHub Actions (sintaxis, diez escenarios, seguridad, diagnóstico) y pruebas E2E con Playwright en .NET | [06_GitHub-Actions-y-E2E.md](indexes/06_GitHub-Actions-y-E2E.md) |
| DevOps (DORA, SemVer, supply chain), Scrum y Jira, SDD con agentes, marco UX/UI/DX — el material importado | [07_DevOps-Agiles-SDD-UX.md](indexes/07_DevOps-Agiles-SDD-UX.md) |
| Guías de arquitectura .NET / microservicios / archivos-multimedia, y `references/` (agentes SDD, duplicados, notas) | [08_Arquitectura-y-References.md](indexes/08_Arquitectura-y-References.md) |
| Convenciones compartidas (frontmatter, IDs, marcas **[F]/[C]/[E]/[V]**, niveles de autoridad, catálogos `N-/G-/F-/O-/P-`) y glosario cruzado | [09_Convenciones-y-Glosario.md](indexes/09_Convenciones-y-Glosario.md) |

## Resumen ejecutivo

| Dato | Valor |
| --- | --- |
| Proyecto indexado | `Lab-Documentos` (`/LAB/Lab-Documentos`) |
| Repositorio | `https://github.com/hdcm-dev/Lab-Documentos` · rama `main` en `e1a39bf` (2026-08-26) |
| Tipo | **Corpus documental de estudio**: 15 carpetas de guías en Markdown, sin código ejecutable |
| Volumen | 237 archivos · 232 `.md` (87 577 líneas; 2 vacíos) · 3 workflows `.yml` · 1 PDF · 7 MB · 217 diagramas Mermaid en 146 archivos |
| Stack de referencia de los ejemplos | .NET 10 / C# · ASP.NET Core · Blazor *interactive server* · .NET MAUI (MVVM) · EF Core · PostgreSQL · Playwright · GitHub Actions (`Arquitectura/` usa .NET 9) |
| Documentación asociada | `Lab-Documentos.Documentacion` (este repositorio: prompts generadores en `PROMPTs/`, `CHANGELOG.md`, esta ia-db) |

**Función principal.** Reunir en un solo repositorio las guías de estudio que el equipo produjo
—con asistencia de agentes— sobre documentación técnica, informes de solución, organización de
código .NET, diseño de APIs REST, modelo de ramas, GitHub Actions, pruebas E2E, DevOps, métodos
ágiles, SDD y UX/UI. Cada guía es autocontenida; las cuatro grandes comparten un mismo aparato
(marco de referencia con escenarios/contextos/actores, mapa conceptual «estoy acá → qué aplico»,
familias temáticas, anexos) y el dominio de ejemplo de **reserva de salas**.

**Arquitectura en una línea.** `Guides/<Guía>/` por tema; las guías estructuradas siguen
`00-Marco-de-Referencia → 01-Mapa-Conceptual → NN-Familia → 99-Anexos` con frontmatter YAML y
`doc_id` por archivo; las de procedimiento (ramas, Actions, E2E) son documentos únicos con marcas
de evidencia **[F]/[C]/[E]/[V]**; el resto es material importado de otros proyectos, sin ese aparato.

## Estructura del repositorio indexado

```
Lab-Documentos/
├── README.md                                 (vacío — ver hallazgos)
├── .gitignore                                plantilla Visual Studio / .NET (bin/, obj/, .vs/…)
└── Guides/
    ├── README.md                             (vacío)
    ├── Documentacion-Tecnica/                59 docs · 20 700 líneas · 7 familias + métodos, modelos, transversales
    ├── Documentacion-Informe-Despliegue/     30 docs ·  5 348 líneas · el informe de solución y su plantilla
    ├── Organizacion-Estilo-Patrones-Codigo/  38 docs · 11 321 líneas · 6 familias + análisis integral
    ├── Organizacion-Estilo-Rest-API/         56 docs · 21 327 líneas · 10 familias (README vacío, sin mapa ni glosario)
    ├── Estandares-Modelo-Ramas-Guide/        GF-GUIA (2 029 líneas) + Anexos/workflows (README + 3 .yml)
    ├── GitFlow-Practice-Guide/               8 escenarios del modelo adoptado
    ├── GitHubFlow-Practice-Guide/            8 escenarios del modelo no adoptado (línea de base)
    ├── GitHub-Action-Guide/                  GHA-00, documento único de 2 974 líneas
    ├── E2E-Guide/                            Beginner-Guide (E2E-00) + Quick-Guide-ABM (E2E-01)
    ├── DevOps-Guide/                         marco teórico, flujo/versionado, plan de mejoras, NuGet
    ├── Scrum-Guide/                          metodologías ágiles + Jira, guía de estudio, caso, PDF
    ├── SDD-Guide/                            prompting colaborativo SDD, niveles de SDD, tablas
    ├── UX-UI-Guide/                          marco teórico UX/UI/DX + metodología de documentación
    ├── Arquitectura/                         3 guías (.NET, microservicios, archivos/multimedia)
    └── references/                           agentes SDD (AG-xx), duplicados de Arquitectura/, notas
```

Estado del árbol al indexar: la aplicación Blazor, sus workflows y `CODEOWNERS` figuran **borrados
sin commitear** en `git status`, `README.md` modificado (vaciado) y `Guides/` **sin trackear**
(`??`). El último commit de `main` (`e1a39bf`) todavía contiene la aplicación `MovilidadUrbana`.
Ver [00_MASTER-INDEX.md](indexes/00_MASTER-INDEX.md#estado-del-repositorio).

## Restricciones para IA

- **No modificar `Lab-Documentos` desde esta base.** La ia-db documenta; no autoriza cambios.
- **No presentar el índice como fuente de verdad del contenido.** Ante contradicción prevalece el
  archivo fuente: se corrige el índice, no el razonamiento sobre la guía.
- **No mezclar los vocabularios.** `ESC-`, `CTX-`, `ACT-`, `E-`, `C-`, `A-`, `N-`, `F-` significan
  cosas distintas en cada guía (ver [09_Convenciones-y-Glosario.md](indexes/09_Convenciones-y-Glosario.md)).
- **No citar como norma lo que la guía marca como convención o criterio propio** (**[C]**, «esta
  guía recomienda», nivel «criterio propio»). Esa distinción es el rasgo central del corpus.
- **No dar por vigente** el material importado (DevOps, Scrum, SDD, UX-UI, Arquitectura, references)
  sin mirar fecha y origen: viene del *Motor DSL* (UTN FRP, abril 2026), no comparte marco con las
  guías propias y en un punto las **contradice** (modelo de ramas con `homologacion`).
- **No indexar ni escanear** `.git/`, el PDF, ni la propia `ia-db`.
- **No hacer commit, push ni pull request** como parte de una consulta a esta base.

## Manifiesto de generación

- Generado por : `/IA/PROMPTs/IA.Prompts/Tool-Prompts/Indexado-Documentado/Iniciar-Indexado.md`
- Invocado por : `/LAB/Lab-Documentos.Documentacion/PROMPTs/Indexado/Crear-Indexado.md`
- Perfil       : `/IA/PROMPTs/IA.Prompts/PromptFramework/Profiles/Knowledge-Indexing.md`
- Alcance      : `/LAB/Lab-Documentos` (modo proyecto; destino explícito fuera del proyecto, en
  `/LAB/Lab-Documentos.Documentacion/ia-db`)
- Fuentes      : `README.md`, `.gitignore`, `Guides/**/*.md` (232 archivos), `Guides/**/*.yml` (3);
  el PDF `Guides/Scrum-Guide/2020-Scrum-Guide-US.pdf` se inventaría pero no se lee. Para la génesis
  se leyeron además `README.md`, `CHANGELOG.md` y `PROMPTs/` de `Lab-Documentos.Documentacion`
- Estado del repositorio : `main` en `e1a39bf`; árbol de trabajo con la app borrada y `Guides/` sin trackear
- Verificaciones ejecutadas : `wc -l` por guía; comprobación de 2 409 enlaces relativos con un
  script Python (36 archivos con enlaces rotos, detallados en el índice 00); `cmp` de los tres
  duplicados de `references/arquitectura/` contra `Arquitectura/` (idénticos byte a byte)
- Generado     : 2026-09-12 · Versión: 3.0 (regeneración completa a pedido; reemplaza a la 2.0 del
  mismo día, que no tenía cambios de fuente pendientes; la 1.0 del 2026-09-01 indexaba la app
  Blazor + E2E que ya no está en el árbol)
- Actualizar   : `/IA/PROMPTs/IA.Prompts/Tool-Prompts/Indexado-Documentado/Actualizar-Indexado.md`
  (invocación local: `/LAB/Lab-Documentos.Documentacion/PROMPTs/Indexado/Actualizar-Indexado.md`)
