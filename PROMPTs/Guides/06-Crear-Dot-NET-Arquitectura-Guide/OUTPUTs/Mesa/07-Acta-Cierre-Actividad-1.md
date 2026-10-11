# 07 — Acta de cierre de la Actividad 1: terminar el cuaderno del párrafo I

**Fecha:** 2026-10-03
**Clase de objeto:** corpus documental existente (`Knowledge-Mesa-De-Expertos-A-Pedido.md` §2.2)
**Objeto:** `LAB/Lab-Documentos/Guides/Dot-NET-Arquitectura-Guide/Interactive-Activities/Actividades/Actividad-1-Deduciendo-Reglas-Negocios.md`
**Quién aplica:** la mesa. **Su producto es el archivo terminado, no este dictamen.**
**Qué NO está acá:** nada de lo que ya está escrito en el archivo. Este acta registra **por qué** se
decidió cada cosa; el **qué** se lee allá.

---

## 0. Convocatoria

### 0.1 Contrato de entrada

```text
PEDIDO (literal, 2026-10-03): «Convocás y conducís una MESA DE EXPERTOS para cerrar las tareas
  pendientes de una guía práctica que un docente viene resolviendo a mano. La mesa decide y aplica:
  su producto es el archivo terminado, no un dictamen aparte.»
CLASE DE OBJETO: corpus documental existente
OBJETIVO: dejar cerrado el cuaderno del párrafo I, con lo agregado distinguible de lo del autor.
PREGUNTAS DEL CASO: T-1 a T-8, más una decisión sobre el defecto conocido del paso 1.
RESTRICCIONES DURAS:
  · Se edita UN archivo. Nada bajo `PROG2/`, ni `Knowledge-*`, ni `02`, `03`, `04`, ni el apunte,
    ni `Mis-Apuntes-Borradores/`.
  · Sólo lectura sobre `/IA/SDD/IA.SDD`.
  · No inventar información. Toda afirmación con su ancla.
  · El cuaderno es del Product Owner: su trabajo se conserva; lo agregado va marcado.
DECISIONES CERRADAS (no se rediscuten): el acta `06-Acta-Replanteo-Del-Modelo.md` entera —el
  referente, la hoja del referente, los cuatro cuadrantes, «central» es Q1—; y las ocho letras.
FUERA DE ALCANCE: contestar las seis preguntas del autor; corregir el enunciado; el párrafo II;
  los pasos 1 y 2 salvo lo que T-1 obligue.
MEDIOS: lectura del corpus y conteos sobre el archivo. SIN OBSERVAR: ninguna corrida del método
  sobre material nuevo — ver §4, IR-1 heredada.
EXPEDIENTE: este acta. No cumple la condición de `Expediente-Rules.md` §1: carpeta y acta, sin
  forma de expediente.
QUIÉN APLICA: la mesa.
PRESUPUESTO: una ronda.
```

### 0.2 Panel, con su señal y los descartes

| Rol | Señal que lo convoca | No le corresponde |
| --- | --- | --- |
| **Presidente** | — | Votar |
| **Gramático del texto** | T-1 y la decisión del paso 1 son de segmentación y de modificadores | Decidir qué se eleva al autor |
| **Modelador de dominio** | T-2 y T-7: el referente y sus hojas son esa competencia | Redactar gramática |
| **Cronista de momentos** | T-4: el hallazgo es un atributo sin momento de verificación | Juzgar la letra |
| **Ejecutor con lápiz** | El lector del cuaderno es el autor con un lápiz; T-6 y T-8 se escriben para él | Proponer notación nueva |
| **Editor de material didáctico** | T-7 y la decisión del paso 1 son decisiones de qué enseña un error | Decidir contenido técnico |
| **Refutador** *(último)* | Permanente | Hallazgos propios fuera del ataque |

**Descartados, con su motivo:**

| Descartado | Motivo |
| --- | --- |
| **Usuario estándar** | Su evidencia admisible es `E3`, un recorrido sobre una interfaz en ejecución. Acá el objeto es un cuaderno de lápiz |
| **Perito** | No hay contradicción entre observadores que medir. La única contradicción del caso —`RN-06`— se resuelve con la escalera, no con un experimento |
| **Analista de articulado legal** | El objeto es prosa de negocio rioplatense, calibración ya declarada en `02` §9.4 |

