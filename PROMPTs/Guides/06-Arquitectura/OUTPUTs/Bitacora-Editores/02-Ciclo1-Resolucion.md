# Bitácora de editores 02 — Resolución del ciclo 1: peritajes, plan de parches y presupuesto

**Fecha:** 2026-09-19 · **Presidente** (no vota; lo que agrega va marcado «propio») · **Insumos:** `Ciclo-1/Informe-{Editor,Pedagogia,Fowler,DotNet,Refutador}.md` (verbatim)

## 1. Resultado del ciclo

47 hallazgos: 22 sostenidos, 13 degradados, 1 tumbado (opción b de PE-02), 7 duplicados, 4 elevados. Ningún P1 tumbado entero → **no se abre segundo ciclo** (condición del contrato: ≥ 3 P0/P1 tumbados). Rendimiento: 5,5 hallazgos procedentes por comisión (22/4), declarado.

## 2. Peritajes resueltos por el presidente

Regla aplicada: la propuesta mejor fundamentada queda aprobada (delegación del PO, 2026-09-14); el experimento mínimo del refutador se ejecuta o se razona con los datos ya medidos.

| Peritaje | Decisión | Fundamento |
|---|---|---|
| **P-1** Forma de la asociación código↔concepto | **Tabla «línea → concepto» debajo de cada bloque `[Compilado]`** (ED-01). No se toca `MyProject/*.cs` ni `lab.sh` ni `Conceptos-DI/`. | E1: `lab.sh` escribe los fuentes por heredoc y hoy coincide byte a byte con `MyProject/`; comentar el fuente crea dos verdades o edita el laboratorio congelado. La tabla cumple §0.5 sin reescribirlo y cuesta ≤ 6 líneas por bloque. |
| **P-2** Términos técnicos en §n.1 | **Se mantienen como viñeta de una línea con remisión** al snippet compilado de la misma sección (p. ej. `CancellationToken` → `ct` en el bloque de §3.3). No se sacan. | E4: §0.2 promete definir cada término la primera vez. E1: el snippet técnico ya está en el bloque de la sección (`ct` en l. 597). Costo: 0 bloques. |
| **P-3** Tercera variante | **(b) Extender `Variantes/Pedidos/` con `Infrastructure`**: `AppDbContext : IUnitOfWork` (Sqlite), `PedidoRepository` y `ProductoRepository` **con seguimiento** (sin `AsNoTracking`), un Use Case de modificación (`CambiarPrecioProducto` o `DesactivarProducto`) que ejercite obtener→cambiar→`SaveChangesAsync`, y el Demo mostrando filas afectadas = 1. Se regeneran V02 y se agrega V03. | Cociente del refutador: (b) 3 hallazgos pasan a `[Compilado]` (MF-01/NET-03, PE-12, decisión cerrada «IUnitOfWork con la firma de DbContext») con ~4 archivos; (a) 2/6; (c) 1/14. (a) se resuelve con tres fragmentos ilustrativos (ED-06/PE-07). |
| **P-4** Citas de §3.6 | **Kay se mantiene** (sostiene la oración «`producto.Precio = -1m` es un mensaje», que conecta con §3.4). **Booch pasa a paréntesis de una línea** con su referencia, sin cita textual. | Experimento del refutador razonado: la frase sobre el comportamiento como único cambio de estado se sostiene con Design by Contract (Meyer) ya citado; Booch aporta la terna estado-comportamiento-identidad, que cabe en un paréntesis. |
| **P-5** «Respuesta» en las ocho secciones ⚠ | **Alternativa de PE-11:** una línea de predicción delante («Antes de mirar la salida: ¿qué esperás que pase y por qué?»); la Respuesta en negrita queda arriba, como fija §0.3. | E4: §0.3 y la lectura de consulta (ED-10). Costo: 8 líneas. |
| **P-6** Alcance de «DTO» | **Se reserva «DTO (Fowler, 2002)» para `Contracts`** (§5.1, Anexo D vuelven a «entre procesos»); §4.3 l. 858 quita «Los dos son DTOs»; **la fila de §7.4 se conserva reescrita**: «Un objeto plano que viaja entre capas —lo que solía llamarse DTO—» → «Command o Query adentro; Request o Response en el borde». Se cita *LocalDTO* (Fowler, 2004) en el Anexo E. | MF-05 sostenido P1 con las cinco frases de *LocalDTO* verificadas; la fila de §7.4 es vocabulario del lector y su antecedente «la clase plana se partió en dos» la necesita (refutador). |
| **P-7** Nivel de `AsNoTracking` | **Queda P2 en `MyProject/`** (defecto latente: `GetByIdAsync` sólo alimenta una Query; `grep` confirma que no hay Use Case de modificación sobre `Producto`), **pero se cierra por P-3(b)**: la variante muestra el ciclo real y §5.5 declara el apartamiento de `ProductoRepository` en una oración. | Experimento del refutador ejecutado por el propio refutador. |

## 3. Plan de parches por raíz común (orden de aplicación = orden de la tabla)

Presupuesto adoptado (criterio de corte del refutador §4.2): **≤ +300 líneas y ≤ +18 bloques de código** sobre 2126 / 23. Una materialización por concepto, en un solo lugar.

