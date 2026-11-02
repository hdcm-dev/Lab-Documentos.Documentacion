---
doc_id: BIT-16-REC2-INV-aportes-lab
doc_type: inventario-de-mesa
title: Inventario «aportes-lab» — lo que el laboratorio de <equipo-de-contingencia> suma a la base (Examples 01–17 y demo)
status: cerrado
origin: agent
last_review: 2026-10-28
---

# Inventario «aportes-lab» (mesa de recuperación, 2026-10-28)

**Objeto.** Hay que comparar las piezas y pruebas del laboratorio de la línea <equipo-de-contingencia> (insumo, sólo lectura) con la base <equipo-principal> que ya está restaurada. Se compara contra:

- la guía: `Examples/` 01–17, `_Comun` y `Demos/MovilidadUrbana.Asistente`;
- la bitácora: `06-Construccion.md` §2.1, §5 y §7, y `07-Redaccion.md` §8 y §9.

Cuenta como unidad:

- lo que la base no tiene;
- lo que la base hace peor;
- una deuda de la base que el laboratorio de <equipo-de-contingencia> resuelve;
- lo que el laboratorio **no** resuelve aunque el contexto lo suponga.

**Fuentes del insumo** (`OUTPUTs/Linea-*-2026-10-28/`):

- `Guia/Examples/{01..10,12,13}/README.md` y su código;
- `Guia/Demos/MovilidadUrbana.Asistente/README.md` y `LimitadorDelModelo.cs`;
- `Bitacoras/Mesa/Ciclo-2/evidencia-examples/*` y `evidencia-demo/*`.

**Fuentes de la base**:

- `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/` (guía 0.10.1, `Examples/`, `Demos/`);
- `OUTPUTs/Bitacoras/06-Construccion.md` y `07-Redaccion.md`.

**Cómo se verificó.** Se leyeron los README, la evidencia y el código del insumo. En la base se buscó cada concepto con `grep` sobre `*.cs`, `*.json` y `*.md`, fuera de `obj/`. Las líneas que se citan son de la guía de la base, salvo que se diga otra cosa. No se compiló ni se corrió nada contra el modelo, porque en esta mesa no corresponde. No se tocó el insumo ni <equipo-principal>.

## Hechos transversales (los que condicionan todo lo demás)

1. **El laboratorio de <equipo-de-contingencia> midió contra los dos servidores vigentes.** La estación 1 es la de 4 núcleos (`<recurso-compartido>`) y la estación 2, la de más núcleos (`<recurso-estación-2>`). Las cifras con modelo de la base son de otros servidores:
   - el «servidor compartido» de la LAN, que ya no existe: Ollama 0.32.0-rc0 y `qwen3.5:4b@2a654d98e6fb`, citado 22 veces en `Examples/` y en la guía;
   - el «Ollama propio» del gestor.

   En los servidores vigentes, `qwen3.5:4b` tiene **otro digest**: `d8b0f5e9760c`, con Ollama 0.40.11. Por eso ninguna cifra de la base con `2a654d98e6fb` se puede reproducir con el mismo digest.
2. **Los ejemplos de <equipo-de-contingencia> no son los de la base.** Tienen otra numeración, otra estructura (`src/` + `tests/` con `Cableado/` y `ConModelo/`), NUnit 5.0.0 con NUnit3TestAdapter 6.3.1 y no usan arnés. Sus cifras son de **su** código. No se trasladan a los ejemplos de la base: sirven de antecedente, de criterio y de estímulo para la re-corrida, o como pieza que se porta.
3. **El caso base es el mismo.** <equipo-de-contingencia> copia de `59399ba` y la base, de `8fb4c3a`. `git diff --stat 8fb4c3a 59399ba` en el clon de Lab-E2E.WebBlazor da un único archivo `.md` de documentación, sin cambios en `src/MovilidadUrbana.ApiWeb`. No hay conflicto de código, sólo de referencia (APOR-24).
4. **Intervalos.** <equipo-de-contingencia> usa Wilson al 95 % y la base, Clopper-Pearson (`verificar.sh tasa`). Si se cita una cifra de <equipo-de-contingencia>, hay que recalcular su intervalo con el método de la base.

## Unidades