---

## 1. Base mecánica

Medido antes de decidir, con el comando al lado. Las dos primeras filas son **anteriores** a la
intervención.

| Dato | Valor | Comando |
| --- | --- | --- |
| Líneas del archivo, antes | **359** | `wc -l` sobre el archivo |
| Líneas del archivo, después | **921** | ídem |
| Fragmentos producidos por el paso 2 | **31** | `grep -cE '^  [0-9]{2}\.[ab]\.[0-9] \['` |
| Afirmaciones del paso 1 | **5** sobre 4 oraciones | conteo de `01.a … 04.a` |
| Verbos en forma personal del párrafo | **7** — `tiene`, `está compuesta`, `se establece`, `se puede conocer`, `son`, `se aloja`, `se contempla` | lectura del párrafo citado en el archivo |
| Filas de la tabla 3, antes → después | **8 → 9** | `sed -n '/^#### Tabla 3/,/^---/p' \| grep -cE '^\| (RN-\|AL-\|⟨M⟩ \*\*AD)'` |
| Marcas `⟨M⟩` en el archivo | **36** | `grep -c '⟨M'` |

**Lo que la base mecánica decide sola, antes de que nadie opine:** 5 afirmaciones contra 7
predicaciones disponibles cumplen la cota de atomización de `02` `P11` condición 5. **El corte del
autor está bien**, y eso es lo que separa el defecto del paso 1 —que está en la regla enunciada— del
resultado —que es correcto—. Sin esta medición, la decisión sobre el paso 1 habría sido una opinión.

---

## 2. Las ocho tareas: qué se decidió y con qué fundamento

| # | Decisión | Fundamento, en una línea |
| --- | --- | --- |
| **T-1** | `central` y `rural` pasan a `R/A` con cuadrante `Q1`, **conservando** su fila de atributo | `Q1` tiene **doble destino** (`02` §4.3): la afirmación a la tabla de reglas **y** la propiedad al glosario. Sacar la fila de atributo habría aplicado media regla |
| **T-1** | La fila de reglas que producen es **`AD-01`**, no dos reglas nuevas | «El casco es la central» y «los puestos son las periféricas» se incumplen con **el mismo contraejemplo**: partirlas viola `02` `P11` condición 4. Esto conecta T-1 con T-2 y evita la redundancia que el método prohíbe |
| **T-2** | `AD-01` entra con `Letra` **vacía**, rótulo `Intención` y grado `inferencia` | La gramática suministra las premisas; la conclusión es un paso deductivo de quien analiza, y **nunca puede salir como `Letra`** |
| **T-2** | La prueba de admisión se corrió y se dejó escrita | Las tres supresiones tumban la conclusión y la negación contradice el párrafo. Se escribió **la tabla**, no el veredicto: una prueba cuyo resultado se afirma sin exhibirse no es una prueba |
| **T-3** | `RN-05` pierde `⟦implícita⟧`, gana rótulo `Intención` y **tres** anclas | `⟦implícita⟧` ocupaba la columna `Letra` sin ser cita. El ancla `02.b.5` que el autor tenía es **ella misma** un fragmento marcado implícito: hacía falta decir de qué letra sale, y sale de `02.b.1` + `02.b.3` |
| **T-4** | Diagnóstico `E2`, con los tres peldaños escritos y el descarte de `E1` fundado | La obligación de declaración de `02` §6.2 pide el motivo del descarte de los anteriores, no sólo el peldaño elegido. Y el daño de reportar `E2` como `E3` es tirar una afirmación verdadera sin rastro |
| **T-4** | El acto va a la **tabla 2**, con rótulo `⟦Propuesta⟧` y «de dónde» vacío | Un hueco que no se ve no se discute. El rótulo y la columna vacía son lo que impide que, dentro de tres semanas, el acto se lea como si el enunciado lo pidiera |
| **T-5** | «nunca se define» → «no se define acá», en `dueño`, `personal` y —por uniformidad— `campo` | «Nunca» es una afirmación sobre el documento entero y el autor leyó un párrafo. Es el mismo principio que la mesa aplica a las comisiones: **una afirmación de que algo no está sólo se admite con la búsqueda exhibida** |
| **T-6** | Seis fichas completas nuevas; **las tres del autor no se tocan** | `RN-01`–`RN-03` son suyas y están bien; completarlas por él habría borrado dónde terminaba su trabajo. Se declara qué les falta y que es suyo |
| **T-6** | `RN-07` gana `Momento: Invariant` y `Quién verifica: nadie`, con aviso | La tabla 3 tenía «—» en los dos campos. «—» no es valor válido ahí; **«nadie» sí, y es un hallazgo**. Se avisa en la ficha en vez de corregir la celda del autor |
| **T-7** | **Siete** hojas: estancia, campo, instalación, Administrador, encargado, dueño, personal | Una por sustantivo del dominio |
| **T-7** | `casco` y `puesto` **no** abren hoja propia | Son los miembros de *instalación*: todo lo que el párrafo les predica se lo predica al grupo. Dos hojas más duplicarían los depósitos y volverían invisible el eje. **Declarado con causa y revisable** si el párrafo II rompe la simetría |
| **T-7** | La advertencia de re-derivación se escribió **antes** de las hojas, no al pie | Es la deuda `IR-1` del acta `06` §7 y gobierna cómo se lee todo lo que sigue. Al pie, se lee después de haber creído |
| **T-8** | El recuento incluye la lectura incómoda del `0/31` | Un `0/31` se puede leer como «no hubo dudas» o como «no se levantaron». El método dice que la pasividad **no se ve leyendo el entregable: se ve en el recuento**, así que el recuento lo dice de sí mismo |
| **T-8** | Las seis preguntas salen **en un solo lote**, con las dos lecturas y la consecuencia | `M-6` y `D-8`: una respuesta temprana condiciona al resto. Y una pregunta sin las dos lecturas no se contesta en quince segundos |

