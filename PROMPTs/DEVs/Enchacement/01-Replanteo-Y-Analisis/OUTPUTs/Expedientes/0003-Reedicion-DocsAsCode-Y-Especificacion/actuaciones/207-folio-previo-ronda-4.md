---
doc_id: EXP0003-F207
doc_type: folio-previo
title: Folio previo de la ronda 4 de los ensayos — conocimiento 1.4 y 1.2, oráculos corregidos, cartas nuevas y aislamiento total del aplicador
status: vigente
origin: agent
confidence: alta en las huellas (sha256sum corrido el 2026-11-02 sobre cada insumo); media en la elección de la 1.2 para el brazo A y en la lectura de la numeración de A-01 para C0 (§6), rotuladas [criterio propio]; la prueba de 14 casos de la guardia se toma del informe de su autor, sin salida archivada (§7)
owner: presidencia de la mesa de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-02
audience: [presidencia, coordinador, autores de oráculo, autor del conocimiento, peritos, refutador, PO]
traces: [TP:18, TP:20, EXP0003-F099, EXP0003-F202, EXP0003-F205, EXP0003-F206, EXP0003-F399]
---

| Campo | Valor |
| --- | --- |
| Tipo | folio previo |
| Fecha | 2026-11-02 |
| Autor | Presidencia. No escribió ningún oráculo, el conocimiento ni las cartas, y no corre ni coordina ninguna corrida |
| Cumple | `F206` §9 (conocimiento 1.4, oráculos corregidos, cartas nuevas, ronda 4 sellada antes de la primera corrida) |
| Resultado | **Ronda 4 sellada.** Ocho corridas: brazo A (C0, conocimiento 1.2) y brazo B (C1, C2, C3a, conocimiento 1.4), dos por caso, con coordinador y **aplicador en aislamiento total**. Ninguna corrida empieza antes de este commit |
| Rama | `dac/0003-ensayos` |

**Convención de citas.** La misma de `F200`. `EXP3/` es la carpeta de este expediente. Lo privado va por alias:
`{area-de-ensayo}` (raíz del área de ensayos), `{servicio-privado}`. Toda huella es `sha256sum` corrida el 2026-11-02,
antes de la primera corrida.

## Índice

