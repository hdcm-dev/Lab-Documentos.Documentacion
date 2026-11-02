---
doc_id: BIT-16-M2-INF-REQ
doc_type: informe-de-especialista
rol: Requisitos (núcleo permanente, M§4.1.1)
objeto: BIT-16-04 v1 (04-Plan-De-Integracion.md, estructura aprobada v1)
ciclo: 2
modo: a ciegas (no se leyó ningún otro informe de Mesa/Ciclo-2/02-Informes/)
fecha: 2026-10-26
---

# Informe de Requisitos — Ciclo 2 sobre el plan de integración v1

**Mandato.** Trazar S-xx e insumos I-01…I-06 hasta las secciones y ejemplos de la v1, y buscar huecos y ambigüedades nuevas que hayan introducido los parches del ciclo 1. No se repiten los hallazgos REQ-01…REQ-07 del ciclo 1 que ya quedaron corregidos.

**Fuentes contrastadas.** Plan v1 (§A–§H); BIT-16-02 §6 (la matriz única vigente después de PAR-21); REED-16 §2 y §7; I-01…I-06; Mesa/Ciclo-1/04, 06, 07 y 08.

**Aclaración sobre el despacho.** El despacho llama AJ-08 a la asignación de OA a las preguntas guía. En `07-Aplicacion-Y-Verificacion.md` (l. 32 y l. 35) eso es **AJ-05**; AJ-08 es la corrección de la fila S-12 de BIT-16-02. El plan dice AJ-05 en todas sus fichas. En este informe uso la numeración de 07.

## 1. Hallazgos

### REQ2-01 · S2 · E2 · confianza 0,85 — AC-3b deja sin criterio de cierre a PD-7 y a los ejemplos de nivel de turno C que sí llaman a un modelo, y los pasos PD-n no tienen ni M ni oráculo

- **Ubicación**: §F.10 AC-3b (l. 818); §E.5, tabla de niveles de turno (l. 666-668); §F.1, tabla de pasos (l. 685-693); §F.8 ConModelo (l. 801).
- **Afirmación**: AC-3b exige registro R-LLM válido para «cada PD-1…PD-6 y cada ejemplo de nivel A de §E.5», y para los de nivel B un registro o la marca «no ejecutado». Quedan afuera tres cosas.
  1. **PD-7**: ESC-05 y el único paso de MCP. Por OA-D8 y por el ejemplo 13 hay modelo del lado del cliente.
  2. **05 y 06**: son nivel C («sin `<recurso-compartido>`», 0 llamadas), pero llaman a un modelo, `qwen2.5:0.5b` y `qwen3-embedding:0.6b`, en el Ollama propio.
  3. **Los pasos PD-n**: AC-3b exige «M entradas distintas» y F.8 remite a «oráculos y precondiciones declarados … en la del paso». Pero la tabla de F.1 no tiene columna de M ni de oráculo, y §E.5 presupuesta «una corrida de humo por paso (6 × 2)».
- **Evidencia**: E2. l. 818: «Cada PD-1…PD-6 y cada ejemplo de nivel A de §E.5 tiene al menos un registro R-LLM válido (M entradas distintas…)». l. 668: «C · sin <recurso-compartido> | 05 y 06 (Ollama propio…) | 0». l. 631: 05 corre con «`qwen2.5:0.5b`». l. 685: las columnas de F.1 son «Paso | v0 | Escenario | Capacidad | Escalón | Qué muestra». El cierre del ciclo 1 (08-Cierre, `coherencia.requisitos_sin_prueba: 0 … PD-1…PD-7 con AC-3b/AC-4`) da por cubierto lo que AC-3b no cubre.
- **Impacto**: S-17 («probar todo… con el modelo Qwen») y la pregunta 6 de REED-16 §7 («qué muestra la demo funcionando contra Qwen») se cierran sin criterio para ESC-05 ni para las cifras de §6 (05) y §7 (06). Además, AC-3b no se puede verificar en ningún PD-n porque no está definido qué es un registro «válido» de un paso con dos llamadas.
- **Dirección**: dos cambios. (a) Que AC-3b nombre la lista cerrada que cubre: todo ejemplo y paso que llama a un modelo, cualquiera sea el servidor. Para el nivel C, el criterio es un registro con `servidor = propio`. PD-7 entra o se declara sin modelo, con motivo. (b) Agregar a F.1 las columnas «Entradas (M)» y «Oráculo», como las de §E.2, y recalcular la fila A de §E.5 con esas M.

