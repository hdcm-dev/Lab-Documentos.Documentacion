# Informe de la comisión Martin Fowler — ciclo 4: revisión de fidelidad sobre `main`

**Fecha:** 2026-09-21
**Objeto:** `Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md`, **v2.3.0**, 2755 líneas, `main @ dade777` (PR #8 fusionado por el PO).
**Encargo:** (1) resolver la deuda de la cita de Evans 2003 de segunda mano; (2) barrido de fidelidad de **todas** las citas textuales tras tres ciclos de reescritura; (3) atribuciones cruzadas (criterio propio sin rotular / rotulado como propio lo que tiene fuente); (4) citas que faltan y podrían estar; (5) citas recortadas por presupuesto en los ciclos 1–3 que convendría reponer; (6) de qué archivo del laboratorio sale el *snippet* que materializa cada una.
**Fuera de alcance:** `Guides/Dot-NET-Arquitectura-Guide/Exercices/` (taller del PO). **No se aplicó ningún cambio.**

**Método.** Se extrajeron con expresión regular las **51 citas textuales** entre comillas latinas de la guía y se cotejaron, normalizando espacios y guiones tipográficos, contra el corpus de fuentes descargado en los ciclos 1–3 y conservado en el *scratchpad* de la sesión: `ddd3.txt` (*DDD Reference* 2015), `ch09.txt` (PoEAA, cap. 9 *Domain Logic Patterns*), `brg.txt`/`brg1.txt` (Business Rules Group, 2000), `rdd.txt` (Wirfs-Brock, 2006), `cock.txt` (Cockburn, borrador #3), `introduction.txt` (Eiffel, *Design by Contract*), `AnemicDomainModel.txt`, `ContextualValidation.txt`, `CQRS.txt`, `CommandQuerySeparation.txt`, `CommandMessage.txt`, `LocalDTO.txt`, `spec.txt` (Evans y Fowler, 1997), `rtwn.html`, `notif.html`, `martin2012.html`, `efctor.html` (EF Core). **Resultado global: 45 verificadas textualmente en esta corrida, 6 no verificables con el corpus local (ninguna sospechosa), 0 falsas, 0 desalineadas por el contexto nuevo.**

---

## 1. La deuda del ciclo 3: la cita de Evans 2003 de segunda mano (§9.6, l. 2439)

**Estado de hecho.** La guía cita: «This layer is kept thin. It does not contain business rules or knowledge, but only coordinates tasks and delegates work to collaborations of domain objects» ([Evans, 2003](#ref-evans-2003), citado en [Fowler, 2003](#ref-fowler-2003)). **Verificado:** la frase aparece literal en `AnemicDomainModel.txt` —es Fowler quien la transcribe—, de modo que la guía no inventa nada y el rótulo «citado en» es honesto. La entrada `ref-evans-2003` del Anexo E lo declara igual.

**Dictamen: se reemplaza.** No por falsedad, sino por coherencia de procedencia: la guía declara en §0.5 que marca de dónde viene cada afirmación, y en el ciclo 3 la mesa resolvió (E-3) no apoyarse en el libro de 2003 mientras no esté a la vista. Sostener una cita de segunda mano en el único lugar donde hace falta el argumento de que **la capa de aplicación no lleva reglas** es exactamente el caso que E-3 quiso evitar. Además el reemplazo es **mejor para el argumento**: la frase de 2003 describe la capa; la de 2015 **manda** aislar el dominio, que es lo que §9.6 paso 7 está haciendo.

**Frase de reemplazo, verificada verbatim** en `DDD_Reference_2015-03.pdf`, sección **«Layered Architecture»**, pág. 10, párrafo «Therefore:»

> «Isolate the expression of the domain model and the business logic, and eliminate any dependency on infrastructure, user interface, or even **application logic that is not business logic**.»

**Redacción propuesta para §9.6 paso 7** (reemplaza la oración que hoy cierra el párrafo): «La capa queda delgada porque lo que no es regla de negocio no le pertenece: Evans manda “Isolate the expression of the domain model and the business logic, and eliminate any dependency on infrastructure, user interface, or even application logic that is not business logic” ([Evans, 2015](#ref-evans-2015)).» **Costo:** 0 líneas netas. **Anexo E:** `ref-evans-2003` queda sin usos; se puede quitar o dejarla como lectura, pero no debería seguir figurando como fuente citada.

**Snippet que la materializa:** ya existe y está compilado — `Variantes/Pedidos/Application/Pedidos/Commands/RegistrarPedido/RegistrarPedidoHandler.cs` l. 19–33: el `Handle` sólo pide, compone y confirma (`_pedidos.Add(pedido); await _unitOfWork.SaveChangesAsync(ct);`), y ninguna regla vive ahí: están en `Pedido.Confirmar` y `Pedido.AgregarItem`. Es la prueba en código de «la capa queda delgada».

---

## 2. Barrido de fidelidad (3 ciclos acumulados)

### 2.1 Verificadas en esta corrida, y siguen diciendo lo que la guía afirma **en su contexto actual** (45)

| Fuente | Citas | Secciones | Estado |
| --- | --- | --- | --- |
| Evans, *DDD Reference* 2015 | 9 (*Factories* ×2, *Value Objects* «give it related functionality» y «when you care only…», *Aggregates* ×2, *Repositories* ×2, *Domain Events*, «assertions define contracts…», «blindsided by changes in other objects») | 3.1, 3.6, 3.9, 4.1, 4.2, 4.4, 4.10, 5.4 | **Fieles.** Las dos del «Therefore» de *Aggregates* quedaron mejor tras el ciclo 3: §4.10 usa ahora la segunda para el argumento que le corresponde |
| Fowler, PoEAA (cap. 9) | 5 (*Transaction Script* «The glory…», «If you have complicated and everchanging…», *Service Layer* «directly implement application logic but delegate…», «each Transaction Script in its own class […] using the Command pattern», «as soon as you envision a second kind of client…») | 3.5, 4.1, 9.5, 9.6 | **Fieles.** La de «a Transaction Script is a better bet» omite el número de página cruzada «(110)» del original, que es práctica normal |
| Fowler, artículos (*AnemicDomainModel*, *ContextualValidation*, *CQRS*, *CommandQuerySeparation*, *Notification*, *LocalDTO*, *refactoring catalog*, «Resultados o excepciones») | 14 | 3.5, 3.7, 3.8, 4.5, 4.7, 4.8, 5.6, 7.2 d, 9.6 | **Fieles**, incluidas las cuatro de *CQS* y las tres de 2014, que el ciclo 2 reencuadró sin desalinearlas |
| Business Rules Group (2000) | 4 (definición completa, *Action Assertion*, *integrity constraint*, «Where the STRUCTURAL ASSERTIONS…») | 3.6 | **Fieles** (`brg1.txt`) |
| Eiffel Software / Meyer | 2 (la misma *class invariant*, en §3.1 y §3.6) | 3.1, 3.6 | **Fieles.** Sigue valiendo la nota del ciclo 3: la página **no** enuncia los momentos en que la invariante debe valer; por eso las tres piezas de §3.6 son criterio propio y están rotuladas |
| Wirfs-Brock (2006) | 2 («an obligation to perform a task or know information», «knowing/doing/deciding») | 3.6 | **Fieles** (`rdd.txt`) |
| Kay (1998) | 1 («The big idea is "messaging"») | 3.6 | Fiel al texto que la guía transcribe; **no re-verificada** contra el correo original en esta corrida |
| Hohpe y Woolf (2003) | 1 («simply a regular message that happens to contain a command») | 4.7 | **Fiel** (`CommandMessage.txt`) |
| Cockburn (2001) | 1 («A use case captures a contract between the stakeholders…») | 4.10 | **Fiel** (`cock.txt`, borrador #3) |
| Martin (2012) | 1 («orchestrate the flow of data to and from the entities») | 4.10 | **Fiel** (`martin2012.html`) |
| Microsoft | 4 (EF Core *constructors* ×2, `System.Text.Json` *immutability* ×2) | 5.4, Anexo E | **Fieles**; las de EF Core contra `efctor.html` |
| Evans y Fowler (1997), *Specifications* | 1 (`isSatisfiedBy`) | 3.8 | **Fiel** (`spec.txt`) |

### 2.2 No verificables con el corpus local de esta corrida (6) — ninguna sospechosa, todas a reconfirmar cuando haya red

| # | Cita | Dónde | Por qué no se verificó |
| --- | --- | --- | --- |
| **O-1** | «Mediates between the domain and data mapping layers using a collection-like interface for accessing domain objects» | §4.4 l. 1078 | *Repository* es PoEAA p. 322 (cap. 10); el corpus local sólo tiene el cap. 9. Verificada en el ciclo 1 contra `eaaCatalog/repository.html` |
| **O-2** | «An object that acts as a gateway to a database table» | §4.4 l. 1082 | *Table Data Gateway*, misma razón |
| **O-3** | «coordinates the writing out of changes» | §4.10 l. 1433 | *Unit of Work*, PoEAA p. 184, misma razón |
| **O-4** | «like money or a date range, whose equality isn't based on identity» | §3.1 l. 546 | *Value Object*, PoEAA p. 486, misma razón |
| **O-5** | «Consider static factory methods instead of constructors» | §3.1 l. 545 y Anexo E | Verificada en el ciclo 3 contra el TOC del editor (PDF de Pearson); el PDF no quedó en el corpus local |
| **O-6** | «because compilers propagate constants…» y las dos de `System.Text.Json` | §7.2 d l. 2033; Anexo E `ref-microsoft-2026o` | Páginas de Microsoft Learn verificadas al agregarse (ciclos 2 y 3); no re-descargadas hoy |

**Ninguna cita quedó desalineada por las reescrituras.** El riesgo que el encargo anticipaba —una cita correcta en el ciclo 1 que cambia de sentido cuando el párrafo cambia— se materializó **una sola vez y ya fue corregido**: la de Evans sobre *Aggregates*, que en v2.2.0 sostenía sólo el control de acceso y en v2.3.0 sostiene además la invariante del agregado, que es lo que la frase dice.

---

## 3. Atribuciones cruzadas

| # | Hallazgo | Nivel | Dirección |
| --- | --- | --- | --- |
| **A-1** | **§9.6 paso 7 y §4.1 atribuyen *Service Layer* a Fowler.** En PoEAA el patrón lleva firma: «Service Layer **by Randy Stafford**. Defines an application's boundary with a layer of services that establishes a set of available operations and coordinates the application's response in each operation» (p. 133, verificado en `ch09.txt`). La guía escribe «lo que PoEAA llama *Service Layer* ([Fowler, 2002, p. 111 y 135])» | P1 | Dos palabras: «…*Service Layer*, de Randy Stafford en PoEAA ([Fowler, 2002, p. 133](#ref-fowler-2002))», y de paso la página correcta es la **133**, no la 135. Es exactamente la clase de precisión que la guía se exige en §0.5 |
| **A-2** | **§4.4 atribuye *Repository* a Fowler.** En PoEAA el patrón es **de Edward Hieatt y Rob Mee**; la guía lo cita como `[Fowler, 2002]` sin la firma. *(no verificado en esta corrida: el cap. 10 no está en el corpus local)* | P2 | Confirmar contra `eaaCatalog/repository.html` y, si se confirma, agregar la firma como en A-1 |
| **A-3** | **§5.4: «Ese camino no valida, y es deliberado. Criterio de esta guía, porque ninguna fuente lo manda».** La primera mitad es correcta —ninguna fuente lo manda—, pero la afirmación «ninguna fuente» es más fuerte de lo necesario: Wirfs-Brock nombra el concepto que la sostiene, *trust region*, «an area where trusted collaborations occur», con la implicación textual: «Objects deep inside a trust region can be designed to not check for…» y «Objects at the "borders" may take on extra responsibilities» (verificado en `rdd.txt`) | P1 | Mantener el rótulo de criterio y **agregar el respaldo conceptual**: el camino de materialización está dentro de la región de confianza; el adaptador del escenario E-C está en el borde. La guía ya cita a Wirfs-Brock en §3.6, así que no hay entrada nueva en el Anexo E |
| **A-4** | **§4.9: «se obtiene con un decorador»** — se nombra el patrón *Decorator* sin fuente, en un párrafo donde la guía sí cita a Gamma et al. para *Command* y para *Factory Method*. *(GoF no está en el corpus local; a verificar)* | P2 | Un `([Gamma et al., 1994](#ref-gamma-1994))` sobre la palabra «decorador». Costo cero |
| **A-5** | **§1.4, §2.5, §5.2: «composition root»** se usa cinco veces como término establecido y **no tiene fuente ni glosario propio** como término acuñado (el Anexo D lo define, pero como vocabulario de la guía). El término es de Mark Seemann (*Dependency Injection in .NET*, 2011; `blog.ploeh.dk/2011/07/28/CompositionRoot/`) | P2 | O se cita, o se declara que la guía usa el término corriente. *(no verificado en esta corrida)* |
| **A-6** | **Criterio propio bien rotulado, sin faltantes nuevos.** Las 14 apariciones de «Criterio de esta guía» siguen cubriendo todo lo que no tiene fuente; las tres afirmaciones que el ciclo 2 marcó sin respaldo (`const string`, «cuesta lo mismo», *Specification*/*Guard Clause* sin Anexo E) **están corregidas en `main`**: hoy §7.2 d cita a Microsoft (2026n), §3.8 dice «cuesta del mismo orden» y el Anexo E tiene `ref-evans-fowler-1997` | — | Sin acción |
| **A-7** | **Nada está rotulado como propio teniendo fuente**, salvo el matiz de A-3. Verificado uno por uno sobre las 14 marcas | — | Sin acción |

---

## 4. Citas que faltan y sí existen (nuevas)

Todas con texto verificado en esta corrida salvo donde se indica. Cada una trae el archivo del laboratorio que la vuelve concreta.

| # | Dónde | Cita que falta (verbatim verificado) | Qué agrega | Snippet que la materializa |
| --- | --- | --- | --- | --- |
| **C-1** | §2.1/§2.3, la regla de dependencia (hoy sólo Martin, 2012) | Evans, *Layered Architecture*, pág. 10: «Partition a complex program into layers. Develop a design within each layer that is cohesive and that depends only on the layers below» | Da la formulación **anterior** a Clean Architecture y explica por qué la flecha va hacia adentro. Hoy la guía presenta la regla como si fuera sólo de Martin | Ya compilado: `MyProject/src/Backend/MyProject.Domain/Productos/IProductoRepository.cs` + `…/MyProject.Infrastructure/Persistence/Repositories/ProductoRepository.cs` (la interfaz adentro, la implementación afuera); captura `L07-separado.txt` |
| **C-2** | §3.5 y §9.6 paso 4, el *Anemic Domain Model* (hoy sólo Fowler, 2003) | Evans, *Repositories*, pág. 17: «Domain logic moves into queries and application layer code, and the entities and value objects become **mere data containers**» | Es el mismo diagnóstico desde la otra fuente, y explica **por dónde** se escapa la lógica: por las consultas. Refuerza el paso 4 sin una línea de prosa propia | `MyProject/src/Backend/MyProject.Domain/Productos/Producto.cs` l. 15–25 (`Create` + `Desactivar`) contra el paso 4 de §9.6 |
| **C-3** | §4.1/§9.6 paso 7, *Service Layer* | PoEAA p. 133 (Stafford): «Defines an application's boundary with a layer of services that establishes a set of available operations and coordinates the application's response in each operation» | Define la capa en una línea de fuente, en lugar de describirla; resuelve A-1 de paso | `MyProject/src/Backend/MyProject.Application/Productos/Commands/CrearProducto/CrearProductoHandler.cs` (el conjunto de handlers **es** el límite) |
| **C-4** | §5.4 y §7.2 g, el mapeo declarado afuera | PoEAA, *Data Mapper*: «A layer of Mappers that moves data between objects and a database while keeping them **independent of each other and the mapper itself**» *(ciclo 1, a re-verificar)* | Es el **nombre** de lo que §5.4 describe con «la Entity no se entera». Ver también §5, MF-09 | `MyProject/src/Backend/MyProject.Infrastructure/Persistence/Configurations/ProductoConfiguration.cs` l. 8–17 (ya citado en §5.4) |
| **C-5** | §5.4, el criterio de no validar al materializar | Wirfs-Brock, 2006: «trust region — an area where trusted collaborations occur»; «Objects deep inside a trust region can be designed to not check…»; «Objects at the "borders" may take on extra responsibilities» | Da nombre a la razón del criterio y al lugar de la excepción (el adaptador de E-C). Resuelve A-3 | `Variantes/FabricaYResultado/Domain/Productos/ProductoQueDevuelve.cs` l. 15–20 (el constructor que no valida, con su comentario «No valida nada, a propósito») |
| **C-6** | §7.2 d, *Response DTO* | Hohpe y Woolf, *Document Message*: es el hermano del *Command Message* que la guía ya cita —la petición lleva intención, la respuesta lleva datos— *(el texto exacto del patrón no está en `CommandMessage.txt`; a verificar)* | Cierra el par: §4.7 explica el Command con Hohpe y deja la respuesta sin nombre | `MyProject/src/Contracts/MyProject.Contracts/ProductoResponse.cs` (ya citado en §6.3) |
| **C-7** | §7.2 e, *ViewModel* | Fowler, *Presentation Model* (2004): «Represent the state and behavior of the presentation independently of the GUI controls used in the interface» *(a verificar)* | Hoy el ViewModel es el único de los siete objetos sin ninguna fuente; queda como invención de la guía cuando tiene padre conocido | No hay código: el ViewModel es uno de los tres objetos que el laboratorio no construye. Fragmento ilustrativo de §6.5, o el `PrecioFormateado` de §7.2 e |
| **C-8** | §4.10, el enunciado del *Use Case* | Cockburn, borrador #3: los niveles de objetivo —«Show only use cases at **user goal level** and higher»— | Justifica por qué el enunciado de §4.10 está escrito a ese nivel y no más fino; una línea | El propio enunciado de §4.10 (texto, no código) |

---

## 5. Citas y materiales recortados en los ciclos 1–3 que convendría reponer

Repaso de mis tres informes y de las tres resoluciones. **Siete ítems**, ordenados por rendimiento.

| # | Origen | Qué se recortó y por qué | Reposición propuesta | Snippet |
| --- | --- | --- | --- | --- |
| **R-1** | **MF-09** (ciclo 1; refutador: «una frase o nada» → nada; anotado como deuda en `03-Cierre.md`) | *Data Mapper* como **nombre** de lo que §5.4 describe | Una frase en §5.4: «`ProductoConfiguration` + EF Core son el *Data Mapper* de PoEAA: mueven datos entre objetos y base manteniéndolos independientes entre sí y del propio mapeador ([Fowler, 2002](#ref-fowler-2002))», más una fila en el Anexo D. Con el ciclo 3 **rinde más que entonces**: la tabla de los cuatro materializadores existe, y Dapper es un *Data Mapper* pobre; con el nombre puesto, el lector reconoce el patrón en EF Core, en Dapper y en NHibernate | `…/Configurations/ProductoConfiguration.cs` l. 8–17 (existe) y `Variantes/FabricaYResultado/Demo/Program.cs` l. 261 (Dapper, existe) |
| **R-2** | **P-07** (ciclo 2; entró el párrafo de §5.6, se cayó el fragmento) | El `[Fragmento ilustrativo]` de JSON que muestra el cuerpo `ProblemDetails` con el **código** en un miembro de extensión | **Mejor que un fragmento ilustrativo: la captura ya existe.** `capturas/L21-regla-traducida.txt` trae el cuerpo real (`{"type":"…rfc9110#section-15.5.1","title":"Regla de negocio incumplida","status":400,"detail":"El precio debe ser mayor a cero.","traceId":"…"}`). Se muestra ese cuerpo **medido** y se contrasta en una línea con la variante de código: `{"…","code":"PRECIO_NO_POSITIVO"}`. Cierra el argumento de Fowler *Notification* («error codes rather than strings»), que §7.2 d ya cita y §5.6 sólo enuncia | `MyProject/src/Backend/MyProject.WebAPI/ExceptionHandlers/DomainExceptionHandler.cs` l. 13–29 (el `Detail = exception.Message` que es la decisión discutida) + `capturas/L21-regla-traducida.txt` |
| **R-3** | Ciclo 1, **PE-08** (deuda declarada) | Materializar en código los pasos 5 y 6 de la escalera de §9.6 (Repository y Contracts del ABM de Personas) | Sigue abierta. Rinde menos que R-1 y R-2 porque el laboratorio ya muestra las dos piezas con `Producto`; **recomiendo cerrarla como no-deuda** y decirlo en el Anexo A, en vez de compilar un segundo ABM | — |
| **R-4** | Ciclo 1, **NET-09** (descartada por P-3) | Variante `ClienteApi/` compilada; los objetos de cliente quedaron como fragmentos ilustrativos | **No reponer.** El cliente de consola de L22 ya está compilado y capturado; la variante agregaría volumen sin cita nueva | — |
| **R-5** | Ciclo 2, filo 6 / **D-6** | *Notification* de Fowler: se nombró, no se construyó | Reponer **sólo la cita**, ya presente en §7.2 d; construirla sería un cuarto camino de rechazo. La deuda real es el puente de §5.6, que resuelve R-2 | — |
| **R-6** | Ciclo 2, **P-08** (observación fina, no aplicada) | La señal de cuándo el predicado se saca del objeto: «el mismo criterio tiene que valer en memoria y en la base», que es el problema que hace aparecer *Specification* | Una línea en §3.8, junto a la exclusión de *Specification* que ya está escrita y ya tiene su entrada en el Anexo E (`ref-evans-fowler-1997`) | `Variantes/Pedidos/Infrastructure/Persistence/Repositories/ProductoRepositorySinSeguimiento.cs` (el predicado que sí traduce el motor) |
| **R-7** | Ciclo 3, **NET3-06** (no aplicado; lo señalé en el dictamen) | La frase de §6.3 que nombra al serializador materializando un `record` posicional **por su constructor** | Una frase en §6.3 con remisión a §5.4. Hoy §5.4 afirma el mecanismo y §6.3 lo tiene compilado y capturado sin nombrarlo: la evidencia está y el puente no | `MyProject/src/Clients/MyProject.ConsoleClient/Program.cs` (`GetFromJsonAsync<List<ProductoResponse>>`) + `capturas/L22-cliente-consola.txt` |

---

## 6. Cuantificación (para que la presidencia fije el presupuesto)

| Lote | Ítems | Líneas netas estimadas | Bloques nuevos | Entradas nuevas en Anexo E |
| --- | --- | --- | --- | --- |
| §1 — reemplazo de la cita de Evans 2003 | 1 | 0 | 0 | 0 (una entrada deja de usarse) |
| §3 — atribuciones (A-1, A-3, A-4; A-2/A-5 a verificar) | 3 (+2) | +2 | 0 | 0 (+1 si se cita a Seemann) |
| §4 — citas que faltan (C-1…C-8) | 8 | +14 a +20 según cuántas lleven explicación | 0 (todos los snippets existen ya compilados, salvo C-7) | +2 (*Presentation Model*; *Document Message* si se repone) |
| §5 — reposiciones (R-1, R-2, R-6, R-7) | 4 | +8 a +12 | 0 si R-2 usa la captura de L21; +1 si se quiere el contraste JSON | +1 (*Data Mapper*, si no se reusa `ref-fowler-2002`) |
| **Total recomendado** | **16 aplicables** | **+24 a +34** | **0 a 1** | **+3** |

**Orden de rendimiento, si hay que cortar:** §1 (procedencia) → R-1 y R-2 → A-1 y A-3 → C-1, C-3, C-5 → C-2, C-8 → R-6, R-7 → C-4, C-6, C-7 → A-2, A-4, A-5 (verificar primero). **Nada de esto requiere compilar código nuevo**: los dieciséis ítems se materializan con archivos y capturas que ya existen en `MyProject/` y en `Variantes/`, que es el criterio de corte que la mesa viene aplicando desde el ciclo 1.

**Pendiente de red.** Seis citas (O-1…O-6) y cuatro propuestas (C-4, C-6, C-7, A-2, A-5) están marcadas como no verificadas en esta corrida por falta de la fuente en el corpus local. Ninguna debería entrar a la guía sin su verificación, y ninguna de las existentes debería quitarse por esa marca: todas fueron verificadas en el ciclo en que se agregaron.
