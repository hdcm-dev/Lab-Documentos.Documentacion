# 01 · Chat básico

Primer contacto con un modelo desde .NET, con el caso de Movilidad Urbana: una consola que le pregunta al asistente de
la encuesta por los requisitos de una localidad, con historial explícito, configuración validada al arrancar y el
proveedor elegido por configuración.

- **Nivel:** básico.
- **Sección de la guía:** §5, «Hablar con un modelo desde .NET» (`IChatClient`, `OpcionesDeIA`, `num_ctx` por pedido,
  la tabla de diferencias entre la vía nativa y `/v1`, y la regla de credenciales). También lo citan el Anexo A
  (plantilla de `OpcionesDeIA`) y §8, «Operar, evaluar y asegurar» (el control «opciones validadas al arrancar»).
- **Modo sin modelo:** no hay. La consola necesita el servidor; las pruebas de `Cableado/` corren sin él.

## Qué demuestra

1. **`IChatClient` con OllamaSharp** (vía nativa, `/api/chat`). El resto del código sólo ve `IChatClient`.
2. **`OpcionesDeIA`:** una sola clase ligada a la sección `AI`, con `ValidateDataAnnotations().ValidateOnStart()`.
   `TimeoutSegundos` no tiene valor por defecto en el código: lo declara `appsettings.Development.json`.
   `[ValidateObjectMembers]` hace que se validen también `Concurrencia` y `Muestreo`. Las variables
   `OLLAMA_ENDPOINT`, `OLLAMA_MODEL` y `OLLAMA_EMBEDDING_MODEL` pisan la sección sólo si están definidas.
3. **`num_ctx` por pedido**, con `ChatOptions.AdditionalProperties["num_ctx"]`, sólo por la vía nativa.
4. **Largo máximo de entrada:** un texto de más de `LargoMaximoDeEntrada` caracteres se rechaza antes de llamar al
   modelo.
5. **Selector `AI:Proveedor`** (`ollama` | `openai-compatible`). Este ejemplo y el 06 son los dos únicos lugares de la
   guía donde aparece. Con `openai-compatible` no se cumple la regla de `num_ctx`: por `/v1`, Ollama no acepta
   `num_ctx` por pedido.
6. **Credenciales en un `DelegatingHandler`** (`ManejadorDeCredenciales`) sobre el `HttpClient` de
   `IHttpClientFactory`. Nunca en un campo que viaje en el cuerpo del pedido.
7. **Muestreo del fabricante** por configuración (`AI:Muestreo`): el preajuste «Instruct (or non-thinking) mode for
   general tasks» de la model card de Qwen3.5-4B (`temperature 0.7`, `top_p 0.8`, `top_k 20`, `min_p 0.0`,
   `presence_penalty 1.5`, `repetition_penalty 1.0`). `TopK`, `min_p` y `repeat_penalty` llegan sólo por la vía nativa.

### Qué llega al servidor por cada vía

Lo reproduce `Cableado/CuerpoDelPedidoTests` capturando el cuerpo del pedido con un servidor falso, con las mismas
`ChatOptions` y `MaxOutputTokens = 3`:

| `ChatOptions` | OllamaSharp 5.5.0 → `/api/chat` | MEAI.OpenAI 10.11.0 → `/v1/chat/completions` |
|---|---|---|
| `TopK` | viaja (`options.top_k`) | no viaja: se descarta en silencio |
| `num_ctx` (por `AdditionalProperties`) | viaja (`options.num_ctx`) | no viaja (no se puede fijar por pedido) |
| `MaxOutputTokens` | `options.num_predict` | `max_completion_tokens` |
| `Reasoning.Effort = None` | `think: false` | `reasoning_effort: "none"` |
| credencial (por `ManejadorDeCredenciales`) | encabezado `Authorization`, no en el cuerpo | encabezado `Authorization`, no en el cuerpo |

Contra el servidor real, `max_completion_tokens` no acota la salida: lo mide `ConModelo/MaxOutputTokensConModeloTests`
(ver «Resultado medido»).

## Requisitos

- Docker. Todo se compila y se corre en `mcr.microsoft.com/dotnet/sdk:10.0` (SDK 10.0.403 al 2026-10-28).
- Para la consola y `ConModelo/`: el servidor Ollama de prueba levantado con la receta del Anexo E de la guía (red
  `ia-guia`, contenedor `ollama`), con los modelos `qwen3.5:4b` y, para la prueba de `num_ctx`, el modelo de humo
  `qwen2.5:0.5b`. Si el servidor corre en otro lado, alcanza con cambiar `OLLAMA_ENDPOINT` (por defecto
  `http://localhost:11434`).

## Estructura

