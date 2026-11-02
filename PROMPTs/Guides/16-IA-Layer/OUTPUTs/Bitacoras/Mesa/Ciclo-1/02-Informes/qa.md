---
doc_id: BIT-16-MESA-C1-QA
doc_type: informe-de-especialista
title: Informe de Verificación/QA sobre el plan de integración v0
role: Verificación/QA (núcleo permanente)
objeto: ../../../04-Plan-De-Integracion.md (v0)
modo: a ciegas (sin leer otros informes)
fecha: 2026-10-26
---

# Informe de Verificación/QA — Ciclo 1

Mandato: cómo se prueba cada afirmación y cada ejemplo, qué no es testeable, pruebas no deterministas con LLM, evidencia E1 exigible.

Las líneas citadas son las de `04-Plan-De-Integracion.md` v0 (762 líneas al 2026-10-26).

## Hallazgos

### QA-01 · S2 · E2 + E4 · confianza 0,85 — La aceptación de la demo se puede cumplir sin una sola corrida contra el modelo

- **Ubicación**: §F.10 AC-3 (l. 692); §F.8 `ConModelo/` (l. 678); §C §14.5 (l. 450).
- **Afirmación**: AC-3 da por cumplido el criterio con «`ConModelo/` verde **o saltada con mensaje**». Si el servidor no responde, la demo pasa la aceptación con cero registros R-LLM. Al mismo tiempo, §14.5 promete mostrar «qué evidencia produjo (tasas R-LLM)», y el contrato exige probar contra el modelo (S-17 «Probar todo», R-LLM). Los ejemplos de §E no tienen ninguna lista de aceptación: AC-1…AC-8 son sólo de la demo.
- **Ancla**: l. 692: «`ConModelo/` verde o saltada con mensaje; cada D1–D7 con registro R-LLM y tasa en N=5». Reedición l. 90: «S-17 | **Probar todo** y llevar registro de las pruebas, usando la API local con el modelo Qwen».
- **Impacto**: se puede cerrar la construcción con la guía mostrando tasas que nunca se midieron, o con §14.5 vacía. Eso es una salida presentada como medida sin la medición, S1 según el contrato.
- **Dirección**: separar dos cosas. Que la prueba se salte con un mensaje sirve para el lector que no tiene servidor. Para el cierre de la corrida, en cambio, tiene que haber una ejecución con registro por cada D1–D7 y por cada ejemplo con modelo. Hace falta una lista de aceptación para `Examples/` equivalente a AC-1…AC-3, y una regla: si no hay corrida, la sección de la guía dice «no ejecutado» y no muestra cifras.

### QA-02 · S2 · E2 · confianza 0,8 — Repetir N veces la misma entrada con `temperature` 0 no da una tasa del comportamiento del modelo

- **Ubicación**: §E.1 «Corridas contra el modelo» (l. 534); todos los criterios con «tasa en N=…» de §E.2–§E.4 y §F.8.
- **Afirmación**: el plan fija `temperature` 0 y `seed`, y después pide una «tasa en N corridas» con la entrada exacta repetida. Pero N3b X4b midió que, con `temperature` 0, dos peticiones idénticas dieron respuestas distintas entre el camino en frío y el camino con la caché del prefijo. En un servidor compartido, la primera corrida va en frío y las siguientes con caché. Las N corridas no son muestras independientes: la tasa mezcla dos regímenes y mide el estado de la caché, no la variabilidad del modelo ante entradas plausibles.
- **Ancla**: N3b l. 482: «dos peticiones idénticas (A y C) dieron respuestas distintas (1812 y 8983) con `temperature` 0 […] con `cache_prompt` los logits "are not guaranteed to be bit-for-bit identical"»; N3b l. 539: «es un patrón repetible entre el camino frío y el cacheado». Plan l. 534: «`temperature` 0, `seed` si el proveedor la respeta […] y **tasa en N corridas**».
- **Impacto**: hay dos resultados posibles y los dos son engañosos. Uno es un 10/10 que repite una sola muestra. El otro es una variación que se le atribuye al modelo cuando la produce la caché. Los dos llegan a la guía como «tasa».
- **Dirección**: definir qué es una unidad de muestra (por ejemplo, paráfrasis o entradas distintas del mismo caso, en lugar de la misma cadena repetida). Registrar en cada corrida si fue en frío o con caché. Declarar qué varía y qué se fija. Que AH-02 valide el diseño.