1. [Qué cambia respecto de la ronda 3](#1-qué-cambia-respecto-de-la-ronda-3)
2. [Aislamiento total del aplicador](#2-aislamiento-total-del-aplicador)
3. [Sellos de los insumos](#3-sellos-de-los-insumos)
4. [Oráculos, n y umbral](#4-oráculos-n-y-umbral)
5. [Validez, métrica y criterio](#5-validez-métrica-y-criterio)
6. [Observación sobre la carta del aplicador 4](#6-observación-sobre-la-carta-del-aplicador-4)
7. [Lo no verificado](#7-lo-no-verificado)
8. [Copias públicas y barrido](#8-copias-públicas-y-barrido)

## 1. Qué cambia respecto de la ronda 3

| Elemento | Ronda 3 (`F205`) | Ronda 4 | Fuente |
| --- | --- | --- | --- |
| Brazo B (C1, C2, C3a) | Conocimiento 1.3 | **Conocimiento 1.4** con su A-01 | `F206` §9.1 |
| Brazo A (C0) | Conocimiento 1.2 | **1.2 otra vez** [criterio propio] | §1.1 |
| Oráculos | Ronda 3 | C1 y C3a corregidos, C2 con nueva huella, C0 sin cambio | `F206` §6 |
| Cartas | Aplicador 3, coordinador 2 | **Aplicador 4, coordinador 3** | `F206` §9.3 |
| Aislamiento | Toda consola por `./aislado`, sin red; L-1 a L-4 declarados | **Aislamiento total**: proceso aparte con guardia | §2 |
| Regla de validez | `F206` §1 | Sin cambio | — |
| Criterio de aptitud | `F206` §9 | Sin cambio | — |

### 1.1 Por qué C0 sigue con la 1.2

`F206` §9.4 dejó la elección a este folio. C0 lleva **tres rondas sin medición válida** (`F206` §7): no hay todavía un
dato de la 1.2 que comparar. Pasarlo a la 1.4 cambiaría dos variables a la vez (conocimiento y aislamiento) y dejaría
otra vez sin respuesta la pregunta del brazo A. Con la 1.2 y el aislamiento nuevo, una corrida válida de C0 mide por
fin la 1.2. C0 no ejercita D-18, así que la 1.4 no le agrega nada que su caso pueda probar.

### 1.2 Conocimiento 1.4

Escrito por su autor, no por la presidencia. Corrige las familias P0 de `F206` §5 y, en su segunda revisión, tres de
cuatro hallazgos: §3.2.1 regla 2 (la inclusión de roles exige que todo punto que autoriza a la menor autorice a la
mayor, con búsqueda completa citada, o una política compuesta explícita; si no, roles planos y fila H «jerarquía»),
§3.7 (tabla de seis acciones: la herramienta de archivo sólo lee o escribe a mano dentro de `{dir-de-corrida}`; todo
cómputo, por el envoltorio) y ejemplos sin choque entre reglas. El cuarto (fila D-10 de A-01 §2) no procede: medidas
las celdas, D-01 a D-18 tienen seis, como la cabecera. El conocimiento 1.4 **no se publica en este folio**: va en el
PR 7.

## 2. Aislamiento total del aplicador

El aplicador ya no es una sesión con el entorno del equipo. Es **un proceso aparte** lanzado por `aplicar.sh`:

- **Directorio de trabajo = la corrida.** Nada fuera de ella es punto de partida.
- **Sin fuentes de configuración ni memoria del usuario** (`--setting-sources ""`, memoria automática apagada). **Esto
  cierra L-1 / PR2-4**, el límite que la ronda 3 declaró y no pudo quitar (`F205` §4.3): ningún índice de memoria ni
  instrucción del usuario llega al aplicador. La carta del coordinador 3 pide comprobarlo en la transcripción y, si
  llegó algo, anotarlo como observación para la presidencia.
- **Sin MCP** (configuración MCP vacía y estricta).
- **Sólo herramientas de archivo y consola**: Read, Write, Edit, Glob, Grep, Bash.
- **Guardia PreToolUse** (`guardia.py`) sobre toda herramienta, probada con 14 casos (§7):
  - consola sólo `./aislado …`; sin operadores (`;`, `&&`, `|`, redirecciones) ni expansiones del host (`$`, comillas
    invertidas); las tuberías sólo dentro de `./aislado bash -c '…'`;
  - archivos sólo de la corrida propia;
  - `coordinacion/` cerrada;
  - enlaces simbólicos resueltos antes de decidir, para que no se salga de la corrida por un enlace.
- Lo que la guardia rechaza queda en su registro, una línea por llamada; la carta del aplicador 4 prohíbe reintentarlo
  por otra vía y manda anotarlo como dato faltante.

Con esto L-2 (lectura fuera de `./aislado`) queda acotada a la corrida propia y L-3 (consola sin `./aislado`) pasa de
«no se puede impedir» a rechazada por la guardia. L-4 y L-5 (`F205` §6) siguen como estaban.

## 3. Sellos de los insumos

| Insumo | Uso | Huella |
| --- | --- | --- |
| Conocimiento 1.2 | Brazo A | `aeb9135f60c3177a98c5c97eac1e272e889d10ab8a07b5b3df0827d3d85716d8` |
| A-01 vacía de la 1.2 | Brazo A | `8af70465bd0e834fddfa795f4dec2b8eb5cf595045a106e1f34775808d716cac` |
| Conocimiento 1.4 | Brazo B | `cc489f3e84f53b869af4eb597c60f35fb801b383c3923d7856785e8cda51aede` |
| A-01 vacía de la 1.4 | Brazo B | `8bddb672939b1b3b0f079a0bcfe8f7c81e8d4106464e45b9f1b6903e0b57c264` |
| Carta del aplicador 4 | Las ocho | `1dea73f38ce13696659d385ff2910e632aba1ab550460d5c2b464acdf04883ca` |
| Carta del coordinador 3 | Las ocho | `85698a6588d05b86e3c4a9416e7dd48ce186ed4e8431869bb99e1021fe8e5280` |
| `aislado/aplicar.sh` | Las ocho | `d4ee0f9004d2785d008f08393be001b5d5c56cd2f6a0549e3c7245d71f79450a` |
| `aislado/guardia.py` | Las ocho | `86ac1fd0a33e6599096754d3445a6d61850587f6b429429f2e1a9326f5f33bad` |
| `aislado/guardia-settings.json` | Las ocho | `5213b1ea3b84f3316d262a135627ed706467f217b715159a173e37397a6c8bc9` |
| `aislado/aislado.sh` | Las ocho | `989424ee5667ca9666a9ff9f2e85806dcb89ab7d349e97373d32a2885258a930` (sin cambio) |
| `aislado/Dockerfile` | Las ocho | `60c194f2f3f831f56ebc795fd3ddc0cd8ccb0ae70ca5997aefadc62c8419b16f` (sin cambio) |
| `aislado/huellas.txt` | Las ocho | `cb740a5ac28e85af39954ff8cf96328c0f396d7af7b53fc54baef62bef48825f` (sin cambio) |
| `compuerta/` (árbol) | Las ocho | `f58f5061d4db853a7489b8d2cbf218028ce1b6ec4ec8c9983e8474eb21d83ede` (sin cambio) |
| Imagen `dac-aislado:1` | Las ocho | sin cambio (`F205` §2) |

**Montaje.** Ocho corridas, seis en el área pública de ensayos y dos (C2) en la privada. En las ocho, `conocimiento.md`,
`A-01-ficha-vacia.md` y `carta-aplicador-4.md` coinciden con la huella de su brazo; `repo/` es copia exacta del de la
corrida r1 homóloga de la ronda 3; `coordinacion/` en modo `000`; `salida/` vacía; en C0 `SDEI/` sigue en `000`;
`./aislado ls repo` corre en las ocho. El registro de la guardia de la prueba se apartó y la carpeta de prueba se
borró.

## 4. Oráculos, n y umbral

Umbral de M2 = ⌊0,15·*n*⌋, sin cambio. Por O-4 (`F016` §4.3) ninguna corrección fusiona filas: *n* y umbral iguales a
la ronda 3. Los oráculos de la ronda 3 quedan intactos; los corregidos son archivos nuevos que citan la huella del
anterior.

| Caso | Brazo | Oráculo | Huella | *n* heredadas | Umbral | *n* audiencia | Umbral | Cambios (`F206` §6) |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| C0 | A | Oráculo 3 | `e553c186c996f1ca1f1ff91e7b813fbcab0322ae7c29bf811e60f5862e263a00` | 24 | 3 | − | − | Ninguno |
| C1 | B | O3 ronda 4 | `564daf29819db457e3ceee8977e329e114f6f8ff1f8b2192bcaa2441eb0077ac` | 23 | 3 | 12 | 1 | E-1: «decidida por {actor}» con ancla ruta:línea a una decisión escrita coincide en la regla H y en D-11. E-3: AUD-10 cubre también el alcance. E-2 (CL-04 fuente o salida) sigue como pregunta a la mesa; mientras tanto rige el oráculo |
| C2 | B | O3 ronda 4 | `4ba0816d7db3998e49041a40d74f7ab3ec42beff6fa5abd31a4b3bbe29cf2c43` | 25 | 3 | 16 | 2 | 4 (sólo la cuenta) |
| C3a | B | O3 ronda 4 | `e0ae58f7a199667d3250f2307b39ba9176084b67492ea493d8dd223d7612913e` | 21 | 3 | 12 | 1 | E-1: lectura (b) de D-01 sin alta motivada de paquete, curso o sitio queda excluida. E-2: la omisión del build se cuenta una vez, en D-10; no se fusionan filas. E-3: enlaces externos de D-17 pasan a libres con nota. E-5: H decidida dada por abierta con default excluido falla M2 y M3. E-4 no procede |

**C3a, E-2.** `F206` §6 dijo «una fila sola». El autor del oráculo no fusionó filas: dejó D-03 con la activación de
CL-14 y D-10 con la omisión, porque son decisiones distintas, y la omisión se cuenta una sola vez. Así *n* = 21 y el
umbral 3 se conservan, como pide O-4. La presidencia lo acepta: corrige el doble conteo, que era el error.

Ningún oráculo se publica antes del folio de resultado (`F208`). El de C2 no se publica nunca: sólo huella y cifras.

## 5. Validez, métrica y criterio

- **Regla de validez de `F206` §1, sin cambio.** Con la guardia, la consola del host fuera de `./aislado` debería
  quedar rechazada; si igual aparece, la regla se aplica tal cual.
- Métrica e de `F099:406-416` y M2 por grupo de filas en el brazo B (`F205` §5), sin cambio.
- **Criterio de aptitud de `F206` §9, sin cambio**: la 1.4 queda apta para el PR 7 cuando cada caso del brazo B tiene al
  menos una corrida válida que pasa y no queda abierto ningún defecto P0.
- ANULADA se re-corre con aplicador nuevo y los mismos sellos (`F202` §5).

## 6. Observación sobre la carta del aplicador 4

La carta sellada conserva, al principio, una nota del autor para la presidencia: al escribirla la A-01 1.4 no existía
y tomó la numeración de una A-01 idéntica a la 1.3 (artefactos en §6, lo no resuelto en §7). Confrontada con la A-01
1.4 sellada, **la numeración coincide** (§6 «Artefactos A-02 a A-13», §7 «Lo que el conocimiento no resolvió»).

En la A-01 de la 1.2 (brazo A) la numeración es otra: artefactos en §5 y lo no resuelto en §6. **[criterio propio]**
La nota no se quita, porque la carta ya está montada en las ocho corridas con esta huella y quitarla obliga a
re-sellar y re-montar. Para C0, una referencia de la carta a §6 o §7 se lee como la sección del mismo título en su
A-01; el coordinador de C0 lo hace saber al aplicador si pregunta, y el perito no cuenta como defecto que C0 use la
numeración de su ficha.

## 7. Lo no verificado

- **La prueba de 14 casos de la guardia** se toma del informe de su autor. Su salida no quedó archivada: el registro
  de la prueba quedó vacío al apartarlo. Una corrida de prueba completa con `aplicar.sh` tampoco se hizo.
- Que el arnés respete `--setting-sources ""` y la memoria apagada se comprueba en cada transcripción (carta del
  coordinador 3), no antes.
- La reproducibilidad de la imagen `dac-aislado:1` (L-5), como en `F205` §6.

## 8. Copias públicas y barrido

En `EXP3/evidencia/ronda-4/insumos/` van las dos cartas, `guardia.py`, `guardia-settings.json` y `aplicar.sh`. **En las
copias públicas, las rutas absolutas del área de ensayos se reemplazaron por el marcador `{area-de-ensayo}`.** Por eso
su huella difiere de la sellada en §3 en todas salvo la carta del aplicador 4, que no tenía rutas:

| Copia pública | Huella |
| --- | --- |
| `carta-aplicador-4.md` | `1dea73f38ce13696659d385ff2910e632aba1ab550460d5c2b464acdf04883ca` (igual al sello) |
| `carta-coordinador-3.md` | `eb985a20df30b62c2dec2d4c9dcbd7bd5dd78296e69159c388eea8d97a23c5e3` |
| `guardia.py` | `86286ab38d7203853d7ce2641d38809ae2ec9ffb9db6dfcbbe362058e2bdd78c` |
| `guardia-settings.json` | `fe783a70a6406bf97543ea2043b5f623cd3186817d5b7ecab7efc145d5079982` |
| `aplicar.sh` | `2754fde7ffd19bc4793ed71b9447137c88cc62a943be19ce4f3f2e1da135979c` |

Para comprobar una copia contra el sello: reemplazar `{area-de-ensayo}` por la ruta real y correr `sha256sum`.

Pasada de `grep -noiEf` sobre este folio y `evidencia/ronda-4/**` con la lista precisa del expediente, más los nombres
de las máquinas del entorno. **Resultado: 0.** De C2 este folio nombra sólo el alias, la huella y las cifras.

Sigue: ocho corridas · auditorías · peritos · `F208`
