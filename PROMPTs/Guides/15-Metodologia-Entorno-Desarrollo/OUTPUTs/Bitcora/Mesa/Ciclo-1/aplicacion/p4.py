# ---------------- P-11 · §8 ----------------
begin("P-11")
R("propone mitigarlo con Docker Scout o con Dependabot, que abre PR con el digest nuevo [B113].", "propone mitigarlo con Docker Scout o con Dependabot, que según Docker abre PR con la etiqueta y el digest nuevos [B113]; la página de ecosistemas de GitHub dice que el ecosistema `docker` actualiza las referencias de imagen de los Dockerfile sin mencionar digests [B107], y el laboratorio no lo observó **[no verificado]** (requiere la plataforma).")
R("""1. **Digest en todo lo versionado** que nombra una imagen: `FROM`, `image` del devcontainer, `container.image` de la CI. Se escribe `repo:etiqueta@sha256:…`: la etiqueta queda como referencia humana y manda el digest.
2. **Actualización como PR**""", """1. **Digest en todo lo que construye artefactos publicados**: el `FROM` de la imagen de CI y de los Dockerfile de build, y `container.image` de la CI. Se escribe `repo:etiqueta@sha256:…`: la etiqueta queda como referencia humana y manda el digest.
2. **En el devcontainer, «mismo SDK», no «misma imagen»** (§8.6): o una etiqueta **fija** de SDK y SO (`mcr.microsoft.com/dotnet/sdk:8.0.425-bookworm-slim`, o la versión semántica de `devcontainers/dotnet`, que su README recomienda para fijar versión y SO y reserva el digest para las imágenes `dev-*`, que se actualizan en el lugar [B118]) más `global.json`, que detecta la deriva de la capa 2 (E5-6); o la **misma receta** que la imagen de CI (`build.dockerfile`), cuyas bases por digest mantiene el bot de la CI. Un digest en la `image` de `devcontainer.json` sólo con un bot que lo actualice: en un repositorio privado el ecosistema `devcontainers` de Dependabot no está soportado [B107].
3. **Actualización como PR**""")
R("3. **Cadencia alineada con el publicador**", "4. **Cadencia alineada con el publicador**")
R("4. **Etiqueta flotante sólo donde se quiere deriva**", "5. **Etiqueta flotante sólo donde se quiere deriva**")
R("Un equipo que fija digests y no tiene el punto 2 está peor", "Un equipo que fija digests y no tiene el punto 3 está peor", note="renumeración derivada")
R("3. **Lo que tiene que ser idéntico entre ESC-01 y ESC-04**:", "3. **Lo que tiene que ser idéntico entre la estación Windows (ESC-01) y el devcontainer (ESC-04)**:")
R("que Dependabot actualice un `FROM …@sha256` fijado por digest **[no verificado]** en la documentación oficial.", "Docker documenta que Dependabot actualiza etiqueta y digest de las imágenes base [B113]; la página de ecosistemas de GitHub no menciona digests [B107] y el laboratorio no lo observó **[no verificado]** (requiere la plataforma).")
R("**[hallazgo negativo, a revalidar]**", "**[no verificado]** (hallazgo negativo, a revalidar)")
R("| ESC-04 Devcontainer | Capas 2 y 4 por digest; *features* con lock | Capas 1, 3, 6 |", "| ESC-04 Devcontainer | Capa 2 por etiqueta fija verificada con `global.json`, o la receta de la imagen de CI; *features* con lock | Capas 1, 3, 6 |")
AFTER("| ESC-05 CI | La imagen por digest que construye lo que se publica | Reemplazar a `global.json` o a los locks |", "\n\nPor contexto: en CTX-NET el devcontainer no reemplaza a Visual Studio para quien trabaja en ESC-01 (§8.2.4); en CTX-NODE y CTX-PY, la imagen oficial del runtime con `npm ci` o `uv sync --locked`; en CTX-POLI, la imagen trae los tres toolchains o la build se parte por componente (§11.2.6).")
R("""```jsonc
// .devcontainer/devcontainer.json — capa 4 por digest, Node como feature con versión exacta (Anexo A.9).
{
  "name": "solucion",
  "image": "mcr.microsoft.com/dotnet/sdk:8.0@sha256:78235e09001f52b6592c458ac010775ebac6725422e80cd0c1650590f67b2743",
""", """```jsonc
// .devcontainer/devcontainer.json — sólo .NET + Node; etiqueta FIJA de SDK y SO (§8.2.2).
// La variante políglota, construida con la receta de la imagen de CI, está en A.9.
{
  "name": "solucion",
  "image": "mcr.microsoft.com/dotnet/sdk:8.0.425-bookworm-slim",
""")
UNNUMQ("### 8.6 Preguntas guía", "### 8.7")
SPLITQ("### 8.6 Preguntas guía", "### 8.7")
R("Digest en todo lo que construye artefactos o define el entorno compartido; etiqueta flotante sólo donde se acepta deriva. El costo medido: con el digest de septiembre, la imagen siguió con OpenSSL 3.0.20 cuando la etiqueta ya traía 3.0.22. El digest convierte los parches en trabajo explícito.",
  "Digest en todo lo que construye artefactos publicados, con un bot que proponga el digest nuevo; en el devcontainer, etiqueta fija de SDK y SO, o la receta de la imagen de CI. Etiqueta flotante sólo donde se acepta deriva. El costo medido: con el digest de septiembre, la imagen siguió con OpenSSL 3.0.20 cuando la etiqueta ya traía 3.0.22. El digest convierte los parches en trabajo explícito. *Aplica* a toda referencia a una imagen en el repo; en un repositorio privado, revisar antes qué ecosistemas del bot están soportados [B107].")
