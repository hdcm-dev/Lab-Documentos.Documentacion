# Mesa — Ciclo 1 — Informe 06: Implementador ingenuo (lector novato)

**Fecha:** 2026-09-18
**Rol:** núcleo permanente, *Implementador ingenuo*, actuando como **lector novato**: sabe escribir clases en C#, nunca creó una solución de varios proyectos y no oyó hablar de Clean Architecture.
**Pregunta que responde:** ¿puede esta persona, leyendo la guía de corrido, construir lo que la guía describe sin preguntar nada? Cada pregunta que necesita hacer es un hallazgo.
**Artefacto:** `/LAB/Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md` (1003 líneas, commit 063f4e9). Números de línea referidos a esa versión.
**Trabajo a ciegas:** no se leyó ningún otro informe de `Mesa/Ciclo-1/`.

---

## 0. Método

1. Lectura lineal de la guía, de la línea 1 a la 1003, anotando cada punto en que el lector se detiene.
2. Intento de hacer lo que haría el lector: **copiar los fragmentos de código a proyectos reales y compilarlos**, en el contenedor `mcr.microsoft.com/dotnet/sdk:9.0` (la versión que la guía declara en la línea 4). Los guiones de la corrida están en el scratchpad de la sesión; se reproducen abajo en lo que importa.
3. Búsqueda textual de comandos y de definiciones de tipos que el código usa.

### 0.1 Corridas (E1)

**Corrida A — Domain tal como lo da la guía.** Se creó `MyProject.Domain` con `dotnet new classlib` y se pegaron las líneas 37–55 (`Producto`) y 67–76 (`Dinero`).

```
Entities/Producto.cs(14,36): error CS0246: The type or namespace name 'DomainException' could not be found
ValueObjects/Dinero.cs(7,46): error CS0246: The type or namespace name 'DomainException' could not be found
```

**Corrida B — Application tal como lo da la guía.** Tras agregar a mano un `DomainException` (que la guía no da), se creó `MyProject.Application`, se referenció Domain, se instalaron `MediatR 12.4.1` y `FluentValidation` (decisión del evaluador: la guía no dice cómo instalarlos) y se pegaron las líneas 430–456.

```
CrearProducto.cs(2,69):  error CS0246: 'IRequest<>' could not be found
CrearProducto.cs(5,39):  error CS0246: 'AbstractValidator<>' could not be found
CrearProducto.cs(15,37): error CS0246: 'IRequestHandler<,>' could not be found
CrearProducto.cs(17,22): error CS0246: 'IProductoRepository' could not be found
CrearProducto.cs(19,33): error CS0246: 'IProductoRepository' could not be found
```

Una observación lateral de la corrida A: al colocar `DomainException` en el espacio de nombres `MyProject.Domain` (lo que sugiere el árbol de la línea 360), el error persistió, porque los fragmentos de la guía no declaran `namespace` ni `using`. El lector no tiene forma de saber por qué.

**Búsqueda textual.** `grep -n "dotnet "` sobre la guía: **0 coincidencias**. `grep "class DomainException|interface IProductoRepository|AppDbContext :|GetById("`: **0 coincidencias**.

---

## 1. Hallazgos

### H-06-01 — La guía no tiene un solo comando: el lector no puede crear la solución que describe

