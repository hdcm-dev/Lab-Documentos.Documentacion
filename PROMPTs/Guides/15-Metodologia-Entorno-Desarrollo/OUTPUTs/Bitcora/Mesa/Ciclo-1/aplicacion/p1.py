# ---------------- P-19 · Anexo D ----------------
begin("P-19")
R("Todas las fuentes se consultaron el **2026-10-07**.", "Las fuentes B01–B193 se consultaron el **2026-10-07**; B194–B204, el **2026-10-09**.")
LINE_REPLACE("| B14 |", "| B14 | dotnet/roslyn — `EncodedStringText.cs` y `CommandLineParser.cs` (commit `9c298328ef91`, 2026-04-24; histórico `5a5e8027cb`) | https://github.com/dotnet/roslyn/blob/9c298328ef910c8c592a6ac73c4a03af64a266b3/src/Compilers/Core/Portable/EncodedStringText.cs · https://github.com/dotnet/roslyn/blob/9c298328ef910c8c592a6ac73c4a03af64a266b3/src/Compilers/Core/Portable/CommandLine/CommandLineParser.cs | 2026-10-07 |")
R("| B15 | dotnet/roslyn — PR #83320 (fallback de codificación por plataforma) |", "| B15 | dotnet/roslyn — PR #83320, «Fix regression in CreateFallbackEncoding» (arreglo de #82159; prueba `CreateFallbackEncoding_IsNotUtf8OnWindows`) |")
LINE_REPLACE("| B49 |", "| B49 | microsoft/vscode — `files.contribution.ts` y `encoding.ts` (commit `521857c60832`, último de `main` al 2026-10-07) | https://github.com/microsoft/vscode/blob/521857c60832c41416f78e035c8977ad14d0ba9b/src/vs/workbench/contrib/files/browser/files.contribution.ts · https://github.com/microsoft/vscode/blob/521857c60832c41416f78e035c8977ad14d0ba9b/src/vs/workbench/services/textfile/common/encoding.ts | 2026-10-07 |")
R("| B155 | SPDX — Specification 3.0.1; specifications (ISO/IEC 5962:2021) |", "| B155 | SPDX — Specification 3.0.1; especificaciones publicadas |")
AFTER("| B193 | `actions/checkout` — repositorio y etiquetas (`git ls-remote`, v7.0.1 → `3d3c42e5…`) | https://github.com/actions/checkout | 2026-10-07 |", """
| B194 | IEC Webstore — ISO/IEC 5962:2021, «Information technology - SPDX® Specification V2.2.1» (2021-08-24) | https://webstore.iec.ch/publication/70993 | 2026-10-09 |
| B195 | Microsoft Learn — NuGet Warning NU1603 | https://learn.microsoft.com/en-us/nuget/reference/errors-and-warnings/nu1603 | 2026-10-09 |
| B196 | pnpm — Settings: CLI (`pmOnFail`, desde v11.0.0) | https://pnpm.io/settings/cli | 2026-10-09 |
| B197 | Sigstore — Signing overview (firma sin clave, Rekor, instancia propia) | https://docs.sigstore.dev/cosign/signing/overview/ | 2026-10-09 |
| B198 | npm Docs v11 — scope (un *scope*, un registro) | https://docs.npmjs.com/cli/v11/using-npm/scope | 2026-10-09 |
| B199 | GitLab Docs — Auto-merge («Pipelines must succeed»; Free, Premium, Ultimate) | https://docs.gitlab.com/user/project/merge_requests/auto_merge/ | 2026-10-09 |
| B200 | GitHub Docs — Events that trigger workflows (`pull_request`, `pull_request_target`) | https://docs.github.com/en/actions/reference/workflows-and-actions/events-that-trigger-workflows | 2026-10-09 |
| B201 | editorconfig-checker — README (v4.0.2) | https://github.com/editorconfig-checker/editorconfig-checker | 2026-10-09 |
| B202 | slsa-framework/github-actions-buildtypes — `workflow/v1` (`resolvedDependencies`) | https://github.com/slsa-framework/github-actions-buildtypes/blob/main/workflow/v1/README.md | 2026-10-09 |
| B203 | Microsoft Learn — .NET Runtime Identifier (RID) catalog | https://learn.microsoft.com/en-us/dotnet/core/rid-catalog | 2026-10-09 |
| B204 | git — git-reset (`--hard`) | https://git-scm.com/docs/git-reset | 2026-10-09 |""")

