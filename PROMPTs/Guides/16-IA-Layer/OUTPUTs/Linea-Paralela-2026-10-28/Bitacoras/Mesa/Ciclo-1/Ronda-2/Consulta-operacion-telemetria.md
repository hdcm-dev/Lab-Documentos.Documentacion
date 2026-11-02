---
doc_id: BIT-16-C1R2-CON-operacion-telemetria
doc_type: consulta-dirigida
title: Consulta dirigida a Operación y entrega + Senior .NET — PC-02 (doble capa de telemetría) y PC-06 (contexto cargado sin num_ctx)
status: hecho
origin: agent
owner: Operación y entrega + Senior .NET (consulta dirigida, dictamen §3.3)
last_review: 2026-10-28
audience: [presidencia, jurado de la ronda 2, aplicación, redacción]
traces: [Mesa/Ciclo-1/07-Dictamen-Presidencia.md §3.3; Mesa/Ciclo-1/01-Consolidado.md C1-37, C1-66, tabla C (PC-02, PC-06); Mesa/Ciclo-1/03-Parches.md P-03, P-20, P-42, §5; 04-Integracion.md R-C07, R-C08, nota P-03; Mesa/Ciclo-1/evidencia-senior-dotnet/S-sonda1-*; Mesa/Ciclo-1/evidencia-implementador-desarrollador/numctx-real*.txt, api-ps.txt; BIT-16-00 R-PRIV, R-LLM]
---

# Consulta dirigida: PC-02 y PC-06

Respondo las dos preguntas C que la presidencia me derivó (dictamen §3.3) con un experimento cada una. La evidencia cruda está en `evidencia-operacion-telemetria/`. No toco la bitácora previa: lo que cambia para los ítems del jurado va en la última columna de cada respuesta y lo aplica quien corresponda.

| Pregunta | Respuesta corta | Evidencia |
|---|---|---|
| PC-02 | **Sí.** Con la doble capa y el mismo `sourceName`, el mismo pedido muestra los spans de herramientas con la caché fría y el acierto con la caché caliente. Tiene un costo que no estaba previsto: la métrica de tokens cuenta dos veces cada fallo de caché, y las dos capas no se pueden separar por atributos. | E1, sonda sin modelo |
| PC-06 | **No.** En Ollama 0.40.11, un pedido sin `num_ctx` que llega con el modelo cargado con 8192 **lo recarga** con el contexto por defecto (4096) y trunca a 2050 tokens. Pasó en 10 de 10 series (5 con `qwen2.5:0.5b` y prompt largo, 5 con `qwen3.5:4b` y `api/ps`). Lo dice también el código fuente de esa versión. La corrida 2 de K9 no probaba reutilización: su prompt (2741 tokens) entraba en 4096 | E1, R-LLM con turno, N = 5 + 5; E2, fuente v0.40.11 |

## PC-02 · Doble capa de telemetría con el mismo `sourceName`

**Pregunta (01-Consolidado, tabla C; ítem C1-37; parches P-03 y P-42).** ¿Se ven a la vez los spans de herramientas y los aciertos de caché si `UseOpenTelemetry` va dos veces con el mismo `sourceName`? SENIOR-01 midió sólo los dos órdenes simples («la doble capa no la probé»).

**Experimento (E1, sin modelo).** `PC02-Program.cs` y `PC02.csproj`, compilados y corridos con el recurso `build` en `mcr.microsoft.com/dotnet/sdk:10.0` (SDK 10.0.403, runtime 10.0.14). Versiones: Microsoft.Extensions.AI 10.11.0, OpenTelemetry 1.20.1 y OpenTelemetry.Exporter.InMemory 1.20.1, la última estable en nuget.org (flatcontainer, consultado el 2026-10-28 a las 12:04 -03). El cliente es un `IChatClient` con guion: pide la herramienta `contar_localidades_por_provincia` y después devuelve su resultado, con `Usage` 12/3 por llamada. Las trazas y las métricas se capturan con el SDK de OpenTelemetry (`AddSource`/`AddMeter` con la constante `"MovilidadUrbana.AI"` de MI-15) y el exportador en memoria; las métricas van en temporalidad delta, por pedido. La caché es `DistributedCachingChatClient` sobre `MemoryDistributedCache`. Una subclase cuenta los aciertos en un `Counter<long>` del mismo `Meter` (`ReadCacheAsync` devuelve algo distinto de `null`). En D2 se repite D con `UseDistributedCache` tal cual, sin contador. Cada variante corre el mismo pedido dos veces: primero con la caché fría y después con la caché caliente. Salida: `PC02-salida.txt`.

