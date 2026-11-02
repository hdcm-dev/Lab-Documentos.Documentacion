# 09 · Pruebas con cliente falso: `Cableado/` frente a `ConModelo/`

La API del asistente de Movilidad Urbana con el pipeline que se usaría en producción: caché de respuestas,
bucle de herramientas, telemetría, límite de concurrencia en la entrada HTTP y un detector de contexto truncado.
Casi todo se prueba **sin modelo**, con un `IChatClient` falso que sigue un guion: así se comprueban las garantías
(qué se cachea, qué spans quedan, qué sesión ve qué, cuándo se rechaza un pedido) de forma determinista. Lo que
depende del modelo va aparte, en `ConModelo/`, con su registro R-LLM.

- **Nivel:** intermedio.
- **Sección de la guía:** §8, «Operar, evaluar y asegurar» (las dos suites y sus tipos de aserción; el orden del
  pipeline con sus spans; el contador de aciertos; el limitador con 503 y `Retry-After`; el ciclo de vida del
  cliente, D-06; el método de evaluación con juez). §5, «Hablar con un modelo desde .NET», remite acá para el registro
  en DI y el decorador propio (`DelegatingChatClient`); §6, «Estrategias de conocimiento», para la lectura de
  `prompt_eval_cached_count`.
- **Modo sin modelo:** sí. Toda la carpeta `Cableado/` corre sin servidor. Sin `OLLAMA_ENDPOINT`, las pruebas de
  `ConModelo/` quedan `Inconclusive` («ConModelo: no medido»): nunca en verde.

## Qué demuestra

1. **El pipeline y su orden: caché → `UseFunctionInvocation` → `UseOpenTelemetry` → cliente**
   (`Infrastructure/AI/ComposicionDeIA.cs`). Con la caché fría se ven los spans `orchestrate_tools`, `chat`,
   `execute_tool contar_localidades_por_provincia` y `chat`. Un acierto deja **0 spans** y no llama al modelo: se lee
   en la métrica `movilidadurbana.ai.cache.aciertos`, un `Counter<long>` del `Meter` de la misma fuente
   (`TelemetriaDeIA.Fuente` = `MovilidadUrbana.AI`, la misma constante en `UseOpenTelemetry`, `AddSource` y
   `AddMeter`). Un acierto **no vuelve a ejecutar las herramientas**: devuelve la respuesta tal como se armó.
2. **La caché cuenta sus aciertos por los dos caminos de lectura.** `CacheConContador` sobrescribe `ReadCacheAsync` y
   `ReadCacheStreamingAsync`. En Microsoft.Extensions.AI 10.11.0, con `CoalesceStreamingUpdates` en `true` (el valor por
   defecto) el streaming lee por `ReadCacheAsync`, y con `false`, por `ReadCacheStreamingAsync`. Una caché que sólo
   sobrescribe el primero cuenta 0 aciertos con `false`: es el caso rojo de las pruebas.
3. **La clave de la caché lleva `[SessionId, VersionDeDatos]`, leídos en cada pedido.** Dos sesiones con el mismo texto
   no comparten respuesta. Una escritura confirmada por la operación normal (`AltaDeLocalidad`, después de guardar)
   incrementa la versión de la sesión, y la misma pregunta vuelve a consultar. Si la versión falta en la clave, o se lee
   al crear la caché, se sirve la respuesta vieja: son los dos casos rojos. Límite declarado: la versión sólo ve las
   escrituras que pasan por los casos de uso que la incrementan.
4. **El límite de concurrencia va en la entrada HTTP, no dentro del pipeline**
   (`Infrastructure/Http/EndpointsDelAsistente.cs`). `AI:Concurrencia:Permisos` = 1 y `Cola` = 2 (valores elegidos, no
   medidos): con un cliente falso que tarda 2 s, el cuarto pedido simultáneo recibe 503 con `Retry-After: 30`. Un texto
   de más de `AI:LargoMaximoDeEntrada` (2000) caracteres recibe 400 sin llamar al modelo.
5. **El ciclo de vida del pipeline (D-06).** Las herramientas resuelven el caso de uso desde los servicios del pipeline
   que las invoca. Con el pipeline Scoped, cada conversación ve su sesión. Con un Singleton y `ValidateScopes = false`,
   todas resuelven el `SessionContext` de la raíz, que en el caso base trae un `Guid` provisorio: **todas las
   conversaciones comparten un único espacio y una puede leer y borrar lo que otra escribió, sin error**. Con un
   Singleton y `ValidateScopes = true` no falla al construir el contenedor: falla **en cada llamada a la herramienta**, con
   `InvalidOperationException`. La prueba usa la clase real `SessionContext.cs` copiada del caso base.
