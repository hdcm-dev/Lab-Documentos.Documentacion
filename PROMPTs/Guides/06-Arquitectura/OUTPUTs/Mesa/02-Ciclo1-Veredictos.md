# Mesa evaluadora, ciclo 1: relatoría y veredictos del jurado

**Fecha:** 2026-09-18
**Marco:** `/IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §4.2 (relator), §4.3 (jurado), §5.3 (veredicto), §6 (escaladas)
**Objeto:** guía vigente `LAB/Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md` (commit 063f4e9, 1003 líneas) y plan `OUTPUTs/Nucleos/` (NC-00..NC-10)
**Informes leídos (8):** `Ciclo-1/01-Didactica.md`, `02-Edicion.md`, `03-Arquitecto-NET.md`, `04-Requisitos.md`, `05-Verificacion-QA.md`, `06-Lector-Novato.md`, `07-Abogado-Diablo.md`, `08-AH-Ecosistema.md`
**Autoridad de las decisiones:** delegación del PO del 2026-09-14 («la mesa decide; la propuesta mejor fundamentada queda aprobada»). DC-1..DC-4 no se reabren.

---

## Índice

- **[1. Relatoría](#1-relatoría)**: 54 hallazgos del panel reducidos a 27 consolidados, 7 contradicciones entre especialistas y la evidencia que agregó el juez de evidencia.
- **[2. Veredictos por hallazgo](#2-veredictos-por-hallazgo)**: cinco votos con fundamento por ítem.
- **[3. Contradicciones entre especialistas: resolución](#3-contradicciones-entre-especialistas-resolución)**: el orden del recorrido, dónde va «Cada objeto responde una pregunta», uno o dos documentos.
- **[4. Decisiones abiertas DA-1..DA-4](#4-decisiones-abiertas-da-1da-4)**: alternativas, elegida y reparto de votos.
- **[5. Índice aprobado del entregable](#5-índice-aprobado-del-entregable)**: partes, capítulos, secciones, núcleo que cubre cada una, laboratorio, tabla de objetos, criterios y anexos.
- **[6. Mapa del laboratorio](#6-mapa-del-laboratorio)**: cada paso con su sección, su comando y lo que confirma.
- **[7. Directivas de redacción](#7-directivas-de-redacción)**: DR-01..DR-30, cada una con su verificación.
- **[8. Convocatoria para el ciclo 2](#8-convocatoria-para-el-ciclo-2)**
- **[9. Escaladas al humano](#9-escaladas-al-humano)**: ninguna; chequeo de los 7 disparadores.
- **[10. Controles del ciclo](#10-controles-del-ciclo)**: homogeneidad, descartes, pendientes.

---

## 1. Relatoría

### 1.1 Base

| Informe | Hallazgos | S1 | S2 | S3 |
|---|---|---|---|---|
| 01 Didáctica | 7 | 0 | 5 | 2 |
| 02 Edición | 7 | 1 | 5 | 1 |
| 03 Arquitecto .NET | 7 | 1 | 5 | 1 |
| 04 Requisitos | 7 | 1 | 4 | 2 |
| 05 Verificación/QA | 7 | 1 | 4 | 2 |
| 06 Lector novato | 7 | 3 | 4 | 0 |
| 07 Abogado del diablo | 7 | 0 | 7 | 0 |
| 08 AH-001 Ecosistema | 5 | 0 | 3 | 2 |
| **Total** | **54** | **7** | **37** | **10** |

### 1.2 Hallazgos consolidados por raíz común

El relator no edita el contenido de los hallazgos: agrupa y remite al original.

| ID | Raíz común | Hallazgos de origen | Evidencia más alta | Severidad consolidada |
|---|---|---|---|---|
| HC-01 | No hay aparato de referencias: ninguna atribución, versión ni licencia tiene fuente ni fecha; NC-02 ubica mal el artículo de Martin | Ed H-01; Req H-05 (citas sin URL) | E2+E4 | S1 |
| HC-02 | «No inventar» no tiene mecanismo: no hay protocolo de captura, y el plan ya predice salidas que no ocurren (el ciclo «lo rechaza el SDK»; CS0246 como primer error; CS0272 con un inicializador de objeto) | QA-01, QA-04, Req H-05, Arq H-ARQ-07, QA-07 (rótulos) | E1 | S1 |
| HC-03 | Los pedidos del prompt no tienen ID, criterio ni prueba; no hay inventario de las secciones vigentes (§12 sin destino); la trazabilidad núcleo → capítulo está vacía | Req H-01, Req H-07, Req H-06 (forma), Ed H-07 (trazabilidad) | E2+E4 | S1 |
| HC-04 | La guía no tiene ningún comando; los fragmentos no compilan (`GetById`, `DomainException`, `IProductoRepository`, `ProductoApiService`); faltan DI, `Program.cs`, `AppDbContext` y repositorio | Nov H-06-01, H-06-02, H-06-03; Arq H-ARQ-01; QA-05; NC-00 X-03 | E1 | S1 |
| HC-05 | No se fija qué sabe el lector; términos usados antes de definirse o nunca definidos; el «Glosario» es un capítulo doctrinal | Did D-01; Ed H-02; Nov H-06-04 | E2+E4 | S2 |
| HC-06 | Secuencia: la tabla de objetos usa conceptos que se presentan después; el laboratorio no está asignado a capítulos; NC-08 rompe reglas antes de construir lo que protegen | Did D-02, D-03, D-04; Req R-07 | E2+E4 | S2 |
| HC-07 | Faltan preguntas guía en seis núcleos y casi ninguna pregunta «cuándo no» | Did D-05; Req H-03 | E2+E4 | S2 |
| HC-08 | La puerta de consulta no existe: sin escenarios, sin mapa «estoy acá → qué aplico», sin criterio de aceptación de NC-09, el problema conductor nunca se plantea | Did D-06; Req H-04 | E4+E2 | S2 |
| HC-09 | El lector solo practica el escalón más alto; los objetos se presentan sin la condición que justifica cada uno; el recorrido arranca por la solución máxima | Diablo H-01, H-04; Did D-07 (ubicación, E2); Nov H-06-07 | E2+E3+E4 | S2 |
| HC-10 | CQRS como opción por defecto con un nombre que no corresponde; MediatR y AutoMapper en el camino base con licencia dual desde 13/15 y vulnerabilidad alta en la última MIT | Diablo H-02, H-03; AH H-02, H-03 | E1+E2 | S2 |
| HC-11 | Los DTOs del front viven en Application, que el front no puede referenciar; Contracts «opcional» y vacío; el controller enlaza el Command desde el cuerpo HTTP; ruta `Products` en inglés | Arq H-ARQ-03; Nov H-06-06; NC-00 X-01, X-04, X-05 | E2+E3 | S2 |
| HC-12 | El caso de uso «crear» no persiste: `AddAsync` sin `SaveChanges` ni unidad de trabajo | Arq H-ARQ-02; Diablo H-06 (parte a) | E3 + fuente | S2 |
| HC-13 | El repositorio se enseña como obligatorio, contra la fuente de Microsoft | Diablo H-06 (parte b) | E2 + fuente | S2 |
| HC-14 | El «400 por precio negativo» no sale de ningún mecanismo descrito; la receta de ejecución (puerto, entorno, proceso en segundo plano) no está fijada | QA-03, QA-06 (puerto, E2) | E3+E2 | S2 |
| HC-15 | Afirmaciones de clientes incorrectas: no hay plantilla «Blazor Server», configuración de WASM en `wwwroot`, Hybrid «renderiza nativamente / funciona offline», «Desktop» con Android | Arq H-ARQ-04, H-ARQ-05; Nov H-06-05 (offline) | E1+E2 | S2 |
| HC-16 | Los diagramas contradicen la regla que enseñan (APP→INF, backend dentro de WebAPI, repositorio coloreado como Application); sin convención de flechas; Mermaid sin criterio | Arq H-ARQ-06; Nov H-06-05; Req H-06 (Mermaid) | E2 | S2 |
| HC-17 | Terminología no unívoca: «contrato» en cinco sentidos, un DTO con dos nombres, dos rutas, capas sin correspondencia | Ed H-04; NC-00 X-05 | E2+E4 | S2 |
| HC-18 | Registro coloquial, emojis como rótulos, tres voces; el texto de la conversación está en diálogo con «vos» | Ed H-05 | E2+E4 | S2 |
| HC-19 | Sin arquitectura editorial: jerarquía no citable, índice sin glosa, 10 núcleos no caben en 5-9 partes, sin presupuesto de extensión | Ed H-03, H-07; Diablo H-07 | E1+E2+E4 | S2 |
| HC-20 | Falta frontmatter; la metadata no dice con qué SDK se validó | Ed H-06 | E2+E4 | S3 |
| HC-21 | Versiones: .NET 9 y .NET 8 terminan soporte el 2026-11-10; EF Core suelto; la plantilla `webapi` no trae Swagger; `.slnx` por defecto; `webapi` genera minimal APIs | AH H-01, H-04, H-05; QA-02; Arq H-ARQ-07 (.slnx) | E1+E2 | S2 |
| HC-22 | La fuente «esto último que escribiste» no está archivada y NC-03 omite el «término medio» | Req H-02 | E2 | S2 |
| HC-23 | La regla «el front nunca referencia Application» es absoluta y falla en Blazor Server con cliente único, caso que la conversación declara válido | Diablo H-05 | E2+E3 | S2 |
| HC-24 | Tres afirmaciones centrales sin prueba asignada (Domain no se recompila al cambiar la implementación; WebAPI conoce Infrastructure solo en el DI; el cliente HTTP no necesita Domain) | QA-07 (pasos 16-18) | E4+E2 | S3 |
| HC-25 | «Empezar por la solución máxima dificulta ver cuándo aplica cada escalón» (efecto didáctico) | Did D-07 (parte C) | C | S3 |
| HC-26 | «No está verificado que `curl` venga en la imagen SDK» | QA-06 (parte C) | C | S3 |
| HC-27 | «Sin perfil de lanzamiento, el entorno es Production» | QA-06 (parte C) | C | S3 |

### 1.3 Contradicciones entre especialistas

| ID | Contradicción | Posiciones | Se resuelve en |
|---|---|---|---|
| CT-01 | Orden del recorrido práctico | Descendente: se arma el esqueleto de 4 proyectos temprano (Did §2, QA §3). Ascendente: se empieza con un único proyecto y se sube un escalón por necesidad (Diablo H-01; Did D-07 opción c, «la más cara») | §3.1 |
| CT-02 | Dónde va «Cada objeto responde una pregunta» | Capítulo 3, antes del backend (Ed §3.2). Capítulo de síntesis después de Clientes; cada objeto nace en su capa (Did D-02) | §3.2 |
| CT-03 | Contracts | Obligatorio en la solución de referencia (Arq DA-2). Existe solo cuando hay un cliente .NET remoto y nace con él (Diablo, Did). Un solo lugar del que el front saca los DTOs (Nov) | §4.2 (DA-2) |
| CT-04 | Uno o dos documentos | Un documento es sostenible con arquitectura editorial (Ed). Un documento con recorte declarado o documento más anexo hermano de laboratorio (Diablo H-07) | §3.3 |
| CT-05 | Cantidad de capítulos | 0..10 más anexos (Did). §0 más 9 capítulos en tres partes más anexos A-E (Ed) | §5 |
| CT-06 | Regla de referencias del front | Absoluta, tabla §13 vigente (Arq en su tabla; guía). Condicionada por proceso y cantidad de clientes (Diablo H-05); el Arq admite la variante pragmática como apartamiento declarado | §2 (HC-23) y §4.2 |
| CT-07 | Definiciones primero o descubrimiento | Estilo §3.1, definiciones primero (Ed). Espiral: cada objeto en su capa, síntesis al final (Did); Ed pide que decida Didáctica | §3.4 |

### 1.4 Evidencia verificada por el juez de evidencia

El juez de evidencia reprodujo dos puntos para no votar sobre afirmaciones no comprobadas. Guion y salida en `Ciclo-1/evidencia-jurado/run-j1.sh` y `salida-j1.txt` (imagen `mcr.microsoft.com/dotnet/sdk:10.0`, SDK 10.0.400, 2026-09-18).

| Afirmación | Resultado | Efecto |
|---|---|---|
| `evidencia-03/run1.sh` (ciclo de referencias) | Reproducido: `Ciclo.slnx`; `dotnet add … reference` responde «Reference … added to the project.» con código 0; `dotnet build` da `error MSB4006: There is a circular dependency in the target dependency graph involving target "_GenerateRestoreProjectPathWalk"` | Confirma Arq H-ARQ-07 y Req H-05 (E1) |
| QA-04: con `using` de un proyecto no referenciado el primer error sería CS0234 (C) | `Uso.cs(1,9): error CS0234 … does not exist in the namespace 'X' (are you missing an assembly reference?)` y `Uso.cs(2,47): error CS0246 … 'Repo' could not be found` | La conjetura asciende a E1 y se incorpora a HC-02 |
| QA-06: `curl` podría no estar en la imagen SDK (C) | `curl 8.5.0 …`, código 0 | Refutada; HC-26 no procede |

### 1.5 Solicitudes de convocatoria consolidadas

| Solicitud | Pedida por | Tratamiento |
|---|---|---|
| Seguridad: «JWT + Bearer» asociado a ASP.NET Core Identity (Microsoft Learn: «The tokens aren't standard JSON Web Tokens (JWTs)»); `ITokenService` inexistente | Arq, Nov, AH-001 | Corrección directa por HC-04/HC-15 (DR-21) y convocatoria acotada para el ciclo 2 (§8) |
| Arquitecto: código de estado para errores de dominio, controllers o minimal APIs, implementación alternativa del repositorio, cliente de consola o WASM, dónde vive el repositorio en memoria | QA, Did | Resuelto por el jurado en DR-14, DR-18, DR-19 y §6 |
| AH-001: DA-3 antes de correr el laboratorio; DA-4 | QA, Diablo, Nov, Arq | Resuelto en §4 |
| Didáctica: intercalado o capítulo aparte; ascendente o descendente; definiciones primero o descubrimiento | QA, Req, Diablo, Ed | Resuelto en §3 |
| Edición: extensión y recorte | Diablo | Resuelto en §3.3 y DR-08 |
| QA: formato de `Laboratorio/Lnn` | Ed, Req | Resuelto en DR-01 y DR-06 |
| Diseño de handlers y decoradores sin MediatR | AH-001 | Resuelto en DR-15 |

---

## 2. Veredictos por hallazgo

Jueces: **Ev** (evidencia), **Im** (impacto), **CB** (costo/beneficio), **CH** (coherencia histórica con DC-1..DC-4 y con este ciclo), **Ri** (riesgo e irreversibilidad). P = PROCEDE, NP = NO_PROCEDE, I = INSUFICIENTE. Ningún hallazgo nivel C funda una corrección.

### HC-01: sin aparato de referencias (S1). **PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | Ausencia comprobable en las líneas citadas; la sede del artículo de Martin se verificó con URL. |
| Im | P | Sin citas, la restricción dura «no inventar» no se puede auditar en el ciclo 2. |
| CB | P | Una norma autor-fecha y un anexo cuestan poco frente a republicar datos falsos. |
| CH | P | Aplica el contrato; no toca ninguna DC. |
| Ri | P | Reversible; solo agrega aparato. |

### HC-02: «no inventar» sin mecanismo, predicciones erróneas (S1). **PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | Dos predicciones desmentidas con E1 reproducido por el jurado (MSB4006 al compilar; CS0234 antes que CS0246). |
| Im | P | El lector que ve otra salida que la prometida pierde confianza en toda la guía. |
| CB | P | Un guion con capturas es el costo mínimo para cumplir la restricción dura. |
| CH | P | Coincide con el principio de NC-08, al que solo le faltaba el mecanismo. |
| Ri | P | Reversible; sin efecto sobre decisiones cerradas. |

### HC-03: requisitos sin ID ni criterio, sin inventario (S1). **PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | La matriz de Req muestra 12 de 17 pedidos sin criterio completo; el marco §3 lo declara S1. |
| Im | P | Sin registro, el ciclo 2 juzgaría el documento final contra impresiones. |
| CB | P | La matriz ya está escrita en el informe de Req; pasarla a Bitácora es barato. Registro liviano: criterio y chequeo, sin burocracia de pruebas formales. |
| CH | P | Completa lo que NC-00 §4 dejó explícitamente pendiente. |
| Ri | P | Sin riesgo. |

### HC-04: sin comandos, código que no compila, piezas de conexión ausentes (S1). **PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | E1 de dos panelistas independientes (Arq en SDK 10, Nov en SDK 9) con los mismos errores. |
| Im | P | Incumple la restricción dura «comandos que se puedan probar». |
| CB | P | El laboratorio es el núcleo del pedido; no hay alternativa más barata. |
| CH | P | Resuelve X-03 del propio plan. |
| Ri | P | Reversible. |

### HC-05: perfil del lector, términos sin definir, glosario doctrinal (S2). **PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | Citas literales de prompt y contrato que describen lectores distintos; tabla de términos con línea de primer uso. |
| Im | P | El lector del prompt se traba en `Producto`, antes de cualquier idea de arquitectura. |
| CB | P | Definir en el primer uso cuesta líneas, no reestructuras. |
| CH | P | El contrato dice «sin experiencia en arquitectura .NET»; el prompt manda. Se adopta el lector del prompt con C# mínimo explicado. |
| Ri | P | Reversible. |

### HC-06: secuencia de conceptos y del laboratorio (S2). **PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | El paso 4 de NC-08 no se puede ejecutar antes del paso 5 (E2 literal). |
| Im | P | Un laboratorio al final separa la salida del concepto, contra «al mismo tiempo» del prompt. |
| CB | P | Reordenar en el plan cuesta menos que reescribir el documento. |
| CH | P | NC-00 ya decía «columna»; se concreta. |
| Ri | P | Reversible. |

### HC-07: preguntas guía faltantes y sin «cuándo no» (S2). **PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | Conteo verificable de encabezados «Preguntas guía» en los núcleos. |
| Im | P | Es literal del prompt: «identificar en qué caso se aplica». |
| CB | P | Una pregunta por capítulo es barata. |
| CH | P | Coherente con T-04. |
| Ri | P | Sin riesgo. |

### HC-08: sin puerta de consulta (S2). **PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | El Perfil exige marco y mapa (E4); ningún núcleo los planifica (E2). |
| Im | P | El segundo destinatario del prompt (quien diseña desde cero) no tiene por dónde entrar. |
| CB | P | Cuatro escenarios y una tabla de entrada. |
| CH | P | Resuelve T-01 del contrato. |
| Ri | P | Sin riesgo. |

### HC-09: solo se practica el escalón máximo; objetos sin condición de existencia (S2). **PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | Sostenido por E2+E4 (Diablo) y E3 (21 tipos para una regla); la parte C de D-07 no se usa (ver HC-25). |
| Im | P | El lector sale sabiendo armar Clean y sin haber ejercido el criterio que el objetivo del contrato promete. |
| CB | P | Procede con la dirección híbrida de §3.1, no con la escalera completa ejecutada. |
| CH | P | No reabre DC-1: la escala se enseña sin cambiar qué es un anillo. |
| Ri | P | Reversible. |

### HC-10: CQRS, MediatR y AutoMapper en el camino base (S2). **PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | Metadatos de NuGet por versión (E1), NU1903 reproducido, Fowler citado con URL. |
| Im | P | Un lector en contexto institucional puede quedar fuera de la licencia Community sin saberlo. |
| CB | P | Handlers propios y mapeo manual cuestan menos que el paquete y su explicación. |
| CH | P | DC-2 conserva los nombres Command, Query y Handler; no dependen de MediatR. |
| Ri | P | Reversible: el paquete se puede sumar como escalón. |

### HC-11: DTOs inaccesibles para el front, Contracts vacío, Command como cuerpo HTTP (S2). **PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | Contradicción interna citada (l.91 contra l.980) y contraejemplo de compilación. |
| Im | P | Con las reglas escritas, el front no compila. |
| CB | P | Se corrige con DA-2. |
| CH | P | DA-2 estaba abierta a propósito. |
| Ri | P | Reversible. |

### HC-12: el caso de uso «crear» no persiste (S2). **PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | Contraejemplo concreto y documentación de `AddAsync` citada. |
| Im | P | Síntoma silencioso: 201 y un GET vacío. |
| CB | P | Una línea y un paso de laboratorio. |
| CH | P | No toca DC-3. |
| Ri | P | Sin riesgo. |

### HC-13: el repositorio como obligatorio (S2). **PROCEDE 4-1**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | Cita literal de Microsoft Learn («Repositories shouldn't be mandatory»). |
| Im | P | El lector que ya usa EF Core crea una capa que no sabe justificar. |
| CB | P | Se resuelve con una pregunta guía, no con cambios de código. |
| CH | NP | DC-3 fija dónde vive `IProductoRepository`; presentar el repositorio como opcional roza esa decisión. |
| Ri | P | Procede si el ejemplo conductor conserva el repositorio (DC-3 intacta) y lo opcional se enseña como criterio en §5.5 y §9. |

Resultado: procede como pregunta guía; el ejemplo mantiene el repositorio. La objeción de CH queda atendida por esa condición.

### HC-14: errores HTTP y receta de ejecución (S2). **PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | E3 sobre la validación automática con fuente; el puerto aleatorio está citado. |
| Im | P | El lector no obtiene el 400 que la guía promete y no sabe a qué URL llamar. |
| CB | P | Tres capturas y una receta fija. |
| CH | P | NC-04 dejaba «400/422» abierto; se cierra. |
| Ri | P | Sin riesgo. |

### HC-15: afirmaciones de clientes incorrectas (S2). **PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | `dotnet new list` en SDK 9 y 10 (E1) y dos páginas de Microsoft Learn citadas. |
| Im | P | «Offline» induce un error de diseño; `builder.Configuration["ApiBase"]` queda en null. |
| CB | P | Corrección de texto. |
| CH | P | Sin relación con DC. |
| Ri | P | Sin riesgo. |

### HC-16: diagramas contrarios a la regla (S2). **PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | Citas literales (l.950 contra l.241). |
| Im | P | El lector aprende la regla del diagrama, no la del texto. |
| CB | P | Una convención y seis diagramas. |
| CH | P | Hace cumplir DC-1 en los dibujos. |
| Ri | P | Sin riesgo. |

### HC-17: terminología no unívoca (S2). **PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | Siete apariciones de «contrato» con cinco sentidos, verificadas por grep. |
| Im | P | Viola la quinta condición de coherencia del marco §3. |
| CB | P | Una tabla de términos canónicos antes de redactar. |
| CH | P | Aplica DC-2 a la prosa sin reabrirla. |
| Ri | P | Sin riesgo. |

### HC-18: registro y voz (S2). **PROCEDE 4-1**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | Citas con línea y regla del prompt («sin caer en un lenguaje coloquial»). |
| Im | P | Tres voces rompen la uniformidad exigida por el perfil. |
| CB | P | Corrección de redacción. |
| CH | P | Coherente con el Estilo §4.6. |
| Ri | NP | La norma propuesta conserva el voseo en reglas y preguntas; lo considera riesgo de lectura coloquial y prefiere impersonal en todo el texto. |

Resultado: procede la norma de Edición (voseo solo en reglas prácticas y preguntas guía, como el corpus del Estilo §8). La objeción de Ri queda registrada para que el ciclo 2 la revise con el texto final.

### HC-19: arquitectura editorial y extensión (S2). **PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | Conteo mecánico de encabezados (E1) y reglas del Estilo §3.2 (E4). |
| Im | P | Sin estructura previa, se reescribe después de redactar. |
| CB | P | Aprobar el índice ahora (§5) cuesta menos que reestructurar. |
| CH | P | Mantiene el supuesto del contrato §1.1 (un documento). |
| Ri | P | Reversible hasta la redacción. |

### HC-20: frontmatter (S3). **PROCEDE 4-1**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | Rule-Dual-Audience llega por el RuleSet del Perfil. |
| Im | I | Sin frontmatter la guía se lee igual; el valor está solo en `sdk_validado`. |
| CB | P | Diez líneas. |
| CH | P | Coherente con el Perfil aplicado. |
| Ri | P | Sin riesgo. |

### HC-21: versiones y plantillas (S2). **PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | E1 en tres SDK y política de soporte citada con fecha de consulta. |
| Im | P | La guía quedaría sin soporte en 53 días. |
| CB | P | Se resuelve con DA-3 antes de capturar. |
| CH | P | DA-3 estaba abierta. |
| Ri | P | Reversible antes de correr el laboratorio; después, costoso. Por eso DA-3 se fija ya. |

### HC-22: fuente de la conversación no archivada (S2). **PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | La frase del «término medio» está en la fuente y no en NC-03. |
| Im | P | Sin la fuente, el pedido R-01 no se puede verificar. |
| CB | P | Copiar un texto. |
| CH | P | Coherente con R-01. |
| Ri | P | Sin riesgo. |

### HC-23: regla del front absoluta (S2). **PROCEDE 4-1**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | Contraejemplo coherente con la conversación y con Microsoft Learn (la UI referencia Application Core). |
| Im | P | Sin la condición, la guía contradice el caso que el prompt manda incorporar. |
| CB | P | Una tabla con condición. |
| CH | P | Ninguna DC fija esa regla. |
| Ri | NP | Un principiante puede leer «puede referenciar Application» como permiso general. |

Resultado: procede con la salvaguarda de Ri incorporada en DR-23 (invariante explícita: nunca Infrastructure; la condición se declara como escalón con su señal de salida).

### HC-24: pruebas faltantes de afirmaciones centrales (S3). **PROCEDE 4-1**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | P | Las tres afirmaciones no tienen prueba asignada en NC-08. |
| Im | P | Son las tres afirmaciones que justifican la arquitectura. |
| CB | P | Un comando cada una. |
| CH | P | Coherente con HC-02. |
| Ri | I | El hash de `Domain.dll` depende de si el build es incremental; pide un criterio robusto. |

Resultado: procede con el criterio de Ri: la prueba de «Domain no se recompila» se toma de la salida de `dotnet build -v n` (Domain aparece sin compilar) y el hash queda como apoyo (DR-06).

### HC-25: efecto didáctico de empezar por lo máximo (C). **INSUFICIENTE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | I | Nivel C: no funda corrección. |
| Im | I | El efecto ya lo cubre HC-09 con evidencia propia. |
| CB | I | No hace falta una corrección adicional. |
| CH | I | Sin conflicto. |
| Ri | I | Sin riesgo. |

Vuelve a Didáctica con un pedido concreto: en el ciclo 2, el lector novato debe decir en qué capítulo entendió por qué existe cada escalón. Si no asciende a E2, se archiva.

### HC-26: `curl` podría faltar en la imagen (C). **NO_PROCEDE 5-0**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | NP | Refutado por E1 del jurado: `curl 8.5.0`, código 0. |
| Im | NP | Sin impacto. |
| CB | NP | Nada que corregir. |
| CH | NP | Sin conflicto. |
| Ri | NP | Sin riesgo; L00 igual registra `curl --version`. |

### HC-27: entorno Production sin perfil de lanzamiento (C). **INSUFICIENTE 4-1**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | I | Nivel C. |
| Im | I | Solo afecta si la página de errores o OpenAPI dependen del entorno. |
| CB | P | La receta ya fija `ASPNETCORE_ENVIRONMENT=Development`, así que el costo de cubrirlo es nulo. |
| CH | I | Sin conflicto. |
| Ri | I | Sin riesgo. |

Resultado: la receta de DR-20 fija el entorno igual, así que no hace falta corrección. La captura L13 registra el entorno que informa el arranque, y con eso la conjetura se resuelve.

---

## 3. Contradicciones entre especialistas: resolución

### 3.1 CT-01: ¿el laboratorio baja desde la solución completa o sube desde un proyecto único?

**Resolución: recorrido híbrido. El esqueleto por capas se construye, pero cada escalón aparece después de una necesidad que se muestra con un comando capturado. Votos: híbrido 4, ascendente completo 1.**

| Alternativa | A favor | En contra |
|---|---|---|
| A. Descendente (Did §2, QA §3) | Barato; ya tiene orden verificado | El lector nunca ve la versión simple (Diablo H-01, E2+E4) |
| B. Ascendente completo (Diablo H-01) | Ejercita el criterio | Didáctica lo califica de opción más cara; exige HTTP y EF antes de definirlos |
| C. Híbrido (Did D-07 a+b, con los disparadores de Diablo H-01) | Muestra la versión «todo junto» y su límite; Tests nace con su motivo y Contracts con el primer cliente | Un paso más de laboratorio |

Qué queda fijado en C:

- En §2.2, el contraste antes/después se hace con dos bibliotecas de clases, sin HTTP ni EF. En la versión «todo junto», la entidad usa un tipo de persistencia y compila (nada lo impide). Separada en proyectos, el mismo uso falla con CS0234/CS0246. Ese es el disparador «que el dominio no compile contra la infraestructura» de Diablo H-01.
- Tests nace en §4 («probar la regla sin base de datos»). Contracts nace en §6 («el primer cliente .NET»).
- El escalón 1 (una sola app, página → servicio → EF) se enseña en §9 como opción legítima, con su escenario (E-A) y la señal para subir. No se ejecuta. La restricción de extensión (HC-19) lo impide.

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | C | Es la única que funda cada escalón en una salida capturada, sin inventar el efecto. |
| Im | B | El criterio se forma mejor practicando la opción baja; C la deja leída. |
| CB | C | B duplica el laboratorio; C agrega un paso. |
| CH | C | Compatible con el orden de NC-00 y con DC-1. |
| Ri | C | C es reversible; B compromete la extensión del documento único. |

### 3.2 CT-02: ¿dónde va «Cada objeto responde una pregunta»?

**Resolución: cada objeto se define en el capítulo de su capa; la tabla completa, con las siete respuestas explicativas, va en el capítulo 7 (síntesis). Votos: 4-1.**

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | Síntesis | D-02 muestra que la tabla usa Contracts, Front, Command y Fluent API antes de definirlos (E2). |
| Im | Síntesis | Una respuesta explicativa con términos indefinidos no explica. |
| CB | Síntesis | La definición en la capa y la síntesis no duplican: la síntesis responde y remite. |
| CH | Temprano | El pedido principal del prompt es esa tabla y el capítulo 7 la aleja. |
| Ri | Síntesis | Se mitiga la objeción de CH: el índice y §0.3 remiten al capítulo 7 desde el principio, y la ruta de consulta llega en un salto. |

### 3.3 CT-04: ¿un documento o dos?

**Resolución: un solo documento con recorte declarado (opción a de Diablo H-07). Votos: 5-0.**

La opción (b), documento más anexo hermano, cambia el entregable que el contrato fijó («el mismo archivo, reescrito entero»). Sería el disparador 3 de §6. La opción (a) respeta la letra del prompt. El recorte queda declarado en §0.1: laboratorio del backend y de un cliente de consola. Shared.UI, MAUI, Refit y autenticación quedan como fragmentos ilustrativos. El presupuesto de extensión está en DR-08.

### 3.4 CT-07: ¿definiciones primero o descubrimiento?

**Resolución: las dos, en niveles distintos. Dentro de cada capítulo, definiciones primero (Estilo §3.1). Entre capítulos, espiral: el concepto se presenta en la capa que lo necesita y se sintetiza en el capítulo 7. Votos: 5-0.**

### 3.5 CT-03, CT-05 y CT-06

- **CT-03** se resuelve en DA-2 (§4.2). Las posiciones comparten el mismo criterio («existe si hay un cliente .NET que consume la API») y difieren solo en cuándo aparece en el relato.
- **CT-05** se resuelve en el índice (§5): §0 más 9 capítulos en tres partes, con las partes solo en el índice. §0 cuenta como la fila 0 del Estilo §3.1 («metadatos y overview») y no como parte del cuerpo.
- **CT-06** se resuelve en HC-23 y DA-2.

---

## 4. Decisiones abiertas DA-1..DA-4

### 4.1 DA-1: estructura física

**Aprobada: `src/Backend/`, `src/Clients/`, `src/Contracts/` y `tests/` con la misma forma, en dos niveles como máximo, sin las subcarpetas `Core/` ni `Presentation/`. Votos: 5-0.**

```text
src/
├── Backend/
│   ├── MyProject.Domain/
│   ├── MyProject.Application/
│   ├── MyProject.Infrastructure/
│   └── MyProject.WebAPI/
├── Clients/
│   ├── MyProject.WebFront/
│   ├── MyProject.Maui/
│   ├── MyProject.Shared.UI/
│   └── MyProject.ConsoleClient/   (cliente del laboratorio)
└── Contracts/
    └── MyProject.Contracts/
