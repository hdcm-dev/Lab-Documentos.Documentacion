# Mesa evaluadora — Ciclo 1 — Informe 07: Abogado del diablo

**Fecha:** 2026-09-18
**Rol:** Abogado del diablo (núcleo permanente, §4.1.1 del marco)
**Mandato:** atacar la propuesta dominante —que la guía enseñe Clean Architecture + CQRS + MediatR + seis tipos de objetos por concepto como *la* forma de diseñar una solución .NET desde cero— y el plan de núcleos. Buscar dónde induce sobre-ingeniería a un principiante, dónde el plan no cabe en un solo documento y qué contraargumentos con fuente tiene que traer la guía.
**Trabajo a ciegas:** no leí los otros informes de `Ciclo-1/`.
**Material leído:** prompt 03, contrato de entrada (Bitácora 01), NC-00…NC-10, registro de convocatoria, guía vigente (commit 063f4e9, 1003 líneas), `Mesa-Evaluadora.md` §3 y §4.1.4, `Estilo-Redaccion-Explicativo.md`, perfil `Study-Guide-Documentation.md`.

**Fuentes externas consultadas (2026-09-18):**

| Id | Fuente | URL |
|---|---|---|
| F1 | Fowler, «CQRS» (bliki) | https://martinfowler.com/bliki/CQRS.html |
| F2 | Fowler, «LocalDTO» (bliki) | https://martinfowler.com/bliki/LocalDTO.html |
| F3 | Microsoft Learn, «Common web application architectures» (actualizada 2026-07-08) | https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures |
| F4 | Microsoft Learn, «Designing the infrastructure persistence layer» | https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design |
| F5 | Microsoft Learn, «Creating a simple data-driven CRUD microservice» | https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/data-driven-crud-microservice |
| F6 | Martin, «The Clean Architecture» (2012) | https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html |
| F7 | Bogard, «Vertical Slice Architecture» (2018-04-19) | https://www.jimmybogard.com/vertical-slice-architecture/ |
| F8 | Bogard, «AutoMapper and MediatR Going Commercial» (2025-04-02) | https://www.jimmybogard.com/automapper-and-mediatr-going-commercial/ |
| F9 | Página de precios de MediatR | https://mediatr.io/ |
| F10 | Metadatos NuGet de MediatR (API v3) | https://api.nuget.org/v3-flatcontainer/mediatr/ |

---

## 0. La tesis que ataco, en una línea

**El plan declara que va a enseñar «cuándo no conviene Clean» (T-04, X-06, NC-09), pero todo lo que el lector ejecuta con sus manos es la opción máxima.** El criterio queda como un capítulo final que se lee; la sobre-ingeniería queda como el único camino que se practica.

---

## 1. Hallazgos

### H-01 — El único camino que el lector practica es el escalón más alto de la escala

- **Ubicación:** NC-00 línea 51; NC-08 líneas 12–20; NC-09 línea 7.
- **Evidencia:** E2 + E4.
- **Severidad:** S2.
- **Confianza:** 0,85.

**Afirmación.** NC-09 define una escala de cinco escalones —«página→EF (Transaction Script) → capas con servicio → Clean con casos de uso → Clean + CQRS con mediador» (NC-09:7)—, pero el laboratorio construye desde el paso 2 la solución completa: «Crear solución y proyectos Domain, Application, Infrastructure, WebAPI (+ Contracts, + Tests)» (NC-08:14). Además, el documento de cohesión fija que «NC-09 cierra porque exige haber entendido el resto» (NC-00:51). El lector sin experiencia recorre entero el escalón 4 o 5 y llega a los criterios cuando ya no tiene nada que decidir.

**Por qué es un defecto y no una preferencia.** El objetivo del contrato es que el lector «quede con criterio para estructurar desde cero» (Bitácora 01, `objetivo`). La regla del estilo exigido dice que un documento forma criterio cuando, «tapada la solución que propone», lo que queda alcanza para reconstruirla (`Estilo-Redaccion-Explicativo.md` §1.1). Un laboratorio que parte de la solución terminada no deja nada que reconstruir: muestra un resultado y no la decisión que llevó a él. Es la anatomía de un «registro con prólogo» (§1.1 del estilo).

