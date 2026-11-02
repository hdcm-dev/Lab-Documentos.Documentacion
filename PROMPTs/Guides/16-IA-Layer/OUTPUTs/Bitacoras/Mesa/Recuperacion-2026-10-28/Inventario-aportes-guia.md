---
doc_id: BIT-16-REC2-INV-aportes-guia
doc_type: inventario-de-mesa
title: Inventario «aportes-guia». Lo que la línea de <equipo-de-contingencia> aporta a la guía de la base
status: emitido
origin: agent
last_review: 2026-10-28
traces: [Linea-*-2026-10-28/Guia, Linea-*-2026-10-28/Bitacoras/Mesa/Ciclo-2/Informe-*.md, Linea-*-2026-10-28/Bitacoras/Mesa/Ciclo-1/Ronda-2, Linea-*-2026-10-28/Bitacoras/Mesa/Ciclo-1/06-Plan-De-Redaccion.md §10, Linea-*-2026-10-28/Bitacoras/Sondeo-Entorno.md §R]
---

# Inventario «aportes-guia» (mesa de recuperación, 2026-10-28)

## 0. Alcance, método y lectura

- **BASE** es la guía 0.10.1 de <equipo-principal>, restaurada en `Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Dot-Net-Integration-AI-Layer-Guide.md`: 5128 líneas, §0–§15 y Anexos A–G, 17 `Examples/`. Las líneas citadas como «B l. N» se refieren a ese archivo.
- **INSUMO** es la guía de <equipo-de-contingencia>, `Linea-*-2026-10-28/Guia/Dot-Net-Integration-AI-Layer-Guide.md`, con 4116 líneas. Las líneas se citan como «H l. N». Junto con ella entraron los 13 `Informe-*.md` de la relectura del ciclo 2, las consultas PC-01…PC-15 de `Ciclo-1/Ronda-2/` y §10 de `06-Plan-De-Redaccion.md`.
- **Las dos guías no comparten numeración.** Difieren las secciones y la numeración de los ejemplos: el `Examples/09` de <equipo-de-contingencia> no es el 09 de la base. Por eso cada unidad ubica el tema en las dos guías por contenido y no por número.
- **Método.** Se buscó con `grep` en la base cada hecho medido, cada regla y cada hallazgo del insumo, y se leyó el párrafo encontrado. No se compiló ni se corrió nada contra el modelo, porque esta mesa no lo hace.
- **Estado de la base:**
  - La base no tiene IPs (`grep -E '\b100\.[0-9]+\.'` = 0 sobre la carpeta de la guía).
  - Los mensajes de salto de `PredicadoDeSalto.cs` ya no incluyen el endpoint (l. 25).
- **Lo que pesa más.** La base midió el 4b como `qwen3.5:4b@2a654d98e6fb` en Ollama 0.32.0-rc0, en el «servidor compartido» que ya no existe: el rótulo aparece 53 veces. <equipo-de-contingencia> midió `qwen3.5:4b@d8b0f5e9760c` en Ollama 0.40.11, en las **dos estaciones vigentes** (la de 4 núcleos y la de más núcleos). Los digests son distintos, así que no es el mismo artefacto. Por eso las cifras de <equipo-de-contingencia> son las únicas que hoy pueden figurar como «medido» sin volver a correr. Igual tienen que pasar por la regla de rótulo (estación y estimando) y por la conversión de intervalos de APOR-15.
- **Severidad.**
  - S1: bloquea la publicación.
  - S2: afirma algo falso o inseguro de copiar, o falta un hecho medido que cambia una regla.
  - S3: completa o precisa.
  - S4: retoque, o constatación de que la base ya está bien.

## 1. Resumen

| Severidad | Unidades |
|---|---|
| S2 | APOR-01, 02, 06, 08, 09, 11, 13, 15, 18, 19, 21 |
| S3 | APOR-03, 04, 05, 07, 10, 12, 14, 16, 17, 20, 22, 23, 25, 27 |
| S4 | APOR-24, 26, 28 |

Tres hallazgos de <equipo-de-contingencia> **no se trasladan** porque la base ya resolvió lo mismo de otra forma o mejor (§3).

## 2. Unidades

### APOR-01 · S2 · Entorno de las cifras: el 4b de la base no es el 4b vigente
- **Base:**
  - F.4 (B l. 5073–5084) declara «Servidor Ollama compartido del laboratorio 0.32.0-rc0» y «`qwen3.5:4b`, digest `2a654d98e6fb`».
  - 53 cifras del cuerpo dicen «servidor compartido». Algunos ejemplos: §5.4 (l. 1011, 1015), §8.5 (l. 1982), §11.7 (l. 3165) y §12.4 (l. 3381).
- **<equipo-de-contingencia>:**
  - `Sondeo-Entorno.md` §R, «el servidor medido ya no existe», con §R.6: una tabla única de 28 filas, regenerable con `cifras.py` desde los `.jsonl` crudos, y 5 filas más de P2-10 con la columna «servidor».
  - La guía, en E.3 y E.4 (H l. 3993–4041), usa `qwen3.5:4b@d8b0f5e9760c`, Ollama 0.40.11, en las dos estaciones.
