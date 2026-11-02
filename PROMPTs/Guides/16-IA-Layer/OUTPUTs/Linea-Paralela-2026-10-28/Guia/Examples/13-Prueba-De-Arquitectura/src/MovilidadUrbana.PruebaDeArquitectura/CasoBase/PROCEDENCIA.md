# Procedencia de `CasoBase/`

Copia literal (`diff -r` = sin diferencias) de las seis carpetas de código de `MovilidadUrbana.ApiWeb` del laboratorio Lab-E2E.WebBlazor, en el commit `59399ba`: `Domain/`, `Application/`, `Infrastructure/`, `Contracts/`, `Controllers/` y `Sessions/` (31 archivos). Conservan su namespace (`MovilidadUrbana.ApiWeb.*`), que es lo que la prueba de arquitectura usa para saber a qué capa pertenece cada tipo.

**Qué no se copió.** `Program.cs` (lo reemplaza el del ejemplo, sin OpenAPI ni Scalar, porque este ejemplo no levanta la API), `Properties/` y los `appsettings*.json`. El paquete `Microsoft.EntityFrameworkCore.Sqlite` pasa de 10.0.11 (caso base) a 10.0.14 (la versión vigente en nuget.org el 2026-10-28); la copia compila sin cambios con esa versión.

**Qué se agregó, fuera de esta carpeta.** `Agregado/Application/Propuestas/` (puerto `IExtractorDeLocalidad` y caso de uso `ProponerLocalidadDesdeTexto`, núcleo), `Agregado/Infrastructure/AI/` (adaptador de salida con `IChatClient`) y `Agregado/Presentation/Herramientas/` (adaptador de entrada con `AIFunction`). La copia **no** se modifica para que la regla dé verde: la regla se escribe sobre el código tal como está, y lo que el caso base trae y la regla no tolera se declara como excepción en la prueba (hay una: `SessionHeaderMiddleware` → `SessionContext`).

| Archivo copiado | sha256 |
|---|---|
| `Application/Abstractions/IEncuestaRepository.cs` | `d3721216c3e53a4762ad87fd16a48028af4aac9cfca24a9755175ebeec145982` |
| `Application/Abstractions/ILocalidadRepository.cs` | `22da98ffbfd93367b014088f01773b015a9f0215261cf1639418c81453a80036` |
| `Application/Abstractions/ISessionContext.cs` | `bc0231354d055b47784fd708db4ee0ea6bcaba384eb82ac7f431fa9f79e9fe06` |
| `Application/DependencyInjection.cs` | `c5d7e4b53689f7aaa27051622a0450a8aa5a3d24b5168f6119408e64857077b5` |
| `Application/Encuestas/EncuestaModel.cs` | `d9ecbfe3cbe138fe859957fbf815227710ab80f58a5c46d7f6c074f397d3c9a7` |
| `Application/Encuestas/EncuestaPolicy.cs` | `7f5102f0a6f80afb77d03d75ae118f2c8be613e7ed29ee3858f7944f9de6453d` |
| `Application/Encuestas/EncuestaService.cs` | `7b99e33767c62f3470955e273894ca579ddc135b396d18a131d8bc301f99a9f5` |
| `Application/Encuestas/ResumenDeEncuesta.cs` | `ca64b0525ef13f6d955d8ed060da97d45cb1d5804a8b25b5a4cd85c35fd30313` |
| `Application/Localidades/LocalidadModel.cs` | `b4f7cd00ff2b596c6d3b4fa3636137babf179071fcf6bc5ef4e55bb2cb507df1` |
| `Application/Localidades/LocalidadPolicy.cs` | `28cc975a6fe9316d71eb9232782ce6e2329f5d757b7b6cb6215a9de8da59ab3f` |
| `Application/Localidades/LocalidadService.cs` | `4ca85e7d01e6c8e62c1f84d19dda7373ffc7a12350753d452daaee00c925aad7` |
| `Application/Result.cs` | `4a8fb2367f052d72aaa821bf331182c41b3d67db5e886cd7f49039170b79a124` |
| `Contracts/Encuestas.cs` | `2fe8fcea773ea6d2cb5cd5dd8ecd03d2326c385d6466f52dfaf03f55fd72828a` |
| `Contracts/Localidades.cs` | `40ccf7775af4ee776410308d6c7604bada639100711c0e6a4921ab32b329af31` |
| `Controllers/EncuestasController.cs` | `f17bfa444ba6d1c75f45ab416db665cc468b5320a0e2cef9dc44236d94120c53` |
| `Controllers/LocalidadesController.cs` | `a78b9b625e73ddb48af9983428b84040b6297fb2ded31cbb5b96186b4269280d` |
| `Controllers/ValidationProblems.cs` | `d243369c7c331433c8a2bc2fbc2ab484d98332c636bb3321b791143091342d4d` |
| `Domain/Catalogos.cs` | `46fd04bb099453598041144484284a8578e673c18622b644d7b2f3be6cfd8b84` |
| `Domain/Entities/Localidad.cs` | `c6deded5411c3194b5f5c13176c91f5eea57ca51322fd144040846a79dbebd67` |
| `Domain/Entities/RespuestaDeEncuesta.cs` | `c84cc083a2141fee4ee77e6189be866cb3e857e2bb199d08d6d7eebdd8b152d4` |
| `Domain/Entities/Session.cs` | `c0d8352402ed20823278b11565b61f351bdc4c6c6de031f94ac8acc122dfa1d4` |
| `Domain/Rules/EncuestaRules.cs` | `06bce43faafdbae7920942d38406d91e21e708c0117497b856bef2efb2cd6b6e` |
| `Domain/Rules/LocalidadRules.cs` | `c69c894394b3480bbbad4193ed107ee2cf5a6fc996c46d74a1060cf3edc48819` |
| `Infrastructure/DependencyInjection.cs` | `6871f4dc1231bb97ed97e063cb4eb8d7b26d351bea71996f249cb3abd2f60bda` |
| `Infrastructure/Persistence/AppDbContext.cs` | `7f72e4d21dca87fe475b41e356ce586c5ef2711344af32789e2c4aff3d5e7373` |
| `Infrastructure/Persistence/DatabaseInitializer.cs` | `5c8b091f384b599cc1f3e182232a7c7b3703de29893ab7084fae9e85c7b0b95a` |
| `Infrastructure/Persistence/EncuestaRepository.cs` | `6edaf7dbebfdfa1d50599bb44f2df807b33e5839765f37edf620083ef09b6997` |
| `Infrastructure/Persistence/LocalidadRepository.cs` | `1dcacd9ca48e95108345dc6d0aa3f61bcaeba01d3558bd953c87d0ba9e32613b` |
| `Infrastructure/Persistence/SessionSeeder.cs` | `d4cc8ca79e4e9ea77f83d7390928bd89758ddd4ed63e443fa60bd410415f0013` |
| `Infrastructure/Sessions/SessionContext.cs` | `caa4d67fcd0a8fc1d7bca885329f21620ca03274137af4618c912ba7a2742493` |
| `Sessions/SessionHeaderMiddleware.cs` | `4102b90857bc71cd61bbb60c386bac9a7a5c02d92e40e9e4a877f49197f476a9` |
