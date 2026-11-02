# Evidencia de integración — grupo B-abstracciones-agentes (2026-10-28)

Contra el Ollama propio en contenedor (estación 1), Ollama 0.40.11. El endpoint se pasó sólo por `OLLAMA_ENDPOINT` y no se escribe (R-PRIV).
Modelos: `qwen3.5:4b@d8b0f5e9760c`, `qwen2.5:0.5b@a8b0c5157701`, `qwen3-embedding:0.6b@ac6da0dfba84` (`/api/tags`, 2026-10-28).
Paquetes: Microsoft.Extensions.AI 10.11.0, Microsoft.Extensions.AI.OpenAI 10.11.0, OllamaSharp 5.5.0, Microsoft.Agents.AI 1.26.0; SDK 10.0.403 (`mcr.microsoft.com/dotnet/sdk:10.0`). Build: `0 Warning(s)`, `0 Error(s)`, sin `NoWarn`.

| Id | Qué | Salida |
|---|---|---|
| E-B1 | Tool calling con `UseFunctionInvocation` por OllamaSharp y por `/v1` (adaptador OpenAI), validación del argumento en la app | `sonda/salidas/01-b1-b2.jsonl` |
| E-B2 | `GetResponseAsync<LocalidadPropuesta>` por las dos vías, con y sin `useJsonSchemaResponseFormat`, y validación de dominio | `sonda/salidas/01-b1-b2.jsonl` |
| E-B3 | Agente de Agent Framework (`AsAIAgent`) sobre el mismo `IChatClient`: sesión de dos turnos y `ApprovalRequiredAIFunction` rechazada | `sonda/salidas/02-b3-b4.jsonl` |
| E-B4 | ESC-01 por similitud (top-k de embeddings, `IEmbeddingGenerator` .NET) frente a conteo exacto | `sonda/salidas/02-b3-b4.jsonl` |
| E-B5 | ESC-02: mapear expresiones coloquiales a claves del catálogo `Medios` por embeddings (HTTP, Python stdlib) | `sonda/salidas/03-b5.jsonl` |
| E-B6 | LangGraph y paquetes: NuGet `q=langgraph`, `owner:langchain`, PyPI, npm, flatcontainer | `langgraph/*.txt` |

Captura HTTP (un `DelegatingHandler` que registra la ruta relativa y las claves del cuerpo, sin host): líneas `captura-http` de cada `.jsonl`.

Datos sintéticos, rotulados en el código: los conteos por medio de E-B1/E-B3 y las ocho localidades de E-B4 (el caso base no tiene consulta de resultados y siembra sólo Corrientes y Resistencia). El catálogo `Medios` y `Provincias` se copiaron de `MovilidadUrbana.ApiWeb/Domain/Catalogos.cs` (Lab-E2E.WebBlazor, commit `59399ba`, 2026-10-27).

Comandos (desde la carpeta de la sonda; los intermedios estuvieron en `{dir-de-trabajo}/B-abstracciones-agentes/`, bin/obj borrados):

```bash
$R/<envoltorio-de-turnos> build B-abstracciones-agentes "compila sonda B" -- docker run --rm -v <volumen-nuget>:/root/.nuget/packages -v $PWD:/w -w /w mcr.microsoft.com/dotnet/sdk:10.0 dotnet build -c Release
$R/<envoltorio-de-turnos> <recurso-compartido> B-abstracciones-agentes "sonda B (N=5)" 45 -- docker run --rm --network host -e OLLAMA_ENDPOINT -e OLLAMA_MODEL=qwen3.5:4b -e N=5 -v <volumen-nuget>:/root/.nuget/packages -v $PWD:/w -w /w mcr.microsoft.com/dotnet/sdk:10.0 dotnet bin/Release/net10.0/SondaB.dll b1,b2 > salidas/01-b1-b2.jsonl
$R/<envoltorio-de-turnos> <recurso-compartido> B-abstracciones-agentes "sonda B (N=3)" 45 -- ./correr-b3-b5.sh
```

Parámetros R-LLM: `temperature 0.7`, `seed` = número de corrida, `qwen3.5:4b` con `ChatOptions.Reasoning = { Effort = None }` (la captura muestra `think:false` en OllamaSharp y `reasoning_effort:none` en `/v1`), `MaximumIterationsPerRequest 4`, `MaximumConsecutiveErrorsPerRequest 2`. Las latencias son de banco exclusivo (turno `<recurso-compartido>`) sobre CPU de 4 núcleos; la 1.ª corrida de cada serie incluye carga del modelo.
