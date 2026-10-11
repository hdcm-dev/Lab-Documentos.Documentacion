# Parches del ciclo 2 sobre la guía. Cada op:
#   ("R",  viejo, nuevo, cubo)          reemplazar una aparición única
#   ("RA", viejo, nuevo, cubo)          reemplazar todas las apariciones (n >= 1)
#   ("RG", desde, hasta, nuevo, cubo)   reemplazar el rango que empieza en `desde` (incluido)
#                                      y termina justo antes de `hasta` (ambos únicos)
# cubo: "prosa" (prosa propia) o "evid" (código, plantillas, salidas, filas de bibliografía, citas).
P = []
def parche(pid, titulo, hallazgos, seccion, capa, costo, reversible, verificacion, ops, nota=""):
    P.append(dict(id=pid, titulo=titulo, hallazgos=hallazgos, seccion=seccion, capa=capa,
                  costo=costo, reversible=reversible, verificacion=verificacion, ops=ops, nota=nota))

# ---------------------------------------------------------------------------------------------
parche("P-01", "Front matter, banda de versión e índice", ["C2-56", "C2-49", "C2-34", "C2-14", "C2-53"],
  "Front matter L5–L15; banda L26; índice L43, L48", "guía", "bajo", True,
  "`grep -c '^version: 1.0.0$'` → 1; `grep -c '^status: vigente'` → 1; `grep -c '217 fuentes'` → 1; "
  "slugs del índice = encabezados `##` (script de anclas del ciclo 1, `aplicacion/`): 20 = 20, 0 rotos.",
  [
   ("R", "version: 1.0.0-rc.1\nstatus: borrador", "version: 1.0.0\nstatus: vigente", "prosa"),
   ("R", 'fuentes_consultadas: "2026-10-07; B194–B204: 2026-10-09"', 'fuentes_consultadas: "2026-10-07; B194–B217: 2026-10-09"', "evid"),
   ("R", "> **Versión 1.0.0-rc.1.** Fecha: 2026-10-09", "> **Versión 1.0.0.** Fecha: 2026-10-09", "prosa"),
   ("R", "(204 fuentes, Anexo D), más 73 experimentos ejecutables (Anexo E).", "(217 fuentes, Anexo D), más 73 experimentos ejecutables (Anexo E).", "evid"),
   ("R", "Dockerfile, hook, CI, bots, `CODEOWNERS`, ADR; verificadas juntas.", "Dockerfile, hook, CI, bots, `CODEOWNERS`, ADR, registro del entorno y `.gitignore`; verificadas juntas.", "prosa"),
   ("RA", "#anexo-f-límites-y-lo-que-no-se-verificó", "#anexo-f-trazas-límites-y-lo-que-no-se-verificó", "evid"),
   ("R", "- **[Anexo F. Límites y lo que no se verificó](#anexo-f-trazas-límites-y-lo-que-no-se-verificó)**: hechos, interpretaciones y pendientes, separados.",
         "- **[Anexo F. Trazas, límites y lo que no se verificó](#anexo-f-trazas-límites-y-lo-que-no-se-verificó)**: qué pedido cubre cada sección; hechos, interpretaciones y pendientes, separados.", "prosa"),
  ])

# ---------------------------------------------------------------------------------------------
parche("P-02", "§0 Cómo usar esta guía", ["C2-32", "C2-33", "C2-51", "C2-49", "C2-40", "C2-27", "C2-24", "C2-10", "C2-37"],
  "§0.2 L65–L81; §0.3 L87–L97; §0.4 L109–L111", "guía", "bajo", True,
  "`grep -c 'únicas cinco'` → 0; `grep -c 'consultada el 2026-10-07\\.'` → 0; `grep -c 'MSYS_NO_PATHCONV=1'` → 1 en §0.4; "
  "`grep -c 'cli-plugins'` → 1; la tabla de la ruta mínima tiene 9 filas; el comando de §0.4 corrido tal cual da "
  "`buildx v0.35.0` (evidencia-auditor/x0-docker-config/salida.txt).",
  [
   ("R", "Al cierre de cada capítulo, su **Práctica**, sobre la ruta mínima de abajo |",
         "Al cierre de cada capítulo, su **Práctica**, sobre la ruta mínima de abajo o un experimento vecino |", "prosa"),
   ("R", "→ **Práctica** (dos consignas sobre experimentos que ya existen, con la respuesta esperada).",
         "→ **Práctica** (dos consignas sobre experimentos que ya existen, con la respuesta esperada o, en las de diseño, el criterio para evaluarla).", "prosa"),
   ("R", "| §11 | E8-1 | Qué se rompe primero en un repo con los tres ecosistemas |\n",
         "| §11 | E8-1 | Qué se rompe primero en un repo con los tres ecosistemas |\n| §12 | los de cada paso | La hoja de ruta, validación por validación (Práctica integradora) |\n", "prosa"),
   ("R", "Afirmación respaldada por la fuente B12 del [Anexo D](#anexo-d-bibliografía), consultada el 2026-10-07. |",
         "Afirmación respaldada por la fuente B12 del [Anexo D](#anexo-d-bibliografía), consultada en la fecha que indica su fila. |", "prosa"),
   ("R", "Resultado del experimento E4-2, ejecutado el 2026-10-07; la carpeta,",
         "Resultado del experimento E4-2, ejecutado en la fecha de su salida; la carpeta,", "prosa"),
   ("R", "Son las únicas cinco marcas, siempre en negrita.",
         "Son las únicas cuatro marcas de juicio, siempre en negrita; `[Bnn]`, IDs y rutas no la llevan.", "prosa"),
   ("R", "puede omitir líneas que no hacen al punto (se marca con `...`) pero nunca altera una línea mostrada.",
         "puede omitir líneas que no hacen al punto (se marca con `...`) o acortar una línea (con `…`), pero nunca altera lo que muestra.", "prosa"),
   ("R", "Si las credenciales de Docker Hub guardadas en la máquina están vencidas, `export DOCKER_CONFIG=$(mktemp -d)` permite descargar las imágenes en modo anónimo.",
         "Si las credenciales de Docker Hub guardadas en la máquina están vencidas, un `DOCKER_CONFIG` temporal descarga en modo anónimo, con los *plugins* enlazados para que `buildx` no cambie de versión (con uno vacío, el v0.35.0 del usuario cae al 0.13.1 del sistema **[observado]**, §8.5): `D=$(mktemp -d); ln -s ~/.docker/cli-plugins \"$D/\"; export DOCKER_CONFIG=$D`.", "prosa"),
   ("R", "Docker Desktop con contenedores Linux, corriendo los mismos `docker run` desde Git Bash o desde una terminal de WSL 2 con el clon en el sistema de archivos de WSL [B130][B132];",
         "Docker Desktop con contenedores Linux, corriendo los mismos `docker run` desde una terminal de WSL 2 con el clon en el sistema de archivos de WSL [B130][B132], o desde Git Bash con `MSYS_NO_PATHCONV=1` delante, porque convierte en ruta de Windows argumentos como `-w /w` [B209];", "prosa"),
  ])

# ---------------------------------------------------------------------------------------------
parche("P-03", "§1.2 Extracto literal de E1-01", ["C2-27"], "§1.2 L141–L158", "guía", "bajo", True,
  "Cada línea del bloque `text` de §1.2, salvo `...`, aparece tal cual en `Examples/N1-codificacion-y-finales-de-linea/salidas/e1-roslyn-sdk8.txt` "
  "(`grep -Fxf`); `grep -c '^\\$ docker run --rm -v' GUIA` → 0.",
  [
   ("RG", "```text\n$ docker run --rm -v \"$PWD\":/w -w /w mcr.microsoft.com/dotnet/sdk:8.0 sh e1-roslyn.sh\n",
          "*Extracto de E1-01",
          "```text\n== cp1252-lf | sólo literal\n  build OK\n  Texto  : Atenci�n: se�al recibida en �andubay\n...\n  U+     : FFFD 006E 003A\n...\n== cp1252-lf | con identificador no ASCII\n  Alarma.cs(4,23): error CS1056: Unexpected character '�' [/w/work/dotnet/cp1252-lf/App.csproj]\n...\n== utf8-lf | con identificador no ASCII\n  build OK\n  Texto  : Atención: señal recibida en Ñandubay\n...\n  U+     : 00F3 006E 003A\n...\n== cp1252-lf | el mismo programa con una consola no UTF-8 (LC_ALL=es_AR.ISO-8859-1): U+FFFD se ve como '?'\n  Texto  : Atenci?n: se?al recibida en ?andubay\n```\n\n", "evid"),
  ])

# ---------------------------------------------------------------------------------------------
parche("P-04", "§2.4 Matriz de actores y rótulo de ESC-01", ["C2-22", "C2-52"], "§2.4 L233, L247–L252; filas ESC-01 de §4.4–§11.4", "guía", "bajo", True,
  "`grep -c 'Windows + VS |'` → 0; `grep -c 'Windows+VS'` → 0; la celda «Aplica» de ACT-ARQ cita pasos que existen en §12.",
  [
   ("R", "| Capítulo | ESC-01 Windows+VS |", "| Capítulo | ESC-01 Windows + Visual Studio |", "prosa"),
   ("RA", "| ESC-01 Windows + VS |", "| ESC-01 Windows + Visual Studio |", "prosa"),
   ("R", "| ACT-ARQ | §3, §5, §6, §7, §11 | — | coherencia entre capítulos |\n| ACT-OPS | §8, §9, §10 | — | compuertas y procedencia |\n| ACT-REV | — | §10 (lista del revisor) | diffs de §5, §6, §7, §8 |\n",
         "| ACT-ARQ | §3, §5, §6, §7, §11 | §12, pasos 1–3, 5–7, 9 y 10 | coherencia entre capítulos |\n| ACT-OPS | §8, §9, §10 | — | compuertas y procedencia |\n| ACT-REV | — | §10 (lista del revisor) | diffs de §5, §6, §7, §8 |\n\nEn capítulos que lidera ACT-OPS, ACT-ARQ decide la estrategia de imagen (§8) y el alcance de SBOM y procedencia (§9); ACT-OPS la implementa (§11.4).\n", "prosa"),
  ])

# ---------------------------------------------------------------------------------------------
parche("P-05", "§3 Instrucción de lectura y §3.7", ["C2-37", "C2-38"], "§3 L258; §3.7 L419, L428", "guía", "bajo", True,
  "`grep -c 'En el Recorrido, leé ahora'` → 0; §3.7 P2 no contiene `NU1603` ni `requested`; 67 de 67 preguntas siguen con *Aplica*.",
  [
   ("R", " En el Recorrido, leé ahora §3.1, §3.2, §3.4 y §3.7; las tablas de §3.3, §3.5 y §3.6 usan mecanismos que se explican recién en §6 a §10 y son de consulta.", "", "prosa"),
   ("R", "No. Fijar es elegir una versión para una entrada; congelar es guardar el resultado completo de una resolución, transitivas incluidas. En NuGet conviven: CPM fija las directas en un lugar y `packages.lock.json` congela el grafo (E4-2: CPM pidió 8.0.2, que no existe, y NuGet resolvió 9.0.0; sin lock lo avisa con `NU1603`, y con lock el aviso desaparece y el lock registra `requested [8.0.2, )` con `resolved 9.0.0`, §7.2.1).",
         "No. Fijar es elegir una versión para una entrada; congelar es guardar el resultado completo de una resolución, transitivas incluidas. No se reemplazan: lo fijado puede no existir, y el lock registra lo que se resolvió en su lugar (§7.2.1).", "prosa"),
   ("R", "rango en el manifiesto y lock con modo estricto en la CI; para .NET sin lock, la política de §6.4.",
         "rango en el manifiesto y lock con modo estricto en la CI; para .NET, lo que se decide en §6.4.", "prosa"),
  ])

# ---------------------------------------------------------------------------------------------
parche("P-06", "§4 Codificación: snippet de Roslyn, `CS2016`, lecturas de §4.2.4 y Python 3.15", ["C2-49", "C2-58", "C2-31", "C2-29"],
  "§4.2.1 L459; §4.2.3 L492; §4.2.4 L506, L516; §4.3 L542", "guía + N1 (P-22)", "bajo", True,
  "`grep -c 'rama main al'` → 0; `grep -c 'Sólo Python falla siempre'` → 0; `grep -c 'prevista para el 2026-10-09'` → 0; "
  "`grep -c 'E1-03). En E1-03'` → 0; [B205] definida y citada.",
  [
   ("R", "// Roslyn, EncodedStringText.cs (rama main al 2026-10-07 [B14]), recortado y comentado.",
         "// Roslyn, EncodedStringText.cs (commit 9c298328ef91 [B14]), recortado y comentado.", "evid"),
   ("R", "Segunda trampa: con SDK 8.0.425 la build con `CodePage=1252` falla con `CS2016: Code page '1252' is invalid or not installed` según el estado del servidor de compilación, y con SDK 10.0.400 compila (E1-03). En E1-03 la falla aparece con el servidor de compilación (`VBCSCompiler`) recién arrancado, desaparece si el servidor ya compiló antes un archivo con *fallback*, y no aparece con `-p:UseSharedCompilation=false`, que compila sin servidor; el mismo",
         "Segunda trampa: con SDK 8.0.425, `CodePage=1252` falla con `CS2016: Code page '1252' is invalid or not installed` cuando el servidor de compilación (`VBCSCompiler`) recién arrancó, y no falla si ya compiló un archivo con *fallback* ni con `-p:UseSharedCompilation=false`, que compila sin servidor; con SDK 10.0.400 compila (E1-03). El mismo", "prosa"),
   ("R", "| Python `open()` sin `encoding=` | según *locale* | según *locale* |",
         "| Python `open()` sin `encoding=` | ≤ 3.14: según *locale*; ≥ 3.15: UTF-8 [B29] | ≤ 3.14: según *locale*; ≥ 3.15: se lee como UTF-8 [B29] |", "prosa"),
   ("R", "- **Sólo Python falla siempre ante cp1252.** Roslyn, Razor y Node fallan sólo si el carácter cae en un identificador (`CS1056`, `RZ1005`, `SyntaxError`); en literales y en HTML corrompen sin error (E1-01, E1-04, E1-05).",
         "- **Sólo Python rechaza el fuente en cp1252 en toda plataforma**, aun con el byte en un comentario [B33], salvo un cp1252 cuyos bytes forman UTF-8 válido, que se lee con otro texto. Roslyn, Razor y Node, en Linux y macOS, fallan sólo con el carácter en un identificador (`CS1056`, `RZ1005`, `SyntaxError`) y corrompen sin error literales y HTML (E1-01, E1-04, E1-05); en Windows con ACP 1252, Roslyn lo lee bien (§4.2.1).", "prosa"),
   ("R", "PEP 686 (*Final*) activa el modo UTF-8 por defecto desde Python 3.15 [B29], cuya versión final está prevista para el 2026-10-09 [B32]: al 2026-10-07 ninguna versión estable lo tiene activo.",
         "PEP 686 (*Final*) activa el modo UTF-8 por defecto desde Python 3.15 [B29], publicada el 2026-10-09 [B205] según el calendario de [B32]; en 3.14 y anteriores, como el 3.12 del laboratorio, `open()` sigue dependiendo del *locale*.", "prosa"),
  ])

# ---------------------------------------------------------------------------------------------
SENALES5_OLD = "Señales de una versión pobre: la política vive en una wiki o en `core.autocrlf`; `* text=auto` sin renormalizar; `*.{cmd,bat}` en `.gitattributes`; un hook genérico que quita todos los BOM; la conversión mezclada con cambios funcionales; un `.git-blame-ignore-revs` con un SHA que no está en `main`; política, migración e ignore-revs aplastados en un solo *squash*; comentarios al final de una línea del `.editorconfig`; el `.editorconfig` de `dotnet new` (SDK 8) commiteado sin revisar su `end_of_line = crlf`."
SENALES5_NEW = """Señales de una versión pobre:

- la política vive en una wiki o en `core.autocrlf` (§5.2.1);
- `* text=auto` sin renormalizar, o `*.{cmd,bat}` en `.gitattributes` (§5.2.4);
- un hook genérico que quita todos los BOM (§5.2.5);
- la conversión mezclada con cambios funcionales, un `.git-blame-ignore-revs` con un SHA que no está en `main`, o política, migración e ignore-revs en un solo *squash* (§5.2.6);
- comentarios al final de una línea del `.editorconfig` (§5.2.4);
- el `.editorconfig` de `dotnet new` (SDK 8) commiteado sin revisar su `end_of_line = crlf` (§5.3)."""
parche("P-07", "§5 Política de texto: variante B, compuerta de texto, scripts desde Windows, Práctica y señales", ["C2-12", "C2-05", "C2-08", "C2-50"],
  "§5.2.3 L715; §5.2.5 L742; §5.2.6 recuadro L810; §5.5 L862; §5.6 L890; §5.7 L923; §5.9 P2 L932", "guía + N2 (P-22)", "medio", True,
  "EA-1 paso 1c (nuevo, P-23 L3) da 0 violaciones con la variante B sobre la solución que crea el SDK convertida con BOM "
  "(evidencia-auditor/x5-variante-b/salida.txt: A tal cual 4; B ampliada 2 sin BOM en `Directory.Build.*`, 0 con BOM); "
  "`grep -c '^- ' ` en §5.7 tras «Señales» → 6; la respuesta de §5.9.2 coincide con el bloque B de A.1.",
  [
   ("R", "- **Heredado ya convertido a UTF-8 con BOM**, como el del caso: `utf-8-bom` para `*.cs` (variante B).",
         "- **Heredado ya convertido a UTF-8 con BOM**, como el del caso: `utf-8-bom` para `*.cs` y los archivos de proyecto (variante B).", "prosa"),
   ("R", "**[criterio]** La guía mantiene su verificador porque mira el **índice** —lo que se commitea— y da el diagnóstico «¿cp1252?». Necesita `python3` y el paquete `EditorConfig==0.17.1` en cada lugar donde corre (A.11). Un equipo que prefiera no mantener un script puede armar el paso de texto con editorconfig-checker sobre un clon limpio en la CI y `dotnet format whitespace --verify-no-changes` para los `.cs`, con la misma regla de una sola compuerta en hook y CI (§10.2.2).",
         "**[criterio]** La guía mantiene su verificador porque mira el **índice** —lo que se commitea— y da el diagnóstico «¿cp1252?». Necesita `python3` y el paquete `EditorConfig==0.17.1` donde corre, y la compuerta dice cuál falta (A.11). Sin Python, el paso de texto de la **misma** compuerta puede ser editorconfig-checker, fijado por versión, más `dotnet format whitespace --verify-no-changes` para los `.cs`, con los límites de la tabla; la regla de una sola compuerta en hook y CI no cambia (§10.2.2).", "prosa"),
   ("R", "Desde Windows: esa imagen con Docker Desktop montando el clon, o Git Bash con Python, el paquete y un `iconv` disponible **[no verificado]** (requiere Windows).",
         "Desde Windows: esa imagen con Docker Desktop montando el clon, o Git Bash con Python, el paquete y un `iconv` disponible **[no verificado]** (requiere Windows). Un `.sh` agregado desde Windows entra sin bit de ejecución: `git update-index --chmod=+x` antes del commit (§8.2.5).", "prosa"),
   ("R", "[*.{razor,cshtml,sln}]\ncharset = utf-8-bom\n```\n\n```gitattributes\n# .gitattributes — lo lee git;",
         "[*.{razor,cshtml,sln}]\ncharset = utf-8-bom\n\n# Heredado ya convertido con BOM, como el del caso: variante B de A.1,\n# [*.{cs,csproj,props,targets}] con charset = utf-8-bom.\n```\n\n```gitattributes\n# .gitattributes — lo lee git;", "evid"),
   ("R", "heredado ya convertido con BOM, como el del caso → `utf-8-bom` para `*.cs` y no tocar más.",
         "heredado ya convertido con BOM, como el del caso → `utf-8-bom` para `*.cs` y los archivos de proyecto, y no tocar más.", "prosa"),
   ("R", SENALES5_OLD, SENALES5_NEW, "prosa"),
   ("R", "Con la tabla de §5.2.3, escribí la política de un repo con `.sh`, `appsettings.json`, `.razor` y `.cs` heredados ya convertidos con BOM. Compará con A.1, variante B. *Respuesta esperada*: `[*]` sin BOM y LF; `.razor` y `.cs` con `utf-8-bom`;",
         "Con la tabla de §5.2.3, escribí la política de un repo con `.sh`, `appsettings.json`, `.razor`, `.cs` y `.csproj` heredados ya convertidos con BOM. Compará con A.1, variante B. *Respuesta esperada*: `[*]` sin BOM y LF; `.razor`, `.cs`, `.csproj`, `.props` y `.targets` con `utf-8-bom`;", "prosa"),
  ])

