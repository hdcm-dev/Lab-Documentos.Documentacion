# Informe de la comisión especialista .NET/C# — fábricas, resultados y valores

- **Fecha:** 2026-09-20
- **Comisión:** especialista .NET/C# (Ciclo-2 de la mesa sobre la guía de arquitectura .NET). Trabajo a ciegas: no se leyó ningún informe de otras comisiones de este ciclo.
- **Objeto principal:** `LAB/Lab-Documentos/Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md` (v2.1.0) y su laboratorio en `Examples/Dot-NET-Arquitectura-Lab/`.
- **Objeto adicional (leído, no editado):** `PROG2/Geometria/Lab-Geometria/src/GeometriaFactory.Domain/` — `Entities/Work.cs`, `Entities/Account.cs`, `Guards/DomainResult.cs`, `Guards/Admission.cs`, `Values/*.cs` — y, para el mapeo, `src/GeometriaFactory.Infrastructure/Persistence/Configurations/WorkConfiguration.cs` y `src/GeometriaFactory.Application/`.
- **Competencia de esta comisión:** mecánica de C# y de EF Core; costo medible (tiempo, memoria, líneas, avisos del compilador). No se pronuncia sobre pedagogía, redacción ni orden del documento.
- **Caso que origina el encargo (PO, 2026-09-20, literal):** «en el Domain del proyecto GeometriaFactory.Domain aparece el Entity discutido en el documento, pero en el proyecto también aparecen los Guards, y estoy viendo al uso tradicional del constructor, es que en los entity el constructor pasa a ser privado y se crea una suerte de método tipo factory, porque es static y un método create — podés ampliar este tema». Addendum del mismo día: «…qué pasa con estas Guards y estos Values, dónde encajan en esa línea de pensamiento».

**Anclas de evidencia usadas en este informe**

| Ancla | Significado |
| --- | --- |
| **E1** | Ejecutado por esta comisión en `mcr.microsoft.com/dotnet/sdk:10.0` (digest `sha256:e1ffd2a9…7a64c`, el mismo del laboratorio). Se cita comando y salida literal. |
| **E2** | Documentación oficial (`learn.microsoft.com`), citada textualmente. |
| **E3** | Código fuente leído del proyecto real `Lab-Geometria` (ruta y línea). |
| **E4** | Texto de la guía (sección y línea). |
| **C** | Criterio de esta comisión, sin medición posible o sin medición hecha. |

Ninguna medición se hizo dentro del repositorio de Geometría ni dentro del laboratorio de la guía: todo corrió en el scratchpad de la sesión, en contenedor, con `--user $(id -u):$(id -g)`, y los `bin/obj` se borraron dentro del contenedor al terminar (§ Fuentes y comandos, paso 7).

---

## 1. Lo que la mecánica dice, medido

### 1.1 El constructor privado sin parámetros: ¿EF Core lo usa de verdad?

Sí, y es el primer camino que intenta. La documentación oficial es explícita (**E2**):

