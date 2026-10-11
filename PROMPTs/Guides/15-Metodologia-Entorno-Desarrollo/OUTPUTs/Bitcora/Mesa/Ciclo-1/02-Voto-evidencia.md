# Mesa · Ciclo 1 · 02 — Voto del juez de evidencia

> Fecha: 2026-10-09. Rol: juez de evidencia (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §4.3.1 y §5.3). Función objetivo: ¿el hallazgo está probado al nivel que declara?
> Artefacto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (3060 líneas). Fuente de los ítems: `01-Consolidado.md`.
> Voto ítem por ítem. En los ítems [CONTRADICCIÓN], `PROCEDE` quiere decir que la evidencia de los dos lados alcanza para que haya una decisión real que tomar; la dirección (a)/(b) la eligen los demás jueces.

## Verificaciones propias (re-ejecutadas por este juez)

Directorio de trabajo: el scratchpad de la sesión (fuera del repo). Imágenes locales `mcr.microsoft.com/dotnet/sdk:8.0` (SDK 8.0.425), `node:22-alpine`, `python:3.12-slim`.

| # | Ítem | Comando (resumen) | Salida |
|---|---|---|---|
| V1 | C1-01 | `global.json` `{"sdk":{"version":"8.0.424","rollForward":"disable"}}` + `dotnet --version` en SDK 8.0.425 | «Learn about SDK resolution: https://aka.ms/dotnet/sdk-not-found», `8.0.425 [/usr/share/dotnet/sdk]`, `rc=145` |
| V2 | C1-02, C1-03 | Copia de `N4/e2-nuget-cpm-pinning` + `PackageVersion Microsoft.Extensions.Primitives 8.0.2`; variante a sin `RestorePackagesWithLockFile`, variante b con lock; `dotnet restore` | a: `warning NU1603: App depends on Microsoft.Extensions.Primitives (>= 8.0.2) but … 8.0.2 was not found. An approximate best match of … 9.0.0 was resolved.` · b: ninguna advertencia; lock `"requested": "[8.0.2, )"`, `"resolved": "9.0.0"` |
| V3 | C1-04 | `api.nuget.org/v3-flatcontainer/microsoft.net.sdk.compilers.toolset/index.json`; `grep BuildWithNetFrameworkHostedCompiler` en los targets del SDK 8.0.425 | 94 versiones, ninguna `8.*` (la primera es `9.0.100-preview.7`); en el SDK 8 sólo aparece el opt-in `BuildWithNetFrameworkHostedCompiler` condicionado a `Windows_NT` |
| V4 | C1-11 | `printf 'const a\xf1o = 1; …'` + `node` 22 | `SyntaxError: Missing initializer in const declaration` |
| V5 | C1-30 | `pip install pip-tools; pip-compile --universal r.in` | `pip-compile, version 7.6.2` · `Error: No such option '--universal'` |
| V6 | C1-27 | `find Examples -name '*.sh' ! -perm -u+x \| wc -l` | `20` |
| V7 | C1-23, C1-47 | `grep -ci 'ejercicio\|actividad\|autoevalu'`; `grep -ci 'entradas:\|salidas:\|validaciones'` sobre la guía | `0`; `0` |
| V8 | C1-22 | Preguntas guía en negrita (`^\*\*¿`) hasta §12 y cuántas cierran con `*Aplica*` en la misma línea | 39 y 9. El método no coincide con el del informe (20 de 57), pero los dos dan minoría |
| V9 | C1-35 | WebFetch de github.com/dotnet/roslyn/pull/83320 | Título «Fix regression in CreateFallbackEncoding», regresión de #82159; prueba `CreateFallbackEncoding_IsNotUtf8OnWindows`. El resumen no muestra la frase «UTF-8 locale» |
| V10 | C1-21 | WebFetch de docs.github.com, *Supported ecosystems and repositories* | `devcontainers`: repositorios privados no soportados |
| V11 | varios | Lectura de las líneas ancladas (`sed -n`) | L933, L883, L291, L1048, L381, L1009, L1131, L885, L975, L979, L474, L1923 (en realidad está en el punto 3 de la lista de L1918–L1926), L1716, L1459, L1570, L2168, L67, L6, L3060, L15, L233, L31/L35/L43, L89–L92, L2115 (no hay `buildx create` en la guía), A.10 `NODE_IMAGE=node:22-bookworm-slim`, `A-plantillas/repo/.nvmrc` = 24.21.0, N8 `.nvmrc` = 22.23.2, esqueleto `compuerta.sh` sin `exit 1`, A.13 sin `docker`, Profile L46 y L48, Rule-Dual-Audience L25 |

