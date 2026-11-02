# 03 · Salida estructurada: la forma no es validez

Nivel: básico. Se usa en la sección **§5 «Hablar con un modelo desde .NET»** (salida estructurada) y es el lugar donde se prueba el control **CTRL-04** («salida estructurada con `TryGetResult` y camino sin IA»). Escenario ESC-03 (extracción a estructura) sobre el caso Movilidad Urbana.

## Qué demuestra

Una persona escribe «Agregá Goya, Corrientes, CP 34, 89959 habitantes». El ejemplo le pide al modelo una `LocalidadPropuesta` con `GetResponseAsync<LocalidadPropuesta>` y muestra el recorrido completo:

1. **Forma.** `GetResponseAsync<T>` manda el JSON Schema del record en el campo `format` de `/api/chat` (vía nativa, OllamaSharp). La respuesta se consume con `TryGetResult`: si no deserializa, el adaptador devuelve `null` y la aplicación sigue por el camino sin IA (el formulario vacío). Nunca `.Result` a ciegas: con texto que no es JSON, `.Result` lanza `JsonException`.
2. **Contrato.** Una respuesta con forma válida puede traer un `tipo` que el enum no define (`5`) o un id que no existe en la sesión (`-1`, o el de otra sesión). `RevisorDePropuesta` las descarta **antes de llegar a la pantalla**, sin escribir nada.
3. **Normalización y reglas.** El catálogo normaliza (provincia contra `Catalogos.Provincias`, dígitos 0-9, nombre de 60 caracteres como máximo) y las reglas del dominio deciden (`LocalidadRules`, copiadas del caso base). Lo que no pasa vuelve como errores por campo, con los mensajes del ABM.
4. **Confirmación.** Una propuesta sin errores no es una propuesta cierta: el modelo puede «corregir» el CP 34 a 3400, que cumple `^\d{4}$`. Por eso nada se guarda hasta que la persona confirma el formulario precargado con la operación normal (`LocalidadService.SaveAsync`).

| Pieza | Capa | Archivo |
|---|---|---|
| `LocalidadPropuesta`, `TipoDePropuesta` | Application (núcleo) | `src/.../Application/Propuestas/LocalidadPropuesta.cs` |
| `IExtractorDeLocalidad` (puerto, sin tipos de MEAI) | Application | `src/.../Application/Propuestas/IExtractorDeLocalidad.cs` |
| `RevisorDePropuesta` (contrato, normalización, reglas; no escribe) | Application | `src/.../Application/Propuestas/RevisorDePropuesta.cs` |
| `ExtractorDeLocalidadLlm` (el único que conoce `IChatClient`) | Infrastructure/AI | `src/.../Infrastructure/AI/ExtractorDeLocalidadLlm.cs` |
| `OpcionesDeIA` (sección `AI`, validada al arrancar) | composición | `src/.../OpcionesDeIA.cs`, `appsettings.json` |
| Copia literal del caso base | Domain, Application | `src/.../CasoBase/` |

`CasoBase/` es una copia sin cambios de ocho archivos de `MovilidadUrbana.ApiWeb` (Lab-E2E.WebBlazor, commit `59399ba`): `Domain/Catalogos.cs`, `Domain/Rules/LocalidadRules.cs`, `Domain/Entities/Localidad.cs`, `Application/Result.cs`, `Application/Abstractions/ILocalidadRepository.cs` y `Application/Localidades/{LocalidadModel,LocalidadService,LocalidadPolicy}.cs`, con sus namespaces originales. Las validaciones que el ejemplo agrega viven fuera de esa carpeta y valen sólo para el camino de IA: la copia **no** se endurece.

Lo que las reglas copiadas aceptan y la entrada de IA rechaza (las pruebas lo muestran con el código, no con la política):

| Valor propuesto | `LocalidadRules` (caso base) | `RevisorDePropuesta` |
|---|---|---|
| provincia «Misiones» | válida (sólo exige «no vacío») | error: fuera del catálogo |
| CP «٣٤٥٠» | válido (`\d` acepta dígitos no ASCII) | error: no son dígitos 0-9 |
| nombre de 61 caracteres | válido (el máximo 60 está declarado y no se aplica) | error: supera 60 |
| provincia «corrientes» | válida | se normaliza a «Corrientes» |

## Requisitos

- Docker con la imagen `mcr.microsoft.com/dotnet/sdk:10.0` (probado con `sha256:de4fe90a98845d75910b9769662465c84de1a934665c431279d1382b2bddc02b`, SDK 10.0.403).
- Para la corrida contra el modelo: el servidor Ollama de prueba con `qwen3.5:4b`, alcanzado por `OLLAMA_ENDPOINT` (por defecto `http://localhost:11434`). Si el servidor corre en la misma máquina que Docker, agregá `--network host` a los comandos.
- Sin modo sin modelo: el programa necesita el servidor. Las pruebas de `Cableado/` no lo necesitan.

Paquetes (versiones exactas, consultadas en nuget.org el 2026-10-28):

| Paquete | Versión | Dónde |
|---|---|---|
| `Microsoft.Extensions.AI` | 10.11.0 | src |
| `OllamaSharp` | 5.5.0 | src |
| `Microsoft.Extensions.Hosting` | 10.0.14 | src |
| `Microsoft.Extensions.Http` | 10.0.14 | src |
| `Microsoft.Extensions.Options.DataAnnotations` | 10.0.14 | src |
| `NUnit` | 5.0.0 | tests |
| `NUnit3TestAdapter` | 6.3.1 | tests |
| `Microsoft.NET.Test.Sdk` | 18.11.0 | tests |

## Comandos

Desde esta carpeta. `bin/`, `obj/` y `salidas/` quedan fuera de git por `.gitignore`.