### QA-03 · S2 · E3 · confianza 0,8 — Con N=5 no se pueden sacar las conclusiones comparativas que el plan les asigna a `11`, `14` y `17`

- **Ubicación**: §E.3 `11` (l. 556); §E.4 `14` (l. 564) y `17` (l. 567); §G P-07 (l. 750).
- **Afirmación**: el plan quiere que «la pregunta "¿uno o varios?" se responda con números del laboratorio» (N=5 por variante) y comparar la tasa de bajas inducidas «con y sin marcado» (N=5). Cálculo exacto (binomial de Clopper-Pearson al 95 %, prueba exacta de Fisher; reproducible en una línea de Python):
  - 5/5 → la tasa real puede estar en [0,478 ; 1]; 0/5 → en [0 ; 0,522]. Con N=10: 10/10 → [0,692 ; 1].
  - 0/5 frente a 3/5 → p = 0,167; 1/5 frente a 4/5 → p = 0,206. Sólo 0/5 frente a 4/5 o más llega a p < 0,05.
  - Los tiempos de `14` se miden en un servidor compartido donde la misma consulta tardó 68,8 s en una corrida y más de 600 s en otra (Sondeo §0).
- **Ancla**: plan l. 564: «se miden llamadas al modelo, tokens y tiempo por variante (N=5) para que la pregunta "¿uno o varios?" se responda con números del laboratorio». Sondeo l. 12: «latencias bajo carga, no de banco exclusivo. La dispersión es enorme».
- **Impacto**: la guía enseñaría a decidir arquitectura con diferencias que caben en el ruido. Es el antipatrón que la propia guía tiene que desarmar.
- **Dirección**: informar cada tasa con N y su intervalo. Comparar variantes sólo con métricas deterministas o casi deterministas (cantidad de llamadas, tokens de entrada). Rotular los tiempos medidos en el servidor compartido como no comparables. Si se quiere una conclusión comparativa, que AH-02 fije el N, o que la guía diga explícitamente que N=5 no alcanza para concluir.

### QA-04 · S2 · E2 · confianza 0,75 — Varios criterios «ejecutables» no tienen oráculo mecánico o no prueban lo que dicen probar

- **Ubicación**: §E.2 `05` (l. 545); §E.3 `11` (l. 556); §E.4 `14` (l. 564) y `17` (l. 567).
- **Afirmación**:
  - `05`: «el modelo no inventa». No dice cómo se decide mecánicamente, sobre el texto libre de la respuesta, que no inventó.
  - `11`: «tasa de respuestas que contradicen la fuente citada». Sin juez ni anotación manual definidos, no hay quién decida qué es contradecir. Además, «la cita apunta a un fragmento recuperado (siempre)» aparece como aserción sobre la salida del modelo. Sólo puede valer «siempre» si es el código el que valida o descarta las citas, y el plan no dice que lo haga en el modo con modelo.
  - `14`: «sin `Nombre` ni `Edad`». La herramienta `resumir_encuesta` devuelve sólo agregados (§F.4, l. 647), así que las dos variantes cumplen la propiedad por construcción. La prueba no puede mostrar el aporte del agente revisor.
  - `17`: si el documento malicioso no se recupera en una corrida, esa corrida cuenta como «no inducida» y la tasa sale optimista. No figura como precondición que el documento esté en el contexto.
- **Ancla**: l. 545: «provincia fuera de catálogo → la herramienta devuelve error y el modelo no inventa»; l. 556: «tasa de respuestas que contradicen la fuente citada, sabiendo que N3 E5 mostró que pasa»; l. 647: «**agregados**, nunca filas con `Nombre`/`Edad`».
- **Impacto**: criterios que cada constructor implementa a su manera (S2 según el contrato). En `14` y `17`, además, el resultado es favorable por construcción y la guía lo presentaría como medido.
- **Dirección**: para cada criterio con modelo, escribir el oráculo: qué se busca en la salida y con qué regla. Si el oráculo es un juez, decirlo y remitir a §10.6. Agregar las precondiciones que se registran por corrida (documento recuperado, herramienta disponible). En `14`, construir una entrada en la que el redactor sí tenga acceso a datos personales, o reformular qué demuestra el ejemplo.

### QA-05 · S2 · E3 · confianza 0,7 — `03` y D2 no prueban el modo de falla que el escenario plantea: inventar el dato que falta

