---
doc_id: MESA-16-C1-INF-IA
doc_type: informe-de-especialista
title: Informe del especialista en IA/LLM sobre el plan de integración v0
status: ciclo 1, revisión a ciegas
objeto: Bitacoras/04-Plan-De-Integracion.md (v0)
fecha: 2026-10-26
---

# Informe del especialista en IA/LLM — Ciclo 1

**Mandato**: que lo que el plan dice sobre LLM, RAG, CAG, embeddings, agentes, tool calling, salida estructurada y evaluación de modelos sea correcto, y que tenga en cuenta los límites de un modelo chico (Qwen, en CPU). También LangGraph y los ecosistemas.

**Contra qué se contrastó**: Sondeo-Entorno; N3 (y su evidencia E3); N3b (§3.3, §3.7, X3, X4b y la verificación adversarial); N4 (§8); N5 (§4.6, §8.4); N6 (E1 y `N6-Evidencia/sonda-Program.cs`); N0b (B13, PG-5); I-02, I-03 e I-05.

Severidades y niveles de evidencia: los de M§3.

---

## Hallazgos

### IA-01 · S2 · El tipo de la salida estructurada obliga al modelo a inventar el dato que falta

- **Ubicación**: §E.2, fila `03-Salida-Estructurada`; §F.1, paso D2; §F.7.
- **Afirmación**: el plan da por hecho que, si el texto dice «no sé cuántos viven», el modelo va a devolver `Habitantes = 0` y que `LocalidadRules` lo va a rechazar. El tipo que viene de N6 declara `int Habitantes`, no anulable. Con ese esquema, el modelo está obligado a poner un número. Si pone uno plausible (por ejemplo, 30000), la propuesta pasa las reglas y se guarda un dato inventado. Ninguno de los criterios de prueba del plan detecta ese caso. El `0` de N6 E1 §[3] salió de un cliente falso guionado, no de un modelo.
- **Evidencia**: E3. Contraejemplo con anclas literales:
  - N6-Evidencia/sonda-Program.cs:94: `public record LocalidadPropuesta(string Nombre, string Provincia, string CodigoPostal, int Habitantes);`
  - N6 §4.0: «**Qué no prueba**: el comportamiento de Qwen. El modelo es un cliente falso guionado».
  - Plan: «"En Bella Vista, Corrientes, CP 3432, no sé cuántos viven" → propuesta tipada; las reglas rechazan habitantes ≤ 0».
- **Confianza**: 0,8.
- **Impacto si no se corrige**: el ejemplo enseña justo lo contrario del principio rector. La regla no puede atajar un dato inventado que cumple el formato, y la «tasa de JSON válido» va a dar bien aunque haya fabricación.
- **Dirección**: que el esquema pueda decir «no está en el texto» (campo anulable o marcador explícito), y que el adaptador traduzca la ausencia en «pedir el dato». El criterio de prueba tiene que medir la **tasa de invención**: de las entradas que no traen el dato, cuántas propuestas lo completan igual. La validez del JSON pasa a ser un dato secundario. Lo mismo vale para D2 y para `IExtractorDeEncuesta`.

### IA-02 · S2 · D6 y `07` piden una cadena de dos herramientas que el diseño no permite y que nadie midió

- **Ubicación**: §F.1 D6; §F.4 (`eliminar_localidad(id)`, `listar_localidades`); §E.3 fila `07-Agente-Con-Aprobacion`; §G.2 R-08.
- **Afirmación**: para resolver «Borrá Resistencia» con `eliminar_localidad(id)`, el modelo primero tiene que conseguir el id. Eso exige llamar antes a una herramienta de lectura y extraer el id de su resultado: dos llamadas encadenadas. Pero en la única ejecución que existe, `listar_localidades` devuelve nombres sin id. Además, sobre Qwen sólo se midió una llamada a **una** herramienta. La selección entre las cinco del §F.4, las cadenas de varios pasos, la aprobación y las orquestaciones nunca se corrieron contra Qwen. Todo eso, con el razonamiento apagado, que es la condición que el plan impone por latencia. R-08 reconoce el riesgo de calidad, pero no la imposibilidad de diseño ni la falta de una sonda previa.
- **Evidencia**: E3. Contraejemplo con anclas literales:
  - N6 E1 §[5]: `listar_localidades → ["[\"Corrientes (Corrientes)\",\"Resistencia (Chaco)\",\"Goya (Corrientes)\"]"]`.
  - N4 §8 punto 1: «tool calling, agente, aprobación y orquestación secuencial **compilan** [E02] pero no se ejecutaron contra Qwen».
  - Sondeo §3: una sola herramienta, `contar_localidades`.
