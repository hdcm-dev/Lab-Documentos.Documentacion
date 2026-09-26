# Informe de la comisión Especialista .NET / C# — Ciclo 1

**Fecha:** 2026-09-19
**Comisión:** Especialista .NET / C# (C# 13, .NET 10, ASP.NET Core, EF Core 10, xUnit). Trabajo a ciegas: no se leyó ningún otro informe de `Ciclo-1/`.
**Objeto:** `LAB/Lab-Documentos/Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md` @ `dbdf9dd` (v2.0.2, 2126 líneas; `git log --oneline -1` → `dbdf9dd Merge pull request #7 …`).
**Competencia:** NE-05 (que cada `[Compilado]` coincida con su archivo y compile con SDK 10.0.400 sin advertencias; que los `[Fragmento ilustrativo]` sean C# válido y coherente) y NE-01 en su cara técnica (qué snippet mínimo, derivado de qué archivo existente, materializa cada definición de §1.1, §3.1, §4.1, §5.1 y §6.1). Errores o imprecisiones sobre EF Core, DI, ASP.NET Core, records, constructores, nullable.
**No-competencia:** fidelidad histórica de los patrones a sus autores, forma editorial, pedagogía. Lo que apareció de eso va en «Solicitudes de convocatoria», no como hallazgo.

**Medios usados (E1):** imagen `mcr.microsoft.com/dotnet/sdk:10.0` con digest `sha256:e1ffd2a9…87a64c` (el mismo que declara la guía en `sdk_validado`), `dotnet --version` → `10.0.400`. El laboratorio se copió al scratchpad de la sesión y se compiló ahí; no se tocó el repo. Programas de comprobación (`Chk1`–`Chk4`) escritos por la comisión, compilados y ejecutados en la misma imagen; su salida se cita textual. Rutas del laboratorio relativas a `LAB/Lab-Documentos/Guides/Dot-NET-Arquitectura-Guide/Examples/Dot-NET-Arquitectura-Lab/`.

---

## Hallazgos

Orden: P1 → P2 → P3. No hay P0: nada de lo revisado falsea el objetivo del pedido ni bloquea la reedición.

### NET-01 · P1 · Los *lifetimes* del contenedor se usan sin definirse y el composition root nunca se muestra

- **Sección:** §2.1 (definición de composition root, l. 251), §2.2 Paso 2 (l. 384–385), §5.2 (l. 1167), §5.3 (l. 1225).
- **Ancla E1:** `grep -n -i "Scoped\|Singleton\|Transient\|ciclo de vida\|tiempo de vida\|lifetime" Dot-NET-Arquitectura-Guide.md` devuelve cuatro líneas (384, 385, 400, 1167, 1834) y **ninguna define** qué significan `AddSingleton`, `AddTransient` ni `AddScoped`. Ninguna sección «Definiciones» ni el glosario (Anexo D) tiene la entrada.
- **Ancla E1 (el dato que falta es decisivo):** `lab.sh` l. 543 registra `builder.Services.AddSingleton<IProductoRepository, InMemoryProductoRepository>();`. §5.2 (l. 1167) dice que `Program.cs` «registra `InMemoryProductoRepository` … como implementación de `IProductoRepository`, y los tres handlers … con `AddScoped`», sin decir que el Repository en memoria es **Singleton**. Si fuera Scoped, cada petición recibiría un diccionario nuevo y el `GET` de L15 devolvería `[]`: el lector que reproduzca «a mano» con `AddScoped` no obtiene la captura.
- **Ancla E4:** §0.5, fila «Tipo nombrado sin código»: «el archivo completo está en `Examples/Dot-NET-Arquitectura-Lab/MyProject/`». `InMemoryProductoRepository` y el `Program.cs` de L13 **no existen en `MyProject/`**: viven sólo dentro de un heredoc de `lab.sh` (l. 451–476 y 530–556). La regla de §0.5 no los cubre.
- **Ancla E2:** §2.1, l. 251: «**Composition root.** El único lugar del programa que conoce todas las piezas … En esta guía es `Program.cs` de la WebAPI». `Program.cs` se nombra 13 veces (`grep -c "Program.cs"` → 13) y su código no aparece en ningún bloque; `MyProject/src/Backend/MyProject.WebAPI/Program.cs` tiene 33 líneas.
- **Impacto:** el concepto central de §2 (composition root) y una decisión que determina el resultado observable (Singleton vs Scoped) quedan en alegoría; el lector no puede asociar «registrar» con una línea concreta.
- **Dirección:** (1) mostrar `Program.cs` final como `[Compilado: MyProject/src/Backend/MyProject.WebAPI/Program.cs]` en §5.3 o §5.6 (es la versión que compiló en L21), con comentarios en línea «composition root», «middleware», «OpenAPI»; (2) agregar a §2.1 o §5.1 una definición de *lifetime* con una tabla de tres filas (Singleton / Scoped / Transient: quién y cuántas veces) atada a las líneas reales: `AddSingleton` para el Repository en memoria (el dato debe sobrevivir a la petición), `AddDbContext` → Scoped por defecto (una sesión por petición), handlers `AddScoped`; (3) para L13, o bien mover `InMemoryProductoRepository` y `Program.memoria.cs` a una carpeta publicada (p. ej. `Examples/…/Etapas/L13/`), o bien decir en §0.5 que los archivos intermedios están en `lab.sh` con el número de línea.

### NET-02 · P1 · «¿Se puede … comparar por valor? Sí: es un `record`» es falso para el Command del §4.10

- **Sección:** §4.3, tabla «Prueba rápida», l. 851; §4.10, l. 1074 (`RegistrarPedidoCommand(IReadOnlyList<RegistrarPedidoItem> Items)`).
- **Ancla E1:** `Chk1/Program.cs`, compilado con 0 advertencias y ejecutado en la imagen:
  ```text
  1. Command escalar igual: True
  1. Command con lista igual: False
  1. Item igual: True
  ```
  Dos `RegistrarPedidoCommand` con ítems iguales **no son iguales**: la igualdad sintetizada de un `record` llama a `EqualityComparer<T>.Default` sobre cada miembro, y para `IReadOnlyList<T>` eso es igualdad de referencia.
- **Ancla E2:** §4.3, l. 851: «| ¿Se puede serializar, registrar en un log o comparar por valor? | Sí: es un `record` de datos | No: es un servicio |». La fila se aplica sin matiz a todo Command, y el único Command con colección de la guía la incumple.
- **Impacto:** afirmación sobre C# sin respaldo que el lector va a comprobar con `==` en una prueba y ver fallar; además, la definición de *Value Object* (§3.1) descansa en la misma idea de «`record` = igualdad por datos».
- **Dirección:** matizar la fila («por valor en sus miembros escalares y `string`; una colección se compara por referencia») y, si se quiere igualdad estructural, mostrar en 3 líneas la salida idiomática (`ImmutableArray<T>`/`SequenceEqual` en un `Equals` propio) o declarar que no hace falta porque el Command no se compara. La corrección también toca §3.1 («un tipo cuya igualdad compara datos»): agregar «miembro a miembro».

### NET-03 · P1 · `ProductoRepository` —el archivo del que trata §5.5— no se muestra, y su `AsNoTracking()` contradice el patrón *Unit of Work* que la guía enseña después

- **Sección:** §5.5 (l. 1258–1272), §4.10 (l. 1078–1093 y 1115), §9.6 paso 7 (l. 1857–1866).
- **Ancla E1:** `MyProject/src/Backend/MyProject.Infrastructure/Persistence/Repositories/ProductoRepository.cs` (23 líneas) no aparece en ningún `[Compilado]`; §5.5 lo describe en prosa (l. 1262: «L18 reemplaza en el Repository la llamada a `SaveChangesAsync`…») y L18 lo edita con `sed` (`lab.sh` l. 720). Sus lecturas usan `_db.Productos.AsNoTracking()` (l. 12 y 15 del archivo).
- **Ancla E1:** `Chk4/Program.cs` (misma imagen, 0 advertencias):
  ```text
  AsNoTracking + cambio + SaveChangesAsync -> filas afectadas: 0
  Con seguimiento + cambio + SaveChangesAsync -> filas afectadas: 1
  ```
- **Ancla E3:** el patrón que la guía instala en §4.10 y §9.6 paso 7 es «`GetByIdAsync` → mutar la *Entity* → `SaveChangesAsync` en el Handler como *Unit of Work*». Si un lector implementa `IPedidoRepository`/`IProductoRepository` copiando `ProductoRepository` (que es el único Repository EF Core del corpus), un futuro `DesactivarProductoHandler` que haga `GetByIdAsync` + `producto.Desactivar()` + `SaveChangesAsync` devuelve 201/204 y **no persiste nada**, exactamente el síntoma de L18 pero sin la explicación de L18.
- **Impacto:** el concepto *Unit of Work* (§5.1, §4.10, glosario) queda materializado sólo con un doble en memoria (`UnitOfWorkContador`) y nunca con el `DbContext` real; y el único código EF Core de escritura del laboratorio no se ve.
- **Dirección:** mostrar `ProductoRepository` como `[Compilado]` en §5.5 (las dos líneas de `AddAsync` ya tienen los comentarios «marca» / «confirma»); agregar una frase sobre `AsNoTracking()`: correcto para *Queries* (§4.1, modelo de lectura), incorrecto para un *Use Case* que carga, modifica y guarda, donde la *Entity* tiene que estar rastreada. Si se agrega la tercera variante (NET-09) o se extiende `Variantes/Pedidos/` a Infrastructure, `AppDbContext : DbContext, IUnitOfWork` sería el snippet compilado del *Unit of Work* real (ver «Lo que revisé y está bien», ítem 2).

### NET-04 · P1 · Las cinco secciones «Definiciones» tienen archivo para casi todo; falta la asociación, no el código

- **Sección:** §1.1 (l. 123–131), §3.1 (l. 502–515), §4.1 (l. 747–756), §5.1 (l. 1127–1140), §6.1 (l. 1323–1330).
- **Ancla E1:** `01-Base-Mecanica.md` §2: 49 viñetas, cero bloques de código en las cinco secciones. Comprobado: 12 de los 13 `[Compilado]` de la guía coinciden línea a línea con su archivo (script de la comisión: `missing(stripped)=0` en los 12); el material compilado existe, está en otra sección o en un archivo nunca citado.
- **Impacto:** es la pregunta Q1 del contrato. Sin la asociación, la definición queda en prosa aunque el código exista a cinco líneas de distancia.
- **Dirección (qué snippet, de qué archivo, 3–8 líneas):** todos derivables de archivos existentes; ninguno requiere código nuevo salvo los de §6.1 (NET-09).

  | Definición | Archivo (ruta exacta) | Líneas a extraer |
  |---|---|---|
  | §1.1 Proyecto, Referencia de proyecto, Paquete NuGet | `MyProject/src/Backend/MyProject.Infrastructure/MyProject.Infrastructure.csproj` | los dos `<ProjectReference>` y el `<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="10.0.12" />` (5 líneas XML; marcar como `[Compilado]`: es el archivo que compiló) |
  | §1.1 Solución `.slnx` | `MyProject/MyProject.slnx` | `<Folder Name="/src/Backend/">` con sus cuatro `<Project Path=…/>` |
  | §1.1 Espacio de nombres ≠ dependencia | `MyProject/src/Backend/MyProject.Domain/Productos/Producto.cs` l. 3 + `MyProject.Domain.csproj` completo (sin `<ProjectReference>`) | 1 + 7 líneas: el namespace tiene tres segmentos y el proyecto no referencia nada |
  | §1.1 SDK / `global.json` | `MyProject/global.json` | las 6 líneas |
  | §3.1 Entity (identidad + comportamiento) | `…/MyProject.Domain/Productos/Producto.cs` | `public Guid Id { get; private set; }` y `public void Desactivar() => Activo = false;` |
  | §3.1 Business Rule / Invariant | ídem | las dos líneas `if (precio <= 0) throw new DomainException(…)` |
  | §3.1 Precondition | `Variantes/ProductoSinPrecio/Domain/Productos/Producto.cs` | `PrecioDeVenta()` (2 líneas) |
  | §3.1 Postcondition | `MyProject/tests/Backend/MyProject.Domain.Tests/ProductoTests.cs` | `Create_con_datos_validos_devuelve_un_producto_activo` (5 líneas): la *Postcondition* de `Create` («el producto queda activo») está materializada como prueba, y es el único lugar del corpus donde lo está |
  | §3.1 Factory Method | `Producto.cs` | `private Producto() { }` + firma `public static Producto Create(string nombre, decimal precio)` |
  | §3.1 Value Object | `…/MyProject.Domain/Common/Dinero.cs` + `ProductoTests.cs` | la declaración `public record Dinero(decimal Monto, string Moneda)` + la prueba `Dos_Dinero_con_los_mismos_datos_son_iguales` (2 líneas) |
  | §3.1 Excepción de dominio | `…/MyProject.Domain/Common/DomainException.cs` | las 4 líneas; hoy es «tipo nombrado sin código» |
  | §3.1 Setter privado, `Guid` | `Producto.cs` | `public decimal Precio { get; private set; }`; `Id = Guid.NewGuid()` |
  | §3.1 `CancellationToken` | `…/MyProject.Domain/Productos/IProductoRepository.cs` l. 6 + `…/MyProject.WebAPI/Controllers/ProductosController.cs` l. 31–34 | la firma con `ct = default` y el `ct` que el controller recibe del framework y pasa al handler: es el recorrido completo del token, hoy invisible |
  | §4.1 Use Case, Command, Handler | ya en §4.5 | remitir con ancla; no repetir |
  | §4.1 Query | `…/MyProject.Application/Productos/Queries/ObtenerProductoPorId/ObtenerProductoPorIdQuery.cs` y `…/ObtenerProductos/ObtenerProductosQuery.cs` | `public record ObtenerProductoPorIdQuery(Guid Id);` y `public record ObtenerProductosQuery;` (una línea cada una; la segunda muestra el `record` sin parámetros, que compila) |
  | §4.1 Modelo de lectura | `…/MyProject.Application/Productos/ProductoDto.cs` | `record ProductoDto(…)` + `From` (4 líneas): «copia campo a campo, escrita a mano» hoy no se ve |
  | §4.1 Repository (doble) | `MyProject/tests/Backend/MyProject.Application.Tests/FakeProductoRepository.cs` | `Guardados` + `AddAsync` (5 líneas) |
  | §4.1 Aggregate / Aggregate Root | `Variantes/Pedidos/Domain/Pedidos/Pedido.cs` l. 9, 14 + `ItemPedido.cs` l. 13–14 | `private readonly List<ItemPedido> _items`, `IReadOnlyList<ItemPedido> Items => _items`, y el constructor `internal`: las tres líneas que hacen raíz al `Pedido` |
  | §4.1 Interfaz de servicio técnico | `Variantes/Pedidos/Application/Common/IUnitOfWork.cs` | las 3 líneas (ver NET-08) |
  | §4.1 `async`/`await`/`Task` | `CrearProductoHandler.cs` | ya en §4.5; anclar la línea `await _repository.AddAsync(producto, ct);` |
  | §5.1 DTO / Contrato | `MyProject/src/Contracts/MyProject.Contracts/CrearProductoRequest.cs`, `ProductoResponse.cs` | una línea cada uno; hoy sólo se nombran |
  | §5.1 Middleware, OpenAPI, ProblemDetails | `…/MyProject.WebAPI/Program.cs` | `app.UseExceptionHandler();`, `builder.Services.AddOpenApi(); … app.MapOpenApi();`, `AddProblemDetails()` (NET-01) |
  | §5.1 EF Core / `DbContext` | `…/MyProject.Infrastructure/Persistence/AppDbContext.cs` | `DbSet<Producto> Productos => Set<Producto>();` + `ApplyConfigurationsFromAssembly` (3 líneas) |
  | §5.1 Unit of Work | `…/Persistence/Repositories/ProductoRepository.cs` l. 17–21 | `Add` + `SaveChangesAsync` (NET-03) |
  | §5.1 Configuración Fluent API | ya en §5.4 | remitir |
  | §5.1 Registro en el contenedor | `…/MyProject.Infrastructure/DependencyInjection.cs` | `AddDbContext` + `AddScoped<IProductoRepository, ProductoRepository>()` (3 líneas); §5.3 lo describe en prosa |
  | §6.1 Cliente | ya en §6.3 | remitir |
  | §6.1 Blazor, MAUI, RCL, Servicio de API, ViewModel, form model | **sin archivo** | NET-09 |

  Forma de la asociación (sugerencia técnica, no editorial): comentario en línea con el nombre del concepto en el propio archivo (`// Invariant`, como ya hace `Variantes/…/Producto.cs` l. 12 y 24) para que el snippet y el archivo digan lo mismo y el extracto no reescriba nada (§0.5).

### NET-05 · P2 · `[Index]` no obliga a referenciar «el paquete del ORM»: vive en `Microsoft.EntityFrameworkCore.Abstractions`

- **Sección:** §5.4, l. 1256 («`[Index]`, que sí es de EF Core, haría además que `Domain` dependa del paquete del ORM»); §7.4, l. 1603 y 1617 («`[Index]` obliga a referenciar el paquete de EF Core desde el proyecto del dominio, que es la regla de dependencia rota»).
- **Ancla E1:** `Chk1`: `4. IndexAttribute vive en: Microsoft.EntityFrameworkCore.Abstractions`; `[Key]` y `[Table]` viven en `System.ComponentModel.Annotations` (biblioteca base, como dice la guía).
- **Impacto:** el paquete `Abstractions` existe precisamente para que un proyecto de dominio use los atributos de EF Core sin referenciar el ORM; decir «el paquete del ORM» es una imprecisión que un lector con experiencia detecta y que debilita el argumento de §7.4. El argumento de fondo sigue en pie (el dominio adopta vocabulario de almacenamiento), pero hay que decirlo así.
- **Dirección:** reemplazar «el paquete del ORM» por «un paquete de EF Core (`Microsoft.EntityFrameworkCore.Abstractions`)», y reformular la frase de §7.4: la regla de dependencia se rompe porque `Domain` pasa a nombrar un tipo de la familia del ORM, no porque cargue con el ORM entero.

### NET-06 · P2 · §9.6 paso 7: `return persona.Id` con clave `int` vale sólo si `_repository.Add` confirma; con el *Unit of Work* del §4.10 devuelve 0

- **Sección:** §9.6, l. 1830–1832 (paso 1: `public int Id`, «Id existe porque EF Core necesita una clave»), l. 1857–1866 (paso 7), l. 1845–1846 (índice único).
- **Ancla E1:** `Chk3`:
  ```text
  Id después de Add, antes de SaveChanges: 0
  Id después de SaveChanges: 1
  Segunda alta: DbUpdateException -> SqliteException: SQLite Error 19: 'UNIQUE constraint failed: Personas.DNI'.
  ```
- **Ancla E2:** §9.6 l. 1877: «Cuando un *Use Case* toca varias *Entities*, `SaveChanges` sube al handler como *Unit of Work* (§4.10)». En el laboratorio el problema no aparece porque `Producto.Id` es un `Guid` generado por el dominio (§3.1); en §9.6 la clave es `int` generada por la base y el snippet devuelve `persona.Id` sin mostrar dónde está el `SaveChanges`.
- **Impacto:** dos conceptos de EF Core que la guía menciona (clave generada por la base; índice único «como respaldo», §3.6) quedan sin su consecuencia: (a) el `Id` es 0 hasta confirmar; (b) la violación del índice llega como `DbUpdateException`, no como `DomainException`, y con el manejador de §5.6 produce **500**, no 400 (§5.6 l. 1293: «otras excepciones siguen su curso (500)»).
- **Dirección:** en el paso 7, un comentario sobre `_repository.Add(persona);` («confirma con `SaveChanges`; por eso `Id` ya tiene valor»), y una línea en el paso 3 diciendo qué excepción produce el índice y que el `Any` sigue siendo necesario para el mensaje de negocio. Opcional: mencionar `Guid.CreateVersion7()` (.NET 9+; `Chk1` línea 5) como forma de que el dominio genere claves ordenables sin depender de la base.

### NET-07 · P2 · El corpus mezcla dos estilos de constructor sin nombrar el rasgo del lenguaje

- **Sección:** §4.5 (l. 895: `public CrearProductoHandler(IProductoRepository repository) => _repository = repository;`), §4.10 (l. 1096: «`RegistrarPedidoHandler` recibe por constructor…»), Variantes.
- **Ancla E1:** `Variantes/Pedidos/Demo/Program.cs` l. 43: `class ProductosEnMemoria(params Producto[] productos) : IProductoRepository` — *primary constructor* (C# 12) con `params`. `grep -n -i "primario\|primary constructor" Dot-NET-Arquitectura-Guide.md` → vacío.
- **Ancla E4:** contrato de entrada, Q7: «correcto, idiomático (C# 12/13, .NET 10)»; §0.2: «Todo lo demás … se define la primera vez que aparece».
- **Impacto:** el lector que abra el Demo (la guía lo invita: «`Variantes/Pedidos/Demo/Program.cs` lo ejecuta con dobles en memoria») encuentra una sintaxis que la guía no nombra; y la guía nunca dice por qué elige constructores explícitos con campo `readonly` en los handlers.
- **Dirección:** declarar el criterio en §4.3 o §4.5 (una frase: el constructor explícito muestra el campo y la asignación, que es lo que se quiere enseñar) y mostrar en 2 líneas el equivalente con *primary constructor* como `[Fragmento ilustrativo]`, o bien unificar el Demo al estilo clásico. Cualquiera de las dos es válida; lo que no es válido es el silencio.

### NET-08 · P2 · `IEmailService` e `ICurrentUserService` no existen en ningún archivo; el único servicio técnico compilado es `IUnitOfWork`

- **Sección:** §4.1, l. 755; §3.2, l. 543 («`CrearProductoHandler`, a través de `IEmailService` (§4.1)»); §2.7, l. 490.
- **Ancla E1:** `grep -rn "IEmailService\|ICurrentUserService" Examples/` → nada. `grep -n` en la guía → l. 543 y 755. `Variantes/Pedidos/Application/Common/IUnitOfWork.cs` existe, compila (V02) y su comentario de cabecera dice «Interfaz de servicio técnico: la implementa el AppDbContext en Infrastructure».
- **Ancla E4:** §0.5, «Tipo nombrado sin código»: promete que el archivo existe en `MyProject/`. Para estos dos tipos la promesa no se cumple.
- **Impacto:** la definición queda en alegoría y, peor, l. 543 describe a `CrearProductoHandler` usando algo que el handler compilado (§4.5) no recibe.
- **Dirección:** en §4.1 anclar la definición a `IUnitOfWork` (3 líneas, `[Compilado: Variantes/Pedidos/Application/Common/IUnitOfWork.cs]`) y rotular `IEmailService`/`ICurrentUserService` como hipotéticos; corregir l. 543 («a través de un `IEmailService` que este laboratorio no llega a necesitar»).

### NET-09 · P2 · §6.1 no tiene ningún archivo detrás; conviene una tercera variante compilable con el SDK solo

- **Sección:** §6.1 (l. 1323–1330), §6.5, §7.1 (`ProductoListItemViewModel`, `ProductoFormModel`, `ProductoDbModel`), §7.2 e–g.
- **Ancla E1:** de las seis definiciones de §6.1 sólo «Cliente» tiene código (§6.3). `IProductoApiService`, `ProductoListItemViewModel` y `ProductoFormModel` se nombran 9 veces en total y no existen en `Examples/`. `Dinero` (§3.3) tiene un test propio; ningún objeto de §6/§7 lo tiene.
- **Ancla E3 (viabilidad):** un `classlib` `net10.0` compila en la imagen sin cargas de trabajo (los cuatro proyectos de `Variantes/` lo prueban: V01/V02, 0 advertencias). MAUI necesita workloads y no compila ahí; una *Blazor Web App* sí compila con el SDK solo, pero agrega el framework de componentes a la variante.
- **Dirección:** `Variantes/ClienteApi/` con un proyecto `ClienteApi.Cliente` (`classlib`, referencia a `MyProject.Contracts` por `ProjectReference` a `../../MyProject/src/Contracts/…`) que contenga: `IProductoApiService` (2 métodos), `ProductoApiService : IProductoApiService` con `HttpClient` inyectado (materializa «Servicio de API del cliente» y §6.2), `ProductoListItemViewModel` con `PrecioFormateado` (§7.2 e) y su mapeo desde `ProductoResponse`, y `ProductoFormModel` con `{ get; set; }` y `[Required]`/`[Range]` (§7.2 f) más el `ToRequest()` hacia `CrearProductoRequest`; un `Demo` de consola que ejercita el mapeo y la validación con `Validator.TryValidateObject` (sin Blazor). Con eso §6.1, §6.2, §7.2 e y §7.2 f pasan a `[Compilado]`; Blazor, MAUI y RCL siguen como `[Fragmento ilustrativo]` con motivo declarado. Sobre la «tercera variante `Conceptos-Objetos/` con una clase por definición» que plantea NE-05: **no la recomiendo**: §3.1, §4.1 y §5.1 ya tienen archivo para todo (NET-04); duplicar `Producto` en una carpeta didáctica crearía dos verdades.

### NET-10 · P3 · `[FromServices]` es opcional desde ASP.NET Core 7; la guía lo presenta como necesario

- **Sección:** §5.2, l. 1167; §7.4, l. 1592.
- **Ancla E1:** `Chk2` (webapi con `[ApiController]`, servicio `Saludo` registrado con `AddScoped`, imagen SDK 10.0.400): `GET /api/prueba/sin-atributo` → `HTTP/1.1 200 OK` con el texto del servicio; idéntico a `con-atributo`.
- **Ancla E2:** Microsoft, *What's new in ASP.NET Core in .NET 7*, «Parameter binding with DI in API controllers»: «Parameter binding for API controller actions binds parameters through dependency injection when the type is configured as a service. This means it's no longer required to explicitly apply the `[FromServices]` attribute to a parameter» (consultado 2026-09-19; se desactiva con `ApiBehaviorOptions.DisableImplicitFromServicesParameters`).
- **Impacto:** bajo; el atributo explícito es una elección legítima y didáctica. Pero «le indica al controller que ese parámetro no viene de la petición sino del contenedor» sugiere que sin él se enlazaría del cuerpo, y no es así en .NET 10.
- **Dirección:** una frase: «desde ASP.NET Core 7 el atributo se infiere para tipos registrados; la guía lo escribe para que se lea de dónde viene el parámetro». Criterio de esta guía.

### NET-11 · P3 · Dos imprecisiones de EF Core en prosa

- **(a) Sección §3.7, l. 729:** «una columna que admite nulos en `ProductoConfiguration`». EF Core infiere la nulabilidad de la columna del tipo CLR `decimal?`; `ProductoConfiguration` no cambia (sólo si se quisiera forzar `IsRequired(false)`, que es redundante). **Ancla E1:** `Chk1` mapea `decimal` con `HasPrecision(18, 2)` y la columna sale `TEXT`; con `decimal?` la convención produce `TEXT NULL` sin configuración adicional (convención documentada de EF Core: tipos de referencia y `Nullable<T>` → columnas opcionales). **Dirección:** «`decimal?` en la *Entity*, que EF Core traduce solo a una columna opcional».
- **(b) Sección §5.5, l. 1264:** «Se usa `Add` y no `AddAsync`» dentro de un método del Repository que se llama `AddAsync`. La cita de la documentación es correcta (E2: «This method is async only to allow special value generators … For all other cases the non async method should be used», learn.microsoft.com, consultado 2026-09-19), pero el lector ve `AddAsync` en la interfaz (§3.3) y `Add` en la frase sin que nadie diga que son dos métodos de dos tipos. **Dirección:** «`IProductoRepository.AddAsync` se llama así porque espera a `SaveChangesAsync`; adentro usa `DbSet.Add`, no `DbSet.AddAsync`, porque…». Se resuelve solo si se muestra `ProductoRepository` (NET-03).

### NET-12 · P3 · Pulidos de coherencia entre snippet y archivo

- **(a) §2.2 Paso 1, l. 323:** el comentario del snippet dice `// el único lugar que conoce las dos piezas`; el archivo `Conceptos-DI/Paso1/Program.cs` l. 1 dice `// composition root: el único que conoce las dos piezas`. Es `[Fragmento ilustrativo]`, así que §0.5 no lo prohíbe, pero es la única línea de los tres pasos que difiere (script de la comisión: 1 línea distinta en 3 bloques) y el comentario del archivo es mejor porque nombra el concepto de §2.1. **Dirección:** copiar la del archivo.
- **(b) §5.2, l. 1167:** «`IActionResult` es el tipo que representa cualquier respuesta HTTP». Las otras dos acciones del mismo controller (archivo, l. 15 y 23) devuelven `ActionResult<IEnumerable<ProductoResponse>>` y `ActionResult<ProductoResponse>`, tipo que la guía no nombra (`grep -n "ActionResult<"` → vacío) aunque el lector lo va a ver al abrir el archivo que §0.5 le manda a copiar. **Dirección:** una frase o mostrar `GetById` (5 líneas) que además materializa el `404` de L15.

---

## Lo que revisé y está bien

1. **Los `[Compilado]` coinciden con sus archivos y todo compila con 0 advertencias.** Script de la comisión sobre los 12 bloques con ruta (el 13.º «`[Compilado`» del conteo es la fila de §0.5): cada línea no vacía del bloque existe en el archivo módulo sangría (`missing(stripped)=0` × 12). Compilación en la imagen (`build-all.log`): `MyProject` → `Build succeeded. 0 Warning(s) 0 Error(s)`; `dotnet test` → `Passed! … Passed: 3 … MyProject.Domain.Tests` y `Passed: 2 … MyProject.Application.Tests`; `Variantes` V01 y V02 → 0 advertencias y salida idéntica a la citada en §3.7 y §4.10 (las 5 y las 12 líneas); `Conceptos-DI` Paso0/1/2 → 0 advertencias. Las columnas de los errores citados en §1.4 (`Producto.cs(9,25)`) y §3.4 (`Intento.cs(10,9)`) coinciden con la posición real de `ConexionSql` y de `producto.Precio` en los archivos de `lab.sh`.
2. **§4.10: «alcanza con declarar que el contexto implementa `IUnitOfWork`».** `Chk1`: `class Ctx : DbContext, IUnitOfWork` con la interfaz `Task<int> SaveChangesAsync(CancellationToken ct = default)` compila sin adaptador y `2. filas afectadas por IUnitOfWork.SaveChangesAsync: 1`. La afirmación es exacta.
3. **§5.3/§5.4, `decimal` en SQLite, y las dos búsquedas de §2.7 y §5.3.** `Chk1`: `columna Precio tipo=TEXT, texto guardado='4500.0', leído=4500.0, JSON=4500.0` con `HasPrecision(18, 2)`: la explicación del `4500.0` de L17 es correcta. `grep -rn Application src/Backend/MyProject.Infrastructure --include=*.cs` → vacío (rc 1), como dice §2.7; `grep -rn Infrastructure src/Backend/MyProject.WebAPI --include=*.cs` → exactamente dos líneas, ambas en `Program.cs` (l. 4 y 15), como dice §5.3.

---

## Solicitudes de convocatoria

| # | Señal | Ubicación | Comisión |
|---|---|---|---|
| SC-1 | `InMemoryProductoRepository` y el `Program.cs` de L13 existen sólo dentro de `lab.sh`; §0.5 promete que todo tipo nombrado está en `MyProject/`. Es una regla editorial de procedencia; la parte técnica está en NET-01 | §0.5 fila «Tipo nombrado sin código»; §5.2 l. 1167 | Editor |
| SC-2 | §4.4 y §5.5 atribuyen a Microsoft (2018) que «`DbContext` ya implementa *Repository* y *Unit of Work*» y §9.6 paso 2 lo usa para calificar `PersonasService` como *Service Layer* + *Transaction Script*. Si la correspondencia entre `DbSet` y el *Repository* de Fowler/Evans es fiel no es de mi competencia | §4.4 l. 874 y 881; §9.6 l. 1820 y 1869 | Fowler |
| SC-3 | La tabla de §4.3 («Prueba rápida») y la de §3.6 se usan como criterio de decisión; NET-02 muestra que una fila es falsa en un caso del propio corpus. Si el formato «tabla de sí/no» forma criterio o sólo lo aparenta cuando la fila admite excepciones, es pregunta de pedagogía | §4.3 l. 846–852 | Académico |

---

## Fuentes consultadas

- Código y capturas del laboratorio en `LAB/Lab-Documentos/Guides/Dot-NET-Arquitectura-Guide/Examples/Dot-NET-Arquitectura-Lab/` @ `dbdf9dd` (`MyProject/`, `Variantes/`, `Conceptos-DI/`, `lab.sh`, `Variantes/capturas/V01-*`, `V02-*`).
- `00-Contrato-De-Entrada.md`, `01-Base-Mecanica.md`, `Nucleos/NE-00`, `NE-01`, `NE-05` (misma carpeta que este informe).
- Compilaciones y programas de comprobación de la comisión, imagen `mcr.microsoft.com/dotnet/sdk:10.0@sha256:e1ffd2a92ae84c1291bc1b6887501f8af98e6331e7af6d4c8d37168c5e87a64c`, SDK 10.0.400, 2026-09-19: `build-all.log`, `Chk1` (record con colección, `DbContext : IUnitOfWork`, `decimal` en SQLite, ensamblado de `IndexAttribute`, `Guid.CreateVersion7`), `Chk2` (inferencia de `[FromServices]`), `Chk3` (`int Id` antes de `SaveChanges`, `DbUpdateException` por índice único), `Chk4` (`AsNoTracking` + `SaveChangesAsync`). Fuente de los programas transcrita en este informe donde se cita su salida; quedan en el scratchpad de la sesión y pueden reproducirse a partir de lo aquí descrito.
- Microsoft. *DbSet<TEntity>.AddAsync(TEntity, CancellationToken) Method*. https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1.addasync (consultado el 2026-09-19).
- Microsoft. *What's new in ASP.NET Core in .NET 7*, sección «Parameter binding with DI in API controllers». https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-7.0 (consultado el 2026-09-19).
- Microsoft. *Model Binding in ASP.NET Core*, sección `[FromServices]`. https://learn.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-10.0 (consultado el 2026-09-19).