**Resultado** (spans de la fuente `MovilidadUrbana.AI`; «llamadas» son las que llegan al cliente con guion):

| Variante | Caché | Llamadas | Spans (árbol) | `gen_ai.client.token.usage` input (n / suma) | Contador de aciertos |
|---|---|---|---|---|---|
| **A** · caché → `UseFunctionInvocation` → OTel → cliente (rama A de P-03) | fría | 2 | 4: `orchestrate_tools` > `chat`, `execute_tool contar_…`, `chat` | 2 / 24 | — |
| | caliente | 0 | **0** | sin registro | **1** |
| **B** · OTel → caché → `UseFunctionInvocation` → cliente (R-C07) | fría | 2 | 1: `chat` | 1 / 24 | — |
| | caliente | 0 | 1: `chat` (sin hijos, 0,3 ms) | 1 / 24 | 1 |
| **D** · OTel externa → caché → `UseFunctionInvocation` → OTel interna → cliente, mismo `sourceName` | fría | 2 | **5**: `chat` > `orchestrate_tools` > `chat`, `execute_tool contar_…`, `chat` | **3 / 48** | — |
| | caliente | 0 | **1**: `chat` sin hijos | 1 / 24 | 1 |
| **D2** · D con `UseDistributedCache` sin contador | fría | 2 | 5 (igual que D) | 3 / 48 | — |
| | caliente | 0 | 1: `chat` sin hijos | 1 / 24 | — |

**Respuesta.** Sí: con la doble capa se ven las dos señales en una misma traza. Con la caché fría, el span externo `chat` es padre de `orchestrate_tools`, que contiene el `execute_tool`. Con la caché caliente sólo aparece el `chat` externo, sin hijos y sin llamadas al cliente. Ese span sin hijos es lo que delata el acierto. La condición de la primera rama de la nota P-03 en 04-Integracion se cumple al pie de la letra («si se ven a la vez los spans de herramientas y el acierto de caché, M8 pasa a doble capa»).

**Lo que la nota de P-03 no preveía** (lo medido, para que el jurado lo pese):

1. **Doble conteo de tokens en la métrica.** En D, un fallo de caché registra `gen_ai.client.token.usage` input = 48 con n = 3: el `chat` externo (24) más los dos `chat` internos (12 + 12). Lo que se consumió de verdad es 24. Los tres puntos caen en **un solo punto de métrica con los mismos atributos** (`input:n=3`), así que no se puede filtrar por capa. Para medir costo con la doble capa hay que sacar los tokens de las trazas (sólo de los `chat` hijos de `orchestrate_tools`) o de un contador propio, no del histograma estándar. N5 §4.1 ya avisaba algo parecido para B («hay que contar sólo los spans de la capa interna», V3); con la doble capa esto pasa también en la métrica.
2. **El acierto no lleva ningún atributo que lo marque.** En B y en D, el span del acierto se ve igual que uno real con los mismos tokens (24/6, como en N5 V3). Sólo se distingue porque no tiene hijos (en D) o por la duración. Para que un tablero cuente aciertos sin reconstruir el árbol de la traza hace falta el `Counter<long>`, y eso vale en todas las variantes.
3. **Dos niveles de `chat` en la misma traza.** Una consulta que cuente spans `chat` cuenta 3 por cada pedido con herramienta en D (1 en B, 2 en A).
4. **Rama A con contador.** Con la caché caliente no hay ningún span ni ningún registro de tokens, pero el `Counter<long>` del `Meter` de la fuente registra 1. La condición que puso coherencia histórica para elegir la rama A («sólo si una prueba de `Cableado/` muestra que el `Counter` cuenta el acierto de caché», 04-Aprobacion-coherencia-historica, P-03) **queda demostrada en sonda**, aunque todavía no como prueba de `Cableado/`. El mecanismo es una subclase de `DistributedCachingChatClient` que sobrescribe `ReadCacheAsync`; MEAI 10.11.0 no trae un evento de acierto. En A, el histograma de tokens queda limpio: sólo cuenta llamadas reales (2 / 24).

**Condición CTX-SENS (clave con sesión, P-03), medida de paso.** En `PC02-salida.txt` [S]: con la caché por fuera de `UseFunctionInvocation`, sin agregar nada a la clave, la sesión B **recibe la respuesta de la sesión A** (0 llamadas al cliente). Con `DistributedCachingChatClient.CacheKeyAdditionalValues = [SessionId]` (la propiedad existe en 10.11.0, junto con el `GetCacheKey` protegido), las dos sesiones dan dos fallos de caché. La propiedad es de la instancia, así que la caché tiene que crearse por scope o la clave tiene que salir de `GetCacheKey` con el `SessionContext`. Encaja con el pipeline externo Scoped de P-12.