- **Ubicación:** documento completo; en particular §3 (líneas 305–330) y §4–§7 (líneas 340, 376, 463, 505: «Tipo de proyecto: Class Library»).
- **Evidencia:** E1 (búsqueda textual: cero apariciones de `dotnet `) + E4 (contrato de entrada, restricción dura: «comandos que se puedan probar, con su resultado esperado y cómo analizarlo»).
- **Severidad:** S1.
- **Dónde me trabo.** La guía dice «Tipo de proyecto: Class Library (.NET)» y muestra un árbol con `src/core/…`, pero no dice cómo se crea una Class Library, cómo se agrega a `MyProject.sln`, cómo se hace que Application «dependa de» Domain, ni si `src/core/` es una carpeta del disco o una carpeta de la solución. Tampoco hay cómo comprobar que lo hice bien (`dotnet build`, `dotnet list reference`) ni qué salida debería ver. Sin eso, la tabla de reglas de §13 es una afirmación que no sé verificar: no sé qué significa físicamente «referenciar».
- **Propuesta de dirección.** Un recorrido de laboratorio (NC-08) que acompañe a los capítulos: `dotnet --version`, `dotnet new sln`, `dotnet new classlib -o src/…`, `dotnet sln add`, `dotnet add reference`, `dotnet list reference`, `dotnet build`, `dotnet run`, `curl`; para cada uno, la salida real capturada y un párrafo «cómo leerla». Incluir un paso que **rompa la regla a propósito** (Domain referenciando Infrastructure, referencia circular) y muestre el error, porque es lo que hace tangible la regla de dependencia.

### H-06-02 — Los fragmentos de código no compilan si se copian: faltan tipos, `using`, `namespace` y la instalación de paquetes

- **Ubicación:** líneas 50 y 73 (`DomainException`), 431–456 (Command/Validator/Handler), 552 (`nameof(GetById)`), 629–649 (Opción A).
- **Evidencia:** E1 (corridas A y B arriba) + E2.
- **Severidad:** S1.
- **Dónde me trabo.**
  - `DomainException` se usa tres veces y solo aparece como nombre de archivo en el árbol (línea 360); nunca se muestra su código. Corrida A: CS0246.
  - El Handler usa `IRequest`, `IRequestHandler`, `AbstractValidator`: la guía nombra MediatR y FluentValidation como «Dependencias» (línea 377) pero no dice que son paquetes NuGet, cómo se instalan ni qué `using` llevan. Corrida B: CS0246 aun con los paquetes instalados.
  - `IProductoRepository` se usa (líneas 446–453, `AddAsync`) pero su código no aparece en ninguna parte (búsqueda: 0). No sé qué firma escribir ni en qué archivo.
  - El controller devuelve `CreatedAtAction(nameof(GetById), …)` (línea 552) y la acción `GetById` no existe en la clase: no compila.
  - `ProductoApiService` (líneas 631–649) implementa `IProductoApiService` pero omite `GetByIdAsync` y `DeleteAsync` declarados en las líneas 621 y 623; una clase que no implementa todos los miembros de su interfaz no compila (CS0535).
  - Ningún fragmento indica en qué proyecto y archivo va, salvo por un comentario de ruta que a veces está (línea 37) y a veces no (línea 430 dice solo `CrearProductoCommand.cs`, cuando hay tres archivos pegados en un bloque).
- **Propuesta de dirección.** Distinguir de forma visible dos clases de fragmento: **«código del laboratorio»** (completo: ruta del archivo, `namespace`, `using`, paquete requerido; compilado de verdad en la corrida del laboratorio) y **«fragmento ilustrativo»** (rotulado como tal, sin promesa de compilar). Ningún tipo usado en código de laboratorio queda sin definir.

### H-06-03 — Faltan las piezas que conectan todo: no sé cómo llega el repositorio al Handler ni cómo arranca la API