- **Juicio.** La base no puede seguir afirmando como medidas las cifras del 4b. <equipo-de-contingencia> trae el único juego de cifras tomado en servidores vigentes, con crudos y script.
- **Acción.**
  - Rotular «historia (servidor retirado)» todas las cifras de la base con «servidor compartido».
  - Reemplazar las que la guía necesita como «medido» por la fila equivalente de §R.6 o de la tabla de <equipo-de-contingencia>, cuando el estímulo es comparable. Si no lo es, volver a correrlas en la estación 1 o en la 2.
  - Cambiar F.4 para que nombre el digest `d8b0f5e9760c` y 0.40.11.

### APOR-02 · S2 · Latencia y costo locales en las estaciones vigentes
- **Base.** Hay tres pasajes:
  - §5.4 (l. 1014): «Latencias de minutos… 91,7 s y 123,1 s», servidor compartido.
  - §12.3 (l. 3351–3373) define costo y latencia sin ninguna cifra local.
  - §12.4 (l. 3381) describe el servidor compartido.
- **<equipo-de-contingencia>:**
  - E.3 y E.4 (H l. 4001–4002, 4011–4038) dan la lectura del prompt con el 4b: unos 19 tok/s (13–22) en la estación de 4 núcleos y 107,5–110,3 tok/s en la de más núcleos. La generación va de 7,4 a 10,7 tok/s en la primera y de 11 a 13 tok/s en la segunda.
  - En la estación de 4 núcleos, un prompt de 2943 tokens tardó 167 s (pared 168,20 s, VERIFI-05). Eso son unos 50 s por cada 1000 tokens de prompt sin caché (ADV-01).
- **Juicio.** Es justo el dato que le falta a la base para que ACT-ARQ decida entre contexto fijo, RAG y servidor (ADR-03 y ADR-04). Además corrige la impresión de que «en local cuesta poco»: ADV-01 lo mostró en <equipo-de-contingencia>, y el criterio aplica igual en la base.
- **Acción.**
  - Sumar en §12.3 una tabla corta por estación, tomada de §R.6 y con su rótulo.
  - Atender VERIFI-02: el rango 13–22 tiene que coincidir con la fila de la tabla.
  - En §12.4, reemplazar el párrafo del servidor compartido por las dos estaciones vigentes, descritas sin nombres de equipo.

### APOR-03 · S3 · Caché de prefijo con el 4b: la base dice «no medida» y <equipo-de-contingencia> la midió
- **Base.** §5.4 (l. 1015): «Con `qwen3.5:4b` no está medida; lo de §6.3 es de `qwen2.5:0.5b`». §6.3 y §6.4 (l. 1375–1409) sólo tienen la cifra del 0,5b.
- **<equipo-de-contingencia>.** §6.4 (H l. 1465–1471, 1803) y E.4 (l. 4031):
  - El reuso fue **parcial**. Con un prompt de ayuda de unos 1541 tokens, cambiar sólo la pregunta bajó la pared de 71,7 s en frío a 26,0 s. Fue una corrida por caso, en la estación de 4 núcleos.
  - El reuso pleno aparece con el prompt idéntico.
- **Juicio.** Llena un hueco que la base declara abierto. Es N = 1, así que entra como existencia y no como tasa.
- **Acción.** Sumar el dato en §6.3 o §6.4 con el rótulo «una corrida por caso, estación de 4 núcleos». Si la base lo va a usar como argumento de costo, repetirlo en la estación 1 con el prompt de su `Examples/05`.

### APOR-04 · S3 · Truncado silencioso con el 4b
- **Base.** §5.4 (l. 1013) mide sólo con `qwen2.5:0.5b`: 5714 tokens con la capa y 2050 sin ella, sin error. La guarda está en `GuardaDeTruncado.cs`.
- **<equipo-de-contingencia>:**
  - §6.5 y §8.8 (H l. 1508–1509, 1532, 3015–3017) miden el 4b `d8b0f5e9760c`. Con `num_ctx` 8192 entraron 5114 tokens en 3 de 3 semillas. Con 4096 entraron 2050 en 3 de 3, con fin `stop` y sin error, y el detector lanzó la excepción «esperado 5114, recibido 2050». Fue en la estación de más núcleos.
  - El mismo texto mide 5114 tokens con el tokenizador del 4b y 5134 con el del 0,5b: el largo esperado se estima con el modelo que va a leer el pedido.
  - EXPERT-03 y EXPERT-04 dejan dos cautelas: no atribuirle al 4b respuestas del modelo de humo, y no afirmar «se perdió el principio», porque qué tramo se conserva no se midió.
- **Juicio.** El insumo extiende al modelo de chat una regla que la base sólo midió con el modelo de humo, y le suma la lección del tokenizador. La base no dice «se perdió el principio» (`grep` = 0): no hay que corregir eso.
- **Acción.** Sumar en §5.4 o §6.5 la fila del 4b con su rótulo y la frase sobre el tokenizador. Antes, verificar que `GuardaDeTruncado` estime con el modelo de la llamada.

### APOR-05 · S3 · `num_ctx`: depende de la configuración del servidor, no de su estado, y conviene el mismo valor en todos los clientes
- **Base:**
  - §5.4 (l. 1013) cita el valor por defecto de 4096, o uno «que depende de la memoria de video» [REF-55, REF-56].
  - E.3 (B l. 4894) lee `/api/ps` y exporta la ventana del modelo cargado.
