# Informe AH-001 — Especialista en ecosistemas Node.js y Python (ciclo 1)

- Rol: agente ad hoc «Especialista en ecosistemas Node.js y Python (toolchain, gestores, locks, empaquetado)».
- Pregunta: ¿lo que la guía afirma de cada herramienta de Node.js y de Python (qué declara, qué hace cumplir, su default y su estado al 2026-10-07) es exacto, y la recomendación por ecosistema coincide con la del fabricante o la PEP?
- Objeto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (3060 líneas), revisado a ciegas. Fecha: 2026-10-07.
- Experimentos propios: en el scratchpad de la sesión (no en el laboratorio), con las imágenes locales `node:22-bookworm-slim` (Node 22.23.2, npm 10.9.8), `node:24-bookworm-slim` (Node 24.21.0, npm 11.19.0), `node:26-alpine` (Node 26.10.0, npm 11.19.1), `python:3.12-slim`.

## Hallazgos

### adhoc-AH-001-01 — §11.2.5, punto 3 (L1923 aprox.): «`engines` + `engine-strict` es lo único que hace cumplir la versión de Node» — S2, E1 + E2

**Ancla:** «`global.json` no cubre a Node ni a Python; dentro de esta frontera, `engines` + `engine-strict` es lo único que hace cumplir la versión de Node.»

**Problema:** contradice §6.2.3 de la propia guía («con npm alcanza `devEngines`») y la documentación de npm: `devEngines.runtime` se evalúa antes de `install`, `ci` y `run`, y `onFail` vale `error` si no se declara [B63, consultado 2026-10-07]. El laboratorio N8 (`solucion/web/package.json`) no declara `devEngines`, por eso el experimento sólo mostró `engine-strict`.

**E1** (sin `.npmrc`, sin `onFail`, `devEngines.runtime.version = "24.21.0"`, lock vacío):

```
== node:22-bookworm-slim   (npm 10.9.8)
npm error code EBADDEVENGINES
npm error EBADDEVENGINES Invalid semver version "24.21.0" does not match "v22.23.2" for "runtime"
ci exit=1 ... run exit=1
== node:24-bookworm-slim   (npm 11.19.0)
up to date ... ci exit=0
construido con v24.21.0   run exit=0
== node:26-alpine          (npm 11.19.1)
EBADDEVENGINES ... does not match "v26.10.0" ... ci exit=1 ... run exit=1
```

Nota: el E3-3 del laboratorio declara `onFail: "error"` explícito, así que no probaba el default; este E1 lo prueba, y además con npm 10.

**Dirección:** reescribir el punto 3: dentro de la frontera A, lo que hace cumplir la versión de Node es `devEngines.runtime` (falla por defecto en `npm ci` y `npm run`, sin configuración) o, alternativamente, `engines` + `engine-strict`. Alinear con §6.2.3 la fila «A en la estación» de la tabla de criterio (hoy pide `engine-strict`) y, si se quiere coherencia con la recomendación de §6, agregar `devEngines` al `package.json` de N8 y volver a medir E8-3.

### adhoc-AH-001-02 — §7.2.3 (L1062), tabla §7.3 (L1075) y respuesta rápida (L1137): pip-tools no tiene `--universal`, y E4-5 no ejercitó pip-tools — S3, E1 + E2

**Anclas:** «pip-tools y `uv pip compile` producen un `requirements.txt` **por plataforma** salvo `--universal` [B98][B104]»; tabla, columna «pip-tools / pip», fila Multiplataforma: «no, salvo `--universal`»; L1137: «`pip-compile` sin `--universal` no (E4-5)».

**Problema:** `--universal` es una opción de `uv pip compile`, no de `pip-compile`. El README de pip-tools [B104, consultado 2026-10-07] dice que hay que ejecutar `pip-compile` en cada entorno de destino («users should still always execute `pip-compile` on each targeted Python environment»). La salida de E4-5 (`salidas/e5-python-lock.txt`, sección 5) se titula «pip-tools style (uv pip compile)»: lo medido fue uv, no pip-tools.

**E1:**

```
$ docker run --rm python:3.12-slim sh -c 'pip install -q pip-tools; pip-compile --version; pip-compile --universal r.in'
pip-compile, version 7.6.2
Error: No such option '--universal'. (Did you mean one of: '--verbose', '--version'?)
exit=2
```

**Dirección:** atribuir `--universal` sólo a `uv pip compile`; para pip-tools, decir que el `requirements.txt` vale para el entorno donde se compiló y que el fabricante pide compilar por entorno; en L1137 cambiar «`pip-compile` sin `--universal`» por «`uv pip compile` sin `--universal`, y `pip-compile` siempre»; aclarar en E4-5 que se usó `uv pip compile` como sustituto de pip-tools.

