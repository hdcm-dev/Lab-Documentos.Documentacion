---
doc_id: BIT-16-C1-INF-arquitectura
doc_type: informe-de-especialista
title: Informe del especialista en Arquitectura de software — ciclo 1
status: entregado
origin: agent
owner: panel del ciclo 1 (especialista «Arquitectura de software»)
last_review: 2026-10-28
audience: [relator, jurado, cuerpo-auditor, presidencia]
traces: [REED-16 §8.2, §8.4, §9.2 paso 3, M§8, BIT-16-00 §3, BIT-16-04 §2–§6, BIT-16-N0b §3.4, BIT-16-N1 §1.1, §2.14, §4.7, §6, BIT-16-N4 §1.2, BIT-16-N6 §1.1–§1.4, §4.4, Anexo A]
---

# Informe del especialista en Arquitectura de software — ciclo 1

**Mandato (REED-16 §8.2).** N1 (la capa de IA en el stack), ubicación de la capa de IA en `Domain/Application/Infrastructure`, fronteras N3–N4, coherencia del modelo reconstruido en BIT-16-04 y en N6, decisiones D-01…D-10. No juzgo detalle de comandos.
**Modo.** A ciegas: no leí otros `Informe-*.md` de esta carpeta.
**Objeto leído.** `04-Integracion.md` completo; `Nucleos/N1` (§1, §2.13–§2.14, §4.7, §5, §6, §8 y las notas del 2026-10-28); `Nucleos/N0b` §3.4 (D-01…D-10, §3.4.11) y su reparación; `Nucleos/N6` §1.1–§1.5, §4.4, Anexo A y su reparación; `Nucleos/N4` §1.2 y su reparación; `Nucleos/N3` §1.2; `00-Contrato-De-Entrada.md`; REED-16 §6–§9; la evidencia `Integracion-Evidencia/A-arquitectura/` (puertos, adaptadores y prueba de arquitectura) y el código del caso base en `59399ba`.
**Evidencia propia.** [`evidencia-arquitectura/`](evidencia-arquitectura/): `sonda-arquitectura.sh` y su salida (`grep` de sólo lectura sobre el caso base y sobre EA-2/EA-3, salidas S1…S10) y `cockburn-cita.txt` (cita literal de F20, consultada el 2026-10-28T12:52:09Z, HTTP 200). No se llamó al modelo ni se compiló.

---

## 1. Hallazgos

Esquema M§8. Capas posibles (REED-16 §9.5): pedido, núcleo, integración, laboratorio, demo, guía.

### ARQUIT-01 · Las herramientas son un adaptador de entrada y el modelo las ubica como adaptador de salida

```yaml
id: ARQUIT-01
especialista: arquitectura
capa_origen: núcleo   # N1 §2.14 y N4 §1.2 fila N1 (criterio propio sin fuente), propagado a BIT-16-04 §6.2 y N6 §1.3
ubicación: "BIT-16-04 §6.2 (diagrama, líneas 255, 267, 278, 289; lectura (1)–(2), línea 296); N6 §1.3 filas C1 y C6; N4 §1.2 fila N1; N1 §2.14"
severidad: S2
confianza: 0.8
```

**Afirmación.** El modelo pone en `Infrastructure/AI` las herramientas (`AIFunction` sobre casos de uso) y el bucle que las invoca, detrás de un puerto de `Application` (`IAsistenteDeMovilidad`). Al mismo tiempo pone el servidor MCP, que hace lo mismo para un modelo externo (exponer casos de uso como herramientas), en Presentación como «adaptador **de entrada**, como un controller» (N6 §1.3, fila C6). Es el mismo mecanismo clasificado en dos lados opuestos del hexágono. El resultado es un recorrido `Controller → puerto de Application → adaptador de Infrastructure → servicio de Application`, y la política de qué casos de uso ve el modelo (privilegio mínimo, D-06, M1, M7) queda en Infrastructure.