- **Ubicación**: §E.2 `03` (l. 543); §F.1 D2 (l. 582).
- **Afirmación**: la entrada «no sé cuántos viven» tiene como salida esperada que «las reglas rechazan habitantes ≤ 0», y D2 afirma que «la propuesta no pasa las reglas y la UI pide el dato». Las dos cosas dan por hecho que el modelo va a emitir 0 o nada. Contraejemplo: el modelo propone `Habitantes = 37000`. `LocalidadRules` lo acepta (está en rango), la propuesta pasa y se guarda un dato inventado. El criterio de prueba de `03` («toda propuesta que pasa `LocalidadRules` tiene CP de 4 dígitos y provincia del catálogo») ni siquiera mira ese caso.
- **Ancla**: l. 543: «"En Bella Vista, Corrientes, CP 3432, no sé cuántos viven" → propuesta tipada; las reglas rechazan habitantes ≤ 0»; l. 582: «la propuesta no pasa las reglas y la UI pide el dato».
- **Impacto**: la demo afirmaría (D2) un comportamiento que el código no garantiza, sobre la alucinación, que es el riesgo central de la salida tipada (OA-D2, D-08).
- **Dirección**: hacer que la propiedad bajo prueba sea «cuando la entrada no trae el dato, la propuesta no lo trae» (por ejemplo, con un campo que admita ausencia) y medir la tasa de invención. Lo que garantiza el código (la ausencia lleva a pedir el dato) tiene que estar separado de lo que hace el modelo (la tasa medida).

### QA-06 · S2 · E2 · confianza 0,85 — La compuerta AC-8 no puede dar cero: «línea» e «incidente» son palabras comunes del texto de la guía

- **Ubicación**: §F.10 AC-8 (l. 697).
- **Afirmación**: AC-8 exige cero apariciones de «línea» e «incidente», entre otras. El propio plan pone en la guía «línea de tiempo» (§4.1, l. 352), «hitos "C" en una línea» (l. 480) y «una línea al empezar» (l. 145). En seguridad y operación, «incidente» es vocabulario normal. Un `grep` por términos sueltos da falsos positivos seguros. O la compuerta nunca pasa, o se la termina ignorando.
- **Ancla**: l. 697: «Barrido RD-PO-4 en cero (sin «reclamo», «ticket», «línea», «incidente» ni nombres de otros proyectos)»; l. 352: «tabla de 12 hitos "I" de N1b §3.2 + línea de tiempo».
- **Impacto**: es un criterio de aceptación imposible de cumplir tal como está escrito, y deja sin control efectivo RD-PO-1 a RD-PO-3.
- **Dirección**: escribir el barrido como patrones de dominio (por ejemplo, «línea de colectivo», «reclamo ciudadano», nombres de entidades ajenas en identificadores de código), con una lista de excepciones revisada, y validar la compuerta contra el propio plan antes de usarla.

### QA-07 · S2 · E2 + E4 · confianza 0,7 — Falta rastreo del estado de verificación desde la fuente hasta la guía (snippets y evidencia de los dossiers)

- **Ubicación**: §C, patrón interno paso 3 (l. 304); §F.10 AC-6 (l. 695); §E.1 «Modelo de embeddings» (l. 530); `11` (l. 556).
- **Afirmación**:
  - El contrato define como S1 un «snippet marcado como ejecutado que no compila o no corre». Sin embargo, ningún AC verifica que el snippet impreso en la guía sea el texto que compiló: AC-6 compara sólo versiones. N3 muestra que la distancia es real: «E1, E3 y E4 ejecutaron variantes, no estos textos literales» (N3 l. 189).
  - «La CI compila y corre todo sin red» (l. 533): no se dice qué CI es.
  - El plan usa como base la evidencia de N3 E3 («8/8 en el conjunto de oro», l. 530) y la de E5 (l. 556) sin decir que la verificación de N3 las marcó «**no verificada** de forma independiente (no re-ejecutada)» (N3 l. 520 y 522).
- **Ancla**: contrato l. 106: «S1: […] snippet marcado como ejecutado que no compila o no corre»; plan l. 695: «Versiones de `Directory.Packages.props` = versiones que cita la guía»; N3 l. 522: «E5: la respuesta citó y contradijo la fuente | **no verificada** de forma independiente».
- **Impacto**: la guía puede heredar como E1 resultados que no se re-ejecutaron, y snippets que difieren del código probado. Es el S1 del contrato, sin una compuerta que lo detecte.
- **Dirección**: agregar una compuerta que compruebe que cada bloque de código de la guía sale de un archivo de `Examples/` o `Demos/` (o lleva el rótulo «no compilado» o «adaptación no ejecutada»). Dar a cada cifra que se tome de un dossier su estado (verificada, no re-ejecutada) y re-ejecutarla en `10` y `11` antes de citarla. Nombrar dónde corre la «CI», o reemplazarla por el comando en contenedor que la sustituye.