# ---------------------------------------------------------------------------------------------
SENALES6_OLD = "Señales de una versión pobre: `global.json` sin `rollForward` creyendo que fija la versión exacta; `\"version\": \"8.0\"`; `latestMajor` como «fijación»; confiar en que `engines` bloquea; `corepack enable` en una imagen de Node 26; `.nvmrc` que nada verifica; la CI que descarga «la última 3.x» de Python; subir el SDK con lock files activos y `rollForward` permisivo."
SENALES6_NEW = """Señales de una versión pobre:

- `global.json` sin `rollForward` creyendo que fija la versión exacta, `"version": "8.0"` o `latestMajor` como «fijación» (§6.2.2);
- confiar en que `engines` bloquea, o un `.nvmrc` que nada verifica (§6.2.3);
- `corepack enable` en una imagen de Node 26 (§6.2.3);
- la CI que descarga «la última 3.x» de Python (§6.2.4);
- subir el SDK con lock files activos y `rollForward` permisivo (§6.4)."""
parche("P-08", "§6 Toolchain: pnpm y Yarn, costo de `disable`, política por defecto, ESC-04, Práctica y señales", ["C2-30", "C2-41", "C2-57", "C2-01", "C2-04", "C2-23", "C2-50", "C2-51", "C2-32"],
  "§6.2.1 diagrama L968; §6.2.2 L990; §6.2.3 L1000; §6.4 L1037, L1044; §6.6 L1095, L1104; §6.7 L1125; §6.9 L1133–L1134", "guía + N3, N4 (P-22)", "medio", True,
  "`grep -c 'pnpm ≥ 11'` → 0; `grep -c 'desde la 11, lo hace cumplir'` → 0; [B206] y [B207] definidas y citadas; "
  "§6.2.2 cita `A compatible .NET SDK was not found` una sola vez y §6.6 P2 y A.3 remiten a §6.4 para el costo; la fila ESC-04 de §6.4 no contiene `digest`; "
  "la celda «Qué cuesta» cita [B56]. E1 de pnpm 10.18.0: `Informe-adhoc-AH-001.md` (AH-001-01).",
  [
   ("R", '        PM["packageManager"] -- "pnpm ≥ 11 (pmOnFail) · Yarn con Corepack" --> PMV["pnpm / yarn"]',
         '        PM["packageManager"] -- "pnpm (solo) · Yarn con Corepack o yarnPath" --> PMV["pnpm / yarn"]', "evid"),
   ("R", "Esa recomendación tiene un costo que conviene escribir: con `disable`, **toda** máquina —cada estación, la imagen del devcontainer y la de CI— necesita exactamente ese SDK, y `dotnet` falla con `A compatible .NET SDK was not found` en la que tenga otro parche (E3-1). §6.4 pone las dos políticas lado a lado.",
         "Esa recomendación tiene un costo —el SDK exacto en **toda** máquina—, que §6.4 pone al lado de la alternativa.", "prosa"),
   ("R", "pnpm, desde la 11, lo hace cumplir por sí mismo con el ajuste `pmOnFail` —por defecto `download`, que cambia a la versión declarada; con `error`, falla—, que gobierna también `devEngines.packageManager` [B196] (E3-3: pnpm 12.10.1 sin Corepack, con `pmOnFail=error`, `ERR_PNPM_BAD_PM_VERSION`). Yarn depende de Corepack o de instalarlo explícitamente [B81]. En la compuerta, pnpm con `pmOnFail=error`;",
         "pnpm lo hace cumplir por sí mismo [B81]: en la 10 descarga la versión declarada y, con `packageManagerStrictVersion=true`, falla [B206]; desde la 11 esos ajustes se unifican en `pmOnFail` —por defecto `download`; con `error`, falla—, que gobierna también `devEngines.packageManager` [B196] (E3-3: pnpm 12.10.1 sin Corepack, con `pmOnFail=error`, `ERR_PNPM_BAD_PM_VERSION`). Yarn depende de Corepack o de `yarnPath`, el binario versionado en el repo que deja `yarn set version --yarn-path` [B207]. En la compuerta, pnpm con `pmOnFail=error` (en la 10, `packageManagerStrictVersion=true`);", "prosa"),
   ("R", "| ESC-04 Devcontainer | La imagen trae el toolchain | Imagen por etiqueta que cambia de parche y hasta de banda (E3-7) | Imagen construida desde los archivos nativos y fijada por digest (§8) |",
         "| ESC-04 Devcontainer | La imagen trae el toolchain | Imagen por etiqueta que cambia de parche y hasta de banda (E3-7) | Etiqueta fija de SDK y SO verificada por `global.json`, o la receta de la imagen de CI (§8.2.2) |", "prosa"),
   ("R", "| **Con lock** (por defecto): `disable` + `packages.lock.json` en los ejecutables + `RestoreLockedMode` en CI |",
         "| **Con lock** (por defecto): `disable` + `packages.lock.json` en los ejecutables + `RestoreLockedMode` en CI + `NU1603` como error + la compuerta que compara `requested` con `resolved` |", "prosa"),
   ("R", "| Una estación con otro parche **no compila** (`A compatible .NET SDK was not found`, E3-1) hasta instalar el exacto; cada actualización de Visual Studio puede reemplazar su SDK [B59]; subir el SDK es un PR que mueve `global.json`, las imágenes y los locks (§10.2.6) | El SDK, el grafo completo y el `contentHash` |",
         "| Una estación con otro parche **no compila** (`A compatible .NET SDK was not found`, E3-1) hasta instalar el exacto; cada actualización de Visual Studio puede reemplazar su SDK [B59], y el SDK independiente ya no se actualiza con Visual Studio: su parche mensual es un PR del equipo [B56]; subir el SDK es un PR que mueve `global.json`, las imágenes y los locks (§10.2.6) | El SDK, el grafo completo y el `contentHash`; la aproximación de una versión inexistente, en la compuerta (§7.2.1) |", "prosa"),
   ("R", "*Criterio*: `disable` con lock files, aceptando su costo (el SDK exacto en cada estación); `latestPatch` sin lock files, con `NU1603` como error y la versión real registrada en la CI (§6.4).",
         "*Criterio*: §6.4.", "prosa"),
   ("R", "`packageManager` lo hace cumplir pnpm ≥ 11 por sí mismo (`pmOnFail`, [B196]); con Yarn, Corepack o una instalación explícita.",
         "`packageManager` lo hace cumplir pnpm por sí mismo (10: `packageManagerStrictVersion` [B206]; ≥ 11: `pmOnFail` [B196]); con Yarn, Corepack o `yarnPath` [B207].", "prosa"),
   ("R", SENALES6_OLD, SENALES6_NEW, "prosa"),
   ("R", "*Respuesta esperada*: la de `Examples/N3-fijacion-del-toolchain/README.md`, sección E3-1;",
         "*Respuesta esperada*: la de `Examples/N3-fijacion-del-toolchain/README.md`, sección «01 — `global.json` y `rollForward`» (E3-1);", "prosa"),
   ("R", "política elegida de la tabla de §6.4, costo aceptado y quién instala qué en cada estación.",
         "política elegida de la tabla de §6.4, costo aceptado y quién instala qué en cada estación. *Criterio de corrección*: nombra una fila de §6.4, dice qué se pierde con ella y quién instala el SDK exacto en cada estación Windows.", "prosa"),
  ])

# ---------------------------------------------------------------------------------------------
SENALES7_OLD = "Señales de una versión pobre: lock commiteado y CI con `dotnet restore`, `npm install` o `uv sync` a secas; `Version=\"X\"` leído como exacto; `requirements.txt` compilado en Linux usado en Windows; lock sin RID y CI que restaura con `-r`; SDK subido sin regenerar el lock; el lock de una biblioteca o de un proyecto común tratado como garantía para quien la referencia; .NET sin lock y con `NU1603` como simple advertencia; mapeo de fuentes con caché compartida como única defensa; un conflicto de lock «arreglado» a mano; `uv sync --frozen` en CI; `pip lock` como mecanismo estable."
SENALES7_NEW = """Señales de una versión pobre:

- lock commiteado y CI con `dotnet restore`, `npm install`, `uv sync` a secas o `uv sync --frozen` (§7.2);
- `Version="X"` leído como exacto (§7.1);
- `requirements.txt` compilado en Linux usado en Windows, o lock sin RID y CI que restaura con `-r` (§7.2.1, §7.2.3);
- SDK subido sin regenerar el lock (§6.2.2);
- el lock de una biblioteca o de un proyecto común tratado como garantía para quien la referencia, o una app `WinExe` sin lock (§7.2.1);
- `NU1603` como simple advertencia, o un lock sin la compuerta que compara `requested` con `resolved` (§7.2.1);
- mapeo de fuentes con caché compartida como única defensa (§7.2.1);
- un conflicto de lock «arreglado» a mano (§7.6);
- `pip lock` como mecanismo estable (§7.2.3)."""
parche("P-09", "§7 Dependencias: las dos defensas contra `NU1603`, `WinExe`, tabla de §7.3, `.nupkg` y señales", ["C2-01", "C2-02", "C2-03", "C2-37", "C2-42", "C2-46", "C2-47", "C2-50"],
  "§7.2.1 L1179, L1181; §7.2.2 L1189; §7.3 L1204–L1205; §7.4 L1224; §7.5 L1259; §7.6 L1266; §7.7 L1296; §7.9 L1304", "guía + N4 (P-22)", "medio", True,
  "EA-1 paso 8 (P-23 L3): con `Microsoft.Extensions.Primitives 8.0.2` el restore con lock no emite `NU1603` y la compuerta da "
  "`pide [8.0.2, ) y resolvió 9.0.0` y `resultado=ROJO`; paso 2c: el `WinExe` tiene `packages.lock.json` "
  "(evidencia-auditor/x2-compuerta-propuesta/salida.txt, secciones 4 y 5). `grep -c 'sólo cuando detectan CI'` → 0; "
  "`grep -c '\\*\\*\\[no verificado\\]\\*\\* |' ` en §7.3 → 0; [B215] definida y citada; conteo de `[B83]` en §7.2.1 sin cambio.",
  [
   ("R", "Con `NU1603` tratado como error, el restore sin lock se detiene y el restore con lock termina con 0: en este caso, activar el lock desarma esa defensa (E4-2). **[criterio]** Con lock, la compuerta compara `requested` con `resolved` en las entradas `Direct` y `CentralTransitive` del lock; sin lock, `NU1603` va en `WarningsAsErrors` (A.4).",
         "Con `NU1603` tratado como error, el restore sin lock se detiene y el restore con lock termina con 0: el lock desarma esa defensa (E4-2). **[criterio]** Por eso van las dos: `NU1603` como error en todo proyecto (A.4), que corta a los que no tienen lock, y una compuerta que compara la cota inferior de `requested` con `resolved` en las entradas `Direct` y `CentralTransitive` de los que lo tienen (A.11; EA-1: `pide [8.0.2, ) y resolvió 9.0.0`). También marca una subida legítima, que se resuelve subiendo la `PackageVersion`.", "prosa"),
   ("R", "Tres reglas del fabricante: el lock que gobierna es el del proyecto en la punta de la cadena, y el de una biblioteca que no se distribuye o de un proyecto de código común del que dependen otros «no debería» versionarse —conservarlo «no hace daño», pero no fija lo que resuelve quien lo referencia— [B83]; fijar el SDK porque aporta paquetes implícitos (§6, E3-6) [B83]; y saber que la poda de paquetes del SDK 10 (`PrunePackageReference`) cambia el grafo la próxima vez que se regenera [B83]. Además, **el conjunto de RID",
         "Tres reglas del fabricante:\n\n- el lock que gobierna es el del proyecto en la punta de la cadena; el de una biblioteca que no se distribuye o de un proyecto común del que dependen otros «no debería» versionarse —conservarlo «no hace daño», pero no fija lo que resuelve quien lo referencia— [B83];\n- el SDK se fija porque aporta paquetes implícitos (§6, E3-6) [B83];\n- la poda de paquetes del SDK 10 (`PrunePackageReference`) cambia el grafo la próxima vez que se regenera [B83].\n\n**Ejecutable quiere decir `Exe` o `WinExe`**, el tipo de las apps WinForms y WPF [B215]: una regla que mire sólo `Exe` las deja sin lock y con la CI en verde (A.4b, EA-1). Un proyecto de prueba no recibe lock por esa regla: su `OutputType=Exe` llega de un paquete que el restore no evalúa (SDK 8.0.425 **[observado]**).\n\n**El conjunto de RID", "prosa"),
   ("R", "activan el modo estricto **sólo cuando detectan CI** [B95][B96]", "activan el modo estricto **por defecto** cuando detectan CI [B95][B96]", "prosa"),
   ("R", "| Error de deriva | `NU1004` | `EUSAGE` | `ERR_PNPM_OUTDATED_LOCKFILE` | **[no verificado]** | «needs to be updated» | «changed significantly» | — |",
         "| Error de deriva | `NU1004` | `EUSAGE` | `ERR_PNPM_OUTDATED_LOCKFILE` | `YN0028` | «needs to be updated» | «changed significantly» | — |", "evid"),
   ("R", "| Error de integridad | `NU1403` | `EINTEGRITY` | **[no verificado]** | **[no verificado]** | **[no verificado]** | **[no verificado]** | «DO NOT MATCH THE HASHES» |",
         "| Error de integridad | `NU1403` | `EINTEGRITY` | `ERR_PNPM_TARBALL_INTEGRITY` | `YN0018` | «Hash mismatch» | «did not match any known checksums» | «DO NOT MATCH THE HASHES» |", "evid"),
   ("R", "El riesgo de confusión de dependencias está en el momento de bloquear o actualizar:",
         "Los cinco mensajes nuevos de esas dos filas son **[observado]** (Yarn 4.10.3, pnpm 10.18.0, uv 0.12.23, Poetry 2.5.1; Anexo F).\n\nEl riesgo de confusión de dependencias está en el momento de bloquear o actualizar:", "prosa"),
   ("R", "en CTX-NET la decisión es lock sí o no (§6.4) y, con lock, sólo en los ejecutables (A.4);",
         "en CTX-NET la decisión es lock sí o no (§6.4) y, con lock, sólo en los ejecutables, `Exe` y `WinExe` (A.4);", "prosa"),
   ("R", "Un mismo código empaquetado dos veces con SDK 8 o 10 da `.nupkg` con hash distinto (fechas y un nombre aleatorio dentro del zip); si un feed interno re-empaqueta «la misma versión», los locks de sus consumidores fallan con `NU1403` (E4-3, E6-2).",
         "Un mismo código empaquetado dos veces con SDK 8 da `.nupkg` con hash distinto (fechas y un nombre aleatorio dentro del zip, E6-2), y con SDK 10 también, según [B147]; si un feed interno re-empaqueta «la misma versión», los locks de sus consumidores fallan con `NU1403` (E4-3).", "prosa"),
   ("R", "detiene la aproximación de E4-2 que el lock deja pasar en silencio,", "detiene la aproximación de E4-2 que el lock por sí solo deja pasar en silencio,", "prosa"),
   ("R", SENALES7_OLD, SENALES7_NEW, "prosa"),
   ("R", "con lock, una compuerta que compare `requested` con `resolved` (§7.2.1).", "con lock, la compuerta de A.11, que compara `requested` con `resolved` (§7.2.1).", "prosa"),
  ])

# ---------------------------------------------------------------------------------------------
SENALES8_OLD = "Señales de una versión pobre: «con devcontainer ya no hace falta `.gitattributes`»; «usamos `sdk:8.0`, así que todos tenemos lo mismo»; digests sin actualización; *feature* de Node sin `version`; creer que el lock de devcontainer fija la imagen; Alpine «porque es más chica» con Node o Python nativos; imágenes de dev y CI elegidas por nombre; un digest en el devcontainer de un repo privado que ningún bot actualiza."
SENALES8_NEW = """Señales de una versión pobre:

- «con devcontainer ya no hace falta `.gitattributes`» (§8.2.1);
- «usamos `sdk:8.0`, así que todos tenemos lo mismo» (§8.2.2);
- digests sin actualización, o un digest en el devcontainer de un repo privado que ningún bot actualiza (§8.2.2);
- *feature* de Node sin `version`, o creer que el lock de devcontainer fija la imagen (§8.2.3);
- Alpine «porque es más chica» con Node o Python nativos (§8.3);
- imágenes de dev y CI elegidas por nombre (§8.2.6)."""
parche("P-10", "§8 Contenedores: CI sin imagen propia, quién mueve el digest, `safe.directory`, buildx y señales", ["C2-13", "C2-17", "C2-11", "C2-24", "C2-37", "C2-50"],
  "§8.2.2 puntos 1 y 3 L1372, L1374; §8.3 L1445; §8.5 L1475, L1480; §8.7 L1526", "guía + N5 (P-22)", "bajo", True,
  "§8.5 JSONC válido; el `postCreateCommand` de §8.5 y el de A.9 llevan `safe.directory`; `devcontainer up` con A.9 da "
  "`\"outcome\":\"success\"` y `core.hooksPath=.githooks` (evidencia-auditor/x4-devcontainer-safe-directory/salida.txt); "
  "[B213] y [B216] definidas y citadas.",
  [
   ("R", "Se escribe `repo:etiqueta@sha256:…`: la etiqueta queda como referencia humana y manda el digest.",
         "Se escribe `repo:etiqueta@sha256:…`: la etiqueta queda como referencia humana y manda el digest. Para 8a también vale el runner alojado con acciones de *setup* por SHA que leen `global.json`, `.nvmrc` y `.python-version` [B181]: la imagen del runner (capa 4) flota y queda en el log «Set up job» [B216]. La imagen propia hace falta para 8b, la reconstrucción bit a bit o la frontera A en la CI (§11.2.5).", "prosa"),
   ("R", "3. **Actualización como PR**, no como accidente: un bot o un trabajo programado propone el digest nuevo y el PR pasa por las mismas compuertas (§10).",
         "3. **Actualización como PR**, no como accidente: un bot o un trabajo programado propone el digest nuevo y el PR pasa por las mismas compuertas (§10). Ningún ecosistema de Dependabot cubre el `container:` de un workflow [B107]; Renovate lo reconoce [B213], pero que mueva su digest **[no verificado]**: lo mueve el PR que abre el workflow que publica la imagen **[criterio]**.", "prosa"),
   ("R", "| Transversal | Fijar imágenes por digest y actualizarlas por PR automatizado [B113]. Dependabot soporta `docker` y `devcontainers` para actualizaciones de versión (no de seguridad), y la tabla oficial marca `devcontainers` como **no soportado en repositorios privados** [B107]; Docker documenta que Dependabot actualiza etiqueta y digest de las imágenes base [B113]; la página de ecosistemas de GitHub no menciona digests [B107] y el laboratorio no lo observó **[no verificado]** (requiere la plataforma). Renovate documenta `pinDigests` [B108]. | fabricante |",
         "| Transversal | Fijar imágenes por digest y actualizarlas por PR automatizado [B113]. Dependabot: `docker` y `devcontainers`, sólo actualizaciones de versión, y `devcontainers` **no soportado en repositorios privados** [B107]; que mueva digests lo documenta Docker [B113] y no GitHub [B107] **[no verificado]** (§8.2.2). Renovate: `pinDigests` [B108]. | fabricante |", "prosa"),
   ("R", '  "postCreateCommand": "git config core.hooksPath .githooks && dotnet --version && node --version"\n}',
         '  // La imagen corre como root: sin safe.directory, git rechaza el repo montado (8.2.5).\n  "postCreateCommand": "git config --global --add safe.directory ${containerWorkspaceFolder} && git config core.hooksPath .githooks && dotnet --version && node --version"\n}', "evid"),
   ("R", "# ¿A qué digest apunta HOY una etiqueta? (sin bajar la imagen; E5-2)",
         "# ¿A qué digest apunta HOY una etiqueta? (sin bajar la imagen; E5-2, buildx v0.35.0; ver §0.4)", "evid"),
   ("R", SENALES8_OLD, SENALES8_NEW, "prosa"),
  ])

