# 07 — Material metodológico importado: DevOps, métodos ágiles y Jira, SDD, UX/UI/DX

> **Propósito**: inventario y destilado de las cuatro carpetas de material que **no** comparte el
> aparato de las guías propias: `Guides/DevOps-Guide/`, `Guides/Scrum-Guide/`, `Guides/SDD-Guide/`
> y `Guides/UX-UI-Guide/` (14 documentos + 1 PDF, ≈7 100 líneas). Provienen del proyecto
> *Motor DSL de Generación de Documentos* (`Ejemplo_IA_SDD_Template`, cátedra UTN FRP TUP
> Aplicada 2025) o de guías genéricas fechadas en abril de 2026.
> **Fuente primaria**: los encabezados «Documento / Versión / Fecha / Estado» y los índices de
> cada archivo.

## Advertencias de lectura

- Encabezados con **Versión/Fecha/Autor/Estado** en vez de frontmatter YAML; sin `doc_id`
  (salvo referencias cruzadas a IDs del proyecto de origen: `D1–D7`, `NB-xx`, `CU-xx`, `SA-03`…).
- Las rutas que citan (`/docs/09_devops/`, `/devs/devops/`, `/devs/metodologia-sdd/`,
  `docs/00_contexto/`…) pertenecen al repositorio de origen y **no existen acá** (H-08).
- **Modelo de ramas**: `guia-flujo-trabajo-versionado.md` prescribe `main` + `homologacion`; el
  propio `marco-teorico.md` §6.7 lo declara contradicción con la decisión D3 (GitHub Flow estricto)
  del proyecto de origen; y el modelo **adoptado por este equipo** es el de
  [05](05_Modelo-de-Ramas-y-Practicas.md) (tronco + `release/x.y`). Tres modelos distintos en
  el mismo corpus: prevalece el de la guía de ramas (H-05).

## DevOps (`DevOps-Guide/`, 4 documentos, 2 853 líneas)

| Archivo | Líneas | Fecha / estado | Qué es |
|---|---:|---|---|
| `marco-teorico.md` | 1 637 | 2026-04-25 · v1.0 · Aprobado · «material metodológico, no producto» | Marco teórico de **release engineering de librerías .NET**, con el Motor DSL como caso |
| `guia-flujo-trabajo-versionado.md` | 714 | Abril 2026 · onboarding | Flujo GitHub con `main`/`homologacion`, versión `MAJOR.MINOR.PATCH.BUILD`, ramas de mantenimiento, Conventional Commits, diccionario de commits para .NET, cheat sheet |
| `plan-mejoras-devops_v1.0.md` | 400 | 2026-04-25 · v1.0 · En ejecución (fase 1 cerrada, 2 en curso, 3 pendiente) | Registro archivístico del plan de mejoras sobre `/docs/09_devops` del template: auditoría inicial, decisiones D1–D7, patrón metodológico, auditorías por fase, riesgos, lecciones |
| `publish-nuget.md` | 102 | sin fecha | Receta: paquetes interdependientes (orden y versión en todos los `.csproj`), NuGet privado en GitHub Packages (el `--password` es el PAT), nuget.org |

### `marco-teorico.md` — secciones

