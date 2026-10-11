# Mesa · Ciclo 3 · Informe del abogado del diablo

- **Rol**: abogado del diablo (núcleo permanente). Marco: `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §4.1.1 (mandato de atacar la propuesta dominante; entra después de leer al resto) y §9 (anclaje, consenso vacío).
- **Objeto**: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md`, **1.0.0 / vigente** (3605 líneas, 54 267 palabras). «L*n*» = línea de ese archivo al 2026-10-09.
- **Fecha**: 2026-10-09.
- **Orden de lectura, a propósito**: primero la guía completa como obra terminada; después lo cerrado del ciclo 2 (`Ciclo-2/05-Aplicacion.md`, mi informe del ciclo 2) y la fila C1-03 del ciclo 1; por último los once informes del ciclo 3.
- **Lo cerrado que no reabro**: C1-03 (lock por defecto en .NET con `disable`), C1-08 (compuerta propia), C1-10 (tabla de BOM por extensión), C1-18 (8a/8b), C1-21 (devcontainer), C2-36 (compresión sin tope duro, saldo de prosa ≤ 0). Donde un hallazgo toca uno de ellos, digo qué evidencia **nueva** trae y pido corregir la premisa o el texto, no la decisión.
- **Evidencia propia** en `evidencia-abogado-del-diablo/` (cuatro carpetas, cada una con script y `salida.txt`; no se tocó `Examples/`):
  - `01-bom-razor/`: BOM de plantillas de proyecto e ítem, y si algún comando del SDK lo repone en `.razor` (SDK 8.0.425 y 10.0.400).
  - `02-capa4-y-artefacto/`: el mismo commit, el mismo SDK 8.0.425, tres sistemas operativos y tres rutas; control con otro SDK.
  - `03-sdk8-eol/`: `dotnet sdk check` dentro de la imagen que fija A.10 y metadatos oficiales de soporte.
  - `04-compresion/`: peso por sección y repeticiones medidas sobre la guía.
  - Fuentes web consultadas el 2026-10-09: `.editorconfig` y `global.json` de ocho repositorios `dotnet/*` (raw.githubusercontent.com), árbol de seis por la API de GitHub, y https://learn.microsoft.com/en-us/dotnet/core/tools/global-json.

## Qué ataco y qué no

En el ciclo 1 la pregunta era «¿necesario u opción?»; en el ciclo 2, «¿lo que se copia entrega lo que se recomienda?». En el ciclo 3, con la guía declarada `vigente`, la pregunta es otra: **¿la propuesta dominante se sostiene como la industria la practica, o es una preferencia de la guía presentada como norma?** El mandato del PO para este ciclo es además edición y compresión. Ataco tres premisas:

- **El peso de la capa 4.** «Digest» aparece 121 veces y «runner alojado» 4. Seis informes del ciclo 3 proponen resolver la contradicción abierta digest/runner agregando cláusulas en unos quince lugares. Mi E1 dice que la premisa misma está mal dimensionada (01).
- **El pin exacto.** `rollForward: disable` es el default de la guía, y lo presenta como práctica del fabricante (03, con 04 sobre la fecha).
- **«UTF-8 sin BOM» para la familia .NET en repo nuevo.** Ataco el costo declarado y la razón que se da para el `.razor`, no la tabla (02).

Cierro con el consenso de método, que se repite por tercer ciclo (05).

## Hallazgos

### abogado-diablo-C3-01 · S2 · E1: la capa 4 no cambia los bytes del artefacto .NET. «La imagen propia hace falta para la reconstrucción bit a bit» es falso, y la contradicción digest/runner se resuelve con una definición, no con quince cláusulas

- **Ubicación**:
  - §8.2.2 punto 1 (L1414): «La imagen propia hace falta para 8b, la reconstrucción bit a bit o la frontera A en la CI».
  - §12 paso 7 (L2477): «(para 8b, reconstrucción bit a bit o frontera A en la CI)».
  - §12 paso 8a (L2478) y contrato YAML: «digest de la imagen» como contenido obligatorio del registro.
  - §9.6 (L1796): «construir con el mismo toolchain **e imagen** y comparar sha256».
  - Lo mismo, como regla sin excepción, en §8.2.2 punto 5, §8.6, §8.7, §10.6, §10.7, §11.3, §11.4, B.3 y B.4 (el inventario de arquitecto-software-01).