```text
01-Chat-Basico/
├── 01-Chat-Basico.slnx
├── src/MovilidadUrbana.Ejemplos.ChatBasico/
│   ├── Program.cs                         # consola: arranca el host y hace dos preguntas
│   ├── appsettings.json                   # proveedor, endpoint, modelo, num_ctx, muestreo
│   ├── appsettings.Development.json       # TimeoutSegundos
│   ├── Configuracion/OpcionesDeIA.cs      # la única clase de opciones
│   ├── Configuracion/ComposicionDeIA.cs   # el único lugar que conoce al proveedor
│   ├── Configuracion/ManejadorDeCredenciales.cs
│   ├── Conversacion/AsistenteDeMovilidad.cs
│   └── Conversacion/FabricaDeOpcionesDeChat.cs
└── tests/MovilidadUrbana.Ejemplos.ChatBasico.Tests/
    ├── Cableado/    # sin modelo, deterministas, siempre
    └── ConModelo/   # contra el servidor de prueba, por turno; sin OLLAMA_ENDPOINT quedan «no medido»
```

## Comandos

Desde esta carpeta. Los `bin/` y `obj/` que se generan están en `.gitignore`.

**Compilar:**

```bash
docker run --rm -v "$PWD":/work -w /work mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet build 01-Chat-Basico.slnx -c Release
```

**Pruebas de `Cableado/` (sin modelo):**

```bash
docker run --rm -v "$PWD":/work -w /work mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test 01-Chat-Basico.slnx -c Release --filter TestCategory=Cableado
```

**La consola contra el servidor de prueba:**

```bash
docker run --rm --network ia-guia -e OLLAMA_ENDPOINT=http://ollama:11434 -e DOTNET_ENVIRONMENT=Development \
  -v "$PWD":/work -w /work mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet run --project src/MovilidadUrbana.Ejemplos.ChatBasico -c Release
```

Variantes: `-- --pregunta "¿Cuántos habitantes como mínimo?"` cambia la primera pregunta;
`-- --AI:Proveedor=openai-compatible` usa la vía `/v1` (sin `num_ctx`). Sin `-e DOTNET_ENVIRONMENT=Development` la
consola no arranca: falta `TimeoutSegundos` y sale con código 3 antes del primer pedido.

**Pruebas de `ConModelo/` (contra el servidor de prueba):**

```bash
docker run --rm --network ia-guia -e OLLAMA_ENDPOINT=http://ollama:11434 \
  -v "$PWD":/work -w /work mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test 01-Chat-Basico.slnx -c Release --filter TestCategory=ConModelo --logger "console;verbosity=normal"
```

Cada prueba escribe su registro R-LLM en `tests/.../bin/Release/net10.0/salidas-con-modelo/` (o en la carpeta de
`RLLM_SALIDA`). Sin `OLLAMA_ENDPOINT`, las tres quedan `Inconclusive` («ConModelo: no medido»): nunca en verde.

## Resultado esperado

- `Cableado`: 17 de 17 en verde. Arranque sin `TimeoutSegundos` y con `AI:Concurrencia:Permisos = 0` →
  `OptionsValidationException`; proveedor desconocido → `OptionsValidationException`; entrada de 2001 caracteres →
  `EntradaDemasiadoLargaException` con 0 llamadas al modelo (y 2000 caracteres → 1 llamada); la segunda pregunta viaja
  con `system, user, assistant, user`; ningún literal de endpoint, modelo, `num_ctx` ni timeout en `src/` fuera de
  `OpcionesDeIA.cs` (con tres casos rojos que prueban el patrón); la tabla de arriba; la credencial en el encabezado y
  no en el cuerpo, por las dos vías.
- La consola: dos respuestas en español; la segunda usa el historial («¿Y la provincia…?» se entiende como la provincia
  de la localidad).
- `ConModelo`: ver los criterios en «Resultado medido».

Los requisitos del mensaje de sistema son los que enuncia la política del caso base (`LocalidadPolicy`). El código
del caso base no los hace cumplir todos: no verifica el máximo de 60 caracteres del nombre, acepta dígitos que no son
ASCII en el código postal y no controla que la provincia sea del catálogo. El modelo repite la política; lo que el
código acepta lo muestran las pruebas de la demo.

## Resultado medido

Medido en la estación de laboratorio (CPU de 4 núcleos sin GPU; contenedor limitado a 4 CPU / 5 GB; Ollama 0.40.11),
2026-10-28, con `mcr.microsoft.com/dotnet/sdk:10.0` (SDK 10.0.403,
`sha256:de4fe90a98845d75910b9769662465c84de1a934665c431279d1382b2bddc02b`). Los criterios se escribieron antes de
correr y están en el comentario de cada clase de `ConModelo/`.

**Sin modelo.** Compilación: 0 advertencias, 0 errores. `Cableado`: 18 de 18 en verde. `ConModelo` sin
`OLLAMA_ENDPOINT`: las tres pruebas quedan «Skipped» con el mensaje «ConModelo: no medido (falta OLLAMA_ENDPOINT)».
La consola sin `DOTNET_ENVIRONMENT=Development` sale con código 3 («'TimeoutSegundos' … must be between 1 and 3600»),
y con una pregunta de 2001 caracteres sale con código 2 sin haber llamado al servidor.

