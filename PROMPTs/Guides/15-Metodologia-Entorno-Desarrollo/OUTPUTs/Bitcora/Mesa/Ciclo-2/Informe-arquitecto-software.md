# Informe — Arquitecto de software (Ciclo 2)

- Especialista: arquitecto-software (catálogo variable «Arquitectura»).
- Mandato: el modelo integrado (solución políglota, monorepo, límites entre runtimes, contenedor frente a host, trazabilidad y procedencia del artefacto), los compromisos explicitados y la coherencia entre capítulos. En este ciclo, además, edición, compresión y coherencia global de la obra como versión final.
- Objeto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (1.0.0-rc.1, 3391 líneas); laboratorio `Examples/` (N8 y A-plantillas).
- Insumos cerrados que no se re-litigan: `Mesa/Ciclo-1/05-Aplicacion.md` (P-01…P-24, deudas D-1…D-7).
- Revisión a ciegas: no leí informes de otros especialistas de este ciclo.
- Fecha: 2026-10-09. Experimentos en el scratchpad de la sesión, sobre copias; nada del laboratorio se modificó.

## Experimentos propios (E1)

**X1. Seguir A.11 al pie de la letra en el repositorio del Anexo A.** El repo de plantillas tiene sus proyectos en subcarpetas (`web/`, `tools/gen/`, `src/App/`), que es justamente el caso en que A.11 manda copiar «`verificar.sh` de N8 con su inventario de rutas» a `tools/ci/`. Copié `Examples/A-plantillas/repo/`, puse `N8-…/solucion/verificar.sh` como `tools/ci/compuerta.sh` (el nombre que invoca el hook de A.11) junto con `verificar-texto.py`, agregué un `.cs` en cp1252 —el del caso— y corrí el hook en la imagen multi-runtime del laboratorio:

```text
$ printf 'class Alarma { string \xc7audal = "Atenci\xf3n"; }\n' > src/App/Alarma.cs; file src/App/Alarma.cs
src/App/Alarma.cs: C++ source, ISO-8859 text
$ docker run --rm -v $S/repo:/w -w /w lab-n8-poliglota:local bash -c '... bash tools/ci/compuerta.sh --staged'
== 1. Texto (N2)
texto: OK
== 2. Toolchain (N3): lo instalado contra los archivos del repo
FileNotFoundError: [Errno 2] No such file or directory: 'global.json'
tools/ci/compuerta.sh: line 14: .nvmrc: No such file or directory
tools/ci/compuerta.sh: line 15: tools/gen/.python-version: No such file or directory
tools/ci/compuerta.sh: line 18: cd: tools/gen: No such file or directory
tools/ci/compuerta.sh: line 21: $3: unbound variable
rc=1
--- mismo verificador desde la raíz:
$ python3 tools/ci/verificar-texto.py .
texto: src/App/Alarma.cs: no es UTF-8 (byte 0xc7 en 22)
texto: 1 violación(es)
```

`verificar.sh` hace `cd "$(dirname "$0")"`: en `tools/ci/` el paso de texto revisa sólo esa carpeta y **da OK con el cp1252 del caso en el repo**; el paso 2 aborta por `set -u`. Además el inventario está escrito para N8 (`dotnet restore src/Saludo`, línea 25) e ignora `--staged`/`--base`.

**X2. `verificar.sh` sin las herramientas.** La solución N8 en la imagen oficial `dotnet/sdk:8.0` (sin Python, Node ni uv):

```text
== 1. Texto (N2)
./verificar.sh: line 10: python3: command not found
== 2. Toolchain (N3): lo instalado contra los archivos del repo
./verificar.sh: line 13: python3: command not found
./verificar.sh: line 21: $3: unbound variable
rc=1
```

**X3. La prueba de regresión del `.csproj` (§11.2.5), tal como la receta la describe.** Copia limpia de `N8-…/solucion/` en un repo git, imagen `lab-n8-poliglota:local`: `./build.sh` y, tras `git clean -fdx`, `dotnet build src/Saludo -c Release -p:ContinuousIntegrationBuild=true` (con `ConstruirPoliglota` por defecto, `true`):

```text
build.sh rc=0
csproj rc=0
build.sh=ab218c16  csproj(ConstruirPoliglota=true,CI=true)=ab218c16
```

