# ---------------- P-15 · §12 ----------------
begin("P-15")
R("Los capítulos anteriores se pueden leer en cualquier orden; adoptarlos, no.", "Los capítulos anteriores se pueden **consultar** en cualquier orden; para aprenderlos conviene el orden de §0.2, y para adoptarlos, el de esta tabla.")
R("elegir la variante de `*.cs` según el estado del repo.", "elegir la convención de la familia .NET (`*.cs`, `*.csproj`) según el estado del repo: nuevo, heredado todavía en cp1252 o ya convertido con BOM (§5.2.3).")
R("`.git-blame-ignore-revs` después; fusión con merge commit.", "`.git-blame-ignore-revs` después, con el SHA que quedó en `main`; un PR por commit o uno con merge commit.")
R("Poner la compuerta de texto en la CI y el hook versionado.", "Poner la compuerta de texto en la CI y el hook versionado, con los prerrequisitos de cada estación declarados (A.11).")
LINE_REPLACE("| 6 | Congelar el grafo:", "| 6 | Congelar el grafo: lock en npm y uv; en .NET, lock en los ejecutables con `disable` (por defecto) o la política sin lock de §6.4, según el ADR del paso 5; CPM; registros en el repo; restauración estricta en la compuerta, activada en CI. | ACT-ARQ, ACT-OPS | `NU1004` / `EUSAGE` / «needs to be updated» ante deriva; sin lock, `NU1603` como error | §6.4, §7 |")
LINE_REPLACE("| 7 | Construir la imagen de CI", "| 7 | Construir la imagen de CI **desde** los archivos de los pasos 5–6, con sus bases por digest y un bot que proponga los digests nuevos por PR; el devcontainer, si se ofrece, con la misma receta o con etiqueta fija de SDK y SO verificada por `global.json`. | ACT-OPS | La compuerta pasa en la imagen y falla si se desalinea | §8 |")
LINE_REPLACE("| 8 | En la CI: `ContinuousIntegrationBuild`", """| 8a | En la CI, para todo equipo: `ContinuousIntegrationBuild`, `SOURCE_DATE_EPOCH`, registro del entorno (SDK, compilador y runtimes efectivos, digest de la imagen, commit y árbol limpio) y SBOM con alcance declarado. | ACT-OPS | Artefacto, registro del entorno y SBOM publicados juntos | §9 |
| 8b | Si hay un consumidor externo que la verifique, un requisito contractual o un repositorio público: procedencia firmada por la plataforma si el plan lo permite, o con el nivel declarado honestamente. | ACT-OPS | Procedencia verificable con su par firmante/`builder.id` | §9.2.4 |""")
R("Los pasos 1 a 4 resuelven la primera pregunta del caso; 5 a 7, la segunda; 8, la tercera;", "Los pasos 1 a 4 resuelven la primera pregunta del caso; 5 a 7, la segunda; 8a, la tercera; 8b, la misma pregunta cuando quien la hace es un tercero;")
R("restaura con NuGet y ejecuta el hook de git;", "restaura con NuGet y, si su integración de git respeta `core.hooksPath`, ejecuta el hook **[no verificado]** (requiere Windows);")
BEFORE_SECTION_END("## 12. Hoja de ruta", """```yaml
# La hoja de ruta como contrato, para agentes y revisores.
entradas:
  repositorio: el del caso (heredado; CTX-NET o CTX-POLI)
  plataforma: la CI disponible y su plan (protección de rama, atestaciones)
salidas:
  - ".editorconfig, .gitattributes y .git-blame-ignore-revs (pasos 1-3)"
  - "tools/ci/ con la compuerta y .githooks/pre-commit (paso 4)"
  - "global.json, devEngines, .python-version + required-version y el ADR de rollForward (paso 5)"
  - "locks y registros por ecosistema (paso 6)"
  - "imagen de CI con bases por digest y configuración del bot (paso 7)"
  - "registro del entorno y SBOM junto al artefacto (8a); procedencia si corresponde (8b)"
validaciones:
  - "paso 3: tools/verificar-commit-mecanico.sh <sha> CP1252 -> 0 con cambio de contenido"
  - "paso 4: un .cs en cp1252 en un PR -> compuerta en rojo"
  - "paso 5: un SDK distinto del de global.json -> A compatible .NET SDK was not found"
  - "paso 6: manifiesto cambiado sin regenerar el lock -> NU1004 / EUSAGE / needs to be updated"
  - "paso 7: imagen desalineada con los archivos nativos -> compuerta en rojo"
```""")

