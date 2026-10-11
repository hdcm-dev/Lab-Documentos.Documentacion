# Informe de la mesa: Senior .NET, ciclo 3

- **Especialista:** Senior .NET. Cubre Roslyn y codificación, MSBuild, `global.json`/`rollForward`, lock de NuGet y CPM, `Deterministic`/`ContinuousIntegrationBuild`, Source Link, Visual Studio frente a la CLI e imágenes oficiales del SDK.
- **Objeto:** `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (1.0.0, 3605 líneas), leída como obra terminada. Uso `Examples/` como respaldo.
- **Fecha:** 2026-10-09. Revisión a ciegas: no leí ningún informe de otro especialista del ciclo 3. Del ciclo 2 leí sólo mi informe y `05-Aplicacion.md`, para no volver sobre lo que ya se cerró.
- **Experimentos propios:** los corrí con `mcr.microsoft.com/dotnet/sdk:8.0` (8.0.425), `:10.0` (10.0.400) y `:11.0.100-rc.1`. Las salidas están en `Ciclo-3/evidencia-senior-dotnet/`.
- **Corrección de mi propio ciclo 2:** mi hallazgo senior-dotnet-03 decía que `CheckSdkVulnerabilities` le señalaría a un equipo con 8.0.425 que su SDK estaba fuera de soporte. Eso es falso: la propiedad no existe en ese SDK (ver hallazgo 01).

---

## Hallazgos

### senior-dotnet-01: la guía recomienda `CheckSdkVulnerabilities` como práctica del fabricante, pero la propiedad no existe en 8.0.425 ni en 10.0.400, los SDK de toda la guía; ahí no hace nada y no avisa

- **Ubicación:** §6.3 L1039 («`CheckSdkVulnerabilities=true` para que la build avise si el SDK resuelto es vulnerable o está fuera de soporte [B58]»), §10.2.6 L1959 y §10.3 L1997.
- **Nivel:** E1. **Severidad:** S2.
- **Ancla** (`evidencia-senior-dotnet/checksdkvuln.txt`): `dotnet build -p:CheckSdkVulnerabilities=true` sobre un `dotnet new console` y luego `-getTargetResult:_CheckForSdkVulnerabilities`:

```text
== sdk:8.0
8.0.425
Build succeeded.
/tmp/p/p.csproj : error MSB4057: The target "_CheckForSdkVulnerabilities" does not exist in the project.
== sdk:10.0
10.0.400
Build succeeded.
/tmp/p/p.csproj : error MSB4057: The target "_CheckForSdkVulnerabilities" does not exist in the project.
== sdk:11.0.100-rc.1
11.0.100-rc.1.26425.128
Build succeeded.
{ "TargetResults": { "_CheckForSdkVulnerabilities": { ...
```

  `grep -r CheckSdkVulnerabilities /usr/share/dotnet/sdk/` no encuentra nada en 8.0.425 ni en 10.0.400. En 11.0.100-rc.1 la propiedad vive en `Microsoft.NET.SdkVulnerabilityCheck.targets`, que dice «*Opt-in … NETSDK1238 (vulnerabilities) or NETSDK1239 (EOL)*». [B58], consultado el 2026-10-09, describe la propiedad y no dice desde qué SDK existe.
- **Qué está mal:** la guía fija el SDK 8.0.425 con `disable` (A.3) y presenta la propiedad como la red que avisa si el SDK es vulnerable o sale de soporte. En ese SDK y en el 10.0.400 la propiedad no tiene efecto, y MSBuild no avisa de una propiedad desconocida. El equipo que siga §6.3 cree tener ese aviso y no lo tiene. Además, .NET 8 sale de soporte el 2026-11-10, que es justo el caso que la propiedad debería señalar.
- **Dirección:** en los tres lugares, decir que la propiedad existe **desde el SDK 11** (en 8.0.425 y 10.0.400 no hace nada; E1, con fecha). Para SDK 8 o 10, la red es `dotnet sdk check` en un job programado de la CI, más el bot de `dotnet-sdk`. Agregar el dato al Anexo F como volátil.

### senior-dotnet-02: A.10 toma el SDK de la etiqueta flotante `sdk:8.0@sha256`, así que el PR de digest del bot también cambia el parche del SDK y choca con `rollForward: disable`

- **Ubicación:** A.10 L2800 (`ARG SDK_IMAGE=mcr.microsoft.com/dotnet/sdk:8.0@sha256:78235e…`). Lo contradicen §10.2.6 L1945–L1951, donde «Imagen base | digest | PR del bot» va separado de «SDK | archivo de versión + imagen + locks | ADR», y §8.2.2 punto 2 con la variante de A.9 L2773, que para el SDK sí usan la etiqueta **fija** `8.0.425-bookworm-slim`.
- **Nivel:** E1, por E3-7 de la propia guía, más E2 ([B115]). **Severidad:** S3.
- **Ancla:**
  - Guía L1103: «en E3-7, las etiquetas `sdk:8.0` y `sdk:10.0` del host derivaron de 8.0.424 a 8.0.425 y de 10.0.302 a 10.0.400, un cambio de **banda**».
  - Guía L1408, citando [B115]: las etiquetas fijas (`8.0.11`) no cambian la versión de .NET; las flotantes sí.
  - Guía L1006 y E3-6: otro SDK cambia los paquetes implícitos y rompe el lock con `NU1004`.
- **Qué está mal:** con `sdk:8.0@sha256`, el siguiente digest de esa etiqueta (A.13, ecosistema `docker`, o cualquier actualizador) puede traer otro parche y hasta otra banda del SDK. Con `global.json` en `disable`, ese PR «de imagen base» da `A compatible .NET SDK was not found` en la compuerta. Si además `global.json` se mueve en otro PR (el del ecosistema `dotnet-sdk`), cada PR por separado queda en rojo, porque el lock cambia con el SDK (E3-6). La regla de §10.2.6, «se mueve en el mismo PR», no se puede cumplir con dos bots que proponen las dos mitades por separado.
- **Dirección:**
  1. En A.10, usar la etiqueta fija de SDK y SO con digest: `sdk:8.0.425-bookworm-slim@sha256:…`. Así el digest del bot trae sólo parches del SO [B115], y el SDK sube únicamente en el PR que mueve `global.json`, la imagen y los locks juntos.
  2. Agregar una línea en §10.2.6: con etiqueta flotante, un PR de digest puede ser un cambio de SDK.
  3. Reemplazar el digest por el de esa etiqueta en `Examples/A-plantillas/repo/imagen/Dockerfile` y volver a correr EA-1.

### senior-dotnet-03: `AssemblyMetadata ImagenDigest` de A.4 no lo alimenta nadie en el conjunto de plantillas, y si se conecta, cambia el hash de la DLL según la imagen y rompe «reconstruir y comparar»

- **Ubicación:** A.4 L2643–L2645 («Lo que el SDK no graba: … en qué imagen (la pasa la CI)»), §9.2.1 L1641. Contra A.12 L2904 (`dotnet build src/App -c Release -o out`, sin `-p:ImagenDigest`), A.17 L3046 («El digest se declara UNA vez, en el container: del workflow (A.12); el registro lo lee de ahí») y §9.4 L1737 (devcontainer como «lugar natural para reconstruir»).
- **Nivel:** E1. **Severidad:** S3.
- **Ancla** (`evidencia-senior-dotnet/imagendigest.txt`): `Examples/A-plantillas/repo/` con `CI=true`, SDK 8.0.425, el mismo commit, tres builds:

```text
ImagenDigest=[] b35eb13069cb 0
ImagenDigest=[sha256:aaaa] 031b8d556cf7 1
ImagenDigest=[sha256:bbbb] 1c1f2270261f 1
```

  `grep ImagenDigest` sobre A.12, A.17 y `A-plantillas/verificar.sh` da 0 apariciones fuera de A.4. EA-1 construye igual que A.12 (`verificar.sh` L151), sin la propiedad.
- **Qué está mal:**
  1. Es una plantilla muerta. Ni A.12 ni A.17 pasan `ImagenDigest`, y la variable de entorno `IMAGEN_DIGEST` de N8 no es la propiedad `ImagenDigest` de MSBuild.
  2. Contradice la decisión de declarar el digest «UNA vez», en el workflow, y registrarlo al lado del artefacto (A.17).
  3. Si alguien la conecta, el digest de la imagen entra en los bytes de la DLL. Una reconstrucción en el devcontainer, cuya imagen tiene otro digest aunque traiga el mismo SDK (§8.2.6, A.9), da otro hash. La verificación por reconstrucción de §9 falla por un dato de diagnóstico.
  4. Lo mismo vale, con menos riesgo, para `SdkVersion`, que ya fija `global.json` y registra A.17.
- **Dirección:** quitar de A.4 (y de `Examples/A-plantillas/repo/Directory.Build.props`) el `AssemblyMetadata` de `ImagenDigest`. En §9.2.1, decir que el digest y el SDK van **al lado** del artefacto (A.17), no adentro, porque lo incrustado tiene que ser reproducible: es el mismo criterio que la guía aplica al SBOM en §9.2.2. Si se quiere conservar `SdkVersion` embebido, rotularlo **[criterio]** y decir que la reconstrucción exige el mismo SDK, que `global.json` ya garantiza. N6 E6-1 puede quedar como demostración, con la nota de su efecto en el hash.

### senior-dotnet-04: `.slnx` no sigue «la misma convención que `.cs`»: `dotnet sln add` (SDK 10.0.400) le quita el BOM; E2-6 sólo probó la dirección sin BOM

- **Ubicación:** §5.2.3, tabla L714 (`*.csproj`, `*.props`, `*.targets`, `*.slnx` | «la misma convención que `*.cs`» | «la CLI no les agrega BOM al editarlos»); §5.6 L902 («`.csproj`, `.props` y `.slnx`, con la misma convención que `.cs`»). El README de N2 (fila E2-6) dice que «el `.slnx` y el `.csproj` se respetan».
- **Nivel:** E1. **Severidad:** S3.
- **Ancla** (`evidencia-senior-dotnet/bom-cli.txt`): BOM puesto a mano, después `dotnet sln add` y `dotnet add reference`:

```text
== sdk:8.0
8.0.425
antes   A/A.csproj  ef bb bf
despues A/A.csproj  ef bb bf
== sdk:10.0
10.0.400
antes   S.slnx  ef bb bf
antes   A/A.csproj  ef bb bf
despues S.slnx  3c 53 6f
despues A/A.csproj  ef bb bf
```

  En `Examples/N2-…/salidas/e6-plantillas-dotnet.txt` L74–L80, los dos archivos «antes» estaban **sin** BOM («se les quitó BOM y CR a mano»), así que nunca se probó la dirección contraria.
- **Qué está mal:** con la variante B, que la guía recomienda para el heredado del caso, un equipo que lea la tabla declararía `.slnx` con BOM. La CLI se lo quita en cada `dotnet sln add`: es el «pelea con la herramienta» que la propia tabla usa para justificar `.sln` con BOM, pero al revés. A.1 variante B (L2559) acierta al no incluir `slnx`, pero el texto la contradice. Con .NET 10, `.slnx` es lo que crea `dotnet new sln` [B55], así que esto alcanza a todo repo nuevo. `.csproj`, en cambio, sí conserva el BOM, y la regla vale para él.
- **Dirección:**
  1. Sacar `*.slnx` de esa fila y darle una fila propia: «UTF-8 **sin** BOM | lo decide la CLI | `dotnet sln add` lo quita (SDK 10.0.400, E1)», simétrica a la de `*.sln`.
  2. En L902: «`.slnx` sin BOM porque la CLI lo quita».
  3. En el comentario de A.1, nombrar `.slnx` como cubierto por `[*]` en las dos variantes.
  4. Agregar el caso con BOM a E2-6 y corregir la frase del README de N2.

---

## Revisado y bien

1. **§7.2.1 y A.4b: lock sólo en `Exe`/`WinExe` dentro de `Directory.Build.targets`, y la nota sobre los proyectos de prueba (cierra mi D-1 del ciclo 2).** El motivo dado es exacto: en `.props` todavía no está definido `OutputType`, y la inferencia `Exe`→`WinExe` del SDK ocurre antes de importar `Directory.Build.targets`. Lo del proyecto de prueba también es correcto: el `OutputType=Exe` de `Microsoft.NET.Test.Sdk` llega por el `nuget.g.props`, que la evaluación de restore excluye. Es coherente con EA-1 2b/2c.
2. **§9.6 y A.17: la versión del compilador como dato propio.** `csc.dll -version` sale del `Roslyn/bincore` del SDK resuelto. `4.11.0-3.25569.22 (3fb752d4)` coincide con el `CS8304` de `#error version` que medí en el ciclo 2 y con el 4.11.0 de E3-2.
3. **§4.2.3 y §6.2.2 después de la compresión del ciclo 2.** Las dos oraciones del `CS2016` quedaron fundidas en una, con su condición (servidor recién arrancado / `UseSharedCompilation=false` / SDK 10). El párrafo de `global.json` cita el error una sola vez y remite el costo a §6.4. `paths`/`errorMessage` «desde el SDK 10», la política por defecto `patch` y el *roll forward* `Minor` del runtime coinciden con [B56] y [B58].

## Solicitudes de convocatoria

- **CI/arquitectura (fuera de mandato):** A.17 lee `.github/workflows/ci.yml`, pero A.12 no dice con qué nombre se guarda el workflow (`name: compuerta`). Ya figura abierto en `Ciclo-2/05-Aplicacion.md` §6 punto 2. Pido que lo mire quien tenga CI en su mandato, porque afecta lo que registra la capa 4.
