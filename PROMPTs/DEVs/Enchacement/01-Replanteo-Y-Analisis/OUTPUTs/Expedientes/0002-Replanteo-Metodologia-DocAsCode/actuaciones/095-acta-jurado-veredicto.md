---
doc_id: EXP0002-F095
doc_type: informe
title: Acta del jurado de veredicto — votos verbatim de las rondas 1 y 2 sobre las 29 decisiones, recuento y resultado
status: vigente
origin: agent
confidence: alta en los votos (extraídos de la salida estructurada de cada juez, archivada con huella) y en el recuento; media en la lectura de las dos irregularidades de procedimiento de §4.3 y §4.4, rotulada como criterio propio
owner: presidencia de la mesa de Replanteo y análisis DocAsCode (despacho P10), que redacta y no vota
last_review: 2026-10-26
audience: [presidencia, jurado de veredicto, refutador, comisiones, PO]
traces: [TP:36, TP:53, R01:281-306, R01:597-630, RM:325-339, EXP0002-F004, EXP0002-F080, EXP0002-F085, EXP0002-F090]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-26 |
| Autor | Jurado de veredicto (cinco funciones fijas, `R01:283-291`); redacta el acta la presidencia (despacho P10), que no vota |
| Corrige | — |

Norma y secciones leídas por quien redacta: `R01` §10 (jurado, `R01:281-310`), §14 (cierre, `R01:438-451`) y §17.4
(plantilla de esta acta, `R01:597-630`), derivados de `KB-privada/Rules/Rule-Mesa.md` 1.0 §3.5.4–§3.5.7
(`RM:325-339`, `RM:372-388`). Insumos que leyó el jurado: folio 080 (análisis de decisiones), folio 085 (refutación) y,
en la ronda 2, folio 090 (reconsideración de D22).
Carta: el texto de cada despacho de juez lo armó el guion del workflow de la mesa y no se archivó por separado en
`evidencia/` (mismo caso que el folio 004 §8, excepción 3). Votos: `evidencia/P10/01-votos-jurado-veredicto.json`
(sha256 `a0f7522f3d40dc300ef5558cc19a0e872ea0fdf14a2d7d7d8f00cecb07ff6352`).

# Veredicto del jurado — expediente 0002, rondas 1 y 2

## Índice