# ---------------- P-16 · Anexo A ----------------
begin("P-16")
R("y **EA-1** (`Examples/A-plantillas/verificar.sh`) las verifica en conjunto: resolución de `.editorconfig` y `.gitattributes`, compuerta de texto sobre las propias plantillas (21 archivos, 0 violaciones), condición de CI de `Directory.Build.props`, `devEngines`, uv, y sintaxis de JSONC, YAML y del esquema de `dependabot.yml`.",
  "y **EA-1** (`Examples/A-plantillas/verificar.sh`) las verifica en conjunto: resolución de `.editorconfig` y `.gitattributes`, compuerta de texto sobre las propias plantillas, un `dotnet new console` creado dentro del repo, condición de CI de `Directory.Build.props`, lock sólo en los ejecutables, la imagen de A.10 construida con la plantilla `web/` corriendo adentro, `devEngines`, uv, y sintaxis de JSONC, YAML y del esquema de `dependabot.yml`. El esqueleto de compuerta de A.11 **falla a propósito** hasta que se lo reemplaza: copiar las plantillas no instala una red que no detecta nada.")
R("¿El repo es nuevo o heredado ya convertido con BOM (variante B para `*.cs`)?", "¿El repo es nuevo, heredado todavía en cp1252 o heredado ya convertido con BOM (variante B para `*.cs`)? ¿Se acepta normalizar lo que crea `dotnet new console` (`Program.cs` y `.csproj` con BOM) antes del primer commit?")
R("# Variante B (código heredado YA convertido a UTF-8 con BOM): descomentar.", "# Variante B (heredado YA convertido a UTF-8 con BOM, o elegida antes de migrar):\n# descomentar. Con la variante A, lo que crea dotnet new console (Program.cs y el\n# .csproj, con BOM) se normaliza antes del primer commit.")
R("Fuentes: [B43] (llaves, `unset`, la última sección gana, sin comentarios en línea), §5.2.3 (tabla por extensión).", "Fuentes: [B43] (llaves, `unset`, la última sección gana, sin comentarios en línea), §5.2.3 (tabla por extensión). EA-1 paso 1b: un `dotnet new console` dentro del repo deja dos violaciones con la variante A (`Program.cs` y el `.csproj` con BOM) y ninguna después de normalizarlos.")
R("¿el disco tiene que tener LF en todas las máquinas (sí, si se construye en Windows y Linux)?", "¿hay literales multilínea o datos cuyo fin de línea importe en las pruebas de la estación (entonces `eol=lf`; si no, `* text=auto` también vale, §5.2.2)?")
R("¿hay lock files de NuGet (entonces `disable`)?", "¿hay lock files de NuGet (entonces `disable`)? ¿Quién instala el SDK exacto en cada estación Windows?")
AFTER("Variante tolerante, sin lock files: `\"version\": \"8.0.400\", \"rollForward\": \"latestPatch\"` (el parche más alto de la banda 4xx).", " Costo de `disable`: toda estación, la imagen del devcontainer y la de CI necesitan exactamente 8.0.425, y la que tenga otro parche no compila (§6.4). La variante tolerante va con la política sin lock: `NU1603` como error y el SDK registrado en la CI.")
A4_OLD = """  <PropertyGroup>
    <!-- Capa 3: generar y usar packages.lock.json. -->
    <RestorePackagesWithLockFile>true</RestorePackagesWithLockFile>
    <!-- Capa 5: nunca "latest"; omitirlo deja la versión que fija el TFM. -->
    <LangVersion>12.0</LangVersion>
    <!-- Capa 6: URL del repo y commit en el .nuspec; símbolos aparte. -->"""
A4_NEW = """  <PropertyGroup>
    <!-- Política SIN lock (guía, 6.4): descomentar. Una versión inexistente que NuGet
         aproxima corta el restore. Con lock, el lock desarma este aviso (E4-2). -->
    <!-- <WarningsAsErrors>$(WarningsAsErrors);NU1603</WarningsAsErrors> -->
    <!-- Capa 2: el TFM fija la versión de C#. Sólo si hace falta otra, y nunca "latest":
    <LangVersion>12.0</LangVersion> -->
    <!-- Capa 6: URL del repo y commit en el .nuspec; símbolos aparte. -->"""
