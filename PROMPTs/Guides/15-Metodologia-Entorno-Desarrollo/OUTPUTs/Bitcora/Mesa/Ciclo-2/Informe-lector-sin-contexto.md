# Informe — Implementador ingenuo (lector sin contexto) · Ciclo 2

- Artefacto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (1.0.0-rc.1, 3391 líneas), revisado como obra terminada.
- Fecha: 2026-10-09.
- Rol: desarrollador que usa Visual Studio en Windows y nunca usó contenedores. Pregunta: ¿puedo aplicar la guía a mi solución sin preguntar nada?
- Lectura: a ciegas (no se leyeron informes de otros especialistas del ciclo 2). Se leyeron `Ciclo-1/05-Aplicacion.md` (incluye la deuda D-1…D-7) y mi propio informe del ciclo 1, para no re-litigar lo cerrado.
- Receta seguida de punta a punta: el Anexo A sobre una solución .NET creada como la crea el SDK (`dotnet new sln/console/classlib` + `dotnet sln add`), heredada «ya convertida a UTF-8 con BOM» como la del caso: A.1 con la variante B descomentada, A.2, A.3, A.4, A.4b, A.5 y A.6, más A.11 «Qué se copia y adónde» al pie de la letra. Primero en una estación «Windows» y después en el clon de un compañero en Linux o en el devcontainer, y en la CI. Además, el flujo diario de Visual Studio: agregar una referencia y commitear desde *Git Changes*.
- Evidencia: `evidencia-lector-sin-contexto/` (`receta-a11.sh` → `salida-receta-a11.txt`; `hook-lock-sin-stage.sh` → `salida-hook-lock-sin-stage.txt`). Las corridas usan la imagen del laboratorio `lab-n2-texto:local` (SDK 8.0.425, git 2.39.5, Python con `EditorConfig==0.17.1`). La estación «Windows» se simula con `core.fileMode=false` y archivos sin el bit de ejecución, que es lo que la guía misma dice de NTFS (§8.2.5, E5-3). **No es Windows**: se mide el comportamiento de git y de los scripts, no el de Windows.

## Hallazgos

### lector-sin-contexto-01 · S2 · E1 — Si los archivos de A.11 se copian desde Windows, el hook queda apagado sin aviso y el paso de CI de A.12 da `Permission denied`

- Ubicación: A.11, «Qué se copia y adónde» (línea 2755); A.12, los dos `run:` (líneas 2783 y 2785); §12, paso 4 (línea 2389).
- Ancla: «A `tools/ci/`: `compuerta.sh` de `Examples/N7-…/compuerta/` y `check_text_policy.py` de …. A `.githooks/`: el hook de arriba. Activación, una vez por clon: `git config core.hooksPath .githooks`». La lista no dice nada del bit de ejecución, aunque la guía ya conoce el problema: §8.2.5 dice «en NTFS git usa `core.fileMode=false` y no registra el bit → `git update-index --chmod=+x`».
- E1 (`salida-receta-a11.txt`):
  - En la estación «Windows», el índice registra `100644 .githooks/pre-commit` y `100644 tools/ci/compuerta.sh`.
  - En el clon de un compañero en Linux, con `core.hooksPath` activado, un commit de un `.cs` en cp1252 da `hint: The '.githooks/pre-commit' hook was ignored because it's not set as executable.` y entra con `rc=0`.
  - El paso de CI de A.12, tal cual (`tools/ci/compuerta.sh`), da `Permission denied` con `rc=126`.
  - Control: con `git update-index --chmod=+x tools/ci/compuerta.sh .githooks/pre-commit`, el mismo commit se rechaza con `no es UTF-8 válido (byte 0xf3 …; ¿cp1252?)`, `rc=1`.
- Impacto: la persona que arma la política es justamente la de ESC-01, que es el escenario del caso. Sigue A.11 y, sin enterarse, deja el hook apagado para todos los clones de Linux, WSL y el devcontainer, y la CI en rojo por un motivo que no es la política. Es el «falso rojo» que §10.2.2 dice evitar, y además un «falso verde» local.
- Dirección: en «Qué se copia y adónde», agregar `git update-index --chmod=+x tools/ci/compuerta.sh .githooks/pre-commit` antes del commit, con remisión a §8.2.5. El `run:` de A.12 puede invocar `bash tools/ci/compuerta.sh`, que no depende del bit, pero el hook sí lo necesita porque git lo ignora sin el bit. Va lo mismo para los scripts de `tools/` de §5.2.6, y un ítem en B.4: «¿los `.sh` nuevos entran como `100755`?».

### lector-sin-contexto-02 · S2 · E2 — Los `docker run` que el recuadro «Desde Windows» manda correr desde Git Bash tienen argumentos que Git Bash reescribe

