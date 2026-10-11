# Mesa · Ciclo 2 · Informe del especialista de Verificación/QA (evidencia)

> Fecha: 2026-10-09. Rol: núcleo permanente, Verificación/QA (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md`).
> Objeto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md`, 1.0.0-rc.1 (3391 líneas).
> Revisión a ciegas: no se leyeron informes de otros especialistas del ciclo 2. Se leyó `Ciclo-1/05-Aplicacion.md` para no re-litigar lo cerrado.
> Evidencia propia: `evidencia-verificacion-evidencia/` (re-corridas de E1-01, E1-11 y E3-1).

## 1. Muestreo de afirmaciones de riesgo (25 re-consultadas el 2026-10-09)

| # | Afirmación (ubicación) | Fuente re-consultada / comando | Resultado |
|---|---|---|---|
| 1 | Python 3.15 final «prevista para el 2026-10-09»; «ninguna versión estable lo tiene activo» (§4.3 l.542; §11.2.2 l.2099) | peps.python.org/pep-0790; python.org/downloads/release/python-3150/; `curl python.org/ftp/python/` → `3.15.0/` | **Desactualizada el mismo día de la versión**: 3.15.0 publicada el 2026-10-09 con PEP 686 activo (hallazgo 01) |
| 2 | PEP 686 *Final*, modo UTF-8 por defecto desde 3.15 (§4.3) | peps.python.org/pep-0686 | ✔ |
| 3 | Corepack deja de distribuirse desde Node 25.0.0 (§6.2.3) | nodejs.org/en/blog/release/v25.0.0: «build: stop distributing Corepack» (#57617) | ✔ |
| 4 | v26 Current, v24/v22 LTS, v20 EOL; desde Node 27 ciclo anual, todas LTS (§6.2.3, §10.2.6) | nodejs.org/en/about/previous-releases | ✔ |
| 5 | Node 24.21.0, 22.23.2 y 22.23.3 publicada el 2026-09-23 (§11.2.6) | `nodejs.org/dist/index.json`: v24.21.0 2026-09-07; v22.23.3 2026-09-23; v22.23.2 2026-07-28 | ✔ |
| 6 | `npm-shrinkwrap.json` no se lee ni escribe desde npm 12 (§7.2.2) | docs.npmjs.com/cli/v12/configuring-npm/package-lock-json: «As of npm v12, npm-shrinkwrap.json is no longer read or written by npm» | ✔ |
| 7 | Vigentes al 2026-10-07: npm 12, pnpm 12, uv 0.12 (§7.3) | registry.npmjs.org: npm `latest` 12.2.0; pnpm `latest` 12.10.1; PyPI uv 0.12.24 | ✔ (uv avanzó a 0.12.24; la guía fija 0.12.23 a propósito) |
| 8 | Dependabot: npm ≤ v11, pnpm ≤ v10, uv v0.11; `devcontainers` no soportado en privados (§7.3, §8.2.2, A.13) | docs.github.com …/supported-ecosystems-and-repositories (texto de la tabla: «uv uv v0.11», npm «v7…v11», pnpm «v7…v10»; devcontainers «Not supported» en privados) | ✔ |
| 9 | Dependabot: enfriamiento por defecto de 3 días; no más de cinco PR (§10.2.6) | docs.github.com …/dependabot-options-reference: «Apply a default cooldown period of 3 days to version updates»; «If five pull requests…» | ✔ |
| 10 | VS mínimo: 10.0.100 → 17.14; 10.0.2xx–4xx → 18.0 (§6.2.2) | learn.microsoft.com …/versioning-sdk-msbuild-vs (columna *Minimum Visual Studio version*) | ✔ |
| 11 | pnpm `pmOnFail` desde v11, default `download`, gobierna `packageManager` y `devEngines.packageManager` (§6.2.3) | pnpm.io/settings/cli | ✔ |
| 12 | Atestaciones de GitHub: Free/Pro/Team sólo públicos; privados requieren Enterprise Cloud (§9.2.4) | raw `github/docs` …/gated-features/attestations.md | ✔ |
| 13 | EditorConfig 0.17.2: `utf-8-bom` «se desaconseja»; sin comentarios en línea (§4.3, §5.2.4) | raw `editorconfig/specification` `index.rst` (l.290-291 «Use of utf-8-bom is discouraged»; «No inline comments») y `conf.py` `version = '0.17.2'` | ✔ |
| 14 | BuildKit v0.28.0 pasó el default a SLSA v1; la página de Docker todavía dice v0.2 (§9.2.4) | github.com/moby/buildkit/releases/tag/v0.28.0; docs.docker.com/build/metadata/attestations/slsa-provenance («version=v0.2 (default)») | ✔ (ver hallazgo 03) |
| 15 | `.nupkg` determinista por defecto desde .NET 11, salvo fechas (`DeterministicTimestamp`/`SOURCE_DATE_EPOCH`) (§9.2.1) | learn.microsoft.com/nuget/create-packages/deterministic-packages | ✔ |
| 16 | .NET 8 y 9 terminan el 10-11-2026; .NET 10 el 14-11-2028 (§10.2.6) | dotnet.microsoft.com/…/support/policy/dotnet-core | ✔ |
| 17 | GHES: `pre-receive` combinados en 5 s; desaconseja servicios externos (§10.2.7) | docs.github.com/enterprise-server@3.22 …/about-pre-receive-hooks | ✔ |
| 18 | SLSA v1.2 aprobada, v1.1 retirada; `builder.id` requerido desde L1 y «sole determiner» (§9.2.4, B05) | slsa.dev/spec/ (v1.2 *Approved*); slsa.dev/spec/v1.1/ (*Retired*); slsa.dev/spec/v1.2/build-provenance | ✔ |
| 19 | Imágenes de Node: sin Yarn v1 desde 26; musl amd64 «Experimental» (§8.3) | github.com/nodejs/docker-node README | ✔ |
| 20 | Imágenes .NET: rehechas a las 12 h de su base, mensual el segundo martes, CVE críticos (§8.2.2) | github.com/dotnet/dotnet-docker README | ✔ |
| 21 | pre-commit 4.6.2; `unsupported` (antes `system`) (§10.2.3) | pypi.org/pypi/pre-commit/json → 4.6.2; pre-commit.com: «unsupported — new in 4.4.0: previously language: system» | ✔ |
| 22 | SHA de `actions/checkout` v7.0.1, `actions/attest` v4.2.2, `pre-commit-hooks` v6.0.0 (A.12, §9.5, §10.5) | `git ls-remote --tags`: `3d3c42e5…`, `1e69f48a…`, `3e8a8703…` | ✔ |
| 23 | editorconfig-checker 4.0.2 (§5.2.5) | `git ls-remote --tags` → último `v4.0.2` | ✔ |
| 24 | pip 26.2.1; `@devcontainers/cli` 0.89.0 (§7.2.3, §8.2.3) | PyPI pip 26.2.1; npm `@devcontainers/cli` latest 0.89.0 (2026-08-31) | ✔ |
| 25 | CISA «2026 Minimum Elements», 2026-07-29 (§9.2.3) | `curl -I` del PDF B157: 200, `last-modified: Wed, 29 Jul 2026` | ✔ |

## 2. Experimentos re-corridos (5) contra lo que dice la guía

| Exp. | Comando (copia en scratchpad, no en `Examples/`) | Resultado | Contra la guía |
|---|---|---|---|
| E1-01 | Los dos `docker run` de §1.2, copiados tal cual (python:3.12-slim + sdk:8.0) | rc=0; `CS1056`; `U+ : FFFD 006E 003A`; mojibake con `CodePage=1252` en UTF-8 sin BOM; `Atenci?n` con consola ISO-8859-1. `diff` contra `salidas/e1-roslyn-sdk8.txt` (sin tiempos): **sin diferencias** | ✔ el contenido; el bloque de §1.2 no es literal (hallazgo 02) |
| E1-11 | `docker run … python:3.12-slim sh e1-shebang.sh` | BOM: dash/bash exit 0 con error en stderr; `subprocess` → `OSError 8 Exec format error`; CRLF: exit 127. `diff` contra `salidas/e1-shebang.txt`: **IGUAL** | ✔ §4.2.4 párrafo del BOM en scripts |
| E3-1 | `sh correr.sh` (siete `global.json` × sdk:8.0 y sdk:10.0) | Idéntico a `salidas/E3-1.txt` (8.0.400 → 8.0.425; 8.0.300 falla; `latestMajor` → 10.0.400; `errorMessage` sólo con SDK 10) | ✔ §6.2.2 y §6.9 |
| §4.5 Node | `node` 22.23.2: `TextDecoder("utf-8",{fatal:true})` sobre JSON con BOM y con `0xF1` | BOM: `{"a":1}` (lo descarta); `readFileSync`+`JSON.parse`: `SyntaxError: Unexpected token '﻿'`; cp1252 con `fatal:true`: `TypeError`; sin `fatal`: `{"a�o":2026}` | ✔ §4.2.4 y snippet de §4.5 |
| E5-7 | git 2.47.3: `*.{cmd,bat} text eol=crlf` y `git check-attr -a x.cmd` | ningún atributo asignado | ✔ §5.2.4 |

## 3. Hallazgos (máximo 7)

### verificacion-evidencia-01 · S3 · E2 — Python 3.15.0 ya salió y la guía, fechada el mismo día, lo da como futuro

- **Ubicación**: §4.3 fila Python (l.542); §11.2.2 (l.2099); §4.2.4 fila «Python `open()` sin `encoding=`» (l.506); B32 (l.3075).
- **Ancla**: «PEP 686 (*Final*) activa el modo UTF-8 por defecto desde Python 3.15 [B29], cuya versión final está prevista para el 2026-10-09 [B32]: al 2026-10-07 ninguna versión estable lo tiene activo» y «hasta que el modo UTF-8 sea el predeterminado (Python 3.15) `open()` sin codificación usa `locale.getencoding()`».
- **Evidencia**: `https://www.python.org/downloads/release/python-3150/` (consulta 2026-10-09): «Release Date: October 9, 2026», «the stable release of Python 3.15.0», con PEP 686. `curl -s https://www.python.org/ftp/python/` lista `3.15.0/`. PEP 790 (modificada 2026-10-09 14:38 UTC) fija el final ese día.
- **Impacto**: la versión 1.0.0-rc.1 lleva `last_review: 2026-10-09`; un lector toma como vigente que «ninguna versión estable» tiene el modo UTF-8, y la fila de §4.2.4 («según *locale*») ya depende de la versión.
- **Dirección**: re-fechar con la fuente nueva (página de release de 3.15.0, consulta 2026-10-09): «desde 3.15.0 (2026-10-09) el modo UTF-8 es el predeterminado; 3.14 y anteriores, como el 3.12 del laboratorio, siguen dependiendo del *locale*». Calificar la fila de §4.2.4 («< 3.15: según *locale*; ≥ 3.15: UTF-8») y §11.2.2. La recomendación de `encoding=` explícito no cambia (el laboratorio fija 3.12). Agregar la URL a B32 o como fuente nueva.

### verificacion-evidencia-02 · S3 · E1 — Tres bloques de salida no son el «extracto literal» que promete §0.3

- **Ubicación**: §1.2 (l.141-156); §9.2.1 (l.1595-1603); §5.5 (l.876-883).
- **Ancla**: §0.3: «Un bloque de salida es un extracto literal de la salida registrada; puede omitir líneas que no hacen al punto (se marca con `...`) pero nunca altera una línea mostrada».
- **Evidencia (E1)**:
  - §1.2 abre con `$ docker run --rm -v "$PWD":/w -w /w mcr.microsoft.com/dotnet/sdk:8.0 sh e1-roslyn.sh`. Esa línea no está en `salidas/e1-roslyn-sdk8.txt` (que empieza con `SDK: 8.0.425 | TF=net8.0 …`) y no coincide con el comando que la guía da dos líneas antes (`-u "$(id -u):$(id -g)" -e HOME=/tmp`). Omite sin `...` las líneas `Largo`, `Bloque`, los dos `CS1519` y toda la sección `== utf8-lf | sólo literal`. Mi re-corrida del comando de la guía da el mismo contenido que el archivo versionado (`evidencia-verificacion-evidencia/E1-01-rerun-sdk8.txt`), así que el problema es de transcripción y no de resultado.
  - §9.2.1: la guía muestra `--- mapa de SourceLink en el PDB con PathMap a mano: no se normaliza`; el archivo (`N6-…/salidas/e2-determinismo-dotnet.txt`, l.31) dice `--- mapa de SourceLink en el PDB de (4): PathMap a mano no lo normaliza`. Las URL vienen truncadas (`9e618f99…`) y se omiten las corridas (2)–(7) sin `...`.
  - §5.5: las líneas de EA-1 se acortan dentro de la línea (`charset=utf-8 end_of_line=lf ...`). Es un caso menor, pero la regla no lo contempla.
- **Impacto**: el bloque de §1.2 es «todo el caso» y lo primero que alguien coteja con el laboratorio. Una línea de comando que no se corrió y que difiere del comando prescripto contradice la regla de procedencia que la guía se impone.
- **Dirección**: en §1.2, borrar la línea `$ docker run …` o reemplazarla por el comando real, y marcar con `...` cada omisión. En §9.2.1, copiar la línea 31 tal cual y marcar los saltos. En §0.3, admitir explícitamente el recorte dentro de una línea (`…`) o dejar de usarlo. Con un chequeo mecánico (cada línea de un bloque `text` citado debe aparecer en su archivo, salvo `...`) se cierra para todos los bloques.

### verificacion-evidencia-03 · S3 · E2 — El comando de §11.5 depende de la versión de BuildKit para dar lo que promete su comentario

- **Ubicación**: §11.5 (l.2316-2327) frente a §9.2.4 (l.1646).
- **Ancla**: §11.5: «`# salida/provenance.json : SLSA v1` … Este comando no pide `version=v1`: el default de la versión de BuildKit usada ya es v1». §9.2.4: «**[criterio]** pedir `--provenance=mode=max,version=v1` explícitamente».
- **Evidencia**: BuildKit v0.28.0 cambió el default («The default provenance format has been switched to SLSA v1.0 from the previous v0.2»). La documentación de Docker, consultada hoy, sigue diciendo «Supported values are `version=v0.2` (default) and `version=v1`». Es la deuda D-4 del ciclo 1, que sigue abierta. Con las dos fuentes de hoy deja de ser una cuestión de estilo: con un BuildKit anterior a 0.28, o con un builder fijado a una imagen vieja, el mismo comando produce v0.2 y el comentario `SLSA v1` es falso.
- **Dirección**: agregar `,version=v1` al `--provenance` de §11.5 y borrar la frase «Este comando no pide `version=v1`…». Re-correr L16 (`e6-sbom-unificado/comando-de-la-guia.sh`) con el cambio para que la salida citada siga siendo literal. Así §11.5 queda igual a §9.2.4.

### verificacion-evidencia-04 · S4 · E1 — §0.3 fija todas las fechas en 2026-10-07 y el Anexo D y el laboratorio dicen 2026-10-09

- **Ubicación**: §0.3, tabla de marcas (l.87-88).
- **Ancla**: «[B12] | Afirmación respaldada por la fuente B12 …, consultada el 2026-10-07» y «E4-2 | Resultado del experimento E4-2, ejecutado el 2026-10-07».
- **Evidencia**: el Anexo D (l.3040) fecha B194–B204 el 2026-10-09; `Examples/N3-fijacion-del-toolchain/salidas/E3-1.txt` lleva el encabezado `# E3-1 — 01-dotnet-global-json — 2026-10-09`; `05-Aplicacion.md` lista los experimentos re-corridos ese día. La apertura (l.24) sí distingue las dos fechas, pero la tabla de marcas no.
- **Dirección**: «consultada en la fecha que indica el Anexo D» y «ejecutado en la fecha de su salida (Anexo E)», o las dos fechas, igual que en l.24.

## 4. Revisado y bien (3)

1. **El caso reproducido y el fenómeno de §4 se sostienen al re-correrlos.** E1-01 con los comandos de §1.2 copiados tal cual coincide byte a byte con la salida versionada (sin contar tiempos), y E1-11 da la misma salida, incluida la diferencia shell/`execve` (`Exec format error`). El snippet de Node de §4.5 hace lo que dice.
2. **E3-1 y la tabla de `rollForward` de §6.2.2 coinciden con una corrida nueva**, también en las fallas de `errorMessage` (sólo SDK 10) y en `latestMajor` → 10.0.400.
3. **Los datos volátiles re-consultados hoy están vigentes**: SHAs de acciones y de `pre-commit-hooks`, líneas de Node y su cambio de ciclo desde la 27, tabla de Dependabot (máximos de gestor, `devcontainers` en privados, enfriamiento de 3 días), `pmOnFail`, npm 12 y `npm-shrinkwrap.json`, disponibilidad de atestaciones por plan, mínimos de Visual Studio por banda, SLSA v1.2/v1.1, fechas de soporte de .NET y la política de imágenes de .NET. Las 24 afirmaciones del muestreo, fuera de la n.º 1, coinciden con su fuente.

## 5. Solicitudes de convocatoria (fuera de mandato)

- Edición/didáctica: §11.9 tiene una sola consigna mientras §0.2 anuncia dos por capítulo (deuda D-4 del ciclo 1). No es un tema de evidencia; lo dejo para quien tenga ese mandato.
