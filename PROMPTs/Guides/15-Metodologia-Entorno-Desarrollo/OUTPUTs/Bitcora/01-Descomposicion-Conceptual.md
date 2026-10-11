---
doc_id: BIT-15-01
doc_type: descomposicion-conceptual
title: Descomposición conceptual del pedido — núcleos N0 a N8
status: vigente
origin: agent
confidence: 0.8
owner: analista de descomposición (sin voto en la mesa)
last_review: 2026-10-07
audience: [mesa-evaluadora, presidente, redactores]
traces: [BIT-15-00, PROMPT-15 §Contexto, §Solicitudes, §Reglas]
---

# Bitácora 01 — Descomposición conceptual

La segmentación se hizo sobre la **totalidad del prompt** (contexto, solicitudes y reglas), no sobre sus párrafos. El contexto del PO tiene cinco párrafos, pero mezcla en uno solo el síntoma de codificación con la causa de plataforma, y en otro mete en la misma frase SDK, compilador y paquetes NuGet, que se fijan con mecanismos que no se tocan entre sí. Cortar por párrafo habría producido núcleos con dependencias cruzadas en ambos sentidos. El criterio usado fue otro: dos ideas van al mismo núcleo cuando comparten **mecanismo** (los mismos archivos de configuración y la misma herramienta que los lee) y **modo de falla** (el mismo síntoma cuando faltan); van a núcleos distintos cuando se pueden fijar, probar y romper por separado.

Todas las afirmaciones técnicas de este documento que todavía no tienen fuente se marcan **[C: a verificar]**. Son hipótesis de trabajo del analista para orientar la investigación de cada núcleo, no contenido de la guía.

## Índice

