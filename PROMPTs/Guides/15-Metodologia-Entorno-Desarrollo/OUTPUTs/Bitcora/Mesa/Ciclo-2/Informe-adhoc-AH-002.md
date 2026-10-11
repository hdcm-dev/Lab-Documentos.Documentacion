# Informe AH-002: cadena de suministro y gobierno de la CI (ciclo 2)

Especialista ad hoc en integridad, procedencia y compuertas de plataforma. Revisé a ciegas la guía corregida (`Metodologia-Entorno-Desarrollo-Guide.md`, 3391 líneas, 1.0.0-rc.1), leyéndola como obra terminada. No re-litigo lo que se cerró en el ciclo 1 (C1-17, C1-18 b, C1-19, C1-20, C1-21 b, C1-32, C1-33). Consulté las fuentes el 2026-10-09. La evidencia E1 está en `Ciclo-2/evidencia-adhoc-AH-002/`.

Pregunta: ¿cada garantía que la guía atribuye a un mecanismo de integridad, procedencia o compuerta de plataforma coincide con lo que realmente otorgan su especificación o su plataforma? ¿Y dice la guía qué no protege ese mecanismo?

## Hallazgos

### adhoc-AH-002-01: el chequeo requerido de GitHub no dice quién puede ponerlo en verde (S2, E4)

- **Ubicación:** §10.2.7, tabla, fila «Rama protegida con chequeo requerido (GitHub…)» (L1904), y el párrafo **[criterio]** «"Impide" vale de verdad cuando…» (L1910).
- **Ancla:** la fila dice «Qué impide: El merge o el push sin el chequeo aprobado». La lista del párrafo cubre la revisión de dueños, la aprobación del último push y la inclusión de los administradores.
- **Evidencia:** GitHub Docs, About protected branches ([B177], 2026-10-09). Al exigir un chequeo, se puede elegir una app «as the expected source of status updates»: «If the status is set by any other person or integration, merging won't be allowed. If you select "any source", you can still manually verify the author of each status.»
- **Problema:** un chequeo requerido identifica el estado por su nombre (`compuerta`). Si no se fija una fuente esperada, quien tenga permiso de escritura puede publicar un estado `success` con ese nombre sobre el commit del PR, por la API o desde otro workflow, sin correr la compuerta. Ese «qué no impide» falta en la fila, y la lista de condiciones con las que «"impide" vale de verdad» no lo cubre.
- **Dirección:** agregar a «Qué no impide» de la fila: «un estado con el mismo nombre publicado por otra fuente, si no se fijó la fuente esperada [B177]». Sumar a la lista de L1910: «y el chequeo exige como fuente la app de GitHub Actions».

### adhoc-AH-002-02: el `builder.id` de BuildKit se completa con un parámetro, y su valor lo escribe quien invoca la build (S3, E1 + E4)

