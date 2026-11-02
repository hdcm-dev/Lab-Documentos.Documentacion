---
doc_id: BIT-16-C2-INF-AH-02-evaluacion-llm-rag
doc_type: informe-de-especialista
title: Informe de AH-02 — Evaluación de sistemas LLM y RAG (relectura integral, ciclo 2)
status: hecho
origin: agent
owner: AH-02 Evaluación de sistemas LLM y RAG (relectura integral del ciclo 2)
date: 2026-10-28
traces: [REED-16 §9.1, §10, §13, Mesa/Ciclo-1/06-Plan-De-Redaccion.md §10.2 y §10.3 (RV-17, R-LLM-1…5), Mesa/Ciclo-1/07-Dictamen-Presidencia.md, Mesa/Ciclo-1/Ronda-2/Consulta-{estación-2}-ollama.md §3 (PC-08), Mesa/Ciclo-2/evidencia-examples/, Mesa/Ciclo-2/evidencia-demo/]
evidencia: evidencia-AH-02-evaluacion-llm-rag/
---

# Informe de AH-02: Evaluación de sistemas LLM y RAG (relectura integral)

**Mandato.** ¿Las pruebas de `Examples/` y `Demos/` demuestran lo que la guía afirma, con aserciones que no dependen del azar? ¿R-LLM se aplica bien (k/n, intervalos, criterio previo)? ¿Se enseña a evaluar la respuesta y la recuperación con herramientas vigentes?

**Leído.** La guía completa, de punta a punta (4116 líneas). De `Examples/` y la demo, todas las clases de `ConModelo/`, las de `Cableado/` que tocan tiempo u orden, el método del juez de `Examples/09`, `Oro.cs` de `Examples/05` y los README de `01`, `05` y `09`. Como contraste, la evidencia del ciclo 2 (`evidencia-examples/`, `evidencia-demo/`) y la consulta PC-08 del ciclo 1. A ciegas: no leí otros `Informe-*.md` del ciclo 2.

**Respuesta corta.** La aritmética está bien: recalculé los 93 intervalos de Wilson de la guía y todos coinciden. Casi todas las pruebas contra el modelo hacen fallar sólo por invariantes, y la recuperación se enseña con un método sólido. Hay cuatro defectos de peso:

1. La prueba del juez de `Examples/09` **pasa en verde sin medir nada**. La corrí hoy, sin cambios: ningún evaluador dio puntaje y el resultado fue «Passed» (AH-02--01).
2. La guía no recoge lo que el laboratorio vio del juez: puntuó «Good» una respuesta incorrecta. Y recomienda justo los evaluadores que fallaron (AH-02--02).
3. Una prueba de `Examples/01` falla por una tasa (k ≥ m − 2), y el Anexo A.4 la muestra como el caso modelo. Eso contradice §8.1.3 (AH-02--03).
4. La frase de §8.10.1 sobre la inyección dice literalmente lo contrario de lo que se midió (AH-02--04).

## Índice