### REQ2-02 · S2 · E1 · confianza 0,85 — La matriz única de BIT-16-02 §6 tiene una fila sin contenido y dos filas atribuidas a pedidos que no son los del insumo; falta I-02

- **Ubicación**: BIT-16-02 §6, l. 172, 174-177 (la matriz que el plan declara única: §D PR-12, PR-15); plan §G.4 P-05 (l. 883); plan §H (l. 900).
- **Afirmación**: la matriz que reemplazó a la tabla vieja (PAR-21) no traza lo que dice trazar.
  - **Q1–Q6**: la fila dice «(una fila por pregunta, con su sección)», pero no tiene esas filas. El criterio «cada una con sección» no se puede correr.
  - **I-04 §5.2**: en el insumo, el punto 2 es «si la señal de evaluación alcanza para convocar a AH-02». La fila lo registra como «Preocupaciones de audiencia → relectura».
  - **I-05 §5.2**: el punto 2 es «si PR-17 abre un escenario nuevo en N0 o es una variante de ESC-04». La fila lo registra como «PR-16…PR-22». Esa pregunta tampoco está resuelta en el plan: P-05 la reformula como «un par de **contextos**» y la deja en «No por ahora».
  - **I-02**: no tiene fila, aunque su §5.2 (si PR-3 cabe en la demo o va en ejemplos separados) es un pedido explícito.
  - **§H**: dice «PAR-01…PAR-23», pero el encabezado (l. 16) y 06-Aprobacion (l. 43) tienen 24 parches. PAR-24 es justamente el que toca §H.
- **Evidencia**: E1. BIT-16-02 l. 172: «| Q1–Q6 | … | (una fila por pregunta, con su sección) | — | cada una con sección |». l. 176: «| I-04 §5.2 | Preocupaciones de audiencia | relectura (PR-15) |». I-04 §5, punto 2: «Si la señal de evaluación alcanza para convocar a AH-02». I-05 §5, punto 2: «Si PR-17 abre un escenario nuevo en el marco N0 o es una variante de ESC-04». Plan l. 883 (P-05): «¿PR-17 abre un par de contextos…? | No por ahora». Plan l. 900: «parches PAR-01…PAR-23».
- **Impacto**: la compuerta C2 (REED-16 §9.1) y la relectura (PR-15) corren contra esta matriz y la darían por verde. Dos decisiones que el PO pidió explícitamente no tienen traza: la convocatoria de AH-02 y si PR-17 es escenario o variante. La de I-05 además sigue abierta con otra formulación.
- **Dirección**: en la capa de origen (BIT-16-02 §6), abrir Q1…Q6 en seis filas con su sección (§1/§3.1; §5/Anexo F; §6–§7; §8–§9; §10–§12; §14). Reescribir las filas I-04 §5.2 e I-05 §5.2 con el pedido literal y su resolución: AH-02 convocado en el ciclo 1, y para PR-17 una decisión explícita «escenario o variante de ESC-04». Si se mantiene la vía de contextos, declararla como apartamiento. Agregar una fila I-02 §5.1–§5.4 y corregir §H a PAR-24.

### REQ2-03 · S2 · E2 · confianza 0,75 — El plan de respaldo de P-12 no cubre todo lo que P-12 somete, y deja sin ejemplo a dos OA y a una subsección entera

- **Ubicación**: §G.4 P-12 (l. 890); §E.1 «Dominio» (l. 567); §E.2 filas 05 (l. 631) y 16 (l. 642); §F.2 siembra (l. 703); §A.3 OA-D3 y OA-S2 (l. 108, 124); §C §11.7 (l. 477).
- **Afirmación**: P-12 somete a la mesa tres contenidos «escritos para el ejemplo»: el reglamento de 05, el documento malicioso de 16 y la siembra de encuestas. Su plan de respaldo («si la mesa dice que no, 05 y 16 pasan a explicación conceptual») sólo nombra dos de los tres y no dice qué pasa con lo que depende de ellos.
  - **La siembra** sostiene PD-1 («¿qué medio usa más la gente?»), 12 y `resumir_encuesta`.
  - **05** es el único ejemplo de OA-D3.
  - **§11.7** es el ejemplo 16 tal cual.
  - El ciclo 1 cambió además el corpus de 05 a «la localidad ficticia Nº n», o sea **localidades inventadas**. I-06 pide que el caso se tome «de su ia-db y de su código». La pregunta de P-12 («usa sólo entidades y valores de Movilidad Urbana») no menciona ese rasgo.
  - La v1 no registra la decisión sobre P-12 (04-Veredictos l. 80 sólo vota que se someta), y ningún DEP la pone como condición previa de 05 y 16.
