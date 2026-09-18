# Ciclo 2 — Informe del Lector Novato (implementador ingenuo)

**Fecha:** 2026-09-18
**Objeto:** `LAB/Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md` v2.0.0 (1309 líneas) y `Dot-NET-Arquitectura-Lab/` (lab.sh, capturas/, aserciones.log, MyProject/).
**Mandato (§4.1.4):** leer de corrido como alguien que sabe algo de C#, nunca armó una solución de varios proyectos y no conoce HTTP en profundidad, con una terminal al lado. Cada punto donde me trabo es un hallazgo. No opino de arquitectura, estilo ni citas.
**Método:** lectura lineal §0 → Anexo E siguiendo el recorrido de §0.3; cada comando o salida que la guía muestra se contrastó con `capturas/` y con `lab.sh` (el guion que sí ejecutó los pasos). Trabajé a ciegas respecto de los otros informes del ciclo 2.

**Resumen:** el documento se lee bien y las salidas mostradas son reales; donde me trabo es en la **brecha entre lo que la guía muestra y lo que hay que tener escrito para que el paso siguiente compile o corra**. Hay tres puntos S2 (tipos que se nombran pero nunca se muestran ni se dice dónde están; pasos Lnn sin el comando que los ejecuta; el arranque de la API sin carpeta ni segunda terminal) y cuatro S3.

---

## 1. Hallazgos

### H-NOV-01 — Tipos que el laboratorio necesita y la guía nombra pero nunca muestra ni ubica

- **Ubicación:** §3.2 l.414 («`Domain` contiene además `DomainException` y la interfaz `IProductoRepository` (§4.1)»); §4.2 l.490 (`ProductoDto.From`, `ObtenerProductosHandler`); §4.3 l.504 (`FakeProductoRepository`, `Guardados`); §5.2 l.597 («registra `InMemoryProductoRepository` … y los tres handlers»; «la versión de esta etapa queda en `lab.sh`»); §5.3 l.653 (`AppDbContext`, `ProductoRepository`, `AddInfrastructure`); §5.6 l.717-731 (método sin clase: no se ve `IExceptionHandler` ni de dónde sale `_problemDetails`).
- **Afirmación:** para pasar de L09 a L13 tengo que escribir, sin que la guía me los muestre, `IProductoRepository` (con qué métodos y firmas), `DomainException`, `ProductoDto` y su `From`, `ObtenerProductosQuery`/`Handler`, `ObtenerProductoPorIdQuery`/`Handler`, `FakeProductoRepository`, `CrearProductoRequest`, `ProductoResponse`, `InMemoryProductoRepository`, las acciones `GetAll`/`GetById` del controller y el registro en `Program.cs`. La firma de `AddAsync(producto, ct)` y `GetAllAsync` solo se deduce del uso. Y la guía remite a un guion bash (`lab.sh`) para recuperar un `Program.cs` en C#. Un lector novato no sabe que todo eso está en `Dot-NET-Arquitectura-Lab/MyProject/` con la ruta que indica el espacio de nombres: la única frase que lo dice está en el Anexo A l.1161 («El código final está en …»), al final del documento.
- **Evidencia:** E2 (citas anteriores) + E1: `find Dot-NET-Arquitectura-Lab/MyProject -name '*.cs'` devuelve 25 archivos; la guía rotula como [Compilado] 9 rutas (Bitácora 04 §4). Los 16 restantes son los que el lector necesita y no ve. `IProductoRepository.cs` existe con `GetByIdAsync(Guid, CancellationToken)`, `GetAllAsync(CancellationToken)`, `AddAsync(Producto, CancellationToken)`: ninguna firma aparece en la guía.
- **Severidad:** S2 (quien sigue el recorrido con la terminal se detiene en L11 y tiene que adivinar o abandonar; interpretación divergente entre lectores).
- **Reemplazo propuesto (dos partes):**
  1. En §0.5, agregar una fila al final de la tabla de marcas (después de l.85):
     reemplazar: `| [Autor, año](#anexo-e-referencias) | Afirmación respaldada por la fuente citada en el Anexo E |`
     por: `| [Autor, año](#anexo-e-referencias) | Afirmación respaldada por la fuente citada en el Anexo E |\n| Tipo nombrado sin código | Cuando la guía nombra un tipo (\`IProductoRepository\`, \`ProductoDto\`, \`FakeProductoRepository\`, \`Program.cs\`…) sin mostrar su código, el archivo completo está en [\`Dot-NET-Arquitectura-Lab/MyProject/\`](Dot-NET-Arquitectura-Lab/MyProject/), en la carpeta que indica su espacio de nombres (\`MyProject.Domain.Productos\` → \`src/Backend/MyProject.Domain/Productos/\`). Se copia desde ahí antes de compilar el paso |`
  2. En §3.2 l.414, mostrar la interfaz, porque es la pieza de la que depende todo §4:
     reemplazar: «`Domain` contiene además `DomainException` y la interfaz `IProductoRepository` (§4.1), y compila sin ninguna referencia»
     por: «`Domain` contiene además `DomainException` (una clase que hereda de `Exception` y recibe el mensaje) y la interfaz que declara lo que el dominio necesita del almacenamiento (§4.1):\n\n**[Compilado: `MyProject/src/Backend/MyProject.Domain/Productos/IProductoRepository.cs`]**\n\n```csharp\npublic interface IProductoRepository\n{\n    Task<Producto?> GetByIdAsync(Guid id, CancellationToken ct = default);\n    Task<IReadOnlyList<Producto>> GetAllAsync(CancellationToken ct = default);\n    Task AddAsync(Producto producto, CancellationToken ct = default);\n}\n```\n\n`Domain` compila sin ninguna referencia»
     (Costo: +9 líneas en §3, que está en 98 de 120 permitidas por DR-08.)