R(A4_OLD, A4_NEW)
R("""    <AssemblyMetadata Include="ImagenDigest" Value="$(ImagenDigest)" Condition="'$(ImagenDigest)' != ''" />
  </ItemGroup>
</Project>
```

Verificado en EA-1 (paso 2):""", """    <AssemblyMetadata Include="ImagenDigest" Value="$(ImagenDigest)" Condition="'$(ImagenDigest)' != ''" />
  </ItemGroup>
</Project>
```

`Directory.Build.targets` (raíz), para que el lock quede sólo en los ejecutables:

```xml
<Project>
  <!-- Anexo A.4b. El lock que gobierna es el del proyecto en la punta de la cadena.
       Va en .targets y no en .props: cuando se evalúa Directory.Build.props,
       OutputType todavía no está definido y la condición no se cumple nunca. -->
  <PropertyGroup Condition="'$(OutputType)' == 'Exe'">
    <RestorePackagesWithLockFile>true</RestorePackagesWithLockFile>
  </PropertyGroup>
</Project>
```

Verificado en EA-1 (paso 2):""")
R("`LangVersion` puede omitirse (lo fija el TFM) pero nunca valer `latest` [B57].", "`LangVersion` se omite: lo fija el TFM, y un valor fijo para todo el repo deja a un proyecto `net10.0` en C# 12 sin aviso; si hace falta, nunca `latest` [B57]. EA-1 paso 2b: con `Directory.Build.targets`, `packages.lock.json` aparece en el ejecutable y no en la biblioteca, y en modo CI el restore pasa y falla con `NU1004` ante un cambio sin regenerar.")
R("""```jsonc
// Anexo A.9. La etiqueta queda como referencia humana; manda el digest.
{
  "name": "solucion",
  "image": "mcr.microsoft.com/dotnet/sdk:8.0@sha256:78235e09001f52b6592c458ac010775ebac6725422e80cd0c1650590f67b2743",
  "features": {
    // Versión exacta: sin ella la feature instala "lts", que cambia sola.
    "ghcr.io/devcontainers/features/node:1": { "version": "24.21.0" }
  },
  // Hook versionado activado una vez por clon.
  "postCreateCommand": "git config core.hooksPath .githooks && dotnet --version && node --version"
}
```

El `devcontainer-lock.json` lo genera la CLI (`devcontainer up`/`build`) y se versiona; registra las *features*, no la imagen [B121]. Se levanta con `--frozen-lockfile` (E5-5). Fuentes: [B119], [B120], [B137].""", """```jsonc
// Anexo A.9. El devcontainer se construye con la MISMA receta que la imagen de CI (A.10):
// sus bases van por digest y las actualiza el bot de la CI (A.13, ecosistema docker).
// Variante sólo .NET sin receta propia (§8.5): "image": "mcr.microsoft.com/dotnet/sdk:8.0.425-bookworm-slim".
{
  "name": "solucion",
  "build": {
    "dockerfile": "../imagen/Dockerfile",
    "context": "../imagen",
    // Igual a tools/gen/.python-version: la compuerta compara lo instalado con el archivo.
    "args": { "PYTHON_VERSION": "3.12.15" }
  },
  // Hook versionado activado una vez por clon.
  "postCreateCommand": "git config core.hooksPath .githooks && dotnet --version && node --version && uv --version"
}
```

Con `build.dockerfile` no hay *features* ni `devcontainer-lock.json`: lo que se congela es la receta, y sus bases van por digest. Fuentes: [B119], [B136].""")
R("Preguntas: ¿qué digest corresponde a la imagen de la CI (misma base)? ¿Qué *features* hacen falta y con qué versión exacta? ¿El host es Linux (entonces `remoteUser` + `updateRemoteUserUID` [B119])?",
  "Preguntas que guían los campos: ¿la imagen de desarrollo comparte la receta de la CI (solución políglota) o basta una etiqueta fija de SDK y SO (sólo .NET)? ¿Hay un bot que actualice cada digest en un repo privado? ¿El host es Linux (entonces `remoteUser` + `updateRemoteUserUID` [B119])?")