**Contra el modelo** (cabecera R-LLM de cada prueba; los registros crudos los escribe la prueba en
`salidas-con-modelo/`):

| Prueba | Cabecera R-LLM | Resultado |
|---|---|---|
| `ChatConModeloTests` | 10/10 — estimando: este pedido, 1 pedido × 10 semillas (s = 1..10), `qwen3.5:4b@d8b0f5e9760c`, T 0,7, `top_p` 0,8, `top_k` 20, `presence_penalty` 1,5, think false, `num_ctx` 8192, `/api/chat` (OllamaSharp 5.5.0), criterio previo: invariantes en 10/10 y «nombra 4 dígitos» con k ≥ 8, 2026-10-28; Wilson 95 % [0,72; 1]; crudo: `chat-basico-4b.txt` | invariantes (texto no vacío, `stop`, `InputTokenCount` > 0): 0 violaciones. 130 tokens de entrada; pared por llamada de 2,4 a 10,1 s, mediana 2,9 s (la primera, 10,1 s). Respondió con Markdown (`**4 dígitos**`) en 7 de 10, aunque el sistema pide una o dos oraciones: la salida del modelo se trata como texto |
| `MaxOutputTokensConModeloTests` | 3/3 y 3/3 — estimando: este pedido, 1 pedido × 3 semillas por vía (s = 1..3), `qwen3.5:4b@d8b0f5e9760c`, T 0,7, `MaxOutputTokens` 3, `/api/chat` (OllamaSharp) y `/v1/chat/completions` (MEAI.OpenAI 10.11.0), criterio previo: nativa ≤ 3 en 3/3 (invariante), `/v1` > 3 en al menos 1 de 3 (existencia), 2026-10-28; crudo: `max-output-tokens-4b.txt` | vía nativa: 3 tokens de salida en 3 de 3, `FinishReason` `length`. Vía `/v1`: 30, 35 y 31 tokens de salida, `FinishReason` `stop`: se observó que `MaxOutputTokens` no acota la salida en 3 de 3. Por `/v1` no se puede contar con `MaxOutputTokens` para acotar el tiempo de respuesta |
| `NumCtxConModeloTests` | 3/3 en (a), (b) y (c) — estimando: este pedido (invariantes), 1 pedido × 3 semillas por tamaño (s = 1..3) más 1 de referencia, `qwen2.5:0.5b@a8b0c5157701`, T 0,7, think sin enviar, `num_ctx` 16384 / 8192 / 4096, `MaxOutputTokens` 3, `/api/chat` (OllamaSharp), criterio previo: (a) entrada(8192) > 4096, (b) entrada(4096) ≤ 4096, (c) entrada(8192) = entrada(16384), 2026-10-28; crudo: `num-ctx-humo.txt` | prompt de 242 líneas (22 014 caracteres): 6843 tokens de entrada con 16384 y con 8192 (3 de 3); **2050** con 4096 (3 de 3), con `FinishReason` `stop` y sin ningún error: el servidor truncó en silencio a menos de la mitad del prompt. `num_ctx` llega por pedido: sin él, los dos tamaños darían lo mismo. Pared: 137,6 s la de referencia, 165,8 s la primera con 8192 (recarga del modelo y lectura sin caché), 0,3–0,4 s las repeticiones del mismo prompt |

**La consola** (existencia, 1 corrida de 2 vueltas por vía, sin semilla, `qwen3.5:4b@d8b0f5e9760c`, muestreo de
`appsettings.json`, 2026-10-28):

```text
Proveedor: ollama; modelo: qwen3.5:4b; num_ctx: 8192
> ¿Cuántos dígitos lleva el código postal de una localidad?
El código postal debe consistir en **cuatro** dígitos numéricos.
  [uso] entrada=130 salida=19 fin=stop
> ¿Y la provincia puede ser cualquiera?
No, la provincia no puede ser cualquiera; solo se pueden seleccionar las provincias específicas del catálogo como Buenos Aires, Chaco, Córdoba, Corrientes, Entre Ríos, Mendoza o Santa Fe.
  [uso] entrada=166 salida=41 fin=stop
```

Con `--AI:Proveedor=openai-compatible` la primera línea dice `num_ctx: no se fija por /v1` y las dos respuestas
llegan igual (130 y 160 tokens de entrada). Pared total del proceso, contenedor incluido: 24 s por la vía nativa y
54 s por `/v1`, corridas en ese orden. La diferencia no se desglosó: la vía `/v1` no manda `num_ctx`, así que no
pide el mismo contexto con que quedó cargado el modelo. Por eso la regla es que todos los clientes del mismo modelo
usen el mismo `num_ctx`.

El truncado de la última fila es el motivo de comparar `Usage.InputTokenCount` con lo que se esperaba mandar: el
servidor no avisa.
