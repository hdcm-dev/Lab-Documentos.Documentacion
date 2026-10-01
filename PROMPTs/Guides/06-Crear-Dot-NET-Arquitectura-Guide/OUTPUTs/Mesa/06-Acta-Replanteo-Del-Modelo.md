# 06 — Acta de la mesa: ¿se replantea el modelo que sostiene el método, o alcanza con corregirlo?

**Fecha:** 2026-09-28
**Clase de objeto:** diseño de una norma (`Knowledge-Mesa-De-Expertos-A-Pedido.md` §2.2)
**Objeto:** el método de deducción de reglas de negocio —`Knowledge-Deduccion-De-Reglas-De-Negocio.md`
1.3, `02-Criterio-De-Segmentacion.md` 1.1, `03-Catalogo-De-Etiquetas.md` 1.1— y el dictamen que redacta
37 parches sobre él, `04-Afirmacion-Distribuida-Y-Modificadores.md` 1.0.
**Quién aplica:** la mesa entrega el plan y los textos de reemplazo; la aplicación sobre `02`, `03` y
los `Knowledge-*` queda fuera del alcance de este acta por restricción dura del pedido.
**La mesa decide.** Lo que resuelve queda aprobado.

---

## Índice

- [0. Convocatoria](#0-convocatoria)
- [1. Base mecánica](#1-base-mecánica)
- [2. C-1 — ¿Procedimiento o mecanización?](#2-c-1--el-procedimiento-describe-lo-que-hace-una-persona-competente-o-una-mecanización-de-eso)
- [3. C-2 — ¿Se replantea el modelo?](#3-c-2--se-replantea-el-modelo-o-alcanza-con-dejar-de-tirar-información)
- [4. C-4 — El objeto sin nombrar](#4-c-4--el-objeto-sin-nombrar)
- [5. C-3 — Cuáles de los 37 parches sobreviven](#5-c-3--cuáles-de-los-37-parches-sobreviven)
- [6. C-5 — El volumen](#6-c-5--el-volumen)
- [7. Lo que la mesa declara irresoluble](#7-lo-que-la-mesa-declara-irresoluble-con-la-evidencia-disponible)
- [8. Tabla de decisiones y orden de aplicación](#8-tabla-de-decisiones-y-orden-de-aplicación)
- [9. Qué cambia para quien está usando el método hoy](#9-qué-cambia-para-quien-está-usando-el-método-hoy)

> **C-4 se trata antes que C-3 y C-5 a propósito.** El nombre del objeto es lo que decide qué parche
> declara un paso real, y sin él C-3 se contesta por gusto. El orden del enunciado se conserva en la
> numeración de las cuestiones y se altera en el de las secciones; está dicho para que no parezca un
> descuido.

---

## 0. Convocatoria

### 0.1 Contrato de entrada

```text
PEDIDO (literal, 2026-09-28): «Convocás y conducís una MESA DE EXPERTOS sobre una cuestión de fondo:
  si el modelo que sostiene un método de deducción de reglas de negocio hay que replantearlo, o
  alcanza con corregirlo. La mesa decide: lo que resuelva queda aprobado.»
CLASE DE OBJETO: diseño de una norma
OBJETIVO: decidir si el modelo se replantea o se corrige, y dejar cada una de las cinco cuestiones
  cerrada con parche concreto.
PREGUNTAS DEL CASO: C-1 a C-5, tal como las redacta el pedido. El dictamen responde cada una por
  separado, sin «depende».
RESTRICCIONES DURAS:
  · Sólo lectura sobre `/IA/SDD/IA.SDD`.
  · No se edita ningún archivo salvo este acta. En particular: nada bajo `PROG2/`,
    `Interactive-Activities/`, ni `Knowledge-*`, `02`, `03`, `04`.
  · Criterio de aceptación innegociable del Product Owner: después de la decisión, cada uno de los
    diez parches cae como consecuencia del modelo o desaparece. Si sobreviven como excepciones, la
    decisión fue la equivocada. Se verifica parche por parche.
  · `Icono-Y-Ancla` se aplica a todo lo que este acta redacte.
DECISIONES CERRADAS (no se rediscuten): `Mesa/04-Acta-Actividad-Interactiva.md` y
  `Mesa/05-Acta-Catalogo-De-Etiquetas.md` enteras. En particular: las ocho letras son ocho (C-1 del
  acta 05), las marcas `°`, `⟦ ⟧`, `⟦?⟧`, `!` y la forma `letra(nota)` (C-2), la hoja de bolsillo al
  frente (C-3), la generalización de la jerarquía a todo modificador (C-4) y la recuenta del `?` sin
  umbral (C-5).
FUERA DE ALCANCE: el diseño didáctico de la actividad; la solución de escritorio del autor; qué
  artefactos produce cada categoría del framework.
MEDIOS: lectura del corpus y conteos sobre los archivos. SIN OBSERVAR: ninguna corrida del método
  sobre material nuevo; §7 declara qué queda sin verificar por eso.
QUIÉN APLICA: nadie desde este acta. Se entrega plan, textos y orden.
PRESUPUESTO: una ronda. El corte se declara en §8.
```

### 0.2 Panel, con su señal y los descartes

| Rol | Señal que lo convoca | Mandato | No le corresponde |
| --- | --- | --- | --- |
| **Presidente** | — | Arma el contrato, verifica el despacho, consolida y escribe el cierre. **No vota** | Emitir hallazgos |
| **Conciliador** *(entra primero, por Reporte 23 §4.2)* | El pedido enfrenta dos criterios declarados —PO-1/PO-2 contra el gramático— y ninguno es una restricción dura del contrato | Detectar que dos criterios no se pueden aplicar juntos y **producir el que los reemplaza** | Proponer una posición intermedia |
| **Gramático del texto** | `04` está escrito desde ese rol y el contra-argumento a pesar es suyo | Sostener el remedio barato y su prueba | Decidir sobre el volumen del corpus |
| **Modelador de dominio** | C-4 pregunta si hay un objeto sin nombrar; nombrar objetos es esa competencia | Decir si el objeto existe, dónde vive ya y cómo se llama | Redactar gramática |
| **Ejecutor con lápiz** | `03` declara que su lector es «una persona con lápiz, en la mitad de la tarea»; los dos ejecutores son dato de diseño | Decir qué paso haría sin que se lo digan y cuál no haría nunca | Proponer notación nueva |
| **Ejecutor agente** | La otra mitad del mismo dato de diseño | Decir qué paso puede verificar y cuál sólo puede simular | Juzgar por intuición de dominio |
| **Editor de corpus** | Tres techos de categoría declarados y excedidos: `02` §9.7, `03` §11.5, `04` §16.14 | Decidir qué se conserva, qué se funde y qué se tira | Decidir contenido |
| **Refutador** *(entra último; es el único que lee a los demás)* | Permanente | Atacar la lectura dominante por evidencia **y por costo de aplicarla** | Emitir hallazgos propios fuera de eso |

**Descartados, con su motivo:**

| Descartado | Motivo |
| --- | --- |
| **Lingüista computacional** | No hay implementación que medir. Su aporte sería una arquitectura de análisis que ninguno de los dos ejecutores puede correr, y su señal —la extensión a imágenes de T-4— ya está cerrada como límite declarado en `04` §16.13 |
| **Usuario estándar** (`Mesa-De-Expertos-A-Pedido` §2.2.1) | Su evidencia admisible es `E3`, un recorrido sobre una interfaz en ejecución. Acá el objeto es un procedimiento de lápiz. Su función la cubre el **ejecutor con lápiz**, que sí puede leer el documento |
| **Didacta** | El diseño de la actividad se cerró en el acta `04` y es decisión cerrada |
| **Analista de articulado legal** | `02` §9.4 declara la calibración para prosa de negocio rioplatense; el articulado tiene su propia unidad de corte y está fuera de alcance |

---

## 1. Base mecánica

Medido antes de que nadie opine, con el comando al lado.

| Dato | Valor | Comando |
| --- | --- | --- |
| Líneas del corpus `Conocimientos/` | **6695** en 7 archivos: `00` 444, `01` 830, `02` 925, `03` 1578, `04` 2053, Knowledge 599, Icono 266 | `wc -l Conocimientos/*.md` |
| Parches redactados en `04` §15 | **20** a `02`, **14** a `03`, **3** al Knowledge = **37** | `grep -c '^| \*\*02-'` · `'^| \*\*03-'` · `'^| \*\*KD-'` |
| De ellos marcados `P0` | **13** | `grep -c '| \*\*P0\*\* |'` |
| Extensión de las dos pasadas nuevas (`04` §12 y §13) | **320 líneas** | `awk 'NR>=1408 && NR<=1727' \| wc -l` |
| Veces que `04` dice «conjunto de referencia» | **21** | `grep -c 'conjunto de referencia'` |
| Veces que dice «bolsa» | **7** | `grep -c 'bolsa'` |
| Veces que dice «casillero» | **5** | `grep -c 'casillero'` |
| Extensión de la hoja de bolsillo de `03` | **57 líneas** | `awk 'NR>=28 && NR<=84' \| wc -l` |

**Las tres últimas filas entran acá y no en el cuerpo por una razón.** Son tres nombres distintos, en
un mismo documento, para lo mismo, y ninguno está definido. Eso es exactamente el síntoma que PO-5
manda leer: **cuando un documento nombra tres veces lo que no definió, hay un objeto sin nombrar.**
Se retoma en C-4.

**Lo que la base mecánica no puede medir, y hay que decirlo antes de empezar:** ninguna de las dos
pasadas propuestas por `04` se corrió jamás. Su propio §16.15 lo declara: *«No se probó en una corrida
completa.»* Toda la discusión de C-2 es, por lo tanto, entre un procedimiento vigente con un fracaso
medido y un remedio sin uso. La mesa no puede saldar eso y lo declara en §7.

---

## 2. C-1 — ¿El procedimiento describe lo que hace una persona competente, o una mecanización de eso?

### 2.1 El instrumento: los cuatro movimientos, convertidos en prueba

PO-3 describe lo que hace una persona en cuatro movimientos: **agrupar, contrastar, apartar, cerrar**.
Para usarlos como criterio hay que poder correrlos sobre un paso, así que la mesa los convierte en una
prueba, y se la aplica a cada paso de `02` §5 y al paso 2 de `03`.

> **Prueba del acto.** Preguntale al paso: *¿una persona competente lo haría sin que se lo digan?*
>
> **Cómo se aplica.** Si la respuesta es sí, el paso **declara un acto**: se escribe, porque declarar
> un acto es lo que permite verificarlo en el otro ejecutor. Si la respuesta es no, el paso es
> **mecanización**, y entonces sólo se admite bajo un rótulo: **verificación** —algo que se comprueba
> *después*, no una manera de leer—. Una mecanización presentada como paso de lectura es un paso
> inventado, y se retira.
>
> **Un caso.** P11.5, la cota de atomización —contar verbos en forma personal y comparar—. ¿Una
> persona lo haría sin que se lo digan? **No.** Nadie cuenta verbos al leer un párrafo. ¿Es
> verificación? **Sí**: se corre al final, sobre lo ya producido, y detecta sobrecorte. → **se
> conserva, rotulada verificación.** Contra: P12.4, la propagación con desempate determinista por
> orden de texto. ¿Alguien lo haría sin que se lo digan? No. ¿Es verificación? Tampoco: **produce** la
> lectura elegida. → **paso inventado.**

### 2.2 El recorrido, paso por paso

| Paso | ¿Acto que una persona hace sola? | Movimiento de PO-3 que cubre | Veredicto |
| --- | --- | --- | --- |
| **P0** copia y numeración | Sí | — (preparación) | Acto |
| **P1** puntuación fuerte | Sí. «El corte gratis» | — (preparación) | Acto |
| **P2** marcar conectores | Sí, y el documento ya sabe por qué: *«esto es inventario, no producción»* | — | Acto |
| **P3** coordinación | Sí | — | Acto |
| **P4** podar adjuntos | Sí | — | Acto |
| **P5** relativas | Sí | **contrastar**, dentro de la oración | Acto |
| **P5-bis** modificadores | Sí | **contrastar**, y es el que falló | Acto |
| **P6** completivas y modalidad | Sí | — | Acto |
| **P7** restituir lo tácito | Sí | — | Acto |
| **P8** desnominalizar | Sí | — | Acto |
| **P9** las cuatro pruebas | No, una por una sobre cada candidata | — | **Verificación** |
| **P10** cierre de cobertura | Sí en su mitad —barrer lo que quedó suelto—. **No** en su otra mitad: *«exactamente un destino»* | — | **Acto + una mecanización adentro** |
| **P11** las seis condiciones | No | — | **Verificación** |
| **paso 2** de `03`, cinco segundos | Sí, y es el paso mejor fundado de todo el corpus | — | Acto |
| **P12** sintonización | No | pretende cubrir **contrastar** y **cerrar** | **Paso inventado** |
| **P13** recomposición | No | pretende cubrir **agrupar** | **Paso inventado** |

### 2.3 Lo que el recorrido muestra

**Tres cosas, y la tercera decide.**

**Primera: el procedimiento cubre uno de los cuatro movimientos y sólo dentro de la oración.**
*Contrastar* aparece en P5 y P5-bis, y el contraste que hace es del modificador contra un conjunto.
*Agrupar* no aparece en ningún paso. *Cerrar* tampoco. *Apartar* aparece, y aparece mal: el
procedimiento no aparta, **descarta**. El `?` se eleva, la lectura derrotada no se anota, la
alternativa se tira. «Apartar aquello que no cuadra» significa dejarlo a un lado **para volver**, y
volver exige que haya adónde. Ese es exactamente el hallazgo del gramático en `04` §10.3, y la mesa lo
asienta como correcto y procedente.

**Segunda: P10 contiene la mecanización que causa el resto.** «Todo tramo tiene **exactamente un**
destino» no es residuo cero: residuo cero es que nada quede sin destino. El «exactamente uno» agrega
una afirmación que nadie necesitaba —que los destinos son disjuntos— y es falsa sobre prosa: la
oración «tanto el casco como el puesto son instalaciones» alimenta la tabla de términos **y** el eje
que separa a los dos miembros **y** la afirmación distribuida, y no elige. El `04` §5.4 punto 2 lo
rozó y no lo nombró: *«su redacción —"exactamente uno"— refuerza la partición»*. Es más que un
refuerzo. **Es la cláusula que vuelve estructuralmente imposible agrupar.**

**Tercera, y es la que decide: P13.1 es la confesión.** El primer paso de la pasada de recomposición
dice, textual: *«Leer el párrafo entero, una sola vez, sin la hoja de fragmentos a la vista. El
propósito de la lectura no es encontrar nada: es **deshacer la partición** en la cabeza antes de
barrer.»*

Un procedimiento cuyo penúltimo paso consiste en deshacer lo que su primer paso hizo no está
describiendo un acto: está reparando un daño propio. Y la reparación llega tarde por construcción,
porque para entonces los fragmentos ya están etiquetados y cerrados —lo dice el mismo `04` §5.4 punto
4—.

**Una persona lee el párrafo entero primero.** No corta y después reconstruye: forma los conceptos
mientras lee y corta sobre conceptos ya formados. Eso no es una intuición sobre la psicología del
lector: es lo que el propio corpus mide, cuando `02` §3.1 explica por qué P-1 —el glosario— va antes
que P-4 —las reglas—: *«en el caso se salteó, y seis de las trece divergencias eran problemas de
término, no de regla»*. El procedimiento ya sabe que los términos van primero. Lo que no hizo fue
seguir su propio hallazgo una vuelta más: **si los términos van antes que las reglas, las cosas del
negocio van antes que los fragmentos.**

### 2.4 Decisión de C-1

> **El procedimiento describe la mecanización, no el acto, en tres lugares y sólo en tres: la cláusula
> «exactamente un destino» de P10, y las dos pasadas P12 y P13 que existen para reparar lo que esa
> cláusula rompe. Todo lo demás —P0 a P9, P11 como verificación, y el paso 2 entero de `03`— describe
> actos reales y se conserva sin cambios.**

**Fundamento.** Los diez pasos de corte pasan la prueba del acto. Las dos pasadas no la pasan ni como
acto ni como verificación: producen. Y la lectura de corrido que P13.1 manda hacer al final es el acto
que falta **al principio**.

**Parche concreto de C-1** —dos movimientos, ninguno inventa nada:

1. **P-0 gana la lectura de corrido.** El texto de P13.1 se muda entero al principio del
   procedimiento, con su misma justificación y sin una palabra nueva: *una lectura del párrafo entero,
   una sola vez, antes de cortar nada.* Deja de ser «deshacer la partición» y pasa a ser lo que
   siempre fue: **leer antes de cortar**.
2. **P10 pierde «exactamente».** Queda: *«Recorré el párrafo palabra por palabra y verificá que cada
   tramo tenga **al menos un** destino. Un tramo sin destino es siempre un error de análisis. Un
   tramo con dos destinos es lo normal, y el segundo destino es la hoja del referente (§4).»* Residuo
   cero se conserva entero; lo que se retira es la disyunción.

**Lo que no cambia, y conviene decirlo porque es el grueso:** el orden P1→P9, las 38 filas de la tabla
de estructuras, las cuatro pruebas operativas, la regla de la duda, los falsos cortes y las falsas
uniones, las ocho letras, los cinco segundos y la ley del paso sucio. **Nada de eso era mecanización.**

---

## 3. C-2 — ¿Se replantea el modelo o alcanza con dejar de tirar información?

### 3.1 Las dos posiciones, con lo mejor de cada una

**El gramático (`04` §10.3).** El remedio es barato. El procedimiento **ya produce** la lista de
lugares indecisos —los `?`, las disyunciones sin rotular, las restituciones no unívocas y, sobre todo,
las decisiones tomadas por un indicio derrotable, que hoy no dejan marca—. *«La corrección no es abrir
lecturas: es dejar de tirarlas.»* `P0–P11` no cambian. Y la sintonización encaja con algo que el
corpus ya tiene: es **la segunda compuerta del `?`** —la primera pregunta si hay un criterio que lo
resuelva; la segunda, si hay otra parte del texto—.

**El Product Owner (PO-1, PO-2).** El modelo es pobre y pide parches. Supone que un texto es un
conjunto de fragmentos independientes, cada uno con sentido determinado, que se clasifican localmente.
Diez parches en una sesión, y cinco son el mismo con otro disfraz: todos dicen que **el fragmento
atómico no es la unidad de sentido**.

**Lo que la mesa verifica antes de conciliar.** El PO cuenta cinco repetidos. **Son ocho.** El recuento,
con el mecanismo y su ámbito:

| # | Parche de la sesión | ¿Necesita mirar fuera del fragmento? |
| --- | --- | --- |
| 1 | Conjunto de contraste: dos ejes y regla del ámbito agotado | **Sí.** N1→N3 y Á1→Á4 son, literalmente, coordenadas de búsqueda fuera del fragmento |
| 2 | Indicio del paralelismo (2-bis) | **Sí.** El eje se lee en el núcleo coordinado, que es otro fragmento |
| 3 | Restringe / informa: los cuatro cuadrantes | **No.** Es el descubrimiento de que la decisión tiene dos salidas, no una |
| 4 | Adjetivo con dominio cerrado | **No.** Es una fila que faltaba en la tabla de estructuras |
| 5 | Afirmación distribuida y pasada P13 | **Sí.** Es su definición |
| 6 | Enmienda al indicio 3: la unicidad se juzga sobre el conjunto de referencia | **Sí.** El conjunto vive en otra oración |
| 7 | Reafirmación y triangulación | **Sí.** Cruzar formulaciones es cruzar fragmentos |
| 8 | Apertura selectiva y registro de lecturas abiertas | **Sí.** Existe para que un fragmento pueda esperar a otro |
| 9 | Pasada P12 de sintonización | **Sí.** Resuelve el conjunto |
| 10 | Escalera de diagnóstico y premisa faltante | **Sí.** Diagnostica dos afirmaciones que no cierran |

**Ocho de diez.** PO-2 es más fuerte de lo que su autor lo enunció, y las dos excepciones son las dos
que la mesa va a conservar intactas en C-3. Eso no es casualidad: son las dos que no hablan del mismo
problema.

### 3.2 La conciliación, que produce el criterio que ninguno de los dos propuso

**El gramático tiene razón en lo que probó y probó menos de lo que concluyó.** Lo que demostró —y es el
hallazgo más valioso de `04`— es que **no hace falta buscar nada nuevo**: la información ya se produce
y se tira, así que no hay explosión combinatoria ni costo de búsqueda. Eso es cierto, está bien
argumentado y la mesa lo adopta. Lo que **no** demostró es que el orden esté bien.

**El Product Owner tiene razón en el diagnóstico y no midió el costo del remedio que critica.** Su
criterio de adecuación —*«si los datos son más diversos de lo que pensó el modelo, el modelo hará
aguas por varios lados y tendrá puntos de conflicto»*— se verifica: ocho fugas, un documento que
triplica su techo, y tres nombres sin definir para el mismo objeto.

**El conductor midió lo que no era.** Aplicó la prueba de aceptación y encontró que los cinco parches
repetidos «caen como consecuencia». Lo que en realidad ocurrió es que se **consolidaron en dos**: P12 y
P13. Un parche consolidado no cayó: cambió de nombre y creció. Las dos pasadas son 320 líneas de
maquinaria —propagación, desempate determinista, ciclos, cota de una entrada cada dos oraciones,
`e = t + p + c + d`, cinco condiciones de admisión, ficha de once campos— y cada pieza existe para
atender un caso que el modelo no previó. **Nombrar cinco excepciones con dos nombres no es hacerlas
caer; es la definición exacta de «siguen haciendo falta como excepciones».** El criterio de aceptación
del PO, aplicado al remedio del gramático, lo rechaza.

> **El criterio conciliado, que no es de ninguno de los dos:**
>
> **La información no falta y la búsqueda no explota. Lo que está mal es dónde se guarda.** El
> procedimiento guarda por fragmento, y el sentido se acumula por **referente**. Dejar de tirar no
> alcanza si lo que se deja de tirar se sigue guardando en la caja del fragmento: entonces hay que
> inventar una pasada que lo vuelva a juntar, y esa pasada es el parche.
>
> **Cómo se aplica.** Ante cada mecanismo propuesto, preguntá: *¿esto agrega una búsqueda, o cambia
> el contenedor?* Si agrega una búsqueda, el gramático tiene razón y se rechaza: la información ya
> está. Si cambia el contenedor, el PO tiene razón y se adopta: el modelo era el equivocado.
>
> **Un caso.** La afirmación distribuida «el casco y los puestos se establecen en el acto de
> conformación» (`04` §14.3). Por el remedio del gramático: entrada `AB-5` en el registro, dos
> lecturas escritas con sus cinco casilleros de compromisos, inventario de reafirmaciones, `RF-4`
> discriminante, `L-a` fijada con causa, y después `P13` con su señal, dos premisas, `A1` a `A5` y
> ficha de once campos. Unas cuarenta líneas de aparato. Por el cambio de contenedor: la hoja del
> referente *instalación* tiene un casillero «momento»; O1 deposita «en su momento de conformación» y
> O2 deposita «en el mismo acto»; dos depósitos en el mismo casillero y un solo antecedente posible.
> **Tres líneas, y ningún mecanismo nuevo.**

### 3.3 Decisión de C-2

> **Se replantea el modelo. Y el replanteo es más barato que los diez parches, y también más barato
> que el remedio del gramático: es un solo cambio, y toca menos pasos que los que `04` §15.1 pide
> tocar.**
>
> **El cambio, entero:** la unidad de acumulación del método deja de ser el fragmento y pasa a ser el
> **referente** —la cosa del negocio de la que el párrafo habla—. El corte sigue produciendo
> fragmentos, porque cortar es correcto y es lo que el corpus mide bien. Lo que cambia es que cada
> fragmento, además de recibir su etiqueta, **deposita lo que dice en la hoja del referente del que
> habla**. El sentido se lee en la hoja, no en el fragmento.

**Fundamento.** (a) Pasa la prueba del acto de C-1: una persona agrupa mientras lee, y la hoja es la
declaración de ese agrupamiento, no su mecanización. (b) Adopta entero lo que el gramático probó: no
hay búsqueda nueva, no hay combinatoria, la información ya la produce el corte. (c) Satisface el
criterio de adecuación del PO: no queda ningún punto de conflicto que atender con una excepción. (d)
Y no inventa un objeto: el objeto ya está en el corpus, sin nombre y en el lugar equivocado. Eso es
C-4, y por eso va a continuación.

### 3.4 Verificación del criterio de aceptación, parche por parche

**No en bloque.** Uno por uno, con qué le pasa a cada uno bajo el modelo nuevo.

| # | Parche | Qué le pasa | ¿Excepción? |
| --- | --- | --- | --- |
| **1** | **Conjunto de contraste: dos ejes (N1–N4, Á1–Á5), regla del ámbito agotado, criterio de corte de la búsqueda, qué vale como ejemplar** | **Cae entero.** El conjunto de referencia **es** el casillero «género» de la hoja. No se busca: está depositado o no está. N1 a N3 son «la hoja»; N4 es «no está en la hoja, no decide»; Á1 a Á4 son «de dónde vino el depósito», que la hoja ya anota. La regla del ámbito agotado —*no encontrar sólo vale si barriste todo*— se vuelve verificable sin barrido: la hoja está cerrada o tiene pendientes | No |
| **2** | **Indicio del paralelismo, cuatro condiciones, seis casos NV** | **Se conserva, como regla de depósito, no como indicio.** Dos núcleos coordinados con modificadores de la misma clase **depositan un eje** en el casillero «eje». C1–C4 y la prueba del eje se conservan palabra por palabra; NV-1 a NV-6 se conservan como *cuándo no se deposita*. Deja de ser el indicio 2-bis de una jerarquía de ocho | No: es regla del modelo |
| **3** | **Cuatro cuadrantes `(restringe?, informa?)`** | **Se conserva entero, y mejora.** «Restringe» pasa a ser *hay un eje en el casillero*; «informa» pasa a ser *este depósito es nuevo en la hoja*. La contraprueba obligatoria —*nombrá dónde ya estaba*— deja de depender de la memoria del analista: se señala el depósito anterior en la hoja, o no hay Q4 | No |
| **4** | **Adjetivo con dominio cerrado: fila 39, cinco señales, tres desempates, D-1/D-2/D-3** | **Se conserva entero.** Es local, es una fila que faltaba, y ni el modelo viejo ni el nuevo la tocan. Deposita en el casillero «eje» un eje **con exhaustividad declarada**, que es lo que lo distingue de un eje común | No |
| **5** | **Afirmación distribuida y pasada P13** | **El fenómeno se conserva con su nombre; la pasada cae.** Una `AD` es *una hoja con dos casilleros llenos que ninguna oración dijo junta*. De las cinco condiciones de admisión, tres se vuelven automáticas —A1 dos anclas *(son dos casilleros)*, A3 vecindad *(es la misma hoja)*, A4 supresión *(sacá un casillero y a la conclusión le falta un término)*— y **dos siguen haciendo trabajo y se conservan: A2** —las premisas son letra— **y A5** —la negación contradice al párrafo—. Las ocho señales S-1 a S-8 dejan de ser una lista de barrido y se conservan como **disparadores de depósito**: ver §4.3 | No |
| **6** | **Enmienda al indicio 3: la unicidad se verifica sobre el conjunto de referencia** | **Cae entera.** La unicidad es un conteo del casillero «miembros». «El casco es único como casco y no como instalación» deja de poder formularse mal: la hoja es *instalación* y tiene dos miembros. La pregunta equivocada no se puede hacer | No |
| **7** | **Reafirmación, cinco formas RF-1 a RF-5, prueba de la discriminación** | **Se conserva, como la regla de contraste de la hoja.** Dos depósitos en el mismo casillero **son** una reafirmación, y la prueba de la discriminación —adorno, triangula, discordia— es el movimiento *contrastar* de PO-3, entero y sin cambios. RF-1 a RF-5 se conservan como *cómo se nota que llegó un segundo depósito*, y RF-5 —la operacional desempata— se conserva con su insistencia, porque es el hallazgo que resolvió el caso «coherente». Deja de ser el paso P12.2 | No: es regla del modelo |
| **8** | **Apertura selectiva, nueve orígenes AB-1 a AB-9, compromisos, techo de dos, cota global** | **Se conserva reducido a una regla; los nueve orígenes caen.** Eran nueve porque el `?` tenía nueve lugares donde nacer. En la hoja hay uno: **un depósito que no cierra con el casillero queda pendiente en la hoja.** Eso es *apartar*. El techo de dos lecturas se conserva con su fundamento. La cota de una entrada cada dos oraciones se conserva **como diagnóstico**, medida sobre pendientes en vez de entradas. `AB-7` —las decisiones por indicio derrotable no dejan marca— es el único que exige cambiar un hábito del corte, y **se conserva tal cual**: es un defecto real y verificado del procedimiento vigente | No |
| **9** | **Pasada P12 de sintonización: siete pasos, tablero fijo, orden de resolución, desempate determinista, propagación con causa, ciclos, realimentación acotada, cuenta de cinco números** | **Cae entera.** Todo eso es maquinaria para resolver un grafo de lecturas que sólo existe porque las lecturas se guardan por fragmento. En la hoja no hay grafo: cuando un casillero cierra, los pendientes de **esa** hoja que lo contradicen se descartan con causa escrita —la regla del descarte con causa se conserva, y es lo único que sobrevive de §13.4—. Sin grafo no hay propagación, no hay ciclos, no hay desempate por orden de texto y no hay `e = t + p + c + d` | No |
| **10** | **Escalera de diagnóstico E1/E2/E3, premisa faltante, unificación con I-08** | **Se conserva entera, y es lo más valioso del dictamen.** No habla de fragmentos: habla de dos afirmaciones que no cierran, que en el modelo nuevo son dos depósitos incompatibles en un casillero. E1, E2 y E3 con su orden, la prohibición de saltar peldaños, la obligación de declarar el descarte de los anteriores, los tres candados de la premisa faltante y el veredicto de §13.7 —se unifica el diagnóstico y el rótulo, no la búsqueda— pasan sin tocar. Tiene además el único testigo independiente del corpus: el autor corrigió el párrafo agregando la pieza faltante (§14.4) | No |

**Recuento: cuatro caen enteros (1, 6, 9 y la pasada de 5); tres se conservan intactos (3, 4, 10);
tres se conservan como reglas del modelo, no como excepciones (2, 7, 8).** Ninguno de los diez
sobrevive como excepción. **El criterio de aceptación del Product Owner se verificó parche por parche
y se cumple.**

---

## 4. C-4 — El objeto sin nombrar

### 4.1 Existe, y ya tiene destino en el corpus

PO-5 manda leer diez vistas de lo mismo como aviso de un objeto que nadie nombró. La base mecánica lo
confirma por el lado léxico: `04` dice **conjunto de referencia** 21 veces, **bolsa** 7 y **casillero**
5, y no define ninguno de los tres. `03` §14.1 llega a escribir la consecuencia sin nombrar la causa:
*«no son dos términos: es un término con dos facetas»*.

**Y el objeto no hay que inventarlo: ya está en el corpus, mal ubicado y anémico.**

- `03` §0.1 declara que el paso 3 vuelca las etiquetas en **tres tablas: términos, actos y reglas**.
  La fila de la tabla de términos es la cosa del negocio.
- El Knowledge §5.2 ya tiene su ficha: `| Término | Sentido 1 | Sentido 2 | Unidad | Nombre preferente
  | Equivalencias |`. **Seis columnas, todas sobre cómo se llama la cosa, ninguna sobre lo que el
  texto dice de ella.**
- El Knowledge §3.1 ya decidió que esa ficha va **primero**: *«El orden P-1 antes que P-4 no es
  estético: en el caso se salteó, y seis de las trece divergencias eran problemas de término.»*

**El método construyó el contenedor, lo puso al principio, y después no lo usó.** Lo usa para
desambiguar nombres y vuelve a trabajar fragmento por fragmento. Todo `04` es la consecuencia de esa
vuelta.

### 4.2 El nombre y su operación

> **Referente.** La cosa del negocio de la que el párrafo habla. Ningún fragmento la contiene entera,
> porque el autor la describió **por caras**: cada oración aporta una dimensión distinta de la misma
> cosa. El referente es el lugar donde las caras se intersecan.
>
> **Cómo se aplica.** Abrí **una hoja por cada sustantivo del dominio que el párrafo nombre**. Cada
> fragmento que diga algo de esa cosa **deposita** lo que dice en un casillero de la hoja, con el
> identificador del fragmento del que vino. Cuando un casillero recibe un **segundo** depósito,
> contrastalo con el primero: si coinciden, uno confirma al otro; si uno discrimina al otro, fija la
> lectura; si no cierran, es un hallazgo y va a la escalera. Un depósito que no cierra con el
> casillero **queda pendiente en la hoja**, no se tira. La hoja se cierra cuando no queda fragmento
> con algo que depositar y ningún pendiente sin causa.
>
> **Un caso, el del párrafo que originó todo.** Hoja **instalación**:
>
> | Casillero | Depósitos |
> | --- | --- |
> | género | ← O3 «tanto el casco como el puesto son **instalaciones**» · ← O3 «y **viviendas** donde se aloja el dueño y personal» |
> | eje | ← O2 «un casco **central**» ⟂ «varios puestos **rurales**» |
> | miembros | ← O2 «**un** casco» · «**varios** puestos» |
> | momento | ← O1 «en su **momento de conformación**» · ← O2 «en el **mismo acto** se establece» |
> | agente | ← O2 «a cargo de un **Administrador**» · ← O2 «el nombre del **encargado**» |
> | alcance | ← O4 «la administración del casco y de los puestos **se contempla en un futuro análisis**» |
>
> Una hoja, seis casilleros, once depósitos, cuatro oraciones.

### 4.3 Qué produce esa hoja, verificado contra lo que el corpus ya sabía

La mesa corrió la hoja contra los cinco resultados que `04` produjo sobre el mismo párrafo con 2053
líneas de aparato, y contra los que el corpus declaraba perdidos.

| Resultado que `04` produce | Con qué aparato lo produce | Con la hoja |
| --- | --- | --- |
| «central» es **Q1**, no epíteto; restringe sobre *instalaciones* | Indicio 2-bis + paso A/B/C + enmienda al 3 + cuatro cuadrantes | El casillero «eje» tiene depósito → restringe. El casillero «género» dice sobre qué. **Dos casilleros** |
| **AD:** la instalación central es el casco; las periféricas, los puestos | P13 entera: señal, premisas, A1–A5, ficha | Casillero «género» × casillero «eje». **Dos casilleros llenos que ninguna oración dijo junta** |
| **AD:** el casco y los puestos se establecen en el acto de conformación | `AB-5` + compromisos + `RF-4` + P12 + P13 | Casillero «momento», dos depósitos, un solo antecedente posible |
| *instalación* y *vivienda* son dos facetas de un referente, no dos términos | `AB-6` + `RF-3` + prueba de la discriminación | Casillero «género», dos depósitos, misma hoja. **Una entrada de glosario, no dos** |
| La administración se difiere: `E` sobre fragmentos ya etiquetados | Señal `S-7`, cierre de alcance diferido, reetiquetado hacia atrás | Casillero «alcance». No hay que reetiquetar hacia atrás: la hoja no estaba cerrada |

**Cinco resultados, seis casilleros, ninguna pasada.** Y hay una comprobación más fuerte, que es la que
convence a la mesa: **las ocho señales de `04` §8 mapean una a una sobre casilleros, sin sobrantes ni
faltantes.**

| Señal | Casillero donde deposita |
| --- | --- |
| S-1 hiperónimo diferido | género |
| S-2 modificadores en paralelo | eje |
| S-3 coordinados que reaparecen agrupados | la hoja del grupo: lo que se predica del grupo se deposita en cada miembro |
| S-4 definición diferida | definición |
| S-5 correlativos y pares cerrados | eje, con exhaustividad |
| S-6 repetición léxica con variación | **dos depósitos**: o es la misma hoja con otro nombre, o son dos hojas |
| S-7 cierre de alcance diferido | alcance |
| S-8 asimetría de detalle entre coordinados | **un casillero lleno en un miembro y vacío en el otro** |

**Ocho de ocho.** Una lista de señales que resulta ser una lista de casilleros no es una lista de
señales: es la descripción, hecha desde afuera, del objeto que el método no tenía. Eso es la prueba de
que el objeto existe y de que es éste.

### 4.4 Decisión de C-4

> **El objeto existe, se llama **referente**, su instrumento es la **hoja del referente**, y no es
> nuevo: es la fila de la tabla de términos del paso 3, adelantada al paso 1 y con casilleros de
> contenido además de columnas de nombre.**
>
> **Los casilleros, por ahora seis y uno más:** `género` (qué clase de cosa es), `eje` (de qué se
> distingue, y si el eje es exhaustivo), `miembros` (cuántos, cuáles), `momento` (cuándo nace, cuándo
> vale), `agente` (quién), `alcance` (qué no se va a hacer), y `definición` cuando el texto la da. La
> lista **no está declarada cerrada**: ver §7.

**Parche concreto de C-4:**

1. **El Knowledge §5.2 gana los casilleros.** La ficha de término pasa de seis columnas de nombre a
   seis columnas de nombre **más los casilleros de contenido**, cada uno con el identificador del
   fragmento del que vino. Sin columna nueva en ningún otro lado.
2. **`02` gana el depósito en P10**, que es donde ya recorre el párrafo palabra por palabra: *cada
   tramo tiene al menos un destino, y el destino adicional es la hoja del referente del que habla.*
3. **`03` §0.1 corrige el contrato**: la tabla de términos deja de llenarse en el paso 3 y pasa a
   abrirse en el paso 1 y a llenarse mientras se etiqueta. El paso 3 la **lee**, no la arma.
4. **Nada de esto agrega una letra, una marca ni un paso.**

---

## 5. C-3 — Cuáles de los 37 parches sobreviven

Se juzgan contra C-1: **sobrevive el que declara un paso real; desaparece el que parchaba un paso
inventado.** Tres resultados, no dos: hay parches cuyo *qué hay que arreglar* es correcto y cuyo *texto
de reemplazo* remite a un aparato que se retira.

### 5.1 Parches a `02` (20)

| # | Veredicto | Por qué |
| --- | --- | --- |
| **02-a** `P0` | **Sobrevive con texto nuevo** | La corrección es real y urgente: el documento afirma hoy que «un casco central» describe, y es falso. El texto de reemplazo de `04` resuelve el caso con el indicio 2-bis y el paso A/B/C; el nuevo lo resuelve con dos casilleros. **Texto nuevo en §8.2** |
| **02-b** `P0` | **Desaparece** | Parcha un paso inventado: el paso A/B/C es la búsqueda que el modelo nuevo no necesita. Se reemplaza por una línea: *el conjunto de referencia es el casillero «género» de la hoja; si está vacío, no hay conjunto y el indicio pasa el turno* |
| **02-c** `P0` | **Sobrevive con texto nuevo** | El paralelismo es un acto real. Deja de ser la fila «2-bis» de la jerarquía y pasa a ser regla de depósito en el casillero «eje», con C1–C4 y los seis NV intactos |
| **02-d** `P0` | **Desaparece** | La enmienda al indicio 3 sólo hace falta si la unicidad se puede juzgar sobre el núcleo. Con la hoja, no se puede |
| **02-e** `P0` | **Sobrevive tal cual** | Los cuatro cuadrantes y las tres reglas antifraude declaran un paso real y son el mejor aporte local del dictamen |
| **02-f** | **Sobrevive tal cual** | Fila 39, dominio cerrado |
| **02-g** | **Sobrevive tal cual** | Fila 37 pasa a salir con cuadrante |
| **02-h** | **Sobrevive a medias** | La mitad de los cuadrantes se aplica; el «agregar el paso A» se retira con 02-b |
| **02-i** | **Desaparece entero** | Agrega P12 y P13 al procedimiento y dos condiciones de terminación que los verifican. Los dos pasos no existen |
| **02-j** | **Sobrevive tal cual** | §3.9, dominio cerrado |
| **02-k** | **Sobrevive con texto nuevo** | Consecuencia mecánica de 02-c |
| **02-l** | **Desaparece** | Remite FU-10 a la clase `AD-3`, que se retira con la taxonomía de P13. La resolución vigente de FU-10 ya era correcta y `04` mismo dice que no la cambia: el parche era contabilidad |
| **02-m** | **Sobrevive a medias** | De los tres ítems de la lista de control: (a) cuadrante escrito **sobrevive**; (b) ámbito agotado **cae**; (c) P13 corrida **cae**. Entra uno nuevo: *toda hoja de referente cerrada, o con sus pendientes declarados con causa* |
| **02-n** | **Desaparece** | El orden en una línea no termina en «recomposición». Termina en «hojas cerradas» |
| **02-o** | **Sobrevive con texto nuevo** | Los estatutos hay que declararlos igual; cambia qué se incorpora |
| **02-p** | **Sobrevive con texto nuevo** | El límite es real —lo que la hoja produce es inferencia, no letra— y deja de hablar de «la pasada» |
| **02-q** | **Sobrevive con texto nuevo** | Control de cambios, reescrito sobre lo que efectivamente entra |
| **02-r** `P0` | **Sobrevive con texto nuevo** | *El `?` deja de ser terminal* es el mejor hallazgo del gramático y se adopta. Deja de ir a un registro de nueve orígenes y pasa a quedar **pendiente en la hoja** |
| **02-s** `P0` | **Sobrevive tal cual** | *Dejar marca donde hoy no la hay*: una decisión tomada por indicio derrotable no anota la lectura derrotada. Es un defecto real y verificado, y su corrección es una línea por decisión |
| **02-t** | **Sobrevive tal cual** | Lleva la escalera de diagnóstico a §6.2 y §9 por remisión. La escalera se conserva entera (§3.4, parche 10) y la remisión es correcta tal como está escrita |

### 5.2 Parches a `03` (14)

| # | Veredicto | Por qué |
| --- | --- | --- |
| **03-a** `P0` | **Sobrevive con texto nuevo** | La línea «sin conjunto de contraste, describe: A» es falsa y tiene que irse. Pero el reemplazo de `04` **es más largo que lo que reemplaza**, en una hoja de bolsillo de 57 líneas cuyo valor es caber. Texto nuevo, más corto que el vigente, en §8.2 |
| **03-b** `P0` | **Sobrevive tal cual** | El caso 6 del banco se reescribe: había criterio **y estaba mal aplicado**. Vale más reescrito que borrado |
| **03-c** `P0` | **Sobrevive tal cual** | «no hay otros cascos → no hay de dónde recortar» es falso y está escrito hoy |
| **03-d** `P0` | **Sobrevive a medias** | Los cuatro cuadrantes en la tabla «qué le toca a cada paso» **sobreviven**; el 2-bis entra como regla de depósito; la enmienda al 3 **cae** |
| **03-e** | **Sobrevive tal cual** | El ejemplo de `A` contra `R` estaba fundado en un veredicto falso |
| **03-f** | **Sobrevive a medias** | `A(dominio)` **entra**; la nota `(AD)` **cae** con P13 |
| **03-g** | **Desaparece** | El paso 1 no entrega `AD-nn` |
| **03-h** | **Desaparece** | Dos líneas en la hoja de bolsillo sobre un producto que no existe |
| **03-i** | **Sobrevive tal cual** | El borde de `A` con dominio enumerado |
| **03-j** | **Sobrevive tal cual** | Límite declarado: el banco contiene un veredicto corregido |
| **03-k** | **Sobrevive tal cual** | Control de cambios y procedencia |
| **03-l** `P0` | **Sobrevive con texto nuevo, y es el mejor de los 37** | *El segundo tramo de la compuerta del `?`* —«¿hay otra parte del texto que lo resuelva?»— **es** el movimiento *contrastar* de PO-3, y es gratis. Cambia su operación: «otra parte del texto» pasa a ser «otro depósito en el mismo casillero», que se mira en un lugar en vez de buscarse en cuatro ámbitos |
| **03-m** | **Sobrevive con texto nuevo** | La nota `(abierta)` es real y barata; el registro de nueve orígenes cae |
| **03-n** | **Sobrevive a medias** | De los tres signos: `(abierta)` **entra**; `⟪ ⟫` **cae** —no hay registro— y `≡` **cae** —el contraste ocurre en el casillero y no necesita signo—. `03` §2.3 ya había fundado por qué un signo nuevo se cobra en todos los fragmentos |

### 5.3 Parches al `Knowledge` (3)

| # | Veredicto | Por qué |
| --- | --- | --- |
| **KD-a** `P0` | **Sobrevive tal cual** | La reformulación de I-07 es PO-6 escrito antes de que PO-6 se enunciara: *el hallazgo es el desacuerdo, no la duplicación*, y la reafirmación que cierra es un instrumento que se usa. Se conserva entera, con su nota vigente |
| **KD-b** | **Sobrevive tal cual** | I-06 ordena recuperar la intención y no dice cómo. La triangulación —en especial con la formulación operacional, `RF-5`— es la operación que le faltaba. Es, literalmente, una reparación de icono según `Icono-Y-Ancla` §3.2 |
| **KD-c** | **Sobrevive tal cual** | La remisión cruzada con I-08 sin fusionar, fundada en enumerabilidad (`04` §13.7), es el razonamiento mejor construido del dictamen y sobrevive intacto al cambio de modelo |

### 5.4 Decisión de C-3

> **De los 37: 15 sobreviven tal como están escritos, 15 sobreviven con texto nuevo porque remiten a
> un aparato que se retira, y 7 desaparecen. Ninguno de los 13 marcados `P0` desaparece sin
> reemplazo: los cuatro que caen —02-b, 02-d, y las mitades de 02-h y 03-d— corregían un paso
> inventado, y lo que corregían deja de poder ocurrir.**

| Resultado | Cuántos | Cuáles |
| --- | --- | --- |
| **Sobreviven tal cual** | **15** | 02-e, 02-f, 02-g, 02-j, 02-s, 02-t · 03-b, 03-c, 03-e, 03-i, 03-j, 03-k · KD-a, KD-b, KD-c |
| **Sobreviven con texto nuevo** | **15** | 02-a, 02-c, 02-h, 02-k, 02-m, 02-o, 02-p, 02-q, 02-r · 03-a, 03-d, 03-f, 03-l, 03-m, 03-n |
| **Desaparecen** | **7** | 02-b, 02-d, 02-i, 02-l, 02-n · 03-g, 03-h |

*Aritmética, reproducible contando las filas de §5.1 a §5.3: `02` **6 + 9 + 5 = 20**; `03`
**6 + 6 + 2 = 14**; Knowledge **3 + 0 + 0 = 3**. Total **15 + 15 + 7 = 37**. Los que sobreviven «a
medias» —02-h, 02-m, 03-d, 03-f, 03-n— cuentan una vez, en «texto nuevo», porque la mitad que cae
obliga a reescribir el parche entero.*

---

## 6. C-5 — El volumen

### 6.1 El diagnóstico, que es el mismo que el método existe para corregir

6695 líneas para un método cuyo paso central se ejecuta en cinco segundos por fragmento. Y tres techos
de categoría declarados y excedidos por sus propios autores: `02` §9.7, `03` §11.5 y `04` §16.14, que
además dice *«empeoró a propósito»*.

**El editor de corpus asienta el punto que ordena todo lo demás:** un aparato que no se puede sostener
no se va a usar, y no usarse produce **exactamente el defecto que el método persigue** —una afirmación
que nadie verifica—. Un documento de 2053 líneas que nadie corrió entero es una regla no ejercida, y
el filtro de juicio de `Knowledge-Mesa-De-Expertos-A-Pedido.md` §3.3 dice qué se hace con eso: **no se
reescribe para absolverlo; se declara.**

### 6.2 Decisión de C-5

> **Se tira la mitad. Circulan cinco documentos en lugar de siete, y ninguno nuevo.**

| Documento | Hoy | Decisión | Después |
| --- | --- | --- | --- |
| `00-Dictamen-Diseno-De-Roles.md` | 444 | **Se tira**, con una condición | 0 |
| `01-Cuerpo-Metodologico.md` | 830 | **Se tira**, con la misma condición | 0 |
| `02-Criterio-De-Segmentacion.md` | 925 | **Se conserva y crece poco** | ~965 |
| `03-Catalogo-De-Etiquetas.md` | 1578 | **Se parte**, por su propio §11.5 | ~700 (A) + ~650 (B) |
| `04-Afirmacion-Distribuida-Y-Modificadores.md` | 2053 | **Se disuelve**: sale de circulación y queda como folio sellado | 0 en circulación |
| `Knowledge-Deduccion-De-Reglas-De-Negocio.md` | 599 | **Se conserva en su techo** | 599 |
| `Knowledge-Icono-Y-Ancla.md` | 266 | **Se conserva sin tocar** | 266 |
| **Total en circulación** | **6695** | | **≈ 3180** |

**Fundamentos, uno por uno:**

**`00` y `01` se tiran.** El Knowledge §9 los declara «dictámenes que lo fundan», y el Knowledge ya
consolidó su contenido. Son 1274 líneas cuya única función es ser la procedencia de un documento que
declara su procedencia en una fila. **La condición, y es innegociable:** `Icono-Y-Ancla` §1.3 advierte
que *«la operación es lo primero que se cae al consolidar»*. Antes de borrarlos se corre **una** pasada
de auditoría de consolidación —§6 de `Icono-Y-Ancla`, criterio interpretativo último— que recupere del
`00` y del `01` toda operación que el Knowledge haya comprimido. Lo recuperado entra al Knowledge; lo
demás se borra. **No se conservan «por las dudas»: eso es cómo el corpus llegó acá.**

**`04` se disuelve.** No es conocimiento: es un dictamen, y su propio §15 dice *«este documento no
edita a sus hermanos»*, o sea que está escrito para consumirse. Lo que vale se aplica en `02`, `03` y
el Knowledge por los 30 parches que sobreviven. Lo que no vale —§12 y §13, 320 líneas de maquinaria
que esta mesa retira, más los dos ejes de §1 y la enmienda de §2.4— no se aplica en ningún lado.
**Queda como folio histórico, sellado y no vigente**, porque contiene el razonamiento que funda las
decisiones y `Icono-Y-Ancla` D-3 prohíbe simular lo que no se puede reconstruir. Deja de leerse: se
cita.

**`03` se parte ahora, por su propio §11.5**, y la partición sale más chica de lo que ese apartado
planeaba, por dos motivos concretos: §8 —la jerarquía generalizada, 76 líneas— se reduce a una remisión
cuando el conjunto de referencia deja de buscarse, y §7 —«¿alcanzan las ocho etiquetas?», 119 líneas—
es una decisión cerrada del acta `05` y su lugar es un control de cambios, no un documento que se lee
con el lápiz en la mano. La advertencia dimensional honesta del propio §11.5 —que `B` queda sobre el
techo con seis filas de ejemplos— se resuelve bajando a tres filas, como ese mismo apartado propone.

**El Knowledge se queda en 599 y entra todo.** Los tres parches `KD` suman unas diez líneas a §3.6, y
el techo es 600. Lo que sale para hacerles lugar: **el diagrama `mermaid` de §2.3, 25 líneas**, que
repite la tabla de §2.1 sin agregar una operación. Es, con el criterio del propio `Icono-Y-Ancla` §3.3,
una escena de repertorio. Neto: **584**, bajo el techo por primera vez.

**Lo nuevo no es un documento.** La hoja del referente cuesta unas **60 líneas**: la ficha ampliada en
el Knowledge §5.2, el depósito en `02` P10, la corrección del contrato en `03` §0.1 y cuatro líneas en
la hoja de bolsillo. **Cero archivos nuevos.** Esa es la prueba de que el replanteo es más barato que
el parcheo: los diez parches produjeron 2053 líneas; el replanteo produce 60 y retira 3500.

---

## 7. Lo que la mesa declara irresoluble con la evidencia disponible

**Dos cosas. Ninguna se rellena.**

**IR-1 — La hoja del referente no se corrió a ciegas.** La verificación de §4.3 es una
**re-derivación**, no una prueba: la mesa conocía los cinco resultados antes de abrir la hoja, porque
están escritos en `04`. Que la hoja los reproduzca con seis casilleros demuestra que el objeto es
suficiente para lo ya encontrado; **no demuestra que encuentre lo que no se encontró**.

*Qué haría falta, y es barato:* correr la hoja sobre los párrafos del enunciado de la estancia que el
corpus declara no cubiertos —`03` §10 límite 9 dice que la decisión de las ocho letras se tomó sobre
**dos de las cuatro oraciones** de un solo párrafo— y contar cuántas de las **14 reglas no escritas** y
los **9 huecos** del documento `10-Relectura-De-Intencion.md` salen de leer las hojas. Ese conteo es el
único que convierte esta decisión en medida. Hasta entonces: decisión fundada en el material existente
y **no probada sobre material nuevo**.

**IR-2 — La lista de casilleros no está declarada cerrada, y hay una costura visible.** Los seis salen
de intersecar las ocho señales de `04` §8 con los cinco compromisos de `04` §12.3. Los dos conjuntos
coinciden en cuatro —referente, alcance, momento, cardinalidad— y el quinto compromiso, **modalidad**,
**no entra**: obligar, permitir y prohibir no son propiedades de una cosa, son propiedades de un acto.

Eso deja una pregunta abierta que la mesa **no puede contestar sin una corrida**: ¿hay también hojas de
acto, con casilleros distintos —quién, qué exige antes, qué cambia, qué pasa si falla—? Una persona
las lleva, eso lo sostiene el ejecutor con lápiz. Pero sus casilleros no se derivan de ninguna medición
del corpus, y escribirlos acá sería fabricar la operación que `Icono-Y-Ancla` D-3 prohíbe simular.

*Qué haría falta:* la misma corrida de IR-1, mirando si los depósitos que no encuentran casillero en
una hoja de término son todos del mismo tipo. Si lo son, la hoja de acto existe y sus casilleros se
leen de ahí. Si no, los seis alcanzan.

**Y lo que la mesa declara que NO es irresoluble, aunque lo parezca:** si el gramático tenía razón. La
tiene, en lo que probó, y §3.2 dice exactamente qué probó y qué no. Eso está decidido, no empatado.

---

## 8. Tabla de decisiones y orden de aplicación

### 8.1 Las cinco cuestiones

| # | Cuestión | Decisión |
| --- | --- | --- |
| **C-1** | ¿Procedimiento o mecanización? | **Mecanización en tres lugares y sólo en tres**: la cláusula «exactamente un destino» de P10, y las pasadas P12 y P13. El resto describe actos y se conserva sin cambios. La lectura de corrido de P13.1 se muda al principio |
| **C-2** | ¿Replanteo o corrección? | **Se replantea el modelo, con un solo cambio**: la unidad de acumulación deja de ser el fragmento y pasa a ser el referente. Sale más barato que los diez parches y que el remedio del gramático. Criterio de aceptación del PO **verificado parche por parche: se cumple** |
| **C-3** | ¿Cuáles de los 37 sobreviven? | **15 tal cual, 15 con texto nuevo, 7 desaparecen.** Ninguno de los 13 `P0` queda sin reemplazo |
| **C-4** | ¿Hay un objeto sin nombrar? | **Sí. Se llama referente; su instrumento es la hoja del referente.** No es nuevo: es la fila de la tabla de términos del paso 3, adelantada al paso 1 y con casilleros de contenido. Las ocho señales de `04` §8 mapean una a una sobre casilleros |
| **C-5** | El volumen | **Se tira la mitad.** `00` y `01` se borran con auditoría previa de consolidación; `04` se disuelve y queda como folio sellado; `03` se parte por su propio §11.5; el Knowledge baja a 584 y entra bajo su techo. De 6695 a ≈3180 en circulación, con cero archivos nuevos |

### 8.2 Los dos textos de reemplazo que la mesa redacta

**Para 02-a y 03-c** —el ejemplo «un casco central», que hoy está escrito al revés en dos documentos:

> **Adjetivo restrictivo sobre un conjunto que el núcleo no nombra.** «se establece un casco
> **central** … y varios puestos **rurales**». Abrí la hoja del referente *instalación*. El casillero
> **género** recibe un depósito de la oración siguiente: «tanto el casco como el puesto **son
> instalaciones**». El casillero **eje** recibe uno de esta misma oración: dos núcleos coordinados
> bajo «se establece», dos adjetivos pospuestos, eje nombrable *ubicación*. Con el eje depositado,
> «central» **restringe**, y restringe sobre *instalaciones* —no sobre cascos—. ¿Informa? Para decir
> que no, hay que señalar el depósito anterior donde ya estuviera dicho que el casco es el central, y
> no hay ninguno: **informa**. → **Q1**, `⟨C-restr⟩`. **La versión 1.1 daba este caso por «describe»,
> y era la unicidad del núcleo juzgada como si el núcleo fuera el conjunto.**

**Para 03-a** —el bloque `MODIFICADORES` de la hoja de bolsillo. **Más corto que el vigente**, que es
la única condición que una hoja de bolsillo impone:

```text
MODIFICADORES ("un casco central")
  1. ¿es argumento? → no entra
  2. antepuesto → describe | universal (todo, cada, los... que) → RESTRINGE
     el indefinido (un, una, unos) NO PRUEBA NADA
  3. ¿CONTRA CUÁL?  mirá el casillero "eje" de la hoja del referente.
     Si hay eje depositado → restringe, y sobre el GÉNERO de la hoja,
     no sobre el núcleo.  Si la hoja está vacía, el indicio pasa el turno.
  DOS PREGUNTAS, no una:
     ¿restringe? (¿hay eje?)      ¿informa? (¿es depósito nuevo?)
     Q1 sí/sí → R   Q2 sí/no → R°   Q3 no/sí → A   Q4 no/no → T°
     Para poner Q4 tenés que SEÑALAR el depósito anterior.
     "No restringe" NO es "no importa".
```

### 8.3 Orden de aplicación

**Seis tramos. El orden importa: cada uno deja el corpus consistente, y ninguno depende del siguiente.**

| # | Tramo | Qué se hace | Por qué va acá |
| --- | --- | --- | --- |
| **1** | **Detener la contradicción** | Aplicar los `P0` que corrigen afirmaciones hoy falsas: 02-a y 03-a con los textos de §8.2, más 03-b, 03-c, 03-e | Hasta que se apliquen, tres documentos afirman que «central» describe, y eso es falso. Es lo único que daña hoy |
| **2** | **Los tres `KD`** | KD-a, KD-b, KD-c, más la baja del diagrama de §2.3 que les hace lugar | Son independientes de todo lo demás, sobreviven tal cual, y dejan el Knowledge bajo su techo |
| **3** | **El objeto** | La ficha ampliada en Knowledge §5.2; el depósito en `02` P10 y la baja de «exactamente»; la lectura de corrido en P-0; el contrato corregido en `03` §0.1; las cuatro líneas de la hoja de bolsillo | Es el cambio de modelo entero. Sesenta líneas |
| **4** | **Lo local que sobrevive intacto** | 02-e, 02-f, 02-g, 02-j, 02-s, 02-t · 03-i, 03-j, 03-k · y las mitades vivas de 02-h, 02-m, 03-d, 03-f, 03-n | No dependen del objeto y no lo contradicen |
| **5** | **Lo que el objeto reescribe** | 02-c, 02-k, 02-r, 03-l, 03-m con texto nuevo; 02-o, 02-p y 02-q de contabilidad | Requiere el tramo 3 aplicado |
| **6** | **El volumen** | Auditoría de consolidación sobre `00` y `01` → baja; sellado de `04`; partición de `03` en A y B | Va último: una partición sobre documentos que todavía se están corrigiendo se hace dos veces |

**Criterio de corte de esta mesa.** Una ronda. Se cierra acá por decisión y no por agotamiento, y se
declara: las cinco cuestiones tienen decisión con parche, y lo que queda abierto está en §7 con lo que
haría falta para cerrarlo. Una segunda ronda antes de la corrida de IR-1 produciría más aparato sobre
el mismo material, que es el defecto que este acta acaba de nombrar.

---

## 9. Qué cambia para quien está usando el método hoy

**Corto y explícito, porque es lo primero que se lee.**

### 9.1 Nada de lo que venís usando se invalida

**Las ocho letras siguen siendo ocho.** `T A V C M R E ?`. No entra una novena y no sale ninguna.

**Todas las marcas siguen igual y significan lo mismo:** `°` el anillo, `⟦ ⟧` lo que pusiste vos, `⟦?⟧`
el hueco que no pudiste reponer, `!` el fragmento mal cortado, y la forma `letra(nota)` con sus tres
palabras. **`R(estructura)` se conserva sin un cambio**, con su segunda entrada de reconocimiento y su
destino en la columna `Especie`.

**Los cinco segundos, la ley del paso sucio, la doble etiqueta y la recuenta del `?` al cierre: sin
cambios.** El orden de corte P1→P9, las 38 filas de estructuras, las cuatro pruebas, la regla de la
duda, los falsos cortes y las falsas uniones: sin cambios.

### 9.2 Una cosa que estabas haciendo y está mal

**Si usaste la línea «sin conjunto de contraste, describe: `A`» de la hoja de bolsillo, el veredicto
sobre «central» salió mal, y con él cualquier adjetivo que recorte sobre un conjunto que su propio
sustantivo no nombra.** La regla correcta es: el conjunto contra el que un modificador recorta **no es
la extensión de su sustantivo**. Buscar «otro casco» es buscar en el lugar equivocado. Es el único
resultado de este acta que invalida algo ya producido, y se corrige releyendo los modificadores, no
rehaciendo el corte.

### 9.3 Tres cosas nuevas, y las tres son baratas

1. **La hoja del referente.** Una hoja por cada sustantivo del dominio que el párrafo nombra. Mientras
   etiquetás, cada fragmento deposita lo que dice sobre esa cosa en un casillero —género, eje,
   miembros, momento, agente, alcance, definición— con el número del fragmento al lado. **No es un
   paso más: es la misma pasada, anotando en dos lugares en vez de uno.** Y no es una tabla nueva: es
   la tabla de términos que ya llenabas en el paso 3, abierta antes.
2. **Dos preguntas en vez de una sobre cada modificador**, y su respuesta escrita como cuadrante:
   *¿restringe?* —¿hay eje en el casillero?— y *¿informa?* —¿es un depósito nuevo?—. `Q1 → R`,
   `Q2 → R°`, `Q3 → A`, `Q4 → T°`. **Para poner `Q4` tenés que señalar el depósito anterior donde ya
   estaba dicho.** Si no podés señalarlo, es `Q3`.
3. **La nota `A(dominio)`**, para el fragmento que declara los valores posibles de una propiedad en
   vez de asignar uno —«el casco es permanente o temporal»—. Es una nota, no una letra: no compite
   con nada.

### 9.4 Una cosa que se te vuelve más fácil

**El `?` deja de ser terminal.** Antes, un `?` que ningún criterio resolvía iba derecho al
cuestionario del autor. Ahora tiene una segunda compuerta y se mira en un solo lugar: *¿hay otro
depósito en el mismo casillero de la misma hoja que lo resuelva?* Recién lo que sobrevive a las dos
compuertas es una pregunta para el autor. Y un depósito que no cierra **no se tira: queda pendiente en
la hoja**, que es dónde vas a encontrarlo cuando la oración que lo resuelve llegue tres renglones
después.

### 9.5 Todo esto no tenés que aprenderlo

El dictamen `04` propuso, y esta mesa retira, un aparato que nunca llegaste a usar. **No hace falta
que aprendas nada de esta lista:**

las dos pasadas **P12** y **P13**; los nueve orígenes de apertura **AB-1** a **AB-9**; el registro de
lecturas abiertas y sus **compromisos** por casillero; la propagación, los ciclos y el desempate
determinista por orden de texto; la cota de una entrada abierta cada dos oraciones; las ocho señales
**S-1** a **S-8** como barrido; las cinco formas **RF-1** a **RF-5** como inventario; las cinco
condiciones de admisión **A1–A5** y la ficha **AD** de once campos; las clases **AD-1/AD-2/AD-3**; los
dos ejes del conjunto de contraste **N1–N4** y **Á1–Á5** con su regla del ámbito agotado; y los cuatro
signos nuevos **`⟪ ⟫`**, **`≡`**, **`⟂`** y **`⊂`**.

**Nada de eso entra a la hoja de bolsillo, y por lo tanto nada de eso entra al método.** Lo que esos
mecanismos hacían bien —contrastar dos formulaciones, apartar lo que no cierra, nombrar la pieza que
falta, diagnosticar antes de declarar contradicción— **se conserva entero**, y se hace en la hoja del
referente, mirando un casillero.

---

## Control de cambios

| Versión | Fecha | Cambios |
| --- | --- | --- |
| 1.0 | 2026-09-28 | Emisión. **C-1:** prueba del acto sobre los dieciséis pasos; mecanización en tres lugares —«exactamente un destino» de P10, P12 y P13—; P13.1 identificado como confesión y mudado a P-0. **C-2:** se replantea el modelo; recuento corregido de los parches repetidos —**ocho de diez**, no cinco—; criterio conciliado *la información no falta y la búsqueda no explota, lo que está mal es dónde se guarda*; verificación parche por parche del criterio de aceptación del PO, con cuatro que caen enteros, tres intactos y tres convertidos en reglas del modelo, **ninguno como excepción**. **C-4:** el objeto existe, se llama **referente**, su instrumento es la **hoja del referente**, y ya estaba en el corpus como la fila de la tabla de términos del paso 3; las ocho señales de `04` §8 mapean una a una sobre casilleros. **C-3:** de los 37 parches, **15 tal cual, 15 con texto nuevo, 7 desaparecen**; dos textos de reemplazo redactados. **C-5:** de 6695 líneas a ≈3180 en circulación; `00` y `01` se borran tras auditoría de consolidación, `04` se disuelve y queda sellado, `03` se parte por su propio §11.5, el Knowledge baja a 584 y entra bajo su techo; el replanteo cuesta 60 líneas y cero archivos nuevos. **Irresolubles declarados:** la hoja no se corrió a ciegas (IR-1) y la lista de casilleros no está cerrada, con la costura de *modalidad* nombrada (IR-2). |
