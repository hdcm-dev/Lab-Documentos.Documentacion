---
doc_id: BIT-16-C2-INF-didactica
doc_type: informe-de-relectura
title: Relectura integral de la guía 16, ciclo 2 — informe de Didáctica
status: emitido
origin: agent
owner: Didáctica (relectura integral, ciclo 2)
last_review: 2026-10-28
audience: [presidencia, consolidación, redacción]
traces: [Crear-IA-Layer-Guide.md (prompt del PO, regla de preguntas guía); Crear-IA-Layer-Guide-Reedicion.md (REED-16) §10; Mesa/Ciclo-1/06-Plan-De-Redaccion.md §2 (P-07, P-09) y RV-10; Nucleos/N6-Caso-Movilidad-Urbana.md (7); evidencia-didactica/]
---

# Informe de Didáctica — relectura integral, ciclo 2

**Mandato.** Progresión, definiciones antes del uso, ejemplos que iluminan, calidad de las preguntas guía y de sus respuestas como formadoras de criterio (¿dicen en qué caso aplica cada concepto?), adecuación al lector y carga cognitiva. Fuera de eso no opino.

**Qué se leyó.** La guía completa (4116 líneas, de punta a punta, por partes), los README de `Examples/06-Tool-Calling` (el primer ejercicio) y de la demo, y la lista de títulos de los demás README. A ciegas: no leí otros `Informe-*.md` de este ciclo. Sin pruebas contra el modelo: el mandato no las pide.

**Escala.** S1 bloquea la lectura; S2 desorienta al lector en un concepto central o en un instrumento de decisión; S3 menor, con arreglo local; S4 cosmético o de coherencia sin efecto en la comprensión.

**Evidencia** (en `evidencia-didactica/`, generada con scripts sobre la guía el 2026-10-28):

- `molde-preguntas.txt`: las 73 preguntas guía de §1–§9, con su línea, si llevan etiqueta de alcance ESC/CTX y si llevan una marca explícita de criterio.
- `nombres-de-escenarios.txt`: los nombres con que la guía acompaña a cada ESC.
- `rotulos-y-cifras-repetidas.txt`: rótulos largos de estación y repeticiones del caso «CP 34».

## Hallazgos

### DIDACT-01 · §3.1 define «Situación» y el resto de la guía usa «Contexto» — S2

- **Ubicación:** guía, §3.1, l. 449; Anexo C, fila «Contexto» (remite a §3.1).
- **Evidencia:** §3.1 define **Situación** («una variante que cambia la respuesta correcta dentro de un escenario; vienen de a pares independientes»), pero §3.3 se titula «Contextos», todos los ids son CTX-* y el Anexo C define **Contexto** con ese mismo texto y dice «Se enseña en §3.1». La palabra «situación» no vuelve a aparecer con ese sentido en ninguna sección (`grep -n -i situaci`: l. 449, una tabla de §7.3.1 y el formato del Anexo F). El lector aprende un término que no se usa y no encuentra la definición del que sí se usa en cada encabezado «Escenario y contexto».
- **Propuesta:** reemplazar la l. 449 por:
  > - **Contexto:** una variante del marco (CTX-*) que cambia la respuesta correcta **dentro** de un escenario; vienen de a pares independientes (CTX-LOCAL o CTX-NUBE, CTX-PROTO o CTX-PROD, CTX-PUB o CTX-SENS). No es el texto que recibe el modelo: ese sentido (§6) siempre lleva calificativo, como «ventana de contexto», «contexto fijo» o «contexto truncado».

### DIDACT-02 · El árbol de §3.2 clasifica como ESC-04 el ejemplo canónico de ESC-01 — S2