tests/
└── Backend/
    ├── MyProject.Domain.Tests/
    └── MyProject.Application.Tests/
```

| Alternativa | Origen | Por qué no |
|---|---|---|
| Vigente: `core/`, `infrastructure/`, `presentation/` | Guía | Pone la WebAPI junto a apps que solo hablan HTTP (X-02) |
| NC-06: `Backend/Core/…`, `Backend/Presentation/…` | Plan | Codifica los anillos como anidamiento, la lectura de contención que DC-1 cerró (Arq) |
| **Arq DA-1** | Arq; a favor Did, Diablo, Nov | **Elegida**: la carpeta refleja la unidad de despliegue; Contracts no tiene dueño; la regla vive en `ProjectReference` |

Condiciones: §2.6 muestra solo `src/Backend/`. El árbol completo aparece en §8.1 (Did, Diablo). La guía declara que ni las carpetas ni las *solution folders* hacen cumplir la regla (§8.2). El proyecto se llama `MyProject.Maui`, no `Desktop` (HC-15).

### 4.2 DA-2: Contracts

**Aprobada: regla condicional con la solución de referencia como caso en que se cumple. Votos: 4-1.**

- **Criterio (§8.5 y §9):** existe `Contracts` si y solo si al menos un cliente .NET consume la API por HTTP. Sin clientes .NET, el contrato es el documento OpenAPI.
- **En el relato:** nace en §6.3 con el primer cliente .NET (la consola del laboratorio). No se crea en el esqueleto de §2.6 (Did D-04, Diablo).
- **Contenido:** solo `record` de request y response (`CrearProductoRequest`, `ProductoResponse`), sin comportamiento y sin paquetes.
- **Quién lo referencia:** WebAPI y los clientes. **Application no.** Application devuelve su modelo de lectura (`ProductoDto`); el controller lo traduce a `ProductoResponse`, recibe `CrearProductoRequest` y construye `CrearProductoCommand`. El Command deja de ser el cuerpo HTTP (HC-11).
- **Apartamiento declarado:** la variante Application → Contracts, sin mapeo en el controller, se presenta como válida cuando la API es la única puerta de Application y se señala su costo.
- **Interfaces del cliente** (`IProductoApiService`): no van en Contracts. Si hubiera que compartirlas, van en un `Clients/MyProject.ApiClient`.
- **Front y Application:** regla condicionada (HC-23, DR-23).

| Juez | Voto | Fundamento |
|---|---|---|
| Ev | A favor | Resuelve la contradicción l.91 / l.980 comprobada por Arq y Nov. |
| Im | A favor | Da un solo lugar del que el front obtiene los DTOs (Nov). |
| CB | En contra | Prefiere la variante pragmática (Application → Contracts): un mapeo menos para un principiante. |
| CH | A favor | Coincide el criterio de Arq, Diablo y Did; ninguna DC lo contradice. |
| Ri | A favor | La variante pragmática queda como apartamiento declarado; reversible. |

### 4.3 DA-3: versión de .NET

**Aprobada: .NET 10 LTS, con ASP.NET Core 10 y EF Core 10. La guía enseña la regla LTS/STS con la política oficial citada. Votos: 5-0.**

Fundamento (AH-001 H-01, con fuente consultada el 2026-09-18: https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core): .NET 8 y .NET 9 terminan su soporte el 2026-11-10. .NET 10 tiene soporte hasta el 2028-11-14. El SDK 10.0.400 ya está en el entorno. Consecuencias fijadas para el laboratorio: `global.json` con el SDK usado; imagen `mcr.microsoft.com/dotnet/sdk:10.0` con el tag completo y el digest registrados; `dotnet new sln` genera `.slnx`, y así se enseña; `webapi --use-controllers`; EF Core de la misma versión mayor que el runtime.

Alternativas descartadas: .NET 9 (el soporte termina en 53 días) y esperar a .NET 11 (será STS según la política citada).

### 4.4 DA-4: MediatR y AutoMapper

**Aprobada: fuera del ejemplo conductor y del laboratorio. Handlers propios inyectados con el contenedor nativo y mapeo manual. Ambos aparecen en §9.4 como caso de estudio de evaluación de dependencias, con los datos fechados en el Anexo C. Votos: 5-0.**

- Fundamento didáctico (Diablo H-03): la indirección no aporta al principiante, y el beneficio real (*pipeline behaviors*) se explica como decorador.
- Fundamento de ecosistema (AH-001 H-02, H-03, E1 y metadatos de NuGet): MediatR ≥ 13.0.0 y AutoMapper ≥ 15.0.0 tienen licencia RPL-1.5 o comercial. La última versión MIT de AutoMapper (14.0.0) tiene una vulnerabilidad alta (GHSA-rvv3-g6hj-g44x) sin parche libre.
- La licencia refuerza la decisión, pero no la funda (Diablo). Por eso la decisión no depende de que cambien los términos.
- No reabre DC-2: `CrearProductoCommand`, `ObtenerProductosQuery` y `Handler` se conservan. El nombre «CQRS» se reserva para modelos de lectura y escritura separados (HC-10, DR-16).

---

## 5. Índice aprobado del entregable

Archivo: `LAB/Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md`, reescrito entero.
Convenciones: `##` numerado de 0 a 9; las partes solo aparecen en el índice; `###` `n.m`; `####` con letra solo para series paralelas; anexos con letra. «Lnn» remite al mapa de §6.

