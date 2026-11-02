# 10 · Workflow de MAF: el contraejemplo de la encuesta y un workflow con un paso con modelo

La encuesta de movilidad tiene tres pasos fijos (datos de la persona, medios, distancia). ¿Conviene escribirla como
workflow de Microsoft Agent Framework (MAF)? Este ejemplo la escribe de las dos maneras, como función y como grafo de
MAF, y muestra que dan lo mismo: ningún paso usa un modelo, así que no es un workflow, es código. Después arma un
workflow de verdad sobre el mismo caso: el alta asistida de una localidad («Agregá Goya, Corrientes, CP 3450, 89959
habitantes»). Un paso usa el modelo, el código fija el orden de todos los pasos y la persona confirma antes de que
se escriba nada. Por último expone una orquestación prearmada (`BuildSequential`) con la interfaz de un agente.

- **Nivel:** avanzado (opcional).
- **Sección de la guía:** §7, «Agentes, herramientas y orquestación», en el tramo del workflow de MAF (herramienta →
  agente mínimo → agente de MAF → **workflow de MAF** → multiagente). Es el contraejemplo de CASO-8 y la pieza de las
  trampas `BindAsExecutor` / `[MessageHandler]`. El registro de decisiones (D-07, nivel de orquestación) remite acá.
- **Modo sin modelo:** sí. `--sin-modelo` reemplaza al modelo por un cliente guionado. Se ve el cableado (orden de los
  pasos, puerto de confirmación, escrituras, checkpoint), no el comportamiento de un modelo. El comando `encuesta`
  nunca usa modelo. Las pruebas de `Cableado/` tampoco necesitan el servidor.

## Qué demuestra

1. **Contraejemplo (CASO-8): la encuesta como función y como workflow de MAF.** `EncuestaComoProceso` es un `for`
   sobre los tres pasos que llama a `EncuestaService.ValidarPaso` (copiado del caso base) y registra al final.
   `EncuestaComoWorkflowDeMaf` es lo mismo como grafo: tres executors `ValidarPasoExecutor` (clase `partial` con
   `[MessageHandler]`), seis aristas condicionales, un executor de rechazo y uno de registro creados desde funciones
   con `BindAsExecutor`. Para las cuatro encuestas de ejemplo dan el mismo resultado y las mismas escrituras. El grafo
   suma cinco executors, seis aristas y entre 2 y 4 supersteps, y no llama al modelo ni una vez. Es el caso de la
   regla de la documentación de MAF: «If you can write a function to handle the task, do that instead».
2. **Un workflow con un paso con modelo: el alta asistida.** `WorkflowDeAlta`:
   `extraer` (modelo, `GetResponseAsync<PropuestaDeAlta>`, sin herramientas) → `revisar` (código: `RevisorDeAlta` con
   `LocalidadRules` y el catálogo) → `confirmar-alta` (la persona, por `RequestPort`) → `registrar`
   (`LocalidadService.SaveAsync`, copiado). Si la revisión falla, la salida es `rechazo` y la persona no llega a ver la
   propuesta. El modelo produce el contenido del paso, pero no elige el siguiente: el camino es uno de dos, y los dos
   están escritos en `WorkflowBuilder`.
3. **Ninguna escritura sin confirmación.** El único executor que escribe está detrás del puerto. Si la persona dice
   que no, la salida es «Descartada». Si no responde, la corrida queda en `PendingRequests`, sin salida y sin
   escrituras. El caso de uso copiado tiene la última palabra: una duplicada confirmada no se guarda.
4. **Checkpoint y reanudación.** Con `CheckpointManager.CreateInMemory()`, una corrida que quedó esperando a la
   persona se reanuda desde su checkpoint en otra corrida, sobre otra instancia del workflow. El pedido pendiente se
   vuelve a emitir y, al confirmar, se registra sin volver a llamar al modelo. La revisión aceptada viaja en el estado
   del workflow (`QueueStateUpdateAsync` / `ReadStateAsync` con un alcance propio), que queda en el checkpoint.
5. **Orquestación prearmada expuesta como agente.** `AltaAsistidaSecuencial`: `AgentWorkflowBuilder.BuildSequential`
   con dos agentes de MAF (extractor → redactor) y `AsAIAgent()`. El tipo expuesto es `WorkflowHostAgent`, un `AIAgent`.
   Para quien lo llama es un agente, pero el orden sigue en el grafo: invertir el código invierte el orden, y el
   redactor recibe la conversación con lo que dijo el extractor.