**Evidencia.** E2 + E4 + E1.
- E2: BIT-16-04 §6.2, `MCP["/mcp: sólo lecturas (MovilidadUrbanaMcp)"]` dentro de `PRES` (l. 255) frente a `TOOLS[…AIFunction finas sobre casos de uso…]` dentro de `INF/AI` (l. 267), con `NEW --> PORTS` (l. 278) y `TOOLS --> SVC` (l. 289). N4 §1.2, fila N1: «el agente es un adaptador en `Infrastructure`, las herramientas envuelven casos de uso de `Application` **(criterio propio)**». La reparación de N4 lo da por «confirmado por la integración», pero EA-2/EA-3 sólo prueban que no hay `using` de IA fuera de `Infrastructure/AI`. No prueban en qué lado del hexágono va la herramienta.
- E4: Cockburn (F20 de N1), consultado el 2026-10-28: «A primary actor is an actor that drives the application […]. A secondary actor is one that the application drives […]. The distinction between primary and secondary lies in who triggers or is in charge of the conversation.» En el bucle de herramientas, el que dispara el caso de uso es el modelo. Frente a `LocalidadService`, entonces, el modelo es un actor primario y la herramienta es un adaptador primario. Frente al modelo, `IChatClient` es un puerto secundario (`evidencia-arquitectura/cockburn-cita.txt`).
- E1: `Adaptadores.cs` l. 24, `AsistenteDeMovilidadLlm(IChatClient …, LocalidadService localidades) : IAsistenteDeMovilidad`: el adaptador de un puerto de Application depende del servicio concreto de Application (salida S10).

**Impacto si no se corrige.** El lector se lleva una regla, «toda la IA va en Infrastructure», que contradice la propia demo (MCP en Presentación) y no le sirve para decidir dónde poner una herramienta nueva. Además, la lista de capacidades que el modelo puede invocar, que es una decisión de seguridad y de producto, queda escondida en un adaptador técnico.

**Propuesta de dirección.** Reparar en origen (N1 §2.14 y N4 §1.2) con los **dos lados** de la capa de IA:
- **Lado secundario.** `IChatClient`, `IEmbeddingGenerator` y `VectorStore`, con su adaptador de proveedor y su pipeline, van en `Infrastructure/AI`.
- **Lado primario.** El catálogo de herramientas sobre casos de uso es un adaptador de entrada, igual que los controllers y que `Mcp/`.

Opciones:
- **(a) Recomendada.** Un único catálogo de capacidades expuestas al modelo, junto a `Mcp/` y con dos transportes (bucle interno y MCP). `Infrastructure/AI` sólo aporta el bucle y el cliente. Que el senior .NET verifique cómo se comparte la definición entre `AIFunction` y MCP; no lo afirmo.
- **(b)** Mantener la ubicación actual como excepción declarada, con su criterio, y que la lista de casos de uso expuestos sea una declaración de Application.

D-06 debería sumar esta alternativa. El diagrama de §6.2 y N6 §1.3 se redibujan en consecuencia.

### ARQUIT-02 · El contrato del puerto del asistente no puede transportar la aprobación, la sesión ni el streaming que el modelo exige

```yaml
id: ARQUIT-02
especialista: arquitectura
capa_origen: integración   # contrato de puerto de EA-2 adoptado por BIT-16-04 §6.2; falta ADR en N0b §3.4
ubicación: "Integracion-Evidencia/A-arquitectura/exp-capas/Nuevo/Application/Abstractions/PuertosDeIA.cs l. 15; BIT-16-04 §6.2 (TOOLS, AGT) y M3; N6 §1.3 filas C1 (streaming) y C5; N6 §4.4 l. 276–280; N0b §3.4 (D-01…D-10, §3.4.11)"
severidad: S2
confianza: 0.85
```

**Afirmación.** El puerto que el modelo adopta, `Task<string> ResponderAsync(string pedido, CancellationToken ct)` (S7), es sin estado y de texto a texto. Pero el mismo modelo exige tres cosas que ese contrato no puede llevar:
- que toda escritura se confirme (M3, MI-14, R-C02), es decir, devolver a la UI una acción pendiente con sus argumentos y recibir la decisión;
- un endpoint `/asistente` con streaming (N6 §1.3, C1);
- un agente MAF con sesión para la aprobación integrada (D-07, C5).