1. [Cómo vota este jurado](#1-cómo-vota-este-jurado)
2. [Definiciones](#2-definiciones)
3. [Recuento y resultado](#3-recuento-y-resultado)
4. [Observaciones de procedimiento](#4-observaciones-de-procedimiento)
5. [Homogeneidad y rendimiento](#5-homogeneidad-y-rendimiento)
6. [Condiciones que los votos dejan a la resolución](#6-condiciones-que-los-votos-dejan-a-la-resolución)
7. [Votos verbatim de la ronda 1](#7-votos-verbatim-de-la-ronda-1)
8. [Votos verbatim de la ronda 2 (D22)](#8-votos-verbatim-de-la-ronda-2-d22)
9. [Excepciones a conocimientos](#9-excepciones-a-conocimientos)
10. [Lo no verificado](#10-lo-no-verificado)
11. [Constancia de lo creado y barrido S2](#11-constancia-de-lo-creado-y-barrido-s2)

---

## 1. Cómo vota este jurado

| Juez | Pregunta fija (`R01:285-291`) |
| --- | --- |
| J1 evidencia | ¿La decisión está anclada al nivel que declara? |
| J2 impacto | Si no se adopta, ¿qué pasa y sobre qué artefacto? |
| J3 costo-beneficio | ¿Adoptarla cuesta menos que el daño que evita? |
| J4 coherencia histórica | ¿Reabre una decisión cerrada? ¿Contradice otro veredicto del ciclo? |
| J5 riesgo | ¿Es reversible? ¿Qué se rompe si sale mal? |

Reglas aplicadas (`RM:330-339`): quórum de cinco; mayoría simple entre `PROCEDE`, `NO_PROCEDE` e `INSUFICIENTE`;
`INSUFICIENTE` vuelve una sola vez; todo voto lleva fundamento. Cada voto `PROCEDE` declara además si prefiere la
`propuesta` o la `alternativa_2` del folio 080; gana la variante que reúne más de la mitad de los `PROCEDE`.

Qué se votó. Ronda 1: las 29 decisiones D01–D29 del folio 080, con el texto de su `decision_propuesta` y su
`alternativa_2`. Ronda 2: sólo D22, la única que no reunió 3/5 `PROCEDE` en la ronda 1.

## 2. Definiciones

| Término | Significado en esta acta |
| --- | --- |
| Ronda | Una votación completa del jurado sobre la lista que recibe. Ronda 1: D01–D29. Ronda 2: la reconsideración de D22 |
| Corrida | Una ejecución de un juez como subagente del workflow. Un juez puede tener más de una corrida si el workflow se cortó y se reanudó |
| Recuento | Conteo de votos por rótulo, con la regla de `RM:331` |
| `C-n` | Corrección propuesta por el refutador en `085` §10.1 (C-1 a C-14) |
| `L-n` | Fila del lote del PO (folio 080 §11, folio 085 §10.3, folio 090 §8) |
| Unanimidad | Cinco votos con el mismo rótulo |

## 3. Recuento y resultado

### 3.1 Ronda 1 (D01–D29)

| D | PROCEDE (propuesta / alternativa_2) | NO_PROCEDE | INSUFICIENTE | Votos válidos | Resultado | Variante que gana |
| --- | --- | --- | --- | --- | --- | --- |
| D01 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D02 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D03 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D04 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D05 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D06 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D07 | 4 (4 / 0) | 0 | 0 | **4** (J5 omitió el voto; §4.4) | `PROCEDE` | propuesta |
| D08 | 5 (0 / 5) | 0 | 0 | 5 | `PROCEDE` | **alternativa_2** |
| D09 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D10 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D11 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D12 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D13 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D14 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D15 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D16 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D17 | 5 (1 / 4) | 0 | 0 | 5 | `PROCEDE` | **alternativa_2** |
| D18 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D19 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D20 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D21 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D22 | 2 (2 / 0) | 0 | 3 | 5 | `INSUFICIENTE` → reconsideración (folio 090) y ronda 2 | — |
| D23 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D24 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D25 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D26 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D27 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D28 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |
| D29 | 5 (5 / 0) | 0 | 0 | 5 | `PROCEDE` | propuesta |

Totales de la ronda 1: 28 `PROCEDE` (26 por la propuesta, 2 por la alternativa_2) y 1 `INSUFICIENTE`. Ningún
`NO_PROCEDE`. Las dos inversiones a la alternativa_2 (D08 y D17) son las dos decisiones que el refutador dio por
REFUTA (`085` §6, D08 y D17).

### 3.2 Ronda 2 (D22)

| D | PROCEDE | NO_PROCEDE | INSUFICIENTE | Votos que cuentan | Resultado |
| --- | --- | --- | --- | --- | --- |
| D22 | 2 (J2, J3; los dos por la propuesta) | 3 (J1, J4, J5) | 0 | 5 | **`NO_PROCEDE`** |

El resultado es el que computó el guion del workflow y la presidencia lo asienta sin cambiarlo. §4.2 y §4.3 explican
por qué ese resultado no cierra la pregunta de fondo y qué se hace con ella.

### 3.3 Resultado final

| Resultado | Decisiones |
| --- | --- |
| `PROCEDE`, gana la propuesta | D01–D07, D09–D16, D18–D21, D23–D29 (26) |
| `PROCEDE`, gana la alternativa_2 | D08, D17 (2) |
| `NO_PROCEDE` | D22 (1) |
| `INSUFICIENTE` | — |

## 4. Observaciones de procedimiento

### 4.1 Lo que se cumplió

- Quórum de cinco en 28 de las 29 decisiones de la ronda 1 y en la ronda 2.
- Todos los votos llevan fundamento con cita. Ningún voto queda fuera del quórum por falta de motivo (`RM:336`).
- No hubo empate ni veto del juez de riesgo.
- La ronda 2 se limitó a la decisión que no reunió 3/5 `PROCEDE`, después de una reconsideración foliada (090).

### 4.2 La ronda 2 votó el texto anterior a la reconsideración

El despacho de la ronda 2 le pasó al jurado el texto de D22 del folio 080 (`080:985-1011`), no la versión reformulada
del folio 090 §4. Los cinco jueces lo advierten en su motivo (§8):

| Juez | Qué dice sobre el texto votado |
| --- | --- |
| J1 | «El texto que se somete a voto es la D22 A original (080:985-1011) … Corresponde votar esa versión [090 §4]» |
| J2 | «la propuesta procede solo si se lee con la reformulación de 090 §4» |
| J3 | «El voto PROCEDE vale sólo para la D22 reformulada con el mismo id en 090 §4» |
| J4 | «el texto que se somete a voto es D22 A tal como estaba antes de la refutación … Lo coherente con los antecedentes es la D22 reformulada de 090 §4» |
| J5 (corrida que cuenta) | «Si esa es la versión que se vota, mi voto sería PROCEDE/propuesta» |

**Lectura de la presidencia [criterio propio].** El `NO_PROCEDE` alcanza al texto de 080. La versión de 090 §4 no fue
votada como tal, pero los cinco motivos dicen que es la que sostienen. La presidencia no vota ni convierte votos: no
puede transformar este resultado en un `PROCEDE` sobre 090 §4. Lo que corresponde es asentar el `NO_PROCEDE` del texto
de 080, archivar ese texto y someter la versión de 090 §4 al jurado como decisión propia (D22-R) en la primera
votación del ciclo siguiente. El tratamiento completo está en la resolución (folio 099, §5).

### 4.3 J5 tiene dos corridas en la ronda 2 con rótulos distintos

| Corrida | Inicio → fin (UTC) | Voto | Qué pasó |
| --- | --- | --- | --- |
| `aae814813e0ca5e43` | 22:33:29 → 22:33:53 | `PROCEDE` / propuesta | Terminó nueve segundos después de que la corrida de J4 (`a7e53cfce6abd6875`) se cortó por el límite de sesión (22:33:44) |
| `acc0b57a5831e4e84` | 23:22:13 → 23:22:38 | `NO_PROCEDE` | Corrió en la reanudación del workflow, junto con la nueva corrida de J4 (`a25df9432a534bf3e`) |

El resultado del workflow (`NO_PROCEDE`) sólo cierra con tres `NO_PROCEDE`: J1, J4 y la segunda corrida de J5. Por lo
tanto el recuento usó esa corrida y descartó la primera. **Si hubiera contado la primera, el resultado habría sido
`PROCEDE` (J2, J3, J5).** El fondo de las dos corridas es el mismo (la decisión vale sólo leída como 090 §4); cambia el
rótulo, según cada corrida haya votado el texto literal o el reformulado.

**Lectura de la presidencia [criterio propio].** La reanudación de un workflow no es una ronda nueva, y un juez no
debería votar dos veces el mismo ítem en la misma ronda. Esta acta no elige entre las dos corridas: asienta las dos
verbatim (§8), deja el resultado que computó el workflow y lo declara como irregularidad. No cambia el tratamiento
de §4.2, porque los dos rótulos apuntan a la misma salida: votar D22-R. La irregularidad va igual al lote del PO para
que conste (resolución, fila L13).

### 4.4 D07 se votó con cuatro votos

La salida de J5 en la ronda 1 (`a751d8b69b8a2478f`) trae 28 votos y omite D07. D07 queda con 4 `PROCEDE` de 4 votos
válidos. El quórum de `RM:330` es cinco («Con menos, no hay veredicto»). **Lectura de la presidencia [criterio
propio].** Cuatro `PROCEDE` ya son mayoría sobre cinco, así que el voto faltante no podía cambiar el resultado. Pero
la regla es formal: D07 se asienta como `PROCEDE` con la marca «quórum incompleto (4/5)», y su ratificación por J5
entra en la misma votación del ciclo siguiente que D22-R.

## 5. Homogeneidad y rendimiento

**Homogeneidad.** En la ronda 1, 27 de 29 decisiones salieron con cinco votos del mismo rótulo (`PROCEDE`): el 93 %.
Si D07 se cuenta como no unánime por faltarle un voto, son 26 de 29: el 90 %. En los dos cómputos se supera el 80 % de
`RM:337-338`, así que **el ciclo queda marcado como sospechoso de homogeneidad** y el refutador tiene que revisar los
`NO_PROCEDE`. En la ronda 1 no hubo ninguno. En la ronda 2 hubo tres, todos sobre D22, y esa revisión no se despachó en
esta corrida. Queda como acto pendiente del ciclo siguiente, junto con la votación de D22-R (resolución, §5).

Dos hechos acotan la sospecha **[criterio propio]**: la coincidencia del rótulo no es coincidencia de fondo, porque 19
de los 28 `PROCEDE` llevan en al menos un voto una corrección del refutador como condición (§6); y la variante
preferida se invirtió en las dos decisiones que el refutador refutó (D08 y D17). El jurado no votó en bloque la
propuesta del análisis.

**Rendimiento por comisión** (aproximación de la presidencia, **[criterio propio]**). La mesa no emitió hallazgos por
especialista sino decisiones consolidadas, así que la fórmula de `R01:305` (procedentes / (comisiones + refutador)) no
se aplica tal cual. En su lugar se cuenta en cuántas de las 28 decisiones procedentes aparece el informe de cada
comisión como fundamento de la variante ganadora (campo «fundamento» de la decisión, folio 080 §6):

| Informe | Decisiones procedentes que lo citan como fundamento de la variante ganadora | Sobre 28 |
| --- | --- | --- |
| F010 C-REQUISITOS | D01, D10, D14, D15, D21, D23, D26 | 7 |
| F011 C-VERIFICACION | D02, D04, D06, D09, D10, D18, D19, D21, D26, D28 | 10 |
| F012 C-LECTOR | D02, D05, D07, D16, D26, D27, D29 | 7 |
| F013 C-ANALISTA | D03, D06, D07, D09, D10, D11, D13, D14, D15, D16, D20, D25 | 12 |
| F014 C-ARQ-NET | D02, D03, D04, D05, D13, D19, D20, D21, D24 | 9 |
| F015 C-DECISIONES | D01, D03, D04, D06, D08, D11, D12, D13, D18, D20, D21, D23, D24, D26 | 14 |
| F016 C-ACADEMICO | D02, D06, D09, D11, D12, D18, D27, D28, D29 | 9 |
| F017 C-AGENTES-IA | D05, D06, D07, D09, D18, D19, D20, D27 | 8 |
| F085 refutador | D08 y D17 (invierte la variante); condición expresa en D03, D06, D09, D11, D13, D14, D18, D20, D21, D23, D24, D25 | 14 |

Ninguna comisión tiene aporte nulo. No se propone dejar de reconvocar a ninguna.

## 6. Condiciones que los votos dejan a la resolución

Un `PROCEDE` con condición no es un `PROCEDE` distinto: la decisión procede, y la condición es una corrección que la
resolución tiene que aplicar al asentarla. Las condiciones que repiten los votos son las correcciones del refutador:

| Corrección | Qué pide | Decisiones | Jueces que la piden en su motivo |
| --- | --- | --- | --- |
| C-1 | Estado CON REVISIÓN por celdas mínimas | D08, D12, D14, D23, D24 | D08: J2, J5 · D12: J5 · D14: J5 · D23: J1–J5 · D24: J1–J5 |
| C-2 | Renombrar clases, chequeos, controles y grupos (T3) | D03, D18, D20 | D03: J1–J5 · D18: J1–J5 · D20: J1–J5 |
| C-3 | Corregir las citas de T4 | D03, D21 | D03: J1–J5 · D21: J1–J5 |
| C-4 | D17 con `workflow_call` en la organización del runner; copia con huella y runner propio en el SDD-B; un solo job; costo real | D17 | J1, J2, J3, J5 (J4 pide las correcciones de runner, guarda y costo sobre la propuesta) |
| C-5 | Carril programado sólo en los repos públicos de la organización del runner, con tabla repo → ruta | D06 | J1–J5 |
| C-6 | El alcance de la aprobación de P pasa a la delegación (L2) | D08 | J1–J5 |
| C-7 | V2 sin las clases de especificación SDD ni de canales de sitio | D13 | J1–J5 |
| C-8 | Declarar R2–R4 en excepciones | D06, D14 | D06: J1–J5 · D14: J1–J5 |
| C-9 | Corregir la cita del CHANGELOG y sumar 13.18 a E-F9 | D24 | J1–J5 |
| C-10 | D25: fundamento corregido, condición (b) nueva, E-F3 resuelto | D25 | J1–J5 |
| C-11 | D22: nombrar el orquestador vivo del SDD-B o elevarlo al lote | D22 | Ronda 1: J1–J5 · Ronda 2: atendida por 090 §4, no votada (§4.2) |
| C-12 | D11: margen contra la excluida y uso verificable de 26514 | D11 | J1–J5 |
| C-13 | D09: `description` revisada por la persona, no «escrita» | D09, D27 | D09: J1–J5 · D27: J1 |
| C-14 | D18: el chequeo de dominios sólo avisa en el anexo de referencias; la lista pasa a P con aprobación | D18 | J1–J5 |
| Otras | D07: rotular F017 E3 como n = 2, orientativo · D16: nombrar el guion local equivalente (patrón 7 de `R03:398`) · D26: G-b de E3 corre en el runner de la otra organización · D25: fijar un umbral de lectura para «mini» (K2) | D07, D16, D26, D25 | D07: J1–J4 · D16: J1–J5 · D26: J1–J5 · D25: J1, J5 |

## 7. Votos verbatim de la ronda 1

Fuente: `evidencia/P10/01-votos-jurado-veredicto.json`, corridas `J1-evidencia-V1` (`a13c712b0c7b6c378`),
`J2-impacto-V1` (`afc3a59d7fbdf2082`), `J3-costo-beneficio-V1` (`a64dfe58b4347155f`),
`J4-coherencia-historica-V1` (`a0e871c84951888d2`) y `J5-riesgo-V1` (`a751d8b69b8a2478f`), todas del
2026-10-26 entre 22:25 y 22:28 UTC. El texto de cada motivo se copia sin cambios.

#### D01

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | Sostenida por TP:36 («que consulten los estandares») y F003 §7 (con la opción A, C-NORMAS-IA no entra nunca). K6 está abierta según F004:442 y no hay providencia posterior (085 §6). La etiqueta de TP:34 no es ruta ni usuario. Queda pendiente P-1. |
| J2 impacto | `PROCEDE` | propuesta | Impacto alto si falta la opción B: sin ella C-NORMAS-IA no entra nunca y TP:36 «estandares» queda sin especialista (F003 §7 citado en 080:304-308). F085 SOSTIENE (085:239-245); K6 abierta es real (004:442). |
| J3 costo-beneficio | `PROCEDE` | propuesta | Costo casi nulo (una providencia, P-1) y beneficio alto: sin la opción B, C-NORMAS-IA no entra nunca y TP:36 'estándares' queda sin especialista (080:302-305; 085:241-245 SOSTIENE). La etiqueta del runner no es materia de S2. No lo cubre otra decisión. |
| J4 coherencia histórica | `PROCEDE` | propuesta | Coherente con el antecedente: en EXP1 el académico quedó fuera y P10 se decidió sin esa comisión, y el jurado lo señaló como falta (EXP1/035:920). La opción B evita repetirlo y cumple F001 D3. La K6 abierta es real (004:442), y F085 D01 sostiene la decisión. P-1 (la providencia) sigue siendo un pendiente de forma. |
| J5 riesgo | `PROCEDE` | propuesta | Riesgo bajo: K6 abierta es real (F004:442, 085 §6 D01) y la etiqueta no es materia de S2. Con la opción A queda un hueco: TP:36 «estándares» se queda sin especialista. Queda pendiente la providencia P-1. |

#### D02

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | CPA §3.1 (líneas 92-104): sin delegación asentada rige el padre, así que el merge de U0 es del PO. El lychee --offline de R-E2 sobre GUIA da exit 2: la deuda sigue viva. Nota de 085: el saneamiento de GUIA sólo sirve a la línea de base 0, porque D27 pasa el archivo a obsoleto. |
| J2 impacto | `PROCEDE` | propuesta | U0 antes de U1 está medido y el merge de U0 por el PO lo exige CPA §3.1 (085:249-251). Impacto bajo de la nota de F085: anotar que el saneamiento de GUIA sirve a la línea de base y no sobrevive a D27 (085:254-257). |
| J3 costo-beneficio | `PROCEDE` | propuesta | U0 y U1 antes del enriquecimiento cuestan un PR mecánico cada uno y evitan que un rojo no diga de dónde viene (080:355-356; CPA §3.1, 085:249-251). Matiz de costo: el saneamiento de GUIA no sobrevive a D27, pero hace falta para dejar la línea de base en 0 (D18, condición 4). Hay que anotarlo en U1 (085:254-257). |
| J4 coherencia histórica | `PROCEDE` | propuesta | La delegación del antecedente cubre sólo 'los PR de esta corrida (expediente 0001)' (EXP1/007, tabla de parámetros), así que el 0002 necesita una propia. CPA §3.1 (líneas 92-104) dice que, sin delegación, rige el padre. El workflow del 0001 en Lab-Documentos sigue sin versionar ('?? .github/', git status del 2026-10-26), por lo que U0 es el primer merge real y le corresponde al PO. Hay que anotar que el saneamiento de GUIA no sobrevive a D27 (F085 D02). |
| J5 riesgo | `PROCEDE` | propuesta | CPA §3.1 (líneas 92-104) sostiene que el merge de U0 sea del PO; lychee --offline sobre GUIA da exit 2 (085 R-E2). Riesgo menor: el saneamiento de GUIA no sobrevive a D27 y hay que anotarlo (085 §6 D02). La alternativa arrastra la deuda al enriquecimiento. |

#### D03

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | Sostenida por I01:200 («Se recorre por pieza documental… la industria mezcla topologías según la pieza») y por F013 §5 (17 piezas en 3 topologías). Hay que corregir la cita: la frase entre comillas no existe en I01 (085 T4). También hay que renombrar las clases por la colisión de T3. |
| J2 impacto | `PROCEDE` | propuesta | «Por pieza» lo sostiene I01:200 aunque la frase entre comillas no es literal (085:261-265). Corregir la cita y renombrar las clases (T3) es de forma: no cambia el dictamen. |
| J3 costo-beneficio | `PROCEDE` | propuesta | El catálogo resuelve D1-D8 una sola vez, contra recorrerlo por proyecto (B, 3,60): ahorro neto a escala (080:374-380; I01:200-213). Correcciones baratas: quitar las comillas de la cita no literal de I01:200 (T4) y renombrar las clases a CL-nn (T3, 085:184-187). Hay solapamiento con D20: D03 decide el principio y D20 el contenido de las filas. Conviene que D20 lo diga para no duplicar. |
| J4 coherencia histórica | `PROCEDE` | propuesta | Ni EXP1 ni la norma tienen un precedente en contra. I01:200 sostiene 'por pieza', pero la cita entre comillas no es literal (F085 T4) y hay que corregirla. Las clases deben renombrarse a CL-nn porque chocan con los chequeos C1-C5 (F085 T3). |
| J5 riesgo | `PROCEDE` | propuesta | I01:200 sostiene «por pieza». Riesgo de forma: la cita entre comillas no es literal (085 T4), y el rótulo C1-C14 choca con los chequeos C1-C5, cosa que un agente sin contexto no resuelve (085 T3). Renombrar a CL-nn (C-2). Recorrer D1-D8 pieza por pieza en cada proyecto multiplica el trabajo y la deriva. |

#### D04

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | Sostenida por TP:20 (c), el desfase de versionado. El refutador verificó 0 tags en los tres repos y los SHA 8fb4c3a/4b114d7/1585af9 (085 §6 D04). El SHA es la única ancla que existe siempre. |
| J2 impacto | `PROCEDE` | propuesta | Los tres repos tienen 0 tags (verificado en 085:269-270): el SHA es la única ancla que existe siempre. No hay ataque que cambie el resultado. |
| J3 costo-beneficio | `PROCEDE` | propuesta | El SHA es la única ancla que existe siempre: hay 0 tags en los tres repos, verificado (085:269-270). Llevar SemVer por documento (alt. 2) cuesta un cambio de versión por edición sin lector que lo pida (080:412-414). Buena relación costo-beneficio. |
| J4 coherencia histórica | `PROCEDE` | propuesta | Sigue lo que fijó el antecedente: contenido con SemVer+commit y artefactos sólo desde una etiqueta alcanzable desde main (EXP1/035 P6.7 y P7). La fila 9 de §9 lo declara alineado con Versionado-Producto-Integral. Verifiqué 0 tags (F085 D04). |
| J5 riesgo | `PROCEDE` | propuesta | Hay 0 tags en los tres repos (085 §6 D04): el SHA es la única ancla que existe siempre. Una SemVer por documento suma costo en cada cambio sin cerrar un hueco medido. |

#### D05

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | Docusaurus Versioning, reconsultada (EVR/07 §6): «Most of the time, you don't need versioning». F014 E5/E7: DocFX no emite .md por página de la prosa. F017 E1: el archivo fuente rinde mejor. Es además lo más barato en el runner efímero (085 T2). |
| J2 impacto | `PROCEDE` | propuesta | Docusaurus reconsultada (EVR/07 §6); sin generador no hay nada que instalar en el runner efímero, así que es la opción más barata bajo T2 (085:278-279). |
| J3 costo-beneficio | `PROCEDE` | propuesta | Las guías sin generador son la opción más barata en un runner efímero sin estado, porque no hay nada que instalar (085:278-279). DocFX para las guías no da .md por página de la prosa (080:455-458). La cita de Docusaurus se reconsultó (EVR/07 §6). |
| J4 coherencia histórica | `PROCEDE` | propuesta | El antecedente publicó la guía sin generador, con Developer-Guide.md como índice único leído en GitHub (EXP1/035 P10). La cita de Docusaurus sobre no versionar se reconsultó (F085 D05). En el runner efímero es la opción más barata. |
| J5 riesgo | `PROCEDE` | propuesta | Docusaurus Versioning, reconsultada: «Most of the time, you don't need versioning» (085 EVR/07 §6). Sin generador no se instala nada en el runner efímero (085 T2), que es la opción de menor riesgo operativo. |

#### D06

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | La necesidad está medida: el relativo entre repos se rompió 8 de 9 veces en GUIA (F016 E04) y en 29 destinos de LE (F011 E03). Procede condicionada a C-5 y C-8 de 085. El carril programado con --root-dir no corre tal cual en el runner efímero, que sólo conserva /cache (EVR/06), y no alcanza al SDD-B. Hay que declarar R3 (RDA:22) y R4 (issues: write). |
| J2 impacto | `PROCEDE` | propuesta | El núcleo vale: el carril PR es determinista y la cita usa ID calificado. El carril programado no corre como está escrito en un runner efímero, y el SDD-B es de otra organización (085:289-295). Impacto medio, que se corrige sin cambiar la decisión: C-5 y declarar R3/R4 (085:298-303). |
| J3 costo-beneficio | `PROCEDE` | propuesta | El carril PR bloqueante es barato y está medido (8/9 enlaces rotos entre repos, 080:473-476). Para que el beneficio sea real hay que aplicar C-5: el carril programado sólo sobre los repos públicos de la organización del runner, con una tabla repo→ruta, y además declarar issues: write y la tensión con RDA:22 (085:297-303). El 'sólo aviso' de la alternativa 2 renuncia al carril de menor costo. |
| J4 coherencia histórica | `PROCEDE` | propuesta | El carril PR bloqueante, offline y sin secretos repite el patrón del antecedente: permissions contents: read y ningún secreto en los jobs de PR (EXP1/035 P6.4; framework-concept-demo.yml). El carril programado tiene que corregirse según F085 D06: sólo repos públicos de la organización del runner, una tabla repo→ruta, issues: write declarado como excepción a R03:393, y la tensión con RDA:22 asentada en §9. |
| J5 riesgo | `PROCEDE` | propuesta | El carril PR es sólido. Hay un hueco: el carril programado no corre como está escrito, porque el runner es efímero, no tiene el árbol del workspace, el SDD-B es de otra organización y hace falta issues:write (085 §6 D06, T2). Procede con C-5 y con R3-R4 declaradas en §9 (085 §9). Si queda sólo el aviso, se pierde la detección determinista. |

#### D07

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | Sostenida por TP:20 (e) y TP:32, la doble audiencia. llmstxt.org la presenta como «A proposal» (EVR/07 §7), lo que sostiene la corrección de GUIA:161. La condición «si hay sitio» es coherente con D05. F017 E3 tiene n = 2: rotularlo como orientativo. |
| J2 impacto | `PROCEDE` | propuesta | llmstxt.org «A proposal» reconsultada (EVR/07 §7). F017 E3 tiene n = 2, pero no sostiene la decisión: hace cumplir la compuerta de D18 (085:308-310). |
| J3 costo-beneficio | `PROCEDE` | propuesta | Hacer los canales condicionales al sitio evita piezas sin lector mientras no haya sitio (D05). La alternativa 2 crea llms.txt y .md sin publicar nada. llms.txt es 'A proposal' (EVR/07 §7). Hay que rotular F017 E3 como n = 2, orientativo (085:308-310). |
| J4 coherencia histórica | `PROCEDE` | propuesta | Es coherente con F001 D5: la ia-db es un índice (R03:141-156). llms.txt figura como 'A proposal' en la fuente reconsultada (F085 D07). El dato de E3 (n=2) debe rotularse como orientativo. |
| J5 riesgo | — | — | **Sin voto**: la salida de `J5-V1` (agente `a751d8b69b8a2478f`) trae 28 votos y omite D07 |

#### D08

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | alternativa_2 | El fundamento de la propuesta no se sostiene. Verifiqué CPA §3.4 (líneas 141-160): la reserva es «una decisión pendiente sobre el contenido entregado», no todo borrador P, y amplía §3.4 sin declararlo. TP:32 pide que la IA pueda intervenir de forma automática. La evidencia favorece que la delegación cubra P sin reserva, con la lista H y los cinco actos humanos. El alcance lo fija el PO en la fila L2 (085 C-6). |
| J2 impacto | `PROCEDE` | alternativa_2 | Verifiqué CPA §3.4: la reserva 1 habla de «una decisión pendiente sobre el contenido», no de todo borrador P. D08 A amplía §3.4 sin declararlo y frena cada PR de un equipo de una persona, contra TP:32 (085:314-324). Impacto alto. Prefiero la delegación sobre P con la lista H intacta, como parámetro de L2 que decide el PO (085:327-335); CON REVISIÓN (3 celdas, T1). |
| J3 costo-beneficio | `PROCEDE` | alternativa_2 | La propuesta amplía CPA §3.4 sin declararlo. La reserva 1 dice 'una decisión pendiente sobre el contenido', no 'todo borrador P' (verificado en CPA:141-160; 085:314-318). Con un equipo de una persona (R03:212-214), aprobar cada PR de agente es el costo dominante y contradice TP:32. El beneficio de control ya lo dan la compuerta determinista y la regla verificador ≠ redactor (085:332-333). La alternativa 2 se acepta con la lista H y los cinco actos humanos intactos, y el alcance queda como parámetro de la delegación del PO (L2 ampliada). |
| J4 coherencia histórica | `PROCEDE` | alternativa_2 | El antecedente fijó dos formas de merge con el mismo control: automática con delegación asentada y guardas G1-G4, sin pedir una aprobación por PR según quién redactó (EXP1/035 P6.5). La regla vigente del PO es que todo PR pasa por CPA. CPA:149 reserva sólo la 'decisión pendiente', y leerlo como 'todo P' amplía §3.4 sin declararlo (F085 D08, REFUTA). Los actos H y los PR que declaren una decisión pendiente vuelven a la persona. |
| J5 riesgo | `PROCEDE` | alternativa_2 | La propuesta lee CPA:149 como «todo P es contenido». La fuente habla de una «decisión pendiente», así que amplía §3.4 sin declararlo (085 §6 D08, R1) y frena a un equipo de una persona (R03:212-214) contra TP:32. Prefiero la alternativa: P se fusiona por la guarda cuando no hay reserva de §3.4. Se conservan la lista H y verificador ≠ redactor, y el alcance lo asienta el PO en L2. Es CON REVISIÓN (3 celdas, 085 T1). |

#### D09

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | RDA:21 trae los 10 campos y R07:366 confirma que el Profile no fija contrato: la extensión está justificada. Corregir según C-13 de 085: ninguna compuerta puede verificar «escrita por una persona». Debe decir obligatoria, ≤160 caracteres y revisada por la persona en el PR que pasa a vigente. |
| J2 impacto | `PROCEDE` | propuesta | Los 10 campos de RDA:21 y R07:366 se verificaron. Ningún validador puede comprobar «escrita por una persona» (085:341-344). Impacto bajo con C-13: la description se revisa en el acto H que pasa el documento a vigente. |
| J3 costo-beneficio | `PROCEDE` | propuesta | Cuesta poco: 207 de 219 documentos ya siguen el vocabulario de CGT (080:583) y no obliga a renombrar IDs, que sí pide la alternativa 2. Corrección C-13: 'description escrita por una persona' no tiene observable ni compuerta. Debe ser obligatoria, de hasta 160 caracteres, y revisada por la persona en el PR que pasa status a vigente (085:341-346). |
| J4 coherencia histórica | `PROCEDE` | propuesta | Los 10 campos salen de RDA:21, y R07:366 confirma que el Profile no fija contrato. Hay que corregir 'escrita por una persona', que no es verificable: description pasa a ser obligatoria y revisada por la persona al pasar a vigente (F085 D09). |
| J5 riesgo | `PROCEDE` | propuesta | Es fiel a RDA:21 y R07:366. Riesgo de aplicación: ninguna compuerta puede verificar «description escrita por una persona», y eso choca con la clase P (085 §6 D09). Aplicar C-13: description obligatoria y revisada en el acto H que pasa status a vigente. Un prefijo global no responde a ningún requisito presente. |

#### D10

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | KDR:402/404 dicen lo citado y el apartamiento está declarado y va a L5. La necesidad está medida: 9/9 trazas de EXAMPLES dan rojo (F011 E06) y el commit 946d023 renombró ruta y clase (F010 E3). TP:20 (c). |
| J2 impacto | `PROCEDE` | propuesta | KDR:402/:404 dicen lo citado y el apartamiento está declarado y va al lote como L5 (085:351-354). F085 no ataca nada. |
| J3 costo-beneficio | `PROCEDE` | propuesta | Sin esta decisión E2 no pasa: hoy 9/9 trazas dan rojo (080:648-650). La alternativa 2 exige tocar el código de LE, con un costo que esta corrida no tiene autorizado. El apartamiento de KDR §5.1 está declarado y va al lote L5 (085:351-354). |
| J4 coherencia histórica | `PROCEDE` | propuesta | El apartamiento de KDR §5.1 ('Ancla' archivo:línea en KDR:404, 'Id' RN-nn en KDR:402) está declarado y va al lote (L5). Así lo piden Excepcion-A-Un-Conocimiento y la regla de avisar al PO de los apartamientos (080 §9, filas 1-2). |
| J5 riesgo | `PROCEDE` | propuesta | KDR:402 y KDR:404 dicen lo citado, y el apartamiento está declarado y va al lote (085 §6 D10). La alternativa exige tocar el código de LE, que está fuera de alcance en E1. |

#### D11

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | La necesidad sale literal de TP:36 («que consulten los estandares», «estandares de la industria»), vía F6. El alcance de 26514 está verificado (I05:125). El tablero debe decir que el margen real es 0,05 contra B y que lo decide F6, y que de 26514 sólo se usa el alcance y el índice, ninguna cláusula (085 C-12). |
| J2 impacto | `PROCEDE` | propuesta | La decide F6 con un margen real de 0,05 contra B (085:358-361). Si el filtro faltara cambiaría poco: ganaría B y el contenido operativo sería casi el mismo. Aplicar C-12 y declarar que de 26514 sólo se usan el alcance (I05:125) y el índice. |
| J3 costo-beneficio | `PROCEDE` | propuesta | Cuesta casi nada: no hay compra (D12) y se cita sin apartado. La impone F6/TP:36. Pero el beneficio verificable es sólo el alcance de 26514 (I05:125), y el margen real contra B es 0,05, decidido por un filtro (085:358-369). Hay que aplicar C-12 y declararlo así. La alternativa 2 no tiene demanda contractual. |
| J4 coherencia histórica | `PROCEDE` | propuesta | El antecedente ya usó Diátaxis como fundamento de la estructura (EXP1/035:705). La cita de alcance de 26514 está verificada (I05:125). Falta informar el margen real, 0,05 contra B, que lo decide F6, y aclarar que de 26514 sólo se usa su alcance (F085 D11). |
| J5 riesgo | `PROCEDE` | propuesta | Riesgo de sesgo: el margen real contra B es 0,05, la elección la decide F6 y nadie leyó las cláusulas de 26514 (085 §6 D11). Procede con C-12: informar ese margen y usar de 26514 sólo el alcance verificable (I05:125). La 2651x completa con DITA es desproporcionada. |

#### D12

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | Es consecuente con D11. La condición de compra es comprobable. El precio no está verificado (ISO dio 403, F016 §12), pero no hace falta para no comprar. Es reversible. |
| J2 impacto | `PROCEDE` | propuesta | Es consecuente con D11, la condición de compra es comprobable y la decisión es reversible por diseño (085:373-374). |
| J3 costo-beneficio | `PROCEDE` | propuesta | No comprar ahorra un costo cuyo beneficio hoy nadie necesita, y la condición de compra se puede comprobar (085:373-374). Sale de D11 y se superpone en parte con su condición de revisión. Como acto de gasto, conviene que quede como decisión aparte. |
| J4 coherencia histórica | `PROCEDE` | propuesta | Se sigue de D11. La condición de compra se puede comprobar y la decisión es reversible (F085 D12). Ningún precedente compró una norma de pago. |
| J5 riesgo | `PROCEDE` | propuesta | Es consecuente con D11, la condición de compra es comprobable y es reversible por diseño (085 §6 D12). Es frágil en celdas (3, T1): queda CON REVISIÓN. |

#### D13

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | R05:120 sostiene que hoy no hay roles en todos los sistemas, así que un tronco con variantes está justificado. Corregir según C-7 de 085: V2 activa C1 (SDD) y C14 (sitio), y MovilidadUrbana no tiene ni SDD ni sitio (D10, D05). |
| J2 impacto | `PROCEDE` | propuesta | Error interno de la tabla: V2 activa C1 y C14, y MovilidadUrbana no tiene SDD ni sitio (085:378-382). La corrección C-7 no cambia la decisión del tronco con variantes. |
| J3 costo-beneficio | `PROCEDE` | propuesta | El tronco con variantes evita inventar roles donde no los hay (R05:120). Corrección C-7, gratuita: V2 sin C1 ni C14, porque MovilidadUrbana no tiene SDD ni sitio. Si no, un agente crearía piezas que la propia mesa descartó (085:378-384). |
| J4 coherencia histórica | `PROCEDE` | propuesta | Ningún precedente se opone. La tabla de la variante V2 debe corregirse: C1 (SDD) y C14 (sitio) quedan inactivas en MovilidadUrbana, porque la demo no tiene SDD (D10) ni sitio (D05) (F085 D13). |
| J5 riesgo | `PROCEDE` | propuesta | Hay un hueco interno: V2 activa C1 (SDD) y C14 (sitio), y MovilidadUrbana no tiene ninguno de los dos. Un agente crearía SDD/ y llms.txt donde la mesa decidió que no van (085 §6 D13). Aplicar C-7. Una metodología idéntica obliga a inventar roles (X6). |

#### D14

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | TP:26 nombra cinco fases y «mantenim» aparece 0 veces en TP (085 §7 #3). Hay que declarar en §9 la excepción R2: REF §2.1 (líneas 52-61) no prevé Requerimientos-Documentales.md en 02-Especificacion-Funcional/. Viaja por el ADR de D23 y L4. |
| J2 impacto | `PROCEDE` | propuesta | Las cinco fases se sostienen («mantenim» aparece 0 veces en TP; TP:26). El RRD en 02-Especificacion-Funcional/ queda fuera de REF §2.1 y es una excepción no declarada (085:390-395). Impacto medio, que se resuelve declarando R2 por el ADR de D23. |
| J3 costo-beneficio | `PROCEDE` | propuesta | Las cinco fases no dependen del PO; la alternativa 2 sí, con el mismo contenido (080:777-779). Hay un costo no declarado: el RRD en 02-Especificacion-Funcional/ no está en la tabla de REF §2.1. Se declara como R2 y viaja por el ADR de D23 (085:389-399). Corregirlo cuesta una fila en §9. |
| J4 coherencia histórica | `PROCEDE` | propuesta | Las cinco fases son literales de TP:26. En cambio, ubicar el RRD en 02-Especificacion-Funcional/ es un apartamiento no declarado de REF §2.1 (líneas 52-61; grep 'Requerimientos-Documentales' da 0). Por la norma Excepcion-A-Un-Conocimiento tiene que declararse en §9 y viajar por el ADR de D23 (F085 D14). |
| J5 riesgo | `PROCEDE` | propuesta | TP:26 nombra cinco fases y «mantenim» aparece 0 veces en TP (085 §6 D14). Pero el RRD en 02-Especificacion-Funcional/ no está en la tabla maestra de REF §2.1: es una excepción no declarada (R2) y tiene que viajar por el ADR de D23. Seis fases inventan una fase que el pedido no trae. CON REVISIÓN (3 celdas). |

#### D15

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | Expediente-Rules.md:268-271 y :420-423 (A13) dicen lo citado (085 §7 #35). R04:322-323 muestra que hoy el reintegro no se ejerce. Reusa la norma sin apartarse. |
| J2 impacto | `PROCEDE` | propuesta | Expediente-Rules.md:268-271 y :420-423 dicen lo citado (085:403-404). |
| J3 costo-beneficio | `PROCEDE` | propuesta | Reutiliza lo que IA.SDD ya mide (Expediente-Rules A13/A15, 085:403-404) sin piezas nuevas. Con reintegro a criterio (alt. 2), hoy el reintegro no se ejerce (R04:322-323). |
| J4 coherencia histórica | `PROCEDE` | propuesta | Lo dicen textualmente Expediente-Rules.md:268-271 y :420-423 (A13). El antecedente es justamente un caso sin versionar ni reintegrar (R01 H-01), y esa falta es la que el control de reintegro previene. |
| J5 riesgo | `PROCEDE` | propuesta | Expediente-Rules.md:268-271 y :420-423 (A13) dicen lo citado (085 §6 D15). Con reintegro a criterio quedaría un hueco de rastro. |

#### D16

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | Sostenida literalmente por TP:32: que los agentes humanos entiendan el flujo para intervenir. F012 H-L04: no hay CONTRIBUTING, AGENTS.md ni CODEOWNERS. El paso «validar» necesita un guion local que instale las herramientas: es el patrón 7 de R03:398. |
| J2 impacto | `PROCEDE` | propuesta | Sostenida. Sólo falta nombrar el guion local equivalente (patrón 7 de R03:398), porque el runner no trae las herramientas (085:408-409). |
| J3 costo-beneficio | `PROCEDE` | propuesta | Una página por proyecto cuesta poco y cubre el corte del play testing en validar y proponer (080:809-811). Se solapa con la clase C12 de D20, que la contiene. Hay que nombrar el guion local equivalente (patrón 7 de R03:398), porque el runner no trae las herramientas (085:408-409). |
| J4 coherencia histórica | `PROCEDE` | propuesta | Repite el patrón del antecedente: el workflow declara su 'equivalente local, con los mismos pasos en el mismo orden: .../scripts/ci-local.sh' (framework-concept-demo.yml, cabecera). Es el patrón 7 de R03:398 (F085 D16). |
| J5 riesgo | `PROCEDE` | propuesta | Es coherente con R03:398 (patrón ci-local). El guion local tiene que instalar las herramientas porque el runner no las trae (085 §6 D16, T2). Con sólo la plantilla de PR, la persona no ve el flujo (TP:32). |

#### D17

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | alternativa_2 | Cae el fundamento del descarte de workflow_call. Verifiqué EVR/07 §1: la referencia oficial dice que el llamado «can access self-hosted runners from the caller's context», con el mismo dueño. La copia sin compuerta deriva (X4). Condiciones: confirmar en U0 con E-F12. El SDD-B, de otra organización, necesita copia con huella y su propio runner (L10, EVR/06). El costo real es de ≈2 min 40 s por PR (T2). |
| J2 impacto | `PROCEDE` | alternativa_2 | Verifiqué EVR/07 §1: la referencia oficial dice que el workflow llamado «can access self-hosted runners from the caller's context». Con eso cae el fundamento del descarte de workflow_call, y la copia sin --check reabre la deriva de X4 (085:413-426). Impacto alto: el rescore empata en 4,15. Prefiero workflow_call dentro de la organización del runner, CON REVISIÓN hasta E-F12, y para el SDD-B copia con huella en su propio runner (L10). |
| J3 costo-beneficio | `PROCEDE` | alternativa_2 | El descarte de workflow_call se cae. La referencia oficial dice que los workflows llamados 'can access self-hosted runners from the caller's context' cuando el dueño es el mismo (verificado en EVR/07 §1; 085:413-420). Una sola fuente evita copias que derivan sin compuerta, el mismo problema que D21 resuelve. Condiciones: confirmarlo con E-F12 en U0; en el SDD-B, copia con huella y runner de su organización (L10); un solo job para pagar un único ciclo efímero (≈68 s; 085:160-165, 437-447). |
| J4 coherencia histórica | `PROCEDE` | propuesta | Históricamente cada repo tuvo su propio workflow de PR: un solo workflow con guarda de mismo repositorio (EXP1/035 P6.2 y P6.4) y e2e.yml en Geometría, y funcionó en el runner. Lleva tres correcciones. (1) En el SDD-B, la etiqueta del runner de su propia organización (F085 T2-1). (2) La guarda if: es higiene; la barrera real es la aprobación de forks que ya fijó EXP1/035 P6.4, y es un acto H del PO. (3) Un costo por PR realista. E-F12 decide si conviene pasar a workflow_call. |
| J5 riesgo | `PROCEDE` | alternativa_2 | El descarte de workflow_call cae: la referencia oficial «Reusing workflow configurations» dice que el workflow llamado accede a los runners self-hosted del que llama (085 §6 D17, EVR/07 §1). Corregido, el puntaje empata en 4,15. La copia por repo no tiene compuerta de deriva (X4). Además, la propuesta pone al SDD-B en i7infra-dev, que no existe en su organización (085 T2-1). Procede B condicionada a E-F12, con copia fijada con huella y runner propio para el SDD-B (L10) y un solo job. El costo real es de unos 2 min 40 s por PR. |

#### D18

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | La regla de cinco condiciones es la unión de F011 §3.6 y F015 Q23. F017 E2 (exit 1) está en la evidencia. Correcciones C-2 y C-14 de 085: renombrar K/C por la colisión de T3, y que C4 sólo avise en el anexo ref-. Si no, las 12 hosts nuevas de las 20 referencias de D28 frenan cada PR. La guarda de forks no es barrera (T2-3). |
| J2 impacto | `PROCEDE` | propuesta | La regla de cinco condiciones es la unión exacta de F011 y F015 (085:451-452). La lista de dominios como H frena D28: hay 12 hosts en 20 referencias (085:456-459). Impacto medio, que se corrige con C-14 y el renombre de T3 sin cambiar la regla. |
| J3 costo-beneficio | `PROCEDE` | propuesta | La regla de cinco condiciones es la unión exacta de F011 y F015, sin costo nuevo. La lista de dominios en clase H es un cuello de botella medido: 12 hosts en 20 referencias contra 6 hoy (085:455-459). Hay que aplicar C-14: C4 sólo avisa en el anexo ref-, y la lista pasa a P con aprobación. También renombrar K/C (T3). 'Todo avisa' renuncia al bloqueo determinista. |
| J4 coherencia histórica | `PROCEDE` | propuesta | El antecedente hizo bloquear toda suite que entra al agregador y descartó el modo aviso para lo determinista (EXP1/035 P6.3 y P6, 'Qué se descartó'). La regla de cinco condiciones es coherente con eso y gradúa lo heredado. Hay que aplicar los renombres de T3 y el aviso de dominios en el anexo ref- (F085 D18). |
| J5 riesgo | `PROCEDE` | propuesta | La regla de cinco condiciones es la unión de F011 §3.6 y F015 Q23. Riesgos: los rótulos K/C chocan (085 T3), y con la lista de dominios en clase H cada referencia nueva frena el PR (12 hosts contra 6, 085 §6 D18). La guarda de forks no es barrera (T2-3). Aplicar C-2 y C-14. Con «todo avisa» la deriva queda sin control. |

#### D19

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | Medido: LE .csproj:10-11 ya tiene GenerateDocumentationFile y NoWarn CS1591. R-E4 reprodujo 8 operaciones. Con grupo de método los summary caen de 8 a 0 (F014 E3b). TP:20 (c). |
| J2 impacto | `PROCEDE` | propuesta | El .csproj de la ApiWeb se verificó (:10-11) y R-E4 reprodujo las 8 operaciones (085:469-471). |
| J3 costo-beneficio | `PROCEDE` | propuesta | Está medido: 8 operaciones, deriva plantada → exit 1. Sin NoWarn salen 114 errores en la ApiWeb (080:918-921). La alternativa 2 cuesta errores sin lector en las apps. En E1 no se toca LE, así que no hay costo inmediato (085:469-472). |
| J4 coherencia histórica | `PROCEDE` | propuesta | El antecedente compilaba con avisos como error (P8; framework-concept-demo.yml). Verifiqué el .csproj de la ApiWeb, líneas 10-11 (F085 D19). No toca el código de LE en E1. |
| J5 riesgo | `PROCEDE` | propuesta | El .csproj de la ApiWeb ya tiene GenerateDocumentationFile y NoWarn CS1591, y R-E4 reprodujo 8 operaciones (085 §6 D19). CS1591 en todo agrega ruido en las apps sin ganancia. |

#### D20

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | Responde a la decisión 2 de la presidencia y a TP:36 («arquitectura clara»). Debe absorber T3 (renombres), C14 como latente sin sitio, la excepción R2 de D14 y los carriles corregidos de D06 y D17 (085 §6 D20). |
| J2 impacto | `PROCEDE` | propuesta | Cumple la decisión 2 de la presidencia (085:476-477). Hereda los defectos de T3, D06, D14 y D17, que son correcciones de forma, y C14 queda marcada como latente (085:484-485). |
| J3 costo-beneficio | `PROCEDE` | propuesta | Cumple la decisión 2 de la presidencia (F7). Gran parte la cubren D03, D04, D07 y D18; su aporte propio son las columnas de audiencia, canal, intervención y tema, y el flujo del sistema. Corregir arrastres: T3, C14 marcada como latente, la excepción de D14 y los carriles de D06/D17 (085:478-485). Un portal agregador cuesta infraestructura sin requisito que lo pida. |
| J4 coherencia histórica | `PROCEDE` | propuesta | Responde a F001 D2. Hay que incorporar las correcciones de T3, D06, D14 y D17, y marcar C14 como latente (F085 D20). |
| J5 riesgo | `PROCEDE` | propuesta | Responde a la decisión 2 de la presidencia (F001 D2), pero arrastra T3, una C14 sin activar y lo de D06, D14 y D17 (085 §6 D20). Procede con esas correcciones y con C14 marcada «latente». Un portal multi-repo no tiene requisito hoy. |

#### D21

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | copiar.py, cierre.py y --check existen (IKB/README.md:70-80; ls). F011 E08: git archive da 14/14 y la deriva plantada da exit 1. Sostenida por TP:18 (d) y X4 (R03:256-267). Corregir la ruta a /IA/SDD/IA.SDD/Conocimiento/Index-Knowledge.md:24-25 (T4). |
| J2 impacto | `PROCEDE` | propuesta | copiar.py, cierre.py y --check existen (085:489-490). Sólo hay que corregir la ruta de Index-Knowledge (T4). |
| J3 costo-beneficio | `PROCEDE` | propuesta | El mecanismo ya existe: copiar.py, cierre.py y --check (085:489-492). git archive está medido 14/14 sin red (080:961-963). Sólo falta corregir la ruta de Index-Knowledge (T4). La alternativa 2 es la mitigación de Q35, todavía sin medir (E-F5). |
| J4 coherencia histórica | `PROCEDE` | propuesta | Coincide con la norma: 'un documento que se suma desde otro repositorio llega con su cierre' (/IA/SDD/IA.SDD/Conocimiento/Index-Knowledge.md:24-25). copiar.py y cierre.py existen (IKB/README.md:70-80). Sólo hay que corregir la ruta citada (F085 T4). |
| J5 riesgo | `PROCEDE` | propuesta | copiar.py, cierre.py y --check existen (085 §6 D21). Sólo hay que corregir la ruta a /IA/SDD/IA.SDD/Conocimiento/Index-Knowledge.md:24-25 (T4). El --check del SDD-B corre en el runner de su organización. |

#### D22

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `INSUFICIENTE` | propuesta | TP:30 pide «mejorando los agentes orquestadores de ambos». Para el SDD-B la propuesta sólo carga en la mesa y suma K1 al CI, y ninguna de las dos toca un orquestador. R04:190-192: los AG-xx están dormidos. Falta nombrar el orquestador vivo del SDD-B con un cambio verificable, o elevar la fila L12 (085 C-11). Además, K1 en su CI corre en el runner de otra organización. |
| J2 impacto | `INSUFICIENTE` | propuesta | La decisión 1 de la presidencia y TP:30 piden mejorar los orquestadores «de ambos». En el SDD-B la propuesta sólo toca la mesa y el CI, y ninguno de los dos es orquestador (R04:190-192; 085:501-505). Impacto alto: sin C-11 o L12 la compuerta E3 no puede dar PROCEDE (085:512-513). Vuelve una vez para nombrar el orquestador vivo o elevarlo al lote. |
| J3 costo-beneficio | `PROCEDE` | propuesta | Es barata: un conocimiento más docs-guard, sin subagentes, y evita mejorar AG-xx dormidos (R04:190-192). Pero tal como está no cumple 'ambos': en el SDD-B ningún orquestador cambia (085:501-513). Requiere C-11: nombrar el punto de entrada vivo y fijarle un cambio verificable, o elevarlo al lote (L12). Además, K1 en su CI corre en el runner de la otra organización. |
| J4 coherencia histórica | `INSUFICIENTE` | propuesta | R04:190-192 registra que los AG-xx no cambian desde el 2026-08-29 y que lo vivo es la mesa. En el SDD-B, la propuesta no toca ningún orquestador, y F001 D1 pide 'mejora de orquestadores de ambos SDD'. Vuelve una vez para nombrar el orquestador vivo del SDD-B con un cambio verificable, o para elevar al lote que está dormido (F085 D22). |
| J5 riesgo | `PROCEDE` | propuesta | Hueco contra la decisión 1 de la presidencia y TP:30 («ambos»): en el SDD-B ningún orquestador cambia, porque la mesa no es orquestador y R04:190-192 dice que los AG-xx están dormidos (085 §6 D22). Procede sólo con C-11: nombrar el orquestador vivo y fijar en él un cambio verificable, o elevar L12. Si no, E3 no puede dar PROCEDE. La importación inmediata agrega riesgo sin validar. |

#### D23

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | RDOC:102/457/723/801/1003, Root-Rules.md:646 y Experiencia-De-Uso.md:100 dicen lo citado (085 §7 #33-34, #39). TP:14 y TP:20 (g) fundan la inclusión. Como 2 celdas la invierten, el estado debe ser CON REVISIÓN. Suma la excepción del RRD (D14). |
| J2 impacto | `PROCEDE` | propuesta | Las citas de RDOC y Root-Rules:646 son exactas (085:517-520). Con 2 celdas se invierte (T1), así que el estado es CON REVISIÓN y no FIRME, y se le suma la excepción R2 (085:521-523). |
| J3 costo-beneficio | `PROCEDE` | propuesta | Las citas de RDOC y Root-Rules:646 son exactas (085:517-520). El costo extra frente al apartamiento solo es una fila de lote que se retira si E2 no necesita el rol. Queda CON REVISIÓN: dos celdas la invierten (T1). Absorbe también la excepción del RRD de D14. |
| J4 coherencia histórica | `PROCEDE` | propuesta | La vía normativa sigue la norma: apartamiento por ADR (Root-Rules §11 y :646; Excepcion-A-Un-Conocimiento) y propuesta de cambio de norma al lote. Las citas de RDOC:102 y de Experiencia-De-Uso.md:100 son exactas. Queda CON REVISIÓN (2 celdas, F085 T1) y suma la excepción del RRD de D14. |
| J5 riesgo | `PROCEDE` | propuesta | Las citas de RDOC:102 y :457, Root-Rules.md:646 y Experiencia-De-Uso.md:100 son exactas (085 §6 D23). Es frágil: 2 celdas la invierten (T1), así que va CON REVISIÓN, no FIRME. Con sólo el apartamiento, el patrón se repite en cada sistema (Root-Rules:646). |

#### D24

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | El fondo se sostiene: la piloto corre la Fase I, que cambia en 13.20-13.22 (reintegración, CPA, Excepcion-A-Un-Conocimiento). Hay que corregir la cita. Verifiqué CHANGELOG: «Ninguno obligatorio» aparece en 3 de 6 (:54, :106, :185), y 13.18 (:273) dice «no es ninguno» y nombra a Lab-Geometria. Sumarlo a E-F9. Estado: CON REVISIÓN. |
| J2 impacto | `PROCEDE` | propuesta | Verifiqué CHANGELOG: sólo 3 de 6 versiones dicen «Ninguno obligatorio» y 13.18:273-277 nombra a Lab-Geometria. La cita es falsa, pero la razón de fondo vale: la Fase I cambia entre 13.20 y 13.22 (085:537-538). CON REVISIÓN, con la cita corregida y 13.18 sumado a E-F9. |
| J3 costo-beneficio | `PROCEDE` | propuesta | El beneficio se sostiene: la piloto corre la Fase I, que cambia entre 13.20 y 13.22 (085:537-538). Hay que corregir la cita: son 3 de 6 los que dicen 'Ninguno obligatorio', y 13.18 nombra a Lab-Geometria (085:527-534). El caso de 13.18 se suma a E-F9. CON REVISIÓN: sin K6 gana B. La condición de Migracion-Rules §3 acota el costo. |
| J4 coherencia histórica | `PROCEDE` | propuesta | El precedente directo es que Geometría migró a 13.16 con un expediente propio (SDD/Expedientes/0001-Migracion-Normativa-A-13.16), que 13.18 deja como forma histórica (/IA/SDD/IA.SDD/CHANGELOG.md:271-277). La cita 'la mayoría declara Ninguno obligatorio' es falsa (3 de 6) y hay que corregirla. Conviene decidir por RE §1 si la migración abre expediente (el próximo numera 0002) y sumar a E-F9 lo que dice 13.18. Queda CON REVISIÓN. |
| J5 riesgo | `PROCEDE` | propuesta | El fondo se sostiene: la piloto corre la Fase I que cambian las versiones 13.20 a 13.22. Pero «la mayoría: Ninguno obligatorio» es falso: son 3 de 6, y 13.18 nombra a Lab-Geometria (CHANGELOG:271-277, 085 §6 D24). Además, el ganador depende sólo de K6. CON REVISIÓN, con la cita corregida y 13.18 sumado a E-F9. |

#### D25

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | TP:16 sitúa los ejemplos en EXAMPLES y TP:30 dice «basado en». R-E4 (EVR/05) emite OpenAPI con 8 operaciones sin tocar LE, así que la condición (b) no se da. Corregir el fundamento: LE-IADB:85 sólo prohíbe renombrar textos y contratos. «mini» queda sin umbral (085 §8.1, K2). |
| J2 impacto | `PROCEDE` | propuesta | R-E4 resuelve E-F3 sin tocar LE: 200 y 8 operaciones (085:551-555), así que la condición (b) no se da. Impacto bajo con C-10: el fundamento exageraba LE-IADB:85. |
| J3 costo-beneficio | `PROCEDE` | propuesta | R-E4 sacó el OpenAPI en ejecución del SHA 8fb4c3a, 8 operaciones en 26 s, sin tocar LE. Eso resuelve E-F3 y quita el principal costo de A (085:551-555). Hay que reescribir el fundamento: LE-IADB:85 prohíbe renombrar, no toda modificación. También cambiar la condición (b), C-10. B sigue dependiendo de un expediente en Lab-E2E. |
| J4 coherencia histórica | `PROCEDE` | propuesta | Coherente con TP:16 y con el antecedente, cuya demo vivió en Lab-Documentos (Concepts/Framework-Concept/Demo) con su propio workflow. R-E4 resolvió E-F3 sin tocar LE (F085 D25). Hay que reescribir el fundamento: LE-IADB:85 prohíbe renombrar, no toda modificación. |
| J5 riesgo | `PROCEDE` | propuesta | TP:16 sostiene EXAMPLES, y R-E4 extrae el OpenAPI en ejecución sin tocar LE (085 EVR/05), con lo que E-F3 queda resuelto. Riesgo: el fundamento exagera LE-IADB:85, y «mini» no tiene umbral de lectura (085 §8.1 K2). Aplicar C-10 y fijar ese umbral. Margen de 0,20: CON REVISIÓN. |

#### D26

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | Sostenida por TP:61 (toda afirmación respaldada) y por R01 (no se asienta por silencio). G-a…G-g son medibles en el runner. Para E3, G-b corre en el runner de la otra organización: agregarlo al criterio (085 §6 D26, L10). |
| J2 impacto | `PROCEDE` | propuesta | G-a…G-g se pueden medir en el runner y la copia a evidencia/ cubre que las URL de Actions expiren. Para E3, G-b depende del runner de otra organización (L10; 085:567-568). |
| J3 costo-beneficio | `PROCEDE` | propuesta | G-a…G-g se miden en el runner, y copiar la salida a evidencia/ cubre que las URL de Actions expiren (085:567-568). Un expediente por repo (alt. 2) multiplica el gobierno sin beneficio. En E3, G-b debe correr en el runner de la otra organización. |
| J4 coherencia histórica | `PROCEDE` | propuesta | Repite el antecedente: compuerta con rojos provocados, 'PR en rojo y en verde en i7infra-dev' y 'un run_id real' (EXP1/035 P8 y P11; EXP1/037 A3). El corte PROCEDE/NO_PROCEDE/INSUFICIENTE, que vuelve una vez, corrige el rótulo ARCHIVA del antecedente según RM:331 (R01 H-04). Para E3, G-b corre en el runner de la otra organización. |
| J5 riesgo | `PROCEDE` | propuesta | G-a…G-g son medibles en el runner, y copiar a evidencia/ cubre que las URL de Actions expiran (085 §6 D26). Hueco: G-b de E3 corre en el runner de la otra organización (L10). Un expediente por repo dispersa el dictamen. |

#### D27

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | Sostenida por TP:67-68 (aplicar el Profile), PERFIL:35, :56-63 y :85, y R02:319 («No cumple como guía de estudio»). F8 está bien aplicado. Cambiar «description escrita por una persona» por «revisada» (C-13). |
| J2 impacto | `PROCEDE` | propuesta | PERFIL:35, :56-63 y :85 y R02:319 se verificaron, y F8 está bien aplicado (085:572-575). |
| J3 costo-beneficio | `PROCEDE` | propuesta | Agrega piezas (K1 = 3), pero las exige el Profile: F8, PERFIL:56-63 y R02:319 'No cumple' (085:572-575). No hay alternativa admitida más barata. El costo para agentes se compensa partiendo el cuerpo por núcleo (D07, E-F4). |
| J4 coherencia histórica | `PROCEDE` | propuesta | El antecedente ya partió la guía en marco con escenarios, mapa, temas, cómo hacer y anexos, con un único índice y un criterio de lector desde un clon limpio (EXP1/035 P10). D27 sigue esa forma bajo el Profile (PERFIL:35, :56-63, :85). |
| J5 riesgo | `PROCEDE` | propuesta | PERFIL:35, :56-63 y :85 dicen lo citado, y F8 está bien aplicado (085 §6 D27). La alternativa queda excluida por el Profile (TP:67-68). |

#### D28

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | Rule-Evidences.md:25 pide fecha de obtención. F016 E01: GUIA tiene 0 de 20 referencias completas y rehechas quedan 20/20. TP:61. El costo de dominios nuevos se resuelve en D18. |
| J2 impacto | `PROCEDE` | propuesta | Rule-Evidences.md:25 pide la fecha de obtención y F016 pasa de 0/20 a 20/20 (085:579-582). El costo en dominios se resuelve en D18. |
| J3 costo-beneficio | `PROCEDE` | propuesta | Pide sólo una línea más por entrada y la sostiene Rule-Evidences.md:25. El piloto pasa de 0/20 a 20/20 (080:1197-1198). El costo de los dominios nuevos se resuelve en D18 con C-14. ISO 690 o IEEE no tienen público que los pida. |
| J4 coherencia histórica | `PROCEDE` | propuesta | Rule-Evidences.md:25 pide 'Referencia y fecha de obtención'. El antecedente tenía un anexo de referencias (EXP1/035 P10, 99-Anexos). El costo en dominios nuevos se resuelve en D18. |
| J5 riesgo | `PROCEDE` | propuesta | Rule-Evidences.md:25 pide la fecha de obtención (085 §6 D28). El costo de los dominios nuevos se resuelve en D18 (C-14). Nada pide ISO 690 ni IEEE. |

#### D29

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | La ruta de TP:68 (/IA/IA.Prompts/…) no existe y PERFIL sí existe en /IA/PROMPTs/IA.Prompts/… (085 §6 D29). El default no toca el Profile y respeta PERFIL:56-63. |
| J2 impacto | `PROCEDE` | propuesta | La ruta del pedido no existe y la real sí (085:586-587). El default no toca el Profile. |
| J3 costo-beneficio | `PROCEDE` | propuesta | Un default sin tocar el Profile da costo cero y no bloquea; la ruta real del Profile se verificó (085:586-587). 'Elevar y esperar' frena E1 sin beneficio, salvo que el PO lo pida. |
| J4 coherencia histórica | `PROCEDE` | propuesta | El antecedente ya registró el mismo error en la ruta del Profile (01-Framework-Concept/OUTPUTs/Bitacoras/00-Registro.md:17; R01 H-11). La ruta real existe y el default no toca el Profile (F085 D29). |
| J5 riesgo | `PROCEDE` | propuesta | La ruta de TP:68 no existe y PERFIL sí (085 §6 D29). El default no toca el Profile ni asienta nada por silencio (R01:460). Elevar y esperar frenaría E1 sin necesidad. |


## 8. Votos verbatim de la ronda 2 (D22)

Insumos de la ronda: folios 080, 085 y 090. Texto sometido a voto: D22 del folio 080 (ver §4.2). En el motivo de J1
el nombre del servicio privado se reemplazó por «[SDD-B]», con la marca entre corchetes; es la única alteración.

| Juez | Corrida (agente, inicio → fin UTC) | Voto | Prefiere | Motivo (verbatim) | ¿Cuenta en el recuento? |
| --- | --- | --- | --- | --- | --- |
| J1 evidencia | `af46a03560963ce76`, 22:33:26 → 22:33:52 | `NO_PROCEDE` | ninguna | Jurado J1, evidencia. El texto que se somete a voto es la D22 A original (080:985-1011), y su alternativa_2 es la vieja C. La evidencia no sostiene esa versión. (1) El pedido exige «aplicarlo a [SDD-B] mejorando los agentes orquestadores de ambos» (TP:30), y la decisión 1 de la presidencia lo fija como escalón 3. En el SDD-B, la propuesta sólo carga el conocimiento en la mesa y suma K1 al CI. Ninguna de las dos cosas toca un orquestador (085:501-505). El ensayo R-A2 lo confirma: la fila del índice entra sola a la mesa por K-Mesa §3.4, sin cambiar nada (ensayos-D22.txt:11-15). (2) Los AG-xx están dormidos (R04:190-192, verificado), así que la parte de IA.SDD no compensa lo que falta en el SDD-B. (3) La propuesta da por hecho que K1 corre en un CI listo para usar. R-A4 midió 257 hallazgos con rc=1, casi todos falsos positivos (ensayos-D22.txt:23-30). En modo bloqueante, el CI queda en rojo el primer día. (4) La alternativa_2 (importar por referencia prioridad de fuentes, reincorporación y delegación) tampoco toca un orquestador. Según F014, dos de esas tres piezas ya son comunes (080:1003-1009). La que queda, prioridad de fuentes, depende de C-SDD-CONOCIMIENTO en E3, así que el pedido no la sostiene para esta corrida. La versión que sí tiene sostén en la evidencia es la D22 reformulada de 090 §4. Agrega el cambio verificable en CC §5, apoyado en el defecto medido de CC:74 frente a R04:190-192, con observables O1 a O7 y L12 como salida. Corresponde votar esa versión. X2 cerrada (F001 D5) no está en discusión. | Sí |
| J2 impacto | `aaa4990cb8eed708e`, 22:33:29 → 22:33:51 | `PROCEDE` | propuesta | Impacto: la propuesta procede solo si se lee con la reformulación de 090 §4. Sin ella cambia el resultado de E3, porque «ambos» de TP:30 queda INSUFICIENTE (085:497-513; 090:157,187). El texto despachado repite 080:989 («cargar en la mesa» + «K1 a su CI»). R-A2 (090:94) mide que la carga entra sola por el índice y no mejora ningún orquestador. Lo que levanta la objeción C-11/L12 es el cambio verificable en CC §5 del orquestador vivo (090:125-127, R-A3, observables O1-O4 en 090 §7). Se aplica como PR de norma del SDD-B con el PO en E3 (R-A6, 090:98). Condiciones del CI: el chequeo anti-inyección corre en el runner de su organización o en ubuntu-latest, nunca en i7infra-dev (R-A5, 090:97), y solo en modo aviso, porque hubo 257 hallazgos, casi todos falsos positivos (R-A4, 090:96). La alternativa_2 (C de 080:993, 3,40) suma riesgo sin validar. Además, dos de sus tres piezas ya son comunes: la delegación en IKB/CPA y la reincorporación en IA.SDD (080:1007-1009). Lo único en disputa es la prioridad de fuentes, que el propio F013 deja a C-SDD-CONOCIMIENTO en E3. Por eso la C no cambia el dictamen y sí lo encarece. X2 sigue cerrada (F001 D5). | Sí |
| J3 costo-beneficio | `af7dd9fcb5a6110fd`, 22:33:29 → 22:33:59 | `PROCEDE` | propuesta | Costo-beneficio: la parte común (conocimiento nuevo con fuente en IKB, docs-guard como insumo de cierre, Momento 2 de AG-00110 en IA.SDD) aporta mucho por poco costo y no crea fases ni subagentes que no corren (080:996-999; R04:190-192). La alternativa_2 duplica lo que ya está cubierto: la delegación ya es IKB/CPA 2.0 y la reincorporación ya es de IA.SDD (Root-Rules §14). Lo único que sigue en disputa es la prioridad de fuentes, y el propio F013 pide validarla en E3 (080:1003-1009). Sobre el texto votado tengo una condición: el tramo del SDD-B no se sostiene tal como está redactado. Por un lado, «cargar en la mesa» no aporta nada, porque eso ya pasa solo por el barrido de K-Mesa §3.4 en cuanto el índice tiene la fila (090 R-A2). Por otro, «sumar K1 a su CI» en modo bloqueante cuesta 257 hallazgos con rc=1 desde el primer día, casi todos falsos positivos (090 R-A4). Además, si corre en i7infra-dev, el job queda en cola (085:135-160). Con ese tramo, la parte de «ambos» no se cumple (085:501-513). El voto PROCEDE vale sólo para la D22 reformulada con el mismo id en 090 §4. Allí el cambio verificable va a CC §5 (+326 B, observable con grep 0→1, R-A3), el chequeo anti-inyección corre sólo en modo aviso y en el runner de la organización del SDD-B o en ubuntu-latest, y L12 elevada sirve de respaldo (090 §5 y §8). | Sí |
| J4 coherencia histórica | `a7e53cfce6abd6875`, 22:33:29 → 22:33:44 | — | — | Corrida cortada por el límite de sesión, sin salida | No |
| J4 coherencia histórica | `a25df9432a534bf3e`, 23:22:11 → 23:22:37 | `NO_PROCEDE` | ninguna | Desde la coherencia histórica, el texto que se somete a voto es D22 A tal como estaba antes de la refutación (080:985-1011). No es la versión reformulada de 090:100-147. La parte común sí es coherente con la norma y con lo que vino antes: no hay fases ni subagentes nuevos porque los AG-xx del SDD-B no corren desde el 2026-08-29 (R04:190-192); el conocimiento se suma sin tocar la norma (080:1011); X2 está cerrada (F001 D5); y la prioridad de fuentes se difiere a E3. Lo que no es coherente es la parte del SDD-B. Las cinco votaciones anteriores del jurado, junto con 085:497-513, ya dejaron asentado que «cargar en la mesa» y «sumar K1 al CI» no tocan ningún orquestador. R-A2 (090:93) confirma que la carga ocurre sola, por K-Mesa §3.4, así que no es una mejora. Además, K1 en modo bloqueante deja el CI en rojo desde el primer día: 257 hallazgos, rc=1, casi todos falsos positivos (R-A4). Votarlo así deshace lo que la mesa ya resolvió. alternativa_2 tampoco procede. F014 mostró que la delegación ya está en IKB/CPA 2.0 y que la reincorporación ya pertenece a IA.SDD (080:1003-1009). El precedente de 0041 indica que un cambio a la norma del SDD-B necesita un PR de norma con el PO, y la propuesta a CC §10 quedó sin aplicar 18 días (090 R-A6; R04 §6). Importar sin pasar por E3 contradice esa vía. Lo coherente con los antecedentes es la D22 reformulada de 090 §4 (cambio en CC §5 por PR de norma, anti-inyección en modo aviso en el runner de su propia organización), con su alt2 L12 (090 §5). | Sí |
| J5 riesgo | `aae814813e0ca5e43`, 22:33:29 → 22:33:53 | `PROCEDE` | propuesta | Procede, pero sólo si la propuesta se lee como la reformula 090 §4. El texto tal como se vota todavía dice que en el SDD-B la mejora es «cargar en la mesa y sumar K1 a su CI». Eso deja abierto el hueco que señaló 085:501-513: ningún orquestador cambia, porque los AG-xx están dormidos (R04:190-192). Además, R-A2 (090:96) mostró que la carga sale sola por K-Mesa §3.4, así que contarla como mejora sería engañoso. Si se toma ese texto literal, la compuerta E3 no puede dar PROCEDE sobre «ambos». El riesgo queda cubierto con lo que agrega 090:125-131. Primero, el cambio verificable va en CC §5 (R-A3, observable O1). Segundo, el chequeo anti-inyección (el antiguo «K1») entra en modo aviso, porque R-A4 midió 257 hallazgos, casi todos falsos positivos, que en modo bloqueante dejarían el CI en rojo desde el primer día. Tercero, corre en el runner de su propia organización, nunca en i7infra-dev (R-A5, T2). Y cuarto, la fila L12 no se asienta por silencio (090:187; R01:460). La alternativa_2 tiene más riesgo. Se apoya en un solo informe (F013 Q34, 3,40). Se solapa con piezas que ya son comunes: la delegación ya está en IKB/CPA 2.0 y la reincorporación ya es de IA.SDD (080:1003-1009). Y depende de una validación que C-SDD-CONOCIMIENTO todavía no hizo. Diferirla a E3 baja el riesgo y no pierde nada. | **No** (reemplazada por la corrida de la reanudación; ver §4.3) |
| J5 riesgo | `acc0b57a5831e4e84`, 23:22:13 → 23:22:38 | `NO_PROCEDE` | ninguna | Voto sobre el texto relayado, que es la D22 A original (080:985-1011) y no la reformulada en 090 §4. Con ese texto la decisión corre dos riesgos medidos. (1) Deja un hueco: en el SDD-B ningún orquestador cambia (085:497-513). Por R-A2 (090 §3), la carga en la mesa sale sola por el barrido de K-Mesa §3.4, así que no cuenta como mejora. Con eso E3 no puede dar PROCEDE sobre «ambos» (TP:30; 085:512-513). (2) «K1 se suma a su CI» sin modo aviso deja el CI en rojo el primer día: 257 hallazgos con rc=1, casi todos falsos positivos (BOM, bloques de código, esqueletos HTML; evidencia/A02-reconsideracion-D22/ensayos-D22.txt:24-29). Tampoco dice en qué runner corre (T2, 085:135-160). La alternativa_2 (C, importar ya) agrega un riesgo de generalización que no está validado y que el mismo F013 pide llevar a C-SDD-CONOCIMIENTO (080:1003-1009). Por eso no la prefiero. Criterio propio: la versión de 090 §4 sí cubre estos riesgos (cambio verificable en CC §5 con observables O1-O7, anti-inyección en modo aviso, runner de su organización y L12 sin asentarse por silencio, R01:460). Si esa es la versión que se vota, mi voto sería PROCEDE/propuesta. | Sí |

## 9. Excepciones a conocimientos

| Conocimiento y § | Qué dice | Qué se hace en su lugar | Impacto operativo |
| --- | --- | --- | --- |
| `Rule-Expediente` 1.0 §3.1 y §3.4 (tipo del folio en el nombre) | El folio se llama `NNN-<tipo>-<slug>.md` con un tipo del conjunto cerrado | El despacho fijó el nombre `095-acta-jurado-veredicto.md`; «acta» no es uno de los tipos. Se respeta el nombre y se declara `Tipo: informe`, como el folio 004 §8 | Ninguno sobre el contenido; un listado por tipo encuentra el folio por su cabecera |
| `Rule-Mesa` 1.0, quórum de cinco (`RM:330`) | Con menos de cinco votos no hay veredicto | D07 se asienta con 4/5 y marca de quórum incompleto, y su ratificación por J5 va al ciclo siguiente (§4.4) | D07 no bloquea ninguna unidad del escalón 1 que dependa sólo de él; si J5 votara en contra, el resultado no cambia |

## 10. Lo no verificado

| Qué | Motivo |
| --- | --- |
| Por qué el workflow volvió a correr a J5 en la reanudación, si su primera corrida ya había terminado | No hay registro del motor del workflow en el árbol; se deduce del resultado que la corrida que contó fue la segunda (§4.3) |
| Las secciones de la norma que cargó cada juez | No constan en la salida estructurada, que sólo trae `id`, `voto`, `prefiere` y `motivo` |
| Las citas dentro de cada motivo | La presidencia no las re-verificó una por una: el acta las transcribe. El muestreo de citas lo hizo el refutador (`085` §7) |

## 11. Constancia de lo creado y barrido S2

- **Creado:** este folio y `evidencia/P10/01-votos-jurado-veredicto.json` (votos de las doce corridas de juez, con
  agente, inicio y fin; redactado según §8).
- **Intermedios:** un directorio de trabajo del despacho fuera del workspace, con las extracciones y los fragmentos de
  tabla de este folio. Se borra al terminar la integración y se asienta en la resolución (folio 099, §11).
- **Barrido S2:** ver el folio 099 §11, que corre el barrido sobre este folio, la resolución y `evidencia/P10/`.

Sigue: resolución (folio 099) · presidencia
