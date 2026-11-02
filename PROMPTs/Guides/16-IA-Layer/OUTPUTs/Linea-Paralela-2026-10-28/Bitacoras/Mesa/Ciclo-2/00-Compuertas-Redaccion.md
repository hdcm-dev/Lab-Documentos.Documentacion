---
doc_id: BIT-16-C2-COMP
doc_type: registro-de-compuertas
title: Compuertas de la redacción de la guía 16 (REED-16 §9.1, 06-Plan §7 y §10.5)
status: vigente
origin: agent
owner: fase de compuertas de la redacción (ciclo 2)
last_review: 2026-10-28
audience: [presidencia, redacción, relectura integral]
traces: [Crear-IA-Layer-Guide-Reedicion.md (REED-16) §9.1; Mesa/Ciclo-1/06-Plan-De-Redaccion.md §6, §7, §10.3–§10.5; Mesa/Ciclo-1/07-Dictamen-Presidencia.md §2, §5; Mesa/Ciclo-2/trazabilidad.md; Mesa/Ciclo-2/matriz-snippets.md; 04-Integracion.md §2]
---

# Compuertas de la redacción (2026-10-28)

Corrida de las compuertas de REED-16 §9.1 y del plan §7 y §10.5 sobre la guía, `Examples/` y `Demos/`, con las correcciones hechas en la capa donde nació cada falla. Cuando un snippet no coincidía con el código, mandó el código compilado. Sin commit.

- **Guía:** `Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Dot-Net-Integration-AI-Layer-Guide.md` (en adelante, «la raíz»).
- **sha256 antes:** `99e62a78534442e992b518bf1a9a50a6f8f5158c6aba5343a2434975b3885cf4` (60 419 palabras, 4107 líneas).
- **sha256 después:** `dcba317763c72d66686264f9e0189c387a84139f96592377a01d9089bb730325` (60 629 palabras, 4113 líneas).
- **Imagen de compilación:** `mcr.microsoft.com/dotnet/sdk:10.0` = `sha256:de4fe90a98845d75910b9769662465c84de1a934665c431279d1382b2bddc02b` (SDK 10.0.403).
- **Turnos:** recurso `build`, dueño `compuertas-redaccion`, dos turnos (corrida 1 con la caché NuGet de la corrida; corrida final con un volumen NuGet nuevo y vacío, borrado al terminar). Ninguna corrida contra el modelo: la fase no la pedía y no se pidió ningún recurso de modelo.
- **Evidencia:** `Mesa/Ciclo-2/evidencia-compuertas/` (salidas antes y después, scripts, bloques Mermaid extraídos y salidas de `dotnet`). La lista privada de R-PRIV vive fuera de la raíz y fuera de `OUTPUTs/`, y no se copió.

## Índice