APPQ("¿Cómo conviven Visual Studio sin contenedores y el devcontainer?", " *Aplica* a CTX-NET y CTX-POLI con estaciones Windows.", "### 8.6", "### 8.7")
APPQ("¿Qué tiene que ser idéntico entre la estación Windows y el devcontainer?", " *Aplica* al escribir las reglas de convivencia del equipo (§8.2.4).", "### 8.6", "### 8.7")
APPQ("¿El lock de devcontainer reemplaza a los locks de NuGet, npm o uv?", " *Aplica* cuando alguien versiona `devcontainer-lock.json` y da por congeladas las dependencias.", "### 8.6", "### 8.7")
END_OF_SECTION_APPEND("### 8.6 Preguntas guía", "### 8.7", """**Tu repo es privado, el devcontainer apunta a `sdk:8.0@sha256:…` y nadie lo tocó en cinco meses. ¿Está bien congelado?**
Está congelado, no mantenido: el sistema de desarrollo no recibió parches desde que se fijó el digest (E5-2 muestra un mes de diferencia en OpenSSL), y en un repositorio privado el ecosistema `devcontainers` de Dependabot no está soportado [B107]. Para desarrollar alcanza «mismo SDK»: etiqueta fija de SDK y SO más `global.json`, o la receta de la imagen de CI, cuyo bot sí la actualiza. *Aplica* a ESC-04 en repositorios privados.""")
R("- nombra toda imagen por digest y tiene un mecanismo (bot o trabajo) que propone el digest nuevo como PR;", "- nombra por digest toda imagen que construye artefactos publicados, con un mecanismo (bot o trabajo) que propone el digest nuevo como PR; en el devcontainer usa una etiqueta fija verificada por `global.json` o la receta de la imagen de CI;")
R("imágenes de dev y CI elegidas por nombre.", "imágenes de dev y CI elegidas por nombre; un digest en el devcontainer de un repo privado que ningún bot actualiza.")
BEFORE_SECTION_END("### 8.8 Plantilla", """### 8.9 Práctica

1. Con la salida de E5-2, decí qué cambió entre los dos digests de `sdk:8.0` y si cambió el SDK. *Respuesta esperada*: el mismo SDK 8.0.425; cambiaron OpenSSL, `libexpat1`, `libpcre2-8-0`, Perl y `tzdata` (§8.2.2).
2. Antes de correr E5-1, predecí si el `.cs` en cp1252 compila dentro de la imagen fijada por digest. *Respuesta esperada*: no, `CS1056`; compila recién al convertir el archivo en el repo (§8.2.1).""")

