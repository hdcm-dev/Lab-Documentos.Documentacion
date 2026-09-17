# 09 — Convenciones compartidas y glosario cruzado

> **Propósito**: lo que hay que saber antes de leer **cualquier** guía del corpus: cómo se
> identifican los documentos, cómo se marca la evidencia, por qué los mismos prefijos significan
> cosas distintas en cada guía, y un glosario mínimo de términos que cruzan guías.
> **Fuente primaria**: `Documentacion-Tecnica/00-Marco-de-Referencia/Convenciones.md`
> (`MARCO-CONVENCIONES`), `Organizacion-Estilo-Rest-API/00-Marco-de-Referencia/Convenciones.md`,
> `Estandares-Modelo-Ramas.md` §Convención de marcas y Anexo A, los `99-Anexos/Glosario.md` de
> cada guía estructurada.

## Frontmatter obligatorio (guías 1–4; variantes en 5–9)

```yaml
---
doc_id: DOC-SAD
doc_type: tema | marco-de-referencia | familia | mapa | anexo | indice
title: Software Architecture Document
status: vigente | borrador | obsoleto
origin: human | ia-assisted | ia-generated
confidence: alta | media | baja      # obligatorio si origin != human
owner: <actor responsable>
last_review: AAAA-MM-DD
audience: [humano, agente]
traces: [IDs de documentos relacionados]
---
```

`origin` y `confidence` son «el mecanismo por el cual un lector distingue lo verificado de lo
inferido». Las guías 5–9 usan el mismo bloque con `origin: agente`, `doc_type` propios
(`documento-tematico`, `guia-practica`, `guia-de-estudio`, `guia-rapida`, `anexo`), `owner`
por repositorio (`Lab-GitFlow`, `Lab-E2E.WebBlazor.Documentacion`) y `audience` por rol
(`[desarrollo, qa, devops, po, seguridad, autoridad-de-cambio]`). `GF-GUIA` agrega `consolida:`
con los IDs que absorbió. El material importado (guías 10–15) **no** tiene frontmatter.

## Identificadores

Los enlaces apuntan al `doc_id`, no a la ruta: «los archivos se mueven, los IDs no».

| Prefijo | Aplica a | Guías |
|---|---|---|
| `ESC-`, `CTX-`, `ACT-` | Escenarios, contextos, actores del marco | 1, 2, 3, 4, E2E (con dos dígitos: `ESC-01`) |
| `E-`, `C-`, `A-` | Escenarios, contextos, actores | Ramas (`E-01..08`, `C-1..4`, `A-PO`…), Actions (`E-01..10`, `C-1..5`, `A-DEV`…) |
| `FAM-` | Familias temáticas | 1, 2, 3, 4 |
| `DOC-` | Documento por tipo de documentación | 1 |
| `TEM-` | Documento temático | 2, 3, 4 |
| `MET-`, `ARQ-` | Métodos ágiles, modelos de arquitectura | 1 |
| `MARCO-`, `MAPA-CONCEPTUAL`, `GUIA-INDICE`, `ANEXO-` | Marco, mapa, índice, anexos | 1, 2, 3, 4 |
| `HUE-`, `VER-` | Huecos y verificaciones pendientes | 1 |
| `GF-`, `GHF-`, `GHA-`, `E2E-` | Documentos de ramas, GitHub Flow, Actions, E2E | 5, 6, 7, 8, 9 |
| `N-`, `G-`, `F-`, `O-`, `P-` | Fuentes por nivel (ver abajo) | 2, 3, 4 |
| `W-`, `IDX-`, `OBS-` | Workflows del workspace, índices ia-db consultados, observaciones | 8 (Actions) |
| `AG-` | Agentes por especialidad SDD | references |
| `RF-`, `RNF-`, `RN-`, `CU-`, `NB-`, `WF-`, `SA-`, `D1..D7` | Prefijos de la industria o del proyecto de origen usados **dentro de ejemplos** | varias |

## Los ejes del marco cambian por guía

El mismo prefijo nombra conjuntos distintos. Antes de citar `ESC-2` o `ACT-03` hay que decir de qué guía.

