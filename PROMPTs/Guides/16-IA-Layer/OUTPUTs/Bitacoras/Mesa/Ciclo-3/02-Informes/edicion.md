---
doc_id: BIT-16-MESA-C3-02-EDICION
doc_type: informe-de-especialista
title: Ciclo 3 · Informe de Edición de material bibliográfico
version: v1
status: entregado a la presidencia
origin: agent (especialista de edición, pedido del PO)
last_review: 2026-10-26
traces: [BIT-16-04 v2, BIT-16-04 v1, BIT-16-03 §2, Mesa/Ciclo-2/02-Informes/edicion.md, Mesa/Ciclo-2/05-Parches.md, Mesa/Ciclo-2/06-Aprobacion.md, Mesa/Ciclo-2/08-Cierre.md, Mesa/Ciclo-2/09-Respuestas-De-La-Presidencia.md, M§3]
---

# Ciclo 3 · Edición de material bibliográfico

**Objeto**: `../../../04-Plan-De-Integracion.md` (v2, ESTRUCTURA APROBADA v2, 1236 líneas). Las líneas («l.») son de la v2 al 2026-10-26. Leí el cierre y las respuestas de la presidencia del ciclo 2, la aprobación (objeciones en minoría), los parches PAR2-15…PAR2-19 y mi informe del ciclo 2 (ED2-01…ED2-07), para no repetir lo que ya se corrigió. No leí los informes de este ciclo.

**Mandato**: RV-04 (presupuesto de palabras, regla de conteo, compensación), coherencia terminológica final, residuos de los parches (§B.4, IDs, anclas) y el par CTX-NUEVA / CTX-EXISTENTE en el vocabulario.

Las mediciones se hicieron con GNU `grep`, `wc`, `tr` y `cut` sobre la v2 y la v1. Se pueden reproducir con los comandos que cito.

## Índice

