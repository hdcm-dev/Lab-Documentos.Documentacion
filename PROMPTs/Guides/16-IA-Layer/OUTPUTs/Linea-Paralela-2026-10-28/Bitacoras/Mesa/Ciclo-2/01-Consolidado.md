# 01 · Consolidado del ciclo 2 (relectura integral, REED-16 §10)

Fecha: 2026-10-28. Relator del ciclo 2. Fuente: los 13 `Informe-<rol>.md` de esta carpeta (102 hallazgos). Este documento no corrige nada: arma los ítems para el voto (`02-Voto-*`).

Cómo leerlo:

- Cada ítem `C2-NN` junta hallazgos con la misma raíz. Su severidad es la más alta de los hallazgos que agrupa.
- Opciones con clave: **A** = corregir como se propone; **B** = no corregir (con el argumento más fuerte); **C, D…** = variantes reales que aparecen en los informes.
- Las contradicciones entre especialistas son ítems propios (marcados **[CONTRADICCIÓN]**) o una opción explícita dentro del ítem.
- C2-45 es el **lote S4 de forma**: un solo ítem, que se vota en bloque.
- Dependencias de orden al aplicar: C2-04 (renumerar §7) va **después** de todo ítem que cite §7.11–§7.13 por número; C2-09 condiciona C2-08 y C2-29; C2-22 (rótulos de estación) condiciona el texto nuevo de C2-31 y de C2-38; C2-28 (presupuesto) pesa sobre todo ítem que agrega texto.

## 1. Estadística

### 1.1 Por rol y severidad

| Rol | Hallazgos | S2 | S3 | S4 |
|---|---:|---:|---:|---:|
| requisitos | 6 | 3 | 3 | 0 |
| verificacion-qa | 7 | 0 | 4 | 3 |
| implementador-desarrollador | 8 | 3 | 4 | 1 |
| didactica | 8 | 3 | 4 | 1 |
| edicion-bibliografica | 15 | 6 | 8 | 1 |
| senior-dotnet | 6 | 1 | 2 | 3 |
| experto-ia | 8 | 3 | 3 | 2 |
| arquitectura | 8 | 2 | 5 | 1 |
| AH-01-seguridad-llm | 6 | 1 | 4 | 1 |
| AH-02-evaluacion-llm-rag | 8 | 4 | 3 | 1 |
| CAT-operacion-entrega-rendimiento | 8 | 2 | 6 | 0 |
| CAT-formal-matematico | 8 | 5 | 3 | 0 |
| abogado-del-diablo | 6 | 4 | 1 | 1 |
| **Total** | **102** | **37** | **50** | **15** |

No hay S1.

### 1.2 Por rol y tipo

| Rol | coherencia | evidencia | edición | compresión | técnico | reproducibilidad | seguridad |
|---|---:|---:|---:|---:|---:|---:|---:|
| requisitos | 4 | 1 | 1 | 0 | 0 | 0 | 0 |
| verificacion-qa | 3 | 3 | 0 | 0 | 0 | 1 | 0 |
| implementador | 2 | 1 | 0 | 0 | 1 | 3 | 1 |
| didactica | 4 | 0 | 3 | 1 | 0 | 0 | 0 |
| edicion-bibliografica | 1 | 0 | 6 | 8 | 0 | 0 | 0 |
| senior-dotnet | 1 | 0 | 0 | 0 | 5 | 0 | 0 |
| experto-ia | 3 | 4 | 0 | 0 | 1 | 0 | 0 |
| arquitectura | 6 | 0 | 0 | 0 | 2 | 0 | 0 |
| AH-01 | 2 | 1 | 0 | 0 | 1 | 0 | 2 |
| AH-02 | 2 | 2 | 1 | 0 | 1 | 2 | 0 |
| CAT-operación | 4 | 1 | 0 | 0 | 2 | 0 | 1 |
| CAT-formal | 4 | 3 | 0 | 0 | 0 | 1 | 0 |
| abogado-del-diablo | 2 | 2 | 0 | 1 | 0 | 0 | 1 |
| **Total** | **38** | **18** | **11** | **10** | **13** | **7** | **5** |

Agrupado en los tres ejes que pide la tarea: **edición** 11, **compresión** 10 y **coherencia** 38. Los otros 43 son de fondo: evidencia 18, técnico 13, reproducibilidad 7 y seguridad 5.

### 1.3 Deduplicación

Los 102 hallazgos quedan en **67 ítems**: 66 con raíz propia, más el lote S4 (C2-45, que junta 9 hallazgos S4 de forma: VERIFI-05, DIDACT-08, EDICIO-15, EXPERT-08, DIDACT-05 c, ARQUIT-08, AH-01-06, ADV-06 y la parte de cita de EDICIO-14). Los cruces más repetidos, contando los roles que llegaron por separado a la misma raíz:

- la doble negación de §8.10.1 (2 roles);
- las medianas de §7.13.2 (4 roles);
- los nombres de los escenarios (3 roles);
- el molde de las preguntas guía (3 roles);
- el despliegue fuera de Development (3 roles);
- la tasa usada como compuerta en Examples/01 (2 roles);
- la regla «difiere» (2 roles);
- el conteo de Misiones (2 roles);
- el host y el puerto en excepciones y logs (2 roles).

Hay **ocho contradicciones** entre especialistas elevadas como ítem propio: C2-09, C2-11, C2-18, C2-22, C2-33, C2-37, C2-41 y C2-46. Otras dos van como opciones enfrentadas dentro del ítem: C2-02 (C frente a D) y C2-10 (C frente a E.4). A eso se suma la tensión transversal de C2-28 entre el presupuesto y los textos que se agregan.

## 2. Ítems

### C2-01 · Los escenarios se nombran de varias maneras (S3, coherencia)

Origen: REQUIS-03, DIDACT-04 y EDICIO-08 (parte de nombres).
Ubicación: §4.8 l.863, §5 l.904, §6 l.1324, §6.10 l.1754–1756, §7 l.1835, §7.12 l.2571–2575, §8.2, §9 l.3211.
Evidencia: unas 15 apariciones con nombres que no son los de §3.2 («acción con aprobación», «integración con terceros», «búsqueda por significado», «extracción a estructura», «consulta de datos», «acción con herramientas», «acciones con confirmación»). «ESC-04 (acción con aprobación)» reduce el escenario a uno de sus dos mecanismos, y la demo no usa aprobación integrada.

- **A**: los cinco nombres canónicos de §3.2 en todos los lugares. Para §7 l.1835, el texto de REQUIS-03: «El escenario principal es ESC-04 (agentes y herramientas). ESC-01 (asistente sobre datos propios) aparece en el primer ejercicio y ESC-05 (exposición por MCP) en MCP.»
- **B**: no corregir. Las variantes describen el uso local de cada sección y el id ESC-xx ya desambigua.
- **C** (DIDACT-04): nombre canónico con el matiz pegado. En §7: «ESC-04 (agentes y herramientas), con las escrituras siempre aprobadas»; en §9: «ESC-04 (agentes y herramientas, como acciones que la persona confirma)».
- **D** (REQUIS-03, variante): nombre canónico y, si hace falta, el matiz como aclaración aparte: «ESC-04 (agentes y herramientas), con escrituras confirmadas».

