---
doc_id: BIT-16-C1-02-evidencia
doc_type: voto-de-jurado
title: Voto del juez de evidencia — ciclo 1, ronda 1
status: entregado
origin: agent
owner: juez de evidencia del jurado de cinco (REED-16 §9.4; M§4.3)
last_review: 2026-10-28
audience: [presidencia, jurado, relator, cuerpo-auditor]
traces: [Mesa/Ciclo-1/01-Consolidado, BIT-16-00 §3 y R-PRIV, REED-16 §6.2, §9.4, Mesa/Ciclo-1/Informe-*.md, Mesa/Ciclo-1/evidencia-*]
---

# Voto del juez de evidencia (ciclo 1, ronda 1)

**Función fija:** ¿la afirmación o el hallazgo están respaldados por evidencia del nivel que declaran (E1–E4, BIT-16-00 §3)? Voto desde esa pregunta y nada más. Las cuestiones de alcance, didáctica o forma sin consecuencia probatoria quedan señaladas como tales.

**Método.** Leí el consolidado entero y re-verifiqué en la fuente los puntos de los que dependen los votos. No volví a correr nada contra el modelo, y no compilé: me limité a leer salidas guardadas y a hacer conteos con grep. Las rutas de este documento se dan relativas a `Mesa/Ciclo-1/` o a `OUTPUTs/`. Por R-PRIV no transcribo direcciones, usuarios ni rutas del home.

Re-verificaciones (todas del 2026-10-28):

- **R-PRIV.** Hay una sola dirección concreta de tailnet, en `Reanudar.md` l. 60; las otras coincidencias son el rango escrito como texto. Fuera de `Mesa/` hay 20 rutas del home en 9 archivos, y dentro de `Mesa/Ciclo-1/` 25 más: la compuerta tiene que barrer también `Mesa/`. `16-IA-Layer/` figura sin seguimiento.
- **Fuentes de núcleos e integración.** N0b l. 105 frente a l. 561. N5 §4.2: `QueueLimit = int.MaxValue`, `"llama3.1"`, rechazo como excepción. Conteos ESC/CTX en N1–N6, PR-3…7 y PR-18…22 en 04, y «Validación del núcleo» en los nueve núcleos (0 en todos).
- **Salidas de modelo y sondas.** `salida-real.txt`: la vía A tiene N = 1. JSONL de X2 (D1 10/10 con CP corregido o inventado, D6 10/10 baja sin confirmar). AD-S1: 2b 10/10 = 4b 10/10, con digests. Sondas 1 a 4 del senior. O4 de Operación, `numctx-real` y builds del implementador (CS5001, NU1902/NU1903). s4/s5 del experto. R3 y R4 de Verificación.
- **Fuentes E4 guardadas.** La cita de Cockburn (con sha256), `fuentes-consultadas.md` de AH-01, `fuentes.txt` del experto y la doc de Ollama sobre `/v1`.

## Resumen


| Voto | Cantidad |
|---|---|
| INSUFICIENTE | 2 |
| NO_PROCEDE | 1 |
| PROCEDE | 70 |
| **Total** | **73** |


Lo que más pesa desde la función de evidencia:

1. **C1-12 sobreafirma en el título.** O4 con `ValidateScopes=false` muestra que el Singleton ve el `SessionContext` raíz **vacío**. Eso es pérdida silenciosa de la sesión, no mezcla probada: el cruce entre sesiones sigue siendo PC-11 (C).
2. **EA-6 declara N = 5 para A, que corrió una vez** (C1-25, C1-43). El nivel declarado no coincide con la salida.
3. **El 4b no está separado de su familia** (C1-41): AD-S1 es E1 con R-LLM y empata con el 2b.
4. **La causa de «≥ 7B no corre» no está medida** (C1-42). La redacción que se puede sostener es la de Operación.
5. **C1-38 y C1-48: INSUFICIENTE.** Ninguna posición trae evidencia del nivel que el objeto requiere. En los dos propongo la prueba o la tabla que lo destrabaría.
6. **C1-39.** Reemplazar la dirección por el hostname mueve la fuga a otra clase prohibida por R-PRIV. El rótulo «medido en estación 1» también necesita nombre neutro.

## Votos


### C1-01 — **PROCEDE**

- **Fundamento:** E1 re-ejecutado hoy: una sola dirección concreta del rango <rango-cgnat>, con usuario, en Reanudar.md l. 60 (el resto de las coincidencias son el rango escrito como texto). Rutas del home: 20 en 9 archivos fuera de Mesa/ (el consolidado dice 11 archivos; la diferencia no cambia el hallazgo), y 25 más dentro de Mesa/Ciclo-1, incluidos la convocatoria y los informes: la compuerta tiene que barrer también Mesa/. 16-IA-Layer/ figura sin seguimiento (git status «??») y el remoto es el repo que Reanudar §5 declara público. R-PRIV (BIT-16-00 l. 68) prohíbe IPs privadas, hostnames de la LAN y usuarios: S1 por contrato. Sobre la decisión pendiente: una nota de agregado no elimina la cadena (sigue en el archivo), así que como evidencia de cierre sólo vale la redacción in situ con nota fechada o la exclusión del commit, verificada con la compuerta re-ejecutada en cero.

### C1-02 — **PROCEDE**