| Guía | Escenarios | Contextos | Actores |
|---|---|---|---|
| Documentación técnica | `ESC-1` nuevo · `2` migración · `3` evaluación con código · `4` evaluación desde afuera | `CTX-1` web · `2` backend · `3` fullstack | `ACT-01..10` (PO, analista, arquitecto, dev, QA, DevOps, seguridad, UX, writer, **agente IA**) |
| Informe de solución | `ESC-1` en diseño · `2` construida · `3` en evolución · `4` ajena | `CTX-1` monolito · `2` cliente-servidor · `3` borde · `4` servicios en infra controlada | `ACT-01..08` (arquitecto, dev/líder, solicitante, despliegue, analista/PO, patrocinador, redactor, auditor) |
| Organización de código | `ESC-1` nuevo · `2` evolución estructural · `3` normalización · `4` código ajeno | `CTX-1` web/cliente · `2` servicio/API · `3` biblioteca · `4` distribuida | `ACT-01..06` (arquitecto, dev, responsable técnico, revisor, DevOps, mantenedor de biblioteca) |
| REST | `ESC-1` API nueva · `2` exposición/migración · `3` evolución en producción · `4` API ajena (`4b` sondeo) | `CTX-1` pública · `2` interna · `3` backend propio · `4` integración externa | `ACT-01..07` (arquitecto de API, productor, consumidor, QA, analista, PO, **seguridad con veto**) |
| Ramas | `E-01..08` (funcionalidad, defecto pre-release, corte, estabilización, emergencia, demo, mantenimiento, rechazo) | `C-1..4` (sin/con release abierta, producción comprometida, ≥3 versiones vivas) | `A-PO`, `A-DEV`, `A-REV`, `A-QA`, `A-OPS`, `A-SEC`, `A-AUT` |
| Actions | `E-01..10` (PR, principal, puertas, NuGet, FTP, contenedor, móvil, release, entorno, programada) | `C-1..5` (runner alojado/propio, repo público/privado, plataforma ≠ runner) | `A-DEV`, `A-QA`, `A-DEVOPS`, `A-PO`, `A-SEC` |
| E2E | `ESC-01..05` (pantalla nueva, PR, intermitente, despliegue, regresión de fondo) | `CTX-01..04` (dev, CI, desplegado, móvil) | `ACT-01..04` (dev, QA, DevOps, PO/autoridad) |

Las guías REST e Informe traen tablas de correspondencia con los ejes genéricos de la guía madre
(`Escenarios.md` §Correspondencia…).

## Cómo se marca la evidencia

### Niveles de autoridad (guías 2, 3, 4)

| Nivel | Prefijo de fuente | Cómo se cita |
|---|---|---|
| Normativo (RFC, OpenAPI, OASIS, ISO citada por designación, Microsoft Learn) | `N-xx` | Identificador y sección exacta: «`N-01` §9.2.2» |
| Guía / marco de organización (Microsoft, Google, Zalando, GOV.UK, adidas; arc42, C4, RUP) | `G-xx` | Se nombra la organización; vale para quien la adopta |
| Convención de facto (drafts, specs comunitarias, práctica dominante) | `F-xx` | Se declara como convención y se apunta la evidencia `P-xx` |
| Obras de referencia (Fielding, Evans, Fowler, Martin…) | `O-xx` | Origen verificable de un concepto, no autoridad |
| Evidencia de plataformas (Stripe, GitHub, Jira…) | `P-xx` | Prueba de qué se hace, jamás de qué corresponde |
| **Criterio propio** | — | Fórmula «esta guía recomienda»; discutible |

La guía de código usa tres niveles (`N-`, `F-`, `O-`); la de Informe cinco; la REST cinco más la
sección «documentos obsoletos que se siguen citando».

### Marcas inline (guías 5–9)

| Marca | Significado |
|---|---|
| **[F: ID]** | Fundamentada en fuente externa listada en el Anexo E del documento |
| **[C]** | Convención del equipo: discutible y cambiable |
| **[E: qué/fecha]** | Comprobado ejecutando o leyendo algo en el workspace, con fecha o ruta |
| **[V]** (solo E2E) | Solo validación de sintaxis (YAML), sin ejecución |

Principio común: «un documento de proceso pierde autoridad cuando presenta preferencias del autor
como si fueran estándares de la industria».

## Estructura de un documento temático (guías 1–4)

