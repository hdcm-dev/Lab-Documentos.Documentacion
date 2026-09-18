# Mesa, ciclo 1 — Informe del especialista en edición de material bibliográfico técnico

**Fecha:** 2026-09-18
**Rol:** E-Edición bibliográfica (catálogo variable, convocado 5-0)
**Objeto:** `/LAB/Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md` (commit 063f4e9, 1003 líneas) y el plan `OUTPUTs/Nucleos/` (NC-00..NC-10)
**Mandato:** estructura jerárquica, índice, registro técnico no coloquial, voz uniforme, terminología unívoca, citas y referencias verificables, frontmatter y glosario. Propuesta de la arquitectura editorial del entregable y de la norma de citas.
**Normas aplicadas:** Estilo-Redaccion-Explicativo (§3, §4, §6, §7); Profile Study-Guide-Documentation; Rule-Markdown, Rule-Documentation, Rule-Evidences, Rule-Dual-Audience, Rule-Narrative-Voice; restricciones duras del contrato de entrada.
**Trabajo a ciegas:** no se leyeron otros informes de `Ciclo-1/`.

---

## 1. Chequeos mecánicos corridos

Script Python sobre el archivo de la guía (encabezados fuera de bloques de código, slug estilo GitHub, búsqueda literal de términos). Resultado reproducible:

| Chequeo | Resultado |
|---|---|
| Anclas del índice (13) | 13 de 13 resuelven |
| Encabezados | 1 `#`, 15 `##`, 22 `###`; ningún `####` |
| `##` sin número | `## Índice` (l. 8) y `## Resumen de Decisiones Tecnológicas` (l. 989) |
| `###` numerados | 0 de 22 |
| «Contrato/contrato» | 7 apariciones, líneas 98, 185, 272, 324, 423, 424, 683, con cinco sentidos distintos (H-04) |
| Registro coloquial | «boilerplate» (654, 1002), «arruina» y «ahorrar un viaje» (985), «es fundamental» (28), «La distinción crítica» (807), «la capa más importante» (612), «❌ MAL / ✓ BIEN» (810, 813) |
| Emojis en diagramas y tablas | 💛 ⚙️ 🔌 🌐 en líneas 210–216 y 245–248 |

Fuentes externas consultadas para este informe (2026-09-18):

- Martin, R. C. (2012-08-13). *The Clean Architecture*. https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html — confirma título, autor, fecha, el enunciado literal de la regla de dependencia («Source code dependencies can only point inwards») y los cuatro círculos (Entities, Use Cases, Interface Adapters, Frameworks and Drivers).
- Fowler, M. et al. (2002). *Patterns of Enterprise Application Architecture*. https://martinfowler.com/books/eaa.html — confirma título, autor y año. La página no nombra Transaction Script ni Domain Model: esa atribución queda por verificar contra el catálogo (https://martinfowler.com/eaaCatalog/) antes de citarla.

---

## 2. Hallazgos

### H-01 — La obra no tiene aparato de referencias: ninguna atribución ni cifra lleva fuente

- **Ubicación:** guía vigente l. 206 («Estilo arquitectónico propuesto por Robert C. Martin»), l. 241 («el diagrama original de Martin»), l. 994–1003 («MediatR 12», «EF Core 9», «.NET 9»); ausencia de una sección de referencias en todo el documento. En el plan, NC-02 cita el artículo de Martin como «blog 8th Light, 2012», mientras la publicación consultada está en `blog.cleancoder.com`.
- **Evidencia:** E2 (citas con ubicación) + E4 (restricción dura del contrato: «toda afirmación respaldada por evidencia verificable»; Rule-Evidences «Trazabilidad: referencia y fecha de obtención»).
- **Severidad:** S1. Viola una restricción dura: sin norma de citas no hay manera de que el entregable cumpla «no inventar».
- **Confianza:** 0,9.
- **Propuesta:** adoptar la norma de citas de la §4 de este informe; crear el anexo «Referencias» con identificadores estables; que cada afirmación atribuida (autor, patrón, versión, licencia, comportamiento de una herramienta) lleve cita o marca de laboratorio. Corregir en NC-02 la sede del artículo de Martin (verificada arriba). La veracidad de versiones y licencias no es mandato de este rol: la resuelve AH-001. Lo que sí corresponde acá es que toda afirmación de ese tipo tenga fecha de consulta.

### H-02 — El «Glosario» no es un glosario y el vocabulario de base no está definido en ningún lado

