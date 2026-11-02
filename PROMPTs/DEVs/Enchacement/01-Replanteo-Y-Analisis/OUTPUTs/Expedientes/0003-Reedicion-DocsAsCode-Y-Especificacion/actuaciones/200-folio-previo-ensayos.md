---
doc_id: EXP0003-F200
doc_type: folio-previo
title: Folio previo de los ensayos — cifras, clase H y huellas selladas de C0 a C3 antes de la primera corrida
status: vigente
origin: agent
confidence: alta en las huellas y cifras (sha256sum, git rev-parse y conteos corridos el 2026-11-01 sobre los archivos sellados); media en el reparto de quién corre M1, M2, M3, M5 y M7, rotulado [criterio propio]
owner: presidencia de la mesa de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-01
audience: [presidencia, autores de oráculo, aplicadores (sólo después de sus corridas), refutador, PO]
traces: [EXP0003-F016, EXP0003-F099, EXP0003-F110, EXP0003-F120, EXP0003-F130, EXP0003-F199]
---

| Campo | Valor |
| --- | --- |
| Tipo | folio-previo |
| Fecha | 2026-11-01 |
| Autor | Presidencia. No escribió ningún oráculo, la ficha de C3 ni el conocimiento, y no corre ninguna corrida |
| Cumple | `F099` §5.5, «Folio previo» (`F099:423-425`), y `F199` §5.6, fila «Antes de correr C0» |
| Rama | `dac/0003-ensayos` (PR 6, `F099:452`). La fecha del sello es la del commit en el remoto |

**Convención de citas.** `F0nn`/`F1nn` = folios de esta mesa por número de línea; `N3:n` = núcleo de forma del
conocimiento; `SDEI/` = `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/` de `LD` en
`00171bd`; `EXP3/` como en `F099` §2. Lo privado va por alias: `{dir-de-trabajo}`, `{host-de-pruebas}`,
`{servicio-privado}`. Toda huella es `sha256sum` salvo que se diga otra cosa.

## Índice