**Consecuencia para los ítems del jurado.**

- **C1-37 / P-03 / M8 / RV-03.** PC-02 queda corrida y RV-03 ya no bloquea: la guía puede dejar de ser neutral. El jurado elige con estos datos:
  - *Doble capa (D):* cumple la condición literal de P-03. Obliga a la guía a advertir el doble conteo de tokens y a dar la regla para medir costo (spans internos o contador). Sigue necesitando el contador para contar aciertos sin leer el árbol.
  - *Rama A con contador:* spans de herramientas, métricas de tokens sin doble conteo y aciertos contados por el `Counter`. La condición de coherencia queda cubierta en sonda. El acierto no aparece en las trazas.
  - *B (R-C07):* ya refutada para la observabilidad de herramientas (SENIOR-01); se confirma que no muestra `execute_tool`.
  - Mi recomendación técnica, que no es un voto: **rama A con el `Counter`**, porque es la única que da las tres señales (herramientas, aciertos y costo) sin un número engañoso en el histograma estándar. Si el jurado elige D, M8 tiene que llevar la advertencia 1.
- **P-03, verificación (4):** la salida de PC-02 está en `evidencia-operacion-telemetria/PC02-salida.txt`. La nota de P-03 pedía guardarla en `Integracion-Evidencia/C-operacion-demo/`: la aplicación decide si la copia allá.
- **P-03, verificación (3), y el ejemplo `09` del plan:** la prueba «dos sesiones con el mismo texto → dos fallos de caché» se reproduce con `CacheKeyAdditionalValues`; el fragmento sirve de base para `Cableado/`.
- **P-42 (MI-15):** confirmado que con la doble capa las dos capas comparten la constante y el SDK las recoge con un solo `AddSource`/`AddMeter`. También que el `Counter` de aciertos vive en el `Meter` de esa fuente y el exportador lo ve.

## PC-06 · Sin `num_ctx`, ¿se reutiliza el contexto con que quedó cargado el modelo?

**Pregunta (01-Consolidado, tabla C; ítem C1-66 / MI-18; parche P-20, «derivados a revalidar»).** Sin `num_ctx`, ¿Ollama 0.40.11 reutiliza el contexto con que quedó cargado el modelo (`api/ps` 8192)? Hasta ahora había N = 1: K9 del implementador, corrida 2, con `api/ps` = 8192 después.

**Experimento (E1, R-LLM).** `PC06-sonda.py`, corrido con `PC06-correr.sh` en un turno `<recurso-compartido>` (`PC06-turno.txt`: concedido 13:02, liberado al terminar). Va por HTTP a `/api/chat` contra el Ollama de la estación de laboratorio; el endpoint sale sólo de `OLLAMA_ENDPOINT` y no se imprime. Cabecera R-LLM: Ollama **0.40.11** (`/api/version`), `qwen2.5:0.5b` (`a8b0c5157701`) y `qwen3.5:4b` (`d8b0f5e9760c`), `temperature` 0, `seed` 1, `num_predict` 8, `think` false, 2026-10-28 de 13:02 a 13:19 -03. **El criterio quedó escrito en el script antes de correr** (H-reuso frente a H-recarga). Cada serie: (0) descargar el modelo (`keep_alive: 0`) y confirmar en `api/ps` que no está; (1) pedido en frío sin `num_ctx`; (2) pedido con `num_ctx` = 8192; (3) pedido sin `num_ctx` con el modelo cargado con 8192, **que es la medición**; (4) otro pedido sin `num_ctx`. Después de cada paso se lee `api/ps`. Cada paso lleva un encabezado propio («Planilla serie-paso») para que la caché de prefijo no se mezcle con la medición. Con el 0.5b, el prompt tiene 185 líneas del dominio (13 685 caracteres, 5134 tokens: más que 4096 y menos que 8192). Con el 4b el prompt es corto (30 tokens): se mira sólo `api/ps` y `load_duration`, porque leer más de 4096 tokens a unos 19 tok/s (§R.6) no entra en el turno con N = 5.

**Resultado.**

