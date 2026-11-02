---
doc_id: EXP0003-F205
doc_type: folio-previo
title: Folio previo de la ronda 3 de los ensayos — dos brazos, n y umbral por grupo de filas, sellos de insumos, oráculos y aislamiento
status: vigente
origin: agent
confidence: alta en las huellas (sha256sum corrido el 2026-11-02 sobre cada insumo) y en n y umbrales (copiados de los oráculos y recalculados por la fórmula); media en la elección de la A-01 del brazo A y en la lectura de clase H condicional de C3a, rotuladas [criterio propio]
owner: presidencia de la mesa de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-02
audience: [presidencia, coordinador, autores de oráculo, peritos, refutador, PO]
traces: [EXP0003-F099, EXP0003-F200, EXP0003-F201, EXP0003-F202, EXP0003-F203, EXP0003-F204, EXP0003-F399]
---

| Campo | Valor |
| --- | --- |
| Tipo | folio previo |
| Fecha | 2026-11-02 |
| Autor | Presidencia. No escribió ningún oráculo ni el conocimiento, y no corre ni coordina ninguna corrida |
| Cumple | `F399` §5.5 (dos brazos, *n* por brazo y por grupo de filas, sellos antes de la primera corrida) y `F204` §9.2 en lo que `F399` no enmienda |
| Resultado | **Ronda 3 sellada.** Ocho corridas: brazo A (C0, conocimiento 1.2) y brazo B (C1, C2 y C3a, conocimiento 1.3), dos cada caso, con coordinador. Ninguna corrida empieza antes de este commit |
| Rama | `dac/0003-ensayos` |

**Convención de citas.** La misma de `F200`. `EXP3/` es la carpeta de este expediente. Lo privado va por alias:
`{dir-de-trabajo}`, `{servicio-privado}`. Toda huella es `sha256sum` corrida el 2026-11-02, antes de la primera
corrida.

## Índice