- **Ubicación:** línea 250 («sin tocar una línea del dominio»), 483 (`DependencyInjection.cs`), 470 (`AppDbContext.cs`), 475 (`ProductoRepository.cs`), 477 (`Migrations/`), 528 (`Program.cs`), 950 («resueltas por DI»).
- **Evidencia:** E2 (los archivos se nombran en los árboles y ninguno se muestra; la frase «resueltas por DI» es la única mención de DI en la guía).
- **Severidad:** S1.
- **Dónde me trabo.** El Handler recibe `IProductoRepository` por constructor (línea 448). ¿Quién lo construye? La guía supone que sé qué es un contenedor de inyección de dependencias, qué es `builder.Services`, qué significa «registrar», y que `DependencyInjection.cs` contiene un *extension method* que alguien llama desde `Program.cs`. Nada de eso se explica ni se muestra. Tampoco se muestra `AppDbContext`, la implementación de `ProductoRepository`, la cadena de conexión ni cómo se crea la base (migraciones). Resultado: aunque arregle H-06-02, no puedo hacer arrancar la API ni ver un producto guardado. La afirmación central de la guía —«se puede reemplazar SQL Server por Postgres o por un doble en memoria sin tocar el dominio» (línea 250)— no la puedo comprobar.
- **Propuesta de dirección.** Definir DI en el capítulo de fundamentos (NC-01, concepto 8) y mostrar la cadena completa, una sola vez, en el laboratorio: interfaz → implementación → registro → `Program.cs` → petición HTTP que la atraviesa. Para demostrar la línea 250, el laboratorio puede cambiar la implementación registrada (en memoria ↔ EF) y mostrar que Domain no se recompila o no cambia.

### H-06-04 — Términos usados antes de definirse o nunca definidos

- **Ubicación:** el glosario empieza en «Entidad de Dominio» (línea 32); nunca define lo que está por debajo.
- **Evidencia:** E2.
- **Severidad:** S2.
- **Dónde me trabo.** Lista de términos que la guía usa sin definir, con la primera línea donde aparecen:

  | Término | Línea | Qué no sé |
  |---|---|---|
  | solución / `.sln`, proyecto, Class Library, referencia de proyecto | 258, 340 | qué es cada cosa y qué produce |
  | paquete NuGet | 341 («cero NuGet packages») | qué es, cómo se agrega |
  | `record` | 68, 92 | en qué se diferencia de `class`; la guía lo usa para VO y para DTO sin decir por qué |
  | inyección de dependencias, «inyectado» | 703, 950 | ver H-06-03 |
  | Fluent API, Code-First, `DbContext`, atributos de EF Core | 58, 137 | aparecen en §1, antes de que §6 muestre un ejemplo |
  | Vertical Slice | 379 | se presenta como la estructura «recomendada» sin definirse |
  | Pipeline / Behavior de MediatR | 386–387 | qué es un pipeline, cuándo se ejecuta |
  | Domain Events | 362 | «avanzado», sin más |
  | Middleware, ProblemDetails, CORS, Swagger/Scalar | 518, 524, 998 | — |
  | Blazor WASM vs Server | 263, 563 | cuál elijo y qué cambia |
  | `StateHasChanged()` | 708 | — |
  | JWT, Bearer, `DelegatingHandler`, `ITokenService` | 879–892 | `ITokenService` no existe en ningún árbol ni fragmento |
  | Interface Adapters, Frameworks & Drivers | 212, 210 | ver H-06-05 |

- **Propuesta de dirección.** Capítulo inicial de fundamentos del ecosistema (NC-01) antes del glosario de arquitectura, y regla editorial: **ningún término se usa antes de su definición**, o se usa con un enlace a ella. Lo que la guía decide no cubrir (Domain Events, JWT) se rotula «fuera de alcance» en vez de mencionarse de pasada.

### H-06-05 — Los diagramas me dicen cosas distintas que el texto

