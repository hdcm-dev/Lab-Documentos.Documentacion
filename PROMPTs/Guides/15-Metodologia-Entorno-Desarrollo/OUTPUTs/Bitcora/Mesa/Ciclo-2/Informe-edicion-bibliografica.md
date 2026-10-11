# Informe — Edición de material bibliográfico (Ciclo 2)

- **Especialista**: edición de material bibliográfico (estructura editorial, índice y numeración, citas y bibliografía, coherencia terminológica, voz única, redundancias, compresión, glosario).
- **Objeto**: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md`, versión 1.0.0-rc.1 (2026-10-09), 3391 líneas, 53 363 palabras (`wc -w`), sha256 `e7837762f3bafa54…`.
- **Modo**: a ciegas respecto del ciclo 2 (no se leyeron informes de otros especialistas de este ciclo). Se leyó lo cerrado del ciclo 1 (`01-Consolidado.md`, `03-Parches.md`, `05-Aplicacion.md`, el propio informe de edición) para no re-litigar.
- **Método**: lectura de front matter, §0–§3, §5.2.3, §10.1–§10.2.4, §11.2.4–§11.2.5, §12 y anexos B, C, D (encabezado y muestreo), E y F completos; chequeos mecánicos con scripts propios (anclas internas contra slugs, `§n.m` contra encabezados, `[Bnn]` definidas contra citadas, inventario de marcas fuera de código, longitud de celdas de tabla, n-gramas repetidos, conteos terminológicos). Comandos y salidas en cada hallazgo.

## Hallazgos

### edicion-bibliografica-01 — §0.3 dice «cinco marcas, siempre en negrita» y la tabla define cuatro en negrita

- **Nivel**: E1 · **Severidad**: S3
- **Ubicación**: §0.3, L83–L95 (frase tras la tabla); Control de cambios, fila 1.0.0-rc.1 (L3391: «un vocabulario cerrado de cinco (§0.3)»).
- **Ancla**: «Son las únicas cinco marcas, siempre en negrita.» La tabla de §0.3 tiene siete filas: `[B12]`, `E4-2`, `` `Examples/…` `` (no en negrita) y **[criterio]**, **[no verificado]**, **[observado]**, **[interpretación]** (las únicas en negrita).
  ```text
  $ grep -c '\*\*\[B' GUIA                 -> 0      (ninguna [Bnn] va en negrita)
  inventario fuera de código: criterio 88 · no verificado 38 · observado 3 · interpretación 3 = 132, todas en negrita
  ```
  El texto de P-03 (3e) introdujo la frase con «cinco»; la verificación de `05-Aplicacion.md` contó 132 marcas, que son exactamente las cuatro.
- **Dirección**: «Son las únicas cuatro marcas de juicio, siempre en negrita; las referencias `[Bnn]`, los IDs de experimento y las rutas no llevan negrita.» Corregir igual la fila del control de cambios («un vocabulario cerrado de cuatro marcas»).

### edicion-bibliografica-02 — El Anexo F mezcla trazas, límites y una recomendación, y su tabla de trazas tiene referencias erróneas

- **Nivel**: E1 · **Severidad**: S3
- **Ubicación**: Anexo F L3325–L3383; índice L48; front matter `traces` L15.
- **Ancla**:
  - Fila R-03: «n.5, n.6 y n.9 de §3–§11». En §3, `3.5` es «¿Lo resuelve un contenedor?», `3.6` es el mapa conceptual y **no existe 3.9** (`grep -n '^### 3\.' GUIA` → 3.1…3.7). La estructura n.1–n.9 sólo rige en §4–§11 (lo dice §0.2, L68).
  - Los IDs `R-01, R-02, R-03, R-06, R-07` no coinciden con los del contrato (`R-PO-1…R-PO-7`, `00-Contrato-De-Entrada.md` L52–L58) y el salto R-04/R-05 no se explica: un lector ve dos requisitos «perdidos».
  - El anexo se titula «Límites y lo que no se verificó» y el índice lo describe como «hechos, interpretaciones y pendientes, separados», pero abre con «Qué pedido cubre cada sección» (trazabilidad) y cierra con «Formato de SBOM» (una recomendación ya dicha en §9.2.3).
- **Dirección**: (a) corregir R-03 a «§3.7; n.5, n.6 y n.9 de §4–§11»; (b) una línea antes de la tabla: «P-nn son los pedidos del caso; R-nn, los requisitos de forma del pedido (R-04 y R-05 regían el proceso de trabajo, no la guía)», o usar los IDs del contrato; (c) sacar la tabla de trazas a un anexo propio corto (o al final de §0.1) y actualizar el índice; (d) borrar el párrafo «Formato de SBOM» del Anexo F: está en §9.2.3 y el anexo no es lugar de recomendaciones.

### edicion-bibliografica-03 — «Registro» con cuatro sentidos y «manifiesto» sin definir; el glosario no recoge ninguno

- **Nivel**: E1 · **Severidad**: S3
- **Ubicación**: §11.2.4 (título, L2115), §11.2.5 (L2139), §11.6 (L2346), §9.2.4 (L1664), §10.1 (ADR), L1819/L1942/L1984/L2892; «manifiesto» desde §3.7 (L422, L428), §7.1 (L1146), §8.1 (L1319); Anexo C.
- **Ancla**:
  ```text
  $ grep -oiP '\bregistros?\b' GUIA | wc -l                       -> 72
    sentidos: registro del entorno (record) · registro de paquetes (registry) ·
              registro de imágenes/artefactos («la etiqueta del registro», «junto al artefacto en el registro») ·
              ADR «registro de solo agregado»
  $ grep -c 'registro de entorno' GUIA ; grep -c 'registro del entorno' GUIA   -> 5 ; 14
  L2115  «#### 11.2.4 Un lock y un registro por ecosistema»            (registry)
  L2139  «…con su comando estricto, entre la compuerta y el registro»  (¿registry de publicación o registro del entorno?)
  $ grep -oiP '\bmanifiestos?\b' GUIA | wc -l                     -> 27; sentidos: manifiesto del paquete
    (package.json/.csproj/pyproject), manifiesto de la imagen (L1319), «diff de dos manifiestos» por capa (E0-6, L422)
  Anexo C: sin filas «Manifiesto», «Registro (de paquetes)», «Registro (de imágenes)», «Escenario», «Contexto», «Actor».
  ```
  Rule-Dual-Audience: «Definir cada término en su primer uso y registrarlo en el glosario»; «los sinónimos se registran como alias del término canónico». Es el mismo defecto que C1-25 resolvió para «índice», en otras dos palabras.
- **Dirección**: fijar «registro del entorno» (una sola forma; las 5 de «registro de entorno» se alinean) y usar **«registro de paquetes»** / **«registro de imágenes»** siempre con complemento cuando el sentido es *registry*; retitular §11.2.4 «Un lock y un registro de paquetes declarado por ecosistema»; en L2139 y L2346 decir cuál («…entre la compuerta y la publicación»). Llamar «manifiesto de capas» (o «registro por capa») al de E0-6 y «manifiesto de la imagen» al de §8.1. Agregar al Anexo C: Manifiesto (del paquete), Registro de paquetes (alias: índice, *feed*), Registro de imágenes, y Escenario / Contexto / Actor con remisión a §2.

### edicion-bibliografica-04 — El ciclo 1 agrandó la guía un 22 %; hay compresión disponible sin perder contenido

- **Nivel**: E1 · **Severidad**: S3
- **Ubicación**: global; Control de cambios L3391; §0.2 L65, §3 L258, §3.3 L312, §3.6 L364; celdas en §10.4 L1938, §8.3 L1445, §4.3 L542.
- **Ancla**: el pedido del PO dice que la mesa debe «hacer las correcciones pertinentes en edición y compresión ajustando su coherencia».
  ```text
  ciclo 1 (informe de edición): 3060 líneas, 43 605 palabras   ->   ahora: 3391 líneas, 53 363 palabras (+22 %)
  celdas de tabla con ≥60 palabras (script): Control de cambios L3391 = 320 · §10.4 L1938 = 85 · §8.3 L1445 = 73 · §4.3 L542 = 72 · §5.2.3 L705 = 62 · §5.3 L820 = 61
  instrucción «en §3, leer 3.1/3.2/3.4/3.7; 3.3/3.5/3.6 son de consulta»: L65, L258, L312 (*Tabla de consulta…*), L364 (*Tabla de consulta…*)
  ```
  Rule-Markdown: tablas «sin celdas de texto largo»; Rule-Narrative-Voice: «Si un párrafo se puede borrar sin perder información, sobra». No hay repetición literal relevante (n-gramas de 10 palabras repetidos ≥3 veces: sólo encabezados de tabla), así que la compresión tiene que ser de redacción, no de borrar duplicados.
- **Dirección**: (a) la fila 1.0.0-rc.1 del control de cambios pasa a una celda breve («Revisión integral, ciclo 1: ver lista») con la lista de cambios debajo de la tabla, agrupada en Corrige / Agrega / Plantillas / Marcas; (b) la instrucción de lectura de §3 queda en §0.2 y en una frase de §3; se borran las dos cursivas «Tabla de consulta» (o se dejan y se quita la frase de L258); (c) las celdas de 60–85 palabras de §4.3, §8.3 y §10.4 pasan a una frase en celda + prosa debajo de la tabla; (d) meta concreta para el editor de cierre: volver a ≤ 48 000 palabras **[criterio]**, midiendo con `wc -w` antes y después, sin tocar evidencia (salidas, `[Bnn]`, IDs).

### edicion-bibliografica-05 — Citas y fechas: el snippet de Roslyn dice «rama main», Node se cita por rama y las fechas de §0.3 y del Anexo F quedaron en el 2026-10-07

- **Nivel**: E1 · **Severidad**: S4
- **Ubicación**: §4.2.1 L459; Anexo D L3040 y B23; §0.3 L87–L88; Anexo F L3368 y L3380; front matter L5–L6.
- **Ancla**:
  - L459: `// Roslyn, EncodedStringText.cs (rama main al 2026-10-07 [B14])`, pero B14 cita ahora el commit `9c298328ef91` (2026-04-24) por enlace permanente (P-19).
  - L3040 promete «Las fuentes de código (Roslyn, Node, VS Code) se citan por archivo y commit»; B23 cita el cargador de Node por rama: `https://github.com/nodejs/node/tree/v22.x/lib/internal/modules`.
  - §0.3: «[B12] … consultada el 2026-10-07», «E4-2 … ejecutado el 2026-10-07», mientras B194–B204 son del 2026-10-09 y hay ampliaciones del 2026-10-09 (L24, L3040).
  - Anexo F: «Datos volátiles **al 2026-10-07**» en una versión del 2026-10-09, y «Python 3.15 … final prevista para el 2026-10-09» (L3368), es decir, la fecha de la propia versión.
  - Front matter: `version: 1.0.0-rc.1` con `status: borrador`.