6. **Las trampas de los executors.** (a) Sin el paquete `Microsoft.Agents.AI.Workflows.Generators`, una clase con
   `[MessageHandler]` no compila: `CS0534 … does not implement inherited abstract member
   'Executor.ConfigureProtocol(ProtocolBuilder)'`. (b) La página de executors muestra `BindExecutor` para una función;
   en 1.26.0 eso da `CS0411`, y el método es `BindAsExecutor`. (c) Un handler que produce salida por
   `context.YieldOutputAsync` sin declararla en `[MessageHandler(Yield = [...])]` compila y falla al ejecutar con
   `InvalidOperationException: Cannot output object of type String. Expecting one of []`. Las dos primeras se
   reprodujeron fuera de esta carpeta (no compilarían); la tercera es una prueba de `Cableado/`.

| Pieza | Capa | Archivo |
|---|---|---|
| `EncuestaComoProceso` (la encuesta como función) | Application (núcleo) | `src/.../Application/Encuesta/EncuestaComoProceso.cs` |
| `RevisorDeAlta`, `PropuestaDeAlta`, `IExtractorDeAlta` (puerto) | Application (núcleo) | `src/.../Application/Altas/` |
| `ExtractorDeAltaLlm` (el único que ve `IChatClient`) | Infrastructure/AI | `src/.../Infrastructure/AI/ExtractorDeAltaLlm.cs` |
| `OpcionesDeIA`, `FabricaDeOpcionesDeChat`, `ComposicionDeIA` | composición | `src/.../Infrastructure/AI/`, `appsettings*.json` |
| `EncuestaComoWorkflowDeMaf` (contraejemplo) | Infrastructure/Workflows | `src/.../Infrastructure/Workflows/EncuestaComoWorkflowDeMaf.cs` |
| `WorkflowDeAlta` (workflow con persona en el bucle) | Infrastructure/Workflows | `src/.../Infrastructure/Workflows/WorkflowDeAlta.cs` |
| `AltaAsistidaSecuencial` (`BuildSequential` + `AsAIAgent`) | Infrastructure/Workflows | `src/.../Infrastructure/Workflows/AltaAsistidaSecuencial.cs` |
| repositorios en memoria por sesión | Infrastructure/Persistence | `src/.../Infrastructure/Persistence/RepositoriosEnMemoria.cs` |
| copia literal del caso base | Domain, Application, Sessions | `src/.../CasoBase/` (ver `CasoBase/PROCEDENCIA.md`) |
| cliente guionado del modo sin modelo | — | `src/.../SinModelo/ClienteGuionado.cs` |

## Requisitos

- Docker con la imagen `mcr.microsoft.com/dotnet/sdk:10.0` (probado con
  `sha256:de4fe90a98845d75910b9769662465c84de1a934665c431279d1382b2bddc02b`, SDK 10.0.403).
- Para la consola con modelo y `ConModelo/`: el servidor Ollama de prueba con `qwen3.5:4b`, alcanzado por
  `OLLAMA_ENDPOINT` (por defecto `http://localhost:11434`). Con la receta del Anexo E de la guía (red `ia-guia`,
  contenedor `ollama`) es `--network ia-guia -e OLLAMA_ENDPOINT=http://ollama:11434`; si el servidor corre en la misma
  máquina que Docker, `--network host` y el valor por defecto.

Paquetes (versiones exactas, consultadas en nuget.org el 2026-10-28; ninguno deprecado ni con vulnerabilidades
publicadas ese día):

| Paquete | Versión | Dónde |
|---|---|---|
| `Microsoft.Agents.AI` | 1.26.0 | src |
| `Microsoft.Agents.AI.Workflows` | 1.26.0 | src |
| `Microsoft.Agents.AI.Workflows.Generators` | 1.26.0 | src (necesario para `[MessageHandler]`) |
| `Microsoft.Extensions.AI` | 10.11.0 | src |
| `OllamaSharp` | 5.5.0 | src |
| `Microsoft.Extensions.Hosting` | 10.0.14 | src |
| `Microsoft.Extensions.Http` | 10.0.14 | src |
| `Microsoft.Extensions.Options.DataAnnotations` | 10.0.14 | src |
| `NUnit` | 5.0.0 | tests |
| `NUnit3TestAdapter` | 6.3.1 | tests |
| `Microsoft.NET.Test.Sdk` | 18.11.0 | tests |

## Comandos

Desde esta carpeta. `bin/`, `obj/` y `salidas-con-modelo/` quedan fuera de git por `.gitignore`.

**Compilar:**

```bash
docker run --rm -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet build 10-Workflow.slnx
```

**Pruebas de `Cableado/` (sin modelo, deterministas):**

```bash
docker run --rm -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test 10-Workflow.slnx --filter TestCategory=Cableado
```

