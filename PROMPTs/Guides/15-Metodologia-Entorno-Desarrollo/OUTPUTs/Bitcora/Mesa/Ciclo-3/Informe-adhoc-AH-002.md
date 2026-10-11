# Informe AH-002: cadena de suministro y gobierno de la CI (ciclo 3)

Soy el especialista ad hoc en integridad, procedencia y compuertas de plataforma. Revisé a ciegas la guía (`Metodologia-Entorno-Desarrollo-Guide.md`, 3605 líneas) como obra terminada. No leí informes de otros especialistas de este ciclo. Doy por cerrado lo que el ciclo 2 aplicó de mis hallazgos: C2-16, C2-17, C2-18, C2-19, C2-20 y C2-44. Lo verifiqué en §9.2.4, §8.2.2, A.12 y §10.2.7, y no lo vuelvo a discutir. Consulté las fuentes el 2026-10-09. La evidencia E1 está en `Ciclo-3/evidencia-adhoc-AH-002/`.

Pregunta: ¿cada garantía que la guía atribuye a un mecanismo de integridad, procedencia o compuerta coincide con lo que otorgan su especificación o su plataforma? ¿Y dice la guía qué no protege ese mecanismo?

## Hallazgos

### adhoc-AH-002-01: la plantilla `CODEOWNERS` deja sin dueño lo que desarma la compuerta y el mapeo de fuentes (S2, E1 + E2)

- **Ubicación:** A.14 (L2972–L2990); §10.2.7, párrafo **[criterio]** (L1978); §10.2.5, tabla (L1930–L1937); §10.2.8 (L1982–L1991).
- **Ancla:** L1978: «"Impide" vale de verdad cuando, además del chequeo requerido, la revisión de dueños es obligatoria sobre los archivos de la compuerta (`/.github/`, `/tools/ci/`, A.14)». §10.2.5 pide revisar `nuget.config`, `.npmrc`, los índices de uv, `.githooks/` y `.pre-commit-config.yaml` («quien puede cambiar la compuerta puede apagarla»).
- **Evidencia E1** (`evidencia-adhoc-AH-002/e1-codeowners-a14.txt`): apliqué la regla «gana el último patrón que coincide» [B178] al `CODEOWNERS` de `Examples/A-plantillas/repo` (idéntico a A.14), con `python3 -I owners.py Examples/A-plantillas/repo`:
  ```text
  @org/desarrollo    .githooks/pre-commit
  @org/desarrollo    Directory.Build.props      (RestoreLockedMode, NU1603 como error)
  @org/desarrollo    Directory.Build.targets    (RestorePackagesWithLockFile)
  @org/desarrollo    imagen/Dockerfile
  @org/desarrollo    nuget.config
  @org/desarrollo    web/.npmrc
  @org/desarrollo    tools/gen/pyproject.toml   (índices de uv)
  @org/desarrollo    web/package-lock.json, tools/gen/uv.lock, .nvmrc, tools/gen/.python-version
  ```
- **Problema:** con la plantilla tal como está, cualquier par de `@org/desarrollo` aprueba tres tipos de cambio:
  1. Un PR que saca `NU1603` de `WarningsAsErrors` o deja de activar el lock en `Directory.Build.targets`. Es la defensa doble de §7.2.1, y sin lock el paso «grafo» queda sin nada que verificar.
  2. Un PR que agrega en `nuget.config`, `.npmrc` o `[[tool.uv.index]]` un registro con patrón `*`. Es el control contra la confusión de dependencias de §7.6.
  3. Un PR que cambia el hook.

  §10.2.5 y §10.2.8 asignan esos archivos a la revisión de arquitectura o de plataforma, y §10.2.7 condiciona el «impide» a esa revisión. Pero la plantilla que el lector copia no la pide. Además, el lock con dueño es sólo el de NuGet (`**/packages.lock.json`).
