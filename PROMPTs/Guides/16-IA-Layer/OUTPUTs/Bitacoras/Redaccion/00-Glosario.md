---
doc_id: BIT-16-RED-00-GLO
doc_type: borrador-de-anexo
title: Glosario canónico (Anexo C de la guía 16)
status: vigente para la redacción
origin: agent (preparación de la redacción)
last_review: 2026-10-27
audience: [redactores, relectura integral]
traces: [BIT-16-04 v3 §C Anexo C (H-043, H2-048, PAR2-19, PAR3-05), §B, §E.1, BIT-16-03, REED-16 §9.1 C5, BIT-16-N1 §2, BIT-16-N3b §2, 00-Referencias.md]
---

# Glosario canónico (Anexo C)

Un término por concepto, con sus alias y la sección de la guía donde se define. La lista de términos es la del plan (§C, Anexo C) y no se amplía acá. Las definiciones son breves a propósito: la definición completa vive en la sección que figura en la columna «Se define en», y el glosario no la reemplaza. Donde la definición es criterio de la guía y no de una fuente, se dice.

## Índice

- [Reglas del glosario](#reglas-del-glosario)
- [Términos](#términos)
- [Alias que no se usan en títulos](#alias-que-no-se-usan-en-títulos)

## Reglas del glosario

- **Control C5** (REED-16 §9.1; H2-048): ningún título de la guía usa un alias. Comprobación: `grep` de la columna «Alias» sobre los encabezados de la guía = 0.
- En la prosa, el término canónico es el que se usa. Un alias aparece sólo la primera vez, entre paréntesis, para que el lector que lo trae lo reconozca («llamada con herramientas (*tool calling*)»), o cuando se cita un nombre de API o una fuente literal.
- *Contexto* y *contexto de uso* no se intercambian nunca: el primero es lo que recibe el modelo en una llamada; el segundo, la variante del marco de referencia (CTX-…).
- *CAG* sin calificar designa sólo el método del artículo que lo define [REF-67]. Lo que una aplicación por API puede hacer se llama *contexto completo con prefijo estable*.
- **Al pasar a la guía**: la columna «Respaldo» queda con los `[REF-nn]` y con la marca «criterio de la guía»; todo paréntesis «(plan §…)» es trazabilidad interna y se borra (plan §C, «Remisiones en las fichas»).
- Los nombres de API (`IChatClient`, `AIFunction`, `ApprovalRequiredAIFunction`…) van en código y en inglés; no son términos del glosario.

## Términos

| Término canónico | Alias | Definición breve | Se define en | Respaldo |
|---|---|---|---|---|
| modelo | LLM, modelo de lenguaje | Modelo generativo que produce la salida un token por vez, prediciendo el siguiente a partir de los anteriores. No es una base de datos ni un motor de reglas: no conoce los datos de la aplicación salvo que se los pasen en el contexto | §3.0, §4.1 | [REF-11] |
| token | — | Unidad en que el tokenizador parte el texto (palabras, partes de palabra o signos). Es la unidad de cómputo, de límite y de costo; no equivale a una palabra | §4.1 | [REF-12] |
| temperatura | — | Parámetro de muestreo: más alta, salida más variable; más baja, más enfocada. Temperatura 0 no garantiza la misma salida entre llamadas ni entre versiones del modelo (criterio de la guía) | §4.1 | [REF-46], [REF-14] |
| prompt | — | El texto de entrada al que responde el modelo; en chat se organiza en mensajes con rol (sistema, usuario, asistente) | §3.0, §4.1 | [REF-13] |
| instrucciones | system prompt, mensaje de sistema | La parte del prompt que le dice al modelo cómo comportarse: el mensaje de rol sistema o `ChatOptions.Instructions`. Orienta; no es un control de seguridad ni el lugar de una regla de negocio | §4.1 | [REF-13], [REF-46], [REF-160] |
| contexto | — | Todo lo que el modelo recibe en **una** llamada: instrucciones, historial, datos recuperados y resultados de herramientas. Lo que no se reenvía en la llamada siguiente, el modelo no lo ve | §3.0 | [REF-12], [REF-45] |
| contexto de uso | contexto (del marco), CTX- | Variante que cambia la respuesta correcta dentro de un mismo escenario (local o nube, prototipo o producción, datos públicos o sensibles, aplicación existente o nueva). Se escribe siempre «contexto de uso» o con su ID | §2.2 | marco de referencia de la guía (criterio de la guía) |
| ventana declarada / efectiva / configurada | ventana de contexto | Declarada: el máximo de tokens que el fabricante anuncia. Efectiva: lo que el modelo usa bien en la práctica, que puede ser menos. Configurada: lo que el servidor reserva para la llamada (en Ollama, `num_ctx`); si el prompt la supera, el servidor puede recortar sin avisar | §6.5 | [REF-12], [REF-76], [REF-55] |
| modelo de razonamiento | modelo que «piensa», *thinking* | Modelo que produce tokens de razonamiento antes de la respuesta. Esos tokens consumen tiempo y presupuesto; si se agota el presupuesto, la respuesta puede llegar vacía. En la guía el razonamiento se apaga en una sola capa de opciones | §4.1, §5.4 | [REF-52], [REF-46] |
| alucinación | confabulación | Texto que el modelo genera sin sustento en la entrada ni en las fuentes provistas, con la misma seguridad que una respuesta correcta. No lanza error ni excepción | §4.1 | [REF-15], [REF-16], [REF-06] |
| grounding | anclaje | Hacer que la respuesta se apoye en material fuente provisto y que cada afirmación pueda rastrearse hasta él. Reduce la alucinación y la vuelve verificable; no la elimina | §4.1 | [REF-16], [REF-86] |
| salida estructurada | salida tipada | Respuesta del modelo con un tipo que fija la aplicación (en .NET, `GetResponseAsync<T>` y `TryGetResult`). Un tipo bien formado puede traer un valor falso: es una propuesta que validan las reglas | §3.0, §5.3 | [REF-47] |
| embedding | vector, representación vectorial | Representación numérica de un texto que permite medir parecido de significado por distancia entre vectores. Dos vectores de modelos distintos no son comparables (criterio de la guía) | §3.0, §4.1, §7.1 | [REF-87], [REF-88] |
| fragmento | chunk | Unidad del corpus que se vectoriza, se recupera y se cita. En el caso, cada literal de una `*Policy` es un fragmento | §7.2 | [REF-86], [REF-109] |
| RAG | generación aumentada por recuperación | Recuperar en el momento de la consulta los fragmentos relevantes de datos propios y pasarlos en el contexto, con su fuente para citar. No cambia los pesos del modelo | §3.0, §7 | [REF-85], [REF-86] |
| RAG agéntico | — | RAG en el que recuperar es una herramienta que el modelo decide llamar dentro del bucle. Es el único punto donde se cruzan las dos escaleras | §3.0, §6.6 | criterio de la guía (plan §B.3) |
| contexto completo con prefijo estable | CAG de servicio (no se usa en títulos) | Pasar el corpus entero en cada llamada, con un prefijo idéntico byte a byte para que el servidor pueda reutilizar el trabajo ya hecho sobre él. Es lo que una aplicación por API puede hacer del CAG; el CAG del artículo exige la caché KV persistida y el modelo en proceso | §3.0, §6.3 | [REF-67], [REF-70], [REF-71], [REF-72], [REF-73] |
| herramienta | tool, función | Función de la aplicación que el modelo puede pedir invocar con argumentos; en .NET, un `AIFunction`. En la guía, una herramienta envuelve un caso de uso de Application, nunca el repositorio | §3.0, §8.2 | [REF-121], [REF-162] |
| llamada con herramientas | tool calling, function calling | El modelo pide invocar una herramienta, la aplicación la ejecuta y le devuelve el resultado con el historial, en un bucle con tope de iteraciones. El modelo pide; la aplicación ejecuta | §3.0, §8.2 | [REF-45], [REF-121] |
| workflow | flujo de trabajo | Camino de pasos fijado en el código; sus nodos pueden ser funciones, llamadas al modelo o agentes, y sigue siendo workflow si el camino lo fija el código | §3.0, §8.6 | [REF-115], [REF-124] |
| agente | — | Sistema en el que el modelo dirige su propio proceso y el uso de herramientas hacia un objetivo. El artefacto agente de un marco (`AIAgent`) y el escalón 3 son cosas distintas: un `AIAgent` puede estar en el escalón 1 | §3.0, §8.7 | [REF-115], [REF-116], [REF-117] |
| orquestación | — | Coordinación de varios pasos o agentes: de camino fijo (secuencial, concurrente) en el escalón 2, o con un modelo que elige el siguiente agente en el escalón 3 | §8.8 | [REF-115], [REF-129]; criterio de la guía el mapeo a escalones |
| escalón de orquestación | escalón de agencia | La posición de un caso en la escalera de agencia: −1 función sin modelo, 0 llamada única, 1 llamada con herramientas, 2 workflow, 3 agente. Mide cuánto decide el modelo, no qué tan difícil es la API | §3.2, §8.1, §13.8 | criterio de la guía (plan §B.3), sobre [REF-115], [REF-117] |
| escalón | — | Cada nivel de una de las dos escaleras (conocimiento: qué sabe el modelo; agencia: qué puede hacer). Se sube cuando el de abajo no alcanza | §3.2 | criterio de la guía (plan §B.3) |
| criterio de salto | — | La condición explícita que justifica subir un escalón (tamaño del corpus contra la ventana efectiva, frecuencia de cambio, latencia, costo, aislamiento; o, en agencia, que una función no alcance) | §3.2, §6, §8.1 | [REF-115], [REF-117]; criterio de la guía |
| capa de IA | — | El lugar de la aplicación por donde el modelo propone y la aplicación decide: la llamada al modelo vive en Infrastructure detrás de un contrato, y crece por las dos escaleras | §1, §4 | criterio de la guía (tesis, plan §A.1) |
| puerto | contrato, interfaz | Interfaz que expresa lo que el núcleo necesita, definida en el núcleo (Application). En la capa de IA hay dos: el puerto propio (`IExtractorDeLocalidad`) y el puerto técnico (`IChatClient`) | §4.3, §4.4 | [REF-183], [REF-182] |
| adaptador | — | Tipo de Infrastructure que implementa un puerto contra un dispositivo o servicio externo (aquí, el proveedor del modelo) | §4.3 | [REF-183], [REF-182] |
| raíz de composición | — | El punto donde se conectan implementaciones con interfaces por inyección de dependencias; en el caso, `Program.cs` | §4.3 | [REF-182] |
| aprobación | aprobación humana | La persona confirma una acción concreta que el modelo pidió, sobre argumentos que resolvió el código, antes de ejecutarla. No reemplaza la autorización | §8.5 | [REF-122], [REF-162] |
| autorización | — | La decisión del sistema sobre si alguien puede hacer algo. La demo muestra aislamiento por sesión y aprobación, no autorización | §8.5, §11.3 | [REF-162]; criterio de la guía (plan §A.4) |
| sesión | — | En el caso, la identidad mínima que pone el código (`X-Sesion-Id` en la API, la cookie en Blazor, una sesión fija en el ejemplo MCP). El modelo nunca la elige y no autentica | §8.3 | [REF-186]; criterio de la guía (plan §A.4, punto 3) |
| MCP | Model Context Protocol | Protocolo abierto para que un cliente de IA descubra y llame herramientas y recursos de otro proceso. La aplicación puede ser servidor (exponer) o cliente (consumir) | §8.9 | [REF-37], [REF-130] |
| marcado del contenido | spotlighting | Separar y marcar el texto no confiable dentro del contexto para que el modelo lo distinga de las instrucciones. Es una defensa entre varias, no una solución | §11.2 | [REF-166], [REF-160] |
| hit rate@k | tasa de acierto en k | Fracción de preguntas para las que algún fragmento relevante aparece entre los k primeros recuperados. Con un solo fragmento relevante por pregunta coincide con recall@k. Se informa siempre contra una línea base | §7.5 | criterio de la guía (plan §E.2, fila 06) |
| línea base | — | Una forma sin modelo de resolver la misma tarea (azar, coincidencia léxica en código) contra la que se compara una métrica para saber si el modelo aporta | §7.5 | criterio de la guía (plan §E.2 fila 06) |
| LLM juez | juez | Un modelo que puntúa la salida de otro. Tiene sesgos conocidos; un juez que no se calibró contra casos anotados no se interpreta | §10.6 | [REF-158], [REF-151] |
| oráculo | — | Regla mecánica, definida antes de correr, que decide si una salida pasa, falla o se excluye, y que se puede recalcular leyendo sólo el registro de la corrida | §10.4 | criterio de la guía (plan §E.1) |
| entrada distinta | — | La unidad de muestra de una corrida contra el modelo: una paráfrasis, un límite o un negativo distinto, no la repetición de la misma entrada. La tasa es k/M con su intervalo | §10.4 | criterio de la guía (plan §E.1, H-001) |
| cliente guionado | — | `IChatClient` que devuelve respuestas fijadas por un guion, sin servidor, y pasa por la misma capa de opciones que el cliente real. Lo que muestra es conducta del código, nunca del modelo | §0.4, §10.2 | `Examples/_Comun/MovilidadUrbana.Asistente.Comun/AI/FabricaDeClientes.cs` (`Envolver`); criterio de la guía (carta §16.8) |
| prueba de cableado | — | Prueba con el cliente guionado que comprueba que las piezas están compuestas como dice el diseño (capa de opciones, herramientas, reglas en el camino), sin afirmar nada sobre el modelo | §0.4, §10.2 | criterio de la guía (plan §E.5, pasos de la demo) |
| prueba de humo | — | Una sola entrada corrida contra el modelo para ver que un paso funciona de punta a punta. Muestra conducta; no da tasa | §0.4, §14.3 | criterio de la guía (plan §E.5, pasos de la demo) |
| estímulo del mismo autor | — | Entrada escrita por quien escribió también el código y el oráculo. Se declara en el rótulo porque puede favorecer al sistema que se mide | §0.4, §10.4 | criterio de la guía (carta §9.3) |
| IC95 | intervalo de confianza | Intervalo de Clopper-Pearson del 95 % para una tasa k/M. Con M ≤ 12 la tasa es descriptiva | §0.4, §10.4 | criterio de la guía (carta §10) |
| dificultad | nivel | Rótulo para el lector (básico, intermedio, avanzado) que lleva cada ejemplo; no es un bloque de la guía. Se escribe con palabras, no con letras | §0.4, Anexo E | criterio de la guía (plan §E.2) |

## Alias que no se usan en títulos

Lista para la comprobación C5 sobre los encabezados (sin distinguir mayúsculas): LLM · tool calling · function calling · salida tipada · CAG de servicio · chunk · system prompt · ventana de contexto · confabulación · anclaje · spotlighting · Model Context Protocol · flujo de trabajo · escalón de agencia · tasa de acierto en k · nivel.

Excepciones previstas, con motivo, para que la comprobación no las marque: «LLM juez» es término canónico y contiene «LLM»; el alias «LLM» se comprueba como palabra aislada. «RAG» y «MCP» son términos canónicos (siglas) y no alias.