**La consola sin modelo.** `encuesta` compara la función con el grafo; `alta` corre el workflow de alta con los dos
textos de ejemplo (CP 34 y CP 3450); `secuencial` corre `BuildSequential` como agente. `--confirmar si|no|nadie`
elige qué responde la persona en `alta` (por defecto `si`):

```bash
docker run --rm -e DOTNET_ENVIRONMENT=Development -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet run --project src/MovilidadUrbana.Ejemplos.Orquestacion -- encuesta

docker run --rm -e DOTNET_ENVIRONMENT=Development -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet run --project src/MovilidadUrbana.Ejemplos.Orquestacion -- alta --sin-modelo --confirmar nadie
```

**La consola contra el servidor de prueba:**

```bash
docker run --rm --network ia-guia -e OLLAMA_ENDPOINT=http://ollama:11434 -e DOTNET_ENVIRONMENT=Development \
  -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet run --project src/MovilidadUrbana.Ejemplos.Orquestacion -- alta
```

Sin `-e DOTNET_ENVIRONMENT=Development` la consola no arranca: falta `TimeoutSegundos` y sale con código 3 antes del
primer pedido. `-- alta --texto "…"` usa otro texto.

**Pruebas de `ConModelo/`** (workflow de alta: 2 pedidos × 10 semillas, 1 llamada cada uno; secuencial: 1 pedido × 10
semillas, 2 llamadas cada uno; 40 llamadas en total):

```bash
docker run --rm --network ia-guia -e OLLAMA_ENDPOINT=http://ollama:11434 \
  -e ESTACION="medido en <tu equipo>, $(date +%F)" \
  -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test 10-Workflow.slnx --filter TestCategory=ConModelo --logger "console;verbosity=normal"
```

Cada prueba escribe su registro R-LLM en `tests/.../bin/Debug/net10.0/salidas-con-modelo/` (`workflow-de-alta.txt` y
`secuencial.txt`), o en la carpeta de `RLLM_SALIDA`. `CONMODELO_M` cambia la cantidad de semillas. Sin
`OLLAMA_ENDPOINT` las dos pruebas quedan `Inconclusive` («ConModelo: no medido»), que la consola de `dotnet test`
muestra como `Skipped`: nunca en verde.

## Resultado esperado

- Build: `0 Warning(s)`, `0 Error(s)` (con `TreatWarningsAsErrors`).
- `Cableado/`: 27 pruebas en verde.
  - **Contraejemplo:** para la encuesta completa y las que fallan en el paso 1 (edad 15), 2 (sin medios) y 3
    (0 minutos), la función y el grafo dan el mismo resultado, el mismo paso con errores y las mismas escrituras (1 y
    0), con 0 llamadas al modelo. El grafo tiene los executors `paso-1`, `paso-2`, `paso-3`, `rechazo` y `registro`,
    seis aristas, y ninguno es un agente.
  - **Workflow de alta:** con dos «modelos» distintos, el mismo camino `extraer > revisar > confirmar-alta >
    registrar`, una llamada al modelo y ninguna herramienta ofrecida. Propuestas inválidas (CP «34», CP «٣٤٥٠»,
    provincia «Misiones», sin habitantes, nombre «G», nombre de 61 caracteres) y JSON malformado → `extraer > revisar
    > rechazo`, 0 pedidos de confirmación, 0 escrituras. La persona confirma → «Registrada» y 1 escritura; dice que no
    → «Descartada» y 0; no responde → `PendingRequests`, sin salida, 0. «Corrientes, Corrientes» confirmada →
    «Rechazada» por el caso de uso (duplicada), 0. Entrada de 2001 caracteres → falla el executor `extraer` con
    `EntradaDemasiadoLargaException`, 0 llamadas al modelo.
  - **Checkpoint:** la primera corrida queda en `PendingRequests` con un checkpoint; la segunda, desde ese checkpoint
    y sobre otra instancia del workflow, recibe 1 pedido de confirmación, registra (1 escritura) y el modelo se llamó
    1 vez en total.
  - **Secuencial:** `WorkflowHostAgent`; dos corridas → `extractor > redactor > extractor > redactor`; el redactor
    recibe 2 mensajes y el extractor 1; con el código invertido, `redactor > extractor`.
  - **Trampa del `Yield`:** sin declararlo, `InvalidOperationException` y ninguna salida; declarado, la salida llega.
  - Ningún literal de endpoint, modelo, `num_ctx` ni timeout en `src/` fuera de `OpcionesDeIA.cs`; ningún tipo de
    Application nombra tipos de Microsoft.Extensions.AI, OllamaSharp ni Agent Framework.
- La consola sin modelo: `encuesta` muestra las cuatro filas iguales por los dos caminos; `alta --sin-modelo` rechaza
  el CP 34 y registra el CP 3450; con `--confirmar nadie` el segundo queda en `PendingRequests` y hay 0 escrituras.