1 Resumen ejecutivo (prosa) · 2 Definición (qué es, qué no es, con qué se confunde) · 3 Aplicación
por escenario × contexto · 4 Ejemplos concretos con datos · 5 Preguntas guía · 6 Criterios de
calidad y antipatrones · 7 Anexo: plantilla comentada. Regla «no duplicar»: cada tema vive en un
solo documento y los demás lo referencian; los README de familia de la guía REST fijan
explícitamente esos repartos de frontera.

## Glosario cruzado (términos que aparecen en más de una guía)

| Término | Definición canónica | Dónde |
|---|---|---|
| Escenario | Situación de partida con disparador reconocible y final verificable; determina si la documentación decide, describe o infiere | Glosarios de 1 y de ramas |
| Contexto | Lo que cambia la respuesta correcta dentro de un mismo escenario | Ramas Anexo A; guías 1–4 |
| Actor | Rol definido por lo que **decide** (y lo que no), no por el cargo | Todas las guías con marco |
| Familia | Agrupación de documentos que responden la misma pregunta | Guías 1–4 |
| Artefacto (documental) | Documento concreto con propósito, dueño y audiencia | Guía 1 |
| Artefacto (de build) | Resultado compilado y versionado; lo que se despliega; nunca se rehace por ambiente | Ramas §7.1; UML `N-07` en Informe |
| Ambiente | Infraestructura donde corre un artefacto; **no es una rama** | Ramas §7.1 |
| Promoción | Mover el mismo artefacto ya construido de un ambiente al siguiente | Ramas §7.5 |
| Build hermético | Insensible a la máquina que lo ejecuta; dos personas obtienen el mismo resultado | Ramas §7.5; DevOps §7.6 «determinismo» |
| Tag / candidata / demostración | Puntero inmutable `v1.4.0` / `v1.4.0-rc2` / `v1.5.0-demo.3` [C] | Ramas §7.3 |
| Tronco / rama corta / rama de release | `main` integrable siempre / vive ≤ 2 días, >7 incumple / ventana de estabilización desde un punto del tronco | Ramas §6 |
| Puerta (gate) | Verificación cuyo fallo bloquea el paso al siguiente stage del pipeline | Actions §1.4; DevOps §7.4 (DoR/DoD) |
| Workflow reutilizable | Workflow con `workflow_call`, inputs y outputs, invocado desde otro | Actions §6.1; E2E §8 |
| `data-testid` | Contrato entre la interfaz y la prueba E2E: el localizador estable | E2E §6.2; Quick-Guide §2.1 |
| Layer / Tier | Capa lógica de código / unidad de despliegue físico | Código, glosario |
| Proyecto / Proceso | `.csproj` que se compila / unidad que se ejecuta; ejes independientes | Código, `TEM-TOPO` |
| Monolito distribuido | Diagnóstico (no categoría formal): sistema desordenado partido en servicios | Código `TEM-MICRO` |
| Nivel 2 de Richardson | Recursos + métodos + códigos HTTP, sin hipermedia; donde llegan casi todas las guías corporativas | REST `TEM-RMM` |
| Informe de solución | Documento transversal (arquitectura + despliegue + requisitos) orientado a una decisión | Informe `TEM-QUE-ES` |
| Vista / viewpoint / concern / stakeholder | Vocabulario de ISO/IEC/IEEE 42010 (`N-01` del Informe) | Informe, glosario |
| Spec-First / Spec-Anchored / Spec-as-Source | Los tres niveles de SDD | SDD-Guide; `DOC-SDD`; `TEM-SDD` |
| RFC / ADR | Instrumento para decidir / registro de lo decidido | Código, glosario; `DOC-RFC`, `DOC-ADR` |
| Doble audiencia | Documento que sirve a la vez a una persona y a un agente que extrae datos | Guía 1, glosario; `audience: [humano, agente]` |

Los glosarios completos: `Documentacion-Tecnica/99-Anexos/Glosario.md`,
`Documentacion-Informe-Despliegue/99-Anexos/Glosario.md` (con fuente por término),
`Organizacion-Estilo-Patrones-Codigo/99-Anexos/Glosario.md` (con «pares que se confunden»),
`Estandares-Modelo-Ramas.md` Anexo A, `GitHub-Action-Guide.md` Anexo A, `Beginner-Guide.md`
Anexo D, `UX-UI-Guide.md` Apéndice A. La guía REST **no tiene glosario** (H-02).
