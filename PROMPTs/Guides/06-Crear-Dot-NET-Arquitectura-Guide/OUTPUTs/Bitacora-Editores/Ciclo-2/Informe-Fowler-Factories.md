# Informe de la comisión MARTIN FOWLER — Fábricas, guardas, resultados y valores

| | |
| --- | --- |
| **Fecha** | 2026-09-20 |
| **Comisión** | MARTIN FOWLER (personificada: se juzga con el criterio y los textos de Fowler; toda afirmación sobre «lo que Fowler sostiene» lleva cita verificada en `martinfowler.com` o en el catálogo de PoEAA, con URL y fecha de consulta en la última sección) |
| **Objeto** | `LAB/Lab-Documentos/Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md` v2.1.0 (la carpeta se renombró de `Guides/Arquitectura` a `Guides/Dot-NET-Arquitectura-Guide`; las referencias internas de este informe usan la ruta nueva) |
| **Objeto de estudio adicional** | `PROG2/Geometria/Lab-Geometria/src/GeometriaFactory.Domain` — leído, no editado: `Entities/Work.cs`, `Entities/Account.cs`, `Guards/DomainResult.cs`, `Guards/Admission.cs`, `Values/*.cs` |
| **Caso** | Pedido del Product Owner del 2026-09-20 sobre fábricas estáticas, constructor privado, guardas y resultados tipados, más el addendum sobre los `Values` y la «línea de pensamiento» entidad → intención → hecho consumado |
| **Competencia** | Validación y su forma de rechazo (excepción / *Notification*), *Value Object* y la dicotomía referencia/valor, nombres de refactorizaciones y de patrones de PoEAA, *Contextual Validation*, *Command-Query Separation*. **Fuera de competencia**: las decisiones de producto de Lab-Geometria, su SDD, su norma de nomenclatura y sus casos de uso; se los cita como evidencia de forma, nunca se los juzga |
| **Modo** | A ciegas: no se leyó ningún informe de otra comisión de este ciclo |
| **Anclas** | Lectura de §0.5 de la guía. **E1** salida registrada de una ejecución real; **E2** `[Compilado: …]`; **E3** `[Compilado sin captura: …]`; **E4** `[Fragmento ilustrativo: motivo]`; **C** `Criterio de esta guía` |
| **Niveles** | **P0** corrige algo verificablemente incompleto o sin fuente donde la guía afirma; **P1** falta que impide al lector elegir; **P2** mejora el juicio del lector; **P3** opcional |

**Aviso de método.** Cada punto dice *qué agregar* (dirección), *en qué sección*, *nivel*, *ancla* y *si hace falta código nuevo*. No se redacta el texto de la guía: eso es del editor. Diez puntos del encargo original (P-01…P-10) y tres del addendum (A-01…A-03).

---

## P-01. Lo que Evans manda en «Factories» no es el método estático: es un objeto aparte

**Hallazgo.** §3.1 dice: «Evans describe la *Factory* como la operación que crea el objeto o el agregado entero haciendo cumplir sus *Invariants* ([Evans, 2015])». La segunda mitad está respaldada al pie de la letra; la primera recorta lo que la fuente manda. El texto verificado del *DDD Reference* 2015, apartado «Factories», dice:

> «Therefore: Shift the responsibility for creating instances of complex objects and aggregates to a separate object, which may itself have no responsibility in the domain model but is still part of the domain design. Provide an interface that encapsulates all complex assembly and that does not require the client to reference the concrete classes of the objects being instantiated. **Create an entire aggregate as a piece, enforcing its invariants.** Create a complex value object as a piece, possibly after assembling the elements with a builder.»

Y el problema que la justifica, también verbatim: «Making the client direct construction muddies the design of the client, breaches encapsulation of the assembled object or aggregate, and overly couples the client to the implementation of the created object.»

O sea: la *Factory* de Evans nace cuando la construcción «becomes complicated or reveals too much of the internal structure». El método estático en la propia *Entity* es el caso liviano de esa familia, no su definición. `Producto.Create` y `Work.Create` son fábricas legítimas precisamente porque la construcción no necesita colaboradores ni decide clases concretas; el día que necesite cualquiera de las dos cosas, el patrón pide un objeto aparte, y el lector de la guía no tiene con qué ver esa frontera.

**Qué agregar.** Una frase de frontera detrás de la viñeta *Factory Method* de §3.1: la fábrica vive en la propia *Entity* mientras la construcción sea un chequeo de sus datos; se muda a un objeto aparte cuando necesita colaboradores (otro agregado, un servicio de dominio), cuando arma varias piezas o cuando el cliente tendría que nombrar clases concretas. Citar el «Therefore» completo, no la mitad.

**Sección** §3.1 (viñeta *Factory Method*), con eco de una línea en §3.3. **Nivel** P1. **Ancla** C, apoyada en Evans 2015 (ya en Anexo E). **Código** no hace falta.

---

## P-02. El nombre correcto del movimiento existe y es una refactorización de tu propio catálogo

**Hallazgo.** §3.1 aclara bien que *Factory Method* en GoF designa otro patrón, basado en subclases —y es una aclaración que casi ningún material .NET hace—. Pero deja al lector sin nombre para lo que sí está haciendo. El nombre existe y está en el catálogo de *Refactoring*: **«Replace Constructor with Factory Function»**, con el alias explícito **«Replace Constructor with Factory Method»** (verificado en `refactoring.com/catalog/replaceConstructorWithFactoryFunction.html`; el ejemplo del catálogo va de `new Employee(document.leadEngineer, 'E')` a `createEngineer(document.leadEngineer)`).

