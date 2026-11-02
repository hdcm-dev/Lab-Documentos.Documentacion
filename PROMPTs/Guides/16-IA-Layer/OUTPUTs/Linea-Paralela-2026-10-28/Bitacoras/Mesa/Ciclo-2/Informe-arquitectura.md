---
doc_id: BIT-16-C2-INF-arquitectura
doc_type: informe-de-mesa
title: Relectura integral, ciclo 2 — Arquitectura de software
rol: Arquitectura de software
fecha: 2026-10-28
objeto: "Guides/IA/Dot-Net-Integration-AI-Layer-Guide (guía, Examples/, Demos/MovilidadUrbana.Asistente/)"
mandato: "capa de IA en el stack (imagen de entrada y su corrección), regla de dependencias y su prueba, fronteras, coherencia §4–§6–§7–§9 con la demo real (PROCEDENCIA.md, Agregado/)"
modo: a ciegas (no se leyeron otros Informe-*.md)
evidencia: evidencia-arquitectura/
---

# Informe de Arquitectura de software — relectura integral (ciclo 2)

## 1. Qué se leyó y qué se corrió

- La guía completa, de punta a punta (§0–§9 y anexos A–F), con foco del mandato en §4, §5.3, §6.6, §7.2–§7.8, §8.6–§8.7, §9 y Anexo F.
- `Demos/MovilidadUrbana.Asistente/`: `PROCEDENCIA.md`, todo `Agregado/` (Application, Infrastructure/AI, Infrastructure/Persistence, Presentation), `Program.cs` y `tests/.../Cableado/ArquitecturaTests.cs` + `Comun/ReglaDeCapas.cs`.
- `Examples/13-Prueba-De-Arquitectura/` completo (fuente, `Composicion.cs`, `Capas.cs`, `ReglaDeDependenciasTests.cs`, `ReglaDeCapas.cs`); la ubicación por capas de `Examples/05`, `06`, `07`, `09` y `10`.
- Referencias de juicio: plan vinculante §10.2 (fila «§4 La capa de IA en el stack»), dictamen y compuertas.
- **Sondas sin modelo** (recurso «build», `mcr.microsoft.com/dotnet/sdk:10.0`, copias de trabajo borradas al terminar; nada quedó en la carpeta de la guía): (a) las reglas R2–R6 de `Examples/13` aplicadas al ensamblado de la demo; (b) un caso rojo nuevo, «argumento genérico de método», contra el motor de la demo y el de `Examples/13`. Detalle en `evidencia-arquitectura/00-LEEME.md`.

## 2. Hallazgos

### ARQUIT-01 · La demo no cumple la «forma completa» de la regla que la guía enseña, y la guía no lo dice — S2 · coherencia

**Ubicación.** Guía §4.5 punto 5 (l. 775), §4.6.2 tabla de mutaciones (l. 831), §4.6.3 último párrafo (l. 844), §9.3.1 (l. 3262). Demo `Agregado/Infrastructure/AI/HerramientasDeLectura.cs`, `Agregado/Presentation/{LimitadorDelModelo.cs, Controllers/AsistenteController.cs, Componentes/Paginas/ChatDelAsistente.razor}`.

**Evidencia (medida).** Sonda (a), `evidencia-arquitectura/02-salida-sonda-reglas.txt`: R2, R4 y R5 dan 0; **R3 («Infrastructure no usa casos de uso») da rojo**: `MovilidadUrbana.Asistente.Infrastructure.AI.HerramientasDeLectura → LocalidadService` y `→ ResultadosDeEncuestaService`, que es exactamente la mutación `HerramientaEnInfrastructure` que §4.6.2 muestra roja «porque eso es trabajo de un adaptador de entrada»; **R6 («Presentation no conoce Infrastructure») da rojo**: `ChatDelAsistente`, `AsistenteController` y `LimitadorDelModelo` → `Infrastructure.AI.OpcionesDeIA`/`OpcionesDeConcurrencia`, y `App`, `Routes` y `CookieDeSesionMiddleware` (las piezas adaptadas, agregadas) → `SessionContext` concreto, además de la excepción heredada que `Examples/13` declara. El plan vinculante §10.2 dice: «La regla de capa (P-30) reconoce `Agregado/Application` como núcleo **y el catálogo único de herramientas como adaptador de entrada**»; la prueba de la demo sólo cubre el núcleo y no reconoce el catálogo en ningún rol. §4.5.5 dice «Carpeta no es rol», pero la prueba que «lo prueba» define el rol **por espacio de nombres**: para ella, carpeta (namespace) sí es rol. El lector que pase la regla de §4.6 a la demo ve dos rojos que la guía no anticipa.