- **<equipo-de-contingencia>:**
  - PC-06 y P2-09: sin `num_ctx`, Ollama 0.40.11 recarga el modelo con 4096. Es configuración del servidor, no lo que haya quedado cargado.
  - H l. 1067: alternar valores recarga el 4b, con 10,5–16,1 s de `load_duration` (N = 5, estación de 4 núcleos). La vía `/v1`, que no manda `num_ctx`, cuenta como otro valor.
- **Juicio.** Completa la regla de la base y le da fundamento medido: leer `/api/ps` sirve porque no se debe alternar. Mezclar clientes por la vía nativa y por `/v1` sobre el mismo modelo provoca recargas.
- **Acción.** Sumar la regla «mismo `num_ctx` en todos los clientes de un modelo» en §5.4 y §12.4, con la cifra de recarga y su rótulo.

### APOR-06 · S2 · Diferencias medidas entre la vía nativa y `/v1`: faltan filas en la tabla de §5.6
- **Base.** La tabla de §5.6 (B l. 1000–1005) tiene cuatro filas: forzar herramienta, ventana, razonamiento y duraciones. No menciona `TopK` (`grep` = 0), y sobre `MaxOutputTokens` por `/v1` no dice nada.
- **<equipo-de-contingencia>.** La «tabla única» de §5.7 (H l. 1180–1192) y PC-05:
  - MEAI.OpenAI **descarta `TopK` en silencio**.
  - Por `/v1`, `MaxOutputTokens` se traduce a `max_completion_tokens`, y Ollama 0.40.11 **no acota** la salida: se pidieron 3 tokens y salieron 57. Por eso tampoco acota la pared.
  - El mensaje `tool` viaja distinto en cada vía.
  - `CachedInputTokenCount` queda `null` por la vía nativa.
  - Las filas las reproduce sin modelo una captura de cuerpo con servidor falso.
- **Juicio.** El `Examples/02` de la base cambia a `/v1` sobre el mismo Ollama. Quien copie un tope de salida o `TopK` cree que lo aplicó y no es así. Es un hecho medido que cambia una regla de configuración.
- **Acción.**
  - Sumar las filas `TopK`, `MaxOutputTokens`, mensaje `tool` y `CachedInputTokenCount` a la tabla de §5.6.
  - Sumar una prueba de captura de cuerpo sin modelo en `Examples/02` y registrarla con su rótulo.
  - Antes de afirmar «3 → 57» como medido, volver a correrlo en la estación 1.

### APOR-07 · S3 · Cómo leer el reuso del prefijo con OllamaSharp 5.5.0
- **Base.** §6.3 (B l. 1393): «OllamaSharp no [llena `CachedInputTokenCount`], y deja las duraciones del servidor en `AdditionalProperties`». §6.4, tabla (l. 1405): «`CachedInputTokenCount`, si el adaptador lo informa». La versión fijada es la misma, OllamaSharp 5.5.0 (F.1, l. 5011).
- **<equipo-de-contingencia>.** H l. 1471 y PC-04: el servidor informa `prompt_eval_cached_count` en la última línea NDJSON de `/api/chat`. OllamaSharp 5.5.0 no lo expone. Se lee con un `DelegatingHandler` en el `HttpClient` del proveedor, o por `/v1`, y una prueba sin modelo lo fija con un NDJSON grabado.
- **Juicio.** La base deja al lector sin un camino para observar la caché de prefijo. <equipo-de-contingencia> se lo da, con la misma versión del paquete.
- **Acción.** En §6.4, reemplazar «si el adaptador lo informa» por el hecho y el camino (handler u `/v1`). Opcional: sumar el handler y su prueba a `Examples/05`.

### APOR-08 · S2 · Las credenciales del proveedor no van en un campo que viaje en el cuerpo
- **Base.** §11.6 (secretos) y A.12 no dicen nada sobre esto. `grep` de la propiedad de cabeceras del pedido de OllamaSharp: 0.
- **<equipo-de-contingencia>.** PC-03 y P2-01/P2-08, RV-01 ampliada:
  - OllamaSharp 5.5.0 serializa en el **cuerpo JSON** las cabeceras que se le pasan al pedido.
  - Las credenciales van en el `HttpClient` de `IHttpClientFactory` o en un `DelegatingHandler`, que las manda como encabezado (H l. 1192).
  - Toda captura de cuerpo que se publique pasa la compuerta `cabeceras=0`.
- **Juicio.** Un lector que pase a un proveedor con clave puede filtrarla en los registros y capturas de cuerpo que la guía misma le enseña a guardar.
- **Acción.**
  - Sumar la regla en §11.6 y en A.12, sin nombrar la propiedad: el R-PRIV ampliado de esta mesa prohíbe ese identificador en la guía, en `Examples/` y en `Demos/`. Se puede decir «el diccionario de cabeceras del pedido de OllamaSharp».
  - Sumar la compuerta `cabeceras=0` a las capturas.