# ---------------- P-12 · §9 ----------------
begin("P-12")
for a, b in [
    ("una pieza que ya está publicada", "un artefacto que ya está publicado"),
    ("| **Pieza** (artefacto) |", "| **Artefacto** |"),
    ("grabados **dentro** de la pieza", "grabados **dentro** del artefacto"),
    ("Inventario de los componentes de la pieza", "Inventario de los componentes del artefacto"),
    ("Atestación que identifica la pieza por digest", "Atestación que identifica el artefacto por digest"),
    ("Reconstruir la pieza desde el commit", "Reconstruir el artefacto desde el commit"),
    ('        A["pieza (sha256)"]', '        A["artefacto (sha256)"]'),
    ("Compilando la pieza .NET", "Compilando el artefacto .NET"),
    ("| Commit en la pieza |", "| Commit en el artefacto |"),
    ("| ESC-02 / ESC-03 | Reconstruir una pieza publicada", "| ESC-02 / ESC-03 | Reconstruir un artefacto publicado"),
    ("(1) el digest de la pieza;", "(1) el digest del artefacto;"),
    ("Una pieza trazable:", "Un artefacto trazable:"),
]:
    R(a, b)
R("**`npm pack` dio el mismo tarball** desde dos rutas con fechas distintas: todas las entradas llevan `mtime` fijo 1985-10-26T08:15:00Z (E6-3) **[observado]**;",
  "**Con npm 11.19.0, `npm pack` dio el mismo tarball** desde dos rutas con fechas de archivo distintas: las dos entradas del paquete de prueba llevan `mtime` fijo 1985-10-26T08:15:00Z (E6-3) **[observado]**; no se probaron otro usuario, otro *umask* ni otra versión de npm;")
R("| SPDX | 3.0.1 [B155] | ISO/IEC 5962:2021 [B155] |", "| SPDX | 3.0.1 [B155] | ISO/IEC 5962:2021 normaliza la versión **2.2.1** [B194] |")
R("**[criterio]** El formato lo elige el consumidor; conviene **uno solo** por solución, aunque cada ecosistema lo genere con su herramienta.",
  "**[criterio]** El formato lo elige el consumidor, y conviene **uno solo** por solución aunque cada ecosistema lo genere con su herramienta. Sin un consumidor que pida otro, CycloneDX: es el que emitieron las tres vías que el laboratorio usó para cubrir una solución políglota (syft, los exportadores nativos y su unión con `cyclonedx-cli`, E8-6). SPDX cuando el consumidor lo exige o cita la norma ISO, sabiendo que la versión normalizada es la 2.2.1 [B194] y que BuildKit emite SPDX (E8-6).")
R("| Firma | Opcional | Requisito desde SLSA Build L2 |", "| Firma | Opcional | Requisito desde SLSA Build L2; L1 exige `builder.id` [B09] |")
R("el commit en `vcs:revision`; `builder.id` **vacío**, porque una build local no tiene identidad de plataforma.",
  "el commit en `vcs:revision`; `builder.id` **vacío**, porque una build local no tiene identidad de plataforma. Con `builder.id` vacío esa procedencia **no alcanza SLSA Build L1**: la especificación lo exige desde L1, lo presenta como «el único determinante» del nivel y pide al consumidor aceptar sólo pares firmante/`builder.id` conocidos [B09]. Llega a L1 cuando la plataforma de CI que corre BuildKit la identifica en `builder.id`; cómo completarlo en BuildKit no se verificó **[no verificado]**.")
