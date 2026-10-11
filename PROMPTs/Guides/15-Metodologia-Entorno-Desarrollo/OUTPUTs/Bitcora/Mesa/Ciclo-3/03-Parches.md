# Mesa · Ciclo 3 · 03 — Parches del cuerpo auditor

> Fecha: 2026-10-09. Rol: cuerpo auditor (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §4.4 y §5.4). **No vota sus propios parches**: los somete a la mesa de aprobación (§5.5).
> Artefacto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (1.0.0 / vigente, 3605 líneas, 54 267 palabras con `wc -w`, sha256 `a2b78179…`). «L*n*» = línea de esa versión. Insumos: `01-Consolidado.md`, los cinco `02-Voto-*.md` y los doce `Informe-*.md` de esta carpeta, con sus `evidencia-*/`.
> Alcance: los 35 ítems con veredicto PROCEDE (C3-01 a C3-35) y el lote S4 completo (C3-36 a C3-53), salvo la Práctica de C3-41, que cede ante el saldo de C3-35 (§8).
> Evidencia nueva del auditor: [`evidencia-auditor/`](evidencia-auditor/) (§6). Fuentes nuevas consultadas el **2026-10-09** (B218–B224, §6.2).
> Resultado de la simulación: 23 parches, 0 anclas fallidas; la guía parcheada (`evidencia-auditor/simulacion/guia-parcheada.md`, sha256 `e65a650b…`) pasa los chequeos mecánicos del ciclo 2 (§8).

## 0. Cómo leer este documento

- Cada parche agrupa los hallazgos que tocan **la misma sección** de la guía (marco §5.4). Un hallazgo que toca varias secciones aparece en varios parches; la tabla de cobertura (§7) dice dónde.
- **Texto exacto.** Cada op de §3 cita su ancla literal y el texto nuevo completo, entre `~~~~`. El mismo contenido está en forma ejecutable en [`evidencia-auditor/simulacion/parches.py`](evidencia-auditor/simulacion/parches.py): `GUIA=<ruta> python3 -I gen.py` aplica los 23 parches, en orden, a una **copia** de la guía (no toca el original), falla si un ancla no aparece exactamente las veces declaradas, mide el Δ de palabras y deja el resultado en `guia-parcheada.md`. El texto de §3 lo genera ese mismo script (`parches-md.txt`): lo que se lee acá es lo que se aplica.
- **El orden importa.** P-23 (la glosa «(requiere Windows)») va último porque cuenta apariciones que P-08, P-11, P-13 y P-21 modifican o quitan.
- **Capa de origen.** Si el defecto nació en un núcleo o en la bitácora de un ciclo anterior, §4 lo corrige allí con notas de solo agregado (marco §5.5). Incluye los pendientes O-5 y O-12 que `Ciclo-2/05-Aplicacion.md` §6.3 dejó abiertos.
- **Laboratorio.** §5 lista los cambios de `Examples/`, cada uno con su fuente ya probada en `evidencia-auditor/` y lo que hay que volver a correr.
- **Marcas.** Todo texto nuevo usa el vocabulario cerrado de §0.3 de la guía: `**[criterio]**`, `**[no verificado]**`, `**[observado]**` (con versión), `**[interpretación]**`.
- **Presupuesto.** Cada parche declara su Δ de palabras en dos cubos (§2), medido sobre el archivo, no estimado.

## 1. Decisiones de dirección

### 1.1 Las tres contradicciones

Votos de dirección leídos en el fundamento de cada juez. Ningún juez vetó (riesgo: «No hay veto en este ciclo»).

| Ítem | Coherencia | Costo-beneficio | Impacto | Riesgo | Evidencia | Resultado | Lo que aplica el auditor |
|---|---|---|---|---|---|---|---|
| C3-01 | A (tabla de dos caminos cabe **dentro** de §8.2.2 si los demás remiten) | A | A, con remisiones en §11.3/§11.4, B.3/B.4 y E5-8 | A | A, con el inventario de B como lista de remisiones; lo nativo como **[interpretación]** | **A, 5-0** | Una definición en §8.2.2 p.1 («qué decide cada capa sobre el artefacto») con los dos caminos de CI en el mismo párrafo; en los otros quince sitios, una remisión de pocas palabras («o el runner alojado, §8.2.2»), no una cláusula. Una fila en §11.3 y una cláusula en §11.4 ESC-05, porque §11 es el capítulo central (costo-beneficio). El E1 del abogado entra como **E5-8** (L-02), re-corrido por el auditor con el mismo resultado (X5). Se escribe como acotamiento de C1-21 (b), C1-18 (b) y C2-13 (O-1, O-9). |
| C3-02 | A + (a); (b) opcional rotulada [observado]; (c) no | A + B(a) | A + (a) + (b) | A + B(a) | A + (a) | **A + (a), 5-0** | El runner alcanza para 8a; el registro lleva el digest o `NO DECLARADA` con su motivo, admitido **sólo** con runner; la retención del log (90 días; 1–400 en privados) se declara con fuente nueva [B218]. (b), archivar «Set up job» o `/etc/environment`, **no** se aplica: sólo impacto la pidió y el ciclo 2 (§9) la dejó fuera por no tener fuente de contrato. |
| C3-03 | A | A | A, conservando la imagen para lo nativo, *self-contained*, R2R y AOT | A acotada | A; lo nativo como [interpretación] | **A, 5-0** | «Reconstrucción bit a bit» sale de los motivos de la imagen propia (§8.2.2, §12 p.7); §9.6 dice «mismo SDK (E5-8); para lo nativo, también la misma imagen **[interpretación]**». |

### 1.2 Direcciones dentro de ítems no contradictorios

| Ítem | Opciones en el consolidado | Votos | Lo que aplica el auditor |
|---|---|---|---|
| C3-05 | (a) declarar la retención; (b) archivar el log; (c) reservar 8a | costo, riesgo, evidencia: (a); impacto: (a)+(b); coherencia: (a) y (b) opcional | (a), con [B218], en §8.2.2, §9.6, §12 p.7, A.17 y el Anexo F. |
| C3-06 | tabla + filas; cláusula por sitio; *No aplica*; remisiones | todos: remisiones (por C3-01); impacto: *No aplica* en §8.6/§8.7; coherencia: «en §8.6 y §8.7 basta la remisión» | Remisiones. En §8.6 y §8.7, remisión y no *No aplica* (coherencia y costo: sale más corta). |
| C3-11 | etiqueta fija en A.10 y laboratorio; línea en §10.2.6 | costo: la línea sólo si no la cubre la regla | Las dos: la línea va como una celda de la fila «Imagen base» de §10.2.6, no como párrafo. Digest nuevo resuelto el 2026-10-09 (X5): `sdk:8.0.425-bookworm-slim@sha256:ec9c0a0d…`, que hoy es también el de `sdk:8.0`; el `78235e09…` de A.10 era el de la etiqueta flotante del 2026-09-19. |
| C3-12 | quitar `ImagenDigest`; `SdkVersion` embebido rotulado o fuera | todos: quitar | Se quitan los dos `AssemblyMetadata` (el `ItemGroup` entero) de A.4 y del laboratorio: el SDK ya lo registra A.17, y un dato embebido que cambia con el entorno contradice «al lado, no adentro». Costo: el hash de la DLL de EA-1 cambia (`d6cc63cb…` → `fa6a50ec…`, X1). |
| C3-15 | rótulo; mitigación `paths`; tabla de ocho repos | costo: tabla al Anexo F, no al cuerpo; evidencia: tabla sólo con fecha y comando | Rótulo y una oración de `paths` con **[no verificado]** para Visual Studio. La tabla de ocho repos **no entra**: no se re-corrió y la frase de [B56] («In CI… an acceptable range») sostiene el rótulo sola. |
| C3-16 | fila `.slnx`; razón del `.razor`; costo recurrente | todos | Las tres partes, con E2-6 ampliado (L-03, X2) y la fuente nueva [B222]. |
| C3-18 | (a) rojo con excepciones; (b) límite repetido + X1 en EA-1 | coherencia, costo, riesgo, evidencia: (b); impacto: (a) preferida, (b) mínimo | (b): el límite en §10.4, §11.7 (también como señal pobre) y §11.8; el estado X1 como paso de EA-1 (paso 8, X1). (a) no se adopta (coherencia: reabre `Ciclo-2/03-Parches.md` §9). |
| C3-19 | `.githooks/` como entrada única; o pre-commit en su lugar | coherencia: `.githooks/` | Se declara que se excluyen y que el `postCreateCommand` activa una sola; el comentario del `.pre-commit-config.yaml` dice que reemplaza, no se suma. No se elige por el lector: la plantilla (A.9, A.11) queda en `.githooks/`. |
| C3-20 | compuerta en el commit 1, activada en el paso 4; o compuerta al paso 2 | coherencia, riesgo: la primera | La primera. |
| C3-21 | receta mínima | todos: mínima, [no verificado] | Dos oraciones en A.11 y una remisión en B.1. |
| C3-29 | completar; acotar | coherencia, costo, impacto, riesgo: completar | Completar en una línea, con 8b y 9 «sin experimento» y `# [no verificado]` en el YAML; se suma uv a la 6. |
| C3-34 | línea; columna | costo: línea | Una línea en el Anexo E. Las fechas salen de la fecha de modificación de las 85 salidas (X7) cruzada con las aplicaciones de los ciclos 1 y 2, no de una estimación (condición de riesgo). |
| C3-35 | cinco recortes + Δ medido | costo: 1, 2, 3 y 5 (4 lo cubre C3-01); riesgo: la tesis de Visual Studio se queda donde es advertencia | Los cuatro, y tres más (P-20 a P-22). Resultado y saldo en §2. |

Lote S4 (C3-36 a C3-53): el auditor aplica los 18, con una excepción parcial: de C3-41 entra la fila «§3 | E0-6» de la ruta mínima y **no** la Práctica nueva de §3 (+85 palabras de prosa), que el relator ya marcó en choque con C3-35; la diagnosis por capas ya se practica en §3.7 (pregunta 3) sobre la misma salida.

## 2. Balance de palabras (C2-36, C3-35)

Medido por `simulacion/gen.py` sobre la guía 1.0.0 (54 267 palabras con `wc -w`), aplicando P-01…P-23 en orden. «Prosa» cuenta las palabras fuera de bloques de código, de las filas `[Bnn]` del Anexo D y de las filas del Anexo E; dentro de la prosa, las citas sueltas (`[Bnn]` e IDs de experimento) se presupuestan como evidencia, como pide C2-36 («citas y evidencia se presupuestan aparte»). «Evidencia y plantillas», el resto.

| Parche | Δ prosa | Δ evidencia y plantillas |
|---|---|---|
| P-01 | +28 | +1 |
| P-02 | +2 | +0 |
| P-03 | -124 | -3 |
| P-04 | +36 | +2 |
| P-05 | +92 | +6 |
| P-06 | +36 | +1 |
| P-07 | -16 | +9 |
| P-08 | +146 | +4 |
| P-09 | +80 | +20 |
| P-10 | +132 | +18 |
| P-11 | +121 | +2 |
| P-12 | +66 | +25 |
| P-13 | +89 | +140 |
| P-14 | +29 | +0 |
| P-15 | +12 | +0 |
| P-16 | +0 | +176 |
| P-17 | +3 | +65 |
| P-18 | +48 | +14 |
| P-19 | -14 | +1 |
| P-20 | -74 | +0 |
| P-21 | -125 | +0 |
| P-22 | -58 | +0 |
| P-23 | -16 | +0 |
| **Total** | **+493** (43 604 → 44 097) | **+481** (10 663 → 11 144) |

`wc -w` de la guía: 54 267 → 55 241 (+974).

**El saldo de prosa queda en +493 (+1,1 %) y no cumple el ≤ 0 de C2-36.** Lo declaro como punto para la mesa de aprobación, no lo escondo. Composición:

- **Recortes** (P-03, P-07, P-19 a P-23): −427; P-08 además fusiona dos preguntas de §8.6, ahorro ya descontado de su Δ. Son los cuatro recortes aprobados de C3-35 —§3.5 a un párrafo; las preguntas del contenedor de §3.7, §7.6 y §8.6 (la de §4.6 ya era corta); la tesis de Visual Studio, que queda en §8.2.4 y sale de §8.4 y §12; la glosa «(requiere Windows)», ocho veces— y otros cinco: el mapa repetido en la apertura de §3, la apertura de §11, la lista de pasos de EA-1 en la apertura del Anexo A, el recuadro «Desde Windows» de §5.2.6 y tres preguntas guía de §6.6, §10.6 y §11.6 que repetían su sección.
- **Correcciones con E1 que agregan texto**: +920. Las de mayor peso son la definición de §8.2.2 con los dos caminos y la retención (P-08, +146 neto ya descontado el texto que reemplaza), las quince remisiones de C3-06 (repartidas en P-08 a P-14, de 5 a 15 palabras cada una), la receta de Windows (C3-21), la explicación de pre-commit frente a `core.hooksPath` (C3-19), el límite de «sin lock» en tres lugares (C3-18), la respuesta completa de la Práctica integradora (C3-29) y la tabla de BOM según la CLI (C3-16). Cada una corrige una afirmación refutada o un comando que falla; ninguna es la «cláusula por sitio» que C3-01 descartó.
- Comparado con la alternativa B de C3-01 (≈ +300 de cláusulas, estimación del abogado), la definición única ahorra más de lo que cuesta.

Propuesta para que el saldo llegue a ≤ 0 sin tocar citas ni evidencia: que el **editor de cierre con presupuesto** (C3-Q09) haga, antes de la aplicación, una pasada de compresión de ≈ 500 palabras de prosa propia con la misma vara de P-20 a P-22. Candidatos medidos (no parcheados porque cada uno toca prosa con información y necesita juicio editorial): los párrafos de ≥ 150 palabras de §6.2.2 (L1006, L1008, L1010), §6.2.3 (L1014, L1016), §7.2.1 (L1201) y §10.2.6 «Bots» (L1965), y las «Señales de una versión pobre» que repiten negaciones de su propia lista de criterios. Si la mesa prefiere cerrar con +493, queda escrito como costo aceptado de un ciclo de correcciones con E1.

## 3. Parches sobre la guía

### P-01 · Encabezado, apertura y §0: versión, cifras, fechas de las corridas, marca por defecto y ruta mínima

- **Hallazgos**: C3-34, C3-35, C3-40, C3-41, C3-01.
- **Sección**: front matter L5, L14; L24, L26; §0.2 L65, L72–L82; §0.3 L89, L92, L96.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa +28, evidencia y plantillas +1.
- **Verificación**: `version: 1.1.0` igual a la fila nueva del control de cambios; «224» fuentes = filas `| Bnn |` del Anexo D (`checks.py`); «74 experimentos» = IDs del Anexo E expandidos; `grep -c 'las ampliaciones de la revisión'` → 0; la ruta mínima tiene fila §3.

1. Reemplazar

~~~~text
version: 1.0.0

~~~~

por

~~~~text
version: 1.1.0

~~~~

2. Reemplazar

~~~~text
fuentes_consultadas: "2026-10-07; B194–B217: 2026-10-09"
~~~~

por

~~~~text
fuentes_consultadas: "2026-10-07; B194–B224: 2026-10-09"
~~~~

3. Reemplazar

~~~~text
Todo lo que la guía presenta como salida de un comando se ejecutó el 2026-10-07 (las ampliaciones de la revisión, el 2026-10-09) en el laboratorio
~~~~

por

~~~~text
Todo lo que la guía presenta como salida de un comando se ejecutó el 2026-10-07 (los que lista el Anexo E, el 2026-10-09) en el laboratorio
~~~~

4. Reemplazar

~~~~text
> **Versión 1.0.0.** Fecha: 2026-10-09
~~~~

por

~~~~text
> **Versión 1.1.0.** Fecha: 2026-10-09
~~~~

5. Reemplazar

~~~~text
(217 fuentes, Anexo D), más 73 experimentos ejecutables (Anexo E).
~~~~

por

~~~~text
(224 fuentes, Anexo D), más 74 experimentos ejecutables (Anexo E).
~~~~

6. Reemplazar

~~~~text
En §3, las secciones 3.1, 3.2, 3.4 y 3.7 (las tablas de 3.3, 3.5 y 3.6 son de consulta: se vuelve a ellas al terminar §10).
~~~~

por

~~~~text
En §3, las secciones 3.1, 3.2, 3.4, 3.5 y 3.7 (las tablas de 3.3 y 3.6 son de consulta: se vuelve a ellas al terminar §10).
~~~~

7. Reemplazar

~~~~text
| §4 | E1-01 | El mismo `.cs` en cp1252: literal corrupto, identificador que no compila |
~~~~

por

~~~~text
| §3 | E0-6 | La primera capa que difiere explica el «en mi máquina anda» |
| §4 | E1-01 | El mismo `.cs` en cp1252: literal corrupto, identificador que no compila |
~~~~

8. Reemplazar

