# Informe — Implementador ingenuo (lector sin contexto) · Ciclo 3

- Artefacto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (1.0.0, `vigente`, 3605 líneas), revisado como obra terminada.
- Fecha: 2026-10-09.
- Rol: desarrollador que usa Visual Studio en Windows y nunca usó contenedores. La pregunta es si puedo aplicar la guía a mi solución sin preguntar nada.
- Lectura a ciegas: no leí informes de otros especialistas del ciclo 3. Leí `Ciclo-2/05-Aplicacion.md` (lo aplicado y lo que quedó abierto, §6), `Ciclo-2/01-Consolidado.md` (sólo mis ítems) y mi informe del ciclo 2, para no re-litigar lo cerrado.
- Receta seguida de punta a punta: la fila CTX-NET de §3.6 («archivos mínimos») más A.4b y A.18, aplicada sobre una solución creada por el SDK (`dotnet new sln/console/classlib`) y heredada «ya convertida con BOM», como la del caso. Pasos: A.1 con la variante B descomentada y el comentario de la variante seguido al pie de la letra; A.11 «Qué se copia y adónde», con el `chmod`; primer commit **con el hook activo**; A.12 guardado como `.github/workflows/compuerta.yml`; A.17.
- Evidencia: `evidencia-lector-sin-contexto/receta-ciclo3.sh` → `salida-receta-ciclo3.txt`. Imagen del laboratorio `lab-n2-texto:local` (SDK 8.0.425, git 2.39.5). **No es Windows**: se mide git, la compuerta y los scripts.

## Hallazgos

### lector-sin-contexto-01 · S2 · E1 — A.17 busca el digest sólo en `.github/workflows/ci.yml`, y nada en la guía ni en el laboratorio dice que el workflow se llame así: con otro nombre, el registro afirma algo falso sin fallar

- Ubicación: A.17, línea 3047 (`… .github/workflows/ci.yml | head -1`); A.12, bloque YAML (línea `name: compuerta`), que no dice con qué nombre se guarda; `Examples/N7-compuertas-y-gobierno/compuerta/ci-compuerta.yml`, línea 1; §12, validación del paso 8a.
- Ancla: A.12 empieza con `name: compuerta`. El ejemplo de N7 se titula `# .github/workflows/compuerta.yml — la CI como árbitro`. A.17 lee `ci.yml` y, si no lo encuentra, imprime `imagen=NO DECLARADA (runner sin contenedor: capa 4 en el log «Set up job»)`. El único lugar donde aparece `ci.yml` es la plantilla del laboratorio (`Examples/A-plantillas/repo/.github/workflows/ci.yml`), que la guía no nombra.
- E1 (`salida-receta-ciclo3.txt`, sección 2), con el mismo archivo en los dos casos:
  - Guardado como `compuerta.yml` (el nombre que sugieren A.12 y N7): `imagen=NO DECLARADA (runner sin contenedor: capa 4 en el log «Set up job»)`.
  - Guardado como `ci.yml`: `imagen=ghcr.io/org/imagen-ci@sha256:0000…`.
  - El script sale con 0 en los dos casos.
- Impacto: es la tercera pregunta del caso, «¿con qué se construyó?». El registro dice «runner sin contenedor» de una build que sí corrió en el contenedor, y la validación de 8a («registro sin campos vacíos») no lo detecta, porque el campo no queda vacío. Quien sigue la guía no tiene cómo enterarse. `05-Aplicacion.md` §6 punto 2 lo dejó abierto para este ciclo, así que no es algo cerrado.
- Dirección: que A.12 diga «guardar como `.github/workflows/ci.yml` (A.17 lo lee de ahí)», o que A.17 tome la ruta de una variable que falle si el archivo no existe. En cualquier caso, alinear el comentario de `ci-compuerta.yml` de N7 con ese nombre, o rotularlo como un ejemplo aparte que A.17 no lee.

### lector-sin-contexto-02 · S3 · E1 — La variante B de A.1 manda guardar con BOM «los `Directory.Build.*`», pero también cubre `Directory.Packages.props`, que está entre los archivos mínimos de CTX-NET: el primer commit sale en rojo