# ---------------------------------------------------------------------------------------------
P924_NEW = r"""#### 9.2.4 Procedencia SLSA y firma

**[criterio] Para el caso** (repositorio privado de una organización, equipo chico, artefactos internos), la tercera pregunta se contesta con el **registro del entorno** y el SBOM que la CI graba junto al artefacto (§3.4, §9.6, A.17). Lo que sigue es para el paso 8b de §12: un consumidor externo que verifique, un requisito contractual o un repositorio público.

La versión aprobada de SLSA es la **v1.2** [B05]; agrega un *Source Track* y su lista de cambios no enumera cambios al Build Track [B11]. Niveles del Build Track [B07]:

| Nivel | Exige | Protege contra |
|---|---|---|
| L1 | La plataforma genera automáticamente la procedencia (puede ser sin firma) | Errores de proceso; habilita inventario |
| L2 | L1 + plataforma **alojada** que **genera y firma** | Manipulación **después** de la build |
| L3 | L2 + aislamiento entre ejecuciones y secreto de firma inaccesible a los pasos del usuario | Manipulación **durante** la build |

Ningún nivel exige builds reproducibles; figuran como candidatas a un futuro L4 [B07][B08]. El `builder.id` es «el único determinante» del nivel, y el consumidor acepta sólo pares firmante/`builder.id` conocidos [B09].

**Una procedencia real (E6-5).** BuildKit la genera en formato in-toto [B160] con un builder `docker-container` o con el almacén de containerd, predeterminado en Docker Engine 29 [B162]; el driver `docker` sobre el almacén clásico la rechaza. Para el artefacto .NET construido `FROM` el SDK por digest: `predicateType=https://slsa.dev/provenance/v1`; `subject` con los sha256 de DLL y PDB; `resolvedDependencies` con **la imagen del SDK por digest**; el commit en `vcs:revision`; y `builder.id` **vacío**, que no alcanza L1. Se completa con el parámetro `builder-id=` de `--provenance` [B208], pero su valor lo escribe el paso que invoca la build: identifica a la plataforma sólo emparejado con el firmante. La DLL salió idéntica a la de otra build independiente: la verificación por reconstrucción, funcionando. El default de BuildKit pasó de SLSA v0.2 a v1 en la v0.28.0 [B161], aunque la página de Docker todavía dice v0.2 [B160]: **[criterio]** pedir `--provenance=mode=max,version=v1` explícitamente.

**La firma.** Sin firma, la procedencia es un JSON: E6-5 cambió `builder.id` y el archivo siguió siendo válido. Firmada con cosign (envoltorio DSSE [B163]): el original da `Verified OK`; con un byte más en el artefacto, `provided artifact digests do not match digests in statement`; con el predicado editado, `accepted signatures do not match threshold`. **[criterio]** Una clave guardada como secreto de la CI y usada por un paso del pipeline **no** es L2, que pide que firme la plataforma: a lo sumo, L1 firmado por un inquilino. Y `verify-blob-attestation` comprueba firma, `subject` y tipo de predicado, no su contenido (`builder.id`, repositorio, commit): eso es un paso aparte, con una política que fije lo esperado [B10].

| Plataforma | Mecanismo | Nivel | Restricción |
|---|---|---|---|
| GitHub Actions | `actions/attest@v4`, permisos `id-token: write` y `attestations: write`; `gh attestation verify` [B158] | L2 por sí sola; L3 con *reusable workflows* [B158] | En planes Free, Pro y Team, sólo repos **públicos**; privados o internos requieren Enterprise Cloud [B158] |
| GitLab CI/CD | `RUNNER_GENERATE_ARTIFACTS_METADATA=true`: in-toto con predicado SLSA [B159] | L2 con firma por componente; L3 con aislamiento del runner [B159] | La firma es un paso adicional |
| npm | `npm publish --provenance` [B148] | Sigstore + log público | Repo público, runners en la nube |
| PyPI | PEP 740 vía *Trusted Publishing* [B154] | in-toto + SLSA | Proveedores admitidos por PyPI |
| nuget.org | *Trusted Publishing* por OIDC [B165] | — | Su documentación no describe atestaciones de procedencia **[no verificado]** (como ausencia) |

Sin Enterprise Cloud, las atestaciones nativas de GitHub no están disponibles en un repo privado, y las de npm y PyPI no aplican a paquetes privados. Quedan tres caminos, con su nivel declarado sin inflarlo:

- **GitLab**: los metadatos del runner más un paso de firma [B159].
- **BuildKit + cosign con clave propia**, en un job aparte que no ejecuta código del PR, detrás de un entorno con aprobación: L1 firmado por un inquilino.
- **cosign sin clave**, con el token OIDC de la CI: un certificado efímero de Fulcio atado al workflow y el registro en el log público Rekor [B197]; para un repo privado, esa identidad queda publicada, salvo con una instancia propia de Sigstore. No se ejercitó en el laboratorio **[no verificado]**.

**Dónde se guarda.** SLSA pide publicar las atestaciones en al menos un lugar —junto al release, junto al artefacto en su registro de paquetes, y su hash en un log de transparencia— y que el consumidor verifique firma, `subject` y parámetros esperados [B10]. **[criterio]** Para un equipo chico: procedencia y SBOM junto al artefacto, con el mismo nombre base, donde se publica.

"""
SENALES9_OLD = "Señales de una versión pobre: `ContinuousIntegrationBuild` sin condición (rompe la depuración local); `PathMap` a mano; comparar hashes de `.nupkg` en SDK 8 o 10; el SHA embebido como prueba de origen; confundir SBOM con procedencia; llamar procedencia a un JSON sin firma; declarar L2 con una clave propia; declarar L1 con una procedencia sin `builder.id`; dar por verificado el predicado porque `verify-blob-attestation` pasó; contar con atestaciones de GitHub en un repo privado de un plan Team; `npm publish --provenance` en un paquete privado."
SENALES9_NEW = """Señales de una versión pobre:

- `ContinuousIntegrationBuild` sin condición, que rompe la depuración local, o `PathMap` a mano (§9.2.1);
- comparar hashes de `.nupkg` en SDK 8 o 10 (§9.2.1);
- el SHA embebido como prueba de origen (§9.2.1);
- confundir SBOM con procedencia (§9.2.3);
- llamar procedencia a un JSON sin firma, declarar L2 con una clave propia o L1 con una procedencia sin `builder.id` (§9.2.4);
- dar por verificado el predicado porque `verify-blob-attestation` pasó (§9.2.4);
- contar con atestaciones de GitHub en un repo privado de un plan Team, o `npm publish --provenance` en un paquete privado (§9.2.4)."""
parche("P-11", "§9 Procedencia: §9.2.4 comprimido para 8b, `builder-id`, `npm pack`, ESC-04, contextos, `GITHUB_ENV`, rótulo y Práctica", ["C2-15", "C2-16", "C2-45", "C2-23", "C2-54", "C2-26", "C2-39", "C2-14", "C2-32", "C2-50"],
  "§9.2.4 L1634–L1665; §9.3 L1672; §9.4 L1683, L1686; §9.5 L1702–L1716; §9.6 L1731; §9.7 L1761; §9.9.2 L1770", "guía + N6 (P-22)", "medio", True,
  "`awk '/^#### 9.2.4/,/^### 9.3/' | wc -w` → 604, de las que 5 son el encabezado de §9.3: ≤ 600 (antes 931); la tabla de plataformas pasa intacta a §9.3; conserva [B05] [B07] [B08] [B09] [B10] [B11] [B148] [B154] "
  "[B158] [B159] [B160] [B161] [B162] [B163] [B165] [B197] y agrega [B208]; `grep -c 'cómo completarlo en BuildKit no se verificó'` → 0; "
  "`grep -c '^export SOURCE_DATE_EPOCH'` → 1 (dentro de un script) y `GITHUB_ENV` en §9.5; `grep -oi ilustrativ` → 4 (antes 2); "
  "los enlaces a `#924-procedencia-slsa-y-firma` siguen resolviendo (el encabezado no cambia).",
  [
   ("RG", "#### 9.2.4 Procedencia SLSA y firma\n", "### 9.3 Qué propone la industria\n", P924_NEW, "prosa"),
   ("R", "| `npm pack`: sí, `mtime` fijo **[observado]** |", "| `npm pack`: sí con npm 11.19.0 (E6-3), `mtime` fijo **[observado]** |", "prosa"),
   ("R", "| ESC-04 Devcontainer | Con la misma imagen por digest que la CI, el lugar natural para reconstruir |",
         "| ESC-04 Devcontainer | Con la receta de la imagen de CI, el lugar natural para reconstruir |", "prosa"),
   ("R", "En CTX-POLI (los tres ecosistemas en un repo) aparecen tres SBOM distintos",
         "Por contexto: en CTX-NET, metadatos del SDK y `ContinuousIntegrationBuild` (§9.2.1); en CTX-NODE, `npm pack`, `npm sbom` y la procedencia de npm (§9.2.2); en CTX-PY, ruedas con `SOURCE_DATE_EPOCH` y PEP 770 (§9.2.2). En CTX-POLI (los tres ecosistemas en un repo) aparecen tres SBOM distintos", "prosa"),
   ("R", "```sh\n# Paso común al principio del job de CI, para los tres ecosistemas.\n# La fecha del COMMIT, no la de la build: dos builds del mismo commit incrustan la misma [B03].\nexport SOURCE_DATE_EPOCH=$(git log -1 --pretty=%ct)\n```",
         "```sh\n# Al principio del job de CI, para los tres ecosistemas: la fecha del COMMIT, no la de la build;\n# dos builds del mismo commit incrustan la misma [B03]. En GitHub Actions cada run: es un shell\n# propio: la variable llega a los pasos siguientes por el archivo GITHUB_ENV [B212].\necho \"SOURCE_DATE_EPOCH=$(git log -1 --pretty=%ct)\" >> \"$GITHUB_ENV\"\n# Dentro de un mismo script (build.sh), alcanza con export:\nexport SOURCE_DATE_EPOCH=$(git log -1 --pretty=%ct)\n```", "evid"),
   ("R", "# Consumidor:  gh attestation verify Pieza.1.4.0.nupkg -R <org>/<repo>\n```\n",
         "# Consumidor:  gh attestation verify Pieza.1.4.0.nupkg -R <org>/<repo>\n```\n\n**Ilustrativo**: no ejecutado (requiere GitHub con repo público o Enterprise Cloud); el SHA de `actions/attest` v4.2.2 se resolvió con `git ls-remote` el 2026-10-09.\n", "prosa"),
   ("R", "el 3, y el 4 si nadie lo trae, los agrega el registro del entorno.", "el 3, y el 4 si nadie lo trae, los agrega el registro del entorno (A.17).", "prosa"),
   ("R", SENALES9_OLD, SENALES9_NEW, "prosa"),
   ("R", "*Respuesta esperada*: trae el digest del artefacto, el commit y la imagen del SDK por digest; faltan la identidad de la plataforma (`builder.id` vacío) y el toolchain efectivo como dato propio.",
         "*Respuesta esperada*: trae (1) el digest del artefacto, (2) el commit, sin decir si el árbol estaba limpio, y (4) la imagen del SDK por digest; (5) aparece como SBOM de la imagen, con 2 paquetes, y hay que juzgar si ese alcance cubre el grafo; de (6) trae el cuándo (`startedOn`) y no el quién (`builder.id` vacío); falta (3), el toolchain efectivo como dato propio.", "prosa"),
  ])

# ---------------------------------------------------------------------------------------------
SENALES10_OLD = "Señales de una versión pobre: el hook como única defensa; lógica distinta en hook y CI; hooks genéricos de BOM sin cruzar con `.editorconfig`; `dotnet restore` o `npm install` en la CI; `global.json` subido sin mover la imagen; un lock que cambió sin su manifiesto aprobado sin preguntar; un diff de línea entera aceptado sin mirar si sólo cambió el BOM; documentar «la CI bloquea el merge» sin protección de rama; acciones por etiqueta móvil mientras se exige digest en la imagen; un bot sin agrupación ni enfriamiento decidido; ningún ADR que explique por qué `rollForward` es `disable`; la compuerta dice `n/a` para un archivo que existe en una subcarpeta; la compuerta informa «violación» cuando lo que falta es una herramienta; documentar que la rama protegida «impide» sin decir qué no impide."
SENALES10_NEW = """Señales de una versión pobre, por quién las ve:

- **En la compuerta**: el hook como única defensa (§10.2.3); lógica distinta en hook y CI (§10.2.2); hooks genéricos de BOM sin cruzar con `.editorconfig` (§10.2.3); `dotnet restore` o `npm install` en la CI (§10.2.4); `n/a` para un archivo que existe en una subcarpeta, o «violación» cuando falta una herramienta (§10.2.2).
- **En la revisión**: `global.json` subido sin mover la imagen (§10.2.6); un lock que cambió sin su manifiesto aprobado sin preguntar, o un diff de línea entera aceptado sin mirar si sólo cambió el BOM (§10.2.5).
- **En la plataforma y el gobierno**: documentar «la CI bloquea el merge» sin protección de rama, o que la rama protegida «impide» sin decir qué no impide (§10.2.7); acciones por etiqueta móvil mientras se exige digest en la imagen (§10.2.4); un bot sin agrupación ni enfriamiento decidido, o ningún ADR que explique por qué `rollForward` es `disable` (§10.2.6)."""
P1022_ALC_OLD_START = "**Alcance declarado.** La compuerta de `Examples/N7-compuertas-y-gobierno/compuerta/` busca cada archivo **en la raíz** del repo:"
P1022_ALC_NEW = "**Alcance declarado.** La compuerta de A.11 busca `global.json` y `.nvmrc` en la raíz, y los `.python-version` y los locks en todo lo versionado (`git ls-files`): sirve con los proyectos en la raíz (E7-1, E7-7) o en subcarpetas, como recomienda §11.2.3 (EA-1); un manifiesto sin lock queda para la revisión. «Compuerta única» es un solo programa por repositorio: `verificar.sh` (N8) es la de la solución de referencia, con sus rutas escritas, y no se copia. Y **una herramienta que falta no es una violación**: la compuerta dice «falta `python3`» o «falta el paquete EditorConfig», para que nadie apague el hook por un falso rojo.\n\n"
parche("P-12", "§10 Compuertas: compuerta propia con descubrimiento y `requested` = `resolved`, alcance de `--staged`, qué no impide, ESC-04, pre-commit, Práctica, mapa y señales", ["C2-05", "C2-06", "C2-07", "C2-03", "C2-09", "C2-19", "C2-20", "C2-44", "C2-23", "C2-25", "C2-54", "C2-37", "C2-32", "C2-38", "C2-50", "C2-35"],
  "§10.2 diagrama L1819; §10.2.2 L1845–L1849; §10.2.5 L1870; §10.2.7 L1904–L1910; §10.2.8 L1923; §10.4 L1938–L1944; §10.5 L1958; §10.7 L2025; §10.9 L2034", "guía + N7 (P-22) + laboratorio (P-23)", "alto", True,
  "EA-1 paso 8 (P-23 L3), en la imagen de A.10: plantillas → `resultado=VERDE` con `toolchain Python: 3.12.15 cumple tools/gen/.python-version` y `grafo npm: … web/package-lock.json`; "
  "`.cs` cp1252 en `src/App/` → `¿cp1252?` y ROJO; imagen sin el paquete → `falta el paquete EditorConfig`; regresión de N7 con la compuerta nueva: "
  "E7-01, E7-03 y E7-07 (Node y Python) con veredictos y códigos iguales a las salidas versionadas (evidencia-auditor/x3-regresion-n7/salida.txt). "
  "`grep -c 'mismo diseño'` → 0; `grep -c 'minimum_pre_commit_version'` → 1; el bloque de §10.5 corre con pre-commit 4.4.0 (E1 de `Informe-desarrollador.md`, desarrollador-04); "
  "[B214] definida y citada; la fila de GitHub de §10.2.7 ya no cita [B186].",
  [
   ("R", "    CI -->|registro de entorno| N6[\"§9 procedencia\"]", "    CI -->|registro del entorno| N6[\"§9 procedencia\"]", "evid"),
   ("R", "| grafo | los tres locks | `dotnet restore --locked-mode`, `npm ci`, `uv lock --check` | `NU1004`, `NU1403`, `EUSAGE`, «needs to be updated» |",
         "| grafo | los tres locks, donde estén | `dotnet restore --locked-mode` y `requested` = `resolved`, `npm ci`, `uv lock --check` | `NU1004`, `NU1403`, `pide [8.0.2, ) y resolvió 9.0.0`, `EUSAGE`, «needs to be updated» |", "evid"),
   ("R", "que sirve a la vez de registro de entorno para §9. Tres alcances: `--staged` (hook), `--base origin/main` (PR), sin argumentos (`main`, servidor, publicación).",
         "que sirve a la vez de registro del entorno para §9. Tres alcances: `--staged` (hook), `--base origin/main` (PR), sin argumentos (`main`, servidor, publicación). El alcance acota sólo el texto: toolchain y grafo miran el disco, y un lock modificado sin marcar pasa el hook y la CI lo rechaza (`NU1004`; git 2.39.5, SDK 8.0.425 **[observado]**).", "prosa"),
   ("RG", P1022_ALC_OLD_START, "#### 10.2.3 Hooks locales y frameworks de hooks", P1022_ALC_NEW, "prosa"),
   ("R", "| `Dockerfile`, `devcontainer.json` y su lock | ¿Sigue por digest? ¿El SDK de la imagen coincide con `global.json`? | §8 |",
         "| `Dockerfile`, `devcontainer.json` y su lock | ¿Lo que construye artefactos publicados sigue por digest? ¿El devcontainer usa etiqueta fija o la receta de la CI, y su SDK coincide con `global.json`? | §8.2.2 |", "prosa"),
   ("R", "a los administradores, salvo que se los incluya [B177] | [B177][B186][B200] |",
         "a los administradores, salvo que se los incluya [B177]; un estado con el mismo nombre publicado por otra fuente, si no se fijó la app esperada [B177] | [B177][B200] |", "prosa"),
   ("R", "| Un MR que edita `.gitlab-ci.yml` o la compuerta, si la aprobación de dueños no es obligatoria (Premium/Ultimate) | [B185][B199] |\n",
         "| Un MR que edita `.gitlab-ci.yml` o la compuerta, si la aprobación de dueños no es obligatoria (Premium/Ultimate) | [B185][B199] |\n| Validación de build obligatoria (Azure DevOps) | Completar el PR sin una build exitosa | A quien tiene permiso de *bypass* | [B186] |\n", "prosa"),
   ("R", "| Nada mientras el hook corra en el servidor; su tiempo está acotado en GHES (abajo) | E7-5, [B175] |",
         "| A quien puede deshabilitarlo: el administrador del servidor y, en GHES, los de organización o repositorio si se les delegó [B214]; su tiempo está acotado en GHES (abajo) | E7-5, [B175][B214] |", "prosa"),
   ("R", "lo empujó y los administradores están incluidos en la regla [B177].", "lo empujó, los administradores están incluidos en la regla y el chequeo exige como fuente la app de GitHub Actions [B177].", "prosa"),
   ("R", "(GitHub permite a los administradores saltear la protección salvo que se configure lo contrario [B177]) y cómo queda registrado su uso.",
         "(GitHub permite a los administradores saltear la protección salvo que se configure lo contrario [B177]; en GHES, quien puede deshabilitar un `pre-receive` [B214]) y cómo queda registrado su uso.", "prosa"),
   ("R", "| El hook de A.11 necesita en la estación `bash` (el de Git for Windows), `python3` con el paquete `EditorConfig==0.17.1` y los dos archivos de la compuerta en `tools/ci/`; para los pasos de toolchain y grafo, las herramientas que el repo declara. A mano, desde Git Bash en la raíz del clon: `bash tools/ci/compuerta.sh` **[no verificado]** (requiere Windows). La integración de git de Visual Studio con `core.hooksPath` **[no verificado]** (requiere Windows). Es donde el problema del caso no se ve: la CI en Linux lo revela. |",
         "| El hook necesita los prerrequisitos de A.11; a mano, desde Git Bash en la raíz: `bash tools/ci/compuerta.sh` **[no verificado]** (requiere Windows), igual que la integración de git de Visual Studio con `core.hooksPath`. El problema del caso no se ve acá: la CI en Linux lo revela. |", "prosa"),
   ("R", "| Con la misma imagen que la CI, el hook da el veredicto de la CI; `postCreateCommand` puede activar el hook **[criterio]**. |",
         "| Con la misma imagen que la CI, el hook da el veredicto de la CI sobre lo que está en disco (`--staged` acota sólo el texto, §10.2.2); `postCreateCommand` activa el hook (A.9) **[criterio]**. |", "prosa"),
   ("R", "| ESC-05 CI | Árbitro; registro de entorno para §9 |", "| ESC-05 CI | Árbitro; registro del entorno para §9 |", "prosa"),
   ("R", "En CTX-POLI (los tres ecosistemas en un repo) la compuerta corre sus tres pasos para los tres ecosistemas a la vez, sobre el inventario de proyectos de §10.2.2;",
         "Por contexto, la misma compuerta corre los pasos cuyos archivos existen y deja `n/a` los demás (E7-1, E7-7); en CTX-POLI (los tres ecosistemas en un repo) corre sus tres pasos para los tres a la vez, sobre los proyectos que encuentra (§10.2.2);", "prosa"),
   ("R", "# y packages.lock.json; .ps1, package-lock.json y uv.lock se agregan por la misma regla.\nrepos:",
         "# y packages.lock.json; .ps1, package-lock.json y uv.lock se agregan por la misma regla.\nminimum_pre_commit_version: \"4.4.0\"     # \"unsupported\" no existe en versiones viejas\nrepos:", "evid"),
   ("R", SENALES10_OLD, SENALES10_NEW, "prosa"),
   ("R", "2. Con la tabla de §10.2.7, escribí qué impide y qué no impide la configuración de tu plataforma y tu plan, y qué control compensatorio agregás donde no impide nada.\n",
         "2. Con la tabla de §10.2.7, escribí qué impide y qué no impide la configuración de tu plataforma y tu plan, y qué control compensatorio agregás donde no impide nada. *Criterio de corrección*: cada fila dice «impide» o «sólo avisa» en tu plan, qué no impide y su control compensatorio.\n\n**Volver al mapa.** Releé §3.3 desde «Qué deja libre», y §3.5: para cada fila, nombrá el experimento que lo mostró; si no podés, volvé a su capítulo.\n", "prosa"),
  ])

# ---------------------------------------------------------------------------------------------
SENALES11_OLD = "Señales de una versión pobre: «todo a UTF-8 con BOM»; creer que un `.sh` «anda» porque el paso terminó en verde; `.python-version` en la raíz con el proyecto uv en una subcarpeta; versiones en `mise.toml` además de los nativos; un target de MSBuild con `npm install`; el `.esproj` con sus defaults en CI; asumir que `global.json` fija Node y Python; comandos de bash en un `Exec`; bases por etiqueta; confundir el SBOM del artefacto con el de la build; locks marcados `linguist-generated`; una compuerta que dice `n/a` para los proyectos de las subcarpetas."
SENALES11_NEW = """Señales de una versión pobre:

- «todo a UTF-8 con BOM», o creer que un `.sh` «anda» porque el paso terminó en verde (§11.2.1);
- locks marcados `linguist-generated` (§11.2.2);
- `.python-version` en la raíz con el proyecto uv en una subcarpeta, o versiones en `mise.toml` además de los nativos (§11.2.3);
- un target de MSBuild con `npm install`, el `.esproj` con sus defaults en CI o comandos de bash en un `Exec` (§11.2.5);
- asumir que `global.json` fija Node y Python (§11.2.5);
- bases por etiqueta (§11.2.6);
- confundir el SBOM del artefacto con el de la build (§11.2.8);
- una compuerta que dice `n/a` para los proyectos de las subcarpetas (§10.2.2)."""
P115_VERIF_OLD = """**Compuerta: tres capas, tres ecosistemas** (extracto de `solucion/verificar.sh`):

```bash
echo "== 2. Toolchain: lo instalado contra los archivos NATIVOS del repo"
esperado_sdk=$(python3 -c 'import json;print(json.load(open("global.json"))["sdk"]["version"])')
esperado_node=$(tr -d '[:space:]' < .nvmrc)
esperado_py=$(tr -d '[:space:]' < tools/gen/.python-version)     # donde lo busca uv
# ... comparar con dotnet --version, node -v, uv python find; archivo sin herramienta = rojo
echo "== 3. Restauración estricta: un lock por ecosistema"
dotnet restore src/Saludo --locked-mode
(cd web && npm ci)
(cd tools/gen && uv sync --locked)
```"""
P115_VERIF_NEW = """**La compuerta propia de la solución de referencia: tres capas, tres ecosistemas, con sus rutas escritas** (extracto de `solucion/verificar.sh`; para otro repositorio, la compuerta de A.11, que encuentra los proyectos donde estén):

```bash
echo "== 2. Toolchain (N3): lo instalado contra los archivos del repo"
esperado_sdk=$(python3 -c 'import json;print(json.load(open("global.json"))["sdk"]["version"])')
esperado_node=$(tr -d '[:space:]' < .nvmrc)
esperado_py=$(tr -d "[:space:]" < tools/gen/.python-version)
...
echo "== 3. Restauración estricta (N4): un lock por ecosistema"
dotnet restore src/Saludo --locked-mode -v q --nologo || fallas=$((fallas+1))
(cd web && npm ci --no-audit --no-fund --loglevel=error) || fallas=$((fallas+1))
(cd tools/gen && uv sync --locked -q) || fallas=$((fallas+1))
```"""
P119_OLD = "1. Copiá la compuerta de N7 (con `check_text_policy.py`) dentro de la solución de N8, corrélas a las dos y explicá cada diferencia. *Respuesta esperada*: la de N7 declara `n/a` el Python, el lock de npm y el de uv, porque los busca en la raíz; `verificar.sh` los encuentra porque tiene las rutas (§10.2.2)."
P119_NEW = """1. Antes de mirar la columna B de E8-1 («UTF-8 con BOM para todo»), predecí qué lectores fallan. *Respuesta esperada*: cinco —el shebang de `saluda.py`, `json.load`, `tomllib`, `JSON.parse` y la comparación de `.nvmrc`—; `hola.sh` corre, con un error en stderr: el daño silencioso de §4.2.4.
2. Con EA-1, predecí qué paso de la compuerta de A.11 pone en rojo un `.cs` en cp1252 dentro de `src/App/` y qué dice. *Respuesta esperada*: sólo el de texto, con `no es UTF-8 válido (byte 0xc7 …; ¿cp1252?)`; toolchain y grafo siguen en verde, porque la compuerta encuentra los proyectos en sus subcarpetas (§10.2.2)."""
parche("P-13", "§11 Políglota: alcance de «registro», npm de E8-3, procedencia en tres partes, extracto literal de `verificar.sh`, `version=v1`, Práctica y señales", ["C2-35", "C2-43", "C2-52", "C2-21", "C2-48", "C2-06", "C2-27", "C2-28", "C2-14", "C2-32", "C2-50"],
  "§11 L2040; §11.2.4 L2115–L2117; §11.2.5 L2127, L2139; §11.2.8 L2183; §11.2.9 L2205, L2212; §11.3 L2232, L2246; §11.5 L2271, L2300–L2327; §11.6 L2343, L2346; §11.7 L2368; §11.8 L2372; §11.9", "guía + N8 (P-22) + laboratorio (P-23)", "medio", True,
  "`grep -c 'version=v1' ` en §11.5 → 1 y `grep -c 'Este comando no pide'` → 0; `e6-sbom-unificado/comando-de-la-guia.sh` con `,version=v1` da rc=0, `https://slsa.dev/provenance/v1`, "
  "`builder.id: ''` y cinco materiales por digest (evidencia-auditor/x5-version-v1/salida.txt); cada línea del extracto de `verificar.sh`, salvo `...`, está en el archivo (`grep -Fxf`); "
  "el comentario del `.csproj` de §11.5 es igual al de `solucion/src/Saludo/Saludo.csproj` tras P-23 L5; §11.9 tiene dos consignas; los dos diagramas renderizan (mermaid-cli); "
  "`grep -c 'piezas'` en §11 → 0; el ancla nueva de §11.2.4 no tiene enlaces entrantes que romper (`grep -c '#1124-'` → 0 antes del cambio).",
  [
   ("R", "Éste junta las piezas en un repositorio", "Éste junta las partes en un repositorio", "prosa"),
   ("R", "#### 11.2.4 Un lock y un registro por ecosistema", "#### 11.2.4 Un lock y un registro de paquetes por ecosistema", "prosa"),
   ("R", "Lo que se unifica es el procedimiento: los tres archivos de registros **en el repo**", "Lo que se unifica es el procedimiento: los tres archivos que declaran los registros de paquetes, **en el repo**", "prosa"),
   ("R", "(`EBADDEVENGINES` con npm 10.9.8 y 11.19, E8-3)", "(`EBADDEVENGINES` con npm 10.9.8 en E8-3, que corre el npm del `PATH` y no el del Node antepuesto; con npm 11.19, E3-3)", "prosa"),
   ("R", "| La CI publica el artefacto | B en la CI | Cada ecosistema corre una vez, con su comando estricto, entre la compuerta y el registro |",
         "| La CI publica el artefacto | B en la CI | Cada ecosistema corre una vez, con su comando estricto, entre la compuerta y el registro del entorno |", "prosa"),
   ("R", "hay entonces tres piezas distintas **[criterio]**", "hay entonces tres partes distintas **[criterio]**", "prosa"),
   ("R", '        NET["dotnet build -p:ConstruirPoliglota=false"]', '        NET["dotnet build<br/>(build.sh: -p:ConstruirPoliglota=false)"]', "evid"),
   ("R", '        PRV["procedencia firmada por la plataforma (commit)<br/>o de BuildKit (bases por digest, sin firma)"]',
         '        PRV["procedencia (§11.2.8): (a) la de la plataforma, firmada<br/>+ (b) materiales del entorno registrados<br/>+ (c) el vínculo firmado entre las dos"]', "evid"),
   ("R", "Las estrategias de §11.2 se apoyan en piezas documentadas de cada ecosistema", "Las estrategias de §11.2 se apoyan en mecanismos documentados de cada ecosistema", "prosa"),
   ("R", "| SBOM | Multi-ecosistema / nativos + unión / BuildKit | Uno de los dos primeros para los locks; BuildKit para procedencia | E8-6 |",
         "| SBOM y procedencia | Multi-ecosistema / nativos + unión / BuildKit | SBOM de los locks: uno de los dos primeros; procedencia: (a)+(b)+(c) de §11.2.8 con imagen única, y por componente, además, BuildKit `mode=max` como materiales | E8-6 |", "prosa"),
   ("R", "  <!-- true en la estación (F5); la CI pasa -p:ConstruirPoliglota=false y usa build.sh -->",
         "  <!-- true en la estación (F5) y en la prueba de regresión de la CI (§11.2.5); build.sh pasa false -->", "evid"),
   ("R", P115_VERIF_OLD, P115_VERIF_NEW, "evid"),
   ("R", "  --provenance=mode=max --sbom=true \\\n", "  --provenance=mode=max,version=v1 --sbom=true \\\n", "evid"),
   ("R", " Este comando no pide `version=v1`: el default de la versión de BuildKit usada ya es v1 (§9.2.4).", "", "prosa"),
   ("R", "Para el entorno, el registro del entorno de la CI y, si la build corre en contenedores, la procedencia de BuildKit,",
         "Para el entorno, el registro del entorno de la CI y, si la build corre por componentes con BuildKit, su procedencia,", "prosa"),
   ("R", "fuera de MSBuild para que la CI corra cada ecosistema una vez, en modo estricto, entre la compuerta y el registro.",
         "fuera de MSBuild para que la CI corra cada ecosistema una vez, en modo estricto, entre la compuerta y el registro del entorno.", "prosa"),
   ("R", SENALES11_OLD, SENALES11_NEW, "prosa"),
   ("R", "incluida la imagen multi-runtime de [A.10](#a10-dockerfile-de-la-imagen-multi-runtime), que EA-1 construye, y el devcontainer de A.9, que usa su receta.",
         "incluida la imagen multi-runtime de [A.10](#a10-dockerfile-de-la-imagen-multi-runtime), que EA-1 construye y donde corre la compuerta completa, el devcontainer de A.9, que usa su receta, y el registro del entorno de A.17. La CI de A.12 corre la compuerta, compila y registra el entorno; el SBOM y la publicación los agrega cada equipo (§9.2.3).", "prosa"),
   ("R", P119_OLD, P119_NEW, "prosa"),
  ])