Las dos fronteras dan la misma DLL. El hash difiere del `4dd5d90f…` de la guía porque cambia la ruta, como la guía misma advierte.

## Hallazgos

### arquitecto-software-01 · S2 · E1 — El camino de A.11 para proyectos en subcarpetas deja la compuerta en verde ante el cp1252 del caso, y N8 no es «el mismo diseño» que N7

- **Ubicación:** A.11, párrafo «Qué se copia y adónde» (l. 2755) y comentario del esqueleto (l. 2748-2749); §10.2.2, «Alcance declarado» (l. 1849); §11.5, extracto de `verificar.sh` (l. 2300-2312); §11.7.
- **Ancla:** «o, si los proyectos viven en subcarpetas, `verificar.sh` de N8 con su inventario de rutas (§10.2.2)»; «`compuerta.sh` (N7) y `verificar.sh` (N8) son dos ejemplos del mismo diseño para dos disposiciones»; «la compuerta dice «falta `python3`» y no «la política no se cumple»».
- **Evidencia:** X1 y X2. El repo del Anexo A es exactamente la disposición en subcarpetas; seguida la instrucción, el paso de texto da `texto: OK` con un `.cs` en cp1252 (falso verde de capa 1, la falla del caso) y el paso de toolchain aborta. N8 no tiene alcance (`--staged`, `--base`), no distingue «falta la herramienta» de «violación» (aborta con `unbound variable`) y corre `npm ci`, `dotnet restore` y `uv sync` completos en cada commit si se lo engancha como hook. Es decir, la guía remite al lector a un script que no cumple tres propiedades que §10.2.2 atribuye a «la compuerta única».
- **Dirección:** o bien (a) A.11 deja de ofrecer `verificar.sh` como pieza para copiar y lo presenta como lo que es —la compuerta *de la solución de referencia*, con rutas fijas, ejecutada desde su raíz—, y para subcarpetas propone el criterio de §10.2.2 (inventario explícito o descubrimiento que falle) sobre la compuerta de N7; o bien (b) se ajusta `verificar.sh` en el laboratorio para que resuelva la raíz con `git rev-parse --show-toplevel`, lea el inventario de un archivo o de variables, acepte `--staged`/`--base` y nombre la herramienta faltante, y se agrega a EA-1 un paso que la corra dentro del repo de plantillas con un `.cs` cp1252 (rojo esperado). En los dos casos, §10.2.2 deja de decir «el mismo diseño» hasta que lo sea.

### arquitecto-software-02 · S2 · E2 — La CI que §11.2.7 y §12 recomiendan (build + registro con digest + SBOM) no tiene plantilla: A.12 sólo corre la compuerta, y el digest de la imagen no llega al registro

- **Ubicación:** A.12 (l. 2759-2789); §11.8 (l. 2372); §11.2.7 (l. 2173); §12, paso 8a (l. 2393) y contrato YAML (l. 2410-2411); `Examples/N8-…/solucion/registrar-entorno.sh` l. 9.
- **Ancla:** §11.2.7 «Imagen única cuando el artefacto es uno: el job corre `./build.sh`»; §11.8 «Todas las del Anexo A, que forman juntas un repositorio políglota mínimo»; §12 8a «registro del entorno (… digest de la imagen, commit y árbol limpio) y SBOM con alcance declarado»; A.12 sólo tiene `tools/ci/compuerta.sh --base …` y `tools/ci/compuerta.sh`; `registrar-entorno.sh`: `echo "imagen=${IMAGEN_DIGEST:-desconocida}"`.
- **Evidencia (E2, lectura de código y texto):** A.12 se llama `compuerta` y no construye, no registra el entorno, no genera SBOM ni adjunta nada al artefacto; el repo de plantillas no tiene orquestador (`build.sh`) ni `registrar-entorno.sh`. El único workflow que corre `build.sh` y pasa `IMAGEN_DIGEST` es `N8-…/solucion/ci/github-actions.ejemplo.yml`, que la guía no cita y que usa acciones por etiqueta (`actions/checkout@v5`, `actions/attest@v4`), contra la regla de §10. En ese ejemplo el digest se escribe dos veces a mano (`container.image` y `env.IMAGEN_DIGEST`); fuera de él, el registro dice `imagen=desconocida`. Así, el elemento (b) de §11.2.8 —«los materiales del entorno … que registra un paso del pipeline»— y el criterio 4 de §9.6 quedan sin mecanismo mostrado para la disposición recomendada.
- **Dirección:** completar A.12 con un segundo job (o pasos posteriores) que corra el orquestador y publique artefacto + registro + SBOM, con las acciones por SHA; decir de dónde sale el digest de la imagen del job y declararlo una sola vez (si la plataforma no lo expone dentro del contenedor, rotularlo **[no verificado]** y mostrar la duplicación como deuda explícita, con una comprobación en la compuerta de que ambos valores coinciden). Si se decide no ampliar A.12, corregir §11.8: el Anexo A da la compuerta y la imagen, no la CI de publicación.