Eso le da a la guía algo que hoy no tiene: el **movimiento**. En un laboratorio no se parte de la fábrica; se parte del constructor público y se llega a la fábrica por una refactorización con nombre, motivo y paso a paso.

**Qué agregar.** En §3.1, una línea: el paso de constructor a método estático es una refactorización catalogada (nombre y alias), y su motivo es que el constructor no puede elegir qué devolver ni llevar nombre propio. En §3.3, nombrar el movimiento al mostrar `private Producto()` + `Create`.

**Sección** §3.1 y §3.3. **Nivel** P2. **Ancla** C + nueva entrada en Anexo E (Fowler, *Refactoring* catalog). **Código** no hace falta.

---

## P-03. No hay dos constructores: hay uno, y ese es el hecho que la guía tiene que explicar

**Hallazgo (corrección al planteo del caso).** El pedido habla de «DOS constructores privados con propósitos opuestos». En el código leído no hay dos. Hay **uno solo**, sin parámetros, y la fábrica lo usa a través del inicializador de objeto:

- `Work.cs`: `private Work() { Name = string.Empty; DeclaredDate = string.Empty; OriginalJson = string.Empty; }`, documentado como «Constructor de materialización. Lo usa el motor de persistencia y nadie más», y `Create` devuelve `new Work { Id = Guid.NewGuid(), OwnerId = ownerId, … }`.
- `Account.cs`: idéntica forma, con dos fábricas (`ConfigureAdministrator`, `Register`) que pasan por ese mismo constructor.

Los **propósitos** opuestos son reales: materializar una fila ya constituida y constituir un hecho nuevo. Lo que no es real es que estén separados en dos constructores. Están separados en *un constructor que no decide nada* y *una fábrica que decide todo*. Eso es más fuerte, no más débil: el constructor no puede ser un segundo camino de alta porque no sabe recibir datos.

La forma con dos constructores existe y es la que documenta EF Core para el enlace por parámetros; ahí sí habría un constructor con parámetros para la constitución y otro sin parámetros para la materialización. Verbatim de la documentación de EF Core:

> «When EF Core creates instances of these types, such as for the results of a query, it will first call the default parameterless constructor and then set each property to the value from the database. However, if EF Core finds a parameterized constructor with parameter names and types that match those of mapped properties, then it will instead call the parameterized constructor with values for those properties and will not set each property explicitly.»

Y, sobre la accesibilidad: «The constructor can be public, private, or have any other accessibility. However, lazy-loading proxies require that the constructor is accessible from the inheriting proxy class.»

**De paso, un P0 de la guía.** §5.4 afirma «usa el constructor privado y asigna las propiedades por su cuenta» **sin fuente**. La fuente existe, es la frase citada arriba y está en `learn.microsoft.com`. Hoy esa afirmación queda como si fuera del autor.

**Qué agregar.** (a) En §3.3, una nota corta: el constructor privado sin parámetros no es un segundo camino de alta sino el camino del ORM, y la fábrica lo usa por inicializador; si alguna vez hay dos constructores, el de parámetros es el de constitución y el otro sigue siendo el del ORM. (b) En §5.4, citar la documentación de EF Core en la frase que hoy no la tiene.

**Sección** §3.3 (nota) y §5.4 (cita). **Nivel** P0 la cita de §5.4; P1 la nota de §3.3. **Ancla** E2 para el código existente + nueva entrada en Anexo E (Microsoft, *Entity types with constructors*). **Código** no hace falta: alcanza con `Producto.cs` tal como está.

---

## P-04. Por qué el camino de materialización no valida: hay tres razones y ninguna fuente que lo diga

**Hallazgo.** Ninguna de las tres fuentes que corresponden —Evans (2015), Fowler (PoEAA y bliki) y la documentación de EF Core— dice en ningún lado «el constructor de materialización no debe validar». **Lo digo como criterio, y así hay que marcarlo.** Lo que las fuentes sí sostienen y sirve de apoyo:

- Evans, *Assertions* (verbatim): «State post-conditions of operations and invariants of classes and aggregates. […] **Assertions define contracts of services and entity modifiers.** Assertions define invariants on aggregates.» Las aserciones gobiernan los *modificadores*; rehidratar no es modificar.
- EF Core: el enlace es **por convención** («Currently, all constructor binding is by convention»), así que una excepción lanzada ahí no ocurre en el alta sino **en medio de una consulta**, y el lector la ve como un 500 sin relación aparente con el dato que la causó.

Las tres razones, ordenadas para la guía: (1) la fila ya fue constituida por la fábrica y la regla ya se ejerció entonces; (2) los setters privados impiden que se rompiera después (§3.4 ya lo demuestra con CS0200); (3) validar al materializar convierte un dato viejo inválido en una consulta rota, y eso no es lo que el negocio quiere que pase.

**Y el criterio observable que sigue**, que es lo valioso: si la base **puede** tener filas inválidas —esquema heredado, escenario E-C— la comprobación existe, pero no en el constructor: va en el adaptador que traduce, que es quien puede decidir descartar, marcar o reportar. Eso conecta con §7.2 g y no obliga a inventar nada nuevo.