- [1. Mapa de núcleos](#1-mapa-de-núcleos)
- [2. Núcleos](#2-núcleos)
  - [N0 — Modelo de capas del entorno y vocabulario de reproducibilidad](#n0--modelo-de-capas-del-entorno-y-vocabulario-de-reproducibilidad)
  - [N1 — Codificación de texto y finales de línea: el fenómeno](#n1--codificación-de-texto-y-finales-de-línea-el-fenómeno)
  - [N2 — Política de texto del repositorio y remediación de código heredado](#n2--política-de-texto-del-repositorio-y-remediación-de-código-heredado)
  - [N3 — Fijación del toolchain](#n3--fijación-del-toolchain)
  - [N4 — Congelamiento de dependencias](#n4--congelamiento-de-dependencias)
  - [N5 — Entornos en contenedores y convivencia con estaciones Windows](#n5--entornos-en-contenedores-y-convivencia-con-estaciones-windows)
  - [N6 — Procedencia y trazabilidad de la pieza construida](#n6--procedencia-y-trazabilidad-de-la-pieza-construida)
  - [N7 — Compuertas, gobierno y actualización controlada](#n7--compuertas-gobierno-y-actualización-controlada)
  - [N8 — Integración políglota en una única solución](#n8--integración-políglota-en-una-única-solución)
- [3. Decisiones de segmentación](#3-decisiones-de-segmentación)
- [4. Plan de validación por núcleo](#4-plan-de-validación-por-núcleo)

## 1. Mapa de núcleos

| ID | Slug | Título | Ecosistemas | Depende de |
|---|---|---|---|---|
| N0 | `modelo-de-capas-y-reproducibilidad` | Modelo de capas del entorno y vocabulario de reproducibilidad | transversal | — |
| N1 | `codificacion-y-finales-de-linea` | Codificación de texto y finales de línea: el fenómeno | .NET, Node, Python, git, editores | N0 |
| N2 | `politica-de-texto-y-remediacion` | Política de texto del repositorio y remediación de código heredado | git, EditorConfig, .NET, Node, Python | N1 |
| N3 | `fijacion-del-toolchain` | Fijación del toolchain (SDK, runtime, intérprete, gestor de paquetes) | .NET, Node, Python | N0 |
| N4 | `congelamiento-de-dependencias` | Congelamiento de dependencias | NuGet, npm/pnpm/yarn, pip/uv/poetry | N0, N3 |
| N5 | `entornos-en-contenedores` | Entornos en contenedores y convivencia con estaciones Windows | Docker, Dev Containers, WSL, Visual Studio | N1, N2, N3, N4 |
| N6 | `procedencia-y-trazabilidad` | Procedencia y trazabilidad de la pieza construida | .NET, Node, Python, SLSA, SBOM | N3, N4, N5 |
| N7 | `compuertas-y-gobierno` | Compuertas, gobierno y actualización controlada | CI, git, revisión de PR | N2, N3, N4, N6 |
| N8 | `integracion-poliglota` | Integración políglota en una única solución | .NET + Node + Python | N1–N7 |

## 2. Núcleos

### N0 — Modelo de capas del entorno y vocabulario de reproducibilidad

**Alcance.** El esqueleto conceptual del que cuelgan los demás núcleos. Modela el «entorno con que se ensambló la pieza» como una pila de capas, cada una con su fuente de verdad versionada: bytes del fuente (codificación, EOL) → toolchain (SDK, compilador, runtime, intérprete, gestor de paquetes) → grafo de dependencias → sistema operativo e imagen base → proceso de build (flags, variables, fecha, rutas) → metadatos y procedencia del artefacto. Fija el vocabulario que la guía usa con un solo sentido: *fijar* (pin) frente a *rango*, *congelar* (lock), *reproducible*, *determinista*, *hermético*, *deriva* (drift) del entorno, «funciona en mi máquina».

**Preguntas que responde.**
- ¿Qué significa exactamente «saber con qué entorno se construyó» una pieza y qué capas hay que registrar para poder afirmarlo?
- ¿Qué diferencia hay entre una build reproducible, una determinista y una hermética? ¿Cuál necesita mi equipo?
- ¿Qué capa fija cada mecanismo (archivo de configuración, lock file, imagen de contenedor) y cuál deja libre?
- ¿Por qué el mismo commit produce resultados distintos en dos máquinas?

**Ecosistemas.** Transversal.

**Por qué es un núcleo.** El pedido del PO usa «congelar» para cosas de capas distintas y pregunta si los contenedores «lo resuelven». Sin un modelo explícito de capas, cada núcleo redefine los términos y la guía se contradice (por ejemplo, al afirmar que un contenedor «congela» las dependencias). Es el único núcleo sin dependencias y el que vuelve verificable la cohesión. Las definiciones de reproducibilidad se anclan en reproducible-builds.org y slsa.dev **[C: a verificar en la fuente]**.

### N1 — Codificación de texto y finales de línea: el fenómeno

**Alcance.** Qué es un *encoding* y por qué un archivo de texto no lo declara; Windows-1252 frente a UTF-8; qué es el BOM (U+FEFF) y qué hace cada herramienta con él; CRLF frente a LF. Cómo detecta o supone la codificación cada lector relevante: el compilador de C# (Roslyn) invocado por MSBuild en Windows y en Linux, el compilador de Razor, Node.js (`require`/`import`, `fs.readFile`), Python (PEP 263, el modo UTF-8 de PEP 540 y el cambio de default de PEP 686), git (que trata el contenido como bytes) y los editores (Visual Studio, VS Code). Reproduce el caso disparador con un ejemplo sintético.

**Preguntas que responde.**
- ¿Por qué el mismo `.cs` en cp1252 compila bien en Windows y falla o corrompe literales en Linux? **[C: la hipótesis es que el compilador, sin BOM y ante bytes inválidos en UTF-8, recurre a la página de códigos del sistema, que difiere entre plataformas; a verificar en learn.microsoft.com y con E1]**
- ¿Qué cambia el BOM para Roslyn, para Node, para Python y para git? ¿Es necesario, inocuo o perjudicial en cada uno?
- ¿Cómo se diagnostica la codificación real de un archivo (`file`, `iconv`, inspección de bytes)?
- ¿Por qué un identificador con un carácter no ASCII rompe la compilación y un literal con acento sólo se corrompe?
- ¿Qué editor reescribe la codificación o los finales de línea al guardar, y bajo qué configuración?

**Ecosistemas.** .NET (Roslyn, MSBuild, Razor), Node.js, Python, git, editores.

**Por qué es un núcleo.** Codificación y finales de línea son dos propiedades distintas de los mismos bytes, que se configuran en los mismos archivos (`.editorconfig`, `.gitattributes`) y producen el mismo síntoma que el PO quiere evitar: commits cuyo único cambio es invisible. Se separa la **explicación del fenómeno** (N1) de la **política** (N2) porque el fenómeno se valida con experimentos E1 por ecosistema, y la política con revisión de configuración y escenarios E3: son validaciones de naturaleza distinta.

### N2 — Política de texto del repositorio y remediación de código heredado

**Alcance.** La respuesta al «criterio unificado» del PO. Elegir la codificación canónica (con o sin BOM, por tipo de archivo) y la política de finales de línea; declararla en `.editorconfig` (`charset`, `end_of_line`, `insert_final_newline`) y en `.gitattributes` (`text`, `eol`, `-text`/`binary`, `working-tree-encoding`); entender `core.autocrlf` y por qué no conviene que la política dependa de la configuración local de cada desarrollador; verificar la política (chequeo local, hook de pre-commit, compuerta de CI); migrar un código heredado en un único commit de normalización (`git add --renormalize`, conversión con `iconv`) y aislarlo de `git blame` con `.git-blame-ignore-revs`.

**Preguntas que responde.**
- ¿UTF-8 con BOM o sin BOM para C#/Razor? ¿Y para JS/TS, Python, JSON, scripts de shell y archivos `.sln`/`.csproj`? ¿Qué pierde cada opción?
- ¿Qué archivo manda cuando `.editorconfig`, `.gitattributes` y `core.autocrlf` dicen cosas distintas? ¿Quién lee cada uno (editor, git, compilador)?
- ¿Cómo convierto cien archivos heredados sin romper la historia ni mezclar la conversión con cambios funcionales?
- ¿Cómo detecto en un PR que alguien reintrodujo cp1252, un BOM o CRLF?
- ¿Cuándo usar `working-tree-encoding` y cuándo es mejor convertir de una vez?

**Ecosistemas.** git, EditorConfig, Visual Studio/VS Code; aplica a los tres lenguajes.

**Por qué es un núcleo.** Es la decisión que el PO pide explícitamente («mantener un criterio… para no tener commits con cambios de BOM») y tiene un ciclo propio: decidir, declarar, verificar, migrar. Depende de N1 (no se puede elegir política sin entender quién lee qué) y alimenta a N5 (los bind mounts de un contenedor muestran los bytes que escribió Windows) y a N7 (la política sin compuerta se degrada).

### N3 — Fijación del toolchain

**Alcance.** Fijar la versión de la herramienta que transforma el fuente: SDK de .NET (`global.json`, `sdk.version`, `rollForward`, `allowPrerelease`) y lo que eso implica para la versión del compilador y de `LangVersion`; *target framework* frente a SDK; runtime de Node (`.nvmrc`, `.node-version`, `engines` en `package.json`, `engine-strict`), gestor de paquetes (`packageManager`, Corepack); intérprete de Python (`requires-python`, `.python-version`) y gestores de versión (nvm, fnm, pyenv, uv, mise/asdf). Diferencia entre **declarar** una versión y **hacerla cumplir**.

**Preguntas que responde.**
- ¿Qué fija `global.json` y qué no fija? ¿Qué pasa con `rollForward` si la versión exacta no está instalada?
- ¿Fijar el SDK fija el compilador de C#? ¿Y el runtime con que corre la aplicación?
- En Node, ¿`engines` impide instalar con otra versión o sólo avisa? ¿Cuál es el estado vigente de Corepack y de `packageManager`? **[C: hay cambios recientes en la distribución de Corepack con Node; a verificar en nodejs.org]**
- En Python, ¿qué diferencia hay entre `requires-python` (metadato del paquete) y `.python-version` (preferencia del entorno)?
- ¿Cuál es el archivo que una estación Windows con Visual Studio respeta, y cuál ignora?

**Ecosistemas.** .NET, Node.js, Python.

**Por qué es un núcleo.** El PO pide congelar «versiones de compiladores, sdk» en la misma frase que los NuGet, pero el toolchain se fija con archivos y herramientas distintos de los del grafo de dependencias, y falla distinto (un SDK más nuevo cambia advertencias, analizadores o el resultado de la build aunque el lock file no cambie **[C: a verificar]**). Además, la versión del gestor de paquetes condiciona el formato del lock file, por lo que N4 depende de N3 y no al revés.

### N4 — Congelamiento de dependencias

**Alcance.** Pasar de rangos declarados a un grafo resuelto y congelado. En .NET: `packages.lock.json` (`RestorePackagesWithLockFile`, `RestoreLockedMode`), Central Package Management (`Directory.Packages.props`, `ManagePackageVersionsCentrally`, *transitive pinning*), fuentes de paquetes y *package source mapping* en `nuget.config`. En Node: `package-lock.json` con `npm ci`, y los equivalentes de pnpm y Yarn. En Python: `uv.lock`, `poetry.lock`, `requirements.txt` compilado con hashes (pip-tools) y el formato estándar de lock file (PEP 751, `pylock.toml`) **[C: verificar su estado de aceptación y adopción al 2026-10-07 en peps.python.org y packaging.python.org]**. Integridad (hashes), restauración estricta en CI frente a resolución libre en desarrollo.

**Preguntas que responde.**
- ¿Qué diferencia hay entre fijar versiones directas (CPM) y congelar el grafo transitivo (lock file)? ¿Necesito las dos cosas?
- ¿Qué comando falla si el lock file no coincide con lo declarado, en cada ecosistema, y cuál lo regenera en silencio?
- ¿Qué pasa con el lock file cuando el mismo repo se restaura en Windows y en Linux (dependencias específicas de plataforma, marcadores de entorno)?
- ¿El lock file protege contra un paquete republicado o un registro comprometido? ¿Qué agregan los hashes y el mapeo de fuentes?
- ¿Quién actualiza el lock file, cuándo, y cómo se revisa ese cambio en un PR?

**Ecosistemas.** NuGet, npm/pnpm/Yarn, pip/pip-tools/uv/Poetry.

**Por qué es un núcleo.** Tiene un mecanismo propio (resolver + archivo de lock + modo estricto) y un modo de falla propio (deriva del grafo transitivo) que no depende de la plataforma ni del contenedor. Separarlo de N3 permite validar cada ecosistema con un experimento E1 corto: alterar el lock y comprobar que la restauración estricta falla.

### N5 — Entornos en contenedores y convivencia con estaciones Windows

**Alcance.** La pregunta del PO «no sé si esto se puede hacer mediante contenedores». Qué fija un contenedor (SO, bibliotecas del sistema, toolchain instalado en la imagen) y qué no (el código montado, el grafo si no hay lock, la configuración de git del host). Dev Containers (`devcontainer.json`, *features*, imagen frente a Dockerfile), fijación de imágenes por *digest* frente a etiqueta, imágenes oficiales de .NET, Node y Python. Convivencia: Visual Studio en Windows (soporte de contenedores y de devcontainers, o su ausencia), VS Code con Dev Containers, WSL 2, bind mounts entre Windows y Linux (finales de línea, permisos, rendimiento), y la estación Windows nativa sin contenedor como escenario legítimo.

**Preguntas que responde.**
- ¿Qué capas del modelo N0 congela realmente un devcontainer y cuáles quedan abiertas?
- ¿Etiqueta (`sdk:8.0`) o digest (`sdk@sha256:…`)? ¿Qué gano y qué pierdo en cada caso, incluidas las actualizaciones de seguridad?
- ¿Cómo trabaja con el mismo repo quien usa Visual Studio en Windows sin contenedores y quien usa un devcontainer? ¿Qué debe ser idéntico entre ambos para que la build dé lo mismo?
- ¿Qué problemas aparecen al montar en un contenedor Linux un repo clonado en Windows (CRLF, permisos de ejecución, `core.autocrlf` del host)?
- ¿El contenedor de desarrollo debe ser la misma imagen que la de CI? ¿Cuándo conviene separarlas?

**Ecosistemas.** Docker, Dev Containers (containers.dev), WSL, Visual Studio, VS Code; imágenes de .NET, Node y Python.

**Por qué es un núcleo.** Es el núcleo donde convergen los anteriores: un contenedor sólo es útil si la política de texto (N2), el toolchain (N3) y las dependencias (N4) ya están declaradas en el repo; si no, congela una configuración no declarada. Por eso depende de los cuatro, y por eso SUP-04 (el contenedor no resuelve todo) se valida acá con E1.

### N6 — Procedencia y trazabilidad de la pieza construida

**Alcance.** La respuesta a «saber con qué entorno se ensambló esa pieza de código». Builds deterministas en .NET (`Deterministic`, `ContinuousIntegrationBuild`, `PathMap`), SourceLink y símbolos; metadatos de build embebidos (versión informativa con SHA de commit, versión del SDK); equivalentes en Node (campos del paquete, `npm pack`, procedencia de npm) y Python (metadatos de distribución, `SOURCE_DATE_EPOCH`); SBOM (SPDX, CycloneDX) y herramientas por ecosistema; procedencia SLSA y atestaciones firmadas generadas por la CI.

**Preguntas que responde.**
- ¿Qué información mínima debe viajar con un artefacto para saber con qué entorno se construyó?
- ¿Qué diferencia hay entre un SBOM (qué contiene) y una atestación de procedencia (cómo y dónde se construyó)?
- ¿Cómo verifico que dos builds del mismo commit producen el mismo binario? ¿Qué rompe el determinismo (fechas, rutas absolutas, orden)?
- ¿Qué nivel de SLSA es razonable para un equipo chico y qué exige cada nivel? **[C: verificar la versión vigente de la especificación en slsa.dev]**
- ¿Dónde se guarda la procedencia y quién la consulta?

**Ecosistemas.** .NET, Node.js, Python; SLSA, SPDX/CycloneDX, reproducible-builds.org.

**Por qué es un núcleo.** Es el objetivo final que el PO declara («super importante») y responde a una pregunta distinta de las anteriores: no cómo fijar el entorno, sino cómo **demostrar después** qué entorno se usó. Depende de N3–N5 porque sólo se puede registrar lo que se fijó.

### N7 — Compuertas, gobierno y actualización controlada

**Alcance.** La «mecánica» que pide el PO para mantener el criterio en el tiempo. La CI como árbitro (los mismos chequeos de política de texto, versión de toolchain y restauración estricta que en local), hooks de pre-commit, lista de verificación de revisión de PR para cambios de entorno, roles y responsabilidades, actualización controlada (bots de actualización de dependencias, cadencia de subida de SDK/imagen) y el registro de decisiones de entorno (ADR). Incluye el límite real de las compuertas en plataformas sin protección de rama.

**Preguntas que responde.**
- ¿Qué se verifica en local, qué en CI y qué sólo en revisión humana?
- ¿Cómo se descongela algo deliberadamente (subir SDK, actualizar un paquete) sin perder la trazabilidad?
- ¿Quién decide la política de entorno y quién puede cambiarla?
- ¿Qué cambios de entorno debe mirar con lupa el revisor de un PR (lock files, `global.json`, imagen base, `.gitattributes`)?

**Ecosistemas.** git, CI (genérico), bots de actualización; aplica a los tres lenguajes.

**Por qué es un núcleo.** Sin este núcleo la guía describe configuraciones correctas el día uno y no explica por qué se degradan. Agrupa todo lo que tiene que ver con **mantener** lo fijado: no introduce mecanismos nuevos de fijación, sino el proceso que hace cumplir los de N2, N3, N4 y N6. Se separa de N8 porque aplica igual a una solución de un solo lenguaje.

### N8 — Integración políglota en una única solución

**Alcance.** La solicitud «en especial qué sucede cuando se integran todos estos en una única solución». Organización de monorepo (un `.editorconfig` y un `.gitattributes` raíz con secciones por lenguaje, un lock file por ecosistema), gestores multi-runtime (mise/asdf, *features* de devcontainer), cómo una solución .NET invoca la build de Node o Python (targets de MSBuild, orquestadores, scripts de tareas), una imagen de desarrollo multi-runtime frente a varias, CI con matriz o con una sola imagen, SBOM y procedencia unificados, choque de convenciones (BOM, EOL, versión de herramientas entre ecosistemas).

**Preguntas que responde.**
- ¿Qué se rompe primero cuando .NET, Node y Python comparten repo (convenciones de BOM, finales de línea, versiones de herramientas, rutas)?
- ¿Una sola imagen de desarrollo con los tres runtimes o una por componente? ¿Con qué criterio?
- ¿Cómo se fija el toolchain de tres ecosistemas desde un único punto de verdad?
- ¿Cómo se genera un SBOM y una procedencia que cubran los tres?
- ¿Dónde vive la frontera entre la build de .NET y la de los demás (quién llama a quién)?

**Ecosistemas.** .NET + Node.js + Python juntos.

**Por qué es un núcleo.** Es la fase de integración que el prompt exige: reutiliza los resultados de N1–N7 y resuelve sus contradicciones (por ejemplo, una política de BOM elegida para C# que no conviene a scripts de shell o a Python). Por construcción es el último y el único que depende de todos.

## 3. Decisiones de segmentación

| Decisión | Alternativa descartada | Motivo |
|---|---|---|
| Se agrega **N0** (modelo de capas) aunque el PO no lo pida como tema. | Repartir las definiciones en cada núcleo. | El pedido usa «congelar» para tres capas distintas; sin un vocabulario único se viola la univocidad terminológica del marco (§3, coherencia). |
| Codificación y finales de línea **fusionados** en N1/N2. | Un núcleo para encoding y otro para EOL. | Mismo mecanismo (`.editorconfig`, `.gitattributes`, normalización de git) y mismo síntoma (diffs invisibles). SUP-02. |
| Codificación **separada** en fenómeno (N1) y política/remediación (N2). | Un único núcleo de codificación. | Validaciones distintas (E1 por lector frente a E3 por escenario de equipo) y N5 sólo depende de la política, no del detalle de cada lector. |
| Toolchain (N3) **separado** de dependencias (N4). | Un núcleo «congelamiento». | Archivos, comandos y fallas distintas; N4 depende de N3 por el formato del lock. SUP-03. |
| Contenedores (N5) **después** de N1–N4. | Contenedores como solución transversal primero. | El contenedor congela lo que el repo declara; presentarlo primero induce la conclusión errónea de que basta con él (SUP-04). |
| Se agrega **N7** (gobierno y compuertas). | Repartir la CI en cada núcleo. | El PO pide una «mecánica» que se sostenga; las compuertas comparten diseño (local = CI) y actores (revisor, DevOps) que se definen una vez. |
| Políglota (N8) como **núcleo de integración** al final. | Tratar la combinación dentro de cada núcleo. | Cumple la fase de integración que exige la regla de descomposición y concentra las contradicciones entre ecosistemas en un solo lugar. Cada núcleo N1–N7 igual cubre los tres ecosistemas por separado. |
| WSL dentro de N5, no aparte. | Núcleo de WSL. | Es una variante del escenario «Linux en máquina Windows»; comparte las preguntas de bind mount y EOL. |

## 4. Plan de validación por núcleo

Cada núcleo se valida de manera relativamente independiente antes de la integración:

| Núcleo | Validación mínima esperada | Evidencia |
|---|---|---|
| N0 | Las definiciones citan fuente y no se contradicen con N1–N8. | E4 + E2 |
| N1 | Experimento que reproduce el caso: `.cs` en cp1252 con carácter no ASCII en identificador y en literal, compilado con el SDK en Linux; mismos bytes leídos por Node y Python. | E1 |
| N2 | Repo de juguete con `.editorconfig` + `.gitattributes`; `git add --renormalize` muestra el efecto; un chequeo detecta BOM/cp1252/CRLF reintroducidos. | E1 + E3 |
| N3 | `global.json` con versión no instalada y su error; `engines`/`packageManager` y `requires-python` con versión incompatible. | E1 |
| N4 | Restauración estricta que falla al alterar el lock en .NET, npm y uv/pip. | E1 |
| N5 | Devcontainer mínimo con imagen por digest; bind mount con archivo CRLF. | E1 |
| N6 | Dos builds .NET del mismo commit comparadas por hash; metadatos de versión con SHA; SBOM generado. | E1 |
| N7 | Script de compuerta único invocado igual en local y en un workflow de CI de ejemplo. | E1 |
| N8 | Mini solución con los tres ecosistemas, política raíz y build orquestada desde un punto. | E1 |
