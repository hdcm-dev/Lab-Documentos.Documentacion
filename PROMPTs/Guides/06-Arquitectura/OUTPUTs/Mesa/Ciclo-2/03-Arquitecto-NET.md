# Ciclo 2 — Informe del Arquitecto .NET senior

**Objeto:** `Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md` v2.0.0 (1308 líneas) y su laboratorio `Dot-NET-Arquitectura-Lab/` (lab.sh, capturas/, aserciones.log, MyProject/).
**Mandato:** corrección técnica de cada afirmación y fragmento de código contra el código compilado y las capturas. Trabajé a ciegas respecto de los otros informes del ciclo.
**Método:** leí el documento completo, los 24 archivos `.cs`, los 8 `.csproj`, `global.json`, `lab.sh` (tramos L13–L22) y las capturas L01, L03, L04, L05, L10, L13–L24. Una afirmación (decimal en SQLite) la verifiqué ejecutando código en la misma imagen `mcr.microsoft.com/dotnet/sdk:10.0` con `Microsoft.EntityFrameworkCore.Sqlite 10.0.12`. Una fuente externa (Microsoft, 2026b) la verifiqué por URL.

---

## 1. Hallazgos

### H-01 — `HasPrecision(18, 2)` no tiene efecto en SQLite y la explicación del `4500.0` es imprecisa

- **Ubicación:** §5.3 línea 662 («el tipo `decimal` conserva la escala con la que el proveedor de SQLite lo devuelve») y §5.4 líneas 678 y 683 (`builder.Property(p => p.Precio).HasPrecision(18, 2);`).
- **Evidencia:** E1. Programa mínimo con EF Core Sqlite 10.0.12, entidad con `decimal Precio` configurada con `HasPrecision(18, 2)`, valor `4500m` guardado y releído:

  ```text
  leido por EF: 4500.0 (escala 1)
  json: 4500.0
  almacenado: '4500.0' typeof=text
  CREATE TABLE "Items" ("Id" INTEGER NOT NULL ..., "Precio" TEXT NOT NULL)
  ```

  El proveedor de SQLite guarda `decimal` como columna `TEXT` y lo escribe siempre con al menos un decimal (`4500.0`); la precisión y escala declaradas no se aplican al esquema (la columna no es `DECIMAL(18,2)` ni el valor vuelve como `4500.00`). Coincide con la captura `L17-mismo-contrato.txt` (`"precio":4500.0`) y con `L22-cliente-consola.txt` (`12000.0`).
- **Por qué importa:** la guía muestra `HasPrecision(18, 2)` y dos párrafos después un resultado con un solo decimal. Una persona que aprende a leer resultados se pregunta por qué no sale `4500.00`, y la frase «conserva la escala con la que el proveedor lo devuelve» no lo responde: no dice que el proveedor guarda texto ni que la configuración de precisión no rige en SQLite.
- **Severidad:** S3.
- **Reemplazar (línea 662):** «El precio llega como `4500.0` en lugar de `4500`: el valor numérico es igual, pero el tipo `decimal` conserva la escala con la que el proveedor de SQLite lo devuelve.»
  **Por:** «El precio llega como `4500.0` en lugar de `4500`: el valor numérico es igual. SQLite no tiene un tipo decimal, así que el proveedor de EF Core guarda el `decimal` como texto y lo escribe siempre con al menos un dígito decimal (`4500.0`); al releerlo, el `decimal` conserva esa escala y el JSON la reproduce.»
- **Agregar (después de la línea 683):** «`HasPrecision(18, 2)` documenta la intención y rige en proveedores con tipo decimal nativo (SQL Server, PostgreSQL); en SQLite la columna se crea como `TEXT` y la precisión no se aplica, por eso en L17 el precio vuelve con un solo decimal y no con dos.»

### H-02 — La referencia `Infrastructure → Application` se justifica con interfaces que el laboratorio no contiene

