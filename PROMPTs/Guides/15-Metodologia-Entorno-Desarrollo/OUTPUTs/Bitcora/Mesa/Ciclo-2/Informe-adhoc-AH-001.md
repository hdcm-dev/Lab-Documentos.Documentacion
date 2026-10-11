# Informe AH-001 — Especialista en ecosistemas Node.js y Python (ciclo 2)

- Rol: agente ad hoc «Especialista en ecosistemas Node.js y Python (toolchain, gestores, locks, empaquetado)».
- Pregunta: ¿lo que la guía afirma de cada herramienta de Node.js y de Python (qué declara, qué hace cumplir, su default y su estado al 2026-10-07) es exacto, y la recomendación por ecosistema coincide con la del fabricante o la PEP?
- Objeto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (3391 líneas), revisado a ciegas como obra terminada. Leí sólo mi informe del ciclo 1 y las filas que me tocan del consolidado y de los parches (C1-12, C1-30, C1-31, C1-58, R2-10); no leí informes de otros especialistas del ciclo 2.
- Experimentos propios: en el scratchpad de la sesión (no en el laboratorio), con `node:24-bookworm-slim` (Node 24.21.0), `node:22-bookworm-slim` (Node 22.23.2) y `python:3.12-slim` / `python:3-slim`. Consultas web del 2026-10-09.
- Lo cerrado en el ciclo 1 se aplicó: devEngines en §11.2.5 punto 3 y en N8 (C1-12), `--universal` sólo de uv (C1-30), pnpm cumple `packageManager` sin Corepack (C1-31), «Multiplataforma» de pnpm y Yarn en «sí» (C1-58). Lo que sigue no lo re-litiga: corrige la precisión de lo que quedó escrito.

## Hallazgos

### adhoc-AH-001-01 — pnpm hace cumplir `packageManager` por sí mismo desde la 9.7 (por defecto desde la 10), no «desde la 11» — S3, E1 + E2

**Ubicación:** §6.2.3 [criterio] L1000; diagrama L968; respuesta rápida L1104; tabla de experimentos L3285 (E3-3).

**Anclas:** L1000 «pnpm, desde la 11, lo hace cumplir por sí mismo con el ajuste `pmOnFail`»; L968 `"pnpm ≥ 11 (pmOnFail) · Yarn con Corepack"`; L1104 «`packageManager` lo hace cumplir pnpm ≥ 11 por sí mismo (`pmOnFail`, [B196])».

