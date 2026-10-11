# Mesa · Ciclo 2 · Informe del abogado del diablo

- **Rol**: abogado del diablo (núcleo permanente). Marco: `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §4.1.1 (mandato de atacar la propuesta dominante; entra después de leer al resto) y §9 (anclaje, consenso vacío).
- **Objeto**: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md`, 1.0.0-rc.1 (3391 líneas). «L*n*» = línea de ese archivo al 2026-10-09.
- **Fecha**: 2026-10-09.
- **Orden de lectura, a propósito**: primero la guía completa como obra terminada; después lo cerrado del ciclo 1 (`Ciclo-1/01-Consolidado.md`, `03-Parches.md` §1, `04*-Aprobacion-*.md` sobre C1-10, `05-Aplicacion.md`) y mi informe del ciclo 1; por último los once informes del ciclo 2 (requisitos, verificación-evidencia, lector-sin-contexto, didáctica, edición bibliográfica, senior-dotnet, arquitecto-software, desarrollador, AH-001, AH-002 y CAT-FORMAL).
- **Lo cerrado que no reabro sin contradicción E1/E2 demostrada**: C1-03 (lock por defecto en .NET, con la política sin lock al lado), C1-08 (compuerta propia reparada, editorconfig-checker como alternativa), C1-10 (síntesis de la tabla de BOM), C1-18 (8a/8b), C1-21 (etiqueta fija o receta de CI en el devcontainer), C1-36 y C1-37. Dos de ellas, C1-03 y C1-08, las reabro **sólo** en el punto donde la evidencia de este ciclo contradice la premisa con la que se votaron (hallazgos 01 y 02). Las demás las uso como norma vigente y señalo dónde quedaron aplicadas a medias.
- **Evidencia propia**: `evidencia-abogado-del-diablo/` en esta carpeta, cuatro experimentos con script y salida:
  - `01-lock-por-defecto/`: política .NET por defecto sobre una app WinExe y una consola;
  - `02-compuerta-de-texto/`: editorconfig-checker sobre el repo del Anexo A;
  - `03-plantilla-y-caso/`: A.1 sobre el heredado del caso;
  - `04-peso-8a-8b/`: cuánto texto dedica la guía a cada respuesta de la tercera pregunta.

  Corrieron en este host con Docker, `mcr.microsoft.com/dotnet/sdk:8.0` (SDK 8.0.425), `ghcr.io/editorconfig-checker/editorconfig-checker:4.0.2` y Python 3.13 (`-I`). Las copias de trabajo están en el scratchpad de la sesión. No se tocó `Examples/`.

## Qué ataco y qué no

En el ciclo 1 la pregunta era «¿necesario u opción?». En el ciclo 2 cambia: **¿la guía terminada entrega, tal como se copia, lo que dice que recomienda?** El panel del ciclo 2 encontró muchos defectos de plantilla y casi todos los trata como reparaciones locales. Mi ataque va a la premisa que esas reparaciones dan por buena:

- la política .NET por defecto (01);
- la compuerta propia (02);
- dónde pone la guía su peso para la tercera pregunta del caso (03);
- la imagen propia como paso obligado de la CI (07).

Hay además dos incoherencias de lo ya decidido (04 y 05) y un consenso de método del propio panel (06).

## Hallazgos

### abogado-diablo-C2-01 · S2 · E1: la política .NET por defecto, tal como la entregan las plantillas, en una app de escritorio (el proyecto típico de ESC-01) cobra el costo de `disable` y no da ni el lock ni `NU1603`. La defensa barata es compatible con el lock y la guía la presenta como exclusiva de la otra política