# ---------------- P-01 · Front matter y apertura ----------------
begin("P-01")
R("status: borrador (pendiente de relectura integral de la mesa)", "status: borrador")
R("fuentes_consultadas: 2026-10-07", 'fuentes_consultadas: "2026-10-07; B194–B204: 2026-10-09"')
R("Todo lo que la guía presenta como salida de un comando se ejecutó el 2026-10-07 en el laboratorio", "Todo lo que la guía presenta como salida de un comando se ejecutó el 2026-10-07 (las ampliaciones de la revisión, el 2026-10-09) en el laboratorio")
R("(193 fuentes, Anexo D), más 71 experimentos ejecutables (Anexo E).", "(204 fuentes, Anexo D), más 73 experimentos ejecutables (Anexo E).")

# ---------------- P-02 · Índice ----------------
begin("P-02")
R("- ***Parte I — El problema y el mapa***\n", "")
R("- ***Parte II — Cada capa, en los tres ecosistemas***\n", "")
R("- ***Parte III — Integración***\n", "")
R("qué pasó, por qué Windows lo tapaba, qué resolvió el fix y qué dejó abierto.", "qué pasó, por qué Windows lo tapaba, qué resolvió la corrección y qué dejó abierto.")
R("la compuerta única, la CI como árbitro", "la compuerta única y su alcance, la CI como árbitro")

# ---------------- P-03 · §0 (3a–3e, 3g, 3h; la 3f va al final) ----------------
begin("P-03")
L = lines()
i = [k for k, l in enumerate(L) if l.startswith("Quedan fuera: el despliegue y la operación en producción")]
if len(i) == 1:
    L[i[0]] = "Quedan fuera: el despliegue y la operación en producción (la guía termina en el artefacto construido y su procedencia; el procedimiento de verificar antes de instalar corresponde a la [guía de Despliegue](../Despliegue/) de esta misma colección), otros ecosistemas (Java, Go, Rust), las comparativas comerciales de productos de CI y la recomendación de una herramienta única «para todo». Tampoco compara los enfoques que reemplazan el entorno completo: sistemas de build herméticos que gestionan las herramientas como fuente (la definición de §3.1 se toma de uno de ellos, Bazel [B04]) o gestores declarativos del entorno de todo el sistema. **[criterio]** La guía parte de un repositorio que se edita con Visual Studio en Windows y se construye con las CLI nativas de cada ecosistema, y adopta un enfoque que conserva esas herramientas: archivos nativos de cada ecosistema, una compuerta y una imagen por digest. Quien evalúe un enfoque de entorno completo necesita otra comparación, con su propia evidencia; ésta no la hizo."
    setlines(L); LOG.append(("P-03", "3a", True, ""))
else:
    LOG.append(("P-03", "3a", False, str(len(i))))
R("| **Recorrido** | §1 → §12 en orden; correr los experimentos que cada capítulo cita | Quien llega con el problema del caso y quiere entenderlo de raíz |",
  "| **Recorrido** | §1 → §12 en orden. En §3, las secciones 3.1, 3.2, 3.4 y 3.7 (las tablas de 3.3, 3.5 y 3.6 son de consulta: se vuelve a ellas al terminar §10). Al cierre de cada capítulo, su **Práctica**, sobre la ruta mínima de abajo | Quien llega con el problema del caso y quiere entenderlo de raíz |")
