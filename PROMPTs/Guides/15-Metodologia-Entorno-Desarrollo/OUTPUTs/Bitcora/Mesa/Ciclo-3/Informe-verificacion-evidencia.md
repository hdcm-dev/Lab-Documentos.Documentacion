# Mesa · Ciclo 3 · Informe del especialista de Verificación/QA (evidencia)

> Fecha: 2026-10-09. Rol: Verificación/QA, núcleo permanente (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md`).
> Objeto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` v1.0.0 (3605 líneas) y su laboratorio `Examples/`.
> Revisión a ciegas: no se leyeron informes de otros especialistas del ciclo 3. De Ciclo-2 sólo se leyó el resumen de `05-Aplicacion.md`, para no re-litigar lo cerrado.
> Las corridas se hicieron sobre copias en el scratchpad de la sesión: no se tocó `Examples/` ni sus `salidas/`.

## 1. Muestreo de afirmaciones de riesgo (22 re-consultadas)

| # | Afirmación (ubicación) | Fuente re-consultada (2026-10-09) | Resultado |
|---|---|---|---|
| 1 | Python 3.15.0 publicada el 2026-10-09; PEP 686 activo (§4.3, l. 548) | python.org/downloads/release/python-3150 («Release date: Oct. 9, 2026»; «PEP 686: Python now uses UTF-8 as the default encoding»); PEP 790 («3.15.0 final: Friday, 2026-10-09») | Coincide |
| 2 | PEP 686 *Final*, Python 3.15 (l. 548) | peps.python.org/pep-0686 (Status: Final; Python-Version: 3.15) | Coincide |
| 3 | `npm-shrinkwrap.json` ya no se lee ni se escribe desde npm 12 (§7.2.2) | docs.npmjs.com/cli/v12/…/package-lock-json: «As of npm v12, `npm-shrinkwrap.json` is no longer read or written by npm.» | Coincide |
| 4 | Dependabot: npm ≤ v11, pnpm ≤ v10, uv v0.11; `devcontainers` sin repos privados (§7.3, §8.2.2) | docs.github.com …/supported-ecosystems-and-repositories | Coincide |
| 5 | Dependabot espera 3 días por defecto y abre hasta 5 PR (§10.2.6) | docs.github.com …/dependabot-options-reference («default cooldown period of 3 days»; «If five pull requests…») | Coincide |
| 6 | BuildKit v0.28.0 pasa el default a SLSA v1 (§9.2.4) | github.com/moby/buildkit/releases/tag/v0.28.0 («switched to SLSA v1.0 from the previous v0.2») | Coincide |
| 7 | Banda → VS mínimo (10.0.100 → 17.14; 2xx–4xx → 18.0); VS instala una sola copia del SDK y la reemplaza (§6.2.2) | learn.microsoft.com …/versioning-sdk-msbuild-vs | Coincide |
| 8 | v26 Current, v24/v22 LTS, v20 EOL; desde Node 27 ciclo anual con todas a LTS (§6.2.3) | nodejs.org/en/about/previous-releases | Coincide |
| 9 | Corepack deja de distribuirse desde Node 25.0.0 (§6.2.3) | nodejs.org/en/blog/release/v25.0.0 («build: stop distributing Corepack», #57617) | Coincide |
| 10 | EditorConfig 0.17.2: `utf-8-bom` desaconsejado; `#` tras un valor es parte del valor; llaves (§4.3, §5.2.4) | spec.editorconfig.org | Coincide |
| 11 | NuGet determinista por defecto desde .NET 11; fechas con `DeterministicTimestamp`/`SOURCE_DATE_EPOCH` (§9.2.1) | learn.microsoft.com/nuget/create-packages/deterministic-packages | Coincide |
| 12 | Atestaciones de GitHub: Free/Pro/Team sólo públicos; privados con Enterprise Cloud (§9.2.4) | raw.githubusercontent.com/github/docs/main/data/reusables/gated-features/attestations.md | Coincide |
| 13 | pnpm 11 `pmOnFail`, default `download`, gobierna `devEngines.packageManager` (§6.2.3) | pnpm.io/settings/cli | Coincide |
| 14 | `devEngines` con `onFail` por defecto `error`, antes de `install`, `ci`, `run`; `engines` sólo aviso (§6.2.3) | docs.npmjs.com/cli/v11/configuring-npm/package-json | Coincide |
| 15 | Imagen `node` sin Yarn v1 desde Node 26; Alpine amd64 «Experimental» (§8.3) | github.com/nodejs/docker-node README | Coincide |
| 16 | Etiquetas fijas y flotantes de .NET se rehacen por la base; digest para el parche del SO; .NET 10 multiplataforma en Ubuntu; 12 h y segundo martes (§8.2.2, §8.3) | dotnet/dotnet-docker `documentation/supported-tags.md` («Fixed version tags are updated according to the image update policy»; «Digest pinning is required…») y README (*Image Update Policy*) | Coincide |
| 17 | CycloneDX 1.7 (2025-10-21), ECMA-424 (§9.2.3) | cyclonedx.org/specification/overview | Coincide |
| 18 | CISA 2026 Minimum Elements, 2026-07-29, reemplaza a 2021, agrega contexto de generación (§9.2.3) | PDF B157 (`pdftotext`): «Publication: July 29, 2026»; «updates and replaces»; «SBOM Generation Context» | Coincide |
| 19 | SLSA v1.2 aprobada (§9.2.4) | slsa.dev/spec («Status: Approved», v1.2) | Coincide |
| 20 | containerd image store por defecto en Docker Engine 29 (§9.2.4) | docs.docker.com/engine/storage/containerd («default … for Docker Engine 29.0 and later on fresh installations») | Coincide |
| 21 | `actions/attest` v4.2.2 = `1e69f48a…` (§9.5); PR Roslyn #83320 (abril 2026) y #81382 (noviembre 2025) (§4.2.1, §4.2.3) | `git ls-remote https://github.com/actions/attest 'refs/tags/v4*'` → `1e69f48acb82d1966a394da916b4c1698aa569d6 refs/tags/v4.2.2`; API de GitHub: #83320 merged 2026-04-24, #81382 merged 2025-11-26 | Coincide |
| 22 | uv busca `.python-version` sin pasar el límite del proyecto; `python-downloads` = `automatic` (§6.2.4); `unsupported` (antes `system`) desde pre-commit 4.4 (§10.2.3); Prettier `lf` desde 2.0 (§4.3) | docs.astral.sh/uv/concepts/python-versions; pre-commit.com; prettier.io/docs/options | Coincide |

Versiones vigentes comprobadas por API: editorconfig-checker v4.0.2, paquete `EditorConfig` 0.17.1, pip 26.2.1, `@devcontainers/cli` 0.89.0 y pre-commit 4.6.2. Todas coinciden con lo que dice la guía. La metadata de .NET (`releases-index.json`) da 10.0.401 y 8.0.425 como últimos SDK, igual que «Datos volátiles». **uv 0.13.0** salió el 2026-10-09 19:49Z; ver V-4.

## 2. Experimentos re-ejecutados

| Experimento | Comando (sobre copia) | Resultado frente a la guía |
|---|---|---|
| E1-01 | `docker run … python:3.12-slim python generar.py` + `docker run … mcr.microsoft.com/dotnet/sdk:8.0 sh e1-roslyn.sh` | Sale idéntico a `salidas/e1-roslyn-sdk8.txt` (`diff` vacío; SDK 8.0.425). Coincide con el extracto de §1.2 y con §4.2.3 (`AtenciÃ³n` con `CodePage=1252` sin BOM). |
| E4-2 | `docker run --rm -v "$PWD/e2-nuget-cpm-pinning:/src:ro" mcr.microsoft.com/dotnet/sdk:8.0 bash /src/run.sh` | Coincide con `salidas/e2-nuget-cpm-pinning.txt`: sólo difieren dos tiempos de restore. 5a: con lock, 0 NU1603, rc=0, `requested [8.0.2, )`, `resolved 9.0.0`. 5b: `warning NU1603`. 5c: rc=1. 5d: rc=0. Coincide con §7.2.1. |
| E1-11 | `docker run --rm -v "$PWD":/w -w /w python:3.12-slim sh e1-shebang.sh` | Sale idéntico a `salidas/e1-shebang.txt`. Con BOM: dash y bash, exit 0; `subprocess` da `OSError 8 Exec format error`. Con CRLF: 127 / `ENOENT`. |
| ad hoc (V-1/V-2) | `node:24` (v24.21.0): `spawnSync` sobre `con-bom.sh` y `con-bom.py`; `bash -c ./con-bom.py` | `con-bom.sh`: status 0. `con-bom.py`: status 2 (`Syntax error: word unexpected`). `bash`: rc=2. |

## 3. Hallazgos

### V-1 · S3 · E1 — §4.2.4, l. 517: «y sale con 0» generaliza de más

- **Ancla:** «Si lo lanzó un shell (bash, dash) o una función de la familia `execvp` (como el `child_process` de Node), se reintenta con `/bin/sh`: la primera línea falla, el resto corre **con ese shell** aunque el shebang pidiera otro intérprete, y sale con 0.»
- **Contraevidencia:** el propio E8-1 (`Examples/N8-integracion-poliglota/salidas/E8-1-choque-de-convenciones.txt`, columna B) da `python: ./tools/saluda.py (shebang) FALLA rc=2`. La corrida ad hoc lo repite con `bash -c ./con-bom.py` (rc=2) y con `spawnSync` de Node (status 2).
- El exit 0 sólo aparece cuando el resto del archivo es shell válido, como en E1-11, cuyo shebang es `/bin/sh`. Si el shebang pedía otro intérprete, el shell interpreta código de otro lenguaje y lo normal es que falle más abajo.
- **Dirección:** «…el resto corre con ese shell aunque el shebang pidiera otro intérprete: si es shell válido sale con 0 (E1-11); si no, falla más abajo, lejos de la causa (E8-1: un `.py` con BOM da rc=2)». La pregunta de §4.6 («puede … salir con 0») y l. 2168 ya están bien acotadas.

### V-2 · S4 · E1 — §4.2.4, l. 517: el `child_process` de Node se cita con experimentos que no lo ejercitan

- **Ancla:** «(como el `child_process` de Node)» con «(E1-11, E8-1)».
- E1-11 prueba dash, bash y `subprocess` de Python. E8-1 lanza los scripts desde `lectores.sh`, es decir, desde bash. `grep -rn "child_process\|execFile\|spawn" Examples/` no devuelve nada.
- La afirmación es cierta: Node 24.21.0, `spawnSync('./con-bom.sh')` → `{"status":0,"out":"hola desde sh\n","err":"./con-bom.sh: 1: ﻿#!/bin/sh: not found\n"}`. Pero hoy no tiene evidencia versionada.
- **Dirección:** agregar a `e1-shebang.sh` (o a un `e1-node.mjs`) un caso `spawnSync` con su salida, o rotular la mención **[observado]** (Node 24.21.0) remitiendo a esa salida.

### V-3 · S3 · E1 — Laboratorio N4: dos textos contradicen la guía y la propia salida

- **Ancla 1:** `Examples/N4-congelamiento-de-dependencias/README.md`, l. 47 (fila E2): «si la versión pedida no existe, NuGet resuelve la siguiente **sin advertir**».
  - La corrida (paso 5b) da `warning NU1603: … An approximate best match of Microsoft.Extensions.Primitives 9.0.0 was resolved.`
  - Sin aviso queda sólo **con lock** (5a). Así lo dicen la l. 64 del mismo README y §7.2.1 de la guía.
- **Ancla 2:** `e2-nuget-cpm-pinning/run.sh`, l. 42: «en el repo, la línea comentada de A.4».
  - Desde el ciclo 2, A.4 (`Examples/A-plantillas/repo/Directory.Build.props`, l. 16) tiene `<WarningsAsErrors>$(WarningsAsErrors);NU1603</WarningsAsErrors>` **activo**.
  - La línea se imprime en la salida versionada.
- Quien sigue la ruta mínima (§0.2: E4-2 «el lock calla el aviso») lee en la carpeta lo contrario de la guía.
- **Dirección:**
  - Fila E2: «…resuelve la siguiente con `NU1603`; con lock, sin aviso».
  - `run.sh`: «en el repo, la línea de A.4».
  - Regenerar `salidas/e2-nuget-cpm-pinning*.txt`, o declarar el cambio de rótulo.

### V-4 · S4 · E2 — «Datos volátiles» (l. 3591) y §7.3 (l. 1244): uv 0.12 como vigente el mismo día en que salió uv 0.13.0

- **Ancla:** «Python 3.15.0 publicada el 2026-10-09; uv 0.12.23; …» y «vigentes al 2026-10-07 (npm 12, pnpm 12, uv 0.12)».
- La API de GitHub da `astral-sh/uv v0.13.0 2026-10-09T19:49:55Z`. Su nota dice: «The default stable Python version has changed from 3.14 to 3.15. This affects Python downloads when no version is requested or pinned».
- Lo fechado al 2026-10-07 sigue siendo cierto. Pero «Datos volátiles» mezcla fechas: Python 3.15.0 al 9, uv al 7.
- Las plantillas no se ven afectadas: fijan `required-version = "==0.12.23"` y `.python-version` 3.12.15. Justamente por eso, este dato les sirve de argumento.
- **Dirección:** en «Datos volátiles», «uv 0.12.23 (laboratorio); uv 0.13.0 publicada el 2026-10-09, que pasa el Python por defecto a 3.15». Se puede agregar una línea en §6.2.4: sin `.python-version` con parche, ese cambio llega solo.

## 4. Revisado y bien

1. **Fuentes vigentes:** las 22 afirmaciones de riesgo muestreadas (versiones, defaults, deprecaciones, planes y fechas) coinciden con su fuente al 2026-10-09, sin excepción.
2. **Salidas fieles:** E1-01, E4-2 y E1-11 reproducen byte a byte sus salidas versionadas (salvo tiempos de restore). Los extractos de §1.2 y §7.2.1 son literales.
3. **Contabilidad consistente:**
   - 217 filas `Bnn` en el Anexo D.
   - 65 filas de Anexo E que, con las agrupadas (`a/b/c`, `/b`), suman los 73 experimentos que anuncia el encabezado.
   - El SHA de `actions/attest` v4.2.2 y las fechas de los PR de Roslyn coinciden con lo que se resuelve hoy.

## 5. Solicitudes de convocatoria

Ninguna.
