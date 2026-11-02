---
doc_id: MESA-16-C2-INF-IA
doc_type: informe-de-especialista
title: Informe del especialista en IA/LLM sobre la estructura aprobada v1
status: ciclo 2, revisión a ciegas
objeto: Bitacoras/04-Plan-De-Integracion.md (v1)
fecha: 2026-10-26
---

# Informe del especialista en IA/LLM — Ciclo 2

**Mandato**: corrección conceptual después de los parches del ciclo 1. Escaleras de conocimiento y de agencia, CAG/RAG, evaluación y límites de un modelo chico en CPU.

**Contra qué se contrastó**: la v1 completa; el informe IA del ciclo 1 y la consolidación del ciclo 1 (para no repetir H-001…H-063 ya corregidos); N3b (§0 punto 4, X2, X3, X4b, §9); N4 §2.1 y l. 452; N6 §1.1 y l. 249; Sondeo §3; las clases `LocalidadPolicy` y `EncuestaPolicy` de `Lab-E2E.WebBlazor` leídas con `git show 8fb4c3a:…`. No leí los informes de otros especialistas de este ciclo.

Severidades y niveles de evidencia: los de M§3. Formato: M§8.

---

## Hallazgos

### IA2-01 · S2 · El principio rector afirma que el modelo «no tiene dónde inventar» el dato, y el propio ejemplo 03 mide que sí puede

- **Ubicación**: §A.4, punto 1 (l. 139); §F.7 (l. 794); ADR-08 (§13.9).
- **Afirmación**: el parche de H-004 hizo anulable `Habitantes`, pero el texto sacó una conclusión que no se sigue. Un `int?` le da al modelo un lugar para **no** inventar. No le quita el lugar para inventar: puede devolver `30000` igual. Y la regla `HabitantesValidos` sólo detecta el `null`, no un número plausible inventado. El ejemplo 03 lo reconoce cuando define una «tasa de invención» (propuestas con `Habitantes != null` sobre entradas que no traen el dato). Si la invención fuera imposible, esa tasa sería 0 por construcción.
- **Evidencia**: E2.
  - §A.4 l. 139: «La ausencia la detectan las reglas (`LocalidadRules.HabitantesValidos(null)` es `false`) y la aplicación pide el dato. El modelo no tiene un lugar donde inventarlo.»
  - §F.7: «la UI pide el dato: el modelo no tiene dónde inventarlo».
  - §E.2, fila 03: «**tasa de invención** = propuestas con `Habitantes != null` sobre las 4 entradas que no lo traen».
- **Confianza**: 0,9.
- **Impacto si no se corrige**: la guía enseñaría, como principio rector, una garantía que el código no da. El lector daría por cerrada la fabricación de datos con sólo cambiar el tipo.
- **Dirección**: hay que distinguir dos cosas. Lo que **garantiza el código**: un `null` nunca se guarda, y un valor fuera de rango se rechaza. Lo que **sólo se mide**: que el modelo devuelva `null` cuando falta el dato. Lo segundo es una tasa, no un invariante. Si se quiere una garantía, tiene que venir del código: por ejemplo, la confirmación del usuario de los campos propuestos, o una comprobación de que el número aparece en el texto de entrada. Lo mismo vale para la encuesta (edad, distancia, minutos).

### IA2-02 · S2 · Los escalones 1 y 3 de agencia no tienen una frontera operativa, y el 11/PD-6 queda en el 3 por un motivo que no es autonomía

