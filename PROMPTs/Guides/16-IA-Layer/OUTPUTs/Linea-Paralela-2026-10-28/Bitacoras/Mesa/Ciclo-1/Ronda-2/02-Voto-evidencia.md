---
doc_id: BIT-16-C1-R2-02-EVID
doc_type: voto
title: Voto del juez de evidencia, segunda ronda del ciclo 1 (por opción)
status: entregado
origin: agent
owner: juez de evidencia (REED-16 §9.4)
last_review: 2026-10-28
audience: [presidencia, relator, cuerpo-auditor]
traces: [Ronda-2/00-Boleta.md, Ronda-2/Consulta-*.md, Ronda-2/evidencia-*/, Ciclo-1/07-Dictamen-Presidencia.md, Ciclo-1/03-Parches.md (P-05), Ciclo-1/02-Voto-evidencia.md]
---

# Voto del juez de evidencia, segunda ronda del ciclo 1

Mi función es fija: **¿está respaldado por evidencia del nivel que declara?** Voto una clave por ítem (dictamen §3.4) y cada fundamento sale de esa pregunta. En los ítems dependientes, el voto está condicionado a lo que voté en el antecedente, y lo digo.

## 0. Lo que verifiqué yo mismo antes de votar (2026-10-28, 13:51 -03)

No me apoyé sólo en los resúmenes de las consultas. Abrí la salida cruda de las piezas que deciden votos:

| Pieza | Comprobación | Resultado |
|---|---|---|
| AH-01 D1h y D2 (`evidencia-AH-01-seguridad/D-salida.txt`) | `grep -n 'D1h\|D2'` | l. 14: `"ejecutadas_ids":"77"`. l. 16: Singleton + `ValidateScopes=false`, las dos sesiones «ve sesión raiz:c3b546bc», B «borradas 1». l. 17: `ValidateScopes=true`, `InvalidOperationException` en las tres llamadas de cada sesión. l. 21 y 23 (D3): `tipo` 5 con `definido:false`, `localidadId:-1` deserializado. Coincide con la consulta |
| Comparación 2b/4b (`03-comparacion.jsonl`) | sha256 y recuento por pedido, modelo y clase (`python3 -I`) | sha256 `8c66765f86ab4969…`, igual al de la consulta. D1: 2b 8 tal cual + 1 `3489959` + 1 no-llama; 4b 10 sin declarar (`34000`×8, `3400`, `34012`). D3: 2b 10 fuera de catálogo, 4b 10 esperado. D3-T: 2b 9 fuera, 4b 1 fuera (`bondi`). D6: 10/10 y 10/10. Coincide |
| AH-02 PC-10 (`salida-analisis-pc10.txt`) | lectura | P0 5/8 y P1–P5 8/8; ICC 0,286; efecto de diseño 3,00; χ² p = 0,0179; Cochran Q p = 1,00; misma semilla → salida idéntica 3/3. Coincide |
| PC-01 (`R2-mcp-salida.txt`, `R2-mcp-spec-transports-origin.txt`) | `grep` | 401 sin token y con token incorrecto, 400 con Host ajeno, 403 con Origin ajeno y middleware. La captura de la especificación dice «Servers MUST validate the Origin header on all incoming connections». Coincide |
| PC-02 (`PC02-salida.txt`) | `grep` | D: `token.usage input:n=3,suma=48` en el fallo; A: `input:n=2,suma=24` y `cache.aciertos n=1`; [S]: sin la sesión en la clave, «sesion-B: llamadas al cliente=0 → ACIERTO (respuesta de otra sesión)». Coincide |
| PC-03 | `grep -rl '"<clave-de-cabeceras>":{"'` sobre `OUTPUTs/` (txt, jsonl, json), excluida la sonda `R2-cuerpo` que lo provoca a propósito | 0 archivos. La sonda tiene 3 apariciones, las de los casos [C], [F] y [G]. «Hoy da 0» se sostiene |