### APOR-09 · S2 · Caché de respuestas: la clave tiene que llevar la sesión, y la versión de los datos si hay herramientas
- **Base:**
  - §5.4, diagrama (B l. 904) y §12.3 (l. 3355): «las opciones son parte de la clave».
  - «Con la caché por fuera de la invocación de funciones, un acierto devuelve la respuesta final **sin volver a ejecutar herramientas**», presentado como ventaja (l. 924).
  - `Examples/17` usa `UseDistributedCache`.
  - No hay ninguna mención de la sesión en la clave.
- **<equipo-de-contingencia>:**
  - PC-02 midió sin modelo: si la clave no incluye la sesión, **la sesión B recibe la respuesta cacheada de A**. Se corrige con `CacheKeyAdditionalValues = [SessionId]`.
  - §8.5.3 (H l. 2835, 2920, 3168): como un acierto no vuelve a ejecutar herramientas, con herramientas la clave suma `VersionDeDatos`, o directamente no se cachea.
  - El contador de aciertos va aparte (RV-03).
- **Juicio.** En el caso, la sesión es la frontera de los datos (CTX-SENS). Tal como la enseña la base, la caché es un cruce de sesiones posible, y el «no reejecuta» también sirve datos viejos.
- **Acción.**
  - En §12.3, sumar las dos reglas con su prueba.
  - En `Examples/17`, sumar la clave con `SessionId` y una prueba sin modelo: dos sesiones con el mismo texto dan dos fallos de caché.
  - En §5.4, matizar la frase del diagrama.

### APOR-10 · S3 · Dónde va el límite de concurrencia
- **Base.** §12.3 (B l. 3373): «Una capa propia con un `RateLimiter` acota los pedidos simultáneos» (la sitúa en el pipeline del cliente). Según l. 3463, la demo no usa limitador.
- **<equipo-de-contingencia>.** §8.6 (H l. 2937–2950) pone el límite **en la entrada HTTP** y no dentro de la cadena de `IChatClient`, con 503 y `Retry-After`. La razón es medida: `OLLAMA_NUM_PARALLEL` = 1 y llamadas de 167 s en la estación de 4 núcleos, así que sin límite el pedido termina en un 500 por timeout. AH-02--07 suma que la prueba del 503 no debe depender del orden de llegada.
- **Juicio.** Las dos guías discrepan en el diseño. El argumento de <equipo-de-contingencia> (una respuesta interpretable por el cliente y cifras vigentes) es más fuerte para CTX-LOCAL. La base no lo contradice con evidencia propia.
- **Acción.** La mesa elige. Default propuesto: adoptar la entrada HTTP en §12.3 y mencionar la capa del cliente como alternativa. Si se suma código, la prueba del 503 tiene que ser determinista.

### APOR-11 · S2 · Ciclo de vida: un Singleton cruza sesiones sin dar error
- **Base.** ADR-12 y §13.13 (B l. 3739–3750) y la prueba `Composicion_ValidateScopes` (l. 3746, 3969). `grep Singleton` = 0. La base no describe el modo de falla.
- **<equipo-de-contingencia>.** §8.7 (H l. 2998–3008), PC-11 y P2-05/D-06, medido sin modelo con dos sesiones concurrentes:
  - **Singleton con `ValidateScopes = false`:** B ve y borra la localidad de A, **sin ningún error**. El cruce es de datos y también de autorización, porque la autorización es el filtro por `SessionId`.
  - **Singleton con `true`:** no falla al construir el contenedor, sino en **cada llamada a la herramienta**.
  - `ValidateOnBuild` no se probó.
  - La cita es DI overview, §«Scope validation» (ms.date 2026-01-26).
- **Juicio.** Es el antipatrón más caro del caso, porque rompe la única frontera que tiene la demo, y la base sólo muestra la configuración buena.
- **Acción.** Sumar el caso rojo a §13.13 y al Anexo B, con la prueba concurrente (a)–(c), en la pieza de la base que arma herramientas por sesión (`Examples/08` y la demo). Corregir la frase sobre cuándo falla.

### APOR-12 · S3 · Blazor Interactive Server: «Scoped» quiere decir el circuito
- **Base.** El circuito aparece en §0.3 (l. 137), en l. 971 (una sesión de chat por conexión), en l. 2059 y 2435 (el historial en el circuito) y en ADR-12 (l. 3741). La relación entre los servicios Scoped y el `DbContext` no se explica.
- **<equipo-de-contingencia>.** SENIOR-01 propone el texto: el ámbito es el circuito, así que alcanza para aislar sesiones pero no sirve para un `DbContext` Scoped (vive horas y no admite operaciones concurrentes). Por eso se usa `AddDbContextFactory`, con la cita de Microsoft Learn, «Blazor with EF Core».
- **Juicio.** La base hace PD-6 con el historial en el circuito, así que el riesgo de copiar es el mismo.
- **Acción.** Verificar que `Demos/.../Infrastructure/Persistence` registre la fábrica. Después, sumar el párrafo en §5.5 o §13.13 y la referencia.

### APOR-13 · S2 · El LLM juez con el 4b: los evaluadores sin referencia no detectaron una respuesta incorrecta
- **Base:**
  - §10.5 y §10.6 (B l. 2875–2905): el juez es `qwen2.5:0.5b`, «no calibrado», y ninguna de sus 52 salidas fue interpretable.
  - §6.6/§7 (l. 1661) recomienda `RetrievalEvaluator` y `GroundednessEvaluator`.
  - `Examples/15` usa `RelevanceEvaluator` y `GroundednessEvaluator` (`grep` sobre el código). `Equivalence` y `Completeness`: 0.