- **Evidencia**: E2. l. 890: «Si la mesa dice que no, 05 y 16 pasan a explicación conceptual (RD-PO-3)». l. 567: «(el reglamento sintético de 05, el documento malicioso de 16, la siembra de encuestas) … sometido a la mesa como P-12». l. 631: «70 artículos … cada uno "la localidad ficticia Nº n, provincia de `Catalogos`, código postal … generado"». I-06 RD-PO-1: «tomado de su ia-db y de su código (sólo lectura)».
- **Impacto**: si la mesa contesta «no», OA-D3 y la mitad de OA-S2 quedan sin ejemplo, contra el criterio de inclusión de §A.3, y §11.7 se queda sin contenido. PD-1 y 12 se quedarían sin datos, sin que nada lo haya previsto. Si contesta «sí» sin ver lo de las localidades ficticias, decide sobre una pregunta incompleta.
- **Dirección**: en este ciclo, que el jurado decida P-12 con la pregunta completa: incluir explícitamente «localidades ficticias numeradas» o reemplazarlas por las localidades reales de la siembra del caso base. El plan de respaldo tiene que nombrar los tres contenidos y, para cada uno, los OA, las secciones y los pasos que caen. Sumar P-12 como condición previa de 05, 12, 16 y PD-1 en §G.3.

### REQ2-04 · S3 · E1 · confianza 0,90 — Resto de la renumeración: §12 cita el ejemplo 16 y el 17 no tiene sección que lo aloje

- **Ubicación**: §C §12, línea «Ejemplos» (l. 489); §E.2 fila 17 (l. 643); §E.3 (l. 652).
- **Afirmación**: la ficha de §12 dice «Ejemplos: `16`». En la v1, 16 es la inyección indirecta (§11). El ejemplo de observabilidad pasó de 16 a 17 (E.3), y ninguna ficha de §C lo lista en su bloque «Ejemplos». AJ-06 corrigió la renumeración en otras fichas pero no en esta.
- **Evidencia**: E1. l. 489: «- Ejemplos: `16`; demo (README y `compose`).». l. 643: «`17-Observabilidad-Y-Pipeline` (v0 16) | A | §12.1–§12.3 · OA-O1». l. 652: «| 16 | 17 |» y «| 17 | 16 |». `grep -n "17" ` sobre las fichas de §C: ninguna línea «Ejemplos» contiene 17.
- **Impacto**: la sección dueña de OA-O1 remite a un ejemplo que no es el suyo. Quien redacte §12 desde la ficha va a poner el snippet de la inyección. El chequeo «todo ejemplo con sección» de la relectura falla sin que nadie lo vea, porque el cierre del ciclo 1 declaró 0 huérfanos.
- **Dirección**: cambiar a «Ejemplos: `17`; demo (README y `compose`)» y correr un chequeo mecánico de las dos direcciones: cada NN de §E.2 aparece en la línea «Ejemplos» de la sección de su columna «§», y cada número citado en §C existe en §E.2 con esa sección.

### REQ2-05 · S3 · E1 · confianza 0,80 — Las rutas de §0.2 no se derivan de §A.3, como el plan afirma, y dejan afuera preguntas guía atadas a los OA del propio actor

- **Ubicación**: §A.3 (l. 99, «las rutas de §0.2 … se derivan de ella, no se escriben a mano»); §C §0.2 (l. 367); §C §11, preguntas guía (l. 481); plantilla de §C (l. 341); §A.3, l. 95 y l. 97.
- **Afirmación**: el problema tiene dos caras.
  1. **Las rutas tienen secciones que no salen de ningún OA.** La ruta de ACT-ARQ suma §8.1, §8.6–§8.7 y §14, pero ninguno de OA-A1…A4 apunta ahí. Entonces la ruta se escribió a mano.
  2. **A la inversa, la ruta deja afuera preguntas de los OA del actor.** Las preguntas de los OA de ACT-OPS viven en §11: «¿Activo EnableSensitiveData…?» (OA-O1) y «¿Dónde pongo la API key…?» (OA-O2). La ruta de ACT-OPS (tronco + §5.5–§5.7, §10, §12) no pasa por §11. Pasa algo parecido con ACT-SEC: su ruta lista subsecciones (§7.6, §8.2–§8.5), y las preguntas guía viven en un bloque «Preguntas guía» sin número, que una ruta por subsecciones no alcanza.
  3. Además, §A.3 define dos veces a los lectores, en l. 95 y l. 97, con listas distintas: la segunda suma al lector que viene de SK.
