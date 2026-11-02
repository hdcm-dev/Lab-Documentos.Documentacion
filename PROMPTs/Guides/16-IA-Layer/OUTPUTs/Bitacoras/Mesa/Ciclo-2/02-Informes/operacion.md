---
doc_id: BIT-16-MESA-C2-OPERACION
doc_type: informe-de-especialista
title: Informe de Operación y entrega sobre el plan de integración v1
role: Operación y entrega (catálogo M§4.1.2; convocado por recomendación del cierre del ciclo 1)
objeto: ../../../04-Plan-De-Integracion.md (v1, ESTRUCTURA APROBADA v1)
modo: a ciegas respecto de los demás informes del ciclo 2 (se leyó el ciclo 1 para no repetir lo resuelto)
fecha: 2026-10-26
---

# Informe de Operación y entrega · Ciclo 2

**Mandato.** Ejecución en contenedor, configuración por ambiente, recursos compartidos (gestor de turnos de `<gestor-de-turnos>/PROTOCOLO.md`), presupuesto de turnos, Ollama aparte para embeddings, observabilidad y limpieza.

Las líneas citadas son las de `04-Plan-De-Integracion.md` v1 (1003 líneas al 2026-10-26). ESC-001 no se reabre: rige el default B (SUP-09) y este informe sólo mira si B se puede operar tal como está escrito. Lo ya corregido en el ciclo 1 (H-021 presupuesto, H-056 timeouts, H-059 red de compose, AJ-02 y AJ-03) no se repite.

## Hallazgos

### OP-01 · S2 · E1 · confianza 0,90 · DEP-14 no se puede cumplir como está escrito, y aunque se cumpliera no logra lo que promete

- **Ubicación**: §E.5, l. 675; §G.3 DEP-14, l. 873; §G.2 R-02, l. 848.
- **Afirmación**: el plan dice que el recurso `[recurso-modelo-propio]` se le pide al gestor «para que compita por turnos con `build` en la máquina al límite». Hay dos problemas. (1) El gestor no puede darlo con el ajuste en caliente: `cupos.conf` sólo carga `CUPO` y `<gestor-de-turnos>` lee `TTL[$r]` con `set -u`, así que un recurso nuevo aborta hasta cuando se le pasa el ttl explícito. Hace falta tocar el script: las tablas `CUPO`/`TTL`, la lista `TODOS` y `salud`. (2) Aunque exista, el gestor maneja cupos **por recurso** y no tiene exclusión entre recursos. Un `[recurso-modelo-propio]` con cupo 1 no le impide correr a `build` (cupo 2) al mismo tiempo, y por lo tanto no compite con él.
- **Ancla**: `<gestor-de-turnos>` l. 23–27 (`declare -A CUPO=(…)`, `declare -A TTL=(…)`; `cupos.conf` sólo asigna `CUPO[$r]=$n`), l. 93 (`local ttl="${TTL[$r]}"`). Prueba en un directorio de estado aislado (`<dir-del-gestor>` en el scratchpad, con `cupos.conf` = `[recurso-modelo-propio] 1`): `<gestor-de-turnos> pedir [recurso-modelo-propio] prueba-op "sonda" --no-esperar` → `línea 94: TTL[$r]: variable sin asignar`, rc=1; con `30` explícito, el mismo error. `<gestor-de-turnos> recursos | grep -c [recurso-modelo-propio]` → 0.
- **Impacto**: el cierre del ciclo 1 dice que, si el gestor no da `[recurso-modelo-propio]`, se pasa al plan C. Con el gestor de hoy esa condición ya se cumple. Así, 05, 06, 07, 16 y PD-2 caen a «no ejecutado contra el modelo» por un detalle del script y no por falta de recursos. Si en cambio se agrega el recurso, la mitigación de R-02 queda escrita pero no opera: el Ollama propio y dos builds pueden correr juntos en la máquina al límite.
- **Dirección**: DEP-14 tiene que ser un cambio al gestor con criterio verificable (`<gestor-de-turnos> recursos` lista `[recurso-modelo-propio]` con cupo y ttl, y `salud [recurso-modelo-propio]` responde), con dueño y antes de construir. Si se quiere que el Ollama propio y `build` no se pisen, la regla tiene que estar en algún lado: exclusión en el gestor, o un orden de pedido que tome los dos recursos y quede escrito. Si no, R-02 dice que la mitigación es sólo de memoria (modelo de 639 MB) y no de CPU.

