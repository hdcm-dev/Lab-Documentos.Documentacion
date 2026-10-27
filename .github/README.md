---
title: Integración continua de Lab-Documentos.Documentacion
fecha: 2026-10-27
origen: expediente 0002 (DocAsCode), unidad E1-U0b
---

# Integración continua de Lab-Documentos.Documentacion

## Índice

1. [Definiciones](#definiciones)
2. [Qué corre en cada PR](#qué-corre-en-cada-pr)
3. [Seguridad](#seguridad)
4. [Cómo reproducirlo en local](#cómo-reproducirlo-en-local)
5. [Cambiar la versión de docs-guard](#cambiar-la-versión-de-docs-guard)

## Definiciones

- **Verificar**: el workflow [`workflows/verificar.yml`](workflows/verificar.yml) de este repositorio.
- **docs-guard**: workflow reutilizable (`workflow_call`) de `hdcm-dev/Lab-Documentos`; verifica enlaces internos,
  anclas y estructura de una carpeta de Markdown.
- **Runner propio**: la máquina autohospedada con las etiquetas `self-hosted` e `i7infra-dev`.
- **Fijado por SHA**: la referencia a otro workflow o action se hace por commit completo, no por rama ni etiqueta.

## Qué corre en cada PR

| Job | Qué verifica | Dónde corre |
| --- | --- | --- |
| `verificar` | Lo que el PR agrega: sin claves privadas ni binarios pesados | Runner propio |
| `docs-guard` | `lychee --offline --include-fragments` y `markdownlint-cli2` estructural sobre esta carpeta | Runner propio (lo declara el workflow llamado) |

```mermaid
flowchart LR
  PR[pull_request] --> V[verificar]
  PR --> G[docs-guard de Lab-Documentos @SHA]
  G --> H[herramientas] --> E[enlaces] --> S[estructura]
```

El workflow llamado declara su propio `runs-on`; el registro del job muestra el nombre del runner que lo tomó.

## Seguridad

- `permissions: contents: read` en todo el workflow; ningún secreto.
- Sin `pull_request_target`.
- Un PR desde un fork no corre en el runner propio: guarda
  `if: github.event.pull_request.head.repo.full_name == github.repository`.
- El workflow llamado y las actions se fijan por SHA.

## Cómo reproducirlo en local

Ejemplo, con un clon de Lab-Documentos en el commit fijado:

```bash
git -C ../Lab-Documentos checkout f603984a3a4b35ea62feb7e5b3f68c0ad3331311
bash ../Lab-Documentos/scripts/ci-local.sh todo .github
```

## Cambiar la versión de docs-guard

El SHA aparece dos veces en `verificar.yml` (en `uses:` y en `herramientas-ref`) y deben coincidir: así el workflow
y sus scripts son del mismo commit.

Ver también [el anexo](anexo-inexistente.md).
