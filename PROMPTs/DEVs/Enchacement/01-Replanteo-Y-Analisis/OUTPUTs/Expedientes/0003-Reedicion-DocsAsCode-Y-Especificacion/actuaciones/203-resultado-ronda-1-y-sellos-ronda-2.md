---
doc_id: EXP0003-F203
doc_type: resultado
title: Resultado de la ronda 1 de los ensayos — métrica e, auditoría de ceguera, defectos, juicio de oráculos y sellos de la ronda 2
status: vigente
origin: agent
confidence: alta en las cifras de la métrica e (copiadas de los informes de los peritos) y en las huellas (sha256sum corrido el 2026-11-01 sobre los archivos sellados); media en la clasificación de la auditoría y en el montaje de C0 para la ronda 2, rotulados [criterio propio]
owner: presidencia de la mesa de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-01
audience: [presidencia, coordinador, autores de oráculo, peritos, refutador, PO]
traces: [EXP0003-F099, EXP0003-F199, EXP0003-F200, EXP0003-F201, EXP0003-F202]
---

| Campo | Valor |
| --- | --- |
| Tipo | resultado |
| Fecha | 2026-11-01 |
| Autor | Presidencia. No escribió ningún oráculo ni el conocimiento, y no corrió ni coordinó ninguna corrida |
| Cumple | `F200` §1 (el folio de resultado), `F202` §6 (auditoría a posteriori de la ronda 1) y `F202` §7 (copia de las cartas) |
| Resultado | **Ninguna de las seis corridas pasa.** Ninguna queda anulada. El conocimiento pasa a 1.1 con 27 defectos corregidos. La ronda 2 queda sellada en §6 |
| Rama | `dac/0003-ensayos` |

**Convención de citas.** La misma de `F200`. `EXP3/` es la carpeta de este expediente. Lo privado va por alias:
`{dir-de-trabajo}`, `{host-de-pruebas}`, `{servicio-privado}`, `{etiqueta-runner}`. Toda huella es `sha256sum`.

## Índice