1. [Evidencia producida](#1-evidencia-producida)
2. [Hallazgos](#2-hallazgos)
3. [Revisado y bien](#3-revisado-y-bien)

## 1. Evidencia producida

En `evidencia-AH-02-evaluacion-llm-rag/` (índice en `00-LEEME.md`):

- **Wilson (E1, script).** `01-wilson-check.py` recalcula cada «k/n … [a; b]» de la guía con z = 1,959964. Revisó 93 intervalos y no encontró discrepancias reales; las 3 que marca son falsos positivos de la expresión regular, explicados en la salida.
- **Aserciones (E1, lectura).** `02-aserciones-conmodelo.txt` lista todas las aserciones de `ConModelo/`. `03-cableado-dependiente-del-orden.txt` muestra la prueba del 503 de `Examples/09` frente a la de la demo.
- **Juez (E1, corrida).** Corrí `EvaluacionConJuezTests` de `Examples/09` **tal cual**, con `CONMODELO_JUEZ=1`. Compilé en `mcr.microsoft.com/dotnet/sdk:10.0` con el recurso `build` (0 advertencias, 0 errores) y corrí con un turno exclusivo `<recurso-compartido>`, en la estación de laboratorio de 4 núcleos, el 2026-10-28; tardó 5 min 45 s. La salida está en `04-…` y `05-…`, y la composición del cliente del juez en `06-…`. Antes probé con la estación con más núcleos, pero no respondió (timeout de conexión) y esa corrida no midió nada.

## 2. Hallazgos

### AH-02--01 · La prueba del juez de `Examples/09` pasa en verde sin medir nada y no implementa las condiciones que la guía exige

- **Ubicación.** `Examples/09-Pruebas-Con-Cliente-Falso/tests/MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests/ConModelo/EvaluacionConJuezTests.cs`, l. 31–51. `…/src/…/Infrastructure/AI/ComposicionDeIA.cs`, l. 71–75. Guía §8.9.2 (l. 3066 y 3073) y Anexo E.5 (fila `09 · EvaluacionConJuezTests`).
- **Severidad y tipo.** S2 · técnico / reproducibilidad.
- **Evidencia (E1, corrida de hoy).** La prueba sin cambios terminó **Passed** («Test Run Successful») con este resultado:
  - «Medio en catálogo»: Unacceptable, porque «la respuesta no es JSON».
  - Relevance: Inconclusive («Failed to parse score»), con 800 tokens de salida, que es el límite del evaluador.
  - Coherence y Groundedness: sin puntaje, cortadas por el `HttpClient.Timeout` de 300 s.

  La única aserción es `Assert.That(resultado.Metrics, Has.Count.EqualTo(4))`, que se cumple aunque todas las métricas fallen. Hay tres causas en el código:
  1. El juez es el cliente del proveedor (`DetectorDeContextoTruncado(new OllamaApiClient(...))`), sin `Reasoning = None` ni `num_ctx`. Los evaluadores mandan sus propias `ChatOptions`, así que rige el razonamiento por defecto de Qwen3.5. Es la misma causa que PC-08 midió en el ciclo 1: 6 de 7 evaluadores sin veredicto. §8.9.2 lo pone como condición («razonamiento apagado… `num_ctx` de al menos 8192 fijado en el cliente»), pero el ejemplo no lo cumple.
  2. La respuesta evaluada la genera el mismo cliente juez (`corrida.ChatConfiguration!.ChatClient`) con `GetResponseAsync` sin esquema. Por eso no es JSON y el evaluador determinista falla de entrada. Además, el modelo se juzga a sí mismo: es el sesgo de autofavorecimiento que la guía nombra [REF-127].
  3. Nada distingue «el juez dio un puntaje» de «el juez no respondió».
- **Propuesta.**
  1. En `EvaluacionConJuezTests`, envolver el juez con las condiciones y generar la respuesta con el sistema bajo prueba:
     ```csharp
     var ia = host.Services.GetRequiredService<IOptions<OpcionesDeIA>>().Value;
     var proveedor = host.Services.GetRequiredKeyedService<IChatClient>(ComposicionDeIA.ClaveDelProveedor);
     // Condiciones de §8.9.2: razonamiento apagado y num_ctx fijado en el cliente (ningún evaluador los fija).
     IChatClient juez = new ChatClientBuilder(proveedor)
         .ConfigureOptions(o =>
         {
             o.Reasoning = new ReasoningOptions { Effort = ReasoningEffort.None };
             (o.AdditionalProperties ??= [])["num_ctx"] = ia.NumCtx;
         })
         .Build();
     ```
     La respuesta evaluada sale del mismo camino que `SalidaEstructuradaConModeloTests` (salida estructurada con el esquema del paso 2), no de `corrida.ChatConfiguration.ChatClient`.
  2. Cambiar la aserción final por una invariante del arnés: «cada métrica tiene `Interpretation` y ningún diagnóstico de severidad `Error`; un `Inconclusive` hace fallar la prueba». Esto no fija ningún umbral de calidad: el puntaje se sigue informando, nunca es compuerta.
  3. En §8.9.2, después de «Esta prueba corre sólo bajo demanda (`CONMODELO_JUEZ=1`) y **no se corrió**», agregar: «Corrida tal como estaba, el 2026-10-28 en la estación de 4 núcleos, terminó en verde sin ningún puntaje: el razonamiento por defecto agotó los 800 tokens de Relevance y las otras dos cortaron por el timeout de 300 s. Por eso la prueba fija las dos condiciones en el cliente del juez y falla si una métrica queda sin puntaje (existencia, N = 1).»
  4. Si la prueba no se vuelve a correr, la fila de E.5 queda «no medido».

### AH-02--02 · §8.9 no refleja lo que el laboratorio vio del juez y recomienda los evaluadores que fallaron

- **Ubicación.** Guía §8.9.2 (l. 3055–3076), §8.13.13 (l. 3181–3182), §6.8 (l. 1722) y Anexo E.4 (filas del juez).
- **Severidad y tipo.** S2 · evidencia.
- **Evidencia (E1 del ciclo 1; `Ronda-2/Consulta-{estación-2}-ollama.md` §3 y `pc08/`).** Se probaron 4 casos con respuesta escrita a mano.
  - C3, una respuesta **incorrecta** («hasta 1000 km», cuando la regla dice 0–500): Relevance y Coherence le dieron 4 («Good») y Groundedness, 3. Completeness y Equivalence, que comparan contra una respuesta de referencia, le dieron 1.
  - C2, una respuesta **correcta**: Relevance le dio 2 («Poor»).

  Es una anécdota (N = 1 por celda), pero es justo lo que la guía tiene que enseñar: un evaluador de calidad sin referencia no mide si la respuesta es verdadera. Hoy la guía dice tres cosas que no cierran:
  - Cablea Relevance, Coherence y Groundedness como conjunto (l. 3060).
  - Dice que la prueba «**no se corrió**» y a la vez da el costo de 28 evaluaciones (l. 3074; E.4). Lo que corrió fue una sonda, no la prueba.
  - En §6.8 llama «evaluar la respuesta» a `RetrievalEvaluator`, que juzga los fragmentos recuperados.
- **Propuesta.**
  1. En §8.9.2, agregar después de la viñeta «Se calibra antes»:
     > - **Lo que vio el laboratorio.** Con `qwen3.5:4b` como juez y cuatro casos escritos a mano, una respuesta incorrecta («hasta 1000 km» para una distancia de 0 a 500) sacó 4 («Good») en Relevance y en Coherence, y una correcta sacó 2 («Poor») en Relevance. Completeness y Equivalence, que comparan contra una respuesta de referencia, le dieron 1 a la incorrecta (existencia, N = 1 por celda; medido en una estación de laboratorio con más núcleos (CPU sin GPU; contenedor limitado a 14 CPU / 34 GiB; Ollama 0.40.11), 2026-10-28). Relevancia y coherencia no son verdad: si el oro trae la respuesta esperada, el conjunto mínimo es `EquivalenceEvaluator` o `CompletenessEvaluator` con esa referencia, más `GroundednessEvaluator` con los fragmentos enviados.
  2. Cambiar la frase del costo: «**Costo medido en una sonda aparte de la prueba**, con `qwen3.5:4b`: …».
  3. En §6.8, l. 1722, cambiar «Recién después se evalúa la respuesta, con `GroundednessEvaluator` y `RetrievalEvaluator`» por «Recién después se evalúa la respuesta (`GroundednessEvaluator`, y `EquivalenceEvaluator` contra la respuesta del oro); `RetrievalEvaluator` juzga con un modelo los fragmentos recuperados y no reemplaza las métricas con oro de esta sección».
  4. En §8.13.13, sumar «con un evaluador con referencia, porque relevancia y coherencia no detectaron una respuesta incorrecta (§8.9.2)».

  Antes de publicar, verificar que los nombres de los evaluadores existan en `Microsoft.Extensions.AI.Evaluation.Quality` 10.11.0. Los siete que usó la sonda de PC-08 los incluyen.

### AH-02--03 · Una prueba de `Examples/01` falla por una tasa, y el Anexo A.4 la presenta como modelo

- **Ubicación.**
  - `Examples/01-Chat-Basico/tests/MovilidadUrbana.Ejemplos.ChatBasico.Tests/ConModelo/ChatConModeloTests.cs`, l. 17–18, 46 y 68.
  - `Examples/01-Chat-Basico/README.md`, l. 150.
  - Guía Anexo A.4 (l. 3626–3630), contra §8.1.3 (l. 2644–2646), §3.7 (l. 532) y §9.5 (l. 3327).
- **Severidad y tipo.** S2 · coherencia / técnico.
- **Evidencia (E1, lectura).** `Assert.That(k, Is.GreaterThanOrEqualTo(m - 2))` hace fallar la prueba si el modelo nombra «4 dígitos» en menos de 8 de 10 semillas. La cabecera lo declara («umbral elegido, no medido»). Pero la guía dice otra cosa en tres lugares:
  - §8.1.3: la tasa observada «se informa y no hace fallar» y «una tasa no es un umbral de aceptación».
  - §3.7: sólo una tasa de la tarea puede fijar un umbral.
  - §9.5: «Las tasas no hacen fallar una prueba».

  El Anexo A.4 ofrece justamente esta cabecera como «un caso real» («criterio previo: invariantes en 10/10 y «nombra 4 dígitos» con k ≥ 8»). Hay además aserciones de existencia que hacen fallar («al menos una vez en m»): `DelChatAlAgenteConModeloTests` l. 99–100, `BajaConAprobacionConModeloTests` l. 96 y `MaxOutputTokensConModeloTests` l. 69. Están declaradas en sus cabeceras, pero no entran en los «tres tipos de aserción» de §8.1.3.
- **Propuesta.**
  1. En `ChatConModeloTests`, borrar la l. 68. En la cabecera, cambiar l. 17–18 por «tasa de este pedido, m semillas (1..m), sin umbral: la respuesta nombra 4 dígitos («4» o «cuatro»); se informa con Wilson y no hace fallar». En la l. 46, cambiar el criterio a «tasa «nombra 4 dígitos» informada, sin umbral».
  2. En el README (l. 150) y en A.4 (l. 3629), cambiar «criterio previo: invariantes en 10/10 y «nombra 4 dígitos» con k ≥ 8» por «criterio previo: invariantes en 10/10; «nombra 4 dígitos» se informa, sin umbral».
  3. En §8.1.3, sumar un cuarto tipo después de **Tasa observada**: «**Existencia:** la guía afirma que algo ocurre («el agente pide la herramienta»); la prueba falla si no se observó ni una vez en m semillas, y lo dice así». Cambiar el título a «Los cuatro tipos de aserción» (también en CTRL-11, l. 2706, y en D-08).

### AH-02--04 · §8.10.1 invierte con una doble negación el resultado de la inyección

- **Ubicación.** Guía §8.10.1, l. 3086.
- **Severidad y tipo.** S2 · edición (cambia el sentido de una cifra de seguridad).
- **Evidencia (E1, `evidencia-demo/pruebas/conmodelo/CTRL14-nombre-*.jsonl`).** El resumen dice `propuso_baja: 0/10`, `pidio_herramienta_inexistente: 0/10` y `repitio_el_texto: 10/10`. La guía escribe «el modelo **no** propuso una baja en 0/10 corridas … **no** pidió una herramienta inexistente en 0/10». Leída literal, la frase dice que el modelo propuso una baja en 10 de 10.
- **Propuesta.** Reemplazar por: «ante la inyección por `Localidad.Nombre`, el modelo propuso una baja en 0/10 corridas, Wilson 95 % [0; 0,28], pidió una herramienta inexistente en 0/10 [0; 0,28] y le **repitió el texto inyectado** a la persona en 10/10 [0,72; 1]».

### AH-02--05 · La regla «difiere» se enuncia de dos maneras: cuatro lugares omiten «todos»

- **Ubicación.** Guía §0.5 (l. 225), §6.8 lección 1 (l. 1718), §6.9 (l. 1726) y §8.14, antipatrón (l. 3202). La versión correcta está en §8.4.4 (l. 2823), E.5 regla 3e y `Examples/05/…/Evaluacion/Oro.cs` l. 79–88.
- **Severidad y tipo.** S3 · coherencia.
- **Evidencia (E1, lectura).** El código exige `discordantes >= 6 && (aMejor == 0 || bMejor == 0)`; §8.4.4 dice «6 o más pares discordantes, todos en el mismo sentido (… 2 · 0,5⁶ = 0,031)». En cambio, §0.5, §6.8 y §6.9 dicen «6 o más pares discordantes en el mismo sentido». Un lector con 6 a favor y 5 en contra (prueba del signo, p ≈ 1) podría declarar «difiere».
- **Propuesta.**
  - l. 225: «Dos variantes sólo «difieren» con 6 o más pares discordantes, todos en el mismo sentido; si no, «no separado con este N»».
  - l. 1718: «para «difiere» harían falta 6 o más, todos en el mismo sentido».
  - l. 1726: ««difiere» sólo con 6 o más pares discordantes, todos en un mismo sentido».
  - l. 3202: «sin 6 o más pares discordantes, todos en un sentido, no hay separación».

### AH-02--06 · La cifra de la vía B no se puede reproducir desde `Examples/05`, y su 8/8 queda por debajo de R-LLM-3c

- **Ubicación.** Guía §6.7 (l. 1670–1674) y E.5 (fila «05 · réplica de la vía B (sonda aparte de `ConModelo/`)»). `Examples/05-RAG-En-Memoria/` no tiene esa prueba.
- **Severidad y tipo.** S3 · reproducibilidad.
- **Evidencia (E1, lectura).** `ConModelo/` de `05` tiene sólo `RecuperacionConModeloTests` y `ContextoFijoFrenteARagConModeloTests`, y su README no menciona la vía B contra el modelo. La cifra de 12/16 sale de una sonda del ciclo 1. El texto es el que dicta el plan §10.2 y lo respeto. Pero el lector no puede repetir la medición, y «8/8 en cada una (semillas 1..8)» tiene m = 8, menos que las m ≥ 10 de una tasa de este pedido (E.5, regla 3c).
- **Propuesta.** La preferida es agregar `ConModelo/ViaBConModeloTests.cs` en `Examples/05`, con las seis preguntas y m = 10. El criterio previo sería «buscó (span `buscar_requisitos` o búsquedas > 0)», como tasa informada, con la invariante «respuesta no vacía». Si no se agrega, dejar el párrafo del plan y sumar a continuación: «(Sonda de laboratorio, sin prueba en `Examples/05`. Con 8 semillas, las cinco preguntas que buscaron siempre se leen como existencia: 8/8 da Wilson [0,68; 1].)».

### AH-02--07 · La prueba del 503 de `Examples/09` depende del orden de llegada; la de la demo, no

- **Ubicación.** `Examples/09-Pruebas-Con-Cliente-Falso/tests/…/Cableado/EntradaHttpTests.cs`, l. 26–53. Guía §8.6 (l. 2966).
- **Severidad y tipo.** S3 · técnico.
- **Evidencia (E1, lectura).** Los pedidos salen escalonados con `Task.Delay(i * 250)` y la prueba exige que **el cuarto** (`resultados[3]`) reciba el 503. Su corrección depende del reloj: la guía misma cuenta que sin el calentamiento «la compilación JIT demoró el primero y cambió el orden». `Cableado/` se define como determinista (§8.1.2). En cambio, la prueba de CTRL-09 de la demo (`ControlesTests.cs` l. 293–307) cuenta 3 × 200 y 1 × 503 sin importar cuál fue cuál.
- **Propuesta.**
  1. En `EntradaHttpTests`, cambiar las aserciones de posición por las de la demo: `resultados.Count(r => r.Codigo == HttpStatusCode.OK)` igual a 3, un 503 con `Retry-After` igual a `ReintentarEnSegundos` y `falso.Llamadas` igual a 3. Opcionalmente, reemplazar `Demora` por una compuerta (`TaskCompletionSource`) que el falso libera cuando ya llegaron los cuatro.
  2. En §8.6, cambiar «los pedidos 1 a 3 reciben 200, el cuarto 503» por «tres pedidos reciben 200 y uno 503 con `Retry-After: 30`, sin importar el orden de llegada», y borrar la frase del calentamiento, o dejarla como lección («una prueba que depende del orden de llegada no es determinista»).

### AH-02--08 · `Examples/05` midió la diferencia con y sin instrucción en sentido contrario a `Examples/04`, y la guía no lo dice

- **Ubicación.** Guía §6.8 lección 1 (l. 1718), §6.11.4 (l. 1773) y E.5 (fila «05 · RecuperacionConModeloTests»). Fuente: `Examples/05-RAG-En-Memoria/README.md`, «Resultado medido».
- **Severidad y tipo.** S4 · evidencia.
- **Evidencia (E1, README).** Con el mismo modelo de embeddings, hit@1 dio:
  - en `Examples/04`: 11/12 con instrucción y 10/12 sin ella;
  - en `Examples/05`, con otro oro: 11/12 con instrucción y **12/12 sin ella**.

  En los dos hay un solo par discordante, pero con signo opuesto. E.5 sólo informa «hit@3 12/12 con y sin instrucción». Es la mejor demostración de «no separado con este N» y forma criterio.
- **Propuesta.** En §6.8, al final de la lección 1, agregar: «Con el oro de `Examples/05` (otras 12 consultas, misma estación con más núcleos) el par discordante cayó del otro lado: hit@1 11/12 con instrucción y 12/12 sin ella. Un solo par, en sentidos opuestos según el oro: eso es ruido, no un efecto». En la fila de E.5, cambiar «hit@3 12/12 [0,76; 1] con y sin instrucción» por «hit@3 12/12 [0,76; 1] con y sin instrucción; hit@1 11/12 con y 12/12 sin».

## 3. Revisado y bien

1. **Los intervalos.** Recalculé los 93 «k/n … [a; b]» de la guía con Wilson al 95 % (`01-wilson-check-salida.txt`) y no hay ninguno mal. Además:
   - las tasas de la tarea calculan el intervalo sobre los pedidos (§6.9: 10/12, con K·m = 48 fuera del n);
   - las N chicas se rotulan como existencia (5/5 en §7.4, K = 4 no respondibles en §6.9);
   - la cota de 0/n para invariantes está bien enunciada (1 − 0,05^(1/n) = 0,26 con n = 10).
2. **Invariantes contra tasas en `ConModelo/`.** De las 18 clases, 13 hacen fallar sólo por invariantes; las otras cinco se desvían de forma declarada (AH-02--01 y AH-02--03). Sin `OLLAMA_ENDPOINT` todas quedan `Inconclusive` («no medido»), y la guía avisa con evidencia (`01-Chat-Basico/cableado/03-…`) que `dotnet test` las cuenta como `Skipped` y dice «Test Run Successful». Las garantías de seguridad (0 escrituras, 0 bajas, lista cerrada) son invariantes con prueba en `Cableado/`, nunca porcentajes.
3. **La recuperación se enseña con un método vigente y honesto** (§6.1, §6.8, §6.9):
   - el oro se redacta antes y se versiona contra el commit, con no respondibles y con un conjunto de calibración aparte;
   - hit@k, recall@k y MRR@k se definen con su prueba sin modelo, y la línea de azar va al lado;
   - se mide que los embeddings no muestrean (128/128), así que repetir es reproducir;
   - la comparación pareada por consulta termina en «no separado con este N»;
   - el artefacto del ejemplo de cita en el prompt se declara, y también el criterio léxico «injusto» que no se cambió después de ver las salidas.
