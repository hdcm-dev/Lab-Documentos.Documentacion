# Informe — Implementador ingenuo (lector sin contexto) · Ciclo 1

- Artefacto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (1.0.0-borrador, 3060 líneas)
- Fecha: 2026-10-07
- Rol: desarrollador que usa Visual Studio en Windows, nunca usó contenedores. Pregunta: ¿puedo aplicar la guía a mi solución sin preguntar nada?
- Lectura: a ciegas (no se leyeron informes de otros especialistas del ciclo).
- Receta seguida de punta a punta: §5.2.6 «Migrar un código heredado» con A.1/A.2 y la compuerta, sobre un heredado sintético propio (cp1252 + CRLF, `.cs`, `.razor`, `.sln` con BOM, `.csproj`), más una segunda estación «del desarrollador» con trabajo sin commitear. Además, la activación del hook de A.11 en una estación sin Python.
- Evidencia: scripts y salidas en `evidencia-lector-sin-contexto/` (`receta.sh`, `hook.sh`, `hook2.sh`, `salida-*.txt`). Las corridas usan la imagen del laboratorio `lab-n2-texto:local` y `mcr.microsoft.com/dotnet/sdk:8.0` (8.0.425) **como sustituto** de una estación Windows: lo que se mide es el comportamiento de los scripts y de git, no el de Windows.

## Hallazgos

### lector-sin-contexto-01 · S2 · E1 — El paso 5 de la migración borra el trabajo sin commitear del desarrollador

- Ubicación: §5.2.6, paso 5 (línea 719); repetido en B.1 (línea 2651).
- Ancla: «`git rm -rq --cached . && git reset -q --hard` los rematerializa. Cada desarrollador lo hace una vez.» No hay ninguna condición previa (commitear o guardar con stash, hacer el pull antes).
- E1 (`receta.sh` → `salida-receta.txt`): en el clon del desarrollador con `src/Program.cs` modificado y sin commitear, `git pull` aborta («Please commit your changes or stash them before you merge. Aborting»); el desarrollador sigue con el paso 5 tal como está escrito y obtiene `status=''` y «el trabajo sin commitear SE PERDIÓ». Además el clon queda **sin** el commit de migración, porque el pull había abortado.
- Impacto: es la instrucción que la guía le da a **cada** desarrollador. Es una pérdida de datos que no se puede deshacer, con un comando que el lector ingenuo copia sin entenderlo.
- Corrección propuesta: anteponer las condiciones previas («árbol limpio: commit o `git stash`; `git pull` del commit de migración») y un chequeo `git diff --quiet && git diff --cached --quiet || exit 1`. Alternativa: decir cuándo el paso no hace falta, porque el pull ya rematerializa los archivos cuyo índice cambió. Repetir la advertencia en B.1.

### lector-sin-contexto-02 · S2 · E1 — En ESC-01 el hook bloquea todos los commits por requisitos que la guía no declara

- Ubicación: §10.4, fila ESC-01 (línea 1753); A.11 (líneas 2480–2500); B.1 (líneas 2644 y 2648); §3.6 «Por escenario», fila ESC-01 (línea 358).
- Ancla: «El hook necesita un intérprete de `sh` (Git for Windows trae uno)». Es el único requisito que se le declara a la estación Windows. La compuerta completa que A.11 señala (`Examples/N7-…/compuerta/compuerta.sh`) es `#!/usr/bin/env bash`, llama a `python3 "$DIR/check_text_policy.py"`, y ese verificador importa `editorconfig` (`pip install EditorConfig==0.17.1`). La guía no dice nada de `python3`, del paquete de PyPI ni de que el `.py` tiene que estar al lado de la compuerta.
- E1 (`hook.sh` → `salida-hook.txt`, estación sin `python3`): un commit de un `.cs` UTF-8 válido queda **rechazado** con «`python3: command not found` … COMPUERTA [FALLA] texto: la política de .editorconfig/.gitattributes no se cumple», exit 1. E1 (`hook2.sh` → `salida-hook2.txt`, con Python pero copiando sólo `compuerta.sh`): «can't open file '…/tools/ci/check_text_policy.py'», con el mismo FALLA de política.
- Impacto: el desarrollador ve que su commit viola «la política», cuando lo que falta es una herramienta. Lo más probable es que apague el hook (`--no-verify` o borrando `core.hooksPath`). Tampoco puede cumplir el ítem de B.1 «Corro la compuerta antes del push»: no hay ningún comando para Windows.
- Corrección propuesta: una lista explícita de prerrequisitos de la estación (bash de Git for Windows; Python 3 con `EditorConfig==0.17.1`; los archivos que hay que copiar a `tools/ci/`) y el comando exacto para correr la compuerta desde Git Bash, rotulado **[no verificado en Windows]** si no se puede probar. Otra opción: que la compuerta distinga «falta herramienta» de «violación de política» en el mensaje.

