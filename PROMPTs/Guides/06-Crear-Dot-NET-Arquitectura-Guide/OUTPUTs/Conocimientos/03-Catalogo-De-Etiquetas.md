# 03 — Catálogo de etiquetas: cómo se reconoce cada una sobre un fragmento

**Fecha:** 2026-09-28
**Rol:** reconocimiento rápido de fragmentos para el paso 2 del procedimiento de análisis de un
enunciado de negocio.
**Para quién:** una persona con lápiz, en la mitad de la tarea, que tiene que decidir **en cinco
segundos** y seguir.
**Qué es:** el catálogo de reconocimiento de las etiquetas del paso 2 —definición operativa,
bordes, preguntas de reconocimiento con su razonamiento, ejemplos resueltos y desempates entre
etiquetas—, más las marcas que evitan multiplicar las letras y la compuerta que impide que el
`?` se convierta en un depósito.
**Qué no es:** no es el criterio de corte —eso es `02-Criterio-De-Segmentacion.md`, que produce los
fragmentos que acá se etiquetan— ni el catálogo de reglas —eso es
`Knowledge-Deduccion-De-Reglas-De-Negocio.md`, que trabaja sobre las tablas que el paso 3 arma—.
Acá se empieza con un fragmento sin etiqueta y se termina con el fragmento etiquetado. Nada más.

> **Si estás etiquetando ahora mismo, no leas esto: llevate la hoja de bolsillo de acá abajo y volvé
> cuando una letra se te resista.** El resto del documento es la referencia que explica por qué cada
> ficha dice lo que dice.

> **La frase que gobierna todo el documento:** en el paso 2 el error caro no es la etiqueta
> equivocada, es **el fragmento sin etiqueta**. Una etiqueta mala se descubre al armar las tablas del
> paso 3, porque el fragmento choca con la columna. Un fragmento sin anotar no choca con nada: se
> pierde en silencio.

---

## Hoja de bolsillo

Lo único que hace falta tener al lado del párrafo. Cabe en media carilla.

```text
ETIQUETAS
  T  término       nombra una cosa contable, con vida propia
  A  atributo      un dato con valor, que la cosa lleva encima
  V  acto          alguien hace algo, y puede salir mal
  C  cardinalidad  cuántos: un, al menos, único, a lo sumo, varios
  M  momento       contesta "¿cuándo?", y nada más
  R  regla         podés contar la escena del rechazo
  E  alcance       avisa que algo NO se va a hacer
  ?  no se decide  ni con el texto ni con los criterios (pasá la compuerta)
  (ocho letras. No hay novena.)

MARCAS
  °       no abre fila nueva: SEGUNDA MENCIÓN       →  M°  T°
          (el efecto de un acto NO lleva anillo: es V, y el paso 3 lo fusiona)
  ⟦ ⟧     lo puse yo: sujeto, agente, antecedente. NO va en la cita
  ⟦?⟧     no pude reponerlo: HALLAZGO, no duda. Se cobra en V y en R
  X/Y     dos etiquetas. Es lo correcto, no una indecisión  (X+Y es lo mismo)
  !       el fragmento vino mal cortado. No vuelvas al paso 1:
          al cerrar, copiá la lista de ! al pie de la hoja
  letra(nota)  hasta tres palabras pegadas a la letra. NUNCA rutea
               R(estructura)   C(describe)   ?(dos lecturas)

LAS CUATRO PREGUNTAS, en orden
  1. ¿puedo contar el rechazo?          → R
  2. ¿contesta "cuándo"?                → M  (aunque diga "acto")
  3. ¿de qué es?  resp. obligada        → A  ; pregunta rara → T
  4. ¿hay dos cosas del negocio,        → R(estructura)
     atadas por una locución, y no
     podés contar el rechazo?

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

HOJA DEL REFERENTE  (una por sustantivo del dominio, abierta en el paso 1)
  casilleros: género · eje · miembros · momento · agente · alcance · definición
  cada fragmento DEPOSITA lo que dice, con su número al lado
  2do depósito en un casillero → contrastá.  ¿no cierra? → PENDIENTE, no se tira

RITMO
  5 segundos. Si dudás, las dos etiquetas y seguís.
  Si no tenés ninguna, compuerta del ? (3 preguntas).
  NUNCA un fragmento en blanco. NUNCA releer para mejorar.
  Terminaste cuando: recorrés los números del paso 1 y ninguno
  quedó sin letra.

AL CERRAR
  contá los ? solos            →  anotá  ? n/total
  corré la compuerta sobre ésos y sólo ésos  (criterios, y después la hoja)
  anotá la cuenta final        →  ? n/total → m/total → k/total
  copiá la lista de ! al pie
```

---

## Índice

