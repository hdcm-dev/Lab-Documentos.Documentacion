# Mesa evaluadora, ciclo 1 — Informe del Arquitecto .NET senior

**Fecha:** 2026-09-18
**Rol:** E-Arquitecto .NET (catálogo variable, convocado 5-0)
**Pregunta del mandato:** ¿cada afirmación técnica de la guía vigente y de los núcleos es correcta? Propuesta fundada para DA-1 y DA-2.
**Objeto:** `LAB/Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md` (1003 líneas, commit 063f4e9) y `OUTPUTs/Nucleos/NC-00..NC-10`.
**Condición de trabajo:** a ciegas; no se leyeron otros informes de `Ciclo-1/`.

---

## 0. Cómo se obtuvo la evidencia

Las pruebas E1 se corrieron en contenedores oficiales (`mcr.microsoft.com/dotnet/sdk:9.0` y `:10.0`; SDK informado: `10.0.400`). Los guiones quedaron en `Ciclo-1/evidencia-03/`:

| Guion | Qué reproduce |
|---|---|
| `run1.sh` | Referencia circular entre dos `classlib` y formato de `dotnet new sln` |
| `run2.sh` | Controller §7 y `ProductoApiService` §8 copiados literalmente, más el paquete `MediatR` |
| `run3.sh` | Misma compilación sin `ProductoApiService`, para que aparezcan los errores restantes |
| `run4.sh` | Plantillas disponibles (`dotnet new list`) en SDK 9 y 10 |
| `run5.sh` | Árbol de la plantilla `blazorwasm` y opciones de `--interactivity` de `blazor` (SDK 10) |

Se ejecutan con `docker run --rm -v <carpeta>:/w mcr.microsoft.com/dotnet/sdk:10.0 bash /w/runN.sh` (`run2.sh` crea `/w/g`, que `run3.sh` reutiliza).

Fuentes externas consultadas (hoy):

- EF Core, `DbSet<TEntity>.AddAsync`: <https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1.addasync>
- Blazor, configuración: <https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/configuration>
- Blazor Hybrid: <https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/>
- Identity para SPA (tokens): <https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity-api-authorization>
- Refit (README): <https://github.com/reactiveui/refit>

---

## 1. Hallazgos

### H-ARQ-01 — Tres fragmentos de código de la guía no compilan

- **Ubicación:** §7, línea 552; §8, líneas 618–650; y, como ejemplo de NC-03, el setter privado de §1 (líneas 40–43).
- **Severidad:** S1 · **Evidencia:** E1 · **Confianza:** 0,95
- **Afirmación.** El texto se presenta como código de ejemplo copiable, pero el compilador lo rechaza:

```text
Guia.cs(41,39): error CS0103: The name 'GetById' does not exist in the current context
Guia.cs(52,35): error CS0535: 'ProductoApiService' does not implement interface member 'IProductoApiService.GetByIdAsync(Guid, CancellationToken)'
Guia.cs(52,35): error CS0535: 'ProductoApiService' does not implement interface member 'IProductoApiService.DeleteAsync(Guid, CancellationToken)'
```

  - `CreatedAtAction(nameof(GetById), …)` referencia una acción que el controller no define. La guía ya tiene el caso de uso que hace falta (`ObtenerProductoPorIdQuery`, §5, línea 411), pero no lo expone.
  - `ProductoApiService : IProductoApiService` implementa 2 de los 4 miembros de la interfaz declarada en las líneas 618–624.
  - Además, las dos «opciones» del front declaran **la misma interfaz `IProductoApiService` con firmas distintas**: `Task<Guid> CreateAsync` (línea 622) frente a `Task<ApiResponse<Guid>> CreateAsync` (línea 667), y `ProductoResponseDto?` frente a `ProductoResponseDto` en `GetByIdAsync`. La página de la línea 746 no puede quedar escrita para las dos, y eso contradice la promesa de la línea 703 («la página no sabe si es Refit, HttpClient o un mock»).
  - El control del setter privado sí se comporta como afirma NC-03 (`CS0272 … the set accessor is inaccessible`), así que ese punto se registra en §2 como correcto.
