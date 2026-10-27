# ---------------- P-07 · §4 ----------------
begin("P-07")
R("El equipo del compilador fijó ese comportamiento en una prueba en abril de 2026: el *fallback* «no es UTF-8 en Windows» y «es UTF-8 en Linux/macOS» [B15].",
  "En abril de 2026 el equipo del compilador corrigió una regresión que había hecho que `GetEncoding(0)` devolviera UTF-8 en .NET aunque el sistema tuviera otra página ANSI; la prueba que agregó afirma que en Windows el *fallback* es la página ANSI real «aun cuando la opción de configuración regional UTF-8 está activada», y que en Linux y macOS, donde no hay página ANSI, es UTF-8 [B15].")
R('    E -- "Linux / macOS (o Windows con ACP UTF-8)" --> L["UTF-8 tolerante ⇒ U+FFFD<br/>literal corrupto · identificador = CS1056"]',
  '    E -- "Linux / macOS" --> L["UTF-8 tolerante ⇒ U+FFFD<br/>literal corrupto · identificador = CS1056"]\n    E -. "Windows con ACP UTF-8" .-> Q["pregunta abierta: la prueba de B15<br/>dice que sigue siendo la ANSI real"]')
R("La rama «Windows con ACP UTF-8» es una deducción de [B14], [B19] y [B22], no un experimento **[no verificado en Windows]**: con la opción beta de UTF-8 activada, una estación Windows se comportaría como Linux.",
  "Queda abierta la estación Windows con la opción beta de UTF-8 activada [B22]. Una lectura de [B19] sugiere que se comportaría como Linux; la prueba que el compilador agregó en [B15] afirma lo contrario para el compilador, que registra el proveedor de páginas de códigos antes de pedir la página ANSI. **[no verificado]** (requiere Windows). La guía no recomienda activar esa opción como remedio del caso.")
R("y con SDK 10.0.400 compila (E1-03); el mismo", "y con SDK 10.0.400 compila (E1-03). En E1-03 la falla aparece con el servidor de compilación (`VBCSCompiler`) recién arrancado, desaparece si el servidor ya compiló antes un archivo con *fallback*, y no aparece con `-p:UseSharedCompilation=false`, que compila sin servidor; el mismo")
LINE_REPLACE("| Razor (generador) |", "| Razor (generador) | correcto | literal y HTML → U+FFFD, sin error; identificador → `RZ1005`/`CS1056` | correcto | **[no verificado]** (no medido) | no documentado | E1-04 |")
R("| Node `require`/`import` | correcto | U+FFFD, sin error |", "| Node `require`/`import` | correcto | literal → U+FFFD, sin error; identificador → `SyntaxError` |")
R("- **Nadie falla ruidosamente ante cp1252 salvo Python.** Roslyn falla sólo si cae en un identificador; Node y Razor nunca.",
  "- **Sólo Python falla siempre ante cp1252.** Roslyn, Razor y Node fallan sólo si el carácter cae en un identificador (`CS1056`, `RZ1005`, `SyntaxError`); en literales y en HTML corrompen sin error (E1-01, E1-04, E1-05).")
R("Por contexto: en CTX-NET el riesgo es el cp1252 heredado y los literales multilínea; en CTX-NODE, el BOM en JSON leídos con `fs`; en CTX-PY, `open()` sin `encoding=`; en CTX-POLI se suman todos,",
  "Por contexto: en CTX-NET (sólo .NET) el riesgo es el cp1252 heredado y los literales multilínea; en CTX-NODE (sólo Node.js), el BOM en JSON leídos con `fs`; en CTX-PY (sólo Python), `open()` sin `encoding=`; en CTX-POLI (los tres en un repo) se suman todos,")
R("`file` ayuda, pero es heurístico: informa «ISO-8859 text» para cp1252 y Latin-1 mientras no aparezca ningún byte `80–9F`, y «Non-ISO extended-ASCII text» si aparece (E1-13).",
  "`file` ayuda, pero es heurístico. En E1-13, con `file` 5.46, un cp1252 sin bytes `80–9F` salió como «ISO-8859 text» y uno con esos bytes como «Non-ISO extended-ASCII text»; y un cp1252 cuyos bytes no ASCII forman por casualidad UTF-8 válido —texto que ya tenía mojibake— sale como UTF-8 (E1-13). No es un detector de cp1252.")