| id | tema | severidad | acción, en una línea |
|---|---|---|---|
| APOR-01 | Re-corrida en servidores vigentes: digest nuevo, estación 2 preferente, timeouts de la estación 1 | S1 | plan de re-corrida con `d8b0f5e9760c` y el aprendizaje de turnos de <equipo-de-contingencia> |
| APOR-02 | Cancelación de streaming sin `OperationCanceledException` (OllamaSharp 5.5.0) | S2 | portar el chequeo del token y dos pruebas de cableado a 01 |
| APOR-03 | Truncado con `num_ctx`: re-medición vigente y guarda como excepción | S2 | rotular §5.7 y re-medir; el detector, como alternativa de producción |
| APOR-04 | Lo que viaja por cada vía: `TopK`, `MaxOutputTokens` por `/v1`, `tool_choice`, mensaje `tool` | S2 | prueba de captura del cuerpo en 02 y corrección de la tabla de §5.6 |
| APOR-05 | Señal observada de reuso de prefijo (`prompt_eval_cached_count`) | S2 | lector en `_Comun`; llenar `estado_cache`; cerrar el «no medido» de §6 |
| APOR-06 | Caché por sesión y por versión de datos; contador por los dos caminos de lectura | S2 | casos rojos en 17 y advertencia en §12.3 |
| APOR-07 | Límite de concurrencia en la entrada, compartido por la API y Blazor | S2 | portar `LimitadorDelModelo` a la demo; la base declara que falta |
| APOR-08 | Huecos heredados: CP con dígitos no ASCII y nombre > 60 | S2 | endurecer el camino de IA en `_Comun` con pruebas |
| APOR-09 | MCP: versión negociada medida, token, orden Origin → token, anotaciones que no deciden | S2 | registrar la versión negociada en 13 y corregir el Anexo F |
| APOR-10 | ESC-001 sin objeto: los servidores vigentes tienen `qwen3-embedding:0.6b` | S2 | reformular §9.2, la línea 1596 y EMB-A |
| APOR-11 | Ciclo de vida D-06: caso rojo Singleton con `ValidateScopes=false` | S3 | prueba roja de dos sesiones con barrera |
| APOR-12 | Prueba de arquitectura con mutaciones, excepciones y agujeros declarados | S3 | casos rojos y candidata a la quinta regla de ADR-11 |
| APOR-13 | Abstención por umbral no separable con `qwen3-embedding` | S3 | re-correr 06 con calibración aparte y escribir el criterio |
| APOR-14 | RAG: citar no es fundamentar; el formato de cita sale del ejemplo del prompt | S3 | lecciones en §6 y §10, y revisar la instrucción de 07 |
| APOR-15 | Migración desde SK: tres trampas que fallan en silencio | S3 | casos rojos en 14 |
| APOR-16 | Sesión serializada alterada y guarda de la llamada aprobada | S3 | verificar en 11 y, si falta, caso rojo |
| APOR-17 | CP inventado con forma válida (3400, 3489): evidencia vigente de la confirmación | S3 | estímulo y criterio para re-correr 03, 10 y PD-3 |
| APOR-18 | Herramienta no pedida: el modelo afirma «cero» sin consultar | S3 | lección en §7 y estímulo «Misiones» para 08 y 09 |
| APOR-19 | Deudas 08 y AC-6: <equipo-de-contingencia> no las resuelve; la base ya las resolvió | S3 | nota fechada: el README de la bitácora quedó viejo |
| APOR-20 | `Inconclusive`/`Ignore` como `Skipped`: fuera de «Total tests» | S4 | nota en §10.2; mantener NUnit 4.3.2 |
| APOR-21 | Workflows: trampa de `Yield` en ejecución; `BuildSequential` + `AsAIAgent` | S4 | opcional en 10 o 12 |
| APOR-22 | Embeddings deterministas (128/128 iguales): m no agrega información | S4 | una oración en §6 al re-correr |
| APOR-23 | Demo de <equipo-de-contingencia> sin herramientas de escritura; elección del modelo por `/v1` | S4 | no importar; mantener la demo de la base |
| APOR-24 | Higiene de lo que se porte: rótulos, commit del caso base, «Téngés» y `presence_penalty` | S4 | R-PRIV y rótulos al portar |

### APOR-01 · Re-corrida en servidores vigentes (S1)

- **Base.** Las cifras con modelo de la guía 0.10.1 llevan los rótulos «servidor compartido, Ollama 0.32.0-rc0, `2a654d98e6fb`» u «Ollama propio, 0.40.11». Hay 53 menciones de «servidor compartido» en la guía. En `06-Construccion` §3, el presupuesto de turnos es el del servidor de la LAN (`TOPE_LAN_S`).
- **<equipo-de-contingencia>.** Todas las pruebas `ConModelo/` corrieron en las estaciones 1 y 2, con este método:
  - criterio escrito antes de correr, con el sha256 del archivo de pruebas;
  - cabecera R-LLM;
  - digest `d8b0f5e9760c`.

  Hay aprendizajes medidos de las estaciones:
  - en la estación 1, con el anfitrión cargado, los pedidos superaron los 300 s de `TimeoutSegundos`: la corrida de 07 se cortó y 08 dio una violación por timeout en s = 1;
  - la cola de `<recurso-compartido>` llegó a superar los 20 min, y por eso se usó la estación 2;
  - en la estación 1, 08 tuvo una mediana de pared de 95,5 s contra 9,3 s en la estación 2.

  Fuentes: `evidencia-examples/07-*/README.md`, `08-*/README.md` y `con-modelo-estacion-1/`.
- **Juicio.** Las cifras de <equipo-de-contingencia> no sustituyen las de la base, porque el código es otro. Sí fijan tres cosas para la re-corrida de la base:
  - el digest vigente, que obliga a cambiar todos los rótulos;
  - que la estación 2 es la preferente para lo pesado;
  - que con la estación 1 cargada el plazo de 300 s no alcanza para los agentes de dos llamadas.

  Bloquea: sin esto, la re-corrida reproduciría un digest que ya no existe.
- **Acción.** Hay que hacer el plan de re-corrida de la base con:
  - `qwen3.5:4b@d8b0f5e9760c`;
  - la estación 2 para 11, 12, 13, 16 y la demo;
  - la estación 1 sólo para lo corto y sin carga ajena;
  - el criterio previo con sha256, al estilo de <equipo-de-contingencia>;
  - un presupuesto nuevo en lugar de `TOPE_LAN_S`;
  - los rótulos «estación de laboratorio de 4 núcleos» y «estación de laboratorio con más núcleos».

  Hasta re-correr, toda cifra con `2a654d98e6fb` se rotula como historia.

### APOR-02 · Cancelación de streaming sin excepción (S2)