**Propuesta de dirección.** Hacer de la escala de NC-09 la columna vertebral del laboratorio, no su epílogo:

1. Arrancar con un único proyecto `webapi`: controller o minimal API y `DbContext`. Es la forma con la que empieza toda plantilla nueva de ASP.NET Core según F3 («A new ASP.NET Core project … starts out as a simple "all-in-one" monolith»), y F5 la muestra como diseño legítimo para un CRUD.
2. Subir un escalón **solo cuando aparece la necesidad que lo justifica, y hacerla visible con un comando**:

   | Necesidad | Escalón que resuelve | Comprobación en el laboratorio |
   |---|---|---|
   | Probar la regla del precio sin base de datos | Entidad con comportamiento en un proyecto `Domain` | `dotnet test` sin base de datos |
   | Que el dominio no compile contra EF | Separación en proyectos + inversión de dependencias | CS0246 al intentar referenciar EF desde `Domain` |
   | Un segundo cliente | DTO y `Contracts` | Un cliente de consola que referencia `Contracts` |

3. Cerrar con el capítulo de criterios como **mapa de consulta**. Ese capítulo puede abrirse directamente, tal como pide T-01.

Así el lector ve fallar la versión simple antes de ver la compleja, y el «cuándo no» se vuelve algo que comprobó.

---

### H-02 — «CQRS» se presenta como la opción por defecto, contra la advertencia de su fuente principal y con un nombre que no corresponde

- **Ubicación:** guía vigente líneas 149–156, 379–416 y 994; NC-04 «Decisiones a resolver».
- **Evidencia:** E2 + fuente F1.
- **Severidad:** S2.
- **Confianza:** 0,8.

**Afirmación.** La guía resume «Casos de uso | CQRS | MediatR 12» (l. 994) y organiza todas las features en carpetas `Commands/` y `Queries/` (l. 397–413). NC-04 plantea la decisión como «CQRS con o sin MediatR»: la única pregunta abierta es el mediador. CQRS queda fuera de discusión.

**Contraargumento con fuente.** Fowler, F1:
- «For most systems CQRS adds risky complexity.»
- «You should be very cautious about using CQRS.»
- «CQRS should only be used on specific portions of a system (a BoundedContext in DDD lingo) and not the system as a whole.»

**Contradicción interna.** La guía define CQRS como que cada operación «tiene su propio modelo» (l. 151). A continuación dice que «en la mayoría de proyectos: misma BD, misma ORM» (l. 156). El ejemplo tampoco muestra un modelo de lectura distinto del de escritura. Lo que se enseña es en realidad **un handler por caso de uso**, es decir, separación comando/consulta a nivel de método, y llamarlo CQRS le da a un principiante un nombre prestigioso para una práctica más modesta. Después el lector va a leer el «CQRS» de Fowler y no va a reconocer lo que hizo.

**Propuesta de dirección.**
1. Nombrar lo que se hace como «caso de uso» o «handler por caso de uso».
2. Reservar «CQRS» para el escalón donde lectura y escritura tienen modelos distintos, y citar la advertencia de F1 en la guía, con la pregunta «¿Cuándo no conviene separar lectura y escritura?».
3. Quitar CQRS de la tabla de «decisiones» como opción por defecto.

---

### H-03 — MediatR en el camino base: indirección sin beneficio para el principiante y costo de salida no declarado

- **Ubicación:** guía vigente líneas 160–185, 377, 538–557 y 994; NC-04; NC-10.
- **Evidencia:** E2 + E1 + fuentes F7, F8 y F9.
- **Severidad:** S2.
- **Confianza:** 0,8.