- **Ubicación:** §2.6 línea 348: «`Infrastructure` referencia también a `Application` porque ahí se declaran las interfaces de servicios técnicos (correo, usuario actual) que Infrastructure implementa.»
- **Evidencia:** E2 + E1. `MyProject.Application` compilado contiene solo `ProductoDto`, dos Query, un Command y tres handlers (listado de `find … -name '*.cs'`); no hay `IEmailService` ni `ICurrentUserService`. Ningún archivo de `MyProject.Infrastructure` tiene `using MyProject.Application…` (`DependencyInjection.cs`, `AppDbContext.cs`, `ProductoConfiguration.cs`, `ProductoRepository.cs` usan solo `MyProject.Domain.*` y EF Core). La `ProjectReference` existe en `MyProject.Infrastructure.csproj` pero no se usa.
- **Por qué importa:** la oración está en indicativo («ahí se declaran»), en el mismo párrafo que presenta el «grafo real de la solución». Quien busque esas interfaces en `MyProject/` no las encuentra. Contradice el rótulo «Todo lo que la guía muestra … fue ejecutado y está registrado; lo que no se ejecutó está rotulado» (línea 20).
- **Severidad:** S3.
- **Reemplazar:** «`Infrastructure` referencia también a `Application` porque ahí se declaran las interfaces de servicios técnicos (correo, usuario actual) que Infrastructure implementa.»
  **Por:** «`Infrastructure` referencia también a `Application` para poder implementar las interfaces de servicios técnicos (correo, usuario actual; §4.1) que una solución real declara en esa capa. En el laboratorio esa referencia queda declarada pero sin uso: ningún archivo de `Infrastructure` nombra un tipo de `Application`, porque el ejemplo no llega a necesitar un servicio técnico.»

### H-03 — «`Program.cs` cambia una línea» en L16: cambia más, y una de las líneas nuevas es la que crea la base

- **Ubicación:** §5.3 línea 653: «`Program.cs` cambia una línea: `builder.Services.AddInfrastructure(...)` en lugar del registro en memoria.»
- **Evidencia:** E2. `lab.sh` líneas 527–552 (Program.cs de L13) y 668–696 (Program.cs de L16) muestran que el archivo se reemplaza entero y difiere en: dos `using` que se quitan (`MyProject.Domain.Productos`, `MyProject.Infrastructure.Persistence`), uno que se agrega (`MyProject.Infrastructure`), la línea de registro, y una línea nueva `app.Services.EnsureDatabaseCreated();` que llama a `Database.EnsureCreated()` (`DependencyInjection.cs` líneas 18–23). Esa última línea no se menciona en ningún lugar de la guía.
- **Por qué importa:** quien haga L16 a mano siguiendo el texto (una línea) arranca la API sin tabla `Productos` y el primer `POST` falla con `SqliteException: no such table`. La guía promete que la persona «pruebe comandos y entienda sus resultados»; aquí el resultado sería un error no anticipado.
- **Severidad:** S3.
- **Reemplazar:** «`Program.cs` cambia una línea: `builder.Services.AddInfrastructure(...)` en lugar del registro en memoria.»
  **Por:** «En `Program.cs` el registro en memoria se reemplaza por `builder.Services.AddInfrastructure(...)`, se ajustan los `using` y se agrega, después de `builder.Build()`, `app.Services.EnsureDatabaseCreated();`: un método de extensión de `Infrastructure` que llama a `Database.EnsureCreated()` para crear el archivo y la tabla si no existen (en un proyecto real se usan migraciones). Sin esa línea el primer `POST` falla con `no such table: Productos`. La versión completa está en `MyProject/src/Backend/MyProject.WebAPI/Program.cs`.»

### H-04 — Fragmento rotulado **[Compilado]** que no coincide con el fuente compilado

- **Ubicación:** §5.6 líneas 715–731 (`DomainExceptionHandler`), en particular la línea 728: `ProblemDetails = { Status = 400, Title = …, Detail = … },`.
- **Evidencia:** E2. El archivo `MyProject/src/Backend/MyProject.WebAPI/ExceptionHandlers/DomainExceptionHandler.cs` tiene `Status = StatusCodes.Status400BadRequest` (líneas 24–29). La marca de procedencia (§0.5, línea 82) define **[Compilado]** como «extracto del laboratorio y compiló con cero advertencias». Un extracto puede omitir partes (aquí se omiten la declaración de la clase, el campo y el constructor, lo cual es aceptable) pero no reescribir una expresión. Los demás bloques **[Compilado]** (§3.2, §4.2, §5.2, §5.4, §6.3) sí son textuales, salvo un comentario agregado en §4.3 línea 504 (`// guarda en una List<Producto>`) que no está en `CrearProductoHandlerTests.cs`.
- **Severidad:** S3 (afecta la confiabilidad de la marca, que es el mecanismo de verificabilidad del documento).
- **Reemplazar (línea 728):** `        ProblemDetails = { Status = 400, Title = "Regla de negocio incumplida", Detail = exception.Message },`
  **Por:**
  ```csharp
          ProblemDetails =
          {
              Status = StatusCodes.Status400BadRequest,
              Title = "Regla de negocio incumplida",
              Detail = exception.Message,
          },
  ```
  **Y en la línea 504:** quitar el comentario `// guarda en una List<Producto>` o moverlo a la prosa (línea 494 ya dice «un repositorio falso escrito en el proyecto de pruebas»).

