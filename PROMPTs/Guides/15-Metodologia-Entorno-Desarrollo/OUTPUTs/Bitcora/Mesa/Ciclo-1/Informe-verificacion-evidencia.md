# Informe de Verificación / QA: evidencia, ciclo 1

- **Rol:** Verificación/QA (núcleo permanente). La pregunta que respondo: ¿cada afirmación técnica tiene evidencia verificable y vigente?
- **Objeto:** `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (1.0.0-borrador, 3060 líneas) y su laboratorio `Examples/`.
- **Fecha:** 2026-10-07. Revisé a ciegas: no leí los informes de los otros especialistas de este ciclo.
- **Método:** tomé 24 afirmaciones de riesgo (versiones, estados, defaults, fechas y comportamientos citados a fuentes) y volví a consultar sus fuentes primarias. Corrí 4 experimentos del laboratorio sobre una copia en el scratchpad, sin escribir en `Examples/`, y uno adicional que armé para contrastar una generalización.

## 1. Muestra de afirmaciones re-consultadas (2026-10-07)

| # | Afirmación de la guía (ubicación) | Fuente re-consultada | Resultado |
|---|---|---|---|
| 1 | Python 3.15.0 final prevista para el 2026-10-09; al 2026-10-07 ninguna estable trae el modo UTF-8 (§4.3, l. 500) | peps.python.org/pep-0790: «3.15.0 final: Friday, 2026-10-09»; python.org API: la última publicada es 3.15.0rc3 | Confirmada |
| 2 | EditorConfig 0.17.2: «Use of `utf-8-bom` is discouraged»; un `#` después de un valor forma parte del valor (§4.3, §5.2.4) | spec.editorconfig.org | Confirmada, con cita literal |
| 3 | `engines` sólo advierte salvo `engine-strict`; en `devEngines`, `onFail` vale `error` por defecto y se evalúa antes de `install`, `ci` y `run` (§6.2.3) | docs.npmjs.com/cli/v11/configuring-npm/package-json | Confirmada |
| 4 | Corepack deja de distribuirse desde Node 25.0.0 (§6.2.3) | nodejs.org/en/blog/release/v25.0.0: «(SEMVER-MAJOR) build: stop distributing Corepack» (#57617) | Confirmada |
| 5 | Estado de las líneas: v26 *Current*, v24 y v22 LTS, v20 EOL; desde Node 27 el ciclo es anual y todas las mayores pasan a LTS (§6.2.3) | nodejs.org/en/about/previous-releases | Confirmada |
| 6 | SLSA v1.2 aprobada y v1.1 retirada (B05) | slsa.dev/spec/v1.2 «Status: Approved»; /v1.1 y /v1.0 «Status: Retired» | Confirmada |
| 7 | La tabla de Dependabot llega a npm ≤ v11, pnpm ≤ v10 y uv v0.11; lo vigente es npm 12, pnpm 12 y uv 0.12 (§7.3) | docs.github.com (tabla de ecosistemas); registry.npmjs.org: npm 12.2.0, pnpm 12.10.1; PyPI: uv 0.12.23 | Confirmada |
| 8 | npm 12 ya no lee ni escribe `npm-shrinkwrap.json` (§7.2.2) | docs.npmjs.com/cli/v12/…/package-lock-json | Confirmada, con cita literal |
| 9 | pip 26.2.1: `pip lock` es experimental y su lock vale sólo para la plataforma actual (§7.2.3) | pip.pypa.io/en/stable/cli/pip_lock | Confirmada |
| 10 | PEP 751 está *Final*, con resolución del 2025-03-31 (§7.2.3) | peps.python.org/pep-0751 | Confirmada |
| 11 | Desde .NET 11 los paquetes NuGet son deterministas por defecto (§7.5) | learn.microsoft.com/…/deterministic-packages: «Starting in .NET 11, NuGet packages are deterministic … by default» (la salvedad son las marcas de tiempo) | Confirmada |
| 12 | VS mínimo por banda: 10.0.100 → 17.14; 10.0.2xx a 4xx → 18.0; se recomienda `dotnet build` antes que `msbuild` (§6.2.2, §6.3) | learn.microsoft.com/…/versioning-sdk-msbuild-vs | Confirmada |
| 13 | `paths` y `errorMessage` existen desde el SDK 10; `patch` es el default; Microsoft recomienda `rollForward: disable` con lock files (§6.2.2) | learn.microsoft.com/…/global-json, nota †: «When you use package lock files, set `rollForward` to `disable`…» | Confirmada |
| 14 | `CheckSdkVulnerabilities=true`; sin `global.json` se usa el SDK más alto; el runtime hace *roll forward* con `Minor` por defecto (§6.2.2, §6.3) | learn.microsoft.com/…/versions/selection | Confirmada |
| 15 | La documentación de `CodePage` dice «first attempts to interpret all source files as UTF-8» (§4.2.3) | learn.microsoft.com/…/compiler-options/advanced | Confirmada, y E1-01 la contradice como dice la guía |
| 16 | `GetEncoding(0)` devuelve UTF-8 fuera de Windows (§4.1) | learn.microsoft.com/…/codepagesencodingprovider.getencoding: «On non-Windows platforms: Returns null, allowing GetEncoding(Int32) to fall back to its default UTF-8» | Confirmada |
| 17 | Roslyn PR #83320 (abril de 2026) e issue #81381 / PR #81382 (noviembre de 2025) (§4.2.1, §4.2.3) | api.github.com: #83320 fusionado el 2026-04-24; #81382 fusionado el 2025-11-26 | Las fechas se confirman; el **sentido** de #83320 se describe mal (hallazgo 03) |
| 18 | BuildKit v0.28.0 cambió el default de procedencia a SLSA v1, mientras la página de Docker sigue diciendo v0.2 (§9.2) | notas de la release v0.28.0 (#6526); docs.docker.com/…/slsa-provenance: «`version=v0.2` (default)» | Confirmada; la guía declara bien la discrepancia |
| 19 | El almacén de containerd es el predeterminado en instalaciones nuevas de Docker Engine 29 (§9.2) | docs.docker.com/engine/storage/containerd | Confirmada |
| 20 | Atestaciones de GitHub: L2 por sí solas y L3 con *reusable workflows*; en Free, Pro y Team sólo para repos públicos (§9.2) | docs.github.com (concepto) y reusable `gated-features/attestations.md` | Confirmada |
| 21 | Ramas protegidas y CODEOWNERS en privados sólo con Pro, Team o Enterprise; los `pre-receive` de GHES tienen un presupuesto conjunto de 5 s (§10.2) | reusables `gated-features/protected-branches.md` y `code-owners.md`; GHES 3.22: «all combined pre-receive hooks should run in under five seconds» | Confirmada |
| 22 | `actions/checkout` v7.0.1 → `3d3c42e5…` (B193) | `git ls-remote --tags`: `3d3c42e5aac5ba805825da76410c181273ba90b1 refs/tags/v7.0.1` | Confirmada |
| 23 | SPDX 3.0.1 con estatus «ISO/IEC 5962:2021» (§9.2, tabla de formatos) | ISO/IEC 5962:2021 es «SPDX® Specification V2.2.1» (catálogos de IEC/SCC) | **No se sostiene** (hallazgo 02) |
| 24 | CycloneDX 1.7 del 2025-10-21; ECMA-424; .NET 10.0.401 vigente; .NET 8 y 9 sin soporte desde el 2026-11-10; pre-commit 4.6.2; CISA 2026 (PDF, 2026-07-29); git 2.56.0; Unicode 18.0; la receta con llaves de la documentación de VS Code | cyclonedx.org; `releases-index.json`; PyPI; HTTP 200 en las URL de CISA y Unicode; git-scm.com; code.visualstudio.com (la receta `*.{cmd,[cC][mM][dD]} text eol=crlf` es literal) | Confirmada |

## 2. Experimentos corridos

Todos sobre copias en el scratchpad; el laboratorio no se tocó.

| Experimento | Comando | Resultado frente a la guía |
|---|---|---|
| E1-01 Roslyn | `docker run … mcr.microsoft.com/dotnet/sdk:8.0 sh e1-roslyn.sh` (SDK 8.0.425) | Idéntico a §1.2 y §4.2.3: `U+ : FFFD 006E 003A`; `error CS1056: Unexpected character '�'`; con `-p:CodePage=1252`, UTF-8 sin BOM da `AtenciÃ³n` y con BOM queda correcto; la consola ISO-8859-1 muestra `Atenci?n`. En esta corrida `CodePage=1252` compiló sin `CS2016`, lo que es compatible con el «según el estado del servidor» de §4.2.3 |
| E1-11 shebang | `docker run … python:3.12-slim sh e1-shebang.sh` | Idéntico a §4.2.4: con BOM, dash y bash muestran `not found` / `No such file or directory`, imprimen `hola` y salen con 0, mientras `subprocess` da `OSError 8 Exec format error`; con CRLF, salida 127 y `FileNotFoundError 2` |
| E5-7 llaves en `.gitattributes` | `bash experimento.sh` (host con git 2.47.3; contenedor con git 2.39.5) | Idéntico a §5.2.4: `*.{cmd,bat}` y la receta de VS Code dejan `eol: lf` en `a.cmd`, `b.BAT` y `c.bat`; con un patrón por extensión queda `eol: crlf` |
| E4-2 CPM (paso 5) | `docker run … sdk:8.0 bash run.sh` | Se reproduce: `"type": "CentralTransitive", "requested": "[8.0.2, )", "resolved": "9.0.0"` y 0 advertencias `NU` |
| Contraste propio de E4-2 | el mismo paquete como `PackageReference` **directa**, sin CPM: `<PackageReference Include="Microsoft.Extensions.Primitives" Version="8.0.2" />` | `warning NU1603: App depends on Microsoft.Extensions.Primitives (>= 8.0.2) but Microsoft.Extensions.Primitives 8.0.2 was not found. An approximate best match of Microsoft.Extensions.Primitives 9.0.0 was resolved.` La guía generaliza a partir del caso transitivo (hallazgo 01) |

## 3. Hallazgos

### verificacion-evidencia-01: «NuGet resuelve la siguiente sin advertencia» vale sólo para la transitiva fijada con CPM

- **Ubicación:** §7.2.1, l. 1048 («si la versión pedida no existe, NuGet resuelve la siguiente disponible **sin advertencia**»); repetido en §3.7, l. 381 («entregando 9.0.0 sin advertir») y en §7.2.1, l. 1052.
- **Nivel:** E1. **Severidad:** S3.
- **Ancla:** E4-2, paso 5 (`CentralTransitive`, `[8.0.2, )` → `9.0.0`, 0 advertencias). El contraste con una referencia directa da `warning NU1603: … 8.0.2 was not found. An approximate best match of … 9.0.0 was resolved.` (SDK 8.0.425, nuget.org, 2026-10-07).
- **Impacto:** el lector concluye que NuGet nunca avisa cuando aproxima. Así se pierde una defensa barata que la guía no menciona: tratar `NU1603` como error en la CI (`WarningsAsErrors`). El argumento a favor del lock sigue en pie, pero descansa en una generalización que el experimento no sostiene.
- **Dirección:** acotar la frase al caso medido («una versión fijada de forma central para una **transitiva**, con *transitive pinning*, se aproxima sin advertencia; una referencia directa emite `NU1603`»), agregar el contraste a E4-2 con su salida versionada y, como **[criterio]**, sugerir `NU1603` en `WarningsAsErrors` dentro de la condición de CI de A.4.

### verificacion-evidencia-02: SPDX 3.0.1 aparece con el estatus ISO/IEC 5962:2021, que corresponde a la versión 2.2.1

- **Ubicación:** §9.2, tabla de formatos (l. 1459: «| SPDX | 3.0.1 [B155] | ISO/IEC 5962:2021 [B155] |»); la fila B155 del Anexo D lo repite.
- **Nivel:** E2. **Severidad:** S3.
- **Ancla:** la guía, l. 1459, citada arriba. Del lado de la norma, ISO/IEC 5962:2021 se titula «Information technology — SPDX® Specification V2.2.1» (Edición 1.0, 2021-08-24; catálogos de IEC y SCC). La propia spdx.dev/use/specifications sólo dice «an international open standard (ISO/IEC 5962:2021)», sin versión.
- **Impacto:** el lector cree que la versión vigente es la normalizada por ISO. Es justo el tipo de dato que un consumidor exige en un contrato de SBOM.
- **Dirección:** separar las dos cosas. Versión vigente: 3.0.1. Estatus ISO: «ISO/IEC 5962:2021 = SPDX 2.2.1». Agregar la fuente del catálogo ISO o IEC y fecha de consulta.

### verificacion-evidencia-03: B15 se presenta como la fijación de un comportamiento, pero es el arreglo de una regresión y su prueba contradice la rama «Windows con ACP UTF-8»

- **Ubicación:** §4.2.1, l. 415 («El equipo del compilador fijó ese comportamiento en una prueba en abril de 2026»); §2.1, l. 180; el diagrama de §4.2.1 (rama «Linux / macOS (o Windows con ACP UTF-8)»); l. 442 («con la opción beta de UTF-8 activada, una estación Windows se comportaría como Linux»); §4.1, l. 404.
- **Nivel:** E2. **Severidad:** S3.
- **Ancla:** dotnet/roslyn PR #83320, titulado «Fix regression in CreateFallbackEncoding». La descripción dice que #82159 hizo que `GetEncoding(0)` devolviera UTF-8 «silently», y la prueba agregada afirma, para Windows: «registering CodePagesEncodingProvider makes GetEncoding(0) return the real ANSI code page (e.g., 1252) **even when the UTF-8 locale setting is enabled**» (`Assert.NotEqual(Encoding.UTF8.CodePage, fallback.CodePage)`). La regresión (#82159) se fusionó en `main` el 2026-02-10 y el arreglo tiene *milestone* 18.7.
- **Impacto:** (a) la deducción rotulada **[no verificado]** se apoya en B14, B19 y B22, mientras B15, que la guía cita en el mismo párrafo, afirma lo contrario. (b) Si la regresión llegó a un SDK o a un Visual Studio publicado, hubo una ventana en la que Windows **también** caía en U+FFFD, y eso cambia la explicación de «en Windows no cambia nada» para quien tenga esas versiones.
- **Dirección:** describir #83320 como arreglo de regresión. Citar el comentario de la prueba como evidencia en contra de la rama «ACP UTF-8», y bajar esa rama a pregunta abierta o quitarla del diagrama. Dejar como **pregunta** (nivel C, no corrección) qué SDK o Visual Studio publicado contuvo #82159 sin #83320, porque eso define si la ventana de regresión es real para el lector.

### verificacion-evidencia-04: el Anexo E remite las salidas de E3-x a un «README.md de la carpeta» que no existe

- **Ubicación:** Anexo E, filas E3-1 a E3-6 («`README.md` de la carpeta», «ídem»); §0 l. 24 («la salida está versionada»).
- **Nivel:** E2. **Severidad:** S4.
- **Ancla:** `ls N3-fijacion-del-toolchain/01-dotnet-global-json/` → `correr.sh defecto-misma-banda … rango-feature`, sin README. Las salidas están pegadas en `N3-fijacion-del-toolchain/README.md` (l. 44–195), y N3 es la única de las 10 carpetas sin `salidas/` (`ls | grep -c salidas` → 0).
- **Impacto:** se pierde la trazabilidad de 6 experimentos. Como la salida es un extracto dentro de un README, la regla de §0.3 («extracto literal de la salida registrada») no tiene contra qué compararse.
- **Dirección:** apuntar a `Examples/N3-fijacion-del-toolchain/README.md` con la sección de cada experimento o, mejor, versionar la salida completa en `N3-…/salidas/E3-*.txt` como en las otras carpetas.

## 4. Revisado y bien

1. **El núcleo del caso es reproducible tal como está escrito.** E1-01, E1-11 y E5-7 dieron, en una copia limpia, las mismas líneas que la guía muestra en §1.2, §4.2.3, §4.2.4 y §5.2.4: `CS1056`, `FFFD`, mojibake con `CodePage`, BOM que manda, shebang con BOM que sale con 0 y llaves ignoradas por git. La receta de VS Code que la guía señala como defectuosa es literal.
2. **Los datos volátiles están vigentes al 2026-10-07 y bien fechados.** Python 3.15 (2026-10-09), el calendario de Node desde la 27, Corepack fuera desde Node 25, SLSA 1.2 aprobada y 1.1 retirada, las versiones máximas de Dependabot frente a npm 12, pnpm 12 y uv 0.12, npm-shrinkwrap en npm 12, pip 26.2.1, NuGet determinista en .NET 11, el VS mínimo por banda, la nota † de `global.json`, el SHA de `checkout`, las versiones de .NET y la fecha de fin de soporte, y pre-commit 4.6.2 coinciden con la fuente primaria.
3. **Las discrepancias entre fuente y comportamiento están declaradas, no escondidas.** `CodePage` («first attempts UTF-8» frente a E1-01) y el default de procedencia de BuildKit (v1 en v0.28.0 frente a «v0.2 (default)» en docs.docker.com) aparecen como contradicciones explícitas con su recomendación **[criterio]**. Lo comprobé en las dos fuentes.

## 5. Solicitudes de convocatoria

Ninguna. Lo que vi fuera del mandato es la notación de IDs (`E7-1` en el texto frente a `E7-01` en los nombres de archivo), un detalle editorial que no tiene que ver con la evidencia. Lo dejo al especialista de edición, si la mesa lo considera.
