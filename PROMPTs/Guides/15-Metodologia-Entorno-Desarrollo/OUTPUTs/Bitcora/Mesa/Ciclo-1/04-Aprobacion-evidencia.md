# Mesa · Ciclo 1 · 04 — Aprobación: juez de evidencia

> Fecha: 2026-10-09. Rol: mesa de aprobación, juez de evidencia (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.5). Función objetivo: ¿lo que cada parche agrega está probado al nivel que declara? Chequeo obligatorio: ¿corrige en la capa de origen?
> Insumos: `03-Parches.md` (P-01 a P-24) y la guía `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (3060 líneas, sin parches aplicados).
> Votos posibles: `APLICAR`, `MEJORAR_PLAN`, `NO_APLICAR`, `ESCALAR` (este último sólo ante los siete disparadores de §6 del marco).

## 1. Verificaciones propias

El directorio de trabajo fue el scratchpad de la sesión, fuera del repositorio. Usé las imágenes locales `mcr.microsoft.com/dotnet/sdk:8.0` (8.0.425), `sdk:10.0` (10.0.400) y `python:3.12-slim`. Las páginas web las consulté el 2026-10-09.

### 1.1 Anclas literales

Hice una búsqueda literal (`grep -cF`) en la guía de cada fragmento que los parches P-01 a P-21 mandan reemplazar o usan como ancla. Revisé unas 130 cadenas.

| Resultado | Detalle |
|---|---|
| Únicas | Todas, salvo las dos de abajo |
| **No coincide** | P-12 ítem 16. El parche cita `…en cuanto la plataforma lo ofrezca para el repositorio;…`, pero la guía (L1570) dice `…para el repo;…`. Es un desajuste mecánico: el reemplazo no cambia de sentido. |
| No única, acotada | P-07 ítem 6. La celda `U+FFFD, sin error` aparece en las filas `require`/`import` y `fs.readFileSync`. El parche la acota a «la de esa fila», y con eso alcanza. |

### 1.2 Experimentos re-ejecutados

| # | Parche | Comando (resumen) | Salida | Veredicto |
|---|---|---|---|---|
| J1 | P-10, P-16 (C1-02, C1-03, C1-Q09) | `evidencia-auditor/nu1603-sdk10/run.sh` en `sdk:10.0` y después `grep -A6` sobre la entrada `Microsoft.Extensions.Primitives` del lock | Sin lock: `error NU1603: Warning As Error … 9.0.0 was resolved instead`, rc=1. Con lock: rc=0, `"type": "CentralTransitive"`, `"requested": "[8.0.2, )"`, `"resolved": "9.0.0"` | Confirmado. La salida que versionó el auditor corta el `grep` antes de `requested`/`resolved`, así que **P-22 L11 tiene que versionar la entrada completa** |
| J2 | P-16 (C1-26) | `evidencia-auditor/lock-solo-ejecutables/experimento.sh` en `sdk:8.0` | `.props`: App NO, Lib NO. `.targets`: App SÍ, Lib NO. En modo CI rc=0. Cambio sin regenerar: `error NU1004`, rc=1 | Confirmado, idéntico a la salida del auditor |
| J3 | P-04 (C1-27) | Copia limpia de N1 sin `work/`: los dos `docker run` de P-04 tal como están escritos, con `-u $(id -u):$(id -g)` | `gen=0`; `U+     : FFFD 006E 003A`; `error CS1056`; `stat -c %U work` = `{usuario-del-host}` | Confirmado. Ésta es la «corrida del auditor» que el parche no había versionado |
| J4 | P-12, P-19 | `git ls-remote https://github.com/actions/attest 'refs/tags/v4*'` | `1e69f48a…` = `refs/tags/v4` = `refs/tags/v4.2.2` | Confirmado |
| J5 | P-06, P-11, P-16 | `curl https://mcr.microsoft.com/v2/dotnet/sdk/tags/list` | La lista incluye `8.0.425-bookworm-slim` | Confirmado |
| J6 | P-05, P-07, P-19 | API de GitHub: `pulls/83320` y `pulls/83320/files` | Título «Fix regression in CreateFallbackEncoding», regresión de #82159. En la prueba `CreateFallbackEncoding_IsNotUtf8OnWindows`: «the real ANSI code page (e.g., 1252) even when the UTF-8 locale setting is enabled» y «On Linux/macOS there is no ANSI code page, so the fallback is UTF-8» | Confirmado. Así queda cerrado lo que mi voto V9 no había podido ver |
| J7 | P-19 (C1-41) | `curl -w '%{http_code}'` sobre los permalinks de B14 y B49 | 200 y 200 | Confirmado |
| J8 | P-09 | `registry.npmjs.org/pnpm` | Existen `12.10.1` (latest) y `11.0.0` | Confirmado |