- **Ubicación**: A.4, comentario «Política SIN lock (guía, 6.4): descomentar» (L2529–L2531); A.4b (L2556); §6.4, tabla de las dos políticas (L1044–L1045); §7.2.1 [criterio] (L1179); §7.7, señal pobre «.NET sin lock y con `NU1603` como simple advertencia» (L1296).
- **Propuesta atacada**: «con lock» y «sin lock + `NU1603` como error» como dos paquetes excluyentes, con el primero por defecto (C1-03 (a), 3-1).
- **Ancla (E1, `01-lock-por-defecto/salida.txt`)**: se copian `global.json`, `Directory.Build.props`, `Directory.Build.targets` y `nuget.config` de `Examples/A-plantillas/repo/`. CPM pide `Microsoft.Extensions.Primitives 8.0.2`, una versión inexistente, como en E4-2. Hay un proyecto WinForms (`WinExe`, `net8.0-windows`, `EnableWindowsTargeting`) y una consola (`Exe`). SDK 8.0.425:

  ```text
  == 1. Plantillas TAL CUAL (política por defecto: lock + disable; NU1603 comentado)
  Consola (Exe), CI=true                 rc=0  NU1603:                  lock=SI
  Escritorio (WinExe), CI=true           rc=0  NU1603: warning NU1603   lock=NO
     {"OutputType":"WinExe","RestorePackagesWithLockFile":"","RestoreLockedMode":"true"}
  == 2. Lo mismo con NU1603 como error TAMBIÉN en la política con lock (A.4 descomentado)
  Consola (Exe), estación, cache fría (genera el lock)     rc=0  NU1603:            lock=SI
  Consola (Exe), CI=true                                     rc=0  NU1603:            lock=SI
  Escritorio (WinExe), CI=true                               rc=1  NU1603: error NU1603  lock=NO
  == 3. ... Microsoft.Extensions.Primitives Direct requested [8.0.2, ) resolved 9.0.0
  ```

- **Qué muestra**:
  1. Con las plantillas tal cual, la app de escritorio no recibe lock (senior-dotnet-01 lo encontró con WPF; acá se repite con WinForms), `RestoreLockedMode=true` no tiene nada que verificar y la aproximación 8.0.2 → 9.0.0 pasa como advertencia con `rc=0` en la CI. Al mismo tiempo, `global.json` con `disable` exige el SDK exacto en cada estación Windows. En ESC-01, el escenario del caso, la política por defecto paga el costo de las dos políticas y no obtiene el beneficio de ninguna.
  2. Con `NU1603` como error **además** del lock, el proyecto con lock no se rompe: `rc=0`, incluso al generar el lock con la caché fría. El proyecto sin lock, en cambio, se detiene. Las dos defensas no compiten: cada una cubre lo que la otra no ve. A.4 y §6.4 las presentan como alternativas porque toman la frase «con lock, el lock desarma este aviso» como si fuera un conflicto, y no lo es.
  3. La compensación que §7.2.1 promete para la política con lock (comparar `requested` con `resolved`) no está en la compuerta copiable (senior-dotnet-02, E1).
- **Por qué es contradicción y no re-litigio**: el voto (a) de C1-03 se fundó en que el lock por defecto «congela» y en que la alternativa quedaba escrita al lado. La evidencia del ciclo 2 (senior-dotnet-01, -02, -03 y este E1) muestra que, copiada, la política por defecto no congela el tipo de proyecto de ESC-01 y deja sin ninguna defensa la deriva que la guía usa para justificarla (E4-2). No pido cambiar el default. Pido que el default cumpla su propia premisa.
- **Contra-tesis [criterio]**: `NU1603` como error en **las dos** políticas, activo en A.4 y no comentado. Lock con la condición `Exe` o `WinExe` (senior-dotnet-01). La política con lock deja de verse como «lock en vez de `NU1603`» y pasa a ser «lock **más** `NU1603`».
- **Impacto**: el lector que copia el Anexo A para una solución WinForms o WPF, el caso más probable en un sistema .NET heredado con Visual Studio, cree que tiene el grafo congelado y verificado en CI, y no tiene ninguna de las dos cosas.
- **Dirección**:
  - A.4: descomentar `NU1603` y cambiar el comentario a «vale con lock y sin lock: con lock no se dispara (E1 de este informe); sin lock, corta la aproximación».
  - §6.4: sacar `NU1603` de la fila «Sin lock» como rasgo distintivo y ponerlo en las dos filas.
  - §7.7: la señal pobre pasa a ser «`NU1603` como simple advertencia», sin el «.NET sin lock».
  - A.4b: aplicar senior-dotnet-01.
  - Anclar el experimento como E4-2, paso 7.