# ---------------------------------------------------------------------------------------------
P12_INTEG = """
**Práctica integradora.** Sin experimentos nuevos.

1. Para cada validación del contrato, nombrá el experimento que la mostró y predecí el mensaje antes de mirar su salida. *Respuesta esperada*: paso 3 → E2-2 (`0 con cambio de contenido`); paso 4 → E2-3 (`¿cp1252?`); paso 5 → E3-1 (`A compatible .NET SDK was not found`); paso 6 → E4-1 y E4-4 (`NU1004`, `EUSAGE`); paso 7 → E7-4 (la compuerta en rojo en la imagen vieja).
2. El equipo quiere empezar por el devcontainer (paso 7) antes de fijar el toolchain (paso 5). ¿Qué deja sin detectar? *Respuesta esperada*: con una imagen por etiqueta y sin `global.json`, el SDK cambia sin que el repo se entere (E5-6, §3.5), y la capa 1 sigue rota adentro (E5-1).
"""
parche("P-14", "§12 Hoja de ruta: paso 7 con dos caminos para la CI, registro del entorno, contrato completo y Práctica integradora", ["C2-13", "C2-14", "C2-55", "C2-33"],
  "§12 tabla L2392–L2393; bloque YAML L2400–L2418; cierre", "guía", "bajo", True,
  "El YAML de §12 es válido (PyYAML 6.0.3) y `validaciones` tiene una línea por paso 1–10 (11 líneas, con 8a y 8b); "
  "la ruta mínima de §0.2 remite a la «Práctica integradora», que existe; las salidas citadas en la Práctica están en "
  "`e2-migracion.txt`, `e3-compuerta.txt`, `E3-1.txt`, `e1-nuget-lock.txt`, `e4-npm-lock.txt`, `E7-04-*.txt`, `E5-6-*.txt`, `E5-1-*.txt`.",
  [
   ("R", "| 7 | Construir la imagen de CI **desde** los archivos de los pasos 5–6, con sus bases por digest y un bot que proponga los digests nuevos por PR; el devcontainer, si se ofrece, con la misma receta o con etiqueta fija de SDK y SO verificada por `global.json`. | ACT-OPS | La compuerta pasa en la imagen y falla si se desalinea | §8 |",
         "| 7 | Elegir dónde corre la CI: una imagen propia construida **desde** los archivos de los pasos 5–6, con bases por digest que mueve un PR (necesaria para 8b, la reconstrucción bit a bit o la frontera A en la CI), o el runner alojado con acciones de *setup* fijadas por SHA que leen esos archivos (suficiente para 8a; la capa 4 flota y se registra). El devcontainer, si se ofrece, con la misma receta o con etiqueta fija de SDK y SO verificada por `global.json`. | ACT-ARQ, ACT-OPS | La compuerta pasa en la CI y falla si se desalinea | §8.2.2, A.12 |", "prosa"),
   ("R", "registro del entorno (SDK, compilador y runtimes efectivos, digest de la imagen, commit y árbol limpio) y SBOM con alcance declarado. |",
         "registro del entorno (SDK, compilador y runtimes efectivos, digest de la imagen, commit y árbol limpio; A.17) y SBOM con alcance declarado. |", "prosa"),
   ("R", '  - "imagen de CI con bases por digest y configuración del bot (paso 7)"\n  - "registro del entorno y SBOM junto al artefacto (8a); procedencia si corresponde (8b)"\n',
         '  - "imagen de CI con bases por digest, o runner alojado con acciones por SHA (paso 7)"\n  - "registro del entorno y SBOM junto al artefacto (8a); procedencia si corresponde (8b)"\n  - "CODEOWNERS, configuración de los bots y ADR de descongelamiento (paso 9)"\n  - "tabla por extensión revisada con los lectores de los tres ecosistemas (paso 10)"\n', "evid"),
   ("R", 'validaciones:\n  - "paso 3: tools/verificar-commit-mecanico.sh <sha> CP1252 -> 0 con cambio de contenido"\n',
         'validaciones:\n  - "paso 1: e1-diagnostico.sh -> codificación, BOM y CR de cada archivo"\n  - "paso 2: editorconfig y git check-attr resuelven lo decidido por extensión (EA-1, paso 1)"\n  - "paso 3: tools/verificar-commit-mecanico.sh <sha> CP1252 -> 0 con cambio de contenido"\n', "evid"),
   ("R", '  - "paso 7: imagen desalineada con los archivos nativos -> compuerta en rojo"\n```\n',
         '  - "paso 7: imagen desalineada con los archivos nativos -> compuerta en rojo"\n  - "paso 8a: registro del entorno sin campos vacíos junto al artefacto (A.17)"\n  - "paso 8b: la procedencia verifica con su par firmante/builder.id"\n  - "paso 9: un PR que toca la compuerta pide la aprobación de su dueño (CODEOWNERS)"\n  - "paso 10: los quince lectores de E8-1 pasan con la política por extensión (columna A)"\n```\n' + P12_INTEG, "evid"),
  ],
  nota="El último op agrega la «Práctica integradora» (prosa) junto con el YAML (contrato); su Δ se imputa a prosa en el balance (§2).")

# ---------------------------------------------------------------------------------------------
A11_QUE_OLD = "**Qué se copia y adónde.** A `tools/ci/`: `compuerta.sh` de `Examples/N7-compuertas-y-gobierno/compuerta/` y `check_text_policy.py` de `Examples/N2-politica-de-texto-y-remediacion/tools/`; o, si los proyectos viven en subcarpetas, `verificar.sh` de N8 con su inventario de rutas (§10.2.2). A `.githooks/`: el hook de arriba. Activación, una vez por clon: `git config core.hooksPath .githooks` [B37]."
A11_QUE_NEW = "**Qué se copia y adónde.** A `tools/ci/`: `compuerta.sh` de `Examples/N7-compuertas-y-gobierno/compuerta/`, que encuentra los proyectos en la raíz o en subcarpetas, y `check_text_policy.py` de `Examples/N2-politica-de-texto-y-remediacion/tools/`. A `.githooks/`: el hook de arriba. Creados desde Windows, entran sin bit de ejecución y git ignora un hook sin él (§8.2.5): antes del commit, `git update-index --chmod=+x tools/ci/compuerta.sh .githooks/pre-commit`. Activación, una vez por clon: `git config core.hooksPath .githooks` [B37]."
A12_OLD_START = "Preguntas: ¿la imagen del job sale de la misma receta que el devcontainer (A.10), publicada y nombrada por digest?"
A12_NEW = r"""Preguntas: ¿la imagen del job sale de la misma receta que el devcontainer (A.10), publicada y nombrada por digest, o alcanza el runner alojado (§8.2.2)? ¿La imagen es privada y el job tiene con qué descargarla? ¿Quién mueve el digest del `container:`? ¿La revisión de dueños es obligatoria sobre `.github/` y `tools/ci/` (§10.2.7)? ¿Cada acción está fijada por SHA? ¿El PR tiene la historia que necesita `--base`? ¿`SOURCE_DATE_EPOCH` llega a los pasos que construyen?

```yaml
# Anexo A.12. Ejemplo NO ejecutado en el laboratorio (requiere GitHub).
name: compuerta
on:
  pull_request:
  push:
    branches: [main]
permissions:
  contents: read
  packages: read          # descargar la imagen privada de GHCR (nace privada)
jobs:
  compuerta:
    runs-on: ubuntu-24.04
    # Imagen construida desde imagen/Dockerfile (A.10), la misma receta que el devcontainer (A.9),
    # publicada en el registro de imágenes del equipo. El digest se declara sólo acá: lo lee
    # registrar-entorno.sh (A.17) y lo mueve el PR que abre el workflow que publica la imagen.
    container:
      image: ghcr.io/org/imagen-ci@sha256:0000000000000000000000000000000000000000000000000000000000000000
      credentials:
        username: ${{ github.actor }}
        password: ${{ secrets.GITHUB_TOKEN }}
    steps:
      # Acción fijada por SHA completo; la etiqueta va como comentario.
      - uses: actions/checkout@3d3c42e5aac5ba805825da76410c181273ba90b1 # v7.0.1
        with:
          fetch-depth: 0
      # Cada run: es un shell propio: la variable llega a los pasos siguientes por GITHUB_ENV.
      - run: echo "SOURCE_DATE_EPOCH=$(git log -1 --pretty=%ct)" >> "$GITHUB_ENV"
      # bash explícito: no depende del bit de ejecución registrado en git.
      - run: bash tools/ci/compuerta.sh --base "origin/${{ github.base_ref }}"
        if: github.event_name == 'pull_request'
      - run: bash tools/ci/compuerta.sh
        if: github.event_name == 'push'
      # 8a: construir, registrar el entorno y, aparte, el SBOM con alcance declarado (9.2.3).
      - run: dotnet build src/App -c Release -o out
      - run: bash tools/ci/registrar-entorno.sh out/App.dll > out/registro-entorno.txt
```

**Ilustrativo**: validado como YAML en EA-1, no ejecutado en GitHub; los `run:` corren en EA-1 dentro de la imagen de A.10 (paso 9). El SHA de `actions/checkout` v7.0.1 se resolvió con `git ls-remote` el 2026-10-07 [B193]. En GHCR un paquete nuevo nace privado [B210] y los permisos no declarados quedan en `none` [B211]: de ahí `packages: read` y `credentials` [B135]; `GITHUB_ENV` [B212]. Ningún ecosistema de Dependabot mueve el digest del `container:` [B107]: lo mueve el PR que abre el workflow que publica la imagen **[criterio]**. Fuentes: [B135], [B183].

Variante sin imagen propia, suficiente para 8a (§8.2.2): reemplaza `container:` y los pasos hasta `SOURCE_DATE_EPOCH`; la capa 4 es la imagen del runner, que queda en el log «Set up job» [B216].

```yaml
    steps:
      - uses: actions/checkout@3d3c42e5aac5ba805825da76410c181273ba90b1 # v7.0.1
        with: { fetch-depth: 0 }
      - uses: actions/setup-dotnet@a98b56852c35b8e3190ac28c8c2271da59106c68 # v6.0.0
        with: { global-json-file: global.json }
      - uses: actions/setup-node@949feb2413d6458794dcd2491c4babbbce0c15c1 # v7.1.0
        with: { node-version-file: .nvmrc }
      - uses: actions/setup-python@5fda3b95a4ea91299a34e894583c3862153e4b97 # v7.0.0
        with: { python-version-file: tools/gen/.python-version }
      - uses: astral-sh/setup-uv@c18668ad3cf93ea998bef934396af7bb5c839dc7 # v10.2.0
        with: { working-directory: tools/gen }
      - run: python -m pip install EditorConfig==0.17.1
```

**Ilustrativo** **[no verificado]** (requiere GitHub): entradas de [B181] y [B217]; SHA resueltos con `git ls-remote` el 2026-10-09 [B217].

"""
A17_A18 = r"""### A.17 Registro del entorno

Preguntas: ¿qué no declara el repo y hay que grabar en la build (§3.7)? ¿De dónde sale el digest de la imagen? ¿Qué artefactos se registran?

```sh
#!/bin/sh
# Anexo A.17. Registro del entorno (guía 9.6; 12, paso 8a). Lo corre la CI después de construir,
# en la misma imagen: tools/ci/registrar-entorno.sh <artefacto>... > registro-entorno.txt
# Sin firma: sirve para diagnosticar y reconstruir, no prueba nada ante un tercero (9.2.4).
set -eu
echo "commit=$(git rev-parse HEAD) arbol_limpio=$(git diff --quiet HEAD && echo si || echo NO)"
# El digest se declara UNA vez, en el container: del workflow (A.12); el registro lo lee de ahí.
img=$(sed -n 's/^ *\(container\|image\): *\([^ ]*@sha256:[0-9a-f]\{64\}\).*/\2/p' .github/workflows/ci.yml | head -1)
echo "imagen=${img:-NO DECLARADA (runner sin contenedor: capa 4 en el log «Set up job»)}"
sdk=$(dotnet --version); raiz=$(dirname "$(readlink -f "$(command -v dotnet)")")
echo "dotnet_sdk=$sdk compilador_csharp=$(dotnet exec "$raiz/sdk/$sdk/Roslyn/bincore/csc.dll" -version)"
echo "node=$(node --version) npm=$(npm --version)"
echo "python=$(python3 -c 'import platform;print(platform.python_version())') uv=$(uv --version | cut -d' ' -f2)"
git ls-files '*packages.lock.json' '*package-lock.json' '*uv.lock' | while read -r f; do
  echo "sha256 $f=$(sha256sum "$f" | cut -d' ' -f1)"; done
for a in "$@"; do echo "sha256 $a=$(sha256sum "$a" | cut -d' ' -f1)"; done
```

Salida en EA-1 (paso 9: plantillas con sus locks, en la imagen de A.10; el digest es el de relleno de A.12):

```text
commit=3423028948a3e85b6256be72f3d2acf8fd26696b arbol_limpio=si
imagen=ghcr.io/org/imagen-ci@sha256:0000000000000000000000000000000000000000000000000000000000000000
dotnet_sdk=8.0.425 compilador_csharp=4.11.0-3.25569.22 (3fb752d4)
node=v24.21.0 npm=11.19.0
python=3.12.15 uv=0.12.23
sha256 src/App/packages.lock.json=696d9560…
sha256 tools/gen/uv.lock=bcf2758b…
sha256 web/package-lock.json=72ab32c8…
sha256 out/App.dll=68421c45…
```

El compilador sale de `csc -version`, el mismo dato que da `#error version` (`CS8304`, §9.6). Sin `container:`, la línea `imagen` lo dice y la capa 4 queda en el log del runner [B216]. Fuentes: [B02], §9.6.

### A.18 `.gitignore`

Preguntas: ¿qué genera cada ecosistema dentro del árbol? ¿Qué salidas no tiene que revisar la compuerta?

```gitignore
# Anexo A.18. Lo generado no se versiona: la compuerta y los revisores miran lo versionado.
bin/
obj/
node_modules/
dist/
.venv/
__pycache__/
```

Sin él, `git add -A` versiona `obj/`, y la compuerta y los revisores cargan con archivos generados (EA-1). `dotnet new gitignore` genera uno más completo para .NET.

"""
parche("P-15", "Anexo A: plantillas copiables (A.1, A.3, A.4, A.4b, A.9, A.10, A.11, A.12) y dos nuevas (A.17, A.18)", ["C2-12", "C2-04", "C2-57", "C2-01", "C2-02", "C2-11", "C2-07", "C2-05", "C2-06", "C2-08", "C2-13", "C2-14", "C2-17", "C2-18", "C2-26", "C2-53"],
  "Anexo A L2424, L2456–L2460, L2510, L2529–L2531, L2552–L2562, L2675–L2682, L2723–L2732, L2747–L2757, L2759–L2789; A.17 y A.18 nuevas tras A.16", "guía + laboratorio (P-23 L2, L3)", "alto", True,
  "`aplicacion/anexoA.py` (ciclo 1) ampliado a A.17 y A.18: 22 de 22 bloques que son archivos, iguales byte a byte a `Examples/A-plantillas/repo/` (no lo son la salida de A.17 ni la variante de A.12; ya comprobado para los nueve bloques tocados contra `evidencia-auditor/x7-ea1-propuesto/repo/`); EA-1 rc=0 con los pasos 1c, 2c, 8, 9 y 10 "
  "(salida esperada: evidencia-auditor/x7-ea1-propuesto/salida.txt); el bloque `text` de A.17 se reemplaza por las líneas del paso 9 de EA-1, "
  "con `…` en los hashes (regla de §0.3); [B210] [B211] [B212] [B216] [B217] definidas y citadas; `grep -c 'verificar.sh de N8'` → 0.",
  [
   ("R", "condición de CI de `Directory.Build.props`, lock sólo en los ejecutables, la imagen de A.10 construida con la plantilla `web/` corriendo adentro, `devEngines`, uv, y sintaxis de JSONC, YAML y del esquema de `dependabot.yml`.",
         "condición de CI de `Directory.Build.props`, lock sólo en los ejecutables (también `WinExe`), la variante B de A.1, la imagen de A.10 construida con la plantilla `web/` y la compuerta completa corriendo adentro, el registro del entorno, `devEngines`, uv, el devcontainer levantado con la CLI, y sintaxis de JSONC, YAML y del esquema de `dependabot.yml`.", "prosa"),
   ("R", "# Variante B (heredado YA convertido a UTF-8 con BOM, o elegida antes de migrar):\n# descomentar. Con la variante A, lo que crea dotnet new console (Program.cs y el\n# .csproj, con BOM) se normaliza antes del primer commit.\n# [*.cs]\n# charset = utf-8-bom",
         "# Variante B (heredado YA convertido a UTF-8 con BOM, como el del caso, o elegida\n# antes de migrar): descomentar. Cubre los archivos de proyecto, que siguen la\n# convención de *.cs (5.2.3); los Directory.Build.* de este anexo se guardan\n# entonces con BOM. Con la variante A, lo que crea dotnet new console (Program.cs\n# y el .csproj, con BOM) se normaliza antes del primer commit.\n# [*.{cs,csproj,props,targets}]\n# charset = utf-8-bom", "evid"),
   ("R", "EA-1 paso 1b: un `dotnet new console` dentro del repo deja dos violaciones con la variante A (`Program.cs` y el `.csproj` con BOM) y ninguna después de normalizarlos.",
         "EA-1 paso 1b: un `dotnet new console` dentro del repo deja dos violaciones con la variante A (`Program.cs` y el `.csproj` con BOM) y ninguna después de normalizarlos. Paso 1c: con la variante B, la solución que crea el SDK, convertida con BOM, no deja ninguna una vez guardados con BOM los `Directory.Build.*`.", "prosa"),
   ("R", "Variante tolerante, sin lock files: `\"version\": \"8.0.400\", \"rollForward\": \"latestPatch\"` (el parche más alto de la banda 4xx). Costo de `disable`: toda estación, la imagen del devcontainer y la de CI necesitan exactamente 8.0.425, y la que tenga otro parche no compila (§6.4).",
         "8.0.425 es el SDK del caso; .NET 8 sale de soporte el 2026-11-10 [B61][B62]: un repo nuevo parte de la última 10.0.4xx. Variante tolerante, sin lock files: `\"version\": \"8.0.400\", \"rollForward\": \"latestPatch\"` (el parche más alto de la banda 4xx). Costo de `disable`: §6.4.", "prosa"),
   ("R", "    <!-- Política SIN lock (guía, 6.4): descomentar. Una versión inexistente que NuGet\n         aproxima corta el restore. Con lock, el lock desarma este aviso (E4-2). -->\n    <!-- <WarningsAsErrors>$(WarningsAsErrors);NU1603</WarningsAsErrors> -->",
         "    <!-- NU1603 como error en las dos políticas de la guía (6.4): corta el restore de un\n         proyecto sin lock cuando NuGet aproxima una versión que no existe. Con lock no se\n         dispara (E4-2): esa aproximación la detecta la compuerta (requested = resolved). -->\n    <WarningsAsErrors>$(WarningsAsErrors);NU1603</WarningsAsErrors>", "evid"),
   ("R", "       OutputType todavía no está definido y la condición no se cumple nunca. -->\n  <PropertyGroup Condition=\"'$(OutputType)' == 'Exe'\">",
         "       OutputType todavía no está definido y la condición no se cumple nunca.\n       WinExe: WinForms y WPF (el SDK cambia Exe por WinExe en esas aplicaciones).\n       Un proyecto de prueba no recibe lock por esta regla: su OutputType=Exe llega desde\n       un paquete que el restore no evalúa; si se lo quiere congelar, se declara\n       RestorePackagesWithLockFile en su .csproj. -->\n  <PropertyGroup Condition=\"'$(OutputType)' == 'Exe' Or '$(OutputType)' == 'WinExe'\">", "evid"),
   ("R", "EA-1 paso 2b: con `Directory.Build.targets`, `packages.lock.json` aparece en el ejecutable y no en la biblioteca, y en modo CI el restore pasa y falla con `NU1004` ante un cambio sin regenerar.",
         "EA-1 paso 2b: con `Directory.Build.targets`, `packages.lock.json` aparece en el ejecutable y no en la biblioteca, y en modo CI el restore pasa y falla con `NU1004` ante un cambio sin regenerar; paso 2c: un `WinExe` (WinForms con `EnableWindowsTargeting`) también recibe su lock [B215].", "prosa"),
   ("R", '  // Hook versionado activado una vez por clon.\n  "postCreateCommand": "git config core.hooksPath .githooks && dotnet --version && node --version && uv --version"',
         '  // Hook versionado activado una vez por clon. El contenedor corre como root: sin\n  // safe.directory, git rechaza el repo montado (dubious ownership, guía 8.2.5).\n  "postCreateCommand": "git config --global --add safe.directory ${containerWorkspaceFolder} && git config core.hooksPath .githooks && dotnet --version && node --version && uv --version"', "evid"),
   ("R", "Con `build.dockerfile` no hay *features* ni `devcontainer-lock.json`: lo que se congela es la receta, y sus bases van por digest. Fuentes: [B119], [B136].",
         "Con `build.dockerfile` no hay *features* ni `devcontainer-lock.json`: lo que se congela es la receta, y sus bases van por digest. EA-1 paso 10: `devcontainer up` (CLI 0.89.0) en host Linux da `outcome: success` con el hook activado. Fuentes: [B119], [B136], E5-3.", "prosa"),
   ("R", "RUN test -n \"$PYTHON_VERSION\" \\\n && uv python install \"$PYTHON_VERSION\" \\\n && ln -s \"$(uv python find \"$PYTHON_VERSION\")\" /usr/local/bin/python3 \\\n && chmod -R a+rX /opt/uv-python \\",
         "# EditorConfig: lo importa el paso de texto de la compuerta (A.11).\nRUN test -n \"$PYTHON_VERSION\" \\\n && uv python install \"$PYTHON_VERSION\" \\\n && ln -s \"$(uv python find \"$PYTHON_VERSION\")\" /usr/local/bin/python3 \\\n && uv pip install --system --break-system-packages --python /usr/local/bin/python3 EditorConfig==0.17.1 \\\n && chmod -R a+rX /opt/uv-python \\", "evid"),
   ("R", "La plantilla vive en `Examples/A-plantillas/repo/imagen/Dockerfile` y EA-1 la construye y corre la plantilla `web/` adentro (Node 24.21.0, npm 11.19.0, glibc 2.36 en las dos bases).",
         "La plantilla vive en `Examples/A-plantillas/repo/imagen/Dockerfile` y EA-1 la construye y corre adentro la plantilla `web/` (Node 24.21.0, npm 11.19.0, glibc 2.36 en las dos bases) y la compuerta completa de A.11.", "prosa"),
   ("R", "# Examples/N7-compuertas-y-gobierno/compuerta/compuerta.sh (un proyecto por ecosistema en la raíz)\n# o Examples/N8-integracion-poliglota/solucion/verificar.sh (proyectos en subcarpetas, guía 10.2.2).\n",
         "# Examples/N7-compuertas-y-gobierno/compuerta/compuerta.sh (proyectos en la raíz o en subcarpetas).\n", "evid"),
   ("R", A11_QUE_OLD, A11_QUE_NEW, "prosa"),
   ("RG", A12_OLD_START, "### A.13 `dependabot.yml`", A12_NEW, "evid"),
   ("R", "Un ADR aceptado no se edita: si la decisión cambia, uno nuevo lo reemplaza y se vinculan [B184]. Versión del laboratorio con un ejemplo real (subir de SDK 8 a 10): `Examples/N7-compuertas-y-gobierno/04-descongelamiento-controlado/ADR-plantilla-entorno.md`.\n\n",
         "Un ADR aceptado no se edita: si la decisión cambia, uno nuevo lo reemplaza y se vinculan [B184]. Versión del laboratorio con un ejemplo real (subir de SDK 8 a 10): `Examples/N7-compuertas-y-gobierno/04-descongelamiento-controlado/ADR-plantilla-entorno.md`.\n\n" + A17_A18, "evid"),
  ],
  nota="En el op de A.12 (rango) la prosa nueva es el párrafo «Ilustrativo» y la frase de la variante; en A.17/A.18, las preguntas y las dos frases finales. El balance de §2 los cuenta aparte (columna «prosa dentro de bloques mixtos»).")

