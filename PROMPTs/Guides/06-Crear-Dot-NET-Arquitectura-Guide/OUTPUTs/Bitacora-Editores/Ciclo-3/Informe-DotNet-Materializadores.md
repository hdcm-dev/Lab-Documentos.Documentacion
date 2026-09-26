---
doc: Informe de la comisión especialista .NET/C# — ciclo 3
guia: Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md (v2.2.0)
encargo: definir Dapper y serializador, medirlos contra la misma Entity, proponer los snippets
fecha: 2026-09-21
entorno: mcr.microsoft.com/dotnet/sdk:10.0@sha256:e1ffd2a92ae84c1291bc1b6887501f8af98e6331e7af6d4c8d37168c5e87a64c — SDK 10.0.400
paquetes_medidos: Dapper 2.1.86 (Apache-2.0), Microsoft.Data.Sqlite 10.0.12
banco: fuera del repo, en el scratchpad de la sesión; sin bin/ ni obj/ y sin archivos de root
---

# Dapper, el serializador y la tabla de los materializadores

## 0. Qué pidió el Product Owner y qué se hizo

Pedido literal (2026-09-21): «también mencionás Dapper y serializador, no sé qué son esos términos, EF Core sí sé que es, pero de esos tres podés agregar ejemplos, algo de código snippet para formar una idea visual respecto a esa tabla comparativa que das … introducir estos temas en el documento».

Se hizo: (1) redacción propuesta de las dos definiciones que faltan; (2) medición real de los tres materializadores contra **la misma Entity con constructor privado sin parámetros y setters privados** —el patrón de §3.3—, en el contenedor y fuera del repo; (3) propuesta de snippets dentro del presupuesto de dos bloques; (4) revisión de lo que la guía afirma hoy sobre serialización y otros materializadores.

**Primer hecho a registrar, porque cambia el encargo:** la tabla comparativa de los cuatro constructores/materializadores **no está en la v2.2.0**. En toda la guía, «Dapper» aparece **una** vez (l. 2127, de pasada) y «serializador», **dos** (l. 2114 y 2127); `System.Text.Json` aparece sólo como línea de `using` dentro de un fragmento ilustrativo. La tabla que el PO recuerda salió de la conversación de mesa, no del documento. El encargo, entonces, no es sólo agregarle ejemplos a una tabla existente: es **escribir la tabla y sus ejemplos**, y el lugar natural es §5.4, a continuación de «El constructor privado es la costura del ORM».

---

## 1. Las dos definiciones que faltan (redacción propuesta)

Redacción corta, sin marketing, en el registro de la guía. Las tres entradas de glosario van al Anexo D en su orden alfabético; las dos viñetas van a §5.1 (Dapper y ORM, que es donde vive la persistencia) y a §6.1 (serializador, que es donde vive el borde HTTP). No consumen presupuesto de bloques: son prosa y filas de tabla.

### 1.1 Anexo D — tres filas nuevas

| Término | Equivalente o alias | Definición | § | Código |
| --- | --- | --- | --- | --- |
| Micro-ORM | Dapper | Biblioteca que toma el resultado de un SQL **escrito a mano** y lo convierte en objetos, y nada más: no arma la consulta, no sigue los cambios de los objetos que devolvió y no confirma una unidad de trabajo. Lo que un ORM hace por convención, acá lo escribe quien programa | 5.1, 5.4 | — |
| ORM | *object-relational mapper*, mapeador objeto-relacional | Biblioteca que traduce objetos de C# a filas de una base relacional y al revés, y que además sigue los cambios de los objetos que entregó para confirmarlos juntos; EF Core es el de esta guía | 5.1, 5.4 | §5.4, `ProductoConfiguration.cs` |
| Serializador | *serializer*; `System.Text.Json` | Componente que convierte un objeto en texto (JSON) para que salga del proceso, y reconstruye el objeto a partir de ese texto del otro lado. En .NET es `System.Text.Json`, y lo usan la API al responder y el cliente al leer | 5.1, 6.1 | §6.3, `GetFromJsonAsync<List<ProductoResponse>>` |

### 1.2 §5.1 — una viñeta nueva, y un agregado a la de EF Core

> - **ORM y micro-ORM.** Un **ORM** (*object-relational mapper*) traduce objetos a filas y al revés, y además **sigue los cambios** de los objetos que entregó para confirmarlos juntos: EF Core es el de esta guía. Un **micro-ORM** hace sólo la mitad: recibe el SQL escrito a mano, ejecuta y materializa los objetos del resultado; no arma la consulta, no sigue nada y no confirma nada. **Dapper** es el micro-ORM más usado en .NET. La diferencia no es de tamaño sino de responsabilidad: con EF Core el `DbContext` **es** el Repository y la Unit of Work (§5.5); con Dapper esas dos piezas hay que escribirlas.