### H-NOV-02 — Pasos Lnn cuya salida se muestra sin el comando que la produce

- **Ubicación:** §1.5 l.204-212 (L05: «Deshacer el ciclo … el comando no encuentra la referencia»; el comando `dotnet remove` no aparece en toda la guía); §2.2 l.270 (L06/L07: «`TodoJunto`»: no se dice cómo se crea ni dónde); §2.6 l.316-329 (listado `== MyProject.Domain …`: no se dice qué comando lo produce); §4.3 l.496-515 (L11: «Aquí nacen los proyectos de pruebas» sin `dotnet new xunit`, sin las referencias y sin `dotnet test`); §5.3 l.653 (L16: «agrega el paquete» sin `dotnet add package`; «sha256» sin `sha256sum`); §6.3 l.775 (L22: «crea un cliente de consola» sin `dotnet new console`; l.799 salida del cliente sin `dotnet run --project`).
- **Afirmación:** en esos seis pasos leo una salida y no tengo el comando que la genera. R-06 exige «objetivo, comando, salida registrada, cómo leerla» por paso. Con la terminal abierta, en L05 no sé qué escribir para «quitar la referencia»; en L11 no sé cómo se crea un proyecto xunit ni cómo se corren las pruebas (`dotnet test` no figura en el documento).
- **Evidencia:** E2 (`grep -n 'dotnet remove\|dotnet test\|dotnet new xunit\|dotnet add .* package\|dotnet run --project' Dot-NET-Arquitectura-Guide.md` → 0 resultados) + E1: `lab.sh` l.127, l.131, l.136-137, l.349-350, l.432, l.578, l.780 contienen los comandos reales.
- **Severidad:** S2 para L05 y L11 (el recorrido se corta); S3 para los demás (se puede inferir con esfuerzo).
- **Reemplazo propuesto (los dos S2; el mismo patrón sirve para L06, L16 y L22):**
  - §1.5, reemplazar: «Deshacer el ciclo (L05) deja una segunda lección sobre leer salidas. Con la ruta de la carpeta, el comando **no encuentra** la referencia y aun así termina con código 0:»
    por: «Deshacer el ciclo (L05) deja una segunda lección sobre leer salidas. El comando inverso de `add … reference` es `dotnet remove <proyecto> reference <referencia>`. Con la ruta de la carpeta, **no encuentra** la referencia y aun así termina con código 0:\n\n```bash\ndotnet remove src/Backend/MyProject.Domain reference src/Backend/MyProject.Infrastructure\n```»
    y reemplazar: «Con la ruta al archivo `.csproj`, la quita (`Project reference … removed.`) y la solución vuelve a compilar.»
    por: «Con la ruta al archivo `.csproj` la quita (`Project reference … removed.`); después se borran `Producto.cs` y `ConexionSql.cs` del paso L03 y la solución vuelve a compilar:\n\n```bash\ndotnet remove src/Backend/MyProject.Domain reference src/Backend/MyProject.Infrastructure/MyProject.Infrastructure.csproj\nrm src/Backend/MyProject.Domain/Producto.cs src/Backend/MyProject.Infrastructure/Persistence/ConexionSql.cs\ndotnet build\n```»
  - §4.3, reemplazar: «Aquí nacen los proyectos de pruebas, uno por proyecto probado, en `tests/Backend/`. Una **prueba unitaria** es un método marcado con `[Fact]` (en la biblioteca xUnit) que ejecuta una porción de código y verifica el resultado con `Assert`.»
    por: «Aquí nacen los proyectos de pruebas, uno por proyecto probado, en `tests/Backend/`. Se crean con la plantilla `xunit`, referencian al proyecto que prueban y se ejecutan con `dotnet test`, que compila y corre todas las pruebas de la solución:\n\n```bash\ndotnet new xunit -n MyProject.Domain.Tests -o tests/Backend/MyProject.Domain.Tests\ndotnet new xunit -n MyProject.Application.Tests -o tests/Backend/MyProject.Application.Tests\ndotnet sln add tests/Backend/MyProject.Domain.Tests tests/Backend/MyProject.Application.Tests\ndotnet add tests/Backend/MyProject.Domain.Tests reference src/Backend/MyProject.Domain\ndotnet add tests/Backend/MyProject.Application.Tests reference src/Backend/MyProject.Application\ndotnet test\n```\n\nUna **prueba unitaria** es un método marcado con `[Fact]` (en la biblioteca xUnit, que la plantilla ya incluye) que ejecuta una porción de código y verifica el resultado con `Assert`.»
    (Costo: +9 líneas en §4, que está en 100 de 140.)