Compilar:

```bash
docker run --rm -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet build src/MovilidadUrbana.SalidaEstructurada
```

Pruebas sin modelo (`Cableado/`, deterministas):

```bash
docker run --rm -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test tests/MovilidadUrbana.SalidaEstructurada.Tests --filter "Category!=ConModelo"
```

Pruebas contra el modelo (`ConModelo/`, 4 pedidos × 10 semillas = 40 llamadas). Sin `OLLAMA_ENDPOINT` la prueba termina `Inconclusive` («no medido»), no en verde; la consola de `dotnet test` lo muestra como `Skipped` con el mensaje «Sin OLLAMA_ENDPOINT: no medido.»:

```bash
export OLLAMA_ENDPOINT=http://localhost:11434   # o el del servidor Ollama de prueba
export ESTACION="medido en <tu equipo>, $(date +%F)"
docker run --rm -v "$PWD":/ex -w /ex -e OLLAMA_ENDPOINT -e ESTACION -e SALIDA_DIR=/ex/salidas \
  mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test tests/MovilidadUrbana.SalidaEstructurada.Tests --filter "Category=ConModelo" \
  --logger "console;verbosity=normal"
```

Deja `salidas/conmodelo-salidas.jsonl` (una línea por corrida, con el texto crudo del modelo) y `salidas/conmodelo-resumen.txt` (la cabecera R-LLM y las tasas). `CONMODELO_M` cambia la cantidad de semillas.

El programa, con un texto:

```bash
docker run --rm -v "$PWD":/ex -w /ex -e OLLAMA_ENDPOINT mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet run --project src/MovilidadUrbana.SalidaEstructurada -- "Agregá Goya, Corrientes, CP 34, 89959 habitantes"
```

## Resultado esperado

- Build: `0 Warning(s)`, `0 Error(s)` (con `TreatWarningsAsErrors`).
- `Cableado/`: 15 pruebas en verde. Entre ellas, `ElPedidoLlevaElEsquemaEnFormat_YLasOpcionesPorPedido` comprueba con el cliente real de OllamaSharp y un servidor falso que el pedido lleva `format` con el esquema de `LocalidadPropuesta` (`tipo` como enum `["Alta","Modificacion"]`, los demás campos anulables y todos requeridos), `think: false` y, en `options`, `num_ctx`, `temperature`, `top_p`, `top_k` y `presence_penalty` tal como los declara `appsettings.json`.
- `ConModelo/`: la prueba falla ante una sola violación de las dos invariantes (0 escrituras en el repositorio; ninguna propuesta con `tipo` fuera del enum llega a la pantalla). Las tasas se informan, no se comparan contra un umbral.
- El programa imprime la propuesta del modelo (forma), la revisión (validez) y `Escrituras en el repositorio: 0`.

## Resultado medido

Una corrida de `ConModelo/` con el código de esta carpeta. Cabecera R-LLM: `qwen3.5:4b@d8b0f5e9760c`; T 0,7, top_p 0,8, top_k 20, presence_penalty 1,5 (model card de Qwen3.5-4B, modo sin razonamiento, consultada el 2026-10-28); `think` false; `num_ctx` 8192; ruta `/api/chat` por OllamaSharp 5.5.0 con `format` = JSON Schema; semillas 1..10 por pedido; criterio de cada tasa escrito antes de correr (la lista `Pedidos` de `ConModelo/ExtraccionConModeloTests.cs`). Medido en una estación de laboratorio con más núcleos (CPU sin GPU; contenedor limitado a 14 CPU / 34 GiB; Ollama 0.40.11), 2026-10-28.

**Invariantes:** 0 escrituras en 40 corridas; 0 violaciones.

Cada fila es una tasa de **este pedido** (1 pedido × 10 semillas); no es una tasa de la tarea y las filas no se comparan entre sí.

| Pedido | Qué se cuenta | k/n | Wilson 95 % |
|---|---|---|---|
| «Agregá Goya, Corrientes, CP 34, 89959 habitantes» | forma válida (`TryGetResult`) | 10/10 | [0,72; 1,00] |
| | CP distinto de «34» (inventado) | 8/10 | [0,49; 0,94] |
| | llega a la pantalla sin errores | 8/10 | [0,49; 0,94] |
| «Agregá Goya, Corrientes, CP 3450, unos 90 mil habitantes» | forma válida | 10/10 | [0,72; 1,00] |
| | igual a (Alta, sin id, Goya, Corrientes, 3450, 90000) | 10/10 | [0,72; 1,00] |
| | sin errores | 10/10 | [0,72; 1,00] |
| «En Bella Vista, Corrientes, CP 3432, no sé cuántos viven» | forma válida | 10/10 | [0,72; 1,00] |
| | habitantes en `null` (no inventa) | 10/10 | [0,72; 1,00] |
| | la revisión pide los habitantes | 10/10 | [0,72; 1,00] |
| «Corregí Resistencia: tiene 300000 habitantes» | forma válida | 10/10 | [0,72; 1,00] |
| | `Modificacion` con el id 2 de la sesión | 10/10 | [0,72; 1,00] |
| | no se descarta | 10/10 | [0,72; 1,00] |

Cómo leerlo: en el primer pedido, las 8 propuestas con el CP inventado traían «3400», que cumple `LocalidadRules` y llega a la pantalla sin un solo error; las otras 2 traían «34» y la revisión pidió el CP. Las instrucciones decían «No inventes ni corrijas datos»: el modelo repite la política; la prueba muestra el código. Lo que protege el dato es que la persona vea el formulario precargado antes de guardar. Pared por llamada en esa estación: mediana 4,8 s (4,5–9,8 s, N = 40); es una observación de una corrida, no una cifra de rendimiento.