- **Confianza**: 0,85. Corrió con un solo SDK (8.0.425). La conducta de la consola con lock coincide con E4-2 en SDK 10 (C1-Q09, cerrado por el auditor).

### abogado-diablo-C2-02 · S2 · E1: la compuerta de texto propia sumó en el ciclo 2 cinco defectos de copia, uno de ellos un falso verde con el cp1252 del caso. La herramienta existente pasa las mismas condiciones sin Python. La premisa de C1-08 («reparar el script alcanza») quedó contradicha

- **Ubicación**: §5.2.5 [criterio] (L742); §10.2.2 (L1843, L1849); A.11 «Qué se copia y adónde» y «Prerrequisitos» (L2755–L2757); B.1, ítem 2 (L2906); §12, paso 4 (L2389).
- **Propuesta atacada**: `check_text_policy.py` (con `compuerta.sh` o `verificar.sh`) como paso de texto por defecto, y editorconfig-checker como alternativa al pie (C1-08 (a), 3-1).
- **Ancla**:
  1. **Defectos de copia del ciclo 2**, todos con E1 de otros especialistas:
     - arquitecto-software-01: con la ruta de A.11 para subcarpetas, `verificar.sh` en `tools/ci/` da `texto: OK` con el `.cs` cp1252 del caso;
     - desarrollador-01: la imagen de A.10 no trae `editorconfig`, la CI queda siempre roja y lo informa como violación de política;
     - lector-sin-contexto-01: copiados desde Windows, el hook queda ignorado y la CI da `Permission denied`;
     - lector-sin-contexto-04: el hook da verde a un lock no marcado que la CI rechaza;
     - lector-sin-contexto-06: sin `.gitignore`, violaciones dentro de `obj/`.

     Se suman a los cuatro del ciclo 1 (AS-01, AS-03, lector-02 y lector-03, mi CS-2).
  2. **E1 propio** (`02-compuerta-de-texto/salida.txt`): editorconfig-checker 4.0.2 sobre una copia del repo del Anexo A, que tiene la disposición en subcarpetas que hizo fallar a `verificar.sh`:

     ```text
     == 0. Imagen: v4.0.2 ; ¿trae python3? no
     == 1. Plantillas limpias ...                                   rc=0
     == 2. El .cs del caso en cp1252, en una SUBCARPETA (src/App), y un .razor sin BOM
     src/App/Alarma.cs:  wrong character encoding ("ISO-8859-1" instead of "utf-8")
     src/App/X.razor:    wrong character encoding ("Ascii" instead of "utf-8-bom")
     2 errors found                                                  rc=1
     == 3. ... sin .gitignore: src/App/obj/App.csproj.nuget.g.props:
        con .gitignore (obj/ excluido), líneas que mencionan obj/: 0
     == 4. Sólo lo versionado (git ls-files) ...  2 errors found     rc=1
     ```

     Lee el mismo `.editorconfig` del Anexo A sin falsos rojos (`rc=0` sobre las plantillas). Detecta el cp1252 del caso y el BOM faltante en cualquier carpeta. Es un binario estático, sin intérprete ni paquete de PyPI. Respeta `.gitignore` y acepta la lista de archivos versionados como alcance.
- **Límites, para no sobrevender**:
  - No resuelve el bit de ejecución del hook (lector-01): eso es de git, no del verificador.
  - Revisa el working tree. Con `git ls-files` como argumento, el alcance es lo versionado, no el índice exacto de un commit parcial.
  - No da el diagnóstico «¿cp1252?».
  - Los pasos de toolchain y grafo siguen siendo propios.
