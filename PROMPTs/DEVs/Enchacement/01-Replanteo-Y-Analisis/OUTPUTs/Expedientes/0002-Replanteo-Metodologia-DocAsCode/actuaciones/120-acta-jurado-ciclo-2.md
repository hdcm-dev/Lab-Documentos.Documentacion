---
doc_id: EXP0002-F120
doc_type: acta
title: Acta del jurado del ciclo 2 — votos verbatim y recuento sobre D22-R', D07-R, H-D22, H-5, L12' y P-2 a P-5
status: vigente
origin: agent
confidence: alta (votos transcritos sin edición desde el retorno de los cinco jueces; recuento calculado por script sobre esos votos)
owner: presidencia de la mesa de Replanteo y análisis DocAsCode (despacho P21)
last_review: 2026-10-27
audience: [PO, presidencia, refutador, bitacorista, agentes que implementen E1]
traces: [EXP0002-F100, EXP0002-F110, EXP0002-F115, EXP0002-F095, EXP0002-F099]
---

| Campo | Valor |
| --- | --- |
| Tipo | acta (jurado, `R01` §10) |
| Fecha | 2026-10-27 |
| Autor | Presidencia (despacho P21). Transcribe y cuenta; no vota |
| Objeto | Los 13 puntos del folio 110, sometidos tras la refutación del folio 115 |

# 120 — Acta del jurado, ciclo 2

## Índice

