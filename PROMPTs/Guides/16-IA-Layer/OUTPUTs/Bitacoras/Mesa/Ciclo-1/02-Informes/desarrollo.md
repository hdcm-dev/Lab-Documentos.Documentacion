# Informe del especialista — Desarrollador de código (Ciclo 1, a ciegas)

> Objeto: `04-Plan-De-Integracion.md` v0, §E (ejemplos) y §F (demo), con §G.
> Mandato: ¿los ejemplos y la demo, tal como están especificados, se pueden construir, ejecutar y probar? Criterios de prueba ejecutables, scripts, contenedores, tiempos realistas con el servidor medido y dependencias que faltan.
> Fecha: 2026-10-26. No se compiló ni se corrió nada contra el servidor de la LAN. La única inspección propia (H3) es una lectura de cadenas del binario `OllamaSharp.dll` 5.5.0 que ya estaba restaurado por la sonda N6, sin ejecutar código.

## Hallazgos

### H1 — Falta el presupuesto de tiempo, y el plan usa la cifra equivocada (S2, conf. 0,85)
- **Dónde**: §E.1 «Corridas contra el modelo» (N = 10/5, «~4 tok/s»); §F.8 `ConModelo/`; §F.10 AC-3; §G.2 R-01 y R-02.
- **Qué pasa**: el plan dimensiona el costo con la velocidad de **generación** (~4 tok/s). En este servidor lo que domina es el **procesamiento del prompt**: unos 9,4 tok/s, y en cada pedido de herramientas viajan las instrucciones, los esquemas y el historial. No hay estimación por ejemplo ni del total. Tampoco se dice cómo encaja una suite en el turno `<recurso-compartido>` (cupo 1, ttl 45 min). Y el Ollama propio del plan B, que es pesado en RAM y CPU, no figura como recurso en el protocolo.
- **Evidencia (E1)**: X3 (N3b §3.6): «el procesamiento del prompt tardó 474,7 s en frío (unos 9,4 tokens/s)» para 4.441 tokens. Sondeo §3: `qwen3.5:4b` con herramientas, 199,6 s en la primera vuelta. Sondeo §6.2: `[tools] 50.5s` por OllamaSharp. Protocolo de recursos: «<recurso-compartido> (cupo 1 para corridas pesadas, ttl 45)»; los recursos son build, <recurso-compartido> y emuladores, sin un Ollama local.
- **Orden de magnitud (cuenta mía, sólo para dimensionar)**: unas 300 llamadas al modelo entre los 17 ejemplos y D1–D7 × 5, a 15–200 s cada una, dan entre 3 y 10 horas de turno exclusivo.
- **Impacto**: AC-3 no se cumple dentro de los turnos, las suites se cortan por ttl, y el plan B compite por RAM sin pasar por el gestor.
- **Dirección**: estimar segundos por llamada y llamadas por ejemplo con las cifras medidas (prompt y generación), fijar un tope de horas de turno y decidir P-10 (recorte) con esos números. Definir cómo se renueva el turno dentro de una suite. Pedirle al gestor que el Ollama local sea un recurso por turnos.

### H2 — La «tasa en N corridas» con entrada idéntica y temperatura 0 mide el camino de la caché, no la variabilidad (S2, conf. 0,75)
- **Dónde**: §E.1 R-LLM (`temperature` 0, misma entrada exacta, tasa en N); todas las columnas «tasa N=…»; §F.8.
- **Evidencia (E1)**: X4b (N3b, verificación): «A y C idénticas con `temperature` 0 dan respuestas distintas … patrón repetible entre el camino frío y el cacheado». Ollama reutiliza el prefijo del mismo slot (`cache_prompt: true`, G14).
- **Impacto**: de la corrida 2 a la N el resultado sale casi siempre del camino cacheado. La tasa se acerca a 0/N o a N/N y no le da al lector un criterio sobre la confiabilidad. Además, mezcla corridas frías y cacheadas sin registrarlo.
- **Dirección**: definir qué estima la tasa. Por ejemplo, N entradas distintas (paráfrasis) en lugar de N repeticiones, o temperatura mayor que 0 con semillas distintas. Registrar por corrida si fue fría o cacheada (`prompt_eval_duration` está en `AdditionalProperties`, N3b §3.5).