| Modelo (N = 5 series) | Paso | `prompt_eval_count` | `api/ps` después | `load_duration` (s) | Respuesta |
|---|---|---|---|---|---|
| `qwen2.5:0.5b`, 5134 tokens | 1 · frío, sin `num_ctx` | 2050 ×5 | 4096 ×5 | 0,82–1,93 | «114» ×5 (equivocada) |
| | 2 · `num_ctx` = 8192 | 5134 ×5 | 8192 ×5 | 1,10–1,99 | «1» ×5 (correcta) |
| | **3 · sin `num_ctx`, cargado con 8192** | **2050 ×5** | **4096 ×5** | **1,12–1,74** (recarga) | «114» ×5 |
| | 4 · sin `num_ctx` otra vez | 2050 ×5 (`cached` 2049) | 4096 ×5 | 0,00 | «114» ×5 |
| `qwen3.5:4b`, 30 tokens | 1 · frío, sin `num_ctx` | 30 | 4096 ×5 | 11,51–19,20 | «ok» |
| | 2 · `num_ctx` = 8192 | 30 | 8192 ×5 | 11,36–22,80 | «ok» |
| | **3 · sin `num_ctx`, cargado con 8192** | 30 | **4096 ×5** | **10,48–16,06** (recarga) | «ok» |
| | 4 · sin `num_ctx` otra vez | 30 | 4096 ×5 | 0,00–0,01 | «ok» |

La respuesta esperada era 3001, el código postal de la Localidad 1. Con 8192, el 0.5b responde «1»: equivocada, pero distinta de la truncada. En los dos modelos, `load_duration` del paso 3 es del orden de una carga en frío y el del paso 4 es 0: el paso 3 recargó el modelo. En las dos corridas, `api/ps` mostró también el otro modelo cargado con 4096 (`ps_inicial`, `ps_final`): el valor por defecto es el mismo para los dos.