- **Propuesta atacada**: la imagen por digest como condición de lo publicado y, con ella, la capa 4 como dato obligatorio del registro 8a. Es la premisa que comparten requisitos-01, didáctica-02, arquitecto-software-01 y -02, AH-002-02 y desarrollador-03, que sólo discuten **dónde** poner la excepción del runner.
- **Ancla (E1, `02-capa4-y-artefacto/salida.txt`)**: el mismo proyecto `net8.0` (con un literal verbatim multilínea y acentos), el mismo commit (fechas de git fijadas) y `-c Release -p:ContinuousIntegrationBuild=true`. Tres bases, tres rutas; en dos de ellas el SDK se instaló con `dotnet-install.sh`, que es lo que hace `actions/setup-dotnet`:

  ```text
  == imagen oficial sdk:8.0 | SO: Debian GNU/Linux 12 (bookworm) | glibc: 2.36 | SDK: 8.0.425 | ruta: /w/a
     dll 9815b804e89acc33   pdb 39c56299b47eef9f
  == ubuntu:24.04 + dotnet-install | SO: Ubuntu 24.04.5 LTS | glibc: 2.39 | SDK: 8.0.425 | ruta: /home/runner/work/pieza/pieza
     dll 9815b804e89acc33   pdb 39c56299b47eef9f
  == python:3.12-slim + dotnet-install | SO: Debian GNU/Linux 13 (trixie) | glibc: 2.41 | SDK: 8.0.425 | ruta: /srv/otra/ruta
     dll 9815b804e89acc33   pdb 39c56299b47eef9f
  == CONTROL imagen oficial sdk:10.0 (otro SDK) | SO: Ubuntu 24.04.4 LTS | glibc: 2.39 | SDK: 10.0.400 | ruta: /w/a
     dll 7cd2a836de83b37e   pdb bf63c38442173f34
  ```

  `ubuntu:24.04` = `ubuntu@sha256:534baea6…`. El control prueba que el experimento distingue: cambiar la capa 2 cambia el hash; cambiar la capa 4 (distribución, glibc, ruta, origen del SDK) no lo cambia. Es coherente con E8-5 de la propia guía (dos imágenes, la misma DLL) y con §3.5 («Sí [fija la capa 2], si viene en la imagen»): lo que importa es la capa 2 que trae la imagen, no la imagen.
- **Qué muestra**:
  1. Para un artefacto .NET gestionado (DLL y PDB *framework-dependent*), reconstruir bit a bit pide el **mismo SDK exacto** y `ContinuousIntegrationBuild`, no la misma imagen. El camino «runner alojado + `setup-dotnet` por SHA leyendo `global.json`» con `disable` reconstruye igual que la imagen propia.
  2. La capa 4 importa para otras cosas, que la guía no separa: el comportamiento **en ejecución** (OpenSSL, ICU, `tzdata`: E5-2 mide justo eso, no bytes del artefacto), los artefactos **nativos** (módulos de Node con addons, ruedas de Python con extensiones C; no medido aquí) y el caso en que el artefacto **es** una imagen.
  3. Por eso la objeción de arquitecto-software-02 (el log del runner caduca a los 90 días) pesa menos para reconstruir el artefacto .NET y más para diagnosticar su ejecución. Es un argumento para registrar la capa 4 cuando se pueda, no para exigirla en 8a.