### arquitecto-software-03 · S3 · E2 — El modelo integrado y la tabla de decisiones ofrecen «BuildKit para procedencia», que no existe en la disposición que ellos mismos recomiendan para un solo artefacto

- **Ubicación:** §11.2.9, nodo `PRV` del diagrama (l. 2212); §11.3, fila «SBOM» de la tabla de decisiones (l. 2246) frente a la fila «Imagen · Única» (l. 2244); §11.6, cuarta pregunta (l. 2343).
- **Ancla:** diagrama: «procedencia firmada por la plataforma (commit)<br/>o de BuildKit (bases por digest, sin firma)»; tabla: «Uno de los dos primeros para los locks; BuildKit para procedencia»; §11.2.8: «hay entonces tres piezas distintas … (a) … (b) … (c) cómo se atan».
- **Evidencia:** la procedencia de BuildKit con las cuatro bases por digest sale de `docker buildx build … -f imagen/Dockerfile.por-componente` (§11.5, E8-6), es decir, de la variante por componente. Para un artefacto único la guía recomienda imagen única con `./build.sh` en un *job container* (§11.2.7, §11.3, §11.6 última pregunta), donde el artefacto no se construye con BuildKit. El texto de §11.2.8 ya lo resuelve con (a)+(b)+(c), incluida «la atestación de la imagen del job, enlazada por su digest»; el diagrama y la tabla, que es lo que el lector de consulta mira primero, siguen con la versión anterior («o»), presentando como alternativas piezas que §11.2.8 dice que hay que atar.
- **Dirección:** en el diagrama, reemplazar `PRV` por los tres elementos de §11.2.8 (procedencia de la plataforma · materiales del entorno registrados · vínculo firmado o atestación de la imagen del job); en la tabla de §11.3, fila SBOM/procedencia: «imagen única → (a)+(b)+(c); por componente → además BuildKit `mode=max` como materiales». Mismo ajuste en la respuesta de §11.6.

### arquitecto-software-04 · S3 · E2 — Matriz y actores: §2.4 no refleja la decisión de procedencia ni el reparto que fija §11.4

- **Ubicación:** §2.4, segunda tabla (l. 247-252) frente a §11.4 tabla de actores (l. 2258-2263) y §2.3 (l. 223-224).
- **Ancla:** §2.4: «ACT-ARQ | §3, §5, §6, §7, §11 | — | coherencia entre capítulos» y «ACT-OPS | §8, §9, §10»; §2.3: ACT-ARQ decide «la estrategia de imagen (única o por componente)»; §11.4: «ACT-OPS | Construye y mantiene el Dockerfile multi-runtime o las cuatro bases por digest, según la estrategia que decide ACT-ARQ; el job con `build.sh`; SBOM y procedencia» y «ACT-ARQ | … alcance de los SBOM».
- **Evidencia:** en §2.4 ACT-ARQ no «lidera» §8 ni §9, pero §2.3 y §11.4 le dan la decisión de imagen y el alcance de los SBOM, que son contenido de §8.2.6/§11.2.6 y §9/§11.2.8; y la columna «Aplica» de ACT-ARQ es «—», aunque §12 le asigna pasos 1, 2, 3, 5, 6, 9 y 10. La tabla de §2.4 es la que el lector de consulta usa para saber qué leer.
- **Dirección:** en §2.4, ACT-ARQ lidera también las decisiones de §8 (imagen única o por componente) y de §9 (alcance del SBOM, nivel de procedencia exigido), y ACT-OPS las implementa; o una nota bajo la tabla que distinga «decide» de «lidera el capítulo». Llenar «Aplica» de ACT-ARQ con los pasos de §12 que ejecuta.