### H-05 — «Blazor WebAssembly … no tiene el ensamblado del dominio» presenta como imposibilidad lo que es una decisión

- **Ubicación:** §7.4 línea 977: «En un cliente Blazor WebAssembly, además, el código corre en el navegador y no tiene el ensamblado del dominio.»
- **Evidencia:** E3. Un proyecto Blazor WebAssembly puede agregar `<ProjectReference Include="…\MyProject.Domain.csproj" />`: `Domain` es una `classlib` `net10.0` sin dependencias (`MyProject.Domain.csproj`), compila para el navegador y su `.dll` se descarga con la aplicación. Lo que no puede tener el navegador es la base ni `Infrastructure`, que es exactamente lo que dice bien el ❌ de §6.4 línea 815 («corre en el navegador y no tiene la base ni el servidor»). Las dos líneas del mismo documento dan razones distintas para el mismo caso.
- **Severidad:** S3.
- **Reemplazar:** «En un cliente Blazor WebAssembly, además, el código corre en el navegador y no tiene el ensamblado del dominio.»
  **Por:** «En un cliente Blazor WebAssembly, además, el código corre en el navegador: para que la página recibiera la entidad habría que descargar el ensamblado de `Domain` al cliente, y aun así no habría base ni repositorio que la respalden (§6.4).»

### H-06 — «Cualquier SDK `10.0.*` reproduce el laboratorio» choca con el `global.json` publicado