APPQ("¿Alcanza con que compile en Linux", " *Aplica* en ESC-02 (Linux) y ESC-05 (CI): un verde no cierra el diagnóstico de codificación.", "### 4.6", "### 4.7")
APPQ("¿Alcanza con `-p:CodePage=1252`", " *Aplica* sólo como paliativo mientras se prepara la migración de §5.2.6; *no aplica* a un árbol mixto. Con SDK 8, `-p:UseSharedCompilation=false` evita el `CS2016` (E1-03).", "### 4.6", "### 4.7")
APPQ("¿Un contenedor resuelve el problema?", " *Aplica* cuando se propone el devcontainer (ESC-04) como solución al caso.", "### 4.6", "### 4.7")
END_OF_SECTION_APPEND("### 4.6 Preguntas guía", "### 4.7", """**Un compañero en Windows dice que el `.razor` heredado «se ve bien», y en la CI Linux esa pantalla muestra `?` sin ningún error de compilación. ¿Qué pasa y cómo lo confirmás?**
El archivo está en cp1252 y los acentos caen en texto HTML o en literales: Razor los decodifica como U+FFFD sin fallar (E1-04), y la salida los muestra como `?` o `�`. Se confirma por bytes, no con el editor: `iconv -f UTF-8 -t UTF-8` falla en el primer byte inválido (§4.5). Si el acento cayera en un identificador, la CI habría fallado con `RZ1005` o `CS1056`. *Aplica* a todo `.razor`, `.cshtml` o `.cs` heredado que compila en Linux y muestra texto roto.""")
BEFORE_SECTION_END("### 4.8 Plantilla", """### 4.9 Práctica

1. **Predecí antes de correr.** Antes de E1-01, anotá cuál de estas variantes compila en Linux y qué imprime el literal: cp1252 con el acento sólo en el literal; cp1252 con un identificador `Çaudal`; UTF-8 sin BOM. Compará con `Examples/N1-codificacion-y-finales-de-linea/salidas/e1-roslyn-sdk8.txt`. *Respuesta esperada*: compilan la primera, que imprime `Atenci�n`, y la tercera, que imprime bien; la segunda falla con `CS1056` (§4.2.2).
2. **Diagnosticá por bytes.** Con `work/` generado, corré `e1-diagnostico.sh` y armá una tabla archivo → ¿BOM? → ¿UTF-8 válido? → cantidad de CR. *Respuesta esperada*: la clasificación de `salidas/e1-diagnostico.txt`.""")

# ---------------- P-08 · §5 ----------------
begin("P-08")
R("El fix del caso convirtió cien archivos", "La corrección del caso convirtió cien archivos")
R("cumplirse igual en ESC-01 a ESC-05.", "cumplirse igual en los cinco escenarios (ESC-01 a ESC-05: Windows con Visual Studio, Linux, WSL 2, devcontainer y CI).")
# ítem 3 (se verifica contra E2-8 más abajo)
P08_3_OLD = "(la de `dotnet/runtime` y la base que propone GitHub [B41])"
P08_3_NEW = "(la base que propone GitHub [B41], y la que declaraban al 2026-10-07 seis repositorios de `dotnet/*` relevados —`runtime`, `roslyn`, `aspnetcore`, `sdk`, `msbuild` y `eShop`— con `eol` sólo para `.sh` y, en algunos, `.cmd`, `.bat` y `.sln`; E2-8)"
R(P08_3_OLD, P08_3_NEW)
LINE_REPLACE("**[criterio]** Para un equipo que construye en Windows y en Linux a la vez, la segunda.", "**[criterio]** Las dos dejan el índice en LF, así que ninguna produce commits de EOL (E2-1); lo que cambia es el disco de Windows. La segunda conviene cuando el equipo tiene literales multilínea de C# o datos leídos sin traducción cuyo contenido importa en las pruebas: con CRLF en la estación y LF en la CI, **la misma prueba da distinto** en las dos (§4.2.5). Si no los tiene, la primera es igual de válida, y es la que usan los repositorios del fabricante relevados. En las dos, las excepciones las exige el consumidor del archivo: `*.cmd` y `*.bat` con CRLF para `cmd.exe`, `*.sh` con LF obligatorio. Visual Studio declara soportar `end_of_line` [B45], así que trabajar con LF en Windows no debería requerir configuración local **[no verificado]** (requiere Windows). Las plantillas de esta guía (A.2) usan la segunda.")
R("La decisión real es **dónde va BOM**, y se toma por el lector más estricto de cada tipo de archivo (E2-5, E8-1):",
  "La decisión real es **dónde va BOM**. En una parte de los archivos la toma un lector, que falla con la opción equivocada (E2-5, E8-1). En la familia .NET ningún lector decide —Roslyn y Razor leen UTF-8 con y sin BOM (§4.2.4)— y lo que se elige es una **convención del equipo**, que tiene que quedar declarada igual:")