D-01 (c) prohíbe tipos de `Microsoft.Extensions.AI` en Application, así que el puerto necesita tipos propios en lenguaje del dominio, y ninguno está definido. Ninguna de D-01…D-10 dice dónde vive la `AgentSession` entre dos peticiones HTTP (circuito de Blazor Server o almacén para la API sin estado). §3.4.11 sólo registra el ciclo de vida del cliente en DI.

**Evidencia.** E1 + E2.
- E1: salida S7 de la sonda (`Task<string> ResponderAsync(string pedido…)`).
- E2: N6 §4.4, «`if (pedido is not null) // la UI muestra el pedido; la persona decide` → `agente.RunAsync(new ChatMessage(ChatRole.User, [pedido.CreateResponse(aprobado)]), session)`»: la decisión vuelve en **la misma sesión**. N6 §1.3, C5: «la UI muestra la solicitud y devuelve la decisión», sin puerto que lo lleve. BIT-16-04 §6.2 l. 267: «escrituras con ApprovalRequiredAIFunction».

**Impacto si no se corrige.** El constructor de la demo tiene dos salidas, y las dos rompen la regla que enseña la guía: filtrar `ToolApprovalRequestContent` y `AgentSession` hacia el controller y la página Blazor, o resolver la aprobación dentro del adaptador sin la persona (contra M3). El escenario D6 («Borrá Resistencia») no tiene diseño de capas.

**Propuesta de dirección.**
- Definir en N6 Anexo A el contrato del puerto del asistente en lenguaje del dominio. Por ejemplo: un turno con texto y acciones pendientes (id, herramienta, argumentos legibles); una operación para resolver una acción pendiente con aprobada o rechazada; un identificador de conversación; y, si se mantiene el streaming, un `IAsyncEnumerable` de fragmentos propios.
- Sumar un ADR (D-11, o dentro de D-06 si se vota MI-23 así) sobre el **estado de la conversación**: dónde vive la sesión, cuánto dura, si es por circuito o por identificador, y cómo se aísla por `SessionId`.
- Cubrirlo con una prueba de `Cableado/`: aprobación rechazada → 0 escrituras, a través del puerto y no del agente.

### ARQUIT-03 · «El caso de uso y las reglas deciden» es falso para la pertenencia al catálogo en el diseño elegido

```yaml
id: ARQUIT-03
especialista: arquitectura
capa_origen: integración   # BIT-16-04 tensión 7 / RA-4 frente a §6.2 lectura (2); hereda N6 T2
ubicación: "BIT-16-04 §2 tensión 7 y §6.2 l. 296 (lectura 2); N1 §5 P9; N6 §1.1 fila *Rules y hecho 3; N0b D-08"
severidad: S2
confianza: 0.85
```

**Afirmación.** La tensión 7 (RA-4, MI-05) decide no endurecer H1–H5 en la copia y poner la normalización contra `Catalogos` en el adaptador de `Infrastructure/AI`. Pero §6.2 enseña que «el modelo propone, **el caso de uso y las reglas deciden**», y N1 P9 dice que `LocalidadRules` «sigue siendo la autoridad». En la regla copiada, `ProvinciaValida` sólo exige «no vacío» (S6). Así, el único control de pertenencia al catálogo vive en Infrastructure, y el mismo caso de uso acepta «Corrientes Capital» por REST o por MCP y lo rechaza por la vía de IA. Son dos reglas distintas para un mismo caso de uso, según el adaptador de entrada.

**Evidencia.** E1 + E2.
- E1: S6, `public static bool ProvinciaValida(string? provincia) => !string.IsNullOrWhiteSpace(provincia);`.
- E2: BIT-16-04 §2, fila 7: «H1–H5 no se endurecen en la copia; la normalización contra `Catalogos` va en el adaptador (RA-4)», frente a §6.2 (2).

**Impacto si no se corrige.** La guía afirma una propiedad de su arquitectura que su demo no tiene (candidata a S1 por «contradicción entre secciones» si pasa así a la guía). Además, enseña a meter reglas de dominio en un adaptador técnico, que es justo el desacople que N1 critica.