### 1.3 §6.1 — una viñeta nueva

> - **Serializador.** Componente que convierte un objeto en texto para que salga del proceso y lo reconstruye del otro lado. En .NET es `System.Text.Json`: la API lo usa para escribir la respuesta y el cliente, dentro de `GetFromJsonAsync`, para volver a armar los `ProductoResponse` (§6.3). Es el tercer materializador de la guía, y el único que trabaja **en el borde**: por eso lo que él necesita poder escribir es el contrato, no la Entity (§7.4).

---

## 2. La medición

Banco de pruebas: una Entity `Producto` idéntica en forma a la de §3.3 —`private Producto()`, `{ get; private set; }`, `static Create` que valida— y cinco variantes de contraste. Base SQLite en memoria con una fila (`Mate`, 3500). EF Core no se volvió a medir: se reutiliza V05 y V07 del repo, que corrieron sobre la misma imagen y el mismo SDK.

### 2.1 Resultado, en una tabla

| Caso | EF Core 10 (V05/V07) | Dapper 2.1.86 (V09) | `System.Text.Json` (V09) |
| --- | --- | --- | --- |
| Ctor privado sin parámetros + setters privados | **Materializa** (2 llamadas al ctor: alta y relectura) | **Materializa** (1 llamada al ctor privado) | **Lanza** `NotSupportedException` |
| Sólo ctor con parámetros, nombres que coinciden | Materializa si además coinciden los **tipos mapeados** | Materializa si coinciden nombre **y tipo de columna** | **Materializa** (es el caso del `record` posicional) |
| Sólo ctor con parámetros, nombres que no coinciden | `InvalidOperationException` (V07) | `InvalidOperationException` | `InvalidOperationException` |
| Ctor privado con `[JsonConstructor]` | n/c | n/c | **Materializa** |
| Nombres de columna/propiedad distintos | La propiedad no se mapea | **Valor por omisión, sin avisar** | (equivalente: la propiedad queda en su valor por omisión) |
| Ctor público sin parámetros + setters privados | Materializa | Materializa | **No lanza y deja todo en cero** |
| Al salir: propiedades de sólo lectura | n/c | n/c | **Las incluye**, incluidas las calculadas |

### 2.2 Dapper — salida exacta

```text
== Dapper 2.1.86+8becae8d0e ==

A. Entity con constructor privado sin parámetros y setters privados
   materializada: Nombre = Mate, Precio = 3500, Id = asignado
   veces que corrió el constructor privado: 1

B. Entity sin constructor sin parámetros; los parámetros se llaman como las columnas
   InvalidOperationException: A parameterless default constructor or one matching signature (System.String Nombre, System.Double Precio) is required for Materializadores.ProductoSoloCtorQueCoincide materialization

C. Entity sin constructor sin parámetros y con nombres que NO coinciden
   InvalidOperationException: A parameterless default constructor or one matching signature (System.String Nombre, System.Double Precio) is required for Materializadores.ProductoCtorQueNoCoincide materialization

C2. Entity sin constructor sin parámetros, con nombres Y tipos que coinciden
   materializada: Nombre = Mate, Precio = 3500
   veces que corrió el constructor con parámetros: 1

D. Las columnas no se llaman como las propiedades
   materializada: Nombre = '', Precio = 0  (no lanzó)

E. Sin seguimiento de cambios: se modifica el objeto y se vuelve a leer
   en memoria = 9999, en la base = 3500  (nadie confirmó nada: no hay Unit of Work)
```

Y, en una corrida aparte porque Dapper cachea el materializador por consulta y tipo:

```text
A0. Propiedad Guid contra una columna TEXT, sin TypeHandler registrado
   DataException: Error parsing column 0 (Id=304be298-a927-40e1-b3d3-1319adb666e2 - String)
```

Tres lecturas. **Primera:** Dapper materializa la Entity de §3.3 *tal cual está*, sin abrirle nada —usa el constructor privado sin parámetros y escribe los setters privados, igual que EF Core—; el caso B/C2 muestra que su búsqueda de constructor con parámetros es por nombre **y por tipo de columna** (`System.Double` porque SQLite devolvió el `real`), más estricta que la de EF Core, que empareja contra propiedades mapeadas. **Segunda:** el caso D es el peligroso y no tiene equivalente en EF Core: si la columna no se llama como la propiedad, Dapper **no avisa**, devuelve el objeto con el valor por omisión y la Invariant que `Create` protegía queda violada en silencio (`Nombre = ''`, `Precio = 0`). **Tercera:** el caso A0 es la definición de micro-ORM hecha error: no hay conversor por convención, la conversión `TEXT → Guid` hay que registrarla.