### C2-02 · Preguntas guía sin molde único: rótulo ESC/CTX, marca de criterio y formato (S2, coherencia/edición)

Origen: REQUIS-01, DIDACT-05 (a, b, d) y EDICIO-09.
Ubicación: §4.9 (5 preguntas), §7.13 (12), §9.9 (6) sin rótulo; marca de criterio en §6.11 (0/16), §8.13 (4/13), §7.13 y §9.9.
Evidencia: barrido B3: 23 preguntas sin (ESC; CTX), cuando las otras 50 lo llevan. El criterio aparece en cinco formas («**Criterio:**» 11, «*Criterio:*» 24, «**Criterio**:» 8, «**Aplica**» 4, o sin marca). §6.11.13 cierra con una anécdota, y §4.9.5 vuelca doce parámetros de corrida (RV-10).

- **A**: rótulo con los valores de plan-de-preguntas §1, como los lista REQUIS-01; última oración «**Criterio:**» tomada del cuerpo; arreglos puntuales de §6.11.13 y §4.9.5 (DIDACT-05 b y d).
- **B**: no corregir. Las respuestas ya forman criterio y el rótulo es metadato del plan, no del lector.
- **C** (REQUIS-01, **[CONTRADICCIÓN con D]**): conservar los `####` de §4.9 y poner el rótulo como primera línea del párrafo de respuesta, para no romper las anclas del índice.
- **D** (EDICIO-09): formato único «**N.N.N ¿Pregunta?** *(ESC-xx; CTX-yy)*». Los `####` de §4.9 pasan a negrita, porque sólo el índice enlaza #49.
- Combinable con A o con D: aplicar sólo el rótulo (REQUIS-01) y dejar la marca de criterio para C2-30.

### C2-03 · Los criterios de calidad no dicen su ESC ni su CTX (S2, coherencia)

Origen: REQUIS-02.
Ubicación: §4.10, §5.10, §6.12, §7.11 y §8.14.
Evidencia: barrido B5: 0 menciones de ESC o de CTX. RV-04 lo exige y §3.10 lo enuncia como regla. `num_ctx`, `prompt_eval_count` y `/v1` son de CTX-LOCAL con Ollama y se leen como universales.

- **A**: una línea «Alcance:» bajo cada encabezado, con los textos de REQUIS-02.
- **B**: no corregir. Cada criterio remite a su sección, que ya tiene su escenario.

### C2-04 · El orden del molde P-07 no se cumple en §4, §6 y §7 (S2, edición)

Origen: EDICIO-07.
Ubicación: §4.8, §6.10, §7.11–§7.13; el índice; el ancla de l.1835; §0.3; Anexo B.1 y B.3.
Evidencia: P-07 fija definición → aplicación → ejemplos → preguntas → criterios. §5.2 y §8.2 lo cumplen. §4.8 y §6.10 van después de los ejemplos, y en §7 los criterios van antes que la aplicación y que las preguntas.

- **A**: en §7, renumerar 7.12 → 7.11, 7.13 → 7.12 y 7.11 → 7.13, con índice, ancla, §0.3, B.1 y B.3. En §4 y §6, mover el bloque a la posición 2 con renumeración por script.
- **B**: no corregir. El riesgo de romper anclas es alto (75 referencias en §4 y §6) para una ganancia de orden.
- **C** (EDICIO-07, alternativa): renumerar sólo §7 y cambiar el enunciado de §0.4 a «definiciones, ejemplos que compilan, aplicación por escenario, preguntas guía y criterios». En ese caso §5.2 y §8.2 se mueven en consecuencia.
- Nota de aplicación: si gana A o C, va **al final**. Los parches de C2-02, C2-03, C2-10, C2-30, C2-40 y C2-43 citan §7.11–§7.13 con la numeración de hoy.

### C2-05 · AI-Layer.png: la mayoría de las cajas quedan sin ubicar (S2, evidencia)

Origen: REQUIS-04.
Ubicación: §4.2.2 l.604–612.
Evidencia: §4.2.1 describe 24 rótulos y §4.2.2 juzga 3. El barrido B8 da 0 menciones para 11 cajas. REED-16 §7.1 pide decir qué se sostiene y qué es simplificación.

- **A**: tabla «Caja | Dónde la trata la guía | Qué se sostiene o qué queda afuera», con las filas de REQUIS-04.
- **B**: no corregir. Una tabla de 15 filas agrega texto en una guía que ya pasó el presupuesto (C2-28).
- **C**: tabla reducida sólo a las cajas que la guía trata (Third-Party, Auth, Cache, Docker, Kubernetes/Cloud), y una oración de cierre que manda el resto «fuera del alcance (§0.2)».

### C2-06 · §0 y el Anexo F no tienen las preguntas guía del plan (S3, coherencia)

Origen: REQUIS-05.
Ubicación: §0 y Anexo F.
Evidencia: el plan §2 prevé PG-1 y PG-6 en §0 y PG-7 en el Anexo F. Las tres dan 0 coincidencias.

- **A**: §0.6 con 0.6.1 y 0.6.2, y la pregunta del Anexo F, con los textos de REQUIS-05 y sólo con REF que ya están en el Anexo D.
- **B**: no corregir. El contenido ya está en prosa (§1.5.1, §3.4, §3.6), y §0 es orientación, no materia.
- **C**: sólo §0.6, y el Anexo F sin pregunta. Así se evita la cita a Nygard, que obligaría a sumar una REF nueva.

### C2-07 · La guía no muestra la demo funcionando (S3, edición)

Origen: REQUIS-06.
Ubicación: final de §9.5.
Evidencia: hay 5 capturas sólo en el README de la demo y 0 enlaces desde la guía.

- **A**: párrafo «**Cómo se ve.**» con enlace a la sección del README.
- **B**: no corregir. El README es parte del entregable, y §9 ya remite a la demo.
- **C** (REQUIS-06, opcional): A más la imagen incrustada de D6, la baja propuesta sin confirmar.

### C2-08 · Truncado silencioso: atribución del modelo, la corrida de 16384 y «se perdió el principio» (S2, evidencia)

Origen: EXPERT-03, VERIFI-01 y EXPERT-04.
Ubicación: §2.5 l.410, §5.4 l.1062, §6.5 (fila 1, l.1511), §6.12 l.1819 y E.5.
Evidencia: «14, 30 y 34» son salidas de 3 tokens de qwen2.5:0.5b, no del 4b. Con 16384 hubo una sola corrida de referencia, no 3 de 3. Qué tramo se conservó no se midió.

