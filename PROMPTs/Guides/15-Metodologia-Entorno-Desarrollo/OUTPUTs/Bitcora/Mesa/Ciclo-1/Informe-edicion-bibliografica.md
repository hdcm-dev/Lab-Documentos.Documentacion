# Informe — Edición de material bibliográfico (Ciclo 1)

- **Especialista**: edición de material bibliográfico (estructura editorial, índice y numeración, citas y bibliografía, coherencia terminológica, voz única, redundancias, compresión, glosario).
- **Objeto**: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (3060 líneas, 43 605 palabras), versión 1.0.0-borrador, 2026-10-07.
- **Modo**: a ciegas; no se leyeron los informes de otros especialistas del ciclo.
- **Método**: lectura de §0–§3, §4.1, §4.2.6, §5.2.3, §7.1, §9.1, §11.2.2, §12 y anexos C, D, E y F completos; chequeos mecánicos con un script propio (slugs de encabezados contra enlaces internos, `[Bnn]` citados contra definidos, inventario de marcas y de variantes terminológicas). Los comandos y salidas relevantes van en cada hallazgo.

## Hallazgos

### edicion-bibliografica-01 — El glosario no recoge siglas y nombres que la guía usa decenas de veces, y varias siglas nunca se expanden

- **Nivel**: E1 · **Severidad**: S3
- **Ubicación**: Anexo C (l. 2687–2751); primeras apariciones en l. 26/41 (SLSA), l. 39/186 (CPM), l. 1050 (RID).
- **Ancla** (conteo de apariciones en la guía; ninguna tiene fila en el Anexo C):
  ```text
  $ for t in SLSA BuildKit Corepack '\bRID\b' 'Source Link' CycloneDX SPDX in-toto; do grep -oE "$t" GUIA | wc -l; done
  SLSA 33 · BuildKit 16 · Corepack 13 · RID 10 · Source Link 9 · CycloneDX 15 · SPDX 6 · in-toto 6
  $ grep -n 'Supply-chain' GUIA            -> sin resultados (SLSA no se expande en ningún lugar)
  $ grep -n 'Central Package' GUIA         -> primera expansión en l. 1052; CPM se usa desde l. 39 y l. 186
  $ grep -niE 'runtime identifier' GUIA    -> sin resultados
  ```
- **Por qué importa**: el índice promete para el Anexo C «un término, una definición, la sección donde se trata». SLSA es el marco de toda la capa 6 y el lector que entra por consulta (§0.2) a §9 o a §12 no encuentra qué es. Una sigla sin expandir es una definición ambigua en los términos de Rule-Markdown.
- **Dirección**: agregar al Anexo C, con remisión a su sección, al menos SLSA (*Supply-chain Levels for Software Artifacts*, con [B05]), BuildKit, Corepack, RID (*runtime identifier*), Source Link, CycloneDX, SPDX e in-toto; expandir SLSA, SBOM y CPM en su primera aparición en prosa (no en el índice), y RID donde aparece por primera vez (§7.2.1).

### edicion-bibliografica-02 — El sistema de marcas de procedencia de §0.3 no es el que usa el cuerpo

- **Nivel**: E1 · **Severidad**: S3
- **Ubicación**: §0.3 (l. 72–83) frente a todo el cuerpo; §3.1 l. 246–247; §4.2.6 (l. 492) frente a Anexo F (l. 3055).
- **Ancla**:
  ```text
  $ grep -oE '\[(no verificado|criterio|observado)[^]]*\]' GUIA | sort | uniq -c
       79 [criterio]            (49 en negrita, 30 sin negrita)
        1 [criterio sobre base del fabricante]
        1 [criterio, apoyado en E7-4 y en [B83]
       19 [no verificado]
        4 [no verificado en Windows]
        1 [no verificado en Visual Studio]
        1 [no verificado como ausencia]
        1 [no verificado: no hubo runner Windows]
        3 [observado]
  además: **[no medido]** (l. 458), **[no ejercitado en el laboratorio]** (1 vez)
  l. 246/247, columna «Fuente» de §3.1:  | fabricantes |
  ```
  §0.3 define sólo tres marcas: `[criterio]` («Recomendación propia»), `[no verificado]` y `[observado]`. En §4.2.6 el «ciclo típico de un commit de BOM» lleva `[criterio]`, pero el Anexo F lo lista como **interpretación** («inferido de los defaults documentados»): no es una recomendación sino una inferencia de hecho, y §0.3 no tiene marca para eso.