| § | Tema |
|---|---|
| 1 | Propósito; caso Motor DSL; audiencia (docente: §1→2→11→13; alumno: §1→3→4→5→6→7→12) |
| 2 | DevOps: definición operativa, CALMS, Three Ways, tipología Westrum, SRE, Platform Engineering |
| 3 | Métricas: las cuatro DORA, reliability, 24 capabilities, DORA aplicado a una librería, anti-patterns |
| 4 | Versionado: SemVer 2.0.0, CalVer, ZeroVer (anti-pattern), auto-versioning, Keep a Changelog 1.1.0, inmutabilidad y yanking |
| 5 | Conventional Commits 1.0.0, tooling, trazabilidad commit → versión → changelog → tag |
| 6 | Branching: GitHub Flow, GitFlow, TBD, Release Flow (Microsoft), OneFlow, árbol de decisión, **§6.7 la contradicción documental** |
| 7 | Pipeline CI/CD: anatomía, 15 stages del Motor DSL, gates DoR/DoD, multiplataforma, determinismo y caché |
| 8 | Supply chain: 6 controles no negociables 2024-2026, SLSA v1.0, SBOM, NIST SSDF, OWASP SCVS, OpenSSF Scorecards, Sigstore, incidentes, EU CRA (Reglamento 2024/2847), mapeo al Motor DSL |
| 9 | Release engineering: feeds Preview/Stable, procedimiento en 5 pasos, breaking changes, deprecación en 3 fases, yanking |
| 10 | GitOps: principios OpenGitOps, por qué no aplica a librerías |
| 11 | Seis contextos de industria comparados (web SaaS, OSS .NET, mobile dual-store, microservicios+GitOps, data engineering, ML) |
| 12 | Decisiones D1–D7 del caso: D1 solo GitHub Packages · D2 MIT · D3 GitHub Flow estricto · D4 `net10.0` único · D5 Conventional Commits + MinVer · D6 tres fases · D7 tono industrial; RACI; métricas y thresholds |
| 13 | Bibliografía: normativas, supply chain, DevOps/SRE, branching y versionado |

## Métodos ágiles y Jira (`Scrum-Guide/`, 4 documentos + PDF, 1 454 líneas)

| Archivo | Líneas | Fecha | Qué es |
|---|---:|---|---|
| ` Metodologias-Agiles-Jira-Guide.md` (**nombre con espacio inicial**, H-04) | 2 836 (176 KB) | 2026-04-13 · v1.0 · Activo | Parte 1 metodologías (manifiesto, Scrum, Kanban, otras, user stories/épicas/tareas, métricas, anti-patrones) · Parte 2 Jira (introducción, nomenclatura e issues, configurar proyecto Scrum, flujo diario, reportes, hitos y releases, integraciones) · §16 técnicas de descomposición y planificación · §17 arrancar un proyecto ágil |
| `Estudio-Guide.md` | 594 | 2026-04-15 · v1.0 | «Cómo arrancar un proyecto con Scrum»: cuándo estás listo, construir el Product Backlog, ejemplos en tres contextos, agrupar en épicas, criterios de épica, el patrón que se repite |
| `Caso-De-Estudio-1-Guide.md` | 139 | 2026-04-15 · v1.0 | Impresión de tickets desde app MAUI híbrida: historias originales, problemas detectados, reescritura corregida. Enlaza a `guia-de-estudio.md` (renombrado a `Estudio-Guide.md`, H-09) |
| `guia-organizacion-proyecto-jira.md` | 721 | 2026-04-14 · v1.0 · basado en `devs/metodos-agiles/metodologias-agiles-jira.md` del template | Elementos de Jira, metodologías que propone, paso a paso de alta de proyecto, ejemplos en distintos ámbitos, anti-patrones |
| `2020-Scrum-Guide-US.pdf` | 14 páginas, 254 KB | 2020 | La Scrum Guide oficial en inglés (fuente primaria; no indexada) |

## Spec-Driven Development (`SDD-Guide/`, 4 documentos, 756 líneas)

| Archivo | Líneas | Qué es |
|---|---:|---|
| `Metodologia-Prompting-SDD-Guide.md` | 671 | 2026-04-06 · v1.0 · UTN FRP TUP Aplicada 2025 · Motor DSL. **Prompting colaborativo Claude ↔ Copilot**: por qué dos agentes; roles; **ciclo de 6 fases** (1 contextualización en Claude · 2 definición de la idea · 3 generación de prompt especializado Claude → Copilot · 4 ejecución y revisión humana · 5 prompt de coherencia · 6 refinamiento y retroalimentación); patrones de prompt; tabla de especialidades; resumen por sección de `/docs/`; ejemplo completo del concepto al sprint; anti-patrones; adaptación a nuevos proyectos; cadena de trazabilidad |
| `Spec-Driven Development-SDD.md` | 79 | Los **tres niveles de SDD**: 1 Spec-First (la spec guía y se descarta) · 2 Spec-Anchored (estándar para equipos) · 3 Spec-as-Source (experimental; «especificaciones idénticas no producen código idéntico»); marco de decisión; conceptos clave |
| `Secciones-Disciplinas-Especialidades-Tables.md` | 80 | Resumen de las secciones `00_contexto` … `11_examples` de `/docs/` del Motor DSL; tabla de especialidades; flujo de trazabilidad; mapeo agente → documentación |
| `References.md` | 5 | Tres URL de `agentfactory.panaversity.org` (SDD, markdown writing, three levels of SDD) |

