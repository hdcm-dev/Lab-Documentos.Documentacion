---
doc_id: SDOC-PREFIJOS
doc_type: anexo
title: Registro de prefijos del sistema documentador
description: Registro cerrado de prefijos de ID, con su ámbito, para las trazas del sistema documentador de Fábrica de Geometría.
status: borrador
origin: ia-generated
confidence: media
owner: pendiente (lo asigna una persona; ver A-01 §4)
last_review: 2026-11-01
audience: [desarrollo, agente]
traces: []
---

# Registro de prefijos (A-02)

Ámbito **interno**: se declara en este repositorio y una traza que no resuelve bloquea.
Ámbito **externo**: lo emite el marco de especificación del proyecto (framework SDD, procedencia 13.16,
`SDD/README.md:3`); se resuelve contra el SHA fijado de ese marco, **pendiente**: el registro del marco
vive fuera de este repositorio y su SHA no está declarado en lo leído.

Las familias externas salen del relevamiento de `Lab-Geometria.Documentacion/ia-db/indexes/10_Glosario-Y-Nomenclatura.md:236-261`.

| Prefijo | Ámbito | Nombra | Forma |
| --- | --- | --- | --- |
| `SDOC` | interno | Pieza propia del sistema documentador (ficha, registros, informes) | `SDOC-{SUFIJO}` |
| `RD` | interno | Requerimiento documental (RRD) | `RD-NN` |
| `NB` | externo | Necesidad de negocio | `NB-000NN` |
| `RN` | externo | Regla de negocio | `RN-020NN` |
| `CU` | externo | Caso de uso | `CU-NNNNN` |
| `US` | externo | Historia de usuario | `US-000NN` |
| `BT` | externo | Tarea técnica | `BT-000NN` |
| `ADR` | externo | Decisión de arquitectura | `ADR-NNNNN` |
| `QG` | externo | Puerta de calidad | `QG-NNNNN` |
| `CV` | externo | Criterio de validación | `CV-NNNNN` |
| `SD` | externo | Sonda de sensado de deriva | `SD-NNNNN` |
| `EXP` | externo | Expediente | `EXP-NNNN` |
| `AG` | externo | Rol de agente del marco | `AG-000NN` |

**Fuera del registro, a propósito.** Las familias que el relevamiento marca con homónimos
(`10_Glosario-Y-Nomenclatura.md:272-275`) o con dos anchos vivos (`:266-270`) no entran hasta que una
persona decida su forma única: `A-NN`, `F-NN`/`F-0N`, `RT-NN`, `C-N`, `I-N`, `R-N`, `V-N`, `D-0N`, `INV`,
`RA`, `RI`, `PT`, `EVE`, `AP`, `VER`, `O-N` y los prefijos de mesa. Una traza a una de ellas **avisa**,
no bloquea. Ojo: `A-NN` es la familia de puntos de acceso HTTP; los Id `A-01`…`A-11` de los artefactos
del diseño no son IDs de este corpus y no se usan en `traces`.