- Ubicación: §0.4, recuadro «Desde Windows» (línea 111); los comandos de §1.2 (líneas 137–138) y los README del laboratorio (`-v "$PWD":/w -w /w`). Es la deuda **D-3** de `05-Aplicacion.md`, que sigue sin aplicarse en la rc.1.
- Ancla: «Docker Desktop con contenedores Linux, corriendo los mismos `docker run` desde Git Bash o desde una terminal de WSL 2». Lo único que el recuadro advierte es que `$PWD` y `$(id -u)` «en PowerShell no valen».
- E2:
  - *Known issues* de Git for Windows (https://raw.githubusercontent.com/git-for-windows/build-extra/main/ReleaseNotes.md, consultado el 2026-10-09): «If you specify command-line options starting with a slash, POSIX-to-Windows path conversion will kick in converting e.g. "/usr/bin/bash.exe" to "C:\Program Files\Git\usr\bin\bash.exe". When that is not desired … you need to set the environment variable `MSYS_NO_PATHCONV` temporarily».
  - MSYS2 (https://www.msys2.org/docs/filesystem-paths/, consultado el 2026-10-09): «all the arguments that look like Unix paths will get auto converted to Windows», con `MSYS2_ARG_CONV_EXCL` como exclusión.
  - `-w /w` es un argumento con esa forma, y `docker.exe` es un ejecutable nativo de Windows.
- Impacto: es la primera receta que corre quien nunca usó contenedores (§1.2 y la ruta mínima de §0.2), y la vía que se le ofrece está documentada por el propio fabricante como la que reescribe esos argumentos. El rótulo **[no verificado]** no alcanza cuando la fuente predice el fallo.
- Dirección: en el recuadro, recomendar la terminal de WSL 2 para los `docker run`, o anteponer `MSYS_NO_PATHCONV=1` desde Git Bash, citando las dos fuentes. Mantener **[no verificado]** para el resultado final.

### lector-sin-contexto-03 · S3 · E1+E2 — La variante B de A.1 cubre `*.cs` pero no los `.csproj`, y §5.2.3 dice que van juntos

- Ubicación: A.1, bloque «Variante B» (líneas 2456–2460), frente a §5.2.3, fila `*.csproj, *.props, *.targets, *.slnx` (línea 708: «la misma convención que `*.cs`») y §5.6 (línea 893).
- Ancla: la variante B descomenta sólo `[*.cs]` / `charset = utf-8-bom`.
- E1 (`salida-receta-a11.txt`, sección 1): el SDK 8.0.425 crea `App.csproj` y `Lib.csproj` con `efbbbf`. Con la variante B descomentada tal cual, la compuerta da `src/App/App.csproj: tiene BOM y .editorconfig declara charset=utf-8 (sin BOM)`, lo mismo para `Lib.csproj`, y `COMPUERTA [FALLA] texto`.
- Impacto: en el caso de la guía (heredado ya convertido con BOM), el primer commit de la política sale en rojo y la plantilla no dice qué hacer: ¿quito el BOM de los `.csproj` (lo que dice la plantilla) o amplío la sección (lo que dice §5.2.3)? La Práctica 2 de §5.9 tampoco menciona los `.csproj`.
- Dirección: que la variante B sea `[*.{cs,csproj,props,targets}]` (las llaves sí valen en `.editorconfig`, §5.2.4), o que la plantilla diga explícitamente que los proyectos se normalizan sin BOM y que §5.2.3 lo refleje. Alinear la respuesta de §5.9.2.

### lector-sin-contexto-04 · S3 · E1 — El hook da verde a un commit que la CI rechaza: el paso de grafo mira el lock del disco, no el que se commitea

- Ubicación: §10.4, fila ESC-04 (línea 1942: «Con la misma imagen que la CI, el hook da el veredicto de la CI»); §10.2.2 (líneas 1839 y 1847: alcance `--staged` para el hook); B.1, ítem 4 (línea 2908).
- Ancla: §10.2.2: «Si el hook ejecuta una cosa y la CI otra, divergen, y el desarrollador ve verde en su máquina y rojo en el PR». En la compuerta de N7, `--staged` sólo acota el paso de texto. Los pasos de toolchain y grafo corren sobre el working tree (`dotnet restore "$d" --locked-mode`).
- E1 (`salida-hook-lock-sin-stage.txt`), el flujo diario de Visual Studio: agrego `ProjectReference` App → Lib, restauro (el lock cambia en disco) y en *Git Changes* marco sólo el `.csproj`. El hook da `grafo NuGet: … coincide (--locked-mode)`, `resultado=VERDE`, y el commit entra. En el clon limpio, la misma compuerta da `error NU1004: A new project reference to Lib was found …` y `resultado=ROJO`. Es la misma imagen en los dos lados.
- Impacto: es el divorcio hook/CI que la compuerta única promete evitar, en el gesto más común del IDE (marcar un archivo y no el otro). B.1 lo pide como disciplina («commiteo manifiesto y lock juntos»), pero la guía da a entender que el hook lo vigila.
- Dirección: declarar el límite en §10.2.2 y §10.4: el alcance `--staged` es sólo del texto, y toolchain y grafo se verifican sobre el disco. O hacer que el hook falle si hay un manifiesto marcado y su lock modificado sin marcar (por ejemplo, `git diff --quiet -- '*packages.lock.json' package-lock.json uv.lock`), rotulado **[criterio]** y con un experimento. Corregir la frase de ESC-04.

### lector-sin-contexto-05 · S4 · E2 — B.2 sigue con dos variantes para `*.cs`; el resto de la guía ya tiene tres

- Ubicación: B.2, ítem 2 (línea 2918).
- Ancla: «Para `*.cs` se eligió una variante (repo nuevo sin BOM; heredado convertido con BOM) y está declarada». Frente a §5.2.3 (líneas 713–715), §5.6 (línea 890), §12 paso 2 (línea 2387) y las preguntas de A.1 (línea 2428), que ya incluyen «heredado todavía en cp1252».
- Impacto: la lista de verificación del arquitecto, que es lo que se copia a la definición de «hecho», omite justo el estado del repo que va a correr la migración. Es una incoherencia que quedó de la corrección del ciclo 1.
- Dirección: «(repo nuevo → sin BOM; heredado todavía en cp1252 → la variante decidida antes del commit de política; heredado ya convertido con BOM → `utf-8-bom`)», y extenderlo a los archivos de proyecto si prospera el hallazgo 03.

### lector-sin-contexto-06 · S4 · E1 — Las plantillas no traen `.gitignore`, y en una solución recién creada la compuerta reporta violaciones dentro de `obj/`

- Ubicación: Anexo A, introducción (línea 2424) y la lista del índice (línea 43); A.11.
- Ancla: el Anexo A enumera quince plantillas «verificadas juntas» y ninguna es `.gitignore`. Tampoco se menciona `dotnet new gitignore`.
- E1 (`salida-receta-a11.txt`): con `git add -A` sobre la solución creada por el SDK, la compuerta reporta, además de los `.csproj`, cuatro violaciones en `src/*/obj/*.csproj.nuget.g.props|targets` («tiene BOM…»). `dotnet new gitignore` (SDK 8.0.425) genera `[Bb]in/` y `[Oo]bj/` (comprobado en la misma imagen).
- Impacto: menor en un heredado que ya tiene `.gitignore`, pero quien arma un repo nuevo con el Anexo A ve rojos sobre archivos generados y no sabe si la política está mal.
- Dirección: una línea en A.11 o en la introducción del Anexo A: «la compuerta revisa lo versionado; partir de `dotnet new gitignore` (o el `.gitignore` del equipo) para que `bin/` y `obj/` no entren».

## Revisadas y bien

1. **Las correcciones de mi informe del ciclo 1 están aplicadas y se sostienen al releerlas.** El paso 5 de §5.2.6 tiene ahora la condición de árbol limpio, el `git pull --ff-only` y el criterio «si `git ls-files --eol` ya muestra… no hace falta». §6.4 dice sin ambigüedad que con `disable` una estación desalineada queda bloqueada. §5.2.3 tiene la rama «heredado todavía en cp1252». La compuerta distingue «falta `python3`» de una violación. El esqueleto de A.11 falla a propósito.
2. **Con los archivos en su lugar, la compuerta de N7 sirve tal cual para una solución .NET con los proyectos en subcarpetas** (E1, sección 3 de `salida-receta-a11.txt`): encuentra `src/App/packages.lock.json` con `git ls-files`, el toolchain da `SDK 8.0.425 = global.json`, los `n/a` de Node y Python son correctos, y un `.cs` en cp1252 se rechaza con el diagnóstico «¿cp1252?». A.4b genera el lock sólo en el ejecutable, como promete.
3. **§3.6 «Por escenario», fila ESC-01, y B.1** le dan a quien trabaja en Visual Studio una lista corta y coherente con §6.4 y A.11: qué instalar, qué activar y qué no le toca. Son lo primero que alguien de ESC-01 necesita leer.

## Solicitudes de convocatoria

- Especialista en estaciones Windows / Visual Studio, para verificar en una máquina Windows real tres cosas: (a) qué modo registra Git for Windows al agregar un `.sh` nuevo (hallazgo 01; la guía lo afirma en §8.2.5 desde E5-3, que es una simulación); (b) si `docker run … -w /w` desde Git Bash falla sin `MSYS_NO_PATHCONV` (hallazgo 02); (c) si el paso de toolchain de la compuerta compara bien en Git Bash, donde `dotnet --version` y `python3 -c print(…)` pueden emitir `\r`. Este último punto no lo puedo verificar ni como C con fuente, y queda fuera del mandato de este rol.