- **Ubicación:** §1 «Glosario de Términos», l. 26–250. Ocupa 225 líneas con código, dos diagramas y doctrina (Clean Architecture, inversión de dependencias); sus 11 entradas son `###` sin numerar y sin orden alfabético. Faltan términos que el texto usa sin definir: solución, proyecto, ensamblado, referencia de proyecto, espacio de nombres, paquete NuGet, «el DI» (l. 287), Handler, Controller, middleware, ProblemDetails, Blazor WebAssembly/Server, DelegatingHandler, JWT, composition root.
- **Evidencia:** E2 + E4 (Estilo §3.1: «Antes de usar un término, se fija»; Rule-Dual-Audience: «Definir cada término en su primer uso y registrarlo en el glosario»; Profile: anexos con glosario).
- **Severidad:** S2. El lector sin experiencia, que es el destinatario declarado, encuentra en la línea 34 «identidad», «comportamiento» y «tecnología» antes de saber qué es un proyecto.
- **Confianza:** 0,85.
- **Propuesta:** separar las dos funciones que hoy se mezclan. (a) Definir cada concepto en el capítulo donde se enseña, con el patrón del Estilo §4.4: anclarlo a su archivo y declarar qué excluye. (b) Poner al final un **Anexo D — Glosario** alfabético con, por entrada, término canónico, equivalente en el otro idioma, alias admitidos, definición de una línea y remisión a la § donde se desarrolla. El glosario no lleva código ni diagramas.

### H-03 — Jerarquía no citable e índice sin glosa; la última sección está fuera del índice

- **Ubicación:** índice l. 8–22 (solo títulos); 22 `###` sin número (p. ej. l. 332, 568, 807, 867); `## Resumen de Decisiones Tecnológicas` (l. 989) sin número ni entrada en el índice; no existen las secciones «qué promete», «lo que no se cubre» ni «el criterio, en una línea».
- **Evidencia:** E1 (chequeo mecánico, §1) + E4 (Estilo §3.2 «lo que no tiene número no se puede citar»; §3.3 índice con glosa; §3.1 orden; lista de verificación §7).
- **Severidad:** S2. El prompt pide que la guía sea «de consulta de criterios», y una consulta necesita poder citar «ver §7.3». Hoy ninguna decisión se puede citar.
- **Confianza:** 0,9.
- **Propuesta:** numeración `n.` / `n.m` en todo el cuerpo y letras para los anexos (`A.1`); cada `###` formulado como pregunta cuando trata una decisión (Estilo §2); índice solo del nivel `##`, con glosa que diga qué hay adentro y si es recorrido o consulta; anclas generadas del título exacto y verificadas por script (el de la §1 sirve de base).

### H-04 — Terminología no unívoca: «contrato» en cinco sentidos, nombres que divergen entre secciones, idioma de los identificadores contrario a DC-2

- **Ubicación:**
  - «contrato» significa: el proyecto `Contracts` (l. 324); los DTOs dentro de Application (l. 272, «Use Cases, DTOs, Contratos»); una interfaz técnica (l. 423–424); el Command/Query (l. 185); la interfaz de Refit (l. 683); el contrato de la API (l. 98).
  - Un mismo objeto con dos nombres: `ProductoDto` (l. 410) y `ProductoResponseDto` (l. 416, 620); el cuerpo del POST es `CrearProductoCommand` en el controller (l. 549) y `CrearProductoRequestDto` en el cliente (l. 622, 667).
  - Rutas: `Application/Products/DTOs/` (l. 91, 94) frente a `Features/Productos/DTOs/` (l. 415). `Products` es un concepto del dominio escrito en inglés, en contra de DC-2.
  - Capas: «Presentation» (l. 261), `presentation/` (l. 317), «Interface Adapters» (l. 212) y «Core» (l. 270) sin correspondencia declarada entre sí.
  - «Desktop» nombra un proyecto que incluye `Platforms/Android` (l. 834).
  - «legada» (l. 137) junto a «heredada» (usada en NC-03 y en el texto que se incorpora).
  - Títulos mixtos: «Repository Pattern», «Value Object», «Use Case / Caso de Uso».