- **Dirección**: L459 → «(commit `9c298328ef91` [B14])»; B23 → enlace `blob/<sha>` del archivo en la rama v22.x consultada, o quitar «Node» de la promesa de L3040; en §0.3 decir «consultada en la fecha que indica su fila del Anexo D» y «ejecutado en la fecha del Anexo E»; en Anexo F, «Datos volátiles al 2026-10-07 (B01–B193) y al 2026-10-09 (B194–B204)» y rehacer la línea de Python 3.15 como dato con fecha de consulta («prevista, al 2026-10-07, para…»). Alinear `status` con la versión (p. ej. `candidata` o `en revisión`), según el vocabulario que use la colección **[criterio]**.

### edicion-bibliografica-06 — La lista del arquitecto (B.2) da dos variantes para `*.cs`; el cuerpo da tres estados

- **Nivel**: E1 · **Severidad**: S4
- **Ubicación**: Anexo B.2, segundo ítem; §5.2.3 (L713–L717); §12 paso 2 (L2389).
- **Ancla**: B.2: «Para `*.cs` se eligió una variante (repo nuevo sin BOM; heredado convertido con BOM) y está declarada. (§5.2.3)». §5.2.3 distingue **tres** estados: «Repositorio nuevo», «Heredado todavía en cp1252 … elegir A o B **antes** del commit de política» y «Heredado ya convertido a UTF-8 con BOM»; §12 paso 2 también nombra los tres.
- **Dirección**: «Para `*.cs` y los archivos de proyecto se eligió la variante A o B según el estado del repo (nuevo, heredado todavía en cp1252 —decidir antes del commit de política—, heredado ya con BOM) y está declarada. (§5.2.3)».