| § | Título y secciones | Núcleos | Lectura | Laboratorio |
|---|---|---|---|---|
| **0** | **Cómo usar esta guía** | — (T-01, HC-05, HC-08) | Ambas | L00 |
| 0.1 | Qué promete y qué no cubre (microservicios, despliegue, CI/CD, MAUI completo, seguridad en profundidad, C# desde cero) | contrato | | |
| 0.2 | Qué se supone que sabés y qué explica la guía | HC-05 | | |
| 0.3 | Dos maneras de leerla: recorrido (§1→§9) y consulta (§9.1 → capítulos; §7 para los objetos) | T-01 | | |
| 0.4 | El problema conductor (tienda: Producto, Cliente, Pedido), actores y escenarios E-A..E-D, planteados sin resolver | HC-08 | | |
| 0.5 | Cómo leer las marcas de procedencia | HC-01, HC-02 | | |
| 0.6 | Preparar el entorno | NC-08 | | L00 |
| | ***Parte I: Fundamentos*** | | | |
| **1** | **Qué se está armando: solución, proyecto, referencia y paquete** | NC-01 (sin DI) | Recorrido | L01–L05 |
| 1.1 | Definiciones: SDK y CLI, solución (`.slnx`), proyecto y ensamblado, referencia de proyecto, paquete NuGet, espacio de nombres, plantilla | NC-01 | | |
| 1.2 | Crear una solución con dos proyectos | NC-01, NC-08 | | L01, L02 |
| 1.3 | ¿Por qué una referencia es una flecha con dirección? | NC-01 | | |
| 1.4 | ¿Alcanza con escribir `using` para usar otro proyecto? | NC-01 | | L03 |
| 1.5 | ¿Qué pasa si dos proyectos se referencian mutuamente? | NC-01 | | L04, L05 |
| **2** | **La regla de dependencia** | NC-02 + DI de NC-01 | Recorrido | L06–L08 |
| 2.1 | Definiciones: dependencia, interfaz, inversión de dependencias, inyección de dependencias, composition root; tabla única anillo de Martin ↔ proyecto ↔ carpeta (DC-1) | NC-02, HC-17 | | |
| 2.2 | ¿Qué cambia al partir un proyecto en capas? (contraste antes/después) | NC-02, NC-09 | | L06, L07 |
| 2.3 | ¿Por qué Infrastructure depende de Domain, si el dominio es el que necesita guardar? | NC-02 | | |
| 2.4 | ¿Por qué la WebAPI referencia Infrastructure si «no debería conocerla»? | NC-02 | | (verificación en L17) |
| 2.5 | ¿Qué se gana y qué se paga? | NC-02 → §9 | | |
| 2.6 | El esqueleto del backend: cuatro proyectos y sus referencias (diagrama 1) | NC-02, NC-06 | | L08 |
| | ***Parte II: Construcción (el ejemplo crece capítulo a capítulo)*** | | | |
| **3** | **Domain: lo que es verdad en el negocio** | NC-04 (Domain), NC-03 (Entity, VO), NC-07 | Recorrido | L09, L10 |
| 3.1 | Definiciones: entidad, value object, invariante, fábrica, excepción de dominio; recuadro de nombres (DC-2) | | | |
| 3.2 | `Producto` y `Dinero` (código de laboratorio completo) | | | L09 |
| 3.3 | ¿Por qué el precio no tiene setter público? | NC-03 | | L10 |
| 3.4 | ¿Y si la entidad no tiene ninguna regla? | NC-09 | | |
| **4** | **Application: lo que quiere hacer el usuario** | NC-04 (Application), NC-03 (Command/Query) | Recorrido | L11, L12 |
| 4.1 | Definiciones: caso de uso, Command, Query, Handler, modelo de lectura, interfaz de servicio técnico (DC-3) | | | |
| 4.2 | Crear y listar productos con handlers inyectados | NC-04 | | |
| 4.3 | ¿Cómo se prueba la regla sin base de datos? (nace el proyecto de tests) | NC-02, NC-08 | | L11, L12 |
| 4.4 | ¿Esto es CQRS? | NC-04, HC-10 | | |
| 4.5 | ¿Hace falta MediatR para tener casos de uso? | NC-10, DA-4 | | |
| **5** | **Infrastructure y WebAPI: el borde con el mundo** | NC-04 (Infra, WebAPI), NC-03 (Persistence model, Response DTO) | Recorrido | L13–L21 |
| 5.1 | Definiciones: petición HTTP, verbo, código de estado, JSON, controller, middleware, DbContext, configuración con Fluent API, repositorio, unidad de trabajo, ProblemDetails, OpenAPI | | | |
| 5.2 | La API en marcha con un repositorio en memoria | NC-04 | | L13–L15 |
| 5.3 | ¿Se puede cambiar el almacenamiento sin tocar Domain? (EF Core con SQLite) | NC-02 | | L16, L17 |
| 5.4 | ¿No es la entidad la que mapea la base de datos? | NC-03 (conversación) | | |
| 5.5 | ¿Dónde se confirma la escritura, y hace falta un repositorio si ya está EF Core? | HC-12, HC-13 | | L18 |
| 5.6 | ¿Qué devuelve la API cuando se rompe una regla? | HC-14 | | L19–L21 |
| **6** | **Los clientes** | NC-05, NC-03 (ViewModel, Form model), DA-2 | Recorrido | L22 |
| 6.1 | Definiciones: cliente, Blazor Web App y sus modos, Blazor WebAssembly Standalone, MAUI Blazor Hybrid, Razor Class Library, servicio de API del cliente, ViewModel, form model | | | |
| 6.2 | ¿Por qué la página no llama a `HttpClient` directamente? (diagrama 5) | NC-05 | | |
| 6.3 | ¿De dónde saca el cliente los DTOs? (nace Contracts) | DA-2 | | L22 |
| 6.4 | Si el Blazor es Server y es el único cliente, ¿por qué no llamar directamente a Application? | HC-23 | | |
| 6.5 | Ampliaciones rotuladas como ilustrativas: Shared.UI, MAUI Hybrid (qué corre dónde), Refit, autenticación con `DelegatingHandler` | NC-05 | | — |
| | ***Parte III: Criterio (se puede abrir directamente)*** | | | |
| **7** | **Cada objeto responde una pregunta** | NC-03 completo (R-01, R-02) | Ambas | remite |
| 7.1 | La tabla: objeto, ejemplo, pregunta, dónde vive, cambia cuando, **existe solo si…** | NC-03, HC-09 | | |
| 7.2 | Las siete preguntas con respuesta explicativa: `####` a. Entity, b. Value Object, c. Command/Query, d. Response DTO, e. ViewModel, f. Form model, g. Persistence model | NC-03 | | cada una remite a su Lnn |
| 7.3 | El recorrido de ida y vuelta de un producto (diagrama 3) | NC-03 | | |
| 7.4 | ¿Por qué no alcanza con una sola clase plana? | NC-03 | | |
| 7.5 | ¿Cuándo la clase única es la correcta, y cuál es el término medio? | NC-03, NC-09, HC-22 | | |
| **8** | **La estructura física y los nombres** | NC-06, NC-07, DA-1 | Consulta | L23 |
| 8.1 | El árbol de la solución | DA-1 | | L23 |
| 8.2 | ¿Las carpetas hacen cumplir la regla? | DA-1 | | |
| 8.3 | Referencias permitidas entre proyectos (tabla única, condicionada) | NC-06, HC-23 | | |
| 8.4 | ¿En qué idioma se nombra y con qué sufijo? | NC-07, DC-2 | | |
| 8.5 | ¿Contracts desde el primer día o cuando aparece el cliente? | DA-2 | | |
| **9** | **Del problema a la estructura: criterios para una solución real** | NC-09, NC-10 (criterio) | Consulta | L24 |
| 9.1 | Mapa de entrada: escenario E-A..E-D → estructura → capítulos y objetos → señal para subir | HC-08 | | |
| 9.2 | La escalera de opciones, de página → EF a capas con casos de uso (diagrama 6) | NC-09 | | |
| 9.3 | ¿Cuándo subir un escalón y cuándo es sobreingeniería? | NC-09, HC-09 | | |
| 9.4 | ¿Qué mirar antes de adoptar una versión o un paquete? (LTS/STS; licencia, mantenimiento, alternativa nativa, costo de salida; caso MediatR/AutoMapper) | NC-10, DA-3, DA-4 | | L24 |
| 9.5 | El problema conductor, resuelto | NC-09 | | |
| 9.6 | El criterio, en una línea | Estilo §3.1 | | |
| **A** | **Hoja de ruta del laboratorio**: L00..L24 con sección, comando, qué confirma y captura; los comandos reunidos para la consulta | NC-08 | Consulta | todas |
| **B** | **Lista de verificación para diseñar una solución nueva**: plantilla comentada con las preguntas de §9 | NC-09, Perfil | Consulta | |
| **C** | **Versiones, soporte y licencias verificadas**: datos volátiles, cada uno con fuente y fecha de consulta | NC-10 | Consulta | |
| **D** | **Glosario**: orden alfabético; término canónico, equivalente, alias, definición de una línea, § | todos | Consulta | |
| **E** | **Referencias**: autor-fecha, anclas `ref-autor-año`, URL, fecha de consulta | todos | — | |

**Inventario de la guía vigente → destino** (completa R-03; la Bitácora 03 lo detalla):

| Sección vigente | Destino |
|---|---|
| §1 Glosario | Definiciones repartidas en §1–§6 (en su capítulo) y Anexo D |
| §2 Diagrama de capas | §2.1 y §2.6, con la convención de DR-22 |
| §3 Estructura de carpetas | §8.1 (DA-1) |
| §4–§7 Domain, Application, Infrastructure, WebAPI | §3, §4, §5 |
| §8–§11 Front, servicios, Desktop, autenticación | §6 (6.5 ilustrativo) |
| §12 Diagrama final completo | Se retira: lo reemplazan el diagrama 2 (§2.6, generado de `reference list`) y el diagrama 3 (§7.3). Estaba en contra de DC-1 (HC-16) |
| §13 Reglas de dependencia | §8.3 (condicionada) |
| Resumen de decisiones tecnológicas | §9.4 (criterio) y Anexo C (datos fechados) |

---

## 6. Mapa del laboratorio

Una sola solución que crece. Cada paso declara su estado de partida. Formato fijo: objetivo → comando → salida registrada → cómo leerla → qué confirma → qué puede cambiar en otro equipo. Los pasos marcados con ⚠ se presentan como «predecí antes de ejecutar».

| Paso | § | Comando o acción | Resultado que se captura | Confirma |
|---|---|---|---|---|
| L00 | 0.6 | `dotnet --info`; `curl --version` | Versión del SDK = `global.json` | Entorno |
| L01 | 1.2 | `dotnet new sln` | `MyProject.slnx` | La solución agrupa y no compila |
| L02 | 1.2 | 2 `classlib`, `sln add`, referencia, listado de referencias, `build` | Build correcto | La referencia es una flecha |
| L03 ⚠ | 1.4 | `using` de un proyecto no referenciado; `build` | CS0234 y CS0246 (ya verificado por el jurado) | El espacio de nombres no crea referencia |
| L04 ⚠ | 1.5 | Referencia inversa (ciclo); `build` | Por separado: add con código 0; build con MSB4006 | El ciclo se detecta al compilar, no al agregar |
| L05 | 1.5 | Quitar la referencia; `build` | Build correcto | Reversibilidad |
| L06 | 2.2 | Un solo proyecto: la entidad usa un tipo de persistencia | Build correcto | Nada impide mezclar |
| L07 ⚠ | 2.2 | Separado en Domain/Infrastructure: el mismo uso | CS0234/CS0246 | La separación física hace cumplir la regla |
| L08 | 2.6 | 3 `classlib` + `webapi --use-controllers --no-https` en `src/Backend/`; referencias según la regla; listado; `build` | Domain con 0 referencias; 0 advertencias | El esqueleto obedece la regla |
| L09 | 3.2 | `Producto`, `Dinero`, `DomainException`; `build` | Build correcto | Domain no depende de nada |
| L10 ⚠ | 3.3 | Asignar `Precio` desde afuera sobre una instancia creada por `Create` | CS0272 | El setter privado protege la invariante |
| L11 | 4.3 | Proyecto xUnit en `tests/Backend/`; `Create(…, -5)` lanza; handler con repositorio en memoria **definido en el proyecto de tests**; `dotnet test` | Passed, Failed 0 | La regla se prueba sin base ni HTTP |
| L12 ⚠ | 4.3 | Quitar la validación de `Create`; `dotnet test` | Un test falla | El test detecta la regresión (se lo vio fallar) |
| L13 | 5.2 | Arranque con la receta de DR-20 (repositorio en memoria en Infrastructure) | Arranque escuchando en el puerto fijado; entorno informado | Composition root |
| L14 | 5.2 | `curl -s -i -X POST …/api/productos` | 201 con `Location` | Controller → caso de uso → dominio |
| L15 | 5.2 | `curl -s -i …/api/productos`; `…/openapi/v1.json` | 200 con solo los campos de `ProductoResponse`; documento OpenAPI | El contrato filtra; la plantilla no trae interfaz Swagger |
| L16 | 5.3 | Cambiar a EF Core 10 con SQLite tocando solo Infrastructure y `Program.cs`; `dotnet build -v n` | Domain no se recompila (el hash de `Domain.dll` como apoyo) | Inversión de dependencias |
| L17 | 5.3 | Repetir L15; `grep -rn Infrastructure src/Backend/MyProject.WebAPI` | Mismo JSON; una sola coincidencia, en `Program.cs` | WebAPI conoce Infrastructure solo en el DI |
| L18 ⚠ | 5.5 | Repositorio sin `SaveChanges`: POST y GET; corregir; repetir | 201 y lista vacía; después, el producto presente | Dónde se confirma la escritura |
| L19 ⚠ | 5.6 | POST con JSON mal formado | 400 con `ValidationProblemDetails` | Validación automática de forma |
| L20 ⚠ | 5.6 | POST con `precio: -5` sin manejador | 500 | La regla rechaza, pero nadie traduce |
| L21 | 5.6 | Manejador de excepciones en WebAPI; repetir L20 | 400 con ProblemDetails | La traducción de errores vive en el borde |
| L22 | 6.3 | Nace `src/Contracts/`; `console` en `src/Clients/` que referencia solo Contracts; listado de referencias; ejecutar contra la API | Lista de productos; sin referencia a Domain | Un cliente remoto vive con Contracts |
| L23 | 8.1 | `dotnet sln list`; árbol | Coincide con §8.1 | Estructura física |
| L24 | 9.4 | Proyecto descartable: `dotnet list package --vulnerable` con AutoMapper 14.0.0; lectura del campo de licencia en NuGet | NU1903 / High | Evaluar una dependencia antes de adoptarla |

Queda como **fragmento ilustrativo**, rotulado con su motivo: WebFront Blazor (si no se compila; si se compila, se rotula [Compilado]), Shared.UI, MAUI Hybrid, Refit, `DelegatingHandler` de autenticación, MediatR y AutoMapper.

---

## 7. Directivas de redacción

Cada directiva lleva su verificación. El ciclo 2 revisa contra esta lista y contra `Bitacora/02-Requisitos.md`.

### 7.1 Antes de redactar (bloquean el inicio)

| ID | Directiva | Verificación |
|---|---|---|
| DR-01 | Crear `Bitacora/00-Fuente-Conversacion.md` con el texto literal de la respuesta «Cada objeto responde una pregunta» y sus secciones («la entidad es la que mapea», «una sola clase plana», «cuándo tu idea es la correcta», término medio). Cada afirmación se traza a su §n.m o se declara descartada con su motivo | Archivo existe; tabla afirmación → § sin filas vacías |
| DR-02 | Crear `Bitacora/02-Requisitos.md` con R-01..R-17 (semilla: matriz del informe de Requisitos), con criterio y chequeo por requisito | 17 filas con criterio y chequeo |
| DR-03 | Crear `Bitacora/03-Integracion.md`: trazabilidad núcleo → § (tabla de §5), inventario vigente → destino y tabla de términos canónicos (DR-12) | Cada NC-01..NC-10 aparece en al menos una §; cada sección vigente tiene destino |
| DR-04 | Correr el laboratorio completo (§6) **antes** de redactar las secciones que lo muestran, con `lab.sh` en `OUTPUTs/Laboratorio/` | Existen `capturas/L00…L24` |

### 7.2 Evidencia

| ID | Directiva | Verificación |
|---|---|---|
| DR-05 | Toda salida mostrada lleva al pie: «Salida registrada: `Laboratorio/capturas/Lnn-<nombre>.txt`, SDK 10.0.x». Toda captura tiene un encabezado con fecha, imagen y digest, `dotnet --version`, comando y código de salida | Script: cada marca apunta a un archivo existente con encabezado |
| DR-06 | `lab.sh` hace una aserción sobre lo que no cambia en cada paso (código de error, estado HTTP, código de salida) y se lo ve fallar al menos una vez. «Domain no se recompila» se prueba con `build -v n`; el hash es apoyo | Salida del guion con todas las aserciones en verde y un registro de fallo provocado |
| DR-07 | Ningún código de error ni de estado aparece en la prosa sin su captura. Ya verificados: CS0234 + CS0246 (L03), código 0 al agregar y MSB4006 al compilar (L04), `.slnx` (L01). No se escribe «el SDK rechaza el ciclo» | grep de `CS[0-9]{4}\|MSB[0-9]{4}\|NU[0-9]{4}\| [2-5][0-9]{2} ` en la guía: cada aparición tiene una captura cerca o una remisión Lnn |
| DR-08 | **Presupuesto de extensión**: objetivo ≤ 1.600 líneas en total. Por `##`: §0 ≤ 90; §1 ≤ 130; §2 ≤ 150; §3 ≤ 120; §4 ≤ 140; §5 ≤ 190; §6 ≤ 150; §7 ≤ 170; §8 ≤ 110; §9 ≤ 150. Si un `##` se pasa, el material de referencia baja al Anexo A o C sin partir decisiones. §5 y §7 tienen permitido pasar las ~150 líneas del Estilo por el laboratorio y por las siete respuestas; queda declarado | `wc -l` por sección con script |
| DR-09 | Cada bloque de C# se rotula **[Compilado: `Laboratorio/src/<ruta>`]** (extraído del código que compiló) o **[Fragmento ilustrativo: motivo]**. En los bloques compilados no queda ningún tipo sin definir. El build de laboratorio da 0 advertencias o cada advertencia se explica | Script: todo bloque ```csharp va precedido de uno de los dos rótulos |
| DR-10 | Norma de citas autor-fecha: `[Autor, año](#ref-autor-año)` y entrada en el Anexo E con URL y fecha de consulta. Las afirmaciones volátiles (versión, soporte, licencia, comportamiento de una plantilla) llevan cita en el mismo renglón o en la celda. Las recomendaciones propias llevan el rótulo «Criterio de esta guía». El artículo de Martin se cita en `blog.cleancoder.com`. Transaction Script y Domain Model se atribuyen a Fowler solo después de verificarlos en https://martinfowler.com/eaaCatalog/ | Script: cada ancla `ref-` resuelve; grep de números de versión: cada uno tiene cita |
| DR-11 | Cada paso con salida variable (rutas, tiempos, puertos, versiones) lleva «Qué puede cambiar en tu equipo» | Revisión por paso en el ciclo 2 |

### 7.3 Estructura y exposición

| ID | Directiva | Verificación |
|---|---|---|
| DR-12 | Términos canónicos: **contrato** solo para el contrato HTTP y sus DTOs (proyecto `Contracts`); **interfaz** para las interfaces; **mensaje** para Command/Query. Nombres únicos: `CrearProductoRequest` y `ProductoResponse` (Contracts), `ProductoDto` (modelo de lectura de Application), `CrearProductoCommand`, `ObtenerProductosQuery`, `ProductoListItemViewModel`, `ProductoFormModel`. Carpetas de dominio en español (`Productos/`). `MyProject.Maui`, nunca «Desktop». «Heredada», nunca «legada». En la prosa, el término en español con el inglés en cursiva la primera vez; los identificadores siguen DC-2 | grep de alias prohibidos = 0 (`ProductoResponseDto`, `CrearProductoRequestDto`, `Products/`, `Desktop`, `legada`) |
| DR-13 | Seguir el índice de §5: `##` 0-9, `###` `n.m`, `####` solo en §7.2 y series; las `###` que tratan una decisión se formulan como pregunta; índice solo de `##` y con glosa; anclas comprobadas por script | Script de anclas: 100 % resuelven; 0 `#####` |
| DR-14 | Frontmatter YAML: `doc_id: GUIA-NET-ARQ`, `doc_type: study-guide`, `title`, `version: 2.0.0`, `status`, `origin`, `last_review`, `audience`, `prerequisites`, `sdk_validado` (salida literal de L00), `traces` (NC-01..NC-10 y R-01..R-17), `related` (Microservicios-Guide) | Parseo YAML sin error; `sdk_validado` = L00 |
| DR-15 | Cada capítulo del cuerpo sigue: línea de prerrequisitos con enlaces → definiciones declaradas (sin pregunta, Estilo §2.6; ancladas a su archivo y a lo que excluyen) → decisiones (pregunta → **respuesta en una línea en negrita** → porqué → ✅/❌ con 1 ✅ y 2-3 ❌, o una tabla de escenarios) → práctica → cierre con al menos una pregunta de aplicabilidad («¿cuándo no…?») respondida en términos de E-A..E-D | Checklist por capítulo en el ciclo 2 |
| DR-16 | Ningún término antes de su definición. El mínimo de C# (interfaz, `record`, `private set`, constructor privado, método `static` de fábrica, `async/await`, excepción) y de web (petición HTTP, verbo, código de estado, JSON, base relacional) se define en su primer uso. C# desde cero queda fuera de alcance, declarado en §0.1 | Script: lista de términos con la línea de su definición, anterior a la de su primer uso |
| DR-17 | Escenarios definidos una sola vez en §0.4: **E-A** una sola app Blazor Server, CRUD de pocas reglas; **E-B** una API con uno o más clientes .NET remotos; **E-C** base de datos heredada con esquema fijo; **E-D** reglas de negocio ricas que se repiten. Actores: quien administra el catálogo y quien compra. Todo el documento usa solo esos rótulos | grep: ningún escenario E-x que no esté en §0.4 |
| DR-18 | Voz: exposición impersonal, en presente; voseo solo en reglas prácticas y preguntas guía, igual en todo el documento; ninguna referencia al interlocutor de la conversación («tu idea» pasa a ser «el esquema página → servicio → EF»); sin emojis fuera de las tablas ✅/⚠️/❌; sin «MAL/BIEN» dentro de código. Palabras prohibidas: *simplemente, obviamente, basta con, boilerplate, arruina, crítico, fundamental, la más importante* | grep de la lista = 0; grep de emojis de capa = 0 |
| DR-19 | Tabla de §7.1 con la columna «Existe solo si…» para los siete objetos. §7.2 tiene exactamente siete `####`, cada uno con la respuesta en una línea, el porqué, el contraste ✅/❌ y la remisión al paso Lnn donde se vio. §7.5 incluye el término medio (entidad mapeada por EF, DTO o form model para lo que la página enlaza) | 7 de 7 `####` completos (R-02) |

### 7.4 Contenido técnico

| ID | Directiva | Verificación |
|---|---|---|
| DR-20 | Receta fija de ejecución: `ASPNETCORE_ENVIRONMENT=Development dotnet run --no-launch-profile --urls http://127.0.0.1:5180 &`; esperar con `curl -s -o /dev/null -w '%{http_code}'`; consultar con `curl -s -i`; la API y `curl` corren en el mismo contenedor. Se explica por qué: sin `--urls`, el puerto sale de `launchSettings.json` y varía | L13–L21 usan la receta |
| DR-21 | .NET 10 LTS (DA-3): `global.json`; imagen `sdk:10.0` con tag completo y digest; `.slnx`; los comandos con la forma que usó la captura, con la forma alternativa mencionada si el SDK 10 la admite y con cita; `webapi --use-controllers --no-https`; EF Core 10 con SQLite. Clientes: nombres de plantilla del SDK 10 (Blazor Web App con modos; Blazor WebAssembly Standalone); configuración de WASM en `wwwroot/appsettings.json` con la advertencia de que es visible para el usuario; Hybrid: el código corre nativo y el renderizado ocurre en un WebView; «la interfaz se carga sin red; los datos, no». Autenticación: `DelegatingHandler` como fragmento ilustrativo con cualquier `ITokenService` definido en el mismo fragmento; no se afirma que ASP.NET Core Identity emita JWT | Revisión de Arq y Seguridad en el ciclo 2 |
| DR-22 | Diagramas: una convención con leyenda en todos. **Línea continua**: `ProjectReference`, siempre hacia adentro. **Línea punteada**: llamada en ejecución o HTTP. Sin emojis. Lista mínima: (1) anillos ↔ proyectos, §2.1; (2) grafo real de referencias, §2.6, coincidente con el listado de L08; (3) ida y vuelta de un producto, §7.3; (4) secuencia de una petición, §5.2; (5) página → servicio → HTTP → API, §6.2; (6) escalera de opciones, §9.2. Ninguna flecha continua sale del centro hacia afuera | Render sin error; comparación de (2) con la salida de L08 |
| DR-23 | §8.3: tabla única de referencias permitidas con ✅/❌ y condición. **Invariante**: ningún cliente referencia Infrastructure ni Domain por fuera de Application. Un front puede referenciar Application solo si corre en el mismo proceso que el backend y es el único cliente (E-A); la señal para dejar de hacerlo es la aparición de un cliente remoto. WebAPI referencia Application, Infrastructure (solo para el DI) y Contracts. Application no referencia Contracts (salvo el apartamiento declarado de DA-2) | La tabla existe en un solo lugar; §2 y el Anexo B remiten, no copian |
| DR-24 | Sin MediatR ni AutoMapper en el ejemplo (DA-4): un handler es una clase con un método `Handle` (o una interfaz por handler si el laboratorio lo necesita para el test) registrada en el DI nativo; la validación y el logging transversales se explican como decoradores; el mapeo es manual (constructores o métodos de extensión). MediatR y AutoMapper solo aparecen en §4.5, §9.4 y el Anexo C | grep de `MediatR\|AutoMapper\|IMediator\|IMapper` fuera de §4.5, §9.4 y Anexo C = 0 |
| DR-25 | «CQRS» se reserva para modelos de lectura y escritura separados, con Fowler citado; el ejemplo se describe como «casos de uso con mensajes Command y Query» (§4.4) | grep de «CQRS»: cada aparición está en §4.4, §9 o el Anexo D |
| DR-26 | Contracts según DA-2: el controller recibe `CrearProductoRequest`, construye `CrearProductoCommand`, recibe `ProductoDto` y devuelve `ProductoResponse`. Ruta `api/productos`. `CreatedAtAction` apunta a una acción `GetById` que existe | L14 devuelve 201 con `Location` válido |
| DR-27 | Persistencia: en el CRUD simple, el repositorio llama `SaveChangesAsync`; se usa `Add` y no `AddAsync`, con la cita de la documentación de EF Core; la unidad de trabajo se presenta para cuando el caso de uso toca varios agregados. §5.5 responde «¿hace falta un repositorio si ya está EF Core?» con respuesta condicionada y la cita de Microsoft Learn; el ejemplo conserva `IProductoRepository` en Domain (DC-3) | L18 muestra el síntoma y la corrección |
| DR-28 | Errores HTTP: un solo código para el cliente, **400**, distinguido por el cuerpo. JSON mal formado → `ValidationProblemDetails` automático de `[ApiController]`. `DomainException` → ProblemDetails con `title` propio, traducido por un manejador de excepciones registrado en WebAPI (el mecanismo concreto se cita de Microsoft Learn al redactarlo). Se rotula «Criterio de esta guía» y se menciona 422 como alternativa válida con su cita | L19 y L21 con 400; L20 con 500 |
| DR-29 | Anexo C con los datos de AH-001 y sus fuentes, con fecha de consulta 2026-09-18: soporte de .NET 8/9/10 y de EF Core; MediatR 12.5.0 Apache-2.0 y ≥ 13.0.0 RPL-1.5/comercial; AutoMapper 14.0.0 MIT con GHSA-rvv3-g6hj-g44x y ≥ 15.0.0 RPL-1.5/comercial; condiciones de la licencia Community; FluentValidation 12.1.1 Apache-2.0; Refit MIT con generadores de código y aviso sobre versiones < 7.2.22; plantilla `webapi` 9/10 sin Swashbuckle | Cada fila con URL y fecha |
| DR-30 | §9 se lee sin los anteriores: empieza con el mapa §9.1 (escenario → estructura → capítulos y objetos → señal para subir) y cada fila tiene fundamento con cita o rótulo de criterio propio. §9.5 resuelve el problema planteado en §0.4. El Anexo B es la plantilla comentada del Perfil | R-08: tabla presente, caso resuelto presente |

---

## 8. Convocatoria para el ciclo 2

| Rol | Resultado | Motivo |
|---|---|---|
| Núcleo permanente (Requisitos, QA, Lector novato, Abogado del diablo) | Se mantiene | Automático |
| E-Didáctica, E-Edición, E-Arquitecto .NET | Se mantienen | Revisan el documento final, como pide el prompt |
| **Seguridad (catálogo variable), mandato acotado** | **CONVOCAR, 4-1** | Tres solicitudes independientes con ubicación (Resumen l.1003, §11). Mandato: solo §6.5 y la fila de autenticación del Anexo C. No opina sobre arquitectura. Voto en contra (CB): alcanza con retirar la afirmación. |
| AH-001 | Disuelto según su carta | Sus datos pasan al Anexo C con fecha; se reconvoca solo si el ciclo 2 detecta una señal de versión o licencia |

Variables en el ciclo 2: 4 (techo 5).

---

## 9. Escaladas al humano

**Ninguna.** Chequeo de los siete disparadores del §6:

| # | Disparador | ¿Se dispara? | Por qué |
|---|---|---|---|
| 1 | Ambigüedad de intención irresoluble | No | Lector «sin conocimientos» frente a «sin experiencia en arquitectura»: manda el prompt, que es la fuente del contrato (HC-05) |
| 2 | Conflicto entre restricciones duras | No | «Un documento» y «comandos con salida real» son compatibles con el recorte declarado (§3.3) |
| 3 | Cambio de alcance | No | Se eligió la opción (a) de CT-04 justamente para no cambiar el entregable; lo ilustrativo ya era fragmento en la guía vigente; MAUI ya estaba fuera de alcance |
| 4 | Irreversibilidad con impacto real | No | Todo es texto versionado; DA-3 se fija antes de capturar |
| 5 | Dominio con consecuencia externa | No | La guía informa licencias con fuente y no adopta los paquetes (DA-4) |
| 6 | Empate persistente | No | Ningún empate |
| 7 | Reapertura de decisión cerrada | No | HC-13 roza DC-3 y se resolvió sin reabrirla (el ejemplo conserva el repositorio); HC-10 y DR-25 conservan los nombres de DC-2 |

---

## 10. Controles del ciclo

### 10.1 Homogeneidad (§9 del marco)

27 ítems votados: 21 por 5-0 (78 %), 6 con disidencia (HC-13, HC-18, HC-20, HC-23, HC-24, HC-27), más CT-01 (4-1), CT-02 (4-1) y DA-2 (4-1). Queda por debajo del umbral de 80 %. Aun así, la unanimidad es alta, y se explica por la evidencia: 19 de los 21 ítems unánimes tienen E1, E2 o E3, y los otros dos son los de nivel C (HC-25 y HC-26), que se archivaron o devolvieron por unanimidad justamente por ser C. Salvaguarda voluntaria: en el ciclo 2, el abogado del diablo revisa HC-25, HC-26 y HC-27 (INSUFICIENTE o NO_PROCEDE).

### 10.2 Resultados

| Resultado | Ítems |
|---|---|
| PROCEDE | HC-01..HC-24 (24) |
| INSUFICIENTE | HC-25 (vuelve a Didáctica con un pedido), HC-27 (se resuelve con la captura L13) |
| NO_PROCEDE | HC-26 (refutado por E1) |

S1 que bloquean el cierre: HC-01, HC-02, HC-03, HC-04. Todos PROCEDE, con directivas DR-01..DR-10.

### 10.3 Registro de convocatoria contrastado con los hallazgos

Los ocho roles aportaron hallazgos que prosperaron. AH-001 justificó su convocatoria: DA-3 y DA-4 se resolvieron con sus datos. El «no convocar Seguridad» del registro (4-1) se revierte para el ciclo 2 por tres solicitudes con ubicación (§8).

### 10.4 Próximos pasos

1. DR-01..DR-03: Bitácoras 00, 02 y 03.
2. DR-04: laboratorio L00..L24 con `lab.sh` y capturas.
3. Redacción íntegra del entregable según §5 y §7.
4. Ciclo 2: panel a ciegas sobre el documento final, con Seguridad acotada; jurado; parches; verificación.