**Afirmación.** El beneficio que la guía le atribuye al mediador —«el Controller no conoce la implementación del Handler. Solo conoce el contrato» (l. 185)— ya lo da la inversión de dependencias que la misma guía enseña en l. 250. Basta con inyectar una interfaz o el handler por el contenedor de DI nativo. El valor diferencial de MediatR son los *pipeline behaviors* (`ValidationBehavior`, `LoggingBehavior`, l. 386–387), y la guía nunca los muestra. Para quien aprende, `_mediator.Send(...)` agrega un salto que no se puede seguir con «Ir a definición». Cuando algo falla, el lector no sabe dónde buscar.

**Costo de salida verificado.** NC-10 propone evaluar cada dependencia por «licencia, mantenimiento, alternativa nativa, costo de salida». Aplicado a MediatR:

- **E1, metadatos NuGet (F10):**
  - `mediatr/12.5.0`: `<license type="expression">Apache-2.0</license>`.
  - `mediatr/13.0.0` y `14.2.0` (última publicada): `<license type="file">LICENSE.md</license>` y `<requireLicenseAcceptance>true`.
  - El `LICENSE.md` de 14.2.0 remite a la Reciprocal Public License 1.5 o a un acuerdo comercial en `luckypennysoftware.com/license`.
- **F9:** la edición Community es gratuita para organizaciones con ingresos anuales menores a USD 5 000 000 que no hayan recibido más de USD 10 000 000 de capital externo, y **excluye a entidades de gobierno y a instituciones de educación superior**.
- **F8:** el anuncio es del 2025-04-02.

Si la guía recomienda MediatR a un lector que diseña «desde cero», le recomienda una de estas dos cosas: una versión congelada (12.x) o una licencia que puede no cubrirlo, según dónde trabaje. En ambos casos la guía no se lo dice.

**Propuesta de dirección.**
1. Dejar MediatR fuera del camino base y del laboratorio. Los controllers llaman a handlers inyectados por interfaz.
2. Presentar el mediador en el capítulo de criterios como escalón opcional, con su único beneficio real (behaviors transversales) y su costo (indirección y licencia).
3. Citar a Bogard, autor de MediatR, en F7. Critica las arquitecturas por capas con reglas del tipo «Controller MUST talk to a Service that MUST use a Repository». Sirve de contraargumento de primera mano.
4. El detalle de licencias es competencia de AH-001: ver la solicitud de convocatoria 1.

---

### H-04 — «Seis objetos por concepto» sin la condición que justifica cada uno: la guía de Fowler dice lo contrario para DTOs locales

- **Ubicación:** NC-03, tabla de objetos; guía vigente líneas 83–118, 593–598 y 696–720.
- **Evidencia:** E2 + E3 + fuente F2.
- **Severidad:** S2.
- **Confianza:** 0,75.

**Afirmación.** La tabla de NC-03 presenta siete objetos: Entity, Value Object, Command/Query, Response DTO, ViewModel, Form model y Persistence model. Solo uno lleva la condición de no uso («casi nunca necesario», en el Persistence model). Los demás aparecen como obligatorios.

**Contraejemplo E3.** Recuento de los tipos que la guía vigente exige para la feature «crear y listar productos» de punta a punta, según sus propios árboles y snippets:

| Proyecto | Tipos | Líneas de la guía |
|---|---|---|
| Domain | `Producto`, `DomainException`, `IProductoRepository` | 37–56, 359–367 |
| Application | `CrearProductoCommand`, `CrearProductoValidator`, `CrearProductoHandler`, `ObtenerProductosQuery`, `ObtenerProductosHandler`, `ProductoResponseDto`, `CrearProductoRequestDto` | 399–416, 94–95 |
| Infrastructure | `AppDbContext`, `ProductoConfiguration`, `ProductoRepository` | 470–476 |
| WebAPI | `ProductosController` | 513–515 |
| WebFront | `IProductoApiService`, `ProductoApiService`, `ProductoListItemViewModel`, `ProductoFormViewModel`, `ProductoMapper`, `Index.razor`, `Form.razor` | 575–598 |

