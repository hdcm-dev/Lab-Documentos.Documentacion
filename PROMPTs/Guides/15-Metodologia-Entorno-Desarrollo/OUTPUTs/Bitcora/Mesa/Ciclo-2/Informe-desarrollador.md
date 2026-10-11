# Mesa · Ciclo 2 · Informe del especialista «Desarrollador de código»

> Fecha: 2026-10-09. Artefacto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (1.0.0-rc.1, 3391 líneas).
> Mandato: snippets y plantillas correctos y copiables; experimentos corridos en docker; snippets que no compilan, rutas rotas, comandos que fallan.
> Revisión a ciegas: no se leyeron informes del ciclo 2. Del ciclo 1 sólo `05-Aplicacion.md` (decisiones y deuda D-1…D-7, que no se re-litigan).
> Todas las corridas se hicieron sobre copias en el scratchpad de la sesión; no se modificó `Examples/`.

## Hallazgos

### desarrollador-01 · S2 · E1 — La imagen de A.10, usada como contenedor del workflow de A.12, deja la compuerta en rojo y la compuerta lo informa como violación de política

- **Ubicación:** Anexo A.10 (Dockerfile, ~L2690–2730), A.11 «Prerrequisitos de cada estación» (~L2756), A.12 (`container:` ~L2775).
- **Ancla:** A.12: «Imagen construida desde imagen/Dockerfile (A.10), la misma receta que el devcontainer (A.9)»; A.11: «`python3` con el paquete `EditorConfig==0.17.1`».
- **Experimento:** construir `Examples/A-plantillas/repo/imagen/Dockerfile` con `--build-arg PYTHON_VERSION=3.12.15`; copiar a `tools/ci/` la `compuerta.sh` de N7 y `check_text_policy.py` de N2 (como manda A.11); `git init` + commit; correr con `CI=true` dentro de la imagen.

```text
$ docker run --rm c2-a10:local sh -c 'python3 -c "import editorconfig"; echo import_rc=$?'
ModuleNotFoundError: No module named 'editorconfig'
import_rc=1
$ docker run ... -e CI=true c2-a10:local sh -c 'tools/ci/compuerta.sh; echo rc=$?'
    ModuleNotFoundError: No module named 'editorconfig'
COMPUERTA [FALLA] texto: la política de .editorconfig/.gitattributes no se cumple
COMPUERTA [ok]    toolchain .NET: SDK 8.0.425 = global.json
COMPUERTA [ok]    toolchain Node: 24.21.0 cumple .nvmrc=24.21.0
COMPUERTA resultado=ROJO (1 paso/s)
rc=1
```

- **Impacto:** quien copie A.10 + A.11 + A.12 tal cual obtiene una CI siempre roja, y con el mensaje que §10.2.2 dice evitar («una herramienta que falta NO es una violación»): la verificación de L13 (ciclo 1) cubrió la falta de `python3`, no la del módulo. EA-1 no lo detecta porque no corre la compuerta dentro de la imagen.
- **Dirección:** (a) en A.10, instalar el paquete en el intérprete de la imagen (p. ej. `uv pip install --system --python "$PYTHON_VERSION" EditorConfig==0.17.1`, o `python3 -m pip install EditorConfig==0.17.1`: la imagen trae pip 26.2.1) y re-verificar en EA-1 corriendo la compuerta completa dentro de la imagen; (b) en `compuerta.sh`, chequear `python3 -c 'import editorconfig'` como prerrequisito, con el mismo mensaje «falta …, no una violación».

### desarrollador-02 · S2 · E1 — El `postCreateCommand` de A.9 falla en un host Linux: `git` en el contenedor (root) rechaza el repo del usuario

- **Ubicación:** Anexo A.9 (`postCreateCommand`), y por el mismo mecanismo §8.5 (imagen del SDK, también root).
- **Ancla:** `"postCreateCommand": "git config core.hooksPath .githooks && dotnet --version && node --version && uv --version"`.
- **Experimento:** copia de `Examples/A-plantillas/repo`, `git init` + commit con el UID del host (1000), `npx -y @devcontainers/cli@0.89.0 up --workspace-folder .` (la CLI y versión que la guía usa en §8.5):

```text
Running the postCreateCommand from devcontainer.json...
fatal: not in a git directory
postCreateCommand from devcontainer.json failed with exit code 128.
{"outcome":"error", ... "description":"postCreateCommand from devcontainer.json failed."}
$ devcontainer exec ... sh -c 'id -u; git status'
0
fatal: detected dubious ownership in repository at '/workspaces/dc'
```

