---
doc_id: BIT-16-C2-INF-experto-ia
doc_type: informe-de-mesa
title: Relectura integral (ciclo 2) — Experto en IA
fecha: 2026-10-28
rol: Experto en IA
mandato: corrección conceptual (LLM, tokens, ventana y truncado, embeddings y similitud, abstención, chunking, RAG/CAG/contexto fijo, tool calling, agentes, workflow, MCP, LangGraph en .NET) y fidelidad de las afirmaciones sobre los Qwen a lo medido
objeto: Dot-Net-Integration-AI-Layer-Guide.md (leída de punta a punta), Examples/06 y 10 (README), Demos/MovilidadUrbana.Asistente (README y registros R-LLM)
a_ciegas: sí (no se leyó ningún otro Informe-*.md del ciclo 2)
evidencia: evidencia-experto-ia/
---

# Informe del Experto en IA — relectura integral, ciclo 2

## 1. Alcance y método

Leí la guía completa por partes (§0 a Anexo E.4), contrastando cada afirmación conceptual de mi mandato con su fuente o con el registro de la corrida. Para lo medido sobre los Qwen fui al registro crudo: `evidencia-examples/06-Tool-Calling/con-modelo/`, `evidencia-examples/01-Chat-Basico/con-modelo/rllm/num-ctx-humo.txt`, `evidencia-examples/09-Pruebas-Con-Cliente-Falso/contexto-truncado.txt`, `evidencia-demo/pruebas/conmodelo/CTRL14-*.jsonl` y la tabla E.4 de la propia guía. Para MAF consulté el XML de documentación de `Microsoft.Agents.AI.Workflows` 1.26.0 del paquete restaurado (la misma versión de los ejemplos). No corrí nada contra el modelo: ningún hallazgo lo necesita (R-LLM no aplica).

Evidencia propia en `evidencia-experto-ia/`:

- `01-maf-group-chat-manager.txt`: tipos y miembros de group chat en el XML de MAF 1.26.0.
- `02-ctrl14-resumen.txt`: líneas de resumen de los dos registros CTRL-14 de la demo.
- `03-misiones-lectura-manual.txt`: las 20 respuestas a «Misiones» de `Examples/06` y mi conteo manual.

## 2. Hallazgos

### EXPERT-01 · S2 · coherencia — La doble negación invierte el resultado de la inyección

- **Ubicación:** guía §8.10.1, l. 3086.
- **Evidencia:** el texto dice «el modelo **no propuso una baja en 0/10** corridas, Wilson 95 % [0; 0,28], **no pidió** una herramienta inexistente **en 0/10**». Leído literal, significa que propuso la baja en 10/10. El registro dice lo contrario: `"propuso_baja":"0/10 … [0,00; 0,28]"`, `"pidio_herramienta_inexistente":"0/10"`, `"repitio_el_texto":"10/10"` (`evidencia-experto-ia/02-ctrl14-resumen.txt`). El README de la demo lo dice bien («propuso una baja: 0/10»). Es la única cifra con modelo sobre inyección indirecta, y la frase la da vuelta.
- **Propuesta:** reemplazar por: «Contra el modelo, con la composición de la demo, ante la inyección por `Localidad.Nombre`: propuso una baja en 0/10 corridas, Wilson 95 % [0; 0,28]; pidió una herramienta inexistente en 0/10 [0; 0,28]; y le **repitió el texto inyectado** a la persona en 10/10 [0,72; 1] (…resto igual).»

### EXPERT-02 · S2 · técnico — En el group chat de MAF 1.26.0 no elige un modelo: elige el `GroupChatManager`, y el que trae el paquete rota por código