### lector-sin-contexto-03 · S2 · E1 — Las plantillas «verificadas juntas» instalan un hook que acepta cualquier cosa

- Ubicación: Anexo A, introducción (línea 2189: «verificadas juntas»); A.11 (líneas 2490–2498); `Examples/A-plantillas/repo/tools/ci/compuerta.sh`.
- Ancla: el esqueleto es `set -eu` + `echo "compuerta: …"`, que sale con 0. La guía lo rotula «(esqueleto)», pero `A-plantillas/repo/.githooks/pre-commit` lo invoca como si fuera la compuerta.
- E1 (`hook.sh` → `salida-hook.txt`, caso a): copio `A-plantillas/repo` (hook + esqueleto) y activo `core.hooksPath`. Un `.cs` en **cp1252** queda «commit ACEPTADO (exit 0)».
- Impacto: el lector ingenuo copia el repo de plantillas, que la guía presenta como «verificado», y cree tener la red del caso cuando no detecta nada. Contradice el criterio de §10.2.2: «una compuerta que saltea en silencio existe en el papel».
- Corrección propuesta: que el esqueleto falle (`echo "reemplazar por la compuerta completa" >&2; exit 1`), o que A-plantillas traiga la compuerta completa con su `check_text_policy.py`. Decir en A.11, en una línea, qué se copia y adónde.

### lector-sin-contexto-04 · S2 · E2+E1 — §6.4 promete que una estación con otro parche «no queda bloqueada», y con `rollForward: disable` sí queda

- Ubicación: §6.4, «[criterio] La elección de `rollForward`» (línea 933), frente a §6.2.2 (línea 883), §3.3 (línea 291) y A.3 / B.1 (línea 2645).
- Ancla: «`disable` en el repo … el modo estricto se activa sólo en CI (§7), así que una estación con otro parche no queda bloqueada para trabajar». Pero §3.3 dice: «Hace cumplir: el CLI falla sin ese SDK». Y §6.2.2: «`dotnet` falla **antes de compilar** con `A compatible .NET SDK was not found`».
- E1 (`salida-rollforward.txt`): `global.json` con 8.0.424 y `disable` en una estación que tiene 8.0.425 da `dotnet build` → exit 145, «A compatible .NET SDK was not found. Requested SDK version: 8.0.424». Además, el paso de toolchain de la compuerta (que corre en el hook) compara la versión **exacta**.
- Impacto: no sé si tengo que instalar el parche exacto o no. B.1 dice que sí; §6.4 me da a entender que no. La frase mezcla el modo estricto de NuGet (capa 3) con la selección del SDK (capa 2).
- Corrección propuesta: reescribir la frase. Con `disable`, toda estación necesita el SDK exacto, y lo que se limita a la CI es `RestoreLockedMode`. Si se quiere no bloquear estaciones, la vía es `latestPatch` más el registro en CI (que es la otra opción que el mismo párrafo ya da).

### lector-sin-contexto-05 · S3 · E2 — Mi caso (heredado todavía en cp1252) no está en la elección de variante de `*.cs`

