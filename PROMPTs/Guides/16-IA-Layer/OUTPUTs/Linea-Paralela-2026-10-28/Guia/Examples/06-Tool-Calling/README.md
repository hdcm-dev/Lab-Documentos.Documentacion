# 06 · Tool calling: el primer ejercicio

Una persona le pregunta al asistente de la encuesta «¿Cuántas localidades hay cargadas en Chaco?». El modelo no sabe
la respuesta y no la tiene que inventar: pide una herramienta, la aplicación la ejecuta sobre un caso de uso de
lectura, y el modelo redacta la respuesta con el resultado. Es el primer ejercicio de la guía.

- **Nivel:** básico, primer ejercicio.
- **Sección de la guía:** §7, «Agentes, herramientas y orquestación» (herramienta → agente mínimo; límites del bucle).
  §5, «Hablar con un modelo desde .NET», remite acá para el tool calling con `UseFunctionInvocation`, y éste es uno
  de los dos lugares del selector `AI:Proveedor` (el otro es el ejemplo 01). §8, «Operar, evaluar y asegurar», cita
  las pruebas de los controles CTRL-02 (argumentos validados en la aplicación), CTRL-05 (límites del bucle por
  configuración) y CTRL-06 (herramientas por sesión).
- **Modo sin modelo:** sí. `--sin-modelo` reemplaza al modelo por un cliente guionado: se ve el cableado (bucle,
  herramientas, casos de uso, sesión), no el comportamiento de un modelo. Las pruebas de `Cableado/` tampoco
  necesitan el servidor.

## Qué demuestra

1. **Herramientas finas sobre casos de uso, sólo de lectura.** `contar_localidades_por_provincia(provincia)` y
   `listar_localidades(provincia?, codigoPostal?, nombre?)`. El adaptador (`HerramientasDeLocalidades`) no valida ni
   filtra por su cuenta: llama a `ConsultaDeLocalidades` (núcleo), que delega en `LocalidadService` (copiado del caso
   base). Ninguna herramienta escribe; la lista de nombres es cerrada y una prueba la compara con lo registrado.
2. **El modelo propone; la aplicación valida.** `NormalizadorDeCatalogos` (núcleo) revisa cada argumento antes del
   caso de uso: la provincia contra `Catalogos.Provincias` («chaco» se normaliza a «Chaco»; «Misiones» se rechaza),
   el código postal con 4 dígitos 0-9 y el nombre con 60 caracteres como máximo. El rechazo vuelve al modelo como
   errores por campo, con los nombres del ABM (`provincia`, `codigoPostal`, `nombre`), sin leer ni escribir nada.
3. **Herramientas por sesión.** Las herramientas se crean en el ámbito de cada sesión, con su `ISessionContext`; el
   repositorio filtra por sesión como el del caso base. Una localidad que cargó otra sesión no se ve, y la respuesta es
   **idéntica** a la de una localidad que no existe. Eso aísla datos; no es control de acceso: en el caso base el
   identificador de sesión lo elige el cliente.
4. **Un agente mínimo con el bucle acotado (CTRL-05).** `IChatClient` + `FunctionInvokingChatClient`, con
   `MaximumIterationsPerRequest` y `MaximumConsecutiveErrorsPerRequest` leídos de `AI:Herramientas` (3 y 2: dos
   herramientas encadenables + 1, y 2 errores consecutivos; valores elegidos con esa regla, no medidos). Las pruebas
   miden qué hace el paquete al llegar a cada límite (ver «Resultado esperado»).
5. **Selector de proveedor sin tocar Application.** `AI:Proveedor` = `ollama` (OllamaSharp 5.5.0 → `/api/chat`) u
   `openai-compatible` (MEAI.OpenAI 10.11.0 → `/v1/chat/completions`). Lo único que cambia es
   `ComposicionDeIA.CrearClienteDelProveedor`. Una prueba con dos proveedores falsos (un servidor HTTP falso que
   habla los dos protocolos) muestra que el caso de uso recibe y devuelve lo mismo por las dos vías, y otra comprueba
   por reflexión que ningún tipo de Application ni de Domain nombra un tipo de Microsoft.Extensions.AI, OllamaSharp u
   OpenAI. Por `/v1` no viajan `num_ctx` ni `TopK` (la tabla de diferencias está en el ejemplo 01 y en §5 de la guía).