**Propuesta de dirección.** Dos salidas, a elegir por la mesa:
- **(a) Recomendada.** Sumar, sin editar ningún archivo copiado, una pieza nueva del núcleo para normalizar y validar contra `Catalogos` (función de Domain o servicio de Application en archivo nuevo), que usen las herramientas, los extractores y los controllers nuevos. La copia sigue con `diff` = 0 y la regla vive en el núcleo.
- **(b)** Mantener el diseño, pero reescribir la lectura (2) de §6.2 y N1 P9 para decir que la pertenencia al catálogo la controla el adaptador anticorrupción de la IA, y declarar el déficit heredado del camino sin IA.

### ARQUIT-04 · El endpoint «desde texto» no tiene caso de uso: el controller va directo al puerto y nadie puede validar sin escribir

```yaml
id: ARQUIT-04
especialista: arquitectura
capa_origen: integración   # BIT-16-04 §6.2 (NEW --> PORTS) y R-C02; diverge de N1 §4.7 y de D-08
ubicación: "BIT-16-04 §6.2 l. 278 (NEW --> PORTS) y §3.2 R-C02 (ESC-03); N1 §4.7 (diagrama: UC --> P); N0b D-08 (c)"
severidad: S2
confianza: 0.8
```

**Afirmación.** Para ESC-03, R-C02 pide que «el endpoint no escribe, devuelve la propuesta normalizada con sus errores». §6.2 dibuja `Controllers nuevos --> Puertos de IA`, sin caso de uso en el medio. `LocalidadService` sólo tiene `GetAllAsync`, `SaveAsync` (valida **y** guarda) y `DeleteAsync` (S5): no hay «validar sin guardar». Entonces los errores los calcula el controller o el adaptador, y ninguno de los dos puede detectar el duplicado (`MismaLocalidad` necesita el repositorio) sin replicar lógica del servicio. Esto contradice el diagrama de N1 §4.7 (el caso de uso consume el puerto) y D-08 (c) («el caso de uso valida y decide»).

**Evidencia.** E1 + E2. E1: salida S5. E2: BIT-16-04 l. 278 `NEW --> PORTS` frente a N1 §4.7 `UC["EncuestaService (caso de uso)"] --> P["IAsistenteDeEncuesta"]`.

**Impacto si no se corrige.** La demo enseña, sin decirlo, a orquestar extracción y reglas en el controller, que es el antipatrón «llamar al LLM desde la UI o el controller» de N1 §6.2 con un puerto de por medio.

**Propuesta de dirección.**
- Sumar un caso de uso **nuevo** en Application para «proponer desde texto»: usa el puerto extractor, normaliza (ARQUIT-03), aplica `LocalidadRules` y el chequeo de duplicado por repositorio, y devuelve propuesta y errores sin escribir.
- Para la encuesta alcanza con `EncuestaService.ValidarPaso`, que ya existe.
- En §6.2, los controllers nuevos llaman sólo a Application (`NEW --> SVC`) y los servicios consumen los puertos (`SVC --> PORTS`), como en N1 §4.7.

### ARQUIT-05 · La «copia literal» (MI-05) tiene un inventario incompleto e importa a la demo una violación de la regla que la guía enseña

```yaml
id: ARQUIT-05
especialista: arquitectura
capa_origen: integración   # RA-4 / MI-05; reparación de N6 Anexo A
ubicación: "BIT-16-04 §2 tensión 7, §5 MI-05, §6.2 (PERS «copia»); N6 reparación «Anexo A, estructura y decisión (c)»; N6 §1.3 última oración"
severidad: S2
confianza: 0.85
```

**Afirmación.** Hay dos problemas.
- **El inventario no compila tal cual.** MI-05 y la reparación de N6 copian `Domain/`, `Application/`, `Controllers/` y `Sessions/`. Pero los controllers dependen de `MovilidadUrbana.ApiWeb.Contracts` (S3), y §6.2 da también por copiados `Persistence/` (y hace falta `Infrastructure/Sessions/SessionContext.cs` y `Infrastructure/DependencyInjection.cs`, S2). La fidelidad «verificable por `diff`» sólo se probó para `Domain` + `Application` (EA-2, 18 archivos).
- **La copia importa una violación.** Copiar `Controllers/` literal trae `LocalidadesController`, que inyecta `ILocalidadRepository` y lo usa en `GetById`, `Create` y `Update` (S4). N6 §1.3 lo señala como «excepción a evitar», y M1 y D-06 prohíben que una herramienta haga lo mismo. La prueba de arquitectura propuesta (EA-3) no lo detecta.