- **Ubicación:** guía, §3.2, diagrama, l. 474–477.
- **Evidencia:** el nodo `Q2{"¿Quién decide la acción?"}` manda «el modelo elige herramientas» a ESC-04 y «nadie: sólo se responde» a ESC-01. Pero la tabla de la misma sección dice que en ESC-01 el modelo puede «leer, por herramientas», §1.2 manda el dato exacto a «Herramienta de lectura sobre el caso de uso (ESC-01, §7.3)» y D4 («¿Qué medio usa más la gente?») es ESC-01 con una herramienta que elige el modelo. Un lector que use el árbol para clasificar «¿Cuántas localidades hay en Chaco?» (el primer ejercicio) llega a ESC-04, cuyo riesgo dominante es la agencia excesiva: el instrumento de decisión contradice los ejemplos que lo ilustran.
- **Propuesta:** reemplazar las l. 474–477 por:
  ```
    Q1 -- "sí" --> Q2{"¿Qué devuelve el turno?"}
    Q2 -- "un objeto tipado que la aplicación valida y decide" --> E3["ESC-03: extracción estructurada"]
    Q2 -- "acciones sobre la app que elige el modelo" --> E4["ESC-04: agentes y herramientas"]
    Q2 -- "una respuesta, aunque el modelo lea datos con herramientas" --> E1["ESC-01: asistente sobre datos propios"]
  ```
  y agregar, después del diagrama, antes de «Un pedido puede cruzar dos escenarios»: «Leer datos con una herramienta no convierte el pedido en ESC-04: «¿Cuántas localidades hay en Chaco?» es ESC-01 (§7.3, D4). ESC-04 empieza cuando el modelo elige una acción que cambia algo («Borrá Resistencia», D6).»

### DIDACT-03 · Semilla, Wilson y par discordante se usan desde §0.5 y se definen en §8.1.4, o nunca — S2

- **Ubicación:** guía, §0.2 (l. 173), §0.5 (l. 225), §2.5 (l. 405–412), §3.2 (l. 464), §8.1.4 (l. 2650); Anexo C.
- **Evidencia:** §0.2 promete que el lector no necesita estadística porque «los pocos [términos] que hacen falta (token, ventana, embedding, intervalo de Wilson) se definen donde se usan». El intervalo de Wilson aparece en l. 173 (objetivos), l. 225 (§0.5), en las cuatro viñetas de §2.5 y en §3.2, y se define recién en §8.1.4 (l. 2650), unas 2400 líneas después; «par discordante» se usa en §0.5 y se define también en §8.1.4. **Semilla** no se define en ninguna parte: §5.1.6 sólo nombra `Seed` entre los parámetros tipados, y el Anexo C no la tiene, aunque «10 semillas» acompaña a casi todas las cifras y la distinción «este pedido / la tarea» depende de entenderla. Para el lector declarado (sin estadística ni aprendizaje automático), las cifras de §2 y §3 son ilegibles hasta §8.
- **Propuesta:** (a) agregar en §0.5, después del párrafo **Estimandos.** (l. 225):
  > **Tres palabras de estadística, antes de la primera cifra.** Una **semilla** es el número que fija el azar del muestreo de un pedido (`ChatOptions.Seed`, §5.1.6); «10 semillas» son 10 corridas del mismo pedido con azares distintos, y repetir una semilla es reproducción, no una corrida más. El **intervalo de Wilson al 95 %** es un intervalo de confianza para una tasa k/n que se porta bien con N chico: 10/10 da [0,72; 1], así que 10 aciertos en 10 no prueban «siempre». Un **par discordante** es un pedido en el que una variante acierta y la otra no; sólo esos pares cuentan para comparar dos variantes. El detalle está en §8.1.4.

  (b) agregar al Anexo C la fila: «| **Semilla** | Número que fija el azar del muestreo de un pedido (`ChatOptions.Seed`); con el mismo pedido, repetirla es reproducción y no suma a n | una corrida de otro pedido; un pedido distinto | §0.5, §8.1.4 |», y pasar «intervalo de Wilson» y «comparación pareada» de la lista final a filas propias que remitan a §0.5 y §8.1.4.

### DIDACT-04 · Un escenario, cinco nombres — S3

