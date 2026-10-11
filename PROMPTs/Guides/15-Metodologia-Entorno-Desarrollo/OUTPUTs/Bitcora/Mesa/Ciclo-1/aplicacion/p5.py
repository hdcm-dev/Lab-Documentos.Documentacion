# ---------------- P-13 · §10 ----------------
begin("P-13")
AFTER("La misma compuerta sirvió sin cambios para un repo .NET (E7-1), uno Node y uno Python (E7-7).", "\n\n**Alcance declarado.** La compuerta de `Examples/N7-compuertas-y-gobierno/compuerta/` busca cada archivo **en la raíz** del repo: vale para un repo con un proyecto por ecosistema en la raíz (E7-1, E7-7). En una solución políglota que ubica `.python-version`, `uv.lock` y `package-lock.json` en subcarpetas, como recomienda §11.2.3, esa misma compuerta los declara `n/a` aunque existan. Ahí hace falta un **inventario explícito de proyectos por ecosistema** —la variante de §11, `solucion/verificar.sh`, lo tiene escrito en el script— o un descubrimiento de manifiestos que falle ante uno que no figure en el inventario **[criterio]**. «Compuerta única» quiere decir un solo programa por repositorio: `compuerta.sh` (N7) y `verificar.sh` (N8) son dos ejemplos del mismo diseño para dos disposiciones, no dos compuertas para un mismo repo. Y **una herramienta que falta no es una violación**: la compuerta dice «falta `python3`» y no «la política no se cumple», para que nadie apague el hook por un falso rojo.")
R("En GitHub, las ramas protegidas, los dueños de código requeridos y los *rulesets* están disponibles en repositorios **públicos** con el plan Free y en privados sólo con Pro, Team o Enterprise [B176][B177][B179]. En GitLab las ramas protegidas están en Free, pero la aprobación obligatoria de dueños es Premium/Ultimate [B185].",
  "En GitHub, las ramas protegidas, los dueños de código requeridos y los *rulesets* están disponibles en repositorios **públicos** con el plan Free y en privados con Pro, que es un plan de cuentas personales, o con Team y Enterprise, los de organizaciones [B176][B177][B179]: para el repositorio de una organización, el mínimo es Team. En GitLab, las ramas protegidas y «Pipelines must succeed» están en Free —la segunda impide fusionar un *merge request* sin una pipeline exitosa, incluido el que no tiene ninguna [B199]—, pero la aprobación obligatoria de dueños es Premium/Ultimate [B185].")