# ---------------------------------------------------------------------------------------------
parche("P-16", "Anexo B: listas por actor", ["C2-12", "C2-01", "C2-02", "C2-23", "C2-08", "C2-26", "C2-14"],
  "B.2 L2918, L2921; B.3 L2932–L2933; B.4 L2943", "guía", "bajo", True,
  "Cada ítem tocado remite a una sección que, tras P-07…P-15, dice lo mismo; `grep -c '¿La imagen sigue fijada por digest'` → 0; B.4 tiene 8 ítems.",
  [
   ("R", "- [ ] Para `*.cs` se eligió una variante (repo nuevo sin BOM; heredado convertido con BOM) y está declarada. (§5.2.3)",
         "- [ ] Para `*.cs` y los archivos de proyecto se eligió la variante según el estado del repo (nuevo → sin BOM; heredado todavía en cp1252 → la decidida antes del commit de política; heredado ya con BOM → `utf-8-bom`) y está declarada. (§5.2.3)", "prosa"),
   ("R", "- [ ] Con la política con lock, cada ejecutable tiene su lock (`Directory.Build.targets`, A.4); los proyectos comunes no lo necesitan.",
         "- [ ] Con la política con lock, cada ejecutable (`Exe` o `WinExe`) tiene su lock (`Directory.Build.targets`, A.4), `NU1603` es error y la compuerta compara `requested` con `resolved`; los proyectos comunes no lo necesitan.", "prosa"),
   ("R", "- [ ] La CI exporta `SOURCE_DATE_EPOCH` = fecha del commit y define `CI=true` o `TF_BUILD` para `ContinuousIntegrationBuild`. (§9.5, A.4)",
         "- [ ] `SOURCE_DATE_EPOCH` = fecha del commit llega a los pasos que construyen (en GitHub Actions, por `GITHUB_ENV`), y la CI define `CI=true` o `TF_BUILD` para `ContinuousIntegrationBuild`. (§9.5, A.4)", "prosa"),
   ("R", "- [ ] Se graban el registro del entorno y el SBOM junto al artefacto;", "- [ ] Se graban el registro del entorno (A.17) y el SBOM junto al artefacto;", "prosa"),
   ("R", "- [ ] ¿La imagen sigue fijada por digest y su SDK coincide con `global.json`? (§8)",
         "- [ ] ¿Lo que construye artefactos publicados sigue por digest? ¿El devcontainer usa etiqueta fija o la receta de la CI, y su SDK coincide con `global.json`? (§8.2.2)\n- [ ] ¿Los `.sh` y el hook nuevos entran como `100755` (`git ls-files -s`)? (§8.2.5, A.11)", "prosa"),
  ])

# ---------------------------------------------------------------------------------------------
parche("P-17", "Anexo C: «registro», «manifiesto», «VS» y el marco de §2", ["C2-35", "C2-52"],
  "Anexo C (filas nuevas en orden alfabético); «Registro del entorno»; «Índice de paquetes»", "guía", "bajo", True,
  "Los términos «Manifiesto», «Registro de paquetes / de imágenes», «VS» y «Escenario / contexto / actor» están en el Anexo C y remiten a secciones que existen; orden alfabético conservado.",
  [
   ("R", "| Enfriamiento (*cooldown*) |", "| Escenario / contexto / actor | Dónde se edita o construye (ESC-nn) / composición tecnológica de la solución (CTX-…) / rol con decisiones propias (ACT-…). | §2 |\n| Enfriamiento (*cooldown*) |", "prosa"),
   ("R", "| Índice de paquetes | Registro del que se descargan paquetes (en Python, *index*); sinónimo de registro. | §7.1 |",
         "| Índice de paquetes | Registro del que se descargan paquetes (en Python, *index*); sinónimo de registro de paquetes. | §7.1 |", "prosa"),
   ("R", "| Mapeo de fuentes |", "| Manifiesto | Sin complemento, el del paquete (`package.json`, `.csproj`, `pyproject.toml`); «manifiesto de la imagen» es lo que nombra un digest, y «manifiesto de capas», el registro por capa de E0-6. | §7.1, §8.1 |\n| Mapeo de fuentes |", "prosa"),
   ("R", "| Registro del entorno | Lo que se graba en la build sobre el entorno usado; sin firma. | §3.1 |",
         "| Registro de paquetes / de imágenes | Servidor del que se descargan paquetes (*registry*; alias: índice, *feed*) o imágenes; se nombra siempre con su complemento. | §7.1, §8.1 |\n| Registro del entorno | Lo que se graba en la build sobre el entorno usado; sin firma. | §3.1, A.17 |", "prosa"),
   ("R", "| Verificación por reconstrucción |", "| VS | Abreviatura de Visual Studio; no es VS Code. | §2.1 |\n| Verificación por reconstrucción |", "prosa"),
  ])

# ---------------------------------------------------------------------------------------------
BIB_NEW = """| B205 | Python — Python 3.15.0 (release, 2026-10-09; PEP 686 activo) | https://www.python.org/downloads/release/python-3150/ | 2026-10-09 |
| B206 | pnpm 10.x — Settings (`managePackageManagerVersions`, `packageManagerStrict`, `packageManagerStrictVersion`) | https://pnpm.io/10.x/settings | 2026-10-09 |
| B207 | Yarn — `yarn set version` (`--yarn-path`, `yarnPath`) | https://yarnpkg.com/cli/set/version | 2026-10-09 |
| B208 | Docker Docs — SLSA definitions (`builder.id`, parámetro `builder-id`) | https://docs.docker.com/build/metadata/attestations/slsa-definitions/ | 2026-10-09 |
| B209 | Git for Windows — Release notes, *Known issues* (conversión de rutas, `MSYS_NO_PATHCONV`) | https://github.com/git-for-windows/build-extra/blob/main/ReleaseNotes.md | 2026-10-09 |
| B210 | GitHub Docs — Working with the Container registry (visibilidad privada por defecto) | https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-container-registry | 2026-10-09 |
| B211 | GitHub Docs — Workflow syntax (`permissions`: lo no declarado queda en `none`) | https://docs.github.com/en/actions/reference/workflows-and-actions/workflow-syntax | 2026-10-09 |
| B212 | GitHub Docs — Workflow commands (`GITHUB_ENV`) | https://docs.github.com/en/actions/reference/workflows-and-actions/workflow-commands | 2026-10-09 |
| B213 | Renovate — manager `github-actions` (depType `container` y `service`) | https://docs.renovatebot.com/modules/manager/github-actions/ | 2026-10-09 |
| B214 | GitHub Enterprise Server 3.22 — Managing pre-receive hooks on your instance (delegación a administradores) | https://docs.github.com/en/enterprise-server@3.22/admin/enforcing-policies/enforcing-policy-with-pre-receive-hooks/managing-pre-receive-hooks-on-your-instance | 2026-10-09 |
| B215 | Microsoft Learn — Breaking change: `OutputType` set to `WinExe` for WPF and WinForms apps (SDK 5.0.100) | https://learn.microsoft.com/en-us/dotnet/core/compatibility/sdk/5.0/automatically-infer-winexe-output-type | 2026-10-09 |
| B216 | actions/runner-images — README (versión de la imagen en el log «Set up job») | https://github.com/actions/runner-images | 2026-10-09 |
| B217 | GitHub Actions — `setup-python` y etiquetas de `setup-dotnet` v6.0.0, `setup-node` v7.1.0, `setup-python` v7.0.0, `setup-uv` v10.2.0 (`git ls-remote`) | https://github.com/actions/setup-python · https://github.com/actions/setup-dotnet · https://github.com/actions/setup-node · https://github.com/astral-sh/setup-uv | 2026-10-09 |
"""
parche("P-18", "Anexo D: fuentes nuevas y promesa de citas de código", ["C2-49", "C2-04", "C2-10", "C2-16", "C2-17", "C2-18", "C2-20", "C2-26", "C2-29", "C2-30", "C2-41", "C2-02", "C2-13"],
  "Anexo D L3040; filas B205–B217 tras B204", "guía", "bajo", True,
  "Script de bibliografía del ciclo 1: 217 `[Bnn]` definidas = 217 citadas, ninguna colgante ni duplicada; cada URL nueva se consultó el 2026-10-09 "
  "(WebFetch o `git ls-remote`, §4 de este documento).",
  [
   ("R", "Las fuentes B01–B193 se consultaron el **2026-10-07**; B194–B204, el **2026-10-09**.", "Las fuentes B01–B193 se consultaron el **2026-10-07**; B194–B217, el **2026-10-09**.", "evid"),
   ("R", "Las fuentes de código (Roslyn, Node, VS Code) se citan por archivo y commit cuando el comportamiento no estaba documentado en prosa.",
         "Las fuentes de código (Roslyn, VS Code) se citan por archivo y commit cuando el comportamiento no estaba documentado en prosa; el cargador de Node, por la rama v22.x consultada.", "prosa"),
   ("R", "| B204 | git — git-reset (`--hard`) | https://git-scm.com/docs/git-reset | 2026-10-09 |\n",
         "| B204 | git — git-reset (`--hard`) | https://git-scm.com/docs/git-reset | 2026-10-09 |\n" + BIB_NEW, "evid"),
  ])

# ---------------------------------------------------------------------------------------------
parche("P-19", "Anexo E: filas de E3-3 y EA-1", ["C2-30", "C2-02", "C2-07", "C2-11", "C2-12", "C2-14"],
  "Anexo E, filas E3-3 y EA-1", "guía", "bajo", True,
  "Cada ID del cuerpo tiene fila (72 citados); la fila de EA-1 nombra los pasos 1c, 2c, 8, 9 y 10 que existen en `Examples/A-plantillas/verificar.sh` tras P-23 L3.",
  [
   ("R", "Corepack (Node 22/24/26); pnpm ≥ 11 y `pmOnFail` sin Corepack |", "Corepack (Node 22/24/26); pnpm 12 y `pmOnFail` sin Corepack |", "prosa"),
   ("R", "| EA-1 | Todas las plantillas del Anexo A, juntas; `dotnet new console`, lock sólo en ejecutables, imagen A.10 |",
         "| EA-1 | Todas las plantillas del Anexo A, juntas; `dotnet new console`, variante B, lock en `Exe` y `WinExe`, imagen A.10 con la compuerta completa adentro, registro del entorno, `devcontainer up` |", "prosa"),
  ])

# ---------------------------------------------------------------------------------------------
parche("P-20", "Anexo F: trazas, límites, Python 3.15, `builder.id` y fechas", ["C2-34", "C2-16", "C2-29", "C2-49", "C2-42", "C2-04"],
  "Anexo F L3325–L3384", "guía", "bajo", True,
  "R-03 remite a §3.7 y a §4–§11; P-09 a «n.3 de §4–§11»; `grep -c 'Formato de SBOM'` en el Anexo F → 0; `grep -c 'cómo completar .builder.id.'` → 0; "
  "`grep -c 'Datos volátiles al 2026-10-07'` → 0; el título nuevo coincide con su entrada del índice (P-01).",
  [
   ("R", "## Anexo F. Límites y lo que no se verificó\n\nSiguiendo la separación entre hechos e interpretaciones, esta lista reúne lo que la guía **no** afirma como hecho.",
         "## Anexo F. Trazas, límites y lo que no se verificó\n\nPrimero, qué pedido cubre cada sección; después, separados, los hechos que acotan el alcance, lo no verificado y las interpretaciones.", "prosa"),
   ("R", "**Qué pedido cubre cada sección.** Los identificadores del campo `traces` del encabezado:",
         "**Qué pedido cubre cada sección.** Los identificadores del campo `traces` del encabezado: P-nn son los pedidos de contenido del caso; R-nn, los requisitos de forma del pedido, con su número (R-04 y R-05 regían el proceso de trabajo, no la guía).", "prosa"),
   ("R", "| P-09 | Estrategias de la industria para .NET, Node.js y Python | «Qué propone la industria» de §4–§10 |",
         "| P-09 | Estrategias de la industria para .NET, Node.js y Python | n.3 («Qué propone la industria») de §4–§11 |", "prosa"),
   ("R", "| R-03 | Snippets y preguntas guía que forman criterio | n.5, n.6 y n.9 de §3–§11; Anexo A |",
         "| R-03 | Snippets y preguntas guía que forman criterio | §3.7; n.5, n.6 y n.9 de §4–§11; Anexo A |", "prosa"),
   ("R", "la DLL de `Debug` distinta de la de `Release` en la frontera A, y la versión de BuildKit del builder (v0.33.1).",
         "la DLL de `Debug` distinta de la de `Release` en la frontera A, y la versión de BuildKit del builder (v0.33.1). Tampoco los mensajes de deriva e integridad de Yarn 4.10.3, pnpm 10.18.0, uv 0.12.23 y Poetry 2.5.1 de la tabla de §7.3.", "prosa"),
   ("R", "- El modo UTF-8 por defecto de Python 3.15 en una versión real (final prevista para el 2026-10-09).",
         "- El modo UTF-8 por defecto de Python 3.15.0, publicada el 2026-10-09 [B205]: el laboratorio usa 3.12.", "prosa"),
   ("R", "- La firma sin clave con cosign y cómo completar `builder.id` en BuildKit (§9.2.4).", "- La firma sin clave con cosign (§9.2.4).", "prosa"),
   ("R", "**Datos volátiles al 2026-10-07** (revisar antes de aplicar): SDK de .NET 10.0.401 vigente y .NET 11 en RC1; fin de soporte de .NET 8 y 9 el 2026-11-10;",
         "**Datos volátiles** (al 2026-10-07; los de B194–B217, al 2026-10-09; revisar antes de aplicar): SDK de .NET 10.0.401 vigente y .NET 11 en RC1; SDK 8.0.425, el del caso, y fin de soporte de .NET 8 y 9 el 2026-11-10;", "prosa"),
   ("R", "Python 3.15.0 prevista para el 2026-10-09;", "Python 3.15.0 publicada el 2026-10-09;", "prosa"),
   ("R", "\n**Formato de SBOM.** La guía recomienda un solo formato por solución, el que pida el consumidor, y CycloneDX cuando nadie pide otro (§9.2.3).\n", "", "prosa"),
  ])

# ---------------------------------------------------------------------------------------------
CC_OLD_START = "| 1.0.0-rc.1 | 2026-10-09 | Revisión integral, ciclo 1. **Corrige**:"
CC_NEW = """| 1.0.0-rc.1 | 2026-10-09 | Revisión integral, ciclo 1 (detalle abajo). |
| 1.0.0 | 2026-10-09 | Revisión integral, ciclo 2: versión vigente (detalle abajo). |

**1.0.0-rc.1.** *Corrige*: el *fallback* de Roslyn en Windows con ACP UTF-8, pregunta abierta (§4.2.1); Razor y Node fallan con un identificador cp1252 (§4.2.4); el BOM de la familia .NET es convención, con la rama «heredado todavía en cp1252» (§5.2.3); *squash* compatible con `.git-blame-ignore-revs` y árbol limpio para refrescar (§5.2.6); el compilador de Visual Studio depende del SDK, y `disable` exige el SDK exacto en toda máquina (§6.2.2, §6.4); el lock calla `NU1603` (§7.2.1); digest y bot donde se construye lo publicado (§8.2.2); `builder.id` vacío no alcanza L1 y la firma se condiciona a un consumidor (§9.2.4, §12); qué impide una rama protegida (§10.2.7); alcance de la compuerta (§10.2.2); `devEngines`, igualdad A = B en la CI e imagen única (§11). *Agrega*: ruta mínima y **Práctica** por capítulo; mapa por contexto; una pregunta situada por capítulo; trazas (Anexo F); 23 términos; B194–B204; E2-7, E2-8 y diez experimentos ampliados. *Plantillas*: `Directory.Build.targets`, devcontainer con la receta de A.10, A.10 con Node 24, esqueleto de compuerta que falla, `docker` en `dependabot.yml`. *Marcas*: cuatro, de vocabulario cerrado (§0.3).

**1.0.0.** *Corrige*: `NU1603` como error con lock y sin lock, y la compuerta compara `requested` con `resolved` (§6.4, §7.2.1, A.4, A.11); lock también en `WinExe` (A.4b); la compuerta encuentra los proyectos en subcarpetas y nombra el paquete EditorConfig que falta (§10.2.2); `safe.directory` en el devcontainer (A.9); variante B con los archivos de proyecto (A.1); pnpm hace cumplir `packageManager` desde la 10 (§6.2.3); Python 3.15.0 publicada (§4.3); §9.2.4 comprimido para 8b, con `builder-id` (§9.2.4); dos caminos de CI para 8a (§8.2.2, §12); qué no impide un chequeo requerido y un `pre-receive` (§10.2.7); extractos literales (§1.2, §9.2.1, §11.5). *Agrega*: A.17 (registro del entorno), A.18 (`.gitignore`), A.12 con permisos, credenciales, `GITHUB_ENV` y variante de runner alojado; Práctica de §11 y de §12; B205–B217."""
parche("P-21", "Control de cambios: celda breve, detalle debajo y fila 1.0.0", ["C2-36", "C2-37", "C2-40", "C2-56"],
  "Control de cambios L3387–L3391", "guía", "bajo", True,
  "Ninguna celda de la tabla supera 60 palabras (script de celdas del ciclo 2); `grep -c 'cerrado de cinco'` → 0; la fila 1.0.0 coincide con `version:` del encabezado.",
  [
   ("RG", CC_OLD_START, "\x00FIN", CC_NEW, "prosa"),
  ])

# =============================================================================================
# Ajustes de compresión (C2-36, C2-37): se fusionan en el parche de la sección que tocan.
def _p(pid): return [x for x in P if x['id']==pid][0]
def set_new(pid, old_start, new):
    for k,op in enumerate(_p(pid)['ops']):
        if op[1].startswith(old_start):
            l=list(op); l[3 if op[0]=='RG' else 2]=new; _p(pid)['ops'][k]=tuple(l); return
    raise KeyError((pid,old_start))