- **Por qué importa**: las marcas son la interfaz de confianza de la guía (y lo que lee una máquina, Rule-Dual-Audience). Con once variantes, una búsqueda de `[no verificado]` no encuentra seis de los casos, y «fabricantes» en la columna de fuentes no remite a ninguna fila del Anexo D.
- **Dirección**: cerrar el vocabulario a las marcas de §0.3 más una cuarta, `[interpretación]` (inferencia de hecho no observada), y poner el matiz fuera del corchete: `**[no verificado]** (requiere Windows)`. Unificar la negrita. Reemplazar «fabricantes» en l. 246–247 por los `[Bnn]` que ya aparecen en la celda de definición ([B84][B106][B56][B113] y [B83][B93][B99][B101]). Reetiquetar §4.2.6 como `[interpretación]` para que coincida con el Anexo F.

### edicion-bibliografica-03 — Las fuentes de código se citan por rama móvil aunque el Anexo D promete «archivo y commit»

- **Nivel**: E1 · **Severidad**: S3
- **Ubicación**: Anexo D, introducción (l. 2755) y filas B14, B49.
- **Ancla**:
  ```text
  l. 2755: «Las fuentes de código (Roslyn, Node, VS Code) se citan por archivo y commit cuando el comportamiento no estaba documentado en prosa.»
  B14 | dotnet/roslyn — `EncodedStringText.cs` (main, commit `9c298328ef`; histórico `5a5e8027cb`) ... | https://github.com/dotnet/roslyn/blob/main/src/Compilers/Core/Portable/EncodedStringText.cs · .../blob/main/.../CommandLineParser.cs
  B49 | microsoft/vscode — `files.contribution.ts` y `encoding.ts` (main) | https://github.com/microsoft/vscode/blob/main/...
  ```
- **Por qué importa**: B14 sostiene el mecanismo central del caso (§1.2, §4.2.1) y B49 los defaults de VS Code (§4.2.6). Un enlace a `blob/main` deja de mostrar lo citado en cuanto el archivo cambia; el SHA está en el texto pero no en la URL, y en B49 no está en ningún lado. Contradice la promesa de la propia introducción del anexo y la exigencia de reproducibilidad de Rule-Evidences.
- **Dirección**: usar enlaces permanentes `.../blob/<sha>/...` (con número de línea si corresponde) en B14 —el commit ya está registrado— y en B49 (agregar el SHA consultado el 2026-10-07). Las fuentes de prosa en `blob/main` (README de nvm, pyenv, fnm, etc.) pueden quedarse así: son documentación, no código.

### edicion-bibliografica-04 — El mapa de la guía contradice su propia tabla de capas, y el índice anuncia «Partes» que el cuerpo no tiene

- **Nivel**: E1 · **Severidad**: S3
- **Ubicación**: §3, párrafo de apertura (l. 233); tabla de §3.2 (columna «Capítulo», l. 275–280); Índice (l. 31, 35, 43).
- **Ancla**:
  ```text
  l. 233: «Es el mapa: los capítulos 4 a 10 desarrollan una capa cada uno.»
  §3.2: capa 1 -> «§4, §5»; capa 5 -> «§9»; capa 6 -> «§9»   (y §10 no es una capa: es gobierno)
  $ grep -n 'Parte I' GUIA  ->  31, 35, 43 (sólo en el índice; ningún encabezado de Parte en el cuerpo)
  ```
  Siete capítulos (4 a 10) no pueden desarrollar seis capas «una cada uno», y la tabla de la página siguiente lo muestra.