R('# Imagen de desarrollo y CI con los TRES runtimes (variante "imagen única" de N8).', "# Imagen de desarrollo y CI con los TRES runtimes (plantilla del Anexo A; la de N8 difiere sólo en NODE_IMAGE).")
R("ARG NODE_IMAGE=node:22-bookworm-slim@sha256:d649c27dae7ba0137b3cef5dd75baa422c08dc3d9e3fc0c23dfb172dc3cc6436\nARG UV_IMAGE", "ARG NODE_IMAGE=node:24-bookworm-slim@sha256:d6aa754f16b3197301076f047b5def2f02ea1dbbc2ca920407d46d7ec7f87b20\nARG UV_IMAGE")
R("# Base: el SDK de .NET (Debian 12, la misma familia que node:22-bookworm-slim,", "# Base: el SDK de .NET (Debian 12, la misma familia que node:24-bookworm-slim,")
R("Archivo ejecutado en E8-3, E8-5 y E8-6: `Examples/N8-integracion-poliglota/imagen/Dockerfile`.", "La plantilla vive en `Examples/A-plantillas/repo/imagen/Dockerfile` y EA-1 la construye y corre la plantilla `web/` adentro (Node 24.21.0, npm 11.19.0, glibc 2.36 en las dos bases). La de `Examples/N8-integracion-poliglota/imagen/Dockerfile`, usada en E8-3, E8-5 y E8-6, difiere sólo en `NODE_IMAGE`, porque N8 fija Node 22.23.2 en su `.nvmrc`.")
R("""```sh
#!/bin/sh
# Anexo A.11 (esqueleto). La versión completa está en
# Examples/N7-compuertas-y-gobierno/compuerta/compuerta.sh.
# Alcance: --staged (hook), --base <rev> (PR), sin argumentos (todo).
set -eu
echo "compuerta: texto, toolchain y restauración estricta ($*)"
```""", """```sh
#!/bin/sh
# Anexo A.11 (esqueleto). FALLA A PROPÓSITO hasta que se lo reemplaza por la compuerta completa:
# Examples/N7-compuertas-y-gobierno/compuerta/compuerta.sh (un proyecto por ecosistema en la raíz)
# o Examples/N8-integracion-poliglota/solucion/verificar.sh (proyectos en subcarpetas, guía 10.2.2).
# Alcance: --staged (hook), --base <rev> (PR), sin argumentos (todo).
echo "compuerta: esqueleto sin reemplazar; copiá la compuerta completa (Anexo A.11)" >&2
exit 1
```""")
LINE_REPLACE("Activación, una vez por clon: `git config core.hooksPath .githooks` [B37]. La compuerta completa", """**Qué se copia y adónde.** A `tools/ci/`: `compuerta.sh` de `Examples/N7-compuertas-y-gobierno/compuerta/` y `check_text_policy.py` de `Examples/N2-politica-de-texto-y-remediacion/tools/`; o, si los proyectos viven en subcarpetas, `verificar.sh` de N8 con su inventario de rutas (§10.2.2). A `.githooks/`: el hook de arriba. Activación, una vez por clon: `git config core.hooksPath .githooks` [B37].

**Prerrequisitos de cada estación**, para que el hook no dé un falso rojo: `bash` (en Windows, el de Git for Windows); `python3` con el paquete `EditorConfig==0.17.1`; y, para los pasos de toolchain y grafo, las herramientas que el repo declara (`dotnet`, `node`/`npm`, `uv`). En Windows se corre desde Git Bash, en la raíz del clon: `bash tools/ci/compuerta.sh --staged` **[no verificado]** (requiere Windows). La alternativa sin Python para el paso de texto es editorconfig-checker (§5.2.5).""")
R("¿la imagen del job es la misma receta que el devcontainer, por digest?", "¿la imagen del job sale de la misma receta que el devcontainer (A.10), publicada y nombrada por digest? ¿La revisión de dueños es obligatoria sobre `.github/` y `tools/ci/` (§10.2.7)?")
R("    # Misma receta que el devcontainer, por digest (completar).", "    # Imagen construida desde imagen/Dockerfile (A.10), la misma receta que el devcontainer (A.9),\n    # publicada en el registro del equipo y nombrada por digest (completar).")
R("¿El repo es privado (el ecosistema `devcontainers` no está soportado ahí [B107])?", "¿El repo es privado (el ecosistema `devcontainers` no está soportado ahí [B107])? ¿Qué Dockerfile tiene bases por digest (ecosistema `docker`)?")
BEFORE('  - package-ecosystem: "github-actions"', '  - package-ecosystem: "docker"\n    directory: "/imagen"\n    schedule:\n      interval: "monthly"\n')
R("Para imágenes por digest, Renovate documenta `pinDigests` [B108]; que Dependabot `docker` actualice un `FROM …@sha256` no está verificado.",
  "Para las bases por digest de `imagen/Dockerfile` (A.10), el ecosistema `docker`: Docker documenta que Dependabot actualiza etiqueta y digest [B113]; la página de GitHub no menciona digests [B107] y el laboratorio no lo observó **[no verificado]** (requiere la plataforma). Renovate documenta `pinDigests` [B108]. `devcontainers` no se incluye: no está soportado en repositorios privados [B107], y el devcontainer de A.9 hereda las bases de A.10.")