- **Propuesta.** (1) Agregar `[HttpGet("{id:guid}")] GetById(Guid id, …)` que envíe `ObtenerProductoPorIdQuery` y devuelva `NotFound()` o `Ok(dto)`. (2) Completar `ProductoApiService`, o rotularlo como «fragmento ilustrativo» y dejarlo fuera del código que el lector copia. (3) Mantener **una sola** interfaz del front con firmas neutras (`Task<Guid>`, `Task<ProductoResponseDto?>`); la variante Refit la implementa detrás, con una interfaz Refit interna, o la guía declara que en Refit la interfaz cambia y la página también. (4) Regla de proceso para el entregable: todo bloque `csharp` que no esté rotulado como fragmento se compila en el laboratorio (NC-08) antes del cierre.

### H-ARQ-02 — El caso de uso «crear» no persiste nada: falta `SaveChanges` / unidad de trabajo

- **Ubicación:** §5, líneas 450–455 (`CrearProductoHandler`); §1, línea 191 (operaciones del repositorio); §6 (no se muestra `ProductoRepository`).
- **Severidad:** S2 · **Evidencia:** E3 + fuente primaria · **Confianza:** 0,85
- **Afirmación.** El handler llama a `_repo.AddAsync(producto, ct)` y devuelve el `Id`. En ningún lugar de la guía aparece `SaveChangesAsync`, un `IUnitOfWork` ni la implementación del repositorio. La documentación de EF Core dice que `AddAsync` solo marca la entidad para insertar: *«Begins tracking the given entity … in the Added state such that they will be inserted into the database when SaveChanges() is called.»* También aclara: *«This method is async only to allow special value generators … For all other cases the non async method should be used.»*
- **Contraejemplo.** Un lector novato implementa el repositorio con la forma más directa, `await _db.Productos.AddAsync(p, ct);`. Entonces `POST /api/productos` responde 201 con un `Id`, y el `GET` siguiente devuelve `[]`. El lector ve un éxito que no ocurrió y no tiene en la guía la pieza que le falta para diagnosticarlo.
- **Propuesta.** Mostrar `ProductoRepository` completo y decidir explícitamente dónde se confirma la transacción. Hay dos opciones: el repositorio llama a `SaveChangesAsync`, que es lo más simple para un CRUD, o se declara un `IUnitOfWork` que el handler invoca, que es lo correcto cuando un caso de uso toca más de un agregado. La guía debe enseñar ese criterio. Dentro del repositorio conviene usar `Add` y no `AddAsync`, según la nota citada. El laboratorio (NC-08, paso 6) debe mostrar `POST` seguido de `GET` con el producto presente, que es la prueba de que se persistió.

### H-ARQ-03 — Los DTOs viven donde la propia tabla de dependencias prohíbe que el front llegue

- **Ubicación:** §1, líneas 91–95 (`MyProject.Application/Products/DTOs/…`); §5, línea 416; §8, líneas 620–622 y 746 (el front usa `ProductoResponseDto` y `CrearProductoRequestDto`); §13, líneas 979–983; §3, línea 324 («Opcional»); §7, línea 549.
- **Severidad:** S2 · **Evidencia:** E2 · **Confianza:** 0,9
- **Afirmación.** La guía se contradice en cuatro puntos:
  - El front consume `ProductoResponseDto`, que está definido en `Application`, mientras §13 (línea 980) prohíbe que WebFront y Desktop referencien `Application`. Con las reglas tal como están escritas, el front no compila.
  - `Contracts` figura como «opcional» (línea 324), pero en la arquitectura de la guía es la única vía legal para que el front obtenga los tipos.
  - En §13, `WebAPI` no lista `Contracts` entre lo que puede referenciar (línea 979), aunque es quien lo serializa.
  - El controller enlaza `CrearProductoCommand` directamente desde el cuerpo HTTP (línea 549). Con eso, un tipo interno de Application pasa a formar parte del contrato público: cualquier cambio en el comando cambia la API sin que nadie lo decida.

  Todo esto coincide con X-01, X-04 y X-05 de NC-00 y es la raíz técnica de DA-2.