- **Evidencia:** E2 + E4 (DC-2; Rule-Dual-Audience «sinónimos como alias del término canónico»; Profile «la misma terminología en toda la guía»).
- **Severidad:** S2. Un lector novato no puede distinguir si «contrato» en §11 es el proyecto o la interfaz, y va a reproducir en su solución dos nombres para el mismo DTO.
- **Confianza:** 0,9.
- **Propuesta:** antes de redactar, publicar en la bitácora una **tabla de términos canónicos**: término de prosa, identificador en código, alias prohibidos y definición. Reglas mínimas:
  - «contrato» se reserva para el contrato HTTP de la API y sus DTOs (proyecto `Contracts`, según resuelva DA-2). Para las interfaces se dice «interfaz» y para los Commands y Queries, «mensaje».
  - Un solo nombre por DTO.
  - Correspondencia explícita anillo de Martin ↔ proyecto ↔ carpeta, una sola vez y en una tabla.
  - Prosa en español con el término inglés en cursiva en su primera aparición («entidad (*Entity*)»). Los identificadores siguen DC-2 sin excepción. Esto no reabre DC-2: la aplica a la prosa.

### H-05 — Registro y voz: coloquialismos, calificativos de énfasis y tres voces distintas; el texto que hay que incorporar está en voz de conversación

- **Ubicación:** guía vigente l. 28, 612, 654, 807, 985, 1002; `❌ MAL / ✓ BIEN` dentro de un bloque de código (l. 810–814); emojis como rótulos de capa (l. 210–248). El material de la conversación del 2026-09-18 que el prompt manda incorporar usa voseo dirigido a un interlocutor («En tu idea…», «no querés arrastrar», «ya resolvés», «Sí, y en Clean también lo hace»).
- **Evidencia:** E2 + E4 (prompt: «sin caer en un lenguaje coloquial»; Estilo §4.6 «sin adjetivos de entusiasmo», sin condescendencia; Rule-Narrative-Voice: voz uniforme, sin muletillas).
- **Severidad:** S2. Si se pega la respuesta de la conversación tal cual, conviven tres voces: impersonal, imperativa de manual y diálogo con «vos». Eso rompe la uniformidad que exige el perfil («una sola voz de autor»).
- **Confianza:** 0,85.
- **Propuesta:** fijar una norma de voz en la bitácora.
  - **Exposición:** impersonal y en presente («la entidad se mapea desde Infrastructure»).
  - **Reglas prácticas y preguntas guía:** segunda persona con voseo rioplatense, que es la variante del corpus de referencia del Estilo (§8). Se aplica igual en todo el documento.
  - **Referencias al interlocutor:** se eliminan. «Tu idea» pasa a ser «el esquema página → servicio → EF». La objeción del lector se conserva como encabezado en forma de pregunta (Estilo §4.5), por ejemplo «### 3.6 ¿No es la entidad la que mapea la base de datos?».
  - **Contraste:** sin emojis ni «MAL/BIEN» dentro de código. Se usa la tabla ✅/❌ del Estilo §2.4, fuera del bloque.
  - **Léxico:** «boilerplate» → «código repetitivo de infraestructura»; «ahorrar un viaje HTTP» → «evitar la llamada HTTP».
  - **Diagramas:** los rótulos de capa sin emoji. El color ya distingue las capas.

### H-06 — Falta el frontmatter y la metadata es imprecisa

- **Ubicación:** l. 3–4: «Fecha: Abril 2026», «Stack: .NET 9…». No hay identificador, estado, versión, audiencia, prerrequisitos, fecha de última revisión ni trazas.
- **Evidencia:** E2 + E4 (Rule-Dual-Audience: frontmatter YAML obligatorio con `doc_id`, `doc_type`, `title`, `status`, `origin`, `owner`, `last_review`, `audience`, `traces`).
- **Severidad:** S3. No bloquea la lectura. Sí impide saber con qué SDK se validaron las salidas del laboratorio y cuándo vence la guía.
- **Confianza:** 0,8.
- **Propuesta:** frontmatter como el de la §3.1 de este informe. `sdk_validado` es obligatorio porque ancla todas las salidas «reales».

### H-07 — El plan no tiene arquitectura editorial: 10 núcleos más anexos no caben en 5–9 partes, y la trazabilidad núcleo → capítulo está vacía

