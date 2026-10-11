# Informe — Arquitecto de software (Ciclo 1)

- Especialista: arquitecto-software (catálogo variable «Arquitectura»).
- Mandato: el modelo integrado (solución políglota, monorepo, límites entre runtimes, contenedor frente a host, trazabilidad y procedencia del artefacto), los compromisos explicitados y la coherencia entre capítulos.
- Objeto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (3060 líneas, 1.0.0-borrador), laboratorio `Examples/` (N7, N8, A-plantillas).
- Revisión a ciegas: no leí informes de otros especialistas de este ciclo.
- Fecha: 2026-10-07.

## Experimento propio (E1) que sostiene AS-01

Copié `Examples/N8-integracion-poliglota/solucion/` (la disposición que el §11 recomienda) a un directorio temporal y le agregué `tools/ci/` con la compuerta única de N7 (`Examples/N7-compuertas-y-gobierno/compuerta/compuerta.sh`, la que §10.2.2 y A.11 llaman «la compuerta completa»). Después la corrí dentro de la imagen multi-runtime del laboratorio:

```text
$ docker run --rm -v $S/repo:/w -w /w lab-n8-poliglota:local bash -c 'git config --global --add safe.directory /w; bash tools/ci/compuerta.sh'
COMPUERTA commit=55fd01d alcance=todo
    python3: can't open file '/w/tools/ci/check_text_policy.py': [Errno 2] No such file or directory
COMPUERTA [FALLA] texto: la política de .editorconfig/.gitattributes no se cumple
COMPUERTA [ok]    toolchain .NET: SDK 8.0.425 = global.json
COMPUERTA [ok]    toolchain Node: 22.23.2 cumple .nvmrc=22.23.2
COMPUERTA [n/a]   toolchain Python: no hay .python-version
COMPUERTA [ok]    grafo NuGet: src/Saludo/packages.lock.json coincide (--locked-mode)
COMPUERTA [n/a]   grafo npm: no hay package-lock.json
COMPUERTA [n/a]   grafo uv: no hay uv.lock
COMPUERTA resultado=ROJO (1 paso/s)
```

La falla del paso de texto es un efecto de mi copia: no traje el verificador auxiliar de N2. Lo que importa son las tres líneas `n/a`. La solución tiene `tools/gen/.python-version`, `tools/gen/uv.lock` y `web/package-lock.json`, y la compuerta los declara inexistentes porque sólo los busca en la raíz (`compuerta.sh`, líneas 60 y 85: `if [ -f .python-version ]`, `if [ -f uv.lock ]`).

## Hallazgos

### AS-01 · S2 · E1 + E2 — La «compuerta única» de §10 no gobierna la disposición que recomienda §11: pasa por alto en silencio el Python y los locks de npm y uv

- **Ubicación**: §10.2.2, línea 1667; §10.4, línea 1759; §11.2.3, línea 1909; A.11, línea ~2500.
- **Ancla**: §10.2.2: «**un archivo presente sin su herramienta es rojo** … una compuerta que saltea en silencio existe en el papel, no en la práctica» y «La misma compuerta sirvió sin cambios para un repo .NET (E7-1), uno Node y uno Python (E7-7)». §10.4: «En CTX-POLI la compuerta corre sus tres pasos para los tres ecosistemas a la vez». §11.2.3 recomienda «`.python-version` dentro del proyecto uv». Con esa disposición, la compuerta de N7 da `[n/a] toolchain Python: no hay .python-version`, `[n/a] grafo npm` y `[n/a] grafo uv` (experimento de arriba). La variante que sí funciona, `solucion/verificar.sh`, tiene las rutas escritas a mano (`tools/gen/.python-version`, `cd web`).
- **Impacto**: el lector toma la compuerta de §10 o de A.11 para su monorepo y obtiene verde con dos de los tres ecosistemas sin verificar. Es la misma falla que §10 dice evitar, y el modelo integrado (§11.2.9, «compuerta única») descansa sobre ella.
- **Dirección**: declarar que la compuerta de N7 sólo cubre un repo con un proyecto por ecosistema en la raíz y que en CTX-POLI hace falta un **inventario explícito de proyectos por ecosistema** (rutas declaradas en el repo, o descubrimiento de manifiestos que falle ante uno no listado). Unificar o relacionar `compuerta.sh` y `verificar.sh` para que «única» no designe dos programas distintos. Agregar a la lista de señales de una versión pobre: «la compuerta dice n/a para un archivo que existe en una subcarpeta».

