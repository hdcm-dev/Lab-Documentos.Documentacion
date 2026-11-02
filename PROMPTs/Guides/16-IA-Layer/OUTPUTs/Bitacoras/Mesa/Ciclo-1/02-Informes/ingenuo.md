---
doc_id: BIT-16-MESA-C1-INF-INGENUO
doc_type: informe-de-especialista
title: Informe del implementador ingenuo sobre el plan de integración v0
rol: Implementador ingenuo (núcleo permanente)
objeto: 04-Plan-De-Integracion.md (v0)
modo: a ciegas (sin leer Ciclo-1 ni informes de otros especialistas)
fecha: 2026-10-26
---

# Implementador ingenuo: informe sobre el plan v0

Leí el plan como si me tocara construir `Examples/` y la demo mañana, sin haber estado en la corrida. Cada hallazgo es una pregunta que tendría que hacer antes de escribir código. Contrasté cada una con los dossiers, el sondeo y la evidencia de `Nucleos/`.

## Hallazgos

### H-01 · S2 · E1 · confianza 0,85. El corpus de los ejemplos 10 y 11 y de D5 no es el que se midió

- **Ubicación**: §E.3 `10-Embeddings-Y-Busqueda-Semantica` y `11-RAG-Con-Citas`; §E.1 (modelo de embeddings: «8/8 en el conjunto de oro de N3 E3»); §F.6 («reconstruido al arrancar desde los literales de `*Policy`»).
- **Afirmación**: el plan dice que el ejemplo 10 busca sobre «los 12 enunciados de `*Policy`». Para respaldar el modelo de embeddings cita el 8/8 de N3 E3. Pero E3 no midió sobre los literales de `*Policy`. Midió sobre 12 reglas **redactadas por el investigador**, que no son los literales. Entre ellas hay fragmentos que no son `*Policy`, como `sesion`, `enc-pasos` y `loc-baja`. Los ids tampoco coinciden: E3 usa `loc-cp` y el plan espera `LocalidadPolicy.RequisitoDelCodigoPostal`. Según N6 §1.1, los literales son textos muy cortos y sin sujeto («4 dígitos.», «Entre 16 y 110 años.»). Si tengo que construir el ejemplo, no sé qué indexo, con qué ids, ni con qué preguntas de oro.
- **Ancla**: `Nucleos/N3-Evidencia/E3-rag-real-Program.cs`: `("loc-cp","reglas/localidad#codigo-postal","El código postal de una localidad se compone de exactamente 4 dígitos numéricos.")` … `("sesion","persistencia#sesion","Cada visitante tiene su propia sesión…")`. N6 §1.1: `*Policy` = «Requisitos enunciados para la persona ("4 dígitos.", "Entre 16 y 110 años.")», «12 enunciados».
- **Impacto**: el ejemplo, la demo D5 y §7.5 citarían una métrica medida sobre otro corpus. La recuperación sobre los literales cortos puede salir distinta, y nadie la midió.
- **Dirección**: decidir cuál es el corpus de RAG. Una opción son los literales, con su propiedad como contexto. La otra es un texto redactado y rotulado «escrito para el ejemplo». Con eso se fija el esquema de ids y de `Fuente` y el conjunto de oro. Después hay que volver a medir, o decir que el 8/8 corresponde a otro corpus.

### H-02 · S2 · E1 · confianza 0,8. La regla de `num_ctx` no se puede construir tal como está escrita