R("¿La aprobación del dueño es obligatoria en el plan del equipo [B177][B185]?", "¿La aprobación del dueño es obligatoria en el plan del equipo (en GitHub, para una organización privada, desde Team; en GitLab, Premium) [B176][B177][B185]?")
R("# (merge commit: un squash o un rebase cambiarían el SHA).", "# (con squash, un PR por commit: el SHA es el del squash ya en main; guía 5.2.6).")

# ---------------- P-17 · Anexo B ----------------
begin("P-17")
R("- [ ] Activé el hook una vez en este clon: `git config core.hooksPath .githooks`. (§10.2.3)", "- [ ] Tengo los prerrequisitos del hook (`bash`, `python3` con `EditorConfig==0.17.1`, y las herramientas que el repo declara) y lo activé una vez en este clon: `git config core.hooksPath .githooks`. (A.11, §10.4)")
R("- [ ] Tengo instalado el SDK exacto de `global.json`; si Visual Studio trae otro, instalé el independiente. (§6.2.2)", "- [ ] Si `global.json` usa `rollForward: disable`, tengo instalado ese SDK exacto (si Visual Studio trae otro, el independiente); si no, un SDK de la banda. (§6.4)")
R("- [ ] Corro la compuerta antes del push; si da rojo", "- [ ] Corro la compuerta antes del push (en Windows, desde Git Bash); si da rojo")
R("- [ ] Después de una migración de codificación, refresqué mi working tree una vez. (§5.2.6)", "- [ ] Después de una migración de codificación, con el árbol limpio (commit o `git stash`) y la migración ya traída, refresqué mi working tree una vez. (§5.2.6, paso 5)")
R("- [ ] La elección de `rollForward` está escrita en un ADR, coherente con el uso de lock files. (§6.4)", "- [ ] La política de §6.4 (con lock y `disable`, o sin lock con `latestPatch` y `NU1603` como error) está escrita en un ADR con su costo. (§6.4)")
R("- [ ] Cada ejecutable tiene lock; las bibliotecas que se publican, no. CPM centraliza las versiones directas. (§7.2.1)", "- [ ] Con la política con lock, cada ejecutable tiene su lock (`Directory.Build.targets`, A.4); los proyectos comunes no lo necesitan. CPM centraliza las versiones directas. (§7.2.1)")
R("- [ ] Toda imagen (CI, devcontainer, ejecución) va por digest, y un bot o un trabajo propone el digest nuevo por PR con cadencia al menos mensual. (§8.2.2)", "- [ ] Toda imagen que construye artefactos publicados va por digest, y un bot o un trabajo propone el digest nuevo por PR con cadencia al menos mensual; el devcontainer usa la misma receta o una etiqueta fija verificada por `global.json`. (§8.2.2)")
R("- [ ] Se generan SBOM y procedencia junto al artefacto; el nivel SLSA declarado coincide con lo que la plataforma firma. (§9.2.4)", "- [ ] Se graban el registro del entorno y el SBOM junto al artefacto; si un consumidor la verifica, la procedencia lleva el nivel SLSA que la plataforma realmente da. (§9.2.4, §12 pasos 8a y 8b)")