**Evidencia.** E1: salidas S2, S3 y S4 de `evidencia-arquitectura/sonda-arquitectura-salida.txt`, sobre el caso base en `59399ba`.

**Impacto si no se corrige.** El primer constructor de la demo encuentra que la copia no compila (falta `Contracts`) o copia de más sin procedencia. Y la demo que «muestra las capas» (N0b §3.4.11) trae un controller que saltea el caso de uso sin advertencia.

**Propuesta de dirección.**
- Fijar en N6 Anexo A el inventario exacto de la copia: carpetas y archivos, incluidos `Contracts/`, `Infrastructure/Persistence/`, `Infrastructure/Sessions/` y `DependencyInjection.cs`, o declarar cuáles se reescriben. Extender el `diff` de EA-2 a todo lo copiado.
- Para `LocalidadesController`: (a) declararlo en `PROCEDENCIA` y en la guía como deuda heredada del caso base, con remisión a la regla; o (b) no copiarlo y poner un controller equivalente que use sólo el servicio, como desvío declarado. Recomiendo (a), que conserva la promesa «la IA sólo agrega», más una excepción explícita en la prueba de arquitectura.

### ARQUIT-06 · La prueba de arquitectura propuesta (MI-04) no prueba la regla de dependencias que enuncia

```yaml
id: ARQUIT-06
especialista: arquitectura
capa_origen: laboratorio   # EA-3, propuesta como ejemplo en MI-04
ubicación: "Integracion-Evidencia/A-arquitectura/exp-capas/verificar-capas.sh l. 5–6; BIT-16-04 §3.1 RA-2 («la regla la hace cumplir una prueba de arquitectura»), §5 MI-04, §8 fila 3"
severidad: S3
confianza: 0.85
```

**Afirmación.** `verificar-capas.sh` cuenta archivos con `^using` de cinco prefijos (MEAI, Agents, OllamaSharp, VectorData, CommunityToolkit.VectorData) en cuatro carpetas (S8, S9). No verifica:
- la dirección de dependencias entre capas (`Application` → `Infrastructure`, `Domain` → `Application`);
- Presentación (controllers, `Mcp/`, página Blazor), donde está el antipatrón n.º 1 de N1 §6.2;
- `global using` ni nombres calificados;
- `ModelContextProtocol`;
- el atajo al repositorio de ARQUIT-05.

Aun así, RA-2 dice que la regla «la hace cumplir una prueba de arquitectura», y la guía la va a enseñar (§8, fila 3).

**Evidencia.** E1: salidas S8 y S9.

**Impacto si no se corrige.** El lector copia una compuerta que da verde aunque se viole la regla que dice proteger.

**Propuesta de dirección.** Que el ejemplo de MI-04 sea una prueba de `Cableado/` (NUnit, como el caso base) con reglas por capa:
- `Domain` → nada.
- `Application` → sólo `Domain`, sin paquetes de IA.
- Presentación → sin `Infrastructure.AI` concreto ni MEAI, OllamaSharp ni VectorData; `ModelContextProtocol` sólo en `Mcp/`.
- `OllamaSharp` sólo en `Infrastructure/AI`.
- Excepciones declaradas (ARQUIT-05).

La técnica (reflexión sobre tipos referenciados, análisis de fuente o `grep` con lista blanca por carpeta) la elige el senior .NET.

### ARQUIT-07 · El «único diagrama de capas» deja fuera la ingesta y deja ambiguo dónde vive el almacén vectorial

```yaml
id: ARQUIT-07
especialista: arquitectura
capa_origen: integración   # BIT-16-04 §6.2; deriva de N1 §1.1 y N3 §1.2 fila N1
ubicación: "BIT-16-04 §6.2 (RET, PERS) y regla de la tensión 1; N1 §1.1 (Vector DB dos veces) y su reparación; N6 §1.3 fila C4 y T3; MI-17"
severidad: S3
confianza: 0.75
```