### arquitecto-software-05 · S4 · E1 + E2 — §11.5 contradice la prueba de regresión de §11.2.5 en un comentario

- **Ubicación:** §11.5, comentario del `.csproj` (l. 2271); §11.2.5 (l. 2143); §11.2.9, nodo `NET` (l. 2205).
- **Ancla:** «true en la estación (F5); la CI pasa -p:ConstruirPoliglota=false y usa build.sh» frente a «se comprueba en la CI como **prueba de regresión del `.csproj`**, con la misma imagen corriendo `dotnet build -c Release -p:ContinuousIntegrationBuild=true` con `ConstruirPoliglota=true` y `build.sh`».
- **Evidencia:** X3 confirma que la prueba de §11.2.5 funciona (misma DLL `ab218c16` por los dos caminos), así que la CI recomendada **sí** construye con `ConstruirPoliglota=true` en un paso. El comentario y el nodo del diagrama sólo muestran el camino B.
- **Dirección:** comentario: «la CI de publicación pasa `-p:ConstruirPoliglota=false` (build.sh); la prueba de regresión lo deja en `true` (§11.2.5)». El diagrama ya tiene la flecha `MSB -.-> NET`; basta con que el rótulo del nodo `NET` no excluya el otro camino.

### arquitecto-software-06 · S4 · E2 — El capítulo central queda con una sola consigna de práctica (deuda D-4), y la que falta es la que probaría la integración

- **Ubicación:** §11.9 (l. 2374-2376) frente a §0.2 (l. 68: «**Práctica** (dos consignas sobre experimentos que ya existen…)»).
- **Ancla:** §11.9 tiene sólo «1. Copiá la compuerta de N7 …».
- **Evidencia:** conteo directo; registrado como D-4 en `05-Aplicacion.md` §3 y §8. Los demás capítulos 4 a 10 tienen dos.
- **Dirección:** restituir la consigna de E8-1 con el texto que propuso el juez de costo-beneficio (`04-Aprobacion-costo-beneficio.md`, P-14 punto 2: fallan cinco —`saluda.py`, `json.load`, `tomllib`, `JSON.parse` y `.nvmrc`— y `hola.sh` da OK con error en stderr), o, mejor para el mandato del capítulo, una consigna sobre X1 una vez resuelto el hallazgo 01: «enganchá la compuerta en el repo del Anexo A con un `.cs` cp1252 y predecí qué paso la pone en rojo».

## Revisado y bien

1. **§11.2.5, la prueba de regresión del `.csproj`.** La receta, tal como está escrita, reproduce: las dos fronteras dan la misma DLL en la misma imagen y la misma ruta (X3). El criterio «se prueba en la CI, no en la estación» y la aclaración de lo que demuestra («que los targets de A no divergen de B») resuelven sin exceso el AS-06 del ciclo 1.
2. **§11.2.8, las tres piezas de la procedencia.** La guía ya no promete que una sola atestación firmada nombre el entorno por digest: separa lo que firma la plataforma (commit, workflow; entorno opcional [B202]), lo que registra el pipeline y cómo se atan, y rotula el vínculo como **[criterio]**. Es la vara de §9.2.4 aplicada a §11, que era el reclamo de AS-02.
3. **§11.2.7 y la última pregunta de §11.6.** La decisión de imagen para la CI quedó coherente con §8.2.6 y §11.3: imagen única si el artefacto es uno, por componente sólo con publicación separada y con la compuerta completa corrida antes; la contradicción de AS-03 no reaparece en el cuerpo (sí en el diagrama y la fila de la tabla, hallazgo 03).

## Solicitudes de convocatoria

- **Senior .NET:** la deuda D-1 sigue en la plantilla versionada: `Examples/A-plantillas/repo/Directory.Build.targets` mantiene `Condition="'$(OutputType)' == 'Exe'"` (deja afuera `WinExe`). Fuera de mi mandato; sólo constato que no se aplicó.
