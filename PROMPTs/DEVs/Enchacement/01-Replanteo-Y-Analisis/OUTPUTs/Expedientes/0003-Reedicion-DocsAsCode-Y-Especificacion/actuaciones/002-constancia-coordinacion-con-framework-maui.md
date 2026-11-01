---
doc_id: EXP0003-F002
doc_type: constancia
title: Constancia de coordinación con la sesión FRAMEWORK MAUI — territorios, archivos comunes, worktrees y merges serializados
status: vigente
origin: agent
confidence: alta (propuesta y aceptación por mensaje entre sesiones del 2026-11-01; ramas y PR abiertos medidos por la API ese día)
owner: presidencia de la reedición DocsAsCode
last_review: 2026-11-01
audience: [PO, presidencia, sesión FRAMEWORK MAUI, agentes de la reedición]
traces: [EXP0003-F001, DB-R02-00]
---

| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-11-01 |
| Autor | Presidencia de la reedición DocsAsCode |
| Corrige | — |

# 002 — Constancia de coordinación con FRAMEWORK MAUI

## Índice

1. [Qué se asienta](#1-qué-se-asienta)
2. [Estado medido al acordar](#2-estado-medido-al-acordar)
3. [Reglas acordadas](#3-reglas-acordadas)
4. [Aprendizajes transmitidos por FRAMEWORK MAUI](#4-aprendizajes-transmitidos-por-framework-maui)

## 1. Qué se asienta

El 2026-11-01 el PO pidió coordinar con los agentes de la sesión FRAMEWORK MAUI, que intervienen los mismos dos
repositorios, «para que no se pisen con los PR». También pidió buscar cómo trabajar en paralelo sin conflictos, por
ejemplo armonizando ramas y usando clones paralelos.

La presidencia propuso un reparto por mensaje entre sesiones. FRAMEWORK MAUI lo aceptó sin cambios, literal: «acepta el
reparto R1–R8 ampliado tal como lo propusiste, sin cambios; asentalo en la constancia del 0003».

## 2. Estado medido al acordar

| Repositorio | `origin/main` | PR abiertos | Ramas remotas |
| --- | --- | --- | --- |
| Lab-Documentos | `0bed863` | ninguno | `main`, `fc/e04-arranque-superpuesto`, `fc/e04-semilla-apk` |
| Lab-Documentos.Documentacion | `8b96bc6` | ninguno | `main` |

FRAMEWORK MAUI declaró que las dos ramas `fc/e04-*` sólo tocan `Concepts/Framework-Concept/Demo/**`, que son
descartables y que no se fusionan.

## 3. Reglas acordadas

1. **Territorios disjuntos.**
   - DocsAsCode: `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/**` en Lab-Documentos; este
     expediente y `PROMPTs/Guides/14-Sistema-De-Documentador-Tecnico/OUTPUTs/**` en Lab-Documentos.Documentacion.
   - FRAMEWORK MAUI: `Concepts/Framework-Concept/**`, `PROMPTs/Concepts/**` y sus expedientes.
   - Ninguna sesión toca el territorio de la otra.
2. **Archivos comunes.** Son CHANGELOG, README raíz, `Guides/README.md`, `.github/**`, `ia-db/**` y `tools/docs-guard`.
   - No entran en los PR de contenido.
   - Si hace falta tocarlos, va un PR común pequeño y aislado, anunciado antes a la otra sesión.
   - Hay un solo PR común abierto a la vez por repositorio.
3. **Clones paralelos.** Cada sesión trabaja en worktrees propios y nunca en los clones principales del PO.
   - DocsAsCode usa `{dir-de-trabajo}/wt/dac-LD` y `{dir-de-trabajo}/wt/dac-LDD`, con ramas `dac/0003-*`.
   - FRAMEWORK MAUI usa ramas `fc/*`.
   - Antes de pedir merge, cada uno integra `origin/main`. Si el PR queda `behind`, se hace update-branch y se esperan
     los checks. No se fuerza.
4. **Merges serializados por repositorio.** Antes de fusionar, la sesión que fusiona avisa con una línea («fusiono LD
   #N»). La otra no fusiona en el mismo repositorio en esos minutos.
5. **docs-guard y `verificar.yml`.** Si hace falta cambiarlos o repinear, se anuncia antes. Lo hace la sesión que los
   tocó por última vez; hoy es FRAMEWORK MAUI, por la reescritura de historia.
6. **Guía 16.** `Guides/IA/Dot-Net-Integration-AI-Layer-Guide` y `PROMPTs/Guides/16-IA-Layer` quedan intocables y sin
   versionar.

FRAMEWORK MAUI declaró además que no planea tocar archivos comunes en los próximos días. Si surge algo, avisa antes y lo
hace como PR común aislado.

## 4. Aprendizajes transmitidos por FRAMEWORK MAUI

Vienen de su libro unificado del prompt 04, `Concepts/Framework-Concept/MAUI-Framework-Developer-Guide.md`.

- **Mermaid.** Dentro de una etiqueta, «1. Texto» se dibuja como lista y una URL como enlace. El resultado es una caja
  «Unsupported markdown» que igual compila, así que la CI no la detecta.
  - Escribir «1 · Texto» y sacar las URLs de las etiquetas.
  - Validar con `tools/medios/mermaid.sh` desde la raíz del workspace antes de cada PR.
- **Libros grandes.** docs-guard pasó sin problemas un libro de unas 2900 líneas. Lo costoso fue la coherencia interna:
  numeración, anclas y referencias cruzadas. Conviene verificar anclas e índice al final del ciclo.
- **Repos públicos.** Antes de cada PR, barrer con grep rutas de home, IPs, seriales y nombres de proyectos privados.
- **Bitácoras.** Llevar una por núcleo, con su evidencia, facilitó el cierre y la revisión.