- **A**: reescribir la viñeta de §2.5 como propone EXPERT-03; corregir «3 de 3» en §5.4, §6.5, §2.5 y E.5 (VERIFI-01); y cambiar «se perdió el principio» por «quedó menos de la mitad; qué tramo, no se midió» en §6.5 y §6.12 (EXPERT-04).
- **B**: no corregir. La lección (la ventana se recorta sin error) es correcta con cualquier modelo.
- **C** (EXPERT-03, variante): conservar «14/30/34» rotulado como «salidas de 3 tokens del modelo de humo; con la ventana entera no se midió si acertaba».
- Se aplica junto con C2-09: la compresión no puede borrar la atribución.

### C2-09 · [CONTRADICCIÓN] Comprimir §2.5 y §5.4 o conservar modelo, estación y N (S2, compresión)

Origen: EDICIO-02 y DIDACT-07, frente a ADV-03 (y EXPERT-03).
Ubicación: §2.5 l.403–412, §5.4 ≈l.1062, §8.8 y §6.11.16.
Evidencia: «2050» aparece 16 veces. EDICIO-02 ahorra unas 370 palabras, pero en §2.5 y §5.4 quita la única oración que nombra qwen2.5:0.5b, y funde 6843→2050 (0,5b, estación de 4 núcleos) con 5114→2050 (4b, estación con más núcleos), una comparación que §0.5 prohíbe. La viñeta de ejemplo de DIDACT-07 («el modelo contestó tres totales distintos») también se las atribuye al 4b.

- **A** (ADV-03): de EDICIO-02 aplicar sólo la viñeta de §8.8. §2.5 se reescribe según C2-08. Para §5.4, el texto mínimo de ADV-03, con los dos modelos y las dos estaciones. Queda como regla general de aplicación: no se quita una oración que nombre modelo, estación, estimando o prueba si es la única de su sección que lo hace.
- **B**: no comprimir nada; dejar las repeticiones como están.
- **C** (EDICIO-02 completo): §5.4, §8.8 y §2.5 como los propone EDICIO-02.
- **D** (DIDACT-07): en todas las viñetas de §2.5, lección + cifra + remisión, sin ruta ni rótulo largo, pero con el modelo nombrado según EXPERT-03.

### C2-10 · §7.13.2 presenta un rango como «mediana por serie» (S3, evidencia)

Origen: VERIFI-03, EXPERT-07, CAT-OP-02 y CAT-FO-08 (parte).
Ubicación: §7.13.2 l.2583.
Evidencia: las medianas de E.4 son 4,68 y 4,75 s. 4,65 es un mínimo y 4,96 no figura en E.4.

- **A** (EXPERT-07, CAT-OP-02 y CAT-FO-08): «tardó 4,68 y 4,75 s de mediana en dos series de 10, sin contar la carga (estación de 4 núcleos; E.4)».
- **B**: no corregir; la diferencia es de centésimas.
- **C** (VERIFI-03): las medianas más el rango «de 4,65 a 4,96 s sin la primera». Es una variante en tensión con E.4, que se declara fuente única de las latencias: obligaría a sumar ese rango a E.4.

### C2-11 · [CONTRADICCIÓN] Presupuesto R-LLM-5 con 27 s por llamada, que no está en E.4 (S2, coherencia)

Origen: CAT-OP-01 y CAT-FO-08 (parte).
Ubicación: Anexo E.5, regla 5 (l.4051).
Evidencia: 27 s sale de una sonda del ciclo 1 que mezcla operaciones. 45 min / 27 s = 100 llamadas, no «unas 90». K = 10 × m = 5 son 50 llamadas y 4 × 10 son 40.

- **A** (CAT-OP-01): presupuesto con la mediana de la operación que se va a medir (E.4), de 4,68 a 26,37 s, más la carga en frío; con la más lenta, unas 100 llamadas.
- **B**: no corregir; es una regla orientativa.
- **C** (CAT-FO-08): conservar «hasta unos 27 s» rotulado como la propuesta de escritura más lenta de E.4, y corregir la aritmética: 100 = 50 + 40, sin margen. **Choca con A**: E.4 da 26,37, no 27.

### C2-12 · La lectura del prompt «13–22 tok/s» no coincide con E.4 (S3, coherencia)

Origen: VERIFI-02.
Ubicación: §2.5 l.412, §6.4.3 l.1467, E.3 y E.4.
Evidencia: E.4 trae 27,2 y 11,8 tok/s, fuera del rango. El rango sale de cuatro lecturas elegidas, y O3 (13,2) no está en E.4.

- **A**: los textos de VERIFI-02 (mediana de unos 19 tok/s en cuatro lecturas largas, y los extremos de E.4) y agregar la fila O3 a E.4.
- **B**: no corregir. El rango describe lecturas largas sin caché, y está rotulado.
- Nota: ADV-01 (C2-38) deriva de esta cifra «unos 50 s por cada 1000 tokens». Si se toca, hay que recalcularlo.

### C2-13 · «Tardó 167 s», con 168,20 s de pared (S4 → lote, C2-45)

Lo absorbe el lote.

### C2-14 · Anexo D: tres autoenlaces rotos, versiones arXiv que faltan y formas mezcladas (S2, edición/evidencia)

Origen: EDICIO-11 y VERIFI-06.
Ubicación: Anexo D.1 (REF-030, 032, 033, 035, 052–065, 067, 068, 090, 121, 122 y 127) y las citas del cuerpo.
Evidencia: los autoenlaces con espacio no se renderizan. API de arXiv consultada el 2026-10-28: versiones v1 y vigente de seis REF. La columna «Consulta» tiene cinco formas, y las citas, tres.

- **A**: todo EDICIO-11: URL entre `<>`, versiones, columna con la fecha ISO sola, editor en REF-052–065 y citas en la forma `[REF-a][REF-b]`.
- **B**: no corregir la forma de las citas ni la columna; sólo las URL rotas.
- **C** (VERIFI-06, mínimo): sólo las versiones de REF-067, 068 y 090, más las URL rotas.

### C2-15 · E.5 remite la cifra de Examples/05 a §6.9, que no la tiene; la diferencia con instrucción tiene signo opuesto a la de 04 (S4/S4, coherencia/evidencia)

Origen: VERIFI-07 y AH-02-08.
Ubicación: E.5, fila «05 · RecuperacionConModeloTests»; §6.8, lección 1; §6.9.
Evidencia: la cifra 12/12 sólo está en E.5. En Examples/05, hit@1 da 11/12 con instrucción y 12/12 sin ella. En 04 el único par discordante cae del otro lado.

- **A**: oración en §6.9 con la recuperación medida sola (VERIFI-07), oración en §6.8 sobre el signo opuesto («un solo par… es ruido») y E.5 con hit@1 (AH-02-08).
- **B**: no corregir. Las dos son «no separado», y la guía ya no afirma efecto.
- **C** (VERIFI-07, alternativa): en E.5, «En la guía» → «— (README de Examples/05)», sin texto nuevo.

