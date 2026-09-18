# Mesa evaluadora, ciclo 1: informe de Verificación / QA

**Rol:** núcleo permanente, Verificación / QA (Mesa-Evaluadora §4.1.1)
**Pregunta del mandato:** ¿cómo se prueba cada afirmación y cada comando de la guía reeditada?
**Objeto revisado:** guía vigente `LAB/Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md` (1003 líneas), contrato de entrada (Bitácora 01), núcleos NC-00 a NC-10 y registro de convocatoria.
**Condición de trabajo:** a ciegas. No leí otros informes de `Ciclo-1/` ni ejecuté docker. Todo lo que afirmo sobre el comportamiento del SDK viene de una fuente citada con URL o está marcado como conjetura (C) que el laboratorio tiene que confirmar.

---

## Índice

1. [Síntesis](#1-síntesis)
2. [Hallazgos](#2-hallazgos)
3. [Propuesta: laboratorio mínimo ejecutable](#3-propuesta-laboratorio-mínimo-ejecutable)
4. [Revisado y correcto](#4-revisado-y-correcto)
5. [Solicitudes de convocatoria](#5-solicitudes-de-convocatoria)
6. [Fuentes consultadas](#6-fuentes-consultadas)

---

## 1. Síntesis

El plan ya acierta en el principio: toda salida viene de una corrida y lo que no se ejecutó se rotula como ilustrativo (NC-08). Le falta el mecanismo que haga ese principio verificable. Hoy no hay forma de comprobar que la salida publicada en la guía salió de una corrida, con qué SDK se hizo ni qué partes de esa salida cambian en cada ejecución. Además, tres de las «salidas esperadas» que los núcleos ya anticipan probablemente no coincidan con lo que va a devolver la máquina:

- el 400 por un precio negativo;
- el CS0246 como único error;
- el rechazo del ciclo de referencias con un código de error conocido de antemano.

Si la guía las fija antes de capturarlas, viola la restricción dura «no inventar».

---

## 2. Hallazgos

### QA-01. No hay protocolo de captura. «Las salidas son reales» no se puede verificar

- **Ubicación:** NC-08 §Principio y §Cada paso documenta; Bitácora 01 §1.1, fila «Pruebas sobre el servicio».
- **Afirmación:** NC-08 exige que «toda salida mostrada en la guía proviene de una corrida registrada en `OUTPUTs/Laboratorio/`», pero no define:
  - qué se registra de cada corrida: imagen y digest, `dotnet --info`, comando, código de salida y salida cruda;
  - cómo se distinguen en una salida los campos invariantes (código de error, estado HTTP, nombre de proyecto) de los variables (Guid, tiempos, rutas, puertos);
  - cómo se vuelve a ejecutar la corrida.

  Sin esas tres cosas, un revisor del ciclo 2 no puede distinguir una captura real de una salida verosímil escrita a mano. La restricción «no inventar» se vuelve una declaración de buena fe.
- **Evidencia:** E4. La restricción dura del contrato dice «No inventar información; toda afirmación respaldada por evidencia verificable», y el supuesto de la Bitácora 01 dice «las salidas mostradas son capturas reales». E2: NC-08 no tiene campos de trazabilidad.
- **Severidad:** S1. Sin este mecanismo no se puede cumplir, ni comprobar que se cumplió, una restricción dura. Es la condición previa del resto del laboratorio.
- **Confianza:** 0,9.
- **Propuesta de dirección:**
  1. Un único guion `Laboratorio/lab.sh` que corre dentro de `docker run --rm -v "$PWD":/lab -w /lab mcr.microsoft.com/dotnet/sdk:<tag>`.
  2. Cada paso escribe `Laboratorio/capturas/NN-<nombre>.txt` con encabezado (fecha, imagen y digest, `dotnet --version`, comando literal, código de salida) y la salida cruda sin editar.
  3. Cada paso lleva una **aserción** sobre sus invariantes: `grep -q 'error CS0272'`, código HTTP con `curl -w '%{http_code}'`, `test $? -ne 0` en los errores provocados. El guion falla si una aserción no se cumple.
  4. Cada aserción se ve fallar al menos una vez. Por ejemplo, se corre el paso CS0272 con el setter en `public` y se registra que la aserción lo detecta. Una prueba que nunca se vio fallar no prueba nada.
  5. En la guía, cada bloque de salida lleva el rótulo `Salida real — captura NN` y una nota **«qué cambia en su equipo»**: Guid, tiempos, rutas y puertos. Así el lector novato no confunde una diferencia esperable con un error.

### QA-02. Las salidas dependen de la versión del SDK y la guía todavía no la fijó (DA-3)

- **Ubicación:** guía vigente, encabezado «Stack: .NET 9»; NC-08 §Entorno («`sdk:<versión>`»); DA-3 abierta.
- **Afirmación:** en los comandos de este laboratorio, la salida y el comportamiento cambian entre las imágenes 8.0, 9.0 y 10.0:
  - Desde .NET 10, `dotnet new sln` crea `.slnx` por defecto. En 9.0.200 y posteriores se elige con `--format`.
  - .NET 10 agrega las formas «sustantivo primero» (`dotnet reference add` y `dotnet reference list`) y recomienda usarlas en guiones y documentación.
  - `dotnet new webapi` genera minimal APIs por defecto. El controller de la guía (§7) necesita `--use-controllers`, opción disponible desde el SDK de .NET 8.

  Una salida capturada con una imagen y leída por alguien que usa otra deja de coincidir en el primer comando: `.sln` contra `.slnx`.
- **Evidencia:** E2 externa (Microsoft Learn, «.NET default templates», sección `sln`: «Starting with .NET 10, the default format is `slnx`»; sección `webapi`: «entering `dotnet new webapi` without specifying either option creates a minimal API project»; «What's new in the SDK for .NET 10», «More consistent command order»). E2 interna: el encabezado de la guía dice «.NET 9».
- **Severidad:** S2. Es ejecutable, pero hay una alta probabilidad de que el lector novato vea una salida distinta y crea que se equivocó.
- **Confianza:** 0,85.
- **Propuesta de dirección:**
  - Correr el laboratorio **una sola vez, con la versión que el jurado adopte en DA-3**, y fijarla con `global.json` (`dotnet new globaljson --sdk-version …`) más el tag completo de la imagen.
  - Anotar en la guía, en una tabla, las diferencias conocidas de los comandos usados si el lector tiene otra versión: `.sln`/`.slnx`, forma del comando y `--use-controllers`.
  - Usar siempre `--use-controllers` (o bien, si el arquitecto lo decide, minimal APIs de forma explícita), y nunca el valor por defecto implícito.
  - Si el jurado elige .NET 10, conviene usar la forma `dotnet reference add` y mencionar la forma verbo-primero como alias.

### QA-03. El «400 por validación» que prevé NC-04 no sale de ninguno de los mecanismos que describe la guía

- **Ubicación:** NC-04 §Evidencia («`POST` con precio negativo → 400/422 con ProblemDetails»); guía §1 `Producto.Create` (`throw new DomainException`); §5 `CrearProductoValidator` con pipeline MediatR; §7 `ExceptionHandlingMiddleware` nombrado y nunca mostrado.
- **Afirmación:** `[ApiController]` produce un 400 automático solo cuando falla la **validación del modelo** (model state), por ejemplo un JSON mal formado o un atributo `[Required]` o `[Range]` sobre el tipo que se enlaza. Un `decimal Precio = -5` pasa la vinculación sin problemas. El rechazo ocurre después:
  - por un `DomainException` en `Producto.Create`;
  - o por un `ValidationException` de FluentValidation en el pipeline.

  Si no hay un manejador de excepciones que las traduzca, ninguna de las dos produce un 400. Contraejemplo: `POST /api/productos {"nombre":"x","precio":-5}` con el código de la guía tal como está da un error 500, no un 400. Además, sin entorno `Development` ese 500 llega con el cuerpo vacío.
- **Evidencia:** E3 (contraejemplo construido), apoyado en E2 externa: Microsoft Learn, «Create web APIs with ASP.NET Core», §Automatic HTTP 400 responses: «The `[ApiController]` attribute makes model validation errors automatically trigger an HTTP 400 response» y «The default response type for an HTTP 400 response is `ValidationProblemDetails`». El código exacto del 500 y su cuerpo quedan como C hasta que se capturen.
- **Severidad:** S2. Si la guía muestra «400» sin haberlo capturado, está inventando. Si lo captura, va a obtener otro resultado y el texto se tiene que reescribir.
- **Confianza:** 0,8.
- **Propuesta de dirección:** convertir la discrepancia en contenido didáctico con **tres capturas distintas**, porque cada una enseña una capa:
  1. **400 de la capa Web.** Enviar un cuerpo mal formado, o un request DTO con `[Required]`, y mostrar el `ValidationProblemDetails`. Enseña que ASP.NET valida la forma.
  2. **500 provocado a propósito.** Precio negativo sin manejador. Enseña que la regla de negocio vive en Domain, que Domain no sabe de HTTP y que alguien tiene que traducir el error.
  3. **400 o 422 con ProblemDetails.** El mismo pedido después de agregar el manejador en WebAPI (composition root). Enseña a qué capa pertenece esa traducción.

  El jurado y el arquitecto eligen el código de estado (400 o 422) y el mecanismo (middleware o `IExceptionHandler`). QA solo exige que la guía muestre lo que se capturó.

### QA-04. Los errores provocados que anticipan los núcleos pueden no ser los que emite el compilador

- **Ubicación:** NC-01 §Preguntas guía («¿Qué pasa si dos proyectos se referencian mutuamente? → el SDK lo rechaza») y §Evidencia («error CS0246 por tipo no referenciado»); NC-03 §Evidencia (CS0272); NC-02 §Evidencia (error de ciclo).
- **Afirmación:** en tres de los cuatro errores provocados, la redacción de la guía podría fijar un código o un momento de falla que no coincide con la corrida:
  - **Tipo no referenciado.** Si el lector escribe `using MyProject.Infrastructure;` en un proyecto Domain cuyo namespace raíz también es `MyProject`, el primer diagnóstico esperable es CS0234 («the type or namespace name 'Infrastructure' does not exist in the namespace 'MyProject'»). Solo después aparece CS0246 por el tipo. Esto es C, a confirmar. Una guía que promete «CS0246» y muestra otra cosa desorienta al lector novato.
  - **Setter privado.** CS0272 aparece si se asigna la propiedad a una instancia existente: `var p = Producto.Create("x", 10); p.Precio = 5;`. Si el lector intenta `new Producto { Precio = 5 }`, el constructor privado (`private Producto() { }` en la guía §1) falla antes, con un error de accesibilidad del constructor y no con CS0272. Esto es E3.
  - **Ciclo de referencias.** No se sabe si `dotnet add reference` rechaza el ciclo al agregarlo o si lo acepta y la falla aparece en `restore`/`build`, ni con qué código. La página de NU1108 («Cycle detected: A -> B -> A») describe el caso de paquetes. No encontré documentado el caso de `ProjectReference`. Esto es C.
- **Evidencia:** E3 para CS0272 frente al constructor privado (a partir de la cita literal de la guía §1 y del mensaje oficial de CS0272: «The property or indexer … cannot be used in this context because the set accessor is inaccessible»). C para CS0234 y para el ciclo.
- **Severidad:** S2.
- **Confianza:** 0,7.
- **Propuesta de dirección:**
  - Ninguna prosa de la guía nombra un código de error antes de que exista su captura.
  - El guion registra **los dos momentos** del ciclo por separado: la salida de `add reference` y la de `build`. La guía explica el que efectivamente ocurre.
  - Cada error provocado se documenta con cuatro cosas: la línea exacta que lo provoca, la salida real y **cómo leerla** (archivo(línea,col): error CÓDIGO: mensaje [proyecto]), y la corrección que lo hace desaparecer, también capturada.

### QA-05. Los fragmentos de la guía vigente no compilan tal como están y la salida del build tendrá advertencias no explicadas

- **Ubicación:** guía §7, `return CreatedAtAction(nameof(GetById), new { id }, null);` sin acción `GetById` (X-03 en NC-00); §1 `DomainException` sin definir; §1 y §8 propiedades `string` no nulables sin inicializar (`public string Nombre { get; private set; }` con constructor privado vacío; ViewModel con `public string Nombre { get; set; }`).
- **Afirmación:**
  - `nameof(GetById)` sin miembro que se llame así no compila. Es un error del compilador por nombre inexistente (código a capturar).
  - Con `<Nullable>enable</Nullable>`, que es lo que traen las plantillas actuales (C, a confirmar mirando el `.csproj` generado), las propiedades `string` sin inicializar generan advertencias de nulabilidad.

  El lector novato espera un «Build succeeded» limpio y ve advertencias que la guía no menciona.
- **Evidencia:** E2 (citas literales con ubicación) y E3 (el fragmento, compilado tal cual, no puede resolver `GetById`). C para el código exacto de la advertencia de nulabilidad.
- **Severidad:** S2.
- **Confianza:** 0,8.
- **Propuesta de dirección:** invertir la dirección de los ejemplos. **Todo fragmento de código de la guía se extrae de los fuentes del laboratorio** (`Laboratorio/src/…`), lleva como primera línea la ruta del archivo y queda cubierto por el build capturado.
  - Los fragmentos que no se compilan (MAUI, Refit, JWT) llevan el rótulo «Ilustrativo — no compilado en el laboratorio».
  - El build de referencia se corre con `-warnaserror`, o bien la guía explica cada advertencia que aparezca. No se muestra ninguna salida recortada para ocultar advertencias.

### QA-06. Levantar y consultar la API dentro del contenedor tiene trampas que cambian la salida

- **Ubicación:** NC-08 §Recorrido, paso 6 («Compilar y correr la API; probar con `curl`»); NC-05 §Evidencia («al menos `curl` como cliente HTTP genérico»).
- **Afirmación:** el paso 6 tal como está redactado no alcanza para reproducir la salida:
  - Las plantillas web guardan en `Properties/launchSettings.json` un puerto HTTP elegido al azar entre 5000 y 5300. Por eso la URL de los `curl` de la guía no coincide con la del lector.
  - Si se omite el perfil de lanzamiento, la aplicación arranca en entorno Production. Esto es C: afecta si se expone OpenAPI y qué cuerpo trae un 500.
  - No verifiqué que `curl` venga incluido en la imagen `sdk` (C).
  - El proceso de la API tiene que quedar corriendo mientras se ejecutan los `curl`.
- **Evidencia:** E2 externa: Microsoft Learn, «Configure endpoints for Kestrel»: «The configuration selects a random HTTP port between 5000-5300 … stored in the generated *Properties/launchSettings.json*». Además, las plantillas aceptan `--exclude-launch-settings` y `--no-https` («.NET default templates», sección `webapi`). El resto es C.
- **Severidad:** S3. Se resuelve con una receta fija, sin retrabajo conceptual.
- **Confianza:** 0,75.
- **Propuesta de dirección:** receta única y explícita:
  1. Crear el proyecto con `dotnet new webapi --use-controllers --no-https`.
  2. Arrancar con `ASPNETCORE_ENVIRONMENT=Development dotnet run --no-launch-profile --urls http://0.0.0.0:5080 &`.
  3. Esperar a que conteste con un bucle sobre `curl -s -o /dev/null -w '%{http_code}'`.
  4. Consultar siempre con `curl -s -i` (se ve el estado y los encabezados, que es lo que el lector tiene que aprender a leer).

  El paso 0 del laboratorio incluye `curl --version`. Si falla, la guía indica otra vía: `docker exec` desde otro contenedor, o un cliente de consola de .NET, que además sirve como ejemplo de «cliente que solo habla HTTP».

### QA-07. Falta un esquema de rotulado para separar lo ejecutado de lo ilustrativo, y hay afirmaciones baratas de probar que hoy quedarían sin prueba

- **Ubicación:** NC-05 («MAUI: fuera del laboratorio… fragmento ilustrativo»); guía §8 («Refit la genera en tiempo de compilación»); conversación de origen incorporada en NC-03 («En Blazor WASM… el front… ni siquiera tiene el ensamblado del dominio»); NC-02 («reemplazar la base o testear con un doble sin tocar Domain»).
- **Afirmación:** el plan solo distingue entre «ejecutado» e «ilustrativo». Una guía de consulta necesita que el lector sepa, afirmación por afirmación, **qué tan probada está**. Además, hay afirmaciones centrales para formar criterio que se pueden probar con poco costo y hoy no tienen paso asignado:
  - «Cambiar la implementación del repositorio no toca Domain» se prueba: compilar, cambiar la implementación registrada y verificar que el ensamblado de Domain no se recompiló o que su hash no cambió. Hoy NC-08 paso 8 lo menciona sin criterio de verificación.
  - «La WebAPI referencia Infrastructure solo para el DI» se prueba con `dotnet reference list` y con un `grep` que muestre que no hay `using …Infrastructure` fuera de `Program.cs`.
  - «Un cliente que solo habla HTTP no necesita Domain» se prueba con una app de consola, o con `blazorwasm` si el arquitecto lo decide (C: no verifiqué si necesita workloads), que compile y consuma la API sin `ProjectReference` a Domain.
- **Evidencia:** E4 (restricción «toda afirmación respaldada por evidencia verificable») y E2 (citas de NC-02, NC-05 y NC-08 sin criterio de verificación).
- **Severidad:** S3.
- **Confianza:** 0,7.
- **Propuesta de dirección:** un rótulo de tres niveles, visible en la guía:
  - **[Ejecutado · captura NN]**: comando corrido, con salida real.
  - **[Compilado]**: código que forma parte de un build capturado.
  - **[Ilustrativo]**: fragmento no compilado, con el motivo (por ejemplo, «MAUI requiere workloads fuera del alcance»).

  Las afirmaciones sobre terceros (licencias, Refit, versiones) llevan **[Fuente: URL]** y no un rótulo de ejecución. Las tres pruebas anteriores se agregan al laboratorio porque cuestan un comando cada una.

---

## 3. Propuesta: laboratorio mínimo ejecutable

**Criterio de recorte:** entra todo lo que demuestra una **regla de dependencia** o una **responsabilidad de capa** con un solo comando y sin paquetes de terceros de licencia dudosa. Por eso el recorrido no usa MediatR ni AutoMapper (DA-4): los handlers se inyectan directamente y el mapeo es manual. Si el jurado decide incluirlos, se agregan como variante ilustrativa. Solo necesitan red para restaurar paquetes de nuget.org la plantilla de tests y, si se usa, EF Core.

**Entorno:** `docker run --rm -it -v "$PWD":/lab -w /lab mcr.microsoft.com/dotnet/sdk:<versión DA-3>`, con `global.json` fijado. Nombres según DC-2 y DC-4.

| # | Comando(s) | Salida que se captura | Concepto que demuestra | Aserción del guion |
|---|---|---|---|---|
| 0 | `dotnet --info`; `curl --version` | Versión del SDK, RID, runtimes | El SDK es la herramienta; la versión condiciona el resto (QA-02) | versión = la de `global.json` |
| 1 | `dotnet new sln -n MyProject` | Archivo `.sln`/`.slnx` creado | Una solución agrupa proyectos y no compila nada | el archivo existe |
| 2 | `dotnet new classlib -n MyProject.Domain -o src/Backend/Core/MyProject.Domain` (ídem Application e Infrastructure); `dotnet new webapi --use-controllers --no-https -n MyProject.WebAPI …` | Mensajes de creación | Proyecto = unidad de compilación; hay tipos de plantilla | código de salida 0 |
| 3 | `dotnet sln add …` ×4; `dotnet sln list` | Lista de proyectos | Relación solución–proyecto | 4 líneas de proyecto |
| 4 | `dotnet reference add` según la regla (Application→Domain; Infrastructure→Application, Domain; WebAPI→Application, Infrastructure); `dotnet reference list` por proyecto | Referencias de cada proyecto | La referencia es una flecha con dirección; Domain no tiene ninguna | Domain lista 0 referencias |
| 5 | `dotnet build` | «Build succeeded», 0 advertencias | Punto de partida sano | código 0; `0 Warning(s)` |
| 6 | **Error provocado:** en Domain, `using MyProject.Infrastructure;` y un uso de un tipo de Infrastructure; `dotnet build` | `error CS02xx` con archivo, línea y columna | Namespace ≠ referencia; sin flecha no hay tipo | código ≠ 0; `grep 'error CS0'` |
| 7 | **Error provocado:** `dotnet reference add` de Domain→Infrastructure (ciclo); luego `dotnet build` | Las **dos** salidas, por separado | La regla de dependencia es física: el SDK no admite el ciclo (el momento y el código se confirman acá, QA-04) | alguno de los dos ≠ 0 |
| 8 | Deshacer 6 y 7 (`dotnet reference remove`); `dotnet build` | Vuelve el build limpio | Reversibilidad; leer el diff | código 0 |
| 9 | **Error provocado:** en Application, `var p = Producto.Create("x", 10); p.Precio = 5;` → `dotnet build` | `error CS0272` | El setter privado protege la regla del negocio | `grep 'CS0272'` |
| 10 | Test de dominio con xUnit: `Producto.Create("x", -5)` lanza `DomainException`; test del handler con un repositorio en memoria; `dotnet test` | «Passed: N, Failed: 0» | La regla vive en Domain y se prueba sin base de datos ni HTTP (DIP) | `Failed: 0`; ver fallar una vez (QA-01) |
| 11 | Arrancar la API (receta de QA-06); `curl -s -i -X POST …/api/productos -d '{"nombre":"Mesa","precio":1500}'` | `HTTP/1.1 201` + encabezado `Location` | Controller delgado → caso de uso → dominio | estado 201 |
| 12 | `curl -s -i …/api/productos` | `200` + JSON con **solo** los campos del DTO | El contrato filtra: la entidad no sale al cliente | 200; las claves del JSON coinciden con el DTO |
| 13 | **Error provocado:** `POST` con JSON mal formado | `400` + `ValidationProblemDetails` | Validación de forma: la hace la capa Web, automáticamente | estado 400 |
| 14 | **Error provocado:** `POST` con `precio: -5` **sin** manejador | `500` | La regla de negocio rechaza, pero nadie la traduce a HTTP | estado 500 |
| 15 | Agregar el manejador de excepciones en WebAPI; repetir el 14 | `400`/`422` + ProblemDetails | La traducción de errores pertenece al composition root | estado según la decisión del jurado |
| 16 | Cambiar la implementación del repositorio (lista en memoria → EF Core InMemory o Sqlite, según el arquitecto) tocando solo Infrastructure y `Program.cs`; `dotnet build -v n` y hash de `MyProject.Domain.dll` antes y después | Domain no se recompila (o el hash coincide); `curl` del paso 12 repite el resultado | Inversión de dependencias: se reemplaza lo de afuera sin tocar lo de adentro | hash igual; 200 |
| 17 | `grep -rn 'Infrastructure' src/Backend/Presentation` | Solo `Program.cs` | WebAPI conoce Infrastructure solo para registrar el DI | una única coincidencia |
| 18 | *(opcional)* Cliente de consola `dotnet new console` que llama a la API con `HttpClient` y **no** referencia Domain | Lista de productos impresa | Un cliente que solo habla HTTP vive con DTOs o Contracts (DA-2) | salida con N productos |

**Queda como fragmento ilustrativo, rotulado [Ilustrativo] con su motivo:**

- MAUI Blazor Hybrid y `BlazorWebView`: requieren workloads, fuera de alcance según el contrato.
- Refit y su generación de código: solo con [Fuente: URL], salvo que el jurado decida compilarlo.
- `AuthorizationMessageHandler` y JWT: la seguridad no fue convocada.
- MediatR, AutoMapper y pipeline behaviors: dependen de DA-4.
- Shared.UI (RCL): se puede compilar si el arquitecto lo pide; no aporta a ninguna regla que no demuestren los pasos 4 a 7.

**Presentación en la guía:** cada paso ocupa un bloque con este orden fijo: **objetivo → comando → salida real (captura NN) → cómo leerla → qué concepto confirma → qué cambia en su equipo**. Los pasos 6, 7, 9, 13 y 14 se presentan como «predecí antes de ejecutar». Esa es la versión ejecutable del patrón pregunta → respuesta del estilo exigido.

---

## 4. Revisado y correcto

1. **El principio de NC-08** («toda salida mostrada… proviene de una corrida registrada; lo que no se ejecutó se rotula fragmento ilustrativo») es correcto y basta como política. Lo que le falta es el mecanismo (QA-01), no el criterio.
2. **CS0272 es el código correcto** para asignar desde afuera una propiedad con `private set` sobre una instancia existente. Coincide con el mensaje y el ejemplo oficiales (Microsoft Learn, Compiler Error CS0272), siempre que se provoque como indica QA-04.
3. **Dejar MAUI fuera del laboratorio** (contrato, `fuera_de_alcance`; NC-05) es coherente con el entorno disponible y con la regla «no inventar», siempre que se rotule como ilustrativo.

---

## 5. Solicitudes de convocatoria

- **Arquitecto .NET:**
  - qué mecanismo y qué código de estado (400 o 422) se enseña para los errores de dominio (QA-03, paso 15);
  - controllers o minimal APIs (QA-02);
  - qué implementación alternativa del repositorio se usa en el paso 16;
  - si el cliente del paso 18 es de consola o `blazorwasm`.
- **Ad hoc AH-001 (ecosistema y versionado):** la versión fijada por DA-3 condiciona todas las capturas. Hace falta decidirla **antes** de correr el laboratorio. También hace falta la decisión DA-4 para saber si MediatR y AutoMapper entran como compilados o como ilustrativos.
- **Didáctica:** si el laboratorio va intercalado en cada capítulo (NC-00 lo dibuja como una «columna que acompaña») o en un capítulo propio con remisiones. Afecta cómo se numeran y citan las capturas.

---

## 6. Fuentes consultadas

- Microsoft Learn, «.NET default templates for dotnet new» (secciones `sln` y `webapi`): https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new-sdk-templates
- Microsoft Learn, «What's new in the SDK and tooling for .NET 10» (§More consistent command order): https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10/sdk
- Microsoft Learn, «Create web APIs with ASP.NET Core» (§Automatic HTTP 400 responses): https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-9.0
- Microsoft Learn, «Configure endpoints for the ASP.NET Core Kestrel web server»: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel/endpoints?view=aspnetcore-10.0
- Microsoft Learn, «Compiler Error CS0272»: https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs0272
- Microsoft Learn, «NuGet Error NU1108»: https://learn.microsoft.com/en-us/nuget/reference/errors-and-warnings/nu1108
