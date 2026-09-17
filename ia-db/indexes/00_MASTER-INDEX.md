# 00 — Índice maestro

> **Propósito**: visión general de `Lab-Documentos`: qué es, qué guías contiene, de dónde salió cada
> una, qué comparten y qué hallazgos tiene el árbol al momento de indexar.
> **Fuente primaria**: `Guides/*/README.md`, frontmatter de cada guía, `git status` / `git log` de
> `Lab-Documentos`, `README.md` y `CHANGELOG.md` de `Lab-Documentos.Documentacion`, `wc -l` y una
> comprobación de enlaces relativos ejecutadas el 2026-09-12.

## Qué es

Un repositorio **solo de documentación**: quince carpetas de guías de estudio en Markdown sobre
ingeniería de software con ejemplos en .NET. No compila nada. Las guías propias se produjeron con
agentes a partir de prompts versionados en `Lab-Documentos.Documentacion/PROMPTs/`; el resto se
importó de otros proyectos del equipo. Se leen de dos maneras: de corrido, para estudiar; o por el
mapa conceptual, para resolver algo concreto.

## Inventario de guías

| # | Carpeta | Tipo | `.md` | Líneas | `doc_id` raíz · `last_review` | Índice ia-db |
|---|---|---|---:|---:|---|---|
| 1 | `Documentacion-Tecnica/` | Guía estructurada: marco + mapa + 7 familias + métodos + modelos + transversales + anexos | 59 | 20 700 | `GUIA-INDICE` · 2026-07-18 | [01](01_Documentacion-Tecnica.md) |
| 2 | `Documentacion-Informe-Despliegue/` | Guía estructurada: marco + mapa + 5 familias + anexos | 30 | 5 348 | `GUIA-INDICE` · 2026-07-21 | [02](02_Informe-de-Solucion.md) |
| 3 | `Organizacion-Estilo-Patrones-Codigo/` | Guía estructurada: marco + mapa + 6 familias + análisis integral + anexos | 38 | 11 321 | `GUIA-INDICE` · 2026-07-20 | [03](03_Organizacion-Codigo-NET.md) |
| 4 | `Organizacion-Estilo-Rest-API/` | Guía estructurada: marco + 10 familias + 1 anexo (**sin README, mapa ni glosario**) | 56 | 21 327 | *(README vacío)* · 2026-07-20 | [04](04_Diseno-REST-API.md) |
| 5 | `Estandares-Modelo-Ramas-Guide/` | Documento único + anexo de 3 workflows | 2 (+3 yml) | 2 132 | `GF-GUIA` · 2026-08-23 | [05](05_Modelo-de-Ramas-y-Practicas.md) |
| 6 | `GitFlow-Practice-Guide/` | Guía práctica: 8 escenarios (00–07) | 2 | 1 269 | `GF-09` · 2026-08-23 | [05](05_Modelo-de-Ramas-y-Practicas.md) |
| 7 | `GitHubFlow-Practice-Guide/` | Guía práctica: 8 escenarios (00–07) | 2 | 1 217 | `GHF-IDX` · 2026-08-25 | [05](05_Modelo-de-Ramas-y-Practicas.md) |
| 8 | `GitHub-Action-Guide/` | Documento único (9 secciones + anexos A–F) | 1 | 2 974 | `GHA-00` · 2026-08-31 | [06](06_GitHub-Actions-y-E2E.md) |
| 9 | `E2E-Guide/` | Guía de estudio + guía rápida | 2 | 2 137 | `E2E-00`, `E2E-01` · 2026-08-23/24 | [06](06_GitHub-Actions-y-E2E.md) |
| 10 | `DevOps-Guide/` | Material importado (Motor DSL) | 4 | 2 853 | sin `doc_id` · abril 2026 | [07](07_DevOps-Agiles-SDD-UX.md) |
| 11 | `Scrum-Guide/` | Material importado + PDF | 4 (+1 pdf) | 4 290 | sin `doc_id` · abril 2026 | [07](07_DevOps-Agiles-SDD-UX.md) |
| 12 | `SDD-Guide/` | Material importado (UTN FRP) | 4 | 835 | sin `doc_id` · 2026-04-06 | [07](07_DevOps-Agiles-SDD-UX.md) |
| 13 | `UX-UI-Guide/` | Material importado | 2 | 2 038 | sin `doc_id` · 2026-04-25 | [07](07_DevOps-Agiles-SDD-UX.md) |
| 14 | `Arquitectura/` | 3 guías importadas (.NET 9) | 3 | 2 559 | sin `doc_id` · abril 2026 | [08](08_Arquitectura-y-References.md) |
| 15 | `references/` | Insumos: agentes SDD, duplicados de 14, notas | 21 | 6 577 | `AG-xx` · 2026-04-03/04 | [08](08_Arquitectura-y-References.md) |