### C2-16 · El filtro de §8.4.2 corre 0 pruebas en la demo, sin error (S3, reproducibilidad)

Origen: VERIFI-04.
Ubicación: §8.4.2 l.2797; las pruebas de Cableado/ de 03, 05, 13 y la demo.
Evidencia: corrida del 2026-10-28: «No test matches» y código de salida 0.

- **A** (texto): enumerar el filtro de cada carpeta y advertir que un filtro que no aplica no falla.
- **B**: no corregir. Cada README da su filtro correcto.
- **C** (VERIFI-04, preferida por el rol): en código, `[Category("Cableado")]` en 03, 05, 13 y la demo, y unificar los README. La frase actual queda verdadera. Exige recompilar y correr.

### C2-17 · Los `docker run` dejan bin/, obj/ y las salidas con dueño root (S2, reproducibilidad)

Origen: IMPLEM-01.
Ubicación: la cabecera de la guía, §8.12.2, §9.8 y todos los README.
Evidencia: con `-u "$(id -u):$(id -g)" -e HOME=/tmp` dio 23/23 y ningún archivo de root.

- **A**: agregar `-u` y `HOME` en cada `docker run` del SDK, más la nota de limpieza en la cabecera.
- **B**: no corregir. Es un detalle del anfitrión del lector, y Docker Desktop no lo muestra.
- **C**: sólo la nota en la cabecera de la guía, sin tocar los comandos de los README.

### C2-18 · [CONTRADICCIÓN parcial] El host y el puerto del servidor se filtran por excepciones y logs (S2, seguridad)

Origen: IMPLEM-03 y CAT-OP-06.
Ubicación: los ConModelo de 06, 07, 08 y 10; los appsettings de la demo; §5.3(b), §8.5.4, §9.8, A.2 y B.3.
Evidencia: el mensaje de NUnit y el registro R-LLM copian «Connection timed out (host:puerto)». Con `HttpClient` en `Warning` sigue saliendo una línea (`gen_ai.client.operation.exception`). Las dos medidas coinciden.

- **A**: las dos. Redactar `Authority` en el helper de violación (IMPLEM-03); `System.Net.Http.HttpClient: Warning` en la demo; y corregir §8.5.4, §9.8 y B.3, porque la guía hoy afirma que con `Warning` no se filtra (CAT-OP-06).
- **B**: no corregir. El endpoint es una variable del lector, no un secreto.
- **C**: sólo texto (advertir en §8.5.4 y §9.8), sin tocar código.
- Tensión: la frase de §8.5.4 que propone IMPLEM-03 («los registros R-LLM los redactan») supone el cambio de código; con C, es falsa.

### C2-19 · Una caída del servidor se cuenta como violación de invariante (S3, reproducibilidad)

Origen: IMPLEM-04.
Ubicación: los README de 06, 07, 08 y 10; §8.1.3.

- **A**: la regla «excepción de conexión o timeout = no medido, se repite» en los README y en §8.1.3.
- **B**: no corregir. Una suite roja ante una caída es conservadora, y el registro ya muestra la excepción.
- **C**: además de A, clasificarlo en código (marcar esas semillas como «no medido» en el registro).

### C2-20 · Seis nombres de variable para lo mismo; E.5 da una regla que no se cumple (S3, reproducibilidad)

Origen: IMPLEM-05.

- **A**: unificar en el código `RLLM_SALIDA`, `ESTACION` y `salidas-con-modelo/`.
- **B**: no corregir; cada README dice su variable.
- **C** (IMPLEM-05, alternativa): sólo texto. E.5 l.4079 lista las variables de cada ejemplo.

### C2-21 · 10-Workflow: falta el comando secuencial y la consola imprime la confirmación bajo el pedido equivocado (S3, técnico)

Origen: IMPLEM-06.

- **A**: mover `Console.WriteLine($"> {texto}")` antes de `EjecutarAsync` y completar los comandos del README.
- **B**: no corregir; la traza es correcta y sólo se ve desordenada.
- **C**: sólo el README.

### C2-22 · [CONTRADICCIÓN] Rótulos de estación: abreviar, unidades y el rótulo «15 vCPU» (S3, compresión/coherencia)

Origen: EDICIO-05, CAT-OP-03 e IMPLEM-08, frente al texto nuevo de AH-02-02.
Ubicación: 15 rótulos completos en la guía; «5 GB» en la guía (10 veces), en 6 README y en un appsettings; «15 vCPU» en el README de 10.
Evidencia: el límite real es 5 GiB (5368709120). §0.5 ya declara las dos formas abreviadas. AH-02-02 (C2-31) propone **agregar** un rótulo completo nuevo en §8.9.2.

- **A**: abreviar en la guía a «estación de 4 núcleos» y «estación con más núcleos» (EDICIO-05); «5 GB» → «5 GiB» donde quede el rótulo completo, incluido el README de la demo partido en dos líneas (CAT-OP-03); el README de 10 con el rótulo de RV-01 (IMPLEM-08). Todo texto nuevo de otros ítems usa la forma abreviada.
- **B**: no corregir. El rótulo completo en cada cifra evita que el lector compare estaciones.
- **C**: sólo las unidades y «vCPU», sin abreviar.

### C2-23 · README 01: «Resultado esperado» dice 17 y todo lo demás dice 18 (S3, coherencia)

Origen: IMPLEM-07.

- **A**: «Cableado: 18 de 18 en verde».
- **B**: no corregir; no hay argumento fuerte, porque el conteo estático da 18.

### C2-24 · §3.1 define «Situación» y el resto de la guía dice «Contexto» (S2, coherencia)

Origen: DIDACT-01.

- **A**: redefinir como «**Contexto:** … (CTX-*)», con la aclaración de que no es el texto que recibe el modelo.
- **B**: no corregir; el Anexo C ya define «Contexto».
- **C**: cambiar sólo la palabra, sin la aclaración sobre la ventana de contexto.

### C2-25 · El árbol de §3.2 manda a ESC-04 el ejemplo canónico de ESC-01 (S2, coherencia)

Origen: DIDACT-02.
Evidencia: «¿Cuántas localidades hay en Chaco?» (D4, ESC-01) termina en ESC-04 si se sigue el árbol.

- **A**: Q2 «¿Qué devuelve el turno?», con tres ramas, más la oración de después del diagrama (DIDACT-02).
- **B**: no corregir. El árbol pregunta quién decide y D4 es un caso borde.
- **C**: dejar el árbol y agregar sólo la oración aclaratoria.

### C2-26 · Semilla, Wilson y par discordante se usan antes de definirse, o nunca se definen (S2, edición)

Origen: DIDACT-03, relacionado con CAT-FO-01 (definición de discordante, C2-35) y CAT-FO-07 (C2-36).