- **Impacto:** el hook no queda activado (la frase «Hook versionado activado una vez por clon» es falsa en ESC-04 sobre Linux) y el devcontainer termina con `outcome: error`. La propia guía documenta la causa en §8.2.5 (fila `dubious ownership`, E5-3) pero la plantilla no la aplica. No se probó con la extensión de VS Code, que podría agregar `safe.directory` por su cuenta **[no verificado]**.
- **Dirección:** anteponer `git config --global --add safe.directory "${containerWorkspaceFolder}"` en el `postCreateCommand` de A.9 y §8.5, o fijar `remoteUser` + `updateRemoteUserUID` (la pregunta de A.9 ya lo sugiere) con una imagen que tenga usuario no root; agregar a EA-1 un paso `devcontainer up` que exija `outcome: success`.

### desarrollador-03 · S3 · E1 — El remedio de §0.4 (`DOCKER_CONFIG=$(mktemp -d)`) cambia el plugin `buildx` y rompe el comando de digest de §8.5

- **Ubicación:** §0.4 (párrafo bajo el bloque, ~L109) y §8.5 (`docker buildx imagetools inspect … --format '{{.Manifest.Digest}}'`, ~L1481); afecta igual a `E5-2/experimento.sh`.
- **Ancla:** «`export DOCKER_CONFIG=$(mktemp -d)` permite descargar las imágenes en modo anónimo».
- **Experimento (host de la corrida):**

```text
$ docker buildx version
github.com/docker/buildx v0.35.0 ...            # plugin de ~/.docker/cli-plugins
$ DOCKER_CONFIG=$(mktemp -d) docker buildx version
github.com/docker/buildx 0.13.1+ds1 0.13.1+ds1-3  # cae al plugin del sistema
$ docker buildx imagetools inspect mcr.microsoft.com/dotnet/sdk:8.0 --format '{{.Manifest.Digest}}'
sha256:ec9c0a0dc5f60adc2065762050638dd5ed5facfc53716d4580a42d86027c8e80
$ R=$(DOCKER_CONFIG=$(mktemp -d) docker buildx imagetools inspect mcr.microsoft.com/dotnet/sdk:8.0 --format '{{.Manifest.Digest}}'); printf '%s\n' "$R" | wc -l
16          # imprime el inspect completo (Name:, MediaType:, …), no el digest
```

- **Impacto:** el directorio de configuración también es donde el cliente busca los plugins instalados por el usuario; vaciarlo cambia en silencio la versión de `buildx` con la que corren E5-2, §8.5 y §11.5 (en E5-2, `REMOTO` deja de ser un digest y la comparación da «se MOVIÓ» por la razón equivocada).
- **Dirección:** en §0.4, advertir el efecto y dar una alternativa que conserve los plugins (p. ej. `D=$(mktemp -d); ln -s ~/.docker/cli-plugins "$D/"; export DOCKER_CONFIG=$D`, o `docker logout <registro>`); en §8.5, declarar la versión de buildx con la que se probó el `--format`.

### desarrollador-04 · S3 · E1 — El `.pre-commit-config.yaml` de §10.5 perdió `minimum_pre_commit_version` y falla en pre-commit < 4.4

- **Ubicación:** §10.5, segundo bloque (~L1954–1975).
- **Ancla:** `language: unsupported`; el original del laboratorio (`N7-…/02-pre-commit-y-politica/pre-commit-alineado.yaml`) lleva `minimum_pre_commit_version: "4.4.0"     # "unsupported" no existe en versiones viejas`, que el bloque de la guía omite.
- **Experimento** (python:3.12-slim, repo con sólo el hook local del bloque):

```text
== pre-commit 4.3.0
=====> Expected one of conda, coursier, dart, docker, docker_image, dotnet, fail, golang, haskell, julia, lua, node, perl, pygrep, python, r, ruby, rust, script, swift, system but got: 'unsupported'
== pre-commit 4.4.0
compuerta del entorno....................................................Passed
```

- **Impacto:** el bloque se presenta como copiable; en una estación con pre-commit anterior a 4.4 el error no dice qué versión hace falta.
- **Dirección:** restituir `minimum_pre_commit_version: "4.4.0"` en el bloque (con el comentario), que además lo deja igual al archivo ejecutado en E7-2 salvo las exclusiones ya declaradas.

### desarrollador-05 · S3 · E2 — `SOURCE_DATE_EPOCH` como «paso común al principio del job» no llega a los pasos siguientes en GitHub Actions

