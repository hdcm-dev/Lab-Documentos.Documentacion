---
doc_id: EXP0003-F401
doc_type: constancia
title: Cierre del libro DocsAsCode — ejecución de la resolución 99 y diferidos
status: vigente
origin: agent
confidence: alta en lo ejecutado (con SHA y enlaces, 2026-11-07/08); los diferidos se listan sin decidir
owner: presidencia de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-08
audience: [PO, presidencia, editores, sesión FRAMEWORK MAUI]
traces: [EXP0003-F400, DB-R02-05]
---

| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-11-08 |
| Autor | Agente que ejecutó la resolución 99 |
| Corrige | — |

## 1. Ejecutado

- **PR 8** ([hdcm-dev/Lab-Documentos#61](https://github.com/hdcm-dev/Lab-Documentos/pull/61)): libro partido por
  Parte, **fusionado por el agente** con el commit de merge `0d8c1d6`, atado a la cabeza auditada `7483a4d`; guarda
  G1–G4 en verde (estado `clean`, 3 corridas en éxito); rama remota borrada (404); docs-guard del commit de merge en
  éxito. Mediciones en `Reedicion-02/05-Rondas-Editoriales.md`.
- **Etiqueta** `sdei-v2.0.0-borrador` sobre `31660d3`, comprobada con `ls-remote` y HTTP 200.
- **Este PR (PR 9)**: fila de delegación del expediente 0003 en `CHANGELOG.md`, folio 400 (la resolución), este
  folio, la bitácora de rondas y el reindexado incremental de la ia-db (índices 11, 01 y 10).
- **Reindexado de la ia-db de Lab-Documentos (paso 9):** `Lab-Documentos` no tiene ia-db propia; su índice vive en la
  ia-db de este repositorio y se reindexa en este PR. No hay PR aparte.

## 2. Diferidos (sin decidir; no se resuelven al fusionar)

Correcciones rechazadas de la intervención 4 (no aplicadas):

| Línea del libro único | Motivo del rechazo |
| --- | --- |
| 2705 | Preferencia, no error («avisa» es término del libro) |
| 2767 | Ambigüedad bien detectada, reemplazo inadecuado («resolución» choca con la de expediente) |
| 2894 | Preferencia, no error («como a `docs-guard`») |
| 5512 | Motivo falso: la concordancia es correcta |
| 6766 | No es error: el antecedente es la carpeta `Conocimientos/` |

Citas observadas sin reemplazo aplicado (de 58 observadas, 52 están aplicadas en `ba99393`):

| Línea del libro único | Tipo | Qué queda |
| --- | --- | --- |
| 680 | rango | Lo afirmado sale sólo de la fila AI-3; acotar la cita |
| 2416 | fondo | Absorber §3.6 de la fuente (asistentes que sólo muestran lo que el usuario ve) |
| 3720 | fondo | Absorber la fila nueva de `01-Mapa.md` |
| 4977 | fondo | Toca la tesis: reglas D-18 e I-21…I-25 de §0 que no están en el cuerpo |
| 5953 | fondo | Prefijo `GUIA` registrado en `prefijos.txt` y ausente del anexo del cuerpo |
| 6488 | fondo | Clave `delivery:` de TEM-05 frente a `roles` en G.5 y G.9.2 |

Decisiones de contenido abiertas del PO: BadDeviceToken y las demás que siguen abiertas en sus expedientes. La
partición ya quedó resuelta por la resolución 99.

No hay registro durable de diferidos (SDD §12.3): esta lista es su asiento.