## Posición sobre las propuestas de la presidencia (dentro del mandato)

| PR | Posición | Fundamento |
|---|---|---|
| PR-3 | apoya_con_cambios | Los tres niveles son testeables y cada ejemplo trae su modo `--fake`. Falta lo de QA-01: una aceptación por ejemplo, no sólo para la demo. |
| PR-8 | apoya_con_cambios | La parte de tiempos de `12` es medible y tiene precedente (X4b: `prompt_eval_duration`, truncado detectable). La parte de calidad no tiene un camino ejecutable: con `qwen2.5:0.5b` falló Q1 en todas las corridas (N3b l. 482), un 7B «con el servidor sin carga» no tiene condición verificable, y con `num_ctx` 8192 explícito en el servidor compartido choca con R-04 (igualar el `num_ctx` cargado, 65.536). Hay que declarar la calidad como «no medida» o definir dónde corre. |
| PR-10 | apoya_con_cambios | El conjunto de oro con consultas no respondibles es el lugar justo. Hay que aclarar que lo que se llama recall@k es *hit rate@k* (N3 l. 128 y 580) y que la cifra 8/8 de N3 E3 está sin re-ejecutar (QA-07). |
| PR-15 | apoya | Una lista de control interna, verificable por cobertura (sección + ejemplo + pregunta por preocupación), que no se publica: no tiene problemas de prueba. |
| PR-20 | apoya_con_cambios | Faltan las negativas de PR-20, que nombra «código postal inválido» (I-05 l. 65). `05` lo omite, y sus herramientas (`contar_localidades(provincia)`, `listar_localidades`) no tienen un parámetro donde probarlo. Además, la prueba de «sesión ajena» es de cableado (la sesión no es argumento) y tiene que ir separada de la tasa con modelo. Y hay que dar un oráculo para «no inventa» (QA-04). |
| PR-22 | apoya | El criterio de `08` (nombre, descripción y parámetros iguales en los dos esquemas, compilando juntos con `FunctionCallContent` calificado, N4 V01) es determinista y no necesita modelo. Es E1 limpio. |
| PR-16 | apoya_con_cambios | El principio se puede probar donde lo hace cumplir el código (cero bajas sin aprobación, nunca un CP inválido en la base). Donde depende del modelo (D2), el plan lo afirma sin probarlo (QA-05). |

## Revisado y bien

1. La separación entre `Cableado/` (cliente guionado, sin red, en cada build) y `ConModelo/` (`[Category("LLM")]`). Las invariantes que hace cumplir el código se afirman como «siempre» y las del modelo como tasa: «nunca hay una localidad con CP inválido en la base» (`06`), «sin aprobación, cero bajas» (`07`, `17`), «un valor fuera de catálogo siempre produce error» (`04`). Coincide con N5 §2.4 y con N6 Q3, Q5 y Q6.
2. Las variantes negativas que reproducen fallas medidas: `01` con el razonamiento encendido y un presupuesto chico, que devuelve `Text` vacío (Sondeo §2: dos de dos), y `12`, que detecta el truncado por `num_ctx` comparando tokens de entrada (N3b X4b: 4.728 → 2.050).
3. El generador de embeddings falso usa un hash estable (FNV/SHA-256) y no `string.GetHashCode()`, la corrección de N6 D5/F19. Las aserciones son sobre forma y propiedades, nunca sobre texto literal (R-LLM).

## Solicitudes de convocatoria

- **AH-02 (Evaluación de sistemas LLM y RAG)**: tiene que decidir la unidad de muestra y el N de las tasas (QA-02, QA-03, P-07), la calibración del juez de `15` (cuántos casos anotados, con qué criterio de acuerdo) y el oráculo de «contradice la fuente» en `11`.
- **Operación y entrega**: el presupuesto de tiempo de las corridas R-LLM en el servidor compartido. Hay unas quince superficies con N de 5 a 10 y entre 11 s y más de 200 s por llamada (Sondeo §2, §3 y §7), y no está estimado si entra en los turnos `<recurso-compartido>` (MD-2).
