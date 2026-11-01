---
doc_id: DB-R02-00
doc_type: bitacora-plan
title: Plan de la reedición DocsAsCode (prompt 02 de la guía 14)
status: vigente
origin: agent
confidence: alta en la coordinación (respuesta de FRAMEWORK MAUI del 2026-11-01); media en el plan (lo ajusta la mesa)
owner: presidencia de la reedición DocsAsCode
last_review: 2026-11-01
audience: [PO, presidencia, mesa, editores, bitacorista]
traces: [DB00, EXP0003-F001]
---

# 00 — Plan de la reedición DocsAsCode

## Índice

1. [Pedido](#1-pedido)
2. [Productos](#2-productos)
3. [Núcleos conceptuales](#3-núcleos-conceptuales)
4. [Fases](#4-fases)
5. [Coordinación con FRAMEWORK MAUI](#5-coordinación-con-framework-maui)
6. [Pruebas](#6-pruebas)
7. [Público y privado](#7-público-y-privado)
8. [Desvíos del prompt declarados](#8-desvíos-del-prompt-declarados)

## 1. Pedido

El prompt es `PROMPTs/Guides/14-Sistema-De-Documentador-Tecnico/02-Ajuste-Coherencia-Reedicion-Documentacion.md`.
Se invocó con ultracode el 2026-11-01.

El PO agregó en el chat del 2026-11-01:

- Sumar los ajustes de coherencia pendientes de la corrida anterior: onda 8 sin bitácora y folio del cambio de decisión
  «No reescribir».
- Correr las pruebas en el equipo de pruebas o donde haya recursos.
- Coordinar con la sesión FRAMEWORK MAUI para que los PR no se pisen.

## 2. Productos

| # | Producto | Repositorio | Ruta |
|---|---|---|---|
| P1 | Libro unificado, autocontenido y con índice | Lab-Documentos (público) | `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/DocsAsCode-Developer-Guide.md` |
| P2 | Conocimiento de especificación | Lab-Documentos (público) | `…/Sistema-De-Documentacion-E-Integracion/Conocimientos/knowledge-DocsAsCode-Designing-Specification.md` |
| P3 | Ajustes de coherencia del cuerpo SDEI y de sus ejemplos | Lab-Documentos | `…/Sistema-De-Documentacion-E-Integracion/**` |
| P4 | Ensayo del conocimiento sobre Geometría y ejemplos enriquecidos | Lab-Geometria.Documentacion (público) y Lab-Documentos | lo fija la mesa |
| P5 | Ensayo del conocimiento sobre el servicio privado de notificaciones | su repositorio de documentación (privado) | lo fija la mesa |
| P6 | Expediente 0003, bitácoras por núcleo y cohesión | Lab-Documentos.Documentacion | `PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/OUTPUTs/Expedientes/0003-…` y esta carpeta |
| P7 | Ajustes de coherencia de la corrida anterior | Lab-Documentos.Documentacion | bitácora 16 (onda 8), índice `00`, folio 261 del expediente 0002 |

## 3. Núcleos conceptuales

Esta es la segmentación preliminar. La fase 1 la valida o la corrige, y cada núcleo tiene su bitácora `Nucleo-Nx.md`.

| Núcleo | Eje | Depende de |
|---|---|---|
| N1 | Coherencia del cuerpo SDEI con sus ejemplos y su demo | — |
| N2 | Arquitectura del libro: fundamentos, partes y mapa de fuente a capítulo | N1, N6 |
| N3 | Conocimiento de especificación: forma, alcance y prueba de reproducción | N2 |
| N4 | Aplicación a Geometría (público) | N3 |
| N5 | Aplicación al servicio privado de notificaciones | N3 |
| N6 | Industria: estándares, tendencias y casos con fuente verificable | — |
| N7 | Gobierno: mesa, expediente, PR coordinados, pruebas en el equipo de pruebas | todos |

La cohesión global vive en `01-Cohesion-Global.md`.

## 4. Fases

Cada fase es un workflow propio, y la presidencia lee el resultado antes de abrir la siguiente.

1. **Relevamiento por núcleos.** Lectores en paralelo, a ciegas entre sí, y una crítica de cohesión. En paralelo corre el
   asiento de los ajustes de coherencia de la corrida anterior (P7).
2. **Mesa.** Se convoca según `Knowledge-Mesa-De-Expertos-A-Pedido` y `Knowledge-Mesa-Consulta-A-Un-Tercero`.
   - Panel: analistas de sistemas, arquitectos MAUI .NET, análisis de decisiones, documentación técnica de usuario y de
     sistemas, académicos de edición bibliográfica.
   - Comisiones a ciegas, análisis de decisiones, refutación y jurado.
   - La propuesta mejor fundada queda aprobada (delegación del PO del 2026-09-14).
3. **Redacción.** El libro se escribe por partes, con un núcleo de anclas e índice al cierre. Se redacta el conocimiento
   de especificación.
4. **Ensayos.** Se aplica el conocimiento a Geometría y al servicio privado: la prueba de reproducción la hace un agente
   sin contexto. Las correcciones vuelven al conocimiento y al libro.
5. **Rondas editoriales** sobre el libro, una por intervención:
   1. edición de contenido;
   2. edición académica;
   3. corrección de estilo;
   4. corrección ortotipográfica;
   5. diseño editorial;
   6. corrección de pruebas, con verificación adversarial.
6. **Integración y entrega.** PRs por conformación automática y compuerta final con evidencia.

## 5. Coordinación con FRAMEWORK MAUI

Acordado el 2026-11-01; FRAMEWORK MAUI lo aceptó sin cambios. Lo asienta la constancia `002` del expediente 0003.

- **Territorios disjuntos.**
  - DocsAsCode: `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/**` en LD; el expediente 0003 y esta
    carpeta en LDD.
  - FRAMEWORK MAUI: `Concepts/Framework-Concept/**`, `PROMPTs/Concepts/**` y sus expedientes.
- **Archivos comunes** (CHANGELOG, README raíz, `Guides/README.md`, `.github/**`, `ia-db/**`, `tools/docs-guard`):
  - fuera de los PR de contenido;
  - sólo en un PR común pequeño, anunciado antes;
  - un PR común a la vez por repo.
- **Worktrees propios.** `{dir-de-trabajo}/wt/dac-LD` y `{dir-de-trabajo}/wt/dac-LDD`, con ramas `dac/0003-*`. Los mains locales del PO no se
  tocan.
- **Merges serializados por repo.** Antes de cada merge se avisa con una línea («fusiono LD #N»). Si el PR queda
  `behind`, update-branch y se esperan los checks.
- **Ramas de FRAMEWORK MAUI.** `fc/e04-*` sólo tocan `Concepts/Framework-Concept/Demo/**`, son descartables y no se
  fusionan.
- **Guía 16.** `Guides/IA/Dot-Net-Integration-AI-Layer-Guide` y `PROMPTs/Guides/16-IA-Layer` no se tocan.

## 6. Pruebas

Corren en el equipo de pruebas:

- **docs-guard.** `tools/docs-guard/dg.py`, con el layout de la CI.
- **Mermaid.** `tools/medios/mermaid.sh <md>…` dibuja en un contenedor efímero y sale 1 si algún diagrama no compila o
  sale «Unsupported markdown».
  - Aprendizaje de FRAMEWORK MAUI: en las etiquetas, «1 · Texto» en vez de «1. Texto», y sin URLs.
- **Enlaces y anclas.** Se verifican contra el árbol.
- **Sitio MkDocs.** Se construye en contenedor.
- **Barrido de lo privado.** Antes de cada PR público se buscan nombres de repos privados, IPs, hosts, rutas de home y
  seriales.

## 7. Público y privado

- LD, LDD y Lab-Geometria son públicos: se nombran y se citan.
- El servicio de notificaciones push es privado. En los repos públicos va ofuscado, como «servicio privado de
  notificaciones», sin nombre, dominio ni datos.
- Su ensayo y su evidencia quedan en su propio repositorio de documentación, que es privado, y en
  `{dir-de-trabajo}/privado/`.

## 8. Desvíos del prompt declarados

- **Profile.** El prompt cita `/IA/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md`, que no existe. El
  archivo está en `/IA/PROMPTs/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md` y se usa ése.
- **Ubicación del conocimiento.**
  - El contexto del prompt lo ubica en `PROMPTs/Guides/14-…/ARTIFACTs/`.
  - La solicitud 3 lo ubica en `…/Sistema-De-Documentacion-E-Integracion/Conocimientos/` de LD.
  - `PROMPTs/` fuera de `OUTPUTs/` es del PO, así que el canónico va en LD. Una copia en `ARTIFACTs/` queda a decisión
    del PO.
- **Archivos vacíos.** `DocsAsCode-Developer-Guide.md` y `Conocimientos/knowledge-DocsAsCode-Designing-Specification.md`
  existen vacíos y sin versionar en el clon local del PO. Se crean en la rama `dac/0003-*`; el PO tiene que borrar sus
  vacíos antes del pull.
