---
doc_id: BIT-16-MESA-C2-DA
doc_type: informe-de-especialista
title: Ciclo 2 · Abogado del diablo sobre la estructura aprobada v1 y el consenso del panel
role: Abogado del diablo (núcleo permanente, M§9)
objeto: ../../../04-Plan-De-Integracion.md (v1, ESTRUCTURA APROBADA v1)
modo: con lectura de los 12 informes del ciclo 2 y de la auditoría de homogeneidad (el mandato es atacar el consenso)
fecha: 2026-10-26
traces: [BIT-16-04 v1, BIT-16-04 v0, BIT-16-MESA-C2-00, BIT-16-MESA-C2-00b, Mesa/Ciclo-1/03…08, Sondeo-Entorno, M§3, M§5.5, M§9]
---

# Ciclo 2 · Abogado del diablo

**Mandato.** Atacar la v1 y el consenso del panel de este ciclo. Prioridades: sobrealcance (¿17 ejemplos, la demo y una guía única caben con el servidor medido y 4 h de turno?), decisiones tomadas por costumbre y ajustes AJ sin ratificar.

**No duplico.** Hay dos textos que ya cubren parte del terreno y no los repito. La auditoría de homogeneidad (`../00-Auditoria-Homogeneidad.md`) trata X-007, X-008, X-002, H-004, H-008 y el «11 a 200 s». La revisión de los NO_PROCEDE (`../00-Revision-Abogado-NO-PROCEDE.md`) trata PR-07b, AJ-03 frente a AC-3b, el `Domain` duplicado, PD-6 por la API y el motivo de §E.4 (d). Remito a esos textos. Lo que sigue es nuevo, o junta en una sola decisión cosas que el panel trató por separado.

**Niveles.** E1: lo corrí o lo leí en la fuente primaria. E2: es texto del plan o de la bitácora, con su línea. Las cuentas se hacen con cifras medidas que están en el Sondeo o en N3b, y se muestran. Lo que no está probado va como pregunta.

## 0. Diagnóstico del consenso del ciclo 2

1. **Triangulación real.** Unos diez defectos salieron en dos a cuatro informes escritos a ciegas:
   - AJ-03 frente a AC-3b;
   - el esquema R-LLM;
   - el oráculo de 07 en 5 de 12 fragmentos;
   - el presupuesto de 15;
   - la fusión de los dos hosts;
   - el csproj con `NoWarn`;
   - la aprobación sin MAF;
   - la imagen de 05;
   - AJ-01;
   - M = 5 sin poder discriminar.

   Que coincidan es buena señal: son defectos reales. La consolidación tiene que fusionarlos. Si no los fusiona, el conteo infla el ciclo.
2. **Dirección única: agregar.** Ningún informe del ciclo 2 propone sacar un ejemplo, un paso de la demo ni una sección. Todas las direcciones agregan:
   - campos al R-LLM;
   - columnas a §F.1;
   - OA;
   - filas de delta;
   - ADR;
   - pruebas;
   - variables;
   - anclas;
   - un glosario más grande;
   - DEP.

   Sólo QA-01 y DES2-01 admiten, en una frase, «subir el tope o achicar». Es la misma homogeneidad que la auditoría vio en el J3 del ciclo 1, ahora del lado de los especialistas: el costo de cada corrección se describe y no se suma.
3. **Supuestos que nadie discute.** Los informes toman como dados el tope de 4 h, los 17 ejemplos y los siete pasos de la demo, con tres puntos de entrada en un solo host. Nadie los votó: el tope es [criterio propio] (auditoría §4, punto 3), los 17 vienen de la v0 (DA2-04) y P-03 se decidió sin estimar su costo (DA2-03).

## 1. Hallazgos

### DA2-01 · S1 · E1 · confianza 0,8 — Con los tiempos medidos, lo especificado necesita unas 19 h de `<recurso-compartido>` contra un tope de 4 h. El t «nominal» de 60 s no tiene ninguna medición que lo respalde

