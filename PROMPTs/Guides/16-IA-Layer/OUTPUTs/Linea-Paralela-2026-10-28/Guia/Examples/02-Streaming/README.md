# 02 · Streaming y cancelación

Nivel básico. Lo usa la sección **§5 «Hablar con un modelo desde .NET»** de la guía, en la parte de streaming y cancelación. Es la única pieza dedicada a `GetStreamingResponseAsync` y `ChatResponseUpdate`: la demo de Movilidad Urbana no la trae, porque su página de chat publica eventos propios (`TextoParcial`, `EtapaIniciada`, `Final`).

## Qué demuestra

Un asistente de consola contesta preguntas sobre la encuesta de movilidad urbana (campos, rangos y catálogos de `RespuestaDeEncuesta`, `EncuestaRules` y `Catalogos` del caso base) y muestra el texto a medida que llega.

- `IChatClient.GetStreamingResponseAsync` con `await foreach` sobre `ChatResponseUpdate` (`AsistenteDeLaEncuesta.cs`).
- `ToChatResponse()` y `AddMessages(...)`: los fragmentos se recomponen en **un** mensaje del asistente, con `FinishReason` y `Usage`, que en streaming llegan en el último fragmento.
- Cancelación con `CancellationToken` (Ctrl+C o `--cortar-a-los`). El texto parcial se devuelve y **no** entra al historial.
- **El corte hay que mirarlo en el token, no sólo esperar la excepción.** Con OllamaSharp 5.5.0, cancelar terminó la enumeración **sin lanzar** `OperationCanceledException` (se ve en «Resultado medido»). Si el código sólo atrapa la excepción, toma la respuesta cortada como completa y la guarda en el historial. Por eso `ResponderAsync` revisa `ct.IsCancellationRequested` después del `await foreach`, y `Cableado/` prueba los dos comportamientos del proveedor.
- `OpcionesDeIA` (sección `AI`, validada al arrancar) como la única fuente del endpoint, el modelo, `num_ctx` (por pedido), el timeout, el largo máximo de entrada y el muestreo. El razonamiento se apaga con `ChatOptions.Reasoning`.
- Los registros por pedido del `HttpClient` quedan en `Warning` en `appsettings.json`, porque en `Information` escriben la URL del servidor en la consola.

## Requisitos

- Docker con la imagen `mcr.microsoft.com/dotnet/sdk:10.0` (se probó con el SDK 10.0.403).
- Para correr contra el modelo: el servidor Ollama de prueba de la receta del Anexo E, con `qwen3.5:4b`, alcanzable por `OLLAMA_ENDPOINT` (por defecto `http://localhost:11434`). En la receta, el servidor está en la red de Docker `ia-guia` con el nombre `ollama`.

| Paquete | Versión |
|---|---|
| `Microsoft.Extensions.AI` | 10.11.0 |
| `OllamaSharp` | 5.5.0 |
| `Microsoft.Extensions.Hosting` | 10.0.14 |
| `Microsoft.Extensions.Http` | 10.0.14 |
| `Microsoft.Extensions.Options.DataAnnotations` | 10.0.14 |
| `NUnit` | 5.0.0 |
| `NUnit3TestAdapter` | 6.3.1 |
| `Microsoft.NET.Test.Sdk` | 18.11.0 |

`dotnet list package --vulnerable --include-transitive` y `--deprecated` no dieron hallazgos en ninguno de los dos proyectos (2026-10-28).

## Estructura

```
02-Streaming/
├── src/MovilidadUrbana.Streaming/        consola: OpcionesDeIA, ComposicionDeIA, AsistenteDeLaEncuesta, Program
└── tests/MovilidadUrbana.Streaming.Tests/
    ├── Cableado/    sin modelo, deterministas, corren siempre (cliente falso con guion)
    └── ConModelo/   contra el servidor de prueba; sin OLLAMA_ENDPOINT quedan Inconclusive
```

## Comandos

Desde esta carpeta. El volumen `nuget` es opcional y sirve como caché de paquetes.

**Build y pruebas de cableado (sin modelo):**

```bash
docker run --rm -v "$PWD":/src -v nuget:/root/.nuget/packages -w /src mcr.microsoft.com/dotnet/sdk:10.0 \
  bash -c "dotnet build tests/MovilidadUrbana.Streaming.Tests -c Release && \
           dotnet test tests/MovilidadUrbana.Streaming.Tests -c Release --no-build --filter TestCategory=Cableado"
```

**Correr el ejemplo contra el modelo** (`DOTNET_ENVIRONMENT=Development` carga `appsettings.Development.json`, que declara `TimeoutSegundos`; sin él, el host no arranca):

```bash
docker run --rm --network ia-guia -e OLLAMA_ENDPOINT=http://ollama:11434 -e DOTNET_ENVIRONMENT=Development \
  -v "$PWD":/src -v nuget:/root/.nuget/packages -w /src mcr.microsoft.com/dotnet/sdk:10.0 \
  bash -c "dotnet run --project src/MovilidadUrbana.Streaming -c Release"

# cortado a los 20 s (también se corta con Ctrl+C si el contenedor corre con -it)
docker run --rm --network ia-guia -e OLLAMA_ENDPOINT=http://ollama:11434 -e DOTNET_ENVIRONMENT=Development \
  -v "$PWD":/src -v nuget:/root/.nuget/packages -w /src mcr.microsoft.com/dotnet/sdk:10.0 \
  bash -c "dotnet run --project src/MovilidadUrbana.Streaming -c Release -- \
           --pregunta 'Explicá con detalle, campo por campo, todo lo que pide la encuesta y para qué sirve cada dato.' --cortar-a-los 20"
```