# ---------------- P-18 · Anexo C ----------------
begin("P-18")
R("| EOL | Final de línea: LF o CRLF. | §4.1 |\n", "")
R("| **Final de línea** (EOL) |", "| **Fin de línea** (EOL) |")
R("| Índice / working tree | Lo que git guarda / lo que está en disco. | §5.1 |", "| Índice (git) / working tree | Lo que git guarda y compara / lo que está en disco. No confundir con el índice de paquetes. | §5.1 |")
R("| Pieza (artefacto) | Lo que sale de la build, identificado por digest. | §9.1 |\n", "")
R("| Procedencia (*provenance*) | Atestación de cómo, dónde y por quién se construyó una pieza. |", "| Procedencia (*provenance*) | Atestación de cómo, dónde y por quién se construyó un artefacto. |")
R("| SBOM | Inventario de componentes de una pieza. |", "| SBOM | Inventario de componentes de un artefacto. |")
NUEVAS = """| Aislar de `blame` | Listar el SHA de un commit mecánico en `.git-blame-ignore-revs` para que `git blame` atribuya las líneas a sus autores. | §5.1 |
| Archivo nativo de versión | El que lee la herramienta del propio ecosistema (`global.json`, `.nvmrc`/`engines`, `.python-version`/`requires-python`), frente al de un gestor de terceros. | §11.1 |
| Artefacto | Lo que sale de la build y se distribuye, identificado por digest. El caso lo llama «pieza». | §9.1 |
| BuildKit | Motor de build de Docker; genera SBOM y procedencia SLSA de lo que construye. | §9.2.4 |
| Corepack | Herramienta de Node que hace cumplir `packageManager`; experimental y fuera de la distribución de Node desde la 25. | §6.2.3 |
| CycloneDX | Formato de SBOM normalizado como ECMA-424. | §9.2.3 |
| `devcontainer-lock.json` | Lock de las *features* de un devcontainer; no registra la imagen base. | §8.1 |
| Dueño del código | Revisor que la plataforma pide cuando un PR toca ciertas rutas (`CODEOWNERS`). | §10.1 |
| Fin de línea (EOL) | LF o CRLF; en plural, «finales de línea». | §4.1 |
| Grafo resuelto | Directas y transitivas con una versión concreta cada una, en un momento dado. | §7.1 |
| Imagen de desarrollo / de CI / de ejecución | La del desarrollador, la que compila en CI y la que corre la aplicación. | §8.1 |
| Imagen multi-runtime / por componente | Una imagen con los tres toolchains, o una oficial por ecosistema con las salidas pasadas entre etapas. | §11.1 |
| Índice de paquetes | Registro del que se descargan paquetes (en Python, *index*); sinónimo de registro. | §7.1 |
| in-toto | Formato de atestación (`subject`, `predicateType`, `predicate`) que usa la procedencia SLSA. | §9.1 |
| Integridad | Comprobar que los bytes descargados son los que registró el lock. | §7.1 |
| Metadatos embebidos | Datos de origen grabados dentro del artefacto (SHA del commit, URL del repo). | §9.1 |
| Monorepo | Varios proyectos versionados juntos; no implica una herramienta. | §11.1 |
| Orquestador | Quien decide el orden de los pasos de la build y los ejecuta. | §11.1 |
| Política de texto | Para cada tipo de archivo: codificación, BOM y fin de línea, declarados y verificados. | §5.1 |
| Resolución libre | Instalación que, si el manifiesto cambió, vuelve a resolver y reescribe el lock. | §7.1 |
| RID | *Runtime identifier*: plataforma de destino de .NET (`win-x64`, `linux-x64`); forma parte del lock de NuGet. | §7.2.1 |
| Runtime | Lo que ejecuta el programa; en .NET se elige al ejecutar, no lo fija el SDK. | §6.1 |
| SLSA | *Supply-chain Levels for Software Artifacts*: niveles de garantía de la build y su procedencia. | §9.2.4 |
| Source Link | Mapa en el PDB de cada archivo fuente a su URL en el repositorio y el commit. | §9.2.1 |
| SPDX | Formato de SBOM; la versión 2.2.1 está normalizada como ISO/IEC 5962:2021. | §9.2.3 |"""
import unicodedata
def _k(row):
    t = row.split("|")[1].strip()
    t = re.sub(r"[`*«»¿]", "", t)
    t = "".join(c for c in unicodedata.normalize("NFD", t) if unicodedata.category(c) != "Mn")
    return t.lower()
L = lines()
h = L.index("## Anexo C. Glosario")
s0 = h + 4  # primera fila de datos (tras encabezado y separador)
assert L[h + 2].startswith("| Término |") and L[h + 3].startswith("|---")
e0 = s0
while L[e0].startswith("|"):
    e0 += 1
filas = L[s0:e0]
nuevas = NUEVAS.split("\n")
ins = 0
for nf in nuevas:
    kk = _k(nf)
    pos = next((i for i, f in enumerate(filas) if _k(f) > kk), len(filas))
    filas.insert(pos, nf); ins += 1
