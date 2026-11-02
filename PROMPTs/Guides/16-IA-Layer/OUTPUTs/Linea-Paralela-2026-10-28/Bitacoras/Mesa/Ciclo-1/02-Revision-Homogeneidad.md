---
doc_id: BIT-16-C1-02-revision-homogeneidad
doc_type: revision-abogado-del-diablo
title: Revisión por homogeneidad del voto del ciclo 1 (M§9, «consenso vacío»)
status: entregado
origin: agent
owner: abogado del diablo (M§9; REED-16 §9.4)
last_review: 2026-10-28
audience: [presidencia, jurado, cuerpo-auditor]
traces: [Mesa/Ciclo-1/01-Consolidado.md, Mesa/Ciclo-1/02-Voto-evidencia.md, 02-Voto-impacto.md, 02-Voto-costo-beneficio.md, 02-Voto-coherencia-historica.md, 02-Voto-riesgo.md, Mesa/Ciclo-1/Informe-abogado-del-diablo.md, Bitacoras/04-Integracion.md, REED-16 §6.2, §9.4, §9.5, M§4.3, M§9]
---

# Revisión por homogeneidad del voto del ciclo 1

**Mandato.** M§9 («consenso vacío») y REED-16 §9.4: si más del 80 % de los ítems sale 5-0, el ciclo se marca como sospechoso de homogeneidad y el abogado del diablo revisa los `NO_PROCEDE`. Escribo como abogado del diablo, no como juez: no voto. Lo que sigue es un pedido de reconsideración con evidencia, dirigido a la presidencia.

**Método.** Leí los cinco votos fila por fila en los ítems que no salieron 5-0 y en los que tienen opciones, crucé las dependencias que los propios jueces declaran ("acotado a C1-48", "según C1-40") y re-verifiqué en la fuente lo que sostiene cada pedido. No corrí nada contra el modelo ni compilé: la evidencia de esta revisión es E2 (lectura de los votos, del consolidado y de 04) más conteos E1 con `grep` del 2026-10-28. Por R-PRIV no escribo direcciones, usuarios ni rutas del home: las rutas van relativas a `OUTPUTs/` o a `Mesa/Ciclo-1/`.

## 1. Diagnóstico

| Medida | Valor |
|---|---|
| Ítems votados | 73 (C1-01…C1-72 y C1-S4) |
| Ítems 5-0 | 68 (93,2 %) — supera el umbral de 80 % |
| Ítems con resultado `NO_PROCEDE` | **0** |
| Votos individuales `NO_PROCEDE` | 4, en 3 ítems: C1-36 (impacto), C1-67 (coherencia histórica y evidencia), C1-72 (costo-beneficio) |
| Votos `INSUFICIENTE` | 2, ambos del juez de evidencia: C1-38 y C1-48 |

Leído al pie de la letra, el mandato de M§9 queda vacío: no hay ningún ítem `NO_PROCEDE` que revisar. No lo leo así. Lo que M§9 quiere detectar es un acuerdo que no es tal, y en este ciclo el acuerdo es sobre todo **de forma**.

**La causa es la boleta, no el panel.** En los hallazgos, `PROCEDE` quiere decir «corregir esto». En las contradicciones (C1-37…C1-48) y en los criterios MI (C1-49…C1-72), en cambio, los jueces usaron `PROCEDE` para decir «hay que resolverlo», y pusieron la decisión real en la columna de opción. Por eso un 5-0 convive con tres cosas distintas:

1. **Rechazo unánime de la propuesta**, que queda escrito como `PROCEDE` (C1-45, C1-46, C1-61, C1-64, C1-67, C1-71 y otros: §3.3).
2. **Divisiones 3-2 o 2-2-1 sobre la opción**, que no aparecen en el conteo (C1-38, C1-40, C1-49, C1-55, C1-62: §3.1 y §3.2).
3. **Votos `PROCEDE` condicionados a la salida de otro ítem que está dividido**. Ejemplos: C1-14 (costo-beneficio: «acotado al perímetro de C1-48 y a C1-40»; riesgo: «depende de C1-40»), C1-28 (costo: «M13 sigue al perímetro»), C1-55 (riesgo: «si C1-48 queda en B, voto la propuesta»).

