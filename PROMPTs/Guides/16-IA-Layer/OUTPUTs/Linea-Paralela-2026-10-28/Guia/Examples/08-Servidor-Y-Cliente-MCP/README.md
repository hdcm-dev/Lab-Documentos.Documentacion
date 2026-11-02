# 08 · Servidor y cliente MCP

Un cliente MCP lista localidades de Movilidad Urbana. Del otro lado no hay un servidor de terceros: es el servidor MCP
propio del caso, un adaptador de entrada más, al lado de la API, que publica los mismos casos de uso de lectura que usa
el bucle de herramientas. El cliente le pasa esas herramientas, filtradas por una lista blanca, a un agente de MAF.

- **Nivel:** avanzado.
- **Sección de la guía:** §7, «Agentes, herramientas y orquestación» (MCP es transporte, no un nivel de orquestación;
  servidor propio, cliente al servidor propio, agente con `McpClientTool`). §4, «La capa de IA en el stack», lo muestra
  en el diagrama como pieza de este ejemplo, fuera de la demo. §8, «Operar, evaluar y asegurar», cita las pruebas de
  CTRL-13 (MCP HTTP: loopback, `AllowedHosts`, `Origin`, autenticación) y CTRL-06 (herramientas por sesión).
- **Modo sin modelo:** sí. `--sin-modelo` reemplaza al modelo por un cliente guionado: se ve el cableado (servidor,
  perímetro, transporte, lista blanca, agente), no el comportamiento de un modelo. Las pruebas de `Cableado/` no
  necesitan el servidor de modelos.

## Qué demuestra

1. **Un catálogo único de herramientas.** Cada herramienta se define una vez, como `AIFunction`
   (`Herramientas/CatalogoDeHerramientas.cs`): nombre, descripción y esquema salen de un solo lugar. El catálogo tiene
   dos lecturas (`contar_localidades_por_provincia`, `listar_localidades`) y una escritura (`borrar_localidad`), que entra
   envuelta en `ApprovalRequiredAIFunction` para el bucle de la app. El servidor MCP publica **sólo las de lectura**:
   `WithTools(CatalogoDeHerramientas.DeLectura().Select(f => McpServerTool.Create(f, …)))`. Por MCP la aprobación no
   viaja: si la escritura se publicara, el servidor la ejecutaría sin preguntar.
2. **CTRL-13, completo, sobre el servidor real** (`Mcp/ServidorMcp.cs`, `Mcp/PerimetroDelServidorMcp.cs`):
   - escucha sólo en loopback; una dirección que no sea `127.0.0.1`, `[::1]` o `localhost` no arranca;
   - `AllowedHosts` cerrado (`localhost;127.0.0.1`). No es una opción del SDK de MCP: lo aplica el HostFiltering que
     registra `WebApplication.CreateBuilder` (no el builder *slim*); con un `Host` ajeno responde 400. `"*"` no arranca;
   - un middleware valida `Origin` sobre `/mcp` y responde 403 si viene y no está en la lista. El SDK
     `ModelContextProtocol.AspNetCore` 2.3.0 no lo hace, y la especificación del transporte Streamable HTTP lo exige;
   - `MapMcp("/mcp").RequireAuthorization()` con un token por `Authorization: Bearer`: 401 sin token o con uno
     incorrecto. El ejemplo lo exige siempre; en Development usa un token de demostración declarado en
     `servidor-mcp.Development.json`, y fuera de Development no arranca sin `Mcp__Token`.
3. **La sesión fija de demostración, declarada.** Todo pedido MCP trabaja sobre el espacio de datos `demostracion-mcp`
   (`SesionFijaDeDemostracion`). El servidor no lee `X-Sesion-Id`: en el caso base ese identificador lo elige el cliente
   y es débil; aislar datos por él no es control de acceso. En CTX-PROD el espacio de datos sale de la identidad
   autenticada, no de una constante.
4. **El cliente MCP con lista blanca** (`src/…Cliente/Mcp/ConexionMcp.cs`): el agente recibe sólo las herramientas cuyo
   nombre está en `McpCliente:HerramientasPermitidas`, no todo lo que el servidor publique. El token viaja como
   encabezado, puesto por un `DelegatingHandler` en el `HttpClient` del transporte; nunca en el cuerpo.
