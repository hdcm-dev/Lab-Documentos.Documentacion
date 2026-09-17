# 04 — Guía de estudio: Organización y estilo de APIs REST

> **Propósito**: cómo diseñar, especificar, evolucionar, asegurar e implementar en ASP.NET Core
> una API REST, con cada prescripción clasificada por nivel de autoridad. Cubre
> `Guides/Organizacion-Estilo-Rest-API/` (56 documentos, 21 327 líneas): la guía más grande del corpus.
> **Fuente primaria**: los `README.md` de familia (`FAM-xx`, todos `last_review` 2026-07-20),
> `00-Marco-de-Referencia/Convenciones.md` y `99-Anexos/Referencias.md`. **El `README.md` de la
> guía está vacío y no existe `01-Mapa-Conceptual/`** (hallazgo H-02 del [índice maestro](00_MASTER-INDEX.md#hallazgos-y-divergencias)); este índice reconstruye la tabla de contenido.

## En una pantalla

- Vocabulario: «REST» en su acepción corriente (API HTTP con recursos por URI y JSON); la acepción
  estricta de Fielding (`O-01`) se reserva para `FAM-FUN`. Casi todas las guías corporativas
  verificadas prescriben APIs de **nivel 2** del modelo de Richardson (`O-03`), no 3.
- **Cuatro niveles de autoridad** (`Convenciones.md` §Los cuatro niveles): normativo (`N-xx`,
  sección exacta) · guía de organización (se nombra la organización) · convención de facto
  (con evidencia `P-xx`) · criterio propio («esta guía recomienda»). Es «la convención más
  importante de la guía».
- Estado de la materia, en una línea por tema: semántica HTTP → **hay norma** (RFC 9110/9111,
  9457, 5789/6902/7396); versionado, casing de campos, paginación, filtrado → **no hay norma**,
  solo guías que se contradicen (Microsoft `camelCase` vs Zalando `snake_case`; Google
  `camelCase` en colecciones vs Zalando `kebab-case`).
- Contradicciones documentadas y **no resueltas por autoridad**: la guía da el criterio para
  elegir (qué problema resolvía cada organización).
- Casos testigo: el rate limiter nativo de ASP.NET Core rechaza con **503, no 429** (`N-43`);
  `Asp.Versioning` **no es producto de Microsoft** aunque viva en `github.com/dotnet/` (`F-09`);
  `Idempotency-Key` es convención de Stripe sobre un draft IETF **expirado**.

## Marco de referencia (`00-Marco-de-Referencia/`)

| Eje | Valores |
|---|---|
| Escenarios `ESC-` | `ESC-1` API nueva · `ESC-2` exposición o migración · `ESC-3` evolución en producción (el más frecuente y peor cubierto por el material disponible) · `ESC-4` evaluación de una API ajena (`ESC-4b`: sondear una API ajena solo con autorización) |
| Contextos `CTX-` | `CTX-1` API pública · `CTX-2` API interna entre servicios · `CTX-3` backend de aplicación propia · `CTX-4` integración con sistemas externos |
| Actores `ACT-` | `ACT-01` arquitecto de API (vinculante en toda la superficie) · `02` desarrollador productor · `03` desarrollador consumidor · `04` QA/tester de API · `05` analista funcional · `06` product owner (calendario, deprecación) · `07` seguridad y operaciones (**poder de veto**) |
| Convenciones | Identificadores, frontmatter, los cuatro niveles de autoridad, cómo citar («`N-01` §9.2.2») |

Cada marco tiene anexo de autodiagnóstico (ficha de ubicación, determinación del contexto) y
tabla de correspondencia con los escenarios/contextos genéricos de la guía madre.

## Las diez familias

| Familia | Pregunta | Documentos (`doc_id`) |
|---|---|---|
| `FAM-FUN` Fundamentos (`10-…`) | ¿Qué es REST y qué de lo que llamamos REST lo es? | `TEM-REST` (seis restricciones de Fielding) · `TEM-RMM` (modelo de madurez) · `TEM-HATEOAS` · `TEM-ALT` (REST y alternativas: GraphQL, gRPC, tRPC, SOAP/WCF) |
| `FAM-REC` Diseño de recursos (`20-…`) | ¿Qué expone la API y cómo se llama? *La decisión más difícil de revertir; casi sin norma* | `TEM-RECURSOS` · `TEM-URI` (casing de segmentos, ruta vs query) · `TEM-JERARQ` · `TEM-ACCIONES` (operaciones no CRUD) |
| `FAM-HTTP` Semántica HTTP (`30-…`) | ¿Qué significa cada pieza del protocolo? *La familia con más respaldo normativo* | `TEM-METODOS` · `TEM-STATUS` (429 lo define RFC 6585, no 9110) · `TEM-HEADERS` · `TEM-CACHE` · `TEM-IDEM` (idempotencia y concurrencia) |
| `FAM-CON` Contratos y representaciones (`40-…`) | ¿Qué forma tiene lo que viaja por el cable? | `TEM-CAMPOS` (casing de campos y parámetros) · `TEM-ERR` (RFC 9457; cuatro modelos incompatibles en producción) · `TEM-PATCH` (tres RFC) · `TEM-PAG` (`Link` RFC 8288; la mayoría pagina en el cuerpo) · `TEM-FILTRO` (OData, JSON:API, AIP-160: ninguna adoptada por plataformas grandes) |
| `FAM-EVO` Evolución y versionado (`50-…`) | ¿Cómo se cambia sin romper a quien la usa? | `TEM-BREAK` (¿cuál de mis cambios rompe?: respuesta técnica, no opinable) · `TEM-VERS` (path, header, query; la opción «correcta» tiene adopción nula) · `TEM-DEPR` (`Deprecation`/`Sunset`; fechas defendibles exigen medir consumo por versión) |
| `FAM-ESP` Especificación y documentación (`60-…`) | ¿Cómo se declara y comunica el contrato? *Especificar ≠ documentar* | `TEM-OPENAPI` (OAS 3.2.0, `N-19`, 2025-09-19; `AddOpenApi`/`MapOpenApi`, transformers) · `TEM-DESIGNFIRST` · `TEM-CLIENTES` (generación de clientes y pruebas de contrato) |
| `FAM-SEG` Seguridad y robustez (`70-…`) | ¿Quién puede hacer qué y qué pasa cuando falla? *Solo mecanismos defensivos* | `TEM-AUTH` (RFC 6749/6750/7519/9068, `AddJwtBearer`, políticas) · `TEM-PROT` (rate limiting, exposición) · `TEM-RESIL` (`AddStandardResilienceHandler`, reintentos, circuit breaker; depende de `TEM-IDEM`) |
| `FAM-NET` Implementación en .NET (`80-…`) | ¿Cómo llevar el contrato a ASP.NET Core sin que el framework decida por uno? | `TEM-MINIMAL` · `TEM-PROYECTO` · `TEM-SERIAL` (camelCase por defecto, números entre comillas) · `TEM-VALID` (`Microsoft.Extensions.Validation`, source generator .NET 10) · `TEM-PRUEBAS` (`WebApplicationFactory`) · `TEM-CONSUMO` (Blazor y MAUI, `IHttpClientFactory`) |
| `FAM-IND` Guías de la industria (`90-…`) | ¿Quién prescribe qué y cuánto vale? *Corte por guía, no por decisión* | `TEM-GMS` (Azure `G-01` y Graph `G-02`, que se contradicen; el monolítico `G-03` deprecado) · `TEM-GGOOGLE` (AIP) · `TEM-GOTRAS` (Zalando, GOV.UK, adidas, Heroku) · `TEM-GCOMP` |
| `FAM-TRA` Transversales (`95-…`) | ¿Cómo se conecta con arquitectura, producto y generación asistida? *Sin fuente normativa posible* | `TEM-ARQ` (REST como adaptador primario) · `TEM-DX` (experiencia del consumidor) · `TEM-SDD` (OpenAPI como insumo de generación) |

### Tres niveles que `FAM-NET` obliga a distinguir

| Nivel | Qué es | Ejemplo |
|---|---|---|
| (a) Prescripción normativa | Microsoft lo prescribe con verbo prescriptivo | «For new projects, we recommend using Minimal APIs» (`N-24`); `TypedResults` preferido a `Results` (`N-26`) |
| (b) Default de plantilla | Lo que genera `dotnet new`, nada más | `AddOpenApi()` en `IsDevelopment()`, `WeatherForecast` (`N-66`) |
| (c) Convención de comunidad | Práctica difundida sin respaldo oficial | Carpetas `Endpoints/`, Clean Architecture, Vertical Slice, FluentValidation, Scalar sobre Swagger UI |

Confundir (b) con (a) produce «la plantilla lo hace así, entonces es lo correcto».

### Repartos de frontera que evitan duplicación (fijados en los README de familia)

| Decisión | Dónde |
|---|---|
| Casing de segmentos de URI; ruta vs query | `TEM-URI` |
| Casing de campos JSON y parámetros de query; sintaxis del filtro | `TEM-CAMPOS`, `TEM-FILTRO` |
| Qué código de estado | `TEM-STATUS`; el cuerpo del error → `TEM-ERR`; qué **no** va en el error → `TEM-PROT` |
| Qué es una ruptura | `TEM-BREAK`; quién la detecta (pruebas de contrato) → `TEM-CLIENTES` |
| Configuración de OpenAPI en ASP.NET Core | `TEM-OPENAPI`, no `FAM-NET` |
| Minimal APIs vs controllers | `TEM-MINIMAL` (contrato) y `TEM-ENDP` de la guía de código (organización) |

## Anexo de referencias (`99-Anexos/Referencias.md`, 548 líneas, 131 filas)

| Prefijo | Qué agrupa | Fuerza |
|---|---|---|
| `N-xx` | RFC IETF, OpenAPI Spec, OASIS, Microsoft Learn | Es el estándar: designación y sección exacta |
| `G-xx` | Microsoft (`G-01` Azure, `G-02` Graph, `G-03` deprecado), Google `G-04`, Zalando `G-05`, GOV.UK `G-06`, adidas `G-07`, Heroku `G-08` | Vale para quien la adopta |
| `F-xx` | Drafts IETF, specs comunitarias (JSON:API `F-04`, OData 4.02 `F-05`, `Asp.Versioning` `F-09`, Standard Webhooks `F-16`) | No obliga; requiere evidencia `P-xx` |
| `O-xx` | Fielding `O-01`, Richardson/Fowler `O-03`… | Origen de un concepto, no autoridad |
| `P-xx` | Documentación pública de APIs reales (Stripe `P-04`, GitHub `P-05`…) | Prueba de qué se hace, jamás de qué corresponde |

Secciones clave: §6 **documentos obsoletos que se siguen citando** (RFC 2616, RFC 7231 → 9110,
RFC 7807 → 9457, Microsoft REST API Guidelines monolítico); §7 advertencias de estado; §8
**fuentes no verificadas** (p. ej. adopción real del header `Deprecation` en formato RFC 9745:
sin evidencia salvo GitHub; adopciones que se atribuye Standard Webhooks; definición de
*breaking change* de GitHub: 404). Todas las verificaciones datan del 2026-07-20.

## Cómo entrar sin mapa conceptual

- Decidir un punto concreto → familia temática (`TEM-`) correspondiente en la tabla de arriba.
- Evaluar una guía corporativa completa → `FAM-IND`.
- Ubicarse (escenario/contexto) → anexos de `Escenarios.md` y `Contextos.md`.
- Ruta secuencial → `FAM-FUN` → `FAM-REC` → `FAM-HTTP` → `FAM-CON` → `FAM-EVO` → `FAM-ESP` →
  `FAM-SEG` → `FAM-NET` → `FAM-IND` → `FAM-TRA` (orden de las carpetas).

## Relación con las otras guías

- `TEM-ENDP` de [03](03_Organizacion-Codigo-NET.md) (organización) ↔ `TEM-MINIMAL` (contrato).
- `DOC-API` y `DOC-INTEGRACION` de [01](01_Documentacion-Tecnica.md) son los documentos que esta
  guía llena de contenido; `TEM-SDD` ↔ `DOC-SDD`.
- `UX-UI-Guide.md` §10 «Developer Experience en REST APIs» trata DX, modelos de error y versionado
  desde el marco UX, sin niveles de autoridad → [07](07_DevOps-Agiles-SDD-UX.md).