- **Ubicación**: §B.3 (l. 250–252, 268, 275–277); §F.1 PD-6; §E.2 fila 11; §8.7; OA-D6.
- **Afirmación**: el plan dice que el escalón mide «cuánto decide el modelo». Pero ubica el 11 y el PD-6 en el escalón 3 «porque el agente conserva la conversación entre dos peticiones». Conservar el historial es estado, no autonomía. La tarea de 11 (listar → id → eliminar con aprobación) es la misma cadena acotada que `UseFunctionInvocation` resuelve en el escalón 1 con `MaximumIterationsPerRequest`. En los dos casos el modelo «dirige el bucle» de herramientas. N4 dice que `ChatClientAgent` es un envoltorio sobre el mismo `IChatClient`. Así, la etiqueta G3, «el modelo dirige el bucle», no separa el 3 del 1. El ciclo 1 sacó la aprobación de los escalones (H-015), pero dejó el escalón 3 definido por el artefacto de MAF que se usa, no por la autonomía. Es el mismo error que se corrigió con el workflow («el escalón no es de inclusión»), aplicado al agente.
- **Evidencia**: E2.
  - Plan l. 268: «El escalón mide **cuánto decide el modelo** (autonomía), no qué tan difícil es la API».
  - Plan l. 277: «PD-6 en el 3, porque el agente conserva la conversación entre dos peticiones (ADR-12), no por la aprobación».
  - Plan l. 250 y 252: «1 · Llamada con herramientas UseFunctionInvocation» frente a «3 · Agente: el modelo dirige el bucle».
  - N4 l. 452: «en código, `ChatClientAgent` es un envoltorio sobre el mismo `IChatClient`», y «agente cuando "la tarea es abierta o conversacional"» [F01].
  - N4 l. 143: «Agentes autónomos: bucle con feedback del entorno para problemas abiertos».
- **Confianza**: 0,75.
- **Impacto si no se corrige**: OA-D6 («elegir entre función, llamada con herramientas, workflow y agente») no tiene un criterio que el lector pueda aplicar. El caso que la guía usa para el escalón 3 enseña que «agente = conservar la conversación», cuando la conversación se conserva en el escalón 1 con el historial de mensajes.
- **Dirección**: definir la frontera entre el 1 y el 3 con algo observable. Por ejemplo: el escalón 1 es un pedido acotado, con herramientas fijadas por el código y un tope de iteraciones; en el escalón 3 la tarea es abierta y el modelo decide cuándo terminó, qué subobjetivos encara o qué herramientas pide en varios turnos. Después hay dos caminos para 11/PD-6:
  - Reubicarlos en el escalón 1 con «estado de la conversación» como dimensión aparte, igual que la aprobación, y declarar que MAF se usa como empaque de la sesión.
  - Si se quedan en el 3, darles una tarea en la que el modelo decida de verdad más que en el 1.

### IA2-03 · S2 · El 12 cambia dos variables a la vez, y su verificador LLM hace una cuenta que el código ya hace

- **Ubicación**: §E.2 fila 12; §B.3 l. 277 («instancia positiva»); §A.1 l. 58; OA-D7; PR-4 y PR-5 en §D; P-01.
- **Afirmación**: hay dos defectos.
  - **Confusión de factores.** A es un agente con `resumir_encuesta`. B es un workflow secuencial con dos agentes. Entre A y B cambian a la vez el escalón (3 o 1 contra 2) y la cantidad de agentes (uno contra dos). Ninguna diferencia de costo o de cifras se puede atribuir a «varios agentes» (OA-D7), ni a «workflow».
  - **El verificador es una función.** El verificador de B «contrasta los porcentajes del resumen con los de `ResultadosDeEncuestaService`». Eso es, letra por letra, el oráculo determinista del ejemplo (±1 punto). Por el criterio de salto que la guía adopta («If you can write a function… do that instead»), ese nodo es del escalón −1, no un agente.
  - **Resultado.** La única instancia positiva del escalón 2 queda declarada a la vez como positiva (l. 277) y como «sube más de lo necesario» (l. 58 y README). Así, H-017 sigue sin resolverse en el fondo.
- **Evidencia**: E2.
  - Fila 12: «(B) un **workflow secuencial** (`BuildSequential`) de redactor + **verificador de cifras**, que contrasta los porcentajes del resumen con los del caso de uso y corrige» y «Oráculo: los porcentajes del texto coinciden (±1 punto) con `ResultadosDeEncuestaService`».
  - Plan l. 58: «La variante de dos agentes de 12 resuelve una tarea que un agente resuelve».
  - Plan l. 277: «La **instancia positiva** del escalón 2 es 12».
  - Plan l. 55 (MAF F01): «If you can write a function to handle the task, do that instead».