R("Es mejor que nada, pero hay que llamarlo por su nombre.", "Es mejor que nada, pero hay que llamarlo por su nombre: a lo sumo, L1 firmado por un inquilino de la plataforma. Y `verify-blob-attestation` comprueba la firma, el `subject` y el tipo de predicado; por sí solo no evalúa su contenido (`builder.id`, repositorio, commit, parámetros), de modo que un predicado falso firmado con la clave legítima verifica igual. Esa comprobación es un paso aparte, con una política que fije lo esperado [B10].")
LINE_REPLACE("**[criterio] Para el caso** (repositorio privado de una organización, equipo chico):", """**[criterio] Para el caso** (repositorio privado de una organización, equipo chico, artefactos internos), la tercera pregunta del caso se contesta con el **registro del entorno** y el SBOM que la CI graba junto al artefacto (§3.4, §9.6). La procedencia firmada se agrega cuando hay un consumidor externo que la verifique, un requisito contractual o un repositorio público (§12, paso 8b). Si se agrega y el plan no es Enterprise Cloud, las atestaciones nativas de GitHub no están disponibles para ese repo, y las de npm y PyPI no aplican a paquetes privados. Quedan tres caminos, cada uno con su nivel declarado sin inflarlo:

- **GitLab** con los metadatos del runner más un paso de firma [B159].
- **BuildKit + cosign con clave propia**: la clave en un job aparte que no ejecuta código del PR, detrás de un entorno con aprobación y fuera del alcance de los pasos de build; a lo sumo, L1 firmado por un inquilino.
- **cosign sin clave**, con el token OIDC de la CI: Fulcio emite un certificado efímero atado a la identidad del workflow, y el evento se registra en el log de transparencia público Rekor «para que sea auditable públicamente» [B197]. El costo, para un repositorio privado, es que esa identidad queda publicada en el log; la alternativa es una instancia propia de Sigstore [B197]. No se ejercitó en el laboratorio **[no verificado]**.""")
R("| ESC-05 CI | **Todo**: `ContinuousIntegrationBuild`, `SOURCE_DATE_EPOCH`, SBOM, procedencia, firma, publicación junto al artefacto | — |", "| ESC-05 CI | Siempre: `ContinuousIntegrationBuild`, `SOURCE_DATE_EPOCH`, registro del entorno y SBOM junto al artefacto. Si un consumidor la verifica: procedencia firmada, con su nivel declarado | — |")
R("En CTX-POLI aparecen tres SBOM distintos según el **alcance** —artefacto, dependencias declaradas, entorno de build— y una procedencia que nombra por digest las imágenes de los tres toolchains",
  "En CTX-POLI (los tres ecosistemas en un repo) aparecen tres SBOM distintos según el **alcance** —artefacto, dependencias declaradas, entorno de build— y una procedencia de BuildKit que nombra por digest las imágenes de los tres toolchains, sin firma ni `builder.id`")
R("  - uses: actions/attest@v4\n", "  - uses: actions/attest@1e69f48acb82d1966a394da916b4c1698aa569d6 # v4.2.2 (git ls-remote, 2026-10-09)\n")
R("# Sin plataforma que firme (E6-5): cosign sobre la procedencia de BuildKit. NO es SLSA L2.", "# Sin plataforma que firme (E6-5): cosign sobre la procedencia de BuildKit. NO es SLSA L2; con builder.id vacío, tampoco L1.")
R("--type slsaprovenance1 --insecure-ignore-tlog Pieza.dll        # falla si cambia 1 byte o el predicado", "--type slsaprovenance1 --insecure-ignore-tlog Pieza.dll        # falla si cambia 1 byte o se edita lo firmado; NO verifica builder.id ni commit")
SPLITQ("### 9.6 Preguntas guía", "### 9.7")
R("(3) el toolchain efectivo;", "(3) el toolchain efectivo, incluida la versión del compilador (en .NET, `#error version` provoca el `CS8304` con la versión del compilador [B57]);")
R("Una procedencia SLSA de la plataforma da 1, 4, 6 y casi siempre 2; el SBOM da 5; el 3 hay que agregarlo si la procedencia no lo trae.",
  "Una procedencia firmada por la plataforma da 1, 2 y 6, y deja el entorno como opcional [B202]; la de BuildKit da además 4, sin firma (§9.2.4); el SBOM da 5; el 3, y el 4 si nadie lo trae, los agrega el registro del entorno.")