### OP-02 · S2 · E1 · confianza 0,85 · AJ-01 hace depender el rechazo de la corrida de un dato, `servidor`, que ninguna variable define

- **Ubicación**: §E.1, viñeta `num_ctx` (l. 596), tabla de variables canónicas (l. 601–608) y esquema R-LLM (l. 618). Es el ajuste AJ-01, que este ciclo tiene que ratificar.
- **Afirmación**: AJ-01 manda que «con `servidor = compartido` y la variable sin venir del arnés, el código rechaza la corrida» y pide una prueba de cableado de ese rechazo. Pero ni `servidor` (`compartido` | `propio` | `nube`) ni el «vino del arnés» tienen fuente. La tabla de variables canónicas sólo trae `OLLAMA_ENDPOINT`, `OLLAMA_MODEL`, `OLLAMA_NUM_CTX`, `OLLAMA_EMBED_*` y `RLLM_DIR`. El código no puede saber por el endpoint si un servidor es compartido, y la regla R-PRIV prohíbe escribir su dirección para compararla. `num_ctx_origen` distingue «variable o default», pero no si la variable la exportó el arnés o la puso a mano el lector.
- **Ancla**: l. 596: «con `servidor = compartido` y la variable sin venir del arnés, el código rechaza la corrida, y una prueba de cableado comprueba ese rechazo (R-04; AJ-01)». La tabla de l. 601–608 no tiene variable de tipo de servidor ni marca de origen. l. 618: «`servidor` (`compartido` | `propio` | `nube`)» como campo del registro, sin decir de dónde sale.
- **Impacto**: la prueba de cableado de AJ-01 no se puede escribir sin inventar un mecanismo, y cada constructor va a inventar uno distinto. El campo `servidor` del R-LLM, que decide qué tiempos son comparables (l. 616), queda a criterio de quien corre. La protección de R-04, que es no forzar una recarga en el servidor ajeno, depende de que alguien se acuerde.
- **Dirección**: ratificar AJ-01 sólo con una fuente explícita para los dos datos, por ejemplo una variable canónica de tipo de servidor que el arnés fija dentro del turno y una marca de origen de `OLLAMA_NUM_CTX`. Hay que fijar su default, que tiene que ser seguro para el servidor compartido, y su fila en la tabla. El R-LLM registra ese valor y no lo deduce.

### OP-03 · S2 · E3 · confianza 0,75 · El plan no dice dónde corre el arnés ni en qué orden se toman los turnos, y hay corridas con modelo que quedan sin turno

- **Ubicación**: §E.1 «Arnés» (l. 611); §E.5 punto 3 (l. 673); filas 07 y 16 de §E.2; §F.9 (l. 805–807); §F.11.
- **Afirmación**: `verificar.sh` «corre en `mcr.microsoft.com/dotnet/sdk:10.0` con turno `build`», y `--con-modelo` «envuelve `dotnet test --filter "Category=LLM"` en `<gestor-de-turnos> <recurso-compartido>`». Faltan cuatro cosas. (a) `<gestor-de-turnos>` y `<gestor-de-turnos>` viven en el host y usan el directorio de estado y `flock` del host, así que no pueden correr dentro del contenedor del SDK. El plan no dice qué parte corre en el host. (b) Si la suite con modelo corre dentro del turno `build`, lo retiene durante horas: `<gestor-de-turnos>` lo renueva cada ttl/2. Además, `pedir` bloquea hasta 90 min en cola esperando `<recurso-compartido>` mientras ya tiene `build`. (c) 07 y 16 necesitan a la vez `<recurso-compartido>` (chat) y `[recurso-modelo-propio]` (embeddings), y la demo con PD-2 también. No hay un orden de pedido declarado entre recursos. (d) La demo que se corre a mano (`docker run`/`compose`) para las salidas de §14.5 o la captura de §F.11 llama al servidor compartido sin turno. El protocolo exime sólo las llamadas de menos de un minuto, y §E.5 estima 475 s o más para PD-n.
- **Ancla**: plan l. 611 (texto citado). `<gestor-de-turnos>` l. 13–17: `RECURSO_PID=$$ "$R" pedir …`; renovador `while sleep $(( ttl_ef*30 )); do "$R" renovar …`; `ttl_ef` se lee de `{dir-de-trabajo}/recursos/leases/…`, que es una ruta del host. PROTOCOLO.md: «Llamadas sueltas cortas a <recurso-compartido> (< 1 min, un prompt) van sin turno; suites, evaluaciones y bucles, con turno». §E.5 l. 662: «pesimista de al menos 475 s para 07, 11 y PD-n».
- **Impacto**: un constructor que sigue el plan al pie de la letra no puede invocar el gestor desde el contenedor. Si lo hace desde el host, envolviendo todo, deja un cupo de `build` ocupado durante horas. Dos agentes que piden `<recurso-compartido>` y `[recurso-modelo-propio]` en orden inverso se esperan mutuamente hasta agotar la espera, con código 4. Las corridas de la demo para la evidencia quedan fuera del presupuesto y del registro del gestor.
- **Dirección**: declarar que el arnés es un script del host que pide cada turno por separado y lanza un contenedor por fase, sin anidar `build` y `<recurso-compartido>`. Fijar un orden global de pedido para las corridas que necesitan los dos Ollama. Agregar a §F.9 y §F.11 que toda corrida de la demo contra el servidor compartido, salvo una consulta suelta corta, va con turno `<recurso-compartido>` y suma al tope.

