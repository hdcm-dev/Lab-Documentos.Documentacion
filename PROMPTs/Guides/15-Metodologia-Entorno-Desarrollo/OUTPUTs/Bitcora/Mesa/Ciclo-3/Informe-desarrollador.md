# Mesa · Ciclo 3 · Informe del especialista «Desarrollador de código»

> Fecha: 2026-10-09. Artefacto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (1.0.0, 3605 líneas).
> Mandato: que los snippets y las plantillas sean correctos y copiables; correr en docker los experimentos que se puedan; detectar snippets que no compilan, rutas rotas y comandos que fallan.
> Revisión a ciegas: no se leyeron informes del ciclo 3. Del ciclo 2 se leyeron `05-Aplicacion.md` (lo aplicado, y lo que §6 deja abierto) y el informe propio del ciclo 2. No se re-litiga nada de lo cerrado.
> Todas las corridas se hicieron sobre copias en el scratchpad de la sesión (`…/scratchpad/c3dev/`). No se modificó `Examples/` ni la guía.

## Corridas de esta revisión

| Qué | Comando | Resultado |
|---|---|---|
| EA-1 completo | `bash verificar.sh` sobre una copia de `Examples/` | rc=0. La salida es igual a `salidas/EA-1-plantillas.txt` salvo dos líneas: el `commit=` del repo de juguete y `out/App.dll`, que depende del commit. Las otras 114 líneas coinciden. |
| §1.2, los dos `docker run` tal cual | `python generar.py` + `sh e1-roslyn.sh` con SDK 8 | rc=0. Las 17 líneas del extracto (sin `...`) aparecen literales en la salida (`grep -xF`). |
| §8.5, el `devcontainer.json` tal cual | `npx -y @devcontainers/cli@0.89.0 up` | `"outcome":"success"`, uid 0, `v24.21.0`, `core.hooksPath=.githooks`. |
| SHA de las acciones y de `pre-commit-hooks` | `git ls-remote` de cada tag | Los siete coinciden: checkout v7.0.1, setup-dotnet v6.0.0, setup-node v7.1.0, setup-python v7.0.0, setup-uv v10.2.0, attest v4.2.2 y pre-commit-hooks v6.0.0. |
| Entradas usadas en A.12 y §9.5 | `action.yml` en el SHA fijado | Existen `global-json-file`, `node-version-file`, `python-version-file`, `working-directory` (setup-uv) y `subject-path`. |

## Hallazgos

### desarrollador-01 · S2 · E1 — A.17 depende de que A.12 se guarde como `ci.yml`, y la guía nunca lo dice: con otro nombre, el registro afirma «runner sin contenedor»

- **Ubicación:** A.12, bloque YAML (`name: compuerta`; no da la ruta del archivo); A.17, línea `img=$(sed -n … .github/workflows/ci.yml | head -1)`.
- **Ancla:** A.12 dice «El digest se declara sólo acá: lo lee registrar-entorno.sh (A.17)». Ningún lugar de la guía nombra `.github/workflows/ci.yml` fuera del `sed` de A.17 (`grep -n 'ci\.yml'` da sólo L3047).
- **Experimento:** copia de `A-plantillas/repo` con el workflow renombrado a `.github/workflows/compuerta.yml`, el nombre que sugiere `name: compuerta`. Después, commit y `sh tools/ci/registrar-entorno.sh`:

```text
sed: no se puede leer .github/workflows/ci.yml: No existe el fichero o el directorio
imagen=NO DECLARADA (runner sin contenedor: capa 4 en el log «Set up job»)
```

- **Impacto:** el job corre en el contenedor por digest, pero el registro del entorno, que es la pieza de procedencia del paso 8a, afirma lo contrario. `set -eu` no lo frena, porque el estado del pipeline es el de `head`. EA-1 no lo ve porque su repo usa justo `ci.yml`. Es el punto 2 que `05-Aplicacion.md` §6 deja abierto para este ciclo.
- **Dirección:**
  - En A.12, nombrar la ruta en la primera línea del bloque: `# .github/workflows/ci.yml — Anexo A.12`.
  - En A.17, leer `WORKFLOW_FILE=${WORKFLOW_FILE:-.github/workflows/ci.yml}` y fallar si no existe, con `[ -f "$WORKFLOW_FILE" ] || { echo "registro: no existe $WORKFLOW_FILE" >&2; exit 1; }`, en vez de caer en «NO DECLARADA».
  - Agregar a EA-1 un paso con el archivo renombrado que exija rc≠0.

