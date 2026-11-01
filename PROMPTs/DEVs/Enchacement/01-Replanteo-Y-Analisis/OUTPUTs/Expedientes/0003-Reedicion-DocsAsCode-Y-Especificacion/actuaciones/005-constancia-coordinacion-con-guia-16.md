---
doc_id: EXP0003-F005
doc_type: constancia
title: Constancia de coordinación con la sesión de la guía 16 (AI Layer) — carpetas por línea en los casos de uso, expedientes, reindexado y PR comunes
status: vigente
origin: agent
confidence: alta (propuesta y aceptación por mensajes entre sesiones del 2026-11-01)
owner: presidencia de la reedición DocsAsCode
last_review: 2026-11-01
audience: [PO, presidencia, sesión Crear IA Layer Guide, sesión FRAMEWORK MAUI, agentes de la reedición]
traces: [EXP0003-F002, DB-R02-00]
---

| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-11-01 |
| Autor | Presidencia de la reedición DocsAsCode |
| Corrige | — |

# 005 — Constancia de coordinación con la guía 16

## Índice

1. [Qué se asienta](#1-qué-se-asienta)
2. [Territorio de la guía 16](#2-territorio-de-la-guía-16)
3. [Reglas acordadas](#3-reglas-acordadas)

## 1. Qué se asienta

El 2026-11-01, el PO le pidió a la sesión de la guía 16 (AI Layer) que ejecute el prompt 02 de esa guía. También le pidió
coordinarlo entre tres sesiones: DocsAsCode, FRAMEWORK MAUI y la guía 16.

- La guía 16 propuso cuatro reglas.
- DocsAsCode las aceptó y sumó tres ajustes (a, b y c).
- La guía 16 aceptó los ajustes. Lo asienta también en su bitácora de coordinación:
  `PROMPTs/Guides/16-IA-Layer/OUTPUTs/Bitacoras/Prompt-02/00-Coordinacion-Entre-Sesiones.md`.

Esta constancia complementa la `002` (FRAMEWORK MAUI), que sigue rigiendo.

## 2. Territorio de la guía 16

| Dónde | Qué |
| --- | --- |
| Lab-Documentos | `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/**`: guía unificada, conocimiento de especificación, `Examples/`, `Demos/` |
| Lab-Documentos.Documentacion | `PROMPTs/Guides/16-IA-Layer/OUTPUTs/**` |
| Lab-Geometria.Documentacion | `ai-layer/` |
| Repositorio de documentación del servicio privado | `ai-layer/`, sólo si su mesa decide abrir un PR. Si no, el trabajo queda en privado |

La guía 16 no toca:

- `Guides/Documentacion-Tecnica/**`;
- `Concepts/**`;
- la ia-db;
- `verificar.yml`.

Hasta el cierre, la guía 16 sigue sin versionar. Al cerrar, entra en un único PR de integración, después de los PR de
DocsAsCode y de FRAMEWORK MAUI.

## 3. Reglas acordadas

1. **Worktrees y ramas propias.** Cada sesión trabaja en su propio worktree y en ramas con su propio prefijo:
   `g16/<tema>` para la guía 16 y `dac/0003-*` para DocsAsCode. En los casos de uso, primero va el diseño y la
   especificación. Antes de tocar código o de abrir un PR en un repositorio de caso de uso, la sesión avisa a las otras.
2. **Un PR por vez y por repositorio.** Antes de cada merge, la sesión que fusiona avisa a las otras dos con una línea:
   «fusiono <repo> #N».
3. **Carpetas separadas por línea en los casos de uso** (ajuste a).
   - La guía 16 trabaja en `ai-layer/`. DocsAsCode deja sus artefactos de ensayo en una carpeta propia de docs-as-code.
   - Ninguna línea edita los artefactos de la otra.
   - La guía 16 confirma la ruta exacta antes de crear.
4. **Reindexado de las ia-db de los casos de uso** (ajuste b). Reindexa el último que cierra, después de las dos líneas,
   y lo anuncia.
5. **Archivos comunes de LD y LDD** (ajuste c). Son CHANGELOG, README raíz, `Guides/README.md`, `.github/**`, `ia-db/**`
   y `tools/docs-guard`. Admiten un solo PR común abierto a la vez por repositorio, anunciado a las otras dos sesiones.
6. **Numeración de expedientes en los casos de uso.**
   - Lab-Geometria: si su mesa lo requiere, la guía 16 toma el `0002` en `SDD/Expedientes`. Hoy el último es el `0001`.
   - Servicio privado: el número se toma del último en `main` del repositorio y se anuncia antes de crearlo.
   - DocsAsCode no abre expedientes en esos repositorios. Su evidencia vive en este expediente 0003. Si una mesa lo
     obligara, tomaría el siguiente libre y lo anunciaría.
7. **Ramas ajenas que nadie toca.**
   - En Lab-Geometria.Documentacion: `entrega/delegacion-y-verificar` e `ia-db/4.0`.
   - En el repositorio de documentación del servicio privado: `rescate/{equipo-de-pruebas}-2026-10-28`.