### H-NOV-03 — Arrancar la API: desde qué carpeta, y cómo tener «otra terminal» dentro del contenedor

- **Ubicación:** §5.2 l.599-603 («La API se arranca con una receta fija … `dotnet run --no-launch-profile --urls …`») y l.611 («Con la API escuchando, desde otra terminal:»).
- **Afirmación:** el comando no dice desde qué carpeta se ejecuta ni lleva `--project`; ejecutado en la raíz de la solución, `dotnet run` falla porque hay varios proyectos. Además, quien entró al contenedor con el `docker run` de §0.6 tiene **una** terminal; «desde otra terminal» no le dice cómo conseguirla (`docker exec` a ese contenedor, o `&` como pedía DR-20). La captura L13 tampoco resuelve la duda: su encabezado dice `comando: cat /tmp/work/api-memoria.log`, no el comando de arranque.
- **Evidencia:** E2 (citas) + E1: `lab.sh` l.58 arranca con `( cd "$SLN/src/Backend/MyProject.WebAPI" && ASPNETCORE_ENVIRONMENT=Development setsid dotnet run --no-launch-profile --urls $API > … & )`; DR-20 (veredicto §7.4) prescribe `… 5180 &` y «la API y `curl` corren en el mismo contenedor».
- **Severidad:** S2 (L13-L21, nueve pasos, dependen de este arranque).
- **Reemplazo propuesto:** reemplazar l.599-603:
  «La API se arranca con una receta fija, para que el puerto no dependa de la configuración del equipo:\n\n```bash\nASPNETCORE_ENVIRONMENT=Development dotnet run --no-launch-profile --urls http://127.0.0.1:5180\n```»
  por: «La API se arranca con una receta fija, para que el puerto no dependa de la configuración del equipo. Se ejecuta desde la carpeta del proyecto WebAPI, y el `&` final la deja corriendo en segundo plano para poder seguir usando la misma terminal (para detenerla: `kill %1`):\n\n```bash\ncd src/Backend/MyProject.WebAPI\nASPNETCORE_ENVIRONMENT=Development dotnet run --no-launch-profile --urls http://127.0.0.1:5180 &\ncd ../../..\n```»
  y en l.611 reemplazar «Con la API escuchando, desde otra terminal:» por «Con la API escuchando (la línea `Now listening on`), en la misma terminal:».