### OP-04 · S3 · E1 · confianza 0,80 · Las cifras de 05 se van a medir en otra versión de Ollama y con builds en paralelo, distinto de la evidencia que las respalda

- **Ubicación**: §E.2 fila `05-Contexto-Completo-Con-Prefijo` (l. 631); §E.1 «Comparar variantes» (l. 616).
- **Afirmación**: al unificar la imagen por H-027, la fila 05 pasó a `ollama/ollama:0.40.11`. Pero la evidencia que cita para «B ≪ A con el mismo prefijo» y para el truncado (N3b X4b) se obtuvo con `ollama/ollama:0.32.0-rc0`, elegida a propósito por ser la misma versión que el servidor compartido. H-027 justificó el cambio **sólo para embeddings** («para embeddings no hace falta igualar la versión de la LAN»), y 05 no es de embeddings. Además, la regla de que «los tiempos comparables sólo se miden en el Ollama propio» no excluye builds en paralelo en la misma CPU (ver OP-01).
- **Ancla**: N3b l. 441: «**X4b. Ollama propio en contenedor, misma versión que el servidor de la LAN** (`ollama/ollama:0.32.0-rc0`, CPU de 8 núcleos, sin GPU), modelo `qwen2.5:0.5b`». Plan v0 l. 557 (fila `12-CAG-vs-RAG`): «`ollama/ollama:0.32.0-rc0`: `qwen2.5:0.5b` para tiempos (N3b X4b)». Plan v1 l. 631: «**Ollama propio** `ollama/ollama:0.40.11` con `qwen2.5:0.5b`». Consolidación del ciclo 1, H-027: «La imagen del plan B (0.32.0-rc0) nunca corrió el modelo de embeddings». `docker images ollama/ollama` muestra hoy las dos imágenes locales (`latest` = 5aefd07598b5, `0.32.0-rc0` = 987a8ffdb4fd).
- **Impacto**: el comportamiento de la caché de prefijo y del truncado que 05 enseña puede cambiar entre 0.32 y 0.40 sin que nada lo registre. La guía mostraría tiempos de 05 con el respaldo de X4b, que se midió en otra versión, y tiempos de prefijo que la concurrencia con builds puede volver incomparables.
- **Dirección**: decidir, con evidencia, qué imagen usa 05. Si es 0.32.0-rc0, se mantiene la paridad con el servidor compartido y X4b sigue valiendo como respaldo. Si es 0.40.11, hay que re-correr X4b con ella antes de citarla. En los dos casos, registrar la versión de Ollama en el R-LLM y en el rótulo, y medir los tiempos de 05 sin builds concurrentes.

### OP-05 · S3 · E1 · confianza 0,75 · El tope de 4 h no tiene medidor ni corte: el envoltorio renueva sin límite