### adhoc-AH-001-03 — §6.2.3 [criterio] (L893) y respuesta rápida (L983): pnpm hace cumplir `packageManager` por sí mismo, sin Corepack — S3, E1 + E2

**Anclas:** «`packageManager` sigue siendo útil como declaración (la leen Corepack y pnpm [B81]), pero no es un mecanismo de cumplimiento estándar: […] con pnpm o Yarn, instalar Corepack o el gestor explícitamente»; L983: «`packageManager` sigue siendo una declaración útil, no un mecanismo de cumplimiento».

**Problema:** desde pnpm 11, el ajuste `pmOnFail` (default `download`; opciones `download`, `error`, `warn`, `ignore`) gobierna tanto `packageManager` como `devEngines.packageManager` «when the running pnpm version does not match the declared one» (pnpm.io/settings/cli, consultado 2026-10-07). Es decir, pnpm cambia solo a la versión declarada o, con `pmOnFail=error`, falla. Además B81 (`self-update`) no es la página que documenta ese cumplimiento.

**E1** (pnpm 12.10.1 global instalado con npm, Corepack sin habilitar, `packageManager: "pnpm@10.18.0"`):

```
pnpm en el proyecto:
10.18.0            exit=0
con pmOnFail=error:
Error: ERR_PNPM_BAD_PM_VERSION
  × This project is configured to use 10.18.0 of pnpm. Your current pnpm is v12.10.1
exit=1
```

**Dirección:** matizar el criterio: con pnpm ≥ 11, `packageManager` o `devEngines.packageManager` **sí** se hacen cumplir por el propio pnpm (por defecto descargando la versión declarada; en la compuerta, `pmOnFail=error`); Corepack queda como opción para Yarn. Citar pnpm.io/settings/cli (`pmOnFail`) en lugar de, o además de, B81. Ajustar la fila del diagrama L861 («Corepack, si está») si se quiere precisión.

### adhoc-AH-001-04 — Tabla §7.3 (L1075): «Multiplataforma» de pnpm y Yarn queda **[no verificado]** y es verificable — S4, E1

**Ancla:** `| Multiplataforma | sólo los RID declarados | sí | **[no verificado]** | **[no verificado]** | …`

**E1** (`esbuild` 0.25.10 en Linux x64; pnpm 10.18.0 y Yarn 4.10.3):

```
entradas @esbuild/* en pnpm-lock.yaml: 52        (26 paquetes × secciones packages/snapshots)
  '@esbuild/win32-x64@0.25.10': resolution: {integrity: sha512-…} … cpu: [x64]
instaladas: @esbuild+linux-x64@0.25.10
entradas @esbuild/* en yarn.lock: 26
  "@esbuild/win32-x64…": conditions: os=win32 & cpu=x64
```

**Dirección:** reemplazar los dos **[no verificado]** por «sí» y citar el experimento (agregarlo a E4-4 si el laboratorio lo debe reproducir). Ambos locks registran todas las variantes con su `os`/`cpu` e instalan sólo la de la plataforma, igual que npm.

## Revisado y bien

1. **`devEngines`** (§6.2.3, L299, L981): falla por defecto y se evalúa antes de `install`, `ci` y `run` (B63, 2026-10-07); el E1 de AH-001-01 lo confirma sin `onFail`, en npm 10.9.8 y 11.19.x. `engines` «advisory only» salvo `engine-strict`, también exacto.
2. **Estados de Node y Corepack** (§6.2.3): v26 *Current*, v24 y v22 LTS, v20 EOL, ciclo anual con todas las mayores a LTS desde Node 27 (nodejs.org/en/about/previous-releases, 2026-10-07); Corepack eliminado de la distribución en 25.0.0 (PR #57617, release notes v25.0.0); `node:26-alpine` sin Corepack. `npm-shrinkwrap.json` ignorado desde npm 12 (docs v12, 2026-10-07; `npm view npm dist-tags` → `latest: 12.2.0`); `lockfileVersion: 3` desde npm 9.
3. **uv y PEP de Python**: `.python-version` sin cruzar el límite del proyecto, descarga automática por defecto y «3.13» = último parche (docs.astral.sh/uv/concepts/python-versions, 2026-10-07); PEP 686 *Final* con Python-Version 3.15 y final prevista para el 2026-10-09 (PEP 790); PEP 770 *Final* con `.dist-info/sboms/`; el mensaje `SyntaxError: Non-UTF-8 code … see https://peps.python.org/pep-0263/` se reproduce igual en 3.11, 3.12 y `python:3-slim`.

## Solicitudes de convocatoria

Ninguna.