- **Base.** `Examples/01-Chat-Y-Streaming/Application/AsistenteDeAyuda.cs`, líneas 46–70: `await foreach` sobre `GetStreamingResponseAsync` y después `_historial.AddRange(respuesta.Messages)`, sin mirar el token. No hay ninguna prueba de cancelación: `grep` de `IsCancellationRequested` y de `OperationCanceledException` en `Examples/` y `Demos/` da 0. La guía no trata el corte del streaming.
- **<equipo-de-contingencia>.** En `02-Streaming`, con OllamaSharp 5.5.0, cancelar terminó la enumeración **sin lanzar**:
  - antes del arreglo dio «no cancelada» en 10/10 (`evidencia-examples/02-Streaming/LEEME.txt`, `corrida-1-antes-del-arreglo/2-cancelacion.jsonl`);
  - el programa cortado a los 20 s informó «completa» con el motivo de fin vacío y guardó el parcial en el historial;
  - el arreglo revisa `ct.IsCancellationRequested` después del `await foreach`;
  - `Cableado/` prueba los dos proveedores, el que lanza y el que termina en silencio (9/9);
  - después del arreglo, la cancelación dio 10/10 en la estación 1.
- **Juicio.** La base tiene exactamente el defecto que <equipo-de-contingencia> midió: una respuesta cortada entra al historial como completa. La base usa OllamaSharp 5.5.0, el mismo paquete. Es un defecto de corrección del ejemplo de chat, no de estilo.
- **Acción.** Portar a 01 de la base:
  - el chequeo del token después del `await foreach`;
  - no agregar el parcial al historial;
  - devolver la vuelta marcada como cancelada;
  - dos pruebas de cableado con `GuionChatClient`: una que lanza `OperationCanceledException` y otra que corta sin lanzar.

  Sumar un párrafo en §5 con el rótulo de <equipo-de-contingencia> («observado en la estación de laboratorio de 4 núcleos, 2026-10-28, OllamaSharp 5.5.0») hasta que la base lo re-corra con su propio código.

### APOR-03 · Truncado con `num_ctx` (S2)

- **Base.** `_Comun/.../AI/GuardaDeTruncado.cs` estima por caracteres por token y marca `truncado_posible`; no corta. La línea 1013 de la guía afirma «5.714 frente a 2.050 tokens», sobre la sonda DEP-03 en el «Ollama propio» con `qwen2.5:0.5b`, el 2026-10-27, que no es un servidor vigente.
- **<equipo-de-contingencia>.** Lo midió en las dos estaciones vigentes:
  - 01, estación 1, con `qwen2.5:0.5b@a8b0c5157701`: 6.843 tokens con `num_ctx` 16384 y 8192, y **2.050** con 4096, en 3/3, con `stop` y sin error;
  - 09, estación 2, con `qwen3.5:4b@d8b0f5e9760c`: 5.114 tokens con 8192 y 2.050 con 4096, en 3/3. Además observó que el servidor conserva 4096/2 + 2 tokens.

  Además:
  - el largo esperado se mide con el mismo modelo: el mismo prompt da 5.114 tokens con `qwen3.5:4b` y 5.134 con `qwen2.5:0.5b`;
  - `DetectorDeContextoTruncado` es un `DelegatingChatClient` que lanza `ContextoTruncadoException`.
- **Juicio.**
  - El fenómeno es el mismo y el 2.050 coincide. Hay que re-correr en un servidor vigente la cifra que afirma la guía, o rotularla.
  - La guarda de la base cuida el registro (saca la corrida de la tasa). La de <equipo-de-contingencia> cuida la aplicación (no responde con un contexto roto). Son complementarias.
  - Que el largo esperado dependa del tokenizador refuerza que la estimación de la base (2,33 caracteres por token, de DEP-03) es propia del modelo.
- **Acción.**
  - Re-correr DEP-03 de la base en la estación 1 o la 2 y actualizar la línea 1013.
  - Agregar en §5.7 la regla «4096 → 2.050 conservados», con su rótulo vigente.
  - Mostrar el detector que lanza como alternativa de CTX-PROD, en una plantilla o en un ejemplo, sin reemplazar `GuardaDeTruncado`.
  - Dejar escrito que la calibración de caracteres por token es por modelo.

### APOR-04 · Lo que viaja por cada vía (S2)

- **Base.** La tabla de §5.6 (líneas 1000–1003) dice que `/v1` «no admite `tool_choice`», que `num_ctx` sólo viaja por OllamaSharp y que las duraciones no llegan por `/v1`. No hay una prueba que capture el cuerpo del pedido: `grep` de `max_completion_tokens`, `tool_call_id` y `tool_choice` en `Examples/` da 0.
- **<equipo-de-contingencia>.** 01 (`Cableado/CuerpoDelPedidoTests`, con un servidor falso) y 06 (`ProveedorTests…EnElFormatoDeCadaVia`) capturan:
  - `TopK` se descarta en silencio por `/v1`;
  - `MaxOutputTokens` va como `options.num_predict` por la vía nativa y como `max_completion_tokens` por `/v1`;
  - `Reasoning.None` va como `think:false` y como `reasoning_effort:"none"`;
  - `ChatToolMode.Auto` manda `"tool_choice":"auto"` por `/v1`;
  - el mensaje `tool` lleva el `FunctionResultContent` entero (`{"CallId":…,"Result":…}`) por OllamaSharp y sólo el resultado, con `tool_call_id` aparte, por `/v1`.

  Contra la estación 1, con `MaxOutputTokens` 3: la vía nativa dio 3 tokens con `length` en 3/3; `/v1` dio 30, 35 y 31 tokens con `stop`, es decir que **no acota**.
- **Juicio.**
  - Que `/v1` no acote la salida cambia una recomendación (no se puede acotar el tiempo por `/v1`) y la base no lo tiene.
  - «`/v1` no admite `tool_choice`» es inexacto del lado del cliente: el adaptador lo manda. Que Ollama lo haga cumplir no está medido.
  - La diferencia del mensaje `tool` importa para quien lee los registros o cambia de adaptador.