### H3 — `num_ctx`: la demo no tiene default ni guarda, y D-03 se puede cerrar barato (S2, conf. 0,7)
- **Dónde**: §E.1 (`OLLAMA_NUM_CTX`, umbral de ~2.000 tokens, «el cargado» en la LAN); §F.9 (los defaults son sólo `OLLAMA_ENDPOINT` y `OLLAMA_MODEL`); §G.3 D-03.
- **Evidencia (E1)**: X4b: sin `num_ctx`, un prompt de 4.728 tokens quedó en 2.050 «sin error en la API». El default del endpoint, `localhost:11434`, es el Ollama del propio lector, con el default de la FAQ (4096, G13). X3: en la LAN, **sin** `num_ctx`, se usó el contexto cargado (65.536) sin recarga (`load_s` 1,16). Inspección propia de `OllamaSharp.dll` 5.5.0: el ensamblado contiene `ToOllamaSharpChatRequest`, `TryAddOllamaOption`, `NumCtx`, `num_ctx`, `keep_alive` y `get_AdditionalProperties`. Eso sugiere una vía por `ChatOptions.AdditionalProperties`, pero **no verifiqué la clave ni el comportamiento**.
- **Impacto**: con instrucciones, cinco esquemas de herramientas e historial de `AgentSession`, la demo puede pasar 4096 tokens en el Ollama local del lector. Si pasa, pierde en silencio el principio del prompt, que es justo donde están las instrucciones del principio rector. Nadie mide el tamaño de los prompts de D1–D7.
- **Dirección**: declarar un default de `OLLAMA_NUM_CTX` para la demo. Medir `prompt_eval_count` por paso y agregar a `ConModelo/` una aserción de que no hubo truncado. Cerrar D-03 con una sonda de una llamada (la clave en `AdditionalProperties` y `ollama ps`) antes de decidir si `Examples/12` necesita `HttpClient` a `/api/chat`.

### H4 — Apagar el razonamiento por `ChatOptions` no alcanza a los componentes que arman sus propias opciones (S2, conf. 0,6)
- **Dónde**: §E.1 «Modelo de chat» (`ChatOptions.Reasoning = …None`); `15` (juez `qwen3.5:4b`); `14` y `07`/D6 (agentes de MAF); §F.7.
- **Evidencia (E1)**: Sondeo §2: con el razonamiento encendido, `content` vacío y `finish=length`. Sondeo §4: salida estructurada `timed out` a los 300 s. N5 §4.6: el juez se arma como `new OllamaApiClient(...)`, sin ninguna capa que fuerce el razonamiento apagado.
- **Pregunta (C)**: ¿los evaluadores de `Microsoft.Extensions.AI.Evaluation.Quality` 10.11.0 y los agentes o workflows de MAF mandan `ChatOptions` propias que no traen `Reasoning`? Si las mandan, el juez y los agentes razonan por defecto, y el plan no lo controla.
- **Impacto**: si la respuesta es sí, `15` da puntajes vacíos o se corta por timeout, y los agentes pagan minutos de razonamiento por vuelta.
- **Dirección**: especificar que el razonamiento se apaga **en el pipeline** del `IChatClient` (una capa que configura las opciones de toda llamada), no en cada llamada. Agregar al cableado una prueba de que toda llamada que sale lleva el esfuerzo en None.

### H5 — «La CI compila y corre todo sin red»: no existe esa CI (S2, conf. 0,85)
- **Dónde**: §E.1 «Modo falso»; §F.10 AC-1 y AC-2; §E.1 «Build» (`sdk:10.0`, 10.0.403).
- **Evidencia (E1)**: el único workflow del repo destino es `.github/workflows/framework-concept-demo.yml`. Su alcance es `Concepts/Framework-Concept/Demo/`, y un PR que no la toca da «demo=false». El archivo dice además: «El runner [nombre de host del laboratorio, redactado por R-PRIV en el cierre del ciclo 1] no tiene docker.sock … Trae SDK 10.0.402». Por otro lado, «sin red» no vale para el `restore`, que necesita nuget.org.
- **Impacto**: `Examples/` y `Demos/` quedan sin compuerta. Lo que el plan llama CI tampoco podría correr en contenedor ni con el SDK fijado.
- **Dirección**: definir el mecanismo real. Una opción es un script local equivalente (el patrón de `ci-local.sh`) que corra lo mismo en contenedor y deje evidencia. La otra es un workflow propio con alcance en `Guides/IA/...`, con `global.json` y rollForward, porque el runner no tiene Docker. En los dos casos hay que decir «sin servidor de modelos» y no «sin red».

### H6 — Precondiciones de ejecución: saltear las pruebas «si no responde» y la red de los contenedores están sin especificar (S3, conf. 0,7)
- **Dónde**: §F.8 `ConModelo/` («se saltan con mensaje si no responden»); §F.10 AC-3; §F.9 (los dos caminos de contenedor).
- **Evidencia (E1)**: Sondeo §5: el servidor **responde**, pero `/api/embed` devuelve 501. Sondeo §1: `/api/show` informa las `capabilities`. Sondeo §0 y §6.2: con un timeout de 600 s, un modelo que no está cargado o la cola hacen que el primer byte no llegue. Sondeo §6.2: el patrón verificado usa `docker run --network host`. §F.9 no dice el modo de red, el puerto publicado ni el default de `OLLAMA_EMBED_ENDPOINT`.
- **Impacto**: con un timeout de 5–10 min, una prueba que espera el «no responde» tarda minutos antes de saltearse, o falla en lugar de saltearse si el servidor contesta 501. Con la red por defecto de un contenedor (bridge), `localhost:11434` apunta al propio contenedor. Además, la demo es web y necesita bind y puerto.
- **Dirección**: definir el predicado de salto con chequeos rápidos (versión, modelo presente, capacidad `tools` o `embedding` en `/api/show`) y con un timeout corto propio. Especificar en §F.9 el modo de red, `ASPNETCORE_URLS`, el puerto y los nombres de servicio del `compose` para el plan B, sin datos de la LAN.

