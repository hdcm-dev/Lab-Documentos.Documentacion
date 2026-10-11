# Informe del especialista: Desarrollador de código (ciclo 1)

- Fecha: 2026-10-07
- Mandato: snippets y plantillas correctos y copiables; ejecutar experimentos del laboratorio; detectar snippets que no compilan, rutas rotas o comandos que fallan.
- Revisión a ciegas: no se leyeron informes de otros especialistas del ciclo.
- Objeto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (3060 líneas) y `Examples/`.
- Corridas propias: en copias dentro del scratchpad de la sesión (el laboratorio no se modificó), con Docker en Linux x86_64.

## Qué se ejecutó

| Prueba | Resultado |
|---|---|
| Existencia de las 31 rutas `Examples/...` citadas en la guía | 31/31 existen |
| Bloques del Anexo A comparados byte a byte con `Examples/A-plantillas/repo/` y `N8-.../imagen/Dockerfile` | 19/19 idénticos |
| `Examples/A-plantillas/verificar.sh` (EA-1) | rc=0; salida idéntica a `salidas/EA-1-plantillas.txt` |
| `Examples/N0-.../correr-todo.sh` en copia | rc=0, 1m24s; diferencias sólo en rutas temporales, tiempos, hashes con `Deterministic=false` y sellos UTC |
| §1.2 `docker run ... sh e1-roslyn.sh` en copia limpia de N1 | falla sin `generar.py` (hallazgo 02); con `generar.py` reproduce CS1056 y U+FFFD |
| §4.5 diagnóstico POSIX y `TextDecoder` de Node 24.21.0 | funcionan como dice la guía |
| §6.5 `global.json` con comentarios en SDK 8.0.425 | lo acepta y lo respeta (con 8.0.999, `dotnet --version` falla) |
| §6.5 `package.json` con comentarios en npm 11 | `EJSONPARSE` (hallazgo 06) |
| §10.5 `.pre-commit-config.yaml` con pre-commit 4.6.2 | 3 hooks Passed; respeta BOM de `.razor`/`.ps1` y lock sin salto final |
| §11.5 `docker buildx build ...` textual | falla (hallazgo 04) |
| `git ls-remote` de `actions/checkout`, `pre-commit-hooks`, `actions/attest` | SHAs de A.12 y §10.5 correctos |

## Hallazgos

### desarrollador-01 — S2 — E1 — Anexo A.10 contradice A.7, A.9 y `.nvmrc`: la imagen multi-runtime trae Node 22 y la plantilla exige Node 24

- **Ubicación**: Anexo A.10 (línea ~2441, `ARG NODE_IMAGE=node:22-bookworm-slim@sha256:d649…`) frente a A.7 (`"engines": { "node": ">=24 <25" }`, `devEngines … "onFail": "error"`, «`.nvmrc` … `24.21.0`») y A.9 (feature `node:1` con `"version": "24.21.0"`).
- **Ancla**: la propia A.10 dice «Las versiones deben coincidir con los archivos del repo (global.json, .nvmrc, tools/gen/.python-version)». El paso 3 de EA-1, que corrí otra vez, usa la imagen construida con ese Dockerfile (`lab-n8-poliglota:local`):

  ```text
  == 3. Node: devEngines + engine-strict
    v24.21.0 npm 11.19.0: rc=0
    v22.23.2 npm 10.9.8: rc=1 EBADDEVENGINES
  ```

  `Examples/A-plantillas/repo/.nvmrc` = `24.21.0`; `Examples/N8-integracion-poliglota/solucion/.nvmrc` = `22.23.2`.
- **Impacto**: el anexo se presenta como un juego que «funciona junto», pero quien copie A.7, A.9, A.10 y A.12 obtiene una imagen de CI que no pasa `npm install` en la plantilla y un devcontainer con Node 24 frente a una CI con Node 22. Es el «imagen dev ≠ imagen CI» que la guía combate en §8.2.6.
- **Dirección**: alinear A.10 con el resto del anexo: `node:24-bookworm-slim@sha256:<digest>`, con base Debian 12 compartida con `sdk:8.0` (hay que verificar la glibc). La otra salida es declarar que A.10 pertenece a la solución N8, con Node 22, y no al juego A. En cualquiera de los dos casos, sumar a EA-1 un paso que construya A.10 y corra la plantilla `web/` adentro.

### desarrollador-02 — S3 — E1 — El comando de §1.2 falla en un clon limpio: falta `generar.py` y no dice desde qué carpeta se corre

- **Ubicación**: §1.2, bloque `text`: `$ docker run --rm -v "$PWD":/w -w /w mcr.microsoft.com/dotnet/sdk:8.0 sh e1-roslyn.sh`.
- **Ancla**: corrida en una copia de N1 sin `work/`, que `N1-…/.gitignore` excluye:

  ```text
  SDK: 8.0.425  |  TF=net8.0  |  LANG=<vacío>
  e1-roslyn.sh: 10: cd: can't cd to ./work/dotnet
  ```

  rc=1. El script lo avisa en su cabecera: «Requiere haber corrido generar.py». Después de `docker run … python:3.12-slim python generar.py`, el mismo comando reproduce lo que muestra la guía (`error CS1056: Unexpected character '�'`, `U+ : FFFD 006E 003A`).