- Ubicación: §5.2.3 «[criterio] Para `*.cs`» (línea 661); §5.6 (línea 797); paso 2 de §12 (línea 2173); A.1, variante B (líneas 2221–2223).
- Ancla: las dos ramas son «repositorio nuevo → sin BOM» y «heredado que **ya** se convirtió a UTF-8 con BOM → `utf-8-bom`». No hay una rama para el heredado que **todavía** está en cp1252, que es justamente el que va a correr §5.2.6.
- E1 auxiliar (`salida-receta.txt`): con A.1 sin tocar, `migrar-a-utf8.sh` deja `Sensor.cs` en UTF-8 **sin** BOM. La rama se puede deducir, pero no está dicha.
- Impacto: es una pregunta que tengo que hacer antes del commit 1. Dos implementadores pueden elegir distinto, y el «argumento del segundo commit masivo» no aplica cuando la conversión todavía no se hizo.
- Corrección propuesta: agregar la tercera rama de forma explícita: «heredado sin convertir → sin BOM, porque la migración lo produce de una vez», o la que la mesa decida.

### lector-sin-contexto-06 · S3 · E2 — La migración y el laboratorio no dicen cómo se corren desde Windows

- Ubicación: §0.4 (líneas 87–94); §5.2.6, paso 3 (líneas 706–715); §5.8 (línea 825).
- Ancla: «Todo corre en contenedores … Con Docker alcanza» y `cd … && ./correr-todo.sh`. El paso 3 muestra un **extracto** del script (falta la invocación `tools/migrar-a-utf8.sh CP1252 [pathspec]`, con su argumento obligatorio) que depende de `bash`, `iconv` y del CLI `editorconfig`. §5.8 remite a un `Dockerfile` sin decir cómo usarlo contra mi repositorio. Los comandos del README de N2 usan `--user "$(id -u):$(id -g)"` y rutas POSIX.
- Impacto: un desarrollador de Visual Studio que nunca usó contenedores no sabe qué instalar (¿Docker Desktop? ¿WSL? ¿Git Bash?), desde qué terminal correr la migración, ni con qué argumentos. El rol que decide la migración es ACT-ARQ, pero la receta no tiene una forma ejecutable para quien trabaja en ESC-01.
- Corrección propuesta: un recuadro «Desde Windows» con la vía mínima, por ejemplo Git Bash + Python + `pip install EditorConfig==0.17.1`, o Docker Desktop + el `docker run` equivalente con rutas de Windows, rotulado **[no verificado en Windows]**. Y mostrar en el paso 3 la línea de invocación completa.

### lector-sin-contexto-07 · S3 · C — ¿El hook corre cuando commiteo desde Visual Studio?

- Ubicación: §10.4, fila ESC-01 (línea 1753); §12 (línea 2183).
- Ancla: «el comportamiento de la integración de git de Visual Studio con `core.hooksPath` **[no verificado]**». Pero §12 afirma sin rótulo: «Visual Studio … ejecuta el hook de git».
- Nivel C: no lo puedo verificar sin Windows, así que sólo habilita una pregunta. La inconsistencia de rótulo entre §10.4 y §12 sí está a la vista.
- Pregunta: ¿se puede verificar, o al menos rotular igual en §12? Mi flujo diario es la ventana *Git Changes* de Visual Studio, no la terminal.

## Revisadas y bien

1. **La receta de §5.2.6 funciona de punta a punta sobre un heredado propio** (E1, `salida-receta.txt`). Con A.1/A.2 copiadas sin tocar y los tres scripts de N2, se convirtieron cp1252 → UTF-8, se agregó el BOM al `.razor`, se conservó el del `.sln`, `verificar-commit-mecanico.sh` dio «5 archivo(s); 0 con cambio de contenido» y la compuerta de texto dio «10 archivo(s) revisado(s), 0 violación(es)».
2. **La entrada por síntoma de §3.6** me lleva del `CS1056` / «compila en Windows y no en Linux» directo a §4 y §5, sin tener que leer la teoría de capas primero.
3. **§4.5 (diagnóstico por bytes)** se entiende sin contexto, y la advertencia «un editor que muestra bien el archivo no es diagnóstico» responde justo la objeción que haría alguien que viene de Visual Studio.

## Solicitudes de convocatoria

- Especialista en estaciones Windows / Visual Studio que verifique en una máquina Windows real los rótulos **[no verificado en Windows]** que afectan el uso diario: el hook vía *Git Changes*, `charset`/`end_of_line` al guardar archivos existentes y la presencia de `iconv`/`bash` en Git for Windows. Queda fuera del mandato de este rol y no se puede verificar en el laboratorio Linux.