**Propuesta.** Preferida (cambio de código, chico): mover `HerramientasDeLectura` y `CatalogoDeHerramientas` a `Agregado/Presentation/Herramientas/` (namespace `MovilidadUrbana.Asistente.Presentation.Herramientas`) con el cableado de ARQUIT-02, y sumar a `ArquitecturaTests` las reglas R3 y R6 de `Examples/13` con dos excepciones declaradas en el test, con motivo: «Presentation → `OpcionesDeIA` (límites de entrada y concurrencia: la entrada valida antes del modelo)» y «piezas adaptadas de la web → `SessionContext` concreto (fijan la sesión del circuito, como el middleware heredado)». Mínima (si la mesa no toca código): reemplazar el punto 5 de §4.5 y el último párrafo de §4.6.3 por:

> 5. **Carpeta y rol.** La prueba de `Examples/13` define el rol por espacio de nombres, así que para ella la carpeta *es* el rol: allí las herramientas viven en `Presentation/Herramientas` y una herramienta en `Infrastructure/AI` da rojo. La demo las deja en `Infrastructure/AI`, con rol de entrada, y por eso no pasaría esa regla (ver §4.6.3).

> La versión de la demo (`…/Cableado/ArquitecturaTests.cs`) cubre sólo el núcleo, con los casos rojos de la propiedad y del cuerpo. Aplicadas a la demo, las reglas de Infrastructure y de Presentation de `Examples/13` dan rojo: las herramientas de `Infrastructure/AI` usan `LocalidadService` y `ResultadosDeEncuestaService`, y la página, el controller y el limitador leen `OpcionesDeIA` (medido sin modelo, 2026-10-28). Es una deuda declarada de la demo, no una excepción a la regla.

Y en §9.3.1 (l. 3262) agregar al final: «Las reglas de Infrastructure y de Presentation no se aplican a la demo (§4.6.3).»

### ARQUIT-02 · El cableado «herramienta de entrada → adaptador de salida» no está enseñado ni probado en ninguna pieza — S2 · técnico

**Ubicación.** Guía §4.4 (l. 702, el adaptador de entrada), §7.2 último párrafo (l. 1917), Anexo F (sin decisión sobre esto). `Examples/13/.../Composicion.cs` y `Agregado/Presentation/Herramientas/HerramientasDeLectura.cs`.

**Evidencia (lectura).** En `Examples/13`, `Composicion.cs` hace `services.AddScoped<HerramientasDeLectura>()` y ningún tipo llama a `Catalogo()`: las herramientas en `Presentation` no llegan a ningún `IChatClient`. La única pieza que cumple R3 lo logra porque sus herramientas no están conectadas. Donde sí se conectan (demo, `Examples/06`, `07`, `05` vía B/C), viven en `Infrastructure/AI` y el adaptador de salida que las ofrece las nombra directamente (`AdaptadoresDeModelo.cs` l. 95: `fabrica.Crear([.. CatalogoDeHerramientas.Todas])`). El problema arquitectónico real de una capa de IA con herramientas es la **reentrada**: núcleo → puerto → adaptador de salida → bucle del modelo → herramienta → caso de uso del núcleo. La guía no lo nombra, no dice cómo se rompe el acoplamiento y §7.2 afirma «las herramientas … son adaptadores de entrada» sin mostrar una solución que lo cumpla bajo la prueba.

**Propuesta.** (1) En §7.2, después de «Dónde vive cada pieza en las capas (§4): …», agregar:

> Las herramientas crean una **reentrada**: el núcleo llama a un puerto, el adaptador de salida abre el bucle del modelo y el modelo pide una herramienta que vuelve a un caso de uso del núcleo. No es un ciclo de compilación, pero sí de ejecución, y se resuelve en la raíz de composición: el adaptador de entrada (las herramientas, en `Presentation`) publica su catálogo como `IReadOnlyList<AIFunction>`, la composición lo registra, y el adaptador de salida lo recibe por inyección sin conocer los casos de uso. Así el adaptador de salida sólo nombra `AIFunction`, y la regla «Infrastructure no usa casos de uso» se puede probar.