### Lo que lee el modelo no es igual por las dos vías

El caso de uso devuelve lo mismo, pero el mensaje `tool` que recibe el modelo cambia con el adaptador. Lo captura
`Cableado/ProveedorTests.ElResultadoDeLaHerramientaViajaAlModelo_EnElFormatoDeCadaVia`:

| | OllamaSharp 5.5.0 → `/api/chat` | MEAI.OpenAI 10.11.0 → `/v1/chat/completions` |
|---|---|---|
| contenido del mensaje `tool` | el `FunctionResultContent` entero: `{"CallId":"…","Result":{…}}` | sólo el resultado: `{"ok":true,"datos":{…},"errores":{}}` |
| id de la llamada | dentro del contenido (`CallId`, lo genera el cliente: Ollama no manda id) | aparte, en `tool_call_id` |
| `ChatToolMode.Auto` | no se manda campo | `"tool_choice":"auto"` |
| `num_ctx` | `options.num_ctx` | no viaja |

Que `/v1` mande `tool_choice` no prueba que Ollama lo haga cumplir: eso no se midió en este ejemplo.

| Pieza | Capa | Archivo |
|---|---|---|
| `NormalizadorDeCatalogos` | Application (núcleo) | `src/.../Application/Normalizacion/NormalizadorDeCatalogos.cs` |
| `ConsultaDeLocalidades` (casos de uso de lectura) | Application (núcleo) | `src/.../Application/Consultas/ConsultaDeLocalidades.cs` |
| `IAsistenteDeLocalidades` (puerto, sin tipos de MEAI) | Application | `src/.../Application/Asistente/IAsistenteDeLocalidades.cs` |
| `HerramientasDeLocalidades` (adaptador de entrada) | Infrastructure/AI | `src/.../Infrastructure/AI/HerramientasDeLocalidades.cs` |
| `AsistenteDeLocalidades` (el único que ve `IChatClient`) | Infrastructure/AI | `src/.../Infrastructure/AI/AsistenteDeLocalidades.cs` |
| `ComposicionDeIA` (selector y límites del bucle) | composición | `src/.../Infrastructure/AI/ComposicionDeIA.cs` |
| `OpcionesDeIA` (sección `AI`, validada al arrancar) | composición | `src/.../Infrastructure/AI/OpcionesDeIA.cs`, `appsettings*.json` |
| repositorio en memoria por sesión | Infrastructure/Persistence | `src/.../Infrastructure/Persistence/` |
| copia literal del caso base | Domain, Application, Sessions | `src/.../CasoBase/` (ver `CasoBase/PROCEDENCIA.md`) |
| cliente guionado del modo sin modelo | — | `src/.../SinModelo/ClienteGuionado.cs` |

## Requisitos

- Docker con la imagen `mcr.microsoft.com/dotnet/sdk:10.0` (probado con
  `sha256:de4fe90a98845d75910b9769662465c84de1a934665c431279d1382b2bddc02b`, SDK 10.0.403).
- Para la consola con modelo y `ConModelo/`: el servidor Ollama de prueba con `qwen3.5:4b`, alcanzado por
  `OLLAMA_ENDPOINT` (por defecto `http://localhost:11434`). Con la receta del Anexo E de la guía (red `ia-guia`,
  contenedor `ollama`) es `--network ia-guia -e OLLAMA_ENDPOINT=http://ollama:11434`; si el servidor corre en la misma
  máquina que Docker, `--network host` y el valor por defecto.

Paquetes (versiones exactas, consultadas en nuget.org el 2026-10-28):

| Paquete | Versión | Dónde |
|---|---|---|
| `Microsoft.Extensions.AI` | 10.11.0 | src |
| `Microsoft.Extensions.AI.OpenAI` | 10.11.0 | src |
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
  dotnet build 06-Tool-Calling.slnx