- **Ubicación:** §9.5, bloque `sh` (~L1702–1706); A.12 (los dos `run:` con `export SOURCE_DATE_EPOCH=… && tools/ci/compuerta.sh`).
- **Ancla:** «# Paso común al principio del job de CI, para los tres ecosistemas.» / `export SOURCE_DATE_EPOCH=$(git log -1 --pretty=%ct)`.
- **Fuente:** GitHub Docs, *Workflow commands* (https://docs.github.com/en/actions/reference/workflows-and-actions/workflow-commands, consultado 2026-10-09): «You can make an environment variable available to any subsequent steps in a workflow job by … writing this to the `GITHUB_ENV` environment file». Cada `run:` es su propio proceso de shell; un `export` no sobrevive al paso.
- **Impacto:** puesto como paso propio al principio del job —que es lo que dice el comentario—, los pasos de `dotnet pack`, `npm pack` o `uv build` no ven la variable y la promesa «dos builds del mismo commit incrustan la misma fecha» no se cumple. En A.12 el `export` sólo alcanza a la compuerta, que no construye nada.
- **Dirección:** en §9.5, dar la forma de Actions (`echo "SOURCE_DATE_EPOCH=$(git log -1 --pretty=%ct)" >> "$GITHUB_ENV"`) y aclarar que el `export` vale dentro de un mismo script (`build.sh`); en A.12, un paso previo con `$GITHUB_ENV` en lugar del `export` en línea.

### desarrollador-06 · S4 · E1 — El Anexo A no trae `.gitignore`, y el propio EA-1 commitea `obj/`

- **Ubicación:** Anexo A (no hay plantilla ni mención de `.gitignore` en toda la guía: `grep -n gitignore` → 0); `Examples/A-plantillas/repo/` tampoco lo tiene.
- **Ancla (salida de EA-1, paso 7, corrida 2026-10-09):** `warning: in the working copy of 'src/App/obj/Debug/net8.0/.NETCoreApp,Version=v8.0.AssemblyAttributes.cs', CRLF will be replaced by LF the next time Git touches it`.
- **Impacto:** §11.8 dice que el Anexo A forma «un repositorio políglota mínimo»; copiado y con `git add -A` (lo que hace EA-1) entran `bin/`, `obj/`, `node_modules/`, y la compuerta de texto y los revisores (A.14) cargan con archivos generados.
- **Dirección:** agregar A.17 `.gitignore` (bin/, obj/, node_modules/, .venv/, __pycache__/, dist/) a la guía y a `A-plantillas/repo/`, e incluirlo en el `diff` byte a byte de EA-1.

### desarrollador-07 · S4 · E1 — Dos «extractos» que alteran líneas del original

- **Ubicación:** §1.2, bloque de salida (~L138) y §11.5, «extracto de `solucion/verificar.sh`» (~L2311–2313).
- **Ancla:** §1.2 manda correr `docker run --rm -u "$(id -u):$(id -g)" -e HOME=/tmp -v "$PWD":/w …`, pero la salida muestra `$ docker run --rm -v "$PWD":/w -w /w mcr.microsoft.com/dotnet/sdk:8.0 sh e1-roslyn.sh`. §11.5 muestra `dotnet restore src/Saludo --locked-mode` donde el archivo dice `dotnet restore src/Saludo --locked-mode -v q --nologo || fallas=$((fallas+1))` (L25; igual para npm y uv).
- **Impacto:** §0.3 dice que un extracto «nunca altera una línea mostrada». En §11.5, sin el `|| fallas=…`, el bloque copiado no acumula fallas ni falla la compuerta (sin `set -e`, sale con el código del último comando).
- **Dirección:** en §1.2, mostrar el mismo comando que se manda correr (o rotular la línea `$` como la de la corrida registrada); en §11.5, copiar las tres líneas completas o marcar el bloque como ilustrativo.

## Revisado y bien

1. **§1.2 y §0.4 corren tal cual.** En copia limpia, no root: `generar.py` + `e1-roslyn.sh` con SDK 8.0.425 dan `build OK … U+ : FFFD 006E 003A` y `error CS1056: Unexpected character '�'`; N0 `rc=0` en 1 min 22 s (la guía dice «~1,5 minutos»); EA-1 `rc=0`, `POLITICA-TEXTO: 23 archivo(s) revisado(s), 0 violación(es)`, `NU1004` en modo CI y `EBADDEVENGINES` con Node 22.23.2, igual a §5.5, §6.5 y A.4.
2. **Snippet de Node de §4.5.** Con Node 22.23.2: JSON con BOM → `{ a: 'ó' }`; con un byte cp1252 → `TypeError: The encoded data was not valid for encoding utf-8`. Hace lo que el comentario promete.
3. **SHA fijados.** `git ls-remote` (2026-10-09): `actions/attest` `refs/tags/v4.2.2` = `1e69f48acb82d1966a394da916b4c1698aa569d6` (§9.5) y `pre-commit/pre-commit-hooks` `refs/tags/v6.0.0` = `3e8a8703264a2f4a69428a0aa4dcb512790b2c8c` (§10.5).

## Solicitudes de convocatoria

- Ninguna fuera de mandato.
