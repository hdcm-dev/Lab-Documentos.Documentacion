# Informe de la mesa: Senior .NET, ciclo 1

- **Especialista:** Senior .NET. Cubre Roslyn y codificación, MSBuild, `global.json`/`rollForward`, lock de NuGet y CPM, `Deterministic`/`ContinuousIntegrationBuild`, Source Link, Visual Studio frente a la CLI, imágenes oficiales del SDK.
- **Objeto:** `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (3060 líneas, borrador integrado), con el laboratorio `Examples/` como respaldo.
- **Fecha:** 2026-10-07. Revisión a ciegas: no leí informes de otros especialistas de este ciclo.
- **Experimentos propios:** los corrí en el scratchpad de la sesión, fuera del repositorio, con `mcr.microsoft.com/dotnet/sdk:8.0` (8.0.425) y `:10.0` (10.0.400).

---

## Hallazgos

### senior-dotnet-01: «¿Fijar el SDK fija el compilador? Sí» es falso en Visual Studio con el SDK 8 que fija la propia guía

- **Ubicación:** §6.2.2, línea 885 («**¿Fijar el SDK fija el compilador?** Sí: el compilador viaja dentro del SDK…»). También §6.6, línea 975 («Fija el SDK con que corren `dotnet` y MSBuild y, por arrastre, el compilador…») y línea 979 («El compilador sí; el runtime no»).
- **Nivel:** E1, por inspección de los *targets* de los SDK oficiales, más E2 [B60].
- **Severidad:** S2.
- **Ancla:**

```text
$ docker run --rm mcr.microsoft.com/dotnet/sdk:8.0 sh -c 'grep -n "RoslynCompilerType\|BuildWithNetFrameworkHostedCompiler\|DOTNET_HOST_PATH" /usr/share/dotnet/sdk/8.0.425/Sdks/Microsoft.NET.Sdk/targets/Microsoft.NET.Sdk.targets'
222:         If they do, and they also set BuildWithNetFrameworkHostedCompiler, we will have
227:    <ItemGroup Condition="'$(BuildWithNetFrameworkHostedCompiler)' == 'true' and '$(OS)' == 'Windows_NT'">
      (SDK 8: sólo opt-in, agrega Microsoft.Net.Compilers.Toolset.Framework; no hay selección automática)

$ curl -s https://api.nuget.org/v3-flatcontainer/microsoft.net.sdk.compilers.toolset/index.json  → 94 versiones; la primera, 9.0.100-preview.7; ninguna 8.x

$ docker run --rm mcr.microsoft.com/dotnet/sdk:10.0 sh -c 'sed -n 325,362p .../10.0.400/Sdks/Microsoft.NET.Sdk/targets/Microsoft.NET.Sdk.BeforeCommon.targets'
    Use Roslyn deployed with SDK for builds of SDK-style projects (regardless of whether the initiator is `dotnet` or `msbuild`).
    <When Condition="'$(MSBuildRuntimeType)' == 'Core' or '$(DOTNET_HOST_PATH)' != '' ..."> → RoslynCompilerType=Core
    <When ... '$(_IsDisjointMSBuildVersion)' == 'true' ...> → FrameworkPackage (descarga Microsoft.Net.Sdk.Compilers.Toolset)
    <Otherwise> → RoslynCompilerType=Framework   (compilador del MSBuild de Visual Studio; con advertencia de obsoleto)
$ ... Microsoft.NETCoreSdk.BundledMSBuildInformation.props:
    <_IsDisjointMSBuildVersion>$([MSBuild]::VersionLessThan('$(_MSBuildVersionMajorMinor)', '18.9'))