APPQ("¿SBOM o procedencia?", " *Aplica*: SBOM en todo artefacto que salga de la CI; procedencia firmada cuando un consumidor la verifica (§12, paso 8b).", "### 9.6", "### 9.7")
APPQ("¿Cómo verifico que dos builds del mismo commit dan el mismo binario?", " *Aplica* en Linux, WSL, devcontainer o CI (ESC-02 a ESC-05) con la misma imagen que la CI; en una estación Windows con Visual Studio no se espera el mismo hash (§8.2.4).", "### 9.6", "### 9.7")
APPQ("¿El SHA en `InformationalVersion` alcanza?", " *Aplica* al diagnosticar en cualquier escenario; nunca como prueba ante un tercero.", "### 9.6", "### 9.7")
APPQ("¿Meto el SBOM dentro del paquete?", " *Aplica* en CTX-PY (PEP 770); en CTX-NET y CTX-NODE el SBOM viaja al lado.", "### 9.6", "### 9.7")
REPQ_ANSWER("¿Qué nivel SLSA es razonable para un equipo chico?", "**[criterio]** Primero, el registro del entorno y el SBOM, que no dependen de ningún nivel. L1 cuando la CI genere la procedencia con un `builder.id` que la identifique: la de BuildKit tal como sale en E6-5, con `builder.id` vacío, no lo alcanza (§9.2.4). L2 cuando un consumidor la verifique y la plataforma lo ofrezca para el repositorio; L3 sólo con un requisito externo. Sin declarar L2 por firmar con una clave propia. *Aplica* a ACT-OPS al declarar un nivel ante un cliente o un auditor.", "### 9.6", "### 9.7")
END_OF_SECTION_APPEND("### 9.6 Preguntas guía", "### 9.7", """**Un cliente pide «procedencia SLSA L2» del binario que le entregan. El repo es privado, el plan es Team y la CI ya graba el registro del entorno y un SBOM. ¿Qué le contestás?**
Que hoy podés entregar registro del entorno y SBOM, y procedencia L1 cuando la CI la genere con un `builder.id` que la identifique. Las atestaciones nativas de GitHub, que darían L2, requieren Enterprise Cloud en un repositorio privado [B158], y una firma con clave propia no es L2 (§9.2.4). Las salidas honestas son cambiar de plan o de plataforma, o declarar el nivel alcanzado. *Aplica* a todo pedido de nivel SLSA sobre lo que sale de la CI (ESC-05).""")
R("- su procedencia la firma la plataforma, o se declara con honestidad qué nivel se alcanzó;", "- si un consumidor la verifica, su procedencia la firma la plataforma, o se declara con honestidad qué nivel se alcanzó;")
R("contar con atestaciones de GitHub", "declarar L1 con una procedencia sin `builder.id`; dar por verificado el predicado porque `verify-blob-attestation` pasó; contar con atestaciones de GitHub")
BEFORE_SECTION_END("### 9.8 Plantilla", """### 9.9 Práctica

1. Con la salida de E6-2, decí qué cambia entre la corrida (1) y la (8) y por qué el `.nupkg` difiere aunque DLL y PDB coinciden. *Respuesta esperada*: en (8), el SDK 11 con `SOURCE_DATE_EPOCH` fija las fechas del zip; en (1), el zip guarda fechas del disco y un nombre aleatorio (§9.2.1).
2. Con la procedencia de E6-5, marcá cuáles de los seis metadatos de §9.6 trae y cuáles faltan. *Respuesta esperada*: trae el digest del artefacto, el commit y la imagen del SDK por digest; faltan la identidad de la plataforma (`builder.id` vacío) y el toolchain efectivo como dato propio.""")