## UX / UI / DX (`UX-UI-Guide/`, 2 documentos, 2 038 líneas)

| Archivo | Líneas | Fecha / estado | Qué es |
|---|---:|---|---|
| `UX-UI-Guide.md` | 1 714 | 2026-04-25 · v1.0 · Aprobado · audiencia UTN | **Marco teórico de UX/UI/DX** en 12 capítulos + apéndices: 1 encuadre (UX/UI/DX como continuo) · 2 nueve disciplinas (HCI, usabilidad, UX, UI, IxD, arquitectura de información, accesibilidad, service design, DX) · 3 modelos de proceso (Garrett, doble diamante, design thinking, Lean UX, design sprint) · 4 Nielsen, Shneiderman, leyes · 5 normativa (ISO 9241-210:2019, 9241-11:2018, WCAG 2.2, WAI-ARIA 1.2, IEEE 1063 e ISO/IEC 26514) · 6 sistemas de diseño (Atomic Design, ITCSS, Material 3 / HIG / Carbon / Polaris) · 7 investigación y métricas · 8 web (Core Web Vitals, patrones, CSS, forms, microinteracciones, antipatrones) · 9 móvil · **10 DX en REST APIs** (métricas, modelos de error, versionado path vs header, Diátaxis) · 11 caso Motor DSL multi-target (WCAG 2.2 AA en el preview) · 12 tabla maestra pilar × proceso × norma × métrica y checklist · glosario, bibliografía, índice de cuadros |
| `metodologia-uix-ux.md` | 324 | 2026-04-25 · v1.0 · **Borrador** | Qué se documenta en la sección `SA-03` del template en la práctica (flujos de usuario: happy path, alternativos, errores, decisiones; wireframes `WF-xx`; guía de estilo); qué inputs pedir al cliente; cómo normalizar los documentos; cómo articular en la cadena SDD |

La guía UX-UI se generó desde `Lab-Documentos.Documentacion/PROMPTs/Guides/06-Crear-UX-UI-Guide/`
(con `INPUTs/`), a diferencia del resto de esta carpeta, que llegó ya escrito.

## Relación con las guías propias

| Tema importado | Guía propia que lo trata con marco y niveles de autoridad |
|---|---|
| Branching, SemVer, Conventional Commits (`marco-teorico.md` §4–6, `guia-flujo-trabajo-versionado.md`) | `Estandares-Modelo-Ramas.md` §5–7 → [05](05_Modelo-de-Ramas-y-Practicas.md) |
| Pipeline, supply chain (`marco-teorico.md` §7–8) | `GitHub-Action-Guide.md` §1, §8 → [06](06_GitHub-Actions-y-E2E.md) |
| Scrum, Kanban, Canvas como productores de documentación | `Documentacion-Tecnica/80-Metodos-Agiles/` (`MET-*`) → [01](01_Documentacion-Tecnica.md) |
| SDD | `DOC-SDD` (transversal de Documentación técnica) y `TEM-SDD` (REST) → [01](01_Documentacion-Tecnica.md), [04](04_Diseno-REST-API.md) |
| UX y flujo de usuario; DX de APIs | `DOC-UX` y `TEM-DX` → [01](01_Documentacion-Tecnica.md), [04](04_Diseno-REST-API.md) |
| Agentes por especialidad (AG-xx) | `references/agentes-especialidades/` → [08](08_Arquitectura-y-References.md) |