- **Dirección:** completar A.14 (y `Examples/A-plantillas/repo/.github/CODEOWNERS`) con estas líneas:
  - `/Directory.Build.props`, `/Directory.Build.targets`, `/nuget.config`, `**/.npmrc`, `**/pyproject.toml`, `**/package-lock.json`, `**/uv.lock`, `/.nvmrc`, `**/.python-version` → `@org/arquitectura`;
  - `/.githooks/`, `/.pre-commit-config.yaml`, `/imagen/` → `@org/plataforma`.

  En L1978, cambiar «(`/.github/`, `/tools/ci/`, A.14)» por «(los de A.14: compuerta, workflows, registros y propiedades de restauración)».

### adhoc-AH-002-02: el camino «runner alojado» choca con cuatro reglas de la guía que siguen pidiendo digest sin excepción (S3, E2 + E4)

- **Ubicación:** §8.2.2, punto 1 (L1414) contra el punto 5 (L1418); §8.6 (L1539); §10.6 (L2079); §10.7 (L2089 y L2098).
- **Ancla:** L1414: «Para 8a también vale el runner alojado …: la imagen del runner (capa 4) flota». L1418: «**Etiqueta flotante sólo donde se quiere deriva**: nunca en la CI que publica artefactos». L1539: «Digest en todo lo que construye artefactos publicados». L2079: «Sí: acciones por SHA, … imagen de CI por digest». L2089: «fija por SHA o digest todo lo que ejecuta la compuerta».
- **Evidencia:** actions/runner-images, README ([B216], 2026-10-09): «We typically deploy weekly updates to the software on the runner images». Fijar un número de versión (`ubuntu-24.04`) sólo evita la migración de SO de `-latest`. La versión efectiva aparece en el log «Set up job» y no hay forma de fijarla.
- **Problema:** después de C2-13, la guía ofrece dos caminos de igual rango para 8a, pero sólo §8.2.2 punto 1 y A.17 registran la excepción. `runs-on: ubuntu-24.04` (A.12) es justamente la «etiqueta flotante en la CI que publica artefactos» que el punto 5 prohíbe. Quien sigue la variante de A.12 incumple los criterios de calidad de §10.7 y la respuesta de §10.6. A la inversa, quien lee §8.6 o §10.6 no se entera de que existe el otro camino. Es una contradicción interna sobre qué fija el mecanismo, no un desacuerdo de criterio.
- **Dirección:** en el punto 5 y en §8.6, agregar «salvo la capa 4 del runner alojado (camino 8a de §8.2.2): se actualiza semanalmente y no se fija; se registra (A.17) [B216]». En §10.6 y §10.7, cambiar «imagen de CI por digest» por «imagen de CI por digest, o runner alojado con su versión registrada». Es una cláusula por sitio y no agrega extensión neta relevante.

### adhoc-AH-002-03: la verificación de consumidor de `actions/attest` sólo comprueba el repositorio, y la guía no dice qué deja pasar (S3, E1 + E4)

- **Ubicación:** §9.5, bloque YAML (L1772); §9.3, fila «GitHub Actions» (L1725).
- **Ancla:** L1772: `# Consumidor:  gh attestation verify Pieza.1.4.0.nupkg -R <org>/<repo>`. L1725: «L2 por sí sola; L3 con *reusable workflows* [B158]».
- **Evidencia E1** (`evidencia-adhoc-AH-002/e1-gh-attestation-verify-help.txt`, gh 2.102.0, binario oficial, `gh attestation verify --help`):
  ```text
  The "actor identity" consists of:
  * the repository or the repository owner the artifact is linked with
  * the Actions workflow that produced the attestation (a.k.a the signer workflow)
  …
  At a minimum, this command requires either: … the `--repo` flag
  The more precisely you specify the identity, the more control you will
  have over the security guarantees offered by the verification process.
  Ideally, the path of the signer workflow is also validated using the
  `--signer-workflow` or `--cert-identity` flags.
  Please note: if your attestation was generated via a reusable workflow then
  that reusable workflow is the signer … you must use either the `--signer-workflow` or the `--signer-repo` flag.
  --source-ref string   Enforce that the git ref associated with the source repository matches the provided value
  ```
  Es lo mismo que dice el manual en cli.github.com/manual/gh_attestation_verify (2026-10-09).