- **Propuesta.** Ver la posición sobre DA-2 (§3). En el ejemplo, el controller recibe `CrearProductoRequest` (de Contracts) y construye `CrearProductoCommand`; la tabla §13 agrega `Contracts` a lo que pueden referenciar WebAPI, WebFront y Desktop. Además hay que unificar la ruta de los DTOs (X-05) y el nombre de carpeta: `Products` en la línea 91 contradice DC-2, porque el concepto va en español (`Productos`).

### H-ARQ-04 — Afirmaciones de Blazor que no corresponden al .NET que la guía declara

- **Ubicación:** §8, línea 563 («Blazor WebAssembly (standalone) o Blazor Server»); línea 606 (`appsettings.json` en la raíz del WebFront con la URL de la API) y línea 680; línea 566; Resumen, línea 999.
- **Severidad:** S2 · **Evidencia:** E1 + fuente primaria · **Confianza:** 0,85
- **Afirmación.**
  1. **No existe un tipo de proyecto «Blazor Server» en el SDK 9 ni en el 10.** `dotnet new list` (`run4.sh`) ofrece solo `blazor` («Blazor Web App») y `blazorwasm` («Blazor WebAssembly Standalone App»). Lo que la guía llama Blazor Server hoy se crea con `dotnet new blazor --interactivity Server` (la ayuda de la plantilla dice: *«Server — Runs on the server»*, valor por defecto). Un lector que busque la plantilla que nombra la guía no la encuentra.
  2. **Ubicación de la configuración en WASM.** Según Microsoft Learn, *«In standalone Blazor WebAssembly apps, configuration is loaded from … `wwwroot/appsettings.json`»*, y advierte: *«Configuration and settings files in the web root (`wwwroot` folder) are visible to users on the client … Don't store app secrets»*. El árbol de la línea 606 pone `appsettings.json` en la raíz del proyecto. En WASM, `builder.Configuration["ApiBase"]` (línea 680) devuelve `null` y el `new Uri(null!)` falla al arrancar. La plantilla `blazorwasm` del SDK 10 no genera ningún `appsettings.json` (listado de `run5.sh`: solo `wwwroot/index.html`, `css`, `lib`, `sample-data`), así que el lector tiene que crearlo, y en el lugar correcto.
  3. La afirmación de la línea 566 («si la WebAPI cae, el front puede seguir abierto») solo vale para WASM. En modo interactivo de servidor, la UI también es un proceso servidor con circuito SignalR, y lo que ve el usuario depende de ese proceso, no solo de la API.
- **Propuesta.** Nombrar los modos como los nombra el SDK vigente (Blazor Web App con modo de renderizado Server, WebAssembly o Auto; y Blazor WebAssembly Standalone). Poner la configuración del cliente en `wwwroot/appsettings.json` con la advertencia de visibilidad. Separar en una tabla qué cambia entre Server y WASM (dónde corre el código, qué puede referenciar, qué se descarga al navegador). Eso además funda la respuesta de NC-05 sobre por qué igual se separa en Server.

### H-ARQ-05 — «Los componentes se renderizan nativamente… Funciona offline» es incorrecto y contradice la propia arquitectura

