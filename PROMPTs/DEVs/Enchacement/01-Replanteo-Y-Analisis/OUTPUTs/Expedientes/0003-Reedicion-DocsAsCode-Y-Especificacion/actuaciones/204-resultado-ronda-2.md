---
doc_id: EXP0003-F204
doc_type: resultado
title: Resultado de la ronda 2 de los ensayos — validez, métrica e, defectos del conocimiento 1.1, juicio de oráculos y respuesta a TP:20
status: vigente
origin: agent
confidence: alta en las cifras (copiadas de los informes de los peritos y de las auditorías de los coordinadores) y en las huellas (sha256sum corrido el 2026-11-01 sobre los oráculos publicados); media en la decisión sobre las cinco auditorías dudosas, en el cruce de los defectos con DK-nn, en el criterio de caso y en la propuesta de 1.2, rotulados [criterio propio]
owner: presidencia de la mesa de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-01
audience: [presidencia, coordinador, autores de oráculo, peritos, refutador, PO]
traces: [TP:18, TP:20, TP:70, EXP0003-F099, EXP0003-F199, EXP0003-F200, EXP0003-F201, EXP0003-F202, EXP0003-F203]
---

| Campo | Valor |
| --- | --- |
| Tipo | resultado |
| Fecha | 2026-11-01 |
| Autor | Presidencia. No escribió ningún oráculo ni el conocimiento, y no corrió ni coordinó ninguna corrida |
| Cumple | `F200` §1 (folio de resultado), `F202` §5 (decide las auditorías dudosas) y `F203` §6.4 (copia de registros y auditorías) |
| Resultado | **Una corrida de ocho pasa (C2-r2), y con reserva. Ningún caso pasa.** Las dos de C0 quedan ANULADAS y se re-corren. El conocimiento 1.1 no alcanza todavía (`TP:20`). La mitad «nuevos» de `TP:18` queda **ejercitada y no probada**. Se propone la 1.2 y una ronda 3 (§9) |
| Rama | `dac/0003-ensayos` |

**Convención de citas.** La misma de `F200`. `EXP3/` es la carpeta de este expediente. Lo privado va por alias:
`{dir-de-trabajo}`, `{host-de-pruebas}`, `{servicio-privado}`, `{worktree-LD}`. Toda huella es `sha256sum`. Las
cifras son las de los informes de cada caso (§10); no volví a medir.

## Índice