### desarrollador-02 · S3 · E1 — El `.pre-commit-config.yaml` de §10.5 no se puede instalar en un clon con `core.hooksPath`, que activan A.9, §8.5 y A.11

- **Ubicación:**
  - §10.5, bloque `.pre-commit-config.yaml`.
  - §10.6, la respuesta a «¿Uso pre-commit o un script propio?»: «*Aplica* al elegir cómo se instalan los hooks en las estaciones y el devcontainer».
  - Los `postCreateCommand` de §8.5 y A.9, y la activación de A.11.
- **Ancla:** `"postCreateCommand": "… && git config core.hooksPath .githooks && …"`, y en §10.5, «framework como orquestador».
- **Experimento** (pre-commit 4.6.2, la versión que cita la guía, en `lab-n2-texto:local`):

```text
$ git config core.hooksPath .githooks; pre-commit install
pre-commit 4.6.2
[ERROR] Cowardly refusing to install hooks with `core.hooksPath` set.
hint: `git config --unset-all core.hooksPath`
rc=1
```

- **Impacto:** quien sigue la guía y adopta pre-commit en el devcontainer (el caso que §10.6 trata) recibe un error, y la guía no dice cuál de los dos mecanismos se queda. Si saca `core.hooksPath` para instalarlo, el hook de A.11 deja de correr. Si no lo saca, pre-commit nunca corre en local. E7-2 no lo detecta porque usa `pre-commit run`, no `install`.
- **Dirección:** declarar en §10.5 que las dos vías se excluyen. Una opción es `.githooks/pre-commit` (A.11) como entrada única, sin `pre-commit install`. La otra es pre-commit como orquestador: `pre-commit install` en lugar de `git config core.hooksPath .githooks` en el `postCreateCommand`, con el hook local `compuerta-entorno` como entrada única. Hace falta una línea en §10.5 y otra en la pregunta de A.11.

### desarrollador-03 · S3 · E2 — La variante «runner alojado» de A.12, aplicada como dice el texto, pierde `SOURCE_DATE_EPOCH`, que el paso 8a exige

- **Ubicación:** A.12, el párrafo y el bloque de la variante con runner alojado (~L2910–2925); §12, paso 8a.
- **Ancla:** «Variante con runner alojado, que alcanza para 8a (§8.2.2); reemplaza `container:` y los pasos previos a la compuerta». En el bloque principal, los pasos previos a la compuerta son el `checkout` y `- run: echo "SOURCE_DATE_EPOCH=$(git log -1 --pretty=%ct)" >> "$GITHUB_ENV"`. La variante trae `checkout`, cuatro `setup-*` y `pip install`, pero no esa línea. §12 8a pide «`ContinuousIntegrationBuild`, `SOURCE_DATE_EPOCH`, registro del entorno…».
- **Impacto:** el workflow que queda de seguir la instrucción al pie de la letra no cumple el paso para el que se ofrece. En .NET la consecuencia es menor, pero en `npm pack` y en las ruedas de Python cambia la fecha incrustada (§9.2.2).
- **Dirección:** agregar al final del bloque de la variante el mismo `- run: echo "SOURCE_DATE_EPOCH=…" >> "$GITHUB_ENV"`, o cambiar la frase a «reemplaza `container:` y el `checkout`; el paso de `SOURCE_DATE_EPOCH` se conserva».

### desarrollador-04 · S3 · E1 — El snippet de §7.5 corre `dotnet restore --locked-mode` en la raíz, y en el diseño de las plantillas de la propia guía falla con MSB1003

- **Ubicación:** §7.5, segundo bloque `bash` («Compuerta de restauración estricta para los tres ecosistemas»).
- **Ancla:** `dotnet restore --locked-mode          # NU1004 / NU1403 si el lock no coincide`, junto a `( cd web && npm ci )` y `( cd tools/gen && uv sync --locked )`. Las dos líneas siguientes usan la disposición de `A-plantillas/repo/`, que no tiene `.sln` en la raíz.
- **Experimento** (copia de `A-plantillas/repo`, `mcr.microsoft.com/dotnet/sdk:8.0`):

```text
$ dotnet restore --locked-mode
MSBUILD : error MSB1003: Specify a project or solution file. The current working directory does not contain a project or solution file.
rc=1
$ dotnet restore src/App --locked-mode -v q
rc=0
```

- **Impacto:** el comando que se presenta como la compuerta, «misma en local y en CI», da rojo por una razón que no es deriva del lock. El lector lo puede tomar por la señal NU1004 que el comentario anuncia.
- **Dirección:** escribir el destino explícito, `dotnet restore src/App --locked-mode` o `dotnet restore <Solución>.sln --locked-mode`, con un comentario: «sin .sln en la raíz, indicar el proyecto; la compuerta de A.11 los encuentra sola».