**Qué agregar.** Un párrafo en §5.4 con las tres razones y el criterio de E-C, marcado **Criterio de esta guía**, apoyado en la frase de Evans sobre *modifiers* y en la convención de enlace de EF Core.

**Sección** §5.4, con remisión desde §3.3. **Nivel** P1. **Ancla** C (explícita: no hay fuente que lo mande) + Evans 2015 + Microsoft. **Código** no hace falta.

---

## P-05. Varias fábricas con nombre del acto: la fuente es «Intention-Revealing Interfaces», y §8.4 hoy las empuja al lugar equivocado

**Hallazgo.** `Account` tiene dos altas —`ConfigureAdministrator` y `Register`— y el propio código explica por qué no es una con bandera: «una bandera habría dejado que el estado inicial y la credencial se eligieran desde afuera». Ese es exactamente el argumento de Evans, verbatim:

> «Therefore: Name classes and operations to describe their effect and purpose, without reference to the means by which they do what they promise. This relieves the client developer of the need to understand the internals. **These names should conform to the ubiquitous language** so that team members can quickly infer their meaning.»

Y el lenguaje ubicuo, también verbatim: «Use the model as the backbone of a language. […] **Recognize that a change in the language is a change to the model.** […] Then refactor the code, renaming classes, methods, and modules to conform to the new model.»

**El roce con la guía.** §8.4 dice hoy: «Las operaciones estándar de un patrón también son vocabulario del patrón, no del problema», con `Create`, `AddAsync`, `GetById` como ejemplos, y §3.1 repite la regla. Leída al pie, esa regla manda llamar `Create` a una fábrica que nombra un acto del negocio —y `Register` / `ConfigureAdministrator` / `Registrar` / `ConfigurarAdministrador` no son operaciones estándar de ningún patrón: son actos. La regla y su excepción conviven, pero la guía solo escribió la regla.

**El criterio observable, que es lo que falta.** *Hay más de una fábrica cuando hay más de un acto, y se reconoce por la bandera*: si un parámetro booleano o un enum elige **qué conjunto de reglas se aplica** —no qué valor toma un campo—, ahí hay dos fábricas disfrazadas de una. `Account` lo muestra entero: dos altas con estado inicial, papel y credencial opuestos.

**Qué agregar.** (a) En §8.4, una fila y una frase: cuando la operación deja de ser la creación estándar y nombra un acto del negocio, el nombre sale del vocabulario ubicuo y le rige la columna de negocio de la tabla, no la de patrón. (b) En §3.3, dos o tres líneas sobre la prueba de la bandera, con un fragmento de dos firmas.

**Sección** §8.4 (regla) y §3.3 (criterio). **Nivel** P1. **Ancla** C + Evans 2015. **Código** un fragmento **E4** de dos firmas alcanza; no hace falta tocar el laboratorio.

---

## P-06. Excepción o resultado: el aporte central

**Lo que sostengo, verificado.** De «Replacing Throwing Exceptions with Notification in Validations» (09 December 2014), verbatim:

> «Firstly I'm not happy with using exceptions for something like this. Exceptions signal something outside the expected bounds of behavior of the code in question. But if you're running some checks on outside input, this is because you expect some messages to fail - and **if a failure is expected behavior, then you shouldn't be using exceptions.**»

> «The second problem with code like this is that it fails with the first error it detects, but usually it's better to report all errors with the incoming data, not just the first. That way a client can choose to display all errors for the user to fix in a single interaction rather than give her the impression she's playing a game of whack-a-mole with the computer.»

> «I need to stress here, that I'm not advocating getting rid of exceptions throughout your code base. Exceptions are a very useful technique for handling exceptional behavior and getting it away from the main flow of logic. **This refactoring is a good one to use only when the outcome signaled by the exception isn't really exceptional**, and thus should be handled through the main logic of the program.»

> «An important consequence of this is that **whether to use exceptions for a particular task is dependent on the context.**»

> «**There is a case when it may be sensible to use exceptions for validation failures.** This would be situations where you have data that you expect to have already been validated earlier in processing, but you want to run the validation checks again to guard against a programming error letting some invalid data slip through.»

> «This article is about replacing exceptions for notification in the context of validating raw input. […] **Guard clauses** remain appropriate elsewhere» *(el artículo lo dice en la forma citada arriba sobre el defecto de programación; la nota al pie 1 agrega:)* «Another common validation approach is just to return a boolean indicating if the input is valid or not. While this makes it easy for the caller to invoke different behavior, **it doesn't give any way to provide diagnostics beyond the useless "an error has occurred"**.»

Y de «Notification» (09 August 2004), verbatim: «The most obvious alternative to using Notification is for the domain to use exception handling to indicate errors. […] The problem with this is that **it only indicates the first validation error.**» Con la salvedad, que es honesta y hay que reproducir: «On the whole I feel that validation errors are sufficiently common that it isn't worthwhile to use exception handling mechanisms for these cases, **but that's not an overwhelming preference.**»

**Dictamen.**