**Problema:** el corte en la 11 es el del **nombre del ajuste**, no del comportamiento. En pnpm 10 la documentación da `managePackageManagerVersions` (default `true`: «pnpm will automatically download and run the version of pnpm specified in the `packageManager` field»), `packageManagerStrict` (default `true`) y `packageManagerStrictVersion` (default `false`: «pnpm will fail if its version doesn't exactly match») (pnpm.io/10.x/settings, consultado 2026-10-09). La página de pnpm 11 dice que `pmOnFail` «replaces the removed `managePackageManagerVersions`, `packageManagerStrict`, and `packageManagerStrictVersion` settings» (pnpm.io/settings/cli = [B196], 2026-10-09). Importa en la práctica: la guía misma dice (L1210) que Dependabot soporta pnpm sólo hasta v10, así que un equipo en pnpm 10 leería que `packageManager` no se cumple, y la receta de la compuerta (`pmOnFail=error`) **no existe** en su versión.

**E1** (pnpm 10.18.0 instalado con npm, Corepack sin habilitar):

```
pnpm global: 10.18.0
== pnpm --version en proyecto con packageManager pnpm@9.15.0
9.15.0
== con --config.manage-package-manager-versions=false y package-manager-strict-version=true
 ERROR  This project is configured to use v9.15.0 of pnpm. Your current pnpm is v10.18.0
== packageManager yarn@4.10.3, pnpm install:
 ERROR  This project is configured to use yarn
```

**Dirección:** «pnpm lo hace cumplir por sí mismo: en la 10, descargando la versión declarada (`managePackageManagerVersions`, por defecto) o fallando con `packageManagerStrictVersion=true`; desde la 11 los tres ajustes se unifican en `pmOnFail` (`download` por defecto, `error` en la compuerta) [B196]». Cambiar el rótulo del diagrama a «pnpm (solo) · Yarn con Corepack» y la respuesta rápida a «pnpm por sí mismo (10: `packageManagerStrictVersion`; ≥ 11: `pmOnFail`)». Sumar la página de pnpm 10.x a la bibliografía o a [B196].

### adhoc-AH-001-02 — La afirmación sobre Yarn cita la página de `pnpm self-update` y omite el mecanismo propio de Yarn (`yarnPath`) — S4, E2

**Ubicación:** §6.2.3 L1000.

**Ancla:** «Yarn depende de Corepack o de instalarlo explícitamente [B81].» — y en la bibliografía: «B81 | pnpm — `self-update` (`packageManager`) | https://pnpm.io/cli/self-update».

**Problema:** la cita no respalda la afirmación (es de pnpm). Además, «instalarlo explícitamente» deja afuera la vía que documenta Yarn para no depender de Corepack: `yarn set version --yarn-path` guarda el binario en el repo y lo referencia con `yarnPath` en `.yarnrc.yml`; sin `--yarn-path` el comando escribe `packageManager` para Corepack (yarnpkg.com/cli/set/version, 2026-10-09: «downloaded from the Yarn GitHub repository, stored inside your project, and referenced via the `yarnPath` settings»).

**Dirección:** citar yarnpkg.com/cli/set/version (nueva entrada, o reemplazar el uso de [B81] en esa frase) y escribir «Yarn depende de Corepack o de `yarnPath` (el binario versionado en el repo, `yarn set version --yarn-path`)». Si [B81] ya no se cita en ninguna otra parte, revisar si queda huérfana.

### adhoc-AH-001-03 — Tabla §7.3: los seis **[no verificado]** de «Error de deriva» y «Error de integridad» se pueden verificar, y ya están medidos — S4, E1

**Ubicación:** §7.3 L1204–L1205.

**Anclas:** `| Error de deriva | … | ERR_PNPM_OUTDATED_LOCKFILE | **[no verificado]** | …` y `| Error de integridad | NU1403 | EINTEGRITY | **[no verificado]** | **[no verificado]** | **[no verificado]** | **[no verificado]** | …`.

**E1:**

```
# Yarn 4.10.3 (Corepack, node:22), is-odd 3.0.1 → 2.0.0 en package.json:
yarn install --immutable
➤ YN0028: │ The lockfile would have been modified by this install, which is explicitly forbidden.   exit=1
# Yarn, checksum alterado en yarn.lock, caché limpia:
➤ YN0018: │ is-odd@npm:3.0.1: The remote archive doesn't match the expected checksum                exit=1
# pnpm 10.18.0, integrity alterado en pnpm-lock.yaml, store borrado:
pnpm install --frozen-lockfile → … error (ERR_PNPM_TARBALL_INTEGRITY) …                                  exit=1
# uv 0.12.23, sha256 alterado en uv.lock, caché limpia:
uv sync --locked → error: Failed to download `six==1.16.0`  cause: Hash mismatch for `six==1.16.0`        exit=1
# Poetry 2.5.1, sha256 alterado en poetry.lock, caché limpia:
poetry install → Downloaded distributions for six (1.16.0) did not match any known checksums in your lock file.   exit=1
```

**Dirección:** reemplazar las seis marcas por `YN0028`, `ERR_PNPM_TARBALL_INTEGRITY`, `YN0018`, «Hash mismatch», «did not match any known checksums», y sumar el experimento a E4-4 (Node) y E4-5 (Python) si el laboratorio lo debe reproducir. Con eso la fila «Evidencia» de la tabla queda pareja en todas las columnas.

### adhoc-AH-001-04 — §11.2.5 punto 3 atribuye a E8-3 una medición con npm 11.19 que E8-3 no hizo — S4, E1 (lectura de la salida versionada)

**Ubicación:** §11.2.5, punto 3, L2127.

**Ancla:** «`EBADDEVENGINES` con npm 10.9.8 y 11.19, E8-3».

**Evidencia:** `Examples/N8-integracion-poliglota/salidas/E8-3-frontera-de-la-build.txt`, línea 43: `npm warn EBADENGINE   current: { node: 'v24.21.0', npm: '10.9.8' }`. El experimento antepone el binario de Node 24 al `PATH` pero el npm es el de la imagen de Node 22 (10.9.8); la medición con npm 11.19 es de E3-3 (y del E1 de AH-001-01 del ciclo 1).

**Dirección:** «(`EBADDEVENGINES` con npm 10.9.8 en E8-3; con npm 11.19 en E3-3)». De paso queda explícito un detalle útil del caso: el npm que corre es el del `PATH`, que puede no ser el que trae el Node antepuesto.

## Revisado y bien

1. **Estados vigentes de herramientas de Python:** pip 26.2.1 es la última (`pip install -U pip` en `python:3.12-slim`, 2026-10-09), `pip install --help` dice «pylock.toml support is experimental» y `pip lock` existe; PEP 790 fija 3.15.0 final para el viernes 2026-10-09, así que «al 2026-10-07 ninguna versión estable lo tiene activo» (PEP 686, L542) es exacto en la fecha del documento. `--universal` quedó sólo en uv y pip-tools «por entorno» (L1193, L1206, L1275), coherente con el README de pip-tools.
2. **Topes de Dependabot y requisitos de procedencia de npm:** la tabla oficial (2026-10-09) da npm v7–v11, pnpm v7–v10, Yarn v1–v4, uv v0.11, Poetry v2, igual que L1210; npm documenta provenance sólo desde GitHub Actions y GitLab CI/CD con runners de la nube y `repository` público (§9.2.2, L1611). Matiz opcional, no hallazgo: con *trusted publishing* la procedencia se genera sin `--provenance`.
3. **Gestores de versión (§6.2.5) y `devEngines`:** fnm resuelve `engines.node` por defecto cuando faltan `.node-version`/`.nvmrc` (docs/commands.md: «Enabled by default»); mise no crea `mise.lock` por defecto y tiene `mise install --locked` / `locked = true` para fallar sin entrada; `devEngines.runtime` sin `onFail` falla en N8 tal como dice §11.2.5 (E8-3, caso c).

## Solicitudes de convocatoria

Ninguna.