(2) Código, si la mesa aplica ARQUIT-01: en la demo, `ConsultaConHerramientasLlm(IChatClient chat, FabricaDeOpcionesDeChat fabrica, IReadOnlyList<AIFunction> herramientas)` y en `Program.cs` `builder.Services.AddSingleton<IReadOnlyList<AIFunction>>(CatalogoDeHerramientas.Todas);` (el catálogo ya crea cada instancia con `args.Services`, así que la sesión por ámbito se conserva; CTRL-06 se re-verifica con la suite). En `Examples/13`, conectar `Catalogo()` a un adaptador de salida mínimo o declarar en su README que las herramientas no se conectan. (3) Anexo F, decisión nueva:

> **D-12 · Dónde viven las herramientas y cómo llegan al modelo.** *Situación:* una herramienta es un adaptador de entrada (llama a un caso de uso) que consume un adaptador de salida (el bucle del `IChatClient`). *Alternativas:* (a) en `Infrastructure/AI`, junto al adaptador que las ofrece; (b) en `Presentation/Herramientas`, entregadas por la composición como `IReadOnlyList<AIFunction>`. *Criterio:* la regla de dependencias y su prueba. *Decisión:* (b). *Consecuencias:* un registro más en la raíz de composición; el adaptador de salida no nombra casos de uso. *Pieza:* §4.6, §7.2; `Examples/13`.

### ARQUIT-03 · El motor de la prueba de la demo es más débil que el de `Examples/13` y tiene un agujero no declarado — S3 · técnico

**Ubicación.** Demo `tests/.../Comun/ReglaDeCapas.cs` (`TiposEnIL`, rama `MethodBase`; `try { … ResolveMember … } catch (Exception) { }`); guía §4.6.1 (l. 785 y ss.), §4.6.3 (l. 844), §9.3.1 (l. 3262).

**Evidencia (medida).** Sondas 3 y 4, `evidencia-arquitectura/05-salida-generico-de-metodo.txt`: un tipo «del núcleo» cuyo único uso de `ChatMessage` es `s.AddSingleton<ChatMessage>()` da **0 hallazgos con el motor de la demo y 1 con el de `Examples/13`**. La diferencia: `Examples/13` recorre `r.GetGenericArguments()` del método resuelto; la demo no. La demo además traga en silencio las excepciones de `ResolveMember` y no inspecciona atributos ni restricciones genéricas (el caso rojo `Atributo` de §4.6.2 no tendría equivalente). El mismo agujero explica por qué la sonda (a) da R5 = 0 aunque `ComposicionDeIA.cs` l. 79 registre `AddScoped<ILecturaDeResultados, LecturaDeResultadosEf>()`. La guía dice de la demo «cubre sólo el núcleo» (alcance) y §9.3.1 «verifica por reflexión y por IL que ninguno use tipos de IA…», pero no que el motor sea otro; §4.6.3 declara sólo dos agujeros (`SoloUsing`, `Nameof`).

**Propuesta.** Reemplazar `Demos/.../tests/MovilidadUrbana.Asistente.Tests/Comun/ReglaDeCapas.cs` por el de `Examples/13` (adaptando el predicado a `Func<Type,bool>` o envolviendo `Prohibido`) y sumar a `ArquitecturaTests` el caso rojo «argumento genérico de método» (el de `evidencia-arquitectura/03-…`). Si no se toca código, agregar en §4.6.3, después de la frase de la demo: «Su motor es una versión anterior: no mira argumentos genéricos de método ni atributos, así que un `AddSingleton<ChatMessage>()` en el núcleo pasa (medido sin modelo, 2026-10-28).»

### ARQUIT-04 · El diagrama único de §4.5 no coincide con la demo en tres puntos — S3 · coherencia

**Ubicación.** Guía §4.5, mermaid (l. 711–770): nodos `PORTS` (l. 729), `PERS` (l. 734), arista `CNEW --> UCN` (l. 751). Demo `Agregado/Application/Abstractions/PuertosDeIA.cs`, `Agregado/Infrastructure/Persistence/LecturaDeResultadosEf.cs`, `Agregado/Infrastructure/AI/ComposicionDeIA.cs` l. 79, `AsistenteController.cs` l. 22.