Con eso, lo que las consultas declaran como E1 está respaldado en el nivel que declaran. Las marcas [C] que las propias consultas dejan abiertas (`CreateSlimBuilder` sin HostFiltering, MCP que ejecuta un `ApprovalRequiredAIFunction` sin pedir la aprobación, `ValidateOnBuild`, nombres por defecto de `[McpServerTool]`) siguen siendo C, y las tengo en cuenta abajo.

## 1. Bloque del perímetro

### C1-48 — **B**

- **Fundamento.** En la ronda 1 voté `INSUFICIENTE` y pedí la tabla D1–D7 → ESC → CTX con la columna «afirmación de la guía que la necesita como E1». La tabla existe (P-05) y la regla común dice: «una pieza entra a la demo sólo si figura en la columna "afirmación… como E1"». Aplicada al pie de la letra, esa regla deja **D1–D7 adentro**: D7 tiene su afirmación («MCP es otro adaptador de entrada», §6). Lo que la tabla no respalda con ninguna afirmación es el selector de proveedor, `AyudaRag` y la página de streaming de tokens, y eso va a `Examples/`. La rama A saca a D7 aunque está en la columna, así que contradice la regla que la sostiene. Lo que en la ronda 1 frenaba a D7 era que su control no estaba probado: M13 era C. Hoy está en E1 (PC-01: 400/401/403, con el Origin que exige la especificación MCP 2025-06-18 con un MUST), y el catálogo único también (PC-09: un cliente MCP real ve el mismo esquema, byte a byte). La opción C no es una composición que se pueda verificar: no dice qué piezas entran.
- **Condiciones.** (1) La demo usa `WebApplication.CreateBuilder`, o alguien verifica HostFiltering con el builder *slim*, que sigue en C (PC-01, precisión 1). (2) La lista que va a MCP se filtra a lectura. Con C1-40 = B no hay herramientas que escriban, y la marca C de PC-09 (MCP ejecutaría una herramienta que pide aprobación sin pedirla) deja de aplicar.

### C1-40 — **B** (voto C1-48 = B; mismo voto si C1-48 = A o C)

- **Fundamento.** En la ronda 1 voté A por una sola razón: `AccionPropuesta` no estaba compilada ni probada (PC-13, C). PC-13 hoy está cerrada con E1 + E3, y la objeción probatoria desaparece. Con las dos ramas medidas, la B es la única cuya garantía central se prueba como **invariante determinista** (R-LLM-3b): «ninguna herramienta de escritura en `ChatOptions.Tools`» (B1), que se verifica por reflexión, y «0 escrituras sin clic» (B4). La seguridad de la rama A depende de custodiar un almacén que D1h muestra como frontera de confianza (verifiqué `ejecutadas_ids: "77"`), y de un id que D1-ids muestra que no es secreto. D6 (10/10 bajas sin confirmar con el 2b **y** con el 4b, verificado) prueba que el riesgo nace de ofrecer la herramienta. B la saca. Con D7 en la demo (C1-48 = B), la rama A sumaría además la marca C de PC-09.
- **Condición.** D3 entra como prueba de `Cableado/`: una propuesta con `tipo` 5, o con id −1 o inexistente en la sesión, se descarta (lo verifiqué en `D-salida.txt` l. 21 y 23).

### C1-62 — **B** (sigue a mi C1-40 = B)

- **Fundamento.** D1, verificado: el 4b inventa el CP 10/10 sin declararlo, y uno de esos CP, el `3400`, pasa `LocalidadRules.CodigoPostal` (`^\d{4}$`). Con eso, «reglas más estrictas» (C) no basta: un CP inventado de cuatro dígitos es válido. El alta necesita que la persona confirme con los dos modelos (el 2b inventó 1/10). La forma B (un formulario precargado y editable en la operación normal) es la que AH-01 describe como el lugar donde se ve el CP inventado. Además, es coherente con C1-40 = B sin pasar por la regla 4 de la boleta.

### C1-55 — **B** (con C1-48 = B; mismo voto con A o C)