> **Si estás etiquetando, andá a la [hoja de bolsillo](#hoja-de-bolsillo), que está acá arriba.** Todo
> lo que sigue es referencia: se abre cuando una letra se resiste.

- [Hoja de bolsillo](#hoja-de-bolsillo)
- [0. Dónde vive este paso](#0-dónde-vive-este-paso)
  - [0.1 El contrato con el paso 1 y con el paso 3](#01-el-contrato-con-el-paso-1-y-con-el-paso-3)
  - [0.2 Notación](#02-notación)
  - [0.3 Qué es propio de este documento](#03-qué-es-propio-de-este-documento)
- [1. La ley del paso sucio](#1-la-ley-del-paso-sucio)
  - [1.1 El enunciado y por qué se sostiene](#11-el-enunciado-y-por-qué-se-sostiene)
  - [1.2 La regla de los cinco segundos](#12-la-regla-de-los-cinco-segundos)
  - [1.3 La doble etiqueta no es una falla: es el mecanismo](#13-la-doble-etiqueta-no-es-una-falla-es-el-mecanismo)
  - [1.4 Cómo se sabe que el paso 2 terminó](#14-cómo-se-sabe-que-el-paso-2-terminó)
- [2. Las marcas, y por qué no son letras](#2-las-marcas-y-por-qué-no-son-letras)
  - [2.1 El anillo `°`: esto no abre fila nueva](#21-el-anillo--esto-no-abre-fila-nueva)
  - [2.2 Los corchetes `⟦ ⟧`: esto lo puse yo](#22-los-corchetes---esto-lo-puse-yo)
  - [2.3 Por qué una marca cuesta menos que una letra](#23-por-qué-una-marca-cuesta-menos-que-una-letra)
  - [2.4 El signo `!`: esto vino mal cortado](#24-el-signo--esto-vino-mal-cortado)
- [3. El catálogo, etiqueta por etiqueta](#3-el-catálogo-etiqueta-por-etiqueta)
  - [3.1 `T` — término](#31-t--término)
  - [3.2 `A` — atributo](#32-a--atributo)
  - [3.3 `V` — acto](#33-v--acto)
  - [3.4 `C` — cardinalidad](#34-c--cardinalidad)
  - [3.5 `M` — momento](#35-m--momento)
  - [3.6 `R` — candidata a regla](#36-r--candidata-a-regla)
  - [3.7 `E` — alcance](#37-e--alcance)
  - [3.8 `?` — no se decide](#38---no-se-decide)
- [4. Desempates entre etiquetas](#4-desempates-entre-etiquetas)
  - [4.1 Las cuatro que más valen](#41-las-cuatro-que-más-valen)
  - [4.2 Matriz completa de pares](#42-matriz-completa-de-pares)
  - [4.3 Las cuatro preguntas que desempatan casi todo](#43-las-cuatro-preguntas-que-desempatan-casi-todo)
- [5. La compuerta del `?`](#5-la-compuerta-del-)
  - [5.1 Qué significa realmente `?`](#51-qué-significa-realmente-)
  - [5.2 El procedimiento de la compuerta](#52-el-procedimiento-de-la-compuerta)
  - [5.3 Qué es una pregunta legítima para el autor](#53-qué-es-una-pregunta-legítima-para-el-autor)
  - [5.4 El hueco de agente no es un `?`](#54-el-hueco-de-agente-no-es-un-)
- [6. Banco de pruebas: los siete casos observados](#6-banco-de-pruebas-los-siete-casos-observados)
- [7. ¿Alcanzan las ocho etiquetas?](#7-alcanzan-las-ocho-etiquetas)
  - [7.1 Veredicto](#71-veredicto)
  - [7.2 Por qué `L` no se agrega, y qué entra en su lugar](#72-por-qué-l-no-se-agrega-y-qué-entra-en-su-lugar)
  - [7.3 Por qué no se agrega ninguna otra](#73-por-qué-no-se-agrega-ninguna-otra)
  - [7.4 Qué no sobra, y por qué `C` estuvo cerca](#74-qué-no-sobra-y-por-qué-c-estuvo-cerca)
  - [7.5 Lo que el paso 3 tiene que absorber](#75-lo-que-el-paso-3-tiene-que-absorber)
- [8. La jerarquía de indicios, generalizada a todo modificador](#8-la-jerarquía-de-indicios-generalizada-a-todo-modificador)
- [9. Hoja de bolsillo](#9-hoja-de-bolsillo)
- [10. Límites declarados](#10-límites-declarados)
- [11. Trazabilidad y control de cambios](#11-trazabilidad-y-control-de-cambios)

---

## 0. Dónde vive este paso

### 0.1 El contrato con el paso 1 y con el paso 3

Cinco pasos. El 2 es el más corto y el más barato, y esa es su virtud, no su defecto.

| Paso | Qué hace | Qué entrega |
| --- | --- | --- |
| 1 | Corta el párrafo en fragmentos, con el criterio de `02-Criterio-De-Segmentacion.md`, **y abre una hoja del referente por cada sustantivo del dominio** | Fragmentos numerados, ninguno superpuesto, sin residuo, **más las hojas abiertas** |
| **2** | **Le pone una etiqueta a cada fragmento, rápido, y deposita lo que el fragmento dice en el casillero que le toca** | **Los mismos fragmentos, cada uno con al menos una letra** —etiquetados con la **lectura fijada**, o con la nota `(abierta)` si el depósito quedó pendiente— **y las hojas con sus depósitos** |
| 3 | **Lee** las hojas y vuelca las etiquetas en las tablas: términos, actos, reglas | Tres tablas con filas, y las filas ya se piensan |
| 4 | Deduce la regla de cada fila candidata | Fichas de regla |
| 5 | Cierra: huecos, preguntas, cobertura | El entregable |

**Lo que el paso 1 garantiza y el paso 2 puede dar por hecho:** residuo cero. P10 del criterio de
segmentación reparte el párrafo entero en **cinco destinos** —afirmación, calificador, glosario,
inventario de actos, inventario de huecos— y no deja ningún tramo sin dueño.

**Lo que el paso 2 recibe no es el párrafo entero:** recibe las **afirmaciones y sus calificadores**,
numeradas con el identificador del paso 1. Y **puede subdividir**: si una afirmación trae adentro dos
cosas que piden letras distintas, se la parte y los pedazos se numeran con el identificador del paso 1
más un sufijo —`02.a.4` sale de `02.a`—. Lo que el paso 2 **nunca hace es descartar**: ningún pedazo
se queda sin letra. Si te parece que un fragmento está mal cortado, lo etiquetás igual, le ponés un
`!` al margen (§2.4) y seguís: el corte se discute en otro momento, no acá.

**Lo que el paso 3 espera del paso 2:** una letra por fragmento, no un análisis. El paso 3 lee la
letra para saber **a qué tabla llevar el fragmento**, y ahí recién lo piensa. Las letras son un
ruteo, no un dictamen.

> **Y una corrección de contrato, que es el cambio de fondo del acta 06.** La **tabla de términos
> deja de llenarse en el paso 3**: se abre en el **paso 1** como hoja del referente —una por cada
> sustantivo del dominio que el párrafo nombre— y **se llena mientras se etiqueta**. El paso 3 la
> **lee**, no la arma.
>
> **Cómo se aplica.** Mientras ponés la letra, escribí también **dónde deposita** el fragmento: el
> casillero de la hoja —género, eje, miembros, momento, agente, alcance, definición— con el número
> del fragmento al lado. **No es un paso más: es la misma pasada, anotando en dos lugares en vez de
> uno.** Si un depósito no cierra con lo que el casillero ya tenía, **queda pendiente en la hoja**;
> no se tira y no se eleva todavía.
>
> **Por qué importa acá.** Es lo que vuelve baratas dos cosas que antes costaban un aparato: el
> conjunto contra el que un modificador recorta se **mira** en un casillero en vez de buscarse, y el
> `?` deja de ser terminal (§5.2).

> **Consecuencia directa, y conviene tenerla presente todo el tiempo:** la etiqueta no tiene que ser
> correcta, tiene que ser **suficientemente correcta como para que el fragmento llegue a una mesa
> donde alguien lo mire**. Una `T` que era `A` llega igual a la tabla de términos, y ahí se ve en dos
> segundos que era un atributo. Una `R` que era `V` llega a la tabla de reglas, y ahí se ve que no se
> puede incumplir.

### 0.2 Notación

Se hereda la del criterio de segmentación (su §0.4) y se agregan las marcas propias del paso 2.
**Ésta es la única tabla de signos del documento**: lo que no está acá, no existe como notación. La
hoja de bolsillo repite esta misma lista y no otra.

| Marca | Significado | Sección |
| --- | --- | --- |
| `T A V C M R E ?` | Las **ocho etiquetas**. Se escriben al margen del fragmento | §3 |
| `T/A` | **Dos etiquetas** sobre el mismo fragmento. No es indecisión: es el resultado esperado de la regla de los cinco segundos | §1.3 |
| `+` | Si escribís `T+A` en vez de `T/A`, es lo mismo. El paso 3 lee las dos formas | §1.3 |
| `°` | **Anillo.** Pospuesto a la letra: este fragmento **no abre fila nueva** en su tabla; es la **segunda mención** de algo que otro fragmento ya registró | §2.1 |
| `⟦ … ⟧` | Material que **puso quien etiqueta**, no la fuente: sujeto tácito, agente, antecedente. **Heredada del paso 1** (`02` §0.4) | §2.2 |
| `⟦?⟧` | Restitución **fallida**: hay un hueco donde debería ir un sujeto o un agente. Es un hallazgo, no una duda de etiquetado | §5.4 |
| `!` | **Aviso sobre el corte.** El fragmento vino gordo o mal delimitado del paso 1. Se escribe al margen, junto a la letra. **No se vuelve al paso 1** | §2.4 |
| `letra(nota)` | **Una nota tuya de hasta tres palabras**, pegada a la letra: `R(estructura)`, `C(describe)`, `?(dos lecturas)`. **Nunca rutea**: la letra manda | §7.3 |
| `A(dominio)` | Nota sobre un `A` cuyo fragmento **declara los valores posibles** de una propiedad en vez de asignar uno: «el casco es permanente o temporal». **Ninguna letra nueva** | §3.2 |
| `(abierta)` | Nota sobre la letra cuando la lectura que la fijó **no cerró**: el fragmento se etiqueta con la lectura elegida y el depósito queda pendiente en la hoja | §5.2 |

`°`, `⟦ ⟧`, `!` y las notas **no reemplazan a la letra: la acompañan.** Un fragmento nunca queda
marcado con `°` solo, ni con una nota sola.

### 0.3 Qué es propio de este documento

Regla de la casa, heredada del hermano: no se cita lo que no se cotejó, y se separa lo propio de lo
recibido.

| Afirmación | Estatuto |
| --- | --- |
| Las ocho etiquetas originales y sus glosas de una línea | **Recibido**: son el artefacto que este documento desarrolla |
| Las definiciones operativas, los bordes y las preguntas de reconocimiento | **Criterio propio** |
| La nota `R(estructura)` y su segunda entrada de reconocimiento (§3.6) | **Propuesta propia** de este documento (§7.2) |
| El inventario de marcas | **Una marca propia (`°`), una propia de aviso (`!`), dos heredadas (`⟦ ⟧`, `?`) y una especialización propia (`⟦?⟧`)**. `⟦ ⟧` viene del paso 1 (`02` §0.4 y P7) |
| La regla de los cinco segundos y la doble etiqueta | **Criterio propio** |
| La compuerta del `?` | **Recibido en su formulación**: el material observado ya dice que «un `?` que un criterio en mano resuelve no es una pregunta para el autor: es un criterio no aplicado». Lo propio es la **formalización**: el procedimiento de tres pasos, la tabla de criterios y la recuenta de cierre |
| La **hoja del referente**, el depósito por casillero y el segundo tramo de la compuerta (§0.1, §5.2, §8) | **Recibido** del acta `../Mesa/06-Acta-Replanteo-Del-Modelo.md`, que a su vez la reconoce como la tabla de términos del paso 3 adelantada al paso 1. Lo propio de este documento es **cuándo se deposita** dentro del paso 2 |
| Los **cuatro cuadrantes** `Q1`–`Q4` y la contraprueba de `Q4` | **Recibido** de `04-Afirmacion-Distribuida-Y-Modificadores.md` §3, folio sellado y no vigente. **La versión que manda es `02` §4.3**, y acá se resume |
| La nota **`A(dominio)`** | **Recibida** de `04` §4. **Ninguna letra nueva**: la letra es `A` |
| El **conjunto de contraste** como indicio (§8) | **Recibido**: está en el material observado con su nombre, su formulación y su aplicación al mismo caso —«un adjetivo restringe solo si existe un conjunto de contraste del cual recortar»—. Lo propio es la **formalización** y el lugar en el orden |
| La **generalización a todo modificador** (§8) | **Recibido**: el material ya la había decidido y fundado. Lo propio es la redacción de la jerarquía y los puntos de entrada |
| Los siete casos del banco de pruebas (§6) | **Observados en uso real**, entregados con el encargo. No son invento de este documento |
| La hoja de bolsillo | **Fuente única** de las ocho glosas de una línea. Si una ficha de §3 y la hoja discrepan, **manda la hoja**, y la ficha se corrige. Ninguna otra parte del documento reescribe las cuatro preguntas de §4.3: las cita |
| Todos los demás ejemplos | **Propios**, inventados para este documento y declarados como tales |

---

## 1. La ley del paso sucio

### 1.1 El enunciado y por qué se sostiene

> **El paso 2 es sucio a propósito. Etiquetar rápido y mal es mejor que etiquetar despacio y bien.**

No es una licencia para ser descuidado: es una consecuencia de cómo se propagan los dos errores
posibles.

| Error | Cuándo se descubre | Qué cuesta arreglarlo |
| --- | --- | --- |
| **Etiqueta equivocada** | En el paso 3, al volcar: el fragmento no entra en las columnas de la tabla a la que lo mandaste | Un renglón. Se mueve de tabla y listo |
| **Fragmento sin etiquetar** | **Nunca** | Todo: el fragmento no llega a ninguna tabla, y nadie lo extraña porque las tablas no saben qué les falta |

La asimetría es total, y es la misma forma de la asimetría que gobierna el paso 1 —donde el error caro
es cortar de más porque la pérdida es silenciosa—. Acá la pérdida silenciosa es el fragmento en blanco.

**Y hay un segundo motivo, menos obvio y más importante:** deliberar en el paso 2 no sirve, porque en
el paso 2 **todavía no tenés la información con la que se decide**. Si dudás entre `T` y `A` para
«encargado», lo que resuelve la duda es ver si «encargado» aparece en otros fragmentos con vida propia
—si alguien lo lista, lo busca o lo da de alta—, y eso lo vas a ver en el paso 3 cuando estén las tres
tablas juntas. Pensar dos minutos ahora no te acerca a la respuesta: sólo te cansa y te hace saltear
fragmentos más adelante, cuando ya estás harto.

> **Criterio de fracaso de este documento**, escrito acá para que se pueda verificar **sin
> cronómetro**: si después de leerlo alguien etiqueta un párrafo y **no puede nombrar, para cada
> fragmento, el único criterio que lo resolvió**, el documento fracasó. No importa cuán buenas hayan
> quedado las etiquetas. *(La versión anterior decía «en más de cinco minutos»: era un número que
> nadie iba a medir, y §10 límite 3 ya declara que nadie cronometra.)*

### 1.2 La regla de los cinco segundos

**Cinco segundos por fragmento.** Se cuentan desde que terminaste de leer el fragmento.

| Lo que pasa a los cinco segundos | Qué escribís |
| --- | --- |
| Tenés una etiqueta clara | Esa. Seguís |
| Tenés **dos** candidatas y no te decidís | **Las dos**, separadas por barra: `T/A`. Seguís |
| Tenés tres o más candidatas | Las **dos más fuertes**. Nunca tres. Seguís |
| No tenés ninguna | Pasás la compuerta del `?` (§5.2), que son tres preguntas. Si sobrevive, `?`. Si no, la etiqueta que la compuerta te dio |
| Te salen **tres** etiquetas, o ves **dos verbos en forma personal** sin nada que los relacione | Las dos etiquetas más fuertes, más un signo `!` al margen (§2.4). **No volvés al paso 1** |

**Por qué cinco y no diez.** Cinco segundos es lo que tarda una lectura del fragmento más una pregunta
de reconocimiento de §3. Alcanza para aplicar **un** criterio. A los diez segundos ya estás aplicando
el segundo criterio, y el segundo criterio casi siempre necesita mirar otro fragmento —o sea, ya no
estás en el paso 2—. **Es una calibración, no una medida** (§10 límite 3).

### 1.3 La doble etiqueta no es una falla: es el mecanismo

`T/V` sobre «la administración de los campos» no es «no me decidí». Es **la anotación correcta**: ese
fragmento efectivamente alimenta dos tablas, la de términos y la de actos, y el paso 3 va a tener que
mirarlo dos veces. La doble etiqueta hace dos cosas a la vez:

1. **Ruteo doble.** El fragmento llega a las dos tablas. Si sobraba en una, ahí se ve y se saca.
2. **Señal de densidad.** Un fragmento con dos etiquetas es un fragmento donde hay más de una cosa
   pasando, y eso es exactamente lo que el paso 3 quiere saber antes de leerlo.

**Techo.** Dos etiquetas por fragmento. Tres significa que el fragmento quedó gordo y eso es un
problema del paso 1, no del 2: se anota `!` y se sigue (§2.4).

**La barra y el más son lo mismo.** `T/A` y `T+A` se leen igual; el paso 3 acepta las dos formas.

**Lo que la doble etiqueta resuelve sin que tengas que saberlo.** Las nominalizaciones —«conformación»,
«administración», «cierre»— son el caso donde la duda entre `T` y `V` es *legítima*, porque la palabra
es gramaticalmente un sustantivo y semánticamente un verbo. No hace falta que reconozcas la
nominalización: la duda de cinco segundos entre `T` y `V` **produce `T/V`, que es la respuesta
correcta**. Un mecanismo que resuelve un caso difícil sin exigir que lo identifiques vale más que una
regla que lo explica.

### 1.4 Cómo se sabe que el paso 2 terminó

Una sola cuenta, y se hace sobre la numeración del paso 1:

> **Recorré los números que te entregó el paso 1, de principio a fin, y contá los que no tienen
> letra. El paso 2 termina cuando ese número es cero.**

**Por qué sobre la numeración del paso 1 y no sobre tus anotaciones.** Porque el único modo de falla
que esta ley teme es **el fragmento salteado**, y un fragmento salteado no está en tus anotaciones:
contar tus anotaciones contra tus anotaciones da siempre lo mismo y no detecta nada. La lista contra
la que se cuenta tiene que ser la que vino de afuera.

No hay lista de control. No hay repaso. No se releen las etiquetas puestas. **Releer para mejorar
etiquetas es trabajo del paso 3 hecho en el lugar equivocado.** La única excepción está escrita y
acotada: la recuenta de los `?` al cerrar (§5.2), que no toca ninguna etiqueta puesta porque un `?`
no es una etiqueta puesta, es una decisión que quedó pendiente.

---

## 2. Las marcas, y por qué no son letras

### 2.1 El anillo `°`: esto no abre fila nueva

**El anillo.** Un signo pospuesto a la letra —`M°`, `T°`— que dice: *esto ya lo nombré; no abre fila
nueva, es la segunda mención de algo que otro fragmento ya registró.*

**Cómo se aplica.** **Buscá la palabra que apunta.** El anillo se pone cuando el fragmento trae una de
éstas y ninguna otra cosa: *el mismo, dicho, ese, esa, tal, ahí, entonces, acto seguido, luego, al
hacerlo* — o repite literal un nombre que ya etiquetaste. Es una palabra a la vista: no hay que
recordar nada ni ir a buscar. Si no hay ninguna de esas palabras, **no hay anillo**.

**Un caso.** En un párrafo de una aerolínea: fragmento 4, «al momento del despacho de equipaje»;
fragmento 9, «en ese mismo momento». El 4 es `M` y abre el momento *despacho de equipaje*. El 9 trae
«ese mismo» → `M°`. Sin el anillo, la tabla de actos termina con dos momentos y el segundo no existe.

**Qué NO es anillo, y es la corrección que esta versión trae:** el **efecto de un acto** —«queda
registrado», «se establece un casco»— **no lleva anillo**. Se etiqueta `V` y listo. La distinción entre
un acto y su efecto **no se hace acá**: el paso 3 arma una sola fila por acto y le acumula los efectos
en la columna «qué cambia». Decidirlo fragmento por fragmento es la clase de deliberación que el
paso 2 no puede pagar.

### 2.2 Los corchetes `⟦ ⟧`: esto lo puse yo

**Los corchetes.** Encierran cualquier palabra que **no está en la fuente** y que quien etiqueta
agregó para que el fragmento se entienda solo: el sujeto tácito, el agente de una pasiva, el
antecedente de un pronombre.

**Cómo se aplica.** Leé el fragmento en voz alta como si fuera la única frase que tenés. Si te falta
saber **de qué o de quién habla**, escribilo entre corchetes adelante y seguí. Si no sabés qué
escribir, escribí `⟦?⟧`. Nunca toques la cita: el fragmento se transcribe con las palabras del autor,
y lo tuyo va entre corchetes al lado, de modo que después se pueda leer la cita sin tu agregado.

**Un caso.** Un enunciado de una obra: «se aprueba el plan de trabajos y se comunica a la
inspección». El segundo fragmento, suelto, dice «se comunica a la inspección» y no se entiende: ¿se
comunica qué? ¿quién comunica? Se anota `V ⟦el jefe de obra?⟧ comunica ⟦el plan aprobado⟧ a la
inspección`, con el `?` adentro del corchete del agente porque el texto no lo dice. La cita que va a
la tabla sigue siendo «se comunica a la inspección», sin contaminar.

**Regla dura, y es la que hace que la marca sirva:** el material entre corchetes **no viaja a la
columna de cita**. Viaja a una columna propia. Una cita con restituciones adentro es una cita
falsificada, y la evidencia se arruina en silencio.

**De dónde vienen los corchetes, y qué agrega el paso 2.** La marca `⟦ ⟧` **no es de acá**: la trae el
paso 1 (`02` §0.4), cuyo P7 ya restituye verbos elididos, sujetos tácitos, **agentes de pasivas e
impersonales con «se»** y antecedentes. Si el paso 1 cumplió, el fragmento **llega con los corchetes
puestos y vos los leés**. Cuando falte uno, lo agregás y ponés `!`: es un aviso sobre el corte, igual
que un fragmento gordo. **Lo propio del paso 2** es la distinción entre `?` y `⟦?⟧` (§5.4) y la tabla
de en qué letras se cobra el hueco.

### 2.3 Por qué una marca cuesta menos que una letra

Es la decisión de diseño de este documento y conviene que esté justificada, porque de ella depende
que el paso 2 siga siendo rápido.

**Una letra más cuesta caro.** La parte lenta del paso 2 no es escribir: es **elegir entre las
opciones disponibles**. El costo de elegir crece con la cantidad de candidatas que hay que descartar,
y esa cantidad es la cantidad de letras. Pasar de ocho a nueve letras encarece **todos** los
fragmentos, incluso los que nunca van a llevar la letra nueva.

**Una marca cuesta barato.** La marca se aplica *después* de haber elegido la letra, y su decisión es
binaria —se pone o no se pone—, sobre una sola pregunta. No compite con nada. El fragmento «en el
mismo acto» se etiqueta `M` en el mismo tiempo que antes; el anillo agrega un trazo y una pregunta de
una pregunta que además **sólo te hacés si el fragmento trae una palabra que apunta**.

| | Letra nueva | Marca nueva |
| --- | --- | --- |
| A qué momento afecta | A la elección: todos los fragmentos | A la anotación: sólo los fragmentos que la llevan |
| Cómo se decide | Comparando contra las otras ocho | Una pregunta de sí o no |
| Qué pasa si se omite | El fragmento va a la tabla equivocada | La fila se duplica o la restitución se pierde: ambas recuperables |

Por eso los casos de **anáfora**, **sujeto tácito** y **agente oculto** se resuelven con marcas y no
con letras nuevas. Y por eso el caso que parecía pedir letra —la **atadura** entre dos cosas del
negocio— se resuelve con una **nota** sobre una letra correcta, `R(estructura)`, y no con una novena
letra (§7.2).

**Y hay un tercer instrumento, más barato todavía: la nota.** Una nota se escribe pegada a la letra,
entre paréntesis, con hasta tres palabras, y **nunca rutea**: el fragmento va a la tabla que la letra
manda, y la nota viaja con él como una columna ya llena. La regla que separa los tres instrumentos
—marca, nota o columna del paso 3— está en §7.3.

### 2.4 El signo `!`: esto vino mal cortado

**`!`** Un aviso al margen: *este fragmento no está bien delimitado, lo etiqueté como pude, y alguien
tiene que mirar el corte.*

**Cómo se aplica.** **Contá.** Si te salen **tres** etiquetas, o si ves **dos verbos en forma personal**
sin nada que los relacione, el fragmento vino gordo: escribí las dos etiquetas más fuertes y un `!` al
margen. No volvés al paso 1.

**Un caso.** «un préstamo corresponde a un único ejemplar» pide atadura, cantidad y regla: tres. Se
anota `R(estructura)/C` y `!`.

**A dónde va, que es lo que faltaba.** Al terminar el paso 2, **copiá la lista de fragmentos con `!` al
pie de la hoja**. Esa lista es lo único que el paso 2 le devuelve al paso 1, y es el único lugar del
procedimiento desde donde se ve que un corte salió mal. Sin la lista, el aviso se pierde en silencio,
que es el error que este documento existe para evitar.

---

## 3. El catálogo, etiqueta por etiqueta

Cada ficha trae lo mismo, en el mismo orden: **definición operativa** —con qué hace quien la aplica—,
**es / no es**, **preguntas de reconocimiento con su razonamiento en voz alta**, **ejemplos
resueltos** de dominios distintos, y **con qué se confunde**.

Las preguntas de reconocimiento son el corazón. No están escritas como reglas sino como el
pensamiento de alguien que está decidiendo, porque lo que hay que transmitir no es la respuesta sino
**cómo se llega a la respuesta cuando el caso no es el del manual**.

---

### 3.1 `T` — término

> **Término.** Un fragmento es `T` cuando nombra una cosa del negocio de la que después vas a poder
> decir cuántas hay.

**Cómo se aplica.** **Contá.** Poné un número adelante de la palabra y preguntate si la frase que
sale tiene sentido en el negocio: *tres préstamos*, *diecisiete parcelas*, *cuatro sucursales*. Si se
puede contar y el negocio lleva la cuenta, es `T`. Después **buscá el dueño**: preguntate «¿de qué es
esto?». Si la pregunta tiene una respuesta obligatoria —*el saldo es de una cuenta*, siempre—,
retrocedé: es `A`, no `T`.

**Un caso.** En una biblioteca: «el ejemplar» y «el estado de conservación». *Tres ejemplares* tiene
sentido y la biblioteca los cuenta → `T`. *Tres estados de conservación* tiene sentido como lista de
valores posibles, pero «¿de qué es el estado de conservación?» tiene respuesta obligatoria —de un
ejemplar— → `A`.

#### Es / no es

| **Es `T`** | **No es `T`** |
| --- | --- |
| Un sustantivo del negocio que se puede listar: *sucursal, expediente, turno, vuelo* | Una propiedad que siempre es *de* algo: *el saldo, la matrícula, el peso* → `A` |
| Un rol, si el negocio lo trata como cosa que se da de alta: *el Administrador*, *el inspector* | Un rol mencionado sólo para decir que alguien está atado a otra cosa → `R(estructura)`, y el rol llega igual a la tabla de términos (§3.6) |
| Una palabra que el texto **define**: «se entiende por parcela…» | Una palabra que el texto usa como sinónimo de otra ya nombrada → `T°` |
| Un sustantivo deverbal, **también**: *la conformación* es a la vez cosa nombrada y acto → `T/V` | Un sustantivo que sólo aparece dentro de una fecha o un plazo: *el cierre del ejercicio* en «al cierre del ejercicio» → `M` |

#### Preguntas de reconocimiento

**«¿Puedo contar esto?»**
Si me contesto que sí, voy a `T` — pero ojo, porque *tres colores de carpeta* también se cuenta y no
es un término del negocio: es el conjunto de valores de un atributo. El desempate es la segunda
pregunta.

**«¿De qué es?»**
Si la pregunta suena rara —«¿de qué es el expediente?»—, es `T`: la cosa existe por sí. Si la
pregunta tiene una respuesta forzosa —«¿de qué es la matrícula?», de un vehículo, siempre—, es `A`.
Y ojo con el caso intermedio, que es el que arruina modelos: «¿de qué es la dirección?» parece tener
respuesta forzosa —de un cliente—, pero si el negocio guarda direcciones que después reusa, corrige y
lista, entonces la dirección tiene vida propia y es `T`. **Cuando la duda cae ahí, `T/A` y seguís**:
el paso 3 tiene a la vista si alguien lista direcciones.

**«¿Aparece este mismo nombre en otro fragmento que ya etiqueté?»**
Si me contesto que sí y allá ya puse `T`, acá va `T°`: es la segunda mención, no un término nuevo. Y
ojo con los casi-sinónimos: «el personal de la estancia» y «el encargado» no son el mismo término,
aunque en el párrafo parezcan lo mismo. **Ante casi-sinónimos no se pone anillo**, se ponen los dos
como `T` y que el paso 3 decida si fusiona.

#### Ejemplos resueltos

| Dominio | Fragmento | Etiqueta | Por qué |
| --- | --- | --- | --- |
| Banco | «una caja de ahorro» | `T` | *Cuatro cajas de ahorro* tiene sentido y el banco las cuenta. «¿De qué es una caja de ahorro?» suena rara: vida propia |
| Banco | «el saldo disponible» | `A` | Se cuenta mal —*tres saldos disponibles* sólo tiene sentido si ya pensaste en tres cuentas— y «¿de qué es?» contesta *de una cuenta*, siempre |
| Biblioteca | «el socio» | `T` | Rol que la biblioteca da de alta, lista y busca. Es cosa, aunque sea persona |
| Obra | «el pliego de especificaciones técnicas» | `T` | Documento contable y listable. El adjetivo largo no cambia nada: es un nombre compuesto |
| Hospital | «la historia clínica» | `T` | Se cuenta, se lista, se busca por sí sola. Que siempre sea *de un paciente* no la degrada a `A`: el hospital la trata como objeto |
| Municipio | «el trámite de habilitación» | `T/V` | *Cinco trámites de habilitación* se cuenta → `T`. Pero «trámite» esconde *tramitar* y «habilitación» esconde *habilitar* → también `V`. Dos etiquetas, cinco segundos, se sigue |

#### Con qué se confunde

- **Contra `A`** → §4.1, es la confusión número uno.
- **Contra `V`** → toda nominalización. Se resuelve solo con `T/V` (§1.3).
- **Contra `R(estructura)`** → «a cargo de un Administrador» nombra un término *y* lo ata a otro. El
  criterio: si el fragmento **sin la locución no dice nada**, el peso está en la atadura, no en el
  nombre. «un Administrador» solo es `T`; «a cargo de un Administrador» es `R(estructura)`, y el
  Administrador llega a la tabla de términos igual, por el fragmento vecino que lo nombra.

---

### 3.2 `A` — atributo

> **Atributo.** Un fragmento es `A` cuando dice un dato que una cosa lleva encima, y que podés pedirle
> a esa cosa sin pedirle nada a ninguna otra.

**Cómo se aplica.** **Preguntale a la cosa.** Armá la frase «¿cuál es el ‹fragmento› de ‹la cosa›?».
Si la frase corre y la respuesta es un valor —un número, un texto, una fecha, una opción de una
lista—, es `A`. Después **intentá violarlo**: describí a alguien intentando hacer algo que el
atributo prohíba. Si no se te ocurre nada que prohibir, sigue siendo `A`; si se te ocurre, mirá `R`.

**Un caso.** En una obra: «cada frente de trabajo tiene un responsable designado» y «el responsable
designado no puede estar en dos frentes a la vez». El primero: «¿cuál es el responsable del frente
tres?» corre, la respuesta es un nombre, y no hay nada que rechazar → `A`. El segundo: se puede
describir a alguien cargando al mismo capataz en dos frentes y el sistema rechazándolo → `R`.

#### Es / no es

| **Es `A`** | **No es `A`** |
| --- | --- |
| Un dato con valor: *nombre, superficie, fecha de ingreso, categoría* | Una cosa con la que otras cosas se relacionan → `T` |
| Un adjetivo que **no recorta y sin embargo predica** —cuadrante `Q3`—: «la cámara **frigorífica**» (§8) | Un adjetivo que **recorta** sobre el género de la hoja —`Q1` o `Q2`—: «un casco **central**», «los lotes **mayores a 200 ha**» → `R` o calificador de alcance |
| Una unidad declarada: «superficie en hectáreas» | Un vínculo con otra cosa del negocio: «asignada a una parcela» → `R(estructura)` |
| Un dato que el negocio guarda aunque nadie lo controle | Un dato que el negocio **exige** que cumpla algo → `A/R` |
| Un fragmento que **declara los valores posibles** de una propiedad: «el casco es permanente o temporal» → `A(dominio)` | Un fragmento que **asigna** un valor a un referente: «el casco es central» → cuadrante, §8 |

#### Preguntas de reconocimiento

**«¿Esto tiene un valor, o tiene identidad?»**
Si lo que hay del otro lado es un número, un texto o una fecha, es `A`. Si lo que hay del otro lado es
**un sustantivo del negocio** —no un número, ni una fecha, ni un texto libre—, no es `A`: es
`R(estructura)` (§3.6). La trampa está en los nombres propios: «el titular es Juan Pérez» parece un
valor —un texto— pero *titular* es un sustantivo del negocio. **Y no te preguntes si «tendría ficha
propia»**: eso se ve en el paso 3 con las tres tablas a la vista, no acá.

**«¿Se puede incumplir?»**
Si me contesto que no —tener un nombre no se incumple, se tiene o falta—, es `A` limpio. Pero ojo,
porque casi todo atributo trae una regla pegada y a veces en el mismo fragmento: «un identificador
que debe ser único» es `A` —hay identificador— **y** `R` —la unicidad se puede violar—. Las dos
etiquetas, y seguís. Si me contesto que sí y el atributo ya estaba nombrado en otro fragmento, va
`R` sola.

**«¿Este adjetivo agrega o separa?» — y son dos preguntas, no una.**
*¿Separa?* Se mira el casillero **«eje»** de la hoja del referente: si hay eje depositado, el adjetivo
recorta, y recorta sobre el **género** de la hoja, no sobre el núcleo. «La cámara **frigorífica**», con
una sola cámara y ningún otro equipo en el enunciado, no recorta. «Los socios **morosos**», con el
socio al día tratado distinto, sí. *¿Agrega?* Es depósito nuevo o no lo es, y para decir que no hay que
**señalar el depósito anterior**. `Q3 → A`; `Q1 → R` o `R/A`; `Q2 → R°`; `Q4 → T°`. Ver §8.

#### Ejemplos resueltos

| Dominio | Fragmento | Etiqueta | Por qué |
| --- | --- | --- | --- |
| Obra | «una superficie determinada, en metros cuadrados» | `A` | «¿Cuál es la superficie del local?» corre, la respuesta es un número con unidad, no hay nada que rechazar |
| Hospital | «el número de afiliado» | `A` | Valor, no cosa con ficha. Salvo que el hospital administre afiliaciones, en cuyo caso alguien lo va a ver en el paso 3 |
| Hospital | «el médico de cabecera» | `R(estructura)` | Parece atributo del paciente, pero del otro lado hay un sustantivo del negocio. Es una atadura, y la nota dice de qué clase |
| Aerolínea | «un vuelo de cabotaje» | `A` | Sin eje en la hoja, `Q3` → `A`. **Salvo** que el texto hable también de vuelos internacionales: ahí se deposita el eje *alcance del trayecto* y el adjetivo pasa a `Q1` → `A/R`. El casillero decide |
| Obra | «el casco **es permanente o temporal**» | `A(dominio)` | No asigna un valor: **declara los valores posibles**. Deposita en «eje» un eje con exhaustividad declarada, y arrastra las tres afirmaciones de `02` §3.9 |
| Escuela | «la condición de regular» | `A/R` | Es un dato del alumno → `A`, y es un estado que se gana o se pierde según condiciones → `R`. Dos etiquetas en cinco segundos |
| Taller | «la patente del vehículo» | `A` | Valor. Que sea única es otra cosa, y si el texto lo dice, ese fragmento será `R` |

#### Con qué se confunde

- **Contra `T`** → §4.1.
- **Contra `R`** → §4.1. Es la segunda más cara.
- **Contra `R(estructura)`** → la pregunta es qué hay del otro lado de la locución: un valor o un
  sustantivo del negocio.
- **Contra `C`** → «una superficie» es `A`; «al menos una» es `C`. El artículo indefinido solo no es
  cardinalidad; el cuantificador sí.

---

### 3.3 `V` — acto

> **Acto.** Un fragmento es `V` cuando alguien del negocio hace algo, en un momento, y ese algo puede
> salir mal.

**Cómo se aplica.** **Buscá al que lo hace.** Preguntá «¿quién?» y escribí la respuesta, aunque sea
`⟦?⟧`. Después **imaginá que sale mal**: describí el intento fallido —el que lo hace, empieza, y no
puede—. Si podés describirlo, es `V`. Si no hay nadie que lo haga y no hay forma de que falle, mirá
si el fragmento contesta «¿cuándo?» —entonces es `M`— o si afirma algo que se puede rechazar
—entonces es `R`—.

**Un caso.** En un municipio: «se otorga la habilitación comercial». ¿Quién? La oficina de comercio,
que el texto no nombra → `⟦?⟧`. ¿Puede salir mal? Sí: el inspector va a otorgarla y falta el
certificado de bomberos. → `V ⟦?⟧ otorga la habilitación`, con el hueco de agente anotado. Contra:
«queda habilitado el local», que es el efecto de la anterior: **también se etiqueta `V`**, y la
fusión la hace el paso 3 acumulando efectos en la fila del acto (§2.1).

#### Es / no es

| **Es `V`** | **No es `V`** |
| --- | --- |
| Una acción con actor, aunque el actor esté oculto: «se emite el remito» | Algo que *pasa* sin que nadie lo haga: «el plazo vence», «la condición se pierde» → `R` |
| El **efecto** de una acción ya nombrada: «queda emitido», «se establece un casco» → **también `V`**, y el paso 3 lo acumula en la fila del acto | Un verbo de estado: *es, tiene, consta de, se compone de* → `A`, `R(estructura)` o `R` |
| Un sustantivo deverbal que nombra la acción: «la conformación» → `T/V` | Ese mismo sustantivo cuando **ubica en el tiempo**: «en el momento de la conformación» → `M` |
| Una acción prohibida o permitida: «no se puede reasignar una parcela ocupada» → `V/R` | Un verbo del **sistema** y no del negocio: «el sistema deberá permitir» → marco, no acto |

#### Preguntas de reconocimiento

**«¿Quién lo hace?»**
Si tengo un sujeto, `V` sin más. Si no lo tengo —«se establece», «se contempla», «se aprueba»—, sigue
siendo `V`, y el que falta **se anota `⟦?⟧` y es un hallazgo**, no una duda. Pero ojo, porque a veces
la respuesta honesta es «nadie»: si el fragmento describe algo que *pasa* en vez de algo que
*alguien hace* —«el plazo vence», «la condición se pierde»—, no es un acto: es la consecuencia de una
regla, y va `R`.

**«¿Puede fallar?»**
Si puedo contar la escena del intento frustrado, **es acto**, y con eso alcanza: `V`. Si no puedo
—«queda establecido el casco»: ¿cómo fallaría eso, si ya está dicho que el otro acto lo produjo?—,
estoy mirando el **efecto** de un acto, y el efecto **se etiqueta `V` igual**. La pregunta sirve para
confirmar que hay acto, no para decidir acto contra efecto: esa distinción **no se hace en el paso 2**
y la hace el paso 3, que arma una sola fila por acto y le acumula los efectos en la columna «qué
cambia». Decidirla fragmento por fragmento es deliberación, y el paso 2 no la paga.

**«¿Este acto ya lo anoté?»**
Si el fragmento dice «en el mismo acto», «acto seguido», «al hacerlo», está **señalando** un acto, no
nombrando uno. Eso no es `V`: es `M°`. El error de etiquetar `V` acá es el más caro de los que
produce esta letra, porque mete en la tabla de actos una fila que no tiene ni actor ni forma de
fallar, y alguien más adelante va a intentar implementarla.

#### Ejemplos resueltos

| Dominio | Fragmento | Etiqueta | Por qué |
| --- | --- | --- | --- |
| Aerolínea | «el pasajero despacha su equipaje» | `V` | Actor explícito; el intento fallido se cuenta solo —excede el peso y no puede— |
| Aerolínea | «el equipaje queda registrado» | `V` | Es el efecto del despacho. **No lleva anillo:** el paso 3 lo acumula en la columna «qué cambia» de la fila del despacho, sin duplicar el acto |
| Municipio | «se dispone el archivo del expediente» | `V ⟦?⟧` | Acción con actor oculto. El hueco de agente es hallazgo, y acá es caro: alguien va a tener que poder archivar |
| Biblioteca | «la devolución del ejemplar» | `T/V` | Sustantivo deverbal suelto: nombra una cosa contable y esconde *devolver*. Dos etiquetas |
| Biblioteca | «al momento de la devolución» | `M` | El mismo sustantivo, pero acá ubica en el tiempo. No es acto: **contesta «¿cuándo?»** |
| Taller | «el turno se cancela automáticamente» | `V/R` | Hay acción, pero «automáticamente» dice que no la hace una persona: es una regla que dispara un acto. Dos etiquetas y que el paso 3 lo parta |

#### Con qué se confunde

- **Contra `M`** → §4.1. Es la tercera más cara, y la que produjo dos de los siete casos observados.
- **Contra `T`** → nominalizaciones, resueltas con `T/V`.
- **Contra `R`** → un acto que se describe sólo para decir que está prohibido es regla: «no se
  eliminan parcelas con actividad asignada» es `R`, no `V`. El criterio: **si el fragmento existe
  para decir que algo no se puede, es `R`.**

---

### 3.4 `C` — cardinalidad

> **Cardinalidad.** Un fragmento es `C` cuando dice **cuántos**, y el número o el cuantificador es lo
> que el fragmento aporta.

**Cómo se aplica.** **Subrayá el cuantificador** —un, uno, al menos, a lo sumo, único, varios, cada,
todo, ninguno, hasta, no más de— y preguntate qué pasa si lo cambiás por otro. Si cambiar «al menos
uno» por «al menos dos» cambia lo que el negocio acepta, es `C`. Después **preguntá si obliga**: ¿el
número es una exigencia o una descripción de lo habitual? Escribí la respuesta al lado, porque es lo
que el paso 3 no va a poder reconstruir.

**Un caso.** En una escuela: «cada división tiene un preceptor» y «las divisiones suelen tener entre
veinticinco y treinta alumnos». En el primero, cambiar «un» por «dos» cambia lo que el sistema acepta
→ `C` exigible. En el segundo, cambiar los números no cambia nada que alguien vaya a rechazar: es
descripción → `C(describe)`, y anotarlo así evita que aparezca una validación que nadie pidió.

#### Es / no es

| **Es `C`** | **No es `C`** |
| --- | --- |
| Cuantificadores: *al menos, a lo sumo, exactamente, único, ninguno, varios* | Un artículo indefinido que sólo introduce: «tiene **un** nombre» → `A` |
| Un número con unidad **cuando lo que importa es el número**: «no más de tres reservas activas» | Un número que es un valor del dato: «treinta días de plazo» → `A` o `M` |
| «único dentro de ‹ámbito›»: cardinalidad más ámbito | «único» como adjetivo de estilo: «el único responsable» cuando no delimita nada → `A` |
| «cada», «todo», cuando distribuyen sobre una colección | «cada» como muletilla enumerativa: «cada uno de los siguientes puntos» → nada, es prosa de armazón |

#### Preguntas de reconocimiento

**«¿Si cambio el número, cambia lo que el negocio acepta?»**
Si me contesto que sí, es `C`. Si me contesto que no, probablemente el número sea un valor y esté
mirando un `A`. Ojo con el cero, que es el número que nadie escribe: «puede no tener parcelas» es
cardinalidad —el mínimo es cero— aunque no haya dígito a la vista.

**«¿Esto obliga o describe?»**
Es la pregunta más rentable de esta letra y la que menos se hace. «Al menos un campo» obliga: hay un
mínimo que alguien va a verificar. «Varios puestos rurales» describe el establecimiento típico y no
obliga a nada; si se lo toma como exigencia, aparece una validación de cantidad mínima que el negocio
nunca pidió. **El indicio más confiable es lo que el propio texto hace después**: si más adelante
declara que eso no se administra, el número era descripción. Cuando no puedo decidirlo en cinco
segundos, escribo la nota `C(dudoso)` pegada a la letra, que no es la etiqueta `?` sino una nota
adentro de la etiqueta y **no rutea**: el fragmento va igual a la tabla que `C` manda (§0.2).

**«¿Dentro de qué?»**
Si el fragmento dice «único», la cardinalidad está incompleta sin el ámbito: único **dentro de qué**.
Si el texto lo dice —«único dentro del contexto administrativo de la estancia»—, se copia. Si no lo
dice, se anota `C(sin ámbito)`, que es un hallazgo caro: la unicidad sin ámbito es la fuente clásica
de un índice mal puesto.

#### Ejemplos resueltos

| Dominio | Fragmento | Etiqueta | Por qué |
| --- | --- | --- | --- |
| Biblioteca | «hasta tres ejemplares por socio» | `C` | Cambiar el tres cambia lo que se acepta. Trae ámbito: *por socio* |
| Hospital | «al menos un acompañante mayor de edad» | `C/A` | El «al menos uno» es cardinalidad; «mayor de edad» es atributo del acompañante |
| Escuela | «un único legajo por alumno» | `C` | Unicidad con ámbito explícito |
| Escuela | «suelen inscribirse unos doscientos alumnos» | `C(describe)` | «Suelen» delata la descripción. No hay nada que verificar |
| Aerolínea | «ninguna reserva sin pasajero asociado» | `C/R` | Cardinalidad mínima uno, y se puede intentar violar → también regla |
| Obra | «los treinta días corridos del plazo de obra» | `M` | Número, pero no dice cuántas cosas hay: ubica en el tiempo |

#### Con qué se confunde

- **Contra `R`** → §4.1. Toda cardinalidad exigible **va a terminar siendo** una regla; la diferencia
  es de momento, no de naturaleza. Ver §7.4.
- **Contra `A`** → si el número es el valor del dato, es `A`; si dice cuántas cosas hay, es `C`.
- **Contra `R(estructura)`** → casi siempre juntas: la atadura y su cantidad vienen en el mismo
  fragmento, y la anotación completa es `R(estructura)/C`.

---

### 3.5 `M` — momento

> **Momento.** Un fragmento es `M` cuando contesta «¿cuándo?» y no agrega nada más.

**Cómo se aplica.** **Sacalo y leé lo que queda.** Si al quitar el fragmento la frase sigue diciendo
lo mismo pero deja de saberse cuándo pasa, es `M`. Después **fijate si adentro hay un acto**: si el
núcleo es un sustantivo de acción —*la conformación, el cierre, la recepción*— o un infinitivo —*al
recibir*—, el acto se anota aparte, pero **el fragmento sigue siendo `M`**.

**Un caso.** En un taller: «al retirar el vehículo, se entrega el comprobante de garantía». Quito «al
retirar el vehículo» y queda «se entrega el comprobante de garantía», que dice lo mismo sin el
cuándo → `M`. Y adentro hay *retirar el vehículo*, que es un acto del negocio: se anota en la tabla de
actos, **una sola vez**, y el fragmento queda `M`.

#### Es / no es

| **Es `M`** | **No es `M`** |
| --- | --- |
| *al, cuando, luego de, antes de, en el acto de, al cierre, mientras, hasta que* | Una condición que puede no cumplirse: «si el saldo alcanza» → `R` |
| Fechas y plazos: «el 30 de junio», «dentro de las 48 horas» | Un plazo con consecuencia: «vencidas las 48 horas la reserva cae» → `M/R` |
| Una referencia a un momento **ya nombrado**: «en el mismo acto» → `M°` | Ese mismo acto cuando se lo nombra **por primera vez** → `V` |
| Un orden entre actos: «una vez aprobado, se comunica» | Una causa: «porque venció el plazo» → calificador de causa, no momento |

#### Preguntas de reconocimiento

**«¿Contesta cuándo?»**
Si me contesto que sí, `M`, y ya está: no importa que adentro haya un sustantivo que parezca cosa ni
un verbo que parezca acto. **La función manda sobre la forma.** Éste es el punto donde se cometió uno
de los errores observados: «en el mismo acto» tiene la palabra *acto* adentro y se etiquetó `V`; pero
contesta «cuándo», así que es `M`.

**«¿El momento que nombra ya está en alguna parte?»**
Si el fragmento usa un demostrativo —«ese», «el mismo», «dicho»— o un adverbio de retorno
—«entonces», «acto seguido»—, está apuntando, no nombrando: `M°`. Si me contesto que el momento
aparece por primera vez y lleva adentro un sustantivo de acción, entonces **pasan dos cosas a la
vez**: el fragmento es `M` y el acto que nombra entra a la tabla de actos. No son dos etiquetas: es
una etiqueta y un registro. Lo anoto `M →acto: conformar` y sigo.

**«¿Esto siempre pasa, o puede no pasar?»**
Si siempre pasa y lo único que se dice es *cuándo*, es `M`. Si puede no pasar, y de eso depende que
algo se haga o no, es condición y la condición es regla: `R`. La frontera está en «cuando»: «cuando
se registra el ingreso» es momento; «cuando el saldo es insuficiente» es condición. **El desempate:
¿el fragmento describe un instante de la línea de tiempo, o un estado del mundo que puede ser falso?**

#### Ejemplos resueltos

| Dominio | Fragmento | Etiqueta | Por qué |
| --- | --- | --- | --- |
| Banco | «al cierre del día hábil» | `M` | Contesta cuándo; «cierre» nombra además un acto que se registra aparte |
| Banco | «en esa misma operación» | `M°` | Demostrativo: apunta a un momento ya nombrado |
| Hospital | «antes del alta médica» | `M` | Ubica en el tiempo respecto de un acto; el acto *dar el alta* se registra una vez |
| Municipio | «dentro de los diez días hábiles de notificado» | `M` | Plazo con punto de partida. Si el texto dijera qué pasa al vencer, sería `M/R` |
| Aerolínea | «mientras el vuelo esté en estado programado» | `M/R` | Ubica en el tiempo **y** es un estado que puede ser falso: hay algo que rechazar |
| Obra | «una vez aprobada la certificación» | `M` | Orden entre actos. *Aprobar la certificación* va a la tabla de actos, una vez |

#### Con qué se confunde

- **Contra `V`** → §4.1. La confusión que más ensucia la tabla de actos.
- **Contra `R`** → momento contra condición. Criterio: instante de la línea de tiempo contra estado
  que puede ser falso.

---

### 3.6 `R` — candidata a regla

> **Candidata a regla.** Un fragmento es `R` cuando podés contar la escena de alguien intentando algo
> y el negocio diciéndole que no.

**Cómo se aplica.** **Contá el rechazo.** En voz alta, en una oración: *«Fulano quiere ‹algo› y el
sistema no lo deja porque ‹el fragmento›»*. Si la oración sale, es `R`. Si no sale —si lo mejor que
podés decir es «entonces el sistema muestra el dato» o «entonces así es»—, mirá la segunda entrada
de abajo: si hay una locución que ata, es `R(estructura)`; si no, es `A` o un cálculo.

**Un caso.** En una biblioteca: «un socio con multa impaga no puede retirar ejemplares». *La socia
González quiere llevarse un libro y el mostrador no la deja porque tiene una multa impaga.* La
oración sale sola → `R`. Contra: «la multa se calcula a razón de cien pesos por día de atraso». No
hay nadie a quien decirle que no; es una fórmula. Va a la tabla de reglas igual, pero como derivación,
y quien etiqueta no necesita saber eso: pone `R` y el paso 4 lo clasifica.

**Y la segunda entrada, para cuando el rechazo no se cuenta.** **Subrayá la locución que ata**:
*a cargo de, a nombre de, perteneciente a, asignado a, dependiente de, bajo la dirección de,
provisto por, está compuesta por, consta de, contiene, agrupa*. Si hay una de ésas y del otro
lado hay **un sustantivo** —no un número, ni una fecha, ni un texto libre—, escribí
`R(estructura)`. **No te preguntes si ese sustantivo «tendría ficha propia»**: eso se ve en el
paso 3 con las tres tablas a la vista, no acá.

**Un caso.** «a cargo de un Administrador». Locución: *a cargo de*; del otro lado, *Administrador*,
sustantivo. → `R(estructura)/C`. En el paso 3 la fila entra a la tabla de reglas con la especie ya
escrita, y el paso 4 no le corre el análisis completo: ya sabe que es estructura, no prohibición.
Contra: «una cuenta con saldo en pesos» —del otro lado hay un valor— → `A`.

**Qué no entra en la lista.** *dentro de, en, donde* ubican o dan ámbito, no atan: «único dentro
del contexto administrativo» es el ámbito de una `C`, no una atadura.

#### Es / no es

| **Es `R`** | **No es `R`** |
| --- | --- |
| Toda perífrasis de obligación, prohibición o permiso: *debe, no puede, está obligado a, sólo podrá* | Un dato que la cosa tiene y nadie controla → `A` |
| Una condición de la que depende que algo se haga o no | Un momento en el que algo se hace → `M` |
| Una unicidad, un mínimo o un máximo exigibles | Un número que es el **valor** del dato: «treinta días de plazo» → `A` |
| Una **atadura** entre dos cosas del negocio, aunque no puedas contar el rechazo: va a la misma tabla con la nota `(estructura)` | Una relación con un **valor** y no con otra cosa del negocio → `A` |
| Un cálculo o una fórmula: se vuelca a la misma tabla | Una función que el enunciado declara fuera → `E` |
| Una coherencia exigida entre dos datos: «la suma debe ser coherente con el total» | Una descripción de lo típico: «suelen ser varios» → `C(describe)` |

#### Preguntas de reconocimiento

**«¿Puedo contar el rechazo?»**
Es la prueba entera y casi nunca falla. Si me contesto que sí, `R` y sigo. Si me contesto que no
—pero igual me suena a regla—, la pregunta de control es **qué clase de cosa es**: un cálculo no se
puede violar y aun así va a la tabla de reglas; una descripción de cómo se compone algo tampoco se
viola y **no** va. La diferencia: el cálculo produce un valor que puede estar mal; la composición no
produce nada.

**«¿El texto dice "debe", "no puede", "sólo", "únicamente", "salvo"?»**
Si me contesto que sí, `R` sin pensar más: esas palabras son el mejor detector de reglas que tiene un
texto de negocio. Pero ojo con el «debe» que no obliga a nadie —«el expediente debe estar completo»—:
es `R` igual, y lo que falta es **quién** debe, que se anota `⟦?⟧`. No es motivo de duda de etiqueta.

**«¿Esto ya está dicho en otro fragmento, con otras palabras?»**
Si me contesto que sí, sigue siendo `R`, no `R°`: **el anillo no se usa en reglas.** Dos formulaciones
distintas de lo que parece la misma regla son un hallazgo valioso —o son dos reglas distintas que se
parecen—, y esa decisión es del paso 4. Mandar las dos es lo correcto.

**«¿Estoy poniendo `R` porque es regla, o porque no encontré otra letra?»**
Ésta es una pregunta de higiene y conviene hacérsela una vez cada tanto, no en cada fragmento. `R` es
el depósito natural del paso 2: cualquier cosa que afirme algo y no encaje termina ahí. Si la respuesta
es «porque no encontré otra», fijate primero si hay una **locución que ata** —ahí va
`R(estructura)`, que es la misma letra con la especie escrita— y después mirá `E`.

#### Ejemplos resueltos

| Dominio | Fragmento | Etiqueta | Por qué |
| --- | --- | --- | --- |
| Biblioteca | «no se prestan ejemplares de la sala de referencia» | `R` | El rechazo se cuenta solo |
| Aerolínea | «el check-in cierra cuarenta minutos antes del despegue» | `M/R` | Ubica en el tiempo y define un rechazo: llegás a los treinta y no entrás |
| Banco | «la transferencia no puede superar el límite diario» | `R` | Prohibición explícita, escena de rechazo inmediata |
| Banco | «el interés se calcula sobre el saldo promedio» | `R` | Nadie es rechazado, pero es una derivación y va a la misma tabla |
| Obra | «la certificación debe estar firmada por el director técnico» | `R` | El rechazo se cuenta —llega sin firma y no se acepta—, así que la primera entrada manda y la nota no hace falta |
| Hospital | «la cantidad de camas ocupadas no puede exceder la capacidad del sector» | `R/C` | Rechazo contable |

#### Con qué se confunde

- **Contra `A`** → §4.1. La prueba del rechazo lo resuelve casi siempre.
- **Contra `C`** → §4.1 y §7.4.
- **Contra `R(estructura)`** → no es contra: es la misma letra. ¿Podés contar el rechazo? `R` sola.
  ¿No, y hay una locución que ata? `R(estructura)`.
- **Contra `E`** → lo de adentro contra lo de afuera: `R` dice qué tiene que valer; `E` dice que eso
  ni siquiera se va a hacer.

---

### 3.7 `E` — alcance

> **Alcance.** Un fragmento es `E` cuando el texto avisa que algo **no se va a hacer**, y por lo tanto
> que nadie va a poder rechazarlo ni construirlo.

**Cómo se aplica.** **Buscá la función que desaparece.** Preguntate: ¿qué cosa quedaría sin
construirse si tomo este fragmento en serio? Si podés nombrarla —*dar de baja campos*, *administrar
los puestos*—, es `E`. Después **anotá qué queda huérfano**: si en otro fragmento hay un término o una
atadura que sólo existía para eso, marcalo, porque es lo que después aparece como código muerto.

**Un caso.** En un municipio: «la gestión de las tasas municipales excede el presente sistema». La
función que desaparece es *liquidar tasas* → `E`. Y queda huérfano el término *tasa*, que el párrafo
anterior nombró: eso se anota, porque si nadie lo ve, alguien va a modelar una tabla de tasas que
nada usa.

#### Es / no es

| **Es `E`** | **No es `E`** |
| --- | --- |
| *queda fuera del alcance, se contempla en un futuro análisis, no forma parte de, excede este sistema, por ahora no* | Una prohibición del negocio: «no se pueden eliminar» → `R` |
| *sólo* cuando limita la función: «la administración consiste **solo** en el alta» | *sólo* cuando limita un valor: «sólo mayores de edad» → `R` |
| Una mención de algo que existe en la realidad pero que el sistema no toca | Un dato que no se guarda pero sí se usa → `A` con hallazgo |
| Un «se verá más adelante» aunque suene informal | Una aclaración didáctica: «para este ejercicio se toma…» → es una simplificación, va `R` con nota |

#### Preguntas de reconocimiento

**«¿Esto saca trabajo o agrega trabajo?»**
Si al leerlo hay **menos** para construir, es `E`. Si hay más —una validación, un cálculo, un
campo—, no es `E`. Es la pregunta más rápida de todo el catálogo y casi nunca se equivoca.

**«¿Hay alguien a quien decirle que no?»**
Si me contesto que sí, es `R`, no `E`. La diferencia se ve mejor con dos frases casi iguales: «no se
dan de baja los campos» es `R` —alguien intenta y se le rechaza—; «la baja de los campos se contempla
en un futuro análisis» es `E` —no hay a quién rechazar, porque la pantalla no existe—. **El texto
frecuentemente elige la segunda forma para decir la primera, y distinguirlas es justamente lo que hay
que dejar registrado.** Cuando dudo, `E/R` y sigo.

**«¿Qué queda sin dueño si esto es verdad?»**
No cambia la etiqueta, pero es la pregunta que hace valiosa a `E`. Si el fragmento excluye la
administración de los puestos y otro fragmento dice que cada puesto tiene un encargado, entonces el
encargado no tiene por dónde cargarse. Se anota al margen y se sigue: **esa observación de tres
segundos es la que evita el modelado de algo que nadie va a usar.**

#### Ejemplos resueltos

| Dominio | Fragmento | Etiqueta | Por qué |
| --- | --- | --- | --- |
| Municipio | «la integración con el sistema de rentas queda para una etapa posterior» | `E` | Saca trabajo; no hay a quién rechazar |
| Obra | «el control de stock de materiales no forma parte de este desarrollo» | `E` | Idem. Queda huérfano el término *material*, si otro fragmento lo nombró |
| Hospital | «la facturación a obras sociales se analizará más adelante» | `E` | Fórmula típica del diferimiento |
| Hospital | «no se admiten internaciones sin orden médica» | `R` | Hay rechazo: es prohibición, no exclusión |
| Escuela | «la administración se limita al alta y la consulta» | `E` | El «se limita a» excluye modificación y baja. Saca trabajo |
| Banco | «para este ejercicio se toma una única moneda» | `R` | Simplificación del enunciado, no exclusión: hay algo que sí hay que construir, con una restricción |

#### Con qué se confunde

- **Contra `R`** → la pregunta del rechazo, y ante duda `E/R`.
- **Contra `?`** → nunca: `E` es de las etiquetas más fáciles de reconocer, porque tiene fórmulas
  fijas de superficie. Si el fragmento trae una de esas fórmulas, no hay duda que elevar.

---

### 3.8 `?` — no se decide

> **`?` no es «no sé». Es «no se decide con el texto que tengo delante ni con ninguno de los criterios
> que tengo en la mano».**

**Cómo se aplica.** **Pasá la compuerta.** Antes de escribir el signo, corré las cuatro preguntas de
§5.2. Si alguna te da una etiqueta, esa etiqueta se escribe y el
`?` no se pone. Si las tres pasan sin resolver, escribí `?` **y al lado la razón en tres palabras**:
`?(dos lecturas)`, `?(término no definido)`, `?(contradice frag. 7)`. Un `?` sin razón al lado no
sirve para nada: el paso 5 no va a poder convertirlo en pregunta.

**Un caso.** En un banco: «la operación se registra en la cuenta correspondiente». ¿Correspondiente a
qué? El texto no lo dice en ningún lado y no hay criterio que lo resuelva: puede ser la cuenta del
ordenante o la del beneficiario, y la diferencia cambia el modelo. → `V ?(cuál cuenta)`. Es una
pregunta legítima para el autor. Contra: **«central»**, que se elevó como `?` y no debía, porque el
criterio del §8 lo resuelve en cinco segundos mirando el casillero «eje» → `R`, cuadrante `Q1`. Y ojo
con la unidad: el `?` cayó sobre el adjetivo solo, no sobre «un casco central», que es `T/C`.

#### Es / no es

| **Es `?`** | **No es `?`** |
| --- | --- |
| Dos lecturas incompatibles que el texto no desempata, y que **cambian el resultado** | Dos etiquetas posibles: eso es `X/Y`, no `?` |
| Un término usado con dos sentidos distintos en el mismo párrafo | Un término que no conocés del dominio pero que el texto usa consistentemente → etiquetá igual |
| Una contradicción entre dos fragmentos | Un fragmento que te parece mal redactado → etiquetá igual y poné `!` |
| Un dato que hace falta para decidir y que **ningún criterio del catálogo produce** | Un agente que el texto oculta → `⟦?⟧`, que es hallazgo, no duda (§5.4) |
| Una duda que **sobrevive a los dos tramos** de la compuerta: ni un criterio ni otro depósito de la hoja la cierran | Una duda que todavía no se contrastó contra la hoja: eso es un **pendiente**, se etiqueta con la lectura elegida y la nota `(abierta)` |

#### Preguntas de reconocimiento

**«¿Mi duda es entre dos etiquetas, o sobre qué dice el texto?»**
Si es entre dos etiquetas, **no es `?`**: son las dos, con barra, y sigo. `?` se reserva para cuando
no entiendo qué afirma el fragmento, no para cuando no sé en qué cajón ponerlo. Esta sola distinción
vacía la mayor parte del depósito de `?`.

**«¿Hay un criterio que ya tengo que resolvería esto?»**
La respuesta es que sí más veces de las que uno espera, y por eso la compuerta existe. Los criterios
que se tienen en la mano están listados en §5.2. **Un `?` que un criterio disponible resuelve no es
una pregunta para el autor: es un criterio no aplicado**, y cada uno de esos que llega al cuestionario
final entierra a las preguntas que sí importaban.

**«Si el autor me contestara esto, ¿cambiaría algo?»**
Si me contesto que no —si con cualquiera de las dos respuestas el modelo queda igual—, no hay
pregunta: elijo la lectura más simple, la anoto y sigo. Una pregunta cuya respuesta no cambia nada le
cuesta al autor lo mismo que una que sí, y devalúa a todas las demás.

#### Ejemplos resueltos

| Dominio | Fragmento | Etiqueta | Por qué |
| --- | --- | --- | --- |
| Banco | «la operación se registra en la cuenta correspondiente» | `V ?(cuál cuenta)` | Dos lecturas, cambian el modelo, ningún criterio las desempata |
| Escuela | «el alumno regular puede rendir» y, cuatro líneas después, «se consideran regulares los que aprobaron la cursada» | `R ?(dos sentidos de regular)` | El mismo término con dos definiciones. Es contradicción, no duda de cajón |
| Escuela | «el legajo se archiva» | `V` | No es `?`: no sé si «archivar» es guardar o dar de baja, pero es un acto igual. **La etiqueta no depende de resolver eso** |
| Obra | «central», dentro de «un casco central» *(el caso observado)* | `R` (`Q1`) | No es `?`: el criterio de §8 lo resuelve en un casillero. La hoja *instalación* tiene eje depositado —«central» ⟂ «rurales»— y género depositado —«son instalaciones»—: **recorta sobre las instalaciones, no sobre los cascos**, e informa. **El fragmento entero, «un casco central», es `T/C`**: el `?` había caído sobre el adjetivo solo |
| Hospital | «el turno se otorga según disponibilidad» | `R ?(según qué)` | «Disponibilidad» es un criterio no escrito. La respuesta cambia el modelo: es pregunta legítima |
| Taller | «se procede conforme al procedimiento habitual» | `V ?(cuál procedimiento)` | Remite a algo que no está en el texto. Nada lo resuelve |

#### Con qué se confunde

- **Contra la doble etiqueta** → §4.1. Es la confusión que más `?` falsos produce.
- **Contra `⟦?⟧`** → §5.4. El agente oculto no es una duda: es un resultado.

---

## 4. Desempates entre etiquetas

### 4.1 Las cuatro que más valen

Están ordenadas por lo que cuesta el error, no por lo frecuentes que son. **Las cuatro preguntas
que las resuelven están escritas una sola vez, en §4.3, y acá se citan**: si alguna discrepa, manda
§4.3 (regla de copia única, §0.3).

#### `A` contra `R` — la más cara

| | |
| --- | --- |
| **Cómo se ve** | «un identificador que debe ser único», «la condición de regular», «un vuelo de cabotaje» |
| **Qué desempata** | **La prueba del rechazo.** Un atributo no se puede incumplir: se tiene o falta. Una regla sí: hay alguien intentando y alguien diciéndole que no |
| **Por qué cuesta caro** | Una `R` etiquetada `A` produce un campo sin validación, y el error aparece en producción con datos ya cargados. Es el único error del paso 2 que puede llegar hasta el final |
| **Qué hacer en duda** | `A/R`, siempre. Es barato: la tabla de reglas descarta en un renglón lo que no era regla, y la de términos ignora lo que no era atributo |

> Detalle que conviene tener presente: **el mismo fragmento suele ser las dos cosas.** «Un
> identificador único» dice que hay identificador —`A`— y que es único —`R`—. No estás eligiendo entre
> dos lecturas: estás reconociendo dos contenidos.

#### `V` contra `M` — la que ensucia la tabla de actos

| | |
| --- | --- |
| **Cómo se ve** | «en el mismo acto», «al momento de la conformación», «una vez aprobada la certificación» |
| **Qué desempata** | **La prueba del «¿cuándo?».** Si el fragmento contesta *cuándo*, es `M`, aunque adentro tenga la palabra «acto» o un sustantivo de acción. La función manda sobre la forma |
| **Por qué cuesta caro** | Mete en la tabla de actos filas sin actor y sin forma de fallar. Alguien más adelante las toma por casos de uso e intenta implementarlas, y lo que implementa no existe |
| **Qué hacer en duda** | Sacá el fragmento de la frase. Si lo que queda sigue diciendo lo mismo pero sin cuándo, es `M`. Si lo que queda se rompe, es `V` |

> Y el registro doble, que es lo que hace que no se pierda nada: cuando un `M` nombra un acto por
> primera vez, **el acto se anota en la tabla de actos igual**, y el fragmento sigue siendo `M`. El
> acto se registra una sola vez, venga de donde venga.

#### `T` contra `A` — la que decide el modelo

| | |
| --- | --- |
| **Cómo se ve** | «el médico de cabecera», «la dirección», «el estado de conservación», «el encargado» |
| **Qué desempata** | **La pregunta «¿de qué es?».** Si tiene respuesta obligatoria, es `A`. Si la pregunta suena rara, es `T`. Y el control: **si el valor tendría ficha propia —alguien lo lista, lo busca, lo da de alta—, es `T` aunque suene a atributo** |
| **Por qué cuesta caro** | Un `T` tomado por `A` desaparece como entidad y se convierte en un campo de texto; un `A` tomado por `T` crea una entidad fantasma que nada usa. Los dos son caros, pero el primero es peor: reaparece meses después como «necesitamos poder listar los encargados» |
| **Qué hacer en duda** | `T/A`. Y no perder tiempo: la información que decide esto —si alguien lista esa cosa— está en otros fragmentos, no en éste |

#### `C` contra `R` — la que inventa validaciones

| | |
| --- | --- |
| **Cómo se ve** | «al menos un campo», «varios puestos», «hasta tres ejemplares por socio» |
| **Qué desempata** | **La pregunta de si obliga o describe.** «Al menos uno» obliga: hay un mínimo y alguien lo va a verificar. «Varios» describe lo típico. El indicio más fuerte: si el texto declara después que eso no se administra, el número era descripción |
| **Por qué cuesta caro** | Hacia un lado, una validación que el negocio nunca pidió y que va a rechazar datos legítimos. Hacia el otro, un mínimo que nadie controla |
| **Qué hacer en duda** | `C(dudoso)`, con el cuantificador copiado al lado. **No** se eleva como `?`: es una nota, no una pregunta |

### 4.2 Matriz completa de pares

Se lee: fila contra columna, y la celda dice **qué pregunta desempata**. Sólo la mitad superior;
los pares que nunca se confunden están en blanco.

| | `A` | `V` | `C` | `M` | `R` | `E` |
| --- | --- | --- | --- | --- | --- | --- |
| **`T`** | ¿de qué es? | ¿es sustantivo de acción? → **las dos** | | ¿contesta cuándo? | ¿el fragmento sin la locución dice algo? | |
| **`A`** | | | ¿el número es el valor, o dice cuántos hay? | | **¿puedo contar el rechazo?**, y si no, ¿hay una locución que ata? | |
| **`V`** | | | | **¿contesta cuándo?** | ¿existe para decir que algo no se puede?, ¿se puede fechar «ayer a las tres»? | ¿saca trabajo o agrega? |
| **`C`** | | | | ¿dice cuántas cosas o cuándo? | **¿obliga o describe?** | |
| **`M`** | | | | | ¿instante, o estado que puede ser falso? | |
| **`R`** | | | | | | ¿hay alguien a quien decirle que no? |

**Las celdas vacías no son olvidos.** `T` contra `E`, `A` contra `E` y `C` contra `E` no se confunden
en la práctica: las formas de superficie son demasiado distintas. Si alguna aparece en uso, entra a
esta matriz y el documento se revisa.

**La nota `(estructura)` no entra en la matriz**, y por eso no hay fila para ella: no compite con
ninguna letra. Se escribe **después** de haber puesto `R`, sobre una sola pregunta binaria.

### 4.3 Las cuatro preguntas que desempatan casi todo

Si hubiera que quedarse con cuatro líneas de todo el documento, son éstas. Sirven en ese orden y la
primera que contesta, manda.

| # | Pregunta | Qué separa |
| --- | --- | --- |
| 1 | **¿Puedo contar el rechazo?** | `R` de todo lo demás |
| 2 | **¿Contesta «cuándo»?** | `M` de `V` |
| 3 | **¿De qué es?** | `A` de `T` |
| 4 | **¿Hay dos cosas del negocio acá adentro?** | Si sí y no podés contar el rechazo: `R(estructura)` |

Ninguna pide mirar otro fragmento, y entre las cuatro cubren los pares que se confunden de verdad.

---

## 5. La compuerta del `?`

### 5.1 Qué significa realmente `?`

La glosa original decía «no sé», y ahí está el problema: «no sé» es un estado de quien etiqueta, y
cualquier estado de quien etiqueta se alcanza estando cansado. La etiqueta tiene que nombrar una
propiedad **del texto**, no del lector.

> **`?` es: el fragmento no se decide con el texto que tengo delante, ni con ninguno de los criterios
> que tengo en la mano, ni con ningún otro depósito de la misma hoja del referente.**

La tercera parte es el segundo tramo de la compuerta, y la segunda es el primero. Sin ella, `?` se convierte en el desagüe del paso 2: todo lo
incómodo cae ahí, el cuestionario final sale con cuarenta preguntas, y las tres que de verdad
importaban se pierden entre las treinta y siete que cualquiera podía resolver. **El daño no es
preguntar de más: es que preguntar de más apaga las preguntas buenas.**

### 5.2 El procedimiento de la compuerta

Cuatro preguntas. Se corren **en orden** y la primera que resuelve, manda. **Un `?` sólo llega al autor después de pasarlas todas.**

**Paso 1 — ¿Mi duda es entre dos etiquetas?**
Si sí → **no es `?`.** Escribí las dos con barra y seguí. Fin.

**Paso 2 — ¿Alguno de estos criterios que ya tengo lo resuelve?**
Corré la lista de un vistazo. Las cuatro primeras filas **son las cuatro preguntas de §4.3**, citadas
acá para que no haya que ir a buscarlas; si alguna discrepa, manda §4.3.

| Criterio | Resuelve |
| --- | --- |
| ¿Puedo contar el rechazo? | Si sí, `R` |
| ¿Contesta «cuándo»? | Si sí, `M` |
| ¿De qué es? | Respuesta obligada, `A`; pregunta rara, `T` |
| ¿Hay dos cosas del negocio, atadas por una locución? | Si sí y no podés contar el rechazo, `R(estructura)` |
| ¿Saca trabajo? | Si sí, `E` |
| ¿Es un sustantivo de acción? | `T/V` |
| ¿Es un demostrativo que apunta a algo ya nombrado? | Anillo `°` sobre la letra que corresponda (`M°`, `T°`) |
| ¿Es un modificador? | La jerarquía de §8: determinante → unicidad en «miembros» → **¿contra cuál?**, que se mira en «género» → supresión → coma. Sale con cuadrante |
| ¿Falta el sujeto o el agente? | `⟦ ⟧`, y si no se puede reponer, `⟦?⟧`: **hallazgo, no duda** |

Si alguno resuelve → escribí esa etiqueta. Fin. **Ese `?` era un criterio no aplicado.**

**Paso 3 — ¿Hay otro depósito en el mismo casillero que lo resuelva?**
Es el **segundo tramo de la compuerta**, y es gratis: el primero pregunta si hay un criterio en la
mano; éste, si hay otra parte del texto. La diferencia con buscar por el párrafo es que **se mira en un
solo lugar**.

> **Cómo se aplica.** Preguntale al fragmento de qué cosa del negocio habla y abrí esa hoja. Andá al
> casillero donde el fragmento depositaría. ¿Hay ya otro depósito? Contrastalo: si coinciden, uno
> confirma al otro y la duda se cierra; si uno **discrimina** al otro —una formulación es más precisa,
> y en especial si es la operacional, la que dice qué se hace con la cosa—, **fija la lectura**; si no
> cierran, no es duda de etiqueta sino hallazgo, y baja por la escalera de `02` §6.2.
>
> Si no hay segundo depósito todavía, **el `?` no es terminal: queda pendiente en la hoja**, con la
> letra puesta bajo la lectura elegida y la nota `(abierta)` al lado. Ahí es donde lo vas a encontrar
> cuando llegue, tres renglones después, la oración que lo resuelve.

**Paso 4 — Si el autor me contestara, ¿cambiaría el modelo?**
Si no → elegí la lectura más simple, anotala y seguí. Fin.
Si sí → **`?` con la razón en tres palabras al lado.** Ese es un `?` legítimo: pasó **las tres**
compuertas y va a llegar al cuestionario del paso 5 con fuerza, porque va a estar rodeado de pocos
hermanos.

> **La medida del `?`, y es una cuenta que hacés vos.**
>
> **Contá los `?`.** Al cerrar el paso 2, contá cuántos fragmentos quedaron con la letra `?` **sola**.
> No cuentan los `⟦?⟧`, ni las notas entre paréntesis, ni los signos de interrogación de tus notas al
> margen: ésos son hallazgos, no dudas. Escribí la cuenta al lado del total: `? 1/13`.
>
> **Corré la compuerta de nuevo sobre esos, y sólo sobre esos.** Fragmento por fragmento, pasá la tabla
> del paso 2 de la compuerta. El que un criterio resuelva, reemplazalo por la etiqueta que el criterio
> te dio y tachá el `?`. Los que sobrevivan, copialos al cuestionario del paso 5 con su razón en tres
> palabras. **Esto no es releer etiquetas puestas**, que §1.4 prohíbe: un `?` no es una etiqueta
> puesta, es una decisión que quedó pendiente.
>
> **Anotá la cuenta después de cada tramo** —`? 1/13 → 1/13 → 0/13`—: los levantados, los que
> sobreviven a los criterios en la mano, y los que sobreviven además al contraste en la hoja. La
> proporción es lo único que dice si la compuerta sirvió: **si sobrevive el que levantaste, la
> compuerta funcionó; si se caen todos, la estabas salteando.**
>
> **Sobre qué evidencia se apoya esto, sin maquillar.** Sobre **una sola corrida**: 13 fragmentos, un
> `?`, y ese `?` resultó resuelto por un criterio que ya estaba disponible (§6, caso 6). La única
> cuenta observada de `?` que sobreviven es **cero sobre uno**. **Por eso acá no hay umbral y hay una
> recuenta.** Cuando haya cinco corridas anotadas con su par, se calcula la proporción observada y
> recién entonces se escribe un umbral.

### 5.3 Qué es una pregunta legítima para el autor

Tres condiciones a la vez. Si falta una, no hay pregunta.

| Condición | Cómo se verifica |
| --- | --- |
| **No está en el texto** | Buscaste la palabra en el párrafo entero, no sólo en el fragmento |
| **Ningún criterio la produce** | Corriste la tabla del paso 2 de la compuerta |
| **La respuesta cambia algo** | Podés nombrar las dos cosas distintas que se construirían según la respuesta |

Y la forma en que se escribe, porque una pregunta mal escrita se responde mal: **se ofrecen las dos
lecturas y se dice qué cambia con cada una.** «¿A qué se refiere "la cuenta correspondiente": a la
del ordenante o a la del beneficiario? Si es la del ordenante, la operación se registra una sola vez;
si es cualquiera de las dos, hace falta un campo que diga cuál.» Eso el autor lo contesta en quince
segundos. «¿Qué quiere decir "correspondiente"?» no lo contesta nunca.

### 5.4 El hueco de agente no es un `?`

El «se» impersonal —«se establece», «se contempla», «se aprueba»— esconde quién hace la acción. La
tentación es elevarlo como `?`. Es un error, y distinguirlo bien es una de las cosas que más limpian
el cuestionario final.

| | `?` | `⟦?⟧` |
| --- | --- | --- |
| Qué dice | **No pude clasificar** este fragmento | Clasifiqué bien; **falta un dato del mundo** |
| Sobre qué es | Sobre mi lectura del texto | Sobre el negocio |
| A dónde va | Al cuestionario del paso 5 | A la columna «quién lo hace» de la tabla de actos, vacía |
| Qué resultado produce | Una pregunta | **Un hallazgo**: la tabla de actos con la columna del actor en blanco |

**Y el punto que lo vuelve valioso:** una tabla de actos con la columna «quién lo hace» vacía en
cinco filas no es una tabla incompleta. Es la evidencia, junta y a la vista, de que **el enunciado no
dijo quién hace nada**, que es un hallazgo sobre el enunciado y no un descuido del que lo analizó.
Disperso en cinco preguntas sueltas, ese hallazgo no existe; concentrado en una columna, salta.

**Dónde se cobra el hueco y dónde no.** No todo agente oculto vale lo mismo, y cobrarlos todos es
volver al problema del ruido:

| Etiqueta | ¿Se cobra el `⟦?⟧`? | Por qué |
| --- | --- | --- |
| `V` | **Sí, siempre** | Un acto sin actor no se puede construir: alguien va a tener que apretar el botón |
| `R` | **Sí** | Una regla sin obligado termina con un responsable inventado por el software |
| `E` | No | Quién decidió excluirlo no cambia nada: está excluido igual |
| `M` | No | Un momento no tiene agente |
| `T`, `A`, `C` | No | No hay agente que reponer |

---

## 6. Banco de pruebas: los siete casos observados

Son casos de uso real, entregados con el encargo. Se resuelven acá con el catálogo tal como quedó, y
**cada caso lo resuelve exactamente un criterio nombrado**, que es la prueba que sí es auditable —la
versión anterior decía «en menos de cinco segundos», y §10 límite 3 declara que nadie cronometra—.

**Cómo leer la columna «Con las ocho originales», que en la versión 1.0 estaba mal.** La corrida
observada vive en un archivo que registra **su propia corrección**: el estado que se lee es el ya
corregido por el instructor, y la primera pasada sólo se ve donde el texto la cita. Por eso cada fila
declara ahora si lo que dice de la primera pasada es **testimonio directo** —está citado— o
**reconstrucción** —se infiere—, y trae el identificador del fragmento cuando la evidencia lo da.

| # | Caso | Fragmento (id) | Con las ocho originales | Estatuto de esa columna | Con este catálogo | Qué lo resuelve |
| --- | --- | --- | --- | --- | --- | --- |
| 1 | **Efecto de un acto** | «se establece un casco central» *(sin id en la evidencia disponible)* | `V` | **Reconstrucción.** La etiqueta es correcta; **la consecuencia «y la tabla de actos duplica» es falsa**: el paso 3 acumula los efectos en la fila del acto y no duplica nada | `V ⟦?⟧` + `T/C` (casco central) | **Nada nuevo.** La ley del paso sucio (§1.1): el efecto se etiqueta `V` y la fusión la hace el paso 3. El `⟦?⟧` cobra el agente del «se» |
| 2 | **Anáfora de momento** | «En el mismo acto» (`02.a.1`) | `V` — por la palabra «acto» | **Testimonio directo.** Es el único caso con cita de la primera pasada: «pusiste `ref: 01.b.5`… no es `V`, es `M`» | `M°` | La pregunta **«¿contesta cuándo?»** (§4.1) manda sobre la forma; el demostrativo «el mismo» pide **anillo** (§2.1) |
| 3 | **Atadura entre dos cosas del negocio** | «a cargo de un Administrador» (`02.a.5`) | `R` | **Reconstrucción, y el rótulo «a falta de algo mejor» es falso.** La `R` se asignó con doctrina: «no corta… pero sí contiene una afirmación… **por eso va `R`**. Es el caso del calificador que aporta un hecho». La mezcla en la tabla de reglas es real; la resignación, no | `R(estructura)/C` + `T` (Administrador) | La **nota `(estructura)`** (§3.6): la letra ya era correcta y le faltaba una palabra. El aporte es **notación**, no capacidad |
| 4 | **Sujeto tácito** | «está compuesta por al menos un campo» (`01.b.2`) | `R+C` | **Reconstrucción, y «ninguna clara» es falso.** El material etiqueta `R+C`, y lo hace **dos veces, en dos dominios distintos** | `R(estructura)/C` con `⟦la estancia⟧` | Los **corchetes** (§2.2) restituyen el sujeto sin tocar la cita; la nota `(estructura)` dice de qué clase es la afirmación. El aporte es **notación** |
| 5 | **Nominalización** | «conformación» (`01.b.5`), «la administración de los campos» | `V` en el archivo | **Reconstrucción sobre un condicional.** El §6 de la versión 1.0 decía «`T`, y el acto se pierde»; el material dice «**si lo dejás** como sustantivo se te va a términos y perdés el acto». Es una advertencia del instructor, no un hecho observado | `T/V` | La **doble etiqueta** (§1.3): la duda legítima de cinco segundos produce la anotación correcta, sin que haya que reconocer la nominalización |
| 6 | **Modificador sobre un conjunto que el núcleo no nombra** | **«central»** (`02.a.4`), dentro de «un casco central» | `?` elevado al autor | **Testimonio indirecto, con la unidad corregida.** El `?` cayó sobre **«central»** sola; «un casco central» era `T+C`. El material retracta el `?`: «levanté un `?` que podía contestar con un criterio que tenía en la mano» | `R` (`Q1`) para «central»; `T/C` para el fragmento entero | La **hoja del referente** (§8): el casillero «eje» tiene depósito —«central» ⟂ «rurales»— y el «género» dice sobre qué —*instalaciones*—. **Había criterio, y además estaba mal aplicado:** la versión 1.1 buscaba el contraste entre cascos, que es el conjunto equivocado. Sigue siendo un criterio no aplicado, no una pregunta |
| 7 | **Agente oculto** | «se establece», «se contempla» *(sin id en la evidencia disponible)* | la columna del actor queda vacía y parece descuido | **Reconstrucción, y correcta** | `V ⟦?⟧` / `E` (sin cobrar) | La distinción **`?` contra `⟦?⟧`** (§5.4): en `V` se cobra y produce un hallazgo contable; en `E` no se cobra. **Es el mejor aporte propio del catálogo** |

**El recuento honesto, que es distinto del que traía la versión 1.0.** De los siete, **ninguno
necesitó etiqueta nueva**. Dos —el 3 y el 4— se resuelven con una **nota** sobre una letra que la
corrida ya había puesto bien, o sea que lo que el catálogo aporta ahí es **notación y no capacidad**.
Uno con el anillo, dos con marcas de restitución, uno con la doble etiqueta y uno con un criterio que
ya existía y no se estaba aplicando. **Ninguna de las siete filas prueba una carencia de las ocho
letras.** Esa es la base del veredicto de §7.1.

**Lo que el caso 3 ya no deja como residuo.** «A cargo de un Administrador» trae una afirmación
implícita —*todo casco tiene alguien a cargo*— que es una regla estructural. Con la letra `R` y la
nota `(estructura)`, esa afirmación **viaja desde el paso 2**: la fila llega a la tabla de reglas con
la especie ya escrita. Lo que el paso 3 tiene que hacer es **componer la cardinalidad mínima** para
que la regla quede enunciada, y esa obligación está declarada en §7.5.

**Advertencia de anclaje, y está sin resolver.** §11.1 ancla estos siete casos a un archivo que
contiene el **enunciado** y no la **corrida**. Mientras la corrida no esté transcripta y versionada en
el árbol de este documento, **el §6 no es verificable desde el repositorio que lo contiene** (§10,
límite 8).

---

## 7. ¿Alcanzan las ocho etiquetas?

### 7.1 Veredicto

**Alcanzan.** Las ocho letras se quedan como están: no falta ninguna, no sobra ninguna, ninguna hay
que partir en dos. Lo que faltaba no era una letra: era **una palabra sobre una letra que ya
existía**.

| Pregunta | Respuesta |
| --- | --- |
| ¿Falta alguna? | **Ninguna.** La candidata seria era `L` (liga), y se rechaza: el destino que decía faltar ya existe, y la letra `R` ya lo alcanza (§7.2) |
| ¿Sobra alguna? | **Ninguna.** `C` estuvo cerca y se queda por un motivo operativo, no taxonómico (§7.4) |
| ¿Hay que partir alguna? | **No.** La tentación era partir `V` en *acto* y *efecto*; no se parte, y tampoco se marca: la fusión la hace el paso 3 acumulando efectos en la fila del acto (§2.1) |
| ¿Cuánto más lento queda el paso 2? | **Nada.** Ocho candidatas antes, ocho ahora. Una nota se escribe *después* de elegir la letra, sobre una pregunta binaria, y no compite con nada (§2.3) |
| ¿Qué gana el paso 4, entonces? | El ahorro entero que la letra nueva prometía: la fila llega con su especie escrita y **no se le corre el análisis de regla completo** (§7.5) |

### 7.2 Por qué `L` no se agrega, y qué entra en su lugar

**El diagnóstico que fundaba la letra es correcto y hay que decirlo.** Cuando `R` contiene reglas
verificables y afirmaciones estructurales sin distinguirlas, el paso 4 corre el análisis completo
—especie, momento, dueño, prueba— sobre algo que no es una regla. Eso es trabajo real perdido.

**El instrumento era el equivocado, y son tres cosas verificadas:**

**Primero: el destino existe.** El paso 3 tiene tres tablas, y la de reglas tiene una columna
`Especie` cuyo valor `estructura` ya está definido en el material de origen. El fragmento «a cargo de
un Administrador» **sí** va a una de las tres tablas: va a la de reglas, con la especie escrita.

**Segundo: la `R` de la corrida no fue una resignación.** El material da una razón positiva —«no
corta… pero **sí contiene una afirmación**: todo casco tiene alguien a cargo. **Por eso va `R`**… Es
el caso del calificador que aporta un hecho»—. `R` es la letra **correcta**, y lo que le faltaba era
decir de qué clase es la afirmación. Eso es una nota, no una letra.

**Tercero: no se reconocía mirando.** La pregunta que la letra pedía era «¿hay dos cosas del negocio
acá adentro **y las dos son cosas y no valores**?»: dos cláusulas, y la segunda es la decisión `T`/`A`
que §4.1 declara **no local** —«la información que decide esto está en otros fragmentos, no en
éste»—. Una pregunta que remite a otro fragmento no entra en cinco segundos.

**Y lo que se perdía.** Con `L/C`, la afirmación que la `R` transporta —*todo casco tiene alguien a
cargo*— **desaparecía del paso 2** y quedaba delegada en una obligación que el documento del paso 3
no había aceptado. La nota no pierde nada: la afirmación sigue viajando.

**Qué entra en su lugar, en una línea:** la nota **`R(estructura)`**, con su segunda entrada de
reconocimiento en §3.6 —*subrayá la locución que ata*— y destino fijado en la **Tabla 3 del paso 3,
columna `Especie`, valor `estructura`**. Ninguna tabla nueva. Ningún cambio en el documento del
paso 3.

**El costo, dicho sin maquillar.** Es uno solo y es real: **`R` queda con dos entradas** —contá el
rechazo, o subrayá la locución que ata— y eso es más de lo que tiene cualquier otra letra. Es el
precio de no agregar la novena, y se revisa si en dos corridas la segunda entrada produce `R` donde
no hay nada que asentar (§10, límite 4).

### 7.3 Por qué no se agrega ninguna otra

Las cuatro candidatas que los casos observados sugieren, y por qué cada una se rechaza.

| Candidata | Qué resolvería | Por qué se rechaza |
| --- | --- | --- |
| **Efecto** (partir `V` en acto y efecto) | Caso 1 | No hace falta **ningún** instrumento: el paso 3 arma una sola fila por acto y le acumula los efectos en la columna «qué cambia». La duplicación que se temía **no ocurre** |
| **Liga** (`L`, atar dos cosas del negocio) | Casos 3 y 4 | El destino ya existe —la tabla de reglas, con su columna `Especie`—, la letra `R` ya es correcta, y la pregunta que la reconocería tiene dos cláusulas y una de ellas no es local. Es una **nota**: `R(estructura)` (§7.2) |
| **Anáfora** | Caso 2 | El anillo `°`, que no encarece la elección y sirve para `M` y para `T`. Y el caso 2 no era un problema de etiqueta: era `V` donde correspondía `M`, o sea, un desempate mal hecho. La solución es la pregunta de §4.1, no una letra |
| **Hueco / agente faltante** | Caso 7 | Es `⟦?⟧`, y el motivo es de fondo: **no describe el fragmento, describe lo que falta.** Una letra que compite con las otras ocho tiene que decir qué *es* el fragmento; «le falta el actor» no es una respuesta a esa pregunta. Además el hueco convive con cualquier letra: `V ⟦?⟧`, `R ⟦?⟧` |
| **Definición** («se entiende por X…») | — | No salió en los casos observados, y cuando salga se etiqueta `T` con la definición al lado: el destino —la tabla de términos— es el mismo. Agregar una letra cuyo ruteo coincide con otra no aporta nada al paso 2 |

**El criterio general, para que no haya que discutir la próxima vez:**

> **Primero, ¿hay destino?** Listá las tres tablas del paso 3 y preguntá a cuál va el fragmento. Si
> no va a ninguna, es candidata a **letra**. Si va a una, no es letra: es marca, nota o columna.
>
> **Después, ¿se reconoce mirando?** **Escribí la pregunta que la reconoce.** Si la pregunta tiene
> más de una cláusula, o menciona otro fragmento, **no se reconoce mirando** y no entra: va a
> producir `?` o deliberación, que es lo mismo.
>
> **Y al final, cuál de los tres es.** **Marca** cuando la letra es correcta pero la anotación está
> incompleta y la falta es del mismo tipo en varias letras (`°`, `⟦ ⟧`, `!`). **Nota** cuando la
> letra es correcta y lo que falta es una palabra sobre esa letra (`R(estructura)`, `C(describe)`).
> **Columna del paso 3** cuando el dato no cambia lo que la persona escribe en el margen.
>
> **Un caso, y es el de esta mesa.** `L` (liga): ¿hay destino? La Tabla 3 ya recibe el fragmento por
> `R`. ¿Se reconoce mirando? Su pregunta era «¿hay dos cosas del negocio acá adentro **y las dos son
> cosas y no valores**?»: dos cláusulas, y la segunda es la decisión `T`/`A` que §4.1 declara no
> local. **No entra como letra.** ¿Marca, nota o columna? La letra `R` es correcta y le falta una
> palabra: **nota**, `R(estructura)`.

### 7.4 Qué no sobra, y por qué `C` estuvo cerca

**`C` fue la candidata seria a eliminarse**, y el argumento en contra es bueno: toda cardinalidad
exigible termina siendo una regla —«al menos un campo» es una regla estructural—, así que `C` podría
absorberse en `R` sin costo neto.

**Se queda igual, por tres motivos operativos:**

1. **Se reconoce más rápido que `R`.** El cuantificador es una palabra visible; contar el rechazo es
   un razonamiento. `C` es de las pocas etiquetas que se ponen sin pensar, y las etiquetas baratas
   subsidian a las caras.
2. **`C` casi nunca viene sola: viene pegada a `R(estructura)` o a `A`.** Es una anotación *sobre*
   otra cosa, y ese carácter se perdería adentro de `R`.
3. **La distinción obliga-describe vive en `C`.** «Varios puestos» es descripción y no regla; si el
   fragmento se etiqueta `R`, esa distinción se pierde y aparece una validación inventada. Fue un
   caso real del material.

**Las demás no se discuten.** `E` es la etiqueta de mejor relación entre costo y valor de todo el
catálogo: se reconoce por fórmulas fijas de superficie, es rara, y su omisión hace construir cosas
que nadie pidió. `M`, `T`, `A`, `V` y `R` son los cinco destinos básicos. `?` no es una etiqueta de
contenido sino la válvula del procedimiento, y con la compuerta puesta ya no es un desagüe.

### 7.5 Lo que el paso 3 tiene que absorber

Este documento le deja tres obligaciones al paso 3. Se declaran acá porque si no se cumplen, parte
del trabajo del paso 2 no llega a ningún lado.

| # | Obligación | Si no se cumple |
| --- | --- | --- |
| 1 | **Asentar la especie de las `R`**: toda `R(estructura)` entra a la Tabla 3 con `Especie: estructura`, y el paso 4 no le corre el análisis de regla completo | El paso 4 analiza como prohibición lo que es la forma del modelo, que es el trabajo que esta nota existe para ahorrar |
| 2 | **Componer `R(estructura) + C` en regla enunciada**: toda atadura con cardinalidad mínima uno produce la regla *«toda ‹A› tiene al menos un ‹B›»* | La afirmación llega con su especie pero sin enunciar, y el caso 3 queda a medio camino |
| 3 | **Dejar la columna del actor visible y vacía**: los `⟦?⟧` se concentran en una columna de la tabla de actos, no se dispersan en notas | El hallazgo «el enunciado no dice quién hace nada» no se ve |

---

## 8. La jerarquía de indicios, generalizada a todo modificador

La jerarquía de `02-Criterio-De-Segmentacion.md` §4.3 estaba escrita para relativas, y **había que
generalizarla a todo modificador** —adjetivos, complementos preposicionales, aposiciones—. El caso 6
lo prueba: «central» se elevó como `?` cuando la unicidad del antecedente y la ausencia de contraste
ya lo resolvían, y se elevó porque la jerarquía que lo resolvía estaba **titulada por una estructura
gramatical y no por su función**, así que nadie fue a buscarla. `grep -ic "modificador"` sobre el
paso 1 devolvía **cero**.

**Ya está aplicado.** La generalización **no es una propuesta de este documento**: el material
observado ya la había decidido y fundado, y desde la versión 1.1 está escrita en el documento hermano
—`02` §4.3, retitulada por su función —hoy «¿Este modificador restringe? ¿e informa?»—, con el capítulo
retitulado, el paso **P5-bis** en el procedimiento y las dos filas nuevas en la tabla de estructuras—.
**La versión que manda es la de `02` §4.3.** Lo que sigue es el resumen que se usa desde el paso 2, y
si discrepa con el hermano, manda el hermano.

### El resumen operativo

Se aplican en orden y el primero que resuelve, manda.

**Antes de empezar: ¿es modificador o es argumento?** Si el núcleo es un sustantivo **relacional o
deverbal** y el segmento llena su casilla —«el nombre **del encargado**», «la administración **de los
campos**»—, **no entra en la jerarquía**: no restringe ni describe, satura un argumento.

**Y antes de la jerarquía corre la regla que llena el casillero «eje».** No es un indicio más: es de
dónde sale lo que el indicio 4 va a mirar.

> **Regla de depósito del eje.** Dos núcleos coordinados con modificadores de la misma clase
> **depositan un eje** en la hoja del referente que comparten. **Cómo se aplica.** Se exigen las
> cuatro: **C1** coordinados bajo el mismo predicado (o con elipsis verbal), **C2** los dos
> modificadores del mismo lado de su núcleo, **C3** misma clase —adjetivo contra adjetivo—, **C4**
> eje nombrable. *Prueba del eje:* completá «se distinguen por su ____» con un sustantivo; si sólo
> te sale «por sus características», **no hay eje** y no se deposita. **Un caso:** «un casco
> **central** … y varios puestos **rurales**» → eje *ubicación*, depositado. Detalle en `02` §4.3.

| Orden | Indicio | Cómo decide | Vale para |
| --- | --- | --- | --- |
| 1 | **Posición del adjetivo** | **Antepuesto** —*un amplio casco*, *el mencionado plazo*— → **describe**. Unidireccional: **pospuesto no prueba nada** | sólo adjetivos |
| 2 | **Determinante del antecedente** | *todo, cada, los… que, aquellos… que, sólo los, ningún* → **restringe**, casi con seguridad. Unidireccional: ***un, una, unos* no prueba que describa** | todos |
| 3 | **Unicidad referencial** | Se cuenta en el casillero **«miembros»** de la hoja, **no sobre la extensión del núcleo**: un solo miembro → **describe**; dos o más → no concluye | todos |
| 4 | **Conjunto de contraste — «¿contra cuál?»** | **No se busca: se mira.** El conjunto es el casillero **«género»** de la hoja. Con género depositado → recorta, y sobre ese género. Con la hoja vacía → **el indicio pasa el turno**, que no es lo mismo que «describe» | todos |
| 5 | **Prueba de la supresión** | Suprimí el modificador: ¿el antecedente designa el mismo conjunto? Mismo → describe; más grande → restringe. **Con un adjetivo de una palabra no concluye** | relativas, complementos |
| 6 | **Puntuación del autor** | Entre comas → describe; sin comas → restringe. **Sólo si 1 a 5 no resolvieron**, y sólo en estructuras que admiten inciso | relativas, aposiciones, complementos |
| 7 | **Consistencia interna del documento** | Cómo puntúa el mismo autor un caso inequívoco en otro párrafo | todos |
| 8 | **Regla de cierre** | Si nada resolvió: **restringe, no se corta, se marca `?`** | todos |

**El error que esta versión corrige, y era el peor del documento.** La versión 1.0 escribía el
indicio del determinante en las dos direcciones —«*un, una, unos* → describe»— y eso es **falso**. El
indicio es **unidireccional**: el determinante universal pide restricción; el indefinido **no prueba
nada**. Tres contraejemplos, y dos son de este mismo catálogo:

- «**Un** socio moroso no puede retirar ejemplares» → indefinido, y *moroso* **restringe**. Con la
  regla vieja salía `A` donde va `R`: el par que §4.1 llama «la más cara».
- «**Una** cuenta a nombre de **un** titular» → la regla vieja mandaba a «describe» y contradecía a
  la ficha que la alojaba.
- «**Un** socio con multa impaga no puede retirar ejemplares» → `R`, con indefinido.

**El indicio 4 es el que resuelve los adjetivos, y el acta 06 le corrigió el ámbito.** La formulación
recibida —«un adjetivo restringe solo si existe un conjunto de contraste del cual recortar»— es
correcta; lo que estaba mal era **dónde se buscaba ese conjunto**. Aplicada a «un casco central», la
versión 1.1 concluía «no hay otros cascos en el discurso, no hay de dónde recortar» → describe, **y es
falso**: hay de dónde recortar, y el conjunto no era *cascos* sino *instalaciones*, que es lo que la
oración siguiente deposita en el casillero «género». **El conjunto contra el que un modificador recorta
no es la extensión de su sustantivo.** Buscar «otro casco» es buscar en el lugar equivocado.

Lo propio de este documento sigue siendo la **formalización** y el lugar en el orden: **el contraste va
antes que la supresión**, porque la supresión se contesta por impresión y con un adjetivo de una
palabra resbala. Lo que cambia es que el contraste **ya no se busca: se mira** en la hoja.

**Y el resultado no es simétrico, ni es una sola pregunta.** Son dos —*¿restringe?* y *¿informa?*— y
salen como cuadrante. *Restringe* → es el **alcance** de la afirmación, no se corta. *No restringe* →
**no es inerte**: predica algo aparte. Un modificador no restrictivo nunca se descarta por no
restringir, y **«no restringe» no es «no importa»**.

**Qué le toca a cada paso.**

| Paso | Qué decide el modificador | Resultado |
| --- | --- | --- |
| 1 (corte) | Si se corta o se registra como restricción del antecedente | Corte o calificador |
| **2 (etiqueta)** | **El cuadrante.** `Q1 → R`, o `R/A` si la propiedad es además un dato de la cosa · `Q2 → R°` · `Q3 → A`, o `R(estructura)` si ata dos cosas del negocio · `Q4 → T°` | La letra, con el cuadrante escrito al lado |

La celda del paso 2 estaba mal en la versión 1.0 —decía «si es `A` —describe— o `R`»—, y el propio
banco de casos la refuta: «a cargo de un Administrador» **no restringe** y tampoco es `A`. La versión
1.1 la corrigió a describe/restringe, que seguía siendo **una** pregunta; el acta 06 la parte en dos.

**Qué cambió aguas arriba, dicho sin maquillar.** La versión 1.0 afirmaba que generalizar §4.3 «no
altera ninguna decisión ya tomada» por el paso 1. **Sí la altera.** «Un lote que supere las 200
hectáreas se subdivide» es una especificativa bajo indefinido —la fila 17 del paso 1—, y con el
indicio mal escrito se leía «describe» → explicativa → **corta**, que es la afirmación universal falsa
que el paso 1 está escrito para evitar. La corrección del indicio 1 a unidireccional es justamente lo
que impide ese resultado.

---

## 9. Hoja de bolsillo

Está al principio del documento, que es donde la necesitás. Si llegaste hasta acá leyendo, ya no la
necesitás: volvé arriba y llevatela impresa.

---

## 10. Límites declarados

1. **No decide nada sobre el contenido.** Una etiqueta es un ruteo a una tabla. Que un fragmento
   etiquetado `R` sea efectivamente una regla, de qué especie y con qué dueño, lo decide el cuerpo
   metodológico, no este catálogo.
2. **No corrige el corte.** Si el paso 1 entregó un fragmento gordo o mal delimitado, este catálogo
   lo etiqueta como puede y lo marca con `!`. Volver al paso 1 desde el paso 2 rompe el ritmo y en la
   práctica hace abandonar la pasada.
3. **La regla de los cinco segundos es una calibración, no una medida.** Nadie va a cronometrar. Lo
   que la regla transmite es el orden de magnitud y, sobre todo, **la autorización a no deliberar**,
   que es lo que de verdad hace falta decir.
4. **La nota `R(estructura)` es una propuesta de este documento y todavía no tiene uso real.** Las
   ocho letras vienen de una corrida; la nota viene de un análisis de esa corrida. En particular hay
   que ver si la **segunda entrada** de `R` —subrayá la locución que ata— produce `R` donde no hay
   nada que asentar. Se revisa a las dos corridas.
5. **El techo de dos etiquetas no está validado.** Salió del razonamiento de que tres etiquetas
   significan un fragmento gordo. Puede ser que existan fragmentos legítimamente triples; si aparecen
   dos o tres en uso, el techo se revisa.
6. **Calibrado para prosa de negocio en español rioplatense**, con la misma salvedad del criterio de
   segmentación: articulado legal, prosa narrativa y especificaciones formales pedirían otra cosa.
7. **La matriz de §4.2 está incompleta a propósito.** Los pares en blanco son los que no se
   confundieron; si alguno se confunde en uso, entra.
8. **La medida del `?` no está validada.** Sale de una corrida de 13 fragmentos con un solo `?`, que
   además resultó ilegítimo. Lo único que la corrida sostiene es que la compuerta hacía falta, no
   cuántos `?` son demasiados. Y hay un límite de anclaje encima: la corrida **no está transcripta ni
   versionada** en el árbol de este documento, así que §6 no es verificable desde acá.
9. **El banco de pruebas de §6 contiene un veredicto corregido.** El caso 6 pasó de `A` a `R` (`Q1`)
   por el acta 06: ya no es un caso de **criterio no aplicado** sino de **criterio mal aplicado**
   —había criterio en la mano, y además se lo estaba corriendo sobre el conjunto equivocado—. Lo que
   el caso sigue probando, que el `?` era ilegítimo, se conserva y se refuerza.
10. **La hoja del referente no se corrió a ciegas**, y la lista de casilleros **no está declarada
   cerrada**. La verificación que la fundó es una re-derivación sobre resultados ya conocidos, y la
   pregunta de si hacen falta hojas de acto sigue abierta (acta 06 §7, IR-1 e IR-2).
11. **La suficiencia de las ocho letras se decide sobre trece fragmentos**, de los cuales sólo dos son
   testimonio directo de la primera pasada, y que cubren **dos de las cuatro oraciones** del párrafo.
   La primera corrida sobre las oraciones que faltan es la prueba de esta decisión: si aparecen
   ataduras que la nota `(estructura)` no alcanza a anotar, `L` vuelve a discutirse **con datos**.

---

## 11. Trazabilidad y control de cambios

### 11.1 Procedencia

| | |
| --- | --- |
| **Hermanos** | `02-Criterio-De-Segmentacion.md` (paso 1, produce los fragmentos), `Knowledge-Deduccion-De-Reglas-De-Negocio.md` (pasos 4 y 5, consume las tablas), `Knowledge-Icono-Y-Ancla.md` (forma de entrega de cada definición) |
| **Fuente de los casos** | Los siete casos de §6 fueron observados en un uso real del paso 2. **El ancla es insuficiente y se declara como tal:** `../Bitacora-Editores/09-Fuente-Actividad-La-Estancia.md` contiene el **enunciado**, no la **corrida**. La corrida vive fuera del árbol de este documento, y transcribirla y versionarla es deuda abierta (§10, límite 8). Cada fila de §6 dice si lo que afirma de la primera pasada es testimonio directo o reconstrucción |
| **Acta que lo corrige** | `../Mesa/06-Acta-Replanteo-Del-Modelo.md` (2026-09-28). De sus 37 parches, este documento recibe **14**: seis tal cual, seis con texto nuevo y dos que desaparecen (`03-g` y `03-h`, que hablaban de un producto —la pasada de recomposición— que el acta retira) |
| **Qué es recibido y qué es formalización** | El **conjunto de contraste**, la **generalización a todo modificador** y la **formulación de la compuerta** están en el material observado: lo propio de este documento es la formalización, el orden y los puntos de entrada (§0.3). La versión 1.0 las declaraba propias, y no lo son |
| **Ejemplos** | Todos los de §3 son propios e inventados para este documento, de banco, biblioteca, obra, hospital, escuela, municipio, aerolínea y taller. Ninguna escena se repite en más de dos fichas |
| **Qué se propone hacia afuera** | Las tres obligaciones del paso 3 (§7.5), que **no requieren tabla nueva ni cambio de estructura**: la Tabla 3 ya tiene la columna `Especie`. La generalización de §4.3 **ya no es propuesta**: está aplicada en `02` v1.1 |

### 11.2 Verificación contra `Knowledge-Icono-Y-Ancla.md`

**Alcance real, corregido.** La prueba de la operación (§3.1 del hermano) se corre sobre **toda
definición y todo enunciado numérico** del documento, que es lo que la regla exige. La versión 1.0
declaraba «las nueve definiciones de etiqueta, las dos de marca y la del `?`» y remataba «las once»:
la cuenta no cerraba —eran doce con `?` contado dos veces— y el alcance declarado era menor que el
exigido.

**Las trece definiciones, con su verbo y su escena.**

| Definición | Verbo | Escena con datos |
| --- | --- | --- |
| `T` | **contá**, y después **buscá el dueño** | Biblioteca: ejemplar contra estado de conservación |
| `A` | **preguntale a la cosa**, y después **intentá violarlo** | Obra: responsable del frente contra responsable en dos frentes |
| `V` | **buscá al que lo hace**, y después **imaginá que sale mal** | Municipio: otorgar la habilitación contra quedar habilitado |
| `C` | **subrayá el cuantificador** y **cambialo por otro** | Escuela: un preceptor por división contra veinticinco alumnos |
| `M` | **sacalo y leé lo que queda** | Taller: al retirar el vehículo |
| `R`, primera entrada | **contá el rechazo** en una oración | Biblioteca: socio con multa impaga |
| `R(estructura)`, segunda entrada | **subrayá la locución que ata** y mirá qué hay del otro lado | Banco: cuenta a nombre de titular contra cuenta con saldo |
| `E` | **buscá la función que desaparece** | Municipio: gestión de tasas |
| `?` | **pasá la compuerta** (tres preguntas) | Banco: «la cuenta correspondiente» contra «central» |
| `°` | **buscá la palabra que apunta** (lista cerrada) | Aerolínea: despacho de equipaje y «ese mismo momento» |
| `⟦ ⟧` | **leé el fragmento en voz alta** como frase única | Obra: «se comunica a la inspección» |
| `!` | **contá** los verbos y **contá** las etiquetas | Biblioteca: «un préstamo corresponde a un único ejemplar» |
| Terminación del paso 2 (§1.4) | **recorré los números del paso 1 y contá los que no tienen letra** | La numeración del paso 1, no las anotaciones propias |

**Los enunciados numéricos, que la versión 1.0 no auditaba.**

| Enunciado | Estado |
| --- | --- |
| «Cinco segundos por fragmento» (§1.2) | **Calibración declarada** (§10, límite 3). Es el único número de ritmo que sobrevive |
| «Tres segundos» del anillo, «diez segundos» de la compuerta, «media jornada» de la ficha de `E` | **Retirados.** Eran números derivados de una calibración, sin medición propia |
| «Cinco minutos» del criterio de fracaso (§1.1) | **Retirado**, y reemplazado por una prueba auditable sin cronómetro |
| «Cero, uno o dos `?` por párrafo» (§5.2) | **Retirado.** No discriminaba: la única corrida conocida se hizo sin compuerta y caía dentro de la banda. Reemplazado por la recuenta y el par `? levantados / ? sobrevividos` |
| «Alrededor de un diez por ciento de costo de elección» (§7.1) | **Retirado.** No coincidía con ningún modelo de costo del propio documento, y medía el costo de una letra que nunca se usó |

**Siete definiciones o criterios de la versión 1.0 fallaban la prueba, y las siete están reparadas:**
la rama `V°` de `°` (entregaba la operación de la anáfora con el veredicto del efecto), la letra `L`
(pedía un juicio que §4.1 declara no local), el signo `!` (usado cinco veces y sin definición), el
criterio de ampliación de §7.3 («se reconoce mirando, no razonando» no nombra ningún verbo), la
medida del `?` («tres o más **significa** que…» clasifica y no manda hacer nada), la condición de
terminación de §1.4 (se satisfacía trivialmente y dejaba pasar el fragmento salteado, que es el error
que este documento existe para evitar) y la doble grafía `C descriptiva` / `C(varios?)` (dos formas
para lo mismo, ninguna en la hoja de bolsillo).

**Auditoría de consolidación, pendiente y anotada acá porque va a hacer falta** (`Icono-Y-Ancla` §6):
cuando este documento se resuma para entrar en el techo de su categoría —la partición declarada en
§0.3 y en el control de cambios—, hay que verificar **qué operaciones se cayeron en el resumen**. Una
ficha que pierde su verbo al acortarse vuelve a ser un icono.

Punto de vigilancia declarado: la frase «el paso 2 es sucio a propósito» **es un icono** —comprime
un razonamiento en una fórmula memorable—, y por eso no va sola: §1.1 entrega la operación que la
sostiene, que es la tabla de asimetría de los dos errores, y §1.4 entrega la verificación contable.
Se la conserva como título porque abajo se desarrolla, que es el uso correcto según §3.4 del hermano.

### 11.3 Verificación de ofuscación

**Superada.** No se nombran clientes, credenciales, datos reales ni infraestructura. Los ocho
dominios de los ejemplos son genéricos e inventados. El enunciado de origen es material didáctico de
cátedra del propio autor, ya transcripto en el documento hermano de la bitácora, y acá se citan de él
sólo los siete fragmentos que el encargo entregó como banco de pruebas.

### 11.4 Cómo mejora este conocimiento

1. Cada corrida del paso 2 que produzca un fragmento que **ninguna de las ocho letras** rutee entra
   a §6 como caso octavo, y se lo somete al criterio de §7.3 —destino, reconocimiento, y recién
   entonces marca, nota o columna— antes de proponer letra nueva.
2. Cada par de etiquetas que se confunda en uso y no esté en la matriz de §4.2 entra a la matriz con
   su pregunta de desempate.
3. Cada corrida anota su par `? levantados / ? sobrevividos` y el total de fragmentos. A las cinco
   corridas se calcula la proporción y se decide si hay umbral. **Hasta entonces, no hay número.**
4. La nota `R(estructura)` se reevalúa después de su primera corrida real (límite 4 de §10),
   anotando **cuántas `R(estructura)` aparecieron**. Si la nota resulta insuficiente —si aparecen
   ataduras que no llegan a `R` por su propia operación—, `L` vuelve a discutirse con datos, que es
   la condición que hoy le falta.

### 11.5 Techo de categoría y partición declarada

**El documento está sobre el techo.** `Rules-Base-Conocimiento.md` §6.2 fija **600 líneas** para un
documento de naturaleza `propio`, y dice que superarlo «no se justifica: se parte el documento en
dos, y los dos se declaran hermanos en su §9». Éste está muy por encima.

**Por qué no se parte ahora.** Mientras lleve prefijo numérico y **no declare cabecera**, es un
borrador y el techo no lo alcanza: los dos hermanos que sí declaran cabecera están dentro del techo.
Y el recorrido de uso muestra que el archivo único funciona, porque lo que la persona hace es
**saltar dentro de un archivo** —once veces en una corrida—, y partir le pondría un archivo de por
medio en cada salto. Lo que sí cambia el uso es la inversión, y está hecha: la hoja de bolsillo va
primero.

**Qué se hace el día que se catalogue como `Knowledge-*`, y no antes.** Cabecera completa de
`Rules-Base-Conocimiento.md` §4.1 —`Alias`, `Naturaleza: propio`, `Tema`, `Consumidor`,
`Condicion-de-carga`, `Hereda-de`, `Sustituye`, `Compatible-con: Rules-Base-Conocimiento.md 2.2`,
`Versión`, `Estado`— y **partición obligatoria**, con este corte:

| Va a **A**, `Knowledge-Etiquetado-De-Fragmentos.md` (el instrumento) | Va a **B**, `Knowledge-Fundamentacion-Del-Etiquetado.md` (la referencia) |
| --- | --- |
| Encabezado, hoja de bolsillo, §0, §1, §2.1-§2.4, §3 en **ficha corta** (definición + «Cómo se aplica» + «Un caso» + «con qué se confunde»), §4.1, §4.3, §5 entero, §10 límites 2 y 3 | §2.3, §3 en **ficha larga** («Es / no es», preguntas de reconocimiento, ejemplos resueltos), §4.2, §6, §7, §8, §10 restante, §11 |

**A** conserva el consumo del paso 2 y es el que los hermanos referencian. **B** declara en su §9:
«no se usa durante una corrida; toda ficha presupone la definición y la operación de A, que no se
repiten acá». **A** declara en su §9 la partición, su motivo (`Rules-Base-Conocimiento.md` §6.2) y
que B no se lee con el lápiz en la mano.

**Advertencia dimensional honesta:** con las tablas de ejemplos en seis filas, B queda alrededor de
650 líneas y **sigue sobre el techo**; bajar los ejemplos a tres filas por ficha la cierra en torno a
520. Si se quieren conservar las seis filas, son **tres** documentos y hay que decirlo, no
absorberlo.

**Y la regla que evita la deriva, que rige desde ahora y no desde la partición: cada contenido vive
en un solo archivo.** El operativo no repite ningún argumento; el argumentativo no repite ninguna
definición ni ninguna glosa, y abre cada ficha citando `03 §3.n`. La única copia legítima es la hoja
de bolsillo, porque una hoja de bolsillo **es** una copia, y por eso está declarada **fuente única**
de las ocho glosas en §0.3: si una ficha y la hoja discrepan, manda la hoja. Y las cuatro preguntas
de desempate **se citan, no se reescriben**: la versión que manda es la de §4.3.

### 11.6 Control de cambios

| Versión | Fecha | Cambios |
| --- | --- | --- |
| 1.2 | 2026-09-28 | **Aplicación de los tramos 1, 3, 4 y 5 del acta** `../Mesa/06-Acta-Replanteo-Del-Modelo.md` §8.3. **El cambio de fondo:** la unidad de acumulación del método deja de ser el fragmento y pasa a ser el **referente**. **§0.1 corrige el contrato:** la tabla de términos deja de llenarse en el paso 3; se abre en el **paso 1** como **hoja del referente** —una por sustantivo del dominio— y se llena mientras se etiqueta. El paso 3 la **lee**, no la arma. El paso 2 gana una obligación que no es un paso más: además de la letra, **deposita** lo que el fragmento dice en un casillero —género, eje, miembros, momento, agente, alcance, definición—, con el número del fragmento al lado. **Tres afirmaciones falsas se retiran** (`P0`): la línea «sin conjunto de contraste, describe: `A`» de la hoja de bolsillo, el veredicto del **caso 6** del banco —«central» era `A` y es **`R`**, cuadrante `Q1`— y el párrafo de §8 que decía «no hay otros cascos → no hay de dónde recortar», que es falso: el conjunto no era *cascos* sino *instalaciones*. **El conjunto contra el que un modificador recorta no es la extensión de su sustantivo.** Con eso, el indicio 4 **deja de buscar y pasa a mirar** el casillero «género», el 3 cuenta la unicidad en «miembros», y entra la **regla de depósito del eje** (paralelismo) que llena el casillero que el 4 consulta. **La salida del paso 2 sobre un modificador deja de ser binaria:** `Q1 → R` o `R/A` · `Q2 → R°` · `Q3 → A`, o `R(estructura)` si ata dos cosas · `Q4 → T°`, y para poner `Q4` hay que **señalar el depósito anterior**. **La compuerta del `?` gana su segundo tramo** —*¿hay otro depósito en el mismo casillero que lo resuelva?*—, la recuenta de cierre gana una columna (`? n/total → m/total → k/total`) y el `?` **deja de ser terminal**: lo que no cierra queda **pendiente en la hoja**, con la nota `(abierta)`. Notación nueva, **sin ninguna letra nueva**: `A(dominio)` y `(abierta)`. El ejemplo del adjetivo que no recorta y sin embargo predica pasa a ser «la cámara **frigorífica**». Dos límites nuevos en §10. **Lo que expresamente no entra, para que nadie lo reponga:** las `AD-nn` como producto del paso 1 y las dos líneas de la hoja de bolsillo sobre ellas (`03-g` y `03-h`, que dependían de una pasada de recomposición que el acta retira), la nota `(AD)`, el registro de lecturas abiertas con sus nueve orígenes, y los signos `⟪ ⟫` y `≡` —el contraste ocurre en el casillero y no necesita signo, y §2.3 ya fundó por qué un signo nuevo se cobra en todos los fragmentos—. |
| 1.1 | 2026-09-26 | **Aplicación del acta de la mesa** `../Mesa/05-Acta-Catalogo-De-Etiquetas.md` (cinco cuestiones, C-1 a C-5). **C-1:** `L` no se adopta; las letras siguen siendo ocho y la distinción entra como nota `R(estructura)`, con destino en la Tabla 3 del paso 3, columna `Especie`. Se retira la ficha `L` y se renumeran §3.4 a §3.8. **C-2:** las marcas se adoptan con tres reparaciones —`°` sólo para anáfora con disparador de lista cerrada, `V°` retirado por ser letra encubierta, `⟦ ⟧` con estatuto de heredada del paso 1—, el signo `!` recibe ficha (§2.4) y destinatario, y el inventario de signos se cierra en una sola tabla (§0.2) con la forma única `letra(nota)`. La regla de ampliación de §7.3 se reformula con operación y tres salidas: marca, nota o columna. **C-3:** la hoja de bolsillo pasa al frente; se adopta la regla de copia única (§0.3) y se declara el corte de la partición futura, que se ejecuta al catalogar como `Knowledge-*`, no antes. **C-4:** la jerarquía de indicios se generaliza a todo modificador, con el indicio del determinante corregido a **unidireccional** —el indefinido no prueba nada, y la formulación anterior era un P0—, el filtro argumento/adjunto y el indicio de la posición del adjetivo; el parche se aplica en `02` §4.3 y §8 pasa a resumir, no a proponer. **C-5:** el umbral de `?` no se adopta; se reemplaza por la recuenta obligatoria al cierre y el par `? levantados / ? sobrevividos`, con la base declarada (n=1) y sin número hasta cinco corridas. Además: se rehace el banco de casos de §6 —de siete acusaciones de carencia sobreviven tres, y las filas declaran testimonio directo contra reconstrucción—, se corrigen los estatutos de procedencia de §0.3 y §11.1 —conjunto de contraste, generalización y compuerta son recibidos—, se reescribe la condición de terminación de §1.4, se retiran los números de ritmo sin medición y se corrige la aritmética y el alcance de §11.2. |
| 1.0 | 2026-09-26 | Emisión inicial. Desarrollo de la tabla de ocho etiquetas en catálogo de reconocimiento. Se propone la etiqueta `L` (liga) y se rechazan otras cuatro candidatas con criterio explícito; se introducen las marcas `°` y `⟦ ⟧`/`⟦?⟧`; se define `?` con su compuerta; se declara y sostiene la ley del paso sucio con la regla de los cinco segundos; se generaliza la jerarquía de indicios a todo modificador y se agrega el indicio del conjunto de contraste. Los siete casos observados quedan resueltos, con un residuo declarado en el caso 3 que se traslada como obligación al paso 3. |
