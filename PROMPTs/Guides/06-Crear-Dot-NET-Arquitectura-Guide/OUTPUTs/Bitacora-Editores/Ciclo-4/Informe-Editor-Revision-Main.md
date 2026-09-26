# Informe de la comisión Editor — revisión de lectura sobre `main`

| | |
| --- | --- |
| **Fecha** | 2026-09-21 |
| **Comisión** | Editor de libros técnicos |
| **Objeto** | `Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md` publicado en `main` @ `dade777`, v2.3.0, 2755 líneas, sha256 `1bac06a8…` (idéntico a lo aplicado en el ciclo 3) |
| **Alcance** | Lectura completa con la lista de deuda abierta y con el criterio nuevo del PO sobre citas (2026-09-21). **No se editó la guía.** No se entró en `Exercices/` |
| **Medios** | Lectura íntegra; scripts sobre el documento (anclas, remisiones `§n.m` contra los encabezados reales, tamaño por capítulo y por sección, inventario de citas textuales y su distancia al bloque de código más cercano); lectura de `Examples/` sólo para ubicar los archivos que podrían dar los snippets que faltan |

## 0. Estado mecánico (lo que ya está sano)

| Chequeo | Resultado |
| --- | --- |
| Anclas internas | 145 enlaces, **0 rotos**; 0 referencias del Anexo E sin uso |
| Remisiones `§n.m` contra encabezados reales | **0 desfasadas** (el único «§15.5» es la cita de RFC 9110, no una sección) |
| Bloques `[Compilado]` contra archivo y rango | **28/28** |
| Marcas de procedencia | todos los bloques marcados; 0 marcadores `PENDIENTE` |
| Rule-Narrative-Voice | 0 muletillas de la lista |

La deuda que sigue no es mecánica: es de dosis y de coherencia entre lo que la guía promete y lo que hace después de tres ciclos.

---

## 1. Diez observaciones, por impacto

### O-1 · Alto · §3.2, §3.6, §3.7 — la misma regla se clasifica en cuatro tablas

`grep` sobre las filas de tabla: «no se vende un producto sin precio» aparece clasificada en l. 574 (§3.2, ¿es Business Rule?), l. 745 (§3.6, tipo de regla), l. 768 (§3.7, cuándo vale) y l. 778 (§3.7, ¿es Invariant?). «El precio es mayor a cero» corre la misma suerte: l. 573, 744, 767, 774. El capítulo 3 tiene hoy **14 tablas en 390 líneas** y cinco de ellas clasifican reglas con ejes que se solapan. El ciclo 1 ya lo había anotado (PE-10: «tres taxonomías consecutivas»); los ciclos 2 y 3 agregaron dos tablas más sobre el mismo objeto.

Para el lector de una sola pasada el efecto es que la cuarta tabla no enseña nada nuevo: reordena lo mismo. **Costo de corrección: −15/−20 líneas**, fusionando la tabla de tres filas de §3.7 (que es un subconjunto de la de siete) y quitando de la de §3.6 las dos filas que la de §3.7 vuelve a clasificar; ninguna cita se toca.

### O-2 · Alto · §4.10 — 209 líneas en una sola sección

Es la sección más larga de la guía y creció en los tres ciclos (enunciado Cockburn, `Pedido`, `ItemPedido`, la pregunta de *Unit of Work*, `IUnitOfWork`, `AppDbContext`, el composition root de la variante, la *Invariant* de *Aggregate*). Tiene 5 bloques de código y 4 tablas. Sigue siendo legible, pero ya no se lee «de una sentada»: es un capítulo dentro de un capítulo.

**Costo: 0 líneas**, partirla en §4.10 (el Use Case y el Aggregate) y §4.11 (¿cuándo `SaveChanges` sube al Handler?), renumerando la pregunta de cierre a §4.12 y actualizando 11 remisiones. Es cirugía de índice, no de contenido.

### O-3 · Alto (deuda b) · §3.8 depende de una captura que no se puede regenerar

