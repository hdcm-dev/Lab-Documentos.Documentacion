---
doc_id: EXP0002-F249
doc_type: providencia
title: Providencia de estado del expediente al 2026-10-28 — compuerta E1-G INSUFICIENTE y qué sigue
status: vigente
origin: agent
confidence: alta en el estado (folios 240 y 245); media en el orden de la vuelta, que es criterio propio de la presidencia
owner: presidencia de la mesa de Replanteo y análisis DocAsCode (compuerta E1-G)
last_review: 2026-10-28
audience: [PO, presidencia, agentes que reparen E1, bitacorista]
traces: [EXP0002-F133, EXP0002-F240, EXP0002-F245, N10]
---

# 249 — Providencia: estado del expediente

| Campo | Valor |
| --- | --- |
| Tipo | providencia |
| Fecha | 2026-10-28 |
| Autor | Presidencia de la mesa (compuerta E1-G). Pluma delegada en un agente redactor; la presidencia revisa |
| Corrige | El «Estado (2026-10-27)» de la carátula queda superado por este folio; la carátula no se edita |

## Índice

1. [Estado al 2026-10-28](#1-estado-al-2026-10-28)
2. [Qué sigue](#2-qué-sigue)
3. [Pase](#3-pase)

## 1. Estado al 2026-10-28

La carátula (`README.md`) dice: «ciclo 2 cerrado … Sigue: implementación E1». Eso ya ocurrió. El estado vigente es:

| Aspecto | Estado | Folio |
| --- | --- | --- |
| Escalón 1 | Implementado: 17 PR fusionados por CPA (E1-U0a…E1-U6 y #26, #27, #28 de la compuerta) | `240` §5 |
| Entorno | i7infra cayó el 2026-10-28 00:50 -03; se trabaja desde hpdev con el runner `hpdev-runner-dev` (mismas etiquetas) | `240` §2–§3 |
| Folios de E1 | Perdidos los de E1-U0c (citado como `230`), E1-U2…E1-U5 y la verificación previa de E1-G; incorporados como antecedente, no reconstruidos | `240` §4–§6 |
| Compuerta E1-G | **INSUFICIENTE — vuelve una vez**. G-a y G-c INSUFICIENTE; G-b, G-d, G-e, G-f y G-g NO_CUMPLE. Reserva: NO_PROCEDE si la presidencia califica de P0 el hallazgo de G-f | `245` §4, §7 |
| Mesa de la opción B | No constituida en esta vuelta; hubo verificador y refutador por criterio, sin votación | `245` §3 |
| Anexo L6 | Pendiente | `245` §11 |
| Evidencia de E1-G | En `evidencia/E1-G/`, sin versionar hasta el PR de la presidencia | `240` §9 |

La cita de la carátula a «folio `230`» no tiene destino: ese folio se perdió (`240` §4).

Estado por folio de lo actuado desde la onda 0 (`git log` de cada archivo en este repo):

| Folio | Objeto | Estado | Fuente |
| --- | --- | --- | --- |
| `130`–`133` | Respuestas del PO, decisiones delegadas, opción B, criterios de E1 | Vigentes; versionados en `cc2bfd6` (E1-U0c, #20), un solo commit | `240` §4; `245` §5 (G-a) |
| `210` | E1-U0a | `estado: fusionado`; versionado en `cc2bfd6` | `240` §5 |
| `211-e1-u0b`, `211-e1-u1` | E1-U0b, E1-U1 | `estado: fusionado`; versionados en `cc2bfd6`. Comparten el número `211` | `240` §5 |
| `216` | E1-U6 | `estado: fusionado`; versionado en `cc2bfd6` | `240` §5 |
| `230` | E1-U0c | Perdido con i7infra; sólo queda la cita de la carátula | `240` §4 |
| Sin número | E1-U2, E1-U3, E1-U4a…E1-U4f, E1-U5 | Perdidos con i7infra; antecedente en sus PR | `240` §4–§6 |
| Sin número | Verificación de E1-G previa a la caída | Perdido; las medidas se repitieron desde hpdev | `240` §8; `245` |
| `240`, `245`, `249` | Constancia, resolución de E1-G, esta providencia | Vigentes; sin versionar al escribirse | `240` §9 |

## 2. Qué sigue

En este orden **[criterio propio]**:

1. **Presidencia**: versionar por PR los folios `240`, `245`, `249` y `evidencia/E1-G/`.
2. **Presidencia**: decidir la severidad de G-f (`245` §9.1). Si es P0, el corte pasa a NO_PROCEDE y la redacción del
   hallazgo va antes que todo lo demás; la reescritura de la historia de git, si se propone, sale al PO.
3. **Presidencia o mesa**: las decisiones de `245` §9.2–§9.8 (G-a, G-b, regla de corte, granularidad de G-c, alcance de
   G-d, obligatorios de G-g, composición de la mesa).
4. **Agentes, por CPA**: las reparaciones de `245` §10, una rama `exp0002/e1g-…` por grupo.
5. **Presidencia**: medir E-F4, emitir las lecciones de E1 y el anexo L6.
6. **Mesa de la opción B** (`132` §3): segunda y última vuelta de E1-G, con un folio de resolución nuevo.
7. Si esa vuelta da PROCEDE: **E2-U0** (`N10` §7).

## 3. Pase

A la presidencia para el PR de esta compuerta y las decisiones de `245` §9 · presidencia.