```

**Pruebas de `Cableado/` (sin modelo, deterministas):**

```bash
docker run --rm -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test 06-Tool-Calling.slnx --filter TestCategory=Cableado
```

**La consola sin modelo** (cliente guionado):

```bash
docker run --rm -e DOTNET_ENVIRONMENT=Development -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet run --project src/MovilidadUrbana.Ejemplos.ToolCalling -- --sin-modelo
```

**La consola contra el servidor de prueba:**

```bash
docker run --rm --network ia-guia -e OLLAMA_ENDPOINT=http://ollama:11434 -e DOTNET_ENVIRONMENT=Development \
  -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet run --project src/MovilidadUrbana.Ejemplos.ToolCalling
```

`-- --AI:Proveedor=openai-compatible` usa la vía `/v1` (sin `num_ctx`). Sin `-e DOTNET_ENVIRONMENT=Development` la
consola no arranca: falta `TimeoutSegundos` y sale con código 3 antes del primer pedido.

**Pruebas de `ConModelo/`** (2 vías × 2 pedidos × 10 semillas = 40 pedidos, de 2 a 4 llamadas al modelo cada uno):

```bash
docker run --rm --network ia-guia -e OLLAMA_ENDPOINT=http://ollama:11434 \
  -e ESTACION="medido en <tu equipo>, $(date +%F)" \
  -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test 06-Tool-Calling.slnx --filter TestCategory=ConModelo --logger "console;verbosity=normal"
