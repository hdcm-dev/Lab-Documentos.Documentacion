---
doc_id: EXP0002-EV-CACAD-E01
doc_type: evidencia
title: Ensayo E01 — veinte referencias de la guía del documentador rehechas en APA 7 en castellano
status: vigente
origin: agent
owner: comisión C-ACADEMICO
last_review: 2026-10-26
audience: [mesa, jurado, presidencia]
traces: [EXP0002-F016, Q44, Q40, Q07]
---

# Ensayo E01 — veinte referencias rehechas en APA 7 en castellano

## Índice

1. [Método](#1-método)
2. [Estado actual de las veinte citas](#2-estado-actual-de-las-veinte-citas)
3. [Las veinte referencias rehechas](#3-las-veinte-referencias-rehechas)
4. [Resultado](#4-resultado)

## 1. Método

- **Objeto.** Las veinte fuentes web de la guía `/LAB/Lab-Documentos/Lab-Documentos/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Sistema-Documentador-Tecnico-Guide.md` (Lab-Documentos `5d5c2b4`) listadas en su §12 (líneas 723-757), en el orden de `scripts/urls.tsv`.
- **Descarga.** `curl -sL -A "Mozilla/5.0"` de cada URL al directorio de ensayos (fuera del workspace), el 2026-10-26; nuevo control de estado HTTP a las 18:37 -03:00: 20/20 respondieron `200` (`E01b-citas-y-estado-http.txt`).
- **Metadatos.** `python3 -I scripts/meta.py <dir>` extrae `<title>`, `author`, `article:*`, `ms.date`, `ms.author` y `dateModified`. Autores de software: API de GitHub (`/users/xoofx` → «Alexandre Mutel»; `/orgs/dotnet` → «.NET Platform»); versiones: `/repos/<r>/releases/latest` (docfx `v2.81.0`, 2026-09-25; markdig `1.5.0`, 2026-10-24).
- **Criterio de completitud (cinco elementos de APA 7 para recursos web).** Autor (persona u organización), fecha (o «s. f.»), título, URL y, por la regla de la casa (`Rule-Evidences.md:25`), fecha de consulta. «s. f.» es una forma válida de APA, no un faltante.
- **Fecha.** Se usa sólo una fecha **visible** en la página («Last updated», `ms.date` publicado como metadato oficial de Microsoft Learn, fecha del artículo) o la de la versión del software. El `dateModified` de las páginas de Mintlify es un metadato no visible: se informa en nota y la referencia va con «s. f.» *[criterio propio, conservador]*.

## 2. Estado actual de las veinte citas

Columnas: **A** autor, **F** fecha de publicación, **T** título, **U** URL, **C** fecha de consulta localizable (en el texto o en el registro del §12). «sí*» = sólo en el registro del §12, no en el lugar de la cita.

| Id | Fuente | Líneas de la guía | A | F | T | U | C | Falta |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| R01 | OneSignal, *Create user* | 28, 723 | sí | no | no | sí | sí* | F, T |
| R02 | OneSignal, `llms.txt` | 94, 726 | sí | no | sí | sí | sí* | F |
| R03 | Mintlify, *Quickstart* | 140, 729 | sí | no | no | sí | sí* | F, T |
| R04 | Mintlify, *OpenAPI setup* | 84, 730 | sí | no | no | sí | sí | F, T |
| R05 | Write the Docs, *Docs as code* | 102, 731 | sí (org.; la persona no) | no | no | sí | sí | F, T |
| R06 | Procida, *Diátaxis* | 165, 732 | no | no | sí | sí | sí | A, F |
| R07 | Backstage, *What is Backstage?* | 248, 734 | sí | no | no | sí | sí* | F, T |
| R08 | Backstage, *TechDocs Documentation* | 248, 735 | sí | no | no | sí | sí* | F, T |
| R09 | Mintlify, *Authentication setup* | 234, 736 | sí | no | no | sí | sí* | F, T |
| R10 | Nygard, *Documenting Architecture Decisions* | 203, 737 | sí | sí | no | sí | sí* | T |
| R11 | Hruschka y Starke, *arc42 Template Overview* | 203, 738 | no | no | no | sí | sí* | A, F, T |
| R12 | OASIS, *Conditional processing (profiling)* | 234, 246, 739 | sí | no | no (sólo «§2.4.3») | sí | sí* | F, T |
| R13 | Mintlify, *Personalized content* | 236, 740 | sí | no | no | sí | sí* | F, T |
| R14 | Docusaurus, *Versioning* | 292, 627, 744 | sí | no | no | sí (fuente en `main`) | sí* | F, T |
| R15 | Microsoft, *Globalization and localization in ASP.NET Core* | 446, 751 | sí | no | no | sí | sí* | F, T |
| R16 | Docusaurus, *i18n - Tutorial* | 448, 753 | sí | no | no | sí | sí* | F, T |
| R17 | Microsoft, *Metadata for Microsoft Learn documentation* | 607, 755 | sí | no | no | sí | sí* | F, T |
| R18 | Lacan, *Keep a Changelog* 1.1.0 | 590, 757 | no | no | sí | sí | sí* | A, F |
| R19 | .NET Platform, *docfx* | 319, 745 | sí | no | sí | sí (API) | sí* | F, versión |
| R20 | Mutel, *Markdig* | 317, 745 | no | no | sí | sí (API) | sí* | A, F |

**Completas hoy: 0 de 20.** Falta el título en 15, el autor en 4 (más R05, donde la página firma una persona que la guía no nombra), la fecha en 19. La fecha de consulta está en el lugar de la cita sólo en 3 (R04, R05, R06); en las otras 17 hay que inferirla del encabezado del §12 por sección (`GUIA:719`).

## 3. Las veinte referencias rehechas

Todas consultadas el 2026-10-26. Ancla propuesta entre corchetes.

1. `[ref-onesignal-sf-create-user]` OneSignal. (s. f.). *Create user*. https://documentation.onesignal.com/reference/create-user (consultado el 2026-10-26). Nota: metadato `dateModified` 2026-07-09.
2. `[ref-onesignal-sf-llms]` OneSignal. (s. f.). *llms.txt* [Índice de la documentación para modelos de lenguaje]. https://documentation.onesignal.com/llms.txt (consultado el 2026-10-26).
3. `[ref-mintlify-sf-quickstart]` Mintlify. (s. f.). *Quickstart*. https://mintlify.com/docs/quickstart (consultado el 2026-10-26). Nota: `dateModified` 2026-10-24, posterior a la consulta de la guía (2026-09-16).
4. `[ref-mintlify-sf-openapi]` Mintlify. (s. f.). *OpenAPI setup*. https://mintlify.com/docs/api-playground/openapi-setup (consultado el 2026-10-26). Nota: `dateModified` 2026-10-13.
5. `[ref-holscher-sf]` Holscher, E., y comunidad Write the Docs. (s. f.). *Docs as code*. Write the Docs. https://www.writethedocs.org/guide/docs-as-code/ (consultado el 2026-10-26). La página declara «author: Eric Holscher & the Write the Docs community».
6. `[ref-procida-sf]` Procida, D. (s. f.). *Diátaxis*. https://diataxis.fr/ (consultado el 2026-10-26).
7. `[ref-backstage-sf-what]` Backstage Project Authors. (s. f.). *What is Backstage?* Backstage. https://backstage.io/docs/overview/what-is-backstage (consultado el 2026-10-26).
8. `[ref-backstage-sf-techdocs]` Backstage Project Authors. (s. f.). *TechDocs documentation*. Backstage. https://backstage.io/docs/features/techdocs/ (consultado el 2026-10-26).
9. `[ref-mintlify-sf-auth]` Mintlify. (s. f.). *Authentication setup*. https://mintlify.com/docs/deploy/authentication-setup (consultado el 2026-10-26). Nota: `dateModified` 2026-10-15.
10. `[ref-nygard-2011]` Nygard, M. (2011, 15 de noviembre). *Documenting architecture decisions*. Cognitect. https://www.cognitect.com/blog/2011/11/15/documenting-architecture-decisions (consultado el 2026-10-26).
11. `[ref-hruschka-starke-sf]` Hruschka, P., y Starke, G. (s. f.). *arc42 template overview*. arc42. https://arc42.org/overview (consultado el 2026-10-26).
12. `[ref-oasis-2015]` OASIS. (2015, 17 de diciembre). Conditional processing (profiling), §2.4.3. En *DITA Version 1.3. Part 1: Base Edition*. https://docs.oasis-open.org/dita/dita/v1.3/os/part1-base/archSpec/base/condproc.html (consultado el 2026-10-26). Observación de contenido: la página enumera `@audience`, `@deliveryTarget`, `@otherprops`, `@platform` y `@props`; `@product`, que la guía nombra (`GUIA:234`), no aparece en esa página.
13. `[ref-mintlify-sf-personalization]` Mintlify. (s. f.). *Personalized content*. https://mintlify.com/docs/deploy/personalization-setup (consultado el 2026-10-26). Nota: `dateModified` 2026-09-28.
14. `[ref-docusaurus-2026-versioning]` Docusaurus. (2026, 10 de julio). *Versioning*. https://docusaurus.io/docs/versioning (consultado el 2026-10-26). Observación: la frase «linking to immutable standalone deployment» que cita la guía (`GUIA:627`) está en la fuente de la rama `main` (`website/docs/guides/docs/versioning.mdx:330`), no en la página publicada de la versión vigente.
15. `[ref-microsoft-2025-localization]` Microsoft. (2025, 20 de junio). *Globalization and localization in ASP.NET Core*. Microsoft Learn. https://learn.microsoft.com/en-us/aspnet/core/fundamentals/localization (consultado el 2026-10-26).
16. `[ref-docusaurus-2026-i18n]` Docusaurus. (2026, 10 de julio). *i18n - Tutorial*. https://docusaurus.io/docs/i18n/tutorial (consultado el 2026-10-26).
17. `[ref-microsoft-2025-metadata]` Microsoft. (2025, 1 de mayo). *Metadata for Microsoft Learn documentation*. Microsoft Learn. https://learn.microsoft.com/en-us/contribute/content/metadata (consultado el 2026-10-26).
18. `[ref-lacan-sf]` Lacan, O. (s. f.). *Keep a Changelog* (versión 1.1.0). https://keepachangelog.com/en/1.1.0/ (consultado el 2026-10-26).
19. `[ref-dotnet-2026-docfx]` .NET Platform. (2026). *docfx* (versión v2.81.0) [Software]. GitHub. https://github.com/dotnet/docfx (consultado el 2026-10-26).
20. `[ref-mutel-2026-markdig]` Mutel, A. (2026). *Markdig* (versión 1.5.0) [Software]. GitHub. https://github.com/xoofx/markdig (consultado el 2026-10-26). La prueba de concepto de la guía usó la 0.45.0 (`GUIA:476`): la cita de software va con la versión **usada**, y la vigente sólo como dato.

## 4. Resultado

| Medida | Antes | Después |
| --- | --- | --- |
| Referencias con los cinco elementos | 0/20 | 20/20 |
| Con fecha «s. f.» (válida en APA) | — | 12/20 |
| Referencias con autor personal | 1 (R10, Nygard) | 6 (R05, R06, R10, R11, R18, R20: siete personas) |
| Que necesitan título descriptivo entre corchetes | — | 1 (R02) |
| Citas literales que siguen en la página publicada | — | 28/29 (`quotes.py` informa 26/29; R05 y R06 son falsos negativos del marcado HTML, verificados con el contexto extraído) |
| Páginas modificadas después de la consulta de la guía | — | 4 (R03, R04, R09, R13; por `dateModified`) |
| Observaciones de contenido al rehacer | — | 2 (R12 atributo no presente; R14 cita sólo en `main`) |

Lectura *[criterio propio]*: el costo de completar no está en el formato sino en **recuperar el título y el autor**, que la guía no registró en el momento de la consulta; con el método de este ensayo, 20 referencias se completaron con un solo pase de descarga y metadatos. Dos de veinte revelaron un problema de **contenido** que sólo aparece al rehacer la referencia: rehacer las citas es también una revisión técnica (CQ-01).