6. **Contexto truncado como error.** Si el prompt supera `num_ctx`, Ollama lo recorta sin avisar.
   `DetectorDeContextoTruncado` (un `DelegatingChatClient` que envuelve al cliente del proveedor) compara
   `Usage.InputTokenCount` con el largo esperado, medido antes con el mismo modelo, y si llegó menos lanza
   `ContextoTruncadoException`.
7. **La señal de reuso del prefijo.** El servidor informa `prompt_eval_cached_count`; OllamaSharp 5.5.0 no lo expone
   (`Usage.CachedInputTokenCount` queda `null`). `LectorDePrefijoCacheado`, un `DelegatingHandler` del `HttpClient`
   del proveedor, lo lee de la línea final del NDJSON de `/api/chat` sin cambiar los fragmentos.
8. **Contrato de salida estructurada y evaluadores.** `GetResponseAsync<EncuestaPaso2Propuesta>` con el texto «Voy en
   bondi y a veces en bici, casi todos los días»: caso feliz, JSON malformado (`TryGetResult` falso, el código no se
   rompe) y el esquema enviado con `required`. `MedioEnCatalogoEvaluator` (propio, determinista) marca «piedra» o
   «bondi» como métrica fallida con su motivo. El método con juez (`RelevanceEvaluator`, `CoherenceEvaluator`,
   `GroundednessEvaluator`) se cablea con un juez **falso**: las métricas aparecen y queda el almacén para
   `aieval report`; eso no mide calidad.
9. **Contenido en la telemetría sólo en Development** (`EnableSensitiveData`), y ningún endpoint, modelo, `num_ctx` ni
   timeout literal fuera de `OpcionesDeIA` y los `appsettings*.json` (una prueba lo barre).

| Pieza | Capa | Archivo |
|---|---|---|
| `ConsultaDeLocalidades` (lectura, normaliza la provincia contra el catálogo) | Application (núcleo) | `src/.../Application/Consultas/ConsultaDeLocalidades.cs` |
| `AltaDeLocalidad` (escritura confirmada; incrementa `VersionDeDatos`) | Application (núcleo) | `src/.../Application/Localidades/AltaDeLocalidad.cs` |
| `IVersionesDeDatos`, `IAsistente` (puertos, sin tipos de MEAI) | Application | `src/.../Application/Abstractions/`, `Application/Asistente/` |
| `EncuestaPaso2Propuesta` | Application | `src/.../Application/Encuestas/EncuestaPaso2Propuesta.cs` |
| `ComposicionDeIA` (pipeline, vida, cliente del proveedor) | composición | `src/.../Infrastructure/AI/ComposicionDeIA.cs` |
| `CacheConContador`, `TelemetriaDeIA` | Infrastructure/AI | `src/.../Infrastructure/AI/` |
| `DetectorDeContextoTruncado`, `LectorDePrefijoCacheado` | Infrastructure/AI | `src/.../Infrastructure/AI/` |
| `HerramientasDeLocalidades` (catálogo cerrado, sólo lectura), `Asistente` | Infrastructure/AI | `src/.../Infrastructure/AI/` |
| limitador y endpoints | Infrastructure/Http | `src/.../Infrastructure/Http/EndpointsDelAsistente.cs` |
| `OpcionesDeIA` (sección `AI`, validada al arrancar) | composición | `src/.../Infrastructure/AI/OpcionesDeIA.cs`, `appsettings*.json` |
| copia literal del caso base | Domain, Application, Sessions | `src/.../CasoBase/` (ver `CasoBase/PROCEDENCIA.md`) |
| cliente falso con guion | pruebas | `tests/.../Cableado/ClienteGuionado.cs` |
| `MedioEnCatalogoEvaluator` | pruebas | `tests/.../Evaluacion/MedioEnCatalogoEvaluator.cs` |

En este ejemplo **ninguna herramienta escribe**. La prueba del ciclo de vida suma dos herramientas de escritura que
viven sólo dentro de la prueba, para poder medir el cruce entre sesiones.

## Requisitos

- Docker con la imagen `mcr.microsoft.com/dotnet/sdk:10.0` (probado con
  `sha256:de4fe90a98845d75910b9769662465c84de1a934665c431279d1382b2bddc02b`, SDK 10.0.403, runtime 10.0.14).