### AS-02 · S2 · E4 + E2 — El modelo integrado promete una procedencia «firmada en CI» que además nombre por digest las bases de los tres toolchains; ninguno de los caminos del laboratorio da las dos cosas juntas

- **Ubicación**: §11.2.9, diagrama, línea 2010 («procedencia: bases por digest, firmada en CI»); §11.6 P4, línea 2136 («la procedencia de la plataforma, que nombra por digest las imágenes de los tres toolchains, firmada en la CI»); §11.2.8, línea 1981; `solucion/ci/github-actions.ejemplo.yml`.
- **Ancla**:
  - La procedencia con bases por digest es la de BuildKit (E8-6). El propio §9.2.4 (línea 1484) dice que tiene «`builder.id` **vacío**» y que no está firmada.
  - La procedencia firmada por la plataforma (`actions/attest`) usa el tipo de build de GitHub Actions. Su especificación exige en `resolvedDependencies` sólo el commit («SHOULD contain an entry identifying the resolved git commit ID») y deja todo lo demás como «MAY contain additional artifacts … such as the specific versions of the virtual environments used». El ejemplo oficial no tiene ninguna imagen de contenedor. Fuente: slsa-framework/github-actions-buildtypes, `workflow/v1/README.md` y `example.json`, consultados el 2026-10-07.
  - En el ejemplo de CI del laboratorio, `IMAGEN_DIGEST: sha256:DIGEST` se pasa a mano a `registrar-entorno.sh`. El `entorno.txt` resultante no forma parte del sujeto ni del predicado que firma `actions/attest`.
- **Impacto**: el lector cree que obtiene un SLSA L2 que contesta «con qué entorno se ensambló». En realidad obtiene dos documentos desacoplados: uno firmado que sólo nombra el commit y otro sin firma que nombra el entorno. Es la tercera pregunta del caso.
- **Dirección**: separar en el modelo integrado las tres piezas: (a) procedencia firmada por la plataforma (commit, workflow); (b) materiales del entorno (digest de la imagen del job o de las etapas, toolchain efectivo), registrados por un paso del usuario; (c) cómo se atan, sea con un predicado propio firmado por `actions/attest`, rotulado como afirmación del pipeline y no de la plataforma (la misma vara que §9.2.4 aplica a cosign), sea con la atestación de la imagen del job, enlazada por su digest. Corregir §11.6 P4 y el diagrama para que no atribuyan a la plataforma lo que aporta BuildKit.

### AS-03 · S2 · E2 + E1 — Decisión de imagen para la CI contradictoria entre §11.3/§11.6 y §8.2.6/§10/§11.2.7, y la variante «por componente» del laboratorio no corre la compuerta

