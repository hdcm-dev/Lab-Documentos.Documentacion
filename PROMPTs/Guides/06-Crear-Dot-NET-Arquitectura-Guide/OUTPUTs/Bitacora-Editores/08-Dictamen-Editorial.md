# Bitácora de editores 08 — Dictamen editorial sobre la v2.4.0

| | |
| --- | --- |
| **Fecha** | 2026-09-24 |
| **Comisión** | Editor de material bibliográfico técnico (edición de libros de ingeniería de software) |
| **Objeto** | `LAB/Lab-Documentos/Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md`, v2.4.0, 2818 líneas, `last_review: 2026-09-21` |
| **Encargo** | Dictamen previo a la fase interactiva (`03-Actividad-Interactiva.md`): estado del aparato crítico, huecos bibliográficos, tensiones conceptuales, consistencia editorial y plan de edición priorizado. **No se editó la guía ni nada bajo `LAB/Lab-Documentos/Guides/`.** |
| **Contexto nuevo** | `09-Fuente-Actividad-La-Estancia.md` (transcripción de la fuente primaria de la actividad: jerarquía de clases, 15 casos de uso, 18 reglas de negocio) |
| **Medios** | Lectura íntegra del apunte; scripts sobre anclas, remisiones, referencias y conteos; lectura de la bitácora de los cuatro ciclos anteriores; verificación en línea de seis fuentes nuevas (`WebFetch`, `pdftotext`) |
| **Norma aplicada** | `Profiles/Study-Guide-Documentation.md` + `RuleSet-Study-Guide` (`Rule-Evidences`, `Rule-Narrative-Voice`, `Rule-Dual-Audience`) |

## Índice