- **<equipo-de-contingencia>.** PC-08, AH-02--01, AH-02--02 y E.4 (filas 4 y 4b de §R.6). El juez fue el 4b `d8b0f5e9760c`, en la estación de más núcleos:
  - Con cuatro casos escritos a mano, una respuesta **incorrecta** sacó 4 («Good») en Relevance y en Coherence, y una correcta sacó 2 («Poor») en Relevance. Completeness y Equivalence, que comparan contra una referencia, le dieron 1 a la incorrecta. Es existencia, con N = 1 por celda.
  - Con el razonamiento por defecto, el juez agota los 800 tokens del evaluador de Relevance.
  - Costo: unos 34 s por evaluación en la estación de más núcleos y 1285 s por caso con 7 evaluadores en la de 4 núcleos.
  - Si el juez y el generador son el mismo modelo, hay autofavorecimiento.
- **Juicio.** La base sólo pudo decir «el 0,5b no sirve de juez». <equipo-de-contingencia> muestra la lección que la guía tiene que enseñar: relevancia y coherencia no son verdad, y con oro conviene un evaluador con referencia. Hoy la base recomienda justo los evaluadores que fallaron.
- **Acción:**
  - En §10.6, sumar «lo que vio el laboratorio» rotulado como existencia.
  - En `Examples/15` y §10.5, sumar `EquivalenceEvaluator`, o `CompletenessEvaluator`, con la respuesta del oro.
  - Verificar que el cliente del juez pase por la capa de opciones (razonamiento apagado y `num_ctx` ≥ 8192). Los evaluadores mandan sus propias `ChatOptions`, pero el `??=` de la capa (B l. 943) debería cubrirlo.
  - Antes de publicar como medido, repetir la sonda en la estación 2.

### APOR-14 · S3 · Una prueba del juez puede pasar en verde sin medir nada
- **Base.** El arnés de `Examples/15` cuenta las salidas interpretables y decide «no descartado / descartado» (B l. 2992–2995). Separa así «no respondió» de «dio un puntaje».
- **<equipo-de-contingencia>.** AH-02--01: en <equipo-de-contingencia> la prueba equivalente afirmaba sólo `Metrics.Count == 4` y pasó con todas las métricas `Inconclusive` o cortadas por timeout.
- **Juicio.** La base está mejor protegida. Lo que se traslada es el control: un `Inconclusive` o un diagnóstico `Error` no puede contar como acuerdo ni como puntaje.
- **Acción.** Verificar en `Examples/15` que una métrica sin `Interpretation`, o con un diagnóstico de error, cuente como «no interpretable». Si no cuenta así, corregirlo.

### APOR-15 · S2 · Intervalos: la base usa Clopper-Pearson y <equipo-de-contingencia> usa Wilson
- **Base.** §0.4 (l. 168), §10.4 (l. 2829) y el glosario (l. 4597) usan IC95 de Clopper-Pearson, calculado con `tools/verificar.sh tasa`: 0/10 da [0; 0,308] y 0/6 da [0; 0,459].
- **<equipo-de-contingencia>.** Usa Wilson 95 % en todas sus cifras: 0/10 da [0; 0,28]. AH-02 recalculó los 93 intervalos de su guía con `evidencia-AH-02-evaluacion-llm-rag/01-wilson-check.py` y no encontró discrepancias. CAT-FO-07 marca que dos cotas para 0/10 confunden al lector.
- **Juicio.** Toda cifra que pase de <equipo-de-contingencia> a la base (APOR-03, 06, 13, 18, 19 y 20) trae un intervalo con otro método. Mezclarlos es una incoherencia formal visible.
- **Acción.** Recalcular con Clopper-Pearson, con `verificar.sh tasa`, cada k/n que se importe. Adaptar el script de AH-02 a Clopper-Pearson y correrlo sobre la base como compuerta de los IC95.

### APOR-16 · S3 · Declarar el estimando: «este pedido» o «la tarea»
- **Base:**
  - §10.4 (l. 2829–2830) habla de «k/M» sobre M entradas, con «M ≤ 12, descriptiva».
  - Hay tasas sobre un solo estímulo, por ejemplo §11.7: «una tasa sobre un solo texto de ataque».
  - No hay un rótulo explícito de estimando.
- **<equipo-de-contingencia>.** PC-10, R-LLM-3d y RV-17:
  - Las semillas de un mismo pedido no son una muestra de la tarea.
  - Una tasa de la tarea exige K ≥ 10 pedidos redactados antes y m ≥ 3 semillas por pedido, con el intervalo sobre los pedidos.
  - Toda tasa lleva «estimando: este pedido | la tarea».
- **Juicio.** El insumo formaliza lo que la base practica a medias, y evita que un 0/6 sobre un texto se lea como robustez.
- **Acción.** Sumar el estimando a la regla de §10.4 y a la cabecera de registro (A.10 y E.6). Revisar las tasas de la base que agregan semillas de un mismo pedido.

