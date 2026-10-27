---
doc_id: EXP0002-F0070
doc_type: informe
title: Informe del despacho I07 — complementos de industria (DORA, documentación viva, estilo, WCAG 2.2, 82079-1, i18n, anclas multi-repo)
status: vigente
origin: agent
owner: presidencia de la mesa de Replanteo y análisis DocAsCode
last_review: 2026-10-26
audience: [mesa, jurado, comisiones, presidencia, PO]
traces: [TP:30, TP:34, TP:36, C00:89, C00:167-179, C00:219, N02, N03, N04, N05, N08, R02, R03, R05, R06, I01, I02, I04, I07]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-26 |
| Autor | Investigador de industria, despacho I07 |
| Corrige | — |

# Informe I07: complementos de industria

Insumos leídos:

- C00 (H8, P2);
- N02, N05 (hallazgos del runner);
- R02, R03 §10, R05, R06;
- I01, I02 (Antora, Vale, submódulos);
- reglas de IA.SDD: `Rules-UX-UI-DX.md`, `Rules-Documentacion.md`, `Rules-Especificacion-Funcional.md`, `Rules-Calidad-Y-Pruebas.md`.

La bitácora de respaldo tiene las citas por línea y 38 fuentes con URL. Las cláusulas se leyeron sobre la muestra de la norma y las páginas sobre los PDF de DORA. Está en `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/OUTPUTs/Bitacoras/I07-Complementos-De-Industria.md`.

## Índice