- **Confianza**: 0,8.
- **Impacto si no se corrige**: la guía mostraría como buen uso de un workflow un patrón (un LLM que verifica una cuenta) que su propio principio rector desaconseja, y respondería «¿uno o varios?» con una comparación que no aísla la variable.
- **Dirección**:
  - **Instancia positiva del escalón 2**: un camino fijo en código que mezcle nodos. Un redactor LLM, después un executor de código que compara las cifras y, si no coinciden, vuelta al redactor con el error (evaluador-optimizador con evaluador determinista; N4 F21). Ahí el workflow se justifica por el camino fijo y el reintento. No hace falta un segundo agente.
  - **«Uno o varios»**: compararlo con el escalón fijo (por ejemplo, el mismo workflow con uno o con dos nodos LLM), o declarar que el 12 no responde OA-D7 y ajustar ese OA.

### IA2-04 · S2 · El oráculo de la afirmación central de 07 no está definido para 5 de los 12 fragmentos, y el texto que se vectoriza no está fijado

- **Ubicación**: §E.2 filas 06 y 07; §F.6; §7.5; §10.7.
- **Afirmación**: el oráculo de 07 pide «el valor que fija el literal de la `*Policy` citada (extraído del propio literal en código)». En `8fb4c3a`, cinco de los doce literales no fijan ningún valor extraíble:
  - `RequisitoDeLaProvincia`: «Una de las provincias del catálogo.»
  - `RequisitoDeLaLocalidad`: «Una de las localidades cargadas en el ABM.»
  - `RequisitoDeLosMedios`: «Al menos uno.», con el número en palabras.
  - `RequisitoDeLaFrecuencia`: «Con qué asiduidad usa esos medios.»
  - `RequisitoDelMotivo`: «El motivo principal del viaje.»

  Otros cuatro fijan dos valores (rangos). Así, «tasa k/12 de afirmación correcta» no se puede calcular como está escrita. Además, para responder sobre provincia o frecuencia hacen falta los valores de `Catalogos`, que no están en el corpus: esas preguntas son en realidad no respondibles desde los fragmentos.

  El texto que se vectoriza tampoco está fijado. Un vector de «Al menos uno.» sin rótulo no tiene contenido semántico. N6 lo resolvió con un prefijo («Código postal: » + literal), pero el plan v1 no lo dice, y el hit rate@k de 06 va a depender de esa decisión no declarada.
- **Evidencia**: E3. Contraejemplo con anclas literales:
  - `git show 8fb4c3a:src/MovilidadUrbana.ApiWeb/Application/Encuestas/EncuestaPolicy.cs`, l. 18–30: los cuatro literales sin valor citados arriba más `RequisitoDelMotivo`.
  - `…/Localidades/LocalidadPolicy.cs`, l. 18: «Una de las provincias del catálogo.»
  - N6 l. 249: `Embedding = "Código postal: " + LocalidadPolicy.RequisitoDelCodigoPostal`.
  - Plan, fila 07: «el valor que fija el literal de la `*Policy` citada (extraído del propio literal en código, p. ej. el número de dígitos del CP)».
- **Confianza**: 0,85.
- **Impacto si no se corrige**: los constructores van a inventar cada uno su oráculo para esos 5 fragmentos, o los van a contar como aciertos vacíos. La cifra de 07 y la de 06 no serían comparables entre corridas ni defendibles en §14.5.
- **Dirección**:
  - Que el conjunto de oro (§10.7) declare, por pregunta, qué se verifica: valor esperado, valor del catálogo o «sin valor verificable». La tasa se informa sobre el M efectivo.
  - Que las preguntas cuya respuesta exige `Catalogos` se clasifiquen como no respondibles cercanas, o que el corpus sume las etiquetas del catálogo (N6 §1.1 ya las nombra como texto propio).
  - Que el texto vectorizado (rótulo del campo + clase + literal) quede fijado y versionado como parte del corpus, y que 06 lo diga.

### IA2-05 · S3 · Los oráculos de 08, 11, 15 y 16 dependen de datos que el registro R-LLM no guarda, y el de 08 deja pasar un conteo inventado