- **Límites**: un solo SDK (8.0.425), sólo linux/amd64, sólo build *framework-dependent* (sin `-r`, *self-contained*, ReadyToRun ni AOT, que no se probaron). No se midió un artefacto nativo.
- **Contra-tesis [criterio]**: escribir **una vez**, en §8.2.2, qué decide cada capa sobre el artefacto. La capa 2 exacta lo decide para lo gestionado; la capa 4 lo decide para lo nativo, para la ejecución y para lo que se publica como imagen. De ahí salen los dos caminos sin contradicción:
  - **8a**: el registro exige el toolchain efectivo. La imagen se registra por digest si la CI corre en contenedor, y por versión del runner si no. `NO DECLARADA` deja de ser un incumplimiento y pasa a ser un valor admitido con su motivo.
  - **Imagen propia por digest**: cuando el repo publica artefactos nativos o imágenes, cuando hace falta la frontera A en la misma base que el devcontainer, o cuando un consumidor exige la capa 4.
  - **«Reconstrucción bit a bit»** sale de la lista de motivos de la imagen propia en §8.2.2 punto 1 y §12 paso 7, y §9.6 dice «con el mismo toolchain (y, para artefactos nativos, la misma imagen)».
  - Las demás menciones remiten a §8.2.2. La regla «nunca etiqueta flotante en la CI que publica» queda acotada a lo que **el repo nombra** (como pide arquitecto-software-01).
- **Impacto**: si se aplica la dirección del panel tal como está, la guía suma unas quince cláusulas de excepción a una regla cuya premisa no se midió. La guía es la que más peso pone en la capa 4 (121 «digest»), y el caso es un sistema .NET gestionado de un equipo chico. Ese lector termina construyendo y manteniendo una imagen propia que no le cambia un byte del artefacto.
- **Dirección**:
  - Sumar este E1 al laboratorio como E5-8 (o E6-7): tres bases, mismo SDK, mismo hash, control con otro SDK.
  - Reescribir §8.2.2 punto 1 como la definición de arriba. Corregir L1414, L2477 y L1796.
  - En el paso 8a de §12 y su validación: «toolchain efectivo; imagen: digest o versión del runner, nunca vacío».
  - Reemplazar las cláusulas del panel por una remisión a §8.2.2 en cada lugar que la pide.
- **Confianza**: 0,8. El E1 es de un SDK y una arquitectura. Que la capa 4 importe para lo nativo es inferencia **[interpretación]**: está documentada en general, pero aquí no se midió.

### abogado-diablo-C3-02 · S3 · E1 + E2: «UTF-8 sin BOM» para la familia .NET en un repo nuevo tiene un costo **recurrente** que la guía declara como único, y la razón que da para el `.razor` con BOM («las herramientas lo reponen») es falsa; la decisión sí coincide con lo que hace el fabricante

- **Ubicación**:
  - §5.2.3, rama «Repositorio nuevo» (L719): «El costo: el `Program.cs` y el `.csproj` que crea `dotnet new console` llegan con BOM y hay que normalizarlos **antes del primer commit**».
  - A.1 L2558: «… se normaliza antes del primer commit».
  - §5.2.3 L723: «`*.razor`, `*.cshtml` y `*.sln` van con BOM en las dos variantes, porque las herramientas del SDK **lo reponen**».
  - §11.2.2 (L2172): «`.razor`/`.cshtml`/`.sln` con BOM (las herramientas del SDK lo reponen)».
  - A.1 L2546: «crean o reponen estos con BOM».
- **Propuesta atacada**: la variante A («sin BOM») como default copiable de la familia .NET, y la asimetría `.cs` sin BOM / `.razor` con BOM, justificada por las herramientas.
- **Ancla (E1, `01-bom-razor/salida.txt`, SDK 8.0.425 y 10.0.400, idénticos en lo que importa)**:

  ```text
  -- 1. plantilla de proyecto (dotnet new blazor)
  *.razor: conBOM=9 sinBOM=0          (SDK 10: 11 y 0)
  *.cs: conBOM=0 sinBOM=1
  -- 2. plantillas de ITEM: dotnet new razorcomponent / class / interface
  Items/Nuevo.razor: BOM
  Items/Clase.cs: BOM
  Items/IFace.cs: BOM
  -- 3. se quita el BOM de TODOS los .razor existentes ... build, format whitespace, add package
  -- 4. después de build, format y add package:
  *.razor: conBOM=0 sinBOM=10         (SDK 10: 0 y 12)
  build con .razor UTF-8 SIN BOM y acentos rc=0
  ```