1. [Qué se relevó](#1-qué-se-relevó)
2. [Hallazgos](#2-hallazgos)
3. [Propuesta por escalón](#3-propuesta-por-escalón)
4. [Excepciones a conocimientos](#4-excepciones-a-conocimientos)
5. [No verificado y huella](#5-no-verificado-y-huella)

## 1. Qué se relevó

Son los siete huecos de C00 H8 (`C00:167-179`). Todas las fuentes se consultaron el 2026-10-26 (I07 §13).

| Hueco | Fuentes primarias principales |
| --- | --- |
| (a) DORA | Informe 2021 (pp. 21-23), informe 2024 v.2024.3 (pp. 36-37, 63-64), página de capacidad *Documentation quality* |
| (b) Documentación viva | Cucumber BDD; Reqnroll (docs, *formatters*, v3.0.0 del 2025-08-21); fin de vida de SpecFlow (2024-12-31) |
| (c) Estilo y Vale | Google developer documentation style guide; Microsoft Writing Style Guide y *Localization Style Guides* (incluye Spanish Neutral); Vale (packages, spelling); `vale-action` |
| (d) WCAG 2.2 | W3C TR (versión 12 Dec 2024; Recomendación desde el 5 Oct 2023); axe-core; pa11y-ci |
| (e) 82079-1:2019 | Muestra pública iTeh: cl. 1 e índice (la ficha de ISO devolvió 403) |
| (f) i18n | Docusaurus (introducción y flujo Git), MkDocs, mkdocs-static-i18n, DocFX (`_lang`) |
| (g) Anclas multi-repo | Pro Git (submódulos), git-subtree, Renovate (git-submodules, regex, github-action), Dependabot (gitsubmodule, runners self-hosted), `repository_dispatch` (evento y REST), `GITHUB_TOKEN` |

## 2. Hallazgos

| ID | Hallazgo | Evidencia |
| --- | --- | --- |
| I07-H1 | DORA 2021: cerca del 25% tiene buena documentación. Quien la tiene es 2,4 veces más propenso a mejor desempeño SDO, 3,8 veces a aplicar prácticas de seguridad y 3,5 veces a aplicar SRE. Sus prácticas: documentar CU críticos, dueños, guías de actualización, doc dentro del ciclo, reconocimiento, guías de estilo y pruebas automáticas de muestras de código. Son correlaciones de encuesta | I07 §4.1; DORA 2021 pp. 21-23 |
| I07-H2 | DORA 2024: un 25% más de adopción de IA se asocia con un 7,5% más de calidad de documentación **percibida**. Agrega «Deleting out-of-date or redundant documentation» como práctica | I07 §4.1-4.2; DORA 2024 pp. 36-37, 64 |
| I07-H3 | En .NET la documentación viva es Reqnroll: SpecFlow murió el 2024-12-31 y LivingDoc era cerrado. Reqnroll v3 trae un *formatter* HTML que reemplaza a LivingDoc. Sólo necesita `dotnet test`, así que es compatible con el runner sin Docker. IA.SDD ya pide criterios BDD (`/IA/SDD/IA.SDD/SDD/Devs/Rules/Rules-Especificacion-Funcional.md:20`, `Rules-Calidad-Y-Pruebas.md:166`) | I07 §5 |
| I07-H4 | Las guías de Google y Microsoft son para inglés, y sus paquetes Vale también. Vale usa por defecto un diccionario en_US y admite Hunspell. Para español, Microsoft publica una *Spanish (Neutral) Localization Style Guide*. Google prescribe esta precedencia: proyecto, guía, terceros | I07 §6 |
| I07-H5 | IA.SDD ya fija WCAG 2.2 AA como piso (`/IA/SDD/IA.SDD/SDD/Devs/Rules/Rules-UX-UI-DX.md:27`, `:285`); falta extenderlo al sitio de documentación. Criterios clave: 1.1.1 (mermaid), 3.1.1 y 3.1.2 (idioma), 3.2.6 *Consistent Help* (nuevo; toca la ayuda por rol), 2.4.11 y 2.5.8 (nuevos). axe-core detecta en promedio el 57% de los problemas | I07 §7 |
| I07-H6 | 82079-1 alcanza «application software» y la «online help». Trae un proceso de gestión de información con idiomas (6.2.4), sostenimiento (6.2.6) y gestión de configuración (6.2.10); competencias, incluidas las de traductores (cl. 10); y un Anexo A de evaluación: completitud, *desk check* y eficacia empírica | I07 §8 |
| I07-H7 | Ningún generador relevado detecta traducciones desactualizadas: Docusaurus lo declara responsabilidad del autor. El validador `translation_of` de la guía es una compuerta propia, hoy no implementada (`R02:187`) | I07 §9 |
| I07-H8 | La Renovate Action corre dentro de Docker, así que no es viable en `i7infra-dev`, que no tiene `docker.sock` (`N05:81`). Su gestor de submódulos está en beta. `GITHUB_TOKEN` no cruza repos, y `repository_dispatch` exige un PAT o una GitHub App (payload de hasta 10 propiedades y 64 KB) | I07 §10 |

## 3. Propuesta por escalón

Todo lo de esta sección es criterio propio, sobre la evidencia de §2. La mesa decide.

1. **Mini demo (MovilidadUrbana.MAUI + workflow en `[self-hosted, i7infra-dev]` + guía).**
   - Frontmatter con `owner` y `last_review` obligatorios (H1).
   - Vale con estilo propio en español y sólo reglas `error`; paquetes Google o Microsoft sólo sobre contenido en inglés (H4).
   - Si hay sitio publicado: `lang` correcto y axe/pa11y en AA, más una revisión manual en la lista VER-* (H5).
   - La guía suma los siete temas como referencias de industria, en las secciones de N08 y N05.
2. **Piloto Geometría.**
   - Escenarios Reqnroll con tag `@CU-100NN`, que trazan a los CU de pantalla (`R06:193`), y reporte HTML como artefacto (H3).
   - Validador de `translation_of` con hash o versión de la fuente (H7).
   - Ancla de la ia-db por tag, actualizada por `repository_dispatch` → PR (H8).
3. **SDD-B y orquestadores.**
   - El mismo patrón tag → dispatch → PR hacia el repo de documentación, dentro del ciclo de conformación automática de PR (H8).
   - El Anexo A de 82079-1 como plantilla de la compuerta de dictamen de cada escalón (H6).
   - DORA como justificación de las reglas de dueño y borrado (H1, H2).

## 4. Excepciones a conocimientos

**Ninguna.** La única tensión es entre «Be brief» de Microsoft y §1.4 «Explicar, no solo describir» de `/IA/SDD/IA.SDD/SDD/Devs/Rules/Rules-Documentacion.md:230-245`. Se resuelve con la precedencia de Google: el estilo del proyecto prevalece. Impacto operativo: el estilo Vale no incluye reglas de brevedad contrarias a §1.4.

**Aparte, una regla del workspace que no es conocimiento:** el patrón de workflows «sin `container:`» (`R03:395`) descarta la Renovate Action.

## 5. No verificado y huella

**No verificado** (detalle en I07 §14):

- ninguna herramienta se ensayó en el runner;
- 82079-1: sólo la muestra pública, sin las cláusulas «shall»;
- DORA 2022 y 2025 sin leer en PDF;
- Hunspell `es` en Vale;
- persistencia del *tool cache* de `vale-action` en un runner efímero;
- la ref que sigue Dependabot `gitsubmodule`;
- el permiso de grano fino de `repository_dispatch`;
- soporte i18n comunitario de DocFX;
- separación en `net10.0` de la lógica de MovilidadUrbana.MAUI (`R05:68`).

**Huella.**

- Escrito: la bitácora I07 y este folio.
- Intermedios: `fc-work/docascode/I07/`, fuera del workspace, con tres PDF, sus extracciones de texto y dos HTML. Se borró entero al terminar.
- Sin contenedores, commits, push ni PR.