Totales: 232 `.md` (230 con contenido + `README.md` raíz y `Guides/README.md` vacíos) · 87 577
líneas · 3 `.yml` · 1 PDF · 217 bloques Mermaid. Líneas medidas con `wc -l` el 2026-09-12.

## Dos linajes dentro del corpus

| Linaje | Guías | Rasgos |
|---|---|---|
| **Guías propias con aparato común** (1–9) | Las cuatro estructuradas, ramas, dos prácticas, Actions, E2E | Frontmatter YAML con `doc_id`/`status`/`origin`/`confidence`/`last_review`/`traces`; marco de referencia (escenarios, contextos, actores); mapa conceptual; marcas de evidencia o niveles de autoridad; anexos con fuentes verificadas y pendientes declarados |
| **Material importado** (10–15) | DevOps, Scrum, SDD, UX-UI, Arquitectura, references | Encabezados «Documento / Versión / Fecha / Autor / Estado» y «Control de cambios»; provienen del proyecto *Motor DSL de Generación de Documentos* (`Ejemplo_IA_SDD_Template`, cátedra UTN FRP TUP Aplicada 2025) o de guías genéricas de abril de 2026; **no** comparten marco ni convenciones con las guías propias y sus enlaces relativos apuntan al árbol `docs/` de aquel proyecto |

Dentro del primer linaje hay a su vez dos sublinajes con `origin` distinto: las guías 1–4 declaran
`origin: ia-assisted` con `owner` = el título de la guía; las 5–9 declaran `origin: agente` con
`owner: Lab-GitFlow` o `Lab-E2E.WebBlazor.Documentacion` y usan marcas **[F]/[C]/[E]/[V]** en lugar
de «niveles de autoridad».

Las guías 1, 3 y 4 comparten el dominio de ejemplo (**sistema de reserva de salas**: salas,
reservas, usuarios, sedes) y se citan entre sí como «guía hermana»; la 2 usa un **sistema de
gestión de audiencias** distribuido en el borde. Las guías 5–9 forman el bloque «procedimiento del
equipo»: el modelo de ramas se practica sobre `Lab-GitFlow` con la aplicación de `Lab-E2E.WebBlazor`,
los workflows del anexo exigen el `e2e.yml` de esa aplicación, y la guía de Actions toma todos sus
ejemplos de doce workflows reales del workspace (`GitHub-Action-Guide.md`, Anexo F).

## Génesis (de dónde salió cada guía)

Los prompts viven en `Lab-Documentos.Documentacion/PROMPTs/`. Dos generaciones de carpetas conviven:
`PROMPTs/Guides/NN-*` (tool-prompts numerados, bloque ramas/Actions/E2E) y `PROMPTs/PROMPTs/Guia-De-Estudio/*`
(prompts de las cuatro guías grandes, sin trackear en git).