- **A**: el párrafo «Tres palabras de estadística» en §0.5, la fila «Semilla» en el Anexo C, y Wilson y comparación pareada como filas propias.
- **B**: no corregir. §8.1.4 las define, y §0.5 remite.
- **C**: sólo las filas del Anexo C, sin texto nuevo en §0.5, por el presupuesto (C2-28).
- Coordinación: si gana C2-35 A, la definición de par discordante de §0.5 usa la de CAT-FO-01 (por semillas acertadas), no «una acierta y la otra no».

### C2-27 · La ruta de ACT-DEV salta las definiciones de §7 (S3, edición)

Origen: DIDACT-06.

- **A**: «§4 → §5 → §7.1–§7.3 → §6 → resto de §7 → §8.4 → §9».
- **B**: no corregir; §7.3 se puede leer solo.

### C2-28 · El presupuesto de palabras se mide mal y el exceso real es estructural (S2, compresión)

Origen: EDICIO-01.
Evidencia: la compuerta cuenta 6236 palabras de código y unas 900 del índice. En prosa: §7 +43 %, §8 +48 % y anexos +94 %.

- **A**: medir con `palabras.awk`; aplicar la compresión de EDICIO-02 y EDICIO-13; y un dictamen de la presidencia con valores orientativos (§7 ≈ 8000, §8 ≈ 7500, anexos ≈ 11000).
- **B**: no corregir; P-07 dice que recortar redundancia no autoriza recortar evidencia.
- **C**: sólo cambiar el método de medida y dejar los topes como están.
- Tensión transversal: C2-03, C2-05, C2-06, C2-26, C2-31, C2-37, C2-38, C2-41 y otros **agregan** texto.

### C2-29 · «La política no es el código» tiene dos tablas y tres párrafos (S2, compresión)

Origen: EDICIO-03.

- **A**: §6.3 en un párrafo con remisión a la tabla canónica de §9.3.3, y §4.9.5 y §5.4 en una oración cada uno (ahorro de unas 210 palabras).
- **B**: no corregir. La repetición es deliberada: es la invariante central.
- Respeta la regla de C2-09 A: el commit `59399ba` y la ruta de la prueba se conservan.

### C2-30 · Preguntas guía que repiten el cuerpo (S2, compresión)

Origen: EDICIO-04 (con la marca de criterio de C2-02).
Ubicación: §6.11.10, §6.11.12, §6.11.14, §8.13.11–13 y §9.9.5.

- **A**: respuesta = criterio + remisión, con los textos de EDICIO-04 (ahorro de unas 420 palabras).
- **B**: no corregir; el lector que entra por las preguntas necesita las cifras ahí.
- **C**: sólo las réplicas exactas (§8.13.11 = §8.12.3 y §8.13.12 = §8.5.1).

### C2-31 · §8.9: el juez y lo que vio el laboratorio (S2, evidencia)

Origen: AH-02-02 y CAT-OP-08.
Ubicación: §8.9.2 l.3055–3076, §8.13.13, §6.8 l.1722 y E.4 (filas del juez).
Evidencia: con una respuesta incorrecta, Relevance y Coherence dieron 4; con una correcta, Relevance dio 2. Completeness y Equivalence le dieron 1 a la incorrecta. El costo informado sale de una sonda aparte, no de la prueba que «no se corrió».

- **A**: el ítem «Lo que vio el laboratorio», el conjunto mínimo con referencia, «Costo medido, con una sonda aparte…» (CAT-OP-08), «(sonda aparte)» en E.4, y §6.8 sobre RetrievalEvaluator. Antes, verificar los nombres en Quality 10.11.0.
- **B**: no corregir; N = 1 por celda no sostiene una recomendación de evaluadores.
- **C** (CAT-OP-08 solo): sólo rotular el costo como sonda aparte.
- Con C2-22 A, el rótulo de estación del texto nuevo va abreviado.

### C2-32 · La prueba del juez de Examples/09 pasa en verde sin medir nada (S2, reproducibilidad)

Origen: AH-02-01.
Evidencia: corrida del 2026-10-28: Passed, con Relevance Inconclusive, dos métricas cortadas por timeout y una aserción `Metrics.Count == 4`.

- **A**: juez con `Reasoning = None` y `num_ctx`; respuesta evaluada por el camino del esquema; invariante «toda métrica con Interpretation; un Inconclusive falla»; y la oración en §8.9.2.
- **B**: no corregir el código; declararlo en §8.9.2 como prueba de humo que no mide.
- **C**: sólo cambiar la aserción, para que no quede verde en falso, y dejar el juez como está.

### C2-33 · [CONTRADICCIÓN] Tasa usada como compuerta (k ≥ m−2) y existencia como aserción en Examples/01 (S2, coherencia)

Origen: AH-02-03 y CAT-FO-04.
Ubicación: ChatConModeloTests.cs l.18, 46 y 68; MaxOutputTokensConModeloTests.cs l.69; README de 01 l.150; A.4 l.3629; §8.1.3, §9.5 y E.5.
Evidencia: `Assert.That(k, Is.GreaterThanOrEqualTo(m - 2))` hace fallar la prueba por azar, contra «una tasa se informa y no hace fallar».

- **A** (AH-02-03): borrar la l.68 y reescribir los comentarios; en §8.1.3, sumar un cuarto tipo, «**Existencia:** falla si no se observó ni una vez en m», y renombrar a «los cuatro tipos» en el título, en CTRL-11 y en D-08. Las aserciones de existencia (07 y la de MaxOutputTokens) quedan.
- **B**: no corregir; k ≥ m−2 es un umbral de humo laxo.
- **C** (CAT-FO-04): borrar la l.68 y además quitar el Assert de existencia de MaxOutputTokens (sólo `nativaAcotada == m`, y `v1Excedida` informada). **Choca con A**: A legitima la existencia como aserción; C la saca.
- **D** (CAT-FO-04, alternativa): declarar en §8.1.3 un cuarto tipo, «umbral de humo, elegido y no medido», sacar la frase absoluta de §9.5 y E.5, y no tocar el código.

### C2-34 · La regla «difiere» está escrita de tres maneras (S2, coherencia)

Origen: AH-02-05 y CAT-FO-02.
Ubicación: §0.5 l.225, §5 l.906, §6.8 l.1718, §6.9 l.1726, §8.4.4 l.2823 y 2825, §8.14 l.3202, §9.7 l.3443.
Evidencia: el código exige que todos estén en el mismo sentido. Con 7 contra 1, §0.5 da «difiere» y el código «no separado». Además, «con N = 10 no se puede» choca con el «difiere» de §9.7.

- **A** (CAT-FO-02, completa): «6 o más, todos en el mismo sentido» en los cuatro lugares; reescribir §5 l.906 y §8.4.4 l.2825; y la nota de §9.7 sobre que entre modelos la semilla no empareja (Fisher).
- **B**: no corregir; §8.4.4 y E.5 son la versión canónica.
- **C** (AH-02-05): sólo los cuatro lugares, sin tocar §5, §8.4.4 l.2825 ni §9.7.

### C2-35 · §6.9: la comparación pareada usa otra unidad que la fila (S2, coherencia)