### 2.3 `System.Text.Json` — salida exacta

```text
== System.Text.Json ==

JSON de entrada: {"Id":"11111111-1111-1111-1111-111111111111","Nombre":"Mate","Precio":3500}

A. Deserializar la Entity con constructor privado sin parámetros y setters privados
   NotSupportedException: Deserialization of types without a parameterless constructor, a singular parameterized constructor, or a parameterized constructor annotated with 'JsonConstructorAttribute' is not supported. Type 'Materializadores.Producto'. Path: $ | LineNumber: 0 | BytePositionInLine: 1.

B. Constructor público sin parámetros, setters privados
   Nombre = '', Precio = 0, Id = Guid.Empty  (no lanzó)

C. Constructor privado con parámetros, anotado con [JsonConstructor]
   Nombre = 'Mate', Precio = 3500

D. Un único constructor público con parámetros que coinciden con las propiedades
   Nombre = 'Mate', Precio = 3500

E. Un único constructor público con parámetros que NO coinciden
   InvalidOperationException: Each parameter in the deserialization constructor on type 'Materializadores.ProductoCtorQueNoCoincide' must bind to an object property or field on deserialization. Each parameter name and type must match with a property or field on the object. Fields are only considered when 'JsonSerializerOptions.IncludeFields' is enabled. The name match can be case-insensitive.

F. Al serializar: ¿salen las propiedades de sólo lectura?
   setters privados:  {"Id":"551ca8aa-2c7d-4fdb-b80b-2eab9ade1a40","Nombre":"Mate","Precio":3500}
   get sin setter:    {"Nombre":"Mate","Precio":3500,"Creado":"2026-09-21","PrecioConIva":4235.00}
```

Respuestas puntuales a lo preguntado. **¿Puede deserializar una Entity con setters privados?** Depende del constructor, no de los setters: con el constructor privado sin parámetros **lanza** (A); con un constructor público sin parámetros **no lanza y deja las propiedades en su valor por omisión** (B) —el peor de los dos mundos, porque el programa sigue con un objeto vacío—; con `[JsonConstructor]` sobre un constructor privado con parámetros (C) o con un único constructor público cuyos parámetros coincidan, sin atributo (D), **materializa sin tocar un solo setter**. La coincidencia es por nombre, sin distinguir mayúsculas, y si falla el mensaje lo dice en letras (E). **Al serializar** incluye todo lo que tenga `get` público: las de setter privado, las de sólo lectura (`Creado`) y **las calculadas** (`PrecioConIva`, que no estaba en ningún JSON de entrada).

---

## 3. Hallazgos