R("""| Control | Qué impide | Evidencia |
|---|---|---|
| Rama protegida con chequeo requerido (si el plan la ofrece) | El merge o el push | [B177][B186] |
| `pre-receive` en un servidor propio | El push completo (`pre-receive hook declined`, `main` intacto) | E7-5, [B175] |
| Compuerta en el **acto irreversible**: publicar sólo desde `main`, corriendo la compuerta sobre ese commit en un clon limpio, sin reescribir una versión publicada | Publicar desde un estado que no cumple | E7-5 |
| Regla escrita + revisión periódica de que `main` está en verde | Nada en el momento; detecta | [criterio] |""", """| Control | Qué impide | Qué no impide | Evidencia |
|---|---|---|---|
| Rama protegida con chequeo requerido (GitHub, si el plan la ofrece) | El merge o el push sin el chequeo aprobado | Un PR que edita la compuerta o el workflow para que salgan 0: el evento `pull_request` corre el código del *merge commit* del PR [B200]; un job `skipped`, que satisface el chequeo; a los administradores, salvo que se los incluya [B177] | [B177][B186][B200] |
| Rama protegida sin push directo + «Pipelines must succeed» (GitLab, también en Free) | Fusionar sin una pipeline exitosa | Un MR que edita `.gitlab-ci.yml` o la compuerta, si la aprobación de dueños no es obligatoria (Premium/Ultimate) | [B185][B199] |
| `pre-receive` en un servidor propio | El push completo (`pre-receive hook declined`, `main` intacto) | Nada mientras el hook corra en el servidor; su tiempo está acotado en GHES (abajo) | E7-5, [B175] |
| Compuerta en el **acto irreversible**: publicar sólo desde `main`, corriendo la compuerta sobre ese commit en un clon limpio, sin reescribir una versión publicada | Publicar desde un estado que no cumple | Que `main` quede rojo un rato | E7-5 |
| Regla escrita + revisión periódica de que `main` está en verde | Nada en el momento; detecta | Todo | **[criterio]** |

**[criterio]** «Impide» vale de verdad cuando, además del chequeo requerido, la revisión de dueños es obligatoria sobre los archivos de la compuerta (`/.github/`, `/tools/ci/`, A.14), la aprobación del último push la hace alguien distinto de quien lo empujó y los administradores están incluidos en la regla [B177].""")
R("Política de texto, toolchain, dependencias; cuándo se descongela una mayor", "Política de texto, toolchain, dependencias, estrategia de imagen (única o por componente); cuándo se descongela una mayor")
R("Imagen de CI y devcontainer, compuerta, bots, protección de rama", "Construcción, digest y mantenimiento de las imágenes de CI y devcontainer; compuerta, bots, protección de rama")
R("| El hook necesita un intérprete de `sh` (Git for Windows trae uno); el comportamiento de la integración de git de Visual Studio con `core.hooksPath` **[no verificado]**. Es donde el problema del caso no se ve: la CI en Linux lo revela. |",
  "| El hook de A.11 necesita en la estación `bash` (el de Git for Windows), `python3` con el paquete `EditorConfig==0.17.1` y los dos archivos de la compuerta en `tools/ci/`; para los pasos de toolchain y grafo, las herramientas que el repo declara. A mano, desde Git Bash en la raíz del clon: `bash tools/ci/compuerta.sh` **[no verificado]** (requiere Windows). La integración de git de Visual Studio con `core.hooksPath` **[no verificado]** (requiere Windows). Es donde el problema del caso no se ve: la CI en Linux lo revela. |")