- **Ubicación**: §E.1 (`num_ctx`), tablas E.2 a E.4 (columna «el cargado (LAN)»), §G.3 D-03.
- **Afirmación**: §E.1 pide que `num_ctx` sea explícito y que, en el servidor compartido, «coincida con el cargado». Pero el mismo párrafo dice que no está verificado cómo se pasa desde `IChatClient` con OllamaSharp. Tampoco dice de dónde saca el ejemplo el valor cargado: ¿lee `/api/ps` al arrancar, o usa un número fijo en `OLLAMA_NUM_CTX`? Además, la evidencia muestra dos comportamientos al omitirlo. En la LAN, un pedido sin `num_ctx` usó el contexto del modelo cargado (65.536). En el Ollama propio, el default 4096 truncó. No sé si en la LAN tengo que fijarlo, omitirlo o leerlo.
- **Ancla**: plan §E.1: «Cómo se pasa `num_ctx` desde `IChatClient` con OllamaSharp **no está verificado** (§G, D-03)». N3b X3: «sin `num_ctx` (usa el del modelo cargado, 65.536)». N3b X4b: «Con el default de 4096, un prompt de 4.728 tokens quedó en 2.050».
- **Impacto**: afecta a casi todas las filas de E.2 a E.4 y a la demo. Si se fija mal el valor, el modelo del servidor compartido se recarga y perjudica a los demás clientes (R-04). Si no se fija, el texto se trunca sin error (R-03).
- **Dirección**: correr la sonda D-03 **antes** de la construcción, no en paralelo. Escribir la regla por contexto: LAN, Ollama propio y nube. Para cada uno: qué se hace, de dónde sale el valor y cómo se detecta un truncado.

### H-03 · S2 · E2 · confianza 0,75. No está definido qué contiene `Examples/_Comun` ni cómo lo usa cada ejemplo

- **Ubicación**: §E.1 («Dominio mínimo compartido»), filas `02`, `04`, `05`, `06`, `07`, `09`, `17`; §F.2 (endurecimiento T2).
- **Afirmación**: según §E.1, `_Comun` tiene «copia de `Domain/` y de los servicios necesarios de `Application/`». Sin embargo, `05`, `06`, `07`, `09` y `17` necesitan persistencia (EF Core, repositorios, `SessionSeeder`, una implementación de `ISessionContext`), y eso no figura. El `04` exige que un medio inventado «se **rechaza** en vez de descartarse», pero ese endurecimiento (T2) sólo se declara para la demo. Tampoco se dice si los ejemplos referencian `_Comun` por `ProjectReference`, lo que contradice la «consola net10.0 independiente» de N6. Por último, el criterio del `02` («`grep` de `OllamaSharp` y `OpenAI` fuera del host») supone capas dentro de una consola de un solo proyecto, y no hay una estructura de carpetas que lo permita.
- **Ancla**: plan §E.1: «`Examples/_Comun/MovilidadUrbana.Dominio/` con copia de `Domain/` y de los servicios necesarios de `Application/`». Plan §F.2: «**endurecimiento declarado** … Se declara como desvío del caso base» (sólo para la demo). N6 §5: «Cada uno es una consola net10.0 independiente en `Examples/NN-Nombre/`».
- **Impacto**: cada constructor resolvería la duda a su manera. Los ejemplos terminarían con reglas distintas, que es justo lo que `_Comun` debía evitar, y el `04` podría no rechazar `"avion"`.
- **Dirección**: especificar el contenido de `_Comun`: Domain endurecido o no, Application, y persistencia con siembra y sesión. Fijar cómo se referencia y qué estructura mínima de carpetas tiene cada ejemplo para que los criterios de capas se puedan verificar.

### H-04 · S2 · E1 · confianza 0,8. Faltan datos de encuesta para D4, `resumir_encuesta` y el ejemplo 14

- **Ubicación**: §F.1 D4, §F.4 `resumir_encuesta`, §E.4 `14-Uno-O-Varios-Agentes`.
- **Afirmación**: «¿Qué medio usa más la gente?» y «Resumí qué medios usa la gente» suponen que hay respuestas de encuesta cargadas. La siembra del caso base sólo carga localidades, y el plan no especifica un conjunto de respuestas. Tampoco dice si «la gente» son todas las sesiones o sólo la propia. No se sabe si `RespuestaDeEncuesta` se aísla por sesión: N6 lo dice para `Localidad` y no para la encuesta. En el `14`, el revisor tiene que verificar que no haya nombres ni edades. Si el redactor sólo recibe agregados, la propiedad se cumple siempre y la comparación «uno o varios» no mide nada.
- **Ancla**: N6 §1.1: «`Localidad` … aislada por `SessionId` … (siembra: Corrientes y Resistencia)»; «`IEncuestaRepository` sólo tiene `AddAsync` y `CountAsync`». N6 §7: «siembra Corrientes/Resistencia» (confirmada contra `SessionSeeder.cs`).
- **Impacto**: con la base vacía, D4 y el `14` responden «no hay datos» o inventan. Su R-LLM no mostraría lo que dice el plan.
- **Dirección**: definir un conjunto de respuestas rotulado «escrito para el ejemplo», cuándo y cómo se siembra y su alcance (sesión o global). En el `14`, aclarar por dónde podrían entrar datos personales, para que el revisor tenga algo que atrapar, o cambiar la propiedad que se mide.