- [1. Tabla de compuertas](#1-tabla-de-compuertas)
- [2. Comandos](#2-comandos)
- [3. Detalle por compuerta](#3-detalle-por-compuerta)
- [4. Correcciones (changelog)](#4-correcciones-changelog)
- [5. Lo que no se pudo cerrar](#5-lo-que-no-se-pudo-cerrar)

## 1. Tabla de compuertas

| Compuerta | Criterio | Antes | Después | Estado |
|---|---|---|---|---|
| C1 contradicciones | 0, lectura guiada por las tensiones 1–8 de BIT-16-04 §2 y por §10 del plan | 0 contradicciones con las tensiones; 2 fracciones sin estimando (RV-17); 4 menciones de `/v1` sin remitir a la tabla (RV-22) | 0 | cerrada |
| C2 trazabilidad | toda S-, §7.n y PR con sección; `grep '\[C:'` = 0 | 0 marcas; PR-16 sin el comentario en el código de `06`, `07` y `08` | 0 marcas; 56 filas de origen con sección o con estado de proceso | cerrada |
| C3 trazabilidad inversa | 0 secciones huérfanas | 0 (§0–§9 y Anexos A–F, cada una con origen en `trazabilidad.md` §6) | 0 | cerrada |
| C4 huérfanos | 0 enlaces rotos; todo directorio de `Examples/` y `Demos/` citado; toda cita existe | 194 enlaces, 0 rotos; 13 de 13 carpetas citadas; 214 rutas citadas, 0 inexistentes; 1 rango de líneas fuera del archivo (§5.8) | 194 / 0; 13 / 13; 214 / 0; 0 rangos fuera | cerrada |
| C5 glosario | un sentido por término; 0 formas excluidas; «agente» y «workflow» junto a un tipo de MAF con «de MAF» | 17 apariciones sin calificativo junto a `AIAgent`/`WorkflowBuilder`/`AsAIAgent`, 8 de ellas en el sentido de MAF; 15 usos de «contexto» en el sentido excluido; 3 «*Contexto:*» en el Anexo F | 0 en el sentido de MAF (las restantes nombran el concepto o el mecanismo: §7.1 y la fila «Workflow» de §7.2); 0 usos excluidos de «contexto» | cerrada, con una nota (§5) |
| Snippets = código (RV-18, RV-19) | cada bloque C# coincide con el archivo y el rango que cita; cada uno con `using` o «Compila en» | 66 bloques: 63 coinciden, 2 difieren, 1 con rango inexistente | 66 de 66 (54 por script, 12 a mano) | cerrada |
| Build y test | `dotnet build` + `Cableado/` de cada carpeta en `sdk:10.0`, n/n | 338/338, 0 advertencias, 0 errores; copia sola de la demo compila | 338/338 con la caché NuGet vacía al empezar | cerrada |
| Versiones (P-32) | `PackageReference` = Anexo D.2; nuget.org consultado hoy; 0 vulnerables ni deprecados | 29 filas = nuget.org; 3 paquetes de la copia sola fuera de la tabla y `Microsoft.EntityFrameworkCore.Sqlite` 10.0.11 distinto | 32 filas = nuget.org y = `.csproj`; 28 de 28 proyectos sin paquetes vulnerables ni deprecados | cerrada |
| Mermaid | 0 inválidos | 16 de 16 válidos (15 de la guía, 1 del README de la demo) | 16 de 16 | cerrada (era la que no se había podido correr en el ciclo 1) |
| R-PRIV v2 | `patrones=0 identificadores=0 cabeceras=0` sobre la raíz | 0 / 0 / 0 | 0 / 0 / 0 | cerrada |
| R-PRIV ampliado | 0 IPs del laboratorio, 0 rangos 100.x, 0 rutas del home, 0 `<clave-de-cabeceras>`, 0 nombres de equipos, contenedores, usuarios u otros proyectos; capturas revisadas a ojo | 0 (sólo loopback, `0.0.0.0` en pruebas de arranque y `192.0.2.10` de documentación); 5 capturas sin URL ni datos del laboratorio, sin metadatos de texto | igual | cerrada |
| R-PRIV v2 sobre `OUTPUTs/` | `patrones=0`, `cabeceras=0` siempre | `patrones=2` (dos rutas del home en scripts de evidencia de `01`) | `patrones=0 cabeceras=0`; `identificadores=651`, que no bloquea mientras no haya commit (dictamen §2) | cerrada |
| `.gitignore` (DC-08) | presente en cada carpeta y con `bin/`, `obj/`, `*.db` y las salidas generadas | 13 de 13 | 13 de 13 | cerrada |
| Árbol limpio | 0 `bin/`, `obj/`, `TestResults/`, `*.db` en la raíz | 0 | 0 (las compilaciones corrieron sobre copias fuera del workspace) | cerrada |
| Barridos §6 y §10.4 | 0 | 4 a corregir: «falla al arrancar» ×2 (frase correcta, pero literal), `RV-01` en `Examples/05`, «la mesa» en el Anexo D | 0 a corregir; quedan 4 coincidencias aceptadas (§3.9) | cerrada |
| RD-PO-4 dominios ajenos | 0 | 0 («reclamo», `Movie`, «pozo», «semáforo roto», nombres de otros proyectos) | 0 | cerrada |
| Ids de bitácora | 0 en la guía | 0 en la guía; 26 en comentarios de `Examples/` y `Demos/` (`R-LLM-3b`, `R-LLM-3c`, `R-LLM-3e`, `R-LLM-4`, `RV-01`) | 0 en la guía, `Examples/` y `Demos/` | cerrada |
| RV-12 literales | endpoint y modelo sólo en `OpcionesDeIA` y `appsettings` | 0 fuera de opciones (los demás son las pruebas del barrido) | igual | cerrada |
| R-LLM | `grep -L "modelo@"` = 0 y `grep -L "estimando:"` = 0 sobre las salidas | ninguna salida contra el modelo vive en `Examples/` ni en `Demos/`; sobre `evidencia-examples/` y `evidencia-demo/`, 9 archivos sin la cabecera en el mismo archivo | sin cambios | abierta en parte (§5) |
| Validación del núcleo (P2-15) | `^## Validación del núcleo` = 1 por registro | 9 de 9 | 9 de 9 | cerrada |
| Clon limpio (P-10) | carpeta nueva fuera del workspace, sin caché NuGet, cada README tal cual | build y `Cableado/` con caché vacía (equivale a la parte sin modelo) | igual | abierta en parte (§5) |
| Presupuesto (P-07) | ±20 % por sección | 8 de 11 fuera (total 60 163 frente a 40 200) | sin cambios | abierta (§5) |

## 2. Comandos

Rutas relativas a `Bitacoras/Mesa/`; `<raíz>` es la carpeta de la guía. Los scripts están en `Ciclo-2/evidencia-compuertas/scripts/`.

| Compuerta | Comando |
|---|---|
| R-PRIV v2 | `RPRIV_LISTA=<lista privada, fuera de la raíz> RPRIV_SINTETICOS=Ciclo-1/Ronda-2/aplicacion/rpriv-sinteticos.txt Ciclo-1/Ronda-2/aplicacion/rpriv.sh <raíz> --detalle` |
| Barridos (§6, §10.4, RV, ids, RD-PO-4) | `scripts/barridos.sh <raíz>` |
| Enlaces y anclas | `python3 -I Ciclo-1/evidencia-verificacion-qa/G2-enlaces.py $(find . -name '*.md' -not -path '*/bin/*' -not -path '*/obj/*')` desde `<raíz>` |
| Citas y carpetas | `python3 -I scripts/citas.py <raíz>` |
| Snippets contra el código | `python3 -I scripts/snippets.py <raíz>` y, para los 12 bloques cuya referencia no sigue la forma «Compila en …», `python3 -I scripts/chk.py <raíz> "<línea>\|<archivo>\|<rango>"…` |
| Build y `Cableado/` | `<envoltorio-de-turnos> build compuertas-redaccion "<motivo>" 60 -- scripts/correr.sh` (corrida 1); `SALIDAS=salidas-final FUENTE=fuente-final NUGETVOL=<volumen nuevo> <envoltorio-de-turnos> build … -- scripts/correr2.sh` (corrida final, suma `dotnet list package --vulnerable --include-transitive` y `--deprecated`) |
| Versiones | `python3 -I scripts/nuget.py <paquete>@<versión>…` (índice de registro de nuget.org, 2026-10-28) |
| Mermaid | bloques extraídos a `.mmd` y `scripts/validar.mjs` en `mcr.microsoft.com/playwright:v1.62.1-noble` con `mermaid@11.12.0` y `playwright@1.62.1`: `mermaid.parse` y `mermaid.render` de cada bloque en Chromium |
| Presupuesto | conteo de palabras por `## N.` y por los anexos (script en línea, salida en §3.11) |

## 3. Detalle por compuerta

### 3.1 C1 contradicciones

Lectura cruzada contra las ocho tensiones de BIT-16-04 §2, con sus remisiones del ciclo 1 y la ronda 2, y contra las reglas de §10.1–§10.3 del plan.

| Tensión | Qué se buscó en la guía | Resultado |
|---|---|---|
| 1 vías A, B y C | la frase de la tensión 1 del plan §10.2 («buscó en 12 de 16 corridas», «8/8 en cada una»); «A por defecto» por diseño; la vía C «corrida sólo con un doble» | presentes; sin Wilson agrupado |
| 2 `IChatClient` frente a marco | escalera llamada única → agente mínimo → agente de MAF → workflow de MAF → multiagente; `AsAIAgent` sobre el mismo `IChatClient` | presente (§7.2, §7.4) |
| 3 ESC-01 por herramienta | `resultados_de_encuesta` → `ResultadosDeEncuestaService`, agregados sin `Nombre` ni `Edad` | presente (§9.5.2); la demo usa `ILecturaDeResultados` |
| 4 modelo | rótulo 2b/4b del plan §0.4, el 4b «provisional», el 2b con Q8_0, 2,68 GB y digest; el 35b-a3b no candidato; nunca «el 2b es más rápido» | presente; 0 «más rápido» |
| 5 LangGraph | «No hay LangGraph oficial para .NET»; «equivalentes en capacidades, no en modelo de programación»; snippet HTTP «no ejecutado» | presente (§7.10.2) |
| 6 controles | CTRL-01…CTRL-15 y la lista de CTX-PROD | presente (§8.3) |
| 7 copia literal | «el adaptador invoca al normalizador del núcleo y después al caso de uso; el catálogo normaliza y las reglas deciden»; «declarado, no aplicado por la API» | presente |
| 8 GA por defecto | Anexo D.2 sólo con GA; preview fuera del camino | presente |

Otras comprobaciones de esta compuerta: «falso aceptado» sólo en el sentido 1 y «no medido» (§3.7, §8.3.1, Anexo C); D-06 con el título de P2-05 en el Anexo F; D-11 con `AccionPropuesta(tipo, datos)` y sin aprobación pendiente; RV-20 («no es control de acceso», 7 apariciones); RV-16 (las cuatro apariciones de «93» son cifras de tabla o el ancla de §9.3, ninguna es aceleración por caché); los recuentos de pruebas que declaran la guía y los README (06: 23, 09: 37, 13: 13, demo: 69) coinciden con la corrida de hoy. RV-17: de 118 fracciones, dos en prosa no tenían estimando (§2.6.4 y Anexo B.1) y se corrigieron; las demás llevan estimando, intervalo o rótulo en la fila o en la cabecera de su tabla. RV-22: cuatro menciones de `num_ctx`, `top_k` o el tope de salida por `/v1` fuera de §5.7 no remitían a la tabla; ahora remiten.

### 3.2 C2 y C3

Cada fila de `trazabilidad.md` §1–§5 se comprobó contra la guía con una búsqueda de su marca (sección, encabezado o término). PR-16 pedía el principio «el modelo propone» en el código de `06`, `07` y `08` y faltaba en los tres: se agregó en el comentario de la clase de herramientas (06 y 07) y de la composición del servidor MCP (08), en la misma línea, sin correr números de línea citados. PR-18 está como 7.13.5 («¿Uso un marco o lo escribo yo?»). MD-1 (cliente móvil) queda «no ejecutada» en la trazabilidad; la guía registra el recorrido D1–D6 en Chromium con la emulación de un teléfono de 412 px (§9.8). `grep '\[C:'` = 0. Las preguntas guía numeradas suman 73: 68 en negrita en §1–§3 y §5–§9 (sin las 9 definiciones de §5.1) y 5 encabezados en §4.9.

### 3.3 C4 huérfanos

`G2-enlaces.py` sobre los 23 `.md` de la raíz: 194 enlaces relativos, 0 rotos (archivos y anclas). `citas.py`: las 13 carpetas (12 de `Examples/` y la demo) están citadas en la guía entre 4 y 26 veces; las 214 rutas entre comillas invertidas existen (la forma corta `Examples/NN` se resuelve por prefijo); los rangos de líneas verificables están dentro de su archivo. El único rango fuera de archivo era el de §5.8 (`HerramientasDeResultados.cs`, l. 34–36 en un archivo de 21 líneas), corregido con el snippet (§4).

### 3.4 C5 glosario

Anexo C: 47 entradas, una definición por término; la de *agente* es la de la consulta de definiciones, palabra por palabra; «Chunk» remite a «Fragmento». Se hicieron ocho reemplazos, en seis líneas, donde «agente» o «workflow» estaban junto a `AIAgent`, `WorkflowBuilder` o `AsAIAgent` sin «de MAF» (§5.8, §7.1, §7.7, §7.13.3, Anexo C). «Contexto» tiene en el glosario el sentido CTX-*; 15 usos en el sentido excluido («el texto que recibe el modelo») pasaron a «prompt», «pedido», «fragmentos» o «ventana de contexto», y el campo «*Contexto:*» del Anexo F pasó a «*Situación:*». Las formas excluidas («agentic workflow», «flujo agéntico», «flujo de trabajo») aparecen una sola vez: en la columna «Sentidos excluidos» de la entrada «Workflow», que es la declaración de la exclusión (ver §5).

### 3.5 Snippets contra el código

`snippets.py` asocia cada bloque C# con su «Compila en» (antes o después del bloque) y compara línea a línea, sin espacios, con el rango citado. 54 coinciden por script. Los otros 12 citan el archivo con otra forma («El registro, en …», «Antes, en …», dos rangos) y se compararon con `chk.py`: 12 de 12 después de las correcciones. Dos difirieron y se corrigieron en la guía, porque manda el código: §5.8 (la guía mostraba `ComoAIFunction` como «el mismo método, l. 34–36»; el método está en l. 12–16 y la función en l. 18–20) y §8.4.3 (la guía recortaba el comentario del criterio; ahora lo muestra igual que el archivo, con la expresión regular y `&gt;`). Los dos bloques `json` del Anexo A son iguales a `appsettings.json` y `appsettings.Development.json` de `Examples/01`.

### 3.6 Build y test

| Carpeta | Build | `Cableado/` |
|---|---|---|
| `01-Chat-Basico` | 0 advertencias, 0 errores | 18/18 |
| `02-Streaming` | 0 / 0 | 9/9 |
| `03-Salida-Estructurada` | 0 / 0 | 15/15 |
| `04-Embeddings-Y-Busqueda` | 0 / 0 | 13/13 |
| `05-RAG-En-Memoria` | 0 / 0 | 27/27 |
| `06-Tool-Calling` | 0 / 0 | 23/23 |
| `07-Agente-Con-Aprobacion` | 0 / 0 | 25/25 |
| `08-Servidor-Y-Cliente-MCP` | 0 / 0 | 44/44 |
| `09-Pruebas-Con-Cliente-Falso` | 0 / 0 | 37/37 |
| `10-Workflow` | 0 / 0 | 27/27 |
| `12-Anotaciones-Pareadas` | 0 / 0 | 18/18 |
| `13-Prueba-De-Arquitectura` | 0 / 0 | 13/13 |
| `Demos/MovilidadUrbana.Asistente` | 0 / 0 | 69/69 |
| `Demos/…/verificacion/CopiaSola` | 0 / 0 | — |
| **Total** | 14 de 14 | **338/338** |

Las dos corridas dieron lo mismo. La final corrió sobre una copia tomada después de todas las correcciones de código (`diff -rq` contra el árbol = 0) y con la caché NuGet vacía. `10-Workflow`, que en su construcción tuvo 4–5 pruebas rojas por corrida con `blockOnPendingRequest: false`, dio 27/27 en las dos. Salidas: `evidencia-compuertas/build-cableado-1/` y `build-cableado-final/`.

### 3.7 Versiones

Las 29 filas del Anexo D.2 coinciden hoy con nuget.org (versión, última estable, publicación, deprecación y vulnerabilidades: `evidencia-compuertas/nuget-2026-10-28.tsv`). `verificacion/CopiaSola/CopiaSola.csproj` compila lo copiado con los paquetes del origen (`Microsoft.EntityFrameworkCore.Sqlite` y `Microsoft.AspNetCore.OpenApi` 10.0.11, `Scalar.AspNetCore` 2.17.3), que la guía nombraba en prosa pero no en la tabla, y la tabla afirmaba «igual en todos los `.csproj`». Se sumaron las tres filas con sus datos de nuget.org (publicadas 2026-08-11, 2026-08-11 y 2026-09-07; últimas 10.0.14, 10.0.14 y 2.18.5; sin deprecación ni vulnerabilidades) y se acotó la frase. `dotnet list package --vulnerable --include-transitive` y `--deprecated`: 28 de 28 proyectos sin hallazgos.

### 3.8 R-PRIV

`rpriv.sh` v2 con una lista privada de 43 identificadores (equipos, contenedores, recursos de turno, usuario, dispositivo, las dos direcciones de las estaciones y nombres de otros proyectos), fuera de la raíz: `patrones=0 identificadores=0 cabeceras=0` antes y después. Barrido ampliado: las únicas direcciones son `127.0.0.1`, `0.0.0.0` (pruebas de arranque del servidor MCP) y `192.0.2.10` (rango de documentación); los puertos son los de la receta propia (`11434`, `5260:8080`, `8080`) y el del `launchSettings.json` copiado; 0 `<clave-de-cabeceras>`; 0 rutas del home. Las cinco capturas de `Demos/…/docs/capturas/` se miraron una por una: sin barra de direcciones ni datos del laboratorio, y sin fragmentos `tEXt`, `iTXt`, `zTXt` ni `eXIf`. La evidencia copiada a la bitácora también da `patrones=0 identificadores=0 cabeceras=0` (`evidencia-compuertas/rpriv-evidencia.txt`), después de reemplazar en los scripts las rutas del área de trabajo y el nombre del volumen NuGet por marcadores.

### 3.9 Barridos

Salida completa en `barridos-antes.txt` y `barridos-despues.txt`. Quedan cuatro coincidencias que cumplen el criterio del plan: `UseDistributedCache`/`CacheConContador` en `Demos/` (3), aceptado porque la demo lo registra sólo con `AI:Cache:Habilitada`, apagado por defecto, y con la sobrescritura de `EnableCaching` que excluye los pedidos con herramientas, probada en `Cableado/CacheTests`; «doble capa» (2), las dos como alternativa descartada por el doble conteo de tokens; «no vuelve a ejecutar las herramientas» (4), que tiene que estar; y dos «línea 1» que son «`using` … en la línea 1», no el dominio de colectivos. La forma excluida «flujo de trabajo» tiene la nota de §3.4.

### 3.10 Mermaid

16 bloques: los 15 de la guía (§1.2, §2.4, §3.2, §4.5, §5.3, §5.8, §5.9, §6.2, §6.6, §7.2, §7.5, §7.6, §8.4, §8.5 y §9.4) y el del README de la demo. Los 16 pasan `mermaid.parse` y `mermaid.render` con mermaid 11.12.0 en Chromium. Esta compuerta quedó sin correr en el ciclo 1 por falta de renderizador.

### 3.11 Presupuesto

| Sección | Palabras | Presupuesto | Desvío |
|---|---|---|---|
| §0 | 2030 | 1200 | +69 % |
| §1 | 1122 | 1000 | +12 % |
| §2 | 2414 | 1500 | +61 % |
| §3 | 2713 | 2000 | +36 % |
| §4 | 3603 | 3000 | +20 % (en el borde) |
| §5 | 5395 | 4500 | +20 % |
| §6 | 7053 | 6000 | +18 % |
| §7 | 9944 | 6000 | +66 % |
| §8 | 9051 | 5500 | +65 % |
| §9 | 4693 | 3500 | +34 % |
| Anexos | 12 145 | 6000 | +102 % |

## 4. Correcciones (changelog)

**Guía** (`99e62a78…3885cf4` → `dcba3177…bb730325`):

1. §5.8, anotaciones pareadas: el snippet «después» citaba l. 34–36 de un archivo de 21 líneas y mostraba sólo `ComoAIFunction`. Ahora cita l. 12–20 y muestra el método con `[Description]` y la función con el nombre explícito, como en el código.
2. §8.4.3: el comentario del criterio, igual al archivo (l. 15–19), después de quitar del código los ids de bitácora.
3. Anexo D.2: tres filas para los paquetes de la copia sola de la demo y la frase de cabecera acotada.
4. Anexo D.1, REF-031: «verificación de la mesa» → «verificación previa» (proceso interno en un texto público).
5. C5, «de MAF» junto a tipos de MAF: §5.8 (fila MAF), §7.1 (párrafo de apertura y «Workflow de MAF»), §7.7 (`SecuencialTests`), §7.13.3 y la entrada «Workflow de MAF» del Anexo C.
6. C5, «contexto»: 15 reemplazos en §2.5, §3.9, §5.4, §6.4, §6.11, §6.12, §7.8, §8.1, §9.5 (dos), §9.9, el Anexo C (CAG), el Anexo E (dos tablas) y el formato del Anexo F («situación»).
7. RV-17: estimando en §2.6.4 y en el Anexo B.1.
8. RV-22: remisión a la tabla de §5.7 en §5.4, §5.10, §6.5 y §7.3.4.

**`Examples/` y `Demos/`** (23 archivos, 29 líneas, ninguna línea agregada ni quitada):

- Ids de bitácora fuera de comentarios y textos: `(R-LLM-3b)`, `(R-LLM-3c)`, `(R-LLM-3e)` y `(RV-01)` quitados; «cabecera R-LLM-4» → «cabecera R-LLM» en los `ServidorDePrueba.cs` de 01, 04, 05, 06, 07, 08, 09 y 10, en `RegistroRllm.cs` y `RecorridoConModeloTests.cs` de la demo, en `Oro.cs` y el README de 05, y en la línea de cabecera que escribe `BusquedaConModeloTests.cs` de 04 («# R-LLM — estimando: …»).
- `Examples/09`: «no falla al arrancar» → «no falla al construir el contenedor» en el README y en el comentario de `CicloDeVidaDelClienteTests.cs` (es la frase de P2-05 y evita el literal del barrido).
- PR-16: «Principio: el modelo propone; la aplicación ejecuta, autoriza y valida.» en `HerramientasDeLocalidades.cs` de 06 y 07 y en `ServidorMcp.cs` de 08, al final de una línea de comentario existente.

**Bitácora:** redacción R-PRIV in situ, con la excepción del dictamen de la presidencia §1, de una ruta del home en la línea 4 de `evidencia-examples/01-Chat-Basico/scripts/build-test.sh` y de `evidencia-cableado.sh` (→ `<workspace>`): sobre `OUTPUTs/` daban `patrones=2`, y ahora `patrones=0 cabeceras=0` (`identificadores` se informa y no bloquea mientras no haya commit, dictamen §2). `matriz-snippets.md` con el estado real de las 70 filas (nota fechada al final); este registro; `evidencia-compuertas/`; nota en `Bitacoras/README.md`.

## 5. Lo que no se pudo cerrar

1. **Presupuesto (P-07): 8 de 11 secciones fuera de ±20 %** y la guía en 60 629 palabras frente a 40 200. Cerrarlo es comprimir unas 20 000 palabras, una tarea editorial de la relectura integral (S-14, REED-16 §10), no un arreglo mecánico. No se tocó.
2. **Clon limpio (P-10), parte con modelo.** Corrió la parte sin modelo en una copia fuera del workspace y con caché NuGet vacía. Los comandos `ConModelo` de cada README con el servidor levantado por la receta del Anexo E no se corrieron (sin turno de modelo en esta fase).
3. **R-LLM sobre las salidas crudas.** En `evidencia-examples/` y `evidencia-demo/`, 9 archivos no tienen `modelo@` o `estimando` en el mismo archivo: los `conmodelo-salidas.jsonl` de 03 (la cabecera está en el `conmodelo-resumen.txt` de al lado), `inicio.txt` y `NOTA.md` de 03, el intento fallido de 07 en la estación de 4 núcleos, dos salidas de `dotnet test` de 08 (la cabecera está en `agente-por-mcp.txt`) y la consola de la demo. Hay que decidir si la compuerta se lee por registro (cabecera más crudos) o por archivo.
4. **RV-18 para piezas que sólo viven en la demo** (S-51, B-02, B-03, B-12, B-14, B-15): siguen «[a ratificar por la presidencia]»; la matriz las registra como «corre» con la compilación y `Cableado/` de la demo.
5. **«flujo de trabajo» en el Anexo C.** El criterio literal de C5 es 0, y la única aparición es la declaración de la forma excluida en la columna «Sentidos excluidos». Se dejó porque quitarla borra la regla que la exclusión enuncia; si la presidencia prefiere el 0 literal, la celda se reescribe sin nombrar la forma.
6. **MD-1 (cliente móvil):** sigue «no ejecutada» en la trazabilidad; la guía sólo registra la emulación de un teléfono en Chromium.