~~~~text
| E4-2 | Resultado del experimento E4-2, ejecutado en la fecha de su salida; la carpeta, el comando y la salida están en el [Anexo E](#anexo-e-laboratorio). |
~~~~

por

~~~~text
| E4-2 | Resultado del experimento E4-2, ejecutado en la fecha que indica el [Anexo E](#anexo-e-laboratorio), donde están la carpeta, el comando y la salida. |
~~~~

9. Reemplazar

~~~~text
El motivo o el matiz va fuera del corchete: **[no verificado]** (requiere Windows), **[criterio]** (sobre la base del fabricante).
~~~~

por

~~~~text
El motivo o el matiz va fuera del corchete: **[no verificado]** (requiere una plataforma alojada), **[criterio]** (sobre la base del fabricante). Sin motivo escrito, **[no verificado]** quiere decir «requiere Windows» (§0.4).
~~~~

### P-02 · §2.4: ACT-OPS aplica los pasos 4 a 9 de §12

- **Hallazgos**: C3-46.
- **Sección**: §2.4, segunda tabla, fila ACT-OPS.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa +2, evidencia y plantillas +0.
- **Verificación**: La fila ACT-OPS nombra los pasos en que §12 la pone como responsable (4, 5, 6, 7, 8a, 8b, 9).

1. Reemplazar

~~~~text
| ACT-OPS | §8, §9, §10 | — | compuertas y procedencia |
~~~~

por

~~~~text
| ACT-OPS | §8, §9, §10 | §12, pasos 4–9 | compuertas y procedencia |
~~~~

### P-03 · §3: §3.5 comprimida, fila de capa 6 en el mapa y pregunta del contenedor

- **Hallazgos**: C3-35, C3-30.
- **Sección**: §3.5 L366–L377; §3.6 L410–L417; §3.7 Q4 L430–L431.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa -124, evidencia y plantillas -3.
- **Verificación**: §3.5 sin tabla y con el enlace a §8.2.1 resuelto (ancla `#821-qué-fija-un-contenedor-y-qué-no`); la tabla «por artefacto» de §3.6 tiene fila de capa 6 con A.17 y nombra A.18.

1. Reemplazar

~~~~text
En parte, y sólo en las capas que el contenedor efectivamente aporta. El [§8](#8-contenedores-devcontainers-y-estaciones-windows) da la respuesta completa con experimentos; ésta es su forma:

| Capa | ¿La fija el contenedor? | Matiz |
|---|---|---|
| 1 · Bytes | **No.** | Lo montado llega con los bytes que escribió el host; lo clonado puede cambiar finales de línea según `eol` y `core.autocrlf` [B36]. El `.cs` en cp1252 falla igual adentro (E5-1). |
| 2 · Toolchain | **Sí**, si viene en la imagen **y** la imagen va por digest. | Por etiqueta, el SDK puede cambiar entre descargas; sin `global.json` el repo no se entera (E5-6). |
| 3 · Grafo | **No.** | Sin lock y restauración estricta, dentro del contenedor se resuelven rangos como en cualquier lado. |
| 4 · SO | **Sí, por digest**; por etiqueta, no. | El digest deja de recibir parches solo (E5-2). |
| 5 · Proceso | **En parte.** | Iguala ruta y variables para quien usa el contenedor; la estación Windows con Visual Studio queda afuera. |
| 6 · Metadatos | **No.** | El contenedor no registra nada por sí solo. |
~~~~

por

~~~~text
En parte, y sólo en las capas que aporta: la 4 y, si la trae la imagen, la 2, **sólo por digest**; la 5, para quien usa la misma definición. No fija la 1 (el `.cs` en cp1252 falla igual adentro, E5-1), ni la 3 (sin lock y restauración estricta resuelve rangos como en cualquier lado), ni la 6. La tabla capa por capa, con su evidencia, está en [§8.2.1](#821-qué-fija-un-contenedor-y-qué-no).
~~~~

2. Reemplazar

~~~~text
| `Directory.Build.props`, scripts de build | 5 | §9 | A.4 |
| Workflow de CI, hooks, `CODEOWNERS`, configuración de bots, ADR | gobierno | §10 | A.11–A.14, A.16 |
~~~~

por

~~~~text
| `Directory.Build.props`, scripts de build | 5 | §9 | A.4 |
| Registro del entorno, SBOM, atestación | 6 | §9 | A.17 |
| Workflow de CI, hooks, `CODEOWNERS`, configuración de bots, ADR, `.gitignore` | gobierno | §10 | A.11–A.14, A.16, A.18 |
~~~~

3. Reemplazar

~~~~text
No. Una imagen por digest fija SO y, si lo trae, el toolchain; pero quien trabaja en Visual Studio sobre Windows no usa esa imagen, y el grafo se resuelve igual que afuera. La fuente de verdad tiene que estar en archivos que lean todas las herramientas, con o sin contenedor (§3.5).
~~~~

por

~~~~text
No: la fuente de verdad tiene que estar en archivos que lean todas las herramientas, con o sin contenedor; la estación Windows no usa la imagen y el grafo se resuelve igual adentro (§3.5).
~~~~

### P-04 · §4: apertura acotada, Python ≥ 3.15 con cp1252, el BOM en un script según el resto del archivo

- **Hallazgos**: C3-53, C3-33, C3-31, C3-37.
- **Sección**: §4 L443; §4.2.4 tabla L512; §4.2.4 L517.
- **Capa de origen**: guía + N1 (laboratorio, L-04). **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa +36, evidencia y plantillas +2.
- **Verificación**: La celda de L512 dice `UnicodeDecodeError` para ≥ 3.15 y cita [B220]; L517 remite a E1-11 para el `child_process` y la salida `e1-shebang-node.txt` existe con `"status":0` para `con-bom.sh` y `ENOENT` para `crlf.sh`; E8-1 columna B da `FALLA rc=2` para `saluda.py`.

1. Reemplazar

~~~~text
Node.js decodifica siempre como UTF-8 y reemplaza lo que no entiende; Python exige UTF-8 o una declaración explícita y, si no la encuentra, se niega a compilar.
~~~~

por

~~~~text
Node.js lee sus módulos como UTF-8: reemplaza lo que no entiende en literales y falla en un identificador; Python exige UTF-8 o una declaración explícita en el fuente y, ante un byte inválido, se niega a compilar.
~~~~

2. Reemplazar

~~~~text
| ≤ 3.14: según *locale*; ≥ 3.15: se lee como UTF-8 [B29] |
~~~~

por

~~~~text
| ≤ 3.14: según *locale*; ≥ 3.15: **`UnicodeDecodeError`**, salvo bytes que formen UTF-8 válido (modo UTF-8 estricto) [B29][B220] |
~~~~

3. Reemplazar

~~~~text
Si lo lanzó un shell (bash, dash) o una función de la familia `execvp` (como el `child_process` de Node), se reintenta con `/bin/sh`: la primera línea falla, el resto corre **con ese shell** aunque el shebang pidiera otro intérprete, y sale con 0.
~~~~

por

~~~~text
Si lo lanzó un shell (bash, dash) o una función de la familia `execvp` (como el `child_process` de Node), se reintenta con `/bin/sh`: la primera línea falla y el resto corre **con ese shell** aunque el shebang pidiera otro intérprete; si es shell válido sale con 0 (E1-11), y si no, falla más abajo, lejos de la causa (E8-1: un `.py` con BOM da rc=2).
~~~~

### P-05 · §5: razones de la tabla de BOM según la CLI, costo de la variante A, compuerta en el commit 1 y guardián del paso 5

- **Hallazgos**: C3-16, C3-20, C3-25, C3-48.
- **Sección**: §5.2.3 L714–L723; §5.2.6 paso 2 y paso 5; §5.6 L898, L902.
- **Capa de origen**: guía + N2 (laboratorio, L-05; capa de origen, O-3). **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa +92, evidencia y plantillas +6.
- **Verificación**: La tabla tiene fila `*.slnx` sin BOM y ninguna fila dice que la CLI «repone» el BOM de `.razor`; E2-6 ampliado (evidencia-auditor/x2) da `s.slnx con BOM → sin BOM` (SDK 10.0.400), `Items/Clase.cs con BOM`, `Items/Comp.razor sin BOM` después de `dotnet format whitespace`; el guardián nuevo, pegado en `bash -i` con un árbol sucio, avisa y la terminal sigue abierta (evidencia-auditor/x4).

1. Reemplazar

~~~~text
| `*.cs` | UTF-8; **con o sin** BOM, una sola de las dos, **declarada** | convención del equipo | El compilador no necesita BOM, pero con BOM el archivo queda a salvo de `CodePage` y de la página ANSI de cada máquina (§4.2.3); `dotnet format` hace cumplir cualquiera de las dos; `dotnet new console` crea `Program.cs` **con** BOM (SDK 8 y 10) y las plantillas web, `.cs` sin BOM;
~~~~

por

~~~~text
| `*.cs` | UTF-8; **con o sin** BOM, una sola de las dos, **declarada** | convención del equipo | El compilador no necesita BOM, pero con BOM el archivo queda a salvo de `CodePage` y de la página ANSI de cada máquina (§4.2.3); `dotnet format` hace cumplir cualquiera de las dos; `dotnet new console` y las plantillas de ítem (`class`, `interface`) crean **con** BOM (SDK 8 y 10) y las plantillas web, `.cs` sin BOM;
~~~~

2. Reemplazar

~~~~text
| `*.razor`, `*.cshtml` | UTF-8 **con** BOM | convención: las plantillas | Las plantillas web del SDK 8 y 10 los crean así (10 de 10 y 12 de 12 `.razor`); pedir lo contrario obliga a corregir cada archivo nuevo | E2-6 |
~~~~

por

~~~~text
| `*.razor`, `*.cshtml` | UTF-8 **con** BOM | convención: las plantillas y el fabricante | Las plantillas del SDK 8 y 10 los crean así (10 de 10 y 12 de 12 `.razor`, y `razorcomponent`), ningún comando lo repone, y es la convención de `dotnet/aspnetcore` y `dotnet/aspire` [B222] | E2-6 |
~~~~

3. Reemplazar

~~~~text
| `*.csproj`, `*.props`, `*.targets`, `*.slnx` | UTF-8; **con o sin** BOM, la misma convención que `*.cs` | convención del equipo | `dotnet new console` crea el `.csproj` **con** BOM y las plantillas web, sin; la CLI no les agrega BOM al editarlos; los repositorios del fabricante difieren (`dotnet/sdk` con BOM, `dotnet/msbuild` y `dotnet/runtime` sin); desde .NET 10, `dotnet new sln` crea `.slnx` [B55] | E2-6, E2-8 |
~~~~

por

~~~~text
| `*.slnx` | UTF-8 **sin** BOM | un lector: la CLI | `dotnet sln add` le quita el BOM (SDK 10.0.400); desde .NET 10, `dotnet new sln` crea `.slnx` [B55] | E2-6 |
| `*.csproj`, `*.props`, `*.targets` | UTF-8; **con o sin** BOM, la misma convención que `*.cs` | convención del equipo | `dotnet new console` crea el `.csproj` **con** BOM y las plantillas web, sin; la CLI conserva el que tienen al editarlos; los repositorios del fabricante difieren (`dotnet/sdk` con BOM, `dotnet/msbuild` y `dotnet/runtime` sin) | E2-6, E2-8 |
~~~~

4. Reemplazar

~~~~text
El costo: el `Program.cs` y el `.csproj` que crea `dotnet new console` llegan con BOM y hay que normalizarlos **antes del primer commit**; la compuerta los señala (EA-1).
~~~~

por

~~~~text
El costo es **recurrente**: todo archivo que crea una plantilla del SDK, de proyecto o de ítem, llega con BOM y se normaliza antes de su commit; la compuerta lo señala (E2-6, EA-1). Las de Visual Studio, **[no verificado]**.
~~~~

5. Reemplazar

~~~~text
`*.razor`, `*.cshtml` y `*.sln` van con BOM en las dos variantes, porque las herramientas del SDK lo reponen.
~~~~

por

~~~~text
`*.razor`, `*.cshtml` y `*.sln` van con BOM en las dos variantes: los dos primeros, por la convención de las plantillas y del fabricante [B222]; `.sln`, porque `dotnet sln add` lo repone (E2-6).
~~~~

6. Reemplazar

~~~~text
2. **Commit de política.** Apenas se commitea,
~~~~

por

~~~~text
2. **Commit de política.** Trae la compuerta; su workflow (A.12) y el hook se activan después de migrar (§12, paso 4). Apenas se commitea,
~~~~

7. Reemplazar

~~~~text
   git diff --quiet && git diff --cached --quiet \
     || { echo "commiteá o guardá con git stash antes de seguir" >&2; exit 1; }
   git pull --ff-only                               # trae los commits de política y migración
   git rm -rq --cached . && git reset -q --hard     # rematerializa el disco con la política
~~~~

por

~~~~text
   if git diff --quiet && git diff --cached --quiet; then   # sin exit: se pega en la terminal
     git pull --ff-only &&                          # trae los commits de política y migración
     git rm -rq --cached . && git reset -q --hard   # rematerializa el disco con la política
   else
     echo "commiteá o guardá con git stash antes de seguir" >&2
   fi
~~~~

8. Reemplazar

~~~~text
Para Razor, con BOM: es lo que producen las plantillas y lo que declara `dotnet/aspnetcore`.
~~~~

por

~~~~text
Para Razor, con BOM: es lo que producen las plantillas y lo que declaran `dotnet/aspnetcore` y `dotnet/aspire` [B222].
~~~~

9. Reemplazar

~~~~text
`.sln` con BOM porque la CLI lo repone; `.csproj`, `.props` y `.slnx`, con la misma convención que `.cs`.
~~~~

por

~~~~text
`.sln` con BOM porque la CLI lo repone y `.slnx` sin BOM porque la CLI lo quita; `.csproj`, `.props` y `.targets`, con la misma convención que `.cs`.
~~~~

### P-06 · §6: `CheckSdkVulnerabilities` desde el SDK 11, rótulo del pin exacto, mitigación `paths` y quién aplica `requires-python`

- **Hallazgos**: C3-13, C3-15, C3-49.
- **Sección**: §6.3 L1039; §6.4 L1050, L1060; §6.6 L1126.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa +36, evidencia y plantillas +1.
- **Verificación**: `grep -n CheckSdkVulnerabilities` → todas las apariciones dicen «desde el SDK 11»; la celda .NET de §6.3 separa lo del fabricante ([B56]: rango en CI, `disable` con lock) del **[criterio]** de la guía; `paths` lleva **[no verificado]** para Visual Studio; `grep -c 'npm y pip'` → 0.

1. Reemplazar

~~~~text
| .NET | `global.json` con versión exacta y `rollForward: disable` cuando hay lock files [B56]; no usar `LangVersion=latest` [B57]; `dotnet sdk check`, Dependabot para subir el SDK fijado y `CheckSdkVulnerabilities=true` para que la build avise si el SDK resuelto es vulnerable o está fuera de soporte [B58]; compilar con `dotnet build` antes que con `msbuild` [B59]. | fabricante |
~~~~

por

~~~~text
| .NET | `rollForward: disable` cuando hay lock files; en CI sin lock, un rango [B56] (el lock por defecto es **[criterio]**, §7.2.1); no usar `LangVersion=latest` [B57]; `dotnet sdk check`, Dependabot y, desde el SDK 11, `CheckSdkVulnerabilities` para que la build avise (en 8.0.425 y 10.0.400 no hace nada **[observado]**) [B58]; compilar con `dotnet build` antes que con `msbuild` [B59]. | fabricante |
~~~~

2. Reemplazar

~~~~text
| ESC-01 Windows + Visual Studio | `global.json`, TFM, `LangVersion`; npm y pip hacen cumplir `devEngines`, `engine-strict` y `requires-python` |
~~~~

por

~~~~text
| ESC-01 Windows + Visual Studio | `global.json`, TFM, `LangVersion`; npm hace cumplir `devEngines` y `engine-strict`, y uv `requires-python` (pip, sólo al instalar el paquete) |
~~~~

3. Reemplazar

~~~~text
subir el SDK es un PR que mueve `global.json`, las imágenes y los locks (§10.2.6) |
~~~~

por

~~~~text
subir el SDK es un PR que mueve `global.json`, las imágenes y los locks (§10.2.6). Con SDK 10, `paths: [".dotnet", "$host$"]` y `errorMessage` admiten un SDK local instalado por script [B56] (en Visual Studio, **[no verificado]**) |
~~~~

4. Reemplazar

~~~~text
`engines`, `devEngines` y `requires-python` se cumplen igual porque los aplican npm y pip.
~~~~

por

~~~~text
`engines`, `devEngines` y `requires-python` se cumplen igual porque los aplican npm y uv (pip, sólo al instalar el paquete).
~~~~

### P-07 · §7: destino explícito de `dotnet restore` y pregunta del contenedor

- **Hallazgos**: C3-24, C3-35.
- **Sección**: §7.5 segundo bloque `bash`; §7.6 «¿Un contenedor reemplaza al lock?».
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa -16, evidencia y plantillas +9.
- **Verificación**: En una copia de `Examples/A-plantillas/repo`, `dotnet restore src/App --locked-mode` da rc=0 (desarrollador-04); el bloque ya no corre `dotnet restore` en la raíz.

1. Reemplazar

~~~~text
dotnet restore --locked-mode          # NU1004 / NU1403 si el lock no coincide
~~~~

por

~~~~text
dotnet restore src/App --locked-mode  # NU1004 / NU1403; sin .sln en la raíz, el proyecto (la compuerta de A.11 los busca)
~~~~

2. Reemplazar

~~~~text
No. La imagen fija SO y toolchain; si dentro se usa `npm install` o `dotnet restore` sin modo estricto, el grafo se resuelve de nuevo en cada build. Todos los experimentos de este capítulo corrieron en contenedores y mostraron deriva igual.
~~~~

por

~~~~text
No: sin modo estricto, el grafo se resuelve de nuevo en cada build también adentro (§3.5); todos los experimentos de este capítulo corrieron en contenedores.
~~~~

### P-08 · §8: qué decide cada capa sobre el artefacto (una definición, dos caminos de CI) y remisiones; digest de índice; «detecta», no «garantiza»

- **Hallazgos**: C3-01, C3-02, C3-03, C3-05, C3-06, C3-07, C3-10, C3-23, C3-35.
- **Sección**: §8.1 L1361; §8.2.2 L1408, L1414, L1418; §8.2.4 L1449; §8.2.6 L1481; §8.4 L1499, L1501, L1503; §8.5 L1531; §8.6 L1539, L1544–L1548; §8.7 L1563.
- **Capa de origen**: guía + N5 (laboratorio, L-06: E5-8; capa de origen, O-1). **Costo**: medio. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa +146, evidencia y plantillas +4.
- **Verificación**: E5-8 (evidencia-auditor/x5) da `dll 9815b804e89acc33 pdb 39c56299b47eef9f` en las tres bases con SDK 8.0.425 y `7cd2a836…` con 10.0.400; `grep -n 'reconstrucción bit a bit'` → 0 en §8 y §12; en §8.2.2, «8a» y «8b» aparecen sólo como «§12, paso 8a/8b» junto a lo que nombran; [B218] definida y citada; el inventario de C3-06 (§8.2.2 p.5, §8.4, §8.6, §8.7, §9.6, §9.7, §10.6, §10.7, §11.2.6, §11.2.7, §11.3, §11.4, §12, B.3, B.4, §10.2.5) remite a §8.2.2.

1. Reemplazar

~~~~text
| **Digest** | Hash `sha256:` del manifiesto de la imagen: el mismo digest es siempre la misma imagen. Al usarlo,
~~~~

por

~~~~text
| **Digest** | Hash `sha256:` del manifiesto de la imagen: el mismo digest es siempre el mismo manifiesto. Si es un índice multiplataforma, como los de las imágenes oficiales, cada arquitectura resuelve su propia imagen **[observado]** (`docker buildx imagetools inspect`, 2026-10-09). Al usarlo,
~~~~

2. Reemplazar

~~~~text
Docker documenta que las etiquetas son mutables y que fijar por digest garantiza la misma imagen, al costo
~~~~

por

~~~~text
Docker documenta que las etiquetas son mutables y que fijar por digest garantiza la misma imagen —para la misma plataforma; igualar estaciones de otra arquitectura pide `--platform` o el digest por plataforma **[criterio]**—, al costo
~~~~

3. Reemplazar

~~~~text
1. **Digest en todo lo que construye artefactos publicados**: el `FROM` de la imagen de CI y de los Dockerfile de build, y `container.image` de la CI. Se escribe `repo:etiqueta@sha256:…`: la etiqueta queda como referencia humana y manda el digest. Para 8a también vale el runner alojado con acciones de *setup* por SHA que leen `global.json`, `.nvmrc` y `.python-version` [B181]: la imagen del runner (capa 4) flota y queda en el log «Set up job» [B216]. La imagen propia hace falta para 8b, la reconstrucción bit a bit o la frontera A en la CI (§11.2.5).
~~~~

por

~~~~text
1. **Digest en toda imagen que el repo nombra para construir lo publicado**: el `FROM` de la imagen de CI y de los Dockerfile de build, y `container.image` de la CI. Se escribe `repo:etiqueta@sha256:…`: la etiqueta queda como referencia humana y manda el digest.

   **Qué decide cada capa sobre el artefacto.** Los bytes de un artefacto .NET gestionado los decide la capa 2 exacta: el mismo SDK con `ContinuousIntegrationBuild` dio la misma DLL y el mismo PDB en tres sistemas operativos y tres rutas; otro SDK, otra (E5-8). La capa 4 decide la ejecución (E5-2), lo nativo **[interpretación]** y lo que se publica como imagen. Por eso hay dos caminos de CI **[criterio]**: **imagen propia por digest** si la CI comparte base con el devcontainer (§8.2.6), publica algo nativo o una imagen, o un tercero verifica su procedencia (§12, paso 8b); o **runner alojado** con acciones de *setup* por SHA que leen `global.json`, `.nvmrc` y `.python-version` [B181], que alcanza para registrar con qué se construyó (§12, paso 8a): su imagen flota y su versión queda sólo en el log «Set up job» [B216] mientras dure la retención, 90 días por defecto y hasta 400 en repositorios privados [B218]. Las demás reglas de imagen remiten acá.
~~~~

4. Reemplazar

~~~~text
5. **Etiqueta flotante sólo donde se quiere deriva**: nunca en la CI que publica artefactos.
~~~~

por

~~~~text
5. **Etiqueta flotante sólo donde se quiere deriva**: nunca en una imagen que el repo nombra para construir lo publicado (la del runner alojado no la nombra el repo: punto 1).
~~~~

5. Reemplazar

~~~~text
2. **El devcontainer es una comodidad que reproduce la CI, no un requisito.** Quien no puede o no quiere usarlo trabaja nativo; la compuerta de CI garantiza que su commit cumple.
~~~~

por

~~~~text
2. **El devcontainer es una comodidad que reproduce la CI, no un requisito.** Quien no puede o no quiere usarlo trabaja nativo; la compuerta de CI **detecta** si su commit no cumple, y lo **impide** sólo con protección de rama o con la compuerta en la publicación (§10.2.7).
~~~~

6. Reemplazar

~~~~text
la CI dentro del devcontainer preconstruido (stacks simples) o la imagen de desarrollo `FROM` el mismo `sdk@sha256` de la CI, con herramientas agregadas (multi-runtime, §11); no imágenes elegidas por un nombre parecido.
~~~~

por

~~~~text
la CI dentro del devcontainer preconstruido (stacks simples) o la imagen de desarrollo `FROM` el mismo `sdk@sha256` de la CI, con herramientas agregadas (multi-runtime, §11); no imágenes elegidas por un nombre parecido. Con el runner alojado (§8.2.2) no hay base compartida: sólo la compuerta prueba que las versiones coinciden.
~~~~

7. Reemplazar

~~~~text
| ESC-01 Windows + Visual Studio | Contenerizar y depurar la app (Container Tools) | Desarrollo .NET dentro de un devcontainer **[no verificado]** (hallazgo negativo, a revalidar) |
~~~~

por

~~~~text
| ESC-01 Windows + Visual Studio | Contenerizar y depurar la app (Container Tools) | Desarrollo .NET dentro de un devcontainer (§8.2.4) |
~~~~

8. Reemplazar

~~~~text
| ESC-05 CI | La imagen por digest que construye lo que se publica | Reemplazar a `global.json` o a los locks |
~~~~

por

~~~~text
| ESC-05 CI | La imagen por digest que construye lo que se publica, o el runner alojado (§8.2.2) | Reemplazar a `global.json` o a los locks |
~~~~

9. Reemplazar

~~~~text
Por contexto: en CTX-NET el devcontainer no reemplaza a Visual Studio para quien trabaja en ESC-01 (§8.2.4); en CTX-NODE
~~~~

por

~~~~text
Por contexto: en CTX-NET, la convivencia de §8.2.4; en CTX-NODE
~~~~

10. Reemplazar

~~~~text
Experimentos del capítulo: E5-1 a E5-7 y E5-5b (Anexo E).
~~~~

por

~~~~text
Experimentos del capítulo: E5-1 a E5-8 y E5-5b (Anexo E).
~~~~

11. Reemplazar

~~~~text
Digest en todo lo que construye artefactos publicados, con un bot que proponga el digest nuevo; en el devcontainer,
~~~~

por

~~~~text
Digest en toda imagen que el repo nombra para construir lo publicado, con un bot que proponga el digest nuevo, o el runner alojado (§8.2.2); en el devcontainer,
~~~~

12. Reemplazar

~~~~text
Etiqueta flotante sólo donde se acepta deriva. El costo medido: con el digest de septiembre, la imagen siguió con OpenSSL 3.0.20 cuando la etiqueta ya traía 3.0.22. El digest convierte los parches en trabajo explícito. *Aplica* a toda referencia
~~~~

por

~~~~text
Etiqueta flotante sólo donde se acepta deriva. El digest convierte los parches en trabajo explícito (E5-2). *Aplica* a toda referencia
~~~~

13. Reemplazar

~~~~text
**¿Cómo conviven Visual Studio sin contenedores y el devcontainer?**
Con la política en el repo, el devcontainer como comodidad que la reproduce y la CI como árbitro. La señal de alarma es una regla que sólo se cumple «si usás el devcontainer». *Aplica* a CTX-NET y CTX-POLI con estaciones Windows.

**¿Qué tiene que ser idéntico entre la estación Windows y el devcontainer?**
Lo que el repo declara: bytes normalizados, SDK admitido por `global.json`, locks, comando de build. El SO, las rutas y el hash del binario no lo serán; la igualdad bit a bit es asunto de la CI (§9). *Aplica* al escribir las reglas de convivencia del equipo (§8.2.4).
~~~~

por

~~~~text
**¿Cómo conviven Visual Studio sin contenedores y el devcontainer, y qué tiene que ser idéntico?**
Con las reglas de §8.2.4: idéntico es lo que el repo declara (bytes, SDK admitido por `global.json`, locks, comando de build), no el SO, las rutas ni el hash del binario. La señal de alarma es una regla que sólo se cumple «si usás el devcontainer». *Aplica* a CTX-NET y CTX-POLI con estaciones Windows.
~~~~

14. Reemplazar

~~~~text
- nombra por digest toda imagen que construye artefactos publicados, con un mecanismo
~~~~

por

~~~~text
- nombra por digest toda imagen que el repo usa para construir lo publicado (o corre en el runner alojado, §8.2.2), con un mecanismo
~~~~

### P-09 · §9: el digest va al lado del artefacto, qué queda del metadato (4) con el runner, reconstrucción con el mismo SDK, verificación de `gh` con firmante y rama

- **Hallazgos**: C3-12, C3-03, C3-06, C3-05, C3-27, C3-51, C3-30.
- **Sección**: §9.2.1 L1641; §9.3 L1725; §9.4 L1737; §9.5 L1772; §9.6 L1790, L1796; §9.7 L1815; §9.8 L1832.
- **Capa de origen**: guía + N6 (capa de origen, O-4). **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa +80, evidencia y plantillas +20.
- **Verificación**: `grep -c ImagenDigest` → 0 en la guía; la línea de consumidor lleva `--signer-workflow` y `--source-ref` y sigue rotulada **Ilustrativo**; [B221] definida y citada; §9.8 enlaza A.17.

1. Reemplazar

~~~~text
El SDK **no** registra con qué SDK, imagen ni máquina se compiló; agregarlo como `AssemblyMetadata` (`$(NETCoreSdkVersion)` y un digest que pase la CI) sirve para diagnóstico, no como prueba.
~~~~

por

~~~~text
El SDK **no** registra con qué SDK, imagen ni máquina se compiló, y eso va **al lado** del artefacto (registro del entorno, A.17), no adentro: un `AssemblyMetadata` con el digest de la imagen cambia el hash de la DLL según dónde se construya, y la reconstrucción en el devcontainer deja de coincidir **[observado]** (SDK 8.0.425).
~~~~

2. Reemplazar

~~~~text
| GitHub Actions | `actions/attest@v4`, permisos `id-token: write` y `attestations: write`; `gh attestation verify` [B158] | L2 por sí sola; L3 con *reusable workflows* [B158] |
~~~~

por

~~~~text
| GitHub Actions | `actions/attest@v4`, permisos `id-token: write` y `attestations: write`; `gh attestation verify` [B158], con el workflow firmante fijado por el consumidor (`--signer-workflow`; con *reusable workflows*, obligatorio [B221]) | L2 por sí sola; L3 con *reusable workflows* [B158] |
~~~~

3. Reemplazar

~~~~text
| ESC-04 Devcontainer | Con la receta de la imagen de CI, el lugar natural para reconstruir | No genera procedencia válida: no es una plataforma alojada |
~~~~

por

~~~~text
| ESC-04 Devcontainer | Con la receta de la imagen de CI, el lugar natural para reconstruir | No es donde se genera la procedencia que se entrega (§9.2.4) |
~~~~

4. Reemplazar

~~~~text
# Consumidor:  gh attestation verify Pieza.1.4.0.nupkg -R <org>/<repo>
~~~~

por

~~~~text
# Consumidor (sólo con -R acepta cualquier workflow y rama del repo [B221]):
#   gh attestation verify Pieza.1.4.0.nupkg -R <org>/<repo> \
#     --signer-workflow <org>/<repo>/.github/workflows/<publicar>.yml --source-ref refs/heads/main
~~~~

5. Reemplazar

~~~~text
(4) el digest de la imagen de build;
~~~~

por

~~~~text
(4) la imagen de build: su digest o, con runner alojado, su versión, que vive sólo en el log mientras dure la retención (§8.2.2);
~~~~

6. Reemplazar

~~~~text
Clonar dos veces en rutas distintas, construir con el mismo toolchain e imagen y comparar sha256 (E6-2).
~~~~

por

~~~~text
Clonar dos veces en rutas distintas, construir con el mismo toolchain y comparar sha256 (E6-2): en un artefacto .NET gestionado alcanza el mismo SDK (E5-8); para lo nativo, también la misma imagen **[interpretación]**.
~~~~

7. Reemplazar

~~~~text
*Aplica* en Linux, WSL, devcontainer o CI (ESC-02 a ESC-05) con la misma imagen que la CI;
~~~~

por

~~~~text
*Aplica* en Linux, WSL, devcontainer o CI (ESC-02 a ESC-05) con el mismo SDK que la CI;
~~~~

8. Reemplazar

~~~~text
- lleva o tiene al lado: digest, commit, toolchain, digest de imagen, SBOM con alcance declarado y procedencia;
~~~~

por

~~~~text
- lleva o tiene al lado: digest, commit, toolchain, imagen (digest, o versión del runner, §8.2.2), SBOM con alcance declarado y procedencia;
~~~~

9. Reemplazar

~~~~text
[A.4 `Directory.Build.props`](#a4-directorybuildprops) (trazabilidad .NET), [A.12 workflow de CI](#a12-workflow-de-ci) (`SOURCE_DATE_EPOCH`).
~~~~

por

~~~~text
[A.17 Registro del entorno](#a17-registro-del-entorno), [A.4 `Directory.Build.props`](#a4-directorybuildprops) (trazabilidad .NET), [A.12 workflow de CI](#a12-workflow-de-ci) (`SOURCE_DATE_EPOCH`).
~~~~

### P-10 · §10: etiqueta fija de SDK, `dotnet sdk check`, límite de «sin lock», pre-commit o `.githooks/`, dueños de lo que desarma la compuerta y la vuelta al mapa

- **Hallazgos**: C3-11, C3-13, C3-15, C3-18, C3-19, C3-26, C3-06, C3-40.
- **Sección**: §10.2.5 L1934; §10.2.6 L1948, L1959; §10.2.7 L1978; §10.3 L1997; §10.4 L2012; §10.5 bloque `.pre-commit-config.yaml`; §10.6 L2067, L2079; §10.7 L2089; §10.9 L2109.
- **Capa de origen**: guía + N7 (capa de origen, O-2). **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa +132, evidencia y plantillas +18.
- **Verificación**: EA-1 propuesto (evidencia-auditor/x1) paso 8: «sin su lock» → `[n/a]` npm y uv, VERDE, rc=0, como dice §10.4; pre-commit 4.6.2 con `core.hooksPath` → `Cowardly refusing…` (voto de evidencia); `owners.py` sobre el CODEOWNERS nuevo (evidencia-auditor/x6) da `@org/arquitectura` o `@org/plataforma` para los once archivos de AH-002-01; la consigna de §10.9 tiene criterio de corrección.

1. Reemplazar

~~~~text
| `Dockerfile`, `devcontainer.json` y su lock | ¿Lo que construye artefactos publicados sigue por digest? ¿El devcontainer
~~~~

por

~~~~text
| `Dockerfile`, `devcontainer.json` y su lock | ¿Lo que construye artefactos publicados sigue por digest, o en el runner alojado (§8.2.2)? ¿El devcontainer
~~~~

2. Reemplazar

~~~~text
| Imagen base | digest en `Dockerfile`/`devcontainer.json` | PR del bot, o ADR si cambia la distribución |
~~~~

por

~~~~text
| Imagen base | digest en `Dockerfile`/`devcontainer.json`, sobre una etiqueta **fija** de SDK: con una flotante, el PR del digest puede traer otro SDK (E3-7) | PR del bot, o ADR si cambia la distribución |
~~~~

3. Reemplazar

~~~~text
Microsoft sugiere Dependabot para el SDK de `global.json` y `CheckSdkVulnerabilities` para que la build avise [B58].
~~~~

por

~~~~text
Microsoft sugiere Dependabot para el SDK de `global.json` y `CheckSdkVulnerabilities` para que la build avise [B58], pero la propiedad existe desde el SDK 11 (§6.3): con SDK 8 o 10 avisa `dotnet sdk check` en un job programado (8.0.425: `going out of support soon` **[observado]**).
~~~~

4. Reemplazar

~~~~text
revisión de dueños es obligatoria sobre los archivos de la compuerta (`/.github/`, `/tools/ci/`, A.14),
~~~~

por

~~~~text
revisión de dueños es obligatoria sobre los archivos que pueden desarmarla (los de A.14: compuerta, workflows, registros y propiedades de restauración),
~~~~

5. Reemplazar

~~~~text
| .NET | `--locked-mode` en CI y `rollForward: disable` con lock files [B83]; `dotnet sdk check`, Dependabot y `CheckSdkVulnerabilities` [B58]; `setup-dotnet` con `global-json-file` [B181] | Dependabot `nuget` + `dotnet-sdk`; ADR para subir de banda | Compuerta que compara `dotnet --version` con `global.json` |
~~~~

por

~~~~text
| .NET | `--locked-mode` en CI [B83]; `rollForward: disable` sólo con lock files [B56]; `dotnet sdk check`, Dependabot y, desde el SDK 11, `CheckSdkVulnerabilities` [B58]; `setup-dotnet` con `global-json-file` [B181] | Dependabot `nuget` + `dotnet-sdk`; ADR para subir de banda | Lock por defecto (§7.2.1); compuerta que compara `dotnet --version` con `global.json` |
~~~~

6. Reemplazar

~~~~text
Por contexto, la misma compuerta corre los pasos cuyos archivos existen y deja `n/a` los demás (E7-1, E7-7); en CTX-POLI (los tres ecosistemas en un repo) corre sus tres pasos para los tres a la vez, sobre los proyectos que encuentra (§10.2.2);
~~~~

por

~~~~text
Por contexto, la misma compuerta corre los pasos cuyos archivos existen y deja `n/a` los demás (E7-1, E7-7); en CTX-POLI (los tres ecosistemas en un repo) corre sus tres pasos para los tres a la vez, sobre los proyectos que encuentra (§10.2.2), y un manifiesto sin lock queda en `n/a`: lo ve la revisión (EA-1, paso 8);
~~~~

7. Reemplazar

~~~~text
# .pre-commit-config.yaml — framework como orquestador, alineado con .editorconfig.
~~~~

por

~~~~text
# .pre-commit-config.yaml — framework como orquestador, alineado con .editorconfig.
# Reemplaza a .githooks/ (A.11), no se suma: con core.hooksPath, pre-commit install se niega (10.6).
~~~~

8. Reemplazar

~~~~text
Si se adopta, la política la sigue haciendo cumplir un chequeo que lee `.editorconfig`: el del laboratorio o editorconfig-checker (§5.2.5).
~~~~

por

~~~~text
Si se adopta, la política la sigue haciendo cumplir un chequeo que lee `.editorconfig`: el del laboratorio o editorconfig-checker (§5.2.5). Las dos entradas se excluyen: con `core.hooksPath` (A.9, A.11), `pre-commit install` se niega (4.6.2 **[observado]**); **[criterio]** el `postCreateCommand` activa una sola.
~~~~

9. Reemplazar

~~~~text
Sí: acciones por SHA, `rev` de pre-commit por SHA, imagen de CI por digest,
~~~~

por

~~~~text
Sí: acciones por SHA, `rev` de pre-commit por SHA, imagen de CI por digest (o runner alojado, §8.2.2),
~~~~

10. Reemplazar

~~~~text
- fija por SHA o digest todo lo que ejecuta la compuerta;
~~~~

por

~~~~text
- fija por SHA o digest todo lo que ejecuta la compuerta, salvo la imagen del runner alojado, que se registra (§8.2.2);
~~~~

11. Reemplazar

~~~~text
**Volver al mapa.** Releé §3.3 desde «Qué deja libre», y §3.5: para cada fila, nombrá el experimento que lo mostró; si no podés, volvé a su capítulo.
~~~~

por

~~~~text
**Volver al mapa.** Tapá las columnas «Qué deja libre» y «Evidencia» de §3.3, escribilas para cada mecanismo y compará; si no podés, volvé a su capítulo. *Criterio de corrección*: coincide con la tabla, y tres filas se reconocen respaldadas sólo por una fuente.
~~~~

### P-11 · §11: la compuerta por su nombre, imagen única por cantidad de artefactos, runner alojado en el modelo, límite de «sin lock», Python 3.15 en pasado y párrafos de una regla

- **Hallazgos**: C3-06, C3-16, C3-18, C3-22, C3-28, C3-42, C3-48, C3-52.
- **Sección**: §11.2.2 L2172, L2174; §11.2.5 L2207; §11.2.6 L2239, L2244; §11.2.7 L2248; §11.2.8 L2258; §11.2.9 L2271; §11.3 L2319–L2320; §11.4 L2327, L2331; §11.6 L2409, L2412; §11.7 L2438, señales; §11.8 L2456.
- **Capa de origen**: guía + N8 (capa de origen, O-5). **Costo**: medio. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa +121, evidencia y plantillas +2.
- **Verificación**: `grep -n 'verificar.sh'` → sólo §0.4, §10.2.2, §11.2.3, §11.5, Anexo A y Anexo E (N8 y EA-1), no en §11.2.9 ni §11.4; el encadenamiento §11.2.5 → §11.2.6 da «CI de un artefacto → imagen única»; los tres párrafos de L2207, L2248 y L2258 quedan por debajo de 150 palabras (script de didáctica); diagrama mermaid válido.

1. Reemplazar

~~~~text
`.razor`/`.cshtml`/`.sln` con BOM (las herramientas del SDK lo reponen);
~~~~

por

~~~~text
`.razor`/`.cshtml` con BOM (las plantillas y el fabricante) y `.sln` con BOM (la CLI lo repone);
~~~~

2. Reemplazar

~~~~text
porque hasta que el modo UTF-8 sea el predeterminado (Python 3.15) `open()` sin codificación usa `locale.getencoding()`, que en Windows es la página ANSI [B35][B29].
~~~~

por

~~~~text
porque en Python 3.14 y anteriores —el 3.12 del laboratorio— `open()` sin codificación usa `locale.getencoding()`, que en Windows es la página ANSI [B35]; desde 3.15 usa UTF-8 estricto [B29][B205], y un archivo en otra codificación falla en vez de leerse.
~~~~

3. Reemplazar

~~~~text
Con `ShouldRunNpmInstall=false` y un target propio que corre `npm ci` antes del interno `RunNpmInstall`, la misma deriva falla con `EUSAGE`. El enganche
~~~~

por

~~~~text
Con `ShouldRunNpmInstall=false` y un target propio que corre `npm ci` antes del interno `RunNpmInstall`, la misma deriva falla con `EUSAGE`.

**`RunNpmInstall` no es un contrato.** El enganche
~~~~

4. Reemplazar

~~~~text
| Para el **devcontainer** y para la frontera A: los tres runtimes tienen que estar en el mismo proceso | Para la **CI que publica** por etapas (frontera B) o componentes publicados aparte |
~~~~

por

~~~~text
| Para el **devcontainer**, la frontera A (los tres runtimes en el mismo proceso) y la CI de un solo artefacto (§11.2.7) | Para la CI de componentes que se publican por separado |
~~~~

5. Reemplazar

~~~~text
La imagen de desarrollo `FROM` la base de la CI (§8.2.6) sale por construcción **si la CI usa la imagen única**;
~~~~

por

~~~~text
La imagen de desarrollo `FROM` la base de la CI (§8.2.6) sale por construcción **si la CI usa la imagen única**, y no existe si corre en el runner alojado (§8.2.2);
~~~~

6. Reemplazar

~~~~text
GitHub Actions ofrece `jobs.<id>.container`, que corre todos los pasos del job en una imagen [B135], y `strategy.matrix`, un job por combinación [B171]. **[criterio]** Imagen única cuando el artefacto es uno: el job corre `./build.sh`, el mismo comando que la estación y el devcontainer. Por componente sólo si los componentes se publican por separado, con una etapa previa que corre la compuerta completa en la imagen única: el Dockerfile por componente del laboratorio corre sólo los comandos estrictos, no la compuerta de texto. La matriz sirve para probar varias versiones de un runtime y no reemplaza a la compuerta; por **sistema operativo**
~~~~

por

~~~~text
GitHub Actions ofrece `jobs.<id>.container`, que corre todos los pasos del job en una imagen [B135], y `strategy.matrix`, un job por combinación [B171]. **[criterio]** Imagen única cuando el artefacto es uno: el job corre `./build.sh`, el mismo comando que la estación y el devcontainer. Por componente sólo si los componentes se publican por separado, con una etapa previa que corre la compuerta completa en la imagen única: el Dockerfile por componente del laboratorio corre sólo los comandos estrictos, no la compuerta de texto. El runner alojado con los tres *setup-* también sirve, sin la base del devcontainer (§8.2.2).

**La matriz no reemplaza a la compuerta.** Sirve para probar varias versiones de un runtime; por **sistema operativo**
~~~~

7. Reemplazar

~~~~text
La lección es de **alcance**: el SBOM del artefacto
~~~~

por

~~~~text
**La lección es de alcance.** El SBOM del artefacto
~~~~

8. Reemplazar

~~~~text
no se confunde con el del producto. La procedencia de BuildKit no está firmada y su `builder.id` sale vacío (§9.2.4); la que firma la plataforma, como la de `actions/attest`, exige en sus dependencias sólo el commit y deja el entorno como opcional [B202]. Para contestar «con qué entorno se ensambló» hay entonces tres partes **[criterio]**: (a) la procedencia de la plataforma, firmada, que nombra commit y workflow; (b) los materiales del entorno —digest de la imagen del job o de cada etapa, toolchain efectivo—, que registra un paso del pipeline (A.17); (c) su vínculo:
~~~~

por

~~~~text
no se confunde con el del producto.

**Para contestar «con qué entorno se ensambló» hacen falta tres partes** **[criterio]**, porque la procedencia de BuildKit no está firmada y su `builder.id` sale vacío (§9.2.4), y la que firma la plataforma, como la de `actions/attest`, exige en sus dependencias sólo el commit y deja el entorno como opcional [B202]:

- (a) la procedencia de la plataforma, firmada, que nombra commit y workflow;
- (b) los materiales del entorno —digest de la imagen del job o de cada etapa (con runner alojado, su versión, §8.2.2), toolchain efectivo—, que registra un paso del pipeline (A.17);
- (c) su vínculo:
~~~~

9. Reemplazar

~~~~text
    subgraph GATE["verificar.sh — compuerta única (§10)"]
~~~~

por

~~~~text
    subgraph GATE["compuerta única: tools/ci/compuerta.sh (A.11, §10)"]
~~~~

10. Reemplazar

~~~~text
| | Por componente | **CI** cuando los componentes se publican por separado, con la compuerta completa corrida antes en la imagen única | E8-5 |
~~~~

por

~~~~text
| | Por componente | **CI** cuando los componentes se publican por separado, con la compuerta completa corrida antes en la imagen única | E8-5 |
| | Runner alojado + *setup-* por SHA | CI que registra el entorno (8a); no comparte base con el devcontainer (§8.2.2) | E5-8 |
~~~~

11. Reemplazar

~~~~text
correr `verificar.sh` desde **Git Bash**, que usa el `PATH` de Windows,
~~~~

por

~~~~text
correr la compuerta (`bash tools/ci/compuerta.sh`) desde **Git Bash**, que usa el `PATH` de Windows,
~~~~

12. Reemplazar

~~~~text
| ESC-05 CI | Build que se publica | Frontera B; imagen única si el artefacto es uno, etapas por componente si se publican por separado (§11.2.7);
~~~~

por

~~~~text
| ESC-05 CI | Build que se publica | Frontera B; imagen única si el artefacto es uno, etapas por componente si se publican por separado (§11.2.7), o runner alojado (§8.2.2);
~~~~

13. Reemplazar

~~~~text
con cp1252 falla C# en Linux, falla Python y Node corrompe sin error los datos que lee (un identificador cp1252 en su propio código sí lo haría fallar, §4.2.4) (E8-1).
~~~~

por

~~~~text
con cp1252, C# en Linux falla si el carácter está en un identificador (como en E8-1) y corrompe sin error si está en un literal; falla Python, y Node corrompe sin error los datos que lee (§4.2.4).
~~~~

14. Reemplazar

~~~~text
Depende de dónde esté la frontera de la build. Si MSBuild llama a npm y uv, los tres runtimes tienen que estar en la misma imagen (E8-3). Si un orquestador llama a cada ecosistema por separado, cada etapa puede usar la imagen de su fabricante. Con las mismas versiones, las dos dan la misma DLL (E8-5).
~~~~

por

~~~~text
La frontera dice si hace falta la imagen única: si MSBuild llama a npm y uv (frontera A), los tres runtimes tienen que estar en la misma imagen (E8-3). La cantidad de artefactos dice si la CI puede partirse (§11.2.7). Con las mismas versiones, las dos dan la misma DLL (E8-5).
~~~~

15. Reemplazar

~~~~text
- tiene **un lock y un archivo de registros por ecosistema** en el repo, verificados por los tres comandos estrictos;
~~~~

por

~~~~text
- tiene **un lock y un archivo de registros por ecosistema** en el repo, verificados por los tres comandos estrictos (que no ven un manifiesto sin lock, §10.2.2);
~~~~

16. Reemplazar

~~~~text
- una compuerta que dice `n/a` para los proyectos de las subcarpetas (§10.2.2).
~~~~

por

~~~~text
- una compuerta que dice `n/a` para los proyectos de las subcarpetas, o `n/a` en el grafo de un ecosistema cuyo manifiesto está versionado (§10.2.2).
~~~~

17. Reemplazar

~~~~text
que forman juntas un repositorio políglota mínimo verificado por EA-1,
~~~~

por

~~~~text
que forman juntas un repositorio políglota mínimo verificado por EA-1 (con sus locks generados, paso 8),
~~~~

### P-12 · §12: SDK con soporte antes de fijar, los dos caminos de CI sin rótulos, 8a con imagen o `NO DECLARADA`, la compuerta que se activa en el paso 4 y la Práctica completa

- **Hallazgos**: C3-02, C3-04, C3-05, C3-07, C3-03, C3-14, C3-20, C3-29.
- **Sección**: §12 tabla pasos 4, 5, 7, 8a (L2474–L2478); contrato YAML L2499–L2510; Práctica L2513–L2516.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa +66, evidencia y plantillas +25.
- **Verificación**: YAML de §12 válido con once validaciones (`yaml.safe_load`); 8b y 9 llevan `# [no verificado]`; la respuesta de la Práctica nombra 11 de 11 validaciones; el paso 8a admite `NO DECLARADA` sólo con runner alojado, igual que A.17.

1. Reemplazar

~~~~text
| 4 | Poner la compuerta de texto en la CI y el hook versionado, con los prerrequisitos de cada estación declarados (A.11).
~~~~

por

~~~~text
| 4 | Activar la compuerta, commiteada en el paso 2, en la CI y en el hook versionado, con los prerrequisitos de cada estación declarados (A.11).
~~~~

2. Reemplazar

~~~~text
| 5 | Fijar el toolchain: `global.json`
~~~~

por

~~~~text
| 5 | Elegir un SDK con soporte (al 2026-10-09, .NET 8 termina el 2026-11-10 [B61]) y fijar el toolchain: `global.json`
~~~~

3. Reemplazar

~~~~text
| 7 | Elegir dónde corre la CI: imagen propia construida **desde** los archivos de los pasos 5–6, con bases por digest que mueve un PR (para 8b, reconstrucción bit a bit o frontera A en la CI), o runner alojado con acciones de *setup* por SHA que los leen (alcanza para 8a).
~~~~

por

~~~~text
| 7 | Elegir dónde corre la CI (§8.2.2): imagen propia construida **desde** los archivos de los pasos 5–6, con bases por digest que mueve un PR (base compartida con el devcontainer, artefactos nativos o imágenes, 8b), o runner alojado con acciones de *setup* por SHA que los leen (alcanza para 8a; su imagen se consulta mientras dure la retención del log).
~~~~

4. Reemplazar

~~~~text
registro del entorno (SDK, compilador y runtimes efectivos, digest de la imagen, commit y árbol limpio; A.17)
~~~~

por

~~~~text
registro del entorno (SDK, compilador y runtimes efectivos, imagen —digest o, con runner alojado, `NO DECLARADA` con su motivo—, commit y árbol limpio; A.17)
~~~~

5. Reemplazar

~~~~text
  - "paso 8a: registro del entorno sin campos vacíos junto al artefacto (A.17)"
  - "paso 8b: la procedencia verifica con su par firmante/builder.id"
  - "paso 9: un PR que toca la compuerta pide la aprobación de su dueño (CODEOWNERS)"
~~~~

por

~~~~text
  - "paso 8a: registro del entorno junto al artefacto (A.17), sin campos vacíos; imagen NO DECLARADA sólo con runner alojado"
  - "paso 8b: la procedencia verifica con su par firmante/builder.id"   # [no verificado]: requiere plataforma alojada
  - "paso 9: un PR que toca la compuerta pide la aprobación de su dueño (CODEOWNERS)"   # [no verificado]: requiere plataforma alojada
~~~~

6. Reemplazar

~~~~text
*Respuesta esperada*: paso 3, E2-2 (`0 con cambio de contenido`); 4, E2-3 (`¿cp1252?`); 5, E3-1 (`A compatible .NET SDK was not found`); 6, E4-1 y E4-4 (`NU1004`, `EUSAGE`); 7, E7-4 (rojo en la imagen vieja).
~~~~

por

~~~~text
*Respuesta esperada*: paso 1, E1-09 (codificación, BOM y CR por archivo); 2, EA-1 paso 1; 3, E2-2 (`0 con cambio de contenido`); 4, E2-3 (`¿cp1252?`); 5, E3-1 (`A compatible .NET SDK was not found`); 6, E4-1, E4-4 y E4-5 (`NU1004`, `EUSAGE`, «needs to be updated»); 7, E7-4 (rojo en la imagen vieja); 8a, EA-1 paso 9 (A.17); 10, E8-1 columna A; 8b y 9 no tienen experimento: requieren una plataforma alojada (Anexo F).
~~~~

### P-13 · Anexo A: plantillas A.1, A.4, A.10, A.11, A.12, A.14 y A.17 alineadas con el laboratorio propuesto

- **Hallazgos**: C3-08, C3-09, C3-11, C3-12, C3-16, C3-17, C3-19, C3-21, C3-22, C3-26, C3-39, C3-44, C3-47, C3-02, C3-05.
- **Sección**: Anexo A: apertura L2522; A.1 L2526–L2564; A.4 L2643–L2646 y párrafo; A.10 L2795–L2836; A.11 L2840–L2864; A.12 L2868–L2927; A.14 L2972–L2990; A.17 L3040–L3072.
- **Capa de origen**: guía + `Examples/A-plantillas/` (laboratorio, L-01). **Costo**: medio. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa +89, evidencia y plantillas +140.
- **Verificación**: `anexoA.py` del ciclo 2 sobre la guía parcheada y `evidencia-auditor/x1-ea1-propuesto/repo/`: 22 de 22 bloques iguales byte a byte (evidencia-auditor/simulacion/anexoA-salida.txt); EA-1 propuesto rc=0 con pasos 1c (3 → 0 violaciones), 8 (sin locks: `n/a`, VERDE) y 9b (`registro: no existe .github/workflows/ci.yml`, rc=1); `owners.py` (x6); el extracto de A.17 coincide con la salida del EA-1 que se versione (commit y hash de la DLL se copian de esa corrida).

1. Reemplazar

~~~~text
Preguntas que guían los campos: ¿qué lector es el más estricto para cada extensión? ¿El repo es nuevo, heredado todavía en cp1252 o heredado ya convertido con BOM (variante B para `*.cs`)? ¿Se acepta normalizar lo que crea `dotnet new console` (`Program.cs` y `.csproj` con BOM) antes del primer commit?
~~~~

por

~~~~text
Preguntas que guían los campos: ¿qué lector es el más estricto para cada extensión? ¿El repo es nuevo, heredado todavía en cp1252 o heredado ya convertido con BOM (variante B para `*.cs`)? ¿Se acepta normalizar, antes de cada commit, lo que crean las plantillas del SDK (con BOM)?
~~~~

2. Reemplazar

~~~~text
# Política de texto del repositorio (guía §5, §11.3; Anexo A.1).
~~~~

por

~~~~text
# Política de texto del repositorio (guía §5, §11.2.2; Anexo A.1).
~~~~

3. Reemplazar

~~~~text
# Las plantillas y comandos del SDK de .NET crean o reponen estos con BOM.
[*.{razor,cshtml,sln}]
~~~~

por

~~~~text
# Con BOM: .razor y .cshtml, porque así los crean las plantillas y así los declaran
# dotnet/aspnetcore y dotnet/aspire; .sln, porque dotnet sln add lo repone.
# .slnx queda en [*]: dotnet sln add le quita el BOM (SDK 10).
[*.{razor,cshtml,sln}]
~~~~

4. Reemplazar

~~~~text
# convención de *.cs (5.2.3); los Directory.Build.* de este anexo se guardan
# entonces con BOM. Con la variante A, lo que crea dotnet new console (Program.cs
# y el .csproj, con BOM) se normaliza antes del primer commit.
~~~~

por

~~~~text
# convención de *.cs (5.2.3); los .props y .targets de este anexo (Directory.Build.*,
# Directory.Packages.props) se guardan entonces con BOM. Con la variante A, cada
# archivo que crea una plantilla del SDK, de proyecto o de ítem, llega con BOM y se
# normaliza antes de su commit (dotnet format en los .cs; la compuerta lo señala).
~~~~

5. Reemplazar

~~~~text
Paso 1c: con la variante B, la solución que crea el SDK, convertida con BOM, no deja ninguna una vez guardados con BOM los `Directory.Build.*`.
~~~~

por

~~~~text
Paso 1c: con la variante B, la solución que crea el SDK, convertida con BOM, no deja ninguna una vez guardados con BOM los `.props` y `.targets` de A.4 y A.5.
~~~~

6. Reemplazar

~~~~text
    <!-- NO configurar PathMap a mano: no normaliza el mapa de SourceLink. -->
  </PropertyGroup>

  <ItemGroup>
    <!-- Lo que el SDK no graba: con qué SDK y en qué imagen (la pasa la CI). -->
    <AssemblyMetadata Include="SdkVersion" Value="$(NETCoreSdkVersion)" />
    <AssemblyMetadata Include="ImagenDigest" Value="$(ImagenDigest)" Condition="'$(ImagenDigest)' != ''" />
  </ItemGroup>
</Project>
~~~~

por

~~~~text
    <!-- NO configurar PathMap a mano: no normaliza el mapa de SourceLink. -->
    <!-- Con qué SDK e imagen se construyó va AL LADO del artefacto (registro del entorno, A.17),
         no adentro: un dato incrustado que cambia con la imagen cambia el hash de la DLL. -->
  </PropertyGroup>
</Project>
~~~~

7. Reemplazar

~~~~text
Preguntas: ¿qué variable define cada CI que usa el equipo? ¿Se quiere restauración estricta sólo en CI? ¿Qué se agrega al artefacto que el SDK no graba?
~~~~

por

~~~~text
Preguntas: ¿qué variable define cada CI que usa el equipo? ¿Se quiere restauración estricta sólo en CI? ¿Qué se registra al lado del artefacto (A.17) y no adentro?
~~~~

8. Reemplazar

~~~~text
# Imagen de desarrollo y CI con los TRES runtimes (plantilla del Anexo A; la de N8 difiere sólo en NODE_IMAGE).
# Cada runtime se toma de su imagen OFICIAL fijada por digest; no se instala nada
# "latest" desde apt. Las versiones deben coincidir con los archivos del repo
# (global.json, .nvmrc, tools/gen/.python-version): lo comprueba verificar.sh, no esta imagen.

ARG SDK_IMAGE=mcr.microsoft.com/dotnet/sdk:8.0@sha256:78235e09001f52b6592c458ac010775ebac6725422e80cd0c1650590f67b2743
~~~~

por

~~~~text
# Imagen de desarrollo y CI con los TRES runtimes (plantilla del Anexo A).
# Cada runtime se toma de su imagen OFICIAL fijada por digest; no se instala nada
# "latest" desde apt. Las versiones deben coincidir con los archivos del repo
# (global.json, .nvmrc, tools/gen/.python-version): lo comprueba la compuerta (A.11), no esta imagen.
# SDK por etiqueta FIJA + digest: el PR de digest del bot trae parches del SO, no otro SDK (guía 10.2.6).

ARG SDK_IMAGE=mcr.microsoft.com/dotnet/sdk:8.0.425-bookworm-slim@sha256:ec9c0a0dc5f60adc2065762050638dd5ed5facfc53716d4580a42d86027c8e80
~~~~

9. Reemplazar

~~~~text
La de `Examples/N8-integracion-poliglota/imagen/Dockerfile`, usada en E8-3, E8-5 y E8-6, difiere sólo en `NODE_IMAGE`, porque N8 fija Node 22.23.2 en su `.nvmrc`.
~~~~

por

~~~~text
La de `Examples/N8-integracion-poliglota/imagen/Dockerfile`, usada en E8-3, E8-5 y E8-6, difiere en `NODE_IMAGE` (N8 fija Node 22.23.2 en su `.nvmrc`), en la referencia del SDK (el mismo 8.0.425 por la etiqueta flotante `sdk:8.0`) y en que no instala `EditorConfig`: N8 no corre la compuerta adentro.
~~~~

10. Reemplazar

~~~~text
Preguntas: ¿la compuerta tiene un solo punto de entrada? ¿Cómo se activa el hook en cada clon (una vez, o en el `postCreateCommand` del devcontainer)?
~~~~

por

~~~~text
Preguntas: ¿la compuerta tiene un solo punto de entrada? ¿Cómo se activa el hook en cada clon (una vez, o en el `postCreateCommand` del devcontainer)? ¿`.githooks/` o pre-commit? Se excluyen (§10.6).
~~~~

11. Reemplazar

~~~~text
A `.githooks/`: el hook de arriba. Creados desde Windows,
~~~~

por

~~~~text
A `.githooks/`: el hook de arriba, **no** el `pre-commit` de N7, que asume `tools/compuerta.sh`. Creados desde Windows,
~~~~

12. Reemplazar

~~~~text
En Windows se corre desde Git Bash, en la raíz del clon: `bash tools/ci/compuerta.sh --staged` **[no verificado]** (requiere Windows). La alternativa sin Python para el paso de texto es editorconfig-checker (§5.2.5).
~~~~

por

~~~~text
En Windows **[no verificado]**: `py -m pip install EditorConfig==0.17.1` y, desde Git Bash en la raíz del clon, `python3 -c "import editorconfig"` y `bash tools/ci/compuerta.sh --staged`. Python no recomienda su comando `python3` [B219]: si Git Bash no lo encuentra, un alias, editorconfig-checker para el texto (§5.2.5) o la CI como único árbitro.
~~~~

13. Reemplazar

~~~~text
# Anexo A.12. Ejemplo NO ejecutado en el laboratorio (requiere GitHub).
name: compuerta
~~~~

por

~~~~text
# .github/workflows/ci.yml — Anexo A.12. Ejemplo NO ejecutado en el laboratorio (requiere GitHub).
# A.17 lee el digest de esta ruta; con otro nombre, WORKFLOW_FILE=<ruta>.
name: compuerta
~~~~

14. Reemplazar

~~~~text
Variante con runner alojado, que alcanza para 8a (§8.2.2); reemplaza `container:` y los pasos previos a la compuerta:
~~~~

por

~~~~text
Variante con runner alojado, que alcanza para 8a (§8.2.2); reemplaza `container:`, el `checkout` y el paso de `SOURCE_DATE_EPOCH`, que se repite al final:
~~~~

15. Reemplazar

~~~~text
      - run: python -m pip install EditorConfig==0.17.1
```
~~~~

por

~~~~text
      - run: python -m pip install EditorConfig==0.17.1
      - run: echo "SOURCE_DATE_EPOCH=$(git log -1 --pretty=%ct)" >> "$GITHUB_ENV"
```
~~~~

16. Reemplazar

~~~~text
*                          @org/desarrollo
/.editorconfig             @org/arquitectura
/.gitattributes            @org/arquitectura
/global.json               @org/arquitectura @org/plataforma
/Directory.Packages.props  @org/arquitectura
**/packages.lock.json      @org/arquitectura
/.devcontainer/            @org/plataforma
/.github/                  @org/plataforma
/tools/ci/                 @org/plataforma
~~~~

por

~~~~text
*                          @org/desarrollo
/.editorconfig             @org/arquitectura
/.gitattributes            @org/arquitectura
/global.json               @org/arquitectura @org/plataforma
/.nvmrc                    @org/arquitectura
**/.python-version         @org/arquitectura
/Directory.Build.props     @org/arquitectura
/Directory.Build.targets   @org/arquitectura
/Directory.Packages.props  @org/arquitectura
/nuget.config              @org/arquitectura
**/.npmrc                  @org/arquitectura
**/pyproject.toml          @org/arquitectura
**/packages.lock.json      @org/arquitectura
**/package-lock.json       @org/arquitectura
**/uv.lock                 @org/arquitectura
/.devcontainer/            @org/plataforma
/imagen/                   @org/plataforma
/.githooks/                @org/plataforma
/.pre-commit-config.yaml   @org/plataforma
/.github/                  @org/plataforma
/tools/ci/                 @org/plataforma
~~~~

17. Reemplazar

~~~~text
Gana el último patrón que coincide [B178].
~~~~

por

~~~~text
Gana el último patrón que coincide [B178]; con estos archivos se desarma la compuerta (§10.2.7).
~~~~

18. Reemplazar

~~~~text
# El digest se declara UNA vez, en el container: del workflow (A.12); el registro lo lee de ahí.
img=$(sed -n 's/^ *\(container\|image\): *\([^ ]*@sha256:[0-9a-f]\{64\}\).*/\2/p' .github/workflows/ci.yml | head -1)
echo "imagen=${img:-NO DECLARADA (runner sin contenedor: capa 4 en el log «Set up job»)}"
~~~~

por

~~~~text
# El digest se declara UNA vez, en el container: del workflow (A.12); el registro lo lee de ahí.
W=${WORKFLOW_FILE:-.github/workflows/ci.yml}
[ -f "$W" ] || { echo "registro: no existe $W (indicá la ruta del workflow en WORKFLOW_FILE)" >&2; exit 1; }
img=$(sed -n 's/^ *\(container\|image\): *\([^ ]*@sha256:[0-9a-f]\{64\}\).*/\2/p' "$W" | head -1)
echo "imagen=${img:-NO DECLARADA (runner alojado: capa 4 en el log «Set up job», mientras dure su retención)}"
~~~~

19. Reemplazar

~~~~text
commit=9fc4bb38… arbol_limpio=si
~~~~

por

~~~~text
commit=ab2a6d36… arbol_limpio=si
~~~~

20. Reemplazar

~~~~text
sha256 out/App.dll=d6cc63cb…
~~~~

por

~~~~text
sha256 out/App.dll=fa6a50ec…
~~~~

21. Reemplazar

~~~~text
El compilador sale de `csc -version`, el dato de `#error version` (`CS8304`, §9.6); sin `container:`, la capa 4 queda en el log del runner [B216].
~~~~

por

~~~~text
El compilador sale de `csc -version`, el dato de `#error version` (`CS8304`, §9.6); sin `container:`, la capa 4 queda en el log del runner [B216] mientras dure su retención [B218]; sin el archivo del workflow, el registro falla (EA-1, paso 9b).
~~~~

### P-14 · Anexo B: los dos caminos de CI en B.3 y B.4, y la receta de Windows en B.1

- **Hallazgos**: C3-06, C3-21.
- **Sección**: B.1 ítem 2; B.3 ítem 1; B.4 ítem 5.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa +29, evidencia y plantillas +0.
- **Verificación**: B.3 y B.4 remiten a §8.2.2; B.1 remite a la receta de A.11.

1. Reemplazar

~~~~text
y lo activé una vez en este clon: `git config core.hooksPath .githooks`. (A.11, §10.4)
~~~~

por

~~~~text
y lo activé una vez en este clon: `git config core.hooksPath .githooks`; en Windows, con la receta de A.11. (A.11, §10.4)
~~~~

2. Reemplazar

~~~~text
- [ ] Toda imagen que construye artefactos publicados va por digest, y un bot
~~~~

por

~~~~text
- [ ] Toda imagen que el repo nombra para construir lo publicado va por digest (o la CI corre en el runner alojado, con su versión registrada, §8.2.2), y un bot
~~~~

3. Reemplazar

~~~~text
- [ ] ¿Lo que construye artefactos publicados sigue por digest? ¿El devcontainer usa etiqueta fija o la receta de la CI, y su SDK coincide con `global.json`? (§8.2.2)
~~~~

por

~~~~text
- [ ] ¿Lo que construye artefactos publicados sigue por digest, o en el runner alojado? ¿El devcontainer usa etiqueta fija o la receta de la CI, y su SDK coincide con `global.json`? (§8.2.2)
~~~~

### P-15 · Anexo C: remisiones del glosario, la promesa de «registro» y dos alias

- **Hallazgos**: C3-43.
- **Sección**: Anexo C L3147, L3199, L3213, L3217, L3229.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa +12, evidencia y plantillas +0.
- **Verificación**: Cada término remite a una sección donde aparece (script de edición-bibliográfica-02); «modo estricto» y «lock» figuran como alias.

1. Reemplazar

~~~~text
| ACP (página de códigos ANSI) | Codificación que Windows usa para las API «-A»; 1252 en español; UTF-8 en Linux para .NET. | §4.1 |
~~~~

por

~~~~text
| ACP (página de códigos ANSI) | Codificación que Windows usa para las API «-A»; 1252 en español; UTF-8 en Linux para .NET. | §4.1, §4.2.1 |
~~~~

2. Reemplazar

~~~~text
| Lock file | Archivo generado que persiste el grafo resuelto con hashes. | §7.1 |
~~~~

por

~~~~text
| Lock file | Archivo generado que persiste el grafo resuelto con hashes. Alias: «lock». | §7.1 |
~~~~

3. Reemplazar

~~~~text
| Registro de paquetes / de imágenes | De dónde se bajan paquetes (alias: índice, *feed*) o imágenes; siempre con su complemento. | §7.1, §8.1 |
~~~~

por

~~~~text
| Registro de paquetes / de imágenes | De dónde se bajan paquetes (alias: índice, *feed*) o imágenes; con su complemento cuando el contexto no lo deja claro. | §7.1, A.12 |
~~~~

4. Reemplazar

~~~~text
| Restauración estricta | Instalación que falla si el lock no coincide, en vez de reescribirlo. | §3.1, §7.1 |
~~~~

por

~~~~text
| Restauración estricta | Instalación que falla si el lock no coincide, en vez de reescribirlo. Alias: «modo estricto». | §3.1, §7.1 |
~~~~

5. Reemplazar

~~~~text
| VS | Visual Studio (no VS Code). | §2.1 |
~~~~

por

~~~~text
| VS | Visual Studio (no VS Code). | §6.2.2 |
~~~~

### P-16 · Anexo D: B218–B224, npm v12 y B217 sin URL repetidas

- **Hallazgos**: C3-05, C3-21, C3-33, C3-27, C3-16, C3-38, C3-50, C3-45.
- **Sección**: Anexo D L3247 (apertura), L3304, L3305, L3391, L3458 y filas nuevas.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa +0, evidencia y plantillas +176.
- **Verificación**: `checks.py` del ciclo 2: 224 definidas, 224 citadas, 0 URL repetidas entre filas distintas; las frases verificadas de §6 de este documento.

1. Reemplazar

~~~~text
Las fuentes B01–B193 se consultaron el **2026-10-07**; B194–B217, el **2026-10-09**.
~~~~

por

~~~~text
Las fuentes B01–B193 se consultaron el **2026-10-07**; B194–B224, el **2026-10-09**.
~~~~

2. Reemplazar

~~~~text
| B63 | npm Docs v11 — `package.json` (`engines`, `devEngines`, `repository`) | https://docs.npmjs.com/cli/v11/configuring-npm/package-json | 2026-10-07 |
~~~~

por

~~~~text
| B63 | npm Docs v11 y v12 — `package.json` (`engines`, `devEngines`, `repository`) | https://docs.npmjs.com/cli/v11/configuring-npm/package-json · https://docs.npmjs.com/cli/v12/configuring-npm/package-json | 2026-10-07; v12, 2026-10-09 |
~~~~

3. Reemplazar

~~~~text
| B64 | npm Docs v11 — config (`engine-strict`) | https://docs.npmjs.com/cli/v11/using-npm/config | 2026-10-07 |
~~~~

por

~~~~text
| B64 | npm Docs v11 y v12 — config (`engine-strict`) | https://docs.npmjs.com/cli/v11/using-npm/config · https://docs.npmjs.com/cli/v12/using-npm/config | 2026-10-07; v12, 2026-10-09 |
~~~~

4. Reemplazar

~~~~text
| B150 | npm Docs v11 — `npm pack` | https://docs.npmjs.com/cli/v11/commands/npm-pack | 2026-10-07 |
~~~~

por

~~~~text
| B150 | npm Docs v11 y v12 — `npm pack` | https://docs.npmjs.com/cli/v11/commands/npm-pack · https://docs.npmjs.com/cli/v12/commands/npm-pack | 2026-10-07; v12, 2026-10-09 |
~~~~

5. Reemplazar

~~~~text
| B217 | GitHub Actions — `setup-python` y etiquetas de `setup-dotnet` v6.0.0, `setup-node` v7.1.0, `setup-python` v7.0.0, `setup-uv` v10.2.0 (`git ls-remote`) | https://github.com/actions/setup-python · https://github.com/actions/setup-dotnet · https://github.com/actions/setup-node · https://github.com/astral-sh/setup-uv | 2026-10-09 |
~~~~

por

~~~~text
| B217 | GitHub Actions — `setup-python`; etiquetas y SHA de las cuatro acciones de *setup* (`setup-dotnet` v6.0.0, `setup-node` v7.1.0, `setup-python` v7.0.0, `setup-uv` v10.2.0; `git ls-remote`; las otras tres URL, como B181) | https://github.com/actions/setup-python | 2026-10-09 |
| B218 | GitHub Docs — Configuring the retention period for GitHub Actions artifacts and logs in your organization (90 días; entre 1 y 400 en privados) | https://docs.github.com/en/organizations/managing-organization-settings/configuring-the-retention-period-for-github-actions-artifacts-and-logs-in-your-organization | 2026-10-09 |
| B219 | Python — Using Python on Windows (`python3` «not meant to be widely used or recommended»; `py`) | https://docs.python.org/3/using/windows.html | 2026-10-09 |
| B220 | Python — `os`, Python UTF-8 Mode (manejador estricto; activo por defecto desde 3.15) | https://docs.python.org/3/library/os.html#utf8-mode | 2026-10-09 |
| B221 | GitHub CLI — `gh attestation verify` (`--signer-workflow`, `--signer-repo`, `--source-ref`) | https://cli.github.com/manual/gh_attestation_verify | 2026-10-09 |
| B222 | `.editorconfig` de `dotnet/aspnetcore` y `dotnet/aspire` (`[*.{razor,cshtml}] charset = utf-8-bom`, `[*] charset = utf-8`) | https://github.com/dotnet/aspnetcore/blob/main/.editorconfig · https://github.com/dotnet/aspire/blob/main/.editorconfig | 2026-10-09 |
| B223 | astral-sh/uv — release 0.13.0 (2026-10-09; Python por defecto 3.15) | https://github.com/astral-sh/uv/releases/tag/0.13.0 | 2026-10-09 |
| B224 | .NET — `releases-index.json` (8.0: `eol-date` 2026-11-10; 10.0: `latest-sdk` 10.0.401), reconsultado | https://builds.dotnet.microsoft.com/dotnet/release-metadata/releases-index.json | 2026-10-09 |
~~~~

### P-17 · Anexo E: fecha de cada corrida, E1-11 con Node, E2-6 ampliado y E5-8

- **Hallazgos**: C3-34, C3-37, C3-16, C3-01.
- **Sección**: Anexo E L3464 y filas E1-11, E2-6, E5-7.
- **Capa de origen**: guía + laboratorio (L-02, L-04, L-05, L-06). **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa +3, evidencia y plantillas +65.
- **Verificación**: Las fechas salen de la fecha de modificación de las 85 salidas (`find … -newermt 2026-10-08`: 39 del 2026-10-09) cruzada con `Ciclo-1/05-Aplicacion.md` L18 y `Ciclo-2/05-Aplicacion.md` §4.2 (evidencia-auditor/x7); las salidas nuevas existen; 74 IDs.

1. Reemplazar

~~~~text
Fecha de las corridas: 2026-10-07 (las ampliaciones de la revisión, 2026-10-09), Linux x86_64 con Docker.
~~~~

por

~~~~text
Fecha de las corridas: 2026-10-07; el 2026-10-09, E1-04, E1-05, E1-11 (Node), E1-13, §1.2, E2, E3-1 a E3-6, E4-2, E4-4, E5-8, E7, E8-3, E8-5, E8-6 (§11.5) y EA-1. Linux x86_64 con Docker.
~~~~

2. Reemplazar

~~~~text
| E1-11 | Shebang con BOM y con CRLF según quién lo lance | `…/N1-…/e1-shebang.sh` | `e1-shebang.txt` |
~~~~

por

~~~~text
| E1-11 | Shebang con BOM y con CRLF según quién lo lance (dash, bash, `subprocess` de Python, `spawnSync` de Node) | `…/N1-…/e1-shebang.sh`, `e1-shebang-node.mjs` | `e1-shebang.txt`, `e1-shebang-node.txt` |
~~~~

3. Reemplazar

~~~~text
| E2-6 | Plantillas del SDK 8 y 10; `dotnet format`; `dotnet sln add` | `…/N2-…/e6-plantillas-dotnet/` | `e6-plantillas-dotnet.txt` |
~~~~

por

~~~~text
| E2-6 | Plantillas del SDK 8 y 10, de proyecto y de ítem; `dotnet format`; `dotnet sln add` con y sin BOM | `…/N2-…/e6-plantillas-dotnet/` | `e6-plantillas-dotnet.txt` |
~~~~

4. Reemplazar

~~~~text
| E5-7 | git no expande llaves en `.gitattributes` | `…/N5-…/e7-llaves-en-gitattributes/` | `E5-7-*.txt` |
~~~~

por

~~~~text
| E5-7 | git no expande llaves en `.gitattributes` | `…/N5-…/e7-llaves-en-gitattributes/` | `E5-7-*.txt` |
| E5-8 | La capa 4 no cambia la DLL ni el PDB de un artefacto .NET gestionado: mismo SDK en tres bases, mismo hash; otro SDK, otro | `…/N5-…/e8-capa4-y-artefacto/` | `E5-8-capa4-y-artefacto.txt` |
~~~~

### P-18 · Anexo F: trazas completas, límites del runner alojado y datos volátiles con su fuente

- **Hallazgos**: C3-36, C3-38, C3-45, C3-05, C3-13.
- **Sección**: Anexo F L3546, L3547, L3550; «No verificado»; «Datos volátiles» L3591.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa +48, evidencia y plantillas +14.
- **Verificación**: `sed -n '/Datos volátiles/p' | grep -o '\[B[0-9]*\]' | wc -l` ≥ 12; las tres filas de trazas nombran sus plantillas.

1. Reemplazar

~~~~text
| P-03 | Criterio de codificación unificado, sin commits de BOM | §5, §10.2.5, A.1, A.2 |
~~~~

por

~~~~text
| P-03 | Criterio de codificación unificado, sin commits de BOM | §5, §10.2.5, A.1, A.2, A.15 |
~~~~

2. Reemplazar

~~~~text
| P-04 | Congelar paquetes NuGet | §7 |
~~~~

por

~~~~text
| P-04 | Congelar paquetes NuGet | §7, A.5, A.6 |
~~~~

3. Reemplazar

~~~~text
| P-07 | Integrarlo con herramientas en Windows y Linux | §8.2.4, §10, §12 |
~~~~

por

~~~~text
| P-07 | Integrarlo con herramientas en Windows y Linux | §0.4, §3.6, §8.2.4, §10.4, §11.4, §12 |
~~~~

4. Reemplazar

~~~~text
- `actions/attest`, la procedencia de npm, las atestaciones de PyPI y los metadatos del runner de GitLab: requieren una plataforma alojada.
~~~~

por

~~~~text
- `actions/attest`, la procedencia de npm, las atestaciones de PyPI y los metadatos del runner de GitLab: requieren una plataforma alojada. Tampoco se observó el log «Set up job» del runner alojado ni su retención: lo dicen [B216] y [B218].
~~~~

5. Reemplazar

~~~~text
**Datos volátiles** (al 2026-10-07; los de B194–B217, al 2026-10-09; revisar antes de aplicar): SDK de .NET 10.0.401 vigente y .NET 11 en RC1; SDK 8.0.425, el del caso, y fin de soporte de .NET 8 y 9 el 2026-11-10; Node 24 LTS activa, Node 26 *Current*, Node 20 sin soporte; Python 3.15.0 publicada el 2026-10-09; uv 0.12.23; npm 12; pnpm 12; pre-commit 4.6.2; `actions/checkout` v7.0.1; SLSA v1.2; CycloneDX 1.7; SPDX 3.0.1.
~~~~

por

~~~~text
**Datos volátiles** (cada uno a la fecha de su fuente; revisar antes de aplicar): SDK de .NET 10.0.401 vigente y .NET 11 en RC1 [B224][B62]; SDK 8.0.425, el del caso, y fin de soporte de .NET 8 y 9 el 2026-11-10 [B61][B224]; `CheckSdkVulnerabilities` sólo desde el SDK 11 (§6.3); Node 24 LTS activa, Node 26 *Current*, Node 20 sin soporte [B68]; Python 3.15.0 publicada el 2026-10-09 [B205]; uv 0.12.23 en el laboratorio y uv 0.13.0 publicada el 2026-10-09, que pasa el Python por defecto a 3.15 [B223]; npm 12 [B93]; pnpm 12 (E3-3); pre-commit 4.6.2 [B180]; `actions/checkout` v7.0.1 [B193]; SLSA v1.2 [B07]; CycloneDX 1.7 [B156]; SPDX 3.0.1 [B155].
~~~~

### P-19 · Control de cambios: fila 1.1.0

- **Hallazgos**: C3-01…C3-53.
- **Sección**: Control de cambios, al final.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa -14, evidencia y plantillas +1.
- **Verificación**: La fila 1.1.0 coincide con `version:`; la celda tiene ≤ 21 palabras (criterio del ciclo 2).

1. Reemplazar

~~~~text
| 1.0.0 | 2026-10-09 | Revisión integral, ciclo 2; versión vigente (abajo). |
~~~~

por

~~~~text
| 1.0.0 | 2026-10-09 | Revisión integral, ciclo 2 (abajo). |
| 1.1.0 | 2026-10-09 | Revisión integral, ciclo 3; versión vigente (abajo). |
~~~~

2. Reemplazar

~~~~text
**1.0.0-rc.1.** Corrige el *fallback* de Roslyn, la convención de BOM de .NET, la migración con *squash*, el costo de `disable`, el lock que calla `NU1603`, digest y bot donde se construye lo publicado, el nivel SLSA de un `builder.id` vacío, qué impide una rama protegida y la frontera de build políglota. Agrega ruta mínima y Práctica, mapa por contexto, preguntas situadas, trazas, glosario, B194–B204, E2-7, E2-8 y plantillas; fija cuatro marcas de juicio (§0.3).
~~~~

por

~~~~text
**1.0.0-rc.1.** *Fallback* de Roslyn, BOM de .NET, migración con *squash*, costo de `disable`, `NU1603` con lock, digest y bot, SLSA sin `builder.id`, ramas protegidas, frontera políglota; ruta mínima, Prácticas, mapa, glosario, trazas, B194–B204, E2-7, E2-8.
~~~~

3. Reemplazar

~~~~text
**1.0.0.** Corrige las dos defensas contra `NU1603`, el lock de `WinExe`, la compuerta en subcarpetas y sus prerrequisitos, el devcontainer en host Linux, la variante B, pnpm 10, Python 3.15.0, la procedencia para 8b, los dos caminos de CI, qué no impiden un chequeo requerido y un `pre-receive`, y los extractos literales. Agrega A.17, A.18, la Práctica de §11 y §12, y B205–B217.
~~~~

por

~~~~text
**1.0.0.** Dos defensas contra `NU1603`, lock de `WinExe`, compuerta en subcarpetas, devcontainer en Linux, variante B, pnpm 10, Python 3.15.0, procedencia para 8b, dos caminos de CI, `pre-receive`; A.17, A.18, Prácticas de §11 y §12, B205–B217.

**1.1.0.** Qué decide cada capa sobre el artefacto (E5-8), aplicado en todo el texto; `CheckSdkVulnerabilities`, BOM de `.slnx` y `.razor`, Python 3.15 con cp1252, digest de índice, registro y dueños de la compuerta, `gh attestation verify`; §3.5 comprimida, Práctica de §3, B218–B224.
~~~~

### P-20 · Compresión: repeticiones que el cuerpo ya dice en su lugar (recortes 2 y 3 de C3-35, más dos aperturas)

- **Hallazgos**: C3-35.
- **Sección**: §5.2.6 recuadro «Desde Windows»; apertura del Anexo A.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa -74, evidencia y plantillas +0.
- **Verificación**: Lo quitado está dicho en §0.4 y en la fila EA-1 del Anexo E; 0 enlaces rotos (script de enlaces del ciclo 2).

1. Reemplazar

~~~~text
Desde Windows: esa imagen con Docker Desktop montando el clon, o Git Bash con Python, el paquete y un `iconv` disponible **[no verificado]** (requiere Windows).
~~~~

por

~~~~text
Desde Windows, las vías de §0.4 **[no verificado]** (requiere Windows).
~~~~

2. Reemplazar

~~~~text
y **EA-1** (`Examples/A-plantillas/verificar.sh`) las verifica en conjunto: resolución de `.editorconfig` y `.gitattributes`, compuerta de texto sobre las propias plantillas, un `dotnet new console` creado dentro del repo, condición de CI de `Directory.Build.props`, lock sólo en los ejecutables (también `WinExe`), variante B de A.1, la imagen de A.10 con la plantilla `web/` y la compuerta completa adentro, registro del entorno, `devEngines`, uv, `devcontainer up`, y sintaxis de JSONC, YAML y del esquema de `dependabot.yml`.
~~~~

por

~~~~text
y **EA-1** (`Examples/A-plantillas/verificar.sh`) las verifica en conjunto; cada plantilla dice qué paso la comprueba.
~~~~

### P-21 · Compresión: aperturas y respuestas que repiten lo que su sección ya dice (C3-35, recortes 3 y adicionales)

- **Hallazgos**: C3-35.
- **Sección**: §3 apertura L264; §10.6 última pregunta; §11 apertura; §12 párrafo de cierre; A.4 párrafo de verificación.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa -125, evidencia y plantillas +0.
- **Verificación**: Lo quitado está en la columna «Capítulo» de §3.2, en A.11, en los títulos de §11.2, en §8.2.4 y en el comentario de A.4; 0 enlaces rotos.

1. Reemplazar

~~~~text
 Es el mapa: §4 y §5 tratan la capa 1; §6, §7 y §8, las capas 2, 3 y 4; §9, las capas 5 y 6; §10, cómo se hace cumplir todo lo anterior; y §11 cruza todas las capas en una solución con tres ecosistemas.
~~~~

por

~~~~text
 La columna «Capítulo» de §3.2 es el mapa.
~~~~

2. Reemplazar

~~~~text
Si la estación tiene lo que la compuerta necesita: `bash`, `python3`, el paquete `EditorConfig` y `check_text_policy.py` junto a `compuerta.sh` (§10.4). Sin `python3` el verificador no corre, y una compuerta que no distingue «falta herramienta» de «violación» informa lo segundo. Se instala lo que falta o se corrige la compuerta para que lo diga;
~~~~

por

~~~~text
Si la estación tiene los prerrequisitos de A.11: una compuerta que no distingue «falta herramienta» de «violación» informa lo segundo. Se instala lo que falta (receta de A.11) o se corrige la compuerta para que lo diga;
~~~~

3. Reemplazar

~~~~text
y mira qué se rompe **en las uniones**: la política de texto que sirve a uno y daña a otro, las versiones que cada herramienta busca en otro lugar, la build de un ecosistema que llama a otro sin saber con qué versión, la imagen que tiene que traer tres runtimes, y el SBOM y la procedencia que tienen que cubrir todo.
~~~~

por

~~~~text
y mira qué se rompe **en las uniones**: texto, versiones, la build que cruza ecosistemas, la imagen, el SBOM y la procedencia.
~~~~

4. Reemplazar

~~~~text
Visual Studio en Windows queda dentro en todos: lee `.editorconfig` y `global.json`, restaura con NuGet y, si su integración de git respeta `core.hooksPath`, ejecuta el hook **[no verificado]** (requiere Windows); lo que no tiene (el devcontainer) no se le exige, porque el árbitro es la CI.
~~~~

por

~~~~text
Visual Studio en Windows queda dentro en todos (§8.2.4): lo que no tiene, el devcontainer, no se le exige, porque el árbitro es la CI.
~~~~

5. Reemplazar

~~~~text
 `LangVersion` se omite: lo fija el TFM, y un valor fijo para todo el repo deja a un proyecto `net10.0` en C# 12 sin aviso; si hace falta, nunca `latest` [B57].
~~~~

por

~~~~text
 `LangVersion` se omite: un valor fijo para todo el repo deja a un proyecto `net10.0` en C# 12 sin aviso [B57].
~~~~

### P-22 · Compresión: preguntas guía que repiten su sección (C3-35, recorte 2 ampliado)

- **Hallazgos**: C3-35.
- **Sección**: §6.6 preguntas 1 y 3; §10.6 pregunta 2; §11.6 pregunta 1.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa -58, evidencia y plantillas +0.
- **Verificación**: Cada respuesta conserva su *Aplica* y remite a la sección que la desarrolla; el conteo de `*Aplica*` baja en 1 por la fusión de §6.6 (como en §8.6, P-08).

1. Reemplazar

~~~~text
**¿Qué fija `global.json` y qué no?**
Fija el SDK que eligen `dotnet` y el resolvedor de MSBuild y, en la CLI, por arrastre, el compilador, los analizadores incorporados y los *targets*; en Visual Studio el motor MSBuild es el del IDE y, con el SDK 8, también el compilador (§6.2.2). No fija el TFM, ni la versión de C#, ni el runtime de ejecución, ni los paquetes que el proyecto referencia (aunque el SDK aporte algunos implícitos). *Aplica* siempre que haya más de una máquina.
~~~~

por

~~~~text
**¿Qué fija `global.json` y qué no? ¿Fija el compilador de C# y el runtime?**
Fija el SDK que eligen `dotnet` y el resolvedor de MSBuild y, en la CLI, por arrastre, el compilador, los analizadores incorporados y los *targets*; en Visual Studio el compilador depende del SDK (§6.2.2). No fija el TFM, ni la versión de C#, ni el runtime de ejecución, ni los paquetes que el proyecto referencia (aunque el SDK aporte algunos implícitos). *Aplica* siempre que haya más de una máquina, y al diagnosticar «compila igual pero se comporta distinto»: compilador y runtime se miran y se registran por separado.
~~~~

2. Reemplazar

~~~~text
**¿Fijar el SDK fija el compilador de C# y el runtime?**
El compilador, en la CLI sí y en Visual Studio depende del SDK (§6.2.2); el runtime no. *Aplica* al diagnosticar «compila igual pero se comporta distinto»: mirar las dos capas por separado y registrar ambas.


~~~~

por

~~~~text

~~~~

3. Reemplazar

~~~~text
No: no viaja con el clon, se activa a mano y se saltea con `--no-verify` (E7-1). *Aplica* a todo equipo: el hook es para ACT-DEV; la defensa es la CI (ESC-05).
~~~~

por

~~~~text
No (§10.2.3, E7-1). *Aplica* a todo equipo: el hook es para ACT-DEV; la defensa es la CI (ESC-05).
~~~~

4. Reemplazar

~~~~text
Lo que nadie mira: los scripts con shebang y los lectores estrictos de datos, no el compilador. Con BOM global fallan cinco lectores y ninguno es de .NET; con CRLF fallan los dos shebangs;
~~~~

por

~~~~text
Lo que nadie mira (§11.2.1): los scripts con shebang y los lectores estrictos de datos, no el compilador;
~~~~

### P-23 · Compresión transversal: la glosa «(requiere Windows)», motivo por defecto desde P-01

- **Hallazgos**: C3-35.
- **Sección**: L112, L393, L490, L505, L697, L816, L2006, L2327.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa -16, evidencia y plantillas +0.
- **Verificación**: `grep -c '\*\*\[no verificado\]\*\* (requiere Windows)'` → 0 después del parche (la regla queda escrita una vez, en §0.3).

1. Reemplazar las 8 apariciones de

~~~~text
**[no verificado]** (requiere Windows)
~~~~

por

~~~~text
**[no verificado]**
~~~~

## 4. P-24 · Capa de origen (bitácora): notas de solo agregado

- **Hallazgos**: C3-01, C3-02, C3-03, C3-05, C3-07, C3-10, C3-11, C3-12, C3-13, C3-14, C3-15, C3-16, C3-17, C3-18, C3-19, C3-22, C3-24, C3-26, C3-27, C3-28, C3-31, C3-32, C3-33, C3-37, C3-49, C3-52, C3-53; pendientes del ciclo 2 (`Ciclo-2/05-Aplicacion.md` §6.3): O-5 (acotamiento), O-12, la nota de C1-05 en N7 L154 y la de `04-Integracion.md`.
- **Capa**: `Bitcora/Nucleos/`, `Bitcora/04-Integracion.md`, `Mesa/Ciclo-1/03-Parches.md`, `Mesa/Ciclo-2/01-Consolidado.md`. **Costo**: bajo. **Reversible**: sí (sólo se agregan líneas). **Δ palabras de la guía**: 0.
- **Formato**: como en los ciclos 1 y 2, cada nota se inserta como párrafo citado **al pie del bloque que contiene la frase ancla**. Antes de insertar, instantánea de los archivos en `Ciclo-3/aplicacion/instantanea-origen/`.
- **Verificación**: `diff` de cada archivo contra la instantánea: sólo líneas `>`, 0 `<`; once notas encontradas por `Corrección mesa ciclo 3` o `Nota de solo agregado (ciclo 3`; el `grep` de identificadores privados del contrato (R-PRIV) → 0 en las notas.

| # | Archivo | Ancla (bloque al pie del cual se inserta) | Nota a insertar |
|---|---|---|---|
| O-1 | `Nucleos/N5-entornos-en-contenedores.md` | la nota que empieza `> **Corrección mesa ciclo 2 (2026-10-09, C2-11, C2-13, C2-17, C2-23).**` (L114) | `> **Corrección mesa ciclo 3 (2026-10-09, C3-01, C3-02, C3-03, C3-05, C3-07, C3-10, C3-11). Acota C1-21 (b), C1-18 (b) y C2-13** (pendiente O-5 del ciclo 2). La regla «digest en todo lo que construye lo publicado» pasa a «digest en toda imagen que el repo nombra para construir lo publicado», con una definición: los bytes de un artefacto .NET gestionado los decide la capa 2 exacta (E5-8: SDK 8.0.425 y `ContinuousIntegrationBuild`, la misma DLL `9815b804…` y el mismo PDB en Debian 12, Ubuntu 24.04 y Debian 13; con 10.0.400, `7cd2a836…`; `Mesa/Ciclo-3/evidencia-abogado-del-diablo/02-capa4-y-artefacto/`, re-corrido en `evidencia-auditor/x5-e5-8-capa4/`); la capa 4 decide la ejecución, lo nativo **[interpretación]** y lo que se publica como imagen. De ahí, dos caminos de CI: imagen propia por digest (base compartida con el devcontainer, nativo o imagen, 8b) o runner alojado (8a, con la capa 4 en un log que caduca: 90 días; 1–400 en privados [B218]). «Reconstrucción bit a bit» deja de ser motivo de la imagen propia. El digest de un índice multiplataforma fija el manifiesto, no la imagen de cada arquitectura (`imagetools inspect`, 2026-10-09). A.10 pasa a `sdk:8.0.425-bookworm-slim@sha256:ec9c0a0d…` (etiqueta fija: el bot ya no trae otro SDK). Guía §8.1, §8.2.2, §8.2.6, §9.6, §12, A.10 (Ciclo-3, P-08, P-09, P-12, P-13).` |
| O-2 | `Nucleos/N7-compuertas-y-gobierno.md` | la nota que empieza `> **Corrección mesa ciclo 1 (2026-10-09, C1-05).**` (L154) | `> **Corrección mesa ciclo 3 (2026-10-09, C3-18, C3-19, C3-22, C3-26; pendiente de C1-05).** «Un inventario explícito de proyectos, como en verificar.sh de N8» quedó sin efecto en el ciclo 2 (C2-06): la compuerta de N7 encuentra los proyectos con `git ls-files`, y `verificar.sh` es sólo la de la solución de referencia. Límite: un manifiesto versionado sin lock da `n/a` y VERDE (EA-1 paso 8; `Mesa/Ciclo-3/evidencia-auditor/x1-ea1-propuesto/salida.txt`). `pre-commit install` se niega con `core.hooksPath` (pre-commit 4.6.2, `Cowardly refusing…`): las dos entradas se excluyen. `CODEOWNERS` asigna a arquitectura o plataforma lo que desarma la compuerta (`evidencia-auditor/x6-codeowners/`). Guía §10.2.7, §10.4, §10.6, §11.7, A.14 (Ciclo-3, P-10, P-11, P-13).` |
| O-3 | `Nucleos/N2-politica-de-texto-y-remediacion.md` | la nota que empieza `> **Corrección mesa ciclo 2 (2026-10-09, C2-12).**` (L145) | `> **Corrección mesa ciclo 3 (2026-10-09, C3-16, C3-17).** Las razones por extensión se ajustan a lo que hace la CLI (E2-6 ampliado, `Mesa/Ciclo-3/evidencia-auditor/x2-e2-6-ampliado/`): `.slnx` pierde el BOM con `dotnet sln add` (SDK 10.0.400) y va sin BOM; `.csproj` lo conserva; las plantillas de ítem (`class`, `interface`, `razorcomponent`) crean con BOM, así que el costo de la variante A es recurrente; ningún comando repone el BOM de un `.razor` (`dotnet format whitespace` no lo hace): va con BOM por las plantillas y por la convención de `dotnet/aspnetcore` y `dotnet/aspire` [B222]. Con la variante B se guardan con BOM todos los `.props`/`.targets`, también `Directory.Packages.props` (EA-1 paso 1c: 3 violaciones → 0). Guía §5.2.3, §5.6, §11.2.2, A.1 (Ciclo-3, P-05, P-11, P-13).` |
| O-4 | `Nucleos/N6-procedencia-y-trazabilidad.md` | el bloque `xml` que contiene `<AssemblyMetadata Include="ImagenDigest"` (L352) | `> **Corrección mesa ciclo 3 (2026-10-09, C3-12, C3-27).** El `AssemblyMetadata` de `SdkVersion` e `ImagenDigest` sale de la plantilla: nadie lo alimentaba, contradecía «el digest se declara una vez» y, conectado, cambia el hash de la DLL según la imagen (`Mesa/Ciclo-3/evidencia-senior-dotnet/imagendigest.txt`: `b35eb130…`, `031b8d55…`, `1c1f2270…`). SDK e imagen van al lado del artefacto (A.17). E6-1 queda como demostración. La verificación de consumidor de `actions/attest` fija `--signer-workflow` y `--source-ref`: sólo con `-R` acepta cualquier workflow y rama [B221]. Guía §9.2.1, §9.3, §9.5, A.4 (Ciclo-3, P-09, P-13).` |
| O-5 | `Nucleos/N8-integracion-poliglota.md` | la nota que empieza `> **Corrección mesa ciclo 2 (2026-10-09, C2-06, C2-14, C2-48).**` (L177) | `> **Corrección mesa ciclo 3 (2026-10-09, C3-22, C3-28, C3-52).** El diagrama del modelo integrado y §11.4 nombran la compuerta del lector (`tools/ci/compuerta.sh`, A.11), no `verificar.sh`. La imagen única se decide por la cantidad de artefactos (§11.2.7) y la frontera sólo dice si hace falta para F5 (A). «Con cp1252 falla C# en Linux» se acota: falla si el carácter está en un identificador, como en E8-1, y corrompe sin error en un literal. Guía §11.2.6, §11.2.9, §11.4, §11.6 (Ciclo-3, P-11).` |
| O-6 | `Nucleos/N1-codificacion-y-finales-de-linea.md` | la nota que empieza `> **Corrección mesa ciclo 2 (2026-10-09, C2-29, C2-31).**` (L181) | `> **Corrección mesa ciclo 3 (2026-10-09, C3-31, C3-33, C3-37, C3-53).** Con Python ≥ 3.15 el modo UTF-8 usa el manejador estricto: un cp1252 da `UnicodeDecodeError` [B220] (E1 de `Mesa/Ciclo-3/Informe-adhoc-AH-001.md`, `-X utf8` con 3.12.14). Un script con BOM lanzado por un shell sale con 0 sólo si el resto es shell válido (E8-1: `.py` con BOM, rc=2). El `child_process` de Node tiene ahora evidencia: `spawnSync` con Node 24.21.0, `status 0` y `not found` en stderr (`Mesa/Ciclo-3/evidencia-auditor/x3-shebang-node/`). Guía §4, §4.2.4 (Ciclo-3, P-04).` |
| O-7 | `Nucleos/N4-congelamiento-de-dependencias.md` | la nota que empieza `> **Corrección mesa ciclo 2 (2026-10-09, C2-01, C2-03).**` (L101) | `> **Corrección mesa ciclo 3 (2026-10-09, C3-24, C3-32).** `dotnet restore --locked-mode` en la raíz falla con MSB1003 en la disposición de las plantillas (sin `.sln` en la raíz): el ejemplo de la guía nombra el proyecto. El README de N4 y `run.sh` decían «sin advertir» y «línea comentada de A.4»: la corrida da `NU1603` y A.4 tiene la línea activa desde el ciclo 2. Guía §7.5 (Ciclo-3, P-07; laboratorio L-05).` |
| O-8 | `Nucleos/N3-fijacion-del-toolchain.md` | la nota que empieza `> **Corrección mesa ciclo 2 (2026-10-09, C2-30, C2-41).**` (L93) | `> **Corrección mesa ciclo 3 (2026-10-09, C3-13, C3-14, C3-15, C3-49).** `CheckSdkVulnerabilities` existe desde el SDK 11: en 8.0.425 y 10.0.400 el target no existe (`MSB4057`, `Mesa/Ciclo-3/evidencia-senior-dotnet/checksdkvuln.txt`); con SDK 8 o 10 avisa `dotnet sdk check` (`8.0.425 … going out of support soon`, `evidencia-abogado-del-diablo/03-sdk8-eol/`). [B56] recomienda un rango en CI y `disable` sólo con lock: el lock por defecto es criterio de la guía, no del fabricante (no reabre C1-03). `requires-python` lo aplica uv en el proyecto tipo; pip, sólo al instalar el paquete. §12 p.5 elige un SDK con soporte antes de fijar (.NET 8 termina el 2026-11-10). Guía §6.3, §6.4, §6.6, §10.2.6, §10.3, §12 (Ciclo-3, P-06, P-10, P-12).` |
| O-9 | `04-Integracion.md` | la nota que empieza `> **Corrección mesa ciclo 1 (2026-10-09, C1-20, C1-21).**` (L119) | `> **Corrección mesa ciclo 2 y 3 (2026-10-09, C2-13, C3-01; pendiente O-12 del ciclo 2).** «Digest + bot en lo que construye lo publicado» se acota a las imágenes que el repo nombra: la CI también puede correr en el runner alojado con acciones de *setup* por SHA (C2-13), que alcanza para 8a; la definición de qué decide cada capa sobre el artefacto está en la guía §8.2.2 (E5-8) y las demás reglas remiten ahí (Ciclo-3, P-08).` |
| O-10 | `Mesa/Ciclo-1/03-Parches.md` | al final del archivo | `> **Nota de solo agregado (ciclo 3, 2026-10-09; pendiente de P-22 del ciclo 2 y C3-12).** Tres textos de este documento se corrigieron en la guía sin nota acá: el chequeo requerido de GitHub se identifica por nombre y hay que fijar la app esperada (C2-19); un `pre-receive` lo puede deshabilitar quien administra el servidor o, en GHES, quien recibió la delegación (C2-20); «BuildKit para procedencia» no es alternativa en la disposición de un solo artefacto (C2-21). El `AssemblyMetadata ImagenDigest` del bloque de A.4 (L866) se retira en el ciclo 3 (C3-12). Ver `Mesa/Ciclo-2/05-Aplicacion.md` y `Mesa/Ciclo-3/03-Parches.md` P-13.` |
| O-11 | `Mesa/Ciclo-2/01-Consolidado.md` | al final del archivo | `> **Nota de solo agregado (ciclo 3, 2026-10-09, C3-10).** `Informe-adhoc-CAT-FORMAL.md` L10–L23 (CAT-FORMAL-01, digest de índice multiplataforma) no tuvo fila en este consolidado. Se dispuso como C3-10 en `Mesa/Ciclo-3/01-Consolidado.md` (C3-Q11 queda para el juez de coherencia).` |

## 5. P-25 · Laboratorio (`Examples/`)

- **Hallazgos**: C3-01, C3-09, C3-11, C3-12, C3-16, C3-17, C3-18, C3-22, C3-26, C3-32, C3-37, C3-39, C3-44.
- **Capa**: laboratorio. **Costo**: medio (EA-1 completo ≈ 4 min con las imágenes en caché; E5-8 ≈ 3 min y red; E2-6 con los dos SDK ≈ 2 min). **Reversible**: sí, con la instantánea de `Examples/` antes de aplicar.
- **Fuentes ya probadas**: [`evidencia-auditor/x1-ea1-propuesto/`](evidencia-auditor/x1-ea1-propuesto/) tiene el `repo/` y el `verificar.sh` que resultan de esta tabla, con `plantillas.diff` (118 líneas) y `verificar.diff` (40), y su `salida.txt` (rc=0). Sus bloques coinciden byte a byte con el Anexo A de la guía parcheada: `anexoA.py` del ciclo 2 da **TODO IGUAL** (`simulacion/anexoA-salida.txt`).

| # | Archivo | Cambio | Fuente | Re-correr y esperar |
|---|---|---|---|---|
| L-01 | `A-plantillas/repo/`: `Directory.Build.props`, `imagen/Dockerfile`, `.github/CODEOWNERS`, `.github/workflows/ci.yml`, `tools/ci/registrar-entorno.sh`, `.editorconfig` | los bloques A.4, A.10, A.14, A.12, A.17 y A.1 de la guía parcheada | `x1-ea1-propuesto/plantillas.diff` | `anexoA.py`: 22 de 22 iguales |
| L-01b | `A-plantillas/verificar.sh` (EA-1) | paso 1c con `Directory.Packages.props` (se esperan 3 → 0); paso 8 con las plantillas sin los locks de npm y uv (`[n/a]`, VERDE: el límite declarado); paso 9b con el workflow renombrado (rc=1) y con `WORKFLOW_FILE` (digest) | `x1-ea1-propuesto/verificar.diff` | `salidas/EA-1-plantillas.txt` igual a `x1-ea1-propuesto/salida.txt` salvo el commit y el hash de la DLL, que se copian al extracto de A.17 desde la corrida que se versiona (como AJ-1 del ciclo 2) |
| L-02 | `N5-entornos-en-contenedores/e8-capa4-y-artefacto/` (nuevo: `experimento.sh`, `build-en.sh`, `proy/`) y `salidas/E5-8-capa4-y-artefacto.txt`; fila en el README de N5 | E5-8 | `x5-e5-8-capa4/` (copia del experimento 02 del abogado, con encabezados de laboratorio) | `bash e8-capa4-y-artefacto/experimento.sh > salidas/E5-8-capa4-y-artefacto.txt`: tres líneas `dll 9815b804e89acc33 pdb 39c56299b47eef9f` y el control `7cd2a836de83b37e` (`x5-e5-8-capa4/salida.txt`) |
| L-03 | `N2-politica-de-texto-y-remediacion/e6-plantillas-dotnet/run.sh` | se agrega al final el bloque de `x2-e2-6-ampliado/bloque-e6.sh` (con BOM antes; plantillas de ítem; `dotnet format` sobre un `.razor` sin BOM) | `x2-e2-6-ampliado/run.diff` | `correr-todo.sh` de N2 → `salidas/e6-plantillas-dotnet.txt` = la versionada más los 14 renglones por SDK de `x2-e2-6-ampliado/salida.txt` (el `diff` sólo agrega líneas) |
| L-03b | `N2-…/README.md`, fila E2-6 | «…el `.slnx` y el `.csproj` se respetan» → «…sin BOM, el `.slnx` y el `.csproj` se respetan; con BOM, el `.csproj` lo conserva y el `.slnx` (SDK 10) lo pierde; las plantillas de ítem crean con BOM y `dotnet format whitespace` no se lo repone a un `.razor`» | C3-16 | el README nombra lo que muestra la salida |
| L-04 | `N1-codificacion-y-finales-de-linea/e1-shebang-node.mjs` (nuevo) y `salidas/e1-shebang-node.txt`; una línea en `correr-todo.sh`: `run node:24-bookworm-slim node e1-shebang-node.mjs > "$S/e1-shebang-node.txt" 2>&1` | caso `spawnSync` de E1-11 | `x3-shebang-node/` | `con-bom.sh`: `"status":0`, `not found` en stderr; `crlf.sh`: `ENOENT` |
| L-05 | `N4-congelamiento-de-dependencias/README.md` l.46 y `e2-nuget-cpm-pinning/run.sh` l.42 | «resuelve la siguiente sin advertir» → «resuelve la siguiente con `NU1603`; con lock, sin aviso»; «la línea comentada de A.4» → «la línea de A.4». Las salidas versionadas no se regeneran: el README declara «las salidas conservan el rótulo anterior; el resultado no cambia» | C3-32 (costo-beneficio: declarar) | `grep -c 'sin advertir' README.md` → 0 |
| L-06 | `N7-compuertas-y-gobierno/compuerta/ci-compuerta.yml` l.1 y `README.md` l.20 | l.1: `# Ejemplo de N7 (no lo lee A.17, que busca .github/workflows/ci.yml): la CI como árbitro.`; README, fila del hook: «…con el layout de N7 (`tools/compuerta.sh`); en el de A.11 es `tools/ci/`» | C3-09, C3-39 | los README nombran sólo archivos que existen |
| L-07 | `Examples/README.md` | sección «Ampliaciones del ciclo 3 (2026-10-09)»: E5-8, E1-11 con Node, E2-6 ampliado, pasos 1c, 8 y 9b de EA-1 | — | nombra sólo archivos que existen |

N8 no se toca (desarrollador-06: cambiar su imagen mueve el digest y obliga a regenerar E8-3, E8-5 y E8-6); la guía describe la diferencia (P-13).

## 6. Evidencia nueva del auditor (`evidencia-auditor/`)

### 6.1 Experimentos

| ID | Carpeta | Qué prueba | Resultado |
|---|---|---|---|
| X1 | `x1-ea1-propuesto/` | Todo el laboratorio propuesto de L-01/L-01b, junto (C3-09, C3-11, C3-12, C3-17, C3-18, C3-22, C3-26, C3-44) | EA-1 rc=0: paso 1c `3 violación(es)` → `0`; paso 6 con `sdk:8.0.425-bookworm-slim@ec9c0a0d…`: `dotnet 8.0.425`, glibc 2.36; paso 8 «sin su lock» `[n/a]` npm y uv, VERDE; paso 9 registro completo (DLL `fa6a50ec…`, antes `d6cc63cb…` por el `AssemblyMetadata` quitado); 9b `registro: no existe .github/workflows/ci.yml`, rc=1, y con `WORKFLOW_FILE` el digest; paso 10 `"outcome":"success"` |
| X2 | `x2-e2-6-ampliado/` | E2-6 con BOM antes y plantillas de ítem, SDK 8.0.425 y 10.0.400 por los digests de N2 (C3-16) | `.csproj` conserva el BOM; `s.slnx con BOM → sin BOM` (SDK 10); `Items/Clase.cs`, `IFace.cs` y `Comp.razor` con BOM; tras `dotnet format whitespace`, `Comp.razor sin BOM`. La salida previa no cambia: el `diff` sólo agrega |
| X3 | `x3-shebang-node/` | `spawnSync` de Node con los scripts de E1-11 (C3-37) | Node 24.21.0: `sin-bom.sh` status 0; `con-bom.sh` status 0 y `﻿#!/bin/sh: not found`; `crlf.sh` `ENOENT` |
| X4 | `x4-guardian/` | el guardián nuevo de §5.2.6 paso 5, pegado en un `bash --norc -i` (C3-25) | árbol sucio: el aviso y `la terminal sigue abierta`; árbol limpio sin remoto: `git pull` falla y no corre lo que sigue |
| X5 | `x5-e5-8-capa4/` | E5-8 re-corrido como experimento de laboratorio (C3-01, C3-03); `imagetools inspect` del SDK fijo y del digest de A.10 (C3-10, C3-11) | las tres bases con SDK 8.0.425: `dll 9815b804e89acc33 pdb 39c56299b47eef9f`; control SDK 10.0.400: `7cd2a836de83b37e`, igual que el abogado. `sdk:8.0.425-bookworm-slim` → índice `ec9c0a0d…` (amd64 `e1d5584f…`, arm/v7 `48cc58e9…`, arm64 `c1730b12…`); `78235e09…` es índice de tres plataformas |
| X6 | `x6-codeowners/` | `owners.py` de AH-002 sobre el CODEOWNERS propuesto (C3-26; condición de riesgo) | `Directory.Build.*`, `nuget.config`, `.npmrc`, `pyproject.toml`, los tres locks, `.nvmrc` y `.python-version` → `@org/arquitectura`; `.githooks/`, `.pre-commit-config.yaml`, `imagen/` → `@org/plataforma`; `package.json` y el código, `@org/desarrollo` |
| X7 | `x7-fechas/` | fecha de modificación de las 85 salidas (C3-34; condición de riesgo: no estimar) | 46 del 2026-10-07 y 39 del 2026-10-09; la lista coincide con `Ciclo-1/05-Aplicacion.md` L18 y `Ciclo-2/05-Aplicacion.md` §4.2, más E2-1, E2-3 a E2-6 y E7-6, que regeneraron los `correr-todo.sh` de N2 y N7 |
| — | `simulacion/` | P-01…P-23 aplicados a una copia de la guía | 0 anclas fallidas; `guia-parcheada.md`, `deltas.json`, `gen-salida.txt`, `anexoA-salida.txt` (TODO IGUAL), `yaml-salida.txt` (7 bloques YAML válidos; §12 con 11 validaciones) |

### 6.2 Fuentes consultadas el 2026-10-09 (filas B218–B224 de P-16)

| Fuente | Frase verificada |
|---|---|
| B218 GitHub Docs, retención (organización) | «By default, checks, workflow runs, commit statuses, and the artifacts and log files generated by workflows are retained for 90 days before they are automatically deleted.»; «For private repositories: you can change this retention period to anywhere between 1 day or 400 days.» |
| B219 Python, Using Python on Windows | «A `python3` command is also included that mimics the `python` command. It is intended to catch accidental uses of the typical POSIX command on Windows, but is not meant to be widely used or recommended.»; «For all scenarios involving multiple runtime versions, the recommended command is `py`.» |
| B220 Python, `os` · Python UTF-8 Mode | «`open()`, `io.open()`, and `codecs.open()` use the UTF-8 encoding by default. However, they still use the strict error handler by default…»; «Changed in version 3.15: Python UTF-8 mode is now enabled by default (PEP 686).» |
| B221 GitHub CLI, `gh attestation verify` | `--signer-workflow`: «Enforce that the workflow that signed the attestation matches the provided value»; «if your attestation was generated via a reusable workflow… you must use either the `--signer-workflow` or the `--signer-repo` flag»; `--source-ref`: «Enforce that the git ref associated with the source repository matches the provided value» |
| B222 `.editorconfig` de `dotnet/aspnetcore` y `dotnet/aspire` (rama `main`) | `[*.{razor,cshtml}]` / `charset = utf-8-bom` y `[*]` / `charset = utf-8` en los dos |
| B223 astral-sh/uv, release 0.13.0 | publicada 2026-10-09T19:49:55Z; «The default stable Python version has changed from 3.14 to 3.15.» |
| B224 .NET `releases-index.json` | `8.0`: `eol-date` 2026-11-10, `latest-sdk` 8.0.425; `10.0`: `latest-sdk` 10.0.401 (`evidencia-abogado-del-diablo/03-sdk8-eol/dl/releases-index.json` y voto del juez de evidencia) |

También se re-consultó [B56] (Microsoft Learn, `global.json`, 2026-10-09): «In CI (continuous integration) scenarios, however, you typically want to specify an acceptable range for the SDK version»; «When you use package lock files, set `rollForward` to `disable`»; `paths` y `errorMessage`: «Available since: .NET 10 SDK», con el ejemplo `"paths": [ ".dotnet", "$host$" ]`. Y npm v12 (`docs.npmjs.com/cli/v12/…`, 2026-10-09): las tres páginas de B63, B64 y B150 existen (HTTP 200) y `package-json` mantiene «advisory only» para `engines` y `onFail` «if left undefined is of the same value as `error`».

## 7. Cobertura: hallazgo → parche

| Hallazgo | Parches |
|---|---|
| C3-01 | P-01, P-08, P-17, P-24 (O-1, O-9), P-25 (L-02) |
| C3-02 | P-08, P-12, P-13, P-24 (O-1) |
| C3-03 | P-08, P-09, P-12, P-24 (O-1) |
| C3-04 | P-12 |
| C3-05 | P-08, P-09, P-12, P-13, P-16, P-18, P-24 (O-1) |
| C3-06 | P-08, P-09, P-10, P-11, P-14 |
| C3-07 | P-08, P-12, P-24 (O-1) |
| C3-08 | P-13 |
| C3-09 | P-13, P-25 (L-01, L-01b, L-06) |
| C3-10 | P-08, P-24 (O-1, O-11) |
| C3-11 | P-10, P-13, P-24 (O-1), P-25 (L-01) |
| C3-12 | P-09, P-13, P-24 (O-4, O-10), P-25 (L-01) |
| C3-13 | P-06, P-10, P-18, P-24 (O-8) |
| C3-14 | P-12, P-24 (O-8) |
| C3-15 | P-06, P-10, P-24 (O-8) |
| C3-16 | P-05, P-11, P-13, P-16, P-17, P-24 (O-3), P-25 (L-01, L-03, L-03b) |
| C3-17 | P-13, P-24 (O-3), P-25 (L-01, L-01b) |
| C3-18 | P-10, P-11, P-24 (O-2), P-25 (L-01b) |
| C3-19 | P-10, P-13, P-24 (O-2) |
| C3-20 | P-05, P-12 |
| C3-21 | P-13, P-14, P-16 |
| C3-22 | P-11, P-13, P-24 (O-2, O-5), P-25 (L-01) |
| C3-23 | P-08 |
| C3-24 | P-07, P-24 (O-7) |
| C3-25 | P-05 |
| C3-26 | P-10, P-13, P-24 (O-2), P-25 (L-01) |
| C3-27 | P-09, P-16, P-24 (O-4) |
| C3-28 | P-11, P-24 (O-5) |
| C3-29 | P-12 |
| C3-30 | P-03, P-09 |
| C3-31 | P-04, P-24 (O-6) |
| C3-32 | P-24 (O-7), P-25 (L-05) |
| C3-33 | P-04, P-16, P-24 (O-6) |
| C3-34 | P-01, P-17 |
| C3-35 | P-01, P-03, P-07, P-08, P-20, P-21, P-22, P-23 |
| C3-36 | P-18 |
| C3-37 | P-04, P-17, P-24 (O-6), P-25 (L-04) |
| C3-38 | P-16, P-18 |
| C3-39 | P-13, P-25 (L-06) |
| C3-40 | P-01, P-10 |
| C3-41 | P-01 (fila de la ruta mínima; la Práctica no entra, §1.2) |
| C3-42 | P-08, P-11 |
| C3-43 | P-15 |
| C3-44 | P-13, P-25 (L-01) |
| C3-45 | P-16, P-18 |
| C3-46 | P-02 |
| C3-47 | P-13 |
| C3-48 | P-11 |
| C3-49 | P-06, P-24 (O-8) |
| C3-50 | P-16 |
| C3-51 | P-09 |
| C3-52 | P-11, P-24 (O-5) |
| C3-53 | P-04, P-24 (O-6) |

## 8. Chequeos de la guía parcheada y lo que no se aplica

**Chequeos** (`checks.py` y `anexoA.py` del ciclo 2 sobre `simulacion/guia-parcheada.md`, con `Examples/` enlazado al lado):

- 183 encabezados, 183 anclas, 92 enlaces internos, **0 rotos** (incluido el nuevo `#821-qué-fija-un-contenedor-y-qué-no` de §3.5); índice en orden; rutas `Examples/…` citadas inexistentes: 0. El único relativo inexistente es `../Despliegue/`, que ya estaba en 1.0.0.
- `[Bnn]`: 224 definidas, 224 citadas, 0 sin definir, 0 sin citar.
- IDs de experimento en el cuerpo: 72, todos con fila; filas del Anexo E: 66 (con E5-8), que se expanden a los 74 que declara la apertura.
- 11 bloques mermaid; 7 bloques YAML válidos (`yaml.safe_load`); el contrato de §12 conserva sus 11 validaciones.
- Anexo A contra `x1-ea1-propuesto/repo/`: 22 de 22 bloques iguales byte a byte.
- `grep` sobre la guía parcheada: `ImagenDigest` 0; `(requiere Windows)` detrás de una marca 0; `npm y pip` 0; «reconstrucción bit a bit» como motivo de la imagen propia 0; `verificar.sh` sólo en §0.4, §10.2.2, §11.2.3, §11.5, Anexo A y Anexo E (N8 y EA-1).

**Lo que no se aplica, por decisión:**

- C3-02 (b), archivar el log «Set up job» o `/etc/environment` junto al artefacto: sin contrato documentado (`Ciclo-2/03-Parches.md` §9), y la mayoría votó (a).
- C3-02 (c), reservar 8a a la imagen propia: reabre C2-13 sin E1 (coherencia).
- C3-15, la tabla de ocho repos `dotnet/*`: no se re-corrió y no hace falta para el rótulo (evidencia).
- C3-18 (a), rojo ante un manifiesto sin lock: reabre `Ciclo-2/03-Parches.md` §9 (coherencia, riesgo).
- C3-41, la Práctica nueva de §3: +85 palabras de prosa contra el saldo de C3-35 (§2).
- Cambiar la imagen de N8 (C3-47): la guía describe la diferencia.

**Condiciones que el auditor deja para la aplicación:**

- Volver a correr EA-1 **una sola vez**, después de L-01 y L-01b (coherencia, riesgo), y copiar al extracto de A.17 el commit y el hash de la DLL de esa corrida.
- E5-8, E2-6 y E1-11 (Node) se corren y versionan antes de aplicar P-08, P-05 y P-04, que los citan («evidencia antes de declarar cerrado»).
- El saldo de prosa (+493) va a la mesa de aprobación con la propuesta del editor de cierre (§2).

## 9. Supuestos registrados

- La fecha de trabajo es la del sistema, 2026-10-09, la misma del consolidado y de los votos.
- Versión de la guía después de aplicar: **1.1.0** **[criterio]**: además de correcciones, agrega un experimento (E5-8), siete fuentes y una fila de la ruta mínima; no es sólo un parche de erratas.
- «Lo nativo» (addons de Node, ruedas con extensiones C, *self-contained*, R2R, AOT) queda como **[interpretación]**: ni el abogado ni el auditor lo midieron (C3-Q05).
- El digest nuevo de A.10 (`ec9c0a0d…`) es el que la etiqueta fija `8.0.425-bookworm-slim` tenía el 2026-10-09; si el registro la rehace antes de aplicar, EA-1 lo muestra (paso 6) y el PR lleva el digest de ese día.
- La receta de Windows (C3-21) sigue **[no verificado]**: no hay host Windows (C3-Q01, C3-Q10).
- No se tocó el prompt del PO, ni la guía, ni `Examples/`: todo lo propuesto vive en `Ciclo-3/evidencia-auditor/`. No se hizo `git commit` ni `push`.

## Revisión 2 · P-01 y P-19 (respuesta a los `04-Aprobacion-*.md`)

> Fecha: 2026-10-09. Rol: cuerpo auditor, segunda vuelta (marco §5.5, `MEJORAR_PLAN`). Esta sección **reemplaza** a P-01 y P-19 de §3; el resto del lote no cambia por ella. Las anclas son literales de la guía 1.0.0 (sha256 `a2b78179…`), salvo en P-19, que se aplica sobre la fila que deja P-19 de la revisión 1 en la misma corrida.
> Prueba: [`evidencia-auditor/r2-p01-p19/r2.py`](evidencia-auditor/r2-p01-p19/r2.py) aplica estas ops a una copia de `simulacion/guia-parcheada.md` (que ya trae P-01…P-23 de la revisión 1): todas las anclas aparecen 1 vez y la copia resultante (sha256 `eb7d1673…`) tiene 55 279 palabras, +38 sobre 55 241. El listado de marcas sin motivo está en [`marcas-sin-motivo.txt`](evidencia-auditor/r2-p01-p19/marcas-sin-motivo.txt).

### Objeciones atendidas

| Parche | Juez | Objeción | Cómo se atiende |
|---|---|---|---|
| P-01 | riesgo, coherencia histórica, impacto | La op 9 («sin motivo escrito, **[no verificado]** quiere decir "requiere Windows"») vuelve falso el motivo de marcas sin motivo que no tratan de Windows: L539, L1031 (dos celdas), L1411, L1482, L1698 y L1953 de 1.0.0 (L1027 y L1953 de la simulación). El chequeo de P-23 cuenta la glosa, no el sentido. | Se queda la regla, que votaron coherencia e impacto y que el riesgo admite si se clasifican todas las marcas. Las ops 10 a 15 le escriben el motivo a las siete marcas en el mismo parche, y la verificación pasa a ser el listado clasificado de **todas** las marcas sin motivo. Con P-01 aplicado así, P-23 queda como está y su defecto desaparece, porque cuando corre ya no hay ninguna marca ajena a Windows sin su motivo. |
| P-01 | impacto (P-16), evidencia (P-16) | Las cifras «224» y «B194–B224» dependen de cómo entre P-16. | Las ops 2 y 5 llevan una regla de arrastre explícita (abajo). |
| P-19 | evidencia, coherencia histórica, impacto | El párrafo 1.1.0 anuncia una «Práctica de §3» que no entra (§1.2 y §8 la dejan fuera, por C3-41). | Pasa a decir «fila §3 en la ruta mínima». |
| P-19 | coherencia histórica | La compresión del párrafo 1.0.0-rc.1 borra «fija cuatro marcas de juicio (§0.3)», que es un hecho histórico, y la regla nueva de P-01 se apoya justamente en ese vocabulario cerrado. | Se conserva, como «cuatro marcas de juicio (§0.3)». |
| P-19 | riesgo (condición) | Si P-01 o P-23 vuelven reformulados, la fila 1.1.0 tiene que describirlos tal como entren. | El párrafo 1.1.0 nombra el cambio de convención de §0.3: «motivo por defecto de **[no verificado]**». |

### P-01 · Encabezado, apertura y §0 (revisión 2)

- **Hallazgos**: C3-34, C3-35, C3-40, C3-41, C3-01; objeciones J-I1 (impacto), §2 (riesgo), §2.1 (coherencia histórica).
- **Sección**: front matter L5, L14; L24, L26; §0.2 L65, L72–L82; §0.3 L89, L92, L96; §4 L539; §6.2.5 L1031; §8 L1411, L1482; §9 L1698; §10 L1953.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa +52 (+28 de la revisión 1, +24 de las ops 9 a 15), evidencia y plantillas +1.
- **Ops 1 a 8**: **sin cambios** respecto de §3 (versión 1.1.0, fechas, cifras, §0.2, fila §3/E0-6, fila E4-2). Ningún juez las objetó.
- **Arrastre de P-16 sobre las ops 2 y 5**: el texto que aplica es el de §3 («B194–B224», «224 fuentes») si P-16 entra con 224 filas en el Anexo D. Es lo que da el remedio del juez de evidencia, en el que B224 pasa a ser NETSDK1238 y la reconsulta del índice va a B62. Si P-16 entra sin B224 (remedio del juez de impacto), las ops 2 y 5 dicen «B194–B223» y «223 fuentes». Lo decide el conteo de `checks.py` sobre la guía real, después de P-16 y antes de P-01 (orden C-3 del juez de costo-beneficio), y no esta sección.
- **Verificación**:
  1. Las de §3: `version:` igual a la fila 1.1.0; cifra de fuentes igual a las filas `| Bnn |` del Anexo D (`checks.py`); «74 experimentos» igual a los IDs del Anexo E expandidos; `grep -c 'las ampliaciones de la revisión'` → 0; la ruta mínima tiene fila §3.
  2. **Nueva**: después de P-23, se listan todas las `**[no verificado]**` que no tienen detrás un paréntesis de motivo (un paréntesis que empieza con `§` es una remisión, no un motivo, y cuenta como «sin motivo»). Cada una tiene que caer en una de dos clases. (a) Metatexto: la definición de §0.3, la regla de §0.3 y el párrafo 1.1.0 del control de cambios. (b) Contexto de Windows, Visual Studio, Git Bash o ESC-01. Ninguna puede caer fuera de las dos. En la simulación (E1, 2026-10-09, `marcas-sin-motivo.txt`) son 20: 3 de la clase (a) y 17 de la (b) (L113, L385, L483, L498, L530, L690, L713, L812, L832, L1046, L1056, L1119, L1243, L2000, L2333, L2868, L2870 de la copia); fuera de clase, 0. Antes de las ops 10 a 15 quedaban 7 fuera de clase.

9. Reemplazar

~~~~text
El motivo o el matiz va fuera del corchete: **[no verificado]** (requiere Windows), **[criterio]** (sobre la base del fabricante).
~~~~

por

~~~~text
El motivo o el matiz va fuera del corchete: **[no verificado]** (requiere una plataforma alojada), **[criterio]** (sobre la base del fabricante). Sin motivo escrito, **[no verificado]** quiere decir «requiere Windows» (§0.4); todo otro motivo se escribe.
~~~~

10. Reemplazar (§4, tabla de BOM)

~~~~text
que recomiende o desaconseje el BOM en `.cs` **[no verificado]**.
~~~~

por

~~~~text
que recomiende o desaconseje el BOM en `.cs` **[no verificado]** (sin documento del fabricante).
~~~~

11. Reemplazar (§6.2.5, fila asdf, columnas «Windows nativo» y «¿Hace cumplir?»)

~~~~text
[B80] | **[no verificado]** | **[no verificado]** |
~~~~

por

~~~~text
[B80] | **[no verificado]** (no ejercitado) | **[no verificado]** (no ejercitado) |
~~~~

12. Reemplazar (§8, Renovate y el `container:`)

~~~~text
pero que mueva su digest **[no verificado]**:
~~~~

por

~~~~text
pero que mueva su digest **[no verificado]** (requiere la plataforma):
~~~~

13. Reemplazar (§8, fila «Transversal»: «(§8.2.2)» es una remisión, no un motivo)

~~~~text
y no GitHub [B107] **[no verificado]** (§8.2.2)
~~~~

por

~~~~text
y no GitHub [B107] **[no verificado]** (requiere la plataforma; §8.2.2)
~~~~

14. Reemplazar (§9, cosign sin clave)

~~~~text
No se ejercitó **[no verificado]**.
~~~~

por

~~~~text
**[no verificado]** (no ejercitado en el laboratorio).
~~~~

15. Reemplazar (§10, Dependabot y gestores nuevos)

~~~~text
cómo se comporta con las más nuevas **[no verificado]**.
~~~~

por

~~~~text
cómo se comporta con las más nuevas **[no verificado]** (requiere la plataforma).
~~~~

Notas de la revisión 2:

- Las siete anclas de las ops 10 a 15 aparecen una vez en la guía 1.0.0 y una vez en la simulación (`grep -cF`, E1 2026-10-09). Ningún parche de P-02 a P-22 las modifica, así que el orden de aplicación no las afecta. Ninguno de los textos nuevos contiene `**[no verificado]** (requiere Windows)`, de modo que el conteo de P-23 (8 → 0) no cambia.
- Los motivos usan formas que la guía ya emplea: «(requiere la plataforma)» (L1401 y L2978 de la simulación) y «(no ejercitado en el laboratorio)» (L2191). Para asdf se eligió «(no ejercitado)» y no «(no documentado)», que proponía coherencia histórica, porque no se consultó la documentación de asdf sobre Windows. Afirmar que no lo documenta sería otra afirmación sin evidencia. **[criterio]**
- En L1698, la oración «No se ejercitó» y el motivo decían lo mismo dos veces. La op 14 deja una sola mención, la que va en el lugar que fija §0.3.
- No se adopta la alternativa del juez de riesgo de volver a la regla de 1.0.0. La regla por defecto es la que habilita el ahorro de P-23 (votado por costo-beneficio y evidencia), y con las ops 10 a 15 ya no puede producir un motivo falso.

### P-19 · Control de cambios: fila 1.1.0 (revisión 2)

- **Hallazgos**: C3-01…C3-53; objeciones J-I7 (impacto), P-19 (evidencia), §2.3 (coherencia histórica), condición de P-19 (riesgo).
- **Sección**: Control de cambios, al final.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras** (`wc -w`): prosa 0 (−14 de la revisión 1, +5 de la op 2, +9 de la op 3), evidencia y plantillas +1.
- **Verificación**: la fila 1.1.0 coincide con `version:`; la celda tiene ≤ 21 palabras (criterio del ciclo 2); `grep -c 'Práctica de §3'` → 0; `grep -c 'cuatro marcas de juicio (§0.3)'` → 1. Cada ítem del párrafo 1.1.0 tiene un parche aplicado que lo produce (tabla §7): «fila §3 en la ruta mínima», P-01 op 7; «motivo por defecto de **[no verificado]**», P-01 op 9 y P-23; «§3.5 comprimida», P-03. El rango «B218–B224» sigue el mismo arrastre de P-16 que P-01 («B218–B223» si P-16 entra sin B224).
- **Op 1**: sin cambios respecto de §3.
- **Op 2 (rc.1)**: la misma de §3, pero el texto nuevo termina en «…, B194–B204, E2-7, E2-8; cuatro marcas de juicio (§0.3).» Texto completo:

~~~~text
**1.0.0-rc.1.** *Fallback* de Roslyn, BOM de .NET, migración con *squash*, costo de `disable`, `NU1603` con lock, digest y bot, SLSA sin `builder.id`, ramas protegidas, frontera políglota; ruta mínima, Prácticas, mapa, glosario, trazas, B194–B204, E2-7, E2-8; cuatro marcas de juicio (§0.3).
~~~~

- **Op 3 (1.0.0 y 1.1.0)**: el párrafo **1.0.0** queda como en §3. El párrafo **1.1.0** pasa a ser:

~~~~text
**1.1.0.** Qué decide cada capa sobre el artefacto (E5-8), aplicado en todo el texto; `CheckSdkVulnerabilities`, BOM de `.slnx` y `.razor`, Python 3.15 con cp1252, digest de índice, registro y dueños de la compuerta, `gh attestation verify`; §3.5 comprimida, fila §3 en la ruta mínima, motivo por defecto de **[no verificado]**, B218–B224.
~~~~

Notas de la revisión 2:

- No se restauran otros ítems que la revisión 1 resumió en el párrafo 1.0.0 («sus prerrequisitos», «extractos literales»). Ningún juez los objetó, y el de impacto dejó escrito que los dos párrafos comprimidos conservan la información. Se restaura sólo lo que coherencia histórica pidió por ser un hecho del que depende otra regla.
- El párrafo 1.1.0 no dice que la versión comprime. Así respeta la condición de coherencia histórica (§4, «lo que la guía no puede afirmar al cerrar»): el saldo de prosa del lote sigue siendo positivo.

### Efecto sobre el balance (§2)

| Parche | Prosa, revisión 1 | Prosa, revisión 2 | Diferencia |
|---|---|---|---|
| P-01 | +28 | +52 | +24 |
| P-19 | −14 | 0 | +14 |

El saldo del lote sube en +38 palabras de prosa, medidas con `wc -w` sobre la copia (55 241 → 55 279). Los otros parches en `MEJORAR_PLAN` suman su propio Δ. La decisión sobre el saldo total sigue en manos de la mesa (C2-36; voto de coherencia histórica §2.5).