**Evidencia (lectura).** (1) Falta el adaptador de persistencia agregado: `LecturaDeResultadosEf` (EF Core, `Agregado/Infrastructure/Persistence`) implementa `ILecturaDeResultados`, que usa `ResultadosDeEncuestaService`; el diagrama sólo dibuja «Persistence: EF Core SQLite (copia)». §9.3.1 sí lo lista. (2) `PORTS` se rotula «Puertos hacia la IA» pero `PuertosDeIA.cs` incluye `ILecturaDeResultados` (persistencia) e `IHistorialDeConversacion` (estado), que no son de IA. (3) `[EnableRateLimiting(LimitadorDelModelo.Politica)]` está a nivel de **clase**: los tres endpoints, también `/localidades/desde-texto` y `/encuestas/pasos/2/desde-texto`, pasan por el limitador; la arista `CNEW --> UCN` los dibuja saltándolo, contra el punto 3 del propio diagrama («el limitador va en la entrada»). Además, el registro de `LecturaDeResultadosEf` vive en `ComposicionDeIA.AddCapaDeIA` (namespace `Infrastructure.AI`), así que la capa de IA registra persistencia: la «raíz de composición que sólo registra» de §4.6.3 está, en la demo, partida entre `Program.cs` y un tipo de la capa de IA.

**Propuesta.** En el mermaid de §4.5: cambiar `PORTS["Puertos hacia la IA: IExtractorDeLocalidad, IExtractorDeBaja, IAyuda, otros"]` por `PORTS["Puertos del agregado: IExtractorDeLocalidad, IExtractorDeBaja, IAyuda, IConsultaConHerramientas; ILecturaDeResultados, IHistorialDeConversacion"]`; agregar dentro de `INF` el nodo `PERSA["Persistence agregada: LecturaDeResultadosEf (EF Core)"]` y la arista `PERSA -.->|implementa| PORTS`; reemplazar `CNEW --> UCN` por `LIM --> UCN`. En `ComposicionDeIA.cs`, mover `services.AddScoped<ILecturaDeResultados, LecturaDeResultadosEf>();` a `Program.cs` (bloque «Lo agregado») para que la capa de IA no registre persistencia; si no se mueve, decirlo en §9.3.1: «`AddCapaDeIA` registra también la lectura de conteos (persistencia agregada)».

### ARQUIT-05 · `Examples/05` pone en `Persistence` un tipo que genera embeddings: contradice §4.2.2 y la regla «la persistencia no conoce IA» — S3 · coherencia

**Ubicación.** Guía §4.2.2 (l. 611) y §6.6.3 (l. 1579 y ss., los tres snippets con ruta `Infrastructure/Persistence/AlmacenDeRequisitos.cs`). `Examples/05/.../Infrastructure/Persistence/AlmacenDeRequisitos.cs` l. 1–6 y 26.

**Evidencia (lectura).** `AlmacenDeRequisitos` está en `MovilidadUrbana.RagEnMemoria.Infrastructure.Persistence`, recibe `IEmbeddingGenerator<string, Embedding<float>>` (`using Microsoft.Extensions.AI;`) y `IOptions<OpcionesDeIA>` del namespace `Infrastructure.AI`, y su comentario dice «Los embeddings los genera este adaptador, no el almacén». §4.2.2 enseña lo contrario: «el código que busca es un adaptador de IA y el almacén es persistencia». Con las familias de `Examples/13`, la regla «La persistencia no conoce IA» lo marcaría rojo.

**Propuesta.** Texto, en §6.6.3 después de «El texto y la fuente van aparte del vector…»: «`AlmacenDeRequisitos` junta dos roles: genera el embedding de la consulta (adaptador de IA) y guarda la colección (persistencia). Vive en `Infrastructure/Persistence` por simplicidad del ejemplo; con la prueba de `Examples/13`, la regla «la persistencia no conoce IA» lo marcaría, y se separaría en un buscador en `Infrastructure/AI` que usa el generador y una colección en `Persistence` (§4.2.2).» Alternativa en código: mover el archivo a `Infrastructure/AI/` y actualizar las tres rutas de §6.6.2–§6.6.3.

### ARQUIT-06 · La guía no dice dónde va un workflow de MAF en las capas, y las dos piezas que orquestan lo hacen distinto — S3 · coherencia

**Ubicación.** Guía §7.2 último párrafo (l. 1917), §7.6.2. `Examples/10/.../Infrastructure/Workflows/WorkflowDeAlta.cs` l. 2 y 46; demo `Agregado/Application/Asistente/AsistenteDeMovilidad.cs`.