1. **Defecto de programación del llamador → excepción.** `DomainResult.Rejected` con `ArgumentException.ThrowIfNullOrWhiteSpace`, y `AdoptInterpretation` con `ArgumentNullException.ThrowIfNull`, están del lado correcto de la línea: son datos que el contrato ya exigía. El comentario de `DomainResult.cs` —«la excepción queda reservada al defecto de programación del consumidor»— coincide palabra por palabra con el caso que el artículo admite.
2. **Rechazo esperable de entrada externa → resultado / notificación.** Es el caso de `Create`, `Edit`, `Submit`, `ApplyOutcome`.
3. **El contexto decide**, y por eso la guía no puede dictar una sola forma.

**Lo que la guía tiene hoy y lo que le falta.** §3.3 lanza `DomainException` y §5.6 la traduce a 400. Es una decisión legítima y está marcada como **Criterio de esta guía** en lo que hace al código de estado. Pero:

- No hay **criterio para elegir**: el lector que llega con un formulario de seis campos no tiene con qué decidir.
- No se dice en ningún lado que el camino de la excepción **informa un solo error**, que es el costo que paga y el motivo del «whack-a-mole».
- §3.7 ya cita *ContextualValidation* y la pregunta «should failing this test prevent saving?». El puente entre esa pregunta y **la forma del rechazo** no está escrito: son el mismo tema visto dos veces.

**El criterio observable que propongo** (cuatro preguntas, al estilo de la tabla de §3.2, que es el formato que la guía ya sabe usar): ¿el rechazo es esperable por la entrada? ¿la persona necesita ver todos los motivos a la vez, o el primero alcanza? ¿el llamador hace algo **distinto** según el motivo, o solo aborta? ¿el motivo tiene que cruzar un borde (HTTP, pantalla, otro proceso) sin texto de presentación? Dos o más síes → resultado; defecto de programación → excepción; ninguna razón fuerte → la excepción es menos ceremonia y está bien.

**El costo del resultado tipado, sin barrer nada.** Cada llamador escribe su `if (!r.Succeeded) return …`; el resultado **se puede ignorar** y el compilador no obliga a mirarlo, mientras que la excepción no se puede ignorar; no sirve en constructores ni en propiedades; y en una cadena de tres operaciones la ceremonia se multiplica por tres. Contra eso, la excepción paga un salto de control invisible y un solo error por vez.

**Y el dictamen filoso sobre el objeto de estudio.** `DomainResult` de Geometría lleva **un** `ConditionCode`, no una colección. Eso compra la primera mitad de mi argumento —no usar excepciones para lo esperable— y **no compra la segunda**: se detiene en el primer motivo, que es exactamente el defecto que le atribuyo a la excepción. Para operaciones de una sola decisión (enviar, aprobar, resolver alcance) está perfectamente bien y es hasta preferible. Para un alta con cinco campos obligatorios, la persona corrige de a uno. No es un error del proyecto —es una forma con un límite—, pero **la guía tiene que escribir ese límite**, porque el lector que copie la forma va a copiarla para un formulario.

**Qué agregar.** Una subsección nueva en §3, después de §3.7 («¿Excepción o resultado?»), con: las citas de 2014 y 2004, la tabla de cuatro preguntas, el costo de cada opción, la aclaración de que un motivo único no es una *Notification*, y el puente explícito con §3.7.

**Sección** §3 (subsección nueva) + dos líneas en §5.6. **Nivel** P0 (es el vacío central del encargo). **Ancla** C para el criterio; Fowler 2014 y Fowler 2004 para lo citado (2004 es entrada nueva en el Anexo E; 2005b ya está). **Código**: alcanza con un fragmento **E4** de 12 líneas del tipo resultado. **Opcional P1**: una variante compilada (**E2**, mecanismo `Variantes/` que la guía ya tiene) con `Producto.TryCreate` devolviendo resultado y el borde traduciendo código → 400 sin excepción; sería la primera vez que el lector ve las dos formas corriendo.

---

## P-07. El borde: hoy el mensaje de la regla **es** el texto de la pantalla

**Hallazgo.** El `DomainExceptionHandler` de §5.6 hace `Detail = exception.Message`. O sea: la cadena que escribió quien programó la *Entity* llega tal cual al consumidor. Funciona, y en un laboratorio es lo correcto; pero es una decisión con consecuencias que la guía no nombra: el texto de presentación vive en `Domain`, no se puede traducir, no se puede cambiar sin tocar la regla, y el cliente no puede reaccionar distinto según el motivo porque solo recibe prosa.

La alternativa está descrita, verbatim, en «Notification» (2004):

> «A notification object will typically have methods for adding errors that **use error codes rather than strings**, and convenience methods to tell if the notification has any errors present.»

> «Error codes need to be present on classes that are shared between presentation and domain. **Using error codes provides a more explicit statement of the expected errors and makes it easier for the presentation to present the errors in a more interactive way than just printing out error messages.** […] With a domain model the error codes need to be designed around the vocabulary of the domain model itself.»

Eso es, punto por punto, lo que hace `ConditionCode` en Geometría. Y hay una advertencia de la misma fuente que le sirve a la guía para el escenario E-B: «If you are using Notification in a system where the presentation and domain logic are in different processes, you need to ensure that the Notification only contains information that can be safely transported across the wire.»

**Qué agregar.** En §5.6, un párrafo: con excepción, el borde traduce **mensaje**; con resultado, traduce **código** a estado y a texto, y el texto de presentación deja de vivir en `Domain`. Nombrar el miembro de extensión del `ProblemDetails` (RFC 9457, ya citado en la guía) como el lugar natural del código.