**Fuente (E2).** `PC06-fuente-ollama-v0.40.11.txt`, extracto de la etiqueta v0.40.11 en GitHub, bajado el 2026-10-28. `routes.go` l. 202–212: `usesAutomaticNumCtx` da `true` si ni el pedido ni el Modelfile traen `num_ctx` y `OLLAMA_CONTEXT_LENGTH` no está definida. `sched.go` l. 1437–1473 (`needsReload`): el contexto cargado se conserva **sólo si el runner también se cargó con el valor automático** (`runner.numCtxAuto && req.numCtxAuto`). Si se cargó con un `num_ctx` explícito, el pedido automático trae el valor por defecto, las opciones difieren y el runner se recarga. La doc oficial (https://docs.ollama.com/context-length, leída el 2026-10-28) fija el valor por defecto por VRAM: «< 24 GiB VRAM: 4k context». Concuerda con el 4096 medido, en un servidor sólo CPU y sin `OLLAMA_CONTEXT_LENGTH`.

**Respuesta.** No: **en 0.40.11 un pedido sin `num_ctx` no hereda el contexto del modelo cargado**. Si el modelo estaba cargado con un `num_ctx` explícito, lo recarga con el valor por defecto (4096 en esta estación) y trunca en silencio a `num_ctx/2 + 2` = 2050, con `done_reason: stop`. El resultado es determinista: 10 de 10. Lo que sí depende del estado del servidor es **el costo**: esa recarga costó de 10 a 16 s con el 4b.

**Corrección a la evidencia previa.** La lectura de K9, corrida 2 (Informe-implementador-desarrollador, IMPLEM-02 y su voto de MI-18: «sin fijarlo, el resultado depende del estado del servidor… el modelo seguía cargado con 8192») **no se sostiene**. Ese prompt tenía 2741 tokens, menos que 4096, así que no truncaba con ningún contexto. Y el `api/ps` = 8192 se leyó después del pedido **con** 8192, que en esa sonda era el segundo (`numctxreal/Program.cs`). «2050 sin `num_ctx`» (X3) sí es un dato que el lector va a reproducir, siempre que no se defina `OLLAMA_CONTEXT_LENGTH`, ni haya `num_ctx` en el Modelfile, ni la máquina tenga 24 GiB de VRAM o más.

**Observación de paso (inferencia, no medida directa).** En el paso 4, `prompt_eval_cached_count` = 2049 aunque el encabezado del prompt era distinto del paso 3. Eso es compatible con que el truncado descarte el **principio** del prompt y conserve el final, que era idéntico entre los dos pasos. También concuerda con que la respuesta truncada no vea la línea de la Localidad 1, que está al principio. Refuerza la regla de P-20 de poner el dato en la zona que se descarta, pero no lo medí aparte.

**Consecuencia para los ítems del jurado.**

- **C1-66 / MI-18 / P-20:** queda cerrado el derivado «PC-06». La regla de diseño de P-20 se sostiene y se apoya mejor: **sin `num_ctx` explícito el contexto es el de por defecto del servidor, no el que haya quedado cargado**. El argumento «depende del estado del servidor» sale de la posición del implementador en MI-18 (y de cualquier texto de la guía que lo repita). En su lugar va: «depende de la configuración del servidor (`OLLAMA_CONTEXT_LENGTH`, Modelfile, VRAM)». La comparación de `InputTokenCount` con el largo esperado sigue siendo necesaria por el otro motivo de K9: con 8192 también trunca si el prompt no entra (4098, corrida 1).
- **R-C08 («todo ejemplo y la demo fijan `num_ctx`… lo verifican con `api/ps`»):** se mantiene. Con un matiz operativo nuevo: **mezclar pedidos con y sin `num_ctx` sobre el mismo modelo hace que se recargue en cada alternancia** (de 10 a 16 s con el 4b, en el único hueco de concurrencia). Pasa, por ejemplo, con la vía `/v1`, que no admite `num_ctx` por pedido (SENIOR-06, R-C14), o con otro consumidor del mismo servidor. La guía debería decir que todos los clientes de un mismo modelo usan el mismo `num_ctx`, o que se fije en el servidor (`OLLAMA_CONTEXT_LENGTH`) o en el Modelfile. Esto último no lo medí.
- **P-11 (`NumCtx = 8192` en `OpcionesDeIA`):** sin cambio. La verificación (4) de P-11, «no se trunca con 8192 y sí con 4096», se puede correr con el prompt de 185 líneas de esta sonda (5134 tokens).
- **§R.6 (cifras):** la tabla única puede sumar dos filas: la recarga del 4b, de 10,5 a 22,8 s de `load_duration` (N = 15 cargas), y la lectura del prompt del 0.5b, 5134 tokens en 67–96 s. Las fuentes son `PC06-*.jsonl` y es la aplicación la que decide si entran.

> **2026-10-28 — Parche P2-10 (ciclo 1, ronda 2).** «§R.6 (cifras)»: la «recarga del 4b, de 10,5 a 22,8 s (N = 15 cargas)» junta tres pasos. En §R.6 entró como dos filas: la recarga al alternar (paso 3) 10,5–16,1 s con N = 5, y la carga en frío y con 8192 como referencia aparte. La cifra de Parche P2-09 y la de §R.6 son la misma (posición del juez de costo-beneficio).


## Registro de turnos y limpieza

- `build`, dueño `operacion-telemetria`: tres corridas de PC-02. La segunda falló en compilación (CS1593, firma del delegado de `AddInMemoryExporter`); la corregí y en la tercera agregué métricas delta. Cada una se liberó al terminar.
- `<recurso-compartido>`, dueño `operacion-telemetria`: una prueba corta salió de la cola antes de que le tocara turno, sin llegar a pedir nada al modelo. Después hubo una sola concesión, de 13:02 a 13:19, con las dos corridas de PC-06 (`PC06-turno.txt`).
- Intermedios en `{dir-de-trabajo}/operacion-telemetria/` (bin/obj borrados). Ni la evidencia ni este documento tienen dirección, puerto, nombre de equipo ni credenciales de servidores de IA (`grep` sobre la carpeta: 0).
- Sin commit ni push.

## Evidencia

| Archivo | Qué |
|---|---|
| `evidencia-operacion-telemetria/PC02.csproj`, `PC02-Program.cs` | Sonda de PC-02: variantes A, B, D y D2, contador de aciertos y clave con sesión |
| `evidencia-operacion-telemetria/PC02-salida.txt` | Salida cruda de PC-02, con las advertencias de compilación filtradas |
| `evidencia-operacion-telemetria/PC06-sonda.py`, `PC06-correr.sh` | Sonda R-LLM de PC-06, con el criterio escrito antes |
| `evidencia-operacion-telemetria/PC06-qwen2.5-0.5b.jsonl`, `PC06-qwen3.5-4b-corto.jsonl` | Salidas crudas (N = 5 + 5) |
| `evidencia-operacion-telemetria/PC06-turno.txt` | Registro del turno `<recurso-compartido>` |
| `evidencia-operacion-telemetria/PC06-fuente-ollama-v0.40.11.txt` | Extracto de `routes.go` y `sched.go` (v0.40.11) y cita de la doc de longitud de contexto |