1. [Brazos y casos](#1-brazos-y-casos)
2. [Sellos de los insumos](#2-sellos-de-los-insumos)
3. [Oráculos, n y umbral por grupo de filas](#3-oráculos-n-y-umbral-por-grupo-de-filas)
4. [Protocolo](#4-protocolo)
5. [Métrica y criterio](#5-métrica-y-criterio)
6. [Lo no verificado](#6-lo-no-verificado)
7. [Barrido de lo privado](#7-barrido-de-lo-privado)

## 1. Brazos y casos

| Brazo | Casos | Conocimiento | Por qué (`F399` §5.5) |
| --- | --- | --- | --- |
| A | C0 | 1.2 | Sin roles, API ni formulario. No espera a la 1.3 |
| B | C1 (panel con roles), C2 (`{servicio-privado}`, servicio con paquetes), C3a (proyecto nuevo, ficha 2 con roles y panel) | 1.3 | Con roles, API o formulario: ejercitan D-18 |

Dos corridas por caso, independientes, cada una con aplicador nuevo y un coordinador por caso (`F202`). Total: ocho.

## 2. Sellos de los insumos

| Insumo | Uso | Huella |
| --- | --- | --- |
| Conocimiento 1.2 | Brazo A | `aeb9135f60c3177a98c5c97eac1e272e889d10ab8a07b5b3df0827d3d85716d8` |
| Conocimiento 1.3 | Brazo B | `8a3122671827a4777c112477a1a76603ac294f9b3ce386da857cda1c9543279e` |
| A-01 vacía de la 1.2 (sin §5 «Audiencias y entrega») | Brazo A | `8af70465bd0e834fddfa795f4dec2b8eb5cf595045a106e1f34775808d716cac` |
| A-01 vacía de la 1.3 (con fila D-18 y §5 D-18) | Brazo B | `293974f81f7e0bf4e23dd20c033f1cd941718a065a829d2764d328a79d63f1d7` |
| Carta del aplicador 3 | Las ocho | `dd5f95ab44c55c2a725974431df511840e485e6657252c3b2910271845c64fc1` |
| Carta del coordinador 2 | Las ocho | `151eaff858e6e40c7760699600c77c1d0b3096a43156579aff522948c8a93b3b` |
| `compuerta/` (árbol, 100 archivos; `tools/docs-guard` y `scripts` de `LD@00171bd`) | Las ocho | `f58f5061d4db853a7489b8d2cbf218028ce1b6ec4ec8c9983e8474eb21d83ede` |
| Imagen `dac-aislado:1` (id) | Las ocho | `sha256:4f0d72f24b36f270f86d46a4e403b7b911fb87ed1eab6762bc625e36eed99191` |
| `aislado/Dockerfile` | Las ocho | `60c194f2f3f831f56ebc795fd3ddc0cd8ccb0ae70ca5997aefadc62c8419b16f` |
| `aislado/aislado.sh` | Las ocho | `989424ee5667ca9666a9ff9f2e85806dcb89ab7d349e97373d32a2885258a930` |
| `aislado/huellas.txt` | Las ocho | `cb740a5ac28e85af39954ff8cf96328c0f396d7af7b53fc54baef62bef48825f` |
| `aislado/limites.md` | Declaración | `6f12775648ba442da8acd15afcda1845c0ff2dc670b5cf89cfcd78f2da7aee27` |
| `aislado/prueba-aislado.txt` | Prueba sin red | `ed0fb6284b32dda65f83299b0574ad7f4675da6465d6068b0b624c512e76dd5e` |
| Salida de `ci-local.sh todo` desde `./aislado` | Verde de referencia | `ee5706de965bf2309bc61bfef61b8f79c64ad38e66402471a67f4f4d091b8435` |
| Ficha 2 de C3a (sin re-sello) | C3a | `f5592471fbeac091b7642567e361d44f23620c5375dddf73066a5cb0bc0ca448` (semilla `d39dfbd`) |

Las huellas del árbol de `compuerta/` y de la imagen coinciden con las que `aislado/huellas.txt` declaró al
construirlas.

**A-01 del brazo A [criterio propio].** `F399` cambió la A-01 para la 1.3 (fila D-18 en §2, §5 nueva, clase H de
D-18). C0 corre con la copia de la 1.2, que existe y es la ficha que acompaña a ese conocimiento. Darle a C0 la de la
1.3 le pediría una decisión que su conocimiento no define.

**Copias viejas en la carpeta de insumos.** La carpeta de insumos de las rondas anteriores todavía guarda el
conocimiento 1.0 (`baa150ab…6d417f`) y la A-01 1.0 (`521ec37e…c6bc643`). **No son insumo de esta ronda.** El montaje
copia desde la carpeta del conocimiento y el coordinador verifica la huella de la tabla antes de entregar.

## 3. Oráculos, n y umbral por grupo de filas

Umbral de M2 = ⌊0,15·*n*⌋, sin cambio (`F399` §5.5). En el brazo B, *n* y umbral van por separado para las filas
heredadas y para las filas de audiencia nuevas (D-18 y D-13 «punto de uso»).

| Caso | Brazo | Oráculo | Huella | *n* heredadas | Umbral | *n* audiencia | Umbral | Clase H |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| C0 | A | Oráculo 3 (`F203` §4.1) | `e553c186c996f1ca1f1ff91e7b813fbcab0322ae7c29bf811e60f5862e263a00` | 24 | 3 | − | − | 5 (`F200` §4.1) |
| C1 | B | Oráculo O3 ronda 3 | `e956db681333a48ce3d509200337d0b7edb96ee64e820dad3288d2c0b894bc5a` | 23 | 3 | 12 | 1 | 5: D-03, D-09, D-11, D-12, AUD-09 |
| C2 | B | Oráculo O3 ronda 3 | `f8c9cddab071737b87faa1183bbe2f8dbdf4395ef0f0f957f09d42b475f1f827` | 25 | 3 | 16 | 2 | 5 (sólo la cuenta) |
| C3a | B | Oráculo O3 ronda 3 | `84ba6248c01fc3d7ea64ceaf6541f1c4d227ecaa3e110670beb94a760035f8c3` | 21 | 3 | 12 | 1 | 6 fijas (D-03, D-09, D-11, D-12, AU-09, AU-10) y 2 condicionales: AU-05 sólo si la respuesta propone una jerarquía; D-01 sólo en la lectura (c) |

- Los oráculos de C1, C2 y C3a son versión nueva por decisión nueva (`F399` A-14), escritos por un agente distinto
  del autor del conocimiento y de los aplicadores (P-26 de `F099`). Los anteriores quedan intactos.
- **C3a, ficha:** el autor del oráculo asentó que **no se re-sella**: la tabla de perfiles de la ficha 2 basta para
  decidir D-18 (`F399:354`). Sigue con su huella.
- **C2:** sólo huella y cifras; el oráculo no se publica.
- Ningún oráculo se publica antes del folio de resultado (`F206`).

## 4. Protocolo

1. Rige `F202` (coordinador, canal, auditoría a posteriori) con la carta del aplicador 3 y la del coordinador 2.
2. **Todo comando por `./aislado`, sin red.** La carpeta `coordinacion/` queda ilegible para el aplicador (modo
   `000`).
3. **Límite estructural PR2-4, declarado** (`aislado/limites.md`, L-1): el índice de memoria que el arnés inyecta a
   toda sesión no se puede quitar con el arnés de esta ronda. No se presenta como corregido. Control: la auditoría de
   términos heredados del entorno de la carta del coordinador 2. Un término del índice que aparece en la salida y no en
   el directorio de la corrida es observación, y ANULADA si sostiene un valor; uno presente también en el repositorio
   se cuenta aparte como «no atribuible». También se declaran L-2 (la herramienta de lectura no pasa por
   `./aislado`), L-3 (la consola sin `./aislado` no se puede impedir) y L-4 (qué hace la compuerta sin red), cada
   uno con su control.
4. ANULADA se re-corre con aplicador nuevo y los mismos sellos (`F202` §5).
5. Las re-corridas de C0 de `F204` §9.3 con la 1.1 quedan reemplazadas por las dos de C0 del brazo A con la 1.2. Si
   alguna se corrió antes de este folio, su resultado va a `F206` como diagnóstico, fuera de la métrica.

## 5. Métrica y criterio

- Métrica e de `F099:406-416`, sin cambio.
- **Brazo B: M2 por grupo de filas** (`F399` §5.5): heredadas contra su umbral y audiencia contra el suyo. Así se ve
  si falla la corrección de la ronda 2 o falla D-18 (R3-06). La corrida pasa M2 sólo si pasa en los dos grupos.
- Criterio de caso de `F204` §8 sin cambio: un caso responde «sí» cuando sus dos corridas pasan M1–M6.
- No hay ronda adicional ni cambio de criterio (`F399` §5.5).

## 6. Lo no verificado

- La reproducibilidad de la imagen `dac-aislado:1`: es local. Se identifica por su id; una reconstrucción podría
  dar otro id (`limites.md`, L-5).
- Si el índice de memoria inyectado influye en una ficha sin llamadas a herramientas: sólo se controla por términos
  (§4.3).

## 7. Barrido de lo privado

Pasada de `grep -noiEf` sobre este folio con la lista precisa de la ronda 2 y la del conocimiento, que quedan en
`{dir-de-trabajo}/privado/`. **Resultado: 0.** De C2 este folio nombra sólo el alias, la huella y las cifras.

Sigue: ocho corridas · auditorías · peritos · `F206`
