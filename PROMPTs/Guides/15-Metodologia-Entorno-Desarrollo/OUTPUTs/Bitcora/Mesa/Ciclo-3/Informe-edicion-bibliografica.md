# Informe — Edición de material bibliográfico (Ciclo 3)

- **Especialista**: edición de material bibliográfico (estructura editorial, índice y numeración, citas y bibliografía, coherencia terminológica, voz única, redundancias, compresión, glosario).
- **Objeto**: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md`, versión 1.0.0 (`status: vigente`, 2026-10-09), 3605 líneas, 54 267 palabras (`wc -l -w`), sha256 `a2b78179…c48a691fd` (el mismo que deja `Ciclo-2/05-Aplicacion.md`: la guía no cambió desde la aplicación).
- **Modo**: a ciegas respecto del ciclo 3 (no se leyó ningún informe de otro especialista de este ciclo). De lo cerrado se leyeron `Ciclo-2/01-Consolidado.md` (filas de edición), `03-Parches.md` §1 (decisión C2-36: sin tope de palabras), `05-Aplicacion.md` y el informe de edición del ciclo 2. No se re-litiga: el presupuesto de compresión (C2-36, saldo ≤ 0 sin tope de 48 000), el no-reemplazo global de «registro» (`03-Parches.md` §9) ni la contradicción digest/runner (abierta por coherencia, fuera de este mandato).
- **Método**: lectura de front matter, índice, §0, §12, Anexos B, C, D (encabezado y cola), E y F completos y control de cambios; chequeos mecánicos: `Ciclo-2/aplicacion/checks.py` re-corrido sobre la guía actual, script propio de glosario (¿el término aparece en la sección que el glosario cita?), conteo de IDs de experimento, duplicados de URL en el Anexo D, referencias «guía §n.m» dentro de plantillas, fechas en las salidas del laboratorio, muletillas y voz.

## Hallazgos

### edicion-bibliografica-01 — §0.3 promete la fecha de ejecución «de su salida» y ni las salidas ni el Anexo E la dan

- **Nivel**: E1 · **Severidad**: S3
- **Ubicación**: §0.3 L89; párrafo de apertura L24; Anexo E L3464.
- **Ancla**: L89: «E4-2 | Resultado del experimento E4-2, ejecutado en la fecha de su salida; la carpeta, el comando y la salida están en el Anexo E». L24 y L3464: «se ejecutó el 2026-10-07 (las ampliaciones de la revisión, el 2026-10-09)».
  ```text
  $ find Examples -path '*salidas*' -name '*.txt' | wc -l                         -> 85
  $ grep -rlE '2026-10-0[0-9]|…' (salidas/*.txt) | wc -l                          -> 19   (66 sin fecha)
    sin fecha, p. ej.: N7/salidas/E7-01-*.txt, A-plantillas/salidas/EA-1-plantillas.txt,
                       N8/salidas/E8-3-*.txt, N1/salidas/e1-roslyn-sdk8.txt, N4/salidas/e2-nuget-cpm-pinning.txt
  Anexo E: columnas «ID | Qué demuestra | Carpeta / script | Salida»: no hay columna ni marca de fecha por fila.
  ```
  Según `Ciclo-2/05-Aplicacion.md` §4.2, N7 (E7-1…E7-7), E8-3 y EA-1 se regeneraron el 2026-10-09; además E2-7, E2-8 y E8-6 («comando de la guía») son de esa fecha. El lector no puede saber cuáles: la salida no lo dice, el Anexo E tampoco, y «las ampliaciones de la revisión» nombra un proceso de trabajo que la obra terminada no define (el lector no sabe qué fue «la revisión» ni qué amplió). La dirección de C2-49 movió la fecha a «la de su salida», que no existe para 66 de 85 archivos.
- **Dirección**: en el Anexo E, una línea antes de la tabla: «Se corrieron el 2026-10-07, salvo E2-7, E2-8, E7-1…E7-7, E8-3, E8-6 (comando de §11.5) y EA-1, corridos o regenerados el 2026-10-09», con la lista exacta tomada de `05-Aplicacion.md` y de los ciclos anteriores (o una columna «Fecha»); §0.3 → «ejecutado en la fecha que indica el Anexo E»; L24 y L3464 → «el 2026-10-07 (los que lista el Anexo E, el 2026-10-09)», sin «la revisión».

### edicion-bibliografica-02 — El glosario remite a secciones donde el término no está y fija una regla («siempre con su complemento») que el texto no cumple; faltan dos alias

- **Nivel**: E1 · **Severidad**: S4
- **Ubicación**: Anexo C L3147 (ACP), L3213 (Registro de paquetes / de imágenes), L3229 (VS), L3199 (Lock file), L3217 (Restauración estricta).
- **Ancla**: script que busca la primera palabra del término en el texto de la sección citada:
  ```text
  MISS 3147 ACP (página de códigos ANSI) | ACP in §4.1      (§4.1 define «Página de códigos ANSI del sistema» sin la sigla; «ACP» aparece primero en el mermaid de L485)
  MISS 3213 Registro de paquetes / de imágenes | in §8.1    (§8.1 no habla de registro de imágenes; «registro de imágenes» aparece 1 vez, L2884, dentro de A.12)
  MISS 3229 VS | VS in §2.1                                  (§2.1 no usa «VS»; las 5 apariciones están en §6.2.2, §6.4, §6.6 y §8.2.4)
  ```
  L3213 dice «siempre con su complemento», pero fuera de código hay unas 15 apariciones sin complemento con sentido *registry*: L1174 «de qué registro puede venir cada paquete», L1237 «un registro por *scope*… va al registro por defecto», L1719 «Procedencia en el registro», L2476 «registros en el repo», L2494 «locks y registros por ecosistema». El reemplazo global se descartó en el ciclo 2 (`03-Parches.md` §9); lo que queda incoherente es la promesa del glosario. Además, «modo estricto» (18 apariciones fuera de código) y «restauración estricta» (18) nombran lo mismo, y el glosario no registra el alias; tampoco «lock» (359) como forma corta de «Lock file». Rule-Dual-Audience: «los sinónimos se registran como alias del término canónico».
- **Dirección**: (a) ACP: agregar «(ACP)» a la definición de §4.1 L451 o hacer que el glosario remita a §4.2.1; (b) VS: remitir a §6.2.2; (c) Registro de paquetes / de imágenes: remitir a §7.1 y A.12, y cambiar «siempre con su complemento» por «con su complemento cuando el contexto no lo deja claro»; (d) «Restauración estricta… Alias: modo estricto»; «Lock file… Alias: lock».

### edicion-bibliografica-03 — La plantilla A.1 remite a §11.3 por la política de texto raíz, que está en §11.2.2

- **Nivel**: E1 · **Severidad**: S4
- **Ubicación**: Anexo A.1 L2529, y el mismo comentario en `Examples/A-plantillas/repo/.editorconfig` L1.
- **Ancla**:
  ```text
  L2529  # Política de texto del repositorio (guía §5, §11.3; Anexo A.1).
  L2170  #### 11.2.2 Política de texto raíz, por extensión
  L2297  ### 11.3 Qué propone la industria      (tabla «Agrupación que documenta el fabricante | Cómo invoca a otros»)
  $ grep -n '11.3' Examples/A-plantillas/repo/.editorconfig  -> 1:# Política de texto del repositorio (guía §5, §11.3; Anexo A.1).
  ```
  Es la única referencia interna rota en contenido de las cinco «guía §n.m» de las plantillas (L2529, L2574, L2783, L2998, L3041); las otras cuatro resuelven a la sección que tratan.
- **Dirección**: «(guía §5, §11.2.2; Anexo A.1)» en la guía **y** en `Examples/A-plantillas/repo/.editorconfig`, en el mismo cambio, para que A.1 siga igual byte a byte al laboratorio (`aplicacion/anexoA.py`) y EA-1 se vuelva a correr.

### edicion-bibliografica-04 — La Práctica integradora pide «cada validación» y la respuesta cubre cinco de once

- **Nivel**: E1 · **Severidad**: S4
- **Ubicación**: §12, Práctica integradora, ítem 1 (L2515); contrato `validaciones` L2499–L2510.
- **Ancla**: «Para cada validación del contrato, nombrá el experimento que la mostró y predecí el mensaje. *Respuesta esperada*: paso 3, E2-2 …; 4, E2-3 …; 5, E3-1 …; 6, E4-1 y E4-4 …; 7, E7-4 …». El contrato tiene once validaciones (pasos 1, 2, 3, 4, 5, 6, 7, 8a, 8b, 9, 10); la respuesta omite 1, 2, 8a, 8b, 9 y 10, aunque el propio contrato nombra su experimento en tres de ellas (paso 1 `e1-diagnostico.sh` = E1-09; paso 2 «EA-1, paso 1»; paso 10 «los quince lectores de E8-1»).
- **Dirección**: completar la respuesta: «1, E1-09; 2, EA-1 paso 1; 8a, EA-1 (registro del entorno, A.17); 10, E8-1 (columna A); 8b y 9 no tienen experimento: requieren una plataforma alojada (Anexo F)». La última cláusula enseña también qué quedó sin verificar. Alternativa más corta: acotar la consigna a «las validaciones de los pasos 3 a 7».

### edicion-bibliografica-05 — Los «Datos volátiles» del Anexo F no citan ninguna fuente, y B181 y B217 repiten las mismas tres URL

- **Nivel**: E1 · **Severidad**: S4
- **Ubicación**: Anexo F L3591; Anexo D L3422 (B181) y L3458 (B217); A.12 L2927.
- **Ancla**:
  ```text
  $ sed -n 3591p GUIA | grep -c '\[B'      -> 0
    («SDK de .NET 10.0.401 vigente y .NET 11 en RC1; … Node 24 LTS activa, Node 26 Current, Node 20 sin soporte; … npm 12; pnpm 12;
      pre-commit 4.6.2; actions/checkout v7.0.1; SLSA v1.2; CycloneDX 1.7; SPDX 3.0.1», «revisar antes de aplicar»)
  script de URL duplicadas en el Anexo D:
    https://github.com/actions/setup-dotnet  ['B181', 'B217']
    https://github.com/actions/setup-node    ['B181', 'B217']
    https://github.com/astral-sh/setup-uv    ['B181', 'B217']
  ```
  La línea existe para que el lector revalide cada dato, pero no le dice dónde: tiene que buscar en el cuerpo qué `[Bnn]` respalda cada uno (B180 para pre-commit, B193 para `actions/checkout`, B205 para Python 3.15.0, etc.). B181 (2026-10-07) y B217 (2026-10-09) son la misma fuente consultada dos veces; B217 sólo agrega `setup-python` y las etiquetas por `git ls-remote`, y se cita una sola vez (L2927, «entradas de [B181]; SHA de [B217]»).
- **Dirección**: en L3591, cada dato con su `[Bnn]` entre paréntesis (sin agregar texto). Para B181/B217: retitular B217 «GitHub Actions — `setup-python`; etiquetas y SHA de las cuatro acciones de *setup* (`git ls-remote`)» y dejar en su URL sólo `actions/setup-python` más la nota «las otras tres, como B181»; o fundirlas en B181 con dos fechas. **[criterio]**: la primera opción no renumera la bibliografía.

## Revisado y bien

1. **Navegación y bibliografía, re-corridas sobre 1.0.0**: `checks.py` del ciclo 2 da `encabezados=183 anclas=183 enlaces internos=91 rotos=0`, `índice en orden con ## : True (20 = 20)`, `rutas Examples/… citadas=39 inexistentes=[]`, `Bnn definidas=217 citadas=217`, `IDs de experimento en el cuerpo=71 sin fila en el Anexo E=[]`. Las 217 filas del Anexo D tienen fecha y coinciden con la regla del encabezado (B01–B193 el 2026-10-07; B194–B217 el 2026-10-09; 0 discrepancias). El conteo «73 experimentos» del encabezado coincide con los IDs del Anexo E expandidos (73), y el «71» de la fila 1.0.0-borrador es histórico (E2-7 y E2-8 llegan en rc.1).
2. **Estructura editorial**: los capítulos 4 a 11 tienen n.1–n.9 completos; ningún encabezado salta de nivel; los 68 bloques de código declaran lenguaje; el control de cambios quedó en celdas breves con el detalle en prosa debajo (la celda de 320 palabras del ciclo 2 ya no existe); celdas de tabla ≥ 60 palabras bajaron a 5 (máx. 78) y párrafos ≥ 150 palabras a 7. `status: vigente` coincide con el vocabulario de la colección (205 guías con `vigente`).
3. **Voz única**: 0 apariciones de las muletillas que lista Rule-Narrative-Voice («Es importante», «Cabe», «En resumen», «Asimismo», «Por otro lado», «Por consiguiente»…); voseo uniforme (0 «usted», 0 «puedes/tienes/debes»); 0 restos de proceso en el cuerpo (`C1-`, `C2-`, «mesa», «parche P-» sólo en `traces` y en el control de cambios), salvo «las ampliaciones de la revisión» (hallazgo 01). La corrección de C2-35 en §11.2.5/§11.5 («entre la compuerta y el registro del entorno») está aplicada.

## Solicitudes de convocatoria

- **Indexación de la colección (Rule-Indexing / dueño de `Guides/README.md`)**: `grep -i metodolog LAB/Lab-Documentos/Guides/README.md` no devuelve nada; la guía `vigente` no figura en el índice de la colección. Este panel no puede escribir ese archivo; corresponde al PO o al agente encargado del cierre.
- **Verificación de datos volátiles**: «SDK de .NET 10.0.401 vigente» (Anexo F) se declara «al 2026-10-07» mientras `entorno_validado` y el laboratorio usan 10.0.400 y la pregunta C2-Q08 quedó sin respuesta en el ciclo 2. Es materia de exactitud, no editorial: sólo señalo que la fecha atribuida al dato no se puede comprobar desde la guía (hallazgo 05).