- **Fundamento.** Nadie midió `IAyuda` (lo dice la boleta, y ninguna consulta trae salida de `IAyuda`). En la tabla de P-05, la afirmación de D5 es «con 12 enunciados alcanza el contexto fijo». Esa afirmación se respalda con `AyudaContextoFijo` contra el oro de P-22, sin RAG en la demo. Una comparación pareada es una tasa de **tarea** sobre K preguntas (R-LLM-3d y 3e de AH-02), y su único costo medido es CAT-OP-07: 25–70 s por pregunta en la estación. El segundo servidor lee el prompt a 107,5–110,3 tok/s (verificable en `pc07/01-largo-4b.jsonl`), así que la comparación cabe mejor en `Examples/05`.
- **Condición.** La guía no escribe ninguna frase comparativa entre CAG y RAG hasta que corra `Examples/05` (es la parte común de P-23).

### C1-56 — **B** (con C1-48 = B; mismo voto con A o C)

- **Fundamento.** En la tabla de P-05, ninguna afirmación necesita como E1 el candidato de ESC-02 en la demo. D5 lo menciona sólo como «+ ESC-02 si P-22 entra a la demo», o sea condicionado, no requerido. Sus métricas (hit@k, recall@3, MRR@3, abstención) son tasas de tarea sobre las preguntas del oro: les rige R-LLM-3d, y `Examples/04` es donde se pueden correr con K suficiente. La fila N6 de 03 §4.1 tiene que decir lo que la demo cubre de verdad, que es la verificación de P-05.

## 2. Ubicación de la normalización

### C1-38 — **A**

- **Fundamento.** Lo que exijo es que la frase de la guía describa lo que el código hace y que el cierre se pueda verificar en forma mecánica. A conserva el criterio más fuerte y más simple de verificar, `diff -r = 0` sobre **todo** lo copiado. Además, la pertenencia al núcleo se comprueba por referencias: el agregado no referencia MEAI ni Infrastructure. Con A, la frase «el caso de uso y las reglas deciden» puede quedar casi como está, porque la pieza es del núcleo. C debilita el criterio de MI-05 a «18 archivos» y depende de que una lista se mantenga a mano. B es defendible si se corrige la frase, pero mete una regla de dominio en Infrastructure. Para la segunda entrada (D7, MCP con el catálogo único), A y B dan lo mismo. La comparación 2b/4b (verificada: el 2b deja medios fuera del catálogo 10/10 y el 4b propone `bondi` 1/10 en D3-T) prueba que la normalización no puede quedar en el modelo, cualquiera sea la ubicación.
- **Condición.** La prueba común con `medio: "piedra"` corre en `Cableado/` por la herramienta y por el endpoint normal, y da el mismo error. PC-15 suma validar en el servidor el largo del nombre y los enums antes del caso de uso, porque la ApiWeb no hace cumplir `LargoMaximoDelNombre = 60` (E7: guardó 300 caracteres).

### C1-53 — **A** (con mi C1-38 = A: `diff -r = 0` sobre todo lo copiado)

- **Fundamento.** La copia literal más C1-19 (cierre con `dotnet build`) es lo único que se verifica por diff y por compilación. La condición de AH-01 (que M2 quede) se cumple. El largo de 60 que no se aplica (AH-01 §7.1) es un defecto heredado, verificado en E7, y no es motivo para reimplementar: va como deuda declarada por P-16 («las reglas se enuncian como las hace cumplir el código»). B no trae evidencia propia.

## 3. Re-registros

### C1-67 — **A**

- **Fundamento.** Lo que hundía la propuesta en la ronda 1 era el campo `Comentario` **hipotético**. La variante `Localidad.Nombre` es un campo real con E1: un nombre de 57 bytes con la instrucción da 201, uno de 300 caracteres da 201, y el marcado también entra. La validez de la amenaza queda en E3, con su precondición, y la tasa L viene de un R-LLM completo (modelo@digest, T, semillas, fecha). B descarta evidencia disponible.
- **Condición.** La tasa L se rotula con el estimando de R-LLM-1, «este pedido»: una redacción del ataque y un pedido. Va así: 0/10, Wilson [0; 0,28], y 10/10 corridas que repiten el texto. Nunca va como control, y el control sigue siendo M3.

### C1-72 — **A**