- Para `ConModelo/`: el servidor Ollama de prueba con `qwen3.5:4b`, alcanzado por `OLLAMA_ENDPOINT` (por defecto
  `http://localhost:11434`). Con la receta del Anexo E de la guía (red `ia-guia`, contenedor `ollama`) es
  `--network ia-guia -e OLLAMA_ENDPOINT=http://ollama:11434`; si el servidor corre en la misma máquina que Docker,
  `--network host` y el valor por defecto.

Paquetes (versiones exactas, consultadas en nuget.org el 2026-10-28; `dotnet list package --vulnerable
--include-transitive` no informa paquetes vulnerables):

| Paquete | Versión | Dónde |
|---|---|---|
| `Microsoft.Extensions.AI` | 10.11.0 | src |
| `OllamaSharp` | 5.5.0 | src |
| `OpenTelemetry.Extensions.Hosting` | 1.20.1 | src |
| `OpenTelemetry.Exporter.OpenTelemetryProtocol` | 1.20.1 | src |
| `Microsoft.AspNetCore.Mvc.Testing` | 10.0.14 | tests |
| `Microsoft.Extensions.AI.Evaluation` | 10.11.0 | tests |
| `Microsoft.Extensions.AI.Evaluation.Quality` | 10.11.0 | tests |
| `Microsoft.Extensions.AI.Evaluation.Reporting` | 10.11.0 | tests |
| `NUnit` | 5.0.0 | tests |
| `NUnit3TestAdapter` | 6.3.1 | tests |
| `Microsoft.NET.Test.Sdk` | 18.11.0 | tests |
| `Microsoft.Extensions.AI.Evaluation.Console` (herramienta `aieval`) | 10.11.0 | sólo para el informe |

## Comandos

Desde esta carpeta. `bin/`, `obj/`, `salidas-con-modelo/`, `almacen-evaluacion/` e `informe-evaluacion.html` quedan
fuera de git por `.gitignore`.

**Compilar:**

```bash
docker run --rm -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet build 09-Pruebas-Con-Cliente-Falso.slnx
```

**Pruebas de `Cableado/` (sin modelo, deterministas):**

```bash
docker run --rm -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test 09-Pruebas-Con-Cliente-Falso.slnx --filter TestCategory=Cableado
```

**Pruebas de `ConModelo/`** (truncado: 3 semillas × 2 `num_ctx` con un prompt de 185 líneas; pipeline: 10 semillas ×
2 pedidos; salida estructurada: 10 semillas):

```bash
docker run --rm --network ia-guia -e OLLAMA_ENDPOINT=http://ollama:11434 \
  -e ESTACION="medido en <tu equipo>, $(date +%F)" \
  -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test 09-Pruebas-Con-Cliente-Falso.slnx --filter TestCategory=ConModelo --logger "console;verbosity=normal"
```

Cada prueba escribe su registro R-LLM en `tests/.../bin/Debug/net10.0/salidas-con-modelo/` (o en la carpeta de
`RLLM_SALIDA`). `CONMODELO_M` cambia la cantidad de semillas. La evaluación con juez (`EvaluacionConJuezTests`) corre
sólo con `-e CONMODELO_JUEZ=1`; sin la variable queda `Inconclusive` («no medido»).

**El informe de evaluación** (sobre el almacén que deja la prueba de `Cableado/` con el juez falso):

```bash
docker run --rm -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 bash -c \
  "dotnet test 09-Pruebas-Con-Cliente-Falso.slnx --filter TestCategory=Cableado && \
   dotnet tool install --tool-path /tmp/herramientas Microsoft.Extensions.AI.Evaluation.Console --version 10.11.0 && \
   /tmp/herramientas/aieval report \
     --path tests/MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests/bin/Debug/net10.0/almacen-evaluacion \
     --output informe-evaluacion.html"
```

**La API, contra el servidor de prueba** (escucha en el puerto 8080 del contenedor):

```bash
docker run --rm --network ia-guia -p 8080:8080 -e OLLAMA_ENDPOINT=http://ollama:11434 \
  -e ASPNETCORE_ENVIRONMENT=Development -e ASPNETCORE_URLS=http://+:8080 \
  -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet run --project src/MovilidadUrbana.Ejemplos.PruebasConClienteFalso
# en otra terminal:
curl -s -X POST localhost:8080/api/v1/asistente -H 'Content-Type: application/json' -H 'X-Sesion-Id: sesion-1' \
  -d '{"texto":"¿Cuántas localidades hay cargadas en Corrientes?"}'
```

