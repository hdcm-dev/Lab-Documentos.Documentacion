# Mesa de expertos — Acta de las seis cuestiones que bloquean la fase interactiva

| | |
| --- | --- |
| **Fecha** | 2026-09-24 |
| **Clase de objeto** | **Diseño de una norma o decisión** (`Knowledge-Mesa-De-Expertos-A-Pedido.md` §2.2, tercera fila): lo que se resuelve son seis decisiones de diseño sobre un corpus vivo, no hallazgos sobre un artefacto terminado. Regla de cierre propia de la clase: **un dictamen que responde cada pregunta del pedido por separado, sin «depende»** |
| **Marco** | `Knowledge-Mesa-De-Expertos-A-Pedido.md` 1.2 · `IA.Prompts/Base/Mesa-Evaluadora.md` · Reporte `23` de `IA.SDD.Documentacion` (aplicado, no citado de adorno: ver [§0.4](#04-el-rol-que-suma-esta-mesa-conciliación)) |
| **Objeto** | `LAB/Lab-Documentos/Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md` v2.4.0 (2817 líneas) y `Dot-NET-Arquiectura-Interactive-Guide.md` v0.1.0 (481 líneas) |
| **Quién aplica** | Quien el pedido designe. La mesa entrega los parches con texto exacto y su verificación; **no editó ningún archivo** fuera de esta acta |
| **Presidente** | El conductor de la mesa. No vota |
| **Autoridad** | Delegación del PO del 2026-09-14: la mesa decide y la propuesta mejor fundamentada queda aprobada |

> **Lo que esta acta no hizo**: no tocó el apunte, ni la guía interactiva, ni `Interactive-Activities/`, ni nada bajo `PROG2/`. Todos los parches están redactados para aplicarse, ninguno está aplicado.

---

## Índice

- [0. Convocatoria](#0-convocatoria)
- [1. Base mecánica: lo medido antes de que nadie opine](#1-base-mecánica-lo-medido-antes-de-que-nadie-opine)
- [C-1. Dónde vive la interfaz del Repository](#c-1-dónde-vive-la-interfaz-del-repository)
- [C-2. El tratamiento de las jerarquías de tipos](#c-2-el-tratamiento-de-las-jerarquías-de-tipos)
- [C-3. RN-13 contra CU-11](#c-3-rn-13-contra-cu-11)
- [C-4. La referencia `Infrastructure → Application`](#c-4-la-referencia-infrastructure--application)
- [C-5. Las tres decisiones de construcción](#c-5-las-tres-decisiones-de-construcción)
- [C-6. La escalera del §9.2 y la aplicación de escritorio](#c-6-la-escalera-del-92-y-la-aplicación-de-escritorio)
- [7. Anexo de peritajes: las tres corridas](#7-anexo-de-peritajes-las-tres-corridas)
- [8. Cierre](#8-cierre)

---

## 0. Convocatoria

### 0.1 Contrato de entrada

```text
PEDIDO (literal, 2026-09-24): «Convocás y conducís una MESA DE EXPERTOS para resolver seis
  tensiones que bloquean la fase interactiva de una guía de estudio de arquitectura .NET.
  La mesa DECIDE: lo que resuelva queda aprobado y se aplica. No devuelvas un abanico de
  opciones sin pronunciarte.»
CORRECCIÓN DEL CONDUCTOR (literal, en curso): «DOS DE LAS SEIS CUESTIONES LAS RESOLVIÓ EL
  AUTOR DEL ENUNCIADO. No las delibere más; tomalas como dadas y ajustá el acta. […] C-3
  (RN-13 vs CU-11) — RESUELTA POR CORRECCIÓN DE LA FUENTE. […] La actividad usa SQLite.»
CLASE DE OBJETO: diseño de una norma o decisión
OBJETO: el apunte v2.4.0 y la guía interactiva v0.1.0, con la fuente de la actividad y el
  código de escritorio (HEAD 80c003b) como evidencia de contraste
OBJETIVO: dejar las seis cuestiones decididas y con el parche redactado, para que la fase
  interactiva arranque sin volver a abrirlas
PREGUNTAS DEL CASO: C-1 a C-6 (una sección por cuestión; cada una se responde entera)
RESTRICCIONES DURAS:
  - No se edita ningún archivo fuera de esta acta
  - No se cita lo que no se pudo verificar textualmente, y se dice cuál es
  - Voz del apunte: rioplatense neutro, respuesta primero en negrita, ✅/❌, marcas de
    procedencia; lo propio va rotulado «Criterio de esta guía»
  - Regla de la casa: la cita entra con explicación y materializada en un snippet
DECISIONES CERRADAS (no se reabren): E-3 (Evans 2003 no se cita), D-5, D-9, el 400 en lugar
  del 422, R-4; el dominio de la actividad viene dado por la cátedra; la persistencia de la
  actividad es SQLite (decisión del autor, 2026-09-24)
FUERA DE ALCANCE: reabrir los cuatro ciclos de mesa anteriores; el contenido de `Exercices/`;
  cualquier escritura sobre `PROG2/`
MEDIOS: lectura del corpus; `grep`/`wc` sobre los dos documentos; y **tres corridas en
  contenedor** con `mcr.microsoft.com/dotnet/sdk:10.0` (§7). Sin observar: nada que requiera
  Windows Desktop — el cliente WinForms no compila en este equipo, y eso condiciona C-5 (a)
EXPEDIENTE: esta acta. La mesa no cumple `Expediente-Rules.md` §1 (no hay destino con
  corpus normativo propio): queda carpeta con el acta, sin forma de expediente
QUIÉN APLICA: quien el pedido designe; la mesa entrega el plan
PRESUPUESTO: una ronda; el corte es por cuestión respondida, no por rendimientos
```

### 0.2 Composición del panel, con señal y ubicación

**Núcleo permanente** (se convoca siempre, `Mesa-Evaluadora.md` §4.1.1):

| Rol | Por qué |
| --- | --- |
| **Requisitos** | Las seis cuestiones son requisitos del documento que viene: hay que poder decir cuándo cada una está cumplida |
| **Verificación / QA** | Cinco de las seis se pueden cerrar con un comando; la mesa no acepta una decisión cuya verificación no exista |
| **Implementador ingenuo** (lector) | El apunte se juzga por lo que un lector que no estuvo en la discusión puede decidir con él |
| **Refutador** | Entra último y ataca la lectura dominante **y el costo de aplicarla** (la clase «diseño de norma» lo exige) |

**Catálogo variable** (techo de cinco; cada una con su señal citada):

| Rol | Señal observable | Voto | Resultado |
| --- | --- | --- | --- |
| **E-Arquitecto .NET** | «más de un componente y una restricción dura de stack»: cuatro proyectos, EF Core, `System.Text.Json`, SDK 10.0.400 (`Interactive-Activities/global.json`) | 5-0 | CONVOCAR |
| **E-Didáctica** | El objeto es material de estudio: «respuesta formadora de criterio» es su unidad (`07-Actividad-Didactica.md` §6.3) | 5-0 | CONVOCAR |
| **E-Edición bibliográfica** | Citas, aparato crítico y rótulos de procedencia: 110 citas textuales, 50 entradas en el Anexo E, 16 «Criterio de esta guía» (`08-Dictamen-Editorial.md` §1) | 5-0 | CONVOCAR |
| **AH-001 · Perito de laboratorio .NET 10** | Tres afirmaciones del pedido son sobre mecanismos que **nadie midió**: jerarquía en JSON, jerarquía en EF Core, 400 automático sin `[ApiController]` (F-B, F-C, F-J del análisis didáctico) | 5-0 | INSTANCIAR (carta en §0.3) |
| **AH-002 · Conciliador de criterios** | Cuatro de las seis cuestiones vienen con **dos criterios de rol que no se pueden aplicar juntos**; el Reporte `23` mide qué pasa cuando eso no tiene dueño | 4-1 | INSTANCIAR (§0.4) |

**Descartados, con motivo** —el registro que permite corregir el criterio si después aparece un defecto en esa área—:

| Rol | Motivo del descarte |
| --- | --- |
| Seguridad y privacidad | No hay datos personales ni autenticación en juego. **Excepción registrada**: apareció una señal en la corrida del perito (la traza completa dentro del `ProblemDetails` en Development, §7.3) y se resolvió dentro de C-5 (c) sin reconvocar |
| Concurrencia / tiempo | Ningún proceso simultáneo en el alcance; el único caso de carrera (el índice entre dos peticiones) ya está resuelto en A2 y no se discute acá |
| Rendimiento y costo | No hay volumen ni latencia prometidos. TPH contra TPT roza el tema y se resolvió con el esquema medido, no con una estimación |
| Accesibilidad / uso | No hay superficie de interfaz para observar: el cliente todavía no existe. Se reconvoca cuando A8 produzca pantallas |
| Usuario estándar | Es un rol de la clase «interfaz en ejecución» y esta mesa no lo es |

### 0.3 Carta de mandato de AH-001

```yaml
agente_ad_hoc:
  id: AH-001
  nombre: Perito de laboratorio .NET 10
  señal_que_lo_justifica:
    descripción: "Tres afirmaciones centrales del pedido dependen de mecanismos que ningún
      ciclo midió: cómo viaja una jerarquía en System.Text.Json, cómo la mapea EF Core sobre
      SQLite, y si el 400 automático existe sin [ApiController]"
    ubicación: "07-Actividad-Didactica.md §8, F-B, F-C y F-J; 08-Dictamen-Editorial.md §3, T-5"
  pregunta_que_responde: "¿Qué hace realmente el stack cuando una jerarquía cruza un borde?"
  competencia: "Diseñar y correr el experimento mínimo y transcribir su salida verbatim.
    NO le corresponde decidir qué enseña el apunte ni cómo se redacta."
  evidencia_admisible: [E1]
  tope_hallazgos: 5
  se_disuelve_cuando: "Entrega las tres corridas del §7"
```

**Por qué un perito y no una opinión**: el filtro «el peritaje cambia una sola variable» (`Knowledge…` §3.3). Las tres corridas difieren del caso real en una sola cosa —el dominio es un recorte de dos subtipos— y todo lo demás es el stack de la actividad.

### 0.4 El rol que suma esta mesa: conciliación

El Reporte `23` de `IA.SDD.Documentacion` dice que la mesa **tiene cuatro piezas contra el consenso prematuro y ninguna para el desacuerdo entre criterios**, y mide el desenlace: el investigador produce quince, el juez descarta trece sin mirarlas, y nadie escribe por qué. El reporte está **Abierto**: lo que sigue no es norma del framework, es una propuesta que esta mesa aplica y declara.

**Mandato de AH-002**: no acercar posiciones. Detectar que dos criterios no se pueden aplicar juntos y **producir el que los reemplaza**, antes de que las comisiones produzcan sobre ellos. Su producto queda escrito en cada cuestión, bajo el rótulo **Conciliación**, con **por qué se descartó el criterio de cada rol**.

El voto 4-1 registra la objeción del juez de coherencia histórica: *«aplicar una propuesta de un reporte abierto es adoptar norma por la ventana»*. Se resolvió declarándolo: el rol existe **en esta mesa y para este pedido**, no queda incorporado a ninguna regla, y su efecto está medido en cada cuestión para que el reporte tenga una segunda corrida con la que discutir.

**Resultado medido de aplicarlo**: en tres de las seis cuestiones (C-1, C-4, C-6) el criterio que resolvió **no era el de ninguna de las dos posiciones**, y en una (C-6) contradijo a las dos.

---

## 1. Base mecánica: lo medido antes de que nadie opine

Todo dato que el despacho le pasó al panel, con su comando. Es la convención que más caro se paga si se ignora: *«la mesa hereda los errores de quien la convoca»*.

| # | Dato | Comando | Salida |
| --- | --- | --- | --- |
| B-1 | El apunte no trata jerarquías | `grep -ci` sobre 2817 líneas | `herencia` 0, `polimorf` 0, `jerarqu` 0, `Liskov` 0, `clase abstracta` 0 |
| B-2 | §2.1 mapea `Domain` al círculo *Entities* y dice que contiene «interfaces de Repository» | lectura de la tabla «Círculo → Proyecto», l. 279–284 | verbatim: `| Entities | MyProject.Domain | Entities, Value Objects, reglas, interfaces de Repository |` |
| B-3 | La interfaz existe y está en `Domain` | l. 665 del apunte | `[Compilado: MyProject/src/Backend/MyProject.Domain/Productos/IProductoRepository.cs, l. 3–9]`, namespace `MyProject.Domain.Productos` |
| B-4 | §2.7 declara `Infrastructure → Application` y admite que nadie la usa | l. 524 del apunte | «esa referencia queda declarada pero sin uso: ningún archivo de `Infrastructure` nombra un tipo de `Application` (se comprueba con `grep -rn Application src/Backend/MyProject.Infrastructure --include=*.cs`, que no devuelve nada)» |
| B-5 | §9.8 declara el control que §2.7 incumple | l. 2516 | «Cada capa y cada clase se agrega cuando aparece la señal que la justifica» |
| B-6 | RN-09, RN-10 y RN-14 se hacen cumplir en la vista | lectura de `Vistas/FormPrincipal.cs` | l. 553 `estancia.EstaAsignada(seleccionada)`; l. 337 `estancia.EstaAsignada(lote)`; l. 396 y ss. cadena de `if (actividad is Agricola) { ((Agricola)actividad).… }` |
| B-7 | El defecto latente de la Tarea 2 | `Vistas/Datos/FormActividadDatos.cs` l. 18 | `tbCantidadCabezas.Enabled = cmbTipoActividad.SelectedIndex > 0;` con cuatro ítems en el combo |
| B-8 | La solución nueva compila y responde | verificación del 2026-09-24 | SDK 10.0.400, `LaEstancia.slnx`, `Microsoft.AspNetCore.OpenApi` 10.0.11, `Scalar.AspNetCore` 2.17.9; `/openapi/v1.json` 200 con `paths` vacío; `/scalar/` 200 |
| B-9 | El Anexo E **ya tiene** *AnemicDomainModel* y el catálogo de refactorizaciones | `grep -n 'ref-fowler-2003\|ref-fowler-refactoring'` | `ref-fowler-2003` (2003) y `ref-fowler-refactoring` (dos refactorizaciones: *Replace Constructor with Factory Function* y *Replace Nested Conditional with Guard Clauses*) |
| B-10 | El Anexo E **no tiene** Liskov | `grep -c Liskov` | `0` |
| B-11 | `§3.9` tiene 7 remisiones vivas | `grep -c '§3\.9'` | `7` (l. 546, 737, 1020, 1706, 2014, 2587, 2632) |
| B-12 | El enunciado fue corregido por su autor | `09-Fuente-Actividad-La-Estancia.md` §2, «Corrección del autor, 2026-09-24» | desaparece «al menos tiene asignado un lote»; RN-13 pasa a «a una actividad se le asignan una o más parcelas, **después** del alta» |
| B-13 | La persistencia de la actividad está decidida | ídem, §6 | «**Decisión del autor para la actividad interactiva (2026-09-24): se usa SQLite.**» |
| **B-14** | **Jerarquía en `System.Text.Json` 10** | peritaje P-1 (§7.1) | serializa con discriminador; sin discriminador → `NotSupportedException`; discriminador no registrado → `JsonException: Read unrecognized type discriminator id 'forestal'` |
| **B-15** | **Jerarquía en EF Core 10 sobre SQLite** | peritaje P-2 (§7.2) | TPH por defecto: `Discriminator TEXT NOT NULL` y columnas propias **NULL**. TPT: tres tablas y columnas propias **NOT NULL**. Y con sólo `DbSet<Base>` el modelo **no valida** |
| **B-16** | **El 400 automático sin `[ApiController]`** | peritaje P-3 (§7.3) | minimal API + `AddProblemDetails()` → `400 application/problem+json` **sin `errors`** y con la excepción entera en Development; **sin** `AddProblemDetails()` → `400` con `Content-Length: 0` |

**Corrección del despacho, registrada.** Dos datos que el pedido traía como tensiones abiertas —C-3 y la persistencia— dejaron de serlo durante la corrida, y no por deliberación: **los cerró el autor de la fuente**. La mesa lo asienta como lo que es, un resultado del método (ver [C-3](#c-3-rn-13-contra-cu-11)), y no se atribuye la decisión.

---

## C-1. Dónde vive la interfaz del Repository

### Posiciones

| | Posición A — se queda en `Domain` | Posición B — se muda a `Application` |
| --- | --- | --- |
| **Quién la sostiene** | E-Arquitecto .NET, E-Didáctica | E-Edición bibliográfica, Refutador |
| **Tesis** | La interfaz la declara quien la necesita, y quien necesita no saber cómo se guarda es el dominio | El que persiste no es la *Entity* sino el caso de uso; el círculo *Entities* no debería tener una sola interfaz de acceso a datos |
| **Evidencia** | **E1**: `IProductoRepository` está compilado en `Domain` y `Domain` compila con cero referencias (`capturas/L09-domain.txt`, L08). **E2**: Evans le pide al *Repository*, desde el dominio, dar «the illusion of an in-memory collection of all objects of that aggregate's root type» ([Evans, 2015], citado ya en §4.4 del apunte) | **E2**: §2.1 del apunte adopta los cuatro círculos de Martin y dice que el círculo *Entities* «contiene […] interfaces de Repository»; en *Clean Architecture* los *gateways* pertenecen al círculo de los *Use Cases*. La contradicción está en el documento y **no se nombra** |
| **Costo si gana** | Queda una contradicción viva con la fuente que el propio apunte adopta | Se regeneran `L09`, `L11`, `L12`, `L16`, `L17`; cambian §3.3, §4.4, §4.6, §5.3, §5.5, §8.3 y dos diagramas |

### Conciliación

Los dos criterios en juego eran **«¿quién es dueño del concepto?»** (Evans, posición A) y **«¿quién necesita el gateway?»** (Martin, posición B). No se pueden aplicar juntos y ninguno es completo: el primero no dice qué hacer cuando la guía adoptó explícitamente los círculos del segundo; el segundo no dice qué se gana pagando la regeneración.

**El criterio que los reemplaza — y que no propuso ninguna de las dos posiciones — es éste: la regla de dependencia no desempata, así que la ubicación no es una cuestión de corrección sino de qué enseña el apunte, y lo que no se puede dejar sin decidir es la contradicción, no la ubicación.** Medido: con la interfaz en `Domain` el grafo de L08 da `Domain` con cero referencias y `Application → Domain`; con la interfaz en `Application` daría exactamente el mismo grafo con una flecha idéntica. **Las dos ubicaciones satisfacen la regla que el capítulo 2 enseña.** Por eso el defecto real —el que un lector puede sufrir— no es que la interfaz esté en `Domain`: es que el apunte adopta una fuente y la contradice en una fila sin avisar, y el lector que venga del libro no puede saber si eso es una elección o un descuido.

Por qué se descartó el criterio de cada rol: el de la posición A porque «Evans también lo dice» no resuelve haber adoptado los círculos de otro; el de la posición B porque exige el cambio más caro del corpus para conseguir cero mejoras en la única propiedad que el capítulo mide.

### Decisión

**La interfaz se queda en `Domain`, y la divergencia con Martin se declara en §2.1 con la marca «Criterio de esta guía», más una remisión desde §4.4.** Aprobada 5-0 (evidencia, impacto, costo/beneficio, coherencia histórica, riesgo).

### Parches

**P-C1-a.** En §2.1, en la tabla «Círculo → Proyecto», **reemplazar** la fila:

```text
| Entities | `MyProject.Domain` | Entities, Value Objects, reglas, interfaces de Repository |
```

**por**:

```text
| Entities | `MyProject.Domain` | Entities, Value Objects, reglas, interfaces de Repository (con la salvedad de abajo) |
```

**P-C1-b.** En §2.1, **después de la tabla** «Círculo → Proyecto» y **antes del párrafo que empieza** «Los términos de la columna «Contiene» se definen en el capítulo de su proyecto», **agregar**:

> **Una salvedad sobre la primera fila.** Martin ubica las interfaces de acceso a datos —lo que un caso de uso usa para pedir y guardar— en el círculo de los *Use Cases*, no en el de las *Entities* ([Martin, 2017](#ref-martin-2017)); esta guía las declara en `Domain`, y lo hace a sabiendas. La razón es la que el §2.2 enseña en su paso 1: **la interfaz la declara quien la necesita**, y acá quien necesita no saber cómo se guarda es el dominio. Evans le pide al *Repository* exactamente eso, y desde adentro del dominio: dar «the illusion of an in-memory collection of all objects of that aggregate's root type» ([Evans, 2015](#ref-evans-2015)); es la misma frase con la que §4.4 lo reconoce. Conviene ver qué **no** cambia con la elección: las dos ubicaciones dejan el mismo grafo de referencias —`Domain` sin ninguna, `Application → Domain`—, que es lo que L08 mide; **la regla de dependencia no desempata acá**. Lo que decide es qué se quiere enseñar, y esta guía enseña que una capa declara lo que le falta en lugar de esperar que se lo den. **Criterio de esta guía**, declarado para que quien venga del libro de 2017 sepa que hay una elección y no un descuido. → §3.3 (`IProductoRepository.cs`, en `Domain`), §4.4.

**P-C1-c.** En §4.4, en la tabla de preguntas, **reemplazar** la celda de la fila «¿Dónde vive?»:

```text
| ¿Dónde vive? | La interfaz en `Domain`, la implementación en `Infrastructure` | Es la inversión de dependencias del §2.4: el dominio declara lo que necesita sin nombrar EF Core |
```

**por**:

```text
| ¿Dónde vive? | La interfaz en `Domain`, la implementación en `Infrastructure` | Es la inversión de dependencias del §2.4: el dominio declara lo que necesita sin nombrar EF Core. Martin la ubicaría en el círculo de los *Use Cases*; la divergencia está declarada en §2.1 |
```

**P-C1-d.** En el Anexo E, **reemplazar** la entrada:

```text
<a id="ref-martin-2017"></a>Martin, R. C. (2017). *Clean Architecture: A Craftsman's Guide to Software Structure and Design*. Prentice Hall. Cap. 20, «Business Rules».
```

**por**:

```text
<a id="ref-martin-2017"></a>Martin, R. C. (2017). *Clean Architecture: A Craftsman's Guide to Software Structure and Design*. Prentice Hall. Cap. 20, «Business Rules». La ubicación de las interfaces de acceso a datos en el círculo de los *Use Cases* (§2.1) **se cita sin apartado y sin texto literal**: el ejemplar no estuvo a la vista en la corrida que la incorporó, y rige la misma política que la decisión sobre Evans (2003).
```

> **Por qué el parche no trae una cita textual de Martin.** No se verificó ninguna. La mesa aplica su propia regla —«toda afirmación sobre la industria o la academia lleva fuente; si no se está seguro del apartado, se cita sin apartado, y no se inventan cláusulas»— y deja la verificación como deuda: ver [§8.3](#83-deuda-declarada), D-1.

**Verificación del parche**: `grep -c 'Criterio de esta guía'` pasa de 16 a 17; el script de anclas sigue dando 0 enlaces rotos; `grep -n 'salvedad de abajo' ` devuelve una sola línea y está en §2.1.

---

## C-2. El tratamiento de las jerarquías de tipos

### Posiciones

| | Posición A — el apunte gana el tema | Posición B — el tema se queda en la actividad |
| --- | --- | --- |
| **Tesis** | Es el hueco mayor del corpus y bloquea A5 y A7; un apunte que enseña a decidir estructura y no dice cuándo una jerarquía es la respuesta está incompleto | El apunte es sobre la regla de dependencia; la jerarquía es el eje de *otra* materia, y meterlo desbalancea el capítulo 3 y arrastra renumeración |
| **Evidencia** | **E1**: `herencia` 0, `polimorf` 0, `jerarqu` 0, `Liskov` 0 en 2817 líneas (B-1). **E2**: §7 se llama «Cada objeto responde una pregunta» y no tiene la pregunta que el caso hace | **E2**: §0.1 declara el alcance del apunte; **E2**: C-1 del dictamen ya señala que §3.9 está sobrecargado, y meter una sección más empeora el capítulo |
| **Costo** | +70/+90 líneas, una entrada nueva en el Anexo E, renumeración de 7 remisiones vivas (B-11) | El alumno que lea el apunte para resolver la actividad no encuentra una línea del tema que la actividad evalúa |

### Conciliación

Los dos criterios eran **«el corpus tiene que cubrir lo que la actividad usa»** y **«el capítulo tiene que quedar balanceado»**. El criterio que los reemplaza:

> **No se decide si el tema entra, sino qué parte del tema es criterio y qué parte es mecanismo.** El criterio —cuándo una jerarquía es del dominio— no depende del stack y es exactamente lo que §3 enseña; los mecanismos —cómo la mapea EF Core, cómo la publica `System.Text.Json`— dependen del stack y ya tienen capítulo: §5.4 y §7.2 d. Repartido así, el capítulo 3 recibe una sección de su propia naturaleza y no un tratado, y los dos mecanismos entran donde el lector los va a buscar.

Y una segunda pieza que la conciliación aporta y que ninguna posición vio: **la renumeración se paga una sola vez.** El editor quería partir §3.9 (P1-4 del dictamen) y la didáctica quería insertar una sección antes del cierre; las dos mueven los mismos números. Hacerlo en dos pases deja el documento mitad corregido, que es peor que uniformemente viejo (filtro «la unidad de aplicación es el documento»). Van juntas.

### Decisión

**Sí, el apunte gana el tratamiento, repartido en cinco piezas y en un solo pase**, con este alcance exacto:

| Pieza | Dónde | Líneas | Qué contiene |
| --- | --- | --- | --- |
| **§3.9 nueva** — «¿Cuándo una jerarquía de tipos es la respuesta?» | entre el actual §3.8 y el actual §3.9 | **≈ 85** | El criterio (a), las dos fuentes, el snippet, el contraejemplo y los tres ❌ |
| **§3.10 / §3.11** | renumeración del actual §3.9 | 0 nuevas | Se aplica P1-4: «Un conjunto cerrado que de verdad esté cerrado» pasa a §3.10 y la pregunta de cierre queda sola en §3.11 |
| **Nota medida en §5.4** | al final de §5.4 | **≈ 16** | (b): la jerarquía persistida, con el esquema medido |
| **Nota medida en §7.2 d** | al final de §7.2 d | **≈ 18** | (c): la jerarquía en el contrato JSON, con las tres salidas medidas |
| **Fila nueva en §7.1** | tabla de los siete objetos | 1 | La octava fila (P0-2 del dictamen) |

Versión resultante: **v2.5.0**. Aprobada 5-0; el juez de riesgo dejó constancia de que la renumeración es el único cambio no trivialmente reversible del lote y por eso va **primero** en el orden de aplicación (§8.2).

### Fuentes: cuáles entran y cuáles no

| Fuente | ¿Está en el Anexo E? | Decisión |
| --- | --- | --- |
| **Liskov (1987)**, *Data Abstraction and Hierarchy*, OOPSLA'87 Addendum | No (B-10) | **Entra.** Cita verificada verbatim con `pdftotext` en la corrida del dictamen (§6 de `08-…`) |
| **Liskov y Wing (1994)**, *A Behavioral Notion of Subtyping* | No | **Entra sólo después del cotejo contra la edición de ACM.** El propio dictamen declara que el OCR del PDF trajo ruido tipográfico. Si el cotejo no se hace, **la sección se publica sin ella** y el puente con las *Invariants* de §3.1 queda rotulado «Criterio de esta guía» |
| **Fowler, *Replace Conditional with Polymorphism*** | El catálogo sí, con otras dos entradas (B-9) | **Entra como URL agregada a `ref-fowler-refactoring`**, no como entrada nueva. **Sin frase de motivación**: el dictamen verificó que la página no publica ninguna |
| **Fowler (2003), *AnemicDomainModel*** | Sí, `ref-fowler-2003`, ya citada en §3.6 y §9.6 | **Se reutiliza**, no se agrega: sostiene el ❌ del subtipo que sólo agrega campos |

Costo real en el Anexo E: **una entrada nueva** (Liskov 1987), **una URL agregada** a una entrada existente, y una entrada condicional (Liskov y Wing).

### (a) Cuándo una jerarquía pertenece al dominio — el criterio operativo

Éste es el texto que el apunte va a llevar, y es la respuesta a la subpregunta (a) **y** al pedido de un criterio para decidir **jerarquía contra composición**:

> **Criterio de esta guía — jerarquía o composición, en tres preguntas.**
>
> **Condición previa: la diferencia tiene que ser de comportamiento que el negocio nombra.** Si los subtipos sólo agregan campos y el cálculo vive en un `switch` de afuera, la jerarquía no está resolviendo nada: es el *Anemic Domain Model* con una capa más ([Fowler, 2003](#ref-fowler-2003)).
>
> 1. **¿Un objeto puede cambiar de variante durante su vida sin dejar de ser el mismo objeto?** Si puede, lo que varía no es *qué es* sino *cómo hace una parte de su trabajo*, y eso es **composición**. Una actividad agrícola no pasa a ser de cría; una tarifa sí puede cambiar de fórmula.
> 2. **¿Cuántos ejes varían a la vez?** Un eje admite jerarquía. Dos ejes independientes la hacen explotar —cuatro tipos por tres formas de valorizar son doce clases—, y ahí lo que varía se **inyecta**.
> 3. **¿Todo lo que vale para la base sigue valiendo para cada hoja?** Es el criterio de legitimidad, y no lo inventó esta guía.

Y la cita, con su explicación y su materialización, como manda §0.5:

> Liskov lo formuló como una propiedad de sustitución: «What is wanted here is something like the following **substitution property**: If for each object o1 of type S there is an object o2 of type T such that for all programs P defined in terms of T, the behavior of P is unchanged when o1 is substituted for o2, then S is a subtype of T» ([Liskov, 1987](#ref-liskov-1987)). **Qué implica para quien diseña**: la jerarquía no se valida mirando las clases sino mirando **los programas escritos contra la base**. Si hay un solo lugar donde el código que usa el tipo base tiene que preguntar de qué subtipo se trata para hacer bien su trabajo, ese lugar es la refutación de la jerarquía.

**Materialización** (queda `[Fragmento ilustrativo: la solución de la actividad todavía no tiene `Domain`]` hasta que A5 lo compile, y entonces pasa a `[Compilado]`):

```csharp
public abstract class ActividadProductiva
{
    public string Descripcion { get; private set; }
    // …superficie ocupada: la misma para todos, vive acá

    // Lo que varía por tipo, con la misma firma para todos:
    public abstract Dinero Produccion();
    public abstract Rendimiento Rendimiento();
}

public sealed class Agricola : ActividadProductiva
{
    public override Dinero Produccion() => PrecioTonelada * ToneladasCosechadas;
    public override Rendimiento Rendimiento() => Rendimiento.PorHectarea(ToneladasCosechadas, SuperficieOcupada());
}

public sealed class Cria : ActividadProductiva      // hoja de Ganadera, en el caso completo
{
    public override Dinero Produccion() => PrecioTernero * TernerosDestetados;
    public override Rendimiento Rendimiento() => Rendimiento.PorCienVacas(TernerosDestetados, VacasMadres);
}
```

El programa que suma no pregunta nada, y ése es el resultado de la prueba de sustitución, no una elegancia:

```csharp
// El informe de toda la estancia, sin una sola pregunta por el tipo.
Dinero total = actividades.Aggregate(Dinero.Cero, (acc, a) => acc + a.Produccion());
```

Contraejemplo, con su marca:

```csharp
// [Fragmento ilustrativo: contraejemplo]
decimal produccion = tipo switch
{
    1 => toneladas * precioTonelada,
    2 => terneros * precioTernero,
    3 => (kilosFinales - kilosIniciales) * precioKilo,
    4 => kilosLogrados * precioKilo,
    _ => 0m                       // el tipo nuevo produce 0 y nadie se entera
};
```

La operación que lleva del segundo al primero tiene nombre en el catálogo que esta guía ya cita: *Replace Conditional with Polymorphism* ([Fowler, s. f.](#ref-fowler-refactoring)).

Y los tres ❌ del cierre de la sección:

| | |
| --- | --- |
| ✅ | Jerarquía cuando cada hoja **responde distinto la misma pregunta** y el negocio le puso nombre a cada una |
| ❌ | Jerarquía **para compartir código**: heredar para no repetir un método ata dos cosas que el negocio no ató, y la que cambia primero rompe a la otra |
| ❌ | Subtipos que **sólo agregan campos** y un `switch` afuera que decide: es el *Anemic Domain Model* en su forma más visible —el subtipo existe y no hace nada— ([Fowler, 2003](#ref-fowler-2003)) |
| ❌ | Un subtipo que **rompe lo que la base prometía** (devuelve `0` donde la base promete un importe, o lanza donde la base promete responder): ahí el que se equivocó no es el que llama, es la jerarquía |

### (b) Cuando la jerarquía tiene que persistirse — medido

La respuesta ya no es prosa: el perito la midió (§7.2, B-15). El apunte incorpora esto y **nada más**:

- **EF Core 10 mapea por defecto con *table-per-hierarchy* (TPH)**: una tabla, una columna `Discriminator TEXT NOT NULL`, y **las columnas propias de cada subtipo pasan a ser NULL-ables** aunque el subtipo las exija.
- **EF Core no descubre los subtipos solo**: con `DbSet<Base>` y nada más, el modelo no valida (`InvalidOperationException: The entity type 'Actividad' cannot be instantiated because its corresponding CLR type is abstract and there is no derived entity type in the model`). Hay que registrarlos.
- Con **TPT** (`UseTptMappingStrategy()`), una tabla por tipo, sin discriminador, y las columnas propias vuelven a ser **`NOT NULL`**, con la clave foránea a la tabla base.

**El criterio que sale de la medición**, y que es la respuesta a (b):

> **Una jerarquía no se «mapea»: se declara dos veces, y la segunda declaración es un registro que el compilador no exige.** Y la elección de estrategia no es de rendimiento antes que nada: es **de quién respalda las reglas del subtipo**. Con TPH la base no puede sostener «una actividad agrícola tiene toneladas», porque esa columna tiene que admitir `NULL` para las filas de cría; la *Invariant* se queda entera en la fábrica del dominio (§3.6) y el esquema no la respalda. Con TPT el esquema sí la respalda, y se paga con una tabla por tipo y una unión por consulta. **Criterio de esta guía**: cuanto más rica es la jerarquía, **menos puede la base respaldar sus reglas**, y el respaldo se pierde de a una columna. Lo que no cambia con ninguna de las dos es dónde se declara: **afuera del dominio**, en la configuración (§5.4), y el `sha256` de L16 lo sigue comprobando.

**Decisión para la actividad (F-B, T-5 y la consulta del conductor): la actividad mapea con TPH y mide TPT en una corrida de una línea.** Fundamento, en ese orden: (i) TPH es el **default**, y la actividad no puede empezar apartándose de un default sin señal, que es lo que §9.3 y §9.8 condenan; (ii) el respaldo que TPT agregaría es el de las *Invariants* de los subtipos, y el hito A6 ya las establece en la fábrica: duplicar el respaldo no cambiaría **ninguna** decisión del lector; (iii) y la razón didáctica decisiva: **con TPH la pérdida se ve** —`"Toneladas" TEXT NULL` en el esquema generado— y con TPT no se ve nada, porque no hay nada que perder. La actividad enseña con lo que se ve fallar. El costo de mostrar las dos es `UseTptMappingStrategy()` y una captura.

Las dos posiciones de T-5 quedan resueltas así: gana A —el mapeo se sigue declarando afuera, sin cambios— **con la precisión que B pedía y que ahora está medida**: el discriminador no es como `HasMaxLength`, porque determina qué tipos pueden existir; por eso el registro de subtipos es una decisión de diseño que se declara, y no una línea de configuración más.

### (c) Cuando la jerarquía tiene que publicarse en un contrato JSON — medido

Medido en §7.1 (B-14). El hallazgo, y es el más fuerte de toda la mesa:

> **El polimorfismo no viaja. Lo que viaja es un discriminador y un registro cerrado de subtipos, declarado en el tipo base.** `System.Text.Json` serializa `{"tipo":"agricola", …}` y reconstruye el subtipo correcto al leer; pero un cuerpo **sin** discriminador falla con `NotSupportedException`, y un cuerpo con un discriminador **no registrado** —el subtipo nuevo de la Tarea 2— falla con `JsonException: Read unrecognized type discriminator id 'forestal'`.

Y de ahí salen las tres consecuencias que la actividad necesita, con su criterio:

1. **El registro es una lista paralela más, y el compilador no la exige.** Es **exactamente el mismo defecto** que la actividad denuncia en la línea de base: el combo de `FormActividadDatos.Designer.cs` l. 143, cuyo orden es parte del contrato del dominio. Con una diferencia medible, y ésa es la que forma criterio: **el combo falla en silencio** —habilita «cantidad de cabezas» para una actividad forestal (B-7)— y **el registro JSON falla a los gritos**, del lado del servidor, nombrando el discriminador que no conoce. ✅ **Criterio de esta guía**: cuando una lista paralela es inevitable, se elige la que falla ruidoso y se la cubre con una prueba que recorra los subtipos por reflexión; una lista paralela silenciosa es un defecto esperando a la próxima entrega.
2. **La jerarquía del contrato no es la del dominio.** El registro `[JsonDerivedType]` va sobre los DTO de `Contracts`, nunca sobre `ActividadProductiva`: ponerlo en el dominio mete `System.Text.Json` y una decisión de contrato adentro (§7.4). Y el discriminador es un **nombre público**: cambiarlo rompe clientes, como cualquier campo del contrato (§7.2 d).
3. **Dónde queda el único `switch` legítimo.** Si el borde ya consumió el discriminador para construir el objeto, de ahí para adentro el polimorfismo hace todo el trabajo y el *Use Case* no vuelve a preguntar. ✅ **Criterio de esta guía**: *una cadena de `is` sobre una jerarquía propia es un método que falta en la clase base — salvo en el borde donde el objeto se construye desde afuera. Ahí el `switch` no es una omisión: es la materialización del contrato, y su lugar es el serializador, una sola vez.* Eso es lo que convierte la cadena de `is` de `FormPrincipal.cs` l. 396 en un atributo declarativo, y lo que hace que el hito A5 pueda cerrar con `grep -rn ' is Agricola' src/` → vacío.

### Parches

**P-C2-a (primero de todo el lote).** Renumerar: el actual `### 3.9 Pregunta de cierre` se parte, según P1-4 del dictamen, en `### 3.10 Un conjunto cerrado que de verdad esté cerrado` y `### 3.11 Pregunta de cierre`; y las 7 remisiones vivas a `§3.9` (l. 546, 737, 1020, 1706, 2014, 2587, 2632 — todas apuntan al conjunto cerrado o al *Value Object*) pasan a `§3.10`.

**P-C2-b.** Insertar `### 3.9 ¿Cuándo una jerarquía de tipos es la respuesta?` entre §3.8 y el nuevo §3.10, con el contenido redactado arriba: respuesta en negrita primero —

> **Respuesta: cuando los subtipos se diferencian por comportamiento que el negocio nombra, no por los datos que guardan; y sólo si todo lo que vale para el tipo base sigue valiendo para cada subtipo.**

— las tres preguntas del criterio, la cita de Liskov con su explicación, el bloque de código, el `Aggregate` que no pregunta, el contraejemplo marcado y la tabla ✅/❌.

**P-C2-c.** Al final de §5.4, **después del párrafo que cierra el tratamiento de la configuración con Fluent API**, agregar la nota de (b): el esquema TPH medido, la falta de descubrimiento automático de subtipos, el contraste con TPT y el criterio «cuanto más rica la jerarquía, menos respalda la base». Con su salida registrada cuando la actividad la produzca (`Variantes/capturas/Vnn-jerarquia-efcore.txt`); hasta entonces, la medición de esta acta (§7.2) citada como corrida del expediente.

**P-C2-d.** Al final de §7.2 d, agregar la nota de (c): el discriminador, las dos formas de fallar, el criterio de la lista paralela ruidosa y el del único `switch` legítimo.

**P-C2-e.** En §7.1, **agregar** como octava fila de la tabla:

```text
| **Jerarquía de tipos** | `ActividadProductiva` → `Agricola`, `Ganadera` | ¿Qué varía según el tipo, y qué vale para todos? | Domain | cambia el conjunto de tipos, o una hoja empieza a responder distinto | hay comportamiento que difiere por tipo y el negocio le puso nombre a cada uno (§3.9) |
```

**P-C2-f.** En el Anexo E, **agregar** (orden alfabético, entre `ref-kay-1998` y `ref-luckypenny-2025`):

```text
<a id="ref-liskov-1987"></a>Liskov, B. (1987). *Data Abstraction and Hierarchy*. Addendum to the Proceedings of OOPSLA'87 (conferencia inaugural). Cita verificada sobre el PDF con `pdftotext` (consultado el 2026-09-24).
```

y **reemplazar** en `ref-fowler-refactoring` el fragmento «…y *Replace Nested Conditional with Guard Clauses*, https://refactoring.com/catalog/replaceNestedConditionalWithGuardClauses.html (consultados el 2026-09-20).» **por** «…, *Replace Nested Conditional with Guard Clauses*, https://refactoring.com/catalog/replaceNestedConditionalWithGuardClauses.html, y *Replace Conditional with Polymorphism*, https://refactoring.com/catalog/replaceConditionalWithPolymorphism.html (consultados el 2026-09-20 y el 2026-09-24). La página de esta última **no publica frase de motivación**: se la cita por su nombre y su ejemplo, no con una cita textual.»

**Verificación del lote C-2**: el script de anclas da 0 enlaces rotos y 0 remisiones inexistentes; `grep -c '§3\.9'` cuenta sólo las remisiones nuevas a la sección de jerarquías; `grep -ci 'jerarqu'` deja de dar 0; toda entrada nueva del Anexo E está citada al menos una vez desde el cuerpo.

---

## C-3. RN-13 contra CU-11

### La tensión se cerró por corrección de la fuente, no por interpretación de la mesa

El 2026-09-24, **el autor del enunciado reescribió el párrafo**. Lo viejo decía: «Cada actividad consta de una descripción, un periodo productivo y **al menos tiene asignado un lote** (una parcela de alguno de los campos de la estancia). […] **Luego se le asignan los lotes** en los que se va a desarrollar». Lo vigente dice: «Cada actividad consta de una descripción, un periodo productivo **y luego se le tiene que asignar una parcela** (una parcela de alguno de los campos de la estancia). Cada actividad productiva se agrega a la estancia indicando su periodo de vigencia y descripción». El autor precisó además que a una actividad se le asignan **una o más parcelas**, y que «estancia» se usa en el sentido rioplatense de **establecimiento agropecuario**. Está asentado en `09-Fuente-Actividad-La-Estancia.md`, «Corrección del autor, 2026-09-24» (B-12).

**Desaparece «al menos tiene asignado un lote».** Con eso, la recomendación D-01 del análisis didáctico queda **confirmada por la fuente misma**, y la mesa la registra sin atribuirse la decisión.

### Lo que la mesa asienta

1. **RN-13 no es un *Invariant* del alta.** La actividad nace con descripción y período; la asignación de parcelas es posterior y admite una o más. **CU-11 no se toca.**
2. **La regla que se hace cumplir es RN-12**: una actividad sin parcelas asignadas no se puede cerrar. Está en `Actividad.Cerrar` (`Actividad.cs` l. 70) y se muda a `ActividadProductiva.Cerrar` en el dominio de la versión nueva.
3. **RN-13 se reformula así**, y es la redacción que la actividad usa: *«A una actividad se le asignan una o más parcelas, después del alta. Describe el estado productivo; se hace cumplir en el cierre (RN-12).»*
4. **La trampa queda declarada**: nadie repone RN-13 en el repositorio ni en el endpoint. Si alguien la hace cumplir en el alta, bloquea un caso de uso que el enunciado ordena explícitamente. El `POST /api/actividades` sin parcelas devuelve **201**, y eso es correcto.
5. **Se cierra `P-02`** de la guía interactiva (§5 de `Dot-NET-Arquiectura-Interactive-Guide.md`).

### Por qué esto es un resultado del método y conviene decirlo

Lo que hizo esta cadena de documentos fue **leer un enunciado con el filtro de §3.7 del apunte** —¿vale toda la vida del objeto?, ¿mirando ese objeto solo?— y encontrar que una de sus afirmaciones no podía valer en el instante que el propio enunciado describía. **Eso es todo lo que hizo: nombró la contradicción y la devolvió a su autor.** No la resolvió por interpretación, no eligió una lectura y no reescribió la fuente. La corrigió quien podía corregirla.

Es, además, la aplicación literal del filtro de la mesa: una afirmación de la fuente no se «arregla» corrigiendo el documento que la cita, porque eso la absolvería sin que nadie vote la derogación. Se devuelve. **El apunte tiene una herramienta que detectó un defecto en un enunciado de cátedra escrito antes que él, y el autor lo corrigió en el día.** Ese hecho vale más que cualquier ejercicio inventado, y por eso la mesa lo manda al apunte como ejercicio (P1-6 del dictamen), con el caso real y el desenlace real.

### Parches

**P-C3-a.** En §9.7 del apunte, agregar el **ejercicio de transferencia 3**:

> *Ejercicio 3.* Un enunciado de un sistema para una estancia —un establecimiento agropecuario— dice, en el mismo párrafo, que «cada actividad […] al menos tiene asignado un lote» y que «cada actividad productiva se agrega a la estancia indicando su periodo de vigencia y descripción; luego se le asignan los lotes». Más adelante agrega que una actividad sin lotes no se puede cerrar. **¿«Al menos un lote» es una *Invariant*, es una *Precondition*, o sobra?** Escribí la respuesta antes de seguir.

Y en el bloque **Respuestas**:

> *Ejercicio 3.* Con la tabla del §3.7: la primera pregunta —¿vale toda la vida del objeto?— se responde **no**, porque el propio enunciado describe un instante, el del alta, en el que la actividad existe y no tiene lotes. Falla la primera condición, así que **no es una *Invariant***; es la *Precondition* del acto de cerrar, y la regla que ya la dice es «una actividad sin lotes no se puede cerrar». Hacerla cumplir en la creación bloquearía un caso de uso que el enunciado ordena. **Y el desenlace real importa más que la clasificación**: este enunciado existe, la contradicción se le señaló a su autor y el autor reescribió el párrafo. Cuando un documento se contradice a sí mismo, la respuesta no siempre es elegir una de las dos lecturas: muchas veces es **devolver la pregunta a quien puede corregir el documento**, con la contradicción señalada por escrito.

**Verificación**: el ejercicio nuevo no agrega términos al glosario ni fuentes al Anexo E; el script de anclas sigue en 0 rotos.

---

## C-4. La referencia `Infrastructure → Application`

### Posiciones

| | Posición A — se queda, declarada como apartamiento | Posición B — se saca del esqueleto |
| --- | --- | --- |
| **Quién la sostiene** | E-Arquitecto .NET | E-Edición bibliográfica, Implementador ingenuo |
| **Evidencia** | **E2**: la variante de §4.10 sí la usa (`IUnitOfWork` declarada en `Application`, `AppDbContext` la implementa); un esqueleto que no la trae no es el de una solución real | **E1**: el propio apunte publica el `grep` que prueba que nadie la usa (B-4). **E2**: §9.8, la última línea del documento, declara el control que esto incumple (B-5) |
| **Costo si gana** | El documento cierra con una regla que su único esqueleto no cumple, y lo dice | Se regenera `capturas/L08-esqueleto.txt`, cambian el Diagrama 2.1, el Diagrama 2.3 y un comando de §2.7 |

### Conciliación

Los criterios enfrentados eran **«el esqueleto tiene que parecerse a una solución real»** y **«el corpus no puede incumplir su propia regla»**. El criterio que los reemplaza sale de aplicar el filtro **descripción, control o decisión**:

> §9.8 **no es una descripción**: es un **control declarado**, y un control no ejercido no se absuelve reescribiendo el documento que lo declara. Pero tampoco se absuelve rotulando la infracción como «apartamiento»: un apartamiento es legítimo cuando **el control no se puede cumplir sin perder algo**, y acá no se pierde nada. La pregunta que decide no es «¿se declara o se saca?» sino **«¿qué le cuesta a cada opción, y qué enseña cada una?»**, y las dos partes se contestan: sacarla cuesta **una captura**, la más barata del laboratorio, y **enseña la única cosa que el apunte no puede enseñar de otra forma: la guía aplicándose su propia regla a sí misma.**

Por qué se descartó el criterio de cada rol: el del arquitecto porque confunde «esqueleto real» con «esqueleto completo» —una solución real tampoco tiene esa flecha hasta que aparece la interfaz que la pide—; el del editor porque «hay una contradicción» no alcanza para ordenar un cambio hasta que alguien cuenta lo que cuesta, y la cuenta acá es a favor.

**Un dato que la conciliación aportó y que ninguna posición había visto:** la tabla de §8.3 **no se toca**. Esa tabla dice qué **puede** referenciar cada proyecto, y `Infrastructure` **sigue pudiendo** referenciar `Application`. Lo que cambia es qué hay en el esqueleto, no qué está permitido. Confundir el permiso con la declaración era el error latente en las dos posiciones.

### Decisión

**Se saca del esqueleto de L08, y §2.7 pasa a nombrar la señal que la devuelve.** Aprobada 4-1; el voto en contra es el del juez de costo/beneficio, que sostiene que regenerar una captura contradice el presupuesto del dictamen («nada exige regenerar las capturas L00–L24»). Se resolvió con una **condición de aplicación**, que es parte de la decisión:

> **El parche no se aplica hasta que L08 se vuelva a correr y la captura nueva quede versionada**, con el mismo encuadre que la vieja. Si por cualquier motivo L08 no se puede regenerar, **el default es la posición A**: se deja la flecha y se rotula «Apartamiento declarado» con el criterio del §9.8. Un documento que afirma un grafo que su captura no muestra es peor que los dos.

### Parches

**P-C4-a.** En §2.7, **eliminar** la línea del bloque `bash`:

```bash
dotnet add src/Backend/MyProject.Infrastructure reference src/Backend/MyProject.Application
```

**P-C4-b.** En §2.7, en la salida registrada de L08, **reemplazar**:

```text
== MyProject.Infrastructure
../MyProject.Domain/MyProject.Domain.csproj
../MyProject.Application/MyProject.Application.csproj
```

**por** lo que devuelva la corrida nueva, que debe ser:

```text
== MyProject.Infrastructure
../MyProject.Domain/MyProject.Domain.csproj
```

**P-C4-c.** En el Diagrama 2.3 (§2.7) y en el Diagrama 2.1 (§2.1), **eliminar** la línea `I --> A`.

**P-C4-d.** En §2.7, **reemplazar** el párrafo que empieza «`Infrastructure` referencia también a `Application` para poder implementar las interfaces de servicios técnicos…» y termina «…el §8.2 explica cómo cortarlo si hiciera falta.» **por**:

> `Infrastructure` **no** referencia a `Application` en el esqueleto, y la ausencia es deliberada. Una solución real termina necesitando esa flecha, porque `Application` declara interfaces de servicios técnicos (§4.1) que `Infrastructure` implementa: la variante de §4.10 tiene una, `IUnitOfWork`, y su `AppDbContext` la implementa. Pero la señal que la justifica **todavía no apareció**, y el criterio de esta guía es el de su última línea: cada capa y cada referencia se agregan cuando aparece la señal, no antes (§9.8, §9.3). Declararla acá sería exactamente lo que §9.3 llama sobreingeniería —una flecha que no trabaja— y el laboratorio tendría que convivir con una regla que el propio documento incumple en su único esqueleto. **Cuándo se agrega, en una línea: con la primera interfaz de `Application` que `Infrastructure` tenga que implementar.** La tabla de §8.3 no cambia por esto: esa tabla dice lo que cada proyecto **puede** referenciar, y `Infrastructure` puede; el grafo de L08 dice lo que **hay**. Las referencias de .NET son **transitivas**: la WebAPI puede usar tipos de `Domain` sin referenciarlo, porque lo alcanza a través de `Application`. El §8.2 explica cómo cortarlo si hiciera falta.

**Verificación del parche**: `dotnet list src/Backend/MyProject.Infrastructure reference` devuelve una sola línea; `dotnet build` sigue dando `Build succeeded` con `0 Warning(s)`; el Diagrama 2.3 y la salida registrada muestran el mismo grafo; y `grep -n 'Apartamiento' ` no agrega ninguna aparición nueva.

---

## C-5. Las tres decisiones de construcción

### (a) El cliente y su evidencia

**Restricción dura, verificada**: `net9.0-windows7.0` con `UseWindowsForms` (`Ejercicio1.csproj`) necesita el paquete de destino de Windows Desktop, que no está en Linux; en este equipo no hay SDK fuera del contenedor. **Ni el cliente WinForms nuevo ni la línea de base compilan acá.**

**Posiciones.** A (E-Didáctica): reutilizar los WinForms, porque es lo único que hace honesta la comparación de la Tarea 2. B (Verificación/QA): nada que no se ejecutó lleva marca de ejecutado; si el cliente no compila, la evidencia de A8 y A9 no existe y hay que hacer un cliente de consola.

**Conciliación.** Los dos criterios eran **«comparar lo mismo»** y **«no afirmar lo que no se corrió»**, y se estaban peleando por una premisa falsa que ninguno enunció. La pregunta que lo desbloquea: **¿qué necesita A9 exactamente?** No necesita ejecutar nada. Necesita **contar puntos de toque y decir cuántos de ellos exige el compilador**. Y hay un precedente dentro de la propia corrida que lo demuestra: **toda la tabla de las 18 reglas de la línea de base se midió por lectura**, citada con archivo y línea, y la comisión de didáctica lo declaró —«ninguna afirmación de esta comisión depende de compilarlo»—. Si ese método fue bueno para medir el punto de partida, es bueno para medir el punto de llegada, **siempre que la asimetría se declare y no se disfrace**.

> **Dicho explícitamente, como el conductor pidió: la decisión NO depende de poder ejecutar el cliente WinForms, y tampoco de poder compilarlo.** La comparación de la Tarea 2 no se da por perdida. Lo único que se pierde si nadie lo corre en Windows es la posibilidad de **verificar con el compilador** la columna «¿lo exige el compilador?» del lado del cliente visual — y esa columna, en la línea de base, tampoco se verificó con el compilador: se leyó.

**Decisión: dos clientes, con dos papeles declarados, y ninguno mintiendo.**

| Cliente | Papel | Marca de su evidencia |
| --- | --- | --- |
| **`LaEstancia.ClienteConsola`** (`net10.0`) | Es el cliente **compilado y capturado** de la actividad, como L22 del apunte. Toda salida `[Compilado]` y toda «Salida registrada» de A8 sale de él | las del apunte |
| **Cliente WinForms** (`net9.0-windows`), reusando los formularios de la línea de base | Es el que hace honesta la Tarea 2, porque es **el mismo cliente** que el original. Se escribe y **se mide por lectura**, con archivo y línea | **`[No compilado: net9.0-windows con UseWindowsForms necesita Windows Desktop; en este equipo sólo hay SDK en contenedor Linux]`** — marca nueva, se agrega a la tabla del §0.3 de la actividad |

Y tres condiciones duras que la mesa impone:

1. **El conteo de A9 se publica en tres columnas** —puntos de toque, cuántos exige el compilador, y **cómo se determinó cada uno** (corrida o lectura)—, con la fila del cliente WinForms marcada como leída en las dos versiones. La tesis del §4 se sostiene o se cae con lo que sí se compila: `Domain`, `Application`, `Contracts` y `WebAPI`, que son `net10.0` y corren acá.
2. **Ninguna captura de pantalla ni salida de ejecución de WinForms** entra al documento. Si el PO lo corre en Windows, la evidencia entra después y la marca cambia; hasta entonces no se insinúa.
3. **La sección que lo declara va antes del primer hito que lo usa**, no en una nota al pie. Una limitación de medio que aparece al final se lee como excusa.

**Parche P-C5-a.** En `Dot-NET-Arquiectura-Interactive-Guide.md` §0.3, **agregar** a la tabla de marcas, después de la fila `[Leído: ruta]`:

```text
| **[No compilado: motivo]** | El código existe y se cita por archivo y línea, pero no se compiló en este entorno; el motivo se declara. Lo que se afirme sobre él sale de leerlo, igual que lo que se afirma de la versión de escritorio |
```

**Parche P-C5-b.** En la tabla de **Preguntas abiertas** (§5), **reemplazar** la fila `P-04` («¿La actividad usa persistencia o se mantiene en memoria…?») por su cierre:

```text
| P-04 | ¿La actividad usa persistencia? | ✅ **Cerrada 2026-09-24 por decisión del autor: SQLite.** El mapeo de la jerarquía de actividades es TPH, con una corrida que mide TPT (acta de mesa, C-2 b) |
```

y **reemplazar** la fila `P-02` por su cierre:

```text
| P-02 | ¿El invariante de «al menos un lote» es del alta o del cierre? | ✅ **Cerrada 2026-09-24 por corrección de la fuente.** El autor reescribió el párrafo: la actividad nace con descripción y período, y se le asignan una o más parcelas después. Se hace cumplir en el cierre (RN-12) |
```

### (b) Minimal APIs o controllers

**Posiciones.** A (E-Arquitecto): minimal APIs con clases de extensión, porque el `Program.cs` de la actividad ya está armado así (`// app.MapProductosEndpoints();`). B (Verificación/QA): controllers, porque el apunte midió su comportamiento con `--use-controllers` y el 400 automático de L19 no se puede dar por repetido.

**Conciliación.** El criterio de B no era «controllers son mejores» sino **«no repitas una medición que no hiciste»**, y ése es correcto y no se discute. El de A era «no cambies lo que ya está armado sin señal», que también. El criterio que los reemplaza: **la diferencia entre las dos formas no es un obstáculo de la actividad, es contenido de la actividad** — y para que lo sea hay que medirla, no suponerla. La mesa la mandó a medir **antes de decidir**, que es lo que el filtro «el peritaje cambia una sola variable» pide, y el perito volvió con esto (§7.3, B-16):

| Situación | Respuesta medida |
| --- | --- |
| Minimal API, `AddProblemDetails()`, JSON mal formado, `Development` | `400 application/problem+json`, `"title":"Microsoft.AspNetCore.Http.BadHttpRequestException"`, **sin diccionario `errors`**, y con la **excepción entera** —traza, encabezados y ruta— dentro del cuerpo |
| Minimal API, **sin** `AddProblemDetails()`, `Production` | `400 Bad Request` con **`Content-Length: 0`**: ni cuerpo, ni motivo, ni nada |
| Controller con `[ApiController]` (L19 del apunte, ya medido) | `400 application/problem+json` **con `"errors"`**, automáticamente |

**Decisión: minimal APIs, con los endpoints agrupados en clases de extensión por concepto, y con dos obligaciones que la medición impuso.**

1. **`builder.Services.AddProblemDetails()` es obligatorio** en el `Program.cs` de la actividad. Sin eso, el borde de la actividad **no dice nada** cuando no puede: un `400` con cuerpo vacío. Es la pregunta que la mesa se hace siempre —*¿qué dice el sistema cuando no pudo?*— contestada con una medición.
2. **El `DomainExceptionHandler` de §5.6 sigue haciendo falta igual**, y por el mismo motivo que con controllers: nadie traduce una regla de negocio por vos.

Y la precisión que la medición le devuelve al apunte, que es un hallazgo de esta mesa: **el 400 automático por JSON mal formado no lo produce `[ApiController]`, lo produce el enlace de parámetros**; lo que `[ApiController]` agrega es el cuerpo con `errors` por campo. La fila de §5.6 que dice «Quién la produce: `[ApiController]`, automáticamente» es imprecisa. No es falsa en su contexto —ahí hay un controller— pero induce a creer que sin el atributo no hay 400, y no es así. Va como parche menor (§8.3, D-3).

Y una señal de seguridad que apareció sin buscarla, y que la mesa registra en lugar de reconvocar: con `AddProblemDetails()` en `Development`, **la traza completa viaja dentro del `problem+json`**, no sólo en la página del desarrollador. El apunte ya advierte sobre esa página en §5.6; la advertencia hay que extenderla al cuerpo de la respuesta. Va en el mismo parche menor.

**Parche P-C5-c.** En `Interactive-Activities/src/Backend/LaEstancia.WebAPI/Program.cs`, **agregar** después de `builder.Services.AddOpenApi();`:

```csharp
// Sin esto, un JSON mal formado devuelve 400 con el cuerpo vacío: el borde no dice por qué.
builder.Services.AddProblemDetails();
```

**Parche P-C5-d.** En el documento de la actividad, declarar en una línea que las clases de extensión de endpoints ocupan el mismo círculo que los controllers del apunte —*Interface Adapters*, §2.1— y que `Program.cs` sigue siendo el composition root.

### (c) `UseHttpsRedirection`

**Decisión: se saca del `Program.cs` de la actividad.** Unánime, 5-0.

Tres fundamentos, en orden de peso, y el segundo es el que el pedido pidió fundar:

1. **La evidencia deja de ser legible.** Los `curl` de A1, A2 y A9 son la verificación de esos hitos y devolverían `307` antes de tocar un endpoint. El apunte ya había resuelto lo mismo creando su WebAPI con `--no-https`.
2. **Y lo que implica para un cliente que corre en contenedor, que es el caso de esta actividad.** La redirección manda al cliente a un puerto TLS con un certificado de desarrollo que **no está en el almacén de confianza del contenedor**. El cliente no falla por el caso de uso: falla validando un certificado. Y hay exactamente dos salidas, las dos malas: importar el certificado en cada contenedor, que es infraestructura que la actividad no enseña; o **desactivar la validación** en el `HttpClientHandler`, que es una línea que después se copia a producción. ✅ **Criterio de esta guía: en desarrollo se elige el transporte más simple que no obligue a desactivar una verificación de seguridad. Una redirección que sólo se puede seguir apagando una comprobación enseña a apagarla, y eso es lo que se va a copiar.**
3. **No protege nada acá.** No hay credenciales ni datos personales en el laboratorio, y el tráfico es `127.0.0.1`. El middleware está cumpliendo una ceremonia, no un control.

Y la contracara, que va escrita para que sacarlo no enseñe lo contrario: **en producción vuelve**, y la actividad lo dice donde lo saca.

**Parche P-C5-e.** En `Interactive-Activities/src/Backend/LaEstancia.WebAPI/Program.cs`, **reemplazar**:

```csharp
app.UseHttpsRedirection();
```

**por**:

```csharp
// En desarrollo no se redirige a HTTPS: los curl de los hitos devolverían 307 y, sobre todo,
// un cliente en contenedor tendría que desactivar la validación del certificado para seguir
// la redirección. En producción esta línea vuelve, con un certificado de verdad.
```

**Verificación de (b) y (c)**: `curl -s -o /dev/null -w '%{http_code}' http://127.0.0.1:5250/openapi/v1.json` devuelve `200` y no `307`; y `curl -i -X POST … -d '{"nombre":}'` devuelve `400` con `application/problem+json` y cuerpo no vacío.

---

## C-6. La escalera del §9.2 y la aplicación de escritorio

### Posiciones

| | A — se agrega un escalón | B — se ensanchan los existentes | C — fuera de alcance |
| --- | --- | --- | --- |
| **Tesis** | La línea de base no encaja en ninguno y hay que darle su lugar | El problema no es que falte un escalón: es que el escalón 1 nombra una tecnología en lugar de una estructura | El apunte es sobre soluciones con servidor; el escritorio es otra guía |
| **Evidencia** | **E2**: escalón 1 = «Página → EF Core», y la línea de base no tiene página web, ni EF Core, ni base | **E1/E2**: la línea de base es un *Domain Model* con comportamiento en **un solo proyecto** y sin persistencia (`Actividad.cs` l. 21–58, `Estancia.cs` l. 151–181); eso falsifica que el escalón 1 sea *Transaction Script* | **E2**: §0.1 declara el alcance |

### Conciliación

El criterio de A era **«todo caso real tiene que tener su casillero»** y el de C **«el alcance manda»**; los dos son correctos y ninguno sirve. El criterio que los reemplaza, y que contradice a las tres posiciones incluida B en su formulación original:

> **La escalera cuenta piezas separadas; la tecnología y el lugar donde corre el proceso son otros dos ejes, y meterlos en los peldaños es lo que rompe el mapa.** Agregar un escalón para el escritorio sería peor que no tener ninguno, porque sugeriría que una aplicación de escritorio es **un estadio más bajo** de la misma escalera, y es falso: **una aplicación de escritorio puede estar parada en cualquiera de los cuatro escalones.** Lo que cambia en el caso de La Estancia no es cuántas capas tiene —tiene una— sino **dónde corre el proceso**, y eso pertenece al mapa de escenarios del §9.1, que ya está organizado por situaciones y no por estructuras.

Y el dato que lo decide, medido: **la línea de base es un contraejemplo del escalón 1 tal como está escrito hoy.** Tiene un proyecto y tiene un *Domain Model* con comportamiento — las dos cosas a la vez. Si el escalón 1 se llama «*Transaction Script* con EF Core», entonces un caso real que la guía misma analiza no entra en su propia escalera. El peldaño tiene que nombrar **la estructura**, que es lo único que la escalera ordena.

### Decisión

**No se agrega un escalón. Se renombra el escalón 1 para que nombre la estructura y no la tecnología, se agrega una fila E-E al mapa del §9.1, y se declara bajo el diagrama qué es lo que la escalera cuenta.** Aprobada 5-0. Los escalones 2, 3 y 4 no se tocan.

### Parches

**P-C6-a.** En el Diagrama 9.1 (§9.2), **reemplazar**:

```text
    S1["1. Página → EF Core<br/>un proyecto"]
```

**por**:

```text
    S1["1. Un proyecto<br/>pantalla → servicio → almacenamiento"]
```

**P-C6-b.** En §9.2, **después** de la línea que empieza «*Diagrama 9.1. Cada flecha es una señal observable…*», **agregar**:

> **Qué cuenta la escalera, y qué no. Criterio de esta guía**: los peldaños cuentan **piezas separadas**, no tecnología. El almacenamiento es un eje aparte —un escalón 1 puede no tener base de datos— y dónde corre el proceso es un tercero: una aplicación que corre en la máquina del usuario puede estar parada en cualquiera de los cuatro escalones, y eso se decide en el mapa del §9.1, no acá. De ahí se sigue algo que conviene decir porque el reflejo empuja al revés: **tener un modelo con comportamiento no obliga a subir de escalón.** Se sube cuando una regla se repite, cuando no cabe en ningún objeto, o cuando aparece un segundo consumidor; no por tener buenas clases.

**P-C6-c.** En la tabla del §9.1, **agregar** después de la fila E-D:

```text
| **E-E** una aplicación que corre en la máquina del usuario (escritorio o móvil), con su modelo en memoria y sin servidor | Un proyecto: pantalla → modelo; el almacenamiento, si aparece, es un archivo o una base local | 1, y el modelo puede tener comportamiento desde el primer día | §9.2, §9.3, §6.4 | Aparece un segundo consumidor de las mismas reglas —otra máquina, un proceso por lotes, una API—: lo que la pantalla decidía no viaja (§2.3) |
```

**P-C6-d (nota, no parche).** El §2.8 y el §8.6 siguen hablando del «escenario E-A en el escalón 1» con su «página → servicio → EF Core»: **no se tocan**, porque ahí la tecnología es del escenario E-A, que sí es una aplicación Blazor en el servidor. Lo que se corrigió es el nombre del peldaño, no el de los escenarios.

**Verificación del parche**: `grep -n 'Página → EF Core'` no devuelve nada; la tabla de §9.1 pasa de cinco filas a seis; el script de remisiones sigue en 0 inexistentes; y la fila E-E se puede contrastar contra un caso real —la línea de base de La Estancia— que ahora entra en el mapa sin forzarlo.

---

## 7. Anexo de peritajes: las tres corridas

Las tres corrieron el **2026-09-24** en `mcr.microsoft.com/dotnet/sdk:10.0`, con el repositorio **sin tocar**: los programas viven en el directorio temporal de la sesión y están transcritos acá enteros para que se puedan rehacer. **Cuando los parches se apliquen, estas corridas se rehacen dentro del laboratorio de la actividad y sus capturas se versionan ahí**; una afirmación con una captura en un temporal no cierra nada.

### 7.1 P-1 · Una jerarquía cruzando `System.Text.Json` 10

```csharp
[JsonPolymorphic(TypeDiscriminatorPropertyName = "tipo")]
[JsonDerivedType(typeof(CierreAgricola), "agricola")]
[JsonDerivedType(typeof(CierreCria), "cria")]
public abstract class CierreDatos { }
public sealed class CierreAgricola : CierreDatos { public decimal Toneladas { get; set; } public decimal PrecioTonelada { get; set; } }
public sealed class CierreCria : CierreDatos { public int VacasMadres { get; set; } public int TernerosDestetados { get; set; } public decimal PrecioTernero { get; set; } }
```

Salida verbatim:

```text
1. Serializado (base declarada): {"tipo":"agricola","Toneladas":120.5,"PrecioTonelada":250}
2. Deserializado, tipo en tiempo de ejecucion: CierreAgricola
3. Cria deserializada: CierreCria
4. Sin discriminador -> NotSupportedException: The JSON payload for polymorphic interface or abstract type 'CierreDatos' must specify a type discriminator. Path: $ | LineNumber: 0 | BytePositionInLine: 13.
5. Discriminador desconocido -> JsonException: Read unrecognized type discriminator id 'forestal'. Path: $ | LineNumber: 0 | BytePositionInLine: 28.
```

**Cómo leerla.** (1) y (2) son el mecanismo funcionando: el discriminador sale y vuelve, y el tipo se reconstruye. (4) es la razón por la que el polimorfismo **no viaja solo**: sin discriminador no hay forma de saber qué construir, y falla. (5) es el caso de la Tarea 2: agregar un subtipo y olvidarse del registro **no es un error de compilación**, es un `JsonException` en producción con el nombre del discriminador que nadie declaró.

### 7.2 P-2 · La misma jerarquía en EF Core 10 sobre SQLite

Con `DbSet<Actividad>` y nada más, el modelo **no valida**:

```text
System.InvalidOperationException: The entity type 'Actividad' cannot be instantiated because its
corresponding CLR type is abstract and there is no derived entity type in the model that corresponds
to a concrete CLR type. Add a concrete derived entity type to the model or change the entity type to
use a concrete CLR type.
```

Registrados los subtipos (`b.Entity<Agricola>(); b.Entity<Cria>();`), **estrategia por defecto, TPH**:

```sql
CREATE TABLE "Actividades" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Actividades" PRIMARY KEY AUTOINCREMENT,
    "Descripcion" TEXT NOT NULL,
    "Discriminator" TEXT NOT NULL,
    "Toneladas" TEXT NULL,
    "PrecioTonelada" TEXT NULL,
    "Terneros" INTEGER NULL,
    "PrecioTernero" TEXT NULL
);
```

Con `b.Entity<Actividad>().UseTptMappingStrategy()`, **TPT**:

```sql
CREATE TABLE "Actividades" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Actividades" PRIMARY KEY,
    "Descripcion" TEXT NOT NULL
);
CREATE TABLE "Agricola" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Agricola" PRIMARY KEY,
    "Toneladas" TEXT NOT NULL,
    "PrecioTonelada" TEXT NOT NULL,
    CONSTRAINT "FK_Agricola_Actividades_Id" FOREIGN KEY ("Id") REFERENCES "Actividades" ("Id") ON DELETE CASCADE
);
CREATE TABLE "Cria" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Cria" PRIMARY KEY,
    "Terneros" INTEGER NOT NULL,
    "PrecioTernero" TEXT NOT NULL,
    CONSTRAINT "FK_Cria_Actividades_Id" FOREIGN KEY ("Id") REFERENCES "Actividades" ("Id") ON DELETE CASCADE
);
```

Y en las dos, leyendo por el tipo base, el polimorfismo funciona:

```text
leido: Agricola -> Produccion() = 25000.00
leido: Cria -> Produccion() = 24600.0
```

**Cómo leerla.** La diferencia que decide no es el número de tablas: es **`NULL` contra `NOT NULL`**. Con TPH la base no puede exigir que una agrícola tenga toneladas, porque esa columna la comparten las filas de cría; con TPT sí. Y las columnas `TEXT` para `decimal` son lo que el apunte ya documenta de SQLite (§5.3), no una sorpresa.

### 7.3 P-3 · El 400 automático sin `[ApiController]`

Minimal API `app.MapPost("/api/productos", (CrearProductoCommand cmd) => …)`, JSON mal formado `{"nombre":"Mate","precio":}`:

```text
HTTP/1.1 400 Bad Request
Content-Type: application/problem+json

{"type":"https://tools.ietf.org/html/rfc9110#section-15.5.1",
 "title":"Microsoft.AspNetCore.Http.BadHttpRequestException","status":400,
 "detail":"Failed to read parameter \"CrearProductoCommand cmd\" from the request body as JSON.",
 "exception":{"details":"…System.Text.Json.JsonException: '}' is an invalid start of a value…",
 "headers":{…},"path":"/api/productos"}, "traceId":"…"}
```

La misma petición **sin** `builder.Services.AddProblemDetails()` y con `ASPNETCORE_ENVIRONMENT=Production`:

```text
HTTP/1.1 400 Bad Request
Content-Length: 0
```

**Cómo leerla.** El `400` existe sin `[ApiController]`: lo produce el enlace de parámetros. Lo que **no** existe es el diccionario `errors` por campo, y lo que aparece de más en `Development` es la excepción entera dentro del cuerpo. Y sin `AddProblemDetails()` el borde se queda mudo: `Content-Length: 0`.

---

## 8. Cierre

### 8.1 Tabla de decisiones

| # | Cuestión | Decisión | Alcance |
| --- | --- | --- | --- |
| **C-1** | Dónde vive `IProductoRepository` | **Se queda en `Domain`; se declara la divergencia con Martin** | 4 parches: fila de §2.1, párrafo nuevo en §2.1, celda de §4.4, entrada de Martin en el Anexo E. **Sin cita textual de Martin** (no verificada) |
| **C-2** | ¿El apunte gana las jerarquías? | **Sí, repartido: el criterio a §3 y los mecanismos a §5.4 y §7.2 d**, en un solo pase con la renumeración | §3.9 nueva (≈85 líneas), §3.9→§3.10/§3.11 con 7 remisiones, nota en §5.4 (≈16), nota en §7.2 d (≈18), fila 8 en §7.1, Anexo E +1 entrada y +1 URL. **v2.5.0** |
| — | (a) ¿cuándo la jerarquía es del dominio? | **Criterio de tres preguntas + Liskov**, redactado | Condición previa (comportamiento que el negocio nombra) + cambio de variante + cantidad de ejes + sustitución |
| — | (b) ¿y al persistirla? | **TPH para la actividad; TPT medido en una corrida.** El mapeo sigue afuera del dominio | Criterio: cuanto más rica la jerarquía, menos respalda la base; el respaldo se pierde de a una columna |
| — | (c) ¿y en el contrato JSON? | **El polimorfismo no viaja: viaja un discriminador y un registro cerrado**, declarado en `Contracts` | Criterio de la lista paralela ruidosa + el único `switch` legítimo vive en el borde |
| **C-3** | RN-13 contra CU-11 | **Cerrada por corrección de la fuente, 2026-09-24. Confirma la recomendación D-01**: RN-13 no es *Invariant* del alta; se hace cumplir RN-12; CU-11 no se toca | RN-13 reformulada; `P-02` de la actividad cerrada; el caso real entra como ejercicio 3 del §9.7 |
| **C-4** | `Infrastructure → Application` | **Se saca del esqueleto de L08**, con §2.7 nombrando la señal que la devuelve | 4 parches + regenerar `L08`. **Condición**: si L08 no se puede regenerar, el default es dejarla y rotularla apartamiento. §8.3 **no se toca** |
| **C-5 (a)** | El cliente y su evidencia | **Dos clientes: consola compilado y capturado; WinForms medido por lectura, con marca `[No compilado: motivo]`.** La comparación de la Tarea 2 **no** depende de ejecutar ni compilar el WinForms | Marca nueva en §0.3 de la actividad; conteo de A9 en tres columnas; prohibido insinuar ejecución |
| **C-5 (b)** | Minimal APIs o controllers | **Minimal APIs con clases de extensión**, con `AddProblemDetails()` **obligatorio** y el `DomainExceptionHandler` de §5.6 | Medido: sin `AddProblemDetails()`, `400` con cuerpo vacío. Devuelve al apunte una imprecisión de §5.6 |
| **C-5 (c)** | `UseHttpsRedirection` | **Se saca**, con el comentario que explica por qué y que en producción vuelve | Criterio: no se elige un transporte que obligue a desactivar una verificación de seguridad |
| **C-6** | La escalera y el escritorio | **No se agrega escalón: se renombra el 1, se declara qué cuenta la escalera y se agrega E-E al §9.1** | 3 parches. §2.8 y §8.6 no se tocan |

**Ninguna decisión quedó empatada.** Los dos votos no unánimes son C-4 (4-1) y la instanciación del conciliador (4-1), y los dos se resolvieron con una condición escrita, no con un desempate del presidente.

### 8.2 Orden en que hay que aplicar los parches

El orden no es arbitrario: está armado para que ningún parche pise a otro y para que la renumeración se pague una sola vez.

| # | Parche | Por qué va acá | Verificación antes de seguir |
| --- | --- | --- | --- |
| 1 | **P-C2-a** — renumerar §3.9 → §3.10 / §3.11 y sus 7 remisiones | Es el único cambio que mueve identificadores; todo lo demás se escribe contra la numeración nueva | script de anclas: 0 rotos, 0 remisiones inexistentes |
| 2 | **P-C2-b** — §3.9 nueva | Ocupa el número que quedó libre | `grep -ci 'jerarqu'` deja de dar 0 |
| 3 | **P-C2-f** — Anexo E (Liskov 1987; URL de *Replace Conditional with Polymorphism*) | La sección nueva ya la cita | 0 entradas del Anexo E sin citar |
| 4 | **P-C2-e** — fila 8 de §7.1; **P-C2-c** §5.4; **P-C2-d** §7.2 d | Remiten a §3.9, que ya existe | remisiones resueltas |
| 5 | **P-C1-a/b/c/d** — la divergencia del Repository | Toca §2.1 y §4.4, que ningún parche anterior movió | `grep -c 'Criterio de esta guía'` = 17 |
| 6 | **P-C6-a/b/c** — la escalera y E-E | Independiente; va antes que C-4 porque C-4 cambia una captura y conviene cerrar el texto primero | §9.1 con seis filas; `grep -n 'Página → EF Core'` vacío |
| 7 | **Regenerar `capturas/L08-esqueleto.txt`** | **Es la condición de C-4**: sin la captura nueva, los parches de C-4 no se aplican | `dotnet build` → `Build succeeded`, `0 Warning(s)` |
| 8 | **P-C4-a/b/c/d** | Ya con la captura en la mano | `dotnet list … reference` con una sola línea; diagramas y salida coincidiendo |
| 9 | **P-C3-a** — ejercicio 3 del §9.7 | Cierra el apunte; no depende de nada anterior | script de anclas |
| 10 | **Versionar el apunte como v2.5.0** y actualizar su control de cambios | El corpus queda uniforme, no mitad corregido | `last_review` y `version` en el frontmatter |
| 11 | **P-C5-a/b** — la guía interactiva: marca nueva, P-02 y P-04 cerradas | Otro documento; va después de que el apunte esté entero | lectura |
| 12 | **P-C5-c/d/e** — `Program.cs` de la actividad | Es código; va último porque su verificación es una corrida | `curl` de `/openapi/v1.json` → `200`, no `307`; `400` con cuerpo no vacío |

### 8.3 Deuda declarada

| Id | Qué | Por qué se asume |
| --- | --- | --- |
| **D-1** | **La ubicación de los gateways en Martin (2017) se cita sin apartado y sin texto literal.** El ejemplar no estuvo a la vista | La mesa no inventa citas. El parche de C-1 funciona igual, porque lo que declara es la elección de esta guía. Cuando el libro esté a la vista, se agrega el capítulo y, si corresponde, la cita |
| **D-2** | **Liskov y Wing (1994) no entra hasta el cotejo contra la edición de ACM** | El dictamen declaró ruido tipográfico del OCR. Si no se coteja, §3.9 se publica sólo con Liskov (1987) y el puente con las *Invariants* va rotulado como criterio propio |
| **D-3** | **§5.6 atribuye a `[ApiController]` un 400 que produce el enlace de parámetros**, y su advertencia sobre la página del desarrollador no cubre el caso en que la traza viaja dentro del `problem+json` | Es una imprecisión, no un error; el parche es de dos líneas y no bloquea la fase interactiva. Va al primer ciclo con presupuesto, con la corrida de §7.3 como evidencia |
| **D-4** | **TPT no se mide dentro del laboratorio del apunte**, sólo en la corrida de esta acta | El apunte no tiene ninguna variante que mapee una jerarquía. Hasta que A7 la produzca, §5.4 cita la corrida del expediente y no una captura versionada del laboratorio |
| **D-5** | **El cliente WinForms de la actividad no se compila ni se ejecuta en este equipo** | Declarado en C-5 (a) con su marca. Se levanta el día que alguien lo corra en Windows y versione la evidencia |
| **D-6** | **Las tres corridas del §7 viven en un directorio temporal** | Están transcritas enteras acá para poder rehacerse, pero **no son capturas versionadas**. Se rehacen dentro del laboratorio de la actividad cuando los hitos A5 y A7 las necesiten |

### 8.4 Lo que la mesa **no** pudo resolver con la evidencia disponible

Una sola cosa, y no es una de las seis cuestiones: **el texto literal de Martin (2017) sobre dónde van los gateways** (D-1). La decisión de C-1 no depende de él —depende de que la regla de dependencia no desempate, que sí está medido— pero la redacción del parche quedó deliberadamente sin comillas por eso, y está dicho en el propio parche.

### 8.5 Preguntas al Product Owner, en lote

Ninguna de las seis cuestiones sale como pregunta: las seis están decididas. Lo que sale es una sola, y es de alcance.

```yaml
escalada:
  id: ESC-001
  disparador: 3 — cambio de alcance
  pregunta: ¿El apunte pasa a v2.5.0 con el capítulo 3 renumerado, o la fase interactiva
    arranca contra la v2.4.0 y el apunte se edita después?
  contexto: |
    C-2 agrega una sección al capítulo 3 y mueve la numeración de dos secciones y siete
    remisiones. Es el único cambio del lote que no es local y el único que obliga a que
    cualquier documento que cite §3.9 se revise. La mesa decidió el contenido; lo que no
    puede decidir sola es si el apunte cambia de versión antes de que la actividad empiece
    a citarlo, porque eso toca lo que la guía promete a quien ya la está leyendo.
  opciones:
    - id: A
      descripción: Se aplica todo el lote ahora y el apunte queda en v2.5.0 antes de A0
      consecuencia: La actividad cita numeración estable desde el primer hito; el costo se
        paga una vez
    - id: B
      descripción: La actividad arranca contra v2.4.0 y el lote se aplica después
      consecuencia: Los hitos A5 y A7 van a citar secciones que todavía no existen, y la
        renumeración se paga con la actividad ya escrita, que es cuando más cuesta
  recomendación_de_la_mesa: A, 5-0. El filtro es el de siempre: un documento mitad corregido
    es peor que uno uniformemente viejo, y acá el «documento» son los dos.
  si_no_respondés: Se aplica A. El lote se ejecuta en el orden del §8.2, el apunte queda en
    v2.5.0 y esta acta queda como el registro de por qué.
```

### 8.6 Rendimiento del panel, medido

| Rol | Cuestiones donde aportó una posición que sobrevivió al cierre |
| --- | --- |
| E-Arquitecto .NET | C-1, C-4, C-5 (b) |
| E-Didáctica | C-2 (a), C-5 (a), C-6 |
| E-Edición bibliográfica | C-1, C-2 (fuentes), C-4 |
| Verificación / QA | C-5 (a), C-5 (b), la condición de aplicación de C-4 |
| Implementador ingenuo | C-4, C-6 |
| Refutador | C-1 (posición B), y el ataque al costo que forzó la condición de C-4 |
| **AH-001 Perito** | C-2 (b), C-2 (c), C-5 (b) — **las tres únicas afirmaciones del lote que pasaron de conjetura a E1** |
| **AH-002 Conciliador** | C-1, C-4, C-6 — **en las tres, el criterio que cerró no era el de ninguna de las posiciones** |

**Lo que esto le devuelve al Reporte `23`.** Es su segunda corrida medida. El resultado: de seis cuestiones, **tres se resolvieron con un criterio que ninguna posición había propuesto**, y en una (C-6) el criterio contradijo a las tres posiciones en juego. Sin el rol, el desenlace probable de C-4 era el que el reporte describe —gana quien decide último y nadie escribe por qué—, y el de C-6 era agregar un escalón que habría enseñado algo falso. La línea que explica todo el resto, en cada caso, es la que quedó escrita bajo **Conciliación**: exactamente lo que §4.3 del reporte pedía.

---

*Acta cerrada el 2026-09-24. Ningún archivo fuera de esta ruta fue modificado. Los doce parches están redactados para aplicarse en el orden del §8.2, y el primero que se aplique es el que mueve la numeración.*
