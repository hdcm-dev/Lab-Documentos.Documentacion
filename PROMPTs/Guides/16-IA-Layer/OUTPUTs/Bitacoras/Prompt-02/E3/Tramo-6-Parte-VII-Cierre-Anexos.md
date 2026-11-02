# E3 · Tramo 6 · Parte VII, Cierre y Anexos (capítulos 14–17, Anexos A–H)

Etapa E3, tramo 6 de 6 (`../05-Plan-Integrado.md` §5 E3). Fecha: 2026-11-01. Registro de sólo agregado. Recuento y compuertas: `Registro-Por-Parte.md` §7.

## Índice

1. [Definiciones](#1-definiciones)
2. [Qué se hizo](#2-qué-se-hizo)
3. [Cambios de E1 y recortes en el tramo](#3-cambios-de-e1-y-recortes-en-el-tramo)
4. [Decisiones de edición](#4-decisiones-de-edición)
5. [Para el Anexo H (tramo de Anexos)](#5-para-el-anexo-h-tramo-de-anexos)
6. [Pendientes](#6-pendientes)
7. [Archivos tocados](#7-archivos-tocados)

## 1. Definiciones

- **Renumeración de enlaces:** en la región que va desde `<a id="parte-7">` hasta el final, todo enlace `[§N.k](#sM-k)` o `[capítulo N](#sM)` pasa a la forma nueva (`[§N.k](#cN-k)`, `[capítulo N](#cN)`), con el número visible tomado del encabezado al que apunta el alias. Lo hizo un script (485 enlaces) y la revisión a mano de los rótulos que no empiezan con «§».
- **R-PD:** la corrida del humo de la demo del 2026-10-29 en la estación 2 (`qwen3.5:4b`, digest `d8b0f5e9760c`, Ollama 0.40.11), en `../../Evidencia/R-LLM-2026-10-28/estacion-2/R-PD/`: tres entradas `pasa` (pd2-01, pd3-01, pd6-01); PD-2 con EMB-C (embeddings sin modelo, `embeddings rc=1` en `corridas.txt`).

## 2. Qué se hizo

1. **Encabezados** según el índice congelado: Capítulo 14 · Decisiones de arquitectura de la capa de IA (`c14`, alias `s13`, secciones `c14-1…c14-15`), Capítulo 15 · La demo de Movilidad Urbana (`c15`, `s14`, `c15-1…c15-6`), Capítulo 16 · Caso aplicado: Geometría (`c16`, esqueleto para E8), Capítulo 17 · Autoevaluación (`c17`, `s15`; ítems `c17-iNN` con alias `s15-iNN`). Anexos con sus anclas `anexo-*` sin cambio; nuevas `anexo-c-1`, `anexo-c-2` (Tablas C.1 y C.2, alias `s3-0`, `s4-1`), `anexo-e-8` y `anexo-h`. Las 451 anclas previas siguen (0 faltan, 0 repetidas, 65 nuevas).
2. **Capítulo 14:** la pregunta guía de 14.1 pasa a 14.16 «Preguntas guía» (`c14-preguntas`), como pide el índice para los capítulos 14 y 15. La apertura dice que ADR-01…ADR-10 concretan P-1…P-10 (C-3.5), y cada «Criterio» de ADR-01…ADR-10 termina con «Principio: P-n».
3. **Capítulo 15:** «Preguntas guía de §14» pasa a 15.7. El bloque Historia de 15.3 (humos del 2026-10-27 con el servidor retirado y sus tres salidas) se reemplaza por lo vigente de R-PD.
4. **Capítulo 16 (esqueleto):** secciones 16.1–16.6 con el patrón D-09 a, «En redacción», y 16.7 «Del libro a la especificación» con el enlace al Conocimiento (U-2.3, «al final de la Parte VII»).
5. **Capítulo 17:** sólo encabezado, anclas y remisiones (sin cambio de contenido).
6. **Anexos:** A (títulos «para el capítulo N»; intro sin la regla «A.n = §n»; A.11 y A.12 sin Historia), B (control 4 sin «0/6 es Historia»; un ítem de B.3 acortado), C (anclas propias de C.1/C.2), E (E.1 con columna ADR-01 sí/no, U-2.2, apoyada en `../E1/Cambios-Al-Libro.md` §3; sin Historia; E.3, E.5 y E.6 condensados; la línea `entrada` de ejemplo es la de R-PD; E.8 nuevo con la medición de `contar.sh`, CL-01), F (sin filas Historia; F.1 y F.3 sin la historia del hash), G (renumeración, intro y cierre de G.1 condensados), H nuevo (una tabla, D-10 a).
7. **Prólogo, índice 0.0:** los renglones de la Parte VII, el Cierre y los Anexos enlazan ahora a `c14`, `c15`, `c16`, `c17` y `anexo-h` (los tramos 1 y 3 los dejaron sin enlace hasta que existieran). Es el único cambio fuera del tramo.

## 3. Cambios de E1 y recortes en el tramo

| Id | Estado en el tramo 6 |
|---|---|
| CL-01 | aplicado: E.8 registra la medición de `contar.sh` con fecha (57.466 / 60.000, 2026-11-01) |
| CL-02…CL-06, CL-08 | sin ocurrencias en la región (hechos en tramos 1–5 o sin efecto en el libro) |
| CL-07 | aplicado: E.3 ya no dice que el servidor de chat fue uno que atendía a otros clientes; 0 «servidor compartido» y 0 «servidor retirado» fuera del Anexo H; `OLLAMA_SERVIDOR=compartido` queda como identificador histórico (lo permite CL-07) |
| C-2.2 Historia | 24 líneas con «Historia» o «hasta el 2026-10-28» en la región → 0 fuera del Anexo H; texto íntegro en §5 |
| C-2.3 | el glosario cita sus tablas por `anexo-c-1`/`anexo-c-2` |
| C-2.7 | E.1 es el único mapa de ejemplos y suma la columna ADR-01 |
| D-10 a | Anexo H, una tabla (Tabla H.1) |
| D-11 d | sin Prácticas de ejemplos en la región: los bloques de la demo (`ResolutorDeAprobaciones.cs`, `demo.sh`) se quedan, criterio de los tramos 4 y 5 |
| U-2.2 | columna ADR-01 en E.1 |
| U-2.3 | 16.7 enlaza al Conocimiento |

## 4. Decisiones de edición

- **Topes por parte (Índice §8: «los fija E3 con el total votado»).** Los Anexos no entraban en 12.100 aun con los recortes del tramo: suman Tablas C.1 y C.2 (tramos 2 y 3) y el Anexo H. Se redistribuyó dentro del total votado de 60.000, sin tocarlo: III 6.500 → 6.300, IV 6.300 → 6.000, V 8.600 → 8.300, Anexos 12.100 → 12.900. Las tres partes quedan por debajo de su tope nuevo (6.183, 5.861, 8.242). La Parte VII conserva 7.600, porque el capítulo 16 tiene presupuestadas 2.158 palabras (`../E2/Medicion-Y-Tope.md` §4). Si la mesa prefiere otra distribución, se cambia sólo `tools/contar.sh`.
- **Recortes de redacción en los Anexos** (sin perder contenido normativo): E.3 (verificación de versión y digests), E.5 (presupuesto por clase en un párrafo), E.6 (paso 5 remite a A.10, que ya trae las reglas de lectura; inventario y limpieza en un bloque), G (intro y cierre de G.1), B.3 y B.5 (frases repetidas), F.1 y F.3 (historia del hash).
- **Mapa de intervalos:** salen 11 filas cuya figura dejó el cuerpo (I28, I29, I30, PV01-06a/b/c, PV01-07a/b/c, PV01-09, PV01-10); texto en `Evidencia-Tramo-6/filas-retiradas.tsv`. Lo nuevo vigente se escribe sin forma «k de M» (criterio de los tramos 4 y 5).
- **`verificar-markdown.py`:** resuelve los enlaces `/LAB/…` desde la raíz del workspace, como ya hacía `compuerta-referencias.sh` (convención del repositorio para enlazar a LDD). Lo necesitan los enlaces del Anexo H a las bitácoras.
- **REF-74** quedaba sin cita al salir la fila Historia de F.4: se cita en la fila de la estación 1, donde respalda que 0.40.11 era la última versión publicada.
- **Capítulo 16:** esqueleto sin contenido inventado; los títulos de 16.1–16.6 siguen el patrón D-09 a. E8 los llena dentro de las 2.158 palabras presupuestadas.
- **Gramática de la renumeración:** «a [capítulo N]» y «de [capítulo N]» se corrigieron a mano (al, del, en el).
- Sin mensajes ajenos a mitad de turno.

## 5. Para el Anexo H (tramo de Anexos)

Texto íntegro que sale del cuerpo, de la guía al abrir el tramo (sha256 `5fc013c4239c3bc30f9a10ea9070881f4c976256df2ae39d0be7c0af7e821b67`). Algunas líneas son párrafos enteros: sólo la parte «Historia…» (o la cifra «0/6», o la cláusula «hasta el 2026-10-28») salió; el resto quedó reescrito en el cuerpo.

- **Línea 2746 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > - **Consecuencias.** Microsoft recomienda `InMemory` sólo para prototipos, y Testcontainers para probar contra la base real [REF-89]. Indexar y consultar usan el mismo modelo de embeddings [REF-102]: cambiarlo obliga a reindexar. Los embeddings van por `OLLAMA_EMBED_ENDPOINT`: en el mismo servidor del chat (EMB-A) o en uno aparte (EMB-B), por papeles separados y para no recargar el modelo de chat ([A.12](#anexo-a-12)). Historia (hasta el 2026-10-28). El servidor de chat de entonces no tenía modelo de embeddings y respondía 501 ([§7.1](#s7-1)).

- **Línea 2755 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > - **Alternativas.** (a) Herramienta sobre el repositorio o el `DbContext`; (b) sobre el caso de uso; (c) SQL genérico. Escrituras con o sin `ApprovalRequiredAIFunction` [REF-122]; con texto no confiable, con o sin escrituras montadas; alcance por petición o por circuito; (d) ninguna herramienta escribe: el modelo devuelve una `AccionPropuesta` tipada y la persona ejecuta la operación normal de la API, como se probó en el laboratorio hasta el 2026-10-28. Por MCP, un catálogo único de `AIFunction` del que salgan el bucle y el servidor.

- **Línea 2759 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > - **Confianza.** Media: `TodaEscritura_EsAprobable`, `ContextoNoConfiable_SinHerramientasDeEscritura` (comprueba la opción `conEscrituras: false`, no su uso en el chat), `PedidoQueNombraOtraSesion_NoLaAlcanza`; ninguna prueba de la demo registra una baja sin aprobación ([§14.5](#s14-5)). La demo aplica sólo la regla 2: `SesionDeChat.cs:73` llama a `Crear()` con los valores por defecto. No está medida con la composición vigente: el 0/6 es Historia.

- **Línea 2806 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > - **Consecuencias.** Dos suites: `Cableado/` sin red y `ConModelo/`, que se salta con motivo. Con M ≤ 12 toda tasa es descriptiva ([§10.4](#s10-4)). El LLM juez local no está calibrado. Historia (hasta el 2026-10-28): `qwen2.5:0.5b`, 0/52 salidas legibles, así que el acuerdo no se midió. Vigente: `qwen3.5:4b`, no medido (41/52 < 45/52, 2026-10-29). El anotador fue un agente ([§10.6](#s10-6)). Los evaluadores de seguridad requieren Azure [REF-154].

- **Línea 2829 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > - **Decisión.** `IChatClient` base singleton. Invocación de funciones y herramientas por circuito, con `AIFunctionFactory.Create` sobre instancias del scope y sin parámetros de DI. Historial y pedido pendiente en el circuito; `CreateResponse` sobre el pedido guardado, y la página manda sólo id y decisión. Sin chat por la API ni almacén de conversaciones.

- **Línea 2831 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > - **Confianza.** Alta en el mecanismo: `Composicion_ValidateScopes`, `Herramientas_SinParametrosDeDi`, `Persistencia_ConFabricaDeDbContext`, `Aprobacion_ArgumentosAlterados_SeRechaza`. Lo que pasa sin la regla lo muestra la prueba roja de 08 (`Pruebas/CicloDeVidaTests.cs`): con las herramientas en un Singleton y sin validación de ámbitos, la sesión B ve y borra lo de A sin error (`Singleton_ValidateScopesFalse_CasoRojo_BVeYBorraLoDeA_SinError`); con la validación, falla en cada llamada a la herramienta y no al construir el contenedor (`Singleton_ValidateScopesTrue_CasoRojo_FallaEnCadaLlamadaALaHerramienta`). Historia (hasta el 2026-10-28). Servidor retirado: la sonda de aprobación en dos peticiones conservó el pedido y rechazó la aprobación alterada, una vez. Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27.

- **Línea 2875 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > | `Concurrencia/LimitadorDelModelo.cs` | todo: un `ConcurrencyLimiter` singleton en la entrada, compartido por la API y la página, con 503 y `Retry-After`; patrón probado en el laboratorio hasta el 2026-10-28 | — | — |

- **Línea 3006 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > Historia (hasta el 2026-10-28). Servidor retirado. Los tres humos pasaron su oráculo. El de PD-6 se repitió, porque la primera corrida falló por un defecto de la aserción de la prueba, no del modelo. Observado en el laboratorio: `qwen3.5:4b` (digest `2a654d98e6fb`), Ollama 0.32.0-rc0, sólo CPU, servidor compartido, 2026-10-27; humo de la demo. Embeddings de PD-2: `qwen3-embedding:0.6b` (digest `ac6da0dfba84`), Ollama 0.40.11, segundo servidor, 2026-10-27. Salidas de PD-2 y PD-3, y la llamada pedida en PD-6:
  >
  > ```json
  > { "respuesta": "4", "fuente": "[LocalidadPolicy.RequisitoDelCodigoPostal]" }
  > ```
  >
  > ```json
  > {
  >   "nombre": "Bella Vista",
  >   "provincia": "Corrientes",
  >   "codigoPostal": "3432",
  >   "habitantes": null
  > }
  > ```
  >
  > ```json
  > {"nombre":"eliminar_localidad","argumentos":{"nombre":"Resistencia","provincia":"Chaco"},"resultado":null,"error":null}
  > ```
  >
  > El código validó la cita de PD-2 contra los fragmentos recuperados. En PD-3 `LocalidadRules` rechazó el `null` y la respuesta pidió el dato. En PD-6 el código mostró «Eliminar la localidad «Resistencia» (Chaco), id 2, de tu sesión.», la persona rechazó y la base no cambió. Es conducta de una entrada por paso, sin tasa; las tasas de 03 y 07 están en [§5](#s5-ejemplos) y [§7](#s7-ejemplos).

- **Línea 3057 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > Evidencia: las 81 pruebas de la demo, sin servidor, pasaron (2026-10-29), y ninguna registra una baja sin aprobación; incluyen arquitectura (seis reglas y tres mutaciones rojas), composición con `ValidateScopes` y la fábrica de `DbContext`, el límite de concurrencia, sesiones concurrentes y humo del host. Los tres humos dejaron un registro con su oráculo, recalculable sin volver a llamar al modelo ([§10.4](#s10-4)). Historia (hasta el 2026-10-28). No se muestran ni comparan tiempos, porque el servidor de las corridas atendía a otros clientes.

- **Línea 3067 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > - **LLM juez.** El de 15 es de la familia del generador y no quedó calibrado. Historia (hasta el 2026-10-28): `qwen2.5:0.5b`, 0/52 salidas legibles. Vigente: `qwen3.5:4b`, no medido (41/52 < 45/52, 2026-10-29), ver [§10.6](#s10-6). Falta uno de otra familia.

- **Línea 3456 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > | Medición | ¿Con cuántos textos de ataque, y de quién? | 0/6 pedidos de baja inducidos por variante, IC95 [0; 0,459], b = c = 0, sobre un solo texto de ataque, del mismo autor (rótulo abajo) |

- **Línea 3460 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > Historia (hasta el 2026-10-28). Servidor retirado. Observado en el laboratorio: `qwen3.5:4b` (digest `2a654d98e6fb`), Ollama 0.32.0-rc0, sólo CPU, servidor compartido, 2026-10-27; estímulo del mismo autor. La tasa no muestra que el modelo resista: el control es la garantía del código.
  >

- **Línea 3472 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > | `OLLAMA_PROPIO_ENDPOINT` · `OLLAMA_PROPIO_MODEL` | `http://localhost:11434` · `qwen3.5:4b` (Historia (hasta el 2026-10-28): `qwen2.5:0.5b`) | ¿Qué corre en el segundo servidor (el nombre de la variable es histórico)? Acá, 02, 05 y el LLM juez de 15 |

- **Línea 3473 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > | `OLLAMA_EMBED_ENDPOINT` · `OLLAMA_EMBED_MODEL` | el de `OLLAMA_PROPIO_ENDPOINT` · `qwen3-embedding:0.6b` | ¿Qué servidor tiene el modelo de embeddings? Por defecto, el segundo; con `EMB-A`, el mismo del chat. La razón para separarlos es de papeles y de recarga: el modelo de chat no se descarga para vectorizar (la recarga no se midió para este caso). Historia (hasta el 2026-10-28). La regla era «nunca el de `OLLAMA_ENDPOINT`», porque aquel servidor respondía 501 a embeddings ([§7.1](#s7-1)) |

- **Línea 3617 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > | 4 | Con texto que la aplicación no escribió: si llega al armar el pedido, no se montan escrituras; si llega a mitad del bucle, una escritura sólo corre aprobada y una no aprobable se rechaza | LLM01:2025 [REF-160] | `ContextoNoConfiable_SinHerramientasDeEscritura`, que prueba que `Crear(conEscrituras: false)` no monta escrituras (el chat de la demo no usa esa vía y aplica sólo la regla 2: `SesionDeChat.cs:73` llama a `Crear()` con los valores por defecto; no medida con la composición vigente: el 0/6 es Historia); `Escritura_ConResultadoNoConfiable_PideAprobacion` y `Escritura_NoAprobable_ConResultadoNoConfiable_Rechaza` (`Cableado/AprobacionTests.cs`); en 16, `Origen_SinHerramientaDeEscritura_CeroPedidosPosibles` | [§11.3](#s11-3) |

- **Línea 3983 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > | `02-Cambio-De-Adaptador` | básico | [§5.6](#s5-6) | [OA-D1](#oa-d1) | segundo servidor, vigente `qwen3.5:4b` (Historia: `qwen2.5:0.5b`), dos adaptadores | conducta ([§5](#s5-ejemplos)) |

- **Línea 3986 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > | `05-Contexto-Completo-Con-Prefijo` | intermedio | [§6.3](#s6-3)–[§6.5](#s6-5) | [OA-D3](#oa-d3) | segundo servidor, vigente `qwen3.5:4b` (Historia: `qwen2.5:0.5b`) | duraciones del servidor, sin calidad ([§6](#s6-ejemplos)) |

- **Línea 3996 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > | `15-Pruebas-Y-Evaluacion` | avanzado | [§10.2](#s10-2)–[§10.6](#s10-6) | [OA-D9](#oa-d9), [OA-O3](#oa-o3) | segundo servidor; vigente `qwen3.5:4b` como LLM juez de salidas de 07 (Historia: `qwen2.5:0.5b`) | LLM juez no calibrado ([§10](#s10-ejemplos)) |

- **Línea 4012 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > Hay dos papeles de servidor. El **servidor de chat** (`OLLAMA_ENDPOINT`, `OLLAMA_MODEL`) atiende a casi todos los ejemplos; hasta el 2026-10-28, en el laboratorio fue un servidor, hoy retirado, que atendía a otros clientes ([F.4](#anexo-f-4)). El **segundo servidor** (`OLLAMA_PROPIO_ENDPOINT`; el nombre de la variable es histórico) sirve el chat de 02 y 05, el LLM juez de 15 y los embeddings (`OLLAMA_EMBED_ENDPOINT`, si no se define, toma el valor de `OLLAMA_PROPIO_ENDPOINT`; con EMB-A puede ser el del chat, [A.12](#anexo-a-12)). Dentro de un contenedor, `localhost` es el contenedor ([§12.6](#s12-6)).

- **Línea 4025 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > El arnés no corre contra un segundo servidor cuya versión o cuyos digests no sean los de las corridas de la guía ([Anexo F](#anexo-f)); los valores esperados están al principio de `tools/verificar.sh`: Ollama 0.40.11 y `qwen3.5:4b` con digest `d8b0f5e9760c` (Historia (hasta el 2026-10-28): el digest `a8b0c5157701` de `qwen2.5:0.5b`). Contra el servidor de chat compara `/api/version` y `/api/tags` con `OLLAMA_VERSION_ESPERADA` y `DIGEST_4B_ESPERADO`, que no tienen defecto, y lee `/api/ps`: exporta como `OLLAMA_NUM_CTX` la ventana del modelo cargado, precalienta si no hay ninguno y aborta sin llamar si hay otro. Con un solo servidor para el chat y para el segundo servidor, esperá a que se descargue el modelo de la fase anterior (`keep_alive` [REF-55]) o descargalo antes de la fase de chat; si no, la fase aborta sin llamar. Historia (hasta el 2026-10-28). El README daba como motivo no recargar un servidor que usaban otros; eso no se verificó. `TURNO_CMD` envuelve cada fase en un turno; vacía, la fase corre sin turno y lo avisa, que es lo que corresponde con un servidor propio.

- **Línea 4099 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > Historia (hasta el 2026-10-28). Servidor retirado. Una línea `entrada` real. Observado en el laboratorio: `qwen3.5:4b` (digest `2a654d98e6fb`), Ollama 0.32.0-rc0, sólo CPU, servidor compartido, 2026-10-27; extensión de 03, estímulo del mismo autor:
  >
  > ```json
  > {"tipo":"entrada","fecha":"2026-10-27T17:49:54.596679+00:00","ejemplo":"03-Salida-Estructurada","entrada_id":"x01","oraculo":"salida-estructurada","resultado":"pasa","motivo":"decision=lista","entradas_version":"v1","entradas_hash":"d8155a89635191cf2cbf61e815094566c41b3d9ff36b1f364648e7c2667e04f0"}
  > ```
  >

- **Línea 4124 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > Historia (hasta el 2026-10-28). Servidor retirado. Recálculo y tasa de 16. Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27; estímulo del mismo autor, sobre un solo texto de ataque:
  >
  > ```text
  > recalcular-oraculos: 12 de 12 entradas coinciden
  > […]
  > aprobacion: 0/6 = 0,000  IC95 Clopper-Pearson [0,000; 0,459]
  > aprobacion+marcado: 0/6 = 0,000  IC95 Clopper-Pearson [0,000; 0,459]
  > ```
  >

- **Línea 4193 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > El 2026-10-29 se retiraron de `Examples/Directory.Packages.props` `Microsoft.Extensions.Hosting` (10.0.14), `OpenTelemetry.Extensions.Hosting` y `OpenTelemetry.Exporter.OpenTelemetryProtocol` (1.20.1): ningún proyecto los referenciaba, ni como transitivos. Los paquetes resueltos de los 22 proyectos no cambiaron, y `paquetes_hash` pasó a `2b217a9b4e2523605a9927fdc947ca6d92357b2dbe1079c315e330d267acc60d`.

- **Línea 4228 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > - El hash de `Examples/Directory.Packages.props` cambió con el pin de `OpenTelemetry.Api`: los registros de corridas anteriores conservan el hash viejo y no se volvieron a correr. Volvió a cambiar el 2026-10-29, con el retiro de tres paquetes sin uso ([F.1](#anexo-f-1)).

- **Línea 4233 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > No son paquetes, pero cada salida rotulada de la guía los nombra. Cómo se registra una corrida: [E.6](#anexo-e-6). Servidores vigentes: estación 1 y estación 2 (tres servidores en la tabla de [§4.2](#s4-2): el retirado, como historia, y las dos estaciones).

- **Línea 4240 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > | Historia (hasta el 2026-10-28). Servidor del laboratorio que atendía a otros clientes, retirado | 0.32.0-rc0 (release candidate), sólo CPU | del 2026-10-25 al 2026-10-27 | campo `ollama_version` de los registros de corrida |

- **Línea 4241 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > | Historia (hasta el 2026-10-28). Segundo servidor del laboratorio | 0.40.11 (la última publicada al 2026-10-24) | 2026-10-27 | campo `ollama_version` de los registros; [REF-74] |

- **Línea 4242 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > | Historia (hasta el 2026-10-28). Modelo de chat del servidor retirado | `qwen3.5:4b`, digest `2a654d98e6fb` | 2026-10-27 | campo `digest` de los registros |

- **Línea 4243 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > | Historia (hasta el 2026-10-28). Modelo de chat y LLM juez del segundo servidor | `qwen2.5:0.5b`, digest `a8b0c5157701` | 2026-10-27 | ídem |

- **Línea 4244 (guía al abrir el tramo, sha256 `5fc013c4239c…`):**

  > | Historia (hasta el 2026-10-28). Modelo de embeddings del segundo servidor | `qwen3-embedding:0.6b`, digest `ac6da0dfba84` | 2026-10-27 | ídem |


Filas retiradas de `tools/compuerta-intervalos.tsv`: `Evidencia-Tramo-6/filas-retiradas.tsv`.

## 6. Pendientes

1. Capítulo 16: lo llena E8 (≤ 2.158 palabras; la Parte VII tiene 7.600 − 5.520 de margen).
2. Las Partes I–VI siguen enlazando a la Parte VII por alias (`#s13-…`, `#s14-…`) y nombran «Anexo H» sin enlace: resuelven, pero E10 puede pasarlos a `c14…`/`anexo-h`.
3. README 15, 16 y 17: remisiones internas con número viejo y párrafos Historia propios (pendiente del tramo 5, para E10).
4. `dg.py mermaid-arroba` sigue sin existir en el repo (rc 2); control aplicado a mano (0 arrobas, 0 `#64;`).
5. Topes redistribuidos (§4): que la mesa los ratifique o los cambie en `tools/contar.sh`.
6. R-PRIV corrió sólo con clases genéricas (sin `COMPUERTAS_DIR`).

## 7. Archivos tocados

| Archivo (LD, carpeta de la guía) | sha256 antes | sha256 después |
|---|---|---|
| `Dot-Net-Integration-AI-Layer-Guide.md` | `5fc013c4239c3bc30f9a10ea9070881f4c976256df2ae39d0be7c0af7e821b67` | `425ed9b27704f95ffdfdbae02fcf67aee8099b089068ded7e36e0b676fc3b680` |
| `tools/contar.sh` | `cdcdb31d1cd052bc62ab149c3e755a50e0a6ef5244774a318594973ccb8e78c7` | `3fe1bc6b13e8e7ccb6d11dbc08b344e564c74904eb00a9b230e5ef83542fcb0a` |
| `tools/verificar-markdown.py` | `7f41d4ab68039817ed4d88f34bba39938c666587990497a08a0bea252529fd85` | `d4f3dcbee356a5deb3dae81124038f9666a7f73be4f0f69a39cffcceebebd3db` |
| `tools/compuerta-intervalos.tsv` | `ad53961e6df675a4f6cb8e93570af57b822673881f260f70b6b1a002ab3faad8` | `647024af38fb728f2964b410c1c8cdc693ab3587164081f16dc0a5bc36029d45` |

Sin commit, push ni PR. Ningún README de ejemplos tocado. Partes I–VI byte a byte iguales salvo los cuatro renglones del índice 0.0 (§2.7). Volúmenes y contenedores del build (etiqueta `proyecto=g16e3t6`) borrados al terminar.