**Sección** §5.6. **Nivel** P1. **Ancla** C + Fowler 2004 + IETF (ambas referencias ya disponibles o nuevas en el Anexo E). **Código** un fragmento **E4** de cuatro líneas de JSON alcanza.

---

## P-08. `Admission`: no es *Specification*, no es *Guard Clause*, y sí tiene nombre

**Verificado antes de nombrar.**

- **No es *Specification*.** El patrón (Evans y Fowler, 1997, `martinfowler.com/apsupp/spec.pdf`) dice, verbatim: «Create a specification that is able to tell if a candidate object matches some criteria. The specification has a method `isSatisfiedBy (anObject) : Boolean` that returns true if all criteria are met by anObject.» Y trae su propia advertencia de exclusión: «if you find that you don't use `isSatisfiedBy` or `isGeneralizationOf` […] you should reconsider the use of this pattern.» `Admission` no es un predicado aplicado a un candidato: es el **resultado** que devuelve `Account.EvaluateAdmission()`, un método de la propia cuenta. No hay objeto-criterio, no hay candidato, no hay composición. No es *Specification*.
- **No es *Guard Clause*.** En el catálogo de *Refactoring*, «Replace Nested Conditional with Guard Clauses» es una transformación de la **forma del control de flujo dentro de un método** (verificado: el antes/después del catálogo va de `if/else` anidados a `if (isDead) return deadAmount();`). Es lo que hacen por dentro `Create`, `Edit` y `Submit` —y muy bien—, pero no es el nombre de un tipo. La carpeta `Guards/` nombra la forma interna de los métodos, no lo que contiene.
- **Sí es** tres cosas con nombre, todas verificadas: (1) una **Query** en el sentido de *Command-Query Separation*, que la guía ya cita: «Queries: Return a result and do not change the observable state of the system (are free of side effects)»; (2) una **Side-Effect-Free Function** de Evans: «Therefore: Place as much of the logic of the program as possible into functions, operations that return results with no observable side effects»; (3) una ***Notification* degenerada**, de exactamente un motivo y sin texto —el propio comentario del código lo dice: «Admisible lleva CERO motivos; no admisible lleva EXACTAMENTE UNO».
- **Y es, literalmente, lo que §3.7 ya cita.** «So rather than have methods like `isValid` have methods like `isValidForCheckIn`» (*ContextualValidation*, 2005). `EvaluateAdmission` **es** `isValidForCheckIn`. La guía tiene la cita y no tiene el puente al tipo.

**Una observación fina que la guía puede aprovechar.** `Work.StatusOutsideAdministratorScope` expone el predicado **como dato** porque «un predicado escrito como método no lo puede traducir el motor de datos y terminaría copiado en la consulta». Ese es, históricamente, el problema que hace aparecer *Specification*: el mismo criterio tiene que valer en memoria y en la base. Vale una línea, como señal de cuándo el predicado se saca del objeto.

**Qué agregar.** En §3 (junto a la subsección nueva de P-06) o al final de §3.7: la consulta que contesta sin mutar tiene nombre —consulta en el sentido de CQS, función sin efecto en el sentido de Evans— y es la forma de la validación contextual que §3.7 ya predica; *Specification* se reserva para cuando el predicado se saca del objeto para combinarlo o para traducirlo a una consulta de datos. Nombrarlo **sin** llamarlo *Guard Clause*.

**Sección** §3.7 (cierre) + viñeta en §3.1. **Nivel** P1 el puente con §3.7; P2 la nota de *Specification*. **Ancla** C + Fowler 2005a (ya en Anexo E), Evans 2015, Evans y Fowler 1997 (entrada nueva). **Código** no hace falta.

---

## P-09. `ConditionCode`: el contrato de error también es contrato

**Hallazgo.** §7.2 d enseña la regla correcta para el éxito: «exactamente los campos del contrato, y ninguno más. […] Agregar un campo al contrato es fácil; quitarlo rompe a cada cliente que lo usaba». No hay una sola línea equivalente para el error. Y el error es lo que más se consume programáticamente: un cliente que decide por el motivo del rechazo depende de ese código igual que de un campo.

`ConditionCode` es la versión disciplinada de eso: conjunto cerrado, sin texto de presentación, transcrito de un catálogo único («esta clase no acuña ninguno, los transcribe»), con los códigos que ninguna operación puede producir **deliberadamente ausentes**. Es lo que la fuente pide: «the error codes need to be designed around the vocabulary of the domain model itself» y «Error codes need to be present on classes that are shared between presentation and domain».

**Qué agregar.** (a) En §7.2 d, un párrafo y una fila del cuadro ✅/❌: el código de condición es parte del contrato y se versiona con el mismo cuidado que un campo; ❌ devolver el `Message` de la excepción como si fuera contrato estable. (b) En §5.6, dónde viaja el código dentro del `ProblemDetails`.

**Sección** §7.2 d y §5.6. **Nivel** P1. **Ancla** C + Fowler 2004. **Código** no hace falta.

---

## P-10. Lo que **no** hay que importar: la proporción, y dónde se escribe