L = lines()
a = [i for i, l in enumerate(L) if l == "| Tipo de archivo | Política | Por qué | Evidencia |"]
b = [i for i, l in enumerate(L) if l.startswith("| Lock files | UTF-8 sin BOM, LF, **sin exigir salto final**")]
if len(a) == 1 and len(b) == 1 and b[0] - a[0] == 12:
    L[a[0]:b[0] + 1] = """| Tipo de archivo | Política | Lo decide | Por qué | Evidencia |
|---|---|---|---|---|
| `*.sh`, scripts con shebang | UTF-8 **sin** BOM, **LF obligatorio** | un lector: el kernel y el shell | Con BOM, `execve` falla o el script corre con otro intérprete; con CRLF no arranca | E2-5, E1-11, [B12] |
| `*.json` (incl. `package.json`, `appsettings.json`) | UTF-8 sin BOM | un lector: `JSON.parse`, `json.load`, `JsonDocument.Parse(bytes)` | Fallan con BOM; `require()` y `File.ReadAllText` lo toleran | E2-5 |
| `*.py`, `pyproject.toml` | UTF-8 sin BOM | un lector: `tomllib` | El intérprete lo tolera, pero `tomllib` falla con BOM; PEP 8 pide UTF-8 sin declaración | E2-5, [B34] |
| `*.ps1` | UTF-8 **con** BOM si el equipo usa Windows PowerShell 5.1 y hay texto no ASCII | un lector: Windows PowerShell 5.1 | Lee un script sin BOM como ANSI; PowerShell 7 usa UTF-8 sin BOM | [B54] |
| `*.cmd`, `*.bat` | UTF-8 sin BOM, **CRLF** | un lector para el CRLF (`cmd.exe`); convención para el BOM | Convención de repositorios de referencia; «sin BOM» es **[criterio]** | E2-6 |
| `*.js`, `*.ts`, `*.css`, `*.md`, `*.yml` | UTF-8 sin BOM, LF | convención (Node, Prettier [B53]) | Una plantilla web del SDK trae un `.js` con BOM: se normaliza | E2-6 |
| `*.cs` | UTF-8; **con o sin** BOM, una sola de las dos, **declarada** | convención del equipo | El compilador no necesita BOM, pero con BOM el archivo queda a salvo de `CodePage` y de la página ANSI de cada máquina (§4.2.3); `dotnet format` hace cumplir cualquiera de las dos; `dotnet new console` crea `Program.cs` **con** BOM (SDK 8 y 10) y las plantillas web, `.cs` sin BOM; los repositorios del fabricante difieren (`dotnet/roslyn` y `dotnet/eShop` con BOM, `dotnet/aspnetcore` sin) | E2-6, E2-8 |
| `*.razor`, `*.cshtml` | UTF-8 **con** BOM | convención: las plantillas | Las plantillas web del SDK 8 y 10 los crean así (10 de 10 y 12 de 12 `.razor`); pedir lo contrario obliga a corregir cada archivo nuevo | E2-6 |
| `*.sln` | UTF-8 **con** BOM | convención: la CLI | `dotnet sln add` repone el BOM aunque se lo quiten | E2-6 |
| `*.csproj`, `*.props`, `*.targets`, `*.slnx` | UTF-8; **con o sin** BOM, la misma convención que `*.cs` | convención del equipo | `dotnet new console` crea el `.csproj` **con** BOM y las plantillas web, sin; la CLI no les agrega BOM al editarlos; los repositorios del fabricante difieren (`dotnet/sdk` con BOM, `dotnet/msbuild` y `dotnet/runtime` sin); desde .NET 10, `dotnet new sln` crea `.slnx` [B55] | E2-6, E2-8 |
| Lock files | UTF-8 sin BOM, LF, **sin exigir salto final** | la herramienta que los escribe | NuGet escribe `packages.lock.json` sin salto final; un hook que lo agrega pelea con la herramienta | E7-2, E8-1, EA-1 |""".split("\n")
    setlines(L); LOG.append(("P-08", "tabla 5.2.3", True, ""))