### APOR-17 · S3 · Cuarto tipo de aserción, «existencia», y cómo leer una caída del servidor
- **Base.** §10.1 y §10.4 (l. 2746–2830) distinguen invariantes, tasas descriptivas y deterministas. `PredicadoDeSalto` salta la prueba cuando no hay servidor al empezar.
- **<equipo-de-contingencia>:**
  - AH-02--03 y CAT-FO-04 suman el tipo «existencia»: la prueba falla si el hecho no se observó ni una vez en m semillas, y lo dice. También señalan que ninguna tasa debe hacer fallar una prueba.
  - IMPLEM-04: una excepción de conexión o de timeout a mitad de corrida no es una violación de invariante. Esas semillas quedan «no medido».
- **Juicio.** Las dos cosas valen para la base. Cubren lo que pasa cuando el servidor se cae después del salto inicial, que es lo que sucedió en la contingencia del 28-10.
- **Acción.** Sumar el tipo y la regla de lectura en §10.4. Revisar los `ConModelo/` de la base: buscar umbrales de tasa (`GreaterThanOrEqualTo(m - …)` dio 0) y el manejo de las excepciones de red durante la corrida.

### APOR-18 · S2 · Comparación del 2b frente al 4b, y por qué el 35b no es el modelo por defecto
- **Base.** No hay ninguna comparación (`grep qwen3.5:2b` = 0, `35b` = 0). El 4b figura como modelo de chat sin un rótulo de elección (F.4, A.12, l. 4378).
- **<equipo-de-contingencia>.** Plan §10.2 «§0.4», `Consulta-comparacion-2b-4b.md`, PC-07 y H l. 3433–3445:
  - D3, normalizar al catálogo: el 4b falló 0/10 y el 2b 10/10.
  - D1, respetar el dato inválido: el 4b inventó el CP 10/10 y el 2b 1/10.
  - D6, confirmar antes de borrar: ninguno de los dos, 10/10 cada uno.
  - «Difiere» vale sólo para ese pedido, en D1 y D3.
  - El 2b medido es `qwen3.5:2b@0689d44085e0`, Q8_0, 2,68 GB.
  - `qwen3.5:35b-a3b` ocupa 21 GiB, no se separa del 4b en herramientas y tarda 13,3 s por llamada frente a 3,2 s.
  - ADV-05 y EXPERT-05 agregan dos límites: no trasladar la elección a otra composición, y no concluir «no depende del tamaño» a partir de dos modelos chicos.
- **Juicio.** Es la única evidencia que funda el rótulo «provisional» del 4b. Además da el dato de seguridad «ninguno confirma antes de borrar», que apoya la aprobación obligatoria de la base. Todo esto se midió en servidores vigentes.
- **Acción.** Sumar en §5.7, F.4 o el ADR-03 un rótulo de elección del modelo con estas cifras, recalculadas con Clopper-Pearson (APOR-15) y con sus límites. Citar D6 en §8.5 como existencia.

### APOR-19 · S2 · Un dato inventado con forma válida pasa las reglas: el caso «34 → 3400»
- **Base:**
  - §8.5 (B l. 2010): «09 deja pasar el «34» a la aprobación a propósito… quien no deja escribir es `SaveAsync`».
  - El `Examples/03` de la base ya descarta campos que no están en el texto: «descartado por no estar en el texto: habitantes» (l. 1214–1220).
  - `grep 3400` = 0.
- **<equipo-de-contingencia>.** §5.6 (H l. 886, 1144), §2.5 (l. 409) y §9.5.1 (l. 3352):
  - Con «CP 34» y la instrucción «No inventes ni corrijas datos», el 4b devolvió «3400» en 8/10, por `/api/chat` con esquema, en la estación de más núcleos. Por `/v1` con herramientas, cambió el CP en 10/10, en la de 4 núcleos.
  - «3400» cumple la regla de 4 dígitos y llega a la pantalla sin error.
- **Juicio.** Contradice el argumento de §8.5: con «3400», `SaveAsync` no frena nada. El control determinista de fidelidad que la base ya tiene para habitantes es la respuesta correcta (ADV-02 la propone en <equipo-de-contingencia>), pero la base no muestra que cubra el código postal.
- **Acción:**
  - En §8.5, sumar el caso medido, rotulado y recalculado.
  - Verificar que el descarte por «no está en el texto» cubra todos los campos de `LocalidadPropuesta`, incluido el CP. Si no los cubre, extenderlo y probarlo sin modelo con un guion que proponga «3400».
  - Volver a correr el pedido en la estación 1 antes de afirmarlo.

### APOR-20 · S3 · Inyección indirecta por el nombre de una localidad: cifra vigente y la observación «repite el texto»
- **Base.** §11.7 (B l. 3161–3168): cada variante dio 0/6 pedidos de baja inducidos, IC95 [0; 0,459], con el 4b `2a654d98e6fb` en el servidor compartido. La composición tiene una herramienta de baja aprobable.
- **<equipo-de-contingencia>.** §8.10.1 (H l. 3086), PC-14 y P2-12, con la composición de la demo, que no tiene herramienta de escritura:
  - Propuso una baja en 0/10.
  - Pidió una herramienta inexistente en 0/10.
  - **Le repitió el texto inyectado a la persona en 10/10**, y lo señaló como sospechoso en 3/10, por lectura manual.
  - Se midió en una estación vigente.
  - La frase de <equipo-de-contingencia> tiene una doble negación que invierte el sentido (AH-02--04, EXPERT-01): no hay que copiarla.