**Afirmación.** §6.2 se declara «el único diagrama de capas de la guía», pero sólo dibuja el lado de consulta de la recuperación. No hay nodo para la **ingesta**: quién lee los `*Policy`, cuándo se indexa (al arrancar, porque InMemory se reconstruye) ni dónde se valida la dimensión (MI-17), aunque la «RAG Pipeline» de la imagen y N3 la tratan como etapa propia. Además, N1 §1.1 enseña «el *uso* es de la capa de IA y el *almacenamiento* es de la capa de datos», mientras §6.2 pone `VectorStore InMemory` dentro de `Infrastructure/AI` y deja `Persistence` aparte. Con la variante SqliteVec, que comparte archivo con EF Core (N6 T3), el almacenamiento es de Persistence y el diagrama no lo muestra.

**Evidencia.** E2: BIT-16-04 §6.2, nodo `RET["Recuperación: IEmbeddingGenerator + VectorStore InMemory (vías A, B, C; dimensión por configuración)"]`, sin arista de escritura. N1 §1.1, tercera viñeta de interpretación.

**Impacto si no se corrige.** El lector no ve dónde engancha la ingesta ni qué cambia en las capas al pasar de InMemory a un almacén persistente, que es el paso que la guía anuncia como variante.

**Propuesta de dirección.**
- Agregar al diagrama de §6.2 un nodo de ingesta en `Infrastructure/AI` (paso de arranque que lee los `*Policy` de Domain, genera embeddings, valida la dimensión y escribe la colección).
- Marcar el almacén como «Persistence cuando es persistente (SqliteVec); en memoria, junto al adaptador», coherente con N1 §1.1.

---

## 2. Lo que revisé y está bien

1. **D-01 (c) y RA-2 = C-1.** La resolución es correcta y está bien sostenida: puerto en `Application/Abstractions` sin ningún paquete de IA (ni `.Abstractions`), adaptador en `Infrastructure/AI` y composición en `Program.cs`. Se alinea con F12 («strictly through interfaces defined in Application Core») y con el patrón que el caso base ya usa para persistencia. EA-2/EA-3 la respaldan (0 `using` de IA en Domain y Application; copia con `diff` = 0), y los puertos de `PuertosDeIA.cs` hablan en lenguaje del dominio (`RespuestaConFuentes`), sin tipos de MEAI. P3 de N1 (cuándo `IChatClient` alcanza como puerto) da el criterio honesto de excepción.
2. **Tensión 1 y §6.3.** Reemplazar la diapositiva por un diagrama propio, tratar generar, recuperar y actuar como aumentos independientes (F02, F11) y convertir la escalera de N3b en un **criterio de elección** y no en una secuencia es arquitectónicamente correcto. Las tres vías de recuperación corren sobre el mismo buscador (EA-5), lo que muestra que la recuperación es una pieza reutilizable y no una capa «entre» el LLM y los agentes. El árbol de §6.3, con «código sin LLM» como primera salida, es coherente con D-07 y con N1 P1/P6.
3. **RA-3, RA-6 y la frontera N3–N4.** El armado del prompt y el orden del contexto quedan en el adaptador (detalle técnico ligado al proveedor y a la caché del prefijo), y Application aporta qué se pregunta, con qué permisos y qué se hace con la respuesta. `IAyuda` con dos adaptadores elegidos por configuración (`AyudaContextoFijo`, `AyudaRag`) es la demostración canónica del valor de un puerto. La frontera N3–N4 queda bien trazada: la vía B es «recuperación como herramienta» y la vía C sólo existe si ya hay un agente, sin forzar un marco de agentes para hacer RAG. LangGraph queda lateral, a la altura de los workflows.

---

## 3. Posición sobre los criterios propios de BIT-16-04 §5 (los de mi mandato)

