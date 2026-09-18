# Mesa evaluadora, ciclo 2 — Informe de Edición bibliográfica

**Fecha:** 2026-09-18
**Rol:** E-Edición bibliográfica (mandato: estructura, índice con glosa, jerarquía DR-13, frontmatter DR-14, voz y registro DR-18, terminología DR-12, citas autor-fecha y Anexo E DR-10, numeración de referencias, rótulos de procedencia DR-05/DR-09; revisión de la objeción de Ri en HC-18).
**Objeto:** `LAB/Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md` v2.0.0 (1308 líneas) y `Dot-NET-Arquitectura-Lab/`.
**Vara:** R-01..R-17 (`Bitacora/02-Requisitos.md`); DR-01..DR-30 e índice aprobado (`Mesa/02-Ciclo1-Veredictos.md` §5 y §7).
**Trabajo a ciegas:** no se leyeron otros informes de `Mesa/Ciclo-2/`.

## 1. Hallazgos

### ED2-01. Remisión a la versión anterior de la guía (S2, E1)

- **Ubicación:** §9.4, línea 1128.
- **Afirmación:** la guía remite a su versión anterior, lo que incumple el chequeo de R-03 («grep "versión anterior\|guía vigente" = 0») y la condición de documento autocontenido (DR-03). Para quien lee por primera vez, la frase remite a un texto que no tiene.
- **Evidencia (E1):** `grep -n -i "versión anterior\|guía vigente" Dot-NET-Arquitectura-Guide.md` → `1128:… AutoMapper, la biblioteca de mapeo que la versión anterior de esta guía recomendaba:`. La Bitácora 04 §4 no incluyó este chequeo en su tabla.
- **Reemplazar:** «El paso L24 las aplica a AutoMapper, la biblioteca de mapeo que la versión anterior de esta guía recomendaba:»
- **Por:** «El paso L24 las aplica a AutoMapper, una biblioteca que copia automáticamente los datos entre objetos de clases distintas:»

### ED2-02. Anexo D incompleto frente a la promesa de §0.2; índice de anexos sin glosa (S2, E2 + E1)

- **Ubicación:** §0.2, línea 51; Anexo D, líneas 1228–1270; índice, línea 37.
- **Afirmación:** §0.2 promete «cada definición figura en el [Anexo D]». Diecisiete términos definidos en negrita en §1.1–§6.1 (y en el cuerpo) no figuran en el glosario: *CLI*, *plantilla*, *método de fábrica*, *excepción de dominio*, *setter privado*, *mensaje*, *interfaz de servicio técnico*, *petición HTTP*, *controller*, *EF Core*, *configuración Fluent API*, *Blazor*, *MAUI Blazor Hybrid*, *Razor Class Library*, *servicio de API del cliente*, *decorador* (l. 546) y *prueba unitaria* (l. 496). Además: (a) el índice aprobado (§5, fila D) pide las columnas «término canónico, equivalente, alias, definición de una línea, §» y el anexo tiene solo tres; (b) dos remisiones de § son erróneas: *ProblemDetails* remite a 5.6 y se define en 5.1 (l. 570); *Unidad de trabajo* remite a 5.5 y se define en 5.1 (l. 569); (c) DR-13 pide «índice solo de `##` y con glosa», y la línea 37 lista los cinco anexos sin glosa, a diferencia de §0–§9.
- **Evidencia:** E2 (cita de l. 51 y de §5 fila D del veredicto); E1: extracción de los `- **término**` de las definiciones (`grep -n -o -E "^- \*\*[^*]+\*\*"`) comparada con la primera columna del Anexo D.
- **Reemplazos:**
  1. Encabezado del Anexo D: reemplazar «`| Término | Definición | § |`» por «`| Término | Equivalente en inglés o alias | Definición | § |`» y completar la columna (p. ej. *Entidad* → *Entity*; *Value object* → *objeto de valor*; *Inyección de dependencias* → *DI*; *Unidad de trabajo* → *Unit of Work*; *Repositorio* → *Repository*).
  2. Reemplazar «`| ProblemDetails | Formato estándar de cuerpo de error en APIs HTTP (RFC 9457) | 5.6 |`» por «`| ProblemDetails | … | Formato estándar de cuerpo de error en APIs HTTP (RFC 9457) | 5.1, 5.6 |`».
  3. Reemplazar «`| Unidad de trabajo | Grupo de cambios que se confirman juntos; en EF Core, `SaveChanges` | 5.5 |`» por «`| Unidad de trabajo | *Unit of Work* | Grupo de cambios que se confirman juntos; en EF Core, `SaveChanges` | 5.1, 5.5 |`».
  4. Agregar, en orden alfabético, filas para los 17 términos listados, con la definición de una línea tomada de su propia definición en el cuerpo y su § (1.1, 1.1, 3.1, 3.1, 3.1, 4.1, 4.1, 5.1, 5.1, 5.1, 5.1, 6.1, 6.1, 6.1, 6.1, 4.5, 4.3).
  5. Línea 37: reemplazar la línea única de anexos por cinco viñetas con glosa, p. ej.: «- **[Anexo A. Hoja de ruta del laboratorio](#anexo-a-hoja-de-ruta-del-laboratorio)**: los 25 pasos con su sección y lo que confirman.» · «- **[Anexo B. Lista de verificación](…)**: las preguntas de §9 como plantilla para una solución nueva.» · «- **[Anexo C. Versiones, soporte y licencias](…)**: datos volátiles con fuente y fecha de consulta.» · «- **[Anexo D. Glosario](…)**: cada término con su equivalente y la § donde se define.» · «- **[Anexo E. Referencias](…)**: fuentes citadas, en formato autor-fecha.»

### ED2-03. Rótulos de procedencia: dos bloques compilados rotulados como «no compilados», y rótulos después del código (S3, E2 + E4)

- **Ubicación:** §0.5 l. 83; §1.4 l. 167–181; §3.3 l. 422–427; marcas de salida sin SDK en l. 270 (×2), 414, 691, 1026; rótulos sobre prosa en l. 597 y l. 1038.
- **Afirmación:**
  1. §0.5 define «**[Fragmento ilustrativo: motivo]** — El bloque no se compiló en el laboratorio». Los bloques de L03 (l. 167) y L10 (l. 422) sí se compilaron: `lab.sh` los escribe (l. 100–112 y 245–258) y los compila (`cap L03 … dotnet build`, l. 113; `cap L10 … dotnet build`, l. 259); sus capturas son justamente el resultado de esa compilación. El rótulo contradice su propia definición.
  2. DR-09 exige que todo bloque ```csharp **vaya precedido** por el rótulo. En esos dos bloques el rótulo va después (9 de 11 bloques cumplen; E1 con `awk` sobre la línea previa a cada ```csharp).
  3. DR-05 fija el pie «Salida registrada: `…`, SDK 10.0.x»; cinco marcas lo omiten, y la propia plantilla de §0.5 (l. 81) lo omite.
  4. La l. 597 usa una forma no declarada («**[Compilado en L13; …]**») y la l. 1038 aplica «[Fragmento ilustrativo]» a una frase, no a un bloque de código.
