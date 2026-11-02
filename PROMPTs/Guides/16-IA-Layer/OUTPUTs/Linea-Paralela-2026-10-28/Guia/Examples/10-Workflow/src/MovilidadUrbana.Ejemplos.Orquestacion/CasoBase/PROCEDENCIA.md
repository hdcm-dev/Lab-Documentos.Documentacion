# Procedencia de `CasoBase/`

Copia literal (sin cambios, `diff` = 0) de quince archivos de `MovilidadUrbana.ApiWeb`, del laboratorio Lab-E2E.WebBlazor, en el commit `59399ba`. Conservan su namespace (`MovilidadUrbana.ApiWeb.*`) para que se vea de dónde vienen. Lo que el ejemplo agrega vive fuera de esta carpeta (`Application/`, `Infrastructure/`, `SinModelo/`) y la copia **no** se endurece.

| Archivo copiado | Origen en el caso base | sha256 |
|---|---|---|
| `Application/Abstractions/IEncuestaRepository.cs` | `src/MovilidadUrbana.ApiWeb/Application/Abstractions/IEncuestaRepository.cs` | `d3721216c3e53a4762ad87fd16a48028af4aac9cfca24a9755175ebeec145982` |
| `Application/Abstractions/ILocalidadRepository.cs` | `src/MovilidadUrbana.ApiWeb/Application/Abstractions/ILocalidadRepository.cs` | `22da98ffbfd93367b014088f01773b015a9f0215261cf1639418c81453a80036` |
| `Application/Abstractions/ISessionContext.cs` | `src/MovilidadUrbana.ApiWeb/Application/Abstractions/ISessionContext.cs` | `bc0231354d055b47784fd708db4ee0ea6bcaba384eb82ac7f431fa9f79e9fe06` |
| `Application/Encuestas/EncuestaModel.cs` | `src/MovilidadUrbana.ApiWeb/Application/Encuestas/EncuestaModel.cs` | `d9ecbfe3cbe138fe859957fbf815227710ab80f58a5c46d7f6c074f397d3c9a7` |
| `Application/Encuestas/EncuestaService.cs` | `src/MovilidadUrbana.ApiWeb/Application/Encuestas/EncuestaService.cs` | `7b99e33767c62f3470955e273894ca579ddc135b396d18a131d8bc301f99a9f5` |
| `Application/Localidades/LocalidadModel.cs` | `src/MovilidadUrbana.ApiWeb/Application/Localidades/LocalidadModel.cs` | `b4f7cd00ff2b596c6d3b4fa3636137babf179071fcf6bc5ef4e55bb2cb507df1` |
| `Application/Localidades/LocalidadPolicy.cs` | `src/MovilidadUrbana.ApiWeb/Application/Localidades/LocalidadPolicy.cs` | `28cc975a6fe9316d71eb9232782ce6e2329f5d757b7b6cb6215a9de8da59ab3f` |
| `Application/Localidades/LocalidadService.cs` | `src/MovilidadUrbana.ApiWeb/Application/Localidades/LocalidadService.cs` | `4ca85e7d01e6c8e62c1f84d19dda7373ffc7a12350753d452daaee00c925aad7` |
| `Application/Result.cs` | `src/MovilidadUrbana.ApiWeb/Application/Result.cs` | `4a8fb2367f052d72aaa821bf331182c41b3d67db5e886cd7f49039170b79a124` |
| `Domain/Catalogos.cs` | `src/MovilidadUrbana.ApiWeb/Domain/Catalogos.cs` | `46fd04bb099453598041144484284a8578e673c18622b644d7b2f3be6cfd8b84` |
| `Domain/Entities/Localidad.cs` | `src/MovilidadUrbana.ApiWeb/Domain/Entities/Localidad.cs` | `c6deded5411c3194b5f5c13176c91f5eea57ca51322fd144040846a79dbebd67` |
| `Domain/Entities/RespuestaDeEncuesta.cs` | `src/MovilidadUrbana.ApiWeb/Domain/Entities/RespuestaDeEncuesta.cs` | `c84cc083a2141fee4ee77e6189be866cb3e857e2bb199d08d6d7eebdd8b152d4` |
| `Domain/Rules/EncuestaRules.cs` | `src/MovilidadUrbana.ApiWeb/Domain/Rules/EncuestaRules.cs` | `06bce43faafdbae7920942d38406d91e21e708c0117497b856bef2efb2cd6b6e` |
| `Domain/Rules/LocalidadRules.cs` | `src/MovilidadUrbana.ApiWeb/Domain/Rules/LocalidadRules.cs` | `c69c894394b3480bbbad4193ed107ee2cf5a6fc996c46d74a1060cf3edc48819` |
| `Infrastructure/Sessions/SessionContext.cs` | `src/MovilidadUrbana.ApiWeb/Infrastructure/Sessions/SessionContext.cs` | `caa4d67fcd0a8fc1d7bca885329f21620ca03274137af4618c912ba7a2742493` |

**Qué no se copió y por qué.** `Infrastructure/Persistence/LocalidadRepository.cs` y `EncuestaRepository.cs` (EF Core sobre SQLite) se reemplazan por `Infrastructure/Persistence/RepositoriosEnMemoria.cs`, que filtra por sesión como los originales y siembra las mismas dos localidades que `SessionSeeder` (Corrientes y Resistencia). `SessionContext.cs` se copia tal cual: en el caso base lo fija el middleware de sesión en cada petición; acá lo fija quien abre el ámbito (la consola o la prueba).

**Deuda heredada, a la vista.** Las reglas copiadas aceptan lo que el camino de IA rechaza: `ProvinciaValida` sólo exige «no vacío» (una provincia fuera del catálogo pasa); `^\d{4}$` acepta dígitos que no son ASCII («٣٤٥٠»); el máximo de 60 caracteres del nombre está declarado y no se aplica. `RevisorDeAlta` (núcleo del ejemplo) cierra esas tres puertas sólo para lo que propone el modelo.