Son **21 tipos en cinco proyectos** para un alta con listado y una sola regla: precio mayor que cero. En ese recorrido, `CrearProductoRequestDto` y `CrearProductoCommand` tienen los mismos dos campos (l. 95 y 431), y `ProductoResponseDto` vuelve a copiarse en `ProductoListItemViewModel`.

**Contraargumento con fuente.** Fowler, F2, sobre DTOs dentro de un mismo proceso:
- «Not just do you not need them in a local context, they are actually harmful».
- Cita a Stafford: «Don't underestimate the cost of [using DTOs].... It's significant, and it's painful».

La única excepción local que admite es una capa de presentación con un desajuste significativo respecto del dominio. Esa excepción es la condición que falta en la tabla.

**Propuesta de dirección.** Agregar a la tabla de NC-03 una columna **«Existe solo si…»**, con el disparador de cada objeto:

| Objeto | Existe solo si… |
|---|---|
| Response DTO | La entidad cruza un límite de proceso o un contrato público (API, WASM) |
| ViewModel | La pantalla muestra algo que el DTO no trae: formato, estado visual |
| Form model | El formulario difiere del comando o requiere validación de UI |
| Command separado del Request DTO | Hay datos que no vienen del cliente (usuario actual, fecha) |

Completar con la pregunta guía «¿Cuántos de estos objetos necesita mi primera pantalla?» y su respuesta: **la entidad y, si hay HTTP, un DTO; el resto se agrega cuando aparece su disparador.** NC-09:9 ya lista «seis objetos por concepto en un CRUD» como señal de sobre-ingeniería. El plan tiene que llevar esa señal a la tabla que la produce.

---

### H-05 — La regla «el front nunca referencia Application» es absoluta y falla en el caso que la propia conversación declaró válido

- **Ubicación:** guía vigente líneas 299, 563, 980 y 985; NC-05 último punto.
- **Evidencia:** E2 + E3.
- **Severidad:** S2.
- **Confianza:** 0,75.

**Afirmación.** La guía dice que el WebFront «Nunca referencia directamente los proyectos de dominio o infraestructura» (l. 299). La tabla de §13 le prohíbe referenciar Application (l. 980). La nota de l. 985 califica esa referencia como «la violación más común», porque «arruina la independencia de despliegue». Al mismo tiempo, el WebFront admite «Blazor … Server» (l. 563).

**Contraejemplo E3.** Una aplicación Blazor Server, sin otro cliente, que se despliega como una sola unidad. No tiene independencia de despliegue que arruinar: la API HTTP intermedia existe solo para cumplir la regla. Agrega un proceso, serialización, un `HttpClient`, DTOs y mapeos. La respuesta de la conversación que el prompt pide incorporar dice exactamente eso: «Blazor Server, sin API aparte y con un CRUD de pocas reglas … es una arquitectura en capas válida». NC-05 lo registra («en Server … *podría* referenciar Application»). La regla de §13, en cambio, sigue escrita como ley sin condición.

**Contraargumento con fuente.** F3 muestra el caso de referencia de Microsoft: la capa de UI referencia al Application Core, y la separación se garantiza por la regla de dependencia, no por un salto HTTP. En F3, la API separada aparece solo para el componente Blazor opcional de eShopOnWeb.

**Propuesta de dirección.** Reescribir §13 como regla condicionada, con la pregunta «¿Cuándo el front sí puede referenciar Application?». Respuesta: **cuando el front corre en el mismo proceso que el backend y es su único cliente; deja de poder cuando aparece un cliente remoto (WASM, MAUI, terceros).** Agregar ejemplos ✅ y ❌. La prohibición que queda como invariante es otra: el front nunca referencia Infrastructure.

---

### H-06 — El repositorio se enseña como obligatorio y el ejemplo nunca confirma la escritura

- **Ubicación:** guía vigente líneas 189–195 y 444–456; NC-08 línea 19.
- **Evidencia:** E2 + E3 + fuentes F4 y F5.
- **Severidad:** S2.
- **Confianza:** 0,7.

No reabro DC-3: dónde vive `IProductoRepository` está decidido. Ataco que se presente como paso obligatorio y el hueco que deja en el ejemplo.