### 2.1 Lo que la mesa decidió NO hacer, aunque podía

| Qué | Por qué no |
| --- | --- |
| Abrir `RN-08` y `RN-09` para `central` y `rural` | Serían las dos mitades de `AD-01`. Es la trampa exacta que T-1 y T-2 tenían preparada si se resolvían por separado |
| Completar las fichas `RN-01`–`RN-03` del autor | Dejaría de verse dónde termina su mano. Se declara qué falta y de quién es |
| Elevar «campo no se define» como pregunta | El párrafo II lo define. Es un `?` que un criterio en mano resuelve: **elevarlo sería pasividad disfrazada de rigor** (`B-8`) |
| Contestar la pregunta 3 —si `Administrador` y `encargado` son el mismo rol— | La hoja del referente la **muestra** con claridad y no la **resuelve**: el párrafo no desempata. Un empate no se vota, se eleva (`D-7`) |

---

## 3. La decisión sobre el paso 1

**El defecto, medido.** El enunciado del autor —«se corta en cada `y`, en cada coma, y en cada
`de los cuales / donde / tanto… como`»— aplicado al pie de la letra produce **tres cortes mal** en
este mismo párrafo: dos falsos cortes —el `y` de (02), que coordina dos objetos de un mismo verbo, y
el «tanto… como» de (03), que es sujeto múltiple— y un acierto por la razón equivocada —la coma de
(02) corta, pero no por ser coma: porque del otro lado hay predicado—.

**Las dos posiciones, con lo mejor de cada una.**

> **El editor de material didáctico.** Se deja. El error y su corrección juntos enseñan más que la
> regla sola: el alumno que ve la regla correcta desde el principio no entiende qué problema
> resuelve. Y el Product Owner declaró que va a revisar ese paso él mismo; reescribirlo es tomarle
> la decisión.

> **El gramático.** Se corrige. El paso 1 es el **insumo de todo lo demás**: los números `02.a.4`,
> `03.a.4` son el ancla de `AD-01` y de las siete hojas. Un cuaderno que ancla en fragmentos
> producidos por una regla falsa enseña a anclar mal.

**Decisión: se corrige por aviso, y el texto del autor no se toca.**

**Fundamento, y son tres cosas:**

1. **El filtro «descripción o control» decide la forma.** La oración del paso 1 no describe lo que el
   autor hizo: **declara un control** —cómo hay que cortar— que el propio autor no ejerció. Un
   control no ejercido **no se reescribe para absolverlo**: se declara. Reescribirlo habría borrado
   la evidencia de que el criterio y la práctica no coinciden, que es el hallazgo.