- **Ubicación**: §E.1, «Esquema» del R-LLM (l. 618); filas 08, 11, 15 y 16.
- **Afirmación**: el esquema guarda `entrada` y `salida`, pero no los fragmentos recuperados ni las llamadas a herramientas con sus argumentos y resultados. Sin eso:
  - **08**: no se puede auditar «los números que devolvieron las herramientas en esa corrida».
  - **11**: no se puede auditar la «cadena correcta (listar → id correcto → pedido)».
  - **16**: no se puede auditar «el documento malicioso está en el top-k recuperado (registrado)».
  - **15**: no se puede correr `GroundednessEvaluator`, que necesita el contexto, sobre la «entrada fija: el registro R-LLM de 07».

  Además, el parche que hizo que `listar_localidades` devuelva ids (H-011) debilitó el oráculo de 08 (H-031). Si en la corrida se llamó a `listar_localidades`, los ids 1…n quedan en el conjunto de números permitidos, y un conteo inventado ≤ n pasa. Un conteo escrito en palabras («hay dos») no lo toma `\d+` y también pasa.
- **Evidencia**: E2 + E3.
  - Esquema l. 618: «`fecha`, `ejemplo`, `paso`, `entrada_id`, `entrada`, `salida`, `modelo`, … `oraculo` (nombre), `resultado`». No hay ningún campo de contexto ni de herramientas.
  - Fila 08: «el conjunto de números de la respuesta está contenido en el de números que devolvieron las herramientas en esa corrida (regex `\d+`)».
  - §F.4: «devuelve **id, nombre y provincia**».
  - Contraejemplo: la sesión con 3 localidades (ids 1–3) y la pregunta «¿cuántas hay en Chaco?». El modelo llama a `listar_localidades` y responde «hay 2» sin llamar a `contar_localidades`: el 2 está entre los ids y la corrida pasa. Si responde «hay dos», pasa siempre.
- **Confianza**: 0,8.
- **Impacto si no se corrige**: AC-3b exige «oráculo aplicado» sobre un registro que no permite volver a aplicarlo. 15 no se puede construir como está especificado, y la tasa «sin invención» de 08 sale optimista.
- **Dirección**: sumar al esquema los ids y puntajes de lo recuperado, y las llamadas a herramientas (nombre, argumentos y resultado), todo bajo AC-7. El oráculo de 08 tiene que comparar el conteo afirmado con el **campo** `cantidad` de la herramienta que corresponde, normalizar los números escritos en palabras y excluir los ids.

### IA2-06 · S3 · La calibración del juez en 15 no prueba el sesgo que declara, y su umbral contradice la regla estadística del propio plan

- **Ubicación**: §10.6; §E.2 fila 15; OA-O3.
- **Afirmación**: hay dos problemas.
  - **La calibración no toca el sesgo declarado.** Los 10 casos de calibración están «anotados a mano» (5 buenos y 5 malos conocidos). El sesgo que el plan declara es el autofavorecimiento, y ese sesgo aparece sobre las salidas **del propio modelo**, no sobre textos escritos por una persona. Pasar la calibración no autoriza a interpretar los puntajes sobre las salidas de 07, que es justo lo que se evalúa.
  - **El umbral no separa del azar.** El umbral de 8 de 10 tiene un intervalo de Clopper-Pearson al 95 % de [0,44; 0,97]. Es compatible con un juez cercano al azar (0,5) en una tarea balanceada. Y el plan exige ese intervalo para toda tasa (§E.1).
- **Evidencia**: E2 + cálculo.
  - Fila 15: «los 10 casos de calibración anotados a mano (5 buenos, 5 malos conocidos)» y «en al menos 8 de 10».
  - §E.1: «La **tasa** es k/M con su intervalo Clopper-Pearson al 95 %».
  - N0b B13, citado en §10.6: «autofavorecimiento».
  - Cálculo: P(X ≥ 8 | n = 10, p = 0,444) ≈ 0,024, así que el límite inferior es ≈ 0,44.
- **Confianza**: 0,7.
- **Impacto si no se corrige**: OA-O3 («decir si está calibrado y qué sesgo declara») se enseña con un protocolo que da «calibrado» a un juez que puede estar cerca del azar y que no mira la condición de sesgo.
- **Dirección**: que la calibración incluya salidas reales de `qwen3.5:4b` en 07, anotadas por una persona a ciegas, junto a las escritas a mano. Que el resultado se informe con su intervalo. Que la guía diga que, con 10 casos, la calibración sólo puede **descartar** un juez (si falla), no habilitarlo con confianza.