**Afirmación 1: obligatoriedad.** La guía presenta el patrón Repository sin alternativa (l. 189–195). La fuente de Microsoft que la sustenta dice lo contrario:
- «EF DbContext implements both the Repository and the Unit of Work patterns» (F4).
- Hay una sección titulada «Repositories shouldn't be mandatory» (F4), que cita a Bogard: «I don't usually want to mock my repositories – I still need to have that integration test with the real thing».
- F5 muestra un controller que usa el `DbContext` directamente como diseño legítimo para CRUD.

**Afirmación 2: contraejemplo E3.** El handler de l. 450–455 llama a `_repo.AddAsync(producto, ct)` y devuelve el `Id`. Nadie llama a `SaveChanges`/`SaveChangesAsync`, y la interfaz no expone una unidad de trabajo. Con EF Core, `Add` sin `SaveChanges` no persiste (F4: la unidad de trabajo «is executed when a call is made to `SaveChanges`»). Un lector que copia el ejemplo va a hacer `POST` (201) y después `GET` (lista vacía), y la guía no le da con qué entender por qué. Hay dos salidas posibles, y la guía no elige ninguna:
- el repositorio hace `SaveChanges` dentro de `AddAsync`, lo que rompe la transacción cuando hay varias operaciones;
- o existe un `IUnitOfWork`, que es un objeto más para el principiante.

Además, el paso 7 de NC-08 («Test … con repositorio en memoria») es exactamente la clase de prueba que, según F4, no reemplaza la de integración.

**Propuesta de dirección.**
1. Pregunta guía «¿Necesito un repositorio si ya tengo EF Core?», con su respuesta condicionada: sí cuando el dominio tiene reglas que quiero probar sin base de datos o la persistencia puede cambiar; no en un CRUD.
2. Resolver explícitamente dónde se confirma la transacción y mostrar en el laboratorio el síntoma del `SaveChanges` omitido. Es un error que enseña, según el estilo §5.4.
3. Agregar al laboratorio al menos una prueba contra la base real (SQLite en archivo, por ejemplo) junto a la prueba con el doble.

---

### H-07 — El plan no cabe en un solo documento sin declarar qué sale, y el contrato resolvió la tensión en silencio

- **Ubicación:** Bitácora 01 línea 61; perfil `Study-Guide-Documentation.md` línea 47 y «Estructura de cada documento temático»; NC-00; NC-05; NC-08.
- **Evidencia:** E2 + E4.
- **Severidad:** S2.
- **Confianza:** 0,7.

**Afirmación.** El contrato decide «Un único documento; los núcleos del perfil se vuelven capítulos» (Bitácora 01:61). Al mismo tiempo mantiene todas las exigencias del perfil y del estilo:

- **Por capítulo:** estructura de seis partes (definición, aplicación por escenario, ejemplos, preguntas guía, criterios de calidad, anexo con plantilla) y el patrón pregunta → respuesta → porqué → ejemplos ✅/❌ del estilo.
- **Marco de referencia** de escenarios, contextos y actores. El perfil lo exige y ningún núcleo lo planifica.
- **Laboratorio** de ocho pasos con salidas reales (NC-08).
- **Clientes:** Blazor, Shared.UI, MAUI, Refit y autenticación (NC-05).
- **Criterios** con un caso resuelto de punta a punta (NC-09) y tecnologías con fuente (NC-10).
- **Las respuestas explicativas** de «Cada objeto responde una pregunta».

La guía vigente ya tiene 1003 líneas y no tiene nada de laboratorio, preguntas guía ni criterios. El plan multiplica el contenido y conserva el contenedor. El resultado previsible es uno de dos modos de falla:
- el documento crece hasta que el capítulo de criterios —la «puerta de consulta» de T-01— queda enterrado;
- o se recortan en silencio las partes caras (laboratorio, ✅/❌), que son justamente las que el prompt pide.