§3.8 cita cinco números de V06 (`4,357.0 ms`, `296.0 bytes`, `30.6 ms`, `0.0 bytes`, `142x`) y dos más (`765,3` / `824,9`). La variante se amplió dos veces desde entonces y V06 quedó deliberadamente sin regenerar; está declarado en el Anexo A y en el CHANGELOG, pero la deuda sigue viva: cualquier corrida futura de `variantes.sh` la pisa y deja siete números huérfanos en el cuerpo.

**Costo: ~4 líneas**, o bien fijando los números en una tabla de una fila con la fecha de la corrida (para que el desfase se vea), o bien regenerando V06 y actualizando los siete valores de un saque. Recomiendo lo segundo: el factor se mantiene en el mismo orden y deja de haber una captura «congelada» en un laboratorio que se corre entero.

### O-4 · Medio (deuda a) · §9.6 — la única cita de segunda mano que queda

L. 2439 cita a Evans 2003 («This layer is kept thin…») a través de Fowler 2003, con la entrada `ref-evans-2003` rotulada «Citado en Fowler (2003)». Está declarada, y por eso no es un error; pero es la única del documento que no se verificó contra su fuente, en una guía que en el ciclo 3 decidió **no** citar otra frase de ese mismo libro por no tenerlo a la vista (E-3). El criterio quedó aplicado a una cita y no a la otra.

**Costo: 0 líneas** si se verifica el pasaje contra el *DDD Reference* 2015 —que dice lo mismo sobre la capa de aplicación— y se cambia la referencia; **−2 líneas** si se quita la cita y se deja la de Martin (2012) que ya está en §4.10.

### O-5 · Medio (deuda c) · §9.6 — los pasos 5 y 6 siguen sin código

El bloque de la escalera muestra los pasos 1, 2, 3, 4 y 7; los pasos 5 (Repository propio + doble) y 6 (`Contracts` + cliente HTTP) están sólo en prosa, y el paso 7 usa `_repository.ExisteDni` sin que la interfaz se haya visto nunca. Es PE-08 del ciclo 1, degradado entonces por presupuesto. Hoy el argumento de costo es más débil: los dos deltas son ~12 líneas dentro de un bloque que ya existe, y son justamente los escalones donde aparecen las dos piezas que la guía más discute.

**Costo: +12 líneas, 0 bloques nuevos** (se agregan al bloque ilustrativo existente).

### O-6 · Medio · Anexo B no acompañó tres ciclos de cambios

La lista de verificación tiene las mismas 9 preguntas de la v2.0.x. No pregunta nada de lo que los ciclos 2 y 3 agregaron: cómo se rechaza (§3.8), si el catálogo de códigos es parte del contrato (§7.2 d), si la *Entity* tiene un camino de materialización que el ORM alcance (§5.4), si los valores cerrados son enum o *Value Object* (§3.9). El lector de consulta que usa el Anexo B como plantilla se lleva la guía de hace tres versiones.

**Costo: +4 líneas** (cuatro filas, con su remisión).

### O-7 · Medio · §9.3 — la tabla de señales no incorporó la señal del ciclo 2

§9.3 es «cuándo subir un escalón»; el ciclo 2 agregó una decisión con señal observable («el borde necesita distinguir motivos de rechazo, o hay que mostrar varios a la vez» → del `throw` al resultado tipado) y quedó fuera de esa tabla, que es donde el lector de consulta la buscaría. Era P-10 del informe Fowler del ciclo 2, no aplicado por presupuesto.

**Costo: +1 línea.**

### O-8 · Medio (deuda d) · §5.4 describe *Data Mapper* y no lo nombra

`grep "Data Mapper"` → **0**. §5.4 explica con precisión lo que hace `ProductoConfiguration` («el mapeo se declara afuera y la Entity no se entera») y esa es, palabra por palabra, la intención del patrón: «A layer of Mappers that moves data between objects and a database while keeping them independent of each other and the mapper itself». Con el criterio nuevo del PO, esto ya no es «una frase o nada»: es una cita verificable que le da nombre a algo que el lector va a encontrar en Dapper, NHibernate o en un archivo.

**Costo: +2 líneas** (cita + qué implica), **0 bloques**: el snippet ya está arriba, es `ProductoConfiguration.cs`.

