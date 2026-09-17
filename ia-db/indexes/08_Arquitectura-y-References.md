# 08 — Guías de arquitectura importadas y material de `references/`

> **Propósito**: las tres guías de `Guides/Arquitectura/` (solución .NET por capas, microservicios
> y frontends, archivos/multimedia/video) y los insumos de `Guides/references/` (catálogo de
> agentes por especialidad para SDD, prompt de refinamiento, duplicados, notas). 24 documentos,
> ≈9 100 líneas.
> **Fuente primaria**: índices de navegación de cada guía; `references/agentes-especialidades/README.md`
> y `tabla-caracterizacion-agentes.md` (2026-04-03/04, proyecto Motor DSL).

## Advertencias de lectura

- Sin frontmatter ni `doc_id`; sin marcas de evidencia ni niveles de autoridad. Son guías
  prescriptivas «cómo lo hacemos», no guías de estudio con fuentes verificadas.
- `references/arquitectura/*.md` son **copias byte a byte** de `Arquitectura/*.md` (H-03):
  citar siempre `Arquitectura/`.
- `Dot-NET-Arquitectura-Guide.md` está en **.NET 9 / EF Core 9** (H-06); el resto del corpus usa .NET 10.

## `Arquitectura/Dot-NET-Arquitectura-Guide.md` (929 líneas, abril 2026)

Guía completa de una **solución .NET multi-cliente**: stack .NET 9, Blazor, MAUI Hybrid,
ASP.NET Core Web API, EF Core. Secciones: glosario · visión general · estructura de proyectos ·
un capítulo por proyecto (`Domain`, `Application`, `Infrastructure`, `WebAPI`, `WebFront`
Blazor, `Shared.UI` Razor Class Library, `Desktop` MAUI Blazor Hybrid) · comunicación front → API
(capa de servicios) · diagrama final · reglas de dependencia · resumen de decisiones.

| Capa | Decisión | Tecnología |
|---|---|---|
| Dominio | Entidades puras | Class Library .NET 9 |
| Casos de uso | CQRS | MediatR 12 |
| Validaciones | Pipeline automático | FluentValidation |
| Mapeo | DTO ↔ entidad | AutoMapper o manual (records) |
| Persistencia | ORM code-first | EF Core 9 |
| API | REST documentada | ASP.NET Core + Scalar/Swagger |
| Front web | SPA con .NET | Blazor WebAssembly o Server |
| Compartido | Componentes multiplataforma | Razor Class Library |
| Desktop | UI web nativa | MAUI Blazor Hybrid |
| Cliente HTTP | Sin boilerplate | Refit |
| Autenticación | JWT + Bearer | ASP.NET Core Identity |

Reglas de dependencia (§13): `Domain` no referencia a nadie; `Application` → `Domain`;
`Infrastructure` → `Application`, `Domain`; `WebAPI` → `Application`, `Infrastructure`;
`WebFront` y `Desktop` → solo `Shared.UI` y `Contracts` (nunca `Domain`/`Application`/`Infrastructure`/`WebAPI`).

Contraste: la guía de código propia (`TEM-CAPAS`, `TEM-CVP`) discute **si** conviene esta
separación en proyectos y advierte que Clean Architecture no es estándar de Microsoft
→ [03](03_Organizacion-Codigo-NET.md).

## `Arquitectura/Microservicios-Guide.md` (717 líneas)

«Guía de arquitectura de microservicios y estrategias de frontend», con enfoque .NET.

| § | Tema |
|---|---|
| 1 | Glosario y principios |
| 2 | Microservicios: cuándo, scaffolding estándar por servicio, Clean Architecture por servicio, comunicación, base de datos por servicio |
| 3 | Autenticación: identity provider centralizado, flujos OAuth2 por tipo de cliente, multi-tenancy en el JWT |
| 4 | API Gateway: rol; YARP vs Ocelot vs alternativas |
| 5 | Configuración: secrets vs parametría, patrón *manifest-driven*, settings store multi-tenant |
| 6 | Frontends: dos planos (admin vs producto); patrón 1 mini-front por micro · 2 front monolítico · 2.5 monolito modular con RCL · 3 app shell + micro-frontends · 4 BFF · 5 API-first para consumo externo |
| 7 | Extensibilidad del Admin Portal: manifest-driven, plugins RCL, híbrido recomendado |
| 8 | Consumo multi-cliente: Blazor Interactive Server (principal), SPAs, móviles (MAUI), terceros (webhooks, widgets) |
| 9 | Despliegue: Docker y orquestación; IIS |
| 10 | Tablas de decisión (backend, frontend, autenticación) y matriz de madurez evolutiva |
| 11 | **Guía para agentes IA**: roles, tabla de selección de estructura por tipo de solicitud, prompts de referencia por rol |
| 12 | Casos reales (Mercado Libre, Google Workspace…) |
| Ap. | Estructura de carpetas completa del monorepo |