### H7 — La evidencia del plan B y del ejemplo 10 viene de otra configuración (S3, conf. 0,8)
- **Dónde**: §F.6 plan B («`ollama/ollama:0.32.0-rc0` … Patrón ya ejecutado en N3 E3 y N3b X4b»); §E.3 `10` («12 enunciados de `*Policy`», top-1 `LocalidadPolicy.RequisitoDelCodigoPostal`).
- **Evidencia (E1)**: N3 `salidas.md` §3: «los modelos de embeddings corrieron en un contenedor `ollama/ollama:latest` local (Ollama 0.40.11)». La versión 0.32.0-rc0 sólo se usó en X4b, con `qwen2.5:0.5b`. El corpus de E3 son «12 enunciados redactados a partir de las reglas», con ids `reglas/encuesta#…`. X4b mide los literales de `*Policy`: «14 literales, 750 bytes».
- **Impacto**: la combinación «0.32.0-rc0 + `qwen3-embedding:0.6b`» no se ejecutó nunca. El «8/8» de E3 no se puede trasladar al conjunto de oro sobre los literales de `*Policy`, que todavía no existe.
- **Dirección**: fijar para el plan B la imagen que sí se ejecutó (0.40.11, con su etiqueta exacta) o volver a correr E3 con 0.32.0-rc0. Para embeddings no hace falta igualar la versión de la LAN. Armar y medir el conjunto de oro sobre el corpus que el ejemplo va a usar, y corregir el conteo (12 frente a 14).

## Posición sobre las propuestas de mi mandato

| PR | Posición | Fundamento |
|---|---|---|
| PR-3 | apoya con cambios | Tres niveles sí, pero dimensionados con H1. Si el presupuesto no alcanza, aplicar el recorte de P-10 antes de construir, no después |
| PR-7 | se opone | Además de I-06, un sistema externo (git, un servidor MCP de ejemplo) agrega dependencias de ejecución que no están en ningún sondeo. `05` con `--fake` cubre la intención |
| PR-8 | apoya con cambios | `12` en un Ollama propio sólo sirve para medir el **mecanismo** (X4b: 102,7 s → 1,1 s). La exactitud con 0,5B no forma criterio (X4b: respondió mal), y un 7B con un prompt de 4,7k tokens en CPU pasa los 400 s por consulta (X3). Los aciertos no deberían ser criterio de prueba |
| PR-11 | apoya con cambios | El camino mínimo en contenedor necesita la red, el bind y el puerto especificados (H6) y un default de `num_ctx` (H3) |
| PR-20 | apoya con cambios | Las pruebas negativas y la de sesión ajena tienen que ser deterministas, con el cliente guionado y en el cableado. Contra el modelo, sólo como tasa con el diseño de H2 |
| PR-22 | apoya | `08` no llama al modelo, y N4 V01 ya compiló SK 1.81.0 con M.E.AI 10.11.0, con la trampa de `FunctionCallContent` |
| PR-19 | apoya | La fila de LangGraph como snippet «no ejecutado», sin levantar Python (P-09). Así no se suma un stack que nadie probó |

## Revisado y bien
1. El modo `--fake`, con cliente guionado y hash estable para los embeddings, ya está probado en la sonda de N6: rechazo y corrección, aprobación con `CreateResponse(false)`, `"avion"` y MCP en proceso (`verif-adv-salida.txt`, `sonda-salida.txt`).
2. Central Package Management con todos los `Microsoft.Extensions.AI*` y MEVD fijados en 10.11.0 responde a un problema medido: MAF 1.26.0 arrastra 10.10.0 (N6 T4, confirmado contra el nuspec).
3. `13` pide `Microsoft.Agents.AI.Workflows.Generators` y usa `BindAsExecutor`. Las dos trampas (`CS0534` y `CS0411`) se reprodujeron en N4 E02.

## Solicitudes de convocatoria
- DevOps/CI: decidir si `Examples/` y `Demos/` tienen compuerta propia en el repo destino, y con qué alcance (H5). Es una decisión de política del repo, fuera de mi mandato.
- Gestor de recursos: incorporar el Ollama local del plan B como recurso por turnos y revisar el ttl de `<recurso-compartido>` para las suites (H1).