2. **La posición del editor es correcta y está incompleta.** Un error enseña **si está rotulado como
   error**. Sin rótulo enseña el error. El aviso es lo que convierte el defecto en material
   didáctico, y es además el formato más barato: no hay que rehacer un solo fragmento.
3. **La medición lo permite.** 5 afirmaciones contra 7 predicaciones: el resultado del corte es
   correcto. Si el corte hubiera estado mal, la decisión habría sido otra —no se puede dejar un
   cuaderno cuyos números están mal, por didáctico que sea el error—. **Esta decisión depende de un
   dato, no de una preferencia**, y conviene que quede dicho: si el párrafo II se corta con la misma
   regla y sale mal, hay que volver acá.

**Y la restricción del Product Owner se respeta entera:** el aviso dice explícitamente que la mesa
**no reescribe el paso**, y deja la reformulación para él.

---

## 4. Lo que no se pudo cerrar con la evidencia disponible

**IR-1, heredada del acta `06` §7 y ahora con nombre y lugar.** Las siete hojas del referente del
párrafo I son **re-derivación, no prueba**: sus resultados se conocían antes de abrirlas. La prueba
pendiente es el **párrafo II**, que esta mesa tiene fuera de alcance. *Qué haría falta:* correrlo a
ciegas y contar cuántos de sus hallazgos salen de leer las hojas. Hasta entonces, las siete hojas
valen como ejemplo trabajado y **no** como evidencia de rendimiento del instrumento. Está escrito en
el archivo, antes de las hojas y no al pie.

**IR-2, heredada y confirmada por el uso.** La lista de casilleros no está cerrada, y la corrida la
tensionó en un punto concreto: las hojas de `Administrador` y de `encargado` necesitaron un casillero
**género** que el párrafo deja `⟦?⟧` —ni persona, ni rol, ni cargo—, y el pendiente que ambas
cargan no es de contenido sino **de relación entre dos hojas** —¿son la misma?—. Los siete casilleros
no tienen dónde poner eso; quedó en `pendientes` de las dos. *Qué haría falta:* la misma corrida del
párrafo II, mirando si los depósitos sin casillero son todos de este tipo.

**Lo que esta mesa agrega como deuda propia:** el cuaderno tiene ahora **dos rótulos nuevos en
circulación** —`⟨M⟩` y `⟨M corrige: …⟩`— que no están en ningún `Knowledge-*`. Son andamiaje de
autoría, no notación del método, y **deberían desaparecer** cuando el autor incorpore o rechace cada
bloque. Si sobreviven a la actividad 2, dejan de ser andamiaje y pasan a ser notación sin catalogar.

---

## 5. Apartamientos de conocimiento catalogado

**Ninguno.** Todo lo aplicado sale de `Knowledge-Deduccion-De-Reglas-De-Negocio.md` 1.4, de
`02-Criterio-De-Segmentacion.md`, de `03-Catalogo-De-Etiquetas.md` y del acta `06`, y en los cuatro
casos en que la mesa eligió entre dos lecturas admisibles —la fila única de `AD-01`, la conservación
de las filas de atributo, la no apertura de hojas para `casco` y `puesto`, y la forma de corregir el
paso 1— la elección está fundada arriba, con el criterio que la sostiene nombrado.

**Lo único que no tiene respaldo en un conocimiento catalogado** son los dos rótulos de autoría de
§4. Se declara.

---

## Control de cambios

| Versión | Fecha | Cambios |
| --- | --- | --- |
| 1.0 | 2026-10-03 | Emisión. Cierre de la actividad 1 sobre el párrafo I: T-1 a T-8 aplicadas sobre el cuaderno, de 359 a 921 líneas y de 8 a 9 filas en la tabla 3. **T-1 y T-2 se resuelven juntas**: `Q1` manda la afirmación a la tabla de reglas y la propiedad al glosario, y la fila que producen es una sola, `AD-01`, con sus tres anclas y la prueba de supresión escrita. **Paso 1: se corrige por aviso y no se reescribe**, por el filtro «control no ejercido» y porque la cota de atomización mide que el resultado del corte es correcto. **Seis preguntas abiertas**, en lote, con sus dos lecturas y su consecuencia. **IR-1 e IR-2 heredadas** del acta `06` y confirmadas; deuda propia: los dos rótulos de autoría. |