Contraste: `FAM-SRV` de la guía de código (`TEM-MICRO`, `TEM-PART`) trata cuándo partir con
criterios verificables y el «monolito distribuido» → [03](03_Organizacion-Codigo-NET.md).

## `Arquitectura/Manejo-Archivos-Guide.md` (913 líneas)

Complemento de la anterior: gestión de archivos, multimedia y video en microservicios, API-first.

| § | Tema |
|---|---|
| 1 | Archivos: principios, abstracción de storage (patrón proveedor), proveedores (Google Drive, FTP/SFTP, S3 y compatibles, local), microservicio de archivos, seguridad y validación |
| 2 | Imágenes y multimedia: pipeline, thumbnails y variantes, estrategia «WhatsApp» (caché local + descarga bajo demanda), lazy loading blur-up, CDN, multimedia desde móviles |
| 3 | Video: escenarios, formatos/codecs/contenedores, protocolos de streaming, pipeline FFmpeg, **grabación local y upload diferido**, fuentes (cámaras IP, webcam, pantalla), live, VOD |
| 4 | Compresión: archivos, imágenes, transcodificación, perfiles recomendados |
| 5 | Firma digital de documentos y video; watermarking |
| 6 | Arquitectura integrada |
| 7–8 | Glosario; guía para agentes IA |

Relación: el dominio de ejemplo de [02](02_Informe-de-Solucion.md) (audiencias con grabación por
terminal y subida diferida) es un caso de §3.5.

## `references/` (21 documentos, 6 577 líneas)

| Carpeta | Contenido | Estado |
|---|---|---|
| `agentes-especialidades/` (15) | `README.md` índice + `tabla-caracterizacion-agentes.md` + una ficha por agente `AG-ROOT`, `AG-00..AG-11` | Proyecto Motor DSL, 2026-04-03/04 |
| `refinamiento_docs/` (2) | `agentes-refinamiento-docs.md` (515 líneas: definición de los mismos AG-xx) · `prompt_refinanmiento.md` (189: prompt maestro de un agente orquestador con sub-agentes para refinar la documentación SDD del Motor DSL) | Insumo de prompts |
| `arquitectura/` (3) | `guia-arquitectura-.net.md`, `guia-arquitectura-microservicios.md`, `guia-manejo-recursos.md` | **Duplicados exactos** de `Arquitectura/` (H-03) |
| `notas/tools.md` (1) | Atajos de VS Code para previsualizar Markdown (`Ctrl+K V`, `Ctrl+Shift+V`) | Nota personal |

### Catálogo de agentes por especialidad (`agentes-especialidades/`)

Cada carpeta de `docs/` del template SDD tiene un agente con el perfil profesional para evaluarla
y refinarla. Cada ficha `AG-xx.md` tiene la misma estructura: 1 qué es la especialidad
(disciplinas, ejemplos, diferencia con roles vecinos) · 2 tareas · 3 especificaciones
normalizadas que produce · 4 criterios de calidad · 5 preguntas guía · 6 plantilla base ·
7 anti-patrones.

| ID | Carpeta SDD | Agente |
|---|---|---|
| `AG-ROOT` | `docs/README.md` | Arquitecto de Soluciones Senior (coherencia cross-documental) |
| `AG-00` | `docs/00_contexto/` | Product Manager / Analista de Negocio |
| `AG-01` | `docs/01_necesidades_negocio/` | Analista de Negocio Senior |
| `AG-02` | `docs/02_especificacion_funcional/` | Analista Funcional / Ingeniero de Requisitos |
| `AG-03` | `docs/03_ux-ui/` | Especialista en Developer Experience |
| `AG-04` | `docs/04_prompts_ai/` | Ingeniero de Prompts / AI Specialist |
| `AG-05` | `docs/05_arquitectura_tecnica/` | Arquitecto de Software Senior (ADR, contratos, extensibilidad) |
| `AG-06` | `docs/06_backlog-tecnico/` | Scrum Master / Agile Coach |
| `AG-07` | `docs/07_plan-sprint/` | Gestión de proyectos ágiles |
| `AG-08` | `docs/08_calidad_y_pruebas/` | Ingeniero QA / SDET |
| `AG-09` | `docs/09_devops/` | Ingeniero DevOps (pipelines, SemVer, NuGet, rollback, secretos) |
| `AG-10` | `docs/10_developer_guide/` | Technical Writer / Developer Advocate |
| `AG-11` | `docs/11_examples/` | Developer Advocate / Ingeniero de Aplicación |

Flujo de lectura recomendado: AG-00 → 01 → 02 → (03 + 04) → 05 → 06 → 07 → 08 → …

Relación: `Documentacion-Tecnica/00-Marco-de-Referencia/Actores.md` define **diez actores**
(`ACT-01..10`) para el mismo problema, con `ACT-10` = agente de IA que produce borradores y no
decide; los `AG-xx` son la versión «un agente por carpeta» del proyecto de origen
→ [01](01_Documentacion-Tecnica.md), [09](09_Convenciones-y-Glosario.md).