### H-NOV-04 — La carpeta de trabajo nunca se crea, y las rutas de la guía suponen que existe

- **Ubicación:** §0.6 l.93-94 (`docker run … -v "$PWD":/w -w /w … bash`) y §1.2 l.128-129 (`dotnet new sln -n MyProject` como primer comando); rótulos [Compilado: `MyProject/src/Backend/…`] desde l.373; captura L10 encabezado `directorio: /tmp/work/MyProject`.
- **Afirmación:** siguiendo la guía al pie de la letra, la solución se crea en `/w` (la carpeta desde la que lancé `docker run`), no en una carpeta `MyProject/`. Después las rutas [Compilado] empiezan con `MyProject/` y el árbol de §8.1 l.1005 pone `MyProject.slnx` en la raíz. No sé si me falta un `mkdir MyProject && cd MyProject` o si `MyProject/` en los rótulos es otra cosa (es la carpeta del laboratorio publicado, pero eso no se dice).
- **Evidencia:** E2 (citas) + E1: `lab.sh` l.78 hace `mkdir -p "$SLN"; cd "$SLN"` con `SLN=/tmp/work/MyProject` antes de L01.
- **Severidad:** S3 (se resuelve solo, pero cada ruta posterior obliga a traducir mentalmente).
- **Reemplazo propuesto:** en §1.2, reemplazar el bloque de l.128-137 por el mismo bloque con dos líneas iniciales:
  reemplazar: «```bash\ndotnet new sln -n MyProject\n»
  por: «```bash\nmkdir MyProject && cd MyProject      # todo el laboratorio se ejecuta desde esta carpeta\ndotnet new sln -n MyProject\n»
  y en §0.5 (fila **[Compilado: `src/…`]**, l.82) reemplazar «El bloque de código es un extracto del laboratorio y compiló con cero advertencias» por «El bloque de código es un extracto del laboratorio y compiló con cero advertencias; la ruta `MyProject/…` es la del código publicado en `Dot-NET-Arquitectura-Lab/` y coincide con la carpeta creada en L01».

### H-NOV-05 — Fragmentos que no sé dónde poner ni cómo completar

