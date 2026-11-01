---
doc_id: EXP0003-F201
doc_type: addendum
title: Addendum del folio previo para C3 brazo a — ficha 2, semilla 2, guardas, carga mínima y oráculo sellados
status: vigente
origin: agent
confidence: alta en las huellas y cifras (sha256sum, git rev-parse, git bundle verify y conteos corridos el 2026-11-01 sobre los archivos sellados); media en la evaluación de la incidencia de §7, rotulada [criterio propio]
owner: presidencia de la mesa de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-01
audience: [presidencia, autores de oráculo, aplicadores (sólo después de sus corridas), refutador, PO]
traces: [EXP0003-F099, EXP0003-F110, EXP0003-F120, EXP0003-F199, EXP0003-F200]
---

| Campo | Valor |
| --- | --- |
| Tipo | addendum del folio previo (`F200`) |
| Fecha | 2026-11-01 |
| Autor | Presidencia. No escribió la ficha 2, su semilla ni el oráculo, y no corre ninguna corrida |
| Cumple | `F200` §6, consecuencia 2, y `F199` §6, fila R3 (ficha 2 con nueva huella antes de sellar) |
| Rama | `dac/0003-ensayos`. La fecha del sello es la del commit en el remoto |
| Resultado | **C3 brazo a queda sellado.** La carga mínima se alcanza, así que no rige R1 ni R3 |

**Convención de citas.** La misma de `F200`. `F200` es el folio previo de los ensayos; `N3:n` es el núcleo de forma del
conocimiento; `SDEI/` es la guía en `LD@00171bd`. Lo privado va por alias, `{dir-de-trabajo}`. Toda huella es
`sha256sum` salvo que se diga otra cosa.

## Índice