- **Fundamento.** El 2/10 de X2 D1 es una tasa de un pedido (PC-10, E1 y E4) y no fija un umbral de la tarea. El «N ≥ 96» de P-02 sale del intervalo normal, que Bowyer et al. (arXiv:2503.01747v3, 2025-05-28) desaconsejan con estos N. Lo honesto es «no medido» hasta que exista la métrica. B pide investigar el umbral sin tener la métrica definida, y eso produciría un número sin objeto.
- **Condición.** K ≥ 10 y m ≥ 3 entran rotulados como **criterio de método** de AH-02, no como un hecho medido (AH-02 §2 lo dice así).

### C1-61 — **A**

- **Fundamento.** PC-05 trae E1 + R-LLM. Por `/v1`, MEAI.OpenAI descarta `TopK` sin avisar, `max_completion_tokens` no tiene efecto (se pidieron 3 y salieron 57), y Ollama no permite fijar `num_ctx` por pedido (E4, ronda 1). Con la vía `/v1` en la composición de la demo, M10 no se puede cumplir. La tabla de diferencias es justo la evidencia que tienen que llevar `Examples/01` y `06`.

### C1-64 — **A**

- **Fundamento.** PC-08 midió el costo, pero no la calidad del juez. Las únicas observaciones de calidad son anécdotas con N = 1 por celda: un falso negativo en C2, y Relevance y Coherence le ponen 4 a la respuesta incorrecta de C3. No hay anotaciones humanas para calibrar. A ya permite correr el juez en el segundo servidor como k/n con intervalo. B lo vuelve obligatorio dentro del ciclo, sin el conjunto anotado que haría falta para que ese k/n signifique acuerdo.
- **Condición.** Las condiciones medidas de PC-08 son duras: razonamiento apagado (con el razonamiento por defecto, 6 de 7 evaluadores dieron *Inconclusive*), `num_ctx` ≥ 8192 si entra Retrieval, y en la estación, «no medido».

### C1-42 — **A**

- **Fundamento.** Para el 35b-a3b, la causa queda **medida**: 21,05 GiB cargado, contra un contenedor de 5 GB. Para un denso de 7–9B sigue sin medirse. La posición B pone la causa en la lectura de prompt, y eso no se midió como causa: con 18–20 tok/s el modelo es lento, no imposible. A dice exactamente lo medido.

### C1-43 — **A**

- **Fundamento.** Verificado en `salida-analisis-pc10.txt`: P0 falla y P1–P5 dan 8/8. χ² entre pedidos da p = 0,018. «B omite la herramienta» existe, pero depende del pedido. Una tasa de un solo pedido no respalda «A por defecto» como rasgo de la vía. MI-01 se sostiene por diseño (EA-5).
- **Condición.** La tensión 1 usa la redacción de AH-02, con el estimando «este pedido»: «en una de seis preguntas de requisitos, B a veces contesta sin buscar (12/16)».

### C1-44 — **A**

- **Fundamento.** Es lo mismo que C1-64. Además, la marca «no medido» del costo se reemplaza por las cifras medidas de PC-08, cada una con su servidor: 21,4 min por caso en la estación, y 950 s para 28 evaluaciones en el segundo servidor. Nunca se usa la estimación «tokens / 19 tok/s», que subestimó un 35 %. B usa los 35 min como si alcanzaran para calibrar, y lo que falta es el conjunto anotado, no el tiempo.

### C1-45 — **A** (sigue a mi C1-61 = A)

- **Fundamento.** Es el mismo objeto que C1-61, con la misma evidencia (PC-05 y E4 de la ronda 1: «The OpenAI API does not have a way of setting the context size»).

### C1-46 — **A**

- **Fundamento.** Desde la evidencia, la forma es indiferente, como dije en la ronda 1. Lo que la evidencia exige es el contenido, y A lo ata por escrito al resultado de C1-12, que hoy es E1 de PC-11 (D2). B no fija el contenido. El número D-11 ya lo usó P-13, y eso es un hecho del registro, no un argumento a favor de un ADR propio.

### C1-50 — **A** (con C1-41 = A)