Sin `ASPNETCORE_ENVIRONMENT=Development` la API no arranca: falta `TimeoutSegundos` (cada entorno lo declara en su
`appsettings.<entorno>.json`) y sale con `OptionsValidationException`.

## Resultado esperado

- Build: `0 Warning(s)`, `0 Error(s)` (con `TreatWarningsAsErrors`).
- `Cableado/`: 37 pruebas en verde.
  - **Pipeline (`PipelineTests`):** (1) caché fría → `orchestrate_tools`, `chat`, `execute_tool …`, `chat` y 2
    llamadas al cliente; (2) caché caliente por `GetResponseAsync` → 0 spans, 0 llamadas, el instrumento
    `movilidadurbana.ai.cache.aciertos` encontrado por su nombre con +1 y el histograma `gen_ai.client.token.usage`
    sin registros nuevos; (2b) por `GetStreamingResponseAsync`, con `CoalesceStreamingUpdates` por defecto y en `false`,
    0 llamadas y +1; el caso rojo «sólo `ReadCacheAsync`» da +1 con el valor por defecto y 0 con `false`; (3) dos
    sesiones, mismo texto → dos fallos, 2 llamadas en cada una; (4) misma sesión y misma instancia: lectura cacheada →
    alta de Goya (versión de 0 a 1) → misma pregunta → fallo, `execute_tool` presente, contador sin cambio y «Hay 2
    localidades…»; los dos casos rojos sirven la respuesta vieja («Hay 1…») sin llamar al cliente.
  - **Ciclo de vida (`CicloDeVidaDelClienteTests`)**, dos sesiones concurrentes en cuatro fases separadas por una
    barrera: Scoped (con `ValidateScopes` en `true` y en `false`) → B no ve ni borra lo de A (`borradas 0`); Singleton y
    `false` → caso rojo: B ve 2 en Corrientes, borra la Goya de A (`borradas 1`) y A queda con 1, sin error; Singleton
    y `true` → las 6 llamadas a herramientas terminan en `InvalidOperationException`.
  - **Entrada HTTP (`EntradaHttpTests`):** pedidos 1–3 en 200 y el 4.º en 503 con `Retry-After: 30`, 3 llamadas al
    cliente; 2001 caracteres → 400 con 0 llamadas; el `X-Sesion-Id` vuelve en la respuesta.
  - **Lectura del uso (`LecturaDelUsoTests`):** sobre un NDJSON fijo, el handler lee 710 y 706 cacheados mientras
    `Usage.CachedInputTokenCount` es `null`, también por streaming; sin el campo, la lectura queda nula;
    `InputTokenCount` 2050 con 5134 esperados → `ContextoTruncadoException` («contexto truncado…»), y el largo esperado
    no llega al proveedor.
  - **Opciones y telemetría:** sin `TimeoutSegundos` no arranca; un `ActivityListener` con la fuente correcta ve al
    menos un span y con otro nombre 0; `EnableSensitiveData` vale `true` en Development y `false` en Production; el
    orden leído de la instancia es `CacheConContador` → `FunctionInvokingChatClient` → `OpenTelemetryChatClient` →
    cliente; ningún literal fuera de las opciones.
  - **Salida estructurada y evaluación:** caso feliz, malformado y `required`; el evaluador marca «piedra» y «bondi»;
    con el juez falso aparecen `Relevance`, `Coherence`, `Groundedness` y «Medio en catálogo».
- La suite completa sin `OLLAMA_ENDPOINT`: las 37 en verde y las 4 de `ConModelo/` `Inconclusive`. La consola de
  `dotnet test` las lista como `Skipped` y **no las suma** al total («Total tests: 37»).
- `ConModelo/`: falla ante una sola violación de sus invariantes (cada clase las escribe en su comentario). Las tasas
  se informan sin umbral.

## Resultado medido

**Sin modelo** (2026-10-28, `sdk:10.0` con el digest de «Requisitos»): build con 0 advertencias y 0 errores;
`Cableado/` 37 de 37 en verde, en tres corridas seguidas; la suite completa sin `OLLAMA_ENDPOINT` da 37 en verde y las
4 de `ConModelo/` como `Skipped` («no medido»); `aieval report` generó `informe-evaluacion.html` sobre el almacén del
juez falso.