- **Confianza**: 0,85.
- **Impacto si no se corrige**: D6, `07` y `17` pueden quedar inejecutables o con tasas cercanas a cero. La causa sería un contrato de herramienta mal pensado, no el modelo, y se descubriría recién al construir la demo.
- **Dirección**: dos cosas.
  - Rediseñar el contrato para que el modelo pueda llegar a la acción. Puede ser que la lectura devuelva id y nombre, o que la baja reciba nombre y provincia y el caso de uso resuelva la ambigüedad.
  - Antes de construir, correr una sonda R-LLM con el conjunto completo de herramientas armado y razonamiento apagado. La sonda mide selección correcta, argumentos válidos y cadena de dos pasos. Si da baja, se decide con datos si el paso usa razonamiento encendido o menos herramientas por pedido.

### IA-03 · S2 · Con `temperature` 0 y la misma entrada repetida, la «tasa en N corridas» no está definida

- **Ubicación**: §E.1, «Corridas contra el modelo (R-LLM)»; criterios de `01`–`17`; §F.8; §F.10 AC-3; P-07.
- **Afirmación**: el plan fija `temperature` 0 y `seed` y, al mismo tiempo, pide tasas en N=10 o N=5 sobre «la» entrada de cada ejemplo. Con decodificación prácticamente determinista, repetir la misma entrada no muestrea cómo se comporta el modelo. La única variación medida con `temperature` 0 vino del camino frío frente al cacheado del servidor, que es un artefacto de infraestructura. Una tasa así puede salir 10/10 o 0/10 sin decir nada del criterio que el lector necesita: cómo responde el modelo ante pedidos distintos del mismo tipo. Además, cada constructor la va a interpretar a su manera.
- **Evidencia**: E2. Anclas literales:
  - Plan §E.1: «registran modelo, digest, `temperature` 0, `seed` si el proveedor la respeta, […] y **tasa en N corridas** (N = 10 en básico, 5 en intermedio y avanzado».
  - N3b §9 punto 8: «dos peticiones idénticas con `temperature` 0 dieron respuestas distintas».
  - Verificación de N3b: «es un patrón repetible entre el camino frío y el cacheado».
- **Confianza**: 0,75.
- **Impacto si no se corrige**: las tasas de §14.5 y de `Examples/` pueden presentarse como evidencia de la confiabilidad del modelo cuando sólo miden repetibilidad. Hay retrabajo cuando AH-02 o el jurado lo detecten.
- **Dirección**: separar dos magnitudes y nombrarlas distinto.
  - **Tasa sobre un conjunto de entradas**: N paráfrasis o casos distintos por ejemplo, rotulados como «escritos para el ejemplo».
  - **Estabilidad ante repetición**: la misma entrada; se informa aparte y con el estado de caché registrado.
  - Declarar en R-LLM qué `temperature` se usa en cada una y por qué.

### IA-04 · S3 · En `15`, el juez es el mismo modelo que generó las respuestas que evalúa

- **Ubicación**: §E.4 fila `15-Pruebas-Y-Evaluacion`; §10.6.
- **Afirmación**: `15` evalúa «Respuestas de `11`», generadas con `qwen3.5:4b`, usando a `qwen3.5:4b` como juez. B13 documenta el sesgo de autofavorecimiento y su resultado vale para jueces **fuertes**. Un 4B que se juzga a sí mismo reúne las dos condiciones que la fuente señala como problemáticas. La calibración con casos anotados que propone el plan mitiga la falta de fuerza del juez, pero no el autofavorecimiento.
- **Evidencia**: E2. Anclas literales:
  - N0b B13: «sesgos de posición, verbosidad y autofavorecimiento», y «Un LLM fuerte que evalúa respuestas abiertas».
  - N5 §8.4: «no verifiqué la calidad ni la estabilidad de `RelevanceEvaluator`/[…]/`GroundednessEvaluator` con un modelo Qwen local».
  - Plan: «`qwen3.5:4b` como juez».
- **Confianza**: 0,7.
- **Impacto si no se corrige**: los puntajes de `15` pueden salir inflados, y la guía los mostraría como ejemplo de evaluación sin advertir el sesgo de diseño.
- **Dirección**: dos opciones.
  - Usar un juez distinto del generador. Puede ser otra familia o tamaño del servidor, aunque sea con pocos casos por costo.
  - Si no se puede, declarar el autofavorecimiento como limitación del ejemplo en el texto y en el README, y apoyar el resultado en evaluadores exactos (cita que apunta a un fragmento recuperado, clave de catálogo) por encima del juez.

### IA-05 · S3 · En `14`, la propiedad que se mide no depende de cuántos agentes hay

- **Ubicación**: §E.4 fila `14-Uno-O-Varios-Agentes`; §F.4 `resumir_encuesta`.
- **Afirmación**: `14` compara un agente contra un secuencial redactor + revisor por la propiedad «resumen sin `Nombre` ni `Edad`». Pero `resumir_encuesta` devuelve sólo agregados por diseño, así que esos datos nunca entran al contexto. La propiedad se cumple en las dos variantes por construcción y no discrimina entre ellas. Además, un revisor LLM presentado como control de datos personales contradice el principio rector: el control vive en el código.
- **Evidencia**: E2. Anclas literales:
  - §F.4: «**agregados**, nunca filas con `Nombre`/`Edad` (T5; OWASP LLM02)».
  - §E.4 (fila 14): «revisor que verifica que no haya datos personales» y «Las dos variantes producen un resumen sin `Nombre` ni `Edad` (propiedad)».
  - §A.4 punto 5: «Las **reglas del dominio** son la autoridad».
- **Confianza**: 0,75.
- **Impacto si no se corrige**: la respuesta a PR-4 («¿uno o varios?») se apoyaría en una comparación que no mide calidad. Queda sólo el costo, y el lector puede aprender que un segundo LLM sirve como filtro de datos personales.
- **Dirección**: dejar la propiedad sin datos personales como invariante de la herramienta, probada en código. Para la comparación, elegir una tarea donde el segundo agente aporte algo verificable: por ejemplo, que los porcentajes del resumen coincidan con los del caso de uso. Así, «uno o varios» se responde con costo **y** con calidad medida.

### IA-06 · S3 · En `12`, comparar aciertos entre A y B mezcla la estrategia con el estado de la caché

- **Ubicación**: §E.3 fila `12-CAG-vs-RAG`; §6.3–§6.5.
- **Afirmación**: A (contexto completo sin reutilizar el prefijo) y B (con prefijo estable) le dan al modelo el **mismo conocimiento**. Sólo difieren en la caché del servidor. Sin embargo, X4b midió respuestas distintas entre el camino frío y el cacheado con `temperature` 0. Si `12` informa «aciertos» por variante, una diferencia entre A y B se va a leer como efecto de la estrategia cuando es ruido del motor. La comparación de calidad que tiene sentido es entre contexto completo y RAG (C). Entre A y B sólo tiene sentido comparar tiempos. Por otra parte, el plan no dice cómo se produce A de forma controlada. N3b propone «reiniciar o cambiar el primer carácter del prefijo», y X4b muestra que la caché en RAM puede restaurar un estado anterior.
- **Evidencia**: E2. Anclas literales:
  - Plan: «→ tiempos de prompt por variante y aciertos».
  - Verificación de N3b, X4b: «A y C idénticas con `temperature` 0 dan respuestas distintas».
  - N3b §9 punto 7: «G acertó después de D […] el mecanismo exacto no está verificado».
- **Confianza**: 0,7.
- **Impacto si no se corrige**: se arriesga una conclusión espuria sobre la calidad de CAG frente al contexto sin caché, justo en el tema que el PO pidió verificar (PR-8).
- **Dirección**: entre A y B, sólo `prompt_eval_duration` y `load_duration`. Aciertos, sólo entre contexto completo y RAG, con el modelo de calidad cuando esté disponible. Especificar cómo se fuerza A, con un prefijo único por consulta, y registrar el estado de caché en cada corrida.

### IA-07 · S3 · D6/C5 está en el escalón 3 aunque el eje declarado es la autonomía y la aprobación es un mecanismo del escalón 1

- **Ubicación**: §B.3 («C5 (baja con aprobación) en el 3»); §F.1 D6 («agencia 3»); §E.3 `07`.
- **Afirmación**: el plan ordena la escalera de agencia por «cuánto decide el modelo». La baja con aprobación es un pedido de una sola acción con un humano en el medio, o sea, menos autonomía que una llamada con herramientas sin control. La aprobación es una propiedad de la herramienta (`ApprovalRequiredAIFunction`), definida en M.E.AI. Lo que agrega MAF en `07` es la sesión (`AgentSession`), no autonomía. Ubicarla en el escalón 3 mezcla «tiene aprobación» con «es un agente», y debilita el criterio que el propio plan defiende frente a PR-5.
- **Evidencia**: E2. Anclas literales:
  - Plan §B.3: «Propuesto: herramienta → workflow → agente → multiagente | Cuánto decide el modelo (autonomía)».
  - N4 §1 G1: «El modelo pide, la app ejecuta | Tool/function calling; […] aprobación humana (`ApprovalRequiredAIFunction`, `ToolApprovalRequestContent`). | […] Vive en MEAI (N2)».
  - N6 E2: «existen `ApprovalRequiredAIFunction`, `ToolApprovalRequestContent` y `ToolApprovalResponseContent`» en MEAI 10.11.0.
- **Confianza**: 0,6. Que `FunctionInvokingChatClient` respete la aprobación sin MAF no está ejecutado en ningún dossier.
- **Impacto si no se corrige**: el lector se lleva que para pedir aprobación hace falta un agente. Eso lo empuja un escalón arriba sin necesidad, en contra de la tesis de §A.1.
- **Dirección**: ubicar la aprobación como control transversal del escalón 1 en adelante, y justificar el uso de agente en `07` sólo por la sesión o la conversación. Que una sonda corta confirme que la aprobación funciona con `UseFunctionInvocation` solo. Si no funciona, decirlo como requisito técnico, no de autonomía.

---

## Posición sobre las propuestas de mi mandato

| PR | Posición | Fundamento |
|---|---|---|
| PR-2 | apoya con cambios | Bien el alcance reducido. Qwen3.5 no tiene hito con fuente (R-07). Mientras no aparezca la fuente primaria, nombrarlo sólo como «modelo del laboratorio», con su digest. Sumar al vocabulario de §4.2 «modelo de razonamiento / tokens de razonamiento»: §5.7 depende de ese concepto (Sondeo §2: `finish=length` con `content` vacío). |
| PR-4 | apoya | La pregunta está bien fundada (N4 F21, F01). Para responderla con datos, `14` tiene que medir algo que dependa de la cantidad de agentes (IA-05). |
| PR-5 | apoya con cambios | Reordenar por autonomía es conceptualmente correcto y tiene fuente (N4 §2.15, F21: «predefined code paths» frente a «dynamically direct»). El cambio: la aprobación es un control transversal, no un escalón (IA-07). |
| PR-8 | apoya con cambios | Bien la distinción entre el CAG de servicio y el del paper, y que el comparativo vaya a `Examples/` (N3b §0.1, §3.7). El cambio: no comparar calidad entre A y B (IA-06). |
| PR-10 | apoya | La preparación de datos, el conjunto de oro con preguntas no respondibles y la recuperación medida antes que la respuesta coinciden con N3 C6 y N0b B08–B11. |
| PR-16 | apoya | Es el principio correcto. Para que el código lo muestre de verdad, el esquema tipado tiene que permitir que falte el dato (IA-01). |
| PR-18 | apoya | Bien como pregunta guía, con el inventario verificable de M.E.AI y MAF y sin construir un marco. |
| PR-19 | apoya | Bien la fila «LangGraph por HTTP» como snippet no ejecutado. La aclaración de LangGraph, Microsoft Graph y «GraphLang» es correcta según I-01 y N4. |
| PR-20 | apoya con cambios | Bien un primer ejercicio sólo de lectura con negativas y la sesión puesta por el código. Los cambios: la lectura tiene que devolver lo que una acción posterior necesita (id) (IA-02), y falta la negativa «dato que no está en la base ni en el pedido», donde lo que se mide es que el modelo no invente. |
| PR-22 | apoya | Es didáctico, no llama al modelo y su trampa está verificada (N4 V01, `FunctionCallContent` ambiguo). |

## Revisado y bien

1. **Hechos de Ollama y Qwen**: razonamiento encendido por defecto y `ReasoningEffort.None`, sin `tool_choice`, truncado silencioso de `num_ctx` 4096 detectado por los tokens de entrada, acierto de caché medido por `prompt_eval_duration` y no por `prompt_eval_count`, timeouts largos. Todo coincide con Sondeo §2–§8 y con N3b X4b.
2. **RAG**: modelo de embeddings dedicado (no el de chat), el mismo para indexar y para consultar, dimensión verificada al arrancar, recuperación medida aparte (recall@k/MRR) y aviso de que citar no es estar fundamentado (N3 E5). Es correcto. Matiz menor: con un relevante por pregunta, lo que se mide es *hit rate@k* (N3 §2.8). Conviene que la guía lo nombre, y que pruebe la instrucción de consulta que `qwen3-embedding` admite (N3 F21).
3. **Ecosistemas y LangGraph (§B.4, §B.5, §9.4–§9.5)**: «no hay LangGraph oficial para .NET», el equivalente funcional como criterio propio declarado, «los atributos marcan piezas, no agentes», y Microsoft Graph sin relación con IA. Son correctos y están anclados en I-01 y N4.

## Solicitudes de convocatoria

- **Didáctica/redacción**: la cantidad de ejemplos (17) frente al costo de las corridas R-LLM, y la fusión que propone P-10.
- **Infraestructura/recursos**: el plan sugiere un 7B «para calidad» en `12`. En un Ollama propio choca con R-02 (máquina al límite) y en el servidor de la LAN, con R-01/R-04. Que se defina dónde y con qué turno.