| Guía | Prompt generador (relativo a `PROMPTs/`) |
|---|---|
| Documentación técnica | `PROMPTs/Guia-De-Estudio/Generacion-Documentacion-Tecnica/Crear-Guia-de-Estudio-Documentacion-Tecnica.md` (+ `Inputs/Tipos-De-Documentacion-Tecnica.md`, el catálogo de 28 tipos) |
| Informe de solución | `PROMPTs/Guia-De-Estudio/Generacion-Documentacion-Informe-Despliegue/Generacion-Documentacion-Informe-Despliegue.md` |
| Organización y patrones de código | `PROMPTs/Guia-De-Estudio/Crear-Guia-Organizacion-Estilo-Patrones-Codigo/…` (hay una segunda carpeta `Organizacion-Estilo-Patrones-Codigo/` cuyo prompt está titulado «Rest API»: ver hallazgos) |
| REST API | `PROMPTs/Guia-De-Estudio/Organizacion-Estilo-Rest-API/Crear-Guia-de-Organizacion-Estilo-Rest-API.md` |
| Estándares de modelo de ramas | `Guides/01-Crear-Guia-Estudio-Modelo-Ramas/Guia-Estudio.md` (+ `Mejora-Continuar-Mesa-Evaluadora.md`, `INPUTs/Flujo-De-Trabajo-Ramas.md`, que es el origen del modelo adoptado) |
| GitHub Flow (práctica) | `Guides/02-Crear-Guia-GithubFlow/Crear-Guia-GithubFlow.md` y `Debate.md`; bitácora de una corrida real en `Guides/05-Crear-Practica-Interactiva-Practica-GitHubFlow/OUTPUTs/Experiencia-Ejemplo-GitHubFlow.md` (`GHF-EXP-01`) |
| GitHub Actions | `Guides/03-GitHub-Action/Guia-GitHub-Action-Estudio.md` |
| E2E | `Guides/04-Crear-E2E-Guide-Developer-Guide/Crear-E2E-Guide-Developer-Guide.md` |
| Mejoras posteriores | `Fixs/01..04-Mejoras-Documentacion*/` (ramas, GitFlow, GitHub Flow, estándares) |
| UX-UI (encargo), Test REST (encargo) | `Guides/06-Crear-UX-UI-Guide/` y `Guides/07-Crear-Test-Standard-APIRest-Guide/` — prompts sin salida en `Lab-Documentos` al indexar; el de 07 se llama `Crear-UX-UI-Guide.md` y se titula «GitFlow» |
| DevOps, Scrum, SDD, UX-UI, Arquitectura, references | Sin prompt en este repositorio: importados |

El `CHANGELOG.md` de `Lab-Documentos.Documentacion` registra las consolidaciones (ocho documentos
de ramas → `Estandares-Modelo-Ramas.md`; ocho escenarios → una guía práctica por modelo) y aclara
que **esas consolidaciones no volvieron a ejecutar ni verificar nada**: los estados de verificación
son los que ya estaban.

## Cómo entrar según lo que se busca

| Situación | Ruta |
|---|---|
| Tengo que producir o evaluar un documento técnico concreto | [01](01_Documentacion-Tecnica.md) → mapa por artefacto → plantilla del anexo del documento |
| Me piden «un documento que explique la solución» | [02](02_Informe-de-Solucion.md) → `99-Anexos/Plantilla-del-Informe.md` |
| Estoy armando o normalizando una solución .NET | [03](03_Organizacion-Codigo-NET.md) → tabla de entrada por decisión (30 preguntas) |
| Diseño, evoluciono o evalúo una API HTTP | [04](04_Diseno-REST-API.md) → familia según la pregunta |
| Necesito el procedimiento de ramas/PR/versiones del equipo | [05](05_Modelo-de-Ramas-y-Practicas.md) → `GF-GUIA` §6–§8 |
| Escribo o depuro un workflow, o monto E2E | [06](06_GitHub-Actions-y-E2E.md) |
| Busco DORA, SemVer, supply chain, Scrum/Jira, prompting SDD o UX | [07](07_DevOps-Agiles-SDD-UX.md) (leer las advertencias de vigencia) |
| Busco Clean Architecture aplicada, gateway, storage/video | [08](08_Arquitectura-y-References.md) |
| No sé qué significa una sigla o un prefijo | [09](09_Convenciones-y-Glosario.md) |

## Estado del repositorio

Comprobado con `git status` y `git log` el 2026-09-12:

| Hecho | Detalle |
|---|---|
| Último commit de `main` | `e1a39bf` (2026-08-26) «Merge pull request #4 from hdcm-dev/feature/107-filtro-por-provincia»: el repositorio **todavía es** la app Blazor `MovilidadUrbana` con su suite E2E (60 archivos trackeados: `.github/`, `src/`, `tests/`, `scripts/`, `Lab-E2E.WebBlazor.sln`, `pruebas.runsettings`) |
| Árbol de trabajo | Todo eso figura ` D` (borrado sin stagear); `README.md` figura ` M` (quedó vacío); `Guides/` figura `??` (sin trackear) |
| Interpretación | El repositorio está a mitad de una conversión de «laboratorio de GitFlow con app» a «corpus de guías». Nada de `Guides/` está publicado en GitHub al indexar. *(Interpretación; el hecho es el `git status`.)* |
| `Lab-Documentos.Documentacion` | Mismo cuadro: su `Guides/` figura ` D` (las guías se movieron acá), `PROMPTs/PROMPTs/` y varios `PROMPTs/Guides/NN-*` figuran `??`, y su `README.md` todavía se titula **«Lab-GitFlow.Documentacion»** y enlaza a `Guides/…` que ya no existen ahí |

## Hallazgos y divergencias

Hechos verificados sobre los archivos; la interpretación va aparte cuando corresponde.

### Estructura

- **H-01** `README.md` de la raíz y `Guides/README.md` están **vacíos** (0 bytes). No hay punto de
  entrada humano al corpus; esta ia-db lo suple para agentes.
- **H-02** `Organizacion-Estilo-Rest-API/README.md` está vacío y la guía **no tiene**
  `01-Mapa-Conceptual/`, `99-Anexos/Glosario.md` ni `99-Anexos/Listas-de-Verificacion.md`, aunque
  `MARCO-CONVENCIONES` y `MARCO-ESCENARIOS` los enlazan. Es la única guía estructurada sin mapa.
- **H-03** `Guides/Scrum-Guide/ Metodologias-Agiles-Jira-Guide.md` tiene un **espacio inicial en el
  nombre de archivo** (también en su encabezado `**Documento:**`). Rompe cualquier enlace o glob que
  no lo contemple.
- **H-04** `Guides/SDD-Guide/Spec-Driven Development-SDD.md` tiene un espacio en el nombre.
- **H-05** Los tres archivos de `references/arquitectura/` son **idénticos byte a byte** (`cmp`) a
  los de `Arquitectura/`: `guia-arquitectura-.net.md` = `Dot-NET-Arquitectura-Guide.md`,
  `guia-arquitectura-microservicios.md` = `Microservicios-Guide.md`,
  `guia-manejo-recursos.md` = `Manejo-Archivos-Guide.md`.
- **H-06** `Estandares-Modelo-Ramas-Guide/README.md` fue eliminado (CHANGELOG 2026-09-03) pero
  `GitFlow-Practice-Guide/Guia-Practica-GitFlow.md` sigue enlazándolo; el CHANGELOG lo registra
  como pendiente.

### Enlaces (script sobre 2 409 enlaces relativos; 36 archivos con al menos uno roto)

- **H-07** `Organizacion-Estilo-Rest-API/`: **14 destinos inexistentes** citados desde 23 archivos.
  Son nombres previos de documentos que existen con otro nombre: `Proteccion-y-Limites` →
  `Proteccion-de-la-Superficie`; `Resiliencia` → `Resiliencia-y-Reintentos`;
  `Serializacion-Con-System-Text-Json` y `Serializacion` → `Serializacion-y-Modelos`;
  `Consumo-de-APIs` → `Consumo-desde-Blazor-y-MAUI`; `Clientes-y-Pruebas-de-Contrato` →
  `Generacion-de-Clientes-y-Pruebas-de-Contrato`; `Especificacion-OpenAPI` → `OpenAPI`;
  `Diseno-Primero` → `Design-First-y-Code-First`; `Deprecacion` → `Deprecacion-y-Retiro`;
  `Comparativa` → `Comparativa-y-Criterios`; `Experiencia-del-Desarrollador` →
  `Experiencia-del-Consumidor`; `70-…/Errores-y-Problem-Details` → `40-…/Manejo-de-Errores`; más
  `Glosario.md` y `Listas-de-Verificacion.md` que no existen (H-02). *(La correspondencia es
  interpretación por nombre; el hecho es que el destino no existe.)*