- **Reemplazos:**
  - l. 83: «| **[Fragmento ilustrativo: motivo]** | El bloque no se compiló en el laboratorio; el motivo se declara |» → «| **[Fragmento ilustrativo: motivo]** | El bloque no forma parte del código final del laboratorio: o no se compiló, o se compiló para provocar un error y se eliminó; el motivo lo declara |».
  - l. 81: «| *Salida registrada: `capturas/Lnn-….txt`* |» → «| *Salida registrada: `capturas/Lnn-….txt`, SDK 10.0.400* |».
  - Mover la l. 181 inmediatamente antes de la l. 167 y reescribirla: «**[Fragmento ilustrativo: compilado en L03 para provocar el error; el archivo se elimina en L05 (`lab.sh`).]**».
  - Mover la l. 427 inmediatamente antes de la l. 422 y reescribirla: «**[Fragmento ilustrativo: compilado en L10 para provocar el error; el archivo se elimina a continuación (`lab.sh`).]**».
  - l. 270, 414, 1026: agregar «, SDK 10.0.400» dentro de cada marca; l. 691: «(*`capturas/L18-corregido-con-savechanges.txt`*)» → «(*salida registrada: `capturas/L18-corregido-con-savechanges.txt`, SDK 10.0.400*)».
  - l. 597: «**[Compilado en L13; `Program.cs` se reemplaza en L16 y la versión de esta etapa queda en `lab.sh`.]**» → «La versión de `Program.cs` de esta etapa compiló en L13, se reemplaza en L16 y se conserva en `lab.sh`.»
  - l. 1038: «**[Fragmento ilustrativo: no se ejercitó en el laboratorio.]**» → «Esta propiedad no se ejercitó en el laboratorio.»

### ED2-04. El frontmatter parsea, pero `prerequisites` se parte en cuatro ítems (S3, E1)