## Votos

| Id | Voto | Fundamento |
|---|---|---|
| C1-01 | PROCEDE | Lo reproduje (V1): `disable` con 8.0.424 en una estación con 8.0.425 da rc=145. L933 dice lo contrario. Probado en E1. |
| C1-02 | PROCEDE | Lo reproduje con el SDK 8 (V2): sin lock aparece `NU1603`; con lock, silencio y `resolved 9.0.0`. L1048 y L381 generalizan un caso. El SDK 10 no lo re-ejecuté; para el nivel declarado alcanza con el 8. |
| C1-03 | PROCEDE | La contradicción es real y está bien anclada. V2 confirma la base fáctica del abogado: sin lock la deriva se ve (`NU1603`) y con lock se ve sólo en el archivo. L1009 y L2177 presentan el lock como condición. La nota † (`disable` con lock) también tiene sustento. Hay decisión que tomar. |
| C1-04 | PROCEDE | V3: no hay paquete toolset 8.x y el SDK 8 sólo trae el opt-in. Entonces el «Sí» de L885/L979 no vale para Visual Studio con SDK 8. E1+E2 suficiente. |
| C1-05 | PROCEDE | L1667 promete «archivo presente sin herramienta = rojo». L1909 recomienda poner `.python-version` en la subcarpeta. El `[n/a]` medido sobre N8 muestra que la compuerta no ve esos archivos. Contradicción interna E2 con ejecución E1 citada. |
| C1-06 | PROCEDE | Los prerrequisitos del hook no están declarados en A.11. La salida «violación» por falta de `python3` es E1 del informe y la naturaleza de la lista la vuelve verosímil. La parte de Windows queda, a propósito, como [no verificado]; la dirección no afirma nada que no se pueda sostener. |
| C1-07 | PROCEDE | Lo comprobé en el archivo: el esqueleto de `A-plantillas/repo/tools/ci/compuerta.sh` sólo hace `echo` con `set -eu` y sale 0, así que el hook acepta cualquier cosa. Anexo A L2189 dice «verificadas juntas». |
| C1-08 | PROCEDE | Contradicción real. `grep editorconfig-checker` en la guía da 0, así que falta en §5.2.5 en cualquiera de las dos opciones. El E1 del abogado (4.0.2, rc=1) declara sus límites. Hay decisión que tomar. |
| C1-09 | PROCEDE | `git rm --cached . && git reset --hard` descarta por definición lo que no está commiteado. El E1 del informe lo muestra y L719 no pone precondiciones. |
| C1-10 | PROCEDE | Contradicción con evidencia de los dos lados: E2-6 (`dotnet new` crea archivos con BOM) contra la tabla de A.1, y la rama cp1252 que falta. Hay decisión que tomar. |
| C1-11 | PROCEDE | Lo reproduje para Node (V4): un identificador cp1252 da `SyntaxError`. L474 dice «nunca». El caso Razor (`RZ1005`/`CS1056`) viene del informe; con Node solo ya alcanza para acotar la frase. |
| C1-12 | PROCEDE | Contradicción interna E2 comprobada. El punto 3 de §11.2.5 (L1923, dentro de L1918–L1926) dice «lo único». L299 y L891 dicen que `devEngines` «falla por defecto» con `EBADDEVENGINES` (E3-3). |
| C1-13 | PROCEDE | Lo comprobé en los archivos: A.10 usa `NODE_IMAGE=node:22-bookworm-slim` y `A-plantillas/repo/.nvmrc` dice 24.21.0. El E1 `EBADDEVENGINES` del informe es la consecuencia esperable. |
| C1-14 | PROCEDE | La tabla de §11.3 (L2042–L2043) asigna «por componente» a la CI. `Dockerfile.por-componente` sólo tiene `RUN uv run`, `npm ci` y `dotnet restore --locked-mode`, sin compuerta (lo comprobé con grep). E2 suficiente. |
| C1-15 | PROCEDE | L2115 usa `--builder n8-attest` y la guía no tiene ningún `buildx create` (comprobado). El default de `PY_IMAGE` es `python:3.12-slim@sha256…`, distinto del 3.12.15 que se pide. Copiado tal cual, el bloque falla. |
| C1-16 | PROCEDE | Se sostiene con la propia guía. L1490: atestaciones nativas no disponibles en privados fuera de Enterprise Cloud. L1484–L1496: BuildKit da bases por digest sin firma y un `builder.id` editable. Ningún camino descrito da firma y materiales del entorno a la vez. La parte de `actions/attest` (E4) no la re-consulté, pero no hace falta para el núcleo. |
| C1-17 | PROCEDE | L1570 dice «L1 de inmediato (BuildKit…)». SLSA v1.x define `builder.id` como REQUIRED en la procedencia, y la salida E6-5 citada lo trae vacío. E4+E1 suficiente. |
| C1-18 | PROCEDE | Contradicción real con anclas en el texto: §3.4 L318–L319 separa «con qué se construyó» de la firma, y §12 paso 8 la pone en la ruta estándar. Hay decisión que tomar; depende de C1-16 y C1-17, que proceden. |
| C1-19 | PROCEDE | Comprobé L1716: dice «Pro, Team o Enterprise», y GitHub Pro es un plan de cuentas personales, no de organizaciones. El check `skipped` que satisface la regla y el bypass de administradores están en docs.github.com (E4, consultado 2026-10-07). Lo que «no impide» no está en la guía. |
| C1-20 | PROCEDE | Lo comprobé: el bloque de A.13 (L2535–L2567) lista `dotnet-sdk`, `nuget`, `npm`, `uv` y `github-actions`, sin `docker`. La inconsistencia de rótulo con §8.2.2 es E2 directa. |
| C1-21 | PROCEDE | Contradicción con base verificada (V10): `devcontainers` no se soporta en repositorios privados, así que el digest del devcontainer del caso no tiene bot. Hay decisión que tomar. |
| C1-22 | PROCEDE | Mi conteo (V8) da 9 de 39 por otro método; el del informe da 20 de 57. Los dos muestran minoría. La regla del PO («en qué caso se aplica») es E4. Hay que corregir la cifra si se cita, no el hallazgo. |
| C1-23 | PROCEDE | V7: 0 coincidencias de actividad, ejercicio o autoevaluación. La omisión está probada en E1. |
| C1-24 | PROCEDE | La tabla de §3.3 (L291, L299) usa `devEngines`, `--locked-mode` y `rollForward` antes de §6 y §7. La omisión de explicación es E2 verificable. Lo de «sobrecarga» es juicio didáctico, pero la dirección (señalizar dos velocidades) es proporcional. |
| C1-25 | PROCEDE | En las filas del Anexo C (L2687–L2752) no hay ninguna que empiece por SLSA, BuildKit, CycloneDX, Corepack, RID ni in-toto; los conteos de uso del informe dan la medida. Los sentidos de «índice» son E2 por citas. |
| C1-26 | PROCEDE | L1131 dice «en una biblioteca que se publica … lock no [B83]». La cita literal de [B83] en el informe habla de bibliotecas que *no* se distribuyen y dice «no harm in keeping». Es un error de cita E2. |
| C1-27 | PROCEDE | V6: 20 `.sh` sin bit de ejecución. L89–L92 encadenan `cd` relativos en la misma shell, así que el segundo `cd` falla. E1 reproducible. |
| C1-28 | PROCEDE | La regla del propio script pide un clon limpio y el extracto lo omite (E2 por comparación de texto, citada con línea del script). |
| C1-29 | PROCEDE | La inferencia E2 se sostiene: §8.2.4 admite hashes distintos sin `ContinuousIntegrationBuild`, la frontera A va en la estación y la igualdad se midió sólo en contenedor Release. El criterio de §11.7 no se puede verificar donde se recomienda. |
| C1-30 | PROCEDE | Lo reproduje (V5): pip-compile 7.6.2 rechaza `--universal`. L1075 y L1137 atribuyen la opción a pip-tools. |
| C1-31 | PROCEDE | El E1 del informe (`pmOnFail=error` → `ERR_PNPM_BAD_PM_VERSION`) está ligado a una versión, con cita de pnpm.io. El criterio de L893 («no es un mecanismo de cumplimiento») queda refutado para pnpm ≥ 11. No lo re-ejecuté; el nivel declarado se sostiene con comando y salida. |
| C1-32 | PROCEDE | Es una omisión E4 con fuentes oficiales nombradas y fechadas. La guía (L1496, §9.5) no menciona la vía sin clave ni la verificación del predicado. Su alcance queda subordinado a C1-18, como dice el ítem. |
| C1-33 | PROCEDE | E4 con cita literal de docs.npmjs.com («a scope only ever points to one registry»), y E4-3 sólo mide NuGet. La asimetría de §7.3 L1076 queda probada. |
| C1-34 | PROCEDE | L1459 pone «3.0.1» junto a «ISO/IEC 5962:2021», y la norma ISO/IEC 5962:2021 es la especificación SPDX 2.2.1. El error es E2 directo. |
| C1-35 | PROCEDE | V9 confirma que el PR #83320 arregla una regresión (de #82159) y no fija un comportamiento. La frase de la prueba sobre «UTF-8 locale» no la pude ver en el resumen, pero la dirección propone bajar esa rama a pregunta, no afirmar lo contrario. Alcanza. |
| C1-36 | PROCEDE | Contradicción E2 entre L641 (igualdad del binario) y §2.4/§8.2.4, que descartan esa igualdad en las estaciones. El dato de los seis repositorios declara su límite. |
| C1-37 | PROCEDE | El SHA del squash existe en `main` después de fusionar, y `.git-blame-ignore-revs` lo ignora (E1 del informe con git 2.47.3). L2598 y la señal pobre de L821 lo descartan sin fundamento. |
| C1-38 | PROCEDE | 62 apariciones de `ESC-0` (comprobado). L1137 es un ejemplo literal. E1 suficiente para un S3 de legibilidad. |
| C1-39 | PROCEDE | Comprobé la contradicción literal: L2168 dice «se pueden leer en cualquier orden» y L67 dice «§1 → §12 en orden». |
| C1-40 | PROCEDE | Los conteos de marcas son reproducibles con grep y §0.3 define tres. E1 suficiente. |
| C1-41 | PROCEDE | Comprobado: B14 cita `blob/main` con el SHA sólo en el texto y B49 `blob/main` sin SHA, aunque el Anexo D promete «archivo y commit». |
| C1-42 | PROCEDE | `grep 'Parte I'` encuentra sólo el índice (L31, L35, L43). La tabla de §3.2 reparte las capas de otra forma que L233. E1 suficiente. |
| C1-43 | PROCEDE | Literal: L6 dice «pendiente de relectura integral de la mesa» y L3060 dice «Pendiente de decisión de la mesa». |
| C1-44 | PROCEDE | Profile L46 exige «tablas de entrada … por contexto» (E4) y §3.6 no la tiene. La omisión en §5.4–§8.4 es E2. |
| C1-45 | PROCEDE | Profile L48 exige «Métodos y marcos» (E4); `grep -ciw nix` da 0 y no hay exclusión declarada en §0.1. |
| C1-46 | PROCEDE | Comprobé que `P-01` aparece sólo en L15: las trazas no se resuelven dentro del documento (E2). |
| C1-47 | PROCEDE | Rule-Dual-Audience L25 exige los bloques cuando el documento define un proceso ejecutable, y §5.2.6/§12 lo son; V7 da 0. E4+E1 suficiente. |
| C1-48 | PROCEDE | El grep sobre la ia-db, citado en el informe, no devuelve nada. La dirección se limita a registrar el apartamiento para el PO sin escribir fuera del alcance, que es lo que la evidencia permite. |

## Notas para el relator

- No hay ningún NO_PROCEDE ni INSUFICIENTE: los 48 ítems traen ancla verificable al nivel que declaran. En los que re-ejecuté (V1–V10), la evidencia coincide con lo informado.
- C1-22: si el parche cita una cifra, que use un método de conteo declarado. Mi recuento (9/39) no coincide con el del informe (20/57).
- C1-12: la ubicación «L1923» es el punto 1 de la lista. La frase atacada está en el punto 3 del mismo bloque (L1918–L1926).
- C1-02/C1-03: el SDK 10.0.400 no lo re-ejecuté (sigue abierta C1-Q09). No cambia el voto.