### 1.3 Fuentes re-consultadas (2026-10-09)

| Fuente | Afirmación del parche | Lo que dice la fuente | Veredicto |
|---|---|---|---|
| [B09] slsa.dev/spec/v1.2/build-provenance | P-12: `builder.id` exigido desde L1, «sole determiner», pares firmante/builder | «REQUIRED for SLSA Build L1: `id`»; «intended to be the sole determiner of the SLSA Build level»; «Consumers MUST accept only specific signer-builder pairs» | Fiel |
| [B196] pnpm.io/settings/cli | P-09: `pmOnFail` desde v11, default `download`, gobierna `packageManager` y `devEngines.packageManager` | «Added in: v11.0.0»; default `download`; `download, error, warn, ignore`; «overrides the `onFail` behavior of both…» | Fiel |
| [B194] IEC Webstore 70993 | P-12: ISO/IEC 5962:2021 = SPDX 2.2.1 | «Information technology - SPDX® Specification V2.2.1», 2021-08-24 | Fiel |
| [B199] GitLab Auto-merge | P-13: «Pipelines must succeed» en Free; un MR sin pipeline no se fusiona | Página de Tier Free, Premium y Ultimate; «A merge request with no pipelines at all is not considered to have a successful pipeline, and cannot merge» | Fiel |
| [B176] GitHub plans | P-13: Pro es de cuentas personales y Team de organizaciones; los dos con ramas protegidas en privados | Coincide | Fiel |
| [B177] About protected branches | P-13: chequeo `successful`/`skipped`/`neutral`; administradores exentos por defecto; aprobación del último push | Las tres cosas, literales | Fiel |
| [B202] github-actions-buildtypes `workflow/v1` | P-12, P-14: `resolvedDependencies` debe (SHOULD) traer el commit y puede (MAY) traer los entornos virtuales | Literal | Fiel |
| [B113] Docker best practices | P-11, P-16, P-21: Docker dice que Dependabot actualiza etiqueta y digest | «Dependabot raises pull requests to update your base image tags and digests on a schedule» | Fiel |
| [B118] devcontainers/images `dotnet` | P-11: etiqueta de SO y versión semántica para fijar; `dev-` se actualiza en el lugar | «…to pin to an OS version»; `2.3.1-10.0-noble`; «dev- prefix … may be updated in place; pin the image» | Fiel |
| [B197] Sigstore signing overview | P-12: Fulcio con certificado efímero, Rekor público, instancia propia | «Fulcio issues short-lived certificates binding an ephemeral key to an OpenID Connect identity»; «publicly auditable»; endpoints propios configurables | Fiel |
| [B83] NuGet PackageReference | P-10: lock *opt-in*; biblioteca que no se distribuye o proyecto de código común «should not»; «no harm» | «you can opt-in to the lock file feature»; «a library project that you do not ship or a common code project … you **should not** check in the lock file … There is no harm in keeping the lock file». La nota sobre `rollForward: disable` («all developers … and your CI pipelines, will need to use the same version of the SDK») respalda además el costo que declaran P-09 y P-16 | Fiel |

### 1.4 Evidencia de la bitácora cotejada