- **Juicio.** La cifra de la base es historia. La de <equipo-de-contingencia> es de otra composición, así que no la reemplaza, pero aporta un hecho nuevo: el texto inyectado vuelve a la persona. Eso es salida insegura o desinformación, aunque no haya escritura.
- **Acción.**
  - Volver a correr `Examples/16` en la estación 1 con el estimando declarado.
  - Sumar a §11.2 y §11.7 la observación «repitió el texto», rotulada como de otra composición.
  - Redactar la cifra sin negaciones.

### APOR-21 · S2 · Ollama no autentica, y la imagen fijada escucha en todas las interfaces
- **Base:**
  - E.3 (B l. 4896): «el servidor tiene que escuchar fuera del *loopback*, y se exporta la dirección de la puerta de enlace de la red *bridge*», sin ninguna advertencia.
  - El `compose.yaml` de la demo fija `ollama/ollama:0.40.11@sha256:dea72d1e…` para `ollama-embed`, sin `ports` (bien).
  - La página publica en `127.0.0.1:8080` (bien).
- **<equipo-de-contingencia>.** AH-01--01, con evidencia de ejecución: esa misma imagen trae `OLLAMA_HOST` con el comodín y registra «Listening on [::]:11434». El valor de loopback es el del binario, no el de la imagen. Ollama no tiene autenticación.
- **Juicio.** La base empuja al lector a abrir su Ollama a la red sin decirle que queda sin autenticación. Es una instrucción insegura de copiar.
- **Acción.**
  - En E.3, §12.6 y §11.6: «Ollama no autentica. Si lo abrís fuera del loopback, que sea sólo a la interfaz del bridge de docker, o publicá el puerto a `127.0.0.1`, nunca a todas las interfaces de una red compartida».
  - Dejar constancia del comportamiento de la imagen, verificado por digest.

### APOR-22 · S3 · MAF 1.26.0 ejecuta la llamada de una sesión guardada que fue alterada
- **Base.** §8.7 (B l. 2045): `Examples/11` serializa la `AgentSession` al final de la primera petición y la deserializa en la segunda, y «el servidor guarda sólo la sesión y el pedido pendiente». El `Examples/09`, sin MAF, rechaza los argumentos alterados (`Aprobacion_ArgumentosAlterados_SeRechaza`).
- **<equipo-de-contingencia>.** §7.5.3 (H l. 2169) y A5 (l. 2125): el caso rojo `CasoRojo_SinLaGuarda_MafEjecutaLoAlterado`. Si se altera la sesión guardada (el id de una localidad por el de otra), MAF pide ejecutar la llamada alterada. La solución es una guarda que compara con la copia que guardó el servidor al registrar la aprobación.
- **Juicio.** En la base la sesión no sale del servidor, así que el riesgo es menor. Pero quien persista la sesión en otro lado se lo lleva puesto, y la guía no lo dice.
- **Acción.**
  - Verificar si `Examples/11` tiene una guarda equivalente.
  - Sumar en §8.7 el hecho medido y la condición «la sesión serializada es estado no confiable si sale del servidor».
  - Si `Examples/11` no tiene la guarda, sumar el caso rojo.

### APOR-23 · S3 · MCP: un único catálogo de herramientas frente a dos definiciones
- **Base:**
  - §8.9 (B l. 2094): `Examples/13` publica con `[McpServerToolType]` y `[McpServerTool]`.
  - Ya valida `Origin` (l. 2430: 403) y cita la especificación 2026-07-28 (l. 3149).
  - Tiene la prueba `Herramientas_SinParametrosDeDi` (l. 3746).
- **<equipo-de-contingencia>.** PC-09, P2-07 y RV-21: un catálogo único de `AIFunction`, filtrado a lectura y publicado con `McpServerTool.Create`. Los atributos quedan sólo como «alternativa con dos definiciones». Las pruebas son `tools/list` igual al `JsonSchema` del catálogo y ninguna herramienta de escritura publicada. PC-01 confirma que el SDK 2.3.0 no valida `Origin`.
- **Juicio.** La seguridad de la base ya coincide con la de <equipo-de-contingencia>. La diferencia es de mantenimiento: dos definiciones de la misma herramienta pueden divergir.
- **Acción.** Lo decide la mesa. Si se mantienen los atributos, sumar la prueba «`tools/list` = esquema de la herramienta del bucle» y declarar la alternativa del catálogo único.

### APOR-24 · S4 · *Group chat* de MAF: el único gestor que trae el paquete rota por código
- **Base.** §8.8 (B l. 2066): «*group chat* cae en el 2 o en el 3 según quién elija al siguiente orador, el código o un modelo». Es correcto.
- **<equipo-de-contingencia>.** EXPERT-02: según el XML de `Microsoft.Agents.AI.Workflows` 1.26.0, el único gestor concreto es `RoundRobinGroupChatManager` («selects agents in a round-robin fashion»).
- **Juicio.** Precisa la frase de la base con un hecho verificable.
- **Acción.** Agregar en §8.8: «con el gestor que trae el paquete, por turnos (código)».