- **Ubicación:** guía, §4.8 (l. 863), §6 encabezado (l. 1324), §6.10 (l. 1754–1756), §7 encabezado (l. 1835), §7.12 (l. 2571–2575), §9 encabezado (l. 3211).
- **Evidencia** (`nombres-de-escenarios.txt`): el Anexo C pide «un término, un sentido» y §3.2 fija los nombres, pero ESC-04 aparece como «agentes y herramientas», «acción con herramientas», «acción con aprobación» y «acciones con confirmación»; ESC-05 como «exposición por MCP» e «integración con terceros»; ESC-01 como «asistente sobre datos propios» y «consulta de datos»; ESC-02 como «búsqueda semántica» y «búsqueda por significado»; ESC-03 como «extracción estructurada» y «extracción a estructura». Un lector que llega a §7 por la ruta de su actor lee «ESC-05 (integración con terceros)» y no lo reconoce como el «ESC-05 Exposición por MCP» de §3.2.
- **Propuesta:** usar en todos esos lugares el nombre de §3.2. En concreto: l. 863 «ESC-04 acción con herramientas» → «ESC-04 agentes y herramientas»; l. 1324 «ESC-02 (búsqueda por significado)» → «ESC-02 (búsqueda semántica)»; l. 1754 y 2572 «ESC-02 búsqueda por significado» → «ESC-02 búsqueda semántica»; l. 1755 y 2573 «ESC-03 extracción a estructura» → «ESC-03 extracción estructurada»; l. 1756 y 2574 «ESC-04 acción con aprobación» → «ESC-04 agentes y herramientas»; l. 1835 «ESC-04 (acción con aprobación). ESC-01 (consulta de datos) aparece en el primer ejercicio y ESC-05 (integración con terceros) en MCP» → «ESC-04 (agentes y herramientas), con las escrituras siempre aprobadas. ESC-01 (asistente sobre datos propios) aparece en el primer ejercicio y ESC-05 (exposición por MCP) en MCP»; l. 2571 «ESC-01 consulta de datos» → «ESC-01 asistente sobre datos propios»; l. 2575 «ESC-05 integración con terceros» → «ESC-05 exposición por MCP»; l. 3211 «ESC-04 (acciones con confirmación)» → «ESC-04 (agentes y herramientas, como acciones que la persona confirma)».

### DIDACT-05 · Las preguntas guía no tienen un molde: en §6, §7 y §9 el criterio no está marcado y en §4, §7 y §9 falta el alcance — S3

- **Ubicación:** guía, §4.9, §6.11, §7.13, §8.13, §9.9; en particular §6.11.13 (l. 1800), §6.11.15 (l. 1806) y §4.9.5 (l. 886).
- **Evidencia** (`molde-preguntas.txt`): de 73 preguntas, §2, §3 y §5 llevan etiqueta *(ESC; CTX)* y cierran con **Criterio:**; §6.11 lleva etiqueta en las 16 y marca de criterio en ninguna; §7.13 (12) y §9.9 (6) no llevan ni etiqueta ni marca; §4.9 (5) lleva **Aplica/Cuándo no** pero no etiqueta; §8.13 marca criterio en 4 de 13. El prompt del PO pide respuestas que «sirvan al lector [para] identificar en qué caso se aplica cada concepto»: el contenido suele estar, pero el lector no lo encuentra en el mismo lugar de cada respuesta. Tres respuestas concretas no forman criterio: §6.11.13 termina en una anécdota de un servidor dado de baja; §6.11.15 cierra con «Ese umbral no se midió acá», sin antecedente para «ese umbral»; §4.9.5 vuelca la cabecera entera de una corrida (doce parámetros) dentro de la respuesta, contra RV-10 del plan («transfiere el criterio, no el resultado de una corrida»).
- **Propuesta:** (a) regla de molde para §4.9, §6.11, §7.13, §8.13 y §9.9: título con *(ESC; CTX)* y una última oración que empiece con **Criterio:**, sin agregar contenido nuevo (la oración se toma del cuerpo, donde ya está; p. ej. §9.9.1: «**Criterio:** buscá dónde la persona escribe o pregunta algo que el formulario no admite; si no hay, no hay capa de IA»; §7.13.3: «**Criterio:** si podés dibujar el diagrama de antemano, workflow; si no, agente»). (b) §6.11.13, reemplazar la segunda oración por: «Por API se obtiene la caché del servidor, que es efímera: cualquier otra carga o un `num_ctx` distinto la descarta sin aviso (§6.4.3). **Criterio:** si el ahorro depende de que la caché sobreviva, medilo con `prompt_eval_cached_count` (§6.4.4); no lo des por hecho.» (c) §6.11.15, reemplazar «Ese umbral no se midió acá.» por «El tamaño de corpus desde el que RAG empieza a convenir no se midió acá.» (d) §4.9.5, reemplazar desde «Estimando: este pedido.» hasta «2026-10-28.» por «(estimando: este pedido; condiciones completas en §5.6).»

### DIDACT-06 · La ruta de ACT-DEV salta las definiciones de §7 — S3