- `ConModelo/`: falla ante una sola violación de las invariantes (el camino es uno de los dos fijados por código; una
  llamada al modelo por corrida del alta y dos, en orden extractor → redactor, por corrida de la secuencial; ninguna
  herramienta ofrecida; escrituras sólo con «Registrada» tras una confirmación afirmativa; sin excepción). Las tasas
  se informan sin umbral y no se comparan entre sí.

## Resultado medido

**Sin modelo** (2026-10-28, `sdk:10.0` con el digest de «Requisitos», copia limpia): build con 0 advertencias y 0
errores; `Cableado/` 27 de 27 en verde (cinco corridas seguidas de la suite, sin fallas); la suite completa sin
`OLLAMA_ENDPOINT` da 27 en verde y las 2 de `ConModelo/` en `Skipped` («no medido»); la consola sale con código 0 en
los cinco comandos de «Resultado esperado» y con código 3 sin `DOTNET_ENVIRONMENT=Development`.

**Contra el modelo**, una corrida de `ConModelo/` con el código de esta carpeta. Cabecera R-LLM: estimando «este
pedido»; `qwen3.5:4b@d8b0f5e9760c` (Q4_K_M, provisional); T 0,7, top_p 0,8, top_k 20, presence_penalty 1,5 (preajuste
de la model card de Qwen3.5-4B para el modo sin razonamiento); `think` false; `num_ctx` 8192; vía nativa `/api/chat`
(OllamaSharp 5.5.0); semillas s = 1..10, una por corrida; criterio escrito antes de correr (el comentario de
`ConModelo/WorkflowConModeloTests.cs`). Medido en la estación de laboratorio de 15 vCPU (CPU sin GPU; contenedor
limitado a 14 CPU / 34 GiB; Ollama 0.40.11), 2026-10-28.

**Invariantes:** 0 violaciones en 20 corridas del workflow de alta (siempre uno de los dos caminos fijados por código,
1 llamada al modelo sin herramientas, escrituras sólo con «Registrada» tras una confirmación afirmativa, ninguna
excepción) y 0 en 10 corridas de la secuencial (2 llamadas, siempre extractor → redactor, sin herramientas).

Cada fila es una tasa de **este pedido** (1 pedido × 10 semillas); no es una tasa de la tarea y las filas no se
comparan entre sí.

| Pedido | Qué se cuenta | k/n, Wilson 95 % |
|---|---|---|
| alta, «Agregá Goya, Corrientes, CP 34, 89959 habitantes» | la propuesta trae el CP «34» del texto | 8/10, [0,49; 0,94] |
| | la revisión en código la rechazó (la persona no la vio) | 9/10, [0,60; 0,98] |
| | llegó a la persona con un CP de 4 dígitos que el texto no dice | 1/10, [0,02; 0,40] |
| alta, «Agregá Goya, Corrientes, CP 3450, 89959 habitantes» | propuesta exacta (Goya, Corrientes, 3450, 89959) | 10/10, [0,72; 1,00] |
| | registrada tras la confirmación | 10/10, [0,72; 1,00] |
| secuencial, el mismo texto con CP 3450 | la línea del extractor contiene «3450» | 10/10, [0,72; 1,00] |
| | el redactor nombra Goya y Corrientes | 10/10, [0,72; 1,00] |
| | el redactor repite «3450» | 10/10, [0,72; 1,00] |

Cómo leerlo: con el CP inválido, el modelo inventó un código postal en 2 de 10 corridas. En una («34899», 5 dígitos)
la revisión en código lo rechazó. En la otra («3489», 4 dígitos) la revisión no tenía cómo detectarlo, porque es un
CP con la forma válida, y la propuesta llegó a la persona, que en la prueba la rechazó. Por eso el workflow pone a la
persona antes de la escritura: las reglas protegen la forma del dato, no su exactitud. Pared por corrida en esa
estación: mediana 5,2 s el alta (1 llamada; 4,9–5,5 s, N = 20) y 5,0 s la secuencial (2 llamadas; 4,4–8,1 s, N = 10).
Es una observación de una corrida, no una cifra de rendimiento, y no se compara con las de la estación de 4 núcleos.

No medido en este ejemplo: la estación de 4 núcleos (la cola de turnos superaba 20 minutos); otras redacciones del
pedido (no hay tasa de la tarea); un checkpoint persistido en disco (`FileSystemJsonCheckpointStore`) y la reanudación
tras reiniciar el proceso; orquestaciones en las que un modelo elige el paso siguiente (*handoff*, *group chat*,
*Magentic*).
