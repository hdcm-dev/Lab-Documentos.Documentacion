# Informe de la comisión Martin Fowler — Ciclo 1

**Fecha:** 2026-09-19
**Comisión:** Martin Fowler (personificado). Cada afirmación sobre lo que «Fowler piensa» remite a un texto de martinfowler.com o de *Patterns of Enterprise Application Architecture* (PoEAA, 2002), verificado en esta corrida; donde la fuente es un capítulo del libro se da la página de la edición de 2002.
**Objeto:** `LAB/Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md` @ `dbdf9dd` (v2.0.2, 2126 líneas), más el código de `Guides/Arquitectura/Examples/Dot-NET-Arquitectura-Lab/` (`MyProject/`, `Variantes/`) que la guía declara como materialización.
**Encargo:** refutar, no verificar. A ciegas: no se leyó ningún otro informe ni nada de `Ciclo-1/`.
**Competencia (NE-03, NE-01):** fidelidad de los patrones y conceptos a sus fuentes; que el código los encarne; que las citas existan y digan lo que la guía afirma; que el criterio propio esté rotulado; dónde un ejemplo de PoEAA o del bliki materializa mejor un concepto que hoy está en alegoría.
**No-competencia:** forma editorial, pedagogía de la progresión, idiomaticidad del C# moderno. Lo que se detectó ahí va en «Solicitudes de convocatoria».

Convenciones: nivel P0–P3 y clase de ancla E1/E2/E3/E4/C según el despacho. Las líneas son las de la guía @ `dbdf9dd`.

---

## Hallazgos

### MF-01 · P1 · El `Repository` del laboratorio no encarna el par Repository + Unit of Work: confirma en `AddAsync` y devuelve Entities sin seguimiento