5. **Un agente de MAF con `McpClientTool`** (`AgenteDeLocalidadesPorMcp.cs`): `chat.AsAIAgent(instructions, tools:
   [.. aceptadas])`. Un `McpClientTool` es un `AIFunction`; cada llamada del modelo viaja por MCP al servidor, que la
   ejecuta con sus casos de uso. El `IChatClient` lleva el bucle acotado (CTRL-05: 3 iteraciones, 2 errores).
6. **La alternativa con dos definiciones** (`Alternativa/HerramientasConAtributos.cs`): las mismas herramientas con
   `[McpServerToolType]` / `[McpServerTool]`. Compila y no se registra; una prueba la levanta y compara lo que publica con
   el catálogo único.

La consola levanta el servidor del ejemplo en `127.0.0.1`, en un puerto libre y en el mismo proceso, y se conecta por
HTTP: la conexión pasa por el perímetro y la autenticación igual que con un servidor aparte. El servidor también corre
solo (`dotnet run --project src/MovilidadUrbana.Ejemplos.Mcp.Servidor`), en loopback.

| Pieza | Capa | Archivo |
|---|---|---|
| `ConsultaDeLocalidades`, `NormalizadorDeCatalogos` (casos de uso de lectura) | Application (núcleo) | `src/…Servidor/Application/` |
| `HerramientasDeLocalidades` y `CatalogoDeHerramientas` (adaptador de entrada) | adaptador | `src/…Servidor/Herramientas/` |
| servidor MCP: composición, perímetro, sesión fija, token | adaptador de entrada | `src/…Servidor/Mcp/` |
| alternativa con atributos (no registrada) | — | `src/…Servidor/Alternativa/` |
| repositorio en memoria por sesión | Infrastructure/Persistence | `src/…Servidor/Infrastructure/Persistence/` |
| copia literal del caso base | Domain, Application, Sessions | `src/…Servidor/CasoBase/` (ver `CasoBase/PROCEDENCIA.md`) |
| `OpcionesDeIA`, `OpcionesDelClienteMcp`, composición del `IChatClient` | composición del cliente | `src/…Cliente/Infrastructure/AI/`, `appsettings*.json` |
| conexión MCP y lista blanca | cliente | `src/…Cliente/Mcp/ConexionMcp.cs` |
| agente de MAF con `McpClientTool` | cliente | `src/…Cliente/AgenteDeLocalidadesPorMcp.cs` |
| cliente guionado del modo sin modelo | — | `src/…Cliente/SinModelo/ClienteGuionado.cs` |

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
| `ModelContextProtocol.AspNetCore` | 2.3.0 | servidor |
| `ModelContextProtocol` | 2.3.0 | cliente |
| `Microsoft.Extensions.AI` | 10.11.0 | servidor y cliente |
| `Microsoft.Agents.AI` | 1.26.0 | cliente |
| `OllamaSharp` | 5.5.0 | cliente |
| `Microsoft.Extensions.Hosting` | 10.0.14 | cliente |
| `Microsoft.Extensions.Http` | 10.0.14 | cliente |
| `Microsoft.Extensions.Options.DataAnnotations` | 10.0.14 | cliente |
| `NUnit` | 5.0.0 | tests |
| `NUnit3TestAdapter` | 6.3.1 | tests |
| `Microsoft.NET.Test.Sdk` | 18.11.0 | tests |

## Comandos

Desde esta carpeta. `bin/`, `obj/` y `salidas-con-modelo/` quedan fuera de git por `.gitignore`.

**Compilar:**

```bash
docker run --rm -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet build 08-Servidor-Y-Cliente-MCP.slnx
```

**Pruebas de `Cableado/` (sin modelo, deterministas):**

```bash
docker run --rm -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test 08-Servidor-Y-Cliente-MCP.slnx --filter TestCategory=Cableado
```

**La consola sin modelo** (cliente guionado):

```bash
docker run --rm -e DOTNET_ENVIRONMENT=Development -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet run --project src/MovilidadUrbana.Ejemplos.Mcp.Cliente -- --sin-modelo
```

**La consola contra el servidor de prueba:**

```bash
docker run --rm --network ia-guia -e OLLAMA_ENDPOINT=http://ollama:11434 -e DOTNET_ENVIRONMENT=Development \
  -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet run --project src/MovilidadUrbana.Ejemplos.Mcp.Cliente
```

Sin `-e DOTNET_ENVIRONMENT=Development` la consola no arranca: faltan `TimeoutSegundos` y el token del servidor MCP, y
sale con código 3 antes de levantar nada.