- **Acción.**
  - Agregar a 02-Cambio-De-Adaptador una prueba de cableado que capture el cuerpo por las dos vías, sin modelo.
  - Re-medir `MaxOutputTokens` por `/v1` en un servidor vigente.
  - Corregir la fila de `tool_choice` de §5.6: «el adaptador lo manda; que el servidor lo cumpla, no verificado».
  - Sumar a §5.6 las filas de `TopK`, `MaxOutputTokens` y el formato del mensaje `tool`.

### APOR-05 · Señal observada de reuso de prefijo (S2)

- **Base.** `EscritorDeRegistro.EstadoDeCache.Deducir` deduce el estado de la caché y deja `estado_cache` en «desconocido». `06-Construccion` §5 dice que no se puede hablar de caché caliente o fría. Guía, línea 1395: con `qwen3.5:4b` el reuso «no está medido».
- **<equipo-de-contingencia>.** En 09, `LectorDePrefijoCacheado` es un `DelegatingHandler` del `HttpClient` del proveedor:
  - lee `prompt_eval_cached_count` de la última línea del NDJSON de `/api/chat`, porque OllamaSharp 5.5.0 deja `Usage.CachedInputTokenCount` en `null`;
  - la prueba de cableado usa un NDJSON fijo y lee 710 y 706, también por streaming;
  - contra la estación 2, con `qwen3.5:4b@d8b0f5e9760c`, en 10/10 el servidor informó tokens cacheados mayores que 0: 362 de unos 441.

  En 02, el tiempo al primer texto bajó de 24,9 s a una mediana de 0,51 s cuando se repite el prompt.
- **Juicio.** Llena un «no medido» explícito de la base con una señal **observada** en lugar de deducida, y con el modelo de chat de la guía. Sirve también para el ejemplo 05 de la base, cuya lectura de prefijo hoy no se puede afirmar.
- **Acción.**
  - Portar el lector a `_Comun` (Infrastructure/AI) y llenar `estado_cache` con el campo observado cuando llega.
  - Re-correr 05 en una estación vigente.
  - Actualizar la línea 1395 de §6.4 y la deuda de 05 en `06-Construccion` §5, con una nota fechada en la bitácora.

### APOR-06 · Caché por sesión y por versión de datos (S2)

- **Base.** En 17, `PipelineObservado` arma `UseDistributedCache(cache)` con la clave por defecto: mensajes más opciones. La guía (línea 3355, ADR-09) habla de «caché sólo con pedidos idénticos» y no avisa que dos sesiones con el mismo texto comparten la respuesta, ni que un acierto devuelve datos de antes de una escritura. `grep` de `ReadCacheStreamingAsync` y de `CoalesceStreamingUpdates` da 0.
- **<equipo-de-contingencia>.** 09 (`PipelineTests`, 37/37 sin modelo) prueba:
  - la clave con `[SessionId, VersionDeDatos]`, leídos en cada pedido;
  - dos casos rojos que sirven la respuesta vieja: la versión que falta en la clave, y la versión leída al crear la caché;
  - el contador de aciertos, que hay que sobrescribir por **los dos** caminos de lectura. Con `CoalesceStreamingUpdates=false`, una caché que sólo sobrescribe `ReadCacheAsync` cuenta 0 (M.E.AI 10.11.0).

  La demo de <equipo-de-contingencia> aplica la regla «sin caché con herramientas».
- **Juicio.** Con CTX-SENS, que dos sesiones compartan una respuesta es una fuga de datos, y que un acierto no vuelva a ejecutar las herramientas sirve datos viejos. La base no lo advierte.
- **Acción.**
  - En 17 de la base: clave con la sesión y caso rojo de dos sesiones; caso rojo de escritura seguida de un acierto viejo; contador por los dos caminos.
  - En §12.3 y ADR-09: la sesión y la versión de datos van en la clave, y no se cachea con herramientas que leen datos mutables.

### APOR-07 · Límite de concurrencia compartido (S2)

- **Base.** Hay una deuda declarada:
  - línea 3463: «En el código de la demo, nada llama a `AddOpenTelemetry` ni usa un limitador»;
  - ADR-09: «La demo no limita la concurrencia»;
  - lista de autoevaluación (línea 4495): «con un límite de concurrencia, que la demo no tiene».

  `grep` de `ConcurrencyLimiter` y de `Retry-After` en `Examples/` y `Demos/` da 0.
- **<equipo-de-contingencia>.** En la demo, `Agregado/Presentation/LimitadorDelModelo.cs` es un `ConcurrencyLimiter` singleton (1 permiso y cola de 2, por configuración):
  - `AddRateLimiter` responde 503 con `Retry-After`;
  - la partición devuelve **la misma instancia** que inyecta la página Blazor (`ChatDelAsistente.razor`), así que el límite es uno solo para la API y para el circuito;
  - está fuera de la cadena del `IChatClient`;
  - CTRL-09 prueba que cuatro pedidos simultáneos dan 3 × 200 y 1 × 503 con `Retry-After: 30`.

  En 09 está lo mismo en la entrada HTTP, más un texto de 2001 caracteres que recibe 400 sin llamar al modelo.
- **Juicio.** Es una deuda de la base que <equipo-de-contingencia> resuelve con una pieza chica, probada y en el lugar que la guía recomienda (la entrada, no el pipeline). Que el mismo limitador sirva para Blazor, que no pasa por el middleware HTTP en cada mensaje del circuito, es el detalle que la base no tiene.
- **Acción.**
  - Portar `LimitadorDelModelo` a la demo de la base, con sus opciones en la capa única y la prueba de 4 simultáneos.
  - Ajustar las líneas 3463 y 4495 y ADR-09.
  - Registrar en la bitácora la procedencia: <equipo-de-contingencia>, `Guia/Demos/.../LimitadorDelModelo.cs`.