- **Contra-tesis [criterio]**: en A.11, en §10.2.2 y en §12, paso 4, el paso de **texto** de la compuerta se arma por defecto con editorconfig-checker (más `dotnet format whitespace --verify-no-changes` para `.cs`). `check_text_policy.py` queda como ejemplo didáctico y como opción cuando se necesite verificar el índice de un commit parcial. La regla «una sola compuerta en hook y CI» no cambia: cambia qué corre adentro.
- **Impacto**: la red que, según §12 paso 4, hace que «el problema del caso no pueda volver sin que alguien lo vea» es la pieza con más defectos de copia de la guía, dos ciclos seguidos. Cada reparación agrega texto y prerrequisitos (B.1 ya pide Python, un paquete fijado y bash en cada estación Windows).
- **Dirección**: reordenar la tabla de §5.2.5 (la herramienta existente primero, con este E1 sumado a E2-7) y el párrafo [criterio] de L742. En A.11 y B.1, el prerrequisito del paso de texto pasa a ser un binario fijado por versión. Los hallazgos desarrollador-01 y arquitecto-software-01 se resuelven de rebote, y lector-01, -04 y -06 siguen aplicando.
- **Confianza**: 0,75.

### abogado-diablo-C2-03 · S2 · E1: la respuesta a la tercera pregunta del caso (8a, «registro del entorno») no tiene plantilla ni muestra de formato. La respuesta condicional (8b, procedencia firmada) tiene tres snippets y el párrafo más largo del capítulo

- **Ubicación**: §12, pasos 8a y 8b (L2393–L2394) y frase de cierre (L2398: «8a, la tercera»); §9.2.4 (L1634–L1665); §9.5 (L1708–L1724); §9.6 P1 (L1731); Anexo A (sin plantilla de registro); `Examples/N8-…/solucion/registrar-entorno.sh`.
- **Propuesta atacada**: el reparto de peso que dejó C1-18. La decisión (8a para todos, 8b condicional) se tomó 4-0, pero el texto siguió escrito como antes.
- **Ancla (E1, `04-peso-8a-8b/salida.txt`, `medir.py` sobre la guía)**:

  ```text
  §9.2.4 Procedencia SLSA y firma (8b)       L1634-L1665  931 palabras
  §9.2.3 SBOM (8a)                           L1615-L1633  298 palabras
  §11.2.8 SBOM y procedencia políglota       L2175-L2184  405 palabras
  SLSA 58 · builder.id 22 · atestaci 20 · cosign 13 apariciones
  bloques de código que muestran el registro del entorno (formato/contenido): 1   > solucion/   (sólo el nombre del archivo en un árbol)
  bloques de código de procedencia/firma: 3
  ```

  El único script de registro del laboratorio no está en el Anexo A y, fuera del workflow de ejemplo de N8 (que la guía no cita), escribe `imagen=desconocida` (arquitecto-software-02). La guía dice qué tiene que tener el registro (§9.6, seis puntos), pero no muestra uno.
- **Contra-tesis [criterio]**: para el caso, que es un repositorio privado, de un equipo chico y con artefactos internos, la guía misma decide que alcanza con 8a (§3.4, §9.2.4 L1658). Entonces la plantilla que falta es la del registro: un A.x de unas quince líneas (SDK, compilador por `CS8304`, runtimes, digest de la imagen o del runner, commit y árbol limpio, hash de los locks y del artefacto) y una salida de ejemplo. La procedencia firmada queda como detalle de 8b, en un bloque subordinado («Si hay un consumidor externo»).
- **Impacto**: el lector que llega con la tercera pregunta encuentra mucho sobre cómo **no** declarar L2 y nada que copiar para contestarla. Es lo inverso de lo que el propio §12 ordena.
- **Dirección**:
  - Agregar A.x «Registro del entorno», copiado de `registrar-entorno.sh` y con el digest resuelto (no `desconocida`), con su salida.
  - Comprimir §9.2.4: la tabla de niveles, la firma y los tres caminos sin plan Enterprise pasan a un bloque «Para 8b», y la frase de cada camino se reduce a una línea.
  - Meta de compresión [criterio]: §9.2.4 por debajo de 600 palabras, lo que compensa con creces el anexo nuevo.
  - Coordinar con arquitecto-software-02 (A.12 sin registro) y con edición bibliográfica-04 (presupuesto de palabras).
- **Confianza**: 0,8.

### abogado-diablo-C2-04 · S3 · E2: C1-21 (etiqueta fija o receta de la CI en el devcontainer) quedó aplicada en §8 y §3.6, pero tres tablas y la lista del revisor siguen pidiendo digest en el devcontainer