### H-05 · S3 · E1 · confianza 0,8. El corpus sintético del ejemplo 12 no se puede reproducir con lo que hay

- **Ubicación**: §E.3 `12-CAG-vs-RAG` («70 artículos, semilla 7 … valores de `Catalogos`»).
- **Afirmación**: el corpus de X3 y X4b lo generó un script Python (`e1/corpus.py`, `random.seed(7)`). Los valores esperados (Art. 7 → 3961, Art. 12 → Santa Fe) dependen del generador de Python. Si lo hago en C# con `new Random(7)`, sale otro corpus y otras respuestas. El script quedó en un directorio de trabajo fuera del repo. Python está fuera del stack DC-07. Además, el plan dice «valores de `Catalogos`», pero los códigos postales y los nombres de las localidades de referencia no están en `Catalogos`.
- **Ancla**: N3b X3: «70 artículos generados con `random.seed(7)` (16.748 bytes). Script `e1/corpus.py`». N3b verificación: «Los intermedios están en `{dir-de-trabajo}/n3b-verif/`». N3b: «Corpus sintético: 70 artículos, `seed(7)` … Art. 7 → 3961, Art. 12 → Santa Fe | Confirmada | `corpus70.txt` y `corpus.py`».
- **Impacto**: el ejemplo no repite la medición que lo justifica. El constructor tendría que inventar el corpus y sus valores esperados.
- **Dirección**: decidir si el corpus se genera en C#, con sus valores esperados recalculados y documentados, o si se versiona como texto fijo rotulado dentro de `Examples/12`. Decir de dónde salen los códigos postales y los nombres.

### H-06 · S3 · C · confianza 0,5. ¿Cómo obtiene su sesión la página Blazor?

- **Ubicación**: §F.5, primer punto: «por la cookie del circuito (página Blazor) y la resuelve `SessionHeaderMiddleware` → `ISessionContext` scoped».
- **Afirmación (pregunta)**: ¿cómo maneja la sesión el MovilidadUrbana.Web del caso base? ¿Cómo llega una cookie a un middleware que lee el encabezado `X-Sesion-Id`, si en Interactive Server los servicios scoped viven por circuito y no por petición HTTP? Ningún dossier lo documenta. N6 sólo leyó el `Program.cs` de la Web.
- **Ancla**: N6 E4: «Archivos leídos: `Program.cs` de Web y ApiWeb, `Domain/*`, `Application/*`, `Infrastructure/Persistence/{SessionSeeder,EncuestaRepository}.cs` y `Controllers/EncuestasController.cs` de ApiWeb». No hay lectura de cómo maneja la sesión la Web.
- **Impacto**: si la página de chat no puede resolver la sesión así, las herramientas leen la sesión equivocada o una vacía, y la prueba de aislamiento no cubre la web.
- **Dirección**: sondear el caso base (sólo lectura) y escribir el mecanismo con evidencia antes de diseñar la página.

### H-07 · S3 · E2 · confianza 0,7. No está definido el arnés de verificación de los ejemplos