### APOR-08 · Huecos heredados del caso base (S2)

- **Base.** `_Comun/MovilidadUrbana.Dominio/Domain/Rules/LocalidadRules.cs`:
  - endurece sólo la provincia (hueco H1);
  - `CodigoPostal()` sigue siendo `[GeneratedRegex(@"^\d{4}$")]`, que acepta dígitos no ASCII;
  - `NombreValido` sólo exige el mínimo de 3: `LargoMaximoDelNombre = 60` está declarado y no se aplica.

  La guía (línea 1075) repite «entre 3 y 60 caracteres» como si se cumpliera.
- **<equipo-de-contingencia>.** Lo prueba en la demo (D1, «reglas heredadas»: por la API copiada entran `"٣٤٥٠"`, un nombre de 61 caracteres y `"Tucumán"`), en 03 (tabla «lo que las reglas copiadas aceptan y la entrada de IA rechaza») y en 05: «el máximo de 60 es una deuda heredada». El cierre está en `NormalizadorDeCatalogos`: provincia contra el catálogo, dígitos 0-9 y nombre ≤ 60, sin tocar la copia.
- **Juicio.**
  - Con un modelo que propone texto, un CP con dígitos arábigo-índicos pasa las garantías de la base.
  - La garantía de 03, «el número tiene que aparecer en la entrada», no lo detecta si la entrada lo trae.
  - El largo de 60 se afirma y no se cumple.

  Hay que confirmarlo con una prueba en la base antes de cambiar código.
- **Acción.**
  - Escribir en la base dos pruebas de cableado (`"٣٤٥٠"` y 61 caracteres) para confirmar.
  - Si fallan, endurecer el camino de IA (`_Comun` o el normalizador de 04) y declararlo en la tabla de delta del caso base.
  - Corregir la línea 1075 o rotularla («declarado; el caso base no lo aplica»).

### APOR-09 · MCP: versión negociada, token y orden de las validaciones (S2)

- **Base.** En 13:
  - loopback, `AllowedHosts` y un filtro de `Origin` con 403;
  - **sin autenticación**: README, línea 16, «el servidor no autentica a nadie»;
  - los comentarios citan la revisión 2025-06-18;
  - Anexo F, línea 5061: que el SDK 2.3.0 negocie 2026-07-28 es «una inferencia **no verificada**».
- **<equipo-de-contingencia>.** En 08:
  - la consola imprime `NegotiatedProtocolVersion`, que da **2026-07-28** (`evidencia-examples/08-*/01-build-...txt:231`; también en las dos corridas con modelo);
  - Bearer por un `DelegatingHandler`: 401 sin token o con uno malo;
  - el `Origin` se revisa **antes** que el token: un `Origin` ajeno sin token da 403, no 401;
  - una herramienta `borrar_todo` marcada `ReadOnly` queda afuera por la lista blanca, porque la anotación no decide;
  - una prueba con un servidor Ollama falso muestra el `TextContent` de MCP, con JSON adentro de un string, que llega al modelo;
  - hay concurrencia por sesión con caso rojo.

  Con modelo: 20 pedidos y 0 violaciones en la estación 2; en la estación 1, una violación por timeout de 300 s.
- **Juicio.**
  - La versión negociada cierra un «no verificado» del Anexo F con evidencia de 2.3.0.
  - El orden Origin → token y «la anotación no decide» son garantías de seguridad concretas.
  - Si se agrega el token o no, lo decide la mesa: la guía dice que no implementa autorización (línea 3149). Sumarlo en loopback no es OAuth 2.1 y hay que rotularlo así.
- **Acción.**
  - Imprimir o registrar `NegotiatedProtocolVersion` en 13 de la base y actualizar la línea 5061 del Anexo F con lo observado.
  - Sumar el caso de lista blanca «`ReadOnly` que no decide».
  - Llevar a decisión de la mesa el token con su orden y, si entra, sumar las cuatro pruebas de orden.

### APOR-10 · ESC-001 sin objeto (S2)

- **Base.**
  - `07-Redaccion` §9.2 le pregunta al PO si instala `qwen3-embedding:0.6b` en el servidor de la LAN;
  - la línea 1596 dice que en el servidor compartido `/api/embed` respondió 501;
  - rige EMB-B, con el Ollama propio.
- **<equipo-de-contingencia>.** Los embeddings corrieron en las estaciones vigentes con `qwen3-embedding:0.6b@ac6da0dfba84`: 04 en la estación 1 y 05 en la estación 2. El contexto común lista ese modelo en la estación 1.
- **Juicio.** La pregunta al PO quedó sin objeto: el servidor de la LAN no existe y los vigentes tienen el modelo de embeddings. La afirmación del 501 es historia de otro servidor.
- **Acción.**
  - Retirar ESC-001 de §9 o reformularlo.
  - Rotular la línea 1596 como historia.
  - Que la re-corrida de 06, 07 y PD-2 use `OLLAMA_EMBED_ENDPOINT` hacia una estación vigente (EMB-A), por variable.
  - Re-medir hit@k y MRR.

### APOR-11 · Ciclo de vida D-06 (S3)

- **Base.** ADR-12 (líneas 3742–3744) enuncia el criterio «ningún estado de conversación en un singleton». Las pruebas construyen siempre con `ValidateScopes = true`. No hay caso rojo que muestre la fuga.
- **<equipo-de-contingencia>.** 09 (`CicloDeVidaDelClienteTests`) y la demo (CTRL-06) usan dos sesiones concurrentes con barrera:
  - Scoped: aisladas;
  - Singleton con `ValidateScopes=false`: B ve y **borra** lo de A, sin error;
  - Singleton con `true`: falla **en cada llamada a la herramienta**, no al construir.