- **Ubicación**:
  - §6.4, fila ESC-04 (L1037): «Imagen construida desde los archivos nativos y fijada por digest (§8)».
  - §9.4, fila ESC-04 (L1683): «Con la misma imagen por digest que la CI, el lugar natural para reconstruir».
  - §10.2.5, fila `Dockerfile`, `devcontainer.json` (L1870): «¿Sigue por digest?».
  - B.4, ítem 5 (L2943): «¿La imagen sigue fijada por digest…?».
- **Ancla**: §8.2.2, punto 2 (L1373): «En el devcontainer, "mismo SDK", no "misma imagen"… Un digest en la `image` de `devcontainer.json` sólo con un bot que lo actualice: en un repositorio privado el ecosistema `devcontainers` de Dependabot no está soportado». Las mismas recomendaciones aparecen en §3.6 (L390), §8.4 (L1458), §8.6 (L1496 y L1514), §8.7 (L1520) y B.3. El § `05-Aplicacion.md` dio C1-21 por aplicado, y ningún informe del ciclo 2 revisó estas cuatro filas (lector-sin-contexto-04 toca la frase de §10.4 por otro motivo).
- **Impacto**: el revisor que sigue B.4 rechaza un `devcontainer.json` con etiqueta fija, que es justamente lo que §8.2.2 recomienda. El lector de consulta que entra por §6.4 o §9.4 recibe la recomendación anterior.
- **Dirección**:
  - §6.4 ESC-04: «Etiqueta fija de SDK y SO verificada por `global.json`, o la receta de la imagen de CI (§8.2.2)».
  - §9.4 ESC-04: «Con la receta de la imagen de CI, el lugar natural para reconstruir».
  - §10.2.5 y B.4: «¿Lo que construye artefactos publicados sigue por digest? ¿El devcontainer usa etiqueta fija o la receta de la CI, y su SDK coincide con `global.json`?».
  - Que el auditor busque con `grep -n "digest"` en filas ESC-04 y listas antes de cerrar.
- **Confianza**: 0,85.

### abogado-diablo-C2-05 · S3 · E1: la plantilla por defecto (A.1, variante A) es la que la guía desaconseja para su propio caso, y la variante que recomienda para el caso falla con los `.csproj`

- **Ubicación**: A.1 (L2438–L2460); §5.5 «núcleo de la plantilla» (L849–L863); §5.2.3, rama «Heredado ya convertido a UTF-8 con BOM» (L715); §5.6 P1 (L890); §1.4 (L179).
- **Propuesta atacada**: «UTF-8 sin BOM» como valor por defecto copiable de la familia .NET, en una guía cuyo hilo es un heredado ya convertido **con** BOM.
- **Ancla (E1, `03-plantilla-y-caso/salida.txt`, editorconfig-checker sobre el `.editorconfig` de A.1)**:

  ```text
  == A.1 tal cual (variante A): el heredado del caso, ya convertido con BOM (3 .cs + 1 .csproj)
     violaciones: 4
  == A.1 con la variante B descomentada ([*.cs] charset = utf-8-bom)
  src/Servicios/Servicios.csproj:  wrong character encoding ("UTF-8-SIG" instead of "utf-8")
  1 errors found   rc=1
  ```

  En el caso real (unos cien archivos), copiar §5.5 o A.1 tal cual da unas cien violaciones en el primer commit de política. Con la variante B que la guía recomienda para ese estado, igual falla con los archivos de proyecto (lector-sin-contexto-03 lo midió con `dotnet new`; acá se repite con otro verificador).
- **No re-litigo C1-10**: la tabla, la columna «Lo decide» y las tres ramas quedan como están. Ataco cuál de las ramas es la que se copia por defecto, que C1-10 no decidió.
- **Contra-tesis [criterio]**: en una guía que se presenta desde el caso, la plantilla muestra las dos variantes **activas como alternativas explícitas** (dos bloques, «A: repo nuevo» y «B: heredado con BOM, como el del caso»), no una activa y otra comentada. La variante B cubre `[*.{cs,csproj,props,targets}]`, y la convención de la familia .NET queda como §5.2.3 la escribe («la misma convención que `*.cs`»).
- **Impacto**: es la pregunta 1 del PO, «UTF-8 con o sin BOM», en el lector más probable: el del caso. La guía responde bien en prosa y mal en lo que se copia.
- **Dirección**:
  - A.1 y §5.5: dos bloques A/B, con B ampliada a los archivos de proyecto.
  - §5.9 P2: agregar los `.csproj`.
  - B.2: las tres ramas (lector-sin-contexto-05, edición bibliográfica-06).