**Hallazgo.** La forma de Geometría —33 códigos, resultado tipado en cada operación, y declaraciones que aporta el consumidor (`emailUniquenessVerified`, `originalJsonPreservedDeclared`, `administratorAbsenceDeclared`, `createdAt`)— es proporcional a un producto con especificación escrita y trazabilidad a casos de uso. Trasplantada a la tienda del §0.4, sería ceremonia sin beneficio, y la guía perdería lo que mejor hace: mostrar el escalón mínimo que resuelve.

Dicho eso, **una de esas ideas sí merece entrar**, porque resuelve una fila que la guía ya tiene abierta. §3.6 dice que la regla «sobre varias instancias» (nombre no repetido) no la puede cumplir la *Entity* «porque un producto no conoce a los demás», y que la cumple el *Use Case* con el *Repository*. Geometría da el paso siguiente: pasa **la declaración de que se comprobó** como parámetro, y la fábrica **rechaza si no llega**. Así la *Entity* no comprueba lo que no puede comprobar, pero tampoco se deja constituir sin que alguien lo haya hecho. Es barato, es una línea de código y cierra un agujero que hoy la guía deja abierto (nada impide hoy llamar a `Create` salteando la comprobación de unicidad).

**Qué agregar.** (a) En §9.3, una fila en la tabla de señales: «el borde necesita distinguir motivos de rechazo, o hay que mostrar varios a la vez» → se sube de la excepción al resultado tipado. Es la forma que la guía ya usa para todo: señal observable, no fecha. (b) En §3.6, dos líneas sobre la declaración como parámetro, con el ❌ correspondiente.

**Sección** §9.3 y §3.6. **Nivel** P2. **Ancla** C. **Código** no hace falta.

---

# Addendum — Values y la línea de pensamiento

## A-01. De los once `Values`, ninguno es un *Value Object* en el sentido que la guía enseña, y eso hay que decirlo

**Inventario leído.** Nueve enums (`WorkStatus`, `Role`, `FigureType`, `AccountStatus`, `ComponentRole`, `ObservationKind`, `WorkOperation`, `WorkOutcome` y `WorkStatus` por estado del trabajo), una clase estática de constantes (`ConditionCode`) y una función de normalización (`EmailIdentity.Normalize`). Tres especies distintas en una sola carpeta llamada `Values`.

**Las fuentes, verificadas.**

- Evans 2015, *Value Objects*: «Therefore: **When you care only about the attributes and logic of an element of the model, classify it as a value object. Make it express the meaning of the attributes it conveys and give it related functionality.** Treat the value object as immutable. Make all operations Side-effect-free Functions that don't depend on any mutable state. Don't give a value object any identity…»
- PoEAA, catálogo: «A small simple object, like money or a date range, whose equality isn't based on identity.»
- Bliki *Value Object* (14 November 2016): «Objects that are equal due to the value of their properties, in this case their x and y coordinates, are called value objects», y la regla: «value objects should be immutable».
- Bliki *Evans Classification* (14 December 2005): «Values are usually little things like Date, Money, Database Query. […] **Values may be primitives (in languages that make the distinction) or have special language support (as they do in .NET) but they don't have to.**»

**Dictamen.**

1. **Los nueve enums son valores, no *Value Objects* del patrón.** Del lado de la dicotomía referencia/valor están claramente del lado valor: igualdad por valor, inmutables, sin identidad, y en .NET con soporte del lenguaje —que es el caso que *Evans Classification* admite explícitamente—. Pero al patrón que la guía enseña con `Dinero` le falta lo que Evans pone en el «Therefore»: «give it related functionality». El enum no tiene funcionalidad. Llamarlo «*Value Object* degenerado» es defendible y lo firmo, con una condición: que se diga **qué** está degenerado, que es el comportamiento. Mi preferencia para la guía es el nombre llano: **conjunto cerrado del dominio**. Lo que aportan es vocabulario, y el vocabulario es trabajo del lenguaje ubicuo, no del patrón.
2. **`ConditionCode` no es un valor de ningún tipo**: es un catálogo de constantes, y ya tiene nombre propio en la literatura, el de P-09 («error codes […] present on classes that are shared between presentation and domain»).
3. **`EmailIdentity` no es un *Value Object*: es una función.** Un *Value Object* sería el tipo que envuelve la forma normalizada. Ver A-02.

**Qué agregar.** En §3.1 (viñeta *Value Object*) o en §7.1, una lista corta de **qué no es un *Value Object***: el enum de conjunto cerrado (es vocabulario, no comportamiento), el catálogo de constantes (es contrato) y la función auxiliar (es una función). El motivo es didáctico y concreto: un alumno que abre una carpeta `Values/` con once archivos va a concluir que los once son el patrón de `Dinero`, y no lo son.

**Sección** §3.1 y §7.1. **Nivel** P1. **Ancla** C + Evans 2015 + PoEAA + bliki 2016 + *Evans Classification*. **Código** no hace falta.

---

## A-02. «Un valor se vuelve tipo cuando tiene una regla que proteger»: es criterio propio, y está bien que lo sea

**Hallazgo.** La guía sostiene ese umbral en dos lugares: §7.1, columna «Existe solo si…» → «el valor tiene comportamiento o reglas propias»; y §3.8 → «¿Cuándo no conviene el Value Object? Cuando el valor no tiene comportamiento ni reglas propias», **marcado Criterio de esta guía**.