def add(pid, *ops): _p(pid)['ops'].extend(ops)
def drop(pid, old_start):
    o=_p(pid)['ops']; idx=[k for k,op in enumerate(o) if op[1].startswith(old_start)]; assert len(idx)==1; del o[idx[0]]

add("P-02", ("RL", "Quedan fuera: el despliegue y la operación en producción",
  "Quedan fuera: el despliegue y la operación en producción (la guía termina en el artefacto y su procedencia; verificar antes de instalar es tema de la [guía de Despliegue](../Despliegue/)), otros ecosistemas (Java, Go, Rust), las comparativas comerciales de productos de CI, la herramienta única «para todo» y los enfoques que reemplazan el entorno completo: sistemas de build herméticos que gestionan las herramientas como fuente (Bazel, de donde sale la definición de §3.1 [B04]) o gestores declarativos de todo el sistema. **[criterio]** La guía parte de un repositorio que se edita con Visual Studio en Windows y se construye con las CLI de cada ecosistema, y conserva esas herramientas: archivos nativos, una compuerta y, donde hace falta, una imagen por digest; comparar un enfoque de entorno completo pide otra evidencia, que ésta no reunió.", "prosa"))

add("P-06",
 ("RL", "El compilador lee cada fuente con `EncodedStringText.Create`.",
  "El compilador lee cada fuente con `EncodedStringText.Create`: si el archivo empieza con BOM, el BOM manda; si no, y el proyecto **no** indica página de códigos, intenta UTF-8 estricto y, si falla, decodifica con un *fallback* que el código define como «la página ANSI por defecto; si no, 1252; si no, Latin-1» [B14]. En Linux, `GetEncoding(0)` devuelve UTF-8 [B19] (E1-02): el segundo intento vuelve a ser UTF-8, ahora tolerante, y cada byte de cp1252 se convierte en U+FFFD. La prueba con que el equipo del compilador corrigió en abril de 2026 una regresión de ese *fallback* afirma que en Windows es la página ANSI real «aun cuando la opción de configuración regional UTF-8 está activada», y en Linux y macOS, donde no hay página ANSI, UTF-8 [B15].", "prosa"),
 ("RL", "Experimentos del capítulo: E1-01 (", "Experimentos del capítulo: E1-01 a E1-13 (Anexo E).", "prosa"))

add("P-07", ("RL", "Experimentos del capítulo: E2-1 (", "Experimentos del capítulo: E2-1 a E2-8, E5-7 y EA-1 (Anexo E).", "prosa"))

add("P-08",
 ("RL", "**¿Fijar el SDK fija el compilador?** En la CLI, sí:",
  "**¿Fijar el SDK fija el compilador?** En la CLI, sí: `dotnet build` compila con el Roslyn del SDK (E3-2). En Visual Studio la build corre con el MSBuild del IDE y depende del SDK: los *targets* del 8.0.425 no traen selección automática —sólo `BuildWithNetFrameworkHostedCompiler`, y `Microsoft.Net.Sdk.Compilers.Toolset` no tiene versiones 8.x [B60]—, así que compila el Roslyn del IDE; los del 10.0.400 usan el del SDK si hay `DOTNET_HOST_PATH`, descargan el *toolset* si el MSBuild es anterior a 18.9 y, si no, caen en el del IDE (E3-2, inspección de los *targets* de las imágenes oficiales). Qué corre en un Visual Studio real **[no verificado]** (requiere Visual Studio): el binario que vale es el de la CI, y el registro del entorno incluye la versión del compilador, no sólo la del SDK (§9.6).", "prosa"),
 ("RL", "Node no tiene un archivo propio para fijar su versión.",
  "Node no tiene un archivo propio para fijar su versión. **`.nvmrc`** es la convención de nvm, que no cambia de versión solo al entrar al directorio ni soporta Windows nativo [B69]; fnm lee `.nvmrc`, `.node-version` y, en su defecto, `engines.node` [B70]. Ni `node` ni `npm` lo leen: con `.nvmrc` = 24 en Node 22, `npm install` termina sin aviso (E3-3). **`engines`** es «sólo un aviso» salvo `engine-strict` [B63][B64]: `EBADENGINE` con código 0, o 1 con `engine-strict=true` (E3-3). **`devEngines`** alinea las herramientas de quienes **desarrollan** el proyecto (runtime, gestor, SO, CPU), con `onFail` por defecto `error`, evaluado antes de `install`, `ci` y `run` [B63]: falla con `EBADDEVENGINES` sin tocar `.npmrc` (E3-3, EA-1). **`packageManager`** lo lee Corepack, que rechaza otro gestor y descarga la versión exacta [B67] (E3-3); pero Corepack figura como experimental en Node 24 [B65] y **dejó de distribuirse con Node desde la 25.0.0** [B66][B67] (E3-3: Node 22 y 24 lo traen, Node 26 no).", "prosa"),
 ("RL", "Experimentos del capítulo: E3-1 (", "Experimentos del capítulo: E3-1 a E3-7 (Anexo E); en E3-7, las etiquetas `sdk:8.0` y `sdk:10.0` del host derivaron de 8.0.424 a 8.0.425 y de 10.0.302 a 10.0.400, un cambio de **banda**.", "prosa"))

add("P-09",
 ("RL", "`uv.lock` es TOML, lo administra uv,",
  "`uv.lock` es TOML, lo administra uv, se commitea y es **universal**: en E4-5 incluyó `colorama` con `marker = \"sys_platform == 'win32'\"`, una dependencia que sólo existe en Windows [B98][B99]. `uv run` y `uv sync` bloquean y sincronizan solos: en desarrollo, un cambio en `pyproject.toml` reescribe el lock (E4-5). `--locked` falla si el lock no está al día; `--frozen` lo usa **sin verificar** [B97]: **[criterio]** en CI, `--locked`. Poetry: `install` con lock desactualizado falla y `check --lock` lo verifica [B105] (E4-5). `uv pip compile` da un `requirements.txt` **por plataforma** salvo `--universal` [B98]; `pip-compile` no tiene esa opción y su README pide compilar en cada entorno de destino [B104]. En E4-5, `uv pip compile` sin `--universal`, corrido en Linux, **omitió** `colorama`: «funciona en Linux, en Windows falta un paquete». El modo hash de pip es todo o nada y exige `==` [B102].", "prosa"),
 ("RL", "Experimentos del capítulo: E4-1 (", "Experimentos del capítulo: E4-1 a E4-5 (Anexo E; salidas en `Examples/N4-congelamiento-de-dependencias/salidas/`).", "prosa"))

add("P-10",
 ("RL", "Docker documenta que las etiquetas son mutables",
  "Docker documenta que las etiquetas son mutables y que fijar por digest garantiza la misma imagen, al costo de renunciar a las correcciones de seguridad automáticas; propone mitigarlo con Docker Scout o con Dependabot, que según Docker abre PR con etiqueta y digest nuevos [B113]. La página de ecosistemas de GitHub no menciona digests para `docker` [B107] y el laboratorio no lo observó **[no verificado]** (requiere la plataforma). Las imágenes de .NET distinguen etiquetas *fijas* (`8.0.11`: la versión de .NET no cambia) y *flotantes* (`8.0`), y **ambas** se rehacen cuando cambia la base del SO: «para pedir un parche específico del sistema operativo hace falta fijar por digest» [B115]. Se reconstruyen dentro de las 12 horas de una actualización de su base, con cada versión de .NET, ante CVE críticos y una vez por mes, típicamente el segundo martes [B115].", "prosa"),
 ("RL", "Dos imágenes que un equipo llamaría «la de .NET 10»",
  "Dos imágenes que un equipo llamaría «la de .NET 10» dieron SDK y binarios distintos, y `global.json` lo detectó sin que nadie mirara versiones. No se encontró una recomendación oficial de usar la misma imagen; containers.dev presenta la especificación también como ayuda a la CI [B138] y mantiene una acción que corre la CI dentro del devcontainer [B134]. **[criterio]** Hace falta **compartir la base que trae el toolchain** y que el repo verifique la coincidencia: la CI dentro del devcontainer preconstruido (stacks simples) o la imagen de desarrollo `FROM` el mismo `sdk@sha256` de la CI, con herramientas agregadas (multi-runtime, §11); no imágenes elegidas por un nombre parecido.", "prosa"),
 ("RL", "Experimentos del capítulo: E5-1 (", "Experimentos del capítulo: E5-1 a E5-7 y E5-5b (Anexo E).", "prosa"))

add("P-11", ("RL", "Experimentos del capítulo: E6-1 (", "Experimentos del capítulo: E6-1 a E6-6 y E6-2b (Anexo E).", "prosa"))

add("P-12",
 ("RL", "pre-commit (pre-commit.com) es un framework",
  "pre-commit es un framework de hooks multi-lenguaje, vigente en 4.6.2; el lenguaje de los hooks locales que usan un ejecutable del sistema se llama `unsupported` (antes `system`) desde la 4.4 [B180]. Sus hooks genéricos de texto traen una política propia: en E7-2, sobre un repo .NET con la política de §5, `fix-byte-order-marker` quitó el BOM de un `.razor` que la política exige [B52], y `end-of-file-fixer` agregó a `packages.lock.json` un salto final que NuGet vuelve a quitar: diffs sin contenido de ida y vuelta. **[criterio]** Un framework de hooks es un buen **orquestador** (instala, fija versiones, corre en paralelo); la política la hace cumplir un chequeo que **lee** `.editorconfig`, y los hooks genéricos se recortan con `exclude` alineados a ella.", "prosa"),
 ("RL", "Experimentos del capítulo: E7-1 (", "Experimentos del capítulo: E7-1 a E7-7 y E7-5b (Anexo E).", "prosa"))

drop("P-13", "hay entonces tres piezas distintas")
add("P-13",
 ("RL", "La tabla cambia la pregunta del caso.",
  "La tabla cambia la pregunta del caso. **Lo primero que se rompe no es la compilación de C#, sino lo que un humano no ve**: los scripts con shebang, los parsers estrictos de JSON y TOML, y las comparaciones de texto del propio equipo; las herramientas de paquetes (`npm`, `uv`, `dotnet`) toleran el BOM. Dos «OK» esconden daño: el `.sh` con BOM corre con otro intérprete y sale con 0 si lo lanza un shell (§4.2.4), y Node lee el JSON en cp1252 **sin quejarse**, con U+FFFD. Con código heredado, el ecosistema más permisivo es el que más tarde avisa: el caso rompe a C# en Linux, a Python en el primer `open` estricto y **corrompe en silencio** lo que lee Node.", "prosa"),
 ("RL", "**La compuerta es lo que hace «único» al punto de verdad.**",
  "**La compuerta es lo que hace «único» al punto de verdad.** Lee los tres archivos y los compara con lo instalado: si alguien sube `.nvmrc` y no reconstruye la imagen, falla con `node esperado 24.21.0, encontrado 22.23.2` (E8-2, `verificar.sh`); Node no lo habría detectado, porque no lee `.nvmrc`. **mise y asdf, como lectores y no como fuente**: mise 2026.10.3 no lee los archivos nativos salvo que se lo habilite, y un `mise.toml` con `node = \"24\"` **gana** sin avisar que contradice a `.nvmrc` (E8-2) [B79]. Las *features* de devcontainer tampoco los leen: por defecto, la de .NET usa `latest`, la de Node `lts` y la de Python `os-provided` [B137]: tres versiones flotando si no se fijan y verifican.", "prosa"),
 ("RL", "**El proyecto JavaScript de Visual Studio (`.esproj`).**",
  "**El proyecto JavaScript de Visual Studio (`.esproj`).** Es la forma documentada de tener proyectos Angular, React o Vue en una solución de Visual Studio, y en *Build* y *Restore* corre `npm install` (`ShouldRunNpmInstall`, `true` por defecto) y `npm run build` [B169]. E8-4 lo construyó en Linux: con el MSBuild del SDK 8, la versión 1.0.6887863 del SDK de JavaScript **no carga** (queda acoplada a la versión del SDK de .NET; `global.json` fija SDK de proyecto en `msbuild-sdks` [B56]); con SDK 10 corre `npm install` y, ante un `package.json` que ya no coincide con el lock, **reescribe el lock** con la build en verde: el «regenera en silencio» que §7 prohíbe. Con `ShouldRunNpmInstall=false` y un target propio que corre `npm ci` antes del interno `RunNpmInstall`, la misma deriva falla con `EUSAGE`. El enganche que sugiere la documentación (antes de `BeforeRestore`) no ejecutó `npm ci` en la versión probada, y `RunNpmInstall` es un nombre interno de `Sdk.targets`, no un contrato: se revisa al subir de versión. En Linux, además, el SDK intenta `cmd.exe` para `npm audit` y deja un directorio llamado literalmente `obj\\Debug`.", "prosa"),
 ("RL", "GitHub Actions ofrece `jobs.<id>.container`",
  "GitHub Actions ofrece `jobs.<id>.container`, que corre todos los pasos del job en una imagen [B135], y `strategy.matrix`, un job por combinación [B171]. **[criterio]** Imagen única cuando el artefacto es uno: el job corre `./build.sh`, el mismo comando que la estación y el devcontainer. Por componente sólo si los componentes se publican por separado, con una etapa previa que corre la compuerta completa en la imagen única: el Dockerfile por componente del laboratorio corre sólo los comandos estrictos, no la compuerta de texto. La matriz sirve para probar varias versiones de un runtime y no reemplaza a la compuerta; por **sistema operativo** es la forma barata de detectar lo que mostró el caso —el cp1252 compila en un runner Windows y falla en uno Linux— **[no verificado]** (no hubo runner Windows), pero los *job containers* exigen runner Linux [B172]: la celda Windows instala los toolchains en el runner y depende más de la compuerta. Dentro de un *job container* el shell por defecto de `run` es `sh`, no `bash` [B135].", "prosa"),
 ("RL", "La lección es de **alcance**:",
  "La lección es de **alcance**: el SBOM del artefacto (qué se entrega), el de las dependencias declaradas (qué terceros entraron) y el del entorno de build (las imágenes) son tres documentos distintos, con 2, 4 y casi 900 componentes en el mismo laboratorio. **[criterio]** Una solución políglota necesita al menos los dos primeros y la procedencia; el SBOM del entorno sirve para auditar la cadena de suministro y no se confunde con el del producto. La procedencia de BuildKit no está firmada y su `builder.id` sale vacío (§9.2.4); la que firma la plataforma, como la de `actions/attest`, exige en sus dependencias sólo el commit y deja el entorno como opcional [B202]. Para contestar «con qué entorno se ensambló» hay entonces tres partes **[criterio]**: (a) la procedencia de la plataforma, firmada, que nombra commit y workflow; (b) los materiales del entorno —digest de la imagen del job o de cada etapa, toolchain efectivo—, que registra un paso del pipeline (A.17); (c) su vínculo: un predicado propio firmado en la misma corrida, rotulado como afirmación del pipeline y no de la plataforma (la vara de §9.2.4), o la atestación de la imagen del job, enlazada por su digest.", "prosa"),
 ("RL", "Experimentos del capítulo: E8-1 (", "Experimentos del capítulo: E8-1 a E8-6 (Anexo E).", "prosa"))

set_new("P-14", "| 7 | Construir la imagen de CI", "| 7 | Elegir dónde corre la CI: imagen propia construida **desde** los archivos de los pasos 5–6, con bases por digest que mueve un PR (para 8b, reconstrucción bit a bit o frontera A en la CI), o runner alojado con acciones de *setup* por SHA que los leen (alcanza para 8a). El devcontainer, si se ofrece, con la misma receta o con etiqueta fija de SDK y SO verificada por `global.json`. | ACT-ARQ, ACT-OPS | La compuerta pasa en la CI y falla si se desalinea | §8.2.2, A.12 |")
P12_INTEG2 = """
**Práctica integradora** (sin experimentos nuevos).

1. Para cada validación del contrato, nombrá el experimento que la mostró y predecí el mensaje. *Respuesta esperada*: paso 3, E2-2 (`0 con cambio de contenido`); 4, E2-3 (`¿cp1252?`); 5, E3-1 (`A compatible .NET SDK was not found`); 6, E4-1 y E4-4 (`NU1004`, `EUSAGE`); 7, E7-4 (rojo en la imagen vieja).
2. ¿Qué deja sin detectar empezar por el devcontainer (paso 7) antes de fijar el toolchain (paso 5)? *Respuesta esperada*: con imagen por etiqueta y sin `global.json`, el SDK cambia sin que el repo se entere (E5-6, §3.5), y la capa 1 sigue rota adentro (E5-1).
"""
for k,op in enumerate(_p("P-14")['ops']):
    if P12_INTEG in op[2]:
        _p("P-14")['ops'][k]=(op[0],op[1],op[2].replace(P12_INTEG,P12_INTEG2),op[3])

# ---- ajuste 3: más compresión y versiones breves de lo agregado
add("P-03", ("RL", "Esas líneas contienen todo el caso.",
  "Esas líneas contienen todo el caso. El compilador no «lee cp1252 como UTF-8» a secas: intenta UTF-8, falla y vuelve a leer con la **página de códigos ANSI del sistema**, 1252 en un Windows en español y UTF-8 tolerante en Linux [B14][B19], donde cada byte inválido se vuelve el carácter de reemplazo U+FFFD (`�`). Un identificador no puede contener U+FFFD —no es una letra— y la compilación falla; un literal sí, y la corrupción pasa sin aviso hasta que alguien la ve. El `?` que vio el equipo es, probablemente, ese U+FFFD pasado por una salida que no es UTF-8, como en la última línea (interpretación compatible con el caso, no observada en el sistema original). El [§4](#4-codificación-y-finales-de-línea) explica el mecanismo.", "prosa"))
add("P-06",
 ("RL", "El BOM en un script merece un párrafo aparte,",
  "El BOM en un script daña en silencio. El kernel sólo reconoce un script si empieza con `#!` [B173]; con el BOM delante, `execve` devuelve `ENOEXEC`. Si lo lanzó un shell (bash, dash) o una función de la familia `execvp` (como el `child_process` de Node), se reintenta con `/bin/sh`: la primera línea falla, el resto corre **con ese shell** aunque el shebang pidiera otro intérprete, y sale con 0. Si lo lanzó un programa que llama a `execve` directo, como `subprocess.run` de Python, falla con `Exec format error` (E1-11, E8-1). El mismo archivo «anda» o no según el orquestador.", "prosa"),
 ("RL", "En casi todo el código CRLF y LF son equivalentes:",
  "En casi todo el código CRLF y LF son equivalentes: cambia el diff, no el programa. JavaScript y Python normalizan su fuente (ECMA-262 en los template literals [B24]; Python, todo el fuente [B28]). C# **no**: los literales verbatim y crudos incluyen los saltos de línea del archivo, y la especificación advierte que traducir `\\n` ↔ `\\r\\n` «cambia el comportamiento de la aplicación» [B21]. Un `@\"a⏎b\"` compila a `61-0A-62` con LF y a `61-0D-0A-62` con CRLF (E2-1): con `core.autocrlf=true` en Windows y LF en Linux, **el mismo commit produce dos binarios distintos**. Las otras excepciones son los scripts de shell (un CR tras el shebang impide ejecutarlos) y los datos leídos sin traducción (`fs.readFileSync`, Python con `newline=\"\"`).", "prosa"))
add("P-07",
 ("RL", "**[criterio]** Las dos dejan el índice en LF,",
  "**[criterio]** Las dos dejan el índice en LF y ninguna produce commits de EOL (E2-1); cambia el disco de Windows. La segunda conviene si hay literales multilínea de C# o datos leídos sin traducción cuyo contenido importa en las pruebas: con CRLF en la estación y LF en la CI, **la misma prueba da distinto** (§4.2.5). Si no, la primera vale igual, y es la de los repositorios del fabricante relevados. En las dos, las excepciones las exige el consumidor: `*.cmd` y `*.bat` con CRLF para `cmd.exe`, `*.sh` con LF. Visual Studio declara soportar `end_of_line` [B45], así que LF en Windows no debería requerir configuración local **[no verificado]** (requiere Windows). A.2 usa la segunda.", "prosa"),
 ("RL", "6. **Aislar de `blame`** en un commit **posterior**,",
  "6. **Aislar de `blame`** en un commit **posterior**, porque el SHA no existe hasta que se crea: sin el archivo, `git blame` atribuye todas las líneas al migrador; con él, vuelven a sus autores (E2-2). `git config blame.ignoreRevsFile .git-blame-ignore-revs` lo activa en local [B39]; GitHub lo aplica solo si el archivo está en la raíz [B42]. El SHA listado es el que quedó en `main`, que un `--amend` o un rebase cambian. La fusión por *squash* funciona con un PR por commit —política, migración, `.git-blame-ignore-revs`— y el SHA del *squash* ya fusionado: con git 2.47.3, `blame` vuelve a los autores (E2-2). Juntar los tres en un PR los aplasta en uno, y la verificación mecánica deja de aplicarse a un commit sólo mecánico **[criterio]**.", "prosa"))
add("P-09",
 ("RL", "**`nuget.config` en la raíz con `<clear />`**",
  "**`nuget.config` en la raíz con `<clear />`** evita que la configuración del usuario o de la máquina agregue fuentes [B87], como `.gitattributes` evita depender de `core.autocrlf`. El mapeo de fuentes exige que **todo** paquete, transitivas incluidas, coincida con un patrón (`NU1100` si no) [B86] (E4-3), con dos huecos documentados: un paquete ya presente en la carpeta global no consulta ninguna fuente, y el mapeo no aplica a consultas de metadatos [B86]. En E4-3, con la caché caliente, un impostor se coló e imprimió `IMPOSTOR`; el `contentHash` del lock lo detectó (`NU1403`): defensas complementarias.", "prosa"))
add("P-11",
 ("RL", "`package.json` tiene `repository` con `url` y `directory` [B63];",
  "`package.json` tiene `repository` con `url` y `directory` [B63]; no hay campo estándar para el SHA en el tarball, y `package-lock.json` nunca se publica [B63]: el grafo viaja en el SBOM o en la procedencia. **Con npm 11.19.0, `npm pack` dio el mismo tarball** desde dos rutas con fechas de archivo distintas, con `mtime` fijo 1985-10-26T08:15:00Z en las dos entradas del paquete de prueba (E6-3) **[observado]**; no se probaron otro usuario, otro *umask* ni otra versión, y su documentación no lo menciona [B150]: conviene que la compuerta lo **compruebe**. `npm publish --provenance` firma con Sigstore **sólo** desde GitHub Actions o GitLab con runners en la nube y `repository` público [B148]: no aplica tal cual a un paquete privado.", "prosa"),
 ("RL", "En Python, los metadatos núcleo no tienen campo para el commit [B72];",
  "En Python, los metadatos núcleo no tienen campo para el commit [B72]; una versión local PEP 440 (`1.4.0+g9e618f9`) sirve en índices privados pero PyPI no debe aceptarla [B106]; `direct_url.json` registra el commit de una instalación desde un VCS, no de la construcción [B153]. setuptools 84 dio ruedas **distintas** sin `SOURCE_DATE_EPOCH` e **idénticas** con ella; hatchling es reproducible por defecto [B152] (E6-4). PEP 770 reserva `.dist-info/sboms/` para el SBOM [B151], pero uno con `timestamp` y `serialNumber` vuelve no reproducible la rueda (E6-4), salvo con `cyclonedx-py --output-reproducible`. **[criterio]** Lo incrustado tiene que ser reproducible; un SBOM con fecha viaja **al lado**. PyPI acepta atestaciones (PEP 740) firmadas por un proveedor de *Trusted Publishing* [B154].", "prosa"))