R("En CTX-POLI la compuerta corre sus tres pasos para los tres ecosistemas a la vez;", "En CTX-POLI (los tres ecosistemas en un repo) la compuerta corre sus tres pasos para los tres ecosistemas a la vez, sobre el inventario de proyectos de §10.2.2;")
R("""```bash
# publicar.sh — compuerta en el acto irreversible (extracto de E7-5).
git merge-base --is-ancestor "$commit" origin/main || exit 1     # sólo desde main""", """```bash
# publicar.sh <remoto> <commit> <version> — compuerta en el acto irreversible
# (extracto de E7-5; la ruta de la compuerta, adaptada a A.11).
tmp=$(mktemp -d); git clone -q "$remoto" "$tmp/r" && cd "$tmp/r" || exit 2   # clon limpio, no el árbol de quien publica
git merge-base --is-ancestor "$commit" origin/main || exit 1     # sólo desde main""")
SPLITQ("### 10.6 Preguntas guía", "### 10.7")
APPQ("¿Alcanza con un hook?", " *Aplica* a todo equipo: el hook es para ACT-DEV; la defensa es la CI (ESC-05).", "### 10.6", "### 10.7")
R("Si se adopta, la política la sigue haciendo cumplir un chequeo que lee `.editorconfig`.", "Si se adopta, la política la sigue haciendo cumplir un chequeo que lee `.editorconfig`: el del laboratorio o editorconfig-checker (§5.2.5). *Aplica* al elegir cómo se instalan los hooks en las estaciones y el devcontainer (ESC-01 a ESC-04).")
APPQ("¿Cómo se descongela algo sin perder trazabilidad?", " *Aplica* a ACT-ARQ y ACT-OPS en cada subida de SDK, runtime, imagen o paquete mayor.", "### 10.6", "### 10.7")
APPQ("¿Por qué un lock que cambia sin su manifiesto es sospechoso?", " *Aplica* a ACT-REV en CTX-NET y CTX-POLI.", "### 10.6", "### 10.7")
APPQ("¿Qué hago si la plataforma no ofrece protección de rama?", " *Aplica* a repositorios privados en planes sin protección de rama (§10.2.7).", "### 10.6", "### 10.7")
APPQ("¿Hay que fijar también las herramientas de la compuerta?", " *Aplica* a ACT-OPS al escribir la compuerta y su workflow.", "### 10.6", "### 10.7")
END_OF_SECTION_APPEND("### 10.6 Preguntas guía", "### 10.7", """**El hook de un compañero en Windows rechaza su commit con «la política de .editorconfig/.gitattributes no se cumple», pero su `.cs` es UTF-8 válido. ¿Qué mirás antes de dejarlo usar `--no-verify`?**
Si la estación tiene lo que la compuerta necesita: `bash`, `python3`, el paquete `EditorConfig` y `check_text_policy.py` junto a `compuerta.sh` (§10.4). Sin `python3` el verificador no corre, y una compuerta que no distingue «falta herramienta» de «violación» informa lo segundo. Se instala lo que falta o se corrige la compuerta para que lo diga; `--no-verify` sólo traslada el problema a la CI. *Aplica* a ESC-01 (Windows con Visual Studio).""")
R("ningún ADR que explique por qué `rollForward` es `disable`.", "ningún ADR que explique por qué `rollForward` es `disable`; la compuerta dice `n/a` para un archivo que existe en una subcarpeta; la compuerta informa «violación» cuando lo que falta es una herramienta; documentar que la rama protegida «impide» sin decir qué no impide.")
BEFORE_SECTION_END("### 10.8 Plantilla", """### 10.9 Práctica

1. Revisá el PR de E7-4 que sube el SDK con la lista B.4. ¿Lo aprobás? *Respuesta esperada*: sí, porque mueve juntos `global.json`, la receta de la imagen y el ADR, y la compuerta pasa en la imagen nueva (§10.2.6).
2. Con la tabla de §10.2.7, escribí qué impide y qué no impide la configuración de tu plataforma y tu plan, y qué control compensatorio agregás donde no impide nada.""")

# ---------------- P-14 · §11 ----------------
begin("P-14")
R("índices de uv con `explicit = true` y la estrategia `first-index` contra la confusión de dependencias [B110]—, ninguno dependiente de la configuración del usuario, y la compuerta corriendo los tres comandos estrictos.",
  "índices de paquetes de uv con la estrategia `first-index` contra la confusión de dependencias y `explicit = true` para los internos, que protege sólo lo asignado a ese índice [B110]—, ninguno dependiente de la configuración del usuario, cada uno con el hueco que dice §7.3, y la compuerta corriendo los tres comandos estrictos.")
R("`global.json` no cubre a Node ni a Python; dentro de esta frontera, `engines` + `engine-strict` es lo único que hace cumplir la versión de Node.",
  "`global.json` no cubre a Node ni a Python. Dentro de esta frontera hace cumplir la versión de Node lo que evalúa npm: `devEngines.runtime`, que falla por defecto en `npm ci` y `npm run` sin configuración adicional (`EBADDEVENGINES` con npm 10.9.8 y 11.19, E8-3), o, alternativamente, `engines` + `engine-strict`.")
R("| A en la estación, **con** `npm ci`, `uv run --locked`, `engine-strict` e `Inputs`/`Outputs` |", "| A en la estación, **con** `npm ci`, `uv run --locked`, `devEngines` (o `engine-strict`) e `Inputs`/`Outputs` |")
R("**[criterio]** La comparación A = B se hace con la configuración de publicación explícita.",
  "**[criterio]** La igualdad no se comprueba en la estación —F5 compila en `Debug` y sin `ContinuousIntegrationBuild` (§9.4)—: se comprueba en la CI como **prueba de regresión del `.csproj`**, con la misma imagen corriendo `dotnet build -c Release -p:ContinuousIntegrationBuild=true` con `ConstruirPoliglota=true` y `build.sh`, y comparando las DLL. Lo que demuestra es que los targets de A no divergen de B, no que la estación reproduzca a la CI.")