R("→ **Criterios de calidad** (cómo se distingue una versión buena de una pobre) → **Plantilla** (remite al Anexo A).",
  """→ **Criterios de calidad** (cómo se distingue una versión buena de una pobre) → **Plantilla** (remite al Anexo A) → **Práctica** (dos consignas sobre experimentos que ya existen, con la respuesta esperada).

**Ruta mínima del Recorrido.** Un experimento por capítulo, el que sostiene la idea central; los demás se corren al consultar. Cada carpeta de [`Examples/`](Examples/) dice cómo correrlo. Sólo N0 tiene tiempo medido: alrededor de un minuto y medio con las imágenes ya descargadas; los demás dependen sobre todo de la primera descarga de imágenes.

| Capítulo | Experimento | Qué tiene que quedar claro |
|---|---|---|
| §4 | E1-01 | El mismo `.cs` en cp1252: literal corrupto, identificador que no compila |
| §5 | E2-2 | Una migración de cien archivos que se revisa con un script |
| §6 | E3-1 | Qué SDK elige cada `global.json` y cuál falla |
| §7 | E4-2 | CPM sin lock no garantiza la versión pedida; el lock calla el aviso |
| §8 | E5-1 | El contenedor no arregla los bytes del fuente |
| §9 | E6-2 | Qué hace falta para que dos builds den el mismo hash |
| §10 | E7-1 | El hook se saltea; la CI no |
| §11 | E8-1 | Qué se rompe primero en un repo con los tres ecosistemas |""")
R("| **[observado]** | Comportamiento medido en el laboratorio que la documentación del fabricante no describe; puede cambiar sin aviso. |",
  """| **[observado]** | Comportamiento medido en el laboratorio que la documentación del fabricante no describe; se dice siempre con qué versión se observó, porque puede cambiar sin aviso. |
| **[interpretación]** | Inferencia de un hecho que no se observó directamente: compatible con la evidencia citada, pero no medida. El Anexo F las lista. |

Son las únicas cinco marcas, siempre en negrita. El motivo o el matiz va fuera del corchete: **[no verificado]** (requiere Windows), **[criterio]** (sobre la base del fabricante).""")
R("""```bash
cd Examples/N0-modelo-de-capas-y-reproducibilidad && ./correr-todo.sh      # ~1 minuto
cd Examples/A-plantillas && ./verificar.sh                                   # las plantillas del Anexo A, juntas
```""", """```bash
# Desde la carpeta de esta guía. Cada línea en su propio subshell, para que el cd no se acumule.
( cd Examples/N0-modelo-de-capas-y-reproducibilidad && bash correr-todo.sh )   # ~1,5 minutos con imágenes en caché
( cd Examples/A-plantillas && bash verificar.sh )                              # las plantillas del Anexo A, juntas
```""")
AFTER("el [Anexo F](#anexo-f-límites-y-lo-que-no-se-verificó) lo lista.", """

> **Desde Windows.** Los scripts del laboratorio, de la migración (§5.2.6) y de la compuerta (§10) son de shell POSIX. Hay dos vías, ninguna probada en esta guía **[no verificado]** (requiere Windows): Docker Desktop con contenedores Linux, corriendo los mismos `docker run` desde Git Bash o desde una terminal de WSL 2 con el clon en el sistema de archivos de WSL [B130][B132]; o Git Bash con los prerrequisitos de la compuerta instalados en Windows ([A.11](#a11-hook-versionado-y-esqueleto-de-la-compuerta)). Las expresiones `$PWD` y `$(id -u)` de los comandos son de shell POSIX: en PowerShell no valen.""")

# ---------------- P-04 · §1 ----------------
begin("P-04")
AFTER("El caso real no se puede mostrar (es de un repositorio privado). El laboratorio lo reproduce con un ejemplo sintético: un `.cs` en cp1252 con un identificador `Çaudal` y un literal `\"Atención\"`, compilado con el SDK oficial de .NET en Linux.", """

Para reproducirlo, desde la carpeta de esta guía:

```bash
cd Examples/N1-codificacion-y-finales-de-linea
docker run --rm -u "$(id -u):$(id -g)" -v "$PWD":/w -w /w python:3.12-slim python generar.py      # crea work/
docker run --rm -u "$(id -u):$(id -g)" -e HOME=/tmp -v "$PWD":/w -w /w mcr.microsoft.com/dotnet/sdk:8.0 sh e1-roslyn.sh
```""")
R("El fix funcionó, pero dejó tres preguntas", "La corrección funcionó, pero dejó tres preguntas")
R("### 1.4 Qué resolvió el fix y qué dejó abierto", "### 1.4 Qué resolvió la corrección y qué dejó abierto")
R("- y no queda registro de con qué se construyó cada pieza (", "- y no queda registro de con qué se construyó cada artefacto (")