```

Cada vía escribe su registro R-LLM en `tests/.../bin/Debug/net10.0/salidas-con-modelo/tool-calling-<vía>.txt` (o en
la carpeta de `RLLM_SALIDA`). `CONMODELO_M` cambia la cantidad de semillas. Sin `OLLAMA_ENDPOINT` las dos pruebas
quedan `Inconclusive` («ConModelo: no medido»), que la consola de `dotnet test` muestra como `Skipped`: nunca en verde.

## Resultado esperado

- Build: `0 Warning(s)`, `0 Error(s)` (con `TreatWarningsAsErrors`).
- `Cableado/`: 23 pruebas en verde.
  - **Las cuatro negativas**, por el camino completo (cliente guionado → bucle real → herramienta → caso de uso → el
    resultado vuelve al modelo): provincia fuera del catálogo («Misiones») → error en `provincia`, 0 lecturas y 0
    escrituras; código postal inválido («34», «٣٤٠٠», «34OO») → error en `codigoPostal`, 0 lecturas; localidad
    inexistente («Bella Vista») → error en `nombre`; localidad de otra sesión («Goya», cargada por la sesión B con el
    caso de uso normal) → la sesión A recibe exactamente la misma respuesta que para una inexistente, y B sí la ve.
    Además: contar en Corrientes da 1 en A y 2 en B, y un control positivo («chaco» → «Chaco», 1).
  - **Límites del bucle:** los valores de `AI:Herramientas` llegan a `FunctionInvokingChatClient`; un valor fuera de
    rango no arranca (`OptionsValidationException`). Con un «modelo» que pide herramientas sin parar y el máximo en 3:
    3 ejecuciones, 4 llamadas al modelo, y en la cuarta el bucle ya no ofrece herramientas (la respuesta final es
    texto). Con una herramienta que falla siempre y 2 errores consecutivos: 3 ejecuciones y la excepción sale del
    asistente.
  - **Proveedor:** dos proveedores falsos, mismo resultado del caso de uso, la tabla de arriba; Application y Domain sin
    tipos de MEAI ni de proveedores (30 tipos revisados, con un caso rojo).
  - Lista cerrada de herramientas = lo registrado, y cada una invocada con argumentos válidos da 0 escrituras; entrada
    de 2001 caracteres → `EntradaDemasiadoLargaException` con 0 llamadas al modelo; ningún literal de endpoint, modelo,
    `num_ctx`, timeout ni límite del bucle en `src/` fuera de `OpcionesDeIA.cs`.
- La consola sin modelo: `contar_localidades_por_provincia({"provincia":"Chaco"})` → `cantidad 1`; con «Misiones», el
  error de catálogo.
- `ConModelo/`: falla ante una sola violación de las invariantes (0 escrituras; toda herramienta pedida en la lista
  cerrada; ejecuciones ≤ 3; sin excepción). Las tasas se informan sin umbral y no se comparan entre vías.

## Resultado medido

**Sin modelo** (2026-10-28, `sdk:10.0` con el digest de «Requisitos»): build con 0 advertencias y 0 errores;
`Cableado/` 23 de 23 en verde; la suite completa sin `OLLAMA_ENDPOINT` da 23 en verde y las 2 de `ConModelo/` en
`Skipped` («no medido»); la consola `--sin-modelo` sale con código 0 y muestra lo de «Resultado esperado».

**Contra el modelo**, una corrida de `ConModelo/` con el código de esta carpeta. Cabecera R-LLM: estimando «este
pedido», 2 pedidos × 10 semillas (s = 1..10) por vía; `qwen3.5:4b@d8b0f5e9760c` (Q4_K_M, provisional); T 0,7, top_p 0,8,
top_k 20, presence_penalty 1,5 (preajuste de la model card de Qwen3.5-4B para el modo sin razonamiento; `top_k` no
viaja por `/v1`); `think` false; `num_ctx` 8192 por la vía nativa (por `/v1` no se fija); bucle 3 iteraciones / 2
errores; criterio escrito antes de correr (el comentario de `ConModelo/HerramientasConModeloTests.cs`). Medido en una
estación de laboratorio con más núcleos (CPU sin GPU; contenedor limitado a 14 CPU / 34 GiB; Ollama 0.40.11),
2026-10-28.

**Invariantes:** 0 violaciones en 40 pedidos (0 escrituras, ninguna herramienta fuera de la lista cerrada, ninguna
ejecución por encima de 3, ninguna excepción).

Cada fila es una tasa de **este pedido** (1 pedido × 10 semillas); no es una tasa de la tarea, y las dos vías no se
comparan.

| Pedido | Qué se cuenta | `/api/chat` (OllamaSharp) | `/v1` (MEAI.OpenAI) |
|---|---|---|---|
| «¿Cuántas localidades hay cargadas en Chaco?» | pidió la herramienta con una provincia que normaliza a Chaco | 10/10, Wilson 95 % [0,72; 1,00] | 10/10, [0,72; 1,00] |
| | la respuesta nombra la cantidad (1) | 10/10, [0,72; 1,00] | 10/10, [0,72; 1,00] |
| «¿Cuántas localidades hay cargadas en Misiones?» | pidió alguna herramienta | 0/10, [0,00; 0,28] | 0/10, [0,00; 0,28] |
| | la respuesta dice que no está en el catálogo (regex) | 9/10, [0,60; 0,98] | 10/10, [0,72; 1,00] |
| | la respuesta afirma un conteo con número (`\b\d+\s+localidad`) | 0/10, [0,00; 0,28] | 0/10, [0,00; 0,28] |

Cómo leerlo: con «Misiones», el modelo **no llamó a la herramienta** en ninguna corrida: contestó con la lista de
provincias que encontró en la descripción del parámetro `provincia`. El rechazo del normalizador, que las pruebas de
`Cableado/` muestran, no se ejercitó con el modelo. Y la regex de «afirma un conteo» no captura todo: por lectura
manual, en 3 de 10 (`/api/chat`) y 4 de 10 (`/v1`) respuestas el modelo dice «no hay localidades cargadas» o «el número
total es cero» sin haber consultado nada. Es un dato que la aplicación no le dio. Lo que protege la respuesta es que
el número lo calcule el caso de uso; cuando el modelo no pide la herramienta, la aplicación no puede verificar lo que
dice. Pared por pedido en esa estación: mediana 8,6 s por las dos vías (6,3–12,2 s, N = 20 por vía); es una
observación de una corrida, no una cifra de rendimiento.

La consola contra el mismo servidor (vía nativa, una corrida, existencia): «Chaco» → `contar_localidades_por_provincia({"provincia":"Chaco"})` → `cantidad 1` → «En la provincia de Chaco están cargadas 1 localidad.»; «¿Y cuántas hay en Misiones?» → sin herramienta, «No puedo contar las localidades de Misiones porque el catálogo solo incluye datos para Buenos Aires, Chaco, …».

No medido en este ejemplo: la estación de 4 núcleos; `tool_choice` por `/v1` (si Ollama lo hace cumplir); cadenas de
más de una herramienta con el modelo.