- **Ubicación:** NC-00 §4 («Se completa en la fase de integración»); contrato §1.1 (un documento, «los núcleos del perfil se vuelven capítulos»); NC-08 («no es un capítulo aislado sino una columna»).
- **Evidencia:** E2 + E4 (Estilo §3.2: `##` = 5 a 9 partes y ≤ ~150 líneas por `##`; Profile: anexos y ruta de lectura; Rule-Documentation: única fuente de verdad).
- **Severidad:** S2. Si se traslada un núcleo por capítulo, salen 10 capítulos más anexos. Con el laboratorio, las respuestas explicativas y los criterios agregados, además, varios `##` van a pasar holgadamente las 150 líneas. Esa estructura hay que rehacerla después de escrita.
- **Confianza:** 0,75.
- **Propuesta:** aprobar antes de redactar la arquitectura de la §3: 9 capítulos agrupados en tres partes (las partes solo aparecen en el índice, no como encabezado, para que `##` siga siendo el capítulo citable) y cinco anexos. NC-06 y NC-07 se fusionan. NC-08 se reparte en los capítulos y el Anexo A es solo su hoja de ruta.

---

## 3. Propuesta de arquitectura editorial

### 3.1 Frontmatter

```yaml
---
doc_id: GUIA-NET-ARQ
doc_type: study-guide
title: "Arquitectura de soluciones .NET — guía de estudio y de criterios"
version: 2.0.0
status: draft            # draft → review (mesa ciclo 2) → published
origin: agent            # redactada por agente, revisada por mesa
confidence: <tras ciclo 2>
owner: <PO>
last_review: 2026-09-18
audience: "Persona sin experiencia en arquitectura .NET; sabe leer C# básico"
prerequisites: ["SDK .NET <versión DA-3> o contenedor mcr.microsoft.com/dotnet/sdk:<tag>", "curl"]
sdk_validado: "<salida literal de dotnet --version en la corrida del laboratorio>"
traces: [NC-01, NC-02, NC-03, NC-04, NC-05, NC-06, NC-07, NC-08, NC-09, NC-10]
related: ["Guides/Arquitectura/Microservicios-Guide.md"]
---
```

### 3.2 Estructura

| Sección | Contenido | Núcleo | Tipo de lectura |
|---|---|---|---|
| **0. Cómo usar esta guía** | A quién sirve y qué promete. Las dos puertas: recorrido lineal (§1–§6) y consulta de criterios (§7–§8). Convenciones tipográficas y marcas de evidencia (§4.2 de este informe). Cómo preparar el entorno | contrato T-01 | Ambas |
| *Parte I — Fundamentos* | | | |
| **1. El ecosistema .NET: solución, proyecto, referencia** | Definiciones ancladas a archivos (`.slnx`, `.csproj`); laboratorio L1 | NC-01 | Recorrido |
| **2. La regla de dependencia** | Clean Architecture, anillos ↔ proyectos (DC-1), inversión de dependencias, composition root; laboratorio L2 (ciclo, CS0246) | NC-02 | Recorrido |
| **3. Los objetos de cada capa** | «Cada objeto responde una pregunta»: un `###` por objeto, con respuesta explicativa; recorrido de ida y vuelta; «¿no es la entidad la que mapea la base?»; por qué no alcanza una clase plana; cuándo sí alcanza | NC-03 | Recorrido y consulta |
| *Parte II — Construcción* | | | |
| **4. El backend, proyecto por proyecto** | Domain, Application, Infrastructure, WebAPI; laboratorio L3–L5 (API, curl, tests) | NC-04 | Recorrido |
| **5. Los clientes** | Página → servicio → HTTP; Shared.UI; Hybrid; autenticación (fragmento ilustrativo) | NC-05 | Recorrido |
| **6. Estructura física y nombres** | Árbol de carpetas (DA-1), Contracts (DA-2), tabla de referencias permitidas, convención de nombres (DC-2) | NC-06 + NC-07 | Consulta |
| *Parte III — Criterio* | | | |
| **7. Del problema a la estructura** | Escala de opciones, señales para subir de escalón, señales de sobreingeniería, caso resuelto | NC-09 | Consulta |
| **8. Tecnologías, versión y licencias** | Criterio de evaluación de dependencias; tabla con fecha de verificación | NC-10 | Consulta |
| **9. Límites y criterio final** | Lo que la guía no cubre y por qué; el criterio, en una línea | — | Ambas |
| **Anexo A — Hoja de ruta del laboratorio** | Tabla L1…Ln: paso, § donde está, comando, qué confirma, error literal típico y qué hacer. Los comandos y salidas viven en los capítulos, no se repiten acá | NC-08 | Consulta |
| **Anexo B — Referencia rápida de dependencias** | Proyecto → puede referenciar / no puede, con la razón en una línea | NC-02/06 | Consulta |
| **Anexo C — Lista de verificación de diseño** | Plantilla comentada para una solución nueva, con las preguntas que guían cada campo (exigido por el perfil) | NC-09 | Consulta |
| **Anexo D — Glosario** | Alfabético; canónico, equivalente, alias, definición de una línea, § | todos | Consulta |
| **Anexo E — Referencias** | Norma de la §4 | todos | — |