- Ubicación: A.1, comentario de la variante B (líneas 2554–2558); §3.6, fila CTX-NET, «Archivos mínimos»; A.5; EA-1 paso 1c (`Examples/A-plantillas/verificar.sh` L38–L47, que no copia `Directory.Packages.props`).
- Ancla: «Cubre los archivos de proyecto, que siguen la convención de *.cs (5.2.3); los Directory.Build.* de este anexo se guardan entonces con BOM». El patrón es `[*.{cs,csproj,props,targets}]`, y `Directory.Packages.props` también es `*.props`.
- E1 (`salida-receta-ciclo3.txt`, sección 1). Con los seis archivos de CTX-NET, la variante B descomentada y los dos `Directory.Build.*` con BOM, el primer commit con el hook activo da:
  - `POLITICA-TEXTO: Directory.Packages.props: falta el BOM que .editorconfig declara (charset=utf-8-bom)` y `COMPUERTA resultado=ROJO`, con `rc=1`.
  - Control: con BOM también en `Directory.Packages.props`, `17 archivo(s) revisado(s), 0 violación(es)` y `VERDE`.
- Impacto: la instrucción literal deja afuera un archivo que la misma guía manda copiar. EA-1 no lo vio porque su paso 1c no incluye A.5. El diagnóstico de la compuerta es claro, pero el implementador ingenuo duda: ¿está mal la plantilla o él? Además, la guía no dice cómo se guarda un archivo con BOM desde Visual Studio.
- Dirección: cambiar «los `Directory.Build.*`» por «los `.props` y `.targets` de este anexo (`Directory.Build.*`, `Directory.Packages.props`)», y sumar A.5 al paso 1c de EA-1. Opcional: una línea sobre cómo dejar el BOM desde Visual Studio, rotulada **[no verificado]** si no hay fuente.

### lector-sin-contexto-03 · S3 · E4 — ¿La compuerta entra antes o después de migrar? §5.2.6 la pone en el commit de política; §12 la pone en el paso 4, después de la migración

- Ubicación: §5.2.6, diagrama («Commit 1 · política (.editorconfig + .gitattributes + compuerta)») y contrato YAML («commit 1: política (.editorconfig, .gitattributes, compuerta)»), frente a §12, tabla: paso 2 «Commit 1 (política)», paso 3 migración, paso 4 «Poner la compuerta de texto en la CI y el hook versionado».
- Ancla: son las dos frases citadas. A.12 dispara la compuerta completa en `push` a `main` (`- run: bash tools/ci/compuerta.sh`, `if: github.event_name == 'push'`).
- Análisis (E4): si sigo §5.2.6 en un heredado todavía en cp1252 y la compuerta entra en el commit 1 junto con A.12, el `push` a `main` corre la compuerta sobre todo el árbol y queda en rojo hasta el commit 2. Si sigo §12, la compuerta entra después y el commit de política no se verifica. Las dos lecturas pueden ser válidas, pero la guía no elige, y es la primera decisión de la hoja de ruta.
- Dirección: alinear las dos secciones con una sola frase. Por ejemplo, en §5.2.6: «el commit 1 trae la compuerta, pero el workflow (A.12) y el hook se activan en el paso 4 de §12, después de la migración». O llevar la compuerta al paso 2 de §12 y advertir el rojo transitorio en `main`.

### lector-sin-contexto-04 · S3 · E2 + C — El prerrequisito «`python3` con `EditorConfig==0.17.1`» no dice cómo se consigue en una estación Windows, y en Windows `python3` no es el comando que documenta Python