- **Ubicación:** §1.4 l.165-179 (L03: se muestra `Producto.cs` usando `ConexionSql`, pero no se dice que hay que crear `ConexionSql` en `Infrastructure/Persistence/`, ni con qué contenido); §3.3 l.420-425 (L10: dos sentencias sueltas, «desde `Application`», y la captura dice `Intento.cs(10,9)`: no se dice en qué archivo, clase ni método van); §4.2 l.481 y §5.2 l.585 (`CancellationToken ct = default`, `[FromServices]`, `IActionResult`: aparecen en código [Compilado] sin definirse; DR-16 exige definir en el primer uso); §3.2 l.378 (`Guid` no definido; el Anexo A l.1191 lo usa como si lo fuera).
- **Afirmación:** el mandato dice «código que no sabrías dónde poner»: en L03 y L10 no sé dónde ponerlo, y en L10 ni siquiera compila como está (una asignación fuera de un método). En §4.2/§5.2 puedo copiar, pero no entiendo qué es `ct`, por qué el handler se pide con `[FromServices]` ni qué es un `Guid`.
- **Evidencia:** E1: `lab.sh` l.92-99 crea `ConexionSql.cs` (una clase con `public void Ejecutar(string sql) { }`); l.245-257 crea `Intento.cs` como `public static class Intento { public static void BajarPrecio() { … } }` en `src/Backend/MyProject.Application/Productos/`. E2: `grep -n 'CancellationToken\|FromServices\|Guid' Dot-NET-Arquitectura-Guide.md` no encuentra ninguna definición, solo usos.
- **Severidad:** S3.
- **Reemplazo propuesto:**
  - §1.4, reemplazar «El paso escribe en `Domain` una clase que usa un tipo de `Infrastructure`, sin referencia en esa dirección:» por «El paso crea primero, en `src/Backend/MyProject.Infrastructure/Persistence/ConexionSql.cs`, una clase vacía que simula el acceso a datos (`public class ConexionSql { public void Ejecutar(string sql) { } }`, espacio de nombres `MyProject.Infrastructure.Persistence`), y después escribe en `src/Backend/MyProject.Domain/Producto.cs` una clase que la usa, sin referencia en esa dirección:».
  - §3.3, reemplazar «El paso intenta, desde `Application`, bajar el precio de un producto ya creado:» por «El paso crea `src/Backend/MyProject.Application/Productos/Intento.cs` con un método estático cualquiera (`public static class Intento { public static void BajarPrecio() { … } }`) que intenta bajar el precio de un producto ya creado:».
  - §4.1, agregar una definición después de l.466: «- **`CancellationToken`.** Parámetro que las operaciones asíncronas reciben para poder interrumpirse si quien las pidió ya no espera el resultado (por ejemplo, el cliente cerró la conexión). En esta guía se pasa siempre y se llama `ct`; `= default` permite omitirlo.»
  - §3.1, agregar después de l.362: «- **`Guid`.** Identificador único global: un número de 128 bits que .NET genera con `Guid.NewGuid()` y que sirve como `Id` sin necesidad de una base de datos que lo asigne.»
  - §5.2, después de l.595 agregar una oración: «`[FromServices]` le indica al controller que ese parámetro no viene de la petición sino del contenedor de dependencias (§2.1); `IActionResult` es el tipo que representa cualquier respuesta HTTP.»
  - Anexo D: filas para `Guid` (3.1) y `CancellationToken` (4.1).

### H-NOV-06 — `curl` y sus opciones no se definen

- **Ubicación:** §5.1 l.560-570 (definiciones de HTTP: no incluye `curl`); §5.2 l.614-616 (primer uso: `curl -s -i -X POST … -H 'Content-Type: application/json' -d '…'`); Diagrama 4 l.633 (`participant C as curl`).
- **Afirmación:** la guía define petición, verbo, código de estado y JSON, pero no la herramienta con la que voy a enviar la petición ni qué hacen `-s`, `-i`, `-X`, `-H`, `-d`. Sin eso no sé por qué la salida trae `HTTP/1.1 201 Created` y `Location` (es `-i`), ni qué es `Content-Type`.
- **Evidencia:** E2: `grep -n 'curl' Dot-NET-Arquitectura-Guide.md` → l.614, 616, 633, todas usos, ninguna definición; el Anexo D no tiene la entrada.
- **Severidad:** S3.
- **Reemplazo propuesto:** agregar en §5.1, después de la definición de JSON (l.562): «- **`curl`.** Programa de línea de comandos que envía una petición HTTP y muestra la respuesta; viene instalado en la imagen del SDK. Opciones usadas en la guía: `-X` fija el verbo (`POST`; sin `-X` es `GET`), `-H` agrega un encabezado (`Content-Type: application/json` avisa que el cuerpo es JSON), `-d` es el cuerpo, `-i` muestra también la línea de estado y los encabezados de la respuesta, `-s` silencia la barra de progreso.» Fila en el Anexo D: «`curl` | Programa de terminal que envía peticiones HTTP y muestra la respuesta | 5.1».

### H-NOV-07 — Las duraciones mostradas en L11 y L12 no son las de las capturas