Cada capítulo sigue el mismo patrón interno, adaptado del perfil: definición anclada → preguntas guía (`n.m`, pregunta → respuesta en una línea → porqué → ✅/❌) → laboratorio cuando corresponde (objetivo · comando · salida real · cómo leerla · qué confirma) → criterios de calidad. Si un `##` pasa de ~150 líneas, se parte o su material de referencia baja a un anexo, sin fragmentar las decisiones.

---

## 4. Norma de citas y de evidencia

### 4.1 Referencias bibliográficas

- **Sistema autor-fecha**, con enlace al anexo: `[Martin, 2012](#ref-martin-2012)`. En las entradas de Microsoft Learn el autor es «Microsoft» y la fecha es la de última actualización que muestra la página; si no la muestra, se usa «s. f.».
- **Formato de entrada**, en orden alfabético y con ancla estable `ref-<autor>-<año>`:
  `Autor, I. (año[, fecha]). *Título*. Sede o editorial. URL. Consultado el AAAA-MM-DD.`
  Ejemplo verificado: `Martin, R. C. (2012, 13 de agosto). *The Clean Architecture*. The Clean Code Blog. https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html. Consultado el 2026-09-18.`
- **Jerarquía de fuentes:** se prefiere la fuente primaria (autor del patrón, Microsoft Learn, repositorio o licencia del paquete). Las fuentes secundarias solo se aceptan si no hay primaria y se rotulan como tales.
- **Afirmaciones volátiles** (versión, soporte, licencia, comportamiento de una plantilla): llevan cita con fecha de consulta en el mismo renglón o en la celda de la tabla. Sin eso no se publican.
- **Citas textuales** (por ejemplo, la regla de dependencia): en el idioma original, entre comillas angulares, con traducción propia rotulada.

### 4.2 Marcas de procedencia en el cuerpo

| Marca | Significa | Cómo se cita |
|---|---|---|
| **Salida registrada** | Ejecutado en el laboratorio | `Salida registrada — Laboratorio/Lnn, SDK <versión>, 2026-09-..` al pie del bloque |
| **Fragmento ilustrativo** | Código que no se compiló (p. ej., MAUI) | Rótulo explícito sobre el bloque |
| **Fuente** | Afirmación atribuida | Cita autor-fecha |
| **Criterio de esta guía** | Recomendación propia, no normativa externa | Rótulo explícito (Rule-Evidences: «lo que es criterio propio se declara como tal») |

---

## 5. Revisado y correcto

1. **Las 13 anclas del índice resuelven** contra los encabezados reales (E1, chequeo de la §1). Vale para la guía vigente; en la reedición hay que volver a comprobarlo.
2. **La numeración `##` del cuerpo (1–13) es correlativa y coincide con el índice**, sin saltos ni duplicados. La única excepción es la sección final sin número (ya incluida en H-03).
3. **El supuesto del contrato §1.1** («un único documento; los núcleos se vuelven capítulos») es editorialmente sostenible y compatible con Estilo §3.5: los núcleos no se explican por contraste entre sí, así que partirlos no aporta. Es viable si se cumple la arquitectura de la §3 y el laboratorio se reparte en los capítulos (H-07).

---

## 6. Posición sobre DA-1..DA-4 (solo en lo editorial)

- **DA-1 y DA-2:** sin posición sobre el fondo. Editorialmente, cualquiera que sea la decisión, la tabla de términos canónicos (H-04) tiene que fijar un solo nombre para cada carpeta y proyecto, y la tabla de referencias permitidas tiene que quedar en un solo lugar (§6 con Anexo B como resumen enlazado), no en dos.
- **DA-3 y DA-4:** sin posición sobre el fondo. Lo que resuelva la mesa entra con cita fechada según la §4.1, y la versión elegida va en `sdk_validado` y `prerequisites` del frontmatter.

## 7. Solicitudes de convocatoria

- **Didáctica:** decidir si el lector sin experiencia necesita un recorrido guiado antes de las definiciones de §1 (orden «definiciones primero» del Estilo §3.1 frente a la progresión por descubrimiento). No es asunto de edición.
- **Verificación / QA:** fijar el formato de registro de `Laboratorio/Lnn` para que la marca «Salida registrada» de la §4.2 apunte a un archivo reproducible.