- **Ubicación**: §E.5, «Datos medidos», estimación y tabla (l. 662–671); §F.10 AC-3b (l. 818); §G.2 R-01.
- **Afirmación**: el plan estima con t = 60 s «nominal» y 200 s «pesimista». Ninguna medición del laboratorio con herramientas da 60 s. La única llamada con una herramienta sobre `qwen3.5:4b` tardó **199,6 s**, así que 200 s es lo medido y no el caso pesimista. Las respuestas cortas sin herramientas tardan entre 11 y 24 s. Con un prefijo de 4.441 tokens, la llamada tardó 474,7 s. Si se le pone a cada llamada de §E.5 el tiempo medido de su clase, el nivel A da ~7,8 h y el B ~11 h. Las llamadas son las del plan; al B se le suman las del juez de 15, que el panel ya contó (QA-07, AH-02 H-07). Las dos cuentas usan el piso optimista de 24 s para toda llamada sin herramientas. Con esos números la línea de corte deja de ser una excepción y pasa a ser la regla. Hasta el conjunto prioritario de AJ-03, más las sondas que van antes de construir, pasa el tope.
- **Evidencia (E1, con la cuenta)**:
  - Tiempos medidos: Sondeo l. 68: «qwen3.5:4b: 199.6s finish=tool_calls … contar_localidades». Sondeo l. 201: «11–24 s por respuesta corta». N3b X3: 474,7 s. Sondeo l. 11: dispersión «de 68,8 s» a «más de 600 s».
  - Llamadas: las de §E.5 l. 666–667. A = 140, según QA. Se descuentan las 4 de DEP-03, que va «sin `<recurso-compartido>`» (l. 862).
  - Tiempo asignado a cada clase: 24 s a 01, 03, 04 y 07 (07 lleva ~250 tokens, DES2-02); 200 s a 08, 09, la estabilidad y las sondas; 475 s a 11 y a los PD (AJ-02).

  | Conjunto | Llamadas | Horas con t medido |
  |---|---|---|
  | Nivel A del plan | 136 | **≈ 7,8 h** |
  | Nivel A con cada PD-n a la M de su ejemplo (REQ2-01, ingenuo H-03) | ≈ 202 | ≈ 10,1 h |
  | Nivel B, con el juez de 15 (52) | 133 | **≈ 11,0 h** |
  | Prioridad de AJ-03 (PD 12 + 07 16 + 08 16 + 09 15) + 16 de sondas | 75 | **≈ 4,3 h** |
  | Tope (§E.5 l. 670) | — | 4 h |

- **Impacto**: la construcción cubre alrededor de un 20 % de lo que el plan especifica. La línea de corte decide sola, y en el orden de la tabla, qué se cae: lo que queda al final del nivel B (15, 16 y 17), y con eso OA-O3, OA-S2 y OA-O1. Ni la mesa ni la guía eligieron eso. Hay además un costo que el J5 reformulado tiene que pesar (auditoría §6): `<recurso-compartido>` tiene cupo 1 y es compartido (Sondeo l. 11). Ocuparlo unas 19 h deja a los demás agentes sin servidor, y eso no se revierte cuando se borra el texto.
- **Dirección**: antes de construir, una sola decisión de alcance, votada y cuantificada. Tiene que reemplazar a AJ-03, no ratificarlo con cambios. Hay dos caminos: (a) se fija el tope y se elige qué entra, con las opciones de DA2-02 a DA2-04; (b) se sube el tope con un número votado y con el costo para los demás usuarios del servidor dicho por escrito. El t de §E.5 sale de mediciones por clase de llamada, no de 60/200 s. Si DEP-13 mide menos, la cuenta se rehace, pero no se construye antes con el supuesto optimista.

### DA2-02 · S2 · E2 · confianza 0,8 — Seis de los siete pasos de la demo repiten la lección de un ejemplo, y el plan paga dos veces el modelo, el dominio y el arnés

- **Ubicación**: §F.1 (l. 685–693) frente a §E.2 (l. 629–639); §E.1, regla `_Comun` = `Domain` de la demo (l. 572); §E.5 nivel A; AC-3b.
- **Afirmación**: cada paso de la demo tiene un ejemplo que enseña la misma capacidad, sobre el mismo dominio y con la misma clase de oráculo:

  | Paso | Ejemplo | Capacidad que enseñan |
  |---|---|---|
  | PD-1 | 08 | lectura con herramientas |
  | PD-2 | 07 | RAG con cita |
  | PD-3 | 03 | `Habitantes = null` |
  | PD-4 | 04 | normalización |
  | PD-5 | 09 | alta con aprobación sin MAF |
  | PD-6 | 11 | baja en dos peticiones |
  | PD-7 | 13 | MCP |

  AC-3b les pide un registro R-LLM válido a los dos. Además, cada lado tiene su propio `Domain`, que se sincroniza con un `diff -r` que no corre tal cual (00b §3.3; ingenuo H-06), su propio arnés y sus propias pruebas de sesión. Dentro del nivel A, los ejemplos 03, 04, 07, 08, 09 y 11 suman 78 llamadas, unas 3,9 h con el t medido de DA2-01.