- **Ubicación:** guía, §0.4, l. 209.
- **Evidencia:** la ruta es «§4 → §5 → §7.3 → §6 → §7». §7.3 usa «agente mínimo», «herramienta fina», `FunctionInvokingChatClient` como bucle, CTRL-01/02/05/06 y D-06, y todo eso se define en §7.1 (y el mapa que ubica la herramienta y el agente mínimo como escalones está en §7.2). El ACT-DEV llega al primer ejercicio sin la definición de herramienta (§7.1.1) ni la de agente (§7.1.2), que el molde de la guía pone siempre antes de los ejemplos.
- **Propuesta:** cambiar la celda por «§4 → §5 → §7.1–§7.3 → §6 → resto de §7 → §8.4 → §9».

### DIDACT-07 · §2.5 adelanta cuatro mediciones con vocabulario de §5–§8 en la sección de entrada de ACT-ARQ — S3

- **Ubicación:** guía, §2.5, l. 403–412.
- **Evidencia:** §2 es la primera parada de la ruta de ACT-ARQ (§0.4) y su §2.1 sólo define tres términos. Pero las viñetas de §2.5 usan `num_ctx` (se define en §5.1.7), `OpcionesDeIA` (§5.1.9), «ruta `/v1`» y `/api/chat` (§5.1.8), `Usage.InputTokenCount`, «fin `stop`», el preajuste del Modelfile, semillas y Wilson (ver DIDACT-03), con rutas completas de archivos de prueba y el rótulo largo de estación en cada viñeta (l. 407, 408, 409, 410, 412). La lección de cada viñeta es de una línea y se repite con su evidencia en §5.4, §5.6 y §6.5; acá el lector de arquitectura paga el detalle sin las definiciones.
- **Propuesta:** dejar en cada viñeta la lección, la cifra y la remisión, sin ruta de archivo ni rótulo largo (§0.5 ya lo abrevia). Por ejemplo, la l. 410 queda: «- **La ventana declarada no es la configurada.** El 4b declara 262 144 tokens, pero el servidor de prueba lo cargó con 4096: con un prompt de 6843 tokens llegaron 2050, **sin error**, y el modelo contestó tres totales distintos. La ventana se fija en cada pedido (`num_ctx`, §5.1.7) y el recorte se detecta comparando los tokens leídos con los esperados (§6.5). *Estación de 4 núcleos.*» Igual en l. 407–409: lección, k/n con Wilson y «(§5.6)», «(§7.3)» o «(§5.4)».

### DIDACT-08 · «Sumar IA a una aplicación existente»: §1.3 dice «cualquiera» y §3.2 y §4.7 dicen «variante de ESC-04» — S4

- **Ubicación:** guía, §1.3 (l. 289), §3.2 (l. 480), §4.7 (l. 848).
- **Evidencia:** la decisión vinculante es que sea variante de ESC-04 (N6, nota (7): «PR-17 sigue como variante de ESC-04»), y §3.2, §4.7 y §4.8 la siguen; la tabla de §1.3 la pone en la fila «cualquiera». El mapa de entrada y el marco le dan al lector dos clasificaciones distintas de lo mismo.
- **Propuesta:** alinear §1.3 a la decisión, sin cambiar el resto: en la l. 289, columna «Estoy en», «cualquiera» → «ESC-04 (variante)».

## Revisado y bien

1. **El caso «Agregá Goya, Corrientes, CP 34, 89959 habitantes» como hilo conductor** (§2.5, §5.6, §7.6.2, §9.5.1, Anexo B.1). Un solo texto del dominio enseña que la forma no es la validez y por qué el alta también se confirma; §9.5.1 junta las tres composiciones (8/10 en `Examples/03`, 10/10 por `/v1`, 0/10 en la demo), dice que no se comparan y deja en pie la invariante. Es un ejemplo que ilumina, no que decora.
2. **§7.1 y el contraejemplo de §7.6.1.** Las definiciones de agente y workflow por «quién decide el próximo paso», con el molde qué es / qué resuelve / qué no es, y la encuesta corrida como función y como grafo con el mismo resultado («sin ningún paso con modelo no es un workflow: es código») forman criterio con un ejemplo negativo medido.
3. **§6.1–§6.2: la escalera como criterio y no como secuencia.** Tabla «conviene cuando / deja de convenir cuando», árbol que sale primero por el dato exacto y tabla de las tres cachés que no hay que confundir: la carga cognitiva está bien administrada en el punto donde más fácil era mezclar CAG, caché de prefijo y caché de respuestas.