- **Ubicación:** §0.6 línea 108 y §1.2 líneas 130 y 139; `MyProject/global.json` (`"version": "10.0.400", "rollForward": "latestFeature"`).
- **Evidencia:** E4. Regla documentada de `global.json`: con `latestFeature` se usa «the highest installed feature band and patch level that matches the requested major and minor with a feature band that is greater than or equal to the requested value» (https://learn.microsoft.com/en-us/dotnet/core/tools/global-json#rollforward). Un SDK 10.0.1xx, 10.0.2xx o 10.0.3xx instalado no satisface `10.0.400`: `dotnet build` dentro de `MyProject/` termina con «A compatible .NET SDK was not found». La guía dice a la vez que el número de parche «puede cambiar en tu equipo (`10.0.4xx`, `10.0.1x`)» y que «cualquier SDK `10.0.*` reproduce el laboratorio».
- **Matiz:** ejecutar `lab.sh` sí funciona con cualquier 10.0.*, porque L01 genera el `global.json` con `$(dotnet --version)` del equipo. Lo que no funciona es abrir el `MyProject/` publicado con un SDK de banda inferior a 400. La guía no distingue los dos casos.
- **Severidad:** S3.
- **Reemplazar (línea 108):** «Cualquier SDK `10.0.*` reproduce el laboratorio.»
  **Por:** «Cualquier SDK `10.0.*` reproduce el laboratorio ejecutando `lab.sh` o los comandos de cada paso, porque L01 genera `global.json` con la versión instalada. El `MyProject/` publicado junto a esta guía fija `10.0.400` con `rollForward: latestFeature`, que acepta esa banda o una superior; con un SDK `10.0.1xx`–`10.0.3xx` hay que editar `version` en `global.json` antes de compilarlo.»

### H-07 — El tercer handler (`ObtenerProductoPorIdHandler`) no se presenta nunca, y `GetById` y `CreatedAtAction` dependen de él

- **Ubicación:** §4.2 línea 490 («La Query equivalente, `ObtenerProductosHandler`…») y §5.2 línea 597 («y los tres handlers»).
- **Evidencia:** E2. El código compilado tiene tres handlers: `CrearProductoHandler`, `ObtenerProductosHandler` y `ObtenerProductoPorIdHandler` (`MyProject.Application/Productos/Queries/ObtenerProductoPorId/`). `ProductosController.GetById` recibe `[FromServices] ObtenerProductoPorIdHandler`, y `Create` devuelve `CreatedAtAction(nameof(GetById), …)`, que la guía explica en §5.2 línea 597 y §5.2 línea 629 («`Location` dice dónde consultar el recurso nuevo (la acción `GetById`)»). El nombre `ObtenerProductoPorIdHandler`/`ObtenerProductoPorIdQuery` no aparece en el documento. §5.2 dice «los tres handlers» sin haber nombrado el tercero, y §4.2 presenta una sola Query «equivalente».
- **Por qué importa:** quien construya `Application` a partir de §4.2 escribe dos handlers; al llegar a §5.2 el controller mostrado y el `Location` exigen un tercero que no sabe de dónde sale. Es la pregunta que un implementador tendría que hacer.
- **Severidad:** S3.
- **Reemplazar (línea 490):** «La Query equivalente, `ObtenerProductosHandler`, llama a `GetAllAsync` y convierte cada entidad en `ProductoDto` con `ProductoDto.From(producto)`.»
  **Por:** «Las dos Queries siguen el mismo patrón: `ObtenerProductosHandler` llama a `GetAllAsync` y convierte cada entidad en `ProductoDto` con `ProductoDto.From(producto)`; `ObtenerProductoPorIdHandler` recibe `ObtenerProductoPorIdQuery(Id)`, llama a `GetByIdAsync` y devuelve `ProductoDto?` (nulo si no existe). La segunda es la que usa la API para responder la consulta de un producto por su `Id` (§5.2).»
  **Reemplazar (línea 597):** «y los tres handlers» **por** «y los tres handlers (`CrearProductoHandler`, `ObtenerProductosHandler`, `ObtenerProductoPorIdHandler`) con `AddScoped`».

---

## 2. Observaciones S4 (no cuentan como hallazgo; se aplican o descartan en lote)

- §1.5 línea 202: «El error no lo emite el compilador de C# … sino MSBuild, el motor que ordena la compilación». La captura `L04-ciclo-compilar.txt` ubica el MSB4006 en `/usr/share/dotnet/sdk/10.0.400/NuGet.targets(1298,5)` y en el target `_GenerateRestoreProjectPathWalk`: falla la **restauración** (NuGet, al recorrer el grafo de proyectos), que es la primera fase de `dotnet build`, antes de decidir el orden de compilación. Texto sugerido: «…sino MSBuild, en la fase de restauración que corre antes de compilar (`NuGet.targets`): al recorrer el grafo de proyectos encuentra que cada uno necesita al otro y no puede continuar.»
- §5.2 diagrama «Diagrama 4» aparece antes del «Diagrama 3» (§7.3). Fuera de mi mandato (orden), se deja constancia.

---

## 3. Revisado y correcto

1. **§1.2 línea 153, formas sustantivo-primero de la CLI.** Verificado en https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10/sdk («More consistent command order»): «Starting in .NET 10, the `dotnet` CLI tool includes new aliases … While the verb-first forms continue to work, it's better to use the noun-first forms for improved readability and consistency in scripts and documentation.» La guía reproduce el dato con fidelidad.
2. **§2.6 línea 348 y §8.2 línea 1038, transitividad de las referencias.** E1: `MyProject.WebAPI.csproj` referencia solo `Application`, `Infrastructure` y `Contracts`; `DomainExceptionHandler.cs` usa `MyProject.Domain.Common.DomainException` y la solución compila con 0 advertencias (`L22-build-compilar-solucion.txt`). La propiedad `DisableTransitiveProjectReferences` es el nombre correcto.
3. **§5.6 tabla y prosa (L19–L21) y §5.3 (L16–L17).** Contrastado con las capturas: L19 `400` + `application/problem+json; charset=utf-8` + `"errors"` producido por `[ApiController]`; L20 `500` `text/plain` con `MyProject.Domain.Common.DomainException: El precio debe ser mayor a cero.` (página de excepciones de desarrollo, habilitada por `WebApplication.CreateBuilder` en `Development`); L21 `400` `application/problem+json` con `"title":"Regla de negocio incumplida"` y `"detail"`. L16: `Skipping target "CoreCompile"` para Domain y sha256 idéntico; L17: `grep` de `Infrastructure` devuelve dos líneas, ambas en `Program.cs`. Las cuatro afirmaciones sobre `Add` vs `AddAsync` de EF Core, `CreatedAtAction` sin cuerpo (`Content-Length: 0` en L14), OpenAPI `3.1.1` en `/openapi/v1.json` y `.slnx` por defecto en `dotnet new sln` (L01) también coinciden con capturas y código.

---

## 4. Solicitudes de convocatoria

- **Seguridad / licencias:** §9.4 línea 1137 afirma que la vulnerabilidad GHSA-rvv3-g6hj-g44x «está corregida en versiones de esa rama» (AutoMapper 15.x). No lo verifiqué contra el advisory y excede mi mandato; conviene que quien evalúe licencias y vulnerabilidades lo confirme con la URL del Anexo E.
- **Redacción / edición:** numeración de diagramas (Diagrama 4 antes que Diagrama 3) y consistencia de la marca **[Compilado]** como regla editorial (H-04 la aplica a un caso; la norma general de «extracto» conviene fijarla en §0.5).