- **Evidencia (E2)**: las filas citadas. §F.1: PD-3 «`Habitantes = null`, la regla rechaza»; fila 03: «sin el dato, `Habitantes = null` → `HabitantesValidos(null)` = false». PD-6: «listar → id → pedido armado por el código»; fila 11: la misma cadena «listar_localidades → eliminar_localidad(id)». l. 572: «`Examples/_Comun/MovilidadUrbana.Dominio/Domain` es idéntico a `Demos/…/Domain`».
- **Impacto**: la mitad del presupuesto de A se gasta en medir dos veces la misma conducta del mismo modelo con el mismo prompt de diseño. Ninguna de las dos tasas permite comparar con la otra, porque M es chico (QA-05, AH-02 H-01).
- **Dirección**: votar una de estas opciones, cada una con su ahorro calculado:
  - (a) **Un registro, dos lugares.** El paso PD-n corre una sola entrada de humo. Su evidencia R-LLM es la del ejemplo hermano, siempre que el código del adaptador y de la herramienta sea el mismo. Para que lo sea, el `Domain` y los adaptadores tienen que salir de una sola fuente, y esto cierra también 00b §3.3. Ahorro: el plan ya presupuesta humo para los PD, así que lo que se gana es no subirlos a M (REQ2-01), unas 66 llamadas, ~2,3 h.
  - (b) **La demo es la escalera.** Los ejemplos que repiten un paso quedan en modo `--fake` con su cableado y remiten al paso de la demo. Contra el modelo corren sólo los ejemplos que la demo no tiene: 01, 02, 05, 06, 10, 12, 14, 15, 16 y 17. Ahorro: ~3,9 h. Costo didáctico que didáctica tiene que pesar: una consola por concepto se lee más fácil que una solución completa, y PR-3 trae un desvío (b) ya declarado.
  - (c) Mantener las dos cosas y declarar en §E.5 que se paga doble, con el número.

### DA2-03 · S2 · E2 · confianza 0,75 — Los tres puntos de entrada de la demo en un solo host (API, Blazor y `/mcp`) originan diez hallazgos de este ciclo, y nadie votó su costo

- **Ubicación**: §F.1 PD-7; §F.2 (filas de Web y de `Mcp/`); §F.5; §F.9; §G.4 P-03 (l. 881: «¿La demo incluye la página Blazor de chat? | Sí, una página mínima»).
- **Afirmación**: P-03 se resolvió con un «sí» sin estimar el costo. En este ciclo, la combinación de API, Blazor y MCP en un solo host produjo diez hallazgos en cuatro informes:
  - fusión de hosts: ARQ2-01, SN2-04, ingenuo H-01;
  - dos mecanismos de chat en un solo punto de entrada: ARQ2-04;
  - estado de aprobación en la API sin MAF: SN2-01, ARQ2-03;
  - SSE que reenvía la prosa del modelo: AH01-C2-H3;
  - `/mcp` alcanzable desde la red de compose: SN2-07;
  - `/mcp` sin validar `Origin`: AH01-C2-H2;
  - política de origen sin ningún pedido que la dispare: ARQ2-05.

  A eso se suman tres fuentes de sesión, el middleware de la sesión fija `demo-mcp` como delta, cuatro pruebas de aislamiento y `IAlmacenDeConversaciones`. PD-7 repite el ejemplo 13 (DA2-02), y 13 ya muestra servidor y cliente MCP en proceso.