### O-9 · Bajo · El capítulo 3 es el único de la Parte II sin un solo diagrama

Capítulos con mermaid: 2 (tres), 4, 5, 6, 7 y 9 (uno cada uno). El 3 tiene 390 líneas, 14 tablas y ningún diagrama, y es donde vive la relación que más cuesta en prosa: regla → dónde vive → quién la hace cumplir. No propongo agregarlo por simetría; lo anoto porque, si O-1 fusiona tablas, un diagrama de tres cajas haría el trabajo de dos de ellas.

**Costo: +10 líneas** si se adopta junto con O-1; si no, no hacerlo.

### O-10 · Bajo · La promesa de §0.3 y las respuestas que ya no son «una línea»

§0.3 promete «decisiones formuladas como pregunta, con la respuesta en una línea en negrita». §3.8 responde con dos oraciones más un rótulo de criterio, §4.10 tiene dos «Respuesta» bajo un título que no es pregunta y §9.6 perdió el rótulo en el ciclo 1. Ninguna de las tres está mal; la promesa es la que quedó estrecha.

**Costo: 0 líneas**, ajustando la frase de §0.3 («la respuesta primero, en negrita»).

---

## 2. Lectura de punta a punta: ¿sigue siendo una guía o ya es un catálogo?

Números de la lectura: 2755 líneas, 16 capítulos, 73 secciones, **74 tablas**, 44 bloques de C#, 8 diagramas, 52 contrastes ✅/❌. Reparto por capítulo:

| Capítulo | Líneas | Tablas | Bloques |
| --- | --- | --- | --- |
| 0–2 (fundamentos) | 511 | 11 | 5 |
| 3 Domain | 390 | 14 | 8 |
| 4 Application | 559 | 13 | 14 |
| 5 Infrastructure/WebAPI | 336 | 8 | 8 |
| 6 Clientes | 145 | 3 | 3 |
| 7 Criterio por objeto | 247 | 12 | 5 |
| 8–9 + anexos | 567 | 13 | 1 |

**Diagnóstico.** La Parte I y la Parte III se leen de corrido; el que se volvió denso es el eje §3–§4, y no por el código —que es lo que el pedido original quería— sino por la **densidad de tablas**: 27 tablas en 949 líneas, con los solapamientos de O-1. La guía no se convirtió en catálogo, pero el capítulo 3 se acerca: cinco tablas sucesivas sobre el mismo objeto es la forma editorial de un catálogo, aunque el contenido sea formativo.

Lo que **no** sobra, y conviene decirlo porque es lo que un recorte apresurado tocaría primero: los 28 bloques `[Compilado]`, las tablas «línea → concepto» (son lo que ata código y concepto, que es el pedido) y los ejercicios de §9.7. Si algo tiene que ceder, es prosa y tablas repetidas: O-1, O-2 y la fusión que propone O-9.

---

## 3. Citas que hoy están sin explicación o sin materializar

Inventario: **59 citas textuales** en el cuerpo. La mayoría tiene su explicación al lado; lo que falta, casi siempre, es el tercer elemento que el PO pide: el código que la vuelve concreta. Ordenadas por lo que rinde arreglarlas.