Esto importa por una razón concreta. REED-16 §9.5 manda que el cuerpo auditor diseñe, **por hallazgo `PROCEDE`**, el texto exacto de la propuesta. Si el auditor lee el resultado tal como está, diseña parches para propuestas que el jurado rechazó. El caso más grave es C1-64, donde el resultado `PROCEDE` habilitaría un juez calibrado en la demo que los cinco jueces descartaron.

## 2. Los cuatro votos `NO_PROCEDE`

### 2.1 C1-67 (MI-19) — reconsiderar: el resultado tiene que ser `NO_PROCEDE` de la propuesta

- **Conteo:** 3 `PROCEDE` y 2 `NO_PROCEDE`. **En sustancia, 5-0 contra la propuesta.** Ningún juez eligió el campo `Comentario` hipotético. Coherencia histórica y evidencia votaron `NO_PROCEDE` justamente por eso. Los tres que votaron `PROCEDE` eligieron la alternativa (conceptual) o la variante de Didáctica (`Localidad.Nombre`).
- **Evidencia:** RD-PO-3 (I-06): «los dominios inventados también se reemplazan». El juez de evidencia agrega que el campo «no puede tener E1 (no existe en el código) y contradice la copia literal verificable de MI-05». 04 l. 383 todavía deja `Examples/11` (C7, comentarios) «supeditado a MI-19».
- **Pedido:** registrar MI-19 como **`NO_PROCEDE` de la propuesta (5-0 material)**, con esta resolución: «explicación conceptual hasta cerrar PC-14; si AH-01 valida `Localidad.Nombre` devuelto por una herramienta de lectura como E3, entra esa variante». Además, sacar `Examples/11` (C7) de la tabla de 04 §8 con una nota fechada. Los dos votos `NO_PROCEDE` eran los honestos: no hay nada que revertir en ellos, lo que hay que cambiar es el registro del resultado.

### 2.2 C1-72 (MI-24) — reconsiderar: la mesa no aprobó «investigar»

- **Conteo:** 4-1. **En sustancia, 5-0 contra la propuesta («investigar las dos cuestiones»).** Hasta el voto `PROCEDE` de coherencia histórica condiciona la parte (b) a que antes se fije la métrica de C1-02. Impacto y riesgo dan (a) por resuelta con C1-47.
- **Evidencia:** C1-47 salió con síntesis unánime (sincrónico con cancelación más eventos de etapa; segundo plano sólo en CTX-PROD). C1-02 (S1) prueba que la métrica de C2 todavía no tiene definición única. El juez de evidencia ubica el 2/10 de X2 D1 en un intervalo de Wilson de [0,06; 0,51].
- **Pedido:** registrar MI-24 como **`NO_PROCEDE` de «investigar»**, con dos resoluciones: (a) «resuelta por C1-47»; (b) «sin umbral hasta definir la métrica (C1-02) y medir con N suficiente; en la guía, "no medido"». Si queda como `PROCEDE`, el auditor programa turnos de modelo para un umbral que los cinco jueces dijeron que hoy no se puede fijar.

### 2.3 C1-36 — el `NO_PROCEDE` no cambia nada; el consenso sí merece un ataque