- **Anclas (E2, archivos de los repositorios, 2026-10-09)**:
  - `dotnet/aspnetcore/.editorconfig` L95–L96 y `dotnet/aspire/.editorconfig` L103–L104: `[*.{razor,cshtml}] charset = utf-8-bom`, con `[*] charset = utf-8` para el resto.
  - `dotnet/roslyn` L13–L16 y `dotnet/eShop` L18–L21: `[*.{cs,csx,vb,vbx}] … charset = utf-8-bom`.
  - `dotnet/runtime` L15–L17: «Specify UTF-8 without byte-order mark» para `[*.{csproj,…,slnx,…}]`, lo que coincide con senior-dotnet-04.
- **Qué muestra**:
  1. **El costo de la variante A no termina en el primer commit.** Cada `dotnet new class`, `interface` o `razorcomponent` crea el archivo **con** BOM, en SDK 8 y 10. En un repo nuevo con variante A, cada `.cs` que entra por plantilla de ítem dispara la compuerta y hay que pasarle `dotnet format`. La guía lo presenta como un paso que se hace una vez.
  2. **Ningún comando del SDK repone el BOM de un `.razor`.** Ni `build`, ni `format whitespace`, ni `add package`. Lo **traen** las plantillas al crear, igual que con `.cs`. «Reponer» sólo está probado para `.sln` (`dotnet sln add`, E2-6). Con la misma evidencia, la guía saca dos conclusiones opuestas: para `.cs`, «se normaliza lo que trae la plantilla»; para `.razor`, «se sigue a la plantilla».
  3. **El ataque de fondo no prospera.** La asimetría `.cs` sin BOM / `.razor` con BOM es exactamente la de `dotnet/aspnetcore` y `dotnet/aspire`. Es práctica del fabricante, no preferencia de la guía, y Razor compila sin BOM con acentos (paso 5). La razón correcta es «convención de los repos de ASP.NET Core y de las plantillas», no «las herramientas lo reponen».
- **No re-litigo C1-10**: la tabla y sus ramas quedan como están. Corrijo el costo declarado y la razón de una fila.
- **Contra-tesis [criterio]**: el punto 1 refuerza la variante B para el caso, que es un heredado ya convertido con BOM. Con B, todas las plantillas de ítem de C# y Razor entran sin fricción. Lo que pelea con B es sólo el `Program.cs` y el `.csproj` sin BOM de las plantillas web y el `.slnx` (senior-dotnet-04).
- **Impacto**: es la primera pregunta del PO, «¿con o sin BOM?». El equipo que elige A por la frase de L719 descubre recién en el uso diario que cada ítem nuevo vuelve rojo el hook. Para un equipo con Visual Studio, esa es la experiencia que empuja a usar `--no-verify`.
- **Dirección**:
  - L719 y A.1 L2558: «cada archivo que crea una plantilla del SDK, de proyecto o de ítem (`dotnet new class`, `razorcomponent`), llega con BOM. `dotnet format` lo normaliza en los `.cs` y la compuerta lo señala en el resto (E1)». Lo que hagan las plantillas de ítem de Visual Studio queda **[no verificado]**.
  - L723, §11.2.2 y A.1 L2546: «`.razor`/`.cshtml` con BOM: lo crean así las plantillas y lo declaran `dotnet/aspnetcore` y `dotnet/aspire`; `.sln` con BOM: `dotnet sln add` lo repone». Citar los dos `.editorconfig` como fuentes nuevas, o sumarlos a E2-8.
  - Sumar a E2-6 el caso de ítem y el de «quitar y correr comandos».
- **Confianza**: 0,85.

### abogado-diablo-C3-03 · S3 · E2: el pin exacto (`disable`) es criterio de esta guía, no lo que hace el fabricante, y §6.3 y §10.3 lo rotulan «fabricante»; el mecanismo que el fabricante sí usa para tener «el SDK exacto en toda máquina» no aparece