R("Construir la imagen de desarrollo `FROM` la misma base que la CI (§8.2.6) en la variante única se cumple por construcción.",
  "Construir la imagen de desarrollo `FROM` la misma base que la CI (§8.2.6) se cumple por construcción **si la CI también usa la imagen única**. Con CI por componente, el Python de desarrollo lo instala uv y el de la CI viene de `python:3.12.15-slim`: la misma versión, de dos orígenes, que hay que declarar.")
AFTER("el mismo comando que la estación y el devcontainer.", " Por componente sólo si los componentes se publican por separado, con una etapa previa que corre la compuerta completa en la imagen única: el Dockerfile por componente del laboratorio sólo corre los comandos estrictos de cada ecosistema, no la compuerta de texto.")
R("La procedencia exportada por BuildKit no está firmada: la firma la agrega la plataforma de CI (§9.2.4).",
  "La procedencia exportada por BuildKit no está firmada y su `builder.id` sale vacío (§9.2.4). La que firma la plataforma, como la de `actions/attest`, exige en sus dependencias resueltas sólo el commit y deja el entorno como opcional [B202]. Para contestar «con qué entorno se ensambló» hay entonces tres piezas distintas **[criterio]**: (a) la procedencia de la plataforma, firmada, que nombra commit y workflow; (b) los materiales del entorno —digest de la imagen del job o de cada etapa, toolchain efectivo—, que registra un paso del pipeline; (c) cómo se atan: un predicado propio firmado en la misma corrida, rotulado como afirmación del pipeline y no de la plataforma (la vara de §9.2.4), o la atestación de la imagen del job, enlazada por su digest.")
R('        REG["registro del entorno"]', '        REG["registro del entorno<br/>imagen por digest · toolchain efectivo"]')
R('        PRV["procedencia: bases por digest, firmada en CI"]', '        PRV["procedencia firmada por la plataforma (commit)<br/>o de BuildKit (bases por digest, sin firma)"]')
R('    MSB["Visual Studio / dotnet build<br/>(MSBuild llama a npm y uv)"] -.->|"mismo resultado (Release, misma ruta)"| NET', '    MSB["Visual Studio / dotnet build<br/>(MSBuild llama a npm y uv)"] -.->|"mismo resultado: prueba de regresión en CI"| NET')
R("""| Imagen | Única | **Devcontainer** y frontera A | E8-5 |
| | Por componente | **CI** por etapas | E8-5 |""", """| Imagen | Única | **Devcontainer**, frontera A y **CI cuando el artefacto es uno** (§11.2.7) | E8-5 |
| | Por componente | **CI** cuando los componentes se publican por separado, con la compuerta completa corrida antes en la imagen única | E8-5 |""")
R("| Frontera A en modo estricto; `engine-strict=true`; correr `verificar.sh` (por WSL o Git Bash) antes del push **[no verificado en Windows]** |",
  "| Frontera A en modo estricto; `devEngines` (o `engine-strict=true`); correr `verificar.sh` desde **Git Bash**, que usa el `PATH` de Windows, el mismo que la build de Visual Studio **[no verificado]** (requiere Windows). Por WSL la compuerta compara los archivos nativos con los runtimes de Linux: verifica las capas 1 y 3, no la 2 de Windows |")