- **Ubicación:** §9.2.4, L1646: «Llega a L1 cuando la plataforma de CI que corre BuildKit la identifica en `builder.id`; cómo completarlo en BuildKit no se verificó **[no verificado]**». Anexo F, L3371: «cómo completar `builder.id` en BuildKit (§9.2.4)». Es la pregunta abierta C1-Q07.
- **Evidencia E2:** Docker Docs, SLSA definitions (https://docs.docker.com/build/metadata/attestations/slsa-definitions/, 2026-10-09). Sobre `builder.id`: «The field is set to the URL of the build, if available. This value can be set using the `builder-id` attestation parameter». El ejemplo de la página es la URL de una corrida de GitHub Actions.
- **Evidencia E1** (`evidencia-adhoc-AH-002/e1-builder-id.txt`, buildx v0.35.0 y BuildKit v0.33.1, el mismo builder de N8):
  ```text
  --provenance=mode=max,version=v1                                    -> runDetails.builder= {'id': ''}
  --provenance=mode=max,version=v1,builder-id=https://ci.ejemplo/runs/42 -> runDetails.builder= {'id': 'https://ci.ejemplo/runs/42'}
  GITHUB_ACTIONS=true … GITHUB_RUN_ID=777 (sin builder-id)            -> runDetails.builder= {'id': ''}
  ```
- **Problema:** la guía deja sin verificar algo que se resuelve con un parámetro documentado y probado. Además, no dice lo que el experimento sí muestra: BuildKit escribe tal cual el texto que le pasa el paso que lo invoca, y en una estación buildx no lo toma de las variables `GITHUB_*`. Completado así, `builder.id` es una declaración del inquilino. Da la forma de L1 (L1 no exige autenticidad), pero no identifica a la plataforma ante un consumidor. Sólo lo hace si se empareja con la identidad de quien firma, que es lo que SLSA pide al verificar [B09].
- **Dirección:** en §9.2.4, reemplazar «cómo completarlo en BuildKit no se verificó» por «se completa con el parámetro `builder-id=` de `--provenance` (o `--attest type=provenance,…`) [Docker, SLSA definitions]; el valor es el que pasa el paso que invoca la build (E1), así que vale como identidad sólo emparejado con la del firmante». Sacar la mención del Anexo F (allí queda sólo la firma sin clave). Si se cita, agregar la fuente nueva al Anexo D.

### adhoc-AH-002-03: «`pre-receive`: no impide nada» exagera la garantía (S3, E4)

- **Ubicación:** §10.2.7, fila «`pre-receive` en un servidor propio» (L1906).
- **Ancla:** «Qué no impide: Nada mientras el hook corra en el servidor; su tiempo está acotado en GHES».
- **Evidencia:** GitHub Enterprise Server 3.22, Working with pre-receive hooks (2026-10-09): el administrador del sitio crea los hooks y «may also allow organization or repository administrators to enable or disable hooks for specific scopes». About pre-receive hooks ([B188], 2026-10-09): «Timeouts: Push may fail regardless of enforcement configuration».
- **Problema:** el hook protege mientras esté habilitado. En GHES, el administrador del sitio puede delegar en administradores de organización o de repositorio la facultad de deshabilitarlo, y en un servidor propio puede hacerlo quien lo administra. Es el mismo *bypass* que la fila de GitHub sí declara para los administradores. Además, el hook sólo ve lo que llega por `push`. «Nada» es más de lo que el mecanismo otorga.
- **Dirección:** reemplazar «Nada mientras…» por «A quien puede deshabilitarlo: el administrador del servidor y, en GHES, los administradores de organización o de repositorio si se les delegó [B188]; su tiempo está acotado en GHES (abajo)». Si §10.2.8 lo menciona, la regla de quién tiene *bypass* queda alineada.

### adhoc-AH-002-04: ningún bot de A.13 actualiza el digest de `container:` que §8.2.2 pone bajo «digest + bot» (S3, E4)

- **Ubicación:** §8.2.2, puntos 1 y 3 (L1372, L1374); §8.7 (L1496); A.12 (L2777); A.13 (L2791–L2833).
- **Ancla:** L1372: «Digest en todo lo que construye artefactos publicados: el `FROM` … y `container.image` de la CI». L1374: «un bot o un trabajo programado propone el digest nuevo». A.12: `container: ghcr.io/org/imagen-ci@sha256:…`.
- **Evidencia:** GitHub Docs, Dependabot supported ecosystems ([B107], 2026-10-09). `docker` actualiza Dockerfiles y «Docker image tags in Kubernetes manifests … Deployment YAML files or Helm charts». `github-actions` «only supports updates to GitHub Actions using the GitHub repository syntax, such as `actions/checkout@v6`». Ninguno de los dos menciona `container:` ni `services:` de un workflow. Renovate, manager github-actions (https://docs.renovatebot.com/modules/manager/github-actions/, 2026-10-09): extrae el depType `container` («A Docker image specified in a job's `container:` field») y `service`.
- **Problema:** con el `dependabot.yml` de A.13, el bot `docker` propone las bases nuevas de `imagen/Dockerfile`. La imagen de CI reconstruida, en cambio, entra al workflow por un digest que ningún ecosistema de Dependabot documenta actualizar. El eslabón «base nueva → imagen nueva → digest nuevo en `container:`» queda a mano, que es justo el caso que §8.2.2 llama «congeló vulnerabilidades». Que Dependabot no lo cubra es una inferencia por omisión de su documentación, no una frase explícita.
- **Dirección:** en A.12/A.13 decir quién mueve ese digest. Puede ser el workflow que publica la imagen, que abre el PR con el digest nuevo («trabajo programado» del punto 3), o Renovate, que documenta `container:`. Si no, rotular **[no verificado]** que Dependabot lo actualice.

### adhoc-AH-002-05: A.12 no podría descargar la imagen privada que nombra (S3, E4)

- **Ubicación:** A.12, L2770–L2777.
- **Ancla:** `permissions:` → `contents: read` y `container: ghcr.io/org/imagen-ci@sha256:…`, sin `credentials`. El comentario dice «publicada en el registro del equipo».
- **Evidencia:** GitHub Docs, Running jobs in a container (2026-10-09): «If the image's container registry requires authentication to pull the image, you can use `jobs.<job_id>.container.credentials`», con el ejemplo `username: ${{ github.actor }}` / `password: ${{ secrets.github_token }}`. Working with the Container registry (2026-10-09): «When you first publish a package, the default visibility is private». Workflow syntax, `permissions` (2026-10-09): «all of those that are not specified are set to `none`».
- **Problema:** en el caso de la guía (repositorio privado de una organización) la imagen publicada en GHCR nace privada. El job declara sólo `contents: read`, así que `packages` queda en `none`, y no pasa credenciales. Tal como está, la plantilla no descarga su propia imagen. El rótulo «Ilustrativo: … no ejecutado en GitHub» no avisa ese prerrequisito.
- **Dirección:** agregar `packages: read` a `permissions` y `credentials` con `github.actor` y `secrets.GITHUB_TOKEN` al `container:` (o declarar que la imagen es pública). Sumar a las «Preguntas» de A.12: «¿la imagen es privada y el job tiene con qué descargarla?».

### adhoc-AH-002-06: la fila de GitHub cita la fuente de Azure DevOps, y Azure DevOps queda sin fila (S4, E2)

- **Ubicación:** §10.2.7, L1902 (prosa) y fila de GitHub (L1904).
- **Ancla:** la columna «Evidencia» de la fila de GitHub dice «[B177][B186][B200]», y B186 es «Microsoft Learn: Azure DevOps branch policies» (Anexo D). La prosa nombra Azure DevOps («con permisos de *bypass* explícitos [B186]»), pero la tabla «qué impide / qué no impide» no tiene fila para esa plataforma.
- **Problema:** una cita cruzada en la fila de GitHub, y una plataforma que el texto presenta sin el «qué no impide» que la tabla da para las otras dos.
- **Dirección:** sacar [B186] de la fila de GitHub y agregar una fila de Azure DevOps (validación de build obligatoria, que impide completar el PR; no impide a quien tiene permiso de *bypass* [B186]), o dejar Azure DevOps sólo en la prosa y quitar la cita de la fila.

## Revisado y bien

1. **§10.2.7 después del ciclo 1:** coinciden con docs.github.com y docs.gitlab.com (2026-10-09) estos puntos: el `pull_request` que corre el *merge commit* del PR [B200]; `skipped` y `neutral` aceptados como verde; los administradores exentos por defecto [B177]; Pro como plan personal, con Team como mínimo para una organización; GitLab Free con «Pipelines must succeed», incluido el MR sin pipeline [B199].
2. **§8.2.2, §8.3, A.13 y Anexo F sobre los digests de Dependabot:** el rótulo ya es el mismo en los cuatro lugares («Docker lo documenta [B113]; GitHub no lo menciona [B107]; no observado»). Confirmé que la página de GitHub sigue hablando sólo de *tags* y SemVer para `docker`, y que A.13 ya incluye `docker` y excluye `devcontainers` en repos privados.
3. **§9.2.4 y §9.5 sobre niveles y firma:** coinciden con SLSA v1.2 y con docs.gitlab.com/ci/pipeline_security/slsa (2026-10-09) estos puntos: L1 no se alcanza con `builder.id` vacío; una clave propia es «a lo sumo, L1 firmado por un inquilino»; `verify-blob-attestation` no evalúa el contenido del predicado; la vía sin clave tiene un costo de privacidad en Rekor; GitLab declara «SLSA level 2 compliant provenance» generada por el runner y L3 con mayor aislamiento.

## Solicitudes de convocatoria

Ninguna.
