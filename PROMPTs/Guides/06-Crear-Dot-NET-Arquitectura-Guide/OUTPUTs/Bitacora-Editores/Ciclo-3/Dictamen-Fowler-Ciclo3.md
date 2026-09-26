# Dictamen de la comisión Martin Fowler — post-aplicación del ciclo 3

**Fecha:** 2026-09-21
**Objeto:** `Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md` @ working tree, **v2.3.0** (2753 líneas), rama `docs/arquitectura-v2.1.0-mesa-editores`, sin commitear.
**Insumos:** `Ciclo-3/Informe-Fowler-Invariantes.md`, `Ciclo-3/Informe-DotNet-Materializadores.md`, `05-Ciclo3-Resolucion.md` (E-1…E-14).
**Secciones leídas:** §3.1, §3.6, §3.7, §4.10, §5.1, §5.4, §6.1, §6.3, §7.4, Anexos A, C, D y E; `Variantes/capturas/V09-materializadores.txt`, `Variantes/FabricaYResultado/Demo/Program.cs`, `CHANGELOG.md`.
**Alcance:** no se editó la guía.

## Verificaciones mecánicas

| Chequeo | Comando | Resultado |
| --- | --- | --- |
| Frase de Evans 2003 sobre invariantes | `grep -n "whenever data changes"` | **0 coincidencias** ✅ |
| Presupuesto E-14 | `git diff --numstat` sobre la guía | **+72 / −12 = +60 netas**, tope exacto ✅ |
| Bloques nuevos | `git diff` sobre las vallas ``` | **2** (§5.4 y §7.4), tope exacto ✅ |
| Anclaje de los bloques | `sed -n '45p;62p;261p;303p;309p;311p' Program.cs` | las seis líneas citadas existen y dicen lo que la guía transcribe ✅ |
| Fila de Dapper en Anexo C y `ref-dapper-2026` | lectura | presentes, con licencia verificada en el `.nuspec` ✅ |

## Dictámenes

| # | Decisión | Dictamen | Fundamento |
| --- | --- | --- | --- |
| **E-1** | Procedencia de la refactorización | **CONFORME** | §3.1 l. 545 dice exactamente lo verificado: catalogada desde la 1.ª ed. (1999) como *Replace Constructor with Factory Method*, renombrada *Factory Function* en la 2.ª (2018), alias en el catálogo, **sin coautor**; la corrección menor a `ref-fowler-refactoring` (l. 2685) también entró. |
| **E-2** | Bloch como convergencia | **CONFORME CON OBSERVACIÓN** (la posterioridad no está en el cuerpo) | §3.1 lo presenta bien como movimiento formulado «de manera independiente» y con ítem 1 de la 3.ª ed., pero **no dice que sea posterior a *Refactoring***: ese dato quedó sólo en la entrada `ref-bloch-2018` del Anexo E. Quien lee la viñeta no puede fechar la convergencia sin bajar a la referencia. Costo de corregirlo: tres palabras. |
| **E-3** | No citar a Evans 2003 de segunda mano | **CONFORME CON OBSERVACIÓN** (sobrevive una cita ajena a esta decisión) | «whenever data changes» no aparece (grep negativo) y §4.10 usa la *Reference* 2015 verbatim. Observación: la guía conserva de v2.2.0 **una** cita de Evans 2003 de segunda mano en §9.6 paso 7 (l. 2439, «This layer is kept thin…», con `ref-evans-2003` rotulada «Citado en Fowler (2003)»). Está declarada y es anterior a este ciclo, pero por el criterio que la propia mesa fijó merece revisarse en el ciclo siguiente. |
| **E-4** | Tercera condición de *Invariant* | **CONFORME** | §3.1 l. 545 tiene las **tres** condiciones (vale toda la vida, se verifica mirando ese objeto solo, si se rompe el objeto no debería existir) y la fila `Invariant` del Anexo D (l. 2604) repite las tres y agrega §4.10. |
| **E-5** | Las tres piezas, en §3.6 | **CONFORME** | Tabla de 3 filas con la columna «si falta» (l. 733–737), cada fila anclada a código ya compilado (§3.3, CS0200 de §3.4, §3.7) y el cierre **rotulado «Criterio de esta guía»** (l. 731). El rótulo quedó en el párrafo que abre la tabla y no debajo: es mejor así, la afirmación y su marca se leen juntas. |
| **E-6** | Siete ejemplos en §3.7 | **CONFORME CON OBSERVACIÓN** (dos: columnas y el «100») | Los **cuatro contraejemplos están bien clasificados**: DNI repetido falla la segunda condición; «no se vende sin precio» falla la primera y es *Precondition*; la longitud de columna pasa las dos y cae por la prueba del papel del §3.2; la autorización falla las dos y es *authorization*. Observación 1: el texto anuncia «las tres condiciones del §3.1 se usan como filtro» pero la tabla sólo tiene **dos** columnas de filtro; la tercera queda implícita. Observación 2: la fila de la columna dice «hasta 100 caracteres» mientras §5.4 mapea `HasMaxLength(200)`; el ejemplo es hipotético, pero el número contradice el único caso concreto de la guía. |
| **E-7** | *Aggregate* en §4.10 | **CONFORME** | l. 1262: el «para qué» del borde, la cita verbatim de la *Reference* 2015 («Define properties and invariants for the aggregate as a whole…»), la regla del pedido confirmado como *Invariant* del *Aggregate* y el porqué del constructor `internal`. Sin código nuevo, como se pidió. |
| **E-8** | Tabla de los cuatro materializadores (§5.4) | **CONFORME CON OBSERVACIÓN** — **la más grave del ciclo** | La tabla existe (l. 1657–1661) con las tres columnas pedidas, y siete de sus ocho celdas nuevas se leen contra una línea de V09. **La excepción:** la celda de `System.Text.Json` afirma «con `[JsonConstructor]` **o con un único constructor público que coincida**, materializa sin tocar un setter». `[JsonConstructor]` está medido (V09 2.c); el caso positivo del constructor público que coincide **no está en V09** —2.d es el caso negativo— ni existe en `Program.cs`. Es prosa donde el resto es medición. Ver «Nuevas afirmaciones sin respaldo». |
| **E-9** | §7.4, suficiente y no necesario | **CONFORME CON OBSERVACIÓN** (arrastra la de E-8) | La celda quedó corregida (l. 2131) y el modo de falla medido está escrito con su bloque compilado y su salida exacta («NO lanzó: el objeto llegó entero en su valor por omisión», V09 2.b). La observación es sobre la mitad afirmativa de la celda —«o un constructor cuyos parámetros se llamen como las propiedades —lo que da un `record` posicional»—: es la misma afirmación sin línea de captura que en E-8. |
| **E-10** | Glosario y definiciones | **CONFORME** | Viñeta de ORM/micro-ORM en §5.1 (l. 1498), viñeta de serializador en §6.1 (l. 1831) y las tres filas nuevas del Anexo D (`Micro-ORM` l. 2612, `ORM` l. 2619, `Serializador` l. 2641), con la redacción aprobada y sin gasto de bloques. |
| **E-11** | Un solo bloque con los cuatro usos | **CONFORME** | Un bloque en §5.4 con las cuatro líneas reunidas y su anclaje honesto («l. 45, 62, 261 y 303 — las cuatro líneas, reunidas»), y el segundo, el reservado, gastado en el ❌ medido del serializador en §7.4. Dos bloques en total: exactamente el presupuesto. |
| **E-12** | Compilar el escenario | **CONFORME** | `ProductosDeMaterializacion.cs` nuevo, escenario `materializadores` en el Demo, línea en `variantes.sh` y captura versionada `V09-materializadores.txt` con el encabezado del laboratorio (imagen, digest, SDK 10.0.400, código de salida 0), listada en el Anexo A (l. 2511). La deuda de V06 quedó declarada en el Anexo A (l. 2499) y en el CHANGELOG. |
| **E-13** | Dapper como primer paquete de terceros | **CONFORME** | Fila en el Anexo C (l. 2545) con versión, licencia verificada en el `.nuspec` y remisión a V09; `ref-dapper-2026` en el Anexo E; el Anexo A avisa que es el único proyecto con un paquete de terceros. Coherente con el criterio de §9.4, que el laboratorio ahora ejerce en lugar de sólo enunciar. |

**Conteo: 8 CONFORME · 5 CONFORME CON OBSERVACIÓN · 0 NO CONFORME.**

## Nuevas afirmaciones sin respaldo

Una sola, en dos lugares, y nace del **apartamiento 3 del editor** (haber dejado `System.Text.Json` sin entrada en el Anexo E) combinado con un recorte del banco de pruebas al trasplantarlo:

> **§5.4, celda de `System.Text.Json`:** «o con un **único** constructor público que coincida, materializa sin tocar un setter».
> **§7.4, fila «Transporte»:** «o un constructor cuyos parámetros se llamen como las propiedades —lo que da un `record` posicional».

El banco del informe .NET sí midió ese caso (su caso D), pero **no se trasplantó**: `V09-materializadores.txt` §2 tiene a, b (ctor público sin parámetros), c (`[JsonConstructor]`), d (parámetros que **no** coinciden) y e (salida), y ningún caso positivo de constructor público que coincida. La afirmación queda hoy sostenida por prosa.

**¿Alcanza la medición?** Casi. Hay que separar dos cosas:

1. **Que un constructor con parámetros que coinciden materialice** es un hecho observable y **ya está observado en la guía**, aunque en otro lugar: L22 compila y captura `GetFromJsonAsync<List<ProductoResponse>>` sobre `public record ProductoResponse(Guid Id, string Nombre, decimal Precio)` (`capturas/L22-cliente-consola.txt`), que es exactamente el serializador materializando un `record` posicional por su constructor. **Basta con invocarlo**: citar L22 junto a la celda de §5.4 y a la fila de §7.4 —o reponer el caso positivo en el escenario y regenerar V09— cierra el punto con medición y con costo cero en líneas. Es, además, la frase que el informe .NET proponía en §6.3 (NET3-06) y que no se aplicó.
2. **La palabra «único»** no es observable en V09: que con **varios** constructores públicos haga falta `[JsonConstructor]` es una **regla documentada del serializador**, no un resultado de las cuatro corridas. Para eso **sí hace falta documentación**, y es la que el apartamiento 3 dejó fuera:

> `<a id="ref-microsoft-2026o"></a>`Microsoft. (2026o). *How to use immutable types and non-public accessors with System.Text.Json* / `JsonConstructorAttribute`. https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/immutability (consultado el 2026-09-21).

Con esa entrada —una línea en el Anexo E, dentro de presupuesto— la guía queda con el mismo estándar de procedencia que se exige a sí misma: EF Core tiene `Microsoft, 2026m` para su costura, Dapper tiene `ref-dapper-2026`, y el tercer materializador es hoy el único de los cuatro que afirma una regla sin fuente ni captura. Mientras tanto, la redacción honesta sería quitar «único» o sustituirlo por «un constructor público que coincida (V09 2.d muestra el caso en que no coincide)».

## Nota de cierre

Ninguna de las observaciones invalida lo aplicado: las tres preguntas del Product Owner quedaron respondidas con procedencia verificada, definición completa y medición propia, y el volumen volvió al laboratorio como manda el criterio del ciclo 1. Las cinco observaciones se corrigen con una línea de referencia, dos citas de captura y tres palabras.
