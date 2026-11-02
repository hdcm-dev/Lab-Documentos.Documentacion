# 12 · Anotaciones pareadas: la misma herramienta en Semantic Kernel y en Agent Framework

Quien llega de Semantic Kernel (SK) tiene herramientas escritas como funciones de un plugin, con `[KernelFunction]`.
En Microsoft Agent Framework (MAF) la misma herramienta es un método con `[Description]` que `AIFunctionFactory`
convierte en `AIFunction`. Este ejemplo escribe **una** herramienta del caso, `resultados_por_medio(localidad?)`
(cuántas respuestas de la encuesta de transporte eligieron cada medio), de las dos maneras y sobre el **mismo caso de
uso**, y mide en qué coinciden y en qué no. La guía de migración presenta el cambio como un mapeo uno a uno; el
ejemplo muestra que el mapeo de la anotación es directo, pero que lo que ve el modelo no queda igual.

- **Nivel:** intermedio.
- **Sección de la guía:** §5, «Hablar con un modelo desde .NET» (`AIFunction` como abstracción común; un
  `KernelFunction` también lo es) y §7, «Agentes, herramientas y orquestación» (de `ChatCompletionAgent` a
  `AsAIAgent`, referencia para quien migra).
- **Modelo:** no usa ninguno. No lee `OLLAMA_ENDPOINT` y no tiene pruebas `ConModelo/`: lo que se compara es la
  declaración y el cableado, no el comportamiento de un modelo. El «modelo» de la consola y de las pruebas es un
  cliente guionado (`SinModelo/ClienteGuionado.cs`).

## Qué demuestra

1. **La anotación, lado a lado.** Mismo método, mismos textos de `[Description]`, mismo caso de uso
   (`ConsultaDeResultadosPorMedio`, en Application, sin tipos de ningún marco de IA):

   | | Semantic Kernel 1.81.0 | Agent Framework 1.26.0 (MEAI 10.11.0) |
   |---|---|---|
   | anotación | `[KernelFunction("resultados_por_medio")]` + `[Description]` | `[Description]` |
   | registro | `KernelPluginFactory.CreateFromObject(obj, "Encuesta")` + `kernel.Plugins.Add` | `AIFunctionFactory.Create(metodo, name: "resultados_por_medio")` |
   | agente | `ChatCompletionAgent { Kernel, Instructions, Arguments }` + `InvokeAsync(texto, hilo)` | `chat.AsAIAgent(instructions, tools: [...])` + `RunAsync(texto, sesion)` |
   | ejecución de herramientas | `UseKernelFunctionInvocation()` en el `IChatClient` + `FunctionChoiceBehavior.Auto()` | la agrega `AsAIAgent` |

2. **Lo que ve el modelo no es idéntico** (medido; las pruebas lo fijan con estas versiones):

   | | Semantic Kernel | Agent Framework |
   |---|---|---|
   | nombre ofrecido al modelo | `Encuesta_resultados_por_medio` (plugin + `_` + función) | `resultados_por_medio` |
   | tipo de `localidad` en el esquema | `"string"`, sin `default` | `["string","null"]`, `"default": null` |
   | clave extra en la raíz del esquema | `"condition"` con la descripción de la función | — |
   | `FunctionResultContent.Result` que recibe el cliente | el objeto `ResultadosPorMedio` | un `JsonElement` (camelCase) |

   Coinciden la descripción de la función, el nombre y la descripción del parámetro, que ninguno lo marca como
   obligatorio, y el resultado del caso de uso: con los mismos argumentos las dos invocaciones devuelven el mismo JSON.
   Cómo viaja después el resultado al servidor lo decide el adaptador del proveedor; eso no se midió acá.

3. **Tres trampas de la migración, como casos rojos:**
   - **Sin `UseKernelFunctionInvocation`**, el `ChatCompletionAgent` sobre un `IChatClient` devuelve la llamada a la
     herramienta como respuesta, **sin ejecutarla y sin error**: 0 ejecuciones, 1 llamada al cliente, texto vacío.
   - **`AIFunctionFactory` no lee `[KernelFunction]`.** Si se deja la anotación vieja y no se pasa `name`, la función
     se llama `ResultadosPorMedio` (el método sin el sufijo `Async`): el nombre que veía el modelo cambia sin aviso.
     `[Description]` sí se lee.
   - **Entregar el `KernelFunction` tal cual a un agente de MAF** compila (es un `AIFunction`) y se ofrece al modelo,
     pero al ejecutarse falla: 0 ejecuciones y el modelo recibe `Error: Function failed.`; la aplicación no ve una
     excepción. Con `IncludeDetailedErrors` el motivo es
     `No service for type 'System.Collections.Generic.IEnumerable`1[Microsoft.SemanticKernel.KernelPlugin]' has been registered.`
     Migrar es reescribir la anotación, no reusar el objeto del plugin.

   Además, en SK, si el modelo pide el nombre corto (`resultados_por_medio`) en lugar del que le ofrecieron, no se
   ejecuta nada y el modelo recibe `Error: Requested function "resultados_por_medio" not found.`

4. **Application no cambia.** Una prueba por reflexión revisa que ningún tipo de `Application/` nombre tipos de
   `Microsoft.SemanticKernel`, `Microsoft.Extensions.AI` ni `Microsoft.Agents.AI` (con un caso rojo sobre el
   adaptador). La herramienta devuelve agregados: ni nombre ni edad de quien respondió.