# ---------------- P-05 · §2 ----------------
begin("P-05")
R("macOS no se separa de ESC-02 porque, para estos temas, se comporta como Linux: el propio equipo del compilador de C# fijó en una prueba que el *fallback* es UTF-8 en Linux y macOS [B15].",
  "macOS no se separa de ESC-02 (estación Linux) porque, para estos temas, se comporta como Linux: fuera de Windows, .NET devuelve UTF-8 como página por defecto [B19], y la prueba que acompaña un arreglo del compilador de C# deja escrito que en Linux y macOS el *fallback* es UTF-8 [B15].")
R("si hay devcontainer, la estructura del repo políglota.", "si hay devcontainer, la estrategia de imagen (única o por componente) y la estructura del repo políglota.")
R("La imagen de CI y del devcontainer y su actualización; SBOM y procedencia; las compuertas; la protección de rama.", "La construcción, el digest y la actualización de las imágenes de CI y del devcontainer; SBOM y procedencia; las compuertas; la protección de rama.")
R("| §9 Procedencia | — | — | — | ○ | ● |", "| §9 Procedencia | ○ (diagnóstico) | ○ (reconstruir) | ○ (reconstruir) | ○ | ● |")
LINE_REPLACE("La procedencia (§9) pesa sólo en CI por una decisión de esta guía **[criterio]**:", "La procedencia (§9) se **produce** sólo en la CI por una decisión de esta guía **[criterio]**: la que vale es la del artefacto que se publica, y ese sale de la CI. En las estaciones y el devcontainer, §9 sirve para diagnosticar (metadatos embebidos) y para reconstruir un artefacto publicado y comparar hashes; una build local no demuestra nada ante un tercero.")