R("Imagen única construida desde los nativos, bases por digest", "Imagen única construida desde los nativos con la receta de A.10, la misma que la CI (bases por digest en su Dockerfile)")
R("Frontera B; imagen única o etapas por componente por digest; SBOM de locks y de artefacto; atestación firmada", "Frontera B; imagen única si el artefacto es uno, etapas por componente si se publican por separado (§11.2.7); registro del entorno y SBOM de locks y de artefacto; procedencia firmada si un consumidor la verifica (§12, paso 8b)")
R("Mantiene el Dockerfile multi-runtime o las cuatro bases por digest;", "Construye y mantiene el Dockerfile multi-runtime o las cuatro bases por digest, según la estrategia que decide ACT-ARQ;")
R("""```bash
docker buildx build --builder n8-attest --target artefacto \\
  --provenance=mode=max,version=v1 --sbom=true \\
  -f imagen/Dockerfile.por-componente --output type=local,dest=salida solucion
# salida/provenance.json : SLSA v1; materiales = SDK, Node, Python y uv por digest
# salida/sbom.spdx.json  : sólo lo que viaja (NuGet)
```""", """```bash
# Una vez por máquina: un builder docker-container, que exporta procedencia y SBOM (§9.2.4).
docker buildx inspect n8-attest >/dev/null 2>&1 || docker buildx create --name n8-attest --driver docker-container
docker buildx build --builder n8-attest --target artefacto \\
  --build-arg PY_IMAGE=python:3.12.15-slim@sha256:05cda9777409a9c3ffddd94a4c476b79f0769a0b4857f0c7ed9226b6800b0d6f \\
  --provenance=mode=max --sbom=true \\
  -f imagen/Dockerfile.por-componente --output type=local,dest=salida solucion
# salida/provenance.json : SLSA v1; materiales = SDK, Node, Python y uv por digest; builder.id vacío
# salida/sbom.spdx.json  : sólo lo que viaja (NuGet)
```

E8-6 agrega además `ARG BUILDKIT_SBOM_SCAN_STAGE=true` en las etapas de Python y Node para obtener un SBOM por etapa (§11.2.8). Este comando no pide `version=v1`: el default de la versión de BuildKit usada ya es v1 (§9.2.4).""")
UNNUMQ("### 11.6 Preguntas guía", "### 11.7")
R("con cp1252 falla C# en Linux, falla Python y Node corrompe sin error (E8-1).", "con cp1252 falla C# en Linux, falla Python y Node corrompe sin error los datos que lee (un identificador cp1252 en su propio código sí lo haría fallar, §4.2.4) (E8-1).")
R("*Aplica*: devcontainer y estación → imagen única; CI por etapas → por componente, con cuatro digests fijados.", "*Aplica*: devcontainer y estación → imagen única; CI → la misma imagen única si el artefacto es uno, y por componente sólo si los componentes se publican por separado, con cuatro digests fijados y la compuerta completa corrida antes en la imagen única (§11.2.7).")
APPQ("¿Cómo se fija el toolchain de tres ecosistemas desde un único punto de verdad?", " *Aplica* a CTX-POLI en todos los escenarios; en ESC-01 la compuerta es lo único que verifica Node y Python.", "### 11.6", "### 11.7")
R("Primero decidiendo el alcance: locks, artefacto, entorno. Para los locks, una herramienta multi-ecosistema o los exportadores nativos unidos; para el entorno, la procedencia de la plataforma, que nombra por digest las imágenes de los tres toolchains, firmada en la CI.",
  "Primero decidiendo el alcance: locks, artefacto, entorno. Para los locks, una herramienta multi-ecosistema o los exportadores nativos unidos. Para el entorno, el registro del entorno de la CI y, si la build corre en contenedores, la procedencia de BuildKit, que nombra por digest las imágenes de los tres toolchains pero sale sin firma y sin `builder.id`. La procedencia que firma la plataforma nombra el commit, no el entorno: atar las dos cosas es un paso propio (§11.2.8). *Aplica* a la CI (ESC-05) en CTX-POLI.")
