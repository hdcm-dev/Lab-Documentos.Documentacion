---
doc_id: EXP0002-F252
doc_type: corrigenda
title: Corrigenda a N10 y a la carátula — disparadores sin push, onda 0 sin rama, contradicción de §3.3 frente a §14 (clase H espera al PO), folio 230 vacante, 211 doble, huecos y serie nueva
status: vigente
origin: agent
confidence: alta (cada cita se verificó con el comando de su fila sobre main de los dos repos)
owner: presidencia de la mesa de Replanteo y análisis DocAsCode (vuelta de E1)
last_review: 2026-10-28T13:35:47-03:00
audience: [PO, presidencia, refutador, agentes que reparen E1, mesa de la opción B, bitacorista]
traces: [EXP0002-F240, EXP0002-F245, EXP0002-F249, EXP0002-F250, EXP0002-F251, N10]
---

# 252 — Corrigenda a N10 y a la carátula

| Campo | Valor |
| --- | --- |
| Tipo | corrigenda (sólo agregado, por referencia; estilo `125`) |
| Fecha | 2026-10-28T13:35:47-03:00 |
| Autor | Presidencia de la mesa (vuelta de E1), por la unidad U10 del acta `250`. Decisiones DEC-10, DEC-12, DEC-19 y DEC-20. Defectos DEF-01 y DEF-06 |
| Corrige | `N10` (bitácora del plan) en `:74-76`, `:163`, `:176`, `:505`, `:512` y `:519`; la carátula `README.md` del expediente en `:16`. Ninguno de los dos se edita |

## Índice