1. [Métrica e de la ronda 1](#1-métrica-e-de-la-ronda-1)
2. [Auditoría de ceguera](#2-auditoría-de-ceguera)
3. [Defectos del conocimiento y versión 1.1](#3-defectos-del-conocimiento-y-versión-11)
4. [Juicio de los errores del oráculo](#4-juicio-de-los-errores-del-oráculo)
5. [Evidencia publicada](#5-evidencia-publicada)
6. [Sellos de la ronda 2](#6-sellos-de-la-ronda-2)
7. [Lo no verificado y pendientes](#7-lo-no-verificado-y-pendientes)
8. [Barrido de lo privado](#8-barrido-de-lo-privado)

## 1. Métrica e de la ronda 1

Las seis corridas usaron el conocimiento 1.0 (`baa150ab…6d417f`), la A-01 vacía (`521ec37e…c6bc643`) y la carta 1
(`7d157567…7a1e11`), con los oráculos de `F200` §3. Las medidas son las de `F099:406-416`; el detalle fila por fila
está en el informe de cada caso.

| Corrida | M1 | M2 (umbral 3) | M3 | M4 | M5 | M6 | Corrida |
| --- | --- | --- | --- | --- | --- | --- | --- |
| C0-r1 | 17/17, pasa | 6, no pasa | 5/5, 0 decididas, pasa | 1 (lectura estricta; 0 fabricadas) | 6 | Rojo: 4 `id-duplicado` (IDs del RRD nuevo chocan con otro RRD del repo); rojo plantado visto | **No pasa** |
| C0-r2 | 17/17, pasa | 3, pasa | 5/5, 0 decididas, pasa | 1 (lectura estricta; 0 fabricadas) | 5 | Verde, rojo plantado visto | **No pasa** |
| C1-r1 | 17/17, pasa | 9, no pasa | 4/4, 0 decididas, pasa | 0 | 6 | Con reserva: rojo con el registro del cuerpo; verde con el registro A-02 de la corrida | **No pasa** |
| C1-r2 | 17/17, pasa | 8, no pasa | 4/4, 0 decididas, pasa | 0 | 4 | Rojo en `esquema` (vocabulario de `doc_type` y `audience`) | **No pasa** |
| C2-r1 | 17/17, pasa | 9, no pasa | 4/4, 0 decididas, pasa | 0 | 4 | Condicional | **No pasa** |
| C2-r2 | 17/17, pasa | 11, no pasa | 4/4, 0 decididas, pasa | 1 | 5 | Condicional | **No pasa** |

**M7 (diagnóstico, sin umbral).** C0: 14 diferencias entre r1 y r2. C1: 14. C2: 23. Cada diferencia se atribuye a
un defecto del conocimiento; en total, 51.

Informes:

- C0: [`evidencia/C0/metrica.md`](../evidencia/C0/metrica.md).
- C1: [`evidencia/C1/metrica.md`](../evidencia/C1/metrica.md).
- C2, sólo cifras: [`evidencia/C2/cifras.md`](../evidencia/C2/cifras.md).

**Lectura.** Las seis corridas cubren las 17 decisiones y ninguna decide una fila H: M1 y M3 pasan siempre. Lo que
falla es la convergencia (M2, y M7 lo confirma) y la disciplina de evidencia (M5, en las seis). M6 en rojo, salvo
C0-r2, sale casi entero de la familia G de defectos: el conocimiento no decía cómo se parametriza la compuerta del
cuerpo para un proyecto ajeno (§3).

## 2. Auditoría de ceguera

Hecha a posteriori por el coordinador, con el criterio de `F202` §5, sobre el registro de herramientas de cada corrida.
Método y script: [`evidencia/auditoria-ronda-1/`](../evidencia/auditoria-ronda-1/README.md).

Ninguna de las seis corridas queda anulada: ninguna leyó material del laboratorio fuera de su directorio, ninguna usó
la red y ninguna escribió fuera de `salida/`. Cuatro son válidas y dos llevan una observación.

| Corrida | Clasificación | Motivo |
| --- | --- | --- |
| C0-r1 | VÁLIDA | 36 llamadas, 10 marcadas por el script. Todas son falsos positivos: patrones de `grep`, comodines de bucle y redirecciones a `salida/_inventario`. Sin accesos reales fuera, sin red, sin escrituras fuera de `salida/` |
| C0-r2 | VÁLIDA CON OBSERVACIÓN | 40 llamadas, 8 marcadas. Las marcas de lectura y de red son falsos positivos (el `npx` es `which … npx`, sólo consulta si existe). La observación: el barrido de privacidad de la llamada 23 buscó dos nombres de máquina que no están en su directorio ni en sus resultados previos. Salieron de la memoria del entorno que la sesión recibió al arrancar. Dio 0 coincidencias y no llegó a la ficha |
| C1-r1 | VÁLIDA CON OBSERVACIÓN | 40 llamadas, 9 marcadas. La observación: dos `Read` fuera del directorio (llamadas 2 y 7). Son los archivos donde el arnés guarda la salida larga de sus propios comandos, así que su contenido viene de su `repo/`. Inocuo. El resto son patrones y escrituras dentro de `salida/` |
| C1-r2 | VÁLIDA | 39 llamadas, 14 marcadas. Todos falsos positivos: el `git clone` y el `gh` están dentro de un workflow que escribió en `salida/`, no se ejecutaron. La única coincidencia con el contexto heredado en la ficha, «Runners», es una etiqueta genérica con evidencia en `repo/`, y se descartó |
| C2-r1 | VÁLIDA | 28 llamadas, 9 marcadas, 9 falsos positivos. 0 fuera, 0 red, 0 escrituras fuera de `salida/` |
| C2-r2 | VÁLIDA | 33 llamadas, 8 marcadas, 8 falsos positivos. 0 fuera, 0 red, 0 escrituras fuera de `salida/` |

**Contexto heredado en las fichas.** Las seis sesiones recibieron sin pedirlo el índice de memoria del entorno (unos
25 KB) y un directorio de trabajo fuera de la corrida. De ese contexto salieron 458 términos distintivos. Ninguno que
falte en el directorio de la corrida aparece en su `salida/A-01.md`, y tampoco hay rutas de sesión, correo ni
referencias a la memoria. La medición tiene un límite: si un término está a la vez en la memoria y en `repo/`, no se
puede saber de dónde lo tomó el aplicador. C0-r2 muestra que ese contexto llega y se usa, aunque esta vez no tuvo
efecto.

El script marca de más a propósito, así que cada marca se revisó a mano. Además, ninguna corrida usó `Agent`,
`ToolSearch`, `WebFetch` ni `WebSearch`, y no quedaron `__pycache__` ni `.pyc` en los `repo/`. Ninguna corrida ni el
coordinador recibieron mensajes de otras sesiones.

**Consecuencias.**

1. No hay re-corridas de la ronda 1 (`F202` §6): las seis se miden y se informan como están en §1.
2. Para la ronda 2, los aplicadores se lanzan **sin el índice de memoria del entorno y con el directorio de trabajo
   dentro de la corrida** **[criterio propio]**. Es la condición de despacho de §6.4; el coordinador la comprueba en
   el registro de herramientas y una sesión que la incumpla cae en VÁLIDA CON OBSERVACIÓN o en ANULADA según `F202` §5.
3. Los JSON crudos de la auditoría de C0 y C1 traen los comandos literales, con nombres de máquina: quedan en
   `{dir-de-trabajo}`, fuera de este repositorio. Los de C2 y su detalle quedan en `{dir-de-trabajo}/privado/`.

## 3. Defectos del conocimiento y versión 1.1

Los 48 defectos de origen (C0 K-01…K-13, C1 DC1-01…DC1-16, C2 K-01…K-19) se deduplicaron por sección y causa en **27
consolidados, DK-01 a DK-27**: 6 de la familia G (la compuerta del cuerpo aplicada a un proyecto ajeno), 21 de fondo
y 6 de forma. El registro, con el arreglo de cada uno: [`evidencia/ronda-1/defectos-consolidados.md`](../evidencia/ronda-1/defectos-consolidados.md)
(`d889f6798690506a757d39b5b18d7831424076fda108ae37279f4511a2a01cc1`).

**Conocimiento 1.1.** Los 27 están aplicados. Los cambios más pesados:

| DK | Cambio en el conocimiento |
| --- | --- |
| 01 | A-02 es el registro de prefijos **del proyecto**, en el formato que lee la compuerta. Como la compuerta en `00171bd` no lo recibe como parámetro (`docs-guard.yml:32-48`; `dg.py:39-40`), el default es la copia con huella |
| 02 | Vocabulario de `doc_type` y `audience` declarado por proyecto en A-03, arrancando de las listas del esquema de origen |
| 03 | El par rojo/verde corre con la compuerta de D-09 y la configuración del proyecto; la autoprueba, en la copia de origen intacta |
| 04 | D-09 mide la organización (`origin` y líneas `uses:`); los `uses:` van con marcadores |
| 05 | Unicidad de IDs en todo el repo, inventario de los espacios de IDs y prefijo por artefacto |
| 16 | Lista cerrada de 6 patrones del inventario, cada uno con su comando |
| 21–23 | 0 suposiciones (la sección 6 de A-01 ya no las pide); búsquedas negativas con comando y chequeo mecánico de citas `ruta:línea`; barrido por lista privada y alias canónicos |

La tabla completa DK → cambio → línea queda en el registro de defectos.

**Revisión adversarial antes de sellar.** Un verificador encontró nueve hallazgos (dos medios, siete bajos) y los
nueve se corrigieron sobre la misma versión 1.1:

| Hallazgo | Corrección |
| --- | --- |
| Medio: los comandos del inventario estaban en celdas de tabla con `\|`; copiados crudos, `grep -E` no encuentra nada | Bloque `bash` numerado del 1 al 5, sin `\|`; la tabla queda con nombre y número. Probado: la forma nueva da rc=0 y la vieja rc=1 |
| Medio: DK-01 a DK-03 dichos pero no resueltos en lo operativo (cómo llega A-02 a la copia, formato de A-03, qué cubre la huella) | §5.7: se copian `tools/docs-guard/` y `scripts/` de `Lab-Documentos@{sha}`; A-02 **es** el `prefijos.txt` de la copia; A-03 es su `cuerpo.schema.json` en el formato de origen; la huella cubre sólo `dg.py` y `ci-local.sh`. §8 pide la compuerta de origen en un SHA fijo |
| Bajos (siete) | «Cuándo no» en §0 y fila I-01 en §2.4; `{compuerta}` del inventario es la de origen; cada cita repite el archivo; D-04 alineado con lo que informa el control de trazas; A-02 y el esquema de A-03 sin frontmatter; mapa de carga en tabla `Tarea` / `Secciones`; el exceso sobre la meta de ≤ 500 líneas (`099-resolucion.md:334`) declarado en el control de cambios |

Estado de la 1.1 que sella §6: 593 líneas. `scripts/ci-local.sh todo` en un clon temporal de `Lab-Documentos`
`origin/main` (`e0608fd`), con el conocimiento en su carpeta de `Conocimientos/`: rc=0 y los ocho grupos en verde,
autoprueba incluida. Mermaid, 1 diagrama ok. 147 citas `ruta:línea` comprobadas contra `00171bd` (y las de 099 contra
`0d001ed`), todas existen y están en rango. Barrido de privados sobre el conocimiento, la A-01 y lo que pasa al libro:
0 coincidencias.

## 4. Juicio de los errores del oráculo

Los errores que los peritos señalaron se juzgaron por O-4 (`F016` §4.3): un oráculo sólo se corrige por error, nunca
para acomodar al conocimiento, y *n* y umbral no se mueven.

### 4.1 C0

| Error alegado | Juicio | Efecto |
| --- | --- | --- |
| E-1: el oráculo se escribió contra `LD` completo y el montaje no trae `SDEI/` | **No procede.** 099 §5.5 fija el insumo como «`LD` en SHA del remoto, visto sólo como objeto (sin leer `SDEI/`)»: exclusión de lectura, no de presencia. Sin la carpeta, el objeto deja de ser `LD@00171bd`: la ruta por defecto de `.github/workflows/docs-guard.yml:63` y `scripts/ci-local.sh:35` apunta a una carpeta que no existe, falta el `source.lock` que nombra `.github/workflows/mini-demo-movilidad.yml:3` y falta la instancia que declara `CHANGELOG.md:196`. Todas las anclas del oráculo están fuera de `SDEI/`. **Lo que estaba mal era el montaje** | Regla 0.7 del oráculo 3 (precondición de montaje), sin cambiar ningún valor. Montaje de C0 corregido para la ronda 2 (§6.4) |
| E-2: D-11 excluye «sin delegación», pero el propio oráculo deja a una persona lo que queda fuera de alcance | **Procede.** Contradicción interna: castiga a fichas que reconocen las tres delegaciones acotadas y proponen que una persona fusione el PR de adopción, como hacen C0-r1 (`A-01.md:53`, `A-01.md:86`) y C0-r2 (`A-01.md:54`, `A-01.md:91`) | Nota de D-11: coincide si la ficha reconoce las delegaciones acotadas, niega una general y deja a una persona lo que queda fuera de alcance |
| E-3: la nota de T-05 sólo cubre la etiqueta literal del runner | **Procede** (laguna; no cambia el resultado de r1). D-14 fija la política para lo versionado (`AGENTS.md:109-110`) | Regla 0.8: cualquier valor privado en la salida, incluidos los patrones de un barrido, hace fallar D-14 |
| E-4: D-17 no dice si adoptar el carril existente cuenta como modo igual | **Procede.** El modo del existente consta en `.github/workflows/docs-enlaces-semanal.yml:3` («Sólo avisa»). Que el conocimiento no pida el modo es un defecto del conocimiento (DK-20) | Nota de D-17: la adopción del carril existente sin cambios, con frecuencia y frescura escritas, coincide |

**Oráculo 3 de C0**: `e553c186c996f1ca1f1ff91e7b813fbcab0322ae7c29bf811e60f5862e263a00`. Reemplaza al oráculo 2
(`a9362f1f…1fff25`), que queda intacto y publicado en [`evidencia/C0/sellado/oraculo-O3-2.md`](../evidencia/C0/sellado/oraculo-O3-2.md).
*n* = 24 y umbral = 3 no cambian: ninguna fila entra ni sale. El oráculo 3 no se publica hasta después de la ronda 2
(`F200` §1). Los M2 de la ronda 1 se dejan como los midió el perito con el oráculo 2; no se recalculan.

### 4.2 C1

| Error alegado | Juicio |
| --- | --- |
| D-01, contexto «dentro de la organización», anclado en `LD@00171bd:.github/workflows/docs-guard.yml:75`, fuera del montaje; se propone admitir «pendiente con motivo» | **No procede.** El valor es verdadero: ese workflow hace checkout de `hdcm-dev/Lab-Documentos`, y LG está en `hdcm-dev` (`LG@4b114d7:SDD/Docs/Audit/Estado-Del-Destino-2026-09-12.md:33`; `SDD/Intake/PRODUCT-INTAKE-Fabrica-De-Geometria.md:14`) y ya corre en un runner propio de la organización (`LG@4b114d7:.github/workflows/e2e.yml:69`, `{etiqueta-runner}`). El contexto es relacional y es correcto anclar el lado del cuerpo en `LD`. Si el aplicador no alcanza ese hecho, el defecto es del conocimiento, no del oráculo; rebajarlo iría contra O-4. Además, las dos corridas no declaran ningún contexto: el resultado no cambiaría |
| D-05, CL-05 en «build», cuando el contrato hoy se genera en ejecución (`ApiDocumentation.cs:58`, `:117`); se propone admitir «código, generado en ejecución» | **No procede.** D-05 decide dónde debe vivir cada pieza, no describe el estado actual; el mismo D-05 ubica por regla piezas que hoy no existen. El arreglo del conocimiento (DK-13: un contrato generado en ejecución sigue en build, con un paso de CI que lo extrae) confirma que «build» es el valor correcto |

**Oráculo de C1**: sin cambios. Sigue la revisión 2, `0fd3d463c875d53f5a1cc8724a03c2a4426c18c09ee7ccb114ece059ba461eac`,
publicada en [`evidencia/C1/sellado/oraculo-O3.md`](../evidencia/C1/sellado/oraculo-O3.md). *n* = 23, umbral = 3.

### 4.3 C2 (sólo cifras)

Se alegaron 3 errores; **ninguno procede**. Los tres son filas discutibles de peso o de lectura, no valores falsos, y
con cualquier lectura el veredicto no cambia (r1 queda en 8 o más, r2 en 9 o más, contra umbral 3). **Oráculo de C2**:
sin cambios, `d0ff2a7d25ad7e8c67d12acadd809982f6caea14e12fc60b25502cbc81691468`. *n* = 25, umbral = 3. El juicio
detallado queda en `{dir-de-trabajo}/privado/`.

## 5. Evidencia publicada

| Carpeta en `EXP3/evidencia/` | Contenido |
| --- | --- |
| `C0/` | Informe de métrica, fichas y artefactos de las dos corridas, M4 (script, citas e informe del refutador), M6 (salidas rojo y verde) y el oráculo 2 en `sellado/` |
| `C1/` | Lo mismo para C1, con el oráculo revisión 2 en `sellado/` |
| `C2/` | Sólo `cifras.md`: cifras, huellas y defectos genéricos |
| `auditoria-ronda-1/` | `README.md` con método y resultado; `auditar_corrida.py` |
| `ronda-1/` | `defectos-consolidados.md` (DK-01 a DK-27) |
| `cartas/` | Carta del aplicador 1 (`7d157567…7a1e11`), carta del aplicador 2 (`ca263a77…6ec19a`) y carta del coordinador (`77c19d57…f4e4dc`), como pide `F202` §7. Huellas comprobadas sobre las copias |

No hubo registros de demandas: la ronda 1 corrió sin canal (`F202` §6).

## 6. Sellos de la ronda 2

### 6.1 Insumos comunes

| Insumo | Huella | Alcance |
| --- | --- | --- |
| Conocimiento 1.1 (`knowledge-DocsAsCode-Designing-Specification.md`, 593 líneas) | **`afd741b838ae2bf457f6d2a6143a079d1d65ee76f1ab55d134f560f7165483e8`** | Todas las corridas de la ronda 2 |
| Plantilla A-01 vacía, corregida | **`0fa85977ee8f790a9d39a3febb98a76f1c0a13045ecb734c325ac1b4e85e72bc`** | Todas |
| Carta del aplicador 2 (`carta-aplicador-2.md`) | **`ca263a7735fcb370c23999da4bade0ac364f70e899a2ceec13bf61aed46ec19a`** | Todas (`F202` §7) |
| Carta del coordinador (`carta-coordinador.md`) | **`77c19d57533b1906040fbe4835eaf93f9ea44ca1539058167a2a57d5c3f4e4dc`** | Un coordinador por caso (`F202` §2) |

Las dos primeras huellas se calcularon hoy sobre los archivos de `{dir-de-trabajo}/conocimiento/`; las de las cartas
coinciden con la constancia de huellas de los insumos y con `F202` §7. La 1.0 (`baa150ab…6d417f`) y su A-01
(`521ec37e…c6bc643`) quedan como constancia de la ronda 1.

### 6.2 Oráculos, *n* y umbral por caso

| Caso | Oráculo que rige | Huella | *n* | Umbral M2 | Clase H |
| --- | --- | --- | --- | --- | --- |
| C0 | Oráculo 3 (nuevo, §4.1) | `e553c186c996f1ca1f1ff91e7b813fbcab0322ae7c29bf811e60f5862e263a00` | 24 | 3 | 5 (`F200` §4.1) |
| C1 | Revisión 2 (sin cambios) | `0fd3d463c875d53f5a1cc8724a03c2a4426c18c09ee7ccb114ece059ba461eac` | 23 | 3 | 4 |
| C2 | Sin cambios | `d0ff2a7d25ad7e8c67d12acadd809982f6caea14e12fc60b25502cbc81691468` | 25 | 3 | 4 (sólo la cuenta) |
| C3 brazo a | Oráculo de `F201` §6 | `db708a7773055b014368014b3a1afe10b948fd81e48f8dc73d18433d05711ee1` | 21 | 3 | 4 |

Ningún umbral se movió (`F199` §5.4). Los SHA de los casos, la ia-db y las «sin oráculo» siguen como en `F200` §4,
`F200` §5 y `F201`.

### 6.3 C3 brazo a

Corre por primera vez en la ronda 2, con el oráculo de `F201` (`db708a77…05711ee1`), la ficha 2
(`f5592471…bc0ca448`), los hechos omitidos (`7ba8c3de…782ef4c54`), la semilla 2 (`d39dfbd`, bundle
`0be59357…6e0923c9`) y el **conocimiento 1.1** de §6.1, no la 1.0 que nombraba `F200` §2. Huellas de la ficha, los
hechos omitidos, el bundle y el oráculo recalculadas hoy: coinciden con `F201`. El brazo b sigue en el addendum del
paso 11 bis (`F199` §5.6).

### 6.4 Protocolo y montaje

Rige `F202` completo: carta 2, un coordinador por caso, canal de demandas con máximo 3 rondas, registro y auditoría
de cada corrida. Dos corridas por caso y brazo (`F200` §7). Además:

- **Despacho** **[criterio propio]**: cada aplicador arranca sin el índice de memoria del entorno y con el directorio
  de trabajo dentro de su corrida (§2, consecuencia 2).
- **Montaje de C0** **[criterio propio]**: `LD` en `00171bd` **completo**, con `SDEI/` presente en el árbol (regla 0.7
  del oráculo 3). El oráculo pide que la prohibición de leer `SDEI/` vaya en la carta, pero la carta 2 es una sola
  para todos los casos y ya está sellada; por `F200` §2 («lo que cambia por caso lo pone el montaje, no la carta»), la
  exclusión de lectura la pone el montaje: `SDEI/` queda sin permiso de lectura para el aplicador. El coordinador
  clasifica como ANULADA cualquier lectura de `SDEI/` (`F202` §5).
- Los registros de demandas y las auditorías de la ronda 2 se copian a `EXP3/evidencia/{caso}/` con el folio de
  resultado de la ronda 2; los de C2, sólo en cifras.

## 7. Lo no verificado y pendientes

- No volví a medir ninguna corrida ni a correr la compuerta sobre la 1.1: copio las cifras de los informes de los
  peritos, del refutador, del coordinador y del verificador del conocimiento. Sí recalculé hoy todas las huellas de §4,
  §5 y §6.
- **DK-01 queda abierto en la compuerta de origen**: en `00171bd` no acepta el registro de prefijos como parámetro. La
  1.1 lo dice y deja la copia con huella como salida hasta que se cambie la compuerta.
- **§9, Fuentes, del conocimiento 1.1** cita el registro DK-nn en una ruta prevista
  (`evidencia/auditoria-ronda-1/defectos-ronda-1.md`) y deja su SHA pendiente. El registro quedó versionado en
  `evidencia/ronda-1/defectos-consolidados.md`. Antes de fusionar el conocimiento hay que corregir esa ruta y escribir
  el SHA del commit de este folio. Ese cambio altera la huella del conocimiento, así que se hace **después** de la
  ronda 2, o se sella de nuevo antes de correrla.
- La evidencia de C0-r1 conserva el prefijo genérico del directorio personal como patrón de `grep` y un ejemplo
  ilustrativo de su ficha: no son rutas de un equipo ni nombran a nadie, y no se tocaron para no alterar la evidencia
  medida.
- Mensajes de otras sesiones a mitad de turno: ninguno.

## 8. Barrido de lo privado

Comando: `grep -rnoiEf` con una lista privada (rutas absolutas del equipo, nombres de máquina del laboratorio,
usuarios, el nombre del servicio privado y su organización, el SHA en claro de C2 y el patrón de una IPv4) sobre este
folio, `F202` y `EXP3/evidencia/{C0,C1,C2,auditoria-ronda-1,ronda-1,cartas}/`. Resultado: 0 coincidencias en este
folio, en `F202` y en lo nuevo; en la evidencia, sólo el prefijo genérico de §7 y coincidencias de un fragmento
corto que, revisadas, son partes de palabras comunes. La lista queda en `{dir-de-trabajo}/privado/`.

Sigue: despacho de la ronda 2 (C0, C1, C2 y C3 brazo a, dos corridas cada uno, con coordinador) · addendum del brazo b
(paso 11 bis)