- **H-08** `Documentacion-Informe-Despliegue/` enlaza `../../../../IA.Prompts/PromptFramework/Rules/Rule-Narrative-Voice.md`
  y `Rule-Dual-Audience.md`: rutas al framework de prompts que no resuelven desde este árbol.
- **H-09** `E2E-Guide/` enlaza `../../Lab-E2E.WebBlazor` (y `tests/MovilidadUrbana.E2ETests/`):
  presupone el laboratorio clonado como hermano de `Guides/`, cosa que no ocurre en este repositorio.
- **H-10** `Scrum-Guide/Caso-De-Estudio-1-Guide.md` enlaza `guia-de-estudio.md`; el archivo se
  llama `Estudio-Guide.md`.
- **H-11** `references/agentes-especialidades/*.md` enlazan `docs/00_contexto/…`, `../08_calidad_y_pruebas/…`,
  etc.: el árbol del Motor DSL, ausente acá. `README.md` de esa carpeta enlaza
  `../agentes-refinamiento-docs.md`, que está en `../refinamiento_docs/`.
- **H-12** `Documentacion-Tecnica/60-Desarrollo/Release-Notes.md` tiene un enlace con destino `…`
  (marcador). `Documentacion-Tecnica/README.md` afirma «ningún enlace roto»: es cierto para los
  enlaces internos de esa guía salvo este marcador.

### Contenido y vigencia

- **H-13** `Organizacion-Estilo-Rest-API/00-Marco-de-Referencia/Convenciones.md` tiene
  `last_review: AAAA-MM-DD` en su frontmatter (los otros 55 archivos dicen 2026-07-20).
- **H-14** El **modelo de ramas** difiere entre linajes: `GF-GUIA` §6 adopta tronco + `release/x.y`
  sin `develop` ni `homologacion` **[C]**; `DevOps-Guide/guia-flujo-trabajo-versionado.md` §1
  prescribe `main` + `homologacion` con flujo `issue → homologacion → main`; y
  `DevOps-Guide/marco-teorico.md` §6.7 registra esa misma prescripción como «deuda documental»
  incompatible con el GitHub Flow estricto (D3) del Motor DSL. Tres posiciones en el mismo corpus.
- **H-15** `Arquitectura/Dot-NET-Arquitectura-Guide.md` declara stack **.NET 9**; las guías
  propias usan .NET 10 (LTS) como referencia.
- **H-16** Las dos guías prácticas declaran que sus escenarios **no fueron ejecutados** en esa
  redacción (`GitHubFlow-Practice-Guide/README.md` «Estado de verificación»; CHANGELOG). La
  bitácora `GHF-EXP-01` de `Lab-Documentos.Documentacion/PROMPTs/Guides/05-…/OUTPUTs/` sí registra
  una corrida real de GitHub Flow sobre `Lab-E2E.WebBlazor.Base`.
- **H-17** `PROMPTs/PROMPTs/Guia-De-Estudio/Organizacion-Estilo-Patrones-Codigo/Crear-Guia-de-Organizacion-Estilo-Patrones-Codigo.md`
  se titula «Sobre el estandar Rest API en .NET»: nombre y contenido no coinciden. Y
  `PROMPTs/Guides/07-Crear-Test-Standard-APIRest-Guide/Crear-UX-UI-Guide.md` se titula «GitFlow».
- **H-18** `references/notas/tools.md` son atajos de teclado de VS Code para previsualizar
  Markdown; no es material de estudio.

Ninguno de estos hallazgos se corrigió: la ia-db no modifica el proyecto indexado.