1. [N10: disparadores sin push](#1-n10-disparadores-sin-push)
2. [N10: onda 0 sin rama](#2-n10-onda-0-sin-rama)
3. [N10: clase H, §3.3 frente a §14](#3-n10-clase-h-33-frente-a-14)
4. [Carátula: folio 230, 211 doble y huecos](#4-carátula-folio-230-211-doble-y-huecos)
5. [Serie de folios de la vuelta](#5-serie-de-folios-de-la-vuelta)
6. [Pase](#6-pase)

## 1. N10: disparadores sin push

| Lugar | Dice | Defecto | Se lee |
| --- | --- | --- | --- |
| `N10:163` (E1-U0a) | `docs-guard.yml`: «disparadores `pull_request` y `workflow_call`» | Sin `push` ni `workflow_dispatch`, ninguna corrida podía caer sobre el SHA del merge: G-b («verde sobre el SHA del merge», `133` §2) no podía cumplirse por diseño (DEF-06) | Defecto del plan. `docs-guard.yml` lo corrigió `9d00e42` (Lab-Documentos #26, merge `56ea2d3`, 2026-10-28T00:40:30-03:00), que agregó `push: branches: [main]` y `workflow_dispatch` (`git show 9d00e42 -- .github/workflows/docs-guard.yml`) |
| `N10:176` (E1-U0b) | `verificar.yml`: «`pull_request`» | Mismo defecto. Hoy `verificar.yml:14-16` tiene `pull_request` y `workflow_dispatch`, sin `push` | Defecto del plan. En la vuelta, cada merge de LDD lleva un despacho de Verificar sobre el SHA del merge (`251` §4, G-b). Agregar `push` es clase H: propuesta U11 (`exp0002/e1r-h-verificar`), espera al PO |

## 2. N10: onda 0 sin rama

| Lugar | Dice | Defecto | Se lee |
| --- | --- | --- | --- |
| `N10:505` | «PRE-01 y PRE-03 están hechos (folios `132` y `133`…)» | «Hechos» sin versionar: 132 y 133 entraron recién en `cc2bfd6` (E1-U0c, onda 3, 2026-10-27T11:57:10-03:00), después de la primera rama de E1 (`245` §5, G-a) (DEF-01) | Defecto del plan. Un folio de criterios está hecho cuando está fusionado en `main` |
| `N10:519` | Onda 0: «— (folios 132, 133; hechos)», sin rama | La onda 0 no tenía rama ni merge, así que `git log` nunca podía mostrar los folios antes de la onda 1 | Rige `251` §2: hora ISO 8601 con zona y merge en `main` antes del primer commit de la primera rama del escalón o de la vuelta |

## 3. N10: clase H, §3.3 frente a §14

`N10` se contradice:

- `N10:74-76` (§3.3): «Las de clase H (workflows, `AGENTS.md`, conocimientos, aceptar ADR, etiquetar) y el primer
  merge de cada repo van a conformación «PO»».
- `N10:512` (§14): «Todo PR, incluido el primer merge de cada repo (U0a, U0b, U2, U4e, U6), se fusiona por `CPA`».

Antecedente de que la contradicción tuvo efecto: `9d00e42` cambió un workflow (`docs-guard.yml`, clase H por §3.3) y
se fusionó por CPA en Lab-Documentos #26 (merge `56ea2d3`), al amparo de §14.

**Se lee (DEC-20):** rige la carta común y §3.3. La clase H se prepara en rama, con su PR y CI verde, lleva en el
título la marca «[espera PO]» y **no la fusiona un agente**. Es clase H:

| Ítem | Unidad |
| --- | --- |
| `verificar.yml`: SHA de `docs-guard`, ruta del expediente y `push` | U11 |
| Ruta de trazas de la CI de Lab-Documentos, fixtures y generalización de raíces de `dg.py` | U12 |
| `AGENTS.md:54` | U13 |
| Política de etiquetas, tag `docs-guard-v1.0.0` y regla owner/alias | U14 (folio `255`) |
| `runs-on` de `framework-concept-demo.yml` | De la línea Framework-Concept: sólo aviso |

En general: workflows, `AGENTS.md`, `dg.py` y su contrato, excepciones con huella, conocimientos y tags. **E1-G2 no
espera los merges H**: mide con lo fusionado y declara cada H pendiente como reserva nombrada (`251` §6, punto 5).

## 4. Carátula: folio 230, 211 doble y huecos

La carátula no se edita: `249` ya supera su estado. Por referencia (DEC-19):

| Lugar | Dice | Se lee |
| --- | --- | --- |
| `README.md:16` | «Versión publicada (unidad E1-U0c, folio `230`)» | «Versión publicada (unidad E1-U0c: PR #20 de Lab-Documentos.Documentacion, merge `60d94f3`, y `240` §4)». El folio `230` se perdió con i7infra (`240:76-83`) |
| Número `230` | — | **Vacante.** No se reutiliza. Tampoco el rango `217`–`239` (`240` §4) |
| `211-e1-u0b.md` y `211-e1-u1.md` | Dos folios con el número `211` | No se renombran. Se citan por nombre: `211-e1-u0b` y `211-e1-u1` |
| Folios de E1-U2…E1-U5 y de la verificación previa de E1-G | Sin número conocido | Vacantes por pérdida (`240` §4). No se emiten con fecha vieja |

## 5. Serie de folios de la vuelta

| Folio | Objeto | Estado |
| --- | --- | --- |
| `250` | Acta de la mesa-comisión: organización y vuelta de E1 | Fusionado (PR #29) |
| `251` | Corrigenda a `133`: criterios de la vuelta | Este PR |
| `252` | Este folio | Este PR |
| `253` | Constancia del resguardo privado | Este PR |
| `254` | Corrigenda del patrón S2 en dos partes; las redacciones hacia adelante las agrega U28 | Este PR |
| `255` | Propuesta H de etiquetas, tag y owner/alias | U14, espera al PO |
| `256` | Corrigenda de la cuenta de marcas de G-g | Fusionado (PR #29). No estaba en la serie de DEC-19: lo tomó U01 (`250`, ajuste §7.1) |
| `260` | Registro de E1-R | U32 |
| `263` | Convocatoria de la mesa de la opción B | U43 |
| `265` | Resolución de E1-G2, con el anexo L6 | U43 |

Los números libres entre `250` y `265` quedan para la vuelta. Si una unidad necesita uno, toma el siguiente libre y lo
declara en su folio.

## 6. Pase

A la presidencia, con `251`, `253` y `254`, para fusionar antes de abrir cualquier rama `exp0002/e1r-*`; a U11–U14
para preparar los PR H con la marca «[espera PO]» · presidencia.