- **Ubicación**: §E.5 «Tope» y línea de corte (l. 670–673).
- **Afirmación**: el plan fija un tope de 4 h de `<recurso-compartido>` y una línea de corte que se aplica **antes** de construir. No dice quién mide el consumo real durante la construcción ni con qué. Tampoco hay corte automático: `<gestor-de-turnos>` renueva la concesión cada ttl/2 mientras el comando viva. Si las llamadas reales salen más lentas que el t de DEP-13 (bajo carga ya se midieron más de 600 s), una suite puede pasar el tope y retener el servidor compartido sin que nada la frene. El punto 3 («el turno se renueva con `<gestor-de-turnos> renovar` antes del ttl») es redundante con el envoltorio preferido del protocolo y no limita nada.
- **Ancla**: `<gestor-de-turnos>` l. 4: «Mientras corre, renueva la concesión cada ttl/2 (un comando largo no la pierde por vencimiento)». PROTOCOLO.md: el registro append-only del gestor, `registro.log` (TSV fecha · recurso · dueño · evento · motivo), que permite sumar el tiempo de concesión por dueño. Plan l. 670: «**Tope**: 4 h de `<recurso-compartido>` para todo el ciclo de construcción».
- **Impacto**: el tope queda como una estimación y no como un límite. El cierre (AC-3b) no puede probar que se respetó. Una suite larga deja sin turno, durante horas, a los demás agentes que comparten el servidor (R-01, R-04).
- **Dirección**: definir el medidor, por ejemplo la suma de concesiones de `<recurso-compartido>` por dueño de la construcción en `registro.log`, informada en la evidencia. Que `verificar.sh --con-modelo` reciba un plazo por suite (`timeout`) derivado del tope restante, y que al agotarlo marque lo pendiente como «no ejecutado contra el modelo» en vez de seguir renovando.

### OP-06 · S3 · E3 · confianza 0,70 · El Ollama propio no tiene provisión del modelo ni red para `Examples/`, y la demo depende de los embeddings para arrancar

- **Ubicación**: §E.1 «Modelo de embeddings» (l. 598) y variables (l. 601–608); §F.6 (l. 787–790); §F.9 (l. 805–807).
- **Afirmación**: el plan fija la imagen y el modelo del Ollama propio, pero no dice (a) cómo llega `qwen3-embedding:0.6b` (o `qwen2.5:0.5b` para 05) al contenedor: no hay paso de `ollama pull` ni volumen de modelos, ni en `compose.yaml` ni en los README de los ejemplos; (b) cómo un ejemplo que corre en el contenedor del SDK alcanza al Ollama propio: la nota de red de §F.9 es sólo para la demo en compose, mientras N3 E3 usó `--network host`; (c) qué pasa al arrancar la demo si los embeddings no responden, porque el almacén se «reconstruye al arrancar» con el generador. No hay ninguna variable que elija el plan C (generador estable) en la demo; `--fake` es por ejemplo.
- **Ancla**: N3-Evidencia/salidas.md l. 61: «`ollama pull nomic-embed-text ; ollama pull qwen3-embedding:0.6b` # en el contenedor local»; l. 64: «`docker run --rm --network host …`». N3b l. 444–445: `docker run -d … -v <ollama-n3b>:/root/.ollama …` + `docker exec … ollama pull qwen2.5:0.5b`. Plan l. 790: «reconstruido al arrancar desde las 12 propiedades». Plan l. 805: «`compose.yaml` con el servicio `demo` y, opcional, el servicio `ollama-embed`», sin paso de carga del modelo.
- **Impacto**: el lector que levanta `compose up` tiene un `ollama-embed` sin modelo. PD-2 falla, o la demo no arranca, en lugar de degradar a C como declara §F.6. El predicado de salto protege a `ConModelo/`, pero no a la demo en ejecución. Cada constructor resuelve la red de `Examples/` a su manera, y `--network host` contradice el «sólo loopback» que se pide para la demo.
- **Dirección**: especificar la provisión del modelo (un paso de carga declarado y un volumen con nombre del proyecto), la red de los ejemplos contra el Ollama propio, y el comportamiento de arranque de la demo sin embeddings: degradar a C por configuración, con el rótulo en la UI y en el registro, en vez de caerse.

### OP-07 · S3 · E1 · confianza 0,75 · La limpieza se reduce a «borrar contenedores» y ya hay restos de los dossiers sin decidir