R("en ESC-01, fuera de MSBuild", "en la estación Windows (ESC-01), fuera de MSBuild")
R("Los dos caminos tienen que dar lo mismo con la configuración de publicación.", "Los dos caminos tienen que dar lo mismo, y eso se prueba en la CI (§11.2.5).")
APPQ("¿Dónde vive la frontera entre la build .NET y las demás?", " *Aplica* a CTX-POLI con estaciones Windows y CI.", "### 11.6", "### 11.7")
APPQ("¿Alcanza con que los tres locks estén commiteados?", " *Aplica* a CTX-POLI y a todo repo con `.esproj`.", "### 11.6", "### 11.7")
END_OF_SECTION_APPEND("### 11.6 Preguntas guía", "### 11.7", """**Tu equipo copió A.10 para la imagen de CI y, por la tabla de §11.3, duda entre imagen única y por componente. El artefacto es una sola DLL. ¿Qué usás en la CI?**
La única. Con un solo artefacto, el job corre `build.sh`, el mismo comando que la estación y el devcontainer, y la compuerta completa corre en un lugar (§11.2.7). La variante por componente no corre la compuerta de texto y trae otro origen de Python (§11.2.6); conviene cuando los componentes se publican por separado. *Aplica* a la CI (ESC-05) en CTX-POLI.""")
R("- elige su frontera de build por escenario, con modo estricto en ambas, y comprueba que las dos producen el mismo artefacto;", "- elige su frontera de build por escenario, con modo estricto en ambas, y comprueba en la CI, con una prueba de regresión del `.csproj`, que las dos producen el mismo artefacto;")
R("- declara el alcance de cada SBOM y deja la procedencia firmada en la CI.", "- declara el alcance de cada SBOM, graba el registro del entorno y, si un consumidor la verifica, deja en la CI una procedencia firmada que dice qué nombra y qué no.")
R("locks marcados `linguist-generated`.", "locks marcados `linguist-generated`; una compuerta que dice `n/a` para los proyectos de las subcarpetas.")
R("Todas las del [Anexo A](#anexo-a-plantillas-comentadas), que forman juntas un repositorio políglota mínimo verificado por EA-1; la imagen multi-runtime en [A.10](#a10-dockerfile-de-la-imagen-multi-runtime).",
  "Todas las del [Anexo A](#anexo-a-plantillas-comentadas), que forman juntas un repositorio políglota mínimo verificado por EA-1, incluida la imagen multi-runtime de [A.10](#a10-dockerfile-de-la-imagen-multi-runtime), que EA-1 construye, y el devcontainer de A.9, que usa su receta.")
P14_C1 = "1. Antes de mirar E8-1, predecí qué lectores fallan con «BOM para todo». *Respuesta esperada*: cinco —los dos shebangs, `json.load`, `tomllib`, `JSON.parse` y la comparación de `.nvmrc`—, ninguno de .NET (§11.2.1)."
BEFORE_SECTION_END("### 11.8 Plantilla", "### 11.9 Práctica\n\n" + P14_C1 + "\n2. Copiá la compuerta de N7 (con `check_text_policy.py`) dentro de la solución de N8, corrélas a las dos y explicá cada diferencia. *Respuesta esperada*: la de N7 declara `n/a` el Python, el lock de npm y el de uv, porque los busca en la raíz; `verificar.sh` los encuentra porque tiene las rutas (§10.2.2).")
# --- Verificación fáctica de la consigna 1 de §11.9 contra E8-1 ---
E81 = "/home/fernando/workspaces/workspace-dev/LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Examples/N8-integracion-poliglota/salidas/E8-1-choque-de-convenciones.txt"
t = open(E81, encoding="utf-8").read()
secB = t.split("### B.")[1].split("### C.")[0]
hola_ok = any("hola.sh" in l and l.rstrip().endswith("OK") for l in secB.split("\n"))
if hola_ok:
    R(P14_C1 + "\n2. Copiá", "1. Copiá", note="revert consigna 1")
    LOG.append(("P-14", "§11.9 consigna 1 REVERTIDA", True, "E8-1 B: hola.sh OK; cuenta «cinco» con seis nombres"))