### desarrollador-05 · S3 · E1 — El guardián del paso 5 de §5.2.6 hace `exit 1`: pegado en una terminal, la cierra justo cuando debía avisar

- **Ubicación:** §5.2.6, paso 5 «Refrescar los working trees», primer bloque `bash`.
- **Ancla:** `|| { echo "commiteá o guardá con git stash antes de seguir" >&2; exit 1; }`
- **Experimento:** repo con un cambio sin commitear. Las dos primeras líneas del bloque y un `echo` se pasan a un `bash -i`:

```text
commiteá o guardá con git stash antes de seguir
exit
estado de salida del shell interactivo: 1      # el echo "la terminal sigue abierta" nunca corre
```

- **Impacto:** el bloque se presenta como pasos que «cada desarrollador hace una vez», y lo natural es pegarlo en la terminal. En el único caso en que el guardián actúa (árbol sucio), la ventana se cierra antes de que se lea el mensaje. Si se pega en un shell que no termina, como el de un IDE, quedan además los `git pull` siguientes sin protección.
- **Dirección:** usar una forma que no mate el shell:

```bash
if git diff --quiet && git diff --cached --quiet; then
  git pull --ff-only && git rm -rq --cached . && git reset -q --hard
else echo "commiteá o guardá con git stash antes de seguir" >&2; fi
```

Otra opción es envolver el bloque en `( … )`. El `validaciones` del contrato YAML no cambia.

### desarrollador-06 · S4 · E1 — A.10 afirma que la imagen de N8 «difiere sólo en `NODE_IMAGE`», pero además no instala `EditorConfig`

- **Ubicación:** A.10. Está en el comentario de la primera línea del Dockerfile y en el párrafo siguiente («La de `Examples/N8-integracion-poliglota/imagen/Dockerfile` … difiere sólo en `NODE_IMAGE`»).
- **Experimento:**

```text
$ diff A-plantillas/repo/imagen/Dockerfile N8-integracion-poliglota/imagen/Dockerfile
7c7  < ARG NODE_IMAGE=node:24-bookworm-slim@…   > ARG NODE_IMAGE=node:22-bookworm-slim@…
35d34 < # EditorConfig: lo importa el paso de texto de la compuerta (A.11).
39d37 <  && uv pip install --system --break-system-packages --python /usr/local/bin/python3 EditorConfig==0.17.1 \
```

- **Impacto:** quien tome la imagen de N8 como base de su CI, guiado por esa frase, obtiene una compuerta en rojo en el paso de texto, porque falta el módulo `editorconfig`. Es el defecto que el ciclo 2 cerró en A.10 y que sigue vivo en la copia de N8. La afirmación es falsa tal como está escrita.
- **Dirección:** cambiar la frase y el comentario a «difiere en `NODE_IMAGE` y en que no instala `EditorConfig` (N8 no corre la compuerta adentro)». Otra opción es agregar la misma línea al Dockerfile de N8 y regenerar E8-3, E8-5 y E8-6, lo que cambia el digest; no se recomienda por el costo.

## Revisado y bien

1. **EA-1 reproduce.** Corrido completo hoy: rc=0, y 114 de 116 líneas iguales a `salidas/EA-1-plantillas.txt`; sólo cambian el commit del repo de juguete y el hash de la DLL, que depende de él. Los 22 bloques-archivo del Anexo A que comprobé (A.12 y A.17 con `diff`) son iguales al laboratorio.
2. **El caso de §1.2 se reproduce copiando los dos comandos.** Las 17 líneas del extracto aparecen literales en la salida nueva.
3. **Los pines y el devcontainer de §8.5 son copiables.** Los siete SHA de acciones y `rev` coinciden con su tag (`git ls-remote`), las entradas usadas existen en el `action.yml` de cada SHA, y el `devcontainer.json` de §8.5 levanta con `outcome: success` y el hook activado.

## Solicitudes de convocatoria (fuera de mandato)

- **Edición / verificación de evidencia:** el encabezado (L26) dice «73 experimentos ejecutables (Anexo E)». El Anexo E tiene 65 filas, algunas con dos IDs (E5-5/E5-5b, E6-2/E6-2b, E7-5/E7-5b), y `05-Aplicacion.md` §5 cuenta 71 IDs. Conviene que alguien concilie la cifra. No lo verifiqué.