> «When EF Core creates instances of these types, such as for the results of a query, it will first call the default parameterless constructor and then set each property to the value from the database. However, if EF Core finds a parameterized constructor with parameter names and types that match those of mapped properties, then it will instead call the parameterized constructor…»
> «The constructor can be public, private, or have any other accessibility. However, lazy-loading proxies require that the constructor is accessible from the inheriting proxy class.»
> — [Entity types with constructors, EF Core](https://learn.microsoft.com/en-us/ef/core/modeling/constructors)

Medido (**E1**, proyecto `EfCtor`, EF Core 10.0.12, SQLite, entidad calcada del par `Producto`/`Work`: constructor privado sin parámetros, setters privados, `private readonly List<Item> _items` expuesto como `IReadOnlyList<Item> Items => _items`, fábrica `Create`):

```text
A1 ctor elegido = private Producto()
A2 propiedades mapeadas = Id,Activo,Nombre,Precio
A3 nav Items: campo=_items accessMode=PreferField
A4 Precio: campo=<Precio>k__BackingField accessMode=PreferField
A5 releido: Nombre=Mate Precio=3500.0 Activo=True Items=1
A6 el ctor privado corrio 1 vez/veces durante la relectura
```

Cuatro consecuencias medidas:

1. **No hace falta nada especial.** Ni `UsePropertyAccessMode`, ni campos de respaldo escritos a mano, ni `internal`/`protected`: con el constructor privado sin parámetros y setters privados, el modelo mapea las cuatro propiedades (A2) y la relectura llama al constructor privado exactamente una vez por fila (A6).
2. **El setter privado sí importa.** EF ve la propiedad con setter privado como lectura/escritura (E2) y por eso la mapea; ver 1.3.
3. **La colección por campo la resuelve la convención.** A3 muestra que EF encontró `_items` y quedó en `PreferField` sin que nadie lo pidiera. En `Lab-Geometria`, `WorkConfiguration.cs` l. 56 y l. 63 declaran `builder.Navigation(w => w.Pieces).UsePropertyAccessMode(PropertyAccessMode.Field)` (**E3**): es redundante frente a la convención, pero es documentación ejecutable y no cuesta nada. No es un error.
4. **La precisión decimal se pierde en SQLite**: A5 devuelve `3500.0`, que es exactamente lo que la guía ya dice en §5.4 sobre `HasPrecision` (ver «lo que está bien», B2).

### 1.2 Qué pasa si la Entity no tiene constructor sin parámetros

Dos desenlaces, los dos medidos (**E1**):

- Si existe **un constructor con parámetros cuyos nombres y tipos coinciden** con propiedades mapeadas (Pascal ↔ camel), EF lo usa y no asigna esas propiedades una por una:
  ```text
  B1 ctor elegido = public ProductoB(Guid id, String nombre, Decimal precio)
  B2 releido: Mate 3500.0
  ```
- Si **no coinciden**, el modelo no se construye. Falla en el primer uso del `DbContext`, no al compilar:
  ```text
  C! InvalidOperationException: No suitable constructor was found for the type 'ProductoC'.
  The following constructors had parameters that could not be bound to properties of the type:
      Cannot bind 'textoLibre', 'importe' in 'ProductoC(string textoLibre, decimal importe)'
  Note that only mapped properties can be bound to constructor parameters.
  Navigations to related entities, including references to owned types, cannot be bound.
  ```

Este es el punto práctico del caso del PO: el constructor privado sin parámetros **no es sólo decoración del patrón**; es lo que evita esa excepción cuando la fábrica pública tiene parámetros del negocio (`ownerId`, `originalJsonPreservedDeclared`, `createdAt`) que no son propiedades mapeadas. En `Work.Create` (**E3**, `Entities/Work.cs` l. 46-53) hay siete parámetros y sólo cuatro corresponden a columnas: sin el `private Work()` de l. 11 no habría binding posible.

### 1.3 Propiedades sin setter: el mapeo desaparece en silencio

**E1**, entidad `ProductoD` con `public string Nombre { get; }` (sin setter) y el resto con setter privado:

```text
D1 propiedades mapeadas = Id,Precio
```

`Nombre` **no está en el modelo**: no se crea columna, no se guarda y no se relee, y no hay error ni aviso. Es coherente con E2 («Properties without setters are not mapped by convention»), y es la trampa más cara de esta familia, porque se manifiesta como pérdida de datos y no como excepción.

---

## 2. `DomainResult` / `DomainResult<T>` como `readonly record struct`

Forma real (**E3**, `Guards/DomainResult.cs` l. 38-64): `readonly record struct` con constructor privado, `Succeeded`, `TValue? Value`, `string? ConditionCode` y dos fábricas estáticas `Applied`/`Rejected`. `Guards/Admission.cs` repite la forma con otro vocabulario (`IsAdmissible`/`Reason`).

**Costo y beneficio, medidos (E1, proyecto `Bench`, .NET 10.0.11, Release, workstation GC, N = 1 000 000):**

| Magnitud | Valor medido |
| --- | --- |
| `sizeof(DomainResult<Producto>)` | 24 bytes (bool + referencia + referencia, con relleno) |
| Asignación en montículo por rechazo | **0,0 bytes** |
| Tiempo por 1 000 000 de rechazos | **25,5 ms** (0,026 µs por rechazo) |
| Camino de éxito (alta válida) | 740,6 ms / 56,0 bytes por alta — idéntico al camino por excepción (factor 0,99×) |

- **Beneficio real:** cero asignaciones, comparación por valor gratis (`record struct` genera `Equals`/`GetHashCode` por miembros) y un tamaño que viaja en registros/pila.
- **Costo real 1 — `Value` nulo cuando `Rejected`:** el compilador no puede correlacionar `Succeeded == true` con `Value != null`. Medido (**E1**, proyecto `Nullable`, `<Nullable>enable</Nullable>`): al escribir `r.Value.Nombre` después de `if (!r.Succeeded) return 0;` sale `warning CS8602: Dereference of a possibly null reference`. Por eso el proyecto real escribe `constitution.Value!` (**E3**, `Application/Works/LoadAndEditOwnWorkUseCase.cs` l. 71). Conteo en `Lab-Geometria/src` (**E1**, `grep -ro`): **18 `.Value!` + 15 `.ConditionCode!` = 33 operadores de perdón de nulo** que el patrón obliga a escribir.
- **Costo real 2 — el llamador puede ignorarlo.** Medido (**E1**, proyecto `Ignorar`): la sentencia `w.Edit("");` que descarta el `DomainResult` compila con **0 avisos** en la compilación por defecto **y también** con `-p:AnalysisMode=All -p:EnforceCodeStyleInBuild=true`. Una excepción no se puede ignorar; un resultado sí, y nadie avisa.
- **Forma más segura, medida:** un `TryGetValue([NotNullWhen(true)] out TValue? value, [NotNullWhen(false)] out string? conditionCode)` sobre el mismo `readonly record struct` elimina el CS8602 **sin `!`**: la misma prueba compiló con cero avisos en ese camino y devolvió el mismo resultado. No hay que cambiar de tipo ni pagar asignación: es un método más. (La alternativa «unión discriminada» con `abstract record` + `switch` da exhaustividad al costo de una asignación por resultado; no se midió y esta comisión no la recomienda para este caso: **C**.)
- **Precisión de versión:** el repositorio apunta a `net10.0` y el `LangVersion` por defecto medido es **14.0** (C# 14), no C# 13. Todo lo anterior vale igual en C# 13, pero conviene no rotular la técnica con la versión equivocada.

---

## 3. Excepción vs resultado, con número

**E1**, mismo escenario (`Producto.Create` con precio inválido), mismo proyecto, Release, N = 1 000 000:

```text
RECHAZO por excepcion (profundidad 1):      4.340,6 ms     296,0 bytes/rechazo
RECHAZO por resultado  (profundidad 1):        25,5 ms       0,0 bytes/rechazo
RECHAZO por excepcion (profundidad 11): 9.792,2 ms extrapolado a N
RECHAZO por resultado  (profundidad 11):    51,2 ms extrapolado a N
EXITO   por excepcion:  733,9 ms   56,0 bytes/alta
EXITO   por resultado:  740,6 ms   56,0 bytes/alta

factor rechazo (excepcion / resultado) = 170x
factor exito   (excepcion / resultado) = 0,99x
```

Lecturas, sin adorno:

1. **Un rechazo por excepción cuesta 4,3 µs; por resultado, 0,026 µs: 170×.** Con once cuadros de pila de por medio, 191×. La diferencia **no es constante**: crece con la profundidad de la pila, que es lo que un backend real tiene.
2. **El camino de éxito es indistinguible** (factor 0,99×): elegir resultado no acelera nada cuando no hay rechazos. El `try/catch` sin excepción lanzada no se paga.
3. **En magnitudes de aplicación web esto casi nunca decide.** 4,3 µs por rechazo son 4,3 ms cada 1000 rechazos; una consulta a base de datos cuesta más. La medición dice que el argumento de rendimiento **sólo** manda cuando el rechazo es masivo (validación de lotes, interpretación de un JSON con cientos de figuras — exactamente el caso `f` de Geometría), y que fuera de ahí la decisión es de diseño, no de reloj.
4. **Costo de escritura en el llamador, medido en líneas** (mismo handler, mismo trabajo, líneas no vacías):
   - por excepción (el `CrearProductoHandler` de la guía tal como está compilado): **6 líneas**;
   - por resultado (con `if (!x.Succeeded) return …Rejected(x.ConditionCode!)` y `var p = x.Value!`): **11 líneas**.
   **+5 líneas y 2 `!` por punto de llamada.** En `Lab-Geometria/src` eso ya son **30 bloques `if (!….Succeeded)`** y los 33 `!` citados arriba (**E1**).
5. **Conclusión de la comisión (C):** el número no elige por sí solo. Lo que decide es si el rechazo es *esperable* (parte del flujo: el alumno manda un nombre vacío) o *excepcional* (no debería ocurrir: `ownerId` vacío llegando desde un token ya validado). Geometría eligió resultado para todo lo esperable y conservó `ArgumentNullException.ThrowIfNull` para lo que es contrato de programación (**E3**, `Work.AdoptInterpretation` l. 151-152): esa mezcla es la correcta y es la que la guía no nombra.

---

## 4. Hallazgos

| ID | Sección | Nivel | Ancla | Hallazgo, impacto y dirección de la corrección |
| --- | --- | --- | --- | --- |
| **NET2-01** | §3.1 (*Factory Method*), §3.3 | **P1** | **E1** (A1, A6) + **E2** | La guía justifica el constructor privado sólo como «el único camino de creación». Falta la segunda razón, que es la que hace que el patrón funcione en producción: **es la costura por la que EF Core materializa la fila**. Medido: `A1 ctor elegido = private Producto()`, `A6 el ctor privado corrio 1 vez` en la relectura. Impacto: el alumno que entiende el ctor privado sólo como cerrojo lo borra en cuanto le molesta, y rompe la persistencia sin saber por qué. Dirección: una oración en §3.1 (viñeta *Factory Method*) y el enlace a §5.4, que ya lo afirma. |
| **NET2-02** | §3.3, §5.4 | **P1** | **E1** (B1, C!) + **E2** | No está documentado qué pasa **si la Entity no tiene constructor sin parámetros**. Medido: si hay un ctor con nombres coincidentes, EF lo usa (`public ProductoB(Guid id, String nombre, Decimal precio)`); si no, `InvalidOperationException: No suitable constructor was found for the type …`, **en tiempo de ejecución, al construir el modelo**. Impacto: es el error más frecuente al pasar de la fábrica de la guía a una fábrica con parámetros de negocio (el caso literal de `Work.Create`, siete parámetros, cuatro columnas). Dirección: nota en §5.4 con el mensaje literal y la regla de coincidencia de nombres (Pascal ↔ camel). |
| **NET2-03** | §3.4 (setter privado) | **P1** | **E1** (D1) + **E2** | §3.4 da una sola razón para el setter privado (proteger la *Invariant*, demostrada con CS0200). Falta la razón mecánica: **una propiedad sin setter no se mapea por convención y desaparece del modelo sin aviso**. Medido: con `public string Nombre { get; }`, `D1 propiedades mapeadas = Id,Precio`. Impacto: el alumno que «endurece» la entidad a `{ get; }` pierde la columna, y el síntoma es pérdida de datos, no un error. Dirección: segundo renglón en la tabla de §3.4 con esa salida, y la alternativa oficial (mapeo explícito por campo en `OnModelCreating`). |
| **NET2-04** | §3.1, §3.3, §3.6 | **P1** | **E1** (bench) + **E3** | La guía presenta la **excepción de dominio como el único modo de rechazar**; el proyecto real del mismo autor rechaza con `DomainResult` y no lanza nunca por una regla de negocio. No existe en la guía ni la alternativa ni el criterio para elegir. Impacto: el lector que estudia la guía y después lee `GeometriaFactory.Domain` ve dos dominios que se contradicen sin explicación — que es exactamente lo que el PO preguntó. Dirección: subsección nueva en §3 («¿Se rechaza lanzando o devolviendo?») con los números de §3 de este informe (170×, 296 B vs 0 B, 6 vs 11 líneas, éxito 0,99×) y el criterio *esperable vs excepcional*, más la mención de que las dos formas conviven (resultado para la regla, `ThrowIfNull` para el contrato). |
| **NET2-05** | §5.6 (traducción a HTTP) | **P2** | **E4** + **E3** | La tabla de §5.6 cubre sólo el camino por excepción (`DomainExceptionHandler` → 400). Con un dominio por resultado **no hay excepción que traducir**: el borde mapea `ConditionCode` a estado y cuerpo, y el `IExceptionHandler` queda sólo para lo técnico. Impacto: §5.6 se vuelve inaplicable en cuanto se adopta NET2-04, y es la sección que el lector usa como plantilla. Dirección: agregar una fila/párrafo «si el dominio devuelve resultado» con la forma del mapeo `ConditionCode` → 400/404/409, señalando que el catálogo de códigos es parte del contrato. |
| **NET2-06** | §3.3 (propuesto) | **P2** | **E1** (CS8602, TryGetValue) | Si la guía incorpora el resultado (NET2-04), tiene que decir el costo en anotaciones de nulabilidad: `TValue? Value` + `Succeeded` **no** le enseña nada al compilador. Medido: `warning CS8602` al quitar el `!`; 33 `!` en la solución real. Medido también el remedio: `TryGetValue` con `[NotNullWhen(true)]` compila **sin `!` y sin aviso**, sobre el mismo `readonly record struct` y sin costo de asignación. Dirección: mostrar la forma `Succeeded`/`Value` (la del proyecto real) y, en el margen, el `TryGetValue` como refinamiento medible. Corregir además cualquier rótulo «C# 13»: en `net10.0` el `LangVersion` por defecto medido es **14.0**. |
| **NET2-07** | §3.3 (propuesto) | **P2** | **E1** (`Ignorar`, 0 avisos) | El contrapeso honesto del resultado: **nada obliga a mirarlo**. Medido: `w.Edit("");` como sentencia compila con 0 avisos por defecto y también con `AnalysisMode=All`. La excepción no se puede ignorar. Impacto: sin esta frase, la comparación queda sesgada a favor del resultado. Dirección: una oración en la subsección nueva, con la salida como prueba. |
| **NET2-08** | §3.1 (*Factory Method*) | **P3** | **E3** + **C** | «Método `static` que crea instancias y **es el único camino** para hacerlo» es impreciso en dos sentidos medibles en el código real: (a) el constructor privado bloquea a **otros tipos**, no a la propia clase, que sigue usando el inicializador de objeto (`new Producto { … }` dentro de `Create`); (b) «único camino» no es «un solo método»: `Account` tiene **dos** fábricas estáticas, `ConfigureAdministrator` y `Register` (**E3**, `Entities/Account.cs` l. 38 y l. 95), una por caso de uso de alta. Dirección: cambiar «el único camino» por «el único camino desde afuera de la clase», y una oración diciendo que puede haber una fábrica por acto de constitución. |
| **NET2-09** | §5.4 | **P2** | **E1** (A3) + **E4** | §4.10 ya presenta el agregado con `private readonly List<ItemPedido> _items` + `IReadOnlyList<ItemPedido> Items => _items`, pero §5.4 nunca dice **cómo lo llena EF Core**. Medido: la convención encuentra el campo (`A3 nav Items: campo=_items accessMode=PreferField`), sin configuración. Impacto: el lector no sabe si le hace falta `UsePropertyAccessMode` (no le hace falta) y copia configuración de más o de menos. Dirección: una oración en §5.4 con la línea de metadatos medida, y la nota de que declararlo explícito —como hace `WorkConfiguration.cs`— es documentación, no requisito. |
| **NET2-10** | §3.3 (`Dinero`) | **P2** | **E1** (`Dinero`) | El único *Value Object* de la guía **no protege ninguna invariante en su construcción**, lo que contradice la viñeta de *Factory Method* de §3.1 («haciendo cumplir sus *Invariants*»). Medido: `new Dinero(-10m, "")` se construye sin quejas; `new Dinero(10m,"ARS") with { Moneda = "XYZ" }` cambia la moneda sin pasar por regla alguna; el `record` posicional expone **1 constructor público**. Impacto: el alumno aprende que «*Value Object* = `record`», y se lleva un tipo que admite valores imposibles. Dirección: o bien `Dinero` gana una fábrica `Create`/`TryCreate` con ctor privado (coherente con §3.3), o bien §3.3 declara explícitamente que en ese ejemplo la validación es deliberadamente omitida y dice dónde iría. |

### Addendum del PO: los `Values` y los `Guards` en la línea de pensamiento

Antes de los tres puntos medidos, la respuesta a «dónde encajan» (**C**, apoyada en **E3**). La línea del PO —*entidad → intención (caso de uso) → hecho consumado (otra entidad)*— tiene dos piezas de soporte que no son ni una cosa ni la otra:

- **`Values/` es el vocabulario**: las palabras con las que la intención se expresa y con las que el hecho queda anotado. `WorkOperation` (`View`/`Edit`/`Delete`) nombra **intenciones**; `WorkStatus` (`Draft`/`Submitted`/`Approved`/`Rejected`) nombra **hechos**; `ConditionCode` nombra **los modos en que una intención puede ser rechazada**. No tienen identidad ni ciclo de vida: son el diccionario cerrado del dominio.
- **`Guards/` es la forma del veredicto**: `DomainResult` no es una regla ni un valor del negocio, es **el canal por el que la entidad contesta a la intención**. Por eso no tiene nombre de negocio: es infraestructura del lenguaje del dominio, el equivalente de `throw` en la otra estrategia. `Admission` es el mismo canal con otro vocabulario, para las preguntas de admisión.

Dicho corto: la entidad dice **qué es verdad**; el caso de uso dice **qué se quiere**; `Values` da **las palabras**; `Guards` da **el sí o el no, con su motivo**.

| ID | Sección | Nivel | Ancla | Hallazgo, impacto y dirección de la corrección |
| --- | --- | --- | --- | --- |
| **NET2-11** | §5.4, §7.2 b | **P1** | **E1** (V1–V5) + **E3** | **Mecánica de los nueve enums.** Medido: por convención EF Core los persiste como entero (`V1 … INTEGER`, fila guardada `'3'`); con `HasConversion<string>` la columna es `TEXT` y guarda `'Approved'` (V2, V3). Con valor nuevo en el catálogo y filas viejas en la base: por entero, una fila con `5` se relee como `Status=5`, `Enum.IsDefined=False` y **no lanza** (V4) — estado inválido silencioso dentro de la entidad; con `HasConversion<string>`, un texto desconocido falla fuerte: `InvalidOperationException: Cannot convert string value 'Archived' from the database to any value in the mapped 'WorkStatus' enum` (V5). Geometría eligió texto para `Work.Status` (**E3**, `WorkConfiguration.cs` l. 32-34): **es la elección segura y la guía no la menciona en ningún lado**. Los valores explícitos (`= 1`, `= 2`…) son lo que impide que reordenar el enum reinterprete las filas ya escritas; con columna de texto dejan de ser críticos, pero siguen siendo gratis. Dirección: párrafo en §5.4 con las cuatro salidas y la regla: *entero + valores explícitos* o, mejor, *`HasConversion<string>`*, nunca *entero sin valores explícitos*. |
| **NET2-12** | §3.1, §8.4 | **P2** | **E1** (`Const`) | **El riesgo del `const string` es real y está medido.** `ConditionCode` es una `static class` con 40 `const string` (**E3**). El compilador **hornea el literal en el ensamblado del consumidor**: tras cambiar el valor en el catálogo y recompilar **sólo** el catálogo, el consumidor siguió imprimiendo `EDIT_OUTSIDE_DRAFT` mientras el mismo miembro declarado `static readonly` ya devolvía `EDIT_OUT_OF_DRAFT`; recompilando el consumidor, los dos coinciden. Impacto: **nulo** mientras `Domain`, `Application`, `Api` y `Web` se compilen juntos (el caso de Geometría hoy); **real** en cuanto `Domain` viaje como paquete NuGet o un cliente se compile aparte — dos binarios hablarían vocabularios distintos sin ningún error. Dirección: mantener `const` (es lo correcto para un catálogo versionado con la solución) y agregar el criterio explícito: *el catálogo de códigos es contrato; si cruza la frontera de un paquete, los códigos se renombran con una versión mayor, o se declaran `static readonly`*. |
| **NET2-13** | §3.1, §3.3, §7.2 b | **P2** | **E1** (V6–V12, `Dinero`) | **Conjunto cerrado: `enum` vs *Value Object* vs constantes de cadena.** Medido: **igualdad** — `enum` compara por valor gratis (`V7 True`) igual que un `record`; **exhaustividad** — el `switch` sin brazo por defecto sí avisa (`warning CS8524: The switch expression does not handle some values of its input type … For example, the pattern '(WorkStatus)0' is not covered`), pero es *aviso*, no error, y en ejecución tira `SwitchExpressionException` (V12); **validez** — `(WorkStatus)99` compila, no lanza, `ToString()` devuelve `"99"` e `IsDefined` es `False` (V6); **JSON** — `System.Text.Json` serializa el **número** por defecto (`{"Status":3}`) y el nombre sólo con `JsonStringEnumConverter` (`{"Status":"Approved"}`), y **deserializa un 99 sin quejarse** (V10). Conclusión medible: **el `enum` es un conjunto cerrado que en realidad no está cerrado**; la cadena constante no cierra nada; el único que no puede contener un valor imposible es un *Value Object* con constructor privado y fábrica —la misma mecánica de la Entity, aplicada a un valor—. La guía hoy sólo muestra `Dinero`, y ni siquiera con fábrica (ver NET2-10). Dirección: en §7.2 b, tres renglones con esta tabla medida y la regla: *`enum` para el conjunto cerrado que la base escribe y lee; `Value Object` cuando el valor tiene regla propia; `const string` sólo para catálogos que viajan en el contrato*. |

---

## 5. Lo que revisé y está bien

- **B1 — §5.4, la afirmación central sobre EF Core.** «`Producto` no tiene atributos de base de datos ni setters públicos, y EF Core la guarda y la recupera igual (L17): usa el constructor privado y asigna las propiedades por su cuenta» es **literalmente cierta** y quedó reproducida (A1, A2, A5, A6). Es la frase que sostiene todo el patrón y no hay que tocarla.
- **B2 — §5.4, `HasPrecision` y SQLite.** «en SQLite la columna se crea como `TEXT` y la base no aplica precisión ni escala […] por eso en L17 el precio vuelve con un solo decimal»: reproducido sin proponérmelo, `A5 … Precio=3500.0`.
- **B3 — §3.4, el CS0200 del setter privado.** El experimento y su conclusión son correctos y consistentes con la documentación oficial, que aclara que EF ve el setter privado como lectura/escritura («EF Core sees a property with a private setter as read-write»), de modo que proteger la invariante **no** cuesta el mapeo. El hallazgo NET2-03 no contradice §3.4: la completa.

---

## 6. Propuesta de variante para el laboratorio (punto 4 del encargo) — **no construida**

**Sí alcanza con extender `Examples/Dot-NET-Arquitectura-Lab/Variantes/`**, y es la opción barata: `Variantes/` ya tiene la infraestructura exacta que hace falta (`variantes.sh` con `cap()`, `global.json` con SDK 10.0.400, `Pedidos/` con EF Core Sqlite 10.0.12 y demo de consola), y el laboratorio principal (`lab.sh`, L00–L24) no se toca. Construir una solución aparte duplicaría el andamio sin ganar nada.

### Árbol exacto propuesto

```text
Examples/Dot-NET-Arquitectura-Lab/Variantes/
├── variantes.sh                                   (MODIFICADO: +5 líneas cap V04..V08)
└── FabricaYResultado/
    ├── Domain/
    │   ├── FabricaYResultado.Domain.csproj        (sin referencias: puerta de la regla de dependencia)
    │   ├── Common/DomainException.cs              (igual al de MyProject: la estrategia A)
    │   ├── Common/DomainResult.cs                 (readonly record struct, con TryGetValue)
    │   ├── Productos/EstadoProducto.cs            (enum con valores explícitos: Borrador=1, Publicado=2, Retirado=3)
    │   ├── Productos/Moneda.cs                    (Value Object CON regla: ctor privado + Create/TryCreate)
    │   ├── Productos/ProductoQueLanza.cs          (ctor privado + Create que lanza DomainException)
    │   ├── Productos/ProductoQueDevuelve.cs       (ctor privado + Create que devuelve DomainResult<T>)
    │   └── Productos/ProductoSinCtorPrivado.cs    (SIN ctor sin parámetros y con nombres que no coinciden)
    ├── Infrastructure/
    │   ├── FabricaYResultado.Infrastructure.csproj (ProjectReference a Domain; PackageReference EF Core Sqlite 10.0.12)
    │   └── Persistence/
    │       ├── AppDbContext.cs
    │       └── Configurations/ProductoConfiguration.cs  (ToTable/HasKey; Estado con HasConversion<string>)
    └── Demo/
        ├── FabricaYResultado.Demo.csproj
        └── Program.cs                              (un argumento por escenario: ciclo | rechazos | sin-ctor | enum | valor)
```

### Qué demostraría cada salida

| Captura | Comando | Qué demuestra, en una línea, y con qué evidencia |
| --- | --- | --- |
| `V04-build-fabrica-y-resultado.txt` | `dotnet build FabricaYResultado/Demo` | Que todo lo que sigue **compila**, y con qué SDK y qué versión de EF Core (encabezado `cap()`). |
| `V05-ciclo-efcore.txt` | `dotnet run … -- ciclo` | **El ciclo completo que pide el encargo**: alta por `Create` → `SaveChanges` → **nuevo `DbContext`** → relectura. Imprime el constructor que EF eligió (`private ProductoQueDevuelve()`), el contador de invocaciones del ctor privado (1), la lista de propiedades mapeadas y los valores releídos. Cierra NET2-01 y B1 con salida propia del laboratorio. |
| `V06-rechazos.txt` | `dotnet run … -- rechazos` | **Las dos estrategias sobre el mismo `Producto`**: 100 000 rechazos por excepción y 100 000 por resultado, con milisegundos y bytes asignados por `GC.GetAllocatedBytesForCurrentThread`, más el camino de éxito de las dos. Cierra NET2-04 con números del laboratorio en vez de los de este informe. (N reducido a 100 000 para que la captura no tarde: el factor se conserva.) |
| `V07-sin-ctor-privado.txt` | `dotnet run … -- sin-ctor` | La `InvalidOperationException: No suitable constructor was found…` **literal**, capturada y mostrada como texto (no como caída). Cierra NET2-02. Con la misma corrida, el caso `{ get; }` y su lista de propiedades mapeadas sin la columna: cierra NET2-03. |
| `V08-enum-y-valor.txt` | `dotnet run … -- enum` y `-- valor` | El `enum` guardado como `INTEGER` y como `TEXT`, y la relectura de una fila escrita a mano con un valor que este binario no declara: `Status=5 IsDefined=False` sin excepción contra `Cannot convert string value 'Archived'…`. Y el *Value Object* con regla: `Moneda.Create("XYZ")` rechazado frente a `new Dinero(-10,"")` aceptado. Cierra NET2-11, NET2-13 y da a §3.3 el contraejemplo de NET2-10. |

### Costo estimado (C)

| Concepto | Costo |
| --- | --- |
| Archivos nuevos | 13 (3 `.csproj`, 9 `.cs`, 0 scripts nuevos) |
| Archivos modificados | 1 (`variantes.sh`, +5 líneas `cap`) + la guía, donde se citen las capturas |
| Líneas de código nuevas | ≈ 420, de las cuales ≈ 160 son el `Program.cs` de la demo |
| Tiempo de corrida añadido a `variantes.sh` | ≈ 20 s (las dos compilaciones dominan; el benchmark con N = 100 000 son ≈ 0,5 s) |
| Dependencia nueva | ninguna: EF Core Sqlite 10.0.12 ya está en `Variantes/Pedidos/Infrastructure` |
| Riesgo | bajo y acotado: no toca `lab.sh`, `MyProject/` ni las capturas L00–L24 |

La comisión recomienda construirla **después** de decidir NET2-04, porque el árbol de arriba supone que la guía va a admitir las dos estrategias; si la mesa decide conservar sólo la excepción, la variante se reduce a `V05` y `V07` y el costo baja a la mitad.

---

## 7. Fuentes y comandos

**Documentación oficial (E2)**

- Microsoft, *Entity types with constructors — EF Core*, `https://learn.microsoft.com/en-us/ef/core/modeling/constructors` (consultado 2026-09-20; página con `ms.date: 2018-02-23`, actualizada 2025-02-03). Citas usadas: el orden de binding («it will first call the default parameterless constructor…»), la accesibilidad («The constructor can be public, private, or have any other accessibility»), las propiedades sin setter («Properties without setters are not mapped by convention») y el setter privado («EF Core sees a property with a private setter as read-write»).

**Entorno de medición (E1)**

- Imagen `mcr.microsoft.com/dotnet/sdk:10.0`, digest `sha256:e1ffd2a92ae84c1291bc1b6887501f8af98e6331e7af6d4c8d37168c5e87a64c` (el mismo digest que registran las capturas del laboratorio).
- SDK 10.0.400 / runtime `10.0.11` / `LangVersion` por defecto **14.0** / EF Core `Microsoft.EntityFrameworkCore.Sqlite` **10.0.12** / `IsServerGC=False`.
- Todos los proyectos se crearon en el scratchpad de la sesión (`…/scratchpad/net2/`), **nunca dentro de `Lab-Geometria` ni de `Dot-NET-Arquitectura-Lab`**, y se ejecutaron con `--user "$(id -u):$(id -g)"`.

Forma general de cada corrida:

```bash
docker run --rm --user "$(id -u):$(id -g)" \
  -e HOME=/tmp/h -e DOTNET_CLI_HOME=/tmp/h -e DOTNET_NOLOGO=1 \
  -v "$SCRATCH/net2":/w -w /w/<proyecto> mcr.microsoft.com/dotnet/sdk:10.0 \
  bash -c 'mkdir -p /tmp/h && dotnet run -c Release'
```

| # | Proyecto | Qué mide | Salidas citadas |
| --- | --- | --- | --- |
| 1 | `net2/EfCtor` (EF Core + SQLite) | constructor elegido, propiedades mapeadas, modo de acceso, ciclo alta→guardar→releer, entidad sin ctor sin parámetros, propiedad `{ get; }` | A1–A6, B1, B2, C!, D1 |
| 2 | `net2/Bench` (Release) | excepción vs resultado: N = 1 000 000, profundidad 1 y 11, éxito y rechazo, bytes asignados, `Unsafe.SizeOf` | 4 340,6 / 25,5 / 9 792,2 / 51,2 ms; 296,0 / 0,0 B; 24 bytes; 170× y 0,99× |
| 3 | `net2/Nullable` | `CS8602` sobre `Succeeded`+`Value?` y su desaparición con `TryGetValue([NotNullWhen(true)])`; `LangVersion` | `warning CS8602`; `LangVersion 14.0` |
| 4 | `net2/Ignorar` | si alguien avisa cuando el llamador descarta el `DomainResult` | 0 avisos por defecto y con `-p:AnalysisMode=All -p:EnforceCodeStyleInBuild=true` |
| 5 | `net2/Const` (dos ensamblados) | horneado del `const string`: compilar consumidor, cambiar sólo el catálogo, recompilarlo, sustituir el `.dll` | `const -> EDIT_OUTSIDE_DRAFT` / `static readonly -> EDIT_OUT_OF_DRAFT` con el mismo binario del consumidor |
| 6 | `net2/Enums` (EF Core + SQLite) | enum por convención vs `HasConversion<string>`, fila con valor no declarado, `(WorkStatus)99`, JSON, exhaustividad del `switch` | V1–V12, `warning CS8524`, `SwitchExpressionException` |
| 7 | `net2/Dinero` | el *Value Object* de §3.3 admite valores imposibles | D1–D4 |
| 8 | `grep` sobre `Lab-Geometria/src` (sólo lectura) | costo de escritura del patrón en el proyecto real | 18 `.Value!`, 15 `.ConditionCode!`, 30 bloques `if (!….Succeeded)` |

Conteo de líneas del llamador (punto 3.4 de este informe): dos archivos de texto con el mismo handler escrito en las dos estrategias, `grep -c .` → **6** y **11** líneas no vacías.

**Limpieza**: al terminar se borraron los artefactos de compilación desde dentro del contenedor, con el mismo usuario no privilegiado:

```bash
docker run --rm --user "$(id -u):$(id -g)" -v "$SCRATCH/net2":/w -w /w \
  mcr.microsoft.com/dotnet/sdk:10.0 bash -c 'find /w \( -name bin -o -name obj \) -prune -exec rm -rf {} +'
```

**Código leído (E3), sin modificar**

`Lab-Geometria/src/GeometriaFactory.Domain/`: `Entities/Work.cs`, `Entities/Account.cs`, `Guards/DomainResult.cs`, `Guards/Admission.cs`, `Values/` (los nueve enums, `ConditionCode.cs`, `EmailIdentity.cs`). `Lab-Geometria/src/GeometriaFactory.Infrastructure/Persistence/`: `GeometriaFactoryDbContext.cs`, `Configurations/WorkConfiguration.cs`. `Lab-Geometria/src/GeometriaFactory.Application/`: `ApplicationResult.cs`, `Works/LoadAndEditOwnWorkUseCase.cs`.

**Texto leído (E4)**

`Dot-NET-Arquitectura-Guide.md` v2.1.0, §3.1 (l. 537-552), §3.3 (l. 584-677), §3.4 (l. 678-705), §3.5, §3.6, §4.1 (l. 831), §5.4 (l. 1492-1518), §5.6 (l. 1604-1650), §7.2 b; y el laboratorio `Examples/Dot-NET-Arquitectura-Lab/` (`lab.sh`, `Variantes/variantes.sh`, `Variantes/global.json`, `MyProject/src/Backend/…/CrearProductoHandler.cs`, `capturas/`).