- Ubicación: A.11, «Prerrequisitos de cada estación» (línea 2864); B.1, ítem 2; §3.6, fila ESC-01; §10.9 (línea 2082).
- Ancla: «`python3` con el paquete `EditorConfig==0.17.1` … En Windows se corre desde Git Bash». La compuerta exige justo ese nombre: `tiene python3` y `python3 -c 'import editorconfig'`. El comando `pip install EditorConfig==0.17.1` sólo aparece en el recuadro de §5.2.6, que es para la migración.
- E2: *Using Python on Windows* (https://docs.python.org/3/using/windows.html, consultado el 2026-10-09) dice: «A `python3` command is also included that mimics the `python` command. It is intended to catch accidental uses of the typical POSIX command on Windows, but is not meant to be widely used or recommended». Los comandos que la página recomienda son `py` y `python`.
- C (sólo habilita una pregunta): no sé si, con la instalación de Python que se hace normalmente en Windows, Git Bash encuentra `python3` y con él el paquete instalado por `py -m pip`. Es la pregunta que yo haría antes de activar el hook.
- Impacto: con el hook activado (B.1), un `python3` ausente da el rojo «falta python3 (prerrequisito…)». Está bien diagnosticado, pero la guía no dice cómo resolverlo. El riesgo es el que §10.2.2 quiere evitar: que la persona apague el hook.
- Dirección: en A.11, una receta mínima para Windows, rotulada **[no verificado]**: instalar Python, `py -m pip install EditorConfig==0.17.1`, y comprobar desde Git Bash con `python3 -c "import editorconfig"`. Si eso falla, decir qué hacer: un alias, editorconfig-checker (§5.2.5) o dejar el hook y apoyarse en la CI. Remitir desde B.1.

### lector-sin-contexto-05 · S4 · E1 — En la carpeta que A.11 manda abrir para copiar la compuerta hay otro `pre-commit`, que apunta a `tools/compuerta.sh` y no a `tools/ci/`

- Ubicación: A.11, «Qué se copia y adónde»; `Examples/N7-compuertas-y-gobierno/compuerta/pre-commit`, última línea; README de N7, línea 20 («Hook versionado en `.githooks/`»).
- Ancla: el hook de N7 es `exec "$(git rev-parse --show-toplevel)/tools/compuerta.sh" --staged`. A.11 dice «A `tools/ci/`: `compuerta.sh` de `Examples/N7-…/compuerta/` … A `.githooks/`: el hook de arriba». El README de N7 presenta su `pre-commit` como el hook para `.githooks/`.
- Impacto: quien copia la carpeta entera, o el hook que tiene al lado de la compuerta, deja un hook que hace `exec` de una ruta que no existe. Cada commit se rechaza con un error de shell que no menciona la política. El texto de A.11 es correcto. El problema es el laboratorio vecino, que contradice la ubicación sin decirlo.
- Dirección: en A.11, «el hook de arriba, **no** el `pre-commit` de N7, que asume `tools/compuerta.sh`». O una nota en el README de N7 que diga que su layout es `tools/` y el de A.11 es `tools/ci/`.

## Revisadas y bien

1. **El bit de ejecución (C2-08) quedó resuelto.** A.11 trae el `git update-index --chmod=+x`, A.12 invoca `bash tools/ci/compuerta.sh` y B.4 pregunta por `100755`. E1 (`salida-receta-ciclo3.txt`): el índice registra `100755 .githooks/pre-commit; 100755 tools/ci/compuerta.sh`, el hook corre en el primer commit y bloquea con un diagnóstico preciso. La variante B ampliada a `{cs,csproj,props,targets}` (C2-12) deja la solución del SDK en 0 violaciones una vez que se resuelve el hallazgo 02.
2. **El límite del alcance `--staged` (C2-09) está declarado** en §10.2.2 y en la fila ESC-04 de §10.4: «el alcance acota sólo el texto: toolchain y grafo miran el disco, y un lock modificado sin marcar pasa el hook y la CI lo rechaza». Es lo que pedí en el ciclo 2, con el rótulo **[observado]** y la versión.
3. **El recuadro «Desde Windows» de §0.4 (C2-10) coincide con Docker.** Docker documenta lo mismo que la guía: «run the command with MSYS path conversion disable: `MSYS_NO_PATHCONV=1 docker run --rm -ti -v $(pwd):/work alpine`» (https://docs.docker.com/desktop/troubleshoot-and-support/troubleshoot/topics/, consultado el 2026-10-09). Conserva **[no verificado]** para el resultado en Windows, como corresponde.

## Solicitudes de convocatoria

- Especialista en estaciones Windows / Visual Studio (sigue pendiente desde el ciclo 2, C2-Q03/C2-Q04): (a) si Git Bash encuentra `python3` con una instalación de Python normal y ve el paquete instalado con `py -m pip` (hallazgo 04); (b) si el paso de toolchain compara bien cuando `dotnet --version` o `uv run python -c print(…)` emiten `\r\n` en Windows. Sobre (b), por lectura de `compuerta.sh`: `pedido` y `real` de .NET llevarían el mismo `\r` y coincidirían por casualidad, pero el de Python compara contra un `pedido` sin `\r`. No lo puedo verificar sin Windows, y queda fuera de este rol.