- **Juicio.** Muestra con código por qué el criterio de la base importa, y que `ValidateScopes` no lo ataja al arrancar. Es valor didáctico y de garantía.
- **Acción.** Sumar la prueba roja a 09-Caso-De-Uso-Como-Herramienta o a la demo de la base y citarla en ADR-12.

### APOR-12 · Prueba de arquitectura con mutaciones (S3)

- **Base.** `Demos/.../Cableado/ArquitecturaTests.cs` ya lee el IL y comprueba que cada regla inspeccione algo. No tiene:
  - mutaciones;
  - excepciones declaradas;
  - chequeo de atributos;
  - agujeros declarados.

  Queda pendiente «la quinta regla de ADR-11» (`07-Redaccion` §8.1). AC-5 se apoya también en `grep`.
- **<equipo-de-contingencia>.** En 13:
  - seis reglas;
  - las mutaciones R4, Cuerpo, Atributo y HerramientaEnInfrastructure se ponen rojas con `-p:Mutacion=`;
  - SoloUsing y Nameof quedan como **agujeros declarados**;
  - `Cada_excepcion_declarada_sigue_existiendo`;
  - la búsqueda de texto sobre R4 da 0 coincidencias, y eso muestra por qué no alcanza con `grep`.

  Evidencia en `evidencia-examples/13-*/03-mutacion-*.txt` y `05-busqueda-de-texto-sobre-R4.txt`.
- **Juicio.** Mejora la prueba de la base en tres frentes: muestra que detecta (casos rojos), dice qué no cubre y da candidatas a la quinta regla («Infrastructure no usa casos de uso», «el adaptador de IA no conoce el acceso a datos»). Además, el contraste con R4 muestra que el `grep` de AC-5 es más débil que la reflexión.
- **Acción.**
  - Elegir la quinta regla entre las de <equipo-de-contingencia>.
  - Sumar casos rojos a la demo de la base (al menos Cuerpo y Atributo).
  - Declarar en §4 y en ADR-11 los agujeros `using` sin uso y `nameof`.
  - Dejar de presentar el `grep` de AC-5 como prueba suficiente.

### APOR-13 · Abstención por umbral no separable (S3)

- **Base.** 06 informa el mejor puntaje de las no respondibles «como insumo para el "no sé" de 07», sin calibrar un umbral. En 07, «No sé» dio 0/4.
- **<equipo-de-contingencia>.** En 04, estación 1:
  - el umbral se calibró con un conjunto aparte y se aplicó sin tocarlo;
  - la calibración **no fue separable** en los dos formatos;
  - la abstención correcta dio 4/10 y la indebida, 4/12;
  - «¿Si elimino una ciudad…?» puntúa 0,46, más que la respuesta correcta del CP (0,37).

  En 05, estación 2, los rangos se superponen: 0,429–0,788 para las respondibles y 0,301–0,539 para las no respondibles. Con instrucción y sin ella: «no separado con este N».
- **Juicio.** Es evidencia vigente de que la abstención por similitud no sirve con este modelo y este corpus. Justifica que el «no sé» lo decida otra cosa (la regla de citas o la clasificación) y no un umbral.
- **Acción.**
  - Re-correr 06 de la base en una estación vigente, con un conjunto de calibración aparte.
  - Escribir en §6 el criterio «no abstenerse por umbral de similitud salvo calibración separable», con su rótulo.

### APOR-14 · RAG: citar no es fundamentar (S3)

- **Base.** En 07: «No sé» 0/4 y citas inventadas del tipo `[Fuente: No sé]`, rechazadas por el código.
- **<equipo-de-contingencia>.** En 05:
  - ante «¿Puedo cargar dos localidades con el mismo CP?», que el corpus no responde, contestó «debe ser único» citando la regla del CP real, en 2 de 3 corridas por estrategia;
  - el formato de la cita salió del ejemplo del prompt: con «[Politica.Requisito]» como ejemplo, el modelo lo copió en 28 de 48 respuestas RAG, con citas que no existen, y el sesgo favoreció al contexto fijo en 11 consultas;
  - el modelo agrega la abstención a una respuesta correcta (2 de 36);
  - RAG frente a contexto fijo: no separados; RAG usó 241 tokens contra 516.
- **Juicio.** Son lecciones de método que la base no tiene: la cita válida no garantiza que lo afirmado esté en la fuente, y el ejemplo del prompt sesga la comparación. Hay que revisar si la instrucción de 07 de la base trae un ejemplo de cita.
- **Acción.**
  - Revisar la instrucción de 07 y de PD-2 en la base.
  - Sumar las dos lecciones a §6 y §10 como observaciones rotuladas de <equipo-de-contingencia>, o re-corridas.
  - Agregar al oro de 07 una no respondible «cercana a una regla real», como la del CP único.

### APOR-15 · Migración desde Semantic Kernel (S3)

- **Base.** 14 cubre:
  - la ambigüedad CS0104;
  - el nombre con el prefijo del plugin;
  - la clave `condition`;
  - el resultado serializado o como objeto.
- **<equipo-de-contingencia>.** 12 suma tres trampas que fallan en silencio, como casos rojos, más una sonda aparte (`03-sonda-sk-invocacion.txt`):
  - sin `UseKernelFunctionInvocation`, el `ChatCompletionAgent` devuelve la llamada sin ejecutarla: 0 ejecuciones y texto vacío;
  - `AIFunctionFactory` no lee `[KernelFunction]`: el nombre cambia a `ResultadosPorMedio` sin aviso;
  - un `KernelFunction` entregado a MAF compila y al ejecutarse el modelo recibe «Error: Function failed.», sin que la aplicación vea una excepción.

  Además, si el modelo pide el nombre corto en SK, recibe «not found».