- **Conteo:** 4-1. El `NO_PROCEDE` de impacto («no bloquea la redacción») y los `PROCEDE` de costo, coherencia, riesgo y evidencia dicen lo mismo: el hecho está probado (0 de 9 núcleos tienen «Validación del núcleo»), no bloquea empezar a redactar y sí bloquea declarar validado un núcleo. Que el voto sea `PROCEDE` o `NO_PROCEDE` depende de cómo cada juez leyó la pregunta, no del fondo.
- **Ataque al consenso.** «No bloquea la redacción» es demasiado amplio. REED-16 §6.2 (l. 238) dice: «Un núcleo está validado cuando … la mesa no tiene S1/S2 abiertos sobre él». Hoy hay dos S1 abiertos en núcleos: C1-02 sobre N0b (dos definiciones de «falso aceptado») y C1-03 sobre N5 §4.2 (cola sin techo presentada como mitigación de LLM10). Si se redactan ya las secciones que derivan de N0b y de N5, se copian a la guía dos afirmaciones que el jurado votó falsas 5-0.
- **Pedido:** precisar la resolución de C1-36 así: «no bloquea la redacción en general; bloquea redactar las secciones que derivan de un núcleo con S1 abierto (hoy N0b por C1-02 y N5 §4.2 por C1-03) hasta que su parche esté aplicado y verificado; bloquea declarar "validado" y el cierre». No es una vuelta atrás. Es la regla de §6.2 aplicada sección por sección.

### 2.4 Los dos `INSUFICIENTE` de evidencia (C1-38 y C1-48)

Los trato con sus bloques en §3.1 y §3.2. El juez de evidencia fue el único que dijo, en dos ítems divididos, que ninguna posición traía la evidencia de su nivel. Los otros cuatro resolvieron igual. Que ese voto quede aislado es la señal de homogeneidad más clara del ciclo.

## 3. Ítems 5-0 que tienen que volver a ronda o registrarse de otra forma

### 3.1 Bloque del perímetro: C1-40, C1-48, C1-55, C1-56, C1-62 (y los condicionados C1-14, C1-28, C1-49) — segunda ronda conjunta

**Qué votó cada juez (orden de las opciones: evidencia, impacto, costo-beneficio, coherencia histórica, riesgo):**

| Ítem | Evidencia | Impacto | Costo-beneficio | Coherencia | Riesgo | División real |
|---|---|---|---|---|---|---|
| C1-40 escrituras | A | A (+ principio de B) | **B** | A | **B** | **3-2** |
| C1-62 MI-14 | propuesta | propuesta | **otra = B** | propuesta | **otra = B** | **3-2** |
| C1-48 perímetro | INSUFICIENTE (pieza por pieza) | A en piezas + controles | **A** | otra (lo ya resuelto + corte de la tensión 6) | **A** | 2 A + 1 A parcial + 2 «otra» |
| C1-55 MI-07 | propuesta | propuesta | **alternativa** | propuesta | **alternativa** (condicionada a C1-48) | **3-2** |
| C1-56 MI-08 | propuesta | propuesta | **alternativa** | propuesta | propuesta | 4-1 |

**Por qué la combinación que sale es incoherente.** La «demo mínima D1–D6» de C1-48 opción A es la de ABOGAD-05, y ABOGAD-05 la define con «baja por propuesta confirmada (D6, ABOGAD-01)» (Informe-abogado-del-diablo.md, ABOGAD-05, «La alternativa más fuerte»). Es decir, **la A de C1-48 trae adentro la B de C1-40**. Los ahorros que ABOGAD-05 promete (no hace falta almacén de sesiones ni contrato de aprobación entre peticiones, y por lo tanto C1-14 se achica) dependen de esa B. Si C1-40 sale A y C1-48 sale A, la demo es «mínima» y a la vez carga `ApprovalRequiredAIFunction` en D6, con su sesión pendiente, su endpoint de aprobación y PC-12 abierto. Ese costo es justamente el que el perímetro mínimo quería sacar. Pasa lo mismo con C1-55: la propuesta (dos adaptadores en la demo) le gana 3-2 a la alternativa (escalón 0 en la demo y RAG en `Examples/05`), y la alternativa es la que corresponde a la demo mínima. Impacto votó C1-48 «perímetro mínimo de piezas» y C1-55 «propuesta». Riesgo votó C1-48 A y C1-56 propuesta, que suma una pieza.

**Falta la evidencia que pidió el propio ciclo.** PC-13 («seguridad de `AccionPropuesta` tipada + operación normal frente a `ApprovalRequiredAIFunction`: id inyectado, confirmación en la UI, autorización», consolidado l. 674) está abierta. Es la comparación que S-ABOGAD-1 pidió a AH-01, y AH-01 no la contestó en su informe (0 apariciones de `AccionPropuesta` en Informe-AH-01-seguridad-llm.md). La decisión de seguridad más ajustada del ciclo, que es S2 y la única 3-2 de su tipo, se tomó sin la opinión del especialista de seguridad sobre la alternativa.