| # | Raíz | Parches (hallazgos) | Quién aplica | Tope |
|---|---|---|---|---|
| R-4 | Afirmaciones sin fuente o imprecisas | MF-02 (PoEAA con capítulo y página, Anexo E), MF-03 (a)(c)(d): Use Case/Handler ⇐ Service Layer *operation script* + «Transaction Script en su propia clase, patrón Command» (PoEAA p. 111/135), MF-05 (P-6), MF-06 (Factory ⇐ Evans, GoF como salvedad), MF-08 (`Dinero` = patrón *Money*, PoEAA), MF-11, NET-02 (`record` con lista no compara por valor: corregir la frase), NET-05 (`[Index]` en `Microsoft.EntityFrameworkCore.Abstractions`), NET-10, NET-11, ED-09 (rótulo de Conceptos-DI) | Editor | 0 líneas netas (dentro de la frase o en Anexo E) |
| R-3 | `AsNoTracking` vs *Unit of Work* | NET-03/MF-01 texto (§5.5: una oración de apartamiento), NET-06 (`int Id` = 0 antes de `SaveChanges`; índice único → `DbUpdateException` → 500: una oración en §9.6), MF-10, PE-12(1) (§4.10: pregunta-criterio de Unit of Work y ✅/❌ del Aggregate en código de la variante) | Editor (texto) + .NET (variante b) | +1 bloque, +18 líneas + los bloques de la variante (cuentan en R-2) |
| R-2 | Archivos del laboratorio nunca mostrados | ED-02 (`Program.cs` composition root, `ProductoRepository`, `FakeProductoRepository`, `ProductoDto`, `AppDbContext`), ED-03/NET-08 (`IUnitOfWork` como interfaz de servicio técnico; `IEmailService`/`ICurrentUserService` pasan a «p. ej., no existen en el laboratorio»), ED-04 (`internal` de `ItemPedido`), ED-05 (igualdad de `Dinero`: prueba), NET-01 (`Program.cs` + tabla de *lifetimes* con el Singleton del repositorio en memoria), NET-12b, MF-04 (*Postcondition* materializada con `ProductoTests.Create_con_datos_validos…`) | Editor | **≤ 8 bloques** `[Compilado]` de archivos existentes + los de la variante (b) (≤ 3) |
| R-1 | Definiciones sin remisión | NET-04 como **índice** de remisiones: cada viñeta de §1.1/§3.1/§4.1/§5.1/§6.1 termina con «→ §n.m, `Archivo.cs`» y, si cabe, la firma en una línea; ED-01: tabla «línea → concepto» debajo de cada `[Compilado]` de §3.3, §4.5, §4.6, §5.2, §5.4, §5.6, §6.3, §4.10 (P-1); PE-03 (orden concreto→abstracto: cada §n.1 abre con la frase «todos estos términos se ven en el bloque de §n.m») | Editor | ~30 líneas remisiones + ≤ 6 líneas por tabla |
| R-5 | El lector no ejercita | PE-01 + PE-10(2): **una** sección nueva «§9.6 bis / Ejercicios de transferencia» (≤ 50 líneas): el ABM de Personas con stock y el pedido; PE-05: **2 contraejemplos en código** `[Fragmento ilustrativo: contraejemplo]` («una capa que solo reenvía» y el `if` de negocio en el Handler); PE-04 (par antes/después de §4.2 con `VenderCommand`/`VenderHandler` marcado ilustrativo y remisión a §9.6 paso 7); PE-11 alt (P-5); PE-02(a): una oración en §2.2 que avisa que la regla está en el «Use Case» a propósito y remite a §4.3; ED-07 (frase que reconcilia el ❌ de §6.2 con el `[Compilado]` de §6.3) | Editor | +5 bloques, ≤ 115 líneas |
| R-7 | Objetos de cliente sin código | PE-07/ED-06: tres fragmentos ilustrativos de 4–6 líneas (ViewModel, form model, `IProductoApiService`) en §6.1/§7.2 e–f | Editor | +3 bloques, ≤ 30 líneas |
| R-6 | Forma editorial | ED-08 (procedencia con rango; restituir «composition root» en el comentario citado), ED-10 (plantilla §0.3 en caps. 7–9; §4.10/§9.6 con su pregunta), ED-11 (glosario: columna «Código» → sección con el bloque; cuatro «2.» huérfanos; siete términos sin entrada), ED-12 (orden de diagramas), NET-07 (*primary constructor* nombrado en §0.2 o glosario), PE-09/NET-01 (*lifetime*, `internal` definidos), P-4 (Booch a paréntesis) | Editor | ≤ 10 líneas |

Total estimado: **+16 bloques, ~+270 líneas** (dentro del presupuesto). Lo que no entre va como remisión a `Examples/…`.

## 4. Verificación exigida antes del PR

1. Compilación de `Variantes/` (incluida la extensión de Pedidos) con SDK 10.0.400, 0 advertencias, capturas V02/V03 regeneradas; `MyProject` y `Conceptos-DI` sin tocar (`git diff --stat` vacío en esas carpetas).
2. Cada bloque `[Compilado]` nuevo coincide con su archivo (diff por bloque); cada tabla «línea → concepto» apunta a líneas que existen en el bloque.
3. 100 % de los enlaces internos resuelven; índice y Anexo A actualizados; CHANGELOG con entrada v2.1.0 (cambia estructura y agrega secciones: minor, no patch).
4. Presupuesto: `wc -l` ≤ 2426 y `grep -c '^```csharp'` ≤ 41.
5. Rule-Narrative-Voice: grep de muletillas vacío.
6. Fidelidad: la comisión Fowler relee los parches de R-4 y R-3 y dictamina en una línea por parche.

## 5. Punto de continuación

Aplicación en curso por editor (guía) y especialista .NET (variante b), en paralelo y sin pisarse (el editor no toca `Examples/`; .NET no toca la guía). Después: verificación (§4), reintegración por PR a `hdcm-dev/Lab-Documentos`, cierre en `03-Cierre.md`.