```

- **Qué está mal:** la selección del compilador cuando la build corre en el MSBuild de Visual Studio depende de la **versión del SDK**:
  - **SDK 8.0.4xx**, el que fijan §6.5 y A.3 (`8.0.425`, `disable`): no tiene ningún mecanismo automático. Desde Visual Studio compila el Roslyn que trae el IDE. Con un Visual Studio 2026 (18.x), ese compilador es de la línea 5.x, no el 4.11.0 que E3-2 atribuye al SDK 8.0.425. El paquete `Microsoft.Net.Sdk.Compilers.Toolset` no existe para 8.x.
  - **SDK 10.0.400:** usa el Roslyn del SDK (`Core`) si hay `DOTNET_HOST_PATH`. Descarga el paquete *toolset* sólo si el MSBuild es **más viejo** que 18.9. Si no se da ninguna de las dos, cae en `Framework`, que es el compilador del IDE. La frase de §6.2.2 («cuando no coincide con el SDK, el SDK descarga…») omite que el disparador sólo se activa en esa dirección.
  - **`global.json` no fija el motor MSBuild en Visual Studio:** «Fija el SDK con que corren `dotnet` y MSBuild» induce a pensar que sí.
- **Dirección:**
  1. Reescribir la respuesta así: «En la CLI, sí. En Visual Studio depende del SDK. Con el SDK 8, Visual Studio compila con su propio Roslyn. Con el SDK 9 o 10, con el del SDK (`Core`) o con el paquete *toolset* cuando el MSBuild es más viejo que el que espera el SDK».
  2. Mover la marca **[no verificado en Visual Studio]** a lo que de verdad no se ejecutó (el comportamiento en el IDE) y citar los *targets* como E1.
  3. Agregar al toolchain registrado (§9) la versión del compilador efectiva. Se obtiene con `#error version` (CS8304) [B57] o del *binlog*.
  4. Reforzar «la CI compila con `dotnet build`» como fuente de verdad del binario.
- **Impacto:** el caso tiene la estación Windows con Visual Studio (ESC-01) como escenario principal. El lector termina creyendo que `global.json` alinea el compilador entre el IDE y la CI, y con el SDK 8 eso no ocurre.

### senior-dotnet-02: «NuGet resuelve la siguiente disponible sin advertencia» generaliza un caso particular: el silencio lo produce el lock file

- **Ubicación:** §7.2.1, línea 1048 («E4-2 agregó otro caso: si la versión pedida no existe, NuGet resuelve la siguiente disponible **sin advertencia** (pedida 8.0.2, resuelta 9.0.0)»). También línea 1052 («CPM solo no evita la deriva (E4-2 pidió 8.0.2 y obtuvo 9.0.0)»).
- **Nivel:** E1.
- **Severidad:** S2.
- **Ancla:** el mismo `Directory.Packages.props` (Logging 8.0.0, Options 8.0.2, Primitives 8.0.2 con *transitive pinning*), con y sin `RestorePackagesWithLockFile`, en un contenedor frío y empezando por el proyecto con lock:

```text
SDK 8.0.425
== conlock (frío primero: conlock)
  Restored /w/conlock/App.csproj (in 3.01 sec).                      ← sin advertencia
== sinlock
/w/sinlock/App.csproj : warning NU1603: App depends on Microsoft.Extensions.Primitives (>= 8.0.2) but Microsoft.Extensions.Primitives 8.0.2 was not found. An approximate best match of Microsoft.Extensions.Primitives 9.0.0 was resolved.
SDK 10.0.400
== sinlock  → warning NU1603: … Microsoft.Extensions.Primitives 9.0.0 was resolved instead.   (NU1603 en assets: 1)
== conlock  → Restored … sin advertencia                                                      (NU1603 en assets: 0)
   packages.lock.json: "type": "CentralTransitive", "requested": "[8.0.2, )", "resolved": "9.0.0"
```

  Con una `PackageReference` directa a `Primitives 8.0.2`, sin lock, también aparece `NU1603`. El paso 5 de `Examples/N4-congelamiento-de-dependencias/e2-nuget-cpm-pinning/run.sh` da 0 advertencias porque su `App.csproj` tiene `RestorePackagesWithLockFile=true`. Lo reproduje y el resultado fue el mismo.
- **Qué está mal:** el comportamiento por defecto de NuGet **sí** avisa (`NU1603`). El silencio es una interacción con el lock file, observada en SDK 8.0.425 y 10.0.400. Además, el caso no es «deriva»: es una versión inexistente que se aproxima por arriba. El hallazgo real es más fuerte y más útil que el que escribe la guía: **activar el lock file hace desaparecer la advertencia que habría delatado la aproximación**, y el lock congela `requested [8.0.2, )` con `resolved 9.0.0` sin que nadie lo vea.
- **Dirección:**
  1. Corregir la frase: «NuGet avisa con `NU1603`, pero en los proyectos con `packages.lock.json` el aviso no apareció (E4-2, SDK 8.0.425 y 10.0.400)».
  2. Citar la referencia de `NU1603` en learn.microsoft.com.
  3. **[criterio]** Proponer a la compuerta (§10) un chequeo sobre el lock que compare `requested` con `resolved` en las entradas `Direct` y `CentralTransitive`.
  4. Actualizar el paso 5 del laboratorio para que muestre las dos variantes, con y sin lock.
  5. En la línea 1052, decir «CPM no garantiza la versión pedida» en lugar de «deriva».