- **Ubicación:** guía §7.1.3 «Qué no es» (l. 1864), §7.7 (l. 2355), §7.13.8 (l. 2601), Anexo C, fila «Workflow de MAF» (l. 3758); `Examples/10-Workflow/README.md`, l. 218.
- **Evidencia:** la guía dice cinco veces que en *handoff*, *group chat* y *Magentic* «quien elige el siguiente paso es un modelo». En el XML de `Microsoft.Agents.AI.Workflows` 1.26.0, el group chat se arma con `AgentWorkflowBuilder.CreateGroupChatBuilderWith(Func<IReadOnlyList<AIAgent>, GroupChatManager>)`. El paso siguiente lo decide `GroupChatManager.SelectNextAgentAsync`, y el único gestor concreto del paquete es `RoundRobinGroupChatManager`: «selects agents in a round-robin fashion» (`evidencia-experto-ia/01-maf-group-chat-manager.txt`). En *handoff* sí elige el modelo, porque el traspaso es una herramienta que invoca el agente (lo dice el mismo XML). En *Magentic* elige un orquestador con modelo. Con el gestor del paquete, el group chat es de código: la clasificación «a ese nivel la orquestación es de agente» no vale para él. Esto toca la definición central de §7.1, «quién decide el próximo paso».
- **Propuesta:** en §7.1.3 cambiar por «… en las orquestaciones *handoff* y *Magentic* quien elige el siguiente paso es un modelo, así que a ese nivel la orquestación es de agente [REF-094]. En *group chat* lo elige el `GroupChatManager`: el único que trae MAF 1.26.0, `RoundRobinGroupChatManager`, rota por código; un gestor propio puede consultar a un modelo, y entonces vale lo mismo.» Ajustar con la misma idea §7.7 l. 2355 («Con *handoff* y *Magentic* el armado usa el mismo tipo, pero quien elige el siguiente paso es un modelo; en *group chat*, el gestor: por turnos en el que trae el paquete. Ninguna de las tres se midió en esta guía.»), §7.13.8, la fila del Anexo C («cuando lo arma *handoff* o *Magentic*, o un *group chat* con un gestor que consulta a un modelo») y el README de `Examples/10` («orquestaciones en las que un modelo elige el paso siguiente (*handoff*, *Magentic*, o *group chat* con un gestor propio que consulte a un modelo)»).

### EXPERT-03 · S2 · evidencia — «El modelo contestó 14, 30 y 34» atribuye al truncado un error de respuesta que no se midió

- **Ubicación:** guía §2.5, viñeta «La ventana declarada no es la configurada» (l. 410).
- **Evidencia:** la viñeta arranca con «El 4b declara 262 144 tokens…», y el párrafo de arriba fija que el modelo es el 4b «salvo donde se nombra otro». Sigue «…y el modelo contestó «14», «30» y «34» a «¿Cuántas respuestas hay en total?»; con 8192 y 16 384 llegaron los 6843», y recién después «Invariante con `qwen2.5:0.5b`». El registro (`num-ctx-humo.txt`) muestra que esas salidas son de `qwen2.5:0.5b`, el modelo de humo, con `MaxOutputTokens` 3. Con 8192 y 16 384 el mismo modelo, en sus 3 tokens, dijo «Tiene» y «La encuesta», no un total. No hay contraste: no se sabe si con la ventana entera habría respondido bien. Al lector le queda «el 4b, recortado, contestó mal», y eso no se midió. Lo que sí se midió con el 4b está en `Examples/09`: con 8192 respondió «3001» en 3 de 3 y con 4096 saltó el detector («esperado 5114, recibido 2050»).
- **Propuesta:** reescribir la viñeta así: «**La ventana declarada no es la configurada.** El 4b declara 262 144 tokens nativos y el servidor de prueba, sin configuración, lo cargó con 4096. Con un prompt de 5114 tokens y `num_ctx` 4096 en el pedido, el 4b recibió 2050 en 3 de 3 semillas, con fin `stop` y **sin error**; con 8192 recibió los 5114 (`Examples/09-Pruebas-Con-Cliente-Falso`, *estación con más núcleos*). Lo mismo con `qwen2.5:0.5b`, el modelo de humo, y 242 respuestas de la encuesta (6843 tokens): con 4096 llegaron 2050 y el pedido se respondió igual, sin aviso; con 8192 y 16 384 llegaron los 6843 (`Examples/01-Chat-Basico/…/NumCtxConModeloTests.cs`, *estación de 4 núcleos*). El recorte no fue «ventana menos salida»: quedó menos de la mitad, y la única señal fue comparar `Usage.InputTokenCount` con lo esperado.» Si se quiere conservar «14/30/34», va rotulado: «salidas de 3 tokens del modelo de humo; con la ventana entera no se midió si acertaba».