**Pedido:**
1. Votar en segunda ronda **C1-48 primero**, con la tabla que pidió el juez de evidencia: D1–D7 → ESC → CTX (C1-05) y, por cada pieza, qué afirmación de la guía la necesita como E1. Después, **C1-40/C1-62 con PC-13 cerrada** (consulta dirigida a AH-01, E3). Por último, C1-55 y C1-56, con la regla «no se suma a la demo una pieza que el perímetro votado no tiene».
2. Mientras tanto, los votos 5-0 de C1-14 y C1-28 valen **sólo en su parte que no depende del perímetro**. En C1-14 es el ADR del estado de la conversación. En C1-28 son el largo máximo de entrada y M14 en `Cableado/`. El resto queda en suspenso hasta la segunda ronda. Así lo dicen los propios votos de costo-beneficio y de riesgo.
3. La boleta de esta ronda **vota la opción, no `PROCEDE`**. Una mayoría ≥ 3 sobre una opción concreta, y empate o 2-2-1 → `INSUFICIENTE` (M§4.3, REED-16 §9.4).

### 3.2 C1-38 y C1-53: la ubicación de la normalización está empatada en la opción y choca con el `diff`

- **División real (opción):** coherencia B (adaptador); riesgo A (núcleo); impacto A «invocada desde el adaptador»; costo-beneficio síntesis («pieza nueva en Application que el adaptador invoca»); evidencia `INSUFICIENTE` con la misma síntesis. Según cómo se agrupe «A invocada desde el adaptador», sale 2-2-1 o 3-1-1. En el primer caso, M§4.3 manda `INSUFICIENTE` en primera ronda. El 4-0-1 del conteo lo tapa.
- **Objeción que nadie contestó.** Coherencia histórica escribió que A «obliga a modificar el núcleo copiado o agregarle una pieza que rompe "IA sólo agrega" y el `diff -r` = 0». Los otros tres respondieron «sigue siendo agregado», sin decir dónde vive el archivo. La evidencia que la sostiene es EA-2/EA-3 (04 l. 51): «copia literal de `Domain/`+`Application/` de ApiWeb … 18 archivos, `diff -r` = 0». Un archivo nuevo dentro de `Application/` hace que ese `diff -r` deje de dar 0. Entonces el criterio de verificación de MI-05 se rompe, o el archivo vive fuera del árbol copiado y ya no es «del núcleo» en el sentido de Arquitectura.
- **C1-53 hereda la división.** Lo aprobaron cinco votos `PROCEDE` con condiciones incompatibles: coherencia «con C1-38 B», riesgo «con C1-38 A», costo «con la síntesis». Un 5-0 sobre condiciones que se contradicen no aprueba un texto.
- **Pedido:** segunda ronda de C1-38 votando **una ubicación con carpeta**, por ejemplo «archivo agregado en una carpeta fuera del árbol copiado, que el adaptador invoca». Junto con eso, reescribir el criterio de MI-05 como «`diff -r` = 0 sobre los 18 archivos copiados; lo agregado vive en <carpeta> y figura en `PROCEDENCIA`». La prueba de cierre es la que propuso evidencia: inyectar `medio: "piedra"` por la herramienta y por el endpoint normal, y obtener el mismo error. C1-53 se re-registra después, con la condición que gane.

### 3.3 MI y contradicciones en los que `PROCEDE` quiere decir «gana la alternativa» — re-registro, no ronda

En estos ítems los cinco jueces coinciden, pero en contra de la propuesta o con una versión acotada. Pido que el resultado se registre con el texto que ganó, para que §9.5 no diseñe el parche equivocado:

| Ítem | Propuesta del consolidado | Lo que votaron los cinco | Registro pedido |
|---|---|---|---|
| C1-61 (MI-13) | Composición de la demo + ejemplo 01 | Sólo ejemplos 01 y 06 (5/5) | `NO_PROCEDE` de la propuesta; alternativa adoptada |
| C1-64 (MI-16) | Juez calibrado con 10–20 casos | Demo sin juez; método enseñado, k/n con intervalo, «no medido» (4 alternativa + 1 protocolo de R-C09 sin compuerta) | `NO_PROCEDE` de la propuesta; alternativa adoptada. Es la de más riesgo si se lee mal |
| C1-71 (MI-23) | ADR propio | Dentro de D-06 (4) + indiferente con contenido obligatorio (evidencia) | Alternativa adoptada |
| C1-46 | A: D-11 propio | B (4) + indiferente (evidencia) | B |
| C1-42, C1-43, C1-44, C1-45 | A en cada uno | B (5/5, o 4 + una variante de B en C1-44) | B en cada uno |
| C1-51 (MI-03) | Ollama en estación 2 para ≥ 7B, concurrencia, contexto grande y juez | 5/5 «otra (Operación)»: sólo P-03/P-07, bajo demanda, por la mesa; el resto «no medido» | Propuesta acotada al texto de Operación |
| C1-50 (MI-02) | 4b sin razonamiento como modelo | 5/5 con el rótulo «provisional» de C1-41 | Propuesta con rótulo (texto de C1-41) |
| C1-59 (MI-11) | M1–M12 con corte | 5/5 «otra»: M13, M14, largo de entrada, M11 en tres tipos y términos definidos | «Otra» adoptada; M13 en demo o en `Examples/08` según §3.1 |

### 3.4 C1-12 — el 5-0 descansa en una premisa que el juez de evidencia refutó

- El título dice «Singleton fuera de Development **mezcla sesiones** sin fallar». El juez de evidencia escribe: «O4 con `ValidateScopes=false` muestra que el Singleton ve `SessionId = (vacío)` … prueba que la sesión se pierde sin fallar, no que se mezclen datos de una sesión en otra: el cruce entre sesiones es PC-11 (C)». Lo repite en su resumen como el punto que más le pesa (02-Voto-evidencia.md, «Lo que más pesa», ítem 1).
- El voto de riesgo se apoya justamente en la premisa refutada: «una fuga de datos entre usuarios … de los riesgos más altos del lote».
- **Pedido:** el `PROCEDE` se mantiene, porque la primera mitad (un `HttpClient` por scope) es E1 firme. Lo que hay que cambiar es el título y el fundamento: «pierde la sesión sin error», con PC-11 como verificación. Un `PROCEDE` unánime no le da nivel E1 a una frase que uno de los cinco declaró C.

### 3.5 Condiciones aisladas que el 5-0 no aprobó

- **C1-37.** Los cinco piden PC-02 (doble capa) antes de fijar el orden. Lo que no está votado es qué pasa **si PC-02 falla**: coherencia dice que rige R-C07; costo-beneficio dice A, con la caché medida por un contador propio; impacto y riesgo dicen A. Hay que votar ese caso ahora, para que no vuelva como escalada. Riesgo, además, pone una condición que nadie más votó: con la caché por fuera de `UseFunctionInvocation`, **la clave de caché tiene que incluir la sesión**, o «una respuesta de la sesión A se sirve a la B». Es una condición de aislamiento (CTX-SENS). Pido que entre explícita en el parche o que se vote, pero que no se pierda en la columna de opción.
- **C1-41.** Hay acuerdo en «4b por defecto, no separado del 2b». No lo hay sobre si la comparación D1–D6 con criterio escrito antes de correr es **obligatoria antes de publicar** (evidencia, coherencia) o queda «si sobra turno» (costo) o «deseable, no bloquea» (impacto). Hay que definirlo.
- **C1-49.** La regla «A por defecto por diseño, no por EA-6» es unánime. Dónde va la vía C, no: tres jueces la mandan a §6 o a la sección de agentes como mención, y dos la enseñan como tercera vía rotulada «sólo con doble». Es una decisión de estructura de la guía que el 5-0 no tomó.