- **Evidencia (E2)**: las ubicaciones de esos hallazgos en sus informes. §F.5 (l. 775–780): tres identidades (encabezado, cookie y sesión fija). l. 881 (P-03), sin costo ni alternativa.
- **Impacto**: la demo, que tiene que *ilustrar* capas, se vuelve la pieza más cara y más riesgosa del plan. Los controles de seguridad que la guía enseña a copiar (aprobación, MCP, origen) quedan especificados en el borde donde más fácil es equivocarse.
- **Dirección**: votar el alcance de la demo con estas opciones:
  - (a) **una sola presentación para el chat**: la API con SSE, o la página Blazor, no las dos. La que quede define dónde vive el estado de aprobación, y eso cierra ARQ2-03/SN2-01 o ARQ2-04 en el lado que se elija;
  - (b) **PD-7 fuera de la demo**: ESC-05 se cubre con el ejemplo 13, y se declara en §F.1 y en §14;
  - (c) mantener todo y sumar al plan las correcciones de los diez hallazgos, con su costo.

  **Pregunta**: ¿el contrato (BIT-16-00) o I-06 exigen que *la demo* recorra los cinco escenarios, o alcanza con que los recorra el conjunto formado por la demo y `Examples/`? La respuesta decide si (b) es posible.

### DA2-04 · S2 · E2 · confianza 0,8 — Tres decisiones de alcance se tomaron por costumbre: «no se fusionan ejemplos», los 17 ejemplos y el t de 60 s

- **Ubicación**: §G.4 P-10 (l. 888); §E.2 (17 filas); §E.5 (t nominal).
- **Afirmación**:
  1. **«No se fusionan ejemplos»** entró con el parche y no con el voto. La v0 proponía recortar si hacía falta: «fusionar `01`+`02`, `10`+`11`, y dejar `14` como opcional» (v0 l. 753). El hallazgo votado, H-021, pide «tope de horas, línea de corte antes de construir», y no dice nada de no fusionar (`03-Consolidacion.md` l. 117). La frase «no se fusionan ejemplos» aparece por primera vez en PAR-15/PAR-20 (`05-Parches.md` l. 861) y el jurado la aprobó en bloque. Con eso se cerró, sin voto, la única opción de recorte que el arquitecto había previsto.
  2. **Los 17 ejemplos** vienen de la v0, que también tenía 17 filas. Después del ciclo 1 nadie los volvió a justificar contra los OA: OA-D1 tiene dos ejemplos (01 y 02); OA-SK1, que es para un lector secundario, tiene uno propio (14); 10 no llama al modelo y su lección es un contraejemplo que entra en una sección.
  3. **t = 60 s** (DA2-01): es un supuesto [criterio propio] más bajo que todas las mediciones de llamadas con herramientas.
- **Evidencia (E2)**: v0 l. 753 (leída con `grep`); v1 l. 888; `03-Consolidacion.md` l. 117; `04-Veredictos.md` fila H-021 (ningún juez menciona la fusión); `grep -c` de filas de ejemplo en la v0 = 17.
- **Impacto**: el plan llega a la construcción con el recorte prohibido y el presupuesto optimista. Las dos cosas empujan el ajuste a «no ejecutado», que es lo único que queda.
- **Dirección**: volver a poner a voto las fusiones de la v0, con su ahorro.
  - 01+02 (OA-D1): un ejemplo que muestra chat, streaming y cambio de adaptador. Ahorra un proyecto, un README y 6 llamadas de B.
  - 10+11 no conviene: 10 es el contraejemplo sin modelo y 11 es el agente. En su lugar, 10 pasa a ser un snippet compilado dentro de §8.6.
  - 14 como opcional, fuera del arnés obligatorio.

  Cada fusión tiene que decir qué OA y qué criterio ejecutable conserva.

### DA2-05 · S2 · E2 · confianza 0,75 — «Ratificar con cambios» los AJ apila una tercera capa de texto sin voto. AJ-01…AJ-04 tienen que volver como parches

