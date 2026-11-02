# Procedencia de `CasoBase/`

Copia literal (sin cambios, `diff` = 0) de nueve archivos de `MovilidadUrbana.ApiWeb`, del laboratorio Lab-E2E.WebBlazor, en el commit `59399ba`. Conservan su namespace (`MovilidadUrbana.ApiWeb.*`) para que se vea de dónde vienen. Lo que el ejemplo agrega vive fuera de esta carpeta (`Application/`, `Herramientas/`, `Infrastructure/`, `Mcp/`, `Alternativa/`) y la copia **no** se endurece.

| Archivo copiado | Origen en el caso base | sha256 |
|---|---|---|
| `Application/Abstractions/ILocalidadRepository.cs` | `src/MovilidadUrbana.ApiWeb/Application/Abstractions/ILocalidadRepository.cs` | `22da98ffbfd93367b014088f01773b015a9f0215261cf1639418c81453a80036` |
| `Application/Abstractions/ISessionContext.cs` | `src/MovilidadUrbana.ApiWeb/Application/Abstractions/ISessionContext.cs` | `bc0231354d055b47784fd708db4ee0ea6bcaba384eb82ac7f431fa9f79e9fe06` |
| `Application/Localidades/LocalidadModel.cs` | `src/MovilidadUrbana.ApiWeb/Application/Localidades/LocalidadModel.cs` | `b4f7cd00ff2b596c6d3b4fa3636137babf179071fcf6bc5ef4e55bb2cb507df1` |
| `Application/Localidades/LocalidadService.cs` | `src/MovilidadUrbana.ApiWeb/Application/Localidades/LocalidadService.cs` | `4ca85e7d01e6c8e62c1f84d19dda7373ffc7a12350753d452daaee00c925aad7` |
| `Application/Result.cs` | `src/MovilidadUrbana.ApiWeb/Application/Result.cs` | `4a8fb2367f052d72aaa821bf331182c41b3d67db5e886cd7f49039170b79a124` |
| `Domain/Catalogos.cs` | `src/MovilidadUrbana.ApiWeb/Domain/Catalogos.cs` | `46fd04bb099453598041144484284a8578e673c18622b644d7b2f3be6cfd8b84` |
| `Domain/Entities/Localidad.cs` | `src/MovilidadUrbana.ApiWeb/Domain/Entities/Localidad.cs` | `c6deded5411c3194b5f5c13176c91f5eea57ca51322fd144040846a79dbebd67` |
| `Domain/Rules/LocalidadRules.cs` | `src/MovilidadUrbana.ApiWeb/Domain/Rules/LocalidadRules.cs` | `c69c894394b3480bbbad4193ed107ee2cf5a6fc996c46d74a1060cf3edc48819` |
| `Infrastructure/Sessions/SessionContext.cs` | `src/MovilidadUrbana.ApiWeb/Infrastructure/Sessions/SessionContext.cs` | `caa4d67fcd0a8fc1d7bca885329f21620ca03274137af4618c912ba7a2742493` |

**Qué no se copió y por qué.** `Infrastructure/Persistence/LocalidadRepository.cs` (EF Core sobre SQLite) se reemplaza por `Infrastructure/Persistence/LocalidadRepositoryEnMemoria.cs`, que filtra por sesión igual que el original y siembra las mismas dos localidades que `SessionSeeder` (Corrientes y Resistencia). `Sessions/SessionHeaderMiddleware.cs` no se copia: el servidor MCP no lee `X-Sesion-Id`; en su lugar, `Mcp/SesionFijaDeDemostracion` fija la sesión de demostración, declarada. `SessionContext.cs` se copia tal cual.

**Piezas que vienen del ejemplo 06.** `Application/Consultas/ConsultaDeLocalidades.cs`, `Application/Normalizacion/NormalizadorDeCatalogos.cs` e `Infrastructure/Persistence/*.cs` son las del ejemplo 06 con el namespace cambiado (`…ToolCalling` → `…Mcp.Servidor`); cada ejemplo es autocontenido y no referencia a otro.

**Deuda heredada, a la vista.** Las reglas copiadas aceptan lo que el camino de IA rechaza: `ProvinciaValida` sólo exige «no vacío»; `^\d{4}$` acepta dígitos que no son ASCII («٣٤٠٠»); el máximo de 60 caracteres del nombre está declarado y no se aplica. `NormalizadorDeCatalogos` cierra esas tres puertas sólo para los argumentos que llegan por una herramienta.