- **Ubicación:** §10, líneas 813–814; en contraste con las líneas 825–829 y 949 (el Desktop consume la WebAPI por HTTP); líneas 804 y 831–834 («Desktop» con `Platforms/Android`).
- **Severidad:** S2 · **Evidencia:** E2 + fuente primaria · **Confianza:** 0,85
- **Afirmación.** Microsoft Learn: *«In a Blazor Hybrid app, Razor components run natively on the device. Components render to an embedded Web View control through a local interop channel.»* Lo nativo es la **ejecución** del código .NET; el **renderizado** ocurre en un WebView. La guía confunde las dos cosas y, con eso, la diferencia real con el «WebView remoto» de la línea 810, que es dónde corre el código y de dónde viene la UI, no si hay o no WebView. «Funciona offline» es falso para la solución que describe la guía: las páginas del Desktop obtienen los datos a través de `IProductoApiService` por HTTP (líneas 825–829 y 949). Sin red, la UI abre, pero cada caso de uso falla. Por último, el proyecto se llama *Desktop* y su árbol incluye `Android`, lo que confunde el alcance (MAUI es multiplataforma, móvil incluido).
- **Propuesta.** Reescribir la distinción así: «el código C# de los componentes corre dentro de la app, en el proceso .NET del dispositivo, y dibuja su HTML en un WebView embebido; con un WebView remoto, en cambio, la app solo muestra un sitio que corre en otro servidor». Reemplazar «funciona offline» por «la interfaz se carga sin red; los datos, no, salvo que se diseñe una caché local (fuera de alcance)». Renombrar el proyecto a `MyProject.Maui` o `MyProject.App`, o recortar `Platforms` a los destinos de escritorio que se declaren.

### H-ARQ-06 — Los diagramas dibujan flechas que violan la regla que la guía enseña, y el de §12 contradice DC-1

- **Ubicación:** §12, línea 950 (`APP -.->|"usa sus interfaces, resueltas por DI"| INF`); §12, líneas 932–942 (Application, Domain e Infrastructure dentro del subgrafo «WebAPI (ASP.NET Core)»); §1, línea 181 (`IProductoRepository` coloreado como Application); frente a la línea 241 («nunca hay una flecha que salga del centro hacia afuera») y DC-3.
- **Severidad:** S2 · **Evidencia:** E2 + E4 (DC-1, DC-3) · **Confianza:** 0,8
- **Afirmación.** Para un lector sin experiencia, el diagrama es la regla. En §12 hay una flecha de Application hacia Infrastructure, que es justo la dependencia prohibida, rotulada como algo normal. El mismo diagrama mete los cuatro proyectos del backend **dentro** de la caja «WebAPI»: eso es la lectura de contención que DC-1 cerró («proyectos hermanos»), y además contradice el diagrama de §2, donde son hermanos. El diagrama de MediatR pinta el repositorio como Application aunque DC-3 lo ubica en Domain. El problema de fondo es que la guía mezcla, sin leyenda, dos tipos de flecha: «referencia de compilación» y «llamada en tiempo de ejecución». Esos dos sentidos son opuestos precisamente en la inversión de dependencias, que es lo que más cuesta entender.
- **Propuesta.** Fijar una convención gráfica única y declararla con una leyenda en todos los diagramas: línea continua para la referencia de proyecto (siempre hacia adentro) y línea punteada para el flujo en ejecución (puede ir hacia afuera, pero a través de una interfaz declarada adentro). En §12 la flecha pasa a ser `INF -->|implementa IProductoRepository| DOM`, y el subgrafo se renombra «Backend (desplegado como WebAPI)», con los proyectos como hermanos. El laboratorio respalda la convención con `dotnet list reference` (E1).

### H-ARQ-07 — NC-01 predice mal qué hace el SDK ante una referencia circular, y omite que `dotnet new sln` ya genera `.slnx`

- **Ubicación:** NC-01, línea 18 («el SDK lo rechaza»); NC-01, línea 7 y NC-08 (salidas que se van a capturar).
- **Severidad:** S3 · **Evidencia:** E1 · **Confianza:** 0,9
- **Afirmación.** `run1.sh` (SDK 10.0.400):

