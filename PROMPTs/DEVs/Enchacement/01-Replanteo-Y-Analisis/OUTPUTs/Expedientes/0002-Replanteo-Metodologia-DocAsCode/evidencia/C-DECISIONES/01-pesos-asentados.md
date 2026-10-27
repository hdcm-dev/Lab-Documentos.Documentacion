---
doc_id: EXP0002-EV-CDEC-01
doc_type: evidencia
title: Criterios, escalas, pesos y umbrales de decisión asentados antes de puntuar
status: vigente
origin: agent
owner: comisión C-DECISIONES (análisis y criterios de decisión, función formal absorbida)
last_review: 2026-10-26
audience: [presidencia, refutador, jurado de veredicto]
traces: [TP:34, TP:36, TP:30, RM:216, RM:227, R01:275-276, EXP0002-F003:284, EXP0002-F004:193-196]
---

Origen: comisión C-DECISIONES, expediente 0002.
Fecha-hora de asiento: 2026-10-26T15:06-03:00, antes de puntuar cualquier alternativa y sin haber leído resultado
alguno de los ensayos de generador o topología de otras comisiones (trabajo a ciegas, carta común).
Custodia: la huella SHA-256 de este archivo se registra en `02-huella-pesos.txt` en el mismo minuto; cualquier
cambio posterior la rompe.

# Pesos asentados — C-DECISIONES

## Índice

1. [Criterios y fuente](#1-criterios-y-fuente)
2. [Escalas ancladas](#2-escalas-ancladas)
3. [Pesos](#3-pesos)
4. [Filtros duros](#4-filtros-duros)
5. [Regla de decisión, umbrales y desempate](#5-regla-de-decisión-umbrales-y-desempate)

## 1. Criterios y fuente

| Id | Criterio | Fuente literal |
| --- | --- | --- |
| K1 | Simplicidad | `TP:36` «se deben buscar las ventajas de simplicidad» |
| K2 | Practicidad | `TP:36` «y practicidad» |
| K3 | Escalabilidad | `TP:36` «escalibilidad»; `TP:30` «para ser aplicado luego en el diseño de nuevos sitemas» |
| K4 | Respaldo de industria y estándares | `TP:36` «Es importante basarse en las tendencias del mercado y los estandares de la industria» |

## 2. Escalas ancladas

Escala entera 1–5. Cada punto tiene un observable; una celda sin observable citado no se puntúa (queda «s/d»).

| Punto | K1 Simplicidad: piezas nuevas que agrega (repo, herramienta, mecanismo, paso por cambio) | K2 Practicidad: operable hoy por un mantenedor único, con el runner único sin `docker.sock` y el plan sin protección de rama | K3 Escalabilidad: costo marginal de sumar el sistema N+1 | K4 Respaldo |
| --- | --- | --- | --- | --- |
| 5 | 0 piezas nuevas | Funciona con lo existente, sin paso humano extra por cambio | Constante: se instancia o se declara | ≥ 3 referentes primarios relevados y una norma o especificación |
| 4 | 1 pieza | Un paso humano por lote o por release, no por cambio | Constante más una configuración por sistema | ≥ 3 referentes primarios |
| 3 | 2 piezas | Un paso humano por cambio, o una precondición que hoy falta y se puede crear en una unidad | Lineal con trabajo manual por sistema | 1–2 referentes primarios |
| 2 | 3 piezas | Precondición que exige una decisión del PO o un recurso que hoy no está | Lineal más coordinación entre pares | Sólo criterio propio con antecedente en el workspace |
| 1 | ≥ 4 piezas | Exige infraestructura no disponible (Docker en el runner, protección de rama, credencial entre repos) | Superlineal (pares N×M, sincronización cruzada) | Contraindicado por la industria relevada |

## 3. Pesos

| Criterio | Peso | Fundamento |
| --- | --- | --- |
| K1 | 0,25 | `TP:36` enumera las tres ventajas sin orden ni prioridad; y pone la base en industria y estándares como requisito de igual fuerza («Es importante»). Sin una fuente que ordene, se reparte por igual (principio de razón insuficiente). **Criterio propio**, rotulado |
| K2 | 0,25 | idem |
| K3 | 0,25 | idem |
| K4 | 0,25 | idem |

Puntaje de una alternativa = Σ peso × punto (rango 1,00–5,00).

## 4. Filtros duros

No se ponderan: una alternativa que viola uno sale de la matriz antes de puntuar.

| Id | Filtro | Fuente |
| --- | --- | --- |
| F1 | Todo workflow pedido corre en `runs-on: [self-hosted, i7infra-dev]` | `TP:34`; folio 001 D1 |
| F2 | Nada versionable con ruta del host o usuario | folio 001 D6 (compuerta S2) |
| F3 | El servicio privado no se nombra ni se expone | carta común |
| F4 | Sin escritura en `PROMPTs/` del PO fuera de `OUTPUTs/` | `R06:251` (R10); carta común |
| F5 | Apartarse de un conocimiento catalogado exige ficha con alternativa de cumplir | `MEP:395-398`, citado en `R01:268` |

## 5. Regla de decisión, umbrales y desempate

| Id | Regla | Valor |
| --- | --- | --- |
| U1 | Ganador | Mayor puntaje ponderado |
| U2 | Decisión **firme** | Margen sobre la segunda ≥ 0,30 **y** el ganador no cambia en ninguna de las 8 perturbaciones de ±10 % relativo de un peso (con renormalización) |
| U3 | Decisión **con revisión** | Margen < 0,30 o cambia con alguna perturbación: se elige la alternativa **reversible** (`Knowledge-Cadena-De-Consecuencias` §2, paso 4) y se asienta la condición de revisión como hecho comprobable |
| U4 | Robustez extendida (informativa) | Barrido de cada peso entre 0,10 y 0,40 con las demás renormalizadas: se informa el peso de inversión, si existe |
| U5 | Punto de inversión por celda | Para la celda de mayor incertidumbre se informa cuántos puntos tendría que moverse para cambiar el ganador |
