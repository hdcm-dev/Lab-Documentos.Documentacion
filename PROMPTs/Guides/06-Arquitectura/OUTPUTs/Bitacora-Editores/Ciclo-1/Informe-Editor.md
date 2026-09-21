# Informe de la comisión Editor de libros técnicos — ciclo 1

**Fecha:** 2026-09-19
**Comisión:** Editor de libros técnicos (editorial de informática; arquitectura de software y guías de estudio)
**Objeto:** `Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md` @ `dbdf9dd` (v2.0.2, 2126 líneas)
**Competencia:** forma editorial y asociación código↔concepto en la página (NE-04 y NE-01): jerarquía e índice; definición + explicación + snippet mínimo con procedencia + marca que ata el snippet al concepto; que el código esté donde se define el concepto; cuándo un mermaid reemplaza prosa; autocontención; voz única y tells (Rule-Narrative-Voice); consistencia de plantilla entre secciones.
**No-competencia:** fidelidad de los patrones a Fowler/Evans/Martin, corrección del C#, pedagogía de la progresión. Lo que apareció de eso va en «Solicitudes de convocatoria».
**Modo:** a ciegas; no se leyó nada de `Ciclo-1/` antes de escribir este archivo.
**Medios:** lectura íntegra de la guía; `grep`/`awk`/`diff`/`python3` sobre la guía y sobre `Examples/Dot-NET-Arquitectura-Lab/` (MyProject/, Conceptos-DI/, Variantes/); lectura del contrato de entrada, la base mecánica, NE-00/NE-01/NE-04, el Profile y las Rules. No hubo consulta externa.

---

## Hallazgos

Doce, ordenados por nivel. La línea es la del archivo @ `dbdf9dd`.

### ED-01 · P1 · §3.1 ↔ §3.3 (l.502–603) — Las definiciones del dominio no se atan al código que las materializa