add("P-12",
 ("RL", "Los cambios invisibles necesitan una herramienta:",
  "Los cambios invisibles necesitan una herramienta: en E7-3 un IDE guardó un `.cs` con BOM y la web muestra la línea entera cambiada con el texto idéntico; `Examples/N7-compuertas-y-gobierno/03-revisor-cambios-de-entorno/cambios-de-entorno.py` normaliza y reporta `Program.cs: mismo texto; cambia sólo ['BOM']`, y la compuerta lo rechaza. **El revisor no lo busca a ojo: decide si es la normalización acordada.** `CODEOWNERS` asigna los archivos de entorno; su aprobación es obligatoria sólo con protección de rama, y en GitLab requiere Premium o Ultimate [B178][B185].", "prosa"),
 ("RL", "**Bots.** Automatizan la **propuesta**, no la decisión.",
  "**Bots.** Automatizan la **propuesta**, no la decisión. Dependabot soporta `dotnet-sdk` (para `global.json`), `nuget`, `npm`, `uv`, `pip`, `docker`, `devcontainers`, `github-actions` y `pre-commit`, con `groups` y `cooldown`; por defecto espera 3 días en las actualizaciones de versión y no abre más de cinco PR a la vez [B182]; su tabla declara versiones máximas de gestor por debajo de las vigentes [B107], y cómo se comporta con las más nuevas **[no verificado]**. Microsoft sugiere Dependabot para el SDK de `global.json` y `CheckSdkVulnerabilities` para que la build avise [B58]. Renovate ofrece `minimumReleaseAge`, `lockFileMaintenance` y `pinDigests` [B108]. **[criterio]** Con un bot, **cada descongelamiento llega como PR**, con la misma compuerta, el mismo revisor y la misma traza; el enfriamiento deja que otros descubran una versión rota o maliciosa antes.", "prosa"))
add("P-13",
 ("RL", "La regla es la de §5, y E8-1 la confirma en conjunto",
  "La regla es la de §5, y E8-1 la confirma en conjunto (la columna A pasa los quince lectores): **UTF-8 sin BOM y LF como regla general, con excepciones por extensión que exige quien lee el archivo**, no el lenguaje: `.sh` sin BOM y con LF (el kernel); `.cmd`/`.bat` con CRLF (`cmd.exe`); `.razor`/`.cshtml`/`.sln` con BOM (las herramientas del SDK lo reponen); `.ps1` con BOM si se usa Windows PowerShell 5.1 [B54]; locks sin exigir salto final (NuGet no lo pone; `package-lock.json` y `uv.lock` sí). En `.editorconfig`, `unset` anula una propiedad de `[*]` y la sección posterior gana, así que las excepciones van al final [B43].", "prosa"),
 ("RL", "**Los dos caminos tienen que producir lo mismo**,",
  "**Los dos caminos tienen que producir lo mismo**, y en el laboratorio lo hacen cuando ruta **y configuración** coinciden: `build.sh` en `Release` y `dotnet build -c Release` dieron la misma DLL (`4dd5d90f…`); el `dotnet build` sin `-c` de F5 compila en `Debug` y da otra (verificación del laboratorio N8; Anexo F). **[criterio]** La igualdad se comprueba en la CI, no en la estación (F5 compila en `Debug` y sin `ContinuousIntegrationBuild`, §9.4), como **prueba de regresión del `.csproj`**: en la misma imagen, `dotnet build -c Release -p:ContinuousIntegrationBuild=true` con `ConstruirPoliglota=true` y `build.sh`, comparando las DLL. Demuestra que los targets de A no divergen de B, no que la estación reproduzca a la CI.", "prosa"))

# §9.2.4 más breve; la tabla de plataformas pasa a §9.3 (no se pierde)
P924_TABLA = P924_NEW[P924_NEW.index("| Plataforma | Mecanismo |"):P924_NEW.index("\n\nSin Enterprise Cloud")]
P924_B = P924_NEW.replace("\n\n" + P924_TABLA, "")
P924_B = P924_B.replace("**[criterio] Para el caso** (repositorio privado de una organización, equipo chico, artefactos internos)", "**[criterio] Para el caso** (repositorio privado, equipo chico, artefactos internos)")
P924_B = P924_B.replace("; agrega un *Source Track* y su lista de cambios no enumera cambios al Build Track [B11].", "; agrega un *Source Track* y no enumera cambios al Build Track [B11].")
P924_B = P924_B.replace("Ningún nivel exige builds reproducibles; figuran como candidatas a un futuro L4 [B07][B08].", "Ningún nivel exige builds reproducibles, candidatas a un futuro L4 [B07][B08].")
P924_B = P924_B.replace("BuildKit la genera en formato in-toto [B160] con un builder `docker-container` o con el almacén de containerd, predeterminado en Docker Engine 29 [B162]; el driver `docker` sobre el almacén clásico la rechaza. Para el artefacto .NET construido `FROM` el SDK por digest: `predicateType=https://slsa.dev/provenance/v1`; `subject` con los sha256 de DLL y PDB; `resolvedDependencies` con **la imagen del SDK por digest**; el commit en `vcs:revision`; y `builder.id` **vacío**, que no alcanza L1. Se completa con el parámetro `builder-id=` de `--provenance` [B208], pero su valor lo escribe el paso que invoca la build: identifica a la plataforma sólo emparejado con el firmante. La DLL salió idéntica a la de otra build independiente: la verificación por reconstrucción, funcionando.",
  "BuildKit la genera en formato in-toto [B160] con un builder `docker-container` o el almacén de containerd, predeterminado en Docker Engine 29 [B162] (el driver `docker` sobre el almacén clásico la rechaza). Para la DLL construida `FROM` el SDK por digest trae `predicateType=https://slsa.dev/provenance/v1`, `subject` con los sha256 de DLL y PDB, **la imagen del SDK por digest** en `resolvedDependencies`, el commit en `vcs:revision` y `builder.id` **vacío**, que no alcanza L1. Lo completa el parámetro `builder-id=` de `--provenance` [B208], con el valor que escribe quien invoca la build: identifica a la plataforma sólo junto al firmante. La DLL salió idéntica a la de otra build independiente: verificación por reconstrucción.")
P924_B = P924_B.replace("**[criterio]** pedir `--provenance=mode=max,version=v1` explícitamente.", "**[criterio]** pedir `--provenance=mode=max,version=v1`.")
P924_B = P924_B.replace("Sin firma, la procedencia es un JSON: E6-5 cambió `builder.id` y el archivo siguió siendo válido. Firmada con cosign (envoltorio DSSE [B163])", "Sin firma, la procedencia es un JSON: E6-5 cambió `builder.id` y siguió válida. Firmada con cosign (DSSE [B163])")
P924_B = P924_B.replace("Y `verify-blob-attestation` comprueba firma, `subject` y tipo de predicado, no su contenido (`builder.id`, repositorio, commit): eso es un paso aparte, con una política que fije lo esperado [B10].", "`verify-blob-attestation` comprueba firma, `subject` y tipo de predicado, no su contenido (`builder.id`, repositorio, commit): eso pide una política aparte [B10].")
P924_B = P924_B.replace("Sin Enterprise Cloud, las atestaciones nativas de GitHub no están disponibles en un repo privado,", "Qué ofrece cada plataforma está en §9.3. Sin Enterprise Cloud, las atestaciones nativas de GitHub no están disponibles en un repo privado [B158],")
P924_B = P924_B.replace("- **cosign sin clave**, con el token OIDC de la CI: un certificado efímero de Fulcio atado al workflow y el registro en el log público Rekor [B197]; para un repo privado, esa identidad queda publicada, salvo con una instancia propia de Sigstore. No se ejercitó en el laboratorio **[no verificado]**.",
  "- **cosign sin clave**, con el token OIDC de la CI: certificado efímero de Fulcio atado al workflow y registro en el log público Rekor [B197]; en un repo privado esa identidad queda publicada, salvo con una instancia propia de Sigstore. No se ejercitó **[no verificado]**.")
P924_B = P924_B.replace("—junto al release, junto al artefacto en su registro de paquetes, y su hash en un log de transparencia—", "—junto al release, junto al artefacto en su registro de paquetes, su hash en un log de transparencia—")
P924_B = P924_B.replace("**[criterio]** Para un equipo chico: procedencia y SBOM junto al artefacto,", "**[criterio]** Procedencia y SBOM junto al artefacto,")
set_new("P-11", "#### 9.2.4 Procedencia SLSA y firma\n", P924_B)
add("P-11", ("R", "| Procedencia en el registro | *Trusted Publishing* sin atestaciones documentadas [B165] | `--provenance` [B148] | PEP 740 [B154] | atestación en la imagen [B160] |\n",
  "| Procedencia en el registro | *Trusted Publishing* sin atestaciones documentadas [B165] | `--provenance` [B148] | PEP 740 [B154] | atestación en la imagen [B160] |\n\nProcedencia firmada por plataforma, para el paso 8b (§9.2.4):\n\n" + P924_TABLA + "\n", "prosa"))

# A.12 y A.17/A.18: prosa más breve
_a12 = [op for op in _p("P-15")['ops'] if op[0]=='RG' and op[1].startswith("Preguntas: ¿la imagen del job")][0][3]
_a12 = _a12.replace("Preguntas: ¿la imagen del job sale de la misma receta que el devcontainer (A.10), publicada y nombrada por digest, o alcanza el runner alojado (§8.2.2)? ¿La imagen es privada y el job tiene con qué descargarla? ¿Quién mueve el digest del `container:`? ¿La revisión de dueños es obligatoria sobre `.github/` y `tools/ci/` (§10.2.7)? ¿Cada acción está fijada por SHA? ¿El PR tiene la historia que necesita `--base`? ¿`SOURCE_DATE_EPOCH` llega a los pasos que construyen?",
  "Preguntas: ¿imagen propia por digest, de la receta del devcontainer (A.10), o runner alojado (§8.2.2)? Si es privada, ¿el job puede descargarla y quién mueve su digest? ¿La revisión de dueños es obligatoria sobre `.github/` y `tools/ci/` (§10.2.7)? ¿Cada acción va por SHA? ¿El PR tiene la historia que necesita `--base`? ¿`SOURCE_DATE_EPOCH` llega a los pasos que construyen?")
_a12 = _a12.replace("**Ilustrativo**: validado como YAML en EA-1, no ejecutado en GitHub; los `run:` corren en EA-1 dentro de la imagen de A.10 (paso 9). El SHA de `actions/checkout` v7.0.1 se resolvió con `git ls-remote` el 2026-10-07 [B193]. En GHCR un paquete nuevo nace privado [B210] y los permisos no declarados quedan en `none` [B211]: de ahí `packages: read` y `credentials` [B135]; `GITHUB_ENV` [B212]. Ningún ecosistema de Dependabot mueve el digest del `container:` [B107]: lo mueve el PR que abre el workflow que publica la imagen **[criterio]**. Fuentes: [B135], [B183].",
  "**Ilustrativo**: validado como YAML y con sus `run:` corridos en la imagen de A.10 (EA-1, paso 9); no ejecutado en GitHub. SHA de `actions/checkout` resuelto con `git ls-remote` el 2026-10-07 [B193]. En GHCR un paquete nuevo nace privado [B210] y los permisos no declarados quedan en `none` [B211]: de ahí `packages: read` y `credentials` [B135]; `GITHUB_ENV`, [B212]; quién mueve el digest, §8.2.2. Fuentes: [B135], [B183].")
_a12 = _a12.replace("Variante sin imagen propia, suficiente para 8a (§8.2.2): reemplaza `container:` y los pasos hasta `SOURCE_DATE_EPOCH`; la capa 4 es la imagen del runner, que queda en el log «Set up job» [B216].",
  "Variante con runner alojado, que alcanza para 8a (§8.2.2); reemplaza `container:` y los pasos previos a la compuerta:")
_a12 = _a12.replace("**Ilustrativo** **[no verificado]** (requiere GitHub): entradas de [B181] y [B217]; SHA resueltos con `git ls-remote` el 2026-10-09 [B217].", "**Ilustrativo** **[no verificado]** (requiere GitHub): entradas de [B181]; SHA de [B217].")
set_new("P-15", "Preguntas: ¿la imagen del job", _a12)
_a17 = A17_A18.replace("Preguntas: ¿qué no declara el repo y hay que grabar en la build (§3.7)? ¿De dónde sale el digest de la imagen? ¿Qué artefactos se registran?", "Preguntas: ¿qué no declara el repo y hay que grabar (§3.7)? ¿De dónde sale el digest de la imagen? ¿Qué artefactos se registran?")
_a17 = _a17.replace("Salida en EA-1 (paso 9: plantillas con sus locks, en la imagen de A.10; el digest es el de relleno de A.12):", "Salida en EA-1 (paso 9; digest de relleno de A.12):")
_a17 = _a17.replace("El compilador sale de `csc -version`, el mismo dato que da `#error version` (`CS8304`, §9.6). Sin `container:`, la línea `imagen` lo dice y la capa 4 queda en el log del runner [B216]. Fuentes: [B02], §9.6.", "El compilador sale de `csc -version`, el dato de `#error version` (`CS8304`, §9.6); sin `container:`, la capa 4 queda en el log del runner [B216]. Fuentes: [B02], §9.6.")
_a17 = _a17.replace("Preguntas: ¿qué genera cada ecosistema dentro del árbol? ¿Qué salidas no tiene que revisar la compuerta?", "Preguntas: ¿qué genera cada ecosistema dentro del árbol?")
_a17 = _a17.replace("Sin él, `git add -A` versiona `obj/`, y la compuerta y los revisores cargan con archivos generados (EA-1). `dotnet new gitignore` genera uno más completo para .NET.", "Sin él, `git add -A` versiona `obj/` y la compuerta revisa archivos generados (EA-1); `dotnet new gitignore` da uno más completo para .NET.")
for k,op in enumerate(_p("P-15")['ops']):
    if op[0]=='R' and A17_A18 in op[2]:
        _p("P-15")['ops'][k]=(op[0],op[1],op[2].replace(A17_A18,_a17),op[3])
set_new("P-15", "condición de CI de `Directory.Build.props`, lock sólo en los ejecutables,", "condición de CI de `Directory.Build.props`, lock sólo en los ejecutables (también `WinExe`), variante B de A.1, la imagen de A.10 con la plantilla `web/` y la compuerta completa adentro, registro del entorno, `devEngines`, uv, `devcontainer up`, y sintaxis de JSONC, YAML y del esquema de `dependabot.yml`.")

# Glosario breve
set_new("P-17", "| Enfriamiento (*cooldown*) |", "| Escenario / contexto / actor | ESC-nn, CTX-… y ACT-…: dónde se trabaja, qué combina la solución, qué rol decide. | §2 |\n| Enfriamiento (*cooldown*) |")
set_new("P-17", "| Mapeo de fuentes |", "| Manifiesto | Sin complemento, el del paquete (`package.json`, `.csproj`, `pyproject.toml`); «de la imagen», lo que nombra un digest; «de capas», el de E0-6. | §7.1, §8.1 |\n| Mapeo de fuentes |")
set_new("P-17", "| Registro del entorno | Lo que se graba en la build", "| Registro de paquetes / de imágenes | De dónde se bajan paquetes (alias: índice, *feed*) o imágenes; siempre con su complemento. | §7.1, §8.1 |\n| Registro del entorno | Lo que se graba en la build sobre el entorno usado; sin firma. | §3.1, A.17 |")
set_new("P-17", "| Verificación por reconstrucción |", "| VS | Visual Studio (no VS Code). | §2.1 |\n| Verificación por reconstrucción |")

# Control de cambios breve
set_new("P-21", "| 1.0.0-rc.1 | 2026-10-09 | Revisión integral, ciclo 1. **Corrige**:", """| 1.0.0-rc.1 | 2026-10-09 | Revisión integral, ciclo 1 (abajo). |
| 1.0.0 | 2026-10-09 | Revisión integral, ciclo 2; versión vigente (abajo). |

**1.0.0-rc.1.** Corrige el *fallback* de Roslyn, la convención de BOM de .NET, la migración con *squash*, el costo de `disable`, el lock que calla `NU1603`, digest y bot donde se construye lo publicado, el nivel SLSA de un `builder.id` vacío, qué impide una rama protegida y la frontera de build políglota. Agrega ruta mínima y Práctica, mapa por contexto, preguntas situadas, trazas, glosario, B194–B204, E2-7, E2-8 y plantillas; fija cuatro marcas de juicio (§0.3).

**1.0.0.** Corrige las dos defensas contra `NU1603`, el lock de `WinExe`, la compuerta en subcarpetas y sus prerrequisitos, el devcontainer en host Linux, la variante B, pnpm 10, Python 3.15.0, la procedencia para 8b, los dos caminos de CI, qué no impiden un chequeo requerido y un `pre-receive`, y los extractos literales. Agrega A.17, A.18, la Práctica de §11 y §12, y B205–B217.""")

# ---- ajuste 4
add("P-08",
 ("RL", "«Estamos en .NET 8» puede responder tres cosas distintas,",
  "«Estamos en .NET 8» responde tres preguntas, cada una fijada en otro archivo. **Con qué herramienta se compila**: el SDK, que elige `global.json`; sin él, `dotnet` usa el más alto instalado aunque el proyecto apunte a una versión anterior [B58]. **Contra qué API y con qué lenguaje**: el TFM del `.csproj`. **Con qué runtime corre**: lo decide la máquina que ejecuta. E3-2 las separa con un proyecto `net8.0`: con SDK 8.0.425 compila C# 4.11.0 y con 10.0.400 el 5.9.0, ambos en C# 12.0 por el TFM, y el binario del SDK 10 pide runtime 8.0 y **no arranca** donde sólo hay runtime 10. En Node y Python el intérprete es herramienta y runtime; lo que se separa es el **runtime** del **gestor de paquetes**.", "prosa"),
 ("RL", "**Visual Studio en Windows (ESC-01).**",
  "**Visual Studio en Windows (ESC-01).** Visual Studio instala **una sola copia** del SDK y la reemplaza al actualizarse; si `global.json` pide la anterior, la build deja de encontrarla, y Microsoft recomienda el SDK independiente para conservarla [B56][B59]. Cada banda exige un Visual Studio mínimo (10.0.100 → VS 17.14; 10.0.2xx–4xx → VS 18.0) [B59]: fijar una banda nueva obliga a todo el equipo a actualizar el IDE. Que Visual Studio respete `global.json` es una inferencia documentada (la build pasa por el resolvedor de MSBuild, y `allowPrerelease` describe un comportamiento «si estás en Visual Studio» [B56]), no una frase directa. Usar el SDK del IDE y fijar uno exacto con lock files, las dos recomendaciones de Microsoft, tiran en direcciones opuestas: §6.4 presenta la elección.", "prosa"),
 ("RL", "**`requires-python`** pertenece al **paquete**:",
  "**`requires-python`** pertenece al **paquete**: se publica como metadato y lo validan los instaladores [B71][B72]; pip falla si el intérprete no coincide, salvo `--ignore-requires-python` [B73][B74] (E3-4), y en uv acota la resolución del lock, calculada para todo el rango [B77]. **`.python-version`** es una preferencia **del entorno**, convención de pyenv que también lee uv [B78][B75]: uv lo busca en el directorio y sus padres **sin pasar el límite del proyecto**, y por defecto **descarga** el intérprete que falte (`python-downloads = \"automatic\"`) [B75][B76]. En E3-4, `3.13` descargó 3.13.16 («la 3.13 más reciente», no una fijación exacta); `3.11` contra `requires-python >=3.13` falla, y también falla sin 3.13 instalado y con descargas prohibidas. **`[tool.uv] required-version`** hace fallar uv si su versión no coincide [B76] (E3-4): el equivalente de `devEngines.packageManager`.", "prosa"))
add("P-09",
 ("RL", "Declarar una versión no congela nada.",
  "Declarar una versión no congela nada. Congela un **lock file** con el grafo completo y sus hashes, más un **comando de restauración que falle** si el lock no coincide con lo declarado; sin ese comando, el lock es una sugerencia que la herramienta reescribe. En npm y uv el fabricante pide versionar el lock [B93][B99]; en NuGet es *opt-in* [B83], y esta guía lo adopta por defecto, con su costo y una alternativa sin lock (§6.4, §7.2.1).", "prosa"),
 ("RL", "**Integración en una solución** (el detalle es de",
  "**Integración en una solución** (detalle en [§11](#11-una-sola-solución-con-net-nodejs-y-python)): no hay lock común. **[criterio]** Un lock por ecosistema junto a su manifiesto; una compuerta que llama a los tres comandos estrictos; los registros de los tres declarados en el repo; el toolchain fijado antes que el lock (la versión de npm decide `lockfileVersion`, la de uv el formato de `uv.lock`); y un bot que entienda los tres locks. Dependabot soporta NuGet, npm, pnpm, Yarn, pip, Poetry y uv, con versiones máximas (npm ≤ v11, pnpm ≤ v10, uv v0.11) por debajo de las vigentes al 2026-10-07 (npm 12, pnpm 12, uv 0.12) [B107]; Renovate tiene `lockFileMaintenance`, deshabilitado por defecto [B108].", "prosa"))
add("P-11",
 ("RL", "Desde el SDK 8, Source Link viene incluido",
  "Desde el SDK 8, Source Link viene incluido y el SHA del commit se agrega a `InformationalVersion` en todas las builds [B142][B143]. E6-1 lo muestra con `dotnet pack`: `AssemblyInformationalVersion = 1.4.0+9e618f99…`, la URL del repo como `AssemblyMetadata`, el mapa de Source Link en el PDB y `<repository type=\"git\" url=\"…\" commit=\"…\" />` en el `.nuspec` y el `.snupkg` (con `PublishRepositoryUrl=true`). El SDK **no** registra con qué SDK, imagen ni máquina se compiló; agregarlo como `AssemblyMetadata` (`$(NETCoreSdkVersion)` y un digest que pase la CI) sirve para diagnóstico, no como prueba. Y el SHA embebido **miente** con cambios sin commitear: en E6-1, un `Program.cs` modificado cambió la DLL con el mismo SHA. En una estación, es una pista.", "prosa"),
 ("RL", "**Build determinista.** El compilador de C#",
  "**Build determinista.** El compilador de C# es determinista por defecto, pero entre sus entradas están la ruta del directorio actual, la versión del compilador y los datos de Source Link [B18]. `ContinuousIntegrationBuild=true` habilita `DeterministicSourcePaths`, que mapea las rutas a valores independientes de dónde está el código; la build totalmente determinista pide `Deterministic` y `ContinuousIntegrationBuild` juntos, y las raíces mapeadas son los `SourceRoot` que aporta un repo git [B143][B144]. Microsoft lo condiciona a la CI porque en una estación el depurador deja de encontrar los fuentes [B144]. E6-2 compiló dos clones del mismo commit en rutas distintas:", "prosa"))