**Evidencia (lectura).** §7.2 ubica herramientas, servidor MCP, `IChatClient` y agente, pero no el workflow. En `Examples/10` el workflow de alta (extraer → revisar → confirmar → registrar) está en `Infrastructure/Workflows`, toma `LocalidadService` y `IExtractorDeAlta` y no tiene puerto de Application delante (`Construir` estático). En la demo, el orquestador del turno (`AsistenteDeMovilidad`) vive en Application, «es núcleo: los pasos con modelo llegan por puertos». El lector no puede inferir la regla: ¿la orquestación es núcleo o infraestructura?

**Propuesta.** En §7.2, a continuación del texto de ARQUIT-02, agregar: «Un **workflow de MAF** es orquestación que nombra tipos de MAF (`WorkflowBuilder`, executors), así que no puede ir en Application: va en `Infrastructure/Workflows`, detrás de un puerto de Application que no expone tipos de MAF, y sus executors llaman a los casos de uso igual que las herramientas (la misma reentrada). Si el orden se escribe con código propio y los pasos con modelo llegan por puertos, como el turno de la demo (`AsistenteDeMovilidad`), la orquestación es núcleo. `Examples/10` expone el workflow sin puerto porque es un ejemplo de API, no de capas.»

### ARQUIT-07 · El diagrama de §5.3 dibuja la dependencia al revés — S3 · coherencia

**Ubicación.** Guía §5.3, mermaid (l. 945–955): `P["Application: puerto del dominio"] --> A["Infrastructure/AI: adaptador"]`.

**Evidencia (lectura).** La flecha va de Application a Infrastructure. En el diagrama único de §4.5 la misma relación es `ADP -.->|implementa| PORTS`, y la regla de §4.3.2 dice que Infrastructure depende del núcleo. Un lector que estudia §5 justo después de §4 ve la regla invertida en la primera figura.

**Propuesta.** Reemplazar las dos primeras líneas del flowchart por:

```
  U["Application: caso de uso"] --> P["Application: puerto del dominio"]
  A["Infrastructure/AI: adaptador"] -.->|implementa| P
```

y dejar `A --> I["IChatClient"]` como está; la frase previa («El caso de uso llama a un puerto; el adaptador recibe `IChatClient`…») ya coincide.

### ARQUIT-08 · §9.9.3 atribuye al adaptador la normalización que en la demo hace el caso de uso — S4 · coherencia

**Ubicación.** Guía §9.9.3 (l. 3477): «el adaptador invoca al normalizador del núcleo y después al caso de uso».

**Evidencia (lectura).** La pregunta trata el JSON de una extracción (D1). En la demo, quien normaliza es el caso de uso agregado `ProponerLocalidadDesdeTexto` (`Agregado/Application/Localidades/PropuestasDeLocalidad.cs` l. 48–59), como dice §9.5.1 («El caso de uso agregado la valida sin persistir»); el adaptador (`ExtractoresLlm`) sólo devuelve la propuesta. La frase vale para las herramientas (§7.13.6, B.2), no para la extracción.

**Propuesta.** En §9.9.3 reemplazar «el adaptador invoca al normalizador del núcleo y después al caso de uso» por «el caso de uso agregado pasa la propuesta por el normalizador del núcleo y después por las reglas copiadas».

## 3. Revisado y bien

1. **La corrección de la imagen de partida (§4.2) es sólida y honesta**: describe la diapositiva sin atribuirle fuente que no tiene, separa lo que se sostiene (la IA no habla con el frontend, con cita a la arquitectura de referencia) de lo que simplifica (progresión no obligatoria, «Vector DB» duplicado, la franja «en el medio»), y remite al diagrama de trabajo.
2. **La prueba de `Examples/13` forma criterio de verdad** (§4.6): inspecciona firma e IL, cada regla comprueba que inspeccionó tipos, las excepciones se declaran con motivo y otra prueba falla si sobran, los agujeros (`SoloUsing`, `Nameof`) se afirman verdes a propósito, y el contraejemplo del `grep` con `global using` está medido. La sonda (b) confirmó que su motor también ve un argumento genérico de método.
3. **La frontera copia/agregado de la demo está bien construida y documentada**: `PROCEDENCIA.md` fija commit, método (`git archive`), las seis carpetas como cierre de compilación con `diff -r` y compilación aislada guardadas, los desvíos (piezas adaptadas de la web, middleware sólo bajo `/api`, versión de EF Core) y la deuda heredada; §9.3 la refleja sin contradicciones y muestra que los dos caminos dan resultados distintos en vez de esconderlo.

## 4. Fuera de mandato

No se opina sobre cifras contra el modelo, bibliografía, didáctica ni seguridad más allá de su ubicación en capas.