| MI | Posición | Fundamento |
|---|---|---|
| MI-01 | propuesta | Tres vías sobre un mismo buscador (EA-5) muestran que la recuperación es una pieza y no una capa. «C sólo si ya hay un agente» evita subir de nivel de orquestación sin necesidad (D-07). La ubicación de la vía B queda sujeta a ARQUIT-01 |
| MI-04 | otra | Sí como ejemplo en `Examples/` y en la demo, pero no con el `grep` actual: una prueba de `Cableado/` con reglas por capa, Presentación incluida, y excepciones declaradas (ARQUIT-06) |
| MI-05 | otra | Copia literal + agregado, sí (es la mejor respuesta a PR-17), y `Controllers` en lugar de `Endpoints/`, sí. Condiciones: inventario completo (`Contracts`, `Persistence`, `Infrastructure/Sessions`, `DependencyInjection`) con `diff` sobre todo lo copiado; `LocalidadesController` declarado como deuda heredada; y H1–H5 sin endurecer sólo si la normalización vive en una pieza nueva del núcleo, no en el adaptador (ARQUIT-03, ARQUIT-05) |
| MI-06 | propuesta | El orden del prompt depende del proveedor (prefijo estable para la caché) y es detalle técnico. Un puerto de «armado de contexto» en Application metería prompts en el núcleo, contra D-01 (c). Application conserva qué, con qué permisos y qué hacer con la respuesta (RA-3) |
| MI-07 | propuesta | Un puerto con dos adaptadores intercambiables por configuración es la mejor ilustración del valor de D-01 y deja el escalón 0 como default honesto para 12 enunciados (N3b §0.6) |
| MI-10 | propuesta | Organizar N4 por mecanismo (herramienta → agente → workflow → MCP) sigue el árbol de §6.3 y la escalera de D-07. El ecosistema como columna evita que LangGraph parezca una capa. Pido que la fila MCP diga explícitamente que es un adaptador de entrada (ARQUIT-01) |
| MI-13 | propuesta | Demostrarlo en la composición de la demo (además del ejemplo 01) es la prueba arquitectónica de que Application no cambia, y la prueba de cableado lo comprueba (R-C14). Sólo en ejemplos queda como afirmación sin demostración en el caso |
| MI-14 | propuesta | Coherente con M1/M3 y con D-08: toda escritura es una propuesta. Sólo es implementable sin romper D-01 si se resuelve el contrato del puerto (ARQUIT-02) y la vía «desde texto» tiene caso de uso (ARQUIT-04) |
| MI-20 | propuesta | La página de chat es un adaptador de entrada más y muestra que Presentación consume Application, no `IChatClient` (N1 P8). Me abstengo en la parte de prueba móvil por el emulador (fuera de mandato) |
| MI-21 | propuesta | Que el caso de uso devuelva agregados pone la frontera de datos personales en Application, donde se hace cumplir, y no en la descripción de la herramienta. Es la forma arquitectónica de M7 |
| MI-23 | otra | ADR propio (D-11) y no un párrafo de D-06: el ciclo de vida del cliente, de las herramientas y de la sesión del agente es transversal (herramientas, MCP, aprobación), tiene un modo de falla medido (X1 [B]) y se cruza con el estado de la conversación de ARQUIT-02 |

Sobre D-01…D-10 en conjunto:
- D-01, D-02, D-03, D-07 y D-09 son coherentes con el modelo reconstruido.
- D-04 y D-05 quedan bien actualizados por la reparación del 2026-10-28.
- D-06 necesita la alternativa de ARQUIT-01 (herramientas como adaptador de entrada compartido con MCP).
- D-08 necesita decir dónde vive la normalización (ARQUIT-03).
- Falta una decisión sobre el estado de la conversación y las acciones pendientes (ARQUIT-02). PR-13 (Anexo F) la debería incluir.

---

## 4. Solicitudes de convocatoria (fuera de mi mandato)

- **AH-01 Seguridad.** El aislamiento por `SessionId` del caso base entra por encabezado (`X-Sesion-Id`, `LocalidadesController` l. 9), y §6.2 expone `/mcp` y `/asistente` sobre los mismos servicios. Pido que juzgue si un cliente MCP o el modelo pueden elegir la sesión de otro y si «`/mcp` sólo lecturas» alcanza.
- **Senior .NET.** Para la opción (a) de ARQUIT-01: cómo se comparte en .NET 10 una única definición de herramienta entre el bucle de `IChatClient`/MAF y el servidor `ModelContextProtocol`, con qué API y en qué versión.
- **Didáctica / Edición.** La copia literal conserva los espacios de nombres `MovilidadUrbana.ApiWeb.*` (necesario para `diff` = 0) junto a los nuevos `MovilidadUrbana.Asistente.*` (`Adaptadores.cs` l. 4–5). Juzgar si eso confunde al lector y cómo se explica.
