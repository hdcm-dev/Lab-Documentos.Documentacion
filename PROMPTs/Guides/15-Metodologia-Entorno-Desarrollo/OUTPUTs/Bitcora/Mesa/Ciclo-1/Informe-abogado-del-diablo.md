# Mesa · Ciclo 1 · Informe del abogado del diablo

- **Rol**: abogado del diablo (núcleo permanente). Marco: `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §4.1.1 («mandato explícito de atacar la propuesta dominante; entra después de leer al resto») y §9 (anclaje, consenso vacío).
- **Objeto**: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (1.0.0-borrador, 3060 líneas). «L*n*» = línea de ese archivo al 2026-10-07.
- **Fecha**: 2026-10-07.
- **No es una revisión a ciegas, a propósito.** Leí primero la guía y después la convocatoria (`00-Convocatoria.md`) y los once informes del ciclo: requisitos, verificación-evidencia, lector-sin-contexto, didáctica, edición bibliográfica, senior-dotnet, arquitecto-software, desarrollador, AH-001, AH-002 y CAT-FORMAL.
- **Pregunta que respondo**: ¿lo que la guía recomienda es lo que hace la industria o una preferencia de la guía? ¿Qué premisa aceptó todo el panel sin ponerla a prueba?
- **Evidencia propia**: `evidencia-abogado-del-diablo/` en esta misma carpeta. Tiene cuatro experimentos con su script y su salida:
  - `nu1603/`: NuGet con y sin lock.
  - `editorconfig-checker/`: herramienta existente contra la compuerta propia.
  - `repos-de-referencia/`: relevamiento de seis repos .NET públicos.
  - `squash-y-blame/`: fusión con squash y `.git-blame-ignore-revs`.

  Corrieron en este host: Docker, `mcr.microsoft.com/dotnet/sdk:8.0` (SDK 8.0.425), `ghcr.io/editorconfig-checker/editorconfig-checker:4.0.2` y git 2.47.3. El laboratorio de la guía no se tocó.

## Qué ataco y qué no

La propuesta dominante de la guía tiene cuatro patas:

1. una política de texto por extensión con excepciones de BOM;
2. `* text=auto eol=lf`;
3. una compuerta propia;
4. «congelar» con un lock en cada ecosistema, `rollForward: disable` y digests en todo lo versionado, y cerrar con procedencia SLSA.

Ataqué las cuatro. Tres resistieron por partes; los detalles están en «Revisado y bien». Los hallazgos de abajo son los ataques que **no** resistieron. Ninguno dice que la guía esté equivocada en un hecho. Dicen que la guía presenta como **necesario** algo que es **una opción entre varias**, y que en algunos puntos esa opción no es la que eligen los repositorios de referencia del propio fabricante.

## Hallazgos

### abogado-diablo-01 · S2 · E1 + E4 + E2 — En .NET, el lock de NuGet se presenta como la condición del congelamiento. Para el caso es una opción con costos que la guía misma midió y no sumó

- **Ubicación**: §7 apertura, L1009 («Declarar una versión no congela nada. Lo que congela es un **lock file**…»); §7.6 P1, L1131; §7.7, L1152; §6.4 [criterio], L933; A.3 (`rollForward: disable`); A.4 (`RestorePackagesWithLockFile` para todo proyecto); §12 paso 6, L2177.
- **Propuesta atacada**: lock en .NET + `--locked-mode` en CI + `rollForward: disable` como cadena obligatoria.
- **Ancla**:
  1. **NuGet no es npm.** La propia guía dice que NuGet elige la versión **más baja** aplicable (§3.1, L245). La documentación de NuGet enumera los únicos tres escenarios en que el mismo `PackageReference` resuelve distinto:
     - versiones flotantes;
     - que la versión mínima pedida no exista y se publique después;
     - que una versión se borre del feed, «though nuget.org does not allow package deletions».

     Fuentes, consultadas el 2026-10-07: https://learn.microsoft.com/en-us/nuget/consume-packages/package-references-in-project-files, sección *Locking dependencies*; https://learn.microsoft.com/en-us/nuget/concepts/dependency-resolution, *Lowest applicable version*; https://learn.microsoft.com/en-us/nuget/nuget-org/policies/deleting-packages: «nuget.org does not support permanent deletion of packages».

     Los tres escenarios se cierran sin lock: no usar versiones flotantes, tratar `NU1603` como error y declarar el feed en el repo con mapeo de fuentes (eso la guía ya lo hace).
  2. **E1 propio** (`evidencia-abogado-del-diablo/nu1603/salida.txt`, SDK 8.0.425). Es el mismo `Directory.Packages.props` que E4-2, con `<WarningsAsErrors>$(WarningsAsErrors);NU1603</WarningsAsErrors>`:

     ```text
     == A: CPM + transitive pinning, SIN lock, NU1603 como error
     App.csproj : error NU1603: Warning As Error: App depends on Microsoft.Extensions.Primitives (>= 8.0.2) but Microsoft.Extensions.Primitives 8.0.2 was not found. An approximate best match of Microsoft.Extensions.Primitives 9.0.0 was resolved.
     restore rc=1
     == B: lo mismo CON lock (RestorePackagesWithLockFile), NU1603 como error, cache fria
       Restored App.csproj (in 892 ms).
     restore rc=0
     lock: {"type": "CentralTransitive", "requested": "[8.0.2, )", "resolved": "9.0.0", ...}
     ```

     Sin lock, la defensa barata **detiene** el caso de deriva que la guía usa para justificar el lock (E4-2). Con el lock activado, la misma defensa **no se dispara**: el restore sale con 0 y el lock congela la aproximación. Esto extiende lo que encontraron senior-dotnet-02 y verificacion-evidencia-01: el lock no sólo calla la advertencia, también desarma `NU1603` cuando se lo trata como error.
  3. **Costos que la guía ya midió y no suma en un solo lugar**:
     - otro SDK rompe el lock (E3-6, L883);
     - el RID entra al lock (E4-1, L1050);
     - de ahí sale `rollForward: disable` (L883, «Microsoft recomienda `rollForward: disable` cuando se usan lock files»), que bloquea cada estación con Visual Studio en cada actualización del IDE (senior-dotnet-03, lector-sin-contexto-04);
     - el lock en bibliotecas internas contradice la propia A.4 (senior-dotnet-04).
  4. **Práctica observada** (E1, `evidencia-abogado-del-diablo/repos-de-referencia/salida.txt`, 2026-10-07). La aplicación de referencia `dotnet/eShop` (main `dc7ea499cd35`) usa CPM y `rollForward: latestFeature`, y **no** versiona ningún `packages.lock.json`. Tampoco versionan locks de aplicación `dotnet/roslyn`, `dotnet/aspnetcore`, `dotnet/sdk` (sólo 4, dentro de `test/TestAssets`) ni `dotnet/msbuild`. En `dotnet/runtime` el árbol vino truncado y el conteo no vale.
- **Contra-tesis**: para una solución .NET cuyas dependencias vienen de nuget.org o de un feed que no permite sobrescribir versiones, el equivalente práctico es CPM con versiones existentes, sin flotantes, `NU1603` como error, `nuget.config` con `<clear />` y mapeo, y `rollForward: latestPatch` o `latestFeature` con el SDK registrado en CI (§9). Esa combinación no ata el grafo al parche del SDK ni al RID. El lock vale lo que cuesta cuando hay flotantes, cuando un feed privado admite re-publicar o cuando se necesita el `contentHash` contra la caché caliente (E4-3, el único beneficio exclusivo que la guía midió).
- **Impacto**: la guía empuja al lector a la opción más cara justo en el escenario donde más cuesta (ESC-01 con Visual Studio), y presenta como «versión pobre» lo que hace la aplicación de referencia del fabricante. Dos lectores con el mismo caso van a llegar a políticas distintas, y el que siga la guía al pie de la letra va a pagar `disable` sin necesitarlo.
- **Dirección**:
  - Reescribir L1009 como opción: «en npm y uv el lock es la norma del fabricante; en NuGet es *opt-in* y conviene cuando…».
  - Agregar a §7.6 P1 la alternativa sin lock con `NU1603` como error, citar el E1 de arriba y sumar el resultado al paso 5 de E4-2.
  - En §6.4, separar las dos políticas completas («con lock → `disable`, SDK exacto en cada estación»; «sin lock → `latestPatch`/`latestFeature` + registro») y no recomendar una por defecto sin decir el escenario.
  - En §12 paso 6, «lock por ecosistema» pasa a «lock en npm y uv; en NuGet, según el ADR».
- **Qué no ataco**: el lock en npm y uv. Ahí el fabricante lo pide explícitamente: el `package-lock.json` «is intended to be committed into source repositories» (https://docs.npmjs.com/cli/configuring-npm/package-lock-json) y el `uv.lock` «should be checked into version control» (https://docs.astral.sh/uv/concepts/projects/layout/), ambos consultados el 2026-10-07.
- **Confianza**: 0,8. El E1 es de un solo SDK (8.0.425); habría que repetirlo con 10.0.400.

### abogado-diablo-02 · S2 · E1 + E2 — La tabla de BOM por extensión dice derivarse del «lector más estricto», pero en los archivos de .NET ningún lector decide. Es convención, y la plantilla por defecto falla con `dotnet new console`

- **Ubicación**: §5.2.3, L645 («se toma por el lector más estricto de cada tipo de archivo») y filas L653–L656; [criterio] L661; §11.2.2, L1895 («la excepción no se decide por lenguaje sino por **quién lee ese archivo**»); A.1 (`[*] charset = utf-8`; `[*.{razor,cshtml,sln}] utf-8-bom`; `*.cs` y `*.csproj` sin BOM).
- **Propuesta atacada**: la tabla de cuatro tratamientos para la familia .NET:
  - `.cs`: cualquiera, declarado (en A.1, sin BOM);
  - `.razor`/`.cshtml`/`.sln`: con BOM;
  - `.csproj`/`.props`: sin BOM;
  - y la regla «repo nuevo → `.cs` sin BOM».
- **Ancla**:
  1. **Ningún lector de .NET decide.** Según la propia tabla de §4.2.4 (L456–L458), Roslyn y Razor leen bien UTF-8 con y sin BOM. Nada de la familia .NET falla por la presencia o ausencia de BOM. El criterio «el lector más estricto» sólo decide para `.sh`, `.json`, `.py`/`.toml` y `.ps1`; para el resto, la tabla elige por plantillas o por gusto.
  2. **Las plantillas no dan una convención.** La salida del propio laboratorio (`Examples/N2-…/salidas/e6-plantillas-dotnet.txt`) muestra que el SDK es inconsistente consigo mismo:
     - `dotnet new console`: `Program.cs con BOM` y `app.csproj con BOM`, en el SDK 8 y en el 10;
     - plantillas web: `.cs archivos=2 con BOM=0`, `.cshtml.cs archivos=3 con BOM=1`, `.csproj archivos=2 con BOM=0`.

     El argumento de L654 («pedir lo contrario obliga a corregir cada archivo nuevo») se aplica a `.razor`, pero no a `.cs` ni a `.csproj`. Con A.1 tal cual, un `dotnet new console` produce **dos** violaciones de entrada (`Program.cs` y `app.csproj` con BOM bajo `charset = utf-8`). El desarrollador tiene que quitar los BOM antes del primer commit: un commit cuyo único cambio es el BOM, justo lo que el caso pide no volver a tener (§1.1, pregunta 1).
  3. **Los repos del fabricante tampoco coinciden** (E1, `repos-de-referencia/salida.txt`, 2026-10-07):

     | Repo | `.cs` | `.csproj` | `.razor`/`.cshtml` |
     |---|---|---|---|
     | `dotnet/eShop` | `utf-8-bom` | — | — |
     | `dotnet/roslyn` | `utf-8-bom` | — | — |
     | `dotnet/aspnetcore` | `utf-8` (por `[*]`) | `utf-8` (por `[*]`) | `utf-8-bom` |
     | `dotnet/sdk` | — | **`utf-8-bom`** | — |
     | `dotnet/msbuild` | — | `utf-8` | — |
     | `dotnet/runtime` | — | `utf-8` | — |

     La fila `*.csproj … sin BOM` de la guía (L656) contradice a `dotnet/sdk`, el dueño de la CLI que la guía cita como motivo («La CLI no les agrega BOM al editarlos»).
  4. **La propia guía da el argumento de robustez a favor del BOM en `.cs`** y no lo usa al decidir:
     - con BOM, Roslyn lee UTF-8 «en cualquier plataforma y con cualquier configuración» (L154);
     - con `CodePage` presente, «sólo los archivos con BOM quedan a salvo» (L450).

     En un equipo donde la mitad trabaja en Windows con página ANSI 1252, esa es la protección por archivo que sobrevive a una configuración local. El otro argumento de L661, «EditorConfig desaconseja `utf-8-bom`» [B43], viene de la especificación de una herramienta genérica, no del ecosistema .NET.
- **Contra-tesis** **[criterio]**: dentro de la familia .NET, un **solo** tratamiento.
  - Para el caso: «todo lo que crea o edita el tooling de .NET (`.cs`, `.razor`, `.cshtml`, `.csproj`, `.props`, `.targets`, `.sln`) con BOM; todo lo demás sin BOM».
  - O, si se prefiere, todo sin BOM salvo `.razor`/`.cshtml`/`.sln`, pero declarando que es preferencia y que exige corregir cada `dotnet new console`.

  La regla de una línea se recuerda, se explica y coincide con la elección de eShop y Roslyn para `.cs`. Además deja de depender de la rama «heredado ya convertido» (variante B), que lector-sin-contexto-05 ya encontró incompleta.
- **Impacto**: el PO preguntó cómo se mantiene «un criterio de codificación unificado». La guía responde con cuatro tratamientos para archivos que leen las mismas herramientas, y su plantilla por defecto falla con el primer proyecto que se crea con la CLI.
- **Dirección**:
  - En §5.2.3, separar las filas en dos grupos: «lo decide un lector» (`.sh`, `.json`, `.py`/`.toml`, `.ps1`, `.cmd`) y «es convención del equipo» (familia .NET).
  - Para el segundo grupo, ofrecer las dos opciones con sus costos: plantillas que hay que corregir y robustez ante `CodePage`/ANSI.
  - Corregir la justificación de `*.csproj` con la salida de E2-6.
  - Agregar a EA-1 un `dotnet new console` dentro del repo de plantillas, con la compuerta corriendo.
- **Confianza**: 0,8.

### abogado-diablo-03 · S2 · E1 — La compuerta de texto es un desarrollo propio. Existe una herramienta mantenida que detecta las mismas violaciones, y la guía no la menciona

- **Ubicación**: §5.2.5, L671–L683 (tabla «Herramienta existente»); §10.2.2, L1657–L1667; A.11; B.1. Búsqueda: `grep -n -i 'editorconfig-checker' Metodologia-Entorno-Desarrollo-Guide.md` → sin resultados.
- **Propuesta atacada**: `check_text_policy.py` como pieza central de la compuerta, y la tabla de §5.2.5, que compara sólo contra `dotnet format`, `pre-commit-hooks` y `git ls-files --eol`.
- **Ancla**:
  1. **E1 propio** (`evidencia-abogado-del-diablo/editorconfig-checker/experimento.sh` y `salida.txt`). editorconfig-checker 4.0.2 corrió contra el mismo `.editorconfig` de §5.5 y siete archivos sintéticos:

     ```text
     ConBom.cs:     wrong character encoding ("UTF-8-SIG" instead of "utf-8")
     Cp1252.cs:     wrong character encoding ("ISO-8859-1" instead of "utf-8")
     SinBom.razor:  wrong character encoding ("UTF-8" instead of "utf-8-bom")
     conbom.json:   wrong character encoding ("UTF-8-SIG" instead of "utf-8")
     crlf.sh:       not all lines have the correct end of line character
     6 errors found
     rc=1
     ```

     Detecta las tres clases que verifica `check_text_policy.py` (L673–L675): no UTF-8, BOM distinto del `charset` resuelto y CRLF. Los dos archivos válidos (`Utf8.cs`, `ConBom.razor`) no se reportan.
  2. **Distribución.** La última versión es la v4.0.2, publicada el 2026-09-19 (https://github.com/editorconfig-checker/editorconfig-checker/releases, consultado el 2026-10-07). Hay binarios para `windows-amd64`, `windows-386` y `windows-arm64`, paquetes en npm y PyPI, imagen de contenedor y un hook de pre-commit (`editorconfig-checker.python/.pre-commit-hooks.yaml`). Una estación Windows lo instala sin Python ni bash. Para `.cs`, `dotnet format whitespace --verify-no-changes` viene con el SDK y ya hace cumplir `charset` (E2-6).
  3. **El panel tropezó cuatro veces con el mantenimiento de la compuerta propia, sin preguntarse si tenía que existir**:
     - AS-01: la compuerta no ve los proyectos que están fuera de la raíz;
     - lector-sin-contexto-02: el hook exige `python3` + `EditorConfig==0.17.1` en Windows y rechaza commits válidos;
     - lector-sin-contexto-03: el esqueleto de A.11 acepta cualquier cosa;
     - AS-03: «compuerta única» designa dos programas distintos.

     Son síntomas de un programa a medida que cada equipo va a tener que portar y mantener.
- **Límites de la herramienta, para no sobrevender la contra-tesis**:
  - Revisa el **working tree**, no el índice. En CI, con un clon limpio, da lo mismo; en el hook, el framework pre-commit guarda aparte lo que no está en stage, pero eso no se verificó acá.
  - Su detector puede confundir `windows-1252` con `iso-8859-1` (lo dice su README, sección *Charset Setting*). Para la compuerta eso da igual: lo que importa es «no es UTF-8».
  - No da el diagnóstico «¿cp1252?» que sí da la compuerta propia.
- **Contra-tesis** **[criterio]**: la capa de texto de la compuerta se arma con herramientas existentes y versionadas: editorconfig-checker para todo el árbol, `dotnet format whitespace --verify-no-changes` para `.cs`, y `git ls-files --eol` como diagnóstico. El script propio queda como **ejemplo didáctico** de qué hay que verificar, no como pieza que se copia. Se mantiene igual la regla «una sola compuerta en hook y CI» (§10.2.2): lo que cambia es qué se ejecuta adentro.
- **Impacto**: la guía le pide a cada equipo mantener un verificador en Python con una dependencia de PyPI fijada, y en ESC-01 ese requisito no está declarado (lector-sin-contexto-02). La adopción del paso 4 de §12, el que «impide que el problema del caso vuelva», depende de esa pieza.
- **Dirección**:
  - Agregar editorconfig-checker a la tabla de §5.2.5 con la fuente oficial y el E1 de arriba (sumarlo a E2-3 o a EA-1).
  - Reescribir §10.2.2, paso «texto», con la herramienta existente como opción por defecto y `check_text_policy.py` como alternativa cuando haga falta verificar el índice exacto.
  - En B.1, el prerrequisito de la estación pasa a ser un binario, no Python.
- **Confianza**: 0,75.

### abogado-diablo-04 · S2 · E4 + E2 — «Digest en todo lo versionado», incluido el devcontainer, es una política que la guía misma juzga peor que la etiqueta cuando no hay quién proponga el digest nuevo. En el escenario del caso, ese quién no existe para el devcontainer

- **Ubicación**: §8.2.2, L1227–L1234 («**Digest en todo lo versionado** … `image` del devcontainer»; «Un equipo que fija digests y no tiene el punto 2 está peor que uno que usa etiquetas: congeló vulnerabilidades»); §3.6 ESC-04, L361; §8.7, L1363; A.9; A.13; §12 paso 7, L2178.
- **Propuesta atacada**: el digest como regla también para el entorno de **desarrollo**.
- **Ancla**:
  1. **El caso es un repositorio privado de una organización** (§1.1). En la tabla oficial de Dependabot, `devcontainers` figura con «Private repositories: Not supported». Además, ese ecosistema actualiza las *features* de `devcontainer.json`, no su `image` («This updater ensures Features are pinned to the latest `major` version»). El ecosistema `docker` documenta Dockerfiles y manifiestos de Kubernetes, y no menciona `devcontainer.json`. Fuente: https://docs.github.com/en/code-security/dependabot/ecosystems-supported-by-dependabot/supported-ecosystems-and-repositories, consultado el 2026-10-07. A.9 fija la `image` por digest, y A.13 no tiene ningún ecosistema que la proponga (AH-002-03 encontró la omisión de `docker`; ni agregándolo se cubre la `image` de A.9).
  2. **El publicador de las imágenes de devcontainer recomienda fijar por etiqueta semántica**, no por digest. El README de `devcontainers/dotnet` ofrece:
     - `8.0-bookworm` «to pin to an OS version»;
     - `2.3.0-10.0-noble` como versión semántica de la imagen;
     - el digest sólo para las imágenes `dev-*` que «may be updated in place».

     Fuente: https://github.com/devcontainers/images/blob/main/src/dotnet/README.md, consultado el 2026-10-07.
  3. **La propia guía dice qué alcanza para el devcontainer.** §8.6 P3 (L1349): la etiqueta fija «garantiza la versión de .NET… "mismo SDK" (alcanza) o "misma imagen" (no)». §8.2.4 regla 3 (L1264) acepta que el SO y el hash del binario no van a ser idénticos entre estaciones, y §2.4 (L220) dice que una build local «no demuestra nada». Para desarrollar, el objetivo es «mismo SDK», que también verifica `global.json` (E5-6).
- **Contra-tesis** **[criterio]**: digest donde se construye lo que se publica (CI, Dockerfile de build, con Dependabot `docker` o Renovate `pinDigests`, que sí cubren repos privados). En el devcontainer, una etiqueta **fija** de SDK y SO (`sdk:8.0.425-bookworm-slim` o la versión semántica de `devcontainers/dotnet`), más `global.json`, que detecta la deriva de capa 2. Si se quiere digest también ahí, el devcontainer usa `build.dockerfile` con `FROM …@sha256`, para que el bot de `docker` lo vea.
- **Impacto**: un equipo que adopte A.9 y A.13 tal cual queda en el estado que §8.2.2 llama «peor que etiquetas»: un SO de desarrollo que no recibe parches hasta que alguien se acuerde de él.
- **Dirección**:
  - En §8.2.2, punto 1, separar «imagen que construye artefactos publicados» (digest + bot obligatorio) de «imagen de desarrollo» (etiqueta fija o digest sólo si hay un bot que la cubra).
  - En A.9, mostrar la variante `build.dockerfile`, o la etiqueta fija con la pregunta «¿hay un bot que actualice este digest en un repo privado?».
  - En §3.6 ESC-04 y en §8.7, la misma condición.
- **Confianza**: 0,75.

### abogado-diablo-05 · S3 · E1 + E2 — `* text=auto eol=lf` se justifica con la igualdad del binario entre máquinas, que la guía misma descarta para las estaciones; los seis repos de referencia del fabricante usan `* text=auto` sin `eol`

- **Ubicación**: §5.2.2, L641 («**[criterio]** … la segunda. No es estética: el fin de línea **entra en el binario** … el mismo commit produce dos programas según la máquina que lo materializó»); A.2 (pregunta: «¿el disco tiene que tener LF en todas las máquinas (sí, si se construye en Windows y Linux)?»); §4.2.5, L479.
- **Propuesta atacada**: LF en el disco de todas las estaciones como condición para un equipo Windows + Linux.
- **Ancla**:
  1. **La pregunta 1 del caso se resuelve igual con `* text=auto`.** Esa pregunta es evitar commits de BOM o de EOL (§1.1). Con `* text=auto`, el **índice** queda en LF en cualquier máquina [B36], y E2-1 lo verifica. Lo que agrega `eol=lf` es LF en el **disco** de Windows. No cambia lo que se commitea.
  2. **El argumento del binario choca con la propia guía**:
     - §2.4, L220: «Una build local es útil para trabajar, no para demostrar nada»;
     - §8.2.4 regla 3, L1264: entre ESC-01 y ESC-04 «el hash de los binarios» no va a ser idéntico;
     - §8.2.4 regla 5, L1266: lo que se publica sale de la CI, que clona limpio en Linux (LF).

     Que el binario de la estación Windows difiera no afecta a ningún artefacto publicado. El argumento que sí sostiene `eol=lf` es otro, y la guía no lo usa: que una **prueba** con un literal verbatim multilínea dé lo mismo en la estación y en la CI.
  3. **Práctica observada** (E1, `repos-de-referencia/salida.txt`, 2026-10-07): `dotnet/eShop`, `dotnet/roslyn`, `dotnet/aspnetcore`, `dotnet/runtime`, `dotnet/sdk` y `dotnet/msbuild` declaran `* text=auto` **sin** `eol` global, con `eol=lf` sólo para `.sh` (y `eol=crlf` para `.cmd`/`.bat`/`.sln` en runtime y sdk). Son proyectos que se desarrollan y prueban en Windows y en Linux a la vez, que es el escenario del caso.
- **Contra-tesis**: las dos políticas son defendibles (la guía lo reconoce en L636), pero el criterio para elegir tiene que ser el correcto:
  - `eol=lf` si el equipo tiene literales multilínea cuyo contenido importa en las pruebas, o herramientas de Windows que se confunden con LF;
  - `* text=auto` (lo que hace el fabricante) si no, con `eol` explícito para `.sh`/`.cmd`/`.bat`.

  Con cualquiera de las dos, el índice queda en LF y no hay commits de EOL.
- **Impacto**: moderado. El lector adopta `eol=lf` por un motivo que la guía después invalida. El costo en Windows (LF en el disco de Visual Studio) está rotulado **[no verificado en Windows]** (L641), así que el lector no puede pesarlo.
- **Dirección**:
  - Reemplazar en L641 el argumento «dos binarios» por «la misma prueba da distinto en la estación y en la CI cuando hay literales multilínea».
  - Presentar `* text=auto` como opción válida, con la práctica de los repos del fabricante como dato fechado.
  - Ajustar la pregunta de A.2 a «¿hay literales o datos cuyo fin de línea importe en la estación?».
- **Confianza**: 0,7.

### abogado-diablo-06 · S3 · E2 — Para la tercera pregunta del caso, la guía dice que alcanza con un registro del entorno, y su hoja de ruta igual escala a procedencia SLSA firmada, que el panel probó que no contesta esa pregunta

- **Ubicación**: §3.4, L318 («Saber con qué se construyó una pieza ya publicada | Registro del entorno por capa, grabado por la CI | Alcanza con poder reconstruir el entorno»); §9.4 ESC-05, L1518 («**Todo**: … SBOM, procedencia, firma…»); §9.6, L1570 («L1 de inmediato»); §12 paso 8, L2179; §9.7.
- **Propuesta atacada**: procedencia firmada como parte de la respuesta estándar al caso (un repositorio **privado**, un equipo chico, artefactos internos).
- **Ancla**:
  1. La propia guía separa las dos necesidades en §3.4. Para «con qué se construyó», alcanza con el registro del entorno. La procedencia firmada corresponde a otra necesidad, «demostrar [a un tercero] que un binario sale de un commit dado» (L319). El caso no menciona ese tercero (§1.1).
  2. El panel ya mostró que el camino firmado **no lleva** el entorno:
     - la atestación de la plataforma exige sólo el commit en `resolvedDependencies` (AS-02);
     - la procedencia de BuildKit, que sí nombra las imágenes por digest, sale con `builder.id` vacío y no llega a L1 (AH-002-01, sobre la salida de E6-5);
     - las atestaciones nativas de GitHub no existen para repos privados fuera de Enterprise Cloud (L1490).

     Para el caso, entonces, el camino firmado cuesta más y contesta otra pregunta.
  3. La compuerta ya emite «una línea por paso … que sirve a la vez de registro de entorno para §9» (L1667). Con el digest de la imagen, el SDK efectivo y el hash de los locks junto al artefacto, la pregunta 3 del caso queda respondida sin firma.
- **Contra-tesis** **[criterio]**: partir el paso 8 de §12:
  - **8a**, para todo equipo: el registro del entorno (los seis metadatos de §9.6 P1 sin el punto «quién lo firma») y el SBOM;
  - **8b**, condicionado a un consumidor externo, un requisito contractual o un repo público: procedencia firmada y el nivel SLSA alcanzado.
- **Impacto**: el lector del caso percibe que sin SLSA no contestó la tercera pregunta, y gasta en firma y procedencia (cosign, claves, planes de GitHub) lo que no le da el dato que buscaba.
- **Dirección**:
  - Reescribir §12 paso 8 como 8a/8b.
  - En §9.4 ESC-05, cambiar «Todo» por «registro y SBOM siempre; procedencia firmada si hay un consumidor que la verifique».
  - En §9.6 P4, condicionar «L1 de inmediato» a lo que AH-002-01 pide corregir.
- **Confianza**: 0,7.

### abogado-diablo-07 · S3 · E1 — «PR de migración fusionado con squash» figura como señal de versión pobre, pero el squash es compatible con `.git-blame-ignore-revs` si el SHA se agrega después de fusionar

- **Ubicación**: §5.2.6, diagrama L701 («fusionar con merge commit: el SHA tiene que sobrevivir»); paso 6, L720 («el PR de migración se fusiona con merge commit **[criterio]**»); §5.6, L805 («fusión sin squash»); §5.7, L821 (señal pobre: «el PR de migración fusionado con squash»); A.15, L2597–L2598.
- **Propuesta atacada**: imponer una estrategia de fusión a la organización como condición de la migración.
- **Ancla**: E1 propio (`evidencia-abogado-del-diablo/squash-y-blame/experimento.sh` y `salida.txt`, git 2.47.3). La rama de migración tiene dos commits y se aplasta en `main`; después, en un commit aparte, se agrega el SHA **del squash**:

  ```text
  -- blame sin ignore-revs
     65113ddf 3)     int Leer() => 42; // Atención        ← todo atribuido al squash del migrador
  -- blame con ignore-revs del SHA del squash
     ^ba10b48 (autora 2026-10-07 … 3)     int Leer() => 42; // Atención   ← vuelve a la autora
  ```

  El requisito real es que el SHA que se lista sea el que quedó en `main`, y A.15 ya lo dice («con el SHA definitivo tras fusionar»). Lo que el squash sí rompe es juntar en un mismo PR la política, la migración y el `.git-blame-ignore-revs`: el squash los aplasta en un solo commit, y la verificación mecánica (`verificar-commit-mecanico.sh`) deja de aplicarse a un commit sólo mecánico.
- **Contra-tesis**: tres PR (política → migración → `.git-blame-ignore-revs` con el SHA de `main`) funcionan con cualquier estrategia de fusión, incluido el squash, que muchas organizaciones dejan como única opción habilitada. El merge commit es una alternativa, no un requisito.
- **Impacto**: moderado. En una organización con squash obligatorio, el lector o no migra, o pide una excepción de configuración que la guía no necesitaba exigir.
- **Dirección**:
  - En §5.2.6 y en el diagrama, «un PR por commit (sirve cualquier estrategia) o un PR con merge commit».
  - Quitar «fusionado con squash» de las señales pobres de §5.7 y reemplazarlo por «el `.git-blame-ignore-revs` con un SHA que no está en `main`».
  - Agregar el E1 de arriba a E2-2.
- **Confianza**: 0,85.

## Consensos sospechosos

El marco (§9) pide señalar dónde el panel convergió sin poner a prueba la premisa. Estos consensos no son hallazgos nuevos: explican por qué los de arriba no aparecieron en ningún informe.

| # | Consenso | Quiénes lo comparten | Por qué es sospechoso | Hallazgo |
|---|---|---|---|---|
| CS-1 | «En .NET hay que tener lock» | senior-dotnet-02, -03 y -04; verificacion-evidencia-01; lector-sin-contexto-04 | Cinco hallazgos corrigen **síntomas** de la premisa (NU1603 silenciado, `disable` que bloquea, lock en bibliotecas) y proponen reformular la frase. Ninguno pregunta si el lock hace falta en NuGet. | 01 |
| CS-2 | «La compuerta es un script propio» | AS-01, AS-03, lector-sin-contexto-02 y -03, desarrollador (EA-1) | Cuatro informes reparan la mecánica del script (rutas, dependencias, esqueleto, dos programas) y ninguno busca la herramienta existente. | 03 |
| CS-3 | «La tabla de BOM se deriva del lector» | todos; lector-sin-contexto-05 pide **agregar** una rama | Nadie contrastó la tabla con la salida de E2-6, que ya estaba en el laboratorio, ni con los repos del fabricante. | 02 |
| CS-4 | «SLSA es parte de la respuesta» | AH-002 (5 hallazgos), AS-02, arquitecto («Revisado y bien» §9.2.4) | Afinan niveles y firmas sin preguntar si el caso lo necesita. | 06 |
| CS-5 | «Qué propone la industria» = qué documenta el fabricante | verificacion-evidencia (24 afirmaciones re-consultadas, todas contra documentación) | Ningún informe contrastó las **recomendaciones** contra la práctica observada. El relevamiento de seis repos `dotnet/*` mostró que tres decisiones de la guía no coinciden con la práctica del fabricante: `eol=lf` (0 de 6), lock de NuGet (0 de 5 legibles) y `rollForward: disable` (0 de 6; eShop usa `latestFeature`, Roslyn `patch`, sdk `latestFeature`, runtime `major`). **Límite del dato**: son repos de Microsoft con infraestructura propia (Arcade, SDK bajado por script); el único análogo cercano al caso es eShop, y seis repos no son «la industria». Lo que el dato prueba es que esas elecciones son **preferencias** defendibles, no la práctica dominante del ecosistema. | 01, 02, 05 |
| CS-6 | Panel sin voz de ESC-01 | convocatoria §5 (Windows/VS no instanciado, 3–2) | Las recomendaciones que más cuestan en Windows (`disable`, `eol=lf`, hook con Python, `.cs` sin BOM) las evaluó un panel que sólo ejecutó en Linux. | solicitud abajo |

## Revisado y bien: ataques que la guía resistió

1. **«¿Contenedor siempre?»** La guía no cae en eso. El devcontainer es una comodidad, la CI arbitra y la política vive en el repo (§8.2.4, reglas 1–5). La base es el hallazgo negativo documentado de que Visual Studio no desarrolla .NET dentro de un devcontainer, y E5-1, que muestra que el cp1252 falla igual adentro. Ataqué la idea de que el contenedor resuelve el caso y la guía ya la refuta con evidencia propia.
2. **«¿Lock siempre?» en npm y uv.** Ahí la guía coincide con el fabricante: npm («intended to be committed», docs.npmjs.com) y uv («should be checked into version control», docs.astral.sh), consultados el 2026-10-07. La distinción entre la restauración estricta y la que reescribe el lock en silencio (§7.3) es exacta. El ataque sólo prospera en NuGet (hallazgo 01).
3. **«¿UTF-8 sin BOM es preferencia de Linux?»** No en lo que la guía decide por lector: `.sh`, `JSON.parse`/`json.load`/`tomllib` y Windows PowerShell 5.1 están medidos en E1-11, E2-5 y E8-1, y en esos casos la regla es necesaria. El ataque prospera sólo en la familia .NET (hallazgo 02).

## Solicitudes de convocatoria

- **Especialista en estaciones Windows / Visual Studio** (cola priorizada #1 de la convocatoria, §5). Señal: tres de mis siete hallazgos (01, 02, 05) y CS-6 dependen de comportamientos de ESC-01 que el panel no pudo ejecutar:
  - si Visual Studio, en una estación con página ANSI 1252, guarda o reinterpreta un `.cs` UTF-8 sin BOM, que es el origen probable del cp1252 del caso; ninguna fila de §4.2.6 explica quién escribió cp1252;
  - el costo de LF en el disco de Visual Studio;
  - el costo operativo de `rollForward: disable` con las actualizaciones mensuales del IDE.

  Lo pidieron también lector-sin-contexto y desarrollador. Si no hay host Windows, el especialista puede al menos contrastar la documentación de Visual Studio (la detección de UTF-8 sin firma, que este informe no verificó, y *Save with Encoding* [B45]) y dejar cada punto rotulado.