- **Por qué importa**: §3 es el punto de entrada de la lectura de consulta (§0.2). Una frase de mapa que no coincide con la tabla que la sigue es lo primero que un lector atento detecta, y debilita la confianza en el resto del mapa. Las Partes del índice que no existen como encabezados rompen la correspondencia índice ↔ cuerpo (Rule-Markdown: estructura coherente).
- **Dirección**: reescribir l. 233 según la tabla, por ejemplo: «§4 y §5 tratan la capa 1; §6, §7 y §8, las capas 2 a 4; §9, las capas 5 y 6; §10, cómo se hace cumplir todo lo anterior». Para las Partes, o se agregan como separadores en el cuerpo (sin romper la numeración de capítulos ni las anclas) o se quitan del índice; la primera opción conserva el valor didáctico.

### edicion-bibliografica-05 — El entregable habla de «la mesa», un actor que el lector no conoce

- **Nivel**: E1 · **Severidad**: S3
- **Ubicación**: frontmatter `status` (l. 6); Anexo F, último párrafo (l. 3060).
- **Ancla**:
  ```text
  l. 6:    status: borrador (pendiente de relectura integral de la mesa)
  l. 3060: **Pendiente de decisión de la mesa.** Si la guía recomienda un formato único de SBOM por defecto (CycloneDX o SPDX) o deja la elección al consumidor, como hace hoy (§9.2.3).
  ```
- **Por qué importa**: la guía es autocontenida (regla del prompt del PO); el proceso que la produjo vive en la bitácora. Un anexo de límites que termina en una decisión interna pendiente le transfiere al lector una deuda del proceso editorial, no un límite del conocimiento. Es esperable en el primer ciclo, pero tiene que estar resuelto antes del cierre.
- **Dirección**: en el cierre del ciclo, resolver la decisión sobre el SBOM en §9.2.3 (ver solicitud de convocatoria) y reemplazar el párrafo de l. 3060 por la respuesta o, si se mantiene abierta, por un criterio para el equipo lector («cuándo conviene uno u otro»). Quitar «de la mesa» del `status` al publicar la versión 1.0.0.

### edicion-bibliografica-06 — Pares de términos sin fijar: pieza/artefacto, fix/corrección, fin/final de línea, el/la build

- **Nivel**: E1 · **Severidad**: S4
- **Ubicación**: Anexo C (fila «Pieza (artefacto)», «EOL»); §1.1 l. 102–104; §1.4 (encabezado, l. 152); §5.1 (l. 593); §12 paso 8 (l. 2179); §3.1 l. 241.
- **Ancla**:
  ```text
  $ grep -oE '\bpiezas?\b' GUIA | wc -l      -> 26
  $ grep -oE '\bartefactos?\b' GUIA | wc -l  -> 41
  l. 2179 (§12, paso 8): «Pieza + SBOM + procedencia junto al artefacto»   (usa los dos como si fueran cosas distintas)
  l. 102: «La corrección fue convertir los cien archivos...»  /  l. 104: «El fix funcionó...»  /  l. 152: «### 1.4 Qué resolvió el fix»
  Anexo C: «EOL | Final de línea» ; §5.1 y §5.2.2: «fin de línea» (7 apariciones) ; «final de línea» (2)
  l. 241: «variables de entorno que el build lee»  frente a 50 apariciones de «la build»
  ```
- **Por qué importa**: §3.1 promete que la guía «elige un sentido y lo sostiene»; el glosario elige «Pieza» como término y el cuerpo prefiere «artefacto», y en §12 conviven en la misma celda con lectura de dos objetos. «Fix» es un anglicismo innecesario que convive con «corrección» en el mismo párrafo.
- **Dirección**: elegir un término por concepto y aplicarlo en todo el cuerpo y en el glosario. Propuesta: **artefacto** como término (es el más usado y el de SLSA/SPDX en español), «pieza» sólo en la cita del pedido del caso; «corrección» en lugar de «fix» (también en el encabezado de §1.4 y su ancla en el índice); «fin de línea» (EOL) en singular y «finales de línea» en plural, con el glosario alineado; «la build» en l. 241. En §12 paso 8: «Artefacto + SBOM + procedencia, publicados juntos».