1. [Regla de recuento](#1-regla-de-recuento)
2. [Resultado](#2-resultado)
3. [Condiciones que los votos imponen](#3-condiciones-que-los-votos-imponen)
4. [Votos verbatim](#4-votos-verbatim)
5. [Lo no verificado](#5-lo-no-verificado)
6. [Observaciones](#6-observaciones)

## 1. Regla de recuento

- Un punto procede con **3 de 5** votos `PROCEDE` (quórum completo: votaron J1 a J5 en los 13 puntos).
- La variante que rige es la que **prefiere la mayoría entre los votos `PROCEDE`**.
- Si un punto no llega a 3/5, la propuesta no rige y se mantiene el estado anterior. Si la mayoría de los cinco
  prefiere la `alternativa_2`, esa preferencia se registra como el camino que se toma (es el estado anterior más la
  condición que la alternativa agrega).
- Las condiciones que un voto pone para su `PROCEDE` («procede sólo con C2-n») se aplican si las piden la mayoría de
  los votos `PROCEDE` de ese punto.

Jueces (`095:51-55`): J1 evidencia, J2 impacto, J3 costo-beneficio, J4 coherencia histórica, J5 riesgo.

## 2. Resultado

| Punto | PROCEDE | Rige | Condiciones aplicadas | Resultado |
| --- | --- | --- | --- | --- |
| D22-R' | 5/5 | propuesta (5) | C2-1, C2-2, C2-4 (5/5 las piden) | **PROCEDE** |
| D07-R | 5/5 | propuesta (5) | — | **PROCEDE**: D07 ratificada con quórum completo |
| H-D22 | 5/5 | propuesta (5) | — | **PROCEDE**: los tres `NO_PROCEDE` de D22 no se trasladan |
| H-5 D08 | 2/5 | — (los cinco prefieren `alternativa_2`) | C2-5 | **NO_PROCEDE** la propuesta: D08 **no** pasa a FIRME; sigue CON REVISIÓN con la condición de C2-5 |
| H-5 D23 | 5/5 | propuesta (5) | — | **PROCEDE** |
| H-5 D24 | 5/5 | propuesta (5) | — | **PROCEDE** |
| H-5 D25 | 5/5 | propuesta (5) | — | **PROCEDE** |
| H-5 D17 | 5/5 | propuesta (5) | — | **PROCEDE** (disidencia de J4 registrada) |
| L12' | 4/5 | propuesta (4) | C2-6 (pedida por los 5, incluido el `NO_PROCEDE` de J5) | **PROCEDE con C2-6** |
| P-2 | 5/5 | propuesta (5) | — | **PROCEDE** |
| P-3 | 5/5 | propuesta (5) | — | **PROCEDE** |
| P-4 | 5/5 | propuesta (5) | — | **PROCEDE** |
| P-5 | 5/5 | propuesta (5) | C2-7 (5/5) | **PROCEDE con C2-7** |

Total: 12 `PROCEDE` y 1 `NO_PROCEDE` (H-5 D08). Votos unánimes: 11 de 13. Divididos: D08 (2–3) y L12' (4–1).

## 3. Condiciones que los votos imponen

| Condición (`115` §3) | Sobre | Quiénes la piden | Cómo queda |
| --- | --- | --- | --- |
| C2-1 | D22-R' | J1, J2, J3, J4, J5 | `KLD` = **registro y destilación de lecciones de decisión** que **cita** la escalera vigente (`Rule-Detencion-Y-Lote` §3.2, §3.5, §3.7, §3.8; `Rule-Mesa` §3.6; `Knowledge-Cadena-De-Consecuencias`) sin redefinirla. Entre las dos formas que ofrece C2-1, los votos piden reducir la capa A al registro (J3: «la capa A se reduce al registro de lecciones»); ningún voto elige el cambio MINOR de una regla. Rige el **documento propio reducido** |
| C2-2 | D22-R' | J5 explícito; J1–J4 por «no redefinir» | El criterio de irreductibilidad es la remisión a las listas cerradas de `Rule-Detencion-Y-Lote` §3.2 y §3.7 más la lista H de D08 |
| C2-4 | D22-R' | J1, J2, J5 explícitos | En el SDD-B, «ambos» queda `PENDIENTE` hasta que rija la capa B o se observe O-A4 |
| C2-5 | D08 | J1, J2, J3, J4, J5 | CON REVISIÓN; pasa a FIRME cuando el PO asiente por escrito la delegación de L2 con techo e intervalo, o al vencer el plazo que fija la presidencia (folio 129 §3) sin objeción |
| C2-6 | L12' | J1, J2, J3, J4, J5 | «sin `INSUFICIENTE`» se reemplaza por «`PENDIENTE` con evento de cierre» e ítem diferido |
| C2-7 | P-5 | J1, J2, J3, J4, J5 | Los umbrales se rotulan **[criterio propio] provisional** hasta el rol formal de K2 |
| C2-3 | §9 del 110 | — (ningún voto la trata) | La aplica la presidencia como corrección de forma en el folio 129 §6 (la tabla de lecciones trae «Evidencia» y «Resultado») |

## 4. Votos verbatim

### D22-R'

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | La estructura de dos capas se sostiene (115:42), pero con C2-1/C2-4: la escalera ya está en la norma (Rule-Detencion-Y-Lote §3.2/3.5/3.8; Cadena-De-Consecuencias:75-90, según 115:62-70). KLD debe citarla y no redefinirla, y en el SDD-B queda PENDIENTE sin la capa B (115:129). La alternativa no resuelve P-1. |
| J2 impacto | `PROCEDE` | propuesta | Impacto: la capa A deja mejora sin aprobación de norma y K-OBJ alto (110 §3, §4.2), algo que D22-R no da (K-OBJ bajo, 110:164). Va con C2-1 y C2-4 de 115: KLD cita Detencion-Y-Lote/Rule-Mesa sin redefinir la escalera, y en el SDD-B queda PENDIENTE hasta O-A4. |
| J3 costo-beneficio | `PROCEDE` | propuesta | Costo-beneficio: la capa A es clase P, barata y reversible, y resuelve P-1 (F110:90, :222). La alternativa_2 tiene K-OBJ bajo (F110:163-164). Condición de menor costo: la capa A se reduce al registro de lecciones y cita la escalera vigente en Rule-Detencion-Y-Lote §3.2/§3.5/§3.8 en vez de duplicarla (F115 R-1, R-2). Así baja el mantenimiento y no deja una excepción sin declarar. |
| J4 coherencia histórica | `PROCEDE` | propuesta | Por coherencia histórica procede la estructura en dos capas (P que garantiza, H que se consulta), pero sólo con C2-1. La escalera N1/N2/N3 ya es norma escrita (Rule-Detencion-Y-Lote §3.2, §3.5, §3.8; Rule-Mesa §3.6; 115:42 R-1). KLD debe citarla, no redefinirla. Lo único nuevo que aporta es el registro de lecciones. La alternativa_2 no resuelve P-1 (110 §4). |
| J5 riesgo | `PROCEDE` | propuesta | Riesgo: las dos capas quitan el bloqueo de P-1 (F110 §4.1, F099:53-54) sin asentar norma por silencio. Condiciones: C2-1/C2-2, porque KLD no debe redefinir la escalera que ya está en Rule-Detencion-Y-Lote §3.2/§3.7/§3.8 (F115 R-1; si no, sería una excepción no declarada); y C2-4, porque en el SDD-B la capa A es carga hasta que rija B (F115 R-4). La alternativa_2 deja «ambos» INSUFICIENTE (F110 §4.3). |

Recuento: 5/5 PROCEDE · preferencia entre los PROCEDE: {'propuesta': 5} · preferencia de los cinco: {'propuesta': 5}

### D07-R

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | 4/5 es una mayoría invariante (F099 §5.2); el refutador lo sostiene sin hallar motivo de fondo (115:43). |
| J2 impacto | `PROCEDE` | propuesta | La mayoría invariante 4/5 hace que reabrir no cambie nada (110:174-176). 115:43 SOSTIENE. |
| J3 costo-beneficio | `PROCEDE` | propuesta | Con 4/5 el resultado ya no cambia (F110:174-176; F115 sostiene). Revotar cuesta un ciclo y no aporta nada. |
| J4 coherencia histórica | `PROCEDE` | propuesta | Con 4/5 la mayoría ya es invariante (F099 §5.2; 115:43 SOSTIENE). No hay motivo de fondo para reabrirla. |
| J5 riesgo | `PROCEDE` | propuesta | 4 de 5 es una mayoría que no puede cambiar (F099 §5.2). Riesgo nulo; el refutador sostiene (F115 §1). |

Recuento: 5/5 PROCEDE · preferencia entre los PROCEDE: {'propuesta': 5} · preferencia de los cinco: {'propuesta': 5}

### H-D22

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | Un voto sobre un texto archivado no se traslada (F095 §4.2; 115:44). |
| J2 impacto | `PROCEDE` | propuesta | Un voto sobre el texto archivado no se traslada (F095 §4.2, 115:44). La alternativa cuesta más y la prueba ya la cubre O-A4. |
| J3 costo-beneficio | `PROCEDE` | propuesta | Un voto sobre texto archivado no se traslada (F115 cita F095 §4.2). Contestar cada NO_PROCEDE agrega costo sin beneficio, porque D22-R' ya se vota aparte. |
| J4 coherencia histórica | `PROCEDE` | propuesta | Un voto emitido sobre texto archivado no se traslada a otro texto (F095 §4.2; 115:44). |
| J5 riesgo | `PROCEDE` | propuesta | Los votos se emitieron sobre el texto archivado de F080 y no se trasladan a otro texto (F095 §4.2). La alternativa_2 no baja el riesgo, porque R-4 ya prueba el argumento (F115 R-4). |

Recuento: 5/5 PROCEDE · preferencia entre los PROCEDE: {'propuesta': 5} · preferencia de los cinco: {'propuesta': 5}

### H-5 D08

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `NO_PROCEDE` | alternativa_2 | L2 es una lectura de la presidencia, no un asiento escrito con techo e intervalo (F099:323; F100 §6; 115:104-109, R-5). Debe seguir CON REVISIÓN según C2-5. |
| J2 impacto | `PROCEDE` | alternativa_2 | R-5 (115:45): L2 con P es lectura de la presidencia, revisable por el PO (F100 §6), no aprobación escrita. Seguir CON REVISIÓN con la condición de C2-5 no frena nada, porque la escalera rige igual. |
| J3 costo-beneficio | `PROCEDE` | alternativa_2 | L2 aceptada con P es una lectura de la presidencia que el PO puede revisar, no una aprobación escrita (F115 R-5, F100 §6). Mantener CON REVISIÓN no cuesta casi nada y evita pasar a FIRME sobre un hecho incompleto. La escalera para los P se puede sumar igual. |
| J4 coherencia histórica | `NO_PROCEDE` | alternativa_2 | L2 con P se asentó por lectura de la presidencia y el PO puede revisarla (F100 §6). No es una aprobación escrita, así que la condición no se cumplió del todo (115:45 R-5). Queda CON REVISIÓN según C2-5. |
| J5 riesgo | `NO_PROCEDE` | alternativa_2 | Pasar a FIRME por una lectura de la presidencia adelanta la confirmación del PO. F100 §6 la declara revisable y L2 exige asentar la delegación con techo e intervalo (F099:323; F115 R-5). Mantener CON REVISIÓN con la condición C2-5. |

Recuento: 2/5 PROCEDE · preferencia entre los PROCEDE: {'alternativa_2': 2} · preferencia de los cinco: {'alternativa_2': 5}

### H-5 D23

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | La condición de F099:118 sigue intacta (115:46); la alternativa contradice L4. |
| J2 impacto | `PROCEDE` | propuesta | Se mantiene la condición de F099:118, y la alternativa contradice L4 (110 §6.2). 115 SOSTIENE. |
| J3 costo-beneficio | `PROCEDE` | propuesta | La condición de F099:118 sigue intacta (F115). Retirar ya la propuesta RDOC contradice L4 y obligaría a rehacer trabajo. |
| J4 coherencia histórica | `PROCEDE` | propuesta | La condición de F099:118 sigue intacta y la fragilidad de 2 celdas persiste (115:46). La alternativa_2 contradice L4. |
| J5 riesgo | `PROCEDE` | propuesta | L3/L4 quitan el riesgo de objeto, pero la fragilidad de 2 celdas sigue y la condición de F099:118 se mantiene. La alternativa contradice L4 (F110 §6.2). |

Recuento: 5/5 PROCEDE · preferencia entre los PROCEDE: {'propuesta': 5} · preferencia de los cinco: {'propuesta': 5}

### H-5 D24

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | Corrige la premisa falsa («3 de 6») señalada en F085:225 (110:206; 115:47). |
| J2 impacto | `PROCEDE` | propuesta | Corrige la premisa falsa (3 de 6) que marcó F085:225 sin cambiar el resultado. 115 SOSTIENE. |
| J3 costo-beneficio | `PROCEDE` | propuesta | Corrige la premisa falsa «3 de 6» (F085:225) con un costo mínimo. La alternativa_2 abre un expediente antes de que haga falta. |
| J4 coherencia histórica | `PROCEDE` | propuesta | Corrige la premisa falsa que F085:225 había señalado (son 3 de 6) sin cambiar el ganador (115:47; 110:206). |
| J5 riesgo | `PROCEDE` | propuesta | Corrige la premisa falsa («3 de 6», F085:225) y sigue CON REVISIÓN. Desacoplar ahora agrega riesgo de heterogeneidad (F110 §6.2). |

Recuento: 5/5 PROCEDE · preferencia entre los PROCEDE: {'propuesta': 5} · preferencia de los cinco: {'propuesta': 5}

### H-5 D25

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | La condición (a) de F099:119 se activa sólo cuando el expediente exista (115:48). |
| J2 impacto | `PROCEDE` | propuesta | Aplica la condición (a) que la decisión misma fijó en F099:119, sólo cuando exista el expediente. Quedarse en A la ignora (110 §6.2). |
| J3 costo-beneficio | `PROCEDE` | propuesta | La condición (a) sólo se activa cuando exista el expediente (F099:119). El tope de mini (≤ 20 piezas, 1 workflow, < 15 min) acota el costo. |
| J4 coherencia histórica | `PROCEDE` | propuesta | La condición (a) de F099:119 se activa sólo cuando el expediente exista. Hasta entonces sigue A con source.lock (115:48). |
| J5 riesgo | `PROCEDE` | propuesta | Activa la condición (a) de F099:119 sólo cuando el expediente exista; mientras tanto, A con source.lock. Pasar a B queda atado a un hecho (F115 §1). |

Recuento: 5/5 PROCEDE · preferencia entre los PROCEDE: {'propuesta': 5} · preferencia de los cinco: {'propuesta': 5}

### H-5 D17

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | E-F12 decide (F099:150-155; 115:49) y la disidencia de J4 queda registrada. |
| J2 impacto | `PROCEDE` | propuesta | Decide E-F12 en E1-U0b (F099:150-155), un ensayo barato. La disidencia de J4 queda registrada. |
| J3 costo-beneficio | `PROCEDE` | propuesta | E-F12 decide con un único ensayo barato (F099:150-155). Arrancar con un workflow por repo crearía duplicación que después habría que migrar. |
| J4 coherencia histórica | `PROCEDE` | propuesta | Es coherente con F099:150-155: E-F12 decide. Mi disidencia (J4) queda registrada (110:208; 115:49). |
| J5 riesgo | `PROCEDE` | propuesta | E-F12 es la primera unidad de E1-U0b y su resultado decide (F099:150-155). Se queda CON REVISIÓN y la disidencia de J4 queda registrada, así que el riesgo está acotado por un ensayo temprano. |

Recuento: 5/5 PROCEDE · preferencia entre los PROCEDE: {'propuesta': 5} · preferencia de los cinco: {'propuesta': 5}

### L12'

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | Procede con C2-6: «sin INSUFICIENTE» debe pasar a PENDIENTE con evento de cierre, porque O-A3/O-A4 son observables futuros (115:113-115, R-6). La alternativa depende de D22-R, que pierde. |
| J2 impacto | `PROCEDE` | propuesta | Saca el silencio del PO del camino crítico (110 §7). Se aplica C2-6 de 115: 'PENDIENTE con evento de cierre' en lugar de 'sin INSUFICIENTE' (R-6, 115:50), porque un observable futuro no es verde. |
| J3 costo-beneficio | `PROCEDE` | propuesta | Con la capa A, el silencio del PO no bloquea (F110:222). Corrección necesaria: O-A3/O-A4 dependen de un expediente posterior (F115 R-6). Si ese expediente no existe al cierre de E3, se declara pendiente con fecha en lugar de «sin INSUFICIENTE». |
| J4 coherencia histórica | `PROCEDE` | propuesta | Procede sólo con C2-6. «Sin INSUFICIENTE» debe pasar a PENDIENTE con evento de cierre, porque O-A3 y O-A4 dependen de un expediente posterior (115 R-6). Esa misma línea ya se siguió en el registro de diferidos (§12.3). |
| J5 riesgo | `NO_PROCEDE` | ninguna | Tal como está redactada, «sin INSUFICIENTE» da por verde O-A3/O-A4, que se miden después del cierre de E3. Eso es un falso cumplimiento (F115 R-6). Procede sólo con C2-6: PENDIENTE con evento de cierre y como ítem diferido. La alternativa_2 depende de que gane D22-R. |

Recuento: 4/5 PROCEDE · preferencia entre los PROCEDE: {'propuesta': 4} · preferencia de los cinco: {'propuesta': 4, 'ninguna': 1}

### P-2

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | Es lo reversible y no rompe citas (110:232-238; 115:51). |
| J2 impacto | `PROCEDE` | propuesta | Es lo reversible y evita romper citas en 10 archivos (C10:53, 110 §8.1). |
| J3 costo-beneficio | `PROCEDE` | propuesta | Renombrar toca 10 archivos y rompe citas. Declarar la convención en el README es la opción más barata y reversible. |
| J4 coherencia histórica | `PROCEDE` | propuesta | No renombrar es lo reversible y no rompe citas ya asentadas (110:230-238; 115 SOSTIENE). |
| J5 riesgo | `PROCEDE` | propuesta | Es lo reversible: renombrar toca 10 archivos y rompe citas (C10:53). |

Recuento: 5/5 PROCEDE · preferencia entre los PROCEDE: {'propuesta': 5} · preferencia de los cinco: {'propuesta': 5}

### P-3

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | La corrigenda evita editar folios firmados (115:52). |
| J2 impacto | `PROCEDE` | propuesta | Una corrigenda no altera folios firmados que otros citan por sección (110 §8.2). |
| J3 costo-beneficio | `PROCEDE` | propuesta | Una corrigenda por referencia no reabre folios firmados y cuesta menos que una fila de control de cambios en cada uno. |
| J4 coherencia histórica | `PROCEDE` | propuesta | Los folios firmados no se editan; una corrigenda preserva la historia (110:242-245). |
| J5 riesgo | `PROCEDE` | propuesta | La corrigenda no altera folios firmados que se citan por sección (F110 §8.2); el riesgo es menor. |

Recuento: 5/5 PROCEDE · preferencia entre los PROCEDE: {'propuesta': 5} · preferencia de los cinco: {'propuesta': 5}

### P-4

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | wc -l TP = 67, verificado (110:252-253; 115:53); TP es del PO. |
| J2 impacto | `PROCEDE` | propuesta | wc -l TP = 67, verificado (115:48). La alternativa escribe en un archivo del PO. |
| J3 costo-beneficio | `PROCEDE` | propuesta | wc -l de TP da 67, verificado (F115). La corrección es de una línea y TP es del PO, así que no se toca. |
| J4 coherencia histórica | `PROCEDE` | propuesta | wc -l TP da 67 (verificado en 110:252-253) y TP es del PO, así que no se toca. |
| J5 riesgo | `PROCEDE` | propuesta | wc -l TP da 67, verificado (F115 §1). TP es del PO y no se escribe, así que la alternativa queda descartada. |

Recuento: 5/5 PROCEDE · preferencia entre los PROCEDE: {'propuesta': 5} · preferencia de los cinco: {'propuesta': 5}

### P-5

| Juez | Voto | Prefiere | Motivo (verbatim) |
| --- | --- | --- | --- |
| J1 evidencia | `PROCEDE` | propuesta | Procede sólo con C2-7: los umbrales no tienen fuente y deben rotularse como [criterio propio] provisional (115:117-119, R-7). |
| J2 impacto | `PROCEDE` | propuesta | Sin umbral, la compuerta E1 no cierra (110 §8.4). Se aplica C2-7: rotular los umbrales como [criterio propio] provisional hasta K2 (R-7, 115:52). |
| J3 costo-beneficio | `PROCEDE` | propuesta | Un umbral provisional evita un INSUFICIENTE seguro en E1, que costaría más. Condición: rotular los números como criterio propio de la mesa, sin fuente, revisable por K2 (F115 R-7). |
| J4 coherencia histórica | `PROCEDE` | propuesta | Procede sólo con C2-7. Los umbrales no tienen fuente (115 R-7), así que se rotulan como [criterio propio] provisional hasta el rol formal de K2. |
| J5 riesgo | `PROCEDE` | propuesta | Los umbrales provisionales evitan una compuerta E1 que no puede cerrarse. Condición C2-7: rotularlos [criterio propio] porque no tienen fuente (F115 R-7). |

Recuento: 5/5 PROCEDE · preferencia entre los PROCEDE: {'propuesta': 5} · preferencia de los cinco: {'propuesta': 5}

## 5. Lo no verificado

| Qué | Motivo |
| --- | --- |
| La identidad de cada juez con su bloque de votos | Se asume el orden J1…J5 del despacho; lo confirman las marcas propias (J3 «Costo-beneficio», J4 «Mi disidencia (J4)», J5 «Riesgo») |
| Las citas de línea que los jueces dan a `115` | Algunas difieren entre jueces para el mismo punto (p. ej. `115:48` para P-4 en J2 y para D25 en J1); no cambian ningún resultado |

## 6. Observaciones

- O-1: el `NO_PROCEDE` de J5 en L12' no se opone a la propuesta sino a su redacción; pide la misma C2-6 que los
  otros cuatro. La presidencia lo registra como disenso de forma.
- O-2: en H-5 D08, J2 y J3 votan `PROCEDE` pero prefieren la `alternativa_2`: los cinco coinciden en el camino
  (CON REVISIÓN con C2-5). El 2–3 es sobre el rótulo del voto, no sobre la dirección.
- O-3: sin commits, PR ni contenedores. Archivo creado: este folio.

Sigue: resolución del ciclo 2 (folio 129) · presidencia