L[s0:e0] = filas
setlines(L); LOG.append(("P-18", "glosario: filas insertadas en orden alfabético", True, str(ins)))
R("en SLSA, desde el nivel L2", "en SLSA (*Supply-chain Levels for Software Artifacts*), desde el nivel L2")
R("un SBOM puede describir", "un SBOM (*software bill of materials*, inventario de componentes) puede describir")

# ---------------- P-20 · Anexo E ----------------
begin("P-20")
R("Fecha de todas las corridas: 2026-10-07, Linux x86_64 con Docker.", "Fecha de las corridas: 2026-10-07 (las ampliaciones de la revisión, 2026-10-09), Linux x86_64 con Docker. Los IDs siguen el esquema `E<n>-<m>` de la guía; donde una carpeta o un archivo usan otra numeración (`E1-N1-01` en los scripts de N1; carpetas `e1-…` a `e6-…` de N2 que no coinciden con el ID; `V7-01`, la medición de tiempo de E7-5b), la fila lo dice. Las rutas son relativas a esta guía.")
L = lines()
for m in range(1, 7):
    idx = [i for i, l in enumerate(L) if l.startswith(f"| E3-{m} |")]
    if len(idx) != 1:
        LOG.append(("P-20", f"E3-{m}", False, str(len(idx)))); continue
    cells = L[idx[0]].split(" | ")
    last = cells[-1]
    if last.rstrip(" |") in ("`README.md` de la carpeta", "ídem"):
        cells[-1] = f"`Examples/N3-fijacion-del-toolchain/salidas/E3-{m}.txt` (también pegada en `N3-…/README.md`) |"
        L[idx[0]] = " | ".join(cells); LOG.append(("P-20", f"E3-{m} salida", True, ""))
    else:
        LOG.append(("P-20", f"E3-{m} salida", False, last))
setlines(L)
R("| E1-04 | Razor con cp1252 → U+FFFD |", "| E1-04 | Razor con cp1252 → U+FFFD en literales; `RZ1005`/`CS1056` en identificadores |")
R("| E1-05 | Node: módulos, `fs`, `JSON.parse`, `TextDecoder` |", "| E1-05 | Node: módulos, `fs`, `JSON.parse`, `TextDecoder`; identificador cp1252 → `SyntaxError` |")
R("| E1-12 / E1-13 | Categorías Unicode; cp1252 frente a Latin-1; `file` |", "| E1-12 / E1-13 | Categorías Unicode; cp1252 frente a Latin-1; `file`; un cp1252 que forma UTF-8 válido sale como UTF-8 |")
R("| E2-2 | Migración en tres commits; verificación mecánica; `blame` |", "| E2-2 | Migración en tres commits; verificación mecánica; `blame`; fusión por *squash* con un PR por commit |")
R("| E3-2 | SDK → compilador; TFM → C#; runtime al ejecutar; `LangVersion=latest` |", "| E3-2 | SDK → compilador; TFM → C#; runtime al ejecutar; `LangVersion=latest`; inspección de los *targets* del SDK 8 y 10 (compilador en Visual Studio) |")
R("| E3-3 | `engines`, `engine-strict`, `devEngines`, Corepack (Node 22/24/26) |", "| E3-3 | `engines`, `engine-strict`, `devEngines`, Corepack (Node 22/24/26); pnpm ≥ 11 y `pmOnFail` sin Corepack |")
R("| E4-2 | CPM y *transitive pinning* |", "| E4-2 | CPM y *transitive pinning*; versión inexistente con y sin lock y con `NU1603` como error, SDK 8 y 10 |")
R("| E4-4 | npm y pnpm |", "| E4-4 | npm, pnpm y Yarn (multiplataforma) |")
R("| E8-3 | Frontera de la build |", "| E8-3 | Frontera de la build; `devEngines` sin `onFail` |")
R("| E8-6 | SBOM multi-ecosistema, nativos unidos, BuildKit con procedencia |", "| E8-6 | SBOM multi-ecosistema, nativos unidos, BuildKit con procedencia; el comando de §11.5 tal como está escrito |")
R("| EA-1 | Todas las plantillas del Anexo A, juntas |", "| EA-1 | Todas las plantillas del Anexo A, juntas; `dotnet new console`, lock sólo en ejecutables, imagen A.10 |")
AFTER("| E2-6 | Plantillas del SDK 8 y 10; `dotnet format`; `dotnet sln add` | `…/N2-…/e6-plantillas-dotnet/` | `e6-plantillas-dotnet.txt` |", """
| E2-7 | editorconfig-checker contra el `.editorconfig` de §5.5 | `Examples/N2-politica-de-texto-y-remediacion/e7-editorconfig-checker/` | `…/salidas/e7-editorconfig-checker.txt` |
| E2-8 | `.gitattributes`, `charset`, locks y `rollForward` en seis repos `dotnet/*` (2026-10-07) | `…/N2-…/e8-repos-de-referencia/` | `e8-repos-de-referencia.txt` |""")

