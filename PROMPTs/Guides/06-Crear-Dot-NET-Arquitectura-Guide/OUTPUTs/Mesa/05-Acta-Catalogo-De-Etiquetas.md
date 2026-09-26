# 05 — Acta de la mesa: el catálogo de etiquetas del paso 2

**Fecha:** 2026-09-26
**Objeto:** `OUTPUTs/Conocimientos/03-Catalogo-De-Etiquetas.md` v1.0, 1385 líneas
**Clase de objeto:** diseño de una norma (`Knowledge-Mesa-De-Expertos-A-Pedido.md` §2.2, tercera fila)
**Regla de cierre de esa clase:** un dictamen que responde **cada pregunta del pedido por separado**, sin «depende»
**Quién aplica:** quien el pedido designe. Esta acta **no modificó ningún archivo**: dice qué hay que cambiar y con qué texto.

> **Lo que la mesa resolvió, en una línea.** La propuesta acierta en el diagnóstico y se equivoca en el
> instrumento: lo que el paso 2 necesitaba no era una letra más, era **una nota sobre una letra que ya
> existía**. Las cinco cuestiones se deciden abajo; la novena letra no entra, las marcas sí con una
> reparación, el documento se da vuelta antes de partirse, la jerarquía se generaliza con una corrección
> gramatical que la propuesta traía mal, y el umbral del `?` se reemplaza por una magnitud que sobre la
> única corrida conocida da **rojo** donde el umbral daba verde.

---

## Índice

