# 13 · Prueba de arquitectura: la regla de dependencias, por reflexión

Nivel: intermedio. Se usa en la sección **§4 «La capa de IA en el stack y la regla de dependencias, con su prueba»**. Caso Movilidad Urbana.

## Qué demuestra

Que la regla «el núcleo no conoce la IA» se puede **probar** y no sólo enunciar. La prueba es un test NUnit que inspecciona lo compilado: para cada tipo de una capa mira la firma (tipo base, interfaces, campos, propiedades, eventos, parámetros, retornos, restricciones genéricas y atributos) y, además, el cuerpo de cada método, leyendo el IL y resolviendo cada token de tipo, campo o método. Si un tipo nombra algo que su capa no puede conocer, el test falla y dice qué, desde dónde y en qué lugar.

La aplicación inspeccionada es la API del caso base (un solo proyecto, con las capas como carpetas y espacios de nombres) copiada sin cambios, más la capa de IA agregada:

| Pieza | Capa | Archivo |
|---|---|---|
| Domain, Application, Infrastructure, Controllers, Sessions, Contracts del caso base | las del caso base | `src/.../CasoBase/` (copia literal; ver `CasoBase/PROCEDENCIA.md`) |
| `IExtractorDeLocalidad` (puerto, sin tipos de Microsoft.Extensions.AI) | Application (núcleo) | `src/.../Agregado/Application/Propuestas/IExtractorDeLocalidad.cs` |
| `ProponerLocalidadDesdeTexto` (caso de uso; no persiste) | Application (núcleo) | `src/.../Agregado/Application/Propuestas/ProponerLocalidadDesdeTexto.cs` |
| `ExtractorDeLocalidadLlm` (adaptador de salida, el único que conoce `IChatClient`) | Infrastructure/AI | `src/.../Agregado/Infrastructure/AI/ExtractorDeLocalidadLlm.cs` |
| Registro del proveedor (OllamaSharp aparece sólo acá) | Infrastructure/AI | `src/.../Agregado/Infrastructure/AI/DependencyInjection.cs` |
| `HerramientasDeLectura` (adaptador de entrada: un caso de uso expuesto como `AIFunction`) | Presentation | `src/.../Agregado/Presentation/Herramientas/HerramientasDeLectura.cs` |
| Raíz de composición (no se inspecciona; sólo registra) | — | `src/.../Composicion.cs`, `src/.../Program.cs` |

Las reglas (`tests/.../Cableado/ReglaDeDependenciasTests.cs`; las capas, en `Cableado/Capas.cs`):

| Regla | Capa inspeccionada | No puede nombrar |
|---|---|---|
| El núcleo no conoce IA, acceso a datos, HTTP ni las capas de afuera | `ApiWeb.Domain`, `ApiWeb.Application`, `PruebaDeArquitectura.Application` | `Microsoft.Extensions.AI*`, `Microsoft.Agents.AI*`, `ModelContextProtocol*`, `OllamaSharp*`, `Microsoft.EntityFrameworkCore*`, `Microsoft.Data.Sqlite*`, `Microsoft.AspNetCore*`, Infrastructure y Presentation |
| El dominio no conoce Application | `ApiWeb.Domain` | Application |
| Infrastructure no usa casos de uso ni Presentation | `ApiWeb.Infrastructure`, `PruebaDeArquitectura.Infrastructure` | las clases `*Service` de Application y `ProponerLocalidadDesdeTexto`; Presentation |
| La persistencia no conoce IA | `ApiWeb.Infrastructure` | la familia de IA |
| El adaptador de IA no conoce el acceso a datos | `PruebaDeArquitectura.Infrastructure.AI` | EF Core, SQLite, la persistencia |
| Presentation no conoce acceso a datos, proveedor de IA ni Infrastructure | `ApiWeb.Controllers`, `ApiWeb.Sessions`, `ApiWeb.Contracts`, `PruebaDeArquitectura.Presentation` | EF Core, SQLite, `OllamaSharp`, Infrastructure (sí puede `AIFunction`: es su protocolo) |

Tres decisiones que el código hace visibles:

- **Cada regla comprueba primero que inspeccionó algo.** Una regla sobre cero tipos da verde y no prueba nada: si se renombra un espacio de nombres, el test falla por «la capa no tiene los tipos que se esperaba inspeccionar», no pasa en silencio.
- **Las excepciones se declaran en el test, con su motivo.** Hay una, heredada del caso base: `SessionHeaderMiddleware` (Presentation) recibe la clase concreta `SessionContext` (Infrastructure) porque es la que tiene `Set`. Otra prueba (`Cada_excepcion_declarada_sigue_existiendo`) falla si la excepción deja de hacer falta.
- **`Application` registra sus casos de uso con `IServiceCollection`** (`Microsoft.Extensions.DependencyInjection`): no está en la lista de prohibidos, y la regla no lo trata como una violación.

### Los casos rojos

Las mutaciones viven en `src/.../Mutaciones/<nombre>/` y quedan fuera de la compilación por defecto. Sirven de dos maneras: (1) siempre, compiladas dentro del ensamblado de pruebas, para afirmar qué detecta la regla (`Cableado/CasosRojosTests.cs`); (2) a pedido, con `-p:Mutacion=<nombre>`, entran a la aplicación y la regla verde se vuelve roja.

| Mutación | Qué hace | Con `-p:Mutacion=` |
|---|---|---|
| `R4` | un `global using Microsoft.Extensions.AI;` en un archivo cualquiera y, en Application, una propiedad `ChatMessage` con el nombre corto y otra con el nombre calificado | **rojo**: falla la regla del núcleo |
| `Cuerpo` | un tipo prohibido sólo dentro del cuerpo de un método; la firma queda limpia | **rojo** (lo ve la lectura del IL; con la firma sola, no) |
| `Atributo` | `[Microsoft.EntityFrameworkCore.Keyless]` sobre un tipo de Application | **rojo** |
| `HerramientaEnInfrastructure` | un tipo de Infrastructure/AI que toma `LocalidadService` para exponerlo como herramienta | **rojo**: falla la regla de Infrastructure; ese trabajo es de un adaptador de entrada |
| `SoloUsing` | un `global using Microsoft.Extensions.AI;` que nadie usa | verde: **agujero declarado** |
| `Nameof` | `nameof(Microsoft.Extensions.AI.ChatMessage)` en una constante | verde: **agujero declarado** |

Los dos agujeros son de la misma naturaleza: lo que no deja rastro en lo compilado no se puede inspeccionar por reflexión. Un `using` sin uso no se compila; `nameof` queda como una cadena. Ninguno de los dos crea una dependencia en tiempo de ejecución, pero sí indica que alguien tiene a mano el tipo prohibido, y eso se ve en revisión, no en esta prueba.

Por qué no una búsqueda de texto: sobre la mutación `R4`, buscar `using Microsoft.Extensions.AI` en las carpetas del núcleo da 0 coincidencias, porque el `global using` está en otro archivo y el nombre calificado no necesita `using` (salida en «Resultado medido»).

## Requisitos

- Docker con la imagen `mcr.microsoft.com/dotnet/sdk:10.0` (probado con `sha256:de4fe90a98845d75910b9769662465c84de1a934665c431279d1382b2bddc02b`, SDK 10.0.403).
- **Sin modelo.** Nada de este ejemplo llama al servidor Ollama de prueba: ni las pruebas ni la compilación. `OLLAMA_ENDPOINT` sólo lo leería la API si se la levantara (por defecto `http://localhost:11434`, desde `AI:Endpoint` en `appsettings.json`), y no hace falta para lo que el ejemplo enseña.

Paquetes (versiones exactas, consultadas en nuget.org el 2026-10-28):

| Paquete | Versión | Dónde |
|---|---|---|
| `Microsoft.EntityFrameworkCore.Sqlite` | 10.0.14 | src |
| `Microsoft.Extensions.AI` | 10.11.0 | src |
| `OllamaSharp` | 5.5.0 | src |
| `NUnit` | 5.0.0 | tests |
| `NUnit3TestAdapter` | 6.3.1 | tests |
| `Microsoft.NET.Test.Sdk` | 18.11.0 | tests |

## Comandos

Desde esta carpeta. `bin/`, `obj/`, `TestResults/` y `salidas/` quedan fuera de git por `.gitignore`.

Compilar:

```bash
docker run --rm -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet build 13-Prueba-De-Arquitectura.slnx
```

Pruebas sin modelo (`Cableado/`, deterministas; son todas las del ejemplo):

```bash
docker run --rm -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test tests/MovilidadUrbana.PruebaDeArquitectura.Tests --logger "console;verbosity=detailed"
```

Un caso rojo de verdad: la regla corre sobre la aplicación con la mutación adentro (cambiá `R4` por `Cuerpo`, `Atributo`, `HerramientaEnInfrastructure`, `SoloUsing` o `Nameof`):

```bash
docker run --rm -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test tests/MovilidadUrbana.PruebaDeArquitectura.Tests -p:Mutacion=R4 --filter Category=Regla \
  --logger "console;verbosity=normal"
```

Después de una corrida con mutación, la siguiente sin `-p:Mutacion` recompila la aplicación limpia.

Contra el modelo: no corresponde. Este ejemplo no tiene `ConModelo/`.

## Resultado esperado

- Build: `0 Warning(s)`, `0 Error(s)` (con `TreatWarningsAsErrors`).
- `Cableado/`: 13 pruebas en verde. Siete de la regla (seis reglas y la de las excepciones), cinco de casos rojos (R4, cuerpo de método con y sin IL, atributo, herramienta en Infrastructure, `nameof`) y una de composición (el puerto se resuelve con el adaptador y la herramienta llega al caso de uso, con `ValidateScopes` y `ValidateOnBuild` en `true`).
- Con `-p:Mutacion=R4`, `Cuerpo` o `Atributo`: falla `El_nucleo_no_conoce_IA_ni_acceso_a_datos_ni_HTTP_ni_las_capas_de_afuera` y las otras seis pasan. Con `HerramientaEnInfrastructure`: falla `Infrastructure_no_usa_casos_de_uso_ni_Presentacion`. Con `SoloUsing` o `Nameof`: 7 de 7 en verde (los agujeros).

## Resultado medido

Corrida del 2026-10-28 con el código de esta carpeta, en `mcr.microsoft.com/dotnet/sdk:10.0` (`sha256:de4fe90a…dc02b`, SDK 10.0.403). Sin modelo: no lleva cabecera R-LLM, porque nada depende de un modelo.

| Corrida | Resultado |
|---|---|
| `dotnet build` | 0 advertencias, 0 errores |
| `dotnet test` (`Cableado/`) | 13/13 en verde; el núcleo inspeccionado tiene 34 tipos |
| `-p:Mutacion=R4` | 6/7; falla la regla del núcleo. Los hallazgos son 12, seis por propiedad: la propiedad, su campo de respaldo, el retorno y el cuerpo del `get`, y el parámetro y el cuerpo del `set` (contados en la prueba `R4_global_using_y_propiedad_ChatMessage_se_detecta`) |
| `-p:Mutacion=Cuerpo` | 6/7; falla la regla del núcleo: `ResumenQueArmaUnMensaje → ChatMessage (cuerpo de LargoDelSaludo)` y `→ ChatRole (cuerpo de LargoDelSaludo)` |
| `-p:Mutacion=Atributo` | 6/7; falla la regla del núcleo: `LocalidadSinClave → Microsoft.EntityFrameworkCore.KeylessAttribute (atributo de tipo)` |
| `-p:Mutacion=HerramientaEnInfrastructure` | 6/7; falla la regla de Infrastructure: `→ LocalidadService` en el campo, el constructor y la máquina de estado de la lambda |
| `-p:Mutacion=SoloUsing` | 7/7 (el archivo entra al compilador; no deja rastro) |
| `-p:Mutacion=Nameof` | 7/7 (el núcleo pasa a 35 tipos inspeccionados; la constante no nombra ningún tipo) |
| búsqueda de `using Microsoft.Extensions.AI` en el núcleo con `R4` puesta | 0 coincidencias; el archivo mutado tiene 2 líneas con `ChatMessage` |

Cómo leerlo: la firma sola no alcanza (el caso `Cuerpo` pasa sin la lectura del IL y la prueba lo afirma), y la lectura del IL tampoco ve lo que el compilador borra (`SoloUsing`, `Nameof`). La prueba dice exactamente qué cubre.
