# ia-db — Lab-Documentos

> **Instrucción para IA**: este archivo es el **punto de entrada único** a la base de conocimiento
> del repositorio [`Lab-Documentos`](https://github.com/hdcm-dev/Lab-Documentos) (`/LAB/Lab-Documentos`).
> Leelo primero, ubicá el tema en la tabla de navegación y cargá **sólo** el índice —o los dos— que
> correspondan. Ampliá a los archivos fuente únicamente cuando el índice no alcance: cada índice
> referencia sus fuentes con ruta exacta relativa a `Lab-Documentos/`, con § o `doc_id` cuando existen.
> No recorras las ~125 100 líneas de Markdown ni los laboratorios del corpus completo.

## Navegación

| Necesitás saber… | Leé este índice |
| --- | --- |
| Qué es el repositorio, cómo se organiza `Guides/`, de dónde salió cada guía, cómo se relacionan, qué cambió desde la v3.0 y los hallazgos del corpus | [00_MASTER-INDEX.md](indexes/00_MASTER-INDEX.md) |
| Qué tipo de documento técnico producir (Vision, SRS, SAD, ADR, Runbook…) según escenario o rol, con su plantilla; el apunte original del sistema documentador (obsoleto) y la demo de ayuda por rol | [01_Documentacion-Tecnica.md](indexes/01_Documentacion-Tecnica.md) |
| Cómo estructurar, redactar o evaluar **un informe de solución** (arquitectura + despliegue + requisitos), qué es norma (ISO 42010, 25010:2023) y qué es marco (arc42, C4) | [02_Informe-de-Solucion.md](indexes/02_Informe-de-Solucion.md) |
| Monolito vs microservicios, cuántos proyectos, carpetas vs proyectos, capas, nombres y estilo C# (`.editorconfig`), si Clean/Onion/Hexagonal son estándar | [03_Organizacion-Codigo-NET.md](indexes/03_Organizacion-Codigo-NET.md) |
| Cómo diseñar, versionar, especificar (OpenAPI) o implementar en ASP.NET Core una API REST; qué autoridad tiene una «regla REST» | [04_Diseno-REST-API.md](indexes/04_Diseno-REST-API.md) |
| Qué capas y proyectos necesita una solución .NET (Domain/Application/Infrastructure/WebAPI/Contracts), el laboratorio `L00–L24`/`V01–V09`, el taller «La Estancia», microservicios y manejo de archivos/video | [05_Arquitectura-NET-y-Laboratorio.md](indexes/05_Arquitectura-NET-y-Laboratorio.md) |
| Por qué compila en Windows y falla en Linux (cp1252, BOM, CRLF); fijar SDK/Node/Python, congelar dependencias, devcontainers, SBOM/SLSA, compuerta única, repo políglota y su laboratorio | [06_Metodologia-Entorno-Desarrollo.md](indexes/06_Metodologia-Entorno-Desarrollo.md) |
| Pruebas E2E con Playwright en Blazor, qué probar en una pantalla (superficie/promesa/estado), unitarias, API y Appium en Android; qué copia de las guías E2E está vigente | [07_Testing-E2E.md](indexes/07_Testing-E2E.md) |
| Modelo de ramas adoptado, SemVer y protección de rama; workflows `ci`/`release`/auditoría; prácticas GitFlow y GitHub Flow; GitHub Actions; DORA, Conventional Commits, NuGet | [08_Ramas-CI-CD-y-DevOps.md](indexes/08_Ramas-CI-CD-y-DevOps.md) |
| SDD y agentes (AG-xx, subagentes de refinamiento), Scrum + Jira, UX/UI/DX (WCAG 2.2, ISO 9241), auditoría de intrusiones en Windows | [09_IA-Agiles-UX-y-Otros.md](indexes/09_IA-Agiles-UX-y-Otros.md) |
| Frontmatter, `doc_id`, marcas **[F]/[C]/[E]/[V]**, niveles de autoridad y catálogos `N-/G-/F-/O-/P-`, qué significa `ESC-`/`CTX-`/`ACT-`/`E-` en cada guía, glosario cruzado | [10_Convenciones-y-Glosario.md](indexes/10_Convenciones-y-Glosario.md) |
| Cómo diseñar e intervenir un sistema documentador (cuerpo `SDEI`: temas, anexos, frontmatter de diez campos), la mini demo MovilidadUrbana, la compuerta `docs-guard` y sus workflows, `AGENTS.md` y el expediente 0002 del que salen | [11_Sistema-Documentador-SDEI.md](indexes/11_Sistema-Documentador-SDEI.md) |
| Apps .NET MAUI con pantallas Blazor que se actualizan sin tienda: guía `Concepts/Framework-Concept/`, su demo y su compuerta | [12_Framework-Concept.md](indexes/12_Framework-Concept.md) |

## Resumen ejecutivo

| Dato | Valor |
| --- | --- |
| Proyecto indexado | `Lab-Documentos` (`/LAB/Lab-Documentos`) |
| Repositorio | `https://github.com/hdcm-dev/Lab-Documentos` · rama `main` en `fe10086` (2026-10-27, merge de E1-U4f) |
| Tipo | **Corpus de guías de estudio** en Markdown sobre ingeniería de software, con laboratorios ejecutables en contenedor en tres guías, un cuerpo documental con compuerta de CI propia (`SDEI` + `docs-guard`) y una guía con demo MAUI (`Concepts/Framework-Concept/`) |
| Volumen | 1 161 archivos versionados (≈ 15 MiB) · 383 `.md` (125 129 líneas; 1 vacío) · 324 bloques Mermaid · 251 `.cs`, 46 `.csproj`, 108 `.sh`, 135 salidas `.txt` · 4 workflows · 10 PNG y 1 PDF |
| Stack de referencia | .NET 10 / C# (SDK 10.0.400) · ASP.NET Core · Blazor *interactive server* y WebAssembly · EF Core · .NET MAUI · Playwright + NUnit · xUnit · Docker y devcontainers · GitHub Actions (runner propio) · Node.js y Python (laboratorio políglota y compuerta documental) |
| Documentación asociada | `Lab-Documentos.Documentacion` (este repositorio: prompts generadores en `PROMPTs/Guides/01…15`, expedientes 0001 de Framework Concept en `PROMPTs/Concepts/` y 0002 de DocAsCode en `PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/OUTPUTs/`, prompts de indexado en `PROMPTs/Indexado/`, esta ia-db) |

**Función principal.** Reunir las guías de estudio que el equipo produjo —con asistencia de agentes— sobre
documentación técnica, informes de solución, organización de código y APIs REST en .NET, arquitectura
por capas, entorno de desarrollo reproducible, pruebas automatizadas, ramas y CI/CD, más material
importado de SDD, métodos ágiles, UX y seguridad. El rasgo común es **separar lo normado de lo
convenido y del criterio propio**, y respaldar afirmaciones con fuentes o con ejecuciones registradas.

**Arquitectura en una línea.** `Guides/<Categoría>/<Guía>/`: guías estructuradas
`00-Marco-de-Referencia → 01-Mapa-Conceptual → NN-Familia → 99-Anexos` con frontmatter y `doc_id`;
guías únicas con marcas de evidencia y laboratorio `Examples/`; material importado sin ese aparato.
Desde octubre de 2026, un cuerpo con `corpus_id` (`SDEI`) cuyo frontmatter verifica la compuerta
`docs-guard` en cada PR, y `Concepts/` para guías conceptuales con demo.

## Estructura del repositorio indexado

```
Lab-Documentos/
├── README.md                          portada: ruta de lectura mínima, estructura, compuerta
├── AGENTS.md                          puerta de la ruta «agente»                                                            → 11
├── CHANGELOG.md                       Keep a Changelog; 2026-09-18 → 09-21 y 2026-10-26 → 10-27 (+ delegación del merge)
├── .gitignore                         plantilla Visual Studio / .NET (+ *.log)
├── .github/                             5 arch. · 4 workflows (docs-guard, enlaces semanal, mini demo, framework concept) + plantilla de PR → 11, 12
├── scripts/                             3 arch. · ci-local.sh y configuración de lychee y markdownlint                        → 11
├── tools/docs-guard/                   66 arch. · controles de la compuerta, esquemas, prefijos, fixtures                     → 11
├── Concepts/
│   └── Framework-Concept/             245 arch. · guía MAUI + Blazor actualizable sin tienda y su demo                         → 12
└── Guides/
    ├── README.md                      índice por categoría
    ├── Documentacion-Tecnica/         131 arch. · guía madre (28 tipos, 7 familias) → 01 · cuerpo SDEI + mini demo + apunte obsoleto → 11
    ├── Despliegue/                     35 arch. · informe de solución · GitHub Actions · DevOps importado                      → 02, 08
    ├── Arquitectura/                   94 arch. · organización/estilo de código .NET · REST API (README vacío)                → 03, 04
    ├── Dot-NET-Arquitectura-Guide/    164 arch. · GUIA-NET-ARQ v2.5.0 + laboratorio + taller «La Estancia» + Exercices/ del usuario → 05
    ├── Metodologia-Entorno-Desarrollo/ 343 arch. · GUIA-ENT-DEV v1.1.0 + 74 experimentos en Docker                           → 06
    ├── Testing/                        29 arch. · E2E-Guide (copia vieja) + corpus Lab-E2E.WebBlazor-Guides                  → 07
    ├── GitFlow/                         9 arch. · GF-GUIA + 3 workflows + prácticas GitFlow / GitHub Flow                    → 08
    ├── IA/                             23 arch. · SDD, agentes AG-xx, refinamiento, nota de Claude Code (importado)          → 09
    ├── Metodologia-Agiles/              5 arch. · Scrum + Jira + PDF Scrum Guide 2020 (importado)                            → 09
    ├── UX-UI-Design/                    2 arch. · marco teórico UX/UI/DX (importado)                                         → 09
    └── Otros/                           2 arch. · auditoría de seguridad en servidor Windows + cuaderno                      → 09
```

## Restricciones para IA

- **No modificar `Lab-Documentos` desde esta base.** La ia-db documenta; no autoriza cambios, commits,
  push ni pull requests.
- **No escribir en carpetas del usuario**: `Guides/Dot-NET-Arquitectura-Guide/Exercices/`,
  `Interactive-Activities/Mis-Apuntes-Borradores/` y el texto de la Actividad 1 fuera de los bloques `⟨M⟩`.
- **No presentar el índice como fuente de verdad.** Ante contradicción prevalece el archivo fuente: se
  corrige el índice, no el razonamiento sobre la guía.
- **No mezclar vocabularios.** `ESC-`, `CTX-`, `ACT-`, `E-`, `C-`, `A-`, `N-`, `F-`, `P-` significan cosas
  distintas en cada guía, y los `doc_id` sólo son únicos dentro de una guía: citá siempre `doc_id` + ruta
  ([10](indexes/10_Convenciones-y-Glosario.md)).
- **No citar como norma** lo marcado **[C]**, «esta guía recomienda», `[criterio]` o «Criterio de esta guía».
- **No dar por vigente el material importado** (DevOps, IA, Scrum, UX, `Microservicios-Guide.md`,
  `Manejo-Archivos-Guide.md`) sin mirar fecha y origen: viene del *Motor DSL* y contradice al modelo de
  ramas adoptado.
- **Usar la copia vigente**: las guías E2E vigentes están en `Guides/Testing/Lab-E2E.WebBlazor-Guides/`;
  para ramas y Actions, los originales de `Guides/GitFlow/` y `Guides/Despliegue/`.
- **No confiar en los enlaces relativos sin comprobarlos**: 246 de 3 211 no resuelven en `fe10086`
  (fuera del cuerpo `SDEI`, que la compuerta mantiene limpio salvo 3 plantados); `Concepts/Framework-Concept/`
  usa además enlaces absolutos del workspace que no resuelven en GitHub ([00](indexes/00_MASTER-INDEX.md) §8, H-B).
- **No buscar un `llms.txt` ni un sitio publicado**: en el escalón 1 el corpus se lee en GitHub; esta base no
  enlaza a un `llms.txt` porque no existe.
- **El estado de un documento del cuerpo `SDEI` lo da su README** (`IDX-SDEI` §4); el apunte `DOC-SDT-0001` está
  `obsoleto` y su tabla de destinos dice adónde fue cada sección.
- **No escanear** `.git/`, `bin/`, `obj/`, los PNG, el PDF ni la propia `ia-db`.

## Manifiesto de generación

- Generado por : `/IA/PROMPTs/IA.Prompts/Tool-Prompts/Indexado-Documentado/Iniciar-Indexado.md`
- Invocado por : `/LAB/Lab-Documentos.Documentacion/PROMPTs/Indexado/Crear-Indexado.md` (modalidad
  *ultracode*: workflow con un indexador y un verificador adversarial por dominio (01–09), un
  consolidador (00, 10 y este README) y un chequeo final)
- Perfil       : `/IA/PROMPTs/IA.Prompts/PromptFramework/Profiles/Knowledge-Indexing.md`
- Alcance      : `/LAB/Lab-Documentos` (modo proyecto; destino explícito fuera del proyecto, en
  `/LAB/Lab-Documentos.Documentacion/ia-db`)
- Fuentes      : inventario con `git ls-files` (811 archivos; respeta `.gitignore`): `README.md`,
  `CHANGELOG.md`, `.gitignore` y `Guides/**` — 295 `.md`, 89 `.cs`, 38 `.csproj`, 9 `.razor`, 99 `.sh`,
  11 `.py`, 37 `.json`, 13 `.yml/.yaml`, 132 `.txt` y configuración de laboratorio. Los 10 PNG y el PDF
  `Guides/Metodologia-Agiles/Scrum-Guide/2020-Scrum-Guide-US.pdf` se inventarían, no se leen. Para la
  procedencia se leyeron además `git log` y `PROMPTs/Guides/` de `Lab-Documentos.Documentacion`; la v3.0
  sirvió sólo como línea de base del cambio
- Estado del repositorio : v4.0 sobre `main` en `5d5c2b4` (2026-10-11); v4.1 sobre `main` en `fe10086`
  (2026-10-27), medida con `git archive` del commit
- base_commit  : `fe10086f2b083f6cfe227da49174d204c1b0e008` (merge del PR #25 de `Lab-Documentos`, unidad E1-U4f
  del expediente 0002). Los índices 02–07 y 09 conservan su corte en `5d5c2b4`: sus fuentes no cambiaron entre
  ambos commits salvo dos líneas de redacción en `GitHub-Action-Guide.md` y su copia, que no citan
- Verificaciones ejecutadas (chequeo final del 2026-10-18, scripts `python3 -I` fuera del repo):
  - Enlaces Markdown relativos entre archivos de la ia-db: **127 comprobados** (6 con ancla `#…`,
    contrastadas con slugs estilo GitHub de los encabezados reales): 127 resuelven, 0 rotos.
  - Rutas del corpus citadas en código en línea (`Guides/…`, `README.md`, `CHANGELOG.md`,
    `.gitignore`, más 49 relativas a `Guides/` y 8 con espacios en el nombre): **364 comprobadas**
    contra `git ls-files`; 24 no existen y son todas **intencionales** (rutas viejas que se citan como
    tales en «qué cambió» o como destino de un enlace roto del corpus); 6 rutas del workspace
    (`IA/PROMPTs/…`) comprobadas aparte, existen. Correcciones necesarias: 0.
  - Cifras del resumen re-medidas: 811 archivos (≈ 9,5 MiB), 295 `.md` con 114 597 líneas, 279 bloques
    Mermaid, 3 `.md` vacíos, 89 `.cs`, 38 `.csproj`, 99 `.sh`, 132 `.txt`, 10 PNG, 1 PDF; H-B recontado
    de forma independiente: 247 enlaces rotos sobre 2 729 relativos (la 00 dice 2 728: diferencia de
    método en un enlace, el total de rotos coincide).
  - Tamaño: 3 900 líneas en total; el índice mayor tiene 413 (05); ninguno pasa de 500.
  - Duplicación: 0 líneas largas (> 60 caracteres) y 0 tramos de 3 líneas repetidos entre archivos;
    los dominios de 01–10 no se pisan (los cruces se resuelven por remisión).
  - Verificación de finalización del prompt: el README responde solo «¿de qué trata y con qué stack?»
    (resumen ejecutivo + stack); cada índice cubre un único dominio; este manifiesto nombra los prompts
    de regeneración y actualización, el perfil, el alcance, las fuentes y el commit base.
- Generado     : 2026-10-18 · Versión: 4.0 (regeneración completa: reemplaza la 3.0 del 2026-09-12, que
  indexaba la organización previa de `Guides/` en `e1a39bf`)
- Actualizado  : 2026-10-27 · Versión: **4.1** (incremental, `Actualizar-Indexado.md`; unidad E1-U5 del expediente
  0002). Cambio `5d5c2b4` → `fe10086`: 350 altas, 8 modificados, 0 bajas. Índices nuevos: 11 (cuerpo `SDEI`, mini
  demo, `docs-guard`, `AGENTS.md`, expediente 0002) y 12 (Framework Concept). Tocados: 00, 01, 08, 10 y este
  README; en 06 y 09 sólo se redactaron una cuenta personal y direcciones IP privadas citadas del corpus (S2, repo
  público). Sin cambios: 02, 03, 04, 05, 07. No se enlaza a un `llms.txt`: no hay sitio publicado en el escalón 1
- Verificaciones de la v4.1 (2026-10-27, scripts `python3 -I` fuera del repo, sobre `git archive fe10086`):
  - Cobertura: los 55 `.md` agregados o modificados entre `5d5c2b4` y `fe10086` (sin fixtures ni fuentes de la
    demo) tienen entrada con su ruta y, si lo tienen, su `doc_id`: 55 de 55; los 29 `doc_id` del cuerpo `SDEI`, 29.
  - Enlaces Markdown relativos entre archivos de la ia-db: **185 comprobados** (anclas contra slugs de los
    encabezados reales): 0 rotos (1 falso positivo: un `](…)` citado como texto en 04).
  - Rutas citadas en código en línea en 00, 01, 08, 10, 11, 12 y README: **228 comprobadas** contra
    `git ls-tree fe10086` (y las de `PROMPTs/` contra este repositorio); 9 no existen y son intencionales (rutas
    viejas citadas como tales, un script de la app de práctica de 08 y un nombre no ASCII que `git` escapa).
  - Cifras re-medidas: 1 161 archivos (≈ 15 MiB), 383 `.md`, 125 129 líneas, 324 bloques Mermaid en 195
    archivos, 1 `.md` vacío; enlaces relativos del corpus: 246 rotos de 3 211 (mismo script: 253 de 2 732 en
    `5d5c2b4`).
  - Tamaño: ningún índice pasa de 500 líneas (el mayor, 08, tiene 423). Duplicación: 0 líneas largas repetidas
    entre archivos.
  - Barrido S2 (repo público): 0 rutas del host, 0 IP privadas, 0 nombres de repos privados en la ia-db.
- Actualizar   : `/IA/PROMPTs/IA.Prompts/Tool-Prompts/Indexado-Documentado/Actualizar-Indexado.md`
  (invocación local: `/LAB/Lab-Documentos.Documentacion/PROMPTs/Indexado/Actualizar-Indexado.md`)