- [0. Convocatoria](#0-convocatoria)
- [1. Base mecánica](#1-base-mecánica)
- [2. C-1 — ¿Se adopta `L` como novena etiqueta?](#2-c-1--se-adopta-l-como-novena-etiqueta)
- [3. C-2 — ¿Se adoptan las marcas y la regla que las funda?](#3-c-2--se-adoptan-las-marcas-y-la-regla-que-las-funda)
- [4. C-3 — ¿El formato es el correcto?](#4-c-3--el-formato-es-el-correcto)
- [5. C-4 — ¿Se generaliza la jerarquía de indicios?](#5-c-4--se-generaliza-la-jerarquía-de-indicios)
- [6. C-5 — ¿Se adopta la medida contable del `?`?](#6-c-5--se-adopta-la-medida-contable-del-)
- [7. Auditoría `Icono-Y-Ancla` de la propia propuesta](#7-auditoría-icono-y-ancla-de-la-propia-propuesta)
- [8. Hallazgos fuera de las cinco cuestiones](#8-hallazgos-fuera-de-las-cinco-cuestiones)
- [9. Tabla de decisiones y orden de aplicación](#9-tabla-de-decisiones-y-orden-de-aplicación)
- [10. Deuda declarada y lo que la mesa no puede decidir](#10-deuda-declarada-y-lo-que-la-mesa-no-puede-decidir)

---

## 0. Convocatoria

### 0.1 Contrato de entrada

```text
PEDIDO: dictaminar sobre la propuesta de los editores para el paso 2 del taller de
        deducción de reglas de negocio, en cinco cuestiones cerradas. La mesa decide:
        lo que resuelva queda aprobado. No devuelve un abanico de opciones.
CLASE DE OBJETO: diseño de una norma
OBJETO:   OUTPUTs/Conocimientos/03-Catalogo-De-Etiquetas.md, 1385 líneas, v1.0 2026-09-26
OBJETIVO: que una persona con lápiz, en la mitad de la tarea, le ponga una letra a cada
          fragmento en cinco segundos y siga, sin que ningún fragmento quede en blanco
PREGUNTAS DEL CASO: C-1 a C-5 (una sección por cuestión, cada una con su parche)
RESTRICCIONES DURAS:
  - El destinatario es una persona, no un agente. Todo lo que vuelva deliberativo el
    paso lo destruye. Es el criterio de costo contra el que se mide cada agregado.
  - Knowledge-Deduccion-De-Reglas-De-Negocio.md está en 599 de 600 líneas: no absorbe nada.
  - Toda definición debe pasar la prueba de la operación de Knowledge-Icono-Y-Ancla.
DECISIONES CERRADAS: la ley del paso sucio (§1.1), la doble etiqueta (§1.3) y la
          compuerta del ? (§5) no se reabren: las tres tienen respaldo en la corrida.
FUERA DE ALCANCE: /IA/SDD/IA.SDD (sólo lectura), PROG2/, Interactive-Activities/docs/
          (cuaderno de una persona: se lee, no se escribe), el apunte y la guía interactiva.
MEDIOS: lectura del árbol y comandos sobre él. SIN OBSERVAR: ninguna corrida nueva del
          paso 2 sobre papel; toda afirmación de ritmo es calibración, no medición.
QUIÉN APLICA: quien el pedido designe. La mesa entrega los parches, no los aplica.
PRESUPUESTO: 7-8 hallazgos por comisión, una ronda, refutador último.
```

### 0.2 Panel, con su señal y los descartes

| Rol | Señal que lo convoca, con ubicación | Voto |
| --- | --- | --- |
| **Gramática del español** (ad hoc, con carta) | §8 del objeto y §4.3 del hermano: jerarquía de indicios, restrictivo/no restrictivo, anáfora, nominalización | Convocar |
| **Formal y de medición** | Umbrales numéricos: «cinco segundos» §1.2, «cero a dos `?`» §5.2, «diez por ciento» §7.1. Convocatoria automática | Convocar |
| **Diseño de notación y carga cognitiva** (ad hoc, con carta) | Nueve letras más cinco marcas sobre el mismo papel; el modelo de costo de §2.3 | Convocar |
| **Persona con lápiz** (usuario estándar) | El objeto declara su destinatario en el encabezado. Es la única que puede fundar un hallazgo de ritmo | Convocar |
| **Consultor de documentación y requisitos** | Citas cruzadas a `02` §4.3, a `Icono-Y-Ancla` y al banco de casos; techo de categoría | Convocar |
| **Refutador** | Núcleo permanente. Entra último y es el único que lee los informes | Convocar |

**Descartados, con su motivo:** *datos y dominio* —el objeto no modela entidades; lo cubre requisitos—;
*seguridad y privacidad* —sin señal—; *operación y entrega* —sin señal—; *rendimiento y costo* —el costo
acá es cognitivo y lo cubre la comisión de notación—.

**Quién no votó:** el presidente (consolida), el consultor de documentación (verifica citas, no emite
veredicto) y la persona con lápiz (su evidencia es el recorrido, no el juicio).

### 0.3 Cómo se leen los informes en esta acta

Las cinco comisiones trabajaron **a ciegas y en paralelo**; el refutador entró después y fue el único
que las leyó. **El presidente verificó todo dato antes de asentarlo**, y en dos lugares el resultado
contradice a tres comisiones a la vez: está en §8.1 y es el hallazgo metodológico de la corrida.

---

## 1. Base mecánica

Medido antes de que nadie opine. Cada dato con su comando y su salida.

| # | Dato | Comando | Salida |
| --- | --- | --- | --- |
| M-1 | Tamaño del objeto | `wc -l 03-Catalogo-De-Etiquetas.md` | **1385** |
| M-2 | Tamaño de los hermanos | `wc -l 02-… Knowledge-Deduccion-… Knowledge-Icono-…` | 822 · **599** · 266 |
| M-3 | Techo de categoría | `Rules-Base-Conocimiento.md` §6.2 | **600** líneas para `propio`; «superar el techo **no se justifica: se parte el documento en dos**, y los dos se declaran hermanos en su §9» |
| M-4 | Fragmentos de la corrida observada | `grep -c "^[0-9][0-9]\.[a-z]\.[0-9]" Actividad-1-…md` | **13** |
| M-5 | `?` en la corrida | `grep -n "? *\]" Actividad-1-…md` | **1** (`02.a.4`, «central»), retractado después por ilegítimo |
| M-6 | Ligas en la corrida | inspección de las 13 líneas | **2**: `01.b.2` «compuesta por al menos un campo» → `R+C`; `02.a.5` «a cargo de un Administrador» → `R` |
| M-7 | Destinos del paso 3 | `Mis-Notas.md` l. 270-283 y paso 3 de `Actividad-1` | **Tres tablas**: T1 *(T, A)*, T2 *(V, M)*, T3 *(R, C, E)*. Ninguna recibe `L`. T3 tiene columna **`Especie`** |
| M-8 | La palabra «modificador» en el hermano | `grep -ic "modificador" 02-Criterio-De-Segmentacion.md` | **0** |
| M-9 | Indicios de `02` §4.3 | `sed -n '542,556p' 02-… \| grep -c "^\| [0-9]"` | **6**, bajo el título «para desempatar **una relativa**» |
| M-10 | La marca `!` en la notación | inspección de §0.2 del objeto y §0.4 del hermano | **Ausente de las dos**, y usada cinco veces en el cuerpo del objeto |

**Lo que falla y entra con ancla E1 antes de deliberar:** M-1 contra M-3 (el objeto está a **231 %** del
techo de su categoría, sin invocar la única excepción que la regla admite) y M-10 (una marca en uso sin
entrada en ninguna tabla de notación).

---

## 2. C-1 — ¿Se adopta `L` como novena etiqueta?

### 2.1 Las dos posiciones, con su evidencia

| | **A favor de `L`** (la propuesta, §7.2) | **En contra** (notación, gramática, refutador) |
| --- | --- | --- |
| Destino | «Hay un destino sin etiqueta»: el paso 3 tiene tres tablas y la liga no va a ninguna | **E2/M-7.** El destino **existe**: la Tabla 3 recibe `R` y tiene columna `Especie`, cuyo valor `estructura` ya está definido en el material de origen («Rechaza una *composición*, no una operación → es **estructura**») |
| Evidencia de uso | «En uso real terminó en `R` **a falta de algo mejor**» | **E2.** El material da una razón positiva, no una resignación: «no corta… pero **sí contiene una afirmación**: todo casco tiene alguien a cargo. **Por eso va `R`**… Es el caso del calificador que aporta un hecho» |
| Frecuencia | «Es frecuente, no marginal»: dos de los siete casos | **E2.** Cierto en la cuenta (M-6: 2 de 13 fragmentos), **falso en uno de los dos casos citados**: el §6 declara que «compuesta por al menos un campo» no tenía «ninguna clara» con las ocho letras, y el material lo etiqueta `R+C` dos veces, en dos dominios distintos |
| Costo de reconocimiento | «Se reconoce mirando, no razonando: `L` se ve en la preposición» | **E2.** La operación escrita en §3.4 **no es ésa**: pide decidir si la punta derecha es «un valor o una ficha», que es el juicio `T`/`A` que §4.1 declara indecidible con el fragmento delante («la información que decide esto está en otros fragmentos, no en éste») |
| Costo aguas abajo | «Mover un error del paso 4 al paso 2 es siempre buen negocio» | **E2.** `L` obliga a una **cuarta tabla** (§7.5 obligación 1) en un paso 3 cuyo texto se titula «**Recién ahora, tres tablas. No una.**» — y ese documento es el cuaderno de una persona, que esta mesa no puede editar |
| Qué se pierde | — | **E2.** Con `L/C`, la afirmación que hoy la `R` transporta —*todo casco tiene alguien a cargo*— **desaparece del paso 2**, y el propio objeto lo admite como «residuo honesto» que delega en una obligación que nadie aceptó |

**Lo que hay que reconocer del lado de `L`, y la mesa lo reconoce:** el diagnóstico es correcto. Cuando
`R` contiene reglas verificables y afirmaciones estructurales sin distinguirlas, el paso 4 corre el
análisis completo —especie, momento, dueño, prueba— sobre algo que no es una regla. Eso es trabajo real
perdido y hay que resolverlo.

**Lo que hay que reconocer del lado contrario:** el instrumento elegido cuesta un candidato más en los
trece fragmentos, exige un juicio no local, y crea una tabla en un documento ajeno.

### 2.2 Decisión

> **No se adopta `L` como novena etiqueta. Se adopta la distinción que `L` venía a hacer, como una
> nota de una palabra sobre `R`: `R(estructura)`. Las letras siguen siendo ocho.**
>
> **Destino en el paso 3, fijado y existente:** la Tabla 3, con la columna `Especie` en valor
> `estructura`. **Ninguna tabla nueva, ningún cambio en el documento del paso 3.**

**Fundamento.** Es la aplicación honesta del criterio que la propia propuesta enuncia en su §7.2 y que
usó mal en su único caso: *marca cuando la letra es correcta pero incompleta; letra cuando no hay letra
correcta*. `R` **es** correcta —lo dice el material, con doctrina y nombre: «el calificador que aporta un
hecho»— y está **incompleta**: no dice de qué clase es la afirmación. Eso es exactamente una nota, no una
letra. Y la nota se paga donde el §2.3 dice que se paga una marca: después de haber elegido la letra,
sobre una pregunta binaria, sin competir con nada.

**Qué gana la persona:** nada nuevo que aprender en el momento de elegir; ocho candidatas, no nueve.
**Qué gana el paso 4:** el ahorro completo que `L` prometía —la fila llega con su especie escrita y no se
le corre el análisis de regla—. **Qué no se pierde:** la afirmación estructural sigue viajando, que es lo
que con `L/C` se perdía.

**Voto del jurado.** Evidencia: `PROCEDE` —la base de `L` está mal leída en dos de sus tres patas—.
Impacto: `PROCEDE` —con `L`, el hecho estructural del caso 3 sale del paso 2—. Costo/beneficio:
`PROCEDE` —la nota captura el beneficio a costo cero—. Coherencia histórica: `PROCEDE` —no reabre la ley
del paso sucio; la aplica—. Riesgo: `PROCEDE` —reversible: si una corrida futura muestra que la nota no
alcanza, `L` vuelve a discutirse con datos—. **5-0.**

### 2.3 Parche textual

**P-1.a — En `03` §3.7, agregar una fila a «Es `R`»** (después de «Una unicidad, un mínimo o un máximo
exigibles»):

```markdown
| Una **atadura** entre dos cosas del negocio, aunque no puedas contar el rechazo: va a la misma tabla con la nota `(estructura)` | Una relación con un **valor** y no con otra cosa del negocio → `A` |
```

**P-1.b — En `03` §3.7, agregar al final de «Cómo se aplica»:**

```markdown
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
```

**P-1.c — Eliminar `L`** de: §0.2 (tabla de notación), §3.4 completa (la ficha se reemplaza por P-1.a y
P-1.b), §4.2 (columna y fila `L` de la matriz), §4.3 (la pregunta 4 se conserva con otro resultado, ver
P-1.d), §7.1, §7.2, §7.5 obligación 1, §9 (hoja de bolsillo), §10 límite 4, §11.2 y §11.4 punto 4.

**P-1.d — En `03` §4.3, la cuarta pregunta cambia de resultado:**

```markdown
| 4 | **¿Hay dos cosas del negocio acá adentro?** | Si sí y no podés contar el rechazo: `R(estructura)` |
```

**P-1.e — En `03` §7.5, la obligación 1 se reemplaza:**

```markdown
| 1 | **Asentar la especie de las `R`**: toda `R(estructura)` entra a la Tabla 3 con `Especie: estructura`, y el paso 4 no le corre el análisis de regla completo | El paso 4 analiza como prohibición lo que es la forma del modelo, que es el trabajo que esta nota existe para ahorrar |
```

---

## 3. C-2 — ¿Se adoptan las marcas y la regla que las funda?

### 3.1 La regla que las funda

**Enunciado propuesto:** *letra nueva sólo si rutea a un destino que ninguna otra rutea y se reconoce
mirando, no razonando; si el destino ya existe, es una marca.*

**Qué está bien:** la primera cláusula es un ancla —*listá los destinos del paso 3 y fijate si alguno la
recibe*, verbo de acción, respuesta verificable—. Y la regla, aplicada con honestidad, **rechaza `L`**
(§2), que es la mejor prueba de que sirve.

**Qué está mal, y son dos cosas:**

1. **«Se reconoce mirando, no razonando» es un icono.** No nombra ningún verbo que el lector ejecute, y
   el objeto la usó para dar por aprobada a `L` sin correr nada.
2. **La segunda cláusula tiene dos salidas y hacen falta tres.** «Si el destino ya existe, es una marca»
   no se sigue: puede ser una marca, pero también una **nota** o una **columna** —que es lo que resultó
   ser `L`—.

**Decisión: se adopta reformulada.**

**P-2.a — En `03` §7.3, reemplazar el bloque final por:**

```markdown
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
```

### 3.2 ¿Son letras encubiertas?

**Prueba adoptada** (de la comisión de notación, verificada por el presidente):

> Una marca es **letra encubierta** si hay que decidirla **contra alternativas, fragmento por
> fragmento**, antes de que la anotación esté completa.

Corrida sobre las marcas del objeto:

| Marca | ¿Compite? | Veredicto |
| --- | --- | --- |
| `⟦ ⟧` restitución | No: la restitución salió o no salió | **No es letra encubierta** |
| `⟦?⟧` restitución fallida | No: es el resultado de que no salió | **No es letra encubierta** |
| `!` fragmento mal cortado | No: es un resultado | **No es letra encubierta** —pero no está definida, ver §8.4— |
| `X/Y` doble etiqueta | No: **quita** una decisión en vez de agregarla | **No es letra encubierta.** Es la mejor pieza del documento |
| `°` **anáfora** (`M°`, `T°`) | No, si el disparador es de superficie | **No es letra encubierta**, con la reparación de abajo |
| `°` **efecto** (`V°`) | **Sí**: hay que decidir poner o no poner sobre cualquier fragmento que pudiera ser efecto, y no se sabe cuáles son sin razonar sobre el acto vecino | **Sí lo es. Se retira** |

**El dato que decide el `V°`, y es E2 del material observado:** el método de origen decide **a propósito**
no distinguir acto de efecto durante el etiquetado —«la dejo en `V` a propósito, aunque acabo de decirte
que es un efecto. El paso 2 es sucio por diseño… la distinción acto/efecto **se resuelve al armar la
tabla 2, no ahora**. Si te ponés a decidirlo fragmento por fragmento no terminás más»— y ya tiene resuelto
dónde se paga: «En la tabla 2, `conformación` es **una fila** con la columna "qué cambia" acumulando los
cuatro efectos… **no se duplica el acto, se acumulan los efectos**».

De modo que el daño que el §6 caso 1 atribuye a las ocho letras —«y la tabla de actos duplica»— **no
ocurre**: el paso 3 lo previene. `V°` no arregla nada y contradice la ley que gobierna el documento.

**Segundo dato, independiente:** la operación escrita en §2.1 —«preguntale al fragmento **si nombra algo
por primera vez**»— aplicada a «se establece un casco central» contesta *sí* y **no produce el `V°`** que
el §6 declara. La ficha entrega la operación de la anáfora y le adosa el veredicto del efecto. Es un
icono con ancla prestada.

### 3.3 Decisión

> **Se adoptan las marcas, con tres reparaciones:**
>
> 1. **`°` queda sólo para la anáfora** (`M°`, `T°`), con disparador de **lista cerrada de superficie**.
>    **`V°` se retira**: la fusión acto/efecto la hace el paso 3 acumulando efectos en la fila del acto,
>    como ya hace.
> 2. **`⟦ ⟧` y `⟦?⟧` se adoptan con el estatuto corregido**: `⟦ ⟧` es **heredada** del paso 1 (`02` §0.4 y
>    P7, que ya restituye sujetos tácitos y agentes de pasiva). Lo propio del paso 2 es `⟦?⟧` **como
>    distinto de `?`** y la tabla de dónde se cobra el hueco (§5.4), que es el mejor aporte del documento.
> 3. **`!` se adopta como marca declarada**, con definición, operación y **destinatario** —hoy se le pide
>    a la persona que la escriba y no se dice quién la lee—.
>
> **Y el inventario de signos se cierra:** una sola tabla, en §0.2, idéntica a la de la hoja de bolsillo.
> Todo lo demás que hoy flota —`C(varios?)`, `C descriptiva`, `?(razón)`, `⟦?ámbito⟧`— se unifica bajo
> **una** forma: `letra(nota de hasta tres palabras)`, que nunca rutea.

**Voto del jurado.** Evidencia 5-0 sobre el retiro de `V°` (E2 directa del material). Impacto 5-0 sobre
`!` (es el único canal del paso 2 hacia el paso 1 y hoy no tiene destinatario). Costo/beneficio 4-1 sobre
cerrar el inventario —el juez de costo objeta que renombrar `C descriptiva` toca tres lugares; se aplica
igual porque la hoja de bolsillo, que es lo que la persona usa, hoy no contempla ninguna de las dos
grafías—. Coherencia 5-0. Riesgo 5-0, todo reversible.

### 3.4 Parche textual

**P-2.b — `03` §2, título:** «Las dos marcas, y por qué no son letras» → **«Las marcas, y por qué no son
letras»**.

**P-2.c — `03` §2.1, reemplazar la ficha del anillo por:**

```markdown
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
```

**P-2.d — `03` §2.2, agregar al final:**

```markdown
**De dónde vienen los corchetes, y qué agrega el paso 2.** La marca `⟦ ⟧` **no es de acá**: la trae el
paso 1 (`02` §0.4), cuyo P7 ya restituye verbos elididos, sujetos tácitos, **agentes de pasivas e
impersonales con «se»** y antecedentes. Si el paso 1 cumplió, el fragmento **llega con los corchetes
puestos y vos los leés**. Cuando falte uno, lo agregás y ponés `!`: es un aviso sobre el corte, igual
que un fragmento gordo. **Lo propio del paso 2** es la distinción entre `?` y `⟦?⟧` (§5.4) y la tabla
de en qué letras se cobra el hueco.
```

**P-2.e — `03` §0.2, agregar la fila que falta y unificar las notas:**

```markdown
| `!` | **Aviso sobre el corte.** El fragmento vino gordo o mal delimitado del paso 1. Se escribe al margen, junto a la letra. **No se vuelve al paso 1** | §2.4 |
| `letra(nota)` | **Una nota tuya de hasta tres palabras**, pegada a la letra: `R(estructura)`, `C(describe)`, `?(dos lecturas)`. **Nunca rutea**: la letra manda | §0.2 |
| `+` | Si escribís `T+A` en vez de `T/A`, es lo mismo. El paso 3 lee las dos formas | §1.3 |
```

**P-2.f — `03`, sección nueva §2.4, la ficha de `!`:**

```markdown
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
```

**P-2.g — Retirar `V°`** de §2.1 (hecho en P-2.c), §3.3 —tabla «Es / no es», pregunta de
reconocimiento «¿Puede fallar?», y el ejemplo «el equipaje queda registrado»—, §6 caso 1, §7.3 (fila
«Efecto») y §9. En §3.3, la pregunta «¿Puede fallar?» se conserva **como prueba de que es acto**, sin la
consecuencia `V°`.

**P-2.h — `C descriptiva` → `C(describe)`** en §3.5 (tabla de ejemplos) y en §3.7; `C(varios?)` →
`C(dudoso)` o la forma genérica de P-2.e, una sola grafía en todo el documento.

---

## 4. C-3 — ¿El formato es el correcto?

### 4.1 Las dos posiciones

**El consultor de documentación:** partir en dos, por E4 —`Rules-Base-Conocimiento.md` §6.2, 600 líneas,
«superar el techo no se justifica: se parte el documento en dos»— y porque la hoja de bolsillo está en la
línea **1261 de 1385**.

**El refutador:** no partir. Tres argumentos, los tres con ancla: (a) el techo se indexa por
`Naturaleza:`, y el objeto **no declara cabecera** —los dos documentos que sí la declaran están en 599 y
266, o sea que alguien ya respetó el techo donde rige—; (b) las cuatro preguntas de desempate ya están
**repetidas cuatro veces dentro del archivo** y partir convierte una duplicación que un `grep` encuentra
en una que nadie va a correr; (c) el valor práctico no viene de partir sino de **mover un bloque**.

**La evidencia que desempata, y no la trajo ninguno de los dos: el recorrido de la persona con lápiz.**
Etiquetó 16 fragmentos frescos. Entró por la lista de títulos, saltó a §9 y empezó: **85 líneas leídas de
1385 antes de la primera letra**. Trabajó con §9 al lado **y con nada más**, y abrió **once secciones por
consulta puntual** —§2.1, §2.2, §3.4, §3.5, §3.7, §3.8, §4.1, §5.2, §5.4, §6, §8—. Nunca abrió §0, §1,
§3.1, §3.2, §3.3, §3.9, §7, §10 ni §11. Y a la pregunta de qué se llevaría impreso: «la hoja de bolsillo
tal cual, y detrás, la tabla *Es / No es* de `C` y la de `E`».

Ese recorrido dice dos cosas que corrigen a las dos posiciones. Contra el consultor: **el archivo único
funcionó**, porque lo que ella hizo once veces fue *saltar dentro de un archivo*, y partir le habría
puesto un archivo de por medio en cada salto. Contra el refutador: **la inversión no alcanza como único
cambio**, porque supo que §9 existía por el encargo, no por el documento.

### 4.2 Decisión

> **Las dos cosas, en dos momentos, y con una regla que hace imposible la deriva.**
>
> **Ahora, y es lo que cambia el uso: se invierte.** La hoja de bolsillo pasa al frente, inmediatamente
> después de la frase que gobierna el documento, antes del índice. El índice abre con una línea que dice
> a dónde ir si estás etiquetando. Un bloque movido, cero duplicación nueva.
>
> **Al catalogarlo como `Knowledge-*`, y no antes: se parte.** El techo de 600 rige sobre un documento
> `propio`, y este documento está destinado a serlo —es el encargo que lo originó—. Mientras tenga
> prefijo numérico y no declare cabecera es un borrador, y el techo no lo alcanza; el día que se
> catalogue, lo alcanza entero y la partición es obligatoria, no opcional.
>
> **La regla que evita la deriva, y es la decisión que ninguna de las dos posiciones traía: cada
> contenido vive en un solo archivo.** El operativo no repite ningún argumento; el argumentativo no
> repite ninguna definición ni ninguna glosa, y abre cada ficha citando `03 §3.n`. La única copia
> legítima de todo el conjunto es la hoja de bolsillo, porque una hoja de bolsillo **es** una copia, y
> por eso se declara **fuente única** de las nueve glosas: la que manda es la de §9 y las fichas se
> ajustan a ella, no al revés.

**Y una consecuencia que la mesa asienta ahora, porque hoy ya duele:** las cuatro preguntas de desempate
están escritas cuatro veces (§4.1, §4.3, §5.2 y §9) y **ya divergen** —§5.2 imprime la jerarquía de
modificadores en un orden y §8 la argumenta en otro (§5.3 de esta acta)—. La regla de copia única se
aplica **antes** de partir, no después: §4.1 y §5.2 **remiten** a §4.3, no la reescriben.

**Voto del jurado.** Evidencia 5-0 (M-1 contra M-3, más el recorrido). Impacto 5-0 sobre la inversión.
Costo/beneficio 4-1 sobre partir: el juez de costo vota `NO_PROCEDE` por el riesgo de deriva, y el
argumento se absorbe en la regla de copia única en vez de descartarse. Coherencia 5-0. Riesgo 5-0 con la
condición de que la partición se haga **con** la regla de copia única y no sin ella.

### 4.3 Parche textual

**P-3.a — Mover** el bloque de §9 (hoja de bolsillo, con su valla de código) a continuación de la cita
que gobierna el documento, antes del índice. Donde estaba, dejar:

```markdown
## 9. Hoja de bolsillo

Está al principio del documento, que es donde la necesitás. Si llegaste hasta acá leyendo, ya no la
necesitás: volvé arriba y llevatela impresa.
```

**P-3.b — Encabezado**: reemplazar «que tiene que decidir en diez segundos y seguir» por «que tiene que
decidir **en cinco segundos** y seguir», y agregar como primera línea después del título:

```markdown
> **Si estás etiquetando ahora mismo, no leas esto: llevate la hoja de bolsillo de acá abajo y volvé
> cuando una letra se te resista.** El resto del documento es la referencia que explica por qué cada
> ficha dice lo que dice.
```

**P-3.c — Regla de copia única, en §0.3**, fila nueva:

```markdown
| La hoja de bolsillo | **Fuente única** de las nueve glosas de una línea. Si una ficha de §3 y la hoja discrepan, **manda la hoja**, y la ficha se corrige. Ninguna otra parte del documento reescribe las cuatro preguntas de §4.3: las cita |
```

**P-3.d — Al catalogar** (no antes): cabecera completa de `Rules-Base-Conocimiento.md` §4.1 —`Alias`,
`Naturaleza: propio`, `Tema`, `Consumidor`, `Condicion-de-carga`, `Hereda-de`, `Sustituye`,
`Compatible-con: Rules-Base-Conocimiento.md 2.2`, `Versión`, `Estado`— y partición con este corte:

| Va a **A**, `Knowledge-Etiquetado-De-Fragmentos.md` (el instrumento) | Va a **B**, `Knowledge-Fundamentacion-Del-Etiquetado.md` (la referencia) |
| --- | --- |
| Encabezado, hoja de bolsillo, §0, §1, §2.1-§2.4, §3 en **ficha corta** (definición + «Cómo se aplica» + «Un caso» + «con qué se confunde»), §4.1, §4.3, §5 entero, §10 límites 2 y 3 | §2.3, §3 en **ficha larga** («Es / no es», preguntas de reconocimiento, ejemplos resueltos), §4.2, §6, §7, §8, §10 restante, §11 |

**A** conserva el consumo del paso 2 y es el que los hermanos referencian. **B** declara en su §9: «no se
usa durante una corrida; toda ficha presupone la definición y la operación de A, que no se repiten acá».
**A** declara en su §9 la partición, su motivo (`Rules-Base-Conocimiento.md` §6.2) y que B no se lee con
el lápiz en la mano. **Advertencia dimensional honesta:** con las tablas de ejemplos en seis filas, B
queda alrededor de 650 líneas y **sigue sobre el techo**; bajar los ejemplos a tres filas por ficha la
cierra en torno a 520. Si se quieren conservar las seis filas, son **tres** documentos y hay que decirlo,
no absorberlo.

---

## 5. C-4 — ¿Se generaliza la jerarquía de indicios a todo modificador?

### 5.1 Decisión

> **Sí, y es la cuestión con la evidencia más limpia de las cinco: la jerarquía existía, resolvía el caso
> y nadie fue a buscarla porque estaba titulada por una estructura gramatical y no por su función.**
> `grep -ic "modificador"` sobre el paso 1 devuelve **0** (M-8).
>
> **Pero la versión propuesta en §8 no se adopta tal cual: trae un error gramatical que cambia
> resultados**, y no arregla la causa verificada del defecto, que fue de **acceso** y no de contenido.

**El error, y es P0.** El indicio 1 propuesto dice: «*todo, cada, los… que, sólo los, ningún, aquellos* →
restringe. ***Un, una, unos* → describe**», rotulado «Del §4.3 original». El original **no menciona
indefinidos** y está atenuado («casi con seguridad»). El indicio del determinante es **unidireccional**: el
universal pide restricción, el indefinido **no prueba nada**.

**Tres contraejemplos, y dos son del propio catálogo:**

- «Un socio moroso no puede retirar ejemplares» → indefinido, y *moroso* **restringe**. Con el indicio
  propuesto sale `A` donde va `R`: el par que el propio documento llama «la más cara».
- §3.4 del objeto, su ejemplo insignia: «**una** cuenta a nombre de **un** titular» — el indicio 1 manda a
  «describe» y contradice a la ficha que lo aloja.
- §3.7 del objeto: «**un** socio con multa impaga no puede retirar ejemplares» → `R`, con indefinido.

Y la propuesta afirma en §8 que el cambio «no altera ninguna decisión ya tomada por ese documento». **Sí
la altera**: «un lote que supere las 200 hectáreas se subdivide» es una especificativa bajo indefinido —la
fila 17 del paso 1—, y con el indicio ampliado se lee «describe» → explicativa → **corta**, que es la
afirmación universal falsa que el paso 1 está escrito para evitar.

**Lo que falta.** Ningún indicio propio del adjetivo, que es la estructura que la sección viene a cubrir;
y ningún filtro que separe el **modificador** del **argumento** —«el nombre **del encargado**», «la
administración **de los campos**» no restringen ni describen: saturan una casilla, y la jerarquía no se
les aplica—.

**Lo que hay que suscribir sin reservas:** el **conjunto de contraste** es un buen indicio y **ponerlo
delante de la supresión es el acierto del parche**: es el único que obliga a *nombrar* un referente,
mientras que la supresión se contesta por impresión y con un adjetivo de una palabra resbala.

**Estatuto, corregido:** el conjunto de contraste **no es agregado propio del catálogo**. Está en el
material observado, con su nombre, su formulación y su aplicación al mismo caso: «**Un adjetivo restringe
solo si existe un conjunto de contraste del cual recortar**… "un casco central" → no hay otros cascos en
el discurso. No hay de dónde recortar». Lo propio es la **formalización** y el lugar en el orden.

**Voto del jurado.** Evidencia 5-0. Impacto 5-0 (el indicio mal escrito alimenta el par más caro).
Costo/beneficio 5-0. Coherencia 5-0. Riesgo 4-1: el juez de riesgo advierte que el parche agrega ~60
líneas a un documento que ya está en 822; se aplica igual y la deuda queda declarada en §10.

### 5.2 Parche textual exacto sobre `02-Criterio-De-Segmentacion.md` §4.3

**Título y encabezado** (reemplaza las tres primeras líneas de §4.3):

```markdown
### 4.3 ¿Este modificador restringe o describe?

**Criterio propio.** Vale para **todo lo que cuelgue de un sustantivo**: relativas, adjetivos,
complementos preposicionales y aposiciones. La distinción restrictivo / no restrictivo no es una
propiedad de la relativa: es una propiedad de la **relación de modificación** *(doctrina corriente,
sin cotejo)*. Se aplican en orden y **el primero que resuelve, manda**. La puntuación entra recién
en sexto lugar.

**Antes de empezar: ¿es modificador o es argumento?** Si el núcleo es un sustantivo **relacional o
deverbal** y el segmento llena su casilla —«el nombre **del encargado**», «la administración **de los
campos**», «la firma **del administrador**»—, **no entra en esta jerarquía**: no restringe ni
describe, satura un argumento. Se registra con su núcleo y, si es deverbal, va a §3.5. Sólo entra lo
que se le puede **sacar** al núcleo dejándolo en pie.
```

**Tabla** (reemplaza las seis filas actuales):

```markdown
| Orden | Indicio | Cómo decide | Vale para | Estatuto |
| --- | --- | --- | --- | --- |
| 1 | **Posición del adjetivo** | **Antepuesto** al sustantivo —*un amplio casco*, *el mencionado plazo*, *la citada parcela*— → **describe**. Unidireccional: **pospuesto no prueba nada** | sólo adjetivos | Nuevo. Doctrina corriente sobre la posición del adjetivo, sin cotejo |
| 2 | **Determinante del antecedente** | *todo, cada, los… que, aquellos… que, sólo los, ningún* → **restringe**, casi con seguridad: el determinante universal pide restricción. Unidireccional: ***un, una, unos* no prueba que describa** —«un socio moroso no puede retirar ejemplares» restringe bajo indefinido— | todos | Del §4.3 original, con su alcance explicitado |
| 3 | **Unicidad referencial** | Nombre propio, referente único en el dominio o ya identificado, posesivo identificador → **describe**: lo único no se recorta | todos | Del §4.3 original |
| 4 | **Conjunto de contraste — «¿contra cuál?»** | Nombrá, en el texto o en el dominio, **al menos un ejemplar** del que el modificador distinga. No podés nombrarlo → **describe**. Podés → **restringe**. Es el único indicio que concluye en las dos direcciones, y el único que exige nombrar algo | todos | Del material observado, formalizado acá |
| 5 | **Prueba de la supresión** | Suprimí el modificador: ¿el antecedente designa el mismo conjunto? Mismo → describe; más grande → restringe. **Con un adjetivo de una palabra no concluye**: úsese con relativas y complementos largos | relativas, complementos | Del §4.3 original, con su límite declarado |
| 6 | **Puntuación del autor** | Entre comas → describe; sin comas → restringe. **Sólo si 1 a 5 no resolvieron, y sólo en estructuras que admiten inciso**. Un adjetivo pospuesto sin comas está en su posición no marcada: no informa | relativas, aposiciones, complementos | Del §4.3 original, con su límite declarado |
| 7 | **Consistencia interna del documento** | Cómo puntúa el mismo autor un caso inequívoco en otro párrafo. Puntúa bien → el 6 sube de valor; puntúa mal → el 6 se descarta | todos | Del §4.3 original |
| 8 | **Regla de cierre** | Si nada resolvió: **restringe, no se corta, se marca `?`**. Es el error barato (§3.2) | todos | Del §4.3 original |
```

**Qué se hace con el resultado** (bloque nuevo, al pie de la tabla):

```markdown
**Y no es simétrico.**
**Restringe** → `⟨C-restr⟩`: es el **alcance** de la afirmación, no se corta.
**Describe** → **no es inerte**: predica algo aparte. Relativa explicativa → **corta** con restitución
del antecedente (fila 16). Adjetivo o complemento → se queda con el término, pero **aporta un hecho
propio** —una cualidad, o una atadura con otra cosa del negocio— y va al glosario o al inventario de
relaciones. Un modificador no restrictivo nunca se descarta por no restringir.
```

**Ejemplos** (bloque nuevo, uno por estructura, al pie):

```markdown
> **Adjetivo, no restrictivo.** «se establece un casco **central**». Indicio 1: pospuesto, no concluye.
> Indicio 2: indefinido, **no prueba nada**. Indicio 3: el discurso trata el casco como único →
> **describe**. Confirma el 4: ¿central contra cuál? No hay cascos no centrales en ninguna parte.
> *La supresión no se usa: con un adjetivo de una palabra resbala.*
>
> **Adjetivo bajo indefinido, restrictivo —el caso que el determinante no resuelve.** «Un socio
> **moroso** no puede retirar ejemplares.» Indicios 1 y 2 no concluyen. Indicio 4: ¿moroso contra cuál?
> Contra el socio al día, que existe y se trata distinto → **restringe** → `⟨C-restr⟩`.
>
> **Complemento preposicional, restrictivo.** «El personal **de la estancia** se aloja en el casco.»
> Núcleo no relacional: entra. Indicio 4: contra el personal contratado por terceros → **restringe**.
>
> **Complemento preposicional, no restrictivo y con contenido.** «un casco **a cargo de un
> Administrador**.» Indicio 3: el casco es único → **describe**. No abre `C-restr`, **y sin embargo
> predica**: ata el casco con un Administrador, y eso va al inventario de relaciones.
>
> **Complemento argumental, que no entra.** «el nombre **del encargado**». «Nombre» es relacional: el
> *de*-sintagma llena su casilla. No se le pregunta si restringe.
>
> **Relativa, para que siga sirviendo donde ya servía.** «Los lotes, **que superan las 200 hectáreas**,
> se subdividen.» Indicio 2: «los… que» → restringe, aunque la puntuación diga lo contrario.
```

### 5.3 Lo que hay que tocar además, o el parche no se encuentra

**Es la parte que la propuesta no traía, y es la causa verificada del defecto.** El criterio no faltaba:
no se encontró.

| # | Dónde | Qué |
| --- | --- | --- |
| 1 | `02` §4, **título del capítulo contenedor** | Hoy es «Puntuación: indicio derrotable, no prueba». Quien mira un adjetivo no tiene un problema de puntuación y no abre ese capítulo. Pasa a «**Modificadores y puntuación: qué restringe, qué describe y qué no prueba nada**», o §4.3 se promueve a sección propia. **Sin esto, retitular la subsección no cambia nada** |
| 2 | `02` §5, **procedimiento** — el que más rinde | Hoy P5 resuelve relativas y **no hay ningún paso que mire los modificadores del grupo nominal**. Agregar **P5-bis. Resolver los modificadores**: «para cada adjetivo, complemento preposicional o aposición que cuelgue de un sustantivo del dominio: filtro argumento/adjunto, y jerarquía de §4.3. Restringe → `⟨C-restr⟩`. Describe → se queda con el término y se registra lo que aporta». Y en P11, a la lista de control: «ningún modificador quedó sin pasar por §4.3» |
| 3 | `02` §2.3 y §2.5 | Encabezado y filas 16-18 apuntan a §4.3 por su nombre nuevo. **Dos filas nuevas** en §2.5: *adjetivo modificador de un sustantivo del dominio* y *complemento preposicional adjunto*, las dos **NO corta**, tratamiento «§4.3». Y las filas 30-31 (aposición explicativa / especificativa) **citan §4.3**: son la misma distinción y hoy no la citan |
| 4 | `02` §0.3 y §3.2 | La fila de estatuto pasa de «relativas» a «modificadores», y se agregan las dos filas nuevas con su estatuto. **§3.2 enumera el orden en prosa** —«primero el determinante, después la unicidad, después la supresión»— y hay que reescribirlo con el orden nuevo, o quedan dos jerarquías contradictorias en el mismo archivo |
| 5 | `03` §5.2 | La tabla de la compuerta imprime «determinante, unicidad, **supresión, conjunto de contraste**», **invertido** respecto de §8, que argumenta que el contraste va antes. La versión que la persona lee de verdad es la de la compuerta: es la que revierte la corrección. Pasa a «determinante → unicidad → **¿contra cuál?** → supresión → coma» |
| 6 | `03` §8, tabla «Qué le toca a cada paso» | Dice que el paso 2 decide «si es `A` —describe— o `R`». Es falso por el propio banco: «a cargo de un Administrador» **no restringe** y tampoco es `A`. Pasa a «describe → `A`, o `R(estructura)` si además ata dos cosas del negocio; restringe → `R`» |
| 7 | `03` §3.9 y §6 caso 6 | **El fragmento está mal citado y produce tres etiquetas para la misma cadena.** En la corrida, «un casco central» es `T+C` y el `?` cayó sobre **«central»** sola. Hoy §6 caso 1 da `T` a «casco central» y §3.9 da `A` a «un casco central»: quien lea §3.9 va a etiquetar `A` y **perder el término**, que §4.1 llama el error peor. Corregir la unidad: el fragmento es **«central»** → `A`; «un casco central» → `T/C` |

---

## 6. C-5 — ¿Se adopta la medida contable del `?`?

### 6.1 Por qué el umbral no se defiende

Tres cosas, y cada una alcanzaría:

1. **No discrimina.** La única corrida conocida se hizo **sin compuerta** —la compuerta es invención de
   este documento— y arrojó **1 `?` en 13 fragmentos**: dentro de la banda que el umbral usa para
   certificar que la compuerta se corre. Un indicador que da «sano» sobre el caso que por construcción es
   el enfermo tiene poder de discriminación cero. No hay ninguna observación del otro lado del corte.
2. **La unidad no existe.** «Por párrafo» no es unidad estable, y el documento cuenta en tres: «un párrafo
   de quince fragmentos» (§5.2), «`?` por párrafo» sin denominador (§11.4) y fragmentos sueltos. El
   párrafo real tiene cuatro oraciones y el paso 2 etiquetó 13 ítems sobre tres sub-oraciones: bajo
   ninguna lectura da quince. Además, el glifo `?` tiene hoy cuatro funciones y el documento nunca dice
   cuáles entran en la cuenta.
3. **Es un icono.** «Tres o más **significa** que la compuerta no se está corriendo» clasifica y no manda
   hacer nada: falla la prueba de la operación.

**Y el dato que da vuelta la pregunta, que trajo el refutador:** la corrida levantó un `?` y **el 100 % de
sus `?` era ilegítimo** —el material lo retracta: «Levanté un `?` que podía contestar con un criterio que
tenía en la mano. Eso no es prudencia: **es pasividad disfrazada de rigor**»—. El umbral le habría dado
**verde** a esa corrida. La magnitud que importa no es *cuántos `?` hay*: es **cuántos sobreviven a
correr la compuerta**.

### 6.2 Decisión

> **No se adopta el umbral. Se adopta, en su lugar, una recuenta obligatoria al cierre y una magnitud que
> sí discrimina: `?` que sobreviven sobre `?` levantados.** Sobre la única corrida conocida, esa magnitud
> da **1 de 1 — rojo**, que es el resultado correcto. **Ningún umbral numérico se escribe hasta tener
> cinco corridas anotadas.**

**Voto del jurado.** Evidencia 5-0. Impacto 5-0. Costo/beneficio 5-0 —la recuenta cuesta segundos y sólo
sobre los `?`, que por diseño son poquísimos—. Coherencia 5-0: la recuenta **no** viola «no releer» de
§1.4, porque un `?` no es una etiqueta puesta sino una decisión pendiente, y eso queda escrito. Riesgo
5-0.

### 6.3 Parche textual

**P-5.a — `03` §5.2, reemplazar el bloque final** («La medida de que la compuerta funciona…») por:

```markdown
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
> **Anotá la cuenta final junto a la inicial** —`? 1/13 → 0/13`—. La proporción entre las dos es lo
> único que dice si la compuerta sirvió: **si sobrevive el que levantaste, la compuerta funcionó;
> si se caen todos, la estabas salteando.**
>
> **Sobre qué evidencia se apoya esto, sin maquillar.** Sobre **una sola corrida**: 13 fragmentos, un
> `?`, y ese `?` resultó resuelto por un criterio que ya estaba disponible (§6, caso 6). La única
> cuenta observada de `?` que sobreviven es **cero sobre uno**. **Por eso acá no hay umbral y hay una
> recuenta.** Cuando haya cinco corridas anotadas con su par, se calcula la proporción observada y
> recién entonces se escribe un umbral.
```

**P-5.b — `03` §11.4 punto 3**, reemplazar por: «Cada corrida anota su par `? levantados / ?
sobrevividos` y el total de fragmentos. A las cinco corridas se calcula la proporción y se decide si hay
umbral. Hasta entonces, no hay número.»

**P-5.c — `03` §10**, agregar un límite: «**La medida del `?` no está validada.** Sale de una corrida de
13 fragmentos con un solo `?`, que además resultó ilegítimo. Lo único que la corrida sostiene es que la
compuerta hacía falta, no cuántos `?` son demasiados.»

---

## 7. Auditoría `Icono-Y-Ancla` de la propia propuesta

El §11.2 del objeto declara la prueba de la operación corrida sobre **once** definiciones y concluye «no
se detectó ningún icono sin reparar». **El alcance declarado es menor que el que la regla exige** —«toda
definición del documento»— y **su propia aritmética no cierra**: el texto dice «las nueve definiciones de
etiqueta, las dos de marca y la del `?`», que son doce con `?` contado dos veces, y remata «las once».

### 7.1 Lo que sí pasa

Las nueve fichas de letra entregan operación con verbo de acción y escena con datos: *contá* (`T`),
*preguntale a la cosa* (`A`), *buscá al que lo hace* (`V`), *subrayá el cuantificador* (`C`), *sacalo y leé
lo que queda* (`M`), *contá el rechazo* (`R`), *buscá la función que desaparece* (`E`), *pasá la compuerta*
(`?`), *leé el fragmento en voz alta* (`⟦ ⟧`). `R` es el mejor ancla del documento y `M` el segundo.
Escenas: verificadas, ninguna se repite en más de dos fichas —la reutilización de un **dominio** no es
reutilización de una **escena**—.

### 7.2 Lo que falla, con su reparación

| # | Definición o criterio | Por qué falla | Reparación |
| --- | --- | --- | --- |
| 1 | **`°` en su rama `V°`** | La operación escrita —«preguntale si nombra algo por primera vez»— **no produce** el resultado que §6 caso 1 declara. Entrega la operación de la anáfora y el veredicto del efecto | P-2.c: `V°` se retira; `°` queda con la operación que sí tiene |
| 2 | **`L`** | La operación pide un juicio que el documento declara no local en otra sección. Un ancla que remite a información que no está en el fragmento no es un ancla en el paso 2 | §2: se retira la letra; la nota `R(estructura)` tiene operación de superficie |
| 3 | **`!`** | **No tiene definición, ni ficha, ni entrada en §0.2.** Su único disparador escrito es «**te diste cuenta** de que el fragmento está mal cortado»: la firma exacta del icono | P-2.f: ficha con operación contable (*contá los verbos, contá las etiquetas*), escena y **destinatario** |
| 4 | **El criterio de ampliación de §7.3** | «Se reconoce mirando, no razonando» no nombra ningún verbo. Se usó para aprobar `L` sin correr nada | P-2.a: tres preguntas con verbo y un caso resuelto sobre `L` |
| 5 | **La medida del `?` de §5.2** | «Tres o más **significa** que…» clasifica | P-5.a: siete verbos y una cuenta |
| 6 | **La condición de terminación de §1.4** | «Cantidad de fragmentos = cantidad de fragmentos con al menos una letra» es un veredicto sin verbo, **y se satisface trivialmente**: si los dos términos se obtienen recorriendo la misma lista de anotaciones, da `N = N` y el fragmento salteado —el único modo de falla que la ley teme— no aparece en esa lista | Reescribir: «**Recorré los números que te entregó el paso 1, de principio a fin, y contá los que no tienen letra. El paso 2 termina cuando ese número es cero.**» Una sola cuenta, sobre la numeración del paso 1, con el modo de falla como objeto directo |
| 7 | **`C descriptiva` / `C(varios?)`** | Dos grafías para lo mismo, una de ellas sin definir en ninguna sección y ninguna de las dos en la hoja de bolsillo. Falla por univocidad | P-2.e y P-2.h: una sola forma |

**Punto de vigilancia que el objeto declaró y está bien resuelto:** «el paso 2 es sucio a propósito» es un
icono, va como título y abajo se desarrolla —§1.1 entrega la asimetría de los dos errores y §1.4 la
verificación—. Es el uso correcto.

**P-7.a — `03` §11.2**: corregir la aritmética, declarar el alcance real —«toda definición y **todo
enunciado numérico**»— y agregar la **auditoría de consolidación** de `Icono-Y-Ancla` §6, que es la que va
a hacer falta al ejecutar P-3.d: cuando el documento se resuma para entrar en el techo, verificar qué
operaciones se cayeron en el resumen.

---

## 8. Hallazgos fuera de las cinco cuestiones

### 8.1 El banco de casos del §6: qué es falso y qué no — y la lección de la propia mesa

**Tres comisiones fundaron un `P0` en que el §6 «describe una corrida que no ocurrió»**, porque el archivo
de la corrida muestra `02.a.1 [ "En el mismo acto" **M** ]` y `01.b.5 [ "conformación" **V** ]`, donde el
§6 dice que con las ocho letras salieron `V` y `T`.

**Ese `P0` es falso, y la evidencia estaba en el mismo archivo que las tres leyeron:**

- «Tu instinto fue correcto —pusiste `ref: 01.b.5`— pero la etiqueta no: **no es `V`, es `M`**»
  (`Mis-Notas.md` l. 367). La persona **sí** puso `V`.
- «Ahí adentro hay además un sustantivo que esconde un verbo: "conformación". **Eso es un acto (`V`)**…
  Si lo dejás como sustantivo **se te va a términos y perdés el acto**» (l. 347).

El archivo muestra el estado **ya corregido por el instructor**; la columna «Con las ocho originales»
describe **la primera pasada**. Las tres comisiones cotejaron el resultado contra el resultado.

> **La lección, y vale más que el hallazgo:** cuando la evidencia es un documento que registra una
> corrección, **el estado final y el estado inicial viven en el mismo archivo y no están rotulados**. Hay
> que buscar la corrección antes de acusar a nadie de tergiversar. Esta acta lo asienta porque es
> reutilizable.

**Qué sobrevive, después de verificar los siete casos uno por uno:**

| # | Lo que el §6 afirma | Veredicto verificado |
| --- | --- | --- |
| 1 | `V`, «y la tabla de actos **duplica**» | **La etiqueta es correcta; la consecuencia es falsa.** El material previene la duplicación acumulando efectos en una fila |
| 2 | `V` por la palabra «acto» | **Correcto.** Único caso con testimonio directo de la primera pasada |
| 3 | `R` «a falta de algo mejor» | **Falso en el rótulo.** La `R` se asignó con doctrina: «el caso del calificador que aporta un hecho». La mezcla en la tabla de reglas es real; la resignación, no |
| 4 | «ninguna clara» | **Falso.** El material etiqueta `R+C`, y lo hace **dos veces**, en dos dominios |
| 5 | `T`, «y el acto se pierde» | **Es un condicional de advertencia del instructor** —«*si lo dejás* como sustantivo»—, presentado como hecho observado |
| 6 | `?` elevado sobre «un casco central» | **Sustancia correcta, unidad errada**: el `?` cayó sobre «central»; «un casco central» era `T+C` |
| 7 | columna del actor vacía | **Correcto, y el catálogo mejora la fuente**: la fuente dice «anotalo como `?`» y el catálogo separa `⟦?⟧`. Es su mejor aporte propio |

**Y un problema de anclaje, P1:** §11.1 ancla los siete casos a
`../Bitacora-Editores/09-Fuente-Actividad-La-Estancia.md`, que contiene el enunciado y no la corrida. **El
§6 no es verificable desde el repositorio que lo contiene.**

**P-6.a — Rehacer la columna «Con las ocho originales»** fila por fila con la etiqueta y la nota reales,
con su identificador (`01.b.5`, `02.a.1`…) y marcando cuáles son **testimonio directo** y cuáles
**reconstrucción**. Donde la corrida ya resolvía bien, la fila deja de probar una carencia de las ocho
letras y pasa a probar que el catálogo aporta **notación**, no capacidad. Rehacer después el recuento de
§6 y el veredicto de §7.1 sobre el resultado honesto.

**P-6.b — Versionar la evidencia.** Transcribir los trece fragmentos de la corrida y las dos correcciones
del instructor en `OUTPUTs/Bitacora-Editores/11-Corrida-Observada-Paso-2.md`, citando archivo y línea de
origen, y reanclar §11.1 ahí. Sin eso, la única base empírica del documento vive fuera de su árbol y en
un archivo que esta mesa tiene prohibido escribir.

### 8.2 Contradicciones internas que hay que cerrar

| # | Contradicción | Corrección |
| --- | --- | --- |
| 1 | Encabezado «decidir en **diez** segundos» contra §1.2 «**cinco** segundos por fragmento» y su título «Por qué cinco y no diez» | P-3.b: **cinco** |
| 2 | §3.4, la celda **Etiqueta** dice `L/C/R` y la celda que la explica dice «tres es el techo roto: se ponen `L/C` y un `!`» | Con `L` retirada, la fila pasa a `R(estructura)/C` + `!` |
| 3 | §7.1 cierra el veredicto sobre `L` («falta una letra») y §10 límite 4 lo declara no validado | Resuelto por §2: la letra no entra |
| 4 | §6 «cada caso se resuelve **en menos de cinco segundos**, que es la prueba que de verdad importa» contra §10 límite 3 «nadie va a cronometrar» | Retirar la afirmación. Reemplazarla por la prueba que sí es auditable: **cada caso lo resuelve exactamente un criterio nombrado** |
| 5 | §7.1 «alrededor de un **diez por ciento** de costo de elección» | **Retirar el número.** No coincide con ninguno de los modelos de costo del propio documento —7→8 descartes es +14,3 %; 8→9 letras es +12,5 %; por pares, +28,6 %— y §10 límite 4 declara que `L` no tiene uso real. Un porcentaje de costo de algo que nunca se usó no se publica. Con `L` retirada, el punto desaparece |
| 6 | §0.1 «el paso 2 **nunca crea ni descarta fragmentos**» contra la corrida, donde el paso 2 subdividió un fragmento del paso 1 en seis y etiquetó uno —«estancia»— que **no es un tramo del párrafo** | Reescribir §0.1: el paso 2 recibe las **afirmaciones y sus calificadores** —no el párrafo entero: P10 reparte en **cinco** destinos— y **puede subdividir**, numerando con el identificador del paso 1 más un sufijo |
| 7 | §0.2 dice que `⟦ ⟧` es marca propia y §0.3 la clasifica como criterio propio, cuando está en `02` §0.4 | P-2.d: estatuto corregido. «Una marca propia (`°`), dos heredadas (`⟦ ⟧`, `?`) y una especialización propia (`⟦?⟧`)» |
| 8 | §8 afirma que generalizar §4.3 «no altera ninguna decisión ya tomada» por el paso 1 | **Sí la altera** (§5.1). Retirar la afirmación y declarar qué cambia |

### 8.3 Procedencia: tres criterios declarados propios que están en el material

El §0.3 es la regla de la casa del documento —«no se cita lo que no se cotejó, y se separa lo propio de lo
recibido»—, y está corrida a favor del objeto en tres filas: **el conjunto de contraste** (§5.1 de esta
acta), **la generalización a todo modificador** —declarada «propuesta» cuando el material ya la había
decidido y fundado— y **la compuerta**, cuya formulación es literal del material: «un `?` que un criterio
en mano resuelve no es una pregunta para el autor: es un criterio no aplicado». Lo propio, que no es poco,
es la **formalización**: el procedimiento de tres pasos, la tabla de criterios y el lugar en el orden.

**P-7.b — Corregir §0.3 y §11.1** con estos tres estatutos.

### 8.4 El punto ciego: el `!` no tiene destinatario

Cinco usos operativos en el cuerpo, cero definiciones, ausente de §0.2, ausente de §2, ausente de §7.5, y
ausente del paso 1 —`grep` de `!` sobre `02`: no está en su notación—. El `!` es **el único canal del paso
2 hacia el paso 1**, y el paso 2 es el único lugar del procedimiento desde donde se ve que un corte salió
mal. El documento le pide a la persona que lo escriba, le prohíbe volver al paso 1, y no le asigna
destinatario. Es la frase que gobierna el documento aplicada al propio instrumento: se pierde en silencio.
**Resuelto por P-2.e y P-2.f.**

---

## 9. Tabla de decisiones y orden de aplicación

### 9.1 Las cinco cuestiones

| Cuestión | Decisión | En una línea |
| --- | --- | --- |
| **C-1** | **`L` NO se adopta.** Se adopta la nota `R(estructura)`, con destino fijado en la Tabla 3, columna `Especie`, valor `estructura` | La letra `R` es correcta y estaba incompleta: eso es una nota, no una letra |
| **C-2** | **Marcas SÍ, con tres reparaciones.** `°` sólo para anáfora con disparador de lista cerrada; `V°` se retira; `⟦ ⟧` con estatuto de heredada; `!` se define y recibe destinatario. Inventario cerrado en una sola tabla. **La regla que las funda se adopta reformulada**, con operación y tres salidas | Las marcas no eran letras encubiertas, salvo `V°`, que sí lo era |
| **C-3** | **El formato NO es el correcto. Se invierte ahora; se parte al catalogar**, con el corte declarado y la **regla de copia única** | La hoja de bolsillo va primero; partir sin regla de copia única cambia un problema por otro peor |
| **C-4** | **SÍ se generaliza**, con el parche redactado en §5.2, la corrección del indicio 1 a **unidireccional**, el filtro argumento/adjunto, el indicio de la posición del adjetivo, y **siete puntos de entrada** sin los cuales el criterio vuelve a no encontrarse | El criterio no faltaba: estaba titulado por una estructura y no por su función |
| **C-5** | **El umbral NO se adopta.** Se adopta la recuenta al cierre y la magnitud `?` sobrevividos / `?` levantados, con la base declarada y sin número hasta cinco corridas | El umbral le habría dado verde a una corrida cuyos `?` eran ilegítimos al 100 % |

### 9.2 Orden de aplicación de los parches

El orden **no es negociable en sus dos primeros tramos**: se corrige la evidencia antes de reescribir los
argumentos que se apoyan en ella, y se reorganiza el documento al final, cuando el contenido ya no se
mueve.

| # | Parche | Qué toca | Por qué en este lugar |
| --- | --- | --- | --- |
| 1 | **P-6.a, P-6.b** | `03` §6, §11.1; archivo nuevo `11-Corrida-Observada-Paso-2.md` | La evidencia primero. §7 entero se argumenta sobre §6 |
| 2 | **P-7.b, P-8.3** | `03` §0.3, §11.1 | Procedencia, antes de reescribir lo que se declara propio |
| 3 | **P-1.a a P-1.e** | `03` §3.4, §3.7, §0.2, §4.2, §4.3, §7, §9, §10, §11 | La decisión de mayor alcance: cambia lo que la persona escribe |
| 4 | **P-2.a a P-2.h** | `03` §0.2, §2 entero, §3.3, §3.5, §6, §7.3, §9 | Depende de P-1: la regla reformulada usa `L` como caso resuelto |
| 5 | **P-5.a a P-5.c** | `03` §5.2, §10, §11.4 | Independiente |
| 6 | **§8.2, ítems 1 a 8** | `03` encabezado, §0.1, §0.2, §6, §7.1, §8 | Contradicciones; después de que el contenido se estabilizó |
| 7 | **P-7.a** | `03` §11.2 | La autoauditoría se rehace al final, o audita un estado que ya no existe |
| 8 | **P-3.a a P-3.c** | `03`: mover §9, encabezado, §0.3 | La inversión, cuando el contenido ya no se mueve |
| 9 | **C-4: §5.2 y §5.3 de esta acta** | `02` §0.3, §2.3, §2.5, §3.2, §4 (título), §4.3, §5 (P5-bis), §11; `03` §5.2, §8, §3.9, §6 | **Independiente de todo lo anterior.** Puede ir en paralelo, y es el parche de mejor relación entre costo y valor |
| 10 | **P-3.d** | Partición y cabecera | **Sólo al catalogar como `Knowledge-*`.** No antes |

**Verificación de cada tramo, y sin esto no se declara aplicado:** después de 1 a 8, correr el paso 2
sobre un párrafo nuevo del mismo enunciado con la hoja de bolsillo sola, y anotar el par
`? levantados / ? sobrevividos` y la lista de `!`. Es la evidencia que hoy no existe y que todas las
calibraciones necesitan.

---

## 10. Deuda declarada y lo que la mesa no puede decidir

### 10.1 Deuda que la mesa asume a conciencia

| # | Deuda | Por qué se asume |
| --- | --- | --- |
| D-1 | **El paso 1 también está sobre el techo**: `02` tiene 822 líneas y el parche de C-4 le agrega unas sesenta | El parche corrige un defecto medido y su ausencia cuesta más que las líneas. La partición de `02` no se decide acá: no estaba en las cuestiones |
| D-2 | **`R` queda con dos entradas** —contá el rechazo, o subrayá la locución que ata— y eso es más de lo que tiene cualquier otra letra | Es el precio de no agregar la novena. Se revisa si en dos corridas la segunda entrada produce `R` donde no hay nada que asentar |
| D-3 | **La hoja de bolsillo es una copia**, y toda copia deriva | Se acota con la regla de copia única de P-3.c, que la declara **fuente** y no copia: si hay discrepancia, manda la hoja |
| D-4 | **Ninguna calibración de ritmo está medida.** Cinco segundos, tres segundos, diez segundos de la compuerta, cinco minutos de criterio de fracaso | El propio documento lo declara en §10 límite 3. La mesa retira los tres números derivados —3 s, 10 s y «media jornada»— y conserva **uno solo**, el de §1.2, rotulado calibración |

### 10.2 Lo que la mesa no puede decidir, con su default

**No hay empates que elevar.** Las dos cuestiones con posiciones enfrentadas —C-1 y C-3— se reconciliaron
con un criterio que ninguna de las dos partes había propuesto, que es lo que corresponde cuando dos
criterios correctos no se pueden aplicar juntos.

**Lo único irresoluble con la evidencia disponible** es de otra clase, y no es una pregunta: es un límite.

> **La suficiencia del conjunto de etiquetas no se puede decidir con trece fragmentos, de los cuales sólo
> dos son testimonio directo de la primera pasada.** Todo lo que esta acta decide sobre taxonomía —que
> ocho alcanzan, que la nota `(estructura)` basta, que el techo de dos etiquetas se sostiene— descansa
> sobre una corrida que cubrió **dos de las cuatro oraciones** del párrafo.
>
> **Default de la mesa, que no requiere que nadie conteste nada:** se aplica lo decidido, y la primera
> corrida sobre las oraciones que faltan —`02.b`, `03` y `04`— se trata como **la prueba de la decisión**,
> con dos cosas anotadas: el par `? levantados / ? sobrevividos` y cuántas `R(estructura)` aparecieron.
> Si en esa corrida la nota `(estructura)` resulta insuficiente —si aparecen ligas que no llegan a `R`
> por su propia operación—, `L` vuelve a la mesa **con datos**, que es la condición que hoy le faltaba.

### 10.3 Trazabilidad

| | |
| --- | --- |
| **Método** | `Knowledge-Mesa-De-Expertos-A-Pedido.md` (convocatoria, clase «diseño de una norma», despacho verificado), `Base/Mesa-Evaluadora.md` (panel a ciegas, jurado de cinco funciones, separación entre quien diseña y quien aprueba), Reporte `23` (la mesa reconcilia: en C-1 y C-3 el criterio que resolvió no era el de ninguna de las dos partes) |
| **Informes** | Cinco comisiones a ciegas y en paralelo, más el refutador último. Los hallazgos se asientan en esta acta con su ancla; **el presidente verificó cada dato antes de asentarlo**, y en §8.1 el resultado contradice a tres comisiones |
| **Evidencia** | El árbol de `OUTPUTs/Conocimientos`, el hermano `Rules-Base-Conocimiento.md` §6.2 (sólo lectura), y la corrida observada en `Interactive-Activities/docs` (sólo lectura; se propone versionar su transcripción en P-6.b) |
| **Qué no se tocó** | Ningún archivo. `/IA/SDD/IA.SDD`, `PROG2/`, `Interactive-Activities/`, el apunte y la guía interactiva quedaron intactos, y los parches sobre ellos —ninguno— no existen: lo que esta acta propone sobre el paso 3 **no requiere cambiar el cuaderno de nadie**, y ésa fue una de las razones de la decisión C-1 |

---

## Control de cambios

| Versión | Fecha | Cambios |
| --- | --- | --- |
| 1.0 | 2026-09-26 | Acta de la mesa sobre `03-Catalogo-De-Etiquetas.md`. Cinco cuestiones decididas: `L` no entra y se reemplaza por la nota `R(estructura)` con destino en la columna `Especie` de la tabla 3; las marcas se adoptan con `V°` retirado, `!` definido y el inventario cerrado; el documento se invierte ahora y se parte al catalogar, con regla de copia única; la jerarquía de indicios se generaliza con el indicio 1 corregido a unidireccional y siete puntos de entrada; el umbral del `?` se reemplaza por una recuenta y la magnitud de supervivencia. Siete definiciones o criterios fallaron la prueba de la operación y quedan con su reparación. Se asienta el error metodológico de tres comisiones sobre un archivo que registra su propia corrección. |