**Veredicto contra las fuentes: es más estricto que las dos.** Evans dispara el patrón por la pregunta conceptual —«when you care only about the attributes and logic of an element of the model»— y recién después pide darle funcionalidad; mis propios textos hacen eje en la **igualdad**, no en la regla: un `Point(2,3)` es un *Value Object* de manual y no protege ninguna regla. O sea: «tiene una regla» es **suficiente** para que convenga un tipo, pero no es lo que las fuentes ponen como **necesario**.

Eso no lo invalida: como economía de ingeniería para un curso, es un buen umbral y evita la plaga de envolver cada `string`. Pero §3.8 lo marca como criterio y **§7.1 lo afirma en seco**, sin la marca. Esa asimetría hay que arreglarla: o la celda lleva la marca, o remite a §3.8.

**El caso límite, que es el mejor ejemplo que tiene el corpus.** `EmailIdentity.Normalize` implementa una regla de negocio de manual —«dos correos que difieren en mayúsculas o espacios son el mismo correo»— y sin embargo **no es un tipo**: es `public static string Normalize(string?)`, y la entidad guarda `Email` y `NormalizedEmail` como dos `string`. El motivo está declarado y es real (la comparación se sostiene con un índice único en la columna normalizada). El costo también es real y es exactamente el que §3.4 enseña a evitar: nada impide comparar `Email` en lugar de `NormalizedEmail`; la regla existe pero **el compilador no la protege**, que es todo el argumento de la guía contra el setter público.

**Qué agregar.** (a) Marcar o remitir la celda de §7.1. (b) Un caso límite corto en §3.8: una regla sobre un valor puede quedar como función en vez de tipo cuando la persistencia guarda el dato plano; declarar la pregunta —«¿por qué este valor con regla no es un tipo?»— y **no** resolverla a ciegas: la respuesta depende de si el motor de datos puede guardar el tipo sin ceremonia, y eso se verifica antes de escribirlo, no se supone.

**Sección** §7.1 (marca) y §3.8 (caso límite). **Nivel** P2. **Ancla** C, explícita. **Código** no hace falta.

---

## A-03. La línea del PO es correcta, ya está escrita en §4.2, y le faltan las dos preguntas transversales y un diagrama

**Hallazgo.** «Tengo una entidad → viene la intención, que es el caso de uso → y el hecho consumado, que es otra entidad» **es literalmente la tabla y la lista numerada de §4.2**: «un producto» → *Entity*; «quiero venderlo» → Command + Handler; «venderlo como hecho que queda registrado» → *Entity* `Pedido`. La guía ya la tiene; el PO la reconstruyó solo, que es la mejor señal de que está bien escrita.

**Es defendible con fuentes, y admite un matiz que la enriquece.** El «hecho consumado» tiene **dos** formas posibles, no una. Evans 2015, *Domain Events*: «**Something happened that domain experts care about.** […] Therefore: Model information about activity in the domain as a series of discrete events. Represent each event as a domain object.» Es decir: si lo que importa es que el hecho **ocurrió** (y su causa), es un evento de dominio; si el hecho **tiene identidad y ciclo de vida propios** —se modifica, se cancela, se consulta— es una *Entity*, y ahí rige *Entities*: «Many objects represent a thread of continuity and identity, going through a lifecycle, though their attributes may change.» `Pedido` es lo segundo. El matiz le da al lector el criterio para elegir, que hoy no tiene.

**Dónde encajan los `Values` y los `Guards`: el PO acertó al intuir que no son estaciones de la línea.** Y se puede fundamentar:

- **Los `Values` no son un tercer paso porque son atributos de los otros dos.** Evans: el *Value Object* existe cuando «you care only about the attributes and logic of an element of the model» y «these are the objects that describe things» — describen a otro, no viven por su cuenta. La pregunta transversal es **«¿qué valores admite?»**, y se la hace la *Entity* y también el Command.
- **Los `Guards` no son un paso porque son la forma de la respuesta de toda operación.** Vale para la fábrica, para el modificador y para la consulta. La pregunta transversal es **«¿qué contesta cuando no puede?»**, y su respuesta —excepción o resultado— es una propiedad de la interfaz, no una fase. Fundamento: CQS separa las operaciones por si mutan o no («Queries: Return a result and do not change the observable state of the system»), y lo hace sobre **todos** los métodos del objeto, no sobre un momento del flujo.

**Qué agregar.** (a) En §4.2, después de la lista numerada de cinco pasos, las **dos preguntas transversales** con una frase cada una y el motivo por el que no son pasos. (b) En §4.2, el matiz *Entity* vs *Domain Event* para el hecho consumado, con una línea sobre cuándo es cada uno. (c) **Sí falta un diagrama**, y es el único lugar del capítulo 4 que no tiene uno: «Diagrama 4.1 — la línea y las dos preguntas transversales», en mermaid como los de §9.2 y §7.3: la fila `Entity → Command/Handler → Entity (hecho)` y, debajo, una banda con las dos preguntas apuntando a las tres cajas. (d) En §7.1, una nota de una línea que remita al diagrama: la tabla de siete objetos contesta «dónde vive cada uno», el diagrama contesta «en qué orden se piensa».

**Sección** §4.2 (texto + diagrama) y §7.1 (remisión). **Nivel** P1. **Ancla** C + Evans 2015 (*Entities*, *Value Objects*, *Domain Events*) + Fowler 2005a. **Código** no hace falta; sí un bloque mermaid.