- **Evidencia**: E1. l. 367: «ACT-ARQ: tronco + §6, §7, §8.1, §8.6–§8.7, §9, §13, §14 … ACT-OPS: tronco + §5.5–§5.7, §10, §12». l. 115-118: OA-A1…A4 → §13, §2.4, §6/§7, §9. l. 481: «"¿Activo EnableSensitiveData en producción para depurar?" (OA-O1…) · … "¿Dónde pongo la API key del proveedor?" (OA-O2…)». l. 347: «Cada pregunta vive en un solo lugar».
- **Impacto**: el lector de operación que sigue su ruta no lee dos preguntas que el plan le asigna. La regla «una sola fuente» (PR-14, H-034) se cumple de palabra y no en los hechos, y AC-9 y la relectura no tienen con qué detectarlo.
- **Dirección**: definir la derivación como regla mecánica. Ruta de un actor = tronco ∪ secciones de sus OA ∪ secciones donde vive una pregunta guía atada a sus OA. Lo que se agregue a mano va marcado con su motivo. Las rutas deben nombrar el bloque «Preguntas guía» de cada sección que incluyen. Unificar l. 95 y l. 97 en una sola definición de lectores.

### REQ2-06 · S3 · E2 · confianza 0,70 — El criterio de inclusión «ninguna sección sin OA» no se puede cumplir con la tabla actual, y varias asignaciones de AJ-05 lo esquivan con OA que no corresponden

- **Ubicación**: §A.3, l. 129 (criterio H-040); fichas §2 (l. 391), §4 (l. 407, 412), §9.8 (l. 457), §12.7 y §12.9 (l. 486), §14 (l. 510).
- **Afirmación**: el criterio dice que ninguna sección, ejemplo o pregunta guía entra sin un OA de la tabla. Pero hay subsecciones pedidas por el PO que no tienen OA que las cubra, y hay preguntas guía que AJ-05 ató a OA cuyo verbo no se ejercita en ellas.
  - **Subsecciones sin OA**: §4.1 «Por qué ahora» (PR-2), §12.9 «Realimentación» (PR-10), §12.7 Aspire (PR-11), §9.8 «La fecha de un tutorial» y §2.5 «Diseñar para respuestas que pueden estar mal».
  - **«¿Cómo diseño una pantalla para una respuesta que puede estar mal?» → OA-A2**: OA-A2 es «fijar la métrica, los tipos de error y el umbral». Diseñar una pantalla es otra cosa.
  - **«¿Qué cambió el diseño de aplicaciones: el tamaño del modelo o el uso de herramientas?» → OA-0.1**: OA-0.1 es «decidir si hace falta un modelo».
  - **«¿Qué cambió del caso base y por qué?» → OA-A1**: OA-A1 es «registrar una decisión como ADR».
- **Evidencia**: E2. l. 129: «ninguna sección, ejemplo o pregunta guía entra sin un OA de esta tabla». l. 116: «OA-A2 | … Fijar para un escenario la métrica, los tipos de error y el umbral para seguir | §2.4». l. 391: «"¿Cómo diseño una pantalla para una respuesta que puede estar mal?" (OA-A2; PG-2)». 07-Aplicacion l. 32: «Los OA asignados son criterio de la secretaría».
- **Impacto**: o el criterio obliga a recortar contenido que el PO pidió (PR-2, PR-10, PR-11), o se cumple con OA que el lector no ejercita en esa pregunta. En el segundo caso, §15 («un ítem por OA») evalúa algo distinto de lo que la sección enseña. Es la revalidación de AJ-05 que el cierre del ciclo 1 dejó pendiente.
- **Dirección**: dos opciones. (a) Sumar los OA que faltan, por ejemplo uno de «situar una decisión en el cambio de diseño» para §4.1 y uno de «diseñar la interacción para el error» para §2.5. (b) Declarar en §A.3 una excepción con motivo para las subsecciones de contexto que pidió el PO. En cualquiera de las dos, que didáctica revalide una por una las asignaciones de AJ-05, con el verbo del OA contra la pregunta.

