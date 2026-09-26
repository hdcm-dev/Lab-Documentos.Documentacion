# Informe de la comisión Martin Fowler — Ciclo 3

**Mesa:** guía `Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md`, v2.2.0
**Comisión:** Martin Fowler
**Fecha:** 2026-09-21
**Encargo:** procedencia de *Replace Constructor with Factory Function*; definición y ejemplos de *Invariant*; invariante de *Aggregate*.
**Presupuesto del ciclo:** ≤ +60 líneas y ≤ +2 bloques de código en toda la guía; los dos bloques están reservados para la comisión .NET.
**Costo de este informe:** +34 líneas, **0 bloques de código nuevos**. No se editó la guía.

---

## Resumen de lo verificado (antes de proponer)

Dejo primero el resultado de la verificación, porque dos de las tres preguntas del PO tienen respuesta de hecho y no de criterio.

1. **La refactorización es mía, y está en las dos ediciones.** La ficha del catálogo se llama hoy *Replace Constructor with Factory Function* y lleva el alias *Replace Constructor with Factory Method*. El propio catálogo explica el criterio de los alias: «Each card shows the name used in the second edition together with any aliases for the refactoring (such as names for first edition refactorings that it replaces)» (refactoring.com/catalog/). Y el marcado de la ficha declara en qué libros aparece: `data-books='refactoring2,refactoring,rubyref'` — es decir, *Refactoring* 2.ª ed. (2018), *Refactoring* 1.ª ed. (1999) y la edición Ruby. El catálogo **no declara autor distinto**: no lleva línea de atribución a terceros (a diferencia de otras fichas del sitio que sí la llevan), de modo que la procedencia correcta es la 1.ª edición de 1999, con el nombre viejo, y el renombre a *Function* en la 2.ª de 2018.
2. **Bloch es verificable, pero no es el origen de la refactorización.** *Effective Java*, 3.ª ed. (2018, Addison-Wesley, ISBN 9780134686073), capítulo 2 «Creating and Destroying Objects», **ítem 1: «Consider static factory methods instead of constructors»** — verificado en la tabla de contenidos publicada por el editor. La 1.ª edición es de 2001 (ISBN 0-201-31005-8), posterior a *Refactoring* (1999). Conclusión: Bloch **no propuso** la práctica; formuló de manera independiente —y con más argumentos de diseño de API— el mismo movimiento. Si se lo cita, se lo cita como convergencia, no como origen. Esto **sí** es citable con fuente primaria del editor.
3. **La frase que el PO recuerda de Evans no es del texto que la guía cita.** La *Domain-Driven Design Reference* (Evans, 2015), que es la fuente que la guía usa para Evans, **no contiene** «invariants … that must be maintained whenever data changes»; esa formulación es del libro de 2003, que esta guía solo cita de segunda mano (a través de Fowler, 2003). Lo que sí dice, verbatim, la Reference 2015 es: «Define properties and invariants for the aggregate as a whole and give enforcement responsibility to the root or some designated framework mechanism». **No citar** la frase de 2003 sin el libro a la vista; con la Reference 2015 alcanza y sobra para lo que la guía necesita.

---

## Punto 1 (P0) — Procedencia de la refactorización