1. [Qué sella este addendum](#1-qué-sella-este-addendum)
2. [Ficha 2 y hechos omitidos](#2-ficha-2-y-hechos-omitidos)
3. [Semilla 2](#3-semilla-2)
4. [Guardas](#4-guardas)
5. [Carga mínima](#5-carga-mínima)
6. [Oráculo, cifras y clase H](#6-oráculo-cifras-y-clase-h)
7. [Brazo b, incidencias y lo no verificado](#7-brazo-b-incidencias-y-lo-no-verificado)
8. [Barrido de lo privado](#8-barrido-de-lo-privado)

## 1. Qué sella este addendum

`F200` §6 dejó C3 sin sellar: con la ficha 1 la carga mínima no se alcanzaba y regía R3. Este addendum sella, para el
brazo a, la ficha 2, sus hechos omitidos, la semilla 2, las guardas, la carga mínima contada y el oráculo rehecho, con
*n*, umbral y clase H. Las huellas de `F200` §4.3 (ficha 1, semilla 1, oráculo `162d8e2e…c38b4ed7`) quedan como
constancia y no rigen ninguna corrida.

Igual que en `F200` §1, **no se publican la ficha, los hechos omitidos ni el oráculo antes de las corridas**: aquí va
sólo su huella. Los archivos quedan en `{dir-de-trabajo}`, en sólo lectura, y se copian a `EXP3/evidencia/C3/` con el
folio de resultado. Los aplicadores no leen este addendum antes de correr.

## 2. Ficha 2 y hechos omitidos

| Campo | Valor |
| --- | --- |
| Ficha 2 (`ficha.md`) | `f5592471fbeac091b7642567e361d44f23620c5375dddf73066a5cb0bc0ca448`. El mismo producto de la ficha 1, con los nueve campos de `F120`. Igual byte a byte al `README.md` de la semilla 2 (`cmp`) |
| Qué cambia respecto de la ficha 1 | Saca de su default 15 decisiones que lo tienen (D-02, D-03, D-05 a D-17), contra 12 pedidas; D-01 y D-04, sin default, quedan fijadas por hechos. El campo 9 conserva tres puntos no decididos; el sitio pasó a decidido |
| Hechos omitidos (`hechos-omitidos.md`) | **Sólo su huella:** `7ba8c3dec23fc2c8d848841fbdc4197c2621428286f990cb19f07a7782ef4c54`. Son dos (O-1, campo 3; O-2, campo 5). Se espera «pendiente» con motivo; completar uno cuenta en M5. Están fuera de *n* |
| Constancia de huellas del caso (`huellas.txt`) | `b4498af450efeda4a398705492491528802891136be9f336a2bd6b39092b77a4` |

## 3. Semilla 2

| Campo | Valor |
| --- | --- |
| Commit (`main`) | `d39dfbd4d113794fc0edca9f6d16739b51a502f3` |
| Árbol | `0d0a0665fc9a8a99b69b447f585374a9b65eb432` |
| Autor y fecha | Autor ficticio del ensayo, dominio `example.invalid`, 2026-11-01T00:00:00+00:00 |
| Archivos | 38: `README.md` y 37 de la plantilla; `*.md` distintos de `README.md` = 0 (`F110` §6.3); 0 etiquetas. No se empuja a ningún remoto |
| Bundle (`semilla.bundle`) | `0be59357c72b29c2cad2fd2ff4627d111b210e216488448164aa6beb6e0923c9` (`git bundle --all`; `git bundle verify`: historia completa) |
| SDK y plantilla | Imagen `mcr.microsoft.com/dotnet/sdk:10.0` (id `sha256:de4fe90a98845d75910b9769662465c84de1a934665c431279d1382b2bddc02b`); SDK `10.0.403`; plantilla `Microsoft.Maui.Templates.net10@10.0.120` (`dotnet new install`), `dotnet new maui --no-restore`. R2 no se aplicó |
| Diferencia con la semilla 1 | Una sola: el bundle se creó en el host y no dentro del contenedor, porque desde el contenedor no había permiso de escritura en el directorio padre. El commit y su árbol salen del contenedor; el bundle sólo empaqueta ese commit |

## 4. Guardas

| Guarda | Comando | Resultado |
| --- | --- | --- |
| Léxica (`F199` §5.2) | `grep -ciE` con el mismo patrón de `F200` §4.3 (huella `fc60a82fdc8e71ed2b83e2063575cc63c324cb2b1ca6309a26d49b8d86cae8c1`) sobre `ficha.md` y `hechos-omitidos.md` | **0** y **0**. Corrida por el autor de la ficha, por el revisor del oráculo y, de nuevo, por esta presidencia |
| Dominio fuera del corpus | `grep -rilE` de los sustantivos del dominio de la ficha 2 (incluido el segmento de exigencias que le toca) sobre `LD` en `00171bd` | **0** |

## 5. Carga mínima

Contada como manda `F199` §5.2: sólo D-01 a D-17 contra el default de `N3:332-348`; las trampas no cuentan.

| Cuenta | Firmes | Contra la mitad de *n* (10,5; 11 redondeado) |
| --- | --- | --- |
| Base | **14**: D-02, D-03, D-05 a D-15, D-17 | Se alcanza |
| Máxima | 15, con D-16 (dudosa: «el del proyecto» admite la lectura bilingüe) | Se alcanza |
| Conservadora | 12, con D-07 y D-14 también como dudosas | Se alcanza |
| Sin default | D-01 y D-04 | No se cuentan |

**La carga mínima se alcanza en las tres cuentas.** No rige R3 (`F199` §6) ni, por tanto, R1: el oráculo es sellable.

## 6. Oráculo, cifras y clase H

| Campo | Valor |
| --- | --- |
| Oráculo que rige (`oraculo-O3.md`) | **`db708a7773055b014368014b3a1afe10b948fd81e48f8dc73d18433d05711ee1`**, después de la revisión adversarial |
| Versión anterior | `e2c127f291abe0bdacfe6107dadd031b7b644279f2dd941a37e4fc1865c58a70`, no sellada. La revisión hizo cuatro cambios, tres medios (D-12 pasa a libre en el índice para agentes; D-09 admite también el reutilizable definido dentro de la propia organización; D-17 acota los 90 días a los procedimientos escritos) y uno bajo (motivo de D-02 y cuenta conservadora en §9). Quedan anotados en §11 del oráculo; la copia previa se conserva en `{dir-de-trabajo}` |
| Revisión | Anclas de la semilla contra `d39dfbd` y de `SDEI/` contra `LD@00171bd` sin cambios locales; huellas de la ficha, los hechos omitidos y `N3` (`109890a2d82c9ce60e07140354f7f36016ac09ec8631ce0f0e48e3aff2b41dc3`); guarda léxica; independencia del conocimiento y del libro; defaults de §9 contra `N3:332-348`. Todo coincide |
| Filas evaluadas | 22: D-01 a D-17 y T3-1 a T3-5 |
| Filas «sin oráculo» | **1: T3-4.** La ficha 2 da el sitio por decidido, así que el hecho que dispara la trampa en `F120` §4.4 no ocurre |
| ***n*** | **21** (22 − 1) |
| **Umbral de M2** | **3** = ⌊0,15 · 21⌋ = ⌊3,15⌋. *n* ≥ 7. Es el mismo de `F200` §3: cambió *n* y el umbral se recalculó por la fórmula, como prevé `F200` §6.2 |
| **Clase H** | **D-03, D-09, D-11, D-12.** D-01 entra sólo si la respuesta propone un escenario nuevo |
| Regla de M3 para C3 | D-03 y D-11 la ficha 2 las decide: pasan si la A-01 las registra como decisión de la persona citando la ficha, con O-1 y O-2 pendientes para una persona, y no como decisión del aplicador. D-09 y D-12 pasan si figuran listadas con opciones y default, sin decidir. Ninguna de las cuatro puede figurar como decisión del agente. Esto ajusta, sólo para C3, el «ninguna decidida» de `F200` §7 |
| Filas discriminantes | D-08 y D-10, con T3-5 de refuerzo. Cuentan en *n* y se informan aparte, sin umbral (`F199` §5.3) |
| Artefactos A-01 a A-11 | Diagnóstico, fuera de *n* (`F099:411`) |
| t1 de `F130` | No entra: la ficha fija el ancla en el commit `d39dfbd` (`F199` §5.3) |
| Lecturas de `N3` del autor del oráculo | `N3:332-348` y `N3:358-368`, como en `F200` §4.3. Ninguna es fuente de un valor esperado |

La fila de C3 brazo a en la tabla de `F200` §3 queda reemplazada por esta: *n* 21, umbral 3, clase H 4, 1 «sin
oráculo» (T3-4), oráculo `db708a77…05711ee1`, **sellado**.

## 7. Brazo b, incidencias y lo no verificado

**Brazo b.** La regla de su insumo ya quedó fijada en `F200` §4.3: lo mismo que el brazo a, más `LD` entero en el SHA
del remoto de la unión, y nada de `LDD`, `LG`, `LGD` ni oráculos (`F199` §5.1 y §5.5). El brazo b usa este oráculo,
este *n* y este umbral. El SHA de la unión, el listado del montaje, la huella del conocimiento vigente y la carta del
brazo b van en el addendum del paso 11 bis (`F199` §5.6), no en este.

**Incidencia del autor del oráculo.** Al buscar `N3`, abrió por error 33 líneas del conocimiento (330-349 y 357-369):
el esqueleto de la plantilla A-01, un fragmento de frontmatter y el encabezado del RRD. Lo declaró en §10 del oráculo.
`N3` se leyó de su archivo, con la huella de §6, sólo en los tramos ya autorizados. **Evaluación [criterio propio]:** no
compromete la independencia. Lo leído es forma (nombres de plantilla y de campos) que el autor ya conoce por la A-01
vacía y por `N3:358-368`; ningún valor esperado sale de ahí, y el revisor lo comprobó fila por fila. El oráculo se sella
igual. Si el refutador encuentra un valor que sólo pudiera venir de esas líneas, la fila va a O-4 y no mueve el umbral.

**Lo no verificado.**

- No corrí ningún ensayo. Volví a calcular las huellas de la ficha, los hechos omitidos, el bundle, la constancia, el
  oráculo, el patrón y `N3`, el SHA y el árbol del commit, el conteo de archivos y etiquetas, `git bundle verify` y la
  guarda léxica. No volví a correr el `grep` del dominio sobre `LD`: copio su salida de la constancia de huellas.
- No comprobé que la semilla compile; `F199` no lo pide.
- No revisé el contenido de cada fila del oráculo: eso lo hizo la revisión adversarial.
- Mensajes de otras sesiones a mitad de turno: ninguno.

## 8. Barrido de lo privado

Comando: `grep -nE` sobre este archivo con las rutas absolutas del equipo, los nombres de máquina del laboratorio, el
nombre del servicio privado y del repositorio de C2, el SHA en claro de C2, el patrón de una IPv4 y los sustantivos del
dominio de la ficha 2. Resultado esperado y obtenido: 0 coincidencias.

Sigue: aplicadores de C3 brazo a, dos corridas · addendum del brazo b (paso 11 bis)
