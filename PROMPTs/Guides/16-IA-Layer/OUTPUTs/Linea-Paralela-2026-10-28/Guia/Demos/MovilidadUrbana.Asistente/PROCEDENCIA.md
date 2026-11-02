# Procedencia de la demo

Esta demo es una solución autocontenida. Una parte es **copia literal** de `MovilidadUrbana.ApiWeb`, del
repositorio [Lab-E2E.WebBlazor](https://github.com/hdcm-dev/Lab-E2E.WebBlazor); el resto es **agregado** y
vive fuera del árbol copiado. La demo no referencia ni escribe nada en el repositorio de origen.

## Qué se copió y de dónde

| Dato | Valor |
|---|---|
| Repositorio de origen | Lab-E2E.WebBlazor |
| Proyecto | `src/MovilidadUrbana.ApiWeb` |
| Commit | `59399ba6678c56c3219988a5f9666fc4e0047160` (`59399ba`) |
| Método | `git archive 59399ba src/MovilidadUrbana.ApiWeb`: el contenido del commit, no el del árbol de trabajo |
| Fecha de la copia | 2026-10-28 |
| Carpetas copiadas | `Domain/`, `Application/`, `Contracts/`, `Controllers/`, `Sessions/`, `Infrastructure/` (`Persistence/`, `Sessions/`, `DependencyInjection.cs`) |
| No se copió | `MovilidadUrbana.ApiWeb.csproj`, `Program.cs`, `Properties/`, `appsettings*.json`: la demo trae los suyos |

Las seis carpetas son el **cierre de compilación** de la API: compilan solas, sin nada más del origen.

## Cómo se verifica

`verificacion/verificar-copia.sh <clon de Lab-E2E.WebBlazor> 59399ba` hace dos cosas:

1. `diff -r` entre cada carpeta copiada y la del commit de origen.
2. `dotnet build` de `verificacion/CopiaSola/CopiaSola.csproj`, que compila **sólo** las carpetas copiadas
   (sin `Agregado/` ni el `Program.cs` de la demo), con los mismos paquetes y versiones que el
   `.csproj` de origen (`Microsoft.EntityFrameworkCore.Sqlite` 10.0.11, `Microsoft.AspNetCore.OpenApi`
   10.0.11, `Scalar.AspNetCore` 2.17.3).

Se corre dentro del SDK, con el clon de origen montado de sólo lectura:

```bash
docker run --rm -v "$PWD":/work -v <clon de Lab-E2E.WebBlazor>:/origen:ro -w /work \
  mcr.microsoft.com/dotnet/sdk:10.0 \
  bash -c "git config --global --add safe.directory '*' && ./verificacion/verificar-copia.sh /origen 59399ba"
```

Salida del 2026-10-28 (`mcr.microsoft.com/dotnet/sdk:10.0`, SDK 10.0.403, imagen
`sha256:de4fe90a98845d75910b9769662465c84de1a934665c431279d1382b2bddc02b`):

```text
commit de origen: 59399ba6678c56c3219988a5f9666fc4e0047160
diff -r Domain: 0 diferencias
diff -r Application: 0 diferencias
diff -r Contracts: 0 diferencias
diff -r Controllers: 0 diferencias
diff -r Sessions: 0 diferencias
diff -r Infrastructure: 0 diferencias
archivos de ApiWeb que NO se copian: MovilidadUrbana.ApiWeb.csproj Program.cs Properties appsettings.Development.json appsettings.json 
  Determining projects to restore...
  Restored /work/verificacion/CopiaSola/CopiaSola.csproj (in 2.36 sec).
  CopiaSola -> <temporal>/bin/Release/net10.0/CopiaSola.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:16.29
rc=0
```

## Cómo leer los espacios de nombres

Lo copiado conserva sus espacios de nombres `MovilidadUrbana.ApiWeb.*`; lo agregado usa
`MovilidadUrbana.Asistente.*`. La carpeta `Agregado/` no aparece en los espacios de nombres: un tipo de
`Agregado/Application/...` está en `MovilidadUrbana.Asistente.Application...`.

| Carpeta | Espacio de nombres | Origen | Capa |
|---|---|---|---|
| `Domain/` | `MovilidadUrbana.ApiWeb.Domain` | copia | núcleo |
| `Application/` | `MovilidadUrbana.ApiWeb.Application` | copia | núcleo |
| `Contracts/`, `Controllers/` | `MovilidadUrbana.ApiWeb.Contracts`, `.Controllers` | copia | entrada HTTP |
| `Sessions/` | `MovilidadUrbana.ApiWeb.Sessions` | copia | entrada HTTP (sesión por `X-Sesion-Id`) |
| `Infrastructure/` | `MovilidadUrbana.ApiWeb.Infrastructure` | copia | persistencia y sesión |
| `Agregado/Application/` | `MovilidadUrbana.Asistente.Application` | agregado | núcleo: puertos de IA, casos de uso «desde texto», normalizador, resultados agregados, orquestación del turno |
| `Agregado/Infrastructure/AI/` | `MovilidadUrbana.Asistente.Infrastructure.AI` | agregado | capa de IA: opciones, cadena del `IChatClient`, herramientas de lectura, adaptadores, historial |
| `Agregado/Infrastructure/Persistence/` | `MovilidadUrbana.Asistente.Infrastructure.Persistence` | agregado | lectura de conteos de la encuesta (EF Core) |
| `Agregado/Presentation/` | `MovilidadUrbana.Asistente.Presentation` | agregado | entrada: controller del asistente, página de chat, sesión por cookie, límite de concurrencia |
| `Program.cs`, `appsettings*.json` | (global) | agregado | composición |

## Desvíos declarados

- **De `MovilidadUrbana.Web` se toman dos piezas, adaptadas y no copiadas literal**:
  `Sessions/SessionMiddleware.cs` → `Agregado/Presentation/Sesion/CookieDeSesionMiddleware.cs`, y
  `Components/App.razor` + `Components/Routes.razor` → `Agregado/Presentation/Componentes/`. Motivo: la
  página de chat corre en un circuito de Blazor Server, que no tiene la petición HTTP original; la sesión
  tiene que llegar por cookie y pasar como parámetro al circuito, igual que en la web. La API copiada, en
  cambio, identifica la sesión por `X-Sesion-Id`, que no se propaga al circuito. Las adaptaciones: usan el
  `SessionContext` de la ApiWeb copiada, no traen layout, estilos ni servicios de la web, y `Routes` no tiene
  página de «no encontrado».
- **Composición.** `Program.cs` registra el middleware copiado `SessionHeaderMiddleware` sólo para `/api` y
  el de cookie para el resto; el original lo registra para todas las rutas. No usa OpenAPI ni Scalar.
- **Versiones.** La demo compila lo copiado con `Microsoft.EntityFrameworkCore.Sqlite` 10.0.14 (vigente en
  nuget.org el 2026-10-28); el origen usa 10.0.11. La verificación de la copia sola usa 10.0.11.

## Deuda heredada (no se corrige en la copia)

- `LocalidadesController` llama al repositorio sin pasar por el caso de uso en `GetById`, en la ubicación
  de la localidad creada y en la comprobación previa de `Update`.
- La API copiada **no hace cumplir `LargoMaximoDelNombre` (60)**: la regla lo declara y la base no lo
  limita (SQLite no aplica `HasMaxLength`). En la demo, un nombre de 61 caracteres entra por
  `POST /api/v1/localidades` con 201.
- `LocalidadRules.CodigoPostalValido` usa `^\d{4}$`, y `\d` de .NET acepta cualquier dígito Unicode:
  `"٣٤٥٠"` pasa con 201.
- `LocalidadRules.ProvinciaValida` sólo pide que no esté vacía: una provincia fuera del catálogo
  (`"Tucumán"`) pasa con 201.
- La validación del paso 2 de la encuesta sólo cuenta medios: con `["piedra"]` el paso valida, y el registro
  completo responde 201 y guarda la encuesta **sin** ese medio, en silencio.

El camino de IA rechaza los cuatro casos con `NormalizadorDeCatalogos` (agregado, núcleo), antes del caso de
uso. Los dos caminos **no dan el mismo resultado**: es lo que cuesta no endurecer la copia, y la demo lo
muestra en vez de esconderlo (`tests/.../Cableado/RecorridoD1aD6Tests.cs`, pruebas «regla heredada» y
«piedra»).