**Ancla E1/E2.** `grep -n "Factory Method"` devuelve las líneas 508 (definición), 635, 658 y 2002 (glosario): el término no aparece en ninguna línea de §3.3, que es donde está `Producto.Create` con su constructor privado. Lo mismo para *Invariant* (l.506 define; en §3.3 las líneas 566–567 son la Invariant y nada lo dice), *Excepción de dominio*, *Setter privado* y *`Guid`*. El único comentario del bloque (l.559, «Constructor privado: la única forma de crear un Producto es Create») describe el mecanismo pero no nombra el concepto. Contraste dentro de la misma guía: el bloque de la variante §3.7 (l.690–715) sí lleva la marca en cada línea decisoria («// Structural Assertion: …», «// Invariant: …», «// Precondition del acto de vender: …»). Dato de base mecánica: ninguna de las cinco secciones «Definiciones» tiene un bloque de código (01-Base-Mecanica §2).

**Impacto.** Es el núcleo del pedido: la definición vive en §3.1, el código en §3.3 y la frase que los une no existe. El lector que recorre ve la alegoría (definición) y después el código, y debe hacer él la asociación que la guía promete hacer. Se repite en §4.1↔§4.5 (Use Case «orquesta, no decide reglas»: la línea 899 lo comenta, pero *Handler*, *Command* y *Use Case* no se nombran sobre el bloque) y en §5.1↔§5.2/§5.6 (*Controller* delgado, *ProblemDetails*, *Middleware*).

**Dirección.** Como los bloques **[Compilado]** son extractos textuales (§0.5, l.92) y los comentarios del fuente no se pueden inventar en la página, la marca va **debajo del bloque**, en una tabla corta «línea → concepto» (candidato ya listado en NE-01):

| Líneas del bloque | Concepto (§3.1) |
| --- | --- |
| `private Producto() { }` + `public static Producto Create(…)` | *Factory Method*: el único camino de creación |
| `if (precio <= 0) throw new DomainException(…)` | *Invariant* «el precio es mayor a cero», verificada antes de que el objeto exista |
| `{ get; private set; }` | *Setter privado*: la Invariant no se puede romper desde afuera (§3.4) |

Alternativa, si el PO acepta tocar el fuente publicado: agregar los comentarios en `Producto.cs` (no altera ninguna captura L09–L24, que son salidas de compilación) y que el extracto los traiga. Cualquiera de las dos, aplicada a los 13 bloques **[Compilado]** con la misma plantilla.

### ED-02 · P1 · §0.5 (l.90), §2.1/§2.5, §4.1, §4.6, §5.3, §5.5 — Tipos que encarnan un concepto y existen en el laboratorio, pero nunca aparecen como código

**Ancla E1.** `find Examples/… -name "*.cs"` lista, entre otros, estos archivos de `MyProject/` que la guía nombra y jamás muestra:

| Archivo | Concepto que materializa | Dónde lo define la guía | Cómo lo presenta |
| --- | --- | --- | --- |
| `WebAPI/Program.cs` (tiene el comentario `// Composition root: …`) | *Composition root* | §2.1 l.251, §2.5 l.430, §5.2 l.1167 | Prosa; 13 menciones, cero líneas de código del laboratorio |
| `Infrastructure/Persistence/Repositories/ProductoRepository.cs` | *Repository* (implementación) | §4.1 l.753, §4.4, §5.3, §5.5 | Prosa; el experimento L18 narra el cambio de una línea (`SaveChangesAsync` → `Task.CompletedTask`) de un archivo que el lector no vio |
| `Application.Tests/FakeProductoRepository.cs` | *Doble de prueba* | §4.6 l.923, §6.2 l.1336 | Prosa («guarda los productos en una lista, `Guardados`») |
| `Application/Productos/ProductoDto.cs` | *Modelo de lectura*, mapeo manual | §4.1 l.752; §9.4 lo opone a AutoMapper | Prosa («copia campo a campo, escrita a mano»); `From` nombrado en l.906 |
| `Queries/ObtenerProductos/*.cs` | *Query* y su *Handler* | §4.1 l.750, §4.3 l.832, §7.1 | Solo la firma `ObtenerProductoPorIdQuery(Id)` en una viñeta |
| `Infrastructure/Persistence/AppDbContext.cs` | *DbContext*, *Unit of Work* | §5.1 l.1137, l.1139 | Prosa |

La fila «Tipo nombrado sin código» de §0.5 (l.90) legaliza esto en bloque: «el archivo completo está en `Examples/…`».

**Impacto.** El pedido dice «no me quedaría solo en la alegoría». Un *Composition root* que sólo se describe, un *Repository* cuya implementación nunca se ve y un *Modelo de lectura* cuya «copia a mano» se alaba pero no se muestra son exactamente eso. La exención de §0.5 es razonable para tipos auxiliares, no para los que dan nombre a una definición.

**Dirección.** Un bloque **[Compilado]** de 3–8 líneas por concepto, en la sección donde se define o se usa por primera vez: `Program.cs` l.14–18 en §2.5 (composition root real, con su comentario); `ProductoRepository.AddAsync` (l.17–21 del fuente: `Add` + `SaveChangesAsync`, con sus dos comentarios) en §5.5, que es lo que L18 rompe; `FakeProductoRepository` (la propiedad `Guardados` y `AddAsync`) en §4.6; `ProductoDto` completo (7 líneas) en §4.5; `ObtenerProductosQuery` + el `Handle` de su Handler en §4.5 para que *Query* tenga cuerpo. Reescribir la fila de §0.5 para que cubra sólo tipos auxiliares (`InMemoryProductoRepository`, `Intento.cs`).

### ED-03 · P1 · §4.1 (l.755) ↔ §4.10 (l.1091, l.1115) — «Interfaz de servicio técnico» se define con ejemplos que el laboratorio no tiene, y su única instancia real no se asocia

**Ancla E1/E2.** §4.1 define el concepto con `IEmailService` e `ICurrentUserService`; §2.7 (l.490) confirma que ningún archivo de `Infrastructure` nombra un tipo de `Application` y que «el ejemplo no llega a necesitar un servicio técnico». Pero `Variantes/Pedidos/Application/Common/IUnitOfWork.cs` existe y su primer comentario dice, textual: `// Interfaz de servicio técnico: la implementa el AppDbContext en Infrastructure.` La guía usa `IUnitOfWork` en el bloque de §4.10 (l.1091) y lo explica en l.1115, sin decir nunca que es la interfaz de servicio técnico de §4.1 ni en qué carpeta vive (`Application/Common`, que es la ubicación que la definición prescribe).

**Impacto.** La definición queda en alegoría (dos nombres hipotéticos) mientras el código que la encarna está a seis pantallas, con el rótulo puesto en el fuente y borrado en la página. Es el caso inverso de ED-01: el fuente ata, la guía desata.

**Dirección.** En §4.10, debajo del bloque del Handler, un **[Compilado: `Variantes/Pedidos/Application/Common/IUnitOfWork.cs`]** de 4 líneas con su comentario, y la frase «esta es la *interfaz de servicio técnico* del §4.1: declarada en `Application`, implementada por `AppDbContext` en `Infrastructure`». En §4.1, citar `IUnitOfWork` como la instancia del laboratorio y dejar `IEmailService` como ejemplo hipotético, marcado como tal.

### ED-04 · P1 · §4.1 (l.754), §4.10 (l.991, l.1034–1067) — El *Aggregate* se materializa a medias: el hecho que hace cumplir el límite se narra, no se muestra

**Ancla E1/E2.** La l.991 afirma «el constructor de `ItemPedido` es `internal` para que nadie fuera de `Domain` lo invoque»; la l.1067 describe los campos de `ItemPedido` en prosa. El archivo `Variantes/Pedidos/Domain/Pedidos/ItemPedido.cs` (23 líneas) contiene el constructor `internal` con el comentario `// internal: fuera de Domain nadie crea un ítem sin pasar por Pedido.AgregarItem.` y `PrecioUnitario` con `// copia del precio al momento de vender`. Nada de eso llega a la página. Dato NE-04: el capítulo 4 no tiene ningún diagrama (01-Base-Mecanica §5); la relación raíz→ítem→copia del precio es justo una relación estructural que la prosa de l.1067 carga.

**Impacto.** *Aggregate Root* es la definición más abstracta del capítulo y la única cuyo mecanismo de cumplimiento (visibilidad `internal`) queda fuera de la vista. El lector ve a `Pedido` agregar ítems, pero no ve por qué no podría agregarlos otro.

**Dirección.** Un **[Compilado: `Variantes/Pedidos/Domain/Pedidos/ItemPedido.cs`]** de 6 líneas (las dos propiedades comentadas, el constructor `internal` con su comentario, `Subtotal`), debajo del bloque de `Pedido`, con la frase «`internal` es lo que convierte a `Pedido` en *Aggregate Root*: es la única puerta». Un `classDiagram` mermaid de tres cajas (`Pedido` ◆— `ItemPedido`, `ItemPedido` ··> `Producto` «copia Id, Nombre, PrecioDeVenta()») reemplazaría la oración de l.1067 sobre los campos; es el único lugar del capítulo donde un diagrama haría trabajo que la prosa hace mal.

### ED-05 · P1 · §3.1 (l.509), §3.3 (l.603), §7.2 b (l.1477) — La propiedad definitoria del *Value Object* se afirma tres veces y se muestra cero

**Ancla E1/E2.** §3.1: «dos *Value Objects* con los mismos datos son el mismo valor»; §3.3: «su igualdad se comprueba en las pruebas de L11»; §7.2 b: «Dos `Dinero(10, "ARS")` son el mismo valor (prueba de L11)». La prueba existe: `MyProject/tests/Backend/MyProject.Domain.Tests/ProductoTests.cs` l.21–23, `Dos_Dinero_con_los_mismos_datos_son_iguales() => Assert.Equal(new Dinero(10m, "ARS"), new Dinero(10m, "ARS"));`. No aparece en la guía; el único bloque de pruebas mostrado (§4.6) es el del Handler.

**Impacto.** Lo que distingue al *Value Object* de la *Entity* (igualdad por datos, no por identidad) es la única parte del concepto que no se ve; `Dinero.Sumar` muestra comportamiento, que también tiene la Entity.

**Dirección.** Dos líneas **[Compilado: `…/ProductoTests.cs`]** en §3.3, después de «su igualdad se comprueba en las pruebas de L11», con la frase «esto es lo que `record` da gratis y una `class` no: la igualdad por datos que define al *Value Object*». §7.2 b remite a ese bloque.

### ED-06 · P1 · §6.1 (l.1329–1330), §6.2, §7.1, §7.2 e/f/g — Cuatro objetos definidos y tabulados sin ninguna línea de código

**Ancla E1.** `grep -c` sobre la guía: `ProductoListItemViewModel` aparece en §7.1/§7.2 e/§7.3/§8.4; `ProductoFormModel` en §7.1/§7.2 f/§7.3; `ProductoDbModel` en §7.1/§7.2 g; `IProductoApiService` en §6.1/§6.2 (4 veces). Ningún bloque de código los contiene; §7.1 promete siete objetos, tres no tienen materialización. §0.1 (l.51) admite «fragmentos ilustrativos» para los clientes, y §6.5 ya usa uno (`ApiTokenHandler`, 17 líneas).

**Impacto.** La tabla de §7.1 es la pieza de consulta del capítulo «Criterio»; el lector decide con ella qué clase usar y, para tres de las siete, no ha visto nunca cómo es la clase. En §7.2 f, la respuesta gira sobre «setters públicos que el formulario enlaza» contra «setters privados de la Entity»: el contraste pide ver los dos, y sólo se ve uno.

**Dirección.** Un **[Fragmento ilustrativo: cliente Blazor no construido en el laboratorio]** de 3–5 líneas en §7.2 e, f y g, y la interfaz `IProductoApiService` (3 métodos) en §6.2, debajo del Diagrama 5. Ejemplo para §7.2 f:

```csharp
public class ProductoFormModel                      // form model: lo que la pantalla enlaza
{
    [Required] public string Nombre { get; set; } = "";
    [Range(0.01, 1_000_000)] public decimal Precio { get; set; }   // validación de formulario, no la Invariant
}
```

### ED-07 · P1 · §6.2 (l.1352) ↔ §6.3 (l.1369–1378) — El ❌ de una sección es el **[Compilado]** de la siguiente, sin una frase que lo reconcilie

**Ancla E2.** §6.2, fila ❌: «La página crea un `HttpClient` y arma la URL `api/productos` en su propio código». Veinte líneas después, §6.3 muestra como **[Compilado: `MyProject/src/Clients/MyProject.ConsoleClient/Program.cs`]** exactamente eso: `using var http = new HttpClient { BaseAddress = … }` y `"api/productos"` literal, dos veces. La prosa de §6.3 (l.1390) no menciona la tensión; §6.6 la exime sólo para el escenario E-A («no habla HTTP con nadie»), que no es el caso del cliente de consola.

**Impacto.** Un criterio ✅/❌ pierde autoridad cuando el código del laboratorio hace el ❌ sin explicación. El lector no sabe si la regla vale o si es ceremonia.

**Dirección.** Una oración en §6.3, después del bloque: por qué el cliente de consola está exento (no tiene pantalla que probar, un solo archivo, sin dobles) y cuándo dejaría de estarlo (la primera prueba del cliente o la segunda pantalla), atándolo a la señal de §9.3 «una capa que solo reenvía». Opcional: nombrar la fila ❌ de §6.2 como «en una página», no en cualquier cliente.

### ED-08 · P2 · §0.5 (l.86), §2.2 (l.323), §4.5 (l.886), §4.10 (l.1069) — Procedencia de los snippets: sin rango, dos veces a una carpeta, y un comentario del fuente reescrito en la página

**Ancla E1/E4.** Rule-Dual-Audience exige «snippets con procedencia (ruta + rango + versión de la fuente)». Los 13 **[Compilado]** dan ruta sin rango; dos dan una **carpeta** (`…/Commands/CrearProducto/`, `…/Commands/RegistrarPedido/`) y el bloque mezcla archivos (`RegistrarPedidoCommand.cs` con tres `record` + el `Handle` de `RegistrarPedidoHandler.cs`) sin decir cuál es cuál. En §2.2, `diff` entre la guía (l.323) y `Conceptos-DI/Paso1/Program.cs` l.1: el fuente dice `// composition root: el único que conoce las dos piezas`; la guía imprime `// el único lugar que conoce las dos piezas`. El bloque es ilustrativo, así que §0.5 no lo prohíbe, pero la edición quitó justamente el nombre del concepto (ver ED-02).

**Impacto.** Sin rango ni archivo, la verificación E1 de un bloque exige abrir la carpeta y buscar; con el comentario reescrito, la asociación código↔concepto que el autor del fuente dejó no llega al lector.

**Dirección.** `[Compilado: ruta/Archivo.cs, l.x–y]` por bloque; en los dos bloques de carpeta, una marca por archivo (dos bloques o un separador comentado `// — RegistrarPedidoHandler.cs —`). Restituir el comentario original en §2.2.

### ED-09 · P2 · §0.5 (l.86–87) ↔ §2.2 (l.290) — Código que compiló con cero advertencias rotulado como «Fragmento ilustrativo»: un tercer estado que la tabla de marcas no contempla

**Ancla E1/E2.** §2.2 marca los tres programas de `Conceptos-DI/` como **[Fragmento ilustrativo: … compilaron con SDK 10.0.400 y cero advertencias y se ejecutaron con `dotnet run`, sin captura registrada]**. La definición de §0.5 dice que un fragmento ilustrativo «o no se compiló, o se compiló solo para provocar un error y se eliminó, o es un programa aparte que ilustra un concepto»; la de **[Compilado]** exige «compila con cero advertencias y lo ejecuta `variantes.sh`». `grep -n Conceptos Variantes/variantes.sh lab.sh` no devuelve nada: `Conceptos-DI/` no lo ejecuta ningún guion y no tiene captura.

**Impacto.** La marca es el contrato de confianza de la guía (l.20: «lo que no se ejecutó está rotulado»). Aquí lo ejecutado se rotula como no ejecutado; el lector cuidadoso lo nota y el descuidado aprende que la marca no discrimina.

**Dirección.** Paso V00 en `variantes.sh` (build + run de Paso0/1/2, capturas `V00-…`) y remarcar §2.2 como **[Compilado: `Conceptos-DI/Paso1/Program.cs`]**. Si no se quiere ampliar `variantes.sh`, agregar a §0.5 una fila «Programa aparte, compilado sin captura» para no forzar el rótulo. Lo primero es coherente con NE-05 («primero se compila, después se cita»).

### ED-10 · P2 · §0.3 (l.64) ↔ capítulos 7–9; §4.10 (l.995), §9.6 (l.1813) — La plantilla de capítulo que la guía promete no se cumple en la Parte III ni en dos secciones de la Parte II

**Ancla E1/E2.** §0.3: «Dentro de cada capítulo el orden es fijo: prerrequisitos, definiciones, decisiones formuladas como pregunta …, práctica y una pregunta de cierre». `grep -nE "^### (7|8|9)\."`: los capítulos 7, 8 y 9 no tienen sección «Definiciones»; 7 y 9 no tienen «Pregunta de cierre» (7.6 es una pregunta sin ese rótulo; 9 cierra con «El criterio, en una línea»). `awk` sobre encabezados: §4.10 y §9.6 tienen «**Respuesta:**» en negrita debajo de un título que no es pregunta (en §4.10 la pregunta va en negrita dentro del cuerpo, l.993). El encabezado §7.1 «La tabla» nombra la forma, no el contenido.

**Impacto.** Rule-Markdown y el Profile piden «la misma estructura interna» en todos los documentos temáticos; la guía además la declara. Una promesa de plantilla incumplida cuesta más que no prometerla: el lector de consulta busca «Definiciones» en §7 y no está (ViewModel, Form model y Persistence model se definen en §6.1 y en la tabla §7.1).

**Dirección.** Reescribir la frase de §0.3 para que la plantilla rija en las Partes I y II y describa la de la Parte III (tabla de entrada → preguntas → criterio en una línea); convertir el título de §4.10 y §9.6 en pregunta o quitarles la marca «Respuesta»; renombrar §7.1 por su contenido («Los siete objetos y su pregunta»).

### ED-11 · P2 · Anexo D (l.1962–2046), §0.2 (l.55) — El glosario apunta a la definición y no al código; cuatro «2.» huérfanos; términos usados sin entrada y una entrada sin uso

**Ancla E1/E2.** La columna «§» del glosario remite a la sección de definición: *Factory Method* → 3.1 (el código está en 3.3), *Handler* → 4.1, 4.3 (código en 4.5), *Controller* → 5.1 (código en 5.2), *Configuración Fluent API* → 5.1 (código en 5.4), *Doble de prueba* → 4.6, 6.2 (el archivo no se muestra; ED-02). Cuatro filas dicen «2., 2.2» (l.1981, 2009, 2010, 2032) donde corresponde «2.1». §0.2 promete que «cada definición figura en el Anexo D»; `grep -ci` cuerpo vs. glosario: *Main Success Scenario* (2/0), *Minimal Guarantee* (2/0), *Table Data Gateway* (1/0), *DAO* (1/0), *DelegatingHandler* (2/0), `HttpClient` (7/0), «prueba del papel» (4/0, herramienta propia de la guía). *Validación contextual* está en el glosario (l.2044) y no se usa en el cuerpo (0).

**Impacto.** El glosario es el único índice por concepto de la guía (el índice de l.22–41 es por capítulo). Para el pedido —«que el lector encuentre el código donde se define el concepto»— le falta la columna que lo lleve al código.

**Dirección.** Agregar al glosario una columna «Código» (§ y archivo: *Factory Method* → §3.3, `Producto.cs`); corregir los cuatro «2.»; dar entrada a los siete términos faltantes y quitar o usar *Validación contextual*.

### ED-12 · P3 · l.1219, l.1347, l.1557 — La numeración de los diagramas no sigue el orden de lectura

**Ancla E1.** `grep -n "^\*Diagrama"`: 1 (l.286), 1a (l.372), 2 (l.488), **4** (l.1219, §5.2), **5** (l.1347, §6.2), **3** (l.1557, §7.3), 6 (l.1765). El Diagrama 3 aparece después del 4 y del 5.

**Impacto.** Menor, pero es lo primero que un corrector de estilo marca, y delata que el diagrama se movió sin renumerar.

**Dirección.** Numerar por capítulo (Diagrama 2.1, 2.2, 2.3, 5.1, 6.1, 7.1, 9.1), que además sobrevive a futuras inserciones; o renumerar 1, 1a, 2, 3, 4, 5, 6 por orden de aparición.

---

## Lo que revisé y está bien

1. **Voz sin tells de texto generado.** `grep -nE "Es importante|Cabe destacar|En resumen|En conclusión|Como se puede observar|Vale la pena|^Además|\. Además|Asimismo|Por otro lado|Por consiguiente"` sobre las 2126 líneas: **0 coincidencias**. Las secciones abren con contenido, no reformulando el título (muestra: §1.3 l.167, §3.6 l.641, §7.4 l.1565); la longitud de frase varía. Rule-Narrative-Voice se cumple en la prosa. (E1)
2. **Los extractos [Compilado] son textuales.** `diff` entre la guía l.552–573 y `MyProject/src/Backend/MyProject.Domain/Productos/Producto.cs` l.5–26: **idénticos**. `diff` entre l.1078–1093 y el método `Handle` de `RegistrarPedidoHandler.cs` l.20–35 (quitada la sangría de clase): idénticos, incluidos los comentarios `// 2a`, `// 3a y 3b, en Domain`, `// 4a, en Domain`. §0.5 («no reescriben ninguna expresión») se cumple en los dos casos muestreados. (E1)
3. **Enlaces internos e índice.** Script python sobre encabezados y anclas `<a id>`: **114 enlaces internos, 0 rotos** (coincide con la verificación del PR #7 registrada en 00-Contrato-De-Entrada). Las descripciones del índice (l.24–41) ya reflejan las secciones nuevas de la v2.0.2: «dónde vive cada tipo de regla y cuándo una regla es una Precondition» (§3.6–3.7), «un Use Case con dos Entities» (§4.10), «cómo se traduce el vocabulario de las clases planas» (§7.4), «la escalera en código» (§9.6). La pregunta de NE-04 «¿el índice refleja las secciones nuevas?» se responde que sí, a nivel de capítulo. (E1/E2)

---

## Solicitudes de convocatoria

Señales fuera de mi competencia, con ubicación; no son hallazgos.

| # | Para | Señal | Ubicación |
| --- | --- | --- | --- |
| SC-1 | Especialista .NET/C# (y Fowler, por la ilusión de colección de §4.4) | `ProductoRepository.GetByIdAsync` y `GetAllAsync` usan `AsNoTracking()`. Si ED-02 lleva ese archivo a la página, el lector verá un *Repository* cuyas Entities leídas no persisten cambios con `SaveChanges`; ¿se muestra tal cual con advertencia, o se ajusta antes de citarlo? | `MyProject/src/Backend/MyProject.Infrastructure/Persistence/Repositories/ProductoRepository.cs` l.12–16; guía §4.4 l.864–866 |
| SC-2 | Especialista .NET/C# | §2.2 Paso 2 registra `AddSingleton<IAlmacenDeProductos, ArchivoDeTexto>()` y la WebAPI usa `AddScoped`; la guía no define *lifetime* en ninguna sección (`grep -ci lifetime` = 0; «Singleton»/«Scoped» sin explicación). Si se materializa el composition root (ED-02), el concepto aparece en el código sin definición. | Guía l.384–385, l.1167; `Program.cs` l.15–18 |
| SC-3 | Comisión Fowler | §3.1 usa *Factory Method* «en el sentido corriente» y declara la divergencia con Gamma et al.; Evans llama *Factory* al mismo mecanismo. La fidelidad del nombre elegido y su glosa no es editorial. | Guía l.508, l.2002 |
| SC-4 | Académico en pedagogía | §4.2 introduce `VenderCommand`, `VenderHandler`, `IPedidoRepository` como fragmento ilustrativo antes de que exista ningún Command compilado, y §4.10 renombra el mismo acto a `RegistrarPedido`. Dos nombres para un acto antes del primero real: carga cognitiva de la progresión. | Guía l.764–790, l.987–1005 |

---

## Fuentes consultadas

Todas locales; sin consultas externas en este ciclo.

| Fuente | Uso |
| --- | --- |
| `LAB/Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md` @ `dbdf9dd` | Objeto; lectura íntegra; `grep`, `awk`, `diff`, script python de anclas |
| `LAB/Lab-Documentos/Guides/Arquitectura/Examples/Dot-NET-Arquitectura-Lab/` (`MyProject/`, `Conceptos-DI/`, `Variantes/`, `lab.sh`, `Variantes/variantes.sh`) | `find` de `.cs`; lectura de `Producto.cs`, `Program.cs` (WebAPI), `DependencyInjection.cs`, `ProductoRepository.cs`, `AppDbContext.cs`, `ProductoDto.cs`, `ObtenerProductos*.cs`, `FakeProductoRepository.cs`, `ProductoTests.cs`, `ItemPedido.cs`, `Pedido.cs`, `IUnitOfWork.cs`, `RegistrarPedidoCommand.cs`, `RegistrarPedidoHandler.cs`, `Conceptos-DI/Paso1/Program.cs`, `Paso2/Program.cs` |
| `…/OUTPUTs/Bitacora-Editores/00-Contrato-De-Entrada.md`, `01-Base-Mecanica.md` | Pedido literal, preguntas Q1–Q7, datos E1 de partida |
| `…/OUTPUTs/Bitacora-Editores/Nucleos/NE-00-Cohesion.md`, `NE-01-Materializacion.md`, `NE-04-Forma.md` | Núcleos que juzga esta comisión y candidatos de marca |
| `IA/PROMPTs/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md` | Estructura común de los documentos temáticos; criterios de calidad |
| `IA/PROMPTs/IA.Prompts/PromptFramework/Rules/Rule-Evidences.md`, `Rule-Narrative-Voice.md`, `Rule-Dual-Audience.md`, `Rule-Markdown.md` | Anclas E4 (ED-08, ED-10; verificación de «está bien» 1) |

Comandos reproducibles (desde `LAB/Lab-Documentos/Guides/Arquitectura/`, `G=Dot-NET-Arquitectura-Guide.md`):

```bash
grep -n "Factory Method" $G                                   # ED-01: 508, 635, 658, 2002
grep -n "^\*\*\[Compilado" $G                                 # ED-02/ED-08: 13 marcas, dos a carpeta
grep -rn "Interfaz de servicio técnico" Examples/ --include=*.cs   # ED-03: IUnitOfWork.cs
sed -n '21,23p' Examples/Dot-NET-Arquitectura-Lab/MyProject/tests/Backend/MyProject.Domain.Tests/ProductoTests.cs   # ED-05
grep -n Conceptos Examples/Dot-NET-Arquitectura-Lab/Variantes/variantes.sh Examples/Dot-NET-Arquitectura-Lab/lab.sh  # ED-09: vacío
awk '/^### |^#### /{h=$0} /^\*\*Respuesta:/{ if (h !~ /\?/) print NR": "h}' $G   # ED-10: 995, 1813
grep -n "^\*Diagrama" $G                                      # ED-12
diff <(sed -n '552,573p' $G) <(sed -n '5,26p' Examples/Dot-NET-Arquitectura-Lab/MyProject/src/Backend/MyProject.Domain/Productos/Producto.cs)   # está bien 2
```
