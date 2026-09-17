# 01 — Guía de estudio: Documentación técnica

> **Propósito**: qué tipos de documentación técnica existen (28 del catálogo), qué problema
> resuelve cada uno, cuál producir según el escenario y cómo distinguir una versión buena de una
> pobre. Cubre `Guides/Documentacion-Tecnica/` (59 documentos, 20 700 líneas, 87 diagramas Mermaid).
> **Fuente primaria**: `Guides/Documentacion-Tecnica/README.md` (`GUIA-INDICE`, `last_review`
> 2026-07-18) y `01-Mapa-Conceptual/Mapa-Conceptual.md`.

## En una pantalla

- Es la guía **madre** del corpus: fija el aparato (marco → mapa → familias → anexos) y las
  convenciones de frontmatter e identificadores que las otras tres guías estructuradas reutilizan
  (`00-Marco-de-Referencia/Convenciones.md`).
- Dominio de ejemplo: **sistema de reserva de salas**; tecnologías de vocabulario: .NET/C#, Blazor
  *interactive server*, ASP.NET MVC, .NET MAUI con MVVM. No enseña esas tecnologías.
- Cada documento temático cierra con **su plantilla comentada**; no hay plantillas centralizadas.
- Las normas ISO/IEC/IEEE se citan por designación e idea, nunca por texto (licencia).

## Marco de referencia (`00-Marco-de-Referencia/`)

| Eje | Valores | Archivo |
|---|---|---|
| Escenarios `ESC-` | `ESC-1` desarrollo nuevo · `ESC-2` migración a otro lenguaje/plataforma · `ESC-3` evaluación con acceso al código · `ESC-4` evaluación solo desde afuera | `Escenarios.md` |
| Contextos `CTX-` | `CTX-1` web y cliente interactivo · `CTX-2` backend y servicios · `CTX-3` fullstack | `Contextos.md` |
| Actores `ACT-` | `ACT-01` Product Owner · `02` Analista funcional · `03` Arquitecto · `04` Desarrollador · `05` QA · `06` DevOps/SRE · `07` Seguridad · `08` UX/UI · `09` Technical Writer · `10` Agente de IA (produce borradores, no decide) | `Actores.md` (incluye matriz de responsabilidad) |
| Convenciones | Prefijos de ID, frontmatter obligatorio, estructura de documento temático en 7 secciones, estilo, «no duplicar» | `Convenciones.md` |

`ESC-2` (migración) es el escenario que la guía señala como de **mayor riesgo documental**.

## Mapa conceptual (`01-Mapa-Conceptual/Mapa-Conceptual.md`)

Tres tablas de entrada —por escenario, por contexto, por artefacto— más los cruces
escenario × familia y actor × familia. Es la entrada para «resolver algo concreto»: ubicar el
artefacto, abrir su documento, trabajar con la plantilla de su anexo.

## Las siete familias documentales

| Familia | Pregunta | `doc_id` de los documentos (carpeta) |
|---|---|---|
| 1 Visión `FAM-VIS` | ¿Qué queremos construir? | `DOC-VISION`, `DOC-BRD`, `DOC-PRD`, `DOC-ROADMAP` (`10-Vision/`) |
| 2 Análisis `FAM-ANA` | ¿Qué debe hacer el sistema? | `DOC-SRS` (incluye casos de uso y reglas de negocio), `DOC-DOMINIO` (`20-Analisis/`) |
| 3 Arquitectura `FAM-ARQ` | ¿Cómo estará organizado? | `DOC-SAD` (incluye diagramas y despliegue), `DOC-HLD`, `DOC-ADR`, `DOC-SECARQ`, `DOC-THREAT`, `DOC-RFC` (`30-Arquitectura/`) |
| 4 Diseño `FAM-DIS` | ¿Cómo se implementa cada componente? | `DOC-LLD` (incluye UML y contratos internos), `DOC-DATOS`, `DOC-API`, `DOC-INTEGRACION` (`40-Diseno/`) |
| 5 Operativa `FAM-OPE` | ¿Cómo se instala, mantiene y opera? | `DOC-INSTALL`, `DOC-DEPLOY`, `DOC-OPERACION` (incluye DR), `DOC-ADMIN`, `DOC-RUNBOOK`, `DOC-POSTMORTEM` (`50-Operativa/`) |
| 6 Desarrollo `FAM-DEV` | ¿Cómo trabajamos sobre el proyecto? | `DOC-DEVGUIDE` (incluye coding standards, git workflow, CI/CD), `DOC-TESTPLAN`, `DOC-TESTCASES`, `DOC-RELEASE`, `DOC-CHANGELOG` (`60-Desarrollo/`) |
| 7 Usuarios `FAM-USR` | ¿Cómo se utiliza el sistema? | `DOC-MANUAL` (incluye tutoriales, FAQ, guías rápidas) (`70-Usuarios/`) |