1. [Validez de las corridas](#1-validez-de-las-corridas)
2. [Métrica e de la ronda 2](#2-métrica-e-de-la-ronda-2)
3. [M7 por caso](#3-m7-por-caso)
4. [Comparación con la ronda 1](#4-comparación-con-la-ronda-1)
5. [Defectos del conocimiento 1.1](#5-defectos-del-conocimiento-11)
6. [Defectos del protocolo y del montaje](#6-defectos-del-protocolo-y-del-montaje)
7. [Juicio de los errores del oráculo](#7-juicio-de-los-errores-del-oráculo)
8. [Respuesta a TP:20 y la mitad «nuevos»](#8-respuesta-a-tp20-y-la-mitad-nuevos)
9. [Versión 1.2 y ronda 3](#9-versión-12-y-ronda-3)
10. [Evidencia publicada](#10-evidencia-publicada)
11. [Lo no verificado](#11-lo-no-verificado)
12. [Barrido de lo privado](#12-barrido-de-lo-privado)

## 1. Validez de las corridas

Ocho corridas: C0, C1, C2 y C3 brazo a (C3a), dos cada una, con la carta 2, un coordinador por caso y el canal de
demandas (`F202`). Cada coordinador auditó el registro de herramientas de su aplicador con el criterio de `F202` §5.
Dos corridas salieron ANULADAS, una VÁLIDA CON OBSERVACIÓN y cinco DUDOSAS, que decide esta presidencia.

**Regla de decisión para las dudosas** **[criterio propio]**. `F202` §5 anula cuando «un valor sale de material
externo». Un contenido fuera del límite que sólo llega a la sección de notas sobre el conocimiento de A-01, o a un
campo de cabecera que ninguna medida M1–M6 cuenta, no es un valor medido: la corrida queda **VÁLIDA CON OBSERVACIÓN**
y el hecho se informa. Si llega a una decisión, una clase, un artefacto o una verificación, la corrida se anula.

| Corrida | Auditoría | Hecho | Decisión de la presidencia |
| --- | --- | --- | --- |
| C0-r1 | ANULADA | La autoprueba de origen (`ci-local.sh autoprueba`) corrió `npx markdownlint-cli2` y fue por red al registro de npm, con un paquete de la caché de npm fuera del directorio. Su resultado entra en `A-01.md:144`, que además dice «sin red» | **ANULADA** (red). Se re-corre |
| C0-r2 | ANULADA | La misma autoprueba por `npx`; `A-01.md:120` («48 ok») depende de ella. Además escribió un temporal fuera de `salida/` | **ANULADA** (red y escritura fuera). Se re-corre |
| C1-r1 | DUDOSA | En su ronda 2 leyó `coordinacion/registro.md`; una fila de §6 de A-01 repite casi literal el juicio de Q-1 | **VÁLIDA CON OBSERVACIÓN**: la fila está en §6 (notas sobre el conocimiento), no en un valor medido |
| C1-r2 | DUDOSA | Ídem; dos filas de §6 (sobre D-06 y D-09) repiten comentarios del coordinador | **VÁLIDA CON OBSERVACIÓN**, mismo motivo |
| C2-r1 | VÁLIDA CON OBSERVACIÓN | Leyó la salida guardada de su propio comando; arrancó con el contexto del entorno, que ningún valor usa | Confirmada |
| C2-r2 | DUDOSA | Leyó `coordinacion/registro.md`; §6 de A-01 repite la observación de Q-4. El coordinador comprobó que cada valor se deriva también de `conocimiento.md` | **VÁLIDA CON OBSERVACIÓN**, mismo motivo. Es la única corrida que pasa: va con reserva (§2) |
| C3a-r1 | DUDOSA | «Quién aplica» lleva el nombre del modelo y «Fecha» la del entorno (`A-01.md:6-7`); `git status` reescribió el caché `.git/index` con contenido idéntico a `d39dfbd` | **VÁLIDA CON OBSERVACIÓN**: son campos de cabecera que no mide ninguna M; el árbol no cambió (M4: HEAD `d39dfbd`, `ls-files` = `ls-tree`) |
| C3a-r2 | DUDOSA | «Fecha» y `last_review` sin comando, iguales a la del entorno; el mismo `git status` | **VÁLIDA CON OBSERVACIÓN**, mismo motivo |

**`SDEI/` en C0.** En las dos corridas, comandos recursivos sobre todo el árbol intentaron entrar a `SDEI/` y
recibieron «Permiso denegado», sin contenido. La exclusión del montaje (`F203` §6.4) funcionó: es **observación**, no
anulación **[criterio propio]**. No cambia nada, porque la red ya anula las dos.

**Contexto heredado del entorno.** Las ocho sesiones de aplicador arrancaron con el índice de memoria y las
instrucciones generales del entorno: **la condición de despacho de `F203` §6.4 no se cumplió en ninguna**. Las
auditorías no encontraron un valor de decisión, clase, artefacto o verificación que salga de ese contexto (en C0-r2
quedó un término dudoso de D-16 con un indicio en el repo). Con el registro sólo se prueba que ningún valor depende
de él, no que no haya influido en dónde buscar. Va como defecto del despacho (§6).

## 2. Métrica e de la ronda 2

Insumos sellados en `F203` §6.1 y §6.2 (conocimiento 1.1 `afd741b8…483e8`, A-01 `0fa85977…72bc`, carta 2
`ca263a77…6ec19a`), comprobados por cada perito sobre las copias montadas. M2 con los umbrales sellados (3 en los
cuatro casos). «−» = no se mide.

| Corrida | Validez | M1 | M2 (≤ 3) | M3 | M4 | M5 | M6 | Demandas / «sí» | Corrida |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| C0-r1 | ANULADA | − | − | − | − | − | − | 6 / 0 (1 dudosa) | **No se mide** |
| C0-r2 | ANULADA | − | − | − | − | − | − | 6 / 2 (4 dudosas) | **No se mide** |
| C1-r1 | VCO | 17/17, pasa | 3, pasa | 4/4, 0 decididas, pasa | 0 | 0 | No pasa: rojo en trazas (4 `id-duplicado` por `doc_id` y encabezado con el mismo ID; una traza que no resuelve) | 8 / 2 (2 dudosas) | **No pasa** (M6) |
| C1-r2 | VCO | 17/17, pasa | 5, no pasa | 4/4, 0 decididas, pasa | 3 | 3 | No pasa: rojo en esquema (marcador como `doc_id`) | 5 / 1 (1 dudosa) | **No pasa** (M2, M4, M5, M6) |
| C2-r1 | VCO | 17/17, pasa | 3, pasa | 4/4, 0 decididas, pasa | 0 | 0 | No pasa: no produjo el registro, el esquema ni las excepciones; con la configuración de origen, rojo de esquema | 4 / 0 (2 dudosas) | **No pasa** (M6) |
| C2-r2 | VCO | 17/17, pasa | 3, pasa | 4/4, 0 decididas, pasa | 0 | 0 | Pasa: PR-1 a PR-7 en verde, rojo plantado visto en trazas, autoprueba de origen verde | 6 / 3 (1 dudosa) | **Pasa, con reserva** |
| C3a-r1 | VCO | 17/17, pasa | 7, no pasa | 2/4, no pasa | 0 | 0 | No pasa: rojo en esquema («Dada» en vez de «Dado») y en trazas (A-01 sin `doc_id`) | 7 / 0 (1 dudosa) | **No pasa** (M2, M3, M6) |
| C3a-r2 | VCO | 17/17, pasa | 7, no pasa | 2/4, no pasa | 0 | 1 | Pasa con reserva: verde sólo con A-01 montada; A-07 y el JSON de A-03 los armó el perito | 5 / 0 (1 dudosa) | **No pasa** (M2, M3, M5) |

VCO = VÁLIDA CON OBSERVACIÓN.

**La reserva de C2-r2.** Su M2 está en el umbral, y una fila discutible (prefijo del RRD ya usado en el repo con otro
sentido) lo decide: con la lectura estricta sube a 4 y no pasa. El juicio de §7.3 deja la medición del perito como
está, pero esa corrida no se cuenta como prueba de suficiencia (§8).

**M3 de C3a.** Las dos corridas reabren D-03 y D-11, que la ficha registra como decididas por una persona, y no listan
O-1 ni O-2 (regla de M3 propia de C3, `F201` §6). Es el defecto DC3a-01 (§5).

**Demandas.** 47 en total en las ocho corridas (C0 12, C1 13, C2 10, C3a 12), todas en una sola ronda del canal y
todas «no disponible» salvo una con material parcial (C1-r2 Q-5). Los «sí» (el conocimiento debió cubrirlo) son 8:
C0-r2 Q-1 y Q-4; C1-r1 Q-7 y Q-8; C1-r2 Q-3; C2-r2 Q-4, Q-5 y Q-6. Las dudosas se resuelven en el cruce de §5, sin
cambiar ninguna cifra. Ninguna demanda «sí» terminó en una suposición.

## 3. M7 por caso

M7 es diagnóstico sin umbral: cada diferencia entre las dos corridas de un caso es un defecto del conocimiento.

| Caso | Diferencias | Lectura |
| --- | --- | --- |
| C0 | No se mide | Las dos ANULADAS. Como diagnóstico: los dos aplicadores corrieron la autoprueba creyéndola fuera de línea, y en las dos dio rojo con las mismas fallas (enlaces y mermaid, por herramientas ausentes). Ninguno de los cinco temas que pidieron las dos recibió la misma clasificación de los dos coordinadores |
| C1 | 20 (ronda 1: 14) | Concentradas en lo que depende de la compuerta ausente (patrón 1, espacios de IDs, A-02, A-09, D-07, ruta de la copia), en prefijos por defecto, en la forma de A-05 y A-11 y en el M5 ante las mismas lagunas. Desaparecen las de CL-04, D-08, D-09, D-10 y la forma de la tabla |
| C2 | 19 (ronda 1: 23) | Ubicaciones (CL-04/05, CL-11), prefijos y rango del RRD, D-11, visibilidad en D-14 (donde además el canal contestó distinto la misma demanda), artefactos producidos o no (A-02, A-03, A-07, A-08), forma de A-09 y A-11, patrones 3 y 4 |
| C3a | 20 (primera ronda) | Frontmatter de A-01, «Quién aplica», CL-05/08/11, líneas de D-06, prefijos y carpeta de la copia, campos de D-08, D-10 heredado, default de D-12, A-07 y A-10 producidos o no, «Dada» frente a «Dado». Estables en las dos: D-03, D-10, D-11, D-17, T3-2 y la compuerta pendiente |

Patrón común: **la mayor fuente de inestabilidad es la compuerta de origen**, que el conocimiento pide (§8) y el
montaje no trajo. Sin ella cada aplicador improvisa un camino distinto, y M6 lo decide quien haya producido o no los
artefactos de configuración.

## 4. Comparación con la ronda 1

Ronda 1 con el conocimiento 1.0 (`F203` §1); ronda 2 con la 1.1.

| Caso | Medida | Ronda 1 (r1 / r2) | Ronda 2 (r1 / r2) | Lectura |
| --- | --- | --- | --- | --- |
| C0 | Corrida | No pasa / No pasa | ANULADA / ANULADA | Sin comparación. La 1.1 introdujo la autoprueba en la copia de origen (DK-03) sin decir que necesita red: el arreglo de la ronda 1 causó la anulación de la ronda 2 |
| C0 | M2 · M5 | 6 · 6 / 3 · 5 | − / − | |
| C1 | M2 | 9 / 8 | 3 / 5 | Baja fuerte; r1 entra en el umbral |
| C1 | M4 · M5 | 0 · 6 / 0 · 4 | 0 · 0 / 3 · 3 | r1 limpia; r2 empeora en M4 |
| C1 | M6 | Con reserva / rojo | Rojo / rojo | La familia G sigue: ahora por la forma de los IDs y los prefijos por defecto |
| C1 | M7 | 14 | 20 | Más inestable |
| C2 | M2 | 9 / 11 | 3 / 3 | Baja fuerte; las dos en el umbral |
| C2 | M4 · M5 | 0 · 4 / 1 · 5 | 0 · 0 / 0 · 0 | Disciplina de evidencia resuelta |
| C2 | M6 | Condicional / condicional | No pasa / pasa | La separación de las dos copias de §5.7 funciona cuando los artefactos existen |
| C2 | M7 | 23 | 19 | Algo más estable |
| C3a | Todas | No corrió | §2 | Primera medición |

**Lectura.** La 1.1 corrigió lo que se propuso corregir: M5 cae a 0 en cuatro de las seis corridas
medidas (venía de 4 a 6 en la ronda 1) y M2 baja a 3 en tres de ellas (C1 y C2 venían de 8 a 11). Lo que no mejora es M6 y M7: dependen de la compuerta, y la 1.1 la
supuso disponible.

## 5. Defectos del conocimiento 1.1

Los peritos encontraron **66 defectos** del conocimiento: C0 7 (K2-01…K2-07), C1 20 (DC1R2-01…20), C2 18
(K2-01…K2-18, genéricos) y C3a 21 (DC3a-01…21). Los textos y arreglos de cada uno están en los informes (§10).

### 5.1 Repetición de la ronda 1

Cruce por sección y causa con los 27 consolidados de la ronda 1
([`evidencia/ronda-1/defectos-consolidados.md`](../evidencia/ronda-1/defectos-consolidados.md)) **[criterio propio]**.
«Repite» quiere decir que el arreglo de la 1.1 para ese DK no alcanzó en la misma sección.

| Caso | Repiten un DK | Nuevos |
| --- | --- | --- |
| C0 | 3: K2-03 (DK-18), K2-05 (DK-23), K2-06 (DK-15) | 4: K2-01 (red de la autoprueba, causado por el arreglo de DK-03), K2-02 (carpetas excluidas o ilegibles), K2-04 (carpeta que existe sin permiso), K2-07 (demandas de lo ya resuelto como pendiente) |
| C1 | 19: 01 y 08 (DK-03), 02 (DK-14), 03 (DK-13), 04, 12, 13 y 15 (DK-16), 05 (DK-22), 06 (DK-05), 07 (DK-01), 09 (DK-17), 10 (DK-05/06), 11 y 20 (DK-09), 14 (DK-04/11), 16 (DK-11), 17 (DK-23), 18 (DK-19) | 1: DC1R2-19 (filas mínimas del RRD) |
| C2 | 17: 01 (DK-11), 02 (DK-07), 03 (DK-01/02/03), 04, 10 y 11 (DK-05), 05 (DK-23), 06 (DK-13), 07 (DK-19), 08 (DK-17), 09 (DK-16), 12 (DK-14), 13 (DK-24), 14 (DK-15), 16 (DK-09), 17 (DK-04), 18 (DK-18) | 1: K2-15 (trazas mínimas y comillas en YAML) |
| C3a | 15: 02 (DK-10), 03 (DK-19), 04 (DK-20), 05 (DK-04), 07 (DK-09), 08 (DK-01/09), 10 (DK-03), 11 (DK-08), 12 (DK-13/15), 13 (DK-14), 14 (DK-17), 17 y 19 (DK-11), 20 (DK-15/05), 21 (DK-27) | 6: DC3a-01 (H ya decidida por una persona), 06 (letra localizada sin ancla), 09 (forma literal Dado/Cuando/Entonces), 15 (campos de aprobación de una norma), 16 (origen de «Fecha» y «Quién aplica»), 18 (default de D-12 con sitio) |

Total: **54 repiten** un DK de la ronda 1 y **12 son nuevos**. Los DK que más se repiten son DK-03 y DK-01 (familia
G, la compuerta), DK-05 (IDs y prefijos), DK-09 (rutas por defecto), DK-11 (D-01), DK-15 (evidencia secundaria),
DK-16 (inventario) y DK-19 (delegación). DC3a-01 se apoya en DK-24, pero la causa es otra: el caso de una H ya
decidida no existía en C0–C2.

### 5.2 Familias de la ronda 2

Defectos que aparecen en tres casos o más, con su arreglo para la 1.2 **[criterio propio]**:

| Familia | Defectos | Casos | Arreglo |
| --- | --- | --- | --- |
| R2-A Compuerta de origen | C0 K2-01; C1 01, 08; C2 K2-03; C3a 10, 11 | 4 | Tabla paso → necesita red o herramientas. Sin compuerta, A-02, A-03, A-07 y A-08 se producen igual en el formato del conocimiento, rotulados «sin probar»; sólo el guion y su huella esperan. Comandos sin red para IDs duplicados y espacios de IDs |
| R2-B Prefijos e IDs | C1 06, 07, 10; C2 K2-04, 10, 11; C3a 08, 20 | 3 | Prefijos por defecto libres (procesos, fichas) y comprobación de que están libres con un comando sobre todo el árbol; un ID se declara una sola vez (`doc_id` o H1, no los dos); prefijo en uso → otro o rango con motivo; ámbito interno/externo según lo recorra la compuerta |
| R2-C Delegación y H | C1 18; C2 K2-07, K2-13; C3a 01, 03 | 3 | El PR de adopción con H abiertas es reserva y lo fusiona una persona; una H que el proyecto ya registra como decidida, con `ruta:línea`, se asienta como «decidida por {actor}»; qué ancla asienta una delegación |
| R2-D Anclas y A-09 | C1 09; C2 K2-08; C3a 14 | 3 | Plantilla de `source.lock` (SHA abreviado y completo pendiente); anotar el ancla actual con `ruta:línea` antes de proponer A-09; líneas de versión a futuro como plan |
| R2-E Rutas por defecto | C1 08, 20; C2 K2-16; C3a 07 | 3 | `{copia-proyecto}` fuera de las carpetas verificadas; A-01 lleva `doc_id` cuando va al repo; punteros de A-05 como enlaces a piezas existentes; A-11 un archivo por destino, el de D-12 |
| R2-F Inventario | C0 K2-02, K2-04; C1 04, 12, 13, 15; C2 K2-09; C3a 05 | 4 | `{excluidas}` y carpetas ilegibles declaradas antes del inventario; carpeta ausente = cuenta 0 con el código de salida; `{carpeta-tecnica}` definida; comando para el patrón 6 y para plataformas por máquina; pedir la conclusión, no sólo la cuenta |
| R2-G D-01 roles y contextos | C1 14, 16; C2 K2-01, K2-14; C3a 17, 19 | 3 | Definir «rol»; unión de los escenarios medidos; la tabla de permisos de la descripción del producto cuenta como inventario declarado; evidencia secundaria extendida a contextos de D-01 y a D-03; la subfila sitio hereda la clase de D-03 |
| R2-H Qué no se demanda | C0 K2-05, 06, 07; C2 K2-17, K2-18; C3a 20 | 3 | En §3.5: lo que el conocimiento resuelve como «pendiente» (sin `.git`, sin lista privada, sin índice del hermano, sin compuerta) no se demanda; se anota con la cita de la regla |
| R2-I Barrido y alias | C0 K2-05; C1 17; C2 K2-05 | 3 | Patrones genéricos de D-14 cuando no llega la lista; alias canónicos `{repositorio}` y `{persona}`; comando de visibilidad en una copia sin red |
| R2-J Forma literal | C1 06; C2 K2-15; C3a 09, 16 | 3 | Dado/Cuando/Entonces literal; comillas en valores YAML con «: »; «Fecha» de `date -u` con su salida y «Quién aplica» = rol |

Los defectos de un solo caso (por ejemplo C1 02, 03, 05, 19; C2 K2-02, K2-05, K2-06, K2-12; C3a 02, 04, 06, 12,
13, 15, 18, 21) entran en la 1.2 con el arreglo que dio su perito.

## 6. Defectos del protocolo y del montaje

No son del conocimiento y no cuentan en M7, pero explican la mitad de las incidencias:

| Id | Hecho | Corrección para la ronda 3 |
| --- | --- | --- |
| PR2-1 | Los aplicadores tuvieron red: la carta dice «sin red» pero el entorno no la cortaba (C0) | Aislamiento de red del aplicador por el entorno, no sólo por la carta; caché de npm fuera de su alcance |
| PR2-2 | La compuerta de origen que §8 del conocimiento declara necesaria no estaba en el montaje (C1, C2, C3a) | **Incluirla**: `tools/docs-guard/` y `scripts/` de `LD@00171bd` como insumo con huella, con las herramientas (enlaces, mermaid, markdownlint) ya instaladas en versión fija, para que la autoprueba corra sin red. En C3a, distinta de `SDEI/` (opción a de DC3a-10) |
| PR2-3 | `coordinacion/` era legible para el aplicador; tres corridas leyeron el registro (C1, C2) | `coordinacion/` sin permiso de lectura para el aplicador, como `SDEI/` |
| PR2-4 | Ninguna sesión arrancó sin el índice de memoria (`F203` §6.4) | Lanzar el aplicador con un entorno sin ese índice. Si el arnés no lo permite, declararlo como límite estructural en el folio previo de la ronda 3, con la auditoría de términos de `F203` §2 como control |
| PR2-5 | Dos coordinadores contestaron distinto la misma demanda (C2, D-14), y eso cambió un valor medido | Criterio único: si el material está en `repo/`, la respuesta es «está en el montaje», sin señalar dónde |
| PR2-6 | Fecha y nombre del aplicador tomados del entorno (C3a) | La fecha la da el montaje o un `date -u` registrado; «Quién aplica» es el rol (con R2-J) |

## 7. Juicio de los errores del oráculo

Por O-4 (`F016` §4.3): un oráculo sólo se corrige por error, nunca para acomodar al conocimiento; *n* y umbral no se
mueven. Como en `F203` §4.1, las M2 de la ronda 2 no se recalculan: un oráculo corregido rige desde la ronda 3.

### 7.1 C0

Ningún error alegado. El oráculo 3 (`e553c186…2e263a00`) se publica ahora en
[`evidencia/ronda-2/C0/sellado/oraculo-O3-3.md`](../evidencia/ronda-2/C0/sellado/oraculo-O3-3.md); su huella
coincide con `F203` §4.1. Rige para la re-corrida y para la ronda 3.

### 7.2 C1

| Fila | Alegación | Juicio |
| --- | --- | --- |
| D-06 «sin `base_commit`» | Estado actual o diseño | **No procede.** Es el estado actual; proponer A-09 con `base_commit` coincide. Lectura del perito confirmada |
| D-07 «prefijos externos del SDD» | El conocimiento llama interno a lo declarado en el repo (`conocimiento.md:440`) | **No procede.** El oráculo y la ficha hablan de los mismos prefijos y del mismo registro; la diferencia es de rótulo y es del conocimiento (DC1R2-10). Se juzga por sustancia: coincide |
| T1 «la nombra con `ruta:línea`» | Par exacto en el inventario y no en la ficha | **No procede.** Lectura del perito confirmada |
| D-05 | Fila o tabla de §3 | **No procede.** Se juzga por la tabla, en las dos corridas |

Ningún veredicto cambia: C1-r1 no pasa por M6. Oráculo sin cambios (`0fd3d463…ba461eac`).

### 7.3 C2 (sólo cifras)

E-1 (roles en D-01): **no procede**; el hecho del oráculo es verdadero y la conclusión de las corridas sale de K2-01.
E-3 (trampa nombrada con el origen mal clasificado): **no procede**; coincide si el ancla la sostiene. E-2 (el
oráculo no lista un prefijo que el repo usa 186 veces con otro sentido): **procede como omisión de un hecho** del
oráculo. Rige desde la ronda 3, con un oráculo 2 de C2 que lo liste, sin cambiar *n* ni umbral. En la ronda 2 queda
la medición del perito (3), y por eso C2-r2 pasa **con reserva**. Oráculo vigente para esta ronda:
`d0ff2a7d…81691468`. El detalle queda en `{dir-de-trabajo}/privado/`.

### 7.4 C3a

| Error | Juicio | Efecto |
| --- | --- | --- |
| E-1, D-11: el oráculo da por guardada en el repositorio un acta que el árbol de `d39dfbd` no tiene | **Procede**: es un hecho falso en la semilla | Oráculo 2 de C3a: coincide «delegación decidida por el PO, con el acta pendiente de versionar». No cambia el veredicto de la ronda 2: siguen faltando O-2 y la H reabierta |
| E-2, D-05: el ancla `TEM-05:98` es una de dos opciones y la ficha no elige | **Procede**: el oráculo afirma más de lo que la ficha sostiene | En el oráculo 2, ese elemento pasa a libre. No cambia M2 de la ronda 2: D-05 ya estaba entre las discutibles, fuera de los 7 firmes |
| Publicación | El oráculo sellado nombra en las líneas 172 y 190 la ruta del worktree de `LD` | Se publica con `{worktree-LD}`: huella publicada `c8dd3d5e…01309516`. Reponiendo la ruta vuelve a la sellada, `db708a77…05711ee1`, como comprobó el perito |

El oráculo 2 de C3a lo escribe su autor antes de la ronda 3, con nueva huella; el de la ronda 2 queda publicado.

## 8. Respuesta a TP:20 y la mitad «nuevos»

**Pregunta** (`F099:381`, de `TP:20`): ¿alcanza el conocimiento, solo, para que alguien sin contexto diseñe el sistema
documentador de un proyecto como lo haría quien conoce el cuerpo?

**Criterio de caso** **[criterio propio]**: un caso responde «sí» cuando sus dos corridas, independientes, pasan
M1–M6. Una sola de dos no es reproducción: M7 existe justamente porque dos aplicadores pueden divergir.

| Caso | Respuesta con la 1.1 | Por qué |
| --- | --- | --- |
| C0 | **Sin respuesta** | Dos corridas ANULADAS. Se re-corre (§9.3) |
| C1 | **No** | 0 de 2. M2 ya alcanza el umbral en r1, pero M6 no pasa en ninguna y M7 sube a 20 |
| C2 | **Todavía no** | 1 de 2, y esa una con reserva (M2 en el umbral, E-2). Es el caso que más mejoró: M2 de 9 y 11 a 3 y 3, M5 a 0 |
| C3a | **No** | 0 de 2. M2 7 y 7, M3 2/4 en las dos |

**Respuesta de la ronda 2: el conocimiento 1.1 no alcanza solo.** Mejora la convergencia y la disciplina de evidencia,
pero no la estabilidad ni la compuerta, y gran parte de lo que falta (R2-A) es un insumo que el propio conocimiento
pide y el montaje no dio.

**La mitad «nuevos» de `TP:18` con C3a.** El brazo a corrió por primera vez y ejercitó la §3.4 del conocimiento
(«Proyecto nuevo frente a existente»), como pedía `F199` §3. Las dos corridas fallan: M2 7 (umbral 3), M3 2/4
(reabren decisiones que la ficha ya trae tomadas), y M6 sin verde propio. **La mitad «nuevos» queda ejercitada y no
probada.** Vale el texto de `F199` §7 en su forma parcial: el libro no afirma que el material alcance para un proyecto
nuevo sin la marca «sin probar» del anexo J, mientras C3a no pase en una ronda posterior. Lo no medido sigue igual
(`F120` H08): e mide el día cero, no que un equipo trabaje después con el material (`TP:70`). El brazo b sigue en el
paso 11 bis.

## 9. Versión 1.2 y ronda 3

### 9.1 Propuesta de conocimiento 1.2 (no escrita)

Quedan defectos, así que corresponde una 1.2 **[criterio propio]**. La escribe quien escribió la 1.1, no esta
presidencia. Contenido propuesto:

1. Las diez familias R2-A a R2-J de §5.2, con sus arreglos, y los defectos de un solo caso con el arreglo de su
   perito.
2. En §5.7 y §8, la tabla de pasos que necesitan red o herramientas (C0 K2-01), y la regla de que «no usa red» se
   refiere al control, con las herramientas instaladas antes en versión y huella fijas.
3. En §3.5, la lista de lo que no se demanda porque ya tiene salida «pendiente» (R2-H).
4. §9, Fuentes: la ruta real del registro DK (`evidencia/ronda-1/defectos-consolidados.md`) y el SHA del commit de
   `F203`, pendiente desde `F203` §7; y el registro de los defectos de esta ronda.
5. Control de cambios con el exceso sobre la meta de ≤ 500 líneas declarado, como en la 1.1.

Antes de sellarla: revisión adversarial, `ci-local.sh todo` en un clon de `LD`, chequeo de citas y barrido, como se
hizo con la 1.1 (`F203` §3).

### 9.2 Ronda 3

**Hace falta.** Ningún caso pasa, y C0 no tiene medición en la ronda 2. Propuesta:

| Punto | Propuesta |
| --- | --- |
| Insumos | Conocimiento 1.2 y A-01 con nueva huella; carta 2 sin cambios salvo PR2-6 si lo exige (lo que cambia por caso va en el montaje, `F200` §2) |
| Montaje | Correcciones PR2-1 a PR2-5 de §6; la compuerta de origen como insumo con huella en los cuatro casos |
| Oráculos | C0 oráculo 3; C1 revisión 2; C2 oráculo 2 (E-2); C3a oráculo 2 (E-1, E-2). *n* y umbrales sin cambios |
| Casos | C0, C1, C2 y C3a, dos corridas cada uno, con coordinador y canal |
| Sellos | En el folio de la ronda 3, antes de la primera corrida |

### 9.3 Re-corridas de C0

`F202` §5 manda re-correr las ANULADAS con un aplicador nuevo, los mismos insumos y las mismas huellas: C0-r1 y C0-r2
se re-corren con la 1.1 y el oráculo 3, con el montaje corregido por PR2-1 (sin red real) y PR2-3. Sin red, la
autoprueba no corre y el aplicador debe dejarla pendiente: eso mide justamente K2-01. Pueden correr en paralelo con la
preparación de la 1.2; su resultado se asienta en el folio de la ronda 3.

## 10. Evidencia publicada

En `EXP3/evidencia/ronda-2/`. Lo de cada corrida va con el saneo que declara cada informe.

| Carpeta | Contenido |
| --- | --- |
| `C0/` | [`metrica.md`](../evidencia/ronda-2/C0/metrica.md) (dos ANULADAS, sin medir), las dos corridas con `salida/` y `coordinacion/` (registro de demandas y auditoría), `M4/` como constancia, y el oráculo 3 en `sellado/` |
| `C1/` | [`metrica.md`](../evidencia/ronda-2/C1/metrica.md), las dos corridas, `M4/`, `M6/` y el oráculo revisión 2 en `sellado/` |
| `C2/` | Sólo [`cifras.md`](../evidencia/ronda-2/C2/cifras.md). Informe, registros y auditorías en `{dir-de-trabajo}/privado/` |
| `C3a/` | [`metrica.md`](../evidencia/ronda-2/C3a/metrica.md), las dos corridas, `M4/`, `M6/` y el oráculo con `{worktree-LD}` en `sellado/` |

| Oráculo publicado | Huella del archivo publicado | Huella sellada |
| --- | --- | --- |
| C0, oráculo 3 | `e553c186c996f1ca1f1ff91e7b813fbcab0322ae7c29bf811e60f5862e263a00` | La misma (`F203` §4.1) |
| C1, revisión 2 | `0fd3d463c875d53f5a1cc8724a03c2a4426c18c09ee7ccb114ece059ba461eac` | La misma (`F203` §6.2) |
| C3a | `c8dd3d5e71bb222abec82aa29858de5b86dfed3dce339f6874aaf3dd01309516` | `db708a77…05711ee1` reponiendo la ruta (§7.4) |

Las huellas publicadas se recalcularon hoy sobre los archivos de esta carpeta.

## 11. Lo no verificado

- No volví a medir ninguna corrida ni a correr la compuerta: las cifras son de los peritos, los refutadores y los
  coordinadores. Sí recalculé las huellas de §10.
- El cruce de §5.1 con los DK es por sección y causa, hecho por esta presidencia sobre los textos de los informes;
  otra lectura puede mover algún defecto entre «repite» y «nuevo» sin cambiar la conclusión.
- La influencia del contexto heredado sobre dónde buscó cada aplicador no se puede medir con el registro (§1).
- Mensajes de otras sesiones a mitad de turno: ninguno.

## 12. Barrido de lo privado

Dos pasadas de `grep -rnoiEf` sobre este folio y todo `EXP3/evidencia/ronda-2/` (234 archivos).

1. **Lista privada del expediente**, la de `F203` §8, más el nombre de `{servicio-privado}`, su organización, su
   repositorio, su SHA y su dirección pública temporal. **Este folio: 0.** En la evidencia, 77 coincidencias, todas de
   patrones genéricos de la lista y ninguna un dato privado: direcciones de ejemplo (RFC 5737), de bucle local, de
   «todas las interfaces» y del anfitrión del emulador de Android, todas del contenido público de `LD`, en salidas de
   la compuerta; el prefijo genérico del directorio personal en patrones de `grep` de las fichas, como en `F203` §7;
   una ruta de controlador de una aplicación de ejemplo; un fragmento de URL pública que coincide con el nombre de un
   proyecto privado; el temporal del sistema en el texto de una auditoría de C0; y la organización y el dominio
   públicos de `LG`, que es público (oráculo de C1 e inventario de C1-r1). El perito de C0 ya los había revisado en su
   §8.
2. **Lista precisa**: la misma con los patrones genéricos acotados (directorio personal seguido de un usuario,
   proyectos privados por su nombre completo, IPv4 sólo en los rangos privados y de la red interna, salvo la dirección
   fija del anfitrión del emulador de Android, y sin la ruta de controlador de ejemplo). **Resultado: 0** en este
   folio y en la evidencia.

No se tocó la evidencia medida: cambiarla rompería las citas que comprobó M4. Las listas quedan en
`{dir-de-trabajo}/privado/`.

Sigue: conocimiento 1.2 · re-corridas de C0 · folio previo de la ronda 3 · addendum del brazo b (paso 11 bis)