- **Ubicación**: §G.2 R-02 (l. 848); §E.1 «Build» (l. 619); §F.9 `.gitignore` (l. 809).
- **Afirmación**: la única regla de limpieza del plan es «borrar contenedores al terminar» (R-02). Quedan sin decidir: los volúmenes de modelos del Ollama propio (¿se reutilizan o se borran?), el volumen `<volumen-nuget>`, los `registros/` de `RLLM_DIR` después de copiarlos a la evidencia (contienen entradas y salidas completas y todavía no pasaron por R-PRIV) y los intermedios «fuera del repo», sin ruta. Hoy ya quedan restos de los dossiers. N3 los dejó a propósito «por si la demo los reutiliza», y el plan no los nombra.
- **Ancla**: `docker volume ls` → `<volumen-nuget>`, `<ollama-n3>`. N3-Evidencia/salidas.md l. 107: «Quedan los volúmenes Docker `<ollama-n3>` (modelos `nomic-embed-text` y `qwen3-embedding:0.6b`, unos 913 MB) y `<volumen-nuget-n3>` […] por si la demo los reutiliza». Plan l. 848: «borrar contenedores al terminar».
- **Impacto**: en una máquina al límite (R-02), cerca de 1 GB de modelos queda sin dueño o se descarga de nuevo en cada turno, según quién construya. Los registros crudos con salidas del modelo pueden quedar fuera de la compuerta AC-7 en el árbol de trabajo.
- **Dirección**: una sección corta de limpieza con inventario: qué volúmenes se crean y con qué nombre, si `<ollama-n3>` se reutiliza para el plan B (ahorra la descarga y ya tiene el modelo) o se borra, dónde van los intermedios y qué se borra de `RLLM_DIR` después de pasar AC-7. Tiene que quedar con un comando de verificación al cerrar la construcción.

## Revisado y bien

- **Timeouts y cancelación del cliente del modelo** (§E.1 l. 597, §C §12.7): 10 min por adaptador, sin `AddStandardResilienceHandler`, cero reintentos y `CancellationToken` hasta `GetResponseAsync`. Es coherente con la falla real de N3 E3 (`HttpClient.Timeout of 100 seconds`, salidas.md l. 78) y con las latencias medidas en el servidor compartido.
- **Lo que el registro R-LLM no captura** (l. 618, H-053): sin endpoint, host, puerto, encabezados ni logs de `docker run`, y con la compuerta AC-7 antes de copiar a `Evidencia/`. Cuida la regla R-PRIV del repo público sin perder los campos que deciden si un tiempo es comparable (con la salvedad de OP-02 sobre `servidor`).
- **Red y exposición de la demo** (§F.9 l. 806): `bridge` propio, Ollama de embeddings por nombre de servicio, `OLLAMA_ENDPOINT` sin valor en el archivo y publicación sólo en el loopback del host (`127.0.0.1:8080:8080`), que `/mcp` hereda. Cierra bien H-059 y H-013.

## Sobre los pendientes del ciclo 1 que tocan a Operación

- **AJ-01**: ratificable sólo con la fuente de `servidor` y del origen de `OLLAMA_NUM_CTX` (OP-02).
- **AJ-02 y AJ-03**: desde Operación, ratificables tal como están. AJ-03 necesita el medidor de OP-05 para poder verificarse.
- **Las horas de `<recurso-compartido>` de §E.5 sin recalcular** (deuda del cierre): siguen dependiendo de DEP-13. Con la tabla actual, el pesimista de A (8,0 h) ya duplica el tope de 4 h antes de la sonda, así que la prioridad dentro de A de AJ-03 se va a aplicar con seguridad y no es un caso raro.

## Preguntas (no son hallazgos)

- ¿En qué ambiente (`ASPNETCORE_ENVIRONMENT`) corre la demo en el camino `docker run … dotnet run` de §F.9? §12.2 y §12.5 enseñan contenido en la telemetría y configuración «por ambiente», y la fila 17 dice `EnableSensitiveData` «sólo en desarrollo». Pero §F.9 no fija el ambiente ni dice si `dotnet run` toma un `launchSettings.json`, y la tabla de variables no tiene ninguna variable de exportador OTLP aunque el Anexo F fija `OpenTelemetry.Exporter.OpenTelemetryProtocol`. ¿La demo exporta telemetría a algún lado, o sólo la muestra el ejemplo 17 en memoria?
- `verificar.sh --con-modelo` aborta si no puede leer `context_length` de `/api/ps`. ¿Qué hace si el servidor compartido no tiene ningún modelo cargado en ese momento (lista vacía)? ¿Aborta y la corrida se pierde, o hay una regla para leer el valor de otra fuente sin forzar una carga con otro `num_ctx`?

## Solicitudes de convocatoria

Ninguna. El cambio al gestor que pide OP-01 (DEP-14) no es de un especialista: le toca a la presidencia y a quien mantiene `<gestor-de-turnos>/`.