- **Ubicación**:
  - §6.3, fila .NET (L1039): «`global.json` con versión exacta y `rollForward: disable` cuando hay lock files [B56]» | «fabricante».
  - §10.3, fila .NET (L1997): «`--locked-mode` en CI y `rollForward: disable` con lock files [B83]» | «Fabricante».
  - §6.2.2 (L997): «desde el SDK 10 `paths` y `errorMessage`», mencionados como propiedades y nada más.
  - §6.4: costo de `disable` («instalador independiente si Visual Studio trae otro»).
- **Propuesta atacada**: «lock + `disable`» presentado, en las tablas de «Qué propone la industria», como la práctica del fabricante.
- **Ancla (E2)**:
  - [B56], https://learn.microsoft.com/en-us/dotnet/core/tools/global-json (2026-10-09). La página abre así: «In CI (continuous integration) scenarios, however, you typically want to specify an acceptable **range** for the SDK version that is used», con un ejemplo `latestFeature`. `disable` aparece sólo como condicional: «When you use package lock files, set `rollForward` to `disable`».
  - `global.json` en `main` de ocho repositorios `dotnet/*` (2026-10-09):

    | Repositorio | `rollForward` | `paths` |
    |---|---|---|
    | eShop | `latestFeature` | — |
    | roslyn | `patch` | — |
    | runtime | `major` | `[".dotnet", "$host$"]` + `errorMessage` |
    | aspire | `major` | `[".dotnet", "$host$"]` + `errorMessage` |
    | sdk | `latestFeature` | `[".dotnet", "$host$"]` + `errorMessage` |
    | efcore | `latestMajor` | `[".dotnet", "$host$"]` + `errorMessage` |
    | aspnetcore | (ausente) | `[".dotnet", "$host$"]` + `errorMessage` |
    | maui | (ausente) | `[".dotnet", "$host$"]` |

    **0 de 8** usan `disable`.
  - Árbol de cuatro de ellos por la API de GitHub (eShop, roslyn, aspnetcore, efcore; `truncated=False`): **0** `packages.lock.json`; usan CPM (1, 8, 2 y 5 `Directory.Packages.props`).
- **Qué muestra**:
  1. El fabricante, en su documentación y en sus repos, practica lo que la guía llama «política sin lock»: CPM y `rollForward` de rango. La regla «`disable` con lock» es correcta, pero es condicional a una elección (el lock en NuGet) que la guía toma por su cuenta. La propia apertura de §7 lo declara («esta guía lo adopta por defecto»), y las tablas de industria de §6.3 y §10.3 lo borran.
  2. Para el problema que la guía le atribuye a `disable` en ESC-01 (Visual Studio reemplaza el SDK), el fabricante usa `paths: [".dotnet", "$host$"]` con `errorMessage`: un SDK local del repo, instalado por un script, que el muxer busca primero [B56]. La guía nombra las dos propiedades, pero no las presenta como esa estrategia. Que Visual Studio respete `paths` no está documentado en [B56] **[no verificado]**.
- **No re-litigo C1-03**: el default queda. El dato de eShop ya estaba en el voto. Lo nuevo es el patrón de ocho repos y la frase de [B56] sobre CI, que contradicen el **rótulo** «fabricante» de dos tablas.
- **Contra-tesis [criterio]**:
  - Rotular en §6.3 y §10.3: «`disable` cuando hay lock (fabricante, condicional); lock por defecto en .NET: **[criterio]**. El fabricante, en su documentación y sus repos, usa rango en CI y CPM sin lock (8 de 8 sin `disable`, 0 de 4 con lock)».
  - En §6.4, fila «Con lock», sumar al costo la mitigación del fabricante con SDK 10: `paths` + `errorMessage` + script de instalación, con su **[no verificado]** en Visual Studio.