else:
    LOG.append(("P-08", "tabla 5.2.3", False, f"{a} {b}"))
LINE_REPLACE("**[criterio] Para `*.cs`.** En un repositorio nuevo,", """**[criterio] Para la familia .NET (`*.cs` y los archivos de proyecto).** Como ningún lector decide, se elige según el estado del repositorio y se declara; lo inaceptable es no declarar, porque entonces cada editor decide y vuelven los commits de BOM.

- **Repositorio nuevo**: UTF-8 **sin** BOM (variante A de la plantilla). EditorConfig desaconseja `utf-8-bom` [B43] y `dotnet format` corrige lo que traigan las plantillas. El costo: el `Program.cs` y el `.csproj` que crea `dotnet new console` llegan con BOM y hay que normalizarlos **antes del primer commit**; la compuerta los señala (EA-1).
- **Heredado todavía en cp1252**, el que va a correr la migración de §5.2.6: elegir A o B **antes** del commit de política, porque la migración produce de una vez lo que diga `.editorconfig`. Sin otra razón, A; con BOM (B) si durante la transición alguna parte se va a compilar con `CodePage`.
- **Heredado ya convertido a UTF-8 con BOM**, como el del caso: `utf-8-bom` para `*.cs` (variante B). Cumple lo mismo, protege cada archivo aunque alguien fije `CodePage` y evita un segundo commit masivo sólo para quitar firmas.

`*.razor`, `*.cshtml` y `*.sln` van con BOM en las dos variantes, porque las herramientas del SDK lo reponen.""")
AFTER("| Herramienta existente | Qué cubre | Límite |\n|---|---|---|", "\n| editorconfig-checker 4.0.2 [B201] | Lee el mismo `.editorconfig` para todas las extensiones: no UTF-8, BOM distinto del `charset` resuelto y fin de línea incorrecto; binarios para Windows, paquetes de npm y PyPI e imagen de contenedor (E2-7) | Revisa el **working tree**, no el índice; su detector puede informar `windows-1252` como `iso-8859-1` [B201]; no da el diagnóstico «¿cp1252?»; como hook del framework pre-commit no se probó |")
AFTER("| `git ls-files --eol` | EOL en índice y disco, atributo efectivo | No mira codificación ni BOM |", "\n\n**[criterio]** La guía mantiene su verificador porque mira el **índice** —lo que se commitea— y da el diagnóstico «¿cp1252?». Necesita `python3` y el paquete `EditorConfig==0.17.1` en cada lugar donde corre (A.11). Un equipo que prefiera no mantener un script puede armar el paso de texto con editorconfig-checker sobre un clon limpio en la CI y `dotnet format whitespace --verify-no-changes` para los `.cs`, con la misma regla de una sola compuerta en hook y CI (§10.2.2).")
R("    Note over R: fusionar con merge commit: el SHA tiene que sobrevivir", "    Note over R: un PR por commit (cualquier estrategia de fusión) o un PR con merge commit: se lista el SHA que quedó en main")
R("   # tools/migrar-a-utf8.sh (E2-2), por cada archivo que git considera texto:", "   # Invocación (desde la raíz, con la política ya commiteada): tools/migrar-a-utf8.sh CP1252 [pathspec...]\n   # Requiere bash, iconv, git y el CLI editorconfig (E2-2). Por cada archivo que git considera texto:")
R("5. **Refrescar los working trees.** Los archivos en disco siguen con CRLF hasta el próximo checkout; `git rm -rq --cached . && git reset -q --hard` los rematerializa. Cada desarrollador lo hace una vez.",
  """5. **Refrescar los working trees.** Los archivos en disco pueden seguir con CRLF hasta el próximo checkout. Cada desarrollador lo hace una vez, **con el árbol limpio y después de traer la migración**: `git reset --hard` sobrescribe los archivos con la versión del commit [B204], y un cambio sin commitear se pierde sin aviso.

   ```bash
   git diff --quiet && git diff --cached --quiet \\
     || { echo "commiteá o guardá con git stash antes de seguir" >&2; exit 1; }
   git pull --ff-only                               # trae los commits de política y migración
   git rm -rq --cached . && git reset -q --hard     # rematerializa el disco con la política
   ```

   Si `git ls-files --eol` ya muestra en disco lo que pide la política (`w/lf`, y `w/crlf` en `.cmd` y `.bat`), el paso no hace falta.""")