| # | Cita y ubicación | Qué le falta | De dónde saldría el snippet | Costo |
| --- | --- | --- | --- | --- |
| C-1 | §3.6, l. 719–725: las tres clases del Business Rules Group (*Structural Assertion*, *Action Assertion* con sus tres subtipos, *Derivation*) — **9 citas, el bloque de código más cercano está a 29–49 líneas** | Snippet; la explicación está | Un bloque de 6–8 líneas con las tres a la vista: `Variantes/ProductoSinPrecio/…/Producto.cs` l. 11 (`decimal? Precio` = Structural), l. 28–32 (`AsignarPrecio` = integrity constraint) y `Variantes/Pedidos/…/Pedido.cs` l. 15 (`Total => _items.Sum(...)` = Derivation, ya comentado así en el fuente) | +12 líneas, 1 bloque |
| C-2 | §4.7, l. 1234–1236: CQS de Meyer («Return a result and do not change…», «Change the state… but do not return a value»), la preferencia de Fowler por «modifiers» y el *Command Message* de Hohpe — **5 citas, ningún código en toda la sección** | Snippet | `MyProject/…/Producto.cs` l. 25 (`public void Desactivar() => Activo = false;` = command puro) contra `Variantes/ProductoSinPrecio/…/Producto.cs` l. 36 (`PrecioDeVenta()` = query), y la excepción consciente que la guía ya declara: `CrearProductoHandler.Handle` devuelve el `Guid` | +8 líneas, 1 bloque |
| C-3 | §3.1, l. 545: Evans, *Factories* («shift the responsibility… to a separate object») y Bloch, ítem 1 | Explicación del **límite**: cuándo la fábrica se muda a un objeto aparte está dicho, pero no hay ningún ejemplo de ese caso en la guía | No existe archivo: `[Fragmento ilustrativo: la fábrica que necesita colaboradores]`, 4 líneas | +6 líneas, 1 bloque ilustrativo |
| C-4 | §3.8, l. 887: *Notification* («use error codes rather than strings») | Snippet: se dice qué **no** es `DomainResult` y no se muestra qué sería | No existe: `[Fragmento ilustrativo: la Notification que la guía no construye]`, 5 líneas (lista de códigos + `HasErrors`) | +7 líneas, 1 bloque ilustrativo |
| C-5 | §3.8, l. 889: *Specification* (Evans y Fowler, 1997, `isSatisfiedBy`) y *Guard Clause* | Snippet de la **consulta sin efecto** que sí es la forma recomendada | `Variantes/ProductoSinPrecio/…/Producto.cs` l. 36 (`PrecioDeVenta()`), o un `PuedeVenderse()` de 2 líneas como ilustrativo | +5 líneas |
| C-6 | §4.1, l. 829: *LocalDTO* («they are actually harmful…») | Snippet: la guía declara que se aparta del consejo y no muestra el objeto del que se habla junto a la cita | `MyProject/…/ProductoDto.cs` l. 6–10, que ya está compilado y citado en §4.5: alcanza con la remisión explícita | +1 línea, 0 bloques |
| C-7 | §4.10, l. 1278: Cockburn («A use case captures a contract between the stakeholders…») | Nada: es el mejor caso de la guía (enunciado + extensiones + código + salida) | — | 0 |
| C-8 | §9.6, l. 2431–2439: las cinco citas de PoEAA y el *Anemic Domain Model* | Nada crítico: el bloque de deltas está en la misma sección | Si se aplica O-5, quedan además materializados los pasos 5 y 6 | 0 |
| C-9 | §5.4, l. 1640: EF Core («it will first call the default parameterless constructor…») | Nada: cita + explicación + bloque compilado + captura. **Es el modelo de los tres elementos** | — | 0 |
| C-10 | Anexo E, `ref-microsoft-2026o`: las dos frases de `System.Text.Json` viven en la referencia, no en el cuerpo | Traer al cuerpo la frase que gobierna la regla del «único constructor» (§5.4/§7.4 la usan) | Ya hay medición (V09 l. 39–42) y bloque en §7.4 | +2 líneas |

**Regla que propongo fijar a partir de esto** (y que el ciclo 4 podría aplicar como norma editorial): *cita sin snippet sólo cuando la cita es sobre el método de la guía y no sobre un mecanismo* (p. ej. Wirfs-Brock sobre *Responsibility*). Para todo mecanismo, los tres elementos.

---

## 4. Citas que recortamos y habría que reponer