- **Impacto**: P-09 pide «qué propone hoy la industria». El lector de consulta que entra por las tablas n.3 se lleva que el pin exacto con lock es la práctica del fabricante, cuando es una preferencia defendible de esta guía con un costo que el fabricante resuelve de otro modo.
- **Dirección**: dos celdas en §6.3 y §10.3, y una oración en §6.4. Con la tabla de ocho repos en el Anexo F o como E2-9. Saldo de palabras casi neutro.
- **Confianza**: 0,8. Los repos `dotnet/*` grandes usan Arcade y no son un equipo chico. eShop es el análogo más cercano y va en la misma dirección.

### abogado-diablo-C3-04 · S3 · E1 + E2: la hoja de ruta fija **primero** y pregunta por el soporte **después**; el día de la versión 1.0.0, el SDK que fijan las plantillas y la imagen sale de soporte en 32 días, y el único aviso que la guía recomienda no existe en ese SDK

- **Ubicación**: §12 paso 5 (L2475) y validación «paso 5»; §6.4 (fila «Con lock»); §6.5 (`global.json` 8.0.425); A.3 (nota final); A.10 (`sdk:8.0@sha256`); §10.2.6 «Cadencia».
- **Ancla**:
  - E1 (`03-sdk8-eol/salida.txt`). `dotnet sdk check` dentro de la imagen de A.10, con el host en 2026-10-09: `8.0.425  .NET 8.0 is going out of support soon.` Funciona sin configuración.
  - Metadatos oficiales (https://builds.dotnet.microsoft.com/dotnet/release-metadata/releases-index.json, 2026-10-09): `8.0 lts maintenance eol: 2026-11-10`; `10.0 lts active eol: 2028-11-14 latest-sdk: 10.0.401`.
  - Senior-dotnet-01 (E1, ciclo 3): `CheckSdkVulnerabilities`, que §6.3 y §10.2.6 recomiendan como el aviso de «fuera de soporte», no existe en 8.0.425 ni en 10.0.400.
  - A.3 ya dice «.NET 8 sale de soporte el 2026-11-10: un repo nuevo parte de la última 10.0.4xx», pero §12, que es el orden de adopción, no lo dice.
- **Qué muestra**: un equipo con el heredado del caso que sigue §12 el día de la publicación hace lo siguiente:
  - fija 8.0.425 con `disable` (paso 5);
  - genera los locks con ese SDK (paso 6);
  - construye la imagen por digest (paso 7).

  Treinta y dos días después tiene que mover todo junto con un ADR (§10.2.6). Es el «congeló vulnerabilidades» de §8.2.2 aplicado a la capa 2, y la red de aviso que la guía le da no se dispara.
- **Contra-tesis [criterio]**: el paso 5 empieza por **elegir un SDK con soporte**. Si el actual sale de soporte antes del próximo ciclo de parches, el ADR de `rollForward` es también el de la subida de mayor, y `global.json`, imagen y locks se generan una sola vez. La herramienta que avisa en SDK 8 y 10 es `dotnet sdk check` (E1), en un job programado. `CheckSdkVulnerabilities` sirve recién desde el SDK 11 (senior-dotnet-01).
- **Impacto**: es una guía `vigente` cuyo camino de adopción produce, en su propia fecha, un toolchain fijado a un mes del fin de soporte.
- **Dirección**: una oración en §12 paso 5 («antes de fijar, elegir un SDK con soporte: al 2026-10-09, .NET 8 termina el 2026-11-10 [B61]») y `dotnet sdk check` en §6.3 y §10.2.6, en lugar de `CheckSdkVulnerabilities` o junto con él. Plantillas y laboratorio quedan en 8.0.425 como «el del caso». Migrar EA-1 a SDK 10 costaría mucho más que lo que gana.
- **Confianza**: 0,8.

### abogado-diablo-C3-05 · S2 · E1 + E2: consenso de método, tercera vez. El PO pidió edición y compresión; el panel del ciclo 3 propone casi sólo agregar, y la guía repite sus tesis centrales entre 10 y 14 veces

- **Ubicación**: global. PO: «hacer las correcciones pertinentes en edición y compresión ajustando su coherencia». Rule-Narrative-Voice: «si un párrafo se puede borrar sin perder información, sobra».
- **Ancla (E2, mi clasificación de las «Dirección» de los 52 hallazgos del ciclo 3, [criterio] en la asignación)**:

  | Informe | Agrega texto, filas, consignas o pasos | Neutro (corrige con largo parecido) | Quita |
  |---|---|---|---|
  | requisitos | 02, 03, 04 | 01, 05 | — |
  | verificación-evidencia | 01, 02, 04 | 03 | — |
  | lector-sin-contexto | 01, 03, 04, 05 | 02 | — |
  | didáctica | 01, 02, 04 | 03, 05 | — |
  | edición bibliográfica | 01, 02, 04 | 03, 05 | — |
  | senior-dotnet | 01, 04 | 02 | 03 |
  | arquitecto-software | 01, 02, 05 | 03, 04, 06 | — |
  | desarrollador | 01, 02, 03 | 04, 05, 06 | — |
  | AH-001 | 01 | 02, 03, 04 | — |
  | AH-002 | 01, 02, 03 | 04 | — |
  | CAT-FORMAL | 01, 03 | 02, 04 | — |
  | **Total** | **≈ 30** | **≈ 21** | **1** |

- **Ancla (E1, `04-compresion/salida.txt`, `medir.py` sobre la guía, fuera de bloques de código)**:

  ```text
  12  el contenedor no arregla / el cp1252 falla igual adentro (E5-1)
  14  Visual Studio sin devcontainer .NET
  10  hook se saltea con --no-verify
  11  [no verificado] (requiere Windows)
   9  SDK exacto
  121  digest            4  runner alojado
  §3.5 tabla «¿la fija el contenedor?»: 200 palabras · §8.2.1, la misma tabla con evidencia: 253
  seis preguntas guía con la tesis «el contenedor no reemplaza la política» (§3.7, §4.6, §7.6, §8.6 ×3): 335 palabras
  §11: 5860 palabras, la sección más larga; §12, la que ordena todo: 1148
  ```

- **Por qué es sospechoso**: es CS2-3 del ciclo 2 otra vez. C2-36 fijó «saldo de prosa ≤ 0», y el ciclo 2 cerró en −46 palabras de prosa y +950 de evidencia y plantillas. Si este ciclo aplica las direcciones como vienen, cierra con saldo positivo de nuevo. Lo único que se quita en todo el panel es un `AssemblyMetadata` (senior-dotnet-03). Nadie paga la compresión que pidió el PO.
- **Contra-tesis [criterio]**: un lote de compresión con costo declarado, que compense las altas del ciclo sin tocar evidencia:
  1. **§3.5** queda como una línea por capa con remisión a §8.2.1, o §8.2.1 remite a §3.5 y conserva sólo la columna de evidencia: ≈ −150.
  2. **Las seis preguntas del contenedor** se reducen a dos (§3.7, como mapa, y §8.6 P1, como respuesta completa). §4.6 Q6 y §7.6 Q5 pasan a una oración con remisión: ≈ −120.
  3. **La tesis «Visual Studio no tiene devcontainer .NET»** se enuncia una vez (§8.2.4) y se remite en las otras 13: ≈ −150.
  4. **C3-01 en lugar de las cláusulas del panel**: una definición en §8.2.2 en vez de unas quince excepciones. Evita ≈ +300 y permite recortar las menciones de «digest» que dejan de ser regla.
  5. **Los «[no verificado] (requiere Windows)» repetidos** quedan como marca, sin la glosa, que ya está en §0.4 y en el Anexo F: ≈ −60.
- **Impacto**: la guía se entrega como obra terminada con 54 267 palabras. Las reglas que el lector tiene que llevarse están en §12, que tiene 1148, y se diluyen en repeticiones que la misma guía considera «sobra».
- **Dirección**: que el consolidado del ciclo 3 lleve la columna «Δ palabras» por parche (la pedí en el ciclo 2 y no se adoptó como columna). Que el lote incluya los cinco recortes de arriba como parches propios, medidos con `wc -w` antes y después.
- **Confianza**: 0,7. La clasificación es mía; los conteos son E1.

## Consensos sospechosos

| # | Consenso | Quiénes lo comparten | Por qué es sospechoso | Hallazgo |
|---|---|---|---|---|
| CS3-1 | «La contradicción digest/runner se arregla agregando la excepción donde falta» | requisitos-01, didáctica-02, arquitecto-software-01 y -02, AH-002-02, desarrollador-03 | Seis informes discuten dónde poner la cláusula y ninguno mide si la capa 4 cambia el artefacto. El E1 de C3-01 dice que no, para lo gestionado. | C3-01 |
| CS3-2 | «Faltaba esto: agregarlo» | Los once informes | ≈ 30 direcciones agregan y 1 quita, en el ciclo cuyo mandato es la compresión. Tercer ciclo seguido. | C3-05 |
| CS3-3 | «La compuerta se repara», cuarta vez | lector-sin-contexto-04 y -05, desarrollador-02, requisitos-05, arquitecto-software-03 y -05 | Prerrequisito `python3` que en Windows la documentación de Python no recomienda; dos `pre-commit` en carpetas vecinas; `verificar.sh` con tres sentidos; pre-commit que se niega a instalar con `core.hooksPath`. C1-08 está cerrado y no lo reabro, pero cada ciclo agrega texto alrededor de la misma pieza. | solicitud |
| CS3-4 | «Lo que la guía rotula "fabricante" lo es» | Nadie lo midió; AH-001 verificó Node y Python, senior-dotnet verificó mecanismos, no prácticas | En .NET, el rótulo «fabricante» cubre una elección propia (lock + `disable`) que 8 de 8 repos `dotnet/*` no siguen. | C3-03 |
| CS3-5 | «El SDK del caso es un dato del laboratorio» | Todo el panel; sólo senior-dotnet-01 roza el soporte | Nadie unió la fecha de fin de soporte (32 días) con el orden de §12. | C3-04 |
| CS3-6 | Omisión sin disposición: el digest de índice multiplataforma (CAT-FORMAL-01, dos ciclos) | Consolidado del ciclo 2 | Refuerza C3-01: aun con digest, cada arquitectura resuelve otra imagen. La «misma imagen» que la guía exige no es ni siquiera única. | (de CAT-FORMAL) |

## Revisado y bien: ataques que la guía resistió

1. **«¿UTF-8 sin BOM es una preferencia?» y la asimetría `.cs`/`.razor`.** Ataqué la excepción del `.razor` con BOM como incoherente con la variante A. No prospera en el fondo: `dotnet/aspnetcore` y `dotnet/aspire` declaran exactamente esa asimetría (`[*] charset = utf-8`, `[*.{razor,cshtml}] charset = utf-8-bom`). La guía coincide con el fabricante. Sólo la razón escrita estaba mal (C3-02).
2. **«¿Lock siempre?» en npm y uv.** Sigue alineado con el fabricante ([B93], [B99]). AH-001 re-verificó npm 12 y el registro sin contradicciones. No hay ataque que prospere fuera de .NET.
3. **«¿Contenedor siempre?» para desarrollar.** La guía no lo exige (§8.2.4, reglas 1–5; §12, «lo que no tiene, el devcontainer, no se le exige»). El ataque sólo prospera en la CI, y ahí por la capa 4 (C3-01), no por el devcontainer.

## Solicitudes de convocatoria

- **Especialista en estaciones Windows / Visual Studio** (cuarta solicitud; cola #1 desde el ciclo 1). Preguntas concretas:
  - (a) ¿Las plantillas de ítem de Visual Studio («Add > Class», «Add > Razor Component») crean con BOM, como las de la CLI (C3-02)?
  - (b) ¿Visual Studio respeta `global.json` con `paths: [".dotnet", "$host$"]` (C3-03)?
  - (c) ¿Git Bash encuentra `python3` con una instalación estándar de Python (lector-sin-contexto-04)?

  Si no hay host Windows, que el cierre lo declare como límite estructural de la mesa en el Anexo F.
- **Editor de cierre con presupuesto** (segunda solicitud): que controle el saldo de palabras del lote (C3-05) antes de la mesa de aprobación.