- **`evidencia-abogado-del-diablo/repos-de-referencia/salida.txt` (E2-8).** Todos los repos usan `* text=auto`, así que P-08 ítem 4 se sostiene. Los `charset` de `.cs` y `.csproj` por repo coinciden con la tabla nueva de §5.2.3 (`roslyn` y `eShop` `utf-8-bom` en `.cs`; `aspnetcore` `utf-8`; `sdk` con BOM en `.csproj`; `msbuild` y `runtime` sin BOM). **Pero P-08 ítem 3 no se sostiene**: dice que los seis repos declaran `eol` «sólo para `.sh` y, en algunos, `.cmd`, `.bat` y `.sln`». La misma salida trae otras reglas de `eol`: `gradlew`, `jquery*.js`, `jquery*.map` y `bootstrap*.js` en `aspnetcore`; `*.in` en `runtime`; `*.verified.{txt,xml,json}` en `sdk` y `msbuild`.
- **`squash-y-blame/salida.txt`.** Con git 2.47.3 y el SHA del *squash* en `.git-blame-ignore-revs`, `blame` vuelve a atribuir las líneas a `autora`. Sostiene P-08 ítem 12.
- **`editorconfig-checker/salida.txt`.** Da 6 errores y rc=1, y `Cp1252.cs` sale como `"ISO-8859-1"`. Sostiene la fila de editorconfig-checker de P-08.
- **`Informe-adhoc-CAT-FORMAL.md`** (`SyntaxError`, `RZ1005`) y mi verificación V4 sostienen P-07.
- **`Informe-adhoc-AH-001.md`** (`EBADDEVENGINES` sin `onFail`; `ERR_PNPM_BAD_PM_VERSION`) sostiene P-09 y P-14.
- **`Informe-senior-dotnet.md`** (L29–L38, *targets* del SDK 10 con `DOTNET_HOST_PATH` y `_IsDisjointMSBuildVersion < 18.9`) y mi verificación V3 sostienen P-09 ítem 3.
- **`evidencia-auditor/a10-node24/salida.txt`.** v24.21.0, npm 11.19.0, glibc 2.36 en las dos bases y `web/` pasa `devEngines`. Sostiene P-16 ítem 9.
- **`evidencia-auditor/locks-multiplataforma/salida.txt`.** El lock de Yarn trae 26 plataformas. En pnpm el conteo de 52 son 26 claves × 2 secciones (`packages` y `snapshots`); en los dos casos se instala sólo `linux-x64`. Sostiene P-10 ítem 7 y el «26» de su evidencia.
- **Tiempo de N0.** Informe-desarrollador midió `1m24s` con rc=0. Sostiene el «alrededor de un minuto y medio» de P-03 3d.
- **`N8/e6-sbom-unificado/experimento.sh`** (líneas 11 y 32–37) tiene el builder `n8-attest`, `PY15` con el digest `05cda977…` y la invocación sin `version=v1`. Sostiene P-14 ítem 13 y P-22 L14.
- **Trazas.** La tabla de P-21 coincide con `04-Integracion.md` L220 y siguientes y con `02-Cohesion-Global.md` L110–L127, que definen P-01…P-10 y R-01…R-07. El campo `traces:` de la guía (L15) no trae R-04 ni R-05, y la tabla tampoco: es coherente.
- **Destinos.** Existen `Guides/Despliegue/` (enlace de P-03 3a) y B04 = Bazel *Hermeticity* (P-03 3a).
- **Conteo del Anexo E.** Hoy la tabla tiene **63 filas** de datos para 71 experimentos, porque hay filas que agrupan varios IDs (`E0-3a/b/c`, `E0-5 / E0-5b`, …). El criterio de verificación de P-20, «73 filas de experimentos», no puede cumplirse tal como está escrito.

## 2. Votos