- **Juicio.** Son las trampas que más cuestan en una migración real, porque no dan error. Complementan 14 sin pisarlo.
- **Acción.** Sumar dos o tres casos rojos a 14 de la base, sin modelo, y una línea en §9.7.

### APOR-16 · Sesión serializada alterada (S3, a verificar)

- **Base.** En 11:
  - la `AgentSession` se serializa entre las dos peticiones;
  - hay garantía guionada para «aprobación con argumentos alterados», que se rechaza;
  - la demo tiene `Aprobacion_ArgumentosAlterados_SeRechaza`.

  No se encontró una prueba que altere el **almacén de la sesión serializada**.
- **<equipo-de-contingencia>.** En 07 (`CasoRojo_SinLaGuarda_MafEjecutaLoAlterado`), MAF ejecuta lo que dice la sesión deserializada. `FuncionConAutorizacion` deja pasar una sola ejecución de la llamada exacta aprobada, comparada con la copia que guardó el servidor. Medido sin modelo: el id aparece 2 veces en la sesión serializada y la guarda rechazó 1 ejecución. El límite está declarado: si se comprometen los dos almacenes, la guarda no alcanza.

  Otros puntos:
  - `RequestId` es «ficc_» más el `CallId`, que no es secreto;
  - el bucle de MAF no se suma al del cliente: 4 llamadas con 3 iteraciones.
- **Juicio.** La base parece cubrir los argumentos alterados en el pedido, pero no queda claro que cubra la sesión guardada alterada. Hay que verificarlo leyendo `AgenteConAprobacionTests.cs`.
- **Acción.** Verificar en la base. Si falta, sumar el caso rojo «sesión guardada alterada» a 11.

### APOR-17 · CP inventado con forma válida (S3)

- **Base.** 03 tiene `GarantiaDelTexto`: un número se acepta sólo si aparece en la entrada. Las cifras son del servidor de la LAN.
- **<equipo-de-contingencia>.**
  - En 03, estación 2: con «CP 34», el modelo propuso «3400» en 8/10 y la propuesta llegó a la pantalla sin errores en 8/10.
  - En 10, estación 2: «3489» pasó la revisión y llegó a la persona en 1/10.
  - En la demo (D1, estación 2), con la composición de la demo (clasificador y extractor), el CP quedó «34» tal cual en 10/10.
- **Juicio.** Es evidencia vigente de que la garantía de la base («el número tiene que estar en el texto») es la correcta y de que las reglas de forma no alcanzan. Con la composición de la demo de <equipo-de-contingencia> no se inventó. Las cifras no se trasladan a la base, pero dan estímulo y criterio para re-correr.
- **Acción.** Re-correr 03, 10 y PD-3 de la base en una estación vigente, con el estímulo «Agregá Goya, Corrientes, CP 34, 89959 habitantes» y la tasa «CP distinto de 34», con criterio previo.

### APOR-18 · Herramienta no pedida (S3)

- **Base.** 08 y 09 miden la herramienta de lectura. No se encontró una observación de «el modelo afirma un dato sin consultar».
- **<equipo-de-contingencia>.** En 06, estación 2, ante «Misiones»:
  - en 0/10 corridas el modelo pidió una herramienta, por las dos vías;
  - por lectura manual, en 3 de 10 (`/api/chat`) y en 4 de 10 (`/v1`) dijo «no hay localidades» o «el total es cero» sin consultar;
  - la regex de «conteo» no lo capturó.

  En la demo, D2 afirmó una cantidad de habitantes que no está en los datos (1 de 10).
- **Juicio.** Que el número lo calcule el caso de uso no protege cuando el modelo no pide la herramienta. Es una lección de §7 que la base no tiene, y además un aviso sobre los oráculos por regex.
- **Acción.** Sumar el estímulo de una provincia fuera del catálogo a 08 o 09 de la base, con un oráculo que distinga «afirma un número sin herramienta», y escribir la lección en §7.

### APOR-19 · Deudas 08 y AC-6 (S3)

- **Base.** `Bitacoras/README.md`, línea 31: «08 rechazada», «AC-6 falla en Examples». Sin embargo, `06-Construccion` §2.1 muestra las dos resueltas en el saneamiento del 2026-10-27:
  - P1-08: el oráculo acepta sólo ids presentes;
  - P2-AC6: `OpenTelemetry.Api` 1.20.1 fijado y `Azure.AI.OpenAI` 2.9.0-beta.1 como excepción escrita.

  `07-Redaccion` §6 dice que AC-6 cumple.
- **<equipo-de-contingencia>.** No las resuelve. Sus ejemplos no tienen `Directory.Packages.props` central y fijan OpenTelemetry 1.20.1 sólo en 09. Su 08 es MCP, no la herramienta de sólo lectura de la base.
- **Juicio.** La premisa de que «el laboratorio de <equipo-de-contingencia> resuelve 08 y AC-6» no se sostiene: la base ya las resolvió, y el README de la bitácora quedó desactualizado en esa fila. Lo que sigue abierto en AC-6 (los `Microsoft.Extensions.*` en 2 o 3 versiones, `ac6()` que no vacía `paquetes`) no tiene aporte de <equipo-de-contingencia>.
- **Acción.** Agregar a `Bitacoras/README.md` una nota fechada (sólo agregado) que diga que 08 y AC-6 quedaron resueltas en el saneamiento (§2.1 de 06). No importar nada de <equipo-de-contingencia> por esta unidad.