- **Impacto**: el primer comando que ve el lector, el que «contiene todo el caso», falla al copiarlo.
- **Dirección**: anteponer `cd Examples/N1-codificacion-y-finales-de-linea` y la línea de `generar.py`, o remitir a `sh correr-todo.sh`. Conviene además `-u "$(id -u):$(id -g)"` para no dejar `work/` con dueño root.

### desarrollador-03 — S3 — E1 — Los comandos para correr el laboratorio no funcionan copiados: `cd` relativos encadenados (§0.4) y `./correr-todo.sh` sin bit de ejecución (README de Examples, fila N1)

- **Ubicación**: §0.4, líneas 90–91; `Examples/README.md`, fila N1 («`./correr-todo.sh`»).
- **Ancla**:

  ```text
  $ cd Examples/N0-modelo-de-capas-y-reproducibilidad && …; cd Examples/A-plantillas && …
  bash: línea 1: cd: Examples/A-plantillas: No existe el fichero o el directorio
  $ cd Examples/N1-codificacion-y-finales-de-linea && ./correr-todo.sh
  bash: línea 1: ./correr-todo.sh: Permiso denegado
  ```

  `find Examples -name '*.sh' ! -perm -u+x` devuelve 20 scripts, entre ellos `N1-…/correr-todo.sh`, todos los `e1-*.sh` de N1 y los `N3-…/*/correr.sh`. Los README de N1 y N3 usan `sh …` y funcionan. La carpeta está sin commitear (`?? Guides/Metodologia-Entorno-Desarrollo/`), así que el modo que entre en el índice será el del disco.
- **Dirección**: en §0.4, usar subshells: `( cd Examples/N0-… && ./correr-todo.sh )`. En la fila N1 del README, `sh correr-todo.sh`, o `chmod +x` a los puntos de entrada antes del primer commit, como la guía misma recomienda en §8 (`git update-index --chmod=+x`).

### desarrollador-04 — S2 — E1 — El `docker buildx build` de §11.5 falla tal como está escrito: no existe el builder y el Python por defecto de `Dockerfile.por-componente` no es 3.12.15

- **Ubicación**: §11.5, bloque `docker buildx build --builder n8-attest --target artefacto --provenance=mode=max,version=v1 --sbom=true -f imagen/Dockerfile.por-componente --output type=local,dest=salida solucion`.
- **Ancla**: corrí el bloque en una copia de `N8-integracion-poliglota/{solucion,imagen}`.
  1. Tal cual: `ERROR: no builder "n8-attest" found`. Nada en la guía lo crea; el experimento sí lo hace (`e6-sbom-unificado/experimento.sh:32`, `docker buildx create --name n8-attest --driver docker-container`).
  2. Con el builder creado y Docker Hub anónimo (`DOCKER_CONFIG` vacío, como sugiere §0.4):

     ```text
     #16 [py 1/5] FROM docker.io/library/python:3.12-slim@sha256:78387bc3881b…
     #23 0.709 error: No interpreter found for Python 3.12.15 in search path
     ERROR: failed to build: … "uv run --locked python gen.py dist/Datos.g.cs" … exit code: 2
     ```

     El default `ARG PY_IMAGE=python:3.12-slim@sha256:78387…` de `imagen/Dockerfile.por-componente` no trae el parche de `solucion/tools/gen/.python-version` (3.12.15). E8-6 pasó porque inyecta `--build-arg PY_IMAGE=$PY15` (`python:3.12.15-slim@sha256:05cda…`), y además agrega `BUILDKIT_SBOM_SCAN_STAGE` por `sed` y no usa `version=v1`. Lo que la guía muestra no es lo que se ejecutó, y `version=v1` queda sin evidencia ejecutada.
- **Impacto**: el único comando de procedencia y SBOM de la solución políglota no se puede reproducir copiándolo. El Dockerfile citado contradice su propio comentario («la imagen debe traerlo»).
- **Dirección**: corregir el default de `PY_IMAGE` en `Dockerfile.por-componente` al digest de `python:3.12.15-slim`; agregar en la guía la línea `docker buildx create …`; y mostrar el comando exactamente como corre E8-6 o volver a correr el de la guía y versionar su salida. Si se quieren los SBOM por etapa, explicar `BUILDKIT_SBOM_SCAN_STAGE`.

### desarrollador-05 — S3 — E2 — El extracto de `publicar.sh` en §10.5 omite el clon limpio y corre la compuerta sobre el árbol de trabajo de quien publica