- **Ubicación:** frontmatter, línea 12 (y l. 14).
- **Afirmación:** DR-14 exige «parseo YAML sin error». Parsea, pero la secuencia de flujo corta en cada coma, incluidas las de adentro del paréntesis, y el campo queda con cuatro ítems sin sentido. `traces` lleva el rango `R-01..R-17` como un solo ítem, mientras que NC-01..NC-10 está desplegado.
- **Evidencia (E1):** PyYAML en `python:3-slim` → `prerequisites => ['C# básico (clases', 'métodos', 'propiedades)', 'uso de una terminal']`; `traces => [..., 'NC-10', 'R-01..R-17']`.
- **Reemplazar:** `prerequisites: [C# básico (clases, métodos, propiedades), uso de una terminal]`
- **Por:** `prerequisites: ["C# básico (clases, métodos, propiedades)", "uso de una terminal"]`
- **Reemplazar:** `traces: [NC-01, …, NC-10, R-01..R-17]`
- **Por:** `traces: [NC-01, NC-02, NC-03, NC-04, NC-05, NC-06, NC-07, NC-08, NC-09, NC-10, R-01, R-02, R-03, R-04, R-05, R-06, R-07, R-08, R-09, R-10, R-11, R-12, R-13, R-14, R-15, R-16, R-17]`

### ED2-05. Voz: la única regla con voseo rompe la forma que usan las demás; «en tu equipo» es segunda persona fuera de lo permitido (revisión de HC-18) (S3, E2 + E4)

- **Ubicación:** l. 212; l. 108, 528, 611, 1191; l. 629 y 804; l. 288.
- **Afirmación:** DR-18 admite el voseo solo en reglas prácticas y preguntas guía, **«igual en todo el documento»**. En el texto final:
  - las preguntas guía son todas impersonales (§1.6, §2.7, §3.5, §4.6, §5.7, §6.6: «¿Cuándo no hace falta…?»);
  - las reglas usan infinitivo: «volver a verificarlos» (l. 1213) y «Quitarla de ese caso», «Corregir», «Adoptarlo» (Anexo B). La única regla con voseo es la de la l. 212 («**leé el mensaje, no solo el código de salida**, y para quitar referencias pasá la ruta»). La forma de las reglas no es uniforme;
  - el rótulo «Qué puede cambiar en tu equipo» (l. 108, 528, 611, 1191) le habla a quien lee sin ser una regla ni una pregunta, y además convive con la variante «Qué puede cambiar:» (l. 629, 804). DR-11 prescribe ese rótulo con «tu», así que las dos directivas chocan. El mapa del veredicto (§6) usa «qué puede cambiar en otro equipo», que es impersonal;
  - l. 288: «entregá» está dentro de una cita en estilo directo y no cuenta como voz del texto.
  **Sobre la objeción de Ri:** con el texto terminado, el riesgo de lectura coloquial que Ri señaló se reduce a la l. 212 y al rótulo. Aplicar la norma aprobada (voseo solo en reglas) dejaría una regla vosea entre varias en infinitivo. Queda resuelta a favor de Ri **en los hechos**, sin reabrir la norma: la forma uniforme que el documento ya usa en las reglas es el infinitivo.
- **Reemplazar (l. 212):** «Regla práctica: **leé el mensaje, no solo el código de salida**, y para quitar referencias pasá la ruta al `.csproj`.»
- **Por:** «Regla práctica: **leer el mensaje, no solo el código de salida**, y pasar la ruta al `.csproj` para quitar una referencia.»
- **Reemplazar (l. 108, 528, 611, 1191):** «**Qué puede cambiar en tu equipo:**» / «**Qué puede cambiar en tu equipo en todos los pasos:**»
- **Por:** «**Qué puede cambiar en otro equipo:**» / «**Qué puede cambiar en otro equipo, en todos los pasos:**»; y en l. 629 y 804: «**Qué puede cambiar:**» → «**Qué puede cambiar en otro equipo:**».
- **Opcional (l. 288):** «entregá `ProductoRepository`» → «entregar `ProductoRepository`».

### ED2-06. «Interfaz» se usa también para la interfaz de usuario, contra DR-12 (S3, E2 + E4)

- **Ubicación:** l. 566, 748, 823, 938, 1221.
- **Afirmación:** DR-12 reserva **interfaz** para las interfaces de C#. El documento define *Interfaz* en §2.1 con ese sentido y lo usa así más de quince veces (p. ej. l. 229, 282, 758). En cinco lugares la misma palabra, sola, nombra la interfaz de usuario. Quien lee sin experiencia no tiene cómo desambiguar «atributos de validación de interfaz» (l. 938) ni «la interfaz se carga sin red» (l. 823), justo en capítulos donde `IProductoApiService` es una interfaz de C#.
- **Reemplazos:**
  - l. 566: «no incluye una interfaz visual interactiva» → «no incluye una página web interactiva para explorarla».
  - l. 748: «para construir interfaces web con componentes C#» → «para construir páginas web con componentes C#».
  - l. 823: «La interfaz se carga sin red porque los componentes viajan dentro de la aplicación» → «Las pantallas se cargan sin red porque los componentes viajan dentro de la aplicación».
  - l. 938: «con `{ get; set; }` y atributos de validación de interfaz» → «con `{ get; set; }` y atributos de validación del formulario (`[Required]`, `[Range]`)». *Nota:* los ejemplos de atributos son [Fragmento ilustrativo]; si no se quieren nombrar, se usa «atributos de validación del formulario».
  - l. 1221: «no incluye Swashbuckle ni una interfaz interactiva» → «no incluye Swashbuckle ni una página interactiva».