```text
+ dotnet add A.Infra reference A.Domain
Reference `..\A.Domain\A.Domain.csproj` added to the project.
+ dotnet add A.Domain reference A.Infra
Reference `..\A.Infra\A.Infra.csproj` added to the project.
exit add: 0
+ dotnet build A.Domain
error MSB4006: There is a circular dependency in the target dependency graph involving target "_GenerateRestoreProjectPathWalk".
```

  El SDK **acepta** agregar la referencia; el ciclo recién se detecta al restaurar o compilar, y con un mensaje (MSB4006, que nombra un *target* interno de NuGet) que un novato no puede asociar con «dos proyectos se referencian mutuamente». Si la guía dice «lo rechaza», el lector que ve `exit 0` concluye que la regla no existe. En la misma corrida, `dotnet new sln -n Ciclo` generó `Ciclo.slnx`, no `.sln`: si DA-3 adopta .NET 10, todas las salidas y rutas de la guía (`MyProject.sln`, líneas 258 y 306) cambian.
- **Propuesta.** Corregir la predicción de NC-01 y enseñar la lectura real: «`dotnet add reference` no controla ciclos; el ciclo aparece al compilar como MSB4006; la pista es que el mensaje nombra el grafo de dependencias». Alinear la extensión de la solución con la versión que resuelva DA-3 y explicar en una línea `.sln` frente a `.slnx`.

---

## 2. Revisado y correcto

1. **Entidad con constructor privado y setters privados mapeada por Fluent API** (§1, líneas 38–55; §6, líneas 490–498). Es un patrón que EF Core admite, y el control que promete NC-03 se verifica: asignar `p.Precio = -5` desde afuera da `CS0272: The property or indexer 'Producto.Precio' cannot be used in this context because the set accessor is inaccessible` (E1, `run3.sh`).
2. **Refit genera la implementación en tiempo de compilación** (§8, línea 683; duda abierta en NC-05 y NC-10). Es correcto. El README de Refit dice: *«The `Refit` package ships Roslyn source generators. A `PackageReference` to Refit gets you generated clients at build time — no extra package.»* Hay que conservar la afirmación y citar la fuente.
3. **CQRS sin dos bases, inversión de dependencias y composition root** (§1, líneas 149–156 y 250; §2, línea 287; NC-02). La definición de CQRS («no implica dos bases de datos»), la explicación de que Infrastructure implementa interfaces declaradas adentro y la de que WebAPI referencia Infrastructure solo para registrar el DI son técnicamente correctas y coinciden con DC-1 y DC-3.

---

## 3. Posición sobre las decisiones abiertas

### DA-1 — Reestructuración `Backend/` y `Clients/`

**Propuesta: adoptarla, con dos niveles como máximo y sin la subcarpeta `Presentation` dentro de Backend.**

```text
src/
├── Backend/
│   ├── MyProject.Domain/
│   ├── MyProject.Application/
│   ├── MyProject.Infrastructure/
│   └── MyProject.WebAPI/
├── Clients/
│   ├── MyProject.WebFront/
│   ├── MyProject.Maui/          (hoy «Desktop», ver H-ARQ-05)
│   └── MyProject.Shared.UI/
└── Contracts/
    └── MyProject.Contracts/
tests/
├── Backend/  (Domain.Tests, Application.Tests, WebAPI.IntegrationTests)
└── Clients/  (opcional)
```

**Fundamento.**

1. **La carpeta refleja la unidad de despliegue.** El backend se despliega junto, como un proceso WebAPI que carga Domain, Application e Infrastructure, y cada cliente se despliega por separado. La estructura vigente agrupa por capa (`core/`, `infrastructure/`, `presentation/`), y así pone en la misma carpeta la WebAPI (el anillo exterior del backend) y apps que solo le hablan por HTTP. Esa mezcla es el origen de X-02 y del diagrama de §12 (H-ARQ-06).
2. **No se reproduce la cebolla en carpetas.** La propuesta de NC-06 (`Backend/Core/Domain`, `Backend/Presentation/WebAPI`) vuelve a codificar los anillos como anidamiento, justo la lectura de «contención» que DC-1 cerró. La regla de dependencia vive en los `<ProjectReference>`, no en las carpetas, y se verifica con `dotnet list reference` (E1). Las carpetas solo agrupan.
3. **`Contracts` va aparte**, porque es el único proyecto que referencian los dos mundos. Ponerlo dentro de `Backend/` o de `Clients/` le daría un dueño que no tiene.