| Parche | Voto | Fundamento |
|---|---|---|
| P-01 | APLICAR | Las cuatro anclas son literales y únicas. Las cifras 193 + 11 = 204 y 71 + 2 = 73 son la aritmética de P-19 y P-20. No agrega afirmaciones técnicas. Capa: guía. |
| P-02 | APLICAR | Las tres líneas «Parte» existen (3 coincidencias) y no tienen enlaces entrantes. Es redacción. Capa: guía. |
| P-03 | APLICAR | Las anclas son únicas. Las marcas que se normalizan tienen exactamente las apariciones que dice la tabla 3f (las cuatro `[no verificado en Windows]` incluidas). La exclusión de 3a se declara como **[criterio]** y cita B04 = Bazel, que existe. El enlace `../Despliegue/` existe. El «minuto y medio» lo respalda la medición de 1m24s. El recuadro de Windows queda rotulado **[no verificado]** (requiere Windows) y no afirma nada como hecho. La ruta mínima cita IDs que existen. |
| P-04 | APLICAR | Lo reproduje (J3): los dos comandos, como usuario no root sobre una copia limpia, dan `CS1056` y `FFFD 006E 003A`, y `work/` queda del usuario. **Condición**: versionar esa corrida (P-22 o la salida de N1) para que la frase «verificado por el auditor» tenga archivo. Hoy no lo tiene en `evidencia-auditor/`. |
| P-05 | APLICAR | J6 confirma la reescritura de L180: #83320 es un arreglo, y la prueba dice UTF-8 en Linux/macOS. B19 está en la bibliografía. Los cambios de ACT-ARQ, ACT-OPS y de la matriz son de estructura y se derivan de la decisión 4-0 de C1-18/C1-21. «Se produce sólo en CI» queda como **[criterio]**. Corrige en origen junto con P-23 (`03-Marco-De-Referencia.md`). |
| P-06 | APLICAR | Las citas que reemplazan «fabricantes» son las mismas que ya trae cada fila (B56, B84, B106 y B113 en Fijar; B83, B93, B99 y B101 en Congelar). La fila de `disable` con «falla en toda máquina» está probada (V1, rc=145) y coincide con la nota de [B83]. «En Visual Studio depende del SDK» remite a §6.2.2, que sostiene P-09. La nueva L381 está probada por J1 y V2. La pregunta situada se apoya en E5-1, que existe. |
| P-07 | APLICAR | Todas las afirmaciones nuevas tienen ancla verificada: la prueba de #83320 y su frase literal sobre «UTF-8 locale setting» (J6); el `SyntaxError` de Node (V4 y CAT-FORMAL); `RZ1005` en Razor (CAT-FORMAL; P-22 L3 lo incorpora al laboratorio); `file-5.46` en la línea 1 de `e1-file.txt`, y existe `e1-roslyn-codepage-servidor.txt`. La rama ACP UTF-8 baja de deducción a pregunta abierta con **[no verificado]**: así queda en el nivel que la evidencia permite, que es justo lo que pide esta función objetivo. P-23 corrige el origen de C1-11 en N1. El ancla del ítem 6 queda acotada a su fila. |
| P-08 | **MEJORAR_PLAN** | El hallazgo es válido y casi todo el parche está probado: E2-6, E2-7 (6 errores, rc=1), squash + ignore-revs con git 2.47.3, `text=auto` en los seis repos y los `charset` de `.cs`/`.csproj` por repo. La síntesis de C1-10 tiene base fáctica en los dos lados del empate, así que la acepto en lo que toca a evidencia. **Objeción concreta, ítem 3**: dice que los seis repos `dotnet/*` declaran `eol` «sólo para `.sh` y, en algunos, `.cmd`, `.bat` y `.sln`», y su propia evidencia (E2-8, `repos-de-referencia/salida.txt`) lo contradice: hay `eol=lf` en `gradlew`, `jquery*.js`, `jquery*.map` y `bootstrap*.js` (`aspnetcore`), en `*.in` (`runtime`) y en `*.verified.*` (`sdk`, `msbuild`). Texto propuesto: «…seis repositorios de `dotnet/*` relevados (…; E2-8): todos con `* text=auto`, `eol=lf` para `.sh` en todos y, en algunos, `eol=crlf` para `.cmd`, `.bat` y `.sln`, más reglas puntuales para archivos concretos (scripts sin extensión, bibliotecas JS vendorizadas, *snapshots* de prueba)». Con esa corrección, el resto del parche se aplica como está. Es la vuelta 1 de 2. |
| P-09 | APLICAR | Todo lo que afirma está probado: `pmOnFail` ([B196], literal), pnpm 12.10.1 y 11.0.0 existentes (J8), `ERR_PNPM_BAD_PM_VERSION` (AH-001), rc=145 de `disable` (V1), la nota de [B83] sobre `disable`, los *targets* del SDK 8 sin selección y sin paquete 8.x (V3) y los del SDK 10 (`DOTNET_HOST_PATH`, `< 18.9`; senior-dotnet L29–L38). Lo que no se ejecutó (el compilador efectivo en un Visual Studio real) queda **[no verificado]**: el nivel declarado coincide con el probado. La tabla de dos políticas aplica la decisión 3-1 de C1-03. P-23 corrige el origen en CI-05 y N3. |
| P-10 | APLICAR | J1 confirma en el SDK 10 lo que el ítem 3 afirma: con lock, `requested [8.0.2, )` y `resolved 9.0.0`, rc=0; sin lock, `NU1603` como error, rc=1. El SDK 8 lo cubre V2. La cita de [B83] es fiel (§1.3). `pip-compile --universal` → `No such option` (V5). pnpm y Yarn multiplataforma: 26 plataformas en el lock y una instalada. [B198] y [B110] sostienen los huecos por ecosistema; la frase de §7.6 sobre la alternativa sin lock está rotulada **[criterio]**. **Condición** para P-22 L11: que la salida versionada incluya `requested`/`resolved` (la del auditor la corta). |
| P-11 | APLICAR | [B113] dice literalmente «tags and digests», [B118] es fiel, la etiqueta `8.0.425-bookworm-slim` existe (J5) y el «devcontainers no soportado en privados» ya lo había verificado (V10). El matiz «GitHub no lo menciona, el laboratorio no lo observó» queda **[no verificado]** (requiere la plataforma): es el nivel correcto. Lo de que la *feature* de Node instala `"lts"` sin versión ya estaba en la guía con [B137] (L1242). P-23 corrige el origen en CI-06. |
| P-12 | APLICAR | [B09], [B194], [B197] y [B202] son fieles (§1.3). `builder.id` vacío en E6-5 está en la propia guía (L1484). attest v4.2.2 = `1e69f48a…` (J4). Que `verify-blob-attestation` no evalúa el predicado se apoya en [B10] y la conclusión está acotada. La firma sin clave y cómo completar `builder.id` en BuildKit quedan **[no verificado]**. **Corrección mecánica del ancla, ítem 16**: el texto actual dice «para el repo», no «para el repositorio» (L1570). Se reemplaza la respuesta completa de esa línea; el sentido del parche no cambia. P-23 corrige el origen en N6 y en el marco. |
| P-13 | APLICAR | [B176], [B177] y [B199] son fieles (§1.3). Que en `pull_request` el SHA es el del *merge commit* (B200) es coherente con la columna «Qué no impide». El alcance declarado de la compuerta se apoya en el E1 del arquitecto (`n/a` en N8). ESC-01 por Git Bash queda **[no verificado]**. El extracto de `publicar.sh` se declara extracto de E7-5, y P-22 L13 y la verificación lo cubren. Origen corregido en N7 por P-23. |
| P-14 | APLICAR | `devEngines` falla por defecto (AH-001; npm 10.9.8 y 11.19). El digest `PY15` está en `e6-sbom-unificado/experimento.sh` y en N8/README. El bloque de §11.5 reproduce las líneas 32–37 del experimento (builder `n8-attest`, sin `version=v1`). [B202] sostiene «el entorno es opcional en la procedencia de la plataforma». Las «tres piezas» se rotulan **[criterio]**, y Git Bash y WSL quedan **[no verificado]**. La verificación exige correr literalmente el bloque (P-22 L16), que es lo adecuado. |
| P-15 | APLICAR | Es estructura y alineación con decisiones ya votadas (C1-18 4-0, C1-21 4-0, C1-03 3-1). El hook en Visual Studio queda rotulado **[no verificado]**. Las validaciones del YAML citan errores ya probados (`A compatible .NET SDK was not found` V1; `NU1004` J2; `EUSAGE` E4-4). |
| P-16 | APLICAR | La pieza técnica nueva más sensible, `Directory.Build.targets` en lugar de `.props`, la reproduje (J2). A.10 con Node 24 por digest está construida y probada (`a10-node24`). Que el esqueleto falle a propósito es una decisión de diseño (C1-07) sin afirmación fáctica. El ecosistema `docker` en A.13 lleva el matiz de [B113]/[B107] con **[no verificado]**. El criterio de verificación es fuerte: `diff` byte a byte entre el anexo y `A-plantillas`, más EA-1 en verde. |
| P-17 | APLICAR | No agrega hechos: alinea las listas con P-06, P-09, P-11 y P-15, cuya evidencia ya validé. |
| P-18 | APLICAR | Las definiciones nuevas repiten hechos que la guía ya sostiene con fuente: ECMA-424 [B156] (L1460), Corepack fuera de Node desde la 25 (L983) y SPDX 2.2.1 = ISO/IEC 5962 [B194]. La expansión de SLSA y SBOM es redacción. |
| P-19 | APLICAR | Los permalinks responden 200 (J7) y la descripción de B15 coincide con J6. B194 a B204 tienen la fecha correcta y las que re-consulté son fieles. B155 deja de atribuirse un estatus ISO que corresponde a 2.2.1 y no a 3.0.1. |
| P-20 | APLICAR | El contenido está bien. **Ajuste del criterio de verificación**: hoy hay 63 filas para 71 experimentos, así que «73 filas de experimentos» no se puede cumplir. Cambiarlo por «73 IDs de experimento distintos, todos con su fila» (`grep -oE` de IDs sobre el Anexo E, contando los agrupados como `E0-3a/b/c`). No toca la guía. |
| P-21 | APLICAR | La tabla de trazas coincide con la de `04-Integracion.md` y `02-Cohesion-Global.md`. Los nuevos ítems «no verificado» rotulan exactamente lo que no se ejecutó, y el matiz de Dependabot es fiel a [B113]/[B107]. La decisión de SBOM no agrega hechos: remite a §9.2.3 (P-12). |
| P-22 | APLICAR | Es la capa de evidencia ejecutable, y cada fila trae su verificación observable. Dos **condiciones**: (a) en L11, la salida versionada tiene que incluir `requested`/`resolved` (J1); (b) sumar la corrida de P-04 (J3) a las salidas de N1. El relevamiento E2-8 se versiona fechado y sin re-correr, lo que es correcto para una fuente que cambia. |
| P-23 | APLICAR | Corrige en la **capa de origen**, como pide el chequeo obligatorio, con notas fechadas de solo agregado y sin borrar texto. Las notas repiten hechos que verifiqué arriba (rc=145, `NU1603` con y sin lock, `builder.id`, ISO 5962, Team y Pro, `devEngines`, `--universal`). Cuando se reformule P-08, la nota de N2 sobre el *squash* no cambia. |
| P-24 | APLICAR | Es de proceso. No escribe la ia-db, que queda fuera del alcance de escritura, y registra el apartamiento para el PO, como pide la práctica del proyecto. No es ninguno de los siete disparadores: no cambia el alcance de la guía ni es irreversible. No corresponde ESCALAR. |

## 3. Resumen

- **APLICAR**: 23 parches (P-01 a P-07 y P-09 a P-24). Cuatro de ellos llevan una condición o un ajuste que no cambia su sustancia:
  - P-04: versionar la corrida J3.
  - P-10 y P-22 L11: la salida versionada tiene que mostrar `requested`/`resolved`.
  - P-12 ítem 16: el ancla literal es «para el repo».
  - P-20: el criterio pasa a ser «73 IDs», no «73 filas».
- **MEJORAR_PLAN**: P-08, por una sola razón. El ítem 3 afirma «sólo» donde su propia evidencia (E2-8) muestra otras reglas de `eol`. Arriba va el texto propuesto. Es la vuelta 1 de 2.
- **NO_APLICAR**: ninguno.
- **ESCALAR**: ninguno. No se activa ninguno de los siete disparadores de §6. La síntesis de C1-10 que trae P-08 no es un empate persistente ante este juez: la evidencia de los dos lados queda incorporada y el desacuerdo que queda es de redacción.
- **Capa de origen**: P-23 corrige N0–N8, `03-Marco-De-Referencia.md` y `04-Integracion.md` antes que la guía, y P-22 corrige el laboratorio. Ningún parche parchea la guía tapando un defecto que nació en otra capa.