**Dónde:** §3.1, viñeta **Factory Method**, sustituyendo la oración que hoy dice «El movimiento del constructor público al método estático está catalogado como *Replace Constructor with Factory Function* (alias *Replace Constructor with Factory Method*, [Fowler, s. f.](#ref-fowler-refactoring)); su motivo es que un constructor no puede elegir qué devolver ni llevar el nombre del acto.»
**Ancla:** `#31-definiciones` (viñeta existente; no requiere ancla nueva).
**Código nuevo:** no.
**Costo:** +2 líneas netas (la oración pasa de 1 a 3 renglones de fuente).

Redacción exacta propuesta (reemplaza la oración citada; el resto de la viñeta no se toca):

> El movimiento del constructor público al método estático está catalogado desde la primera edición de *Refactoring* (1999), donde se llamaba *Replace Constructor with Factory Method*; la segunda edición (2018) lo renombró *Replace Constructor with Factory Function* y el catálogo en línea conserva el nombre viejo como alias ([Fowler, s. f.](#ref-fowler-refactoring)). Su motivo es que un constructor no puede elegir qué devolver ni llevar el nombre del acto. Bloch formuló el mismo movimiento de manera independiente como consejo de diseño de API —«Consider static factory methods instead of constructors»— y enumera sus ventajas: el método tiene nombre, no está obligado a crear un objeto nuevo en cada llamada y puede devolver cualquier subtipo del tipo declarado ([Bloch, 2018, ítem 1](#ref-bloch-2018)).

**Referencia para el Anexo E** (alfabéticamente antes de `ref-bogard-2025`):

> `<a id="ref-bloch-2018"></a>`Bloch, J. (2018). *Effective Java* (3.ª ed.). Addison-Wesley. Cap. 2, ítem 1, «Consider static factory methods instead of constructors»; ítem verificado en la tabla de contenidos del editor, https://www.pearson.de/media/muster/toc/toc_9780134686073.pdf (consultado el 2026-09-21). La primera edición es de 2001, posterior a *Refactoring* (1999).

**Y una corrección menor en la referencia existente** `ref-fowler-refactoring`: donde dice «Fowler, M. (s. f.). Catálogo de *Refactoring*», agregar tras el título de la ficha: «(en la 1.ª ed., 1999, *Replace Constructor with Factory Method*; renombrada en la 2.ª ed., 2018)». +0 líneas (cabe en la misma línea de fuente).

---

## Punto 2 (P0) — Qué le falta a la definición de *Invariant*

Hoy §3.1 dice: «*Business Rule* que se verifica mirando un solo objeto y que tiene que cumplirse **siempre**, desde que el objeto se crea». Tiene **dos** de las tres partes que la hacen operativa (alcance: un solo objeto; vigencia: toda la vida del objeto). Le falta la tercera, que es la que convierte la definición en criterio de diseño: **si se rompe, el objeto no debería existir**. Esa parte es la que explica por qué la *Invariant* se verifica en la fábrica y no en un `Validar()` posterior, y es la que el PO necesita para distinguirla de la *Precondition* sin volver a preguntar.

**Dónde:** §3.1, viñeta **Invariant**.
**Ancla:** `#31-definiciones`.
**Código nuevo:** no.
**Costo:** +1 línea neta.

Redacción exacta propuesta (reemplaza la viñeta entera):

> - **Invariant.** *Business Rule* que cumple tres condiciones a la vez: **vale toda la vida del objeto**, no solo antes de una acción; **se verifica mirando ese objeto solo**, sin consultar a otros ni a la base; y **si se rompe, el objeto no debería existir**, por eso se verifica al construirlo y no después. Es la *Class Invariant* de Meyer, «an assertion describing a property which holds of all instances of a class» ([Eiffel Software, s. f.](#ref-eiffel-sf); [Meyer, 1988](#ref-meyer-1988)). En el laboratorio: «el precio es mayor a cero». → §3.3, `Producto.cs`, la misma guarda dentro de `Create`; §3.7, `AsignarPrecio`.

---

## Punto 3 (P1) — Las tres mitades que la sostienen en código

Es el punto que hoy falta y el que más rinde. La guía **tiene** las tres piezas, pero repartidas en §3.3 (la fábrica), §3.4 (el setter privado) y §3.7 (`AsignarPrecio`), y nunca dice que son un mecanismo único ni qué se pierde si falta una. Quien lee puede copiar dos de tres y creer que la *Invariant* está protegida.

**Dónde:** §3.6, párrafo **El contrato**, inmediatamente después de la oración «…que es exactamente lo que hacen `Producto.Create` y el setter privado (§3.3, §3.4)».
**Ancla:** `#36-dónde-vive-una-business-rule-en-un-programa-orientado-a-objetos`.
**Código nuevo:** no — las tres columnas remiten a código ya compilado en la guía.
**Costo:** +8 líneas (tabla de 3 filas + encabezado + una línea de cierre).

Redacción exacta propuesta:

> Una *Invariant* no se sostiene con una guarda sino con tres piezas que trabajan juntas; si falta una, la regla es una intención, no una garantía.
>
> | Pieza | Qué hace | Dónde está | Si falta |
> | --- | --- | --- | --- |
> | El *Factory Method* | La **establece**: ningún objeto nace incumpliéndola | §3.3, `Producto.Create` | Nace un objeto inválido y la regla se verifica tarde, cuando ya hay datos guardados |
> | El setter privado | **Impide romperla desde afuera**: el compilador la protege, no la disciplina | §3.4, error CS0200 | Cualquier `producto.Precio = -1m` la saltea, venga de una pantalla, de un lote o de una prueba |
> | Cada método que toca el dato | La **vuelve a verificar** al cambiar el estado | §3.7, `AsignarPrecio` | El objeto nace bien y se rompe después: la regla vale en el alta y no en la modificación |
>
> Las tres son la misma decisión vista desde tres lados: el estado solo cambia por comportamiento, y todo el comportamiento que lo cambia verifica. **Criterio de esta guía.**

---

## Punto 4 (P1) — Tabla de ejemplos y contraejemplos para clasificar

El PO pidió ejemplos «que formen criterio». Un ejemplo solo forma criterio si viene con su contraejemplo pegado: lo que enseña no es «el precio es mayor a cero», es **por qué «no hay dos con el mismo DNI» no es lo mismo aunque suene igual**. Todos los candidatos ya existen en la guía y en el laboratorio; no hay que inventar ninguno.

**Dónde:** §3.7, después de la tabla de tres filas «Regla / Cuándo vale / Tipo» y antes del párrafo de Fowler sobre validación contextual. Va en §3.7 y no en §3.2 porque §3.7 es exactamente la sección cuya pregunta es «¿vale siempre o solo antes de una acción?».
**Ancla:** `#37-vale-siempre-o-solo-antes-de-una-acción-el-producto-sin-precio`.
**Código nuevo:** no.
**Costo:** +9 líneas (encabezado + 7 filas).

Redacción exacta propuesta:

> Las tres condiciones del §3.1 se usan como filtro. Basta que falle una para que la regla no sea *Invariant*, y entonces la guía ya dice dónde va:
>
> | Regla | ¿Toda la vida del objeto? | ¿Mirando ese objeto solo? | ¿Es *Invariant*? | Dónde va |
> | --- | --- | --- | --- | --- |
> | Si hay precio, es mayor a cero | Sí | Sí | **Sí** | `Producto.Create` y `AsignarPrecio` (§3.7) |
> | Un pedido confirmado se pide con al menos un ítem | Sí, desde que se confirma | Sí: el pedido conoce sus ítems | **Sí**, del *Aggregate* | `Pedido.Confirmar` (§4.10) |
> | El DNI tiene entre 7 y 8 dígitos | Sí | Sí | **Sí** | `Persona.Create` (§9.6, paso 4) |
> | No hay dos personas con el mismo DNI | Sí | **No**: hay que mirar a las demás | No | *Use Case* con *Repository*, con índice único de respaldo (§9.6, pasos 3 y 7) |
> | No se vende un producto sin precio | **No**: solo antes de vender | Sí | No: es *Precondition* | `Producto.PrecioDeVenta` (§3.7) |
> | El nombre admite hasta 100 caracteres porque la columna lo impone | Sí | Sí | No: no pasa la prueba del papel (§3.2) | Configuración de EF Core (Infrastructure) |
> | Solo quien administra el catálogo da de alta | No: depende de quién pide | No: hay que mirar al usuario | No: es *authorization* | *Use Case* o borde (§3.6) |

Las dos últimas filas son deliberadas: muestran que una regla puede pasar las dos primeras preguntas y seguir sin ser *Invariant* del dominio, porque falla la del §3.2 (¿es del negocio?) o la de Wirfs-Brock (¿quién conoce el dato?).

---

## Punto 5 (P2) — La invariante del *Aggregate*, en §4.10

Sí, Evans distingue los dos niveles, y la distinción tiene consecuencia práctica: hay reglas que ningún objeto individual puede cumplir y que **tampoco** son del *Use Case*, porque el dato necesario está adentro del *Aggregate*. «Un pedido confirmado tiene al menos un ítem» es exactamente ese caso: `ItemPedido` no la puede cumplir y `Pedido` sí, mirando dentro de su propio borde. Por eso la guía debería nombrarlo: hoy §4.10 explica muy bien el *Aggregate Root* como control de acceso, pero no dice **para qué** sirve ese control, que es sostener una invariante que abarca a más de un objeto.

La cita que corresponde es la de la fuente que la guía ya usa, no la del libro de 2003 (ver Resumen, punto 3).

**Dónde:** §4.10, al final del párrafo «¿Producto y Pedido son Entities?», después de «…el bloque de `ItemPedido`, más abajo, lo muestra.»
**Ancla:** `#410-un-use-case-con-dos-entities-registrarpedido`.
**Código nuevo:** no — `Pedido.Confirmar` y `AgregarItem` ya están compilados en §4.10 y la extensión 4a del enunciado ya nombra la regla.
**Costo:** +3 líneas.

Redacción exacta propuesta:

> El borde no está para ordenar el código: está para que alguien pueda hacer cumplir una regla que ningún objeto suelto alcanza a verificar. Evans lo pide en el mismo «Therefore»: «Define properties and invariants for the aggregate as a whole and give enforcement responsibility to the root or some designated framework mechanism» ([Evans, 2015](#ref-evans-2015)). «Un pedido confirmado tiene al menos un ítem» es una *Invariant* del *Aggregate*, no de una *Entity* suelta: `ItemPedido` no puede verificarla y `Pedido` sí, porque los ítems están dentro de su borde. Por eso la extensión 4a del enunciado nombra a `Pedido.Confirmar`, y por eso el constructor de `ItemPedido` es `internal`: si los ítems pudieran crearse por fuera, la raíz no tendría nada que hacer cumplir.

**Glosario (Anexo D), fila `Invariant`:** donde dice «Business Rule que un objeto cumple siempre, desde que se crea», proponer «Business Rule que vale toda la vida del objeto, se verifica mirando ese objeto solo y, si se rompe, el objeto no debería existir; cuando abarca a un *Aggregate*, la hace cumplir la raíz», y agregar §4.10 a la columna de secciones. +0 líneas.

---

## Punto 6 (P3) — Lo que recomiendo **no** hacer

Tres cosas, para que el presupuesto del ciclo no se vaya en adorno:

1. **No agregar código.** Los tres puntos anteriores se sostienen enteros con código ya compilado y ya capturado (`Producto.Create`, el CS0200 de L10, `AsignarPrecio`, `Pedido.Confirmar`, `Persona.Create`). Un bloque nuevo para ilustrar «las tres mitades» sería una cuarta versión de `Producto` y confundiría más de lo que aclara; los dos bloques del ciclo quedan íntegros para la comisión .NET.
2. **No citar la frase de Evans de 2003** («invariants … whenever data changes») mientras la guía no tenga el libro a la vista. La Reference 2015 dice lo mismo con otras palabras y es la fuente que la guía ya declara. Una cita de segunda mano en una guía que se precia de marcar procedencia es peor que no citarla.
3. **No convertir a Bloch en el autor de la práctica.** El PO preguntó «quién la propuso», y la respuesta honesta es que está catalogada desde 1999 en *Refactoring* y que Bloch la argumentó por su cuenta dos años después. Presentarlo al revés sería cómodo y falso.

**Total propuesto: +23 líneas de cuerpo + 2 líneas de referencia + 0 bloques de código.** Queda margen holgado dentro del presupuesto del ciclo.

---

## Fuentes consultadas

- Fowler, M. (s. f.). *Replace Constructor with Factory Function* (catálogo de *Refactoring*). https://refactoring.com/catalog/replaceConstructorWithFactoryFunction.html — consultado el 2026-09-21. Alias declarado en la ficha: *Replace Constructor with Factory Method*. Sin línea de atribución a autor distinto.
- Fowler, M. (s. f.). *Refactoring catalog* (índice). https://refactoring.com/catalog/ — consultado el 2026-09-21. Criterio de alias: «Each card shows the name used in the second edition together with any aliases for the refactoring (such as names for first edition refactorings that it replaces)». Marcado de la ficha: `data-books='refactoring2,refactoring,rubyref'` (aparece en la 1.ª y en la 2.ª edición).
- Pearson. *Effective Java, Third Edition — Table of Contents* (ISBN 9780134686073). https://www.pearson.de/media/muster/toc/toc_9780134686073.pdf — consultado el 2026-09-21. Cap. 2 «Creating and Destroying Objects», «Item 1: Consider static factory methods instead of constructors».
- Open Library. *Effective Java: Programming Language Guide* (Bloch, J., 1.ª ed., Addison-Wesley, 2001; ISBN 0-201-31005-8). https://openlibrary.org/books/OL3967005M/Effective_Java — consultado el 2026-09-21. Usado solo para fechar la 1.ª edición frente a *Refactoring* (1999); no se cita en la guía.
- Evans, E. (2015). *Domain-Driven Design Reference: Definitions and Pattern Summaries*. https://www.domainlanguage.com/wp-content/uploads/2016/05/DDD_Reference_2015-03.pdf — consultado el 2026-09-21. Descargado y verificado el texto de *Aggregates* («Define properties and invariants for the aggregate as a whole…») y de *Factories*. **Búsqueda negativa registrada:** la cadena «whenever data changes» no aparece en el documento.
- Eiffel Software (s. f.). *Design by Contract: Introduction*. https://www.eiffel.com/values/design-by-contract/introduction/ — consultado el 2026-09-21. «An assertion describing a property which holds of all instances of a class is called a class invariant». Nota: la página **no** enuncia explícitamente los momentos en que la invariante debe valer (creación y fin de cada rutina exportada); por eso la propuesta del punto 3 presenta las tres piezas como **criterio de esta guía** y no como cita de Meyer.
- Guía en revisión: `Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md`, v2.2.0, §3.1, §3.2, §3.4, §3.6, §3.7, §4.10, Anexo D y Anexo E — leída el 2026-09-21.