**Pruebas de `ConModelo/`** (2 pedidos × 10 semillas = 20 pedidos, de 2 llamadas al modelo cada uno):

```bash
docker run --rm --network ia-guia -e OLLAMA_ENDPOINT=http://ollama:11434 \
  -e ESTACION="medido en <tu equipo>, $(date +%F)" \
  -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test 08-Servidor-Y-Cliente-MCP.slnx --filter TestCategory=ConModelo --logger "console;verbosity=normal"
```

El registro R-LLM queda en `tests/.../bin/Debug/net10.0/salidas-con-modelo/agente-por-mcp.txt` (o en la carpeta de
`RLLM_SALIDA`). `CONMODELO_M` cambia la cantidad de semillas. Sin `OLLAMA_ENDPOINT` la prueba queda `Inconclusive`
(«ConModelo: no medido»), que la consola de `dotnet test` muestra como `Skipped`: nunca en verde.

## Resultado esperado

- Build: `0 Warning(s)`, `0 Error(s)` (con `TreatWarningsAsErrors`).
- `Cableado/`: 44 pruebas en verde.
  - **La tabla del perímetro** (`PerimetroTests`), contra Kestrel en `127.0.0.1`:

    | Pedido `initialize` a `/mcp` | Código |
    |---|---|
    | `Host` ajeno, con token | 400 |
    | sin token | 401 |
    | token incorrecto | 401 |
    | `Origin` ajeno, con token | 403 |
    | `Origin` ajeno, sin token | 403 (el `Origin` se revisa antes que el token) |
    | `Origin` permitido, con token | 200 |
    | sin `Origin` (un cliente que no es navegador), con token | 200 |
    | `Host` `localhost`, con token | 200 |

  - **Arranque:** escucha sólo en loopback; `0.0.0.0`, una dirección de red y `+` no arrancan; `AllowedHosts` con `*`
    no arranca; fuera de Development, sin token, `OptionsValidationException`.
  - **`tools/list`** por un cliente MCP real: los nombres son la lista cerrada de la prueba, y la descripción y el
    `inputSchema` de cada una son iguales, carácter por carácter, al `JsonSchema` del `AIFunction` del catálogo;
    `readOnlyHint` en true y `destructiveHint` en false. Cada herramienta publicada, llamada por MCP con argumentos
    válidos, da 0 escrituras. `borrar_localidad` por MCP → error del protocolo («Unknown tool»), 0 escrituras.
  - **El catálogo por reflexión y por nombre:** lo publicado lleva `[HerramientaDeLectura]` y ninguna pide aprobación;
    la escritura del catálogo es `ApprovalRequiredAIFunction` y el filtro la deja afuera; ningún método del catálogo
    recibe la sesión como parámetro (ni por nombre ni por tipo, ni en el esquema); lo publicado no devuelve entidades de
    `Domain.Entities` ni propiedades `SessionId`, `Edad` o `Id` (con un caso rojo que muestra que la prueba detecta el
    `SessionId` de `Localidad`).
  - **Sesión fija:** con `X-Sesion-Id: otra-sesion` el servidor igual lee `demostracion-mcp`.
  - **Herramientas por sesión, concurrente** (`ConcurrenciaTests`, dos sesiones con barrera): con el ámbito de cada
    sesión, B no ve ni borra lo que A dio de alta, con `ValidateScopes` en true y en false (borradas 0). Casos rojos:
    con los servicios raíz y `ValidateScopes = false`, las dos sesiones comparten un `SessionContext` y B ve y borra
    lo de A, sin error; con `ValidateScopes = true`, cada llamada a la herramienta falla.
  - **Lista blanca:** un servidor que además publica `borrar_todo` (marcada `ReadOnly`, para mostrar que la anotación no
    decide) → el filtro la descarta, informa la faltante y lo aceptado es `AIFunction`.
  - **Agente sin modelo:** el agente de MAF con `McpClientTool` pide `contar_localidades_por_provincia`, la herramienta
    se ejecuta una vez en el servidor (una lectura), 0 escrituras, 2 llamadas al «modelo».
  - **Lo que lee el modelo:** con el `OllamaApiClient` real y un servidor Ollama falso, el mensaje `tool` del segundo
    pedido lleva `{"CallId":"…","Result":{"$type":"text","Text":"{\n  \"ok\": true, …}","Annotations":null,…}}`: el
    `TextContent` de MCP con la respuesta como texto JSON adentro de un string.
  - **La alternativa con atributos** publica los mismos nombres, la misma descripción y el mismo esquema que el
    catálogo único (con `Name` fijado a mano en los dos lados).
  - **Barridos:** `[McpServerTool]` sólo en `Alternativa/HerramientasConAtributos.cs`; ningún literal de endpoint ni de
    modelo fuera de `OpcionesDeIA.cs`; ni lanzadores de servidores de terceros, ni encabezados en el cuerpo del pedido,
    ni `WithToolsFromAssembly`.