R("Un `--amend`, un rebase o un *squash merge* cambian el SHA y rompen el aislamiento: el PR de migración se fusiona con merge commit **[criterio]**.",
  "El SHA listado tiene que ser el que quedó en `main`: un `--amend` o un rebase posteriores lo cambian. La fusión por *squash* funciona si cada commit va en su propio PR —política, migración, `.git-blame-ignore-revs`— y el SHA se toma del *squash* ya fusionado: con git 2.47.3, `blame` vuelve a atribuir las líneas a sus autores (E2-2). Lo que el *squash* rompe es juntar los tres en un PR: los aplasta en uno y la verificación mecánica deja de aplicarse a un commit sólo mecánico **[criterio]**.")
BEFORE("#### 5.2.7 `working-tree-encoding` o convertir", """```yaml
# §5.2.6 como contrato, para agentes y revisores.
entradas:
  repositorio: clon con las ramas abiertas fusionadas o identificadas
  politica: .editorconfig y .gitattributes decididos (§5.2.3, A.1, A.2)
  codificacion_origen: CP1252
salidas:
  - "commit 1: política (.editorconfig, .gitattributes, compuerta)"
  - "commit 2: migración mecánica (tools/migrar-a-utf8.sh CP1252)"
  - "commit 3: .git-blame-ignore-revs con el SHA del commit 2 tal como quedó en main"
validaciones:
  - comando: tools/verificar-commit-mecanico.sh <sha-commit-2> CP1252
    esperado: "0 con cambio de contenido"
  - comando: python3 tools/check_text_policy.py
    esperado: "0 violación(es)"
  - comando: git diff --quiet && git diff --cached --quiet   # en cada estación, antes del paso 5
    esperado: código de salida 0
```

> **Desde Windows.** La migración la ejecuta una sola persona (ACT-ARQ); el resto sólo hace el paso 5, que es git puro. Los tres scripts necesitan `bash`, `iconv`, `git` y el CLI `editorconfig` (`pip install EditorConfig==0.17.1`), o la imagen de `Examples/N2-politica-de-texto-y-remediacion/tools/Dockerfile`, que los trae. Desde Windows: esa imagen con Docker Desktop montando el clon, o Git Bash con Python, el paquete y un `iconv` disponible **[no verificado]** (requiere Windows).

""")
AFTER("| ESC-05 CI | El árbitro: la compuerta en modo `--base` y `dotnet format whitespace --verify-no-changes`. |", "\n\nPor contexto: en CTX-NET (sólo .NET), el BOM de `.cs` y `.csproj` es convención y se elige por estado del repositorio (§5.2.3); en CTX-NODE y CTX-PY no hay excepciones de BOM: todo sin BOM y LF; en CTX-POLI (los tres), la tabla completa de §5.2.3, con las excepciones al final del `.editorconfig` (§11.2.2).")
SPLITQ("### 5.6 Preguntas guía", "### 5.7")
R("Para Razor, con BOM: es lo que producen las plantillas y lo que declara `dotnet/aspnetcore`. Para C#, cualquiera, pero una sola y declarada. *Aplica*: repositorio nuevo → sin BOM; heredado ya convertido con BOM, como el del caso → declarar `utf-8-bom` para `*.cs` y no tocar más.",
  "Para Razor, con BOM: es lo que producen las plantillas y lo que declara `dotnet/aspnetcore`. Para C# y los `.csproj`, ningún lector decide: es convención del equipo, una sola y declarada. *Aplica*: repositorio nuevo → sin BOM, normalizando lo que crea `dotnet new`; heredado todavía en cp1252 → la variante que se declare antes de migrar; heredado ya convertido con BOM, como el del caso → `utf-8-bom` para `*.cs` y no tocar más.")