### edicion-bibliografica-07 — La numeración del laboratorio no es regular y sus rutas no se pueden seguir

- **Nivel**: E1 · **Severidad**: S4
- **Ubicación**: Anexo E (l. 2955–3024); §0.1 (l. 61).
- **Ancla**:
  ```text
  IDs:     E0-1, E2-1, E7-1 ...  pero  E1-01 ... E1-13
  Salidas: E7-1 -> «E7-01-*.txt»; E7-5b -> «V7-01-tiempo-de-la-compuerta.txt» (prefijo V no explicado)
  Carpetas de N2: E2-1 -> `e1-precedencia/`, E2-3 -> `e3-compuerta/` (el número de carpeta no es el del ID)
  Rutas:   `…/N0-…/capa2-toolchain/`, `…/N4-…/e2-nuget-cpm-pinning/` (abreviadas, en backticks, sin enlace)
  E3-1…E3-6, columna «Salida»: «`README.md` de la carpeta» / «ídem»
  l. 61: «corresponde a la guía de Despliegue de esta misma colección» (sin enlace; `../Despliegue` tiene tres subguías)
  ```
- **Por qué importa**: el Anexo E es la tabla que convierte las 71 marcas `Ex-y` del cuerpo en algo reproducible. Con dos esquemas de numeración, un ID que no coincide con su carpeta y rutas elididas, el lector tiene que adivinar dónde está cada salida; Rule-Markdown pide enlaces relativos entre documentos relacionados.
- **Dirección**: fijar un esquema (propuesta: `E<n>-<m>` sin cero a la izquierda, como en los otros ocho núcleos) y renombrar `E1-01…E1-13`; declarar en la cabecera del Anexo E que las carpetas de N2 conservan la numeración del núcleo y que `V7-01` es la verificación de E7-5b, o renombrar las salidas; escribir las rutas completas como enlaces relativos (`[capa2-toolchain](Examples/N0-modelo-de-capas-y-reproducibilidad/capa2-toolchain/)`); enlazar en l. 61 la subguía de despliegue concreta. Si renombrar archivos del laboratorio implica tocar scripts, alcanza con la nota de correspondencia.

## Revisado y bien

1. **Bibliografía cerrada y fechada.** 193 fuentes definidas en el Anexo D, 193 citadas en el cuerpo: ninguna `[Bnn]` colgante ni huérfana; todas con fecha de consulta 2026-10-07; el conteo «193 fuentes» de la cabecera coincide. Fuentes primarias (learn.microsoft.com, docs.npmjs.com, peps.python.org, docs.astral.sh, slsa.dev, git-scm.com, unicode.org, containers.dev); los tres `devblogs.microsoft.com` son del fabricante.
2. **Anclas y estructura.** Todos los enlaces internos `](#…)` resuelven contra los slugs de los encabezados (script propio: 0 rotos, 0 slugs duplicados). Los capítulos 4 a 11 cumplen la estructura x.1–x.8 que promete §0.2, con los mismos títulos. Las 71 marcas de experimento del cuerpo tienen todas fila en el Anexo E, y el conteo «71 experimentos» de la cabecera coincide.
3. **Voz única.** Cero apariciones de las muletillas que lista Rule-Narrative-Voice («Es importante», «Cabe», «En resumen», «En conclusión», «Como se puede», «Vale la pena», «Asimismo», «Por otro lado», «Por consiguiente»); sólo tres «Además,». Las aperturas de capítulo leídas (§3, §5, §12) abren con contenido y no reformulan el título.

## Solicitud de convocatoria

- **Arquitectura de software / DevOps**: decidir si la guía recomienda un formato de SBOM por defecto (CycloneDX o SPDX) o deja la elección al consumidor (§9.2.3, Anexo F l. 3060). Es una decisión de contenido técnico, fuera del mandato editorial; el hallazgo 05 sólo pide que no quede abierta en el entregable.