- **Ubicación**: §E.1 (AJ-01), §E.5 (AJ-02, AJ-03), AC-8 (AJ-04), preguntas guía de §1, §2, §4, §10, §12 y §13 (AJ-05); `../Ciclo-1/07-Aplicacion-Y-Verificacion.md` §2.
- **Afirmación**: AJ-01 a AJ-04 nacen de objeciones `MEJORAR_PLAN`, que por M§5.5 tenían que volver a auditoría (auditoría §2.3). El panel del ciclo 2 converge en «ratificar con cambios»: didáctica sobre AJ-05, Operación sobre AJ-01, QA sobre AJ-04. Si el jurado ratifica y en la misma votación cambia el texto, el resultado es un texto que nadie auditó ni verificó con un criterio. Es el mismo defecto que se quiere corregir. Mi posición, ajuste por ajuste:

  | AJ | Posición | Motivo |
  |---|---|---|
  | AJ-01 | **No ratificar como está**; reemitir como parche | Tal como está escrito no se puede implementar: tres informes independientes lo dicen (OP-02, DES2-03, ingenuo H-04), y QA se abstuvo. Antes de reescribirlo hay que preguntar algo más simple: ¿hace falta mandar `num_ctx` al servidor compartido, o alcanza con no mandarlo y dejar que la guarda de truncado marque la corrida? Esto choca con la pregunta C de H-SN2-05, que tiene que contestarse primero |
  | AJ-02 | Ratificar **las cifras**, no la clasificación | QA comprobó la fórmula. 07 está mal puesto entre las llamadas largas (DES2-02). Lo que AJ-02 deja en pie es justo lo que muestra DA2-01: el presupuesto no entra |
  | AJ-03 | **Rechazar** | Remienda un presupuesto que no se puede cumplir y contradice AC-3b (00b §3.2, DES2-01, QA-01). Lo reemplaza la decisión de alcance de DA2-01 |
  | AJ-04 | Ratificar, con QA-06 como parche aparte | Arregla la contradicción interna. El hueco de identificadores compuestos es otro defecto |
  | AJ-05 | **No ratificar la asignación**; votar la regla | 8 de 21 preguntas están mal atadas (H-DID2-01, REQ2-06). La raíz es el criterio «ninguna pregunta sin OA», que con 58 preguntas guía (conteo propio en §C) empuja a atar a la fuerza. Propuesta: sacar la pregunta que no ejercita ningún OA, en vez de inventarle uno (DA2-07) |
  | AJ-06 | Ratificar y completar | Le faltó el resto de §5.8 en el Anexo F (ED2-01, ARQ2-07) y «Ejemplos: 16» en §12 (REQ2-04) |
  | AJ-07, AJ-08 | Ratificar | Sin objeción en ningún informe. QA verificó AJ-08 |

- **Evidencia (E2)**: `07-…` §2, columna «Origen» (objeciones minoritarias en AJ-01…AJ-04); auditoría §2.3; los informes citados.
- **Impacto**: si el jurado ratifica en bloque «con cambios», el ciclo 2 repite el patrón que la auditoría encontró en el ciclo 1: texto que entra a la estructura aprobada sin verificación propia.
- **Dirección**: AJ-01, AJ-03 y AJ-05 salen de la votación de ratificación y vuelven como parches del ciclo 2, con un criterio de verificación cada uno. AJ-02, AJ-04, AJ-06, AJ-07 y AJ-08 se ratifican con una línea de fundamento por juez.

### DA2-06 · S3 · E2 · confianza 0,75 — Tres de las cinco preguntas de nivel C son deuda que el plan se generó solo, y se cierran decidiendo no hacer algo

- **Ubicación**: `../Ciclo-1/08-Cierre.md`, deuda declarada, «Preguntas de nivel C abiertas»; plan §E.1 l. 596, l. 619; §F.9 l. 808; §G.3 DEP-05.
- **Afirmación**:
  - **`ToolCallAccuracyEvaluator` en 15 (H-SN-07)**: el plan ya dice «Hoy ningún ejemplo lo usa» (l. 619). La pregunta no tiene objeto.
  - **`PublishContainer` (DEP-05)**: §F.9 ya tiene un camino verificado, `sdk:10.0` + `dotnet run`, y DEP-05 admite «quedarse con» él. La pregunta existe sólo porque el plan suma un `Dockerfile` multietapa que ningún OA pide. OA-O2 pide configurar por variable, no publicar una imagen.
  - **`KeepAlive` por `RawRepresentationFactory` (H-SN-02)**: el plan ya dice que «`keep_alive` … no se fija» (l. 596).
  - Las dos que quedan sí tienen objeto: los reintentos del SDK de OpenAI importan para la vía `/v1` de 02, y H-SN2-05 propone correr esa vía sólo contra el Ollama propio; las `ChatOptions` de los evaluadores importan para el juez de 15.
- **Evidencia (E2)**: las líneas citadas.
- **Impacto**: si se mantienen como «abiertas», van a pedir sondas y turno. Ya hay un precedente: el cierre transformó cada pregunta en una tarea.
- **Dirección**: cerrar las tres primeras con una decisión de alcance escrita: no se usa, no se publica imagen, no se fija. Las otras dos se atan a la fila de 02 y a la de 15, y se caen con ellas si esos ejemplos quedan fuera del corte.