Origen: CAT-FO-01.
Evidencia: con 10/12 frente a 10/12 en «pasa 3/3», los discordantes deberían ser iguales, y la tabla dice «2 y 1». El código empareja por aciertos en las 3 semillas.

- **A**: encabezado de la columna, nota bajo la tabla con 10/16 y 11/16, y definición de discordante en §8.1.4.
- **B**: no corregir; el código es el canónico y la tabla lo refleja.

### C2-36 · Estimando de «la tarea» (m/m) y dos cotas para 0/10 (S2, evidencia/coherencia)

Origen: CAT-FO-03 y CAT-FO-07.
Evidencia: el valor depende de m (con 0,9 por semilla: 0,73 con m = 3 y 0,59 con m = 5). §6.9 llama «la tarea» a una media sin intervalo. 0,26 es Clopper-Pearson unilateral y 0,28 es Wilson bilateral, y se presentan igual.

- **A**: aclaración «pasa en las m semillas; se informa con m» en §0.5, §3.7 y el glosario; fila «Todas» de §6.9 rotulada como otro estimando; y la oración de las dos cotas en §8.4.4 y E.5.
- **B**: no corregir; §8.4.4 y E.5 ya dicen m/m.
- **C**: sólo CAT-FO-07 (las cotas), que es una oración.

### C2-37 · [CONTRADICCIÓN] Diagramas mermaid: el de §5.3 tiene la flecha invertida; ¿se borra o se corrige? (S3, coherencia/compresión)

Origen: ARQUIT-07 y EDICIO-12.
Ubicación: §5.3 l.944–955, §5.9.5 l.1271, §8.4 l.2733, §6.2 y §7.2.
Evidencia: §5.3 dibuja Application → Infrastructure, la dependencia invertida. EDICIO-12 lo ve como redundante con §4.5.

- **A** (EDICIO-12): borrar el mermaid de §5.3 y dejar la oración con remisión a §4.5. También el párrafo de §5.9.5 y el mermaid (o la oración) de §8.4. El error desaparece con el diagrama.
- **B**: no tocar ningún diagrama. **Se descarta como opción completa**: deja un error de dirección.
- **C** (ARQUIT-07): conservar §5.3 con la flecha corregida (U → P; A -.->|implementa| P). EDICIO-12 se aplica sólo a §5.9.5 y §8.4.
- **D**: C en §5.3, y no tocar §5.9.5 ni §8.4.

### C2-38 · «Con 12 enunciados alcanza el contexto fijo»: decidido con un «no separado» y un costo local no medido (S2, evidencia)

Origen: ADV-01. Coordinar con el lote (EXPERT-08 y DIDACT-05 c, §6.11.15).
Ubicación: §6.9 l.1738, §6.11.15 l.1806, §9.5.2 l.3362 y §6.2 (fila 0).

- **A**: los cuatro textos de ADV-01.
- **B**: no corregir; el contexto fijo es la elección didáctica y la guía ya dice «no separado».
- **C**: corregir sólo la frase falsa de §6.11.15 («cuesta poco») y la de §6.9, sin la cifra de 50 s/1000 tokens, que depende de C2-12.

### C2-39 · La confirmación es invariante en el clic, no en la detección; el formulario no marca el dato inventado (S2, seguridad)

Origen: ADV-02.
Ubicación: §9.5.1, §9.9.4, §1.2 y ChatDelAsistente.razor l.36–58.

- **A** (preferida por el rol): en código, la marca «no figura en tu pedido» en PropuestasDeLocalidad, con una prueba de Cableado/, y los textos de §9.5.1 y §9.9.4; más la oración sobre el clasificador (D2).
- **B**: no corregir; la invariante de 0 escrituras sin clic se cumple, y detectar es responsabilidad de la persona.
- **C**: sólo texto (§9.5.1 y §9.9.4), con la marca declarada como deuda en una fila de §8.3.2.

### C2-40 · El árbol manda a MAF la «sesión de varios turnos»; «recomendado para proyectos nuevos» sale de un blog anterior al GA (S2, coherencia)

Origen: ADV-04, relacionado con EXPERT-02 (C2-43).
Ubicación: §1.2 nodo D5, §7.13.1, §5.8 (fila MAF) y REF-061.

- **A**: los textos de ADV-04 (D5 reformulado, la lectura del árbol, §7.13.1 y §5.8).
- **B**: no corregir; AgentSession es la pieza estándar para varios turnos, y la demo es un caso mínimo.
- **C**: sólo §5.8 (acotar REF-061 a «MAF frente a SK»), sin tocar el árbol.

### C2-41 · [CONTRADICCIÓN parcial] Despliegue: sólo `dotnet run` en Development, con EnableSensitiveData y puertos en todas las interfaces (S2, técnico/seguridad)

Origen: SENIOR-03, CAT-OP-04 y AH-01-03.
Ubicación: §8.12.2 l.3110–3128, §9.8 l.3460, §8.3.2, el README de la demo l.105 y 114, el README de 09 l.154 y el appsettings.json de la demo.
Evidencia: medido (CAT-OP-04): en Production sin la variable da `OptionsValidationException`, y con `-e AI__TimeoutSegundos=300` arranca. Development enciende EnableSensitiveData. `-p 5260:8080` publica en todas las interfaces, y AllowedHosts es `"*"`.

- **A**: las tres. La viñeta medida de CAT-OP-04 (timeout por variable; no es un artefacto); `-p 127.0.0.1:…` en los tres comandos y la oración sobre Development (AH-01-03); «Lo que este comando no es» y la fila nueva de §8.3.2 (SENIOR-03).
- **B**: no corregir; §8.12 se declara laboratorio y CTX-PROD queda fuera de foco.
- **C** (SENIOR-03): «un `appsettings.Production.json` (o la variable)». **Choca con CAT-OP-04**, que sólo midió la variable y dice que ningún appsettings.Production lo trae. Si gana A, se usa la redacción de CAT-OP-04.
- **D** (AH-01-03, opcional): además, AllowedHosts `"localhost;127.0.0.1"` en la demo, que es un cambio de código.

### C2-42 · La guía dice que Ollama escucha en loopback, y la imagen fijada escucha en todas las interfaces (S2, técnico)

Origen: AH-01-01.
Ubicación: §8.12.1 l.3108, E.2 l.3991 y el README de la demo l.119.
Evidencia: con `docker inspect` y una sonda de bind, el servidor dice «Listening on [::]:11434».

- **A**: los textos de AH-01-01 (red propia; si se publica, `-p 127.0.0.1:11434:11434`).
- **B**: no corregir. **Argumento débil**: la frase actual es falsa para la imagen de la receta.

### C2-43 · Group chat de MAF 1.26.0: el paso lo elige el GroupChatManager, y el del paquete rota por código (S2, técnico)

Origen: EXPERT-02.
Ubicación: §7.1.3, §7.7, §7.13.8, el Anexo C («Workflow de MAF») y el README de 10.