- **Confianza**: 0,8.

### abogado-diablo-C2-06 · S3 · E2: consenso de método del ciclo 2. El PO pidió edición y compresión, edición bibliográfica midió que la guía creció un 22 %, y casi todas las direcciones del panel agregan texto

- **Ubicación**: global; PO («hacer las correcciones pertinentes en edición y compresión ajustando su coherencia»); edición bibliográfica-04 (53 363 palabras, meta ≤ 48 000); didáctica-05 (15 párrafos de 150 palabras o más).
- **Ancla**: mi clasificación de las direcciones de los 71 hallazgos del ciclo 2, leyendo cada «Dirección». Es **[criterio]** en la asignación de cada ítem y E2 en la lectura:

  | Informe | Agrega texto, filas, consignas, plantillas o experimentos | Neutro (corrige o reescribe con largo parecido) | Quita o comprime |
  |---|---|---|---|
  | requisitos | 01, 03, 04, 05 | 02, 06 | — |
  | verificación-evidencia | — | 01, 02, 04 | 03 (una frase) |
  | lector-sin-contexto | 01, 02, 04, 06 | 03, 05 | — |
  | didáctica | 01, 02, 03, 04, 06 | 05, 07 | — |
  | edición bibliográfica | 03 | 01, 05, 06, 07 | 02, 04 |
  | senior-dotnet | 01, 02, 03 | — | 04, 05 |
  | arquitecto-software | 01, 02, 04, 06 | 03, 05 | — |
  | desarrollador | 01, 02, 03, 04, 06 | 05, 07 | — |
  | AH-001 | 01, 03 | 02, 04 | — |
  | AH-002 | 01, 04, 05 | 02, 03, 06 | — |
  | CAT-FORMAL | 01 | 02, 03, 04, 05 | — |
  | **Total** | **≈ 32** | **≈ 31** | **≈ 5** |

  Sólo edición bibliográfica fija una meta y sólo senior-dotnet propone borrar repeticiones concretas (18 apariciones de `A compatible .NET SDK was not found` o «SDK exacto»).
- **Por qué es sospechoso**: nadie se opone a comprimir, pero tampoco nadie paga la compresión. Si el auditor aplica todo lo que procede, la versión 1.0.0 va a ser más larga y más densa que la rc.1, en contra del pedido explícito del PO y de Rule-Narrative-Voice («si un párrafo se puede borrar sin perder información, sobra»).
- **Contra-tesis [criterio]**: presupuesto de compresión como restricción del ciclo y no como un hallazgo más. Cada parche que agrega declara su costo en palabras, y el lote cierra en saldo negativo, con la meta de edición bibliográfica-04 medida con `wc -w`. Hay fuentes de compresión ya identificadas que no tocan evidencia:
  - la celda de 320 palabras del control de cambios;
  - la instrucción de lectura de §3, repetida cuatro veces;
  - las 18 repeticiones del costo de `disable`;
  - §9.2.4 (hallazgo 03);
  - las listas «Señales de una versión pobre» pasadas a viñetas con remisión, sin repetir el criterio.
- **Impacto**: el riesgo es entregar como «obra finalizada» una guía de más de 55 000 palabras cuyas reglas centrales (las de §12) quedan enterradas.
- **Dirección**: que el consolidado del ciclo 2 incluya una columna «Δ palabras» por parche y que el auditor rechace un lote con saldo positivo salvo que la mesa lo vote.
- **Confianza**: 0,7. La clasificación es mía y otro lector puede mover unos pocos ítems de columna, pero no el orden de magnitud.

### abogado-diablo-C2-07 · S3 · E2 + E4: «¿contenedor siempre?» en la CI. §12 paso 7 impone a todo equipo una imagen propia por digest. El camino que documentan Microsoft y GitHub (runner alojado más acciones de *setup* que leen los archivos nativos) no aparece como opción, y en un repositorio privado la imagen propia tiene dos eslabones que nadie mantiene