add("P-12",
 ("RL", "Tres condiciones observables la convierten en árbitro:",
  "Tres condiciones observables la convierten en árbitro: **clon limpio** (sin hooks ni configuración local; en E7-1 da el diagnóstico del hook); **la misma imagen** por digest o el toolchain instalado desde los archivos del repo [B181]; y **restauración estricta** (`--locked-mode` en CI/CD, recomienda NuGet [B83]). Y **todo lo que ejecuta la compuerta es parte del entorno**: fijar una acción a un SHA completo es la única forma de usarla como versión inmutable, hay políticas que lo exigen, y Dependabot no da alertas de vulnerabilidad para acciones fijadas por SHA, aunque sí las actualiza [B183]. Vale también para el `rev` de pre-commit (SHA, `autoupdate --freeze`) [B180] y para la imagen de CI.", "prosa"),
 ("RL", "En GitHub, las ramas protegidas, los dueños de código requeridos",
  "En GitHub, las ramas protegidas, los dueños de código requeridos y los *rulesets* están en repositorios **públicos** con Free y en privados con Pro (cuentas personales), Team o Enterprise (organizaciones) [B176][B177][B179]: para una organización, el mínimo es Team. En GitLab, las ramas protegidas y «Pipelines must succeed» están en Free —ésta impide fusionar un *merge request* sin pipeline exitosa, incluso sin ninguna [B199]—, y la aprobación obligatoria de dueños es Premium/Ultimate [B185]. En Azure DevOps la validación de build obligatoria decide si el PR se completa, con permisos de *bypass* explícitos [B186].", "prosa"),
 ("RL", "En GitHub Enterprise Server, los `pre-receive` de un repositorio",
  "En GitHub Enterprise Server, los `pre-receive` de un repositorio comparten un presupuesto acumulado de **5 segundos** y se desaconseja llamar servicios externos [B188]; la compuerta del laboratorio tardó 1,5–2,3 s en un repo de juguete (E7-5b), que no se generaliza. **[criterio]** Ahí el `pre-receive` corre sólo el paso de texto, rápido y sin red. Sin chequeos requeridos, la fusión automática de Renovate puede fusionar PR con pruebas fallidas [B108]: **sin protección de rama, ningún bot fusiona solo**. Y lo honesto es **declarar el límite**, no escribir que «la CI bloquea»: un `main` rojo unas horas cuesta poco; una versión publicada desde un estado no verificado, no.", "prosa"))
drop("P-13", "Lo que se unifica es el procedimiento:")
add("P-13",
 ("RL", "No hay lock común (§7). Lo que se unifica es el procedimiento:",
  "No hay lock común (§7). Se unifica el procedimiento: los tres archivos que declaran los registros de paquetes, **en el repo** —`nuget.config` con `<clear />` y mapeo [B87][B86]; `.npmrc` del proyecto con el registro y los *scopes* [B109]; índices de uv con la estrategia `first-index` y `explicit = true` para los internos, que protege sólo lo asignado a ese índice [B110]—, ninguno dependiente del usuario y cada uno con el hueco de §7.3, y la compuerta corriendo los tres comandos estrictos. El `.npmrc` del proyecto tiene la prioridad más alta de npm, pero sólo en la raíz donde se corre [B109]: en un *workspace*, el de un miembro se ignora con un aviso (npm 10.9.8, verificación del laboratorio N8 sin script versionado; Anexo F).", "prosa"),
 ("RL", "Con `.python-version` (3.12.15) en la **raíz** del repo",
  "Con `.python-version` (3.12.15) en la **raíz** y el proyecto uv en `tools/gen/`, `uv run` desde `tools/gen/` usó 3.12.14 **sin aviso**, por `requires-python` (E8-2): el archivo «único» no gobernaba al único proyecto Python. **[criterio]** Un archivo nativo por ecosistema, **donde lo busca su herramienta**: `global.json` y `.nvmrc` en la raíz; `.python-version` dentro del proyecto uv (o la raíz como *workspace* de uv [B111], al costo de un `pyproject.toml` en la raíz de una solución .NET).", "prosa"))

# ---- ajuste 5
add("P-03", ("RL", "Linux no «rompió» el código: lo hizo visible.",
  "Linux no «rompió» el código: lo hizo visible. Un contenedor, que fija el sistema operativo, además lo vuelve **reproducible** —todos ven el mismo error—, pero no lo arregla: el cp1252 falla igual adentro (E5-1). El arreglo está en los bytes del archivo.", "prosa"))
for k,op in enumerate(_p("P-04")['ops']):
    if "En capítulos que lidera ACT-OPS" in op[2]:
        _p("P-04")['ops'][k]=(op[0],op[1],op[2].replace("En capítulos que lidera ACT-OPS, ACT-ARQ decide la estrategia de imagen (§8) y el alcance de SBOM y procedencia (§9); ACT-OPS la implementa (§11.4).","ACT-ARQ decide además la imagen (§8) y el alcance de SBOM y procedencia (§9), que implementa ACT-OPS (§11.4)."),op[3])
add("P-05", ("RL", "Las tres palabras describen objetos distintos",
  "Las tres palabras describen objetos distintos y no se implican como suele suponerse. E0-5 muestra la distancia entre las dos primeras: con el mismo SDK y el mismo directorio, dos compilaciones dieron el mismo hash, aun en dos contenedores; con **otro directorio**, cambió, porque la DLL guarda la ruta del `.pdb`: compilador determinista, build no reproducible entre máquinas. Recién con `ContinuousIntegrationBuild=true` en un repo git la ruta quedó normalizada (`/_/obj/…`) y los hashes coincidieron.", "prosa"))
add("P-07", ("RL", "Corre en tres alcances: todos los archivos,",
  "Corre en tres alcances: todo, `--staged` para el hook y `--base <rama>` para un PR. En E2-3, un PR con un `.cs` en cp1252, dos BOM indebidos y un heredado editado con CRLF da cuatro violaciones y código 1; el hook rechaza el commit y `git commit --no-verify` lo saltea. Por eso la misma compuerta corre en la CI: el hook es comodidad, la CI es el árbitro ([§10](#10-compuertas-y-gobierno-del-entorno)).", "prosa"))
add("P-09", ("RL", "**Central Package Management (CPM).**",
  "**Central Package Management (CPM).** `Directory.Packages.props` con `ManagePackageVersionsCentrally=true` y `PackageVersion`; los `.csproj` referencian sin `Version` (`NU1008` si la llevan) [B85]. Con *transitive pinning*, una `PackageVersion` gobierna también a la transitiva; no permite bajar versiones (`NU1109`) y, en bibliotecas, vuelve explícitas esas transitivas en el paquete [B85] (E4-2). **CPM y lock no son alternativas**: CPM decide qué se pide; el lock registra qué se obtuvo, con hash. CPM solo no garantiza la versión pedida (E4-2: pidió 8.0.2, obtuvo 9.0.0).", "prosa"))
add("P-11", ("RL", "**El `.nupkg` no es la DLL.**",
  "**El `.nupkg` no es la DLL.** Con DLL y PDB idénticos, el `.nupkg` salió distinto: el zip guarda las fechas del disco y un `<GUID>.psmdcp` de nombre aleatorio (E6-2). **Desde .NET 11** los paquetes son deterministas por defecto, salvo las fechas, que se fijan con `DeterministicTimestamp` o `SOURCE_DATE_EPOCH` [B147]: con SDK 8 y la variable, distinto; con SDK 11 (preview.7 y RC1, la última publicada al 2026-10-07 [B62]) y la variable, idéntico (E6-2, E6-2b). **[criterio]** En SDK 8 o 10 se compara **por contenido** (DLL, PDB, `.nuspec`), no por el hash del zip.", "prosa"))
add("P-13",
 ("RL", "Ningún fabricante documenta la **build** integrada",
  "Ningún fabricante documenta la **build** integrada de los tres ecosistemas; cada uno documenta cómo agrupar sus proyectos y, a veces, cómo invocar a otro. La excepción parcial es Aspire 13, que orquesta apps .NET, JavaScript y Python para **ejecutar y publicar** —no para compilar una DLL que embeba las salidas de los otros— y cuyos Dockerfiles toman Node de `.nvmrc` y Python de `.python-version` [B167] **[no verificado]** (no ejercitado en el laboratorio). El laboratorio implementa dos diseños sobre el mismo `.csproj`.", "prosa"),
 ("RL", "**[criterio]** Las dos se fijan igual:",
  "**[criterio]** Las dos se fijan igual: cada base por digest, cada versión leída de los archivos nativos y la compuerta como prueba de que la imagen corresponde al repo. La imagen de desarrollo `FROM` la base de la CI (§8.2.6) sale por construcción **si la CI usa la imagen única**; con CI por componente, el Python de desarrollo lo instala uv y el de la CI viene de `python:3.12.15-slim`: misma versión, dos orígenes, que se declaran.", "prosa"))

# ---- ajuste 6
add("P-06",
 ("RL", "La especificación de C# admite en un identificador",
  "La especificación de C# admite en un identificador cualquier letra Unicode (`\\p{L}`, `\\p{Nl}`) [B21]. `Ç` es una letra mayúscula (`Lu`); U+FFFD, un símbolo (`So`) (E1-12). Tras la decodificación tolerante el compilador ve U+FFFD, no puede formar un token y emite `CS1056`; en un literal cualquier carácter vale, y la compilación termina bien. **Un build verde en Linux no prueba que la codificación esté bien; prueba que no hay identificadores no ASCII** **[criterio]**: sin un identificador acentuado, los textos corruptos del caso habrían llegado a producción.", "prosa"),
 ("RL", "**[interpretación]** El ciclo típico de un commit de BOM",
  "**[interpretación]** El ciclo típico de un commit de BOM en un equipo mixto: una plantilla crea el archivo con BOM, alguien lo edita en VS Code, que lo conserva, y el BOM aparece o desaparece cuando una herramienta **reescribe el archivo entero** con su default: una conversión masiva, un formateador, un generador, un hook genérico. La política (§5) declara la codificación donde todos esos programas la lean, y una compuerta la verifica.", "prosa"),
 ("RL", "`file` ayuda, pero es heurístico.",
  "`file` ayuda, pero es heurístico: en E1-13, con `file` 5.46, un cp1252 sin bytes `80–9F` salió como «ISO-8859 text», uno con esos bytes como «Non-ISO extended-ASCII text», y uno cuyos bytes no ASCII forman por casualidad UTF-8 válido —texto que ya tenía mojibake—, como UTF-8. No detecta cp1252. Y un editor que «muestra bien» el archivo ya adivinó: no es diagnóstico.", "prosa"))
add("P-07", ("RL", "`working-tree-encoding` resuelve otro problema.",
  "`working-tree-encoding` resuelve otro problema: git lo documenta para archivos que **no pueden** guardarse en UTF-8, advierte que JGit y libgit2 no lo soportan, que la conversión puede no ser reversible y que cuesta en cada checkout, y lo recomienda «sólo si no se puede guardar el archivo en UTF-8» [B36]. Para el caso no sirve: un `.cs` en cp1252 con `working-tree-encoding=CP1252` queda UTF-8 en el índice y vuelve a cp1252 en el disco, que es lo que lee el compilador, y Linux falla con el mismo `CS1056` (E2-4). Un fuente que se lee en UTF-8 se **convierte una vez**.", "prosa"))
add("P-08", ("RL", "Tres choques de integración que conviene conocer de antemano:",
  "Tres choques de integración: `global.json` exige versión completa y `.nvmrc`/`.python-version` aceptan una línea (`3.12` = «la más reciente»): **[criterio]** en CI, el parche fijado donde el ecosistema lo permite. `allowPrerelease` vale `true` fuera de Visual Studio y depende del IDE adentro: `false` evita que terminal e IDE elijan SDK distintos [B56]. Y la build .NET que invoca `npm` o `python` usa los del `PATH`, que `global.json` no cubre (E8-3).", "prosa"))
add("P-12",
 ("RL", "Si el hook ejecuta una cosa y la CI otra, divergen,",
  "Si el hook ejecuta una cosa y la CI otra, divergen: verde en la máquina y rojo en el PR, sin poder reproducirlo. Las herramientas empujan a lo mismo: pre-commit indica correr su configuración en la CI [B180], y las acciones de *setup* de GitHub leen la versión de los **mismos** archivos del repo (`global-json-file`, `node-version-file`, `required-version` de uv) [B181]. La compuerta del laboratorio (`Examples/N7-compuertas-y-gobierno/compuerta/compuerta.sh`) tiene tres pasos, uno por capítulo:", "prosa"),
 ("RL", "El hook `pre-commit` aborta el commit si falla",
  "El hook `pre-commit` aborta el commit si falla y se saltea con `--no-verify` [B175]. Vive en `.git/hooks`, que **no se versiona**; `core.hooksPath` apunta git a una carpeta versionada (`.githooks/`), y cada clon ejecuta **una vez** `git config core.hooksPath .githooks` [B37][B175]. En E7-1, tras clonar, un archivo en cp1252 entra sin aviso; con el hook activo, se rechaza; con `--no-verify`, entra. **El hook es para el desarrollador** (el error a los diez segundos y no a los diez minutos en el PR), nunca la única defensa.", "prosa"))

# ---- ajuste 7
add("P-03", ("RL", "Un equipo mantiene un sistema .NET heredado de una organización.",
  "Un equipo mantiene un sistema .NET heredado de una organización: lo desarrolla con Visual Studio en Windows y lo compila también en Linux y en contenedores de desarrollo (devcontainers) Linux. Unos cien archivos `.cs` y `.razor` estaban guardados en Windows-1252 (cp1252). En Windows compilaban y se veían bien. En Linux, un proyecto de servicios no compilaba —un identificador que empezaba con una mayúscula acentuada daba un error del compilador— y, en los que compilaban, los acentos aparecían como `?`. La corrección fue convertir los cien archivos a UTF-8 con BOM, que en Windows no cambió nada visible.", "prosa"))
add("P-09",
 ("RL", "**PEP 751 (`pylock.toml`)** está *Final*",
  "**PEP 751 (`pylock.toml`)** está *Final* (resuelta el 2025-03-31) y su especificación vive en packaging.python.org [B100][B101]. Al 2026-10-07, uv la exporta y conserva `uv.lock` como formato propio [B99]; pip 26.2.1 instala desde `pylock.toml` y tiene `pip lock`, ambos **experimentales**, con un lock que vale sólo para la plataforma actual [B103] (E4-5). **[criterio]** Hoy `pylock.toml` es un formato de **intercambio**, no el reemplazo del lock de la herramienta del proyecto.", "prosa"),
 ("RL", "Fijar versiones directas y congelar el grafo son operaciones",
  "Fijar versiones directas controla la **entrada** del resolvedor; congelar el grafo guarda la **salida**; el hash agrega que el contenido no cambió aunque nombre y versión sean los mismos.", "prosa"))
add("P-11", ("RL", "CISA y agencias coautoras publicaron el 2026-07-29",
  "CISA y agencias coautoras publicaron el 2026-07-29 los «2026 Minimum Elements for a SBOM», que reemplazan a los de 2021 y agregan el **contexto de generación**: la fase en que se generó, porque el contenido cambia según ella [B157]. **[criterio]** Un SBOM del lock (antes de la build) dice lo **declarado**; uno de la salida (después), lo **entregado** (E6-6: `dotnet-CycloneDX` lista el paquete NuGet; `sbom-tool`, además los archivos de salida con hash).", "prosa"))
add("P-12", ("RL", "El caso no pide sólo una configuración correcta:",
  "El caso pide además «una mecánica» que mantenga el criterio. Los capítulos 5 a 8 dejan el entorno **declarado** en archivos del repositorio; éste se ocupa de que la declaración **se haga cumplir** todos los días y cambie sólo cuando alguien lo **decide**. Tres hallazgos lo ordenan: el hook local es una comodidad, no una compuerta (E7-1); los hooks genéricos pueden contradecir la política del repo (E7-2); y sin protección de rama la CI avisa pero no impide (E7-5).", "prosa"))

# ---- ajuste 8
add("P-05", ("RL", "Las seis, de dos formas.",
  "Las seis, de dos formas. Las capas 1 a 4 se registran sobre todo **por referencia**: el commit identifica los archivos que las declaran (`.gitattributes`, `global.json`, locks, `FROM` con digest), si existen y el árbol está limpio. Lo que el repo no declara —el SDK usado, el digest real de la imagen, la ruta, las variables— se **graba** durante la build, porque después no se puede reconstruir [B02] (A.17); ante un tercero, además, se firma (§9). *Aplica* a todo artefacto que salga de la CI; para builds locales alcanza con que el repo declare.", "prosa"))
add("P-13", ("RL", "E8-1 toma la solución y le aplica las dos políticas",
  "E8-1 aplica a la solución las dos políticas «globales» que un equipo adopta sin pensar por extensión —la corrección del caso aplicada a todo («UTF-8 con BOM para todo») y el checkout de una estación Windows con `core.autocrlf=true` y sin `.gitattributes` («CRLF para todo»)— más el heredado del caso (cp1252), y corre quince lectores de los tres ecosistemas sobre los mismos bytes:", "prosa"))

# ---- ajuste 9
add("P-05", ("RL", "Porque el commit fija los archivos que el repo versiona y nada más.",
  "Porque el commit fija sólo lo que el repo versiona; lo demás lo aporta la máquina. El diagnóstico es comparar registros por capa (E0-6, con un `diff` de dos manifiestos de capas) y buscar la **primera capa, de abajo hacia arriba**, donde difieren: si los bytes del fuente ya difieren, comparar locks es inútil. *Aplica* al primer diagnóstico de todo «en mi máquina anda»: entre dos estaciones, entre la estación y la CI o entre dos corridas de la CI.", "prosa"))
add("P-06", ("RL", "Para Roslyn es decisivo: con BOM se lee UTF-8",
  "Para Roslyn es decisivo: con BOM se lee UTF-8 en cualquier plataforma y con cualquier `CodePage`. Para Node, inocuo en módulos y dañino en datos (`fs` lo conserva, `JSON.parse` falla); para Python, inocuo en el fuente y visible en datos sin `utf-8-sig`; para git, un cambio invisible en la línea 1; para un script, peor que fatal: puede correr con otro intérprete y salir con 0. *Criterio*: el BOM se decide **por extensión y por lector**, nunca globalmente.", "prosa"))

# ---- ajuste 10
add("P-04", ("RL", "La procedencia (§9) se **produce** sólo en la CI",
  "La procedencia (§9) se **produce** sólo en la CI **[criterio]**: vale la del artefacto que se publica, que sale de ahí. En las estaciones y el devcontainer, §9 sirve para diagnosticar (metadatos embebidos) y para reconstruir un artefacto publicado y comparar hashes; una build local no demuestra nada ante un tercero.", "prosa"))
add("P-05",
 ("RL", "La flecha punteada es la única excepción al apilamiento:",
  "La flecha punteada es la única excepción al apilamiento: la imagen suele **traer** el toolchain, y la capa 4 aporta el valor de la capa 2. No por eso es su fuente de verdad: si el repo no lo declara, lo decide quien eligió la imagen, y dos imágenes oficiales dan dos compiladores distintos (E0-2).", "prosa"),
 ("RL", "La pregunta del caso se contesta leyendo esta tabla por filas:",
  "La pregunta del caso se contesta por filas: ningún mecanismo fija más de una o dos capas y casi todos dejan libre algo que se cree cubierto; por eso se lee «Qué deja libre» antes que «Qué fija».", "prosa"))

# ---- ajuste 11: §9.2.4 por debajo de 600 palabras
_k=[k for k,op in enumerate(_p("P-11")['ops']) if op[0]=='RG' and op[1].startswith("#### 9.2.4")][0]
_op=list(_p("P-11")['ops'][_k]); _t=_op[3]
for a,b in [("Lo que sigue es para el paso 8b de §12: un consumidor externo que verifique, un requisito contractual o un repositorio público.","Lo que sigue es para el paso 8b de §12 (consumidor externo que verifique, requisito contractual o repositorio público)."),
            ("**[criterio]** Una clave guardada como secreto de la CI y usada por un paso del pipeline **no** es L2,","**[criterio]** Una clave de la CI usada por un paso del pipeline **no** es L2,"),
            ("Quedan tres caminos, con su nivel declarado sin inflarlo:","Quedan tres caminos, con su nivel sin inflar:"),
            ("SLSA pide publicar las atestaciones en al menos un lugar —junto al release, junto al artefacto en su registro de paquetes, su hash en un log de transparencia— y que","SLSA pide publicar las atestaciones en al menos un lugar (junto al release, junto al artefacto o, su hash, en un log de transparencia) y que"),
            ("La DLL salió idéntica a la de otra build independiente: verificación por reconstrucción.","La DLL salió idéntica a la de otra build independiente."),]:
    assert _t.count(a)==1,a[:40]; _t=_t.replace(a,b)
_op[3]=_t; _p("P-11")['ops'][_k]=tuple(_op)
add("P-07", ("R", "POLITICA-TEXTO: 23 archivo(s) revisado(s), 0 violación(es)", "POLITICA-TEXTO: 25 archivo(s) revisado(s), 0 violación(es)", "evid"))

# ---- ajuste 12: rótulo de Windows (riesgo, C2-08)
set_new("P-15", "**Qué se copia y adónde.** A `tools/ci/`: `compuerta.sh` de `Examples/N7-compuertas-y-gobierno/compuerta/` y `check_text_policy.py`",
  A11_QUE_NEW.replace("Creados desde Windows, entran sin bit de ejecución y git ignora un hook sin él (§8.2.5):", "Creados desde Windows, entran sin bit de ejecución (§8.2.5; en un Windows real, **[no verificado]**) y git ignora un hook sin él:"))

# ---- ajuste 13: salida de A.17 = EA-1 paso 9 propuesto (evidencia-auditor/x7-ea1-propuesto/salida.txt)
for k,op in enumerate(_p("P-15")['ops']):
    if op[0]=='R' and "### A.17 Registro del entorno" in op[2]:
        n=op[2].replace("commit=3423028948a3e85b6256be72f3d2acf8fd26696b arbol_limpio=si","commit=6f6df869… arbol_limpio=si").replace("sha256 out/App.dll=68421c45…","sha256 out/App.dll=2bcec512…")
        _p("P-15")['ops'][k]=(op[0],op[1],n,op[3])

# ---- ajuste 14: el archivo termina con salto de línea
_k=[k for k,op in enumerate(_p("P-21")['ops']) if op[0]=='RG'][0]
_op=list(_p("P-21")['ops'][_k]); _op[3]=_op[3].rstrip('\n')+'\n'; _p("P-21")['ops'][_k]=tuple(_op)