- La consola sin modelo: `contar_localidades_por_provincia({"provincia":"Chaco"})` → `cantidad 1`;
  `listar_localidades({"provincia":"Corrientes"})` → Corrientes; «Escrituras en el servidor: 0». Cliente y servidor
  negocian la revisión `2026-07-28` del protocolo.
- `ConModelo/`: falla ante una sola violación de las invariantes (0 escrituras en el servidor; toda herramienta pedida
  en la lista blanca; ejecuciones ≤ 3; sin excepción). Las tasas se informan sin umbral.

## Resultado medido

2026-10-28, `qwen3.5:4b@d8b0f5e9760c`, T 0,7, top_p 0,8, top_k 20, presence 1,5, razonamiento apagado, `num_ctx` 8192,
`/api/chat` (OllamaSharp 5.5.0), agente de MAF 1.26.0 con `McpClientTool` (ModelContextProtocol 2.3.0, Streamable HTTP,
protocolo 2026-07-28), bucle 3/2, Ollama 0.40.11. Criterio escrito antes de correr. Estimando: **este pedido**
(la unidad es la semilla), 2 pedidos × 10 semillas (s = 1..10); cada fila por separado, sin comparar entre sí.

**Medido en una estación de laboratorio con más núcleos (CPU sin GPU; contenedor limitado a 14 CPU / 34 GiB;
Ollama 0.40.11), 2026-10-28:**

| Pedido | Afirmación | k/n | Wilson 95 % |
|---|---|---|---|
| «¿Cuántas localidades hay cargadas en Chaco?» | pidió una herramienta con provincia Chaco | 10/10 | [0,72; 1,00] |
| | la respuesta nombra la cantidad 1 | 10/10 | [0,72; 1,00] |
| «¿Qué localidades hay cargadas en Corrientes?» | pidió `listar_localidades` con provincia Corrientes | 10/10 | [0,72; 1,00] |
| | la respuesta nombra Corrientes y no Resistencia | 10/10 | [0,72; 1,00] |

Invariantes: 0 violaciones en 20 pedidos; 0 escrituras en el servidor. Pared por pedido: mediana 9,3 s (mínima 8,4,
máxima 11,3; N = 20).

**Medido en la estación de laboratorio (CPU de 4 núcleos sin GPU; contenedor limitado a 4 CPU / 5 GB; Ollama 0.40.11),
2026-10-28**, con las mismas semillas (es reproducción del mismo pedido en otra estación, no una comparación):

| Pedido | Afirmación | k/n | Wilson 95 % |
|---|---|---|---|
| «¿Cuántas localidades hay cargadas en Chaco?» | pidió una herramienta con provincia Chaco | 9/10 | [0,60; 0,98] |
| | la respuesta nombra la cantidad 1 | 9/10 | [0,60; 0,98] |
| «¿Qué localidades hay cargadas en Corrientes?» | pidió `listar_localidades` con provincia Corrientes | 10/10 | [0,72; 1,00] |
| | la respuesta nombra Corrientes y no Resistencia | 10/10 | [0,72; 1,00] |

**La prueba falló en esta estación:** una invariante violada en 20 pedidos. En la semilla 1, el pedido de Chaco no
terminó: `TaskCanceledException` por el `HttpClient.Timeout` de 300 s (`AI:TimeoutSegundos` de
`appsettings.Development.json`). No hubo escrituras ni herramientas fuera de la lista blanca. Las dos fracciones de 9/10
son esa misma corrida, que no dio respuesta. Pared por pedido: mediana 95,5 s (mínima 48,5, máxima 300,3; N = 20).
Con un modelo de 4B en CPU de 4 núcleos, el plazo de 300 s no alcanzó para todos los pedidos de este agente, que hace
dos llamadas por pedido con las dos herramientas declaradas en el contexto.