| ID | Sección | Nivel | Ancla | Hallazgo y dirección de la corrección |
| --- | --- | --- | --- | --- |
| **NET3-01** | §5.4 (l. 1618–1631) | **P1** | **E1** — `grep -c "Dapper" Dot-NET-Arquitectura-Guide.md` → `1`; `grep -c "serializador"` → `2`; `grep -c "System.Text.Json"` → `1` (una línea de `using` en un fragmento ilustrativo) | **La tabla de los cuatro materializadores no existe en la v2.2.0.** El PO la recuerda de la mesa; el documento sólo tiene el párrafo de EF Core. Los dos términos que él no reconoce aparecen sin definición y de pasada (l. 2127: «si mañana se guarda con Dapper o en un archivo»). **Dirección:** escribir la tabla en §5.4, inmediatamente después de «El constructor privado es la costura del ORM», con las cuatro filas —`Create`, EF Core, Dapper, `System.Text.Json`— y las tres columnas que el PO nombra; las definiciones van antes, en §5.1 y §6.1 (§1 de este informe). |
| **NET3-02** | Anexo D, §5.1, §6.1 | **P1** | **E1** — el glosario tiene `EF Core`, `DbContext`, `JSON`, pero no `ORM`, `micro-ORM`/`Dapper` ni `Serializador`; «ORM» se usa como sigla conocida en l. 639, 1618, 1626, 2081, 2090, 2120, 2127, 2131 y no se expande en ninguna | **Se usa un vocabulario que no se definió.** La guía define `EF Core` pero nunca dice qué es un ORM, y el lector al que apunta («C# básico») queda sin la categoría a la que pertenecen los tres. **Dirección:** las tres filas de glosario y las dos viñetas propuestas en §1; costo cero en bloques de código. |
| **NET3-03** | §7.4, tabla de l. 2089 | **P1** | **E1** — `dotnet run --project Demo -- json`, casos A, B, C y D: con ctor público sin parámetros y setters privados el serializador **no lanza** (`Nombre = '', Precio = 0`); con `[JsonConstructor]` o con un único ctor con parámetros que coincidan **materializa sin setters** | **La guía afirma algo inexacto sobre serialización.** La fila «Transporte / Setters públicos y constructor sin parámetros, **para que el JSON o el formulario la llenen**» presenta como necesaria una condición que es apenas suficiente: el serializador también llena por constructor —es lo que hace con todo `record` posicional del contrato— y, peor, un constructor sin parámetros **con setters privados** no falla: devuelve el objeto en cero. **Dirección:** reescribir la celda como «Un camino de escritura que el serializador alcance: setters públicos, **o** un constructor cuyos parámetros se llamen como las propiedades (es lo que da un `record` posicional)», y agregar la advertencia medida: cerrar los setters sin cerrar el constructor no protege nada, hace que el dato llegue vacío. |
| **NET3-04** | §5.4 (nueva fila y tres renglones) | **P1** | **E1** — `dotnet run --project Demo -- dapper`, casos A, B, C2 y D (salidas en §2.2) | **Dapper, medido: materializa la Entity de §3.3 sin abrirle nada** (usa el constructor privado, escribe los setters privados, 1 llamada), **exige nombre y tipo de columna** si el único constructor lleva parámetros (`A parameterless default constructor or one matching signature (System.String Nombre, System.Double Precio) is required …`) y, si la columna no se llama como la propiedad, **deja el valor por omisión sin avisar** (`Nombre = '', Precio = 0 (no lanzó)`). **Dirección:** tres renglones en §5.4 con esas tres afirmaciones y sus salidas, y la regla que se deriva: con un micro-ORM la correspondencia nombre-columna es parte del contrato del `SELECT`, y un alias mal escrito es un dato perdido, no un error. |
| **NET3-05** | §5.4, §5.5 (l. 1714), §7.4 (l. 2127) | **P2** | **E1** — caso E: `en memoria = 9999, en la base = 3500 (nadie confirmó nada: no hay Unit of Work)`; caso A0: `DataException: Error parsing column 0 (Id=… - String)` | **Lo que define al micro-ORM y la guía no dice.** Sin seguimiento de cambios no hay `SaveChanges` que valga: modificar el objeto no cambia nada y la escritura es otro `INSERT`/`UPDATE` escrito a mano; sin conversores por convención, `Guid` contra una columna `TEXT` **falla en ejecución**. Consecuencia arquitectónica, que es lo que le importa a esta guía: la respuesta de §5.5 —«`DbSet` ya es un *Repository*», Microsoft (2018)— **está atada a EF Core**; con Dapper el Repository propio y la Unit of Work vuelven a ser código que alguien escribe. **Dirección:** media línea en §5.5 acotando la afirmación a EF Core, y el contraste en la fila de Dapper de la tabla nueva. |
| **NET3-06** | §6.3 (l. 1852–1860), §5.1 | **P2** | **E1** — caso D (`Un único constructor público con parámetros que coinciden → Nombre = 'Mate', Precio = 3500`) y `ProductoResponse` es `public record ProductoResponse(Guid Id, string Nombre, decimal Precio);` (l. 1472) | **El tercer materializador ya está compilado en la guía y nadie lo nombra.** `GetFromJsonAsync<List<ProductoResponse>>` del cliente de consola (L22, capturado) es `System.Text.Json` materializando un `record` posicional **por su constructor**: exactamente el caso D medido. **Dirección:** una frase en §6.3 que lo nombre y remita a §5.4 («lo que EF Core hace con la fila, el serializador lo hace con el JSON, y acá por constructor»). Cierra el tema sin gastar bloque: el código ya está y ya tiene captura. |
| **NET3-07** | §7.2 d, §7.4 | **P2** | **E1** — caso F: `{"Nombre":"Mate","Precio":3500,"Creado":"2026-09-21","PrecioConIva":4235.00}` | **Al salir, el serializador no respeta el cierre de la clase.** Un setter privado o una propiedad de sólo lectura no impiden que el dato viaje, y las propiedades **calculadas** también se publican. Es el argumento medido a favor de lo que §7.2 d ya sostiene («los campos prometidos y ninguno más»): devolver la Entity directamente publica todo lo público, incluido lo que nadie prometió. **Dirección:** media línea en §7.2 d con esta salida como refuerzo; no cambia ninguna afirmación, la respalda. Revisado además §6.3 y §5.4: **no se encontró ninguna otra afirmación inexacta** sobre materializadores; lo que §5.4 dice de EF Core coincide con V05/V07 y con la cita de Microsoft (2026m). |
| **NET3-08** | §5.4, Anexo C, `Variantes/` | **P3** | **E1** — `dotnet list Demo package` → `Dapper 2.1.86`; `dapper.nuspec` → `<license type="expression">Apache-2.0</license>` | **Costo de compilar lo medido.** Si la mesa decide que los snippets nuevos sean **[Compilado]** y no ilustrativos, hace falta el escenario `materializadores` en `Variantes/FabricaYResultado/`: un archivo `Domain/Productos/ProductosDeMaterializacion.cs` (6 clases de contraste, ~60 líneas), dos escenarios nuevos en `Demo/Program.cs` (~70 líneas), `PackageReference Dapper 2.1.86` en el `.csproj` del Demo, tres líneas en `variantes.sh` y tres capturas `V09-dapper.txt`, `V09-dapper-sin-conversor.txt`, `V09-serializador.txt`. **Costo real que la mesa debe pesar:** mete el **primer paquete de terceros** en un árbol que hoy es sólo Microsoft, y obliga a sumar una fila a Anexo C (Dapper 2.1.86, Apache-2.0, `dapperlib.dev`) con su fecha de verificación. **No se construyó**: queda a la decisión de la mesa. Todo el banco está corrido y las capturas ya existen en el scratchpad, listas para trasplantar. |

---

## 4. Los snippets: propuesta dentro del presupuesto

Presupuesto del ciclo 3: **≤ 2 bloques nuevos en toda la guía**. Recomendación: **gastar uno solo, y dejar el segundo en reserva** para lo que decida la mesa de los otros informes.

### Bloque 1 — recomendado, obligatorio para el pedido del PO (§5.4, pegado a la tabla nueva)

Un solo bloque con los cuatro usos lado a lado es mejor que dos sueltos: es exactamente «la idea visual respecto a esa tabla» que el PO pide, cada línea es una fila de la tabla y se lee de arriba abajo como el recorrido de un mismo `Producto`.

```csharp
var p  = Producto.Create("Mate", 3500m);                          // constitución: valida y es el único camino
var ef = await db.Productos.SingleAsync(x => x.Id == p.Id);       // EF Core: ctor privado + escribe los setters privados
var dp = cn.Query<Producto>("select Id, Nombre, Precio from Productos").Single();  // Dapper: igual, si las columnas coinciden
var js = JsonSerializer.Deserialize<Producto>(json);              // serializador: NotSupportedException (no hay ctor que alcance)
```

Cuatro líneas, cuatro materializadores, y la única que falla es la que la guía necesita que falle: la Entity **no** es lo que viaja por HTTP (§7.4). De dónde sale cada una: la 1.ª y la 2.ª, de código ya compilado (`Variantes/FabricaYResultado`, V05); la 3.ª y la 4.ª, del banco medido en este informe. Si la mesa las quiere **[Compilado]**, es NET3-08; si acepta **[Fragmento ilustrativo]**, el bloque entra con costo cero y las salidas citadas como V09.

### Bloque 2 — en reserva, a usar sólo si la mesa quiere el ❌ medido (§7.4, junto a la tabla de l. 2089)

```csharp
// Setters cerrados y constructor sin parámetros: el serializador NO lanza; devuelve el objeto en cero.
var p = JsonSerializer.Deserialize<ProductoConSettersPrivados>("""{"Nombre":"Mate","Precio":3500}""")!;
Console.WriteLine($"'{p.Nombre}' / {p.Precio}");   // → '' / 0
```

Es el hallazgo con más filo pedagógico (NET3-03) y el único que un lector no adivina. Si el presupuesto se gasta en otra comisión, la misma información entra como prosa con la salida citada, sin bloque.

---

## 5. Fuentes y comandos

**Guía revisada.** `/home/fernando/workspaces/workspace-dev/LAB/Lab-Documentos/Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md`, v2.2.0, `last_review: 2026-09-20`. Secciones leídas: §3.1, §3.3, §3.4, §5.1, §5.4, §5.5, §6.1, §6.3, §7.2, §7.4, Anexo C, Anexo D.

**Evidencia reutilizada (no se volvió a medir).** `Examples/Dot-NET-Arquitectura-Lab/Variantes/capturas/V05-ciclo-efcore.txt` y `V07-sin-ctor-privado.txt`, misma imagen y mismo SDK que esta corrida.

**Banco propio.** Fuera del repo, en el scratchpad de la sesión: `…/scratchpad/mat/` (`Demo/Entidades.cs`, `Demo/Program.cs`, `Demo/Demo.csproj`, `global.json`, `captura.sh`, `capturas/`). Entidad bajo prueba: copia fiel del patrón de §3.3 (`private Producto()`, `{ get; private set; }`, `static Create` que valida) más cinco variantes de contraste. Base SQLite en memoria con una fila.

Comandos, todos dentro del contenedor:

```bash
docker run --rm --user "$(id -u):$(id -g)" -v "$PWD":/mat -w /mat \
  mcr.microsoft.com/dotnet/sdk:10.0 bash -c 'dotnet build Demo && dotnet list Demo package'
docker run --rm --user "$(id -u):$(id -g)" -e IMAGEN=… -e DIGEST=… -v "$PWD":/mat -w /mat \
  mcr.microsoft.com/dotnet/sdk:10.0 bash /mat/captura.sh
#   → capturas/V09-paquetes.txt, V09-dapper.txt, V09-dapper-sin-conversor.txt, V09-serializador.txt
docker run --rm … bash -c 'dotnet restore Demo --packages /tmp/pk; grep -o "<license[^>]*>[^<]*</license>" /tmp/pk/dapper/2.1.86/dapper.nuspec'
#   → <license type="expression">Apache-2.0</license>
```

Las capturas llevan el mismo encabezado que las del laboratorio (id, fecha UTC, imagen, digest, SDK, directorio, comando, código de salida), para que se trasplanten sin retocar si la mesa aprueba NET3-08.

**Limpieza.** `find /mat -name bin -o -name obj | xargs -r rm -rf` ejecutado dentro del contenedor al final de cada corrida; los paquetes NuGet se restauraron en `$HOME` del contenedor (efímero) y en `/tmp/pk`. No quedan artefactos de compilación ni archivos de propiedad de root, ni dentro ni fuera del repo. **No se escribió nada en el repo de la guía.**

**Documentación citable para la redacción.** Microsoft, *Entity types with constructors* (ya citada como Microsoft, 2026m); `System.Text.Json`, *Immutable types and records* / `JsonConstructorAttribute`; Dapper, `dapperlib.dev`, Apache-2.0. Las tres harían falta en Anexo E si los snippets entran como [Compilado].

---

## 6. Anexo — construcción del escenario (E-12 y E-13 aprobados, 2026-09-21)

Aprobados NET3-08 y la adopción de Dapper, el escenario se construyó dentro del laboratorio y la medición del §2 se trasplantó como captura versionada **V09**. Alcance respetado: sólo `Variantes/FabricaYResultado/`, `Variantes/capturas/` y la línea de `variantes.sh` que produce la captura nueva. Sin git, sin `bin/`, sin `obj/`, sin archivos de root.

### 6.1 Archivos nuevos y modificados

| Archivo | Estado | Qué lleva |
| --- | --- | --- |
| `Variantes/FabricaYResultado/Domain/Productos/ProductosDeMaterializacion.cs` | **nuevo**, 81 líneas | Siete clases de contraste (`ProductoConCtorDeNombres`, `ProductoConCtorDeNombresYTipos`, `ProductoConSettersPrivados`, `ProductoConJsonConstructor`, `ProductoResponse`, `ProductoDeContrato`, `ProductoDeSalida`); las cinco primeras rotuladas como lo que **no** hay que escribir, y `ProductoResponse`/`ProductoDeContrato` como el caso que **sí** |
| `Variantes/FabricaYResultado/Demo/Program.cs` | modificado, 272 → 405 líneas | Escenario `materializadores` (l. 224–340), auxiliar `Intentar` (l. 364–375) y el `TypeHandler` `GuidDesdeTexto` (l. 399–405); dos `using` nuevos y una línea de `case` |
| `Variantes/FabricaYResultado/Demo/FabricaYResultado.Demo.csproj` | modificado | `<PackageReference Include="Dapper" Version="2.1.86" />` con la licencia en el comentario |
| `Variantes/capturas/V09-materializadores.txt` | **nuevo**, 47 líneas | La captura, con el encabezado del laboratorio |
| `Variantes/variantes.sh` | modificado, +1 línea | `cap V09 materializadores "dotnet run --no-build --project FabricaYResultado/Demo -- materializadores"` |

La Entity bajo prueba **no se tocó**: `ProductoQueDevuelve` sigue igual, y el escenario empieza sobre la fila que EF Core escribió con su Factory Function. `ProductoSinCtorPrivado`, la entidad de contraste de V07, se reutiliza para el caso del serializador con parámetros que no coinciden.

### 6.2 Compilación y no regresión

`dotnet build` en Debug y en Release: **0 advertencias, 0 errores**. Con `-p:AnalysisMode=All -p:EnforceCodeStyleInBuild=true`, `CA1806/IDE0058 = 0`, que es lo que V04 registra y lo que §3.8 cita.

Se regeneraron todas las capturas y se compararon con las versionadas: **V03, V05, V07 y V08 son idénticas** salvo la línea `# fecha` (se conservan las regeneradas, que documentan la reverificación con Dapper en el árbol). **V01, V02, V04 y V06** se restauraron a su versión anterior porque sus únicas diferencias eran tiempos de restauración y de compilación —y, en V06, los milisegundos de la medición de costo y **dos números de línea del stack trace** (`Program.cs:line 112 → 115` y `16 → 18`, por los dos `using` y el `case` nuevos)—. **Aviso al editor:** §3.8 y el Anexo de capturas citan los números exactos de V06 (`4.357,0 ms`, `30,6 ms`, `142x`, `765,3`, `824,9`); si alguna vez se regenera V06, esos cinco números cambian y hay que actualizarlos en la guía. Hoy la captura versionada de V06 conserva los números que la guía cita, a costa de dos números de línea de su stack trace que quedaron desfasados.

### 6.3 Qué línea de V09 demuestra cada punto

| Punto | Línea de `V09-materializadores.txt` |
| --- | --- |
| EF Core materializa la Entity (remite a V05, no se repite) | l. 10 |
| Dapper no convierte por convención: `Guid` contra columna `TEXT` | l. 12 |
| Dapper materializa la Entity **tal cual**, con el ctor privado y escribiendo los setters privados | l. 14–16 (l. 15: una sola llamada al constructor) |
| Dapper exige nombre **y tipo** cuando el único constructor lleva parámetros | l. 18 (mensaje exacto) |
| …y lo usa cuando ambos coinciden | l. 20–21 |
| Falla silenciosa: la columna no coincide, valor por omisión, sin aviso | l. 23 |
| Sin seguimiento de cambios ni Unit of Work | l. 25–26 |
| Serializador: ctor privado → `NotSupportedException` | l. 31 (mensaje exacto) |
| Serializador: ctor público sin parámetros + setters privados → **no lanza, objeto en cero** | l. 33–34 |
| Serializador: `[JsonConstructor]` materializa sin tocar setters | l. 36 |
| Serializador: parámetros que no coinciden → `InvalidOperationException` | l. 38 |
| Serializador, **caso positivo**: único ctor público con parámetros que coinciden (`record` posicional del contrato y la misma forma como clase de sólo lectura) → materializa por el constructor, con `setters públicos … = 0` | l. 39–42 |
| Al salir: publica sólo lectura y calculadas (y el `enum` como número, que enlaza con V08) | l. 43–45 |

### 6.4 Bloques citables

| Anclaje | Qué muestra |
| --- | --- |
| `[Compilado: Variantes/FabricaYResultado/Demo/Program.cs, l. 258–265]` | Dapper materializando la Entity de §3.3 y contando el constructor privado |
| `[Compilado: Variantes/FabricaYResultado/Demo/Program.cs, l. 307–312]` | El ❌ del serializador: no lanza y devuelve el objeto en cero (bloque 2 del presupuesto, §7.4) |
| `[Compilado: Variantes/FabricaYResultado/Domain/Productos/ProductosDeMaterializacion.cs, l. 33–40]` | La clase «cerrada a medias» que produce ese ❌ |

**El bloque de cuatro líneas lado a lado (§5.4)**, que es el que tiene presupuesto, es una **composición**: cada línea existe compilada, pero en cuatro lugares distintos del mismo programa. Se propone rotularlo `[Compilado: Variantes/FabricaYResultado/Demo/Program.cs, l. 45, 62, 261 y 303 — las cuatro líneas, reunidas]`:

```csharp
var alta   = ProductoQueDevuelve.Create("Mate", 3500m, "ARS");                       // l. 45  — constitución: valida
var deEf   = await db.Productos.AsNoTracking().SingleAsync(p => p.Id == id);         // l. 62  — EF Core: ctor privado + setters privados (V05)
var deSql  = conexion.Query<ProductoQueDevuelve>("SELECT Id, Nombre, Precio FROM Productos").Single();  // l. 261 — Dapper: lo mismo, si las columnas coinciden (V09 l. 14)
var deJson = JsonSerializer.Deserialize<ProductoQueDevuelve>(json);                  // l. 303 — serializador: NotSupportedException (V09 l. 31)
```

### 6.5 Reposición del caso positivo (dictamen Fowler ciclo 3, punto 2)

El caso positivo del serializador —único constructor público con parámetros que coinciden con las propiedades, que es lo que da un `record` posicional— se midió en el banco pero no había quedado en V09, y §5.4 y §7.4 lo afirman como prosa. Se repuso como **caso 2.e** y V09 se regeneró completa. La medición: `record posicional: Id = 11111111-…, Nombre = 'Mate', Precio = 3500`, la misma forma escrita como clase de propiedades de sólo lectura da lo mismo, y `setters públicos que el serializador pudiera usar = 0`, que es la prueba de que materializó por el constructor y no hubo setter que tocar.

**Correspondencia de líneas, vieja → nueva.** El caso nuevo se insertó antes del último, así que **nada de lo ya citado se corrió salvo el bloque final**:

| Cita | Antes | Ahora |
| --- | --- | --- |
| V09 l. 14–16, 18, 20–21, 23, 25–26, 31, 33–34, 36, 38 | — | **sin cambios** |
| V09, «al salir» | l. 39–41 | **l. 43–45** |
| V09, caso positivo | (no existía) | **l. 39–42** |
| `[Compilado: Program.cs, l. 45, 62, 261 y 303]` | — | **sin cambios** |
| `[Compilado: Program.cs, l. 307–312]` (y l. 309, 311) | — | **sin cambios** |
| `[Compilado: ProductosDeMaterializacion.cs, l. 33–40]` | — | **sin cambios** |
| Bloque citable del caso positivo | (no existía) | `[Compilado: Demo/Program.cs, l. 326–334]`; las clases, en `ProductosDeMaterializacion.cs`, l. 61 (`ProductoResponse`) y l. 63–71 (`ProductoDeContrato`) |

Reverificación: Debug y Release **0 advertencias**; `CA1806/IDE0058 = 0`; **V05, V07 y V08 idénticas** a sus capturas versionadas (salvo `# fecha`). **V06 no se regeneró**, como se pidió; corrida al margen sólo para control, su texto es idéntico y difieren únicamente los milisegundos y los dos números de línea del stack trace (`112 → 115`, `16 → 18`).

### 6.6 V06 repuesta (decisión F-10 del ciclo 4, 2026-09-21)

Se cortó la deuda: `capturas/V06-rechazos.txt` se regeneró con el estado actual del escenario, mismo encabezado, `ulimit -c 0`, misma imagen y mismo SDK. Los números que §3.8 cita cambian, y son los de una medición: varían en cada corrida.

| Lo que cita §3.8 | Antes | **Ahora** | Línea de V06 |
| --- | --- | --- | --- |
| Vía de excepción | `4,357.0 ms` / `296.0 bytes` | **`4,559.2 ms`** / **`296.0 bytes`** (sin cambio) | l. 19 |
| Vía de resultado | `30.6 ms` / `0.0 bytes` | **`30.8 ms`** / **`0.0 bytes`** (sin cambio) | l. 20 |
| Factor | `142x` | **`148x`** | l. 21 |
| Altas válidas, por excepción | `765,3 ms` | **`764.2 ms`** | l. 22 |
| Altas válidas, por resultado | `824,9 ms` | **`848.1 ms`** | l. 22 |

**El factor no cambia de orden de magnitud** (142x → 148x, ambos ~10²), así que el argumento de §3.8 se sostiene sin retocar su razonamiento. Dos números derivados que el editor también tiene que mirar: §3.8 dice «4,3 µs no deciden nada», que con la medición nueva es **4,6 µs** (`4.559,2 ms / 10⁶`); y el Anexo de capturas repite `4.357,0 ms/296,0 B contra 30,6 ms/0,0 B`, que pasa a **`4.559,2 ms/296,0 B contra 30,8 ms/0,0 B`**. El stack trace queda por fin al día: `Program.cs:line 115` y `line 18` (l. 30–31).

Verificación de esta corrida: Debug y Release **0 advertencias**; V01, V02, V03, V05, V07 y V08 idénticas salvo `# fecha`; V09 idéntica salvo los dos `Guid` que el programa genera al azar (l. 12 y l. 44), que es la misma variación que la guía ya advierte para L22. Las tres capturas de compilación (V01-build, V02-build, V04-build) no se volvieron a correr: sólo difieren en tiempos.

### 6.7 Fila del Anexo C, redactada

| Componente | Dato | Fuente |
| --- | --- | --- |
| Dapper | 2.1.86, Apache-2.0 (expresión de licencia declarada en el `.nuspec` del paquete); micro-ORM, único paquete de terceros del laboratorio; se usa en la variante `materializadores` (V09) | [Dapper, 2026](#ref-dapper-2026) (`dapperlib.dev`); `dapper.nuspec` 2.1.86; V09 |
