# Procedencia de `CasoBase/`

Copia literal (sin cambios, `diff` = 0) de cuatro archivos de `MovilidadUrbana.ApiWeb`, del laboratorio
Lab-E2E.WebBlazor, en el commit `59399ba`. Conservan su namespace (`MovilidadUrbana.ApiWeb.*`) para que se vea de
dónde vienen.

| Archivo copiado | Origen en el caso base | sha256 |
|---|---|---|
| `Domain/Rules/LocalidadRules.cs` | `src/MovilidadUrbana.ApiWeb/Domain/Rules/LocalidadRules.cs` | `c69c894394b3480bbbad4193ed107ee2cf5a6fc996c46d74a1060cf3edc48819` |
| `Domain/Rules/EncuestaRules.cs` | `src/MovilidadUrbana.ApiWeb/Domain/Rules/EncuestaRules.cs` | `06bce43faafdbae7920942d38406d91e21e708c0117497b856bef2efb2cd6b6e` |
| `Application/Localidades/LocalidadPolicy.cs` | `src/MovilidadUrbana.ApiWeb/Application/Localidades/LocalidadPolicy.cs` | `28cc975a6fe9316d71eb9232782ce6e2329f5d757b7b6cb6215a9de8da59ab3f` |
| `Application/Encuestas/EncuestaPolicy.cs` | `src/MovilidadUrbana.ApiWeb/Application/Encuestas/EncuestaPolicy.cs` | `7f5102f0a6f80afb77d03d75ae118f2c8be613e7ed29ee3858f7944f9de6453d` |

Los doce enunciados de `LocalidadPolicy` y `EncuestaPolicy` son el corpus del ejemplo: se leen por reflexión, así
que si un límite cambia en las reglas, el texto indexado cambia con él.

**Deuda heredada, a la vista.** Los enunciados dicen lo que la política **declara**, no siempre lo que el código
verifica: `LocalidadPolicy` dice «entre 3 y 60 caracteres» y ninguna regla aplica el máximo de 60; dice «una de las
provincias del catálogo» y `ProvinciaValida` sólo exige que no esté vacía; «4 dígitos» es `^\d{4}$`, y en .NET `\d`
acepta cualquier dígito decimal Unicode. Este ejemplo busca enunciados; no decide validez.