- **Fundamento.** Los números del rótulo nuevo están verificados en la salida cruda: D3 10/10 frente a 0/10, con intervalos de Wilson que no se solapan; D1 1/10 frente a 10/10; D6 10/10 y 10/10. El 2b medido es Q8_0, 2 683 396 812 bytes, digest `0689d44085e0…`. B no tiene respaldo: PC-07 no separa al 35b-a3b del 4b (10/10 en las dos sondas), es unas 4,2 veces más lento por llamada y no entra en la estación.
- **Condición.** El rótulo declara el estimando de R-LLM-1, porque son tasas de un pedido por escenario, no de la tarea: «elegido frente al 2b porque normaliza al catálogo en D3 (este pedido, 10/10 frente a 0/10)…; N = 10 por pedido y modelo, una corrida». El 4b sigue provisional (P-24).

### C1-51 — **A**

- **Fundamento.** A dice lo medido: P-03, P-07, el juez (PC-08) y la lectura de prompts largos. B extiende el servidor a la concurrencia y al contexto grande, que la consulta dejó explícitamente «no medido». Re-registrar B atribuiría una cobertura que no tiene evidencia.

### C1-59 — **A** (con mi C1-28 = A)

- **Fundamento.** D2 (E1, verificado) muestra el cruce real entre sesiones, y que la prueba que propone P-12 («la herramienta ve el `SessionId` de A») no lo detectaría. La prueba concurrente de M6 con la forma (a)–(c) es la que falla ante el defecto medido. B saca M13–M15, que hoy tienen E1 (PC-01) o son firmes.

### C1-71 — **A** (sigue a mi C1-46 = A)

- **Fundamento.** Es el mismo objeto que C1-46. Me rige la misma condición: el contenido de C1-12 tiene que estar entero.

## 4. Precisiones

### C1-12 — **A**

- **Fundamento.** En la ronda 1 pedí «pierde la sesión sin error» porque el cruce no estaba probado. Ahora lo está: D2 con la clase real, verificado en `D-salida.txt` l. 16. Las dos sesiones ven `raiz:c3b546bc`, B borra lo que creó A, y con `ValidateScopes=true` falla en cada llamada (l. 17), no al arrancar. B y C ya no coinciden con la evidencia. A es la única redacción del nivel E1.
- **Condición.** «Fuera de Development» apoya el título en el valor por defecto de `ValidateScopes` según el entorno. La sonda fijó el valor a mano y no midió ese valor por defecto, así que la guía cita la fuente oficial (URL, versión y fecha) o escribe el título en términos de `ValidateScopes=false`. `ValidateOnBuild` sigue en C y no entra al título.

### C1-37 — **B**

- **Fundamento.** PC-02 (E1, verificado en `PC02-salida.txt`) mide que la doble capa registra input 48 cuando el consumo real fue 24, en un solo punto de métrica que no se puede separar por capa. Una guía que enseña a medir costo no puede recomendar un pipeline cuyo histograma estándar da un número falso. La rama A de P-03 con `Counter<long>` da las tres señales con números correctos: spans de herramientas, aciertos (`cache.aciertos n=1`) y tokens sin doble conteo (`n=2, suma=24`). La opción C quedó refutada para las herramientas (SENIOR-01 y PC-02).
- **Condición.** El contador está demostrado en una sonda, no en `Cableado/`. La condición de coherencia histórica se cumple recién cuando la prueba pase a `Cableado/`, y hasta entonces M8 no se declara validado.

### C1-37-clave — **A**

- **Fundamento.** PC-02 [S] (E1, verificado): sin la sesión en la clave, la sesión B recibe la respuesta de la A. Con `CacheKeyAdditionalValues = [SessionId]`, dos sesiones dan dos fallos de caché. B no está probada: nadie midió que excluir de la caché los pedidos que leen `SessionContext` evite la fuga en los otros pedidos, y la clave seguiría sin la sesión. A es la única con E1 y vale para cualquier orden de C1-37.

### C1-41 — **A**