### DA2-07 · S3 · E2 + C · confianza 0,6 — La guía única crece por las correcciones sin regla de compensación, y el presupuesto de 43.700 palabras nunca se votó

- **Ubicación**: §C, presupuesto de extensión (l. 361); las direcciones de ED2-05 (§0.0, anclas), ED2-07 (glosario como superconjunto), H-DID2-02 (OA nuevos, ejemplo propio para §4), REQ2-06 (OA nuevos), ARQ2-01 (ADR nuevo o filas nuevas) y AH01-C2-H2 y H4 (reglas nuevas en §11.5 y en el Anexo B).
- **Afirmación**: el plan ya tiene 58 preguntas guía con respuesta explicativa, 25 ítems de autoevaluación, 12 ADR de seis campos y 10 plantillas comentadas. ED2-06 calcula que la Parte 0 pasa su tope si se cuenta la tabla de OA, y pregunta si 4.500 palabras alcanzan para la Parte VI. Las direcciones de este ciclo suman contenido a la guía y ninguna dice qué saca. Que eso termine en una guía de más de 50.000 palabras es una **conjetura (C)**: la cuenta depende de la regla de conteo que ED2-06 pide fijar.
- **Evidencia (E2)**: conteo propio de «?»» en las líneas «Preguntas guía» de §C: 58. l. 515: 25 ítems. §13: ADR-01…ADR-12. Auditoría §4, punto 4: «se votó la necesidad de un presupuesto, no el número».
- **Impacto**: la relectura S-14 recorta a ciegas al final, o registra «motivo» por costumbre (ED2-06). Es el mismo patrón de DA2-01, ahora con palabras en lugar de turnos.
- **Dirección**: una regla de compensación para los parches del ciclo 2. Todo parche que suma texto a la guía declara cuántas palabras agrega y qué saca, o de qué tope toma. El J3 lo verifica en números. **Pregunta para didáctica**: ¿58 preguntas guía con respuesta, más 25 ítems de §15, no es repetir la misma práctica dos veces? Con un tope de 3 preguntas por sección y §15 derivada de esas preguntas, ¿se pierde algún OA?

## 2. Revisado y bien

1. **Las cifras estadísticas del plan y el diagnóstico de M = 5** son correctos. Lo verificaron tres informes de forma independiente (DES2, QA, AH-02), y la regla de «garantía del código frente a tasa informativa» (AH-02, «Revisado y bien» 3) es la estructura correcta para un M chico. No la ataco. Si no hay presupuesto, uso esa misma regla como argumento para bajar mediciones (00b §3.1).
2. **La ausencia de una variante RAG en 05 y el juez con sesgo declarado** (X-008, X-002) se sostienen con los tiempos medidos. Una variante RAG en el 7B pasa los 400 s por consulta (N3b X3), y un juez de otra familia necesita el Ollama propio, que DEP-14 todavía no da (OP-01). Que las opciones contrarias se hayan eliminado sin voto es un defecto de procedimiento, y la auditoría §2.2 ya lo pide re-votar. En el fondo, el costo le da la razón a lo aplicado.
3. **ESC-001 y el default B.** No se reabre. La imagen del Ollama propio para *embeddings* (0.40.11) se sostiene. Lo que no se sostiene es usarla para la caché de prefijo de 05, y eso ya lo plantearon OP-04, DES2-07 e IA2-07.

## 3. Solicitudes de convocatoria

- **Jurado, primer bloque**: votar la decisión de alcance de DA2-01, con las opciones de DA2-02, DA2-03 y DA2-04, **antes** que cualquier parche que agregue mediciones o pruebas. Si se vota después, los parches del ciclo 2 dimensionan sobre un alcance que puede cambiar.
- **J3 (costo-beneficio)**: rehacer §E.5 con el t medido por clase de llamada (Sondeo l. 68 y l. 201; N3b X3) y valorar el ahorro de cada opción de DA2-02 a DA2-04.
- **Didáctica**: el costo didáctico de DA2-02 (b), es decir, la demo como escalera, y la pregunta de DA2-07.
- **Presidencia**: la pregunta de DA2-03 sobre si la demo tiene que cubrir los cinco escenarios.