### APOR-25 · S3 · Agregados en CTX-PROD: celda mínima y supresión complementaria
- **Base.** §11.4 (B l. 3119 y ss.) dice «agregados sin `Nombre` ni `Edad`». No menciona celda mínima ni normativa (`grep "Ley 25"` = 0).
- **<equipo-de-contingencia>.** §8.10.3 (H l. 3094), CTRL-07 y P2-07:
  - En CTX-PROD, una celda con una sola respuesta identifica a la persona aunque no lleve el nombre.
  - Propone `TamanoMinimoDeCelda`, supresión complementaria y límite de cruces.
  - Cita la Ley 25.326, arts. 2 y 28 [InfoLEG], y la *CMS Cell Size Suppression Policy* (ResDAC) como práctica y no como norma.
- **Juicio.** Completa la frontera de CTX-SENS con un riesgo concreto y con fuente local.
- **Acción.** Sumar el párrafo y las dos referencias a §11.4 y al Anexo D (D.9), con la fecha de consulta.

### APOR-26 · S4 · OWASP sobre RAG: la base cita bien
- **Base.** §7.6 (B l. 1666): «RAG no mitiga del todo la inyección de prompt [REF-160]».
- **<equipo-de-contingencia>.** AH-01--04: <equipo-de-contingencia> decía «no mitiga». La fuente dice «do not fully mitigate».
- **Juicio.** La base ya está bien. No hay que importar la frase de <equipo-de-contingencia>.
- **Acción.** Ninguna. La compuerta de citas tiene que mantener «del todo».

### APOR-27 · S3 · La garantía contra la inyección tiene dos formas
- **Base.** En §11.2 y §11.7 la «regla 1» (sin la herramienta no hay baja posible) y la aprobación aparecen como mecanismos separados (l. 3165, 3314). §8.5 manda a §11.2.
- **<equipo-de-contingencia>.** AH-01--06 propone: «ninguna escritura depende del texto: o el modelo no tiene herramientas que escriban, o toda escritura espera la aprobación de la persona con su contrato».
- **Juicio.** Esa formulación única ayuda a ACT-SEC y encaja con la base, que ya enseña las dos formas.
- **Acción.** Usar esa frase como enunciado de la garantía en §11.2, apuntando a §8.5.

### APOR-28 · S4 · Referencias verificadas por <equipo-de-contingencia> que le sirven a la base
- **Base.** Anexo D, con 203 referencias. Ya tiene la especificación MCP 2026-07-28 (l. 3149) y el blog de SK y MAF (REF-137). No tiene la referencia de Blazor con EF Core, ni el DI overview §«Scope validation», ni la Ley 25.326, ni la página de compatibilidad con OpenAI de Ollama con `top_k` ausente.
- **<equipo-de-contingencia>.** Plan §10.2, Anexo D: DI overview «Scope validation» (ms.date 2026-01-26), Ley 25.326 (InfoLEG), ResDAC, Ollama «OpenAI compatibility» y «context length», `server/routes.go` y `server/sched.go` en v0.40.11, y Blazor con EF Core (SENIOR-01). Todas consultadas el 2026-10-28.
- **Juicio.** Son las fuentes de APOR-06, 11, 12 y 25.
- **Acción.** Importarlas con el formato del Anexo D de la base, sólo cuando entre la unidad que las usa.

## 3. Hallazgos de <equipo-de-contingencia> que no se trasladan

| Hallazgo de <equipo-de-contingencia> | Por qué no aplica a la base |
|---|---|
| AH-01--03 (la demo sólo arranca en Development, que enciende `EnableSensitiveData`, y publica en todas las interfaces) | La base ata `EnableSensitiveData` a una variable y no a Development (B l. 3457). El compose y el README publican en `127.0.0.1` |
| AH-02--05 y CAT-FO-02 (la regla «difiere» enunciada de varias maneras) | La base usa la binomial exacta bilateral sobre los pares discordantes, con p < 0,05 (B l. 2830), que es mejor que la regla de conteo |
| IMPLEM-03 (el registro copia la excepción con host y puerto) | `PredicadoDeSalto.cs` ya excluye el endpoint (l. 25). No se vio ningún registro que copie `ex.Message` de red. Conviene incluirlo en el barrido R-PRIV de los registros |
| ARQUIT-05 (`Persistence` que genera embeddings) | En la base, los embeddings viven en `Infrastructure/AI/Ayuda` y en `Examples/07/Infrastructure`, no en `Persistence` |
| ADV-04 (MAF «recomendado para proyectos nuevos» leído contra MEAI) | La base usa REF-137 sólo para SK frente a MAF (B l. 2706) |
| X-Sesion-Id «no es control de acceso» (RV-20) | La base ya lo dice en l. 421, 1964 y 3306 |
| EDICIO-*, DIDACT-*, REQUIS-*, VERIFI-01…07, CAT-OP-01…03 y 05, CAT-FO-01, 05, 06 y 08, IMPLEM-05…08, ARQUIT-01…04 y 06…08 | Se refieren al texto, las líneas, la numeración de ejemplos o la demo propios de <equipo-de-contingencia>. Su método sirve para la relectura integral de la base, pero no son aportes de contenido |