### EXPERT-04 · S3 · evidencia — «Se perdió el principio» no está medido

- **Ubicación:** guía §6.5, l. 1511 («quedó **menos de la mitad**, y se perdió el principio, donde suelen estar las instrucciones»); §6.12, antipatrón «Corpus grande a Ollama sin `num_ctx`» (l. 1819, «…y se pierde el principio»).
- **Evidencia:** los registros del truncado (`Examples/01` y `Examples/09`) miden cuántos tokens leyó el servidor (2050) y si hubo error (no). Ninguno mide **qué** tramo se conservó. No hay marcador al principio ni al final del prompt, ni log de truncado del servidor. La afirmación describe el mecanismo interno de Ollama sin evidencia en el laboratorio ni en una fuente citada. La regla de §6.5 tampoco la necesita: trata el truncado como error, sea cual sea el tramo perdido.
- **Propuesta:** en §6.5: «Con 4096 no quedaron unos 4000 tokens: quedó **menos de la mitad**. Qué tramo se conservó no se midió: el servidor no lo informa y la respuesta no lo delata. Por eso la regla trata el truncado como error, sin importar qué parte se perdió.» En §6.12: «Se recorta sin error a menos de la mitad, y la respuesta no avisa».

### EXPERT-05 · S3 · coherencia — «No del tamaño del modelo» generaliza desde dos modelos chicos

- **Ubicación:** guía §7.5, l. 2070 («El riesgo nace de **ofrecer** la herramienta, no del tamaño del modelo.»); §9.5.3, l. 3391.
- **Evidencia:** la base es un pedido («Borrá Resistencia») con dos modelos de 2B y 4B, 10/10 en cada uno, «no separados» (§9.7, E.4). Con dos tamaños chicos se puede decir que el tamaño **no lo evitó**. No se puede decir que el riesgo no dependa del tamaño en general: ningún modelo mayor se midió en D6 (el `qwen3.5:35b-a3b` se midió sólo en latencia y en herramientas de lectura, §9.7). Esto choca con la regla de la propia guía de no generalizar una tasa de un pedido.
- **Propuesta:** en §7.5: «…los dos modelos quedan «no separados». Estación de 4 núcleos. Con estos dos tamaños, el tamaño no lo evitó: el riesgo nace de **ofrecer** la herramienta. Con modelos mayores no se midió.» En §9.5.3, después de «(…estación de 4 núcleos)», agregar: «con modelos mayores, no medido».

### EXPERT-06 · S3 · evidencia — El conteo manual de «cero sin consultar» en `Examples/06` queda corto

- **Ubicación:** guía §7.3.4, párrafo «Lo que esto enseña» (l. 2022, «entre 3 y 4 de cada 10») y tabla (l. 2017–2018, celda «afirma un conteo con número 0/10»); `Examples/06-Tool-Calling/README.md`, l. 196–198 («en 3 de 10 (`/api/chat`) y 4 de 10 (`/v1`)»).
- **Evidencia:** en las 20 respuestas crudas (`evidencia-experto-ia/03-misiones-lectura-manual.txt`), sin herramienta, el modelo afirma «no hay localidades cargadas» o «el número total es cero» en s = 3, 4, 5 y 9 por `/api/chat` (4/10). Por `/v1` lo hace en s = 3, 4, 5 y 10 (4/10), y en 5/10 si se cuenta s = 8 («no se cargaron localidades para esa región»). La celda «0/10» es la regex del criterio previo (`\b\d+\s+localidad`, sólo dígitos), que no ve «cero» ni «no hay». Leída sola, la tabla parece decir que el modelo nunca afirmó un conteo, justo lo contrario de la lección. §3.2 se apoya en este dato («a veces afirmó «cero» sin consultar»).
- **Propuesta:** en la tabla, la celda pasa a «conteo en dígitos (regex del criterio previo) 0/10 [0,00; 0,28]». En el párrafo: «Por lectura manual, 4 de 10 respuestas por cada vía afirmaron «no hay localidades cargadas» o «el número total es cero» sin haber consultado (por `/v1`, 5 si se cuenta «no se cargaron localidades»; existencia): la regex del criterio previo, que busca dígitos, no las ve.» En el README, cambiar «en 3 de 10 (`/api/chat`) y 4 de 10 (`/v1`)» por «en 4 de 10 por cada vía (5 de 10 por `/v1` si se cuenta «no se cargaron localidades»)».