| # | Qué se recortó | Cuándo y por qué | Qué repondría | Costo |
| --- | --- | --- | --- | --- |
| R-1 | **Data Mapper** (PoEAA, `dataMapper.html`): «A layer of Mappers that moves data between objects and a database while keeping them independent of each other and the mapper itself» | Ciclo 1, MF-09: el refutador lo degradó a «una frase o nada» y el editor eligió nada | La cita en §5.4 + una línea de qué implica (el patrón que el lector va a reconocer en Dapper o en NHibernate) + la remisión al bloque de `ProductoConfiguration.cs` que ya está ahí | +2 líneas |
| R-2 | **El fragmento de JSON del borde** (P-07 del ciclo 2): cómo viaja el código de condición dentro del `ProblemDetails` (RFC 9457, ya citada) | Ciclo 2: se resolvió en prosa por presupuesto | Un `[Fragmento ilustrativo]` de 4 líneas con el cuerpo de la respuesta y el miembro de extensión, junto al bloque compilado de `DomainExceptionHandler.cs` en §5.6 | +7 líneas, 1 bloque |
| R-3 | **Bloch** (*Effective Java*, ítem 1) | Ciclo 3: entró, pero sólo como nombre y ventajas, sin el código que las muestra | Las tres ventajas que la guía enumera —el método tiene nombre, no obliga a crear un objeto nuevo, puede devolver un subtipo— se materializan con `Moneda.Create` / `Moneda.Materializar` (`Variantes/FabricaYResultado/…/Moneda.cs` l. 17–30), que es exactamente «dos fábricas con nombre distinto sobre el mismo constructor privado» | +4 líneas, 0 bloques (remisión al bloque de §3.9) |
| R-4 | **Evans, *Assertions*** («If assertions cannot be coded directly in your programming language, write automated unit tests for them») | Ciclo 1, MF-04: entró parafraseada en §3.3 («que es lo que Evans indica cuando el lenguaje no tiene cláusulas»), sin la cita textual | La frase textual junto al bloque de `ProductoTests.cs` que ya está compilado ahí | +1 línea |
| R-5 | **Evans, *Intention-Revealing Interfaces*** (P-05 del ciclo 2, no aplicado): «Name classes and operations to describe their effect and purpose…» | Ciclo 2: no entró en la tabla de decisiones | §8.4, como excepción declarada a «las operaciones estándar van en inglés»: cuando la fábrica nombra un acto del negocio, el nombre sale del lenguaje ubicuo. Snippet: las dos fábricas de `Moneda` o el par `Create`/`Materializar` | +3 líneas |

**Total de las dos secciones, si se repone todo:** +58 líneas y 5 bloques (2 compilados, 3 ilustrativos). Con O-1, O-2 y O-4 aplicadas en paralelo (−20 líneas), el saldo neto ronda **+38 líneas** sobre 2755, y ninguna fuente queda recortada.

---

## 5. Lo que recomiendo no hacer

1. **No tocar `Exercices/`**, ni para corregir lo que ya está publicado: es el taller del PO (regla del 2026-09-21).
2. **No agregar más tablas al capítulo 3** hasta resolver O-1; hoy el problema no es que falte información, es que la misma información se presenta cuatro veces.
3. **No convertir los tres fragmentos ilustrativos propuestos (C-3, C-4, R-2) en variantes compiladas.** Son casos que la guía explícitamente no construye —una fábrica con colaboradores, una *Notification*, un cuerpo HTTP—; compilarlos costaría un cuarto proyecto en `Variantes/` sin ganar criterio. El laboratorio ya tiene la dosis justa.

---

## Fuentes de esta revisión

- Guía en `main` @ `dade777`, v2.3.0 (`last_review: 2026-09-21`), sha256 `1bac06a8ea5c09ec1582b1d67eeffeedf5e0c681a81aa753922fcfed9bc1d0e1`.
- `Examples/Dot-NET-Arquitectura-Lab/` — sólo lectura, para ubicar los archivos candidatos: `MyProject/…/Producto.cs`, `ProductoDto.cs`, `ProductoTests.cs`, `DomainExceptionHandler.cs`, `ProductoConfiguration.cs`; `Variantes/ProductoSinPrecio/…/Producto.cs`; `Variantes/Pedidos/…/Pedido.cs`; `Variantes/FabricaYResultado/…/Moneda.cs`; `Variantes/capturas/V06`, `V09`.
- Bitácora: `02-Ciclo1-Resolucion.md`, `04-Ciclo2-Resolucion.md`, `05-Ciclo3-Resolucion.md` y los dictámenes de Fowler de los ciclos 1, 2 y 3 (para rastrear qué se recortó y con qué fundamento).
- Instrucción del Product Owner del 2026-09-21 sobre citas, explicación y snippet.