- **A**: los textos de EXPERT-02.
- **B**: no corregir; el group chat no se midió y la guía no lo recomienda.

### C2-44 · Doble negación en §8.10.1: invierte el resultado de la inyección (S2, coherencia/edición)

Origen: EXPERT-01 y AH-02-04, que coinciden.

- **A**: «propuso una baja en 0/10 … pidió una herramienta inexistente en 0/10 … le **repitió el texto inyectado** en 10/10».
- **B**: no hay argumento; la frase dice lo contrario de lo medido.

### C2-46 · Misiones: «0/10» no ve «cero», y la cuenta manual no coincide con los crudos (S2, evidencia)

Origen: EXPERT-06 y CAT-FO-05. **[CONTRADICCIÓN en la cifra de `/v1`]**.
Ubicación: §7.3.4 (tabla, l.2017–2018, y l.2022), B.1 y el README de 06 l.196–198.
Evidencia: por `/api/chat` dan 4/10 los dos roles. Por `/v1`, EXPERT-06 cuenta s = 3, 4, 5 y 10, y s = 8 si se cuenta «no se cargaron localidades»; CAT-FO-05 cuenta 5/10 (s = 3, 4, 5, 8 y 10).

- **A** (CAT-FO-05): medida renombrada a «conteo en cifras (criterio previo `\b\d+\s+localidad`)», y «4 de 10 por `/api/chat` y 5 de 10 por `/v1` (existencia, criterio posterior)».
- **B**: no corregir; la guía ya advierte la lectura manual.
- **C** (EXPERT-06): la misma tabla, con «4 de 10 por cada vía (5 por `/v1` si se cuenta «no se cargaron localidades»)», que deja visible la ambigüedad de s = 8.

### C2-47 · El extractor de bajas concatena Localidad.Nombre en el mensaje de sistema (S3, seguridad)

Origen: AH-01-02.

- **A**: lista como contenido externo en el mensaje del usuario, con `ContenidoExterno.Envolver`, y una prueba de Cableado/ con `"\n- id 99:"`.
- **B**: no corregir; la invariante de 0 bajas hasta el clic se sostiene.
- **C**: sólo texto: declararlo como deuda en la fila CTRL-14 de §8.3.1.

### C2-48 · OWASP dice «do not fully mitigate», y la guía cita «no mitiga» (S3, evidencia)

Origen: AH-01-04.

- **A**: «no la mitiga por completo («do not fully mitigate»)» en §6.1, §8.1.6 y REF-046.
- **B**: no hay argumento; es una cita entre comillas que no coincide con la fuente.

### C2-49 · §8.2 le atribuye a Examples/08 un límite de concurrencia que no tiene (S3, coherencia)

Origen: AH-01-05.

- **A**: el texto de AH-01-05, y «límite de pedidos por identidad» en la columna CTX-PROD.
- **B**: no hay argumento; el grep da 0.

### C2-50 · Blazor Interactive Server: Scoped es el circuito, no el pedido (S2, técnico)

Origen: SENIOR-01.

- **A**: el párrafo en §8.7, REF-138 nueva (Microsoft Learn, Blazor with EF Core, ms.date 2025-11-11, consultada el 2026-10-28) y la nota en §4.9.4.
- **B**: no corregir; la demo ya lo resuelve con AddDbContextFactory, y los comentarios lo dicen.
- **C**: el párrafo sin la REF nueva, remitiendo a los comentarios del código.

### C2-51 · Singleton que retiene un HttpClient de IHttpClientFactory (S3, técnico)

Origen: SENIOR-02.

- **A**: en la demo y en 09, `UseSocketsHttpHandler` con `PooledConnectionLifetime`, recompilar, correr Cableado/, el Criterio nuevo y REF-139.
- **B**: no corregir; en el laboratorio el endpoint no cambia.
- **C** (SENIOR-02): sólo nombrar el límite: «si la dirección del servidor cambia, hace falta reiniciar el proceso».

### C2-52 · La demo no cumple R3 y R6 de Examples/13, y nada enseña la reentrada de las herramientas (S2, coherencia/técnico)

Origen: ARQUIT-01 y ARQUIT-02 (misma raíz: las herramientas viven en Infrastructure/AI y el adaptador de salida las nombra).
Evidencia: la sonda sin modelo dio R3 y R6 en rojo sobre la demo. Examples/13 registra un `Catalogo()` que nadie llama.

- **A** (en código): mover las herramientas a `Presentation/Herramientas`, inyectar `IReadOnlyList<AIFunction>` en el adaptador, sumar R3 y R6 con dos excepciones declaradas, re-verificar CTRL-06, el párrafo de la reentrada en §7.2 y D-12 en el Anexo F.
- **B**: no corregir; la demo es un caso didáctico y la regla se enseña con Examples/13.
- **C** (sólo texto, «opción mínima» de ARQUIT-01): §4.5.5 y §4.6.3 reescritos como deuda declarada, la línea de §9.3.1, el párrafo de la reentrada en §7.2 y D-12, sin tocar el código.
- **D**: C, más conectar `Catalogo()` en Examples/13 o declarar en su README que no se conecta.

### C2-53 · El motor de la prueba de capas de la demo no ve argumentos genéricos de método (S3, técnico)

Origen: ARQUIT-03.
Evidencia: `AddSingleton<ChatMessage>()` en el núcleo da 0 hallazgos en la demo y 1 en Examples/13.

- **A**: reemplazar ReglaDeCapas.cs por el motor de 13 y sumar el caso rojo.
- **B**: no corregir; el motor cubre el núcleo con los casos rojos que declara.
- **C**: sólo la oración en §4.6.3.

### C2-54 · El diagrama de §4.5 no coincide con la demo (S3, coherencia)

Origen: ARQUIT-04.

- **A**: mermaid con PORTS separado, PERSA y LIM → UCN; en código, mover el registro de `LecturaDeResultadosEf` a Program.cs.
- **B**: no corregir; el diagrama es conceptual.
- **C**: el mermaid sin mover código, más la oración en §9.3.1.

### C2-55 · Examples/05 pone en Persistence un tipo que genera embeddings (S3, coherencia)

Origen: ARQUIT-05.

- **A**: la oración en §6.6.3 que declara la simplificación.
- **B**: no corregir.
- **C**: en código, mover el archivo a `Infrastructure/AI/` y actualizar las tres rutas de los snippets.

### C2-56 · La guía no dice dónde va un workflow de MAF en las capas (S3, coherencia)

Origen: ARQUIT-06.

- **A**: el párrafo de ARQUIT-06 en §7.2, a continuación del de la reentrada (C2-52).
- **B**: no corregir; Examples/10 es un ejemplo de API.

### C2-57 · «No del tamaño del modelo» generaliza desde dos modelos chicos (S3, coherencia)

Origen: EXPERT-05.