### edicion-bibliografica-07 — Alias sin fijar: ESC-01 tiene cuatro rótulos y «pieza» volvió en §11

- **Nivel**: E1 · **Severidad**: S4
- **Ubicación**: §2.1 (ESC-01), §2.4 L233, filas ESC-01 de §4.4 L549, §5.4 L830, §6.4 L1034, §7.4 L1218, §8.4 L1455, §9.4 L1681, §10.4 L1938, §11.4 L2252, §3.6 L385; «piezas» L2040, L2183, L2232.
- **Ancla**:
  ```text
  ESC-01: «Estación Windows con Visual Studio» (§2.1) · «Windows+VS» (L233) · «Windows + VS» (8 tablas n.4) · «Windows + Visual Studio» (§3.6)
  $ grep -noP '\bVS\b(?! Code)' GUIA   -> 14 apariciones de «VS» como abreviatura, que el glosario no registra
  $ grep -n 'piezas\?' GUIA            -> L2040 «junta las piezas», L2183 «tres piezas distintas», L2232 «piezas documentadas»
  ```
  La verificación de P-12/A-3 del ciclo 1 dejó «pieza» sólo en §1.1, nombres de archivo y glosario (C1-54); las tres de §11 no se tocaron.
- **Dirección**: un solo rótulo corto para ESC-01 en tablas («Windows + Visual Studio») y «VS» registrado como alias en el Anexo C, o reemplazado; en §11, «piezas» → «partes» (L2040), «tres respuestas distintas» (L2183), «mecanismos documentados» (L2232), para no reabrir la ambigüedad pieza/artefacto que C1-54 cerró.

