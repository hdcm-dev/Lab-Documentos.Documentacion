# Evidencia del especialista Senior .NET — mesa ciclo 1 (2026-10-28)

Todo sin modelo (no se usó `<recurso-compartido>`). Compilación y corrida por el recurso `build`:

    export DIR_TURNOS={dir-de-turnos}
    <envoltorio-de-turnos> build senior-dotnet "<motivo>" 20 -- \
      docker run --rm -v <sonda>:/work -v <volumen-nuget>:/root/.nuget/packages -w /work \
      mcr.microsoft.com/dotnet/sdk:10.0 sh -c 'dotnet --version && dotnet run'

SDK 10.0.403, runtime 10.0.14. Intermedios en `{dir-de-trabajo}/senior-dotnet/`, bin/obj borrados.

| Archivo | Qué |
|---|---|
| `S-sonda1-*` | [S1] spans según el orden de `UseOpenTelemetry` frente a `UseFunctionInvocation`; [S2] ciclo de vida de `AddChatClient` Scoped (HttpClient por scope) y patrón interno Singleton por clave; [S3] reflexión de `TypedResults.ServerSentEvents`, `AIAgent.Serialize/DeserializeSessionAsync`, `VectorStoreVectorAttribute` |
| `S-sonda2-*` | `[Experimental]` en las piezas que la guía enseña por defecto, con control positivo (reducers, `IImageGenerator`); valores por defecto de `FunctionInvokingChatClient` |
| `S-sonda3-*` | Dónde se fija `num_ctx` desde OllamaSharp 5.5.0 (reflexión) |
| `S-nuget-2026-10-28.tsv` | Versiones vigentes en nuget.org (flatcontainer) a las 09:45 -03 |
| `S-caso-base-lectura.txt` | Cierre de compilación de la copia de ApiWeb y propagación de la sesión al circuito en la Web (`59399ba`) |
| `S-ollama-openai-compat-2026-10-28.txt` | Cita de la doc de Ollama sobre `num_ctx` en `/v1` |
| `S-sonda4-*` | EF Core Sqlite 10.0.14: agregados «por medio» con el `ValueConverter` de `Medios` del caso base (transcrito de `AppDbContext.cs`@59399ba) |