- **Ubicación**: §12, paso 7 (L2392); §8.2.2, punto 1 (L1372); §11.2.7 (L2173); A.12 (L2775–L2777). Se mencionan al pasar, sin presentarlas como opción, en §6.4 ESC-05 (L1038: «La imagen o las acciones de *setup*») y §10.2.4 (L1859: «o el toolchain instalado desde los archivos del repo [B181]»).
- **Ancla**:
  - GitHub Docs, *Building and testing .NET* (https://docs.github.com/en/actions/tutorials/build-and-test-code/net, consultado el 2026-10-09): el ejemplo usa `runs-on: ubuntu-latest` y `actions/setup-dotnet`, sin imagen de contenedor.
  - Microsoft Learn, *Create a build validation GitHub workflow* (https://learn.microsoft.com/en-us/dotnet/devops/dotnet-build-github-action, consultado el 2026-10-09): `actions/setup-dotnet` en una matriz `ubuntu-latest, windows-latest, macOS-latest`, sin contenedor. Esa matriz es la que §11.2.7 llama «la forma barata de detectar en CI lo que mostró el caso».
  - README de `actions/setup-dotnet` (https://github.com/actions/setup-dotnet, consultado el 2026-10-09): «can read .NET SDK version from a `global.json` file. Input `global-json-file`».
  - Tabla de Dependabot ([B107], consultada el 2026-10-09): `github-actions` está soportado en repositorios privados y `devcontainers` no.
  - En el camino de la imagen propia, AH-002-04 mostró que ningún ecosistema de Dependabot documenta actualizar el digest de `container:` y AH-002-05, que la imagen privada de GHCR no se descarga con los permisos de A.12.
- **Límites**: los ejemplos de los fabricantes son tutoriales, no prueba de «lo que hace la industria», y usan `dotnet restore` sin modo estricto y acciones por etiqueta. Con el runner alojado, la capa 4 (SO del runner) flota y hay que registrarla. Cómo informa la plataforma la versión de la imagen del runner **[no verificado]**. La caché de NuGet de `setup-dotnet` usa como clave el hash de `packages.lock.json`: es el hueco de caché caliente de E4-3, cubierto por `contentHash` sólo con la política con lock.
- **Contra-tesis [criterio]**: para 8a, el caso alcanza con «toolchain = archivos nativos» verificado por la compuerta. Las acciones `setup-dotnet`, `setup-node` y `setup-uv`, fijadas por SHA y alimentadas por `global.json`, `.nvmrc` y `.python-version`, lo cumplen, y las actualiza un bot que sí funciona en repos privados. La imagen propia por digest se justifica cuando hace falta igualdad de la capa 4 o reconstrucción bit a bit (8b, §3.4 fila 3) o cuando la frontera A obliga a tener los tres runtimes en un proceso. Son dos opciones con su escenario, no un paso obligado.
- **Impacto**: un equipo chico que sigue §12 al pie de la letra construye, publica, parchea y referencia por digest una imagen propia, con dos eslabones sin bot en un repositorio privado. Con eso llega al estado que §8.2.2 llama «congeló vulnerabilidades», para contestar una pregunta que la guía misma resuelve con el registro del entorno.
- **Dirección**:
  - §12 paso 7: «imagen de CI por digest **o** runner alojado con acciones de *setup* fijadas por SHA que leen los archivos nativos (§10.2.4); la primera si se necesita 8b o la frontera A en CI».
  - §8.2.2 punto 1: condicionar igual.
  - A.12: una variante corta con `setup-*` y `global-json-file`, rotulada **Ilustrativo**.
  - Mantener la matriz por SO de §11.2.7 como recomendación barata para el caso.
- **Confianza**: 0,65. Es criterio sobre fuentes de fabricante, sin E1 en una plataforma alojada.

## Consensos sospechosos

| # | Consenso | Quiénes lo comparten | Por qué es sospechoso | Hallazgo |
|---|---|---|---|---|
| CS2-1 | «La política .NET por defecto está bien; hay que emparcharla» | senior-dotnet-01, -02, -03; arquitecto (solicitud sobre D-1) | Es CS-1 del ciclo 1 otra vez: tres hallazgos con E1 corrigen síntomas (WinExe, `requested≠resolved` ausente, SDK sin soporte) y ninguno pregunta qué entrega el default copiado. Juntos dicen que en ESC-01 no entrega nada. | 01 |
| CS2-2 | «La compuerta propia se repara» | desarrollador-01, arquitecto-software-01, lector-sin-contexto-01, -04, -06 | Es CS-2 por segunda vez: cinco reparaciones nuevas y ninguna vuelve a la alternativa que C1-08 dejó escrita. | 02 |
| CS2-3 | «Faltaba esto: agregarlo» | Los once informes | ≈ 32 direcciones agregan y ≈ 5 quitan, en un ciclo cuyo mandato es la compresión. | 06 |
| CS2-4 | «Precisar la procedencia» | AH-002-02, arquitecto-software-02 y -03 | Afinan `builder-id`, las tres piezas y un segundo job de A.12 sobre la parte condicional (8b), mientras la parte obligatoria (8a) no tiene plantilla. | 03 |
| CS2-5 | «C1-21 está aplicado» | `05-Aplicacion.md`; nadie lo contrastó en el ciclo 2 | Cuatro filas siguen con la recomendación anterior. | 04 |
| CS2-6 | Panel sin voz de ESC-01, tercera vez | Convocatoria del ciclo 1 §5; solicitudes de lector-sin-contexto (ciclo 1 y 2) y la mía del ciclo 1 | Los hallazgos de mayor severidad del ciclo 2 (bit de ejecución, Git Bash, WinExe, `disable`, plantilla por defecto) son de Windows y se midieron en Linux simulando. | solicitud |

## Revisado y bien: ataques que la guía resistió

1. **«¿Contenedor siempre?» para desarrollar.** Ataqué la idea de que la guía exige devcontainer y no lo hace: §8.2.4, reglas 1–5, «el devcontainer es una comodidad… no un requisito» (L1407), y §12 (L2398: «lo que no tiene (el devcontainer) no se le exige»). Con E5-1 como base, la tesis «el contenedor no arregla los bytes» se sostiene en §1.3, §3.5, §4.6 y §8.6 sin contradicciones. El ataque sólo prospera para la CI (hallazgo 07).
2. **«¿Lock siempre?» en npm y uv.** La guía sigue alineada con el fabricante (§7 apertura, L1140, con [B93][B99]). La tabla de §7.3 separa bien lo que falla de lo que reescribe, y AH-001-03 mostró que los «no verificado» que quedan se pueden cerrar con mensajes concretos, no que el criterio esté mal.
3. **«¿UTF-8 sin BOM es una preferencia?» fuera de .NET.** E8-1 (columna A pasa los quince lectores; columna B rompe cinco) sigue sosteniendo la regla por extensión y por lector (§11.2.2), y la verificación-evidencia del ciclo 2 re-corrió E1-11 con el mismo resultado. La versión rc.1 ya separa «lo decide un lector» de «convención del equipo» (§5.2.3). El ataque prospera sólo en lo que se copia (hallazgo 05).

## Solicitudes de convocatoria

- **Especialista en estaciones Windows / Visual Studio** (cola priorizada #1 desde la convocatoria del ciclo 1; es la tercera solicitud). Señal: los hallazgos 01, 02 y 05 de este informe y lector-sin-contexto-01, -02 dependen de ESC-01. Pregunta concreta: en una estación Windows con Visual Studio, (a) ¿qué modo registra Git for Windows para un `.sh` nuevo? (b) ¿un proyecto WinForms recibe lock con A.4b corregida? (c) ¿Visual Studio conserva el BOM de los `.csproj` al editarlos? Si no hay host Windows, que el auditor lo declare en el Anexo F como límite estructural de la mesa y no como pendiente.
- **Editor de cierre con presupuesto** (fuera de catálogo; edición bibliográfica puede asumirlo): controla el saldo de palabras del lote (hallazgo 06) antes de la mesa de aprobación.
