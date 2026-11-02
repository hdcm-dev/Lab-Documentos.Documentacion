# Evidencia del Senior .NET — consulta dirigida, ciclo 1 ronda 2 (2026-10-28)

Cuatro sondas compiladas y corridas en `mcr.microsoft.com/dotnet/sdk:10.0` (SDK 10.0.403, runtime 10.0.14), con la caché NuGet en el volumen `<volumen-nuget>`. Las tres primeras corren sin modelo, con el recurso `build`. La cuarta usa el modelo, con el recurso `<recurso-compartido>`. Los intermedios quedaron en `{dir-de-trabajo}/senior-dotnet-r2/` y se borraron bin/obj.

    export DIR_TURNOS={dir-de-turnos}
    <envoltorio-de-turnos> build senior-dotnet-r2 "<motivo>" 20 -- R2-correr.sh <sonda>
    <envoltorio-de-turnos> <recurso-compartido> senior-dotnet-r2 "<motivo>" 45 -- R2-correr-real.sh   # OLLAMA_ENDPOINT sólo como variable de entorno

| Archivo | Qué |
|---|---|
| `R2-nuget-2026-10-28.txt` | Versiones vigentes en nuget.org (flatcontainer) |
| `R2-reflex-*` | Reflexión de OllamaSharp 5.5.0 (`OllamaRequest.<clave-de-cabeceras>`, `ChatDoneResponseStream`, `RequestOptions`), de MCP 2.3.0 (`McpServerTool.Create`, `MapMcp`, `HttpServerTransportOptions`) y de `AIFunctionFactory` |
| `R2-cuerpo-*` | PC-03, PC-04 y PC-05 con un servidor HTTP falso (Kestrel en loopback, puerto efímero) que registra encabezados y cuerpo tal como llegan por el socket |
| `R2-mcp-*` | PC-01 (`AllowedHosts`, `RequireAuthorization()`, `Origin`) y PC-09 (una sola definición `AIFunction` → `McpServerTool.Create`, un cliente MCP real por HTTP, `IChatClient` y `ChatClientAgent`) |
| `R2-real-*` | PC-04 y PC-05 contra el servidor Ollama de la LAN del laboratorio (R-LLM): `prompt_eval_cached_count` por `IChatClient` y por `/v1`, y `max_completion_tokens` en `/v1` |
| `R2-ollama-openai-compat-campos.txt` | Campos admitidos por `/v1/chat/completions` según la doc de Ollama |
| `R2-mcp-spec-transports-origin.txt` | Advertencia de seguridad del transporte Streamable HTTP (MCP 2025-06-18) |