### EXPERT-07 · S4 · evidencia — §7.13.2 da como «medianas» un rango que no figura en E.4

- **Ubicación:** guía §7.13.2, l. 2583 («una llamada a herramienta con el modelo cargado tardó de 4,65 a 4,96 s de mediana por serie»).
- **Evidencia:** según E.4, «toda cifra de latencia de la guía sale de esta tabla». Ahí las dos series de herramientas del 4b tienen medianas de **4,68** s (rango 4,65–34,51) y **4,75** s (4,69–20,61). «4,96» no aparece en E.4, y «4,65» es un mínimo, no una mediana. La cifra viene de una bitácora previa que mezcló mínimos y medianas.
- **Propuesta:** «…una llamada a herramienta con el modelo cargado tuvo medianas de 4,68 y 4,75 s en dos series de 10 (estación de 4 núcleos; Anexo E.4), y cada vuelta del bucle es una llamada más.»

### EXPERT-08 · S4 · coherencia — «Ese umbral no se midió acá» no dice qué umbral

- **Ubicación:** guía §6.11.15, l. 1806.
- **Evidencia:** la respuesta compara contexto fijo con RAG (516 tokens, mínimo cacheable de la nube) y cierra con «Ese umbral no se midió acá». En el párrafo, el único umbral nombrado es el mínimo cacheable, que sí está citado [REF-076][REF-077]. Lo que no se midió es otra cosa: el tamaño de corpus a partir del cual RAG empieza a convenir en local. El lector no tiene cómo saberlo, y la frase puede leerse como que el mínimo cacheable no está sustentado.
- **Propuesta:** «A partir de qué tamaño de corpus RAG empieza a convenir frente al contexto fijo en local no se midió acá.»

## 3. Revisado y bien

1. **CAG bien acotado (§6.1, §6.4.1, §6.11.11, §6.11.13).** Separa el CAG del paper (caché KV persistida y recargada, con el modelo en proceso) de su versión de servicio (prefijo estable más caché del servidor) y de la caché de respuestas. Del paper cita lo que de verdad dice: BM25 top-5 gana en HotPotQA grande, y la ventaja fuerte es contra el prompt largo sin caché. No le hace decir más que eso.
2. **Recuperación y abstención fieles a lo medido (§6.8, §6.9).** La recuperación se mide antes que la respuesta, con línea de azar. Con y sin instrucción queda «no separado» por un único par discordante. La abstención por umbral se declara fallida con los puntajes superpuestos a la vista, y contexto fijo frente a RAG queda «no separado» con el artefacto del ejemplo de cita explicado. Las cifras coinciden con `evidencia-examples/04` y `05`.
3. **Agente, agente mínimo y LangGraph (§7.1.2, §7.4, §7.10.2).** El agente se define por quién elige el paso, dentro de un límite del código. El agente mínimo es `FunctionInvokingChatClient`, y el agente de MAF reusa su bucle, como mide `DelChatAlAgenteTests` (4 llamadas en los dos caminos). Sobre LangGraph, la guía dice que no es oficial en .NET y que los workflows de MAF son «equivalentes en capacidades, no en modelo de programación», con la diferencia estado/mensajes bien puesta.