### APOR-20 · Pruebas sin modelo que aparecen como `Skipped` (S4)

- **Base.** `Assert.Ignore` con el motivo, NUnit 4.3.2 y adaptador 5.0.0, «fieles al caso base por decisión» (Anexo F, línea 5031).
- **<equipo-de-contingencia>.** `Assert.Inconclusive` con NUnit 5.0.0 y adaptador 6.3.1:
  - en la consola aparece como `Skipped`;
  - queda **fuera** de «Total tests»;
  - la corrida dice «Test Run Successful»;
  - en el `.trx` es `NotExecuted`.

  Por eso cada suite se corre con su filtro.
- **Juicio.** La convención de la base se mantiene. La lección de lectura vale para la base: un `Ignore` tampoco suma al total. Hay que verificarlo con las versiones de la base.
- **Acción.** En la fase de build, verificar cómo aparece `Ignore` con NUnit 4.3.2 y sumar una oración en §10.2 («el "no medido" se lee en las líneas `Skipped`, no en el resumen»). No migrar NUnit.

### APOR-21 · Workflows (S4)

- **Base.** 10 tiene CS0534, `BindAsExecutor`, `CheckpointManager` y `RequestPort`. 12 usa `Yield =`.
- **<equipo-de-contingencia>.** 10 suma:
  - la trampa en ejecución de un `YieldOutputAsync` sin declarar, con `InvalidOperationException` («Expecting one of []»), como prueba de cableado;
  - `AgentWorkflowBuilder.BuildSequential` con `AsAIAgent()` (`WorkflowHostAgent`);
  - el estado por `QueueStateUpdateAsync` en el checkpoint.
- **Juicio.** Es complementario y de prioridad baja. La trampa de `Yield` es la única que no da error al compilar.
- **Acción.** Opcional: sumar a 10 de la base el caso rojo de `Yield`. Que entre `BuildSequential`, lo decide la mesa según el alcance de §8.

### APOR-22 · Embeddings deterministas (S4)

- **<equipo-de-contingencia>.** En 04: 128 de 128 parejas de repeticiones dieron vectores idénticos, así que m no agrega información. La dimensión se valida al arrancar con un caso rojo de 512.
- **Base.** 06 valida la dimensión 1024 al arrancar y no declara el determinismo.
- **Acción.** Una oración en §6 al re-correr 06 en una estación vigente, si se confirma.

### APOR-23 · Diseño de la demo de <equipo-de-contingencia> (S4)

- **<equipo-de-contingencia>.**
  - Ninguna herramienta de escritura: el alta y la baja son una `AccionPropuesta` que la persona confirma con el ABM copiado.
  - Cookie asignada por el servidor.
  - Recorrido D1–D6 a 412 px en Chromium.
  - Tabla `qwen3.5:4b` frente a `qwen3.5:2b`, medida por `/v1` con una herramienta de baja, que no se traslada.
  - Atribuye las palabras deformadas a `presence_penalty` 1,5, sin probarlo.
- **Base.** La demo tiene aprobaciones (AC-4: cuatro pruebas) y su prueba de arquitectura.
- **Juicio.** La base es la BASE por decisión del PO, y su demo cumple AC-4 con aprobación. No se reemplaza. Se toman sólo las piezas sueltas de APOR-06, 07, 08, 11 y 12. La tabla de elección del modelo no se cita, porque es de otra composición.
- **Acción.** No importar el diseño. La elección del modelo provisional se re-mide, si hace falta, con la demo de la base.

### APOR-24 · Higiene de lo que se porte (S4)

- **<equipo-de-contingencia>.** Lo que hay que revisar antes de portar:
  - rótulos «estación de laboratorio de 15 vCPU» (07 y 10) en lugar del vigente «con más núcleos»;
  - `CasoBase/PROCEDENCIA.md` en `59399ba`, sin diferencias de código con `8fb4c3a`;
  - muestreo de la ficha del modelo (T 0,7, top_p 0,8, top_k 20, presence_penalty 1,5), que la base no usa, porque fija temperatura y semilla en la capa única;
  - «Téngés» en 13 de la base, que <equipo-de-contingencia> relaciona con `presence_penalty`, sin probarlo.
- **Acción.**
  - Todo lo que se porte se re-rotula con los rótulos vigentes.
  - La procedencia apunta a `8fb4c3a`, el commit de la base.
  - Se pasa R-PRIV ampliado: endpoints sólo por variable, sin hosts ni rótulos de equipos.
  - El muestreo de la ficha no se importa sin decisión de la mesa.

## Resumen para la matriz

- **S1 (1).** APOR-01: el digest vigente cambia todos los rótulos de la base, y la re-corrida tiene que planificarse con lo que se aprendió en las estaciones.
- **S2 (9).** APOR-02 a 10:
  - defectos o deudas reales de la base con pieza o evidencia vigente en <equipo-de-contingencia>: cancelación, caché por sesión, limitador, huecos del CP y del largo, versión negociada de MCP;
  - correcciones de afirmaciones de la guía: truncado, `/v1`, prefijo, ESC-001.
- **S3 (9).** APOR-11 a 19: casos rojos y lecciones que mejoran la enseñanza. APOR-19 corrige la premisa sobre 08 y AC-6.
- **S4 (5).** APOR-20 a 24: notas de lectura, opcionales y lo que no se importa.

**Lo que no entra.** No entra el diseño de la demo de <equipo-de-contingencia> ni sus tasas de composición. Tampoco las cifras de <equipo-de-contingencia> como si fueran de los ejemplos de la base, ni la migración a NUnit 5.