| Pieza | Capa | Archivo |
|---|---|---|
| `ConsultaDeResultadosPorMedio`, `ResultadosPorMedio`, `ILecturaDeRespuestas` | Application (núcleo) | `src/.../Application/Resultados/` |
| `ResultadosDeEncuestaPlugin` (antes: `[KernelFunction]`) | Infrastructure/AI | `src/.../Infrastructure/AI/SemanticKernel/ResultadosDeEncuestaPlugin.cs` |
| `AgenteDeSemanticKernel` (Kernel + `ChatCompletionAgent`) | Infrastructure/AI | `src/.../Infrastructure/AI/SemanticKernel/AgenteDeSemanticKernel.cs` |
| `HerramientasDeResultados` (después: `[Description]` + `AIFunctionFactory`) | Infrastructure/AI | `src/.../Infrastructure/AI/AgentFramework/HerramientasDeResultados.cs` |
| `AgenteDeAgentFramework` (`AsAIAgent` + `RunAsync`) | Infrastructure/AI | `src/.../Infrastructure/AI/AgentFramework/AgenteDeAgentFramework.cs` |
| respuestas en memoria por sesión, cuatro ficticias | Infrastructure/Persistence | `src/.../Infrastructure/Persistence/RespuestasEnMemoria.cs` |
| copia literal del caso base | Domain, Application, Sessions | `src/.../CasoBase/` (ver `CasoBase/PROCEDENCIA.md`) |
| cliente guionado | — | `src/.../SinModelo/ClienteGuionado.cs` |

## Requisitos

- Docker con la imagen `mcr.microsoft.com/dotnet/sdk:10.0` (probado con
  `sha256:de4fe90a98845d75910b9769662465c84de1a934665c431279d1382b2bddc02b`, SDK 10.0.403).
- Sin servidor de modelos.

Paquetes (versiones exactas, consultadas en nuget.org el 2026-10-28; `dotnet list package --vulnerable
--include-transitive` y `--deprecated`: ninguno):

| Paquete | Versión | Dónde |
|---|---|---|
| `Microsoft.Extensions.AI` | 10.11.0 | src |
| `Microsoft.Agents.AI` | 1.26.0 | src |
| `Microsoft.SemanticKernel.Core` | 1.81.0 | src |
| `Microsoft.SemanticKernel.Agents.Core` | 1.81.0 | src |
| `NUnit` | 5.0.0 | tests |
| `NUnit3TestAdapter` | 6.3.1 | tests |
| `Microsoft.NET.Test.Sdk` | 18.11.0 | tests |

## Comandos

Desde esta carpeta. `bin/` y `obj/` quedan fuera de git por `.gitignore`.

**Compilar:**

```bash
docker run --rm -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet build 12-Anotaciones-Pareadas.slnx
```

**Pruebas de `Cableado/` (sin modelo, deterministas):**

```bash
docker run --rm -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test 12-Anotaciones-Pareadas.slnx --filter TestCategory=Cableado
```

**La consola** (las dos declaraciones, las dos invocaciones y los dos agentes con el cliente guionado):

```bash
docker run --rm -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet run --project src/MovilidadUrbana.Ejemplos.AnotacionesPareadas
```

**Contra el modelo:** no corresponde. El ejemplo no tiene `ConModelo/` ni lee `OLLAMA_ENDPOINT`.

## Resultado esperado

- Build: `0 Warning(s)`, `0 Error(s)` (con `TreatWarningsAsErrors`).
- `Cableado/`: 18 pruebas en verde.
  - **Declaración:** misma descripción; `resultados_por_medio` en MAF y `Encuesta_resultados_por_medio` como
    `AIFunction` de SK (`KernelFunction.Name` sigue siendo `resultados_por_medio`); esquemas con las mismas propiedades
    y descripciones y con las diferencias de la tabla de arriba.
  - **Invocación:** con `localidad` = «Corrientes», «resistencia», sin localidad y «Goya» (sin respuestas), las dos
    variantes devuelven el mismo JSON y cada una lee el almacén una vez; el resultado no trae «Persona de ejemplo»
    ni campos `Nombre` o `Edad`.
  - **Agentes:** `ChatCompletionAgent` y `AsAIAgent` con el mismo cliente guionado: 1 ejecución de la herramienta,
    2 llamadas al cliente, el total de Corrientes (2) en el texto final; el resultado llega al cliente como
    `ResultadosPorMedio` en SK y como `JsonElement` en MAF.
  - **Casos rojos:** sin `UseKernelFunctionInvocation` → 0 ejecuciones, 1 llamada, texto vacío; nombre sin prefijo en
    SK → 0 ejecuciones y «Requested function … not found»; `AIFunctionFactory.Create` sin `name` →
    `ResultadosPorMedio`; `KernelFunction` en un agente de MAF → 0 ejecuciones y `Error: Function failed.` (con
    errores detallados, el mensaje nombra `KernelPlugin`); el adaptador de MAF sí nombra tipos de MEAI.
  - **Arquitectura:** 7 tipos de `Application/` revisados, 0 con tipos de marcos de IA.
- La consola sale con código 0 y muestra, para Corrientes: `totalDeRespuestas` 2, colectivo 2, a pie 1, el resto 0.

## Resultado medido

**Sin modelo** (2026-10-28, `sdk:10.0` con el digest de «Requisitos»): build con 0 advertencias y 0 errores;
`Cableado/` 18 de 18 en verde; la consola sale con código 0 con lo de «Resultado esperado»; ningún paquete
vulnerable ni deprecado.

**Contra el modelo:** no corresponde (sin `ConModelo/`). Que un modelo real elija la herramienta con el nombre
prefijado de SK igual que con el corto de MAF **no se midió**.

No medido en este ejemplo: el cuerpo que manda cada adaptador de proveedor con el resultado de la herramienta; SK
con un conector propio (por ejemplo, el de OpenAI) en lugar de un `IChatClient`; `KernelFunction` creada con
`KernelFunctionFactory.CreateFromMethod` en lugar de un objeto con `[KernelFunction]`.