### REQ2-07 · S3 · E2 · confianza 0,65 — AC-10 y la línea de base de la demo dependen de un commit y de una referencia git que la corrida no puede crear

- **Ubicación**: §F.2 (l. 697, «en un primer commit de trabajo "base 8fb4c3a sin cambios"»); §F.10 AC-10 (l. 825, «`git diff --stat base-8fb4c3a`»); matriz BIT-16-02 §6, fila S-09 (criterio AC-10).
- **Afirmación**: la única forma de verificar S-09 y PR-17 («sin reescribir») es comparar contra una referencia git `base-8fb4c3a`. Esa referencia se crea con un commit en el repositorio de la guía. Las reglas duras de esta corrida dicen «no commitear». El plan no ofrece otra forma de crear la línea de base y no dice quién crea esa referencia ni cuándo. Tampoco aclara si `base-8fb4c3a` es una rama, una etiqueta o un commit.
- **Evidencia**: E2. l. 697: «la demo empieza como **copia literal** … en un primer commit de trabajo «base 8fb4c3a sin cambios»». l. 825: «`git diff --stat base-8fb4c3a` contra la tabla». Contexto común del despacho, reglas duras: «no commitear».
- **Impacto**: AC-10 no se puede correr dentro de la corrida, así que S-09 y la tabla de delta de §14.1 se cerrarían sin verificación. Si alguien crea el commit para poder correrlo, rompe una regla dura.
- **Pregunta para la mesa**: ¿la línea de base se materializa sin git, por ejemplo con una copia exportada de `8fb4c3a` fuera del repo y `diff -r` contra la demo, como ya hace la regla de `_Comun` (§E.1, l. 572)? ¿O el commit se reserva para después de la corrida, con el PO? Lo que se decida tiene que quedar escrito en AC-10.

## 2. Revisado y bien

1. **REQ-02 a REQ-04 del ciclo 1 quedaron resueltos en el texto.** AC-3a y AC-3b separan la CI del cierre, y una corrida saltada «no cierra» (l. 817-818). PR-3 y PR-20 pasaron a **AC** con los desvíos nombrados (l. 539, l. 556), y la negativa de CP inválido tiene casa en 09 (l. 635). §F.2 trae un criterio E1 de procedencia por archivo y la tabla de delta en tres columnas (l. 697-711), que es lo que pedía REQ-04. El defecto que queda en ese tramo es el del mecanismo git (REQ2-07), no el criterio.
2. **REQ-06 y REQ-07 del ciclo 1 también.** §B.4 tiene la columna «Cuándo conviene / cuándo no (fuente)» en cada fila (l. 283-290). El Anexo A trae una plantilla por sección temática, con las preguntas por campo, y excluye §9 con motivo (l. 521). La ruta de ACT-ARQ ya incluye §7 (l. 367), así que OA-A3 se puede alcanzar.
3. **I-01 queda cubierto de forma unívoca.** El eje por mecanismo está elegido y fundado (§B.4, l. 281). Q-PO-1 a Q-PO-3 tienen cada una su pregunta guía literal en §9 (l. 461). El ejemplo de `[MessageHandler]` con la trampa `CS0534` es el 10, y LangGraph por HTTP va como snippet «adaptación no ejecutada» (§E.4 a). El apartamiento de PR-5 está declarado (§B.3, l. 268-273).

## 3. Solicitudes de convocatoria

- **Didáctica**: revalidar una por una las asignaciones de OA de AJ-05 (REQ2-06) y la regla de derivación de rutas (REQ2-05). El juicio sobre el verbo del objetivo frente a la pregunta es de didáctica.
- **Operación y entrega** (pendiente del ciclo 1): REQ2-07 (cómo se materializa la línea de base sin commit) y el cálculo de M y turnos de PD-n (REQ2-01 b).
- **Jurado**: decidir P-12 en este ciclo con la pregunta completa (REQ2-03). Desde Requisitos sólo constato que no hay decisión registrada y que el plan de respaldo está incompleto.
- **Presidencia**: resolver la pregunta de I-05 §5.2 («escenario nuevo o variante de ESC-04») o declarar como apartamiento la reformulación de P-05 en términos de contextos (REQ2-02).