---

# Lo que revisé y está bien (tres)

1. **§3.1 distingue la *Factory* de Evans del *Factory Method* de GoF.** Es una distinción que casi todo el material .NET pasa por alto, y está bien puesta: «En el catálogo de Gamma et al. (1994) *Factory Method* designa otro patrón, basado en subclases». No la tocaría. Lo único que le falta es el nombre del movimiento (P-02) y el alcance completo del «Therefore» de Evans (P-01).
2. **§3.7 cita *ContextualValidation* con exactitud.** Comparé las dos frases citadas con el bliki (7 December 2005): «I think it's much more useful to think of validation as something that's bound to a context - typically an action that you want to do. […] So rather than have methods like `isValid` have methods like `isValidForCheckIn`» y «should failing this test prevent saving?». Reproducción fiel y uso correcto —el producto sin precio es exactamente el caso que el bliki plantea—. Es el mejor párrafo del capítulo 3.
3. **§5.6 declara su elección de código de estado como criterio y nombra la alternativa.** «Usar 400 para las dos clases de error, distinguidas por el cuerpo, es **Criterio de esta guía**; responder `422 Unprocessable Content` […] es otra convención posible», con la cita a RFC 9110 §15.5.21. Así es como se escribe una decisión discutible: se elige, se marca como elección y se nombra la otra. Ese mismo estándar es el que P-06 pide aplicar a la elección entre excepción y resultado, que hoy no está ni elegida ni marcada.

---

# Fuentes consultadas

Todas verificadas por descarga directa el **2026-09-20**; las citas entre comillas de este informe son transcripciones literales del texto recuperado en esa fecha.

| Fuente | URL | Consultada |
| --- | --- | --- |
| Fowler, M. (2014, 9 de diciembre). *Replacing Throwing Exceptions with Notification in Validations* | https://martinfowler.com/articles/replaceThrowWithNotification.html | 2026-09-20 |
| Fowler, M. (2004, 9 de agosto). *Notification* (Further Enterprise Application Architecture development) | https://martinfowler.com/eaaDev/Notification.html | 2026-09-20 |
| Fowler, M. (2005, 7 de diciembre). *Contextual Validation* | https://martinfowler.com/bliki/ContextualValidation.html | 2026-09-20 |
| Fowler, M. (2005, 5 de diciembre). *Command Query Separation* | https://martinfowler.com/bliki/CommandQuerySeparation.html | 2026-09-20 |
| Fowler, M. (2016, 14 de noviembre). *Value Object* (bliki) | https://martinfowler.com/bliki/ValueObject.html | 2026-09-20 |
| Fowler, M. (2005, 14 de diciembre). *Evans Classification* | https://martinfowler.com/bliki/EvansClassification.html | 2026-09-20 |
| Fowler, M. (2003, 5 de marzo). *Value Object* — catálogo de *Patterns of Enterprise Application Architecture* | https://martinfowler.com/eaaCatalog/valueObject.html | 2026-09-20 |
| Fowler, M. *Replace Constructor with Factory Function* (alias *Replace Constructor with Factory Method*) — catálogo de *Refactoring* | https://refactoring.com/catalog/replaceConstructorWithFactoryFunction.html | 2026-09-20 |
| Fowler, M. *Replace Nested Conditional with Guard Clauses* — catálogo de *Refactoring* | https://refactoring.com/catalog/replaceNestedConditionalWithGuardClauses.html | 2026-09-20 |
| Evans, E. y Fowler, M. (1997). *Specifications* | https://martinfowler.com/apsupp/spec.pdf | 2026-09-20 |
| Evans, E. (2015). *Domain-Driven Design Reference: Definitions and Pattern Summaries* — apartados *Ubiquitous Language*, *Entities*, *Value Objects*, *Domain Events*, *Factories*, *Intention-Revealing Interfaces*, *Side-Effect-Free Functions*, *Assertions* | https://www.domainlanguage.com/wp-content/uploads/2016/05/DDD_Reference_2015-03.pdf | 2026-09-20 |
| Microsoft. *Entity types with constructors* (EF Core) | https://learn.microsoft.com/en-us/ef/core/modeling/constructors | 2026-09-20 |

**Fuentes citadas de segunda mano, no verificadas en esta corrida** (aparecen dentro de las citas literales de Fowler y se declaran como tales, no como consulta propia): Thomas, D. y Hunt, A., *The Pragmatic Programmer*, citado verbatim dentro del artículo de 2014; Gamma et al. (1994) para el intento de *Factory Method*, que la guía ya referencia en su Anexo E.

**Código leído como evidencia** (no editado): `PROG2/Geometria/Lab-Geometria/src/GeometriaFactory.Domain/Entities/Work.cs`, `…/Entities/Account.cs`, `…/Guards/DomainResult.cs`, `…/Guards/Admission.cs`, `…/Values/ConditionCode.cs`, `…/Values/EmailIdentity.cs`, `…/Values/WorkStatus.cs`, `…/Values/Role.cs`, `…/Values/ObservationKind.cs`, `…/Values/WorkOperation.cs`.

**Guía leída** (no editada): `LAB/Lab-Documentos/Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md`, §0.5, §3.1–§3.8, §4.2, §5.4, §5.6, §7.1, §7.2 a/d/g, §8.4, §9.1–§9.3 y Anexo E.