- **Ubicación:** §4.3 l.513-514 («Duration: 71 ms … Duration: 44 ms») y l.520, l.524 («[11 ms]», «[19 ms]»), ambas con «*Salida registrada: `capturas/L11-tests.txt`*» / «`capturas/L12-regresion.txt`».
- **Afirmación:** §0.5 promete que la salida mostrada «es un extracto literal de una ejecución real» guardada en `capturas/`. Cuando comparo, los números no coinciden: la captura L11 dice `111 ms` y `94 ms`; la L12 dice `[9 ms]` y `[46 ms]`. Como lector que verifica, mi primera reacción es dudar de si estoy mirando el archivo correcto. La guía ya avisa que las duraciones cambian; lo que se pierde es la promesa de literalidad respecto del archivo citado (probablemente el texto viene de una corrida anterior a la cuarta).
- **Evidencia:** E2: `grep -n 'Passed!\|Failed!' capturas/L11-tests.txt capturas/L12-regresion.txt` → `Duration: 111 ms`, `Duration: 94 ms`, `Duration: 301 ms`, `Duration: 206 ms`; `grep -n 'Failed MyProject' capturas/L12-regresion.txt` → `[9 ms]`, `[46 ms]`. El resto de las salidas contrastadas (L00, L01/L02, L03, L04, L05, L08, L10, L13, L14, L15, L16, L17, L18, L22) coincide con las capturas.
- **Severidad:** S3.
- **Reemplazo propuesto:** l.513 reemplazar `Duration: 71 ms` por `Duration: 111 ms`; l.514 `Duration: 44 ms` por `Duration: 94 ms`; l.520 `[11 ms]` por `[9 ms]`; l.523 agregar ` , Duration: 301 ms` no es necesario (la guía recorta esa parte de la línea, lo declara al decir «extracto»); l.524 `[19 ms]` por `[46 ms]`. Alternativa de menor costo: reemplazar en los cuatro lugares el número por `… ms` y decir en «Qué puede cambiar» que el extracto omite las duraciones.

---

## 2. Revisado y correcto

1. **Salidas contrastadas con las capturas.** L00 (SDK 10.0.400 / Host 10.0.11), L03 (CS0234 en `(1,17)` y CS0246 en `(9,25)`), L04/L05 (código 0 y `could not be found`), L10 (CS0200, coherente con la Bitácora 04 que reemplazó CS0272), L13 (`Overriding HTTP_PORTS`, `Now listening`), L14/L15 (201 + `Location`, JSON sin `activo`), L16 (sha256 idéntico, `Skipping target "CoreCompile"`), L17 (`4500.0`), L18, L22 (`12000.0`): lo que la guía muestra es lo que dice el archivo, salvo las duraciones de H-NOV-07. `aserciones.log`: 68 PASS, 1 FAIL provocado, como declara el Anexo A l.1191.
2. **§5.1 define HTTP antes de usarlo.** Petición, verbo, código de estado, JSON, DTO, controller, middleware, OpenAPI, `DbContext`, unidad de trabajo y ProblemDetails están definidos antes de §5.2, y con eso pude leer la salida de L14/L15 («201 confirma la creación y `Location` dice dónde consultar») sin conocer HTTP de antemano. Solo falta la herramienta (H-NOV-06).
3. **§1.5 enseña a leer salidas y no solo códigos.** La tabla acción/salida/código de salida de L04 y la lección de L05 («leé el mensaje, no solo el código de salida») son claras para un novato y coinciden con las capturas; el contraste `CS` (compilador) vs `MSB` (MSBuild) me sirvió para entender de quién es cada error.

---

## 3. Solicitudes de convocatoria

- **Verificación / QA** — señal: §4.3 l.513-524 (H-NOV-07). Qué no puedo afirmar sin ella: si otras salidas mostradas provienen de una corrida anterior a la cuarta (la Bitácora 04 registra cuatro corridas) y si el chequeo mecánico «capturas citadas existen 29/29» debería también comparar contenido, no solo existencia.

---

## 4. Fuera de mandato (no emito hallazgo)

- No opino sobre si la ausencia de `&` en §5.2 respecto de DR-20 es un apartamiento de la directiva (es tema de Requisitos); solo registro que a mí me deja sin terminal (H-NOV-03).
- No opino sobre citas, licencias ni versiones (Anexo C/E).