**Por qué es del mandato.** Es un ataque directo al plan de núcleos. El perfil prevé la situación («un documento por unidad temática», l. 47), y el estilo también (§3.5: partir cuando el contraste enseña). El contrato los anuló con un supuesto («el perfil multi-documento cede») sin medir el costo.

**Propuesta de dirección.** Que el jurado elija explícitamente una de dos opciones y la registre:

- **(a) Un solo documento con recorte declarado.** Laboratorio solo para el backend y la escala de H-01. Shared.UI, MAUI, Refit y la autenticación JWT se compactan en un capítulo «Clientes» como fragmento ilustrativo, con la ausencia declarada según el estilo §5.3 («Otra herramienta» o «Pendiente»).
- **(b) Documento principal en la ruta pedida más un anexo de laboratorio hermano.** El criterio vive en uno solo, según el estilo §3.5, y el principal enlaza.

La opción (a) respeta la letra de «reedita entera el documento». En cualquiera de las dos, fijar un presupuesto de extensión por capítulo antes de redactar.

---

## 2. Revisado y correcto

1. **DC-1 tiene respaldo externo.** F3 dibuja la arquitectura limpia como anillos de dependencia con proyectos hermanos (Application Core, Infrastructure, UI) y distingue la dependencia de compilación de la de ejecución. Coincide con la lectura «contención = dependencia, no ubicación» de la guía (l. 241) y de NC-02.
2. **El tratamiento del Persistence model es correcto y va en la dirección que pido para el resto.** «En la mayoría de proyectos nuevos con EF Core Code-First, no se necesita» (l. 137; NC-03). Es el único objeto que ya lleva su condición de existencia.
3. **El plan reconoce la tensión que ataco** (T-04, X-06, NC-09:8–9, criterio de NC-10 «licencia, mantenimiento, alternativa nativa, costo de salida»). No falta el diagnóstico: falta que ordene el recorrido y la tabla de objetos (H-01, H-04).

---

## 3. Solicitudes de convocatoria (fuera de mandato)

1. **AH-001 (ecosistema y licencias).** Confirmar con fuente primaria los términos vigentes de MediatR y AutoMapper. El dato hallado de pasada: la edición Community de MediatR excluye a gobierno y educación superior según F9, y la licencia es RPL-1.5 o comercial desde la versión 13.0.0 según F10. El repositorio pertenece a un laboratorio de documentación que puede usarse en contexto académico, así que el dato condiciona directamente DA-4.
2. **E-Didáctica.** Juzgar si el recorrido ascendente por la escala (H-01) es pedagógicamente preferible al descendente: estructura completa primero y justificaciones después. Esa comparación es de su competencia, no de la mía.
3. **E-Edición bibliográfica.** Estimar la extensión del documento con el plan completo y validar el recorte de H-07.

---

## 4. Posición sobre DA-1..DA-4 y la estructura del entregable

- **DA-1 (Backend/ vs Clients/).** La estructura vale para el escalón final, pero no debe ser el primer árbol que ve el lector. La carpeta `Clients/` aparece en la escala cuando aparece el segundo cliente (H-01, H-05).
- **DA-2 (Contracts).** Ni obligatorio ni opcional sin condición. Es obligatorio **cuando existe al menos un cliente .NET remoto** (WASM, MAUI, consola) que consume la API. Mientras no lo hay, no existe, porque es un disparador de la tabla de H-04. En el laboratorio aparece junto con el cliente de consola que lo justifica.
- **DA-3 (versión de .NET).** Fuera de mi mandato. Lo resuelve AH-001.
- **DA-4 (MediatR y AutoMapper).** Independientemente del resultado de licencias, **fuera del camino base y del laboratorio**. Handlers inyectados por interfaz y mapeo manual con métodos de extensión. Ambos se presentan como escalones opcionales, con su beneficio y su costo (H-03). La decisión no depende de la licencia, porque la indirección ya basta como argumento didáctico. La licencia refuerza la decisión, pero no la funda.
- **Estructura.** Escala de opciones como eje del recorrido (H-01). Capítulo de criterios abrible por separado. Recorte declarado de clientes (H-07a).