### senior-dotnet-03: `rollForward: disable` sí bloquea la estación con otro parche; §6.4 dice lo contrario

- **Ubicación:** §6.4, línea 933 («`disable` en el repo, el SDK exacto en la imagen…; el modo estricto se activa sólo en CI (§7), así que una estación con otro parche no queda bloqueada para trabajar, pero la CI detecta la diferencia»).
- **Nivel:** E1, y coincide con E3-1 de la propia guía.
- **Severidad:** S2.
- **Ancla:**

```text
$ printf '{ "sdk": { "version": "8.0.424", "rollForward": "disable", "allowPrerelease": false } }' > global.json
$ docker run --rm -v "$PWD":/w -w /w mcr.microsoft.com/dotnet/sdk:8.0 sh -c 'ls /usr/share/dotnet/sdk; dotnet build'
8.0.425
The command could not be loaded, possibly because:
  * You intended to execute a .NET SDK command:
      A compatible .NET SDK was not found.
```

- **Qué está mal:** que el modo estricto del **lock** sea sólo de CI no cambia nada sobre el **SDK**. Con `disable`, `dotnet` (y el resolvedor de MSBuild del IDE) falla antes de compilar en toda máquina que no tenga **exactamente** esa versión. La propia tabla de §6.2.2 lo dice («`disable` | coincidencia exacta»). La consecuencia práctica para ESC-01 es que cada actualización mensual de Visual Studio reemplaza su SDK [B59], y la estación queda bloqueada hasta instalar el SDK independiente.
- **Dirección:**
  1. Reescribir el criterio: «con `disable`, toda estación necesita el SDK exacto (instalador independiente en Windows), y subirlo es un cambio coordinado por PR que toca `global.json`, la imagen y los locks a la vez».
  2. Si se quiere no bloquear estaciones, la alternativa honesta es `latestPatch` con `RestoreLockedMode` sólo en CI. Hay que decir que entonces `NU1004` puede aparecer en la CI cuando el parche local difiere (E3-6), y que eso es lo que la compuerta detecta.
  3. Presentar los dos caminos como compromiso explícito, no como si `disable` no tuviera costo.

### senior-dotnet-04: lock en bibliotecas. La plantilla A.4 contradice el texto, y el texto cita mal [B83]

- **Ubicación:**
  - §7.2.1, línea 1050: «commitear el lock en **aplicaciones** y no en bibliotecas que consumen otros [B83]».
  - §7.6, línea 1131: «en una biblioteca que se publica, CPM sí y lock no [B83]».
  - §7.7, línea 1158: señal pobre «lock en una biblioteca».
  - Anexo A.4: `<RestorePackagesWithLockFile>true</RestorePackagesWithLockFile>` para **todos** los proyectos, y `RestoreLockedMode` en CI.
- **Nivel:** E2.
- **Severidad:** S3.
- **Ancla:** [B83], *Make lock file part of your source repository*, consultado el 2026-10-07: «*if your project is a library project that you do not ship or a common code project on which other projects depend, you **should not** check in the lock file … There is no harm in keeping the lock file, but the locked package dependencies for the common code project can't be used*».
- **Qué está mal:**
  - La fuente habla de bibliotecas que **no** se distribuyen y de proyectos de código común. La guía lo convierte en «biblioteca que se publica».
  - A.4 activa el lock en todo proyecto de la solución, incluidas las bibliotecas internas, y la exigencia de CI hace obligatorio commitearlos. Esa es justamente la «señal de versión pobre» de §7.7.
  - La fuente dice que conservarlo no hace daño; lo que no hace es gobernar lo que resuelve quien lo referencia.
- **Dirección:**
  1. Citar la regla con sus palabras: el lock que manda es el del proyecto en la punta de la cadena; el de un proyecto común no gobierna lo que resuelve quien lo referencia.
  2. Quitar «lock en una biblioteca» de las señales pobres, o precisarlo como «tratar el lock de una biblioteca como garantía para sus consumidores».
  3. Si se quiere seguir la recomendación al pie de la letra, mostrar en A.4 cómo activar el lock sólo en los proyectos ejecutables. Por ejemplo, con la condición `'$(OutputType)' == 'Exe'`, que habría que verificar en EA-1 porque `OutputType` puede no estar definido aún cuando se evalúa `Directory.Build.props`.