- **Problema:** con sólo `-R`, cualquier workflow de cualquier rama de ese repositorio que corra `actions/attest` produce un artefacto que verifica. Alcanza con un `workflow_dispatch` o un push a una rama sin revisar. La línea de consumidor tampoco puede comprobar el L3 que la tabla atribuye a los *reusable workflows*, porque gh exige `--signer-workflow` o `--signer-repo` para ese caso. La guía sí declara este límite para cosign, en L1780: «NO verifica builder.id ni commit». También dice que SLSA pide aceptar sólo pares firmante/`builder.id` conocidos [B09]. Pero la línea de GitHub, que el lector toma como la verificación «buena», no lo declara.
- **Dirección:** cambiar la línea de consumidor por `gh attestation verify Pieza.1.4.0.nupkg -R <org>/<repo> --signer-workflow <org>/<repo>/.github/workflows/<publicar>.yml --source-ref refs/heads/main` (o `refs/tags/…`), con el comentario «sólo con `-R`, acepta cualquier workflow y rama del repo». En la fila de §9.3, agregar «el consumidor fija el workflow firmante (`--signer-workflow`); con *reusable workflows* es obligatorio». Si hace falta, citar el manual de gh como fuente nueva del Anexo D. Sigue siendo **Ilustrativo**: no corrí la verificación contra una atestación real.

### adhoc-AH-002-04: «no genera procedencia válida: no es una plataforma alojada» confunde L2 con validez (S4, E4)

- **Ubicación:** §9.4, fila ESC-04 (L1737).
- **Ancla:** «No genera procedencia válida: no es una plataforma alojada».
- **Evidencia:** la tabla de §9.2.4 de la propia guía, con base en SLSA v1.2 Build Track ([B07], 2026-10-09): L1 pide que «la plataforma genera automáticamente la procedencia (puede ser sin firma)», y la plataforma alojada recién aparece en L2. En §9.2.4, una BuildKit local con `builder-id=` produce procedencia con la forma de L1 (C2-16).
- **Problema:** «válida» no es una categoría de SLSA. La razón que se da («no es alojada») es la condición de L2, no la de toda procedencia. Contradice la escalera que la guía acaba de presentar y deja al lector sin saber si la procedencia de E6-5, generada fuera de la CI, «vale».
- **Dirección:** cambiar por «Su procedencia no pasa de L1 sin firma ni identifica a la plataforma (no es alojada, §9.2.4)», o simplemente «No es donde se genera la procedencia que se entrega (§9.2.4)».

## Revisado y bien

1. **§10.2.7 y §10.2.8 tras el ciclo 2:** la tabla «qué impide / qué no impide» tiene ahora las cuatro plataformas. Incluye el estado publicado por otra fuente, el *bypass* de Azure DevOps y la delegación de deshabilitar un `pre-receive` en GHES. La lista de condiciones de L1978 exige la app de GitHub Actions como fuente, y §10.2.8 repite la misma regla de *bypass*. Coincide con [B177], [B186], [B188] y [B214] (2026-10-09).
2. **A.12 y §9.2.4 tras el ciclo 2:** `packages: read` y `credentials` para la imagen privada, sin `id-token` en el job que corre código del PR. El `builder-id=` está en dos oraciones, con el alcance «identifica a la plataforma sólo junto al firmante». La clave de cosign está «en un job aparte que no ejecuta código del PR, detrás de un entorno con aprobación», y la firma sin clave declara el costo de privacidad en Rekor. No encontré nada que se haya inflado al comprimir.
3. **§7.3 y §7.6, hash contra mapeo:** «contra cambios de contenido sí; no contra lo que ya era malicioso al bloquear» y el hueco declarado por ecosistema (caché caliente en NuGet, sin *scope* en npm, búsqueda combinada en pip, `explicit` en uv) coinciden con [B86], [B109] y [B110]. La tabla de Dependabot de [B107] (2026-10-09) sigue sin mencionar `container:` ni `docker://` en workflows: «Only repository syntax is supported».

## Solicitudes de convocatoria

Ninguna.