- **Ubicación**: §11.3, tabla de decisiones, líneas 2042–2043 («Única → **Devcontainer** y frontera A»; «Por componente → **CI** por etapas»); §11.6 P2, línea 2130; §11.2.7, línea 1971 («Imagen única cuando el artefacto es uno»); §8.2.6, línea 1295 («compartir la base que trae el toolchain»); §11.2.6, línea 1967; `imagen/Dockerfile.por-componente`.
- **Ancla**:
  - El artefacto del laboratorio es uno solo (la DLL), así que por §11.2.7 corresponde la imagen única. Aun así, la tabla de §11.3 recomienda «por componente» para la CI.
  - `Dockerfile.por-componente` no ejecuta `verificar.sh` ni ningún chequeo de texto. Sólo corre `uv run --locked`, `npm ci` y `dotnet restore --locked-mode` (E1: lectura del archivo). Eso contradice §10.2.4, que pone la compuerta completa en la CI como árbitro.
  - En la pareja recomendada (devcontainer con imagen única y CI por componente), el Python de desarrollo lo instala uv (`UV_PYTHON_PREFERENCE=only-managed`, `imagen/Dockerfile`), mientras que el de la CI es el de `python:3.12-slim` (`only-system`, Debian 13 / glibc 2.41, según §11.2.6). Las bases del toolchain son distintas, lo que contradice §8.2.6, y la frase de §11.2.6 «se cumple por construcción» sólo vale si la CI también usa la imagen única.
- **Impacto**: dos lectores de la guía eligen imágenes de CI opuestas para el mismo caso. El que sigue la tabla de §11.3 pierde la compuerta de texto en la CI, que es justamente la que previene el caso disparador.
- **Dirección**: hacer que la tabla de §11.3 y §11.6 P2 dependan de la misma variable que §11.2.7: un artefacto o componentes publicados por separado. Si se mantiene «por componente» para la CI, exigir una etapa previa con la compuerta completa sobre el clon y declarar que el Python de desarrollo y el de la CI vienen de bases distintas, o bien instalar Python con uv también en la etapa `py`.

### AS-04 · S3 · E2 — Las plantillas del Anexo A, que se presentan como «repositorio políglota mínimo», no siguen el modelo integrado del §11 en el devcontainer ni en la CI

- **Ubicación**: A.9, líneas ~2410–2426; A.12, línea ~2515 («Misma receta que el devcontainer»); §11.8, línea 2162; §11.4, fila ESC-04, línea 2053; §11.2.3, línea 1911.
- **Ancla**:
  - `Examples/A-plantillas/repo/.devcontainer/devcontainer.json` usa `sdk:8.0@sha256` más la *feature* de Node con `"version": "24.21.0"`, y no trae Python ni uv. Sin embargo, el mismo repo tiene `tools/gen/pyproject.toml` y `.python-version`.
  - §11.4 recomienda para ESC-04 una «Imagen única construida desde los nativos». §11.2.3 advierte que las *features* no leen los archivos nativos, y el número de A.9 repite el de `.nvmrc` a mano: una segunda fuente de verdad, lo que §11.6 P3 desaconseja.
  - A.12 dice «misma receta que el devcontainer», pero el devcontainer no tiene receta: es una imagen más una *feature*.
- **Impacto**: quien copia el Anexo A, como invita §11.8, obtiene un devcontainer donde el proyecto Python no se puede construir y una versión de Node declarada en dos lugares.
- **Dirección**: hacer que A.9 apunte a la imagen de A.10 (por digest, construida con `--build-arg` desde los nativos) o declarar explícitamente que A.9 es la variante sólo .NET + Node y no la políglota. Hacer que A.12 nombre la misma imagen.

### AS-05 · S3 · E2 — En ESC-01, la recomendación de correr `verificar.sh` «por WSL o Git Bash» verifica un toolchain distinto del que usa la build de Visual Studio

- **Ubicación**: §11.4, fila ESC-01, línea 2050; fila ESC-03, línea 2052; §11.2.5, punto 3, línea 1925.
- **Ancla**:
  - La fila ESC-01 dice: «correr `verificar.sh` (por WSL o Git Bash) antes del push».
  - La fila ESC-03 dice: «Dos instalaciones de cada runtime (Windows y WSL)».
  - §11.2.5 dice: «MSBuild usa el Node que esté primero en el `PATH`».
  - Corrida desde WSL, la compuerta compara `.nvmrc`, `global.json` y `.python-version` con los runtimes de Linux, no con los de Windows que usa la frontera A de Visual Studio.