# ---------------- P-06 · §3 ----------------
begin("P-06")
R("Es el mapa: los capítulos 4 a 10 desarrollan una capa cada uno.", "Es el mapa: §4 y §5 tratan la capa 1; §6, §7 y §8, las capas 2, 3 y 4; §9, las capas 5 y 6; §10, cómo se hace cumplir todo lo anterior; y §11 cruza todas las capas en una solución con tres ecosistemas. En el Recorrido, leé ahora §3.1, §3.2, §3.4 y §3.7; las tablas de §3.3, §3.5 y §3.6 usan mecanismos que se explican recién en §6 a §10 y son de consulta.")
R("variables de entorno que el build lee", "variables de entorno que la build lee")
R("| fabricantes | Congelar. |", "| [B56][B84][B106][B113] | Congelar. |")
R("| fabricantes | «Congelar el entorno»: un lock congela una sola capa. |", "| [B83][B93][B99][B101] | «Congelar el entorno»: un lock congela una sola capa. |")
AFTER("### 3.3 Qué fija cada mecanismo y qué deja libre\n", "\n*Tabla de consulta: usa mecanismos que se explican en §6 a §10.*\n")
AFTER("### 3.6 Mapa conceptual: «estoy acá → qué aplico»\n", "\n*Tabla de consulta: usa mecanismos que se explican en §4 a §11.*\n")
LINE_REPLACE("| `global.json` con `version` + `rollForward: disable` | 2 (SDK exacto, y con él el compilador)", "| `global.json` con `version` + `rollForward: disable` | 2 (SDK exacto; con él, el compilador en la CLI; en Visual Studio depende del SDK, §6.2.2) | El runtime con que corre la app; capas 3–5 | Hace cumplir: `dotnet` y el resolvedor de MSBuild fallan **en toda máquina** que no tenga ese SDK exacto | [B56], E3-1 |")
R("Tres puertas de entrada al resto de la guía, según lo que el lector tenga delante.", "Cuatro puertas de entrada al resto de la guía, según lo que el lector tenga delante.")
LINE_REPLACE("| ESC-01 Windows + Visual Studio | Respetar `.editorconfig`", "| ESC-01 Windows + Visual Studio | Respetar `.editorconfig` (Visual Studio lo lee de fábrica [B44]); activar el hook **con sus prerrequisitos** ([A.11](#a11-hook-versionado-y-esqueleto-de-la-compuerta)); con `rollForward: disable`, tener el SDK exacto de `global.json` (instalador independiente si VS trae otro [B56]); correr la compuerta antes del push desde Git Bash **[no verificado]** (requiere Windows) | Decidir la política; la procedencia |")
R("| ESC-04 Devcontainer | Imagen por digest; `devcontainer-lock.json`; `--frozen-lockfile` | Creer que reemplaza a la política |", "| ESC-04 Devcontainer | Etiqueta fija de SDK y SO verificada por `global.json`, o la misma receta que la imagen de CI (§8.2.2); `devcontainer-lock.json`; `--frozen-lockfile` | Creer que reemplaza a la política |")
AFTER("| ESC-05 CI | Compuerta completa sobre clon limpio; restauración estricta; `ContinuousIntegrationBuild`; `SOURCE_DATE_EPOCH`; SBOM y procedencia | — |", """

**Por contexto.**

| Mi solución es… | Qué cambia respecto de la regla general | Archivos mínimos | Andá a |
|---|---|---|---|
| CTX-NET (sólo .NET) | El BOM de la familia .NET es convención del equipo (§5.2.3); `rollForward` coherente con usar o no lock de NuGet (§6.4); Visual Studio como estación principal | `.editorconfig`, `.gitattributes`, `global.json`, `Directory.Build.props`, `Directory.Packages.props`, `nuget.config` | §5.2.3, §6.2.2, §7.2.1, §9.2.1 |
| CTX-NODE (sólo Node.js) | Node no tiene archivo de versión propio: `.nvmrc` para los gestores y `devEngines` para que npm falle; JSON sin BOM | `.nvmrc`, `package.json`, `package-lock.json`, `.npmrc` | §6.2.3, §7.2.2, §9.2.2 |
| CTX-PY (sólo Python) | `requires-python` + `.python-version` dentro del proyecto uv; `open()` con `encoding=` | `pyproject.toml`, `.python-version`, `uv.lock` | §6.2.4, §7.2.3, §9.2.2 |
| CTX-POLI (los tres en un repo) | Excepciones de texto por lector; un archivo nativo y un lock por ecosistema donde los busca su herramienta; frontera de la build; imagen única o por componente | todo lo anterior y una compuerta con inventario de proyectos | §11 |""")
R("`*.lock*`, `.npmrc`, índices de uv |", "`*.lock*`, `.npmrc`, índices de paquetes de uv |")
R("(E4-2 muestra CPM pidiendo 8.0.2 y NuGet entregando 9.0.0 sin advertir, cosa que sólo el lock habría detectado)", "(E4-2: CPM pidió 8.0.2, que no existe, y NuGet resolvió 9.0.0; sin lock lo avisa con `NU1603`, y con lock el aviso desaparece y el lock registra `requested [8.0.2, )` con `resolved 9.0.0`, §7.2.1)")
APPQ("¿Por qué el mismo commit da resultados distintos", " *Aplica* al primer diagnóstico de todo «en mi máquina anda»: entre dos estaciones, entre la estación y la CI o entre dos corridas de la CI.", "### 3.7", "## 4.")
APPQ("¿Un contenedor reemplaza al `global.json` o al lock?", " *Aplica* cuando se propone el devcontainer como reemplazo de la política; *no aplica* a la imagen de la CI, que sí es parte de lo que se fija (§8.2.2).", "### 3.7", "## 4.")
APPQ("¿Un rango es siempre peligroso?", " *Aplica* al declarar dependencias en cualquier ecosistema: rango en el manifiesto y lock con modo estricto en la CI; para .NET sin lock, la política de §6.4.", "### 3.7", "## 4.")
BEFORE_SECTION_END("### 3.7 Preguntas guía", """**El caso de §1 llega a tu equipo: el `.cs` en cp1252 compila en la estación Windows y falla en la CI Linux. ¿Por qué capa empezás y qué descartás?**
Por la capa 1, la más baja donde las dos máquinas difieren: los bytes del archivo no son UTF-8 válido y cada compilador los decodifica con la página ANSI de su sistema (§1.2). El SDK, los paquetes y la imagen se descartan por ahora: aunque estuvieran fijados, el archivo fallaría igual en Linux (E5-1). *Aplica* a todo fallo que aparece en un sistema operativo y no en otro con el mismo commit.""")