# ---------------- P-21 · Anexo F ----------------
begin("P-21")
AFTER("Siguiendo la separación entre hechos e interpretaciones, esta lista reúne lo que la guía **no** afirma como hecho.", """

**Qué pedido cubre cada sección.** Los identificadores del campo `traces` del encabezado:

| ID | Pedido | Sección |
|---|---|---|
| P-01 | Código en cp1252 que en Linux falla al compilar y corrompe acentos; en Windows funciona | §1, §4.2.1–§4.2.2 |
| P-02 | Desarrollo simultáneo con Visual Studio en Windows, Linux y devcontainers | §2.1, §8.2.4 |
| P-03 | Criterio de codificación unificado, sin commits de BOM | §5, §10.2.5, A.1, A.2 |
| P-04 | Congelar paquetes NuGet | §7 |
| P-05 | Congelar versiones de compilador y SDK | §6 |
| P-06 | ¿Se puede con contenedores? | §3.5, §8 |
| P-07 | Integrarlo con herramientas en Windows y Linux | §8.2.4, §10, §12 |
| P-08 | Saber con qué entorno se ensambló cada artefacto | §3.2 (capa 6), §9 |
| P-09 | Estrategias de la industria para .NET, Node.js y Python | «Qué propone la industria» de §4–§10 |
| P-10 | Qué pasa al integrarlos en una única solución | §11 |
| R-01 | Secciones jerárquicas, definiciones, ejemplos, diagramas | índice; n.1 de cada capítulo; diagramas |
| R-02 | Autocontenida | toda la guía; Anexo C |
| R-03 | Snippets y preguntas guía que forman criterio | n.5, n.6 y n.9 de §3–§11; Anexo A |
| R-06, R-07 | Sin inventar; toda afirmación con evidencia | marcas de §0.3; Anexos D, E y F |
| R-PROF | Marco de referencia, mapa conceptual, estructura común, anexos | §2, §3.6, §4–§11, Anexos A–C |
| R-PRIV | Sin identificadores del caso privado | §1 (ejemplo sintético) |""")
R("- La rama Windows del mecanismo de Roslyn (ACP 1252 y ACP UTF-8), §4.2.1.", "- La rama Windows del mecanismo de Roslyn (ACP 1252), y la estación con ACP UTF-8, que queda como pregunta abierta porque la prueba de [B15] contradice la deducción de [B19] (§4.2.1).")
R("si Dependabot `docker` actualiza un `FROM …@sha256`;", "si Dependabot `docker` actualiza un `FROM …@sha256` (Docker lo documenta [B113]; GitHub no lo menciona [B107]);")
AFTER("- El modo UTF-8 por defecto de Python 3.15 en una versión real (final prevista para el 2026-10-09).", """
- Qué compilador usa realmente Visual Studio con el SDK 8 y el 10 (§6.2.2; sólo se inspeccionaron los *targets*).
- Los prerrequisitos y comandos de la compuerta y la migración desde Git Bash en Windows (§5.2.6, §10.4, A.11).
- La firma sin clave con cosign y cómo completar `builder.id` en BuildKit (§9.2.4).""")
R("- Que el ciclo típico de un «commit de BOM» sea el descrito en §4.2.6 (inferido de los defaults documentados).", "- Que el ciclo típico de un «commit de BOM» sea el descrito en §4.2.6, marcado **[interpretación]** (inferido de los defaults documentados).")
R("**Pendiente de decisión de la mesa.** Si la guía recomienda un formato único de SBOM por defecto (CycloneDX o SPDX) o deja la elección al consumidor, como hace hoy (§9.2.3).", "**Formato de SBOM.** La guía recomienda un solo formato por solución, el que pida el consumidor, y CycloneDX cuando nadie pide otro (§9.2.3).")