- **Ubicación:** líneas 241, 250, 285, 932–950, 813–814.
- **Evidencia:** E2 (citas contrapuestas).
- **Severidad:** S2.
- **Dónde me trabo.**
  1. Línea 241: «nunca hay una flecha que salga del centro hacia afuera». Línea 950 (diagrama §12): `APP -.->|"usa sus interfaces, resueltas por DI"| INF`, una flecha de Application hacia Infrastructure. ¿Application depende o no de Infrastructure?
  2. Línea 241: Domain, Application e Infrastructure son proyectos **hermanos** (DC-1). Diagrama §12 (líneas 932–942): los tres están **dentro** del recuadro `WebAPI (ASP.NET Core)`. Leo el dibujo y entiendo que Domain es parte de la WebAPI.
  3. Línea 250 remite a «la flecha de Infrastructure hacia Domain del diagrama de la sección 2», que todavía no vi. Cuando llego a §2, la flecha rotulada «implementa sus interfaces» (línea 285) va de Infrastructure a **Application**, mientras que la línea 250 dice que la interfaz del repositorio está en **Domain**.
  4. El diagrama de anillos (líneas 208–239) y la tabla de la línea 243 hablan de cuatro anillos; la solución tiene cuatro proyectos de backend, pero los nombres no coinciden y nadie los pone en correspondencia. «Repositorios EF Core» está en *Interface Adapters* (línea 221) y «EF Core» en *Frameworks & Drivers* (línea 223): ¿el proyecto Infrastructure es uno u otro anillo? ¿Y WebAPI?
  5. Línea 814: MAUI Hybrid «funciona offline». Línea 825: el Desktop llama a la WebAPI por HTTP igual que el WebFront. ¿Funciona offline o no?
- **Propuesta de dirección.** Una sola tabla de correspondencia *anillo de Martin ↔ proyecto de la solución*, y todos los diagramas derivados de ella con la misma convención de flecha («A → B» = «A referencia a B»); si una flecha representa otra cosa (llamada en tiempo de ejecución, HTTP), se dibuja con otro trazo y se dice en la leyenda. Ningún diagrama se referencia antes de mostrarse. Precisar «offline» (qué funciona sin red: la UI empaquetada, no los datos).

### H-06-06 — No sé qué clase viaja por cada tramo ni de qué proyecto la saco

- **Ubicación:** líneas 91–95, 324, 410, 415–416, 549, 620–622, 737, 747, 980.
- **Evidencia:** E3 (contraejemplo) + E2.
- **Severidad:** S2.
- **Contraejemplo.** Sigo §13 al pie de la letra: WebFront referencia solo `Shared.UI` y `Contracts` (línea 980). Escribo `IProductoApiService` como en la línea 620, que usa `ProductoResponseDto` y `CrearProductoRequestDto`. Esos tipos están definidos en `MyProject.Application` (línea 91), que WebFront **no puede** referenciar (línea 980), y `Contracts` es «opcional» (línea 324) y nunca se muestra su contenido. El proyecto no compila y la guía no me dice cuál de las dos reglas romper.
- **Otras trabas del mismo tramo.**
  - El controller recibe un `CrearProductoCommand` (línea 549); el front envía un `CrearProductoRequestDto` (línea 622). ¿Son el mismo JSON? ¿Quién convierte uno en otro?
  - Dos nombres para el DTO de respuesta: `ProductoDto` (línea 410) y `ProductoResponseDto` (línea 416); dos rutas: `Application/Products/DTOs/` (línea 91) y `Application/Features/Productos/DTOs/` (línea 415).
  - `ProductoMapper.ToViewModel` (línea 747) y el componente `<ProductosTabla>` (línea 737) se usan y no se muestran; `ProductosTabla` no figura en el árbol de Shared.UI (líneas 771–792) ni en el de WebFront.
- **Propuesta de dirección.** Un diagrama o tabla de «recorrido de un dato»: formulario (ViewModel) → DTO de request → HTTP → Command → entidad → persistencia → entidad → DTO de response → HTTP → ViewModel, con el proyecto dueño de cada tipo. Depende de DA-2 (ver §3).

### H-06-07 — Tengo definiciones, pero no el criterio para elegir entre objetos parecidos ni para saber si necesito todo esto