- **Fundamento.** Lo que pedí en la ronda 1 era una comparación punta a punta con el criterio escrito **antes**. Se cumplió con trazabilidad completa: el sha256 del criterio no cambió antes ni después, la operacionalización se escribió a las 12:05 y la primera llamada fue a las 12:38. El JSONL tiene el hash que dice la consulta. Para afirmaciones del nivel «este pedido», que es lo que dice el rótulo de C1-50 A, la evidencia está. B exige una comparación de tarea como condición para publicar, pero la guía no la afirma. Si algún día la afirma, ya le rige R-LLM-3d, y no hace falta este ítem para eso. C pide repetir con las mismas semillas, y PC-10 midió que eso reproduce byte a byte, sin evidencia nueva. La pared no se usa como argumento (Consulta 2b/4b, «Pared»), así que reservar el anfitrión no cambia nada de lo que se afirma.
- **Condición.** Si la guía escribe «el 4b es mejor» sin estimando, o como rasgo de la tarea, el rótulo ya no se sostiene.

### C1-49 — **A**

- **Fundamento.** Mis dos exigencias de la ronda 1 se cumplen en A: no apoyarse en la tasa de EA-6 (C1-43 = A) y rotular C «corrida sólo con un doble», porque ninguna consulta la corrió con el modelo. C, «la misma recuperación dentro del agente», necesita la definición de «agente» que fija la consulta de definiciones para la sección de agentes. Enseñarla antes de esa definición sería usar un término todavía no definido. La opción C (una línea) pierde la evidencia de API de EA-5, que compila. Entre A y B, el lugar es didáctico. Me inclino por A sólo por el orden de las definiciones.

### C1-36 — **A**

- **Fundamento.** Un núcleo con S1 abierto no tiene verificadas las afirmaciones de las que deriva una sección. Si se redacta esa sección antes, se publican frases con un nivel de evidencia que todavía no se comprobó. Es exactamente lo que mi función impide. El costo de A es chico: PC-02 ya corrió, así que N5 §4.2 se destraba en cuanto se aplica C1-37, y N0b se destraba con P-02 (C1-72). B deja redactar sobre núcleos sin verificar.

### C1-01 — **A**

- **Fundamento.** PC-03 trae E1: OllamaSharp 5.5.0 serializa los valores de `<clave-de-cabeceras>` por pedido dentro del cuerpo (`R2-cuerpo-salida.txt`, 3 apariciones a propósito). Mi `grep` sobre `OUTPUTs/`, sin contar esa sonda, da 0 archivos hoy. El patrón cubre una vía de fuga demostrada que los cuatro patrones de P-01 no ven: un valor dentro del cuerpo. La exclusión del commit no es evidencia de que el dato no esté, es sólo que no se publica. El dictamen §2 hace del barrido la condición del primer commit, y eso descarta C.

## 5. Suspensos parciales

### C1-14 — **B** (sigue a mi C1-40 = B)

- **Fundamento.** D1g (E1) muestra que la sesión serializada guarda el historial con el texto de la persona. En la rama B ese historial lleva vencimiento y queda fuera de los registros. «404 no es control de acceso» se declara en las dos ramas (E2–E5 sobre la ApiWeb real). El contrato A1–A5 tiene su E1 (D1b y D1h) y se enseña en `Examples/07`.

### C1-28 — **A** (con mi C1-48 = B, M13 va en la demo)

- **Fundamento.** Cada pieza de A tiene E1 o E4 con fuente. Loopback, `AllowedHosts` (400), Origin con middleware (403) y `RequireAuthorization` (401) están verificados en `R2-mcp-salida.txt`. El Origin es un MUST de la especificación MCP 2025-06-18 (https://modelcontextprotocol.io/specification/2025-06-18/basic/transports, consultada el 2026-10-28 y capturada). El catálogo único da el mismo esquema byte a byte (PC-09 [A]/[C]). B deja sin cumplir un MUST que está documentado, y C duplica las definiciones, sin evidencia de que eso sirva de algo y con los nombres por defecto todavía en C.
- **Condición.** Valen las dos condiciones de mi C1-48: el builder no *slim*, o HostFiltering verificado con el *slim*, y la lista de MCP filtrada a lectura. `RequireAuthorization` en CTX-PROD, y en la demo, loopback con `AllowedHosts` y Origin.
