# Procedencia de `CasoBase/`

Copia literal (sin cambios, `diff` = 0) de cuatro archivos de `MovilidadUrbana.ApiWeb`, del laboratorio Lab-E2E.WebBlazor, en el commit `59399ba`. Conservan su namespace (`MovilidadUrbana.ApiWeb.*`) para que se vea de dónde vienen. Lo que el ejemplo agrega vive fuera de esta carpeta (`Application/`, `Infrastructure/`).

| Archivo copiado | Origen en el caso base | sha256 |
|---|---|---|
| `Application/Abstractions/ISessionContext.cs` | `src/MovilidadUrbana.ApiWeb/Application/Abstractions/ISessionContext.cs` | `bc0231354d055b47784fd708db4ee0ea6bcaba384eb82ac7f431fa9f79e9fe06` |
| `Domain/Catalogos.cs` | `src/MovilidadUrbana.ApiWeb/Domain/Catalogos.cs` | `46fd04bb099453598041144484284a8578e673c18622b644d7b2f3be6cfd8b84` |
| `Domain/Entities/RespuestaDeEncuesta.cs` | `src/MovilidadUrbana.ApiWeb/Domain/Entities/RespuestaDeEncuesta.cs` | `c84cc083a2141fee4ee77e6189be866cb3e857e2bb199d08d6d7eebdd8b152d4` |
| `Infrastructure/Sessions/SessionContext.cs` | `src/MovilidadUrbana.ApiWeb/Infrastructure/Sessions/SessionContext.cs` | `caa4d67fcd0a8fc1d7bca885329f21620ca03274137af4618c912ba7a2742493` |

**Qué no se copió y por qué.** `Infrastructure/Persistence/EncuestaRepository.cs` (EF Core sobre SQLite) se reemplaza por `Infrastructure/Persistence/RespuestasEnMemoria.cs`, que filtra por sesión como el original y siembra cuatro respuestas ficticias. El caso base no tiene un caso de uso de resultados: `ConsultaDeResultadosPorMedio` es núcleo del ejemplo. `SessionContext.cs` se copia tal cual; acá lo fija quien abre el ámbito (la consola o la prueba).