**Lo que la guía debe declarar:** las carpetas físicas y las *solution folders* del `.sln`/`.slnx` son independientes. Ninguna de las dos hace cumplir la regla; solo las referencias lo hacen.

### DA-2 — `Contracts`: ¿opcional u obligatorio?

**Propuesta: obligatorio en la solución de referencia de la guía, y opcional como criterio general, con una condición explícita.**

- **Regla de criterio (para NC-09):** *si al menos un cliente .NET consume la API, existe `Contracts`*. Sin clientes .NET (la API la consume un front en otro lenguaje o nadie de la solución), no hace falta; el contrato es el OpenAPI.
- **En la guía** hay dos clientes .NET (WebFront y MAUI), así que en su propio caso es obligatorio. Presentarlo como opcional es lo que produce la contradicción de H-ARQ-03.
- **Contenido:** solo `record`s de request y response (`CrearProductoRequest`, `ProductoResponse`), sin comportamiento y sin paquetes, salvo quizá `System.ComponentModel.DataAnnotations` si se quiere validación compartida de formulario. No entran entidades, comandos ni interfaces de servicios del front.
- **Quién lo referencia:** WebAPI, WebFront y MAUI. **Application no.** Application devuelve sus propios modelos de lectura (ya existe `ProductoDto` junto a la query, §5, línea 410) y el controller los traduce a `ProductoResponse`. Así el formato de transporte no entra en el anillo de casos de uso, y el comando deja de ser el cuerpo HTTP (H-ARQ-03).
- **Costo que la guía debe mostrar, no esconder:** un mapeo más en el controller. Es exactamente la tensión «seis objetos por concepto» de NC-09. La guía debe presentar también la variante pragmática (Application → Contracts, sin mapeo) como apartamiento declarado, válido cuando la API es la única puerta de Application.
- **Interfaces del front** (`IProductoApiService`): no van en Contracts. La línea 875 lo sugiere, pero cada cliente tiene su propia capa de servicios (§11, líneas 869–873) y la interfaz depende de la librería HTTP elegida (H-ARQ-01, firmas Refit y manual distintas). Si hubiera que compartirla, correspondería un proyecto `Clients/MyProject.ApiClient`, no Contracts.

---

## 4. Solicitudes de convocatoria (fuera de mandato)

- **Seguridad:** el Resumen (línea 1003) asocia «JWT + Bearer» con «ASP.NET Core Identity». Microsoft Learn aclara, sobre los endpoints de Identity para SPA: *«The tokens aren't standard JSON Web Tokens (JWTs).»* El `AuthorizationMessageHandler` de §11 depende de un `ITokenService` que no se define. Pido que la especialidad Seguridad (no convocada, 4-1) evalúe si esta fila y el fragmento de autenticación se corrigen, se rotulan como ilustrativos o se retiran.
- **Ecosistema y licencias (AH-001):** `dotnet add package MediatR` resolvió la versión **14.2.0** en la corrida de `run2.sh`; la guía dice «MediatR 12» (línea 994). Además, la plantilla `webapi` de SDK 9 y 10 trae `Microsoft.AspNetCore.OpenApi` y no Swashbuckle (`run4.sh`), lo que afecta a «Scalar/Swagger» (línea 998) y a `ServiceCollectionExtensions` (línea 524). Lo derivo para DA-3 y DA-4; no me pronuncio sobre licencias.