1. [Qué se sella y qué no se publica](#1-qué-se-sella-y-qué-no-se-publica)
2. [Huellas comunes](#2-huellas-comunes)
3. [Cifras por caso](#3-cifras-por-caso)
4. [C0, C1 y C3 en detalle](#4-c0-c1-y-c3-en-detalle)
5. [C2, sólo huellas](#5-c2-sólo-huellas)
6. [Estado de C3](#6-estado-de-c3)
7. [Métrica e: instrumentos y quién corre](#7-métrica-e-instrumentos-y-quién-corre)
8. [Lo no verificado e incidencias](#8-lo-no-verificado-e-incidencias)
9. [Barrido de lo privado de este folio](#9-barrido-de-lo-privado-de-este-folio)

## 1. Qué se sella y qué no se publica

Este folio fija, antes de la primera corrida, lo que `F099:423-425` y `F199` §5.6 piden: por caso, *n*, umbral entero,
lista de clase H, filas «sin oráculo», huella del oráculo, huellas de los insumos y SHA del caso.

**Los oráculos no se publican antes de las corridas.** El aplicador no debe poder verlos (`F199` §5.5: «el brazo b no ve
`LDD` ni oráculos»; lo mismo vale para el brazo a y para C0 a C2). Aquí va sólo su huella. Los archivos quedan en
`{dir-de-trabajo}`, en sólo lectura, y se copian a `EXP3/evidencia/{C0,C1,C3}/` con el folio de resultado, donde
cualquiera puede comprobar que su `sha256sum` es el de este folio. Lo mismo vale para la ficha de C3, la lista de hechos
omitidos y el bundle de la semilla. Los aplicadores tampoco leen este folio antes de correr.

C3 = proyecto nuevo (`F099:404`), no «cuerpo nuevo» en el sentido de `N3:415` (`F199` §5.6; `F130` H-8).

## 2. Huellas comunes

| Insumo | Huella | Alcance |
| --- | --- | --- |
| Conocimiento (`knowledge-DocsAsCode-Designing-Specification.md`, la versión que corren C0, C1, C2 y el brazo a de C3) | `baa150abc7a080db1109b3c55dfa582edf3fb9afe8a03b93bb90aa151d6d417f` | Todas las corridas de este folio |
| Plantilla A-01 vacía (`A-01-ficha-vacia.md`) | `521ec37ef64b4d1ecebf80c517bf38015871a739f9db5d14139283f6ff1bc643` | Todas |
| Carta del aplicador (`carta-aplicador.md`) | `7d1575673a2839e8014924a54b99a11eea4afbff95fb4e0582f017469d7a1e11` | Todas las de este folio. La del brazo b de C3 va en el addendum |

**La carta** es mínima y neutral, igual para todos los casos: el aplicador recibe en un directorio el conocimiento, la
A-01 vacía y el proyecto en `repo/` (un subdirectorio por repositorio si hay más de uno). Llena A-01 siguiendo el
conocimiento y escribe sólo en `salida/`. Toda fila lleva evidencia `ruta:línea` o comando; si falta, «pendiente» con
motivo. No inventa, deja las decisiones de una persona listadas con opciones y default, registra cada suposición en
la sección 6 de A-01 y trabaja sin red. No trae contexto del laboratorio, ni nombres de casos, oráculos o métricas.
Lo que cambia por caso lo pone el montaje, no la carta. En C0, por ejemplo, el montaje no incluye `SDEI/`, porque
`F099:401` lo ve sólo como objeto.

## 3. Cifras por caso

| Caso | Escenario | *n* | Umbral M2 = ⌊0,15·n⌋ | Clase H | Filas «sin oráculo» | Huella del oráculo |
| --- | --- | --- | --- | --- | --- | --- |
| C0 | Corpus de guías | 24 | 3 | 5 | 0 dentro de *n* (A-04 fuera de *n*) | `a9362f1f2048ca7f91ecc2574a3957fbeddac9fbdb26ab8c9cfda64cae1fff25` (oráculo 2) |
| C1 | Panel con roles | 23 | 3 | 4 | 1 (T6) | `0fd3d463c875d53f5a1cc8724a03c2a4426c18c09ee7ccb114ece059ba461eac` (revisión 2) |
| C2 | Servicio con paquetes | 25 | 3 | 4 (sólo la cuenta) | — (§5) | `d0ff2a7d25ad7e8c67d12acadd809982f6caea14e12fc60b25502cbc81691468` |
| C3 brazo a | Proyecto nuevo | 22 | 3 | 4 | 0 | `162d8e2e8c79097f21ed5bed7fbe46d18b8baa2ac6e33c193a510700c38b4ed7` — **borrador, no sellable con la ficha 1** (§6) |

En los cuatro casos *n* sigue a `F099:411`: decisiones D-01 a D-17 más trampas, menos las «sin oráculo». Las filas H
entran en *n*, cada una con la regla de coincidencia de su oráculo. `F099:411` manda sobre `F016` §4.2, que define M2
sobre «decisiones P». Los artefactos A-01 a A-11 quedan fuera de *n*: los miden M4 y M6, y en el oráculo son
diagnóstico. En los cuatro casos *n* ≥ 7, así que el umbral no baja a 0. Los dos brazos de C3 usan el mismo umbral, y
ningún umbral se mueve después de sellar (`F199` §5.4).

## 4. C0, C1 y C3 en detalle

### 4.1 C0, corpus de guías

| Campo | Valor |
| --- | --- |
| SHA del caso | `LD` en `00171bd433fa7835d7680d981d1dadc1fd532ccb` |
| Oráculo que rige | Oráculo 2, `a9362f1f2048ca7f91ecc2574a3957fbeddac9fbdb26ab8c9cfda64cae1fff25`. Reemplaza al oráculo 1, `6cc989eac0bd362421ee11cdb550b5a4303dcf29e44737a65d340e3edd6cbb50`, que queda intacto (O-4 de `F016` §4.3). La causa del reemplazo: el oráculo 1 contaba siete artefactos dentro de *n* (31, umbral 4), y eso iba contra `F099:411` |
| *n* | 24 = 17 decisiones + 7 trampas (T-01 a T-07), 0 «sin oráculo» dentro de *n* |
| Umbral | 3 |
| Clase H | D-03, D-09, D-11, D-12 y la renovación de la huella de `AGENTS.md` en `tools/docs-guard/excepciones.txt` (T-02 / A-08; `excepciones.txt:3`, `AGENTS.md:105`) |
| Sin oráculo | A-04, el RRD inicial. Es diagnóstico y está fuera de *n*: fuera de `SDEI/` no hay RRD del corpus, y desde `LD` no se puede fijar si hace falta ni dónde viviría (`tools/docs-guard/README.md:99-100` sólo valida su forma) |
| ia-db | No aplica: `LD` no tiene `ia-db/` en `00171bd` (`git rev-parse 00171bd:ia-db` falla) |

### 4.2 C1, panel con roles

| Campo | Valor |
| --- | --- |
| SHA del caso | `LG` en `4b114d74f823b380ca65b5c00aab13d34c0b86d7`; `LGD` en `b47d22b78c153ffe2050b2e91211cbec59d12968`; vocabulario del cuerpo, `LD` en `00171bd433fa7835d7680d981d1dadc1fd532ccb` |
| Oráculo que rige | Revisión 2, `0fd3d463c875d53f5a1cc8724a03c2a4426c18c09ee7ccb114ece059ba461eac`. Reemplaza a la revisión 1 (`790188d5…6f420df1e20`), que no se selló. Los cambios: D-05 se compara por repositorio y admite dos conjuntos en `LGD`, según la H de D-12; se agregan anclas a D-01, D-02 y D-08 |
| *n* | 23 = 17 decisiones + 7 trampas − 1 «sin oráculo» |
| Umbral | 3 |
| Clase H | D-03, D-09, D-11, D-12 |
| Sin oráculo | T6, el límite de ADR-10010: el ADR no existe en `4b114d7`, se agrega después y no se detecta en el SHA del insumo. A-01 a A-11 quedan fuera de M2 (`F099:411`) y los miden M6 y M4. El criterio T de `F016` §4.2 («≥ 6 de 7») queda con denominador 6 en este SHA |
| ia-db (O-6) | Árbol `ia-db` de `LGD@b47d22b` = `ce5d7d6eab28fa0514d88250bf57999257ff700a` (`git rev-parse`). `ia-db/README.md` = `3ff8de21db9d9ba6cd4a8810447a7e36bc29b9194b5c983938652fd48d2997e6`. Su línea 38 indexa `4b114d7`, el mismo SHA del caso: O-6 cumple. La copia montada para el aplicador es idéntica al árbol de ese commit (`diff -r` vacío) |
| Restricción | Nada se escribe en `LGD`. `docs-guard` corre en un worktree descartable (`F099:402`) |

### 4.3 C3, brazo a (proyecto nuevo)

| Campo | Valor |
| --- | --- |
| SHA del caso | Semilla `db55bc3cc3b7c5facb1d54b59fe21d3d8531fc4a` (árbol `cd9182bfbe6950dc613319b9b972873ae44f1c3d`). Cuerpo para el oráculo, `LD` en `00171bd`. El aplicador del brazo a no ve `LD`, `LDD`, `LG` ni `LGD` (`F199` §5.5) |
| Ficha (ficha 1) | `16cd9faec1193d6c7ad04b42d0d557edf466692d1154dfde5a971eb5de4eb4ab`. Es igual byte a byte al `README.md` de la semilla (`cmp`) |
| Bundle de la semilla | `2dbbce720d2b9aba04399c621188865dc055a2cc7992c21f307ce5d700152da8` (`git bundle --all`, verificado; una sola cabeza, `main` = `db55bc3`) |
| Semilla | 38 archivos: `README.md` y 37 de la plantilla; `*.md` distintos de `README.md` = 0 (`F110` §6.3). No se empuja a ningún remoto |
| SDK y plantilla | Imagen `mcr.microsoft.com/dotnet/sdk:10.0` (id `sha256:de4fe90a98845d75910b9769662465c84de1a934665c431279d1382b2bddc02b`); SDK `10.0.403`; plantilla `Microsoft.Maui.Templates.net10@10.0.120`, instalada con `dotnet new install` porque la imagen no la traía; `dotnet new maui --no-restore`. R2 no se aplicó: el esqueleto se generó |
| Guarda léxica (`F199` §5.2) | `grep -ciE` sobre la ficha, con la lista unida de `F120` H05 y `F110` §6.2 regla 3, da **0**. Huella del patrón: `fc60a82fdc8e71ed2b83e2063575cc63c324cb2b1ca6309a26d49b8d86cae8c1` |
| Dominio fuera del corpus | `grep -rilE` de los sustantivos del dominio sobre `LD` en `00171bd` da **0** |
| Hechos omitidos | Dos (O-1 y O-2). Sólo su huella: `22eecf193c7b62ac534b1b8c2ff841a3229006ca780439af3c54d667dc744174`. Se espera «pendiente» con motivo. Completar uno cuenta en M5. Están fuera de *n* |
| Oráculo | `162d8e2e8c79097f21ed5bed7fbe46d18b8baa2ac6e33c193a510700c38b4ed7`, borrador corregido contra la ficha 1. Reemplaza a `99110bd8…4d320112`, rechazado. **No sellado**: ver §6 |
| *n* y umbral | 22 = 17 decisiones + 5 trampas (T3-1 a T3-5), 0 «sin oráculo»; umbral 3. Valen para la ficha 1 y se recalculan con la ficha 2 |
| Clase H | D-03, D-09, D-11, D-12. D-01 no es H, porque el cuerpo no prevé un escenario nuevo |
| Filas discriminantes | D-08 y D-10, con T3-5 de refuerzo. Cuentan en *n* y se informan aparte, sin umbral (`F199` §5.3) |
| Lecturas de `N3` del autor del oráculo | `N3:332-348` (defaults, para la carga mínima) y `N3:358-368` (nombres de A-02 a A-11, porque la plantilla A-01 trae sólo los Id). Ninguna es fuente de un valor esperado |
| ia-db | No aplica: la semilla es un proyecto nuevo, sin índice |

**Brazo b.** Va en un addendum de este folio (`F199` §5.6, fila «Paso 11 bis»). El addendum se empuja antes de correr
el brazo b y trae el SHA del remoto de `dac/0003-libro` con la unión, el listado `find` del montaje, la huella del
conocimiento vigente en ese momento y la carta del brazo b. La **regla** del insumo b queda fijada desde ahora, como
pide `F199` §5.6: el brazo b recibe lo mismo que el brazo a, más `LD` entero en el SHA del remoto de la unión (`F199`
§5.1). No recibe `LDD`, `LG`, `LGD` ni oráculos (`F199` §5.5).

## 5. C2, sólo huellas

C2 es privado (`F099:403`). Aquí no va ningún nombre, ninguna ruta del caso ni ningún valor del oráculo.

| Campo | Valor |
| --- | --- |
| Huella del oráculo | `d0ff2a7d25ad7e8c67d12acadd809982f6caea14e12fc60b25502cbc81691468` |
| Huella del SHA del caso | `0ceac5d60c2abb6d2f1904abd6ce3ebf7d796b73411e4962c0531b28c266c2e5`: `sha256sum` de los 40 caracteres hexadecimales del SHA, sin salto de línea (`printf %s <SHA> \| sha256sum`) |
| Huella de la ia-db del caso | `796c06ed2fbe5a3aac95ea709003bcf6d6b59175d2debcb436fb15e22a40e19f`: `find . -type f -print0 \| sort -z \| xargs -0 sha256sum \| sha256sum` dentro de `ia-db/` |
| *n* | 25 |
| Umbral | 3 |
| Clase H | 4 filas (sólo la cuenta) |
| Conocimiento, A-01 y carta | Los de §2 |

El oráculo, la hoja privada de `N5` y las salidas viven sólo en `{dir-de-trabajo}/privado/`. A `EXP3/evidencia/C2/`
van cifras y huellas.

## 6. Estado de C3

El oráculo de C3 aplica `F199` §5.2 tal como está escrito: cuenta sólo D-01 a D-17 contra el default de `N3:332-348`.
Con la ficha 1 quedan 5 decisiones firmes fuera del default (D-06, D-10, D-11, D-13 y D-14) y 3 dudosas (D-02, D-03 y
D-16). Son 5 a 8, contra 11, que es la mitad de *n*. La carga mínima no se alcanza y rige **R3** (`F199` §6): ficha
2 con nueva huella **antes** de sellar, con el mismo umbral. Esta presidencia no cuenta trampas para alcanzar la carga,
porque `F199` §5.2 no lo prevé.

Consecuencias que este folio fija:

1. El brazo a de C3 **no corre** contra la ficha 1 ni contra el oráculo `162d8e2e…c38b4ed7`. Las huellas de §4.3 quedan
   como constancia de la ficha 1, de su semilla y del oráculo descartado para sellar.
2. La ficha 2, su semilla, su bundle, la guarda léxica, la carga mínima y el oráculo rehecho, con *n*, umbral y clase
   H, se sellan en un addendum de este folio, empujado a `dac/0003-ensayos` antes de la primera corrida de C3. El
   umbral sólo puede cambiar si cambia *n*, y siempre por ⌊0,15·n⌋.
3. Si al terminar el paso 8 no hay addendum sellado, rige **R1**: C3 entero va a default con el texto de `F199` §7 y
   el motivo «sin sellar a tiempo».
4. C0, C1 y C2 no dependen de C3 y pueden correr con este folio.

## 7. Métrica e: instrumentos y quién corre

Las medidas son las de `F099:406-416`, sin cambios (`F199` §5.5). Cada corrida se mide sola.

| Medida | Instrumento | Pasa si | Quién corre |
| --- | --- | --- | --- |
| M1 Cobertura | Conteo sobre la A-01 llena: filas D-01 a D-17 con valor o con «pendiente» y motivo | Todas contestadas o pendientes con motivo | Perito de métrica despachado por la presidencia, distinto del aplicador **[criterio propio]** |
| M2 Discrepancias | Comparación fila por fila con el oráculo sellado (decisiones y trampas), con las reglas de conjunto admitido, obligatorios, libres y excluidos de cada oráculo | ≤ umbral de §3 | El autor del oráculo del caso, que no corre la corrida **[criterio propio]**; las filas discutibles van a O-4 (oráculo 2), nunca a mover el umbral |
| M3 Clase H | Lista de clase H de §3 y §4 contra la A-01 | Todas listadas para una persona y ninguna decidida | El mismo autor del oráculo **[criterio propio]** |
| M4 Invenciones | Script que comprueba que cada `ruta:línea` citada existe en el SHA del insumo (en C3, la semilla; en el brazo b, también `LD`), más la verificación del refutador | 0 | Script, lo corre el perito de métrica; lo verifica el refutador (`F099:430-431`, `F199` §5.5) |
| M5 Suposiciones | Sección 6 de la A-01 y registro de la corrida; en C3 incluye completar un hecho omitido | 0 | Perito de métrica **[criterio propio]** |
| M6 Compuerta | Agregador de `docs-guard` sobre A-02 a A-07, con un par rojo y verde plantado: C0 en una copia de `LD`; C1 en el worktree descartable de `LGD`; C2 en `{dir-de-trabajo}/privado/`; C3 en una copia de la semilla | Verde, con el rojo visto | Perito de métrica, en `{host-de-pruebas}` con la guarda de turnos (`F099:432`) |
| M7 Estabilidad | `diff` entre las dos corridas del mismo caso y brazo | Diagnóstico sin umbral: cada diferencia es un defecto del conocimiento | Perito de métrica **[criterio propio]** |

Diagnósticos de C3 sin umbral: diferencia entre brazos decisión por decisión, filas discriminantes y costo de cada
corrida (archivos leídos y tiempo, `F199` §5.5).

**Aplicadores.** Uno por corrida, dos corridas por caso y brazo: subagentes nuevos, sin red y sin memoria, que
reciben sólo la carta de §2 y el montaje de su caso (`F099:430-431`). Ningún aplicador escribe un oráculo ni lee este
folio antes de correr.

## 8. Lo no verificado e incidencias

- No corrí ningún ensayo. Las cifras son las que contaron los autores de oráculo. Verifiqué la aritmética de los
  umbrales y las huellas, no el contenido de cada fila.
- No volví a correr la guarda léxica ni el `grep` del dominio de C3: copio su salida de la constancia de huellas del
  caso, corrida el 2026-11-01.
- No comprobé que la semilla compile; `F199` no lo pide.
- El reparto de M1, M2, M3, M5 y M7 entre el perito de métrica y el autor del oráculo es de esta presidencia
  (`F099:430-431` sólo nombra al refutador para M4).
- Mensajes de otras sesiones a mitad de turno: ninguno.

## 9. Barrido de lo privado de este folio

Comando: `grep -nE` sobre este archivo con las rutas absolutas del equipo, los nombres de máquina del
laboratorio, el nombre del servicio privado y del repositorio de C2, el SHA en claro de C2 y el patrón de una IPv4.
Resultado esperado y obtenido: 0 coincidencias.

Sigue: aplicadores de C0, C1 y C2 (paso 8) · ficha 2 y oráculo de C3 con su addendum · addendum del brazo b (paso 11 bis)