### IA2-07 · S3 · El 05 mide la caché de prefijo en otra versión del motor y en otra arquitectura de modelo que las del laboratorio, y el plan no lo declara

- **Ubicación**: §E.2 fila 05; §6.3; §5.7; §F.6 (imagen 0.40.11).
- **Afirmación**: el ciclo 1 cambió la imagen del Ollama propio a `ollama/ollama:0.40.11` con un argumento que vale **para embeddings** (H-027: «para embeddings no hace falta igualar la versión»). Ahora 05 la usa también para medir la caché de prefijo de **chat**, y ahí el argumento no vale. X4b se corrió a propósito en 0.32.0-rc0, «la misma versión que el servidor de la LAN», porque el propio plan dice que en Ollama la caché es «comportamiento del motor, no contrato».

  A eso se suma la arquitectura. 05 usa `qwen2.5:0.5b`, un transformer puro. El modelo de todos los demás ejemplos es `qwen3.5:4b`, que N3b documenta como **híbrido** (capas de atención lineal `ssm.*`) y sobre el que deja abierta la hipótesis de que eso limita la reutilización del prefijo. El plan v1 no menciona esa diferencia en ningún lado.
- **Evidencia**: E2.
  - Fila 05: «**Ollama propio** `ollama/ollama:0.40.11` con `qwen2.5:0.5b`».
  - N3b l. 237: «en un Ollama propio en contenedor **de la misma versión** (0.32.0-rc0)».
  - N3b l. 441: «`qwen2.5:0.5b` (…, transformer puro)».
  - N3b §0 punto 4 (l. 45): «`qwen3.5:4b` es un modelo **híbrido** con capas de atención lineal […], lo que puede limitar la reutilización **(hipótesis, no verificada)**».
  - N3b §9 punto 2: comportamiento de la caché en híbridos, abierto.
  - `grep -n "híbrido" 04-Plan-De-Integracion.md`: sin resultados.
- **Confianza**: 0,7.
- **Impacto si no se corrige**: §6.3 y el recuadro de §5.7 pueden transmitir un ahorro de ~90 veces del prefijo estable (X4b) como si valiera para el modelo del laboratorio y para su servidor, cuando no se midió en ninguno de los dos. Es justo el tema que el PO pidió verificar (PR-8).
- **Dirección**: fijar para 05 la imagen 0.32.0-rc0 de X4b, o declarar 0.40.11 como otra versión del motor y volver a correr la medición. Rotular las cifras de 05 como «transformer puro, versión X». Agregar a §6.3 y §5.7 que la reutilización con `qwen3.5:4b` (híbrido) no está medida y que es una hipótesis abierta.

---

## Revisado y bien

1. **Estadística de las tasas (§E.1)**: la entrada distinta como unidad, la estabilidad aparte y los límites de Clopper-Pearson citados son correctos (10/10 → 0,025^(1/10) ≈ 0,69; 5/5 → ≈ 0,48). Las líneas base de azar de 06 también lo son (hit@3 = 3/12; MRR = H₁₂/12 ≈ 0,259). Resuelve IA-03 del ciclo 1.
2. **05 sólo en tiempos, con *nonce* al principio del prefijo y `estado_cache` registrado**: separa bien estrategia y motor, y resuelve IA-06 del ciclo 1, salvo lo que señala IA2-07 sobre qué motor y qué modelo.
3. **Aprobación como control transversal desde el escalón 1** (`ApprovalRequiredAIFunction` bajo `UseFunctionInvocation`, condicionado a DEP-09), **política de origen** (sin escrituras con contexto recuperado) y pedido de aprobación armado desde los argumentos resueltos: son conceptualmente correctos y resuelven IA-07 y IA-02 del ciclo 1 en lo que toca al contrato (id en la lectura, DEP-10 con salida de diseño).

## Solicitudes de convocatoria

- **Didáctica**: con IA2-02 y IA2-03, OA-D6 y OA-D7 pueden cambiar de redacción o de ejemplo. Que revise si la escalera, como se enseña en §3.2 y §8.1, sigue siendo legible con una frontera 1/3 operativa.
- **Operación y entrega**: el cambio de imagen de 05 (IA2-07) y los campos nuevos del registro R-LLM (IA2-05) tocan el arnés `verificar.sh` y la compuerta AC-7.