### 3.6 C1-01 — S1 con una compuerta que no da el mismo número dos veces

- Los recuentos de rutas del home no coinciden. El consolidado dice 20 en 11 archivos; el juez de evidencia, 20 en 9 fuera de `Mesa/` más 25 dentro de `Mesa/Ciclo-1/`; costo-beneficio, 13 `.md`. Mi recuento de hoy da 19 apariciones en 8 `.md` fuera de `Mesa/` (9 archivos de cualquier tipo) y 17 `.md` en todo `OUTPUTs/`. Los archivos cambian mientras el ciclo escribe. El problema no es el número: es que una compuerta S1 sin comando fijo no puede probar el cero.
- Hay una sola opción registrada («redacción in situ antes del primer commit»). Costo-beneficio y evidencia dejaron abierta la **exclusión del commit** como cierre válido. Eso no se votó, y la presidencia tiene que dictaminarlo de todos modos (SÓLO AGREGADO frente a redacción in situ).
- **Pedido:** fijar en el parche el comando exacto de la compuerta: patrones del prefijo del home, del rango CGNAT de la tailnet, de usuario@IP y hostnames (según C1-39), alcance `OUTPUTs/` **incluida `Mesa/`**, salida guardada con fecha. El criterio de cierre es «el comando guardado da 0», no un recuento en prosa.

## 4. Lo que ataqué y resiste

No todo 5-0 es homogeneidad. Estos ítems los busqué en la fuente y se sostienen:

- **C1-13 (timeout de 100 s).** Sospeché, porque las cifras del título (13–58 s; 96 s en EA-6) están por debajo de 100 s. Resiste: el juez de evidencia cita el s5 del experto, con 168 s de pared en una sola llamada de 2943 tokens, y el timeout por defecto de 00:01:40 en S-sonda2. Una llamada sola ya pasa el límite.
- **C1-02, C1-03 (S1).** Re-verificados por tres jueces en la fuente, con líneas (N0b l. 105 frente a l. 561; N5 l. 256 `QueueLimit = int.MaxValue`).
- **C1-39 y C1-47.** Unanimidad material de verdad, con la misma opción y el mismo fundamento en los cinco votos.
- **C1-35.** Resiste, con una salvedad de capa: la frase sale de `Mesa/I-01` §2 (l. 43), que es un insumo. El parche va a la integración y a N4. I-01 sólo recibe una nota fechada, por la regla de SÓLO AGREGADO.

## 5. Resumen para la presidencia

| Acción | Ítems |
|---|---|
| **Segunda ronda, votando la opción** | Bloque del perímetro: C1-48 → C1-40/C1-62 (con PC-13 cerrada) → C1-55, C1-56. Ubicación: C1-38 → C1-53 |
| **Re-registro como `NO_PROCEDE` de la propuesta, con la alternativa adoptada** | C1-67, C1-72, C1-61, C1-64 |
| **Re-registro con la opción que ganó** | C1-42, C1-43, C1-44, C1-45, C1-46, C1-50, C1-51, C1-59, C1-71 |
| **Precisión de la resolución** | C1-36 (bloquea las secciones de núcleos con S1 abierto), C1-12 (título y fundamento), C1-37 (rama en la que PC-02 falla; clave de caché con sesión), C1-41 (obligatoriedad de D1–D6), C1-49 (lugar de la vía C), C1-01 (comando fijo de la compuerta; exclusión frente a redacción in situ) |
| **Suspenso parcial hasta la segunda ronda** | C1-14 y C1-28, en la parte que depende del perímetro |

**Recomendación de procedimiento.** En los ciclos siguientes, la boleta de contradicciones y criterios MI vota la opción, no `PROCEDE`, y el umbral de 80 % de M§9 se mide sobre la opción. Con esa medida, este ciclo no habría dado 93 %: los ítems con división real o con condiciones que se contradicen son al menos nueve (C1-37, C1-38, C1-40, C1-41, C1-48, C1-49, C1-53, C1-55, C1-62).