**Sección:** §4.4 (l. 862–882), §5.1 «Unit of Work» (l. 1139), §5.5 (l. 1258–1272), §4.10 (l. 1115).
**Ancla E2 (fuente):** PoEAA, *Repository*: «Mediates between the domain and data mapping layers using a collection-like interface for accessing domain objects» (https://martinfowler.com/eaaCatalog/repository.html). *Unit of Work*: «Maintains a list of objects affected by a business transaction and coordinates the writing out of changes» (https://martinfowler.com/eaaCatalog/unitOfWork.html). Evans, *Repositories*: «Provide methods to add and remove objects, which will encapsulate the actual insertion or removal of data in the data store» (DDD Reference 2015, p. 16).
**Ancla E1 (código):**

```text
$ grep -n "AsNoTracking\|SaveChangesAsync\|Desactivar" -r MyProject --include=*.cs | grep -v /bin/
MyProject/src/Backend/MyProject.Infrastructure/Persistence/Repositories/ProductoRepository.cs:13:  _db.Productos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, ct);
MyProject/src/Backend/MyProject.Infrastructure/Persistence/Repositories/ProductoRepository.cs:16:  await _db.Productos.AsNoTracking().ToListAsync(ct);
MyProject/src/Backend/MyProject.Infrastructure/Persistence/Repositories/ProductoRepository.cs:21:  await _db.SaveChangesAsync(ct);     // confirma la escritura en la base
MyProject/src/Backend/MyProject.Domain/Productos/Producto.cs:25:  public void Desactivar() => Activo = false;
```

**Qué falla.** Dos cosas, y la segunda no está dicha en ninguna parte de la guía:

1. `AddAsync` confirma la transacción. Una colección no confirma transacciones: eso es la *Unit of Work*. La guía lo sabe y lo rotula en §5.5 y §4.10 («A diferencia de `ProductoRepository`, que confirma en cada `AddAsync`»), así que este punto por sí solo sería P3.
2. `GetByIdAsync` y `GetAllAsync` usan `AsNoTracking()`. La Entity que sale del «Repository» no está en la lista de objetos que la *Unit of Work* vigila. La única modificación que `Producto` ofrece, `Desactivar()`, no la ejercita ningún *Use Case* del laboratorio, y **no podría persistirse** con este Repository: un `DesactivarProductoHandler` que hiciera `producto.Desactivar(); await _unitOfWork.SaveChangesAsync(ct)` —que es exactamente lo que §4.10 recomienda («alcanza con declarar que el contexto implementa `IUnitOfWork`»)— terminaría en `200` con la base sin cambios. Es la falla de L18 (§5.5) pero silenciosa, sin la línea que el paso quita a propósito. La ilusión de colección en memoria (Evans, p. 16) se rompe para la mitad del ciclo: agregar funciona, sacar-cambiar-guardar no.

**Impacto si no se corrige.** La guía afirma que `DbContext` «registra los cambios y los confirma todos juntos» (§5.1) y que el Repository «habla de objetos del negocio como si estuvieran en una colección en memoria» (§4.4); el código publicado como **[Compilado]** contradice las dos frases en el primer caso de uso de modificación que alguien escriba. El lector aprende un Repository que sólo sirve para insertar y leer.

**Dirección.** Las capturas L00–L24 no se regeneran, así que `MyProject/` queda como está; la corrección va en el texto y en una variante:
- En §4.4 o §5.5, decir explícitamente que `ProductoRepository` es un Repository **de escritura por inserción y lectura sin seguimiento**, que `AsNoTracking` es correcto para las Queries (devuelven un modelo de lectura) y no para el `GetByIdAsync` que alimenta un Command, y que la confirmación dentro de `AddAsync` es un apartamiento del patrón que §4.10 corrige.
- Una variante `Variantes/Pedidos/` (o una nueva) que llegue a Infrastructure con `AppDbContext : IUnitOfWork`, un `ProductoRepository` cuyo `GetByIdAsync` **sí** siga la Entity, y un Use Case de modificación (`DesactivarProducto` o `AsignarPrecio` de §3.7) que muestre el ciclo completo obtener → cambiar → `SaveChangesAsync`. Snippet de dirección:

```csharp
// Variante: el Repository devuelve la Entity seguida por el DbContext; la Unit of Work la escribe.
public Task<Producto?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
    _db.Productos.FirstOrDefaultAsync(p => p.Id == id, ct);      // sin AsNoTracking: la UoW la vigila

public void Add(Producto producto) => _db.Productos.Add(producto); // marca; no confirma
```

---

### MF-02 · P1 · Tres citas textuales atribuidas a [Fowler, 2002] no están en la fuente que el Anexo E ofrece para verificarlas

**Sección:** §9.6 (l. 1869, 1871, 1875); Anexo E `ref-fowler-2002` (l. 2068).
**Ancla E1:** la entrada del Anexo E dice «Catálogo en línea: https://martinfowler.com/eaaCatalog/». Consultadas el 2026-09-19 las páginas `transactionScript.html`, `domainModel.html` y `serviceLayer.html`: ninguna contiene «The glory of Transaction Script is its simplicity», «complicated and everchanging business rules…» ni «as soon as you envision a second kind of client…». Las páginas del catálogo traen sólo la frase de intención y uno o dos párrafos.
**Ancla E2:** las tres citas **existen** en el libro, capítulo 9, y dicen lo que la guía afirma: Transaction Script, «When to Use It», p. 111; Domain Model, «When to Use It», p. 119; Service Layer, «When to Use It», p. 137 (el patrón lo firma **Randy Stafford**, p. 133). Verificado sobre el texto del capítulo.
**Qué falla.** Rule-Evidences pide evidencia verificable; la guía cita el catálogo, y el catálogo no permite verificar esas tres frases. Un lector que siga el enlace concluye que las citas son inventadas. Además §4.4 sí aclara que el Repository «lo firman Edward Hieatt y Rob Mee», pero §9.6 no dice que Service Layer lo firma Randy Stafford: criterio de atribución inconsistente dentro del mismo documento.
**Impacto.** Tres de las cinco afirmaciones de Fowler que sostienen la escalera en código (§9.6, decisión cerrada) quedan sin ancla verificable.
**Dirección.** En el Anexo E distinguir «catálogo (frases de intención)» de «libro (capítulo y página)», y en cada cita del cuerpo poner capítulo y página: `[Fowler, 2002, p. 111]`, `[Fowler, 2002, p. 119]`, `[Stafford, en Fowler, 2002, p. 137]`. No hace falta tocar el texto de las citas: son exactas.

---

### MF-03 · P1 · El concepto central del capítulo 4 —*Use Case* con Command y Handler— no tiene fuente, y su fuente en PoEAA existe: *Service Layer* en su variante *operation script*, y «cada Transaction Script en su propia clase con el patrón Command»

**Sección:** §4.1 «Use Case», «Handler» (l. 749–751, sin cita); §4.2 (l. 758–808); §4.3 tabla «Con qué se confunde» (l. 859: «un Handler es un método del servicio convertido en clase»); §9.6 tabla fila 7 (l. 1825) y párrafo «Paso 7» (l. 1877: «`IPersonasService` desaparece»); Anexo D «Service Layer» (l. 2036: sólo §9.6).
**Ancla E2 (PoEAA):**
- Transaction Script, p. 111: «You can organize your Transaction Scripts into classes in two ways. The most common is to have several Transaction Scripts in a single class […]. The other way is to have each Transaction Script in its own class (Figure 9.1), using the Command pattern [Gang of Four].»
- Service Layer, p. 133: «Defines an application's boundary with a layer of services that establishes a set of available operations and coordinates the application's response in each operation.» P. 135: «In the operation script approach a Service Layer is implemented as a set of thicker classes that directly implement application logic but delegate to encapsulated domain object classes for domain logic.»
**Qué falla.** La guía deriva el Handler del «método de servicio» (§4.2) y lo emparenta con el Command de Gamma y el Command Message de Hohpe (§4.7), pero no dice que en PoEAA esa organización ya está descrita: un Handler que «no decide reglas; orquesta» sobre un Domain Model es un *operation script* del *Service Layer*; un Handler por clase es la segunda forma de organizar scripts de la p. 111. Y §9.6 dice que en el paso 7 «`IPersonasService` desaparece y el conjunto de handlers pasa a ser el límite de la aplicación»: **eso es la definición de Service Layer** («defines an application's boundary»). El patrón no desaparece; cambia de forma (varios scripts por clase → uno por clase). La fila 7 de la tabla lo omite y el glosario ubica Service Layer sólo en §9.6, cuando es el patrón que el capítulo 4 entero materializa.
Nota sobre la fila 2 (l. 1820): rotular `PersonasService` como Service Layer con un solo cliente es correcto como forma, pero la propia cita de la p. 137 dice que con un solo cliente «you probably don't need a Service Layer»; conviene que la fila lo diga para que la escalera no parezca contradecir la cita que la sostiene.
**Impacto.** El concepto más repetido de la guía (Use Case/Handler) es el único de los grandes que no tiene fuente en §4, y la relación Handler↔Service Layer, que es la que le da al lector el criterio «cuándo conviene uno por clase» (p. 111: «it allows you to manipulate instances of scripts as objects at runtime»), queda sin decir.
**Dirección.** (a) En §4.1 citar Service Layer (p. 133) para *Use Case* y la p. 111 para «un Handler por clase». (b) En la tabla de §4.3 «Handler / Servicio de aplicación», agregar la columna de vocabulario de PoEAA: ambos son Service Layer; el servicio es «several scripts in a single class», el handler «each script in its own class». (c) En §9.6 fila 7: «*Service Layer* (operation script, uno por clase) + *Domain Model*»; y en el párrafo «Paso 7» reemplazar «desaparece» por «cambia de forma: el límite lo fija el conjunto de handlers». (d) Glosario: Service Layer → §4.1, §4.3, §9.6.

---

### MF-04 · P1 · *Postcondition* está definida tres veces y no está materializada nunca, aunque el laboratorio ya la tiene escrita

**Sección:** §3.1 (l. 507), §3.6 «El contrato» (l. 651), Anexo D (l. 2022). Ningún bloque de código de la guía muestra una *Postcondition*.
**Ancla E1:** `grep -n "Postcondition" Dot-NET-Arquitectura-Guide.md` → l. 507, 651, 1992, 2022: todas prosa o glosario. El único código que la encarna está en el laboratorio y la guía no lo muestra:

```text
MyProject/tests/Backend/MyProject.Domain.Tests/ProductoTests.cs
    public void Create_con_datos_validos_devuelve_un_producto_activo()
    {
        var producto = Producto.Create("Mate", 3500m);
        Assert.True(producto.Activo);
        Assert.Equal(3500m, producto.Precio);
    }
```

**Ancla E2:** Evans, *Assertions*: «State post-conditions of operations and invariants of classes and aggregates. If assertions cannot be coded directly in your programming language, write automated unit tests for them» (DDD Reference 2015, p. 21). La guía cita la primera oración (l. 651) y omite la segunda, que es justamente la que dice cómo materializarla en C#.
**Qué falla.** El lector recibe la tríada Precondition/Postcondition/Invariant y ve código para dos de las tres. Es el caso exacto del pedido («no quedarme sólo en la alegoría»). Además, en §4.10 la *Success Guarantee* y la *Minimal Guarantee* de Cockburn son las postcondiciones del *Use Case*, y los contadores de V02 («pedidos guardados: 1, confirmaciones: 1» que no se mueven) son su verificación; la guía lo describe («que es la Minimal Guarantee del enunciado») sin nombrar la palabra *Postcondition*.
**Dirección.** En §3.6 «El contrato», después de «C# no tiene cláusulas para eso», mostrar como **[Compilado: `MyProject/tests/…/ProductoTests.cs`]** esa prueba con la frase que ata: «las dos `Assert` son la *Postcondition* de `Create` escritas como prueba, que es lo que Evans indica cuando el lenguaje no tiene cláusulas». En §4.10, una línea: «*Success Guarantee* y *Minimal Guarantee* son las *Postconditions* del Use Case; los contadores de V02 las verifican».

---

### MF-05 · P1 · La guía me atribuye la definición de DTO y después llama DTO a objetos locales que yo digo expresamente que no lo son

**Sección:** §5.1 (l. 1133: «Objeto sin comportamiento que transporta datos entre procesos ([Fowler, 2002])»); §4.3 (l. 858: «Los dos son DTOs», refiriéndose a Command y Request); §7.4 (l. 1569: «Un DTO que viaja entre capas → Command o Query adentro»); Anexo D (l. 1995: «entre procesos **o capas**»); `ProductoDto` (modelo de lectura en proceso, §4.1).
**Ancla E2:**
- PoEAA, *Data Transfer Object*: «An object that carries data between processes in order to reduce the number of method calls» (https://martinfowler.com/eaaCatalog/dataTransferObject.html).
- Bliki *LocalDTO* (21 de octubre de 2004, https://martinfowler.com/bliki/LocalDTO.html): «DTOs are called Data Transfer Objects because their whole purpose is to shift data in expensive remote calls. […] Not just do you not need them in a local context, they are actually harmful […]. Some people argue for them as part of a Service Layer API because they ensure that service layer clients aren't dependent upon an underlying Domain Model. While that may be handy, I don't think it's worth the cost of all of that data mapping.» Y la excepción que sí admito: «One case where it is useful to use something like a DTO is when you have a significant mismatch between the model in your presentation layer and the underlying domain model.»
**Qué falla.** La definición de §5.1 es fiel; el glosario la amplía a «o capas» sin fuente; §4.3 y §7.4 aplican el nombre al Command y a la Query, que viven en el mismo proceso; y `ProductoDto` existe por la razón exacta que el bliki rechaza (que el controller no dependa de la Entity). Nada de eso es ilegítimo como decisión de la guía —el §7.2 d da un motivo real: el contrato filtra `Activo`—, pero es **criterio de la guía**, y hoy va bajo mi nombre.
**Impacto.** El lector sale creyendo que «DTO» es cualquier clase plana que cruza una capa, y que Fowler lo avala. Es lo contrario de lo que escribí.
**Dirección.** Reservar «DTO [Fowler, 2002]» para el par de `Contracts` (cruza el proceso: es el único caso que cumple la definición). Para Command/Query, quedarse con «mensaje» (§4.1 ya lo hace) y quitar «Los dos son DTOs» de §4.3 y la fila de §7.4. Para `ProductoDto`, decir en §4.1: «Fowler desaconseja los DTO dentro del mismo proceso (*LocalDTO*, 2004); esta guía conserva un modelo de lectura para que el controller no reciba la Entity —**Criterio de esta guía**—; el sufijo `Dto` del laboratorio se usa en sentido amplio». El nombre del archivo no cambia (capturas). Glosario: volver a «entre procesos» y agregar la aclaración.

---

### MF-06 · P2 · *Factory Method* se apoya en GoF con una salvedad («designa otro patrón») cuando la fuente que describe exactamente lo que hace `Producto.Create` es Evans

**Sección:** §3.1 (l. 508); Anexo D (l. 2002).
**Ancla E2:** Evans, *Factories*: «Shift the responsibility for creating instances of complex objects and aggregates to a separate object […]. Create an entire aggregate as a piece, enforcing its invariants» (DDD Reference 2015, p. 17). El nombre corriente de la forma concreta —método `static` que reemplaza al constructor— es «static factory method» (Bloch, *Effective Java*, ítem 1; libro, no verificado en línea en esta corrida).
**Qué falla.** La guía cita un catálogo para reconocer que no es ese patrón. Es honesto pero al revés: la evidencia debe respaldar lo que se afirma, no lo que no se afirma. Evans dice que la Factory «enforces its invariants» al crear el agregado entero, que es la justificación de §3.1 («permite verificar las Invariants antes de que el objeto exista») y de §4.10 (`Pedido.Create` + `ItemPedido` con constructor `internal`).
**Impacto.** Menor en el concepto, mayor en el método de la guía: es el único término del §3.1 cuya fuente dice «no es esto».
**Dirección.** Mantener el nombre (restricción cerrada) y cambiar la fuente: «*Factory Method*. […] Evans lo describe como la operación que crea el agregado entero haciendo cumplir sus Invariants ([Evans, 2015]); en el catálogo de GoF el nombre designa un patrón por subclases; la forma usada aquí se conoce también como *static factory method*». Anexo D igual.

---

### MF-07 · P2 · El Handler de `RegistrarPedido` decide una regla (2a) y la disfraza de `DomainException`

**Sección:** §4.10 (l. 1084–1085, 1096: «2a es propia del Use Case»); §4.3 (l. 860: «Si el Handler tiene el `if` […] la regla está en el lugar equivocado»); §5.6 (l. 1284: `DomainException` → 400 «Regla de negocio incumplida»).
**Ancla E1:** `Variantes/Pedidos/Application/Pedidos/Commands/RegistrarPedido/RegistrarPedidoHandler.cs:26` → `?? throw new DomainException($"No existe el producto {item.ProductoId}.")`.
**Ancla E2:** Service Layer, p. 135: los *operation scripts* «directly implement application logic but delegate to encapsulated domain object classes for domain logic». Martin, 2012: la capa de Use Cases «contains application specific business rules» (verificado en https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html). La guía misma distingue las dos clases en §3.2 (l. 545) y en §4.10.
**Qué falla.** «El producto no existe» es lógica de aplicación (un identificador que llegó de afuera no resuelve), no una regla del dominio: `Producto` no la conoce, ningún objeto del dominio la formula, y `DomainException` está definida en §3.1 como «una operación violaría una regla del negocio». Si esta variante llegara a la WebAPI, `DomainExceptionHandler` la traduciría a `400 Regla de negocio incumplida`, cuando el borde debería decir `404` o `400` de validación de entrada. La guía enseña bien la distinción en prosa y la contradice en el único código donde la distinción se ve.
**Impacto.** Confunde la separación que §3.2 y §4.10 se esfuerzan en enseñar: qué es del dominio y qué del Use Case.
**Dirección.** En `Variantes/` (sus capturas no están congeladas): una excepción de aplicación (`ProductoInexistenteException` en `Application/Common`, o un resultado) y una frase en §4.10: «2a la lanza el Handler con una excepción **de aplicación**, no `DomainException`: el dominio no conoce identificadores que no existen». Regenerar V02.

---

### MF-08 · P2 · *Entity* y *Value Object* se definen sin fuente, y `Dinero` es, letra por letra, el patrón *Money* de PoEAA sin que la guía lo diga

**Sección:** §3.1 (l. 504, 509: sin cita); §3.3 `Dinero` (l. 576–588); §7.2 b (l. 1473–1482).
**Ancla E2:** PoEAA, *Value Object*: «A small simple object, like money or a date range, whose equality isn't based on identity» (https://martinfowler.com/eaaCatalog/valueObject.html). PoEAA, *Money*: «Represents a monetary value. […] once you involve multiple currencies you want to avoid adding your dollars to your yen without taking the currency differences into account» (https://martinfowler.com/eaaCatalog/money.html). Evans define Entity y Value Object en el DDD Reference que la guía ya cita (2015, pp. 6–7).
**Qué falla.** Los dos términos de literatura que abren la Parte II son los únicos del §3.1 que no remiten a nadie, mientras Business Rule, Invariant, Precondition y Factory Method sí. Y `Dinero.Sumar` con la guarda de moneda distinta es exactamente el ejemplo de *Money*: es el caso ideal para atar un snippet ya compilado a un patrón con nombre y fuente, y la guía lo desaprovecha.
**Dirección.** Citar [Fowler, 2002] (`valueObject.html`) y [Evans, 2015] en las dos viñetas de §3.1; en §3.3, una línea bajo el bloque de `Dinero`: «Es el patrón *Money* de PoEAA: un Value Object con moneda cuya suma rechaza monedas distintas ([Fowler, 2002], `money.html`)».

---

### MF-09 · P2 · El Repository «media entre el dominio y el almacenamiento»: la fuente dice «data mapping layers», y esa capa es EF Core; §5.4 responde con *Data Mapper* sin nombrarlo

**Sección:** §4.1 (l. 753); §4.4 (l. 866: aquí la cita sí es literal); §5.4 (l. 1237–1256).
**Ancla E2:** Repository: «Mediates between the domain **and data mapping layers**». *Data Mapper*: «A layer of Mappers that moves data between objects and a database while keeping them independent of each other and the mapper itself» (https://martinfowler.com/eaaCatalog/dataMapper.html).
**Qué falla.** La paráfrasis de §4.1 borra la capa intermedia, que en esta guía es la protagonista de §5.3–§5.4: EF Core con `ProductoConfiguration` es el Data Mapper («la Entity no se entera», l. 1239, es la definición del patrón). Con el nombre puesto, la respuesta de §5.4 deja de ser una descripción de EF Core y pasa a ser un patrón que el lector puede reconocer en Dapper, en NHibernate o en un archivo.
**Dirección.** §4.1: «media entre el dominio y la capa de mapeo a datos»; §5.4: «`ProductoConfiguration` + EF Core son el *Data Mapper* de PoEAA: mueven datos entre objetos y base manteniéndolos independientes ([Fowler, 2002], `dataMapper.html`)».

---

### MF-10 · P3 · «Confirmar» nombra dos cosas distintas en §4.10: el estado del `Pedido` y el *commit* de la *Unit of Work*

**Sección:** §4.10 (l. 1058 `Confirmar()`, l. 1091 «una sola confirmación», l. 1099–1110 «confirmaciones: 1», l. 1113 «cada extensión termina en `DomainException` y los dos contadores no se mueven»); §5.5 («la escritura se confirma con `SaveChangesAsync`»).
**Ancla E1:** `Variantes/Pedidos/Demo/Program.cs`: `UnitOfWorkContador.Confirmaciones` cuenta llamadas a `SaveChangesAsync`; `Pedido.Confirmado` es un estado del negocio (regla «Un pedido confirmado no se modifica»).
**Ancla E2:** Unit of Work: «coordinates the writing out of changes» —un acto técnico—; la *Condition* de la tabla de §3.6 «Un pedido confirmado no se modifica» es del negocio.
**Qué falla.** El lector que llega a «confirmaciones: 1» después de leer `pedido.Confirmar()` puede creer que el contador cuenta pedidos confirmados por el negocio, cuando cuenta commits. Es el punto donde la guía quiere que se vea la diferencia entre regla de dominio y Unit of Work.
**Dirección.** Llamar al acto técnico «commit» o «`SaveChanges`» en la prosa de §4.10 y renombrar el contador del doble (`LlamadasASaveChanges`); dejar «Confirmar» sólo al pedido. Regenerar V02.

---

### MF-11 · P3 · La señal para pasar de Transaction Script a Domain Model (§3.5) es fiel a la fuente, pero flota sin cita ni rótulo

**Sección:** §3.5 (l. 635: «La señal para pasar de uno a otro es que la misma validación empiece a escribirse en más de un lugar»); §9.6 «Paso 4» (l. 1873).
**Ancla E2:** PoEAA, p. 111: «One particular problem to watch for is its duplication between transactions. Since the whole point is to handle one transaction, any common code tends to be duplicated. […] It's hard to quantify the cutover level». P. 119: «It all comes down to the complexity of the behavior in your system».
**Qué falla.** La frase está a continuación de una cita a [Fowler, 2002] y el lector la lee como mía; lo es en sustancia (la duplicación), pero el libro además avisa que el punto de corte no se cuantifica. Sin la cita, la señal parece una regla exacta; con ella, es lo que es: la señal que yo nombro y la advertencia de que no hay umbral.
**Dirección.** Citar p. 111 en §3.5 y agregar la advertencia del corte no cuantificable; alternativamente, rotular la frase como **Criterio de esta guía** construido sobre esa observación.

---

## Lo que revisé y está bien

1. **Las citas de los blikis existen y dicen lo que la guía afirma (E1/E2).** Verificadas el 2026-09-19 sobre el HTML de martinfowler.com: *AnemicDomainModel* (25-11-2003: «little more than bags of getters and setters», «capture all the domain logic», «incur all of the costs of a domain model, without yielding any of the benefits», «Domain Models aren't always the best tool», y la cita de Evans «This layer is kept thin. It does not contain business rules or knowledge, but only coordinates tasks and delegates work to collaborations of domain objects in the next layer down», correctamente rotulada «citado en Fowler (2003)»); *CommandQuerySeparation* (5-12-2005: las dos definiciones, «Because the term 'command' is widely used in other contexts I prefer to refer to them as 'modifiers'», «I'm prepared to break it to get my pop», y la atribución a Meyer/OOSC); *ContextualValidation* (7-12-2005: «bound to a context - typically an action that you want to do», «So rather than have methods like isValid have methods like isValidForCheckIn», «should failing this test prevent saving?»); *CQRS* (14-07-2011: «for most systems CQRS adds risky complexity», «should only be used on specific portions of a system»). También Hohpe y Woolf («A Command Message is simply a regular message that happens to contain a command»), Martin 2012 (las tres frases de l. 997), Evans 2015 (las cinco citas: pp. 15, 16, 21), Eiffel Software (l. 651) y Wirfs-Brock (l. 653). La cita de §4.4 sobre Hieatt y Mee es correcta (`repository.html`: «Edward Hieatt and Rob Mee»).

2. **§4.8 «¿Esto es CQRS?» es fiel y es el párrafo que más me importaba (E2).** Distingue CQS (métodos) de CQRS (modelos), niega que mensajes `…Command`/`…Query` sobre un mismo modelo sean CQRS y reproduce mi advertencia sobre la complejidad. El ❌ «Separar en dos bases de datos una aplicación del escenario E-A para "hacer CQRS"» es exactamente el uso que el bliki desaconseja.

3. **§9.6 «Paso 4» y §3.6 describen el *Anemic Domain Model* con fidelidad, incluida la parte que suele omitirse (E2).** La guía dice que el paso 2 «no era anémico: sin reglas, un Transaction Script es legítimo» y que lo anémico es «la versión a medias: Entities, Repositories y handlers con todas las reglas en los handlers, que cuesta como un Domain Model y rinde como un Transaction Script». Eso es el diagnóstico del bliki, sin caricatura: el antipatrón no es «tener setters» sino pagar el costo de un Domain Model sin sus beneficios. El §3.7 con `PrecioDeVenta()` es además una materialización correcta de *ContextualValidation*: la validez se pregunta respecto de una acción (vender), no del objeto.

---

## Solicitudes de convocatoria

Señales fuera de mi competencia, con ubicación; no son hallazgos.

| Señal | Ubicación | Comisión sugerida |
|---|---|---|
| El código de §2.2 (`AltaDeProducto.Ejecutar` con el `if (precio <= 0)`) pone la regla en el «Use Case» que §3.4 marca después como ❌; como escalón didáctico es legítimo, pero conviene una frase que lo anticipe para que el lector no lo tome de modelo | §2.2, l. 294–318 | Pedagogía |
| `IProductoRepository.AddAsync` (Task) vs `IPedidoRepository.Add` (void, sincrónico): dos firmas para el mismo concepto en dos variantes; §5.5 explica `Add` vs `AddAsync` de EF Core pero no la asimetría entre las dos interfaces de la guía | §3.3 l. 599; §4.10 l. 1090; `Variantes/Pedidos/Domain/Pedidos/IPedidoRepository.cs` | .NET/C# |
| `IUnitOfWork` vive en `Application/Common` mientras `IPedidoRepository` vive en `Domain`; la tabla de §8.3 y §2.7 («interfaces de servicios técnicos» en Application) lo justifican, pero la guía no dice por qué una va en cada capa | §4.10 l. 1096; `Variantes/Pedidos/Application/Common/IUnitOfWork.cs` | .NET/C# y Editor |
| Las cinco secciones «Definiciones» sin bloque de código: los hallazgos MF-04, MF-05 y MF-08 dan tres snippets ya compilados que podrían anclarse ahí (prueba de postcondición, `Dinero` como *Money*, `ProductoResponse` como el único DTO) | §1.1, §3.1, §4.1, §5.1, §6.1 | Editor y Pedagogía |

---

## Fuentes consultadas

Externas (fecha de consulta 2026-09-19 salvo indicación):

- Fowler, M. *Repository* (catálogo PoEAA). https://martinfowler.com/eaaCatalog/repository.html
- Fowler, M. *Transaction Script* (catálogo). https://martinfowler.com/eaaCatalog/transactionScript.html
- Fowler, M. *Domain Model* (catálogo). https://martinfowler.com/eaaCatalog/domainModel.html
- Fowler, M. *Service Layer* (catálogo). https://martinfowler.com/eaaCatalog/serviceLayer.html
- Fowler, M. *Table Data Gateway* (catálogo). https://martinfowler.com/eaaCatalog/tableDataGateway.html
- Fowler, M. *Data Transfer Object* (catálogo). https://martinfowler.com/eaaCatalog/dataTransferObject.html
- Fowler, M. *Unit of Work* (catálogo). https://martinfowler.com/eaaCatalog/unitOfWork.html
- Fowler, M. *Value Object* (catálogo). https://martinfowler.com/eaaCatalog/valueObject.html
- Fowler, M. *Money* (catálogo). https://martinfowler.com/eaaCatalog/money.html
- Fowler, M. *Data Mapper* (catálogo). https://martinfowler.com/eaaCatalog/dataMapper.html
- Fowler, M. (2002). *Patterns of Enterprise Application Architecture*, cap. 9 «Domain Logic Patterns», texto del capítulo (pp. 110–141) según el extracto publicado por el editor: http://media.techtarget.com/tss/static/articles/content/FowlerPatterns/Fowler_ch09.pdf — páginas citadas: 111 (Transaction Script, «When to Use It» y organización por clases con Command), 119 (Domain Model, «When to Use It»), 133 (Service Layer, by Randy Stafford), 135 (operation script), 137 (Service Layer, «When to Use It»).
- Fowler, M. (2003-11-25). *AnemicDomainModel*. https://martinfowler.com/bliki/AnemicDomainModel.html
- Fowler, M. (2004-10-21). *LocalDTO*. https://martinfowler.com/bliki/LocalDTO.html
- Fowler, M. (2005-12-05). *CommandQuerySeparation*. https://martinfowler.com/bliki/CommandQuerySeparation.html
- Fowler, M. (2005-12-07). *ContextualValidation*. https://martinfowler.com/bliki/ContextualValidation.html
- Fowler, M. (2011-07-14). *CQRS*. https://martinfowler.com/bliki/CQRS.html
- Evans, E. (2015). *Domain-Driven Design Reference*. https://www.domainlanguage.com/wp-content/uploads/2016/05/DDD_Reference_2015-03.pdf — Aggregates p. 15, Repositories p. 16, Factories p. 17, Assertions p. 21.
- Hohpe, G. y Woolf, B. *Command Message*. https://www.enterpriseintegrationpatterns.com/patterns/messaging/CommandMessage.html
- Martin, R. C. (2012-08-13). *The Clean Architecture*. https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html
- Eiffel Software. *Design by Contract: Introduction*. https://www.eiffel.com/values/design-by-contract/introduction/
- Wirfs-Brock, R. (2006). *A Brief Tour of Responsibility-Driven Design*. https://www.wirfs-brock.com/PDFs/A_Brief-Tour-of-RDD.pdf
- Bloch, J. *Effective Java*, ítem 1 («Consider static factory methods instead of constructors») — libro, citado de memoria, no verificado en línea en esta corrida.

Locales (sólo lectura):

- `LAB/Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md` @ `dbdf9dd`
- `LAB/Lab-Documentos/Guides/Arquitectura/Examples/Dot-NET-Arquitectura-Lab/MyProject/` (`ProductoRepository.cs`, `AppDbContext.cs`, `Producto.cs`, `ProductoDto.cs`, `ProductoTests.cs`, `FakeProductoRepository.cs`, `ObtenerProductoPorIdHandler.cs`), `Variantes/Pedidos/` (`RegistrarPedidoHandler.cs`, `IUnitOfWork.cs`, `IPedidoRepository.cs`, `ItemPedido.cs`, `Demo/Program.cs`), `lab.sh`
- `Lab-Documentos.Documentacion/PROMPTs/Guides/06-Arquitectura/OUTPUTs/Bitacora-Editores/00-Contrato-De-Entrada.md`, `01-Base-Mecanica.md`, `Nucleos/NE-00-Cohesion.md`, `NE-01-Materializacion.md`, `NE-03-Fidelidad.md`