- **Fundamento:** Verificado en la fuente: N0b l. 105 define «falso aceptado» como valor fuera de catálogo que entra; l. 561 llama así a «2 de 10 si no hubiera confirmación (X2 D1)». El JSONL de X2 D1 muestra 10/10 CP inventados (7 «34000», 2 «3400», 1 «34089»): el 2/10 es «inventado que pasa las reglas», una magnitud distinta, y el 10/10 una tercera. Contradicción entre secciones sobre el mismo término = S1 por contrato. Con N = 10 el intervalo de Wilson [0,06; 0,51] no sostiene ningún umbral: «no medido» hasta que haya definición y oro.

### C1-03 — **PROCEDE**

- **Fundamento:** Verificado en N5 §4.2 l. 252–272: ConcurrencyLimiter con QueueLimit = int.MaxValue, rechazo por InvalidOperationException (sale 500), literal "llama3.1" y la leyenda «Responde a LLM10». Presentar una cola sin techo como respuesta a Unbounded Consumption es una afirmación falsa presentada como hecho: S1 bien asignada. Las cifras de 9–112 s por pedido encolado son E1 de O3/X2 (una estación, N chico, describe a estación 1). El número de QueueLimit va rotulado «elegido, no medido», como pide la propuesta, y la prueba de cableado del pedido N+1 rechazado es la evidencia de cierre correcta.

### C1-04 — **PROCEDE**

- **Fundamento:** Re-ejecuté el conteo: ESC-0 = 0 y CTX- = 0 en N1, N2, N3 y N4; N5 un CTX y ningún ESC. Coincide con las sondas de requisitos y didáctica. «Recomendación sin escenario o contexto» es S2 literal en BIT-16-00 §3. La compuerta mecánica propuesta es verificable.

### C1-05 — **PROCEDE**

- **Fundamento:** E1 + E2 alcanzan: N6 tiene 3 apariciones de ESC-0 y ninguna en el Anexo A, y la fila N6 de 03 §4.1 está en «candidato». La asignación concreta de REQUIS-03 es una propuesta, no evidencia: hay que ratificarla, y el D5 × ESC-02 depende de C1-56.

### C1-06 — **PROCEDE**

- **Fundamento:** Re-ejecutado: PR-3…PR-7 y PR-18…PR-22 tienen 0 menciones en 04. La afirmación de 04 §5 («lo que no está ya no requiere voto») no cubre estas diez, porque no son unificación ni consecuencia de E1. La propuesta (una tabla votada en bloque) no afirma nada técnico: no necesita más evidencia.

### C1-07 — **PROCEDE**

- **Fundamento:** La omisión es E2 contra el Profile (R-PROF en BIT-16-00 exige definición, aplicación por escenario, métodos y marcos y anexos) y contra 04 §8. El volumen de 106 052 palabras es E1. Las reglas de compresión y el presupuesto de palabras son criterio propio y la guía tiene que rotularlas así; el hallazgo no depende de ellas.

### C1-08 — **PROCEDE**

- **Fundamento:** La evidencia (terminos-reemplazados-salida.txt, sonda S9) es E1 sobre el texto. Además el contrato exige que la guía cite fuentes E4 o experimentos E1 propios, no ids de bitácora: la evidencia que sólo vive en la bitácora no es citable desde la guía. La compuerta por grep de ids y rutas es verificable.

### C1-09 — **PROCEDE**

- **Fundamento:** E1 (sondas S4–S7) más un caso E2 concreto: N6 P6 dice lo contrario de lo que pide MI-14. Dos respuestas divergentes a la misma pregunta en la guía serían una contradicción entre secciones (S1). Por eso el plan de reparto con una sola respuesta vigente es una condición previa, no una cuestión de estilo.

### C1-10 — **PROCEDE**

- **Fundamento:** Verifiqué K6: CS5001 en el build del V1-Snip.csproj tal como está. El Anexo E sólo promete registros R-LLM (E2). «Ejemplo no reproducible sin preguntar» es S2 literal. La compuerta «clon limpio + comando del README» es el único E1 que prueba la reproducibilidad: la propuesta es correcta desde la evidencia.

### C1-11 — **PROCEDE**

- **Fundamento:** Re-ejecutado: 0 usos de num_ctx/NumCtx en .cs fuera de Mesa/. K8 (numctx-real.txt) muestra que AdditionalProperties["num_ctx"] llega y que InputTokenCount refleja el truncado (4098 con 8192). S-sonda3 confirma RequestOptions.NumCtx en OllamaSharp 5.5.0. La doc de Ollama (consultada el 2026-10-28, cita literal en S-ollama-openai-compat) dice que /v1 no tiene forma de fijar el tamaño de contexto. Las cuatro afirmaciones del hallazgo tienen el nivel que declaran.

### C1-12 — **PROCEDE**

- **Fundamento:** La primera mitad es E1 firme: S-sonda2 da 3 OllamaApiClient y 3 HttpClient distintos en 3 scopes con Scoped, y timeout 00:01:40. La segunda mitad tiene que corregirse en el título. O4 con ValidateScopes=false muestra que el Singleton ve SessionId = (vacío), es decir, el SessionContext raíz. Eso prueba que la sesión se pierde sin fallar, no que se mezclen datos de una sesión en otra: el cruce entre sesiones es PC-11 (C). La guía tiene que decir «pierde la sesión sin error» mientras PC-11 no se cierre.

### C1-13 — **PROCEDE**

- **Fundamento:** E1: timeout por defecto 00:01:40 (S-sonda2); la vía A tardó 96 547 ms en EA-6 (salida-real.txt [R3]) y el s5 del experto marca 168 s de pared en una sola llamada con 2943 tokens. Una sola llamada ya supera los 100 s en estación 1. El valor declarado tiene que rotularse «medido en <estación neutra>».