R("`.sln` con BOM porque la CLI lo repone; `.csproj` y `.slnx` sin.", "`.sln` con BOM porque la CLI lo repone; `.csproj`, `.props` y `.slnx`, con la misma convención que `.cs`.")
R("y fusión sin squash (§5.2.6).", "y el `.git-blame-ignore-revs` con el SHA que quedó en `main` (§5.2.6).")
APPQ("¿Cómo detecto en un PR", " *Aplica* a todo PR en la CI (ESC-05) y a cada commit si el hook está activo.", "### 5.6", "### 5.7")
APPQ("¿Cuándo `working-tree-encoding` y cuándo convertir?", " *Aplica* a archivos que consume un programa que sólo lee otra codificación; *no aplica* al caso.", "### 5.6", "### 5.7")
END_OF_SECTION_APPEND("### 5.6 Preguntas guía", "### 5.7", """**Tu equipo va a migrar el heredado del caso, todavía en cp1252, y la mitad trabaja con Visual Studio. ¿Declarás `*.cs` con o sin BOM antes de correr la migración?**
Cualquiera de las dos, pero decidida antes del commit de política, porque la migración produce de una vez lo que diga `.editorconfig`. Ningún lector de .NET falla por una u otra (§4.2.4). Sin BOM sigue la recomendación de EditorConfig y obliga a normalizar lo que crea `dotnet new console`; con BOM protege cada archivo si durante la transición alguien compila con `CodePage` (§4.2.3). *Aplica* a todo heredado de CTX-NET o CTX-POLI antes del paso 2 de §12.""")
R("el PR de migración fusionado con squash;", "un `.git-blame-ignore-revs` con un SHA que no está en `main`; política, migración e ignore-revs aplastados en un solo *squash*;")
BEFORE_SECTION_END("### 5.8 Plantilla", """### 5.9 Práctica

1. Antes de mirar la salida de E2-2, decí cuántos archivos debería reportar `verificar-commit-mecanico.sh` con cambio de contenido y qué pasa si la migración además cambia `=> 42` por `=> 43`. *Respuesta esperada*: cero; con el cambio funcional, `CONTENIDO src/Sensor.cs` y código 1 (§5.2.6, paso 4).
2. Con la tabla de §5.2.3, escribí la política de un repo con `.sh`, `appsettings.json`, `.razor` y `.cs` heredados ya convertidos con BOM. Compará con A.1, variante B. *Respuesta esperada*: `[*]` sin BOM y LF; `.razor` y `.cs` con `utf-8-bom`; `.sh` sin BOM y LF también en `.gitattributes`.""")

# --- Verificación fáctica del ítem 3 de P-08 contra su propia evidencia (E2-8) ---
E28 = "<workspace>/LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Examples/N2-politica-de-texto-y-remediacion/salidas/e8-repos-de-referencia.txt"
eol_pat = set()
for l in open(E28, encoding="utf-8"):
    if "eol=" in l and not l.startswith("*"):
        eol_pat.add(l.split()[0])
    elif "eol=" in l:
        eol_pat.add(l.split()[0])
otros = sorted(p for p in eol_pat if p not in ("*.sh", "*.cmd", "*.bat", "*.sln"))
if otros:
    # la afirmación «con eol sólo para .sh y, en algunos, .cmd, .bat y .sln» es falsa: se revierte el ítem
    R(P08_3_NEW, P08_3_OLD, note="revert")
    LOG.append(("P-08", "ítem 3 REVERTIDO", True, "E2-8 muestra eol también en: " + ", ".join(otros)))