- [1. Hallazgos](#1-hallazgos)
- [2. Posiciones sobre la agenda](#2-posiciones-sobre-la-agenda)
- [3. Revisado y bien](#3-revisado-y-bien)

## 1. Hallazgos

### ED3-01 · La compensación de palabras no cuadra con sus propios sumandos, y el saldo no cae en la Parte V — S2 · E2 + E3 · confianza 0.85

- **Ubicación**: §C, párrafo «Compensación de los parches de este ciclo» (l. 372). Fuentes de los costos: `Mesa/Ciclo-2/05-Parches.md` l. 301, 394, 538, 571, 601, 637, 693 y 717.
- **Afirmación**: J3 tiene razón: el saldo es ~+625 y no ~+220. Hay además tres errores que J3 no nombró. (1) La suma interna del párrafo está mal. Los seis sumandos que lista dan 40 + 250 + 80 + 110 + 130 + 150 = **760**, no 640, y los tres que resta dan 170 + 90 + 25 = **285**, no 420. (2) El −25 de PAR2-15 aparece dos veces: una entre los que suman («PAR2-15 −25 con la opción b») y otra entre los que restan («PAR2-15 lectores, ~−25»). Además lo atribuye a la opción b de RV-05, y en el parche ese −25 sale del párrafo de lectores, que no depende de la opción. Faltan PAR2-17 (+120) y la fila nueva de PAR2-15 (+30). (3) La frase «se toma del margen del 15 % de la Parte V (§10–§12), donde cae la mayor parte» es falsa. Repartí cada costo declarado entre las Partes que nombra el parche, en partes iguales cuando el parche nombra varias secciones (E3). El resultado: Parte 0 ≈ +125 (PAR2-17, PAR2-15), Anexos ≈ +150 (glosario, PAR2-19), IV ≈ +117, V ≈ +86, II ≈ +83, III ≈ +68, VI y Cierre ≈ +26 cada una, I ≈ −13. La Parte V se lleva ~14 % del saldo, y la Parte 0 y los Anexos, ~44 %.
- **Evidencia**: l. 372, citado: «suman ~+640 … (PAR2-06 +40, PAR2-09 +250, PAR2-14 +80, PAR2-16 +110, PAR2-18 +130, PAR2-19 +150; PAR2-15 −25 con la opción b de RV-05) y sacan ~−420 (… ~−170; … ~−90; PAR2-15 lectores, ~−25 …)». En los parches: PAR2-17 «la Parte 0 suma ~120 palabras» (l. 637) y PAR2-15 «una fila nueva (~30 palabras en la Parte 0) … el párrafo de lectores baja de ~120 a ~95» (l. 571). Saldo: 910 − 285 = 625.
- **Impacto si no se corrige**: RV-04 se vota sobre un número que no existe. El saldo se carga a la Parte que menos lo recibe. Y el 15 %, que es el disparador de la relectura S-14, se usa como presupuesto: el control deja de controlar. La Parte 0 es la que más pasa su tope (ED3-02), y el párrafo ni la nombra.
- **Propuesta de dirección**: reemplazar el párrafo por una tabla «parche → Parte → +/− palabras» con saldo por Parte. Cada saldo positivo se resuelve explícitamente en la papeleta de RV-04: sube el tope de esa Parte o se recorta algo nombrado. El margen del 15 % no se toca.

### ED3-02 · La regla de conteo no dice qué hacer con la sintaxis de Markdown, y el 551 de la papeleta se midió con otra regla — S2 · E1 · confianza 0.85

- **Ubicación**: §C, regla de conteo y papeleta de RV-04 (l. 370); tabla de OA de §A.3 (l. 103–128).
- **Afirmación**: la regla manda contar con `wc -w` «después de quitar los bloques de código, … las anclas y las filas separadoras». No dice nada de los separadores de celda `|` ni de otros tokens sin letras («·», «—», «→», «/»), y `wc -w` cuenta cada uno como una palabra. El «551» de la papeleta lo medí yo en el ciclo 2 con `tr '|' ' '`, que es otra regla, y sobre la v1, que tenía 25 filas. Medido hoy sobre la v2 (26 filas, con OA-A5): 766 con la regla escrita, 610 sin `|` y 462 sólo en la columna de prosa. Hay 163 tokens sin ningún carácter alfanumérico. La diferencia entre dos lecturas de la misma regla es de 25,6 %, más que el umbral del 15 % de S-14.
- **Evidencia (E1)**: `grep '^| OA' 04-Plan-De-Integracion.md | wc -w` → 766. `… | tr '|' ' ' | wc -w` → 610. Sobre la v1 → 701 y 551. `… | tr ' ' '\n' | grep -vc '[[:alnum:]]'` → 163.
- **Impacto si no se corrige**: la Parte 0, que se estimó en ~1.480 con el método de `tr`, da ~1.700 con la regla escrita (+215 de la tabla de OA), antes de sumar los +125 de este ciclo. Las dos opciones de RV-04 se votan sobre una medida que `tools/contar.sh` no va a reproducir. Las Partes con muchas tablas (§13 con 13 ADR, §15, Anexos) quedan sobrecontadas frente a las de prosa.
- **Propuesta de dirección**: la regla cuenta como palabra sólo el token que tiene al menos una letra o un dígito (`tr -s '[:space:]' '\n' | grep -c '[[:alnum:]]'`). Se escribe así en §C y en `tools/contar.sh`. La cifra de la papeleta (tabla de OA y Parte 0) se vuelve a medir con ese script antes del voto.

### ED3-03 · La compuerta de familias de ID marca como fallo los OA de seguridad, que sí llegan al lector — S2 · E1 · confianza 0.9

- **Ubicación**: §C, «Familias de ID» (l. 368); tabla de OA, filas OA-S1…OA-S4 (l. 124–127).
- **Afirmación**: la compuerta `grep -nE "\b(H2?|PAR2?|AJ|DEP|SUP|R|P|PR|S|Q|T|TURNO|EMB)-?[0-9A-C]+\b"` tiene que dar 0 sobre la guía. Como el guion es opcional y `\b` corta después de «OA-», la alternativa `S` captura el «S2» de **OA-S2**. Esa familia es una de las que «llegan al lector». Tampoco exige guion en las familias de una letra, así que con [A-C] también salta en siglas comunes del texto técnico: «QA», «PC», «TB». Hay cuatro OA (OA-S1…S4) con varias apariciones cada uno, y §8, §11 y §15 los citan. La compuerta va a fallar siempre, o se va a llenar de excepciones.
- **Evidencia (E1)**: `printf 'OA-S2 decide\nel equipo de QA\nuna PC con 2 TB\nOA-SK1\n' | grep -nE "<regex de l. 368>"` marca las líneas 1, 2 y 3 (OA-SK1 no). Sobre la v2, el regex da 11 aciertos «S2» y 8 «S3», que vienen sobre todo de OA-S2 y OA-S3.
- **Impacto si no se corrige**: el falso positivo es estructural. O se lista como excepción cada mención de un OA de seguridad, y la lista crece con la guía, o se apaga la compuerta, y entonces pasan a la guía los H2-, DEP- y PAR2- que la compuerta tenía que frenar.
- **Propuesta de dirección**: guion obligatorio para toda familia de una letra (R-, P-, S-, Q-). T1–T7 va con su propio patrón `\bT[1-7]\b`. Prefijo que excluya lo que viene después de un guion, `(^|[^-[:alnum:]])`, en lugar de `\b`. Y un caso de prueba de la compuerta, con positivos y negativos (OA-S2, QA, PC deben pasar; H2-050, DEP-14, PAR2-18 y TURNO-1 deben fallar), igual que el que tiene AC-8 en `Compuertas/rd-po-4.positivos`.

### ED3-04 · «Contexto» tiene tres sentidos, el glosario registra uno solo, y el par CTX-NUEVA / CTX-EXISTENTE agrava el choque — S2 · E2 · confianza 0.8

- **Ubicación**: BIT-16-03 §2 («Un contexto es una variante que cambia la respuesta correcta», l. 44); §C §2.2 «Contextos» (l. 396–403); §C §3.0 («modelo, prompt, **contexto**, herramienta…», l. 408); escalera de conocimiento («contexto fijo», «contexto completo con prefijo estable», l. 236–282); «contexto no confiable» y «contexto recuperado» (§A.4, Anexo B, l. 879); «Query/**Context**/Answer» (l. 363); «subsecciones de **contexto**» del criterio de inclusión (l. 132); Anexo C (l. 534: una sola entrada, «*contexto*»).
- **Afirmación**: el plan usa «contexto» en tres sentidos. (1) La variante del marco N0 (CTX-LOCAL…CTX-SENS), una propiedad del **uso**. (2) Lo que entra en la ventana del modelo, una propiedad de la **llamada**: hay 14 «contexto completo», 8 «contexto fijo», 5 «contexto no…» y 4 «contexto recuperado». (3) El encuadre de una subsección sin conducta evaluable. El Anexo C, que es la fuente de C5 («un término, un sentido»), tiene una sola entrada sin acepciones. El par que propone la presidencia suma una acepción (1) con un nombre que se lee como (2): «estoy en contexto de aplicación existente» y «el contexto que le paso al modelo» van a convivir en §2, §3.3 y §14. Nadie lo planteó en los ciclos 1 y 2: un `grep` de «contexto» junto a «sentido», «colisión» o «ambig» en `Mesa/` no da nada pertinente.
- **Evidencia (E2)**: las líneas citadas. El conteo: `grep -o -i 'contexto[s]\? [a-zñ]*' 04-Plan-De-Integracion.md | sort | uniq -c`. ED2-02 resolvió la misma clase de defecto con «nivel», y C5 es REED-16 §9.1.
- **Impacto si no se corrige**: C5 no pasa en el término más usado de la guía. El lector de §2.2 aprende «contexto = variante» y en §3.0, dos páginas después, «contexto = lo que ve el modelo». La tabla «ESC-xx × CTX-yy» de §3.3 se puede leer como «qué contexto le paso al modelo en cada escenario».
- **Propuesta de dirección**: en la guía, el sentido (1) se escribe siempre «contexto de uso» o con su ID CTX-, el sentido (2) es «contexto» a secas (el canónico de §3.0) y el sentido (3) pasa a «subsecciones de encuadre». El Anexo C registra «contexto de uso» como entrada propia, con remisión a §2.2. La verificación de C5 busca «contexto» en §2 y en las tablas ESC × CTX. Se aplica en el mismo parche que suma CTX-NUEVA / CTX-EXISTENTE.

### ED3-05 · El residuo de §B.4 ya está en §8: el agrupador «Escalón 3» contiene un ejemplo del escalón 1, y la casa única lo va a copiar a la guía — S3 · E2 · confianza 0.85

- **Ubicación**: §B.4, fila «Agente por código» (l. 291, columna Escalón = «3»); §C §8, agrupadores (l. 459: «**Escalón 3** — §8.7 Agentes de MAF … 11 usa un agente en el escalón 1»); §C §9.3 («casa única del cuadro de §B.4», l. 468); §B.3 (l. 282: «11 usa un `AIAgent` y sigue en el 1 con estado: el artefacto no define el escalón»).
- **Afirmación**: el cierre registra el residuo de §B.4 como deuda (PAR2-16, verificación 3 con observación), pero no nombra dos efectos. (a) En §8, §8.7 vive bajo el agrupador «Escalón 3», y su único ejemplo ejecutado (11) es del escalón 1. El encabezado que ve el lector en la tabla de contenido contradice la frase de §B.3 que el ciclo 2 escribió para cerrar esto. (b) §9.3 es la casa única del cuadro de §B.4. Si se copia como está, la guía publica «Agente por código | 3 | Conviene si hace falta estado de conversación», que es justo lo que la verificación (3) de PAR2-16 prohíbe: «ninguna fila ubica a un artefacto en el escalón 3 sólo por conservar estado».
- **Evidencia (E2)**: l. 291, l. 459, l. 468 y l. 282, citadas. PAR2-16, verificación (3): `Mesa/Ciclo-2/05-Parches.md`, después de l. 601.
- **Impacto si no se corrige**: el error se publica en dos lugares visibles (tabla de contenido y cuadro de §9.3), y el lector aprende «agente = escalón 3», el error conceptual que la escalera de agencia existe para corregir.
- **Propuesta de dirección**: la fila de §B.4 lleva «1–3 (el artefacto no fija el escalón: §B.3)», y en «Cuándo conviene» se cambia «Conviene si hace falta estado de conversación» por «Conviene si hace falta estado de conversación (que no sube el escalón)». En §8, el agrupador de §8.7 pasa a «**El artefacto agente y el escalón 3**». La verificación: `grep -n "Agente por código" … | grep "| 3 |"` = 0 y `grep -n "\*\*Escalón 3\*\* — §8.7"` = 0.

### ED3-06 · Residuos de numeración y de cifras que dejaron los parches del ciclo 2 — S3 · E2 · confianza 0.85

- **Ubicación**: l. 366, l. 370, l. 374–541, l. 998, l. 790 y l. 515–518.
- **Afirmación**:
  - (a) **Lista de líneas de la v1 dentro de la v2**: «entre ellas l. 120, 356, 366, 372, 395–396, 457, 521» (l. 366) son líneas de la v1. En la v2 apuntan a la fila OA-O1, al encabezado de una tabla, a la propia regla, al párrafo de compensación, a una línea vacía y al título de §2.
  - (b) **La regla del prefijo no se aplicó**: la regla dice «en este plan, toda remisión a una sección del plan lleva el prefijo «plan §»», y las fichas de §C (l. 374–541) tienen **33** remisiones `§[A-H]` sin prefijo y **0** con prefijo (§0.1 «§A.3», §0.5 «§E.2», §7 «§F.6», §11 «§F.4», §14 «§E.5», Anexo A «§E.1», entre otras).
  - (c) **Cifras viejas en las preguntas abiertas del presupuesto**: «¿58 preguntas guía más 25 ítems de §15…?» (l. 370). Con el mismo método (`grep '^- Preguntas guía' | grep -o '«[^»]*?» (OA'`), la v1 da 56 y la v2 51, porque PAR2-18 sacó cinco. El régimen provisional de RV-05 son 26 OA, así que §15 tiene 26 ítems, no 25.
  - (d) **Dos grafías del contexto nuevo**: P-05 escribe «CTX-EXIST/CTX-NUEVA» (l. 998) y la presidencia, «CTX-NUEVA / CTX-EXISTENTE».
  - (e) **Frases que contradicen la respuesta 1 de la presidencia**: §F.1 dice «Recorre los cinco escenarios con siete pasos (PD-1…PD-7)» (l. 790), y la ficha de §14 dice «recorriendo los escenarios» y lista ESC-01…05 (l. 515, 518). Las dos quedan falsas en cuanto se vote el recorte de H2-054 o H2-056.
  - (f) **Riesgos del plan dentro de fichas que pasan a la guía**: «sin hito: R-07» (§4.1, l. 419) y «servidor ajeno: R-04» (§12.4, l. 497) siguen en la v2. La familia R-nn «no llega nunca» al lector (l. 368); estos son los dos casos que ED2-04 ya señalaba.
- **Evidencia (E2)**: las líneas citadas. Para (b), `awk 'NR>=374 && NR<=541' 04-Plan-De-Integracion.md | grep -oE '(plan )?§[A-H]([.0-9]+)?' | grep -vc '^plan'` → 33.
- **Impacto si no se corrige**: quien redacta la guía corrige «las líneas listadas» y cae en otras. Las 33 remisiones pasan a la guía, donde §A.3 se lee como Anexo A y §E.2 como Anexo E: el defecto de ED2-03 que la regla tenía que cerrar. Las preguntas abiertas de RV-04 se votan con cifras que ya no existen.
- **Propuesta de dirección**: en el parche de aplicación de este ciclo, cambiar la lista de líneas por «la lista la da el `grep`» (sin números de línea), poner el prefijo «plan §» en las 33 remisiones y comprobar con el `grep` de (b) = 0. Cambiar el «58» y el «25» por la cifra medida. Usar una sola grafía, CTX-EXISTENTE. Y poner en el mismo parche del recorte la frase de §F.1 y el propósito y los escenarios de §14.

## 2. Posiciones sobre la agenda

| Tema | Opción | Fundamento |
|---|---|---|
| **RV-04** (presupuesto de palabras) | **(a) enmendada**: §0.5 (mapa de `Examples/` y PD) pasa al Anexo E; Parte 0 ≤ 1.400; Anexos ≤ 7.430 (7.000 + 280 del mapa + 150 del glosario); las Partes I–VI y el Cierre mantienen su tope y absorben su saldo de este ciclo (≤ +117 cada una, < 2 % del tope), con lo que se declara y se mide en S-14 sin tomar del 15 %. Total ≤ 44.330. Antes del voto: la regla de conteo de ED3-02 y la cifra de la Parte 0 medida otra vez con ella | El Profile define el README como «tabla de contenido … con la ruta de lectura sugerida»: el mapa de ejemplos es material de laboratorio y su casa natural es el Anexo E (E4, Profile). Con (a) sola, la Parte 0 queda en 1.480 − 280 + 125 ≈ 1.325 por el método de `tr`, y en ~1.540 con la regla escrita: pasa los 1.200 en las dos lecturas (ED3-02). Con (b) sola, ~1.605 o ~1.820 contra 1.500. Ninguna de las dos opciones, tal como está escrita, deja la Parte 0 dentro de su tope. Mantener el total en 43.700 obliga a recortar ~625 palabras sin nombrar qué, y es justo lo que la regla de compensación prohíbe (ED3-01) |
| **Compensación ~+625** (objeción de J3 a PAR2-17) | **Procede**, con la tabla por Parte de ED3-01 | Sumas verificadas contra los costos que declara cada parche (E2): 910 − 285 = 625. El párrafo vigente tiene, además, errores de suma propios (760 y no 640; 285 y no 420) |
| **Par CTX-NUEVA / CTX-EXISTENTE** (respuesta 2 de la presidencia) | **APLICAR**, con cuatro condiciones en el mismo parche: (1) una sola grafía, CTX-EXISTENTE (P-05, l. 998); (2) «contexto de uso» como término del sentido N0, en BIT-16-03 §2, en §2.2 de la guía y en el Anexo C (ED3-04); (3) la columna del par en BIT-16-03 §5 (tabla por núcleo, l. 92) y en la frase de l. 55 («CTX-LOCAL × CTX-PROTO es la de esta guía»), además de §F.1 y §14 («CTX-EXISTENTE × CTX-LOCAL × CTX-PROTO»); (4) la fila I-05 §5.2 de BIT-16-02 §6 se cierra con este par | La definición de contexto de BIT-16-03 §2 encaja (E2: «variante que cambia la respuesta correcta dentro de un mismo escenario»). Sin (2), el par agrava el choque de sentidos (ED3-04). Queda una pregunta, no una afirmación: ¿alguna pieza (por ejemplo, un ejemplo de `Examples/` sin código previo) ocupa la celda CTX-NUEVA, o el lado «nuevo» sólo aparece como «qué cambiaría»? Si es lo segundo, la guía tiene que declararlo |
| **§B.4** («Agente por código» en el escalón 3) | **Corregir** como dice ED3-05: «1–3 (el artefacto no fija el escalón: §B.3)», más el agrupador de §8.7 | Contradice §B.3 l. 282 y la verificación (3) de PAR2-16 (E2), y la casa única de §9.3 la llevaría a la guía |
| **Criterio de dificultad B/I/A** | **Ratificar el criterio**, con la enmienda de grafía: en la guía la dificultad se escribe con palabras (básico, intermedio, avanzado), no con letras | Las letras A/B/C siguen nombrando EMB-A…C, los anexos A–G y las secciones A–H del plan (ED2-02). «I» y «A» sueltas en una columna no se distinguen de un anexo en la tabla de contenido |
| **RV-01** (casos integradores), sólo por el presupuesto | **(a)** | (c) suma ~300 palabras al Cierre sin compensación nombrada. (b) «fuera del conteo» choca con la regla de conteo, que cuenta toda la prosa de la Parte: necesitaría una excepción en `tools/contar.sh` |
| **H2-054 / H2-056** (recorte), sólo por el presupuesto y la coherencia | **A favor del recorte en la demo**, con la frase de §F.1 y la ficha de §14 dentro del mismo parche (ED3-06 e) | Cada paso PD que sale reduce §14.3 y ayuda a responder «¿alcanzan 4.500 palabras para la Parte VI con 13 ADR?» (l. 370). Qué pasos salen lo decide el jurado |

## 3. Revisado y bien

- **IDs que llegan al lector**: la tabla de familias (l. 368) y la forma `[REF-nn]` del Anexo D (l. 535) cierran el choque de prefijos de ED2-04. Quedan los dos residuos de ED3-06 (f), que la compuerta de l. 368 sí detecta.
- **Glosario y alias** (ED2-07): el Anexo C incluye puerto, adaptador, raíz de composición, modelo, token y temperatura, y registra «CAG de servicio» sólo como alias. «Prefijo cacheado» ya no aparece en el diagrama de §B.3 (l. 247).
- **«Nivel» y las series de letras** (ED2-02): TURNO-1…3, EMB-A…C y las variantes con nombre («un-agente») eliminan la colisión de «nivel A/B». ADR-07 se llama «Escalón de orquestación» (l. 508).