- **Ubicación**: §E.1 («La CI compila y corre todo sin red», «Corridas contra el modelo (R-LLM)»), fila `15` («Respuestas de `11` → puntajes»), nombres de variables.
- **Afirmación**: el plan habla de «la CI», pero no dice qué CI es ni dónde corre. Tampoco dice dónde y en qué formato escribe cada ejemplo su registro R-LLM, ni quién calcula la «tasa en N»: ¿la consola, un script, NUnit? El `15` consume «respuestas de `11`» y no dice cómo: ¿un archivo fijo, una corrida previa? Las variables de los dossiers tampoco coinciden con las del plan. N3 usa `OLLAMA_EMBEDDING_MODEL`, y su E3 usa `OLLAMA_ENDPOINT` para los embeddings y `OLLAMA_CHAT_ENDPOINT` para el chat. El plan usa `OLLAMA_EMBED_ENDPOINT` y `OLLAMA_EMBED_MODEL`.
- **Ancla**: plan §E.1: «La CI compila y corre todo sin red». Plan §E.4 `15`: «Respuestas de `11` → puntajes». N3 §4: `GetEnvironmentVariable("OLLAMA_EMBEDDING_MODEL")`. N3 E3: `OLLAMA_ENDPOINT` (embeddings) y `OLLAMA_CHAT_ENDPOINT`.
- **Impacto**: cada ejemplo registraría a su manera. No se podría comparar R-LLM entre ejemplos, el `15` dependería de una corrida del `11` sin contrato y los snippets copiados de los dossiers fallarían en silencio por el nombre de la variable.
- **Dirección**: definir un comando único (script en contenedor) que compile y corra todo en modo `--fake`. Definir el esquema y el destino del registro R-LLM, la entrada fija del `15` y una tabla canónica de variables de entorno que los snippets reescritos tengan que respetar.

## Posición sobre las propuestas de mi mandato

| PR | Posición | Fundamento |
|---|---|---|
| PR-3 | apoya con cambios | Los tres niveles sirven para construir, pero los niveles intermedio y avanzado no se pueden construir hasta resolver H-01 a H-05 y H-07 (corpus, `num_ctx`, `_Comun`, datos de encuesta, arnés) |
| PR-7 | se opone | Un primer agente sobre git o un servidor MCP de ejemplo saldría del caso único (I-06). El `05` de sólo lectura cubre la misma intención con datos que la siembra ya trae (Corrientes y Resistencia) |
| PR-8 | apoya con cambios | El ejemplo 12 está bien acotado (Ollama propio, CPU, «no representativo de GPU»), pero su corpus no se puede reproducir (H-05) y depende de D-03 (H-02) |
| PR-16 | apoya | Las cinco reglas operativas de §A.4 se traducen en aserciones concretas («cero bajas sin aprobación», «nunca una localidad con CP inválido», «toda clave pertenece a `Catalogos`») |
| PR-17 | apoya con cambios | §F.2 dice con claridad qué se copia y qué es nuevo. Falta resolver la sesión de la página Blazor (H-06) y los datos de encuesta (H-04) |
| PR-20 | apoya | El `05` trae entrada, salida esperada, cuatro negativas y un guion falso. Se puede construir con la siembra de N6 |
| PR-22 | apoya | El `08` no llama al modelo, tiene una prueba sobre los metadatos y avisa la trampa verificada de `FunctionCallContent` (N4 V01) |

## Revisado y bien

1. El ejemplo `13` se puede construir sin preguntar nada. Nombra el paquete generador, el error si falta (`CS0534`) y `BindAsExecutor` frente a `BindExecutor`, y no usa modelo.
2. La tabla §F.4 asigna a cada herramienta su caso de uso, su tipo y su control. Excluye `RegistrarAsync` con motivo (H6/T7). Con esa tabla se arman las herramientas sin decidir nada nuevo.
3. Los criterios §F.10 (AC-1 a AC-8) son comandos mecánicos (`dotnet test --filter`, `grep`, comparación de versiones) que puedo correr y adjuntar como evidencia E1.

## Solicitudes de convocatoria

- Edición o coherencia documental: el plan crea SUP-09 (embeddings con un Ollama propio) cuando SUP-06 del contrato ya cubre ese caso con otra redacción. Hay que unificarlos o decir cuál manda.
- IA o modelos: confirmar si la tasa N=5 alcanza para comparar el `14` (una variante frente a la otra) sin que el ruido de un servidor compartido cambie la conclusión.