- **Impacto**: verde local engañoso en el escenario donde el problema del caso no se ve. La compuerta contesta por otra máquina.
- **Dirección**: limitar la recomendación a Git Bash (o a un equivalente que use el `PATH` de Windows), o declarar que por WSL sólo se verifican las capas 1 y 3 y que la 2 de Windows queda a cargo de `engine-strict`, `global.json` y la CI. Rotular **[no verificado en Windows]**, como ya se hace en otros lugares.

### AS-06 · S3 · E2 — El criterio «las dos fronteras producen el mismo artefacto» no es comprobable en el escenario para el que se recomienda la frontera A

- **Ubicación**: §11.7, línea 2154 («comprueba que las dos producen el mismo artefacto»); §11.2.5, línea 1941; §8.2.4, regla 3, línea 1264; §9.4, ESC-01, línea 1515.
- **Ancla**:
  - La frontera A se recomienda «en la estación» (ESC-01, F5, `Debug`, sin `ContinuousIntegrationBuild`).
  - §8.2.4 admite que entre ESC-01 y ESC-04 «el hash de los binarios» no va a ser idéntico.
  - §9.4 dice que en ESC-01 `ContinuousIntegrationBuild` «debe quedar apagado».
  - La igualdad de §11.2.5 se midió en un solo contenedor Linux, con la misma ruta y en `Release`.
- **Impacto**: el criterio de calidad pide una comprobación que el lector no puede hacer donde se aplica, o que hace mal (compara la estación con la CI y concluye que el diseño está roto).
- **Dirección**: reformular el criterio como prueba de regresión del `.csproj` en la CI: la misma imagen corre `dotnet build -c Release -p:ContinuousIntegrationBuild=true` con `ConstruirPoliglota=true` y también `build.sh`, y compara las DLL. Lo que se demuestra es que los targets de A no divergen de B, no que la estación reproduzca a la CI.

### AS-07 · S4 · E2 — Matriz capítulo × escenario y derechos de decisión que no coinciden con el cuerpo

- **Ubicación**: §2.4, línea 216 (fila §9: ESC-02 «—», ESC-03 «—») frente a §9.4, línea 1516 («ESC-02 / ESC-03 | Reconstruir una pieza publicada y comparar hashes»). §2.4, líneas 225–226, y §10.2.8, línea 1734 (ACT-OPS decide la «Imagen de CI y devcontainer»), frente a §11.4, línea 2058 (ACT-ARQ decide «imagen única o por componente»).
- **Impacto**: el lector que entra por el mapa de §2 descarta §9 en Linux, y queda ambiguo quién decide la imagen en CTX-POLI.
- **Dirección**: poner «○» en §9 para ESC-02 y ESC-03 (reconstrucción). Separar «estrategia de imagen» (ACT-ARQ) de «mantenimiento y digest de la imagen» (ACT-OPS) en §2.3, §10.2.8 y §11.4.

## Revisado y bien

1. **§3.2, §3.3 y §3.5**: el modelo de seis capas con «fuente de verdad / si el repo calla, la aporta…» y la tabla que se lee por «qué deja libre». Es un modelo coherente y es el que ordena todos los capítulos posteriores, incluida la excepción declarada de la flecha capa 4 → capa 2.
2. **§8.2.4**: la convivencia de Visual Studio con el devcontainer. La política vive en el repo, el devcontainer es un consumidor y la CI arbitra, y el razonamiento se apoya en el hallazgo negativo documentado. La decisión contenedor/host está bien fundada.
3. **§9.2.4 y §9.6**: la honestidad sobre los niveles de SLSA. Una clave propia no es L2, se declara el nivel alcanzado y se separan SBOM y procedencia por la pregunta que contesta cada uno. El defecto de AS-02 es que §11 no aplica esa misma vara.

## Solicitudes de convocatoria

Ninguna.