### C1-14 — **PROCEDE**

- **Fundamento:** E1 + E2: el puerto string→string está en PuertosDeIA.cs l. 15, y N6 §1.3 promete streaming y aprobación sin decir cómo sobrevive la sesión. S-sonda1 S3 confirma por reflexión que AIAgent.SerializeSessionAsync/DeserializeSessionAsync y TypedResults.ServerSentEvents existen en las versiones fijadas: el contrato propuesto es implementable con API real. El contenido depende de C1-40.

### C1-15 — **PROCEDE**

- **Fundamento:** E3 sobre código leído y verificado en S-caso-base-lectura.txt: la propagación de la sesión al circuito existe en MovilidadUrbana.Web (Routes con SessionId e InteractiveServer) y no en ApiWeb. SUP-05 (E2) y las fuentes E4 (playbook de Microsoft, Threat #5, ms.date 2025-04-22, y LLM05:2025) están citadas con URL y fecha en fuentes-consultadas.md. Sin compilar, el patrón de streaming del componente es C hasta que se pruebe.

### C1-16 — **PROCEDE**

- **Fundamento:** La cita E4 de Cockburn está guardada con URL, fecha (2026-10-28T12:52Z) y sha256: actor primario = el que maneja la aplicación. Las herramientas las invoca el modelo para hacer que la aplicación ejecute un caso de uso, y MCP las expone a clientes externos: en los dos casos son lado de entrada. E2 sobre 04 §6.2. PC-09 (definición única compartida) queda en C y no invalida la ubicación.

### C1-17 — **PROCEDE**

- **Fundamento:** E1 sobre la copia literal de LocalidadRules.cs en 59399ba (F-sonda-reglas). Un corpus de oro que enseña reglas que el código no cumple es una afirmación falsa presentada como hecho, que se propagaría a C4. La ubicación de la normalización se resuelve en C1-38.

### C1-18 — **PROCEDE**

- **Fundamento:** E1 (sonda S5) + E2: en 04 §6.2 la arista NEW --> PORTS diverge del diagrama de N1 §4.7 (UC --> P). Es una divergencia entre secciones, verificable en los dos diagramas.

### C1-19 — **PROCEDE**

- **Fundamento:** E1: la sonda de arquitectura y la compilación de SENIOR muestran que la copia no compila sola. Las versiones NUnit 5.0.0 frente a 4.3.2 salen de una consulta a NuGet con fecha. «Verificable por diff» no prueba que la copia sea suficiente: hace falta dotnet build además de diff -r para que la afirmación de MI-05 tenga E1.

### C1-20 — **PROCEDE**

- **Fundamento:** E1 verificado en S-sonda4-salida.txt con Microsoft.EntityFrameworkCore.Sqlite 10.0.14, el mismo proveedor del caso base: SelectMany(Medios).GroupBy y Count(Medios.Contains) dan InvalidOperationException; GroupBy(Motivo) traduce; la proyección de Medios con agregado en memoria funciona y el SQL filtra por SessionId. La propuesta es exactamente lo que la sonda probó.

### C1-21 — **PROCEDE**

- **Fundamento:** E1: s4 del experto muestra prompt_eval_cached_count 0 / 954 / 0 con el 4b (reuso parcial); O5 de CAT-OP pasa de 71,7 s a 26,0 s cambiando sólo la pregunta. El «93×» de N3b l. 477 es de otro modelo y otra versión, presentado como propiedad del patrón: S2 correcto, y sería S1 si pasara así a la guía. La propuesta de no dar cifra de patrón es lo que la evidencia permite.

### C1-22 — **PROCEDE**

- **Fundamento:** E1: F-X3a/F-X3b y la sonda de numctx-real (4098 tokens evaluados con num_ctx 8192 = 8192/2 + 2). E4: vocab_size 248 320 en Qwen3.5-4B frente a 151 936 en Qwen2.5-0.5B (config.json en Hugging Face, 2026-10-28). Contar con TiktokenTokenizer de «gpt-5» (N3 §4.6) no mide el largo del modelo usado. El enunciado condicional de CAT-FO-05 es el único que no afirma más de lo medido (tres valores de num_ctx, un modelo).

### C1-23 — **PROCEDE**

- **Fundamento:** Verifiqué s5: 2943 tokens de prompt en 167,36 s con el 4b. El límite del contenedor (4 CPU / 5 GB) es E1 de X4 y no figura en el perfil del entorno. Las cifras sin N, sin indicar frío o caliente y sin unidad no tienen el nivel que la guía necesita. La tabla única con esos rótulos es la condición mínima, y R-PRIV pide además rotular la estación con un nombre neutro (C1-39).

### C1-24 — **PROCEDE**

- **Fundamento:** E2 verificado: N3 l. 128 define recall@k como hit rate y lo marca «criterio propio; fuente primaria no consultada». La definición es conocida y está sin fuente. La cifra 8/8 con MRR 1,000 sobre paráfrasis no es medición del corpus real: no se puede citar como desempeño de C4. EXPERT-07 (instruction-aware) es E4 con model card. Una métrica sin definición fuente no puede sostener un umbral calibrado.

### C1-25 — **PROCEDE**

- **Fundamento:** Verificado en salida-real.txt: la vía A tiene una sola corrida ([R3], 96 547 ms) y B tiene 5 corridas en dos preguntas (3/5 y 5/5). EA-6 declara N = 5 para las dos vías: la tabla declara un nivel que la salida no tiene. Las garantías de seguridad (ninguna escritura sin aprobación) son invariantes: su evidencia correcta es una prueba determinista en Cableado/, no una tasa.

### C1-26 — **PROCEDE**

- **Fundamento:** E2 + E3: un CI sin OLLAMA_ENDPOINT saltea ConModelo/ y deja el README en «probado contra Qwen», o sea, evidencia declarada que no existe. E1 de VERIFI-05: en C-operacion-demo/ sólo está X2-fecha.txt y el JSONL de X2 no registra digest ni versión por corrida, así que R-LLM queda incompleto. R7 lo atenúa sin cerrarlo. La plantilla común es la forma de que cada corrida traiga su propio R-LLM.

### C1-27 — **PROCEDE**

- **Fundamento:** E1 (grep: npx -y sin versión, tools: [.. tools], `bool aprobado = /* decisión de la persona */ true;`) + E4 (spec MCP 2026-07-28, Security Best Practices y Tools, citadas con URL y fecha). Un fragmento canónico que, copiado tal cual, desactiva la aprobación contradice a M3 dentro de la misma guía.

### C1-28 — **PROCEDE**

- **Fundamento:** E4 verificado en fuentes-consultadas.md: S-MCP1/S-MCP2 (loopback o autenticación; humano en el bucle), LLM01:2025 (adversarial testing, segregar contenido externo) y el playbook de Microsoft #8, todos con fecha. E1 de la sonda §10: 0 controles de MCP en M1–M12. BIT-16-00 §3 usa como ejemplo de E3 justo el caso que ninguna suite prueba. Lo que falta compilar (AllowedHosts y RequireAuthorization sobre MapMcp, PC-01) queda como criterio de verificación del parche.

### C1-29 — **PROCEDE**

- **Fundamento:** E2 alcanza: es una omisión verificable en el diagrama (RET sin arista de escritura). S3, sin afirmación técnica que probar.

### C1-30 — **PROCEDE**

- **Fundamento:** E1: R3 (release-metadata oficial, 2026-10-28T09:45) da .NET 10.0 lts, active, EOL 2028-11-14. Con eso SUP-08 queda cerrado con fuente, y conviene cerrarlo ya, porque «LTS» sin fuente en la guía sería S1. G1 cuenta 11 marcas [C:] sin cierre en la fundación. La tabla de trazabilidad es una omisión E2.

### C1-31 — **PROCEDE**

- **Fundamento:** E1 + E2: P-14 no cubre N1, N3, N3b ni N6; K1 necesitó 11 using para compilar. R9 y R10 se re-ejecutaron. Desde la evidencia, la regla «nada entra como ejecutado sin compilar en Examples/ con sdk:10.0» es la única que hace verdadera la marca de ejecutado (snippet marcado como ejecutado que no compila = S1).

### C1-32 — **PROCEDE**

- **Fundamento:** E1 + E2: fuentes-salida.txt, formato-citas-salida.txt y los conteos de sentidos. «C» con cuatro sentidos, incluido el nivel de evidencia del contrato, vuelve ambigua la propia rotulación de la evidencia. La definición de agente y workflow sigue abierta (sin respuesta del Experto IA) y entra como condición del Anexo C.

### C1-33 — **PROCEDE**

- **Fundamento:** E1 verificado: tres builds de K6 dan NU1902/NU1903 por System.Security.Cryptography.Pkcs 9.0.11, GHSA-2fmv-rv2c-59x7 y GHSA-846f-f764-76mx. R2 muestra que X0 no consulta deprecaciones, y Microsoft.Extensions.AI.Ollama está deprecado. Una compuerta que compara contra la guía y no contra nuget.org no puede probar vigencia. El nivel de E1 que exige R-EVID es la consulta a registro + flatcontainer con fecha.

### C1-34 — **PROCEDE**

- **Fundamento:** E4: model card de Qwen3.5-4B (2026-10-28, «operate in thinking mode by default») y Modelfile de Sondeo §R.1 (E1). La regla genérica de temperatura sin fuente del fabricante es C. Si OllamaSharp y /v1 traducen TopP/TopK/PresencePenalty es PC-05 (C), y la guía no puede afirmarlo hasta probarlo.

### C1-35 — **PROCEDE**

- **Fundamento:** E4 con fecha: graph-api de LangGraph y workflows de Agent Framework (ms.date 2026-07-30). «Mismo modelo» afirma más de lo que dicen las dos fuentes, y «equivalente en capacidades» es la formulación que éstas sostienen. La tabla de diferencias tiene que citar cada fila.

### C1-36 — **PROCEDE**

- **Fundamento:** E1 re-ejecutado: «Validación del núcleo» aparece en 0 de los nueve registros, y REED-16 §6.2 exige las secciones 4 y 6 y define «validado» con ellas. Desde la evidencia, ningún núcleo puede declararse validado hoy, y la guía no puede apoyarse en un núcleo como validado. Ojo: la sección 6 incluye «veredicto de la mesa», que es justamente lo que produce este ciclo. No tiene sentido exigirla antes de él: se completa como nota fechada con el resultado de este ciclo. Que bloquee o no la redacción es materia de la presidencia; mi voto se limita a que el hecho está probado.

### C1-37 — **PROCEDE**

- **Opción:** A en cuanto a reabrir R-C07 y M8; el orden final queda condicionado a una corrida E1 de la doble capa (PC-02). Hasta entonces, la guía sólo afirma lo medido: qué spans se ven en cada orden.

- **Fundamento:** Las dos posiciones tienen E1, pero sobre cosas distintas. S-sonda1 (MEAI 10.11.0) prueba que con OTel por fuera de UseFunctionInvocation se pierden los spans execute_tool (1 frente a 4). Eso refuta que el orden de R-C07 sea suficiente para la observabilidad que M8 pide. V2/V3 de N5 prueban que con OTel afuera se ven los aciertos de caché. Ninguna prueba que el orden de A conserve esa visibilidad, y la doble capa es PC-02 (C). Procede reabrir R-C07; el orden final no se puede afirmar hasta medir la doble capa.

### C1-38 — **INSUFICIENTE**

- **Opción:** otra: pieza de normalización en el núcleo, invocada por el adaptador antes del caso de uso (compatibiliza A y B), cerrada con la prueba de cableado de R-C03/Q3 por las dos entradas

- **Fundamento:** Ninguna de las dos posiciones trae E1 sobre el objeto de la disputa. ARQUIT E1 + E2 prueba que hoy la pertenencia al catálogo sólo se normaliza en el adaptador, y con eso que «el caso de uso decide» es falso tal como está escrito. AH-01 condiciona su voto a M2 sin evidencia de que una ubicación sea más segura que la otra. La evidencia exige una sola cosa: que la frase de la guía describa lo que el código hace. Eso se cumple con A, o con B si se corrige la frase. El relator ya señaló que las dos son compatibles si el adaptador invoca la pieza del núcleo. Falta una prueba de cableado que inyecte medio:"piedra" por la herramienta y por el endpoint normal y muestre el mismo error.

### C1-39 — **PROCEDE**

- **Opción:** A (AH-01): nombre neutro en guía, Examples/ y Demos/; hostnames dentro de la compuerta R-PRIV; el estatus en la bitácora lo decide la presidencia

- **Fundamento:** R-PRIV (BIT-16-00 l. 68, verificado) prohíbe literalmente los «hostnames de la LAN» en repos públicos, y el conteo de AH-01 es E1. La propuesta B reemplaza un identificador prohibido (dirección) por otro de la misma lista (hostname): no cierra la fuga, la cambia de clase. Que el despacho de la mesa use «(estación 1)» es instrucción del orquestador, no excepción a la regla del contrato, y vale para la bitácora privada, no para lo publicable. Consecuencia: el rótulo «medido en estación 1» de C1-23 también va con nombre neutro (p. ej., «estación CPU-only de 4 núcleos, contenedor 4 CPU / 5 GB»).

### C1-40 — **PROCEDE**

- **Opción:** A (MI-14), con la prueba determinista de 0 ejecuciones sin aprobación en Cableado/; B queda como variante a medir, no como descartada

- **Fundamento:** E1 de X2 verificado: D1 inventa o corrige el CP en 10/10 y D6 borra sin confirmar en 10/10 (qwen3.5:4b, N = 10; R-LLM incompleto, ver C1-26). La evidencia muestra que una herramienta de escritura sin control falla. No discrimina entre «aprobación» y «no ofrecer la herramienta», porque las dos eliminan la falla observada. A se apoya en API que existe y no es experimental (S-sonda2: ApprovalRequiredAIFunction y ToolApprovalRequestContent sin [Experimental]) y en E4 explícitas (LLM01:2025, MCP Tools «human in the loop»). B se apoya en LLM06 (E4), pero su pieza central, AccionPropuesta, no está compilada ni probada, y su seguridad es PC-13 (C). Con la evidencia de hoy, A está respaldada en el nivel que declara y B no.

### C1-41 — **PROCEDE**

- **Opción:** B: 4b provisional y comparación punta a punta D1–D6 con criterio escrito antes de correr

- **Fundamento:** AD-S1 verificado: qwen3.5:2b da 10/10 y qwen3.5:4b 10/10 en la misma tarea de sinónimo con herramienta (T 0,7, semillas 1..10; digests en 02-info.jsonl: 2b 0689d440…, 4b d8b0f5e9…). La afirmación «el 4b es el único que interpreta sinónimos» quedó comparada sólo contra el 0.5b. Con un competidor de la misma familia que empata, la evidencia sostiene «la familia qwen3.5 con tools», no «el 4b». Elegir el 4b es criterio propio legítimo, pero tiene que rotularse provisional hasta una comparación punta a punta con criterio previo. Las paredes de AD-S1 no permiten concluir sobre latencia.

### C1-42 — **PROCEDE**

- **Opción:** B en la redacción («no se midió en estación 1; el contenedor está limitado a 4 CPU / 5 GB»); el MoE 35b-a3b queda pendiente de PC-07

- **Fundamento:** Las dos cifras son E1: 13,2–21,9 tok/s de prompt (O3b/O5) y 18–20 (experto), más el límite del contenedor de 4 CPU / 5 GB por inspección (X4). Pero nadie corrió un ≥ 7B en estación 1, así que la causa de «no corre» no está medida: la velocidad de prompt hace lento, no imposible, y la memoria de 5 GB con dos modelos cargados es plausible pero no observada. La única frase con el nivel de evidencia que declara es la de B. El MoE 35b-a3b en estación 2 es PC-07 (C) y no puede usarse todavía como argumento. Sobre la vía (mesa o REED-16 §12 fila 4) no hay cuestión probatoria.

### C1-43 — **PROCEDE**

- **Opción:** B: sostener MI-01 con el argumento de diseño, no con la tasa; EA-6 se corrige a N = 1 para A

- **Fundamento:** Verificado en salida-real.txt: A tiene una corrida ([R3]), B tiene 3/5 en una pregunta y 5/5 en otra. Con N = 1 no hay tasa de A que comparar, y los intervalos de Wilson de B con N = 5 se superponen con cualquier valor plausible de A. EA-6 no respalda «A por defecto» como afirmación empírica. La vía C sólo corrió con un doble (salida-fake.txt l. 27).

### C1-44 — **PROCEDE**

- **Opción:** B (AH-02): sin juez en la demo de estación 1; se enseña el método; si se corre en otra estación, acuerdo k/n con intervalo y nunca como compuerta

- **Fundamento:** B trae E4 (advertencia oficial de bajo desempeño con modelos chicos o locales) y aritmética E1 (IC95 de unos ±0,17 con 10–20 casos). A no trae fuente para «10–20 es lo mínimo», que es criterio propio sin respaldo, y el costo del juez en estación 1 es PC-08 (C). Un juez sin calibrar con N chico no puede ser compuerta: el contrato exige tasas observadas, no veredictos.

### C1-45 — **PROCEDE**

- **Opción:** B: ejemplos 01 y 06; en la demo, como mucho, variante rotulada «sin num_ctx»

- **Fundamento:** E4 verificado (docs.ollama.com/api/openai-compatibility, consultada el 2026-10-28T09:49, cita literal): «The OpenAI API does not have a way of setting the context size». Con el selector /v1 en la composición por defecto, M10 (num_ctx explícito) y MI-18 (prompt_eval_count contra el largo esperado) no se pueden cumplir en esa rama. El argumento de A, que Application no cambia (R-C14, cableado), es E1, pero se prueba igual en los ejemplos 01 y 06 sin romper M10.

### C1-46 — **PROCEDE**

- **Opción:** otra: ninguna de las dos tiene ventaja probatoria; vale cualquiera con el contenido de C1-12 obligatorio

- **Fundamento:** Desde la evidencia, la forma no se decide: X1 [B], O4 y S-sonda2 prueban el contenido (Scoped crea un HttpClient por scope; el Singleton pierde la sesión con ValidateScopes=false), no dónde se escribe. Lo exigible es que el contenido de C1-12 esté entero en el lugar que se elija, con sus E1 citados y la corrección de redacción de C1-12 (pérdida de la sesión, no mezcla probada).

### C1-47 — **PROCEDE**

- **Opción:** otra: A (sincrónico con streaming y cancelación; segundo plano sólo en CTX-PROD) más eventos de etapa durante el bucle de herramientas (de B)

- **Fundamento:** Las dos posiciones tienen respaldo y no se excluyen. El E4 de CAT-OP (Agent Framework, Background responses, ms.date 2026-09-24: «only agents that use the OpenAI Responses API support background responses») descarta AllowBackgroundResponses con Ollama. La observación de ABOGAD-06 la confirma S-sonda1: el pedido con herramientas encadena orchestrate_tools → chat → execute_tool → chat, y en los tramos intermedios no hay texto para transmitir. El streaming de tokens solo deja esos tramos sin señal.

### C1-48 — **INSUFICIENTE**

- **Opción:** otra: decidir pieza por pieza con la tabla de C1-05, quedando en la demo sólo lo que alguna afirmación de la guía necesita como E1

- **Fundamento:** El perímetro es una decisión de alcance y ninguna posición la sostiene con evidencia de su nivel. La E2 de A sobrelee 03 §2: CTX-PROTO dice que en el prototipo «se tolera» no determinismo y falta de observabilidad, no que la demo deba excluir controles. B no tiene inventario de costo (piezas, líneas, tiempo de prueba en la estación). Los dos piden ordenar la votación antes de los parches y en eso tienen razón. Para decidir hace falta la lista D1–D7 → ESC → CTX (C1-05) con, por pieza, qué afirmación de la guía necesita esa pieza como E1. Lo que ninguna afirmación necesita puede ir a Examples/.

### C1-49 — **PROCEDE**

- **Opción:** otra (Formal): tres vías y orden como criterio de diseño sin apoyarse en EA-6; C rotulada «sólo con doble»

- **Fundamento:** Las tres vías existen como API y compilan (EA-5), pero «A por defecto» no tiene respaldo empírico (C1-43: A con N = 1). C sólo corrió con un doble. Desde la evidencia: tres vías como criterio de diseño, rotulado como criterio propio. C se rotula «no ejecutada contra modelo» hasta que corra. La posición de C (§5 o §6) es didáctica y no la decido yo.

### C1-50 — **PROCEDE**

- **Opción:** otra: la propuesta con qwen3.5:4b rotulado provisional (alternativa del abogado) y la dimensión como valor por defecto configurable

- **Fundamento:** Embeddings de 1024 con E1 (R1 por .NET, Sondeo §R.3) y E4 (model card: 32–1024). Razonamiento apagado y 0.5b como humo, con E1. El 4b como único candidato no se sostiene después de AD-S1 (C1-41). Formal tiene razón en que 1024 es la dimensión por defecto y no una constante (C1-65).

### C1-51 — **PROCEDE**

- **Opción:** otra (Operación): sólo P-03/P-07, contenedor bajo demanda con R-LLM y límites registrados; motivo reescrito como «no medido en estación 1»

- **Fundamento:** La justificación del pedido está mal derivada (C1-42: causa no medida). Las mediciones que se piden (≥ 7B, juez) no tienen hoy evidencia en ninguna estación, así que lo que no se mida tiene que quedar «no medido» y no desaparecer. Operación agrega un dato con E2 que hay que ponderar: estación 2 es el respaldo de contingencia. Que el sondeo registre versión, digest y límites es lo que hace citable la corrida.

### C1-52 — **PROCEDE**

- **Opción:** otra (Verificación/Arquitectura): test por reflexión en Cableado/, reglas por capa, caso rojo de R4; ejemplo y demo

- **Fundamento:** R4 verificado: la mutación (global using Microsoft.Extensions.AI y una propiedad con nombre calificado) da 0 archivos y el script no sale con error, así que es un falso negativo. Sin Copia/ el script falla. El grep no prueba la regla que enuncia: con él, la afirmación «la arquitectura está verificada» sería S1. Hace falta una prueba que falle sobre lo compilado, con la mutación de R4 como caso rojo.

### C1-53 — **PROCEDE**

- **Opción:** otra (Senior/Arquitectura): copia = cierre de compilación verificado con dotnet build + diff -r; LocalidadesController declarado como deuda heredada

- **Fundamento:** La copia literal es verificable, pero hoy «verificable por diff» no prueba que compile (C1-19, E1 de SENIOR-07). Con la condición del cierre de compilación con dotnet build, la propuesta queda sostenida por E1. «H1–H5 sin endurecer» está condicionado a C1-38 y a la corrección del corpus de C1-17.

### C1-54 — **PROCEDE**

- **Opción:** propuesta

- **Fundamento:** No hay E1 específico, pero tampoco evidencia en contra. El argumento es E2 contra D-01 (c) y coincide con la regla de capas que R4 manda a probar: un puerto de armado de prompt en Application metería tipos de MEAI, que es lo que la prueba de arquitectura de MI-04 detectaría. Criterio propio con respaldo coherente.

### C1-55 — **PROCEDE**

- **Opción:** propuesta, condicionada a C1-24 (oro sobre el corpus real con no respondibles); sin conclusión comparativa hasta correrla

- **Fundamento:** La comparación de las dos estrategias con el mismo oro es la forma correcta de producir evidencia, pero hoy no hay oro válido: el 8/8 es sobre paráfrasis (C1-24). El costo de AyudaContextoFijo es E1 (O5: unos 25–70 s por pregunta en la estación). La propuesta procede sólo si la comparación se corre sobre el oro rehecho. Mientras tanto la guía no puede afirmar cuál gana.

### C1-56 — **PROCEDE**

- **Opción:** propuesta, con las métricas de CAT-FO-03 y el conjunto de AH-02

- **Fundamento:** Procede con las definiciones de C1-24 (hit@k, recall@k y MRR@k con azar k/12), porque sin ellas el candidato no tiene métrica definida. El matiz Formal/AH-02 es compatible: no respondibles en el conjunto y fuera del promedio de recall, medidas como abstención. E-B5 como contraejemplo es E1.

### C1-57 — **PROCEDE**

- **Opción:** propuesta

- **Fundamento:** RD-PO-3 (I-06) es vinculante: caso único Movilidad Urbana. Los genéricos de N4 (GuessNumber, GetWeather, EchoTool) contradicen esa directiva. Un diff mínimo 4.1 → 4.2 es verificable como E1 (compila el antes y el después).

### C1-58 — **PROCEDE**

- **Opción:** propuesta con las condiciones de C1-16, C1-32 y C1-35

- **Fundamento:** La regla «LangGraph por HTTP sólo si se levanta; si no, ‹no ejecutado›» es exactamente lo que el contrato exige para no presentar como corrido lo que no corrió. Las condiciones de C1-16, C1-32 y C1-35 tienen E4/E2 propias.

### C1-59 — **PROCEDE**

- **Opción:** otra: M1–M12 + M13 + M14 + largo máximo de entrada, M11 en tres tipos de aserción, términos del corte definidos

- **Fundamento:** M1–M12 sin M13, M14 y largo de entrada deja sin control lo que las fuentes E4 verificadas (S-MCP1/2, LLM01:2025, playbook #8) señalan explícitamente. M11 tiene que reformularse porque hoy admite «verde» sin medición (C1-26). CAT-FO-06 (E2) muestra que «pocas líneas», M5, M7 y M10 no tienen valor ni definición: un criterio de corte sin definición no se puede verificar.

### C1-60 — **PROCEDE**

- **Opción:** propuesta, con la re-consulta de C1-33 el día de la publicación

- **Fundamento:** E1 de consulta a NuGet con fecha (X0, R1, R2, S-nuget-2026-10-28). Ojo: GA no quiere decir sin vulnerabilidades: K6 muestra NU1902/NU1903 transitivos en EF Core SqlServer. La compuerta de C1-33 tiene que acompañar este criterio.

### C1-61 — **PROCEDE**

- **Opción:** alternativa: sólo ejemplos 01 y 06 (en la demo, a lo sumo como variante «sin num_ctx»)

- **Fundamento:** Mismo fundamento que C1-45: la doc de Ollama (E4 literal, 2026-10-28) excluye num_ctx por /v1, y eso deja sin cumplir M10 y MI-18 en la rama /v1 de la demo.

### C1-62 — **PROCEDE**

- **Opción:** propuesta (según C1-40, opción A)

- **Fundamento:** X2 D1 (10/10 inventa o corrige el CP; 2/10 pasa las reglas) prueba que la validación protege la forma, no la exactitud: el alta sin confirmación persiste datos inventados. La alternativa (reglas más estrictas) no resuelve un CP inventado de 4 dígitos que es válido. Ver C1-40 para la forma.

### C1-63 — **PROCEDE**

- **Opción:** propuesta, condicionada al orden que salga de C1-37

- **Fundamento:** E1 doble: R6 reproduce X1 y O4 [A] da 0 spans con nombres distintos y 1 con el mismo. O4 muestra además que con sourceName propio el Meter queda con los dos nombres (Experimental.Microsoft.Extensions.AI y MovilidadUrbana.AI): la constante tiene que usarse en AddSource y AddMeter, y la guía tiene que decir qué métricas quedan bajo el nombre por defecto.

### C1-64 — **PROCEDE**

- **Opción:** alternativa: demo sin juez en estación 1; método enseñado y «no medido»

- **Fundamento:** Igual que C1-44: «10–20 casos calibran» no tiene fuente, el IC95 con ese N ronda ±0,17 y hay advertencia oficial (E4) sobre jueces chicos. El costo en la estación es PC-08 (C).

### C1-65 — **PROCEDE**

- **Opción:** propuesta con VectorStoreCollectionDefinition y la invariante de Formal, probada también en Cableado/ con el generador falso (Senior)

- **Fundamento:** E1: CS0182 al intentar [VectorStoreVector(dim de configuración)] (run-1 del implementador); S-sonda3 confirma VectorStoreVectorProperty(name, dimensions) para la definición en tiempo de ejecución. E4: MRL 32–1024 (model card). La invariante de Formal («largo devuelto = dimensión declarada») es la verificable; «= 1024» la ata a un modelo.

### C1-66 — **PROCEDE**

- **Opción:** otra (Experto IA): comparar contra el largo medido con el mismo modelo, presupuesto = num_ctx − salida; diferencia como error

- **Fundamento:** E1: con num_ctx 8192, InputTokenCount = 4098 y FinishReason = stop (numctx-real.txt): sin la comparación, el truncado es silencioso. Pero el «largo esperado» tiene que medirse con el tokenizador del mismo modelo (vocab_size distinto, E4). Si no, la comparación da falsos errores. Operación confirma por E1 que no hay una constante de caracteres por token (3,07 a 4,8).

### C1-67 — **NO_PROCEDE**

- **Opción:** alternativa (conceptual) hasta que PC-14 se cierre; la variante Localidad.Nombre, con un E3 validado por AH-01

- **Fundamento:** Un campo Comentario hipotético no puede tener E1 (no existe en el código), y contradice la copia literal verificable de MI-05 (E2 de Edición). La guía terminaría con un ejemplo que no se puede ejecutar ni comparar por diff. La variante de Didáctica (Localidad.Nombre devuelto por una herramienta de lectura) es mejor candidata, pero su validez como amenaza es PC-14 (C): entra sólo si AH-01 la escribe como E3.

### C1-68 — **PROCEDE**

- **Opción:** propuesta, con las condiciones de C1-15 y la vía móvil rotulada «no ejecutada» hasta el ciclo de demo

- **Fundamento:** La página Blazor cubre SUP-05 (E2) y su propagación de sesión tiene un patrón real en la Web (C1-15). La vía móvil no se puede probar en este ciclo, porque teléfono de pruebas y emuladores están fuera, así que no puede declararse cubierta: queda «no ejecutado» hasta el ciclo de demo.

### C1-69 — **PROCEDE**

- **Opción:** propuesta, también en EncuestaMcpTools

- **Fundamento:** Implementable con E1 (S-sonda4: proyección de Medios y agregado en memoria, GroupBy(Motivo) en el servidor, filtro por SessionId). LLM02:2025 (E4, genai.owasp.org, 2026-10-28) respalda la frontera. El tamaño mínimo de celda es PC-15 (C) y va como advertencia de CTX-PROD, sin cifra.

### C1-70 — **PROCEDE**

- **Opción:** propuesta con la plantilla R-LLM de VERIFI-05 y el archivo compilable por snippet

- **Fundamento:** Hoy la ejecución contra el modelo tiene R-LLM incompleto en X2, X3 y B (C1-26). Asignar dueños con la plantilla R-LLM obligatoria y archivo compilable por snippet hace que cada afirmación llegue con su evidencia completa.

### C1-71 — **PROCEDE**

- **Opción:** otra: indiferente desde la evidencia; contenido de C1-12 obligatorio, con «pierde la sesión sin error» y no «mezcla sesiones»

- **Fundamento:** Igual que C1-46: la evidencia (X1 [B], O4, S-sonda2) fija el contenido, no la forma.

### C1-72 — **PROCEDE**

- **Opción:** otra: dos partes; (a) resuelta con la E4 de CAT-OP + eventos de etapa; (b) el umbral no se fija hasta definir la métrica (C1-02) y medir con N suficiente

- **Fundamento:** Tiene que votarse en dos partes. (a) La E4 de Agent Framework (ms.date 2026-09-24) cierra la vía de segundo plano del proveedor con Ollama: queda sincrónico con streaming, cancelación y eventos de etapa (C1-47). (b) Con 2/10 y Wilson [0,06; 0,51], y con la métrica todavía sin definición estable (C1-02), cualquier umbral sería un número sin evidencia. Se investiga después de definir la métrica, y mientras tanto la guía dice «no medido».

### C1-S4 — **PROCEDE**

- **Fundamento:** Las cinco correcciones son de forma y cada una tiene su E1/E2 en el hallazgo de origen: anclas verificables, doc_id que exige REED-16 §6.2 (frontmatter con doc_id), literal ya decidido por R-C11, acompañantes de evidencia y nota de historia sin tocar el archivo. Ninguna cambia una afirmación técnica. Sólo para el punto 4: renombrar scripts ya citados en la bitácora rompe las referencias existentes. Tiene que hacerse por copia con el nombre nuevo, sin mover el original, para respetar SÓLO AGREGADO.
