# ia-db — Lab-Documentos

> **Instrucción para IA**: este archivo es el **punto de entrada único** a la base de conocimiento
> del repositorio [`Lab-Documentos`](https://github.com/hdcm-dev/Lab-Documentos) (`/LAB/Lab-Documentos`).
> Leelo primero, ubicá el tema en la tabla de navegación y cargá **sólo** el índice —o los dos— que
> correspondan. Ampliá a los archivos fuente únicamente cuando el índice no alcance: cada índice
> referencia sus fuentes con ruta exacta relativa a `Lab-Documentos/`, con § o `doc_id` cuando existen.
> No recorras las ~164 000 líneas de Markdown ni los laboratorios del corpus completo.

## Navegación

| Necesitás saber… | Leé este índice |
| --- | --- |
| Qué es el repositorio, volumen, cómo se organizan `Guides/` y `Concepts/`, raíz y compuerta, de dónde salió cada guía, cronología, relaciones y hallazgos transversales | [00_MASTER-INDEX.md](indexes/00_MASTER-INDEX.md) |
| Qué tipo de documento técnico producir (Vision, SRS, SAD, ADR, Runbook…) según escenario, contexto y actor; plantillas, convenciones de frontmatter/ID y rutas de lectura por rol | [01_Documentacion-Tecnica.md](indexes/01_Documentacion-Tecnica.md) |
| Cómo escribir o evaluar un informe de solución (arquitectura, despliegue, RF/RNF), su plantilla, ISO 42010/25010:2023, arc42, C4 | [02_Informe-de-Solucion.md](indexes/02_Informe-de-Solucion.md) |
| Cómo organizar y escribir código .NET: monolito o microservicios, cuántos proyectos, Clean/Onion/Hexagonal o Vertical Slice, namespaces, DTOs, nombres, `.editorconfig`, Minimal APIs, repositorio sobre EF Core | [03_Organizacion-Codigo-NET.md](indexes/03_Organizacion-Codigo-NET.md) |
| Cómo diseñar, versionar, especificar (OpenAPI), asegurar e implementar en ASP.NET Core una API REST, y qué autoridad tiene cada regla | [04_Diseno-REST-API.md](indexes/04_Diseno-REST-API.md) |
| Arquitectura .NET en capas (Domain/Application/Infrastructure/WebAPI/Contracts), el laboratorio `L00–L24`/`V01–V09`, el taller «La Estancia», microservicios y manejo de archivos | [05_Arquitectura-NET-y-Laboratorio.md](indexes/05_Arquitectura-NET-y-Laboratorio.md) |
| Encoding/BOM/CRLF entre Windows y Linux, fijar SDK/Node/Python, locks, devcontainers y digest, SBOM/SLSA, compuerta única, repo políglota y su laboratorio | [06_Metodologia-Entorno-Desarrollo.md](indexes/06_Metodologia-Entorno-Desarrollo.md) |
| E2E con Playwright en Blazor, qué probar (superficie/promesa/estado), unitarias, API, pantalla MAUI con Appium, qué copia de las guías E2E está vigente | [07_Testing-E2E.md](indexes/07_Testing-E2E.md) |
| Modelo de ramas adoptado (`main` + `release/x.y`), workflows CI/release/convergencia, GitFlow/GitHub Flow, GitHub Actions, DORA, SemVer, Conventional Commits, NuGet y la CI propia del repo | [08_Ramas-CI-CD-y-DevOps.md](indexes/08_Ramas-CI-CD-y-DevOps.md) |
| Sumar una capa de IA a una app .NET (`IChatClient`, RAG, herramientas con aprobación, MCP, ADR-01…13, pruebas k de M), diseño conversacional por anillos, Conocimientos K1–K8, ejemplos y demo de Movilidad Urbana | [09_IA-Layer-DotNet.md](indexes/09_IA-Layer-DotNet.md) |
| Guía de modelos de IA (`IAM-xx`, grafo, labs), trabajo con IA bajo SDD (niveles, Claude↔Copilot, trazabilidad), perfiles `AG-xx` y prompts de refinamiento `SA-xx` | [10_IA-Modelos-SDD-Agentes.md](indexes/10_IA-Modelos-SDD-Agentes.md) |
| Scrum, épicas, US, DoR/DoD, Jira; marco UX/UI/DX (Nielsen, WCAG 2.2) y qué documentar en UX; auditoría forense de un servidor Windows; mapa de categorías de `Guides/` | [11_Agiles-UX-y-Seguridad.md](indexes/11_Agiles-UX-y-Seguridad.md) |
| Cuerpo `SDEI` del sistema documentador (Marco, Mapa, temas, anexos, libro DocsAsCode), mini demo MovilidadUrbana, ayuda por rol, compuerta `docs-guard` y sus workflows, `AGENTS.md` | [12_Sistema-Documentador-SDEI.md](indexes/12_Sistema-Documentador-SDEI.md) |
| App .NET MAUI híbrida con contenido Blazor WASM firmado, actualizable OTA sin tienda y offline: demo, compuerta `fw-ok`, entrega iOS, libro, ADR «contenedor nativo» y Conocimiento | [13_Framework-Concept.md](indexes/13_Framework-Concept.md) |
| Frontmatter, `doc_id`, niveles de autoridad y marcas de evidencia, qué significa cada prefijo (`ESC-`/`CTX-`/`ACT-`/`N-`/`F-`…) en cada guía, glosario cruzado | [14_Convenciones-y-Glosario.md](indexes/14_Convenciones-y-Glosario.md) |

### Correspondencia con la numeración 1.x

| Índice v1.x (2026-10-29) | Ahora (v2.0) |
| --- | --- |
| `00`–`08` | mismos números y dominios |
| `09_IA-Agiles-UX-y-Otros` | se partió en `09` (IA Layer .NET), `10` (modelos, SDD, agentes) y `11` (ágiles, UX, seguridad) |
| `10_Convenciones-y-Glosario` | `14_Convenciones-y-Glosario` |
| `11_Sistema-Documentador-SDEI` | `12_Sistema-Documentador-SDEI` |
| `12_Framework-Concept` | `13_Framework-Concept` |

Los archivos con nombre de la 1.x se retiraron de `indexes/` en la 2.0; si reaparece alguno, es
**obsoleto**: no lo cargues.

## Resumen ejecutivo

| Dato | Valor |
| --- | --- |
| Proyecto indexado | `Lab-Documentos` (`/LAB/Lab-Documentos`) |
| Repositorio | `https://github.com/hdcm-dev/Lab-Documentos` · rama `main` en `34929f2` (2026-11-15, merge del PR #77) |
| Tipo | **Corpus de guías de estudio** en Markdown sobre ingeniería de software, con laboratorios ejecutables en contenedor, un cuerpo documental con compuerta de CI propia (`SDEI` + `docs-guard`), guías de IA con ejemplos y demo, y una guía conceptual con demo MAUI (`Concepts/Framework-Concept/`) |
| Volumen | 1 757 archivos versionados · 483 `.md` (164 013 líneas) · 455 bloques Mermaid · 232 commits · 5 workflows |
| Stack de referencia | .NET 10 / C# (SDK 10.0.400) · ASP.NET Core · Blazor Server y WebAssembly · EF Core · .NET MAUI · Microsoft.Extensions.AI · Playwright + NUnit · xUnit · Docker y devcontainers · GitHub Actions (runner propio `ci-hdcm`) · Node.js y Python |
| Documentación asociada | `Lab-Documentos.Documentacion` (prompts generadores en `PROMPTs/Guides/`, expedientes en `PROMPTs/Concepts/` y `PROMPTs/DEVs/`, prompts de indexado en `PROMPTs/Indexado/`, esta ia-db) |

**Función principal.** Reunir las guías de estudio producidas —con asistencia de agentes— sobre
documentación técnica, informes de solución, organización de código y APIs REST en .NET, arquitectura
por capas, entorno reproducible, pruebas, ramas y CI/CD, integración de IA en .NET y diseño
conversacional, más material importado (SDD, ágiles, UX, seguridad). El rasgo común es **separar lo
normado de lo convenido y del criterio propio**, y respaldar afirmaciones con fuentes o ejecuciones registradas.

**Arquitectura en una línea.** `Guides/<Categoría>/<Guía>/` con guías estructuradas
(`00-Marco → 01-Mapa → NN-Familia → 99-Anexos`, frontmatter y `doc_id`) o únicas con `Examples/`;
un cuerpo con `corpus_id` (`SDEI`) validado por `docs-guard` en cada PR; y `Concepts/` para guías conceptuales con demo.

## Estructura del repositorio indexado

```
Lab-Documentos/
├── README.md                          portada: ruta de lectura mínima, estructura, compuerta     → 00
├── AGENTS.md                          puerta de la ruta «agente»                                → 12
├── CHANGELOG.md                       Keep a Changelog                                          → 00
├── .github/                           6 arch. · 5 workflows + plantilla de PR                  → 08, 12, 13
├── scripts/                           3 arch. · ci-local.sh, config de lychee y markdownlint    → 12
├── tools/docs-guard/                  97 arch. · compuerta documental, esquemas, prefijos       → 12
├── Concepts/
│   └── Framework-Concept/             280 arch. · guía MAUI híbrida OTA + libro + demo          → 13
└── Guides/
    ├── README.md                      índice por categoría (GUIAS-INDICE)                       → 11
    ├── Documentacion-Tecnica/         158 arch. · guía madre → 01 · cuerpo SDEI + demos         → 12
    ├── Despliegue/                     35 arch. · informe de solución → 02 · Actions, DevOps    → 08
    ├── Arquitectura/                   94 arch. · organización de código .NET → 03 · REST API   → 04
    ├── Dot-NET-Arquitectura-Guide/    164 arch. · GUIA-NET-ARQ + laboratorio + «La Estancia»   → 05
    ├── Metodologia-Entorno-Desarrollo/ 343 arch. · GUIA-ENT-DEV + 74 experimentos              → 06
    ├── Testing/                        29 arch. · E2E (copia vieja + corpus vigente)            → 07
    ├── GitFlow/                         9 arch. · GF-GUIA + workflows + GitFlow/GitHub Flow     → 08
    ├── IA/                            525 arch. · AI Layer .NET → 09 · IA-Model, SDD, agentes  → 10
    ├── Metodologia-Agiles/              5 arch. · Scrum + Jira (importado)                      → 11
    ├── UX-UI-Design/                    2 arch. · marco UX/UI/DX (importado)                    → 11
    └── Otros/                           2 arch. · auditoría de seguridad Windows                → 11
```

## Restricciones para IA

- **No modificar `Lab-Documentos` desde esta base.** La ia-db documenta; no autoriza cambios, commits,
  push ni pull requests.
- **No escribir en carpetas del usuario**: `Guides/Dot-NET-Arquitectura-Guide/Exercices/` y los apuntes
  o borradores personales de `Interactive-Activities/`.
- **El índice no es fuente de verdad.** Ante contradicción prevalece el archivo fuente: se corrige el índice.
- **No mezclar vocabularios.** `ESC-`, `CTX-`, `ACT-`, `P-n`, `N-`, `F-`… significan cosas distintas en cada
  guía y los `doc_id` sólo son únicos dentro de una guía: citá `doc_id` + ruta ([14](indexes/14_Convenciones-y-Glosario.md)).
- **No citar como norma** lo marcado como criterio propio o recomendación de la guía.
- **No dar por vigente el material importado** (DevOps, SDD, Scrum, UX, microservicios) sin mirar fecha y
  origen: puede contradecir al modelo de ramas adoptado.
- **Usar la copia vigente**: E2E en `Guides/Testing/Lab-E2E.WebBlazor-Guides/`; ramas y Actions en los
  originales de `Guides/GitFlow/` y `Guides/Despliegue/`.
- **No confiar en enlaces relativos sin comprobarlos**: varias guías tienen enlaces rotos medidos en cada
  índice (p. ej. 76 entrantes a la guía madre, 57 en 02, 39 en 08).
- **Datos marcados «(sin verificar)»** no se presentan como hechos.
- **No cargar los índices obsoletos de la 1.x** ni escanear `.git/`, `bin/`, `obj/`, imágenes, el PDF ni la propia `ia-db`.

## Manifiesto de generación

- Generado por : /IA/IA.Prompts/Tool-Prompts/Indexado-Documentado/Iniciar-Indexado.md
  (invocado desde /LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Indexado/Crear-Indexado.md)
- Alcance      : /LAB/Lab-Documentos/Lab-Documentos (modo proyecto; destino /LAB/Lab-Documentos/Lab-Documentos.Documentacion/ia-db)
- Fuentes      : inventario con `git ls-files` sobre `34929f2` (respeta `.gitignore`): `README.md`, `AGENTS.md`,
  `CHANGELOG.md`, `.gitignore`, `.github/`, `scripts/`, `tools/docs-guard/`, `Guides/**` y `Concepts/**`;
  además `git log` y el listado de `Lab-Documentos.Documentacion/PROMPTs/` para la procedencia. Excluidos:
  `bin/`, `obj/`, `node_modules/`, binarios, imágenes (inventariadas, no leídas) y el PDF de la Scrum Guide
- Generado     : 2026-11-16 · Versión: 2.0 (regeneración completa; reemplaza la 1.x del 2026-10-29) · base origin/main 34929f2
- Actualizar   : /IA/IA.Prompts/Tool-Prompts/Indexado-Documentado/Actualizar-Indexado.md