- **Ubicación**: §10.5, bloque `bash` «publicar.sh — compuerta en el acto irreversible (extracto de E7-5)».
- **Ancla**: la guía dice `git checkout -q "$commit" && tools/ci/compuerta.sh > compuerta.txt || exit 1` y no tiene ningún `clone` ni `fetch`. El script ejecutado (`Examples/N7-…/05-sin-proteccion-de-rama/publicar.sh`, l. 11) empieza así: `tmp=$(mktemp -d); git clone -q "$remoto" "$tmp/r" && cd "$tmp/r" || exit 2`, y su regla 2 pide «la compuerta da VERDE sobre ESE commit, en un clon limpio».
- **Impacto**: copiado tal cual, el extracto evalúa archivos sin seguimiento o modificados de la estación, deja HEAD desacoplado en el clon del desarrollador y contrasta contra un `origin/main` posiblemente viejo. Pierde la propiedad que justifica el control compensatorio.
- **Dirección**: incluir en el extracto las dos líneas del clon temporal (`tmp=$(mktemp -d); git clone -q "$remoto" "$tmp/r" && cd "$tmp/r" || exit 2`) y la firma de uso `publicar.sh <remoto> <commit> <version>`.

### desarrollador-06 — S4 — E1 — §6.5 presenta un `package.json` con comentarios: si se copia, npm falla

- **Ubicación**: §6.5, segundo bloque `jsonc` («// package.json — declara para quien consume…»).
- **Ancla**:

  ```text
  npm error code EJSONPARSE
  npm error JSON.parse Invalid package.json: JSONParseError: Unexpected token "/" (0x2F) …
  npm error JSON.parse Note: package.json must be actual JSON, not just JavaScript.
  ```

  Probado con Node 24.21.0 y npm 11. El `global.json` comentado del mismo apartado sí lo acepta el SDK 8.0.425, así que el lector no puede inferir del bloque cuál de los dos es copiable.
- **Dirección**: rotular esos bloques como «anotados, no copiables; la versión copiable está en A.3/A.7», o pasar las notas del `package.json` a la prosa.

### desarrollador-07 — S4 — E2 — §9.5 referencia `actions/attest@v4` por etiqueta, mientras A.12 exige fijar acciones por SHA

- **Ubicación**: §9.5, bloque `yaml`, `- uses: actions/attest@v4`, frente a A.12, «Acción fijada por SHA completo; la etiqueta va como comentario».
- **Ancla**: `git ls-remote https://github.com/actions/attest 'refs/tags/v4*'` devuelve `1e69f48acb82d1966a394da916b4c1698aa569d6 refs/tags/v4` (= `v4.2.2`). Consultado el 2026-10-07.
- **Dirección**: `uses: actions/attest@1e69f48acb82d1966a394da916b4c1698aa569d6 # v4.2.2` y [B193] como fuente del método de resolución. Volver a resolver el SHA el día que se cierre la guía.

## Revisado y bien

1. **Anexo A copiable y verificado**: los 19 bloques del Anexo A coinciden byte a byte con los archivos del laboratorio (`A-plantillas/repo/` y `N8-…/imagen/Dockerfile`). EA-1, corrido de nuevo, da rc=0 y la misma salida versionada: `.editorconfig`/`.gitattributes` resuelven como dice la guía, NU1004 en modo CI, `devEngines`, uv 3.12.15 y el esquema de `dependabot.yml`. Los SHAs de `actions/checkout` v7.0.1 (`3d3c42e5…`) y de `pre-commit-hooks` v6.0.0 (`3e8a8703…`) son correctos según `git ls-remote`.
2. **El caso se reproduce**: `N0-…/correr-todo.sh` corre en 1m24s con rc=0, y las diferencias contra `salidas/` son las volátiles esperadas. E1-01 con `generar.py` reproduce `CS1056` y `U+FFFD` como muestra §1.2.
3. **Snippets de §4.5, §6.5 (`global.json`) y §10.5 (pre-commit) funcionan**: el diagnóstico POSIX detecta el cp1252 y los CR; `TextDecoder` con `fatal:true` descarta el BOM y rechaza bytes inválidos (`ERR_ENCODING_INVALID_ENCODED_DATA`); el `global.json` comentado es aceptado y respetado por el SDK 8.0.425; el `.pre-commit-config.yaml` adaptado pasa con pre-commit 4.6.2 sin quitar el BOM de `.razor`/`.ps1` ni agregar salto final al lock.

## Solicitudes de convocatoria

- **DevOps/CI (GitHub Actions)**: en A.12, el job corre en `container:` y después de `actions/checkout` ejecuta `git log` y `--base origin/…`. Conviene que alguien con mandato sobre la plataforma confirme si hace falta `git config --global --add safe.directory "$GITHUB_WORKSPACE"` («dubious ownership» en *job containers*) y si la imagen de la CI trae `git`, ya que sin `git` `checkout` baja el código sin `.git`. No se pudo ejecutar: requiere GitHub.