- [0. Cómo leer este dictamen](#0-cómo-leer-este-dictamen)
- [1. Estado del aparato crítico](#1-estado-del-aparato-crítico)
  - [1.1 Lo que se sostiene en laboratorio](#11-lo-que-se-sostiene-en-laboratorio)
  - [1.2 Lo que se sostiene en documentación oficial](#12-lo-que-se-sostiene-en-documentación-oficial)
  - [1.3 Lo que se sostiene en bibliografía](#13-lo-que-se-sostiene-en-bibliografía)
  - [1.4 Criterio propio, rotulado](#14-criterio-propio-rotulado)
  - [1.5 Criterio propio sin rotular: ocho afirmaciones](#15-criterio-propio-sin-rotular-ocho-afirmaciones)
- [2. Huecos bibliográficos](#2-huecos-bibliográficos)
  - [2.1 El hueco mayor: la jerarquía de tipos](#21-el-hueco-mayor-la-jerarquía-de-tipos)
  - [2.2 Autores ausentes, con cita verificada y destino](#22-autores-ausentes-con-cita-verificada-y-destino)
  - [2.3 Autores presentes y subaprovechados](#23-autores-presentes-y-subaprovechados)
  - [2.4 Lo que no hay que traer](#24-lo-que-no-hay-que-traer)
- [3. Tensiones conceptuales para la mesa](#3-tensiones-conceptuales-para-la-mesa)
- [4. Consistencia editorial](#4-consistencia-editorial)
- [5. Plan de edición priorizado](#5-plan-de-edición-priorizado)
- [6. Verificaciones de esta corrida](#6-verificaciones-de-esta-corrida)

---

## 0. Cómo leer este dictamen

Cuatro ciclos de mesa dejaron el apunte mecánicamente sano y con la clase de evidencia que el pedido original pedía: cada concepto con su definición, su explicación y su código, y una tabla «línea → concepto» debajo de cada bloque compilado. Este dictamen no vuelve sobre eso. Se ocupa de lo que la fase interactiva pone en riesgo: un apunte que enseña a decidir estructura va a ser confrontado con un dominio ajeno —La Estancia «La Ana»— cuyo eje es precisamente el tema que el apunte no trata.

Cada hallazgo trae la sección, la cita textual corta que lo prueba y el parche. Lo que ya se cerró en ciclos anteriores se nombra como cerrado y no se reabre: el rechazo por excepción o por resultado (D-5), el umbral propio del *Value Object* (D-9), el 400 en lugar del 422, la decisión de no citar el libro de Evans de 2003 (E-3), la fábrica de Bloch sin materializar (F-4, R-3 como no-deuda) y la variante `ClienteApi/` descartada (R-4).

---

## 1. Estado del aparato crítico

Medido hoy sobre la v2.4.0: 154 enlaces internos, **0 rotos**; 66 remisiones distintas `§n.m`, **0 inexistentes** (el único «§15.5» es la cita del RFC 9110); 50 entradas en el Anexo E, **todas citadas al menos una vez desde el cuerpo**; 46 bloques de C#; 35 marcas `[Compilado]`; 15 `[Fragmento ilustrativo]`; 20 «Salida registrada»; 8 diagramas mermaid; 16 apariciones de «Criterio de esta guía» además de la fila de la leyenda; 110 citas textuales entre comillas latinas.

La guía declara su propia política de procedencia en §0.5, y esa política es la vara con la que se la juzga acá: «Toda cita de un **mecanismo** viene con tres cosas: el texto de la fuente, qué implica para quien diseña y el código que lo materializa».

### 1.1 Lo que se sostiene en laboratorio

Afirmaciones cuya evidencia es una corrida registrada y reproducible. Esta es la parte más fuerte del apunte y no requiere intervención.

| § | Afirmación | Evidencia |
| --- | --- | --- |
| 1.4 | «`using` abrevia nombres que el proyecto ya puede ver; no agrega nada que no pueda ver» | `CS0234`/`CS0246`, `capturas/L03-using-sin-referencia.txt` |
| 1.5 | «el comando que agrega la referencia la acepta; el error aparece recién al compilar» | `MSB4006`, códigos de salida 0 y 1, L04 |
| 2.3 | «la regla deja de ser una intención y pasa a ser un error de compilación» | L06 (`Build succeeded`) contra L07 |
| 3.4 | «la única forma de fijar un precio sea pasar por la regla que lo valida» | `CS0200`, L10 |
| 4.6 | «Una prueba en verde vale solo si se la vio fallar» | L11 (3+2 en verde) y L12 (1+1 en rojo) |
| 5.3 | «Domain no se recompila» | dos `sha256` idénticos, `Skipping target "CoreCompile"`, L16 |
| 5.5 | «La API responde `201` … pero la lista queda vacía» | L18 sin `SaveChanges` y L18 corregido |
| 5.6 | tres clases de error con tres respuestas | L19 (400 automático), L20 (500), L21 (400 ProblemDetails con cuerpo medido) |
| 5.4 | «EF Core llama a este constructor al leer cada fila» | V05 (`corrió 2 veces`), V07 (`No suitable constructor was found`), V09 (cuatro materializadores) |
| 3.8 | «factor 148x a favor del resultado» y «un resultado se puede ignorar; una excepción, no» | V06 (`4.559,2 ms / 296,0 B` contra `30,8 ms / 0,0 B`; `CA1806/IDE0058 = 0`; código 134) |
| 3.9, 5.4 | «El `enum` … no cierra nada» | V08 (`Estado = 9, IsDefined = False, y NO lanzó`) |
| 9.4 | vulnerabilidad y licencia de una dependencia | L24 (`GHSA-rvv3-g6hj-g44x`, `<license>` leído del `.nuspec`) |

### 1.2 Lo que se sostiene en documentación oficial

`rollForward` de `global.json` (§0.6), la forma sustantivo-primero de la CLI 10 (§1.2), el constructor que EF Core elige (§5.4), la inferencia de `[FromServices]` desde ASP.NET Core 7 (§5.2), el tratamiento del `decimal` en SQLite (§5.3), `DbSet.Add` contra `AddAsync` (§5.5), la propagación de constantes por el compilador (§7.2 d), el constructor único de `System.Text.Json` (§7.4), la política de soporte LTS/STS (§9.4) y la posición de Microsoft sobre los Repositories propios (§4.4, §5.5, §9.3). Todas con URL y fecha de consulta en el Anexo E.

### 1.3 Lo que se sostiene en bibliografía

Trece fuentes con cita textual: Evans (*DDD Reference* 2015), PoEAA —con las firmas corregidas en el ciclo 4: *Service Layer* de Stafford p. 133, *Repository* de Hieatt y Mee—, Martin 2012 y 2017, Meyer vía Eiffel Software, Business Rules Group 2000, Wirfs-Brock 2006, Kay 1998, Cockburn 2001, Hohpe y Woolf 2003, Bloch 2018, Gamma et al. 1994, Seemann 2011, Evans y Fowler 1997, Cwalina y Abrams 2008. El barrido del ciclo 4 verificó 45 de 51 citas textuales contra corpus local y dejó seis pendientes de red, ninguna sospechosa; ese saldo sigue vigente.

### 1.4 Criterio propio, rotulado

Dieciséis afirmaciones llevan la marca. Las que más gobiernan el texto: §3.2 («Esta guía llama *Business Rule* solo a las primeras»), §3.6 (las tres piezas que sostienen una *Invariant*), §3.8 («si el rechazo es esperable … se devuelve como valor»), §3.9 (el umbral del *Value Object*, «más estricto que las fuentes»), §4.1 (el sufijo `Dto` en sentido amplio), §4.5 (constructor explícito en lugar de *primary constructor*), §4.11 (cuándo `SaveChanges` sube al Handler), §5.4 («Ese camino no valida, y es deliberado … porque ninguna fuente lo manda»), §5.6 (400 y no 422), §7.6 (el término medio), §9.2 (la escalera) y §9.4 (no adoptar AutoMapper ni MediatR).

### 1.5 Criterio propio sin rotular: ocho afirmaciones

Es el hallazgo central de este apartado. Son tablas y listas que el lector va a leer como doctrina de la industria porque están escritas con el mismo tono que las sostenidas en fuente, y no tienen ni fuente ni rótulo. `Rule-Evidences` lo pide explícito: «lo que es criterio propio se declara como tal».

| # | § | Cita textual | Estado | Costo del parche |
| --- | --- | --- | --- | --- |
| A-1 | 8.3 | «Esta tabla es la única fuente de la regla en la guía; los demás capítulos remiten a ella» | La tabla de referencias permitidas —el corazón normativo del apunte— no cita a nadie ni se rotula. Palermo y Cockburn dan exactamente esa regla (§2.2) | 2 líneas |
| A-2 | 8.4 | «el patrón en inglés y da el sufijo; el concepto del problema en español y da la raíz» | Sólo la capitalización tiene fuente (Cwalina y Abrams). La regla de idioma es de la casa | 1 línea |
| A-3 | 4.3 | «Lo que hace decir “esto es un **Command**”» (cinco viñetas) y «un **Handler**» (cinco más) | Síntesis propia útil y sin respaldo declarado; la única fuente cercana es PoEAA p. 111, citada para otra cosa | 1 línea |
| A-4 | 7.1 | Columnas «Cambia cuando…» y «Existe solo si…» de los siete objetos | Sólo la fila del *Value Object* declara «umbral propio, más estricto que las fuentes»; las otras seis no | 1 línea |
| A-5 | 9.1, 9.3 | «Si la situación es… / Estructura de partida» y la tabla de señales | Propio salvo la última fila (Microsoft, 2018). §9.2 sí está rotulado: la marca se cortó una sección antes de tiempo | 2 líneas |
| A-6 | 3.7 | «Esta es **la** clasificación de la guía» | La frase dice que es de la guía pero no usa la marca que §0.5 definió para eso; la tabla de nueve filas se lee como taxonomía canónica | 1 palabra |
| A-7 | 2.5 | «un handler que recibe un `DbContext` no puede ser Singleton, porque retendría una sesión con la base para siempre» | Es cierto y está documentado por Microsoft como dependencia cautiva; acá va sin fuente y sin captura | 1 línea (cita) |
| A-8 | 3.2 / Anexo D | Anexo D: «Prueba del papel — Herramienta propia de la guía»; §3.2: «Martin define las Business Rules … y agrega que existirían aunque no hubiera una computadora» | Las dos cosas son verdad y conviven mal: la prueba es una operacionalización de Martin, no un invento. Conviene decir «derivada de Martin (2017)» | 1 línea |

---

## 2. Huecos bibliográficos

### 2.1 El hueco mayor: la jerarquía de tipos

Medición: en las 2818 líneas del apunte, `herencia` aparece **0 veces**, `polimorfismo` **0**, `jerarquía` **0**, `Liskov` **0**, `clase abstracta` **0**, `virtual`/`override` sólo dentro del `DelegatingHandler` ilustrativo de §6.5, y las cinco apariciones de «hereda» son la frase «una clase que hereda de `Exception`» y el escenario E-C de base *heredada*. El apunte enseña Entity, Value Object, Aggregate, Command, Handler, Repository, DTO, ViewModel, form model y persistence model, y **nunca dice cuándo la respuesta correcta es una jerarquía de tipos ni cuándo es un error**.

Mientras el dominio conductor fue una tienda con `Producto` y `Pedido`, el hueco no se notaba. La actividad lo vuelve estructural: la fuente primaria es una actividad de cátedra cuyo eje declarado son «interfaces y clases abstractas», con `ActividadProductiva` abstracta, `Ganadera` abstracta intermedia y cuatro hojas —`Agricola`, `Cria`, `Recria`, `Invernada`— que calculan producción y rendimiento con **fórmulas distintas** (RN-15, RN-16). El alumno que lea el apunte para resolver la actividad no va a encontrar ni una línea sobre el tema que la actividad evalúa, y la Tarea 2 del enunciado —agregar un subtipo nuevo y medir cuánto cuesta— es literalmente el banco de pruebas de una jerarquía bien puesta.

El hueco es de **P0** y arrastra tres citas que hoy no están:

| Fuente | Cita verificada hoy | Qué aporta y dónde |
| --- | --- | --- |
| **Liskov, B. (1987)**, *Data Abstraction and Hierarchy*, OOPSLA'87 Addendum (keynote) | «What is wanted here is something like the following **substitution property**: If for each object o1 of type S there is an object o2 of type T such that for all programs P defined in terms of T, the behavior of P is unchanged when o1 is substituted for o2, then S is a subtype of T» | El criterio que decide si `Cria`/`Recria`/`Invernada` es una jerarquía legítima: si un programa escrito contra `ActividadProductiva` sigue comportándose igual con cualquier subtipo. Va en la sección nueva de §3 |
| **Liskov, B. y Wing, J. (1994)**, *A Behavioral Notion of Subtyping*, ACM TOPLAS | «**Subtype Requirement:** Let Φ(x) be a property provable about objects x of type T. Then Φ(y) should be true for objects y of type S where S is a subtype of T» | La formulación en términos de propiedades demostrables: conecta la jerarquía con las *Invariants* de §3.1 y con el *Design by Contract* de §3.6, que el apunte ya tiene. Una *Invariant* de la base debe seguir valiendo en cada subtipo |
| **Fowler, M. (s. f.)**, catálogo de *Refactoring*: *Replace Conditional with Polymorphism* | Nombre verificado en `refactoring.com/catalog/replaceConditionalWithPolymorphism.html`; el ejemplo del catálogo transforma un `switch` sobre tipos de pájaro en clases con su propio `plumage`. La página no publica la frase de motivación: **no citar motivación que no se vio** | Es la operación exacta que el enunciado ejercita, y el hermano de la refactorización que §3.1 ya cita (*Replace Constructor with Factory Function*), del mismo catálogo y del mismo autor: entra sin abrir una fuente nueva |

Y le da otro peso a una fuente **ya citada**: el *Anemic Domain Model* (Fowler, 2003), hoy usado en §3.6 y §9.6 paso 4 para el caso de los setters. Una jerarquía donde los subtipos sólo agregan campos y el cálculo vive en un `switch` del handler es el mismo diagnóstico en su forma más visible: el subtipo existe y no hace nada.

### 2.2 Autores ausentes, con cita verificada y destino

Verificado en esta corrida; ninguno está en el Anexo E (`grep` sobre el apunte: `Cockburn` 3 veces, todas por *Writing Effective Use Cases*; `Onion`, `Palermo`, `hexagonal`, `Ports and Adapters`, `Presentation Domain`, `Microservice Premium`: 0).

| Fuente | Cita verificada | Dónde entra | Prioridad |
| --- | --- | --- | --- |
| **Cockburn, A. (2005)**, *Hexagonal Architecture / Ports and Adapters*, v0.9, HaT Technical Report 2005.02 | «Allow an application to equally be driven by users, programs, automated test or batch scripts, and to be developed and tested in isolation from its eventual run-time devices and databases» | §2.4. Es la intención, palabra por palabra, de lo que el apunte ya hace y explica sin nombrar: `IProductoRepository` es un puerto y `ProductoRepository`, `InMemoryProductoRepository` y `FakeProductoRepository` son tres adaptadores del mismo puerto —dos de ellos ya compilados (§4.6, §5.5)—. El vocabulario puerto/adaptador también le da nombre al adaptador del escenario E-C (§7.2 g) | P1 |
| **Palermo, J. (2008)**, *The Onion Architecture: part 1* | «All code can depend on layers more central, but code cannot depend on layers further out from the core» y «The Domain Model is the very center, and since all coupling is toward the center, the Domain Model is only coupled to itself» | §2.1 y §8.3. La segunda frase es exactamente la línea `MyProject.Domain — 0 referencias` del Diagrama 2.3, medida en L08. Además es el linaje .NET de la idea, que es el público de esta guía | P1 |
| **Fowler, M. (2015)**, *Presentation Domain Data Layering* (26 de agosto de 2015) | «reduce the scope of my attention by allowing me to think about the three topics relatively independently»; «build multiple presentations on top of the same domain logic without duplicating it»; y el límite: «presentation-domain-data separation is a common approach, it should only be applied at a relatively small granularity» | §2.6 («¿Qué se gana y qué se paga?») y §9.2. Las dos primeras frases son las dos columnas de la tabla de §2.6 dichas por la fuente; la tercera es el argumento de la escalera dicho por Fowler, y hoy §9.2 se apoya sólo en la distinción *Transaction Script*/*Domain Model* | P1 |
| **Fowler, M. (2015)**, *Microservice Premium* (13 de mayo de 2015) | «The majority of software systems should be built as a single monolithic application. Do pay attention to good modularity within that monolith, but don't try to separate it into separate services» | §0.1 y el cierre de §9.2. El apunte manda los microservicios a otra guía en una línea; con esta cita la remisión deja de ser administrativa y pasa a ser criterio: el escalón 4 es el techo de esta guía **por decisión**, no por falta de espacio | P2 |

### 2.3 Autores presentes y subaprovechados

- **Martin, R. C. (2017)**, *Clean Architecture*. Citado una sola vez, para el capítulo 20 («Business Rules»), mientras que la regla de dependencia se apoya en el artículo de 2012. El libro tiene dos cosas que el apunte necesita: la ubicación de las interfaces de acceso a datos en la capa de *Use Cases* —que contradice lo que el apunte hace y es la tensión **T-1** de §3— y el tratamiento de la base de datos como detalle, que es el argumento de §5.3 medido con el `sha256`. **P1**: al menos declarar la divergencia.
- **Cwalina, K. y Abrams, B. (2008)**, *Framework Design Guidelines*. Citado sólo por la capitalización, en una sección —§8.4— que es entera sobre nombres. Las guías tienen material directo para lo que ahí se decide: sustantivos para los tipos, prefijo `I` para las interfaces, evitar abreviaturas y nombres dependientes del lenguaje. **P2**, y conviene verificar el texto exacto contra la fuente antes de citarlo: en esta corrida no se verificó.
- **Evans, E.**, *DDD Reference* (2015). La mesa decidió en el ciclo 3 (E-3) no apoyarse en el libro de 2003 mientras no esté a la vista, y eso está bien aplicado. El costo queda invisible para el lector: la *Reference* es un resumen de patrones, no el libro, y el apunte cita nueve veces «Evans» sin decir que su única fuente es ese resumen. **P2**: una línea en el Anexo E que lo diga. No reabrir E-3.
- **Cockburn, A. (2001)**, *Writing Effective Use Cases*. Bien usado en §4.10. Con la actividad encima rinde más: los quince casos de uso de La Estancia son el material para ejercitar el formato completo que §4.10 enseña con uno solo.

### 2.4 Lo que no hay que traer

Se evaluó y se descarta, para que ningún ciclo posterior lo proponga de nuevo: Vernon (*Implementing DDD*) y Richardson (*Microservices Patterns*) exceden el alcance declarado en §0.1; Nygard (*Release It!*) pertenece a operación, que la guía no trata; el catálogo de GoF más allá de *Command*, *Factory Method* y *Decorator* engordaría §4 sin cambiar ninguna decisión. El criterio es el del ciclo 1 y sigue valiendo: una fuente entra cuando cambia lo que el lector decide.

---

## 3. Tensiones conceptuales para la mesa

Siete preguntas, cada una con las dos posiciones y la evidencia de cada lado. Ninguna está resuelta en el apunte; cuatro están resueltas de un modo que la mesa puede sostener o revisar, pero sin decir que eligió.

**T-1 · ¿Dónde vive la interfaz del *Repository*: en `Domain` o en `Application`?**
El apunte pone `IProductoRepository` en `Domain` (§3.3) y al mismo tiempo declara que sus cuatro proyectos son los cuatro círculos de Martin (§2.1, tabla «Círculo → Proyecto»), donde `Domain` es el círculo *Entities*.
*Posición A (lo que el apunte hace)*: Evans ubica el *Repository* en el dominio —«the illusion of an in-memory collection of all objects of that aggregate's root type»— y Palermo pone el *Domain Model* en el centro acoplado sólo a sí mismo. La interfaz la declara quien la necesita, que es la regla que §2.2 paso 1 enseña con `IAlmacenDeProductos`.
*Posición B*: en *Clean Architecture* la interfaz de acceso a datos pertenece a la capa de *Use Cases*, no a la de *Entities*; quien necesita persistir no es la Entity sino el caso de uso. Con eso, `IProductoRepository` iría en `Application` y `Domain` quedaría sin una sola interfaz.
*Qué decide*: si la mesa sostiene A, el apunte debe declarar que se aparta de la ubicación de Martin aunque adopte sus círculos —hoy la contradicción está y no se nombra—. La evidencia de A ya está compilada; la de B exige citar el libro de 2017, que hoy se cita una sola vez.

**T-2 · ¿Cuándo una jerarquía de tipos es la respuesta del `Domain` y cuándo es un error?**
*Posición A (polimorfismo)*: `ActividadProductiva` abstracta con `Produccion()` y `Rendimiento()` abstractos; cada subtipo trae su fórmula. Evidencia: RN-14/15/16 dicen que los datos de cierre y la unidad del rendimiento son «propios del tipo»; *Replace Conditional with Polymorphism* nombra la operación; Liskov da el criterio de legitimidad; y la Tarea 2 del enunciado mide el costo de agregar un subtipo, que con polimorfismo es una clase nueva y ningún `switch` tocado.
*Posición B (composición / estrategia)*: una sola `ActividadProductiva` con una `FormulaDeProduccion` inyectada. Evidencia: evita el mapeo TPH de EF Core, permite cambiar la fórmula sin cambiar el tipo del objeto y es lo que el propio apunte predica cuando dice que una clase aparece «cuando hay dos papeles que separar» (§7.4).
*Posición C (tabla de parámetros)*: los tipos difieren sólo en **datos** y el cálculo es uno solo parametrizado. Evidencia en contra: las cuatro fórmulas no son la misma con otros coeficientes —«kilos finales menos kilos iniciales, contados sobre el total de los animales» no es «toneladas por hectárea»—.
*Qué decide*: si la diferencia entre subtipos es de **comportamiento** y es del negocio, A; si es de datos, B o C. Esa frase no existe hoy en el apunte y es el parche P0-1.

**T-3 · ¿Se declara una referencia antes de que exista la señal que la justifica?**
§2.7 agrega `Infrastructure → Application` y lo admite en el mismo párrafo: «En el laboratorio esa referencia queda declarada pero sin uso: ningún archivo de `Infrastructure` nombra un tipo de `Application` (se comprueba con `grep -rn Application src/Backend/MyProject.Infrastructure --include=*.cs`, que no devuelve nada)».
*Posición A (lo que el apunte hace)*: se declara porque una solución real la va a necesitar, y la variante de §4.10 la usa con `IUnitOfWork`.
*Posición B*: contradice el criterio de una línea del §9.8 —«Cada capa y cada clase se agrega cuando aparece la señal que la justifica»— y la fila de §9.3 que llama sobreingeniería a lo que no trabaja. El propio laboratorio aporta el `grep` que prueba que no hace falta.
*Qué decide*: o se saca del esqueleto de L08 y aparece en la variante, donde sí trabaja, o se declara como apartamiento explícito. Hoy queda como excepción no rotulada a la regla que el apunte cierra en su última línea.

**T-4 · ¿Una *Invariant* declarada que el flujo de casos de uso no sostiene, se hace cumplir o se reclasifica?**
Caso real en la fuente de la actividad: RN-13 dice «toda actividad tiene al menos un lote asignado», y el CU-11 da de alta la actividad **antes** de asignarle lotes; RN-12 dice que una actividad sin lotes no se puede cerrar.
*Posición A (se hace cumplir)*: si es *Invariant*, el alta debe recibir el primer lote y `ActividadProductiva.Create` lo exige. Evidencia: §3.6, las tres piezas —la fábrica la establece, el setter privado la protege, cada método la reverifica—.
*Posición B (se reclasifica)*: es la *Precondition* del acto de cerrar, y RN-12 ya la cubre; RN-13 sobra. Evidencia: §3.7 entero, y la fila «Un pedido confirmado se pide con al menos un ítem … **Sí**, del *Aggregate* → `Pedido.Confirmar`», que es el mismo caso resuelto con otro nombre.
*Qué decide*: el apunte ya tiene la maquinaria para responder —es el mejor ejemplo de transferencia que apareció en cuatro ciclos—, pero no tiene ningún caso donde el enunciado se contradiga a sí mismo. Es material para §9.7.

**T-5 · Si el `Domain` tiene jerarquía, ¿el mapeo sigue declarándose afuera?**
*Posición A*: sí, sin cambios: EF Core mapea la jerarquía con TPH y el discriminador se configura en la Fluent API, como `ProductoConfiguration` (§5.4).
*Posición B*: el discriminador es una decisión de esquema que, a diferencia de `HasMaxLength`, sí determina qué tipos pueden existir; una jerarquía con TPT o con tablas por hoja cambia las consultas y el rendimiento, y eso empuja al *persistence model* del escenario E-C antes de lo que §7.2 g sugiere («casi nunca hace falta»).
*Qué decide*: hace falta una corrida. Hoy ninguna variante del laboratorio mapea una jerarquía, así que cualquier afirmación sobre esto sería prosa; es la clase de cosa que la mesa manda a medir antes de escribir.

**T-6 · ¿La escalera de §9.2 vale para un dominio sin persistencia?**
El escalón 1 se llama «Página → EF Core» y §9.6 empieza con «Hay que guardar personas». La fuente de la actividad dice lo contrario: «No define persistencia. No hay base de datos, archivo ni repositorio en el enunciado: el estado vive en memoria mientras corre la aplicación».
*Posición A*: la escalera sigue valiendo y el estado en memoria es un adaptador más del mismo puerto; el apunte ya tiene `InMemoryProductoRepository` compilado (L13) y el Singleton que lo explica (§2.5).
*Posición B*: la escalera confunde dos ejes —cuántas capas y cuánta tecnología— y por eso el escalón 1 nombra un ORM. Un dominio rico sin base es exactamente el caso E-D con persistencia nula, y la escalera no lo tiene.
*Qué decide*: si se sostiene B, alcanza con renombrar el escalón 1 («un proyecto: pantalla → servicio → almacenamiento») y decirlo; el resto de la escalera no se toca.

**T-7 · ¿«DTO» significa una cosa o dos?**
§5.1 reserva el término: «Son los únicos objetos de la guía que cumplen la definición al pie de la letra: cruzan el proceso». §4.1 mantiene el sufijo en el objeto que no lo cumple: «el sufijo `Dto` del laboratorio se usa en ese sentido amplio, no en el de §5.1. **Criterio de esta guía**».
*Posición A (lo que hay)*: está declarado, y renombrar `ProductoDto` obliga a regenerar capturas que la mesa congeló.
*Posición B*: el apunte enseña que el nombre dice el papel (§7.4, §8.4) y después conserva un nombre que no dice el papel; el lector que copie la convención va a llamar `Dto` a todo.
*Qué decide*: si la mesa sostiene A, conviene que el Anexo D registre `ProductoDto` como alias del término canónico «modelo de lectura», que es lo que `Rule-Dual-Audience` pide para los sinónimos. Costo: una fila.

---

## 4. Consistencia editorial

El estado mecánico es sano (§1). Lo que sigue es de estructura, vocabulario y promesas.

| # | § | Hallazgo | Evidencia | Costo |
| --- | --- | --- | --- | --- |
| **C-1** | 3.9 | La sección que el Profile reserva para la pregunta de cierre carga además un tema nuevo y sustantivo: el título es «Pregunta de cierre» y adentro vive «Un conjunto cerrado que de verdad esté cerrado», con `Moneda.cs` compilado, la medición de V08 y tres formas comparadas. Es el único cierre de capítulo que no es una pregunta | §3.9 contra §1.6, §2.8, §4.12, §5.7, §6.6, §8.6 | Partir en §3.9 (conjunto cerrado) y §3.10 (cierre); 14 remisiones a revisar |
| **C-2** | 3 | Es el único capítulo de la Parte II sin un solo diagrama: 8 mermaid en el documento, ninguno entre las líneas 533 y 938. Quedó pendiente del ciclo 4 (F-11, «sólo si F-6 deja lugar»), y F-6 dejó lugar | conteo por rango | +10 líneas |
| **C-3** | 0.5 | La promesa «Toda cita de un mecanismo viene con tres cosas … una cita va sola sólo cuando habla del método de esta guía» tiene una excepción legítima y no prevista: §4.8 cita a Fowler sobre CQRS, que es un mecanismo, para decir que el ejemplo **no** lo adopta. La regla debería contemplar la cita que sostiene una negativa | §4.8 contra §0.5 | 1 línea |
| **C-4** | 4.1, 4.5 | Oscilación de término declarada pero no registrada como alias: «modelo de lectura» en la prosa y `Dto` en el código y en las capturas (ver T-7) | Anexo D define «Modelo de lectura» y «DTO» por separado, sin cruzarse | 1 fila |
| **C-5** | 3.6, 4.1 | Dos «mensaje» distintos conviven: el *Message* entre objetos («Kay escribió que “The big idea is messaging”») y el mensaje Command/Query. El Anexo D lo advierte —«No confundir con el mensaje Command o Query»—, pero el Diagrama 4.1 usa el segundo sentido en una sección que acaba de usar el primero | §3.6 / §4.2 | 1 línea en la leyenda del diagrama |
| **C-6** | frontmatter | `traces: [NC-01…NC-10, R-01…R-17]` apunta a identificadores que viven sólo en `Lab-Documentos.Documentacion/PROMPTs/.../OUTPUTs/`, otro repositorio: quien lee la guía no puede resolverlos. `Rule-Dual-Audience` pide que las trazas apunten a IDs, y estos existen, pero el documento no dice dónde | `grep -rl "R-17"` resuelve en `OUTPUTs/Bitacora/02-Requisitos.md` y `OUTPUTs/Mesa/` | 1 línea |
| **C-7** | 0.1, frontmatter | `related: [Microservicios-Guide.md]` y la remisión de §0.1 apuntan a un documento que no comparte el contrato: `Microservicios-Guide.md` no tiene frontmatter, no tiene `doc_id` y no cita ninguna fuente bibliográfica. La remisión es válida; la simetría no existe | primeras 20 líneas del documento hermano; `grep -c Fowler` = 0 | 1 línea (declarar la asimetría) |
| **C-8** | 9.7 | Los dos ejercicios de transferencia traen su respuesta inmediatamente debajo, bajo el título «**Respuestas.**». El propio texto pide «conviene escribir la respuesta antes de leer la que cierra la sección», y la maquetación no ayuda a cumplirlo | §9.7 | Mover las respuestas a un Anexo F, o marcarlas con un separador visible |
| **C-9** | Anexo A | «Dos cosas que el laboratorio **no** construye, por decisión y no por olvido» quedó desactualizado por el ciclo 4: los pasos 5 y 6 de §9.6 ya entraron en código (F-8), y el texto sigue justificando por qué no están | §9.6 bloque de deltas contra el párrafo del Anexo A | 2 líneas |

---

## 5. Plan de edición priorizado

Cada ítem está escrito para aplicarse tal cual. Las citas nuevas entran con las tres cosas que §0.5 exige: texto de la fuente, qué implica y código que lo materializa. Nada de lo que sigue exige regenerar las capturas `L00`–`L24`.

### P0 — Antes de que la actividad empiece a usar el apunte

**P0-1 · §3, sección nueva: «¿Cuándo una jerarquía de tipos es la respuesta?»**
En §3, **agregar** una sección entre §3.8 y el cierre (numeración según C-1), con esta forma: respuesta en negrita —«cuando los subtipos se diferencian por **comportamiento** que el negocio nombra, no por los datos que guardan; y sólo si todo lo que vale para el tipo base sigue valiendo para cada subtipo»—, la cita de Liskov (1987) con su explicación, la de Liskov y Wing (1994) atando el subtipado a las *Invariants* que §3.1 ya definió, y el nombre de la operación, *Replace Conditional with Polymorphism*, del mismo catálogo que §3.1 ya cita. Materialización: un bloque con la clase base abstracta y dos hojas con la misma firma y fórmulas distintas, más el contraejemplo `switch (tipo)` marcado `[Fragmento ilustrativo: contraejemplo]`. Cerrar con los tres ❌ que el apunte sabe formular: jerarquía para compartir código, jerarquía donde los subtipos sólo agregan campos —es el *Anemic Domain Model* de §9.6 paso 4 con otra cara— y subtipo que rompe lo que la base prometía. Si la actividad La Estancia se compila, el bloque sale de `ActividadProductiva`/`Agricola`/`Cria` y es `[Compilado]`; mientras no se compile, va ilustrativo y declarado.

**P0-2 · §7.1, fila nueva en la tabla de los siete objetos.**
La tabla dice hoy qué objeto responde cada pregunta. **Agregar** la octava fila: «**Jerarquía de tipos** | `ActividadProductiva` → `Agricola`, `Ganadera` | ¿Qué varía según el tipo, y qué vale para todos? | Domain | cambia el conjunto de tipos o una fórmula | hay comportamiento que difiere por tipo (§3.x)». El capítulo 7 se llama «Cada objeto responde una pregunta» y hoy no tiene la pregunta que la actividad hace.

**P0-3 · Rotular el criterio propio sin rótulo.**
Aplicar A-1 a A-8 de §1.5: en §8.3 agregar, después de «Esta tabla es la única fuente de la regla en la guía», «**Criterio de esta guía**, construido sobre la regla de dependencia ([Martin, 2012](#ref-martin-2012)) y la formulación de Palermo (2008)»; en §8.4, §4.3, §7.1, §9.1, §9.3 y §3.7, la marca sola; en §2.5, la fuente de la dependencia cautiva; en el Anexo D, «Prueba del papel — herramienta de esta guía, derivada de la definición de Martin (2017)». Es cumplimiento de `Rule-Evidences` y cuesta menos de diez líneas en total.

**P0-4 · §2.1 y §4.4, declarar la divergencia de T-1.**
En §2.1, debajo de la tabla «Círculo → Proyecto», **agregar**: «Una salvedad sobre el mapeo: Martin ubica las interfaces de acceso a datos en el círculo de los *Use Cases*; esta guía las declara en `Domain`, con Evans y con la *Onion Architecture*, porque la interfaz la declara quien la necesita (§2.2, paso 1). **Criterio de esta guía**, declarado para que el lector que venga del libro de 2017 sepa que acá hay una elección.» Hoy el apunte adopta los cuatro círculos y contradice uno sin avisar.

**P0-5 · §2.7, resolver la referencia sin uso.**
Reemplazar la frase «esa referencia queda declarada pero sin uso» por la decisión: o se saca de L08 y aparece cuando la variante la necesita —coherente con §9.8—, o se declara «**Apartamiento declarado**: se agrega antes de la señal para que el esqueleto sea el de una solución real; con el criterio del §9.8, en un proyecto propio esta flecha se agrega recién con la primera interfaz de servicio técnico». Si se saca, el Diagrama 2.3 y la tabla de §8.3 se ajustan.

### P1 — En el mismo ciclo, si el presupuesto alcanza

**P1-1 · §2.4, nombrar puertos y adaptadores.** Agregar la cita de Cockburn (2005) con su explicación y la remisión a los tres adaptadores ya compilados del mismo puerto (`ProductoRepository`, `InMemoryProductoRepository`, `FakeProductoRepository`). Entrada nueva en el Anexo E. Cierra además el vocabulario del adaptador de E-C (§7.2 g).

**P1-2 · §2.1 y §8.3, citar a Palermo (2008).** «The Domain Model is the very center, and since all coupling is toward the center, the Domain Model is only coupled to itself» junto al `MyProject.Domain — 0 referencias` del Diagrama 2.3, que es esa frase medida en L08.

**P1-3 · §2.6 y §9.2, citar *Presentation Domain Data Layering* (2015).** Las dos primeras frases sostienen las dos columnas de la tabla «Se gana / Se paga»; la tercera —«it should only be applied at a relatively small granularity»— es el argumento de la escalera dicho por la fuente, y hoy §9.2 se apoya sólo en *Transaction Script* contra *Domain Model*.

**P1-4 · C-1, partir §3.9.** Pasar «Un conjunto cerrado que de verdad esté cerrado» a sección propia y dejar la pregunta de cierre sola, como en los otros siete capítulos. Renumerar y revisar las remisiones a §3.9 (14 apariciones).

**P1-5 · C-2, el diagrama que falta en el capítulo 3.** Tres cajas y dos flechas: regla → objeto que conoce el dato → método que la hace cumplir, con los tres tipos del BRG como etiquetas. Reemplaza prosa, no la agrega.

**P1-6 · §9.7, ejercicio nuevo con la contradicción de T-4.** «Una regla dice que toda actividad tiene al menos un lote; el caso de uso da de alta la actividad antes de asignarle lotes. ¿Es *Invariant*, es *Precondition*, o sobra?». La respuesta se construye con la tabla de §3.7 sin agregar teoría nueva, y es el primer ejercicio del apunte donde el enunciado se contradice a sí mismo, que es lo que pasa en los enunciados reales.

### P2 — Cuando haya ciclo disponible

**P2-1 · §0.1 y §9.2, *Microservice Premium*** como criterio del techo de la guía (§2.2).
**P2-2 · §8.4, ampliar el uso de Cwalina y Abrams** más allá de la capitalización, verificando el texto contra la fuente antes de citarlo.
**P2-3 · Anexo E**, una línea en la entrada de Evans que diga que la fuente usada es la *Reference* de 2015 y no el libro de 2003, con el motivo (decisión E-3 del ciclo 3).
**P2-4 · T-5, medir antes de escribir**: una variante que mapee una jerarquía con EF Core (TPH y TPT) y muestre qué cambia en las consultas; recién con la captura se puede decir algo en §5.4 y §7.2 g.
**P2-5 · C-3 a C-9**: la excepción de §0.5 para la cita que sostiene una negativa; `ProductoDto` como alias en el Anexo D; la leyenda del Diagrama 4.1; dónde viven las trazas del frontmatter; la asimetría con `Microservicios-Guide.md`; las respuestas de §9.7 a un anexo; y el párrafo del Anexo A que quedó desactualizado por F-8.

### Presupuesto propuesto

P0 completo: **+70 a +90 líneas**, 1 bloque compilado nuevo (o ilustrativo mientras La Estancia no compile) y 1 contraejemplo, 2 entradas nuevas en el Anexo E (Liskov 1987; Liskov y Wing 1994) más una remisión al catálogo de refactorizaciones ya citado. P1 completo: **+40 a +55 líneas** y 3 entradas más (Cockburn 2005, Palermo 2008, Fowler 2015). Versión resultante: **v2.5.0** —agrega secciones y cambia numeración en el capítulo 3—.

---

## 6. Verificaciones de esta corrida

| Qué | Cómo | Resultado |
| --- | --- | --- |
| Enlaces internos y anclas | script python sobre encabezados, `<a id=…>` y `](#…)` | 154 enlaces, **0 rotos** |
| Remisiones `§n.m` contra encabezados reales | script python | 66 distintas, **0 inexistentes** |
| Referencias del Anexo E sin uso | script python | 50 entradas, **0 sin citar** |
| Conteos | script python | 46 bloques C#, 35 `[Compilado]`, 15 `[Fragmento ilustrativo]`, 20 «Salida registrada», 8 mermaid, 132 tablas, 110 citas textuales |
| «Criterio de esta guía» | `grep -n` | 16 + la fila de la leyenda de §0.5 |
| Ausencia del eje jerarquía | `grep -ci` sobre 14 términos | `herencia` 0, `polimorf` 0, `jerarqu` 0, `Liskov` 0, `clase base` 0, `override` 1 (en `DelegatingHandler`), `hereda` 5 (todas ajenas al tema) |
| Autores ausentes | `grep -c` | `Hexagonal` 0, `Ports and Adapters` 0, `Onion` 0, `Palermo` 0, `Presentation Domain` 0, `Microservice Premium` 0, `Replace Conditional` 0 |
| Cockburn, *Hexagonal Architecture* | `WebFetch` a `alistair.cockburn.us/hexagonal-architecture/` | Intención verificada verbatim; v0.9, 2005-09-04, HaT TR 2005.02 |
| Palermo, *The Onion Architecture: part 1* | `WebFetch` | Título, fecha (2008-07-29) y dos frases verificadas |
| Fowler, *Presentation Domain Data Layering* | `WebFetch` | Fecha (2015-08-26) y tres frases verificadas, incluida la del límite |
| Fowler, *Microservice Premium* | `WebFetch` | Fecha (2015-05-13) y dos frases verificadas |
| Fowler, *Replace Conditional with Polymorphism* | `WebFetch` al catálogo | Nombre y ejemplo verificados; **la página no publica frase de motivación**: no citar ninguna |
| Liskov, *Data Abstraction and Hierarchy* (1987) | `WebFetch` + `pdftotext` sobre el PDF | *Substitution property* verificada verbatim |
| Liskov y Wing, *A Behavioral Notion of Subtyping* (1994) | `WebFetch` + `pdftotext -layout` | *Subtype Requirement* verificada verbatim (el OCR del PDF trae ruido tipográfico; la transcripción se normalizó y debe cotejarse contra la edición de ACM antes de publicarse) |
| Trazas del frontmatter | `grep -rl "R-17"` sobre `OUTPUTs/` | Resuelven en `Bitacora/02-Requisitos.md` y `Mesa/`, fuera del repositorio de la guía |
| Documento hermano | lectura de `Microservicios-Guide.md` | Sin frontmatter, sin `doc_id`, `grep -c Fowler` = 0 |

**Limitaciones declaradas.** No se verificaron en esta corrida las seis citas que el ciclo 4 dejó pendientes de red (O-1…O-6), ni el texto de Cwalina y Abrams que P2-2 propone citar. No se compiló nada: todo lo que este dictamen propone como `[Compilado]` está condicionado a que la solución `LaEstancia` —hoy con `LaEstancia.slnx`, `global.json` y `src/Backend/LaEstancia.WebAPI` sobre SDK 10.0.400, con OpenAPI y Scalar respondiendo 200 según la verificación del 2026-09-24— llegue a tener el `Domain` de la actividad. Mientras tanto, el bloque de P0-1 entra como `[Fragmento ilustrativo]` con su motivo, que es lo que §0.5 manda.

---

## Punto de continuación

Este dictamen no aplicó ningún cambio. Lo que sigue: llevar a la mesa las siete tensiones del §3 —T-1, T-2 y T-3 son las que bloquean la fase interactiva—, adoptar o recortar el plan del §5 y, recién ahí, editar la guía en una rama propia con `Exercices/` fuera de alcance y stageo explícito.