### senior-dotnet-05: el `CS2016` del SDK 8 tiene un desvío medido que la guía no transmite

- **Ubicación:** §4.2.3, línea 450 («con SDK 8.0.425 la build con `CodePage=1252` falla con `CS2016` … según el estado del servidor de compilación»); también §4.6.
- **Nivel:** E1, con la salida del propio laboratorio.
- **Severidad:** S4.
- **Ancla:** `Examples/N1-codificacion-y-finales-de-linea/salidas/e1-roslyn-codepage-servidor.txt`:

```text
SDK 8.0.425
1) servidor frío, CodePage=1252:                 error CS2016
3b) servidor calentado con un .cs cp1252 (fallback): Build succeeded
4) sin servidor (UseSharedCompilation=false):     Build succeeded
```

- **Qué está mal:** la guía dice que la falla depende «del estado del servidor de compilación», pero no dice cuál es el estado ni cómo evitarlo. Un lector que necesita compilar hoy el árbol cp1252 en Linux con el SDK 8 (el paliativo transitorio que la misma §4.6 admite) se queda sin la salida que el laboratorio ya midió.
- **Dirección:** agregar una oración. Con SDK 8, `CS2016` aparece cuando el servidor `VBCSCompiler` no registró aún el proveedor de páginas de códigos. `-p:UseSharedCompilation=false` lo evita (E1-03), y el SDK 10 no lo necesita ([B16], corregido en el compilador).

### senior-dotnet-06: `LangVersion` fijo en 12.0 para todo el repo en A.4

- **Ubicación:** Anexo A.4, línea 2295 (`<LangVersion>12.0</LangVersion>`, comentario «Capa 5: nunca "latest"; omitirlo deja la versión que fija el TFM»).
- **Nivel:** E2 [B57].
- **Severidad:** S4.
- **Ancla:** [B57]: «*the default version aligns with the project's target framework (TFM). This default configuration ensures compatibility between language features and runtime support … If you must specify your C# version explicitly…*».
- **Qué está mal:** la plantilla aplica 12.0 a **toda** la solución desde `Directory.Build.props`. Un proyecto `net10.0` (E5-6 y §8.2.6 ya usan `net10.0`) queda limitado a C# 12 sin aviso, y la subida de TFM deja de arrastrar al lenguaje, que es justamente el mecanismo que §6.2.1 presenta como el correcto.
- **Dirección:** dejar `LangVersion` comentado en la plantilla, con la nota «sólo si hace falta un valor distinto del que fija el TFM; nunca `latest`», o condicionarlo por `TargetFramework`.

---

## Revisado y bien

1. **§6.2.2, `rollForward` y Visual Studio:** el comportamiento por defecto (`patch` dentro de la banda), `disable` como única fijación exacta, `allowPrerelease` (por defecto `true` fuera de VS) y las bandas mínimas de Visual Studio (10.0.100 → 17.14; 10.0.2xx–4xx → 18.0) coinciden con [B56] y [B59], consultados el 2026-10-07. La recomendación de `disable` con lock files coincide con la nota de [B83] sobre los paquetes implícitos del SDK. `CheckSdkVulnerabilities` existe en [B58] (NETSDK1238/1239/1240).
2. **§9.2.1, determinismo:** `ContinuousIntegrationBuild` + `Deterministic`; la advertencia sobre `PathMap` a mano (que [B17] también restringe a builds de CI); el *nupkg* no determinista en SDK 8 y 10; y «desde .NET 11 deterministas por defecto, salvo las fechas, con `DeterministicTimestamp` o `SOURCE_DATE_EPOCH`». Todo coincide literalmente con [B147] y con la salida de E6-2/E6-2b.
3. **§4.2.1 y §4.2.3, Roslyn y codificación:** la cadena BOM → (sin `CodePage`) UTF-8 estricto → página ANSI del sistema; que `CodePage` apaga el intento UTF-8; y la contradicción con [B17], que efectivamente sigue diciendo «*The compiler first attempts to interpret all source files as UTF-8*» y sin embargo el código no lo hace con `CodePage` presente. E1-03 separa con rigor el efecto del servidor de compilación.

## Solicitudes de convocatoria

Ninguna. No vi nada fuera de mi mandato que requiera otro especialista.