Cada familia tiene su `README.md` (índice de familia). Los artefactos «menores» del catálogo
(casos de uso, reglas de negocio, coding standards, git workflow, CI/CD, DR, tutoriales, FAQ,
guías rápidas) son **secciones** dentro del documento que los contiene, no documentos propios.

### Estructura fija de cada documento temático

1. Resumen ejecutivo · 2. Definición (qué es, qué no es, con qué se confunde) · 3. Aplicación por
escenario (`ESC-1..4` × `CTX-1..3`) · 4. Ejemplos concretos (reserva de salas) · 5. Preguntas
guía · 6. Criterios de calidad y antipatrones · 7. Anexo: plantilla comentada.
Ejemplo verificado: `30-Arquitectura/SAD.md` sigue ese orden y su plantilla tiene 12 secciones
(introducción, restricciones, contexto, estrategia, vistas de bloques/ejecución/despliegue,
conceptos transversales, decisiones, escenarios de calidad, riesgos, glosario).

## Transversales y series

| Serie | Carpeta | Documentos | Ángulo |
|---|---|---|---|
| Métodos ágiles `MET-` | `80-Metodos-Agiles/` | `MET-MANIFIESTO`, `MET-SCRUM`, `MET-KANBAN`, `MET-CANVAS`, `MET-COMPARATIVA` (+ README `MET-INDICE`) | Documental: qué produce, exige y elimina cada método |
| Modelos de arquitectura `ARQ-` | `90-Modelos-de-Arquitectura/` | `ARQ-CS`, `ARQ-CAPAS`, `ARQ-MONO`, `ARQ-HEX`, `ARQ-MICRO`, `ARQ-COMPARATIVA` (+ README `ARQ-INDICE`) | El mismo sistema de reservas modelado bajo los cinco; qué documentación exige cada uno |
| Transversales | `95-Transversales/` | `DOC-UX` (UX, UI y flujo de usuario), `DOC-SDD` (Spec-Driven Development: la especificación como fuente de verdad para generación asistida) | No agregan artefactos; cambian cuáles se exigen |

## Anexos (`99-Anexos/`)

| Archivo | `doc_id` | Contenido |
|---|---|---|
| `Glosario.md` | `ANEXO-GLOSARIO` | Término canónico, definición, alias |
| `Revision-de-Consistencia.md` | `ANEXO-REVISION` | Qué se verificó, defectos corregidos, decisiones de criterio propio, huecos, cómo mantener la guía consistente. **Leer antes de extender la guía** |
| `Pendientes.md` | `ANEXO-PENDIENTES` | Backlog `HUE-01..07` y `VER-01..02` (ver abajo) |

### Pendientes registrados (`Pendientes.md`)

| ID | Prioridad | Hueco |
|---|---|---|
| `HUE-01` | 1 disperso | Métricas de ingeniería (DORA, flujo): repartidas entre Developer Guide, Test Plan y Kanban |
| `HUE-02` | 1 disperso | Gobierno documental (propiedad, revisión, retiro); el más relevante: la guía enseña a producir y evaluar, no a mantener viva |
| `HUE-03` | 2 sin dueño | Guía de transición para migraciones (`ESC-2`), sin `doc_id` propio |
| `HUE-04` | 2 sin dueño | Catálogo de errores de API traducido a mensajes de interfaz |
| `HUE-05` | 3 no cubierto | Arquitecturas orientadas a eventos y CQRS (candidato más fuerte a incorporarse) |
| `HUE-06`, `HUE-07` | 3 no cubierto | Estimación contractual; Kano/story mapping (son método, no artefacto) |
| `VER-01`, `VER-02` | 4 verificación | Revisión 2023 de ISO/IEC 25010; normas ISO/IEC/IEEE citadas sin texto por licencia |

## Rutas de lectura

Cinco tramos (`README.md` §Ruta): 1 marco y mapa (**único obligatorio**) → 2 familias 1–2
(frontera PRD ↔ SRS) → 3 familias 3–4 (orden de rendimiento decreciente: SAD, ADR, LLD, datos,
API) → 4 familias 5–7 (Runbook y Postmortem se leen bajo presión) → 5 métodos, modelos y
transversales. Rutas por rol en la tabla «Rutas alternativas por rol» del README
(p. ej. QA `ACT-05`: tramo 1 → SRS → Test Plan → Test Cases → Postmortem).

## Relación con las otras guías

- `Documentacion-Informe-Despliegue/` es la **guía hermana** que enseña a componer SAD, SRS,
  Deployment Guide y ADR en un informe único → [02](02_Informe-de-Solucion.md).
- `Organizacion-Estilo-Patrones-Codigo/` comparte dominio de ejemplo y convenciones → [03](03_Organizacion-Codigo-NET.md).
- `DOC-SDD` (transversal) dialoga con `SDD-Guide/` y con `TEM-SDD` de la guía REST → [07](07_DevOps-Agiles-SDD-UX.md), [04](04_Diseno-REST-API.md).