- **A**: «Con estos dos tamaños, el tamaño no lo evitó … Con modelos mayores no se midió», en §7.5 y §9.5.3.
- **B**: no corregir; la frase dice dónde nace el riesgo (ofrecer la herramienta), que es independiente del tamaño por diseño.

### C2-58 · qwen3.5:4b en la demo: la elección no se reproduce ni se midió en la estación de 4 núcleos (S3, evidencia)

Origen: ADV-05.

- **A**: la oración de §9.7 de ADV-05.
- **B**: no corregir; el 4b se elige por continuidad, y §9.7 ya lo dice provisional.
- **C** (ADV-05, opcional): A más una corrida R-LLM con qwen3.5:2b en la composición de la demo (D1, D3 y D6; 10 semillas; criterio escrito antes) y un turno de D5 en la estación de 4 núcleos.

### C2-59 · Vía B de Examples/05 no reproducible, y 8/8 por debajo de R-LLM-3c (S3, reproducibilidad)

Origen: AH-02-06.

- **A** (preferida): agregar ConModelo/ViaBConModeloTests.cs con m = 10.
- **B**: no corregir; es una sonda del ciclo 1 que el plan §10.2 dicta textual.
- **C**: dejar el párrafo y sumar la oración «sonda de laboratorio, sin prueba; 8/8 se lee como existencia».

### C2-60 · La prueba del 503 de Examples/09 depende del orden de llegada (S3, técnico)

Origen: AH-02-07.

- **A**: conteos en lugar de posiciones (3 × 200, un 503 con Retry-After, 3 llamadas), y el texto de §8.6.
- **B**: no corregir; con el calentamiento pasa.
- **C**: A más la compuerta con TaskCompletionSource.

### C2-61 · Examples/03 declara el timeout en el appsettings base, contra la regla (S3, coherencia)

Origen: CAT-OP-05.

- **A**: declarar la excepción en §5.3 y en el comentario del archivo, sin mover el valor (moverlo rompe las pruebas).
- **B**: no corregir.
- **C**: mover el valor y cambiar Dobles/Opciones.cs para que lea el appsettings del entorno.

### C2-62 · La cola del limitador no se dimensiona con la latencia (S3, técnico)

Origen: CAT-OP-07.

- **A**: el párrafo «La cola también es espera» en §8.6 y la pregunta en A.1.
- **B**: no corregir; Permisos, Cola y Retry-After están declarados como valores elegidos.

### C2-63 · Tres detalles .NET S4: Meter estático, registro mínimo en Examples/13 y limitador fuera de IOptions en 09 (S4, técnico)

Origen: SENIOR-04, SENIOR-05 y SENIOR-06. No entran al lote de forma porque cada uno puede cambiar código.

- **A**: la variante de solo texto de los tres (párrafo sobre IMeterFactory con REF-140, la nota de §4.4 y la oración después del snippet de §8.6).
- **B**: no corregir; son matices de estilo en ejemplos que funcionan.
- **C**: en código: alinear el registro de 13 con IHttpClientFactory y timeout, construir el limitador de 09 desde IOptions, y verificar si las pruebas del contador corren en paralelo.

### C2-45 · LOTE S4 de forma (un solo ítem, se vota en bloque)

| Hallazgo | Corrección propuesta |
|---|---|
| VERIFI-05 | 167 → 168 s en §8.6, §9.8 y E.4 («168,20 (167,4 de lectura del prompt)») |
| DIDACT-08 | §1.3 l.289: «cualquiera» → «ESC-04 (variante)» |
| EDICIO-15 | README de Examples/ y Demos/: título «NN · Nombre», secciones fijas y enlace de vuelta a la guía |
| EXPERT-08 + DIDACT-05 (c) | §6.11.15: «Ese umbral no se midió acá» → «A partir de qué tamaño de corpus RAG empieza a convenir frente al contexto fijo en local no se midió acá» (se coordina con C2-38) |
| ARQUIT-08 | §9.9.3: la normalización la hace el caso de uso agregado, no el adaptador |
| AH-01-06 | §6.1: «ninguna escritura dependa del texto: sin herramientas que escriban, o con aprobación (§7.5)» |
| ADV-06 | §1.1: «las herramientas leen sólo la sesión del ámbito (aísla datos; no es control de acceso, §8.3.2)» |
| EDICIO-14 (parte cita) | §8.7: citar el título de D-06 tal cual (el resto de EDICIO-14 va en C2-64) |

- **A**: aplicar el lote completo.
- **B**: no aplicar. Ninguno cambia lo que el lector hace; el costo es el riesgo de editar 13 README.
- **C**: el lote sin EDICIO-15 (los README), que es el único cambio extenso.

### C2-64 · El Anexo F tiene campos desiguales (S3, edición)

Origen: EDICIO-14 (la parte de los campos).

- **A**: «*Situación:*» en D-02…D-10 y «*Criterio:*» en D-11.
- **B**: no corregir; los campos que faltan se deducen del texto.

### C2-65 · Formato de la ubicación de los snippets («Compila en») (S3, edición)

Origen: EDICIO-10.

- **A**: forma única antes del bloque, con `sed` para los rangos, sin cursiva y moviendo las ubicaciones de §4.4, §4.6, §6, §8 y §9.
- **B**: no corregir; las 59 ubicaciones son correctas aunque desparejas.
- **C**: sólo el `sed` de los rangos y los asteriscos, sin mover ubicaciones.

### C2-66 · Encabezados repetidos al abrir cada sección (S3, compresión)

Origen: EDICIO-06.

- **A**: «Cifras» en una línea; borrar el endpoint por defecto, la lista de paquetes de §7 y §9, la frase del molde y «Ninguna fila ni columna queda vacía» (ahorro de unas 380 palabras).
- **B**: no corregir; el lector que entra por una sección necesita el recuadro completo.

### C2-67 · Los anexos y §8.12 repiten el cuerpo (S3, compresión)

Origen: EDICIO-13.

- **A**: D.2, E.5 regla 3, E.3, REF-022 y §8.12.2 reducidos a remisiones (ahorro de unas 650 palabras).
- **B**: no corregir; los anexos son de consulta y deben leerse solos.
- **C**: todo menos E.5 regla 3, que la CAT-formal propone editar (C2-36).

### C2-68 · Voz única: persona gramatical mezclada (S3, coherencia)

Origen: EDICIO-08 (la parte de persona; los nombres de escenario van en C2-01).

- **A**: respuestas en impersonal («Cuando se puede escribir la función», «Primero, el inventario»…).
- **B**: no corregir; el voseo en las preguntas guía es deliberado (le habla al lector que pregunta) y es el registro rioplatense del PO.
- **C**: impersonal sólo fuera de las preguntas guía (§2.6, §9.7 y §9.8).

## 3. Nota de numeración

Los ids se asignaron agrupando por raíz. C2-13 está vacío porque lo absorbió el lote C2-45, y C2-45 se dejó para el lote, por eso la numeración salta. Total para votar: **67 ítems** (C2-01 a C2-68, sin C2-13 y con C2-45 como lote).