### ED2-07. La numeración de las referencias de Microsoft 2026 no sigue ningún criterio; hay una cita sin enlace (S4, E1 + E4)

- **Ubicación:** Anexo E, l. 1292–1306; primeras citas en l. 91, 153, 566, 570, 691, 749, 824 y 1126; cita sin enlace en la l. 235.
- **Afirmación:** en la norma autor-fecha, las letras que desambiguan un mismo autor y año siguen un criterio declarado: el orden alfabético del título o el orden de aparición. Aquí no se sigue ninguno. Por aparición, el orden es a, b, d, e, f, g, h y c (2026c aparece por primera vez en la l. 1126, después de h). Por título, el orden alfabético sería otro («.NET and…», «ASP.NET Core Blazor configuration», «ASP.NET Core Blazor Hybrid», «DbSet…», …). Además, la cabecera «Círculo (Martin, 2012)» (l. 235) es la única cita sin la forma `[Autor, año](#ref-…)` que exige DR-10.
- **Evidencia (E1):** `grep -n -o -E "#ref-[a-z0-9-]+"`, filtrado por primera aparición → `91 a · 153 b · 566 d · 570 e · 691 f · 749 g · 824 h · 1126 c`.
- **Reemplazo (criterio de aparición, el que menos cambia):** renombrar en anclas, citas y entradas `2026d→2026c`, `2026e→2026d`, `2026f→2026e`, `2026g→2026f`, `2026h→2026g`, `2026c→2026h`, y reordenar las entradas del Anexo E por letra. Si se prefiere el criterio alfabético por título, declararlo en una línea al comienzo del Anexo E («Las obras de un mismo autor y año se distinguen con letras en orden alfabético de título»).
- **Reemplazar (l. 235):** «| Círculo (Martin, 2012) | Proyecto | Contiene |»
- **Por:** «| Círculo ([Martin, 2012](#ref-martin-2012)) | Proyecto | Contiene |»

## 2. Revisado y correcto

1. **Jerarquía y anclas (DR-13, R-11).** `##` del 0 al 9 más los anexos A a E; `###` con la forma `n.m`; exactamente siete `####` (§7.2 a–g) y ningún `#####` (E1: `grep -c`). Las `###` de decisión están formuladas como pregunta. Un script de anclas con reglas de *slug* de GitHub da **0 enlaces internos rotos**, incluidas las anclas `ref-…` (E1).
2. **Palabras y alias prohibidos (DR-18, DR-12).** La lista de DR-18 da 0 apariciones fuera de URLs (las tres de «fundamental» están en `…/fundamentals/…`). Los alias `ProductoResponseDto`, `CrearProductoRequestDto`, `Products/`, `Desktop` y `legada` dan 0. «Tu idea» no aparece: el esquema se nombra «página → servicio → EF Core» (§2.7, §7.5). Tampoco hay emojis de capa ni «MAL/BIEN» en el código.
3. **Aparato de referencias (DR-10).** Cada entrada del Anexo E tiene autor, año, título, URL y fecha de consulta (2026-09-18). Martin se cita en `blog.cleancoder.com`, y Transaction Script, Domain Model, DTO y Repository remiten al catálogo de Fowler (`martinfowler.com/eaaCatalog/`). Las recomendaciones propias llevan el rótulo «Criterio de esta guía» (§4.5, §5.6, §7.5, §9.2, §9.4). Las 17 claves `ref-` citadas tienen entrada y no hay entradas huérfanas.

## 3. Solicitudes de convocatoria (fuera de mandato)

- **Arquitectura .NET / Evidencia:** §7.2 g (l. 945) dice «En L16 `Producto` se guarda en SQLite», pero L16 solo compila; el guardado y la recuperación contra SQLite se ven en L17 (l. 662).
- **Arquitectura .NET:** §4.5 (l. 546) define el decorador como «una clase que implementa la misma interfaz que el handler», pero los handlers del ejemplo son clases concretas sin interfaz (§4.2, l. 475). Falta aclarar que el decorador requiere introducir esa interfaz.
- **Didáctica / Requisitos:** R-09 pide una pregunta de aplicabilidad «¿cuándo no…?» por capítulo. §8 no la tiene, y §7 y §9 la resuelven con otra forma (§7.5, §9.3). Conviene decidir si R-09 alcanza a §7–§9 o solo a §1–§6, como R-05.