- **Ubicación:** línea 104 («ViewModel: Similar al DTO»), 85–98, 141–156, y ausencia de toda sección de criterio.
- **Evidencia:** E2 + E4 (contrato de entrada: «preguntas guía con respuestas explicativas, formadoras de criterio»; «incorporar “Cada objeto responde una pregunta” con respuesta explicativa»).
- **Severidad:** S2.
- **Dónde me trabo.** Termino §1 con seis clases que «transportan datos de un producto» (entidad, DTO request, DTO response, ViewModel, Command, modelo de persistencia) y no sé cuál poner en mi formulario, ni por qué no me alcanza con una sola. La guía dice que el ViewModel es «similar al DTO» (línea 104) sin decir qué los separa. Tampoco dice cuándo **no** hace falta esta estructura: si mi problema es un ABM chico en Blazor Server, ¿igual necesito seis proyectos, MediatR y Refit? La tabla final (líneas 989–1003) presenta cada tecnología como la decisión, sin alternativa ni condición.
- **Propuesta de dirección.** Para cada objeto, la pregunta que responde y un contraste «qué pasa si uso otro en su lugar» (por ejemplo: el setter público que pide `@bind-Value` contra el setter privado que protege la regla del precio). Un capítulo de criterios de diseño (NC-09) con el caso «cuándo alcanza página → servicio → EF» y las señales que justifican pasar a Clean. Esto queda del lado de Requisitos y Didáctica; lo registro porque es la pregunta que el lector novato se hace al final de §1.

---

## 2. Revisado y correcto

1. **Explicación de los anillos como dependencia y no como ubicación (línea 241).** Es la frase que más me ordenó: dice explícitamente que los anillos no son carpetas anidadas y que los proyectos son hermanos. Coincide con DC-1. Lo que falla es que los diagramas posteriores no la respetan (H-06-05), no el texto.
2. **La entidad `Producto` con setters privados y fábrica `Create` (líneas 36–58).** Aun sin conocer la arquitectura, el ejemplo se entiende: el comentario explica por qué el constructor es privado y la validación del precio muestra qué significa «comportamiento» en una entidad. Una vez agregado `DomainException`, la clase compila (corrida B partió de ella sin error propio).
3. **El principio de la capa de servicios del front (línea 614).** Está dicho con su porqué («permite testear los componentes sin hacer llamadas HTTP reales») y el diagrama de la línea 703 lo refuerza sin contradecirlo.

---

## 3. Posición sobre decisiones abiertas (solo desde la lectura novata)

- **DA-2 (Contracts).** Desde el lector novato: cualquiera sea la decisión, tiene que existir **un solo lugar** del que el front obtiene los DTOs, dicho en la tabla de §13 y mostrado en el laboratorio. «Opcional» sin mostrar el caso sin Contracts produce el contraejemplo de H-06-06. Si se mantiene opcional, la guía debe mostrar las dos variantes (con Contracts; con DTOs duplicados en el cliente) y el criterio para elegir.
- **DA-1 (Backend/ vs Clients/).** Una estructura que separe «lo que es el backend» de «lo que son clientes» me hubiera evitado la confusión de H-06-05 punto 2. No es evidencia de que sea mejor en general; es evidencia de que la actual `presentation/` (líneas 317–321), que junta WebAPI con WebFront, contribuye a que el lector ubique mal la WebAPI.
- **DA-3 / DA-4.** Fuera de mi mandato. Solo observo que el lector necesita que la guía diga **qué versión del SDK** asume y **cómo comprobar la suya** (`dotnet --version`), porque la plantilla que genera `dotnet new` cambia con la versión.

---

## 4. Solicitudes de convocatoria

1. **AH-001 (ecosistema y licencias):** la guía afirma que Refit «genera la implementación en tiempo de compilación» (línea 683) y fija «MediatR 12», «EF Core 9», «.NET 9» (líneas 994–997). No lo verifico: es su mandato.
2. **Verificación / QA:** las corridas A y B de este informe usaron una versión de MediatR elegida por el evaluador (12.4.1) porque la guía no la fija; QA debería decidir qué versión compila el laboratorio y capturar su salida.
3. **Seguridad (no convocada):** el fragmento de autenticación (líneas 877–909) depende de un `ITokenService` inexistente y de conceptos no definidos (JWT, Bearer). Si la mesa decide mantenerlo, conviene que alguien con ese mandato diga si se explica o se declara fuera de alcance.