## Revisado y bien

1. **Bibliografía**: 204 `[Bnn]` definidas en el Anexo D, 204 citadas en el cuerpo, ninguna colgante, ninguna duplicada; todas con fecha de consulta (193 del 2026-10-07, 11 del 2026-10-09). Script: `defs in D 204 dup [] · defined not cited [] · cited not defined []`.
2. **Navegación**: 0 anclas internas rotas sobre todos los enlaces `](#…)`; toda referencia `§n.m` y `A.n` del cuerpo existe como encabezado (las tres que no, `§2.6`, `§12.2`, `§12.9.6`, son secciones de documentos externos citados en B13 y B24); el índice coincide con los `##` en orden.
3. **Marcas y voz**: 132 marcas fuera de código, todas en negrita y del vocabulario cerrado; 0 apariciones de las muletillas que lista Rule-Narrative-Voice («Es importante», «Cabe», «En resumen», «Asimismo», «Por otro lado», «Por consiguiente»…).

## Solicitudes de convocatoria

- **Verificación de evidencia / datos volátiles**: el Anexo F dice «SDK de .NET 10.0.401 vigente» mientras `entorno_validado` y el laboratorio usan 10.0.400, y «Python 3.15.0 prevista para el 2026-10-09»; confirmar en la fuente el estado al cierre (no es materia editorial: sólo señalo la fecha, hallazgo 05).