**Pruebas contra el modelo** (las salidas crudas, con la cabecera R-LLM, quedan en `salida-r-llm/`):

```bash
docker run --rm --network ia-guia -e OLLAMA_ENDPOINT=http://ollama:11434 -e R_LLM_SALIDA=/src/salida-r-llm \
  -v "$PWD":/src -v nuget:/root/.nuget/packages -w /src mcr.microsoft.com/dotnet/sdk:10.0 \
  bash -c "dotnet test tests/MovilidadUrbana.Streaming.Tests -c Release --filter TestCategory=ConModelo --logger 'console;verbosity=normal'"
```

Modo sin modelo: no tiene. Sin `OLLAMA_ENDPOINT`, `ConModelo/` queda `Inconclusive` («no medido») y `Cableado/` cubre el código sin servidor.

## Resultado esperado

- `Cableado/`: 9 de 9 en verde. Los fragmentos llegan en orden y `ToChatResponse()` recompone el mismo texto, con un solo mensaje del asistente en el historial. Cancelar a mitad corta en menos de 1 s, con el proveedor que lanza la excepción y con el que termina la enumeración sin lanzar, y el historial queda como estaba. `num_ctx`, el razonamiento apagado, el muestreo y la semilla viajan desde `OpcionesDeIA`. Una pregunta de 2001 caracteres no llama al modelo. Sin `TimeoutSegundos`, el host no arranca (`OptionsValidationException`).
- Corrida: el texto aparece de a pedazos y al final se imprime el motivo de fin, los tokens, los fragmentos, el tiempo al primer texto y el total.
- `ConModelo/`: los invariantes del criterio, escrito en el encabezado de `ConModelo/StreamingConModeloTests.cs` antes de correr, se cumplen en cada semilla.

## Resultado medido

Medido en la estación de laboratorio (CPU de 4 núcleos sin GPU; contenedor limitado a 4 CPU / 5 GB; Ollama 0.40.11), 2026-10-28, con `qwen3.5:4b@d8b0f5e9760c` (Q4_K_M), T 0,7, top_p 0,8, top_k 20, presence_penalty 1,5, razonamiento apagado, `num_ctx` 8192, ruta `/api/chat` por OllamaSharp 5.5.0. `qwen3.5:4b` es el modelo provisional de la guía. El anfitrión no estaba reservado: los tiempos variaron mucho entre corridas, y por eso se dan como rango y no como referencia.

**Cableado:** 9/9 en verde (SDK 10.0.403).

**Respuesta completa en streaming.** 10/10 sin violar los invariantes. Estimando: este pedido, 1 pedido × 10 semillas (s = 1..10); criterio previo: el (1) del encabezado de la prueba; Wilson 95 % [0,72; 1,00].
- Fragmentos con texto: de 51 a 90 por respuesta, más uno final sin texto que trae el uso. En las 10 corridas, `FinishReason` fue `stop` y `Usage` llegó con datos (206 tokens de entrada; de 52 a 93 de salida).
- Primer texto: 24,9 s en la semilla 1; de 0,47 a 1,86 s en las semillas 2 a 10, con la mediana en 0,51 s. Las semillas 2 a 10 repiten el mismo prompt, y el servidor reusa lo que ya leyó.
- Total: de 14,2 a 80,8 s, con la mediana en 18,1 s.

**Cancelación al primer texto.** 10/10 sin violar los invariantes. Estimando: este pedido, 1 pedido × 10 semillas (s = 1..10); criterio previo: el (2) del encabezado; Wilson 95 % [0,72; 1,00].
- `Cancelada` dio verdadero en las 10 corridas, sin ningún texto después de `Cancel()`.
- `ResponderAsync` volvió en 0,01 s o menos desde `Cancel()`.
- El primer texto llegó entre 23,8 y 50,4 s.

**Antes del arreglo.** Cuando `ResponderAsync` sólo atrapaba `OperationCanceledException`, la misma prueba dio «no cancelada» en 10 de 10 (existencia: la enumeración de OllamaSharp 5.5.0 terminó sin lanzar). El programa cortado a los 20 s informó «completa» con el motivo de fin vacío y guardó la respuesta parcial en el historial. Es el caso que cubre la prueba de cableado «el proveedor termina la enumeración sin lanzar».

**Qué no se midió.** Si el servidor deja de generar la respuesta cortada. Una primera versión de la prueba lo leía en el tiempo al primer texto de una pregunta siguiente, y quedó descartada: ese tiempo depende sobre todo de cuánto del prompt anterior reusa el servidor. Dio 10 de 10 «menos de 15 s» cuando el parcial quedaba en el historial (el prompt siguiente extendía el anterior) y 0 de 10 cuando no quedaba.