**Contra el modelo**, una corrida de cada prueba de `ConModelo/` con el código de esta carpeta. Medido en una
estación de laboratorio con más núcleos (CPU sin GPU; contenedor limitado a 14 CPU / 34 GiB; Ollama 0.40.11),
2026-10-28. Modelo `qwen3.5:4b@d8b0f5e9760c` (Q4_K_M, provisional); T 0,7, top_p 0,8, top_k 20, presence_penalty 1,5
(preajuste de la model card para el modo sin razonamiento); `think` false; ruta `/api/chat` por OllamaSharp 5.5.0;
criterio escrito antes de correr (el comentario de cada clase de `ConModelo/`).

*Contexto truncado* (`ContextoTruncadoConModeloTests`). Cabecera R-LLM: invariantes, estimando «este pedido», 1
pedido × 3 semillas (s = 1..3) por `num_ctx`, `MaxOutputTokens` 8, prompt de 185 líneas.

| `num_ctx` | `InputTokenCount` | Resultado | Pared (N = 3) |
|---|---|---|---|
| 8192 (`AI:NumCtx`) | 5114 en las 3 semillas | respuesta «3001» en 3 de 3; el handler leyó 5114 y `CachedInputTokenCount` llegó `null` | 49,2–50,9 s |
| 4096 | 2050 en las 3 semillas | `ContextoTruncadoException` (esperado 5114, recibido 2050) en 3 de 3 | 20,2–21,4 s |

Invariantes: 0 violaciones. El prompt mide 5114 tokens con el tokenizador de `qwen3.5:4b`; el mismo texto mide 5134
con el de `qwen2.5:0.5b`: el largo esperado se mide con el mismo modelo. Con 4096 el servidor conservó 2050 tokens
(4096 / 2 + 2) y no dio error. La pared de la tabla incluye la recarga del modelo al cambiar `num_ctx`.

*Pipeline* (`PipelineConModeloTests`). Cabecera R-LLM: estimando «este pedido», 1 pedido × 10 semillas (s = 1..10),
`num_ctx` 8192, bucle de 2 iteraciones. Invariantes: 0 violaciones en 10 semillas (sin excepción, 0 escrituras, el
segundo pedido igual fue un acierto con 0 spans, contador +1 y el mismo texto, herramientas dentro de la lista cerrada).

| Qué se cuenta | k/n |
|---|---|
| pidió la herramienta (span `execute_tool contar_localidades_por_provincia`) | 10/10, Wilson 95 % [0,72; 1,00] |
| la respuesta nombra la cantidad (1) | 10/10, [0,72; 1,00] |
| el servidor informó tokens cacheados > 0 en el último `/api/chat` (362 de unos 441) | 10/10, [0,72; 1,00] |

Con la caché fría, cada semilla dejó los cuatro spans `orchestrate_tools`, `chat qwen3.5:4b`, `execute_tool …` y
`chat qwen3.5:4b`. Pared por pedido frío: 4,7–8,5 s (N = 10); es una observación de una corrida, no una cifra de
rendimiento.

*Salida estructurada* (`SalidaEstructuradaConModeloTests`). Cabecera R-LLM: estimando «este pedido», 1 pedido × 10
semillas (s = 1..10), `format` con el esquema JSON de `EncuestaPaso2Propuesta`, sin herramientas. Invariantes: 0
violaciones (sin excepción; el veredicto del evaluador coincidió con la verificación directa en las 10).

| Qué se cuenta | k/n |
|---|---|
| deserializó | 10/10, Wilson 95 % [0,72; 1,00] |
| todos los medios son claves del catálogo | 5/10, [0,24; 0,76] |
| exactamente {colectivo, bicicleta} y «diaria» | 5/10, [0,24; 0,76] |

Cómo leerlo: la forma no es validez. En las 10 corridas el JSON deserializó, y en 5 de ellas el modelo copió
«bondi» (y en 3, también «bici») en lugar de la clave del catálogo, aunque el pedido listaba los medios válidos. Por
eso el catálogo normaliza y las reglas deciden después de la propuesta. Esta tasa es de este pedido, con estos
parámetros y esta ruta; no se compara con otras corridas.

La API contra el mismo servidor (existencia, una corrida, con el comando de «Comandos»): `POST /api/v1/asistente` con
«¿Cuántas localidades hay cargadas en Corrientes?» y `X-Sesion-Id: sesion-1` → 200, el mismo `X-Sesion-Id` en la
respuesta y `{"texto":"Hay una localidad cargada en la provincia de Corrientes."}`.

No medido en este ejemplo: la estación de 4 núcleos (la cola de turnos superaba los 20 minutos y las tres pruebas
corrieron en la de más núcleos); la evaluación con juez (sólo bajo demanda); la vía `/v1`.
